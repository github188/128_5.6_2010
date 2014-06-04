using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    /// <summary>
    /// 日下井路线报表BLL
    /// </summary>
    public class A_InMineDayReportBLL
    {
        private A_InMineDayReportDAL dal = new A_InMineDayReportDAL();

        /// <summary>
        /// 获取日下井路线报表信息
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="where">查询条件</param>
        /// <returns>数据集</returns>
        public DataTable SelectInMineDayReportInfo(int pageIndex, int pageSize, string where)
        {
            if (dal == null)

                dal = new A_InMineDayReportDAL();

            DataSet ds = dal.SelectInMineDayReportInfo(pageIndex, pageSize, where);

            return new DataTable();
        }

        /// <summary>
        /// 获取日下井路线报表信息
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>数据集</returns>
        public DataTable SelectInMineDayReportInfo(string where)
        {
            if (dal == null)

                dal = new A_InMineDayReportDAL();

            DataSet ds = dal.SelectInMineDayReportInfo(where);


            /*
             * Process DataSet Logic
             */

            return new DataTable();
        }
    }
}
