using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class HisSpecialEmpAlarmBLL
    {
        private HisSpecialEmpAlarmDAL hisdal = new HisSpecialEmpAlarmDAL();


        #region [ 方法: 历史 ]

        public DataSet HisSpecialEmpAlarm(int index, int size, string where)
        {
            DataSet ds = hisdal.HisSpecialEmpAlarm(index, size, where);
            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns["CodeSenderAddress"].ColumnName = "发码器编号";
                ds.Tables[0].Columns["EmpName"].ColumnName = "员工姓名";
                ds.Tables[0].Columns["Total"].ColumnName = "报警次数";
            }
            return ds;
        }

        #endregion

    }
}
