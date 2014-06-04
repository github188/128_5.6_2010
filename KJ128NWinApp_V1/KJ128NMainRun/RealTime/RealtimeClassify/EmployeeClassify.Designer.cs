using KJ128WindowsLibrary;
namespace KJ128NInterfaceShow
{
    partial class EmployeeClassify
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
            this.buttonCaptionPanel1 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.buttonCaptionPanel2 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.treeView1 = new KJ128WindowsLibrary.TreeViewDepartment();
            this.dgv_WorkType = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.captionPanel1 = new KJ128WindowsLibrary.CaptionPanel();
            this.captionPanel2 = new KJ128WindowsLibrary.CaptionPanel();
            this.captionPanel3 = new KJ128WindowsLibrary.CaptionPanel();
            this.captionPanel4 = new KJ128WindowsLibrary.CaptionPanel();
            this.captionPanel5 = new KJ128WindowsLibrary.CaptionPanel();
            this.timeControl = new System.Windows.Forms.Timer(this.components);
            this.chk = new System.Windows.Forms.CheckBox();
            this.captionPanel6 = new KJ128WindowsLibrary.CaptionPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_WorkType)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCaptionPanel1
            // 
            this.buttonCaptionPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCaptionPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCaptionPanel1.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.buttonCaptionPanel1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel1.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.buttonCaptionPanel1.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.buttonCaptionPanel1.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.buttonCaptionPanel1.CaptionBottomLineWidth = 1;
            this.buttonCaptionPanel1.CaptionCloseButtonControlLeft = 2;
            this.buttonCaptionPanel1.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCaptionPanel1.CaptionCloseButtonTitle = "×";
            this.buttonCaptionPanel1.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCaptionPanel1.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonCaptionPanel1.CaptionHeight = 30;
            this.buttonCaptionPanel1.CaptionLeft = 1;
            this.buttonCaptionPanel1.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.buttonCaptionPanel1.CaptionTitle = "根据不同的部门对员工下井信息进行汇总:";
            this.buttonCaptionPanel1.CaptionTitleLeft = 8;
            this.buttonCaptionPanel1.CaptionTitleTop = 8;
            this.buttonCaptionPanel1.CaptionTop = 1;
            this.buttonCaptionPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonCaptionPanel1.IsBorderLine = true;
            this.buttonCaptionPanel1.IsCaptionSingleColor = false;
            this.buttonCaptionPanel1.IsOnlyCaption = true;
            this.buttonCaptionPanel1.IsPanelImage = true;
            this.buttonCaptionPanel1.IsUserButtonClose = false;
            this.buttonCaptionPanel1.IsUserCaptionBottomLine = true;
            this.buttonCaptionPanel1.IsUserSystemCloseButtonLeft = true;
            this.buttonCaptionPanel1.Location = new System.Drawing.Point(162, -1);
            this.buttonCaptionPanel1.Name = "buttonCaptionPanel1";
            this.buttonCaptionPanel1.PanelImage = null;
            this.buttonCaptionPanel1.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.buttonCaptionPanel1.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.buttonCaptionPanel1.Size = new System.Drawing.Size(787, 32);
            this.buttonCaptionPanel1.TabIndex = 1;
            this.buttonCaptionPanel1.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // buttonCaptionPanel2
            // 
            this.buttonCaptionPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCaptionPanel2.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.buttonCaptionPanel2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel2.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.buttonCaptionPanel2.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.buttonCaptionPanel2.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.buttonCaptionPanel2.CaptionBottomLineWidth = 1;
            this.buttonCaptionPanel2.CaptionCloseButtonControlLeft = 2;
            this.buttonCaptionPanel2.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCaptionPanel2.CaptionCloseButtonTitle = "×";
            this.buttonCaptionPanel2.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCaptionPanel2.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonCaptionPanel2.CaptionHeight = 30;
            this.buttonCaptionPanel2.CaptionLeft = 1;
            this.buttonCaptionPanel2.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.buttonCaptionPanel2.CaptionTitle = "员工汇总条件:";
            this.buttonCaptionPanel2.CaptionTitleLeft = 8;
            this.buttonCaptionPanel2.CaptionTitleTop = 8;
            this.buttonCaptionPanel2.CaptionTop = 1;
            this.buttonCaptionPanel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonCaptionPanel2.IsBorderLine = true;
            this.buttonCaptionPanel2.IsCaptionSingleColor = false;
            this.buttonCaptionPanel2.IsOnlyCaption = true;
            this.buttonCaptionPanel2.IsPanelImage = true;
            this.buttonCaptionPanel2.IsUserButtonClose = false;
            this.buttonCaptionPanel2.IsUserCaptionBottomLine = true;
            this.buttonCaptionPanel2.IsUserSystemCloseButtonLeft = true;
            this.buttonCaptionPanel2.Location = new System.Drawing.Point(0, -1);
            this.buttonCaptionPanel2.Name = "buttonCaptionPanel2";
            this.buttonCaptionPanel2.PanelImage = null;
            this.buttonCaptionPanel2.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.buttonCaptionPanel2.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.buttonCaptionPanel2.Size = new System.Drawing.Size(156, 32);
            this.buttonCaptionPanel2.TabIndex = 2;
            this.buttonCaptionPanel2.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(162, 26);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(787, 537);
            this.treeView1.TabIndex = 8;
            // 
            // dgv_WorkType
            // 
            this.dgv_WorkType.AllowUserToAddRows = false;
            this.dgv_WorkType.AllowUserToDeleteRows = false;
            this.dgv_WorkType.AllowUserToResizeColumns = false;
            this.dgv_WorkType.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgv_WorkType.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_WorkType.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.dgv_WorkType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_WorkType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_WorkType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_WorkType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgv_WorkType.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.WindowsStyle;
            this.dgv_WorkType.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.dgv_WorkType.Location = new System.Drawing.Point(162, 26);
            this.dgv_WorkType.Name = "dgv_WorkType";
            this.dgv_WorkType.ReadOnly = true;
            this.dgv_WorkType.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dgv_WorkType.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_WorkType.RowTemplate.Height = 23;
            this.dgv_WorkType.Size = new System.Drawing.Size(505, 354);
            this.dgv_WorkType.TabIndex = 9;
            this.dgv_WorkType.VerticalScrollBarMax = 1;
            this.dgv_WorkType.VerticalScrollBarValue = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "下井人员名单";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 500;
            // 
            // captionPanel1
            // 
            this.captionPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.captionPanel1.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.captionPanel1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.captionPanel1.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.captionPanel1.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.captionPanel1.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.captionPanel1.CaptionBottomLineWidth = 1;
            this.captionPanel1.CaptionCloseButtonControlLeft = 2;
            this.captionPanel1.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.captionPanel1.CaptionCloseButtonTitle = "×";
            this.captionPanel1.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.captionPanel1.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.captionPanel1.CaptionHeight = 30;
            this.captionPanel1.CaptionLeft = 1;
            this.captionPanel1.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.captionPanel1.CaptionTitle = "按工种汇总";
            this.captionPanel1.CaptionTitleLeft = 8;
            this.captionPanel1.CaptionTitleTop = 8;
            this.captionPanel1.CaptionTop = 1;
            this.captionPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.captionPanel1.IsBorderLine = true;
            this.captionPanel1.IsCaptionSingleColor = false;
            this.captionPanel1.IsOnlyCaption = true;
            this.captionPanel1.IsPanelImage = false;
            this.captionPanel1.IsUserButtonClose = false;
            this.captionPanel1.IsUserCaptionBottomLine = false;
            this.captionPanel1.IsUserSystemCloseButtonLeft = true;
            this.captionPanel1.Location = new System.Drawing.Point(0, 26);
            this.captionPanel1.Name = "captionPanel1";
            this.captionPanel1.PanelImage = null;
            this.captionPanel1.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.captionPanel1.Size = new System.Drawing.Size(163, 32);
            this.captionPanel1.TabIndex = 10;
            this.captionPanel1.Click += new System.EventHandler(this.captionPanel1_Click);
            // 
            // captionPanel2
            // 
            this.captionPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.captionPanel2.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.captionPanel2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.captionPanel2.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.captionPanel2.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.captionPanel2.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.captionPanel2.CaptionBottomLineWidth = 1;
            this.captionPanel2.CaptionCloseButtonControlLeft = 2;
            this.captionPanel2.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.captionPanel2.CaptionCloseButtonTitle = "×";
            this.captionPanel2.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.captionPanel2.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.captionPanel2.CaptionHeight = 30;
            this.captionPanel2.CaptionLeft = 1;
            this.captionPanel2.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.captionPanel2.CaptionTitle = "按部门汇总";
            this.captionPanel2.CaptionTitleLeft = 8;
            this.captionPanel2.CaptionTitleTop = 8;
            this.captionPanel2.CaptionTop = 1;
            this.captionPanel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.captionPanel2.IsBorderLine = true;
            this.captionPanel2.IsCaptionSingleColor = false;
            this.captionPanel2.IsOnlyCaption = true;
            this.captionPanel2.IsPanelImage = false;
            this.captionPanel2.IsUserButtonClose = false;
            this.captionPanel2.IsUserCaptionBottomLine = false;
            this.captionPanel2.IsUserSystemCloseButtonLeft = true;
            this.captionPanel2.Location = new System.Drawing.Point(-1, 57);
            this.captionPanel2.Name = "captionPanel2";
            this.captionPanel2.PanelImage = null;
            this.captionPanel2.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.captionPanel2.Size = new System.Drawing.Size(164, 32);
            this.captionPanel2.TabIndex = 11;
            this.captionPanel2.Click += new System.EventHandler(this.captionPanel2_Click);
            // 
            // captionPanel3
            // 
            this.captionPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.captionPanel3.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.captionPanel3.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.captionPanel3.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.captionPanel3.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.captionPanel3.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.captionPanel3.CaptionBottomLineWidth = 1;
            this.captionPanel3.CaptionCloseButtonControlLeft = 2;
            this.captionPanel3.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.captionPanel3.CaptionCloseButtonTitle = "×";
            this.captionPanel3.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.captionPanel3.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.captionPanel3.CaptionHeight = 30;
            this.captionPanel3.CaptionLeft = 1;
            this.captionPanel3.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.captionPanel3.CaptionTitle = "按职务汇总";
            this.captionPanel3.CaptionTitleLeft = 8;
            this.captionPanel3.CaptionTitleTop = 8;
            this.captionPanel3.CaptionTop = 1;
            this.captionPanel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.captionPanel3.IsBorderLine = true;
            this.captionPanel3.IsCaptionSingleColor = false;
            this.captionPanel3.IsOnlyCaption = true;
            this.captionPanel3.IsPanelImage = false;
            this.captionPanel3.IsUserButtonClose = false;
            this.captionPanel3.IsUserCaptionBottomLine = false;
            this.captionPanel3.IsUserSystemCloseButtonLeft = true;
            this.captionPanel3.Location = new System.Drawing.Point(0, 87);
            this.captionPanel3.Name = "captionPanel3";
            this.captionPanel3.PanelImage = null;
            this.captionPanel3.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.captionPanel3.Size = new System.Drawing.Size(163, 32);
            this.captionPanel3.TabIndex = 12;
            this.captionPanel3.Click += new System.EventHandler(this.captionPanel3_Click);
            // 
            // captionPanel4
            // 
            this.captionPanel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.captionPanel4.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.captionPanel4.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.captionPanel4.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.captionPanel4.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.captionPanel4.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.captionPanel4.CaptionBottomLineWidth = 1;
            this.captionPanel4.CaptionCloseButtonControlLeft = 2;
            this.captionPanel4.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.captionPanel4.CaptionCloseButtonTitle = "×";
            this.captionPanel4.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.captionPanel4.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.captionPanel4.CaptionHeight = 30;
            this.captionPanel4.CaptionLeft = 1;
            this.captionPanel4.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.captionPanel4.CaptionTitle = "按方向性汇总";
            this.captionPanel4.CaptionTitleLeft = 8;
            this.captionPanel4.CaptionTitleTop = 8;
            this.captionPanel4.CaptionTop = 1;
            this.captionPanel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.captionPanel4.IsBorderLine = true;
            this.captionPanel4.IsCaptionSingleColor = false;
            this.captionPanel4.IsOnlyCaption = true;
            this.captionPanel4.IsPanelImage = false;
            this.captionPanel4.IsUserButtonClose = false;
            this.captionPanel4.IsUserCaptionBottomLine = false;
            this.captionPanel4.IsUserSystemCloseButtonLeft = true;
            this.captionPanel4.Location = new System.Drawing.Point(0, 118);
            this.captionPanel4.Name = "captionPanel4";
            this.captionPanel4.PanelImage = null;
            this.captionPanel4.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.captionPanel4.Size = new System.Drawing.Size(163, 32);
            this.captionPanel4.TabIndex = 13;
            this.captionPanel4.Click += new System.EventHandler(this.captionPanel4_Click);
            // 
            // captionPanel5
            // 
            this.captionPanel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.captionPanel5.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.captionPanel5.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.captionPanel5.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.captionPanel5.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.captionPanel5.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.captionPanel5.CaptionBottomLineWidth = 1;
            this.captionPanel5.CaptionCloseButtonControlLeft = 2;
            this.captionPanel5.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.captionPanel5.CaptionCloseButtonTitle = "×";
            this.captionPanel5.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.captionPanel5.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.captionPanel5.CaptionHeight = 30;
            this.captionPanel5.CaptionLeft = 1;
            this.captionPanel5.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.captionPanel5.CaptionTitle = "按职务等级汇总";
            this.captionPanel5.CaptionTitleLeft = 8;
            this.captionPanel5.CaptionTitleTop = 8;
            this.captionPanel5.CaptionTop = 1;
            this.captionPanel5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.captionPanel5.IsBorderLine = true;
            this.captionPanel5.IsCaptionSingleColor = false;
            this.captionPanel5.IsOnlyCaption = true;
            this.captionPanel5.IsPanelImage = false;
            this.captionPanel5.IsUserButtonClose = false;
            this.captionPanel5.IsUserCaptionBottomLine = false;
            this.captionPanel5.IsUserSystemCloseButtonLeft = true;
            this.captionPanel5.Location = new System.Drawing.Point(0, 148);
            this.captionPanel5.Name = "captionPanel5";
            this.captionPanel5.PanelImage = null;
            this.captionPanel5.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.captionPanel5.Size = new System.Drawing.Size(163, 32);
            this.captionPanel5.TabIndex = 14;
            this.captionPanel5.Click += new System.EventHandler(this.captionPanel5_Click);
            // 
            // timeControl
            // 
            this.timeControl.Enabled = true;
            this.timeControl.Interval = KJ128NInterfaceShow.RefReshTime._rtTime;
            this.timeControl.Tick += new System.EventHandler(this.timeControl_Tick);
            // 
            // chk
            // 
            this.chk.AutoSize = true;
            this.chk.Checked = true;
            this.chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk.Location = new System.Drawing.Point(24, 237);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(96, 16);
            this.chk.TabIndex = 15;
            this.chk.Text = "实时更新数据";
            this.chk.UseVisualStyleBackColor = true;
            this.chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // captionPanel6
            // 
            this.captionPanel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.captionPanel6.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.captionPanel6.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.captionPanel6.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.captionPanel6.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.captionPanel6.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.captionPanel6.CaptionBottomLineWidth = 1;
            this.captionPanel6.CaptionCloseButtonControlLeft = 2;
            this.captionPanel6.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.captionPanel6.CaptionCloseButtonTitle = "×";
            this.captionPanel6.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.captionPanel6.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.captionPanel6.CaptionHeight = 30;
            this.captionPanel6.CaptionLeft = 1;
            this.captionPanel6.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.captionPanel6.CaptionTitle = "按区域汇总";
            this.captionPanel6.CaptionTitleLeft = 8;
            this.captionPanel6.CaptionTitleTop = 8;
            this.captionPanel6.CaptionTop = 1;
            this.captionPanel6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.captionPanel6.IsBorderLine = true;
            this.captionPanel6.IsCaptionSingleColor = false;
            this.captionPanel6.IsOnlyCaption = true;
            this.captionPanel6.IsPanelImage = false;
            this.captionPanel6.IsUserButtonClose = false;
            this.captionPanel6.IsUserCaptionBottomLine = false;
            this.captionPanel6.IsUserSystemCloseButtonLeft = true;
            this.captionPanel6.Location = new System.Drawing.Point(0, 179);
            this.captionPanel6.Name = "captionPanel6";
            this.captionPanel6.PanelImage = null;
            this.captionPanel6.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.captionPanel6.Size = new System.Drawing.Size(163, 32);
            this.captionPanel6.TabIndex = 16;
            this.captionPanel6.Click += new System.EventHandler(this.captionPanel6_Click);
            // 
            // EmployeeClassify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(955, 575);
            this.Controls.Add(this.captionPanel6);
            this.Controls.Add(this.chk);
            this.Controls.Add(this.captionPanel5);
            this.Controls.Add(this.captionPanel4);
            this.Controls.Add(this.captionPanel3);
            this.Controls.Add(this.captionPanel2);
            this.Controls.Add(this.captionPanel1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.buttonCaptionPanel2);
            this.Controls.Add(this.buttonCaptionPanel1);
            this.Controls.Add(this.dgv_WorkType);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeClassify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "员工分类汇总信息";
            this.Text = "员工分类汇总信息";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_WorkType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel1;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel2;
        private TreeViewDepartment treeView1;
        private DataGridViewKJ128 dgv_WorkType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private CaptionPanel captionPanel1;
        private CaptionPanel captionPanel2;
        private CaptionPanel captionPanel3;
        private CaptionPanel captionPanel4;
        private CaptionPanel captionPanel5;
        private System.Windows.Forms.Timer timeControl;
        private System.Windows.Forms.CheckBox chk;
        private CaptionPanel captionPanel6;
    }
}