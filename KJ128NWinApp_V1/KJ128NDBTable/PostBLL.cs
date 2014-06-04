using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    /// <summary>
    /// 实时岗位异常
    /// </summary>
    public class RealTimePostBLL
    {
        RealTimePostDAL dal = new RealTimePostDAL();

        /// <summary>
        /// 查询实时岗位异常信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>返回查询结果</returns>
        public DataTable SelectRealTimePostInfo(string condition)
        {
            if (dal == null)
                dal = new RealTimePostDAL();

            return dal.SelectRealTimePostInfo(condition);
        }

        /// <summary>
        /// 查询岗位异常报警信息
        /// </summary>
        /// <returns>返回查询结果</returns>
        public DataTable SelectRealTimePostAlarmInfo(string condition)
        {
            if (dal == null)
                dal = new RealTimePostDAL();

            return dal.SelectRealTimePostAlarmInfo(condition);
        }

        /// <summary>
        /// 修改实时岗位异常报警信息措施信息
        /// </summary>
        /// <param name="id">异常报警信息id</param>
        /// <param name="measure">措施内容</param>
        /// <returns>返回影响的行数</returns>
        public int UpdateRealTimePostAlarmInfoMeasure(int id, string measure)
        {

            if (dal == null)
                dal = new RealTimePostDAL();
            return dal.UpdateRealTimePostAlarmInfoMeasure(id, measure);
        }

        /// <summary>
        /// 删除（完成）实时岗位异常报警信息，再写入历史
        /// </summary>
        /// <param name="id">岗位异常报警信息Id</param>
        /// <returns>返回影响的行数</returns>
        public int DeleteRealTimePostAlarmInfoToHistory(int id)
        {
            if (dal == null)
                dal = new RealTimePostDAL();

            return dal.DeleteRealTimePostAlarmInfoToHistory(id);
        }
    }

    /// <summary>
    /// 历史岗位异常
    /// </summary>
    public class HistoryPostBLL
    {
        private HistoryPostDAL dal = new HistoryPostDAL();

        /// <summary>
        /// 根据条件查询历史岗位异常信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>返回查询结果</returns>
        public DataSet SelectHistoryPostInfoByCondition(int pIndex, int pSize, string where)
        {
            if (dal == null)
                dal = new HistoryPostDAL();
            return dal.SelectHistoryPostInfoByCondition(pIndex, pSize, where);
        }
    }
}
