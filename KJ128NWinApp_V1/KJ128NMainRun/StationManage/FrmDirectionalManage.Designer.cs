namespace KJ128NMainRun.StationManage
{
    partial class FrmDirectionalManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDirectionalManage));
            this.txtCheckPage = new KJ128N.Command.TxtNumber();
            this.txtWhere = new Shine.ShineTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtD = new Shine.ShineTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.vsPanel = new KJ128WindowsLibrary.VSPanel();
            this.txt = new Shine.ShineTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonCaptionPanel1 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.txtUpdateDInfo = new Shine.ShineTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblUpdateResult = new System.Windows.Forms.Label();
            this.cp = new KJ128WindowsLibrary.CaptionPanel();
            this.bcpUpdate = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.label21 = new System.Windows.Forms.Label();
            this.txtUpdateD = new Shine.ShineTextBox();
            this.vspConfig = new KJ128WindowsLibrary.VSPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblToHead = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rbtnToA = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.rbtnToB = new System.Windows.Forms.RadioButton();
            this.lblToStation = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFromHead = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rbtnFromA = new System.Windows.Forms.RadioButton();
            this.lblFromStation = new System.Windows.Forms.Label();
            this.rbtnFromB = new System.Windows.Forms.RadioButton();
            this.cpConfigHead = new KJ128WindowsLibrary.CaptionPanel();
            this.bcpSave = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.trToStation = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.trFromStation = new System.Windows.Forms.TreeView();
            this.txtDirectional = new Shine.ShineTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bcpConfig = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.bcpSelect = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.bcpPageSum = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.lblSumPage = new KJ128WindowsLibrary.CaptionPanel();
            this.cpUp = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.txtPage = new KJ128WindowsLibrary.CaptionPanel();
            this.cpCheckPage = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cpDown = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.dgvData = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.buttonCaptionPanel8 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cmb_Size = new System.Windows.Forms.ComboBox();
            this.buttonCaptionPanel12 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.sxpPanelGroup1 = new Wilson.Controls.XPPanel.Images.SXPPanelGroup();
            this.sxpPanel1 = new Wilson.Controls.XPPanel.SXPPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonCaptionPanel2 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.vsPanel.SuspendLayout();
            this.vspConfig.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).BeginInit();
            this.sxpPanelGroup1.SuspendLayout();
            this.sxpPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCheckPage
            // 
            this.txtCheckPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCheckPage.Location = new System.Drawing.Point(622, 6);
            this.txtCheckPage.MaxLength = 4;
            this.txtCheckPage.Name = "txtCheckPage";
            this.txtCheckPage.Size = new System.Drawing.Size(27, 21);
            this.txtCheckPage.TabIndex = 42;
            this.txtCheckPage.Text = "1";
            this.txtCheckPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtWhere
            // 
            this.txtWhere.Location = new System.Drawing.Point(84, 92);
            this.txtWhere.MaxLength = 50;
            this.txtWhere.Name = "txtWhere";
            this.txtWhere.Size = new System.Drawing.Size(108, 20);
            this.txtWhere.TabIndex = 44;
            this.txtWhere.TextType = Shine.TextType.WithOutChar;
            this.txtWhere.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "方向性描述:";
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(84, 54);
            this.txtD.MaxLength = 20;
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(108, 20);
            this.txtD.TabIndex = 49;
            this.txtD.TextType = Shine.TextType.WithOutChar;
            this.txtD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "标    识:";
            // 
            // vsPanel
            // 
            this.vsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.vsPanel.BackLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.vsPanel.BetweenControlCount = 2;
            this.vsPanel.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.vsPanel.BottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.vsPanel.Controls.Add(this.txt);
            this.vsPanel.Controls.Add(this.label13);
            this.vsPanel.Controls.Add(this.buttonCaptionPanel1);
            this.vsPanel.Controls.Add(this.txtUpdateDInfo);
            this.vsPanel.Controls.Add(this.label9);
            this.vsPanel.Controls.Add(this.lblUpdateResult);
            this.vsPanel.Controls.Add(this.cp);
            this.vsPanel.Controls.Add(this.bcpUpdate);
            this.vsPanel.Controls.Add(this.label21);
            this.vsPanel.Controls.Add(this.txtUpdateD);
            this.vsPanel.HorizontalInterval = 8;
            this.vsPanel.IsBorderLine = true;
            this.vsPanel.IsBottomLineColor = false;
            this.vsPanel.IsCaptionSingleColor = true;
            this.vsPanel.IsDragModel = false;
            this.vsPanel.IsmiddleInterval = false;
            this.vsPanel.LayoutType = KJ128WindowsLibrary.VSPanelLayoutType.FreeLayoutType;
            this.vsPanel.LeftInterval = 0;
            this.vsPanel.LinearGradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.vsPanel.LinearGradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.vsPanel.Location = new System.Drawing.Point(259, 93);
            this.vsPanel.MiddleInterval = 80;
            this.vsPanel.Name = "vsPanel";
            this.vsPanel.RightInterval = 0;
            this.vsPanel.SetBackGroundStyle = KJ128WindowsLibrary.VsPaneBackGroundStyle.windowsStyle;
            this.vsPanel.Size = new System.Drawing.Size(385, 163);
            this.vsPanel.TabIndex = 47;
            this.vsPanel.TopInterval = 0;
            this.vsPanel.VerticalInterval = 8;
            // 
            // txt
            // 
            this.txt.Enabled = false;
            this.txt.Location = new System.Drawing.Point(90, 37);
            this.txt.Multiline = true;
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(264, 23);
            this.txt.TabIndex = 32;
            this.txt.TextType = Shine.TextType.WithOutChar;
            this.txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 31;
            this.label13.Text = "标     识:";
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
            this.buttonCaptionPanel1.CaptionTitle = "取  消";
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
            this.buttonCaptionPanel1.Location = new System.Drawing.Point(288, 127);
            this.buttonCaptionPanel1.Name = "buttonCaptionPanel1";
            this.buttonCaptionPanel1.PanelImage = null;
            this.buttonCaptionPanel1.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.buttonCaptionPanel1.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.buttonCaptionPanel1.Size = new System.Drawing.Size(66, 22);
            this.buttonCaptionPanel1.TabIndex = 30;
            this.buttonCaptionPanel1.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.buttonCaptionPanel1.Click += new System.EventHandler(this.buttonCaptionPanel1_Click);
            // 
            // txtUpdateDInfo
            // 
            this.txtUpdateDInfo.Enabled = false;
            this.txtUpdateDInfo.Location = new System.Drawing.Point(90, 68);
            this.txtUpdateDInfo.Multiline = true;
            this.txtUpdateDInfo.Name = "txtUpdateDInfo";
            this.txtUpdateDInfo.Size = new System.Drawing.Size(264, 23);
            this.txtUpdateDInfo.TabIndex = 29;
            this.txtUpdateDInfo.TextType = Shine.TextType.WithOutChar;
            this.txtUpdateDInfo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "位     置:";
            // 
            // lblUpdateResult
            // 
            this.lblUpdateResult.AutoSize = true;
            this.lblUpdateResult.Location = new System.Drawing.Point(88, 127);
            this.lblUpdateResult.Name = "lblUpdateResult";
            this.lblUpdateResult.Size = new System.Drawing.Size(41, 12);
            this.lblUpdateResult.TabIndex = 26;
            this.lblUpdateResult.Text = "label8";
            // 
            // cp
            // 
            this.cp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cp.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cp.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cp.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cp.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cp.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cp.CaptionBottomLineWidth = 1;
            this.cp.CaptionCloseButtonControlLeft = 2;
            this.cp.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cp.CaptionCloseButtonTitle = "×";
            this.cp.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cp.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.cp.CaptionHeight = 20;
            this.cp.CaptionLeft = 1;
            this.cp.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cp.CaptionTitle = "方向性修改";
            this.cp.CaptionTitleLeft = 10;
            this.cp.CaptionTitleTop = 4;
            this.cp.CaptionTop = 1;
            this.cp.IsBorderLine = true;
            this.cp.IsCaptionSingleColor = true;
            this.cp.IsOnlyCaption = true;
            this.cp.IsPanelImage = false;
            this.cp.IsUserButtonClose = true;
            this.cp.IsUserCaptionBottomLine = false;
            this.cp.IsUserSystemCloseButtonLeft = true;
            this.cp.Location = new System.Drawing.Point(2, 0);
            this.cp.Name = "cp";
            this.cp.PanelImage = null;
            this.cp.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.cp.Size = new System.Drawing.Size(383, 22);
            this.cp.TabIndex = 16;
            this.cp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cpConfigHead_MouseUp);
            this.cp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cpConfigHead_MouseMove);
            this.cp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cpConfigHead_MouseDown);
            this.cp.CloseButtonClick += new System.EventHandler(this.cp_CloseButtonClick);
            // 
            // bcpUpdate
            // 
            this.bcpUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpUpdate.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpUpdate.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpUpdate.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.bcpUpdate.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.bcpUpdate.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpUpdate.CaptionBottomLineWidth = 1;
            this.bcpUpdate.CaptionCloseButtonControlLeft = 2;
            this.bcpUpdate.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpUpdate.CaptionCloseButtonTitle = "×";
            this.bcpUpdate.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpUpdate.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bcpUpdate.CaptionHeight = 20;
            this.bcpUpdate.CaptionLeft = 1;
            this.bcpUpdate.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpUpdate.CaptionTitle = "修  改";
            this.bcpUpdate.CaptionTitleLeft = 8;
            this.bcpUpdate.CaptionTitleTop = 4;
            this.bcpUpdate.CaptionTop = 1;
            this.bcpUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcpUpdate.IsBorderLine = true;
            this.bcpUpdate.IsCaptionSingleColor = false;
            this.bcpUpdate.IsOnlyCaption = true;
            this.bcpUpdate.IsPanelImage = true;
            this.bcpUpdate.IsUserButtonClose = false;
            this.bcpUpdate.IsUserCaptionBottomLine = false;
            this.bcpUpdate.IsUserSystemCloseButtonLeft = true;
            this.bcpUpdate.Location = new System.Drawing.Point(212, 127);
            this.bcpUpdate.Name = "bcpUpdate";
            this.bcpUpdate.PanelImage = null;
            this.bcpUpdate.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpUpdate.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpUpdate.Size = new System.Drawing.Size(66, 22);
            this.bcpUpdate.TabIndex = 15;
            this.bcpUpdate.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpUpdate.Click += new System.EventHandler(this.bcpUpdate_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(15, 101);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 12);
            this.label21.TabIndex = 14;
            this.label21.Text = "方向性描述:";
            // 
            // txtUpdateD
            // 
            this.txtUpdateD.Location = new System.Drawing.Point(90, 98);
            this.txtUpdateD.MaxLength = 50;
            this.txtUpdateD.Multiline = true;
            this.txtUpdateD.Name = "txtUpdateD";
            this.txtUpdateD.Size = new System.Drawing.Size(264, 23);
            this.txtUpdateD.TabIndex = 12;
            this.txtUpdateD.TextType = Shine.TextType.WithOutChar;
            this.txtUpdateD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // vspConfig
            // 
            this.vspConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.vspConfig.BackLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.vspConfig.BetweenControlCount = 2;
            this.vspConfig.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.vspConfig.BottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.vspConfig.Controls.Add(this.label12);
            this.vspConfig.Controls.Add(this.lblInfo);
            this.vspConfig.Controls.Add(this.groupBox2);
            this.vspConfig.Controls.Add(this.groupBox1);
            this.vspConfig.Controls.Add(this.cpConfigHead);
            this.vspConfig.Controls.Add(this.bcpSave);
            this.vspConfig.Controls.Add(this.trToStation);
            this.vspConfig.Controls.Add(this.label3);
            this.vspConfig.Controls.Add(this.trFromStation);
            this.vspConfig.Controls.Add(this.txtDirectional);
            this.vspConfig.Controls.Add(this.label1);
            this.vspConfig.HorizontalInterval = 8;
            this.vspConfig.IsBorderLine = true;
            this.vspConfig.IsBottomLineColor = false;
            this.vspConfig.IsCaptionSingleColor = true;
            this.vspConfig.IsDragModel = false;
            this.vspConfig.IsmiddleInterval = false;
            this.vspConfig.LayoutType = KJ128WindowsLibrary.VSPanelLayoutType.FreeLayoutType;
            this.vspConfig.LeftInterval = 0;
            this.vspConfig.LinearGradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.vspConfig.LinearGradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.vspConfig.Location = new System.Drawing.Point(338, 51);
            this.vspConfig.MiddleInterval = 80;
            this.vspConfig.Name = "vspConfig";
            this.vspConfig.RightInterval = 0;
            this.vspConfig.SetBackGroundStyle = KJ128WindowsLibrary.VsPaneBackGroundStyle.windowsStyle;
            this.vspConfig.Size = new System.Drawing.Size(533, 459);
            this.vspConfig.TabIndex = 15;
            this.vspConfig.TopInterval = 0;
            this.vspConfig.VerticalInterval = 8;
            this.vspConfig.Paint += new System.Windows.Forms.PaintEventHandler(this.vspConfig_Paint);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(298, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 27;
            this.label12.Text = "目标传输分站";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(99, 434);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(47, 12);
            this.lblInfo.TabIndex = 26;
            this.lblInfo.Text = "lblInfo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblToHead);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.rbtnToA);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.rbtnToB);
            this.groupBox2.Controls.Add(this.lblToStation);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(288, 282);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 100);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "目标接收器";
            // 
            // lblToHead
            // 
            this.lblToHead.AutoSize = true;
            this.lblToHead.Location = new System.Drawing.Point(118, 42);
            this.lblToHead.Name = "lblToHead";
            this.lblToHead.Size = new System.Drawing.Size(41, 12);
            this.lblToHead.TabIndex = 20;
            this.lblToHead.Text = "label7";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 12);
            this.label11.TabIndex = 17;
            this.label11.Text = "传输分站安装位置:";
            // 
            // rbtnToA
            // 
            this.rbtnToA.AutoSize = true;
            this.rbtnToA.Checked = true;
            this.rbtnToA.Location = new System.Drawing.Point(112, 58);
            this.rbtnToA.Name = "rbtnToA";
            this.rbtnToA.Size = new System.Drawing.Size(65, 16);
            this.rbtnToA.TabIndex = 22;
            this.rbtnToA.TabStop = true;
            this.rbtnToA.Text = "rbtnToA";
            this.rbtnToA.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "读卡分站安装位置:";
            // 
            // rbtnToB
            // 
            this.rbtnToB.AutoSize = true;
            this.rbtnToB.Location = new System.Drawing.Point(112, 79);
            this.rbtnToB.Name = "rbtnToB";
            this.rbtnToB.Size = new System.Drawing.Size(65, 16);
            this.rbtnToB.TabIndex = 23;
            this.rbtnToB.Text = "rbtnToB";
            this.rbtnToB.UseVisualStyleBackColor = true;
            // 
            // lblToStation
            // 
            this.lblToStation.AutoSize = true;
            this.lblToStation.Location = new System.Drawing.Point(118, 23);
            this.lblToStation.Name = "lblToStation";
            this.lblToStation.Size = new System.Drawing.Size(41, 12);
            this.lblToStation.TabIndex = 19;
            this.lblToStation.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "天线:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFromHead);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.rbtnFromA);
            this.groupBox1.Controls.Add(this.lblFromStation);
            this.groupBox1.Controls.Add(this.rbtnFromB);
            this.groupBox1.Location = new System.Drawing.Point(24, 284);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 100);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "起始接收器";
            // 
            // lblFromHead
            // 
            this.lblFromHead.AutoSize = true;
            this.lblFromHead.Location = new System.Drawing.Point(115, 43);
            this.lblFromHead.Name = "lblFromHead";
            this.lblFromHead.Size = new System.Drawing.Size(41, 12);
            this.lblFromHead.TabIndex = 20;
            this.lblFromHead.Text = "label7";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "传输分站安装位置:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "天线:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "读卡分站安装位置:";
            // 
            // rbtnFromA
            // 
            this.rbtnFromA.AutoSize = true;
            this.rbtnFromA.Checked = true;
            this.rbtnFromA.Location = new System.Drawing.Point(107, 61);
            this.rbtnFromA.Name = "rbtnFromA";
            this.rbtnFromA.Size = new System.Drawing.Size(77, 16);
            this.rbtnFromA.TabIndex = 7;
            this.rbtnFromA.TabStop = true;
            this.rbtnFromA.Text = "rbtnFromA";
            this.rbtnFromA.UseVisualStyleBackColor = true;
            // 
            // lblFromStation
            // 
            this.lblFromStation.AutoSize = true;
            this.lblFromStation.Location = new System.Drawing.Point(115, 21);
            this.lblFromStation.Name = "lblFromStation";
            this.lblFromStation.Size = new System.Drawing.Size(41, 12);
            this.lblFromStation.TabIndex = 19;
            this.lblFromStation.Text = "label6";
            // 
            // rbtnFromB
            // 
            this.rbtnFromB.AutoSize = true;
            this.rbtnFromB.Location = new System.Drawing.Point(107, 82);
            this.rbtnFromB.Name = "rbtnFromB";
            this.rbtnFromB.Size = new System.Drawing.Size(77, 16);
            this.rbtnFromB.TabIndex = 8;
            this.rbtnFromB.Text = "rbtnFromB";
            this.rbtnFromB.UseVisualStyleBackColor = true;
            // 
            // cpConfigHead
            // 
            this.cpConfigHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpConfigHead.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpConfigHead.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpConfigHead.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpConfigHead.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpConfigHead.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpConfigHead.CaptionBottomLineWidth = 1;
            this.cpConfigHead.CaptionCloseButtonControlLeft = 2;
            this.cpConfigHead.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpConfigHead.CaptionCloseButtonTitle = "×";
            this.cpConfigHead.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpConfigHead.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.cpConfigHead.CaptionHeight = 20;
            this.cpConfigHead.CaptionLeft = 1;
            this.cpConfigHead.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpConfigHead.CaptionTitle = "方向性配置";
            this.cpConfigHead.CaptionTitleLeft = 10;
            this.cpConfigHead.CaptionTitleTop = 4;
            this.cpConfigHead.CaptionTop = 1;
            this.cpConfigHead.IsBorderLine = true;
            this.cpConfigHead.IsCaptionSingleColor = true;
            this.cpConfigHead.IsOnlyCaption = true;
            this.cpConfigHead.IsPanelImage = false;
            this.cpConfigHead.IsUserButtonClose = true;
            this.cpConfigHead.IsUserCaptionBottomLine = false;
            this.cpConfigHead.IsUserSystemCloseButtonLeft = true;
            this.cpConfigHead.Location = new System.Drawing.Point(2, 0);
            this.cpConfigHead.Name = "cpConfigHead";
            this.cpConfigHead.PanelImage = null;
            this.cpConfigHead.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.cpConfigHead.Size = new System.Drawing.Size(531, 22);
            this.cpConfigHead.TabIndex = 16;
            this.cpConfigHead.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cpConfigHead_MouseUp);
            this.cpConfigHead.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cpConfigHead_MouseMove);
            this.cpConfigHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cpConfigHead_MouseDown);
            this.cpConfigHead.CloseButtonClick += new System.EventHandler(this.cpConfigHead_CloseButtonClick);
            // 
            // bcpSave
            // 
            this.bcpSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpSave.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpSave.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpSave.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.bcpSave.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.bcpSave.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpSave.CaptionBottomLineWidth = 1;
            this.bcpSave.CaptionCloseButtonControlLeft = 2;
            this.bcpSave.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpSave.CaptionCloseButtonTitle = "×";
            this.bcpSave.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpSave.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bcpSave.CaptionHeight = 20;
            this.bcpSave.CaptionLeft = 1;
            this.bcpSave.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpSave.CaptionTitle = "保  存";
            this.bcpSave.CaptionTitleLeft = 8;
            this.bcpSave.CaptionTitleTop = 4;
            this.bcpSave.CaptionTop = 1;
            this.bcpSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcpSave.IsBorderLine = true;
            this.bcpSave.IsCaptionSingleColor = false;
            this.bcpSave.IsOnlyCaption = true;
            this.bcpSave.IsPanelImage = true;
            this.bcpSave.IsUserButtonClose = false;
            this.bcpSave.IsUserCaptionBottomLine = false;
            this.bcpSave.IsUserSystemCloseButtonLeft = true;
            this.bcpSave.Location = new System.Drawing.Point(413, 400);
            this.bcpSave.Name = "bcpSave";
            this.bcpSave.PanelImage = null;
            this.bcpSave.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpSave.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpSave.Size = new System.Drawing.Size(66, 22);
            this.bcpSave.TabIndex = 15;
            this.bcpSave.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpSave.Click += new System.EventHandler(this.bcpSave_Click);
            // 
            // trToStation
            // 
            this.trToStation.Location = new System.Drawing.Point(288, 40);
            this.trToStation.Name = "trToStation";
            this.trToStation.Size = new System.Drawing.Size(234, 242);
            this.trToStation.TabIndex = 6;
            this.trToStation.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trToStation_NodeMouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 402);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "方向性描述:";
            // 
            // trFromStation
            // 
            this.trFromStation.Location = new System.Drawing.Point(24, 40);
            this.trFromStation.Name = "trFromStation";
            this.trFromStation.Size = new System.Drawing.Size(234, 242);
            this.trFromStation.TabIndex = 5;
            this.trFromStation.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trFromStation_NodeMouseClick);
            // 
            // txtDirectional
            // 
            this.txtDirectional.Location = new System.Drawing.Point(101, 399);
            this.txtDirectional.MaxLength = 50;
            this.txtDirectional.Multiline = true;
            this.txtDirectional.Name = "txtDirectional";
            this.txtDirectional.Size = new System.Drawing.Size(303, 23);
            this.txtDirectional.TabIndex = 12;
            this.txtDirectional.TextType = Shine.TextType.WithOutChar;
            this.txtDirectional.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txtDirectional.Enter += new System.EventHandler(this.txtDirectional_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "起始传输分站";
            // 
            // bcpConfig
            // 
            this.bcpConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bcpConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpConfig.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpConfig.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpConfig.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.bcpConfig.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.bcpConfig.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpConfig.CaptionBottomLineWidth = 1;
            this.bcpConfig.CaptionCloseButtonControlLeft = 2;
            this.bcpConfig.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpConfig.CaptionCloseButtonTitle = "×";
            this.bcpConfig.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpConfig.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bcpConfig.CaptionHeight = 20;
            this.bcpConfig.CaptionLeft = 1;
            this.bcpConfig.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpConfig.CaptionTitle = "配置方向性";
            this.bcpConfig.CaptionTitleLeft = 8;
            this.bcpConfig.CaptionTitleTop = 4;
            this.bcpConfig.CaptionTop = 1;
            this.bcpConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcpConfig.IsBorderLine = true;
            this.bcpConfig.IsCaptionSingleColor = false;
            this.bcpConfig.IsOnlyCaption = true;
            this.bcpConfig.IsPanelImage = true;
            this.bcpConfig.IsUserButtonClose = false;
            this.bcpConfig.IsUserCaptionBottomLine = false;
            this.bcpConfig.IsUserSystemCloseButtonLeft = true;
            this.bcpConfig.Location = new System.Drawing.Point(935, 5);
            this.bcpConfig.Name = "bcpConfig";
            this.bcpConfig.PanelImage = null;
            this.bcpConfig.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpConfig.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpConfig.Size = new System.Drawing.Size(88, 22);
            this.bcpConfig.TabIndex = 48;
            this.bcpConfig.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpConfig.Click += new System.EventHandler(this.bcpConfig_Click);
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
            this.bcpSelect.CaptionTitle = "查  询";
            this.bcpSelect.CaptionTitleLeft = 8;
            this.bcpSelect.CaptionTitleTop = 4;
            this.bcpSelect.CaptionTop = 1;
            this.bcpSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcpSelect.IsBorderLine = true;
            this.bcpSelect.IsCaptionSingleColor = false;
            this.bcpSelect.IsOnlyCaption = true;
            this.bcpSelect.IsPanelImage = false;
            this.bcpSelect.IsUserButtonClose = false;
            this.bcpSelect.IsUserCaptionBottomLine = false;
            this.bcpSelect.IsUserSystemCloseButtonLeft = true;
            this.bcpSelect.Location = new System.Drawing.Point(60, 126);
            this.bcpSelect.Name = "bcpSelect";
            this.bcpSelect.PanelImage = null;
            this.bcpSelect.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpSelect.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpSelect.Size = new System.Drawing.Size(66, 22);
            this.bcpSelect.TabIndex = 45;
            this.bcpSelect.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpSelect.Load += new System.EventHandler(this.bcpSelect_Load);
            this.bcpSelect.Click += new System.EventHandler(this.bcpSelect_Click);
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
            this.bcpPageSum.CaptionTitleLeft = 4;
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
            this.bcpPageSum.Location = new System.Drawing.Point(338, 4);
            this.bcpPageSum.Name = "bcpPageSum";
            this.bcpPageSum.PanelImage = null;
            this.bcpPageSum.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.bcpPageSum.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.bcpPageSum.Size = new System.Drawing.Size(70, 22);
            this.bcpPageSum.TabIndex = 43;
            this.bcpPageSum.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
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
            this.lblSumPage.Location = new System.Drawing.Point(582, 6);
            this.lblSumPage.Name = "lblSumPage";
            this.lblSumPage.PanelImage = null;
            this.lblSumPage.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.lblSumPage.Size = new System.Drawing.Size(37, 22);
            this.lblSumPage.TabIndex = 37;
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
            this.cpUp.CaptionTitleLeft = 8;
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
            this.cpUp.Location = new System.Drawing.Point(414, 6);
            this.cpUp.Name = "cpUp";
            this.cpUp.PanelImage = null;
            this.cpUp.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.cpUp.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.cpUp.Size = new System.Drawing.Size(64, 22);
            this.cpUp.TabIndex = 39;
            this.cpUp.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
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
            this.txtPage.Location = new System.Drawing.Point(546, 6);
            this.txtPage.Name = "txtPage";
            this.txtPage.PanelImage = null;
            this.txtPage.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.txtPage.Size = new System.Drawing.Size(36, 22);
            this.txtPage.TabIndex = 38;
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
            this.cpCheckPage.CaptionTitle = "跳  至";
            this.cpCheckPage.CaptionTitleLeft = 8;
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
            this.cpCheckPage.Location = new System.Drawing.Point(651, 6);
            this.cpCheckPage.Name = "cpCheckPage";
            this.cpCheckPage.PanelImage = null;
            this.cpCheckPage.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.cpCheckPage.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.cpCheckPage.Size = new System.Drawing.Size(66, 22);
            this.cpCheckPage.TabIndex = 41;
            this.cpCheckPage.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.cpCheckPage.Click += new System.EventHandler(this.cpCheckPage_Click);
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
            this.cpDown.CaptionTitleLeft = 8;
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
            this.cpDown.Location = new System.Drawing.Point(480, 6);
            this.cpDown.Name = "cpDown";
            this.cpDown.PanelImage = null;
            this.cpDown.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.cpDown.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.cpDown.Size = new System.Drawing.Size(64, 22);
            this.cpDown.TabIndex = 40;
            this.cpDown.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.cpDown.Click += new System.EventHandler(this.cpDown_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(251)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvData.ColumnHeadersHeight = 32;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.BlueStyle;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(191)))), ((int)(((byte)(219)))));
            this.dgvData.Location = new System.Drawing.Point(217, 32);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 20;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(811, 532);
            this.dgvData.TabIndex = 17;
            this.dgvData.VerticalScrollBarMax = 1;
            this.dgvData.VerticalScrollBarValue = 0;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            // 
            // buttonCaptionPanel8
            // 
            this.buttonCaptionPanel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCaptionPanel8.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.buttonCaptionPanel8.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel8.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.buttonCaptionPanel8.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.buttonCaptionPanel8.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.buttonCaptionPanel8.CaptionBottomLineWidth = 1;
            this.buttonCaptionPanel8.CaptionCloseButtonControlLeft = 2;
            this.buttonCaptionPanel8.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCaptionPanel8.CaptionCloseButtonTitle = "×";
            this.buttonCaptionPanel8.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCaptionPanel8.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonCaptionPanel8.CaptionHeight = 30;
            this.buttonCaptionPanel8.CaptionLeft = 1;
            this.buttonCaptionPanel8.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.buttonCaptionPanel8.CaptionTitle = "方向性信息管理：";
            this.buttonCaptionPanel8.CaptionTitleLeft = 8;
            this.buttonCaptionPanel8.CaptionTitleTop = 8;
            this.buttonCaptionPanel8.CaptionTop = 1;
            this.buttonCaptionPanel8.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonCaptionPanel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCaptionPanel8.IsBorderLine = true;
            this.buttonCaptionPanel8.IsCaptionSingleColor = false;
            this.buttonCaptionPanel8.IsOnlyCaption = true;
            this.buttonCaptionPanel8.IsPanelImage = true;
            this.buttonCaptionPanel8.IsUserButtonClose = false;
            this.buttonCaptionPanel8.IsUserCaptionBottomLine = true;
            this.buttonCaptionPanel8.IsUserSystemCloseButtonLeft = true;
            this.buttonCaptionPanel8.Location = new System.Drawing.Point(217, 0);
            this.buttonCaptionPanel8.Name = "buttonCaptionPanel8";
            this.buttonCaptionPanel8.PanelImage = null;
            this.buttonCaptionPanel8.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.buttonCaptionPanel8.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.buttonCaptionPanel8.Size = new System.Drawing.Size(811, 32);
            this.buttonCaptionPanel8.TabIndex = 16;
            this.buttonCaptionPanel8.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // cmb_Size
            // 
            this.cmb_Size.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Size.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Size.FormattingEnabled = true;
            this.cmb_Size.Items.AddRange(new object[] {
            "40",
            "50",
            "100",
            "200",
            "500"});
            this.cmb_Size.Location = new System.Drawing.Point(828, 6);
            this.cmb_Size.Name = "cmb_Size";
            this.cmb_Size.Size = new System.Drawing.Size(44, 20);
            this.cmb_Size.TabIndex = 74;
            this.cmb_Size.SelectionChangeCommitted += new System.EventHandler(this.cmb_Size_SelectionChangeCommitted);
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
            this.buttonCaptionPanel12.Location = new System.Drawing.Point(719, 6);
            this.buttonCaptionPanel12.Name = "buttonCaptionPanel12";
            this.buttonCaptionPanel12.PanelImage = null;
            this.buttonCaptionPanel12.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.buttonCaptionPanel12.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.buttonCaptionPanel12.Size = new System.Drawing.Size(106, 22);
            this.buttonCaptionPanel12.TabIndex = 73;
            this.buttonCaptionPanel12.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // sxpPanelGroup1
            // 
            this.sxpPanelGroup1.AutoScroll = true;
            this.sxpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel1);
            this.sxpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Left;
            this.sxpPanelGroup1.Location = new System.Drawing.Point(0, 0);
            this.sxpPanelGroup1.Name = "sxpPanelGroup1";
            this.sxpPanelGroup1.PanelGradient = ((Wilson.Controls.XPPanel.Colors.GradientColor)(resources.GetObject("sxpPanelGroup1.PanelGradient")));
            this.sxpPanelGroup1.Size = new System.Drawing.Size(217, 564);
            this.sxpPanelGroup1.TabIndex = 75;
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
            this.sxpPanel1.Controls.Add(this.label8);
            this.sxpPanel1.Controls.Add(this.txtD);
            this.sxpPanel1.Controls.Add(this.txtWhere);
            this.sxpPanel1.Controls.Add(this.label2);
            this.sxpPanel1.Controls.Add(this.bcpSelect);
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
            this.sxpPanel1.Size = new System.Drawing.Size(201, 173);
            this.sxpPanel1.TabIndex = 76;
            this.sxpPanel1.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel1.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel1.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel1.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonCaptionPanel2
            // 
            this.buttonCaptionPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCaptionPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCaptionPanel2.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.buttonCaptionPanel2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel2.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.buttonCaptionPanel2.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel2.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.buttonCaptionPanel2.CaptionBottomLineWidth = 1;
            this.buttonCaptionPanel2.CaptionCloseButtonControlLeft = 2;
            this.buttonCaptionPanel2.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCaptionPanel2.CaptionCloseButtonTitle = "×";
            this.buttonCaptionPanel2.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCaptionPanel2.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonCaptionPanel2.CaptionHeight = 20;
            this.buttonCaptionPanel2.CaptionLeft = 1;
            this.buttonCaptionPanel2.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.buttonCaptionPanel2.CaptionTitle = "刷新";
            this.buttonCaptionPanel2.CaptionTitleLeft = 8;
            this.buttonCaptionPanel2.CaptionTitleTop = 4;
            this.buttonCaptionPanel2.CaptionTop = 1;
            this.buttonCaptionPanel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCaptionPanel2.IsBorderLine = true;
            this.buttonCaptionPanel2.IsCaptionSingleColor = false;
            this.buttonCaptionPanel2.IsOnlyCaption = true;
            this.buttonCaptionPanel2.IsPanelImage = true;
            this.buttonCaptionPanel2.IsUserButtonClose = false;
            this.buttonCaptionPanel2.IsUserCaptionBottomLine = false;
            this.buttonCaptionPanel2.IsUserSystemCloseButtonLeft = true;
            this.buttonCaptionPanel2.Location = new System.Drawing.Point(878, 4);
            this.buttonCaptionPanel2.Name = "buttonCaptionPanel2";
            this.buttonCaptionPanel2.PanelImage = null;
            this.buttonCaptionPanel2.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.buttonCaptionPanel2.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.buttonCaptionPanel2.Size = new System.Drawing.Size(51, 22);
            this.buttonCaptionPanel2.TabIndex = 76;
            this.buttonCaptionPanel2.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.buttonCaptionPanel2.Click += new System.EventHandler(this.buttonCaptionPanel2_Click);
            // 
            // FrmDirectionalManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1028, 564);
            this.Controls.Add(this.vsPanel);
            this.Controls.Add(this.vspConfig);
            this.Controls.Add(this.buttonCaptionPanel2);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.cmb_Size);
            this.Controls.Add(this.buttonCaptionPanel12);
            this.Controls.Add(this.bcpConfig);
            this.Controls.Add(this.bcpPageSum);
            this.Controls.Add(this.lblSumPage);
            this.Controls.Add(this.cpUp);
            this.Controls.Add(this.txtPage);
            this.Controls.Add(this.cpCheckPage);
            this.Controls.Add(this.cpDown);
            this.Controls.Add(this.txtCheckPage);
            this.Controls.Add(this.buttonCaptionPanel8);
            this.Controls.Add(this.sxpPanelGroup1);
            this.Name = "FrmDirectionalManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "方向性配置";
            this.Text = "方向性配置";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDirectionalManage_Load);
            this.vsPanel.ResumeLayout(false);
            this.vsPanel.PerformLayout();
            this.vspConfig.ResumeLayout(false);
            this.vspConfig.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).EndInit();
            this.sxpPanelGroup1.ResumeLayout(false);
            this.sxpPanel1.ResumeLayout(false);
            this.sxpPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trFromStation;
        private System.Windows.Forms.TreeView trToStation;
        private System.Windows.Forms.RadioButton rbtnFromA;
        private System.Windows.Forms.RadioButton rbtnFromB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private KJ128WindowsLibrary.VSPanel vspConfig;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpSave;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel8;
        private KJ128WindowsLibrary.CaptionPanel cpConfigHead;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFromHead;
        private System.Windows.Forms.Label lblFromStation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbtnToA;
        private System.Windows.Forms.RadioButton rbtnToB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblToHead;
        private System.Windows.Forms.Label lblToStation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblInfo;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpPageSum;
        private KJ128WindowsLibrary.CaptionPanel lblSumPage;
        private KJ128WindowsLibrary.ButtonCaptionPanel cpUp;
        private KJ128WindowsLibrary.CaptionPanel txtPage;
        private KJ128WindowsLibrary.ButtonCaptionPanel cpCheckPage;
        private KJ128WindowsLibrary.ButtonCaptionPanel cpDown;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpSelect;
        private System.Windows.Forms.Label label2;
        private KJ128WindowsLibrary.VSPanel vsPanel;
        private System.Windows.Forms.Label lblUpdateResult;
        private KJ128WindowsLibrary.CaptionPanel cp;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpUpdate;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label9;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpConfig;
        private System.Windows.Forms.Label label8;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private KJ128NInterfaceShow.DataGridViewKJ128 dgvData;
        private System.Windows.Forms.ComboBox cmb_Size;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel12;
        private KJ128N.Command.TxtNumber txtCheckPage;
        private Wilson.Controls.XPPanel.Images.SXPPanelGroup sxpPanelGroup1;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel1;
        private System.Windows.Forms.Timer timer1;
        private Shine.ShineTextBox txtDirectional;
        private Shine.ShineTextBox txtWhere;
        private Shine.ShineTextBox txtUpdateD;
        private Shine.ShineTextBox txtUpdateDInfo;
        private Shine.ShineTextBox txtD;
        private Shine.ShineTextBox txt;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel2;

    }
}