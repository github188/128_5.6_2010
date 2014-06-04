namespace KJ128NMainRun.PathManage
{
    partial class FrmPathEmp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPathEmp));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("所有路线信息");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.sxpPanelGroup1 = new Wilson.Controls.XPPanel.Images.SXPPanelGroup();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.sxpPanel2 = new Wilson.Controls.XPPanel.SXPPanel();
            this.lblPNo = new System.Windows.Forms.Label();
            this.tbEmpName = new Shine.ShineTextBox();
            this.tbPNo = new Shine.ShineTextBox();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.lblPName = new System.Windows.Forms.Label();
            this.tbEmpNo = new Shine.ShineTextBox();
            this.tbPName = new Shine.ShineTextBox();
            this.lblEmpNo = new System.Windows.Forms.Label();
            this.sxpPanel1 = new Wilson.Controls.XPPanel.SXPPanel();
            this.tvMain = new System.Windows.Forms.TreeView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bcpRef = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.bcpPrint = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.vspnlAdd = new KJ128WindowsLibrary.VSPanel();
            this.pbDept = new System.Windows.Forms.PictureBox();
            this.cbDept = new System.Windows.Forms.ComboBox();
            this.lblDept = new System.Windows.Forms.Label();
            this.pbEmp = new System.Windows.Forms.PictureBox();
            this.cbEmp = new System.Windows.Forms.ComboBox();
            this.lblEmp = new System.Windows.Forms.Label();
            this.btnAddOrEdit = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.lblPathName = new System.Windows.Forms.Label();
            this.lblPathNo = new System.Windows.Forms.Label();
            this.tbPathName = new Shine.ShineTextBox();
            this.tbPathNo = new Shine.ShineTextBox();
            this.bcpAdd = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.bcpAddInfo = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.dgvMain = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.bcpSearch = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.bcpRefresh = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cpnlTitle = new KJ128WindowsLibrary.CaptionPanel();
            this.cpnlBootom = new KJ128WindowsLibrary.CaptionPanel();
            this.cpnlTop = new KJ128WindowsLibrary.CaptionPanel();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).BeginInit();
            this.sxpPanelGroup1.SuspendLayout();
            this.sxpPanel2.SuspendLayout();
            this.sxpPanel1.SuspendLayout();
            this.vspnlAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.sxpPanelGroup1);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 26);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(220, 616);
            this.pnlLeft.TabIndex = 4;
            // 
            // sxpPanelGroup1
            // 
            this.sxpPanelGroup1.AutoScroll = true;
            this.sxpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanelGroup1.Controls.Add(this.pnlSearch);
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel2);
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel1);
            this.sxpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sxpPanelGroup1.Location = new System.Drawing.Point(0, 0);
            this.sxpPanelGroup1.Name = "sxpPanelGroup1";
            this.sxpPanelGroup1.PanelGradient = ((Wilson.Controls.XPPanel.Colors.GradientColor)(resources.GetObject("sxpPanelGroup1.PanelGradient")));
            this.sxpPanelGroup1.Size = new System.Drawing.Size(218, 614);
            this.sxpPanelGroup1.TabIndex = 14;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Location = new System.Drawing.Point(28, 512);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(48, 42);
            this.pnlSearch.TabIndex = 3;
            this.pnlSearch.Visible = false;
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
            this.sxpPanel2.Controls.Add(this.bcpSearch);
            this.sxpPanel2.Controls.Add(this.lblPNo);
            this.sxpPanel2.Controls.Add(this.tbEmpName);
            this.sxpPanel2.Controls.Add(this.tbPNo);
            this.sxpPanel2.Controls.Add(this.lblEmpName);
            this.sxpPanel2.Controls.Add(this.lblPName);
            this.sxpPanel2.Controls.Add(this.tbEmpNo);
            this.sxpPanel2.Controls.Add(this.tbPName);
            this.sxpPanel2.Controls.Add(this.lblEmpNo);
            this.sxpPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.sxpPanel2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sxpPanel2.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.sxpPanel2.ImageItems.ImageSet = null;
            this.sxpPanel2.ImageItems.Normal = -1;
            this.sxpPanel2.Location = new System.Drawing.Point(8, 312);
            this.sxpPanel2.Name = "sxpPanel2";
            this.sxpPanel2.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel2.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel2.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel2.Size = new System.Drawing.Size(202, 192);
            this.sxpPanel2.TabIndex = 14;
            this.sxpPanel2.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel2.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel2.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel2.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // lblPNo
            // 
            this.lblPNo.AutoSize = true;
            this.lblPNo.Location = new System.Drawing.Point(3, 44);
            this.lblPNo.Name = "lblPNo";
            this.lblPNo.Size = new System.Drawing.Size(72, 13);
            this.lblPNo.TabIndex = 0;
            this.lblPNo.Text = "路线编号：";
            // 
            // tbEmpName
            // 
            this.tbEmpName.Location = new System.Drawing.Point(75, 131);
            this.tbEmpName.Name = "tbEmpName";
            this.tbEmpName.Size = new System.Drawing.Size(117, 20);
            this.tbEmpName.TabIndex = 7;
            this.tbEmpName.TextType = Shine.TextType.WithOutChar;
            // 
            // tbPNo
            // 
            this.tbPNo.Location = new System.Drawing.Point(75, 40);
            this.tbPNo.Name = "tbPNo";
            this.tbPNo.Size = new System.Drawing.Size(117, 20);
            this.tbPNo.TabIndex = 1;
            this.tbPNo.TextType = Shine.TextType.WithOutChar;
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Location = new System.Drawing.Point(3, 135);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(72, 13);
            this.lblEmpName.TabIndex = 6;
            this.lblEmpName.Text = "员工姓名：";
            // 
            // lblPName
            // 
            this.lblPName.AutoSize = true;
            this.lblPName.Location = new System.Drawing.Point(3, 74);
            this.lblPName.Name = "lblPName";
            this.lblPName.Size = new System.Drawing.Size(72, 13);
            this.lblPName.TabIndex = 2;
            this.lblPName.Text = "路线名称：";
            // 
            // tbEmpNo
            // 
            this.tbEmpNo.Location = new System.Drawing.Point(75, 100);
            this.tbEmpNo.Name = "tbEmpNo";
            this.tbEmpNo.Size = new System.Drawing.Size(117, 20);
            this.tbEmpNo.TabIndex = 5;
            this.tbEmpNo.TextType = Shine.TextType.WithOutChar;
            // 
            // tbPName
            // 
            this.tbPName.Location = new System.Drawing.Point(75, 70);
            this.tbPName.Name = "tbPName";
            this.tbPName.Size = new System.Drawing.Size(117, 20);
            this.tbPName.TabIndex = 3;
            this.tbPName.TextType = Shine.TextType.WithOutChar;
            // 
            // lblEmpNo
            // 
            this.lblEmpNo.AutoSize = true;
            this.lblEmpNo.Location = new System.Drawing.Point(3, 104);
            this.lblEmpNo.Name = "lblEmpNo";
            this.lblEmpNo.Size = new System.Drawing.Size(72, 13);
            this.lblEmpNo.TabIndex = 4;
            this.lblEmpNo.Text = "员工编号：";
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
            this.sxpPanel1.Size = new System.Drawing.Size(202, 296);
            this.sxpPanel1.TabIndex = 14;
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
            treeNode1.Name = "parentNode";
            treeNode1.Text = "所有路线信息";
            this.tvMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvMain.ShowNodeToolTips = true;
            this.tvMain.ShowRootLines = false;
            this.tvMain.Size = new System.Drawing.Size(198, 232);
            this.tvMain.TabIndex = 4;
            this.tvMain.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvMain_NodeMouseClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.bcpRef.Location = new System.Drawing.Point(826, 2);
            this.bcpRef.Name = "bcpRef";
            this.bcpRef.PanelImage = null;
            this.bcpRef.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpRef.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpRef.Size = new System.Drawing.Size(63, 22);
            this.bcpRef.TabIndex = 14;
            this.bcpRef.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpRef.Click += new System.EventHandler(this.bcpRef_Click);
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
            this.bcpPrint.Location = new System.Drawing.Point(949, 2);
            this.bcpPrint.Name = "bcpPrint";
            this.bcpPrint.PanelImage = null;
            this.bcpPrint.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpPrint.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpPrint.Size = new System.Drawing.Size(47, 22);
            this.bcpPrint.TabIndex = 13;
            this.bcpPrint.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpPrint.Click += new System.EventHandler(this.bcpPrint_Click);
            // 
            // vspnlAdd
            // 
            this.vspnlAdd.BackLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.vspnlAdd.BetweenControlCount = 2;
            this.vspnlAdd.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.vspnlAdd.BottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.vspnlAdd.Controls.Add(this.pbDept);
            this.vspnlAdd.Controls.Add(this.cbDept);
            this.vspnlAdd.Controls.Add(this.lblDept);
            this.vspnlAdd.Controls.Add(this.pbEmp);
            this.vspnlAdd.Controls.Add(this.cbEmp);
            this.vspnlAdd.Controls.Add(this.lblEmp);
            this.vspnlAdd.Controls.Add(this.btnAddOrEdit);
            this.vspnlAdd.Controls.Add(this.lblPathName);
            this.vspnlAdd.Controls.Add(this.lblPathNo);
            this.vspnlAdd.Controls.Add(this.tbPathName);
            this.vspnlAdd.Controls.Add(this.tbPathNo);
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
            this.vspnlAdd.Location = new System.Drawing.Point(427, 127);
            this.vspnlAdd.MiddleInterval = 80;
            this.vspnlAdd.Name = "vspnlAdd";
            this.vspnlAdd.RightInterval = 0;
            this.vspnlAdd.SetBackGroundStyle = KJ128WindowsLibrary.VsPaneBackGroundStyle.windowsStyle;
            this.vspnlAdd.Size = new System.Drawing.Size(253, 187);
            this.vspnlAdd.TabIndex = 11;
            this.vspnlAdd.TopInterval = 0;
            this.vspnlAdd.VerticalInterval = 8;
            this.vspnlAdd.Visible = false;
            // 
            // pbDept
            // 
            this.pbDept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDept.Image = global::KJ128NMainRun.Properties.Resources.re;
            this.pbDept.Location = new System.Drawing.Point(222, 99);
            this.pbDept.Name = "pbDept";
            this.pbDept.Size = new System.Drawing.Size(18, 17);
            this.pbDept.TabIndex = 19;
            this.pbDept.TabStop = false;
            this.pbDept.Click += new System.EventHandler(this.pbDept_Click);
            // 
            // cbDept
            // 
            this.cbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDept.FormattingEnabled = true;
            this.cbDept.Location = new System.Drawing.Point(85, 98);
            this.cbDept.Name = "cbDept";
            this.cbDept.Size = new System.Drawing.Size(131, 20);
            this.cbDept.TabIndex = 18;
            this.cbDept.SelectedIndexChanged += new System.EventHandler(this.cbDept_SelectedIndexChanged);
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Location = new System.Drawing.Point(16, 102);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(65, 12);
            this.lblDept.TabIndex = 17;
            this.lblDept.Text = "部门名称：";
            // 
            // pbEmp
            // 
            this.pbEmp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbEmp.Image = global::KJ128NMainRun.Properties.Resources.re;
            this.pbEmp.Location = new System.Drawing.Point(222, 125);
            this.pbEmp.Name = "pbEmp";
            this.pbEmp.Size = new System.Drawing.Size(18, 17);
            this.pbEmp.TabIndex = 16;
            this.pbEmp.TabStop = false;
            this.pbEmp.Click += new System.EventHandler(this.pbEmp_Click);
            // 
            // cbEmp
            // 
            this.cbEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmp.FormattingEnabled = true;
            this.cbEmp.Location = new System.Drawing.Point(85, 125);
            this.cbEmp.Name = "cbEmp";
            this.cbEmp.Size = new System.Drawing.Size(132, 20);
            this.cbEmp.TabIndex = 14;
            // 
            // lblEmp
            // 
            this.lblEmp.AutoSize = true;
            this.lblEmp.Location = new System.Drawing.Point(16, 132);
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
            this.btnAddOrEdit.Location = new System.Drawing.Point(179, 152);
            this.btnAddOrEdit.Name = "btnAddOrEdit";
            this.btnAddOrEdit.PanelImage = null;
            this.btnAddOrEdit.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnAddOrEdit.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnAddOrEdit.Size = new System.Drawing.Size(61, 22);
            this.btnAddOrEdit.TabIndex = 10;
            this.btnAddOrEdit.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnAddOrEdit.Click += new System.EventHandler(this.btnAddOrEdit_Click);
            // 
            // lblPathName
            // 
            this.lblPathName.AutoSize = true;
            this.lblPathName.Location = new System.Drawing.Point(16, 73);
            this.lblPathName.Name = "lblPathName";
            this.lblPathName.Size = new System.Drawing.Size(65, 12);
            this.lblPathName.TabIndex = 6;
            this.lblPathName.Text = "路 线 名：";
            // 
            // lblPathNo
            // 
            this.lblPathNo.AutoSize = true;
            this.lblPathNo.Location = new System.Drawing.Point(16, 43);
            this.lblPathNo.Name = "lblPathNo";
            this.lblPathNo.Size = new System.Drawing.Size(65, 12);
            this.lblPathNo.TabIndex = 5;
            this.lblPathNo.Text = "路线编号：";
            // 
            // tbPathName
            // 
            this.tbPathName.Location = new System.Drawing.Point(85, 69);
            this.tbPathName.Name = "tbPathName";
            this.tbPathName.ReadOnly = true;
            this.tbPathName.Size = new System.Drawing.Size(155, 21);
            this.tbPathName.TabIndex = 4;
            this.tbPathName.TextType = Shine.TextType.WithOutChar;
            // 
            // tbPathNo
            // 
            this.tbPathNo.Location = new System.Drawing.Point(85, 40);
            this.tbPathNo.Name = "tbPathNo";
            this.tbPathNo.ReadOnly = true;
            this.tbPathNo.Size = new System.Drawing.Size(155, 21);
            this.tbPathNo.TabIndex = 3;
            this.tbPathNo.TextType = Shine.TextType.WithOutChar;
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
            this.bcpAdd.Size = new System.Drawing.Size(253, 22);
            this.bcpAdd.TabIndex = 0;
            this.bcpAdd.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bcpAdd_MouseUp);
            this.bcpAdd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bcpAdd_MouseMove);
            this.bcpAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bcpAdd_MouseDown);
            this.bcpAdd.CloseButtonClick += new System.EventHandler(this.bcpAdd_CloseButtonClick);
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
            this.bcpAddInfo.CaptionTitle = "新增";
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
            this.bcpAddInfo.Location = new System.Drawing.Point(895, 2);
            this.bcpAddInfo.Name = "bcpAddInfo";
            this.bcpAddInfo.PanelImage = null;
            this.bcpAddInfo.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpAddInfo.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpAddInfo.Size = new System.Drawing.Size(50, 22);
            this.bcpAddInfo.TabIndex = 12;
            this.bcpAddInfo.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpAddInfo.Click += new System.EventHandler(this.bcpAddInfo_Click);
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
            this.PathId,
            this.PathNo,
            this.PathName,
            this.EmpNo,
            this.EmpName,
            this.edit,
            this.delete});
            this.dgvMain.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.BlueStyle;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(191)))), ((int)(((byte)(219)))));
            this.dgvMain.Location = new System.Drawing.Point(220, 26);
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
            this.dgvMain.Size = new System.Drawing.Size(780, 616);
            this.dgvMain.TabIndex = 10;
            this.dgvMain.VerticalScrollBarMax = 1;
            this.dgvMain.VerticalScrollBarValue = 0;
            this.dgvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgvMain_CellContentClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // PathId
            // 
            this.PathId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PathId.DataPropertyName = "Id";
            this.PathId.HeaderText = "路线ID";
            this.PathId.MinimumWidth = 53;
            this.PathId.Name = "PathId";
            this.PathId.ReadOnly = true;
            this.PathId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.PathId.Visible = false;
            this.PathId.Width = 70;
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
            // EmpNo
            // 
            this.EmpNo.DataPropertyName = "EmpNo";
            this.EmpNo.HeaderText = "员工编号";
            this.EmpNo.Name = "EmpNo";
            this.EmpNo.ReadOnly = true;
            // 
            // EmpName
            // 
            this.EmpName.DataPropertyName = "EmpName";
            this.EmpName.HeaderText = "员工姓名";
            this.EmpName.Name = "EmpName";
            this.EmpName.ReadOnly = true;
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
            this.bcpSearch.Location = new System.Drawing.Point(138, 161);
            this.bcpSearch.Name = "bcpSearch";
            this.bcpSearch.PanelImage = null;
            this.bcpSearch.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpSearch.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpSearch.Size = new System.Drawing.Size(54, 22);
            this.bcpSearch.TabIndex = 8;
            this.bcpSearch.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpSearch.Click += new System.EventHandler(this.bcpSearch_Click);
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
            this.bcpRefresh.Location = new System.Drawing.Point(141, 37);
            this.bcpRefresh.Name = "bcpRefresh";
            this.bcpRefresh.PanelImage = null;
            this.bcpRefresh.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpRefresh.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpRefresh.Size = new System.Drawing.Size(51, 22);
            this.bcpRefresh.TabIndex = 1;
            this.bcpRefresh.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpRefresh.Click += new System.EventHandler(this.bcpRefresh_Click);
            // 
            // cpnlTitle
            // 
            this.cpnlTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpnlTitle.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpnlTitle.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
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
            this.cpnlTitle.CaptionTitle = "路线信息";
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
            // cpnlBootom
            // 
            this.cpnlBootom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpnlBootom.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpnlBootom.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpnlBootom.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpnlBootom.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpnlBootom.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpnlBootom.CaptionBottomLineWidth = 1;
            this.cpnlBootom.CaptionCloseButtonControlLeft = 2;
            this.cpnlBootom.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpnlBootom.CaptionCloseButtonTitle = "×";
            this.cpnlBootom.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpnlBootom.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cpnlBootom.CaptionHeight = 25;
            this.cpnlBootom.CaptionLeft = 1;
            this.cpnlBootom.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpnlBootom.CaptionTitle = "";
            this.cpnlBootom.CaptionTitleLeft = 8;
            this.cpnlBootom.CaptionTitleTop = 4;
            this.cpnlBootom.CaptionTop = 1;
            this.cpnlBootom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cpnlBootom.IsBorderLine = true;
            this.cpnlBootom.IsCaptionSingleColor = false;
            this.cpnlBootom.IsOnlyCaption = false;
            this.cpnlBootom.IsPanelImage = false;
            this.cpnlBootom.IsUserButtonClose = false;
            this.cpnlBootom.IsUserCaptionBottomLine = true;
            this.cpnlBootom.IsUserSystemCloseButtonLeft = true;
            this.cpnlBootom.Location = new System.Drawing.Point(0, 642);
            this.cpnlBootom.Name = "cpnlBootom";
            this.cpnlBootom.PanelImage = null;
            this.cpnlBootom.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.cpnlBootom.Size = new System.Drawing.Size(1000, 27);
            this.cpnlBootom.TabIndex = 3;
            // 
            // cpnlTop
            // 
            this.cpnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpnlTop.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpnlTop.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
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
            this.cpnlTop.CaptionTitle = "员工路线关系设置";
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
            this.cpnlTop.Size = new System.Drawing.Size(1000, 26);
            this.cpnlTop.TabIndex = 0;
            // 
            // FrmPathEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1000, 669);
            this.Controls.Add(this.bcpRef);
            this.Controls.Add(this.bcpPrint);
            this.Controls.Add(this.vspnlAdd);
            this.Controls.Add(this.bcpAddInfo);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.cpnlBootom);
            this.Controls.Add(this.cpnlTop);
            this.Name = "FrmPathEmp";
            this.TabText = "员工路线关系信息";
            this.Text = "员工路线关系信息";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPathEmp_Load);
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).EndInit();
            this.sxpPanelGroup1.ResumeLayout(false);
            this.sxpPanel2.ResumeLayout(false);
            this.sxpPanel2.PerformLayout();
            this.sxpPanel1.ResumeLayout(false);
            this.vspnlAdd.ResumeLayout(false);
            this.vspnlAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KJ128WindowsLibrary.CaptionPanel cpnlTop;
        private KJ128WindowsLibrary.CaptionPanel cpnlBootom;
        private System.Windows.Forms.Panel pnlLeft;
        private KJ128WindowsLibrary.CaptionPanel cpnlTitle;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpRefresh;
        private System.Windows.Forms.Panel pnlSearch;
        private KJ128WindowsLibrary.VSPanel vspnlAdd;
        private System.Windows.Forms.Label lblEmp;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnAddOrEdit;
        private System.Windows.Forms.Label lblPathName;
        private System.Windows.Forms.Label lblPathNo;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpAdd;
        private System.Windows.Forms.ComboBox cbEmp;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpAddInfo;
        private System.Windows.Forms.TreeView tvMain;
        private System.Windows.Forms.PictureBox pbEmp;
        private System.Windows.Forms.Label lblPNo;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.Label lblEmpNo;
        private System.Windows.Forms.Label lblPName;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpSearch;
        private System.Windows.Forms.ComboBox cbDept;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.PictureBox pbDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpName;
        private System.Windows.Forms.DataGridViewLinkColumn edit;
        private System.Windows.Forms.DataGridViewLinkColumn delete;
        private KJ128NInterfaceShow.DataGridViewKJ128 dgvMain;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpPrint;
        private Wilson.Controls.XPPanel.Images.SXPPanelGroup sxpPanelGroup1;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel2;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel1;
        private Shine.ShineTextBox tbPathName;
        private Shine.ShineTextBox tbPathNo;
        private Shine.ShineTextBox tbPNo;
        private Shine.ShineTextBox tbEmpName;
        private Shine.ShineTextBox tbEmpNo;
        private Shine.ShineTextBox tbPName;
        private System.Windows.Forms.Timer timer1;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpRef;
    }
}