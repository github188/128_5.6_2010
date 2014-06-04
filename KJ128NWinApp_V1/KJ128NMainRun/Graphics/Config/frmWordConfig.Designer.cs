namespace KJ128NMainRun.Graphics.Config
{
    partial class frmWordConfig
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
            this.pnlEmp = new System.Windows.Forms.Panel();
            this.trvRealTime = new System.Windows.Forms.TreeView();
            this.labTitle = new System.Windows.Forms.Label();
            this.labWord = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtUserWord = new Shine.ShineTextBox();
            this.btnFont = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnUse = new System.Windows.Forms.Button();
            this.pnlEmp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEmp
            // 
            this.pnlEmp.BackColor = System.Drawing.Color.White;
            this.pnlEmp.Controls.Add(this.trvRealTime);
            this.pnlEmp.Controls.Add(this.labTitle);
            this.pnlEmp.Location = new System.Drawing.Point(6, 6);
            this.pnlEmp.Name = "pnlEmp";
            this.pnlEmp.Size = new System.Drawing.Size(187, 260);
            this.pnlEmp.TabIndex = 6;
            // 
            // trvRealTime
            // 
            this.trvRealTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trvRealTime.Location = new System.Drawing.Point(0, 23);
            this.trvRealTime.Name = "trvRealTime";
            this.trvRealTime.Size = new System.Drawing.Size(187, 237);
            this.trvRealTime.TabIndex = 1;
            this.trvRealTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvRealTime_AfterSelect);
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle.Location = new System.Drawing.Point(7, 6);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(90, 14);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "下井总人数:";
            this.labTitle.Click += new System.EventHandler(this.labTitle_Click);
            // 
            // labWord
            // 
            this.labWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labWord.ForeColor = System.Drawing.Color.Red;
            this.labWord.Location = new System.Drawing.Point(3, 17);
            this.labWord.Name = "labWord";
            this.labWord.Size = new System.Drawing.Size(306, 49);
            this.labWord.TabIndex = 7;
            this.labWord.Text = "演示文字";
            this.labWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(225, 235);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(407, 235);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtUserWord
            // 
            this.txtUserWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserWord.Location = new System.Drawing.Point(3, 17);
            this.txtUserWord.Multiline = true;
            this.txtUserWord.Name = "txtUserWord";
            this.txtUserWord.Size = new System.Drawing.Size(306, 58);
            this.txtUserWord.TabIndex = 11;
            this.txtUserWord.TextType = Shine.TextType.WithOutChar;
            this.txtUserWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserWord_KeyPress);
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(25, 20);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(75, 23);
            this.btnFont.TabIndex = 13;
            this.btnFont.Text = "字体配置";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(207, 20);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 14;
            this.btnColor.Text = "颜色配置";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFont);
            this.groupBox1.Controls.Add(this.btnColor);
            this.groupBox1.Location = new System.Drawing.Point(200, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 54);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "字体及颜色配置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labWord);
            this.groupBox2.Location = new System.Drawing.Point(200, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 69);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "演示文字";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnReset);
            this.groupBox3.Controls.Add(this.btnUse);
            this.groupBox3.Controls.Add(this.txtUserWord);
            this.groupBox3.Location = new System.Drawing.Point(200, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(312, 78);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "自定义文字";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(25, 49);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnUse
            // 
            this.btnUse.Location = new System.Drawing.Point(207, 49);
            this.btnUse.Name = "btnUse";
            this.btnUse.Size = new System.Drawing.Size(75, 23);
            this.btnUse.TabIndex = 14;
            this.btnUse.Text = "应用";
            this.btnUse.UseVisualStyleBackColor = true;
            this.btnUse.Visible = false;
            this.btnUse.Click += new System.EventHandler(this.btnUse_Click);
            // 
            // frmWordConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(524, 270);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.pnlEmp);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWordConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文字设置";
            this.Load += new System.EventHandler(this.frmWordConfig_Load);
            this.pnlEmp.ResumeLayout(false);
            this.pnlEmp.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEmp;
        private System.Windows.Forms.TreeView trvRealTime;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Label labWord;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnUse;
        private System.Windows.Forms.Button btnReset;
        private Shine.ShineTextBox txtUserWord;
    }
}