using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NMainRun
{
    public partial class A_FrmValidate : Form
    {

        #region 【自定义属性】
        //是否通过密码验证
        private bool m_isValidate;
        /// <summary>
        /// 是否通过密码验证
        /// </summary>
        public bool IsValidate
        {
            get { return m_isValidate; }
            set { m_isValidate = value; }
        }

        #endregion

        #region 【自定义参数】
        private LoginBLL lbll = new LoginBLL();
        #endregion

        #region 【构造函数】
        public A_FrmValidate()
        {
            InitializeComponent();
            lbll.getUsername(this.cbx_UserName);
        }
        #endregion

        #region 【事件方法：验证用户密码】
        private void pbLogin_Click(object sender, EventArgs e)
        {
            GetValidate();
        }
        
        private void txt_UserPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                GetValidate();
            }
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
        #endregion

        #region 【事件方法：退出窗体】
        private void pbExit_Click(object sender, EventArgs e)
        {
            m_isValidate = false;
            this.Close();
        }
        #endregion

        #region 【方法：验证用户和密码】
        /// <summary>
        /// 验证用户和密码
        /// </summary>
        /// <returns></returns>
        private void GetValidate()
        {
            if (cbx_UserName.Text.Trim().Equals(LoginBLL.user) && txt_UserPassWord.Text.Trim().Equals(LoginBLL.pwd))   //输入密码正确
            {
                m_isValidate = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("输入的用户名或密码不正确,请重新输入!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_isValidate = false;
            }
        }
        #endregion
    }
}
