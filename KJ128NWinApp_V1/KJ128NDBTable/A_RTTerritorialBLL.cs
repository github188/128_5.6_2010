using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class A_RTTerritorialBLL
    {

        #region【声明】

        private A_RTTerritorialDAL rttdal = new A_RTTerritorialDAL();

        #endregion

        #region【方法：获取区域信息（树）——人员】

        public DataSet GetTerritorialTree_Emp()
        {
            return rttdal.GetTerritorialTree_Emp();
        }

        #endregion

        #region【方法：获取区域信息（树）——设备】

        public DataSet GetTerritorialTree_Equ()
        {
            return rttdal.GetTerritorialTree_Equ();
        }

        #endregion

        #region【方法：获取部门信息（ComboBox）】

        public DataSet GetDeptComboBox()
        {
            return rttdal.GetDeptComboBox();
        }
        #endregion

        #region 【方法: 查询区域信息——人员】

        public DataSet Select_Territorial_Emp(string strWhere)
        {
            return rttdal.Select_Territorial_Emp(strWhere);
        }

        #endregion

        #region 【方法: 查询区域信息——设备】

        public DataSet Select_Territorial_Equ(string strWhere)
        {
            return rttdal.Select_Territorial_Equ(strWhere);
        }

        #endregion


        #region【方法：获取部门（树）—限制区域——人员】

        public DataSet GetDeptTree_ConfineArea_Emp()
        {
            return rttdal.GetDeptTree_ConfineArea_Emp();
        }

        #endregion

        #region【方法：获取部门（树）—限制区域——设备】

        public DataSet GetDeptTree_ConfineArea_Equ()
        {
            return rttdal.GetDeptTree_ConfineArea_Equ();
        }

        #endregion

        #region【方法：获取部门（树）—重点区域——人员】

        public DataSet GetDeptTree_KeyArea_Emp()
        {
            return rttdal.GetDeptTree_KeyArea_Emp();
        }

        #endregion

        #region【方法：获取部门（树）—重点区域——设备】

        public DataSet GetDeptTree_KeyArea_Equ()
        {
            return rttdal.GetDeptTree_KeyArea_Equ();
        }

        #endregion

        #region【方法：获取部门（树）—地域——人员】

        public DataSet GetDeptTree_DistrictArea_Emp()
        {
            return rttdal.GetDeptTree_DistrictArea_Emp();
        }

        #endregion

        #region【方法：获取部门（树）—地域——设备】

        public DataSet GetDeptTree_DistrictArea_Equ()
        {
            return rttdal.GetDeptTree_DistrictArea_Equ();
        }

        #endregion

        #region【方法:Czlt-2010-12-06 获取工种信息(树)】
        public DataSet GetWorkType()
        {
            return rttdal.GetWorkTypeCmb();
        }
        #endregion

    }
}
