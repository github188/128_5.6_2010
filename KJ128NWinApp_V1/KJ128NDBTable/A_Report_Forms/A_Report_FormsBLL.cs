using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KJ128NDataBase;

namespace KJ128NDBTable.A_Report_Forms
{
    public class A_Report_FormsBLL
    {
        KJ128NDataBase.A_Report_Forms.A_Report_FormDAL dal = new KJ128NDataBase.A_Report_Forms.A_Report_FormDAL();
        public void AutoInsertReportForm(DateTime dt)
        {
            dal.AutoInsertReportForm(dt);
        }
        public DataTable selectA_baobiao(string str)
        {
            return dal.Select_A_baobiao(str);
        }
    }
}
