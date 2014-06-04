namespace KJ128NInterfaceShow
{
    partial class RealTimeInOutStation
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
            this.buttonCaptionPanel1 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.dgvInOutStationInfo = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInOutStationInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCaptionPanel1
            // 
            this.buttonCaptionPanel1.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(121)))), ((int)(((byte)(191)))));
            this.buttonCaptionPanel1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel1.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(121)))), ((int)(((byte)(191)))));
            this.buttonCaptionPanel1.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(97)))), ((int)(((byte)(168)))));
            this.buttonCaptionPanel1.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.buttonCaptionPanel1.CaptionBottomLineWidth = 1;
            this.buttonCaptionPanel1.CaptionCloseButtonControlLeft = 2;
            this.buttonCaptionPanel1.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCaptionPanel1.CaptionCloseButtonTitle = "×";
            this.buttonCaptionPanel1.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCaptionPanel1.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonCaptionPanel1.CaptionHeight = 30;
            this.buttonCaptionPanel1.CaptionLeft = 1;
            this.buttonCaptionPanel1.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.buttonCaptionPanel1.CaptionTitle = "实时进出分站信息";
            this.buttonCaptionPanel1.CaptionTitleLeft = 8;
            this.buttonCaptionPanel1.CaptionTitleTop = 8;
            this.buttonCaptionPanel1.CaptionTop = 1;
            this.buttonCaptionPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonCaptionPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCaptionPanel1.IsBorderLine = true;
            this.buttonCaptionPanel1.IsCaptionSingleColor = false;
            this.buttonCaptionPanel1.IsOnlyCaption = true;
            this.buttonCaptionPanel1.IsPanelImage = true;
            this.buttonCaptionPanel1.IsUserButtonClose = false;
            this.buttonCaptionPanel1.IsUserCaptionBottomLine = false;
            this.buttonCaptionPanel1.IsUserSystemCloseButtonLeft = true;
            this.buttonCaptionPanel1.Location = new System.Drawing.Point(0, 0);
            this.buttonCaptionPanel1.Name = "buttonCaptionPanel1";
            this.buttonCaptionPanel1.PanelImage = null;
            this.buttonCaptionPanel1.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.buttonCaptionPanel1.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.buttonCaptionPanel1.Size = new System.Drawing.Size(1115, 32);
            this.buttonCaptionPanel1.TabIndex = 0;
            this.buttonCaptionPanel1.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // dgvInOutStationInfo
            // 
            this.dgvInOutStationInfo.AllowUserToAddRows = false;
            this.dgvInOutStationInfo.AllowUserToDeleteRows = false;
            this.dgvInOutStationInfo.AllowUserToResizeColumns = false;
            this.dgvInOutStationInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvInOutStationInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInOutStationInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInOutStationInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.dgvInOutStationInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInOutStationInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInOutStationInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInOutStationInfo.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.WindowsStyle;
            this.dgvInOutStationInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.dgvInOutStationInfo.Location = new System.Drawing.Point(1, 32);
            this.dgvInOutStationInfo.Name = "dgvInOutStationInfo";
            this.dgvInOutStationInfo.ReadOnly = true;
            this.dgvInOutStationInfo.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dgvInOutStationInfo.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInOutStationInfo.RowTemplate.Height = 23;
            this.dgvInOutStationInfo.Size = new System.Drawing.Size(1116, 347);
            this.dgvInOutStationInfo.TabIndex = 1;
            this.dgvInOutStationInfo.VerticalScrollBarMax = 1;
            this.dgvInOutStationInfo.VerticalScrollBarValue = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = KJ128NInterfaceShow.RefReshTime._rtTime;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // RealTimeInOutStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1115, 380);
            this.Controls.Add(this.dgvInOutStationInfo);
            this.Controls.Add(this.buttonCaptionPanel1);
            this.Name = "RealTimeInOutStation";
            this.TabText = "实时进出分站信息";
            this.Text = "实时进出分站信息";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RealTimeInOutStation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInOutStationInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel1;
        private KJ128NInterfaceShow.DataGridViewKJ128 dgvInOutStationInfo;
        private System.Windows.Forms.Timer timer1;

    }
}