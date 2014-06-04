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
    public class RealtimeStationBreakBLL
    {

        #region [ 声明 ]

        private DataSet ds;
        
        private RealtimeStationBreakDAL rtsbdal = new RealtimeStationBreakDAL();

        #endregion

        #region [ 方法: 查询实时分站信息 ]

        /// <summary>
        /// 查询实时分站信息
        /// </summary>
        /// <param name="strState">分站状态</param>
        /// <param name="dv"></param>
        /// <returns></returns>
        public bool N_SearchStaBreakInfo(string strState, DataGridViewKJ128 dv)
        {
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = rtsbdal.N_StaBreakInfo(strState);
                if (ds == null)
                {
                    return false;
                }
                ds.Tables[0].Columns[0].ColumnName = HardwareName.Value(CorpsName.StationAddress);
                ds.Tables[0].Columns[1].ColumnName = HardwareName.Value(CorpsName.StationSplace);
                //ds.Tables[0].Columns[2].ColumnName = HardwareName.Value(CorpsName.Station) + "联系电话";
                //ds.Tables[0].Columns[3].ColumnName = HardwareName.Value(CorpsName.Station) + "状态";
                //ds.Tables[0].Columns[4].ColumnName = HardwareName.Value(CorpsName.Station) + "故障时间";
 
                dv.DataSource = ds.Tables[0].DefaultView;
                dv.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dv.Columns[3].Visible = false;
            }

            return true;
        }
        #endregion

    }
}
