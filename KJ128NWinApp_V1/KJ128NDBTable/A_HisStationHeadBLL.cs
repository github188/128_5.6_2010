using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class A_HisStationHeadBLL
    {
        #region【声明】

        private A_HisStationHeadDAL hisdal = new A_HisStationHeadDAL();

        #endregion

        #region【方法：获取部门（树）】

        public DataSet GetDeptTree()
        {
            return hisdal.GetDeptTree();
        }

        #endregion

        #region【方法：获取分站（树）】

        public DataSet GetStaHeadTree()
        {
            return hisdal.GetStaHeadTree();
        }

        #endregion

        #region【方法：查询历史读卡分站信息——人员】

        public DataSet GetInfo_HisStationHead_Emp(string where, string tablename, string tablename2)
        {
            return hisdal.GetInfo_HisStationHead_Emp( where, tablename, tablename2);
        }

        #endregion

        #region【方法：查询历史读卡分站信息——设备】

        public DataSet GetInfo_HisStationHead_Equ(int pageIndex, int pageSize, string where)
        {
            return hisdal.GetInfo_HisStationHead_Equ(pageIndex, pageSize, where);
        }

        #endregion

        #region 【方法:Czlt-2010-12-06-获取职务(树)】
        public DataSet GetDuty()
        {
            return hisdal.GetDutyTree();
        }
        #endregion

        #region【Czlt-2011-07-11 历史标识卡跨月查询】
        /// <summary>
        /// Czlt-2011-12-20 
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pageSize"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet Czlt_GetEmpInfo_HisStationHead(int pageindex, int pageSize, string startTime, string endTime, string where)
        {
            return hisdal.Czlt_GetEmpInfo_HisStationHead(pageindex, pageSize, startTime, endTime, where);
        }
        #endregion
    }
}
