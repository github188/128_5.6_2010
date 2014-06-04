namespace KJ128NInterfaceShow
{
    partial class AddHistoryAttendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddHistoryAttendance));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new Shine.ShineTextBox();
            this.lblBlock = new System.Windows.Forms.Label();
            this.txtBlock = new Shine.ShineTextBox();
            this.lblDept = new System.Windows.Forms.Label();
            this.ddlDept = new System.Windows.Forms.ComboBox();
            this.ddlClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlTimerInterval = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbModify = new System.Windows.Forms.GroupBox();
            this.txtRemarkAdd = new Shine.ShineTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpDataAttendanceAdd = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpEndTimeAdd = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpBeginTimeAdd = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.lblErr = new System.Windows.Forms.Label();
            this.txtUserNameAdd = new Shine.ShineTextBox();
            this.btnReturn = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnModifyAndAdd = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.txtBlockAdd = new Shine.ShineTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ddlDeptAdd = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ddlTimerIntervalAdd = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlClassAdd = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlRowsSet = new System.Windows.Forms.ComboBox();
            this.txtJump = new Shine.ShineTextBox();
            this.lblPageIndex = new System.Windows.Forms.Label();
            this.btnJump = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnPageIndexAndPageCount = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnNext = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnPreview = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnRowsCount = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cpModify = new KJ128WindowsLibrary.CaptionPanel();
            this.btnAdd = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnClear = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnQuery = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cpStation = new KJ128WindowsLibrary.CaptionPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sxpPanelGroup1 = new Wilson.Controls.XPPanel.Images.SXPPanelGroup();
            this.sxpPanel2 = new Wilson.Controls.XPPanel.SXPPanel();
            this.sxpPanel1 = new Wilson.Controls.XPPanel.SXPPanel();
            this.cpAdd = new KJ128WindowsLibrary.CaptionPanel();
            this.cpAll = new KJ128WindowsLibrary.CaptionPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgrd = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.cellEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cellDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gbModify.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).BeginInit();
            this.sxpPanelGroup1.SuspendLayout();
            this.sxpPanel2.SuspendLayout();
            this.sxpPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(20, 51);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(63, 13);
            this.lblStartTime.TabIndex = 4;
            this.lblStartTime.Text = "开始日期:";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(92, 47);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(88, 20);
            this.dtpStartTime.TabIndex = 5;
            this.dtpStartTime.Value = new System.DateTime(2007, 10, 26, 0, 0, 0, 0);
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(20, 86);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(63, 13);
            this.lblEndTime.TabIndex = 6;
            this.lblEndTime.Text = "结束日期:";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(92, 82);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(88, 20);
            this.dtpEndTime.TabIndex = 7;
            this.dtpEndTime.Value = new System.DateTime(2007, 10, 26, 0, 0, 0, 0);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(20, 122);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 13);
            this.lblUserName.TabIndex = 8;
            this.lblUserName.Text = "员工姓名:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(91, 116);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(89, 20);
            this.txtUserName.TabIndex = 9;
            this.txtUserName.TextType = Shine.TextType.WithOutChar;
            // 
            // lblBlock
            // 
            this.lblBlock.AutoSize = true;
            this.lblBlock.Location = new System.Drawing.Point(7, 155);
            this.lblBlock.Name = "lblBlock";
            this.lblBlock.Size = new System.Drawing.Size(76, 13);
            this.lblBlock.TabIndex = 10;
            this.lblBlock.Text = "发码器编号:";
            // 
            // txtBlock
            // 
            this.txtBlock.Location = new System.Drawing.Point(91, 149);
            this.txtBlock.Name = "txtBlock";
            this.txtBlock.Size = new System.Drawing.Size(89, 20);
            this.txtBlock.TabIndex = 11;
            this.txtBlock.TextType = Shine.TextType.Number;
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Location = new System.Drawing.Point(20, 187);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(63, 13);
            this.lblDept.TabIndex = 12;
            this.lblDept.Text = "所属部门:";
            // 
            // ddlDept
            // 
            this.ddlDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDept.FormattingEnabled = true;
            this.ddlDept.Location = new System.Drawing.Point(91, 181);
            this.ddlDept.Name = "ddlDept";
            this.ddlDept.Size = new System.Drawing.Size(89, 20);
            this.ddlDept.TabIndex = 13;
            // 
            // ddlClass
            // 
            this.ddlClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlClass.FormattingEnabled = true;
            this.ddlClass.Location = new System.Drawing.Point(91, 216);
            this.ddlClass.Name = "ddlClass";
            this.ddlClass.Size = new System.Drawing.Size(89, 20);
            this.ddlClass.TabIndex = 15;
            this.ddlClass.SelectionChangeCommitted += new System.EventHandler(this.ddlClass_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "班制:";
            // 
            // ddlTimerInterval
            // 
            this.ddlTimerInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTimerInterval.FormattingEnabled = true;
            this.ddlTimerInterval.Location = new System.Drawing.Point(91, 251);
            this.ddlTimerInterval.Name = "ddlTimerInterval";
            this.ddlTimerInterval.Size = new System.Drawing.Size(89, 20);
            this.ddlTimerInterval.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "班次:";
            // 
            // gbModify
            // 
            this.gbModify.Controls.Add(this.txtRemarkAdd);
            this.gbModify.Controls.Add(this.label11);
            this.gbModify.Controls.Add(this.dtpDataAttendanceAdd);
            this.gbModify.Controls.Add(this.label10);
            this.gbModify.Controls.Add(this.dtpEndTimeAdd);
            this.gbModify.Controls.Add(this.label9);
            this.gbModify.Controls.Add(this.dtpBeginTimeAdd);
            this.gbModify.Controls.Add(this.label8);
            this.gbModify.Controls.Add(this.lblErr);
            this.gbModify.Controls.Add(this.txtUserNameAdd);
            this.gbModify.Controls.Add(this.btnReturn);
            this.gbModify.Controls.Add(this.label7);
            this.gbModify.Controls.Add(this.btnModifyAndAdd);
            this.gbModify.Controls.Add(this.txtBlockAdd);
            this.gbModify.Controls.Add(this.label6);
            this.gbModify.Controls.Add(this.ddlDeptAdd);
            this.gbModify.Controls.Add(this.label5);
            this.gbModify.Controls.Add(this.ddlTimerIntervalAdd);
            this.gbModify.Controls.Add(this.label4);
            this.gbModify.Controls.Add(this.ddlClassAdd);
            this.gbModify.Controls.Add(this.label3);
            this.gbModify.Location = new System.Drawing.Point(380, 88);
            this.gbModify.Name = "gbModify";
            this.gbModify.Size = new System.Drawing.Size(421, 464);
            this.gbModify.TabIndex = 23;
            this.gbModify.TabStop = false;
            // 
            // txtRemarkAdd
            // 
            this.txtRemarkAdd.Location = new System.Drawing.Point(154, 325);
            this.txtRemarkAdd.Multiline = true;
            this.txtRemarkAdd.Name = "txtRemarkAdd";
            this.txtRemarkAdd.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRemarkAdd.Size = new System.Drawing.Size(148, 66);
            this.txtRemarkAdd.TabIndex = 17;
            this.txtRemarkAdd.TextType = Shine.TextType.WithOutChar;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(107, 328);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 16;
            this.label11.Text = "备注:";
            // 
            // dtpDataAttendanceAdd
            // 
            this.dtpDataAttendanceAdd.CustomFormat = "yyyy-MM-dd";
            this.dtpDataAttendanceAdd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataAttendanceAdd.Location = new System.Drawing.Point(154, 289);
            this.dtpDataAttendanceAdd.Name = "dtpDataAttendanceAdd";
            this.dtpDataAttendanceAdd.Size = new System.Drawing.Size(148, 21);
            this.dtpDataAttendanceAdd.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(89, 293);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "记工日期:";
            // 
            // dtpEndTimeAdd
            // 
            this.dtpEndTimeAdd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndTimeAdd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTimeAdd.Location = new System.Drawing.Point(154, 250);
            this.dtpEndTimeAdd.Name = "dtpEndTimeAdd";
            this.dtpEndTimeAdd.Size = new System.Drawing.Size(148, 21);
            this.dtpEndTimeAdd.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(89, 254);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "下班时间:";
            // 
            // dtpBeginTimeAdd
            // 
            this.dtpBeginTimeAdd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBeginTimeAdd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBeginTimeAdd.Location = new System.Drawing.Point(154, 211);
            this.dtpBeginTimeAdd.Name = "dtpBeginTimeAdd";
            this.dtpBeginTimeAdd.Size = new System.Drawing.Size(148, 21);
            this.dtpBeginTimeAdd.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(89, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "上班时间:";
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.Location = new System.Drawing.Point(163, 442);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(0, 12);
            this.lblErr.TabIndex = 26;
            // 
            // txtUserNameAdd
            // 
            this.txtUserNameAdd.Location = new System.Drawing.Point(155, 174);
            this.txtUserNameAdd.Name = "txtUserNameAdd";
            this.txtUserNameAdd.ReadOnly = true;
            this.txtUserNameAdd.Size = new System.Drawing.Size(147, 21);
            this.txtUserNameAdd.TabIndex = 9;
            this.txtUserNameAdd.TextType = Shine.TextType.WithOutChar;
            this.txtUserNameAdd.Enter += new System.EventHandler(this.txtUserNameAdd_Enter);
            // 
            // btnReturn
            // 
            this.btnReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReturn.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnReturn.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnReturn.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnReturn.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnReturn.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnReturn.CaptionBottomLineWidth = 1;
            this.btnReturn.CaptionCloseButtonControlLeft = 2;
            this.btnReturn.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReturn.CaptionCloseButtonTitle = "×";
            this.btnReturn.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturn.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReturn.CaptionHeight = 20;
            this.btnReturn.CaptionLeft = 1;
            this.btnReturn.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnReturn.CaptionTitle = "返 回";
            this.btnReturn.CaptionTitleLeft = 25;
            this.btnReturn.CaptionTitleTop = 4;
            this.btnReturn.CaptionTop = 1;
            this.btnReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturn.IsBorderLine = true;
            this.btnReturn.IsCaptionSingleColor = false;
            this.btnReturn.IsOnlyCaption = true;
            this.btnReturn.IsPanelImage = true;
            this.btnReturn.IsUserButtonClose = false;
            this.btnReturn.IsUserCaptionBottomLine = false;
            this.btnReturn.IsUserSystemCloseButtonLeft = true;
            this.btnReturn.Location = new System.Drawing.Point(240, 406);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.PanelImage = null;
            this.btnReturn.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnReturn.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnReturn.Size = new System.Drawing.Size(94, 22);
            this.btnReturn.TabIndex = 25;
            this.btnReturn.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(89, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "员工姓名:";
            // 
            // btnModifyAndAdd
            // 
            this.btnModifyAndAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModifyAndAdd.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnModifyAndAdd.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnModifyAndAdd.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnModifyAndAdd.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnModifyAndAdd.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnModifyAndAdd.CaptionBottomLineWidth = 1;
            this.btnModifyAndAdd.CaptionCloseButtonControlLeft = 2;
            this.btnModifyAndAdd.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnModifyAndAdd.CaptionCloseButtonTitle = "×";
            this.btnModifyAndAdd.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnModifyAndAdd.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnModifyAndAdd.CaptionHeight = 20;
            this.btnModifyAndAdd.CaptionLeft = 1;
            this.btnModifyAndAdd.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnModifyAndAdd.CaptionTitle = "修 改";
            this.btnModifyAndAdd.CaptionTitleLeft = 25;
            this.btnModifyAndAdd.CaptionTitleTop = 4;
            this.btnModifyAndAdd.CaptionTop = 1;
            this.btnModifyAndAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModifyAndAdd.IsBorderLine = true;
            this.btnModifyAndAdd.IsCaptionSingleColor = false;
            this.btnModifyAndAdd.IsOnlyCaption = true;
            this.btnModifyAndAdd.IsPanelImage = true;
            this.btnModifyAndAdd.IsUserButtonClose = false;
            this.btnModifyAndAdd.IsUserCaptionBottomLine = false;
            this.btnModifyAndAdd.IsUserSystemCloseButtonLeft = true;
            this.btnModifyAndAdd.Location = new System.Drawing.Point(123, 406);
            this.btnModifyAndAdd.Name = "btnModifyAndAdd";
            this.btnModifyAndAdd.PanelImage = null;
            this.btnModifyAndAdd.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnModifyAndAdd.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnModifyAndAdd.Size = new System.Drawing.Size(94, 22);
            this.btnModifyAndAdd.TabIndex = 24;
            this.btnModifyAndAdd.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnModifyAndAdd.Click += new System.EventHandler(this.btnModifyAndAdd_Click);
            // 
            // txtBlockAdd
            // 
            this.txtBlockAdd.Location = new System.Drawing.Point(155, 135);
            this.txtBlockAdd.Name = "txtBlockAdd";
            this.txtBlockAdd.Size = new System.Drawing.Size(147, 21);
            this.txtBlockAdd.TabIndex = 7;
            this.txtBlockAdd.TextType = Shine.TextType.Number;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(79, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "发码器编号:";
            // 
            // ddlDeptAdd
            // 
            this.ddlDeptAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDeptAdd.FormattingEnabled = true;
            this.ddlDeptAdd.Location = new System.Drawing.Point(154, 96);
            this.ddlDeptAdd.Name = "ddlDeptAdd";
            this.ddlDeptAdd.Size = new System.Drawing.Size(148, 20);
            this.ddlDeptAdd.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(89, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "所属部门:";
            // 
            // ddlTimerIntervalAdd
            // 
            this.ddlTimerIntervalAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTimerIntervalAdd.FormattingEnabled = true;
            this.ddlTimerIntervalAdd.Location = new System.Drawing.Point(154, 57);
            this.ddlTimerIntervalAdd.Name = "ddlTimerIntervalAdd";
            this.ddlTimerIntervalAdd.Size = new System.Drawing.Size(148, 20);
            this.ddlTimerIntervalAdd.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "上班时段:";
            // 
            // ddlClassAdd
            // 
            this.ddlClassAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlClassAdd.FormattingEnabled = true;
            this.ddlClassAdd.Location = new System.Drawing.Point(154, 21);
            this.ddlClassAdd.Name = "ddlClassAdd";
            this.ddlClassAdd.Size = new System.Drawing.Size(148, 20);
            this.ddlClassAdd.TabIndex = 1;
            this.ddlClassAdd.SelectionChangeCommitted += new System.EventHandler(this.ddlClassAdd_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "所属班制:";
            // 
            // ddlRowsSet
            // 
            this.ddlRowsSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlRowsSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlRowsSet.FormattingEnabled = true;
            this.ddlRowsSet.Location = new System.Drawing.Point(212, 4);
            this.ddlRowsSet.Name = "ddlRowsSet";
            this.ddlRowsSet.Size = new System.Drawing.Size(121, 20);
            this.ddlRowsSet.TabIndex = 27;
            this.ddlRowsSet.SelectionChangeCommitted += new System.EventHandler(this.ddlRowsSet_SelectionChangeCommitted);
            // 
            // txtJump
            // 
            this.txtJump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJump.Location = new System.Drawing.Point(678, 3);
            this.txtJump.Name = "txtJump";
            this.txtJump.Size = new System.Drawing.Size(54, 21);
            this.txtJump.TabIndex = 32;
            this.txtJump.TextType = Shine.TextType.Number;
            // 
            // lblPageIndex
            // 
            this.lblPageIndex.AutoSize = true;
            this.lblPageIndex.Location = new System.Drawing.Point(801, 237);
            this.lblPageIndex.Name = "lblPageIndex";
            this.lblPageIndex.Size = new System.Drawing.Size(0, 12);
            this.lblPageIndex.TabIndex = 34;
            this.lblPageIndex.Visible = false;
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
            this.btnJump.CaptionTitle = "跳  转";
            this.btnJump.CaptionTitleLeft = 8;
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
            this.btnJump.Location = new System.Drawing.Point(738, 3);
            this.btnJump.Name = "btnJump";
            this.btnJump.PanelImage = null;
            this.btnJump.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnJump.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnJump.Size = new System.Drawing.Size(64, 22);
            this.btnJump.TabIndex = 33;
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
            this.btnPageIndexAndPageCount.Location = new System.Drawing.Point(576, 3);
            this.btnPageIndexAndPageCount.Name = "btnPageIndexAndPageCount";
            this.btnPageIndexAndPageCount.PanelImage = null;
            this.btnPageIndexAndPageCount.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.btnPageIndexAndPageCount.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.btnPageIndexAndPageCount.Size = new System.Drawing.Size(96, 22);
            this.btnPageIndexAndPageCount.TabIndex = 31;
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
            this.btnNext.Location = new System.Drawing.Point(507, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.PanelImage = null;
            this.btnNext.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnNext.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnNext.Size = new System.Drawing.Size(64, 22);
            this.btnNext.TabIndex = 30;
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
            this.btnPreview.Location = new System.Drawing.Point(438, 3);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.PanelImage = null;
            this.btnPreview.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnPreview.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnPreview.Size = new System.Drawing.Size(64, 22);
            this.btnPreview.TabIndex = 29;
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
            this.btnRowsCount.CaptionTitleLeft = 1;
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
            this.btnRowsCount.Location = new System.Drawing.Point(339, 3);
            this.btnRowsCount.Name = "btnRowsCount";
            this.btnRowsCount.PanelImage = null;
            this.btnRowsCount.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.btnRowsCount.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.btnRowsCount.Size = new System.Drawing.Size(94, 22);
            this.btnRowsCount.TabIndex = 28;
            this.btnRowsCount.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // cpModify
            // 
            this.cpModify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpModify.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpModify.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpModify.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpModify.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpModify.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpModify.CaptionBottomLineWidth = 1;
            this.cpModify.CaptionCloseButtonControlLeft = 2;
            this.cpModify.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpModify.CaptionCloseButtonTitle = "×";
            this.cpModify.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpModify.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cpModify.CaptionHeight = 20;
            this.cpModify.CaptionLeft = 1;
            this.cpModify.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpModify.CaptionTitle = "历史考勤补单";
            this.cpModify.CaptionTitleLeft = 8;
            this.cpModify.CaptionTitleTop = 4;
            this.cpModify.CaptionTop = 1;
            this.cpModify.IsBorderLine = true;
            this.cpModify.IsCaptionSingleColor = false;
            this.cpModify.IsOnlyCaption = false;
            this.cpModify.IsPanelImage = false;
            this.cpModify.IsUserButtonClose = false;
            this.cpModify.IsUserCaptionBottomLine = true;
            this.cpModify.IsUserSystemCloseButtonLeft = true;
            this.cpModify.Location = new System.Drawing.Point(356, 59);
            this.cpModify.Name = "cpModify";
            this.cpModify.PanelImage = null;
            this.cpModify.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.cpModify.Size = new System.Drawing.Size(498, 504);
            this.cpModify.TabIndex = 22;
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnAdd.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnAdd.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnAdd.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnAdd.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnAdd.CaptionBottomLineWidth = 1;
            this.btnAdd.CaptionCloseButtonControlLeft = 2;
            this.btnAdd.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAdd.CaptionCloseButtonTitle = "×";
            this.btnAdd.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAdd.CaptionHeight = 20;
            this.btnAdd.CaptionLeft = 1;
            this.btnAdd.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAdd.CaptionTitle = "补考勤";
            this.btnAdd.CaptionTitleLeft = 20;
            this.btnAdd.CaptionTitleTop = 4;
            this.btnAdd.CaptionTop = 1;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.IsBorderLine = true;
            this.btnAdd.IsCaptionSingleColor = false;
            this.btnAdd.IsOnlyCaption = true;
            this.btnAdd.IsPanelImage = true;
            this.btnAdd.IsUserButtonClose = false;
            this.btnAdd.IsUserCaptionBottomLine = false;
            this.btnAdd.IsUserSystemCloseButtonLeft = true;
            this.btnAdd.Location = new System.Drawing.Point(45, 51);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PanelImage = null;
            this.btnAdd.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnAdd.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnAdd.Size = new System.Drawing.Size(91, 22);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnClear.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnClear.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnClear.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnClear.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnClear.CaptionBottomLineWidth = 1;
            this.btnClear.CaptionCloseButtonControlLeft = 2;
            this.btnClear.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClear.CaptionCloseButtonTitle = "×";
            this.btnClear.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClear.CaptionHeight = 20;
            this.btnClear.CaptionLeft = 1;
            this.btnClear.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnClear.CaptionTitle = "重 置";
            this.btnClear.CaptionTitleLeft = 15;
            this.btnClear.CaptionTitleTop = 4;
            this.btnClear.CaptionTop = 1;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.IsBorderLine = true;
            this.btnClear.IsCaptionSingleColor = false;
            this.btnClear.IsOnlyCaption = true;
            this.btnClear.IsPanelImage = true;
            this.btnClear.IsUserButtonClose = false;
            this.btnClear.IsUserCaptionBottomLine = false;
            this.btnClear.IsUserSystemCloseButtonLeft = true;
            this.btnClear.Location = new System.Drawing.Point(105, 292);
            this.btnClear.Name = "btnClear";
            this.btnClear.PanelImage = null;
            this.btnClear.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnClear.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnClear.Size = new System.Drawing.Size(71, 22);
            this.btnClear.TabIndex = 19;
            this.btnClear.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            this.btnQuery.CaptionTitleLeft = 15;
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
            this.btnQuery.Location = new System.Drawing.Point(23, 292);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.PanelImage = null;
            this.btnQuery.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnQuery.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnQuery.Size = new System.Drawing.Size(71, 22);
            this.btnQuery.TabIndex = 18;
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
            this.cpStation.CaptionTitleLeft = 40;
            this.cpStation.CaptionTitleTop = 4;
            this.cpStation.CaptionTop = 1;
            this.cpStation.IsBorderLine = true;
            this.cpStation.IsCaptionSingleColor = false;
            this.cpStation.IsOnlyCaption = false;
            this.cpStation.IsPanelImage = false;
            this.cpStation.IsUserButtonClose = false;
            this.cpStation.IsUserCaptionBottomLine = true;
            this.cpStation.IsUserSystemCloseButtonLeft = true;
            this.cpStation.Location = new System.Drawing.Point(85, 565);
            this.cpStation.Name = "cpStation";
            this.cpStation.PanelImage = null;
            this.cpStation.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.cpStation.Size = new System.Drawing.Size(40, 23);
            this.cpStation.TabIndex = 2;
            this.cpStation.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sxpPanelGroup1);
            this.panel1.Controls.Add(this.cpAdd);
            this.panel1.Controls.Add(this.cpStation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 746);
            this.panel1.TabIndex = 36;
            // 
            // sxpPanelGroup1
            // 
            this.sxpPanelGroup1.AutoScroll = true;
            this.sxpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel2);
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel1);
            this.sxpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sxpPanelGroup1.Location = new System.Drawing.Point(0, 0);
            this.sxpPanelGroup1.Name = "sxpPanelGroup1";
            this.sxpPanelGroup1.PanelGradient = ((Wilson.Controls.XPPanel.Colors.GradientColor)(resources.GetObject("sxpPanelGroup1.PanelGradient")));
            this.sxpPanelGroup1.Size = new System.Drawing.Size(216, 746);
            this.sxpPanelGroup1.TabIndex = 41;
            // 
            // sxpPanel2
            // 
            this.sxpPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sxpPanel2.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanel2.Caption = "补考勤";
            this.sxpPanel2.CaptionCornerType = ((Wilson.Controls.XPPanel.Enums.CornerType)((Wilson.Controls.XPPanel.Enums.CornerType.TopLeft | Wilson.Controls.XPPanel.Enums.CornerType.TopRight)));
            this.sxpPanel2.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.sxpPanel2.CaptionGradient.Start = System.Drawing.Color.White;
            this.sxpPanel2.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel2.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sxpPanel2.Controls.Add(this.btnAdd);
            this.sxpPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.sxpPanel2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sxpPanel2.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.sxpPanel2.ImageItems.ImageSet = null;
            this.sxpPanel2.ImageItems.Normal = -1;
            this.sxpPanel2.Location = new System.Drawing.Point(8, 348);
            this.sxpPanel2.Name = "sxpPanel2";
            this.sxpPanel2.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel2.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel2.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel2.Size = new System.Drawing.Size(200, 100);
            this.sxpPanel2.TabIndex = 41;
            this.sxpPanel2.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel2.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel2.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel2.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
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
            this.sxpPanel1.Controls.Add(this.lblStartTime);
            this.sxpPanel1.Controls.Add(this.lblBlock);
            this.sxpPanel1.Controls.Add(this.txtBlock);
            this.sxpPanel1.Controls.Add(this.dtpStartTime);
            this.sxpPanel1.Controls.Add(this.lblDept);
            this.sxpPanel1.Controls.Add(this.btnClear);
            this.sxpPanel1.Controls.Add(this.txtUserName);
            this.sxpPanel1.Controls.Add(this.lblEndTime);
            this.sxpPanel1.Controls.Add(this.ddlDept);
            this.sxpPanel1.Controls.Add(this.ddlTimerInterval);
            this.sxpPanel1.Controls.Add(this.label1);
            this.sxpPanel1.Controls.Add(this.label2);
            this.sxpPanel1.Controls.Add(this.lblUserName);
            this.sxpPanel1.Controls.Add(this.dtpEndTime);
            this.sxpPanel1.Controls.Add(this.ddlClass);
            this.sxpPanel1.Controls.Add(this.btnQuery);
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
            this.sxpPanel1.Size = new System.Drawing.Size(200, 332);
            this.sxpPanel1.TabIndex = 41;
            this.sxpPanel1.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel1.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel1.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel1.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // cpAdd
            // 
            this.cpAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpAdd.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpAdd.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpAdd.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpAdd.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpAdd.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpAdd.CaptionBottomLineWidth = 1;
            this.cpAdd.CaptionCloseButtonControlLeft = 2;
            this.cpAdd.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpAdd.CaptionCloseButtonTitle = "×";
            this.cpAdd.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpAdd.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cpAdd.CaptionHeight = 20;
            this.cpAdd.CaptionLeft = 1;
            this.cpAdd.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpAdd.CaptionTitle = "补考勤";
            this.cpAdd.CaptionTitleLeft = 50;
            this.cpAdd.CaptionTitleTop = 4;
            this.cpAdd.CaptionTop = 1;
            this.cpAdd.IsBorderLine = true;
            this.cpAdd.IsCaptionSingleColor = false;
            this.cpAdd.IsOnlyCaption = false;
            this.cpAdd.IsPanelImage = false;
            this.cpAdd.IsUserButtonClose = false;
            this.cpAdd.IsUserCaptionBottomLine = true;
            this.cpAdd.IsUserSystemCloseButtonLeft = true;
            this.cpAdd.Location = new System.Drawing.Point(85, 594);
            this.cpAdd.Name = "cpAdd";
            this.cpAdd.PanelImage = null;
            this.cpAdd.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.cpAdd.Size = new System.Drawing.Size(40, 22);
            this.cpAdd.TabIndex = 21;
            this.cpAdd.Visible = false;
            // 
            // cpAll
            // 
            this.cpAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpAll.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpAll.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpAll.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpAll.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpAll.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpAll.CaptionBottomLineWidth = 1;
            this.cpAll.CaptionCloseButtonControlLeft = 2;
            this.cpAll.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpAll.CaptionCloseButtonTitle = "×";
            this.cpAll.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpAll.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cpAll.CaptionHeight = 30;
            this.cpAll.CaptionLeft = 1;
            this.cpAll.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpAll.CaptionTitle = "";
            this.cpAll.CaptionTitleLeft = 8;
            this.cpAll.CaptionTitleTop = 4;
            this.cpAll.CaptionTop = 1;
            this.cpAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.cpAll.IsBorderLine = true;
            this.cpAll.IsCaptionSingleColor = false;
            this.cpAll.IsOnlyCaption = false;
            this.cpAll.IsPanelImage = false;
            this.cpAll.IsUserButtonClose = false;
            this.cpAll.IsUserCaptionBottomLine = true;
            this.cpAll.IsUserSystemCloseButtonLeft = true;
            this.cpAll.Location = new System.Drawing.Point(0, 0);
            this.cpAll.Name = "cpAll";
            this.cpAll.PanelImage = null;
            this.cpAll.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.cpAll.Size = new System.Drawing.Size(812, 30);
            this.cpAll.TabIndex = 37;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnJump);
            this.panel2.Controls.Add(this.btnRowsCount);
            this.panel2.Controls.Add(this.ddlRowsSet);
            this.panel2.Controls.Add(this.txtJump);
            this.panel2.Controls.Add(this.btnPreview);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.btnPageIndexAndPageCount);
            this.panel2.Controls.Add(this.cpAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(216, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(812, 31);
            this.panel2.TabIndex = 38;
            // 
            // dgrd
            // 
            this.dgrd.AllowUserToAddRows = false;
            this.dgrd.AllowUserToDeleteRows = false;
            this.dgrd.AllowUserToOrderColumns = true;
            this.dgrd.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgrd.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrd.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.dgrd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(251)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgrd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cellEdit,
            this.cellDelete});
            this.dgrd.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.BlueStyle;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrd.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrd.EnableHeadersVisualStyles = false;
            this.dgrd.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(191)))), ((int)(((byte)(219)))));
            this.dgrd.Location = new System.Drawing.Point(216, 31);
            this.dgrd.Name = "dgrd";
            this.dgrd.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrd.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrd.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dgrd.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgrd.RowTemplate.Height = 23;
            this.dgrd.Size = new System.Drawing.Size(812, 715);
            this.dgrd.TabIndex = 40;
            this.dgrd.VerticalScrollBarMax = 1;
            this.dgrd.VerticalScrollBarValue = 0;
            this.dgrd.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrd_CellClick);
            // 
            // cellEdit
            // 
            this.cellEdit.HeaderText = "修改";
            this.cellEdit.Name = "cellEdit";
            this.cellEdit.ReadOnly = true;
            this.cellEdit.Text = "修改";
            this.cellEdit.UseColumnTextForLinkValue = true;
            // 
            // cellDelete
            // 
            this.cellDelete.HeaderText = "删除";
            this.cellDelete.Name = "cellDelete";
            this.cellDelete.ReadOnly = true;
            this.cellDelete.Text = "删除";
            this.cellDelete.UseColumnTextForLinkValue = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AddHistoryAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.gbModify);
            this.Controls.Add(this.cpModify);
            this.Controls.Add(this.dgrd);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblPageIndex);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddHistoryAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "历史考勤补单";
            this.Text = "历史考勤补单";
            this.Load += new System.EventHandler(this.AddHistoryAttendance_Load);
            this.gbModify.ResumeLayout(false);
            this.gbModify.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).EndInit();
            this.sxpPanelGroup1.ResumeLayout(false);
            this.sxpPanel2.ResumeLayout(false);
            this.sxpPanel1.ResumeLayout(false);
            this.sxpPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KJ128WindowsLibrary.CaptionPanel cpStation;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblBlock;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.ComboBox ddlDept;
        private System.Windows.Forms.ComboBox ddlClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlTimerInterval;
        private System.Windows.Forms.Label label2;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnQuery;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnClear;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnAdd;
        private KJ128WindowsLibrary.CaptionPanel cpModify;
        private System.Windows.Forms.GroupBox gbModify;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlClassAdd;
        private System.Windows.Forms.ComboBox ddlTimerIntervalAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlDeptAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpEndTimeAdd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpBeginTimeAdd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpDataAttendanceAdd;
        private System.Windows.Forms.Label label10;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnModifyAndAdd;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnReturn;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.ComboBox ddlRowsSet;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnRowsCount;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnPreview;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnNext;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnPageIndexAndPageCount;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnJump;
        private System.Windows.Forms.Label lblPageIndex;
        private System.Windows.Forms.Panel panel1;
        private KJ128WindowsLibrary.CaptionPanel cpAll;
        private System.Windows.Forms.Panel panel2;
        private KJ128WindowsLibrary.CaptionPanel cpAdd;
        private DataGridViewKJ128 dgrd;
        private System.Windows.Forms.DataGridViewLinkColumn cellEdit;
        private System.Windows.Forms.DataGridViewLinkColumn cellDelete;
        private Wilson.Controls.XPPanel.Images.SXPPanelGroup sxpPanelGroup1;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel2;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel1;
        private Shine.ShineTextBox txtUserName;
        private Shine.ShineTextBox txtBlock;
        private Shine.ShineTextBox txtUserNameAdd;
        private Shine.ShineTextBox txtBlockAdd;
        private Shine.ShineTextBox txtRemarkAdd;
        private Shine.ShineTextBox txtJump;
        private System.Windows.Forms.Timer timer1;
    }
}