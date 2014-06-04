using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    /// <summary>
    /// 实时进出限制区域BLL类
    /// </summary>
    public class RealTimeInOutConfineAreaBLL
    {
        private RealTimeInOutConfineAreaDAL dal = new RealTimeInOutConfineAreaDAL();

        /// <summary>
        /// 查询实时进出限制区域信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>数据表</returns>
        public DataTable SelectRealTimeInOutConfineAreaInfo(string condition)
        {
            if (dal == null)
                dal = new RealTimeInOutConfineAreaDAL();

            return dal.SelectRealTimeInOutConfineAreaInfo(condition);
        }
    }

    /// <summary>
    /// 历史进出限制区域BLL类
    /// </summary>
    public class HistoryInOutConfineAreaBLL
    {
        private HistoryInOutConfineAreaDAL dal = new HistoryInOutConfineAreaDAL();

        /// <summary>
        /// 查询历史进出限制区域信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>数据表</returns>
        public DataSet SelectHistoryInOutConfineAreaInfo(int pageIndex, int pageSize, string where)
        {
            if (dal == null)
                dal = new HistoryInOutConfineAreaDAL();

            return dal.SelectHistoryInOutConfineAreaInfo(pageIndex, pageSize, where);
        }
    }
}
