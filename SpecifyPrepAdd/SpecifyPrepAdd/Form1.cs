using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SpecifyPrepAdd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            CSVDataGrid.DataSource = dt.DefaultView;
        }

        private MySqlConnection GetMySqlConnection()
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = MySQLHost.Text;
                builder.Database = MySQLDb.Text;
                builder.AllowZeroDateTime = true;
                builder.Port = 3306;
                builder.UserID = MySQLUser.Text;
                builder.Password = MySQLPass.Text;
                return new MySqlConnection(builder.ConnectionString);
            }
            catch (Exception e)
            {
                messageBox.AppendText(e.ToString() + "\n");
                return null;
            }
           
        }

        private void PopulatePrepTypeButton_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = GetMySqlConnection();

            }
            catch (Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
            }
        }

        private DataTable readCSV(string filePath)
        {
            DataTable dt = new DataTable();
            try
            {
                // create columns
                File.ReadLines(filePath).Take(1)
                    .SelectMany(x => x.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    .ToList()
                    .ForEach(x => dt.Columns.Add(x.Trim()));

                // add the rows
                File.ReadLines(filePath).Skip(1)
                    .Select(x => x.Split(','))
                    .ToList()
                    .ForEach(line => dt.Rows.Add(line));
            }
            catch (Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
            }
            return dt;
        }

        private DataSet GetTableDataSet(string tablename)
        {
            try
            {
                using (MySqlConnection conn = GetMySqlConnection())
                {
                    string select = String.Format("SELECT * FROM {0}", tablename);
                    MySqlDataAdapter da = new MySqlDataAdapter(select, conn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                    DataSet ds = new DataSet();
                    da.Fill(ds, tablename);
                    return ds;
                }
            }
            catch (Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
                return null;
            }
        }

        private List<string> getCollections()
        {
            try
            {
                DataSet ds = GetTableDataSet("collection");
                DataTable dt = ds.Tables["collection"];
                var collections = (from DataRow row in dt.Rows
                                   select row["CollectionName"].ToString());
                return collections.ToList();
            }
            catch (Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
                return null;
            }
        }

        private List<string> getPrepTypes(string collection)
        {
            try
            {
                using (MySqlConnection conn = GetMySqlConnection())
                {
                    string select = String.Format("SELECT Name FROM preptype INNER JOIN collection USING(CollectionID) WHERE CollectionName = '{0}'", collection);
                    MySqlDataAdapter da = new MySqlDataAdapter(select, conn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "preptype");
                    var preptypes = (from DataRow row in ds.Tables["preptype"].Rows
                                     select row["Name"].ToString());
                    return preptypes.ToList();
                }
            }
            catch (Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
                return null;
            }
        }

        private int GetCollectionObjectID(string guid)
        {
            try
            {
                using(MySqlConnection conn = GetMySqlConnection())
                {
                    string sql = @"SELECT CollectionObjectID FROM collectionobject WHERE GUID LIKE @guid";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.Add("@guid", MySqlDbType.VarChar);
                    cmd.Parameters["@guid"].Value = guid;
                    conn.Open();
                    int collectionObjectID = (int)cmd.ExecuteScalar();
                    conn.Close();
                    return collectionObjectID;
                }
            }
            catch(Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
                return 0;
            }
        }

        private void SelectCSVButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                SelectedCSVTextBox.Text = openFileDlg.FileName;
            }
        }

        private void SelectedCSVTextBox_Click(object sender, EventArgs e)
        {
            try
            {
                CSVDataGrid.DataSource = readCSV(SelectedCSVTextBox.Text).DefaultView;
            }
            catch (Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = GetMySqlConnection())
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        collectionComboBox.DataSource = getCollections();
                        collectionBox.Visible = true;
                    }
                }
            }
            catch (Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
            }
        }

        private void collectionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                PrepTypeCombobox.DataSource = getPrepTypes(collectionComboBox.Text);
                PrepTypeBox.Visible = true;
            }
            catch (Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
            }
        }

        private void addPrepsButton_Click(object sender, EventArgs e)
        {
            int count = 0;
            try
            {
                DataSet prepTypes = GetTableDataSet("preptype");
                var pts = (from DataRow preprow in prepTypes.Tables["preptype"].AsEnumerable()
                           where (string)preprow["Name"] == PrepTypeCombobox.Text
                           select preprow);
                int prepTypeID = (int)pts.First()["PrepTypeID"];
                DataSet collections = GetTableDataSet("collection");
                var coll = (from DataRow collrow in collections.Tables["collection"].AsEnumerable()
                            where (string)collrow["CollectionName"] == collectionComboBox.Text
                            select collrow);
                int collectionID = (int)coll.First()["CollectionID"];
                using (MySqlConnection conn = GetMySqlConnection())
                {
                    foreach (DataGridViewRow row in CSVDataGrid.Rows)
                    {
                        if (row.Cells[0].Value != null || row.Cells[0].Value != DBNull.Value || !String.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()))
                        {
                            int collectionObjectID = GetCollectionObjectID(row.Cells[0].Value.ToString());
                            string sql = @"INSERT INTO preparation (TimestampCreated, 
                                                            Version, 
                                                            CollectionMemberID, 
                                                            CountAmt,
                                                            CollectionObjectID, 
                                                            CreatedByAgentID, 
                                                            PrepTypeID, 
                                                            GUID)
                                SELECT NOW(), 1, @CollectionID, 1, @CollectionObjectID, 1, @PrepTypeID, UUID()";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.Add("@CollectionID", MySqlDbType.Int32);
                            cmd.Parameters.Add("@CollectionObjectID", MySqlDbType.Int32);
                            cmd.Parameters.Add("@PrepTypeID", MySqlDbType.Int32);
                            cmd.Parameters["@CollectionID"].Value = collectionID;
                            cmd.Parameters["@CollectionObjectID"].Value = collectionObjectID;
                            cmd.Parameters["@PrepTypeID"].Value = prepTypeID;
                            conn.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            conn.Close();
                            if (rowsAffected > 0)
                            {
                                count += rowsAffected;
                            }
                        }
                    }
                }
                MessageBox.Show(String.Format("{0} preps inserted", count));
            }
            catch (Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
                MessageBox.Show(String.Format("{0} preps inserted", count));
            }
        }
    }
}
