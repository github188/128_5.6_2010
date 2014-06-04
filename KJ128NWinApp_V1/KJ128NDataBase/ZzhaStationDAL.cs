using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KJ128NModel;

namespace KJ128NDataBase
{
    public class ZzhaStationDAL
    {
        private DBAcess dba = new DBAcess();

        public List<ZzhaStation> GetAllStations()
        {
            List<ZzhaStation> list = new List<ZzhaStation>();

            string selectstr="select stationaddress,stationheadaddress,stationheadx,stationheady from Station_Head_Info order by stationaddress,stationheadaddress";
            //SqlDataReader dr = dba.GetDataReader(selectstr);
            DataTable dt = dba.GetDataSet(selectstr).Tables[0];
            //while (dr.Read())
            //{
            //    ZzhaStation zzhastation = new ZzhaStation();
            //    zzhastation.StationAddressNum = dr.GetInt32(0).ToString() + "." + dr.GetInt32(1).ToString();
            //    zzhastation.Position = Convert.ToString(dr.GetDouble(2)) + "," + Convert.ToString(dr.GetDouble(3));
            //    //zzhastation.Position = Convert.ToString(dr.GetDouble(2) + 25) + "," + Convert.ToString(dr.GetDouble(3) + 20);
            //    list.Add(zzhastation);
            //}
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ZzhaStation zzhastation = new ZzhaStation();
                //zzhastation.StationAddressNum = dr.GetInt32(0).ToString() + "." + dr.GetInt32(1).ToString();
                zzhastation.StationAddressNum = dt.Rows[i][0].ToString() + "." + dt.Rows[i][1].ToString();
                zzhastation.Position = Convert.ToString(dt.Rows[i][2]) + "," + Convert.ToString(dt.Rows[i][3]);
                //zzhastation.Position = Convert.ToString(dr.GetDouble(2) + 25) + "," + Convert.ToString(dr.GetDouble(3) + 20);
                list.Add(zzhastation);
            }
            return list;
        }

        public Hashtable GetStationAddress()
        {
            Hashtable hashtable = new Hashtable();
            string selectstr="select stationaddress,stationheadaddress,stationheadx,stationheady from Station_Head_Info order by stationaddress,stationheadaddress";
            DataTable dt = dba.GetDataSet(selectstr).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string address = dt.Rows[i][0].ToString() + "." + dt.Rows[i][1].ToString();
                //string point = Convert.ToString(dr.GetDouble(2) + 25) + "," + Convert.ToString(dr.GetDouble(3) + 20);
                string point = Convert.ToString(dt.Rows[i][2]) + "," + Convert.ToString(dt.Rows[i][3]);
                try
                {
                    hashtable.Add(point, address);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            return hashtable;
        }

        public bool DelAllPoint()
        {
            try
            {
                string delstr="DELETE FROM Points";
                if (dba.ExecuteSql(delstr) > 0)
                    return true;
                else
                    return false;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string InsertPoint(string pointid, double x, double y)
        {                           
            string insertstr=string.Format(" insert into points values('{0}',{1},{2}) ", pointid,x,y);
            return insertstr;   
        }

        public bool SavePoint(string savestr)
        {
            if (dba.ExecuteSql(savestr) > 0)
                return true;
            else
                return false;
        }

        public bool SavePoint(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (!(dba.ExecuteSql(list[i]) > 0))
                    return false;
            }
            return true;
        }
    }
}
