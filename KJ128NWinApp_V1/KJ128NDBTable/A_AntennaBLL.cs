using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDBTable
{
    public class A_AntennaBLL
    {
        private KJ128NDataBase.A_AntennaDAL dal = new KJ128NDataBase.A_AntennaDAL();

        public DataTable GetAllStation()
        {
            return dal.GetAllStation();
        }

        public DataTable GetStationHeadByStationAddress(string stationaddress)
        {
            return dal.GetStationHeadByStationAddress(stationaddress);
        }

        public DataTable GetRTantennaInfo(string station, string stationhead, string antenna, string cstype, string starttime, string endtime,bool showmine,string codesenderaddress, int pagenum, int pageindex,string strName, out int pagecount, out int rowcount)
        {
            string sqlstr = string.Empty;
            if (showmine)
            {
                sqlstr = "select 标识卡号,传输分站,读卡分站,结束巡检时间,上次传输分站,上次读卡分站 from A_RT_InOutStationView";
            }
            else
            {
                sqlstr = "select 标识卡号,传输分站,读卡分站,结束巡检时间,上次传输分站,上次读卡分站 from A_RT_InOutStationView where stationheadtypeid<>8";
            }
            if (cstype != "")
            {
                if (cstype != "null")
                {
                    if (sqlstr.Contains("where"))
                        sqlstr = string.Format(sqlstr + " and cstypeid={0}", cstype);
                    else
                        sqlstr = string.Format(sqlstr + " where cstypeid={0}", cstype);
                }
                else
                {
                    if (sqlstr.Contains("where"))
                        sqlstr = string.Format(sqlstr + " and cstypeid is {0}", cstype);
                    else
                        sqlstr = string.Format(sqlstr + " where cstypeid is {0}", cstype);
                }
            }
            if (station != "")
            {
                if (sqlstr.Contains("where"))
                    sqlstr = string.Format(sqlstr + " and stationaddress={0}", station);
                else
                    sqlstr = string.Format(sqlstr + " where stationaddress={0}", station);
            }
            if (stationhead != "")
            {
                if (sqlstr.Contains("where"))
                    sqlstr = string.Format(sqlstr + " and stationheadaddress={0}", stationhead);
                else
                    sqlstr = string.Format(sqlstr + " where stationheadaddress={0}", stationhead);
            }
            if (antenna != "")
            {
                if (sqlstr.Contains("where"))
                    sqlstr = string.Format(sqlstr + " and instationheadantenna={0}", antenna);
                else
                    sqlstr = string.Format(sqlstr + " where instationheadantenna={0}", antenna);
            }
            if (starttime != "" && endtime != "")
            {
                if (sqlstr.Contains("where"))
                    sqlstr = string.Format(sqlstr + " and 结束巡检时间 between '{0}' and '{1}'", starttime, endtime);
                else
                    sqlstr = string.Format(sqlstr + " where 结束巡检时间 between '{0}' and '{1}'", starttime, endtime);
            }
            if (codesenderaddress != "")
            {
                if (sqlstr.Contains("where"))
                    sqlstr = string.Format(sqlstr + " and 标识卡号={0}", codesenderaddress);
                else
                    sqlstr = string.Format(sqlstr + " where 标识卡号={0}", codesenderaddress);
            }
            if (strName != "")
            {
                if (sqlstr.Contains("where"))
                    sqlstr = string.Format(sqlstr + " and 称呼 like '%{0}%' ", strName);
                else
                    sqlstr = string.Format(sqlstr + " where 称呼 like '%{0}%' ", strName);
            }

            return dal.GetRTantennaInfo(sqlstr, pagenum, pageindex, out pagecount, out rowcount);
        }

        public DataTable GetRTantennaInfoByCodeSenderAddress(string codesenderaddress, bool showmine, string cstype, int pagenum, int pageindex, out int pagecount, out int rowcount)
        {
            string sqlstr = string.Empty;
            if (showmine)
            {
                sqlstr = "select 标识卡号,传输分站,读卡分站,结束巡检时间,上次传输分站,上次读卡分站 from A_RT_InOutStationView";
            }
            else
            {
                sqlstr = "select 标识卡号,传输分站,读卡分站,结束巡检时间,上次传输分站,上次读卡分站 from A_RT_InOutStationView where stationheadtypeid<>8";
            }
            if (cstype != "")
            {
                if (cstype != "null")
                {
                    if (sqlstr.Contains("where"))
                        sqlstr = string.Format(sqlstr + " and cstypeid={0}", cstype);
                    else
                        sqlstr = string.Format(sqlstr + " where cstypeid={0}", cstype);
                }
                else
                {
                    if (sqlstr.Contains("where"))
                        sqlstr = string.Format(sqlstr + " and cstypeid is {0}", cstype);
                    else
                        sqlstr = string.Format(sqlstr + " where cstypeid is {0}", cstype);
                }
            }
            if(sqlstr.Contains("where"))
                sqlstr = string.Format(sqlstr + " and 标识卡号={0}", codesenderaddress);
            else
                sqlstr = string.Format(sqlstr + " where 标识卡号={0}", codesenderaddress);
            return dal.GetRTantennaInfo(sqlstr, pagenum, pageindex, out pagecount, out rowcount);
        }

        public DataTable GetHisantennaInfo(string station, string stationhead, string antenna, string cstype, string starttime, string endtime, int pagenum, int pageindex, out int pagecount, out int rowcount)
        {
            string sqlstr = "select 标识卡号,称呼,convert(varchar(20),传输分站)+'@'+convert(varchar(20),读卡分站) as 传输_读卡分站,天线位置,天线,结束巡检时间 "+
                            "from A_His_InOutStationView";
            if (cstype != "")
            {
                if (cstype != "null")
                {
                    if (sqlstr.Contains("where"))
                        sqlstr = string.Format(sqlstr + " and cstypeid={0}", cstype);
                    else
                        sqlstr = string.Format(sqlstr + " where cstypeid={0}", cstype);
                }
                else
                {
                    if (sqlstr.Contains("where"))
                        sqlstr = string.Format(sqlstr + " and cstypeid is {0}", cstype);
                    else
                        sqlstr = string.Format(sqlstr + " where cstypeid is {0}", cstype);
                }
            }
            if (station != "")
            {
                if (sqlstr.Contains("where"))
                    sqlstr = string.Format(sqlstr + " and stationaddress={0}", station);
                else
                    sqlstr = string.Format(sqlstr + " where stationaddress={0}", station);
            }
            if (stationhead != "")
            {
                if (sqlstr.Contains("where"))
                    sqlstr = string.Format(sqlstr + " and stationheadaddress={0}", stationhead);
                else
                    sqlstr = string.Format(sqlstr + " where stationheadaddress={0}", stationhead);
            }
            if (antenna != "")
            {
                if (sqlstr.Contains("where"))
                    sqlstr = string.Format(sqlstr + " and instationantenna={0}", antenna);
                else
                    sqlstr = string.Format(sqlstr + " where instationantenna={0}", antenna);
            }
            if (starttime != "" && endtime != "")
            {
                if (sqlstr.Contains("where"))
                    sqlstr = string.Format(sqlstr + " and 结束巡检时间 between '{0}' and '{1}'", starttime, endtime);
                else
                    sqlstr = string.Format(sqlstr + " where 结束巡检时间 between '{0}' and '{1}'", starttime, endtime);
            }
            return dal.GetRTantennaInfo(sqlstr, pagenum, pageindex, out pagecount, out rowcount);
        }

        public DataTable GetHisantennaInfoByCodeSenderAddress(string codesenderaddress, string startdate, string enddate, string cstype, int pagenum, int pageindex, out int pagecount, out int rowcount)
        {
            string sqlstr = string.Format("select 标识卡号,称呼,convert(varchar(20),传输分站)+'@'+convert(varchar(20),读卡分站) as 传输_读卡分站,天线位置,天线,结束巡检时间 " +
                            "from A_His_InOutStationView where 结束巡检时间 between '{0}' and '{1}'", startdate, enddate);
            if (cstype != "")
            {
                if (cstype != "null")
                {
                    if (sqlstr.Contains("where"))
                        sqlstr = string.Format(sqlstr + " and cstypeid={0}", cstype);
                    else
                        sqlstr = string.Format(sqlstr + " where cstypeid={0}", cstype);
                }
                else
                {
                    if (sqlstr.Contains("where"))
                        sqlstr = string.Format(sqlstr + " and cstypeid is {0}", cstype);
                    else
                        sqlstr = string.Format(sqlstr + " where cstypeid is {0}", cstype);
                }
            }
            if (codesenderaddress!="")
            {
                if (sqlstr.Contains("where"))
                    sqlstr = string.Format(sqlstr + " and 标识卡号={0}", codesenderaddress);
                else
                    sqlstr = string.Format(sqlstr + " where 标识卡号={0}", codesenderaddress);
            }
            return dal.GetRTantennaInfo(sqlstr, pagenum, pageindex, out pagecount, out rowcount);
        }

        /// <summary>
        /// 历史下井信息
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页总数</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public DataSet GetHisantennaInfoByCodeSenderAddress(int pageIndex, int pageSize, string where)
        {
            return dal.GetHisantennaInfoByCodeSenderAddress(pageIndex, pageSize, where);
        }
    }
}
