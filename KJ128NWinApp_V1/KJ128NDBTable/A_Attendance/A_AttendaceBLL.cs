using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable.A_Attendance
{
    public class A_AttendaceBLL
    {
        KJ128NDataBase.A_Attendace.A_AttendanceDAL dal = new KJ128NDataBase.A_Attendace.A_AttendanceDAL();
        public DataTable Dept_Tree_Static()
        {
            DataSet ds = dal.Dept_Tree_Static();
            if (ds != null)
            {
                return dal.Dept_Tree_Static().Tables[0];
            }
            else
            {
                DataTable dt = new DataTable();
               return  dt;
                
            }
        }

    }
}
