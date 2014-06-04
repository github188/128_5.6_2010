namespace KJ128A.Batman
{
    /// <summary>
    /// 通讯程序主窗体
    /// </summary>
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.ssStateList = new System.Windows.Forms.StatusStrip();
            this.tslTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsllblHost = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslHost = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsllblDataBase = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslDataBase = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslduishi = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stlHostBack = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslCommType = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslPointSelect = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ssStateList.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssStateList
            // 
            this.ssStateList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslTitle,
            this.tsllblHost,
            this.tslHost,
            this.toolStripStatusLabel2,
            this.tsllblDataBase,
            this.tslDataBase,
            this.toolStripStatusLabel1,
            this.tslduishi,
            this.toolStripStatusLabel3,
            this.stlHostBack,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.tslCommType,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel6,
            this.tsslPointSelect});
            this.ssStateList.Location = new System.Drawing.Point(0, 458);
            this.ssStateList.Name = "ssStateList";
            this.ssStateList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ssStateList.Size = new System.Drawing.Size(958, 22);
            this.ssStateList.TabIndex = 0;
            // 
            // tslTitle
            // 
            this.tslTitle.Name = "tslTitle";
            this.tslTitle.Size = new System.Drawing.Size(95, 17);
            this.tslTitle.Text = "连接状态：     ";
            // 
            // tsllblHost
            // 
            this.tsllblHost.Name = "tsllblHost";
            this.tsllblHost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsllblHost.Size = new System.Drawing.Size(71, 17);
            this.tsllblHost.Text = "主备机通讯:";
            // 
            // tslHost
            // 
            this.tslHost.Name = "tslHost";
            this.tslHost.Size = new System.Drawing.Size(47, 17);
            this.tslHost.Text = "tslHost";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Enabled = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel2.Text = "  |  ";
            // 
            // tsllblDataBase
            // 
            this.tsllblDataBase.Name = "tsllblDataBase";
            this.tsllblDataBase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsllblDataBase.Size = new System.Drawing.Size(47, 17);
            this.tsllblDataBase.Text = "数据库:";
            // 
            // tslDataBase
            // 
            this.tslDataBase.Name = "tslDataBase";
            this.tslDataBase.Size = new System.Drawing.Size(71, 17);
            this.tslDataBase.Text = "tslDataBase";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Enabled = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel1.Text = "  |  ";
            // 
            // tslduishi
            // 
            this.tslduishi.Name = "tslduishi";
            this.tslduishi.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(71, 17);
            this.toolStripStatusLabel3.Text = "主备机状态:";
            // 
            // stlHostBack
            // 
            this.stlHostBack.Name = "stlHostBack";
            this.stlHostBack.Size = new System.Drawing.Size(71, 17);
            this.stlHostBack.Text = "stlHostBack";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Enabled = false;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel4.Text = "  |  ";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel5.Text = "通讯方式:";
            // 
            // tslCommType
            // 
            this.tslCommType.Name = "tslCommType";
            this.tslCommType.Size = new System.Drawing.Size(131, 17);
            this.tslCommType.Text = "toolStripStatusLabel6";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Enabled = false;
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel7.Text = "  |  ";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel6.Text = "定点巡检：";
            // 
            // tsslPointSelect
            // 
            this.tsslPointSelect.Name = "tsslPointSelect";
            this.tsslPointSelect.Size = new System.Drawing.Size(17, 17);
            this.tsslPointSelect.Text = "无";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipTitle = "aaaaaaaaa";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 480);
            this.Controls.Add(this.ssStateList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "KJ128A 通讯程序 V2.0";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.ssStateList.ResumeLayout(false);
            this.ssStateList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssStateList;
        private System.Windows.Forms.ToolStripStatusLabel tsllblDataBase;
        private System.Windows.Forms.ToolStripStatusLabel tsllblHost;
        private System.Windows.Forms.ToolStripStatusLabel tslTitle;
        private System.Windows.Forms.ToolStripStatusLabel tslHost;
        private System.Windows.Forms.ToolStripStatusLabel tslDataBase;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripStatusLabel tslduishi;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel stlHostBack;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel tslCommType;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel tsslPointSelect;
    }
}

