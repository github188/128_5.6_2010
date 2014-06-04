using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class ConEmployeeInfoDAL
    {

        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();

        private string strSql = string.Empty;

        #endregion

        /*
         * 方法
         */ 

        #region [ 方法: 获取部门信息 ]

        public DataSet N_GetDeptInfo()
        {
            strSql = " Select DeptID, ParentDeptID, DeptLevelID, DeptNO, DeptName, Remark From Dept_Info Order By DeptLevelID ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 获取工种信息 ]

        public DataSet N_GetWorkTypeInfo()
        {
            strSql = " Select WorkTypeID, WtName, CerTypeID ,Remark From WorkType_Info ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 获取职务信息 ]

        public DataSet N_GetBusinessInfo()
        {
            strSql = " Select DutyID, DutyName, DutyClassID, Remark From Duty_Info ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 查询人员配置信息 ]

        /// <summary>
        /// 查询人员配置信息
        /// </summary>
        /// <param name="strName">员工姓名</param>
        /// <param name="strNo">员工编号</param>
        /// <param name="strIdCard">身份证编号</param>
        /// <param name="strDeptID">部门ID</param>
        /// <param name="strWorkTypeId">工种ID</param>
        /// <param name="strDutyId">职务ID</param>
        /// <returns></returns>
        public DataSet N_GetConEmployeeInfo(string strName, string strNo, string strIdCard, string strDeptID, string strWorkTypeId,string strDutyId)
        {
            strSql = " Select " +
                        " Ei.EmpNO as 员工编号, " +
                        " EmpName as 姓名, " +
                        " 性别= case Sex when 0 then '男' when 1 then '女' end, " +
                        " DeptName as 部门, " +
                        " WtName as 工种, " +
                        " DutyName as 职务, " +
                        " Idcard as 身份证编号, " +
                        " dbo.FunConvertTime(MaxSecTime) as 最大工作时间, " +
                        " dbo.FunConvertTime(MinSecTime) as 最小工作时间 " +
                    " From " +
                        " Emp_Info as Ei left join Emp_NowCompany as Enc on Ei.EmpID=Enc.EmpID " +
                        " left join Dept_Info as Dei on Enc.DeptID=Dei.DeptID " +
                        " left join Emp_WorkType as Ewt on Ei.EmpID=Ewt.EmpID and IsEnable=1 " +
                        " left join WorkType_Info as Wti on Wti.WorkTypeID=Ewt.WorkTypeID " +
                        " left join Duty_Info as Dui on Dui.DutyID=Enc.DutyID " +
                        " left join Emp_Detail as Ed on Ed.EmpID=Ei.EmpID " +
                    " Where " +
                        " Ei.EmpID<>-1 ";
            if (!(strName.Equals("") | strName.Equals(null)))
            {
                strSql += " And Ei.EmpName like '%" + strName + "%' ";
            }

            if (!(strNo.Equals("") | strNo.Equals(null)))
            {

                strSql += " And Ei.EmpNO like '%" + strNo + "%'";

            }

            if (!(strIdCard.Equals("") | strIdCard.Equals(null)))
            {
                strSql += " And Idcard like '%" + strIdCard + "%' ";
            }

            if (!(strDeptID.Equals("") | strDeptID.Equals(null)))
            {
                strSql += " And ( Dei.DeptID = " + strDeptID + " ) ";
            }

            if (!strWorkTypeId.Equals("0"))
            {
                strSql += " And Ewt.WorkTypeID = " + strWorkTypeId;
            }
            if (!strDutyId.Equals("0"))
            {
                strSql += " And Enc.DutyID = " + strDutyId;
            }

            return dbacc.GetDataSet(strSql);
        }

        #endregion
    }
}
