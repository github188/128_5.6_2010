namespace KJ128NMainRun.A_RT_StationHead
{
    partial class A_FrmRTStationHead_Set
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_FrmRTStationHead_Set));
            this.returnbutton = new System.Windows.Forms.Button();
            this.removebutton = new System.Windows.Forms.Button();
            this.savebutton = new System.Windows.Forms.Button();
            this.gb = new System.Windows.Forms.GroupBox();
            this.dtp_End = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_Begin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cb = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_TipsInfo = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // returnbutton
            // 
            this.returnbutton.Location = new System.Drawing.Point(310, 218);
            this.returnbutton.Name = "returnbutton";
            this.returnbutton.Size = new System.Drawing.Size(53, 23);
            this.returnbutton.TabIndex = 10;
            this.returnbutton.Text = "返 回";
            this.returnbutton.UseVisualStyleBackColor = true;
            this.returnbutton.Click += new System.EventHandler(this.returnbutton_Click);
            // 
            // removebutton
            // 
            this.removebutton.Location = new System.Drawing.Point(251, 218);
            this.removebutton.Name = "removebutton";
            this.removebutton.Size = new System.Drawing.Size(53, 23);
            this.removebutton.TabIndex = 9;
            this.removebutton.Text = "重 置";
            this.removebutton.UseVisualStyleBackColor = true;
            this.removebutton.Click += new System.EventHandler(this.removebutton_Click);
            // 
            // savebutton
            // 
            this.savebutton.Location = new System.Drawing.Point(192, 218);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(53, 23);
            this.savebutton.TabIndex = 8;
            this.savebutton.Text = "保 存";
            this.savebutton.UseVisualStyleBackColor = true;
            this.savebutton.Click += new System.EventHandler(this.savebutton_Click);
            // 
            // gb
            // 
            this.gb.Controls.Add(this.dtp_End);
            this.gb.Controls.Add(this.label2);
            this.gb.Controls.Add(this.dtp_Begin);
            this.gb.Controls.Add(this.label1);
            this.gb.Location = new System.Drawing.Point(145, 30);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(222, 167);
            this.gb.TabIndex = 7;
            this.gb.TabStop = false;
            // 
            // dtp_End
            // 
            this.dtp_End.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_End.Location = new System.Drawing.Point(18, 120);
            this.dtp_End.Name = "dtp_End";
            this.dtp_End.Size = new System.Drawing.Size(200, 21);
            this.dtp_End.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "终止时间：";
            // 
            // dtp_Begin
            // 
            this.dtp_Begin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_Begin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Begin.Location = new System.Drawing.Point(18, 51);
            this.dtp_Begin.Name = "dtp_Begin";
            this.dtp_Begin.Size = new System.Drawing.Size(200, 21);
            this.dtp_Begin.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "开始时间：";
            // 
            // cb
            // 
            this.cb.AutoSize = true;
            this.cb.Location = new System.Drawing.Point(163, 30);
            this.cb.Name = "cb";
            this.cb.Size = new System.Drawing.Size(120, 16);
            this.cb.TabIndex = 1;
            this.cb.Text = "是否启用起止时间";
            this.cb.UseVisualStyleBackColor = true;
            this.cb.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(12, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(119, 167);
            this.panel1.TabIndex = 6;
            // 
            // lb_TipsInfo
            // 
            this.lb_TipsInfo.AutoSize = true;
            this.lb_TipsInfo.Location = new System.Drawing.Point(59, 223);
            this.lb_TipsInfo.Name = "lb_TipsInfo";
            this.lb_TipsInfo.Size = new System.Drawing.Size(53, 12);
            this.lb_TipsInfo.TabIndex = 73;
            this.lb_TipsInfo.Text = "保存成功";
            this.lb_TipsInfo.Visible = false;
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(12, 223);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(41, 12);
            this.label87.TabIndex = 72;
            this.label87.Text = "提示：";
            // 
            // A_FrmRTStationHead_Set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(379, 267);
            this.Controls.Add(this.lb_TipsInfo);
            this.Controls.Add(this.label87);
            this.Controls.Add(this.returnbutton);
            this.Controls.Add(this.removebutton);
            this.Controls.Add(this.cb);
            this.Controls.Add(this.savebutton);
            this.Controls.Add(this.gb);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "A_FrmRTStationHead_Set";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询时间设置";
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button returnbutton;
        private System.Windows.Forms.Button removebutton;
        private System.Windows.Forms.Button savebutton;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.DateTimePicker dtp_End;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_Begin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_TipsInfo;
        private System.Windows.Forms.Label label87;
    }
}