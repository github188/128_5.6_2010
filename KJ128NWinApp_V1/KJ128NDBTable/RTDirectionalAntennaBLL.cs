using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class RTDirectionalAntennaBLL
    {
        private RTDirectionalAntennaDAL dal = new RTDirectionalAntennaDAL();


        #region 实时探头方向性

        public DataSet Query_RT_DirectionalAntenna(int intPageIndex, int intPageSize, string strWhere, out string strErr)
        {
            DataSet ds = dal.Query_RT_DirectionalAntenna(intPageIndex, intPageSize, strWhere, out strErr);

            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns[0].ColumnName = "标识卡编号";
                ds.Tables[0].Columns[1].ColumnName = "姓名";
                ds.Tables[0].Columns[2].ColumnName = "部门";
                ds.Tables[0].Columns[3].ColumnName = "巷道分支方向性描述";
                ds.Tables[0].Columns[4].ColumnName = "人员行走方向";
                ds.Tables[0].Columns[5].ColumnName = "当前所在传输分站";
                ds.Tables[0].Columns[6].ColumnName = "当前所在读卡分站";
                ds.Tables[0].Columns[7].ColumnName = "监测时刻";
            }
            return ds;
        }

        #endregion
    }
}
