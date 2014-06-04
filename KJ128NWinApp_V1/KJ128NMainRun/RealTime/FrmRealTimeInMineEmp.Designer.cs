namespace KJ128NMainRun.RealTime
{
    partial class FrmRealTimeInMineEmp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRealTimeInMineEmp));
            this.laegeimageList1 = new System.Windows.Forms.ImageList(this.components);
            this.miniimageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.treeView1 = new DegonControlLib.TreeViewControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DutyTree = new DegonControlLib.TreeViewControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tv_Stn = new DegonControlLib.TreeViewControl();
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.大图标ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.小图标ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.平铺ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.EmpPL = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.EmpLbl = new System.Windows.Forms.Label();
            this.EmpPicture = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.drawerLeftMain.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.EmpPL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.checkBox1);
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 481);
            this.panelLeftBottom.Size = new System.Drawing.Size(200, 42);
            // 
            // panelMainTop
            // 
            this.panelMainTop.Controls.Add(this.menuStrip1);
            this.panelMainTop.Controls.SetChildIndex(this.btnExportExcel, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnConfigModel, 0);
            this.panelMainTop.Controls.SetChildIndex(this.menuStrip1, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnLaws, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnDelete, 0);
            this.panelMainTop.Controls.SetChildIndex(this.lblMainTitle, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnSelectAll, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnAdd, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnPrint, 0);
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.Controls.Add(this.tabControl1);
            this.drawerLeftMain.Controls.Add(this.panel1);
            this.drawerLeftMain.Size = new System.Drawing.Size(200, 481);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(-1255, 4);
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Location = new System.Drawing.Point(154, 3);
            this.lblMainTitle.Visible = false;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(-1195, 4);
            // 
            // btnLaws
            // 
            this.btnLaws.Location = new System.Drawing.Point(-1135, 3);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(-1075, 4);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(-1015, 4);
            // 
            // cmbSelectCounts
            // 
            this.cmbSelectCounts.DropDownClosed += new System.EventHandler(this.cmbSelectCounts_DropDownClosed);
            // 
            // txtSkipPage
            // 
            this.txtSkipPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSkipPage_KeyDown);
            // 
            // btnDownPage
            // 
            this.btnDownPage.Click += new System.EventHandler(this.btnDownPage_Click);
            // 
            // btnUpPage
            // 
            this.btnUpPage.Click += new System.EventHandler(this.btnUpPage_Click);
            // 
            // lblCounts
            // 
            this.lblCounts.Size = new System.Drawing.Size(0, 12);
            this.lblCounts.Text = "";
            // 
            // panelMainMain
            // 
            this.panelMainMain.Controls.Add(this.pictureBox2);
            this.panelMainMain.Controls.Add(this.EmpPL);
            this.panelMainMain.Controls.Add(this.listView1);
            // 
            // btnConfigModel
            // 
            this.btnConfigModel.Visible = false;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Visible = false;
            // 
            // laegeimageList1
            // 
            this.laegeimageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("laegeimageList1.ImageStream")));
            this.laegeimageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.laegeimageList1.Images.SetKeyName(0, "48_2.ico");
            this.laegeimageList1.Images.SetKeyName(1, "48_1.ico");
            // 
            // miniimageList1
            // 
            this.miniimageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("miniimageList1.ImageStream")));
            this.miniimageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.miniimageList1.Images.SetKeyName(0, "32_2.ico");
            this.miniimageList1.Images.SetKeyName(1, "32_1.ico");
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.button1.Text = "下井人员名单";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(196, 452);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(188, 427);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "部门";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.treeView1.Size = new System.Drawing.Size(182, 421);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DutyTree);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(188, 427);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "职务";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DutyTree
            // 
            this.DutyTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DutyTree.Location = new System.Drawing.Point(3, 3);
            this.DutyTree.Name = "DutyTree";
            this.DutyTree.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.DutyTree.Size = new System.Drawing.Size(182, 421);
            this.DutyTree.TabIndex = 0;
            this.DutyTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DutyTree_AfterSelect);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tv_Stn);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(188, 427);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "分站";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tv_Stn
            // 
            this.tv_Stn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_Stn.Location = new System.Drawing.Point(3, 3);
            this.tv_Stn.Name = "tv_Stn";
            this.tv_Stn.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.tv_Stn.Size = new System.Drawing.Size(182, 421);
            this.tv_Stn.TabIndex = 1;
            this.tv_Stn.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Stn_AfterSelect);
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.LargeImageList = this.laegeimageList1;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(783, 459);
            this.listView1.SmallImageList = this.miniimageList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            this.listView1.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.listView1_ItemMouseHover);
            this.listView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(783, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 查看ToolStripMenuItem
            // 
            this.查看ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.大图标ToolStripMenuItem,
            this.小图标ToolStripMenuItem,
            this.平铺ToolStripMenuItem});
            this.查看ToolStripMenuItem.Image = global::KJ128NMainRun.Properties.Resources.a1;
            this.查看ToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.查看ToolStripMenuItem.Name = "查看ToolStripMenuItem";
            this.查看ToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.查看ToolStripMenuItem.Text = "查看";
            this.查看ToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // 大图标ToolStripMenuItem
            // 
            this.大图标ToolStripMenuItem.Name = "大图标ToolStripMenuItem";
            this.大图标ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.大图标ToolStripMenuItem.Text = "图标";
            this.大图标ToolStripMenuItem.Click += new System.EventHandler(this.大图标ToolStripMenuItem_Click);
            // 
            // 小图标ToolStripMenuItem
            // 
            this.小图标ToolStripMenuItem.Name = "小图标ToolStripMenuItem";
            this.小图标ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.小图标ToolStripMenuItem.Text = "列表";
            this.小图标ToolStripMenuItem.Click += new System.EventHandler(this.小图标ToolStripMenuItem_Click);
            // 
            // 平铺ToolStripMenuItem
            // 
            this.平铺ToolStripMenuItem.Name = "平铺ToolStripMenuItem";
            this.平铺ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.平铺ToolStripMenuItem.Text = "平铺";
            this.平铺ToolStripMenuItem.Click += new System.EventHandler(this.平铺ToolStripMenuItem_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(50, 14);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "实时更新";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // EmpPL
            // 
            this.EmpPL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))));
            this.EmpPL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EmpPL.Controls.Add(this.pictureBox1);
            this.EmpPL.Controls.Add(this.EmpLbl);
            this.EmpPL.Controls.Add(this.EmpPicture);
            this.EmpPL.Location = new System.Drawing.Point(205, 132);
            this.EmpPL.Name = "EmpPL";
            this.EmpPL.Size = new System.Drawing.Size(277, 222);
            this.EmpPL.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::KJ128NMainRun.Properties.Resources.未标题_1;
            this.pictureBox1.Location = new System.Drawing.Point(4, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 216);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // EmpLbl
            // 
            this.EmpLbl.AutoSize = true;
            this.EmpLbl.Location = new System.Drawing.Point(140, 16);
            this.EmpLbl.Name = "EmpLbl";
            this.EmpLbl.Size = new System.Drawing.Size(0, 12);
            this.EmpLbl.TabIndex = 1;
            // 
            // EmpPicture
            // 
            this.EmpPicture.Location = new System.Drawing.Point(4, 3);
            this.EmpPicture.Name = "EmpPicture";
            this.EmpPicture.Size = new System.Drawing.Size(130, 216);
            this.EmpPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.EmpPicture.TabIndex = 0;
            this.EmpPicture.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(783, 459);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // FrmRealTimeInMineEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmRealTimeInMineEmp";
            this.TabText = "实时下井人员名单";
            this.Text = "实时下井人员名单";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRealTimeInMineEmp_FormClosing);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.EmpPL.ResumeLayout(false);
            this.EmpPL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList laegeimageList1;
        private System.Windows.Forms.ImageList miniimageList1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private DegonControlLib.TreeViewControl DutyTree;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 大图标ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 小图标ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 平铺ToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private DegonControlLib.TreeViewControl treeView1;
        private System.Windows.Forms.Panel EmpPL;
        private System.Windows.Forms.Label EmpLbl;
        private System.Windows.Forms.PictureBox EmpPicture;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private DegonControlLib.TreeViewControl tv_Stn;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}