using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class HisDirectionalAntennaBLL
    {
        private HisDirectionalAntennaDAL dal = new HisDirectionalAntennaDAL();


        #region 历史探头方向性

        public DataSet Query_His_DirectionalAntenna(int intPageIndex, int intPageSize, string strWhere, out string strErr)
        {
            DataSet ds = dal.Query_His_DirectionalAntenna(intPageIndex, intPageSize, strWhere, out strErr);

            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns[0].ColumnName = "标识卡编号";
                ds.Tables[0].Columns[1].ColumnName = "姓名";
                ds.Tables[0].Columns[2].ColumnName = "部门";
                ds.Tables[0].Columns[3].ColumnName = "巷道分支方向性描述";
                ds.Tables[0].Columns[4].ColumnName = "人员行走方向";
                ds.Tables[0].Columns[5].ColumnName = "监测时刻";
            }
            return ds;
        }

        #endregion

        #region 历史进出读卡分站

        public DataSet Query_His_InOutReceiver(int intPageIndex, int intPageSize, string strWhere, out string strErr)
        {
            DataSet ds = dal.Query_His_InOutReceiver(intPageIndex, intPageSize, strWhere, out strErr);

            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns[0].ColumnName = "标识卡编号";
                ds.Tables[0].Columns[1].ColumnName = "姓名";
                ds.Tables[0].Columns[2].ColumnName = "传输分站";
                ds.Tables[0].Columns[3].ColumnName = "读卡分站";
                ds.Tables[0].Columns[4].ColumnName = "读卡分站安装位置";
                ds.Tables[0].Columns[5].ColumnName = "进读卡分站时间";
                ds.Tables[0].Columns[6].ColumnName = "出读卡分站时间";
                ds.Tables[0].Columns[7].ColumnName = "持续时间";
                ds.Tables[0].Columns[8].ColumnName = "进方向";
                ds.Tables[0].Columns[9].ColumnName = "出方向";

            }
            return ds;
        }

        #endregion

        #region 历史进出读卡分站

        public DataSet Query_His_InOutArea(int intPageIndex, int intPageSize, string strWhere, out string strErr)
        {
            DataSet ds = dal.Query_His_InOutArea(intPageIndex, intPageSize, strWhere, out strErr);

            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns[0].ColumnName = "区域名称";
                ds.Tables[0].Columns[1].ColumnName = "区域类型";
                ds.Tables[0].Columns[2].ColumnName = "标识卡号";
                ds.Tables[0].Columns[3].ColumnName = "姓名";
                ds.Tables[0].Columns[4].ColumnName = "进入区域时间";
                ds.Tables[0].Columns[5].ColumnName = "进入区域方向";
                ds.Tables[0].Columns[6].ColumnName = "出区域方向";
                ds.Tables[0].Columns[7].ColumnName = "出区域时间";
                ds.Tables[0].Columns[8].ColumnName = "停留时间";

            }
            return ds;
        }

        #endregion
    }
}
