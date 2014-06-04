using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KJ128NDataBase;
using System.Windows.Forms;
using KJ128NInterfaceShow;
using System.Web.UI.WebControls;

namespace KJ128NDBTable
{
    
   public class His_Station_Head_time_BLL_txj
    {
       private His_Station_Head_time_DAL_txj myhis = new His_Station_Head_time_DAL_txj();

       public DataSet dataGrid_renyuan_bind(int depid)
       {
           return myhis.dataGrid_renyuan_bind(depid);

       }
       public void getStation(ComboBox cmb)
       {
           DataSet ds = myhis.getStation();
           if (ds.Tables != null && ds.Tables.Count > 0)
           {
               //cmb.Items.Clear();
               DataRow dr = ds.Tables[0].NewRow();
                
               cmb.DataSource = ds.Tables[0];
               cmb.DisplayMember = "StationPlace";
               cmb.ValueMember = "stationaddress";
           }
       }

       public void getHead(ComboBox cmb,int stationid)
       {
           DataSet ds = myhis.getHead(stationid);
           if (ds.Tables != null && ds.Tables.Count > 0)
           {
               //cmb.Items.Clear();
               DataRow dr = ds.Tables[0].NewRow();

               cmb.DataSource = ds.Tables[0];
               cmb.DisplayMember = "stationheadplace";
               cmb.ValueMember = "stationheadaddress";
           }
       }


       //GetHisInOutTime
       #region 查询历史进出天线信息
       public DataTable GetHisInOutTime(string kssj, string jssj, string ksjz, string kstt, string jsjz, string jstt, string depid, string name)
       {
           return myhis.GetHisInOutTime(kssj,jssj,ksjz,kstt,jsjz,jstt,depid,name);
       }
       #endregion
    }
}
