using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KJ128NModel;

namespace KJ128NDataBase
{
    public class EmpPostDAL
    {

        #region 【 声明 】

        private string strSql;
        private DBAcess dbacc = new DBAcess();

        #endregion

        #region 【 方法：获取区域名称 】

        public DataSet GetTerrInfo()
        {
            strSql = " Select TerritorialID, TerritorialName From Territorial_Info ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region 【 方法：获取部门名称 】

        public DataSet GetDeptInfo()
        {
            strSql = " Select DeptID, DeptName From Dept_Info ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region 【 方法：获取员工姓名 】

        public DataSet GetEmpName(string strCodeSenderAddress)
        {
            strSql = " Select EmpName "+
                     " From CodeSender_Set as Css left join Emp_Info as Ei on Css.UserID=Ei.EmpID and CsTypeID=0 "+
                     " Where CodeSenderAddress ="+strCodeSenderAddress;
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region 【 方法：增加员工岗位配置信息 】

        public int InsertEmpInfo(EmpPostModel empPostModel)
        {

            SqlParameter[] para = new SqlParameter[] {

                new SqlParameter("@CodeSenderAddress",SqlDbType.Int),
                new SqlParameter("@TerritorialID",SqlDbType.Int),
                new SqlParameter("@WorkTime",SqlDbType.Int),
                new SqlParameter("@Remark",SqlDbType.NVarChar,200)
            };

            para[0].Value = empPostModel.CodeSenderAddress;
            para[1].Value = empPostModel.TerritorialID;
            para[2].Value = empPostModel.WorkTime;
            para[3].Value = empPostModel.Remark;

            return dbacc.ExecuteSql("zjw_EmpPost_Insert", para);
        }

        #endregion

        #region 【 方法：增加员工岗位配置信息 】

        public int UpdataEmpInfo(EmpPostModel empPostModel)
        {

            SqlParameter[] para = new SqlParameter[] {

                new SqlParameter("@CodeSenderAddress",SqlDbType.Int),
                new SqlParameter("@TerritorialID",SqlDbType.Int),
                new SqlParameter("@WorkTime",SqlDbType.Int),
                new SqlParameter("@Remark",SqlDbType.NVarChar,200)
            };

            para[0].Value = empPostModel.CodeSenderAddress;
            para[1].Value = empPostModel.TerritorialID;
            para[2].Value = empPostModel.WorkTime;
            para[3].Value = empPostModel.Remark;

            return dbacc.ExecuteSql("zjw_EmpPost_UpData", para);
        }

        #endregion

        #region 【方法：查询员工岗位信息】

        public DataSet GetEmpPostInfo(int intDeptID, int intTerrID, string strCodeSenderAddress, string strEmpName)
        {
            string strWhere = " Where 1=1 ";

            if (intDeptID!=null && intDeptID != 0)
            {
                strWhere += " And Dei.DeptID=" + intDeptID;
            }

            if (intTerrID!=null && intTerrID != 0)
            {
                strWhere += " And Ep.TerritorialID =" + intTerrID;
            }

            if (strCodeSenderAddress != null && strCodeSenderAddress != "")
            {
                strWhere += " And Css.CodeSenderAddress=" + strCodeSenderAddress;
            }

            if (strEmpName != null && strEmpName != "")
            {
                strWhere += " And Ei.EmpName like %" + strEmpName + "%";
            }

            strSql = " Select Css.CodeSenderAddress as 标识卡编号, EmpName as 姓名,Dei.DeptName as 部门,Ti.TerritorialName as 岗位区域,dbo.FunConvertTime(WorkTime) as 工作时间, " +
                        " Ep.Remark as 备注,Ep.EmpID,Ti.TerritorialID, WorkTime" +
                     " From Emp_Post as Ep left join Emp_Info as Ei on Ep.EmpID=Ei.EmpID " +
                        " left join CodeSender_Set as Css on Ep.EmpID=Css.UserID and Css.CsTypeID=0 " +
                        " left join Emp_NowCompany as Enc on Ep.EmpID=Enc.EmpID " +
                        " left join Dept_Info as Dei on Enc.DeptID=Dei.DeptID " +
                        " left join Territorial_Info as Ti on Ep.TerritorialID=Ti.TerritorialID " + strWhere;

            return dbacc.GetDataSet(strSql);
        }

        #endregion


        #region 【方法：判断数据库中是否存在该员工编号】

        public DataSet IsEmpPost(string strCodeSenderAddress)
        {
            strSql = " Select EmpID " +
                        " From Emp_Post as Ep left join CodeSender_Set as Css on Ep.EmpID=Css.UserID and Css.CsTypeID=0 " +
                        " Where Css.CodeSenderAddress=" + strCodeSenderAddress;

            return dbacc.GetDataSet(strSql);
        }

        #endregion


        #region 【方法：删除员工岗位信息】

        public int DeleteEmpPost(int intEmpID)
        {
            SqlParameter[] para = new SqlParameter[] {

                new SqlParameter("@EmpID",SqlDbType.Int)
            };

            para[0].Value = intEmpID;


            return dbacc.ExecuteSql("zjw_EmpPost_Delete", para);
        }

        #endregion

    }
}
