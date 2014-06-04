namespace KJ128NMainRun.IpConfig
{
    partial class Frm_Ip_Config_new
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
            this.textBox_ipport = new Shine.ShineTextBox();
            this.textBox_ip = new Shine.ShineTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_azwz = new Shine.ShineTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCaptionPanel_save = new System.Windows.Forms.Button();
            this.buttonCaptionPanel_fanhui = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labMessage = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_ipport
            // 
            this.textBox_ipport.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox_ipport.Location = new System.Drawing.Point(94, 103);
            this.textBox_ipport.MaxLength = 5;
            this.textBox_ipport.Name = "textBox_ipport";
            this.textBox_ipport.Size = new System.Drawing.Size(175, 21);
            this.textBox_ipport.TabIndex = 14;
            this.textBox_ipport.TextType = Shine.TextType.Number;
            this.textBox_ipport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ipport_KeyPress);
            // 
            // textBox_ip
            // 
            this.textBox_ip.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox_ip.Location = new System.Drawing.Point(94, 67);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(175, 21);
            this.textBox_ip.TabIndex = 13;
            this.textBox_ip.TextType = Shine.TextType.WithOutChar;
            this.textBox_ip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ip_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "IP 端 口：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "IP 地 址：";
            // 
            // textBox_azwz
            // 
            this.textBox_azwz.Location = new System.Drawing.Point(94, 24);
            this.textBox_azwz.MaxLength = 20;
            this.textBox_azwz.Name = "textBox_azwz";
            this.textBox_azwz.Size = new System.Drawing.Size(175, 21);
            this.textBox_azwz.TabIndex = 10;
            this.textBox_azwz.TextType = Shine.TextType.WithOutChar;
            this.textBox_azwz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_azwz_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "安装位置：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // buttonCaptionPanel_save
            // 
            this.buttonCaptionPanel_save.Location = new System.Drawing.Point(145, 198);
            this.buttonCaptionPanel_save.Name = "buttonCaptionPanel_save";
            this.buttonCaptionPanel_save.Size = new System.Drawing.Size(75, 23);
            this.buttonCaptionPanel_save.TabIndex = 19;
            this.buttonCaptionPanel_save.Text = "保存";
            this.buttonCaptionPanel_save.UseVisualStyleBackColor = true;
            this.buttonCaptionPanel_save.Click += new System.EventHandler(this.buttonCaptionPanel_save_Click);
            // 
            // buttonCaptionPanel_fanhui
            // 
            this.buttonCaptionPanel_fanhui.Location = new System.Drawing.Point(236, 198);
            this.buttonCaptionPanel_fanhui.Name = "buttonCaptionPanel_fanhui";
            this.buttonCaptionPanel_fanhui.Size = new System.Drawing.Size(75, 23);
            this.buttonCaptionPanel_fanhui.TabIndex = 20;
            this.buttonCaptionPanel_fanhui.Text = "返回";
            this.buttonCaptionPanel_fanhui.UseVisualStyleBackColor = true;
            this.buttonCaptionPanel_fanhui.Click += new System.EventHandler(this.buttonCaptionPanel_fanhui_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_azwz);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_ipport);
            this.groupBox1.Controls.Add(this.textBox_ip);
            this.groupBox1.Location = new System.Drawing.Point(25, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 149);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.Location = new System.Drawing.Point(89, 173);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(65, 12);
            this.labMessage.TabIndex = 22;
            this.labMessage.Text = "labMessage";
            this.labMessage.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "提示：";
            // 
            // Frm_Ip_Config_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 233);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labMessage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCaptionPanel_fanhui);
            this.Controls.Add(this.buttonCaptionPanel_save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Ip_Config_new";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Frm_Ip_Config_new_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCaptionPanel_save;
        private System.Windows.Forms.Button buttonCaptionPanel_fanhui;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labMessage;
        private Shine.ShineTextBox textBox_ipport;
        private Shine.ShineTextBox textBox_ip;
        private Shine.ShineTextBox textBox_azwz;
        private System.Windows.Forms.Label label5;
    }
}