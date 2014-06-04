namespace KJ128NMainRun
{
    partial class A_FrmLogin
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
            this.components = new System.ComponentModel.Container();
            this.chIsMemorize = new System.Windows.Forms.CheckBox();
            this.cbx_UserName = new System.Windows.Forms.ComboBox();
            this.txt_UserPassWord = new Shine.ShineTextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pbLogin = new System.Windows.Forms.Button();
            this.pbExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chIsMemorize
            // 
            this.chIsMemorize.AutoSize = true;
            this.chIsMemorize.BackColor = System.Drawing.Color.Transparent;
            this.chIsMemorize.Location = new System.Drawing.Point(141, 99);
            this.chIsMemorize.Name = "chIsMemorize";
            this.chIsMemorize.Size = new System.Drawing.Size(84, 16);
            this.chIsMemorize.TabIndex = 2;
            this.chIsMemorize.Text = "系统强验证";
            this.chIsMemorize.UseVisualStyleBackColor = false;
            this.chIsMemorize.MouseLeave += new System.EventHandler(this.chIsMemorize_MouseLeave);
            this.chIsMemorize.MouseEnter += new System.EventHandler(this.chIsMemorize_MouseEnter);
            // 
            // cbx_UserName
            // 
            this.cbx_UserName.FormattingEnabled = true;
            this.cbx_UserName.Location = new System.Drawing.Point(102, 29);
            this.cbx_UserName.Name = "cbx_UserName";
            this.cbx_UserName.Size = new System.Drawing.Size(123, 20);
            this.cbx_UserName.TabIndex = 0;
            // 
            // txt_UserPassWord
            // 
            this.txt_UserPassWord.Location = new System.Drawing.Point(102, 66);
            this.txt_UserPassWord.MaxLength = 16;
            this.txt_UserPassWord.Name = "txt_UserPassWord";
            this.txt_UserPassWord.PasswordChar = '*';
            this.txt_UserPassWord.Size = new System.Drawing.Size(122, 21);
            this.txt_UserPassWord.TabIndex = 1;
            this.txt_UserPassWord.TextType = Shine.TextType.WithOutChar;
            this.txt_UserPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_UserPassWord_KeyDown);
            this.txt_UserPassWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_UserPassWord_KeyPress);
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "信息提示";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "密  码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(26, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(26, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "*";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMessage);
            this.groupBox1.Controls.Add(this.cbx_UserName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_UserPassWord);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chIsMemorize);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 139);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblMessage.Location = new System.Drawing.Point(24, 121);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(227, 12);
            this.lblMessage.TabIndex = 7;
            this.lblMessage.Text = "选中后在配置操作中需输入密码进行验证!";
            // 
            // pbLogin
            // 
            this.pbLogin.Location = new System.Drawing.Point(53, 148);
            this.pbLogin.Name = "pbLogin";
            this.pbLogin.Size = new System.Drawing.Size(50, 23);
            this.pbLogin.TabIndex = 3;
            this.pbLogin.Text = "确定";
            this.pbLogin.UseVisualStyleBackColor = true;
            this.pbLogin.Click += new System.EventHandler(this.pbLogin_Click);
            // 
            // pbExit
            // 
            this.pbExit.Location = new System.Drawing.Point(182, 148);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(50, 23);
            this.pbExit.TabIndex = 4;
            this.pbExit.Text = "取消";
            this.pbExit.UseVisualStyleBackColor = true;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // A_FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 178);
            this.ControlBox = false;
            this.Controls.Add(this.pbExit);
            this.Controls.Add(this.pbLogin);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "A_FrmLogin";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "登录";
            this.Shown += new System.EventHandler(this.A_FrmLogin_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chIsMemorize;
        private System.Windows.Forms.ComboBox cbx_UserName;
        private Shine.ShineTextBox txt_UserPassWord;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button pbLogin;
        private System.Windows.Forms.Button pbExit;
        private System.Windows.Forms.Label lblMessage;
    }
}