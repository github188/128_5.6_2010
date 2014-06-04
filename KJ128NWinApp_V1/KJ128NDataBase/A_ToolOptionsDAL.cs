using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class A_ToolOptionsDAL
    {
        #region【声明】

        private DBAcess dbacc = new DBAcess();

        private string strSql;

        #endregion


        #region [ 方法: 获取 报警声音类别 ]

        public DataSet GetAlarmWaveType()
        {
            string strSql = " select EnumID,Title From EnumTable Where FunID=11 ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 获取报警数据 ]

        public DataSet GetAlarmSetInfo(int intType)
        {
            strSql = " Select * From KJ128N_AlarmSet_Info Where AlarmSetType= " + intType;
      
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 存储报警设置信息 ]

        public int UpDateAlarmSet(int intAlarmSetType, bool blEnumValue, int intAlarmWaveType, string strAlarmWavePath)
        {
            SqlParameter[] sqlParmeters ={
                new SqlParameter("AlarmSetType",SqlDbType.Int),
                new SqlParameter("EnumValue",SqlDbType.NVarChar,20),
                new SqlParameter("AlarmWaveType",SqlDbType.Int),
                new SqlParameter("AlarmWavePath",SqlDbType.NVarChar,100)
            };
            sqlParmeters[0].Value = intAlarmSetType;
            if (blEnumValue)
            {
                sqlParmeters[1].Value = 1;
            }
            else
            {
                sqlParmeters[1].Value = 0;
            }
            sqlParmeters[2].Value = intAlarmWaveType;
            sqlParmeters[3].Value = strAlarmWavePath;
            return dbacc.ExecuteSql("KJ128N_AlarmSet_UpDate", sqlParmeters);
        }

        #endregion

    }
}
