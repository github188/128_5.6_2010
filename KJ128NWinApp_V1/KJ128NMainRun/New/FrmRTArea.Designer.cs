namespace KJ128NMainRun
{
    partial class FrmRTArea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRTArea));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBlockIDStation = new KJ128N.Command.TxtNumber();
            this.TxtEmployeeNameStation = new Shine.ShineTextBox();
            this.lblAreaName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sxpPanelGroup1 = new Wilson.Controls.XPPanel.Images.SXPPanelGroup();
            this.sxpPanel1 = new Wilson.Controls.XPPanel.SXPPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAreaType = new System.Windows.Forms.ComboBox();
            this.cmbAreaName = new System.Windows.Forms.ComboBox();
            this.chk = new System.Windows.Forms.CheckBox();
            this.btnQuery = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnReset = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.panelStation = new KJ128WindowsLibrary.CaptionPanel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.dgrd = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.PanelRowsCount = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.panelMain = new KJ128WindowsLibrary.CaptionPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).BeginInit();
            this.sxpPanelGroup1.SuspendLayout();
            this.sxpPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "员工姓名：";
            // 
            // txtBlockIDStation
            // 
            this.txtBlockIDStation.Location = new System.Drawing.Point(84, 84);
            this.txtBlockIDStation.Name = "txtBlockIDStation";
            this.txtBlockIDStation.Size = new System.Drawing.Size(111, 20);
            this.txtBlockIDStation.TabIndex = 52;
            // 
            // TxtEmployeeNameStation
            // 
            this.TxtEmployeeNameStation.Location = new System.Drawing.Point(84, 52);
            this.TxtEmployeeNameStation.Name = "TxtEmployeeNameStation";
            this.TxtEmployeeNameStation.Size = new System.Drawing.Size(111, 20);
            this.TxtEmployeeNameStation.TabIndex = 51;
            this.TxtEmployeeNameStation.TextType = Shine.TextType.WithOutChar;
            // 
            // lblAreaName
            // 
            this.lblAreaName.AutoSize = true;
            this.lblAreaName.Location = new System.Drawing.Point(-2, 88);
            this.lblAreaName.Name = "lblAreaName";
            this.lblAreaName.Size = new System.Drawing.Size(85, 13);
            this.lblAreaName.TabIndex = 48;
            this.lblAreaName.Text = "标识卡编号：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sxpPanelGroup1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 526);
            this.panel1.TabIndex = 69;
            // 
            // sxpPanelGroup1
            // 
            this.sxpPanelGroup1.AutoScroll = true;
            this.sxpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel1);
            this.sxpPanelGroup1.Controls.Add(this.panelStation);
            this.sxpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sxpPanelGroup1.Location = new System.Drawing.Point(0, 0);
            this.sxpPanelGroup1.Name = "sxpPanelGroup1";
            this.sxpPanelGroup1.PanelGradient = ((Wilson.Controls.XPPanel.Colors.GradientColor)(resources.GetObject("sxpPanelGroup1.PanelGradient")));
            this.sxpPanelGroup1.Size = new System.Drawing.Size(220, 526);
            this.sxpPanelGroup1.TabIndex = 70;
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
            this.sxpPanel1.Controls.Add(this.label2);
            this.sxpPanel1.Controls.Add(this.label1);
            this.sxpPanel1.Controls.Add(this.cmbAreaType);
            this.sxpPanel1.Controls.Add(this.cmbAreaName);
            this.sxpPanel1.Controls.Add(this.chk);
            this.sxpPanel1.Controls.Add(this.txtBlockIDStation);
            this.sxpPanel1.Controls.Add(this.btnQuery);
            this.sxpPanel1.Controls.Add(this.TxtEmployeeNameStation);
            this.sxpPanel1.Controls.Add(this.lblAreaName);
            this.sxpPanel1.Controls.Add(this.label3);
            this.sxpPanel1.Controls.Add(this.btnReset);
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
            this.sxpPanel1.Size = new System.Drawing.Size(204, 275);
            this.sxpPanel1.TabIndex = 70;
            this.sxpPanel1.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel1.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel1.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel1.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "区域类型：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "区域名称：";
            // 
            // cmbAreaType
            // 
            this.cmbAreaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAreaType.FormattingEnabled = true;
            this.cmbAreaType.Location = new System.Drawing.Point(78, 122);
            this.cmbAreaType.Name = "cmbAreaType";
            this.cmbAreaType.Size = new System.Drawing.Size(121, 20);
            this.cmbAreaType.TabIndex = 59;
            this.cmbAreaType.SelectionChangeCommitted += new System.EventHandler(this.cmbAreaType_SelectedIndexChanged);
            // 
            // cmbAreaName
            // 
            this.cmbAreaName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAreaName.FormattingEnabled = true;
            this.cmbAreaName.Location = new System.Drawing.Point(78, 160);
            this.cmbAreaName.Name = "cmbAreaName";
            this.cmbAreaName.Size = new System.Drawing.Size(121, 20);
            this.cmbAreaName.TabIndex = 58;
            // 
            // chk
            // 
            this.chk.AutoSize = true;
            this.chk.Checked = true;
            this.chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk.Location = new System.Drawing.Point(50, 238);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(104, 17);
            this.chk.TabIndex = 57;
            this.chk.Text = "实时更新数据";
            this.chk.UseVisualStyleBackColor = true;
            this.chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // btnQuery
            // 
            this.btnQuery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuery.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnQuery.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnQuery.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnQuery.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnQuery.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnQuery.CaptionBottomLineWidth = 1;
            this.btnQuery.CaptionCloseButtonControlLeft = 2;
            this.btnQuery.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnQuery.CaptionCloseButtonTitle = "×";
            this.btnQuery.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuery.CaptionHeight = 20;
            this.btnQuery.CaptionLeft = 1;
            this.btnQuery.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnQuery.CaptionTitle = " 查 询";
            this.btnQuery.CaptionTitleLeft = 8;
            this.btnQuery.CaptionTitleTop = 4;
            this.btnQuery.CaptionTop = 1;
            this.btnQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuery.IsBorderLine = true;
            this.btnQuery.IsCaptionSingleColor = false;
            this.btnQuery.IsOnlyCaption = true;
            this.btnQuery.IsPanelImage = true;
            this.btnQuery.IsUserButtonClose = false;
            this.btnQuery.IsUserCaptionBottomLine = false;
            this.btnQuery.IsUserSystemCloseButtonLeft = true;
            this.btnQuery.Location = new System.Drawing.Point(20, 201);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.PanelImage = null;
            this.btnQuery.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnQuery.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnQuery.Size = new System.Drawing.Size(71, 22);
            this.btnQuery.TabIndex = 53;
            this.btnQuery.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReset.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnReset.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnReset.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnReset.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnReset.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnReset.CaptionBottomLineWidth = 1;
            this.btnReset.CaptionCloseButtonControlLeft = 2;
            this.btnReset.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReset.CaptionCloseButtonTitle = "×";
            this.btnReset.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReset.CaptionHeight = 20;
            this.btnReset.CaptionLeft = 1;
            this.btnReset.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnReset.CaptionTitle = " 重 置";
            this.btnReset.CaptionTitleLeft = 8;
            this.btnReset.CaptionTitleTop = 4;
            this.btnReset.CaptionTop = 1;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.IsBorderLine = true;
            this.btnReset.IsCaptionSingleColor = false;
            this.btnReset.IsOnlyCaption = true;
            this.btnReset.IsPanelImage = true;
            this.btnReset.IsUserButtonClose = false;
            this.btnReset.IsUserCaptionBottomLine = false;
            this.btnReset.IsUserSystemCloseButtonLeft = true;
            this.btnReset.Location = new System.Drawing.Point(109, 201);
            this.btnReset.Name = "btnReset";
            this.btnReset.PanelImage = null;
            this.btnReset.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnReset.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnReset.Size = new System.Drawing.Size(71, 22);
            this.btnReset.TabIndex = 54;
            this.btnReset.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panelStation
            // 
            this.panelStation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelStation.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.panelStation.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.panelStation.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.panelStation.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.panelStation.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.panelStation.CaptionBottomLineWidth = 1;
            this.panelStation.CaptionCloseButtonControlLeft = 2;
            this.panelStation.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panelStation.CaptionCloseButtonTitle = "×";
            this.panelStation.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelStation.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelStation.CaptionHeight = 20;
            this.panelStation.CaptionLeft = 1;
            this.panelStation.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panelStation.CaptionTitle = "查询条件";
            this.panelStation.CaptionTitleLeft = 8;
            this.panelStation.CaptionTitleTop = 4;
            this.panelStation.CaptionTop = 1;
            this.panelStation.IsBorderLine = true;
            this.panelStation.IsCaptionSingleColor = false;
            this.panelStation.IsOnlyCaption = false;
            this.panelStation.IsPanelImage = false;
            this.panelStation.IsUserButtonClose = false;
            this.panelStation.IsUserCaptionBottomLine = true;
            this.panelStation.IsUserSystemCloseButtonLeft = true;
            this.panelStation.Location = new System.Drawing.Point(28, 331);
            this.panelStation.Name = "panelStation";
            this.panelStation.PanelImage = null;
            this.panelStation.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.panelStation.Size = new System.Drawing.Size(148, 64);
            this.panelStation.TabIndex = 39;
            this.panelStation.Visible = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 3000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // dgrd
            // 
            this.dgrd.AllowUserToAddRows = false;
            this.dgrd.AllowUserToDeleteRows = false;
            this.dgrd.AllowUserToOrderColumns = true;
            this.dgrd.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgrd.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrd.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.dgrd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(251)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgrd.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.BlueStyle;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrd.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrd.EnableHeadersVisualStyles = false;
            this.dgrd.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(191)))), ((int)(((byte)(219)))));
            this.dgrd.Location = new System.Drawing.Point(220, 31);
            this.dgrd.Name = "dgrd";
            this.dgrd.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrd.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrd.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dgrd.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgrd.RowTemplate.Height = 23;
            this.dgrd.Size = new System.Drawing.Size(808, 495);
            this.dgrd.TabIndex = 67;
            this.dgrd.VerticalScrollBarMax = 1;
            this.dgrd.VerticalScrollBarValue = 0;
            // 
            // PanelRowsCount
            // 
            this.PanelRowsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelRowsCount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelRowsCount.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.PanelRowsCount.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.PanelRowsCount.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.PanelRowsCount.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.PanelRowsCount.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.PanelRowsCount.CaptionBottomLineWidth = 1;
            this.PanelRowsCount.CaptionCloseButtonControlLeft = 2;
            this.PanelRowsCount.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.PanelRowsCount.CaptionCloseButtonTitle = "×";
            this.PanelRowsCount.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PanelRowsCount.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.PanelRowsCount.CaptionHeight = 20;
            this.PanelRowsCount.CaptionLeft = 1;
            this.PanelRowsCount.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.PanelRowsCount.CaptionTitle = "";
            this.PanelRowsCount.CaptionTitleLeft = 8;
            this.PanelRowsCount.CaptionTitleTop = 4;
            this.PanelRowsCount.CaptionTop = 1;
            this.PanelRowsCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.PanelRowsCount.IsBorderLine = true;
            this.PanelRowsCount.IsCaptionSingleColor = true;
            this.PanelRowsCount.IsOnlyCaption = true;
            this.PanelRowsCount.IsPanelImage = true;
            this.PanelRowsCount.IsUserButtonClose = false;
            this.PanelRowsCount.IsUserCaptionBottomLine = false;
            this.PanelRowsCount.IsUserSystemCloseButtonLeft = true;
            this.PanelRowsCount.Location = new System.Drawing.Point(903, 4);
            this.PanelRowsCount.Name = "PanelRowsCount";
            this.PanelRowsCount.PanelImage = null;
            this.PanelRowsCount.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.PanelRowsCount.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.PanelRowsCount.Size = new System.Drawing.Size(113, 22);
            this.PanelRowsCount.TabIndex = 68;
            this.PanelRowsCount.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            // 
            // panelMain
            // 
            this.panelMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMain.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.panelMain.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(189)))), ((int)(((byte)(105)))));
            this.panelMain.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.panelMain.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.panelMain.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.panelMain.CaptionBottomLineWidth = 1;
            this.panelMain.CaptionCloseButtonControlLeft = 2;
            this.panelMain.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panelMain.CaptionCloseButtonTitle = "×";
            this.panelMain.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelMain.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelMain.CaptionHeight = 30;
            this.panelMain.CaptionLeft = 1;
            this.panelMain.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panelMain.CaptionTitle = "";
            this.panelMain.CaptionTitleLeft = 8;
            this.panelMain.CaptionTitleTop = 4;
            this.panelMain.CaptionTop = 1;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.IsBorderLine = true;
            this.panelMain.IsCaptionSingleColor = false;
            this.panelMain.IsOnlyCaption = false;
            this.panelMain.IsPanelImage = false;
            this.panelMain.IsUserButtonClose = false;
            this.panelMain.IsUserCaptionBottomLine = true;
            this.panelMain.IsUserSystemCloseButtonLeft = true;
            this.panelMain.Location = new System.Drawing.Point(220, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.PanelImage = null;
            this.panelMain.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.panelMain.Size = new System.Drawing.Size(808, 31);
            this.panelMain.TabIndex = 38;
            // 
            // FrmRTArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1028, 526);
            this.Controls.Add(this.dgrd);
            this.Controls.Add(this.PanelRowsCount);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmRTArea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "实时进出区域方向性信息";
            this.Text = "实时进出区域方向性信息";
            this.Load += new System.EventHandler(this.SpecialWorkTypeTerrialSet_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).EndInit();
            this.sxpPanelGroup1.ResumeLayout(false);
            this.sxpPanel1.ResumeLayout(false);
            this.sxpPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KJ128WindowsLibrary.ButtonCaptionPanel PanelRowsCount;
        private KJ128NInterfaceShow.DataGridViewKJ128 dgrd;
        private KJ128WindowsLibrary.CaptionPanel panelStation;
        private KJ128WindowsLibrary.CaptionPanel panelMain;
        private System.Windows.Forms.Label label3;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnQuery;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnReset;
        private System.Windows.Forms.Label lblAreaName;
        private System.Windows.Forms.Panel panel1;
        private Wilson.Controls.XPPanel.Images.SXPPanelGroup sxpPanelGroup1;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel1;
        private KJ128N.Command.TxtNumber txtBlockIDStation;
        private Shine.ShineTextBox TxtEmployeeNameStation;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox chk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAreaType;
        private System.Windows.Forms.ComboBox cmbAreaName;
        private System.Windows.Forms.Label label2;
    }
}