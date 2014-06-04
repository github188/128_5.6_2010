using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class A_HisTerritorialDAL
    {

        #region【声明】

        private DBAcess dba = new DBAcess();

        private DataSet ds;

        private string strSQL;

        #endregion


        #region【方法：获取区域信息（树）——历史区域】

        public DataSet GetTerritorialTree()
        {
            strSQL = " Select * From A_AlarmTreeHis_Territorial ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：查询历史区域——人员】

        public DataSet GetInfo_HisTerritorial_Emp(int pageIndex, int pageSize, string where,string TableName,string TableName2)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@tblName2",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "His_InOutTerritorial_"+TableName;
            para[1].Value = "His_InOutTerritorial_"+TableName2;
            para[2].Value = "HisTerritorialID";
            para[3].Value = pageSize;
            para[4].Value = pageIndex;
            para[5].Value = 1;
            para[6].Value = 0;
            para[7].Value = where;
            //para[6].Value = "1=1";
            using (ds = new DataSet())
            {
                ds = dba.ExecuteSqlDataSet("Shine_InOutMine_ByPage", para);
                return ds;
            }
           

            //SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
            //                        new SqlParameter("@fldName",SqlDbType.VarChar,255),
            //                        new SqlParameter("@PageSize",SqlDbType.Int),
            //                        new SqlParameter("@PageIndex",SqlDbType.Int),
            //                        new SqlParameter("@IsReCount",SqlDbType.Bit),
            //                        new SqlParameter("@OrderType",SqlDbType.Bit),
            //                        new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            //};
            //para[0].Value = "His_InOutTerritorial_" + TableName;
            //para[1].Value = "HisTerritorialID";zai 

            //para[2].Value = pageSize;
            //para[3].Value = pageIndex;
            //para[4].Value = 1;
            //para[5].Value = 0;
            //para[6].Value = where;

            //using (ds = new DataSet())
            //{
            //    ds = dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);

            //    ////string sql = "select count(DISTINCT 标识卡号) from A_His_Territorial_Emp Where" + where;
            //    //string s = dba.ExecuteScalarSql(sql);
            //    //DataTable dt = new DataTable("TabCount");
            //    //dt.Columns.Add("Counts");
            //    //DataRow dr = dt.NewRow();
            //    //dr["Counts"] = s;
            //    //dt.Rows.Add(dr);
            //    //ds.Tables.Add(dt);
            //    return ds;
            //}
        }
        #endregion

        #region【方法：查询历史区域——设备】

        public DataSet GetInfo_HisTerritorial_Equ(int pageIndex, int pageSize, string where)
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

            using (ds = new DataSet())
            {
                ds = dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);

                //string sql = "select count(DISTINCT 标识卡号) from A_His_Territorial_Equ Where" + where;
                //string s = dba.ExecuteScalarSql(sql);
                //DataTable dt = new DataTable("TabCount");
                //dt.Columns.Add("Counts");
                //DataRow dr = dt.NewRow();
                //dr["Counts"] = s;
                //dt.Rows.Add(dr);
                //ds.Tables.Add(dt);
                return ds;
            }
        }

        #endregion

        #region【方法：获取部门（树）】

        public DataSet GetDeptTree()
        {
            strSQL = " Select * From A_Tree_Dept ";
            return dba.GetDataSet(strSQL);
        }

        #endregion
    }
}
