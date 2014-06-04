using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NMainRun.A_RTAlarm
{
    public partial class A_FrmRTAlarm_unchainCheckCards : Form
    {
        #region【声明】

        private A_RTAlarmBLL rta = new A_RTAlarmBLL();

        #endregion

        #region 【构造函数】
        public A_FrmRTAlarm_unchainCheckCards(string strCodeSenderAddress, string strName)
        {
            InitializeComponent();
            txtCoderAddress.Text = strCodeSenderAddress;
            txtName.Text = strName;
        }
        #endregion

        #region 【事件方法：点击解除唯一性报警按钮】
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                rta.UnchainRTOnlyone(txtCoderAddress.Text.Trim(),txtName.Text.Trim());
                this.DialogResult = DialogResult.Yes;
            }
            catch { }
            this.Close();
        }
        #endregion

        #region 【事件方法：点击取消按钮】
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
