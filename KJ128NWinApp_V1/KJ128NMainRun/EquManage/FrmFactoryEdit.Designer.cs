namespace KJ128NMainRun.EquManage
{
    partial class FrmFactoryEdit
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCanel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFactoryEmployee = new Shine.ShineTextBox();
            this.txtFactoryFax = new KJ128N.Command.TxtNumber();// Shine.ShineTextBox();
            this.txtFactoryTel = new KJ128N.Command.TxtNumber();// Shine.ShineTextBox();
            this.txtFactoryAddress = new Shine.ShineTextBox();
            this.txtFactoryName = new Shine.ShineTextBox();
            this.txtFactoryNO = new Shine.ShineTextBox();
            this.txtFactoryEmpoyeeTel = new KJ128N.Command.TxtNumber();// Shine.ShineTextBox();
            this.txtRemark = new Shine.ShineTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(71, 431);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(91, 23);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCanel
            // 
            this.btnCanel.Location = new System.Drawing.Point(190, 431);
            this.btnCanel.Name = "btnCanel";
            this.btnCanel.Size = new System.Drawing.Size(91, 23);
            this.btnCanel.TabIndex = 10;
            this.btnCanel.Text = "清除";
            this.btnCanel.UseVisualStyleBackColor = true;
            this.btnCanel.Click += new System.EventHandler(this.btnCanel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "厂家编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "厂家名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "厂家地址";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "联系电话";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "联系人";
            // 
            // txtFactoryEmployee
            // 
            this.txtFactoryEmployee.Location = new System.Drawing.Point(126, 266);
            this.txtFactoryEmployee.MaxLength = 50;
            this.txtFactoryEmployee.Name = "txtFactoryEmployee";
            this.txtFactoryEmployee.Size = new System.Drawing.Size(283, 21);
            this.txtFactoryEmployee.TabIndex = 6;
            // 
            // txtFactoryFax
            // 
            this.txtFactoryFax.Location = new System.Drawing.Point(126, 229);
            this.txtFactoryFax.MaxLength = 20;
            this.txtFactoryFax.Name = "txtFactoryFax";
            this.txtFactoryFax.Size = new System.Drawing.Size(283, 21);
            this.txtFactoryFax.TabIndex = 5;
            // 
            // txtFactoryTel
            // 
            this.txtFactoryTel.Location = new System.Drawing.Point(126, 193);
            this.txtFactoryTel.MaxLength = 20;
            this.txtFactoryTel.Name = "txtFactoryTel";
            this.txtFactoryTel.Size = new System.Drawing.Size(283, 21);
            this.txtFactoryTel.TabIndex = 4;
            // 
            // txtFactoryAddress
            // 
            this.txtFactoryAddress.Location = new System.Drawing.Point(126, 105);
            this.txtFactoryAddress.MaxLength = 80;
            this.txtFactoryAddress.Multiline = true;
            this.txtFactoryAddress.Name = "txtFactoryAddress";
            this.txtFactoryAddress.Size = new System.Drawing.Size(283, 66);
            this.txtFactoryAddress.TabIndex = 3;
            // 
            // txtFactoryName
            // 
            this.txtFactoryName.Location = new System.Drawing.Point(126, 63);
            this.txtFactoryName.MaxLength = 50;
            this.txtFactoryName.Name = "txtFactoryName";
            this.txtFactoryName.Size = new System.Drawing.Size(283, 21);
            this.txtFactoryName.TabIndex = 2;
            // 
            // txtFactoryNO
            // 
            this.txtFactoryNO.Location = new System.Drawing.Point(126, 20);
            this.txtFactoryNO.MaxLength = 10;
            this.txtFactoryNO.Name = "txtFactoryNO";
            this.txtFactoryNO.Size = new System.Drawing.Size(283, 21);
            this.txtFactoryNO.TabIndex = 1;
            // 
            // txtFactoryEmpoyeeTel
            // 
            this.txtFactoryEmpoyeeTel.Location = new System.Drawing.Point(126, 305);
            this.txtFactoryEmpoyeeTel.MaxLength = 20;
            this.txtFactoryEmpoyeeTel.Name = "txtFactoryEmpoyeeTel";
            this.txtFactoryEmpoyeeTel.Size = new System.Drawing.Size(283, 21);
            this.txtFactoryEmpoyeeTel.TabIndex = 7;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(126, 345);
            this.txtRemark.MaxLength = 100;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(283, 68);
            this.txtRemark.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 308);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "联系人电话";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "备 注";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "厂家传真";
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(306, 431);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(91, 23);
            this.btnReturn.TabIndex = 11;
            this.btnReturn.Text = "返回";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // FrmFactoryEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(443, 497);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtFactoryEmpoyeeTel);
            this.Controls.Add(this.txtFactoryNO);
            this.Controls.Add(this.txtFactoryName);
            this.Controls.Add(this.txtFactoryAddress);
            this.Controls.Add(this.txtFactoryTel);
            this.Controls.Add(this.txtFactoryFax);
            this.Controls.Add(this.txtFactoryEmployee);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCanel);
            this.Controls.Add(this.btnEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFactoryEdit";
            this.TabText = "drhy";
            this.Text = "drhy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFactoryEmployee;
        private System.Windows.Forms.TextBox txtFactoryFax;
        private System.Windows.Forms.TextBox txtFactoryTel;
        private System.Windows.Forms.TextBox txtFactoryAddress;
        private System.Windows.Forms.TextBox txtFactoryName;
        private System.Windows.Forms.TextBox txtFactoryNO;
        private System.Windows.Forms.TextBox txtFactoryEmpoyeeTel;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnReturn;
    }
}