using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using KJ128NDataBase;

namespace KJ128NMainRun
{
    public partial class A_FrmExit : Form
    {
        public A_FrmExit()
        {
            InitializeComponent();
            this.Visible = false;
        }


        #region【事件：确定】

        private void pbLogin_Click(object sender, EventArgs e)
        {

            if (cb_CloseCom.Checked)
            {
                //关闭通讯程序
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                //不关闭通讯程序，只关闭主界面
                this.DialogResult = DialogResult.No;

            }
        }

        #endregion

        #region【事件：取消】

        private void pbExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        #endregion

        #region【窗体加载】

        private void A_FrmExit_Load(object sender, EventArgs e)
        {
            if (New_DBAcess.blIsClient)
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }
            else
            {
                this.Visible = true;
            }
        }

        #endregion

    }
}
