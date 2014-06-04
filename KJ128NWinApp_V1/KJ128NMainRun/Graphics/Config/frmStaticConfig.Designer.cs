namespace KJ128NMainRun.Graphics
{
    partial class frmStaticConfig
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
            this.hsbWidth = new System.Windows.Forms.HScrollBar();
            this.hsbHeight = new System.Windows.Forms.HScrollBar();
            this.labWidth = new System.Windows.Forms.Label();
            this.labHeight = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hsbWidth
            // 
            this.hsbWidth.Location = new System.Drawing.Point(65, 9);
            this.hsbWidth.Maximum = 119;
            this.hsbWidth.Minimum = 10;
            this.hsbWidth.Name = "hsbWidth";
            this.hsbWidth.Size = new System.Drawing.Size(157, 17);
            this.hsbWidth.TabIndex = 0;
            this.hsbWidth.Value = 10;
            this.hsbWidth.ValueChanged += new System.EventHandler(this.hsbWidth_ValueChanged);
            // 
            // hsbHeight
            // 
            this.hsbHeight.Location = new System.Drawing.Point(65, 41);
            this.hsbHeight.Maximum = 119;
            this.hsbHeight.Minimum = 10;
            this.hsbHeight.Name = "hsbHeight";
            this.hsbHeight.Size = new System.Drawing.Size(157, 17);
            this.hsbHeight.TabIndex = 1;
            this.hsbHeight.Value = 10;
            this.hsbHeight.ValueChanged += new System.EventHandler(this.hsbHeight_ValueChanged);
            // 
            // labWidth
            // 
            this.labWidth.AutoSize = true;
            this.labWidth.Location = new System.Drawing.Point(12, 13);
            this.labWidth.Name = "labWidth";
            this.labWidth.Size = new System.Drawing.Size(23, 12);
            this.labWidth.TabIndex = 2;
            this.labWidth.Text = "宽:";
            // 
            // labHeight
            // 
            this.labHeight.AutoSize = true;
            this.labHeight.Location = new System.Drawing.Point(12, 44);
            this.labHeight.Name = "labHeight";
            this.labHeight.Size = new System.Drawing.Size(23, 12);
            this.labHeight.TabIndex = 3;
            this.labHeight.Text = "高:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(32, 72);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(126, 72);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmStaticConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 109);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labHeight);
            this.Controls.Add(this.labWidth);
            this.Controls.Add(this.hsbHeight);
            this.Controls.Add(this.hsbWidth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmStaticConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图形图像设置";
            this.Load += new System.EventHandler(this.frmStaticConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar hsbWidth;
        private System.Windows.Forms.HScrollBar hsbHeight;
        private System.Windows.Forms.Label labWidth;
        private System.Windows.Forms.Label labHeight;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

    }
}