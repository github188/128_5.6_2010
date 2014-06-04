namespace KJ128NMainRun.Graphics.A_DPic_Wizard
{
    partial class A_DPic_ChooseStation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_DPic_ChooseStation));
            this.btnRemoveStations = new System.Windows.Forms.Button();
            this.btnAddStations = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsbSelectStation = new KJ128WindowsLibrary.ZzhaListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lsbStation = new KJ128WindowsLibrary.ZzhaListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.picShow = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRemoveStations
            // 
            this.btnRemoveStations.Location = new System.Drawing.Point(238, 210);
            this.btnRemoveStations.Name = "btnRemoveStations";
            this.btnRemoveStations.Size = new System.Drawing.Size(83, 23);
            this.btnRemoveStations.TabIndex = 1;
            this.btnRemoveStations.Text = "<-- 移除至";
            this.btnRemoveStations.UseVisualStyleBackColor = true;
            this.btnRemoveStations.Click += new System.EventHandler(this.btnRemoveStations_Click);
            // 
            // btnAddStations
            // 
            this.btnAddStations.Location = new System.Drawing.Point(238, 160);
            this.btnAddStations.Name = "btnAddStations";
            this.btnAddStations.Size = new System.Drawing.Size(83, 23);
            this.btnAddStations.TabIndex = 2;
            this.btnAddStations.Text = "添加至 -->";
            this.btnAddStations.UseVisualStyleBackColor = true;
            this.btnAddStations.Click += new System.EventHandler(this.btnAddStations_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsbSelectStation);
            this.groupBox1.Location = new System.Drawing.Point(327, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 373);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已经选定要配置的读卡分站列表";
            // 
            // lsbSelectStation
            // 
            this.lsbSelectStation.FormattingEnabled = true;
            this.lsbSelectStation.ItemHeight = 12;
            this.lsbSelectStation.Location = new System.Drawing.Point(8, 20);
            this.lsbSelectStation.Name = "lsbSelectStation";
            this.lsbSelectStation.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbSelectStation.Size = new System.Drawing.Size(184, 340);
            this.lsbSelectStation.TabIndex = 4;
            this.lsbSelectStation.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("lsbSelectStation.Values")));
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lsbStation);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 373);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "备选的读卡分站列表";
            // 
            // lsbStation
            // 
            this.lsbStation.FormattingEnabled = true;
            this.lsbStation.ItemHeight = 12;
            this.lsbStation.Location = new System.Drawing.Point(6, 20);
            this.lsbStation.Name = "lsbStation";
            this.lsbStation.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbStation.Size = new System.Drawing.Size(207, 340);
            this.lsbStation.TabIndex = 1;
            this.lsbStation.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("lsbStation.Values")));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(19, 405);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(485, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "本步骤为配置向导第三步，即选择与图形配置向导第二步中选中煤矿底图相配套的读卡分站";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(17, 469);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "第三步．单击下一步按钮。";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(19, 447);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(497, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "第二步．如果要修改默认绑定，选定对应读卡分站，单击移除至按钮，否则单击添加至按钮。";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(19, 425);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(341, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "第一步．本步骤会默认把所有读卡分站与选定的煤矿地图绑定。";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(318, 498);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 16;
            this.btnPreview.Text = "上一步";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(498, 498);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 17;
            this.btnNext.Text = "下一步";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // picShow
            // 
            this.picShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picShow.Location = new System.Drawing.Point(11, 20);
            this.picShow.Name = "picShow";
            this.picShow.Size = new System.Drawing.Size(327, 338);
            this.picShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picShow.TabIndex = 18;
            this.picShow.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.picShow);
            this.groupBox3.Location = new System.Drawing.Point(531, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(348, 373);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "选定底图预览";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(12, 388);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(867, 100);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "本步骤操作指南";
            // 
            // A_DPic_ChooseStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(884, 532);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddStations);
            this.Controls.Add(this.btnRemoveStations);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Name = "A_DPic_ChooseStation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图形配置系统向导》第三步　选择和煤矿底图相匹配的读卡分站";
            this.Load += new System.EventHandler(this.A_DPic_ChooseStation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemoveStations;
        private System.Windows.Forms.Button btnAddStations;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private KJ128WindowsLibrary.ZzhaListBox lsbStation;
        private KJ128WindowsLibrary.ZzhaListBox lsbSelectStation;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.PictureBox picShow;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}