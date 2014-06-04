namespace KJ128NMainRun.DataOperate
{
    partial class FrmDataManage
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new Shine.ShineTextBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnRevert = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.txtFile = new Shine.ShineTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.linklblScan = new System.Windows.Forms.LinkLabel();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblBackupPath = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.pBarDB = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "备份文件路径:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(121, 20);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(203, 21);
            this.txtPath.TabIndex = 0;
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(367, 18);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(75, 23);
            this.btnBackup.TabIndex = 2;
            this.btnBackup.Text = "备  份";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnRevert
            // 
            this.btnRevert.Location = new System.Drawing.Point(367, 58);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(75, 23);
            this.btnRevert.TabIndex = 4;
            this.btnRevert.Text = "还  原";
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(26, 100);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(29, 12);
            this.lblInfo.TabIndex = 24;
            this.lblInfo.Text = "进度";
            this.lblInfo.Visible = false;
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(121, 58);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(203, 21);
            this.txtFile.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "还原文件路径:";
            // 
            // btnScan
            // 
            this.btnScan.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScan.Location = new System.Drawing.Point(323, 18);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(22, 23);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "…";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // linklblScan
            // 
            this.linklblScan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linklblScan.AutoSize = true;
            this.linklblScan.BackColor = System.Drawing.Color.Transparent;
            this.linklblScan.Location = new System.Drawing.Point(471, 24);
            this.linklblScan.Name = "linklblScan";
            this.linklblScan.Size = new System.Drawing.Size(65, 12);
            this.linklblScan.TabIndex = 5;
            this.linklblScan.TabStop = true;
            this.linklblScan.Text = "打开文件夹";
            this.linklblScan.Visible = false;
            this.linklblScan.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblScan_LinkClicked);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(448, 63);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(71, 12);
            this.lblFileName.TabIndex = 27;
            this.lblFileName.Text = "lblFileName";
            // 
            // lblBackupPath
            // 
            this.lblBackupPath.AutoSize = true;
            this.lblBackupPath.Location = new System.Drawing.Point(448, 43);
            this.lblBackupPath.Name = "lblBackupPath";
            this.lblBackupPath.Size = new System.Drawing.Size(41, 12);
            this.lblBackupPath.TabIndex = 29;
            this.lblBackupPath.Text = "label3";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(401, 100);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(17, 12);
            this.lbl.TabIndex = 30;
            this.lbl.Text = "0%";
            this.lbl.Visible = false;
            // 
            // pBarDB
            // 
            this.pBarDB.Location = new System.Drawing.Point(121, 97);
            this.pBarDB.Name = "pBarDB";
            this.pBarDB.Size = new System.Drawing.Size(256, 21);
            this.pBarDB.TabIndex = 31;
            this.pBarDB.Visible = false;
            // 
            // FrmDataManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(537, 138);
            this.Controls.Add(this.pBarDB);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.lblBackupPath);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.linklblScan);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRevert);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDataManage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "数据库备份和还原";
            this.Text = "数据库备份和还原";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDataManage_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRevert;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.LinkLabel linklblScan;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblBackupPath;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ProgressBar pBarDB;
    }
}