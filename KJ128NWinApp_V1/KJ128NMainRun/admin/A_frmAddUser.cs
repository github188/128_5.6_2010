using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wilson.BaseClassLibrary.Encoder;

namespace KJ128NMainRun.admin
{
    public partial class A_frmAddUser : Form
    {
        #region【声明】

        private KJ128NDBTable.A_UserBLL bll = new KJ128NDBTable.A_UserBLL();
        private int frmoperator = 0;
        private string UserName = string.Empty;
        private string UG = string.Empty;
        private string Remark = string.Empty;
        private bool IsEnable = true;
        private A_frmUser frmUser;

        #endregion

        #region【构造函数——新增】

        public A_frmAddUser(A_frmUser frm)
        {
            InitializeComponent();
            frmUser = frm;
        }

        #endregion

        #region【构造函数——修改、查看】

        public A_frmAddUser(string username, int op, string ug, bool isenable, string remark, A_frmUser frm)
        {
            InitializeComponent();
            this.frmoperator = op;
            this.UserName = username;
            this.UG = ug;
            this.Remark = remark;
            this.IsEnable = isenable;
            frmUser = frm;
            btnReset.Enabled = false;
        }

        #endregion

        #region【窗体加载】

        private void A_frmAddUser_Load(object sender, EventArgs e)
        {
            LoadUserGroup();
            if (frmoperator == 1)
            {
                txtUsername.Text = this.UserName;
                txtUsername.Enabled = false;
                string password = bll.GetPassWordByUserName(this.UserName);
                txtPassword.Text = password;
                //txtPassword.Enabled = false;
                txtCheckPassword.Text = password;
                //txtCheckPassword.Enabled = false;
                cmbUserGroup.Text = UG;
                chbUserEnable.Checked = IsEnable;
                txtRemark.Text = Remark;
            }
        }

        #endregion

        #region【方法：加载用户组信息】

        private void LoadUserGroup()
        {
            DataTable dt = bll.GetUserGroups();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbUserGroup.AddItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString());
                }
                cmbUserGroup.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("用户组尚未配置,请配置后在做此操作...", "提示", MessageBoxButtons.OK);
                btnSave.Enabled = false;
            }
        }

        #endregion

        #region【事件：重置】

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtUsername.Text = "";
            txtPassword.Text = "";
            txtCheckPassword.Text = "";
            txtRemark.Text = "";
            cmbUserGroup.SelectedIndex = 0;
            chbUserEnable.Checked = true;
        }

        #endregion

        #region【事件：返回】

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region【事件：保存】

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (frmoperator == 0)
            {
                if (txtUsername.Text.Trim().Equals(""))
                {
                    SetTipsInfo(false, "用户名不能为空！");
                    txtUsername.Focus();
                    txtUsername.SelectAll();
                    return;
                }
                if (txtPassword.Text.Trim().Equals(""))
                {
                    SetTipsInfo(false, "密码不能为空！");
                    txtPassword.Focus();
                    txtPassword.SelectAll();
                    return;
                }
                if (txtPassword.Text.Trim() != txtCheckPassword.Text.Trim())
                {
                    SetTipsInfo(false, "确认密码与密码不一致！");
                    txtCheckPassword.Focus();
                    txtCheckPassword.SelectAll();
                    return;
                }
                string error="";
                if (!bll.isExitsUserName(txtUsername.Text))
                {
                    if (bll.insertAdmin(txtUsername.Text, MD5.GetPassword16(txtPassword.Text), txtUsername.Text, chbUserEnable.Checked, false, DateTime.Now, int.Parse(cmbUserGroup.SelectedValue), 0, 0, txtRemark.Text, out error) > 0)
                    {
                        SetTipsInfo(true, "保存成功！");
                        //Czlt-2011-12-10 跟新时间
                        bll.UpdateTime();
                        frmUser.Flash();
                    }
                    else
                    {
                        SetTipsInfo(false, "保存失败！");
                    }
                }
                else
                {
                    SetTipsInfo(false, "用户名已存在！");
                    return;
                }
            }
            if (frmoperator == 1)
            {
                if (txtPassword.Text.Trim().Equals(""))
                {
                    SetTipsInfo(false, "密码不能为空！");
                    txtPassword.Focus();
                    txtPassword.SelectAll();
                    return;
                }
                if (txtPassword.Text.Trim() != txtCheckPassword.Text.Trim())
                {
                    SetTipsInfo(false, "确认密码与密码不一致！");
                    txtCheckPassword.Focus();
                    txtCheckPassword.SelectAll();
                    return;
                }
                int isenable=0;
                if(chbUserEnable.Checked)
                    isenable=1;
                if (bll.UpdateUserByUserName(this.UserName, this.cmbUserGroup.SelectedValue, isenable.ToString(), txtRemark.Text, MD5.GetPassword16(txtPassword.Text)))
                {
                    SetTipsInfo(true, "修改成功！");
                    //Czlt-2011-12-10 跟新时间
                    bll.UpdateTime();

                    frmUser.Flash();
                }
                else
                {
                    SetTipsInfo(false, "修改失败！");
                }
            }
        }

        #endregion

        #region 【方法：设置提示信息】

        private void SetTipsInfo( bool blIsSuccess, string strInfo)
        {
            labMessage.Visible = true;
            labMessage.Text = strInfo;
            if (blIsSuccess)
            {
                labMessage.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                labMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtCheckPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
    }
}
