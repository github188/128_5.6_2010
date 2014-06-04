namespace KJ128NMainRun.A_His_Station_Data
{
    partial class A_His_Station_data
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.DetyTree = new DegonControlLib.TreeViewControl();
            this.label1 = new System.Windows.Forms.Label();
            this.beginTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.endtime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.CodeText = new Shine.ShineTextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nameText = new Shine.ShineTextBox();
            this.sendText = new Shine.ShineTextBox();
            this.readText = new Shine.ShineTextBox();
            this.btnselect = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.equradio = new System.Windows.Forms.RadioButton();
            this.empradio = new System.Windows.Forms.RadioButton();
            this.dgrd = new System.Windows.Forms.DataGridView();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.drawerLeftMain.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.panel2);
            this.panelLeftBottom.Controls.Add(this.button2);
            this.panelLeftBottom.Controls.Add(this.btnselect);
            this.panelLeftBottom.Controls.Add(this.readText);
            this.panelLeftBottom.Controls.Add(this.sendText);
            this.panelLeftBottom.Controls.Add(this.nameText);
            this.panelLeftBottom.Controls.Add(this.label5);
            this.panelLeftBottom.Controls.Add(this.label4);
            this.panelLeftBottom.Controls.Add(this.lbl);
            this.panelLeftBottom.Controls.Add(this.CodeText);
            this.panelLeftBottom.Controls.Add(this.label3);
            this.panelLeftBottom.Controls.Add(this.endtime);
            this.panelLeftBottom.Controls.Add(this.label2);
            this.panelLeftBottom.Controls.Add(this.beginTime);
            this.panelLeftBottom.Controls.Add(this.label1);
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 184);
            this.panelLeftBottom.Size = new System.Drawing.Size(200, 339);
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.Controls.Add(this.DetyTree);
            this.drawerLeftMain.Controls.Add(this.panel1);
            this.drawerLeftMain.Size = new System.Drawing.Size(200, 184);
            // 
            // btnPrint
            // 
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cmbSelectCounts
            // 
            this.cmbSelectCounts.SelectedIndexChanged += new System.EventHandler(this.cmbSelectCounts_SelectedIndexChanged);
            // 
            // txtSkipPage
            // 
            this.txtSkipPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSkipPage_KeyPress);
            this.txtSkipPage.Enter += new System.EventHandler(this.txtSkipPage_Enter);
            // 
            // btnDownPage
            // 
            this.btnDownPage.Click += new System.EventHandler(this.btnDownPage_Click);
            // 
            // btnUpPage
            // 
            this.btnUpPage.Click += new System.EventHandler(this.btnUpPage_Click);
            // 
            // panelMainMain
            // 
            this.panelMainMain.Controls.Add(this.dgrd);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 25);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "历史分站";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DetyTree
            // 
            this.DetyTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetyTree.Location = new System.Drawing.Point(0, 25);
            this.DetyTree.Name = "DetyTree";
            this.DetyTree.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.DetyTree.Size = new System.Drawing.Size(196, 155);
            this.DetyTree.TabIndex = 1;
            this.DetyTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DetyTree_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始时间：";
            // 
            // beginTime
            // 
            this.beginTime.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.beginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.beginTime.Location = new System.Drawing.Point(12, 28);
            this.beginTime.Name = "beginTime";
            this.beginTime.Size = new System.Drawing.Size(180, 21);
            this.beginTime.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "终止时间：";
            // 
            // endtime
            // 
            this.endtime.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.endtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endtime.Location = new System.Drawing.Point(12, 72);
            this.endtime.Name = "endtime";
            this.endtime.Size = new System.Drawing.Size(180, 21);
            this.endtime.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "标识卡：";
            // 
            // CodeText
            // 
            this.CodeText.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CodeText.Location = new System.Drawing.Point(92, 99);
            this.CodeText.Name = "CodeText";
            this.CodeText.Size = new System.Drawing.Size(100, 21);
            this.CodeText.TabIndex = 5;
            this.CodeText.TextType = Shine.TextType.Number;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(12, 129);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(53, 12);
            this.lbl.TabIndex = 6;
            this.lbl.Text = "姓  名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "传输分站：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "读卡分站：";
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(92, 126);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(100, 21);
            this.nameText.TabIndex = 9;
            this.nameText.TextType = Shine.TextType.WithOutChar;
            this.nameText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameText_KeyPress);
            // 
            // sendText
            // 
            this.sendText.Location = new System.Drawing.Point(92, 153);
            this.sendText.Name = "sendText";
            this.sendText.Size = new System.Drawing.Size(100, 21);
            this.sendText.TabIndex = 10;
            this.sendText.TextType = Shine.TextType.Number;
            // 
            // readText
            // 
            this.readText.Location = new System.Drawing.Point(92, 181);
            this.readText.Name = "readText";
            this.readText.Size = new System.Drawing.Size(100, 21);
            this.readText.TabIndex = 11;
            this.readText.TextType = Shine.TextType.Number;
            // 
            // btnselect
            // 
            this.btnselect.Location = new System.Drawing.Point(10, 212);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(75, 23);
            this.btnselect.TabIndex = 12;
            this.btnselect.Text = "查  询";
            this.btnselect.UseVisualStyleBackColor = true;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(117, 212);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "重  置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 249);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(196, 86);
            this.panel2.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.equradio);
            this.groupBox1.Controls.Add(this.empradio);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "标识卡匹配类型";
            // 
            // equradio
            // 
            this.equradio.AutoSize = true;
            this.equradio.Location = new System.Drawing.Point(115, 37);
            this.equradio.Name = "equradio";
            this.equradio.Size = new System.Drawing.Size(47, 16);
            this.equradio.TabIndex = 1;
            this.equradio.TabStop = true;
            this.equradio.Text = "设备";
            this.equradio.UseVisualStyleBackColor = true;
            // 
            // empradio
            // 
            this.empradio.AutoSize = true;
            this.empradio.Checked = true;
            this.empradio.Location = new System.Drawing.Point(26, 37);
            this.empradio.Name = "empradio";
            this.empradio.Size = new System.Drawing.Size(47, 16);
            this.empradio.TabIndex = 0;
            this.empradio.TabStop = true;
            this.empradio.Text = "人员";
            this.empradio.UseVisualStyleBackColor = true;
            this.empradio.CheckedChanged += new System.EventHandler(this.empradio_CheckedChanged);
            // 
            // dgrd
            // 
            this.dgrd.AllowUserToAddRows = false;
            this.dgrd.AllowUserToDeleteRows = false;
            this.dgrd.AllowUserToResizeColumns = false;
            this.dgrd.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrd.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrd.Location = new System.Drawing.Point(0, 0);
            this.dgrd.Name = "dgrd";
            this.dgrd.ReadOnly = true;
            this.dgrd.RowHeadersVisible = false;
            this.dgrd.RowTemplate.Height = 23;
            this.dgrd.Size = new System.Drawing.Size(783, 459);
            this.dgrd.TabIndex = 0;
            // 
            // A_His_Station_data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Name = "A_His_Station_data";
            this.TabText = "历史读卡分站";
            this.Text = "A_His_Station_data";
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private DegonControlLib.TreeViewControl DetyTree;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker endtime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker beginTime;
        private System.Windows.Forms.Button btnselect;
        private Shine.ShineTextBox readText;
        private Shine.ShineTextBox sendText;
        private Shine.ShineTextBox nameText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl;
        private Shine.ShineTextBox CodeText;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton equradio;
        private System.Windows.Forms.RadioButton empradio;
        private System.Windows.Forms.DataGridView dgrd;
    }
}