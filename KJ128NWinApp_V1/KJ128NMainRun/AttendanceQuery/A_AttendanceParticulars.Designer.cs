namespace KJ128NInterfaceShow
{
    partial class AttendanceParticulars
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendanceParticulars));
            this.lblBeginTime = new System.Windows.Forms.Label();
            this.dtpBeginTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlDept = new System.Windows.Forms.ComboBox();
            this.ddlDuty = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserName = new Shine.ShineTextBox();
            this.txtBlock = new Shine.ShineTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblErr = new System.Windows.Forms.Label();
            this.buttonCaptionPanel3 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.buttonCaptionPanel2 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.buttonCaptionPanel1 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkUnion = new System.Windows.Forms.CheckBox();
            this.grpMessage = new System.Windows.Forms.GroupBox();
            this.radLast = new System.Windows.Forms.RadioButton();
            this.lblTimeLong = new System.Windows.Forms.Label();
            this.radFull = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.numTimeLong = new Shine.ShineTextBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.cboClassName = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dgrd = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.drawerLeftMain.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpMessage.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.BackColor = System.Drawing.SystemColors.Control;
            this.panelLeftBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLeftBottom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.panelLeftBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 0);
            this.panelLeftBottom.Size = new System.Drawing.Size(200, 523);
            // 
            // panelMainBottom
            // 
            this.panelMainBottom.BackColor = System.Drawing.SystemColors.Control;
            // 
            // panelMainTop
            // 
            this.panelMainTop.BackColor = System.Drawing.SystemColors.Control;
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.BackColor = System.Drawing.SystemColors.Control;
            this.drawerLeftMain.Controls.Add(this.pictureBox1);
            this.drawerLeftMain.Controls.Add(this.panel1);
            this.drawerLeftMain.Size = new System.Drawing.Size(200, 523);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(257, 3);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(331, 3);
            // 
            // btnLaws
            // 
            this.btnLaws.Location = new System.Drawing.Point(659, 4);
            this.btnLaws.Text = "导出";
            this.btnLaws.Click += new System.EventHandler(this.btnLaws_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(479, 3);
            // 
            // btnPrint
            // 
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblSumPage
            // 
            this.lblSumPage.Visible = false;
            // 
            // cmbSelectCounts
            // 
            this.cmbSelectCounts.Visible = false;
            this.cmbSelectCounts.SelectedIndexChanged += new System.EventHandler(this.cmbSelectCounts_SelectedIndexChanged);
            this.cmbSelectCounts.DropDownClosed += new System.EventHandler(this.cmbSelectCounts_DropDownClosed);
            // 
            // label8
            // 
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.Visible = false;
            // 
            // txtSkipPage
            // 
            this.txtSkipPage.Visible = false;
            this.txtSkipPage.Leave += new System.EventHandler(this.txtSkipPage_Leave);
            this.txtSkipPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSkipPage_KeyPress);
            this.txtSkipPage.Enter += new System.EventHandler(this.txtSkipPage_Enter);
            // 
            // label6
            // 
            this.label6.Visible = false;
            // 
            // lblPageCounts
            // 
            this.lblPageCounts.Visible = false;
            // 
            // btnDownPage
            // 
            this.btnDownPage.Visible = false;
            this.btnDownPage.Click += new System.EventHandler(this.btnDownPage_Click);
            // 
            // btnUpPage
            // 
            this.btnUpPage.Visible = false;
            this.btnUpPage.Click += new System.EventHandler(this.btnUpPage_Click);
            // 
            // label9
            // 
            this.label9.Visible = false;
            // 
            // panelMainMain
            // 
            this.panelMainMain.BackColor = System.Drawing.SystemColors.Control;
            this.panelMainMain.Controls.Add(this.pictureBox2);
            this.panelMainMain.Controls.Add(this.dgrd);
            // 
            // btnConfigModel
            // 
            this.btnConfigModel.Click += new System.EventHandler(this.btnConfigModel_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // lblBeginTime
            // 
            this.lblBeginTime.AutoSize = true;
            this.lblBeginTime.Location = new System.Drawing.Point(11, 34);
            this.lblBeginTime.Name = "lblBeginTime";
            this.lblBeginTime.Size = new System.Drawing.Size(65, 12);
            this.lblBeginTime.TabIndex = 3;
            this.lblBeginTime.Text = "开始时间：";
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.CustomFormat = "yyyy-MM-dd";
            this.dtpBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBeginTime.Location = new System.Drawing.Point(88, 30);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.Size = new System.Drawing.Size(91, 21);
            this.dtpBeginTime.TabIndex = 4;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(88, 60);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(91, 21);
            this.dtpEndTime.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "结束时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "部    门：";
            // 
            // ddlDept
            // 
            this.ddlDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDept.FormattingEnabled = true;
            this.ddlDept.Location = new System.Drawing.Point(88, 91);
            this.ddlDept.Name = "ddlDept";
            this.ddlDept.Size = new System.Drawing.Size(91, 20);
            this.ddlDept.TabIndex = 8;
            // 
            // ddlDuty
            // 
            this.ddlDuty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDuty.FormattingEnabled = true;
            this.ddlDuty.Location = new System.Drawing.Point(88, 121);
            this.ddlDuty.Name = "ddlDuty";
            this.ddlDuty.Size = new System.Drawing.Size(91, 20);
            this.ddlDuty.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "职    务：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "姓    名：";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(88, 150);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(91, 21);
            this.txtUserName.TabIndex = 12;
            this.txtUserName.TextType = Shine.TextType.WithOutChar;
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            // 
            // txtBlock
            // 
            this.txtBlock.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtBlock.Location = new System.Drawing.Point(88, 180);
            this.txtBlock.MaxLength = 11;
            this.txtBlock.Name = "txtBlock";
            this.txtBlock.Size = new System.Drawing.Size(91, 21);
            this.txtBlock.TabIndex = 14;
            this.txtBlock.TextType = Shine.TextType.Number;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "卡    号：";
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.Location = new System.Drawing.Point(462, 708);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(0, 12);
            this.lblErr.TabIndex = 27;
            // 
            // buttonCaptionPanel3
            // 
            this.buttonCaptionPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCaptionPanel3.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.buttonCaptionPanel3.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel3.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.buttonCaptionPanel3.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel3.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.buttonCaptionPanel3.CaptionBottomLineWidth = 1;
            this.buttonCaptionPanel3.CaptionCloseButtonControlLeft = 2;
            this.buttonCaptionPanel3.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCaptionPanel3.CaptionCloseButtonTitle = "×";
            this.buttonCaptionPanel3.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCaptionPanel3.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonCaptionPanel3.CaptionHeight = 20;
            this.buttonCaptionPanel3.CaptionLeft = 1;
            this.buttonCaptionPanel3.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.buttonCaptionPanel3.CaptionTitle = "Title";
            this.buttonCaptionPanel3.CaptionTitleLeft = 8;
            this.buttonCaptionPanel3.CaptionTitleTop = 4;
            this.buttonCaptionPanel3.CaptionTop = 1;
            this.buttonCaptionPanel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCaptionPanel3.IsBorderLine = true;
            this.buttonCaptionPanel3.IsCaptionSingleColor = false;
            this.buttonCaptionPanel3.IsOnlyCaption = true;
            this.buttonCaptionPanel3.IsPanelImage = true;
            this.buttonCaptionPanel3.IsUserButtonClose = false;
            this.buttonCaptionPanel3.IsUserCaptionBottomLine = false;
            this.buttonCaptionPanel3.IsUserSystemCloseButtonLeft = true;
            this.buttonCaptionPanel3.Location = new System.Drawing.Point(486, -129);
            this.buttonCaptionPanel3.Name = "buttonCaptionPanel3";
            this.buttonCaptionPanel3.PanelImage = null;
            this.buttonCaptionPanel3.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.WindowsStyle;
            this.buttonCaptionPanel3.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.buttonCaptionPanel3.Size = new System.Drawing.Size(150, 22);
            this.buttonCaptionPanel3.TabIndex = 20;
            this.buttonCaptionPanel3.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // buttonCaptionPanel2
            // 
            this.buttonCaptionPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCaptionPanel2.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.buttonCaptionPanel2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel2.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.buttonCaptionPanel2.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel2.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.buttonCaptionPanel2.CaptionBottomLineWidth = 1;
            this.buttonCaptionPanel2.CaptionCloseButtonControlLeft = 2;
            this.buttonCaptionPanel2.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCaptionPanel2.CaptionCloseButtonTitle = "×";
            this.buttonCaptionPanel2.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCaptionPanel2.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonCaptionPanel2.CaptionHeight = 20;
            this.buttonCaptionPanel2.CaptionLeft = 1;
            this.buttonCaptionPanel2.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.buttonCaptionPanel2.CaptionTitle = "Title";
            this.buttonCaptionPanel2.CaptionTitleLeft = 8;
            this.buttonCaptionPanel2.CaptionTitleTop = 4;
            this.buttonCaptionPanel2.CaptionTop = 1;
            this.buttonCaptionPanel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCaptionPanel2.IsBorderLine = true;
            this.buttonCaptionPanel2.IsCaptionSingleColor = false;
            this.buttonCaptionPanel2.IsOnlyCaption = true;
            this.buttonCaptionPanel2.IsPanelImage = true;
            this.buttonCaptionPanel2.IsUserButtonClose = false;
            this.buttonCaptionPanel2.IsUserCaptionBottomLine = false;
            this.buttonCaptionPanel2.IsUserSystemCloseButtonLeft = true;
            this.buttonCaptionPanel2.Location = new System.Drawing.Point(412, -129);
            this.buttonCaptionPanel2.Name = "buttonCaptionPanel2";
            this.buttonCaptionPanel2.PanelImage = null;
            this.buttonCaptionPanel2.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.WindowsStyle;
            this.buttonCaptionPanel2.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.buttonCaptionPanel2.Size = new System.Drawing.Size(150, 22);
            this.buttonCaptionPanel2.TabIndex = 19;
            this.buttonCaptionPanel2.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // buttonCaptionPanel1
            // 
            this.buttonCaptionPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCaptionPanel1.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.buttonCaptionPanel1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel1.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.buttonCaptionPanel1.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel1.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.buttonCaptionPanel1.CaptionBottomLineWidth = 1;
            this.buttonCaptionPanel1.CaptionCloseButtonControlLeft = 2;
            this.buttonCaptionPanel1.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCaptionPanel1.CaptionCloseButtonTitle = "×";
            this.buttonCaptionPanel1.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCaptionPanel1.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonCaptionPanel1.CaptionHeight = 20;
            this.buttonCaptionPanel1.CaptionLeft = 1;
            this.buttonCaptionPanel1.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.buttonCaptionPanel1.CaptionTitle = "Title";
            this.buttonCaptionPanel1.CaptionTitleLeft = 8;
            this.buttonCaptionPanel1.CaptionTitleTop = 4;
            this.buttonCaptionPanel1.CaptionTop = 1;
            this.buttonCaptionPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCaptionPanel1.IsBorderLine = true;
            this.buttonCaptionPanel1.IsCaptionSingleColor = false;
            this.buttonCaptionPanel1.IsOnlyCaption = true;
            this.buttonCaptionPanel1.IsPanelImage = true;
            this.buttonCaptionPanel1.IsUserButtonClose = false;
            this.buttonCaptionPanel1.IsUserCaptionBottomLine = false;
            this.buttonCaptionPanel1.IsUserSystemCloseButtonLeft = true;
            this.buttonCaptionPanel1.Location = new System.Drawing.Point(412, -129);
            this.buttonCaptionPanel1.Name = "buttonCaptionPanel1";
            this.buttonCaptionPanel1.PanelImage = null;
            this.buttonCaptionPanel1.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.WindowsStyle;
            this.buttonCaptionPanel1.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.buttonCaptionPanel1.Size = new System.Drawing.Size(150, 22);
            this.buttonCaptionPanel1.TabIndex = 18;
            this.buttonCaptionPanel1.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(987, 523);
            this.panel2.TabIndex = 125;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkUnion);
            this.panel1.Controls.Add(this.grpMessage);
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.cboClassName);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.lblBeginTime);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ddlDuty);
            this.panel1.Controls.Add(this.ddlDept);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpBeginTime);
            this.panel1.Controls.Add(this.txtBlock);
            this.panel1.Controls.Add(this.dtpEndTime);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 346);
            this.panel1.TabIndex = 0;
            // 
            // chkUnion
            // 
            this.chkUnion.AutoSize = true;
            this.chkUnion.Location = new System.Drawing.Point(107, 244);
            this.chkUnion.Name = "chkUnion";
            this.chkUnion.Size = new System.Drawing.Size(72, 16);
            this.chkUnion.TabIndex = 57;
            this.chkUnion.Text = "考勤合并";
            this.chkUnion.UseVisualStyleBackColor = true;
            this.chkUnion.CheckedChanged += new System.EventHandler(this.chkUnion_CheckedChanged);
            // 
            // grpMessage
            // 
            this.grpMessage.Controls.Add(this.radLast);
            this.grpMessage.Controls.Add(this.lblTimeLong);
            this.grpMessage.Controls.Add(this.radFull);
            this.grpMessage.Controls.Add(this.label11);
            this.grpMessage.Controls.Add(this.numTimeLong);
            this.grpMessage.Enabled = false;
            this.grpMessage.Location = new System.Drawing.Point(8, 258);
            this.grpMessage.Name = "grpMessage";
            this.grpMessage.Size = new System.Drawing.Size(184, 57);
            this.grpMessage.TabIndex = 52;
            this.grpMessage.TabStop = false;
            // 
            // radLast
            // 
            this.radLast.AutoSize = true;
            this.radLast.Location = new System.Drawing.Point(99, 13);
            this.radLast.Name = "radLast";
            this.radLast.Size = new System.Drawing.Size(71, 16);
            this.radLast.TabIndex = 49;
            this.radLast.TabStop = true;
            this.radLast.Text = "欠工信息";
            this.radLast.UseVisualStyleBackColor = true;
            // 
            // lblTimeLong
            // 
            this.lblTimeLong.AutoSize = true;
            this.lblTimeLong.Location = new System.Drawing.Point(3, 41);
            this.lblTimeLong.Name = "lblTimeLong";
            this.lblTimeLong.Size = new System.Drawing.Size(65, 12);
            this.lblTimeLong.TabIndex = 56;
            this.lblTimeLong.Text = "工作时长：";
            // 
            // radFull
            // 
            this.radFull.AutoSize = true;
            this.radFull.Location = new System.Drawing.Point(7, 13);
            this.radFull.Name = "radFull";
            this.radFull.Size = new System.Drawing.Size(71, 16);
            this.radFull.TabIndex = 50;
            this.radFull.TabStop = true;
            this.radFull.Text = "满工信息";
            this.radFull.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(139, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 55;
            this.label11.Text = "(分钟)";
            // 
            // numTimeLong
            // 
            this.numTimeLong.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.numTimeLong.Location = new System.Drawing.Point(73, 34);
            this.numTimeLong.MaxLength = 3;
            this.numTimeLong.Name = "numTimeLong";
            this.numTimeLong.Size = new System.Drawing.Size(60, 21);
            this.numTimeLong.TabIndex = 54;
            this.numTimeLong.Text = "480";
            this.numTimeLong.TextType = Shine.TextType.Number;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.Location = new System.Drawing.Point(16, 244);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(72, 16);
            this.chkAll.TabIndex = 17;
            this.chkAll.Text = "全部考勤";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // cboClassName
            // 
            this.cboClassName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClassName.FormattingEnabled = true;
            this.cboClassName.Location = new System.Drawing.Point(88, 210);
            this.cboClassName.Name = "cboClassName";
            this.cboClassName.Size = new System.Drawing.Size(91, 20);
            this.cboClassName.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 215);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 15;
            this.label10.Text = "班    次：";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(104, 317);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "重  置";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(23, 317);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "查  询";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(196, 25);
            this.panel3.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "考勤明细";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dgrd
            // 
            this.dgrd.AllowUserToAddRows = false;
            this.dgrd.AllowUserToResizeRows = false;
            this.dgrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrd.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrd.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.dgrd.Location = new System.Drawing.Point(0, 0);
            this.dgrd.Name = "dgrd";
            this.dgrd.ReadOnly = true;
            this.dgrd.RowHeadersVisible = false;
            this.dgrd.RowTemplate.Height = 23;
            this.dgrd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrd.Size = new System.Drawing.Size(783, 459);
            this.dgrd.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::KJ128NMainRun.Properties.Resources.人员考勤明细1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 346);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 173);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(783, 459);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // AttendanceParticulars
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.buttonCaptionPanel3);
            this.Controls.Add(this.buttonCaptionPanel2);
            this.Controls.Add(this.buttonCaptionPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AttendanceParticulars";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "考勤明细";
            this.Text = "考勤明细";
            this.Load += new System.EventHandler(this.AttendanceParticulars_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AttendanceParticulars_FormClosing);
            this.Controls.SetChildIndex(this.buttonCaptionPanel1, 0);
            this.Controls.SetChildIndex(this.buttonCaptionPanel2, 0);
            this.Controls.SetChildIndex(this.buttonCaptionPanel3, 0);
            this.Controls.SetChildIndex(this.lblErr, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panelLeft, 0);
            this.Controls.SetChildIndex(this.panelMain, 0);
            this.panelLeft.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMainBottom.ResumeLayout(false);
            this.panelMainBottom.PerformLayout();
            this.panelMainTop.ResumeLayout(false);
            this.panelMainTop.PerformLayout();
            this.drawerLeftMain.ResumeLayout(false);
            this.panelMainMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpMessage.ResumeLayout(false);
            this.grpMessage.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBeginTime;
        private System.Windows.Forms.DateTimePicker dtpBeginTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlDept;
        private System.Windows.Forms.ComboBox ddlDuty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel1;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel2;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel3;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.Panel panel2;
        private Shine.ShineTextBox txtUserName;
        private Shine.ShineTextBox txtBlock;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dgrd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cboClassName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.RadioButton radLast;
        private System.Windows.Forms.GroupBox grpMessage;
        private System.Windows.Forms.RadioButton radFull;
        private System.Windows.Forms.CheckBox chkUnion;
        private System.Windows.Forms.Label lblTimeLong;
        private System.Windows.Forms.Label label11;
        private Shine.ShineTextBox numTimeLong;
    }
}