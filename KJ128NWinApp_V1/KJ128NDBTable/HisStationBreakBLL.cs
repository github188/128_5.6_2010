using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;

using KJ128NDataBase;
using KJ128NInterfaceShow;

namespace KJ128NDBTable
{
    public class HisStationBreakBLL
    {
        private HisStationBreakDAL hsdal = new HisStationBreakDAL();

        #region 给 ComboBox 控件加载分站地址
        public void LoadStaPlace(ComboBox cmb)
        {
            DataSet ds = hsdal.GetStaPlaceInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.DataSource = null;
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "所有";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "StationPlace";
                cmb.ValueMember = "StationAddress";
            }
        }
        #endregion

        #region 组织 历史分站接收器故障信息 查询条件
        /// <summary>
        /// 组织 历史分站接收器故障信息 查询条件
        /// </summary>
        /// <param name="strStartTime">故障开始时间</param>
        /// <param name="strEndTime">故障结束时间</param>
        /// <param name="strStaAddress">历史分站地址</param>
        /// <returns>返回查询条件</returns>
        public string SelectWhere(string strStartTime, string strEndTime, string strStaAddress,string strStaBreak)
        {
            string strSql = string.Empty;
            strSql = "  故障开始时间 >= '" + strStartTime + "' And 故障开始时间 <='" + strEndTime + "' ";
            if (strStaAddress != "0" && strStaAddress != null)
            {
                strSql += " And 历史" + HardwareName.Value(CorpsName.StationAddress) + " = '" + strStaAddress + "' ";
            }
            if (strStaBreak != "所有故障" && strStaBreak != null)
            {
                strSql+= " And 故障类型 ='" + strStaBreak + "' ";
            }

            return strSql;
        }
        #endregion

        #region 查询 历史分站接收器故障信息
        public DataSet GetHisInTerInfoSet(int pageIndex, int pageSize, string where)
        {
            return hsdal.GetHisInTerInfoSet(pageIndex,pageSize,where);
        }
        #endregion
    }
}
