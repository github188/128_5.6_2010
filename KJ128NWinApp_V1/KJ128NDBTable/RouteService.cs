using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NModel;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class RouteService
    {
        public List<KJ128NModel.RouteModel> GetAllRoute()
        {
            return new KJ128NDataBase.RouteDAL().GetAllRoute();
        }

        //public string ProductRoute(DataSet ds)
        //{
        //    string route = "";
        //    if (ds.Tables[0].Rows.Count > 1)
        //    {
        //        for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
        //        {
        //            string from = Convert.ToString(int.Parse(ds.Tables[0].Rows[i]["StationX"].ToString()) + 25) + "," + Convert.ToString(int.Parse(ds.Tables[0].Rows[i]["StationY"].ToString()) + 20);
        //            string to = Convert.ToString(int.Parse(ds.Tables[0].Rows[i + 1]["StationX"].ToString()) + 25) + "," + Convert.ToString(int.Parse(ds.Tables[0].Rows[i + 1]["StationY"].ToString()) + 20);
        //            if (route == "")
        //            {
        //                route = route + GetRoutePath(from, to);
        //            }
        //            else 
        //            {
        //                string routetemp = GetRoutePath(from, to);
        //                route = route + "," + routetemp.Substring(routetemp.IndexOf("||"));
        //            }
        //        }
        //    }
        //    return route;
        //}
        public string ProductRoutePoint(System.Windows.Forms.Form form,System.Windows.Forms.ProgressBar pgb)
        {
            if (new RouteDAL().GetNumOfRoute() > 0)
            {
                ZzhaStationDAL zzhastationdal = new ZzhaStationDAL();
                zzhastationdal.DelAllPoint();
                List<ZzhaStation> list = zzhastationdal.GetAllStations();
                if (list.Count > 0)
                {
                    //for (int i = 0; i < list.Count; i++)
                    //{
                    //    for (int j = i + 1; j < list.Count; j++)
                    //    {
                    //        string routepath = GetRoutePath(list[i].Position, list[j].Position);
                    //        string[] point = routepath.Split('|');
                    //        for (int k = 0; k < point.Length; k++)
                    //        {
                    //            string[] xy = point[k].Split(',');
                    //            if (!new ZzhaStationDAL().InsertPoint(list[i].StationAddressNum + "," + list[j].StationAddressNum, double.Parse(xy[0]), double.Parse(xy[1])))
                    //                flag = false;
                    //        }
                    //    }
                    //}
                    Hashtable ht = this.GetRouteTable(list,form, pgb);
                    if (ht.Count > 0)
                    {
                        //float step = 100 /(float) ht.Count;
                        //float value = 0;
                        string savestring = "begin ";
                        foreach (DictionaryEntry de in ht)
                        {
                            string pointid = de.Key.ToString();
                            string[] routepoints = ((RouteLength)de.Value).RouteList.Split('|');                            
                            for (int i = 0; i < routepoints.Length; i++)
                            {
                                string[] xy = routepoints[i].Split(',');
                                savestring = savestring + zzhastationdal.InsertPoint(pointid, double.Parse(xy[0]), double.Parse(xy[1]));
                            }
                            //value += step;
                            //pgb.Value = Convert.ToInt32(value);
                        }
                        savestring = savestring + " end";
                        zzhastationdal.SavePoint(savestring);
                        return "生成路径点成功";
                    }
                    else
                    {
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


        public string ProductRoutePoint()
        {
            if (new RouteDAL().GetNumOfRoute() > 0)
            {
                ZzhaStationDAL zzhastationdal = new ZzhaStationDAL();
                zzhastationdal.DelAllPoint();
                List<ZzhaStation> list = zzhastationdal.GetAllStations();
                if (list.Count > 0)
                {
                    //for (int i = 0; i < list.Count; i++)
                    //{
                    //    for (int j = i + 1; j < list.Count; j++)
                    //    {
                    //        string routepath = GetRoutePath(list[i].Position, list[j].Position);
                    //        string[] point = routepath.Split('|');
                    //        for (int k = 0; k < point.Length; k++)
                    //        {
                    //            string[] xy = point[k].Split(',');
                    //            if (!new ZzhaStationDAL().InsertPoint(list[i].StationAddressNum + "," + list[j].StationAddressNum, double.Parse(xy[0]), double.Parse(xy[1])))
                    //                flag = false;
                    //        }
                    //    }
                    //}
                    Hashtable ht=this.GetRouteTable(list);
                    if (ht.Count > 0)
                    {
                        foreach(DictionaryEntry de in ht)
                        {
                            string pointid = de.Key.ToString();
                            string[] routepoints = ((RouteLength)de.Value).RouteList.Split('|');
                            for (int i = 0; i < routepoints.Length; i++)
                            {
                                string[] xy = routepoints[i].Split(',');
                                zzhastationdal.InsertPoint(pointid, double.Parse(xy[0]), double.Parse(xy[1]));
                            }
                        }
                        return "生成路径点成功";
                    }
                    else
                    {
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

        public string GetRoutePath(string from, string to)
        {
            List<RouteModel> routelist = this.GetAllRoute();
            List<RouteLength> routelengthlist = new List<RouteLength>();
            List<RouteModel> newroute = new List<RouteModel>();
            SerachNext(routelengthlist, routelist, from, 0, from, to);
            if (routelengthlist.Count > 0)
            {
                int minlen = routelengthlist[0].Length;
                for (int i = 1; i < routelengthlist.Count; i++)
                {
                    if (routelengthlist[i].Length < minlen)
                        minlen = routelengthlist[i].Length;
                }
                for (int i = 0; i < routelengthlist.Count; i++)
                {
                    if (routelengthlist[i].Length == minlen)
                        return routelengthlist[i].RouteList;
                }
            }
            return "";
        }

        private void SerachNext(List<RouteLength> roulengthlist, List<RouteModel> routelist, string route, int length, string from, string to)
        {
            string newroute = route;
            int newlength = length;
            for (int i = 0; i < routelist.Count; i++)
            {
                if (routelist[i].From == from)
                {
                    if (routelist[i].To == to)
                    {
                        newroute = newroute + "|" + routelist[i].To;
                        newlength += routelist[i].RouteLength;
                        RouteLength r = new RouteLength();
                        r.RouteList = newroute;
                        r.Length = newlength;
                        roulengthlist.Add(r);
                    }
                    else
                    {
                        if (checkpointin(newroute, routelist[i].To))
                        {
                            string tempnewroute = newroute + "|" + routelist[i].To;
                            int tempnewlength = newlength + routelist[i].RouteLength;
                            SerachNext(roulengthlist, routelist, tempnewroute, tempnewlength, routelist[i].To, to);
                        }
                    }
                }
            }
        }

        private void SerachRoute(Hashtable roulentable, List<RouteModel> routelist, string route, int length, string from, string oldfrom,Hashtable stationmap)
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
                            string key = stationmap[oldfrom] + "," +stationmap[routelist[i].To];
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

        public Hashtable GetRouteTable(List<ZzhaStation> stationlist)
        {
            Hashtable roulentable = new Hashtable();
            Hashtable stationmap = new ZzhaStationDAL().GetStationAddress();
            List<RouteModel> routelist = this.GetAllRoute();
            for (int i = 0; i < stationlist.Count - 1; i++)
            {
                SerachRoute(roulentable, routelist, stationlist[i].Position, 0, stationlist[i].Position, stationlist[i].Position, stationmap);
            }
            return roulentable;
        }

        public Hashtable GetRouteTable(List<ZzhaStation> stationlist, System.Windows.Forms.Form form, System.Windows.Forms.ProgressBar pgb)
        {
            Hashtable roulentable = new Hashtable();
            Hashtable stationmap = new ZzhaStationDAL().GetStationAddress();
            List<RouteModel> routelist = this.GetAllRoute();
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


        private bool checkpointin(string route, string point)
        {
            string[] points = route.Split('|');
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i] == point)
                    return false;
            }
            return true;
        }
    }

    public class RouteLength
    {

        #region 【Czlt-2011-12-10 属性】

        public RouteLength(string routelist, int length, int rountStationCount, string routeStationAddress)
        {
            this._routeList = routelist;
            this._length = length;
            this._rountStationCount = rountStationCount;
            this._routeStationAddress = routeStationAddress;
        }

        public RouteLength(string key, string routelist, int length, int rountStationCount, string routeStationAddress)
        {
            _key = key;
            this._routeList = routelist;
            this._length = length;
            this._rountStationCount = rountStationCount;
            this._routeStationAddress = routeStationAddress;
        }

        private string _key;
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        private int _rountStationCount;
        public int RountStationCount
        {
            get { return _rountStationCount; }
            set { _rountStationCount = value; }
        }

        private string _routeStationAddress;
        public string RouteStationAddress
        {
            get { return _routeStationAddress; }
            set { _routeStationAddress = value; }
        }
        #endregion



        public RouteLength()
        { }
        public RouteLength(string routelist,int length)
        {
            this.RouteList = routelist;
            this.Length = length;
        }
        private string _routeList;

        public string RouteList
        {
            get { return _routeList; }
            set { _routeList = value; }
        }
        private int _length;

        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }


    }
}
