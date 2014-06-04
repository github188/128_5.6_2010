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
    public class Li_RealTimeInOutAntennaInfo_BLL : Li_HistoryInOutAntenna_BLL
    {

        #region [ 声明 ]

        private DataSet ds;

        private Li_RealTimeInOutAntennaInfo_DAL lrtodal = new Li_RealTimeInOutAntennaInfo_DAL();

        #endregion

        #region [ 方法: 查询实时天线信息 ]

        public bool N_SearchRTInOutAntennaInfo(
            string strStartTime, 
            string strEndTime, 
            string strCard, 
            string strStationAddress, 
            string strStationHeadAddress,
            int intUserType,
            DataGridViewKJ128 dv,
            out string strCounts)
        {
            if (DateTime.Compare(DateTime.Parse(strStartTime), DateTime.Parse(strEndTime)) > 0)
            {
                MessageBox.Show("对不起, 开始时间不能大于结束时间！");
                strCounts = "-1";
                return false;
            }
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = lrtodal.N_SearchRTInOutAntennaInfo(strStartTime, strEndTime, strCard, strStationAddress, strStationHeadAddress,intUserType);

                dv.DataSource = ds.Tables[0];
                if (ds != null && ds.Tables.Count > 0)
                {
                    dv.Columns[3].FillWeight = 150;

                    dv.Columns[0].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);
                    dv.Columns[1].HeaderText = HardwareName.Value(CorpsName.StationAddress);
                    dv.Columns[2].HeaderText = HardwareName.Value(CorpsName.StaHeadAddress);
                    dv.Columns[3].HeaderText = HardwareName.Value(CorpsName.StaHead) + "监测时间";


                    //将监测时间精确到秒
                    dv.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        strCounts = ds.Tables[0].Rows.Count.ToString();
                    }
                    else
                    {
                        strCounts = "0";
                    }

                }
                else
                {
                    strCounts = "0";
                }
            }

            return true;
        }
        #endregion
    }
}
