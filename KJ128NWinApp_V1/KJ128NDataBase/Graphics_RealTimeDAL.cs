using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class Graphics_RealTimeDAL
    {
        #region[申明]
        private DBAcess dba = new DBAcess();
        #endregion

        #region[周志豪]
        /// <summary>
        /// 根据探头ID取出该探头所探测的实时人员信息
        /// </summary>
        /// <param name="stationaddress">分站ID</param>
        /// <param name="stationheadaddress">探头ID</param>
        /// <returns>信息表</returns>
        public DataTable GetRealTimeInStationByStationInfo(int stationaddress, int stationheadaddress,bool Checked)
        {
            string sqlstr = string.Format("select count(1) from station_head_info where stationaddress={0} and stationheadaddress={1} and stationheadtypeid=8", stationaddress, stationheadaddress);
            if (dba.ExecuteScalarSql(sqlstr) == "1")
            {
                if (Checked)
                {
                    try
                    {
                        string selectstring = string.Format("select 标识卡,姓名,部门,时间 from A_RTStationHeadView where stationaddress={0} and stationheadaddress={1} and inoutflag=0", stationaddress, stationheadaddress);
                        return dba.GetDataSet(selectstring).Tables[0];
                    }
                    catch (Exception ex)
                    {
                        return new DataTable();
                    }
                }
                else
                {
                    try
                    {
                        string selectstring = "select 标识卡,姓名,部门,时间 from A_RTStationHeadView where 1=2";
                        return dba.GetDataSet(selectstring).Tables[0];
                    }
                    catch (Exception ex)
                    {
                        return new DataTable();
                    }
                }
            }
            else
            {
                try
                {
                    string selectstring = string.Format("select 标识卡,姓名,部门,时间 from A_RTStationHeadView where stationaddress={0} and stationheadaddress={1}", stationaddress, stationheadaddress);
                    return dba.GetDataSet(selectstring).Tables[0];
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
        }

        /// <summary>
        /// 得到所有部门名称
        /// </summary>
        /// <returns>信息表</returns>
        public DataTable GetAllDeptName()
        {
            //string selectstring = "select distinct 部门名称,deptid from KJ128N_Emp_Table";
            string selectstring = "select distinct deptname,deptid from Dept_Info";
            DataTable dt = dba.GetDataSet(selectstring).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == "")
                {
                    dt.Rows.RemoveAt(i);
                }
            }
            return dt;
        }

        /// <summary>
        /// 得到所有的雇员姓名
        /// </summary>
        /// <returns>信息表</returns>
        public DataTable GetAllEmpName()
        {
            string selectstring = "select 员工姓名,empid from KJ128N_Emp_Table order by 员工姓名 ";
            DataTable dt = dba.GetDataSet(selectstring).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == "")
                {
                    dt.Rows.RemoveAt(i);
                }
            }
            return dt;
        }

        /// <summary>
        /// 根据部门名称得到该部门所有的雇员姓名
        /// </summary>
        /// <param name="deptname">部门名称</param>
        /// <returns>信息表</returns>
        public DataTable GetEmpNameByDeptName(string deptname)
        {
            string selectstring = string.Format("select distinct 员工姓名,empid from KJ128N_Emp_Table where 部门名称 = '{0}' order by 员工姓名 ", deptname);
            DataTable dt = dba.GetDataSet(selectstring).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == "")
                {
                    dt.Rows.RemoveAt(i);
                }
            }
            return dt;
        }

        public DataTable GetEmpNameByDeptID(string deptid)
        {
            string selectstring;
            if (deptid == "none")
                selectstring = "SELECT  dbo.Emp_Info.EmpName,dbo.Emp_Info.EmpID FROM dbo.RT_InOutMine INNER JOIN dbo.CodeSender_Set ON  dbo.RT_InOutMine.CsSetID = dbo.CodeSender_Set.CsSetID INNER JOIN dbo.Emp_Info ON dbo.CodeSender_Set.UserID = dbo.Emp_Info.EmpID INNER JOIN dbo.Dept_Info ON dbo.Emp_Info.DeptID = dbo.Dept_Info.DeptID";
            else
                selectstring = string.Format("SELECT  dbo.Emp_Info.EmpName,dbo.Emp_Info.EmpID FROM dbo.RT_InOutMine INNER JOIN dbo.CodeSender_Set ON  dbo.RT_InOutMine.CsSetID = dbo.CodeSender_Set.CsSetID INNER JOIN dbo.Emp_Info ON dbo.CodeSender_Set.UserID = dbo.Emp_Info.EmpID INNER JOIN dbo.Dept_Info ON dbo.Emp_Info.DeptID = dbo.Dept_Info.DeptID Where dbo.Dept_Info.DeptID ={0}", deptid);
            DataTable dt = dba.GetDataSet(selectstring).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == "")
                {
                    dt.Rows.RemoveAt(i);
                }
            }
            return dt;
        }


        public DataTable GetRtEmpPositionByID(string empid)
        {
            string sqlstr = string.Format("SELECT dbo.RT_InStationHeadInfo.CodeSenderAddress, dbo.Emp_Info.EmpName, dbo.Dept_Info.DeptName, dbo.RT_InStationHeadInfo.StationHeadTime, dbo.Station_Head_Info.StationHeadPlace, dbo.Station_Head_Info.StationHeadX,  dbo.Station_Head_Info.StationHeadY FROM dbo.RT_InStationHeadInfo INNER JOIN dbo.Station_Head_Info ON  dbo.RT_InStationHeadInfo.StationHeadID = dbo.Station_Head_Info.StationHeadID INNER JOIN dbo.Emp_Info ON dbo.RT_InStationHeadInfo.UserID = dbo.Emp_Info.EmpID INNER JOIN dbo.Dept_Info ON dbo.Emp_Info.DeptID = dbo.Dept_Info.DeptID where dbo.RT_InStationHeadInfo.cstypeid=0 and dbo.RT_InStationHeadInfo.UserID={0}", empid);
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }
        /// <summary>
        /// 根据人员ID和开始结束日期得到该人员进出分站信息
        /// </summary>
        /// <param name="userid">人员ID</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>信息表</returns>
        public DataTable GetRouteByUserID(int userid, string startDate, string endDate)
        {
            string selectstring = "Shine_HistoryInOutStation_QueryView";
            SqlParameter[] parameters = new SqlParameter[] {
																new SqlParameter("@strTableName", SqlDbType.VarChar, 50),
																new SqlParameter("@intBlock", SqlDbType.Int),
																new SqlParameter("@strName", SqlDbType.VarChar, 20),
																new SqlParameter("@intUserType", SqlDbType.Int),
																new SqlParameter("@strStartDateTime", SqlDbType.VarChar, 50),
																new SqlParameter("@strEndDateTime", SqlDbType.VarChar, 50)};
            parameters[0].Value = "Shine_HisInOutStationHeadInfo_zzha";
            parameters[1].Value = userid;
            parameters[2].Value = "";
            parameters[3].Value = 0;
            parameters[4].Value = startDate;
            parameters[5].Value = endDate;
            try
            {
                return dba.GetDataSet(selectstring, parameters).Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 根据两分站的ID字符串得到路径信息
        /// </summary>
        /// <param name="ID">两分站的ID字符串中间用逗号隔开</param>
        /// <param name="isdesc">是否需要倒序</param>
        /// <returns>信息表</returns>
        public DataTable GetRoutePointByID(string ID, bool isdesc)
        {
            string selectstring = string.Empty;
            if (isdesc)
                selectstring = string.Format("select x,y from points where pointid='{0}' order by [id] desc", ID);
            else
                selectstring = string.Format("select x,y from points where pointid='{0}'", ID);
            return dba.GetDataSet(selectstring).Tables[0];
        }

        /// <summary>
        /// 根据时间 部门id和班次id查询人员信息
        /// </summary>
        /// <param name="deptid">部门id</param>
        /// <param name="selectdatetime">时间</param>
        /// <param name="timeintervalid">班次id</param>
        /// <returns>记录集</returns>
        public DataSet GetEmpByDeptIDAndTime(int deptid, DateTime startdate, DateTime enddate, int timeintervalid)
        {
            string procstring = "Shine_HistoryAttendance_GetEmpInfoByTimerIntervalID";
            SqlParameter[] parameters = new SqlParameter[] {
						new SqlParameter("@dtBeginWorkTimest", SqlDbType.DateTime),
						new SqlParameter("@dtBeginWorkTimeed", SqlDbType.DateTime),
						new SqlParameter("@intDeptId", SqlDbType.Int),
						new SqlParameter("@intTimerIntervalID", SqlDbType.Int)};
            parameters[0].Value = startdate;
            parameters[1].Value = enddate;
            parameters[2].Value = deptid;
            parameters[3].Value = timeintervalid;
            return dba.GetDataSet(procstring, parameters);
        }

        /// <summary>
        /// 根据部门ID得到该部门的班次信息
        /// </summary>
        /// <param name="deptid">部门ID</param>
        /// <returns>返回的班次信息</returns>
        public DataSet GetClassByDeptID(string deptid)
        {
            string selectstr = string.Format("SELECT dbo.TimerInterval.IntervalName, " +
                "dbo.TimerInterval.ID FROM dbo.Dept_Info INNER JOIN dbo.TimerInterval ON" +
                " dbo.Dept_Info.ClassID = dbo.TimerInterval.ClassID WHERE (dbo.Dept_Info.DeptID = {0})", deptid);
            return dba.GetDataSet(selectstr);
        }

        /// <summary>
        /// 获得所有工种名称
        /// </summary>
        /// <returns>工种名称信息</returns>
        public DataTable GetAllWorkTypeName()
        {
            string selectstr = "select distinct wtname from WorkType_Info";
            DataSet ds = dba.GetDataSet(selectstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }

        /// <summary>
        /// 根据工种名称得到该工种实时人员数量
        /// </summary>
        /// <param name="worktype">工种名称</param>
        /// <returns>该工种人员数</returns>
        public int GetRealTimeEmpNumByWorkType(string worktype)
        {
            string selectstr = string.Format("SELECT count(dbo.Emp_Info.EmpName) " +
                                          "FROM dbo.WorkType_Info INNER JOIN " +
                                          "dbo.Emp_WorkType ON  " +
                                          "dbo.WorkType_Info.WorkTypeID = dbo.Emp_WorkType.WorkTypeID INNER JOIN " +
                                          "dbo.RT_InOutStation INNER JOIN " +
                                          "dbo.RT_InOutMine ON  " +
                                          "dbo.RT_InOutStation.CodeSenderAddress = dbo.RT_InOutMine.CodeSenderAddress INNER " +
                                          " JOIN " +
                                          "dbo.CodeSender_Set ON  " +
                                          "dbo.RT_InOutMine.CsSetID = dbo.CodeSender_Set.CsSetID INNER JOIN " +
                                          "dbo.Emp_Info ON dbo.CodeSender_Set.UserID = dbo.Emp_Info.EmpID INNER JOIN " +
                                          "dbo.Station_Head_Info ON  " +
                                          "dbo.RT_InOutStation.StationAddress = dbo.Station_Head_Info.StationAddress AND  " +
                                          "dbo.RT_InOutStation.StationHeadAddress = dbo.Station_Head_Info.StationHeadAddress " +
                                          " INNER JOIN " +
                                          "dbo.Emp_NowCompany ON  " +
                                          "dbo.Emp_Info.EmpID = dbo.Emp_NowCompany.EmpID INNER JOIN " +
                                          "dbo.Dept_Info ON dbo.Emp_NowCompany.DeptID = dbo.Dept_Info.DeptID ON  " +
                                          "dbo.Emp_WorkType.EmpID = dbo.Emp_Info.EmpID " +
                                          "where wtname like '{0}' and cstypeid=0 and isenable=1"
            , worktype);
            return int.Parse(dba.ExecuteScalarSql(selectstr));
        }

        public int GetRealTimeEmpNumByDept(string deptname)
        {
            string selectstr = string.Format("SELECT COUNT(dbo.Emp_Info.EmpName) " +
                                              "FROM dbo.RT_InOutStation INNER JOIN " +
                                              "dbo.RT_InOutMine ON  " +
                                              "dbo.RT_InOutStation.CodeSenderAddress = dbo.RT_InOutMine.CodeSenderAddress INNER " +
                                              " JOIN " +
                                              "dbo.CodeSender_Set ON  " +
                                              "dbo.RT_InOutMine.CsSetID = dbo.CodeSender_Set.CsSetID INNER JOIN " +
                                              "dbo.Emp_Info ON dbo.CodeSender_Set.UserID = dbo.Emp_Info.EmpID INNER JOIN " +
                                              "dbo.Emp_NowCompany ON  " +
                                              "dbo.Emp_Info.EmpID = dbo.Emp_NowCompany.EmpID INNER JOIN " +
                                              "dbo.Dept_Info ON dbo.Emp_NowCompany.DeptID = dbo.Dept_Info.DeptID " +
                                              "where DeptName='{0}' and cstypeid=0"
                                            , deptname);
            return int.Parse(dba.ExecuteScalarSql(selectstr));
        }

        public DataTable GetRealTimeStationState()
        {
            string sqlstr = "SELECT 分站安装位置, 分站状态 FROM dbo.KJ128N_RTStation_Info_View";
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }
        #endregion

        public bool IsEmpInMine(string empid)
        {
            string sqlstr = string.Format("SELECT count(dbo.RT_InOutMine.CodeSenderAddress) "+
                                          "FROM dbo.RT_InOutMine INNER JOIN "+
                                          "dbo.CodeSender_Set ON dbo.RT_InOutMine.CsSetID = dbo.CodeSender_Set.CsSetID "+
                                          "where dbo.CodeSender_Set.UserID={0}", empid);
            int num = int.Parse(dba.ExecuteScalarSql(sqlstr));
            if (num > 0)
                return true;
            else
                return false;
        }

        public DataTable GetLastHisStationByEmpID(string empid)
        {
            string sqlstr = string.Format("select * from Shine_HisInOutStationHeadInfo_zzha where instationtime in "+
                                                "(select top 2 max(instationtime) as stime  "+
                                                " from Shine_HisInOutStationHeadInfo_zzha where userid={0} group by stationplace "+
                                                "order by stime desc "+
                                                ") and userid={0} order by instationtime", empid);
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetNowStationByEmpID(string empid)
        {
            string sqlstr = string.Format("SELECT dbo.CodeSender_Set.CodeSenderAddress, dbo.CodeSender_Set.UserID, " +
                                          "dbo.Emp_Info.EmpName, dbo.RealTimeCodeSender.StationAddress,  " +
                                          "dbo.RealTimeCodeSender.StationHeadAddress,  " +
                                          "dbo.Station_Head_Info.StationHeadPlace, dbo.Station_Head_Info.StationHeadX,  " +
                                          "dbo.Station_Head_Info.StationHeadY,dbo.RealTimeCodeSender.StationHeadDetectTime " +
                                          "FROM dbo.RealTimeCodeSender INNER JOIN " +
                                          "dbo.CodeSender_Set ON  " +
                                          "dbo.RealTimeCodeSender.CsSetID = dbo.CodeSender_Set.CsSetID INNER JOIN " +
                                          "dbo.Station_Head_Info ON  " +
                                          "dbo.RealTimeCodeSender.StationAddress = dbo.Station_Head_Info.StationAddress AND " +
                                          " dbo.RealTimeCodeSender.StationHeadAddress = dbo.Station_Head_Info.StationHeadAddress " +
                                          " INNER JOIN " +
                                          "dbo.Emp_Info ON dbo.CodeSender_Set.UserID = dbo.Emp_Info.EmpID " +
                                          "where userid={0}", empid);
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetDeptNameByEmpID(string empid)
        {
            string sqlstr = string.Format("select 员工姓名,部门名称 from KJ128N_Emp_Table where empid={0}", empid);
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetNumWorkType()
        {
            string sqlstr = "select num,wtname from A_RTWorkTypeView";
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetNumDept()
        {
            string sqlstr = "select * from A_RTDeptView";
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        #region【根据卡号查找人名 Czlt-2010-12-17】
        public string GetNameByNum(string num)
        {
            string strName = "";
            string strSql = string.Format("select EmpName,cs.CodeSenderAddress,empID from dbo.CodeSender_Set cs left join  dbo.Emp_Info  ei on cs.UserID = ei.EmpID  where cs.CodeSenderAddress ={0}", num);
            DataSet ds = dba.GetDataSet(strSql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                strName = ds.Tables[0].Rows[0].ItemArray[0].ToString().Trim();
                strName = strName + "," + ds.Tables[0].Rows[0].ItemArray[2].ToString().Trim();
            }

            return strName;

        }
        #endregion
    }
}
