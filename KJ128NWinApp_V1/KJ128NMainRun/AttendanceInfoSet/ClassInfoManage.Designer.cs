namespace KJ128NInterfaceShow
{
    partial class ClassInfoManage
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
            this.captionPanel1 = new KJ128WindowsLibrary.CaptionPanel();
            this.dgrd = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.cellEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cellDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.bcpAdd = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cpModify = new KJ128WindowsLibrary.CaptionPanel();
            this.labelTransparent1 = new KJ128WindowsLibrary.LabelTransparent();
            this.txtName = new Shine.ShineTextBox();
            this.labelTransparent2 = new KJ128WindowsLibrary.LabelTransparent();
            this.labelTransparent3 = new KJ128WindowsLibrary.LabelTransparent();
            this.txtShortName = new Shine.ShineTextBox();
            this.txtRemark = new Shine.ShineTextBox();
            this.buttonCPModify = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.buttonCPCancel = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.lblID = new System.Windows.Forms.Label();
            this.lblErr = new KJ128WindowsLibrary.LabelTransparent();
            this.lblValidate1 = new System.Windows.Forms.Label();
            this.lblValidate2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bcpRef = new KJ128WindowsLibrary.ButtonCaptionPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).BeginInit();
            this.SuspendLayout();
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
            this.captionPanel1.CaptionHeight = 20;
            this.captionPanel1.CaptionLeft = 1;
            this.captionPanel1.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.captionPanel1.CaptionTitle = "";
            this.captionPanel1.CaptionTitleLeft = 8;
            this.captionPanel1.CaptionTitleTop = 4;
            this.captionPanel1.CaptionTop = 1;
            this.captionPanel1.IsBorderLine = true;
            this.captionPanel1.IsCaptionSingleColor = false;
            this.captionPanel1.IsOnlyCaption = false;
            this.captionPanel1.IsPanelImage = false;
            this.captionPanel1.IsUserButtonClose = false;
            this.captionPanel1.IsUserCaptionBottomLine = true;
            this.captionPanel1.IsUserSystemCloseButtonLeft = true;
            this.captionPanel1.Location = new System.Drawing.Point(3, 1);
            this.captionPanel1.Name = "captionPanel1";
            this.captionPanel1.PanelImage = null;
            this.captionPanel1.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.captionPanel1.Size = new System.Drawing.Size(636, 309);
            this.captionPanel1.TabIndex = 0;
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
            this.dgrd.EnableHeadersVisualStyles = false;
            this.dgrd.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(191)))), ((int)(((byte)(219)))));
            this.dgrd.Location = new System.Drawing.Point(3, 23);
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
            this.dgrd.Size = new System.Drawing.Size(636, 287);
            this.dgrd.TabIndex = 2;
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
            // bcpAdd
            // 
            this.bcpAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bcpAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpAdd.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpAdd.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpAdd.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.bcpAdd.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
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
            this.bcpAdd.CaptionTitle = "添 加";
            this.bcpAdd.CaptionTitleLeft = 23;
            this.bcpAdd.CaptionTitleTop = 4;
            this.bcpAdd.CaptionTop = 1;
            this.bcpAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcpAdd.IsBorderLine = true;
            this.bcpAdd.IsCaptionSingleColor = false;
            this.bcpAdd.IsOnlyCaption = true;
            this.bcpAdd.IsPanelImage = true;
            this.bcpAdd.IsUserButtonClose = false;
            this.bcpAdd.IsUserCaptionBottomLine = false;
            this.bcpAdd.IsUserSystemCloseButtonLeft = true;
            this.bcpAdd.Location = new System.Drawing.Point(550, 1);
            this.bcpAdd.Name = "bcpAdd";
            this.bcpAdd.PanelImage = null;
            this.bcpAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bcpAdd.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpAdd.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpAdd.Size = new System.Drawing.Size(87, 22);
            this.bcpAdd.TabIndex = 1;
            this.bcpAdd.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpAdd.Click += new System.EventHandler(this.bcpAdd_Click);
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
            this.cpModify.CaptionTitle = "班制修改";
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
            this.cpModify.Location = new System.Drawing.Point(48, 48);
            this.cpModify.Name = "cpModify";
            this.cpModify.PanelImage = null;
            this.cpModify.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.cpModify.Size = new System.Drawing.Size(492, 239);
            this.cpModify.TabIndex = 3;
            // 
            // labelTransparent1
            // 
            this.labelTransparent1.AutoSize = true;
            this.labelTransparent1.IsTransparent = false;
            this.labelTransparent1.Location = new System.Drawing.Point(133, 79);
            this.labelTransparent1.Name = "labelTransparent1";
            this.labelTransparent1.Size = new System.Drawing.Size(65, 12);
            this.labelTransparent1.TabIndex = 4;
            this.labelTransparent1.Text = "班制全称：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(213, 75);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(151, 21);
            this.txtName.TabIndex = 5;
            this.txtName.TextType = Shine.TextType.WithOutChar;
            // 
            // labelTransparent2
            // 
            this.labelTransparent2.AutoSize = true;
            this.labelTransparent2.IsTransparent = false;
            this.labelTransparent2.Location = new System.Drawing.Point(133, 146);
            this.labelTransparent2.Name = "labelTransparent2";
            this.labelTransparent2.Size = new System.Drawing.Size(41, 12);
            this.labelTransparent2.TabIndex = 6;
            this.labelTransparent2.Text = "备注：";
            // 
            // labelTransparent3
            // 
            this.labelTransparent3.AutoSize = true;
            this.labelTransparent3.IsTransparent = false;
            this.labelTransparent3.Location = new System.Drawing.Point(133, 110);
            this.labelTransparent3.Name = "labelTransparent3";
            this.labelTransparent3.Size = new System.Drawing.Size(65, 12);
            this.labelTransparent3.TabIndex = 7;
            this.labelTransparent3.Text = "班制简称：";
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(211, 108);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(151, 21);
            this.txtShortName.TabIndex = 8;
            this.txtShortName.TextType = Shine.TextType.WithOutChar;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(211, 138);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(194, 104);
            this.txtRemark.TabIndex = 9;
            this.txtRemark.TextType = Shine.TextType.WithOutChar;
            // 
            // buttonCPModify
            // 
            this.buttonCPModify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCPModify.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.buttonCPModify.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.buttonCPModify.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.buttonCPModify.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.buttonCPModify.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.buttonCPModify.CaptionBottomLineWidth = 1;
            this.buttonCPModify.CaptionCloseButtonControlLeft = 2;
            this.buttonCPModify.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCPModify.CaptionCloseButtonTitle = "×";
            this.buttonCPModify.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCPModify.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonCPModify.CaptionHeight = 20;
            this.buttonCPModify.CaptionLeft = 1;
            this.buttonCPModify.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.buttonCPModify.CaptionTitle = "修 改";
            this.buttonCPModify.CaptionTitleLeft = 20;
            this.buttonCPModify.CaptionTitleTop = 4;
            this.buttonCPModify.CaptionTop = 1;
            this.buttonCPModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCPModify.IsBorderLine = true;
            this.buttonCPModify.IsCaptionSingleColor = false;
            this.buttonCPModify.IsOnlyCaption = true;
            this.buttonCPModify.IsPanelImage = true;
            this.buttonCPModify.IsUserButtonClose = false;
            this.buttonCPModify.IsUserCaptionBottomLine = false;
            this.buttonCPModify.IsUserSystemCloseButtonLeft = true;
            this.buttonCPModify.Location = new System.Drawing.Point(187, 253);
            this.buttonCPModify.Name = "buttonCPModify";
            this.buttonCPModify.PanelImage = null;
            this.buttonCPModify.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.buttonCPModify.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.buttonCPModify.Size = new System.Drawing.Size(79, 22);
            this.buttonCPModify.TabIndex = 10;
            this.buttonCPModify.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.buttonCPModify.Click += new System.EventHandler(this.buttonCPModify_Click);
            // 
            // buttonCPCancel
            // 
            this.buttonCPCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCPCancel.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.buttonCPCancel.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.buttonCPCancel.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.buttonCPCancel.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.buttonCPCancel.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.buttonCPCancel.CaptionBottomLineWidth = 1;
            this.buttonCPCancel.CaptionCloseButtonControlLeft = 2;
            this.buttonCPCancel.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCPCancel.CaptionCloseButtonTitle = "×";
            this.buttonCPCancel.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCPCancel.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonCPCancel.CaptionHeight = 20;
            this.buttonCPCancel.CaptionLeft = 1;
            this.buttonCPCancel.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.buttonCPCancel.CaptionTitle = "关 闭";
            this.buttonCPCancel.CaptionTitleLeft = 22;
            this.buttonCPCancel.CaptionTitleTop = 4;
            this.buttonCPCancel.CaptionTop = 1;
            this.buttonCPCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCPCancel.IsBorderLine = true;
            this.buttonCPCancel.IsCaptionSingleColor = false;
            this.buttonCPCancel.IsOnlyCaption = true;
            this.buttonCPCancel.IsPanelImage = true;
            this.buttonCPCancel.IsUserButtonClose = false;
            this.buttonCPCancel.IsUserCaptionBottomLine = false;
            this.buttonCPCancel.IsUserSystemCloseButtonLeft = true;
            this.buttonCPCancel.Location = new System.Drawing.Point(284, 253);
            this.buttonCPCancel.Name = "buttonCPCancel";
            this.buttonCPCancel.PanelImage = null;
            this.buttonCPCancel.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.buttonCPCancel.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.buttonCPCancel.Size = new System.Drawing.Size(79, 22);
            this.buttonCPCancel.TabIndex = 11;
            this.buttonCPCancel.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.buttonCPCancel.Click += new System.EventHandler(this.buttonCPCancel_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(447, 126);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 12);
            this.lblID.TabIndex = 12;
            this.lblID.Visible = false;
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.IsTransparent = false;
            this.lblErr.Location = new System.Drawing.Point(277, 314);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(0, 12);
            this.lblErr.TabIndex = 13;
            // 
            // lblValidate1
            // 
            this.lblValidate1.AutoSize = true;
            this.lblValidate1.ForeColor = System.Drawing.Color.Red;
            this.lblValidate1.Location = new System.Drawing.Point(371, 79);
            this.lblValidate1.Name = "lblValidate1";
            this.lblValidate1.Size = new System.Drawing.Size(11, 12);
            this.lblValidate1.TabIndex = 14;
            this.lblValidate1.Text = "*";
            // 
            // lblValidate2
            // 
            this.lblValidate2.AutoSize = true;
            this.lblValidate2.ForeColor = System.Drawing.Color.Red;
            this.lblValidate2.Location = new System.Drawing.Point(369, 113);
            this.lblValidate2.Name = "lblValidate2";
            this.lblValidate2.Size = new System.Drawing.Size(11, 12);
            this.lblValidate2.TabIndex = 15;
            this.lblValidate2.Text = "*";
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
            this.bcpRef.Location = new System.Drawing.Point(461, 1);
            this.bcpRef.Name = "bcpRef";
            this.bcpRef.PanelImage = null;
            this.bcpRef.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bcpRef.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpRef.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpRef.Size = new System.Drawing.Size(87, 22);
            this.bcpRef.TabIndex = 16;
            this.bcpRef.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpRef.Click += new System.EventHandler(this.bcpRef_Click);
            // 
            // ClassInfoManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(638, 311);
            this.Controls.Add(this.bcpRef);
            this.Controls.Add(this.lblValidate2);
            this.Controls.Add(this.lblValidate1);
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.buttonCPCancel);
            this.Controls.Add(this.buttonCPModify);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtShortName);
            this.Controls.Add(this.labelTransparent3);
            this.Controls.Add(this.labelTransparent2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelTransparent1);
            this.Controls.Add(this.cpModify);
            this.Controls.Add(this.dgrd);
            this.Controls.Add(this.bcpAdd);
            this.Controls.Add(this.captionPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClassInfoManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "班制信息管理";
            this.Text = "班制信息管理";
            this.Load += new System.EventHandler(this.ClassInfoManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KJ128WindowsLibrary.CaptionPanel captionPanel1;
        private KJ128NInterfaceShow.DataGridViewKJ128 dgrd;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpAdd;
        private KJ128WindowsLibrary.CaptionPanel cpModify;
        private KJ128WindowsLibrary.LabelTransparent labelTransparent1;
        private KJ128WindowsLibrary.LabelTransparent labelTransparent2;
        private KJ128WindowsLibrary.LabelTransparent labelTransparent3;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCPModify;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCPCancel;
        private System.Windows.Forms.DataGridViewLinkColumn cellEdit;
        private System.Windows.Forms.DataGridViewLinkColumn cellDelete;
        private System.Windows.Forms.Label lblID;
        private KJ128WindowsLibrary.LabelTransparent lblErr;
        private System.Windows.Forms.Label lblValidate1;
        private System.Windows.Forms.Label lblValidate2;
        private System.Windows.Forms.Timer timer1;
        private Shine.ShineTextBox txtName;
        private Shine.ShineTextBox txtShortName;
        private Shine.ShineTextBox txtRemark;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpRef;


    }
}