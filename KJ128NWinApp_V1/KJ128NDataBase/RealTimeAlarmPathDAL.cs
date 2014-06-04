using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class RealTimeAlarmPathDAL
    {
        private DbHelperSQL help = new DbHelperSQL();

        string outStr = String.Empty;

        public DataTable RealTimeAlarmPathInfo()
        {
            return help.ReturnDataTable("select_RealTimeAlarmPathInfo", null);
        }
        

        public int DeleteRealTimeAlarmPathByEmpID(int empID)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@EmpID",SqlDbType.Int)
        };
            para[0].Value = empID;

            int result = help.RunProcedureByInt("delete_RealTimePathAlert", para, out outStr);

            return result;
        }
    }
}
