namespace KJ128NMainRun.A_RT_PathCheck
{
    partial class A_RT_PathCheck
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Path_Tree = new DegonControlLib.TreeViewControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Text_Code = new Shine.ShineTextBox();
            this.Text_Name = new Shine.ShineTextBox();
            this.Quey = new System.Windows.Forms.Button();
            this.Return = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dgrd = new System.Windows.Forms.DataGridView();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.drawerLeftMain.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.checkBox1);
            this.panelLeftBottom.Controls.Add(this.Return);
            this.panelLeftBottom.Controls.Add(this.Quey);
            this.panelLeftBottom.Controls.Add(this.Text_Name);
            this.panelLeftBottom.Controls.Add(this.Text_Code);
            this.panelLeftBottom.Controls.Add(this.label2);
            this.panelLeftBottom.Controls.Add(this.label1);
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.Controls.Add(this.panel1);
            // 
            // btnPrint
            // 
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtSkipPage
            // 
            this.txtSkipPage.Leave += new System.EventHandler(this.txtSkipPage_Leave);
            this.txtSkipPage.Enter += new System.EventHandler(this.txtSkipPage_Enter);
            // 
            // panelMainMain
            // 
            this.panelMainMain.Controls.Add(this.dgrd);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 339);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(196, 314);
            this.panel3.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(196, 314);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Path_Tree);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(188, 289);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "巡检路线";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Path_Tree
            // 
            this.Path_Tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Path_Tree.Location = new System.Drawing.Point(3, 3);
            this.Path_Tree.Name = "Path_Tree";
            this.Path_Tree.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.Path_Tree.Size = new System.Drawing.Size(182, 283);
            this.Path_Tree.TabIndex = 0;
            this.Path_Tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Path_Tree_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(196, 25);
            this.panel2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "实时巡检";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "标识卡：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "姓  名：";
            // 
            // Text_Code
            // 
            this.Text_Code.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Text_Code.Location = new System.Drawing.Point(69, 10);
            this.Text_Code.Name = "Text_Code";
            this.Text_Code.Size = new System.Drawing.Size(100, 21);
            this.Text_Code.TabIndex = 2;
            this.Text_Code.TextType = Shine.TextType.Number;
            // 
            // Text_Name
            // 
            this.Text_Name.Location = new System.Drawing.Point(69, 48);
            this.Text_Name.Name = "Text_Name";
            this.Text_Name.Size = new System.Drawing.Size(100, 21);
            this.Text_Name.TabIndex = 3;
            this.Text_Name.TextType = Shine.TextType.WithOutChar;
            this.Text_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Text_Name_KeyPress);
            // 
            // Quey
            // 
            this.Quey.Location = new System.Drawing.Point(12, 92);
            this.Quey.Name = "Quey";
            this.Quey.Size = new System.Drawing.Size(75, 23);
            this.Quey.TabIndex = 4;
            this.Quey.Text = "查  询";
            this.Quey.UseVisualStyleBackColor = true;
            this.Quey.Click += new System.EventHandler(this.Quey_Click);
            // 
            // Return
            // 
            this.Return.Location = new System.Drawing.Point(105, 92);
            this.Return.Name = "Return";
            this.Return.Size = new System.Drawing.Size(75, 23);
            this.Return.TabIndex = 5;
            this.Return.Text = "重  置";
            this.Return.UseVisualStyleBackColor = true;
            this.Return.Click += new System.EventHandler(this.Return_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(58, 146);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "实时更新数据";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dgrd
            // 
            this.dgrd.AllowUserToAddRows = false;
            this.dgrd.AllowUserToDeleteRows = false;
            this.dgrd.AllowUserToResizeRows = false;
            this.dgrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
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
            this.dgrd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrd.Size = new System.Drawing.Size(783, 459);
            this.dgrd.TabIndex = 1;
            this.dgrd.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_Main_DataError);
            // 
            // A_RT_PathCheck
            // 
            this.AcceptButton = this.Quey;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Name = "A_RT_PathCheck";
            this.TabText = "实时巡检";
            this.Text = "实时巡检";
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
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Return;
        private System.Windows.Forms.Button Quey;
        private Shine.ShineTextBox Text_Name;
        private Shine.ShineTextBox Text_Code;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private DegonControlLib.TreeViewControl Path_Tree;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dgrd;

    }
}