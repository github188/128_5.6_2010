namespace KJ128NInterfaceShow
{
    partial class FrmHisPathAlert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHisPathAlert));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cpnlTop = new KJ128WindowsLibrary.CaptionPanel();
            this.cpnlBottom = new KJ128WindowsLibrary.CaptionPanel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.sxpPanelGroup1 = new Wilson.Controls.XPPanel.Images.SXPPanelGroup();
            this.gbCondition = new System.Windows.Forms.GroupBox();
            this.sxpPanel1 = new Wilson.Controls.XPPanel.SXPPanel();
            this.lblBeginTime = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.bcpSearch = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.bcpReset = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.dbgvMain = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StationAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StationPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StationHeadAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StationHeadPalce = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlertBeginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlertEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlertTimeValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bcpExcel = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).BeginInit();
            this.sxpPanelGroup1.SuspendLayout();
            this.sxpPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgvMain)).BeginInit();
            this.SuspendLayout();
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
            this.cpnlTop.CaptionTitle = "历史路径报警信息：";
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
            this.cpnlTop.Location = new System.Drawing.Point(215, 0);
            this.cpnlTop.Name = "cpnlTop";
            this.cpnlTop.PanelImage = null;
            this.cpnlTop.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.cpnlTop.Size = new System.Drawing.Size(813, 27);
            this.cpnlTop.TabIndex = 0;
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
            this.cpnlBottom.Location = new System.Drawing.Point(0, 577);
            this.cpnlBottom.Name = "cpnlBottom";
            this.cpnlBottom.PanelImage = null;
            this.cpnlBottom.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.cpnlBottom.Size = new System.Drawing.Size(1028, 27);
            this.cpnlBottom.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.sxpPanelGroup1);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(215, 577);
            this.pnlLeft.TabIndex = 2;
            // 
            // sxpPanelGroup1
            // 
            this.sxpPanelGroup1.AutoScroll = true;
            this.sxpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanelGroup1.Controls.Add(this.gbCondition);
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel1);
            this.sxpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sxpPanelGroup1.Location = new System.Drawing.Point(0, 0);
            this.sxpPanelGroup1.Name = "sxpPanelGroup1";
            this.sxpPanelGroup1.PanelGradient = ((Wilson.Controls.XPPanel.Colors.GradientColor)(resources.GetObject("sxpPanelGroup1.PanelGradient")));
            this.sxpPanelGroup1.Size = new System.Drawing.Size(213, 575);
            this.sxpPanelGroup1.TabIndex = 13;
            // 
            // gbCondition
            // 
            this.gbCondition.Location = new System.Drawing.Point(83, 468);
            this.gbCondition.Name = "gbCondition";
            this.gbCondition.Size = new System.Drawing.Size(81, 33);
            this.gbCondition.TabIndex = 1;
            this.gbCondition.TabStop = false;
            this.gbCondition.Text = "查询条件";
            this.gbCondition.Visible = false;
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
            this.sxpPanel1.Controls.Add(this.lblBeginTime);
            this.sxpPanel1.Controls.Add(this.dtpEnd);
            this.sxpPanel1.Controls.Add(this.bcpSearch);
            this.sxpPanel1.Controls.Add(this.lblEndTime);
            this.sxpPanel1.Controls.Add(this.bcpReset);
            this.sxpPanel1.Controls.Add(this.dtpBegin);
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
            this.sxpPanel1.Size = new System.Drawing.Size(197, 169);
            this.sxpPanel1.TabIndex = 13;
            this.sxpPanel1.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel1.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel1.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel1.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // lblBeginTime
            // 
            this.lblBeginTime.AutoSize = true;
            this.lblBeginTime.Location = new System.Drawing.Point(1, 46);
            this.lblBeginTime.Name = "lblBeginTime";
            this.lblBeginTime.Size = new System.Drawing.Size(59, 13);
            this.lblBeginTime.TabIndex = 0;
            this.lblBeginTime.Text = "开始时间";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(59, 87);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(138, 20);
            this.dtpEnd.TabIndex = 24;
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
            this.bcpSearch.CaptionTitle = "查询";
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
            this.bcpSearch.Location = new System.Drawing.Point(27, 128);
            this.bcpSearch.Name = "bcpSearch";
            this.bcpSearch.PanelImage = null;
            this.bcpSearch.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpSearch.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpSearch.Size = new System.Drawing.Size(49, 22);
            this.bcpSearch.TabIndex = 4;
            this.bcpSearch.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpSearch.Click += new System.EventHandler(this.bcpSearch_Click);
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(1, 87);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(59, 13);
            this.lblEndTime.TabIndex = 2;
            this.lblEndTime.Text = "结束时间";
            // 
            // bcpReset
            // 
            this.bcpReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpReset.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpReset.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpReset.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.bcpReset.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.bcpReset.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpReset.CaptionBottomLineWidth = 1;
            this.bcpReset.CaptionCloseButtonControlLeft = 2;
            this.bcpReset.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpReset.CaptionCloseButtonTitle = "×";
            this.bcpReset.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpReset.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bcpReset.CaptionHeight = 20;
            this.bcpReset.CaptionLeft = 1;
            this.bcpReset.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpReset.CaptionTitle = "重置";
            this.bcpReset.CaptionTitleLeft = 8;
            this.bcpReset.CaptionTitleTop = 4;
            this.bcpReset.CaptionTop = 1;
            this.bcpReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcpReset.IsBorderLine = true;
            this.bcpReset.IsCaptionSingleColor = false;
            this.bcpReset.IsOnlyCaption = true;
            this.bcpReset.IsPanelImage = true;
            this.bcpReset.IsUserButtonClose = false;
            this.bcpReset.IsUserCaptionBottomLine = false;
            this.bcpReset.IsUserSystemCloseButtonLeft = true;
            this.bcpReset.Location = new System.Drawing.Point(114, 128);
            this.bcpReset.Name = "bcpReset";
            this.bcpReset.PanelImage = null;
            this.bcpReset.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpReset.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpReset.Size = new System.Drawing.Size(48, 22);
            this.bcpReset.TabIndex = 5;
            this.bcpReset.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpReset.Click += new System.EventHandler(this.bcpReset_Click);
            // 
            // dtpBegin
            // 
            this.dtpBegin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBegin.Location = new System.Drawing.Point(59, 42);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(138, 20);
            this.dtpBegin.TabIndex = 23;
            // 
            // dbgvMain
            // 
            this.dbgvMain.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dbgvMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dbgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgvMain.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.dbgvMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dbgvMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(251)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dbgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dbgvMain.ColumnHeadersHeight = 30;
            this.dbgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.EmpNo,
            this.EmpName,
            this.StationAddress,
            this.StationPlace,
            this.StationHeadAddress,
            this.StationHeadPalce,
            this.AlertBeginTime,
            this.AlertEndTime,
            this.AlertTimeValue});
            this.dbgvMain.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.BlueStyle;
            this.dbgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbgvMain.EnableHeadersVisualStyles = false;
            this.dbgvMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(191)))), ((int)(((byte)(219)))));
            this.dbgvMain.Location = new System.Drawing.Point(215, 27);
            this.dbgvMain.MultiSelect = false;
            this.dbgvMain.Name = "dbgvMain";
            this.dbgvMain.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dbgvMain.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dbgvMain.RowTemplate.Height = 23;
            this.dbgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgvMain.Size = new System.Drawing.Size(813, 550);
            this.dbgvMain.TabIndex = 11;
            this.dbgvMain.VerticalScrollBarMax = 1;
            this.dbgvMain.VerticalScrollBarValue = 0;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "记录Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // EmpNo
            // 
            this.EmpNo.DataPropertyName = "EmpNo";
            this.EmpNo.HeaderText = "员工编号";
            this.EmpNo.Name = "EmpNo";
            this.EmpNo.ReadOnly = true;
            this.EmpNo.Visible = false;
            // 
            // EmpName
            // 
            this.EmpName.DataPropertyName = "EmpName";
            this.EmpName.HeaderText = "员工姓名";
            this.EmpName.Name = "EmpName";
            // 
            // StationAddress
            // 
            this.StationAddress.DataPropertyName = "StationAddress";
            this.StationAddress.HeaderText = "分站编号";
            this.StationAddress.Name = "StationAddress";
            this.StationAddress.ReadOnly = true;
            this.StationAddress.Visible = false;
            // 
            // StationPlace
            // 
            this.StationPlace.DataPropertyName = "StationPlace";
            this.StationPlace.HeaderText = "分站安装位置";
            this.StationPlace.Name = "StationPlace";
            this.StationPlace.ReadOnly = true;
            // 
            // StationHeadAddress
            // 
            this.StationHeadAddress.DataPropertyName = "StationHeadAddress";
            this.StationHeadAddress.HeaderText = "接收器编号";
            this.StationHeadAddress.Name = "StationHeadAddress";
            this.StationHeadAddress.ReadOnly = true;
            this.StationHeadAddress.Visible = false;
            // 
            // StationHeadPalce
            // 
            this.StationHeadPalce.DataPropertyName = "StationHeadPlace";
            this.StationHeadPalce.HeaderText = "接收器安装位置";
            this.StationHeadPalce.Name = "StationHeadPalce";
            this.StationHeadPalce.ReadOnly = true;
            // 
            // AlertBeginTime
            // 
            this.AlertBeginTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AlertBeginTime.DataPropertyName = "AlertBeginTime";
            dataGridViewCellStyle3.Format = "G";
            dataGridViewCellStyle3.NullValue = null;
            this.AlertBeginTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.AlertBeginTime.HeaderText = "报警开始时间";
            this.AlertBeginTime.Name = "AlertBeginTime";
            this.AlertBeginTime.ReadOnly = true;
            // 
            // AlertEndTime
            // 
            this.AlertEndTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AlertEndTime.DataPropertyName = "AlertEndTime";
            dataGridViewCellStyle4.Format = "G";
            dataGridViewCellStyle4.NullValue = null;
            this.AlertEndTime.DefaultCellStyle = dataGridViewCellStyle4;
            this.AlertEndTime.HeaderText = "报警结束时间";
            this.AlertEndTime.Name = "AlertEndTime";
            this.AlertEndTime.ReadOnly = true;
            // 
            // AlertTimeValue
            // 
            this.AlertTimeValue.DataPropertyName = "AlertTimeValue";
            this.AlertTimeValue.HeaderText = "报警持续时间(秒)";
            this.AlertTimeValue.Name = "AlertTimeValue";
            this.AlertTimeValue.ReadOnly = true;
            // 
            // bcpExcel
            // 
            this.bcpExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bcpExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpExcel.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpExcel.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpExcel.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.bcpExcel.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.bcpExcel.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpExcel.CaptionBottomLineWidth = 1;
            this.bcpExcel.CaptionCloseButtonControlLeft = 2;
            this.bcpExcel.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpExcel.CaptionCloseButtonTitle = "×";
            this.bcpExcel.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpExcel.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bcpExcel.CaptionHeight = 20;
            this.bcpExcel.CaptionLeft = 1;
            this.bcpExcel.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpExcel.CaptionTitle = " 打   印";
            this.bcpExcel.CaptionTitleLeft = 8;
            this.bcpExcel.CaptionTitleTop = 4;
            this.bcpExcel.CaptionTop = 1;
            this.bcpExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcpExcel.IsBorderLine = true;
            this.bcpExcel.IsCaptionSingleColor = false;
            this.bcpExcel.IsOnlyCaption = true;
            this.bcpExcel.IsPanelImage = true;
            this.bcpExcel.IsUserButtonClose = false;
            this.bcpExcel.IsUserCaptionBottomLine = false;
            this.bcpExcel.IsUserSystemCloseButtonLeft = true;
            this.bcpExcel.Location = new System.Drawing.Point(943, 2);
            this.bcpExcel.Name = "bcpExcel";
            this.bcpExcel.PanelImage = null;
            this.bcpExcel.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpExcel.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpExcel.Size = new System.Drawing.Size(81, 22);
            this.bcpExcel.TabIndex = 12;
            this.bcpExcel.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpExcel.Click += new System.EventHandler(this.bcpExcel_Click);
            // 
            // FrmHisPathAlert
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1028, 604);
            this.Controls.Add(this.dbgvMain);
            this.Controls.Add(this.cpnlTop);
            this.Controls.Add(this.bcpExcel);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.cpnlBottom);
            this.Name = "FrmHisPathAlert";
            this.TabText = "历史路径报警";
            this.Text = "历史路径报警";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPathAlert_Load);
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).EndInit();
            this.sxpPanelGroup1.ResumeLayout(false);
            this.sxpPanel1.ResumeLayout(false);
            this.sxpPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KJ128WindowsLibrary.CaptionPanel cpnlTop;
        private KJ128WindowsLibrary.CaptionPanel cpnlBottom;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox gbCondition;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblBeginTime;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpReset;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpSearch;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpExcel;
        private DataGridViewKJ128 dbgvMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationHeadAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationHeadPalce;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlertBeginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlertEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlertTimeValue;
        private Wilson.Controls.XPPanel.Images.SXPPanelGroup sxpPanelGroup1;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel1;
    }
}