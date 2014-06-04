namespace KJ128WindowsLibrary
{
    partial class CaptionPanel
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
            this.lblCloseControl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCloseControl
            // 
            this.lblCloseControl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCloseControl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCloseControl.Location = new System.Drawing.Point(116, 9);
            this.lblCloseControl.Name = "lblCloseControl";
            this.lblCloseControl.Size = new System.Drawing.Size(22, 14);
            this.lblCloseControl.TabIndex = 0;
            this.lblCloseControl.Text = "×";
            this.lblCloseControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCloseControl.Visible = false;
            this.lblCloseControl.MouseLeave += new System.EventHandler(this.lblCloseControl_MouseLeave);
            this.lblCloseControl.Click += new System.EventHandler(this.lblCloseControl_Click);
            this.lblCloseControl.Leave += new System.EventHandler(this.lblCloseControl_Leave);
            this.lblCloseControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblCloseControl_MouseDown);
            this.lblCloseControl.Enter += new System.EventHandler(this.lblCloseControl_Enter);
            this.lblCloseControl.MouseEnter += new System.EventHandler(this.lblCloseControl_MouseEnter);
            // 
            // CaptionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblCloseControl);
            this.DoubleBuffered = true;
            this.Name = "CaptionPanel";
            this.Size = new System.Drawing.Size(138, 104);
            this.Load += new System.EventHandler(this.CaptionPanel_Load);
            this.Resize += new System.EventHandler(this.CaptionPanel_Resize);
            this.SizeChanged += new System.EventHandler(this.CaptionPanel_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCloseControl;
    }
}
