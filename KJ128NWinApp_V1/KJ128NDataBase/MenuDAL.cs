using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace KJ128NDataBase
{
    public class MenuDAL
    {
        DbHelperSQL DB = new DbHelperSQL();
        private DBAcess dbacc = new DBAcess();
        

        #region 执行SQL语句，返回影响的行数
        public int ExcuteSql(string strSql)
        {
            return DB.ExecuteSql(strSql);
        }
        #endregion
        
        public DataTable LoadMenu(int iAdminID)
        {
            SqlParameter[] parameters =
			{
				new SqlParameter("@AdminID", SqlDbType.Int, 4)
			};
            parameters[0].Value = iAdminID;

            return DB.ReturnDataTable("W_GetUserGroupMenu", parameters);
        }

        public DataSet getAllMenu()
        {
            return dbacc.GetDataSet("getMenuAll");

        }

        public bool addMenu(string title, string pname, string name)
        {
            SqlParameter[] parameters =
			{
                new SqlParameter("pname", SqlDbType.VarChar, 50),
				new SqlParameter("Title", SqlDbType.VarChar, 50),
                new SqlParameter("name", SqlDbType.VarChar, 50)
			};
            parameters[0].Value = pname;
            parameters[1].Value = title;
            parameters[2].Value = name; ;
            int a = dbacc.ExecuteSql("MenuInsert", parameters);
            return a != -1 ? true : false;

        }
        public bool deleteMenu(string sql)
        {

            int a = dbacc.ExecuteSql("delete menus1 where name not in (" + sql + "'0') delete usergroupmenu1 where menuid not in (select id from menus1)");
            return a != -1 ? true : false;
        }
        public bool updateMenu(string title, string remark, int pid, int id, string name)
        {
            SqlParameter[] parameters =
			{
                new SqlParameter("id", SqlDbType.Int, 4),
                new SqlParameter("PMenuID", SqlDbType.Int , 4),
				new SqlParameter("Title", SqlDbType.VarChar, 50),
                new SqlParameter("Remark", SqlDbType.VarChar, 200),
                new SqlParameter("name", SqlDbType.VarChar, 50)
               
			};
            parameters[0].Value = id;
            parameters[1].Value = pid;
            parameters[2].Value = title;
            parameters[3].Value = remark;
            parameters[4].Value = name;

            int a = dbacc.ExecuteSql("updateMenu1", parameters);
            return a != -1 ? true : false;

        }
    }
}
