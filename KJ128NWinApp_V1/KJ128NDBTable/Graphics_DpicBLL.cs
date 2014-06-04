using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;
using System.Drawing;
using KJ128NModel;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace KJ128NDBTable
{
    public class Graphics_DpicBLL
    {
        //Czlt -2011-01-28  轨迹生成时间
        //private long timeLon;
        Graphics_Dpic dpicdb = new Graphics_Dpic();
        ZzhaStationDAL zzhastationdal = new ZzhaStationDAL();
        //private Graphics_RealTimeDAL grt = new Graphics_RealTimeDAL();

        public int InsertBackPicFile(string filename, byte[] filebytes)
        {
            return dpicdb.InsertBackPicFile(filename, filebytes);
        }

        public int UpdateBackPicFile(string filename, byte[] filebytes)
        {
            return dpicdb.UpdateBackPicFile(filename, filebytes);
        }

        public DataTable GetAllBackPicFile()
        {
            return dpicdb.GetAllBackPicFile();
        }

        public bool DelBackPicFile(string filename)
        {
            return dpicdb.DelBackPicFile(filename);
        }

        public DataTable GetBackPicByFileID(string fileid)
        {
            return dpicdb.GetBackPicByFileID(fileid);
        }

        public bool IsRouted(string fileID)
        {
            return dpicdb.IsRouted(fileID);
        }

        public bool IsPointed(string fileid)
        {
            return dpicdb.IsPointed(fileid);
        }

        public DataTable GetAllStation()
        {
            return dpicdb.GetAllStation();
        }

        public bool UpdateFileStation(string fileid, List<string> stationidlist)
        {
            dpicdb.UpdateStationHeadXY(CreateUpdateStationSqlstr(fileid, stationidlist));
            if (dpicdb.DelFileStationByFileID(fileid))
            {
                for (int i = 0; i < stationidlist.Count; i++)
                {
                    if (!dpicdb.InsertIntoFileStation(fileid, stationidlist[i]))
                        return false;
                }
            }
            return true;
        }

        public bool UpdateFileStation_Wizard(string fileid, List<string> stationidlist)
        {
            dpicdb.UpdateStationHeadXY(CreateUpdateStationSqlstr(fileid, stationidlist));
            if (dpicdb.DelAllFileStation())
            {
                for (int i = 0; i < stationidlist.Count; i++)
                {
                    if (!dpicdb.InsertIntoFileStation(fileid, stationidlist[i]))
                        return false;
                }
            }
            return true;
        }

        private string CreateUpdateStationSqlstr(string fileid, List<string> stationidlist)
        {
            string values = string.Empty;
            string sqlstr = string.Empty;
            foreach (string str in stationidlist)
            {
                values = values + str + ",";
            }
            if (values.Length > 0)
            {
                values = values.Substring(0, values.Length - 1);
                sqlstr = string.Format("update Station_Head_Info set stationheadx=0, stationheady=0 where " +
                                            "stationheadid in (select stationheadid from G_File_Station where fileid={0} and " +
                                            "stationheadid not in (" + values + "))", fileid);
            }
            else
            {
                sqlstr = string.Format("update Station_Head_Info set stationheadx=0, stationheady=0 where " +
                                            "stationheadid in (select stationheadid from G_File_Station where fileid={0})", fileid);
            }
            return sqlstr;
        }

        public DataTable GetStationInfoByFileID(string fileid)
        {
            return dpicdb.GetStationInfoByFileID(fileid);
        }


        public DataTable GetAllInStationInfoByFileID()
        {
            return dpicdb.GetAllInStationInfoByFileID();
        }

        public DataTable GetNotInStationInfoByFileID()
        {
            return dpicdb.GetNotInStationInfoByFileID();
        }

        public DataTable GetStationInfo()
        {
            return dpicdb.GetStationInfo();
        }

        public DataTable GetStationHeadByFileID(string fileid)
        {
            return dpicdb.GetStationHeadByFileID(fileid);
        }

        public string DelRoute(string fileid)
        {
            return dpicdb.DelRoute(fileid);
        }

        public string InsertIntoRoute(PointF from, PointF to, int length, string Fileid, int id)
        {
            string strfrom = from.X.ToString() + "," + from.Y.ToString();
            string strto = to.X.ToString() + "," + to.Y.ToString();
            return dpicdb.InsertIntoRoute(strfrom, strto, length, Fileid, id);
        }

        public int GetMaxRouteID()
        {
            try
            {
                return dpicdb.GetMaxRouteID();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool HasConfigRoutePoint(string fileid)
        {
            return dpicdb.HasConfigRoutePoint(fileid);
        }

        /// <summary>
        /// 将路径点组合成轨迹线
        /// </summary>
        /// <param name="form">弹出窗体对象</param>
        /// <param name="pgb">进度条对象</param>
        /// <param name="fileid">地图IP</param>
        /// <returns>返回值</returns>
        public string ProductRoutePoint(System.Windows.Forms.Form form, System.Windows.Forms.ProgressBar pgb, string fileid)
        {
            try
            {
                if (this.GetNumOfRoute(fileid) > 0)
                {
                    //DateTime dt = DateTime.Now;
                  
                    this.DelAllPoint(fileid);
                    List<ZzhaStation> list = zzhastationdal.GetAllStations();
                    if (list.Count > 0)
                    {

                        //Czlt-2010-10-29 注销
                        //Hashtable ht = this.GetRouteTable(list, form, pgb, fileid);

                        //Czlt-2010-10-29 优化轨迹生成                
                        Hashtable ht = CzltGetRouteTable(list, form, pgb, fileid);
                        //DateTime dt2 = DateTime.Now;
                        //TimeSpan ts = dt2 - dt;
                        //timeLon = ts.Milliseconds;
                        if (ht.Count > 0)
                        {
                            #region Czlt-2011-02-14 注销
                            //float step = 100 / (float)ht.Count;
                            //float value = 0;
                            //List<string> savelist = new List<string>();
                            //string savestring = "begin ";
                            //int id = dpicdb.GetMaxPointID();
                            //foreach (DictionaryEntry de in ht)
                            //{
                            //    form.Refresh();
                            //    string pointid = de.Key.ToString();
                            //    string[] routepoints = ((RouteLength)de.Value).RouteList.Split('|');
                            //    for (int i = 0; i < routepoints.Length; i++)
                            //    {
                            //        string[] xy = routepoints[i].Split(',');
                            //        //savestring = savestring + this.InsertPoint(pointid, double.Parse(xy[0]), double.Parse(xy[1]), fileid);
                            //        string tempstring = this.InsertPoint(pointid, double.Parse(xy[0]), double.Parse(xy[1]), fileid, id);
                            //        id = id + 2;
                            //        if ((savestring + tempstring).Length > 9000000)
                            //        {
                            //            savestring = savestring + " end";
                            //            string temp = savestring;
                            //            savelist.Add(temp);
                            //            savestring = "begin ";
                            //        }
                            //        else
                            //        {
                            //            savestring = savestring + tempstring;
                            //        }
                            //    }
                            //    value += step;
                            //    pgb.Value = Convert.ToInt32(value);
                            //}
                            //savestring = savestring + " end";
                            //savelist.Add(savestring);
                            //zzhastationdal.SavePoint(savelist);
                            //DateTime dt3 = DateTime.Now;
                            //TimeSpan ts2 = dt3- dt2;
                            //timeLon += ts2.Milliseconds;
                            #endregion

                            //Czlt-2011-01-28 批量插入SQL语句优化
                            SqlBulkInsert(ht, fileid);
                            return "生成路径点成功!";
                        }
                        else
                        {
                            File.WriteAllText("D:\\CzltPicPoint1.txt", "生成的轨迹点集合为空!ht.Count=" + ht.Count, Encoding.Unicode);
                            return "生成路径点失败";
                        }
                    }
                    else
                    {
                        return "基站尚未配置";
                    }
                }
                else
                {
                    return "路径尚未配置";
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText("D:\\CzltPicPoint2.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"\r\t 生成失败原因!\r\n" + ex.Message, Encoding.Unicode);
                return "生成路径点失败";
            }
        }

        public Hashtable GetRouteTable(List<ZzhaStation> stationlist, System.Windows.Forms.Form form, System.Windows.Forms.ProgressBar pgb, string fileid)
        {
            Hashtable roulentable = new Hashtable();
            Hashtable stationmap = new ZzhaStationDAL().GetStationAddress();
            List<RouteModel> routelist = this.GetAllRoute(fileid);
            float value = 0;
            float step = 100 / (float)stationlist.Count;
            for (int i = 0; i < stationlist.Count - 1; i++)
            {
                form.Refresh();
                SerachRoute(roulentable, routelist, stationlist[i].Position, 0, stationlist[i].Position, stationlist[i].Position, stationmap);
                value += step;
                pgb.Value = Convert.ToInt32(value);
            }
            return roulentable;
        }

        private void SerachRoute(Hashtable roulentable, List<RouteModel> routelist, string route, int length, string from, string oldfrom, Hashtable stationmap)
        {
            string newroute = route;
            int newlength = length;
            for (int i = 0; i < routelist.Count; i++)
            {
                if (routelist[i].From == from)
                {
                    if (!newroute.Contains(routelist[i].To))
                    {
                        //double oldaddress = Convert.ToDouble(stationmap[oldfrom]);
                        //double newaddress = Convert.ToDouble(stationmap[routelist[i].To]);
                        if (Convert.ToDouble(stationmap[routelist[i].To]) > Convert.ToDouble(stationmap[oldfrom]))
                        {
                            //一个可能值
                            string key = stationmap[oldfrom] + "," + stationmap[routelist[i].To];
                            if (roulentable.ContainsKey(key))
                            {
                                //有重复值
                                if (((RouteLength)roulentable[key]).Length > (newlength + routelist[i].RouteLength))
                                {
                                    //一个新值
                                    roulentable[key] = new RouteLength(newroute + "|" + routelist[i].To, newlength + routelist[i].RouteLength);
                                }
                            }
                            else
                            {
                                //没有重复值  添加新值
                                roulentable[key] = new RouteLength(newroute + "|" + routelist[i].To, newlength + routelist[i].RouteLength);
                            }
                        }
                        string tempnewroute = newroute + "|" + routelist[i].To;
                        int tempnewlength = newlength + routelist[i].RouteLength;
                        SerachRoute(roulentable, routelist, tempnewroute, tempnewlength, routelist[i].To, oldfrom, stationmap);
                    }
                }
            }
        }

        public List<KJ128NModel.RouteModel> GetAllRoute(string fileid)
        {
            return dpicdb.GetAllRoute(fileid);
        }

        public void DelAllPoint(string fileid)
        {
            dpicdb.DelAllPoint(fileid);
        }

        public string InsertPoint(string pointid, double x, double y, string fileid, int id)
        {
            return dpicdb.InsertPoint(pointid, x, y, fileid, id);
        }

        public int GetMaxPointID()
        {
            try
            {
                return dpicdb.GetMaxPointID();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetNumOfRoute(string fileid)
        {
            return dpicdb.GetNumOfRoute(fileid);
        }

        #region[配置文件操作]
        public DataTable GetAllFileName()
        {
            return dpicdb.GetAllFileName();
        }

        public bool ExitsFileName(string filename)
        {
            return dpicdb.ExitsFileName(filename);
        }

        public void AddFile(string filename, byte[] xmlbyte, string fileid)
        {
            dpicdb.AddFile(filename, xmlbyte, fileid);
        }

        public void UpdateFile(string filename, byte[] xmlbyte, string fileid)
        {
            dpicdb.UpdateFile(filename, xmlbyte, fileid);
        }

        public DataTable GetXmlByFileName(string filename)
        {
            return dpicdb.GetXmlByFileName(filename);
        }

        public void RemoveFile(string filename)
        {
            dpicdb.RemoveFile(filename);
        }
        #endregion

        public DataTable GetStationHeadPlaceByFileID(string fileid)
        {
            return dpicdb.GetStationHeadPlaceByFileID(fileid);
        }

        /// <summary>
        /// 根据人员ID 起始时间和结束时间得到该人员的历史轨迹
        /// </summary>
        /// <param name="id">人员ID</param>
        /// <param name="startdate">起始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <returns>信息表</returns>
        public List<string> GetRouteInfoByEmpID(string id, string startdate, string enddate, int fileid,out string strMessage)
        {
            //DataTable oldDt = grt.GetRouteByUserID(int.Parse(id), startdate, enddate);
            string sdate = DateTime.Parse(startdate).ToString("yyyy-MM-dd HH:mm:ss");
            DataTable oldDt = dpicdb.GetRouteByUserID(int.Parse(id), sdate, enddate, fileid);
            if (oldDt != null)
            {
                if (oldDt.Rows.Count > 0)
                {
                    //string empname = oldDt.Rows[0][12].ToString() + ":" + oldDt.Rows[0][2].ToString();
                    //Czlt-2012-04-20 给out变量赋值 卡号-姓名
                    strMessage = oldDt.Rows[0].ItemArray[0].ToString() + "-" + oldDt.Rows[0].ItemArray[2].ToString()+":";
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
                            //DataTable dt = grt.GetRoutePointByID(towid, isdesc);
                            DataTable dt = dpicdb.GetRoutePointByID(towid, isdesc, fileid.ToString());
                            if (dt.Rows.Count != 0)
                            {
                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    routepoint = routepoint + dt.Rows[j]["x"].ToString() + "," + dt.Rows[j]["y"].ToString() + "|";
                                }
                            }
                            else
                            {
                                //throw new Exception("路径尚未配置,或者配置的路径不符合要求,请检查...");
                                //Czlt-2011-03-08-没有路径时添加
                                string strPath = string.Empty;

                                
                                if (isdesc)
                                {
                                    strPath = GetWayByStaIDT(xy2.ToString("F1"), xy1.ToString("F1"), fileid.ToString());
                                    //GetWayByStaID(xy2.ToString("F1"), xy1.ToString("F1"), fileid.ToString());
                                }
                                else
                                {
                                    strPath = GetWayByStaIDT(xy1.ToString("F1"), xy2.ToString("F1"), fileid.ToString());
                                   // GetWayByStaID(xy1.ToString("F1"), xy2.ToString("F1"), fileid.ToString());

                                }

                                if (strPath.Equals(""))
                                {
                                    //Czlt-2012-04-20 将有问题的路径记录下来
                                    strMessage += "["+towid + "];";
                                    //throw new Exception("路径尚未配置,或者配置的路径不符合要求,请检查...");
                                }
                                else
                                {
                                    routepoint = routepoint + strPath;
                                }
                            }
                            if (oldDt.Rows[i]["StationPlace"].ToString() != "")
                            {
                                //routepoint = routepoint + oldDt.Rows[i]["StationX"].ToString() + "," + oldDt.Rows[i]["StationY"] + "|";
                                address = address + oldDt.Rows[i]["StationPlace"].ToString() + "|";
                                stationpoint = stationpoint + oldDt.Rows[i]["StationX"].ToString() + "," + oldDt.Rows[i]["StationY"] + "|";
                                date = date + oldDt.Rows[i]["InStationTime"].ToString() + "|" + oldDt.Rows[i]["OutStationTime"].ToString() + "|";
                                //date = date + oldDt.Rows[i]["InStationTime"].ToString() + "|";
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
                strMessage = ":";
                return null;
            }
            strMessage = ":";
            return null;
        }

        private void SearchWhile(Hashtable roulentable, List<RouteModel> routelist, string route, int length, string from, string oldfrom, Hashtable stationmap)
        {
            Stack<MultiRecord> RouteStack = new Stack<MultiRecord>();
            MultiRecord Record = null;
            List<RouteModel> PointRoute = SearchPoint(from, route, routelist);
            if (PointRoute.Count > 0)
            {
                Record = new MultiRecord(route, length, from, oldfrom, PointRoute);
                RouteStack.Push(Record);
                while (true)
                {
                    if (Record.NextRoute())
                    {
                        RouteModel temproute = Record.IndexRouteModel;
                        if (Convert.ToDouble(stationmap[temproute.To]) > Convert.ToDouble(stationmap[oldfrom]))
                        {
                            //一个可能值
                            string key = stationmap[oldfrom] + "," + stationmap[temproute.To];
                            if (roulentable.ContainsKey(key))
                            {
                                //有重复值
                                if (((RouteLength)roulentable[key]).Length > (Record.Length + temproute.RouteLength))
                                {
                                    //一个新值
                                    roulentable[key] = new RouteLength(Record.Route + "|" + temproute.To, Record.Length + temproute.RouteLength);
                                }
                            }
                            else
                            {
                                //没有重复值  添加新值
                                roulentable[key] = new RouteLength(Record.Route + "|" + temproute.To, Record.Length + temproute.RouteLength);
                            }
                        }
                        string tempnewroute = Record.Route + "|" + temproute.To;
                        int tempnewlength = Record.Length + temproute.RouteLength;
                        List<RouteModel> newroutepoint = SearchPoint(temproute.To, tempnewroute, routelist);
                        if (newroutepoint.Count > 0)
                        {
                            MultiRecord newrecord = new MultiRecord(tempnewroute, tempnewlength, temproute.To, oldfrom, newroutepoint);
                            RouteStack.Push(newrecord);
                            Record = newrecord;
                        }

                    }
                    else
                    {
                        if (RouteStack.Count > 0)
                        {
                            Record = RouteStack.Pop();
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }

        private List<RouteModel> SearchPoint(string from, string route, List<RouteModel> routelist)
        {
            List<RouteModel> list = new List<RouteModel>();
            for (int i = 0; i < routelist.Count; i++)
            {
                if (routelist[i].From == from && (!route.Contains(routelist[i].To)))
                {
                    list.Add(routelist[i]);
                }
            }
            return list;
        }

        public bool StationExitsByFileIDandStationPlace(string fileid, string stationheadplace)
        {
            return dpicdb.StationExitsByFileIDandStationPlace(fileid, stationheadplace);
        }

        public DataTable GetStationPositionByFileID(string fileid)
        {
            return dpicdb.GetStationPositionByFileID(fileid);
        }

        public DataTable GetRouteInfoPositionByFileID(string fileid)
        {
            return dpicdb.GetRouteInfoPositionByFileID(fileid);
        }

        public DataTable GetColor()
        {
            if (HaveColorSet())
            {
                return dpicdb.GetColorSet();
            }
            else
            {
                dpicdb.DelColor();
                InsertDefaultColor();
                return dpicdb.GetColorSet();
            }
        }

        public bool HaveColorSet()
        {
            return dpicdb.HaveColorSet();
        }

        public void InsertColor(int colorid, string color)
        {
            dpicdb.InsertColor(colorid, color);
        }

        private void InsertDefaultColor()
        {
            dpicdb.InsertColor(1, Color.Red.ToArgb().ToString());
            dpicdb.InsertColor(2, Color.Red.ToArgb().ToString());
            dpicdb.InsertColor(3, Color.Red.ToArgb().ToString());
        }

        public void UpdateColor(int colorid, string color)
        {
            dpicdb.UpdateColor(colorid, color);
        }



        #region 【Czlt-2010-10-27-优化轨迹生成方法】
        private string fromTemp;
        private bool FindConvert(RouteModel rm)
        {
            if (rm.From.Equals(fromTemp))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 生成路径点集合的哈希表 
        /// </summary>
        /// <param name="stationlist"></param>
        /// <param name="form"></param>
        /// <param name="pgb"></param>
        /// <param name="fileid"></param>
        /// <returns></returns>
        public Hashtable CzltGetRouteTable(List<ZzhaStation> stationlist, System.Windows.Forms.Form form, System.Windows.Forms.ProgressBar pgb, string fileid)
        {
            Hashtable nowRoulentable = new Hashtable();
            Hashtable roulentable = new Hashtable();
            Hashtable stationmap = new ZzhaStationDAL().GetStationAddress();
            List<RouteModel> routelist = this.GetAllRoute(fileid);
            float value = 0;
            float step = 100 / (float)stationlist.Count;
            for (int i = 0; i < stationlist.Count - 1; i++)
            {
                form.Refresh();
                CzltSerachRoute(roulentable, routelist, stationlist[i].Position, 0, stationlist[i].Position, stationlist[i].Position, stationmap);
                value += step;
                pgb.Value = Convert.ToInt32(value);
            }


            if (roulentable.Count > 0)
            {
                nowRoulentable = GetHashStation(roulentable, stationlist, form, pgb, step);

            }

            return nowRoulentable;
        }


        /// <summary>
        /// 优化第一步:点点成线.
        /// </summary>
        /// <param name="roulentable"></param>
        /// <param name="routelist"></param>
        /// <param name="route"></param>
        /// <param name="length"></param>
        /// <param name="from"></param>
        /// <param name="oldfrom"></param>
        /// <param name="stationmap"></param>
        private void CzltSerachRoute(Hashtable roulentable, List<RouteModel> routelist, string route, int length, string from, string oldfrom, Hashtable stationmap)
        {
            string newroute = route;
            int newlength = length;
            fromTemp = from;
            List<RouteModel> routelist1 = routelist.FindAll(new Predicate<RouteModel>(FindConvert));
            for (int i = 0; i < routelist1.Count; i++)
            {
                if (!newroute.Contains(routelist1[i].To))
                {
                    string tempnewroute = string.Empty;
                    int tempnewlength = 0;
                    if (stationmap[routelist1[i].To] != null)
                    {
                        if (Convert.ToDouble(stationmap[routelist1[i].To]) > Convert.ToDouble(stationmap[oldfrom]))
                        {
                            //一个可能值
                            string key = stationmap[oldfrom] + "," + stationmap[routelist1[i].To];
                            if (roulentable.ContainsKey(key))
                            {
                                //有重复值
                                if (((RouteLength)roulentable[key]).Length > (newlength + routelist1[i].RouteLength))
                                {
                                    //一个新值
                                    roulentable[key] = new RouteLength(newroute + "|" + routelist1[i].To, newlength + routelist1[i].RouteLength);
                                }
                            }
                            else
                            {
                                //没有重复值  添加新值
                                roulentable[key] = new RouteLength(newroute + "|" + routelist1[i].To, newlength + routelist1[i].RouteLength);
                            }
                            tempnewroute = newroute + "|" + routelist1[i].To;
                            tempnewlength = newlength + routelist1[i].RouteLength;
                        }
                        continue;
                    }

                    tempnewroute = newroute + "|" + routelist1[i].To;
                    tempnewlength = newlength + routelist1[i].RouteLength;
                    CzltSerachRoute(roulentable, routelist, tempnewroute, tempnewlength, routelist1[i].To, oldfrom, stationmap);
                }
            }

        }


        /// <summary>
        /// 获取站点
        /// </summary>
        /// <param name="hashStation"></param>
        /// <param name="stationlist"></param>
        /// <returns></returns>
        private Hashtable GetHashStation(Hashtable hashStation, List<ZzhaStation> stationlist, System.Windows.Forms.Form form, System.Windows.Forms.ProgressBar pgb, float step)
        {
            float value = step;
            Hashtable hashNewStation = new Hashtable();
            Hashtable haNewStationAddress = new Hashtable();
            haNewStationAddress = (Hashtable)hashStation.Clone();
            hashNewStation = (Hashtable)haNewStationAddress.Clone();
            for (int i = stationlist.Count - 1; i >= 0; i--)
            {
                for (int j = stationlist.Count - 1; j >= 0; j--)
                {
                    if (Convert.ToDouble(stationlist[j].StationAddressNum) > Convert.ToDouble(stationlist[i].StationAddressNum))
                    {
                        //路径列表中是否存在该路径,存在则下一个读卡分站的路径
                        if (hashNewStation.ContainsKey(stationlist[i].StationAddressNum + "," + stationlist[j].StationAddressNum))
                        {
                            continue;
                        }
                        haNewStationAddress = SerachHashRoute(hashNewStation, (Hashtable)haNewStationAddress.Clone(), "", 0, "", stationlist[i].StationAddressNum, stationlist[i].StationAddressNum, stationlist[j].StationAddressNum);
                    }
                    else
                    {
                        break;
                    }
                }
                //hashNewStation = RouteAppend1(hashNewStation, stationlist[i].StationAddressNum);
                //hashNewStation = RouteAppend(hashNewStation, stationlist[i].StationAddressNum);
                haNewStationAddress = (Hashtable)hashNewStation.Clone();


                if (i < (stationlist.Count - 2))
                {
                    value += step;
                    pgb.Value = Convert.ToInt32(value);
                }

            }

            for (int m = stationlist.Count - 1; m >= 0; m--)
            {
                hashNewStation = RouteAppend1((Hashtable)hashNewStation.Clone(), stationlist[m].StationAddressNum);
            }
            for (int n = stationlist.Count - 1; n >= 0; n--)
            {
                hashNewStation = RouteAppend((Hashtable)hashNewStation.Clone(), stationlist[n].StationAddressNum);
            }

            //Hashtable hasTemp = new Hashtable();
            //while (true)
            //{
            //    hasTemp = (Hashtable)hashNewStation.Clone();
            //    for (int m = stationlist.Count - 1; m >= 0; m--)
            //    {
            //        hashNewStation = RouteAppend1((Hashtable)hashNewStation.Clone(), stationlist[m].StationAddressNum);
            //    }
            //    for (int n = stationlist.Count - 1; n >= 0; n--)
            //    {
            //        hashNewStation = RouteAppend((Hashtable)hashNewStation.Clone(), stationlist[n].StationAddressNum);
            //    }
            //    if (hashNewStation.Count == hasTemp.Count)
            //    {
            //        break;
            //    }
            //}
            return hashNewStation;
        }

        /// <summary>
        /// 近一步对线进行优化
        /// </summary>
        /// <param name="rolenttable"></param>
        /// <param name="routelist"></param>
        /// <param name="route"></param>
        /// <param name="length"></param>
        /// <param name="lastFrom"></param>
        /// <param name="lastTo"></param>
        /// <param name="startfrom"></param>
        /// <param name="endTo"></param>
        /// <returns></returns>
        private Hashtable SerachHashRoute(Hashtable rolenttable, Hashtable routelist, string route, int length, string lastFrom, string lastTo, string startfrom, string endTo)
        {
            string newRoute = string.Empty;
            int newLength = 0;
            if (Convert.ToDouble(lastTo) <= Convert.ToDouble(endTo))
            {
                if (routelist.ContainsKey(lastTo + "," + endTo))
                {
                    RouteLength rtFisrt = (RouteLength)routelist[lastTo + "," + endTo];
                    string strFirstKey = lastFrom + "," + endTo;
                    if (!rolenttable.ContainsKey(strFirstKey))
                    {
                        if (string.IsNullOrEmpty(route))
                            route = rtFisrt.RouteList;
                        else
                            route = route + "|" + rtFisrt.RouteList;
                        length += rtFisrt.Length;
                        rolenttable[strFirstKey] = new RouteLength(route, length);
                    }
                    else
                    {
                        RouteLength rtFirstNewTemp = (RouteLength)rolenttable[strFirstKey];

                        if (rtFirstNewTemp.Length > (length + rtFisrt.Length))
                        {
                            if (string.IsNullOrEmpty(route))
                                route = rtFisrt.RouteList;
                            else
                                route = route + "|" + rtFisrt.RouteList;
                            length = length + rtFisrt.Length;
                            rolenttable[strFirstKey] = new RouteLength(route, length);
                        }
                    }

                }
                else
                {
                    if (string.IsNullOrEmpty(route))
                    {
                        foreach (string strKey in routelist.Keys)
                        {
                            string[] skeys = strKey.Split(',');
                            //该次线段的起始位置和上次的线段的结尾一致
                            if (skeys[0].Equals(lastTo))
                            {
                                newRoute = route;
                                newLength = length;
                                //获取两点间的线段
                                RouteLength rt = (RouteLength)routelist[strKey];
                                if (Convert.ToDouble(skeys[1]) > Convert.ToDouble(startfrom))
                                {
                                    //设置该次线段的键值
                                    string strKeyTemp = startfrom + "," + skeys[1];

                                    //临时路径表中不存在该路径
                                    if (!rolenttable.ContainsKey(strKeyTemp))
                                    {
                                        if (string.IsNullOrEmpty(newRoute))
                                            newRoute = rt.RouteList;
                                        else
                                            newRoute = newRoute + "|" + rt.RouteList;
                                        newLength += rt.Length;
                                        rolenttable[strKeyTemp] = new RouteLength(newRoute, newLength);
                                    }
                                    else//临时路径表中存在该路径
                                    {
                                        RouteLength rtNewTemp = (RouteLength)rolenttable[strKeyTemp];

                                        if (rtNewTemp.Length > (newLength + rt.Length))
                                        {
                                            if (string.IsNullOrEmpty(newRoute))
                                                newRoute = rt.RouteList;
                                            else
                                                newRoute = newRoute + "|" + rt.RouteList;
                                            newLength = newLength + rt.Length;
                                            rolenttable[strKeyTemp] = new RouteLength(newRoute, newLength);
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(newRoute))
                                                newRoute = rtNewTemp.RouteList;
                                            else
                                                newRoute = newRoute + "|" + rtNewTemp.RouteList;
                                            newLength = newLength + rtNewTemp.Length;
                                        }

                                    }

                                    if (skeys[1].Equals(endTo) || Convert.ToDouble(skeys[1]) > Convert.ToDouble(endTo))
                                    {
                                        continue;
                                    }
                                    SerachHashRoute(rolenttable, routelist, newRoute, newLength, skeys[0], skeys[1], startfrom, endTo);
                                }
                            }
                        }
                    }
                }
            }
            return (Hashtable)rolenttable.Clone();
        }


        /// <summary>
        /// 近一步对线进行优化
        /// </summary>
        /// <param name="rolenttable"></param>
        /// <param name="routelist"></param>
        /// <param name="route"></param>
        /// <param name="length"></param>
        /// <param name="lastFrom"></param>
        /// <param name="lastTo"></param>
        /// <param name="startfrom"></param>
        /// <param name="endTo"></param>
        /// <param name="pCount"></param>
        /// <returns></returns>
        private Hashtable SerachHashRoute(Hashtable rolenttable, Hashtable routelist, string route, int length, string lastFrom, string lastTo, string startfrom, string endTo,int pCount)
        {
            string newRoute = string.Empty;
            int newLength = 0;
            if (Convert.ToDouble(lastTo) <= Convert.ToDouble(endTo))
            {
                if (routelist.ContainsKey(lastTo + "," + endTo))
                {
                    RouteLength rtFisrt = (RouteLength)routelist[lastTo + "," + endTo];
                    string strFirstKey = lastFrom + "," + endTo;
                    if (!rolenttable.ContainsKey(strFirstKey))
                    {
                        if (string.IsNullOrEmpty(route))
                            route = rtFisrt.RouteList;
                        else
                            route = route + "|" + rtFisrt.RouteList;
                        length += rtFisrt.Length;
                        rolenttable[strFirstKey] = new RouteLength(route, length);
                    }
                    else
                    {
                        RouteLength rtFirstNewTemp = (RouteLength)rolenttable[strFirstKey];

                        if (rtFirstNewTemp.Length > (length + rtFisrt.Length))
                        {
                            if (string.IsNullOrEmpty(route))
                                route = rtFisrt.RouteList;
                            else
                                route = route + "|" + rtFisrt.RouteList;
                            length = length + rtFisrt.Length;
                            rolenttable[strFirstKey] = new RouteLength(route, length);
                        }
                    }

                }
                else
                {
                    if (string.IsNullOrEmpty(route))
                    {
                        foreach (string strKey in routelist.Keys)
                        {
                            string[] skeys = strKey.Split(',');
                            //该次线段的起始位置和上次的线段的结尾一致
                            if (skeys[0].Equals(lastTo))
                            {
                                newRoute = route;
                                newLength = length;
                                //获取两点间的线段
                                RouteLength rt = (RouteLength)routelist[strKey];
                                if (Convert.ToDouble(skeys[1]) > Convert.ToDouble(startfrom))
                                {
                                    //设置该次线段的键值
                                    string strKeyTemp = startfrom + "," + skeys[1];

                                    //临时路径表中不存在该路径
                                    if (!rolenttable.ContainsKey(strKeyTemp))
                                    {
                                        if (string.IsNullOrEmpty(newRoute))
                                            newRoute = rt.RouteList;
                                        else
                                            newRoute = newRoute + "|" + rt.RouteList;
                                        newLength += rt.Length;
                                        rolenttable[strKeyTemp] = new RouteLength(newRoute, newLength);
                                    }
                                    else//临时路径表中存在该路径
                                    {
                                        RouteLength rtNewTemp = (RouteLength)rolenttable[strKeyTemp];

                                        if (rtNewTemp.Length > (newLength + rt.Length))
                                        {
                                            if (string.IsNullOrEmpty(newRoute))
                                                newRoute = rt.RouteList;
                                            else
                                                newRoute = newRoute + "|" + rt.RouteList;
                                            newLength = newLength + rt.Length;
                                            rolenttable[strKeyTemp] = new RouteLength(newRoute, newLength);
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(newRoute))
                                                newRoute = rtNewTemp.RouteList;
                                            else
                                                newRoute = newRoute + "|" + rtNewTemp.RouteList;
                                            newLength = newLength + rtNewTemp.Length;
                                        }

                                    }

                                    if (skeys[1].Equals(endTo) || Convert.ToDouble(skeys[1]) > Convert.ToDouble(endTo))
                                    {
                                        continue;
                                    }

                                    if (pCount >= 10)
                                        continue;

                                    SerachHashRoute(rolenttable, routelist, newRoute, newLength, skeys[0], skeys[1], startfrom, endTo,pCount);
                                }
                            }
                        }
                    }
                }
            }
            return (Hashtable)rolenttable.Clone();
        }

        /// <summary>
        /// 将线段连成长线-即完整的轨迹线(正方向)
        /// </summary>
        /// <param name="nowRoulentable"></param>
        /// <param name="strStationAddress"></param>
        /// <returns></returns>
        private Hashtable RouteAppend(Hashtable nowRoulentable, string strStationAddress)
        {
            Hashtable htNew = new Hashtable();
            htNew = (Hashtable)nowRoulentable.Clone();

            foreach (string strKey1 in nowRoulentable.Keys)
            {
                string[] strTemp1 = strKey1.Split(',');
                if (strTemp1[0].Equals(strStationAddress))
                {
                    foreach (string strKey2 in nowRoulentable.Keys)
                    {
                        if (!nowRoulentable[strKey1].Equals(nowRoulentable[strKey2]))
                        {
                            string[] strTemp2 = strKey2.Split(',');
                            #region [起始头相同处理]
                            if (strTemp1[0].Equals(strTemp2[0]) && strTemp1[0].Equals(strStationAddress))
                            {
                                if (Convert.ToDouble(strTemp1[1]) < Convert.ToDouble(strTemp2[1]))
                                {
                                    RouteLength rl1 = (RouteLength)nowRoulentable[strKey1];
                                    RouteLength rl2 = (RouteLength)nowRoulentable[strKey2];
                                    string strKey3 = strTemp1[1] + "," + strTemp2[1];
                                    if (!nowRoulentable.ContainsKey(strKey3))
                                    {
                                        if (!htNew.ContainsKey(strKey3))
                                        {
                                            string[] strRouteTemps = rl1.RouteList.Split('|');
                                            string strRouteTemp = string.Empty;
                                            for (int i = strRouteTemps.Length - 1; i >= 0; i--)
                                            {
                                                strRouteTemp += strRouteTemps[i] + "|";
                                            }
                                            htNew[strKey3] = new RouteLength(strRouteTemp + rl2.RouteList, rl1.Length + rl2.Length);
                                        }
                                        else
                                        {
                                            RouteLength rl3 = (RouteLength)htNew[strKey3];
                                            if (rl3.Length > (rl1.Length + rl2.Length))
                                            {
                                                string[] strRouteTemps = rl1.RouteList.Split('|');
                                                string strRouteTemp = string.Empty;
                                                for (int i = strRouteTemps.Length - 1; i >= 0; i--)
                                                {
                                                    strRouteTemp += strRouteTemps[i] + "|";
                                                }
                                                htNew[strKey3] = new RouteLength(strRouteTemp + rl2.RouteList, rl1.Length + rl2.Length);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        RouteLength rl5 = (RouteLength)nowRoulentable[strKey3];
                                        if (!htNew.ContainsKey(strKey3))
                                        {
                                            if (rl5.Length > (rl1.Length + rl2.Length))
                                            {
                                                string[] strRouteTemps = rl1.RouteList.Split('|');
                                                string strRouteTemp = string.Empty;
                                                for (int i = strRouteTemps.Length - 1; i >= 0; i--)
                                                {
                                                    strRouteTemp += strRouteTemps[i] + "|";
                                                }
                                                htNew[strKey3] = new RouteLength(strRouteTemp + rl2.RouteList, rl1.Length + rl2.Length);
                                            }
                                            else
                                            {
                                                htNew[strKey3] = rl5;
                                            }
                                        }
                                        else
                                        {
                                            RouteLength rl6 = (RouteLength)htNew[strKey3];
                                            if (rl6.Length > (rl1.Length + rl2.Length))
                                            {
                                                string[] strRouteTemps = rl1.RouteList.Split('|');
                                                string strRouteTemp = string.Empty;
                                                for (int i = strRouteTemps.Length - 1; i >= 0; i--)
                                                {
                                                    strRouteTemp += strRouteTemps[i] + "|";
                                                }
                                                htNew[strKey3] = new RouteLength(strRouteTemp + rl2.RouteList, rl1.Length + rl2.Length);
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                }
            }
            return (Hashtable)htNew.Clone();
        }

        /// <summary>
        /// 将线段连成长线-即完整的轨迹线(反方向)
        /// </summary>
        /// <param name="nowRoulentable"></param>
        /// <param name="strStationAddress"></param>
        /// <returns></returns>
        private Hashtable RouteAppend1(Hashtable nowRoulentable, string strStationAddress)
        {
            Hashtable htNew = new Hashtable();
            htNew = (Hashtable)nowRoulentable.Clone();
            foreach (string strKey1 in nowRoulentable.Keys)
            {
                string[] strTemp1 = strKey1.Split(',');
                if (strTemp1[1].Equals(strStationAddress))
                {
                    foreach (string strKey2 in nowRoulentable.Keys)
                    {
                        if (!nowRoulentable[strKey1].Equals(nowRoulentable[strKey2]))
                        {
                            string[] strTemp2 = strKey2.Split(',');
                            #region [结尾相同处理]
                            if (strTemp1[1].Equals(strTemp2[1]) && strTemp1[1].Equals(strStationAddress))
                            {
                                if (Convert.ToDouble(strTemp1[0]) < Convert.ToDouble(strTemp2[0]))
                                {
                                    RouteLength rl1 = (RouteLength)nowRoulentable[strKey1];
                                    RouteLength rl2 = (RouteLength)nowRoulentable[strKey2];
                                    string strKey4 = strTemp1[0] + "," + strTemp2[0];
                                    if (!nowRoulentable.ContainsKey(strKey4))
                                    {
                                        if (!htNew.ContainsKey(strKey4))
                                        {
                                            string[] strRouteTemps = rl2.RouteList.Split('|');
                                            string strRouteTemp = string.Empty;
                                            for (int i = strRouteTemps.Length - 1; i >= 0; i--)
                                            {
                                                strRouteTemp += "|" + strRouteTemps[i];
                                            }
                                            htNew[strKey4] = new RouteLength(rl1.RouteList + strRouteTemp, rl1.Length + rl2.Length);
                                        }
                                        else
                                        {
                                            RouteLength rl4 = (RouteLength)htNew[strKey4];
                                            if (rl4.Length > (rl1.Length + rl2.Length))
                                            {
                                                string[] strRouteTemps = rl2.RouteList.Split('|');
                                                string strRouteTemp = string.Empty;
                                                for (int i = strRouteTemps.Length - 1; i >= 0; i--)
                                                {
                                                    strRouteTemp += "|" + strRouteTemps[i];
                                                }
                                                htNew[strKey4] = new RouteLength(rl1.RouteList + strRouteTemp, rl1.Length + rl2.Length);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        RouteLength rl5 = (RouteLength)nowRoulentable[strKey4];
                                        if (!htNew.ContainsKey(strKey4))
                                        {
                                            if (rl5.Length > (rl1.Length + rl2.Length))
                                            {
                                                string[] strRouteTemps = rl2.RouteList.Split('|');
                                                string strRouteTemp = string.Empty;
                                                for (int i = strRouteTemps.Length - 1; i >= 0; i--)
                                                {
                                                    strRouteTemp += "|" + strRouteTemps[i];
                                                }
                                                htNew[strKey4] = new RouteLength(rl1.RouteList + strRouteTemp, rl1.Length + rl2.Length);
                                            }
                                            else
                                            {
                                                htNew[strKey4] = rl5;
                                            }
                                        }
                                        else
                                        {
                                            RouteLength rl6 = (RouteLength)htNew[strKey4];
                                            if (rl6.Length > (rl1.Length + rl2.Length))
                                            {
                                                string[] strRouteTemps = rl2.RouteList.Split('|');
                                                string strRouteTemp = string.Empty;
                                                for (int i = strRouteTemps.Length - 1; i >= 0; i--)
                                                {
                                                    strRouteTemp += "|" + strRouteTemps[i];
                                                }
                                                htNew[strKey4] = new RouteLength(rl1.RouteList + strRouteTemp, rl1.Length + rl2.Length);
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                }
            }
            return (Hashtable)htNew.Clone();
        }


        #endregion

        #region 【Czlt-2011-01-28 - 优化批量插入语句】

        /// <summary>
        /// 组织信息并保存数据
        /// </summary>
        /// <param name="form">窗体对象</param>
        /// <param name="pgb">进度值</param>
        /// <param name="ht">hashtable</param>
        /// <param name="fileid">图的ID</param>
        private void SqlBulkInsert(Hashtable ht, string fileid)
        {
            if (ht.Count > 0)
            {
                //int indexHtCount = ht.Count;
                //float step = 100 / (float)ht.Count;
                //float value = 0;
                DataTable dt = GetDataTableMode();
                //Czlt-2013-03-20 注销
               // int id = dpicdb.GetMaxPointID();
                //Czlt-2013-03-20 修改
                int id = dpicdb.GetMaxPointID()+1;
               
                foreach (DictionaryEntry de in ht)
                {
                    //form.Refresh();
                    string pointid = de.Key.ToString();
                    string[] strM = pointid.Split(',');
                    string pointName = strM[1].ToString() + "," + strM[0].ToString();

                    //Czlt-2013-03-20 注销 (强转出错)
                    //string[] routepoints = ((RouteLength)de.Value).RouteList.Split('|');
                    //Czlt-2013-03-20 优化
                    string[] routepoints = null;
                    if (de.Value.ToString().Equals("KJ128NDBTable.RouteLength"))
                    {
                         routepoints = ((KJ128NDBTable.RouteLength)(de.Value)).RouteList.ToString().Split('|');
                    }
                    else
                    {
                        routepoints = de.Value.ToString().Split('|');
 
                    }
                    for (int i = 0; i < routepoints.Length; i++)
                    {
                        string[] xy = routepoints[i].Split(',');

                        DataRow dr = dt.NewRow();
                        dr[0] = id;
                        dr[1] = pointid;
                        dr[2] = Convert.ToDecimal(xy[0]);
                        dr[3] = Convert.ToDecimal(xy[1]);
                        dr[4] = Convert.ToInt32(fileid);
                        dt.Rows.Add(dr);
                     
                        DataRow dr2 = dt.NewRow();
                        dr2[0] = id+1;
                        dr2[1] = pointName;
                        dr2[2] = Convert.ToDecimal(xy[0]);
                        dr2[3] = Convert.ToDecimal(xy[1]);
                        dr2[4] = Convert.ToInt32(fileid);
                        dt.Rows.Add(dr2);

                        //
                        if (dt.Rows.Count >= 5000 )
                        {
                            dpicdb.SqlBulkCopyInsert(dt);
                            dt.Clear();
                            dt = GetDataTableMode();
                        }
                        id = id + 2;
                    }
                    //value += step;
                    //if (indexHtCount < (ht.Count - 1))
                    //{
                    //    pgb.Value = Convert.ToInt32(value);
                    //}
                }

                dpicdb.SqlBulkCopyInsert(dt);
                //pgb.Value = Convert.ToInt32(value);

            }

        }

        /// <summary>
        /// 和数据库类型对应DataTable数据集
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTableMode()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("ID") });
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("PointID") });
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("x") });
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("y") });
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("FileID") });
            return dt;
        }


      

        #endregion

        #region 【Czlt-2011-03-04 轨迹生成】

        /// <summary>
        /// 寻找路径点
        /// </summary>
        /// <param name="strStationAddress"></param>
        /// <param name="endStationAddress"></param>
        /// <param name="fileid"></param>
        /// <returns></returns>
        private string GetWayByStaIDT(string strStationAddress, string endStationAddress, string fileid)
        {
            string strPath = string.Empty;
            Hashtable ht = new Hashtable();
            List<ZzhaStation> list = zzhastationdal.GetAllStations();
            Hashtable stationmap = new ZzhaStationDAL().GetStationAddress();
            List<RouteModel> routelist = this.GetAllRoute(fileid);
            List<RouteLength> newRouteLengthList = new List<RouteLength>();
            List<RouteLength> oldRouteLengthList = new List<RouteLength>();
           // Hashtable nowRoulentable = CzltGetRouteTable(list, new Form(), new ProgressBar(), fileid);
            for (int i = 0; i < list.Count - 1; i++)
            {
               // form.Refresh();
                CzltSerachRoute(oldRouteLengthList, routelist, list[i].Position, 0, list[i].Position, list[i].Position, stationmap);
                //value += step;
                //pgb.Value = Convert.ToInt32(value);
            }
            bool tempFlag1 = false;
            SerachRoute20110226(oldRouteLengthList, newRouteLengthList, strStationAddress, endStationAddress, "", strStationAddress, "", 0, "", 0, false, ref tempFlag1);

            if (newRouteLengthList.Count > 0)
            {
                for (int j = 0; j < newRouteLengthList.Count; j++)
                {
                    ht.Add(newRouteLengthList[j].Key, newRouteLengthList[j].RouteList);
                    strPath = strPath + newRouteLengthList[j].RouteList + "|";
                }
            }

            //插入数据库
            SqlBulkInsert(ht, fileid);        


             return strPath;
        }

        /// <summary>
        /// 生成第一步 相邻分站之间连成线
        /// </summary>
        /// <param name="roulentable"></param>
        /// <param name="routelist"></param>
        /// <param name="route"></param>
        /// <param name="length"></param>
        /// <param name="from"></param>
        /// <param name="oldfrom"></param>
        /// <param name="stationmap"></param>
        private void CzltSerachRoute(List<RouteLength> roulentable, List<RouteModel> routelist, string route, int length, string from, string oldfrom, Hashtable stationmap)
        {
            string newroute = route;
            int newlength = length;
            fromTemp = from;
            List<RouteModel> routelist1 = routelist.FindAll(new Predicate<RouteModel>(FindConvert));
            for (int i = 0; i < routelist1.Count; i++)
            {
                if (!newroute.Contains(routelist1[i].To))
                {
                    string tempnewroute = string.Empty;
                    int tempnewlength = 0;
                    if (stationmap[routelist1[i].To] != null)
                    {
                        //一个可能值
                        string key = stationmap[oldfrom] + "," + stationmap[routelist1[i].To];
                        _findKeyEquals = key;
                        RouteLength rlEquals = roulentable.Find(new Predicate<RouteLength>(FindKeyRoulenEquals));
                        if (rlEquals != null)//有重复值
                        {
                            if (rlEquals.RountStationCount == 1)//两点直接连线
                            {
                                if (rlEquals.Length > (newlength + routelist1[i].RouteLength))
                                {
                                    int indexRoulenTable = roulentable.IndexOf(rlEquals);
                                    roulentable[indexRoulenTable].Length = newlength + routelist1[i].RouteLength;
                                    roulentable[indexRoulenTable].RouteList = newroute + "|" + routelist1[i].To;
                                }
                            }
                        }
                        else//没有重复值  添加新值
                        {
                            rlEquals = new RouteLength(key, newroute + "|" + routelist1[i].To, newlength + routelist1[i].RouteLength, 1, key);
                            roulentable.Add(rlEquals);
                        }
                        tempnewroute = newroute + "|" + routelist1[i].To;
                        tempnewlength = newlength + routelist1[i].RouteLength;
                        continue;
                    }

                    tempnewroute = newroute + "|" + routelist1[i].To;
                    tempnewlength = newlength + routelist1[i].RouteLength;
                    CzltSerachRoute(roulentable, routelist, tempnewroute, tempnewlength, routelist1[i].To, oldfrom, stationmap);
                }
            }
        }


        /// <summary>
        /// 根据起始点查找轨迹线
        /// </summary>
        /// <param name="strStationAddress"></param>
        /// <param name="endStationAddress"></param>
        /// <param name="fileid"></param>
        /// <returns></returns>
        public string GetWayByStaID(string strStationAddress, string endStationAddress, string fileid)
        {
            string strPath = "";
            Hashtable ht = new Hashtable();
            List<ZzhaStation> list = zzhastationdal.GetAllStations();
            Hashtable nowRoulentable = CzltGetRouteTable(list, new Form(), new ProgressBar(), fileid);

            ht = GetFrontPoint(nowRoulentable, strStationAddress, endStationAddress);
            ht = GetReversePoint(ht, nowRoulentable, strStationAddress, endStationAddress);

            //插入数据库
            SqlBulkInsert(ht, fileid);


            return strPath;

        }

        /// <summary>
        /// 正方向寻找轨迹点
        /// </summary>
        /// <param name="nowRoulentable"></param>
        /// <param name="strStationAddress"></param>
        /// <param name="endStationAddress"></param>
        /// <returns></returns>
        private Hashtable GetFrontPoint(Hashtable nowRoulentable, string strStationAddress, string endStationAddress)
        {
            Hashtable ht = new Hashtable();

            foreach (string strKey1 in nowRoulentable.Keys)
            {
                string[] strTemp1 = strKey1.Split(',');
                if (strTemp1[0].Equals(strStationAddress))
                {
                    foreach (string strKey2 in nowRoulentable.Keys)
                    {
                        if (!nowRoulentable[strKey1].Equals(nowRoulentable[strKey2]))
                        {
                            string[] strTemp2 = strKey2.Split(',');
                            #region [起始头相同处理]
                            if (strTemp1[0].Equals(strTemp2[0]) && strTemp1[0].Equals(endStationAddress))
                            {
                                if (Convert.ToDouble(strTemp1[1]) < Convert.ToDouble(strTemp2[1]))
                                {
                                    RouteLength rl1 = (RouteLength)nowRoulentable[strKey1];
                                    RouteLength rl2 = (RouteLength)nowRoulentable[strKey2];
                                    string strKey3 = strTemp1[1] + "," + strTemp2[1];
                                    if (!nowRoulentable.ContainsKey(strKey3))
                                    {
                                        if (!ht.ContainsKey(strKey3))
                                        {
                                            string[] strRouteTemps = rl1.RouteList.Split('|');
                                            string strRouteTemp = string.Empty;
                                            for (int i = strRouteTemps.Length - 1; i >= 0; i--)
                                            {
                                                strRouteTemp += strRouteTemps[i] + "|";
                                            }
                                            ht[strKey3] = new RouteLength(strRouteTemp + rl2.RouteList, rl1.Length + rl2.Length);
                                        }
                                        else
                                        {
                                            RouteLength rl3 = (RouteLength)ht[strKey3];
                                            if (rl3.Length > (rl1.Length + rl2.Length))
                                            {
                                                string[] strRouteTemps = rl1.RouteList.Split('|');
                                                string strRouteTemp = string.Empty;
                                                for (int i = strRouteTemps.Length - 1; i >= 0; i--)
                                                {
                                                    strRouteTemp += strRouteTemps[i] + "|";
                                                }
                                                ht[strKey3] = new RouteLength(strRouteTemp + rl2.RouteList, rl1.Length + rl2.Length);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        RouteLength rl5 = (RouteLength)nowRoulentable[strKey3];
                                        if (!ht.ContainsKey(strKey3))
                                        {
                                            if (rl5.Length > (rl1.Length + rl2.Length))
                                            {
                                                string[] strRouteTemps = rl1.RouteList.Split('|');
                                                string strRouteTemp = string.Empty;
                                                for (int i = strRouteTemps.Length - 1; i >= 0; i--)
                                                {
                                                    strRouteTemp += strRouteTemps[i] + "|";
                                                }
                                                ht[strKey3] = new RouteLength(strRouteTemp + rl2.RouteList, rl1.Length + rl2.Length);
                                            }
                                            else
                                            {
                                                ht[strKey3] = rl5;
                                            }
                                        }
                                        else
                                        {
                                            RouteLength rl6 = (RouteLength)ht[strKey3];
                                            if (rl6.Length > (rl1.Length + rl2.Length))
                                            {
                                                string[] strRouteTemps = rl1.RouteList.Split('|');
                                                string strRouteTemp = string.Empty;
                                                for (int i = strRouteTemps.Length - 1; i >= 0; i--)
                                                {
                                                    strRouteTemp += strRouteTemps[i] + "|";
                                                }
                                                ht[strKey3] = new RouteLength(strRouteTemp + rl2.RouteList, rl1.Length + rl2.Length);
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                }
            }

            return ht;
 
        }

        /// <summary>
        /// 反方向寻找路径点
        /// </summary>
        /// <param name="oldHt"></param>
        /// <param name="nowRoulentable"></param>
        /// <param name="strStationAddress"></param>
        /// <param name="endStationAddress"></param>
        /// <returns></returns>
        private Hashtable GetReversePoint(Hashtable oldHt, Hashtable nowRoulentable, string strStationAddress, string endStationAddress)
        {
            Hashtable ht = new Hashtable();
            ht = oldHt;
            foreach (string strKey1 in nowRoulentable.Keys)
            {
                string[] strTemp1 = strKey1.Split(',');
                if (strTemp1[1].Equals(strStationAddress))
                {
                    foreach (string strKey2 in nowRoulentable.Keys)
                    {
                        if (!nowRoulentable[strKey1].Equals(nowRoulentable[strKey2]))
                        {
                            string[] strTemp2 = strKey2.Split(',');
                            #region [结尾相同处理]
                            if (strTemp1[1].Equals(strTemp2[1]) && strTemp1[1].Equals(endStationAddress))
                            {
                                if (Convert.ToDouble(strTemp1[0]) < Convert.ToDouble(strTemp2[0]))
                                {
                                    RouteLength rl1 = (RouteLength)nowRoulentable[strKey1];
                                    RouteLength rl2 = (RouteLength)nowRoulentable[strKey2];
                                    string strKey4 = strTemp1[0] + "," + strTemp2[0];
                                    if (!nowRoulentable.ContainsKey(strKey4))
                                    {
                                        if (!ht.ContainsKey(strKey4))
                                        {
                                            string[] strRouteTemps = rl2.RouteList.Split('|');
                                            string strRouteTemp = string.Empty;
                                            for (int i = strRouteTemps.Length - 1; i >= 0; i--)
                                            {
                                                strRouteTemp += "|" + strRouteTemps[i];
                                            }
                                            ht[strKey4] = new RouteLength(rl1.RouteList + strRouteTemp, rl1.Length + rl2.Length);
                                        }
                                        else
                                        {
                                            RouteLength rl4 = (RouteLength)ht[strKey4];
                                            if (rl4.Length > (rl1.Length + rl2.Length))
                                            {
                                                string[] strRouteTemps = rl2.RouteList.Split('|');
                                                string strRouteTemp = string.Empty;
                                                for (int i = strRouteTemps.Length - 1; i >= 0; i--)
                                                {
                                                    strRouteTemp += "|" + strRouteTemps[i];
                                                }
                                                ht[strKey4] = new RouteLength(rl1.RouteList + strRouteTemp, rl1.Length + rl2.Length);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        RouteLength rl5 = (RouteLength)nowRoulentable[strKey4];
                                        if (!ht.ContainsKey(strKey4))
                                        {
                                            if (rl5.Length > (rl1.Length + rl2.Length))
                                            {
                                                string[] strRouteTemps = rl2.RouteList.Split('|');
                                                string strRouteTemp = string.Empty;
                                                for (int i = strRouteTemps.Length - 1; i >= 0; i--)
                                                {
                                                    strRouteTemp += "|" + strRouteTemps[i];
                                                }
                                                ht[strKey4] = new RouteLength(rl1.RouteList + strRouteTemp, rl1.Length + rl2.Length);
                                            }
                                            else
                                            {
                                                ht[strKey4] = rl5;
                                            }
                                        }
                                        else
                                        {
                                            RouteLength rl6 = (RouteLength)ht[strKey4];
                                            if (rl6.Length > (rl1.Length + rl2.Length))
                                            {
                                                string[] strRouteTemps = rl2.RouteList.Split('|');
                                                string strRouteTemp = string.Empty;
                                                for (int i = strRouteTemps.Length - 1; i >= 0; i--)
                                                {
                                                    strRouteTemp += "|" + strRouteTemps[i];
                                                }
                                                ht[strKey4] = new RouteLength(rl1.RouteList + strRouteTemp, rl1.Length + rl2.Length);
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                }
            }
            return ht;
        }



        #region 【2011-2-26】

        private static string _findKeyEquals;
        private static bool FindKeyRoulenEquals(RouteLength rl)
        {
            try
            {
                if (rl != null && rl.Key.Equals(_findKeyEquals))
                    return true;
            }
            catch (Exception ee)
            {
                string eemxx = ee.Message;
            }
            return false;
        }


        private static string _findKeyContains;
        private static bool FindKeyRoulenContains(RouteLength rl)
        {
            if (rl != null && rl.Key.Contains(_findKeyContains))
                return true;
            return false;
        }

        /// <summary>
        /// 2011-2-26
        /// </summary>
        /// <param name="pOldRouteLengthList"></param>
        /// <param name="pNewRouteLengthList"></param>
        /// <param name="startfrom"></param>
        /// <param name="lastFrom"></param>
        /// <param name="lastTo"></param>
        /// <param name="route"></param>
        /// <param name="length"></param>
        /// <param name="pRouteStationAddress"></param>
        /// <param name="rountStationCount"></param>
        /// <param name="pUpdateFlag"></param>
        /// <returns></returns>
        private bool SerachRoute20110226(List<RouteLength> pOldRouteLengthList, List<RouteLength> pNewRouteLengthList, string startfrom, string endTo, string lastFrom, string lastTo, string route, int length, string pRouteStationAddress, int rountStationCount, bool pUpdateFlag, ref bool pReturnFlag)
        {
            try
            {
                rountStationCount += 1;
                string newRoute = string.Empty;
                int newLength = 0;
                string routeStationAddress = string.Empty;

                _findKeyEquals = startfrom + "," + endTo;
                RouteLength sRoute = pNewRouteLengthList.Find(new Predicate<RouteLength>(FindKeyRoulenEquals));
                if (sRoute != null && sRoute.Length < length)
                    return pUpdateFlag;

                _findKeyEquals = lastTo + "," + endTo;
                RouteLength findRoute = pOldRouteLengthList.Find(new Predicate<RouteLength>(FindKeyRoulenEquals));
                if (findRoute != null)
                {
                    #region 【存在上次最后的基站 到 完结基站的路径】
                    if (!lastTo.Equals(startfrom))
                    {
                        routeStationAddress = pRouteStationAddress;
                        string strFinishKey = startfrom + "," + endTo;//完结键值
                        _findKeyEquals = strFinishKey;
                        RouteLength findFinishRoute = pOldRouteLengthList.Find(new Predicate<RouteLength>(FindKeyRoulenEquals));

                        if (findFinishRoute == null)//完结路径不存在
                        {
                            string[] strRounteAddresses1 = findRoute.RouteStationAddress.Split(',');
                            bool addressFlag1 = false;
                            if (strRounteAddresses1.Length > 1)
                            {
                                for (int mi = 1; mi < strRounteAddresses1.Length; mi++)
                                {
                                    if (!string.IsNullOrEmpty(strRounteAddresses1[mi]) && pRouteStationAddress.Contains(strRounteAddresses1[mi]))
                                    {
                                        addressFlag1 = true;
                                        break;
                                    }
                                }
                            }
                            if (!addressFlag1)
                            {
                                if (string.IsNullOrEmpty(route))
                                    route = findRoute.RouteList;
                                else
                                    route = route + "|" + findRoute.RouteList.Substring(findRoute.RouteList.IndexOf("|") + 1);

                                length += findRoute.Length;

                                routeStationAddress += "," + findRoute.RouteStationAddress.Substring(findRoute.RouteStationAddress.IndexOf(",") + 1);

                                findFinishRoute = new RouteLength(strFinishKey, route, length, rountStationCount, routeStationAddress);
                                pNewRouteLengthList.Add(findFinishRoute);
                                pUpdateFlag = true;
                                if (findRoute.RountStationCount > 1)
                                    pReturnFlag = true;
                            }
                        }
                        else
                        {
                            if (findFinishRoute.RountStationCount > 1)
                            {
                                if (findFinishRoute.Length > (length + findRoute.Length))
                                {
                                    if (string.IsNullOrEmpty(route))
                                        route = findRoute.RouteList;
                                    else
                                        route = route + "|" + findRoute.RouteList.Substring(findRoute.RouteList.IndexOf("|") + 1);
                                    length = length + findRoute.Length;
                                    routeStationAddress += "," + findRoute.RouteStationAddress.Substring(findRoute.RouteStationAddress.IndexOf(",") + 1);

                                    int finishIndex = pNewRouteLengthList.IndexOf(findFinishRoute);
                                    pNewRouteLengthList[finishIndex].Length = length;
                                    pNewRouteLengthList[finishIndex].RountStationCount = rountStationCount;
                                    pNewRouteLengthList[finishIndex].RouteList = route;
                                    pNewRouteLengthList[finishIndex].RouteStationAddress = routeStationAddress;
                                    pUpdateFlag = true;
                                    if (findRoute.RountStationCount > 1)
                                        pReturnFlag = true;
                                }
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    //查询上次最后的基站开头的路径线
                    _findKeyContains = lastTo + ",";
                    List<RouteLength> findAllRoute = pOldRouteLengthList.FindAll(new Predicate<RouteLength>(FindKeyRoulenContains));
                    if (findAllRoute != null && findAllRoute.Count > 0)//存在上次最后的基站开头的路径线
                    {
                        for (int i = 0; i < findAllRoute.Count; i++)//遍历上次最后的基站开头的路径线
                        {
                            RouteLength findRl = findAllRoute[i];
                            string[] skeys = findRl.Key.Split(',');//分割获取得到的键值
                            if (skeys[0].Equals(lastTo) && !skeys[1].Equals(lastFrom) && !skeys[1].Equals(startfrom))
                            {
                                newRoute = route;
                                newLength = length;
                                if (string.IsNullOrEmpty(pRouteStationAddress))
                                    routeStationAddress = skeys[0];
                                else
                                    routeStationAddress = pRouteStationAddress;

                                //生成新的唯一标示
                                string strNewKey = startfrom + "," + skeys[1];

                                if (findRl.RountStationCount > 1)//当前获取的路径不是最基础的线段
                                {
                                    //判断获取的线段中的分站点与当前路径中的分站点是否有重复
                                    string[] strRounteAddresses = findRl.RouteStationAddress.Split(',');
                                    bool addressFlag = false;
                                    if (strRounteAddresses.Length > 1)
                                    {
                                        for (int mi = 1; mi < strRounteAddresses.Length; mi++)
                                        {
                                            if (!string.IsNullOrEmpty(strRounteAddresses[mi]) && routeStationAddress.Contains(strRounteAddresses[mi]))
                                            {
                                                addressFlag = true;
                                                break;
                                            }
                                        }

                                        //没有重复
                                        if (!addressFlag)
                                        {
                                            _findKeyEquals = strNewKey;
                                            RouteLength rlNew = pNewRouteLengthList.Find(new Predicate<RouteLength>(FindKeyRoulenEquals));

                                            //临时存路径的内存是否存在该条路径
                                            if (rlNew == null)//不存在
                                            {
                                                if (string.IsNullOrEmpty(newRoute))
                                                    newRoute = findRl.RouteList;
                                                else
                                                    newRoute = newRoute + "|" + findRl.RouteList.Substring(findRl.RouteList.IndexOf("|") + 1);

                                                newLength += findRl.Length;

                                                routeStationAddress += "," + findRl.RouteStationAddress.Substring(findRl.RouteStationAddress.IndexOf(",") + 1);

                                                //rlNew = new RouteLength(strNewKey, newRoute, newLength, rountStationCount, routeStationAddress);
                                                //pNewRouteLengthList.Add(rlNew);
                                                //pUpdateFlag = true;
                                            }
                                            else//存在
                                            {
                                                routeStationAddress += "," + findRl.RouteStationAddress.Substring(findRl.RouteStationAddress.IndexOf(",") + 1);

                                                if (rlNew.RountStationCount > 1)
                                                {
                                                    if (rlNew.Length > (newLength + findRl.Length))
                                                    {
                                                        if (string.IsNullOrEmpty(newRoute))
                                                            newRoute = findRl.RouteList;
                                                        else
                                                            newRoute = newRoute + "|" + findRl.RouteList.Substring(findRl.RouteList.IndexOf("|") + 1);

                                                        newLength += findRl.Length;

                                                        int newIndex = pNewRouteLengthList.IndexOf(rlNew);
                                                        pNewRouteLengthList[newIndex].Length = newLength;
                                                        pNewRouteLengthList[newIndex].RouteList = newRoute;
                                                        pNewRouteLengthList[newIndex].RountStationCount = rountStationCount;
                                                        pNewRouteLengthList[newIndex].RouteStationAddress = routeStationAddress;
                                                        pUpdateFlag = true;
                                                    }
                                                    else
                                                        continue;
                                                }
                                                else
                                                {
                                                    if (rlNew.Length < (newLength + findRl.Length))
                                                        continue;

                                                    if (string.IsNullOrEmpty(newRoute))
                                                        newRoute = findRl.RouteList;
                                                    else
                                                        newRoute = newRoute + "|" + findRl.RouteList.Substring(findRl.RouteList.IndexOf("|") + 1);
                                                    newLength += findRl.Length;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (!routeStationAddress.Contains(skeys[1]))
                                    {
                                        _findKeyEquals = strNewKey;
                                        RouteLength rlNew1 = pNewRouteLengthList.Find(new Predicate<RouteLength>(FindKeyRoulenEquals));

                                        if (rlNew1 == null)//不存在
                                        {
                                            routeStationAddress += "," + skeys[1];
                                            if (string.IsNullOrEmpty(newRoute))
                                                newRoute = findRl.RouteList;
                                            else
                                                newRoute = newRoute + "|" + findRl.RouteList.Substring(findRl.RouteList.IndexOf("|") + 1);

                                            newLength += findRl.Length;

                                            //rlNew1 = new RouteLength(strNewKey, newRoute, newLength, rountStationCount, routeStationAddress);
                                            //pNewRouteLengthList.Add(rlNew1);
                                            //pUpdateFlag = true;
                                        }
                                        else//存在
                                        {
                                            routeStationAddress += "," + findRl.RouteStationAddress.Substring(findRl.RouteStationAddress.IndexOf(",") + 1);

                                            if (rlNew1.RountStationCount > 1)
                                            {
                                                if (rlNew1.Length > (newLength + findRl.Length))
                                                {
                                                    if (string.IsNullOrEmpty(newRoute))
                                                        newRoute = findRl.RouteList;
                                                    else
                                                        newRoute = newRoute + "|" + findRl.RouteList.Substring(findRl.RouteList.IndexOf("|") + 1);
                                                    newLength += findRl.Length;
                                                    int newIndex1 = pNewRouteLengthList.IndexOf(rlNew1);
                                                    pNewRouteLengthList[newIndex1].Length = newLength;
                                                    pNewRouteLengthList[newIndex1].RouteList = newRoute;
                                                    pNewRouteLengthList[newIndex1].RountStationCount = rountStationCount;
                                                    pNewRouteLengthList[newIndex1].RouteStationAddress = routeStationAddress;
                                                    pUpdateFlag = true;
                                                }
                                                else
                                                    continue;
                                            }
                                            else
                                            {
                                                if (rlNew1.Length < (newLength + findRl.Length))
                                                    continue;

                                                if (string.IsNullOrEmpty(newRoute))
                                                    newRoute = findRl.RouteList;
                                                else
                                                    newRoute = newRoute + "|" + findRl.RouteList.Substring(findRl.RouteList.IndexOf("|") + 1);
                                                newLength += findRl.Length;
                                            }
                                        }
                                    }
                                }

                                //超过10次循环下个路径段
                                if (rountStationCount >= 3)
                                    continue;

                                pUpdateFlag = SerachRoute20110226(pOldRouteLengthList, pNewRouteLengthList, startfrom, endTo, skeys[0], skeys[1], newRoute, newLength, routeStationAddress, rountStationCount, pUpdateFlag, ref pReturnFlag);
                                if (pReturnFlag)
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                string eeeee = ee.Message;
            }
            return pUpdateFlag;
        }
        #endregion

        #endregion

        #region 【Czlt-2011-06-14-获取本地图片图片日志文件】

        public void CztlGetMapBuffer()
        {
            string strPath = System.Windows.Forms.Application.StartupPath.ToString() + @"\MapPath.xml";
            if (!File.Exists(strPath))
            {
               // File.CreateText(strPath, Encoding.Unicode);
               // DataTable dtMap = 

            }
            else
            {
            }
        }

        #endregion

        #region【方法：Czlt-2011-12-10 修改时间】

        public void UpdateTime()
        {
            dpicdb.UpdateTime();
        }
        #endregion
    }
}
