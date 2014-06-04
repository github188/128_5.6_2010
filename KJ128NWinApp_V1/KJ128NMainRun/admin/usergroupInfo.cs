using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDataBase;
using KJ128NDBTable;
using Shine.Logs;
using Shine.Logs.LogType;
using KJ128NInterfaceShow;



namespace KJ128NInterfaceShow
{
    public partial class usergroupInfo : Wilson.Controls.Docking.DockContent
    {
        string strErr = string.Empty;
        public usergroupInfo()
        {
            InitializeComponent();
        }
        private void usergroupInfo_Load(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
            databind();
            cbxBind();

        }
        //NetTraner nt = new NetTraner("192.168.1.59", 8080, 6020);

        UserGroupBLL bll = new UserGroupBLL();

        #region 保存
        private void buttonCaptionPanel1_Load(object sender, EventArgs e)
        {
            //存入日志
            LogSave.Messages("[usergroupInfo]", LogIDType.UserLogID, "增加用户组，用户组名称：" + txtUser.Text.Trim());  

            if (txtUser.Text.Trim() == "")
            {
                MessageBox.Show("用户名称不能为空!");
                return;
            }
            if (lbIssame.Text.Trim() != "")
            {
                return;
            }
            bll.Add(txtUser.Text, cbxisUse.Checked, cbxisEndDATE.Checked, dateTimePicker1.Value, txtRemark.Text, out strErr);

            if (strErr == "Succeeds")
            {
                MessageBox.Show("添加成功!");
            }
            else
            {
                MessageBox.Show("添加失败!");
            }
            usergroupInfo_Load(null, null);
            
           

        }
        #endregion 

        #region 更新
        private void buttonCaptionPanel3_Load(object sender, EventArgs e)
        {
            //存入日志
            LogSave.Messages("[usergroupInfo]", LogIDType.UserLogID, "修改用户组，用户组名称：" + txtUser1.Text.Trim());  

            if (txtUser1.Text.Trim() == "")
            {
                MessageBox.Show("用户名称不能为空!");
                return;

            }
            if (bll.getUserCount(txtUser.Text))
            {
                MessageBox.Show("该用户组已存在，请重新添加");
                return;
            
            }

            bll.Update(id, txtUser1.Text, cbxisUse1.Checked, cbxisEndDATE1.Checked, dateTimePicker2.Value, txtRemark1.Text.Trim(), out strErr);
            if (strErr == "Succeeds")
            {
                MessageBox.Show("修改成功!");
            }
            else
            {
                MessageBox.Show("修改失败!");
            }
            usergroupInfo_Load(null, null); 
        }
       
       
       
        #endregion 

        #region dgv_userGroup事件
        private int id = -1;
        private void dataGridViewKJ1281_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = e.RowIndex;
            this.panel1.Visible = false;
            txtUser1.Text = "";
            cbxisUse.Checked = true;
            dateTimePicker2.Value = DateTime.Now;
            cbxisEndDATE1.Checked = false;
            txtRemark1.Text = "";


            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {

                id = int.Parse(dgv_userGroup.Rows[a].Cells["ids"].Value.ToString());
                txtUser1.Text = dgv_userGroup.Rows[a].Cells["UGName"].Value.ToString();
                cbxisUse1.Checked = Convert.ToBoolean(dgv_userGroup.Rows[a].Cells["IsEnable"].Value.ToString());
                cbxisEndDATE1.Checked = Convert.ToBoolean(dgv_userGroup.Rows[a].Cells["IsUseEndDate"].Value.ToString());
                dateTimePicker2.Value = DateTime.Parse(dgv_userGroup.Rows[a].Cells["UseEndDate"].Value.ToString());

                txtRemark1.Text = dgv_userGroup.Rows[a].Cells["remark"].Value.ToString();
                panel1.Visible = true;
            }
            else
            {
                if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                {

                    id = int.Parse(dgv_userGroup.Rows[a].Cells["ids"].Value.ToString());
                      
                        
                        if (MessageBox.Show("删除用户组会将该用户组的所有用户删除,您确定要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            //存入日志
                            LogSave.Messages("[usergroupInfo]", LogIDType.UserLogID, "删除用户组，用户组名称：" + dgv_userGroup.Rows[a].Cells["UGName"].Value.ToString());  

                            bll.DeleteByID(id,out strErr);
                            if (strErr == "Succeeds")
                            {  
                                usergroupInfo_Load(null, null);
                            
                            }
                            else
                            {
                                MessageBox.Show(strErr);
                            }
                        }
                    
                
                   
                }
            }
        }
        #endregion 

        #region 绑定用户组权限
        public void cbxBind()
        {
            //bll.setCboUserGroupspower(this.cbxUserPower);
            //bll.setCboUserGroupspower(this.cbxUserPower1);

        }
        #endregion 

        #region 绑定dgv_userGroup
        public void databind()
         {
             DataSet ds = bll.getallUserGroup();
             this.dgv_userGroup.DataSource = ds.Tables[0].DefaultView;
             
        
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
        private void buttonCaptionPanel4_Load(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
        }
        #endregion 

        #region 撤消
        private void buttonCaptionPanel2_Load(object sender, EventArgs e)
        {
            this.txtRemark.Text = "";
            this.txtUser.Text = "";
            this.dateTimePicker1.Value = DateTime.Now;
            this.cbxisUse.Checked = true;
            this.cbxisEndDATE.Checked =false;

     
        }
        #endregion 

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            lbIssame.Text = ((bll.getUserCount(txtUser.Text)) ? "用户已存在" : "");
        }

        private void cbxisEndDATE_CheckedChanged(object sender, EventArgs e)
        {

        }

       

       

       

    }
}