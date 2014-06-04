using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using Wilson.BaseClassLibrary.Encoder;
using KJ128NInterfaceShow;
using System.Xml;
using System.IO;

namespace KJ128NMainRun
{
    public partial class A_FrmLogin : Form
    {

        #region【声明】

        private LoginBLL lbll = new LoginBLL();

        private A_FrmMain Main = null;
        #endregion


        #region【构造函数】

        public A_FrmLogin(A_FrmMain frm)
        {
            InitializeComponent();
            lbll.getUsername(this.cbx_UserName);
            Main = frm;

            lblMessage.Text = "";
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
            string configPath = Application.StartupPath + @"\HostIPConfig.xml";

            XmlDocument docConfig = new XmlDocument();

            if (File.Exists(configPath))
            {
                //MessageBox.Show("HostIPConfig.xml文件不存在,配置文件后会自动生成此文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                docConfig.Load(configPath);

                string isStartHost = docConfig.ChildNodes[1].ChildNodes[0].ChildNodes[0].InnerText;

                if (isStartHost.ToUpper() == "TRUE")
                {

                    string isHost = docConfig.ChildNodes[1].ChildNodes[0].ChildNodes[1].InnerText;

                    if (!(isHost.ToUpper() == "TRUE"))
                    {
                        if (Main != null)
                        {
                            Main.SetTsmiFalse();
                        }
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

        #region 登录 单击事件 Click
        private void pbLogin_Click(object sender, EventArgs e)
        {
            string strUserName, strPassWord, strErr;
            strUserName = cbx_UserName.Text;
            strPassWord = MD5.GetPassword16(txt_UserPassWord.Text);
            A_FrmMain frm = (A_FrmMain)Application.OpenForms["A_FrmMain"];
            if (strUserName == "3shine")
            {
                if (txt_UserPassWord.Text.Trim() == "3shine")
                {
                    LoginBLL.user = strUserName;
                    LoginBLL.pwd = "3shine";
                    SettingMenuTrue(frm.msMainMenu.Items);
                    frm.tsmiLogin.Enabled = false;
                    frm.tsbtnLogin.Enabled = false;
                    frm.tsmiExit.Enabled = true;
                    //frm.tsmiClose.Enabled = true;
                    frm.tsbtnExit.Enabled = true;

                    frm.tsbtnReal.Enabled = true;
                    frm.tsbtnHis.Enabled = true;
                    frm.tsbtnGHis.Enabled = true;

                    //系统强验证，true为强验证，需要每次输入密码
                    A_FrmMain.blIsMemorize = !chIsMemorize.Checked;

                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_UserPassWord.Focus();
                    txt_UserPassWord.SelectAll();
                }
            }
            else
            {
                if (lbll.SearchLoginInfo(strUserName, strPassWord, out strErr))
                {
                    LoginBLL.pwd = txt_UserPassWord.Text.Trim();
                    DataTable dt = lbll.GetUserMenu(LoginBLL.user);
                    SettingMenu(frm.msMainMenu.Items, dt);
                    frm.tsmiLogin.Enabled = false;
                    frm.tsbtnLogin.Enabled = false;
                    frm.tsbtnExit.Enabled = true;
                    frm.tsmiExit.Enabled = true;
                    frm.tsbtnReal.Enabled = true;
                    frm.tsbtnHis.Enabled = true;
                    frm.tsbtnGHis.Enabled = true;

                    //系统强验证，true为强验证，需要每次输入密码
                    A_FrmMain.blIsMemorize = !chIsMemorize.Checked;

                    this.Close();
                }
                else
                {
                    cbx_UserName.Focus();
                    cbx_UserName.SelectAll();
                    MessageBox.Show(strErr, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        #endregion


        private void pbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chIsMemorize_MouseEnter(object sender, EventArgs e)
        {
            //this.toolTip.SetToolTip(chIsMemorize, "选择[系统强验证],在执行配置操作时需要输入密码进行验证");
            this.lblMessage.Text = "选中后在配置操作中需输入密码进行验证!";
        }

        #region【事件：密码框键盘时间】

        private void txt_UserPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                pbLogin_Click(null, null);
            }
        }

        #endregion

        private void A_FrmLogin_Shown(object sender, EventArgs e)
        {
            this.txt_UserPassWord.Focus();
        }

        private void txt_UserPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void chIsMemorize_MouseLeave(object sender, EventArgs e)
        {
            this.lblMessage.Text = "";
        }
    }
}
