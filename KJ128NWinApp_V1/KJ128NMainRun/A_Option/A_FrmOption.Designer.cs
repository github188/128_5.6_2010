namespace KJ128NMainRun.A_Option
{
    partial class A_FrmOption
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.AlertName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlertType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectPath = new System.Windows.Forms.DataGridViewButtonColumn();
            this.test = new System.Windows.Forms.DataGridViewButtonColumn();
            this.alterValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(720, 41);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 315);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(720, 84);
            this.pnlBottom.TabIndex = 1;
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToResizeColumns = false;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AlertName,
            this.AlertType,
            this.Path,
            this.selectPath,
            this.test,
            this.alterValue});
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(0, 41);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.Size = new System.Drawing.Size(720, 274);
            this.dgvMain.TabIndex = 2;
            this.dgvMain.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellValueChanged);
            this.dgvMain.Sorted += new System.EventHandler(this.dgvMain_Sorted);
            this.dgvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellContentClick);
            // 
            // AlertName
            // 
            this.AlertName.DataPropertyName = "AlertName";
            this.AlertName.FillWeight = 40F;
            this.AlertName.HeaderText = "报警名称";
            this.AlertName.Name = "AlertName";
            this.AlertName.ReadOnly = true;
            this.AlertName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AlertType
            // 
            this.AlertType.FillWeight = 30F;
            this.AlertType.HeaderText = "报警声音类别";
            this.AlertType.Items.AddRange(new object[] {
            "无声",
            "默认",
            "自定义"});
            this.AlertType.Name = "AlertType";
            // 
            // Path
            // 
            this.Path.FillWeight = 130.0374F;
            this.Path.HeaderText = "报警声音路径";
            this.Path.Name = "Path";
            this.Path.ReadOnly = true;
            this.Path.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // selectPath
            // 
            this.selectPath.FillWeight = 15F;
            this.selectPath.HeaderText = "选择路径";
            this.selectPath.Name = "selectPath";
            this.selectPath.ReadOnly = true;
            this.selectPath.Text = "...";
            this.selectPath.UseColumnTextForButtonValue = true;
            // 
            // test
            // 
            this.test.FillWeight = 20F;
            this.test.HeaderText = "测试";
            this.test.Name = "test";
            this.test.Text = "测试";
            this.test.UseColumnTextForButtonValue = true;
            // 
            // alterValue
            // 
            this.alterValue.DataPropertyName = "AlertValue";
            this.alterValue.HeaderText = "报警值";
            this.alterValue.Name = "alterValue";
            // 
            // A_FrmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 399);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "A_FrmOption";
            this.TabText = "报警声音选项";
            this.Text = "报警声音选项";
            this.Load += new System.EventHandler(this.A_FrmOption_Load);
            this.DockStateChanged += new System.EventHandler(this.A_FrmOption_DockStateChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlertName;
        private System.Windows.Forms.DataGridViewComboBoxColumn AlertType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Path;
        private System.Windows.Forms.DataGridViewButtonColumn selectPath;
        private System.Windows.Forms.DataGridViewButtonColumn test;
        private System.Windows.Forms.DataGridViewTextBoxColumn alterValue;
    }
}