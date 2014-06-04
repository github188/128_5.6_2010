using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class HisOverEmpDAL
    {
        #region [ ���� ] 
		 
        private DBAcess dba = new DBAcess();

	    #endregion

        #region [ ����: ��ʷ��Ա��Ϣ ]

        public DataSet GetHisOverEmpAll(int pageIndex, int pageSize, string where)
        {
            if (where == string.Empty)
            {
                where = "1=1";
            }

            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@keyField",SqlDbType.VarChar,255),
                                    new SqlParameter("@fieldList",SqlDbType.VarChar,2000),
                                    new SqlParameter("@orderField",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@PageSize",SqlDbType.Int,20),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,8000),
                                    new SqlParameter("@orderType",SqlDbType.Bit)
            };
            para[0].Value = "View_His_OverEmployees";
            para[1].Value = "His_OverEmployeeID";
            para[2].Value = "His_RatingEmployeesCount as ���Ա����,His_FactEmployeeCount as ��Ա�������,"
                + "His_OverEmpCount as ��Ա����,His_OverEmployeeBeginTime as ��Ա��ʼʱ��,"
                + "His_OverEmployeeEndTime as ��Ա����ʱ��,OverEmpAbidanceTime as ��Աʱ��";
            para[3].Value = "His_OverEmployeeBeginTime";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            para[6].Value = where;
            para[7].Value = 0;

            return dba.ExecuteSqlDataSet("GetPagingRecord", para);
        }

        #endregion
        
    }
}
