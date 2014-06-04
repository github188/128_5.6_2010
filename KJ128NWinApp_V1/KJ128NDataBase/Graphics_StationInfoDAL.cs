using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NModel;

namespace KJ128NDataBase
{
    /// <summary>
    /// 图形系统中基站类
    /// </summary>
    public class Graphics_StationInfoDAL
    {
        #region[申明]
        private DBAcess dba = new DBAcess();
        #endregion

        #region[周志豪]
        /// <summary>
        /// 得到所有探头信息
        /// </summary>
        /// <returns>信息表</returns>
        public DataTable GetStationInfo()
        {
            string selectstring = "select * from A_Graphics_StationHeadState";
            DataSet ds = dba.GetDataSet(selectstring);
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }

        /// <summary>
        /// 将一条路径信息插入路径表
        /// </summary>
        /// <param name="from">路径起始点</param>
        /// <param name="to">路径结束点</param>
        /// <param name="length">路径长度</param>
        /// <returns>是否成功</returns>
        public string InsertIntoRoute(string from,string to,int length)
        {
            string insertstring1 = string.Format(" insert into route (routefrom,routeto,routelength) values('{0}','{1}',{2}) ", from, to, length);
            string insertstring2 = string.Format(" insert into route (routefrom,routeto,routelength) values('{0}','{1}',{2}) ", to, from, length);
            return insertstring1 + insertstring2;
        }

        /// <summary>
        /// 删除所有的路径
        /// </summary>
        public string DelRoute()
        {
            string delstring = " delete from route ";
            return delstring;
        }

        /// <summary>
        /// 根据探头名称修改探头位置
        /// </summary>
        /// <param name="stationheadx">探头位置坐标X</param>
        /// <param name="stationheady">探头位置坐标Y</param>
        /// <param name="stationheadplace">探头名称</param>
        /// <returns>是否成功</returns>
        public string UpdateStationInfo(string stationheadx, string stationheady,string stationheadplace)
        {
            string updatestring = string.Format(" update Station_Head_Info set stationheadx={0},stationheady={1} where stationheadplace='{2}' ", stationheadx, stationheady, stationheadplace);
            dba.ExecuteSql(updatestring);
            return updatestring;
        }

        public bool SavePointAndRoute(string savestr)
        {
            if (dba.ExecuteSql(savestr) > 0)
                return true;
            else
                return false;
        }
        #endregion
    }


    public class MultiRecord
    {
        private string _route;

        public string Route
        {
            get { return _route; }
            set { _route = value; }
        }

        private int _length;

        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        private string _from;

        public string From
        {
            get { return _from; }
            set { _from = value; }
        }

        private string _oldFrom;

        public string OldFrom
        {
            get { return _oldFrom; }
            set { _oldFrom = value; }
        }

        private List<RouteModel> _RouteList;

        public List<RouteModel> RouteList
        {
            get { return _RouteList; }
            set { _RouteList = value; }
        }

        public RouteModel IndexRouteModel
        {
            get { return RouteList[this.index]; }
        }

        private int index = -1;

        public MultiRecord()
        { }

        public MultiRecord(string route, int length, string from, string oldfrom, List<RouteModel> routelist)
        {
            this.Route = route;
            this.Length = length;
            this.From = from;
            this.OldFrom = oldfrom;
            this.RouteList = routelist;
        }

        public bool NextRoute()
        {
            index++;
            if (index < this.RouteList.Count)
                return true;
            else
                return false;
        }
    }
}
