using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable.A_RT_Mine_List
{
    public class A_RT_Mine_ListBLL
    {
        KJ128NDataBase.A_RT_MineList.A_RT_Mine_ListDAL dal = new KJ128NDataBase.A_RT_MineList.A_RT_Mine_ListDAL();
        public DataTable DutyTree()
        {
            return dal.DutyTree();
        }
        public DataTable Get_Mine_EmpList(string strwhere)
        {
            return dal.Get_Mine_EmpList(strwhere);
        }
        public DataTable Get_Mine_Panel(string EmpId)
        {
            return dal.Get_Mine_Panel(EmpId);
        }


        #region【Czlt-2014-01-14 实时下井人员名单中部门树和分站树查询】

        /// <summary>
        /// 部门树
        /// </summary>
        /// <returns></returns>
        public DataSet GetDeptDs()
        {
            return dal.DeptTree();
        }

        /// <summary>
        /// 分站树
        /// </summary>
        /// <returns></returns>
        public DataSet GetStaDs()
        {
            return dal.StaTree();
        }

        /// <summary>
        /// 查询该部门下面的所有子部门
        /// </summary>
        /// <returns></returns>
        public DataSet GetDetpLevId(string strID)
        {
            return dal.GetDetpLevId(strID);
 
        }

        #endregion
    }
}
