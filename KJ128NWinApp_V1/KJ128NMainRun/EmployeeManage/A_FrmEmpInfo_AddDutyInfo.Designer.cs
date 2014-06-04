namespace KJ128NMainRun.EmployeeManage
{
    partial class A_FrmEmpInfo_AddDutyInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_FrmEmpInfo_AddDutyInfo));
            this.bt_Duty_Close = new System.Windows.Forms.Button();
            this.bt_Duty_Reset = new System.Windows.Forms.Button();
            this.bt_Duty_Save = new System.Windows.Forms.Button();
            this.lb_DutyTipsInfo = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.gb_AddDutyInfo = new System.Windows.Forms.GroupBox();
            this.textBox_DutyRemark = new Shine.ShineTextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label91 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.textBox_DutyName = new Shine.ShineTextBox();
            this.label94 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.comboBox_DutyClass = new System.Windows.Forms.ComboBox();
            this.gb_AddDutyInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Duty_Close
            // 
            this.bt_Duty_Close.Location = new System.Drawing.Point(319, 238);
            this.bt_Duty_Close.Name = "bt_Duty_Close";
            this.bt_Duty_Close.Size = new System.Drawing.Size(56, 23);
            this.bt_Duty_Close.TabIndex = 74;
            this.bt_Duty_Close.Text = "返回";
            this.bt_Duty_Close.UseVisualStyleBackColor = true;
            this.bt_Duty_Close.Click += new System.EventHandler(this.bt_Duty_Close_Click);
            // 
            // bt_Duty_Reset
            // 
            this.bt_Duty_Reset.Location = new System.Drawing.Point(252, 238);
            this.bt_Duty_Reset.Name = "bt_Duty_Reset";
            this.bt_Duty_Reset.Size = new System.Drawing.Size(56, 23);
            this.bt_Duty_Reset.TabIndex = 73;
            this.bt_Duty_Reset.Text = "重置";
            this.bt_Duty_Reset.UseVisualStyleBackColor = true;
            this.bt_Duty_Reset.Click += new System.EventHandler(this.bt_Duty_Reset_Click);
            // 
            // bt_Duty_Save
            // 
            this.bt_Duty_Save.Location = new System.Drawing.Point(184, 238);
            this.bt_Duty_Save.Name = "bt_Duty_Save";
            this.bt_Duty_Save.Size = new System.Drawing.Size(56, 23);
            this.bt_Duty_Save.TabIndex = 72;
            this.bt_Duty_Save.Text = "保存";
            this.bt_Duty_Save.UseVisualStyleBackColor = true;
            this.bt_Duty_Save.Click += new System.EventHandler(this.bt_Duty_Save_Click);
            // 
            // lb_DutyTipsInfo
            // 
            this.lb_DutyTipsInfo.AutoSize = true;
            this.lb_DutyTipsInfo.Location = new System.Drawing.Point(56, 222);
            this.lb_DutyTipsInfo.Name = "lb_DutyTipsInfo";
            this.lb_DutyTipsInfo.Size = new System.Drawing.Size(53, 12);
            this.lb_DutyTipsInfo.TabIndex = 71;
            this.lb_DutyTipsInfo.Text = "保存成功";
            this.lb_DutyTipsInfo.Visible = false;
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(9, 222);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(41, 12);
            this.label88.TabIndex = 70;
            this.label88.Text = "提示：";
            // 
            // gb_AddDutyInfo
            // 
            this.gb_AddDutyInfo.Controls.Add(this.textBox_DutyRemark);
            this.gb_AddDutyInfo.Controls.Add(this.pictureBox3);
            this.gb_AddDutyInfo.Controls.Add(this.label91);
            this.gb_AddDutyInfo.Controls.Add(this.label92);
            this.gb_AddDutyInfo.Controls.Add(this.textBox_DutyName);
            this.gb_AddDutyInfo.Controls.Add(this.label94);
            this.gb_AddDutyInfo.Controls.Add(this.label95);
            this.gb_AddDutyInfo.Controls.Add(this.label97);
            this.gb_AddDutyInfo.Controls.Add(this.comboBox_DutyClass);
            this.gb_AddDutyInfo.Location = new System.Drawing.Point(9, 11);
            this.gb_AddDutyInfo.Name = "gb_AddDutyInfo";
            this.gb_AddDutyInfo.Size = new System.Drawing.Size(356, 195);
            this.gb_AddDutyInfo.TabIndex = 69;
            this.gb_AddDutyInfo.TabStop = false;
            // 
            // textBox_DutyRemark
            // 
            this.textBox_DutyRemark.AcceptsReturn = true;
            this.textBox_DutyRemark.Location = new System.Drawing.Point(72, 118);
            this.textBox_DutyRemark.MaxLength = 200;
            this.textBox_DutyRemark.Multiline = true;
            this.textBox_DutyRemark.Name = "textBox_DutyRemark";
            this.textBox_DutyRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_DutyRemark.Size = new System.Drawing.Size(268, 63);
            this.textBox_DutyRemark.TabIndex = 64;
            this.textBox_DutyRemark.TextType = Shine.TextType.WithOutChar;
            this.textBox_DutyRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_DutyRemark_KeyPress);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(14, 20);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(141, 82);
            this.pictureBox3.TabIndex = 63;
            this.pictureBox3.TabStop = false;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(18, 118);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(41, 12);
            this.label91.TabIndex = 61;
            this.label91.Text = "备注：";
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(186, 28);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(41, 12);
            this.label92.TabIndex = 17;
            this.label92.Text = "名称：";
            // 
            // textBox_DutyName
            // 
            this.textBox_DutyName.Location = new System.Drawing.Point(235, 25);
            this.textBox_DutyName.MaxLength = 10;
            this.textBox_DutyName.Name = "textBox_DutyName";
            this.textBox_DutyName.Size = new System.Drawing.Size(100, 21);
            this.textBox_DutyName.TabIndex = 18;
            this.textBox_DutyName.TextType = Shine.TextType.WithOutChar;
            this.textBox_DutyName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_DutyName_KeyPress);
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.BackColor = System.Drawing.Color.Transparent;
            this.label94.ForeColor = System.Drawing.Color.Red;
            this.label94.Location = new System.Drawing.Point(176, 28);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(11, 12);
            this.label94.TabIndex = 19;
            this.label94.Text = "*";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(186, 75);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(41, 12);
            this.label95.TabIndex = 20;
            this.label95.Text = "等级：";
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.BackColor = System.Drawing.Color.Transparent;
            this.label97.ForeColor = System.Drawing.Color.Red;
            this.label97.Location = new System.Drawing.Point(176, 74);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(11, 12);
            this.label97.TabIndex = 21;
            this.label97.Text = "*";
            // 
            // comboBox_DutyClass
            // 
            this.comboBox_DutyClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DutyClass.FormattingEnabled = true;
            this.comboBox_DutyClass.Location = new System.Drawing.Point(235, 72);
            this.comboBox_DutyClass.Name = "comboBox_DutyClass";
            this.comboBox_DutyClass.Size = new System.Drawing.Size(100, 20);
            this.comboBox_DutyClass.TabIndex = 22;
            // 
            // A_FrmEmpInfo_AddDutyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(385, 272);
            this.Controls.Add(this.bt_Duty_Close);
            this.Controls.Add(this.bt_Duty_Reset);
            this.Controls.Add(this.bt_Duty_Save);
            this.Controls.Add(this.lb_DutyTipsInfo);
            this.Controls.Add(this.label88);
            this.Controls.Add(this.gb_AddDutyInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "A_FrmEmpInfo_AddDutyInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增职务信息";
            this.gb_AddDutyInfo.ResumeLayout(false);
            this.gb_AddDutyInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Duty_Close;
        private System.Windows.Forms.Button bt_Duty_Reset;
        private System.Windows.Forms.Button bt_Duty_Save;
        private System.Windows.Forms.Label lb_DutyTipsInfo;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.GroupBox gb_AddDutyInfo;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label label92;
        private Shine.ShineTextBox textBox_DutyName;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.ComboBox comboBox_DutyClass;
        private Shine.ShineTextBox textBox_DutyRemark;
    }
}