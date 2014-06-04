namespace KJ128NMainRun.StationManage
{
    partial class A_FrmStationInfo
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
            this.components = new System.ComponentModel.Container();
            this.cmsStationHand = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.取消ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pl_AddStaHeadInfo = new System.Windows.Forms.Panel();
            this.bt_StaHead_Close = new System.Windows.Forms.Button();
            this.bt_StaHead_Reset = new System.Windows.Forms.Button();
            this.bt_StaHead_Save = new System.Windows.Forms.Button();
            this.lb_StaHeadTipsInfo = new System.Windows.Forms.Label();
            this.lb_StaHeadTipsInfo2 = new System.Windows.Forms.Label();
            this.gb_AddStaHeadInfo = new System.Windows.Forms.GroupBox();
            this.txt_StaHeadRemark = new Shine.ShineTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_StaHeadTel = new Shine.ShineTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_StaHeadAntennaB = new Shine.ShineTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_StaHeadAddress = new Shine.ShineTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_StaHeadAntennaA = new Shine.ShineTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.rb_WellUp = new System.Windows.Forms.RadioButton();
            this.rb_WellHead = new System.Windows.Forms.RadioButton();
            this.txt_StaHeadPlace = new Shine.ShineTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_StaHead_StaAddress = new Shine.ShineTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.bcp_StaHeadTitle = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.pl_AddStationInfo = new System.Windows.Forms.Panel();
            this.bt_Station_Close = new System.Windows.Forms.Button();
            this.bt_Station_Reset = new System.Windows.Forms.Button();
            this.bt_Station_Save = new System.Windows.Forms.Button();
            this.lb_StationTipsInfo = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.gb_AddStationInfo = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_StationPacket = new System.Windows.Forms.ComboBox();
            this.txt_StationTel = new Shine.ShineTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rb_V2 = new System.Windows.Forms.RadioButton();
            this.rb_A = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_StationPlace = new Shine.ShineTextBox();
            this.label111 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label121 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.txt_StationAddress = new Shine.ShineTextBox();
            this.label123 = new System.Windows.Forms.Label();
            this.bcp_StationTitle = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCaptionPanel1 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.bcpAddNewStation = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer_Refresh = new System.Windows.Forms.Timer(this.components);
            this.cmsStationHand.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pl_AddStaHeadInfo.SuspendLayout();
            this.gb_AddStaHeadInfo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pl_AddStationInfo.SuspendLayout();
            this.gb_AddStationInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsStationHand
            // 
            this.cmsStationHand.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuEdit,
            this.tsMenuDelete,
            this.取消ToolStripMenuItem});
            this.cmsStationHand.Name = "cmsStationHand";
            this.cmsStationHand.Size = new System.Drawing.Size(107, 70);
            // 
            // tsMenuEdit
            // 
            this.tsMenuEdit.Name = "tsMenuEdit";
            this.tsMenuEdit.Size = new System.Drawing.Size(106, 22);
            this.tsMenuEdit.Text = "修  改";
            this.tsMenuEdit.Click += new System.EventHandler(this.FrmStationManage_Click);
            // 
            // tsMenuDelete
            // 
            this.tsMenuDelete.Name = "tsMenuDelete";
            this.tsMenuDelete.Size = new System.Drawing.Size(106, 22);
            this.tsMenuDelete.Text = "删  除";
            this.tsMenuDelete.Click += new System.EventHandler(this.tsMenuDelete_Click);
            // 
            // 取消ToolStripMenuItem
            // 
            this.取消ToolStripMenuItem.Name = "取消ToolStripMenuItem";
            this.取消ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.取消ToolStripMenuItem.Text = "取  消";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.pl_AddStaHeadInfo);
            this.panel2.Controls.Add(this.pl_AddStationInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 548);
            this.panel2.TabIndex = 5;
            // 
            // pl_AddStaHeadInfo
            // 
            this.pl_AddStaHeadInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pl_AddStaHeadInfo.Controls.Add(this.bt_StaHead_Close);
            this.pl_AddStaHeadInfo.Controls.Add(this.bt_StaHead_Reset);
            this.pl_AddStaHeadInfo.Controls.Add(this.bt_StaHead_Save);
            this.pl_AddStaHeadInfo.Controls.Add(this.lb_StaHeadTipsInfo);
            this.pl_AddStaHeadInfo.Controls.Add(this.lb_StaHeadTipsInfo2);
            this.pl_AddStaHeadInfo.Controls.Add(this.gb_AddStaHeadInfo);
            this.pl_AddStaHeadInfo.Controls.Add(this.bcp_StaHeadTitle);
            this.pl_AddStaHeadInfo.Location = new System.Drawing.Point(183, 45);
            this.pl_AddStaHeadInfo.Name = "pl_AddStaHeadInfo";
            this.pl_AddStaHeadInfo.Size = new System.Drawing.Size(393, 299);
            this.pl_AddStaHeadInfo.TabIndex = 7;
            this.pl_AddStaHeadInfo.Visible = false;
            // 
            // bt_StaHead_Close
            // 
            this.bt_StaHead_Close.Location = new System.Drawing.Point(327, 259);
            this.bt_StaHead_Close.Name = "bt_StaHead_Close";
            this.bt_StaHead_Close.Size = new System.Drawing.Size(56, 23);
            this.bt_StaHead_Close.TabIndex = 68;
            this.bt_StaHead_Close.Text = "返回";
            this.bt_StaHead_Close.UseVisualStyleBackColor = true;
            this.bt_StaHead_Close.Click += new System.EventHandler(this.bt_StaHead_Close_Click);
            // 
            // bt_StaHead_Reset
            // 
            this.bt_StaHead_Reset.Location = new System.Drawing.Point(260, 259);
            this.bt_StaHead_Reset.Name = "bt_StaHead_Reset";
            this.bt_StaHead_Reset.Size = new System.Drawing.Size(56, 23);
            this.bt_StaHead_Reset.TabIndex = 67;
            this.bt_StaHead_Reset.Text = "重置";
            this.bt_StaHead_Reset.UseVisualStyleBackColor = true;
            this.bt_StaHead_Reset.Click += new System.EventHandler(this.bt_StaHead_Reset_Click);
            // 
            // bt_StaHead_Save
            // 
            this.bt_StaHead_Save.Location = new System.Drawing.Point(192, 259);
            this.bt_StaHead_Save.Name = "bt_StaHead_Save";
            this.bt_StaHead_Save.Size = new System.Drawing.Size(56, 23);
            this.bt_StaHead_Save.TabIndex = 66;
            this.bt_StaHead_Save.Text = "保存";
            this.bt_StaHead_Save.UseVisualStyleBackColor = true;
            this.bt_StaHead_Save.Click += new System.EventHandler(this.bt_StaHead_Save_Click);
            // 
            // lb_StaHeadTipsInfo
            // 
            this.lb_StaHeadTipsInfo.AutoSize = true;
            this.lb_StaHeadTipsInfo.Location = new System.Drawing.Point(64, 243);
            this.lb_StaHeadTipsInfo.Name = "lb_StaHeadTipsInfo";
            this.lb_StaHeadTipsInfo.Size = new System.Drawing.Size(53, 12);
            this.lb_StaHeadTipsInfo.TabIndex = 65;
            this.lb_StaHeadTipsInfo.Text = "保存成功";
            // 
            // lb_StaHeadTipsInfo2
            // 
            this.lb_StaHeadTipsInfo2.AutoSize = true;
            this.lb_StaHeadTipsInfo2.Location = new System.Drawing.Point(17, 243);
            this.lb_StaHeadTipsInfo2.Name = "lb_StaHeadTipsInfo2";
            this.lb_StaHeadTipsInfo2.Size = new System.Drawing.Size(41, 12);
            this.lb_StaHeadTipsInfo2.TabIndex = 64;
            this.lb_StaHeadTipsInfo2.Text = "提示：";
            // 
            // gb_AddStaHeadInfo
            // 
            this.gb_AddStaHeadInfo.Controls.Add(this.txt_StaHeadRemark);
            this.gb_AddStaHeadInfo.Controls.Add(this.label21);
            this.gb_AddStaHeadInfo.Controls.Add(this.txt_StaHeadTel);
            this.gb_AddStaHeadInfo.Controls.Add(this.label13);
            this.gb_AddStaHeadInfo.Controls.Add(this.txt_StaHeadAntennaB);
            this.gb_AddStaHeadInfo.Controls.Add(this.label20);
            this.gb_AddStaHeadInfo.Controls.Add(this.label15);
            this.gb_AddStaHeadInfo.Controls.Add(this.label9);
            this.gb_AddStaHeadInfo.Controls.Add(this.txt_StaHeadAddress);
            this.gb_AddStaHeadInfo.Controls.Add(this.label12);
            this.gb_AddStaHeadInfo.Controls.Add(this.txt_StaHeadAntennaA);
            this.gb_AddStaHeadInfo.Controls.Add(this.groupBox3);
            this.gb_AddStaHeadInfo.Controls.Add(this.txt_StaHeadPlace);
            this.gb_AddStaHeadInfo.Controls.Add(this.label16);
            this.gb_AddStaHeadInfo.Controls.Add(this.label17);
            this.gb_AddStaHeadInfo.Controls.Add(this.label18);
            this.gb_AddStaHeadInfo.Controls.Add(this.txt_StaHead_StaAddress);
            this.gb_AddStaHeadInfo.Controls.Add(this.label19);
            this.gb_AddStaHeadInfo.Location = new System.Drawing.Point(17, 32);
            this.gb_AddStaHeadInfo.Name = "gb_AddStaHeadInfo";
            this.gb_AddStaHeadInfo.Size = new System.Drawing.Size(356, 195);
            this.gb_AddStaHeadInfo.TabIndex = 63;
            this.gb_AddStaHeadInfo.TabStop = false;
            // 
            // txt_StaHeadRemark
            // 
            this.txt_StaHeadRemark.Location = new System.Drawing.Point(20, 163);
            this.txt_StaHeadRemark.MaxLength = 200;
            this.txt_StaHeadRemark.Name = "txt_StaHeadRemark";
            this.txt_StaHeadRemark.Size = new System.Drawing.Size(320, 21);
            this.txt_StaHeadRemark.TabIndex = 82;
            this.txt_StaHeadRemark.TextType = Shine.TextType.WithOutChar;
            this.txt_StaHeadRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_StaHeadRemark_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(20, 145);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 12);
            this.label21.TabIndex = 81;
            this.label21.Text = "备注：";
            // 
            // txt_StaHeadTel
            // 
            this.txt_StaHeadTel.Location = new System.Drawing.Point(221, 136);
            this.txt_StaHeadTel.MaxLength = 20;
            this.txt_StaHeadTel.Name = "txt_StaHeadTel";
            this.txt_StaHeadTel.Size = new System.Drawing.Size(119, 21);
            this.txt_StaHeadTel.TabIndex = 80;
            this.txt_StaHeadTel.TextType = Shine.TextType.Number;
            this.txt_StaHeadTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_StaHeadTel_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(153, 139);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 79;
            this.label13.Text = "联系电话：";
            // 
            // txt_StaHeadAntennaB
            // 
            this.txt_StaHeadAntennaB.Location = new System.Drawing.Point(221, 109);
            this.txt_StaHeadAntennaB.MaxLength = 20;
            this.txt_StaHeadAntennaB.Name = "txt_StaHeadAntennaB";
            this.txt_StaHeadAntennaB.Size = new System.Drawing.Size(119, 21);
            this.txt_StaHeadAntennaB.TabIndex = 78;
            this.txt_StaHeadAntennaB.TextType = Shine.TextType.WithOutChar;
            this.txt_StaHeadAntennaB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_StaHeadAntennaB_KeyPress);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(171, 112);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 12);
            this.label20.TabIndex = 77;
            this.label20.Text = "天线B：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(298, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 12);
            this.label15.TabIndex = 76;
            this.label15.Text = "(1-6)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(174, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 74;
            this.label9.Text = "读卡分站号：";
            // 
            // txt_StaHeadAddress
            // 
            this.txt_StaHeadAddress.Enabled = false;
            this.txt_StaHeadAddress.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_StaHeadAddress.Location = new System.Drawing.Point(257, 14);
            this.txt_StaHeadAddress.MaxLength = 2;
            this.txt_StaHeadAddress.Name = "txt_StaHeadAddress";
            this.txt_StaHeadAddress.Size = new System.Drawing.Size(38, 21);
            this.txt_StaHeadAddress.TabIndex = 75;
            this.txt_StaHeadAddress.TextType = Shine.TextType.Number;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(8, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 73;
            this.label12.Text = "*";
            // 
            // txt_StaHeadAntennaA
            // 
            this.txt_StaHeadAntennaA.Location = new System.Drawing.Point(221, 78);
            this.txt_StaHeadAntennaA.MaxLength = 20;
            this.txt_StaHeadAntennaA.Name = "txt_StaHeadAntennaA";
            this.txt_StaHeadAntennaA.Size = new System.Drawing.Size(119, 21);
            this.txt_StaHeadAntennaA.TabIndex = 70;
            this.txt_StaHeadAntennaA.TextType = Shine.TextType.WithOutChar;
            this.txt_StaHeadAntennaA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_StaHeadAntennaA_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.rb_WellUp);
            this.groupBox3.Controls.Add(this.rb_WellHead);
            this.groupBox3.Location = new System.Drawing.Point(19, 73);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(129, 65);
            this.groupBox3.TabIndex = 69;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "  传输协议";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(9, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 74;
            this.label14.Text = "*";
            // 
            // rb_WellUp
            // 
            this.rb_WellUp.AutoSize = true;
            this.rb_WellUp.Checked = true;
            this.rb_WellUp.Location = new System.Drawing.Point(38, 42);
            this.rb_WellUp.Name = "rb_WellUp";
            this.rb_WellUp.Size = new System.Drawing.Size(71, 16);
            this.rb_WellUp.TabIndex = 1;
            this.rb_WellUp.TabStop = true;
            this.rb_WellUp.Text = "井下分站";
            this.rb_WellUp.UseVisualStyleBackColor = true;
            // 
            // rb_WellHead
            // 
            this.rb_WellHead.AutoSize = true;
            this.rb_WellHead.Location = new System.Drawing.Point(38, 20);
            this.rb_WellHead.Name = "rb_WellHead";
            this.rb_WellHead.Size = new System.Drawing.Size(83, 16);
            this.rb_WellHead.TabIndex = 0;
            this.rb_WellHead.Text = "上井口分站";
            this.rb_WellHead.UseVisualStyleBackColor = true;
            // 
            // txt_StaHeadPlace
            // 
            this.txt_StaHeadPlace.Location = new System.Drawing.Point(89, 46);
            this.txt_StaHeadPlace.MaxLength = 50;
            this.txt_StaHeadPlace.Name = "txt_StaHeadPlace";
            this.txt_StaHeadPlace.Size = new System.Drawing.Size(250, 21);
            this.txt_StaHeadPlace.TabIndex = 67;
            this.txt_StaHeadPlace.TextType = Shine.TextType.WithOutChar;
            this.txt_StaHeadPlace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_StaHeadPlace_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(18, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 66;
            this.label16.Text = "安装位置：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(171, 81);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 12);
            this.label17.TabIndex = 61;
            this.label17.Text = "天线A：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(18, 17);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 17;
            this.label18.Text = "分站分站：";
            // 
            // txt_StaHead_StaAddress
            // 
            this.txt_StaHead_StaAddress.Enabled = false;
            this.txt_StaHead_StaAddress.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_StaHead_StaAddress.Location = new System.Drawing.Point(89, 13);
            this.txt_StaHead_StaAddress.MaxLength = 3;
            this.txt_StaHead_StaAddress.Name = "txt_StaHead_StaAddress";
            this.txt_StaHead_StaAddress.Size = new System.Drawing.Size(38, 21);
            this.txt_StaHead_StaAddress.TabIndex = 18;
            this.txt_StaHead_StaAddress.TextType = Shine.TextType.Number;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(154, 17);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(11, 12);
            this.label19.TabIndex = 19;
            this.label19.Text = "*";
            // 
            // bcp_StaHeadTitle
            // 
            this.bcp_StaHeadTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcp_StaHeadTitle.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcp_StaHeadTitle.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(189)))), ((int)(((byte)(105)))));
            this.bcp_StaHeadTitle.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(232)))), ((int)(((byte)(253)))));
            this.bcp_StaHeadTitle.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(176)))), ((int)(((byte)(228)))));
            this.bcp_StaHeadTitle.CaptionBottomLineColor = System.Drawing.Color.Black;
            this.bcp_StaHeadTitle.CaptionBottomLineWidth = 1;
            this.bcp_StaHeadTitle.CaptionCloseButtonControlLeft = 2;
            this.bcp_StaHeadTitle.CaptionCloseButtonForeColor = System.Drawing.Color.Black;
            this.bcp_StaHeadTitle.CaptionCloseButtonTitle = "×";
            this.bcp_StaHeadTitle.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcp_StaHeadTitle.CaptionForeColor = System.Drawing.Color.Black;
            this.bcp_StaHeadTitle.CaptionHeight = 20;
            this.bcp_StaHeadTitle.CaptionLeft = 1;
            this.bcp_StaHeadTitle.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcp_StaHeadTitle.CaptionTitle = "新增读卡分站";
            this.bcp_StaHeadTitle.CaptionTitleLeft = 8;
            this.bcp_StaHeadTitle.CaptionTitleTop = 4;
            this.bcp_StaHeadTitle.CaptionTop = 1;
            this.bcp_StaHeadTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.bcp_StaHeadTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.bcp_StaHeadTitle.IsBorderLine = false;
            this.bcp_StaHeadTitle.IsCaptionSingleColor = false;
            this.bcp_StaHeadTitle.IsOnlyCaption = true;
            this.bcp_StaHeadTitle.IsPanelImage = true;
            this.bcp_StaHeadTitle.IsUserButtonClose = true;
            this.bcp_StaHeadTitle.IsUserCaptionBottomLine = false;
            this.bcp_StaHeadTitle.IsUserSystemCloseButtonLeft = true;
            this.bcp_StaHeadTitle.Location = new System.Drawing.Point(0, 0);
            this.bcp_StaHeadTitle.Name = "bcp_StaHeadTitle";
            this.bcp_StaHeadTitle.PanelImage = null;
            this.bcp_StaHeadTitle.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.bcp_StaHeadTitle.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2003;
            this.bcp_StaHeadTitle.Size = new System.Drawing.Size(391, 21);
            this.bcp_StaHeadTitle.TabIndex = 12;
            this.bcp_StaHeadTitle.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcp_StaHeadTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bcp_StaHeadTitle_MouseUp);
            this.bcp_StaHeadTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bcp_StaHeadTitle_MouseMove);
            this.bcp_StaHeadTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bcp_StaHeadTitle_MouseDown);
            this.bcp_StaHeadTitle.CloseButtonClick += new System.EventHandler(this.bt_StaHead_Close_Click);
            // 
            // pl_AddStationInfo
            // 
            this.pl_AddStationInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pl_AddStationInfo.Controls.Add(this.bt_Station_Close);
            this.pl_AddStationInfo.Controls.Add(this.bt_Station_Reset);
            this.pl_AddStationInfo.Controls.Add(this.bt_Station_Save);
            this.pl_AddStationInfo.Controls.Add(this.lb_StationTipsInfo);
            this.pl_AddStationInfo.Controls.Add(this.label110);
            this.pl_AddStationInfo.Controls.Add(this.gb_AddStationInfo);
            this.pl_AddStationInfo.Controls.Add(this.bcp_StationTitle);
            this.pl_AddStationInfo.Location = new System.Drawing.Point(582, 78);
            this.pl_AddStationInfo.Name = "pl_AddStationInfo";
            this.pl_AddStationInfo.Size = new System.Drawing.Size(403, 309);
            this.pl_AddStationInfo.TabIndex = 6;
            this.pl_AddStationInfo.Visible = false;
            // 
            // bt_Station_Close
            // 
            this.bt_Station_Close.Location = new System.Drawing.Point(327, 259);
            this.bt_Station_Close.Name = "bt_Station_Close";
            this.bt_Station_Close.Size = new System.Drawing.Size(56, 23);
            this.bt_Station_Close.TabIndex = 68;
            this.bt_Station_Close.Text = "返回";
            this.bt_Station_Close.UseVisualStyleBackColor = true;
            this.bt_Station_Close.Click += new System.EventHandler(this.bt_Station_Close_Click);
            // 
            // bt_Station_Reset
            // 
            this.bt_Station_Reset.Location = new System.Drawing.Point(260, 259);
            this.bt_Station_Reset.Name = "bt_Station_Reset";
            this.bt_Station_Reset.Size = new System.Drawing.Size(56, 23);
            this.bt_Station_Reset.TabIndex = 67;
            this.bt_Station_Reset.Text = "重置";
            this.bt_Station_Reset.UseVisualStyleBackColor = true;
            this.bt_Station_Reset.Click += new System.EventHandler(this.bt_Station_Reset_Click);
            // 
            // bt_Station_Save
            // 
            this.bt_Station_Save.Location = new System.Drawing.Point(192, 259);
            this.bt_Station_Save.Name = "bt_Station_Save";
            this.bt_Station_Save.Size = new System.Drawing.Size(56, 23);
            this.bt_Station_Save.TabIndex = 66;
            this.bt_Station_Save.Text = "保存";
            this.bt_Station_Save.UseVisualStyleBackColor = true;
            this.bt_Station_Save.Click += new System.EventHandler(this.bt_Station_Save_Click);
            // 
            // lb_StationTipsInfo
            // 
            this.lb_StationTipsInfo.AutoSize = true;
            this.lb_StationTipsInfo.Location = new System.Drawing.Point(64, 243);
            this.lb_StationTipsInfo.Name = "lb_StationTipsInfo";
            this.lb_StationTipsInfo.Size = new System.Drawing.Size(53, 12);
            this.lb_StationTipsInfo.TabIndex = 65;
            this.lb_StationTipsInfo.Text = "保存成功";
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Location = new System.Drawing.Point(17, 243);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(41, 12);
            this.label110.TabIndex = 64;
            this.label110.Text = "提示：";
            // 
            // gb_AddStationInfo
            // 
            this.gb_AddStationInfo.Controls.Add(this.label7);
            this.gb_AddStationInfo.Controls.Add(this.label6);
            this.gb_AddStationInfo.Controls.Add(this.cmb_StationPacket);
            this.gb_AddStationInfo.Controls.Add(this.txt_StationTel);
            this.gb_AddStationInfo.Controls.Add(this.groupBox1);
            this.gb_AddStationInfo.Controls.Add(this.label5);
            this.gb_AddStationInfo.Controls.Add(this.txt_StationPlace);
            this.gb_AddStationInfo.Controls.Add(this.label111);
            this.gb_AddStationInfo.Controls.Add(this.pictureBox5);
            this.gb_AddStationInfo.Controls.Add(this.label121);
            this.gb_AddStationInfo.Controls.Add(this.label122);
            this.gb_AddStationInfo.Controls.Add(this.txt_StationAddress);
            this.gb_AddStationInfo.Controls.Add(this.label123);
            this.gb_AddStationInfo.Location = new System.Drawing.Point(17, 32);
            this.gb_AddStationInfo.Name = "gb_AddStationInfo";
            this.gb_AddStationInfo.Size = new System.Drawing.Size(356, 195);
            this.gb_AddStationInfo.TabIndex = 63;
            this.gb_AddStationInfo.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(161, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 73;
            this.label7.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 72;
            this.label6.Text = "分组编号：";
            // 
            // cmb_StationPacket
            // 
            this.cmb_StationPacket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StationPacket.FormattingEnabled = true;
            this.cmb_StationPacket.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cmb_StationPacket.Location = new System.Drawing.Point(238, 162);
            this.cmb_StationPacket.Name = "cmb_StationPacket";
            this.cmb_StationPacket.Size = new System.Drawing.Size(105, 20);
            this.cmb_StationPacket.TabIndex = 71;
            // 
            // txt_StationTel
            // 
            this.txt_StationTel.Location = new System.Drawing.Point(238, 133);
            this.txt_StationTel.MaxLength = 20;
            this.txt_StationTel.Name = "txt_StationTel";
            this.txt_StationTel.Size = new System.Drawing.Size(105, 21);
            this.txt_StationTel.TabIndex = 70;
            this.txt_StationTel.TextType = Shine.TextType.Number;
            this.txt_StationTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_StationTel_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.rb_V2);
            this.groupBox1.Controls.Add(this.rb_A);
            this.groupBox1.Location = new System.Drawing.Point(171, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 48);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "  传输协议";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(12, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 74;
            this.label8.Text = "*";
            // 
            // rb_V2
            // 
            this.rb_V2.AutoSize = true;
            this.rb_V2.Location = new System.Drawing.Point(111, 18);
            this.rb_V2.Name = "rb_V2";
            this.rb_V2.Size = new System.Drawing.Size(47, 16);
            this.rb_V2.TabIndex = 1;
            this.rb_V2.Text = "V2版";
            this.rb_V2.UseVisualStyleBackColor = true;
            // 
            // rb_A
            // 
            this.rb_A.AutoSize = true;
            this.rb_A.Checked = true;
            this.rb_A.Location = new System.Drawing.Point(24, 19);
            this.rb_A.Name = "rb_A";
            this.rb_A.Size = new System.Drawing.Size(41, 16);
            this.rb_A.TabIndex = 0;
            this.rb_A.TabStop = true;
            this.rb_A.Text = "A版";
            this.rb_A.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(302, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 68;
            this.label5.Text = "(1-64)";
            this.label5.Visible = false;
            // 
            // txt_StationPlace
            // 
            this.txt_StationPlace.Location = new System.Drawing.Point(238, 46);
            this.txt_StationPlace.MaxLength = 20;
            this.txt_StationPlace.Name = "txt_StationPlace";
            this.txt_StationPlace.Size = new System.Drawing.Size(105, 21);
            this.txt_StationPlace.TabIndex = 67;
            this.txt_StationPlace.TextType = Shine.TextType.WithOutChar;
            this.txt_StationPlace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_StationPlace_KeyPress);
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(171, 49);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(65, 12);
            this.label111.TabIndex = 66;
            this.label111.Text = "安装位置：";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.Location = new System.Drawing.Point(14, 20);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(141, 162);
            this.pictureBox5.TabIndex = 63;
            this.pictureBox5.TabStop = false;
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Location = new System.Drawing.Point(171, 136);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(65, 12);
            this.label121.TabIndex = 61;
            this.label121.Text = "联系电话：";
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Location = new System.Drawing.Point(173, 23);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(65, 12);
            this.label122.TabIndex = 17;
            this.label122.Text = "分 站 号：";
            // 
            // txt_StationAddress
            // 
            this.txt_StationAddress.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_StationAddress.Location = new System.Drawing.Point(238, 20);
            this.txt_StationAddress.MaxLength = 3;
            this.txt_StationAddress.Name = "txt_StationAddress";
            this.txt_StationAddress.Size = new System.Drawing.Size(61, 21);
            this.txt_StationAddress.TabIndex = 18;
            this.txt_StationAddress.TextType = Shine.TextType.Number;
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.BackColor = System.Drawing.Color.Transparent;
            this.label123.ForeColor = System.Drawing.Color.Red;
            this.label123.Location = new System.Drawing.Point(161, 23);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(11, 12);
            this.label123.TabIndex = 19;
            this.label123.Text = "*";
            // 
            // bcp_StationTitle
            // 
            this.bcp_StationTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcp_StationTitle.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcp_StationTitle.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(189)))), ((int)(((byte)(105)))));
            this.bcp_StationTitle.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(232)))), ((int)(((byte)(253)))));
            this.bcp_StationTitle.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(176)))), ((int)(((byte)(228)))));
            this.bcp_StationTitle.CaptionBottomLineColor = System.Drawing.Color.Black;
            this.bcp_StationTitle.CaptionBottomLineWidth = 1;
            this.bcp_StationTitle.CaptionCloseButtonControlLeft = 2;
            this.bcp_StationTitle.CaptionCloseButtonForeColor = System.Drawing.Color.Black;
            this.bcp_StationTitle.CaptionCloseButtonTitle = "×";
            this.bcp_StationTitle.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcp_StationTitle.CaptionForeColor = System.Drawing.Color.Black;
            this.bcp_StationTitle.CaptionHeight = 20;
            this.bcp_StationTitle.CaptionLeft = 1;
            this.bcp_StationTitle.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcp_StationTitle.CaptionTitle = "新增传输分站";
            this.bcp_StationTitle.CaptionTitleLeft = 8;
            this.bcp_StationTitle.CaptionTitleTop = 4;
            this.bcp_StationTitle.CaptionTop = 1;
            this.bcp_StationTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.bcp_StationTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.bcp_StationTitle.IsBorderLine = false;
            this.bcp_StationTitle.IsCaptionSingleColor = false;
            this.bcp_StationTitle.IsOnlyCaption = true;
            this.bcp_StationTitle.IsPanelImage = true;
            this.bcp_StationTitle.IsUserButtonClose = true;
            this.bcp_StationTitle.IsUserCaptionBottomLine = false;
            this.bcp_StationTitle.IsUserSystemCloseButtonLeft = true;
            this.bcp_StationTitle.Location = new System.Drawing.Point(0, 0);
            this.bcp_StationTitle.Name = "bcp_StationTitle";
            this.bcp_StationTitle.PanelImage = null;
            this.bcp_StationTitle.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.bcp_StationTitle.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2003;
            this.bcp_StationTitle.Size = new System.Drawing.Size(401, 21);
            this.bcp_StationTitle.TabIndex = 12;
            this.bcp_StationTitle.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcp_StationTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bcp_StationTitle_MouseUp);
            this.bcp_StationTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bcp_StationTitle_MouseMove);
            this.bcp_StationTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bcp_StationTitle_MouseDown);
            this.bcp_StationTitle.CloseButtonClick += new System.EventHandler(this.bt_Station_Close_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1028, 43);
            this.panel3.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.buttonCaptionPanel1);
            this.panel1.Controls.Add(this.bcpAddNewStation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 38);
            this.panel1.TabIndex = 4;
            // 
            // buttonCaptionPanel1
            // 
            this.buttonCaptionPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.buttonCaptionPanel1.CaptionHeight = 30;
            this.buttonCaptionPanel1.CaptionLeft = 1;
            this.buttonCaptionPanel1.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.buttonCaptionPanel1.CaptionTitle = "刷  新";
            this.buttonCaptionPanel1.CaptionTitleLeft = 8;
            this.buttonCaptionPanel1.CaptionTitleTop = 8;
            this.buttonCaptionPanel1.CaptionTop = 1;
            this.buttonCaptionPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCaptionPanel1.IsBorderLine = true;
            this.buttonCaptionPanel1.IsCaptionSingleColor = false;
            this.buttonCaptionPanel1.IsOnlyCaption = true;
            this.buttonCaptionPanel1.IsPanelImage = true;
            this.buttonCaptionPanel1.IsUserButtonClose = false;
            this.buttonCaptionPanel1.IsUserCaptionBottomLine = false;
            this.buttonCaptionPanel1.IsUserSystemCloseButtonLeft = true;
            this.buttonCaptionPanel1.Location = new System.Drawing.Point(837, 3);
            this.buttonCaptionPanel1.Name = "buttonCaptionPanel1";
            this.buttonCaptionPanel1.PanelImage = null;
            this.buttonCaptionPanel1.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.buttonCaptionPanel1.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.buttonCaptionPanel1.Size = new System.Drawing.Size(66, 32);
            this.buttonCaptionPanel1.TabIndex = 1;
            this.buttonCaptionPanel1.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.buttonCaptionPanel1.Click += new System.EventHandler(this.buttonCaptionPanel1_Click);
            // 
            // bcpAddNewStation
            // 
            this.bcpAddNewStation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bcpAddNewStation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpAddNewStation.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpAddNewStation.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpAddNewStation.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.bcpAddNewStation.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.bcpAddNewStation.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpAddNewStation.CaptionBottomLineWidth = 1;
            this.bcpAddNewStation.CaptionCloseButtonControlLeft = 2;
            this.bcpAddNewStation.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpAddNewStation.CaptionCloseButtonTitle = "×";
            this.bcpAddNewStation.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpAddNewStation.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bcpAddNewStation.CaptionHeight = 30;
            this.bcpAddNewStation.CaptionLeft = 1;
            this.bcpAddNewStation.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpAddNewStation.CaptionTitle = "添加新传输分站";
            this.bcpAddNewStation.CaptionTitleLeft = 8;
            this.bcpAddNewStation.CaptionTitleTop = 8;
            this.bcpAddNewStation.CaptionTop = 1;
            this.bcpAddNewStation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcpAddNewStation.IsBorderLine = true;
            this.bcpAddNewStation.IsCaptionSingleColor = false;
            this.bcpAddNewStation.IsOnlyCaption = true;
            this.bcpAddNewStation.IsPanelImage = true;
            this.bcpAddNewStation.IsUserButtonClose = false;
            this.bcpAddNewStation.IsUserCaptionBottomLine = false;
            this.bcpAddNewStation.IsUserSystemCloseButtonLeft = true;
            this.bcpAddNewStation.Location = new System.Drawing.Point(909, 3);
            this.bcpAddNewStation.Name = "bcpAddNewStation";
            this.bcpAddNewStation.PanelImage = null;
            this.bcpAddNewStation.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpAddNewStation.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpAddNewStation.Size = new System.Drawing.Size(114, 32);
            this.bcpAddNewStation.TabIndex = 0;
            this.bcpAddNewStation.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpAddNewStation.Load += new System.EventHandler(this.bcpAddNewStation_Load);
            this.bcpAddNewStation.Click += new System.EventHandler(this.bcpAddNewStation_Click);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 800;
            // 
            // timer_Refresh
            // 
            this.timer_Refresh.Interval = 400;
            this.timer_Refresh.Tick += new System.EventHandler(this.timer_Refresh_Tick);
            // 
            // A_FrmStationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1028, 629);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "A_FrmStationInfo";
            this.TabText = "分站配置";
            this.Text = "分站配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.A_FrmStationInfo_FormClosing);
            this.cmsStationHand.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pl_AddStaHeadInfo.ResumeLayout(false);
            this.pl_AddStaHeadInfo.PerformLayout();
            this.gb_AddStaHeadInfo.ResumeLayout(false);
            this.gb_AddStaHeadInfo.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.pl_AddStationInfo.ResumeLayout(false);
            this.pl_AddStationInfo.PerformLayout();
            this.gb_AddStationInfo.ResumeLayout(false);
            this.gb_AddStationInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsStationHand;
        private System.Windows.Forms.ToolStripMenuItem tsMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem tsMenuDelete;
        private System.Windows.Forms.ToolStripMenuItem 取消ToolStripMenuItem;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpAddNewStation;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer timer1;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel pl_AddStationInfo;
        private System.Windows.Forms.Button bt_Station_Close;
        private System.Windows.Forms.Button bt_Station_Reset;
        private System.Windows.Forms.Button bt_Station_Save;
        private System.Windows.Forms.Label lb_StationTipsInfo;
        private System.Windows.Forms.Label label110;
        private System.Windows.Forms.GroupBox gb_AddStationInfo;
        private Shine.ShineTextBox txt_StationPlace;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label121;
        private System.Windows.Forms.Label label122;
        private Shine.ShineTextBox txt_StationAddress;
        private System.Windows.Forms.Label label123;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcp_StationTitle;
        private Shine.ShineTextBox txt_StationTel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_A;
        private System.Windows.Forms.ComboBox cmb_StationPacket;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pl_AddStaHeadInfo;
        private System.Windows.Forms.Button bt_StaHead_Close;
        private System.Windows.Forms.Button bt_StaHead_Reset;
        private System.Windows.Forms.Button bt_StaHead_Save;
        private System.Windows.Forms.Label lb_StaHeadTipsInfo;
        private System.Windows.Forms.Label lb_StaHeadTipsInfo2;
        private System.Windows.Forms.GroupBox gb_AddStaHeadInfo;
        private System.Windows.Forms.Label label9;
        private Shine.ShineTextBox txt_StaHeadAddress;
        private System.Windows.Forms.Label label12;
        private Shine.ShineTextBox txt_StaHeadAntennaA;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton rb_WellUp;
        private System.Windows.Forms.RadioButton rb_WellHead;
        private Shine.ShineTextBox txt_StaHeadPlace;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private Shine.ShineTextBox txt_StaHead_StaAddress;
        private System.Windows.Forms.Label label19;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcp_StaHeadTitle;
        private System.Windows.Forms.Label label15;
        private Shine.ShineTextBox txt_StaHeadTel;
        private System.Windows.Forms.Label label13;
        private Shine.ShineTextBox txt_StaHeadAntennaB;
        private System.Windows.Forms.Label label20;
        private Shine.ShineTextBox txt_StaHeadRemark;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.RadioButton rb_V2;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Timer timer_Refresh;
    }
}