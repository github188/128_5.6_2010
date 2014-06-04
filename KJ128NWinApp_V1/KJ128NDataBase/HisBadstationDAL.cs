using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class HisBadstationDAL
    {

        #region [ 申明 ]

        private DBAcess dbacc = new DBAcess();

        private string strSQL = string.Empty;

        #endregion

        #region [ 方法: 分站故障统计 ]

        public DataSet GetHisBadStationInfo(string strStartTime, string strEndTime, string strStationAddress)
        {
            if (strStationAddress.Trim().Equals(""))
            {
                strSQL = " Select DISTINCT  StationAddress as 分站编号, " +
                            " Count(StationAddress)as '故障次数', " +
                            " (Select dbo.FunConvertTime( sum(BadTime) ) From HistoryBadStations as Hbs2 " +
                            "  Where Hbs1.StationAddress=Hbs2.StationAddress and Hbs2.StationHeadAddress=0 "+
                            "  And Hbs2.BadBeginTime >='" + strStartTime + "' And Hbs2.BadBeginTime <='"+strEndTime+ "' ) as '故障时间' " +
                            " From HistoryBadStations as Hbs1 " +
                            " Where StationHeadAddress =0 And Hbs1.BadBeginTime >='" + strStartTime + "' And Hbs1.BadBeginTime <='"+strEndTime+"' "+
                            " Group by StationAddress ";
            }
            else
            {
                strSQL = " Select DISTINCT  StationAddress as 分站编号, " +
                            " Count(StationAddress)as '故障次数', " +
                            " (Select dbo.FunConvertTime( sum(BadTime) ) From HistoryBadStations as Hbs2 " +
                            "  Where Hbs1.StationAddress=Hbs2.StationAddress and Hbs2.StationHeadAddress=0 " +
                            "  And Hbs2.BadBeginTime >='" + strStartTime + "' And Hbs2.BadBeginTime <='" + strEndTime + "' And Hbs2.StationAddress="+strStationAddress+" ) as '故障时间' " +
                            " From HistoryBadStations as Hbs1 " +
                            " Where StationHeadAddress =0 And Hbs1.BadBeginTime >='" + strStartTime + "' And Hbs1.BadBeginTime <='" + strEndTime + "' And Hbs1.StationAddress="+strStationAddress +
                            " Group by StationAddress ";

            }
            return dbacc.GetDataSet(strSQL);
        }

        #endregion 

        #region [ 方法: 接收器故障统计 ]

        public DataSet GetHisBadStaHeadInfo(string strStartTime, string strEndTime, string strStationAddress)
        {
            if (strStationAddress.Trim().Equals(""))
            {
                strSQL = "Select DISTINCT  StationAddress as 分站编号, " +
                    " StationHeadAddress as 接收器编号, " +
                    " Count(1) as '故障测试', " +
                    " (Select  dbo.FunConvertTime(sum(Hbs2.BadTime)) " +
                    " From HistoryBadStations as Hbs2 Where Hbs1.StationAddress=Hbs2.StationAddress " +
                    " and Hbs1.StationHeadAddress=Hbs2.StationHeadAddress and Hbs2.StationHeadAddress<>0 and " +
                    " Hbs2.BadBeginTime >='" + strStartTime + "' And Hbs2.BadBeginTime <='" + strEndTime + "' " +
                    " ) as '总故障时间' " +
                    " From HistoryBadStations as Hbs1 " +
                    " Where Hbs1.StationHeadAddress<>0 And " + " Hbs1.BadBeginTime >='" + strStartTime + "' And Hbs1.BadBeginTime <='" + strEndTime + "' " +
                    " Group by StationAddress ,StationHeadAddress " +
                    " Order by Hbs1.StationAddress ,Hbs1.StationHeadAddress ";
            }
            else
            {
                strSQL = "Select DISTINCT  StationAddress as 分站编号, " +
                    " StationHeadAddress as 接收器编号, " +
                    " Count(1) as '故障测试', " +
                    " (Select  dbo.FunConvertTime(sum(Hbs2.BadTime)) " +
                    " From HistoryBadStations as Hbs2 Where Hbs1.StationAddress=Hbs2.StationAddress " +
                    " and Hbs1.StationHeadAddress=Hbs2.StationHeadAddress and Hbs2.StationHeadAddress<>0 and " +
                    " Hbs2.BadBeginTime >='" + strStartTime + "' And Hbs2.BadBeginTime <='" + strEndTime + "' And Hbs2.StationAddress=" + strStationAddress +
                    " ) as '总故障时间' " +
                    " From HistoryBadStations as Hbs1 " +
                    " Where Hbs1.StationHeadAddress<>0 And " + " Hbs1.BadBeginTime >='" + strStartTime + "' And Hbs1.BadBeginTime <='" + strEndTime +"' And Hbs1.StationAddress="+strStationAddress+
                    " Group by StationAddress ,StationHeadAddress " +
                    " Order by Hbs1.StationAddress ,Hbs1.StationHeadAddress ";

            }
            return dbacc.GetDataSet(strSQL);
        }

        #endregion 

    }
}
