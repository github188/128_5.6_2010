using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;

using KJ128NDataBase;
using KJ128NInterfaceShow;

namespace KJ128NDBTable
{
    public class RealTimeStaHeadBreakBLL
    {

        #region [ 声明 ]

        private RealTimeStaHeadBreakDAL rtshdal = new RealTimeStaHeadBreakDAL();

        private DataSet ds;

        #endregion

        #region [ 方法: 根据分站状态获取接收器信息 ]

        /// <summary>
        /// 根据分站状态获取接收器信息
        /// </summary>
        /// <param name="strState">分站状态</param>
        /// <returns></returns>
        private DataSet N_GetStaHeadBreakInfo(string strState)
        {
            return rtshdal.N_GetStaHeadBreakInfo(strState);
        }

        #endregion

        #region [ 方法: 查询实时接收器信息 ]

        /// <summary>
        /// 查询实时接收器信息
        /// </summary>
        /// <param name="strState">分站编号</param>
        /// <param name="dv"></param>
        /// <returns></returns>
        public bool N_SearchStaHeadBreakInfo(string strState,DataGridViewKJ128 dv)
        {
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = this.N_GetStaHeadBreakInfo(strState);
                if (ds == null )
                {
                    return false;
                }
                ds.Tables[0].Columns[0].ColumnName = HardwareName.Value(CorpsName.StationAddress);
                ds.Tables[0].Columns[1].ColumnName = HardwareName.Value(CorpsName.StationSplace);
                ds.Tables[0].Columns[2].ColumnName = HardwareName.Value(CorpsName.StaHeadAddress);
                ds.Tables[0].Columns[3].ColumnName = HardwareName.Value(CorpsName.StaHeadSplace);
                ds.Tables[0].Columns[4].ColumnName = HardwareName.Value(CorpsName.StaHead) + "联系电话";
                ds.Tables[0].Columns[5].ColumnName = HardwareName.Value(CorpsName.StaHead) + "类型";
                ds.Tables[0].Columns[6].ColumnName = HardwareName.Value(CorpsName.StaHead) + "状态";
                ds.Tables[0].Columns[7].ColumnName = HardwareName.Value(CorpsName.StaHead) + "故障时间";

                dv.DataSource = ds.Tables[0].DefaultView;
                dv.Columns[0].FillWeight = 40;
                dv.Columns[2].FillWeight = 55;
                dv.Columns[3].FillWeight = 150;
                dv.Columns[6].FillWeight = 70;
                dv.Columns[7].FillWeight = 120;
                dv.Columns[7].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            }

            return true;
        }
        #endregion

    }
}
