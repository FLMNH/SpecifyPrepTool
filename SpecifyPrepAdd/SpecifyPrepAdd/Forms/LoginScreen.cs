using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SpecifyPrepAdd
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
            tbServerName.Text = Properties.Settings.Default.MySQLServer;
            tbDBName.Text = Properties.Settings.Default.MySQLDatabase;
            tbCollectionName.Text = Properties.Settings.Default.SpecifyCollectionName;
            tbUserName.Text = Properties.Settings.Default.SpecifyUser;
            tbKey.Text = Properties.Settings.Default.SpecifyUserKey;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (tbUserName.Text.Length > 0
                && tbServerName.Text.Length > 0
                && tbDBName.Text.Length > 0
                && tbPassword.Text.Length >0
                && tbKey.Text.Length > 0)
            {
                try
                {
                    Decryptor decryptor = new Decryptor();
                    string[] master = decryptor.decrypt(tbKey.Text, tbPassword.Text).Split(',');
                    string connectionString = "server=" + tbServerName.Text + ";uid=" + master[0] + ";pwd=" + master[1] + ";database=" + tbDBName.Text;
                    MySqlConnection conn = new MySqlConnection(connectionString);
                    conn.Open();
                    Properties.Settings.Default.MySQLServer = tbServerName.Text;
                    Properties.Settings.Default.MySQLDatabase = tbDBName.Text;
                    Properties.Settings.Default.SpecifyCollectionName = tbCollectionName.Text;
                    Properties.Settings.Default.SpecifyUser = tbUserName.Text;
                    Properties.Settings.Default.SpecifyUserKey = tbKey.Text;
                    Properties.Settings.Default.Save();
                    int agentID = getAgentID(conn, getSpecifyUserID(conn, tbUserName.Text, tbPassword.Text));
                    int collectionID = getCollectionID(conn, tbCollectionName.Text);
                    if (hasPreparationModify(conn, tbUserName.Text,tbPassword.Text, tbCollectionName.Text))
                    {
                        this.Hide();
                        MainWindow mainWindow = new MainWindow(connectionString, agentID, collectionID, tbUserName.Text, tbCollectionName.Text, tbDBName.Text, tbServerName.Text);
                        mainWindow.ShowDialog();
                        this.Close();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Security.Cryptography.CryptographicException ex)
                {
                    MessageBox.Show("Unable to connect. Check that all fields are correct. " + ex.Message.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Complete all fields.");
            }
        }

        private int getSpecifyUserID(MySqlConnection conn, string username, string password)
        {
            try
            {
                string sql = "SELECT SpecifyUserID, Password FROM specifyuser where Name = @Name";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", username);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Decryptor decryptor = new Decryptor();
                        if (password.Equals(decryptor.decrypt(reader.GetString(1), password)))
                        {
                            return reader.GetInt32(0);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return -1;
        }

        private int getAgentID(MySqlConnection conn, int specifyUserID)
        {
            try
            {
                string sql = "SELECT AgentID FROM agent WHERE SpecifyUserID = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", specifyUserID);
                object result = cmd.ExecuteScalar();
                if (result == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return -1;
        }

        private int getCollectionID(MySqlConnection conn, string collectionName)
        {
            try
            {
                string sql = "select UserGroupScopeID from collection where CollectionName = @collectionName";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@collectionName", collectionName);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result.ToString());
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return -1;
        }

        private string getSpecifyUserType(MySqlConnection conn, string username, string password, string collectionName)
        {
            try
            {
                string sql = @"select 
                                    spprincipal.groupType
                                from
                                    spprincipal
                                    inner join specifyuser_spprincipal on spprincipal.SpPrincipalID = specifyuser_spprincipal.SpPrincipalID
                                    inner join specifyuser on specifyuser_spprincipal.SpecifyUserID = specifyuser.SpecifyUserID
                                where
                                    spprincipal.userGroupScopeID = @collectionID
                                    and GroupSubClass = 'edu.ku.brc.af.auth.specify.principal.GroupPrincipal'
                                    and specifyuser.SpecifyUserID = @specifyUserID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@collectionID", getCollectionID(conn, collectionName));
                cmd.Parameters.AddWithValue("@specifyUserID", getSpecifyUserID(conn, username, password));
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return result.ToString();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return String.Empty;
        }

        private bool hasPreparationModify(MySqlConnection conn, string username, string password, string collectionName)
        {
            if (isCollectionName(conn, collectionName))
            {
                string userType = getSpecifyUserType(conn, username, password, collectionName);
                if (userType.Equals("Manager"))
                {
                    return true;
                }
                else if (userType.Equals("LimitedAccess"))
                {
                    bool auth = isLimitedUserWithPrepModify(conn, getSpPrincipalID(conn, getSpecifyUserID(conn, username, password), collectionName));
                    if (!auth)
                    {
                        return auth;
                    }
                }
            }
            return false;
        }

        private bool isCollectionName(MySqlConnection conn, string collectionName)
        {
            try
            {
                string sql = "select count(UserGroupScopeID) from collection where CollectionName = @collectionName";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@collectionName", collectionName);
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    if (Convert.ToInt32(result.ToString()) == 1)
                    {
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return false;
        }

        private bool isLimitedUserWithPrepModify(MySqlConnection conn, int spPrincipalID)
        {
            try
            {
                string sql = @"SELECT 
	                                p.Actions
                                from 
	                                sppermission p
                                    inner join spprincipal_sppermission pp on p.SpPermissionID = pp.SpPermissionID
                                where 
	                                p.Name = 'DO.preparation'  
                                    and pp.SpPrincipalID = @spPrincipalID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@spPrincipalID", spPrincipalID);
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    return result.ToString().Contains("modify");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return false;
        }

        private int getSpPrincipalID(MySqlConnection conn, int userID, string collectionName)
        {
            try
            {
                string sql = @"select 
	                                spprincipal.SpPrincipalID
                                from 
	                                spprincipal 
                                    inner join specifyuser_spprincipal on spprincipal.SpPrincipalID = specifyuser_spprincipal.SpPrincipalID
                                    inner join specifyuser on specifyuser_spprincipal.SpecifyUserID = specifyuser.SpecifyUserID
                                where 
	                                spprincipal.userGroupScopeID = @collectionID
                                    and GroupSubClass = 'edu.ku.brc.af.auth.specify.principal.UserPrincipal'
                                    and specifyuser.SpecifyUserID = @userID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@collectionID", getCollectionID(conn, collectionName));
                cmd.Parameters.AddWithValue("@userID", userID);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result.ToString());
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return -1;
        }

    }
}
