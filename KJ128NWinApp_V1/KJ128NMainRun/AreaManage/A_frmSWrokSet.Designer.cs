namespace KJ128NMainRun.AreaManage
{
    partial class A_frmSWrokSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_frmSWrokSet));
            this.bt_Left = new System.Windows.Forms.Button();
            this.bt_Right = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.bt_TerSet_Close = new System.Windows.Forms.Button();
            this.bt_TerSet_Reset = new System.Windows.Forms.Button();
            this.bt_TerSet_Save = new System.Windows.Forms.Button();
            this.labMessage = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lb_TerSetTipsInfo2 = new System.Windows.Forms.Label();
            this.gb_AddTerSetInfo = new System.Windows.Forms.GroupBox();
            this.lsbWt = new KJ128WindowsLibrary.ZzhaListBox();
            this.lsbSelected = new KJ128WindowsLibrary.ZzhaListBox();
            this.cmbTer = new KJ128WindowsLibrary.ZzhaComBox();
            this.gb_AddTerSetInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_Left
            // 
            this.bt_Left.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Left.Location = new System.Drawing.Point(181, 177);
            this.bt_Left.Name = "bt_Left";
            this.bt_Left.Size = new System.Drawing.Size(41, 23);
            this.bt_Left.TabIndex = 7;
            this.bt_Left.Text = "<-";
            this.bt_Left.UseVisualStyleBackColor = true;
            this.bt_Left.Click += new System.EventHandler(this.bt_Left_Click);
            // 
            // bt_Right
            // 
            this.bt_Right.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Right.Location = new System.Drawing.Point(181, 123);
            this.bt_Right.Name = "bt_Right";
            this.bt_Right.Size = new System.Drawing.Size(41, 23);
            this.bt_Right.TabIndex = 6;
            this.bt_Right.Text = "->";
            this.bt_Right.UseVisualStyleBackColor = true;
            this.bt_Right.Click += new System.EventHandler(this.bt_Right_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(245, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "区域：";
            // 
            // bt_TerSet_Close
            // 
            this.bt_TerSet_Close.Location = new System.Drawing.Point(320, 313);
            this.bt_TerSet_Close.Name = "bt_TerSet_Close";
            this.bt_TerSet_Close.Size = new System.Drawing.Size(56, 23);
            this.bt_TerSet_Close.TabIndex = 80;
            this.bt_TerSet_Close.Text = "返回";
            this.bt_TerSet_Close.UseVisualStyleBackColor = true;
            this.bt_TerSet_Close.Click += new System.EventHandler(this.bt_TerSet_Close_Click);
            // 
            // bt_TerSet_Reset
            // 
            this.bt_TerSet_Reset.Location = new System.Drawing.Point(253, 313);
            this.bt_TerSet_Reset.Name = "bt_TerSet_Reset";
            this.bt_TerSet_Reset.Size = new System.Drawing.Size(56, 23);
            this.bt_TerSet_Reset.TabIndex = 79;
            this.bt_TerSet_Reset.Text = "重置";
            this.bt_TerSet_Reset.UseVisualStyleBackColor = true;
            this.bt_TerSet_Reset.Click += new System.EventHandler(this.bt_TerSet_Reset_Click);
            // 
            // bt_TerSet_Save
            // 
            this.bt_TerSet_Save.Location = new System.Drawing.Point(185, 313);
            this.bt_TerSet_Save.Name = "bt_TerSet_Save";
            this.bt_TerSet_Save.Size = new System.Drawing.Size(56, 23);
            this.bt_TerSet_Save.TabIndex = 78;
            this.bt_TerSet_Save.Text = "保存";
            this.bt_TerSet_Save.UseVisualStyleBackColor = true;
            this.bt_TerSet_Save.Click += new System.EventHandler(this.bt_TerSet_Save_Click);
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.Location = new System.Drawing.Point(57, 297);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(53, 12);
            this.labMessage.TabIndex = 77;
            this.labMessage.Text = "保存成功";
            this.labMessage.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "工种：";
            // 
            // lb_TerSetTipsInfo2
            // 
            this.lb_TerSetTipsInfo2.AutoSize = true;
            this.lb_TerSetTipsInfo2.Location = new System.Drawing.Point(10, 297);
            this.lb_TerSetTipsInfo2.Name = "lb_TerSetTipsInfo2";
            this.lb_TerSetTipsInfo2.Size = new System.Drawing.Size(41, 12);
            this.lb_TerSetTipsInfo2.TabIndex = 76;
            this.lb_TerSetTipsInfo2.Text = "提示：";
            // 
            // gb_AddTerSetInfo
            // 
            this.gb_AddTerSetInfo.BackColor = System.Drawing.SystemColors.Control;
            this.gb_AddTerSetInfo.Controls.Add(this.lsbWt);
            this.gb_AddTerSetInfo.Controls.Add(this.lsbSelected);
            this.gb_AddTerSetInfo.Controls.Add(this.cmbTer);
            this.gb_AddTerSetInfo.Controls.Add(this.bt_Left);
            this.gb_AddTerSetInfo.Controls.Add(this.bt_Right);
            this.gb_AddTerSetInfo.Controls.Add(this.label12);
            this.gb_AddTerSetInfo.Controls.Add(this.label11);
            this.gb_AddTerSetInfo.Location = new System.Drawing.Point(1, 6);
            this.gb_AddTerSetInfo.Name = "gb_AddTerSetInfo";
            this.gb_AddTerSetInfo.Size = new System.Drawing.Size(404, 277);
            this.gb_AddTerSetInfo.TabIndex = 75;
            this.gb_AddTerSetInfo.TabStop = false;
            // 
            // lsbWt
            // 
            this.lsbWt.FormattingEnabled = true;
            this.lsbWt.ItemHeight = 12;
            this.lsbWt.Location = new System.Drawing.Point(6, 32);
            this.lsbWt.Name = "lsbWt";
            this.lsbWt.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbWt.Size = new System.Drawing.Size(164, 232);
            this.lsbWt.TabIndex = 10;
            this.lsbWt.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("lsbWt.Values")));
            // 
            // lsbSelected
            // 
            this.lsbSelected.FormattingEnabled = true;
            this.lsbSelected.ItemHeight = 12;
            this.lsbSelected.Location = new System.Drawing.Point(234, 32);
            this.lsbSelected.Name = "lsbSelected";
            this.lsbSelected.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbSelected.Size = new System.Drawing.Size(164, 232);
            this.lsbSelected.TabIndex = 9;
            this.lsbSelected.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("lsbSelected.Values")));
            // 
            // cmbTer
            // 
            this.cmbTer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTer.FormattingEnabled = true;
            this.cmbTer.Location = new System.Drawing.Point(283, 11);
            this.cmbTer.Name = "cmbTer";
            this.cmbTer.Size = new System.Drawing.Size(101, 20);
            this.cmbTer.TabIndex = 8;
            this.cmbTer.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("cmbTer.Values")));
            this.cmbTer.SelectedIndexChanged += new System.EventHandler(this.cmbTer_SelectedIndexChanged);
            // 
            // A_frmSWrokSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 342);
            this.Controls.Add(this.bt_TerSet_Close);
            this.Controls.Add(this.bt_TerSet_Reset);
            this.Controls.Add(this.bt_TerSet_Save);
            this.Controls.Add(this.labMessage);
            this.Controls.Add(this.lb_TerSetTipsInfo2);
            this.Controls.Add(this.gb_AddTerSetInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "A_frmSWrokSet";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "特殊工种区域配置";
            this.Load += new System.EventHandler(this.A_frmSWrokSet_Load);
            this.gb_AddTerSetInfo.ResumeLayout(false);
            this.gb_AddTerSetInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Left;
        private System.Windows.Forms.Button bt_Right;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button bt_TerSet_Close;
        private System.Windows.Forms.Button bt_TerSet_Reset;
        private System.Windows.Forms.Button bt_TerSet_Save;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lb_TerSetTipsInfo2;
        private System.Windows.Forms.GroupBox gb_AddTerSetInfo;
        private KJ128WindowsLibrary.ZzhaComBox cmbTer;
        private KJ128WindowsLibrary.ZzhaListBox lsbSelected;
        private KJ128WindowsLibrary.ZzhaListBox lsbWt;
    }
}