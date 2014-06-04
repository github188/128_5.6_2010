using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using KJ128NInterfaceShow;
using System.Data;

namespace KJ128NDBTable
{
    public class HisBadstationBLL
    {

        #region [ 申明 ]

        private HisBadstationDAL hbdal = new HisBadstationDAL();

        private DataSet ds; 

        #endregion

        #region [ 方法: 分站故障统计 ]

        public bool GetHisBadStationInfo(string strStartTime, string strEndTime, string strStationAddress, DataGridViewKJ128 dv)
        {
            using (ds = new DataSet())
            {
                try
                {
                    dv.Columns.Clear();

                    ds = hbdal.GetHisBadStationInfo(strStartTime, strEndTime, strStationAddress);



                    if (ds != null && ds.Tables.Count >= 0)
                    {
                        dv.DataSource = ds.Tables[0];

                        dv.Columns[0].HeaderText = HardwareName.Value(CorpsName.StationAddress);
                    }
                }
                catch (Exception)
                {
                    dv.DataSource = null;
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region [ 方法: 接收器故障统计 ]

        public bool GetHisBadStaHeadInfo(string strStartTime, string strEndTime, string strStationAddress, DataGridViewKJ128 dv)
        {
            using (ds = new DataSet())
            {
                try
                {
                    dv.Columns.Clear();

                    ds = hbdal.GetHisBadStaHeadInfo(strStartTime, strEndTime, strStationAddress);

                    if (ds != null && ds.Tables.Count >= 0)
                    {
                        dv.DataSource = ds.Tables[0];

                        dv.Columns[0].HeaderText = HardwareName.Value(CorpsName.StationAddress);

                        dv.Columns[1].HeaderText = HardwareName.Value(CorpsName.StaHeadAddress);
                    }
                }
                catch (Exception)
                {
                    dv.DataSource = null;
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
