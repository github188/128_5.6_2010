using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace KJ128NDataBase
{
    public class A_HisStationHeadDAL
    {
        #region【声明】

        private DBAcess dba = new DBAcess();

        private DataSet ds;

        private string strSQL;

        #endregion

        #region【方法：获取部门（树）】

        public DataSet GetDeptTree()
        {
            //qyz 2012-5-18 按部门排序
            strSQL = " Select * From A_Tree_Dept order by serialno";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取分站（树）】

        public DataSet GetStaHeadTree()
        {
            strSQL = " Select * From A_StaHeadTree_HisStaHead ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：查询历史读卡分站信息——人员】

        public DataSet GetInfo_HisStationHead_Emp(string where, string tablename, string tablename2)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@tblName2",SqlDbType.VarChar,255),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = tablename;
            para[1].Value = tablename2;
            para[2].Value = where;
            try
            {
                //ds = dba.ExecuteSqlDataSet("Shine_GetRecordByPageNew", para);
                ds = dba.ExecuteSqlDataSet("Shine_GetRecordByPageNew", para);
                if (ds != null && ds.Tables.Count > 0)
                {

                    DataTable dt = ds.Tables[0];
                    
                    dt.Columns.Add("持续时长");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (DateTime.Parse(dt.Rows[i]["进入时间"].ToString()) < DateTime.Parse(dt.Rows[i]["离开时间"].ToString()))
                        {
                            DateTime intime = DateTime.Parse(dt.Rows[i]["进入时间"].ToString());
                            DateTime outtime = DateTime.Parse(dt.Rows[i]["离开时间"].ToString());
                            int time = int.Parse(dt.Rows[i]["持续时间"].ToString());
                            if (time > 0)
                            {
                                int hour = time / 3600;
                                time = time % 3600;
                                int min = time / 60;
                                time = time % 60;
                                dt.Rows[i]["持续时长"] = hour.ToString() + "时" + min.ToString() + "分" + time.ToString() + "秒";
                            }
                            else
                            {
                                dt.Rows[i]["持续时长"] = "——";
                            }
                        }
                    }
                    dt.Columns.Remove("持续时间");
                    return ds;
                }
                else
                {
                    return new DataSet();
                }
                return ds;
            }
            catch (Exception ex)
            {
                return new DataSet();
            }
        }
        #endregion

        #region【方法：查询历史读卡分站信息——设备】

        public DataSet GetInfo_HisStationHead_Equ(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "A_His_StationHead_Equ";
            para[1].Value = "HisStationHeadID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            using (ds = new DataSet())
            {
                ds = dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);

                string sql = "select count(DISTINCT 标识卡号) from A_His_StationHead_Equ Where" + where;
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


        #region 【方法:Czlt-2010-12-06 获取工种(树)】
        public DataSet GetDutyTree()
        {
            string strSqlTree = "select wt.workTypeID as ID,wt.wtName as Name ,0 as ParentID,'true' as IsChild ,'false' as IsUserNum ,0 as Num From WorkType_Info as wt ";
              //  "select distinct 99999 as ID,'未配置' as Name ,0 as ParentID,'true' as IsChild ,'false' as IsUserNum ,0 as Num From WorkType_Info as wt";
            return dba.GetDataSet(strSqlTree);
        }
        #endregion

        #region【czlt-2011-12-20 查询历史数据】
        /// <summary>
        /// Czlt-2011-12-10 查询历史数据
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pageSize"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet Czlt_GetEmpInfo_HisStationHead(int pageindex, int pageSize, string startTime, string endTime, string where)
        {
            
            SqlParameter[] para = { new SqlParameter("@StartTime",SqlDbType.VarChar,20),
                                    new SqlParameter("@EndTime",SqlDbType.VarChar,20),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000),
                                    new SqlParameter("@pageSize",SqlDbType.Int),
                                    new SqlParameter("@pageIndex",SqlDbType.Int)                                    
                                  
            };
            para[0].Value = startTime;
            para[1].Value =endTime;// HisStationHeadID //进入分站的时间Czlt-2011-06-05
            para[2].Value = where;
            para[3].Value = pageSize;
            para[4].Value = pageindex;
            try {
                ds = dba.ExecuteSqlDataSet("Czlt_GetHisInoutStaHead", para);
            }
            catch (Exception ex)
            {
                ds = new DataSet();
            
            }
            return ds;
          

        }
        #endregion

    }
}
