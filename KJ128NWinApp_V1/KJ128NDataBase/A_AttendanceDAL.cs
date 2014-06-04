using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace KJ128NDataBase.A_Attendace
{
    public class A_AttendanceDAL
    {
        DBAcess db = new DBAcess();
        public DataSet Dept_Tree_Static()
        {
            SqlParameter[] par = { };
            return db.GetDataSet("A_Dept_Tree_Static", par);
        }
    }
}
