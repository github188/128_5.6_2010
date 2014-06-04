namespace KJ128NMainRun.PathManage
{
    partial class FrmPathDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPathDetail));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("123123");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("所有线路信息", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.sxpPanelGroup1 = new Wilson.Controls.XPPanel.Images.SXPPanelGroup();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.sxpPanel2 = new Wilson.Controls.XPPanel.SXPPanel();
            this.tbPathNo = new Shine.ShineTextBox();
            this.lblPathNo = new System.Windows.Forms.Label();
            this.lblPointPlace = new System.Windows.Forms.Label();
            this.bcpSearch = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.tbPointAddress = new Shine.ShineTextBox();
            this.tbStationAddress = new Shine.ShineTextBox();
            this.lblStationPlace = new System.Windows.Forms.Label();
            this.sxpPanel1 = new Wilson.Controls.XPPanel.SXPPanel();
            this.tvMain = new System.Windows.Forms.TreeView();
            this.bcpRefresh = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cpnlTitle = new KJ128WindowsLibrary.CaptionPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.vspnlAdd = new KJ128WindowsLibrary.VSPanel();
            this.pbStation = new System.Windows.Forms.PictureBox();
            this.cbPiont = new System.Windows.Forms.ComboBox();
            this.lblPoint = new System.Windows.Forms.Label();
            this.pbPoint = new System.Windows.Forms.PictureBox();
            this.cbstation = new System.Windows.Forms.ComboBox();
            this.lblStaionPlace = new System.Windows.Forms.Label();
            this.btnAddOrEdit = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.lblPathId = new System.Windows.Forms.Label();
            this.tbPathNum = new Shine.ShineTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPathN = new Shine.ShineTextBox();
            this.bcpAdd = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.bcpPrint = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.dgvMain = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StationAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StationPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StationHeadAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StationHeadPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cpnlBottom = new KJ128WindowsLibrary.CaptionPanel();
            this.bcp_Add = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cpnlTop = new KJ128WindowsLibrary.CaptionPanel();
            this.bcpRef = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).BeginInit();
            this.sxpPanelGroup1.SuspendLayout();
            this.sxpPanel2.SuspendLayout();
            this.sxpPanel1.SuspendLayout();
            this.vspnlAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.sxpPanelGroup1);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 25);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(220, 579);
            this.pnlLeft.TabIndex = 3;
            // 
            // sxpPanelGroup1
            // 
            this.sxpPanelGroup1.AutoScroll = true;
            this.sxpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanelGroup1.Controls.Add(this.pnlBottom);
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel2);
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel1);
            this.sxpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sxpPanelGroup1.Location = new System.Drawing.Point(0, 0);
            this.sxpPanelGroup1.Name = "sxpPanelGroup1";
            this.sxpPanelGroup1.PanelGradient = ((Wilson.Controls.XPPanel.Colors.GradientColor)(resources.GetObject("sxpPanelGroup1.PanelGradient")));
            this.sxpPanelGroup1.Size = new System.Drawing.Size(218, 577);
            this.sxpPanelGroup1.TabIndex = 13;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Location = new System.Drawing.Point(67, 527);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(48, 15);
            this.pnlBottom.TabIndex = 3;
            this.pnlBottom.Visible = false;
            // 
            // sxpPanel2
            // 
            this.sxpPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sxpPanel2.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanel2.Caption = "查询条件";
            this.sxpPanel2.CaptionCornerType = ((Wilson.Controls.XPPanel.Enums.CornerType)((Wilson.Controls.XPPanel.Enums.CornerType.TopLeft | Wilson.Controls.XPPanel.Enums.CornerType.TopRight)));
            this.sxpPanel2.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.sxpPanel2.CaptionGradient.Start = System.Drawing.Color.White;
            this.sxpPanel2.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel2.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sxpPanel2.Controls.Add(this.tbPathNo);
            this.sxpPanel2.Controls.Add(this.lblPathNo);
            this.sxpPanel2.Controls.Add(this.lblPointPlace);
            this.sxpPanel2.Controls.Add(this.bcpSearch);
            this.sxpPanel2.Controls.Add(this.tbPointAddress);
            this.sxpPanel2.Controls.Add(this.tbStationAddress);
            this.sxpPanel2.Controls.Add(this.lblStationPlace);
            this.sxpPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.sxpPanel2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sxpPanel2.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.sxpPanel2.ImageItems.ImageSet = null;
            this.sxpPanel2.ImageItems.Normal = -1;
            this.sxpPanel2.Location = new System.Drawing.Point(8, 299);
            this.sxpPanel2.Name = "sxpPanel2";
            this.sxpPanel2.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel2.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel2.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel2.Size = new System.Drawing.Size(202, 182);
            this.sxpPanel2.TabIndex = 1;
            this.sxpPanel2.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel2.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel2.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel2.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // tbPathNo
            // 
            this.tbPathNo.Location = new System.Drawing.Point(97, 46);
            this.tbPathNo.Name = "tbPathNo";
            this.tbPathNo.Size = new System.Drawing.Size(98, 20);
            this.tbPathNo.TabIndex = 8;
            this.tbPathNo.TextType = Shine.TextType.WithOutChar;
            // 
            // lblPathNo
            // 
            this.lblPathNo.AutoSize = true;
            this.lblPathNo.Location = new System.Drawing.Point(3, 49);
            this.lblPathNo.Name = "lblPathNo";
            this.lblPathNo.Size = new System.Drawing.Size(72, 13);
            this.lblPathNo.TabIndex = 7;
            this.lblPathNo.Text = "路线编号：";
            // 
            // lblPointPlace
            // 
            this.lblPointPlace.AutoSize = true;
            this.lblPointPlace.Location = new System.Drawing.Point(-1, 115);
            this.lblPointPlace.Name = "lblPointPlace";
            this.lblPointPlace.Size = new System.Drawing.Size(98, 13);
            this.lblPointPlace.TabIndex = 2;
            this.lblPointPlace.Text = "读卡分站地址：";
            // 
            // bcpSearch
            // 
            this.bcpSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpSearch.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpSearch.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpSearch.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.bcpSearch.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.bcpSearch.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpSearch.CaptionBottomLineWidth = 1;
            this.bcpSearch.CaptionCloseButtonControlLeft = 2;
            this.bcpSearch.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpSearch.CaptionCloseButtonTitle = "×";
            this.bcpSearch.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpSearch.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bcpSearch.CaptionHeight = 20;
            this.bcpSearch.CaptionLeft = 1;
            this.bcpSearch.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpSearch.CaptionTitle = "查找";
            this.bcpSearch.CaptionTitleLeft = 8;
            this.bcpSearch.CaptionTitleTop = 4;
            this.bcpSearch.CaptionTop = 1;
            this.bcpSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcpSearch.IsBorderLine = true;
            this.bcpSearch.IsCaptionSingleColor = false;
            this.bcpSearch.IsOnlyCaption = true;
            this.bcpSearch.IsPanelImage = true;
            this.bcpSearch.IsUserButtonClose = false;
            this.bcpSearch.IsUserCaptionBottomLine = false;
            this.bcpSearch.IsUserSystemCloseButtonLeft = true;
            this.bcpSearch.Location = new System.Drawing.Point(146, 140);
            this.bcpSearch.Name = "bcpSearch";
            this.bcpSearch.PanelImage = null;
            this.bcpSearch.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpSearch.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpSearch.Size = new System.Drawing.Size(49, 22);
            this.bcpSearch.TabIndex = 6;
            this.bcpSearch.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpSearch.Click += new System.EventHandler(this.bcpSearch_Click);
            // 
            // tbPointAddress
            // 
            this.tbPointAddress.Location = new System.Drawing.Point(97, 112);
            this.tbPointAddress.Name = "tbPointAddress";
            this.tbPointAddress.Size = new System.Drawing.Size(98, 20);
            this.tbPointAddress.TabIndex = 3;
            this.tbPointAddress.TextType = Shine.TextType.WithOutChar;
            // 
            // tbStationAddress
            // 
            this.tbStationAddress.Location = new System.Drawing.Point(97, 79);
            this.tbStationAddress.Name = "tbStationAddress";
            this.tbStationAddress.Size = new System.Drawing.Size(98, 20);
            this.tbStationAddress.TabIndex = 5;
            this.tbStationAddress.TextType = Shine.TextType.WithOutChar;
            // 
            // lblStationPlace
            // 
            this.lblStationPlace.AutoSize = true;
            this.lblStationPlace.Location = new System.Drawing.Point(0, 82);
            this.lblStationPlace.Name = "lblStationPlace";
            this.lblStationPlace.Size = new System.Drawing.Size(98, 13);
            this.lblStationPlace.TabIndex = 4;
            this.lblStationPlace.Text = "传输分站地址：";
            // 
            // sxpPanel1
            // 
            this.sxpPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sxpPanel1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanel1.Caption = "路线信息";
            this.sxpPanel1.CaptionCornerType = ((Wilson.Controls.XPPanel.Enums.CornerType)((Wilson.Controls.XPPanel.Enums.CornerType.TopLeft | Wilson.Controls.XPPanel.Enums.CornerType.TopRight)));
            this.sxpPanel1.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.sxpPanel1.CaptionGradient.Start = System.Drawing.Color.White;
            this.sxpPanel1.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel1.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sxpPanel1.Controls.Add(this.tvMain);
            this.sxpPanel1.Controls.Add(this.bcpRefresh);
            this.sxpPanel1.Controls.Add(this.cpnlTitle);
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
            this.sxpPanel1.Size = new System.Drawing.Size(202, 283);
            this.sxpPanel1.TabIndex = 0;
            this.sxpPanel1.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel1.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel1.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel1.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // tvMain
            // 
            this.tvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMain.Location = new System.Drawing.Point(2, 61);
            this.tvMain.Name = "tvMain";
            treeNode1.Name = "1";
            treeNode1.Text = "123123";
            treeNode2.Name = "ParentNode";
            treeNode2.Text = "所有线路信息";
            this.tvMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.tvMain.ShowNodeToolTips = true;
            this.tvMain.ShowRootLines = false;
            this.tvMain.Size = new System.Drawing.Size(198, 219);
            this.tvMain.TabIndex = 4;
            this.tvMain.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvMain_NodeMouseClick);
            // 
            // bcpRefresh
            // 
            this.bcpRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpRefresh.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpRefresh.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpRefresh.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.bcpRefresh.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.bcpRefresh.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpRefresh.CaptionBottomLineWidth = 1;
            this.bcpRefresh.CaptionCloseButtonControlLeft = 2;
            this.bcpRefresh.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpRefresh.CaptionCloseButtonTitle = "×";
            this.bcpRefresh.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpRefresh.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bcpRefresh.CaptionHeight = 20;
            this.bcpRefresh.CaptionLeft = 1;
            this.bcpRefresh.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpRefresh.CaptionTitle = "刷新";
            this.bcpRefresh.CaptionTitleLeft = 8;
            this.bcpRefresh.CaptionTitleTop = 4;
            this.bcpRefresh.CaptionTop = 1;
            this.bcpRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcpRefresh.IsBorderLine = true;
            this.bcpRefresh.IsCaptionSingleColor = false;
            this.bcpRefresh.IsOnlyCaption = true;
            this.bcpRefresh.IsPanelImage = true;
            this.bcpRefresh.IsUserButtonClose = false;
            this.bcpRefresh.IsUserCaptionBottomLine = false;
            this.bcpRefresh.IsUserSystemCloseButtonLeft = true;
            this.bcpRefresh.Location = new System.Drawing.Point(145, 37);
            this.bcpRefresh.Name = "bcpRefresh";
            this.bcpRefresh.PanelImage = null;
            this.bcpRefresh.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpRefresh.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpRefresh.Size = new System.Drawing.Size(46, 22);
            this.bcpRefresh.TabIndex = 1;
            this.bcpRefresh.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpRefresh.Click += new System.EventHandler(this.bcpRefresh_Click);
            // 
            // cpnlTitle
            // 
            this.cpnlTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpnlTitle.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpnlTitle.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.cpnlTitle.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpnlTitle.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpnlTitle.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpnlTitle.CaptionBottomLineWidth = 1;
            this.cpnlTitle.CaptionCloseButtonControlLeft = 2;
            this.cpnlTitle.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpnlTitle.CaptionCloseButtonTitle = "×";
            this.cpnlTitle.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpnlTitle.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cpnlTitle.CaptionHeight = 25;
            this.cpnlTitle.CaptionLeft = 1;
            this.cpnlTitle.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpnlTitle.CaptionTitle = "路线详细信息";
            this.cpnlTitle.CaptionTitleLeft = 8;
            this.cpnlTitle.CaptionTitleTop = 4;
            this.cpnlTitle.CaptionTop = 1;
            this.cpnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cpnlTitle.IsBorderLine = true;
            this.cpnlTitle.IsCaptionSingleColor = false;
            this.cpnlTitle.IsOnlyCaption = false;
            this.cpnlTitle.IsPanelImage = false;
            this.cpnlTitle.IsUserButtonClose = false;
            this.cpnlTitle.IsUserCaptionBottomLine = true;
            this.cpnlTitle.IsUserSystemCloseButtonLeft = true;
            this.cpnlTitle.Location = new System.Drawing.Point(2, 35);
            this.cpnlTitle.Name = "cpnlTitle";
            this.cpnlTitle.PanelImage = null;
            this.cpnlTitle.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.cpnlTitle.Size = new System.Drawing.Size(198, 26);
            this.cpnlTitle.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // vspnlAdd
            // 
            this.vspnlAdd.BackLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.vspnlAdd.BetweenControlCount = 2;
            this.vspnlAdd.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.vspnlAdd.BottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.vspnlAdd.Controls.Add(this.pbStation);
            this.vspnlAdd.Controls.Add(this.cbPiont);
            this.vspnlAdd.Controls.Add(this.lblPoint);
            this.vspnlAdd.Controls.Add(this.pbPoint);
            this.vspnlAdd.Controls.Add(this.cbstation);
            this.vspnlAdd.Controls.Add(this.lblStaionPlace);
            this.vspnlAdd.Controls.Add(this.btnAddOrEdit);
            this.vspnlAdd.Controls.Add(this.lblPathId);
            this.vspnlAdd.Controls.Add(this.tbPathNum);
            this.vspnlAdd.Controls.Add(this.label1);
            this.vspnlAdd.Controls.Add(this.tbPathN);
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
            this.vspnlAdd.Location = new System.Drawing.Point(444, 168);
            this.vspnlAdd.MiddleInterval = 80;
            this.vspnlAdd.Name = "vspnlAdd";
            this.vspnlAdd.RightInterval = 0;
            this.vspnlAdd.SetBackGroundStyle = KJ128WindowsLibrary.VsPaneBackGroundStyle.windowsStyle;
            this.vspnlAdd.Size = new System.Drawing.Size(270, 187);
            this.vspnlAdd.TabIndex = 11;
            this.vspnlAdd.TopInterval = 0;
            this.vspnlAdd.VerticalInterval = 8;
            this.vspnlAdd.Visible = false;
            // 
            // pbStation
            // 
            this.pbStation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbStation.Image = global::KJ128NMainRun.Properties.Resources.re;
            this.pbStation.Location = new System.Drawing.Point(245, 101);
            this.pbStation.Name = "pbStation";
            this.pbStation.Size = new System.Drawing.Size(18, 17);
            this.pbStation.TabIndex = 18;
            this.pbStation.TabStop = false;
            this.pbStation.Click += new System.EventHandler(this.pbStation_Click);
            // 
            // cbPiont
            // 
            this.cbPiont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPiont.FormattingEnabled = true;
            this.cbPiont.Location = new System.Drawing.Point(107, 129);
            this.cbPiont.Name = "cbPiont";
            this.cbPiont.Size = new System.Drawing.Size(132, 20);
            this.cbPiont.TabIndex = 17;
            this.cbPiont.SelectedIndexChanged += new System.EventHandler(this.cbPiont_SelectedIndexChanged);
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.Location = new System.Drawing.Point(2, 132);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(113, 12);
            this.lblPoint.TabIndex = 16;
            this.lblPoint.Text = "读卡分站安装位置：";
            // 
            // pbPoint
            // 
            this.pbPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPoint.Image = global::KJ128NMainRun.Properties.Resources.re;
            this.pbPoint.Location = new System.Drawing.Point(245, 129);
            this.pbPoint.Name = "pbPoint";
            this.pbPoint.Size = new System.Drawing.Size(18, 17);
            this.pbPoint.TabIndex = 15;
            this.pbPoint.TabStop = false;
            this.pbPoint.Click += new System.EventHandler(this.pbPoint_Click);
            // 
            // cbstation
            // 
            this.cbstation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbstation.FormattingEnabled = true;
            this.cbstation.Location = new System.Drawing.Point(108, 98);
            this.cbstation.Name = "cbstation";
            this.cbstation.Size = new System.Drawing.Size(131, 20);
            this.cbstation.TabIndex = 14;
            this.cbstation.SelectedIndexChanged += new System.EventHandler(this.cbstation_SelectedIndexChanged);
            // 
            // lblStaionPlace
            // 
            this.lblStaionPlace.AutoSize = true;
            this.lblStaionPlace.Location = new System.Drawing.Point(2, 101);
            this.lblStaionPlace.Name = "lblStaionPlace";
            this.lblStaionPlace.Size = new System.Drawing.Size(113, 12);
            this.lblStaionPlace.TabIndex = 12;
            this.lblStaionPlace.Text = "传输分站安装位置：";
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
            this.btnAddOrEdit.Location = new System.Drawing.Point(202, 157);
            this.btnAddOrEdit.Name = "btnAddOrEdit";
            this.btnAddOrEdit.PanelImage = null;
            this.btnAddOrEdit.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnAddOrEdit.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnAddOrEdit.Size = new System.Drawing.Size(61, 22);
            this.btnAddOrEdit.TabIndex = 10;
            this.btnAddOrEdit.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnAddOrEdit.Click += new System.EventHandler(this.btnAddOrEdit_Click);
            // 
            // lblPathId
            // 
            this.lblPathId.AutoSize = true;
            this.lblPathId.Location = new System.Drawing.Point(16, 33);
            this.lblPathId.Name = "lblPathId";
            this.lblPathId.Size = new System.Drawing.Size(65, 12);
            this.lblPathId.TabIndex = 8;
            this.lblPathId.Text = "路线编号：";
            // 
            // tbPathNum
            // 
            this.tbPathNum.Location = new System.Drawing.Point(107, 33);
            this.tbPathNum.Name = "tbPathNum";
            this.tbPathNum.ReadOnly = true;
            this.tbPathNum.Size = new System.Drawing.Size(134, 21);
            this.tbPathNum.TabIndex = 7;
            this.tbPathNum.TextType = Shine.TextType.WithOutChar;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "路 线 名：";
            // 
            // tbPathN
            // 
            this.tbPathN.Location = new System.Drawing.Point(107, 65);
            this.tbPathN.Name = "tbPathN";
            this.tbPathN.ReadOnly = true;
            this.tbPathN.Size = new System.Drawing.Size(134, 21);
            this.tbPathN.TabIndex = 4;
            this.tbPathN.TextType = Shine.TextType.WithOutChar;
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
            this.bcpAdd.CaptionTitle = "增加读卡分站信息";
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
            this.bcpAdd.Size = new System.Drawing.Size(270, 22);
            this.bcpAdd.TabIndex = 0;
            this.bcpAdd.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bcpAdd_MouseUp);
            this.bcpAdd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bcpAdd_MouseMove);
            this.bcpAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bcpAdd_MouseDown);
            this.bcpAdd.CloseButtonClick += new System.EventHandler(this.bcpAdd_CloseButtonClick);
            // 
            // bcpPrint
            // 
            this.bcpPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bcpPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpPrint.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpPrint.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpPrint.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.bcpPrint.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.bcpPrint.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpPrint.CaptionBottomLineWidth = 1;
            this.bcpPrint.CaptionCloseButtonControlLeft = 2;
            this.bcpPrint.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpPrint.CaptionCloseButtonTitle = "×";
            this.bcpPrint.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpPrint.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bcpPrint.CaptionHeight = 20;
            this.bcpPrint.CaptionLeft = 1;
            this.bcpPrint.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpPrint.CaptionTitle = "打印";
            this.bcpPrint.CaptionTitleLeft = 8;
            this.bcpPrint.CaptionTitleTop = 4;
            this.bcpPrint.CaptionTop = 1;
            this.bcpPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcpPrint.IsBorderLine = true;
            this.bcpPrint.IsCaptionSingleColor = false;
            this.bcpPrint.IsOnlyCaption = true;
            this.bcpPrint.IsPanelImage = true;
            this.bcpPrint.IsUserButtonClose = false;
            this.bcpPrint.IsUserCaptionBottomLine = false;
            this.bcpPrint.IsUserSystemCloseButtonLeft = true;
            this.bcpPrint.Location = new System.Drawing.Point(962, 1);
            this.bcpPrint.Name = "bcpPrint";
            this.bcpPrint.PanelImage = null;
            this.bcpPrint.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpPrint.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpPrint.Size = new System.Drawing.Size(63, 22);
            this.bcpPrint.TabIndex = 12;
            this.bcpPrint.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpPrint.Click += new System.EventHandler(this.bcpPrint_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.dgvMain.ColumnHeadersHeight = 30;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.PathNo,
            this.PathName,
            this.StationAddress,
            this.StationPlace,
            this.StationHeadAddress,
            this.StationHeadPlace,
            this.edit,
            this.delete});
            this.dgvMain.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.BlueStyle;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(191)))), ((int)(((byte)(219)))));
            this.dgvMain.Location = new System.Drawing.Point(220, 25);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dgvMain.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(808, 579);
            this.dgvMain.TabIndex = 10;
            this.dgvMain.VerticalScrollBarMax = 1;
            this.dgvMain.VerticalScrollBarValue = 0;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgvMain_CellClick);
            this.dgvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgvMain_CellContentClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // PathNo
            // 
            this.PathNo.DataPropertyName = "PathNo";
            this.PathNo.HeaderText = "路线编号";
            this.PathNo.Name = "PathNo";
            this.PathNo.ReadOnly = true;
            // 
            // PathName
            // 
            this.PathName.DataPropertyName = "PathName";
            this.PathName.HeaderText = "路线名称";
            this.PathName.Name = "PathName";
            this.PathName.ReadOnly = true;
            // 
            // StationAddress
            // 
            this.StationAddress.DataPropertyName = "StationAddress";
            this.StationAddress.HeaderText = "传输分站编号";
            this.StationAddress.Name = "StationAddress";
            this.StationAddress.ReadOnly = true;
            // 
            // StationPlace
            // 
            this.StationPlace.DataPropertyName = "StationPlace";
            this.StationPlace.HeaderText = "传输分站安装位置";
            this.StationPlace.Name = "StationPlace";
            this.StationPlace.ReadOnly = true;
            // 
            // StationHeadAddress
            // 
            this.StationHeadAddress.DataPropertyName = "StationHeadAddress";
            this.StationHeadAddress.HeaderText = "读卡分站编号";
            this.StationHeadAddress.Name = "StationHeadAddress";
            this.StationHeadAddress.ReadOnly = true;
            // 
            // StationHeadPlace
            // 
            this.StationHeadPlace.DataPropertyName = "StationHeadPlace";
            this.StationHeadPlace.HeaderText = "读卡分站安装位置";
            this.StationHeadPlace.Name = "StationHeadPlace";
            this.StationHeadPlace.ReadOnly = true;
            // 
            // edit
            // 
            this.edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.edit.HeaderText = "修改信息";
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Text = "修改";
            this.edit.TrackVisitedState = false;
            this.edit.UseColumnTextForLinkValue = true;
            this.edit.Width = 60;
            // 
            // delete
            // 
            this.delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.delete.HeaderText = "删除信息";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "删除";
            this.delete.TrackVisitedState = false;
            this.delete.UseColumnTextForLinkValue = true;
            this.delete.Width = 60;
            // 
            // cpnlBottom
            // 
            this.cpnlBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpnlBottom.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpnlBottom.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.cpnlBottom.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpnlBottom.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpnlBottom.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpnlBottom.CaptionBottomLineWidth = 1;
            this.cpnlBottom.CaptionCloseButtonControlLeft = 2;
            this.cpnlBottom.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpnlBottom.CaptionCloseButtonTitle = "×";
            this.cpnlBottom.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpnlBottom.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cpnlBottom.CaptionHeight = 25;
            this.cpnlBottom.CaptionLeft = 1;
            this.cpnlBottom.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpnlBottom.CaptionTitle = "";
            this.cpnlBottom.CaptionTitleLeft = 8;
            this.cpnlBottom.CaptionTitleTop = 4;
            this.cpnlBottom.CaptionTop = 1;
            this.cpnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cpnlBottom.IsBorderLine = true;
            this.cpnlBottom.IsCaptionSingleColor = false;
            this.cpnlBottom.IsOnlyCaption = false;
            this.cpnlBottom.IsPanelImage = false;
            this.cpnlBottom.IsUserButtonClose = false;
            this.cpnlBottom.IsUserCaptionBottomLine = true;
            this.cpnlBottom.IsUserSystemCloseButtonLeft = true;
            this.cpnlBottom.Location = new System.Drawing.Point(0, 604);
            this.cpnlBottom.Name = "cpnlBottom";
            this.cpnlBottom.PanelImage = null;
            this.cpnlBottom.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.cpnlBottom.Size = new System.Drawing.Size(1028, 27);
            this.cpnlBottom.TabIndex = 2;
            // 
            // bcp_Add
            // 
            this.bcp_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bcp_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcp_Add.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcp_Add.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcp_Add.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.bcp_Add.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.bcp_Add.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcp_Add.CaptionBottomLineWidth = 1;
            this.bcp_Add.CaptionCloseButtonControlLeft = 2;
            this.bcp_Add.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcp_Add.CaptionCloseButtonTitle = "×";
            this.bcp_Add.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcp_Add.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bcp_Add.CaptionHeight = 20;
            this.bcp_Add.CaptionLeft = 1;
            this.bcp_Add.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcp_Add.CaptionTitle = "增加读卡分站";
            this.bcp_Add.CaptionTitleLeft = 8;
            this.bcp_Add.CaptionTitleTop = 4;
            this.bcp_Add.CaptionTop = 1;
            this.bcp_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcp_Add.IsBorderLine = true;
            this.bcp_Add.IsCaptionSingleColor = false;
            this.bcp_Add.IsOnlyCaption = true;
            this.bcp_Add.IsPanelImage = true;
            this.bcp_Add.IsUserButtonClose = false;
            this.bcp_Add.IsUserCaptionBottomLine = false;
            this.bcp_Add.IsUserSystemCloseButtonLeft = true;
            this.bcp_Add.Location = new System.Drawing.Point(860, 2);
            this.bcp_Add.Name = "bcp_Add";
            this.bcp_Add.PanelImage = null;
            this.bcp_Add.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcp_Add.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcp_Add.Size = new System.Drawing.Size(100, 22);
            this.bcp_Add.TabIndex = 1;
            this.bcp_Add.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcp_Add.Click += new System.EventHandler(this.bcp_Add_Click);
            // 
            // cpnlTop
            // 
            this.cpnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpnlTop.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpnlTop.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpnlTop.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpnlTop.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpnlTop.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpnlTop.CaptionBottomLineWidth = 1;
            this.cpnlTop.CaptionCloseButtonControlLeft = 2;
            this.cpnlTop.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpnlTop.CaptionCloseButtonTitle = "×";
            this.cpnlTop.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpnlTop.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cpnlTop.CaptionHeight = 25;
            this.cpnlTop.CaptionLeft = 1;
            this.cpnlTop.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpnlTop.CaptionTitle = "路线详细信息设置";
            this.cpnlTop.CaptionTitleLeft = 8;
            this.cpnlTop.CaptionTitleTop = 4;
            this.cpnlTop.CaptionTop = 1;
            this.cpnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.cpnlTop.IsBorderLine = true;
            this.cpnlTop.IsCaptionSingleColor = false;
            this.cpnlTop.IsOnlyCaption = false;
            this.cpnlTop.IsPanelImage = false;
            this.cpnlTop.IsUserButtonClose = false;
            this.cpnlTop.IsUserCaptionBottomLine = true;
            this.cpnlTop.IsUserSystemCloseButtonLeft = true;
            this.cpnlTop.Location = new System.Drawing.Point(0, 0);
            this.cpnlTop.Name = "cpnlTop";
            this.cpnlTop.PanelImage = null;
            this.cpnlTop.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.cpnlTop.Size = new System.Drawing.Size(1028, 25);
            this.cpnlTop.TabIndex = 0;
            // 
            // bcpRef
            // 
            this.bcpRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bcpRef.AutoSize = true;
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
            this.bcpRef.CaptionTitle = " 刷 新";
            this.bcpRef.CaptionTitleLeft = 8;
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
            this.bcpRef.Location = new System.Drawing.Point(795, 2);
            this.bcpRef.Name = "bcpRef";
            this.bcpRef.PanelImage = null;
            this.bcpRef.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpRef.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpRef.Size = new System.Drawing.Size(63, 22);
            this.bcpRef.TabIndex = 13;
            this.bcpRef.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpRef.Click += new System.EventHandler(this.bcpRef_Click);
            // 
            // FrmPathDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1028, 631);
            this.Controls.Add(this.bcpRef);
            this.Controls.Add(this.vspnlAdd);
            this.Controls.Add(this.bcpPrint);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.cpnlBottom);
            this.Controls.Add(this.bcp_Add);
            this.Controls.Add(this.cpnlTop);
            this.Name = "FrmPathDetail";
            this.TabText = "路线详细信息";
            this.Text = "路线详细信息";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPathDetail_Load);
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).EndInit();
            this.sxpPanelGroup1.ResumeLayout(false);
            this.sxpPanel2.ResumeLayout(false);
            this.sxpPanel2.PerformLayout();
            this.sxpPanel1.ResumeLayout(false);
            this.vspnlAdd.ResumeLayout(false);
            this.vspnlAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KJ128WindowsLibrary.CaptionPanel cpnlTop;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcp_Add;
        private KJ128WindowsLibrary.CaptionPanel cpnlBottom;
        private System.Windows.Forms.Panel pnlLeft;
        private KJ128WindowsLibrary.CaptionPanel cpnlTitle;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpRefresh;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.TreeView tvMain;
        private System.Windows.Forms.Label lblPointPlace;
        private System.Windows.Forms.Label lblStationPlace;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpSearch;
        private KJ128WindowsLibrary.VSPanel vspnlAdd;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnAddOrEdit;
        private System.Windows.Forms.Label lblPathId;
        private System.Windows.Forms.Label label1;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpAdd;
        private System.Windows.Forms.Label lblStaionPlace;
        private System.Windows.Forms.ComboBox cbstation;
        private System.Windows.Forms.PictureBox pbPoint;
        private System.Windows.Forms.ComboBox cbPiont;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.PictureBox pbStation;
        private System.Windows.Forms.Label lblPathNo;
        private KJ128NInterfaceShow.DataGridViewKJ128 dgvMain;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpPrint;
        private Wilson.Controls.XPPanel.Images.SXPPanelGroup sxpPanelGroup1;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel1;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel2;
        private Shine.ShineTextBox tbPointAddress;
        private Shine.ShineTextBox tbStationAddress;
        private Shine.ShineTextBox tbPathNum;
        private Shine.ShineTextBox tbPathN;
        private Shine.ShineTextBox tbPathNo;
        private System.Windows.Forms.Timer timer1;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationHeadAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationHeadPlace;
        private System.Windows.Forms.DataGridViewLinkColumn edit;
        private System.Windows.Forms.DataGridViewLinkColumn delete;

    }
}