using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class HisOverEmpBLL
    {
        private HisOverEmpDAL his = new HisOverEmpDAL();

        #region [ 方法: 历史超员信息 ]

        public DataSet GetHisOverEmpAll(int pageIndex, int pageSize, string where)
        {
            pageIndex--;
            return his.GetHisOverEmpAll(pageIndex, pageSize, where);
        }

        #endregion
    }
}
