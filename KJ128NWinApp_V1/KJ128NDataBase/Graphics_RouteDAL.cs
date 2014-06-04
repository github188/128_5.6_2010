using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class Graphics_RouteDAL
    {
        #region[申明]
        private DBAcess dba = new DBAcess();
        #endregion

        public DataTable GetAllRoute()
        {
            string sqlstr = "select routefrom,routeto,routelength from route";
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetStationHeadPosition()
        {
            string sqlstr = "select stationheadplace,stationheadx,stationheady from station_head_info";
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }
    }
}
