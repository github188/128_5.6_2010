﻿namespace KJ128NInterfaceShow
{
    partial class RealTimeAttendanceQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RealTimeAttendanceQuery));
            this.lblErr = new System.Windows.Forms.Label();
            this.cbOutStation = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRemark = new Shine.ShineTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpDataAttendanceAdd = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpEndTimeAdd = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpBeginTimeAdd = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnReturn = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnModify = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.gbModify = new System.Windows.Forms.GroupBox();
            this.ddlDeptAdd = new System.Windows.Forms.ComboBox();
            this.txtUserNameAdd = new Shine.ShineTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBlockAdd = new KJ128N.Command.TxtNumber();// Shine.ShineTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ddlTimerIntervalAdd = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ddlClassAdd = new System.Windows.Forms.ComboBox();
            this.buttonCaptionPanel2 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.txtBlock = new KJ128N.Command.TxtNumber();// Shine.ShineTextBox();
            this.txtUserName = new Shine.ShineTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlTimerInterval = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlClass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlDept = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtJump = new Shine.ShineTextBox();
            this.btnPageIndexAndPageCount = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnNext = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnPreview = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnRowsCount = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.ddlRowsSet = new System.Windows.Forms.ComboBox();
            this.btnReset = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnQuery = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cpStation = new KJ128WindowsLibrary.CaptionPanel();
            this.cpModify = new KJ128WindowsLibrary.CaptionPanel();
            this.captionPanel1 = new KJ128WindowsLibrary.CaptionPanel();
            this.dgrd = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.cpToExcel = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sxpPanelGroup1 = new Wilson.Controls.XPPanel.Images.SXPPanelGroup();
            this.sxpPanel1 = new Wilson.Controls.XPPanel.SXPPanel();
            this.gbModify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).BeginInit();
            this.sxpPanelGroup1.SuspendLayout();
            this.sxpPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblErr
            // 
            this.lblErr.AutoEllipsis = true;
            this.lblErr.AutoSize = true;
            this.lblErr.Location = new System.Drawing.Point(518, 568);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(0, 12);
            this.lblErr.TabIndex = 64;
            // 
            // cbOutStation
            // 
            this.cbOutStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutStation.FormattingEnabled = true;
            this.cbOutStation.Location = new System.Drawing.Point(102, 256);
            this.cbOutStation.Name = "cbOutStation";
            this.cbOutStation.Size = new System.Drawing.Size(162, 20);
            this.cbOutStation.TabIndex = 19;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(45, 259);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 18;
            this.label15.Text = "出井分站:";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(103, 287);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(162, 57);
            this.txtRemark.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(69, 294);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 12);
            this.label14.TabIndex = 16;
            this.label14.Text = "备注:";
            // 
            // dtpDataAttendanceAdd
            // 
            this.dtpDataAttendanceAdd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpDataAttendanceAdd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataAttendanceAdd.Location = new System.Drawing.Point(103, 221);
            this.dtpDataAttendanceAdd.Name = "dtpDataAttendanceAdd";
            this.dtpDataAttendanceAdd.Size = new System.Drawing.Size(162, 21);
            this.dtpDataAttendanceAdd.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(43, 227);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 14;
            this.label13.Text = "记工日期:";
            // 
            // dtpEndTimeAdd
            // 
            this.dtpEndTimeAdd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndTimeAdd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTimeAdd.Location = new System.Drawing.Point(102, 188);
            this.dtpEndTimeAdd.Name = "dtpEndTimeAdd";
            this.dtpEndTimeAdd.Size = new System.Drawing.Size(162, 21);
            this.dtpEndTimeAdd.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(42, 194);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 12;
            this.label12.Text = "下班时间:";
            // 
            // dtpBeginTimeAdd
            // 
            this.dtpBeginTimeAdd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBeginTimeAdd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBeginTimeAdd.Location = new System.Drawing.Point(102, 157);
            this.dtpBeginTimeAdd.Name = "dtpBeginTimeAdd";
            this.dtpBeginTimeAdd.Size = new System.Drawing.Size(162, 21);
            this.dtpBeginTimeAdd.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(42, 163);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "上班时间:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "所属部门:";
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
            this.btnReturn.CaptionTitleLeft = 22;
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
            this.btnReturn.Location = new System.Drawing.Point(631, 444);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.PanelImage = null;
            this.btnReturn.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnReturn.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnReturn.Size = new System.Drawing.Size(84, 22);
            this.btnReturn.TabIndex = 87;
            this.btnReturn.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModify.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnModify.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnModify.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnModify.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnModify.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnModify.CaptionBottomLineWidth = 1;
            this.btnModify.CaptionCloseButtonControlLeft = 2;
            this.btnModify.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnModify.CaptionCloseButtonTitle = "×";
            this.btnModify.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnModify.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnModify.CaptionHeight = 20;
            this.btnModify.CaptionLeft = 1;
            this.btnModify.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnModify.CaptionTitle = "补 单";
            this.btnModify.CaptionTitleLeft = 22;
            this.btnModify.CaptionTitleTop = 4;
            this.btnModify.CaptionTop = 1;
            this.btnModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModify.IsBorderLine = true;
            this.btnModify.IsCaptionSingleColor = false;
            this.btnModify.IsOnlyCaption = true;
            this.btnModify.IsPanelImage = true;
            this.btnModify.IsUserButtonClose = false;
            this.btnModify.IsUserCaptionBottomLine = false;
            this.btnModify.IsUserSystemCloseButtonLeft = true;
            this.btnModify.Location = new System.Drawing.Point(528, 444);
            this.btnModify.Name = "btnModify";
            this.btnModify.PanelImage = null;
            this.btnModify.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnModify.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnModify.Size = new System.Drawing.Size(84, 22);
            this.btnModify.TabIndex = 86;
            this.btnModify.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // gbModify
            // 
            this.gbModify.Controls.Add(this.cbOutStation);
            this.gbModify.Controls.Add(this.label15);
            this.gbModify.Controls.Add(this.txtRemark);
            this.gbModify.Controls.Add(this.label14);
            this.gbModify.Controls.Add(this.dtpDataAttendanceAdd);
            this.gbModify.Controls.Add(this.label13);
            this.gbModify.Controls.Add(this.dtpEndTimeAdd);
            this.gbModify.Controls.Add(this.label12);
            this.gbModify.Controls.Add(this.dtpBeginTimeAdd);
            this.gbModify.Controls.Add(this.label11);
            this.gbModify.Controls.Add(this.label10);
            this.gbModify.Controls.Add(this.ddlDeptAdd);
            this.gbModify.Controls.Add(this.txtUserNameAdd);
            this.gbModify.Controls.Add(this.label9);
            this.gbModify.Controls.Add(this.txtBlockAdd);
            this.gbModify.Controls.Add(this.label8);
            this.gbModify.Controls.Add(this.label7);
            this.gbModify.Controls.Add(this.ddlTimerIntervalAdd);
            this.gbModify.Controls.Add(this.label6);
            this.gbModify.Controls.Add(this.ddlClassAdd);
            this.gbModify.Location = new System.Drawing.Point(463, 72);
            this.gbModify.Name = "gbModify";
            this.gbModify.Size = new System.Drawing.Size(313, 357);
            this.gbModify.TabIndex = 85;
            this.gbModify.TabStop = false;
            // 
            // ddlDeptAdd
            // 
            this.ddlDeptAdd.Enabled = false;
            this.ddlDeptAdd.FormattingEnabled = true;
            this.ddlDeptAdd.Location = new System.Drawing.Point(102, 73);
            this.ddlDeptAdd.Name = "ddlDeptAdd";
            this.ddlDeptAdd.Size = new System.Drawing.Size(162, 20);
            this.ddlDeptAdd.TabIndex = 8;
            // 
            // txtUserNameAdd
            // 
            this.txtUserNameAdd.Enabled = false;
            this.txtUserNameAdd.Location = new System.Drawing.Point(102, 126);
            this.txtUserNameAdd.Name = "txtUserNameAdd";
            this.txtUserNameAdd.Size = new System.Drawing.Size(162, 21);
            this.txtUserNameAdd.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "员工姓名:";
            // 
            // txtBlockAdd
            // 
            this.txtBlockAdd.Enabled = false;
            this.txtBlockAdd.Location = new System.Drawing.Point(102, 99);
            this.txtBlockAdd.Name = "txtBlockAdd";
            this.txtBlockAdd.Size = new System.Drawing.Size(162, 21);
            this.txtBlockAdd.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "发码器编号:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "所在时段:";
            // 
            // ddlTimerIntervalAdd
            // 
            this.ddlTimerIntervalAdd.FormattingEnabled = true;
            this.ddlTimerIntervalAdd.Location = new System.Drawing.Point(102, 47);
            this.ddlTimerIntervalAdd.Name = "ddlTimerIntervalAdd";
            this.ddlTimerIntervalAdd.Size = new System.Drawing.Size(162, 20);
            this.ddlTimerIntervalAdd.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "所属班制:";
            // 
            // ddlClassAdd
            // 
            this.ddlClassAdd.FormattingEnabled = true;
            this.ddlClassAdd.Location = new System.Drawing.Point(102, 21);
            this.ddlClassAdd.Name = "ddlClassAdd";
            this.ddlClassAdd.Size = new System.Drawing.Size(162, 20);
            this.ddlClassAdd.TabIndex = 0;
            // 
            // buttonCaptionPanel2
            // 
            this.buttonCaptionPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.buttonCaptionPanel2.CaptionTitle = "跳转";
            this.buttonCaptionPanel2.CaptionTitleLeft = 20;
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
            this.buttonCaptionPanel2.Location = new System.Drawing.Point(862, 5);
            this.buttonCaptionPanel2.Name = "buttonCaptionPanel2";
            this.buttonCaptionPanel2.PanelImage = null;
            this.buttonCaptionPanel2.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.buttonCaptionPanel2.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.buttonCaptionPanel2.Size = new System.Drawing.Size(67, 22);
            this.buttonCaptionPanel2.TabIndex = 83;
            this.buttonCaptionPanel2.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.buttonCaptionPanel2.Click += new System.EventHandler(this.buttonCaptionPanel2_Click);
            // 
            // txtBlock
            // 
            this.txtBlock.Location = new System.Drawing.Point(78, 196);
            this.txtBlock.Name = "txtBlock";
            this.txtBlock.Size = new System.Drawing.Size(121, 20);
            this.txtBlock.TabIndex = 74;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(78, 152);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(121, 20);
            this.txtUserName.TabIndex = 72;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 71;
            this.label4.Text = "员工姓名:";
            // 
            // ddlTimerInterval
            // 
            this.ddlTimerInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTimerInterval.FormattingEnabled = true;
            this.ddlTimerInterval.Location = new System.Drawing.Point(78, 81);
            this.ddlTimerInterval.Name = "ddlTimerInterval";
            this.ddlTimerInterval.Size = new System.Drawing.Size(121, 20);
            this.ddlTimerInterval.TabIndex = 70;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "所属时段:";
            // 
            // ddlClass
            // 
            this.ddlClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlClass.FormattingEnabled = true;
            this.ddlClass.Location = new System.Drawing.Point(78, 42);
            this.ddlClass.Name = "ddlClass";
            this.ddlClass.Size = new System.Drawing.Size(121, 20);
            this.ddlClass.TabIndex = 68;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "所属班制:";
            // 
            // ddlDept
            // 
            this.ddlDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDept.FormattingEnabled = true;
            this.ddlDept.Location = new System.Drawing.Point(78, 117);
            this.ddlDept.Name = "ddlDept";
            this.ddlDept.Size = new System.Drawing.Size(121, 20);
            this.ddlDept.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "所属部门:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 73;
            this.label5.Text = "发码器编号:";
            // 
            // txtJump
            // 
            this.txtJump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJump.Location = new System.Drawing.Point(793, 6);
            this.txtJump.Name = "txtJump";
            this.txtJump.Size = new System.Drawing.Size(66, 21);
            this.txtJump.TabIndex = 82;
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
            this.btnPageIndexAndPageCount.CaptionTitleLeft = 15;
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
            this.btnPageIndexAndPageCount.Location = new System.Drawing.Point(706, 6);
            this.btnPageIndexAndPageCount.Name = "btnPageIndexAndPageCount";
            this.btnPageIndexAndPageCount.PanelImage = null;
            this.btnPageIndexAndPageCount.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.btnPageIndexAndPageCount.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.btnPageIndexAndPageCount.Size = new System.Drawing.Size(86, 22);
            this.btnPageIndexAndPageCount.TabIndex = 81;
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
            this.btnNext.CaptionTitleLeft = 20;
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
            this.btnNext.Location = new System.Drawing.Point(616, 6);
            this.btnNext.Name = "btnNext";
            this.btnNext.PanelImage = null;
            this.btnNext.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnNext.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnNext.Size = new System.Drawing.Size(88, 22);
            this.btnNext.TabIndex = 80;
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
            this.btnPreview.CaptionTitleLeft = 20;
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
            this.btnPreview.Location = new System.Drawing.Point(525, 6);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.PanelImage = null;
            this.btnPreview.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnPreview.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnPreview.Size = new System.Drawing.Size(88, 22);
            this.btnPreview.TabIndex = 79;
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
            this.btnRowsCount.CaptionTitleLeft = 2;
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
            this.btnRowsCount.Location = new System.Drawing.Point(399, 6);
            this.btnRowsCount.Name = "btnRowsCount";
            this.btnRowsCount.PanelImage = null;
            this.btnRowsCount.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.btnRowsCount.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.btnRowsCount.Size = new System.Drawing.Size(122, 22);
            this.btnRowsCount.TabIndex = 78;
            this.btnRowsCount.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // ddlRowsSet
            // 
            this.ddlRowsSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlRowsSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlRowsSet.FormattingEnabled = true;
            this.ddlRowsSet.Location = new System.Drawing.Point(275, 7);
            this.ddlRowsSet.Name = "ddlRowsSet";
            this.ddlRowsSet.Size = new System.Drawing.Size(121, 20);
            this.ddlRowsSet.TabIndex = 77;
            this.ddlRowsSet.SelectionChangeCommitted += new System.EventHandler(this.ddlRowsSet_SelectionChangeCommitted);
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
            this.btnReset.CaptionTitleLeft = 22;
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
            this.btnReset.Location = new System.Drawing.Point(110, 232);
            this.btnReset.Name = "btnReset";
            this.btnReset.PanelImage = null;
            this.btnReset.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnReset.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnReset.Size = new System.Drawing.Size(84, 22);
            this.btnReset.TabIndex = 76;
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
            this.btnQuery.Location = new System.Drawing.Point(18, 232);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.PanelImage = null;
            this.btnQuery.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnQuery.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnQuery.Size = new System.Drawing.Size(84, 22);
            this.btnQuery.TabIndex = 75;
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
            this.cpStation.CaptionTitleLeft = 50;
            this.cpStation.CaptionTitleTop = 4;
            this.cpStation.CaptionTop = 1;
            this.cpStation.IsBorderLine = true;
            this.cpStation.IsCaptionSingleColor = false;
            this.cpStation.IsOnlyCaption = false;
            this.cpStation.IsPanelImage = false;
            this.cpStation.IsUserButtonClose = false;
            this.cpStation.IsUserCaptionBottomLine = true;
            this.cpStation.IsUserSystemCloseButtonLeft = true;
            this.cpStation.Location = new System.Drawing.Point(29, 326);
            this.cpStation.Name = "cpStation";
            this.cpStation.PanelImage = null;
            this.cpStation.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.cpStation.Size = new System.Drawing.Size(56, 26);
            this.cpStation.TabIndex = 62;
            this.cpStation.Visible = false;
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
            this.cpModify.CaptionTitle = "实时补单";
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
            this.cpModify.Location = new System.Drawing.Point(403, 50);
            this.cpModify.Name = "cpModify";
            this.cpModify.PanelImage = null;
            this.cpModify.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.cpModify.Size = new System.Drawing.Size(429, 438);
            this.cpModify.TabIndex = 84;
            // 
            // captionPanel1
            // 
            this.captionPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.captionPanel1.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.captionPanel1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.captionPanel1.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.captionPanel1.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.captionPanel1.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.captionPanel1.CaptionBottomLineWidth = 1;
            this.captionPanel1.CaptionCloseButtonControlLeft = 2;
            this.captionPanel1.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.captionPanel1.CaptionCloseButtonTitle = "×";
            this.captionPanel1.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.captionPanel1.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.captionPanel1.CaptionHeight = 30;
            this.captionPanel1.CaptionLeft = 1;
            this.captionPanel1.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.captionPanel1.CaptionTitle = "";
            this.captionPanel1.CaptionTitleLeft = 8;
            this.captionPanel1.CaptionTitleTop = 4;
            this.captionPanel1.CaptionTop = 1;
            this.captionPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.captionPanel1.IsBorderLine = true;
            this.captionPanel1.IsCaptionSingleColor = false;
            this.captionPanel1.IsOnlyCaption = false;
            this.captionPanel1.IsPanelImage = false;
            this.captionPanel1.IsUserButtonClose = false;
            this.captionPanel1.IsUserCaptionBottomLine = true;
            this.captionPanel1.IsUserSystemCloseButtonLeft = true;
            this.captionPanel1.Location = new System.Drawing.Point(220, 0);
            this.captionPanel1.Name = "captionPanel1";
            this.captionPanel1.PanelImage = null;
            this.captionPanel1.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.captionPanel1.Size = new System.Drawing.Size(808, 33);
            this.captionPanel1.TabIndex = 61;
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
            this.dgrd.Location = new System.Drawing.Point(220, 33);
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
            this.dgrd.Size = new System.Drawing.Size(808, 618);
            this.dgrd.TabIndex = 63;
            this.dgrd.VerticalScrollBarMax = 1;
            this.dgrd.VerticalScrollBarValue = 0;
            // 
            // cpToExcel
            // 
            this.cpToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpToExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpToExcel.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpToExcel.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpToExcel.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.cpToExcel.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.cpToExcel.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpToExcel.CaptionBottomLineWidth = 1;
            this.cpToExcel.CaptionCloseButtonControlLeft = 2;
            this.cpToExcel.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpToExcel.CaptionCloseButtonTitle = "×";
            this.cpToExcel.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpToExcel.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cpToExcel.CaptionHeight = 20;
            this.cpToExcel.CaptionLeft = 1;
            this.cpToExcel.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpToExcel.CaptionTitle = " 打  印";
            this.cpToExcel.CaptionTitleLeft = 10;
            this.cpToExcel.CaptionTitleTop = 4;
            this.cpToExcel.CaptionTop = 1;
            this.cpToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cpToExcel.IsBorderLine = true;
            this.cpToExcel.IsCaptionSingleColor = false;
            this.cpToExcel.IsOnlyCaption = true;
            this.cpToExcel.IsPanelImage = true;
            this.cpToExcel.IsUserButtonClose = false;
            this.cpToExcel.IsUserCaptionBottomLine = false;
            this.cpToExcel.IsUserSystemCloseButtonLeft = true;
            this.cpToExcel.Location = new System.Drawing.Point(935, 4);
            this.cpToExcel.Name = "cpToExcel";
            this.cpToExcel.PanelImage = null;
            this.cpToExcel.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.cpToExcel.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.cpToExcel.Size = new System.Drawing.Size(84, 22);
            this.cpToExcel.TabIndex = 117;
            this.cpToExcel.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.cpToExcel.Click += new System.EventHandler(this.cpToExcel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sxpPanelGroup1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 651);
            this.panel1.TabIndex = 118;
            // 
            // sxpPanelGroup1
            // 
            this.sxpPanelGroup1.AutoScroll = true;
            this.sxpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel1);
            this.sxpPanelGroup1.Controls.Add(this.cpStation);
            this.sxpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sxpPanelGroup1.Location = new System.Drawing.Point(0, 0);
            this.sxpPanelGroup1.Name = "sxpPanelGroup1";
            this.sxpPanelGroup1.PanelGradient = ((Wilson.Controls.XPPanel.Colors.GradientColor)(resources.GetObject("sxpPanelGroup1.PanelGradient")));
            this.sxpPanelGroup1.Size = new System.Drawing.Size(220, 651);
            this.sxpPanelGroup1.TabIndex = 77;
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
            this.sxpPanel1.Controls.Add(this.label2);
            this.sxpPanel1.Controls.Add(this.ddlTimerInterval);
            this.sxpPanel1.Controls.Add(this.btnQuery);
            this.sxpPanel1.Controls.Add(this.label4);
            this.sxpPanel1.Controls.Add(this.btnReset);
            this.sxpPanel1.Controls.Add(this.label3);
            this.sxpPanel1.Controls.Add(this.label5);
            this.sxpPanel1.Controls.Add(this.txtUserName);
            this.sxpPanel1.Controls.Add(this.label1);
            this.sxpPanel1.Controls.Add(this.ddlClass);
            this.sxpPanel1.Controls.Add(this.ddlDept);
            this.sxpPanel1.Controls.Add(this.txtBlock);
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
            this.sxpPanel1.Size = new System.Drawing.Size(204, 271);
            this.sxpPanel1.TabIndex = 0;
            this.sxpPanel1.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel1.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel1.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel1.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // RealTimeAttendanceQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1028, 651);
            this.Controls.Add(this.cpToExcel);
            this.Controls.Add(this.buttonCaptionPanel2);
            this.Controls.Add(this.txtJump);
            this.Controls.Add(this.btnPageIndexAndPageCount);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnRowsCount);
            this.Controls.Add(this.ddlRowsSet);
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.gbModify);
            this.Controls.Add(this.cpModify);
            this.Controls.Add(this.dgrd);
            this.Controls.Add(this.captionPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "RealTimeAttendanceQuery";
            this.TabText = "实时人员班次查询";
            this.Text = "实时人员班次查询";
            this.Load += new System.EventHandler(this.RealTimeAttendanceQuery_Load);
            this.gbModify.ResumeLayout(false);
            this.gbModify.PerformLayout();
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

        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.ComboBox cbOutStation;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpDataAttendanceAdd;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpEndTimeAdd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpBeginTimeAdd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnReturn;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnModify;
        private System.Windows.Forms.GroupBox gbModify;
        private System.Windows.Forms.ComboBox ddlDeptAdd;
        private System.Windows.Forms.TextBox txtUserNameAdd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBlockAdd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ddlTimerIntervalAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlClassAdd;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel2;
        private System.Windows.Forms.TextBox txtBlock;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlTimerInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlDept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtJump;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnPageIndexAndPageCount;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnNext;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnPreview;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnRowsCount;
        private System.Windows.Forms.ComboBox ddlRowsSet;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnReset;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnQuery;
        private KJ128WindowsLibrary.CaptionPanel cpStation;
        private KJ128WindowsLibrary.CaptionPanel cpModify;
        private KJ128WindowsLibrary.CaptionPanel captionPanel1;
        private KJ128NInterfaceShow.DataGridViewKJ128 dgrd;
        private KJ128WindowsLibrary.ButtonCaptionPanel cpToExcel;
        private System.Windows.Forms.Panel panel1;
        private Wilson.Controls.XPPanel.Images.SXPPanelGroup sxpPanelGroup1;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel1;
    }
}