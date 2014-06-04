using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;
using System.Windows.Forms;


namespace KJ128NDBTable
{
    public class IpListDataSource_BAl
    {
        private IpListDataSource_DAl myipdal = new IpListDataSource_DAl();
        /// <summary>
        /// IPlist
        /// </summary>
        /// <returns></returns>
        public DataTable iplist()
        {
            return myipdal.Getlist();
        }
        public DataTable Getlistbyipid(string ipid)
        {
            return myipdal.Getlistbyipid(ipid);
        }
        public int addip(string ip, string port, string place)
        {
            return myipdal.addip(ip, port, place);


        }
        public DataTable stationbyip(string ip)
        {
            return myipdal.stationbyip(ip);
        }
        public DataTable getiplistbyip(string ip)
        {
            return myipdal.getiplistbyip(ip);
        }
        public int updateip(string ip, string port, string place, int id)
        {
            return myipdal.updateip(ip, port, place, id);
        }
        public int deleteip(int id)
        {
            return myipdal.deleteip(id);
        }
        public DataTable Getstationlist()
        {
            return myipdal.Getstationlist();

        }
        public DataTable Getstationlistnyipid(string ipid)
        {
            return myipdal.Getstationlistnyipid(ipid);
        }
        public DataSet getipdrop()
        {
            return myipdal.getipdrop();
        }
        public DataSet getstationdrop()
        {
            return myipdal.getstationdrop();
        }
        public int updatestation(int stationid,int ipid)
        {
            return myipdal.updatestation(stationid, ipid);

        }
        public string stationplace(int stationid)
        {
            return myipdal.stationplace(stationid);

        }
        public string ipplace(int ipid)
        {
            return myipdal.ipplace(ipid);

        }
        public int delstation(int stationid)
        {
            return myipdal.delstation(stationid);
        }
        public DataTable guanlian_tree()
        {
            return myipdal.guanlian_tree();

        }
        public DataTable station_tree()
        {
            return myipdal.station_tree();
        }
        public DataTable GetTcpIpConfig()
        {
            return myipdal.GetTcpIpConfig();
        }

        #region【方法：Czlt-2011-12-10 修改配置时间】
        public void UpdateTime()
        {
            myipdal.UpdateTime();
        }

        #endregion
    }
}
