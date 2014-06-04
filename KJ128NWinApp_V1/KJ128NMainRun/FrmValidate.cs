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
    public partial class FrmValidate : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]

        //是否通过密码验证
        private bool isValidate;

        /// <summary>
        /// 是否通过密码验证
        /// </summary>
        public bool IsValidate
        {
            get { return isValidate; }
            set { isValidate = value; }
        }

        #endregion

        #region [ 构造函数 ]

        public FrmValidate()
        {
            InitializeComponent();
            this.Hide();
        }

        #endregion

        #region [ 方法: 验证用户密码 ]

        private void GetValidate()
        {
            if (txtPassWord.Text.Trim().Equals(LoginBLL.pwd))   //输入密码正确
            {
                isValidate = true;
            }
            else
            {
                MessageBox.Show("输入的密码不正确,无法配置信息!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isValidate = false;
            }
            this.Close();
        }

        #endregion

        #region [ 事件: 窗体加载 ]

        private void FrmValidate_Load(object sender, EventArgs e)
        {
            if (LoginBLL.user.Equals("guest"))
            {
                MessageBox.Show("尚未登录，请登录后再配置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }

            txt_UserName.Text = LoginBLL.user;
        }

        #endregion

        #region [ 事件: 键盘按键事件 ]

        private void txtPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)    //用户按下回车
            {
                GetValidate();
            }
        }

        #endregion

        #region [ 事件: 确定按钮_Click事件 ]

        private void button1_Click(object sender, EventArgs e)
        {
            GetValidate();
        }

        #endregion

        #region [ 事件: 退出按钮_Click事件]

        private void button2_Click(object sender, EventArgs e)
        {
            isValidate = false;
            this.Close();
        }

        #endregion

        #region 鼠标经过效果

        private void pbLogin_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox1.Image = global::KJ128NMainRun.Properties.Resources._06;
        }

        private void pbLogin_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.Image = global::KJ128NMainRun.Properties.Resources._3;
        }

        private void pbExit_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = global::KJ128NMainRun.Properties.Resources._07;
        }

        private void pbExit_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = global::KJ128NMainRun.Properties.Resources._5;
        }

        private void pbClose_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = global::KJ128NMainRun.Properties.Resources._6;
        }

        private void pbClose_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = global::KJ128NMainRun.Properties.Resources._09;
        }

        #endregion

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}