using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class A_RealTimeInWellBll
    {
        #region 【自定义参数】
        private A_RealTimeInWellDAL realtimeInWellDal = new A_RealTimeInWellDAL();
        #endregion

        #region 【自定义方法】

        #region 【方法组：获取各个树信息】
        /// <summary>
        /// 获取部门树信息
        /// </summary>
        public DataSet GetRealTime_DeptTree()
        {
            return realtimeInWellDal.GetRealTime_DeptTree();
        }
        /// <summary>
        /// 获取工种树信息
        /// </summary>
        public DataSet GetRealTime_WorkTypeTree()
        {
            return realtimeInWellDal.GetRealTime_WorkTypeTree();
        }
        /// <summary>
        /// 获取工种树信息
        /// </summary>
        public DataSet GetRealTime_DutyInfoTree()
        {
            return realtimeInWellDal.GetRealTime_DutyInfoTree();

        }
        /// <summary>
        /// 获取方向性树信息
        /// </summary>
        public DataSet GetRealTime_DirectionalTree()
        {
            return realtimeInWellDal.GetRealTime_DirectionalTree();

        }
        /// <summary>
        /// 获取职务等级树信息
        /// </summary>
        public DataSet GetRealTime_DutyLeverTree()
        {
            return realtimeInWellDal.GetRealTime_DutyLeverTree();

        }

        #endregion

        #region 【方法：获取实时下井人员信息】
        /// <summary>
        /// 实时下井信息
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页显示行数量</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public DataSet GetRealTimeInWell(int pageIndex, int pageSize, string where)
        {
            return realtimeInWellDal.GetRealTimeInWell(pageIndex, pageSize, where);
        }
        #endregion
        #endregion
    }
}
