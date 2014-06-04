using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;
using KJ128NModel;

namespace KJ128NDBTable
{
    /// <summary>
    /// 实时地域信息BLL类
    /// </summary>
    public class RealTimeClimeBLL
    {
        private RealTimeClimeDAL dal = new RealTimeClimeDAL();

        /// <summary>
        /// 查询实时地域信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>返回DataTable数据表</returns>
        public DataTable SelectRealTimeClimeInfo(string condition)
        {
            if (dal == null)
                dal = new RealTimeClimeDAL();

            return dal.SelectRealTimeClimeInfo(condition);
        }
    }


    /// <summary>
    /// 历史地域信息BLL类
    /// </summary>
    public class HistoryClimeBLL
    {
        private HistoryClimeDAL dal = new HistoryClimeDAL();

        /// <summary>
        /// 查询历史地域信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>返回DataTable数据表</returns>
        public DataSet SelectHistoryClimeInfo(int pageIndex, int pageSize, string where)
        {
            if (dal == null)
                dal = new HistoryClimeDAL();

            return dal.SelectHistoryClimeInfo(pageIndex, pageSize, where);
        }
    }

}
