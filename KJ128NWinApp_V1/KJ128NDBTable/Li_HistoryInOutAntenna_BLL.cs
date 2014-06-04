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
    public class Li_HistoryInOutAntenna_BLL
    {
        #region [ 声明 ]

        private DataSet ds;
        private string strSql = string.Empty;

        private Li_HistoryInOutAntenna_DAL liHioadal = new Li_HistoryInOutAntenna_DAL();

        #endregion

        #region 获取(分站, 接收器)基本信息
        private DataSet GetStationInfo()
        {
            return liHioadal.N_GetStationInfo();
        }

        private DataSet GetStationHeadInfo(string strStationAddress)
        {
            return liHioadal.N_GetStationHeadInfo(strStationAddress);
        }
        #endregion

        #region 给 ComboBox 控件加载分站, 接收器信息
        /// <summary>
        /// 给 ComboBox 控件加载分站, 接收器信息
        /// </summary>
        /// <param name="cmbStation">加载分站的 ComboBox 控件</param>
        /// <param name="cmbStationHead">加载控头的 ComboBox 控件</param>
        /// <param name="blFlagLoadStationHead">是否加载控头</param>
        /// <returns></returns>
        public bool LoadInfo(ComboBox cmbStation, ComboBox cmbStationHead, bool blFlagLoadStationHead)
        {
            if (blFlagLoadStationHead)
            {
                string strStationAddress = cmbStation.SelectedValue.ToString();

                if (!strStationAddress.Equals("0"))
                {
                    using (ds = new DataSet())
                    {
                        ds = GetStationHeadInfo(strStationAddress);
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            LoadStationHeadInfo(cmbStationHead);
                        }
                    }
                }
                else
                {
                    //重置接收器信息
                    ResetStationHead(cmbStationHead);
                }
            }
            else
            {
                using (ds = new DataSet())
                {
                    ds = GetStationInfo();
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        LoadStationInfo(cmbStation);

                        //重置接收器信息
                        ResetStationHead(cmbStationHead);
                    }
                }
            }

            return true;
        }

        #region 给 ComboBox 控件加载分站
        private void LoadStationInfo(ComboBox cmbStation)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "所有"));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                mylist.Add(new DictionaryEntry(dr["StationAddress"].ToString(), dr["StationPlace"].ToString()));
            }

            cmbStation.DataSource = mylist;
            cmbStation.DisplayMember = "Value";
            cmbStation.ValueMember = "Key";
            cmbStation.SelectedIndex = 0;
        }
        #endregion

        #region 给 ComboBox 控件加载接收器
        private void LoadStationHeadInfo(ComboBox cmbStationHead)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "所有"));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                mylist.Add(new DictionaryEntry(dr["StationHeadAddress"].ToString(), dr["StationHeadPlace"].ToString()));
            }

            cmbStationHead.DataSource = mylist;
            cmbStationHead.DisplayMember = "Value";
            cmbStationHead.ValueMember = "Key";
            cmbStationHead.SelectedIndex = 0;
        }
        #endregion

        #region 重置接收器信息
        private void ResetStationHead(ComboBox cmbStationHead)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "所有"));
            cmbStationHead.DataSource = mylist;
            cmbStationHead.DisplayMember = "Value";
            cmbStationHead.ValueMember = "Key";
            cmbStationHead.SelectedIndex = 0;
        }
        #endregion
        #endregion

        #region 组织查询条件
        public string SelectWhere(string strCodeSenderAddress, string strStartTime, string strEndTime, string strStationAddress, string strStationHeadAddress, 
            int intUserType, bool intFlagNotRegCard)
        {
            strSql = " 监测时间 >= '" + strStartTime + "' And 监测时间 <= '" + strEndTime + "' ";
            if (strCodeSenderAddress != "")
            {
                strSql += " And 发码器=" + strCodeSenderAddress;
            }

            if (!intUserType.Equals(2))
            {
                strSql += " And CsTypeID = " + intUserType.ToString();
            }

            if (intFlagNotRegCard)
            {
                strSql += " And CsSetID Is Null ";
            }

            if (!(strStationAddress.Equals("0")))
            {
                strSql += " And StationAddress = " + strStationAddress;
            }

            if (!(strStationHeadAddress.Equals("0")))
            {
                strSql += " And StationHeadAddress = " + strStationHeadAddress;
            }

            return strSql;
        }
        #endregion

        #region 查询历史进出天线信息
        public DataSet GetHisInOutAntennaSet(int pageIndex, int pageSize, string where)
        {
            return liHioadal.N_GetHisInOutAntennaSet(pageIndex, pageSize, where);
        }
        #endregion
    }
}