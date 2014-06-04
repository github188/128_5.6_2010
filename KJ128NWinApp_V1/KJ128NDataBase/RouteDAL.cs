using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using KJ128NModel;

namespace KJ128NDataBase
{
    public class RouteDAL
    {
        private DBAcess dba = new DBAcess();

        public List<KJ128NModel.RouteModel> GetAllRoute()
        {
            try
            {
                List<KJ128NModel.RouteModel> list = new List<RouteModel>();
                string selectstr = "select * from route";
                DataTable dt = dba.GetDataSet(selectstr).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    RouteModel r = new RouteModel();
                    r.From = dt.Rows[i][1].ToString();
                    r.To = dt.Rows[i][2].ToString();
                    r.RouteLength = Convert.ToInt32(dt.Rows[i][3]);
                    list.Add(r);
                }               
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetNumOfRoute()
        {
            try
            {
                int num = 0;
                string selectstr="select count(id) from route";
                num = Convert.ToInt32(dba.ExecuteScalarSql(selectstr));
                return num;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
