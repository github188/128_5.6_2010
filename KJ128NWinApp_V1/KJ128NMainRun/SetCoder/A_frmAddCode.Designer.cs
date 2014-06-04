namespace KJ128NMainRun.SetCoder
{
    partial class A_frmAddCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_frmAddCode));
            this.labCodeMassage = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCodeReturn = new System.Windows.Forms.Button();
            this.btnCodeReSet = new System.Windows.Forms.Button();
            this.btnCodeSave = new System.Windows.Forms.Button();
            this.txtCodeMaxNum = new Shine.ShineTextBox();
            this.txtCodeMinNum = new Shine.ShineTextBox();
            this.txtCodeReMark = new Shine.ShineTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtLowD = new System.Windows.Forms.RadioButton();
            this.rbtLost = new System.Windows.Forms.RadioButton();
            this.rbtBad = new System.Windows.Forms.RadioButton();
            this.rbtZC = new System.Windows.Forms.RadioButton();
            this.chbMulit = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labCodeMassage
            // 
            this.labCodeMassage.AutoSize = true;
            this.labCodeMassage.ForeColor = System.Drawing.Color.Black;
            this.labCodeMassage.Location = new System.Drawing.Point(61, 255);
            this.labCodeMassage.Name = "labCodeMassage";
            this.labCodeMassage.Size = new System.Drawing.Size(53, 12);
            this.labCodeMassage.TabIndex = 18;
            this.labCodeMassage.Text = "保存成功";
            this.labCodeMassage.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(24, 255);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 12);
            this.label14.TabIndex = 17;
            this.label14.Text = "提示:";
            // 
            // btnCodeReturn
            // 
            this.btnCodeReturn.Location = new System.Drawing.Point(320, 275);
            this.btnCodeReturn.Name = "btnCodeReturn";
            this.btnCodeReturn.Size = new System.Drawing.Size(59, 23);
            this.btnCodeReturn.TabIndex = 16;
            this.btnCodeReturn.Text = "返回";
            this.btnCodeReturn.UseVisualStyleBackColor = true;
            this.btnCodeReturn.Click += new System.EventHandler(this.btnCodeReturn_Click);
            // 
            // btnCodeReSet
            // 
            this.btnCodeReSet.Location = new System.Drawing.Point(257, 275);
            this.btnCodeReSet.Name = "btnCodeReSet";
            this.btnCodeReSet.Size = new System.Drawing.Size(59, 23);
            this.btnCodeReSet.TabIndex = 15;
            this.btnCodeReSet.Text = "重置";
            this.btnCodeReSet.UseVisualStyleBackColor = true;
            this.btnCodeReSet.Click += new System.EventHandler(this.btnCodeReSet_Click);
            // 
            // btnCodeSave
            // 
            this.btnCodeSave.Location = new System.Drawing.Point(194, 275);
            this.btnCodeSave.Name = "btnCodeSave";
            this.btnCodeSave.Size = new System.Drawing.Size(59, 23);
            this.btnCodeSave.TabIndex = 14;
            this.btnCodeSave.Text = "保存";
            this.btnCodeSave.UseVisualStyleBackColor = true;
            this.btnCodeSave.Click += new System.EventHandler(this.btnCodeSave_Click);
            // 
            // txtCodeMaxNum
            // 
            this.txtCodeMaxNum.Enabled = false;
            this.txtCodeMaxNum.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCodeMaxNum.Location = new System.Drawing.Point(253, 16);
            this.txtCodeMaxNum.MaxLength = 8;
            this.txtCodeMaxNum.Name = "txtCodeMaxNum";
            this.txtCodeMaxNum.Size = new System.Drawing.Size(58, 21);
            this.txtCodeMaxNum.TabIndex = 24;
            this.txtCodeMaxNum.TextType = Shine.TextType.Number;
            // 
            // txtCodeMinNum
            // 
            this.txtCodeMinNum.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCodeMinNum.Location = new System.Drawing.Point(167, 16);
            this.txtCodeMinNum.MaxLength = 8;
            this.txtCodeMinNum.Name = "txtCodeMinNum";
            this.txtCodeMinNum.Size = new System.Drawing.Size(63, 21);
            this.txtCodeMinNum.TabIndex = 23;
            this.txtCodeMinNum.TextType = Shine.TextType.Number;
            // 
            // txtCodeReMark
            // 
            this.txtCodeReMark.Location = new System.Drawing.Point(52, 157);
            this.txtCodeReMark.Multiline = true;
            this.txtCodeReMark.Name = "txtCodeReMark";
            this.txtCodeReMark.Size = new System.Drawing.Size(313, 61);
            this.txtCodeReMark.TabIndex = 22;
            this.txtCodeReMark.TextType = Shine.TextType.WithOutChar;
            this.txtCodeReMark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodeReMark_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 157);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 21;
            this.label13.Text = "备注";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtLowD);
            this.groupBox3.Controls.Add(this.rbtLost);
            this.groupBox3.Controls.Add(this.rbtBad);
            this.groupBox3.Controls.Add(this.rbtZC);
            this.groupBox3.Location = new System.Drawing.Point(117, 47);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(251, 85);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "状态";
            // 
            // rbtLowD
            // 
            this.rbtLowD.AutoSize = true;
            this.rbtLowD.Location = new System.Drawing.Point(158, 56);
            this.rbtLowD.Name = "rbtLowD";
            this.rbtLowD.Size = new System.Drawing.Size(59, 16);
            this.rbtLowD.TabIndex = 3;
            this.rbtLowD.Text = "低电量";
            this.rbtLowD.UseVisualStyleBackColor = true;
            // 
            // rbtLost
            // 
            this.rbtLost.AutoSize = true;
            this.rbtLost.Location = new System.Drawing.Point(158, 25);
            this.rbtLost.Name = "rbtLost";
            this.rbtLost.Size = new System.Drawing.Size(47, 16);
            this.rbtLost.TabIndex = 2;
            this.rbtLost.Text = "遗失";
            this.rbtLost.UseVisualStyleBackColor = true;
            // 
            // rbtBad
            // 
            this.rbtBad.AutoSize = true;
            this.rbtBad.Location = new System.Drawing.Point(42, 56);
            this.rbtBad.Name = "rbtBad";
            this.rbtBad.Size = new System.Drawing.Size(47, 16);
            this.rbtBad.TabIndex = 1;
            this.rbtBad.Text = "损坏";
            this.rbtBad.UseVisualStyleBackColor = true;
            // 
            // rbtZC
            // 
            this.rbtZC.AutoSize = true;
            this.rbtZC.Checked = true;
            this.rbtZC.Location = new System.Drawing.Point(42, 25);
            this.rbtZC.Name = "rbtZC";
            this.rbtZC.Size = new System.Drawing.Size(47, 16);
            this.rbtZC.TabIndex = 0;
            this.rbtZC.TabStop = true;
            this.rbtZC.Text = "正常";
            this.rbtZC.UseVisualStyleBackColor = true;
            // 
            // chbMulit
            // 
            this.chbMulit.AutoSize = true;
            this.chbMulit.Location = new System.Drawing.Point(317, 18);
            this.chbMulit.Name = "chbMulit";
            this.chbMulit.Size = new System.Drawing.Size(48, 16);
            this.chbMulit.TabIndex = 19;
            this.chbMulit.Text = "批量";
            this.chbMulit.UseVisualStyleBackColor = true;
            this.chbMulit.CheckedChanged += new System.EventHandler(this.chbMulit_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(236, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 18;
            this.label12.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "卡号";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 122);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.txtCodeMaxNum);
            this.groupBox1.Controls.Add(this.txtCodeReMark);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtCodeMinNum);
            this.groupBox1.Controls.Add(this.chbMulit);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(14, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 229);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // A_frmAddCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(404, 316);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labCodeMassage);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnCodeReturn);
            this.Controls.Add(this.btnCodeSave);
            this.Controls.Add(this.btnCodeReSet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "A_frmAddCode";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "标识卡信息";
            this.Load += new System.EventHandler(this.A_frmAddCode_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtLowD;
        private System.Windows.Forms.RadioButton rbtLost;
        private System.Windows.Forms.RadioButton rbtBad;
        private System.Windows.Forms.RadioButton rbtZC;
        private System.Windows.Forms.CheckBox chbMulit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labCodeMassage;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnCodeReturn;
        private System.Windows.Forms.Button btnCodeReSet;
        private System.Windows.Forms.Button btnCodeSave;
        private Shine.ShineTextBox txtCodeMaxNum;
        private Shine.ShineTextBox txtCodeMinNum;
        private Shine.ShineTextBox txtCodeReMark;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}