using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    /// <summary>
    /// 按时间段查询所有员工状态信息
    /// </summary>
    public class AllEmpStateDAL
    {
        private DbHelperSQL help = new DbHelperSQL();

        /// <summary>
        /// 按时间段查询所有员工状态信息
        /// </summary>
        /// <param name="beginTime">查询开始时间</param>
        /// <param name="endTime">查询结束时间</param>
        /// <returns>返回DataTable数据表</returns>
        public DataTable SelectAllEmpStateInfo(DateTime beginTime,DateTime endTime)
        {
            SqlParameter[] para = {
                new SqlParameter("@beginTime",SqlDbType.DateTime),
                 new SqlParameter("@endTime",SqlDbType.DateTime)
            };
            para[0].Value = beginTime;
            para[1].Value = endTime;

            return help.ReturnDataTable("selectEmpStateByTime", para);
        }
    }
}
