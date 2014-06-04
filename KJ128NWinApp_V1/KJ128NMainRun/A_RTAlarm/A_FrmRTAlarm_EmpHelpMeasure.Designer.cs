namespace KJ128NMainRun.A_RTAlarm
{
    partial class A_FrmRTAlarm_EmpHelpMeasure
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
            this.gb = new System.Windows.Forms.GroupBox();
            this.txt_Measure = new Shine.ShineTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_EmpName = new Shine.ShineTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_CodeSenderAddress = new Shine.ShineTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_Close = new System.Windows.Forms.Button();
            this.bt_Save = new System.Windows.Forms.Button();
            this.lb_TipsInfo = new System.Windows.Forms.Label();
            this.lb_TipsInfo2 = new System.Windows.Forms.Label();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.txt_Measure);
            this.gb.Controls.Add(this.label3);
            this.gb.Controls.Add(this.txt_EmpName);
            this.gb.Controls.Add(this.label2);
            this.gb.Controls.Add(this.txt_CodeSenderAddress);
            this.gb.Controls.Add(this.label1);
            this.gb.Location = new System.Drawing.Point(12, 12);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(359, 169);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            // 
            // txt_Measure
            // 
            this.txt_Measure.AcceptsReturn = true;
            this.txt_Measure.AcceptsTab = true;
            this.txt_Measure.Location = new System.Drawing.Point(86, 63);
            this.txt_Measure.MaxLength = 200;
            this.txt_Measure.Multiline = true;
            this.txt_Measure.Name = "txt_Measure";
            this.txt_Measure.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Measure.Size = new System.Drawing.Size(248, 90);
            this.txt_Measure.TabIndex = 5;
            this.txt_Measure.TextType = Shine.TextType.WithOutChar;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "救援措施：";
            // 
            // txt_EmpName
            // 
            this.txt_EmpName.Enabled = false;
            this.txt_EmpName.Location = new System.Drawing.Point(246, 23);
            this.txt_EmpName.MaxLength = 20;
            this.txt_EmpName.Name = "txt_EmpName";
            this.txt_EmpName.Size = new System.Drawing.Size(88, 21);
            this.txt_EmpName.TabIndex = 3;
            this.txt_EmpName.TextType = Shine.TextType.WithOutChar;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "姓名：";
            // 
            // txt_CodeSenderAddress
            // 
            this.txt_CodeSenderAddress.Enabled = false;
            this.txt_CodeSenderAddress.Location = new System.Drawing.Point(86, 23);
            this.txt_CodeSenderAddress.MaxLength = 5;
            this.txt_CodeSenderAddress.Name = "txt_CodeSenderAddress";
            this.txt_CodeSenderAddress.Size = new System.Drawing.Size(88, 21);
            this.txt_CodeSenderAddress.TabIndex = 1;
            this.txt_CodeSenderAddress.TextType = Shine.TextType.WithOutChar;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "标识卡号：";
            // 
            // bt_Close
            // 
            this.bt_Close.Location = new System.Drawing.Point(319, 209);
            this.bt_Close.Name = "bt_Close";
            this.bt_Close.Size = new System.Drawing.Size(56, 23);
            this.bt_Close.TabIndex = 79;
            this.bt_Close.Text = "返回";
            this.bt_Close.UseVisualStyleBackColor = true;
            this.bt_Close.Click += new System.EventHandler(this.bt_Close_Click);
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(257, 209);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(56, 23);
            this.bt_Save.TabIndex = 77;
            this.bt_Save.Text = "完成";
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // lb_TipsInfo
            // 
            this.lb_TipsInfo.AutoSize = true;
            this.lb_TipsInfo.Location = new System.Drawing.Point(59, 194);
            this.lb_TipsInfo.Name = "lb_TipsInfo";
            this.lb_TipsInfo.Size = new System.Drawing.Size(53, 12);
            this.lb_TipsInfo.TabIndex = 76;
            this.lb_TipsInfo.Text = "保存成功";
            this.lb_TipsInfo.Visible = false;
            // 
            // lb_TipsInfo2
            // 
            this.lb_TipsInfo2.AutoSize = true;
            this.lb_TipsInfo2.Location = new System.Drawing.Point(12, 194);
            this.lb_TipsInfo2.Name = "lb_TipsInfo2";
            this.lb_TipsInfo2.Size = new System.Drawing.Size(41, 12);
            this.lb_TipsInfo2.TabIndex = 75;
            this.lb_TipsInfo2.Text = "提示：";
            // 
            // A_FrmRTAlarm_EmpHelpMeasure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(383, 244);
            this.Controls.Add(this.bt_Close);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.lb_TipsInfo);
            this.Controls.Add(this.lb_TipsInfo2);
            this.Controls.Add(this.gb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "A_FrmRTAlarm_EmpHelpMeasure";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "救援措施";
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private Shine.ShineTextBox txt_Measure;
        private System.Windows.Forms.Label label3;
        private Shine.ShineTextBox txt_EmpName;
        private System.Windows.Forms.Label label2;
        private Shine.ShineTextBox txt_CodeSenderAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_Close;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.Label lb_TipsInfo;
        private System.Windows.Forms.Label lb_TipsInfo2;
    }
}