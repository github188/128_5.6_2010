using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;

using KJ128NDataBase;
using KJ128NInterfaceShow;

namespace KJ128NDBTable
{
    public class Li_HisInOutMine_BLL : Li_HisInMineRecordSet_BLL
    {
        private string strSql = string.Empty;
        private Li_HisInOutMineDAL li = new Li_HisInOutMineDAL();

        #region 组织查询条件
        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <param name="strStartTime">开始时间</param>
        /// <param name="strEndTime">结束时间</param>
        /// <param name="strName">姓名</param>
        /// <param name="strCard">卡号</param>
        /// <param name="strIdCard">身份证号</param>
        /// <param name="strWorkTypeId">工种ID号</param>
        /// <param name="strCerTypeId">证书ID号</param>
        /// <param name="strDutyId">职务ID号</param>
        /// <param name="strDutyClassId">职务等级ID号</param>
        /// <returns>返回查询条件</returns>
        public string SelectWhere(
            string strStartTime,
            string strEndTime,
            string strName,
            string strCard,
            string strDeptName,
            string strWorkTypeId,
            string strDutyId)
        {
            strSql = " And InTime >= '" + strStartTime + "' And InTime <= '" + strEndTime + "' "; ;

            if (!(strName.Equals("") | strName.Equals(null)))
            {
                strSql += " And Ei.EmpName like '%" + strName + "%' ";
            }

            if (!(strCard.Equals("") | strCard.Equals(null)))
            {
                strSql += " And Hi.CodeSenderAddress = " + strCard;
            }
            if (!(strDeptName.Equals("")))
            {
                strSql += " And ( Di.DeptName = " + strDeptName + ") ";
            }

            if (!strWorkTypeId.Equals("0"))
            {
                strSql += " And Wi.WorkTypeID = " + strWorkTypeId;
            }

            if (!strDutyId.Equals("0"))
            {
                strSql += " And Dio.DutyID = " + strDutyId;
            }

            return strSql;
        }
        #endregion

        #region [ 方法: 查询历史下井记录 ]
        public DataSet GetHisInOutMineSet( string where)
        {
            DataSet ds =li.GetHisInOutMineSet(where);
            if (ds!=null &&ds.Tables.Count>0)
            {
                ds.Tables[0].Columns[0].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);

            }
            return ds;
        }
        #endregion

        #region [ 方法: 获得设备查询表 ]
        /// <summary>
        /// 获得查询表
        /// </summary>
        /// <param name="strEquID">设备名称</param>
        /// <param name="strDeptID">部门编号</param>
        /// <param name="strFactoryID">生产厂家</param>
        /// <param name="strInStationHeadTime">下井时间</param>
        /// <param name="strOutStationHeadTime">上井时间</param>
        /// <returns>表</returns>
        public DataSet GetConditionEqu(string strEquID, string strDeptID, string strFactoryID,string strEquType, string strInTime, string strOutTime)
        {
            return li.GetConditionEqu(strEquID, strDeptID, strFactoryID,
                strEquType, strInTime, strOutTime);
        }
        #endregion 

    }
}
