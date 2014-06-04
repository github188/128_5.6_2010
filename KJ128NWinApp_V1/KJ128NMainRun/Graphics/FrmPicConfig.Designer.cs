namespace KJ128NMainRun.Graphics
{
    partial class FrmPicConfig
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
            this.lsbPic = new System.Windows.Forms.ListBox();
            this.picPic = new System.Windows.Forms.PictureBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picPic)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsbPic
            // 
            this.lsbPic.Dock = System.Windows.Forms.DockStyle.Left;
            this.lsbPic.FormattingEnabled = true;
            this.lsbPic.ItemHeight = 12;
            this.lsbPic.Location = new System.Drawing.Point(0, 0);
            this.lsbPic.Name = "lsbPic";
            this.lsbPic.Size = new System.Drawing.Size(120, 556);
            this.lsbPic.TabIndex = 0;
            this.lsbPic.SelectedIndexChanged += new System.EventHandler(this.lsbPic_SelectedIndexChanged);
            // 
            // picPic
            // 
            this.picPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPic.Location = new System.Drawing.Point(120, 49);
            this.picPic.Name = "picPic";
            this.picPic.Size = new System.Drawing.Size(847, 511);
            this.picPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPic.TabIndex = 1;
            this.picPic.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(6, 12);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "更改图片";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(120, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 49);
            this.panel1.TabIndex = 3;
            // 
            // FrmPicConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(967, 560);
            this.Controls.Add(this.picPic);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lsbPic);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPicConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "图形配置";
            this.Text = "底图及图库配置";
            this.Load += new System.EventHandler(this.FrmPicConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPic)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lsbPic;
        private System.Windows.Forms.PictureBox picPic;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel panel1;
    }
}