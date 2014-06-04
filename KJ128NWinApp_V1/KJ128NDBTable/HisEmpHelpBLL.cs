using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class HisEmpHelpBLL
    {

        #region [ 声明 ]

        private HisEmpHelpDAL hehdal = new HisEmpHelpDAL();

        private string strSql = string.Empty;

        #endregion

        /*
         * 方法
         */ 

        #region [ 方法: 组织查询条件 ]

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <param name="strStartTime">开始时间</param>
        /// <param name="strEndTime">结束时间</param>
        /// <param name="strName">姓名</param>
        /// <param name="strCodeSenderAddress">发码器编号</param>
        /// <param name="strDeptName">部门名称</param>
        /// <param name="strDutyId">职务ID</param>
        /// <param name="strStationAddress">分站编号</param>
        /// <param name="strStationHeadAddress">接收器编号</param>
        /// <returns>返回查询条件</returns>
        public string SelectWhere(string strStartTime, string strEndTime, string strName, string strCodeSenderAddress, string strWtName, string strDeptName, string strDutyId, string strStationAddress, string strStationHeadAddress, string strMeasure)
        {
            strSql = "  求救开始时间 >= '" + strStartTime + "' And 求救开始时间 <= '" + strEndTime + "' ";

            if (!(strName.Equals("") | strName.Equals(null)))
            {
                strSql += " And 姓名 like '%" + strName + "%' ";
            }

            if (!(strMeasure.Equals("") | strMeasure.Equals(null)))
            {
                strSql += " And 救援措施 like '%" + strMeasure + "%' ";
            }

            if (!(strCodeSenderAddress.Equals("") | strCodeSenderAddress.Equals(null)))
            {
                strSql += " And 发码器编号 = " + strCodeSenderAddress;
            }


            if (!(strDeptName.Equals("所有部门")))
            {
                strSql += " And ( 部门 = " + strDeptName + ") ";
            }

            if (!strDutyId.Equals("所有"))
            {
                strSql += " And 职务 = '" + strDutyId + "' ";
            }

            if (!strWtName.Equals("所有"))
            {
                strSql += " And 工种 = '" + strWtName + "' ";
            }

            if (!(strStationAddress.Equals("0")))
            {
                strSql += " And 分站编号 = " + strStationAddress;
            }

            if (!(strStationHeadAddress.Equals("0")))
            {
                strSql += " And 接收器编号 = " + strStationHeadAddress;
            }

            return strSql;

        }

        #endregion

        #region [ 方法: 查询历史求救信息 ]

        public DataSet GetEmpHelpInfo(int pageIndex, int pageSize, string where)
        {
            return hehdal.GetEmpHelpInfo(pageIndex, pageSize, where);
        }

        #endregion
    }
}
