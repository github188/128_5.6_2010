namespace KJ128NMainRun
{
    partial class A_FrmExit
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_CloseCom = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbExit = new System.Windows.Forms.Button();
            this.pbLogin = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_CloseCom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cb_CloseCom
            // 
            this.cb_CloseCom.AutoSize = true;
            this.cb_CloseCom.Location = new System.Drawing.Point(51, 63);
            this.cb_CloseCom.Name = "cb_CloseCom";
            this.cb_CloseCom.Size = new System.Drawing.Size(120, 16);
            this.cb_CloseCom.TabIndex = 1;
            this.cb_CloseCom.Text = "同时关闭通讯程序";
            this.cb_CloseCom.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "确实要关闭KJ128A系统？";
            // 
            // pbExit
            // 
            this.pbExit.Location = new System.Drawing.Point(171, 130);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(50, 23);
            this.pbExit.TabIndex = 6;
            this.pbExit.Text = "取消";
            this.pbExit.UseVisualStyleBackColor = true;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // pbLogin
            // 
            this.pbLogin.Location = new System.Drawing.Point(35, 130);
            this.pbLogin.Name = "pbLogin";
            this.pbLogin.Size = new System.Drawing.Size(50, 23);
            this.pbLogin.TabIndex = 5;
            this.pbLogin.Text = "确定";
            this.pbLogin.UseVisualStyleBackColor = true;
            this.pbLogin.Click += new System.EventHandler(this.pbLogin_Click);
            // 
            // A_FrmExit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 169);
            this.ControlBox = false;
            this.Controls.Add(this.pbExit);
            this.Controls.Add(this.pbLogin);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "A_FrmExit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "关闭";
            this.Load += new System.EventHandler(this.A_FrmExit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_CloseCom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button pbExit;
        private System.Windows.Forms.Button pbLogin;
    }
}