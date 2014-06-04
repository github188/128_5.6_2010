namespace KJ128NMainRun.EquManage
{
    partial class A_frmAddFactory
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
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.labMessage = new System.Windows.Forms.Label();
            this.labTT = new System.Windows.Forms.Label();
            this.gb_AddFactory = new System.Windows.Forms.GroupBox();
            this.txtFremark = new Shine.ShineTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFaddress = new Shine.ShineTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFemptel = new Shine.ShineTextBox();
            this.txtFemp = new Shine.ShineTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFfex = new Shine.ShineTextBox();
            this.txtFtel = new Shine.ShineTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtFName = new Shine.ShineTextBox();
            this.txtFNo = new Shine.ShineTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_AddFactory.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(317, 227);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(56, 23);
            this.btnReturn.TabIndex = 21;
            this.btnReturn.Text = "返回";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(255, 227);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(56, 23);
            this.btnReset.TabIndex = 20;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(195, 227);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.ForeColor = System.Drawing.Color.Black;
            this.labMessage.Location = new System.Drawing.Point(47, 208);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(53, 12);
            this.labMessage.TabIndex = 18;
            this.labMessage.Text = "保存成功";
            this.labMessage.Visible = false;
            // 
            // labTT
            // 
            this.labTT.AutoSize = true;
            this.labTT.Location = new System.Drawing.Point(12, 208);
            this.labTT.Name = "labTT";
            this.labTT.Size = new System.Drawing.Size(35, 12);
            this.labTT.TabIndex = 17;
            this.labTT.Text = "提示:";
            // 
            // gb_AddFactory
            // 
            this.gb_AddFactory.Controls.Add(this.txtFremark);
            this.gb_AddFactory.Controls.Add(this.label6);
            this.gb_AddFactory.Controls.Add(this.txtFaddress);
            this.gb_AddFactory.Controls.Add(this.label5);
            this.gb_AddFactory.Controls.Add(this.txtFemptel);
            this.gb_AddFactory.Controls.Add(this.txtFemp);
            this.gb_AddFactory.Controls.Add(this.label3);
            this.gb_AddFactory.Controls.Add(this.label4);
            this.gb_AddFactory.Controls.Add(this.txtFfex);
            this.gb_AddFactory.Controls.Add(this.txtFtel);
            this.gb_AddFactory.Controls.Add(this.label23);
            this.gb_AddFactory.Controls.Add(this.label24);
            this.gb_AddFactory.Controls.Add(this.label20);
            this.gb_AddFactory.Controls.Add(this.label15);
            this.gb_AddFactory.Controls.Add(this.txtFName);
            this.gb_AddFactory.Controls.Add(this.txtFNo);
            this.gb_AddFactory.Controls.Add(this.label1);
            this.gb_AddFactory.Controls.Add(this.label2);
            this.gb_AddFactory.Location = new System.Drawing.Point(12, 12);
            this.gb_AddFactory.Name = "gb_AddFactory";
            this.gb_AddFactory.Size = new System.Drawing.Size(363, 182);
            this.gb_AddFactory.TabIndex = 22;
            this.gb_AddFactory.TabStop = false;
            // 
            // txtFremark
            // 
            this.txtFremark.Location = new System.Drawing.Point(69, 148);
            this.txtFremark.MaxLength = 100;
            this.txtFremark.Name = "txtFremark";
            this.txtFremark.Size = new System.Drawing.Size(275, 21);
            this.txtFremark.TabIndex = 76;
            this.txtFremark.TextType = Shine.TextType.WithOutChar;
            this.txtFremark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFremark_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 75;
            this.label6.Text = "备注：";
            // 
            // txtFaddress
            // 
            this.txtFaddress.Location = new System.Drawing.Point(69, 116);
            this.txtFaddress.MaxLength = 80;
            this.txtFaddress.Name = "txtFaddress";
            this.txtFaddress.Size = new System.Drawing.Size(275, 21);
            this.txtFaddress.TabIndex = 74;
            this.txtFaddress.TextType = Shine.TextType.WithOutChar;
            this.txtFaddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFaddress_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 73;
            this.label5.Text = "厂址：";
            // 
            // txtFemptel
            // 
            this.txtFemptel.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtFemptel.Location = new System.Drawing.Point(247, 86);
            this.txtFemptel.MaxLength = 20;
            this.txtFemptel.Name = "txtFemptel";
            this.txtFemptel.Size = new System.Drawing.Size(97, 21);
            this.txtFemptel.TabIndex = 72;
            this.txtFemptel.TextType = Shine.TextType.Number;
            this.txtFemptel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFemptel_KeyPress_1);
            // 
            // txtFemp
            // 
            this.txtFemp.Location = new System.Drawing.Point(69, 86);
            this.txtFemp.MaxLength = 20;
            this.txtFemp.Name = "txtFemp";
            this.txtFemp.Size = new System.Drawing.Size(86, 21);
            this.txtFemp.TabIndex = 71;
            this.txtFemp.TextType = Shine.TextType.WithOutChar;
            this.txtFemp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFemp_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 69;
            this.label3.Text = "联系人：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 70;
            this.label4.Text = "联系人电话：";
            // 
            // txtFfex
            // 
            this.txtFfex.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtFfex.Location = new System.Drawing.Point(247, 54);
            this.txtFfex.MaxLength = 20;
            this.txtFfex.Name = "txtFfex";
            this.txtFfex.Size = new System.Drawing.Size(97, 21);
            this.txtFfex.TabIndex = 68;
            this.txtFfex.TextType = Shine.TextType.Number;
            this.txtFfex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFfex_KeyPress_1);
            // 
            // txtFtel
            // 
            this.txtFtel.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtFtel.Location = new System.Drawing.Point(69, 54);
            this.txtFtel.MaxLength = 20;
            this.txtFtel.Name = "txtFtel";
            this.txtFtel.Size = new System.Drawing.Size(86, 21);
            this.txtFtel.TabIndex = 67;
            this.txtFtel.TextType = Shine.TextType.Number;
            this.txtFtel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFtel_KeyPress_1);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(22, 57);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 12);
            this.label23.TabIndex = 65;
            this.label23.Text = "电话：";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(200, 57);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 12);
            this.label24.TabIndex = 66;
            this.label24.Text = "传真：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(190, 25);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(11, 12);
            this.label20.TabIndex = 64;
            this.label20.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(11, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 12);
            this.label15.TabIndex = 63;
            this.label15.Text = "*";
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(247, 22);
            this.txtFName.MaxLength = 50;
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(97, 21);
            this.txtFName.TabIndex = 62;
            this.txtFName.TextType = Shine.TextType.WithOutChar;
            this.txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFName_KeyPress);
            // 
            // txtFNo
            // 
            this.txtFNo.Location = new System.Drawing.Point(69, 22);
            this.txtFNo.MaxLength = 10;
            this.txtFNo.Name = "txtFNo";
            this.txtFNo.Size = new System.Drawing.Size(86, 21);
            this.txtFNo.TabIndex = 61;
            this.txtFNo.TextType = Shine.TextType.WithOutChar;
            this.txtFNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFNo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 59;
            this.label1.Text = "编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 60;
            this.label2.Text = "名称：";
            // 
            // A_frmAddFactory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(385, 265);
            this.Controls.Add(this.gb_AddFactory);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labMessage);
            this.Controls.Add(this.labTT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "A_frmAddFactory";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增设备生产厂家";
            this.Load += new System.EventHandler(this.A_frmAddFactory_Load);
            this.gb_AddFactory.ResumeLayout(false);
            this.gb_AddFactory.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Label labTT;
        private System.Windows.Forms.GroupBox gb_AddFactory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Shine.ShineTextBox txtFremark;
        private Shine.ShineTextBox txtFaddress;
        private Shine.ShineTextBox txtFemptel;
        private Shine.ShineTextBox txtFemp;
        private Shine.ShineTextBox txtFfex;
        private Shine.ShineTextBox txtFtel;
        private Shine.ShineTextBox txtFName;
        private Shine.ShineTextBox txtFNo;

    }
}