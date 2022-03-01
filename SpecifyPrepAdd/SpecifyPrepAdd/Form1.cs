/* This software was produced by 
 * The Florida Museum of Natural History c.2020
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 * 
 * This work is licensed under a 
 * Creative Commons Attribution-NonCommercial 4.0 International License.  
 * http://creativecommons.org/licenses/by-nc/4.0/
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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
        private string connectionString;
        private int agentID;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string connectionstring, int agentID)
        {
            InitializeComponent();
            this.connectionString = connectionstring;
            this.agentID = agentID;
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
               return new MySqlConnection(this.connectionString);
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
                bool hasHeaders = true;
                string HDR = hasHeaders ? "Yes" : "No";
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=Excel 8.0";
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                DataRow schemaRow = schemaTable.Rows[0];
                string sheet = schemaRow["TABLE_NAME"].ToString();
                if (!sheet.EndsWith("_"))
                {
                    string query = "SELECT * FROM [" + sheet + "]";
                    OleDbDataAdapter daExcel = new OleDbDataAdapter(query, conn);
                    daExcel.Fill(dt);
                }
            }
            catch (Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
            }
            return dt;
        }

        private DataSet GetTableDataSet(string tablename, string columns = "*", string order = "")
        {
            try
            {
                using (MySqlConnection conn = GetMySqlConnection())
                {
                    string select = String.Format("SELECT {0} FROM {1}{2}", columns, tablename, order);
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

        private String getSpecifyVersion()
        {
            try
            {
                using (MySqlConnection conn = GetMySqlConnection())
                {
                    string select = "SELECT AppVersion from spversion";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(select, conn);
                    string version = cmd.ExecuteScalar().ToString();
                    return version;
                }
            }
            catch (Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
                return null;
            }
        }

        private void fillAgentDataGrid()
        {
            try
            {
                using (MySqlConnection conn = GetMySqlConnection())
                {
                    string select = @"SELECT u.Name, CONCAT(coalesce(LastName, ''), ', ', coalesce(FirstName, '')) as 'AgentName', a.agentid
                                        FROM agent a 
                                        LEFT JOIN specifyuser u USING(SpecifyUserID)
                                        ORDER BY u.Name DESC, 
                                            AgentName ASC";
                    MySqlDataAdapter da = new MySqlDataAdapter(select, conn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "users");
                    agentDataGrid.DataSource = ds.Tables["users"];
                    agentDataGrid.Columns[0].HeaderText = "Specify Username";
                    agentDataGrid.Columns[1].HeaderText = "Agent Name";
                    agentDataGrid.Columns[2].HeaderText = "Agent ID";
                    DataGridViewCheckBoxColumn selectCol = new DataGridViewCheckBoxColumn();
                    selectCol.ValueType = typeof(bool);
                    selectCol.Name = "select";
                    selectCol.HeaderText = "Select";
                    agentDataGrid.Columns.Add(selectCol);
                    foreach (DataGridViewColumn column in agentDataGrid.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }


                }
            }
            catch (Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
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

        private List<string> getExternalColumns(string table)
        {
            try
            {
                using (MySqlConnection conn = GetMySqlConnection())
                {
                    conn.Open();
                    DataTable colls = conn.GetSchema("Columns", new string[] { null, null, table, null });
                    conn.Close();
                    var columns = (from DataRowView row in colls.DefaultView
                                   select row["COLUMN_NAME"].ToString());
                    return columns.ToList();
                }
            }
            catch (Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
                return null;
            }
        }

        private List<string> getExternalTables()
        {
            try
            {
                using (MySqlConnection conn = GetMySqlConnection())
                {
                    conn.Open();
                    DataTable allTables = conn.GetSchema("Tables");
                    conn.Close();
                    var tables = (from DataRow row in allTables.Rows
                                select row["TABLE_NAME"].ToString());
                    return tables.ToList();
                }
            }
            catch (Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
                return null;
            }
        }

        private List<string> getSpreadsheetExternalColumn()
        {
            try
            {
                List<string> columns = new List<string>();
                foreach (DataGridViewColumn col in CSVDataGrid.Columns)
                {
                    columns.Add(col.Name);
                }
                return columns;
            }
            catch (Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
                return null;
            }
        }

        private int GetCollectionObjectID(string identifier)
        {
            try
            {
                using(MySqlConnection conn = GetMySqlConnection())
                {
                    if (byCatNumButton.Checked)
                    {
                        string catNumSQL = @"SELECT CollectionObjectID FROM collectionobject 
                            INNER JOIN collection USING(CollectionID) 
                            WHERE collectionobject.CatalogNumber = LPAD(@CatNum, 9, '0')
                            AND collection.CollectionName = @CollName";
                        MySqlCommand cmd = new MySqlCommand(catNumSQL, conn);
                        cmd.Parameters.Add("@CatNum", MySqlDbType.String);
                        cmd.Parameters.Add("@CollName", MySqlDbType.String);
                        cmd.Parameters["@CatNum"].Value = identifier;
                        cmd.Parameters["@CollName"].Value = collectionComboBox.Text;
                        conn.Open();
                        int CollectionObjectID = (int)cmd.ExecuteScalar();
                        conn.Close();
                        return CollectionObjectID;
                    }
                    else if (byGUIDButton.Checked)
                    {
                        string GUIDsql = @"SELECT CollectionObjectID FROM collectionobject WHERE GUID LIKE @guid";
                        MySqlCommand cmd = new MySqlCommand(GUIDsql, conn);
                        cmd.Parameters.Add("@guid", MySqlDbType.VarChar);
                        cmd.Parameters["@guid"].Value = identifier;
                        conn.Open();
                        int collectionObjectID = (int)cmd.ExecuteScalar();
                        conn.Close();
                        return collectionObjectID;
                    }
                    return 0;
                }
            }
            catch(Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
                return 0;
            }
        }

        private string GetPrepGUID(long prepID)
        {
            try
            {
                using (MySqlConnection conn = GetMySqlConnection())
                {
                    string sql = @"SELECT GUID FROM preparation WHERE preparationID = @prepID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.Add("@prepID", MySqlDbType.Int64);
                    cmd.Parameters["@prepID"].Value = prepID;
                    conn.Open();
                    string prepGUID = (string)cmd.ExecuteScalar();
                    return prepGUID;
                }
            }
            catch (Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
                return null;
            }
        }

        private void AddExternalLocation(long prepID, string externalLocation)
        {
            try
            {
                using (MySqlConnection conn = GetMySqlConnection())
                {
                    string table = externalTableComboBox.SelectedItem.ToString();
                    string locationColumn = externalColumnComboBox.SelectedItem.ToString();
                    string locationBoolColumn = externalBoolComboBox.SelectedItem.ToString();
                    string sql = String.Format("UPDATE {0} SET {1} = @externalLocation, {2} = 1 WHERE preparationID = @prepID", table, locationColumn, locationBoolColumn);
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.Add("@externalLocation", MySqlDbType.String);
                    cmd.Parameters.Add("@prepID", MySqlDbType.Int32);
                    cmd.Parameters["@externalLocation"].Value = externalLocation;
                    cmd.Parameters["@prepID"].Value = prepID;
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
            }
        }

        private void AddPreps()
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
                int agentIndex = agentDataGrid.SelectedCells[0].RowIndex;
                int agentID = (int)agentDataGrid.Rows[agentIndex].Cells[2].Value;
                using (MySqlConnection conn = GetMySqlConnection())
                {
                    exportCSVButton.Visible = true;
                    DataGridViewColumn newColl = new DataGridViewColumn(CSVDataGrid.Rows[0].Cells[0]);
                    newColl.Name = "Inserted Prep GUID";
                    newColl.HeaderText = "Inserted Prep GUID";
                    CSVDataGrid.Columns.Add(newColl);
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
                                SELECT NOW(), 1, @CollectionID, 1, @CollectionObjectID, @AgentID, @PrepTypeID, UUID()";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.Add("@CollectionID", MySqlDbType.Int32);
                            cmd.Parameters.Add("@CollectionObjectID", MySqlDbType.Int32);
                            cmd.Parameters.Add("@PrepTypeID", MySqlDbType.Int32);
                            cmd.Parameters.Add("@AgentID", MySqlDbType.Int32);
                            cmd.Parameters["@CollectionID"].Value = collectionID;
                            cmd.Parameters["@CollectionObjectID"].Value = collectionObjectID;
                            cmd.Parameters["@PrepTypeID"].Value = prepTypeID;
                            cmd.Parameters["@AgentID"].Value = agentID;
                            conn.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            conn.Close();
                            if (rowsAffected > 0)
                            {
                                count += rowsAffected;
                                long prepID = cmd.LastInsertedId;
                                string prepGUID = GetPrepGUID(prepID);
                                row.Cells[CSVDataGrid.Columns["Inserted Prep GUID"].Index].Value = prepGUID;
                                if (externalRadioButton.Checked)
                                {
                                    string spreadsheetColumn = spreadsheetExternalColumnComboBox.SelectedItem.ToString();
                                    string externalLocation = row.Cells[CSVDataGrid.Columns[spreadsheetColumn].Index].Value.ToString();
                                    AddExternalLocation(prepID, externalLocation);
                                }
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

        private string getCSVText()
        {
            try
            {
                var sb = new StringBuilder();

                var headers = CSVDataGrid.Columns.Cast<DataGridViewColumn>();
                sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

                foreach (DataGridViewRow row in CSVDataGrid.Rows)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>();
                    sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
                }
                return sb.ToString();
            }
            catch (Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
                return null;
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
                spreadsheetExternalColumnComboBox.DataSource = getSpreadsheetExternalColumn();
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
                        string spversion = getSpecifyVersion();
                        if (spversion != Properties.Settings.Default.SpecifyVersion)
                        {
                            MessageBox.Show(string.Format("WARNING: Specify version mismatch.  This application supports and has been tested with Specify version {0}.  Your version is {1}.  Use at your own risk.", Properties.Settings.Default.SpecifyVersion, spversion));
                        } 
                        collectionComboBox.DataSource = getCollections();
                        fillAgentDataGrid();
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
                PrepTypeCombobox.DataSource = getPrepTypes(collectionComboBox.SelectedItem.ToString());
                PrepTypeBox.Visible = true;
            }
            catch (Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
            }
        }

        private void externalTableComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                externalColumnComboBox.DataSource = getExternalColumns(externalTableComboBox.SelectedItem.ToString());
                externalBoolComboBox.DataSource = getExternalColumns(externalTableComboBox.SelectedItem.ToString());
            }
            catch (Exception exc)
            {
                messageBox.AppendText(exc.ToString() + "\n");
            }
        }

        private void addPrepsButton_Click(object sender, EventArgs e)
        {
            AddPreps();
        }

        private void exportCSVButton_Click(object sender, EventArgs e)
        {
            exportCSVDialog.ShowDialog();
        }

        private void exportCSVDialog_FileOk(object sender, CancelEventArgs e)
        {
            string csvText = getCSVText();
            string filename = exportCSVDialog.FileName;
            File.WriteAllText(filename, csvText);
        }

        private void prepsOnlyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            externalColumnBox.Visible = false;
        }

        private void externalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            externalColumnBox.Visible = true;
            externalTableComboBox.DataSource = getExternalTables();
        }

        private void agentDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                foreach (DataGridViewRow row in agentDataGrid.Rows)
                {
                    row.Cells["select"].Value = false;
                    agentDataGrid.ClearSelection();
                }
                agentDataGrid.Rows[e.RowIndex].Cells["select"].Selected = true;
                agentDataGrid.Rows[e.RowIndex].Cells["select"].Value = true;
            }
                
        }

        private void MySQLDBLabel_Click(object sender, EventArgs e)
        {

        }

        private void MySQLHostLabel_Click(object sender, EventArgs e)
        {

        }

        private void MySQLUsernameLabel_Click(object sender, EventArgs e)
        {

        }

        private void MySQLPasswordLabel_Click(object sender, EventArgs e)
        {

        }

        private void MySQLDb_TextChanged(object sender, EventArgs e)
        {

        }

        private void MySQLHost_TextChanged(object sender, EventArgs e)
        {

        }

        private void MySQLPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void MySQLUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.O)
            {
                actionBox.Show();
                externalColumnBox.Show();
            }
        }

        private void AboutMenu_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.Show();
        }

        private void HelpMenu_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.ShowDialog();
        }
    }
}
