using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase.A_Report_Forms
{
    public class A_Report_FormDAL
    {
        private DBAcess db = new DBAcess();
        public void AutoInsertReportForm(DateTime dt)
        {
            SqlParameter[] par = { new SqlParameter("@NowDate",SqlDbType.DateTime) };
            par[0].Value = dt;
            db.ExecuteSql("A_Report_Forms_Date_houhui",par);
        }
        public DataTable Select_A_baobiao(string strwhere)
        {
            string sql = "select distinct * from dbo.A_baobiao where " + strwhere;
            return db.GetDataSet(sql).Tables[0];
        }
    }
}
