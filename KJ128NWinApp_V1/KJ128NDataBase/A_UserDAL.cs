using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class A_UserDAL
    {
        #region[申明]
        private DBAcess dba = new DBAcess();
        DbHelperSQL DB = new DbHelperSQL();
        string strSQL;

        #endregion

        public DataTable GetUserGroups()
        {
            string sqlstr = "select [id],ugname from UserGroups";
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return new DataTable();
            }
        }

        public DataTable GetUserByUG(string usergroupid)
        {
            string sqlstr = string.Format("select [id],account from Admins where usergroupid={0}", usergroupid);
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return new DataTable();
            }
        }

        public DataTable GetAdmins(string ugid)
        {
            
            if (ugid == "all")
            {
                strSQL = "(SELECT dbo.Admins.Account as 用户名, dbo.UserGroups.UGName as 用户组, dbo.Admins.IsEnable as 是否可用, "+
                                        "dbo.Admins.Remark as 备注 "+
                                        "FROM dbo.Admins INNER JOIN "+
                                        "dbo.UserGroups ON dbo.Admins.UserGroupID = dbo.UserGroups.ID)";
            }
            else
            {
               strSQL = string.Format("(SELECT dbo.Admins.Account as 用户名, dbo.UserGroups.UGName as 用户组, dbo.Admins.IsEnable as 是否可用, "+
                                        "dbo.Admins.Remark as 备注 "+
                                        "FROM dbo.Admins INNER JOIN "+
                                        "dbo.UserGroups ON dbo.Admins.UserGroupID = dbo.UserGroups.ID where usergroupid={0})", ugid);
            }
            try
            {
                DataSet ds = dba.GetDataSet(strSQL);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public bool isExitsUserName(string username)
        {
            string sqlstr = string.Format("select count(*) from admins where account='{0}'", username);
            int num = int.Parse(dba.ExecuteScalarSql(sqlstr));
            if (num > 0)
                return true;
            else
                return false;
        }

        public int insertAdmin(string Account, string password, string passwordback, bool isEnable, bool isUserEndDate, DateTime UseEndDate, int userGroupID, int CreateID, int CreateIP, string Remark, out string err)
        {

            SqlParameter[] arrParm = 
				{
					new SqlParameter("@Account", SqlDbType.VarChar, 20),
                    new SqlParameter("@password", SqlDbType.VarChar, 16),
                    new SqlParameter("@Passwordback",SqlDbType.VarChar,16),
                    new SqlParameter("@isEnable", SqlDbType.Bit , 1),
                    new SqlParameter("@IsUseEndDate", SqlDbType.Bit , 1),
                    new SqlParameter("@UseEndDate", SqlDbType.DateTime , 8),
                    new SqlParameter("@userGroupID", SqlDbType.Int , 4),
                    new SqlParameter("@CreateID", SqlDbType.Int , 4),
                    new SqlParameter("@CreateIP", SqlDbType.BigInt , 8),
                    new SqlParameter("@Remark", SqlDbType.VarChar, 200),
                    new SqlParameter("@ID",SqlDbType.Int)
				};
            arrParm[0].Value = Account;
            arrParm[1].Value = password;
            arrParm[2].Value = passwordback;
            arrParm[3].Value = isEnable;
            arrParm[4].Value = isUserEndDate;
            arrParm[5].Value = UseEndDate;
            arrParm[6].Value = userGroupID;
            arrParm[7].Value = CreateID;
            arrParm[8].Value = CreateIP;
            arrParm[9].Value = Remark;
            arrParm[10].Value = Account.GetHashCode();
            return DB.RunProcedureByInt("inserUser", arrParm, out err);
        }

        public void DelUserByUserName(string username)
        {
            string sqlstr = string.Format("delete from admins where account='{0}'", username);
            dba.ExecuteSql(sqlstr);
        }

        public bool UpdateUserByUserName(string username,string gu, string isenable, string remark,string Password)
        {
            string sqlstr = string.Format("update admins set usergroupid={1},isenable={2},remark='{3}',Password='{4}' where account='{0}'", username, gu, isenable, remark, Password);
            int num = dba.ExecuteSql(sqlstr);
            if (num > 0)
                return true;
            else
                return false;
        }

        public bool InsertUserGroup(string ugname)
        {
            if (ugname != "")
            {
                string sqlstr = string.Format("if not exists (select * from UserGroups where ugname='{0}') insert into UserGroups ([ID],ugname,isenable,isuseenddate) values({1},'{0}',1,0)", ugname, ugname.GetHashCode());
                int num = dba.ExecuteSql(sqlstr);
                if (num > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public string GetUGidByName(string ugname)
        {
            string sqlstr = string.Format("select [id] from usergroups where ugname='{0}'", ugname);
            return dba.ExecuteScalarSql(sqlstr);
        }

        public string GetMenuPidByMenuName(string name)
        {
            string sqlstr = string.Format("select [id] from menus1 where [name]='{0}'", name);
            return dba.ExecuteScalarSql(sqlstr);
        }

        public bool InsertMenu(string pid, string title, string name)
        {
            string sqlstr = string.Format("if not exists (select * from menus1 where [name]='{2}') "+
                                            "insert into menus1 values({0},'{1}','{2}')", pid, title, name);
            int num = dba.ExecuteSql(sqlstr);
            if (num > 0)
                return true;
            else
                return false;
        }

        public void DelMenuByUGid(string ugid)
        {
            string sqlstr = string.Format("delete from UserGroupMenu1 where usergroupid={0}", ugid);
            dba.ExecuteSql(sqlstr);
        }

        public void InsertUGmenu(string ugid, string menuid, int isuse, string remark)
        {
            string sqlstr = string.Format("if not exists(select * from UserGroupMenu1 where usergroupid={0} and menuid={1}) " +
                                        "insert into UserGroupMenu1 values({4},{0},{1},{2},'{3}')", ugid, menuid, isuse, remark, (ugid.ToString() + menuid.ToString() + isuse.ToString()).GetHashCode());
            dba.ExecuteSql(sqlstr);
        }

        public bool IsMenuSaved()
        {
            try
            {
                string sqlstr = "select count([id]) from menus1";
                if (int.Parse(dba.ExecuteScalarSql(sqlstr)) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DelUserGroupByID(string ugid)
        {
            string sqlstr = string.Format("delete from UserGroups where id={0} delete from Admins where UserGroupID={0}", ugid);
            int num = dba.ExecuteSql(sqlstr);
            if (num > 0)
                return true;
            else
                return false;
        }

        public string GetUGMenuPower(string menuname, string ugid)
        {
            string sqlstr = string.Format("select isuse from UserGroupMenu1 where usergroupid={1} and menuid in (select [id] from menus1 where [name]='{0}')", menuname, ugid);
            return dba.ExecuteScalarSql(sqlstr);
        }

        public string GetPassWordByUserName(string username)
        {
            try
            {
                string sqlstr = string.Format("select passwordback from admins where account='{0}'", username);
                return dba.ExecuteScalarSql(sqlstr);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        #region【方法：Czlt-2011-12-10 修改配置时间】

        public void UpdateTime()
        {
            strSQL = "UPDATE [CzltChangeTable] SET ChangeTime ='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
            dba.GetDataSet(strSQL);
        }

        #endregion
    }
}
