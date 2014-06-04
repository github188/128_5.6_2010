namespace KJ128NMainRun
{
    partial class FrmRealTimeAlarmPath
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbRealTime = new System.Windows.Forms.CheckBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.bcpDelete = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.buttonCaptionPanel1 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.bcpExcel = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cpnlTop = new KJ128WindowsLibrary.CaptionPanel();
            this.bcpPageSum = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.dgvMain = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StationAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StationPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StationHeadAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StationHeadPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alarmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // cbRealTime
            // 
            this.cbRealTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRealTime.AutoSize = true;
            this.cbRealTime.Checked = true;
            this.cbRealTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRealTime.Location = new System.Drawing.Point(695, 43);
            this.cbRealTime.Name = "cbRealTime";
            this.cbRealTime.Size = new System.Drawing.Size(96, 16);
            this.cbRealTime.TabIndex = 2;
            this.cbRealTime.Text = "实时更新信息";
            this.cbRealTime.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 2000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // bcpDelete
            // 
            this.bcpDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bcpDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpDelete.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpDelete.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpDelete.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.bcpDelete.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.bcpDelete.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpDelete.CaptionBottomLineWidth = 1;
            this.bcpDelete.CaptionCloseButtonControlLeft = 2;
            this.bcpDelete.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpDelete.CaptionCloseButtonTitle = "×";
            this.bcpDelete.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpDelete.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bcpDelete.CaptionHeight = 20;
            this.bcpDelete.CaptionLeft = 1;
            this.bcpDelete.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpDelete.CaptionTitle = "删除所选行";
            this.bcpDelete.CaptionTitleLeft = 8;
            this.bcpDelete.CaptionTitleTop = 4;
            this.bcpDelete.CaptionTop = 1;
            this.bcpDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcpDelete.Enabled = false;
            this.bcpDelete.IsBorderLine = true;
            this.bcpDelete.IsCaptionSingleColor = false;
            this.bcpDelete.IsOnlyCaption = true;
            this.bcpDelete.IsPanelImage = true;
            this.bcpDelete.IsUserButtonClose = false;
            this.bcpDelete.IsUserCaptionBottomLine = false;
            this.bcpDelete.IsUserSystemCloseButtonLeft = true;
            this.bcpDelete.Location = new System.Drawing.Point(796, 40);
            this.bcpDelete.Name = "bcpDelete";
            this.bcpDelete.PanelImage = null;
            this.bcpDelete.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpDelete.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpDelete.Size = new System.Drawing.Size(81, 22);
            this.bcpDelete.TabIndex = 41;
            this.bcpDelete.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpDelete.Click += new System.EventHandler(this.bcpDelete_Click);
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
            this.buttonCaptionPanel1.Location = new System.Drawing.Point(341, -87);
            this.buttonCaptionPanel1.Name = "buttonCaptionPanel1";
            this.buttonCaptionPanel1.PanelImage = null;
            this.buttonCaptionPanel1.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.WindowsStyle;
            this.buttonCaptionPanel1.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.buttonCaptionPanel1.Size = new System.Drawing.Size(150, 22);
            this.buttonCaptionPanel1.TabIndex = 40;
            this.buttonCaptionPanel1.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
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
            this.bcpExcel.CaptionTitle = "打印";
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
            this.bcpExcel.Location = new System.Drawing.Point(827, 4);
            this.bcpExcel.Name = "bcpExcel";
            this.bcpExcel.PanelImage = null;
            this.bcpExcel.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpExcel.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpExcel.Size = new System.Drawing.Size(50, 22);
            this.bcpExcel.TabIndex = 1;
            this.bcpExcel.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpExcel.Click += new System.EventHandler(this.bcpExcel_Click);
            // 
            // cpnlTop
            // 
            this.cpnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpnlTop.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpnlTop.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpnlTop.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpnlTop.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpnlTop.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpnlTop.CaptionBottomLineWidth = 1;
            this.cpnlTop.CaptionCloseButtonControlLeft = 2;
            this.cpnlTop.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpnlTop.CaptionCloseButtonTitle = "×";
            this.cpnlTop.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpnlTop.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.cpnlTop.CaptionHeight = 30;
            this.cpnlTop.CaptionLeft = 1;
            this.cpnlTop.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpnlTop.CaptionTitle = "实时工作异常报警信息显示：";
            this.cpnlTop.CaptionTitleLeft = 8;
            this.cpnlTop.CaptionTitleTop = 4;
            this.cpnlTop.CaptionTop = 1;
            this.cpnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.cpnlTop.IsBorderLine = true;
            this.cpnlTop.IsCaptionSingleColor = true;
            this.cpnlTop.IsOnlyCaption = false;
            this.cpnlTop.IsPanelImage = false;
            this.cpnlTop.IsUserButtonClose = false;
            this.cpnlTop.IsUserCaptionBottomLine = false;
            this.cpnlTop.IsUserSystemCloseButtonLeft = true;
            this.cpnlTop.Location = new System.Drawing.Point(0, 0);
            this.cpnlTop.Name = "cpnlTop";
            this.cpnlTop.PanelImage = null;
            this.cpnlTop.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.cpnlTop.Size = new System.Drawing.Size(883, 74);
            this.cpnlTop.TabIndex = 0;
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
            this.bcpPageSum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bcpPageSum.IsBorderLine = true;
            this.bcpPageSum.IsCaptionSingleColor = true;
            this.bcpPageSum.IsOnlyCaption = true;
            this.bcpPageSum.IsPanelImage = false;
            this.bcpPageSum.IsUserButtonClose = false;
            this.bcpPageSum.IsUserCaptionBottomLine = false;
            this.bcpPageSum.IsUserSystemCloseButtonLeft = true;
            this.bcpPageSum.Location = new System.Drawing.Point(10, 40);
            this.bcpPageSum.Name = "bcpPageSum";
            this.bcpPageSum.PanelImage = null;
            this.bcpPageSum.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.bcpPageSum.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.bcpPageSum.Size = new System.Drawing.Size(179, 22);
            this.bcpPageSum.TabIndex = 38;
            this.bcpPageSum.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
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
            this.EmpID,
            this.EmpName,
            this.StationAddress,
            this.StationPlace,
            this.StationHeadAddress,
            this.StationHeadPlace,
            this.alarmTime});
            this.dgvMain.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.BlueStyle;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(191)))), ((int)(((byte)(219)))));
            this.dgvMain.Location = new System.Drawing.Point(0, 74);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dgvMain.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(883, 539);
            this.dgvMain.TabIndex = 39;
            this.dgvMain.VerticalScrollBarMax = 1;
            this.dgvMain.VerticalScrollBarValue = 0;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgvMain_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // EmpID
            // 
            this.EmpID.DataPropertyName = "EmpID";
            this.EmpID.HeaderText = "人员编号";
            this.EmpID.Name = "EmpID";
            this.EmpID.ReadOnly = true;
            this.EmpID.Visible = false;
            // 
            // EmpName
            // 
            this.EmpName.DataPropertyName = "EmpName";
            this.EmpName.HeaderText = "人员姓名";
            this.EmpName.Name = "EmpName";
            this.EmpName.ReadOnly = true;
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
            // StationHeadPlace
            // 
            this.StationHeadPlace.DataPropertyName = "StationHeadPlace";
            this.StationHeadPlace.HeaderText = "接收器安装位置";
            this.StationHeadPlace.Name = "StationHeadPlace";
            this.StationHeadPlace.ReadOnly = true;
            // 
            // alarmTime
            // 
            this.alarmTime.DataPropertyName = "AlarmDatetime";
            dataGridViewCellStyle3.Format = "G";
            dataGridViewCellStyle3.NullValue = null;
            this.alarmTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.alarmTime.HeaderText = "报警时间";
            this.alarmTime.Name = "alarmTime";
            this.alarmTime.ReadOnly = true;
            // 
            // FrmRealTimeAlarmPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(883, 613);
            this.Controls.Add(this.bcpDelete);
            this.Controls.Add(this.buttonCaptionPanel1);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.cbRealTime);
            this.Controls.Add(this.bcpExcel);
            this.Controls.Add(this.cpnlTop);
            this.Name = "FrmRealTimeAlarmPath";
            this.TabText = "实时工作异常报警信息";
            this.Text = "实时工作异常报警信息";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRealTimeAlarmPath_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KJ128WindowsLibrary.CaptionPanel cpnlTop;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpExcel;
        private System.Windows.Forms.CheckBox cbRealTime;
        private System.Windows.Forms.Timer timer;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpPageSum;
        private KJ128NInterfaceShow.DataGridViewKJ128 dgvMain;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel1;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationHeadAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationHeadPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn alarmTime;
    }
}