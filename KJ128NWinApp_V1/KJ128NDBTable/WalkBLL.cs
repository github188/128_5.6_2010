using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;
using KJ128NModel;

namespace KJ128NDBTable
{
    /// <summary>
    /// 实时行走异常
    /// </summary>
    public class RealTimeWalkBLL
    {
        RealTimeWalkDAL dal = new RealTimeWalkDAL();

        /// <summary>
        /// 查询实时行走异常报警信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectRealTimeWalkAlarmInfo(string condition)
        {
            return dal.SelectRealTimeWalkAlarmInfo(condition); 
        }

        /// <summary>
        /// 修改实时行走异常措施
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>返回操作影响的行数</returns>
        public int UpdateRealTimeWalkMeasure(int id, string measure)
        {
            return dal.UpdateRealTimeWalkMeasure(id, measure);
        }

        /// <summary>
        /// 完成（删除）实时行走异常信息，再写入历史
        /// </summary>
        /// <returns>返回操作影响的行数</returns>
        public int DeleteRealTimeWalkInfoToHistroy(int id)
        {
            return dal.DeleteRealTimeWalkInfoToHistroy(id);
        }
    }

    /// <summary>
    /// 历史行走异常
    /// </summary>
    public class HistoryWalkBLL
    {
        HistoryWalkDAL dal = new HistoryWalkDAL();

        /// <summary>
        /// 查询历史行走异常信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>返回查询到的记录</returns>
        public DataSet SelectHiatoryWalkInfo(int pIndex, int pSize, string where)
        {
            return dal.SelectHiatoryWalkInfo(pIndex, pSize, where);
        }
    }


    /// <summary>
    /// 行走异常配置类
    /// </summary>
    public class WalkConfigBLL
    {
        WalkConfigDAL dal = new WalkConfigDAL();


        /// <summary>
        /// 查询行走异常配置信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>返回查询到的记录</returns>
        public DataTable SelectWalkConfigInfo(string condition)
        {
            return dal.SelectWalkConfigInfo(condition);
        }

        /// <summary>
        /// 添加行走异常配置信息
        /// </summary>
        /// <returns>返回执行结果行数</returns>
        public int InsertWalkConfigInfo(WalkConfigModel model)
        {
            return dal.InsertWalkConfigInfo(model);
        }

        /// <summary>
        /// 更新行走异常配置信息
        /// </summary>
        /// <returns>返回执行影响的行数</returns>
         public int UpdateWalkConfigInfo(WalkConfigModel model)
        {
            return dal.UpdateWalkConfigInfo(model);
        }

        /// <summary>
        /// 删除行走异常配置信息
        /// </summary>
        /// <param name="id">行走异常配置信息Id</param>
        /// <returns>返回执行影响的行数</returns>
        public int DeleteWalkConfigInfo(int id)
        {
            return dal.DeleteWalkConfigInfo(id);
        }
    }
}
