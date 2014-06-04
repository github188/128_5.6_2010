using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    /// <summary>
    /// 实时进出天线人数统计
    /// </summary>
    public class RealTimeStationHeadStatDAL
    {
        private DbHelperSQL help = new DbHelperSQL();

        /// <summary>
        /// 查询实时进出天线人数统计信息
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>统计出来的信息表</returns>
        public DataTable SelectRealTimeSationHeadStatInfo(DateTime beginTime,DateTime endTime)
        {

            SqlParameter[] para = new SqlParameter[] {
                new SqlParameter("@beginTime",SqlDbType.DateTime),
                new SqlParameter("@endTime",SqlDbType.DateTime)
            };

            para[0].Value = beginTime;
            para[1].Value = endTime;

            return help.ReturnDataTable("StatCount", para);
        }
    }
}
