namespace isozCoder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSqlServer = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkIDKey = new System.Windows.Forms.CheckBox();
            this.gList = new GlacialComponents.Controls.GlacialList();
            this.cmbDatabases = new System.Windows.Forms.ComboBox();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tabCode = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtDalTemplate = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtBLLTemplate = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtspTemplate = new System.Windows.Forms.TextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.txtBLLFilePath = new System.Windows.Forms.TextBox();
            this.txtDALCode = new System.Windows.Forms.TextBox();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.txtDALFilePath = new System.Windows.Forms.TextBox();
            this.txtBLLCode = new System.Windows.Forms.TextBox();
            this.Sql = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.txtspCode = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabCode.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.Sql.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSqlServer);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SQL Server";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(253, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(186, 32);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(61, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Text = "as";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "UserName";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(123, 32);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(61, 20);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.Text = "sa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "SQL Server Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            // 
            // txtSqlServer
            // 
            this.txtSqlServer.Location = new System.Drawing.Point(9, 32);
            this.txtSqlServer.Name = "txtSqlServer";
            this.txtSqlServer.Size = new System.Drawing.Size(109, 20);
            this.txtSqlServer.TabIndex = 0;
            this.txtSqlServer.Text = "ISMAIL-PC";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.chkIDKey);
            this.groupBox2.Controls.Add(this.gList);
            this.groupBox2.Controls.Add(this.cmbDatabases);
            this.groupBox2.Controls.Add(this.cmbTables);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(3, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 543);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Databases & Tables";
            // 
            // chkIDKey
            // 
            this.chkIDKey.AutoSize = true;
            this.chkIDKey.Location = new System.Drawing.Point(7, 498);
            this.chkIDKey.Name = "chkIDKey";
            this.chkIDKey.Size = new System.Drawing.Size(235, 17);
            this.chkIDKey.TabIndex = 9;
            this.chkIDKey.Text = "Use PrimaryKey fields instead of Identiy Field";
            this.chkIDKey.UseVisualStyleBackColor = true;
            // 
            // gList
            // 
            this.gList.AllowColumnResize = true;
            this.gList.AllowMultiselect = false;
            this.gList.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.gList.AlternatingColors = false;
            this.gList.AutoHeight = true;
            this.gList.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gList.BackgroundStretchToFit = true;
            this.gList.ControlStyle = GlacialComponents.Controls.GLControlStyles.Normal;
            this.gList.FullRowSelect = true;
            this.gList.GridColor = System.Drawing.Color.LightGray;
            this.gList.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.gList.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.gList.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.gList.HeaderHeight = 22;
            this.gList.HeaderVisible = true;
            this.gList.HeaderWordWrap = false;
            this.gList.HotColumnTracking = false;
            this.gList.HotItemTracking = false;
            this.gList.HotTrackingColor = System.Drawing.Color.LightGray;
            this.gList.HoverEvents = false;
            this.gList.HoverTime = 1;
            this.gList.ImageList = null;
            this.gList.ItemHeight = 18;
            this.gList.ItemWordWrap = false;
            this.gList.Location = new System.Drawing.Point(6, 95);
            this.gList.Name = "gList";
            this.gList.Selectable = true;
            this.gList.SelectedTextColor = System.Drawing.Color.White;
            this.gList.SelectionColor = System.Drawing.Color.DarkBlue;
            this.gList.ShowBorder = true;
            this.gList.ShowFocusRect = false;
            this.gList.Size = new System.Drawing.Size(381, 402);
            this.gList.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.gList.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.gList.TabIndex = 8;
            this.gList.Text = "glacialList1";
            // 
            // cmbDatabases
            // 
            this.cmbDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatabases.FormattingEnabled = true;
            this.cmbDatabases.Location = new System.Drawing.Point(64, 21);
            this.cmbDatabases.Name = "cmbDatabases";
            this.cmbDatabases.Size = new System.Drawing.Size(261, 21);
            this.cmbDatabases.TabIndex = 0;
            this.cmbDatabases.SelectedIndexChanged += new System.EventHandler(this.cmbDatabases_SelectedIndexChanged);
            // 
            // cmbTables
            // 
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(64, 48);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(261, 21);
            this.cmbTables.TabIndex = 3;
            this.cmbTables.SelectedIndexChanged += new System.EventHandler(this.cmbTables_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(6, 516);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(381, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Generate Code";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Databases";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tables";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Table Fields";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(9, 393);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Select Fields";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // tabCode
            // 
            this.tabCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCode.Controls.Add(this.tabPage1);
            this.tabCode.Controls.Add(this.tabPage2);
            this.tabCode.Controls.Add(this.tabPage3);
            this.tabCode.Location = new System.Drawing.Point(6, 6);
            this.tabCode.Name = "tabCode";
            this.tabCode.SelectedIndex = 0;
            this.tabCode.Size = new System.Drawing.Size(871, 567);
            this.tabCode.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage1.Controls.Add(this.txtDalTemplate);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(863, 541);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DAL Template";
            // 
            // txtDalTemplate
            // 
            this.txtDalTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDalTemplate.Location = new System.Drawing.Point(6, 3);
            this.txtDalTemplate.Multiline = true;
            this.txtDalTemplate.Name = "txtDalTemplate";
            this.txtDalTemplate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDalTemplate.Size = new System.Drawing.Size(851, 529);
            this.txtDalTemplate.TabIndex = 0;
            this.txtDalTemplate.Text = resources.GetString("txtDalTemplate.Text");
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage2.Controls.Add(this.txtBLLTemplate);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(863, 541);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "BLL Template";
            // 
            // txtBLLTemplate
            // 
            this.txtBLLTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBLLTemplate.Location = new System.Drawing.Point(6, 6);
            this.txtBLLTemplate.Multiline = true;
            this.txtBLLTemplate.Name = "txtBLLTemplate";
            this.txtBLLTemplate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBLLTemplate.Size = new System.Drawing.Size(851, 529);
            this.txtBLLTemplate.TabIndex = 1;
            this.txtBLLTemplate.Text = resources.GetString("txtBLLTemplate.Text");
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtspTemplate);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(863, 541);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "SqlServer SP Template";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtspTemplate
            // 
            this.txtspTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtspTemplate.Location = new System.Drawing.Point(6, 6);
            this.txtspTemplate.Multiline = true;
            this.txtspTemplate.Name = "txtspTemplate";
            this.txtspTemplate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtspTemplate.Size = new System.Drawing.Size(851, 529);
            this.txtspTemplate.TabIndex = 2;
            this.txtspTemplate.Text = resources.GetString("txtspTemplate.Text");
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabPage5);
            this.tabMain.Controls.Add(this.tabPage6);
            this.tabMain.Location = new System.Drawing.Point(409, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(891, 609);
            this.tabMain.TabIndex = 3;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tabCode);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(883, 583);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Template";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.tabControl2);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(883, 583);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Code";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage9);
            this.tabControl2.Controls.Add(this.tabPage10);
            this.tabControl2.Controls.Add(this.Sql);
            this.tabControl2.Location = new System.Drawing.Point(6, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(757, 579);
            this.tabControl2.TabIndex = 3;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.Color.ForestGreen;
            this.tabPage9.Controls.Add(this.button4);
            this.tabPage9.Controls.Add(this.txtBLLFilePath);
            this.tabPage9.Controls.Add(this.txtDALCode);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(749, 553);
            this.tabPage9.TabIndex = 2;
            this.tabPage9.Text = "DAL #.cs";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.BackColor = System.Drawing.Color.Moccasin;
            this.button4.Location = new System.Drawing.Point(322, 528);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtBLLFilePath
            // 
            this.txtBLLFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBLLFilePath.Location = new System.Drawing.Point(6, 528);
            this.txtBLLFilePath.Name = "txtBLLFilePath";
            this.txtBLLFilePath.Size = new System.Drawing.Size(310, 20);
            this.txtBLLFilePath.TabIndex = 3;
            this.txtBLLFilePath.Text = "D:\\GoogleDrive\\electronline\\App_Code\\DAL";
            // 
            // txtDALCode
            // 
            this.txtDALCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDALCode.Location = new System.Drawing.Point(6, 6);
            this.txtDALCode.Multiline = true;
            this.txtDALCode.Name = "txtDALCode";
            this.txtDALCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDALCode.Size = new System.Drawing.Size(737, 518);
            this.txtDALCode.TabIndex = 1;
            // 
            // tabPage10
            // 
            this.tabPage10.BackColor = System.Drawing.Color.ForestGreen;
            this.tabPage10.Controls.Add(this.button5);
            this.tabPage10.Controls.Add(this.txtDALFilePath);
            this.tabPage10.Controls.Add(this.txtBLLCode);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(749, 553);
            this.tabPage10.TabIndex = 3;
            this.tabPage10.Text = "BLL #.cs";
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.BackColor = System.Drawing.Color.Moccasin;
            this.button5.Location = new System.Drawing.Point(322, 529);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Save";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtDALFilePath
            // 
            this.txtDALFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDALFilePath.Location = new System.Drawing.Point(6, 530);
            this.txtDALFilePath.Name = "txtDALFilePath";
            this.txtDALFilePath.Size = new System.Drawing.Size(310, 20);
            this.txtDALFilePath.TabIndex = 5;
            this.txtDALFilePath.Text = "D:\\GoogleDrive\\electronline\\App_Code\\BLL";
            // 
            // txtBLLCode
            // 
            this.txtBLLCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBLLCode.Location = new System.Drawing.Point(6, 6);
            this.txtBLLCode.Multiline = true;
            this.txtBLLCode.Name = "txtBLLCode";
            this.txtBLLCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBLLCode.Size = new System.Drawing.Size(737, 518);
            this.txtBLLCode.TabIndex = 1;
            // 
            // Sql
            // 
            this.Sql.Controls.Add(this.button6);
            this.Sql.Controls.Add(this.txtspCode);
            this.Sql.Location = new System.Drawing.Point(4, 22);
            this.Sql.Name = "Sql";
            this.Sql.Padding = new System.Windows.Forms.Padding(3);
            this.Sql.Size = new System.Drawing.Size(749, 553);
            this.Sql.TabIndex = 4;
            this.Sql.Text = "SqlServer SP Script";
            this.Sql.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.Location = new System.Drawing.Point(6, 530);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(199, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "Execute";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // txtspCode
            // 
            this.txtspCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtspCode.Location = new System.Drawing.Point(6, 6);
            this.txtspCode.Multiline = true;
            this.txtspCode.Name = "txtspCode";
            this.txtspCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtspCode.Size = new System.Drawing.Size(737, 518);
            this.txtspCode.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 626);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabCode.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            this.Sql.ResumeLayout(false);
            this.Sql.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSqlServer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDatabases;
        private System.Windows.Forms.TabControl tabCode;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtDalTemplate;
        private System.Windows.Forms.TextBox txtBLLTemplate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TextBox txtDALCode;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TextBox txtBLLCode;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtspTemplate;
        private System.Windows.Forms.TabPage Sql;
        private System.Windows.Forms.TextBox txtspCode;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtBLLFilePath;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtDALFilePath;
        private System.Windows.Forms.Button button6;
        private GlacialComponents.Controls.GlacialList gList;
        private System.Windows.Forms.CheckBox chkIDKey;
    }
}

