using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace KJ128NDataBase
{
    public class AdminsDAL
    {
        DbHelperSQL DB = new DbHelperSQL();
        #region 管理员登录
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="strAccount"></param>
        /// <param name="strPassword"></param>
        /// <param name="intIP"></param>
        /// <param name="strRemark"></param>
        /// <param name="strErr"></param>
        /// <returns></returns>
        public int Login(string strAccount, string strPassword, int intIP, string strRemark, out string strErr)
        {
            SqlParameter[] arrParm = 
				{
					new SqlParameter("@d_name", SqlDbType.VarChar, 20),
					new SqlParameter("@d_pwd", SqlDbType.VarChar, 20),
					new SqlParameter("@p_TmpLoginIP", SqlDbType.BigInt),
					new SqlParameter("@p_Remark", SqlDbType.VarChar, 200)
				};
            arrParm[0].Value = strAccount;
            arrParm[1].Value = strPassword;
            arrParm[2].Value = intIP;
            arrParm[3].Value = strRemark;
            return DB.RunProcedureByInt("PROC_userLogin", arrParm, out strErr);
        }
        #endregion

        #region 获取用户ID
        /// <summary>
        /// 获取用户ID
        /// </summary>
        /// 
        public int GetIDByAccount(string strAccount, out string strErrMsg)
        {
            SqlParameter[] arrParm = 
				{
					new SqlParameter("@Account", SqlDbType.VarChar, 20)
				};
            arrParm[0].Value = strAccount;
            return DB.RunProcedureReturnInt("Shine_Admins_GetID_ByAccount", arrParm, out strErrMsg);
        }

        public DataSet GetUGPLevelIDByAccount_DataSet(string strAccount, out string strErrMsg)
        {
            SqlParameter[] arrParm = 
				{
					new SqlParameter("@Account", SqlDbType.VarChar, 20)
				};
            arrParm[0].Value = strAccount;
            return DB.RunProcedureByDataSet("Shine_Admin_GetUGPLevelID_ByAccount", "ds", arrParm, out strErrMsg);
        }
        #endregion

        #region 得到用户信息
        public DataSet GetAcountInfo(out string strErrMsg)
        {
            return DB.RunProcedureByDataSet("getAlluser", "ds", out strErrMsg);
        }
        #endregion

        #region 插入数据
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
                    new SqlParameter("@Remark", SqlDbType.VarChar, 200)
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
            return DB.RunProcedureByInt("inserUser", arrParm, out err);

        }
        #endregion

        #region 更新数据
        public int updateAdmin(int id, string Account, string password, string passwordback, bool isEnable, bool isUserEndDate, DateTime UseEndDate, int userGroupID, int CreateID, int CreateIP, string Remark, out string err)
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
                             new SqlParameter("@id", SqlDbType.Int, 4)
                            
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
            arrParm[10].Value = id;
            return DB.RunProcedureByInt("updateUser", arrParm, out err);

        }
        #endregion

        #region 删除
        public int deleteAdmin(int id, out string err)
        {

            SqlParameter[] arrParm = { new SqlParameter("@id", SqlDbType.VarChar, 20) };
            arrParm[0].Value = id;
            return DB.RunProcedureByInt("Shine_Admins_DeleteByPrimaryKey", arrParm, out err);

        }
        #endregion

        #region 查询上次登陆
        public DataSet getLastLoad(int id, out string ErrMsgString)
        {
            SqlParameter[] parameters = new SqlParameter[] {
																new SqlParameter("@ID", SqlDbType.Int, 4)};
            parameters[0].Value = id;
            return DB.RunProcedureByDataSet("Shine_Admin_lastLoard", "ds", parameters, out ErrMsgString);
        }
        #endregion

        #region 比较用户权限等级

        public bool isBigUserPowerID(String account, int id)
        {
            //if (account == "3shine") return true;
            //string err;
            //SqlParameter[] parameters = new SqlParameter[] {   new SqlParameter("@Account", SqlDbType.NVarChar ,50)
            //,new SqlParameter("@ID", SqlDbType.Int, 4)
            //};
            //parameters[0].Value = account;
            //parameters[1].Value = id;
            //DataSet ds = DB.RunProcedureByDataSet("Shine_Admin_GetUGPLevelID", "ds", parameters, out err);
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    return int.Parse(ds.Tables[0].Rows[0][0].ToString()) == 1;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }

        #endregion

    }
}
