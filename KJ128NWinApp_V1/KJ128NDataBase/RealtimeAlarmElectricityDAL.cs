using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class RealtimeAlarmElectricityDAL
    {

        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();

        private string strSql = string.Empty;

        #endregion

        /*
         * 方法
         */ 

        #region [ 方法: 获取低电量信息 ]

        /// <summary>
        /// 获取低电量信息
        /// </summary>
        /// <param name="CodeSenderStateID">发码器状态,4:低电量</param>
        /// <param name="CsTypeID">发码器配置类型;0:人员;1:设备;2:发码器</param>
        /// <returns></returns>
        public DataSet N_GetAlarmElectricity(int CodeSenderStateID,int intCsTypeID)
        {
            //string procName = "KJ128N_CodeAlarmElectricity_Select";
            //SqlParameter[] sqlParmeters ={
            //    new SqlParameter("CodeSenderStateID",SqlDbType.Int)
            //};
            //sqlParmeters[0].Value = CodeSenderStateID;

            //return dbacc.GetDataSet(procName, sqlParmeters);

            strSql = " Select  Csi.CodeSenderAddress as 发码器, " +
                    " Et.Title as 发码器状态, " +
                    " 配置类型= case when CsTypeID= 0 then '人员' when CsTypeID=1 then '设备' else '' end, " +
                    " 名称=case when CsTypeID=0 then EmpName when CsTypeID=1 then EquName else '' end, " +
                    " 部门=case when CsTypeID=0 then Di1.DeptName else '' end " +
                   " From CodeSender_Info as Csi left join CodeSender_Set as Css on Csi.CodeSenderAddress =Css.CodeSenderAddress " +
                        " Left Join Emp_Info as Ei on Ei.EmpID=Css.UserID and CsTypeID=0 " +
                        " Left Join Emp_NowCompany as Enc on Enc.EmpID=Ei.EmpID " +
                        " Left Join Dept_Info as Di1 on Di1.DeptID=Enc.DeptID " +
                        " Left Join Equ_BaseInfo as Ebi on Ebi.EquID=Css.UserID and Css.CsTypeID=1 " +
                        " Left Join Dept_Info as Di2 on Di2.DeptID=Ebi.DeptID " +
                        " Left Join EnumTable as Et on Et.EnumID=Csi.CodeSenderStateID and Et.FunID=2 " +
                    " Where Csi.CodeSenderStateID = " + CodeSenderStateID;
            if (intCsTypeID.Equals(0) || intCsTypeID.Equals(1))
            {
                strSql += " And CsTypeID =" + intCsTypeID;
            }
            else if (intCsTypeID.Equals(2))
            {
                strSql += " And CsTypeID is Null ";
            }
            return dbacc.GetDataSet(strSql);
        }

        #endregion
    }
}
