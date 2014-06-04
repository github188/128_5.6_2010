using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class ConDeptManageDAL
    {

        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();

        private string strSql = string.Empty;

        #endregion

        /*
         * 方法
         */ 

        #region [ 方法: 获取部门基本信息 ]
        
        /// <summary>
        /// 获取部门基本信息
        /// </summary>
        /// <returns></returns>
        public DataSet N_GetDeptInfo()
        {
            strSql = " Select DeptID, ParentDeptID, DeptLevelID, DeptNO, DeptName, Remark From Dept_Info  Order By DeptLevelID ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 获取工种信息 ]

        /// <summary>
        /// 获取工种信息
        /// </summary>
        /// <returns></returns>
        public DataSet N_GetWorkTypeInfo()
        {
            strSql = " Select " +
                        " WtName as 工种名称, " +
                        " CerName as 证书名称, " +
                        " dbo.FunConvertTime(MaxTimeSec) as 最大工作时间, " +
                        " dbo.FunConvertTime(MinTimeSec) as 最小工作时间, " +
                        " Wi.Remark as 备注 " +
                     " From " +
                        " WorkType_Info as Wi left join WorkType_SysSet as Wss on Wi.WorkTypeID=Wss.WorkTypeID " +
                        " left join Certificate_Info as Ci on Ci.CerTypeID=Wi.CerTypeID ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 获取证书信息 ]

        /// <summary>
        /// 获取证书信息
        /// </summary>
        /// <returns></returns>
        public DataSet N_GetCertificateInfo()
        {
            strSql = " Select" +
                        " CerName as 证书名称, " +
                        " CerVestIn as 发证机关, " +
                        " 是否检查有效期 = case when IsCheckExpDate=0 then '不检查' when IsCheckExpDate=1 then '检查' end, " +
                        " Remark as 备注 " +
                     " From " +
                        " Certificate_Info ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 获取职务信息 ]

        /// <summary>
        /// 获取职务信息
        /// </summary>
        /// <returns></returns>
        public DataSet N_GetDutyInfo()
        {
            strSql = " Select " +
                        " DutyName as 职务名称, " +
                        " Title as 职务等级, " +
                        " Di.Remark as 备注 " +
                     " From " +
                        " Duty_Info as Di left join EnumTable as Et on Di.DutyClassID=Et.EnumID and FunID=4 ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 根据部门ID,获取部门详细信息 ]

        /// <summary>
        /// 根据部门ID,获取部门详细信息
        /// </summary>
        /// <param name="strDeptID">部门ID</param>
        /// <returns></returns>
        public DataSet N_GetSearchDeptInfo(string strDeptID)
        {
            strSql = " Select " +
                       " Di1.DeptNO as 部门编号, " +
                       " Di1.DeptName as 部门名称, " +
                       " EmpName as 部门领导, " +
                       " ClassName as 班制名称, " +
                       " 上级部门名称 = case  when Di2.DeptName is null then '无' else Di2.DeptName end, " +
                       " dbo.FunConvertTime(MaxTimeSec) as 最大工作时间, " +
                       " dbo.FunConvertTime(MinTimeSec) as 最小工作时间 " +
                    " From " +
                       " Dept_Info as Di1 left join Dept_Lead as Dl on Di1.DeptID=Dl.DeptID " +
                       " left join Emp_Info as Ei on Ei.EmpID=Dl.EmpID " +
                       " left join InfoClass as Ic on Ic.ID=Di1.ClassID " +
                       " left join Dept_Info as Di2 on Di2.DeptID=Di1.ParentDeptID " +
                       " left join Dept_SysSet as Dss on Dss.DeptID=Di1.DeptID ";
            if (!(strDeptID.Equals("") | strDeptID.Equals(null)))
            {
                strSql += " Where Di1.DeptID = " + strDeptID;
            }
            return dbacc.GetDataSet(strSql);
        }

        #endregion
    }
}
