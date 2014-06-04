using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class HisInMineEmpTotalBLL
    {
        private HisInMineEmpTotalDAL himdal = new HisInMineEmpTotalDAL();

        #region [ 方法: 历史下井总数及人员信息统计 ]

        public DataSet HisInMineEmpTotal(int index, int size, string where)
        {
            DataSet ds = himdal.HisInMineEmpTotal(index, size, where);
            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns["CodeSenderAddress"].ColumnName = "发码器编号";
                ds.Tables[0].Columns["EmpName"].ColumnName = "员工姓名";
                ds.Tables[0].Columns["Total"].ColumnName = "下井次数";
            }
            return ds;
        }

        #endregion
    }
}
