using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class HisPathAlertInfoDal
    {
        private DbHelperSQL help = new DbHelperSQL();

        public DataTable GetHisPathAlertInfo(string condition)
        {
            SqlParameter[] para = new SqlParameter[] 
                {
                    new SqlParameter ("@condition", SqlDbType.VarChar, 100)
                };
            para[0].Value = condition;
            DataTable dt = help.ReturnDataTable("select_His_PathAlert", para);
            return dt;
        }

        /// <summary>
        /// ����ִ�е�����
        /// </summary>
        /// <param name="Id">Ҫɾ���ļ�¼Id</param>
        /// <returns>���ص�����</returns>
        public int DeletePathAlertInfo(int Id)
        {
            SqlParameter[] para = new SqlParameter[] 
                {
                    new SqlParameter("@id", SqlDbType.Int)
                };

            para[0].Value = Id;
            string outStr = String.Empty;
            int result = help.RunProcedureByInt("delete_His_PathAlert", para, out outStr);
            return result;
        }
    }
}
