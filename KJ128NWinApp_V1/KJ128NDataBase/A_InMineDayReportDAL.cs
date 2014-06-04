using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{

    /// <summary>
    /// 日下井路线报表DAL
    /// </summary>
    public class A_InMineDayReportDAL
    {

        #region【声明】

        private DBAcess dba = new DBAcess();

        private DataSet ds;

        private string strSQL;

        #endregion
        
        /// <summary>
        /// 获取日下井路线报表信息
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="where">查询条件</param>
        /// <returns>数据集</returns>
        public DataSet SelectInMineDayReportInfo(int pageIndex, int pageSize, string where)
        {

            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "A_His_Territorial_Equ";
            para[1].Value = "HisTerritorialID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            DataSet ds = dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);

            return ds;

        }

        /// <summary>
        /// 获取日下井路线报表信息
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>数据集</returns>
        public DataSet SelectInMineDayReportInfo(string where)
        {
            SqlParameter[] para = { 
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
          
            para[0].Value = where;
            DataSet ds = dba.ExecuteSqlDataSet("??", para);
            return ds;
        }
    }
}