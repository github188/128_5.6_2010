using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace KJ128NDataBase
{
    public class TaskTimeDAL
    {
        DBAcess DB = new DBAcess();

        #region 工作时长设置
        public int TaskTime_Insert(int intHour,int intMinute,string strRemark,out string strErr)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@HourNumber",SqlDbType.BigInt,8),
                new SqlParameter("@MinuteNumber",SqlDbType.BigInt,8),
                new SqlParameter("@Remark",SqlDbType.VarChar,100)
            };

            parameters[0].Value = intHour;
            parameters[1].Value = intMinute;
            parameters[2].Value = strRemark;

            return DB.ExecuteSql("Shine_TastTime_Add", parameters,out strErr);

        }
        #endregion

        #region 工作时长修改
        public int TaskTime_Update(int intID,int intHour,int intMinute,string strRemark,out string strErr)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.Int,4),
                  new SqlParameter("@HourNumber",SqlDbType.BigInt,8),
                new SqlParameter("@MinuteNumber",SqlDbType.BigInt,8),
                new SqlParameter("@Remark",SqlDbType.VarChar,100)
            };

            parameters[0].Value = intID;
            parameters[1].Value = intHour;
            parameters[2].Value = intMinute;
            parameters[3].Value = strRemark;

            return DB.ExecuteSql("Shine_TastTime_Query", parameters,out strErr);

        }
        #endregion

        #region 工作时长删除
        public int TaskTime_Delete(int intID,out string strErr)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.Int,4)
            };

            parameters[0].Value = intID;
            return DB.ExecuteSql("Shine_TastTime_Delete", parameters,out strErr);

        }
        #endregion

        #region 工作时长查询
        public DataSet TaskTime_Query(string strWhere)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("",SqlDbType.VarChar,200)
            };

            parameter[0].Value = strWhere;

            return DB.ExecuteSqlDataSet("Shine_TastTime_Query", parameter);
        }
        #endregion
    }
}
