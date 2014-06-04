using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable.A_RT_OverSee
{
    public  class A_Station_HeadBLL
    {
        KJ128NDataBase.A_RT_OverSee.A_Station_HeadDAL dal = new KJ128NDataBase.A_RT_OverSee.A_Station_HeadDAL();
        #region[监测]
        public DataTable A_RT_Station_Head(string StrWhere,int pd)
        {
            return dal.A_RT_Station_Head(StrWhere,pd).Tables[0];
        }
        #endregion
        //public DataTable A_exSQL(string sql)
        //{
        //    return dal.A_exSQL(sql).Tables[0];
        //}
        public DataSet A_RT_Dept_Tree(int isEmp)
        {
            return dal.A_RT_Dept_Tree(isEmp);
        }
        public string  A_RT_Station_Head_count(string StrWhere, int pd)
        {
            return dal.A_RT_Station_Head_count(StrWhere, pd).Tables[0].Rows[0][0].ToString();
        }
    }
}
