namespace KJ128NMainRun.Graphics.Config
{
    partial class A_FrmCreateConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_FrmCreateConfig));
            this.pnlInOut = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMoni = new System.Windows.Forms.Button();
            this.ntbMin = new Shine.Command.Controls.NumTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.ntbMax = new Shine.Command.Controls.NumTextBox();
            this.lnkSave = new System.Windows.Forms.LinkLabel();
            this.lnkNew = new System.Windows.Forms.LinkLabel();
            this.lklLoadMap = new System.Windows.Forms.LinkLabel();
            this.trvDiv = new System.Windows.Forms.TreeView();
            this.btnOpen = new System.Windows.Forms.Button();
            this.cmsDiv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDel = new System.Windows.Forms.ToolStripMenuItem();
            this.MapGis = new ZzhaControlLibrary.ZzhaMapGis();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlInOut.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.cmsDiv.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInOut
            // 
            this.pnlInOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlInOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlInOut.Controls.Add(this.button3);
            this.pnlInOut.Controls.Add(this.btnClose);
            this.pnlInOut.Controls.Add(this.groupBox1);
            this.pnlInOut.Controls.Add(this.btnOpen);
            this.pnlInOut.Location = new System.Drawing.Point(0, 1);
            this.pnlInOut.Name = "pnlInOut";
            this.pnlInOut.Size = new System.Drawing.Size(182, 494);
            this.pnlInOut.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(178, 30);
            this.button3.TabIndex = 23;
            this.button3.Text = "图形系统配置文件";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(96, 36);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.picMap);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnMoni);
            this.groupBox1.Controls.Add(this.ntbMin);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.ntbMax);
            this.groupBox1.Controls.Add(this.lnkSave);
            this.groupBox1.Controls.Add(this.lnkNew);
            this.groupBox1.Controls.Add(this.lklLoadMap);
            this.groupBox1.Controls.Add(this.trvDiv);
            this.groupBox1.Location = new System.Drawing.Point(4, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 419);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图形图层配置文件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "底图";
            // 
            // picMap
            // 
            this.picMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.picMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMap.Location = new System.Drawing.Point(7, 32);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(160, 127);
            this.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMap.TabIndex = 3;
            this.picMap.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(6, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "显示范围:";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(92, 196);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(10, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "图层";
            // 
            // btnMoni
            // 
            this.btnMoni.Location = new System.Drawing.Point(92, 393);
            this.btnMoni.Name = "btnMoni";
            this.btnMoni.Size = new System.Drawing.Size(75, 23);
            this.btnMoni.TabIndex = 18;
            this.btnMoni.Text = "模拟全图";
            this.btnMoni.UseVisualStyleBackColor = true;
            this.btnMoni.Click += new System.EventHandler(this.btnMoni_Click);
            // 
            // ntbMin
            // 
            this.ntbMin.BoundValue = "1-100000";
            this.ntbMin.DefaultStyle = true;
            this.ntbMin.IsUseCopy = true;
            this.ntbMin.IsUseCut = true;
            this.ntbMin.IsUseNegative = false;
            this.ntbMin.IsUseStickUP = true;
            this.ntbMin.Location = new System.Drawing.Point(65, 165);
            this.ntbMin.Name = "ntbMin";
            this.ntbMin.NumberTypes = Shine.Command.Controls.NumberValidate.NumberType.Int;
            this.ntbMin.Size = new System.Drawing.Size(44, 21);
            this.ntbMin.TabIndex = 1;
            this.ntbMin.Text = "500";
            this.ntbMin.Leave += new System.EventHandler(this.ntbMin_Leave);
            this.ntbMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ntbMin_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 393);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ntbMax
            // 
            this.ntbMax.BoundValue = "1-100000";
            this.ntbMax.DefaultStyle = true;
            this.ntbMax.IsUseCopy = true;
            this.ntbMax.IsUseCut = true;
            this.ntbMax.IsUseNegative = false;
            this.ntbMax.IsUseStickUP = true;
            this.ntbMax.Location = new System.Drawing.Point(123, 165);
            this.ntbMax.Name = "ntbMax";
            this.ntbMax.NumberTypes = Shine.Command.Controls.NumberValidate.NumberType.Int;
            this.ntbMax.Size = new System.Drawing.Size(44, 21);
            this.ntbMax.TabIndex = 2;
            this.ntbMax.Text = "20000";
            this.ntbMax.Leave += new System.EventHandler(this.ntbMax_Leave);
            this.ntbMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ntbMax_KeyPress);
            // 
            // lnkSave
            // 
            this.lnkSave.AutoSize = true;
            this.lnkSave.Location = new System.Drawing.Point(19, 397);
            this.lnkSave.Name = "lnkSave";
            this.lnkSave.Size = new System.Drawing.Size(29, 12);
            this.lnkSave.TabIndex = 16;
            this.lnkSave.TabStop = true;
            this.lnkSave.Text = "保存";
            this.lnkSave.Visible = false;
            this.lnkSave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSave_LinkClicked);
            // 
            // lnkNew
            // 
            this.lnkNew.AutoSize = true;
            this.lnkNew.Location = new System.Drawing.Point(137, 204);
            this.lnkNew.Name = "lnkNew";
            this.lnkNew.Size = new System.Drawing.Size(29, 12);
            this.lnkNew.TabIndex = 13;
            this.lnkNew.TabStop = true;
            this.lnkNew.Text = "新建";
            this.lnkNew.Visible = false;
            this.lnkNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNew_LinkClicked);
            // 
            // lklLoadMap
            // 
            this.lklLoadMap.AutoSize = true;
            this.lklLoadMap.Location = new System.Drawing.Point(114, 397);
            this.lklLoadMap.Name = "lklLoadMap";
            this.lklLoadMap.Size = new System.Drawing.Size(53, 12);
            this.lklLoadMap.TabIndex = 5;
            this.lklLoadMap.TabStop = true;
            this.lklLoadMap.Text = "模拟全图";
            this.lklLoadMap.Visible = false;
            this.lklLoadMap.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklLoadMap_LinkClicked);
            // 
            // trvDiv
            // 
            this.trvDiv.Location = new System.Drawing.Point(7, 220);
            this.trvDiv.Name = "trvDiv";
            this.trvDiv.Size = new System.Drawing.Size(160, 169);
            this.trvDiv.TabIndex = 4;
            this.trvDiv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvDiv_MouseDown);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(11, 36);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 20;
            this.btnOpen.Text = "打开";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cmsDiv
            // 
            this.cmsDiv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEdit,
            this.tsmDel});
            this.cmsDiv.Name = "cmsDiv";
            this.cmsDiv.Size = new System.Drawing.Size(95, 48);
            // 
            // tsmEdit
            // 
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(94, 22);
            this.tsmEdit.Text = "编辑";
            this.tsmEdit.Click += new System.EventHandler(this.tsmEdit_Click);
            // 
            // tsmDel
            // 
            this.tsmDel.Name = "tsmDel";
            this.tsmDel.Size = new System.Drawing.Size(94, 22);
            this.tsmDel.Text = "删除";
            this.tsmDel.Click += new System.EventHandler(this.tsmDel_Click);
            // 
            // MapGis
            // 
            this.MapGis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MapGis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MapGis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MapGis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MapGis.HashNameColor = ((System.Collections.Hashtable)(resources.GetObject("MapGis.HashNameColor")));
            this.MapGis.Index = 0;
            this.MapGis.IsMoving = false;
            this.MapGis.IsPaintRoute = false;
            this.MapGis.IsStationChangeed = false;
            this.MapGis.Location = new System.Drawing.Point(184, 0);
            this.MapGis.MapFilePath = null;
            this.MapGis.MaxWidth = 0;
            this.MapGis.MinWidth = 0;
            this.MapGis.MoverStrColor = System.Drawing.Color.Red;
            this.MapGis.Name = "MapGis";
            this.MapGis.ShowStationOther = false;
            this.MapGis.Size = new System.Drawing.Size(803, 522);
            this.MapGis.StartPoint = ((System.Drawing.PointF)(resources.GetObject("MapGis.StartPoint")));
            this.MapGis.StationFilePath = null;
            this.MapGis.StationStrColor = System.Drawing.Color.Red;
            this.MapGis.StrImpEmpName = "";
            this.MapGis.StrNameAndColor = null;
            this.MapGis.TabIndex = 0;
            this.MapGis.UseDiv = false;
            this.MapGis.UseGif = false;
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFile});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(987, 24);
            this.mnuMain.TabIndex = 2;
            this.mnuMain.Text = "菜单";
            this.mnuMain.Visible = false;
            // 
            // tsmFile
            // 
            this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNew,
            this.tsmiOpen,
            this.tsmiClose,
            this.toolStripSeparator1,
            this.tsmiSave,
            this.toolStripSeparator2,
            this.tsmiExit});
            this.tsmFile.Name = "tsmFile";
            this.tsmFile.Size = new System.Drawing.Size(59, 20);
            this.tsmFile.Text = "文件(&F)";
            // 
            // tsmiNew
            // 
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.Size = new System.Drawing.Size(112, 22);
            this.tsmiNew.Text = "新建(&N)";
            this.tsmiNew.Click += new System.EventHandler(this.tsmiNew_Click);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(112, 22);
            this.tsmiOpen.Text = "打开(&O)";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tsmiClose
            // 
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.Size = new System.Drawing.Size(112, 22);
            this.tsmiClose.Text = "关闭(&C)";
            this.tsmiClose.Click += new System.EventHandler(this.tsmiClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(112, 22);
            this.tsmiSave.Text = "保存(&S)";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(109, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(112, 22);
            this.tsmiExit.Text = "退出(&X)";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // A_FrmCreateConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.MapGis);
            this.Controls.Add(this.pnlInOut);
            this.Name = "A_FrmCreateConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "图形配置文件系统";
            this.Text = "图形图层配置文件系统";
            this.Load += new System.EventHandler(this.FrmCreateConfig_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCreateConfig_FormClosing);
            this.pnlInOut.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.cmsDiv.ResumeLayout(false);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZzhaControlLibrary.ZzhaMapGis MapGis;
        private System.Windows.Forms.Panel pnlInOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picMap;
        private Shine.Command.Controls.NumTextBox ntbMax;
        private Shine.Command.Controls.NumTextBox ntbMin;
        private System.Windows.Forms.LinkLabel lnkNew;
        private System.Windows.Forms.ContextMenuStrip cmsDiv;
        private System.Windows.Forms.ToolStripMenuItem tsmEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmDel;
        private System.Windows.Forms.TreeView trvDiv;
        private System.Windows.Forms.LinkLabel lklLoadMap;
        private System.Windows.Forms.LinkLabel lnkSave;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem tsmFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.Button btnMoni;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnClose;


    }
}