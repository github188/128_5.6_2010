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
    public class Li_HisInMineRecordSet_BLL
    {
        private Li_HisInMineRecordSetDAL lim = new Li_HisInMineRecordSetDAL();
        private DataSet ds;
        private string strSql = string.Empty;

        #region ���ز���,����, ֤��, ְ��,ְ��ȼ� ��Ϣ
        public bool LoadInfo(TreeView tvDep, ComboBox cmbWorkType, ComboBox cmbCerType, ComboBox cmbDutyName, ComboBox cmbDutyClass, int intUserType)
        {
            if (tvDep != null)
            {
                //���ز���
                using (ds = new DataSet())
                {
                    ds = lim.GetDeptInfo();
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        TreeNode tnDept = new TreeNode();
                        tnDept.Text = "���в���";
                        tvDep.Nodes.Add(tnDept);
                        LoadChildDept(tnDept, 0, 0, ds.Tables[0].Rows.Count);
                    }
                }
            }

            if (cmbWorkType != null)
            {
                //���ع���
                using (ds = new DataSet())
                {
                    ds = lim.GetWorkTypeInfo();
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        LoadWorkType(cmbWorkType);
                    }
                }
            }

            if (cmbDutyClass != null)
            {
                //����ְ��ȼ�
                using (ds = new DataSet())
                {
                    ds = lim.GetBusLevelInfo();
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        LoadDutyClass(cmbDutyClass);
                    }
                }
            }

            if (cmbCerType != null)
            {
                //����֤��
                using (ds = new DataSet())
                {
                    ds = lim.GetCerType();
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        LoadCerType(cmbCerType);
                    }
                }
            }

            if (cmbDutyName != null)
            {
                //����ְ��
                using (ds = new DataSet())
                {
                    ds = lim.GetBusinessInfo();
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        LoadDuty(cmbDutyName);
                    }
                }
            }

            return true;
        }

        #region �� TreeView �ؼ����ز���
        /// <summary>
        /// �� TreeView �ؼ����ز���
        /// </summary>
        /// <param name="tn">���ڵ�</param>
        /// <param name="intParentDeptID">��ID</param>
        /// <param name="intRowsIndex">��ǰ����</param>
        /// <param name="intRowsCount">������</param>
        private void LoadChildDept(TreeNode tn, int intParentDeptID, int intRowsIndex, int intRowsCount)
        {
            if (intRowsIndex == intRowsCount)
            {
                return;
            }

            if (int.Parse(ds.Tables[0].Rows[intRowsIndex]["ParentDeptID"].ToString()).Equals(intParentDeptID))
            {
                TreeNode tnChild = new TreeNode();
                tnChild.Text = ds.Tables[0].Rows[intRowsIndex]["DeptName"].ToString();
                tn.Nodes.Add(tnChild);

                LoadChildDept(tnChild, int.Parse(ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString()), intRowsIndex + 1, intRowsCount);
            }

            LoadChildDept(tn, intParentDeptID, intRowsIndex + 1, intRowsCount);
        }
        #endregion

        #region �� ComboBox �ؼ����ع���
        private void LoadWorkType(ComboBox cmbWorkType)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "����"));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                mylist.Add(new DictionaryEntry(dr["WorkTypeID"].ToString(), dr["WtName"].ToString()));
            }

            cmbWorkType.DataSource = mylist;
            cmbWorkType.DisplayMember = "Value";
            cmbWorkType.ValueMember = "Key";
            cmbWorkType.SelectedIndex = 0;
        }
        #endregion

        #region �� ComboBox �ؼ�����֤��
        private void LoadCerType(ComboBox cmbCerType)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "����"));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                mylist.Add(new DictionaryEntry(dr["CerTypeID"].ToString(), dr["CerName"].ToString()));
            }

            cmbCerType.DataSource = mylist;
            cmbCerType.DisplayMember = "Value";
            cmbCerType.ValueMember = "Key";
            cmbCerType.SelectedIndex = 0;
        }
        #endregion

        #region �� ComboBox �ؼ�����ְ��
        private void LoadDuty(ComboBox cmbDutyName)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "����"));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                mylist.Add(new DictionaryEntry(dr["DutyID"].ToString(), dr["DutyName"].ToString()));
            }

            cmbDutyName.DataSource = mylist;
            cmbDutyName.DisplayMember = "Value";
            cmbDutyName.ValueMember = "Key";
            cmbDutyName.SelectedIndex = 0;
        }
        #endregion

        #region �� ComboBox �ؼ�����ְ��ȼ�
        private void LoadDutyClass(ComboBox cmbDutyClass)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "����"));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                mylist.Add(new DictionaryEntry(dr["EnumID"].ToString(), dr["Title"].ToString()));
            }

            cmbDutyClass.DataSource = mylist;
            cmbDutyClass.DisplayMember = "Value";
            cmbDutyClass.ValueMember = "Key";
            cmbDutyClass.SelectedIndex = 0;
        }
        #endregion
        #endregion

        #region ��֯��ѯ����
        /// <summary>
        /// ��֯��ѯ����
        /// </summary>
        /// <param name="strStartTime">��ʼʱ��</param>
        /// <param name="strEndTime">����ʱ��</param>
        /// <param name="strName">����</param>
        /// <param name="strCard">����</param>
        /// <param name="strIdCard">���֤��</param>
        /// <param name="strWorkTypeId">����ID��</param>
        /// <param name="strCerTypeId">֤��ID��</param>
        /// <param name="strDutyId">ְ��ID��</param>
        /// <param name="strDutyClassId">ְ��ȼ�ID��</param>
        /// <returns>���ز�ѯ����</returns>
        public string SelectWhere(string strStartTime, string strEndTime, string strName, string strCard, string strIdCard, string strDeptName,
            string strWorkTypeId, string strCerTypeId, string strDutyId,string strDutyClassId)
        {
            strSql = " �¾�ʱ�� >= '" + strStartTime + "' And �¾�ʱ�� <= '" + strEndTime + "' ";

            if (!(strName.Equals("") | strName.Equals(null)))
            {
                strSql += " And ���� Like '%" + strName + "%' ";
            }

            if (!(strCard.Equals("") | strCard.Equals(null)))
            {
                strSql += " And ������ = " + strCard;
            }

            if (!(strIdCard.Equals("") | strIdCard.Equals(null)))
            {
                strSql += " And Idcard Like '%" + strIdCard + "%' ";
            }

            if (!(strDeptName.Equals("���в���")))
            {
                strSql += " And ( ���� = " + strDeptName + ") ";
            }

            if (!strWorkTypeId.Equals("0"))
            {
                strSql += " And WorkTypeID = " + strWorkTypeId;
            }

            if (!strCerTypeId.Equals("0"))
            {
                strSql += " And CerTypeID = " + strCerTypeId;
            }

            if (!strDutyId.Equals("0"))
            {
                strSql += " And DutyID = " + strDutyId;
            }

            if (!strDutyClassId.Equals("0"))
            {
                strSql += " And EnumID = " + strDutyClassId;
            }
            return strSql;
        }
        #endregion

        #region ��ѯ ��ʷ�¾���Ϣ
        public DataSet GetHisInMineSet(int pageIndex, int pageSize, string where)
        {
            DataSet ds  = lim.GetHisInMineSet(pageIndex,pageSize,where);
            if (ds!=null &&ds.Tables.Count>0)
            {
                ds.Tables[0].Columns[0].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);
                ds.Tables[0].Columns["�¾�ʱ��"].ColumnName = HardwareName.Value(CorpsName.InWellTime);
                ds.Tables[0].Columns["�Ͼ�ʱ��"].ColumnName = HardwareName.Value(CorpsName.OutWellTime);
                ds.Tables[0].Columns["����ʱ��"].ColumnName = HardwareName.Value(CorpsName.StandingWellTime);
            }
            return ds;
        }
        #endregion
    }
}
