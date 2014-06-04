using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class A_HisPathBLL
    {
        #region【声明】

        private A_HisPathDAL his = new A_HisPathDAL();

        #endregion

        #region【方法：获取巡检路线（树）】

        public DataSet GetPathTree()
        {
            return his.GetPathTree();
        }

        #endregion

        #region【方法：查询历史巡检信息】

        public DataSet GetInfo_HisPath(int pageIndex, int pageSize, string where)
        {
            return his.GetInfo_HisPath(pageIndex, pageSize, where);
        }

        #endregion

    }
}
