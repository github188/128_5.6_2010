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
    public class Li_HisInOutStationHeadRecodset_BLL : Li_HisInMineRecordSet_BLL
    {

        #region [ ���� ]
        
        private Li_HisInOutStationHeadRecodsetDAL li = new Li_HisInOutStationHeadRecodsetDAL();
        private DataSet ds;
        private string strSql = string.Empty;

        #endregion


        #region [ ����: ��ComboBox�ؼ����ط�վ,��������Ϣ ]

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
                        ds = li.GetStationHeadInfo(strStationAddress);
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
                    ds = li.GetStationInfo();
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

        #region [ ����: ��֯��ѯ���� ]

        /// <summary>
        /// ��֯��ѯ����
        /// </summary>
        /// <param name="strStartTime">��ʼʱ��</param>
        /// <param name="strEndTime">����ʱ��</param>
        /// <param name="strName">����</param>
        /// <param name="strCard">����</param>
        /// <param name="strIdCard">���֤��</param>
        /// <param name="strDeptName">��������</param>
        /// <param name="strCerTypeId">֤��ID</param>
        /// <param name="strDutyId">ְ��ID</param>
        /// <param name="strStationAddress">��վ��ַ</param>
        /// <param name="strStationHeadAddress">��������ַ</param>
        /// <returns>���ز�ѯ����</returns>
        public string SelectWhere(string strStartTime,string strEndTime,string strName,string strCard,string strIdCard,string strDeptName,string strCerTypeId,string strDutyId,
            string strStationAddress,string strStationHeadAddress)
        {
            strSql = "  ���������ʱ�� >= '" + strStartTime + "' And ���������ʱ�� <= '" + strEndTime + "' ";

            if (!(strName.Equals("") | strName.Equals(null)))
            {
                strSql += " And ���� like '%" + strName + "%' ";
            }

            if (!(strCard.Equals("") | strCard.Equals(null)))
            {
                strSql += " And ������ = " + strCard;
            }

            if (!(strIdCard.Equals("") | strIdCard.Equals(null)))
            {
                strSql += " And Idcard like '%" + strIdCard + "%' ";
            }

            if (!(strDeptName.Equals("���в���")))
            {
                strSql += " And ( ���� = " + strDeptName + ") ";
            }

            if (!strCerTypeId.Equals("0"))
            {
                strSql += " And CerTypeID = " + strCerTypeId;
            }

            if (!strDutyId.Equals("0"))
            {
                strSql += " And DutyID = " + strDutyId;
            }

            if (!(strStationAddress.Equals("0")))
            {
                strSql += " And ��վ��ַ = " + strStationAddress;
            }

            if (!(strStationHeadAddress.Equals("0")))
            {
                strSql += " And ��������ַ = " + strStationHeadAddress;
            }

            return strSql;

        }

        #endregion

        #region [ ����: ��ѯ��ʷ������������Ϣ ]

        public DataSet GetInOutStationHeadSet(int pageIndex, int pageSize, string where)
        {
            return li.GetInOutStationHeadSet(pageIndex, pageSize, where);
        }

        #endregion


        #region [ ����: ����豸��ѯ�� ]

        /// <summary>
        /// ��ò�ѯ��
        /// </summary>
        /// <param name="strEquID">�豸����</param>
        /// <param name="strDeptID">���ű��</param>
        /// <param name="strFactoryID">��������</param>
        /// <param name="strInStationHeadTime">�����վʱ��</param>
        /// <param name="strOutStationHeadTime">�뿪��վʱ��</param>
        /// <returns>��</returns>
        public DataSet GetConditionEqu(string strEquID, string strDeptID, string strFactoryID, string strEquType, string strInStationHeadTime, string strOutStationHeadTime)
        {
            return li.GetConditionEqu(strEquID, strDeptID, strFactoryID, strEquType, strInStationHeadTime, strOutStationHeadTime);
        }

        #endregion 

    }
}
