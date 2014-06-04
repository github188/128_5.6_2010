using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class UpDatePasswordDAL
    {

        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();
        
        private string strSql = string.Empty;

        #endregion

        #region [ 方法: 修改密码 ]

        public bool UpDatePassWord(string strUserName, string strPassWord)
        {
            strSql = " UpDate Admins Set Password ='" + strPassWord + "' Where Account ='" + strUserName + "'";
            if (dbacc.ExecuteSql(strSql) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
