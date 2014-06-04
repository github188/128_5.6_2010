using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    /// <summary>
    /// 按时间段查询所有员工状态信息
    /// </summary>
    public class AllEmpStateBLL
    {
        private AllEmpStateDAL dal = new AllEmpStateDAL();

        /// <summary>
        /// 按时间段查询所有员工状态信息
        /// </summary>
        /// <param name="beginTime">查询开始时间</param>
        /// <param name="endTime">查询结束时间</param>
        /// <returns>返回DataTable数据表</returns>
        public DataTable SelectAllEmpStateInfo(DateTime beginTime, DateTime endTime)
        {
            if (dal == null)
                dal = new AllEmpStateDAL();
            return dal.SelectAllEmpStateInfo(beginTime, endTime);
        }
    }
}
