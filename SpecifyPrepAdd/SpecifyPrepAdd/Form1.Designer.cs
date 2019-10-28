namespace SpecifyPrepAdd
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MySQLUser = new System.Windows.Forms.TextBox();
            this.MySQLHost = new System.Windows.Forms.TextBox();
            this.MySQLDb = new System.Windows.Forms.TextBox();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.MySQLPasswordLabel = new System.Windows.Forms.Label();
            this.MySQLUsernameLabel = new System.Windows.Forms.Label();
            this.MySQLHostLabel = new System.Windows.Forms.Label();
            this.MySQLDBLabel = new System.Windows.Forms.Label();
            this.PrepTypeCombobox = new System.Windows.Forms.ComboBox();
            this.PrepTypeLabel = new System.Windows.Forms.Label();
            this.MySQLPass = new System.Windows.Forms.TextBox();
            this.SelectedCSVTextBox = new System.Windows.Forms.TextBox();
            this.SelectCSVButton = new System.Windows.Forms.Button();
            this.CSVFileLabel = new System.Windows.Forms.Label();
            this.CSVDataGrid = new System.Windows.Forms.DataGridView();
            this.messageBoxLabel = new System.Windows.Forms.Label();
            this.PrepTypeBox = new System.Windows.Forms.GroupBox();
            this.addPrepsButton = new System.Windows.Forms.Button();
            this.collectionBox = new System.Windows.Forms.GroupBox();
            this.collectionLabel = new System.Windows.Forms.Label();
            this.collectionComboBox = new System.Windows.Forms.ComboBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.prepsOnlyRadioButton = new System.Windows.Forms.RadioButton();
            this.importImagesRadioButton = new System.Windows.Forms.RadioButton();
            this.actionBox = new System.Windows.Forms.GroupBox();
            this.identifierBox = new System.Windows.Forms.GroupBox();
            this.byCatNumButton = new System.Windows.Forms.RadioButton();
            this.byGUIDButton = new System.Windows.Forms.RadioButton();
            this.exportCSVButton = new System.Windows.Forms.Button();
            this.exportCSVDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.CSVDataGrid)).BeginInit();
            this.PrepTypeBox.SuspendLayout();
            this.collectionBox.SuspendLayout();
            this.actionBox.SuspendLayout();
            this.identifierBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MySQLUser
            // 
            this.MySQLUser.Location = new System.Drawing.Point(47, 38);
            this.MySQLUser.Name = "MySQLUser";
            this.MySQLUser.Size = new System.Drawing.Size(226, 20);
            this.MySQLUser.TabIndex = 0;
            // 
            // MySQLHost
            // 
            this.MySQLHost.Location = new System.Drawing.Point(47, 127);
            this.MySQLHost.Name = "MySQLHost";
            this.MySQLHost.Size = new System.Drawing.Size(226, 20);
            this.MySQLHost.TabIndex = 2;
            // 
            // MySQLDb
            // 
            this.MySQLDb.Location = new System.Drawing.Point(321, 127);
            this.MySQLDb.Name = "MySQLDb";
            this.MySQLDb.Size = new System.Drawing.Size(226, 20);
            this.MySQLDb.TabIndex = 3;
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(587, 38);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageBox.Size = new System.Drawing.Size(596, 386);
            this.messageBox.TabIndex = 4;
            // 
            // MySQLPasswordLabel
            // 
            this.MySQLPasswordLabel.AutoSize = true;
            this.MySQLPasswordLabel.Location = new System.Drawing.Point(318, 22);
            this.MySQLPasswordLabel.Name = "MySQLPasswordLabel";
            this.MySQLPasswordLabel.Size = new System.Drawing.Size(91, 13);
            this.MySQLPasswordLabel.TabIndex = 5;
            this.MySQLPasswordLabel.Text = "MySQL Password";
            // 
            // MySQLUsernameLabel
            // 
            this.MySQLUsernameLabel.AutoSize = true;
            this.MySQLUsernameLabel.Location = new System.Drawing.Point(44, 22);
            this.MySQLUsernameLabel.Name = "MySQLUsernameLabel";
            this.MySQLUsernameLabel.Size = new System.Drawing.Size(93, 13);
            this.MySQLUsernameLabel.TabIndex = 6;
            this.MySQLUsernameLabel.Text = "MySQL Username";
            // 
            // MySQLHostLabel
            // 
            this.MySQLHostLabel.AutoSize = true;
            this.MySQLHostLabel.Location = new System.Drawing.Point(44, 111);
            this.MySQLHostLabel.Name = "MySQLHostLabel";
            this.MySQLHostLabel.Size = new System.Drawing.Size(67, 13);
            this.MySQLHostLabel.TabIndex = 7;
            this.MySQLHostLabel.Text = "MySQL Host";
            // 
            // MySQLDBLabel
            // 
            this.MySQLDBLabel.AutoSize = true;
            this.MySQLDBLabel.Location = new System.Drawing.Point(318, 111);
            this.MySQLDBLabel.Name = "MySQLDBLabel";
            this.MySQLDBLabel.Size = new System.Drawing.Size(91, 13);
            this.MySQLDBLabel.TabIndex = 8;
            this.MySQLDBLabel.Text = "MySQL Database";
            // 
            // PrepTypeCombobox
            // 
            this.PrepTypeCombobox.FormattingEnabled = true;
            this.PrepTypeCombobox.Location = new System.Drawing.Point(6, 68);
            this.PrepTypeCombobox.Name = "PrepTypeCombobox";
            this.PrepTypeCombobox.Size = new System.Drawing.Size(350, 21);
            this.PrepTypeCombobox.TabIndex = 9;
            // 
            // PrepTypeLabel
            // 
            this.PrepTypeLabel.AutoSize = true;
            this.PrepTypeLabel.Location = new System.Drawing.Point(6, 52);
            this.PrepTypeLabel.Name = "PrepTypeLabel";
            this.PrepTypeLabel.Size = new System.Drawing.Size(56, 13);
            this.PrepTypeLabel.TabIndex = 10;
            this.PrepTypeLabel.Text = "Prep Type";
            // 
            // MySQLPass
            // 
            this.MySQLPass.Location = new System.Drawing.Point(321, 38);
            this.MySQLPass.Name = "MySQLPass";
            this.MySQLPass.PasswordChar = '*';
            this.MySQLPass.Size = new System.Drawing.Size(226, 20);
            this.MySQLPass.TabIndex = 1;
            // 
            // SelectedCSVTextBox
            // 
            this.SelectedCSVTextBox.Location = new System.Drawing.Point(6, 29);
            this.SelectedCSVTextBox.Name = "SelectedCSVTextBox";
            this.SelectedCSVTextBox.Size = new System.Drawing.Size(350, 20);
            this.SelectedCSVTextBox.TabIndex = 12;
            this.SelectedCSVTextBox.TextChanged += new System.EventHandler(this.SelectedCSVTextBox_Click);
            // 
            // SelectCSVButton
            // 
            this.SelectCSVButton.Location = new System.Drawing.Point(362, 29);
            this.SelectCSVButton.Name = "SelectCSVButton";
            this.SelectCSVButton.Size = new System.Drawing.Size(144, 23);
            this.SelectCSVButton.TabIndex = 13;
            this.SelectCSVButton.Text = "Select CSV File";
            this.SelectCSVButton.UseVisualStyleBackColor = true;
            this.SelectCSVButton.Click += new System.EventHandler(this.SelectCSVButton_Click);
            // 
            // CSVFileLabel
            // 
            this.CSVFileLabel.AutoSize = true;
            this.CSVFileLabel.Location = new System.Drawing.Point(3, 16);
            this.CSVFileLabel.Name = "CSVFileLabel";
            this.CSVFileLabel.Size = new System.Drawing.Size(65, 13);
            this.CSVFileLabel.TabIndex = 14;
            this.CSVFileLabel.Text = "CSV Upload";
            // 
            // CSVDataGrid
            // 
            this.CSVDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CSVDataGrid.Location = new System.Drawing.Point(47, 430);
            this.CSVDataGrid.Name = "CSVDataGrid";
            this.CSVDataGrid.Size = new System.Drawing.Size(1136, 513);
            this.CSVDataGrid.TabIndex = 15;
            // 
            // messageBoxLabel
            // 
            this.messageBoxLabel.AutoSize = true;
            this.messageBoxLabel.Location = new System.Drawing.Point(584, 22);
            this.messageBoxLabel.Name = "messageBoxLabel";
            this.messageBoxLabel.Size = new System.Drawing.Size(55, 13);
            this.messageBoxLabel.TabIndex = 17;
            this.messageBoxLabel.Text = "Messages";
            // 
            // PrepTypeBox
            // 
            this.PrepTypeBox.Controls.Add(this.addPrepsButton);
            this.PrepTypeBox.Controls.Add(this.SelectedCSVTextBox);
            this.PrepTypeBox.Controls.Add(this.SelectCSVButton);
            this.PrepTypeBox.Controls.Add(this.CSVFileLabel);
            this.PrepTypeBox.Controls.Add(this.PrepTypeLabel);
            this.PrepTypeBox.Controls.Add(this.PrepTypeCombobox);
            this.PrepTypeBox.Location = new System.Drawing.Point(47, 312);
            this.PrepTypeBox.Name = "PrepTypeBox";
            this.PrepTypeBox.Size = new System.Drawing.Size(534, 112);
            this.PrepTypeBox.TabIndex = 18;
            this.PrepTypeBox.TabStop = false;
            this.PrepTypeBox.Visible = false;
            // 
            // addPrepsButton
            // 
            this.addPrepsButton.Location = new System.Drawing.Point(362, 66);
            this.addPrepsButton.Name = "addPrepsButton";
            this.addPrepsButton.Size = new System.Drawing.Size(144, 23);
            this.addPrepsButton.TabIndex = 15;
            this.addPrepsButton.Text = "Add Preps";
            this.addPrepsButton.UseVisualStyleBackColor = true;
            this.addPrepsButton.Click += new System.EventHandler(this.addPrepsButton_Click);
            // 
            // collectionBox
            // 
            this.collectionBox.Controls.Add(this.collectionLabel);
            this.collectionBox.Controls.Add(this.collectionComboBox);
            this.collectionBox.Location = new System.Drawing.Point(47, 242);
            this.collectionBox.Name = "collectionBox";
            this.collectionBox.Size = new System.Drawing.Size(534, 64);
            this.collectionBox.TabIndex = 19;
            this.collectionBox.TabStop = false;
            this.collectionBox.Visible = false;
            // 
            // collectionLabel
            // 
            this.collectionLabel.AutoSize = true;
            this.collectionLabel.Location = new System.Drawing.Point(6, 13);
            this.collectionLabel.Name = "collectionLabel";
            this.collectionLabel.Size = new System.Drawing.Size(86, 13);
            this.collectionLabel.TabIndex = 1;
            this.collectionLabel.Text = "Select Collection";
            // 
            // collectionComboBox
            // 
            this.collectionComboBox.FormattingEnabled = true;
            this.collectionComboBox.Location = new System.Drawing.Point(6, 29);
            this.collectionComboBox.Name = "collectionComboBox";
            this.collectionComboBox.Size = new System.Drawing.Size(350, 21);
            this.collectionComboBox.TabIndex = 0;
            this.collectionComboBox.SelectionChangeCommitted += new System.EventHandler(this.collectionComboBox_SelectionChangeCommitted);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(409, 166);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(138, 23);
            this.connectButton.TabIndex = 20;
            this.connectButton.Text = "Connect to DB";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // prepsOnlyRadioButton
            // 
            this.prepsOnlyRadioButton.AutoSize = true;
            this.prepsOnlyRadioButton.Checked = true;
            this.prepsOnlyRadioButton.Location = new System.Drawing.Point(6, 18);
            this.prepsOnlyRadioButton.Name = "prepsOnlyRadioButton";
            this.prepsOnlyRadioButton.Size = new System.Drawing.Size(110, 17);
            this.prepsOnlyRadioButton.TabIndex = 21;
            this.prepsOnlyRadioButton.TabStop = true;
            this.prepsOnlyRadioButton.Text = "Create Preps Only";
            this.prepsOnlyRadioButton.UseVisualStyleBackColor = true;
            // 
            // importImagesRadioButton
            // 
            this.importImagesRadioButton.AutoSize = true;
            this.importImagesRadioButton.Location = new System.Drawing.Point(122, 18);
            this.importImagesRadioButton.Name = "importImagesRadioButton";
            this.importImagesRadioButton.Size = new System.Drawing.Size(131, 17);
            this.importImagesRadioButton.TabIndex = 22;
            this.importImagesRadioButton.Text = "Also Populate External";
            this.importImagesRadioButton.UseVisualStyleBackColor = true;
            // 
            // actionBox
            // 
            this.actionBox.Controls.Add(this.importImagesRadioButton);
            this.actionBox.Controls.Add(this.prepsOnlyRadioButton);
            this.actionBox.Location = new System.Drawing.Point(47, 195);
            this.actionBox.Name = "actionBox";
            this.actionBox.Size = new System.Drawing.Size(281, 41);
            this.actionBox.TabIndex = 23;
            this.actionBox.TabStop = false;
            // 
            // identifierBox
            // 
            this.identifierBox.Controls.Add(this.byCatNumButton);
            this.identifierBox.Controls.Add(this.byGUIDButton);
            this.identifierBox.Location = new System.Drawing.Point(47, 153);
            this.identifierBox.Name = "identifierBox";
            this.identifierBox.Size = new System.Drawing.Size(281, 41);
            this.identifierBox.TabIndex = 24;
            this.identifierBox.TabStop = false;
            // 
            // byCatNumButton
            // 
            this.byCatNumButton.AutoSize = true;
            this.byCatNumButton.Checked = true;
            this.byCatNumButton.Location = new System.Drawing.Point(6, 16);
            this.byCatNumButton.Name = "byCatNumButton";
            this.byCatNumButton.Size = new System.Drawing.Size(116, 17);
            this.byCatNumButton.TabIndex = 22;
            this.byCatNumButton.TabStop = true;
            this.byCatNumButton.Text = "By Catalog Number";
            this.byCatNumButton.UseVisualStyleBackColor = true;
            // 
            // byGUIDButton
            // 
            this.byGUIDButton.AutoSize = true;
            this.byGUIDButton.Location = new System.Drawing.Point(128, 16);
            this.byGUIDButton.Name = "byGUIDButton";
            this.byGUIDButton.Size = new System.Drawing.Size(67, 17);
            this.byGUIDButton.TabIndex = 21;
            this.byGUIDButton.Text = "By GUID";
            this.byGUIDButton.UseVisualStyleBackColor = true;
            // 
            // exportCSVButton
            // 
            this.exportCSVButton.Location = new System.Drawing.Point(409, 213);
            this.exportCSVButton.Name = "exportCSVButton";
            this.exportCSVButton.Size = new System.Drawing.Size(138, 23);
            this.exportCSVButton.TabIndex = 25;
            this.exportCSVButton.Text = "Export CSV";
            this.exportCSVButton.UseVisualStyleBackColor = true;
            this.exportCSVButton.Visible = false;
            this.exportCSVButton.Click += new System.EventHandler(this.exportCSVButton_Click);
            // 
            // exportCSVDialog
            // 
            this.exportCSVDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.exportCSVDialog_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 900);
            this.Controls.Add(this.exportCSVButton);
            this.Controls.Add(this.identifierBox);
            this.Controls.Add(this.actionBox);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.collectionBox);
            this.Controls.Add(this.PrepTypeBox);
            this.Controls.Add(this.messageBoxLabel);
            this.Controls.Add(this.CSVDataGrid);
            this.Controls.Add(this.MySQLDBLabel);
            this.Controls.Add(this.MySQLHostLabel);
            this.Controls.Add(this.MySQLUsernameLabel);
            this.Controls.Add(this.MySQLPasswordLabel);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.MySQLDb);
            this.Controls.Add(this.MySQLHost);
            this.Controls.Add(this.MySQLPass);
            this.Controls.Add(this.MySQLUser);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CSVDataGrid)).EndInit();
            this.PrepTypeBox.ResumeLayout(false);
            this.PrepTypeBox.PerformLayout();
            this.collectionBox.ResumeLayout(false);
            this.collectionBox.PerformLayout();
            this.actionBox.ResumeLayout(false);
            this.actionBox.PerformLayout();
            this.identifierBox.ResumeLayout(false);
            this.identifierBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MySQLUser;
        private System.Windows.Forms.TextBox MySQLHost;
        private System.Windows.Forms.TextBox MySQLDb;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Label MySQLPasswordLabel;
        private System.Windows.Forms.Label MySQLUsernameLabel;
        private System.Windows.Forms.Label MySQLHostLabel;
        private System.Windows.Forms.Label MySQLDBLabel;
        private System.Windows.Forms.ComboBox PrepTypeCombobox;
        private System.Windows.Forms.Label PrepTypeLabel;
        private System.Windows.Forms.TextBox MySQLPass;
        private System.Windows.Forms.TextBox SelectedCSVTextBox;
        private System.Windows.Forms.Button SelectCSVButton;
        private System.Windows.Forms.Label CSVFileLabel;
        private System.Windows.Forms.DataGridView CSVDataGrid;
        private System.Windows.Forms.Label messageBoxLabel;
        private System.Windows.Forms.GroupBox PrepTypeBox;
        private System.Windows.Forms.GroupBox collectionBox;
        private System.Windows.Forms.Label collectionLabel;
        private System.Windows.Forms.ComboBox collectionComboBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button addPrepsButton;
        private System.Windows.Forms.RadioButton prepsOnlyRadioButton;
        private System.Windows.Forms.RadioButton importImagesRadioButton;
        private System.Windows.Forms.GroupBox actionBox;
        private System.Windows.Forms.GroupBox identifierBox;
        private System.Windows.Forms.RadioButton byCatNumButton;
        private System.Windows.Forms.RadioButton byGUIDButton;
        private System.Windows.Forms.Button exportCSVButton;
        private System.Windows.Forms.SaveFileDialog exportCSVDialog;
    }
}

