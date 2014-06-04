using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace KJ128NDataBase
{
    public class A_HisAlarmDAL
    {

        #region【声明】

        private DBAcess dba = new DBAcess();

        private DataSet ds;

        private string strSQL;

        #endregion

        #region [ 方法: 历史超员信息 ]

        public DataSet GetHisOverEmpAll(int pageIndex, int pageSize, string where)
        {
 
            SqlParameter[] para = { 
                                    new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "A_View_His_OverEmployees";
            para[1].Value = "hisoveremployeeid";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }

        #endregion

        #region[方法：历史区域超时]
        public DataSet GetHisTerOVerTime(int pageIndex, int pageSize, string where)
        {
            
            SqlParameter[] para = { 
                                    new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "A_His_Ter_EmpOverTime";
            para[1].Value = "id";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;
            using (ds = new DataSet())
            {
                ds = dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);

                //string sql = "select count(distinct 标识卡) from A_His_Ter_EmpOverTime where" + where;
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

        #region【方法：获取部门信息（树）——实时超时】

        public DataSet GetDeptTree_EmpOverTime()
        {
            strSQL = " Select * From A_HisAlarm_Dept_EmpOverTime ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 查询历史超时信息
        public DataSet GetOverTimeSet(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "A_KJ128N_HisOverTime_Info";
            para[1].Value = "HisOverTimeAlarmID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            using (ds=new DataSet())
            {
                ds = dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);

                //string sql = "select count(DISTINCT 标识卡号) from A_KJ128N_HisOverTime_Info Where" + where;
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

        #region【方法：获取区域信息（树）——历史区域】

        public DataSet GetDeptTree_Territorial()
        {
            strSQL = " Select * From A_AlarmTreeHis_Territorial ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法：获取唯一性部门树信息】
        public DataSet GetDeptTree_Onlyone()
        {
            strSQL = " Select * From A_DeptTree_HisCheckCards ";
            return dba.GetDataSet(strSQL);
        }
        #endregion

        #region 查询历史区域报警信息
        public DataSet GetInfo_HisTerritorial(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "His_InOutTerritorial_" + DateTime.Parse(where.Substring(where.LastIndexOf("InTerritorialTime")).Split('\'')[1]).ToString("yyyyM");
            para[1].Value = "HisTerritorialID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            using (ds = new DataSet())
            {
                ds = dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);

                //string sql = "select count(DISTINCT 标识卡号) from A_HisAlarm_Territorial Where" + where;
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

        #region 查询历史工作异常信息
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
            para[0].Value = "A_HisAlarm_Path";
            para[1].Value = "HisAlarmPathID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            using (ds = new DataSet())
            {
                ds = dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);

                //string sql = "select count(DISTINCT 标识卡号) from A_HisAlarm_Path Where" + where;
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

        #region【方法：获取传输分站信息（树）——实时传输分站】

        public DataSet GetTree_Station()
        {
            strSQL = " Select StationAddress as ID, " +
                        " StationPlace as Name, " +
                        " '0' as ParentID, " +
                        " 'true' as IsChild , " +
                        " 'false' as IsUserNum , " +
                        " 0 as Num " +
                     " From Station_Info ";
            return dba.GetDataSet(strSQL);
        }

        #endregion


        #region【方法：查询历史传输分站故障信息】

        public DataSet GetInfo_HisStation(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            //para[0].Value = "HistoryBadStations";
            para[0].Value = "A_HisAlarm_Station";
            para[1].Value = "HistoryBadStationsID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            using (ds = new DataSet())
            {
                ds = dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);

                //string sql = "select count(DISTINCT 分站编号) from A_HisAlarm_Station Where" + where;
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

        #region【方法：获取读卡分站信息（树）——历史读卡分站】

        public DataSet GetTree_StationHead()
        {
            strSQL = " Select 'S'+ CONVERT(varchar,Si.StationAddress) as ID, " +
                        " Si.StationPlace as Name , " +
                        " '0' as ParentID, " +
                        " 'true' as IsChild , " +
                        " 'false' as IsUserNum , " +
                        " 0 as Num " +
                     " From Station_Info as Si " +
                     " Union " +
                     " Select 'H'+ Convert(varchar,Shi.StationAddress)+Convert(varchar,Shi.StationHeadAddress) as ID, " +
                        " Shi.StationHeadPlace as Name, " +
                        " 'S'+Convert(varchar,Shi.StationAddress) as ParentID, " +
                        " 'true' as IsChild , " +
                        " 'false' as IsUserNum , " +
                        " 0 as Num  " +
                     " From Station_Head_Info as Shi";

            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：查询历史读卡分站故障信息】

        public DataSet GetInfo_HisStationHead(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "A_HisAlarm_StationHead";
            para[1].Value = "HistoryBadStationsID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            using (ds = new DataSet())
            {
                ds = dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);

                //string sql = "Select Count(1) From (select DISTINCT 传输分站编号,读卡分站编号 from A_HisAlarm_StationHead Where" + where +" ) as A ";
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

        #region【方法：查询历史超速报警信息】

        public DataSet GetInfo_HisOverSpeed(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "A_HisAlarm_OverSpeed";
            para[1].Value = "HisOverSpeedID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            using (ds = new DataSet())
            {
                ds = dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);

                //string sql = "Select Count(1) From (select DISTINCT 标识卡号 from A_HisAlarm_OverSpeed Where" + where + " ) as A ";
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

        #region【方法：查询历史欠速报警信息】

        public DataSet GetInfo_HisLackSpeed(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "A_HisAlarm_LackSpeed";
            para[1].Value = "HisOverSpeedID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            using (ds = new DataSet())
            {
                ds = dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);

                //string sql = "Select Count(1) From (select DISTINCT 标识卡号 from A_HisAlarm_LackSpeed Where" + where + " ) as A ";
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

        #region【方法：查询历史求救报警信息】

        public DataSet GetInfo_HisEmpHelp(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "A_HisAlarm_EmpHelp";
            para[1].Value = "HisEmpHelpID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            using (ds = new DataSet())
            {
                ds = dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);

                //string sql = "Select Count(1) From (select DISTINCT 标识卡号 from A_HisAlarm_EmpHelp Where" + where + " ) as A ";
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

        #region【方法：查询历史求救报警信息】

        public DataSet GetInfo_HisOnlyone(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "A_Alarm_HisCheckCards";
            para[1].Value = "HisOnlyoneID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            using (ds = new DataSet())
            {
                ds = dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
                return ds;
            }
        }

        #endregion

        #region【方法：查询历史区域超员报警信息】

        public DataSet GetInfo_HisTerOverEmp(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "A_HisAlarm_TerOverEmp";
            para[1].Value = "HisTerOverEmpID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);

        }
        #endregion

        #region【方法：获取是否启用该报警】

        public DataSet IsEnableAlarm(int intAlarm)
        {
            strSQL = " Select EnumValue From EnumTable where FunID=12 And EnumID = " + intAlarm.ToString();
            return dba.GetDataSet(strSQL);
        }

        #endregion


        #region【Czlt-2011-05-11 查询历史供电情况】

        /// <summary>
        /// 传输分站历史供电情况
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetHisDYStation(string strWhere)
        {
            SqlParameter[] para = {
                                      new  SqlParameter("@strWhere",SqlDbType.VarChar,1000)
                                  };
            para[0].Value = strWhere;

            using (ds = new DataSet())
            {
                ds = dba.ExecuteSqlDataSet("Czlt_Proc_DYStation", para);
                return ds;
            }
        }

        /// <summary>
        /// 串口服务器供电状态
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetHisDYSerial(string strWhere)
        {
            SqlParameter[] para = {
                                      new  SqlParameter("@strWhere",SqlDbType.VarChar,1000)
                                  };
            para[0].Value = strWhere;

            using (ds = new DataSet())
            {
                ds = dba.ExecuteSqlDataSet("Czlt_Proc_DYSerial", para);
                return ds;
            }

        }

        /// <summary>
        /// 查询串口树
        /// </summary>
        /// <returns></returns>
        public DataSet GetTree_IpConfig()
        {
            strSQL = "select IpAddress as ID,place as Name, '0' as ParentID, 'true' as IsChild , 'false' as IsUserNum , 0 as Num from dbo.TcpIPConfig";
            return dba.GetDataSet(strSQL);
        }
        #endregion
    }
}
