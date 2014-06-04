using KJ128N.Command;

namespace KJ128NMainRun
{
    partial class FrmHisSpecialEmpAlarm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHisSpecialEmpAlarm));
            this.vsPanel1 = new KJ128WindowsLibrary.VSPanel();
            this.vsPanel2 = new KJ128WindowsLibrary.VSPanel();
            this.dgValue = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbPSize = new System.Windows.Forms.ComboBox();
            this.buttonCaptionPanel12 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.txtCheckPage = new KJ128N.Command.TxtNumber();
            this.bcpPageSum = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.lblSumPage = new KJ128WindowsLibrary.CaptionPanel();
            this.cpUp = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.txtPage = new KJ128WindowsLibrary.CaptionPanel();
            this.cpDown = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cpCheckPage = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cpToExcel = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.buttonCaptionPanel1 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.sxpPanelGroup1 = new Wilson.Controls.XPPanel.Images.SXPPanelGroup();
            this.gbx0 = new System.Windows.Forms.GroupBox();
            this.sxpPanel1 = new Wilson.Controls.XPPanel.SXPPanel();
            this.cmbWorkType = new System.Windows.Forms.ComboBox();
            this.lblSendCoderAddress = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtName = new Shine.ShineTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSendCoderAddress = new KJ128N.Command.TxtNumber();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.dtEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblDuty = new System.Windows.Forms.Label();
            this.lblWorkType = new System.Windows.Forms.Label();
            this.vsPanel1.SuspendLayout();
            this.vsPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).BeginInit();
            this.sxpPanelGroup1.SuspendLayout();
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
            this.vsPanel1.Controls.Add(this.vsPanel2);
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
            this.vsPanel1.Size = new System.Drawing.Size(1154, 476);
            this.vsPanel1.TabIndex = 23;
            this.vsPanel1.TopInterval = 0;
            this.vsPanel1.VerticalInterval = 8;
            // 
            // vsPanel2
            // 
            this.vsPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.vsPanel2.BackLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.vsPanel2.BetweenControlCount = 2;
            this.vsPanel2.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.vsPanel2.BottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.vsPanel2.Controls.Add(this.dgValue);
            this.vsPanel2.Controls.Add(this.cbPSize);
            this.vsPanel2.Controls.Add(this.buttonCaptionPanel12);
            this.vsPanel2.Controls.Add(this.txtCheckPage);
            this.vsPanel2.Controls.Add(this.bcpPageSum);
            this.vsPanel2.Controls.Add(this.lblSumPage);
            this.vsPanel2.Controls.Add(this.cpUp);
            this.vsPanel2.Controls.Add(this.txtPage);
            this.vsPanel2.Controls.Add(this.cpDown);
            this.vsPanel2.Controls.Add(this.cpCheckPage);
            this.vsPanel2.Controls.Add(this.cpToExcel);
            this.vsPanel2.Controls.Add(this.buttonCaptionPanel1);
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
            this.vsPanel2.Location = new System.Drawing.Point(220, 0);
            this.vsPanel2.MiddleInterval = 80;
            this.vsPanel2.Name = "vsPanel2";
            this.vsPanel2.RightInterval = 0;
            this.vsPanel2.SetBackGroundStyle = KJ128WindowsLibrary.VsPaneBackGroundStyle.paleCaption;
            this.vsPanel2.Size = new System.Drawing.Size(934, 476);
            this.vsPanel2.TabIndex = 25;
            this.vsPanel2.TopInterval = 0;
            this.vsPanel2.VerticalInterval = 8;
            // 
            // dgValue
            // 
            this.dgValue.AllowUserToAddRows = false;
            this.dgValue.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgValue.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgValue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgValue.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.dgValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgValue.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(251)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgValue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgValue.ColumnHeadersHeight = 32;
            this.dgValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgValue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column6});
            this.dgValue.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.BlueStyle;
            this.dgValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgValue.EnableHeadersVisualStyles = false;
            this.dgValue.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(191)))), ((int)(((byte)(219)))));
            this.dgValue.Location = new System.Drawing.Point(0, 32);
            this.dgValue.Name = "dgValue";
            this.dgValue.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgValue.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgValue.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dgValue.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgValue.RowTemplate.Height = 23;
            this.dgValue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgValue.Size = new System.Drawing.Size(934, 444);
            this.dgValue.TabIndex = 132;
            this.dgValue.VerticalScrollBarMax = 1;
            this.dgValue.VerticalScrollBarValue = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CodeSenderAddress";
            this.Column1.HeaderText = "发码器";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "EmpName";
            this.Column2.HeaderText = "姓名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Total";
            this.Column6.HeaderText = "报警次数";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
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
            this.cbPSize.Location = new System.Drawing.Point(785, 8);
            this.cbPSize.Name = "cbPSize";
            this.cbPSize.Size = new System.Drawing.Size(44, 20);
            this.cbPSize.TabIndex = 131;
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
            this.buttonCaptionPanel12.Location = new System.Drawing.Point(675, 8);
            this.buttonCaptionPanel12.Name = "buttonCaptionPanel12";
            this.buttonCaptionPanel12.PanelImage = null;
            this.buttonCaptionPanel12.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.buttonCaptionPanel12.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.buttonCaptionPanel12.Size = new System.Drawing.Size(106, 22);
            this.buttonCaptionPanel12.TabIndex = 130;
            this.buttonCaptionPanel12.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // txtCheckPage
            // 
            this.txtCheckPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCheckPage.Location = new System.Drawing.Point(590, 9);
            this.txtCheckPage.MaxLength = 10;
            this.txtCheckPage.Name = "txtCheckPage";
            this.txtCheckPage.Size = new System.Drawing.Size(26, 21);
            this.txtCheckPage.TabIndex = 129;
            this.txtCheckPage.Text = "1";
            this.txtCheckPage.Visible = false;
            // 
            // bcpPageSum
            // 
            this.bcpPageSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.bcpPageSum.Location = new System.Drawing.Point(296, 7);
            this.bcpPageSum.Name = "bcpPageSum";
            this.bcpPageSum.PanelImage = null;
            this.bcpPageSum.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.bcpPageSum.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.bcpPageSum.Size = new System.Drawing.Size(87, 22);
            this.bcpPageSum.TabIndex = 128;
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
            this.lblSumPage.Location = new System.Drawing.Point(549, 8);
            this.lblSumPage.Name = "lblSumPage";
            this.lblSumPage.PanelImage = null;
            this.lblSumPage.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.lblSumPage.Size = new System.Drawing.Size(36, 22);
            this.lblSumPage.TabIndex = 124;
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
            this.cpUp.Location = new System.Drawing.Point(393, 8);
            this.cpUp.Name = "cpUp";
            this.cpUp.PanelImage = null;
            this.cpUp.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.cpUp.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.cpUp.Size = new System.Drawing.Size(56, 22);
            this.cpUp.TabIndex = 123;
            this.cpUp.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.cpUp.Visible = false;
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
            this.txtPage.Location = new System.Drawing.Point(514, 8);
            this.txtPage.Name = "txtPage";
            this.txtPage.PanelImage = null;
            this.txtPage.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.txtPage.Size = new System.Drawing.Size(35, 22);
            this.txtPage.TabIndex = 125;
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
            this.cpDown.Location = new System.Drawing.Point(455, 8);
            this.cpDown.Name = "cpDown";
            this.cpDown.PanelImage = null;
            this.cpDown.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.cpDown.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.cpDown.Size = new System.Drawing.Size(56, 22);
            this.cpDown.TabIndex = 126;
            this.cpDown.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.cpDown.Visible = false;
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
            this.cpCheckPage.Location = new System.Drawing.Point(620, 8);
            this.cpCheckPage.Name = "cpCheckPage";
            this.cpCheckPage.PanelImage = null;
            this.cpCheckPage.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.cpCheckPage.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.cpCheckPage.Size = new System.Drawing.Size(51, 22);
            this.cpCheckPage.TabIndex = 127;
            this.cpCheckPage.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.cpCheckPage.Visible = false;
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
            this.cpToExcel.Location = new System.Drawing.Point(845, 8);
            this.cpToExcel.Name = "cpToExcel";
            this.cpToExcel.PanelImage = null;
            this.cpToExcel.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.cpToExcel.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.cpToExcel.Size = new System.Drawing.Size(83, 22);
            this.cpToExcel.TabIndex = 122;
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
            this.buttonCaptionPanel1.CaptionTitle = "特种作业人员报警显示：";
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
            this.buttonCaptionPanel1.Size = new System.Drawing.Size(934, 32);
            this.buttonCaptionPanel1.TabIndex = 0;
            this.buttonCaptionPanel1.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // sxpPanelGroup1
            // 
            this.sxpPanelGroup1.AutoScroll = true;
            this.sxpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanelGroup1.Controls.Add(this.gbx0);
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel1);
            this.sxpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Left;
            this.sxpPanelGroup1.Location = new System.Drawing.Point(0, 0);
            this.sxpPanelGroup1.Name = "sxpPanelGroup1";
            this.sxpPanelGroup1.PanelGradient = ((Wilson.Controls.XPPanel.Colors.GradientColor)(resources.GetObject("sxpPanelGroup1.PanelGradient")));
            this.sxpPanelGroup1.Size = new System.Drawing.Size(220, 476);
            this.sxpPanelGroup1.TabIndex = 26;
            // 
            // gbx0
            // 
            this.gbx0.Location = new System.Drawing.Point(59, 348);
            this.gbx0.Name = "gbx0";
            this.gbx0.Size = new System.Drawing.Size(50, 27);
            this.gbx0.TabIndex = 7;
            this.gbx0.TabStop = false;
            this.gbx0.Text = "查   询";
            this.gbx0.Visible = false;
            // 
            // sxpPanel1
            // 
            this.sxpPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sxpPanel1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanel1.Caption = "查询";
            this.sxpPanel1.CaptionCornerType = ((Wilson.Controls.XPPanel.Enums.CornerType)((Wilson.Controls.XPPanel.Enums.CornerType.TopLeft | Wilson.Controls.XPPanel.Enums.CornerType.TopRight)));
            this.sxpPanel1.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.sxpPanel1.CaptionGradient.Start = System.Drawing.Color.White;
            this.sxpPanel1.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel1.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sxpPanel1.Controls.Add(this.cmbWorkType);
            this.sxpPanel1.Controls.Add(this.lblSendCoderAddress);
            this.sxpPanel1.Controls.Add(this.cmbArea);
            this.sxpPanel1.Controls.Add(this.label10);
            this.sxpPanel1.Controls.Add(this.txtName);
            this.sxpPanel1.Controls.Add(this.label8);
            this.sxpPanel1.Controls.Add(this.txtSendCoderAddress);
            this.sxpPanel1.Controls.Add(this.dtStartTime);
            this.sxpPanel1.Controls.Add(this.btnSearch);
            this.sxpPanel1.Controls.Add(this.lblName);
            this.sxpPanel1.Controls.Add(this.dtEndTime);
            this.sxpPanel1.Controls.Add(this.lblDuty);
            this.sxpPanel1.Controls.Add(this.lblWorkType);
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
            this.sxpPanel1.Size = new System.Drawing.Size(204, 304);
            this.sxpPanel1.TabIndex = 0;
            this.sxpPanel1.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel1.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel1.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel1.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            this.sxpPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.sxpPanel1_Paint);
            // 
            // cmbWorkType
            // 
            this.cmbWorkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkType.FormattingEnabled = true;
            this.cmbWorkType.Location = new System.Drawing.Point(84, 76);
            this.cmbWorkType.Name = "cmbWorkType";
            this.cmbWorkType.Size = new System.Drawing.Size(112, 20);
            this.cmbWorkType.TabIndex = 147;
            // 
            // lblSendCoderAddress
            // 
            this.lblSendCoderAddress.AutoSize = true;
            this.lblSendCoderAddress.Location = new System.Drawing.Point(4, 45);
            this.lblSendCoderAddress.Name = "lblSendCoderAddress";
            this.lblSendCoderAddress.Size = new System.Drawing.Size(76, 13);
            this.lblSendCoderAddress.TabIndex = 15;
            this.lblSendCoderAddress.Text = "发码器编号:";
            // 
            // cmbArea
            // 
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(84, 145);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(112, 20);
            this.cmbArea.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "开始时间:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(84, 106);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(112, 20);
            this.txtName.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "结束时间:";
            // 
            // txtSendCoderAddress
            // 
            this.txtSendCoderAddress.Location = new System.Drawing.Point(84, 43);
            this.txtSendCoderAddress.Name = "txtSendCoderAddress";
            this.txtSendCoderAddress.Size = new System.Drawing.Size(112, 20);
            this.txtSendCoderAddress.TabIndex = 18;
            // 
            // dtStartTime
            // 
            this.dtStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartTime.Location = new System.Drawing.Point(62, 181);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Size = new System.Drawing.Size(137, 20);
            this.dtStartTime.TabIndex = 8;
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
            this.btnSearch.CaptionTitle = "查    询";
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
            this.btnSearch.Location = new System.Drawing.Point(51, 264);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PanelImage = null;
            this.btnSearch.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnSearch.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnSearch.Size = new System.Drawing.Size(91, 22);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 107);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(63, 13);
            this.lblName.TabIndex = 14;
            this.lblName.Text = "姓　　名:";
            // 
            // dtEndTime
            // 
            this.dtEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndTime.Location = new System.Drawing.Point(62, 220);
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.Size = new System.Drawing.Size(137, 20);
            this.dtEndTime.TabIndex = 9;
            // 
            // lblDuty
            // 
            this.lblDuty.AutoSize = true;
            this.lblDuty.Location = new System.Drawing.Point(3, 146);
            this.lblDuty.Name = "lblDuty";
            this.lblDuty.Size = new System.Drawing.Size(53, 13);
            this.lblDuty.TabIndex = 13;
            this.lblDuty.Text = "区    域:";
            // 
            // lblWorkType
            // 
            this.lblWorkType.AutoSize = true;
            this.lblWorkType.Location = new System.Drawing.Point(3, 77);
            this.lblWorkType.Name = "lblWorkType";
            this.lblWorkType.Size = new System.Drawing.Size(53, 13);
            this.lblWorkType.TabIndex = 12;
            this.lblWorkType.Text = "工    种:";
            // 
            // FrmHisSpecialEmpAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(1028, 476);
            this.Controls.Add(this.vsPanel1);
            this.Name = "FrmHisSpecialEmpAlarm";
            this.TabText = "特种作业人员工作异常报警总数及人员";
            this.Text = "特种作业人员工作异常报警总数及人员";
            this.Load += new System.EventHandler(this.FrmHisInMineEmpTotal_Load);
            this.vsPanel1.ResumeLayout(false);
            this.vsPanel2.ResumeLayout(false);
            this.vsPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).EndInit();
            this.sxpPanelGroup1.ResumeLayout(false);
            this.sxpPanel1.ResumeLayout(false);
            this.sxpPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KJ128WindowsLibrary.VSPanel vsPanel1;
        private System.Windows.Forms.GroupBox gbx0;
        private System.Windows.Forms.DateTimePicker dtEndTime;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnSearch;
        private System.Windows.Forms.DateTimePicker dtStartTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private KJ128WindowsLibrary.VSPanel vsPanel2;
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
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel1;
        private KJ128NInterfaceShow.DataGridViewKJ128 dgValue;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDuty;
        private System.Windows.Forms.Label lblWorkType;
        private System.Windows.Forms.Label lblSendCoderAddress;
        private System.Windows.Forms.TextBox txtName;
        private TxtNumber txtSendCoderAddress;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.ComboBox cmbWorkType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private Wilson.Controls.XPPanel.Images.SXPPanelGroup sxpPanelGroup1;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel1;
    }
}