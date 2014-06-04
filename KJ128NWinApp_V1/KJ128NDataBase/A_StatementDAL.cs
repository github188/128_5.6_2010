using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class A_StatementDAL
    {

        #region【声明】

        private DBAcess dba = new DBAcess();

        private string strSQL;

        #endregion

        #region【方法：查询——下井人员统计】

        public DataSet Get_EmpInWellStatement(string strDate)
        {
            SqlParameter[] para = { 
                                      new SqlParameter("@strDate",SqlDbType.NVarChar,20),
                                      new SqlParameter("@strTable",SqlDbType.NVarChar,20)
            };
            para[0].Value = strDate;
            para[1].Value = DateTime.Parse(strDate).ToString("yyyyM");

            return dba.GetDataSet("A_Statement_EmpInWell", para);
        }

        #endregion

        #region【方法：查询——重点区域人员统计】

        public DataSet Get_KeyAreaStatement(string strDate)
        {
            SqlParameter[] para = { new SqlParameter("strDate",SqlDbType.NVarChar,20),
                                      new SqlParameter("@strTable",SqlDbType.NVarChar,20)
            };
            para[0].Value = strDate;
            para[1].Value = DateTime.Parse(strDate).ToString("yyyyM");

            return dba.GetDataSet("A_Statement_KeyArea", para);
        }

        #endregion

        #region【方法：查询——限制区域报警人员统计】

        public DataSet Get_ConfineAreaStatement(string strDate)
        {
            SqlParameter[] para = { 
                                      new SqlParameter("strDate",SqlDbType.NVarChar,20),
                                      new SqlParameter("@strTable",SqlDbType.NVarChar,20)
            };
            para[0].Value = strDate;
            para[1].Value = DateTime.Parse(strDate).ToString("yyyyM");

            return dba.GetDataSet("A_Statement_ConfineArea", para);
        }

        #endregion

        #region【方法：查询——超时报警人员统计】

        public DataSet Get_OverTimeEmpStatement(string strDate)
        {
            SqlParameter[] para = { 
                                      new SqlParameter("strDate",SqlDbType.NVarChar,20)
            };
            para[0].Value = strDate;

            return dba.GetDataSet("A_Statement_OverTime", para);
        }

        #endregion

        #region【Czlt-2010-11-10-查询领导干部日下井情况】

        public DataSet Get_LearderDayStatement(string strDate)
        {
            SqlParameter[] para = { 
                                      new SqlParameter("@strDate",SqlDbType.NVarChar,20),
                                      new SqlParameter("@strTable",SqlDbType.NVarChar,20)
            };
            para[0].Value = strDate;
            para[1].Value = DateTime.Parse(strDate).ToString("yyyyM");

            return dba.GetDataSet("leadDayStatement", para);
        }

        #endregion
    }
}
