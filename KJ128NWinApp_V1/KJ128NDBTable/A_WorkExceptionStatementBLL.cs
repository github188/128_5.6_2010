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
    public class A_WorkExceptionStatementBLL
    {
        private A_WorkExceptionStatementDAL dal = new A_WorkExceptionStatementDAL();

        /// <summary>
        /// 特殊人员作业报警总数及时间统计信息

        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>数据集</returns>
        public DataSet SelectWorkExceptionStatementInfo(DateTime beginTime, DateTime endTime)
        {
            if (dal == null)
                dal = new A_WorkExceptionStatementDAL();
            return dal.SelectWorkExceptionStatementInfo(beginTime, endTime);
        }

        /// <summary>
        /// 特殊人员作业报警总数及时间统计信息

        /// </summary>
        /// <param name="dateTime">查询时间</param>
        /// <returns>数据集</returns>
        public DataSet SelectWorkExceptionStatementInfo(DateTime dateTime)
        {
            DateTime beginTime = DateTime.Parse(dateTime.ToString("yyyy-MM-dd") + " 00:00:00");
            DateTime endTime = DateTime.Parse(dateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            //dateTime 

            if (dal == null)
                dal = new A_WorkExceptionStatementDAL();
            return dal.SelectWorkExceptionStatementInfo(beginTime, endTime);
        }

    }
}
