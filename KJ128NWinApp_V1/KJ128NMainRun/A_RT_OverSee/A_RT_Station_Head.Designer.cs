namespace KJ128NMainRun.A_RT_OverSee
{
    partial class A_RT_Station_Head
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeViewControl1 = new DegonControlLib.TreeViewControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.readtextBox = new Shine.ShineTextBox();
            this.sendtextBox = new Shine.ShineTextBox();
            this.nametextBox = new Shine.ShineTextBox();
            this.codetextBox = new Shine.ShineTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioeqe = new System.Windows.Forms.RadioButton();
            this.radioemp = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.drawerLeftMain.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.checkBox1);
            this.panelLeftBottom.Controls.Add(this.groupBox1);
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 406);
            this.panelLeftBottom.Size = new System.Drawing.Size(200, 117);
            // 
            // panelMainTop
            // 
            this.panelMainTop.Controls.Add(this.button3);
            this.panelMainTop.Controls.SetChildIndex(this.btnDelete, 0);
            this.panelMainTop.Controls.SetChildIndex(this.button3, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnSelectAll, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnLaws, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnAdd, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnPrint, 0);
            this.panelMainTop.Controls.SetChildIndex(this.lblMainTitle, 0);
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.Controls.Add(this.panel1);
            this.drawerLeftMain.Controls.Add(this.panel3);
            this.drawerLeftMain.Size = new System.Drawing.Size(200, 406);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(640, 4);
            // 
            // btnPrint
            // 
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // panelMainMain
            // 
            this.panelMainMain.Controls.Add(this.dataGridView1);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.treeViewControl1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 208);
            this.panel1.TabIndex = 0;
            // 
            // treeViewControl1
            // 
            this.treeViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewControl1.Location = new System.Drawing.Point(0, 25);
            this.treeViewControl1.Name = "treeViewControl1";
            this.treeViewControl1.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.treeViewControl1.Size = new System.Drawing.Size(192, 179);
            this.treeViewControl1.TabIndex = 1;
            this.treeViewControl1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewControl1_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 25);
            this.panel2.TabIndex = 0;
            // 
            // button
            // 
            this.button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button.Location = new System.Drawing.Point(0, 0);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(192, 25);
            this.button.TabIndex = 0;
            this.button.Text = "读卡分站";
            this.button.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.readtextBox);
            this.panel3.Controls.Add(this.sendtextBox);
            this.panel3.Controls.Add(this.nametextBox);
            this.panel3.Controls.Add(this.codetextBox);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 208);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(196, 194);
            this.panel3.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(104, 155);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "重 置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "查 询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // readtextBox
            // 
            this.readtextBox.Location = new System.Drawing.Point(90, 114);
            this.readtextBox.Name = "readtextBox";
            this.readtextBox.Size = new System.Drawing.Size(100, 21);
            this.readtextBox.TabIndex = 9;
            this.readtextBox.TextType = Shine.TextType.Number;
            // 
            // sendtextBox
            // 
            this.sendtextBox.Location = new System.Drawing.Point(90, 81);
            this.sendtextBox.Name = "sendtextBox";
            this.sendtextBox.Size = new System.Drawing.Size(100, 21);
            this.sendtextBox.TabIndex = 8;
            this.sendtextBox.TextType = Shine.TextType.Number;
            // 
            // nametextBox
            // 
            this.nametextBox.Location = new System.Drawing.Point(90, 48);
            this.nametextBox.Name = "nametextBox";
            this.nametextBox.Size = new System.Drawing.Size(100, 21);
            this.nametextBox.TabIndex = 7;
            this.nametextBox.TextType = Shine.TextType.WithOutChar;
            this.nametextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nametextBox_KeyPress);
            // 
            // codetextBox
            // 
            this.codetextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.codetextBox.Location = new System.Drawing.Point(90, 14);
            this.codetextBox.Name = "codetextBox";
            this.codetextBox.Size = new System.Drawing.Size(100, 21);
            this.codetextBox.TabIndex = 6;
            this.codetextBox.TextType = Shine.TextType.Number;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "读卡分站：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "传输分站：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "姓  名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "标识卡：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioeqe);
            this.groupBox1.Controls.Add(this.radioemp);
            this.groupBox1.Location = new System.Drawing.Point(3, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "标示卡匹配类型";
            // 
            // radioeqe
            // 
            this.radioeqe.AutoSize = true;
            this.radioeqe.Location = new System.Drawing.Point(101, 32);
            this.radioeqe.Name = "radioeqe";
            this.radioeqe.Size = new System.Drawing.Size(47, 16);
            this.radioeqe.TabIndex = 1;
            this.radioeqe.Text = "设备";
            this.radioeqe.UseVisualStyleBackColor = true;
            this.radioeqe.CheckedChanged += new System.EventHandler(this.radioeqe_CheckedChanged);
            // 
            // radioemp
            // 
            this.radioemp.AutoSize = true;
            this.radioemp.Checked = true;
            this.radioemp.Location = new System.Drawing.Point(21, 33);
            this.radioemp.Name = "radioemp";
            this.radioemp.Size = new System.Drawing.Size(47, 16);
            this.radioemp.TabIndex = 0;
            this.radioemp.TabStop = true;
            this.radioemp.Text = "人员";
            this.radioemp.UseVisualStyleBackColor = true;
            this.radioemp.Click += new System.EventHandler(this.radioemp_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(3, 14);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "实时更新数据";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(783, 459);
            this.dataGridView1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(640, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "设置";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // A_RT_Station_Head
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Name = "A_RT_Station_Head";
            this.TabText = "实时读卡分站";
            this.Text = "A_RT_Station_Head";
            this.panelLeft.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelLeftBottom.ResumeLayout(false);
            this.panelLeftBottom.PerformLayout();
            this.panelMainBottom.ResumeLayout(false);
            this.panelMainBottom.PerformLayout();
            this.panelMainTop.ResumeLayout(false);
            this.panelMainTop.PerformLayout();
            this.drawerLeftMain.ResumeLayout(false);
            this.panelMainMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DegonControlLib.TreeViewControl treeViewControl1;
        private System.Windows.Forms.Button button;
        private Shine.ShineTextBox readtextBox;
        private Shine.ShineTextBox sendtextBox;
        private Shine.ShineTextBox nametextBox;
        private Shine.ShineTextBox codetextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioeqe;
        private System.Windows.Forms.RadioButton radioemp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
    }
}