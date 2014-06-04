using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KJ128NDBTable;
using KJ128NInterfaceShow;
using Wilson.BaseClassLibrary.Encoder;

namespace KJ128NMainRun
{
    public partial class FrmUpDatePassword : Wilson.Controls.Docking.DockContent
    {
        private UpDatePasswordBLL udpbll = new UpDatePasswordBLL();
        private LoginBLL lbll = new LoginBLL();

        public FrmUpDatePassword()
        {
            InitializeComponent();
            txt_UserName.Text = "管理员";
            txt_UserName.Enabled = false;
        }

        #region 修改密码
        private void btn_Login_Click(object sender, EventArgs e)
        {
            string strErr, strPassWord;
            if (!lbll.SearchLoginInfo(txt_UserName.Text.Trim(), MD5.GetPassword16(txtOldPassWord1.Text.Trim()),out strErr))
            {
                MessageBox.Show("旧密码不正确，请重新输入！", "提示", MessageBoxButtons.OK);
                txtOldPassWord1.Focus();
                txtOldPassWord1.SelectAll();
                return;
            }
            if (txtNewPassWord1.Text.Trim() != txtNewPassWord2.Text.Trim())
            {
                MessageBox.Show("密码输入不一致，请重新输入！", "提示", MessageBoxButtons.OK);
                txtNewPassWord2.Focus();
                txtNewPassWord2.SelectAll();
                return;
            }
            strPassWord = MD5.GetPassword16(txtNewPassWord1.Text.Trim());
            strErr = string.Empty;
            udpbll.UpDatePassWord("管理员", strPassWord, out strErr);
            MessageBox.Show(strErr, "提示", MessageBoxButtons.OK);
            this.Close();
            
        }
        #endregion

        #region 取消
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 新密码  KeyPress 事件
        private void txtNewPassWord1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtNewPassWord2.Focus();
                txtNewPassWord2.SelectAll();
            }
        }
        #endregion

        #region 确认新密码 KeyPress 事件
        private void txtNewPassWord2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_Login_Click(sender, e);
            }
        }
        #endregion

        #region 旧密码 KeyPress 事件
        private void txtOldPassWord1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtNewPassWord1.Focus();
                txtNewPassWord1.SelectAll();
            }
        }
        #endregion
    }
}