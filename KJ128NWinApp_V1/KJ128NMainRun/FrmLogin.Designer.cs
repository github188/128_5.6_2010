namespace KJ128NMainRun
{
    partial class FrmLogin
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_UserPassWord = new Shine.ShineTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Login = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.cbx_UserName = new System.Windows.Forms.ComboBox();
            this.pbLogin = new System.Windows.Forms.PictureBox();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.chIsMemorize = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            this.label1.Visible = false;
            // 
            // txt_UserPassWord
            // 
            this.txt_UserPassWord.Location = new System.Drawing.Point(121, 105);
            this.txt_UserPassWord.MaxLength = 16;
            this.txt_UserPassWord.Name = "txt_UserPassWord";
            this.txt_UserPassWord.PasswordChar = '*';
            this.txt_UserPassWord.Size = new System.Drawing.Size(122, 21);
            this.txt_UserPassWord.TabIndex = 3;
            this.txt_UserPassWord.TextType = Shine.TextType.WithOutChar;
            this.txt_UserPassWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_UserPassWord_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密  码：";
            this.label2.Visible = false;
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(12, 3);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(70, 23);
            this.btn_Login.TabIndex = 4;
            this.btn_Login.Text = "登  录";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Visible = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(88, 3);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(70, 23);
            this.btn_Exit.TabIndex = 5;
            this.btn_Exit.Text = "取  消";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Visible = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // cbx_UserName
            // 
            this.cbx_UserName.FormattingEnabled = true;
            this.cbx_UserName.Location = new System.Drawing.Point(121, 78);
            this.cbx_UserName.Name = "cbx_UserName";
            this.cbx_UserName.Size = new System.Drawing.Size(123, 20);
            this.cbx_UserName.TabIndex = 6;
            // 
            // pbLogin
            // 
            this.pbLogin.BackColor = System.Drawing.Color.Transparent;
            this.pbLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLogin.Image = global::KJ128NMainRun.Properties.Resources._3;
            this.pbLogin.Location = new System.Drawing.Point(63, 161);
            this.pbLogin.Name = "pbLogin";
            this.pbLogin.Size = new System.Drawing.Size(69, 24);
            this.pbLogin.TabIndex = 7;
            this.pbLogin.TabStop = false;
            this.pbLogin.MouseLeave += new System.EventHandler(this.pbLogin_MouseLeave);
            this.pbLogin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbLogin_MouseMove);
            this.pbLogin.Click += new System.EventHandler(this.btn_Login_Click);
            this.pbLogin.MouseEnter += new System.EventHandler(this.pbLogin_MouseEnter);
            // 
            // pbExit
            // 
            this.pbExit.BackColor = System.Drawing.Color.Transparent;
            this.pbExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbExit.Image = global::KJ128NMainRun.Properties.Resources._5;
            this.pbExit.Location = new System.Drawing.Point(163, 161);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(69, 24);
            this.pbExit.TabIndex = 8;
            this.pbExit.TabStop = false;
            this.pbExit.MouseLeave += new System.EventHandler(this.pbExit_MouseLeave);
            this.pbExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbExit_MouseMove);
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // pbClose
            // 
            this.pbClose.BackColor = System.Drawing.Color.Transparent;
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = global::KJ128NMainRun.Properties.Resources._09;
            this.pbClose.Location = new System.Drawing.Point(278, 7);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(18, 18);
            this.pbClose.TabIndex = 9;
            this.pbClose.TabStop = false;
            this.pbClose.MouseLeave += new System.EventHandler(this.pbClose_MouseLeave);
            this.pbClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbClose_MouseMove);
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // chIsMemorize
            // 
            this.chIsMemorize.AutoSize = true;
            this.chIsMemorize.BackColor = System.Drawing.Color.Transparent;
            this.chIsMemorize.Location = new System.Drawing.Point(166, 132);
            this.chIsMemorize.Name = "chIsMemorize";
            this.chIsMemorize.Size = new System.Drawing.Size(84, 16);
            this.chIsMemorize.TabIndex = 10;
            this.chIsMemorize.Text = "系统强验证";
            this.chIsMemorize.UseVisualStyleBackColor = false;
            this.chIsMemorize.MouseEnter += new System.EventHandler(this.chIsMemorize_MouseEnter);
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "信息提示";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::KJ128NMainRun.Properties.Resources._01;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(299, 199);
            this.Controls.Add(this.chIsMemorize);
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.pbExit);
            this.Controls.Add(this.pbLogin);
            this.Controls.Add(this.cbx_UserName);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.txt_UserPassWord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseUp);
            this.SizeChanged += new System.EventHandler(this.FrmLogin_SizeChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.ComboBox cbx_UserName;
        private System.Windows.Forms.PictureBox pbLogin;
        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.CheckBox chIsMemorize;
        private Shine.ShineTextBox txt_UserPassWord;
        private System.Windows.Forms.ToolTip toolTip;
    }
}