using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class A_HisTerritorialBLL
    {
        
        #region【声明】

        private A_HisTerritorialDAL his = new A_HisTerritorialDAL();

        #endregion

        #region【方法：获取区域信息（树）——历史区域】

        public DataSet GetTerritorialTree()
        {
            return his.GetTerritorialTree();
        }

        #endregion

        #region【方法：查询历史区域——人员】

        public DataSet GetInfo_HisTerritorial_Emp(int pageIndex, int pageSize, string where,string TableName,string TableName2)
        {
            return his.GetInfo_HisTerritorial_Emp(pageIndex, pageSize, where, TableName, TableName2);
        }

        #endregion

        #region【方法：查询历史区域——设备】

        public DataSet GetInfo_HisTerritorial_Equ(int pageIndex, int pageSize, string where)
        {
            return his.GetInfo_HisTerritorial_Equ(pageIndex, pageSize, where);
        }

        #endregion

        #region【方法：获取部门（树）】

        public DataSet GetDeptTree()
        {
            return his.GetDeptTree();
        }

        #endregion
    }
}
