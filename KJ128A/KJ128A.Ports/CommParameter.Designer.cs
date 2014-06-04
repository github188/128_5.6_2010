namespace KJ128A.Ports
{
    partial class CommParameter
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
            this.chkInvo = new System.Windows.Forms.CheckBox();
            this.gpbPort = new System.Windows.Forms.GroupBox();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCommState = new System.Windows.Forms.Label();
            this.btnOpenClose = new System.Windows.Forms.Button();
            this.cmbMark = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.cmbCommPort = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbPort.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkInvo
            // 
            this.chkInvo.AutoSize = true;
            this.chkInvo.Location = new System.Drawing.Point(3, 19);
            this.chkInvo.Name = "chkInvo";
            this.chkInvo.Size = new System.Drawing.Size(48, 16);
            this.chkInvo.TabIndex = 0;
            this.chkInvo.Text = "启用";
            this.chkInvo.UseVisualStyleBackColor = true;
            this.chkInvo.CheckedChanged += new System.EventHandler(this.chkInvo_CheckedChanged);
            // 
            // gpbPort
            // 
            this.gpbPort.Controls.Add(this.cmbGroup);
            this.gpbPort.Controls.Add(this.label4);
            this.gpbPort.Controls.Add(this.lblCommState);
            this.gpbPort.Controls.Add(this.btnOpenClose);
            this.gpbPort.Controls.Add(this.cmbMark);
            this.gpbPort.Controls.Add(this.cmbBaudRate);
            this.gpbPort.Controls.Add(this.cmbCommPort);
            this.gpbPort.Controls.Add(this.label3);
            this.gpbPort.Controls.Add(this.label2);
            this.gpbPort.Controls.Add(this.label1);
            this.gpbPort.Enabled = false;
            this.gpbPort.Location = new System.Drawing.Point(51, 1);
            this.gpbPort.Name = "gpbPort";
            this.gpbPort.Size = new System.Drawing.Size(712, 44);
            this.gpbPort.TabIndex = 1;
            this.gpbPort.TabStop = false;
            // 
            // cmbGroup
            // 
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cmbGroup.Location = new System.Drawing.Point(456, 16);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(64, 20);
            this.cmbGroup.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(388, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "传输分站组";
            // 
            // lblCommState
            // 
            this.lblCommState.AutoSize = true;
            this.lblCommState.Location = new System.Drawing.Point(629, 18);
            this.lblCommState.Name = "lblCommState";
            this.lblCommState.Size = new System.Drawing.Size(77, 12);
            this.lblCommState.TabIndex = 7;
            this.lblCommState.Text = "串口关闭状态";
            // 
            // btnOpenClose
            // 
            this.btnOpenClose.Location = new System.Drawing.Point(548, 14);
            this.btnOpenClose.Name = "btnOpenClose";
            this.btnOpenClose.Size = new System.Drawing.Size(75, 23);
            this.btnOpenClose.TabIndex = 6;
            this.btnOpenClose.Text = "打开串口";
            this.btnOpenClose.UseVisualStyleBackColor = true;
            this.btnOpenClose.Click += new System.EventHandler(this.btnOpenClose_Click);
            // 
            // cmbMark
            // 
            this.cmbMark.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMark.FormattingEnabled = true;
            this.cmbMark.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cmbMark.Location = new System.Drawing.Point(320, 17);
            this.cmbMark.Name = "cmbMark";
            this.cmbMark.Size = new System.Drawing.Size(63, 20);
            this.cmbMark.TabIndex = 5;
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400"});
            this.cmbBaudRate.Location = new System.Drawing.Point(184, 17);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(63, 20);
            this.cmbBaudRate.TabIndex = 4;
            // 
            // cmbCommPort
            // 
            this.cmbCommPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCommPort.FormattingEnabled = true;
            this.cmbCommPort.Location = new System.Drawing.Point(48, 16);
            this.cmbCommPort.Name = "cmbCommPort";
            this.cmbCommPort.Size = new System.Drawing.Size(63, 20);
            this.cmbCommPort.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "标志位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号";
            // 
            // CommParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpbPort);
            this.Controls.Add(this.chkInvo);
            this.Name = "CommParameter";
            this.Size = new System.Drawing.Size(772, 50);
            this.gpbPort.ResumeLayout(false);
            this.gpbPort.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkInvo;
        private System.Windows.Forms.GroupBox gpbPort;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.ComboBox cmbCommPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenClose;
        private System.Windows.Forms.ComboBox cmbMark;
        private System.Windows.Forms.Label lblCommState;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label label4;
    }
}
