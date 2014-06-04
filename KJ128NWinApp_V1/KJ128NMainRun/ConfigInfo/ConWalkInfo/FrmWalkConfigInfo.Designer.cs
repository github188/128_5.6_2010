namespace KJ128NMainRun
{
    partial class FrmWalkConfigInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWalkConfigInfo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sxpPanelGroup1 = new Wilson.Controls.XPPanel.Images.SXPPanelGroup();
            this.sxpPanel1 = new Wilson.Controls.XPPanel.SXPPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodeSenderAddress = new Shine.ShineTextBox();
            this.txtEmpName = new Shine.ShineTextBox();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.cbdpt = new System.Windows.Forms.ComboBox();
            this.lblDep = new System.Windows.Forms.Label();
            this.bcpAddInfo = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.vspnlAdd = new KJ128WindowsLibrary.VSPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSec = new Shine.ShineTextBox();
            this.txtMin = new Shine.ShineTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHour = new Shine.ShineTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbMSH = new System.Windows.Forms.ComboBox();
            this.cbMS = new System.Windows.Forms.ComboBox();
            this.rbMB = new System.Windows.Forms.RadioButton();
            this.rbMA = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbLSH = new System.Windows.Forms.ComboBox();
            this.cbLS = new System.Windows.Forms.ComboBox();
            this.rbLB = new System.Windows.Forms.RadioButton();
            this.rbLA = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbFSH = new System.Windows.Forms.ComboBox();
            this.cbFS = new System.Windows.Forms.ComboBox();
            this.rbFB = new System.Windows.Forms.RadioButton();
            this.rbFA = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDept = new System.Windows.Forms.ComboBox();
            this.lblDept = new System.Windows.Forms.Label();
            this.cbEmp = new System.Windows.Forms.ComboBox();
            this.lblEmp = new System.Windows.Forms.Label();
            this.btnAddOrEdit = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.bcpAdd = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.dgvMain = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.captionPanel1 = new KJ128WindowsLibrary.CaptionPanel();
            this.bcpSelect = new KJ128WindowsLibrary.ButtonCaptionPanel();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).BeginInit();
            this.sxpPanelGroup1.SuspendLayout();
            this.sxpPanel1.SuspendLayout();
            this.vspnlAdd.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // sxpPanelGroup1
            // 
            this.sxpPanelGroup1.AutoScroll = true;
            this.sxpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel1);
            this.sxpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Left;
            this.sxpPanelGroup1.Location = new System.Drawing.Point(0, 0);
            this.sxpPanelGroup1.Name = "sxpPanelGroup1";
            this.sxpPanelGroup1.PanelGradient = ((Wilson.Controls.XPPanel.Colors.GradientColor)(resources.GetObject("sxpPanelGroup1.PanelGradient")));
            this.sxpPanelGroup1.Size = new System.Drawing.Size(220, 561);
            this.sxpPanelGroup1.TabIndex = 0;
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
            this.sxpPanel1.Controls.Add(this.bcpSelect);
            this.sxpPanel1.Controls.Add(this.label7);
            this.sxpPanel1.Controls.Add(this.txtCodeSenderAddress);
            this.sxpPanel1.Controls.Add(this.txtEmpName);
            this.sxpPanel1.Controls.Add(this.lblEmpName);
            this.sxpPanel1.Controls.Add(this.cbdpt);
            this.sxpPanel1.Controls.Add(this.lblDep);
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
            this.sxpPanel1.Size = new System.Drawing.Size(204, 150);
            this.sxpPanel1.TabIndex = 1;
            this.sxpPanel1.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel1.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel1.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel1.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 126;
            this.label7.Text = "标识卡编号：";
            // 
            // txtCodeSenderAddress
            // 
            this.txtCodeSenderAddress.Location = new System.Drawing.Point(91, 94);
            this.txtCodeSenderAddress.Name = "txtCodeSenderAddress";
            this.txtCodeSenderAddress.Size = new System.Drawing.Size(103, 20);
            this.txtCodeSenderAddress.TabIndex = 124;
            this.txtCodeSenderAddress.TextType = Shine.TextType.Number;
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(91, 66);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(103, 20);
            this.txtEmpName.TabIndex = 123;
            this.txtEmpName.TextType = Shine.TextType.WithOutChar;
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Location = new System.Drawing.Point(5, 71);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(46, 13);
            this.lblEmpName.TabIndex = 127;
            this.lblEmpName.Text = "姓名：";
            // 
            // cbdpt
            // 
            this.cbdpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbdpt.FormattingEnabled = true;
            this.cbdpt.Location = new System.Drawing.Point(91, 38);
            this.cbdpt.Name = "cbdpt";
            this.cbdpt.Size = new System.Drawing.Size(103, 20);
            this.cbdpt.TabIndex = 122;
            // 
            // lblDep
            // 
            this.lblDep.AutoSize = true;
            this.lblDep.Location = new System.Drawing.Point(4, 44);
            this.lblDep.Name = "lblDep";
            this.lblDep.Size = new System.Drawing.Size(46, 13);
            this.lblDep.TabIndex = 125;
            this.lblDep.Text = "部门：";
            // 
            // bcpAddInfo
            // 
            this.bcpAddInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bcpAddInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpAddInfo.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpAddInfo.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpAddInfo.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.bcpAddInfo.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.bcpAddInfo.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpAddInfo.CaptionBottomLineWidth = 1;
            this.bcpAddInfo.CaptionCloseButtonControlLeft = 2;
            this.bcpAddInfo.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpAddInfo.CaptionCloseButtonTitle = "×";
            this.bcpAddInfo.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpAddInfo.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bcpAddInfo.CaptionHeight = 20;
            this.bcpAddInfo.CaptionLeft = 1;
            this.bcpAddInfo.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpAddInfo.CaptionTitle = "增加信息";
            this.bcpAddInfo.CaptionTitleLeft = 8;
            this.bcpAddInfo.CaptionTitleTop = 4;
            this.bcpAddInfo.CaptionTop = 1;
            this.bcpAddInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcpAddInfo.IsBorderLine = true;
            this.bcpAddInfo.IsCaptionSingleColor = false;
            this.bcpAddInfo.IsOnlyCaption = true;
            this.bcpAddInfo.IsPanelImage = true;
            this.bcpAddInfo.IsUserButtonClose = false;
            this.bcpAddInfo.IsUserCaptionBottomLine = false;
            this.bcpAddInfo.IsUserSystemCloseButtonLeft = true;
            this.bcpAddInfo.Location = new System.Drawing.Point(833, 5);
            this.bcpAddInfo.Name = "bcpAddInfo";
            this.bcpAddInfo.PanelImage = null;
            this.bcpAddInfo.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.WindowsStyle;
            this.bcpAddInfo.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpAddInfo.Size = new System.Drawing.Size(69, 22);
            this.bcpAddInfo.TabIndex = 13;
            this.bcpAddInfo.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpAddInfo.Click += new System.EventHandler(this.bcpAddInfo_Click);
            // 
            // vspnlAdd
            // 
            this.vspnlAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.vspnlAdd.BackLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.vspnlAdd.BetweenControlCount = 2;
            this.vspnlAdd.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.vspnlAdd.BottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.vspnlAdd.Controls.Add(this.label9);
            this.vspnlAdd.Controls.Add(this.label6);
            this.vspnlAdd.Controls.Add(this.label3);
            this.vspnlAdd.Controls.Add(this.txtSec);
            this.vspnlAdd.Controls.Add(this.txtMin);
            this.vspnlAdd.Controls.Add(this.label10);
            this.vspnlAdd.Controls.Add(this.txtHour);
            this.vspnlAdd.Controls.Add(this.groupBox2);
            this.vspnlAdd.Controls.Add(this.groupBox3);
            this.vspnlAdd.Controls.Add(this.groupBox1);
            this.vspnlAdd.Controls.Add(this.cbDept);
            this.vspnlAdd.Controls.Add(this.lblDept);
            this.vspnlAdd.Controls.Add(this.cbEmp);
            this.vspnlAdd.Controls.Add(this.lblEmp);
            this.vspnlAdd.Controls.Add(this.btnAddOrEdit);
            this.vspnlAdd.Controls.Add(this.bcpAdd);
            this.vspnlAdd.HorizontalInterval = 8;
            this.vspnlAdd.IsBorderLine = true;
            this.vspnlAdd.IsBottomLineColor = false;
            this.vspnlAdd.IsCaptionSingleColor = true;
            this.vspnlAdd.IsDragModel = true;
            this.vspnlAdd.IsmiddleInterval = false;
            this.vspnlAdd.LayoutType = KJ128WindowsLibrary.VSPanelLayoutType.FreeLayoutType;
            this.vspnlAdd.LeftInterval = 0;
            this.vspnlAdd.LinearGradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.vspnlAdd.LinearGradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.vspnlAdd.Location = new System.Drawing.Point(255, 74);
            this.vspnlAdd.MiddleInterval = 80;
            this.vspnlAdd.Name = "vspnlAdd";
            this.vspnlAdd.RightInterval = 0;
            this.vspnlAdd.SetBackGroundStyle = KJ128WindowsLibrary.VsPaneBackGroundStyle.windowsStyle;
            this.vspnlAdd.Size = new System.Drawing.Size(576, 226);
            this.vspnlAdd.TabIndex = 12;
            this.vspnlAdd.TopInterval = 0;
            this.vspnlAdd.VerticalInterval = 8;
            this.vspnlAdd.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(545, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 45;
            this.label9.Text = "秒";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(470, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 44;
            this.label6.Text = "分";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(394, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 43;
            this.label3.Text = "时";
            // 
            // txtSec
            // 
            this.txtSec.Location = new System.Drawing.Point(492, 29);
            this.txtSec.Name = "txtSec";
            this.txtSec.Size = new System.Drawing.Size(48, 21);
            this.txtSec.TabIndex = 42;
            this.txtSec.Text = "0";
            this.txtSec.TextType = Shine.TextType.Number;
            this.txtSec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHour_KeyPress);
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(417, 29);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(48, 21);
            this.txtMin.TabIndex = 41;
            this.txtMin.Text = "0";
            this.txtMin.TextType = Shine.TextType.Number;
            this.txtMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHour_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(269, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 40;
            this.label10.Text = "行走时间：";
            // 
            // txtHour
            // 
            this.txtHour.Location = new System.Drawing.Point(340, 29);
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new System.Drawing.Size(48, 21);
            this.txtHour.TabIndex = 39;
            this.txtHour.Text = "0";
            this.txtHour.TextType = Shine.TextType.Number;
            this.txtHour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHour_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cbMSH);
            this.groupBox2.Controls.Add(this.cbMS);
            this.groupBox2.Controls.Add(this.rbMB);
            this.groupBox2.Controls.Add(this.rbMA);
            this.groupBox2.Location = new System.Drawing.Point(199, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 97);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "二";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 50;
            this.label11.Text = "传输分站";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 51;
            this.label12.Text = "读卡分站";
            // 
            // cbMSH
            // 
            this.cbMSH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMSH.FormattingEnabled = true;
            this.cbMSH.Location = new System.Drawing.Point(75, 40);
            this.cbMSH.Name = "cbMSH";
            this.cbMSH.Size = new System.Drawing.Size(94, 20);
            this.cbMSH.TabIndex = 49;
            // 
            // cbMS
            // 
            this.cbMS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMS.FormattingEnabled = true;
            this.cbMS.Location = new System.Drawing.Point(75, 14);
            this.cbMS.Name = "cbMS";
            this.cbMS.Size = new System.Drawing.Size(94, 20);
            this.cbMS.TabIndex = 48;
            this.cbMS.SelectedIndexChanged += new System.EventHandler(this.cbMS_SelectedIndexChanged);
            // 
            // rbMB
            // 
            this.rbMB.AutoSize = true;
            this.rbMB.Location = new System.Drawing.Point(116, 73);
            this.rbMB.Name = "rbMB";
            this.rbMB.Size = new System.Drawing.Size(53, 16);
            this.rbMB.TabIndex = 35;
            this.rbMB.Text = "天线B";
            this.rbMB.UseVisualStyleBackColor = true;
            // 
            // rbMA
            // 
            this.rbMA.AutoSize = true;
            this.rbMA.Checked = true;
            this.rbMA.Location = new System.Drawing.Point(12, 73);
            this.rbMA.Name = "rbMA";
            this.rbMA.Size = new System.Drawing.Size(53, 16);
            this.rbMA.TabIndex = 34;
            this.rbMA.TabStop = true;
            this.rbMA.Text = "天线A";
            this.rbMA.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbLSH);
            this.groupBox3.Controls.Add(this.cbLS);
            this.groupBox3.Controls.Add(this.rbLB);
            this.groupBox3.Controls.Add(this.rbLA);
            this.groupBox3.Location = new System.Drawing.Point(392, 90);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(174, 97);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "三";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 52;
            this.label4.Text = "传输分站";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 53;
            this.label5.Text = "读卡分站";
            // 
            // cbLSH
            // 
            this.cbLSH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLSH.FormattingEnabled = true;
            this.cbLSH.Location = new System.Drawing.Point(74, 40);
            this.cbLSH.Name = "cbLSH";
            this.cbLSH.Size = new System.Drawing.Size(89, 20);
            this.cbLSH.TabIndex = 49;
            // 
            // cbLS
            // 
            this.cbLS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLS.FormattingEnabled = true;
            this.cbLS.Location = new System.Drawing.Point(74, 14);
            this.cbLS.Name = "cbLS";
            this.cbLS.Size = new System.Drawing.Size(89, 20);
            this.cbLS.TabIndex = 48;
            this.cbLS.SelectedIndexChanged += new System.EventHandler(this.cbLS_SelectedIndexChanged);
            // 
            // rbLB
            // 
            this.rbLB.AutoSize = true;
            this.rbLB.Location = new System.Drawing.Point(110, 73);
            this.rbLB.Name = "rbLB";
            this.rbLB.Size = new System.Drawing.Size(53, 16);
            this.rbLB.TabIndex = 38;
            this.rbLB.Text = "天线B";
            this.rbLB.UseVisualStyleBackColor = true;
            // 
            // rbLA
            // 
            this.rbLA.AutoSize = true;
            this.rbLA.Checked = true;
            this.rbLA.Location = new System.Drawing.Point(14, 73);
            this.rbLA.Name = "rbLA";
            this.rbLA.Size = new System.Drawing.Size(53, 16);
            this.rbLA.TabIndex = 37;
            this.rbLA.TabStop = true;
            this.rbLA.Text = "天线A";
            this.rbLA.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbFSH);
            this.groupBox1.Controls.Add(this.cbFS);
            this.groupBox1.Controls.Add(this.rbFB);
            this.groupBox1.Controls.Add(this.rbFA);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 97);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "一";
            // 
            // cbFSH
            // 
            this.cbFSH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFSH.FormattingEnabled = true;
            this.cbFSH.Location = new System.Drawing.Point(76, 40);
            this.cbFSH.Name = "cbFSH";
            this.cbFSH.Size = new System.Drawing.Size(86, 20);
            this.cbFSH.TabIndex = 47;
            // 
            // cbFS
            // 
            this.cbFS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFS.FormattingEnabled = true;
            this.cbFS.Location = new System.Drawing.Point(76, 14);
            this.cbFS.Name = "cbFS";
            this.cbFS.Size = new System.Drawing.Size(86, 20);
            this.cbFS.TabIndex = 46;
            this.cbFS.SelectedIndexChanged += new System.EventHandler(this.cbFS_SelectedIndexChanged);
            // 
            // rbFB
            // 
            this.rbFB.AutoSize = true;
            this.rbFB.Location = new System.Drawing.Point(109, 73);
            this.rbFB.Name = "rbFB";
            this.rbFB.Size = new System.Drawing.Size(53, 16);
            this.rbFB.TabIndex = 33;
            this.rbFB.Text = "天线B";
            this.rbFB.UseVisualStyleBackColor = true;
            // 
            // rbFA
            // 
            this.rbFA.AutoSize = true;
            this.rbFA.Checked = true;
            this.rbFA.Location = new System.Drawing.Point(12, 73);
            this.rbFA.Name = "rbFA";
            this.rbFA.Size = new System.Drawing.Size(53, 16);
            this.rbFA.TabIndex = 32;
            this.rbFA.TabStop = true;
            this.rbFA.Text = "天线A";
            this.rbFA.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "传输分站";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "读卡分站";
            // 
            // cbDept
            // 
            this.cbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDept.FormattingEnabled = true;
            this.cbDept.Location = new System.Drawing.Point(89, 29);
            this.cbDept.Name = "cbDept";
            this.cbDept.Size = new System.Drawing.Size(131, 20);
            this.cbDept.TabIndex = 18;
            this.cbDept.SelectedIndexChanged += new System.EventHandler(this.cbDept_SelectedIndexChanged);
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Location = new System.Drawing.Point(18, 32);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(65, 12);
            this.lblDept.TabIndex = 17;
            this.lblDept.Text = "部门名称：";
            // 
            // cbEmp
            // 
            this.cbEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmp.FormattingEnabled = true;
            this.cbEmp.Location = new System.Drawing.Point(89, 57);
            this.cbEmp.Name = "cbEmp";
            this.cbEmp.Size = new System.Drawing.Size(132, 20);
            this.cbEmp.TabIndex = 14;
            // 
            // lblEmp
            // 
            this.lblEmp.AutoSize = true;
            this.lblEmp.Location = new System.Drawing.Point(18, 60);
            this.lblEmp.Name = "lblEmp";
            this.lblEmp.Size = new System.Drawing.Size(65, 12);
            this.lblEmp.TabIndex = 13;
            this.lblEmp.Text = "员工姓名：";
            // 
            // btnAddOrEdit
            // 
            this.btnAddOrEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddOrEdit.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnAddOrEdit.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnAddOrEdit.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnAddOrEdit.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnAddOrEdit.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnAddOrEdit.CaptionBottomLineWidth = 1;
            this.btnAddOrEdit.CaptionCloseButtonControlLeft = 2;
            this.btnAddOrEdit.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddOrEdit.CaptionCloseButtonTitle = "×";
            this.btnAddOrEdit.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddOrEdit.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAddOrEdit.CaptionHeight = 20;
            this.btnAddOrEdit.CaptionLeft = 1;
            this.btnAddOrEdit.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAddOrEdit.CaptionTitle = "Title";
            this.btnAddOrEdit.CaptionTitleLeft = 8;
            this.btnAddOrEdit.CaptionTitleTop = 4;
            this.btnAddOrEdit.CaptionTop = 1;
            this.btnAddOrEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddOrEdit.IsBorderLine = true;
            this.btnAddOrEdit.IsCaptionSingleColor = false;
            this.btnAddOrEdit.IsOnlyCaption = true;
            this.btnAddOrEdit.IsPanelImage = true;
            this.btnAddOrEdit.IsUserButtonClose = false;
            this.btnAddOrEdit.IsUserCaptionBottomLine = false;
            this.btnAddOrEdit.IsUserSystemCloseButtonLeft = true;
            this.btnAddOrEdit.Location = new System.Drawing.Point(502, 195);
            this.btnAddOrEdit.Name = "btnAddOrEdit";
            this.btnAddOrEdit.PanelImage = null;
            this.btnAddOrEdit.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnAddOrEdit.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnAddOrEdit.Size = new System.Drawing.Size(61, 22);
            this.btnAddOrEdit.TabIndex = 10;
            this.btnAddOrEdit.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnAddOrEdit.Click += new System.EventHandler(this.btnAddOrEdit_Click);
            // 
            // bcpAdd
            // 
            this.bcpAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpAdd.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.bcpAdd.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpAdd.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.bcpAdd.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.bcpAdd.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpAdd.CaptionBottomLineWidth = 1;
            this.bcpAdd.CaptionCloseButtonControlLeft = 2;
            this.bcpAdd.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpAdd.CaptionCloseButtonTitle = "×";
            this.bcpAdd.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpAdd.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bcpAdd.CaptionHeight = 20;
            this.bcpAdd.CaptionLeft = 1;
            this.bcpAdd.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpAdd.CaptionTitle = "增加信息";
            this.bcpAdd.CaptionTitleLeft = 8;
            this.bcpAdd.CaptionTitleTop = 4;
            this.bcpAdd.CaptionTop = 1;
            this.bcpAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.bcpAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bcpAdd.IsBorderLine = true;
            this.bcpAdd.IsCaptionSingleColor = false;
            this.bcpAdd.IsOnlyCaption = true;
            this.bcpAdd.IsPanelImage = true;
            this.bcpAdd.IsUserButtonClose = true;
            this.bcpAdd.IsUserCaptionBottomLine = true;
            this.bcpAdd.IsUserSystemCloseButtonLeft = true;
            this.bcpAdd.Location = new System.Drawing.Point(0, 0);
            this.bcpAdd.Name = "bcpAdd";
            this.bcpAdd.PanelImage = null;
            this.bcpAdd.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.bcpAdd.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.bcpAdd.Size = new System.Drawing.Size(576, 22);
            this.bcpAdd.TabIndex = 0;
            this.bcpAdd.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bcpAdd_MouseUp);
            this.bcpAdd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bcpAdd_MouseMove);
            this.bcpAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bcpAdd_MouseDown);
            this.bcpAdd.CloseButtonClick += new System.EventHandler(this.bcpAdd_CloseButtonClick);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvMain.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(251)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Delete});
            this.dgvMain.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.BlueStyle;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(154)))), ((int)(((byte)(198)))));
            this.dgvMain.Location = new System.Drawing.Point(220, 30);
            this.dgvMain.Name = "dgvMain";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMain.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dgvMain.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.Size = new System.Drawing.Size(685, 531);
            this.dgvMain.TabIndex = 2;
            this.dgvMain.VerticalScrollBarMax = 1;
            this.dgvMain.VerticalScrollBarValue = 0;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "修改";
            this.Edit.Name = "Edit";
            this.Edit.Text = "修改";
            this.Edit.Width = 34;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "删除";
            this.Delete.Name = "Delete";
            this.Delete.Text = "删除";
            this.Delete.Width = 34;
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
            this.captionPanel1.Size = new System.Drawing.Size(685, 30);
            this.captionPanel1.TabIndex = 1;
            // 
            // bcpSelect
            // 
            this.bcpSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpSelect.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpSelect.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpSelect.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.bcpSelect.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.bcpSelect.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpSelect.CaptionBottomLineWidth = 1;
            this.bcpSelect.CaptionCloseButtonControlLeft = 2;
            this.bcpSelect.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpSelect.CaptionCloseButtonTitle = "×";
            this.bcpSelect.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpSelect.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bcpSelect.CaptionHeight = 20;
            this.bcpSelect.CaptionLeft = 1;
            this.bcpSelect.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpSelect.CaptionTitle = "查 询";
            this.bcpSelect.CaptionTitleLeft = 8;
            this.bcpSelect.CaptionTitleTop = 4;
            this.bcpSelect.CaptionTop = 1;
            this.bcpSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcpSelect.IsBorderLine = true;
            this.bcpSelect.IsCaptionSingleColor = false;
            this.bcpSelect.IsOnlyCaption = true;
            this.bcpSelect.IsPanelImage = true;
            this.bcpSelect.IsUserButtonClose = false;
            this.bcpSelect.IsUserCaptionBottomLine = false;
            this.bcpSelect.IsUserSystemCloseButtonLeft = true;
            this.bcpSelect.Location = new System.Drawing.Point(134, 121);
            this.bcpSelect.Name = "bcpSelect";
            this.bcpSelect.PanelImage = null;
            this.bcpSelect.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpSelect.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpSelect.Size = new System.Drawing.Size(60, 22);
            this.bcpSelect.TabIndex = 128;
            this.bcpSelect.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpSelect.Click += new System.EventHandler(this.bcpSelect_Click);
            // 
            // FrmWalkConfigInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 561);
            this.Controls.Add(this.bcpAddInfo);
            this.Controls.Add(this.vspnlAdd);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.captionPanel1);
            this.Controls.Add(this.sxpPanelGroup1);
            this.Name = "FrmWalkConfigInfo";
            this.Text = "行走异常配置";
            this.Load += new System.EventHandler(this.FrmWalkConfigInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).EndInit();
            this.sxpPanelGroup1.ResumeLayout(false);
            this.sxpPanel1.ResumeLayout(false);
            this.sxpPanel1.PerformLayout();
            this.vspnlAdd.ResumeLayout(false);
            this.vspnlAdd.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Wilson.Controls.XPPanel.Images.SXPPanelGroup sxpPanelGroup1;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel1;
        private KJ128WindowsLibrary.CaptionPanel captionPanel1;
        private KJ128NInterfaceShow.DataGridViewKJ128 dgvMain;
        private KJ128WindowsLibrary.VSPanel vspnlAdd;
        private System.Windows.Forms.ComboBox cbDept;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.ComboBox cbEmp;
        private System.Windows.Forms.Label lblEmp;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnAddOrEdit;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rbFA;
        private System.Windows.Forms.RadioButton rbFB;
        private System.Windows.Forms.RadioButton rbMB;
        private System.Windows.Forms.RadioButton rbMA;
        private System.Windows.Forms.RadioButton rbLB;
        private System.Windows.Forms.RadioButton rbLA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpAddInfo;
        private System.Windows.Forms.ComboBox cbMSH;
        private System.Windows.Forms.ComboBox cbMS;
        private System.Windows.Forms.ComboBox cbLSH;
        private System.Windows.Forms.ComboBox cbLS;
        private System.Windows.Forms.ComboBox cbFSH;
        private System.Windows.Forms.ComboBox cbFS;
        private Shine.ShineTextBox txtHour;
        private Shine.ShineTextBox txtSec;
        private Shine.ShineTextBox txtMin;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private Shine.ShineTextBox txtCodeSenderAddress;
        private Shine.ShineTextBox txtEmpName;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.ComboBox cbdpt;
        private System.Windows.Forms.Label lblDep;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpSelect;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
    }
}