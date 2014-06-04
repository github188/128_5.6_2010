namespace KJ128NInterfaceShow
{
    partial class adminInfo
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.用户 = new System.Windows.Forms.Label();
            this.txtUser = new Shine.ShineTextBox();
            this.密码 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new Shine.ShineTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPasswordn = new Shine.ShineTextBox();
            this.chkIsuse = new System.Windows.Forms.CheckBox();
            this.txtRemark = new Shine.ShineTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_UserGroup = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbIssame = new System.Windows.Forms.Label();
            this.buttonCaptionPanel4 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonCaptionPanel3 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIsEndDate = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCaptionPanel2 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.buttonCaptionPanel1 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxIsEndDate = new System.Windows.Forms.CheckBox();
            this.cbxUserGroup = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemark1 = new Shine.ShineTextBox();
            this.cbxIsUse1 = new System.Windows.Forms.CheckBox();
            this.txtPasswordn1 = new Shine.ShineTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPassword1 = new Shine.ShineTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUserName = new Shine.ShineTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtgAccount1 = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.ids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsUseEndDate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UseEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.sxpPanel1 = new Wilson.Controls.XPPanel.SXPPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAccount1)).BeginInit();
            this.sxpPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // 用户
            // 
            this.用户.AutoSize = true;
            this.用户.Location = new System.Drawing.Point(14, 80);
            this.用户.Name = "用户";
            this.用户.Size = new System.Drawing.Size(59, 13);
            this.用户.TabIndex = 20;
            this.用户.Text = "用户名称";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(73, 77);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 21;
            this.txtUser.TextType = Shine.TextType.WithOutChar;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            // 
            // 密码
            // 
            this.密码.AutoSize = true;
            this.密码.Location = new System.Drawing.Point(17, 108);
            this.密码.Name = "密码";
            this.密码.Size = new System.Drawing.Size(33, 13);
            this.密码.TabIndex = 22;
            this.密码.Text = "密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 23;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(73, 105);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 25;
            this.txtPassword.TextType = Shine.TextType.WithOutChar;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "用户组";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "再次确认";
            // 
            // txtPasswordn
            // 
            this.txtPasswordn.Location = new System.Drawing.Point(73, 137);
            this.txtPasswordn.MaxLength = 20;
            this.txtPasswordn.Name = "txtPasswordn";
            this.txtPasswordn.PasswordChar = '*';
            this.txtPasswordn.Size = new System.Drawing.Size(100, 20);
            this.txtPasswordn.TabIndex = 30;
            this.txtPasswordn.TextType = Shine.TextType.WithOutChar;
            // 
            // chkIsuse
            // 
            this.chkIsuse.AutoSize = true;
            this.chkIsuse.Checked = true;
            this.chkIsuse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsuse.Location = new System.Drawing.Point(19, 198);
            this.chkIsuse.Name = "chkIsuse";
            this.chkIsuse.Size = new System.Drawing.Size(104, 17);
            this.chkIsuse.TabIndex = 31;
            this.chkIsuse.Text = "用户是否可用";
            this.chkIsuse.UseVisualStyleBackColor = true;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(19, 244);
            this.txtRemark.MaxLength = 200;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(172, 155);
            this.txtRemark.TabIndex = 32;
            this.txtRemark.TextType = Shine.TextType.WithOutChar;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "备注";
            // 
            // cbx_UserGroup
            // 
            this.cbx_UserGroup.AutoCompleteCustomSource.AddRange(new string[] {
            "超级用户",
            "一般用户"});
            this.cbx_UserGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_UserGroup.FormattingEnabled = true;
            this.cbx_UserGroup.Location = new System.Drawing.Point(73, 168);
            this.cbx_UserGroup.Name = "cbx_UserGroup";
            this.cbx_UserGroup.Size = new System.Drawing.Size(100, 20);
            this.cbx_UserGroup.TabIndex = 35;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(326, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(58, 17);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加";
            this.groupBox1.Visible = false;
            // 
            // lbIssame
            // 
            this.lbIssame.AutoSize = true;
            this.lbIssame.ForeColor = System.Drawing.Color.Red;
            this.lbIssame.Location = new System.Drawing.Point(176, 80);
            this.lbIssame.Name = "lbIssame";
            this.lbIssame.Size = new System.Drawing.Size(0, 13);
            this.lbIssame.TabIndex = 61;
            // 
            // buttonCaptionPanel4
            // 
            this.buttonCaptionPanel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCaptionPanel4.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.buttonCaptionPanel4.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel4.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.buttonCaptionPanel4.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel4.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.buttonCaptionPanel4.CaptionBottomLineWidth = 1;
            this.buttonCaptionPanel4.CaptionCloseButtonControlLeft = 2;
            this.buttonCaptionPanel4.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCaptionPanel4.CaptionCloseButtonTitle = "×";
            this.buttonCaptionPanel4.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCaptionPanel4.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonCaptionPanel4.CaptionHeight = 20;
            this.buttonCaptionPanel4.CaptionLeft = 1;
            this.buttonCaptionPanel4.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.buttonCaptionPanel4.CaptionTitle = "取消　";
            this.buttonCaptionPanel4.CaptionTitleLeft = 8;
            this.buttonCaptionPanel4.CaptionTitleTop = 4;
            this.buttonCaptionPanel4.CaptionTop = 1;
            this.buttonCaptionPanel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCaptionPanel4.IsBorderLine = true;
            this.buttonCaptionPanel4.IsCaptionSingleColor = false;
            this.buttonCaptionPanel4.IsOnlyCaption = true;
            this.buttonCaptionPanel4.IsPanelImage = true;
            this.buttonCaptionPanel4.IsUserButtonClose = false;
            this.buttonCaptionPanel4.IsUserCaptionBottomLine = false;
            this.buttonCaptionPanel4.IsUserSystemCloseButtonLeft = true;
            this.buttonCaptionPanel4.Location = new System.Drawing.Point(103, 414);
            this.buttonCaptionPanel4.Name = "buttonCaptionPanel4";
            this.buttonCaptionPanel4.PanelImage = null;
            this.buttonCaptionPanel4.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.WindowsStyle;
            this.buttonCaptionPanel4.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.buttonCaptionPanel4.Size = new System.Drawing.Size(78, 22);
            this.buttonCaptionPanel4.TabIndex = 60;
            this.buttonCaptionPanel4.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.buttonCaptionPanel4.Click += new System.EventHandler(this.buttonCaptionPanel4_Load);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(73, 43);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(129, 20);
            this.dateTimePicker1.TabIndex = 9;
            this.dateTimePicker1.Visible = false;
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
            this.buttonCaptionPanel3.CaptionTitle = "保存";
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
            this.buttonCaptionPanel3.Location = new System.Drawing.Point(16, 414);
            this.buttonCaptionPanel3.Name = "buttonCaptionPanel3";
            this.buttonCaptionPanel3.PanelImage = null;
            this.buttonCaptionPanel3.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.WindowsStyle;
            this.buttonCaptionPanel3.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.buttonCaptionPanel3.Size = new System.Drawing.Size(78, 22);
            this.buttonCaptionPanel3.TabIndex = 59;
            this.buttonCaptionPanel3.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.buttonCaptionPanel3.Click += new System.EventHandler(this.buttonCaptionPanel3_Load);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "截止日期";
            this.label4.Visible = false;
            // 
            // chkIsEndDate
            // 
            this.chkIsEndDate.AutoSize = true;
            this.chkIsEndDate.Location = new System.Drawing.Point(92, 221);
            this.chkIsEndDate.Name = "chkIsEndDate";
            this.chkIsEndDate.Size = new System.Drawing.Size(117, 17);
            this.chkIsEndDate.TabIndex = 38;
            this.chkIsEndDate.Text = "是否有截止日期";
            this.chkIsEndDate.UseVisualStyleBackColor = true;
            this.chkIsEndDate.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.buttonCaptionPanel2);
            this.panel1.Controls.Add(this.buttonCaptionPanel1);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbxIsEndDate);
            this.panel1.Controls.Add(this.cbxUserGroup);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtRemark1);
            this.panel1.Controls.Add(this.cbxIsUse1);
            this.panel1.Controls.Add(this.txtPasswordn1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtPassword1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(328, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 395);
            this.panel1.TabIndex = 42;
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
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
            this.buttonCaptionPanel2.CaptionTitle = "关闭";
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
            this.buttonCaptionPanel2.Location = new System.Drawing.Point(156, 331);
            this.buttonCaptionPanel2.Name = "buttonCaptionPanel2";
            this.buttonCaptionPanel2.PanelImage = null;
            this.buttonCaptionPanel2.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.WindowsStyle;
            this.buttonCaptionPanel2.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.buttonCaptionPanel2.Size = new System.Drawing.Size(78, 22);
            this.buttonCaptionPanel2.TabIndex = 59;
            this.buttonCaptionPanel2.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.buttonCaptionPanel2.Click += new System.EventHandler(this.buttonCaptionPanel2_Load);
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
            this.buttonCaptionPanel1.CaptionTitle = "更新";
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
            this.buttonCaptionPanel1.Location = new System.Drawing.Point(56, 331);
            this.buttonCaptionPanel1.Name = "buttonCaptionPanel1";
            this.buttonCaptionPanel1.PanelImage = null;
            this.buttonCaptionPanel1.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.WindowsStyle;
            this.buttonCaptionPanel1.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.buttonCaptionPanel1.Size = new System.Drawing.Size(78, 22);
            this.buttonCaptionPanel1.TabIndex = 58;
            this.buttonCaptionPanel1.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.buttonCaptionPanel1.Click += new System.EventHandler(this.buttonCaptionPanel1_Load);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(108, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 57;
            this.label13.Text = "更新用户表";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(156, 186);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(129, 21);
            this.dateTimePicker2.TabIndex = 40;
            this.dateTimePicker2.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 54;
            this.label6.Text = "截止日期";
            this.label6.Visible = false;
            // 
            // cbxIsEndDate
            // 
            this.cbxIsEndDate.AutoSize = true;
            this.cbxIsEndDate.Location = new System.Drawing.Point(156, 170);
            this.cbxIsEndDate.Name = "cbxIsEndDate";
            this.cbxIsEndDate.Size = new System.Drawing.Size(108, 16);
            this.cbxIsEndDate.TabIndex = 53;
            this.cbxIsEndDate.Text = "是否有截止日期";
            this.cbxIsEndDate.UseVisualStyleBackColor = true;
            this.cbxIsEndDate.Visible = false;
            // 
            // cbxUserGroup
            // 
            this.cbxUserGroup.AllowDrop = true;
            this.cbxUserGroup.AutoCompleteCustomSource.AddRange(new string[] {
            "超级用户",
            "一般用户"});
            this.cbxUserGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUserGroup.FormattingEnabled = true;
            this.cbxUserGroup.Location = new System.Drawing.Point(110, 140);
            this.cbxUserGroup.Name = "cbxUserGroup";
            this.cbxUserGroup.Size = new System.Drawing.Size(100, 20);
            this.cbxUserGroup.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 51;
            this.label7.Text = "备注";
            // 
            // txtRemark1
            // 
            this.txtRemark1.Location = new System.Drawing.Point(56, 210);
            this.txtRemark1.MaxLength = 200;
            this.txtRemark1.Multiline = true;
            this.txtRemark1.Name = "txtRemark1";
            this.txtRemark1.Size = new System.Drawing.Size(172, 97);
            this.txtRemark1.TabIndex = 50;
            this.txtRemark1.TextType = Shine.TextType.WithOutChar;
            // 
            // cbxIsUse1
            // 
            this.cbxIsUse1.AutoSize = true;
            this.cbxIsUse1.Checked = true;
            this.cbxIsUse1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIsUse1.Location = new System.Drawing.Point(56, 166);
            this.cbxIsUse1.Name = "cbxIsUse1";
            this.cbxIsUse1.Size = new System.Drawing.Size(96, 16);
            this.cbxIsUse1.TabIndex = 49;
            this.cbxIsUse1.Text = "用户是否可用";
            this.cbxIsUse1.UseVisualStyleBackColor = true;
            // 
            // txtPasswordn1
            // 
            this.txtPasswordn1.Location = new System.Drawing.Point(110, 106);
            this.txtPasswordn1.MaxLength = 20;
            this.txtPasswordn1.Name = "txtPasswordn1";
            this.txtPasswordn1.PasswordChar = '*';
            this.txtPasswordn1.Size = new System.Drawing.Size(100, 21);
            this.txtPasswordn1.TabIndex = 48;
            this.txtPasswordn1.TextType = Shine.TextType.WithOutChar;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 47;
            this.label8.Text = "再次确认";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(54, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 46;
            this.label9.Text = "用户组";
            // 
            // txtPassword1
            // 
            this.txtPassword1.Location = new System.Drawing.Point(110, 76);
            this.txtPassword1.MaxLength = 20;
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.PasswordChar = '*';
            this.txtPassword1.Size = new System.Drawing.Size(100, 21);
            this.txtPassword1.TabIndex = 45;
            this.txtPassword1.TextType = Shine.TextType.WithOutChar;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(54, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 12);
            this.label10.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(54, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 43;
            this.label11.Text = "密码";
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(110, 42);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 21);
            this.txtUserName.TabIndex = 42;
            this.txtUserName.TextType = Shine.TextType.WithOutChar;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(54, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 41;
            this.label12.Text = "用户名称";
            // 
            // dtgAccount1
            // 
            this.dtgAccount1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtgAccount1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgAccount1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgAccount1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.dtgAccount1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgAccount1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(251)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgAccount1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgAccount1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgAccount1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ids,
            this.Account,
            this.IsEnable,
            this.IsUseEndDate,
            this.UseEndDate,
            this.remark,
            this.UgName,
            this.Column1,
            this.Column8});
            this.dtgAccount1.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.BlueStyle;
            this.dtgAccount1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgAccount1.EnableHeadersVisualStyles = false;
            this.dtgAccount1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(191)))), ((int)(((byte)(219)))));
            this.dtgAccount1.Location = new System.Drawing.Point(215, 0);
            this.dtgAccount1.Name = "dtgAccount1";
            this.dtgAccount1.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dtgAccount1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgAccount1.RowTemplate.Height = 23;
            this.dtgAccount1.Size = new System.Drawing.Size(748, 606);
            this.dtgAccount1.TabIndex = 41;
            this.dtgAccount1.VerticalScrollBarMax = 1;
            this.dtgAccount1.VerticalScrollBarValue = 0;
            this.dtgAccount1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgAccount_CellContentClick);
            // 
            // ids
            // 
            this.ids.DataPropertyName = "id";
            this.ids.HeaderText = "id";
            this.ids.Name = "ids";
            this.ids.Visible = false;
            // 
            // Account
            // 
            this.Account.DataPropertyName = "Account";
            this.Account.HeaderText = "用户名";
            this.Account.Name = "Account";
            this.Account.ReadOnly = true;
            // 
            // IsEnable
            // 
            this.IsEnable.DataPropertyName = "IsEnable";
            this.IsEnable.HeaderText = "用户是否可用";
            this.IsEnable.Name = "IsEnable";
            this.IsEnable.ReadOnly = true;
            // 
            // IsUseEndDate
            // 
            this.IsUseEndDate.DataPropertyName = "IsUseEndDate";
            this.IsUseEndDate.HeaderText = "是否有期限";
            this.IsUseEndDate.Name = "IsUseEndDate";
            this.IsUseEndDate.ReadOnly = true;
            this.IsUseEndDate.Visible = false;
            // 
            // UseEndDate
            // 
            this.UseEndDate.DataPropertyName = "UseEndDate";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            this.UseEndDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.UseEndDate.HeaderText = "期限";
            this.UseEndDate.Name = "UseEndDate";
            this.UseEndDate.ReadOnly = true;
            this.UseEndDate.Visible = false;
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            // 
            // UgName
            // 
            this.UgName.DataPropertyName = "UgName";
            this.UgName.HeaderText = "用户组";
            this.UgName.Name = "UgName";
            this.UgName.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "修改";
            this.Column1.Name = "Column1";
            this.Column1.Text = "修改";
            this.Column1.UseColumnTextForLinkValue = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "删除";
            this.Column8.Name = "Column8";
            this.Column8.Text = "删除";
            this.Column8.UseColumnTextForLinkValue = true;
            // 
            // sxpPanel1
            // 
            this.sxpPanel1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanel1.Caption = "增加账号信息";
            this.sxpPanel1.CaptionCornerType = ((Wilson.Controls.XPPanel.Enums.CornerType)((Wilson.Controls.XPPanel.Enums.CornerType.TopLeft | Wilson.Controls.XPPanel.Enums.CornerType.TopRight)));
            this.sxpPanel1.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.sxpPanel1.CaptionGradient.Start = System.Drawing.Color.White;
            this.sxpPanel1.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel1.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sxpPanel1.Controls.Add(this.用户);
            this.sxpPanel1.Controls.Add(this.lbIssame);
            this.sxpPanel1.Controls.Add(this.label1);
            this.sxpPanel1.Controls.Add(this.txtPasswordn);
            this.sxpPanel1.Controls.Add(this.buttonCaptionPanel4);
            this.sxpPanel1.Controls.Add(this.label5);
            this.sxpPanel1.Controls.Add(this.chkIsuse);
            this.sxpPanel1.Controls.Add(this.dateTimePicker1);
            this.sxpPanel1.Controls.Add(this.txtPassword);
            this.sxpPanel1.Controls.Add(this.txtRemark);
            this.sxpPanel1.Controls.Add(this.buttonCaptionPanel3);
            this.sxpPanel1.Controls.Add(this.label3);
            this.sxpPanel1.Controls.Add(this.label4);
            this.sxpPanel1.Controls.Add(this.label2);
            this.sxpPanel1.Controls.Add(this.密码);
            this.sxpPanel1.Controls.Add(this.chkIsEndDate);
            this.sxpPanel1.Controls.Add(this.cbx_UserGroup);
            this.sxpPanel1.Controls.Add(this.txtUser);
            this.sxpPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.sxpPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.sxpPanel1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sxpPanel1.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.sxpPanel1.ImageItems.ImageSet = null;
            this.sxpPanel1.ImageItems.Normal = -1;
            this.sxpPanel1.Location = new System.Drawing.Point(0, 0);
            this.sxpPanel1.Name = "sxpPanel1";
            this.sxpPanel1.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel1.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel1.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel1.Size = new System.Drawing.Size(215, 484);
            this.sxpPanel1.TabIndex = 62;
            this.sxpPanel1.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel1.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel1.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel1.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.sxpPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(215, 606);
            this.panel2.TabIndex = 63;
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // adminInfo
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(232)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(963, 606);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtgAccount1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(971, 640);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(971, 640);
            this.Name = "adminInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "帐号管理";
            this.Text = "帐号管理";
            this.Load += new System.EventHandler(this.adminInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAccount1)).EndInit();
            this.sxpPanel1.ResumeLayout(false);
            this.sxpPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label 用户;
        private System.Windows.Forms.Label 密码;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkIsuse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_UserGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkIsEndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private KJ128NInterfaceShow.DataGridViewKJ128 dtgAccount1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewLinkColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbxIsEndDate;
        private System.Windows.Forms.ComboBox cbxUserGroup;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbxIsUse1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel1;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel4;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel3;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel2;
        private System.Windows.Forms.Label lbIssame;
        private System.Windows.Forms.DataGridViewTextBoxColumn ids;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsEnable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsUseEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn UseEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn UgName;
        private System.Windows.Forms.DataGridViewLinkColumn Column1;
        private System.Windows.Forms.DataGridViewLinkColumn Column8;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel1;
        private System.Windows.Forms.Panel panel2;
        private Shine.ShineTextBox txtUser;
        private Shine.ShineTextBox txtPassword;
        private Shine.ShineTextBox txtPasswordn;
        private Shine.ShineTextBox txtRemark;
        private Shine.ShineTextBox txtRemark1;
        private Shine.ShineTextBox txtPasswordn1;
        private Shine.ShineTextBox txtPassword1;
        private Shine.ShineTextBox txtUserName;
        private System.Windows.Forms.Timer timer1;

    }
}