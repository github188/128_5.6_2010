using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class EmpInfoDAL
    {

        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();

        private string strSql = string.Empty;

        #endregion

        /*
         * 方法
         */

        #region [ 方法: 获取人员信息 ]

        public DataSet GetEmpInfo(string strID,bool blIsEmp)
        {
            strSql = " Select Css.CodeSenderAddress as 发码器编号, Ei.EmpName as 姓名, " +
                        " 身份证号= case when Ed.Idcard is null or Ed.Idcard='' then '无' else Ed.Idcard end, " +
                        " 出生年月= case when Ed.BirthDay is null then '无' else substring(convert(varchar(10), Ed.BirthDay,120),1,7) end ," +
                        " 职务= case when Dui.DutyName is null then '无' else Dui.DutyName end , " +
                        " 工种=case when Wti.WtName is null then '无' else Wti.WtName end, " +
                        " 所在区队班组= case when Enc.ClassGroup is null or Enc.ClassGroup='' then '无' else Enc.ClassGroup end, " +
                        " 工作地点= case when Enc.WorkPlace is null or Enc.WorkPlace='' then '无' else Enc.WorkPlace end " +
                    " From Emp_Info as Ei Left Join Emp_Detail as Ed on Ei.EmpID= Ed.EmpID " +
                        " Left Join Emp_NowCompany as Enc on Ei.EmpID=Enc.EmpID " +
                        " Left Join Emp_WorkType as Ewt on Ei.EmpID=Ewt.EmpID " +
                        " Left Join WorkType_Info as Wti on Ewt.WorkTypeID=Wti.WorkTypeID " +
                        " Left Join Duty_Info as Dui on Enc.DutyID=Dui.DutyID " +
                        " Left Join CodeSender_Set as Css on Ei.EmpID=Css.UserID and CsTypeID=0 ";

            if (blIsEmp)
            {
                strSql += " Where Ei.EmpID =" + strID;
            }
            else
            {
                strSql += " Where Css.CodeSenderAddress =" + strID;
            }
            return dbacc.GetDataSet(strSql);
        }

        #endregion

    }
}
