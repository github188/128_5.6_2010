namespace KJ128NMainRun.PathManage
{
    partial class FrmPathInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPathInfo));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("所有路线信息");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.sxpPanelGroup1 = new Wilson.Controls.XPPanel.Images.SXPPanelGroup();
            this.pnlSerach = new System.Windows.Forms.Panel();
            this.sxpPanel2 = new Wilson.Controls.XPPanel.SXPPanel();
            this.tbpRemark = new Shine.ShineTextBox();
            this.lblPId = new System.Windows.Forms.Label();
            this.lblpRemark = new System.Windows.Forms.Label();
            this.btnSerch = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.tbpName = new Shine.ShineTextBox();
            this.lblpNo = new System.Windows.Forms.Label();
            this.tbpNo = new Shine.ShineTextBox();
            this.lblpName = new System.Windows.Forms.Label();
            this.tbpId = new Shine.ShineTextBox();
            this.sxpPanel1 = new Wilson.Controls.XPPanel.SXPPanel();
            this.bcpRefresh = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.tvPathInfo = new System.Windows.Forms.TreeView();
            this.cpnlTile = new KJ128WindowsLibrary.CaptionPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bcpRef = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.vspnlAdd = new KJ128WindowsLibrary.VSPanel();
            this.lblRemark = new System.Windows.Forms.Label();
            this.tbRemark = new Shine.ShineTextBox();
            this.btnAddNew = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnAdd = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.lblPathId = new System.Windows.Forms.Label();
            this.tbPathId = new Shine.ShineTextBox();
            this.lblPathName = new System.Windows.Forms.Label();
            this.lblPathNo = new System.Windows.Forms.Label();
            this.tbPathName = new Shine.ShineTextBox();
            this.tbPathNo = new Shine.ShineTextBox();
            this.bcpAdd = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.bcpPrint = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.buttonCaptionPanel1 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cpnlBottom = new KJ128WindowsLibrary.CaptionPanel();
            this.bcpNew = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cpnlTop = new KJ128WindowsLibrary.CaptionPanel();
            this.dgvMain = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.PathId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).BeginInit();
            this.sxpPanelGroup1.SuspendLayout();
            this.sxpPanel2.SuspendLayout();
            this.sxpPanel1.SuspendLayout();
            this.vspnlAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.sxpPanelGroup1);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 27);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(220, 646);
            this.pnlLeft.TabIndex = 8;
            // 
            // sxpPanelGroup1
            // 
            this.sxpPanelGroup1.AutoScroll = true;
            this.sxpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanelGroup1.Controls.Add(this.pnlSerach);
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel2);
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel1);
            this.sxpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sxpPanelGroup1.Location = new System.Drawing.Point(0, 0);
            this.sxpPanelGroup1.Name = "sxpPanelGroup1";
            this.sxpPanelGroup1.PanelGradient = ((Wilson.Controls.XPPanel.Colors.GradientColor)(resources.GetObject("sxpPanelGroup1.PanelGradient")));
            this.sxpPanelGroup1.Size = new System.Drawing.Size(218, 644);
            this.sxpPanelGroup1.TabIndex = 12;
            // 
            // pnlSerach
            // 
            this.pnlSerach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSerach.Location = new System.Drawing.Point(48, 582);
            this.pnlSerach.Name = "pnlSerach";
            this.pnlSerach.Size = new System.Drawing.Size(40, 30);
            this.pnlSerach.TabIndex = 2;
            this.pnlSerach.Visible = false;
            this.pnlSerach.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSerach_Paint);
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
            this.sxpPanel2.Controls.Add(this.tbpRemark);
            this.sxpPanel2.Controls.Add(this.lblPId);
            this.sxpPanel2.Controls.Add(this.lblpRemark);
            this.sxpPanel2.Controls.Add(this.btnSerch);
            this.sxpPanel2.Controls.Add(this.tbpName);
            this.sxpPanel2.Controls.Add(this.lblpNo);
            this.sxpPanel2.Controls.Add(this.tbpNo);
            this.sxpPanel2.Controls.Add(this.lblpName);
            this.sxpPanel2.Controls.Add(this.tbpId);
            this.sxpPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.sxpPanel2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sxpPanel2.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.sxpPanel2.ImageItems.ImageSet = null;
            this.sxpPanel2.ImageItems.Normal = -1;
            this.sxpPanel2.Location = new System.Drawing.Point(8, 322);
            this.sxpPanel2.Name = "sxpPanel2";
            this.sxpPanel2.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel2.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel2.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel2.Size = new System.Drawing.Size(202, 203);
            this.sxpPanel2.TabIndex = 12;
            this.sxpPanel2.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel2.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel2.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel2.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // tbpRemark
            // 
            this.tbpRemark.Location = new System.Drawing.Point(86, 135);
            this.tbpRemark.Name = "tbpRemark";
            this.tbpRemark.Size = new System.Drawing.Size(100, 20);
            this.tbpRemark.TabIndex = 17;
            this.tbpRemark.TextType = Shine.TextType.WithOutChar;
            // 
            // lblPId
            // 
            this.lblPId.AutoSize = true;
            this.lblPId.Location = new System.Drawing.Point(15, 44);
            this.lblPId.Name = "lblPId";
            this.lblPId.Size = new System.Drawing.Size(67, 13);
            this.lblPId.TabIndex = 9;
            this.lblPId.Text = "路 线 ID：";
            this.lblPId.Visible = false;
            // 
            // lblpRemark
            // 
            this.lblpRemark.AutoSize = true;
            this.lblpRemark.Location = new System.Drawing.Point(15, 138);
            this.lblpRemark.Name = "lblpRemark";
            this.lblpRemark.Size = new System.Drawing.Size(62, 13);
            this.lblpRemark.TabIndex = 16;
            this.lblpRemark.Text = "备    注：";
            // 
            // btnSerch
            // 
            this.btnSerch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSerch.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnSerch.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnSerch.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnSerch.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnSerch.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnSerch.CaptionBottomLineWidth = 1;
            this.btnSerch.CaptionCloseButtonControlLeft = 2;
            this.btnSerch.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSerch.CaptionCloseButtonTitle = "×";
            this.btnSerch.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSerch.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSerch.CaptionHeight = 20;
            this.btnSerch.CaptionLeft = 1;
            this.btnSerch.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnSerch.CaptionTitle = "查找";
            this.btnSerch.CaptionTitleLeft = 8;
            this.btnSerch.CaptionTitleTop = 4;
            this.btnSerch.CaptionTop = 1;
            this.btnSerch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSerch.IsBorderLine = true;
            this.btnSerch.IsCaptionSingleColor = false;
            this.btnSerch.IsOnlyCaption = true;
            this.btnSerch.IsPanelImage = true;
            this.btnSerch.IsUserButtonClose = false;
            this.btnSerch.IsUserCaptionBottomLine = false;
            this.btnSerch.IsUserSystemCloseButtonLeft = true;
            this.btnSerch.Location = new System.Drawing.Point(132, 172);
            this.btnSerch.Name = "btnSerch";
            this.btnSerch.PanelImage = null;
            this.btnSerch.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnSerch.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnSerch.Size = new System.Drawing.Size(54, 22);
            this.btnSerch.TabIndex = 0;
            this.btnSerch.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnSerch.Click += new System.EventHandler(this.btnSerch_Click);
            // 
            // tbpName
            // 
            this.tbpName.Location = new System.Drawing.Point(86, 104);
            this.tbpName.Name = "tbpName";
            this.tbpName.Size = new System.Drawing.Size(100, 20);
            this.tbpName.TabIndex = 14;
            this.tbpName.TextType = Shine.TextType.WithOutChar;
            // 
            // lblpNo
            // 
            this.lblpNo.AutoSize = true;
            this.lblpNo.Location = new System.Drawing.Point(15, 78);
            this.lblpNo.Name = "lblpNo";
            this.lblpNo.Size = new System.Drawing.Size(72, 13);
            this.lblpNo.TabIndex = 10;
            this.lblpNo.Text = "路线编号：";
            // 
            // tbpNo
            // 
            this.tbpNo.Location = new System.Drawing.Point(86, 74);
            this.tbpNo.Name = "tbpNo";
            this.tbpNo.Size = new System.Drawing.Size(100, 20);
            this.tbpNo.TabIndex = 13;
            this.tbpNo.TextType = Shine.TextType.WithOutChar;
            // 
            // lblpName
            // 
            this.lblpName.AutoSize = true;
            this.lblpName.Location = new System.Drawing.Point(15, 107);
            this.lblpName.Name = "lblpName";
            this.lblpName.Size = new System.Drawing.Size(67, 13);
            this.lblpName.TabIndex = 11;
            this.lblpName.Text = "路 线 名：";
            // 
            // tbpId
            // 
            this.tbpId.Location = new System.Drawing.Point(86, 41);
            this.tbpId.Name = "tbpId";
            this.tbpId.Size = new System.Drawing.Size(100, 20);
            this.tbpId.TabIndex = 12;
            this.tbpId.TextType = Shine.TextType.WithOutChar;
            this.tbpId.Visible = false;
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
            this.sxpPanel1.Controls.Add(this.bcpRefresh);
            this.sxpPanel1.Controls.Add(this.tvPathInfo);
            this.sxpPanel1.Controls.Add(this.cpnlTile);
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
            this.sxpPanel1.Size = new System.Drawing.Size(202, 306);
            this.sxpPanel1.TabIndex = 12;
            this.sxpPanel1.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel1.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel1.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel1.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
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
            this.bcpRefresh.Location = new System.Drawing.Point(152, 37);
            this.bcpRefresh.Name = "bcpRefresh";
            this.bcpRefresh.PanelImage = null;
            this.bcpRefresh.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpRefresh.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpRefresh.Size = new System.Drawing.Size(43, 22);
            this.bcpRefresh.TabIndex = 5;
            this.bcpRefresh.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpRefresh.Visible = false;
            this.bcpRefresh.Click += new System.EventHandler(this.bcpRefresh_Click);
            // 
            // tvPathInfo
            // 
            this.tvPathInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPathInfo.Location = new System.Drawing.Point(2, 61);
            this.tvPathInfo.Name = "tvPathInfo";
            treeNode1.Name = "ParentNode";
            treeNode1.Text = "所有路线信息";
            this.tvPathInfo.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvPathInfo.ShowNodeToolTips = true;
            this.tvPathInfo.ShowRootLines = false;
            this.tvPathInfo.Size = new System.Drawing.Size(198, 242);
            this.tvPathInfo.TabIndex = 4;
            // 
            // cpnlTile
            // 
            this.cpnlTile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpnlTile.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpnlTile.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpnlTile.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpnlTile.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpnlTile.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpnlTile.CaptionBottomLineWidth = 1;
            this.cpnlTile.CaptionCloseButtonControlLeft = 2;
            this.cpnlTile.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpnlTile.CaptionCloseButtonTitle = "×";
            this.cpnlTile.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpnlTile.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cpnlTile.CaptionHeight = 25;
            this.cpnlTile.CaptionLeft = 1;
            this.cpnlTile.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpnlTile.CaptionTitle = "路线信息";
            this.cpnlTile.CaptionTitleLeft = 8;
            this.cpnlTile.CaptionTitleTop = 4;
            this.cpnlTile.CaptionTop = 1;
            this.cpnlTile.Dock = System.Windows.Forms.DockStyle.Top;
            this.cpnlTile.IsBorderLine = true;
            this.cpnlTile.IsCaptionSingleColor = false;
            this.cpnlTile.IsOnlyCaption = false;
            this.cpnlTile.IsPanelImage = false;
            this.cpnlTile.IsUserButtonClose = false;
            this.cpnlTile.IsUserCaptionBottomLine = true;
            this.cpnlTile.IsUserSystemCloseButtonLeft = true;
            this.cpnlTile.Location = new System.Drawing.Point(2, 35);
            this.cpnlTile.Name = "cpnlTile";
            this.cpnlTile.PanelImage = null;
            this.cpnlTile.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.cpnlTile.Size = new System.Drawing.Size(198, 26);
            this.cpnlTile.TabIndex = 0;
            this.cpnlTile.Load += new System.EventHandler(this.cpnlTile_Load);
            // 
            // timer1
            // 
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
            this.bcpRef.Location = new System.Drawing.Point(823, 2);
            this.bcpRef.Name = "bcpRef";
            this.bcpRef.PanelImage = null;
            this.bcpRef.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpRef.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpRef.Size = new System.Drawing.Size(63, 22);
            this.bcpRef.TabIndex = 12;
            this.bcpRef.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpRef.Click += new System.EventHandler(this.bcpRef_Click);
            // 
            // vspnlAdd
            // 
            this.vspnlAdd.BackLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.vspnlAdd.BetweenControlCount = 2;
            this.vspnlAdd.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.vspnlAdd.BottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.vspnlAdd.Controls.Add(this.lblRemark);
            this.vspnlAdd.Controls.Add(this.tbRemark);
            this.vspnlAdd.Controls.Add(this.btnAddNew);
            this.vspnlAdd.Controls.Add(this.btnAdd);
            this.vspnlAdd.Controls.Add(this.lblPathId);
            this.vspnlAdd.Controls.Add(this.tbPathId);
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
            this.vspnlAdd.Location = new System.Drawing.Point(417, 143);
            this.vspnlAdd.MiddleInterval = 80;
            this.vspnlAdd.Name = "vspnlAdd";
            this.vspnlAdd.RightInterval = 0;
            this.vspnlAdd.SetBackGroundStyle = KJ128WindowsLibrary.VsPaneBackGroundStyle.windowsStyle;
            this.vspnlAdd.Size = new System.Drawing.Size(253, 187);
            this.vspnlAdd.TabIndex = 7;
            this.vspnlAdd.TopInterval = 0;
            this.vspnlAdd.VerticalInterval = 8;
            this.vspnlAdd.Visible = false;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(16, 128);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(65, 12);
            this.lblRemark.TabIndex = 13;
            this.lblRemark.Text = "备    注：";
            // 
            // tbRemark
            // 
            this.tbRemark.Location = new System.Drawing.Point(85, 125);
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.Size = new System.Drawing.Size(155, 21);
            this.tbRemark.TabIndex = 12;
            this.tbRemark.TextType = Shine.TextType.WithOutChar;
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddNew.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnAddNew.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnAddNew.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnAddNew.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnAddNew.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnAddNew.CaptionBottomLineWidth = 1;
            this.btnAddNew.CaptionCloseButtonControlLeft = 2;
            this.btnAddNew.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddNew.CaptionCloseButtonTitle = "×";
            this.btnAddNew.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddNew.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAddNew.CaptionHeight = 20;
            this.btnAddNew.CaptionLeft = 1;
            this.btnAddNew.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAddNew.CaptionTitle = "Title";
            this.btnAddNew.CaptionTitleLeft = 8;
            this.btnAddNew.CaptionTitleTop = 4;
            this.btnAddNew.CaptionTop = 1;
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.IsBorderLine = true;
            this.btnAddNew.IsCaptionSingleColor = false;
            this.btnAddNew.IsOnlyCaption = true;
            this.btnAddNew.IsPanelImage = true;
            this.btnAddNew.IsUserButtonClose = false;
            this.btnAddNew.IsUserCaptionBottomLine = false;
            this.btnAddNew.IsUserSystemCloseButtonLeft = true;
            this.btnAddNew.Location = new System.Drawing.Point(85, 152);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.PanelImage = null;
            this.btnAddNew.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnAddNew.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnAddNew.Size = new System.Drawing.Size(88, 22);
            this.btnAddNew.TabIndex = 11;
            this.btnAddNew.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
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
            this.btnAdd.CaptionTitle = "Title";
            this.btnAdd.CaptionTitleLeft = 8;
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
            this.btnAdd.Location = new System.Drawing.Point(179, 152);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PanelImage = null;
            this.btnAdd.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnAdd.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnAdd.Size = new System.Drawing.Size(61, 22);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblPathId
            // 
            this.lblPathId.AutoSize = true;
            this.lblPathId.Location = new System.Drawing.Point(16, 36);
            this.lblPathId.Name = "lblPathId";
            this.lblPathId.Size = new System.Drawing.Size(65, 12);
            this.lblPathId.TabIndex = 8;
            this.lblPathId.Text = "路 线 ID：";
            this.lblPathId.Visible = false;
            // 
            // tbPathId
            // 
            this.tbPathId.Location = new System.Drawing.Point(85, 33);
            this.tbPathId.Name = "tbPathId";
            this.tbPathId.ReadOnly = true;
            this.tbPathId.Size = new System.Drawing.Size(30, 21);
            this.tbPathId.TabIndex = 7;
            this.tbPathId.TextType = Shine.TextType.WithOutChar;
            this.tbPathId.Visible = false;
            // 
            // lblPathName
            // 
            this.lblPathName.AutoSize = true;
            this.lblPathName.Location = new System.Drawing.Point(16, 99);
            this.lblPathName.Name = "lblPathName";
            this.lblPathName.Size = new System.Drawing.Size(65, 12);
            this.lblPathName.TabIndex = 6;
            this.lblPathName.Text = "路 线 名：";
            // 
            // lblPathNo
            // 
            this.lblPathNo.AutoSize = true;
            this.lblPathNo.Location = new System.Drawing.Point(16, 70);
            this.lblPathNo.Name = "lblPathNo";
            this.lblPathNo.Size = new System.Drawing.Size(65, 12);
            this.lblPathNo.TabIndex = 5;
            this.lblPathNo.Text = "路线编号：";
            // 
            // tbPathName
            // 
            this.tbPathName.Location = new System.Drawing.Point(85, 94);
            this.tbPathName.Name = "tbPathName";
            this.tbPathName.Size = new System.Drawing.Size(155, 21);
            this.tbPathName.TabIndex = 4;
            this.tbPathName.TextType = Shine.TextType.WithOutChar;
            // 
            // tbPathNo
            // 
            this.tbPathNo.Location = new System.Drawing.Point(85, 64);
            this.tbPathNo.Name = "tbPathNo";
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
            this.bcpAdd.CaptionTitle = "增加线路信息";
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
            this.bcpPrint.Location = new System.Drawing.Point(970, 2);
            this.bcpPrint.Name = "bcpPrint";
            this.bcpPrint.PanelImage = null;
            this.bcpPrint.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpPrint.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpPrint.Size = new System.Drawing.Size(55, 22);
            this.bcpPrint.TabIndex = 11;
            this.bcpPrint.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpPrint.Click += new System.EventHandler(this.bcpPrint_Click);
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
            this.buttonCaptionPanel1.Location = new System.Drawing.Point(417, -124);
            this.buttonCaptionPanel1.Name = "buttonCaptionPanel1";
            this.buttonCaptionPanel1.PanelImage = null;
            this.buttonCaptionPanel1.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.WindowsStyle;
            this.buttonCaptionPanel1.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.buttonCaptionPanel1.Size = new System.Drawing.Size(150, 22);
            this.buttonCaptionPanel1.TabIndex = 10;
            this.buttonCaptionPanel1.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // cpnlBottom
            // 
            this.cpnlBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpnlBottom.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpnlBottom.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpnlBottom.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpnlBottom.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpnlBottom.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpnlBottom.CaptionBottomLineWidth = 1;
            this.cpnlBottom.CaptionCloseButtonControlLeft = 2;
            this.cpnlBottom.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpnlBottom.CaptionCloseButtonTitle = "×";
            this.cpnlBottom.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpnlBottom.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cpnlBottom.CaptionHeight = 30;
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
            this.cpnlBottom.Location = new System.Drawing.Point(0, 673);
            this.cpnlBottom.Name = "cpnlBottom";
            this.cpnlBottom.PanelImage = null;
            this.cpnlBottom.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.cpnlBottom.Size = new System.Drawing.Size(1028, 27);
            this.cpnlBottom.TabIndex = 4;
            // 
            // bcpNew
            // 
            this.bcpNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bcpNew.AutoSize = true;
            this.bcpNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpNew.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpNew.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpNew.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.bcpNew.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.bcpNew.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpNew.CaptionBottomLineWidth = 1;
            this.bcpNew.CaptionCloseButtonControlLeft = 2;
            this.bcpNew.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpNew.CaptionCloseButtonTitle = "×";
            this.bcpNew.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpNew.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bcpNew.CaptionHeight = 20;
            this.bcpNew.CaptionLeft = 1;
            this.bcpNew.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpNew.CaptionTitle = "增加路线";
            this.bcpNew.CaptionTitleLeft = 8;
            this.bcpNew.CaptionTitleTop = 4;
            this.bcpNew.CaptionTop = 1;
            this.bcpNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcpNew.IsBorderLine = true;
            this.bcpNew.IsCaptionSingleColor = false;
            this.bcpNew.IsOnlyCaption = true;
            this.bcpNew.IsPanelImage = true;
            this.bcpNew.IsUserButtonClose = false;
            this.bcpNew.IsUserCaptionBottomLine = false;
            this.bcpNew.IsUserSystemCloseButtonLeft = true;
            this.bcpNew.Location = new System.Drawing.Point(892, 2);
            this.bcpNew.Name = "bcpNew";
            this.bcpNew.PanelImage = null;
            this.bcpNew.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpNew.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpNew.Size = new System.Drawing.Size(74, 22);
            this.bcpNew.TabIndex = 1;
            this.bcpNew.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpNew.Click += new System.EventHandler(this.bcpNew_Click);
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
            this.cpnlTop.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.cpnlTop.CaptionTitle = "路线信息设置";
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
            this.cpnlTop.Size = new System.Drawing.Size(1028, 27);
            this.cpnlTop.TabIndex = 0;
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
            this.PathId,
            this.PathNo,
            this.PathName,
            this.remark,
            this.edit,
            this.delete});
            this.dgvMain.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.BlueStyle;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(191)))), ((int)(((byte)(219)))));
            this.dgvMain.Location = new System.Drawing.Point(220, 27);
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
            this.dgvMain.Size = new System.Drawing.Size(808, 646);
            this.dgvMain.TabIndex = 9;
            this.dgvMain.VerticalScrollBarMax = 1;
            this.dgvMain.VerticalScrollBarValue = 0;
            this.dgvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgvMain_CellContentClick);
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
            // remark
            // 
            this.remark.DataPropertyName = "Remark";
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
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
            // FrmPathInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1028, 700);
            this.Controls.Add(this.bcpRef);
            this.Controls.Add(this.vspnlAdd);
            this.Controls.Add(this.bcpPrint);
            this.Controls.Add(this.buttonCaptionPanel1);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.cpnlBottom);
            this.Controls.Add(this.bcpNew);
            this.Controls.Add(this.cpnlTop);
            this.Name = "FrmPathInfo";
            this.TabText = "路线信息";
            this.Text = "路线信息";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPathInfo_Load);
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).EndInit();
            this.sxpPanelGroup1.ResumeLayout(false);
            this.sxpPanel2.ResumeLayout(false);
            this.sxpPanel2.PerformLayout();
            this.sxpPanel1.ResumeLayout(false);
            this.vspnlAdd.ResumeLayout(false);
            this.vspnlAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KJ128WindowsLibrary.CaptionPanel cpnlTop;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpNew;
        private KJ128WindowsLibrary.CaptionPanel cpnlBottom;
        private KJ128WindowsLibrary.VSPanel vspnlAdd;
        private System.Windows.Forms.Label lblPathId;
        private System.Windows.Forms.Label lblPathName;
        private System.Windows.Forms.Label lblPathNo;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpAdd;
        private System.Windows.Forms.Panel pnlLeft;
        private KJ128WindowsLibrary.CaptionPanel cpnlTile;
        private System.Windows.Forms.Panel pnlSerach;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnAddNew;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnAdd;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnSerch;
        private System.Windows.Forms.Label lblpName;
        private System.Windows.Forms.Label lblpNo;
        private System.Windows.Forms.Label lblPId;
        private System.Windows.Forms.TreeView tvPathInfo;
        private System.Windows.Forms.Label lblRemark;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpRefresh;
        private System.Windows.Forms.Label lblpRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathName;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewLinkColumn edit;
        private System.Windows.Forms.DataGridViewLinkColumn delete;
        private KJ128NInterfaceShow.DataGridViewKJ128 dgvMain;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel1;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpPrint;
        private Wilson.Controls.XPPanel.Images.SXPPanelGroup sxpPanelGroup1;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel2;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel1;
        private Shine.ShineTextBox tbPathId;
        private Shine.ShineTextBox tbPathName;
        private Shine.ShineTextBox tbPathNo;
        private Shine.ShineTextBox tbpName;
        private Shine.ShineTextBox tbpNo;
        private Shine.ShineTextBox tbpId;
        private Shine.ShineTextBox tbRemark;
        private Shine.ShineTextBox tbpRemark;
        private System.Windows.Forms.Timer timer1;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpRef;




    }
}