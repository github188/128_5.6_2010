namespace KJ128NInterfaceShow
{
    partial class FrmTimerInterval
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblErr = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new Shine.ShineTextBox();
            this.txtShortName = new Shine.ShineTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.cpModify = new KJ128WindowsLibrary.CaptionPanel();
            this.btnAdd = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.captionPanel1 = new KJ128WindowsLibrary.CaptionPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.cbBeginWorkType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBeginWorkFront = new KJ128N.Command.TxtNumber();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBeginWorkAfter = new KJ128N.Command.TxtNumber();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbEndWorkType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEndWorkAfter = new KJ128N.Command.TxtNumber();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtEndWorkFront = new KJ128N.Command.TxtNumber();
            this.label17 = new System.Windows.Forms.Label();
            this.btnModify = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnCancel = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cbBeginHour = new System.Windows.Forms.ComboBox();
            this.cbBeginMinute = new System.Windows.Forms.ComboBox();
            this.cbEndHour = new System.Windows.Forms.ComboBox();
            this.cbEndMinute = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.DataAttendanceType = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bcpRef = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.dgrd = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.cellEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cellDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).BeginInit();
            this.SuspendLayout();
            // 
            // lblErr
            // 
            this.lblErr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblErr.AutoSize = true;
            this.lblErr.Location = new System.Drawing.Point(249, 441);
            this.lblErr.Name = "lblErr";
            this.lblErr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblErr.Size = new System.Drawing.Size(0, 12);
            this.lblErr.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "时段全称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "时段简称：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(225, 79);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(153, 21);
            this.txtName.TabIndex = 7;
            this.txtName.TextType = Shine.TextType.WithOutChar;
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(225, 107);
            this.txtShortName.MaxLength = 10;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(153, 21);
            this.txtShortName.TabIndex = 8;
            this.txtShortName.TextType = Shine.TextType.WithOutChar;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "所属班制：";
            // 
            // cbClass
            // 
            this.cbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(225, 138);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(153, 20);
            this.cbClass.TabIndex = 10;
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
            this.cpModify.CaptionTitle = "";
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
            this.cpModify.Location = new System.Drawing.Point(30, 52);
            this.cpModify.Name = "cpModify";
            this.cpModify.PanelImage = null;
            this.cpModify.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.cpModify.Size = new System.Drawing.Size(521, 365);
            this.cpModify.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnAdd.CaptionTitle = "添 加";
            this.btnAdd.CaptionTitleLeft = 22;
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
            this.btnAdd.Location = new System.Drawing.Point(506, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PanelImage = null;
            this.btnAdd.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnAdd.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnAdd.Size = new System.Drawing.Size(80, 22);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.captionPanel1.CaptionHeight = 20;
            this.captionPanel1.CaptionLeft = 1;
            this.captionPanel1.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.captionPanel1.CaptionTitle = "";
            this.captionPanel1.CaptionTitleLeft = 8;
            this.captionPanel1.CaptionTitleTop = 4;
            this.captionPanel1.CaptionTop = 1;
            this.captionPanel1.IsBorderLine = true;
            this.captionPanel1.IsCaptionSingleColor = false;
            this.captionPanel1.IsOnlyCaption = false;
            this.captionPanel1.IsPanelImage = false;
            this.captionPanel1.IsUserButtonClose = false;
            this.captionPanel1.IsUserCaptionBottomLine = true;
            this.captionPanel1.IsUserSystemCloseButtonLeft = true;
            this.captionPanel1.Location = new System.Drawing.Point(3, 1);
            this.captionPanel1.Name = "captionPanel1";
            this.captionPanel1.PanelImage = null;
            this.captionPanel1.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.captionPanel1.Size = new System.Drawing.Size(586, 437);
            this.captionPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "工作开始时间：";
            // 
            // cbBeginWorkType
            // 
            this.cbBeginWorkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBeginWorkType.FormattingEnabled = true;
            this.cbBeginWorkType.Location = new System.Drawing.Point(225, 167);
            this.cbBeginWorkType.Name = "cbBeginWorkType";
            this.cbBeginWorkType.Size = new System.Drawing.Size(83, 20);
            this.cbBeginWorkType.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(371, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "时";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(449, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "分";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(159, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "考勤提前：";
            // 
            // txtBeginWorkFront
            // 
            this.txtBeginWorkFront.Location = new System.Drawing.Point(226, 226);
            this.txtBeginWorkFront.MaxLength = 5;
            this.txtBeginWorkFront.Name = "txtBeginWorkFront";
            this.txtBeginWorkFront.Size = new System.Drawing.Size(61, 21);
            this.txtBeginWorkFront.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(297, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "分钟开始";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(147, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "考勤开始后：";
            // 
            // txtBeginWorkAfter
            // 
            this.txtBeginWorkAfter.Location = new System.Drawing.Point(226, 256);
            this.txtBeginWorkAfter.MaxLength = 5;
            this.txtBeginWorkAfter.Name = "txtBeginWorkAfter";
            this.txtBeginWorkAfter.Size = new System.Drawing.Size(61, 21);
            this.txtBeginWorkAfter.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(297, 259);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "分钟后算迟到";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(136, 290);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 23;
            this.label11.Text = "工作结束时间：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(450, 289);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 28;
            this.label12.Text = "分";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(372, 290);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 27;
            this.label13.Text = "时";
            // 
            // cbEndWorkType
            // 
            this.cbEndWorkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndWorkType.FormattingEnabled = true;
            this.cbEndWorkType.Location = new System.Drawing.Point(226, 286);
            this.cbEndWorkType.Name = "cbEndWorkType";
            this.cbEndWorkType.Size = new System.Drawing.Size(83, 20);
            this.cbEndWorkType.TabIndex = 24;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(298, 350);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 31;
            this.label14.Text = "分钟后结束";
            // 
            // txtEndWorkAfter
            // 
            this.txtEndWorkAfter.Location = new System.Drawing.Point(227, 346);
            this.txtEndWorkAfter.MaxLength = 5;
            this.txtEndWorkAfter.Name = "txtEndWorkAfter";
            this.txtEndWorkAfter.Size = new System.Drawing.Size(61, 21);
            this.txtEndWorkAfter.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(180, 350);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 29;
            this.label15.Text = "考勤：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(297, 319);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 12);
            this.label16.TabIndex = 34;
            this.label16.Text = "分钟前算早退";
            // 
            // txtEndWorkFront
            // 
            this.txtEndWorkFront.Location = new System.Drawing.Point(226, 316);
            this.txtEndWorkFront.MaxLength = 5;
            this.txtEndWorkFront.Name = "txtEndWorkFront";
            this.txtEndWorkFront.Size = new System.Drawing.Size(61, 21);
            this.txtEndWorkFront.TabIndex = 33;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(147, 321);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 12);
            this.label17.TabIndex = 32;
            this.label17.Text = "考勤结束前：";
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
            this.btnModify.CaptionTitle = "修 改";
            this.btnModify.CaptionTitleLeft = 15;
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
            this.btnModify.Location = new System.Drawing.Point(189, 381);
            this.btnModify.Name = "btnModify";
            this.btnModify.PanelImage = null;
            this.btnModify.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnModify.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnModify.Size = new System.Drawing.Size(68, 22);
            this.btnModify.TabIndex = 35;
            this.btnModify.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnCancel.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnCancel.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnCancel.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnCancel.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnCancel.CaptionBottomLineWidth = 1;
            this.btnCancel.CaptionCloseButtonControlLeft = 2;
            this.btnCancel.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.CaptionCloseButtonTitle = "×";
            this.btnCancel.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.CaptionHeight = 20;
            this.btnCancel.CaptionLeft = 1;
            this.btnCancel.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancel.CaptionTitle = "返 回";
            this.btnCancel.CaptionTitleLeft = 15;
            this.btnCancel.CaptionTitleTop = 4;
            this.btnCancel.CaptionTop = 1;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.IsBorderLine = true;
            this.btnCancel.IsCaptionSingleColor = false;
            this.btnCancel.IsOnlyCaption = true;
            this.btnCancel.IsPanelImage = true;
            this.btnCancel.IsUserButtonClose = false;
            this.btnCancel.IsUserCaptionBottomLine = false;
            this.btnCancel.IsUserSystemCloseButtonLeft = true;
            this.btnCancel.Location = new System.Drawing.Point(282, 381);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PanelImage = null;
            this.btnCancel.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnCancel.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnCancel.Size = new System.Drawing.Size(68, 22);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbBeginHour
            // 
            this.cbBeginHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBeginHour.FormattingEnabled = true;
            this.cbBeginHour.Location = new System.Drawing.Point(314, 167);
            this.cbBeginHour.Name = "cbBeginHour";
            this.cbBeginHour.Size = new System.Drawing.Size(53, 20);
            this.cbBeginHour.TabIndex = 37;
            // 
            // cbBeginMinute
            // 
            this.cbBeginMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBeginMinute.FormattingEnabled = true;
            this.cbBeginMinute.Location = new System.Drawing.Point(390, 167);
            this.cbBeginMinute.Name = "cbBeginMinute";
            this.cbBeginMinute.Size = new System.Drawing.Size(53, 20);
            this.cbBeginMinute.TabIndex = 38;
            // 
            // cbEndHour
            // 
            this.cbEndHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndHour.FormattingEnabled = true;
            this.cbEndHour.Location = new System.Drawing.Point(314, 286);
            this.cbEndHour.Name = "cbEndHour";
            this.cbEndHour.Size = new System.Drawing.Size(53, 20);
            this.cbEndHour.TabIndex = 39;
            // 
            // cbEndMinute
            // 
            this.cbEndMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndMinute.FormattingEnabled = true;
            this.cbEndMinute.Location = new System.Drawing.Point(391, 286);
            this.cbEndMinute.Name = "cbEndMinute";
            this.cbEndMinute.Size = new System.Drawing.Size(53, 20);
            this.cbEndMinute.TabIndex = 40;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(385, 82);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(11, 12);
            this.label18.TabIndex = 41;
            this.label18.Text = "*";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(385, 111);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(11, 12);
            this.label19.TabIndex = 42;
            this.label19.Text = "*";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(355, 227);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(11, 12);
            this.label20.TabIndex = 43;
            this.label20.Text = "*";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(380, 257);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(11, 12);
            this.label21.TabIndex = 44;
            this.label21.Text = "*";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(376, 318);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(11, 12);
            this.label22.TabIndex = 45;
            this.label22.Text = "*";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(369, 349);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(11, 12);
            this.label23.TabIndex = 46;
            this.label23.Text = "*";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(532, 218);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 12);
            this.lblID.TabIndex = 47;
            this.lblID.Visible = false;
            // 
            // DataAttendanceType
            // 
            this.DataAttendanceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataAttendanceType.FormattingEnabled = true;
            this.DataAttendanceType.Location = new System.Drawing.Point(224, 197);
            this.DataAttendanceType.Name = "DataAttendanceType";
            this.DataAttendanceType.Size = new System.Drawing.Size(83, 20);
            this.DataAttendanceType.TabIndex = 49;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(155, 201);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(65, 12);
            this.label24.TabIndex = 48;
            this.label24.Text = "记工日期：";
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bcpRef
            // 
            this.bcpRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bcpRef.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpRef.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpRef.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpRef.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.bcpRef.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.bcpRef.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpRef.CaptionBottomLineWidth = 1;
            this.bcpRef.CaptionCloseButtonControlLeft = 2;
            this.bcpRef.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpRef.CaptionCloseButtonTitle = "×";
            this.bcpRef.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpRef.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bcpRef.CaptionHeight = 20;
            this.bcpRef.CaptionLeft = 1;
            this.bcpRef.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpRef.CaptionTitle = "刷 新";
            this.bcpRef.CaptionTitleLeft = 23;
            this.bcpRef.CaptionTitleTop = 4;
            this.bcpRef.CaptionTop = 1;
            this.bcpRef.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcpRef.IsBorderLine = true;
            this.bcpRef.IsCaptionSingleColor = false;
            this.bcpRef.IsOnlyCaption = true;
            this.bcpRef.IsPanelImage = true;
            this.bcpRef.IsUserButtonClose = false;
            this.bcpRef.IsUserCaptionBottomLine = false;
            this.bcpRef.IsUserSystemCloseButtonLeft = true;
            this.bcpRef.Location = new System.Drawing.Point(425, 1);
            this.bcpRef.Name = "bcpRef";
            this.bcpRef.PanelImage = null;
            this.bcpRef.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bcpRef.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpRef.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpRef.Size = new System.Drawing.Size(79, 22);
            this.bcpRef.TabIndex = 51;
            this.bcpRef.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpRef.Click += new System.EventHandler(this.bcpRef_Click);
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
            this.dgrd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cellEdit,
            this.cellDelete});
            this.dgrd.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.BlueStyle;
            this.dgrd.EnableHeadersVisualStyles = false;
            this.dgrd.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(191)))), ((int)(((byte)(219)))));
            this.dgrd.Location = new System.Drawing.Point(4, 24);
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
            this.dgrd.Size = new System.Drawing.Size(583, 414);
            this.dgrd.TabIndex = 50;
            this.dgrd.VerticalScrollBarMax = 1;
            this.dgrd.VerticalScrollBarValue = 0;
            this.dgrd.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrd_CellContentClick);
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
            // FrmTimerInterval
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(590, 458);
            this.Controls.Add(this.bcpRef);
            this.Controls.Add(this.DataAttendanceType);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cbEndMinute);
            this.Controls.Add(this.cbEndHour);
            this.Controls.Add(this.cbBeginMinute);
            this.Controls.Add(this.cbBeginHour);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtEndWorkFront);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtEndWorkAfter);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbEndWorkType);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtBeginWorkAfter);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBeginWorkFront);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbBeginWorkType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbClass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtShortName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cpModify);
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgrd);
            this.Controls.Add(this.captionPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTimerInterval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "考勤时段设置";
            this.Text = "考勤时段设置";
            this.Load += new System.EventHandler(this.FrmTimerInterval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KJ128WindowsLibrary.CaptionPanel captionPanel1;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnAdd;
        private System.Windows.Forms.Label lblErr;
        private KJ128WindowsLibrary.CaptionPanel cpModify;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbBeginWorkType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbEndWorkType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnModify;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnCancel;
        private System.Windows.Forms.ComboBox cbBeginHour;
        private System.Windows.Forms.ComboBox cbBeginMinute;
        private System.Windows.Forms.ComboBox cbEndHour;
        private System.Windows.Forms.ComboBox cbEndMinute;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.ComboBox DataAttendanceType;
        private System.Windows.Forms.Label label24;
        private DataGridViewKJ128 dgrd;
        private System.Windows.Forms.DataGridViewLinkColumn cellEdit;
        private System.Windows.Forms.DataGridViewLinkColumn cellDelete;
        private KJ128N.Command.TxtNumber txtBeginWorkFront;
        private KJ128N.Command.TxtNumber txtBeginWorkAfter;
        private KJ128N.Command.TxtNumber txtEndWorkAfter;
        private KJ128N.Command.TxtNumber txtEndWorkFront;
        private System.Windows.Forms.Timer timer1;
        private Shine.ShineTextBox txtName;
        private Shine.ShineTextBox txtShortName;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpRef;


    }
}