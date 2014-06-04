using KJ128NDataBase;
namespace KJ128NMainRun.HistoryInfo.HistoryStationBreak
{
    partial class FrmHisStationBreak
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHisStationBreak));
            this.vsPanel1 = new KJ128WindowsLibrary.VSPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbx0 = new System.Windows.Forms.GroupBox();
            this.cmb_StaBreak = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_StaPlace = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSearch = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnCancel = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.vsPanel2 = new KJ128WindowsLibrary.VSPanel();
            this.dgValue = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpToExcel = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cbPSize = new System.Windows.Forms.ComboBox();
            this.buttonCaptionPanel12 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.txtCheckPage = new KJ128N.Command.TxtNumber();
            this.bcpPageSum = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.lblSumPage = new KJ128WindowsLibrary.CaptionPanel();
            this.cpUp = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.txtPage = new KJ128WindowsLibrary.CaptionPanel();
            this.cpDown = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cpCheckPage = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.buttonCaptionPanel2 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.buttonCaptionPanel1 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.sxpPanelGroup1 = new Wilson.Controls.XPPanel.Images.SXPPanelGroup();
            this.sxpPanel2 = new Wilson.Controls.XPPanel.SXPPanel();
            this.sxpPanel1 = new Wilson.Controls.XPPanel.SXPPanel();
            this.vsPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).BeginInit();
            this.sxpPanelGroup1.SuspendLayout();
            this.sxpPanel2.SuspendLayout();
            this.sxpPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vsPanel1
            // 
            this.vsPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.vsPanel1.BackLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.vsPanel1.BetweenControlCount = 2;
            this.vsPanel1.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.vsPanel1.BottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.vsPanel1.HorizontalInterval = 8;
            this.vsPanel1.IsBorderLine = true;
            this.vsPanel1.IsBottomLineColor = false;
            this.vsPanel1.IsCaptionSingleColor = true;
            this.vsPanel1.IsDragModel = false;
            this.vsPanel1.IsmiddleInterval = false;
            this.vsPanel1.LayoutType = KJ128WindowsLibrary.VSPanelLayoutType.FreeLayoutType;
            this.vsPanel1.LeftInterval = 0;
            this.vsPanel1.LinearGradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.vsPanel1.LinearGradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.vsPanel1.Location = new System.Drawing.Point(13, 483);
            this.vsPanel1.MiddleInterval = 80;
            this.vsPanel1.Name = "vsPanel1";
            this.vsPanel1.RightInterval = 0;
            this.vsPanel1.SetBackGroundStyle = KJ128WindowsLibrary.VsPaneBackGroundStyle.windowsStyle;
            this.vsPanel1.Size = new System.Drawing.Size(158, 22);
            this.vsPanel1.TabIndex = 21;
            this.vsPanel1.TopInterval = 0;
            this.vsPanel1.VerticalInterval = 8;
            this.vsPanel1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(76, 531);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(72, 25);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "时间段选择";
            this.groupBox1.Visible = false;
            // 
            // dtEndTime
            // 
            this.dtEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndTime.Location = new System.Drawing.Point(68, 86);
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.Size = new System.Drawing.Size(134, 20);
            this.dtEndTime.TabIndex = 21;
            // 
            // dtStartTime
            // 
            this.dtStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartTime.Location = new System.Drawing.Point(68, 41);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Size = new System.Drawing.Size(134, 20);
            this.dtStartTime.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "结束时间：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "开始时间：";
            // 
            // gbx0
            // 
            this.gbx0.Location = new System.Drawing.Point(8, 522);
            this.gbx0.Name = "gbx0";
            this.gbx0.Size = new System.Drawing.Size(62, 34);
            this.gbx0.TabIndex = 7;
            this.gbx0.TabStop = false;
            this.gbx0.Text = "分类查询";
            this.gbx0.Visible = false;
            // 
            // cmb_StaBreak
            // 
            this.cmb_StaBreak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StaBreak.FormattingEnabled = true;
            this.cmb_StaBreak.Items.AddRange(new object[] {
            "所有故障",
            "分站故障",
            "接收器故障"});
            this.cmb_StaBreak.Location = new System.Drawing.Point(99, 92);
            this.cmb_StaBreak.Name = "cmb_StaBreak";
            this.cmb_StaBreak.Size = new System.Drawing.Size(100, 20);
            this.cmb_StaBreak.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "故障类型：";
            // 
            // cmb_StaPlace
            // 
            this.cmb_StaPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StaPlace.FormattingEnabled = true;
            this.cmb_StaPlace.Location = new System.Drawing.Point(100, 47);
            this.cmb_StaPlace.Name = "cmb_StaPlace";
            this.cmb_StaPlace.Size = new System.Drawing.Size(100, 20);
            this.cmb_StaPlace.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(0, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "分站安装位置：";
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnSearch.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnSearch.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnSearch.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnSearch.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnSearch.CaptionBottomLineWidth = 1;
            this.btnSearch.CaptionCloseButtonControlLeft = 2;
            this.btnSearch.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSearch.CaptionCloseButtonTitle = "×";
            this.btnSearch.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSearch.CaptionHeight = 20;
            this.btnSearch.CaptionLeft = 1;
            this.btnSearch.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnSearch.CaptionTitle = "查询";
            this.btnSearch.CaptionTitleLeft = 12;
            this.btnSearch.CaptionTitleTop = 4;
            this.btnSearch.CaptionTop = 1;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.IsBorderLine = true;
            this.btnSearch.IsCaptionSingleColor = false;
            this.btnSearch.IsOnlyCaption = true;
            this.btnSearch.IsPanelImage = true;
            this.btnSearch.IsUserButtonClose = false;
            this.btnSearch.IsUserCaptionBottomLine = false;
            this.btnSearch.IsUserSystemCloseButtonLeft = true;
            this.btnSearch.Location = new System.Drawing.Point(11, 118);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PanelImage = null;
            this.btnSearch.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnSearch.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnSearch.Size = new System.Drawing.Size(61, 22);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.btnCancel.CaptionTitle = "重置";
            this.btnCancel.CaptionTitleLeft = 12;
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
            this.btnCancel.Location = new System.Drawing.Point(129, 118);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PanelImage = null;
            this.btnCancel.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnCancel.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnCancel.Size = new System.Drawing.Size(61, 22);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // vsPanel2
            // 
            this.vsPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.vsPanel2.BackLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.vsPanel2.BetweenControlCount = 2;
            this.vsPanel2.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.vsPanel2.BottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.vsPanel2.Controls.Add(this.dgValue);
            this.vsPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsPanel2.HorizontalInterval = 8;
            this.vsPanel2.IsBorderLine = true;
            this.vsPanel2.IsBottomLineColor = true;
            this.vsPanel2.IsCaptionSingleColor = true;
            this.vsPanel2.IsDragModel = false;
            this.vsPanel2.IsmiddleInterval = false;
            this.vsPanel2.LayoutType = KJ128WindowsLibrary.VSPanelLayoutType.FreeLayoutType;
            this.vsPanel2.LeftInterval = 0;
            this.vsPanel2.LinearGradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.vsPanel2.LinearGradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.vsPanel2.Location = new System.Drawing.Point(220, 32);
            this.vsPanel2.MiddleInterval = 80;
            this.vsPanel2.Name = "vsPanel2";
            this.vsPanel2.RightInterval = 0;
            this.vsPanel2.SetBackGroundStyle = KJ128WindowsLibrary.VsPaneBackGroundStyle.paleCaption;
            this.vsPanel2.Size = new System.Drawing.Size(808, 628);
            this.vsPanel2.TabIndex = 22;
            this.vsPanel2.TopInterval = 0;
            this.vsPanel2.VerticalInterval = 8;
            // 
            // dgValue
            // 
            this.dgValue.AllowUserToAddRows = false;
            this.dgValue.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            this.dgValue.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgValue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgValue.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.dgValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgValue.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(251)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgValue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgValue.ColumnHeadersHeight = 32;
            this.dgValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgValue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column3,
            this.Column7,
            this.Column4,
            this.Column6});
            this.dgValue.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.BlueStyle;
            this.dgValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgValue.EnableHeadersVisualStyles = false;
            this.dgValue.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(191)))), ((int)(((byte)(219)))));
            this.dgValue.Location = new System.Drawing.Point(0, 0);
            this.dgValue.Name = "dgValue";
            this.dgValue.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgValue.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgValue.RowHeadersVisible = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dgValue.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgValue.RowTemplate.Height = 23;
            this.dgValue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgValue.Size = new System.Drawing.Size(808, 628);
            this.dgValue.TabIndex = 12;
            this.dgValue.VerticalScrollBarMax = 1;
            this.dgValue.VerticalScrollBarValue = 0;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 50F;
            this.Column1.HeaderText = "历史分站编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 50F;
            this.Column2.HeaderText = "历史接收器编号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 50F;
            this.Column5.HeaderText = "故障类型";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 138F;
            this.Column3.HeaderText = "分站或接收器安装位置";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 59.08629F;
            this.Column7.HeaderText = "故障开始时间";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 59.08629F;
            this.Column4.HeaderText = "故障结束时间";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 59.08629F;
            this.Column6.HeaderText = "故障持续时间";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
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
            this.cpToExcel.CaptionTitle = " 打   印";
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
            this.cpToExcel.Location = new System.Drawing.Point(935, 6);
            this.cpToExcel.Name = "cpToExcel";
            this.cpToExcel.PanelImage = null;
            this.cpToExcel.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.cpToExcel.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.cpToExcel.Size = new System.Drawing.Size(91, 22);
            this.cpToExcel.TabIndex = 115;
            this.cpToExcel.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.cpToExcel.Click += new System.EventHandler(this.cpToExcel_Click);
            // 
            // cbPSize
            // 
            this.cbPSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPSize.FormattingEnabled = true;
            this.cbPSize.Items.AddRange(new object[] {
            "40",
            "50",
            "100",
            "200",
            "500"});
            this.cbPSize.Location = new System.Drawing.Point(887, 7);
            this.cbPSize.Name = "cbPSize";
            this.cbPSize.Size = new System.Drawing.Size(44, 20);
            this.cbPSize.TabIndex = 99;
            this.cbPSize.DropDownClosed += new System.EventHandler(this.cbPSize_DropDownClosed);
            // 
            // buttonCaptionPanel12
            // 
            this.buttonCaptionPanel12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCaptionPanel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCaptionPanel12.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.buttonCaptionPanel12.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel12.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel12.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel12.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.buttonCaptionPanel12.CaptionBottomLineWidth = 1;
            this.buttonCaptionPanel12.CaptionCloseButtonControlLeft = 2;
            this.buttonCaptionPanel12.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCaptionPanel12.CaptionCloseButtonTitle = "×";
            this.buttonCaptionPanel12.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCaptionPanel12.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.buttonCaptionPanel12.CaptionHeight = 20;
            this.buttonCaptionPanel12.CaptionLeft = 1;
            this.buttonCaptionPanel12.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.buttonCaptionPanel12.CaptionTitle = "每页显示条数：";
            this.buttonCaptionPanel12.CaptionTitleLeft = 8;
            this.buttonCaptionPanel12.CaptionTitleTop = 4;
            this.buttonCaptionPanel12.CaptionTop = 1;
            this.buttonCaptionPanel12.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonCaptionPanel12.IsBorderLine = true;
            this.buttonCaptionPanel12.IsCaptionSingleColor = true;
            this.buttonCaptionPanel12.IsOnlyCaption = true;
            this.buttonCaptionPanel12.IsPanelImage = false;
            this.buttonCaptionPanel12.IsUserButtonClose = false;
            this.buttonCaptionPanel12.IsUserCaptionBottomLine = false;
            this.buttonCaptionPanel12.IsUserSystemCloseButtonLeft = true;
            this.buttonCaptionPanel12.Location = new System.Drawing.Point(778, 7);
            this.buttonCaptionPanel12.Name = "buttonCaptionPanel12";
            this.buttonCaptionPanel12.PanelImage = null;
            this.buttonCaptionPanel12.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.buttonCaptionPanel12.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.buttonCaptionPanel12.Size = new System.Drawing.Size(106, 22);
            this.buttonCaptionPanel12.TabIndex = 98;
            this.buttonCaptionPanel12.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // txtCheckPage
            // 
            this.txtCheckPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCheckPage.Location = new System.Drawing.Point(690, 8);
            this.txtCheckPage.MaxLength = 10;
            this.txtCheckPage.Name = "txtCheckPage";
            this.txtCheckPage.Size = new System.Drawing.Size(30, 21);
            this.txtCheckPage.TabIndex = 97;
            this.txtCheckPage.Text = "1";
            this.txtCheckPage.Visible = false;
            // 
            // bcpPageSum
            // 
            this.bcpPageSum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpPageSum.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpPageSum.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpPageSum.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpPageSum.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpPageSum.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpPageSum.CaptionBottomLineWidth = 1;
            this.bcpPageSum.CaptionCloseButtonControlLeft = 2;
            this.bcpPageSum.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpPageSum.CaptionCloseButtonTitle = "×";
            this.bcpPageSum.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpPageSum.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.bcpPageSum.CaptionHeight = 20;
            this.bcpPageSum.CaptionLeft = 1;
            this.bcpPageSum.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpPageSum.CaptionTitle = "";
            this.bcpPageSum.CaptionTitleLeft = 8;
            this.bcpPageSum.CaptionTitleTop = 4;
            this.bcpPageSum.CaptionTop = 1;
            this.bcpPageSum.Cursor = System.Windows.Forms.Cursors.Default;
            this.bcpPageSum.IsBorderLine = true;
            this.bcpPageSum.IsCaptionSingleColor = true;
            this.bcpPageSum.IsOnlyCaption = true;
            this.bcpPageSum.IsPanelImage = false;
            this.bcpPageSum.IsUserButtonClose = false;
            this.bcpPageSum.IsUserCaptionBottomLine = false;
            this.bcpPageSum.IsUserSystemCloseButtonLeft = true;
            this.bcpPageSum.Location = new System.Drawing.Point(784, 8);
            this.bcpPageSum.Name = "bcpPageSum";
            this.bcpPageSum.PanelImage = null;
            this.bcpPageSum.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.bcpPageSum.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.bcpPageSum.Size = new System.Drawing.Size(100, 22);
            this.bcpPageSum.TabIndex = 96;
            this.bcpPageSum.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpPageSum.Visible = false;
            // 
            // lblSumPage
            // 
            this.lblSumPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblSumPage.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.lblSumPage.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.lblSumPage.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.lblSumPage.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.lblSumPage.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.lblSumPage.CaptionBottomLineWidth = 0;
            this.lblSumPage.CaptionCloseButtonControlLeft = 2;
            this.lblSumPage.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblSumPage.CaptionCloseButtonTitle = "×";
            this.lblSumPage.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSumPage.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.lblSumPage.CaptionHeight = 20;
            this.lblSumPage.CaptionLeft = 0;
            this.lblSumPage.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.lblSumPage.CaptionTitle = "";
            this.lblSumPage.CaptionTitleLeft = 0;
            this.lblSumPage.CaptionTitleTop = 4;
            this.lblSumPage.CaptionTop = 1;
            this.lblSumPage.IsBorderLine = true;
            this.lblSumPage.IsCaptionSingleColor = true;
            this.lblSumPage.IsOnlyCaption = true;
            this.lblSumPage.IsPanelImage = false;
            this.lblSumPage.IsUserButtonClose = false;
            this.lblSumPage.IsUserCaptionBottomLine = false;
            this.lblSumPage.IsUserSystemCloseButtonLeft = true;
            this.lblSumPage.Location = new System.Drawing.Point(643, 7);
            this.lblSumPage.Name = "lblSumPage";
            this.lblSumPage.PanelImage = null;
            this.lblSumPage.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.lblSumPage.Size = new System.Drawing.Size(44, 22);
            this.lblSumPage.TabIndex = 92;
            this.lblSumPage.Visible = false;
            // 
            // cpUp
            // 
            this.cpUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpUp.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpUp.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpUp.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.cpUp.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.cpUp.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpUp.CaptionBottomLineWidth = 1;
            this.cpUp.CaptionCloseButtonControlLeft = 2;
            this.cpUp.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpUp.CaptionCloseButtonTitle = "×";
            this.cpUp.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpUp.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cpUp.CaptionHeight = 20;
            this.cpUp.CaptionLeft = 1;
            this.cpUp.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpUp.CaptionTitle = "上一页";
            this.cpUp.CaptionTitleLeft = 6;
            this.cpUp.CaptionTitleTop = 4;
            this.cpUp.CaptionTop = 1;
            this.cpUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cpUp.IsBorderLine = true;
            this.cpUp.IsCaptionSingleColor = false;
            this.cpUp.IsOnlyCaption = true;
            this.cpUp.IsPanelImage = false;
            this.cpUp.IsUserButtonClose = false;
            this.cpUp.IsUserCaptionBottomLine = false;
            this.cpUp.IsUserSystemCloseButtonLeft = true;
            this.cpUp.Location = new System.Drawing.Point(482, 7);
            this.cpUp.Name = "cpUp";
            this.cpUp.PanelImage = null;
            this.cpUp.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.cpUp.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.cpUp.Size = new System.Drawing.Size(56, 22);
            this.cpUp.TabIndex = 91;
            this.cpUp.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.cpUp.Visible = false;
            this.cpUp.Click += new System.EventHandler(this.cpUp_Click);
            // 
            // txtPage
            // 
            this.txtPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtPage.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.txtPage.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.txtPage.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.txtPage.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.txtPage.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.txtPage.CaptionBottomLineWidth = 0;
            this.txtPage.CaptionCloseButtonControlLeft = 2;
            this.txtPage.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtPage.CaptionCloseButtonTitle = "×";
            this.txtPage.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPage.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.txtPage.CaptionHeight = 20;
            this.txtPage.CaptionLeft = 1;
            this.txtPage.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.txtPage.CaptionTitle = "";
            this.txtPage.CaptionTitleLeft = 0;
            this.txtPage.CaptionTitleTop = 4;
            this.txtPage.CaptionTop = 1;
            this.txtPage.IsBorderLine = true;
            this.txtPage.IsCaptionSingleColor = true;
            this.txtPage.IsOnlyCaption = true;
            this.txtPage.IsPanelImage = false;
            this.txtPage.IsUserButtonClose = false;
            this.txtPage.IsUserCaptionBottomLine = false;
            this.txtPage.IsUserSystemCloseButtonLeft = true;
            this.txtPage.Location = new System.Drawing.Point(601, 7);
            this.txtPage.Name = "txtPage";
            this.txtPage.PanelImage = null;
            this.txtPage.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.txtPage.Size = new System.Drawing.Size(42, 22);
            this.txtPage.TabIndex = 93;
            this.txtPage.Visible = false;
            // 
            // cpDown
            // 
            this.cpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpDown.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpDown.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpDown.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.cpDown.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.cpDown.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpDown.CaptionBottomLineWidth = 1;
            this.cpDown.CaptionCloseButtonControlLeft = 2;
            this.cpDown.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpDown.CaptionCloseButtonTitle = "×";
            this.cpDown.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpDown.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cpDown.CaptionHeight = 20;
            this.cpDown.CaptionLeft = 1;
            this.cpDown.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpDown.CaptionTitle = "下一页";
            this.cpDown.CaptionTitleLeft = 6;
            this.cpDown.CaptionTitleTop = 4;
            this.cpDown.CaptionTop = 1;
            this.cpDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cpDown.IsBorderLine = true;
            this.cpDown.IsCaptionSingleColor = false;
            this.cpDown.IsOnlyCaption = true;
            this.cpDown.IsPanelImage = false;
            this.cpDown.IsUserButtonClose = false;
            this.cpDown.IsUserCaptionBottomLine = false;
            this.cpDown.IsUserSystemCloseButtonLeft = true;
            this.cpDown.Location = new System.Drawing.Point(542, 7);
            this.cpDown.Name = "cpDown";
            this.cpDown.PanelImage = null;
            this.cpDown.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.cpDown.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.cpDown.Size = new System.Drawing.Size(56, 22);
            this.cpDown.TabIndex = 94;
            this.cpDown.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.cpDown.Visible = false;
            this.cpDown.Click += new System.EventHandler(this.cpDown_Click);
            // 
            // cpCheckPage
            // 
            this.cpCheckPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpCheckPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpCheckPage.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpCheckPage.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpCheckPage.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.cpCheckPage.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.cpCheckPage.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpCheckPage.CaptionBottomLineWidth = 1;
            this.cpCheckPage.CaptionCloseButtonControlLeft = 2;
            this.cpCheckPage.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpCheckPage.CaptionCloseButtonTitle = "×";
            this.cpCheckPage.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpCheckPage.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cpCheckPage.CaptionHeight = 20;
            this.cpCheckPage.CaptionLeft = 1;
            this.cpCheckPage.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpCheckPage.CaptionTitle = "跳 至";
            this.cpCheckPage.CaptionTitleLeft = 6;
            this.cpCheckPage.CaptionTitleTop = 4;
            this.cpCheckPage.CaptionTop = 1;
            this.cpCheckPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cpCheckPage.IsBorderLine = true;
            this.cpCheckPage.IsCaptionSingleColor = false;
            this.cpCheckPage.IsOnlyCaption = true;
            this.cpCheckPage.IsPanelImage = false;
            this.cpCheckPage.IsUserButtonClose = false;
            this.cpCheckPage.IsUserCaptionBottomLine = false;
            this.cpCheckPage.IsUserSystemCloseButtonLeft = true;
            this.cpCheckPage.Location = new System.Drawing.Point(723, 7);
            this.cpCheckPage.Name = "cpCheckPage";
            this.cpCheckPage.PanelImage = null;
            this.cpCheckPage.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.cpCheckPage.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.cpCheckPage.Size = new System.Drawing.Size(51, 22);
            this.cpCheckPage.TabIndex = 95;
            this.cpCheckPage.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.cpCheckPage.Visible = false;
            this.cpCheckPage.Click += new System.EventHandler(this.cpCheckPage_Click);
            // 
            // buttonCaptionPanel2
            // 
            this.buttonCaptionPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCaptionPanel2.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.buttonCaptionPanel2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.buttonCaptionPanel2.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(121)))), ((int)(((byte)(191)))));
            this.buttonCaptionPanel2.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(97)))), ((int)(((byte)(168)))));
            this.buttonCaptionPanel2.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.buttonCaptionPanel2.CaptionBottomLineWidth = 1;
            this.buttonCaptionPanel2.CaptionCloseButtonControlLeft = 2;
            this.buttonCaptionPanel2.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCaptionPanel2.CaptionCloseButtonTitle = "×";
            this.buttonCaptionPanel2.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCaptionPanel2.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(22)))), ((int)(((byte)(110)))));
            this.buttonCaptionPanel2.CaptionHeight = 20;
            this.buttonCaptionPanel2.CaptionLeft = 1;
            this.buttonCaptionPanel2.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.buttonCaptionPanel2.CaptionTitle = "备注：当历史接收器编号为0时，表示分站故障；不为0时，表示接收器故障";
            this.buttonCaptionPanel2.CaptionTitleLeft = 8;
            this.buttonCaptionPanel2.CaptionTitleTop = 4;
            this.buttonCaptionPanel2.CaptionTop = 1;
            this.buttonCaptionPanel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonCaptionPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonCaptionPanel2.IsBorderLine = true;
            this.buttonCaptionPanel2.IsCaptionSingleColor = true;
            this.buttonCaptionPanel2.IsOnlyCaption = true;
            this.buttonCaptionPanel2.IsPanelImage = true;
            this.buttonCaptionPanel2.IsUserButtonClose = false;
            this.buttonCaptionPanel2.IsUserCaptionBottomLine = true;
            this.buttonCaptionPanel2.IsUserSystemCloseButtonLeft = true;
            this.buttonCaptionPanel2.Location = new System.Drawing.Point(220, 660);
            this.buttonCaptionPanel2.Name = "buttonCaptionPanel2";
            this.buttonCaptionPanel2.PanelImage = null;
            this.buttonCaptionPanel2.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.buttonCaptionPanel2.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.paleCaption;
            this.buttonCaptionPanel2.Size = new System.Drawing.Size(808, 22);
            this.buttonCaptionPanel2.TabIndex = 13;
            this.buttonCaptionPanel2.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // buttonCaptionPanel1
            // 
            this.buttonCaptionPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCaptionPanel1.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.buttonCaptionPanel1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel1.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(121)))), ((int)(((byte)(191)))));
            this.buttonCaptionPanel1.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(97)))), ((int)(((byte)(168)))));
            this.buttonCaptionPanel1.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.buttonCaptionPanel1.CaptionBottomLineWidth = 1;
            this.buttonCaptionPanel1.CaptionCloseButtonControlLeft = 2;
            this.buttonCaptionPanel1.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCaptionPanel1.CaptionCloseButtonTitle = "×";
            this.buttonCaptionPanel1.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCaptionPanel1.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.buttonCaptionPanel1.CaptionHeight = 30;
            this.buttonCaptionPanel1.CaptionLeft = 1;
            this.buttonCaptionPanel1.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.buttonCaptionPanel1.CaptionTitle = "历史传输分站读卡分站故障信息显示：";
            this.buttonCaptionPanel1.CaptionTitleLeft = 8;
            this.buttonCaptionPanel1.CaptionTitleTop = 10;
            this.buttonCaptionPanel1.CaptionTop = 1;
            this.buttonCaptionPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonCaptionPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCaptionPanel1.IsBorderLine = true;
            this.buttonCaptionPanel1.IsCaptionSingleColor = true;
            this.buttonCaptionPanel1.IsOnlyCaption = true;
            this.buttonCaptionPanel1.IsPanelImage = true;
            this.buttonCaptionPanel1.IsUserButtonClose = false;
            this.buttonCaptionPanel1.IsUserCaptionBottomLine = false;
            this.buttonCaptionPanel1.IsUserSystemCloseButtonLeft = true;
            this.buttonCaptionPanel1.Location = new System.Drawing.Point(220, 0);
            this.buttonCaptionPanel1.Name = "buttonCaptionPanel1";
            this.buttonCaptionPanel1.PanelImage = null;
            this.buttonCaptionPanel1.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.buttonCaptionPanel1.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.buttonCaptionPanel1.Size = new System.Drawing.Size(808, 32);
            this.buttonCaptionPanel1.TabIndex = 0;
            this.buttonCaptionPanel1.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // sxpPanelGroup1
            // 
            this.sxpPanelGroup1.AutoScroll = true;
            this.sxpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel2);
            this.sxpPanelGroup1.Controls.Add(this.groupBox1);
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel1);
            this.sxpPanelGroup1.Controls.Add(this.vsPanel1);
            this.sxpPanelGroup1.Controls.Add(this.gbx0);
            this.sxpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Left;
            this.sxpPanelGroup1.Location = new System.Drawing.Point(0, 0);
            this.sxpPanelGroup1.Name = "sxpPanelGroup1";
            this.sxpPanelGroup1.PanelGradient = ((Wilson.Controls.XPPanel.Colors.GradientColor)(resources.GetObject("sxpPanelGroup1.PanelGradient")));
            this.sxpPanelGroup1.Size = new System.Drawing.Size(220, 682);
            this.sxpPanelGroup1.TabIndex = 116;
            // 
            // sxpPanel2
            // 
            this.sxpPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sxpPanel2.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanel2.Caption = "分类查询";
            this.sxpPanel2.CaptionCornerType = ((Wilson.Controls.XPPanel.Enums.CornerType)((Wilson.Controls.XPPanel.Enums.CornerType.TopLeft | Wilson.Controls.XPPanel.Enums.CornerType.TopRight)));
            this.sxpPanel2.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.sxpPanel2.CaptionGradient.Start = System.Drawing.Color.White;
            this.sxpPanel2.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel2.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sxpPanel2.Controls.Add(this.cmb_StaBreak);
            this.sxpPanel2.Controls.Add(this.btnSearch);
            this.sxpPanel2.Controls.Add(this.label3);
            this.sxpPanel2.Controls.Add(this.btnCancel);
            this.sxpPanel2.Controls.Add(this.cmb_StaPlace);
            this.sxpPanel2.Controls.Add(this.label10);
            this.sxpPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.sxpPanel2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sxpPanel2.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.sxpPanel2.ImageItems.ImageSet = null;
            this.sxpPanel2.ImageItems.Normal = -1;
            this.sxpPanel2.Location = new System.Drawing.Point(8, 145);
            this.sxpPanel2.Name = "sxpPanel2";
            this.sxpPanel2.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel2.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel2.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel2.Size = new System.Drawing.Size(204, 160);
            this.sxpPanel2.TabIndex = 118;
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
            this.sxpPanel1.Caption = "时间段选择";
            this.sxpPanel1.CaptionCornerType = ((Wilson.Controls.XPPanel.Enums.CornerType)((Wilson.Controls.XPPanel.Enums.CornerType.TopLeft | Wilson.Controls.XPPanel.Enums.CornerType.TopRight)));
            this.sxpPanel1.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.sxpPanel1.CaptionGradient.Start = System.Drawing.Color.White;
            this.sxpPanel1.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel1.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sxpPanel1.Controls.Add(this.dtEndTime);
            this.sxpPanel1.Controls.Add(this.dtStartTime);
            this.sxpPanel1.Controls.Add(this.label1);
            this.sxpPanel1.Controls.Add(this.label2);
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
            this.sxpPanel1.Size = new System.Drawing.Size(204, 129);
            this.sxpPanel1.TabIndex = 117;
            this.sxpPanel1.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel1.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel1.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel1.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // FrmHisStationBreak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1028, 682);
            this.Controls.Add(this.vsPanel2);
            this.Controls.Add(this.buttonCaptionPanel2);
            this.Controls.Add(this.cpToExcel);
            this.Controls.Add(this.cbPSize);
            this.Controls.Add(this.buttonCaptionPanel12);
            this.Controls.Add(this.txtCheckPage);
            this.Controls.Add(this.cpUp);
            this.Controls.Add(this.bcpPageSum);
            this.Controls.Add(this.cpCheckPage);
            this.Controls.Add(this.lblSumPage);
            this.Controls.Add(this.cpDown);
            this.Controls.Add(this.txtPage);
            this.Controls.Add(this.buttonCaptionPanel1);
            this.Controls.Add(this.sxpPanelGroup1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHisStationBreak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "历史传输分站读卡分站故障信息";
            this.Text = "历史传输分站读卡分站故障信息";
            this.Load += new System.EventHandler(this.FrmHisStationBreak_Load);
            this.vsPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).EndInit();
            this.sxpPanelGroup1.ResumeLayout(false);
            this.sxpPanel2.ResumeLayout(false);
            this.sxpPanel2.PerformLayout();
            this.sxpPanel1.ResumeLayout(false);
            this.sxpPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KJ128WindowsLibrary.VSPanel vsPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtEndTime;
        private System.Windows.Forms.DateTimePicker dtStartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbx0;
        private System.Windows.Forms.Label label10;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnSearch;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnCancel;
        private KJ128WindowsLibrary.VSPanel vsPanel2;
        private KJ128NInterfaceShow.DataGridViewKJ128 dgValue;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel1;
        private System.Windows.Forms.ComboBox cmb_StaPlace;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel2;
        private System.Windows.Forms.ComboBox cbPSize;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel12;
        private KJ128N.Command.TxtNumber txtCheckPage;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpPageSum;
        private KJ128WindowsLibrary.CaptionPanel lblSumPage;
        private KJ128WindowsLibrary.ButtonCaptionPanel cpUp;
        private KJ128WindowsLibrary.CaptionPanel txtPage;
        private KJ128WindowsLibrary.ButtonCaptionPanel cpDown;
        private KJ128WindowsLibrary.ButtonCaptionPanel cpCheckPage;
        private KJ128WindowsLibrary.ButtonCaptionPanel cpToExcel;
        private System.Windows.Forms.ComboBox cmb_StaBreak;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private Wilson.Controls.XPPanel.Images.SXPPanelGroup sxpPanelGroup1;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel1;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel2;

    }
}