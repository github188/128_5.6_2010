using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class Li_RealTimeInOutAntennaInfo_DAL
    {

        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();

        private string strSql = string.Empty;

        #endregion

        #region [ 方法: 查询实时天线信息 ]

        public DataSet N_SearchRTInOutAntennaInfo(
            string strStartTime,
            string strEndTime,
            string strCard,
            string strStationAddress,
            string strStationHeadAddress,
            int intUserType )
        {
            strSql = " Select " +
                        " Ri.CodeSenderAddress As " + HardwareName.Value(CorpsName.CodeSenderAddress) + ", " +
                        " StationAddress As " + HardwareName.Value(CorpsName.StationAddress) + ", " +
                        " StationHeadAddress As " + HardwareName.Value(CorpsName.StaHeadAddress) + ", " +
                        " StationHeadDetectTime As 接收器监测时间, " +
                        " StationHeadAntennaA As 天线A, " +
                        " StationHeadAntennaB As 天线B, " +
                        " 进出状态=case InStationHeadAntenna when 1 then '进读卡分站' when 2 then '进读卡分站' else '出读卡分站' end, " +
                        " LastStationAddress As 上次" + HardwareName.Value(CorpsName.StationAddress) + ", " +
                        " LastStationHeadAddress As 上次" + HardwareName.Value(CorpsName.StaHeadAddress) + ", " +
                        " LastStationHeadAntennaA As 上次天线A, " +
                        " LastStationHeadAntennaB As 上次天线B " +
                     " From " +
                        " RT_InOutStation  as Ri " +
                        " left join CodeSender_Set as Css on Ri.CodeSenderAddress=Css.CodeSenderAddress " +
                     " Where " +
                        " StationHeadDetectTime >= '" + strStartTime + "' And StationHeadDetectTime <= '" + strEndTime + "' ";

            if (!(strCard.Equals("") | strCard.Equals(null)))
            {
                strSql += " And Ri.CodeSenderAddress = " + strCard;
            }

            ////发码器类型
            if (intUserType.Equals(2))  //未登记发码器
            {
                strSql += " And CsTypeID is Null ";
            }
            else if (intUserType.Equals(1) || intUserType.Equals(0))    //人员、设备
            {
                strSql += " And CsTypeID =" + intUserType;
            }

            if (!(strStationAddress.Equals("0")))
            {
                strSql += " And StationAddress = " + strStationAddress;
            }

            if (!(strStationHeadAddress.Equals("0")))
            {
                strSql += " And StationHeadAddress = " + strStationHeadAddress;
            }

            return dbacc.GetDataSet(strSql);
        }

        #endregion
    }
}
