using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class Li_HistoryInOutAntenna_DAL
    {
        #region [ 申明 ]

        private DBAcess dbacc = new DBAcess();
        private DataSet ds;
        private string strSql = string.Empty;

        #endregion

        #region 获取(分站, 接收器)基本信息
        public DataSet N_GetStationInfo()
        {
            strSql = " Select StationAddress, StationPlace From Station_Info ";
            return dbacc.GetDataSet(strSql);
        }

        public DataSet N_GetStationHeadInfo(string strStationAddress)
        {
            strSql = " Select StationHeadAddress, StationHeadPlace From Station_Head_Info Where StationAddress = " + strStationAddress;
            return dbacc.GetDataSet(strSql);
        }
        #endregion

        #region 查询历史进出天线信息
        public DataSet N_GetHisInOutAntennaSet(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "KJ128N_HisInOutAntenna_Info_View";
            para[1].Value = "HisInStationID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dbacc.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }
        #endregion
    }
}
