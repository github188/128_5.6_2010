namespace KJ128NMainRun
{
    partial class FormHisPassInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cpnlTop = new KJ128WindowsLibrary.CaptionPanel();
            this.dgVMain = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.buttonCaptionPanel1 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.bcpPrint = new KJ128WindowsLibrary.ButtonCaptionPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgVMain)).BeginInit();
            this.SuspendLayout();
            // 
            // cpnlTop
            // 
            this.cpnlTop.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpnlTop.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpnlTop.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(121)))), ((int)(((byte)(191)))));
            this.cpnlTop.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(97)))), ((int)(((byte)(168)))));
            this.cpnlTop.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpnlTop.CaptionBottomLineWidth = 1;
            this.cpnlTop.CaptionCloseButtonControlLeft = 2;
            this.cpnlTop.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpnlTop.CaptionCloseButtonTitle = "×";
            this.cpnlTop.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpnlTop.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cpnlTop.CaptionHeight = 20;
            this.cpnlTop.CaptionLeft = 1;
            this.cpnlTop.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpnlTop.CaptionTitle = "Title";
            this.cpnlTop.CaptionTitleLeft = 8;
            this.cpnlTop.CaptionTitleTop = 4;
            this.cpnlTop.CaptionTop = 1;
            this.cpnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.cpnlTop.IsBorderLine = true;
            this.cpnlTop.IsCaptionSingleColor = false;
            this.cpnlTop.IsOnlyCaption = false;
            this.cpnlTop.IsPanelImage = false;
            this.cpnlTop.IsUserButtonClose = false;
            this.cpnlTop.IsUserCaptionBottomLine = false;
            this.cpnlTop.IsUserSystemCloseButtonLeft = true;
            this.cpnlTop.Location = new System.Drawing.Point(0, 0);
            this.cpnlTop.Name = "cpnlTop";
            this.cpnlTop.PanelImage = null;
            this.cpnlTop.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.cpnlTop.Size = new System.Drawing.Size(970, 22);
            this.cpnlTop.TabIndex = 1;
            // 
            // dgVMain
            // 
            this.dgVMain.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgVMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgVMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgVMain.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.dgVMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgVMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgVMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgVMain.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.BlueStyle;
            this.dgVMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgVMain.EnableHeadersVisualStyles = false;
            this.dgVMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(191)))), ((int)(((byte)(219)))));
            this.dgVMain.Location = new System.Drawing.Point(0, 22);
            this.dgVMain.Name = "dgVMain";
            this.dgVMain.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgVMain.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dgVMain.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgVMain.RowTemplate.Height = 23;
            this.dgVMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVMain.Size = new System.Drawing.Size(970, 393);
            this.dgVMain.TabIndex = 2;
            this.dgVMain.VerticalScrollBarMax = 1;
            this.dgVMain.VerticalScrollBarValue = 0;
            // 
            // buttonCaptionPanel1
            // 
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
            this.buttonCaptionPanel1.Location = new System.Drawing.Point(533, -129);
            this.buttonCaptionPanel1.Name = "buttonCaptionPanel1";
            this.buttonCaptionPanel1.PanelImage = null;
            this.buttonCaptionPanel1.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.WindowsStyle;
            this.buttonCaptionPanel1.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.buttonCaptionPanel1.Size = new System.Drawing.Size(150, 22);
            this.buttonCaptionPanel1.TabIndex = 3;
            this.buttonCaptionPanel1.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // bcpPrint
            // 
            this.bcpPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bcpPrint.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpPrint.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpPrint.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.bcpPrint.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.bcpPrint.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpPrint.CaptionBottomLineWidth = 1;
            this.bcpPrint.CaptionCloseButtonControlLeft = 2;
            this.bcpPrint.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpPrint.CaptionCloseButtonTitle = "×";
            this.bcpPrint.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpPrint.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bcpPrint.CaptionHeight = 20;
            this.bcpPrint.CaptionLeft = 1;
            this.bcpPrint.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpPrint.CaptionTitle = "打印";
            this.bcpPrint.CaptionTitleLeft = 8;
            this.bcpPrint.CaptionTitleTop = 4;
            this.bcpPrint.CaptionTop = 1;
            this.bcpPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcpPrint.IsBorderLine = true;
            this.bcpPrint.IsCaptionSingleColor = false;
            this.bcpPrint.IsOnlyCaption = true;
            this.bcpPrint.IsPanelImage = true;
            this.bcpPrint.IsUserButtonClose = false;
            this.bcpPrint.IsUserCaptionBottomLine = false;
            this.bcpPrint.IsUserSystemCloseButtonLeft = true;
            this.bcpPrint.Location = new System.Drawing.Point(911, 0);
            this.bcpPrint.Name = "bcpPrint";
            this.bcpPrint.PanelImage = null;
            this.bcpPrint.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpPrint.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpPrint.Size = new System.Drawing.Size(56, 22);
            this.bcpPrint.TabIndex = 4;
            this.bcpPrint.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpPrint.Click += new System.EventHandler(this.bcpPrint_Click);
            // 
            // FormHisPassInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 415);
            this.Controls.Add(this.bcpPrint);
            this.Controls.Add(this.buttonCaptionPanel1);
            this.Controls.Add(this.dgVMain);
            this.Controls.Add(this.cpnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHisPassInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "历史路过探测器信息";
            this.Text = "历史路过探测器信息";
            this.Load += new System.EventHandler(this.HisPassInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgVMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KJ128WindowsLibrary.CaptionPanel cpnlTop;
        private KJ128NInterfaceShow.DataGridViewKJ128 dgVMain;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel1;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpPrint;
    }
}