using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    /// <summary>
    /// 实时进出重点区域BLL类
    /// </summary>
    public class RealTimeInOutKeyAreaBLL
    {
        private RealTimeInOutKeyAreaDAL dal = new RealTimeInOutKeyAreaDAL();

        /// <summary>
        /// 查询实时进出重点区域信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>数据表</returns>
        public DataTable SelectRealTimeInOutKeyAreaInfo(string condition)
        {
            if (dal == null)
                dal = new RealTimeInOutKeyAreaDAL();

            return dal.SelectRealTimeInOutKeyAreaInfo(condition);
        }
    }



    /// <summary>
    /// 历史进出重点区域BLL类
    /// </summary>
    public class HistoryInOutKeyAreaBLL
    {
        private HistoryInOutKeyAreaDAL dal = new HistoryInOutKeyAreaDAL();

        /// <summary>
        /// 查询历史进出重点区域信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>数据表</returns>
        public DataSet SelectHistoryInOutKeyAreaInfo(int pageIndex, int pageSize, string where)
        {
            if (dal == null)
                dal = new HistoryInOutKeyAreaDAL();

            return dal.SelectHistoryInOutKeyAreaInfo(pageIndex,pageSize,where);
        }
    }
}
