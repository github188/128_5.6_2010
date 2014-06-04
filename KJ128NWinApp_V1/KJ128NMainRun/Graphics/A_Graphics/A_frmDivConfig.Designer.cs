﻿namespace KJ128NMainRun.Graphics.Config
{
    partial class A_frmDivConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_frmDivConfig));
            this.pnlInOut = new System.Windows.Forms.Panel();
            this.btnDivConfig = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.lnkAll = new System.Windows.Forms.LinkLabel();
            this.dgvStations = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.ntbMax = new Shine.Command.Controls.NumTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ntbMin = new Shine.Command.Controls.NumTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDivName = new Shine.ShineTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadDiv = new System.Windows.Forms.Button();
            this.btnTuku = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lnkSave = new System.Windows.Forms.LinkLabel();
            this.lnkPicList = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pnlPicList = new System.Windows.Forms.Panel();
            this.pnlEmp = new System.Windows.Forms.Panel();
            this.btnFont = new System.Windows.Forms.Button();
            this.btnImg = new System.Windows.Forms.Button();
            this.cpStationHead = new KJ128WindowsLibrary.CaptionPanel();
            this.trvRealTime = new System.Windows.Forms.TreeView();
            this.lsvImg = new System.Windows.Forms.ListView();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiMove = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWordConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.MapGis = new ZzhaControlLibrary.ZzhaMapGis();
            this.dmc = new DegonControlLib.DrawerMainControl();
            this.pnlPic = new System.Windows.Forms.Panel();
            this.btnPic = new System.Windows.Forms.Button();
            this.pnlWord = new System.Windows.Forms.Panel();
            this.btnWrod = new System.Windows.Forms.Button();
            this.pnlInOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStations)).BeginInit();
            this.pnlPicList.SuspendLayout();
            this.cmsMenu.SuspendLayout();
            this.pnlPic.SuspendLayout();
            this.pnlWord.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInOut
            // 
            this.pnlInOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlInOut.Controls.Add(this.btnDivConfig);
            this.pnlInOut.Controls.Add(this.btnSelectAll);
            this.pnlInOut.Controls.Add(this.lnkAll);
            this.pnlInOut.Controls.Add(this.dgvStations);
            this.pnlInOut.Controls.Add(this.label4);
            this.pnlInOut.Controls.Add(this.ntbMax);
            this.pnlInOut.Controls.Add(this.label3);
            this.pnlInOut.Controls.Add(this.ntbMin);
            this.pnlInOut.Controls.Add(this.label2);
            this.pnlInOut.Controls.Add(this.txtDivName);
            this.pnlInOut.Controls.Add(this.label1);
            this.pnlInOut.Location = new System.Drawing.Point(626, 116);
            this.pnlInOut.Name = "pnlInOut";
            this.pnlInOut.Size = new System.Drawing.Size(178, 297);
            this.pnlInOut.TabIndex = 1;
            // 
            // btnDivConfig
            // 
            this.btnDivConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDivConfig.Location = new System.Drawing.Point(0, 0);
            this.btnDivConfig.Name = "btnDivConfig";
            this.btnDivConfig.Size = new System.Drawing.Size(172, 28);
            this.btnDivConfig.TabIndex = 18;
            this.btnDivConfig.Text = "图层配置";
            this.btnDivConfig.UseVisualStyleBackColor = true;
            this.btnDivConfig.Click += new System.EventHandler(this.btnDivConfig_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(104, 108);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(62, 23);
            this.btnSelectAll.TabIndex = 3;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // lnkAll
            // 
            this.lnkAll.AutoSize = true;
            this.lnkAll.Location = new System.Drawing.Point(134, 113);
            this.lnkAll.Name = "lnkAll";
            this.lnkAll.Size = new System.Drawing.Size(29, 12);
            this.lnkAll.TabIndex = 14;
            this.lnkAll.TabStop = true;
            this.lnkAll.Text = "全选";
            this.lnkAll.Visible = false;
            this.lnkAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAll_LinkClicked);
            // 
            // dgvStations
            // 
            this.dgvStations.AllowUserToAddRows = false;
            this.dgvStations.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvStations.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvStations.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.dgvStations.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStations.ColumnHeadersVisible = false;
            this.dgvStations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgvStations.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.WindowsStyle;
            this.dgvStations.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.dgvStations.Location = new System.Drawing.Point(10, 131);
            this.dgvStations.Name = "dgvStations";
            this.dgvStations.RowHeadersVisible = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dgvStations.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvStations.RowTemplate.Height = 23;
            this.dgvStations.Size = new System.Drawing.Size(156, 160);
            this.dgvStations.TabIndex = 4;
            this.dgvStations.VerticalScrollBarMax = 1;
            this.dgvStations.VerticalScrollBarValue = 0;
            // 
            // Column1
            // 
            this.Column1.FalseValue = "false";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.TrueValue = "true";
            this.Column1.Width = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(9, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "分站显示配置";
            // 
            // ntbMax
            // 
            this.ntbMax.BoundValue = "-2147483648-2147483647";
            this.ntbMax.DefaultStyle = true;
            this.ntbMax.IsUseCopy = true;
            this.ntbMax.IsUseCut = true;
            this.ntbMax.IsUseNegative = false;
            this.ntbMax.IsUseStickUP = true;
            this.ntbMax.Location = new System.Drawing.Point(101, 81);
            this.ntbMax.Name = "ntbMax";
            this.ntbMax.NumberTypes = Shine.Command.Controls.NumberValidate.NumberType.Int;
            this.ntbMax.Size = new System.Drawing.Size(62, 21);
            this.ntbMax.TabIndex = 2;
            this.ntbMax.Leave += new System.EventHandler(this.ntbMax_Leave);
            this.ntbMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ntbMax_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(81, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "-";
            // 
            // ntbMin
            // 
            this.ntbMin.BoundValue = "-2147483648-2147483647";
            this.ntbMin.DefaultStyle = true;
            this.ntbMin.IsUseCopy = true;
            this.ntbMin.IsUseCut = true;
            this.ntbMin.IsUseNegative = false;
            this.ntbMin.IsUseStickUP = true;
            this.ntbMin.Location = new System.Drawing.Point(10, 81);
            this.ntbMin.Name = "ntbMin";
            this.ntbMin.NumberTypes = Shine.Command.Controls.NumberValidate.NumberType.Int;
            this.ntbMin.Size = new System.Drawing.Size(62, 21);
            this.ntbMin.TabIndex = 1;
            this.ntbMin.Leave += new System.EventHandler(this.ntbMin_Leave);
            this.ntbMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ntbMin_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(9, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "图层显示范围";
            // 
            // txtDivName
            // 
            this.txtDivName.Location = new System.Drawing.Point(66, 34);
            this.txtDivName.Name = "txtDivName";
            this.txtDivName.Size = new System.Drawing.Size(100, 21);
            this.txtDivName.TabIndex = 0;
            this.txtDivName.TextType = Shine.TextType.WithOutChar;
            this.txtDivName.Leave += new System.EventHandler(this.txtDivName_Leave);
            this.txtDivName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDivName_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(9, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "图层名称";
            // 
            // btnLoadDiv
            // 
            this.btnLoadDiv.Location = new System.Drawing.Point(104, 415);
            this.btnLoadDiv.Name = "btnLoadDiv";
            this.btnLoadDiv.Size = new System.Drawing.Size(61, 23);
            this.btnLoadDiv.TabIndex = 5;
            this.btnLoadDiv.Text = "加载图层";
            this.btnLoadDiv.UseVisualStyleBackColor = true;
            this.btnLoadDiv.Click += new System.EventHandler(this.btnLoadDiv_Click);
            // 
            // btnTuku
            // 
            this.btnTuku.Location = new System.Drawing.Point(12, 475);
            this.btnTuku.Name = "btnTuku";
            this.btnTuku.Size = new System.Drawing.Size(62, 23);
            this.btnTuku.TabIndex = 6;
            this.btnTuku.Text = "打开图库";
            this.btnTuku.UseVisualStyleBackColor = true;
            this.btnTuku.Visible = false;
            this.btnTuku.Click += new System.EventHandler(this.btnTuku_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(19, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lnkSave
            // 
            this.lnkSave.AutoSize = true;
            this.lnkSave.Location = new System.Drawing.Point(26, 420);
            this.lnkSave.Name = "lnkSave";
            this.lnkSave.Size = new System.Drawing.Size(29, 12);
            this.lnkSave.TabIndex = 17;
            this.lnkSave.TabStop = true;
            this.lnkSave.Text = "保存";
            this.lnkSave.Visible = false;
            this.lnkSave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSave_LinkClicked);
            // 
            // lnkPicList
            // 
            this.lnkPicList.AutoSize = true;
            this.lnkPicList.Location = new System.Drawing.Point(21, 480);
            this.lnkPicList.Name = "lnkPicList";
            this.lnkPicList.Size = new System.Drawing.Size(53, 12);
            this.lnkPicList.TabIndex = 16;
            this.lnkPicList.TabStop = true;
            this.lnkPicList.Text = "打开图库";
            this.lnkPicList.Visible = false;
            this.lnkPicList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPicList_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(112, 420);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "加载图层";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pnlPicList
            // 
            this.pnlPicList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPicList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.pnlPicList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPicList.Controls.Add(this.pnlEmp);
            this.pnlPicList.Controls.Add(this.btnFont);
            this.pnlPicList.Controls.Add(this.btnImg);
            this.pnlPicList.Controls.Add(this.cpStationHead);
            this.pnlPicList.Location = new System.Drawing.Point(840, 121);
            this.pnlPicList.Name = "pnlPicList";
            this.pnlPicList.Size = new System.Drawing.Size(135, 364);
            this.pnlPicList.TabIndex = 2;
            this.pnlPicList.Visible = false;
            // 
            // pnlEmp
            // 
            this.pnlEmp.BackColor = System.Drawing.Color.White;
            this.pnlEmp.Location = new System.Drawing.Point(14, 116);
            this.pnlEmp.Name = "pnlEmp";
            this.pnlEmp.Size = new System.Drawing.Size(133, 190);
            this.pnlEmp.TabIndex = 7;
            this.pnlEmp.Visible = false;
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(0, 79);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(133, 23);
            this.btnFont.TabIndex = 4;
            this.btnFont.Text = "可配置文字";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // btnImg
            // 
            this.btnImg.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnImg.Location = new System.Drawing.Point(0, 22);
            this.btnImg.Name = "btnImg";
            this.btnImg.Size = new System.Drawing.Size(133, 23);
            this.btnImg.TabIndex = 2;
            this.btnImg.Text = "可配置图片";
            this.btnImg.UseVisualStyleBackColor = true;
            this.btnImg.Click += new System.EventHandler(this.btnImg_Click);
            // 
            // cpStationHead
            // 
            this.cpStationHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpStationHead.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpStationHead.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpStationHead.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpStationHead.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpStationHead.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpStationHead.CaptionBottomLineWidth = 1;
            this.cpStationHead.CaptionCloseButtonControlLeft = 2;
            this.cpStationHead.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpStationHead.CaptionCloseButtonTitle = "×";
            this.cpStationHead.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpStationHead.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.cpStationHead.CaptionHeight = 20;
            this.cpStationHead.CaptionLeft = 1;
            this.cpStationHead.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpStationHead.CaptionTitle = "图库";
            this.cpStationHead.CaptionTitleLeft = 10;
            this.cpStationHead.CaptionTitleTop = 4;
            this.cpStationHead.CaptionTop = 1;
            this.cpStationHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.cpStationHead.IsBorderLine = true;
            this.cpStationHead.IsCaptionSingleColor = true;
            this.cpStationHead.IsOnlyCaption = true;
            this.cpStationHead.IsPanelImage = false;
            this.cpStationHead.IsUserButtonClose = true;
            this.cpStationHead.IsUserCaptionBottomLine = false;
            this.cpStationHead.IsUserSystemCloseButtonLeft = true;
            this.cpStationHead.Location = new System.Drawing.Point(0, 0);
            this.cpStationHead.Name = "cpStationHead";
            this.cpStationHead.PanelImage = null;
            this.cpStationHead.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.cpStationHead.Size = new System.Drawing.Size(133, 22);
            this.cpStationHead.TabIndex = 1;
            this.cpStationHead.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cpStationHead_MouseMove);
            this.cpStationHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cpStationHead_MouseDown);
            this.cpStationHead.CloseButtonClick += new System.EventHandler(this.cpStationHead_CloseButtonClick);
            // 
            // trvRealTime
            // 
            this.trvRealTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trvRealTime.Location = new System.Drawing.Point(3, 30);
            this.trvRealTime.Name = "trvRealTime";
            this.trvRealTime.Size = new System.Drawing.Size(172, 314);
            this.trvRealTime.TabIndex = 1;
            // 
            // lsvImg
            // 
            this.lsvImg.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lsvImg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvImg.AutoArrange = false;
            this.lsvImg.GridLines = true;
            this.lsvImg.Location = new System.Drawing.Point(3, 31);
            this.lsvImg.MultiSelect = false;
            this.lsvImg.Name = "lsvImg";
            this.lsvImg.Size = new System.Drawing.Size(172, 288);
            this.lsvImg.TabIndex = 3;
            this.lsvImg.TabStop = false;
            this.lsvImg.UseCompatibleStateImageBehavior = false;
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMove,
            this.tsmiConfig,
            this.tsmiWordConfig,
            this.tsmiDel});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(119, 92);
            // 
            // tsmiMove
            // 
            this.tsmiMove.Name = "tsmiMove";
            this.tsmiMove.Size = new System.Drawing.Size(118, 22);
            this.tsmiMove.Text = "移动";
            this.tsmiMove.Click += new System.EventHandler(this.tsmiMove_Click);
            // 
            // tsmiConfig
            // 
            this.tsmiConfig.Name = "tsmiConfig";
            this.tsmiConfig.Size = new System.Drawing.Size(118, 22);
            this.tsmiConfig.Text = "图片设置";
            this.tsmiConfig.Click += new System.EventHandler(this.tsmiConfig_Click);
            // 
            // tsmiWordConfig
            // 
            this.tsmiWordConfig.Name = "tsmiWordConfig";
            this.tsmiWordConfig.Size = new System.Drawing.Size(118, 22);
            this.tsmiWordConfig.Text = "文字设置";
            this.tsmiWordConfig.Click += new System.EventHandler(this.tsmiWordConfig_Click);
            // 
            // tsmiDel
            // 
            this.tsmiDel.Name = "tsmiDel";
            this.tsmiDel.Size = new System.Drawing.Size(118, 22);
            this.tsmiDel.Text = "删除";
            this.tsmiDel.Click += new System.EventHandler(this.tsmiDel_Click);
            // 
            // MapGis
            // 
            this.MapGis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MapGis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MapGis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MapGis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MapGis.HashNameColor = ((System.Collections.Hashtable)(resources.GetObject("MapGis.HashNameColor")));
            this.MapGis.Index = 0;
            this.MapGis.IsMoving = false;
            this.MapGis.IsPaintRoute = false;
            this.MapGis.IsStationChangeed = false;
            this.MapGis.Location = new System.Drawing.Point(187, -2);
            this.MapGis.MapFilePath = null;
            this.MapGis.MaxWidth = 0;
            this.MapGis.MinWidth = 0;
            this.MapGis.MoverStrColor = System.Drawing.Color.Red;
            this.MapGis.Name = "MapGis";
            this.MapGis.ShowStationOther = false;
            this.MapGis.Size = new System.Drawing.Size(801, 525);
            this.MapGis.StartPoint = ((System.Drawing.PointF)(resources.GetObject("MapGis.StartPoint")));
            this.MapGis.StationFilePath = null;
            this.MapGis.StationStrColor = System.Drawing.Color.Red;
            this.MapGis.StrImpEmpName = "";
            this.MapGis.StrNameAndColor = null;
            this.MapGis.TabIndex = 0;
            this.MapGis.UseDiv = false;
            this.MapGis.UseGif = false;
            this.MapGis.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MapGis_MouseDoubleClick);
            // 
            // dmc
            // 
            this.dmc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dmc.Location = new System.Drawing.Point(1, 1);
            this.dmc.MainHeight = 100;
            this.dmc.Name = "dmc";
            this.dmc.PartTime = 10;
            this.dmc.PType = DegonControlLib.PartType.Time;
            this.dmc.Size = new System.Drawing.Size(183, 406);
            this.dmc.SplitHeight = 1;
            this.dmc.TabIndex = 3;
            this.dmc.TitleHeight = 30;
            // 
            // pnlPic
            // 
            this.pnlPic.Controls.Add(this.btnPic);
            this.pnlPic.Controls.Add(this.lsvImg);
            this.pnlPic.Location = new System.Drawing.Point(419, 53);
            this.pnlPic.Name = "pnlPic";
            this.pnlPic.Size = new System.Drawing.Size(178, 322);
            this.pnlPic.TabIndex = 19;
            this.pnlPic.Visible = false;
            // 
            // btnPic
            // 
            this.btnPic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPic.Location = new System.Drawing.Point(1, 0);
            this.btnPic.Name = "btnPic";
            this.btnPic.Size = new System.Drawing.Size(172, 28);
            this.btnPic.TabIndex = 19;
            this.btnPic.Text = "可配置图片";
            this.btnPic.UseVisualStyleBackColor = true;
            this.btnPic.Click += new System.EventHandler(this.btnPic_Click);
            // 
            // pnlWord
            // 
            this.pnlWord.Controls.Add(this.trvRealTime);
            this.pnlWord.Controls.Add(this.btnWrod);
            this.pnlWord.Location = new System.Drawing.Point(220, 85);
            this.pnlWord.Name = "pnlWord";
            this.pnlWord.Size = new System.Drawing.Size(178, 347);
            this.pnlWord.TabIndex = 20;
            this.pnlWord.Visible = false;
            // 
            // btnWrod
            // 
            this.btnWrod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWrod.Location = new System.Drawing.Point(1, 0);
            this.btnWrod.Name = "btnWrod";
            this.btnWrod.Size = new System.Drawing.Size(172, 28);
            this.btnWrod.TabIndex = 20;
            this.btnWrod.Text = "可配置文字";
            this.btnWrod.UseVisualStyleBackColor = true;
            this.btnWrod.Click += new System.EventHandler(this.btnWrod_Click);
            // 
            // A_frmDivConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Controls.Add(this.pnlWord);
            this.Controls.Add(this.btnLoadDiv);
            this.Controls.Add(this.btnTuku);
            this.Controls.Add(this.pnlPic);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlInOut);
            this.Controls.Add(this.dmc);
            this.Controls.Add(this.lnkSave);
            this.Controls.Add(this.lnkPicList);
            this.Controls.Add(this.pnlPicList);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.MapGis);
            this.Name = "A_frmDivConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "图层配置";
            this.Text = "图层配置";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDivConfig_Load);
            this.Shown += new System.EventHandler(this.A_frmDivConfig_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.A_frmDivConfig_FormClosing);
            this.pnlInOut.ResumeLayout(false);
            this.pnlInOut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStations)).EndInit();
            this.pnlPicList.ResumeLayout(false);
            this.cmsMenu.ResumeLayout(false);
            this.pnlPic.ResumeLayout(false);
            this.pnlWord.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZzhaControlLibrary.ZzhaMapGis MapGis;
        private System.Windows.Forms.Panel pnlInOut;
        private System.Windows.Forms.Label label1;
        private Shine.Command.Controls.NumTextBox ntbMax;
        private System.Windows.Forms.Label label3;
        private Shine.Command.Controls.NumTextBox ntbMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private KJ128NInterfaceShow.DataGridViewKJ128 dgvStations;
        private System.Windows.Forms.LinkLabel lnkAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel lnkPicList;
        private System.Windows.Forms.Panel pnlPicList;
        private KJ128WindowsLibrary.CaptionPanel cpStationHead;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.ListView lsvImg;
        private System.Windows.Forms.Button btnImg;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiConfig;
        private System.Windows.Forms.ToolStripMenuItem tsmiDel;
        private System.Windows.Forms.ToolStripMenuItem tsmiMove;
        private System.Windows.Forms.LinkLabel lnkSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiWordConfig;
        private System.Windows.Forms.Panel pnlEmp;
        private System.Windows.Forms.TreeView trvRealTime;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnLoadDiv;
        private System.Windows.Forms.Button btnTuku;
        private System.Windows.Forms.Button btnSave;
        private Shine.ShineTextBox txtDivName;
        private System.Windows.Forms.Button btnDivConfig;
        private DegonControlLib.DrawerMainControl dmc;
        private System.Windows.Forms.Panel pnlPic;
        private System.Windows.Forms.Button btnPic;
        private System.Windows.Forms.Panel pnlWord;
        private System.Windows.Forms.Button btnWrod;
    }
}