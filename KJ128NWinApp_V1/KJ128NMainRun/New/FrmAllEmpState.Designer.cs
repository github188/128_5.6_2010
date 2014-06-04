namespace KJ128NMainRun
{
    partial class FrmAllEmpState
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAllEmpState));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sxpPanel2 = new Wilson.Controls.XPPanel.SXPPanel();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblBeginTime = new System.Windows.Forms.Label();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.bcpSelect = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.sxpPanelGroup1 = new Wilson.Controls.XPPanel.Images.SXPPanelGroup();
            this.cpStationToExcel = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.dgvMain = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlEmpCount = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.pnlCount = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.sxpPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).BeginInit();
            this.sxpPanelGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.sxpPanel2.Controls.Add(this.lblEndTime);
            this.sxpPanel2.Controls.Add(this.dtpEnd);
            this.sxpPanel2.Controls.Add(this.lblBeginTime);
            this.sxpPanel2.Controls.Add(this.dtpBegin);
            this.sxpPanel2.Controls.Add(this.bcpSelect);
            this.sxpPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.sxpPanel2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sxpPanel2.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.sxpPanel2.ImageItems.ImageSet = null;
            this.sxpPanel2.ImageItems.Normal = -1;
            this.sxpPanel2.Location = new System.Drawing.Point(8, 8);
            this.sxpPanel2.Name = "sxpPanel2";
            this.sxpPanel2.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel2.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel2.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel2.Size = new System.Drawing.Size(227, 152);
            this.sxpPanel2.TabIndex = 1;
            this.sxpPanel2.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel2.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel2.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel2.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(5, 81);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(72, 13);
            this.lblEndTime.TabIndex = 124;
            this.lblEndTime.Text = "结束时间：";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(79, 77);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(139, 20);
            this.dtpEnd.TabIndex = 5;
            // 
            // lblBeginTime
            // 
            this.lblBeginTime.AutoSize = true;
            this.lblBeginTime.Location = new System.Drawing.Point(5, 54);
            this.lblBeginTime.Name = "lblBeginTime";
            this.lblBeginTime.Size = new System.Drawing.Size(72, 13);
            this.lblBeginTime.TabIndex = 121;
            this.lblBeginTime.Text = "起始时间：";
            // 
            // dtpBegin
            // 
            this.dtpBegin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBegin.Location = new System.Drawing.Point(79, 50);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(139, 20);
            this.dtpBegin.TabIndex = 4;
            // 
            // bcpSelect
            // 
            this.bcpSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpSelect.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpSelect.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpSelect.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.bcpSelect.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.bcpSelect.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpSelect.CaptionBottomLineWidth = 1;
            this.bcpSelect.CaptionCloseButtonControlLeft = 2;
            this.bcpSelect.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpSelect.CaptionCloseButtonTitle = "×";
            this.bcpSelect.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpSelect.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bcpSelect.CaptionHeight = 20;
            this.bcpSelect.CaptionLeft = 1;
            this.bcpSelect.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpSelect.CaptionTitle = "查 询";
            this.bcpSelect.CaptionTitleLeft = 8;
            this.bcpSelect.CaptionTitleTop = 4;
            this.bcpSelect.CaptionTop = 1;
            this.bcpSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcpSelect.IsBorderLine = true;
            this.bcpSelect.IsCaptionSingleColor = false;
            this.bcpSelect.IsOnlyCaption = true;
            this.bcpSelect.IsPanelImage = true;
            this.bcpSelect.IsUserButtonClose = false;
            this.bcpSelect.IsUserCaptionBottomLine = false;
            this.bcpSelect.IsUserSystemCloseButtonLeft = true;
            this.bcpSelect.Location = new System.Drawing.Point(151, 118);
            this.bcpSelect.Name = "bcpSelect";
            this.bcpSelect.PanelImage = null;
            this.bcpSelect.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpSelect.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpSelect.Size = new System.Drawing.Size(60, 22);
            this.bcpSelect.TabIndex = 5;
            this.bcpSelect.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpSelect.Load += new System.EventHandler(this.bcpSelect_Load);
            this.bcpSelect.Click += new System.EventHandler(this.bcpSelect_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 3000;
            // 
            // sxpPanelGroup1
            // 
            this.sxpPanelGroup1.AutoScroll = true;
            this.sxpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel2);
            this.sxpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Left;
            this.sxpPanelGroup1.Location = new System.Drawing.Point(0, 0);
            this.sxpPanelGroup1.Name = "sxpPanelGroup1";
            this.sxpPanelGroup1.PanelGradient = ((Wilson.Controls.XPPanel.Colors.GradientColor)(resources.GetObject("sxpPanelGroup1.PanelGradient")));
            this.sxpPanelGroup1.Size = new System.Drawing.Size(243, 508);
            this.sxpPanelGroup1.TabIndex = 121;
            // 
            // cpStationToExcel
            // 
            this.cpStationToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpStationToExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpStationToExcel.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpStationToExcel.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpStationToExcel.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.cpStationToExcel.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.cpStationToExcel.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpStationToExcel.CaptionBottomLineWidth = 1;
            this.cpStationToExcel.CaptionCloseButtonControlLeft = 2;
            this.cpStationToExcel.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpStationToExcel.CaptionCloseButtonTitle = "×";
            this.cpStationToExcel.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpStationToExcel.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cpStationToExcel.CaptionHeight = 20;
            this.cpStationToExcel.CaptionLeft = 1;
            this.cpStationToExcel.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpStationToExcel.CaptionTitle = " 打  印";
            this.cpStationToExcel.CaptionTitleLeft = 10;
            this.cpStationToExcel.CaptionTitleTop = 4;
            this.cpStationToExcel.CaptionTop = 1;
            this.cpStationToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cpStationToExcel.IsBorderLine = true;
            this.cpStationToExcel.IsCaptionSingleColor = false;
            this.cpStationToExcel.IsOnlyCaption = true;
            this.cpStationToExcel.IsPanelImage = true;
            this.cpStationToExcel.IsUserButtonClose = false;
            this.cpStationToExcel.IsUserCaptionBottomLine = false;
            this.cpStationToExcel.IsUserSystemCloseButtonLeft = true;
            this.cpStationToExcel.Location = new System.Drawing.Point(865, 5);
            this.cpStationToExcel.Name = "cpStationToExcel";
            this.cpStationToExcel.PanelImage = null;
            this.cpStationToExcel.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.cpStationToExcel.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.cpStationToExcel.Size = new System.Drawing.Size(91, 22);
            this.cpStationToExcel.TabIndex = 123;
            this.cpStationToExcel.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.cpStationToExcel.Click += new System.EventHandler(this.cpStationToExcel_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
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
            this.dgvMain.ColumnHeadersHeight = 32;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMain.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.BlueStyle;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(191)))), ((int)(((byte)(219)))));
            this.dgvMain.Location = new System.Drawing.Point(243, 39);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMain.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dgvMain.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(717, 469);
            this.dgvMain.TabIndex = 124;
            this.dgvMain.VerticalScrollBarMax = 1;
            this.dgvMain.VerticalScrollBarValue = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pnlEmpCount);
            this.panel1.Controls.Add(this.pnlCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(243, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 39);
            this.panel1.TabIndex = 125;
            // 
            // pnlEmpCount
            // 
            this.pnlEmpCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEmpCount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlEmpCount.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.pnlEmpCount.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.pnlEmpCount.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.pnlEmpCount.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.pnlEmpCount.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.pnlEmpCount.CaptionBottomLineWidth = 1;
            this.pnlEmpCount.CaptionCloseButtonControlLeft = 2;
            this.pnlEmpCount.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pnlEmpCount.CaptionCloseButtonTitle = "×";
            this.pnlEmpCount.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlEmpCount.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.pnlEmpCount.CaptionHeight = 20;
            this.pnlEmpCount.CaptionLeft = 1;
            this.pnlEmpCount.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlEmpCount.CaptionTitle = "";
            this.pnlEmpCount.CaptionTitleLeft = 8;
            this.pnlEmpCount.CaptionTitleTop = 4;
            this.pnlEmpCount.CaptionTop = 1;
            this.pnlEmpCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlEmpCount.IsBorderLine = true;
            this.pnlEmpCount.IsCaptionSingleColor = true;
            this.pnlEmpCount.IsOnlyCaption = true;
            this.pnlEmpCount.IsPanelImage = true;
            this.pnlEmpCount.IsUserButtonClose = false;
            this.pnlEmpCount.IsUserCaptionBottomLine = false;
            this.pnlEmpCount.IsUserSystemCloseButtonLeft = true;
            this.pnlEmpCount.Location = new System.Drawing.Point(334, 7);
            this.pnlEmpCount.Name = "pnlEmpCount";
            this.pnlEmpCount.PanelImage = null;
            this.pnlEmpCount.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.pnlEmpCount.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.pnlEmpCount.Size = new System.Drawing.Size(117, 22);
            this.pnlEmpCount.TabIndex = 65;
            this.pnlEmpCount.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            // 
            // pnlCount
            // 
            this.pnlCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlCount.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.pnlCount.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.pnlCount.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.pnlCount.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.pnlCount.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.pnlCount.CaptionBottomLineWidth = 1;
            this.pnlCount.CaptionCloseButtonControlLeft = 2;
            this.pnlCount.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pnlCount.CaptionCloseButtonTitle = "×";
            this.pnlCount.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlCount.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.pnlCount.CaptionHeight = 20;
            this.pnlCount.CaptionLeft = 1;
            this.pnlCount.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlCount.CaptionTitle = "";
            this.pnlCount.CaptionTitleLeft = 8;
            this.pnlCount.CaptionTitleTop = 4;
            this.pnlCount.CaptionTop = 1;
            this.pnlCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlCount.IsBorderLine = true;
            this.pnlCount.IsCaptionSingleColor = true;
            this.pnlCount.IsOnlyCaption = true;
            this.pnlCount.IsPanelImage = true;
            this.pnlCount.IsUserButtonClose = false;
            this.pnlCount.IsUserCaptionBottomLine = false;
            this.pnlCount.IsUserSystemCloseButtonLeft = true;
            this.pnlCount.Location = new System.Drawing.Point(530, 7);
            this.pnlCount.Name = "pnlCount";
            this.pnlCount.PanelImage = null;
            this.pnlCount.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.pnlCount.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.pnlCount.Size = new System.Drawing.Size(174, 22);
            this.pnlCount.TabIndex = 64;
            this.pnlCount.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            // 
            // FrmAllEmpState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 508);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cpStationToExcel);
            this.Controls.Add(this.sxpPanelGroup1);
            this.Name = "FrmAllEmpState";
            this.TabText = "按时间段查询";
            this.Text = "按时间段查询";
            this.Load += new System.EventHandler(this.FrmAllEmpState_Load);
            this.sxpPanel2.ResumeLayout(false);
            this.sxpPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).EndInit();
            this.sxpPanelGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Wilson.Controls.XPPanel.SXPPanel sxpPanel2;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblBeginTime;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpSelect;
        private KJ128WindowsLibrary.ButtonCaptionPanel cpStationToExcel;
        private System.Windows.Forms.Timer timer;
        private Wilson.Controls.XPPanel.Images.SXPPanelGroup sxpPanelGroup1;
        private KJ128NInterfaceShow.DataGridViewKJ128 dgvMain;
        private System.Windows.Forms.Panel panel1;
        private KJ128WindowsLibrary.ButtonCaptionPanel pnlEmpCount;
        private KJ128WindowsLibrary.ButtonCaptionPanel pnlCount;
    }
}