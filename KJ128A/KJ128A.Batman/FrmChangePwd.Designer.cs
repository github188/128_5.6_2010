namespace KJ128A.Batman
{
    partial class FrmChangePwd
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
            this.txtOldPwd = new System.Windows.Forms.TextBox();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.txtAccPwd = new System.Windows.Forms.TextBox();
            this.lblOldPwd = new System.Windows.Forms.Label();
            this.lblNewPwd1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdatePwd = new System.Windows.Forms.Button();
            this.btnCanal = new System.Windows.Forms.Button();
            this.lblLoginName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Location = new System.Drawing.Point(92, 37);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.PasswordChar = '*';
            this.txtOldPwd.Size = new System.Drawing.Size(100, 21);
            this.txtOldPwd.TabIndex = 0;
            this.txtOldPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOldPwd_KeyPress);
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Location = new System.Drawing.Point(92, 67);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.PasswordChar = '*';
            this.txtNewPwd.Size = new System.Drawing.Size(100, 21);
            this.txtNewPwd.TabIndex = 1;
            this.txtNewPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewPwd_KeyPress);
            // 
            // txtAccPwd
            // 
            this.txtAccPwd.Location = new System.Drawing.Point(92, 97);
            this.txtAccPwd.Name = "txtAccPwd";
            this.txtAccPwd.PasswordChar = '*';
            this.txtAccPwd.Size = new System.Drawing.Size(100, 21);
            this.txtAccPwd.TabIndex = 2;
            this.txtAccPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccPwd_KeyPress);
            // 
            // lblOldPwd
            // 
            this.lblOldPwd.AutoSize = true;
            this.lblOldPwd.Location = new System.Drawing.Point(27, 40);
            this.lblOldPwd.Name = "lblOldPwd";
            this.lblOldPwd.Size = new System.Drawing.Size(59, 12);
            this.lblOldPwd.TabIndex = 3;
            this.lblOldPwd.Text = "当前密码:";
            // 
            // lblNewPwd1
            // 
            this.lblNewPwd1.AutoSize = true;
            this.lblNewPwd1.Location = new System.Drawing.Point(27, 70);
            this.lblNewPwd1.Name = "lblNewPwd1";
            this.lblNewPwd1.Size = new System.Drawing.Size(59, 12);
            this.lblNewPwd1.TabIndex = 4;
            this.lblNewPwd1.Text = "新 密 码:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "密码确认:";
            // 
            // btnUpdatePwd
            // 
            this.btnUpdatePwd.Location = new System.Drawing.Point(29, 134);
            this.btnUpdatePwd.Name = "btnUpdatePwd";
            this.btnUpdatePwd.Size = new System.Drawing.Size(75, 23);
            this.btnUpdatePwd.TabIndex = 3;
            this.btnUpdatePwd.Text = "修  改";
            this.btnUpdatePwd.UseVisualStyleBackColor = true;
            this.btnUpdatePwd.Click += new System.EventHandler(this.btnUpdatePwd_Click);
            // 
            // btnCanal
            // 
            this.btnCanal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCanal.Location = new System.Drawing.Point(117, 134);
            this.btnCanal.Name = "btnCanal";
            this.btnCanal.Size = new System.Drawing.Size(75, 23);
            this.btnCanal.TabIndex = 4;
            this.btnCanal.Text = "取  消";
            this.btnCanal.UseVisualStyleBackColor = true;
            this.btnCanal.Click += new System.EventHandler(this.btnCanal_Click);
            // 
            // lblLoginName
            // 
            this.lblLoginName.AutoSize = true;
            this.lblLoginName.Location = new System.Drawing.Point(111, 9);
            this.lblLoginName.Name = "lblLoginName";
            this.lblLoginName.Size = new System.Drawing.Size(0, 12);
            this.lblLoginName.TabIndex = 6;
            // 
            // FrmChangePwd
            // 
            this.AcceptButton = this.btnUpdatePwd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCanal;
            this.ClientSize = new System.Drawing.Size(222, 169);
            this.Controls.Add(this.lblLoginName);
            this.Controls.Add(this.btnCanal);
            this.Controls.Add(this.btnUpdatePwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNewPwd1);
            this.Controls.Add(this.lblOldPwd);
            this.Controls.Add(this.txtAccPwd);
            this.Controls.Add(this.txtNewPwd);
            this.Controls.Add(this.txtOldPwd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChangePwd";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOldPwd;
        private System.Windows.Forms.TextBox txtNewPwd;
        private System.Windows.Forms.TextBox txtAccPwd;
        private System.Windows.Forms.Label lblOldPwd;
        private System.Windows.Forms.Label lblNewPwd1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdatePwd;
        private System.Windows.Forms.Button btnCanal;
        private System.Windows.Forms.Label lblLoginName;
    }
}