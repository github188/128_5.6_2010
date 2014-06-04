using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class A_RT_PathCheckBLL
    {
        A_RT_PathCheckDAL dal = new A_RT_PathCheckDAL();
        public DataTable A_RT_PathCheck(string StrWhere)
        {
            DataSet ds = dal.A_RT_PathCheck(StrWhere);
            return ds.Tables[0];
        }
    }
}
