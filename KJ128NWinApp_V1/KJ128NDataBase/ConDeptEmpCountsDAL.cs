using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class ConDeptEmpCountsDAL
    {
        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();

        private string strSql = string.Empty;

        #endregion

        #region [ 方法: 获取部门信息 ]

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns>返回 部门信息(DataSet)</returns>
        public DataSet N_GetDeptInfo()
        {
            string strSql;
            strSql = " select DeptID,DeptName,ParentDeptID, " +
                        " (select count(distinct EmpID ) from (select EmpID From dbo.Emp_NowCompany where DeptID=Di.DeptID or  DeptID in(select DeptID From Dept_Info Where ParentDeptID=Di.DeptID )  " +
                        " or DeptID in(Select DeptID From Dept_Info where DeptID in(Select DeptID From Dept_Info Where ParentDeptID=Di.DeptID))  " +
                        " or DeptID in(select DeptID From Dept_Info Where DeptID in(select DeptID From Dept_Info Where DeptID in(Select DeptID From Dept_Info where ParentDeptID =Di.DeptID))) " +
                        " )as T1 ) " +
                        " as Counts " +
                    " from Dept_Info as Di " +
                    " Order By DeptLevelID ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 获取总人数 ]

        public string N_GetDeptCounts()
        {
            string strSql;
            strSql = " Select count(DISTINCT EmpID) as Counts From Emp_NowCompany Where DeptID in(select DeptID From Dept_Info)";
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
            return "0";
        }

        #endregion

    }
}
