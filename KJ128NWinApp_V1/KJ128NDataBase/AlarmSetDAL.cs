using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class AlarmSetDAL
    {

        #region [ ���� ]

        private DBAcess dbacc = new DBAcess();

        #endregion

        #region [ ����: ��ȡ ����������� ]
        public DataSet GetAlarmWaveType()
        {
            string strSql = " select EnumID,Title From EnumTable Where FunID=11 ";
            return dbacc.GetDataSet(strSql);
        }
        #endregion

        #region [ ����: �洢����������Ϣ ]

        public int UpDateAlarmSet(int intAlarmSetType, bool blEnumValue, int intAlarmWaveType, string strAlarmWavePath)
        {
            string procName = "KJ128N_AlarmSet_UpDate";
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
            return dbacc.ExecuteSql(procName, sqlParmeters);
        }

        #endregion

        #region [ ����: �洢��Ա�������� ]

        public int SaveEmpCount(string strEmpCount)
        {
            string strSql = " UpDate EnumTable Set EnumValue='" + strEmpCount + "' Where FunID=8 and EnumID=1";
            return dbacc.ExecuteSql(strSql);
        }

        #endregion

        #region [ ����: �ж��Ƿ�Ա ]

        public bool IsOverEmp()
        {
            try
            {
                dbacc.ExecuteSql("zjw_OverEmpInWell", new SqlParameter[0]);
                dbacc.ExecuteSql("zjw_OverEmpOutWell", new SqlParameter[0]);
            }
            catch 
            {
                return false;
            }
            return true;
        }

        #endregion

        #region [ ����: ��ȡ�������� ]

        public DataSet GetAlarmSetInfo(int intType)
        {
            string strSql = " Select * From KJ128N_AlarmSet_Info Where AlarmSetType= "+intType;
            //switch (intType)
            //{
            //    case 1:
            //        strSql += " 1";
            //        break;
            //    case 2:
            //        strSql += "2";
            //        break;
            //    case 3:
            //        strSql += "3";
            //        break;
            //    case 4:
            //        strSql += "4";
            //        break;
            //    case 5:
            //        strSql += "5";
            //        break;
            //    case 6:
            //        strSql += "6";
            //        break;
            //    default:
            //        break;
            //}
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ ����: ���س�Ա���� ]

        public DataSet GetEmpCount()
        {
            string strSql = " Select EnumValue From EnumTable Where FunID=8 And EnumID=1";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

    }
}
