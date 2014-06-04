using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class LoginDAL
    {
        #region [ 桃源 ]

        DbHelperSQL DB = new DbHelperSQL();
        private DBAcess dbacc = new DBAcess();
        #region 查询记录

        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="strAccount"></param>
        /// <param name="strPassword"></param>
        /// <param name="intIP"></param>
        /// <param name="strRemark"></param>
        /// <param name="strErr"></param>
        /// <returns></returns>
        public string  Login(string strAccount, string strPassword, string strRemark, out string strErr)
        {
            SqlParameter[] arrParm = 
				{
					new SqlParameter("@d_name", SqlDbType.VarChar, 20),
					new SqlParameter("@d_pwd", SqlDbType.VarChar, 20),
					new SqlParameter("@p_Remark", SqlDbType.VarChar, 200)
				};
            arrParm[0].Value = strAccount;
            arrParm[1].Value = strPassword;
            arrParm[2].Value = strRemark;
            DataSet ds = DB.RunProcedureByDataSet("PROC_userLogin","ds" ,arrParm,out strErr);
            if (ds != null && ds.Tables.Count > 0)
            {
                string str = ds.Tables[0].Rows[0][0].ToString();
                if (str != string.Empty)
                {
                    return str;
                }
            }
            return "";
        }
        #endregion

        #endregion

        #region [ 方法: 根据用户获得菜单 ]

        public DataSet GetUserMenu(string strAccount)
        {
            SqlParameter[] parArr = {new SqlParameter("@account",SqlDbType.VarChar,20)};
            parArr[0].Value = strAccount;
            return dbacc.ExecuteSqlDataSet("selectUserGrupByAccountID", parArr);
        }

        #endregion


        //#region [ 声明 ]

        //private DBAcess dbacc = new DBAcess();

        //private string strSql = string.Empty;

        //#endregion

        //#region [ 方法: 登录 ]

        //public DataSet GetLoginInfo(string strUserName)
        //{
        //    strSql = " Select Password " +
        //             " From Admins " +
        //             " Where Account='" + strUserName + "'";
        //   return dbacc.GetDataSet(strSql);
        //}

        //#endregion
    }
}
