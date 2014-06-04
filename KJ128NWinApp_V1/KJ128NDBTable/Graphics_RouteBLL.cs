using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class Graphics_RouteBLL
    {
        private Graphics_RouteDAL routedal = new Graphics_RouteDAL();

        public DataTable GetAllRoute()
        {
            DataTable dt = routedal.GetAllRoute();
            for (int i = (dt.Rows.Count - 1); i >= 0; i--)
            {
                if (i % 2 == 1)
                    dt.Rows.RemoveAt(i);
            }
            return dt;
        }

        public DataTable GetStationHeadPosition()
        {
            return routedal.GetStationHeadPosition();
        }
    }
}
