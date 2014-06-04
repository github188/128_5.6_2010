namespace KJ128NMainRun.admin
{
    partial class A_frmAddUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_frmAddUser));
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.labMessage = new System.Windows.Forms.Label();
            this.labTT = new System.Windows.Forms.Label();
            this.gb_AddUser = new System.Windows.Forms.GroupBox();
            this.cmbUserGroup = new KJ128WindowsLibrary.ZzhaComBox();
            this.txtRemark = new Shine.ShineTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chbUserEnable = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCheckPassword = new Shine.ShineTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new Shine.ShineTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsername = new Shine.ShineTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gb_AddUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(320, 230);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(56, 23);
            this.btnReturn.TabIndex = 21;
            this.btnReturn.Text = "返回";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(258, 230);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(56, 23);
            this.btnReset.TabIndex = 20;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(196, 230);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.ForeColor = System.Drawing.Color.Black;
            this.labMessage.Location = new System.Drawing.Point(49, 216);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(53, 12);
            this.labMessage.TabIndex = 18;
            this.labMessage.Text = "保存成功";
            this.labMessage.Visible = false;
            // 
            // labTT
            // 
            this.labTT.AutoSize = true;
            this.labTT.Location = new System.Drawing.Point(10, 216);
            this.labTT.Name = "labTT";
            this.labTT.Size = new System.Drawing.Size(41, 12);
            this.labTT.TabIndex = 17;
            this.labTT.Text = "提示：";
            // 
            // gb_AddUser
            // 
            this.gb_AddUser.Controls.Add(this.cmbUserGroup);
            this.gb_AddUser.Controls.Add(this.txtRemark);
            this.gb_AddUser.Controls.Add(this.label9);
            this.gb_AddUser.Controls.Add(this.chbUserEnable);
            this.gb_AddUser.Controls.Add(this.label10);
            this.gb_AddUser.Controls.Add(this.label7);
            this.gb_AddUser.Controls.Add(this.label8);
            this.gb_AddUser.Controls.Add(this.txtCheckPassword);
            this.gb_AddUser.Controls.Add(this.label5);
            this.gb_AddUser.Controls.Add(this.label6);
            this.gb_AddUser.Controls.Add(this.txtPassword);
            this.gb_AddUser.Controls.Add(this.label3);
            this.gb_AddUser.Controls.Add(this.label4);
            this.gb_AddUser.Controls.Add(this.txtUsername);
            this.gb_AddUser.Controls.Add(this.label2);
            this.gb_AddUser.Controls.Add(this.label1);
            this.gb_AddUser.Controls.Add(this.pictureBox1);
            this.gb_AddUser.Location = new System.Drawing.Point(12, 12);
            this.gb_AddUser.Name = "gb_AddUser";
            this.gb_AddUser.Size = new System.Drawing.Size(364, 187);
            this.gb_AddUser.TabIndex = 22;
            this.gb_AddUser.TabStop = false;
            // 
            // cmbUserGroup
            // 
            this.cmbUserGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserGroup.FormattingEnabled = true;
            this.cmbUserGroup.Location = new System.Drawing.Point(245, 92);
            this.cmbUserGroup.Name = "cmbUserGroup";
            this.cmbUserGroup.Size = new System.Drawing.Size(100, 20);
            this.cmbUserGroup.TabIndex = 34;
            this.cmbUserGroup.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("cmbUserGroup.Values")));
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(54, 150);
            this.txtRemark.MaxLength = 200;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(304, 21);
            this.txtRemark.TabIndex = 33;
            this.txtRemark.TextType = Shine.TextType.WithOutChar;
            this.txtRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemark_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 32;
            this.label9.Text = "备注：";
            // 
            // chbUserEnable
            // 
            this.chbUserEnable.AutoSize = true;
            this.chbUserEnable.Checked = true;
            this.chbUserEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbUserEnable.Location = new System.Drawing.Point(182, 121);
            this.chbUserEnable.Name = "chbUserEnable";
            this.chbUserEnable.Size = new System.Drawing.Size(96, 16);
            this.chbUserEnable.TabIndex = 31;
            this.chbUserEnable.Text = "用户是否可用";
            this.chbUserEnable.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(169, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 30;
            this.label10.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(180, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 29;
            this.label7.Text = "用 户 组：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(169, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 28;
            this.label8.Text = "*";
            // 
            // txtCheckPassword
            // 
            this.txtCheckPassword.Location = new System.Drawing.Point(245, 67);
            this.txtCheckPassword.MaxLength = 16;
            this.txtCheckPassword.Name = "txtCheckPassword";
            this.txtCheckPassword.PasswordChar = '*';
            this.txtCheckPassword.Size = new System.Drawing.Size(100, 21);
            this.txtCheckPassword.TabIndex = 27;
            this.txtCheckPassword.TextType = Shine.TextType.WithOutChar;
            this.txtCheckPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCheckPassword_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "确认密码：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(169, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "*";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(245, 42);
            this.txtPassword.MaxLength = 16;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 21);
            this.txtPassword.TabIndex = 24;
            this.txtPassword.TextType = Shine.TextType.WithOutChar;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "密    码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(169, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "*";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(245, 18);
            this.txtUsername.MaxLength = 20;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 21);
            this.txtUsername.TabIndex = 21;
            this.txtUsername.TextType = Shine.TextType.WithOutChar;
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "用 户 名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(169, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "*";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(9, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 120);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // A_frmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(385, 265);
            this.Controls.Add(this.gb_AddUser);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labMessage);
            this.Controls.Add(this.labTT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "A_frmAddUser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户";
            this.Load += new System.EventHandler(this.A_frmAddUser_Load);
            this.gb_AddUser.ResumeLayout(false);
            this.gb_AddUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Label labTT;
        private System.Windows.Forms.GroupBox gb_AddUser;
        private KJ128WindowsLibrary.ZzhaComBox cmbUserGroup;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chbUserEnable;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Shine.ShineTextBox txtRemark;
        private Shine.ShineTextBox txtCheckPassword;
        private Shine.ShineTextBox txtPassword;
        private Shine.ShineTextBox txtUsername;
    }
}