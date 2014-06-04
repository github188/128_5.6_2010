namespace KJ128NMainRun.Graphics.DPic
{
    partial class FrmAddPic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddPic));
            this.trvDpic = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picBackimg = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnok = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.lsbSelectStation = new KJ128WindowsLibrary.ZzhaListBox();
            this.lsbStation = new KJ128WindowsLibrary.ZzhaListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labPoint = new System.Windows.Forms.Label();
            this.labRoute = new System.Windows.Forms.Label();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackimg)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.cmsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvDpic
            // 
            this.trvDpic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDpic.Location = new System.Drawing.Point(3, 17);
            this.trvDpic.Name = "trvDpic";
            this.trvDpic.Size = new System.Drawing.Size(191, 543);
            this.trvDpic.TabIndex = 0;
            this.trvDpic.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvDpic_AfterSelect);
            this.trvDpic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvDpic_MouseDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.trvDpic);
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 563);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "底图操作";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.picBackimg);
            this.groupBox2.Location = new System.Drawing.Point(210, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 170);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "底图预览";
            // 
            // picBackimg
            // 
            this.picBackimg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picBackimg.Location = new System.Drawing.Point(6, 16);
            this.picBackimg.Name = "picBackimg";
            this.picBackimg.Size = new System.Drawing.Size(182, 147);
            this.picBackimg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBackimg.TabIndex = 0;
            this.picBackimg.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnok);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnRemove);
            this.groupBox3.Controls.Add(this.btnSelect);
            this.groupBox3.Controls.Add(this.lsbSelectStation);
            this.groupBox3.Controls.Add(this.lsbStation);
            this.groupBox3.Location = new System.Drawing.Point(210, 176);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(463, 384);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "读卡分站配置";
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(195, 350);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(73, 23);
            this.btnok.TabIndex = 6;
            this.btnok.Text = "确定";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "该图已配置的读卡分站";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "该图未配置的读卡分站";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(206, 193);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(52, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(206, 136);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(52, 23);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = ">";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lsbSelectStation
            // 
            this.lsbSelectStation.FormattingEnabled = true;
            this.lsbSelectStation.ItemHeight = 12;
            this.lsbSelectStation.Location = new System.Drawing.Point(269, 33);
            this.lsbSelectStation.Name = "lsbSelectStation";
            this.lsbSelectStation.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbSelectStation.Size = new System.Drawing.Size(178, 304);
            this.lsbSelectStation.TabIndex = 1;
            this.lsbSelectStation.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("lsbSelectStation.Values")));
            // 
            // lsbStation
            // 
            this.lsbStation.FormattingEnabled = true;
            this.lsbStation.ItemHeight = 12;
            this.lsbStation.Location = new System.Drawing.Point(16, 33);
            this.lsbStation.Name = "lsbStation";
            this.lsbStation.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbStation.Size = new System.Drawing.Size(178, 304);
            this.lsbStation.TabIndex = 0;
            this.lsbStation.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("lsbStation.Values")));
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.labPoint);
            this.groupBox4.Controls.Add(this.labRoute);
            this.groupBox4.Location = new System.Drawing.Point(416, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(257, 170);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "路径信息";
            // 
            // labPoint
            // 
            this.labPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labPoint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labPoint.Location = new System.Drawing.Point(6, 82);
            this.labPoint.Name = "labPoint";
            this.labPoint.Size = new System.Drawing.Size(245, 24);
            this.labPoint.TabIndex = 1;
            this.labPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labRoute
            // 
            this.labRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labRoute.Location = new System.Drawing.Point(6, 42);
            this.labRoute.Name = "labRoute";
            this.labRoute.Size = new System.Drawing.Size(245, 24);
            this.labRoute.TabIndex = 0;
            this.labRoute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdd,
            this.tsmiDel});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(95, 48);
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(94, 22);
            this.tsmiAdd.Text = "添加";
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // tsmiDel
            // 
            this.tsmiDel.Name = "tsmiDel";
            this.tsmiDel.Size = new System.Drawing.Size(94, 22);
            this.tsmiDel.Text = "删除";
            this.tsmiDel.Click += new System.EventHandler(this.tsmiDel_Click);
            // 
            // FrmAddPic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(685, 569);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAddPic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "底图配置";
            this.Text = "底图配置";
            this.Load += new System.EventHandler(this.FrmAddPic_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBackimg)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.cmsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvDpic;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picBackimg;
        private System.Windows.Forms.GroupBox groupBox3;
        private KJ128WindowsLibrary.ZzhaListBox lsbStation;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSelect;
        private KJ128WindowsLibrary.ZzhaListBox lsbSelectStation;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labRoute;
        private System.Windows.Forms.Label labPoint;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiDel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnok;
    }
}