using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class RealTimeAlarmPathBLL
    {
        RealTimeAlarmPathDAL rtapdal = new RealTimeAlarmPathDAL();

        public DataTable RealTimeAlarmPathInfo()
        {
            if (rtapdal == null)
                rtapdal = new RealTimeAlarmPathDAL();

            return rtapdal.RealTimeAlarmPathInfo();
        }

        public int DeleteRealTimeAlarmPathByEmpID(int empID)
        {
            if (rtapdal == null)
            {
                rtapdal = new RealTimeAlarmPathDAL();
            }

            return rtapdal.DeleteRealTimeAlarmPathByEmpID(empID);
        }
    }
}
