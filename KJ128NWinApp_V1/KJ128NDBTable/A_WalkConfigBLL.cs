using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace KJ128NDBTable
{
    public class A_WalkConfigBLL
    {
        #region【声明】

        private A_WalkConfigDAL scdal = new A_WalkConfigDAL();

        private DataSet ds;

        #endregion


        #region 【方法: 查询超速、欠速配置信息】

        public DataSet SelectSpeedConfig(string strWhere)
        {
            return scdal.SelectSpeedConfig(strWhere);
        }

        #endregion

        #region【方法：获取(分站, 接收器)基本信息】

        private DataSet GetStationInfo()
        {
            return scdal.N_GetStationInfo();
        }

        private DataSet GetStationHeadInfo(string strStationAddress)
        {
            return scdal.N_GetStationHeadInfo(strStationAddress);
        }

        #endregion

        #region【方法：加载分站, 接收器信息】

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
            mylist.Add(new DictionaryEntry("无", "无"));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                mylist.Add(new DictionaryEntry(dr["StationAddress"].ToString(), dr["StationPlace"].ToString()));
            }

            cmbStation.DataSource = mylist;
            cmbStation.DisplayMember = "Key";
            cmbStation.ValueMember = "Key";
            cmbStation.SelectedIndex = 0;
        }
        #endregion

        #region 给 ComboBox 控件加载接收器
        private void LoadStationHeadInfo(ComboBox cmbStationHead)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("无", "无"));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                mylist.Add(new DictionaryEntry(dr["StationHeadAddress"].ToString(), dr["StationHeadPlace"].ToString()));
            }

            cmbStationHead.DataSource = mylist;
            cmbStationHead.DisplayMember = "Key";
            cmbStationHead.ValueMember = "Value";
            cmbStationHead.SelectedIndex = 0;
        }
        #endregion

        #region 重置接收器信息
        private void ResetStationHead(ComboBox cmbStationHead)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "无"));
            cmbStationHead.DataSource = mylist;
            cmbStationHead.DisplayMember = "Value";
            cmbStationHead.ValueMember = "Key";
            cmbStationHead.SelectedIndex = 0;
        }
        #endregion
        #endregion

        #region【方法：添加、修改超速配置信息】

        public int WalkConfig_InsertAndUpDate(int intFirstStationAddress, int intFirstStationHeadAddress, int intLastStationAddress,
            int intLastStationHeadAddress, int intWalkTime, string strRemark,int intLackWalkTime)
        {
            return scdal.WalkConfig_InsertAndUpDate(intFirstStationAddress, intFirstStationHeadAddress, intLastStationAddress, intLastStationHeadAddress,
                intWalkTime, strRemark,intLackWalkTime);
        }

        #endregion

        #region【方法：删除超速配置信息】

        public int WalkConfig_Delete(string strOverSpeedID)
        {
            return scdal.WalkConfig_Delete(strOverSpeedID);
        }

        #endregion
        
        #region【方法：判断数据库中是否存在起始和终点测点】

        public DataSet CheckingOverSpeed(string strFirstStationAddress, string strFirstStationHeadAddress, string strLastStationAddress, string strLastStationHeadAddress)
        {
            return scdal.CheckingOverSpeed(strFirstStationAddress, strFirstStationHeadAddress, strLastStationAddress, strLastStationHeadAddress);
        }

        #endregion

        #region【方法：查询超速配置信息——绑定修改数据】

        public DataSet SelectWalkConfig_Binding(int intOverSpeedID)
        {
            return scdal.SelectWalkConfig_Binding(intOverSpeedID);
        }

        #endregion

    }
}
