using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;


namespace KJ128NDBTable
{
    /// <summary>
    /// 实时进出
    /// </summary>
    public class RealTimeStationHeadStatBLL
    {
        private RealTimeStationHeadStatDAL dal = new RealTimeStationHeadStatDAL();
        
        /// <summary>
        /// 查询实时进出天线人数统计信息
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>统计出来的信息表</returns>
        public DataTable SelectRealTimeSationHeadStatInfo(DateTime beginTime, DateTime endTime)
        {
            return dal.SelectRealTimeSationHeadStatInfo(beginTime, endTime);
        }
    }
}
