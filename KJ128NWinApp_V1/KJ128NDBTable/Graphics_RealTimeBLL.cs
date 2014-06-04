using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class Graphics_RealTimeBLL
    {
        #region[申明]
        private Graphics_RealTimeDAL grt = new Graphics_RealTimeDAL();
        #endregion

        #region[周志豪]

        /// <summary>
        /// 根据探头ID得到该探头所探测到的实时人员信息
        /// </summary>
        /// <param name="stationid">探头ID</param>
        /// <returns>信息表</returns>
        public DataTable GetRealTimeInStationByStationInfo(string stationid,bool Checked)
        {
            string[] address = stationid.Split('.');
            return grt.GetRealTimeInStationByStationInfo(int.Parse(address[0]), int.Parse(address[1]), Checked);
        }

        /// <summary>
        /// 得到所有部门
        /// </summary>
        /// <returns>信息表</returns>
        public DataTable GetAllDept()
        {
            return grt.GetAllDeptName();
        }

        /// <summary>
        /// 得到所有部门的雇员
        /// </summary>
        /// <returns>信息表</returns>
        public DataTable GetAllEmp()
        {
            return grt.GetAllEmpName();
        }

        /// <summary>
        /// 根据部门名称得到该部门所有雇员
        /// </summary>
        /// <param name="deptname">部门名称</param>
        /// <returns>信息表</returns>
        public DataTable GetEmpByDeptName(string deptname)
        {
            return grt.GetEmpNameByDeptName(deptname);
        }

        public DataTable GetEmpByDeptID(string deptid)
        {
            return grt.GetEmpNameByDeptID(deptid);
        }

        public DataTable GetRtEmpPositionByID(string empid)
        {
            return grt.GetRtEmpPositionByID(empid);
        }
        /// <summary>
        /// 根据人员ID 起始时间和结束时间得到该人员的历史轨迹
        /// </summary>
        /// <param name="id">人员ID</param>
        /// <param name="startdate">起始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <returns>信息表</returns>
        public List<string> GetRouteInfoByEmpID(string id, string startdate, string enddate)
        {
            DataTable oldDt = grt.GetRouteByUserID(int.Parse(id), startdate, enddate);
            if (oldDt != null)
            {
                if (oldDt.Rows.Count > 0)
                {
                    //string empname = oldDt.Rows[0][12].ToString() + ":" + oldDt.Rows[0][2].ToString();
                    string empname;
                    if (oldDt.Rows[0][12].ToString() == "")
                        empname = oldDt.Rows[0][2].ToString();
                    else
                        empname = oldDt.Rows[0][12].ToString() + ":" + oldDt.Rows[0][2].ToString();
                    string routepoint = string.Empty;
                    string address = string.Empty;
                    string stationpoint = string.Empty;
                    string date = string.Empty;
                    bool isdesc = false;
                    int LastIndex = 0;
                    for (int i = 1; i < oldDt.Rows.Count; i++)
                    {
                        string nowname = oldDt.Rows[i]["StationPlace"].ToString();
                        if (oldDt.Rows[LastIndex]["StationPlace"].ToString() != oldDt.Rows[i]["StationPlace"].ToString() && oldDt.Rows[i]["StationPlace"].ToString() != "")
                        {
                            string towid;
                            float xy1 = float.Parse(oldDt.Rows[LastIndex]["StationAddress"].ToString() + "." + oldDt.Rows[LastIndex]["StationHeadAddress"].ToString());
                            float xy2 = float.Parse(oldDt.Rows[i]["StationAddress"].ToString() + "." + oldDt.Rows[i]["StationHeadAddress"].ToString());
                            LastIndex = i;

                            if (xy1 > xy2)
                            {
                                towid = xy2.ToString("F1") + "," + xy1.ToString("F1");
                                isdesc = true;
                            }
                            else
                            {
                                towid = xy1.ToString("F1") + "," + xy2.ToString("F1");
                                isdesc = false;
                            }
                            DataTable dt = grt.GetRoutePointByID(towid, isdesc);
                            if (dt.Rows.Count != 0)
                            {
                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    routepoint = routepoint + dt.Rows[j]["x"].ToString() + "," + dt.Rows[j]["y"].ToString() + "|";
                                }
                            }
                            else
                            {
                                throw new Exception("路径尚未配置,或者配置的路径不符合要求,请检查...");
                            }
                            if (oldDt.Rows[i]["StationPlace"].ToString() != "")
                            {
                                //routepoint = routepoint + oldDt.Rows[i]["StationX"].ToString() + "," + oldDt.Rows[i]["StationY"] + "|";
                                address = address + oldDt.Rows[i]["StationPlace"].ToString() + "|";
                                stationpoint = stationpoint + oldDt.Rows[i]["StationX"].ToString() + "," + oldDt.Rows[i]["StationY"] + "|";
                                date = date + oldDt.Rows[i]["InStationTime"].ToString() + "|" + oldDt.Rows[i]["OutStationTime"].ToString() + "|";
                            }
                        }
                    }

                    List<string> list = new List<string>();
                    if (routepoint != "")
                    {
                        list.Add(routepoint.Remove(routepoint.Length - 1));
                        list.Add(date.Remove(date.Length - 1));
                        list.Add(address.Remove(address.Length - 1));
                        list.Add(stationpoint.Remove(stationpoint.Length - 1));
                        list.Add(empname);
                    }
                    return list;
                }
                return null;
            }
            return null;
        }

        public DataSet GetEmpByDeptAndClass(int deptid, DateTime selectdatetime, string timeintervalid)
        {
            DateTime startdatetime = DateTime.Parse(selectdatetime.ToString("yyyy-MM-dd 00:00:00"));
            DateTime enddatetime = DateTime.Parse(selectdatetime.ToString("yyyy-MM-dd 23:59:59"));
            int interal = int.Parse(timeintervalid);
            return grt.GetEmpByDeptIDAndTime(deptid, startdatetime, enddatetime, interal);
        }

        public DataTable GetClassByDeptID(string deptid)
        {
            DataSet ds = grt.GetClassByDeptID(deptid);
            if (ds == null)
                return null;
            else
                return ds.Tables[0];
        }

        public List<string> GetEmpWorkTypeNumRealTime(int allnum)
        {
            List<string> list = new List<string>();
            //DataTable worktypedt = grt.GetAllWorkTypeName();
            //if (worktypedt != null)
            //{
            //    for (int i = 0; i < worktypedt.Rows.Count; i++)
            //    {
            //        string str = worktypedt.Rows[i]["wtname"].ToString();
            //        str = str + ":  " + grt.GetRealTimeEmpNumByWorkType(worktypedt.Rows[i]["wtname"].ToString()).ToString() + "人";
            //        list.Add(str);
            //    }
            //}
            DataTable dt = grt.GetNumWorkType();
            int sumnum = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string str = dt.Rows[i][1].ToString() + ":  " + dt.Rows[i][0].ToString() + "人";
                sumnum = sumnum + Convert.ToInt32(dt.Rows[i][0]);
                list.Add(str);
            }
            string last = "未配置:  ";
            int lastnum = allnum - sumnum;
            last = last + lastnum.ToString();
            list.Add(last);
            return list;
        }

        public string GetEmpInMineCounts()
        {
            return new RealTimeDAL().N_EmpInMineCounts();
        }

        public List<string> GetRealTimeEmpNumByDept()
        {
            List<string> list = new List<string>();
            //DataTable deptdt = this.GetAllDept();
            //if (deptdt != null)
            //{
            //    for (int i = 0; i < deptdt.Rows.Count; i++)
            //    {
            //        string str = deptdt.Rows[i]["部门名称"].ToString();
            //        str = str + ":  " + grt.GetRealTimeEmpNumByDept(deptdt.Rows[i]["部门名称"].ToString()) + "人";
            //        list.Add(str);
            //    }
            //}
            DataTable dt = grt.GetNumDept();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string str = dt.Rows[i][1].ToString() + ":  " + dt.Rows[i][0].ToString() + "人";
                list.Add(str);
            }
            return list;
        }

        public List<string> GetAllStationState()
        {
            DataTable dt = grt.GetRealTimeStationState();
            List<string> list = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(dt.Rows[i][0].ToString() + "-" + dt.Rows[i][1].ToString());
            }
            return list;
        }
        #endregion 

        public bool IsEmpInMine(string empid)
        {
            return grt.IsEmpInMine(empid);
        }

        public List<string> GetLastHisStationByEmpID(string empid,out DataRow LastMovedRow)
        {
            DataTable oldDt = grt.GetLastHisStationByEmpID(empid);
            if (oldDt != null)
            {
                if (oldDt.Rows.Count > 0)
                {
                    //string empname = oldDt.Rows[0][12].ToString() + ":" + oldDt.Rows[0][2].ToString();
                    string empname = this.GetNameDeptByEmpID(empid);
                    string routepoint = string.Empty;
                    string address = string.Empty;
                    string stationpoint = string.Empty;
                    string date = string.Empty;
                    bool isdesc = false;
                    int LastIndex = 0;
                    for (int i = 1; i < oldDt.Rows.Count; i++)
                    {
                        string nowname = oldDt.Rows[i]["StationPlace"].ToString();
                        if (oldDt.Rows[LastIndex]["StationPlace"].ToString() != oldDt.Rows[i]["StationPlace"].ToString() && oldDt.Rows[i]["StationPlace"].ToString() != "")
                        {
                            string towid;
                            float xy1 = float.Parse(oldDt.Rows[LastIndex]["StationAddress"].ToString() + "." + oldDt.Rows[LastIndex]["StationHeadAddress"].ToString());
                            float xy2 = float.Parse(oldDt.Rows[i]["StationAddress"].ToString() + "." + oldDt.Rows[i]["StationHeadAddress"].ToString());
                            LastIndex = i;

                            if (xy1 > xy2)
                            {
                                towid = xy2.ToString("F1") + "," + xy1.ToString("F1");
                                isdesc = true;
                            }
                            else
                            {
                                towid = xy1.ToString("F1") + "," + xy2.ToString("F1");
                                isdesc = false;
                            }
                            DataTable dt = grt.GetRoutePointByID(towid, isdesc);
                            if (dt.Rows.Count != 0)
                            {
                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    routepoint = routepoint + dt.Rows[j]["x"].ToString() + "," + dt.Rows[j]["y"].ToString() + "|";
                                }
                            }
                            else
                            {
                                throw new Exception("路径尚未配置,或者配置的路径不符合要求,请检查...");
                            }
                            if (oldDt.Rows[i]["StationPlace"].ToString() != "")
                            {
                                //routepoint = routepoint + oldDt.Rows[i]["StationX"].ToString() + "," + oldDt.Rows[i]["StationY"] + "|";
                                address = address + oldDt.Rows[i]["StationPlace"].ToString() + "|";
                                stationpoint = stationpoint + oldDt.Rows[i]["StationX"].ToString() + "," + oldDt.Rows[i]["StationY"] + "|";
                                date = date + oldDt.Rows[i]["InStationTime"].ToString() + "|" + oldDt.Rows[i]["OutStationTime"].ToString() + "|";
                            }
                        }
                    }

                    List<string> list = new List<string>();
                    if (routepoint != "")
                    {
                        list.Add(routepoint.Remove(routepoint.Length - 1));
                        list.Add(date.Remove(date.Length - 1));
                        list.Add(address.Remove(address.Length - 1));
                        list.Add(stationpoint.Remove(stationpoint.Length - 1));
                        list.Add(empname);
                    }
                    LastMovedRow = oldDt.Rows[oldDt.Rows.Count - 1];
                    return list;
                }
                LastMovedRow = null;
                return null;
            }
            LastMovedRow = null;
            return null;
        }

        public string GetNameDeptByEmpID(string empid)
        {
            DataTable dt = grt.GetDeptNameByEmpID(empid);
            return dt.Rows[0][1].ToString()+":"+dt.Rows[0][0].ToString();
        }

        public DataTable GetNowStationByEmpID(string empid)
        {
            return grt.GetNowStationByEmpID(empid);
        }

        public List<string> GetRTEmpRoute(DataTable oldDt,string empnamedept, out DataRow LastMovedRow)
        {
            if (oldDt != null)
            {
                if (oldDt.Rows.Count > 0)
                {
                    //string empname = oldDt.Rows[0][12].ToString() + ":" + oldDt.Rows[0][2].ToString();
                    string empname = empnamedept;
                    string routepoint = string.Empty;
                    string address = string.Empty;
                    string stationpoint = string.Empty;
                    string date = string.Empty;
                    bool isdesc = false;
                    int LastIndex = 0;
                    for (int i = 1; i < oldDt.Rows.Count; i++)
                    {
                        string nowname = oldDt.Rows[i]["StationPlace"].ToString();
                        if (oldDt.Rows[LastIndex]["StationPlace"].ToString() != oldDt.Rows[i]["StationPlace"].ToString() && oldDt.Rows[i]["StationPlace"].ToString() != "")
                        {
                            string towid;
                            float xy1 = float.Parse(oldDt.Rows[LastIndex]["StationAddress"].ToString() + "." + oldDt.Rows[LastIndex]["StationHeadAddress"].ToString());
                            float xy2 = float.Parse(oldDt.Rows[i]["StationAddress"].ToString() + "." + oldDt.Rows[i]["StationHeadAddress"].ToString());
                            LastIndex = i;

                            if (xy1 > xy2)
                            {
                                towid = xy2.ToString("F1") + "," + xy1.ToString("F1");
                                isdesc = true;
                            }
                            else
                            {
                                towid = xy1.ToString("F1") + "," + xy2.ToString("F1");
                                isdesc = false;
                            }
                            DataTable dt = grt.GetRoutePointByID(towid, isdesc);
                            if (dt.Rows.Count != 0)
                            {
                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    routepoint = routepoint + dt.Rows[j]["x"].ToString() + "," + dt.Rows[j]["y"].ToString() + "|";
                                }
                            }
                            else
                            {
                                throw new Exception("路径尚未配置,或者配置的路径不符合要求,请检查...");
                            }
                            if (oldDt.Rows[i]["StationPlace"].ToString() != "")
                            {
                                //routepoint = routepoint + oldDt.Rows[i]["StationX"].ToString() + "," + oldDt.Rows[i]["StationY"] + "|";
                                address = address + oldDt.Rows[i]["StationPlace"].ToString() + "|";
                                stationpoint = stationpoint + oldDt.Rows[i]["StationX"].ToString() + "," + oldDt.Rows[i]["StationY"] + "|";
                                date = date + oldDt.Rows[i]["InStationTime"].ToString() + "|" + oldDt.Rows[i]["OutStationTime"].ToString() + "|";
                            }
                        }
                    }

                    List<string> list = new List<string>();
                    if (routepoint != "")
                    {
                        list.Add(routepoint.Remove(routepoint.Length - 1));
                        list.Add(date.Remove(date.Length - 1));
                        list.Add(address.Remove(address.Length - 1));
                        list.Add(stationpoint.Remove(stationpoint.Length - 1));
                        list.Add(empname);
                    }
                    LastMovedRow = oldDt.Rows[oldDt.Rows.Count - 1];
                    return list;
                }
                LastMovedRow = null;
                return null;
            }
            LastMovedRow = null;
            return null;
        }


        #region【根据卡号查找人名 Czlt-2010-12-17】
        public string GetNameByNum(string num)
        {
            return grt.GetNameByNum(num);
        }
        #endregion
    }
}
