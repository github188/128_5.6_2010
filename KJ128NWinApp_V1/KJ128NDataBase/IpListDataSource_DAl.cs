using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace KJ128NDataBase
{
    public class IpListDataSource_DAl
    {

        private DBAcess dba = new DBAcess();
        DbHelperSQL DB = new DbHelperSQL();
        public DataTable Getlist()
        {
            DataSet temp = new DataSet();

            try
            {
                temp = DB.Query("select ipid as 序号,place as 安装地址,ipaddress as IP地址,ipport as IP端口 from  TcpIPConfig");

                return temp.Tables[0];
            }
            catch (Exception ex)
            {
                return temp.Tables[0];
            }

        }
        public DataTable Getlistbyipid(string strWhere)
        {
            DataSet temp = new DataSet();
            if (strWhere.Trim().Equals(""))
            {
                strWhere = "1=1";
            }
            try
            {
                temp = DB.Query("select ipid,place as 安装地址,ipaddress as IP地址,ipport as IP端口 from  TcpIPConfig where " + strWhere);

                return temp.Tables[0];
            }
            catch (Exception ex)
            {
                return temp.Tables[0];
            }

        }

        public DataTable Getstationlist()
        {
            DataSet temp = new DataSet();

            try
            {
                temp = DB.Query("SELECT TcpIPConfig.ipid as 序号,TcpIPConfig.IPAddress as IP地址,TcpIPConfig.place as IP安装位置 , Station_Info.StationAddress as 传输分站号, Station_Info.StationPlace as 传输分站安装位置,Station_Info.Stationid  FROM Station_Info INNER JOIN   TcpIPConfig ON Station_Info.IPAddressID = TcpIPConfig.ipid");

                return temp.Tables[0];
            }
            catch (Exception ex)
            {
                return new DataTable();
            }

        }

        public DataTable Getstationlistnyipid(string strWhere)
        {
            DataSet temp = new DataSet();
            if (strWhere.Trim().Equals(""))
            {
                strWhere = "1=1";
            }
            try
            {
                temp = DB.Query("SELECT TcpIPConfig.ipid,TcpIPConfig.IPAddress as IP地址,TcpIPConfig.place as IP安装位置 , Station_Info.StationAddress as 传输分站号, Station_Info.StationPlace as 传输分站安装位置,Station_Info.Stationid  FROM Station_Info INNER JOIN   TcpIPConfig ON Station_Info.IPAddressID = TcpIPConfig.ipid where " + strWhere);

                return temp.Tables[0];
            }
            catch (Exception ex)
            {
                return new DataTable();
            }

        }

        public int deleteip(int id)
        {
            string procName = "proc_IpStationConfig_delete_txj";
            SqlParameter[] sqlParmeters ={
              
                new SqlParameter("ID",SqlDbType.Int)
              
            };
            sqlParmeters[0].Value = id;
          

            return dba.ExecuteSql(procName, sqlParmeters);
        }
        public int updateip(string ip, string port, string place,int id)
        {
            string procName = "proc_IpStationConfig_update_txj";
            SqlParameter[] sqlParmeters ={
                new SqlParameter("IPAddress",SqlDbType.NVarChar,20),
                new SqlParameter("IPPort",SqlDbType.Int),
                new SqlParameter("PLACE",SqlDbType.NVarChar,200),
                new SqlParameter("ID",SqlDbType.Int)
                
              
            };
            sqlParmeters[0].Value = ip;
            sqlParmeters[1].Value = port;
            sqlParmeters[2].Value = place;
            sqlParmeters[3].Value = id;

         


            return dba.ExecuteSql(procName, sqlParmeters);

        }
           public int addip(string ip, string port,string place)
             {
            string procName = "proc_IpStationConfig_add_txj";
            SqlParameter[] sqlParmeters ={
                new SqlParameter("IPAddress",SqlDbType.NVarChar,20),
                new SqlParameter("IPPort",SqlDbType.Int),
                new SqlParameter("PLACE",SqlDbType.NVarChar,200),
                new SqlParameter("@ID",SqlDbType.Int)
            };
            sqlParmeters[0].Value = ip;
            sqlParmeters[1].Value = port;
            sqlParmeters[2].Value = place;
            sqlParmeters[3].Value = ip.GetHashCode();
            

            return dba.ExecuteSql(procName, sqlParmeters);
           
            }
           public DataSet getipdrop()
           {
               return dba.GetDataSet("select ipid,convert(varchar(30),ipaddress) as ipaddress from TcpIPConfig");
           }
        /// <summary>
        /// 根据IP查询
        /// </summary>
           /// <param name="ip">ip</param>
        /// <returns></returns>
           public DataTable getiplistbyip(string ip)
           {
               return dba.GetDataSet("select place,ipaddress,ipport,ipid from   TcpIPConfig where ipaddress='" + ip + "'").Tables[0];
           }

           public DataSet getstationdrop()
           {
               return dba.GetDataSet("select stationid,convert(varchar(10),stationaddress) as stationaddress from Station_Info");
           }
        //proc_Station_tcpip_update_txj

           public int updatestation(int stationid, int ipid)
           {
               string procName = "proc_Station_tcpip_update_txj";
               SqlParameter[] sqlParmeters ={
                new SqlParameter("stationid",SqlDbType.Int),
                new SqlParameter("ipid",SqlDbType.Int)
                 };
               sqlParmeters[0].Value = stationid;
               sqlParmeters[1].Value = ipid;
              


               return dba.ExecuteSql(procName, sqlParmeters);

           }
        /// <summary>
        /// 分站安装位置
        /// </summary>
        /// <param name="stationid">分站流水号</param>
        /// <returns></returns>
           public string stationplace(int stationid)
           {
               string place = "";
               SqlDataReader dr = DB.ExecuteReader("select stationplace from Station_Info where stationid='" + stationid + "'");
               if (dr.Read())
               {
                   place = dr["stationplace"].ToString();
               }
               return place;
           }

           /// <summary>
           /// IP安装位置
           /// </summary>
           /// <param name="stationid">IP流水号</param>
           /// <returns></returns>
           public string ipplace(int ipid)
           {
               string place = "";
               SqlDataReader dr = DB.ExecuteReader("select place from tcpipconfig where ipid='" + ipid + "'");
               if (dr.Read())
               {
                   place = dr["place"].ToString();
               }
               return place;
           }
           public int delstation(int stationid)
           {
               //Czlt-2012-3-28 注销
               //int i = dba.ExecuteSql("update Station_Info set  IPAddressID=null where StationAddress=" + stationid);
               //Czlt-2012-3-28 修改
               int i = dba.ExecuteSql("update Station_Info set stationState=-1000, IPAddressID=null where StationAddress=" + stationid);
               return i;
           }

           public DataTable stationbyip(string ip)
           {
               return DB.Query("SELECT TcpIPConfig.IPAddress,TcpIPConfig.place, Station_Info.StationAddress, Station_Info.StationPlace,Station_Info.StationID,TcpIPConfig.ipid FROM Station_Info INNER JOIN   TcpIPConfig ON Station_Info.IPAddressID = TcpIPConfig.ipid where TcpIPConfig.IPAddress='" + ip + "'").Tables[0];

           }
           public DataTable guanlian_tree()
           {
               DataTable dt1 = new DataTable();
               DataSet ds = dba.GetDataSet("select ipid as id,place as name,'0' as ParentID,'true' as IsChild ,'false' as IsUserNum,'0' as Num from TcpIPConfig");
               if (ds != null && ds.Tables.Count > 0)
               {
                   dt1 = ds.Tables[0];

               }
               return dt1;
           }
        //SELECT TcpIPConfig.ipid as id,TcpIPConfig.place as name , '0' as ParentID,'true' as IsChild ,'false' as IsUserNum,'0' as Num  FROM Station_Info INNER JOIN   TcpIPConfig ON Station_Info.IPAddressID = TcpIPConfig.ipid
           public DataTable station_tree()
           {
               DataTable dt1 = new DataTable();
               DataSet ds = dba.GetDataSet("SELECT TcpIPConfig.ipid as id,TcpIPConfig.place as name , '0' as ParentID,'true' as IsChild ,'false' as IsUserNum,'0' as Num  FROM Station_Info INNER JOIN   TcpIPConfig ON Station_Info.IPAddressID = TcpIPConfig.ipid");
               if (ds != null && ds.Tables.Count > 0)
               {
                   dt1 = ds.Tables[0];

               }
               return dt1;
           }

           public DataTable GetTcpIpConfig()
           {
               DataSet ds = dba.GetDataSet("cjg_select_tcpIpConfig", null);
               try
               {
                   return ds.Tables[0];
               }
               catch (Exception ex)
               {
                   return new DataTable();
               }
           }

           #region【方法：Czlt-2011-12-10 修改配置时间】
           public void UpdateTime()
           {
               string strSQL = "UPDATE [CzltChangeTable] SET ChangeTime ='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
               dba.GetDataSet(strSQL);
           }

           #endregion
    }
}
