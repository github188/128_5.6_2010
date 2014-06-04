using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class ConCodeSenderInfoDAL
    {

        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();

        private string strSql = string.Empty;

        #endregion


        #region [ 方法: 获取发码器状态基本信息 ]

        /// <summary>
        /// 获取 发码器状态 基本信息
        /// </summary>
        /// <returns></returns>
        public DataSet N_GetCsTypeName()
        {
            strSql = " Select EnumID,Title From EnumTable Where FunID=2 ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 发码器查询 ]
        /// <summary>
        /// 发码器查询
        /// </summary>
        /// <param name="strCodeSender">发码器编号</param>
        /// <param name="strCodeSenderStateID">发码器状态ID</param>
        /// <param name="dv">要绑定的DataGridView</param>
        /// <returns>true 成功，false 不成功</returns>
        public DataSet N_SearchCodeInfo(string strCodeSender, string strCodeSenderStateID)
        {
            bool blIsFirst = false;
            strSql = " Select " +
                        " CodeSenderAddress as " + HardwareName.Value(CorpsName.CodeSenderAddress) + ", " +
                        " Et.Title as 发码器状态, " +
                        " 是否使用=case when IsCodeSenderUser=1 then '使用' when IsCodeSenderUser=2 then '未使用' end, " +
                        " Ci.Remark as 备注 " +
                     " From " +
                        " CodeSender_Info as Ci left join EnumTable as Et on Ci.CodeSenderStateID=Et.EnumID and Et.FunID=2 ";
            if (!(strCodeSender.Equals("") | strCodeSender.Equals(null)))
            {
                strSql += " where CodeSenderAddress =" + strCodeSender;
                blIsFirst = true;
            }
            if (!strCodeSenderStateID.Equals("0"))
            {
                if (blIsFirst)
                {
                    strSql += " And CodeSenderStateID = " + strCodeSenderStateID;
                }
                else
                {
                    strSql += " Where CodeSenderStateID =" + strCodeSenderStateID;
                }
            }

            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 发码器配置查询 ]

        /// <summary>
        /// 发码器配置查询
        /// </summary>
        /// <param name="strCodeSender">发码器地址</param>
        /// <param name="strName">设备或员工的名称</param>
        /// <param name="intUserType">0表示人员，1表示设备，2表示人员和设备</param>
        /// <param name="dv">要绑定的DataGridView</param>
        /// <returns>true 成功，false 不成功</returns>
        public DataSet N_SearchCodeSetInfo(string strCodeSender, string strName, int intUserType)
        {
            strSql = " Select " +
                        " CodeSenderAddress as " + HardwareName.Value(CorpsName.CodeSenderAddress) + ", " +
                        " 配置类型=case when CsTypeID=0 then '人员' when CsTypeID=1 then '设备' end, " +
                        " 名称= case when CsTypeID=0 then Ei.EmpName when CsTypeID=1 then Ebi.EquName end, " +
                        " 所属部门=case when CsTypeID=0 then Di1.DeptName when CsTypeID=1 then Di2.DeptName end, " +
                        " Cs.Remark as 备注 " +
                     " From " +
                        " CodeSender_Set as Cs left join Emp_Info as Ei on Ei.EmpID= Cs.UserID and CsTypeID=0 " +
                        " left join Emp_NowCompany as Enc on Enc.EmpID=Ei.EmpID " +
                        " left join Dept_Info as Di1 on Di1.DeptID=Enc.DeptID " +
                        " left join Equ_BaseInfo as Ebi on Ebi.EquID=Cs.UserID and CsTypeID=1 " +
                        " left join Dept_Info as Di2 on Di2.DeptID=Ebi.DeptID " +
                     " Where " +
                        " CsSetID<>0 ";
            if (!(strCodeSender.Equals("") | strCodeSender.Equals(null)))
            {
                strSql += " And CodeSenderAddress =" + strCodeSender;
            }
            if (!(strName.Equals("") | strName.Equals(null)))
            {
                strSql += " And (Ei.EmpName like '%" + strName + "%' or Ebi.EquName like '%" + strName + "%' )";
            }
            if (!intUserType.Equals(2))
            {
                strSql += " And CsTypeID =" + intUserType.ToString();
            }
            return dbacc.GetDataSet(strSql);
        }

        #endregion

    }
}
