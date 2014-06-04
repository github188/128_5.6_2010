using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class A_HisInWellBLL
    {
        /// <summary>
        /// 历史进出井逻辑对象
        /// </summary>
        private A_HisInWellDAL hisInWellDal = new A_HisInWellDAL();

        #region 【自定义方法】
        #region 【获取各个树控件的表信息】
        /// <summary>
        /// 获取部门树信息
        /// </summary>
        public DataSet GetHisDeptTree(DateTime beginTime,DateTime endTime)
        {
            string strWhere = "inTime>='" + beginTime.ToString("yyyy-MM-dd HH:mm:ss") + "' and inTime<='" + endTime.ToString("yyyy-MM-dd HH:mm:ss")+"'";
            return hisInWellDal.GetHisDeptTree(strWhere);
        }
        /// <summary>
        /// 获取工种树信息
        /// </summary>
        public DataSet GetHisWorkTypeTree(DateTime beginTime, DateTime endTime)
        {
            string strWhere = "inTime>='" + beginTime.ToString("yyyy-MM-dd HH:mm:ss") + "' and inTime<='" + endTime.ToString("yyyy-MM-dd HH:mm:ss")+"'";
            return hisInWellDal.GetHisWorkTypeTree(strWhere);
        }
        /// <summary>
        /// 获取工种树信息
        /// </summary>
        public DataSet GetHisDutyInfoTree(DateTime beginTime, DateTime endTime)
        {
            string strWhere = "inTime>='" + beginTime.ToString("yyyy-MM-dd HH:mm:ss") + "' and inTime<='" + endTime.ToString("yyyy-MM-dd HH:mm:ss")+"'";
            return hisInWellDal.GetHisDutyInfoTree(strWhere);

        }
        #endregion

        #region 【方法：获取历史下井人员信息】
        /// <summary>
        /// 历史下井信息
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页总数</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public DataSet GetHisInWell(string TableName,string TableName2, int pageIndex, int pageSize, string where)
        {
            return hisInWellDal.GetHisInWell(TableName,TableName2, pageIndex, pageSize, where);
        }
        #endregion
        #endregion
    }
}
