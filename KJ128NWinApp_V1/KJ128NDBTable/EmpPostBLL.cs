using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Tools.Excel.Controls;
using System.Collections;
using System.Data;
using KJ128NDataBase;
using KJ128NModel;

namespace KJ128NDBTable
{
    public class EmpPostBLL
    {

        #region 【 声明 】

        private EmpPostDAL epdal = new EmpPostDAL();

        #endregion


        #region 【 方法：区域名称 】

        public DataSet GetTerrInfo()
        {
            return epdal.GetTerrInfo();
        }

        #endregion

        #region 【 方法：获取部门名称 】

        public DataSet GetDeptInfo()
        {
            return epdal.GetDeptInfo();
        }

        #endregion


        #region 【 方法：获取员工姓名 】

        public DataSet GetEmpName(string strCodeSenderAddress)
        {
            return epdal.GetEmpName(strCodeSenderAddress);
        }

        #endregion

        #region 【 方法：增加员工岗位配置信息 】

        public int InsertEmpInfo(EmpPostModel empPostModel)
        {

            return epdal.InsertEmpInfo(empPostModel);
        }

        #endregion

        #region 【 方法：修改员工岗位配置信息 】

        public int UpDataEmpInfo(EmpPostModel empPostModel)
        {

            return epdal.UpdataEmpInfo(empPostModel);
        }

        #endregion

        #region 【方法：查询员工岗位信息】

        public DataSet GetEmpPostInfo(int intDeptID,int intTerrID,string strCodeSenderAddress,string strEmpName)
        {
            return epdal.GetEmpPostInfo(intDeptID, intTerrID, strCodeSenderAddress, strEmpName);
        }

        #endregion


        #region 【方法: 验证员工岗位配置表中该员工是否存在】

        public DataSet IsEmpPost(string strCodeSenderAddress)
        {
            return epdal.IsEmpPost(strCodeSenderAddress);
        }

        #endregion

        #region 【方法：删除员工岗位信息】

        public int DeleteEmpPost(int intEmpID)
        {
            return epdal.DeleteEmpPost(intEmpID);
        }

        #endregion
    }
}
