using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class Graphics_His_EmpPlaceBLL
    {
        #region[声明]
        private Graphics_His_EmpPlaceDAL ghep = new Graphics_His_EmpPlaceDAL();
        RealTimeInTerritorialDAL rtitdal = new RealTimeInTerritorialDAL();
        private Graphics_RealTimeDAL grt = new Graphics_RealTimeDAL();
        #endregion

        public string GetHisEmpNum(DateTime sdate,DateTime edate)
        {
            return ghep.GetHisEmpNum(sdate.ToString("yyyy-MM-dd HH:mm:ss"), edate.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public List<string> GetAllAreaEmpNum(DateTime sdate, DateTime edate)
        {
            DataTable areadt = this.GetAreaInfo();
            List<string> list = new List<string>();
            for (int i = 0; i < areadt.Rows.Count; i++)
            {
                string empnum = ghep.GetHisAreaEmpNum(sdate.ToString("yyyy-MM-dd HH:mm:ss"), edate.ToString("yyyy-MM-dd HH:mm:ss"), areadt.Rows[i]["TerritorialID"].ToString());
                string str = areadt.Rows[i]["TerritorialName"].ToString();
                if (empnum != "")
                {
                    str = str + ":  " + empnum + "人次";
                }
                else
                {
                    str = str + ":  0人次";
                }
                list.Add(str);
            }
            return list;
        }

        public DataTable GetAreaInfo()
        {
            DataSet ds = rtitdal.N_GetTerInfo();
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }

        public List<string> GetHisEmpWorkTypeNum(int allnum,DateTime sdate,DateTime edate)
        {
            List<string> list = new List<string>();
            DataTable worktypedt = grt.GetAllWorkTypeName();
            int worktypenum = 0;
            if (worktypedt != null)
            {
                for (int i = 0; i < worktypedt.Rows.Count; i++)
                {
                    string str = worktypedt.Rows[i]["wtname"].ToString();
                    worktypenum += Convert.ToInt32(ghep.GetHisWorkTypeEmpNum(sdate.ToString("yyyy-MM-dd HH:mm:ss"), edate.ToString("yyyy-MM-dd HH:mm:ss"), worktypedt.Rows[i]["wtname"].ToString()));
                    str = str + ":  " + ghep.GetHisWorkTypeEmpNum(sdate.ToString("yyyy-MM-dd HH:mm:ss"), edate.ToString("yyyy-MM-dd HH:mm:ss"), worktypedt.Rows[i]["wtname"].ToString()) + "人次";
                    list.Add(str);
                }
            }
            string last = "未配置:  ";
            int lastnum = allnum - worktypenum;
            last = last + lastnum.ToString();
            list.Add(last);
            return list;
        }

        public List<string> GetHisEmpNumByDept(DateTime sdate,DateTime edate)
        {
            List<string> list = new List<string>();
            DataTable deptdt = new Graphics_RealTimeBLL().GetAllDept();
            if (deptdt != null)
            {
                for (int i = 0; i < deptdt.Rows.Count; i++)
                {
                    string str = deptdt.Rows[i]["deptname"].ToString();
                    str = str + ":  " + ghep.GetHisDeptEmpNum(sdate.ToString("yyyy-MM-dd HH:mm:ss"), edate.ToString("yyyy-MM-dd HH:mm:ss"), deptdt.Rows[i]["deptname"].ToString()) + "人次";
                    list.Add(str);
                }
            }
            return list;
        }

        public DataTable GetHisStationHeadInfo(DateTime sdate, DateTime edate, string stationplace)
        {
            int stationid = Convert.ToInt32(stationplace.Split('.')[0]);
            int stationheadid = Convert.ToInt32(stationplace.Split('.')[1]);
            return ghep.GetHisStationHeadInfo(sdate.ToString("yyyy-MM-dd HH:mm:ss"), edate.ToString("yyyy-MM-dd HH:mm:ss"), stationid, stationheadid);
        }

        public string GetHisStationHeadEmpNum(DateTime sdate, DateTime edate, string stationplace)
        {
            int stationid = Convert.ToInt32(stationplace.Split('.')[0]);
            int stationheadid = Convert.ToInt32(stationplace.Split('.')[1]);
            DataTable dt = ghep.GetHisStationHeadInfo(sdate.ToString("yyyy-MM-dd HH:mm:ss"), edate.ToString("yyyy-MM-dd HH:mm:ss"), stationid, stationheadid);
            if (dt != null)
                return dt.Rows.Count.ToString();
            else
                return "0";
        }
    }
}
