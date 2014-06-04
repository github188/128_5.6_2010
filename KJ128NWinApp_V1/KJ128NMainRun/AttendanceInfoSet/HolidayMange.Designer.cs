namespace KJ128NInterfaceShow
{
    partial class HolidayMange
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbRowsSet = new System.Windows.Forms.ComboBox();
            this.btnCurrentPageIndex = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnNext = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnpreview = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.captionPanel1 = new KJ128WindowsLibrary.CaptionPanel();
            this.btnRowsCount = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.captionPanel2 = new KJ128WindowsLibrary.CaptionPanel();
            this.gbStations = new System.Windows.Forms.GroupBox();
            this.txtCSAddress = new KJ128N.Command.TxtNumber();
            this.cbHolidayType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbEndTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbBeginTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDept = new System.Windows.Forms.ComboBox();
            this.txtEmpName = new Shine.ShineTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lable1 = new System.Windows.Forms.Label();
            this.btnQuery = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnReset = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.txtJump = new KJ128N.Command.TxtNumber();
            this.btnJump = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnAdd = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cpModify = new KJ128WindowsLibrary.CaptionPanel();
            this.gbUpdate = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtHoliday = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.cbHolidayTypeAdd = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmpNameAdd = new Shine.ShineTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBlockAdd = new KJ128N.Command.TxtNumber();
            this.label6 = new System.Windows.Forms.Label();
            this.cbDeptAdd = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnModify = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.btnReturn = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.lblErr = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblPageIndex = new System.Windows.Forms.Label();
            this.dgrd = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.cellEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cellDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.captionPanel3 = new KJ128WindowsLibrary.CaptionPanel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bcpRef = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.gbStations.SuspendLayout();
            this.gbUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbRowsSet
            // 
            this.cbRowsSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRowsSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRowsSet.FormattingEnabled = true;
            this.cbRowsSet.Location = new System.Drawing.Point(8, 7);
            this.cbRowsSet.Name = "cbRowsSet";
            this.cbRowsSet.Size = new System.Drawing.Size(124, 20);
            this.cbRowsSet.TabIndex = 6;
            this.cbRowsSet.SelectionChangeCommitted += new System.EventHandler(this.cbRowsSet_SelectionChangeCommitted);
            // 
            // btnCurrentPageIndex
            // 
            this.btnCurrentPageIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCurrentPageIndex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCurrentPageIndex.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnCurrentPageIndex.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnCurrentPageIndex.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnCurrentPageIndex.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnCurrentPageIndex.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnCurrentPageIndex.CaptionBottomLineWidth = 1;
            this.btnCurrentPageIndex.CaptionCloseButtonControlLeft = 2;
            this.btnCurrentPageIndex.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCurrentPageIndex.CaptionCloseButtonTitle = "×";
            this.btnCurrentPageIndex.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCurrentPageIndex.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.btnCurrentPageIndex.CaptionHeight = 20;
            this.btnCurrentPageIndex.CaptionLeft = 1;
            this.btnCurrentPageIndex.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCurrentPageIndex.CaptionTitle = "";
            this.btnCurrentPageIndex.CaptionTitleLeft = 20;
            this.btnCurrentPageIndex.CaptionTitleTop = 4;
            this.btnCurrentPageIndex.CaptionTop = 1;
            this.btnCurrentPageIndex.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCurrentPageIndex.IsBorderLine = true;
            this.btnCurrentPageIndex.IsCaptionSingleColor = true;
            this.btnCurrentPageIndex.IsOnlyCaption = true;
            this.btnCurrentPageIndex.IsPanelImage = true;
            this.btnCurrentPageIndex.IsUserButtonClose = false;
            this.btnCurrentPageIndex.IsUserCaptionBottomLine = false;
            this.btnCurrentPageIndex.IsUserSystemCloseButtonLeft = true;
            this.btnCurrentPageIndex.Location = new System.Drawing.Point(560, 6);
            this.btnCurrentPageIndex.Name = "btnCurrentPageIndex";
            this.btnCurrentPageIndex.PanelImage = null;
            this.btnCurrentPageIndex.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.btnCurrentPageIndex.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.btnCurrentPageIndex.Size = new System.Drawing.Size(71, 22);
            this.btnCurrentPageIndex.TabIndex = 4;
            this.btnCurrentPageIndex.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNext.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnNext.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnNext.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnNext.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnNext.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnNext.CaptionBottomLineWidth = 1;
            this.btnNext.CaptionCloseButtonControlLeft = 2;
            this.btnNext.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNext.CaptionCloseButtonTitle = "×";
            this.btnNext.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNext.CaptionHeight = 20;
            this.btnNext.CaptionLeft = 1;
            this.btnNext.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnNext.CaptionTitle = "下一页";
            this.btnNext.CaptionTitleLeft = 20;
            this.btnNext.CaptionTitleTop = 4;
            this.btnNext.CaptionTop = 1;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.IsBorderLine = true;
            this.btnNext.IsCaptionSingleColor = false;
            this.btnNext.IsOnlyCaption = true;
            this.btnNext.IsPanelImage = true;
            this.btnNext.IsUserButtonClose = false;
            this.btnNext.IsUserCaptionBottomLine = false;
            this.btnNext.IsUserSystemCloseButtonLeft = true;
            this.btnNext.Location = new System.Drawing.Point(474, 6);
            this.btnNext.Name = "btnNext";
            this.btnNext.PanelImage = null;
            this.btnNext.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnNext.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnNext.Size = new System.Drawing.Size(81, 22);
            this.btnNext.TabIndex = 3;
            this.btnNext.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnpreview
            // 
            this.btnpreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnpreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnpreview.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnpreview.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnpreview.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnpreview.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnpreview.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnpreview.CaptionBottomLineWidth = 1;
            this.btnpreview.CaptionCloseButtonControlLeft = 2;
            this.btnpreview.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnpreview.CaptionCloseButtonTitle = "×";
            this.btnpreview.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnpreview.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnpreview.CaptionHeight = 20;
            this.btnpreview.CaptionLeft = 1;
            this.btnpreview.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnpreview.CaptionTitle = "上一页";
            this.btnpreview.CaptionTitleLeft = 20;
            this.btnpreview.CaptionTitleTop = 4;
            this.btnpreview.CaptionTop = 1;
            this.btnpreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnpreview.IsBorderLine = true;
            this.btnpreview.IsCaptionSingleColor = false;
            this.btnpreview.IsOnlyCaption = true;
            this.btnpreview.IsPanelImage = true;
            this.btnpreview.IsUserButtonClose = false;
            this.btnpreview.IsUserCaptionBottomLine = false;
            this.btnpreview.IsUserSystemCloseButtonLeft = true;
            this.btnpreview.Location = new System.Drawing.Point(383, 6);
            this.btnpreview.Name = "btnpreview";
            this.btnpreview.PanelImage = null;
            this.btnpreview.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnpreview.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnpreview.Size = new System.Drawing.Size(86, 22);
            this.btnpreview.TabIndex = 2;
            this.btnpreview.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnpreview.Click += new System.EventHandler(this.btnpreview_Click);
            // 
            // captionPanel1
            // 
            this.captionPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.captionPanel1.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.captionPanel1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.captionPanel1.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.captionPanel1.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.captionPanel1.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.captionPanel1.CaptionBottomLineWidth = 1;
            this.captionPanel1.CaptionCloseButtonControlLeft = 2;
            this.captionPanel1.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.captionPanel1.CaptionCloseButtonTitle = "×";
            this.captionPanel1.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.captionPanel1.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.captionPanel1.CaptionHeight = 35;
            this.captionPanel1.CaptionLeft = 1;
            this.captionPanel1.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.captionPanel1.CaptionTitle = "";
            this.captionPanel1.CaptionTitleLeft = 8;
            this.captionPanel1.CaptionTitleTop = 4;
            this.captionPanel1.CaptionTop = 1;
            this.captionPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.captionPanel1.IsBorderLine = true;
            this.captionPanel1.IsCaptionSingleColor = false;
            this.captionPanel1.IsOnlyCaption = false;
            this.captionPanel1.IsPanelImage = false;
            this.captionPanel1.IsUserButtonClose = false;
            this.captionPanel1.IsUserCaptionBottomLine = true;
            this.captionPanel1.IsUserSystemCloseButtonLeft = true;
            this.captionPanel1.Location = new System.Drawing.Point(0, 0);
            this.captionPanel1.Name = "captionPanel1";
            this.captionPanel1.PanelImage = null;
            this.captionPanel1.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.captionPanel1.Size = new System.Drawing.Size(787, 37);
            this.captionPanel1.TabIndex = 0;
            // 
            // btnRowsCount
            // 
            this.btnRowsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRowsCount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRowsCount.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnRowsCount.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnRowsCount.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(121)))), ((int)(((byte)(191)))));
            this.btnRowsCount.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(97)))), ((int)(((byte)(168)))));
            this.btnRowsCount.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnRowsCount.CaptionBottomLineWidth = 1;
            this.btnRowsCount.CaptionCloseButtonControlLeft = 2;
            this.btnRowsCount.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRowsCount.CaptionCloseButtonTitle = "×";
            this.btnRowsCount.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRowsCount.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.btnRowsCount.CaptionHeight = 20;
            this.btnRowsCount.CaptionLeft = 1;
            this.btnRowsCount.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnRowsCount.CaptionTitle = "";
            this.btnRowsCount.CaptionTitleLeft = 1;
            this.btnRowsCount.CaptionTitleTop = 4;
            this.btnRowsCount.CaptionTop = 1;
            this.btnRowsCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnRowsCount.IsBorderLine = true;
            this.btnRowsCount.IsCaptionSingleColor = true;
            this.btnRowsCount.IsOnlyCaption = true;
            this.btnRowsCount.IsPanelImage = true;
            this.btnRowsCount.IsUserButtonClose = false;
            this.btnRowsCount.IsUserCaptionBottomLine = false;
            this.btnRowsCount.IsUserSystemCloseButtonLeft = true;
            this.btnRowsCount.Location = new System.Drawing.Point(140, 6);
            this.btnRowsCount.Name = "btnRowsCount";
            this.btnRowsCount.PanelImage = null;
            this.btnRowsCount.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.btnRowsCount.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.btnRowsCount.Size = new System.Drawing.Size(108, 22);
            this.btnRowsCount.TabIndex = 7;
            this.btnRowsCount.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // captionPanel2
            // 
            this.captionPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.captionPanel2.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.captionPanel2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.captionPanel2.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.captionPanel2.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.captionPanel2.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.captionPanel2.CaptionBottomLineWidth = 1;
            this.captionPanel2.CaptionCloseButtonControlLeft = 2;
            this.captionPanel2.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.captionPanel2.CaptionCloseButtonTitle = "×";
            this.captionPanel2.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.captionPanel2.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.captionPanel2.CaptionHeight = 20;
            this.captionPanel2.CaptionLeft = 1;
            this.captionPanel2.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.captionPanel2.CaptionTitle = "查询条件";
            this.captionPanel2.CaptionTitleLeft = 8;
            this.captionPanel2.CaptionTitleTop = 4;
            this.captionPanel2.CaptionTop = 1;
            this.captionPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.captionPanel2.IsBorderLine = true;
            this.captionPanel2.IsCaptionSingleColor = false;
            this.captionPanel2.IsOnlyCaption = false;
            this.captionPanel2.IsPanelImage = false;
            this.captionPanel2.IsUserButtonClose = false;
            this.captionPanel2.IsUserCaptionBottomLine = true;
            this.captionPanel2.IsUserSystemCloseButtonLeft = true;
            this.captionPanel2.Location = new System.Drawing.Point(0, 0);
            this.captionPanel2.Name = "captionPanel2";
            this.captionPanel2.PanelImage = null;
            this.captionPanel2.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.captionPanel2.Size = new System.Drawing.Size(241, 312);
            this.captionPanel2.TabIndex = 8;
            // 
            // gbStations
            // 
            this.gbStations.Controls.Add(this.txtCSAddress);
            this.gbStations.Controls.Add(this.cbHolidayType);
            this.gbStations.Controls.Add(this.label10);
            this.gbStations.Controls.Add(this.cbEndTime);
            this.gbStations.Controls.Add(this.label4);
            this.gbStations.Controls.Add(this.cbBeginTime);
            this.gbStations.Controls.Add(this.label3);
            this.gbStations.Controls.Add(this.cbDept);
            this.gbStations.Controls.Add(this.txtEmpName);
            this.gbStations.Controls.Add(this.label2);
            this.gbStations.Controls.Add(this.label1);
            this.gbStations.Controls.Add(this.lable1);
            this.gbStations.Location = new System.Drawing.Point(3, 26);
            this.gbStations.Name = "gbStations";
            this.gbStations.Size = new System.Drawing.Size(228, 225);
            this.gbStations.TabIndex = 9;
            this.gbStations.TabStop = false;
            this.gbStations.Text = "综合查询条件";
            // 
            // txtCSAddress
            // 
            this.txtCSAddress.Location = new System.Drawing.Point(72, 189);
            this.txtCSAddress.MaxLength = 5;
            this.txtCSAddress.Name = "txtCSAddress";
            this.txtCSAddress.Size = new System.Drawing.Size(150, 21);
            this.txtCSAddress.TabIndex = 16;
            // 
            // cbHolidayType
            // 
            this.cbHolidayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHolidayType.FormattingEnabled = true;
            this.cbHolidayType.Location = new System.Drawing.Point(72, 124);
            this.cbHolidayType.Name = "cbHolidayType";
            this.cbHolidayType.Size = new System.Drawing.Size(150, 20);
            this.cbHolidayType.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "请假类别：";
            // 
            // cbEndTime
            // 
            this.cbEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.cbEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cbEndTime.Location = new System.Drawing.Point(72, 58);
            this.cbEndTime.Name = "cbEndTime";
            this.cbEndTime.Size = new System.Drawing.Size(150, 21);
            this.cbEndTime.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "结束日期：";
            // 
            // cbBeginTime
            // 
            this.cbBeginTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.cbBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cbBeginTime.Location = new System.Drawing.Point(72, 27);
            this.cbBeginTime.Name = "cbBeginTime";
            this.cbBeginTime.Size = new System.Drawing.Size(150, 21);
            this.cbBeginTime.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "发码器编号：";
            // 
            // cbDept
            // 
            this.cbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDept.FormattingEnabled = true;
            this.cbDept.Location = new System.Drawing.Point(72, 90);
            this.cbDept.Name = "cbDept";
            this.cbDept.Size = new System.Drawing.Size(150, 20);
            this.cbDept.TabIndex = 10;
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(72, 156);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(150, 21);
            this.txtEmpName.TabIndex = 14;
            this.txtEmpName.TextType = Shine.TextType.WithOutChar;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "员工姓名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "所属部门：";
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(6, 31);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(65, 12);
            this.lable1.TabIndex = 10;
            this.lable1.Text = "开始日期：";
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
            this.btnQuery.CaptionTitle = "查 询";
            this.btnQuery.CaptionTitleLeft = 15;
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
            this.btnQuery.Location = new System.Drawing.Point(3, 267);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.PanelImage = null;
            this.btnQuery.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnQuery.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnQuery.Size = new System.Drawing.Size(73, 22);
            this.btnQuery.TabIndex = 10;
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
            this.btnReset.CaptionTitle = "重 置";
            this.btnReset.CaptionTitleLeft = 15;
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
            this.btnReset.Location = new System.Drawing.Point(152, 267);
            this.btnReset.Name = "btnReset";
            this.btnReset.PanelImage = null;
            this.btnReset.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnReset.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnReset.Size = new System.Drawing.Size(73, 22);
            this.btnReset.TabIndex = 11;
            this.btnReset.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtJump
            // 
            this.txtJump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJump.Location = new System.Drawing.Point(637, 6);
            this.txtJump.Name = "txtJump";
            this.txtJump.Size = new System.Drawing.Size(60, 21);
            this.txtJump.TabIndex = 19;
            // 
            // btnJump
            // 
            this.btnJump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJump.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnJump.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnJump.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnJump.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnJump.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnJump.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnJump.CaptionBottomLineWidth = 1;
            this.btnJump.CaptionCloseButtonControlLeft = 2;
            this.btnJump.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnJump.CaptionCloseButtonTitle = "×";
            this.btnJump.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJump.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnJump.CaptionHeight = 20;
            this.btnJump.CaptionLeft = 1;
            this.btnJump.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnJump.CaptionTitle = "跳 转";
            this.btnJump.CaptionTitleLeft = 20;
            this.btnJump.CaptionTitleTop = 4;
            this.btnJump.CaptionTop = 1;
            this.btnJump.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJump.IsBorderLine = true;
            this.btnJump.IsCaptionSingleColor = false;
            this.btnJump.IsOnlyCaption = true;
            this.btnJump.IsPanelImage = true;
            this.btnJump.IsUserButtonClose = false;
            this.btnJump.IsUserCaptionBottomLine = false;
            this.btnJump.IsUserSystemCloseButtonLeft = true;
            this.btnJump.Location = new System.Drawing.Point(703, 5);
            this.btnJump.Name = "btnJump";
            this.btnJump.PanelImage = null;
            this.btnJump.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnJump.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnJump.Size = new System.Drawing.Size(81, 22);
            this.btnJump.TabIndex = 20;
            this.btnJump.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnJump.Click += new System.EventHandler(this.btnJump_Click);
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
            this.btnAdd.CaptionTitle = "添 加";
            this.btnAdd.CaptionTitleLeft = 22;
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
            this.btnAdd.Location = new System.Drawing.Point(21, 369);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PanelImage = null;
            this.btnAdd.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnAdd.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnAdd.Size = new System.Drawing.Size(84, 22);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cpModify
            // 
            this.cpModify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpModify.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpModify.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpModify.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpModify.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.cpModify.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpModify.CaptionBottomLineWidth = 1;
            this.cpModify.CaptionCloseButtonControlLeft = 2;
            this.cpModify.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpModify.CaptionCloseButtonTitle = "×";
            this.cpModify.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpModify.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cpModify.CaptionHeight = 20;
            this.cpModify.CaptionLeft = 1;
            this.cpModify.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpModify.CaptionTitle = "修改请假信息";
            this.cpModify.CaptionTitleLeft = 8;
            this.cpModify.CaptionTitleTop = 4;
            this.cpModify.CaptionTop = 1;
            this.cpModify.IsBorderLine = true;
            this.cpModify.IsCaptionSingleColor = false;
            this.cpModify.IsOnlyCaption = false;
            this.cpModify.IsPanelImage = false;
            this.cpModify.IsUserButtonClose = false;
            this.cpModify.IsUserCaptionBottomLine = true;
            this.cpModify.IsUserSystemCloseButtonLeft = true;
            this.cpModify.Location = new System.Drawing.Point(303, 84);
            this.cpModify.Name = "cpModify";
            this.cpModify.PanelImage = null;
            this.cpModify.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.cpModify.Size = new System.Drawing.Size(476, 307);
            this.cpModify.TabIndex = 24;
            // 
            // gbUpdate
            // 
            this.gbUpdate.Controls.Add(this.label12);
            this.gbUpdate.Controls.Add(this.label11);
            this.gbUpdate.Controls.Add(this.dtHoliday);
            this.gbUpdate.Controls.Add(this.label9);
            this.gbUpdate.Controls.Add(this.cbHolidayTypeAdd);
            this.gbUpdate.Controls.Add(this.label8);
            this.gbUpdate.Controls.Add(this.txtEmpNameAdd);
            this.gbUpdate.Controls.Add(this.label7);
            this.gbUpdate.Controls.Add(this.txtBlockAdd);
            this.gbUpdate.Controls.Add(this.label6);
            this.gbUpdate.Controls.Add(this.cbDeptAdd);
            this.gbUpdate.Controls.Add(this.label5);
            this.gbUpdate.Location = new System.Drawing.Point(351, 118);
            this.gbUpdate.Name = "gbUpdate";
            this.gbUpdate.Size = new System.Drawing.Size(389, 197);
            this.gbUpdate.TabIndex = 25;
            this.gbUpdate.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(276, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 11;
            this.label12.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(274, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "*";
            // 
            // dtHoliday
            // 
            this.dtHoliday.CustomFormat = "yyyy-MM-dd";
            this.dtHoliday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHoliday.Location = new System.Drawing.Point(136, 147);
            this.dtHoliday.Name = "dtHoliday";
            this.dtHoliday.Size = new System.Drawing.Size(132, 21);
            this.dtHoliday.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(65, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "请假日期：";
            // 
            // cbHolidayTypeAdd
            // 
            this.cbHolidayTypeAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHolidayTypeAdd.FormattingEnabled = true;
            this.cbHolidayTypeAdd.Location = new System.Drawing.Point(134, 116);
            this.cbHolidayTypeAdd.Name = "cbHolidayTypeAdd";
            this.cbHolidayTypeAdd.Size = new System.Drawing.Size(133, 20);
            this.cbHolidayTypeAdd.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(64, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "请假类别：";
            // 
            // txtEmpNameAdd
            // 
            this.txtEmpNameAdd.Location = new System.Drawing.Point(133, 82);
            this.txtEmpNameAdd.Name = "txtEmpNameAdd";
            this.txtEmpNameAdd.ReadOnly = true;
            this.txtEmpNameAdd.Size = new System.Drawing.Size(135, 21);
            this.txtEmpNameAdd.TabIndex = 5;
            this.txtEmpNameAdd.TextType = Shine.TextType.WithOutChar;
            this.txtEmpNameAdd.Enter += new System.EventHandler(this.txtEmpNameAdd_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "员工姓名：";
            // 
            // txtBlockAdd
            // 
            this.txtBlockAdd.Location = new System.Drawing.Point(132, 49);
            this.txtBlockAdd.MaxLength = 5;
            this.txtBlockAdd.Name = "txtBlockAdd";
            this.txtBlockAdd.Size = new System.Drawing.Size(136, 21);
            this.txtBlockAdd.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "发码器编号：";
            // 
            // cbDeptAdd
            // 
            this.cbDeptAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeptAdd.FormattingEnabled = true;
            this.cbDeptAdd.Location = new System.Drawing.Point(132, 22);
            this.cbDeptAdd.Name = "cbDeptAdd";
            this.cbDeptAdd.Size = new System.Drawing.Size(136, 20);
            this.cbDeptAdd.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "所属部门：";
            // 
            // btnModify
            // 
            this.btnModify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModify.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnModify.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnModify.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnModify.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnModify.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnModify.CaptionBottomLineWidth = 1;
            this.btnModify.CaptionCloseButtonControlLeft = 2;
            this.btnModify.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnModify.CaptionCloseButtonTitle = "×";
            this.btnModify.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnModify.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnModify.CaptionHeight = 20;
            this.btnModify.CaptionLeft = 1;
            this.btnModify.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnModify.CaptionTitle = "修 改";
            this.btnModify.CaptionTitleLeft = 20;
            this.btnModify.CaptionTitleTop = 4;
            this.btnModify.CaptionTop = 1;
            this.btnModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModify.IsBorderLine = true;
            this.btnModify.IsCaptionSingleColor = false;
            this.btnModify.IsOnlyCaption = true;
            this.btnModify.IsPanelImage = true;
            this.btnModify.IsUserButtonClose = false;
            this.btnModify.IsUserCaptionBottomLine = false;
            this.btnModify.IsUserSystemCloseButtonLeft = true;
            this.btnModify.Location = new System.Drawing.Point(451, 348);
            this.btnModify.Name = "btnModify";
            this.btnModify.PanelImage = null;
            this.btnModify.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnModify.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnModify.Size = new System.Drawing.Size(86, 22);
            this.btnModify.TabIndex = 26;
            this.btnModify.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReturn.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnReturn.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnReturn.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnReturn.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnReturn.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnReturn.CaptionBottomLineWidth = 1;
            this.btnReturn.CaptionCloseButtonControlLeft = 2;
            this.btnReturn.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReturn.CaptionCloseButtonTitle = "×";
            this.btnReturn.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturn.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReturn.CaptionHeight = 20;
            this.btnReturn.CaptionLeft = 1;
            this.btnReturn.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnReturn.CaptionTitle = "返 回";
            this.btnReturn.CaptionTitleLeft = 20;
            this.btnReturn.CaptionTitleTop = 4;
            this.btnReturn.CaptionTop = 1;
            this.btnReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturn.IsBorderLine = true;
            this.btnReturn.IsCaptionSingleColor = false;
            this.btnReturn.IsOnlyCaption = true;
            this.btnReturn.IsPanelImage = true;
            this.btnReturn.IsUserButtonClose = false;
            this.btnReturn.IsUserCaptionBottomLine = false;
            this.btnReturn.IsUserSystemCloseButtonLeft = true;
            this.btnReturn.Location = new System.Drawing.Point(557, 347);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.PanelImage = null;
            this.btnReturn.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnReturn.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnReturn.Size = new System.Drawing.Size(81, 22);
            this.btnReturn.TabIndex = 27;
            this.btnReturn.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.Location = new System.Drawing.Point(76, 347);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(0, 12);
            this.lblErr.TabIndex = 28;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(785, 205);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 12);
            this.lblID.TabIndex = 29;
            this.lblID.Visible = false;
            // 
            // lblPageIndex
            // 
            this.lblPageIndex.AutoSize = true;
            this.lblPageIndex.Location = new System.Drawing.Point(275, 10);
            this.lblPageIndex.Name = "lblPageIndex";
            this.lblPageIndex.Size = new System.Drawing.Size(11, 12);
            this.lblPageIndex.TabIndex = 30;
            this.lblPageIndex.Text = "1";
            // 
            // dgrd
            // 
            this.dgrd.AllowUserToAddRows = false;
            this.dgrd.AllowUserToDeleteRows = false;
            this.dgrd.AllowUserToOrderColumns = true;
            this.dgrd.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgrd.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrd.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.dgrd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(251)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgrd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cellEdit,
            this.cellDelete});
            this.dgrd.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.BlueStyle;
            this.dgrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrd.EnableHeadersVisualStyles = false;
            this.dgrd.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(191)))), ((int)(((byte)(219)))));
            this.dgrd.Location = new System.Drawing.Point(0, 37);
            this.dgrd.Name = "dgrd";
            this.dgrd.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrd.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrd.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dgrd.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrd.RowTemplate.Height = 23;
            this.dgrd.Size = new System.Drawing.Size(787, 652);
            this.dgrd.TabIndex = 31;
            this.dgrd.VerticalScrollBarMax = 1;
            this.dgrd.VerticalScrollBarValue = 0;
            this.dgrd.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrd_CellClick);
            // 
            // cellEdit
            // 
            this.cellEdit.HeaderText = "修改";
            this.cellEdit.Name = "cellEdit";
            this.cellEdit.ReadOnly = true;
            this.cellEdit.Text = "修改";
            this.cellEdit.UseColumnTextForLinkValue = true;
            // 
            // cellDelete
            // 
            this.cellDelete.HeaderText = "删除";
            this.cellDelete.Name = "cellDelete";
            this.cellDelete.ReadOnly = true;
            this.cellDelete.Text = "删除";
            this.cellDelete.UseColumnTextForLinkValue = true;
            // 
            // lblPageCount
            // 
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.Location = new System.Drawing.Point(324, 10);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(0, 12);
            this.lblPageCount.TabIndex = 32;
            this.lblPageCount.Visible = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.bcpRef);
            this.pnlLeft.Controls.Add(this.btnAdd);
            this.pnlLeft.Controls.Add(this.captionPanel3);
            this.pnlLeft.Controls.Add(this.btnReset);
            this.pnlLeft.Controls.Add(this.btnQuery);
            this.pnlLeft.Controls.Add(this.gbStations);
            this.pnlLeft.Controls.Add(this.captionPanel2);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(241, 689);
            this.pnlLeft.TabIndex = 33;
            // 
            // captionPanel3
            // 
            this.captionPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.captionPanel3.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.captionPanel3.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.captionPanel3.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.captionPanel3.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.captionPanel3.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.captionPanel3.CaptionBottomLineWidth = 1;
            this.captionPanel3.CaptionCloseButtonControlLeft = 2;
            this.captionPanel3.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.captionPanel3.CaptionCloseButtonTitle = "×";
            this.captionPanel3.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.captionPanel3.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.captionPanel3.CaptionHeight = 20;
            this.captionPanel3.CaptionLeft = 1;
            this.captionPanel3.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.captionPanel3.CaptionTitle = "添加请假信息";
            this.captionPanel3.CaptionTitleLeft = 8;
            this.captionPanel3.CaptionTitleTop = 4;
            this.captionPanel3.CaptionTop = 1;
            this.captionPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.captionPanel3.IsBorderLine = true;
            this.captionPanel3.IsCaptionSingleColor = false;
            this.captionPanel3.IsOnlyCaption = false;
            this.captionPanel3.IsPanelImage = false;
            this.captionPanel3.IsUserButtonClose = false;
            this.captionPanel3.IsUserCaptionBottomLine = true;
            this.captionPanel3.IsUserSystemCloseButtonLeft = true;
            this.captionPanel3.Location = new System.Drawing.Point(0, 312);
            this.captionPanel3.Name = "captionPanel3";
            this.captionPanel3.PanelImage = null;
            this.captionPanel3.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.captionPanel3.Size = new System.Drawing.Size(241, 377);
            this.captionPanel3.TabIndex = 22;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblErr);
            this.pnlMain.Controls.Add(this.lblPageIndex);
            this.pnlMain.Controls.Add(this.dgrd);
            this.pnlMain.Controls.Add(this.btnRowsCount);
            this.pnlMain.Controls.Add(this.btnpreview);
            this.pnlMain.Controls.Add(this.btnNext);
            this.pnlMain.Controls.Add(this.btnCurrentPageIndex);
            this.pnlMain.Controls.Add(this.lblPageCount);
            this.pnlMain.Controls.Add(this.cbRowsSet);
            this.pnlMain.Controls.Add(this.txtJump);
            this.pnlMain.Controls.Add(this.btnJump);
            this.pnlMain.Controls.Add(this.captionPanel1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(241, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(787, 689);
            this.pnlMain.TabIndex = 34;
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bcpRef
            // 
            this.bcpRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.bcpRef.CaptionTitle = "刷 新";
            this.bcpRef.CaptionTitleLeft = 23;
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
            this.bcpRef.Location = new System.Drawing.Point(124, 368);
            this.bcpRef.Name = "bcpRef";
            this.bcpRef.PanelImage = null;
            this.bcpRef.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bcpRef.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpRef.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpRef.Size = new System.Drawing.Size(79, 22);
            this.bcpRef.TabIndex = 52;
            this.bcpRef.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpRef.Click += new System.EventHandler(this.bcpRef_Click);
            // 
            // HolidayMange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1028, 689);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.gbUpdate);
            this.Controls.Add(this.cpModify);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.lblID);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HolidayMange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "请假管理";
            this.Text = "请假管理";
            this.Load += new System.EventHandler(this.HolidayMange_Load);
            this.gbStations.ResumeLayout(false);
            this.gbStations.PerformLayout();
            this.gbUpdate.ResumeLayout(false);
            this.gbUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KJ128WindowsLibrary.CaptionPanel captionPanel1;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnpreview;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnNext;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnCurrentPageIndex;
        private System.Windows.Forms.ComboBox cbRowsSet;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnRowsCount;
        private KJ128WindowsLibrary.CaptionPanel captionPanel2;
        private System.Windows.Forms.GroupBox gbStations;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker cbBeginTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbDept;
        private System.Windows.Forms.DateTimePicker cbEndTime;
        private System.Windows.Forms.Label label4;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnQuery;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnReset;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnJump;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnAdd;
        private KJ128WindowsLibrary.CaptionPanel cpModify;
        private System.Windows.Forms.GroupBox gbUpdate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbDeptAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtHoliday;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbHolidayTypeAdd;
        private System.Windows.Forms.ComboBox cbHolidayType;
        private System.Windows.Forms.Label label10;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnModify;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnReturn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblPageIndex;
        private DataGridViewKJ128 dgrd;
        private System.Windows.Forms.DataGridViewLinkColumn cellEdit;
        private System.Windows.Forms.DataGridViewLinkColumn cellDelete;
        private System.Windows.Forms.Label lblPageCount;
        private KJ128N.Command.TxtNumber txtCSAddress;
        private KJ128N.Command.TxtNumber txtJump;
        private KJ128N.Command.TxtNumber txtBlockAdd;
        private System.Windows.Forms.Panel pnlLeft;
        private KJ128WindowsLibrary.CaptionPanel captionPanel3;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Timer timer1;
        private Shine.ShineTextBox txtEmpName;
        private Shine.ShineTextBox txtEmpNameAdd;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpRef;
    }
}