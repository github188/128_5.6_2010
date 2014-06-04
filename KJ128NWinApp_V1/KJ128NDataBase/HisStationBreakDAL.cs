using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class HisStationBreakDAL
    {
        private DBAcess dbacc = new DBAcess();
        private string strSql = string.Empty;

        #region 获取区域类别
        public DataSet GetStaPlaceInfo()
        {
            strSql = " Select StationAddress, StationPlace From Station_Info ";
            return dbacc.GetDataSet(strSql);
        }
        #endregion

        #region 查询 历史分站接收器故障信息
        public DataSet GetHisInTerInfoSet(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };

            para[0].Value = "KJ128N_HisStaBreakInfo_View";
            para[1].Value = "HistoryBadStationsID";
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
