using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class Li_HistoryTotalDAL
    {
        private DBAcess dbacc= new DBAcess();
        private string strSql = string.Empty;
        private string strStartDateTime = string.Empty, strEndDateTime=string.Empty;

        #region 根据部门ID，获取该部门的下井人数
        public string GetDeptCounts(string strDeptID, string strStartTime, string strEndTime)
        {
            string strSql;
            if (strDeptID == "0")
            {
                strSql = " Select count(distinct Hi.UserID) as Counts " +
                          " From His_InOutMine as Hi left join Emp_NowCompany as Enc on Enc.EmpID=Hi.UserID and CsTypeID=0  " +
                         " Where InTime>='" + strStartTime + "' And InTime<='" + strEndTime + "'" + " And CsTypeID=0 ";
            }
            else
            {
                strSql = " Select count(distinct Hi.UserID) as Counts " +
                          " From His_InOutMine as Hi left join Emp_NowCompany as Enc on Enc.EmpID=Hi.UserID and CsTypeID=0  " +
                         " Where ( DeptID=" + strDeptID + " or DeptID in(select DeptID From Dept_Info Where ParentDeptID=" + strDeptID + " ) " +
                             " or DeptID in(Select DeptID From Dept_Info where DeptID in(Select DeptID From Dept_Info Where ParentDeptID=" + strDeptID + ")) " +
                             " or DeptID in(select DeptID From Dept_Info Where DeptID in(select DeptID From Dept_Info Where DeptID in(Select DeptID From Dept_Info where ParentDeptID =" + strDeptID + ")))) " +
                             " And InTime>='" + strStartTime + "' And InTime<='" + strEndTime + "'" + " And CsTypeID=0 ";
            }
            DataSet tempDs;
            using (tempDs = new DataSet())
            {
                tempDs = dbacc.GetDataSet(strSql);
                if (tempDs != null && tempDs.Tables.Count > 0)
                {
                    if (tempDs.Tables[0].Rows.Count > 0)
                    {
                        return tempDs.Tables[0].Rows[0]["Counts"].ToString();
                    }
                }
            }
            return null;
        }
        #endregion

        #region 获取(部门, 工种, 职务, 职务等级)信息
        /// <summary>
        /// 获取部门基本信息
        /// </summary>
        /// <returns>返回 DataSet 数据集</returns>
        public DataSet GetDeptInfo(int intUserType, string strStartTime, string strEndTime)
        {
            if (intUserType.Equals(0))
            {
                strSql = " Select " +
                     " Di.DeptID, Di.ParentDeptID, Di.DeptName, " +
                     " ( " +
                     " Select Count(*) From (Select Distinct Hi.UserID From His_InOutMine As Hi " +
                     " Left Join Emp_NowCompany As En On En.DeptID = Di.DeptID " +
                     " Left Join Emp_Info As Ei On Ei.EmpID = En.EmpID " +
                     " Where Hi.UserID = Ei.EmpID And Hi.CsTypeID = " + intUserType.ToString() + " And InTime >= '" + strStartTime + "' And InTime <= '" + strEndTime + "') As T1 " +
                     " ) As Counts " +
                     " From Dept_Info As Di " +
                     " Order By DeptLevelID ";
            }
            else
            {
                strSql = " Select " +
                         " Di.DeptID, Di.ParentDeptID, Di.DeptName, " +
                         " ( " +
                         " Select Count(*) From (Select Distinct Hi.UserID From His_InOutMine As Hi " +
                         " Left Join Equ_BaseInfo As Eb On Eb.DeptID = Di.DeptID " +
                         " Where Hi.UserID = Eb.EquID And Hi.CsTypeID = " + intUserType.ToString() + " And InTime >= '" + strStartTime + "' And InTime <= '" + strEndTime + "') As T1 " +
                         " ) As Counts " +
                         " From Dept_Info As Di" +
                         " Order By DeptLevelID ";
            }

            return dbacc.GetDataSet(strSql);
        }

        public DataSet GetWorkTypeInfo(string strStartTime, string strEndTime)
        {
            strSql = " Select " +
                     " WtName, " +
                     " ( " +
                     " Select Count(*) From (Select Distinct Hi.UserID From His_InOutMine As Hi " +
                     " Left Join Emp_WorkType As Ew On Ew.WorkTypeID = Wi.WorkTypeID " +
                     " Left Join Emp_Info As Ei On Ei.EmpID = Ew.EmpID " +
                     " Where Hi.UserID = Ei.EmpID And Hi.CsTypeID = 0 And InTime >= '" + strStartTime + "' And InTime <= '" + strEndTime + "') As T1 " +
                     " ) As Counts " +
                     " From WorkType_Info As Wi ";
            return dbacc.GetDataSet(strSql);
        }

        public DataSet GetBusinessInfo(string strStartTime, string strEndTime)
        {
            strSql = " Select " +
                     " DutyName, " +
                     " ( " +
                     " Select Count(*) From (Select Distinct Hi.UserID From His_InOutMine As Hi " +
                     " Left Join Emp_NowCompany As En On En.DutyID = Di.DutyID " +
                     " Left Join Emp_Info As Ei On Ei.EmpID = En.EmpID " +
                     " Where Hi.UserID = Ei.EmpID And Hi.CsTypeID = 0 And InTime >= '" + strStartTime + "' And InTime <= '" + strEndTime + "') As T1 " +
                     " ) As Counts " +
                     " From Duty_Info As Di ";
            return dbacc.GetDataSet(strSql);
        }

        public DataSet GetBusLevelInfo(string strStartTime, string strEndTime)
        {
            strSql = " Select " +
                     " Title, " +
                     " ( " +
                     " Select Count(*) From (Select Distinct Hi.UserID From His_InOutMine As Hi " +
                     " left Join Emp_Info as Ei on Ei.EmpID=Hi.UserID " +
                     " left Join Emp_NowCompany as En on Ei.EmpID=En.EmpID " +
                     " left join Duty_Info as Di on Di.DutyID=En.DutyID " +
                     " left join EnumTable as Et1 on Et1.EnumID=Di.DutyClassID and Et1.FunID=4 " +
                     " Where Hi.CsTypeID = 0 and Et1.EnumID=Et.EnumID " +
                     " And InTime >= '" + strStartTime + "' And InTime <= '" + strEndTime + "') As T1 " +
                     " ) As Counts " +
                     " From EnumTable As Et " +
                     " Where Et.FunID = 4";
            return dbacc.GetDataSet(strSql);
        }

        public DataSet GetTerritorialInfo(string strStartTime, string strEndTime)
        {
            strSql = "select distinct TerritorialTypeName,"
            + " (Select Count(DISTINCT CodeSenderAddress) From dbo.His_InOutTerritorial as Hi1 "
                + " where Hi2.TerritorialTypeName=Hi1.TerritorialTypeName and Hi1.CsTypeID=0 and Hi1.InTerritorialTime>='" + strStartTime + "' and Hi1.OutTerritorialTime<='" + strEndTime + "'"
            + " ) as Counts  from His_InOutTerritorial as Hi2 where Hi2.InTerritorialTime>='" + strStartTime + "' and Hi2.OutTerritorialTime<='" + strEndTime + "'"


            + " select distinct Hi2.TerritorialName,Hi2.TerritorialTypeName,"
            + " (Select Count(DISTINCT CodeSenderAddress) From dbo.His_InOutTerritorial as Hi1 "
                + " where Hi1.TerritorialName=Hi2.TerritorialName and Hi1.CsTypeID=0 and Hi1.InTerritorialTime>='" + strStartTime + "' and Hi1.OutTerritorialTime<='" + strEndTime + "'"
            + " ) as Counts  from His_InOutTerritorial as Hi2 where Hi2.InTerritorialTime>='" + strStartTime + "' and Hi2.OutTerritorialTime<='" + strEndTime + "'";

            return dbacc.GetDataSet(strSql);
        }
        #endregion
    }
}
