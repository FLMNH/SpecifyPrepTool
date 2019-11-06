﻿using System;
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
                                long prepID = cmd.LastInsertedId;
                                string prepGUID = GetPrepGUID(prepID);
                                row.Cells[CSVDataGrid.Columns["Inserted Prep GUID"].Index].Value = prepGUID;
                            }
                            if (externalRadioButton.Checked)
                            {

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

    }
}
