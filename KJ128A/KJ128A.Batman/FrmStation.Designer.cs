namespace KJ128A.Batman
{
    partial class FrmStation
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
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button_save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_min = new System.Windows.Forms.TextBox();
            this.textBox_max = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_didian = new System.Windows.Forms.TextBox();
            this.textBox_lianxi = new System.Windows.Forms.TextBox();
            this.comboBox_leixing = new System.Windows.Forms.ComboBox();
            this.checkBox01 = new System.Windows.Forms.CheckBox();
            this.checkBox02 = new System.Windows.Forms.CheckBox();
            this.checkBox03 = new System.Windows.Forms.CheckBox();
            this.checkBox04 = new System.Windows.Forms.CheckBox();
            this.checkBox05 = new System.Windows.Forms.CheckBox();
            this.checkBox06 = new System.Windows.Forms.CheckBox();
            this.checkBox07 = new System.Windows.Forms.CheckBox();
            this.checkBox08 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "添加新的分站";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(104, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "启用批量添加";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(206, -2);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 2;
            this.button_save.Text = "存储";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "分站地址";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "分站安装地点";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "分站联系电话";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "分站类型";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "分站分组号";
            // 
            // textBox_min
            // 
            this.textBox_min.Location = new System.Drawing.Point(95, 45);
            this.textBox_min.MaxLength = 1;
            this.textBox_min.Name = "textBox_min";
            this.textBox_min.Size = new System.Drawing.Size(48, 21);
            this.textBox_min.TabIndex = 8;
            this.textBox_min.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_min_KeyPress);
            // 
            // textBox_max
            // 
            this.textBox_max.Location = new System.Drawing.Point(174, 45);
            this.textBox_max.MaxLength = 999;
            this.textBox_max.Name = "textBox_max";
            this.textBox_max.Size = new System.Drawing.Size(39, 21);
            this.textBox_max.TabIndex = 9;
            this.textBox_max.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_max_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(149, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "－";
            // 
            // textBox_didian
            // 
            this.textBox_didian.Location = new System.Drawing.Point(95, 72);
            this.textBox_didian.Name = "textBox_didian";
            this.textBox_didian.Size = new System.Drawing.Size(100, 21);
            this.textBox_didian.TabIndex = 11;
            this.textBox_didian.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_didian_KeyPress);
            // 
            // textBox_lianxi
            // 
            this.textBox_lianxi.Location = new System.Drawing.Point(95, 101);
            this.textBox_lianxi.Name = "textBox_lianxi";
            this.textBox_lianxi.Size = new System.Drawing.Size(100, 21);
            this.textBox_lianxi.TabIndex = 12;
            this.textBox_lianxi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_lianxi_KeyPress);
            // 
            // comboBox_leixing
            // 
            this.comboBox_leixing.FormattingEnabled = true;
            this.comboBox_leixing.Location = new System.Drawing.Point(92, 145);
            this.comboBox_leixing.Name = "comboBox_leixing";
            this.comboBox_leixing.Size = new System.Drawing.Size(121, 20);
            this.comboBox_leixing.TabIndex = 13;
            // 
            // checkBox01
            // 
            this.checkBox01.AutoSize = true;
            this.checkBox01.Location = new System.Drawing.Point(104, 185);
            this.checkBox01.Name = "checkBox01";
            this.checkBox01.Size = new System.Drawing.Size(30, 16);
            this.checkBox01.TabIndex = 14;
            this.checkBox01.Text = "1";
            this.checkBox01.UseVisualStyleBackColor = true;
            // 
            // checkBox02
            // 
            this.checkBox02.AutoSize = true;
            this.checkBox02.Location = new System.Drawing.Point(142, 185);
            this.checkBox02.Name = "checkBox02";
            this.checkBox02.Size = new System.Drawing.Size(30, 16);
            this.checkBox02.TabIndex = 15;
            this.checkBox02.Text = "2";
            this.checkBox02.UseVisualStyleBackColor = true;
            // 
            // checkBox03
            // 
            this.checkBox03.AutoSize = true;
            this.checkBox03.Location = new System.Drawing.Point(183, 185);
            this.checkBox03.Name = "checkBox03";
            this.checkBox03.Size = new System.Drawing.Size(30, 16);
            this.checkBox03.TabIndex = 16;
            this.checkBox03.Text = "3";
            this.checkBox03.UseVisualStyleBackColor = true;
            // 
            // checkBox04
            // 
            this.checkBox04.AutoSize = true;
            this.checkBox04.Location = new System.Drawing.Point(219, 184);
            this.checkBox04.Name = "checkBox04";
            this.checkBox04.Size = new System.Drawing.Size(30, 16);
            this.checkBox04.TabIndex = 17;
            this.checkBox04.Text = "4";
            this.checkBox04.UseVisualStyleBackColor = true;
            // 
            // checkBox05
            // 
            this.checkBox05.AutoSize = true;
            this.checkBox05.Location = new System.Drawing.Point(104, 215);
            this.checkBox05.Name = "checkBox05";
            this.checkBox05.Size = new System.Drawing.Size(30, 16);
            this.checkBox05.TabIndex = 18;
            this.checkBox05.Text = "5";
            this.checkBox05.UseVisualStyleBackColor = true;
            // 
            // checkBox06
            // 
            this.checkBox06.AutoSize = true;
            this.checkBox06.Location = new System.Drawing.Point(142, 215);
            this.checkBox06.Name = "checkBox06";
            this.checkBox06.Size = new System.Drawing.Size(30, 16);
            this.checkBox06.TabIndex = 19;
            this.checkBox06.Text = "6";
            this.checkBox06.UseVisualStyleBackColor = true;
            // 
            // checkBox07
            // 
            this.checkBox07.AutoSize = true;
            this.checkBox07.Location = new System.Drawing.Point(183, 215);
            this.checkBox07.Name = "checkBox07";
            this.checkBox07.Size = new System.Drawing.Size(30, 16);
            this.checkBox07.TabIndex = 20;
            this.checkBox07.Text = "7";
            this.checkBox07.UseVisualStyleBackColor = true;
            // 
            // checkBox08
            // 
            this.checkBox08.AutoSize = true;
            this.checkBox08.Location = new System.Drawing.Point(219, 215);
            this.checkBox08.Name = "checkBox08";
            this.checkBox08.Size = new System.Drawing.Size(30, 16);
            this.checkBox08.TabIndex = 21;
            this.checkBox08.Text = "8";
            this.checkBox08.UseVisualStyleBackColor = true;
            // 
            // FrmStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 306);
            this.Controls.Add(this.checkBox08);
            this.Controls.Add(this.checkBox07);
            this.Controls.Add(this.checkBox06);
            this.Controls.Add(this.checkBox05);
            this.Controls.Add(this.checkBox04);
            this.Controls.Add(this.checkBox03);
            this.Controls.Add(this.checkBox02);
            this.Controls.Add(this.checkBox01);
            this.Controls.Add(this.comboBox_leixing);
            this.Controls.Add(this.textBox_lianxi);
            this.Controls.Add(this.textBox_didian);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_max);
            this.Controls.Add(this.textBox_min);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Name = "FrmStation";
            this.Text = "添加分站";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_min;
        private System.Windows.Forms.TextBox textBox_max;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_didian;
        private System.Windows.Forms.TextBox textBox_lianxi;
        private System.Windows.Forms.ComboBox comboBox_leixing;
        private System.Windows.Forms.CheckBox checkBox01;
        private System.Windows.Forms.CheckBox checkBox02;
        private System.Windows.Forms.CheckBox checkBox03;
        private System.Windows.Forms.CheckBox checkBox04;
        private System.Windows.Forms.CheckBox checkBox05;
        private System.Windows.Forms.CheckBox checkBox06;
        private System.Windows.Forms.CheckBox checkBox07;
        private System.Windows.Forms.CheckBox checkBox08;
    }
}