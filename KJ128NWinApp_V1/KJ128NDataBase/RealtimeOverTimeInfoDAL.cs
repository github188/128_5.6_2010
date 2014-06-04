using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class RealtimeOverTimeInfoDAL
    {

        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();

        private string strSql = string.Empty;

        #endregion

        /*
         * 方法
         */ 

        #region [ 方法: 获取部门信息 ]

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns>部门信息(DataSet)</returns>
        public DataSet N_GetDeptInfo()
        {
            strSql = " Select DeptID, ParentDeptID, DeptLevelID, DeptNO, DeptName, Remark From Dept_Info Order By DeptLevelID ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 获取工种信息 ]

        /// <summary>
        /// 获取工种信息
        /// </summary>
        /// <returns>工种信息(DataSet)</returns>
        public DataSet N_GetWorkTypeInfo()
        {
            strSql = " Select WorkTypeID, WtName, CerTypeID ,Remark From WorkType_Info ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 获取职务信息 ]

        /// <summary>
        /// 获取职务信息
        /// </summary>
        /// <returns>职务信息(DataSet)</returns>
        public DataSet N_GetBusinessInfo()
        {
            strSql = " Select DutyID, DutyName, DutyClassID, Remark From Duty_Info ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 获取超时信息 ]

        /// <summary>
        /// 获取超时信息
        /// </summary>
        /// <param name="strName">姓名</param>
        /// <param name="strCard">发码器编号</param>
        /// <param name="strDeptID">部门ID</param>
        /// <param name="strWorkTypeId">工种ID</param>
        /// <param name="strDutyId">职务ID</param>
        /// <returns></returns>
        public DataSet N_GetOverTimeInfo(string strName,string strCard,string strDeptID,string strWorkTypeId,string strDutyId)
        {
            strSql = " Select " +
                                   " CodeSenderAddress as " + HardwareName.Value(CorpsName.CodeSenderAddress) + ", " +
                                   " EmpName as 员工姓名 , " +
                                   " DeptName as 部门 , " +
                                   " DutyName as 职务 , " +
                                   " WtName as 工种 , " +
                                   " StartOverTime as 开始超时时间 , " +
                                   " dbo.FunConvertTime(DATEDIFF(second, StartOverTime, getdate())) as 持续时长 " +
                               " From" +
                //" RT_OverTimeInfo as Ro left join Emp_Info as Ei on Ro.UserID=Ei.EmpID " +
                                   " RT_OverTimeInfo_View as Ro left join Emp_Info as Ei on Ro.UserID=Ei.EmpID " +
                                   " left join Emp_NowCompany as En on Ei.EmpID=En.EmpID " +
                                   " left join Dept_Info as Dei on En.DeptID=Dei.DeptID " +
                                   " left join Duty_Info as Dio on En.DutyID=Dio.DutyID " +
                                   " left join Emp_WorkType as Ew on Ew.EmpID=Ei.EmpID and IsEnable=1 " +
                                   " left join WorkType_Info as Wi on Wi.WorkTypeID=Ew.WorkTypeID " +
                               " Where " +
                                   " CsTypeID=0 ";
            // " Hi.StationHeadDetectTime >= '" + strStartTime + "' And Hi.StationHeadDetectTime <= '" + strEndTime + "' ";
            if (strName != "" && strName != null)
            {
                strSql += " And Ei.EmpName like  '%" + strName + "%' ";
            }

            if (strCard != "" && strCard != null)
            {
                strSql += " And Ro.CodeSenderAddress = " + strCard;
            }

            if (strDeptID != "" && strDeptID != null)
            {
                strSql += " And ( Dei.DeptID = " + strDeptID + ") ";
            }

            if (strWorkTypeId != "0" && strWorkTypeId != null)
            {
                strSql += " And Wi.WorkTypeID = " + strWorkTypeId;
            }

            if (strDutyId != "0" && strDutyId != null)
            {
                strSql += " And Dio.DutyID = " + strDutyId;
            }
            return dbacc.GetDataSet(strSql);
        }

        #endregion
    }
}
