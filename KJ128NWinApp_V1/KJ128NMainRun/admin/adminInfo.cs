using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using Wilson.BaseClassLibrary.Encoder;
using Shine.Logs;
using Shine.Logs.LogType;
using KJ128NDataBase;

namespace KJ128NInterfaceShow
{
    public partial class adminInfo : Wilson.Controls.Docking.DockContent
    {
        private string strErr = string.Empty;
        //NetTraner nt = new NetTraner("192.168.1.59", 8080, 6020);
        public adminInfo()
        {
           // KJ128NInterfaceShow.DataGridViewKJ128 dtgAccount = new KJ128NInterfaceShow.DataGridViewKJ128();
            
            InitializeComponent();
            //this.monthCalendar1.Visible = false;
        }
        AdminsBLL bll = new AdminsBLL();

        #region 绑定用户信息
        private void dgv_adminbinding()
        {
            string err;
            DataSet DS = bll.getAccountAll( out err);
            dtgAccount1.DataSource = DS.Tables[0].DefaultView;
            dtgAccount1.Columns["Passwordback"].Visible = false;
       }
        #endregion 

        #region 绑定用户组

        public void cbx_Databind()
        {
            UserGroupBLL groupbll = new UserGroupBLL();
            groupbll.setCboUserGroup(this.cbx_UserGroup);
            groupbll.setCboUserGroup(this.cbxUserGroup);
        }
       #endregion 

        #region 登陆
        private void adminInfo_Load(object sender, EventArgs e)
        {
            dgv_adminbinding();
            cbx_Databind();
            this.panel1.Visible = false;

        }
        #endregion 

        #region dtgAccouns事件
        private int id = -1;
        private void dtgAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             int a = e.RowIndex;
             this.panel1.Visible = false;
              txtUserName.Text = "";
              cbxIsUse1.Checked = true;
              dateTimePicker2.Value = DateTime.Now;
              cbxIsEndDate.Checked = false;
              txtRemark1.Text = "";
             // string cc =dtgAccount1.Rows[a].Cells["ids"].Value.ToString();

             if (e.ColumnIndex == 0&& e.RowIndex >= 0)
             {

                 id = int.Parse(dtgAccount1.Rows[a].Cells["ids"].Value.ToString());
                 txtUserName.Text = this.dtgAccount1.Rows[a].Cells["Account"].Value.ToString();
                 txtPassword1.Text = dtgAccount1.Rows[a].Cells["Passwordback"].Value.ToString();
                 txtPasswordn1.Text = dtgAccount1.Rows[a].Cells["Passwordback"].Value.ToString();
                 cbxUserGroup.SelectedIndex = cbxUserGroup.FindString(this.dtgAccount1.Rows[a].Cells["UgName"].Value.ToString());
                 cbxIsUse1.Checked = Convert.ToBoolean(dtgAccount1.Rows[a].Cells["IsEnable"].Value);
                 dateTimePicker2.Value = Convert.ToDateTime(dtgAccount1.Rows[a].Cells["UseEndDate"].Value);
                 cbxIsEndDate.Checked = Convert.ToBoolean(dtgAccount1.Rows[a].Cells["IsUseEndDate"].Value);
                 txtRemark1.Text = this.dtgAccount1.Rows[a].Cells["remark"].Value.ToString();
                 panel1.Visible = true;
             }
             else
             {
                 if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                 {
                     if (dtgAccount1.Rows[e.RowIndex].Cells["Account"].Value.ToString() != LoginBLL.user)
                     {
                         id = int.Parse(dtgAccount1.Rows[a].Cells["ids"].Value.ToString());
                         if (MessageBox.Show("你确定要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                         {
                             //存入日志
                             LogSave.Messages("[adminInfo]", LogIDType.UserLogID, "删除用户，添加的姓名为：" + dtgAccount1.Rows[e.RowIndex].Cells["Account"].Value.ToString());
                             
                             deleteData(id);
                         }
                     }
                     else
                     {
                         MessageBox.Show("不能删除使用中的用户!");
                     }
                 }
             }
         }
        #endregion 

        #region 保存数据
        private void buttonCaptionPanel3_Load(object sender, EventArgs e)
        {
            //存入日志
            LogSave.Messages("[adminInfo]", LogIDType.UserLogID, "添加用户，添加的用户名为：" + txtUser.Text.ToString() + "。");

            if (txtUser.Text.Trim() == "")
            { 
                MessageBox.Show("用户名不能为空");
                txtUser.Focus();
                return;
            }
            if (lbIssame.Text.Trim() != "")
            {
                return;
            }

            if (txtPasswordn.Text.Trim() != txtPassword.Text.Trim())
            {
                MessageBox.Show("密码一致，请重新输入密码");
                txtPasswordn.Text = "";
                txtPasswordn.Text = "";
                txtPassword.Focus();
                return;
            }
            int Uid =-1;
            if (cbx_UserGroup.SelectedValue!=null)
            {
                Uid = int.Parse(cbx_UserGroup.SelectedValue.ToString().Trim());
            }
            else 
            {
                MessageBox.Show("该用户组不存在!");
                return;
            }
            string strPassWord = MD5.GetPassword16( txtPassword.Text.Trim());

            operated = 1;

            if (bll.insertAdmin(txtUser.Text, strPassWord, txtPassword.Text.Trim(), cbxIsUse1.Checked, cbxIsEndDate.Checked, dateTimePicker2.Value, Uid, 0, 0, txtRemark1.Text, out strErr) > 0)
            {
                MessageBox.Show("用户添加成功!");
            }
            else
            {
                MessageBox.Show("用户添加失败!");
            }

            if (!New_DBAcess.IsDouble)
            {
                adminInfo_Load(null, null);
            }
            else
            {
                timer1.Start();
            }
        }
        #endregion

