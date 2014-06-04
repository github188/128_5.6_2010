using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KJ128NModel;

namespace KJ128NDataBase
{
    /*
     * 李乐
     */

    #region [PathInfoDal]

    public class PathInfoDal
    {
        DbHelperSQL help = new DbHelperSQL();
        private DBAcess dba = new DBAcess();
        string outStr = String.Empty;
        /// <summary>
        /// 查询PathInfo信息
        /// </summary>
        /// <param name="strCondition">查询条件</param>
        /// <returns>返回的记录表信息</returns>
        public DataTable SelectPathInfo(string strCondition)
        {
            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@condition",SqlDbType.VarChar,200)
            };
            para[0].Value = strCondition;

            DataTable dt = help.ReturnDataTable("select_Path_Info", para);

            return dt;
        }

        /// <summary>
        /// 查询PathDetailInfo信息
        /// </summary>
        /// <param name="strCondition">查询条件</param>
        /// <returns>返回的记录表信息</returns>
        public DataTable SelectPathDetailInfo(string strCondition)
        {
            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@condition",SqlDbType.VarChar,1000)
            };
            para[0].Value = strCondition;

            DataTable dt = help.ReturnDataTable("pathDetail_Select", para);

            return dt;
        }

        /// <summary>
        /// 增加PathInfo信息
        /// </summary>
        /// <param name="pathInfo">线路信息类对象</param>
        /// <returns>此次操作影响的行数</returns>
        public int InsertPathInfo(PathInfoModel pathInfo,out string strMessage)
        {
            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@PathNo",SqlDbType.VarChar,50),
                new SqlParameter("@PathName",SqlDbType.VarChar,100),
                new SqlParameter("@Remark",SqlDbType.VarChar,200),
            };
            para[0].Value = pathInfo.PathNo;
            para[1].Value = pathInfo.PathName;
            para[2].Value = pathInfo.Remark;

            int result = help.RunProcedureByInt("insert_Path_Info", para, out strMessage);

            return result;
        }

        /// <summary>
        /// 修改PathInfo信息
        /// </summary>
        /// <param name="pathInfo">线路信息类对象</param>
        /// <returns>此次操作影响的行数</returns>
        public int UpdatePathInfo(PathInfoModel pathInfo,out string strMessage)
        {
            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int),
                new SqlParameter("@PathNo",SqlDbType.VarChar,50),
                new SqlParameter("@PathName",SqlDbType.VarChar,100),
                new SqlParameter("@Remark",SqlDbType.VarChar,200),
            };
            para[0].Value = pathInfo.Id;
            para[1].Value = pathInfo.PathNo;
            para[2].Value = pathInfo.PathName;
            para[3].Value = pathInfo.Remark;

            int result = Convert.ToInt32(help.RunProcedureByInt("update_Path_Info", para, out strMessage));

            return result;
        }

        /// <summary>
        /// 删除PathInfo信息
        /// </summary>
        /// <param name="id">线路Id</param>
        /// <returns>此次操作影响的行数</returns>
        public int DeletePathInfo(int id)
        {
            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int)
            };
            para[0].Value = id;

            int result = Convert.ToInt32(help.RunProcedureReturnString("delete_Path_Info", para, out outStr));

            return result;
        }

        /// <summary>
        /// 删除pathdatail信息
        /// </summary>
        /// <param name="id">详细巡检路线编号</param>
        /// <param name="pathNO">路径编号</param>
        public void DeletePathDetail(int id, string pathNO)
        {
            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int),
                new SqlParameter("@PathNo",SqlDbType.VarChar,50),
            };
            para[0].Value = id;
            para[1].Value = pathNO;

            help.RunProcedureByInt("pathDetail_Delete", para, out outStr);

        }

        /// <summary>
        /// 删除pathdatail信息
        /// </summary>
        /// <param name="id">详细巡检路线编号</param>
        /// <param name="pathNO">路径编号</param>
        public void DeletePathDetail(string pathNO, int stationAddress, int stationHeadAddress)
        {
            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@PathNo",SqlDbType.VarChar,50),
                new SqlParameter("@stationAddress",SqlDbType.Int),
                new SqlParameter("@stationHeadAddress",SqlDbType.Int),
            };
            para[0].Value = pathNO;
            para[1].Value = stationAddress;
            para[2].Value = stationHeadAddress;

            help.RunProcedureByInt("pathDetailInfo_Delete", para, out outStr);
        }

        /// <summary>
        /// 增加PathDetail信息
        /// </summary>
        /// <param name="pathDetail">线路具体信息类对象</param>
        /// <returns>此次操作影响的行数</returns>
        public int InsertPathDetail(PathDetailModel pathDetail)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@PathNo",SqlDbType.VarChar,50),
            new SqlParameter("@StationAddress",SqlDbType.Int),
            new SqlParameter("@StationHeadAddress",SqlDbType.Int),
            new SqlParameter("@PathInterval",SqlDbType.Int)};


            para[0].Value = pathDetail.PathNo;
            para[1].Value = pathDetail.StationAddress;
            para[2].Value = pathDetail.StationHeadAddress;
            para[3].Value = pathDetail.PathInterval;
            try
            {
                int result = help.RunProcedureByInt("insert_Path_Detail", para, out outStr);
                return result;
            }

            catch (Exception ex)
            {
                return 0;
            }

        }

        /// <summary>
        /// 获取分站树数据
        /// </summary>
        /// <param name="strPathNo">路线编号</param>
        /// <returns></returns>
        public DataSet GetStationTreeTable(string strPathNo)
        {
            string strWhere = "";
            if (strPathNo.Trim() != "")
            {
                strWhere = "pd.pathno='" + strPathNo+"'";
            }
            else
            {
                strWhere = "1=1";
            }

            string strSql = "select convert(varchar(10),stationAddress) as ID,stationPlace as [Name],'-1' as ParentID,'False' as IsChild,'False' as IsUserNum,0 as Num from station_info union all select convert(varchar(10),stationAddress)+'.'+convert(varchar(10),StationHeadAddress) as ID,StationHeadPlace as [Name],convert(varchar(10),stationAddress) as ParentID,'True' as IsChild,'False' as IsUserNum,0 as Num from(select * from station_head_info where not stationHeadid in(select h.stationHeadid from station_head_info h join path_detail pd on h.stationaddress=pd.stationAddress and h.stationHeadAddress=pd.stationHeadAddress where " + strWhere + ")) tmp ";
            return dba.GetDataSet(strSql);
        }

        /// <summary>
        /// 获取分站树数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetStationTreeTable()
        {
            string strSql = "select convert(varchar(10),stationAddress) as ID,stationPlace as [Name],'-1' as ParentID,'False' as IsChild,'False' as IsUserNum,0 as Num from station_info union all select convert(varchar(10),stationAddress)+'.'+convert(varchar(10),StationHeadAddress) as ID,StationHeadPlace as [Name],convert(varchar(10),stationAddress) as ParentID,'True' as IsChild,'False' as IsUserNum,0 as Num from station_head_info";
            return dba.GetDataSet(strSql);
        }

        /// <summary>
        /// 获取读卡分站数据
        /// </summary>
        /// <param name="strPathNo">路线编号</param>
        /// <returns></returns>
        public DataSet GetStationHeadTable(string strPathNo)
        {
            string strWhere = "";
            if (strPathNo.Trim() != "")
            {
                strWhere = "pd.pathno='" + strPathNo+"'";
            }
            else
            {
                strWhere = "1=1";
            }
            string strSql = "select convert(varchar(10),h.stationAddress)+'.'+convert(varchar(10),h.stationHeadAddress) as id,pd.id as pid,StationHeadPlace from station_head_info h join path_detail pd on h.stationaddress=pd.stationAddress and h.stationHeadAddress=pd.stationHeadAddress where " + strWhere + " order by pd.id";
            return dba.GetDataSet(strSql);
        }

        /// <summary>
        /// 获取人员巡检数据
        /// </summary>
        /// <param name="strPathNo">路线编号</param>
        /// <returns></returns>
        public DataSet GetPathEmpRelationTable(string strPathid)
        {
            string strWhere = "";
            if (strPathid.Trim() != "")
            {
                strWhere = "p.id=" + strPathid;
            }
            else
            {
                strWhere = "1=1";
            }
            string strSql = "select pe.id,e.empid,e.deptid,pe.pathno as pathno1,p.pathName as pathName1,e.empno,e.empName,e.DeptName,e.worktypeName as wtName from path_emp_Relation pe join path_info p on pe.pathno=p.pathno join emp_info e on e.empid=pe.empid  where " + strWhere;
            return dba.GetDataSet(strSql);
        }

        /// <summary>
        /// 根据部门获取人员信息
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public DataSet GetEmpInfo(string deptID)
        {
            string strWhere = "";
            if (deptID.Trim() != "")
            {
                strWhere = "DeptID=" + deptID;
            }
            else
            {
                strWhere = "1=1";
            }
            string strSql = "select EmpName,Empid from emp_info where  " + strWhere;
            return dba.GetDataSet(strSql);
        }

        public DataTable GetTreeDt(string st1, string st2,string tid)
        {
            DataTable dt2 = new DataTable();
            DataColumn column;

            #region 列
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ID";
            dt2.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Name";
            dt2.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ParentID";
            dt2.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Boolean");
            column.ColumnName = "IsChild";
            dt2.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Boolean");
            column.ColumnName = "IsUserNum";
            dt2.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Num";
            dt2.Columns.Add(column);
            #endregion
            DataTable dt1 = new DataTable();
            dt1 = dba.GetDataSet("select Id,pathname,'0' as ParentID,'true' as IsChild ,'true' as IsUserNum  from Path_Info order by PathNo").Tables[0];



            int j = dt1.Rows.Count;
            int intplace;
            bool flag = true;

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow row;
                string id = dt1.Rows[i]["Id"].ToString();
                string Name = dt1.Rows[i]["pathname"].ToString();
                string ParentID = dt1.Rows[i]["ParentID"].ToString();
                string IsChild = dt1.Rows[i]["IsChild"].ToString();
                string IsUserNum = dt1.Rows[i]["IsUserNum"].ToString();
                string Num = "";

                DataTable temp1 = new DataTable();

                #region dt2.row赋值
                if (i == j)
                {
                    //到了最后一行

                }
                else
                {

                    row = dt2.NewRow();
                    row["ID"] = dt1.Rows[i]["Id"].ToString();
                    row["Name"] = dt1.Rows[i]["pathname"].ToString();
                    row["ParentID"] = dt1.Rows[i]["ParentID"].ToString();
                    row["IsChild"] = dt1.Rows[i]["IsChild"].ToString();
                    row["IsUserNum"] = dt1.Rows[i]["IsUserNum"].ToString();
                    if (tid == "0")
                    {
                        temp1 = dba.GetDataSet("SELECT COUNT(h.ID) AS Expr1 FROM dbo.HisPathCheck h LEFT OUTER JOIN     dbo.Path_Emp_Relation p ON h.EmpID = p.EmpID INNER JOIN    dbo.Path_Info po ON p.PathNo = po.PathNo AND p.PathNo = po.PathNo INNER JOIN      dbo.TimerInterval t ON h.[Interval] = t.ID WHERE    (po.id = '" + id + "') and convert(varchar(20),CheckBeginTime,120)>'" + st1 + "'  and convert(varchar(20),CheckEndTime,120)<'" + st2 + "' ").Tables[0];
                        string yyy = "SELECT COUNT(h.ID) AS Expr1 FROM dbo.HisPathCheck h LEFT OUTER JOIN     dbo.Path_Emp_Relation p ON h.EmpID = p.EmpID INNER JOIN    dbo.Path_Info po ON p.PathNo = po.PathNo AND p.PathNo = po.PathNo INNER JOIN      dbo.TimerInterval t ON h.[Interval] = t.ID WHERE t.id='" + tid + "' and (po.id = '" + id + "') and convert(varchar(20),CheckBeginTime,120)>'" + st1 + "'  and convert(varchar(20),CheckEndTime,120)<'" + st2 + "' ";


                    }
                    else
                    {
                     temp1 = dba.GetDataSet("SELECT COUNT(h.ID) AS Expr1 FROM dbo.HisPathCheck h LEFT OUTER JOIN     dbo.Path_Emp_Relation p ON h.EmpID = p.EmpID INNER JOIN    dbo.Path_Info po ON p.PathNo = po.PathNo AND p.PathNo = po.PathNo INNER JOIN      dbo.TimerInterval t ON h.[Interval] = t.ID WHERE  t.id='" + tid + "' and (po.id = '" + id + "') and convert(varchar(20),CheckBeginTime,120)>'" + st1 + "'  and convert(varchar(20),CheckEndTime,120)<'" + st2 + "' ").Tables[0];
                    string yyy = "SELECT COUNT(h.ID) AS Expr1 FROM dbo.HisPathCheck h LEFT OUTER JOIN     dbo.Path_Emp_Relation p ON h.EmpID = p.EmpID INNER JOIN    dbo.Path_Info po ON p.PathNo = po.PathNo AND p.PathNo = po.PathNo INNER JOIN      dbo.TimerInterval t ON h.[Interval] = t.ID WHERE t.id='" + tid + "' and (po.id = '" + id + "') and convert(varchar(20),CheckBeginTime,120)>'" + st1 + "'  and convert(varchar(20),CheckEndTime,120)<'" + st2 + "' ";

                    }
                    Num = temp1.Rows[0][0].ToString();
                    row["Num"] = Convert.ToInt32(Num);
                    dt2.Rows.Add(row.ItemArray);

                }

                #endregion

            }
            return dt2;


        }

        public DataTable GetTreeDtReal(string tid)
        {
            DataTable dt2 = new DataTable();
            DataColumn column;

            #region 列
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ID";
            dt2.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Name";
            dt2.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ParentID";
            dt2.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Boolean");
            column.ColumnName = "IsChild";
            dt2.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Boolean");
            column.ColumnName = "IsUserNum";
            dt2.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Num";
            dt2.Columns.Add(column);
            #endregion
            DataTable dt1 = new DataTable();
            dt1 = dba.GetDataSet("select Id,pathname,'0' as ParentID,'true' as IsChild ,'true' as IsUserNum  from Path_Info order by PathNo").Tables[0];



            int j = dt1.Rows.Count;
            int intplace;
            bool flag = true;

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow row;
                string id = dt1.Rows[i]["Id"].ToString();
                string Name = dt1.Rows[i]["pathname"].ToString();
                string ParentID = dt1.Rows[i]["ParentID"].ToString();
                string IsChild = dt1.Rows[i]["IsChild"].ToString();
                string IsUserNum = dt1.Rows[i]["IsUserNum"].ToString();
                string Num = "";

                DataTable temp1 = new DataTable();

                #region dt2.row赋值
                if (i == j)
                {
                    //到了最后一行

                }
                else
                {

                    row = dt2.NewRow();
                    row["ID"] = dt1.Rows[i]["Id"].ToString();
                    row["Name"] = dt1.Rows[i]["pathname"].ToString();
                    row["ParentID"] = dt1.Rows[i]["ParentID"].ToString();
                    row["IsChild"] = dt1.Rows[i]["IsChild"].ToString();
                    row["IsUserNum"] = dt1.Rows[i]["IsUserNum"].ToString();
                    if (tid == "0")
                    {
                        string yyy = "SELECT COUNT(po.PathName) AS Expr1 FROM dbo.TimerInterval t INNER JOIN   dbo.RealTimePathCheck ON   t.ID = dbo.RealTimePathCheck.[Interval] LEFT OUTER JOIN   dbo.Path_Emp_Relation p INNER JOIN    dbo.Path_Info po ON p.PathNo = po.PathNo AND p.PathNo = po.PathNo ON     dbo.RealTimePathCheck.EmpID = p.EmpID  where (t.ID = '" + tid + "') and (po.Id = '" + id + "') ";
                        temp1 = dba.GetDataSet("SELECT COUNT(po.PathName) AS Expr1 FROM dbo.TimerInterval t INNER JOIN   dbo.RealTimePathCheck ON   t.ID = dbo.RealTimePathCheck.[Interval] LEFT OUTER JOIN   dbo.Path_Emp_Relation p INNER JOIN    dbo.Path_Info po ON p.PathNo = po.PathNo AND p.PathNo = po.PathNo ON     dbo.RealTimePathCheck.EmpID = p.EmpID  where (po.Id = '" + id + "')").Tables[0];

                    }
                    else
                    {
                        temp1 = dba.GetDataSet("SELECT COUNT(po.PathName) AS Expr1 FROM dbo.TimerInterval t INNER JOIN   dbo.RealTimePathCheck ON   t.ID = dbo.RealTimePathCheck.[Interval] LEFT OUTER JOIN   dbo.Path_Emp_Relation p INNER JOIN    dbo.Path_Info po ON p.PathNo = po.PathNo AND p.PathNo = po.PathNo ON     dbo.RealTimePathCheck.EmpID = p.EmpID  where (t.ID = '" + tid + "') and (po.Id = '" + id + "')").Tables[0];

                    }
                    // string yyy = "SELECT COUNT(po.PathName) AS Expr1 FROM dbo.TimerInterval t INNER JOIN   dbo.RealTimePathCheck ON   t.ID = dbo.RealTimePathCheck.[Interval] LEFT OUTER JOIN   dbo.Path_Emp_Relation p INNER JOIN    dbo.Path_Info po ON p.PathNo = po.PathNo AND p.PathNo = po.PathNo ON     dbo.RealTimePathCheck.EmpID = p.EmpID  where (t.ID = '" + tid + "') and (po.Id = '" + id + "') ";
                    Num = temp1.Rows[0][0].ToString();
                    row["Num"] = Convert.ToInt32(Num);
                    dt2.Rows.Add(row.ItemArray);

                }

                #endregion

            }
            return dt2;


        }

        public DataTable GetEmp_by(string codeid, string rname, string banci, string kssj, string jssj, string pathid)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@codeid",SqlDbType.VarChar),
                new SqlParameter("@rname",SqlDbType.VarChar),
                new SqlParameter("@banci",SqlDbType.VarChar),
                new SqlParameter("@kssj",SqlDbType.VarChar),
                new SqlParameter("@jssj",SqlDbType.VarChar),
                new SqlParameter("@pathid",SqlDbType.VarChar),
               
            };
            parms[0].Value = codeid;
            parms[1].Value = rname;
            parms[2].Value = banci;
            parms[3].Value = kssj;
            parms[4].Value = jssj;
            parms[5].Value = pathid;
            DataTable dt1 = dba.ExecuteSqlDataSet("select_HisPath_by_txjl", parms).Tables[0];

            #region 重新构造DT

            DataTable dt2 = new DataTable();
            DataColumn column;

            #region 列
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ID";
            dt2.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "codeid";
            dt2.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "name";
            dt2.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "dept";
            dt2.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "banci";
            dt2.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "pathname";
            dt2.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "stime";
            dt2.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "jtime";
            dt2.Columns.Add(column);


          


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "xtime";
            dt2.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "gongzhong";
            dt2.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "zhiwu";
            dt2.Columns.Add(column);



            #endregion
           


            int j = dt1.Rows.Count;
            int intplace;
            bool flag = true;

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow row;
                string empid = dt1.Rows[i]["empid"].ToString();
                string gongzhong = "";
                string zhiwu = "";
                
                //string Name = dt1.Rows[i]["pathname"].ToString();
                //string ParentID = dt1.Rows[i]["ParentID"].ToString();
                //string IsChild = dt1.Rows[i]["IsChild"].ToString();
                //string IsUserNum = dt1.Rows[i]["IsUserNum"].ToString();
                //string Num = "";

                DataTable temp1 = new DataTable();

                #region dt2.row赋值
                if (i == j)
                {
                    //到了最后一行

                }
                else
                {

                    row = dt2.NewRow();
                    row["ID"] = dt1.Rows[i]["Id"].ToString();
                    row["codeid"] = dt1.Rows[i]["codeid"].ToString();
                    row["name"] = dt1.Rows[i]["name"].ToString();
                    row["dept"] = dt1.Rows[i]["dept"].ToString();
                    row["banci"] = dt1.Rows[i]["banci"].ToString();

                    row["banci"] = dt1.Rows[i]["banci"].ToString();
                    row["pathname"] = dt1.Rows[i]["pathname"].ToString();
                    row["stime"] = dt1.Rows[i]["stime"].ToString();
                    row["jtime"] = dt1.Rows[i]["jtime"].ToString();
                    row["xtime"] = dt1.Rows[i]["xtime"].ToString();


                    empid = dt1.Rows[i]["empid"].ToString();
                    temp1 = dba.GetDataSet("SELECT dbo.Emp_NowCompany.EmpID, dbo.WorkType_Info.WtName,       dbo.Duty_Info.DutyName FROM dbo.Emp_NowCompany INNER JOIN      dbo.Emp_WorkType ON       dbo.Emp_NowCompany.EmpID = dbo.Emp_WorkType.EmpID LEFT OUTER JOIN     dbo.WorkType_Info ON       dbo.Emp_WorkType.WorkTypeID = dbo.WorkType_Info.WorkTypeID LEFT OUTER JOIN      dbo.Duty_Info ON dbo.Emp_NowCompany.DutyID = dbo.Duty_Info.DutyID WHERE (Emp_NowCompany.EmpID = '" + empid + "') ").Tables[0];
                    if (temp1.Rows.Count > 0)
                    {
                        gongzhong = temp1.Rows[0][1].ToString();
                        zhiwu = temp1.Rows[0][2].ToString();
                    }
                    row["gongzhong"] = gongzhong.ToString();
                    row["zhiwu"] = zhiwu.ToString();
                    //Num = temp1.Rows[0][0].ToString();
                    //row["Num"] = Convert.ToInt32(Num);
                    dt2.Rows.Add(row.ItemArray);

                }

                #endregion

            }
            


            #endregion
            return dt2;





        }

        public DataTable GetEmpReal_by(string codeid, string rname, string banci,  string pathid)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@codeid",SqlDbType.VarChar),
                new SqlParameter("@rname",SqlDbType.VarChar),
                new SqlParameter("@banci",SqlDbType.VarChar),
                new SqlParameter("@pathid",SqlDbType.VarChar)
               
            };
            parms[0].Value = codeid;
            parms[1].Value = rname;
            parms[2].Value = banci;
            parms[3].Value = pathid;

            DataSet ds1 = dba.ExecuteSqlDataSet("select_RealTimePath_by_txj", parms);
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            if (ds1 != null && ds1.Tables.Count > 0)
            {
                dt1 = dba.ExecuteSqlDataSet("select_RealTimePath_by_txj", parms).Tables[0];
                #region 重新构造DT

                
                DataColumn column;

                #region 列
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "ID";
                dt2.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "codeid";
                dt2.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "name";
                dt2.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "dept";
                dt2.Columns.Add(column);


                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "banci";
                dt2.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "pathname";
                dt2.Columns.Add(column);





                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "xtime";
                dt2.Columns.Add(column);






                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "weizhi";
                dt2.Columns.Add(column);


                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "weizhitime";
                dt2.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "gongzhong";
                dt2.Columns.Add(column);


                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "zhiwu";
                dt2.Columns.Add(column);



                #endregion



                int j = dt1.Rows.Count;
                int intplace;
                bool flag = true;

                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    DataRow row;
                    string empid = dt1.Rows[i]["empid"].ToString();
                    string gongzhong = "";
                    string zhiwu = "";

                    //string Name = dt1.Rows[i]["pathname"].ToString();
                    //string ParentID = dt1.Rows[i]["ParentID"].ToString();
                    //string IsChild = dt1.Rows[i]["IsChild"].ToString();
                    //string IsUserNum = dt1.Rows[i]["IsUserNum"].ToString();
                    //string Num = "";

                    DataTable temp1 = new DataTable();

                    #region dt2.row赋值
                    if (i == j)
                    {
                        //到了最后一行

                    }
                    else
                    {

                        row = dt2.NewRow();
                        row["ID"] = dt1.Rows[i]["Id"].ToString();
                        row["codeid"] = dt1.Rows[i]["sendid"].ToString();
                        row["name"] = dt1.Rows[i]["rname"].ToString();
                        row["dept"] = dt1.Rows[i]["bumen"].ToString();
                        row["banci"] = dt1.Rows[i]["banci"].ToString();


                        row["pathname"] = dt1.Rows[i]["pathname"].ToString();
                        row["xtime"] = dt1.Rows[i]["xtime"].ToString();
                        row["weizhi"] = dt1.Rows[i]["weizhi"].ToString();
                        row["weizhitime"] = dt1.Rows[i]["weizhitime"].ToString();


                        empid = dt1.Rows[i]["empid"].ToString();
                        temp1 = dba.GetDataSet("SELECT dbo.Emp_NowCompany.EmpID, dbo.WorkType_Info.WtName,       dbo.Duty_Info.DutyName FROM dbo.Emp_NowCompany INNER JOIN      dbo.Emp_WorkType ON       dbo.Emp_NowCompany.EmpID = dbo.Emp_WorkType.EmpID LEFT OUTER JOIN     dbo.WorkType_Info ON       dbo.Emp_WorkType.WorkTypeID = dbo.WorkType_Info.WorkTypeID LEFT OUTER JOIN      dbo.Duty_Info ON dbo.Emp_NowCompany.DutyID = dbo.Duty_Info.DutyID WHERE (Emp_NowCompany.EmpID = '" + empid + "') ").Tables[0];
                        if (temp1.Rows.Count > 0)
                        {
                            gongzhong = temp1.Rows[0][1].ToString();
                            zhiwu = temp1.Rows[0][2].ToString();
                        }
                        row["gongzhong"] = gongzhong.ToString();
                        row["zhiwu"] = zhiwu.ToString();
                        //Num = temp1.Rows[0][0].ToString();
                        //row["Num"] = Convert.ToInt32(Num);
                        dt2.Rows.Add(row.ItemArray);

                    }

                    #endregion

                }



                #endregion

            }



            //DataTable dt1 = dba.ExecuteSqlDataSet("select_RealTimePath_by_txj", parms).Tables[0];

        
            return dt2;





        }
    }

    #endregion

    #region [PathDetailDal]

    public class PathDetailDal
    {
        DbHelperSQL help = new DbHelperSQL();
        string outStr = String.Empty;

        /// <summary>
        /// 增加PathDetail信息
        /// </summary>
        /// <param name="strCondition">查询条件</param>
        /// <returns>返回的记录表信息</returns>
        public DataTable SelectPathDetail(string strCondition)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@condition",SqlDbType.VarChar,1000)
        };
            para[0].Value = strCondition;

            DataTable dt = help.ReturnDataTable("select_Path_Detail", para);
            return dt;
        }

        /// <summary>
        /// 增加PathDetail信息
        /// </summary>
        /// <param name="pathDetail">线路具体信息类对象</param>
        /// <returns>此次操作影响的行数</returns>
        public int InsertPathDetail(PathDetailModel pathDetail)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@PathNo",SqlDbType.VarChar),
            new SqlParameter("@StationAddress",SqlDbType.Int),
            new SqlParameter("@StationHeadAddress",SqlDbType.Int)
        };
            para[0].Value = pathDetail.PathNo;
            para[1].Value = pathDetail.StationAddress;
            para[2].Value = pathDetail.StationHeadAddress;
            try
            {
                int result = help.RunProcedureByInt("insert_Path_Detail", para, out outStr);
                return result;
            }

            catch (Exception ex)
            {
                return 0;
            }

        }

        /// <summary>
        /// 修改PathDetail信息
        /// </summary>
        /// <param name="pathDetail">线路具体信息类对象</param>
        /// <returns>此次操作影响的行数</returns>
        public int UpdatePathDetail(PathDetailModel pathDetail)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@Id",SqlDbType.Int),
            new SqlParameter("@PathNo",SqlDbType.VarChar),
            new SqlParameter("@StationAddress",SqlDbType.Int),
                new SqlParameter("@StationHeadAddress",SqlDbType.Int)
        };
            para[0].Value = pathDetail.Id;
            para[1].Value = pathDetail.PathNo;
            para[2].Value = pathDetail.StationAddress;
            para[3].Value = pathDetail.StationHeadAddress;

            int result = help.RunProcedureByInt("update_Path_Detail", para, out outStr);

            return result;
        }

        /// <summary>
        /// 删除PathDetail信息
        /// </summary>
        /// <param name="id">记录Id</param>
        /// <returns>此次操作影响的行数</returns>
        public int DeletePathDetail(int id)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@Id",SqlDbType.Int)
        };
            para[0].Value = id;

            int result = help.RunProcedureByInt("delete_Path_Detail", para, out outStr);

            return result;
        }
    }

    #endregion

    #region [PathEmpRelationDal]

    public class PathEmpRelationDal
    {
        DbHelperSQL help = new DbHelperSQL();
        string outStr = String.Empty;

        /// <summary>
        /// 增加PathEmpRelation信息
        /// </summary>
        /// <param name="strCondition">查询条件</param>
        /// <returns>返回的记录表信息</returns>
        public DataTable SelectPathEmpRelation(string strCondition)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@condition",SqlDbType.VarChar,200)
        };
            para[0].Value = strCondition;

            DataTable dt = help.ReturnDataTable("select_Path_Emp_Relation", para);

            return dt;
        }

        /// <summary>
        /// 增加PathEmpRelation信息
        /// </summary>
        /// <param name="pathEmpRelation">线路员工关系类对象</param>
        /// <returns>此次操作影响的行数</returns>
        public int InsertPathEmpRelation(PathEmpRelationModel pathEmpRelation,out string strMessage)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@PathNo",SqlDbType.VarChar,50),
            new SqlParameter("@EmpID",SqlDbType.Int),
        };
            para[0].Value = pathEmpRelation.PathNo;
            para[1].Value = pathEmpRelation.EmpID;

            int result = help.RunProcedureByInt("insert_Path_Emp_Relation", para, out strMessage);

            return result;
        }

        /// <summary>
        /// 增加PathEmpRelation信息
        /// </summary>
        /// <param name="pathEmpRelation">线路员工关系类对象</param>
        /// <returns>此次操作影响的行数</returns>
        public int InsertPathEmpRelation_cjg(PathEmpRelationModel pathEmpRelation)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@PathNo",SqlDbType.VarChar,20),
            new SqlParameter("@EmpNo",SqlDbType.VarChar,20),
        };
            para[0].Value = pathEmpRelation.PathNo;
            para[1].Value = pathEmpRelation.EmpNo;

            int result = help.RunProcedureByInt("insert_Path_Emp_Relation", para, out outStr);

            return result;
        }

        /// <summary>
        /// 修改PathEmpRelation信息
        /// </summary>
        /// <param name="pathEmpRelation">线路员工关系类对象</param>
        /// <returns>此次操作影响的行数</returns>
        public int UpdatePathEmpRelation(PathEmpRelationModel pathEmpRelation,out string strMessage)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@Id",SqlDbType.Int),
            new SqlParameter("@PathNo",SqlDbType.VarChar,20),
            new SqlParameter("@Empid",SqlDbType.Int),
        };
            para[0].Value = pathEmpRelation.Id;
            para[1].Value = pathEmpRelation.PathNo;
            para[2].Value = pathEmpRelation.EmpID;

            int result = help.RunProcedureByInt("update_Path_Emp_Relation", para, out strMessage);

            return result;
        }

        /// <summary>
        /// 删除PathEmpRelation信息
        /// </summary>
        /// <param name="id">记录Id</param>
        /// <returns>此次操作影响的行数</returns>
        public int DeletePathEmpRelation(int id)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@Id",SqlDbType.Int)
        };
            para[0].Value = id;

            int result = help.RunProcedureByInt("delete_Path_Emp_Relation", para, out outStr);

            return result;
        }
    }

    #endregion

    #region [RealTimeAlarmPath]

    /// <summary>
    /// 实时路线报警
    /// </summary>
    //public class RealTimeAlarmPathDal
    //{
    //    DbHelperSQL help = new DbHelperSQL();
    //    string outStr = String.Empty;

    //    public int DeleteRealTimeAlarmPathByEmpNo(string empNO)
    //    {
    //        SqlParameter[] para = new SqlParameter[] { 
    //        new SqlParameter("@EmpNo",SqlDbType.VarChar)
    //    };
    //        para[0].Value = empNO;

    //        int result = help.RunProcedureByInt("delete_RealTimePathAlert", para, out outStr);

    //        return result;
    //    }
    //}

    #endregion

    #region [HisPathAlertDal]

    public class HisPathAlertDal
    {
        DbHelperSQL help = new DbHelperSQL();
        string outStr = String.Empty;

        /// <summary>
        /// 增加HisPathAlert
        /// </summary>
        /// <param name="strCondition">查询条件</param>
        /// <returns>返回的记录表信息</returns>
        public DataTable SelectHisPathAlert(string strCondition)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@condition",SqlDbType.VarChar,200)
        };
            para[0].Value = strCondition;

            DataTable dt = help.ReturnDataTable("select_His_PathAlert", para);

            return dt;
        }

        /// <summary>
        /// 增加HisPathAlert
        /// </summary>
        /// <param name="hisPathAlert">历史线路报警类对象</param>
        /// <returns>此次操作影响的行数</returns>
        public int InsertHisPathAlert(HisPathAlertModel hisPathAlert)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@PathId",SqlDbType.Int),
            new SqlParameter("@StationHeadId",SqlDbType.Int),
            new SqlParameter("@EmpId",SqlDbType.Int),
            new SqlParameter("@AlertBeginTime",SqlDbType.DateTime),
            new SqlParameter("@AlertEndTime",SqlDbType.DateTime),
            new SqlParameter("@AlertTimeValue",SqlDbType.Int)
        };
            para[0].Value = hisPathAlert.PathId;
            para[1].Value = hisPathAlert.StationHeadId;
            para[2].Value = hisPathAlert.EmpId;
            para[3].Value = hisPathAlert.AlertBeginTime;
            para[4].Value = hisPathAlert.AlertEndTime;
            para[5].Value = hisPathAlert.AlertTimeValue;

            int result = help.RunProcedureByInt("insert_His_PathAlert", para, out outStr);

            return result;
        }

        /// <summary>
        /// 删除HisPathAlert
        /// </summary>
        /// <param name="id">记录Id</param>
        /// <returns>此次操作影响的行数</returns>
        public int DeleteHisPathAlert(int id)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@Id",SqlDbType.Int)
        };
            para[0].Value = id;

            int result = help.RunProcedureByInt("delete_His_PathAlert", para, out outStr);

            return result;
        }
    }

    #endregion

    #region [RealTimePathCheckDal]

    public class RealTimePathCheckDal
    {
        DbHelperSQL help = new DbHelperSQL();
        string outStr = String.Empty;

        public DataTable SelectRealTimePathCheckByPath(string PathNo)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@pathNo",SqlDbType.VarChar,50)
        };
            para[0].Value = PathNo;

            DataTable dt = help.ReturnDataTable("select_RealTimePathCheckByPath", para);

            return dt;
        }

        public DataTable SelectRealTimePathCheckByInterval(int Interval)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@Interval",SqlDbType.Int)
        };
            para[0].Value = Interval;

            DataTable dt = help.ReturnDataTable("select_RealTimePathCheckByInterval", para);

            return dt;
        }

        public int InsertRealTimePathCheck(RealTimePathCheckModel model)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@EmpID",SqlDbType.Int),
            new SqlParameter("@Interval",SqlDbType.Int),
            new SqlParameter("@CheckTime",SqlDbType.DateTime)
        };
            para[0].Value = model.EmpNO;
            para[1].Value = model.Interval;
            para[2].Value = model.CheckTime;


            int result = help.RunProcedureByInt("insert_RealTimePathCheck", para, out outStr);

            return result;
        }

        public int UpdateRealTimePathCheck(RealTimePathCheckModel model)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@Id",SqlDbType.Int),
            new SqlParameter("@EmpID",SqlDbType.Int),
            new SqlParameter("@Interval",SqlDbType.Int),
            new SqlParameter("@CheckTime",SqlDbType.DateTime)
        };
            para[0].Value = model.Id;
            para[1].Value = model.EmpNO;
            para[2].Value = model.Interval;
            para[3].Value = model.CheckTime;


            int result = help.RunProcedureByInt("update_RealTimePathCheck", para, out outStr);

            return result;
        }

        public int DeleteRealTimePathCheck(int id)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@Id",SqlDbType.Money),
            
        };
            para[0].Value = id;


            int result = help.RunProcedureByInt("delete_RealTimePathCheck", para, out outStr);

            return result;
        }

        public DataTable GetTimeInterval()
        {
            DataTable dt = help.ReturnDataTable("select_TimeInterval", null);
            return dt;
        }
    }

    #endregion

    #region [HisPathCheckDal]

    public class HisPathCheckDal
    {
        DbHelperSQL help = new DbHelperSQL();
        string outStr = String.Empty;


        public DataTable SelectHisPathCheckByPath(string pathNo)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@pathNo",SqlDbType.VarChar,1000)
        };
            para[0].Value = pathNo;

            DataTable dt = help.ReturnDataTable("select_HisPathCheckByPath", para);

            return dt;
        }


        public DataTable SelectHisPathCheckByInterval(int Inter)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@InterVal",SqlDbType.Int)
        };
            para[0].Value = Inter;

            DataTable dt = help.ReturnDataTable("select_HisPathCheckByInterval", para);

            return dt;
        }

        public DataTable SelectEmpPassInfo(int EmpID, DateTime BeginTime)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@EmpID",SqlDbType.Int),
            new SqlParameter("@BeginTime",SqlDbType.DateTime)
        };
            para[0].Value = EmpID;
            para[1].Value = BeginTime;

            DataTable dt = help.ReturnDataTable("select_EmpPassInfo", para);

            return dt;
        }

        public int InsertHisPathCheck(HisPathCheckModel model)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@EmpID",SqlDbType.Int),
            new SqlParameter("@Interval",SqlDbType.Int),
            new SqlParameter("@CheckBeginTime",SqlDbType.DateTime),
            new SqlParameter("@CheckEndTime",SqlDbType.DateTime)
        };
            para[0].Value = model.EmpNO;
            para[1].Value = model.Interval;
            para[2].Value = model.CheckBeginTime;
            para[3].Value = model.CheckEndTime;

            int result = help.RunProcedureByInt("insert_HisPathCheck", para, out outStr);

            return result;
        }

        public int UpdateHisPathCheck(HisPathCheckModel model)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@Id",SqlDbType.Int),
            new SqlParameter("@EmpID",SqlDbType.Int),
            new SqlParameter("@Interval",SqlDbType.Int),
            new SqlParameter("@CheckBeginTime",SqlDbType.DateTime),
            new SqlParameter("@CheckEndTime",SqlDbType.DateTime)
        };
            para[0].Value = model.Id;
            para[1].Value = model.EmpNO;
            para[2].Value = model.Interval;
            para[3].Value = model.CheckBeginTime;
            para[4].Value = model.CheckEndTime;


            int result = help.RunProcedureByInt("", para, out outStr);

            return result;
        }

        public int DeleteHisPathCheck(int id)
        {
            SqlParameter[] para = new SqlParameter[] { 
            new SqlParameter("@Id",SqlDbType.Money),
            
        };
            para[0].Value = id;

            int result = help.RunProcedureByInt("", para, out outStr);

            return result;
        }


        public DataTable GetTimeInterval()
        {
            DataTable dt = help.ReturnDataTable("select_TimeInterval", null);
            return dt;
        }
    }

    #endregion
}
