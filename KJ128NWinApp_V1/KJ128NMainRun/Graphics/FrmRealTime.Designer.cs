namespace KJ128NMainRun.Graphics
{
    partial class FrmRealTime
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlRealTime = new System.Windows.Forms.Panel();
            this.dgvRealTime = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.cpStationHead = new KJ128WindowsLibrary.CaptionPanel();
            this.pnlInOut = new System.Windows.Forms.Panel();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.pnlEmp = new System.Windows.Forms.Panel();
            this.trvRealTime = new System.Windows.Forms.TreeView();
            this.labTitle = new System.Windows.Forms.Label();
            this.picInOut = new System.Windows.Forms.PictureBox();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.labColor = new System.Windows.Forms.Label();
            this.MapGis = new ZzhaControlLibrary.ZzhaMapGis();
            this.pnlRealTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealTime)).BeginInit();
            this.pnlInOut.SuspendLayout();
            this.pnlEmp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInOut)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRealTime
            // 
            this.pnlRealTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.pnlRealTime.Controls.Add(this.dgvRealTime);
            this.pnlRealTime.Controls.Add(this.cpStationHead);
            this.pnlRealTime.Location = new System.Drawing.Point(257, 173);
            this.pnlRealTime.Name = "pnlRealTime";
            this.pnlRealTime.Size = new System.Drawing.Size(425, 118);
            this.pnlRealTime.TabIndex = 1;
            // 
            // dgvRealTime
            // 
            this.dgvRealTime.AllowUserToAddRows = false;
            this.dgvRealTime.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvRealTime.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvRealTime.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.dgvRealTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRealTime.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvRealTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRealTime.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.WindowsStyle;
            this.dgvRealTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRealTime.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.dgvRealTime.Location = new System.Drawing.Point(0, 22);
            this.dgvRealTime.Name = "dgvRealTime";
            this.dgvRealTime.ReadOnly = true;
            this.dgvRealTime.RowHeadersVisible = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dgvRealTime.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvRealTime.RowTemplate.Height = 23;
            this.dgvRealTime.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRealTime.Size = new System.Drawing.Size(425, 96);
            this.dgvRealTime.TabIndex = 2;
            this.dgvRealTime.VerticalScrollBarMax = 1;
            this.dgvRealTime.VerticalScrollBarValue = 0;
            // 
            // cpStationHead
            // 
            this.cpStationHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpStationHead.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpStationHead.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpStationHead.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpStationHead.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpStationHead.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpStationHead.CaptionBottomLineWidth = 1;
            this.cpStationHead.CaptionCloseButtonControlLeft = 2;
            this.cpStationHead.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpStationHead.CaptionCloseButtonTitle = "×";
            this.cpStationHead.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpStationHead.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.cpStationHead.CaptionHeight = 20;
            this.cpStationHead.CaptionLeft = 1;
            this.cpStationHead.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpStationHead.CaptionTitle = "";
            this.cpStationHead.CaptionTitleLeft = 10;
            this.cpStationHead.CaptionTitleTop = 4;
            this.cpStationHead.CaptionTop = 1;
            this.cpStationHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.cpStationHead.IsBorderLine = true;
            this.cpStationHead.IsCaptionSingleColor = true;
            this.cpStationHead.IsOnlyCaption = true;
            this.cpStationHead.IsPanelImage = false;
            this.cpStationHead.IsUserButtonClose = true;
            this.cpStationHead.IsUserCaptionBottomLine = false;
            this.cpStationHead.IsUserSystemCloseButtonLeft = true;
            this.cpStationHead.Location = new System.Drawing.Point(0, 0);
            this.cpStationHead.Name = "cpStationHead";
            this.cpStationHead.PanelImage = null;
            this.cpStationHead.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.cpStationHead.Size = new System.Drawing.Size(425, 22);
            this.cpStationHead.TabIndex = 1;
            this.cpStationHead.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cpStationHead_MouseMove);
            this.cpStationHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cpStationHead_MouseDown);
            this.cpStationHead.CloseButtonClick += new System.EventHandler(this.cpConfigHead_CloseButtonClick);
            // 
            // pnlInOut
            // 
            this.pnlInOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.pnlInOut.BackgroundImage = global::KJ128NMainRun.Properties.Resources.ffrm;
            this.pnlInOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlInOut.Controls.Add(this.labColor);
            this.pnlInOut.Controls.Add(this.label1);
            this.pnlInOut.Controls.Add(this.btnShowAll);
            this.pnlInOut.Controls.Add(this.pnlEmp);
            this.pnlInOut.Controls.Add(this.picInOut);
            this.pnlInOut.Location = new System.Drawing.Point(-192, 32);
            this.pnlInOut.Name = "pnlInOut";
            this.pnlInOut.Size = new System.Drawing.Size(218, 445);
            this.pnlInOut.TabIndex = 4;
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(124, 414);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(62, 23);
            this.btnShowAll.TabIndex = 6;
            this.btnShowAll.Text = "强制显示";
            this.tip.SetToolTip(this.btnShowAll, "强制显示分站");
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // pnlEmp
            // 
            this.pnlEmp.BackColor = System.Drawing.Color.White;
            this.pnlEmp.Controls.Add(this.trvRealTime);
            this.pnlEmp.Controls.Add(this.labTitle);
            this.pnlEmp.Location = new System.Drawing.Point(3, 7);
            this.pnlEmp.Name = "pnlEmp";
            this.pnlEmp.Size = new System.Drawing.Size(187, 403);
            this.pnlEmp.TabIndex = 5;
            // 
            // trvRealTime
            // 
            this.trvRealTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trvRealTime.Location = new System.Drawing.Point(0, 23);
            this.trvRealTime.Name = "trvRealTime";
            this.trvRealTime.Size = new System.Drawing.Size(187, 380);
            this.trvRealTime.TabIndex = 1;
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle.Location = new System.Drawing.Point(7, 6);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(90, 14);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "下井总人数:";
            // 
            // picInOut
            // 
            this.picInOut.BackColor = System.Drawing.Color.White;
            this.picInOut.Image = global::KJ128NMainRun.Properties.Resources.right;
            this.picInOut.Location = new System.Drawing.Point(191, 13);
            this.picInOut.Name = "picInOut";
            this.picInOut.Size = new System.Drawing.Size(24, 418);
            this.picInOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picInOut.TabIndex = 0;
            this.picInOut.TabStop = false;
            this.picInOut.Click += new System.EventHandler(this.picInOut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "字体颜色";
            // 
            // labColor
            // 
            this.labColor.BackColor = System.Drawing.Color.Red;
            this.labColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labColor.Location = new System.Drawing.Point(70, 416);
            this.labColor.Name = "labColor";
            this.labColor.Size = new System.Drawing.Size(37, 18);
            this.labColor.TabIndex = 8;
            this.tip.SetToolTip(this.labColor, "点击更改分站字体颜色");
            this.labColor.Click += new System.EventHandler(this.labColor_Click);
            // 
            // MapGis
            // 
            this.MapGis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MapGis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MapGis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapGis.IsMoving = false;
            this.MapGis.IsStationChangeed = false;
            this.MapGis.Location = new System.Drawing.Point(0, 0);
            this.MapGis.MapFilePath = null;
            this.MapGis.MaxWidth = 35000;
            this.MapGis.MinWidth = 500;
            this.MapGis.MoverStrColor = System.Drawing.Color.Red;
            this.MapGis.Name = "MapGis";
            this.MapGis.ShowStationOther = true;
            this.MapGis.Size = new System.Drawing.Size(828, 538);
            this.MapGis.StationFilePath = null;
            this.MapGis.StationStrColor = System.Drawing.Color.Red;
            this.MapGis.TabIndex = 0;
            this.MapGis.UseDiv = false;
            this.MapGis.UseGif = true;
            // 
            // FrmRealTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 538);
            this.Controls.Add(this.pnlInOut);
            this.Controls.Add(this.pnlRealTime);
            this.Controls.Add(this.MapGis);
            this.Name = "FrmRealTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "实时分布";
            this.Text = "实时图形系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRealTime_Load);
            this.pnlRealTime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealTime)).EndInit();
            this.pnlInOut.ResumeLayout(false);
            this.pnlInOut.PerformLayout();
            this.pnlEmp.ResumeLayout(false);
            this.pnlEmp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ZzhaControlLibrary.ZzhaMapGis MapGis;
        private System.Windows.Forms.Panel pnlRealTime;
        private KJ128WindowsLibrary.CaptionPanel cpStationHead;
        private KJ128NInterfaceShow.DataGridViewKJ128 dgvRealTime;
        private System.Windows.Forms.Panel pnlInOut;
        private System.Windows.Forms.Panel pnlEmp;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.PictureBox picInOut;
        private System.Windows.Forms.TreeView trvRealTime;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.Label labColor;
    }
}