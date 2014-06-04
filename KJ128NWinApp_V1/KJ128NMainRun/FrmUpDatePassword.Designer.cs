namespace KJ128NMainRun
{
    partial class FrmUpDatePassword
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
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Login = new System.Windows.Forms.Button();
            this.txtNewPassWord1 = new Shine.ShineTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_UserName = new Shine.ShineTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewPassWord2 = new Shine.ShineTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOldPassWord1 = new Shine.ShineTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(159, 169);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(70, 23);
            this.btn_Exit.TabIndex = 11;
            this.btn_Exit.Text = "取  消";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(22, 169);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(70, 23);
            this.btn_Login.TabIndex = 10;
            this.btn_Login.Text = "修  改";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // txtNewPassWord1
            // 
            this.txtNewPassWord1.Location = new System.Drawing.Point(117, 96);
            this.txtNewPassWord1.MaxLength = 16;
            this.txtNewPassWord1.Name = "txtNewPassWord1";
            this.txtNewPassWord1.PasswordChar = '*';
            this.txtNewPassWord1.Size = new System.Drawing.Size(100, 21);
            this.txtNewPassWord1.TabIndex = 9;
            this.txtNewPassWord1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewPassWord1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "新密码：";
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(117, 28);
            this.txt_UserName.MaxLength = 20;
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(100, 21);
            this.txt_UserName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "用户名：";
            // 
            // txtNewPassWord2
            // 
            this.txtNewPassWord2.Location = new System.Drawing.Point(117, 131);
            this.txtNewPassWord2.MaxLength = 16;
            this.txtNewPassWord2.Name = "txtNewPassWord2";
            this.txtNewPassWord2.PasswordChar = '*';
            this.txtNewPassWord2.Size = new System.Drawing.Size(100, 21);
            this.txtNewPassWord2.TabIndex = 13;
            this.txtNewPassWord2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewPassWord2_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "确认新密码：";
            // 
            // txtOldPassWord1
            // 
            this.txtOldPassWord1.Location = new System.Drawing.Point(117, 61);
            this.txtOldPassWord1.MaxLength = 16;
            this.txtOldPassWord1.Name = "txtOldPassWord1";
            this.txtOldPassWord1.PasswordChar = '*';
            this.txtOldPassWord1.Size = new System.Drawing.Size(100, 21);
            this.txtOldPassWord1.TabIndex = 1;
            this.txtOldPassWord1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOldPassWord1_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "旧密码：";
            // 
            // FrmUpDatePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(251, 214);
            this.Controls.Add(this.txtOldPassWord1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNewPassWord2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.txtNewPassWord1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_UserName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUpDatePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.TextBox txtNewPassWord1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewPassWord2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOldPassWord1;
        private System.Windows.Forms.Label label4;
    }
}