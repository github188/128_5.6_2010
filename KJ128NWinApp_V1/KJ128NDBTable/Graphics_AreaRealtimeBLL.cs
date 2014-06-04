using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class Graphics_AreaRealtimeBLL
    {
        RealTimeInTerritorialDAL rtitdal = new RealTimeInTerritorialDAL();

        public List<string> GetAreaInfoAndEmpcount()
        {
            DataTable areadt = this.GetAreaInfo();
            List<string> list = new List<string>();
            for (int i = 0; i < areadt.Rows.Count; i++)
            {
                DataSet empds = rtitdal.N_GetRTInTerritorialInfo_G(Convert.ToInt32(areadt.Rows[i]["TerritorialTypeID"]), areadt.Rows[i]["TerritorialName"].ToString(), true, "");
                string str = areadt.Rows[i]["TerritorialName"].ToString();
                if (empds != null)
                {
                    str = str +":  " + empds.Tables[0].Rows.Count.ToString()+"人";
                }
                else
                {
                    str = str + ":  0人";
                }
                list.Add(str);
            }
            return list;
        }

        public DataTable GetAreaInfo()
        {
            DataSet ds = rtitdal.N_GetTerInfo_G();
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }
    }
}
