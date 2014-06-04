namespace KJ128NMainRun.Graphics
{
    partial class frmRealTimeRoute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRealTimeRoute));
            this.MapGis = new ZzhaControlLibrary.ZzhaMapGis();
            this.pnlRTRoute = new System.Windows.Forms.Panel();
            this.cmbRTRouteSpeed = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picRTRouteInOut = new System.Windows.Forms.PictureBox();
            this.lsbRTRouteEmp = new KJ128WindowsLibrary.ZzhaListBox();
            this.cmbRTRouteDept = new KJ128WindowsLibrary.ZzhaComBox();
            this.pnlRTRoute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRTRouteInOut)).BeginInit();
            this.SuspendLayout();
            // 
            // MapGis
            // 
            this.MapGis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MapGis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MapGis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapGis.IsMoving = false;
            this.MapGis.IsStationChangeed = false;
            this.MapGis.Location = new System.Drawing.Point(0, 0);
            this.MapGis.MapFilePath = null;
            this.MapGis.MaxWidth = 0;
            this.MapGis.MinWidth = 0;
            this.MapGis.MoverStrColor = System.Drawing.Color.Red;
            this.MapGis.Name = "MapGis";
            this.MapGis.ShowStationOther = false;
            this.MapGis.Size = new System.Drawing.Size(691, 545);
            this.MapGis.StationFilePath = null;
            this.MapGis.StationStrColor = System.Drawing.Color.Red;
            this.MapGis.TabIndex = 0;
            this.MapGis.UseDiv = false;
            this.MapGis.UseGif = true;
            // 
            // pnlRTRoute
            // 
            this.pnlRTRoute.BackColor = System.Drawing.Color.White;
            this.pnlRTRoute.BackgroundImage = global::KJ128NMainRun.Properties.Resources.ffrm;
            this.pnlRTRoute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlRTRoute.Controls.Add(this.cmbRTRouteSpeed);
            this.pnlRTRoute.Controls.Add(this.label1);
            this.pnlRTRoute.Controls.Add(this.picRTRouteInOut);
            this.pnlRTRoute.Controls.Add(this.lsbRTRouteEmp);
            this.pnlRTRoute.Controls.Add(this.cmbRTRouteDept);
            this.pnlRTRoute.Location = new System.Drawing.Point(73, 33);
            this.pnlRTRoute.Name = "pnlRTRoute";
            this.pnlRTRoute.Size = new System.Drawing.Size(172, 329);
            this.pnlRTRoute.TabIndex = 1;
            this.pnlRTRoute.Visible = false;
            // 
            // cmbRTRouteSpeed
            // 
            this.cmbRTRouteSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRTRouteSpeed.FormattingEnabled = true;
            this.cmbRTRouteSpeed.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmbRTRouteSpeed.Location = new System.Drawing.Point(71, 302);
            this.cmbRTRouteSpeed.Name = "cmbRTRouteSpeed";
            this.cmbRTRouteSpeed.Size = new System.Drawing.Size(50, 20);
            this.cmbRTRouteSpeed.TabIndex = 4;
            this.cmbRTRouteSpeed.SelectedIndexChanged += new System.EventHandler(this.cmbRTRouteSpeed_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "速度";
            // 
            // picRTRouteInOut
            // 
            this.picRTRouteInOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picRTRouteInOut.Image = global::KJ128NMainRun.Properties.Resources.right;
            this.picRTRouteInOut.Location = new System.Drawing.Point(140, 13);
            this.picRTRouteInOut.Name = "picRTRouteInOut";
            this.picRTRouteInOut.Size = new System.Drawing.Size(28, 305);
            this.picRTRouteInOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picRTRouteInOut.TabIndex = 2;
            this.picRTRouteInOut.TabStop = false;
            this.picRTRouteInOut.Click += new System.EventHandler(this.picRTRouteInOut_Click);
            // 
            // lsbRTRouteEmp
            // 
            this.lsbRTRouteEmp.FormattingEnabled = true;
            this.lsbRTRouteEmp.ItemHeight = 12;
            this.lsbRTRouteEmp.Location = new System.Drawing.Point(14, 40);
            this.lsbRTRouteEmp.Name = "lsbRTRouteEmp";
            this.lsbRTRouteEmp.Size = new System.Drawing.Size(120, 256);
            this.lsbRTRouteEmp.TabIndex = 1;
            this.lsbRTRouteEmp.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("lsbRTRouteEmp.Values")));
            this.lsbRTRouteEmp.SelectedIndexChanged += new System.EventHandler(this.lsbRTRouteEmp_SelectedIndexChanged);
            // 
            // cmbRTRouteDept
            // 
            this.cmbRTRouteDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRTRouteDept.FormattingEnabled = true;
            this.cmbRTRouteDept.Location = new System.Drawing.Point(14, 13);
            this.cmbRTRouteDept.Name = "cmbRTRouteDept";
            this.cmbRTRouteDept.Size = new System.Drawing.Size(121, 20);
            this.cmbRTRouteDept.TabIndex = 0;
            this.cmbRTRouteDept.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("cmbRTRouteDept.Values")));
            this.cmbRTRouteDept.SelectedIndexChanged += new System.EventHandler(this.cmbRTRouteDept_SelectedIndexChanged);
            // 
            // frmRealTimeRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 545);
            this.Controls.Add(this.pnlRTRoute);
            this.Controls.Add(this.MapGis);
            this.Name = "frmRealTimeRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "实时轨迹播放";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRealTimeRoute_Load);
            this.pnlRTRoute.ResumeLayout(false);
            this.pnlRTRoute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRTRouteInOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ZzhaControlLibrary.ZzhaMapGis MapGis;
        private System.Windows.Forms.Panel pnlRTRoute;
        private KJ128WindowsLibrary.ZzhaComBox cmbRTRouteDept;
        private KJ128WindowsLibrary.ZzhaListBox lsbRTRouteEmp;
        private System.Windows.Forms.PictureBox picRTRouteInOut;
        private System.Windows.Forms.ComboBox cmbRTRouteSpeed;
        private System.Windows.Forms.Label label1;
    }
}