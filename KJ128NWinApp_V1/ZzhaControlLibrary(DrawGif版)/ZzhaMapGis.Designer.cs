namespace ZzhaControlLibrary
{
    partial class ZzhaMapGis
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZzhaMapGis));
            this.tkbSize = new System.Windows.Forms.TrackBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbMove = new System.Windows.Forms.ToolStripButton();
            this.tsbRect = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveZoom = new System.Windows.Forms.ToolStripButton();
            this.tsbRollBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSee = new System.Windows.Forms.ToolStripButton();
            this.picMoveLF = new System.Windows.Forms.PictureBox();
            this.pnlItem = new System.Windows.Forms.Panel();
            this.lsvItems = new System.Windows.Forms.ListView();
            this.PicMinBox = new System.Windows.Forms.PictureBox();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.tkbSize)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMoveLF)).BeginInit();
            this.pnlItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicMinBox)).BeginInit();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // tkbSize
            // 
            this.tkbSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tkbSize.LargeChange = 1;
            this.tkbSize.Location = new System.Drawing.Point(795, 76);
            this.tkbSize.Name = "tkbSize";
            this.tkbSize.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tkbSize.Size = new System.Drawing.Size(45, 104);
            this.tkbSize.TabIndex = 0;
            this.tkbSize.Scroll += new System.EventHandler(this.tkbSize_Scroll);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMove,
            this.tsbRect,
            this.tsbMoveZoom,
            this.tsbRollBack,
            this.toolStripSeparator1,
            this.tsbSee});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(154, 32);
            this.toolStrip1.TabIndex = 1;
            // 
            // tsbMove
            // 
            this.tsbMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMove.Image = ((System.Drawing.Image)(resources.GetObject("tsbMove.Image")));
            this.tsbMove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMove.Name = "tsbMove";
            this.tsbMove.Size = new System.Drawing.Size(28, 29);
            this.tsbMove.Text = "漫游";
            this.tsbMove.Click += new System.EventHandler(this.tsbMove_Click);
            // 
            // tsbRect
            // 
            this.tsbRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRect.Image = ((System.Drawing.Image)(resources.GetObject("tsbRect.Image")));
            this.tsbRect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRect.Name = "tsbRect";
            this.tsbRect.Size = new System.Drawing.Size(28, 29);
            this.tsbRect.Text = "选择放大";
            this.tsbRect.Click += new System.EventHandler(this.tsbRect_Click);
            // 
            // tsbMoveZoom
            // 
            this.tsbMoveZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveZoom.Image = ((System.Drawing.Image)(resources.GetObject("tsbMoveZoom.Image")));
            this.tsbMoveZoom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMoveZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveZoom.Name = "tsbMoveZoom";
            this.tsbMoveZoom.Size = new System.Drawing.Size(29, 29);
            this.tsbMoveZoom.Text = "拖动缩放";
            this.tsbMoveZoom.Click += new System.EventHandler(this.tsbMoveZoom_Click);
            // 
            // tsbRollBack
            // 
            this.tsbRollBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRollBack.Image = ((System.Drawing.Image)(resources.GetObject("tsbRollBack.Image")));
            this.tsbRollBack.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRollBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRollBack.Name = "tsbRollBack";
            this.tsbRollBack.Size = new System.Drawing.Size(28, 29);
            this.tsbRollBack.Text = "还原";
            this.tsbRollBack.Click += new System.EventHandler(this.tsbRollBack_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // tsbSee
            // 
            this.tsbSee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSee.Image = ((System.Drawing.Image)(resources.GetObject("tsbSee.Image")));
            this.tsbSee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSee.Name = "tsbSee";
            this.tsbSee.Size = new System.Drawing.Size(23, 29);
            this.tsbSee.Text = "显示\\隐藏鹰眼";
            this.tsbSee.Click += new System.EventHandler(this.tsbSee_Click);
            // 
            // picMoveLF
            // 
            this.picMoveLF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picMoveLF.BackColor = System.Drawing.Color.White;
            this.picMoveLF.Image = global::ZzhaControlLibrary.Properties.Resources.right;
            this.picMoveLF.Location = new System.Drawing.Point(116, 13);
            this.picMoveLF.Name = "picMoveLF";
            this.picMoveLF.Size = new System.Drawing.Size(25, 461);
            this.picMoveLF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMoveLF.TabIndex = 1;
            this.picMoveLF.TabStop = false;
            this.picMoveLF.Click += new System.EventHandler(this.picMoveLF_Click);
            // 
            // pnlItem
            // 
            this.pnlItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlItem.BackgroundImage = global::ZzhaControlLibrary.Properties.Resources.ffrm;
            this.pnlItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlItem.Controls.Add(this.picMoveLF);
            this.pnlItem.Controls.Add(this.lsvItems);
            this.pnlItem.Location = new System.Drawing.Point(-115, 33);
            this.pnlItem.Name = "pnlItem";
            this.pnlItem.Size = new System.Drawing.Size(144, 487);
            this.pnlItem.TabIndex = 3;
            this.pnlItem.Visible = false;
            // 
            // lsvItems
            // 
            this.lsvItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lsvItems.Location = new System.Drawing.Point(0, 3);
            this.lsvItems.MultiSelect = false;
            this.lsvItems.Name = "lsvItems";
            this.lsvItems.Size = new System.Drawing.Size(116, 481);
            this.lsvItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvItems.TabIndex = 10;
            this.lsvItems.UseCompatibleStateImageBehavior = false;
            this.lsvItems.SelectedIndexChanged += new System.EventHandler(this.lsvItems_SelectedIndexChanged);
            this.lsvItems.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lsvItems_ItemSelectionChanged);
            // 
            // PicMinBox
            // 
            this.PicMinBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PicMinBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicMinBox.Location = new System.Drawing.Point(643, 0);
            this.PicMinBox.Name = "PicMinBox";
            this.PicMinBox.Size = new System.Drawing.Size(150, 114);
            this.PicMinBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicMinBox.TabIndex = 0;
            this.PicMinBox.TabStop = false;
            this.PicMinBox.MouseLeave += new System.EventHandler(this.PicMinBox_MouseLeave);
            this.PicMinBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicMinBox_MouseDown);
            this.PicMinBox.MouseEnter += new System.EventHandler(this.PicMinBox_MouseEnter);
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(95, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // ZzhaMapGis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.pnlItem);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tkbSize);
            this.Controls.Add(this.PicMinBox);
            this.Name = "ZzhaMapGis";
            this.Size = new System.Drawing.Size(793, 528);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ZzhaMapGis_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ZzhaMapGis_MouseMove);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ZzhaMapGis_MouseDoubleClick);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ZzhaMapGis_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ZzhaMapGis_MouseDown);
            this.Resize += new System.EventHandler(this.ZzhaMapGis_Resize);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ZzhaMapGis_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.tkbSize)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMoveLF)).EndInit();
            this.pnlItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicMinBox)).EndInit();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicMinBox;
        private System.Windows.Forms.TrackBar tkbSize;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbMove;
        private System.Windows.Forms.ToolStripButton tsbRect;
        private System.Windows.Forms.Panel pnlItem;
        private System.Windows.Forms.PictureBox picMoveLF;
        private System.Windows.Forms.ToolStripButton tsbMoveZoom;
        private System.Windows.Forms.ToolStripButton tsbRollBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSee;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        public System.Windows.Forms.ListView lsvItems;
    }
}
