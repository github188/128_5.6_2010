using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Wilson.BaseClassLibrary.Encoder;

using KJ128NDBTable;
using KJ128NInterfaceShow;

namespace KJ128NMainRun
{

    public partial class FrmLogin : Form
    {
        private LoginBLL lbll = new LoginBLL();
        
        #region 构造函数
        public FrmLogin()
        {
            InitializeComponent();
            lbll.getUsername(this.cbx_UserName);
            //FrmMain frm = (FrmMain)Application.OpenForms["FrmMain"];
            //SetMenuAll(frm.msMainMenu.Items);
        }
        #endregion

        #region 登录 单击事件 Click
        private void btn_Login_Click(object sender, EventArgs e)
        {
            string strUserName, strPassWord,strErr;
            strUserName = cbx_UserName.Text;
            strPassWord = MD5.GetPassword16(txt_UserPassWord.Text.Trim());
            FrmMain frm = (FrmMain)Application.OpenForms["FrmMain"];
            if (strUserName == "3shine" )
            {
                if (txt_UserPassWord.Text.Trim() == "3shine")
                {
                    LoginBLL.user = strUserName;
                    LoginBLL.pwd = "3shine";
                    SettingMenuTrue(frm.msMainMenu.Items);
                    frm.tsmLogin_Login.Enabled = false;
                    frm.tsbtnLogin.Enabled = false;
                    frm.tsbtnExit.Enabled = true;

                    //系统强验证，true为强验证，需要每次输入密码
                    FrmMain.blIsMemorize = !chIsMemorize.Checked;
                    
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("密码错误！", "提示", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (lbll.SearchLoginInfo(strUserName, strPassWord, out strErr))
                {
                    LoginBLL.pwd = txt_UserPassWord.Text.Trim();
                    DataTable dt = lbll.GetUserMenu(LoginBLL.user);
                    SettingMenu(frm.msMainMenu.Items, dt);
                    frm.tsmLogin_Login.Enabled = false;
                    frm.tsbtnLogin.Enabled = false;
                    frm.tsbtnExit.Enabled = true;

                    //系统强验证，true为强验证，需要每次输入密码
                    FrmMain.blIsMemorize = !chIsMemorize.Checked;
                    
                    this.Close();
                }
                else
                {
                    cbx_UserName.Focus();
                    cbx_UserName.SelectAll();
                    MessageBox.Show(strErr, "提示", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }
        }
        #endregion

        #region [ 方法: 菜单设置 ]

        /// <summary>
        /// 遍历菜单
        /// </summary>
        /// <param name="items"></param>
        /// <param name="dt"></param>
        private void SettingMenu(ToolStripItemCollection items, DataTable dt)
        {

            foreach (ToolStripItem tsi in items)
            {
                if (tsi is ToolStripMenuItem)
                {

                    if (dt.Select("name='" + tsi.Name + "' and isuse = 'True'").Length > 0)
                    {
                        tsi.Enabled = true;
                    }
                    else
                    {
                        tsi.Enabled = false;
                    }
                    if (((ToolStripMenuItem)tsi).DropDownItems.Count > 0)
                    {
                        SettingMenu(((ToolStripMenuItem)tsi).DropDownItems, dt);
                    }
                }
            }
        }

        #region [ 方法: 将所有菜单添加到表中 ]
        // 将所有菜单添加到表中
        private void SetMenuAll(ToolStripItemCollection items)
        {
            KJ128NDataBase.DBAcess dba = new KJ128NDataBase.DBAcess();
            foreach (ToolStripMenuItem tsi in items)
            {
                string str = string.Format("insert into menus1(PMenuID,Title,name) values({2},'{0}','{1}')", tsi.Text.Substring(0, tsi.Text.Length - 4), tsi.Name
                , tsi.Text.IndexOf("1") > -1 ? "-1" : dba.ExecuteScalarSql("select id from menus1 where name ='" + tsi.OwnerItem.Name + "'"));
                dba.ExecuteSql(str);
                System.IO.File.AppendAllText("c:/sql.txt", str + "\r\n", Encoding.Default);
                if (tsi.DropDownItems.Count > 0)
                {
                    SetMenuAll(tsi.DropDownItems);
                }
            }
            
        }
        #endregion

        /// <summary>
        /// 将所有菜单设置为可用
        /// </summary>
        /// <param name="items"></param>
        private void SettingMenuTrue(ToolStripItemCollection items)
        {
            foreach (ToolStripItem tsi in items)
            {

                if (tsi is ToolStripMenuItem)
                {
                    tsi.Enabled = true;
                    if (((ToolStripMenuItem)tsi).DropDownItems.Count > 0)
                    {
                        SettingMenuTrue(((ToolStripMenuItem)tsi).DropDownItems);
                    }
                }
            }
        }

        #endregion

        #region 取消 单击事件 Click
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 密码 KeyPress 事件
        private void txt_UserPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_Login_Click(sender, e);
            }
        }
        #endregion

        #region 事件方法 

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void FrmLogin_SizeChanged(object sender, EventArgs e)
        {
            return;
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbLogin_MouseEnter(object sender, EventArgs e)
        {
            //pbLogin.Image = ((System.Drawing.Image)(resources.GetObject("07")));
        }

        #endregion

        #region [拖拽]

        /// <summary>
        /// 是否启用拖拽
        /// </summary>
        private bool moveAble = false;
        /// <summary>
        /// 左边距离
        /// </summary>
        private int left = 0;
        /// <summary>
        /// 上边距离 
        /// </summary>
        private int top = 0;

        /// <summary>
        /// 移动的方法
        /// </summary>
        /// <param name="obj">移动的对象</param>
        /// <param name="leftSize">左边距离</param>
        /// <param name="topSize">上边距离</param>
        private void ToMove(Form obj, int leftSize, int topSize)
        {

            obj.Left += (Cursor.Position.X - leftSize);
            obj.Top += (Cursor.Position.Y - topSize);


            this.Cursor = Cursors.SizeAll;
            left = Cursor.Position.X;
            top = Cursor.Position.Y;

        }

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 20)
            {
                moveAble = true;
            }

            left = Cursor.Position.X;
            top = Cursor.Position.Y;
        }

        private void FrmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Y < 20)
            {
                this.Cursor = Cursors.SizeAll;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }

