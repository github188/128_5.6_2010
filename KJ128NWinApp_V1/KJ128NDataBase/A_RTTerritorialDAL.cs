using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class A_RTTerritorialDAL
    {

        #region【声明】

        private DBAcess dba = new DBAcess();

        private string strSQL;

        #endregion

        #region【方法：获取区域信息（树）——人员】

        public DataSet GetTerritorialTree_Emp()
        {
            strSQL = " Select * From A_RT_TerritorialTree_Emp ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取区域信息（树）——设备】

        public DataSet GetTerritorialTree_Equ()
        {
            strSQL = " Select * From A_RT_TerritorialTree_Equ ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取部门信息（ComboBox）】

        public DataSet GetDeptComboBox()
        {
            strSQL = " select DeptID,DeptName from Dept_Info ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法: 查询区域信息——人员】

        public DataSet Select_Territorial_Emp(string strWhere)
        {
            strSQL = " Select * From A_RT_Territorial_Emp Where " + strWhere;
            //strSQL += " Select DISTINCT(标识卡号) From A_RT_Territorial_Emp Where " + strWhere;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法: 查询区域信息——人员】

        public DataSet Select_Territorial_Equ(string strWhere)
        {
            strSQL = " Select * From A_RT_Territorial_Equ Where " + strWhere;
            //strSQL += " Select DISTINCT(标识卡号) From A_RT_Territorial_Equ Where " + strWhere;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取部门（树）—限制区域——人员】

        public DataSet GetDeptTree_ConfineArea_Emp()
        {
            strSQL = " Select * From A_DeptTree_RTConfineArea_Emp ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取部门（树）—限制区域——设备】

        public DataSet GetDeptTree_ConfineArea_Equ()
        {
            strSQL = " Select * From A_DeptTree_RTConfineArea_Equ ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取部门（树）—重点区域——人员】

        public DataSet GetDeptTree_KeyArea_Emp()
        {
            strSQL = " Select * From A_DeptTree_RTKeyArea_Emp ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取部门（树）—重点区域——设备】

        public DataSet GetDeptTree_KeyArea_Equ()
        {
            strSQL = " Select * From A_DeptTree_RTKeyArea_Equ ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取部门（树）—地域——人员】

        public DataSet GetDeptTree_DistrictArea_Emp()
        {
            strSQL = " Select * From A_DeptTree_RTDistrictArea_Emp ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取部门（树）—地域——设备】

        public DataSet GetDeptTree_DistrictArea_Equ()
        {
            strSQL = " Select * From A_DeptTree_RTDistrictArea_Equ ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法:Czlt-2010-12-06 获取工种信息】
        public DataSet GetWorkTypeCmb()
        {
            string strSqlWorkType = " select workTypeID,WtName from dbo.WorkType_Info ";
            return dba.GetDataSet(strSqlWorkType);
        }
        #endregion
    }
}
