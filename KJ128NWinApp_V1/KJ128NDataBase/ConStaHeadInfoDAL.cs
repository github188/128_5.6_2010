using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class ConStaHeadInfoDAL
    {

        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();

        private string strSql = string.Empty;

        #endregion

        /*
         * 方法
         */ 

        #region [ 方法: 查询分站信息 ]

        /// <summary>
        /// 查询分站信息
        /// </summary>
        /// <returns></returns>
        public DataSet N_GetStationInfo()
        {
            strSql = " Select " +
                        " StationAddress as " + HardwareName.Value(CorpsName.StationAddress) + ", " +
                        " StationPlace as " + HardwareName.Value(CorpsName.StationSplace) + ", " +
                        " StationTel as 联系电话, " +
                        " Et1.Title as 状态 " +
                    " From " +
                        " Station_Info  as Si left join EnumTable as Et1 on Si.StationState=Et1.EnumID and Et1.FunID=7 " +
                        " left join EnumTable as Et2 on Si.StationTypeID=Et2.EnumID and Et2.FunID=1 " +
                    " Order By " +
                        " StationAddress ";
            return dbacc.GetDataSet(strSql);

        }

        #endregion

        #region [ 方法: 按分站编号查询接收器信息 ]

        /// <summary>
        /// 按分站编号查询接收器信息
        /// </summary>
        /// <param name="strStationAddress">分站编号</param>
        /// <returns></returns>
        public DataSet N_GetStationInfo(string strStationAddress)
        {
            strSql = " Select " +
                        " StationHeadAddress as " + HardwareName.Value(CorpsName.StaHeadAddress) + ", " +
                        " StationHeadPlace as " + HardwareName.Value(CorpsName.StaHeadSplace) + ", " +
                        " StationHeadTel as 联系电话, " +
                        " Et1.Title as 状态, " +
                        " AntennaA as 天线A位置, " +
                        " AntennaB as 天线B位置 " +
                    " From " +
                        " Station_Head_Info  as Shi left join EnumTable as Et1 on Shi.StationHeadState=Et1.EnumID and Et1.FunID=7 " +
                        " left join EnumTable as Et2 on Shi.StationHeadTypeID=Et2.EnumID and Et2.FunID=1 " +
                    " Where " +
                        " StationAddress=" + strStationAddress;
            return dbacc.GetDataSet(strSql);

        }

        #endregion

    }
}
