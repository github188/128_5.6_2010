namespace KJ128NMainRun.IpConfig
{
    partial class Frm_Station_Add_new
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
            this.textBox_place = new System.Windows.Forms.TextBox();
            this.comboBox_station = new System.Windows.Forms.ComboBox();
            this.textBox_ipweizhi = new System.Windows.Forms.TextBox();
            this.comboBox_ip = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bCPl_save = new System.Windows.Forms.Button();
            this.bCPl_return = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labMessage = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_place
            // 
            this.textBox_place.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_place.Location = new System.Drawing.Point(115, 147);
            this.textBox_place.Name = "textBox_place";
            this.textBox_place.ReadOnly = true;
            this.textBox_place.Size = new System.Drawing.Size(206, 21);
            this.textBox_place.TabIndex = 18;
            // 
            // comboBox_station
            // 
            this.comboBox_station.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox_station.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_station.FormattingEnabled = true;
            this.comboBox_station.Location = new System.Drawing.Point(115, 110);
            this.comboBox_station.Name = "comboBox_station";
            this.comboBox_station.Size = new System.Drawing.Size(206, 20);
            this.comboBox_station.TabIndex = 17;
            this.comboBox_station.SelectedIndexChanged += new System.EventHandler(this.comboBox_station_SelectedIndexChanged);
            // 
            // textBox_ipweizhi
            // 
            this.textBox_ipweizhi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_ipweizhi.Location = new System.Drawing.Point(115, 71);
            this.textBox_ipweizhi.Name = "textBox_ipweizhi";
            this.textBox_ipweizhi.ReadOnly = true;
            this.textBox_ipweizhi.Size = new System.Drawing.Size(206, 21);
            this.textBox_ipweizhi.TabIndex = 16;
            // 
            // comboBox_ip
            // 
            this.comboBox_ip.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox_ip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ip.FormattingEnabled = true;
            this.comboBox_ip.Location = new System.Drawing.Point(115, 34);
            this.comboBox_ip.Name = "comboBox_ip";
            this.comboBox_ip.Size = new System.Drawing.Size(206, 20);
            this.comboBox_ip.TabIndex = 15;
            this.comboBox_ip.SelectedIndexChanged += new System.EventHandler(this.comboBox_ip_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "分站安装位置：";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "分  站  号：";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "IP安装位置：";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "IP  地  址：";
            // 
            // bCPl_save
            // 
            this.bCPl_save.Location = new System.Drawing.Point(167, 233);
            this.bCPl_save.Name = "bCPl_save";
            this.bCPl_save.Size = new System.Drawing.Size(75, 23);
            this.bCPl_save.TabIndex = 22;
            this.bCPl_save.Text = "保存";
            this.bCPl_save.UseVisualStyleBackColor = true;
            this.bCPl_save.Click += new System.EventHandler(this.bCPl_save_Click);
            // 
            // bCPl_return
            // 
            this.bCPl_return.Location = new System.Drawing.Point(258, 233);
            this.bCPl_return.Name = "bCPl_return";
            this.bCPl_return.Size = new System.Drawing.Size(75, 23);
            this.bCPl_return.TabIndex = 23;
            this.bCPl_return.Text = "返回";
            this.bCPl_return.UseVisualStyleBackColor = true;
            this.bCPl_return.Click += new System.EventHandler(this.bCPl_return_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_ipweizhi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_place);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_station);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox_ip);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 186);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "提示：";
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.Location = new System.Drawing.Point(76, 212);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(65, 12);
            this.labMessage.TabIndex = 26;
            this.labMessage.Text = "labMessage";
            this.labMessage.Visible = false;
            // 
            // Frm_Station_Add_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 268);
            this.Controls.Add(this.labMessage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bCPl_return);
            this.Controls.Add(this.bCPl_save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Station_Add_new";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frm_Station_Add_new";
            this.Load += new System.EventHandler(this.Frm_Station_Add_new_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_place;
        private System.Windows.Forms.ComboBox comboBox_station;
        private System.Windows.Forms.TextBox textBox_ipweizhi;
        private System.Windows.Forms.ComboBox comboBox_ip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bCPl_save;
        private System.Windows.Forms.Button bCPl_return;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labMessage;
    }
}