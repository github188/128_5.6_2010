namespace KJ128A.Batman
{
    partial class FrmParams
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
            this.gbStart = new System.Windows.Forms.GroupBox();
            this.checkBox_quanxian = new System.Windows.Forms.CheckBox();
            this.button_save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gbStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbStart
            // 
            this.gbStart.Controls.Add(this.label1);
            this.gbStart.Controls.Add(this.button_save);
            this.gbStart.Controls.Add(this.checkBox_quanxian);
            this.gbStart.Location = new System.Drawing.Point(12, 12);
            this.gbStart.Name = "gbStart";
            this.gbStart.Size = new System.Drawing.Size(442, 200);
            this.gbStart.TabIndex = 0;
            this.gbStart.TabStop = false;
            this.gbStart.Text = "启动参数设置";
            // 
            // checkBox_quanxian
            // 
            this.checkBox_quanxian.AutoSize = true;
            this.checkBox_quanxian.Location = new System.Drawing.Point(18, 20);
            this.checkBox_quanxian.Name = "checkBox_quanxian";
            this.checkBox_quanxian.Size = new System.Drawing.Size(252, 16);
            this.checkBox_quanxian.TabIndex = 0;
            this.checkBox_quanxian.Text = "退出本程序时检查用户是否有权限退出操作";
            this.checkBox_quanxian.UseVisualStyleBackColor = true;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(361, 171);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 1;
            this.button_save.Text = "确定";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // FrmParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 246);
            this.Controls.Add(this.gbStart);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmParams";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "参数设置";
            this.gbStart.ResumeLayout(false);
            this.gbStart.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbStart;
        private System.Windows.Forms.CheckBox checkBox_quanxian;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Label label1;
    }
}