using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    /// <summary>
    /// 领导每月下进总数及时间统计

    /// </summary>
    public class A_LeadMonthStatementBLL
    {
        private A_LeadMonthStatementDAL dal = new A_LeadMonthStatementDAL();

        /// <summary>
        /// 下井统计信息
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>数据集</returns>
        public DataSet SelectLeadMonthStatementInfo(DateTime beginTime, DateTime endTime)
        {
            if (dal == null)
                dal = new A_LeadMonthStatementDAL();

            return dal.SelectLeadMonthStatementInfo(beginTime, endTime);
        }

        /// <summary>
        /// 下井统计信息
        /// </summary>
        /// <param name="dateTime">查询时间</param>
        /// <returns>数据集</returns>
        public DataSet SelectLeadMonthStatementInfo(DateTime dateTime)
        {
            DateTime beginTime = Convert.ToDateTime(Convert.ToDateTime(dateTime.ToString("yyyy-MM") + "-01 00:00:00").ToString("yyyy-MM-dd HH:mm:ss"));

            DateTime endTime = Convert.ToDateTime(dateTime.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss"));

            if (dal == null)
                dal = new A_LeadMonthStatementDAL();

            return dal.SelectLeadMonthStatementInfo(beginTime, endTime);
        }


        #region 【Czlt-2011-09-10 查询领导月下井记录】
        public DataSet CzltGetMonth(DateTime beginTime, DateTime endTime, string strDeptWhere, string strDutyClassWhere, string strTime)
        {
            if (dal == null)
                dal = new A_LeadMonthStatementDAL();

            return dal.CzltGetMonth(beginTime,endTime, strDeptWhere, strDutyClassWhere, strTime);
        }
        #endregion
    }
}
