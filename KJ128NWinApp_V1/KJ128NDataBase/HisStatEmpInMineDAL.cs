using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class HisStatEmpInMineDAL
    {
        private DBAcess dba = new DBAcess();

        public DataSet StatMonthEmp(string strYear,int index,int size,string strWhere,string isLead)
        {
            SqlParameter[] arrParm = 
				{
					new SqlParameter("@year", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@strwhere",SqlDbType.VarChar,2000),
                    new SqlParameter("@IsLead",SqlDbType.Int)
				};
            arrParm[0].Value = strYear;
            arrParm[1].Value = index;
            arrParm[2].Value = size;
            arrParm[3].Value = strWhere;
            arrParm[4].Value = isLead;

            return dba.ExecuteSqlDataSet("Shine_djc_StatMonthEmp", arrParm);
        }

        #region【方法：月人员下井统计——无分页】

        public DataSet StatMonthEmp(string strYear, string strWhere, string isLead)
        {
            //SqlParameter[] arrParm = 
            //    {
            //        new SqlParameter("@year", SqlDbType.Int),
            //        new SqlParameter("@strwhere",SqlDbType.VarChar,2000),
            //        new SqlParameter("@IsLead",SqlDbType.Int)
            //    };
            //arrParm[0].Value = strYear;
            //arrParm[1].Value = strWhere;
            //arrParm[2].Value = isLead;

            //return dba.ExecuteSqlDataSet("A_Shine_StatMonthEmp_z", arrParm);

            SqlParameter[] arrParm = 
				{					
                    new SqlParameter("@strwhere",SqlDbType.VarChar,200),
                    new SqlParameter("@IsLead",SqlDbType.Int)
				};
            arrParm[0].Value = " [cYear]='" + strYear + "' and " + strWhere;
            arrParm[1].Value = isLead;
        

            return dba.ExecuteSqlDataSet("Czlt_StatMonthEmp", arrParm);

        }

        #endregion

        public DataSet A_StatMonthEmp(string strYear, string Uday,string Dday,int index, int size, string strWhere, string isLead)
        {
            SqlParameter[] arrParm = 
				{
					new SqlParameter("@year", SqlDbType.Int),
                    new SqlParameter("@Uday",SqlDbType.Int),
                    new SqlParameter("@Dday",SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@strwhere",SqlDbType.VarChar,2000),
                    new SqlParameter("@IsLead",SqlDbType.Int)
				};
            arrParm[0].Value = strYear;
            arrParm[1].Value = Uday;
            arrParm[2].Value = Dday;
            arrParm[3].Value = index;
            arrParm[4].Value = size;
            arrParm[5].Value = strWhere;
            arrParm[6].Value = isLead;

            return dba.ExecuteSqlDataSet("A_Shine_hh_StatMonthEmp", arrParm);
        }

    }
}
