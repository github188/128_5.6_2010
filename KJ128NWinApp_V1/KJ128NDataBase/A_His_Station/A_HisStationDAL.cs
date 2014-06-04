using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase.A_His_Station
{
    public class A_HisStationDAL
    {
        DBAcess db = new DBAcess();
        public DataTable DeptTree(int isemp)
        {
            SqlParameter[] par = { new SqlParameter("@isemp", SqlDbType.Int) };
            par[0].Value = isemp;
            return db.GetDataSet("A_houhui_his_Dept_Tree", par).Tables[0];
        }
        public DataSet His_Station_info(int isemp,int pagesize, int pageindex, string str)
        {
            SqlParameter[] par = {
                                     
                                     new SqlParameter("@StrWhere",SqlDbType.VarChar,1000),
                                     new SqlParameter("@PageSize",SqlDbType.Int),
                                     new SqlParameter("@PageIndex",SqlDbType.Int),
                                     new SqlParameter("@IsEmp",SqlDbType.Int)
                                 };
            par[0].Value = str;
            par[1].Value = pagesize;
            par[2].Value = pageindex;
            par[3].Value = isemp;
            return db.GetDataSet("A_houhui_His_Statoin", par);
        }
    }
}
