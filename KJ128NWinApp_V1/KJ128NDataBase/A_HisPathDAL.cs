using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class A_HisPathDAL
    {
        #region【声明】

        private DBAcess dba = new DBAcess();

        private DataSet ds;

        private string strSQL;

        #endregion


        #region【方法：获取巡检路线（树）】

        public DataSet GetPathTree()
        {
            strSQL = " Select * From A_PathTree ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：查询历史巡检信息】

        public DataSet GetInfo_HisPath(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "A_His_Path";
            para[1].Value = "HisPathID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            using (ds = new DataSet())
            {
                ds = dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);

                string sql = "select count(DISTINCT 标识卡号) from A_His_Path Where" + where;
                string s = dba.ExecuteScalarSql(sql);
                DataTable dt = new DataTable("TabCount");
                dt.Columns.Add("Counts");
                DataRow dr = dt.NewRow();
                dr["Counts"] = s;
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                return ds;
            }
        }
        #endregion

    }
}
