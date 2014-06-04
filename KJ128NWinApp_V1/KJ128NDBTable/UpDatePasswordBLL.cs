using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class UpDatePasswordBLL
    {
        //private DBAcess dbacc = new DBAcess();
        //private DataSet ds;
        //private string strSql = string.Empty;
        #region [ 声明 ]

        private UpDatePasswordDAL udpdal = new UpDatePasswordDAL();

        #endregion

        #region [ 方法: 修改密码 ]

        public bool UpDatePassWord(string strUserName, string strPassWord, out string strErr)
        {
            //strSql = " UpDate Admins Set Password ='" + strPassWord + "' Where Account ='" + strUserName + "'";
            //if (dbacc.ExecuteSql(strSql) == 1)
            //{
            //    strErr = "修改成功！";
            //    return true;
            //}
            //else
            //{
            //    strErr = "修改失败！";
            //    return false;
            //}
            if (udpdal.UpDatePassWord(strUserName, strPassWord))
            {
                strErr = "修改成功！";
                return true;
            }
            else
            {
                strErr = "修改失败！";
                return false;
            }
        }

        #endregion
    }
}
