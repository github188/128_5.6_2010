using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;
namespace KJ128NDBTable
{
    
    public class CustomerBLL
    {
        CustomerDAL dal = new CustomerDAL();
        #region 获得数据列表

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(out string ErrMsgString)
        {
            return dal.GetList(out ErrMsgString);
        }

        #endregion
    }
}
