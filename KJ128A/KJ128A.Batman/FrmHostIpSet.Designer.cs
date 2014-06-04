namespace KJ128A.Batman
{
    partial class FrmHostIpSet
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ckbStartHost = new System.Windows.Forms.CheckBox();
            this.gpbMax = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnHost = new System.Windows.Forms.RadioButton();
            this.rbtnBack = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ttpMessage = new System.Windows.Forms.ToolTip(this.components);
            this.gpbMax.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckbStartHost
            // 
            this.ckbStartHost.AutoSize = true;
            this.ckbStartHost.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbStartHost.ForeColor = System.Drawing.Color.Black;
            this.ckbStartHost.Location = new System.Drawing.Point(18, 7);
            this.ckbStartHost.Name = "ckbStartHost";
            this.ckbStartHost.Size = new System.Drawing.Size(86, 18);
            this.ckbStartHost.TabIndex = 20;
            this.ckbStartHost.Text = "启用热备";
            this.ckbStartHost.UseVisualStyleBackColor = true;
            this.ckbStartHost.CheckedChanged += new System.EventHandler(this.ckbStartHost_CheckedChanged);
            // 
            // gpbMax
            // 
            this.gpbMax.Controls.Add(this.groupBox2);
            this.gpbMax.Controls.Add(this.groupBox1);
            this.gpbMax.Location = new System.Drawing.Point(6, 11);
            this.gpbMax.Name = "gpbMax";
            this.gpbMax.Size = new System.Drawing.Size(254, 124);
            this.gpbMax.TabIndex = 19;
            this.gpbMax.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnHost);
            this.groupBox2.Controls.Add(this.rbtnBack);
            this.groupBox2.Location = new System.Drawing.Point(0, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 42);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // rbtnHost
            // 
            this.rbtnHost.AutoSize = true;
            this.rbtnHost.Checked = true;
            this.rbtnHost.Location = new System.Drawing.Point(47, 20);
            this.rbtnHost.Name = "rbtnHost";
            this.rbtnHost.Size = new System.Drawing.Size(47, 16);
            this.rbtnHost.TabIndex = 0;
            this.rbtnHost.TabStop = true;
            this.rbtnHost.Text = "主机";
            this.rbtnHost.UseVisualStyleBackColor = true;
            // 
            // rbtnBack
            // 
            this.rbtnBack.AutoSize = true;
            this.rbtnBack.Location = new System.Drawing.Point(155, 20);
            this.rbtnBack.Name = "rbtnBack";
            this.rbtnBack.Size = new System.Drawing.Size(47, 16);
            this.rbtnBack.TabIndex = 1;
            this.rbtnBack.TabStop = true;
            this.rbtnBack.Text = "备机";
            this.rbtnBack.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIpAddress);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 78);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(70, 53);
            this.txtPort.MaxLength = 5;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(156, 21);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "60001";
            this.txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPort_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 39);
            this.label2.TabIndex = 5;
            this.label2.Text = "对方监听端口号:";
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Location = new System.Drawing.Point(70, 17);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(156, 21);
            this.txtIpAddress.TabIndex = 2;
            this.txtIpAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIpAddress_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "对方IP:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(29, 141);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(67, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(161, 141);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "重置";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ttpMessage
            // 
            this.ttpMessage.AutoPopDelay = 3000;
            this.ttpMessage.InitialDelay = 500;
            this.ttpMessage.IsBalloon = true;
            this.ttpMessage.ReshowDelay = 100;
            this.ttpMessage.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.ttpMessage.ToolTipTitle = "操作错误";
            // 
            // FrmHostIpSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 171);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ckbStartHost);
            this.Controls.Add(this.gpbMax);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHostIpSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置热备信息";
            this.Load += new System.EventHandler(this.FrmHostIpSet_Load);
            this.gpbMax.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbStartHost;
        private System.Windows.Forms.GroupBox gpbMax;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnHost;
        private System.Windows.Forms.RadioButton rbtnBack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip ttpMessage;
    }
}