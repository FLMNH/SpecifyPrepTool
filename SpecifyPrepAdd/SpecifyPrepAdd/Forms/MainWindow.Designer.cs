namespace SpecifyPrepAdd
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.exportCSVDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readmeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelCollection = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDatabase = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblHelpText1 = new System.Windows.Forms.Label();
            this.PrepTypeBox = new System.Windows.Forms.GroupBox();
            this.addPrepsButton = new System.Windows.Forms.Button();
            this.SelectedCSVTextBox = new System.Windows.Forms.TextBox();
            this.SelectCSVButton = new System.Windows.Forms.Button();
            this.CSVFileLabel = new System.Windows.Forms.Label();
            this.PrepTypeLabel = new System.Windows.Forms.Label();
            this.PrepTypeCombobox = new System.Windows.Forms.ComboBox();
            this.messageBoxLabel = new System.Windows.Forms.Label();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.exportCSVButton = new System.Windows.Forms.Button();
            this.identifierBox = new System.Windows.Forms.GroupBox();
            this.byCatNumButton = new System.Windows.Forms.RadioButton();
            this.byGUIDButton = new System.Windows.Forms.RadioButton();
            this.actionBox = new System.Windows.Forms.GroupBox();
            this.externalRadioButton = new System.Windows.Forms.RadioButton();
            this.prepsOnlyRadioButton = new System.Windows.Forms.RadioButton();
            this.externalColumnBox = new System.Windows.Forms.GroupBox();
            this.spreadsheetExternalLocationLabel = new System.Windows.Forms.Label();
            this.spreadsheetExternalColumnComboBox = new System.Windows.Forms.ComboBox();
            this.externalBoolLabel = new System.Windows.Forms.Label();
            this.externalBoolComboBox = new System.Windows.Forms.ComboBox();
            this.externalTableLabel = new System.Windows.Forms.Label();
            this.externalTableComboBox = new System.Windows.Forms.ComboBox();
            this.externalColumnLabel = new System.Windows.Forms.Label();
            this.externalColumnComboBox = new System.Windows.Forms.ComboBox();
            this.CSVDataGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.PrepTypeBox.SuspendLayout();
            this.identifierBox.SuspendLayout();
            this.actionBox.SuspendLayout();
            this.externalColumnBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CSVDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // exportCSVDialog
            // 
            this.exportCSVDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.exportCSVDialog_FileOk);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.HelpMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1223, 24);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // HelpMenu
            // 
            this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.readmeToolStripMenuItem});
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(44, 20);
            this.HelpMenu.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // readmeToolStripMenuItem
            // 
            this.readmeToolStripMenuItem.Name = "readmeToolStripMenuItem";
            this.readmeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.readmeToolStripMenuItem.Text = "Readme";
            this.readmeToolStripMenuItem.Click += new System.EventHandler(this.HelpMenu_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusSpacer,
            this.toolStripStatusLabelUserName,
            this.toolStripStatusLabelCollection,
            this.toolStripStatusLabelDatabase,
            this.toolStripStatusLabelServer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 998);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1223, 24);
            this.statusStrip1.TabIndex = 30;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusSpacer
            // 
            this.toolStripStatusSpacer.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusSpacer.Name = "toolStripStatusSpacer";
            this.toolStripStatusSpacer.Size = new System.Drawing.Size(977, 19);
            this.toolStripStatusSpacer.Spring = true;
            // 
            // toolStripStatusLabelUserName
            // 
            this.toolStripStatusLabelUserName.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelUserName.Name = "toolStripStatusLabelUserName";
            this.toolStripStatusLabelUserName.Size = new System.Drawing.Size(64, 19);
            this.toolStripStatusLabelUserName.Text = "Username";
            // 
            // toolStripStatusLabelCollection
            // 
            this.toolStripStatusLabelCollection.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelCollection.Name = "toolStripStatusLabelCollection";
            this.toolStripStatusLabelCollection.Size = new System.Drawing.Size(65, 19);
            this.toolStripStatusLabelCollection.Text = "Collection";
            // 
            // toolStripStatusLabelDatabase
            // 
            this.toolStripStatusLabelDatabase.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelDatabase.Name = "toolStripStatusLabelDatabase";
            this.toolStripStatusLabelDatabase.Size = new System.Drawing.Size(59, 19);
            this.toolStripStatusLabelDatabase.Text = "Database";
            // 
            // toolStripStatusLabelServer
            // 
            this.toolStripStatusLabelServer.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelServer.Name = "toolStripStatusLabelServer";
            this.toolStripStatusLabelServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabelServer.Size = new System.Drawing.Size(43, 19);
            this.toolStripStatusLabelServer.Text = "Server";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblHelpText1);
            this.splitContainer1.Panel1.Controls.Add(this.PrepTypeBox);
            this.splitContainer1.Panel1.Controls.Add(this.messageBoxLabel);
            this.splitContainer1.Panel1.Controls.Add(this.messageBox);
            this.splitContainer1.Panel1.Controls.Add(this.exportCSVButton);
            this.splitContainer1.Panel1.Controls.Add(this.identifierBox);
            this.splitContainer1.Panel1.Controls.Add(this.actionBox);
            this.splitContainer1.Panel1.Controls.Add(this.externalColumnBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.CSVDataGrid);
            this.splitContainer1.Size = new System.Drawing.Size(1223, 974);
            this.splitContainer1.SplitterDistance = 355;
            this.splitContainer1.TabIndex = 31;
            // 
            // lblHelpText1
            // 
            this.lblHelpText1.AutoSize = true;
            this.lblHelpText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelpText1.Location = new System.Drawing.Point(564, 232);
            this.lblHelpText1.MaximumSize = new System.Drawing.Size(600, 500);
            this.lblHelpText1.Name = "lblHelpText1";
            this.lblHelpText1.Size = new System.Drawing.Size(597, 48);
            this.lblHelpText1.TabIndex = 34;
            this.lblHelpText1.Text = resources.GetString("lblHelpText1.Text");
            this.lblHelpText1.Visible = false;
            // 
            // PrepTypeBox
            // 
            this.PrepTypeBox.Controls.Add(this.addPrepsButton);
            this.PrepTypeBox.Controls.Add(this.SelectedCSVTextBox);
            this.PrepTypeBox.Controls.Add(this.SelectCSVButton);
            this.PrepTypeBox.Controls.Add(this.CSVFileLabel);
            this.PrepTypeBox.Controls.Add(this.PrepTypeLabel);
            this.PrepTypeBox.Controls.Add(this.PrepTypeCombobox);
            this.PrepTypeBox.Location = new System.Drawing.Point(24, 11);
            this.PrepTypeBox.Name = "PrepTypeBox";
            this.PrepTypeBox.Size = new System.Drawing.Size(534, 112);
            this.PrepTypeBox.TabIndex = 33;
            this.PrepTypeBox.TabStop = false;
            // 
            // addPrepsButton
            // 
            this.addPrepsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPrepsButton.Location = new System.Drawing.Point(362, 66);
            this.addPrepsButton.Name = "addPrepsButton";
            this.addPrepsButton.Size = new System.Drawing.Size(144, 23);
            this.addPrepsButton.TabIndex = 15;
            this.addPrepsButton.Text = "Add Preps";
            this.addPrepsButton.UseVisualStyleBackColor = true;
            this.addPrepsButton.Click += new System.EventHandler(this.addPrepsButton_Click);
            // 
            // SelectedCSVTextBox
            // 
            this.SelectedCSVTextBox.Location = new System.Drawing.Point(6, 29);
            this.SelectedCSVTextBox.Name = "SelectedCSVTextBox";
            this.SelectedCSVTextBox.Size = new System.Drawing.Size(350, 20);
            this.SelectedCSVTextBox.TabIndex = 12;
            this.SelectedCSVTextBox.Click += new System.EventHandler(this.SelectedCSVTextBox_Click);
            // 
            // SelectCSVButton
            // 
            this.SelectCSVButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectCSVButton.Location = new System.Drawing.Point(362, 29);
            this.SelectCSVButton.Name = "SelectCSVButton";
            this.SelectCSVButton.Size = new System.Drawing.Size(144, 23);
            this.SelectCSVButton.TabIndex = 13;
            this.SelectCSVButton.Text = "Select XLS File";
            this.SelectCSVButton.UseVisualStyleBackColor = true;
            this.SelectCSVButton.Click += new System.EventHandler(this.SelectCSVButton_Click);
            // 
            // CSVFileLabel
            // 
            this.CSVFileLabel.AutoSize = true;
            this.CSVFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CSVFileLabel.Location = new System.Drawing.Point(6, 8);
            this.CSVFileLabel.Name = "CSVFileLabel";
            this.CSVFileLabel.Size = new System.Drawing.Size(133, 16);
            this.CSVFileLabel.TabIndex = 14;
            this.CSVFileLabel.Text = "Spreadsheet Upload";
            // 
            // PrepTypeLabel
            // 
            this.PrepTypeLabel.AutoSize = true;
            this.PrepTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrepTypeLabel.Location = new System.Drawing.Point(6, 52);
            this.PrepTypeLabel.Name = "PrepTypeLabel";
            this.PrepTypeLabel.Size = new System.Drawing.Size(71, 16);
            this.PrepTypeLabel.TabIndex = 10;
            this.PrepTypeLabel.Text = "Prep Type";
            // 
            // PrepTypeCombobox
            // 
            this.PrepTypeCombobox.FormattingEnabled = true;
            this.PrepTypeCombobox.Location = new System.Drawing.Point(6, 68);
            this.PrepTypeCombobox.Name = "PrepTypeCombobox";
            this.PrepTypeCombobox.Size = new System.Drawing.Size(350, 21);
            this.PrepTypeCombobox.TabIndex = 9;
            // 
            // messageBoxLabel
            // 
            this.messageBoxLabel.AutoSize = true;
            this.messageBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBoxLabel.Location = new System.Drawing.Point(622, 11);
            this.messageBoxLabel.Name = "messageBoxLabel";
            this.messageBoxLabel.Size = new System.Drawing.Size(71, 16);
            this.messageBoxLabel.TabIndex = 32;
            this.messageBoxLabel.Text = "Messages";
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(625, 37);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageBox.Size = new System.Drawing.Size(586, 166);
            this.messageBox.TabIndex = 31;
            // 
            // exportCSVButton
            // 
            this.exportCSVButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportCSVButton.Location = new System.Drawing.Point(350, 139);
            this.exportCSVButton.Name = "exportCSVButton";
            this.exportCSVButton.Size = new System.Drawing.Size(138, 23);
            this.exportCSVButton.TabIndex = 30;
            this.exportCSVButton.Text = "Export CSV";
            this.exportCSVButton.UseVisualStyleBackColor = true;
            this.exportCSVButton.Click += new System.EventHandler(this.exportCSVButton_Click);
            // 
            // identifierBox
            // 
            this.identifierBox.Controls.Add(this.byCatNumButton);
            this.identifierBox.Controls.Add(this.byGUIDButton);
            this.identifierBox.Location = new System.Drawing.Point(24, 129);
            this.identifierBox.Name = "identifierBox";
            this.identifierBox.Size = new System.Drawing.Size(281, 41);
            this.identifierBox.TabIndex = 29;
            this.identifierBox.TabStop = false;
            // 
            // byCatNumButton
            // 
            this.byCatNumButton.AutoSize = true;
            this.byCatNumButton.Checked = true;
            this.byCatNumButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.byCatNumButton.Location = new System.Drawing.Point(6, 16);
            this.byCatNumButton.Name = "byCatNumButton";
            this.byCatNumButton.Size = new System.Drawing.Size(142, 20);
            this.byCatNumButton.TabIndex = 22;
            this.byCatNumButton.TabStop = true;
            this.byCatNumButton.Text = "By Catalog Number";
            this.byCatNumButton.UseVisualStyleBackColor = true;
            // 
            // byGUIDButton
            // 
            this.byGUIDButton.AutoSize = true;
            this.byGUIDButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.byGUIDButton.Location = new System.Drawing.Point(170, 16);
            this.byGUIDButton.Name = "byGUIDButton";
            this.byGUIDButton.Size = new System.Drawing.Size(77, 20);
            this.byGUIDButton.TabIndex = 21;
            this.byGUIDButton.Text = "By GUID";
            this.byGUIDButton.UseVisualStyleBackColor = true;
            // 
            // actionBox
            // 
            this.actionBox.Controls.Add(this.externalRadioButton);
            this.actionBox.Controls.Add(this.prepsOnlyRadioButton);
            this.actionBox.Location = new System.Drawing.Point(24, 168);
            this.actionBox.Name = "actionBox";
            this.actionBox.Size = new System.Drawing.Size(383, 41);
            this.actionBox.TabIndex = 28;
            this.actionBox.TabStop = false;
            // 
            // externalRadioButton
            // 
            this.externalRadioButton.AutoSize = true;
            this.externalRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.externalRadioButton.Location = new System.Drawing.Point(146, 15);
            this.externalRadioButton.Name = "externalRadioButton";
            this.externalRadioButton.Size = new System.Drawing.Size(205, 20);
            this.externalRadioButton.TabIndex = 22;
            this.externalRadioButton.Text = "Also Populate Additional Field";
            this.externalRadioButton.UseVisualStyleBackColor = true;
            this.externalRadioButton.CheckedChanged += new System.EventHandler(this.externalRadioButton_CheckedChanged_1);
            // 
            // prepsOnlyRadioButton
            // 
            this.prepsOnlyRadioButton.AutoSize = true;
            this.prepsOnlyRadioButton.Checked = true;
            this.prepsOnlyRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prepsOnlyRadioButton.Location = new System.Drawing.Point(6, 15);
            this.prepsOnlyRadioButton.Name = "prepsOnlyRadioButton";
            this.prepsOnlyRadioButton.Size = new System.Drawing.Size(134, 20);
            this.prepsOnlyRadioButton.TabIndex = 21;
            this.prepsOnlyRadioButton.TabStop = true;
            this.prepsOnlyRadioButton.Text = "Create Preps Only";
            this.prepsOnlyRadioButton.UseVisualStyleBackColor = true;
            // 
            // externalColumnBox
            // 
            this.externalColumnBox.Controls.Add(this.spreadsheetExternalLocationLabel);
            this.externalColumnBox.Controls.Add(this.spreadsheetExternalColumnComboBox);
            this.externalColumnBox.Controls.Add(this.externalBoolLabel);
            this.externalColumnBox.Controls.Add(this.externalBoolComboBox);
            this.externalColumnBox.Controls.Add(this.externalTableLabel);
            this.externalColumnBox.Controls.Add(this.externalTableComboBox);
            this.externalColumnBox.Controls.Add(this.externalColumnLabel);
            this.externalColumnBox.Controls.Add(this.externalColumnComboBox);
            this.externalColumnBox.Location = new System.Drawing.Point(24, 215);
            this.externalColumnBox.Name = "externalColumnBox";
            this.externalColumnBox.Size = new System.Drawing.Size(534, 113);
            this.externalColumnBox.TabIndex = 27;
            this.externalColumnBox.TabStop = false;
            this.externalColumnBox.Visible = false;
            // 
            // spreadsheetExternalLocationLabel
            // 
            this.spreadsheetExternalLocationLabel.AutoSize = true;
            this.spreadsheetExternalLocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spreadsheetExternalLocationLabel.Location = new System.Drawing.Point(6, 64);
            this.spreadsheetExternalLocationLabel.Name = "spreadsheetExternalLocationLabel";
            this.spreadsheetExternalLocationLabel.Size = new System.Drawing.Size(229, 16);
            this.spreadsheetExternalLocationLabel.TabIndex = 7;
            this.spreadsheetExternalLocationLabel.Text = "Spreadsheet Additional Field Column";
            // 
            // spreadsheetExternalColumnComboBox
            // 
            this.spreadsheetExternalColumnComboBox.FormattingEnabled = true;
            this.spreadsheetExternalColumnComboBox.Location = new System.Drawing.Point(6, 83);
            this.spreadsheetExternalColumnComboBox.Name = "spreadsheetExternalColumnComboBox";
            this.spreadsheetExternalColumnComboBox.Size = new System.Drawing.Size(319, 21);
            this.spreadsheetExternalColumnComboBox.TabIndex = 6;
            // 
            // externalBoolLabel
            // 
            this.externalBoolLabel.AutoSize = true;
            this.externalBoolLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.externalBoolLabel.Location = new System.Drawing.Point(383, 15);
            this.externalBoolLabel.Name = "externalBoolLabel";
            this.externalBoolLabel.Size = new System.Drawing.Size(120, 16);
            this.externalBoolLabel.TabIndex = 5;
            this.externalBoolLabel.Text = "CDN External Field";
            // 
            // externalBoolComboBox
            // 
            this.externalBoolComboBox.FormattingEnabled = true;
            this.externalBoolComboBox.Location = new System.Drawing.Point(379, 35);
            this.externalBoolComboBox.Name = "externalBoolComboBox";
            this.externalBoolComboBox.Size = new System.Drawing.Size(130, 21);
            this.externalBoolComboBox.TabIndex = 4;
            // 
            // externalTableLabel
            // 
            this.externalTableLabel.AutoSize = true;
            this.externalTableLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.externalTableLabel.Location = new System.Drawing.Point(9, 16);
            this.externalTableLabel.Name = "externalTableLabel";
            this.externalTableLabel.Size = new System.Drawing.Size(139, 16);
            this.externalTableLabel.TabIndex = 3;
            this.externalTableLabel.Text = "Additional Field Table";
            // 
            // externalTableComboBox
            // 
            this.externalTableComboBox.FormattingEnabled = true;
            this.externalTableComboBox.Location = new System.Drawing.Point(9, 35);
            this.externalTableComboBox.Name = "externalTableComboBox";
            this.externalTableComboBox.Size = new System.Drawing.Size(217, 21);
            this.externalTableComboBox.TabIndex = 2;
            this.externalTableComboBox.SelectionChangeCommitted += new System.EventHandler(this.externalTableComboBox_SelectionChangeCommitted);
            // 
            // externalColumnLabel
            // 
            this.externalColumnLabel.AutoSize = true;
            this.externalColumnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.externalColumnLabel.Location = new System.Drawing.Point(232, 16);
            this.externalColumnLabel.Name = "externalColumnLabel";
            this.externalColumnLabel.Size = new System.Drawing.Size(100, 16);
            this.externalColumnLabel.TabIndex = 1;
            this.externalColumnLabel.Text = "Additional Field";
            // 
            // externalColumnComboBox
            // 
            this.externalColumnComboBox.FormattingEnabled = true;
            this.externalColumnComboBox.Location = new System.Drawing.Point(232, 35);
            this.externalColumnComboBox.Name = "externalColumnComboBox";
            this.externalColumnComboBox.Size = new System.Drawing.Size(130, 21);
            this.externalColumnComboBox.TabIndex = 0;
            // 
            // CSVDataGrid
            // 
            this.CSVDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CSVDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CSVDataGrid.Location = new System.Drawing.Point(0, 0);
            this.CSVDataGrid.Name = "CSVDataGrid";
            this.CSVDataGrid.ReadOnly = true;
            this.CSVDataGrid.Size = new System.Drawing.Size(1223, 615);
            this.CSVDataGrid.TabIndex = 16;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1223, 1022);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Specify Prep Adder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.PrepTypeBox.ResumeLayout(false);
            this.PrepTypeBox.PerformLayout();
            this.identifierBox.ResumeLayout(false);
            this.identifierBox.PerformLayout();
            this.actionBox.ResumeLayout(false);
            this.actionBox.PerformLayout();
            this.externalColumnBox.ResumeLayout(false);
            this.externalColumnBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CSVDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog exportCSVDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem HelpMenu;
        private System.Windows.Forms.ToolStripMenuItem readmeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelServer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSpacer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUserName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCollection;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDatabase;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox PrepTypeBox;
        private System.Windows.Forms.Button addPrepsButton;
        private System.Windows.Forms.TextBox SelectedCSVTextBox;
        private System.Windows.Forms.Button SelectCSVButton;
        private System.Windows.Forms.Label CSVFileLabel;
        private System.Windows.Forms.Label PrepTypeLabel;
        private System.Windows.Forms.ComboBox PrepTypeCombobox;
        private System.Windows.Forms.Label messageBoxLabel;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Button exportCSVButton;
        private System.Windows.Forms.GroupBox identifierBox;
        private System.Windows.Forms.RadioButton byCatNumButton;
        private System.Windows.Forms.RadioButton byGUIDButton;
        private System.Windows.Forms.GroupBox actionBox;
        private System.Windows.Forms.RadioButton externalRadioButton;
        private System.Windows.Forms.RadioButton prepsOnlyRadioButton;
        private System.Windows.Forms.GroupBox externalColumnBox;
        private System.Windows.Forms.Label spreadsheetExternalLocationLabel;
        private System.Windows.Forms.ComboBox spreadsheetExternalColumnComboBox;
        private System.Windows.Forms.Label externalBoolLabel;
        private System.Windows.Forms.ComboBox externalBoolComboBox;
        private System.Windows.Forms.Label externalTableLabel;
        private System.Windows.Forms.ComboBox externalTableComboBox;
        private System.Windows.Forms.Label externalColumnLabel;
        private System.Windows.Forms.ComboBox externalColumnComboBox;
        private System.Windows.Forms.DataGridView CSVDataGrid;
        private System.Windows.Forms.Label lblHelpText1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

