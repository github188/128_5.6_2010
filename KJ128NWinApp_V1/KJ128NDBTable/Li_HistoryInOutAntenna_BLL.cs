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
        #region [ ���� ]

        private DataSet ds;
        private string strSql = string.Empty;

        private Li_HistoryInOutAntenna_DAL liHioadal = new Li_HistoryInOutAntenna_DAL();

        #endregion

        #region ��ȡ(��վ, ������)������Ϣ
        private DataSet GetStationInfo()
        {
            return liHioadal.N_GetStationInfo();
        }

        private DataSet GetStationHeadInfo(string strStationAddress)
        {
            return liHioadal.N_GetStationHeadInfo(strStationAddress);
        }
        #endregion

        #region �� ComboBox �ؼ����ط�վ, ��������Ϣ
        /// <summary>
        /// �� ComboBox �ؼ����ط�վ, ��������Ϣ
        /// </summary>
        /// <param name="cmbStation">���ط�վ�� ComboBox �ؼ�</param>
        /// <param name="cmbStationHead">���ؿ�ͷ�� ComboBox �ؼ�</param>
        /// <param name="blFlagLoadStationHead">�Ƿ���ؿ�ͷ</param>
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
                    //���ý�������Ϣ
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

                        //���ý�������Ϣ
                        ResetStationHead(cmbStationHead);
                    }
                }
            }

            return true;
        }

        #region �� ComboBox �ؼ����ط�վ
        private void LoadStationInfo(ComboBox cmbStation)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "����"));

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

        #region �� ComboBox �ؼ����ؽ�����
        private void LoadStationHeadInfo(ComboBox cmbStationHead)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "����"));

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

        #region ���ý�������Ϣ
        private void ResetStationHead(ComboBox cmbStationHead)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "����"));
            cmbStationHead.DataSource = mylist;
            cmbStationHead.DisplayMember = "Value";
            cmbStationHead.ValueMember = "Key";
            cmbStationHead.SelectedIndex = 0;
        }
        #endregion
        #endregion

        #region ��֯��ѯ����
        public string SelectWhere(string strCodeSenderAddress, string strStartTime, string strEndTime, string strStationAddress, string strStationHeadAddress, 
            int intUserType, bool intFlagNotRegCard)
        {
            strSql = " ���ʱ�� >= '" + strStartTime + "' And ���ʱ�� <= '" + strEndTime + "' ";
            if (strCodeSenderAddress != "")
            {
                strSql += " And ������=" + strCodeSenderAddress;
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

        #region ��ѯ��ʷ����������Ϣ
        public DataSet GetHisInOutAntennaSet(int pageIndex, int pageSize, string where)
        {
            return liHioadal.N_GetHisInOutAntennaSet(pageIndex, pageSize, where);
        }
        #endregion
    }
}