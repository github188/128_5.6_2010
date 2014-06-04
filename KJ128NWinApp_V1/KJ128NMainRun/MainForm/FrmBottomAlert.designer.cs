namespace KJ128NInterfaceShow
{
    partial class FrmBottomAlert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBottomAlert));
            this.timeControl = new System.Windows.Forms.Timer(this.components);
            this.lbAlarmErr = new System.Windows.Forms.Label();
            this.timerAlarm = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cpAlram = new KJ128WindowsLibrary.CaptionPanel();
            this.label_msg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timeControl
            // 
            this.timeControl.Interval = 5000;
            // 
            // lbAlarmErr
            // 
            this.lbAlarmErr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAlarmErr.AutoSize = true;
            this.lbAlarmErr.ForeColor = System.Drawing.Color.Red;
            this.lbAlarmErr.Location = new System.Drawing.Point(906, 5);
            this.lbAlarmErr.Name = "lbAlarmErr";
            this.lbAlarmErr.Size = new System.Drawing.Size(101, 12);
            this.lbAlarmErr.TabIndex = 28;
            this.lbAlarmErr.Text = "报警声音文件损坏";
            this.lbAlarmErr.Visible = false;
            // 
            // timerAlarm
            // 
            this.timerAlarm.Enabled = true;
            this.timerAlarm.Interval = 5000;
            this.timerAlarm.Tick += new System.EventHandler(this.timerAlarm_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(76, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 12);
            this.label7.TabIndex = 29;
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 100;
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 10000;
            this.toolTip.ReshowDelay = 100;
            // 
            // cpAlram
            // 
            this.cpAlram.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpAlram.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpAlram.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.cpAlram.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(121)))), ((int)(((byte)(191)))));
            this.cpAlram.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(97)))), ((int)(((byte)(168)))));
            this.cpAlram.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpAlram.CaptionBottomLineWidth = 1;
            this.cpAlram.CaptionCloseButtonControlLeft = 1;
            this.cpAlram.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpAlram.CaptionCloseButtonTitle = "×";
            this.cpAlram.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpAlram.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(22)))), ((int)(((byte)(110)))));
            this.cpAlram.CaptionHeight = 20;
            this.cpAlram.CaptionLeft = 1;
            this.cpAlram.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpAlram.CaptionTitle = "报警信息";
            this.cpAlram.CaptionTitleLeft = 8;
            this.cpAlram.CaptionTitleTop = 4;
            this.cpAlram.CaptionTop = 1;
            this.cpAlram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cpAlram.IsBorderLine = true;
            this.cpAlram.IsCaptionSingleColor = true;
            this.cpAlram.IsOnlyCaption = false;
            this.cpAlram.IsPanelImage = false;
            this.cpAlram.IsUserButtonClose = false;
            this.cpAlram.IsUserCaptionBottomLine = true;
            this.cpAlram.IsUserSystemCloseButtonLeft = true;
            this.cpAlram.Location = new System.Drawing.Point(0, 0);
            this.cpAlram.Name = "cpAlram";
            this.cpAlram.PanelImage = ((System.Drawing.Image)(resources.GetObject("cpAlram.PanelImage")));
            this.cpAlram.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.paleCaption;
            this.cpAlram.Size = new System.Drawing.Size(1019, 71);
            this.cpAlram.TabIndex = 13;
            // 
            // label_msg
            // 
            this.label_msg.AutoSize = true;
            this.label_msg.Location = new System.Drawing.Point(154, 5);
            this.label_msg.Name = "label_msg";
            this.label_msg.Size = new System.Drawing.Size(0, 12);
            this.label_msg.TabIndex = 30;
            // 
            // FrmBottomAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1019, 71);
            this.Controls.Add(this.label_msg);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbAlarmErr);
            this.Controls.Add(this.cpAlram);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmBottomAlert";
            this.TabText = "报警栏";
            this.Text = "报警栏";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBottomAlert_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        // public 菜单
        private System.Windows.Forms.Timer timeControl;
        private KJ128WindowsLibrary.CaptionPanel cpAlram;
        private System.Windows.Forms.Label lbAlarmErr;
        private System.Windows.Forms.Timer timerAlarm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Label label_msg;
    }
}

