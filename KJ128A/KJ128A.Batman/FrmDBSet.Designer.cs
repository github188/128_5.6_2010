namespace KJ128A.Batman
{
    partial class FrmDBSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDBSet));
            this.pnlStart = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbbServername = new System.Windows.Forms.TextBox();
            this.btnSelectSQLName = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mimaBox = new System.Windows.Forms.TextBox();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.label_loginID = new System.Windows.Forms.Label();
            this.lable_loginName = new System.Windows.Forms.Label();
            this.sql_rb = new System.Windows.Forms.RadioButton();
            this.win_rb = new System.Windows.Forms.RadioButton();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCommit = new System.Windows.Forms.Button();
            this.pnlNext = new System.Windows.Forms.Panel();
            this.btnprv = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataBaseName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ltbDataBaseName = new System.Windows.Forms.ListBox();
            this.pnlStart.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlNext.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlStart
            // 
            this.pnlStart.Controls.Add(this.lblMessage);
            this.pnlStart.Controls.Add(this.groupBox2);
            this.pnlStart.Controls.Add(this.groupBox1);
            this.pnlStart.Controls.Add(this.btnNext);
            this.pnlStart.Controls.Add(this.btnCommit);
            this.pnlStart.Location = new System.Drawing.Point(12, 12);
            this.pnlStart.Name = "pnlStart";
            this.pnlStart.Size = new System.Drawing.Size(327, 301);
            this.pnlStart.TabIndex = 13;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(3, 260);
            this.lblMessage.MaximumSize = new System.Drawing.Size(150, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(149, 24);
            this.lblMessage.TabIndex = 21;
            this.lblMessage.Text = "正在验证, 这个过程可能将持续几十秒，请等待。。。";
            this.lblMessage.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbbServername);
            this.groupBox2.Controls.Add(this.btnSelectSQLName);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(14, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 83);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // cbbServername
            // 
            this.cbbServername.Location = new System.Drawing.Point(137, 15);
            this.cbbServername.Name = "cbbServername";
            this.cbbServername.ReadOnly = true;
            this.cbbServername.Size = new System.Drawing.Size(118, 21);
            this.cbbServername.TabIndex = 8;
            // 
            // btnSelectSQLName
            // 
            this.btnSelectSQLName.Location = new System.Drawing.Point(261, 15);
            this.btnSelectSQLName.Name = "btnSelectSQLName";
            this.btnSelectSQLName.Size = new System.Drawing.Size(31, 23);
            this.btnSelectSQLName.TabIndex = 7;
            this.btnSelectSQLName.Text = "...";
            this.btnSelectSQLName.UseVisualStyleBackColor = true;
            this.btnSelectSQLName.Click += new System.EventHandler(this.btnSelectSQLName_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 50);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(51, 50);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(204, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "如果SQL Server已停止，则启动它";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "SQL Server(&S):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mimaBox);
            this.groupBox1.Controls.Add(this.loginBox);
            this.groupBox1.Controls.Add(this.label_loginID);
            this.groupBox1.Controls.Add(this.lable_loginName);
            this.groupBox1.Controls.Add(this.sql_rb);
            this.groupBox1.Controls.Add(this.win_rb);
            this.groupBox1.Location = new System.Drawing.Point(16, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 126);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接使用：";
            // 
            // mimaBox
            // 
            this.mimaBox.Location = new System.Drawing.Point(135, 94);
            this.mimaBox.Name = "mimaBox";
            this.mimaBox.PasswordChar = '*';
            this.mimaBox.Size = new System.Drawing.Size(155, 21);
            this.mimaBox.TabIndex = 5;
            this.mimaBox.TextChanged += new System.EventHandler(this.mimaBox_TextChanged);
            // 
            // loginBox
            // 
            this.loginBox.Location = new System.Drawing.Point(135, 67);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(155, 21);
            this.loginBox.TabIndex = 4;
            this.loginBox.TextChanged += new System.EventHandler(this.loginBox_TextChanged);
            // 
            // label_loginID
            // 
            this.label_loginID.AutoSize = true;
            this.label_loginID.Location = new System.Drawing.Point(53, 103);
            this.label_loginID.Name = "label_loginID";
            this.label_loginID.Size = new System.Drawing.Size(41, 12);
            this.label_loginID.TabIndex = 3;
            this.label_loginID.Text = "密码：";
            // 
            // lable_loginName
            // 
            this.lable_loginName.AutoSize = true;
            this.lable_loginName.Location = new System.Drawing.Point(53, 76);
            this.lable_loginName.Name = "lable_loginName";
            this.lable_loginName.Size = new System.Drawing.Size(53, 12);
            this.lable_loginName.TabIndex = 2;
            this.lable_loginName.Text = "登录名：";
            // 
            // sql_rb
            // 
            this.sql_rb.AutoSize = true;
            this.sql_rb.Location = new System.Drawing.Point(22, 41);
            this.sql_rb.Name = "sql_rb";
            this.sql_rb.Size = new System.Drawing.Size(131, 16);
            this.sql_rb.TabIndex = 1;
            this.sql_rb.TabStop = true;
            this.sql_rb.Text = "SQL Server身份验证";
            this.sql_rb.UseVisualStyleBackColor = true;
            this.sql_rb.CheckedChanged += new System.EventHandler(this.sql_rb_CheckedChanged);
            // 
            // win_rb
            // 
            this.win_rb.AutoSize = true;
            this.win_rb.Checked = true;
            this.win_rb.Location = new System.Drawing.Point(22, 19);
            this.win_rb.Name = "win_rb";
            this.win_rb.Size = new System.Drawing.Size(113, 16);
            this.win_rb.TabIndex = 0;
            this.win_rb.TabStop = true;
            this.win_rb.Text = "Windows身份验证";
            this.win_rb.UseVisualStyleBackColor = true;
            this.win_rb.CheckedChanged += new System.EventHandler(this.win_rb_CheckedChanged);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(252, 260);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(60, 25);
            this.btnNext.TabIndex = 14;
            this.btnNext.Text = "下一步";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(168, 260);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(60, 25);
            this.btnCommit.TabIndex = 13;
            this.btnCommit.Text = "验证";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // pnlNext
            // 
            this.pnlNext.Controls.Add(this.btnprv);
            this.pnlNext.Controls.Add(this.label2);
            this.pnlNext.Controls.Add(this.txtDataBaseName);
            this.pnlNext.Controls.Add(this.btnSave);
            this.pnlNext.Controls.Add(this.groupBox3);
            this.pnlNext.Location = new System.Drawing.Point(12, 12);
            this.pnlNext.Name = "pnlNext";
            this.pnlNext.Size = new System.Drawing.Size(327, 301);
            this.pnlNext.TabIndex = 14;
            // 
            // btnprv
            // 
            this.btnprv.Location = new System.Drawing.Point(165, 260);
            this.btnprv.Name = "btnprv";
            this.btnprv.Size = new System.Drawing.Size(60, 25);
            this.btnprv.TabIndex = 15;
            this.btnprv.Text = "上一步";
            this.btnprv.UseVisualStyleBackColor = true;
            this.btnprv.Click += new System.EventHandler(this.btnprv_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "请选择数据库：";
            // 
            // txtDataBaseName
            // 
            this.txtDataBaseName.Location = new System.Drawing.Point(142, 34);
            this.txtDataBaseName.Name = "txtDataBaseName";
            this.txtDataBaseName.ReadOnly = true;
            this.txtDataBaseName.Size = new System.Drawing.Size(166, 21);
            this.txtDataBaseName.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(246, 260);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "完成";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ltbDataBaseName);
            this.groupBox3.Location = new System.Drawing.Point(24, 63);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(290, 191);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据库集合";
            // 
            // ltbDataBaseName
            // 
            this.ltbDataBaseName.FormattingEnabled = true;
            this.ltbDataBaseName.ItemHeight = 12;
            this.ltbDataBaseName.Location = new System.Drawing.Point(6, 13);
            this.ltbDataBaseName.Name = "ltbDataBaseName";
            this.ltbDataBaseName.Size = new System.Drawing.Size(278, 172);
            this.ltbDataBaseName.TabIndex = 0;
            this.ltbDataBaseName.Click += new System.EventHandler(this.ltbDataBaseName_Click);
            // 
            // FrmDBSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 307);
            this.Controls.Add(this.pnlNext);
            this.Controls.Add(this.pnlStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDBSet";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库配置";
            this.Load += new System.EventHandler(this.FrmDBSet_Load);
            this.pnlStart.ResumeLayout(false);
            this.pnlStart.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlNext.ResumeLayout(false);
            this.pnlNext.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox mimaBox;
        private System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.Label label_loginID;
        private System.Windows.Forms.Label lable_loginName;
        private System.Windows.Forms.RadioButton sql_rb;
        private System.Windows.Forms.RadioButton win_rb;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Panel pnlNext;
        private System.Windows.Forms.TextBox txtDataBaseName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox ltbDataBaseName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnprv;
        private System.Windows.Forms.Button btnSelectSQLName;
        private System.Windows.Forms.TextBox cbbServername;
        private System.Windows.Forms.Label lblMessage;

    }
}