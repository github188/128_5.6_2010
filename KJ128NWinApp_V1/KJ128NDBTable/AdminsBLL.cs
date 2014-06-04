using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;
namespace KJ128NDBTable
{
    public class AdminsBLL
    {
        private DBAcess dbacc = new DBAcess();
        AdminsDAL dal = new AdminsDAL();
        #region 查询记录

        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="strAccount"></param>
        /// <param name="strPassword"></param>
        /// <param name="intIP"></param>
        /// <param name="strRemark"></param>
        /// <param name="strErr"></param>
        public void Login(string strAccount, string strPassword, int intIP, string strRemark, out string strErr)
        {
            dal.Login(strAccount, strPassword, intIP, strRemark, out strErr);
        }
        #endregion

        #region
        public bool getUserCount(string account)
        {
            DataSet ds = dbacc.GetDataSet("select id  from admins where account = '" + account + "'");
            if (ds != null & ds.Tables.Count > 0)
            {
                return ds.Tables[0].Rows.Count > 0;
            }
            else
            {
                return false;
            }
        }
        #endregion



        /// <summary>
        /// 根据帐号查询管理员编号
        /// </summary>
        /// <param name="strAccount"></param>
        /// <param name="strErrMsg"></param>
        /// <returns></returns>
        public int GetIDByAccount(string strAccount, out string strErrMsg)
        {
            return dal.GetIDByAccount(strAccount, out strErrMsg);
        }

        public DataSet GetUGPLevelIDByAccount_DataSet(string strAccount, out string strErrMsg)
        {
            return dal.GetUGPLevelIDByAccount_DataSet(strAccount, out strErrMsg);
        }

        public DataSet getLastLoad(int id, out string ErrMsgString)
        {
            return dal.getLastLoad(id, out ErrMsgString);
        }

        public DataSet getAccountAll(out string Err)
        {

            return dal.GetAcountInfo(out Err);
        }

        public int insertAdmin(string strAccount, string password, string passwordback, bool isEnable, bool isUserEndDate, DateTime UseEndDate, int userGroupID, int CreateID, int CreateIP, string Remark, out string err)
        {
            return dal.insertAdmin(strAccount, password, passwordback, isEnable, isUserEndDate, UseEndDate, userGroupID, CreateID, CreateIP, Remark, out err);

        }

        public int updateAdmin(int id, string strAccount, string password, string passwordback, bool isEnable, bool isUserEndDate, DateTime UseEndDate, int userGroupID, int CreateID, int CreateIP, string Remark, out string err)
        {
            return dal.updateAdmin(id, strAccount, password, passwordback, isEnable, isUserEndDate, UseEndDate, userGroupID, CreateID, CreateIP, Remark, out err);
        }

        public int deleteAdmin(int id, out string err)
        {
            if (dal.isBigUserPowerID(LoginBLL.user, id))
            {
                return dal.deleteAdmin(id, out err);
            }
            else
            {
                err = "不能删除比自己权限大的用户";
                return -1;
            }

        }
    }
}
