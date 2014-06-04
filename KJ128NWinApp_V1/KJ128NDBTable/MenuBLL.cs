using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;
using System.Windows.Forms;
namespace KJ128NDBTable
{
    public class MenuBLL
    {
        MenuDAL dal = new MenuDAL();

        private DBAcess dbacc = new DBAcess();
        #region 执行Sql语句，并返回影响的行数
        public int ExcuteSql(string strSql)
        {
            return dal.ExcuteSql(strSql);
        }
        #endregion

        
        public DataTable LoadMenu(int iAdminID)
        {
            return dal.LoadMenu(iAdminID);
        }

        public DataSet getALLmenu()
        {
            return dal.getAllMenu();
        }

        #region 添加菜单
        public bool addMenu(string title, string pname, string name)
        {
            return dal.addMenu(title, pname, name);
        }
        #endregion
        #region 删除菜单
        public bool deleteMenu(string strSql)
        {
            return dal.deleteMenu(strSql);
        }

        #endregion

        #region  修改菜单
        public bool updateMenu(string title, string remark, int pid, int id, string name)
        {
            return dal.updateMenu(title, remark, pid, id, name);
        }

        #endregion

        #region 绑定菜单到ComboBox
        public void getmenu(ComboBox cbxMenu)
        {
            string strSql = " Select id,title  From menus1 where PMenuID = -1  ";
            DataSet ds;
            using (ds = new DataSet())
            {
                ds = dbacc.GetDataSet(strSql);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    cbxMenu.DataSource = ds.Tables[0];
                    cbxMenu.DisplayMember = "title";
                    cbxMenu.ValueMember = "id";
                }
                else
                {
                    cbxMenu.Text = "无 ";
                    cbxMenu.SelectedValue = 0;

                }
            }
        }
        #endregion
    }
}
