using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace KJ128NDataBase
{
    public class TimePrintDAL
    {

        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();

        private string strSql = string.Empty;

        #endregion

        #region [ 方法: 保存打印设置 ]

        public int SavePrint(string str1, string str2, string str3, string str4, string str5, string str6, string str7, string strTime)
        {
            SqlParameter[] sqlParmeters = 
				{
					new SqlParameter("@str1", SqlDbType.VarChar, 20),
					new SqlParameter("@str2", SqlDbType.VarChar, 20),
					new SqlParameter("@str3", SqlDbType.VarChar, 20),
					new SqlParameter("@str4", SqlDbType.VarChar, 20),
					new SqlParameter("@str5", SqlDbType.VarChar, 20),
					new SqlParameter("@str6", SqlDbType.VarChar, 20),
					new SqlParameter("@str7", SqlDbType.VarChar, 20),
                    new SqlParameter("@strTime", SqlDbType.VarChar, 20),
				};
            sqlParmeters[0].Value = str1;
            sqlParmeters[1].Value = str2;
            sqlParmeters[2].Value = str3;
            sqlParmeters[3].Value = str4;
            sqlParmeters[4].Value = str5;
            sqlParmeters[5].Value = str6;
            sqlParmeters[6].Value = str7;
            sqlParmeters[7].Value = strTime;

            return dbacc.ExecuteSql("zjw_SavePrint", sqlParmeters);
        }

        #endregion

        #region [ 方法: 获取打印项目 ]

        public DataSet GetPrint()
        {
            strSql = " Select EnumValue,EnumID From EnumTable Where FunID=15";

            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 获取定时打印时间 ]

        public DataSet GetTime()
        {
            strSql = " Select EnumValue From EnumTable Where FunID=16 and EnumID =1";

            return dbacc.GetDataSet(strSql);
        }

        #endregion
    }
}
