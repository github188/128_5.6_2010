using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace KJ128NDataBase
{
    /// <summary>
    /// 特殊人员作业报警总数及时间统计

    /// </summary>
    public class A_WorkExceptionStatementDAL
    {
        #region[声明]

        private DBAcess dba = new DBAcess();

        #endregion


        /// <summary>
        /// 特殊人员作业报警总数及时间统计信息

        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>数据集</returns>
        public DataSet SelectWorkExceptionStatementInfo(DateTime beginTime, DateTime endTime)
        {
            SqlParameter[] para = { new SqlParameter("@beginTime",SqlDbType.DateTime),
                                    new SqlParameter("@endTime",SqlDbType.DateTime)
            };

            para[0].Value = beginTime;
            para[1].Value = endTime;

            DataSet ds = dba.ExecuteSqlDataSet("workExceptionStatement", para);

            return ds;
        }
    }
}
