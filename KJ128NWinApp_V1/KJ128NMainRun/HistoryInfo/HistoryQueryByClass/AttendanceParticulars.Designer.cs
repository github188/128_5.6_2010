namespace KJ128NInterfaceShow
{
    partial class HistoryQueryByClass
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryQueryByClass));
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
            this.ddlRowsSet = new System.Windows.Forms.ComboBox();
            this.txtJump = new Shine.ShineTextBox();
            this.lblErr = new System.Windows.Forms.Label();
            this.cbTimerInterval = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnToExcel = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.dgrd = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.btnJump = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnPageIndexAndPageCount = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnNext = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnPreview = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnRowsCount = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.buttonCaptionPanel3 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.buttonCaptionPanel2 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.buttonCaptionPanel1 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnReset = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnQuery = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cpStation = new KJ128WindowsLibrary.CaptionPanel();
            this.cpBasic = new KJ128WindowsLibrary.CaptionPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sxpPanelGroup1 = new Wilson.Controls.XPPanel.Images.SXPPanelGroup();
            this.sxpPanel1 = new Wilson.Controls.XPPanel.SXPPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).BeginInit();
            this.sxpPanelGroup1.SuspendLayout();
            this.sxpPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBeginTime
            // 
            this.lblBeginTime.AutoSize = true;
            this.lblBeginTime.Location = new System.Drawing.Point(5, 47);
            this.lblBeginTime.Name = "lblBeginTime";
            this.lblBeginTime.Size = new System.Drawing.Size(63, 13);
            this.lblBeginTime.TabIndex = 3;
            this.lblBeginTime.Text = "开始时间:";
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.CustomFormat = "yyyy-MM-dd";
            this.dtpBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBeginTime.Location = new System.Drawing.Point(80, 39);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.Size = new System.Drawing.Size(106, 20);
            this.dtpBeginTime.TabIndex = 4;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(80, 76);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(106, 20);
            this.dtpEndTime.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "结束时间:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "所属部门:";
            // 
            // ddlDept
            // 
            this.ddlDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDept.FormattingEnabled = true;
            this.ddlDept.Location = new System.Drawing.Point(80, 113);
            this.ddlDept.Name = "ddlDept";
            this.ddlDept.Size = new System.Drawing.Size(106, 20);
            this.ddlDept.TabIndex = 8;
            // 
            // ddlDuty
            // 
            this.ddlDuty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDuty.FormattingEnabled = true;
            this.ddlDuty.Location = new System.Drawing.Point(80, 149);
            this.ddlDuty.Name = "ddlDuty";
            this.ddlDuty.Size = new System.Drawing.Size(106, 20);
            this.ddlDuty.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "所担职务:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "员工姓名:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(80, 256);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(106, 20);
            this.txtUserName.TabIndex = 12;
            // 
            // txtBlock
            // 
            this.txtBlock.Location = new System.Drawing.Point(80, 295);
            this.txtBlock.Name = "txtBlock";
            this.txtBlock.Size = new System.Drawing.Size(106, 20);
            this.txtBlock.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "发码器编号:";
            // 
            // ddlRowsSet
            // 
            this.ddlRowsSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlRowsSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlRowsSet.FormattingEnabled = true;
            this.ddlRowsSet.Location = new System.Drawing.Point(519, 5);
            this.ddlRowsSet.Name = "ddlRowsSet";
            this.ddlRowsSet.Size = new System.Drawing.Size(121, 20);
            this.ddlRowsSet.TabIndex = 17;
            this.ddlRowsSet.SelectionChangeCommitted += new System.EventHandler(this.ddlRowsSet_SelectionChangeCommitted);
            // 
            // txtJump
            // 
            this.txtJump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJump.Location = new System.Drawing.Point(1021, 5);
            this.txtJump.Name = "txtJump";
            this.txtJump.Size = new System.Drawing.Size(50, 21);
            this.txtJump.TabIndex = 25;
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.Location = new System.Drawing.Point(462, 708);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(0, 12);
            this.lblErr.TabIndex = 27;
            // 
            // cbTimerInterval
            // 
            this.cbTimerInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimerInterval.FormattingEnabled = true;
            this.cbTimerInterval.Location = new System.Drawing.Point(80, 219);
            this.cbTimerInterval.Name = "cbTimerInterval";
            this.cbTimerInterval.Size = new System.Drawing.Size(106, 20);
            this.cbTimerInterval.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "所属班次:";
            // 
            // cbClass
            // 
            this.cbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(80, 183);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(106, 20);
            this.cbClass.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "所属班制:";
            // 
            // btnToExcel
            // 
            this.btnToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnToExcel.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnToExcel.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnToExcel.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnToExcel.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnToExcel.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnToExcel.CaptionBottomLineWidth = 1;
            this.btnToExcel.CaptionCloseButtonControlLeft = 2;
            this.btnToExcel.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnToExcel.CaptionCloseButtonTitle = "×";
            this.btnToExcel.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnToExcel.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnToExcel.CaptionHeight = 20;
            this.btnToExcel.CaptionLeft = 1;
            this.btnToExcel.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnToExcel.CaptionTitle = " 打   印";
            this.btnToExcel.CaptionTitleLeft = 15;
            this.btnToExcel.CaptionTitleTop = 4;
            this.btnToExcel.CaptionTop = 1;
            this.btnToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToExcel.IsBorderLine = true;
            this.btnToExcel.IsCaptionSingleColor = false;
            this.btnToExcel.IsOnlyCaption = true;
            this.btnToExcel.IsPanelImage = true;
            this.btnToExcel.IsUserButtonClose = false;
            this.btnToExcel.IsUserCaptionBottomLine = false;
            this.btnToExcel.IsUserSystemCloseButtonLeft = true;
            this.btnToExcel.Location = new System.Drawing.Point(1157, 5);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.PanelImage = null;
            this.btnToExcel.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnToExcel.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnToExcel.Size = new System.Drawing.Size(97, 22);
            this.btnToExcel.TabIndex = 42;
            this.btnToExcel.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // dgrd
            // 
            this.dgrd.AllowUserToAddRows = false;
            this.dgrd.AllowUserToDeleteRows = false;
            this.dgrd.AllowUserToOrderColumns = true;
            this.dgrd.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgrd.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrd.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.dgrd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(251)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgrd.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.BlueStyle;
            this.dgrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrd.EnableHeadersVisualStyles = false;
            this.dgrd.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(191)))), ((int)(((byte)(219)))));
            this.dgrd.Location = new System.Drawing.Point(215, 33);
            this.dgrd.Name = "dgrd";
            this.dgrd.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrd.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrd.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dgrd.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrd.RowTemplate.Height = 23;
            this.dgrd.Size = new System.Drawing.Size(1069, 744);
            this.dgrd.TabIndex = 37;
            this.dgrd.VerticalScrollBarMax = 1;
            this.dgrd.VerticalScrollBarValue = 0;
            // 
            // btnJump
            // 
            this.btnJump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJump.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnJump.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnJump.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnJump.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnJump.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnJump.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnJump.CaptionBottomLineWidth = 1;
            this.btnJump.CaptionCloseButtonControlLeft = 2;
            this.btnJump.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnJump.CaptionCloseButtonTitle = "×";
            this.btnJump.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJump.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnJump.CaptionHeight = 20;
            this.btnJump.CaptionLeft = 1;
            this.btnJump.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnJump.CaptionTitle = "跳 转";
            this.btnJump.CaptionTitleLeft = 20;
            this.btnJump.CaptionTitleTop = 4;
            this.btnJump.CaptionTop = 1;
            this.btnJump.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJump.IsBorderLine = true;
            this.btnJump.IsCaptionSingleColor = false;
            this.btnJump.IsOnlyCaption = true;
            this.btnJump.IsPanelImage = true;
            this.btnJump.IsUserButtonClose = false;
            this.btnJump.IsUserCaptionBottomLine = false;
            this.btnJump.IsUserSystemCloseButtonLeft = true;
            this.btnJump.Location = new System.Drawing.Point(1077, 5);
            this.btnJump.Name = "btnJump";
            this.btnJump.PanelImage = null;
            this.btnJump.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnJump.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnJump.Size = new System.Drawing.Size(74, 22);
            this.btnJump.TabIndex = 26;
            this.btnJump.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnJump.Click += new System.EventHandler(this.btnJump_Click);
            // 
            // btnPageIndexAndPageCount
            // 
            this.btnPageIndexAndPageCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPageIndexAndPageCount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPageIndexAndPageCount.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnPageIndexAndPageCount.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnPageIndexAndPageCount.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnPageIndexAndPageCount.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnPageIndexAndPageCount.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnPageIndexAndPageCount.CaptionBottomLineWidth = 1;
            this.btnPageIndexAndPageCount.CaptionCloseButtonControlLeft = 2;
            this.btnPageIndexAndPageCount.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPageIndexAndPageCount.CaptionCloseButtonTitle = "×";
            this.btnPageIndexAndPageCount.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPageIndexAndPageCount.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.btnPageIndexAndPageCount.CaptionHeight = 20;
            this.btnPageIndexAndPageCount.CaptionLeft = 1;
            this.btnPageIndexAndPageCount.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnPageIndexAndPageCount.CaptionTitle = "";
            this.btnPageIndexAndPageCount.CaptionTitleLeft = 20;
            this.btnPageIndexAndPageCount.CaptionTitleTop = 4;
            this.btnPageIndexAndPageCount.CaptionTop = 1;
            this.btnPageIndexAndPageCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPageIndexAndPageCount.IsBorderLine = true;
            this.btnPageIndexAndPageCount.IsCaptionSingleColor = true;
            this.btnPageIndexAndPageCount.IsOnlyCaption = true;
            this.btnPageIndexAndPageCount.IsPanelImage = true;
            this.btnPageIndexAndPageCount.IsUserButtonClose = false;
            this.btnPageIndexAndPageCount.IsUserCaptionBottomLine = false;
            this.btnPageIndexAndPageCount.IsUserSystemCloseButtonLeft = true;
            this.btnPageIndexAndPageCount.Location = new System.Drawing.Point(920, 5);
            this.btnPageIndexAndPageCount.Name = "btnPageIndexAndPageCount";
            this.btnPageIndexAndPageCount.PanelImage = null;
            this.btnPageIndexAndPageCount.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.btnPageIndexAndPageCount.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.btnPageIndexAndPageCount.Size = new System.Drawing.Size(98, 22);
            this.btnPageIndexAndPageCount.TabIndex = 24;
            this.btnPageIndexAndPageCount.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNext.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnNext.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnNext.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnNext.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnNext.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnNext.CaptionBottomLineWidth = 1;
            this.btnNext.CaptionCloseButtonControlLeft = 2;
            this.btnNext.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNext.CaptionCloseButtonTitle = "×";
            this.btnNext.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNext.CaptionHeight = 20;
            this.btnNext.CaptionLeft = 1;
            this.btnNext.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnNext.CaptionTitle = "下一页";
            this.btnNext.CaptionTitleLeft = 8;
            this.btnNext.CaptionTitleTop = 4;
            this.btnNext.CaptionTop = 1;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.IsBorderLine = true;
            this.btnNext.IsCaptionSingleColor = false;
            this.btnNext.IsOnlyCaption = true;
            this.btnNext.IsPanelImage = true;
            this.btnNext.IsUserButtonClose = false;
            this.btnNext.IsUserCaptionBottomLine = false;
            this.btnNext.IsUserSystemCloseButtonLeft = true;
            this.btnNext.Location = new System.Drawing.Point(847, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.PanelImage = null;
            this.btnNext.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnNext.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnNext.Size = new System.Drawing.Size(71, 22);
            this.btnNext.TabIndex = 23;
            this.btnNext.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreview.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnPreview.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnPreview.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnPreview.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnPreview.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnPreview.CaptionBottomLineWidth = 1;
            this.btnPreview.CaptionCloseButtonControlLeft = 2;
            this.btnPreview.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPreview.CaptionCloseButtonTitle = "×";
            this.btnPreview.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPreview.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPreview.CaptionHeight = 20;
            this.btnPreview.CaptionLeft = 1;
            this.btnPreview.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnPreview.CaptionTitle = "上一页";
            this.btnPreview.CaptionTitleLeft = 8;
            this.btnPreview.CaptionTitleTop = 4;
            this.btnPreview.CaptionTop = 1;
            this.btnPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreview.IsBorderLine = true;
            this.btnPreview.IsCaptionSingleColor = false;
            this.btnPreview.IsOnlyCaption = true;
            this.btnPreview.IsPanelImage = true;
            this.btnPreview.IsUserButtonClose = false;
            this.btnPreview.IsUserCaptionBottomLine = false;
            this.btnPreview.IsUserSystemCloseButtonLeft = true;
            this.btnPreview.Location = new System.Drawing.Point(774, 4);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.PanelImage = null;
            this.btnPreview.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnPreview.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnPreview.Size = new System.Drawing.Size(71, 22);
            this.btnPreview.TabIndex = 22;
            this.btnPreview.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnRowsCount
            // 
            this.btnRowsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRowsCount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRowsCount.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnRowsCount.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnRowsCount.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnRowsCount.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnRowsCount.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnRowsCount.CaptionBottomLineWidth = 1;
            this.btnRowsCount.CaptionCloseButtonControlLeft = 2;
            this.btnRowsCount.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRowsCount.CaptionCloseButtonTitle = "×";
            this.btnRowsCount.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRowsCount.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.btnRowsCount.CaptionHeight = 20;
            this.btnRowsCount.CaptionLeft = 1;
            this.btnRowsCount.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnRowsCount.CaptionTitle = "";
            this.btnRowsCount.CaptionTitleLeft = 8;
            this.btnRowsCount.CaptionTitleTop = 4;
            this.btnRowsCount.CaptionTop = 1;
            this.btnRowsCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnRowsCount.IsBorderLine = true;
            this.btnRowsCount.IsCaptionSingleColor = true;
            this.btnRowsCount.IsOnlyCaption = true;
            this.btnRowsCount.IsPanelImage = true;
            this.btnRowsCount.IsUserButtonClose = false;
            this.btnRowsCount.IsUserCaptionBottomLine = false;
            this.btnRowsCount.IsUserSystemCloseButtonLeft = true;
            this.btnRowsCount.Location = new System.Drawing.Point(643, 4);
            this.btnRowsCount.Name = "btnRowsCount";
            this.btnRowsCount.PanelImage = null;
            this.btnRowsCount.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.btnRowsCount.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.btnRowsCount.Size = new System.Drawing.Size(129, 22);
            this.btnRowsCount.TabIndex = 21;
            this.btnRowsCount.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
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
            // btnReset
            // 
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReset.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnReset.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnReset.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnReset.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnReset.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnReset.CaptionBottomLineWidth = 1;
            this.btnReset.CaptionCloseButtonControlLeft = 2;
            this.btnReset.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReset.CaptionCloseButtonTitle = "×";
            this.btnReset.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReset.CaptionHeight = 20;
            this.btnReset.CaptionLeft = 1;
            this.btnReset.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnReset.CaptionTitle = "重 置";
            this.btnReset.CaptionTitleLeft = 20;
            this.btnReset.CaptionTitleTop = 4;
            this.btnReset.CaptionTop = 1;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.IsBorderLine = true;
            this.btnReset.IsCaptionSingleColor = false;
            this.btnReset.IsOnlyCaption = true;
            this.btnReset.IsPanelImage = true;
            this.btnReset.IsUserButtonClose = false;
            this.btnReset.IsUserCaptionBottomLine = false;
            this.btnReset.IsUserSystemCloseButtonLeft = true;
            this.btnReset.Location = new System.Drawing.Point(106, 336);
            this.btnReset.Name = "btnReset";
            this.btnReset.PanelImage = null;
            this.btnReset.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnReset.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnReset.Size = new System.Drawing.Size(75, 22);
            this.btnReset.TabIndex = 16;
            this.btnReset.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuery.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnQuery.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnQuery.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnQuery.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnQuery.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnQuery.CaptionBottomLineWidth = 1;
            this.btnQuery.CaptionCloseButtonControlLeft = 2;
            this.btnQuery.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnQuery.CaptionCloseButtonTitle = "×";
            this.btnQuery.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuery.CaptionHeight = 20;
            this.btnQuery.CaptionLeft = 1;
            this.btnQuery.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnQuery.CaptionTitle = "查 询";
            this.btnQuery.CaptionTitleLeft = 20;
            this.btnQuery.CaptionTitleTop = 4;
            this.btnQuery.CaptionTop = 1;
            this.btnQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuery.IsBorderLine = true;
            this.btnQuery.IsCaptionSingleColor = false;
            this.btnQuery.IsOnlyCaption = true;
            this.btnQuery.IsPanelImage = true;
            this.btnQuery.IsUserButtonClose = false;
            this.btnQuery.IsUserCaptionBottomLine = false;
            this.btnQuery.IsUserSystemCloseButtonLeft = true;
            this.btnQuery.Location = new System.Drawing.Point(8, 336);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.PanelImage = null;
            this.btnQuery.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnQuery.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnQuery.Size = new System.Drawing.Size(75, 22);
            this.btnQuery.TabIndex = 15;
            this.btnQuery.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cpStation
            // 
            this.cpStation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpStation.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpStation.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpStation.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpStation.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpStation.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpStation.CaptionBottomLineWidth = 1;
            this.cpStation.CaptionCloseButtonControlLeft = 2;
            this.cpStation.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpStation.CaptionCloseButtonTitle = "×";
            this.cpStation.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpStation.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cpStation.CaptionHeight = 20;
            this.cpStation.CaptionLeft = 1;
            this.cpStation.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpStation.CaptionTitle = "查询条件";
            this.cpStation.CaptionTitleLeft = 30;
            this.cpStation.CaptionTitleTop = 4;
            this.cpStation.CaptionTop = 1;
            this.cpStation.IsBorderLine = true;
            this.cpStation.IsCaptionSingleColor = false;
            this.cpStation.IsOnlyCaption = false;
            this.cpStation.IsPanelImage = false;
            this.cpStation.IsUserButtonClose = false;
            this.cpStation.IsUserCaptionBottomLine = true;
            this.cpStation.IsUserSystemCloseButtonLeft = true;
            this.cpStation.Location = new System.Drawing.Point(0, 663);
            this.cpStation.Name = "cpStation";
            this.cpStation.PanelImage = null;
            this.cpStation.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.cpStation.Size = new System.Drawing.Size(200, 57);
            this.cpStation.TabIndex = 1;
            // 
            // cpBasic
            // 
            this.cpBasic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpBasic.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpBasic.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpBasic.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpBasic.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpBasic.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpBasic.CaptionBottomLineWidth = 1;
            this.cpBasic.CaptionCloseButtonControlLeft = 2;
            this.cpBasic.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpBasic.CaptionCloseButtonTitle = "×";
            this.cpBasic.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpBasic.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cpBasic.CaptionHeight = 30;
            this.cpBasic.CaptionLeft = 1;
            this.cpBasic.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpBasic.CaptionTitle = "";
            this.cpBasic.CaptionTitleLeft = 8;
            this.cpBasic.CaptionTitleTop = 4;
            this.cpBasic.CaptionTop = 1;
            this.cpBasic.Dock = System.Windows.Forms.DockStyle.Top;
            this.cpBasic.IsBorderLine = true;
            this.cpBasic.IsCaptionSingleColor = false;
            this.cpBasic.IsOnlyCaption = false;
            this.cpBasic.IsPanelImage = false;
            this.cpBasic.IsUserButtonClose = false;
            this.cpBasic.IsUserCaptionBottomLine = true;
            this.cpBasic.IsUserSystemCloseButtonLeft = true;
            this.cpBasic.Location = new System.Drawing.Point(215, 0);
            this.cpBasic.Name = "cpBasic";
            this.cpBasic.PanelImage = null;
            this.cpBasic.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.cpBasic.Size = new System.Drawing.Size(1069, 33);
            this.cpBasic.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sxpPanelGroup1);
            this.panel1.Controls.Add(this.cpStation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 777);
            this.panel1.TabIndex = 43;
            // 
            // sxpPanelGroup1
            // 
            this.sxpPanelGroup1.AutoScroll = true;
            this.sxpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel1);
            this.sxpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sxpPanelGroup1.Location = new System.Drawing.Point(0, 0);
            this.sxpPanelGroup1.Name = "sxpPanelGroup1";
            this.sxpPanelGroup1.PanelGradient = ((Wilson.Controls.XPPanel.Colors.GradientColor)(resources.GetObject("sxpPanelGroup1.PanelGradient")));
            this.sxpPanelGroup1.Size = new System.Drawing.Size(215, 777);
            this.sxpPanelGroup1.TabIndex = 44;
            // 
            // sxpPanel1
            // 
            this.sxpPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sxpPanel1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanel1.Caption = "查询条件";
            this.sxpPanel1.CaptionCornerType = ((Wilson.Controls.XPPanel.Enums.CornerType)((Wilson.Controls.XPPanel.Enums.CornerType.TopLeft | Wilson.Controls.XPPanel.Enums.CornerType.TopRight)));
            this.sxpPanel1.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.sxpPanel1.CaptionGradient.Start = System.Drawing.Color.White;
            this.sxpPanel1.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel1.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sxpPanel1.Controls.Add(this.lblBeginTime);
            this.sxpPanel1.Controls.Add(this.cbTimerInterval);
            this.sxpPanel1.Controls.Add(this.btnReset);
            this.sxpPanel1.Controls.Add(this.dtpBeginTime);
            this.sxpPanel1.Controls.Add(this.btnQuery);
            this.sxpPanel1.Controls.Add(this.label6);
            this.sxpPanel1.Controls.Add(this.txtBlock);
            this.sxpPanel1.Controls.Add(this.label1);
            this.sxpPanel1.Controls.Add(this.label5);
            this.sxpPanel1.Controls.Add(this.cbClass);
            this.sxpPanel1.Controls.Add(this.txtUserName);
            this.sxpPanel1.Controls.Add(this.dtpEndTime);
            this.sxpPanel1.Controls.Add(this.label4);
            this.sxpPanel1.Controls.Add(this.label7);
            this.sxpPanel1.Controls.Add(this.ddlDuty);
            this.sxpPanel1.Controls.Add(this.label2);
            this.sxpPanel1.Controls.Add(this.label3);
            this.sxpPanel1.Controls.Add(this.ddlDept);
            this.sxpPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.sxpPanel1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sxpPanel1.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.sxpPanel1.ImageItems.ImageSet = null;
            this.sxpPanel1.ImageItems.Normal = -1;
            this.sxpPanel1.Location = new System.Drawing.Point(8, 8);
            this.sxpPanel1.Name = "sxpPanel1";
            this.sxpPanel1.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel1.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel1.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel1.Size = new System.Drawing.Size(199, 380);
            this.sxpPanel1.TabIndex = 44;
            this.sxpPanel1.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel1.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel1.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel1.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // HistoryQueryByClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1284, 777);
            this.Controls.Add(this.dgrd);
            this.Controls.Add(this.btnToExcel);
            this.Controls.Add(this.btnJump);
            this.Controls.Add(this.txtJump);
            this.Controls.Add(this.btnPageIndexAndPageCount);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnRowsCount);
            this.Controls.Add(this.ddlRowsSet);
            this.Controls.Add(this.cpBasic);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.buttonCaptionPanel3);
            this.Controls.Add(this.buttonCaptionPanel2);
            this.Controls.Add(this.buttonCaptionPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HistoryQueryByClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "历史上下井班次查询";
            this.Text = "历史上下井班次查询";
            this.Load += new System.EventHandler(this.AttendanceParticulars_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).EndInit();
            this.sxpPanelGroup1.ResumeLayout(false);
            this.sxpPanel1.ResumeLayout(false);
            this.sxpPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KJ128WindowsLibrary.CaptionPanel cpBasic;
        private KJ128WindowsLibrary.CaptionPanel cpStation;
        private System.Windows.Forms.Label lblBeginTime;
        private System.Windows.Forms.DateTimePicker dtpBeginTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlDept;
        private System.Windows.Forms.ComboBox ddlDuty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtBlock;
        private System.Windows.Forms.Label label5;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnQuery;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnReset;
        private System.Windows.Forms.ComboBox ddlRowsSet;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel1;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel2;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel3;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnRowsCount;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnPreview;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnNext;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnPageIndexAndPageCount;
        private System.Windows.Forms.TextBox txtJump;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnJump;
        private System.Windows.Forms.Label lblErr;
        private DataGridViewKJ128 dgrd;
        private System.Windows.Forms.ComboBox cbTimerInterval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Label label7;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnToExcel;
        private System.Windows.Forms.Panel panel1;
        private Wilson.Controls.XPPanel.Images.SXPPanelGroup sxpPanelGroup1;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel1;
    }
}