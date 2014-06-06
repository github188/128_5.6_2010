namespace KJ128NInterfaceShow
{
    partial class FrmAboutUs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAboutUs));
			this.btnSysInfo = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.lblInfo = new System.Windows.Forms.Label();
			this.lblOSInfo = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblCLRVer = new System.Windows.Forms.Label();
			this.lblMic = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSysInfo
			// 
			this.btnSysInfo.Location = new System.Drawing.Point(356, 203);
			this.btnSysInfo.Name = "btnSysInfo";
			this.btnSysInfo.Size = new System.Drawing.Size(87, 23);
			this.btnSysInfo.TabIndex = 1;
			this.btnSysInfo.Text = "系统信息(&S)";
			this.btnSysInfo.UseVisualStyleBackColor = true;
			this.btnSysInfo.Click += new System.EventHandler(this.btnSysInfo_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(247, 203);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(87, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "确定";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// lblInfo
			// 
			this.lblInfo.Location = new System.Drawing.Point(264, 80);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(230, 74);
			this.lblInfo.TabIndex = 3;
			this.lblInfo.Text = "警告：本计算机程序受著作权法和国际条约保护。如未经授权而擅自复制或传播本程序(或其中任何部分)，将受到严厉的民事和刑事制裁，并将在法律许可最大限度内受到起诉。";
			// 
			// lblOSInfo
			// 
			this.lblOSInfo.Location = new System.Drawing.Point(264, 152);
			this.lblOSInfo.Name = "lblOSInfo";
			this.lblOSInfo.Size = new System.Drawing.Size(195, 28);
			this.lblOSInfo.TabIndex = 4;
			this.lblOSInfo.Text = "OS VER";
			// 
			// lblTitle
			// 
			this.lblTitle.Location = new System.Drawing.Point(69, 180);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(312, 23);
			this.lblTitle.TabIndex = 5;
			this.lblTitle.Text = "(C)2013 - 2015  江苏三恒科技股份有限公司 版权所有。";
			// 
			// lblCLRVer
			// 
			this.lblCLRVer.Location = new System.Drawing.Point(12, 106);
			this.lblCLRVer.Name = "lblCLRVer";
			this.lblCLRVer.Size = new System.Drawing.Size(160, 13);
			this.lblCLRVer.TabIndex = 6;
			this.lblCLRVer.Text = "版本: V5.6(界沟定制)";
			// 
			// lblMic
			// 
			this.lblMic.Location = new System.Drawing.Point(12, 152);
			this.lblMic.Name = "lblMic";
			this.lblMic.Size = new System.Drawing.Size(148, 15);
			this.lblMic.TabIndex = 7;
			this.lblMic.Text = "发布时间:2014-06-06";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(497, 70);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 82);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(242, 14);
			this.label1.TabIndex = 8;
			this.label1.Text = "产品名称:三恒KJ128A矿用人员管理系统软件";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 129);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(242, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "公司名称:江苏三恒科技股份有限公司";
			// 
			// FrmAboutUs
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(497, 234);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblMic);
			this.Controls.Add(this.lblCLRVer);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.lblOSInfo);
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnSysInfo);
			this.Controls.Add(this.pictureBox1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmAboutUs";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "关于 KJ128A矿用人员管理系统";
			this.Load += new System.EventHandler(this.FrmAboutUs_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSysInfo;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblOSInfo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCLRVer;
        private System.Windows.Forms.Label lblMic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}