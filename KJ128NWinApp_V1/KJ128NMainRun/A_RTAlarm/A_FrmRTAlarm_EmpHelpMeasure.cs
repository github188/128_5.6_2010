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
    public partial class A_FrmRTAlarm_EmpHelpMeasure : Form
    {

        #region【声明】

        private A_RTAlarmBLL rta = new A_RTAlarmBLL();

        #endregion

        #region【构造函数】

        public A_FrmRTAlarm_EmpHelpMeasure(string strCodeSenderAddress,string strName)
        {
            InitializeComponent();
            txt_CodeSenderAddress.Text = strCodeSenderAddress;
            txt_EmpName.Text = strName;
        }

        #endregion

        #region【事件：完成】

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (txt_Measure.Text.Trim().Equals(""))
            {
                lb_TipsInfo.Visible = true;
                lb_TipsInfo.Text = "救援措施不能为空！";
                lb_TipsInfo.ForeColor = Color.Red;
                return;
            }
            try
            {
                rta.DeleteRTEmpHelp(txt_CodeSenderAddress.Text.Trim(), txt_Measure.Text.Trim());
                this.DialogResult = DialogResult.Yes;
            }
            catch{}
            this.Close();
        }

        #endregion

        #region【事件：返回】

        private void bt_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
