using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDBTable.A_His_Station
{
    public  class A_His_StationBLL
    {
        KJ128NDataBase.A_His_Station.A_HisStationDAL dal = new KJ128NDataBase.A_His_Station.A_HisStationDAL();
        public DataTable DeptTree(int isemp)
        {
            return dal.DeptTree(isemp);
            
        }
        public DataTable His_Station_Info(bool iscount,int isemp, int pagesize, int pageindex, string str)
        {
            if (iscount)
            {
                return dal.His_Station_info(isemp,pagesize, pageindex, str).Tables[1];
            }
            else
            {
                return dal.His_Station_info(isemp, pagesize, pageindex, str).Tables[0];
            }
        }
    }
}