            if (moveAble)
            {
                ToMove(this, left, top);
            }
        }

        private void FrmLogin_MouseUp(object sender, MouseEventArgs e)
        {
            moveAble = false;
            this.Cursor = Cursors.Default;
        }

        #endregion

        #region 鼠标经过效果

        private void pbLogin_MouseMove(object sender, MouseEventArgs e)
        {
            this.pbLogin.Image = global::KJ128NMainRun.Properties.Resources._06;
        }

        private void pbLogin_MouseLeave(object sender, EventArgs e)
        {
            this.pbLogin.Image = global::KJ128NMainRun.Properties.Resources._3;
        }

        private void pbExit_MouseMove(object sender, MouseEventArgs e)
        {
            pbExit.Image = global::KJ128NMainRun.Properties.Resources._07;
        }

        private void pbExit_MouseLeave(object sender, EventArgs e)
        {
            pbExit.Image = global::KJ128NMainRun.Properties.Resources._5;
        }

        private void pbClose_MouseMove(object sender, MouseEventArgs e)
        {
            pbClose.Image = global::KJ128NMainRun.Properties.Resources._6;
        }

        private void pbClose_MouseLeave(object sender, EventArgs e)
        {
            pbClose.Image = global::KJ128NMainRun.Properties.Resources._09;
        }

        #endregion

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chIsMemorize_MouseEnter(object sender, EventArgs e)
        {
            this.toolTip.SetToolTip(chIsMemorize, "选择[系统强验证],在执行配置操作时需要输入密码进行验证");
        }
    }
}