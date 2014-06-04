namespace KJ128NMainRun.EmployeeManage
{
    partial class A_FrmEmpInfo_AddCerInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_FrmEmpInfo_AddCerInfo));
            this.bt_Cer_Close = new System.Windows.Forms.Button();
            this.bt_Cer_Reset = new System.Windows.Forms.Button();
            this.bt_Cer_Save = new System.Windows.Forms.Button();
            this.lb_CerTipsInfo = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.gb_AddCerInfo = new System.Windows.Forms.GroupBox();
            this.textBox_CerVestIn = new Shine.ShineTextBox();
            this.label111 = new System.Windows.Forms.Label();
            this.textBox_CertificateRemark = new Shine.ShineTextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label121 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.textBox_CerName = new Shine.ShineTextBox();
            this.label123 = new System.Windows.Forms.Label();
            this.gb_AddCerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Cer_Close
            // 
            this.bt_Cer_Close.Location = new System.Drawing.Point(319, 238);
            this.bt_Cer_Close.Name = "bt_Cer_Close";
            this.bt_Cer_Close.Size = new System.Drawing.Size(56, 23);
            this.bt_Cer_Close.TabIndex = 74;
            this.bt_Cer_Close.Text = "返回";
            this.bt_Cer_Close.UseVisualStyleBackColor = true;
            this.bt_Cer_Close.Click += new System.EventHandler(this.bt_Cer_Close_Click);
            // 
            // bt_Cer_Reset
            // 
            this.bt_Cer_Reset.Location = new System.Drawing.Point(252, 238);
            this.bt_Cer_Reset.Name = "bt_Cer_Reset";
            this.bt_Cer_Reset.Size = new System.Drawing.Size(56, 23);
            this.bt_Cer_Reset.TabIndex = 73;
            this.bt_Cer_Reset.Text = "重置";
            this.bt_Cer_Reset.UseVisualStyleBackColor = true;
            this.bt_Cer_Reset.Click += new System.EventHandler(this.bt_Cer_Reset_Click);
            // 
            // bt_Cer_Save
            // 
            this.bt_Cer_Save.Location = new System.Drawing.Point(184, 238);
            this.bt_Cer_Save.Name = "bt_Cer_Save";
            this.bt_Cer_Save.Size = new System.Drawing.Size(56, 23);
            this.bt_Cer_Save.TabIndex = 72;
            this.bt_Cer_Save.Text = "保存";
            this.bt_Cer_Save.UseVisualStyleBackColor = true;
            this.bt_Cer_Save.Click += new System.EventHandler(this.bt_Cer_Save_Click);
            // 
            // lb_CerTipsInfo
            // 
            this.lb_CerTipsInfo.AutoSize = true;
            this.lb_CerTipsInfo.Location = new System.Drawing.Point(56, 222);
            this.lb_CerTipsInfo.Name = "lb_CerTipsInfo";
            this.lb_CerTipsInfo.Size = new System.Drawing.Size(53, 12);
            this.lb_CerTipsInfo.TabIndex = 71;
            this.lb_CerTipsInfo.Text = "保存成功";
            this.lb_CerTipsInfo.Visible = false;
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Location = new System.Drawing.Point(9, 222);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(41, 12);
            this.label110.TabIndex = 70;
            this.label110.Text = "提示：";
            // 
            // gb_AddCerInfo
            // 
            this.gb_AddCerInfo.Controls.Add(this.textBox_CerVestIn);
            this.gb_AddCerInfo.Controls.Add(this.label111);
            this.gb_AddCerInfo.Controls.Add(this.textBox_CertificateRemark);
            this.gb_AddCerInfo.Controls.Add(this.pictureBox5);
            this.gb_AddCerInfo.Controls.Add(this.label121);
            this.gb_AddCerInfo.Controls.Add(this.label122);
            this.gb_AddCerInfo.Controls.Add(this.textBox_CerName);
            this.gb_AddCerInfo.Controls.Add(this.label123);
            this.gb_AddCerInfo.Location = new System.Drawing.Point(9, 11);
            this.gb_AddCerInfo.Name = "gb_AddCerInfo";
            this.gb_AddCerInfo.Size = new System.Drawing.Size(356, 195);
            this.gb_AddCerInfo.TabIndex = 69;
            this.gb_AddCerInfo.TabStop = false;
            // 
            // textBox_CerVestIn
            // 
            this.textBox_CerVestIn.Location = new System.Drawing.Point(179, 91);
            this.textBox_CerVestIn.MaxLength = 20;
            this.textBox_CerVestIn.Name = "textBox_CerVestIn";
            this.textBox_CerVestIn.Size = new System.Drawing.Size(155, 21);
            this.textBox_CerVestIn.TabIndex = 67;
            this.textBox_CerVestIn.TextType = Shine.TextType.WithOutChar;
            this.textBox_CerVestIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_CerVestIn_KeyPress);
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(183, 67);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(65, 12);
            this.label111.TabIndex = 66;
            this.label111.Text = "发证单位：";
            // 
            // textBox_CertificateRemark
            // 
            this.textBox_CertificateRemark.AcceptsReturn = true;
            this.textBox_CertificateRemark.AcceptsTab = true;
            this.textBox_CertificateRemark.Location = new System.Drawing.Point(66, 130);
            this.textBox_CertificateRemark.Multiline = true;
            this.textBox_CertificateRemark.Name = "textBox_CertificateRemark";
            this.textBox_CertificateRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_CertificateRemark.Size = new System.Drawing.Size(268, 55);
            this.textBox_CertificateRemark.TabIndex = 64;
            this.textBox_CertificateRemark.TextType = Shine.TextType.WithOutChar;
            this.textBox_CertificateRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_CertificateRemark_KeyPress);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.Location = new System.Drawing.Point(14, 20);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(141, 97);
            this.pictureBox5.TabIndex = 63;
            this.pictureBox5.TabStop = false;
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Location = new System.Drawing.Point(17, 133);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(41, 12);
            this.label121.TabIndex = 61;
            this.label121.Text = "备注：";
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Location = new System.Drawing.Point(183, 32);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(41, 12);
            this.label122.TabIndex = 17;
            this.label122.Text = "名称：";
            // 
            // textBox_CerName
            // 
            this.textBox_CerName.Location = new System.Drawing.Point(232, 29);
            this.textBox_CerName.MaxLength = 20;
            this.textBox_CerName.Name = "textBox_CerName";
            this.textBox_CerName.Size = new System.Drawing.Size(100, 21);
            this.textBox_CerName.TabIndex = 18;
            this.textBox_CerName.TextType = Shine.TextType.WithOutChar;
            this.textBox_CerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_CerName_KeyPress);
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.BackColor = System.Drawing.Color.Transparent;
            this.label123.ForeColor = System.Drawing.Color.Red;
            this.label123.Location = new System.Drawing.Point(173, 32);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(11, 12);
            this.label123.TabIndex = 19;
            this.label123.Text = "*";
            // 
            // A_FrmEmpInfo_AddCerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(385, 272);
            this.Controls.Add(this.bt_Cer_Close);
            this.Controls.Add(this.bt_Cer_Reset);
            this.Controls.Add(this.bt_Cer_Save);
            this.Controls.Add(this.lb_CerTipsInfo);
            this.Controls.Add(this.label110);
            this.Controls.Add(this.gb_AddCerInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "A_FrmEmpInfo_AddCerInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增证书信息";
            this.gb_AddCerInfo.ResumeLayout(false);
            this.gb_AddCerInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Cer_Close;
        private System.Windows.Forms.Button bt_Cer_Reset;
        private System.Windows.Forms.Button bt_Cer_Save;
        private System.Windows.Forms.Label lb_CerTipsInfo;
        private System.Windows.Forms.Label label110;
        private System.Windows.Forms.GroupBox gb_AddCerInfo;
        private Shine.ShineTextBox textBox_CerVestIn;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label121;
        private System.Windows.Forms.Label label122;
        private Shine.ShineTextBox textBox_CerName;
        private System.Windows.Forms.Label label123;
        private Shine.ShineTextBox textBox_CertificateRemark;
    }
}