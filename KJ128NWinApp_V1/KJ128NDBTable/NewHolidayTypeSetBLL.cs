using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class NewHolidayTypeSetBLL
    {
        private NewHolidayTypeSetDAL dal = new NewHolidayTypeSetDAL();
        #region [ 方法: 实时部门人员信息 ]


        public DataSet GetHolidayType(int pageIndex, int pageSize, string where)
        {
            return dal.GetHolidayType(pageIndex, pageSize, where);
        }

        #endregion

        
    }
}
