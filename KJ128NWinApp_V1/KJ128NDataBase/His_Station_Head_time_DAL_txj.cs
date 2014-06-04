using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace KJ128NDataBase
{
    public class His_Station_Head_time_DAL_txj
    {
        private DBAcess dba = new DBAcess();
        DbHelperSQL DB = new DbHelperSQL();
        string sqlString = string.Empty;

        public DataSet dataGrid_renyuan_bind(int depid)
        {
            
                SqlParameter[] sqlpara = new SqlParameter[]
            {
                new SqlParameter("@depid",SqlDbType.Int,4)
              
            };

                sqlpara[0].Value = depid;
               
                return dba.ExecuteSqlDataSet("proc_select_emp_by_txj",sqlpara);
             
 
        }
        public DataSet getStation()
        {
            return dba.GetDataSet("select stationaddress,StationPlace from station_info");
        }
        public DataSet getHead(int stationid)
        {
            return dba.GetDataSet("select   stationheadaddress,stationheadplace,stationaddress from station_head_info where stationaddress='" + stationid + "'");
        }
        public DataSet GetEmployeeAttendanceHistoryList(string strWhere, int intPageIndex, int intPageSize, out string strErrMsg)
        {
            SqlParameter[] sqlpara = new SqlParameter[]
            {
                new SqlParameter("@strWhere",SqlDbType.VarChar,500),
                new SqlParameter("@PageIndex",SqlDbType.Int,4),
                new SqlParameter("@PageSize",SqlDbType.Int,4)
            };

            sqlpara[0].Value = strWhere;
            sqlpara[1].Value = intPageIndex;
            sqlpara[2].Value = intPageSize;

            return DB.RunProcedureByDataSet("Shine_Shen_EmployeeAttendanceQuery", "dst", sqlpara, out strErrMsg);
        }
        #region 查询历史经过两个探头时间
        public DataTable GetHisInOutTime(string kssj,string jssj,string ksjz,string kstt,string jsjz,string jstt,string depid,string name)
        {
            //先把数据放到DT1里面，在将DT1里的数据

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@kssj",SqlDbType.VarChar),
                new SqlParameter("@jssj",SqlDbType.VarChar),
                new SqlParameter("@ksjz",SqlDbType.VarChar),
                new SqlParameter("@kstt",SqlDbType.VarChar),
                new SqlParameter("@jsjz",SqlDbType.VarChar),
                new SqlParameter("@jstt",SqlDbType.VarChar),
                new SqlParameter("@depid",SqlDbType.VarChar),
                new SqlParameter("@name",SqlDbType.VarChar)
            };
            parms[0].Value = kssj;
            parms[1].Value = jssj;
            parms[2].Value = ksjz;
            parms[3].Value = kstt;
            parms[4].Value = jsjz;
            parms[5].Value = jstt;
            if (depid == "" || depid.Length == 0)
            {
                parms[6].Value = "0";
            }
            else
            {
                parms[6].Value = depid;
            }
            if (name == "" || name.Length == 0)
            {
                parms[7].Value = "0";
            }
            else
            {
                parms[7].Value = name;
            }
            
           
                //parms[6].Value = "0";
          
                //parms[7].Value = "0";

                DataSet newds = dba.ExecuteSqlDataSet("proc_select_his_station_head_time_txj", parms);
                DataTable dt1 = newds.Tables[0];

             DataTable dt2 = new DataTable();
       
             DataColumn column;



             #region 列





             column = new DataColumn();
             column.DataType = System.Type.GetType("System.String");
             column.ColumnName = "userid";
             dt2.Columns.Add(column);

             column = new DataColumn();
             column.DataType = System.Type.GetType("System.String");
             column.ColumnName = "username";
             dt2.Columns.Add(column);


             column = new DataColumn();
             column.DataType = System.Type.GetType("System.DateTime");
             column.ColumnName = "instationheadtime";
             dt2.Columns.Add(column);


             column = new DataColumn();
             column.DataType = System.Type.GetType("System.DateTime");
             column.ColumnName = "outstationheadtime";
             dt2.Columns.Add(column);


             //column = new DataColumn();
             //column.DataType = System.Type.GetType("System.String");
             //column.ColumnName = "stationplace";
             //dt2.Columns.Add(column);

             //column = new DataColumn();
             //column.DataType = System.Type.GetType("System.String");
             //column.ColumnName = "StationHeadPlace";
             //dt2.Columns.Add(column);


             column = new DataColumn();
             column.DataType = System.Type.GetType("System.String");
             column.ColumnName = "deptname";
             dt2.Columns.Add(column);


             column = new DataColumn();
             column.DataType = System.Type.GetType("System.String");
             column.ColumnName = "yongshi";
             dt2.Columns.Add(column);

            //CodeSenderAddress

             column = new DataColumn();
             column.DataType = System.Type.GetType("System.String");
             column.ColumnName = "CodeSenderAddress";
             dt2.Columns.Add(column);


             #endregion
            int j=dt1.Rows.Count;
            int intplace;
            bool flag=true;

             for (int i = 0; i < dt1.Rows.Count; i++)
             {
                 
                 DataRow row;
                
                 string userid = dt1.Rows[i]["userid"].ToString();
                 string username = dt1.Rows[i]["username"].ToString();
                 string instationheadtime =   dt1.Rows[i]["instationheadtime"].ToString();
                 string outstationheadtime =   dt1.Rows[i]["outstationheadtime"].ToString();

                 string stationaddress =   dt1.Rows[i]["stationaddress"].ToString();
                 string stationheadaddress =  dt1.Rows[i]["stationheadaddress"].ToString();

                 string stationplace = dt1.Rows[i]["stationplace"].ToString();
                 string StationHeadPlace = dt1.Rows[i]["StationHeadPlace"].ToString();
                 string deptname = dt1.Rows[i]["deptname"].ToString();
                 string CodeSenderAddress = dt1.Rows[i]["userid"].ToString();
                 #region dt2.row赋值
                 if (i == j)
                 {
                     //到了最后一行

                 }
                 else if (i < j - 1)
                 {
                   
                     //没有到最后一行 可以往下找一个
                     string userid1 = dt1.Rows[i + 1]["userid"].ToString();
                     string stationaddress1 = dt1.Rows[i + 1]["stationaddress"].ToString();
                     string stationheadaddress1 = dt1.Rows[i + 1]["stationheadaddress"].ToString();
                     //在原地没有前进
                     //先要判断是不是同一个人
                     if (userid1 == userid)
                     {
                         if (stationaddress == stationaddress1 && stationheadaddress == stationheadaddress1)
                         {
                             //这里是在原地没有前进

                         }
                         else
                         {
                             //前进了将上条的时间和下一条的时间插到dt2里面去
                             if (flag)
                             {
                                 row = dt2.NewRow();
                                 row["userid"] = dt1.Rows[i]["userid"].ToString();
                                 row["username"] = dt1.Rows[i]["username"].ToString();

                                 row["instationheadtime"] = dt1.Rows[i]["outstationheadtime"].ToString();

                                 row["outstationheadtime"] = dt1.Rows[i + 1]["instationheadtime"].ToString();


                                 //row["stationplace"] = dt1.Rows[i + 1]["stationplace"].ToString();
                                 //row["StationHeadPlace"] = dt1.Rows[i + 1]["StationHeadPlace"].ToString();

                                
                                 row["deptname"] = dt1.Rows[i]["deptname"].ToString();
                                 DateTime dts = DateTime.Parse(dt1.Rows[i]["outstationheadtime"].ToString());
                                 DateTime dtj = DateTime.Parse(dt1.Rows[i + 1]["instationheadtime"].ToString());

                                 TimeSpan ts = dtj.Subtract(dts);
                                 int temptian = Math.Abs(ts.Days);
                                 int temph = Math.Abs(ts.Hours);
                                 int tempm = Math.Abs(ts.Minutes);
                                 int temps = Math.Abs(ts.Seconds);
                                 string temp;
                                 if (temptian == 0 && temph == 0 && tempm ==0)
                                 {
                                     temp = temps + "秒";
                                 }
                                 else if (temptian == 0 && temph == 0)
                                 {
                                     temp = tempm + "分" + temps + "秒";
                                 }
                                 else if (temptian == 0)
                                 {

                                     temp = temph + "小时" + tempm + "分" + temps + "秒";
                                 }
                                 else 
                                 {
                                     temp = temptian+"天"+temph + "小时" + tempm + "分" + temps + "秒";
                                 }
                                 row["yongshi"] = temp;
                                 row["CodeSenderAddress"] = dt1.Rows[i]["CodeSenderAddress"].ToString();
                                 dt2.Rows.Add(row.ItemArray);
                                // flag = false;
                             }
                            

                            

                             //dt2 增加一行
                         }
                     }
                     else
                     //不是同一个人 要重新比较
                     {
                         if (stationaddress == stationaddress1 && stationheadaddress == stationheadaddress1)
                         {
                             //这里是在原地没有前进

                         }
                         else
                         {
                             //前进了将上条的时间和下一条的时间插到dt2里面去
                             row = dt2.NewRow();
                             row["userid"] = dt1.Rows[i]["userid"].ToString();
                             row["username"] = dt1.Rows[i]["username"].ToString();

                             row["instationheadtime"] = dt1.Rows[i]["outstationheadtime"].ToString();

                             row["outstationheadtime"] = dt1.Rows[i + 1]["instationheadtime"].ToString();

                             //row["stationplace"] = dt1.Rows[i + 1]["stationplace"].ToString();
                             //row["StationHeadPlace"] = dt1.Rows[i + 1]["StationHeadPlace"].ToString();

                             row["deptname"] = dt1.Rows[i]["deptname"].ToString();


                             DateTime dts = DateTime.Parse(dt1.Rows[i]["outstationheadtime"].ToString());
                             DateTime dtj = DateTime.Parse(dt1.Rows[i + 1]["instationheadtime"].ToString());

                             TimeSpan ts = dtj.Subtract(dts);

                             int temptian = Math.Abs(ts.Days);
                             int temph = Math.Abs(ts.Hours);
                             int tempm = Math.Abs(ts.Minutes);
                             int temps = Math.Abs(ts.Seconds);
                             string temp;
                             if (temptian == 0 && temph == 0 && tempm == 0)
                             {
                                 temp = temps + "秒";
                             }
                             else if (temptian == 0 && temph == 0)
                             {
                                 temp = tempm + "分" + temps + "秒";
                             }
                             else if (temptian == 0)
                             {

                                 temp = temph + "小时" + tempm + "分" + temps + "秒";
                             }
                             else
                             {
                                 temp = temptian + "天" + temph + "小时" + tempm + "分" + temps + "秒";
                             }
                             row["yongshi"] = temp;
                             row["CodeSenderAddress"] = dt1.Rows[i]["CodeSenderAddress"].ToString();
                             dt2.Rows.Add(row.ItemArray);

                             //dt2 增加一行
                         }

                     }



                 } 
                 #endregion






                 
 
             }
                
            
            return dt2;

        }
        #endregion

    }
}
