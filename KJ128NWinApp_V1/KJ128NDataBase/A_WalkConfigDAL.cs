using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class A_WalkConfigDAL
    {
        #region【声明】

        private DBAcess dba = new DBAcess();

        private string strSQL;

        #endregion

        #region 【方法: 查询行走异常配置信息】

        public DataSet SelectSpeedConfig(string strWhere)
        {
            strSQL = " Select FirstStationAddress as 起始传输分站编号, " +
                        " FirstStationHeadAddress as 起始读卡分站编号, " +
                        " Shi1.StationHeadPlace as 起始读卡分站位置, " +
                        " LastStationAddress as 终点传输分站编号, " +
                        " LastStationHeadAddress as 终点读卡分站编号, " +
                        " Shi2.StationHeadPlace as 终点读卡分站位置, " +
                        " OverSpeedTime = case when WalkTime=-1 then null else dbo.FunConvertTime(WalkTime) end, " +
                        " LackSpeedTime = case When LackWalkTime =-1 then null else dbo.FunConvertTime(LackWalkTime) end," +
                        " Os.Remark as 备注,OverSpeedID " +
                   " From OverSpeed as Os left join Station_Head_Info as Shi1 on Os.FirstStationAddress=Shi1.StationAddress and Os.FirstStationHeadAddress=Shi1.StationHeadAddress " +
                        " Left join Station_Head_Info as Shi2 on Os.LastStationAddress = Shi2.StationAddress and Os.LastStationHeadAddress=Shi2.StationHeadAddress " +
                   " Where " + strWhere;

            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取(分站, 接收器)基本信息】

        public DataSet N_GetStationInfo()
        {
            strSQL = " Select StationAddress, StationPlace From Station_Info Order By  StationAddress";
            return dba.GetDataSet(strSQL);
        }

        public DataSet N_GetStationHeadInfo(string strStationAddress)
        {
            strSQL = " Select StationHeadAddress, StationHeadPlace From Station_Head_Info Where StationAddress = " + strStationAddress + " Order by StationHeadAddress";
            return dba.GetDataSet(strSQL);
        }
        #endregion

        #region【方法：添加、修改超速配置信息】

        public int WalkConfig_InsertAndUpDate(int intFirstStationAddress, int intFirstStationHeadAddress, int intLastStationAddress,
            int intLastStationHeadAddress, int intWalkTime, string strRemark,int intLackWalkTime)
        {
            SqlParameter[] para = { new SqlParameter("@FirstStationAddress",SqlDbType.Int),
                                    new SqlParameter("@FirstStationHeadAddress",SqlDbType.Int),
                                    new SqlParameter("@LastStationAddress",SqlDbType.Int),
                                    new SqlParameter("@LastStationHeadAddress",SqlDbType.Int),
                                    new SqlParameter("@WalkTime",SqlDbType.Int),
                                    new SqlParameter("@Remark",SqlDbType.NVarChar,200),
                                    new SqlParameter("@LackWalkTime",SqlDbType.Int),
                                    new SqlParameter("@ID",SqlDbType.Int)
            };
            para[0].Value = intFirstStationAddress;
            para[1].Value = intFirstStationHeadAddress;
            para[2].Value = intLastStationAddress;
            para[3].Value = intLastStationHeadAddress;
            para[4].Value = intWalkTime;
            para[5].Value = strRemark;
            para[6].Value = intLackWalkTime;
            para[7].Value = (intFirstStationAddress.ToString() + "," + intFirstStationHeadAddress.ToString() + ";" + intLastStationAddress.ToString() + "," + intLastStationHeadAddress.ToString()).GetHashCode();

            return dba.ExecuteSql("A_WalkSpeed_InsertAndUpDate", para);
        }

        #endregion

        #region【方法：删除超速配置信息】

        public int WalkConfig_Delete(string strOverSpeedID)
        {
            SqlParameter[] para = { new SqlParameter("@strOverSpeedID",SqlDbType.VarChar,6000)
            };
            para[0].Value = strOverSpeedID;

            return dba.ExecuteSql("A_WalkSpeed_Delete_All", para);
        }

        #endregion

        #region【方法：判断数据库中是否存在起始和终点测点】

        public DataSet CheckingOverSpeed(string strFirstStationAddress, string strFirstStationHeadAddress, string strLastStationAddress, string strLastStationHeadAddress)
        {
            strSQL = " Select * From OverSpeed Where FirstStationAddress = " + strFirstStationAddress + " And FirstStationHeadAddress = " + strFirstStationHeadAddress +
                            " And LastStationAddress = " + strLastStationAddress + " And LastStationHeadAddress = " + strLastStationHeadAddress;

            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：查询行走异常配置信息——绑定修改数据】

        public DataSet SelectWalkConfig_Binding(int intOverSpeedID)
        {
            strSQL = " Select * From OverSpeed Where OverSpeedID = " + intOverSpeedID.ToString();

            return dba.GetDataSet(strSQL);
        }

        #endregion
    }
}
