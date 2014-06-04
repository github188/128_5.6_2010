namespace KJ128NInterfaceShow
{
    partial class RealTimeInOutStationHeadInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RealTimeInOutStationHeadInfo));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.dgValue = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vsPanel2 = new KJ128WindowsLibrary.VSPanel();
            this.lb_Counts = new System.Windows.Forms.Label();
            this.cpToExcel = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.buttonCaptionPanel1 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.vsPanel1 = new KJ128WindowsLibrary.VSPanel();
            this.sxpPanelGroup1 = new Wilson.Controls.XPPanel.Images.SXPPanelGroup();
            this.sxpPanel5 = new Wilson.Controls.XPPanel.SXPPanel();
            this.cmbStationAddress = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStationHeadAddress = new System.Windows.Forms.ComboBox();
            this.btnCancel = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnSearch = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.sxpPanel4 = new Wilson.Controls.XPPanel.SXPPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbEmp = new System.Windows.Forms.RadioButton();
            this.rbEqu = new System.Windows.Forms.RadioButton();
            this.sxpPanel3 = new Wilson.Controls.XPPanel.SXPPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtEndTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.sxpPanel2 = new Wilson.Controls.XPPanel.SXPPanel();
            this.gbx_Emp = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbWorkType = new System.Windows.Forms.ComboBox();
            this.txtName = new Shine.ShineTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCard = new KJ128N.Command.TxtNumber();
            this.gbx_Equ = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEquNO = new Shine.ShineTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEquAddress = new KJ128N.Command.TxtNumber();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEquName = new Shine.ShineTextBox();
            this.sxpPanel1 = new Wilson.Controls.XPPanel.SXPPanel();
            this.treeInfo = new KJ128WindowsLibrary.TreeViewDepartment();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgValue)).BeginInit();
            this.vsPanel2.SuspendLayout();
            this.vsPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).BeginInit();
            this.sxpPanelGroup1.SuspendLayout();
            this.sxpPanel5.SuspendLayout();
            this.sxpPanel4.SuspendLayout();
            this.sxpPanel3.SuspendLayout();
            this.sxpPanel2.SuspendLayout();
            this.gbx_Emp.SuspendLayout();
            this.gbx_Equ.SuspendLayout();
            this.sxpPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = KJ128NInterfaceShow.RefReshTime._rtTime;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
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
            this.Column3,
            this.Column4,
            this.Column10,
            this.Column11,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column9});
            this.dgValue.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.BlueStyle;
            this.dgValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgValue.EnableHeadersVisualStyles = false;
            this.dgValue.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(191)))), ((int)(((byte)(219)))));
            this.dgValue.Location = new System.Drawing.Point(220, 34);
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
            this.dgValue.Size = new System.Drawing.Size(899, 687);
            this.dgValue.TabIndex = 12;
            this.dgValue.VerticalScrollBarMax = 1;
            this.dgValue.VerticalScrollBarValue = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "发码器编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "姓名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "部门";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "工种";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "分站编号";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "接收器编号";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "接收器安装位置";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "所在位置";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "进入接收器时间";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "持续时间";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // vsPanel2
            // 
            this.vsPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.vsPanel2.BackLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.vsPanel2.BetweenControlCount = 2;
            this.vsPanel2.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.vsPanel2.BottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.vsPanel2.Controls.Add(this.lb_Counts);
            this.vsPanel2.Controls.Add(this.cpToExcel);
            this.vsPanel2.Controls.Add(this.buttonCaptionPanel1);
            this.vsPanel2.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.vsPanel2.Location = new System.Drawing.Point(220, 0);
            this.vsPanel2.MiddleInterval = 80;
            this.vsPanel2.Name = "vsPanel2";
            this.vsPanel2.RightInterval = 0;
            this.vsPanel2.SetBackGroundStyle = KJ128WindowsLibrary.VsPaneBackGroundStyle.paleCaption;
            this.vsPanel2.Size = new System.Drawing.Size(899, 34);
            this.vsPanel2.TabIndex = 15;
            this.vsPanel2.TopInterval = 0;
            this.vsPanel2.VerticalInterval = 8;
            // 
            // lb_Counts
            // 
            this.lb_Counts.AutoSize = true;
            this.lb_Counts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.lb_Counts.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.lb_Counts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.lb_Counts.Location = new System.Drawing.Point(175, 9);
            this.lb_Counts.Name = "lb_Counts";
            this.lb_Counts.Size = new System.Drawing.Size(91, 12);
            this.lb_Counts.TabIndex = 121;
            this.lb_Counts.Text = "共   个发码器";
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
            this.cpToExcel.Location = new System.Drawing.Point(815, 5);
            this.cpToExcel.Name = "cpToExcel";
            this.cpToExcel.PanelImage = null;
            this.cpToExcel.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.cpToExcel.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.cpToExcel.Size = new System.Drawing.Size(81, 22);
            this.cpToExcel.TabIndex = 120;
            this.cpToExcel.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.cpToExcel.Click += new System.EventHandler(this.cpToExcel_Click);
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
            this.buttonCaptionPanel1.CaptionTitle = "实时进出读卡分站显示：";
            this.buttonCaptionPanel1.CaptionTitleLeft = 8;
            this.buttonCaptionPanel1.CaptionTitleTop = 8;
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
            this.buttonCaptionPanel1.Location = new System.Drawing.Point(0, 0);
            this.buttonCaptionPanel1.Name = "buttonCaptionPanel1";
            this.buttonCaptionPanel1.PanelImage = null;
            this.buttonCaptionPanel1.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.buttonCaptionPanel1.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.buttonCaptionPanel1.Size = new System.Drawing.Size(899, 32);
            this.buttonCaptionPanel1.TabIndex = 0;
            this.buttonCaptionPanel1.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // vsPanel1
            // 
            this.vsPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.vsPanel1.BackLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.vsPanel1.BetweenControlCount = 2;
            this.vsPanel1.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.vsPanel1.BottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.vsPanel1.Controls.Add(this.sxpPanelGroup1);
            this.vsPanel1.Dock = System.Windows.Forms.DockStyle.Left;
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
            this.vsPanel1.Location = new System.Drawing.Point(0, 0);
            this.vsPanel1.MiddleInterval = 80;
            this.vsPanel1.Name = "vsPanel1";
            this.vsPanel1.RightInterval = 0;
            this.vsPanel1.SetBackGroundStyle = KJ128WindowsLibrary.VsPaneBackGroundStyle.windowsStyle;
            this.vsPanel1.Size = new System.Drawing.Size(220, 721);
            this.vsPanel1.TabIndex = 18;
            this.vsPanel1.TopInterval = 0;
            this.vsPanel1.VerticalInterval = 8;
            // 
            // sxpPanelGroup1
            // 
            this.sxpPanelGroup1.AutoScroll = true;
            this.sxpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel5);
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel4);
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel3);
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel2);
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel1);
            this.sxpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sxpPanelGroup1.Location = new System.Drawing.Point(0, 0);
            this.sxpPanelGroup1.Name = "sxpPanelGroup1";
            this.sxpPanelGroup1.PanelGradient = ((Wilson.Controls.XPPanel.Colors.GradientColor)(resources.GetObject("sxpPanelGroup1.PanelGradient")));
            this.sxpPanelGroup1.Size = new System.Drawing.Size(220, 721);
            this.sxpPanelGroup1.TabIndex = 123;
            // 
            // sxpPanel5
            // 
            this.sxpPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sxpPanel5.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanel5.Caption = "查询";
            this.sxpPanel5.CaptionCornerType = ((Wilson.Controls.XPPanel.Enums.CornerType)((Wilson.Controls.XPPanel.Enums.CornerType.TopLeft | Wilson.Controls.XPPanel.Enums.CornerType.TopRight)));
            this.sxpPanel5.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.sxpPanel5.CaptionGradient.Start = System.Drawing.Color.White;
            this.sxpPanel5.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel5.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sxpPanel5.Controls.Add(this.cmbStationAddress);
            this.sxpPanel5.Controls.Add(this.groupBox1);
            this.sxpPanel5.Controls.Add(this.chk);
            this.sxpPanel5.Controls.Add(this.label1);
            this.sxpPanel5.Controls.Add(this.cmbStationHeadAddress);
            this.sxpPanel5.Controls.Add(this.btnCancel);
            this.sxpPanel5.Controls.Add(this.btnSearch);
            this.sxpPanel5.Controls.Add(this.label4);
            this.sxpPanel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.sxpPanel5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sxpPanel5.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.sxpPanel5.ImageItems.ImageSet = null;
            this.sxpPanel5.ImageItems.Normal = -1;
            this.sxpPanel5.Location = new System.Drawing.Point(8, 551);
            this.sxpPanel5.Name = "sxpPanel5";
            this.sxpPanel5.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel5.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel5.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel5.Size = new System.Drawing.Size(204, 166);
            this.sxpPanel5.TabIndex = 2;
            this.sxpPanel5.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel5.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel5.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel5.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // cmbStationAddress
            // 
            this.cmbStationAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStationAddress.FormattingEnabled = true;
            this.cmbStationAddress.Location = new System.Drawing.Point(124, 44);
            this.cmbStationAddress.Name = "cmbStationAddress";
            this.cmbStationAddress.Size = new System.Drawing.Size(77, 20);
            this.cmbStationAddress.TabIndex = 5;
            this.cmbStationAddress.SelectionChangeCommitted += new System.EventHandler(this.cmbStationAddress_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(78, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(70, 22);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "限制条件";
            this.groupBox1.Visible = false;
            // 
            // chk
            // 
            this.chk.AutoSize = true;
            this.chk.Checked = true;
            this.chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk.Location = new System.Drawing.Point(72, 107);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(104, 17);
            this.chk.TabIndex = 19;
            this.chk.Text = "实时更新数据";
            this.chk.UseVisualStyleBackColor = true;
            this.chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "分站安装位置：";
            // 
            // cmbStationHeadAddress
            // 
            this.cmbStationHeadAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStationHeadAddress.FormattingEnabled = true;
            this.cmbStationHeadAddress.Location = new System.Drawing.Point(124, 76);
            this.cmbStationHeadAddress.Name = "cmbStationHeadAddress";
            this.cmbStationHeadAddress.Size = new System.Drawing.Size(77, 20);
            this.cmbStationHeadAddress.TabIndex = 3;
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
            this.btnCancel.Location = new System.Drawing.Point(115, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PanelImage = null;
            this.btnCancel.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnCancel.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnCancel.Size = new System.Drawing.Size(61, 22);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.btnSearch.Location = new System.Drawing.Point(14, 130);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PanelImage = null;
            this.btnSearch.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnSearch.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnSearch.Size = new System.Drawing.Size(61, 22);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "接收器安装位置：";
            // 
            // sxpPanel4
            // 
            this.sxpPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sxpPanel4.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanel4.Caption = "发码器配置类型";
            this.sxpPanel4.CaptionCornerType = ((Wilson.Controls.XPPanel.Enums.CornerType)((Wilson.Controls.XPPanel.Enums.CornerType.TopLeft | Wilson.Controls.XPPanel.Enums.CornerType.TopRight)));
            this.sxpPanel4.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.sxpPanel4.CaptionGradient.Start = System.Drawing.Color.White;
            this.sxpPanel4.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel4.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sxpPanel4.Controls.Add(this.groupBox4);
            this.sxpPanel4.Controls.Add(this.rbEmp);
            this.sxpPanel4.Controls.Add(this.rbEqu);
            this.sxpPanel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.sxpPanel4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sxpPanel4.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.sxpPanel4.ImageItems.ImageSet = null;
            this.sxpPanel4.ImageItems.Normal = -1;
            this.sxpPanel4.Location = new System.Drawing.Point(8, 465);
            this.sxpPanel4.Name = "sxpPanel4";
            this.sxpPanel4.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel4.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel4.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel4.Size = new System.Drawing.Size(204, 78);
            this.sxpPanel4.TabIndex = 2;
            this.sxpPanel4.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel4.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel4.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel4.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(72, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(70, 30);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "发码器配置类型";
            this.groupBox4.Visible = false;
            // 
            // rbEmp
            // 
            this.rbEmp.AutoSize = true;
            this.rbEmp.Checked = true;
            this.rbEmp.Location = new System.Drawing.Point(14, 44);
            this.rbEmp.Name = "rbEmp";
            this.rbEmp.Size = new System.Drawing.Size(51, 17);
            this.rbEmp.TabIndex = 5;
            this.rbEmp.TabStop = true;
            this.rbEmp.Text = "人员";
            this.rbEmp.UseVisualStyleBackColor = true;
            this.rbEmp.CheckedChanged += new System.EventHandler(this.rbEmp_CheckedChanged);
            // 
            // rbEqu
            // 
            this.rbEqu.AutoSize = true;
            this.rbEqu.Location = new System.Drawing.Point(126, 42);
            this.rbEqu.Name = "rbEqu";
            this.rbEqu.Size = new System.Drawing.Size(51, 17);
            this.rbEqu.TabIndex = 1;
            this.rbEqu.Text = "设备";
            this.rbEqu.UseVisualStyleBackColor = true;
            // 
            // sxpPanel3
            // 
            this.sxpPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sxpPanel3.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanel3.Caption = "监测时间范围";
            this.sxpPanel3.CaptionCornerType = ((Wilson.Controls.XPPanel.Enums.CornerType)((Wilson.Controls.XPPanel.Enums.CornerType.TopLeft | Wilson.Controls.XPPanel.Enums.CornerType.TopRight)));
            this.sxpPanel3.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.sxpPanel3.CaptionGradient.Start = System.Drawing.Color.White;
            this.sxpPanel3.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel3.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sxpPanel3.Controls.Add(this.label6);
            this.sxpPanel3.Controls.Add(this.groupBox2);
            this.sxpPanel3.Controls.Add(this.dtEndTime);
            this.sxpPanel3.Controls.Add(this.label3);
            this.sxpPanel3.Controls.Add(this.dtStartTime);
            this.sxpPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.sxpPanel3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sxpPanel3.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.sxpPanel3.ImageItems.ImageSet = null;
            this.sxpPanel3.ImageItems.Normal = -1;
            this.sxpPanel3.Location = new System.Drawing.Point(8, 357);
            this.sxpPanel3.Name = "sxpPanel3";
            this.sxpPanel3.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel3.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel3.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel3.Size = new System.Drawing.Size(204, 100);
            this.sxpPanel3.TabIndex = 2;
            this.sxpPanel3.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel3.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel3.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel3.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-1, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "开始时间:";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(78, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(70, 32);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "监测时间范围";
            this.groupBox2.Visible = false;
            // 
            // dtEndTime
            // 
            this.dtEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndTime.Location = new System.Drawing.Point(61, 70);
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.Size = new System.Drawing.Size(137, 20);
            this.dtEndTime.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "结束时间:";
            // 
            // dtStartTime
            // 
            this.dtStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartTime.Location = new System.Drawing.Point(61, 39);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Size = new System.Drawing.Size(137, 20);
            this.dtStartTime.TabIndex = 4;
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
            this.sxpPanel2.Controls.Add(this.gbx_Emp);
            this.sxpPanel2.Controls.Add(this.gbx_Equ);
            this.sxpPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.sxpPanel2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sxpPanel2.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.sxpPanel2.ImageItems.ImageSet = null;
            this.sxpPanel2.ImageItems.Normal = -1;
            this.sxpPanel2.Location = new System.Drawing.Point(8, 177);
            this.sxpPanel2.Name = "sxpPanel2";
            this.sxpPanel2.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel2.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel2.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel2.Size = new System.Drawing.Size(204, 172);
            this.sxpPanel2.TabIndex = 1;
            this.sxpPanel2.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel2.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel2.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel2.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // gbx_Emp
            // 
            this.gbx_Emp.Controls.Add(this.label10);
            this.gbx_Emp.Controls.Add(this.cmbWorkType);
            this.gbx_Emp.Controls.Add(this.txtName);
            this.gbx_Emp.Controls.Add(this.label5);
            this.gbx_Emp.Controls.Add(this.label8);
            this.gbx_Emp.Controls.Add(this.txtCard);
            this.gbx_Emp.Location = new System.Drawing.Point(2, 38);
            this.gbx_Emp.Name = "gbx_Emp";
            this.gbx_Emp.Size = new System.Drawing.Size(193, 123);
            this.gbx_Emp.TabIndex = 18;
            this.gbx_Emp.TabStop = false;
            this.gbx_Emp.Text = "分类查询";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "姓名：";
            // 
            // cmbWorkType
            // 
            this.cmbWorkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkType.FormattingEnabled = true;
            this.cmbWorkType.Location = new System.Drawing.Point(88, 74);
            this.cmbWorkType.Name = "cmbWorkType";
            this.cmbWorkType.Size = new System.Drawing.Size(92, 20);
            this.cmbWorkType.TabIndex = 11;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(88, 15);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(92, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextType = Shine.TextType.WithOutChar;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "工种名称：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-1, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "发码器编号：";
            // 
            // txtCard
            // 
            this.txtCard.Location = new System.Drawing.Point(88, 43);
            this.txtCard.MaxLength = 38;
            this.txtCard.Name = "txtCard";
            this.txtCard.Size = new System.Drawing.Size(92, 20);
            this.txtCard.TabIndex = 4;
            // 
            // gbx_Equ
            // 
            this.gbx_Equ.Controls.Add(this.label9);
            this.gbx_Equ.Controls.Add(this.txtEquNO);
            this.gbx_Equ.Controls.Add(this.label7);
            this.gbx_Equ.Controls.Add(this.txtEquAddress);
            this.gbx_Equ.Controls.Add(this.label2);
            this.gbx_Equ.Controls.Add(this.txtEquName);
            this.gbx_Equ.Location = new System.Drawing.Point(5, 38);
            this.gbx_Equ.Name = "gbx_Equ";
            this.gbx_Equ.Size = new System.Drawing.Size(191, 124);
            this.gbx_Equ.TabIndex = 122;
            this.gbx_Equ.TabStop = false;
            this.gbx_Equ.Text = "分类查询";
            this.gbx_Equ.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "设备名称：";
            // 
            // txtEquNO
            // 
            this.txtEquNO.Location = new System.Drawing.Point(91, 56);
            this.txtEquNO.MaxLength = 20;
            this.txtEquNO.Name = "txtEquNO";
            this.txtEquNO.Size = new System.Drawing.Size(92, 20);
            this.txtEquNO.TabIndex = 12;
            this.txtEquNO.TextType = Shine.TextType.WithOutChar;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "发码器编号：";
            // 
            // txtEquAddress
            // 
            this.txtEquAddress.Location = new System.Drawing.Point(91, 87);
            this.txtEquAddress.MaxLength = 38;
            this.txtEquAddress.Name = "txtEquAddress";
            this.txtEquAddress.Size = new System.Drawing.Size(92, 20);
            this.txtEquAddress.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "设备编号：";
            // 
            // txtEquName
            // 
            this.txtEquName.Location = new System.Drawing.Point(91, 28);
            this.txtEquName.MaxLength = 20;
            this.txtEquName.Name = "txtEquName";
            this.txtEquName.Size = new System.Drawing.Size(92, 20);
            this.txtEquName.TabIndex = 1;
            this.txtEquName.TextType = Shine.TextType.WithOutChar;
            // 
            // sxpPanel1
            // 
            this.sxpPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sxpPanel1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanel1.Caption = "选择部门";
            this.sxpPanel1.CaptionCornerType = ((Wilson.Controls.XPPanel.Enums.CornerType)((Wilson.Controls.XPPanel.Enums.CornerType.TopLeft | Wilson.Controls.XPPanel.Enums.CornerType.TopRight)));
            this.sxpPanel1.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.sxpPanel1.CaptionGradient.Start = System.Drawing.Color.White;
            this.sxpPanel1.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel1.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sxpPanel1.Controls.Add(this.treeInfo);
            this.sxpPanel1.Controls.Add(this.groupBox3);
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
            this.sxpPanel1.Size = new System.Drawing.Size(204, 161);
            this.sxpPanel1.TabIndex = 0;
            this.sxpPanel1.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel1.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel1.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel1.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // treeInfo
            // 
            this.treeInfo.BackColor = System.Drawing.Color.White;
            this.treeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeInfo.Location = new System.Drawing.Point(2, 35);
            this.treeInfo.Name = "treeInfo";
            this.treeInfo.Size = new System.Drawing.Size(200, 123);
            this.treeInfo.TabIndex = 12;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(107, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(78, 30);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "选择部门";
            this.groupBox3.Visible = false;
            // 
            // RealTimeInOutStationHeadInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1119, 721);
            this.Controls.Add(this.dgValue);
            this.Controls.Add(this.vsPanel2);
            this.Controls.Add(this.vsPanel1);
            this.Name = "RealTimeInOutStationHeadInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "实时进出读卡分站信息";
            this.Text = "实时进出读卡分站信息";
            this.Load += new System.EventHandler(this.RealTimeInOutStationHeadInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgValue)).EndInit();
            this.vsPanel2.ResumeLayout(false);
            this.vsPanel2.PerformLayout();
            this.vsPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).EndInit();
            this.sxpPanelGroup1.ResumeLayout(false);
            this.sxpPanel5.ResumeLayout(false);
            this.sxpPanel5.PerformLayout();
            this.sxpPanel4.ResumeLayout(false);
            this.sxpPanel4.PerformLayout();
            this.sxpPanel3.ResumeLayout(false);
            this.sxpPanel3.PerformLayout();
            this.sxpPanel2.ResumeLayout(false);
            this.gbx_Emp.ResumeLayout(false);
            this.gbx_Emp.PerformLayout();
            this.gbx_Equ.ResumeLayout(false);
            this.gbx_Equ.PerformLayout();
            this.sxpPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KJ128WindowsLibrary.VSPanel vsPanel1;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnCancel;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnSearch;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel1;
        private KJ128NInterfaceShow.DataGridViewKJ128 dgValue;
        private KJ128WindowsLibrary.VSPanel vsPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbStationHeadAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private KJ128WindowsLibrary.TreeViewDepartment treeInfo;
        private System.Windows.Forms.GroupBox gbx_Emp;
        private System.Windows.Forms.ComboBox cmbWorkType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtEndTime;
        private System.Windows.Forms.DateTimePicker dtStartTime;
        private System.Windows.Forms.ComboBox cmbStationAddress;
        private System.Windows.Forms.Timer timer;
        private KJ128N.Command.TxtNumber txtCard;
        private System.Windows.Forms.CheckBox chk;
        private KJ128WindowsLibrary.ButtonCaptionPanel cpToExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Label lb_Counts;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbEqu;
        private System.Windows.Forms.RadioButton rbEmp;
        private System.Windows.Forms.GroupBox gbx_Equ;
        private KJ128N.Command.TxtNumber txtEquAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private Wilson.Controls.XPPanel.Images.SXPPanelGroup sxpPanelGroup1;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel1;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel5;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel4;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel3;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel2;
        private Shine.ShineTextBox txtName;
        private Shine.ShineTextBox txtEquName;
        private Shine.ShineTextBox txtEquNO;


    }
}