        #region 删除数据


        public void deleteData(int adminid)
        {
            operated = 2;

            bll.deleteAdmin(adminid,out strErr);

            if (!New_DBAcess.IsDouble)
            {
                adminInfo_Load(null, null);
            }
            else
            {
                timer1.Start();
            }
        }
        #endregion 

        #region 更新数据


        private void buttonCaptionPanel1_Load(object sender, EventArgs e)
        {
            updateData();
            //存入日志
            LogSave.Messages("[adminInfo]", LogIDType.UserLogID, "修改用户信息，用户名为：" + txtUserName.Text.Trim());
        }
        public void updateData()
        {
            if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("用户名不能为空");
                txtUserName.Focus();
                return;
            }
            if (txtPassword1.Text.Trim() != txtPasswordn1.Text.Trim())
            {
                MessageBox.Show("密码一致，请重新输入密码");
                txtPassword1.Text = "";
                txtPasswordn1.Text = "";
                txtPassword1.Focus();
                return;
            }
            int Uid = -1;
            if (this.cbxUserGroup.SelectedValue!=null)
            {
                Uid = int.Parse(cbxUserGroup.SelectedValue.ToString().Trim());
            }

            operated = 3;

            string strPassWord = MD5.GetPassword16(txtPassword1.Text.Trim());

            bll.updateAdmin(id, txtUserName.Text, strPassWord, txtPassword1.Text.Trim(), cbxIsUse1.Checked, cbxIsEndDate.Checked,
                 dateTimePicker2.Value,Uid,0,0,txtRemark1.Text,out strErr);

            if (!New_DBAcess.IsDouble)
            {
                adminInfo_Load(null, null);
            }
            else
            {
                timer1.Start();
            }
        }

        #endregion 
        
        #region Panal1移动事件

        Point _StartXY;
        bool isok = false;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _StartXY = e.Location;
            isok = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            //_StartXY = e.Location;
            if (isok)
            {

                int Xdiff, Ydiff;
                Xdiff = e.X - _StartXY.X;
                Ydiff = e.Y - _StartXY.Y;
                //改变窗体位置 
                int x = panel1.Left + Xdiff;
                int y = panel1.Top + Ydiff;

                x = (x < 0) ? 0 : x;
                y = (y < 0) ? 0 : y;
                x = (x > this.Width - 50) ? (this.Width - 50) : x;
                y = (y > this.Height - 50) ? (this.Height - 50) : y;
                panel1.Left = x;
                panel1.Top = y;
                //把新位置给_StartXY变量了 
                _StartXY = MousePosition;
            }
            isok = false;

        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {

            isok = false;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {

            isok = false;
        }
        #endregion

        #region 关闭
      
       private void buttonCaptionPanel2_Load(object sender, EventArgs e)
        {  this.panel1.Visible = false;

        }
        #endregion 

        #region 取消
        private void buttonCaptionPanel4_Load(object sender, EventArgs e)
        {
            this.txtPassword.Text = "";
            this.txtPasswordn.Text = "";
            this.txtRemark.Text = "";
            this.txtPasswordn.Text = "";
            this.txtUser.Text = "";

        }
#endregion


        #region 判断用户是否存在
        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            lbIssame.Text = ((bll.getUserCount(txtUser.Text)) ? "用户已存在" : "");
        }
        #endregion 

        #region [热备定时刷新]

        /// <summary>
        /// 最大刷新次数
        /// </summary>
        private int maxTimes = 2;

        /// <summary>
        /// 查询刷新次数
        /// </summary>
        private int times = 0;

        /// <summary>
        /// 1表示 增加，修改 2 表示删除,3表示修改
        /// </summary>
        private int operated = 1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            //增加
            if (operated == 1)
            {
                if (RecordSearch.IsRecordExists("Admins", "Account", txtUser.Text,DataType.String))
                {
                    //刷新

                    adminInfo_Load(null, null);

                    times = 0;
                    //关闭timer1
                    timer1.Stop();
                }
                else
                {
                    if (times < maxTimes)
                    {
                        times++;
                        timer1_Tick(sender, e);
                    }
                    else
                    {
                        times = 0;
                        //关闭timer1
                        timer1.Stop();
                    }
                }
            }
            //删除
            else if (operated == 2)
            {
                string value = dtgAccount1.CurrentRow.Cells["ids"].Value.ToString();
                if (!RecordSearch.IsRecordExists("Admins", "ID", value, DataType.Int))
                {
                    //刷新

                    adminInfo_Load(null, null);

                    times = 0;
                    //关闭timer1
                    timer1.Stop();
                }
                else
                {
                    if (times < maxTimes)
                    {
                        times++;
                        timer1_Tick(sender, e);
                    }
                    else
                    {
                        times = 0;
                        //关闭timer1
                        timer1.Stop();
                    }
                }
            }
            //修改
            else
            {
                string strPassWord = MD5.GetPassword16(txtPassword1.Text.Trim());

                string strWhere = "Account='" + txtUserName.Text
                    + "' and Password='" + strPassWord
                    + "' and Remark='" + txtRemark1.Text
                    + "'";

                if (RecordSearch.IsRecordExists("Admins", strWhere))
                {
                    //刷新

                    adminInfo_Load(null, null);

                    times = 0;
                    //关闭timer1
                    timer1.Stop();
                }
                else
                {
                    if (times < maxTimes)
                    {
                        times++;
                        timer1_Tick(sender, e);
                    }
                    else
                    {
                        times = 0;
                        //关闭timer1
                        timer1.Stop();
                    }
                }
            }
        }

        #endregion        
    }
}