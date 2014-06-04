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
        /// 返回执行的行数
        /// </summary>
        /// <param name="Id">要删除的记录Id</param>
        /// <returns>返回的行数</returns>
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
