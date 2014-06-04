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
    public class DeptBLL
    {

        #region [ ������ ]

        DeptDAL deptdal = new DeptDAL();

        #region ������Ϣ

        public DataSet GetDeptInfo()
        {
            return deptdal.GetDeptInfo();
        }

        #endregion

        #region ��ò�����Ϣ

        public DataSet GetDeptInfoAll()
        {
            return deptdal.GetDeptAll();
        }

        #endregion

        #region ����������Ϣ

        public string GetDeptChildAll(DataSet ds, string tmpWhere, int deptID)
        {
            DataRow[] drArray = ds.Tables[0].Select("ParentDeptID=" + deptID.ToString());
            foreach (DataRow dr in drArray)
            {
                if (ds.Tables[0].Select("ParentDeptID=" + deptID.ToString()).GetUpperBound(0) + 1 > 0)
                {
                    tmpWhere = GetDeptChildAll(ds, tmpWhere, int.Parse(dr["DeptID"].ToString()));
                }
                tmpWhere += " or DeptID=" + dr["DeptID"].ToString();
            }
            return tmpWhere;
        }

        #endregion
        //GetDeptInfo()

        #region ְ����Ϣ��

        //ְ�����ư�
        public ComboBox getDutyNameCmb(ComboBox cmb)
        {
            DataSet ds = deptdal.getDutyInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "����";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "DutyName";
                cmb.ValueMember = "DutyID";

            }
            return cmb;
        }

        //ְ��ȼ���
        public ComboBox getDutyClassCmb(ComboBox cmb)
        {
            DataSet ds = deptdal.getDutyClassInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "����";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Title";
                cmb.ValueMember = "EnumID";
            }
            return cmb;
        }

        #endregion

        #region ���ְ�

        public ComboBox getWorkTypeCmb(ComboBox cmb)
        {
            DataSet ds = deptdal.getWorkTypeInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "����";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "WtName";
                cmb.ValueMember = "WorkTypeID";
            }
            return cmb;
        }

        #endregion

        #region ֤������

        public ComboBox getCerTypeCmb(ComboBox cmb)
        {
            DataSet ds = deptdal.getCerTypeInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "����";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "CerName";
                cmb.ValueMember = "CerTypeID";
            }
            return cmb;
        }

        #endregion

        #region �豸���Ͱ�

        public ComboBox getEquTYpeCmb(ComboBox cmb)
        {
            DataSet ds = deptdal.getEquTYpe();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "����";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Title";
                cmb.ValueMember = "EnumID";
            }
            return cmb;
        }

        #endregion

        #region �豸���Ͱ�

        public ComboBox getEquFactoryCmb(ComboBox cmb)
        {
            DataSet ds = deptdal.getEquFactory();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "����";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "FactoryName";
                cmb.ValueMember = "FactoryID";
            }
            return cmb;
        }

        #endregion
        #endregion

        #region [ �Խ�ΰ ]
        private DeptDAL ddal = new DeptDAL();

        #region ����
        #region ����SQL��䣬���ز�����Ϣ(DataTable)
        /// <summary>
        /// ����SQL��䣬���ز�����Ϣ(DataTable)
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <returns>���ز�����Ϣ(DataTable)</returns>
        public DataTable GetDataTableDept(string sql)
        {
            return ddal.GetDataTableDept(sql);
        }
        #endregion

        #region [ ����: ���Ӳ�����Ϣ ]

        public int SaveDeptInfo(int ParentDeptID, int DeptLevelID, string DeptNO, string DeptName, string Remark, int ClassID,
             string DeptTel1, string DeptTel2, string DeptFax, string DeptPost, string DeptAddress, string DeptEmail,
            int MaxHour, int MaxMinute, int MaxSecond, int MinHour, int MinMinute, int MinSecond,
            int EmpID, string LeadDateTime)
        {
            int MaxTimeSec, MinTimeSec;
            MaxTimeSec = MaxHour * 3600 + MaxMinute * 60 + MaxSecond;
            MinTimeSec = MinHour * 3600 + MinMinute * 60 + MinSecond;
            return ddal.SaveDeptInfo(ParentDeptID, DeptLevelID, DeptNO, DeptName, Remark, ClassID, DeptTel1, DeptTel2, DeptFax, DeptPost,
                DeptAddress, DeptEmail, MaxTimeSec, MinTimeSec, EmpID, LeadDateTime);
        }

        #endregion

        #region ��� ���Ż�����Ϣ
        /// <summary>
        /// ��Ӳ��Ż�����Ϣ
        /// </summary>
        /// <param name="ParentDeptID">�ϼ�����ID</param>
        /// <param name="DeptLevelID">���ŵȼ�</param>
        /// <param name="DeptNO">���ű��</param>
        /// <param name="DeptName">��������</param>
        /// <param name="Remark">��ע</param>
        /// <returns>����Ӱ������</returns>
        public int SaveDeptInfoData(int ParentDeptID, int DeptLevelID, string DeptNO, string DeptName, string Remark, int ClassID)
        {
            return ddal.SaveDeptInfoData(ParentDeptID, DeptLevelID, DeptNO, DeptName, Remark, ClassID);
        }
        #endregion
        #region ��� ������Ϣ
        /// <summary>
        /// ��Ӳ�����Ϣ
        /// </summary>
        /// <param name="DeptNO">����NO</param>
        /// <param name="DeptTel1">���ŵ绰1</param>
        /// <param name="DeptTel2">���ŵ绰2</param>
        /// <param name="DeptFax">���Ŵ���</param>
        /// <param name="DeptPost">��������</param>
        /// <param name="DeptAddress">���ŵ�ַ</param>
        /// <param name="DeptEmail">���ŵ�������</param>
        /// <returns>����Ӱ������</returns>
        public int SaveDeptDetailData(string DeptNO, string DeptTel1, string DeptTel2, string DeptFax, string DeptPost, string DeptAddress, string DeptEmail)
        {
            return ddal.SaveDeptDetailData(DeptNO, DeptTel1, DeptTel2, DeptFax, DeptPost, DeptAddress, DeptEmail);
        }
        #endregion
        #region ��� ��������
        /// <summary>
        /// ��Ӳ�������
        /// </summary>
        /// <param name="DeptID">����ID</param>
        /// <param name="MaxHour">�����ʱ��(ʱ)</param>
        /// <param name="MaxMinute">�����ʱ��(��)</param>
        /// <param name="MaxSecond">�����ʱ��(��)</param>
        /// <param name="MinHour">��С����ʱ��(ʱ)</param>
        /// <param name="MinMinute">��С����ʱ��(��)</param>
        /// <param name="MinSecond">��С����ʱ��(��)</param>
        /// <returns>����Ӱ������</returns>
        public int SaveDeptSysSetData(string DeptNO, int MaxHour, int MaxMinute, int MaxSecond, int MinHour, int MinMinute, int MinSecond)
        {
            int MaxTimeSec, MinTimeSec;
            MaxTimeSec = MaxHour * 3600 + MaxMinute * 60 + MaxSecond;
            MinTimeSec = MinHour * 3600 + MinMinute * 60 + MinSecond;
            return ddal.SaveDeptSysSetData(DeptNO, MaxTimeSec, MinTimeSec);
        }
        #endregion
        #region ��� �����쵼
        /// <summary>
        /// ��� �����쵼
        /// </summary>
        /// <param name="DeptID">����ID</param>
        /// <param name="EmpID">�쵼ID</param>
        /// <param name="LeadDateTime">�쵼����ʱ��</param>
        /// <returns>����Ӱ������(int)</returns>
        public int SaveDeptLeadData(string DeptNO, int EmpID, string LeadDateTime)
        {
            return ddal.SaveDeptLeadData(DeptNO, EmpID, LeadDateTime);
        }
        #endregion
        #region �޸� ���Ż�����Ϣ
        /// <summary>
        /// �޸Ĳ��Ż�����Ϣ
        /// </summary>
        /// <param name="DeptID">����ID</param>
        /// <param name="ParentDeptID">�ϼ�����ID</param>
        /// <param name="DeptLevelID">���ż���</param>
        /// <param name="DeptNO">���ű��</param>
        /// <param name="DeptName">��������</param>
        /// <param name="Remark">��ע</param>
        /// <returns>����Ӱ������</returns>
        public int UpDateDeptInfoData(int DeptID, int ParentDeptID, int DeptLevelID, string DeptNO, string DeptName, string Remark, int ClassID)
        {
            return ddal.UpDateDeptInfoData(DeptID, ParentDeptID, DeptLevelID, DeptNO, DeptName, Remark, ClassID);
        }
        #endregion
        #region �޸� ������Ϣ
        /// <summary>
        /// �޸Ĳ�����Ϣ
        /// </summary>
        /// <param name="DeptID">����ID</param>
        /// <param name="DeptTel1">���ŵ绰1</param>
        /// <param name="DeptTel2">���ŵ绰2</param>
        /// <param name="DeptFax">���Ŵ���</param>
        /// <param name="DeptPost">�����ʱ�</param>
        /// <param name="DeptAddress">���ŵ�ַ</param>
        /// <param name="DeptEmail">���ŵ�������</param>
        /// <returns>����Ӱ������</returns>
        public int UpDateDeptDetailData(int DeptID, string DeptTel1, string DeptTel2, string DeptFax, string DeptPost, string DeptAddress, string DeptEmail)
        {
            return ddal.UpDateDeptDetailData(DeptID, DeptTel1, DeptTel2, DeptFax, DeptPost, DeptAddress, DeptEmail);
        }
        #endregion
        #region �޸� ��������
        /// <summary>
        /// �޸Ĳ�������
        /// </summary>
        /// <param name="DeptID">����ID</param>
        /// <param name="MaxHour">�����ʱ��(ʱ)</param>
        /// <param name="MaxMinute">�����ʱ��(��)</param>
        /// <param name="MaxSecond">�����ʱ��(��)</param>
        /// <param name="MinHour">��С����ʱ��(ʱ)</param>
        /// <param name="MinMinute">��С����ʱ��(��)</param>
        /// <param name="MinSecond">��С����ʱ��(��)</param>
        /// <returns>����Ӱ������</returns>
        public int UpDateDeptSysSetData(int DeptID, int MaxHour, int MaxMinute, int MaxSecond, int MinHour, int MinMinute, int MinSecond)
        {
            int MaxTimeSec, MinTimeSec;
            MaxTimeSec = MaxHour * 3600 + MaxMinute * 60 + MaxSecond;
            MinTimeSec = MinHour * 3600 + MinMinute * 60 + MinSecond;
            return ddal.UpDateDeptSysSetData(DeptID, MaxTimeSec, MinTimeSec);
        }
        #endregion
        #region �޸� �����쵼��Ϣ
        /// <summary>
        /// �޸Ĳ����쵼��Ϣ
        /// </summary>
        /// <param name="DeptID">����ID</param>
        /// <param name="EmpID">�����쵼ID</param>
        /// <param name="LeadDateTime">�쵼����ʱ��</param>
        /// <returns>����Ӱ������</returns>
        public int UpDateDeptLeadData(string DeptNO, int EmpID, string LeadDateTime)
        {
            return ddal.UpDateDeptLeadData(DeptNO, EmpID, LeadDateTime);
        }
        #endregion
        #region ɾ�������쵼��Ϣ
        /// <summary>
        /// ɾ�������쵼��Ϣ
        /// </summary>
        /// <param name="DeptID">����ID</param>
        /// <returns>����Ӱ������</returns>
        public int DeleteDeptLead(int DeptID)
        {
            return ddal.DeleteDeptLead(DeptID);
        }
        #endregion
        #region ɾ�� ������Ϣ
        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="DeptID">����ID</param>
        /// <returns>����Ӱ������</returns>
        public int DeleteDept(int DeptID)
        {
            return ddal.DeleteDept(DeptID);
        }
        #endregion
        #region ��ȡ���ż���
        /// <summary>
        /// ��ȡ���ż���
        /// </summary>
        /// <param name="ParentDeptName">�ϼ���������</param>
        /// <returns>���ż���</returns>
        public int GetDeptLevelID(int DeptID)
        {
            if (DeptID == 0)
            {
                return 1;
            }
            else
            {
                string sqlString = string.Format("select DeptLevelID from Dept_Info where DeptID={0}", DeptID);
                return ddal.GetID(sqlString) + 1;
            }
        }
        #endregion
        #region ��ȡ����ID
        /// <summary>
        /// ��ȡ����ID
        /// </summary>
        /// <param name="DeptNO">���ű��</param>
        /// <returns>����ID</returns>
        public int GetDeptID(String DeptNO)
        {
            string sqlString = "select DeptID from KJ128N_Dept_Info_Table where ���ű��='" + DeptNO + "'";
            return ddal.GetID(sqlString);
        }
        #endregion
        #region ��ȡ�����쵼��ID
        /// <summary>
        /// ��ȡ�����쵼��ID
        /// </summary>
        /// <param name="DeptLeadName">�����쵼������</param>
        public int GetDeptLeadID(String DeptLeadName)
        {
            string sqlString = "select EmpID from Emp_Info where EmpName='" + DeptLeadName + "'";
            return ddal.GetID(sqlString);
        }
        #endregion
        #region ���ϼ�����
        public ComboBox GetParentDeptCmb(ComboBox cmb)
        {
            DataSet ds = ddal.GetParentDeptDataSet();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.DataSource = null;
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "��";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "DeptName";
                cmb.ValueMember = "DeptID";
                cmb.SelectedValue = 0;
            }

            return cmb;
        }
        #endregion
        #region �󶨰�������
        public ComboBox GetClassNameCmb(ComboBox cmb)
        {
            DataSet ds = ddal.GetClassDataSet();
            cmb.DataSource = null;
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmb.DataSource = ds.Tables[0];
                    cmb.DisplayMember = "ClassName";
                    cmb.ValueMember = "ID";
                    cmb.SelectedIndex = 0;
                }
            }
            return cmb;
        }
        #endregion

        #region [ ��ȡ������Ϣ ]

        public DataSet GetDeptDataSet()
        {
            return ddal.GetDeptDataSet();
        }

        #endregion

        #endregion

        #region ְ��
        #region ����SQL��䣬����ְ����Ϣ(DataTable)
        /// <summary>
        /// ����SQL��䣬����ְ����Ϣ(DataTable)
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <returns>����ְ����Ϣ(DataTable)</returns>
        public DataTable GetDataTableDuty(string sql)
        {
            return ddal.GetDataTableDuty(sql);
        }
        #endregion
        #region ��� ְ����Ϣ
        /// <summary>
        /// ���ְ����Ϣ
        /// </summary>
        /// <param name="DutyName">ְ������</param>
        /// <param name="DutyClassID">ְ��ȼ�</param>
        /// <param name="DuptRemark">��ע</param>
        /// <returns>����Ӱ������</returns>
        public int SaveDutyInfoData(string DutyName, int DutyClassID, string DuptRemark)
        {
            return ddal.SaveDutyInfoData(DutyName, DutyClassID, DuptRemark);
        }
        #endregion
        #region �޸� ְ����Ϣ
        /// <summary>
        /// �޸�ְ����Ϣ
        /// </summary>
        /// <param name="DutyID">ְ��ID</param>
        /// <param name="DutyName">ְ������</param>
        /// <param name="DutyClassID">ְ��ȼ�</param>
        /// <param name="DutyRemark">��ע</param>
        /// <returns>����Ӱ������</returns>
        public int UpDateDutyInfo(int DutyID, string DutyName, int DutyClassID, string DutyRemark)
        {
            return ddal.UpDateDutyInfo(DutyID, DutyName, DutyClassID, DutyRemark);
        }
        #endregion
        #region ɾ�� ְ����Ϣ
        /// <summary>
        /// ɾ�� ְ����Ϣ
        /// </summary>
        /// <param name="DutyID">ְ��ID</param>
        /// <returns>����Ӱ������</returns>
        public int DeleteDuty(int DutyID)
        {
            return ddal.DeleteDuty(DutyID);
        }
        #endregion
        #endregion

        #region ֤��
        #region ����SQL��䣬����֤����Ϣ(DataTable)
        /// <summary>
        /// ����SQL��䣬����֤����Ϣ(DataTable)
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <returns>����֤����Ϣ(DataTable)</returns>
        public DataTable GetDataTableCertificate(string sql)
        {
            return ddal.GetDataTableCertificate(sql);
        }
        #endregion
        #region ��� ֤����Ϣ
        /// <summary>
        /// ���֤����Ϣ
        /// </summary>
        /// <param name="CerName">֤������</param>
        /// <param name="CerVestIn">��֤��λ</param>
        /// <param name="IsCheckExpDate">�Ƿ���֤����Ч��</param>
        /// <param name="CertificateRemark">��ע</param>
        /// <returns>����Ӱ������</returns>
        public int SaveCertificateData(string CerName, string CerVestIn, int IsCheckExpDate, string CertificateRemark)
        {
            return ddal.SaveCertificateData(CerName, CerVestIn, IsCheckExpDate, CertificateRemark);
        }
        #endregion
        #region �޸� ֤����Ϣ
        /// <summary>
        /// �޸�֤����Ϣ
        /// </summary>
        /// <param name="CerTypeID">֤��ID</param>
        /// <param name="CerName">֤������</param>
        /// <param name="CerVestIn">��֤��λ</param>
        /// <param name="IsCheckExpDate">�Ƿ���֤����Ч��</param>
        /// <param name="CertificateRemark">��ע</param>
        /// <returns>����Ӱ������</returns>
        public int UpDateCertificate(int CerTypeID, string CerName, string CerVestIn, int IsCheckExpDate, string CertificateRemark)
        {
            return ddal.UpDateCertificate(CerTypeID, CerName, CerVestIn, IsCheckExpDate, CertificateRemark);
        }
        #endregion
        #region ɾ�� ֤����Ϣ
        /// <summary>
        /// ɾ��֤����Ϣ
        /// </summary>
        /// <param name="CerTypeID">֤��ID</param>
        /// <returns>����Ӱ������</returns>
        public int DeleteCertificate(int CerTypeID)
        {
            return ddal.DeleteCertificate(CerTypeID);
        }
        #endregion
        #endregion

        #region ����
        #region ����SQL��䣬���ع�����Ϣ(DataTable)
        /// <summary>
        /// ����SQL��䣬���ع�����Ϣ(DataTable)
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <returns>���ع�����Ϣ(DataTable)</returns>
        public DataTable GetDataTableWorkType(string sql)
        {
            return ddal.GetDataTableWorkType(sql);
        }
        #endregion
        #region ��ȡ֤��ID
        /// <summary>
        /// ��ȡ֤��ID
        /// </summary>
        /// <param name="CerName">֤������</param>
        /// <returns>����֤��ID</returns>
        public int GetCerID(String CerName)
        {
            string strsql = string.Format("select CerTypeID from Certificate_Info where CerName='{0}'", CerName);
            return ddal.GetID(strsql);
        }
        #endregion
        #region ��ȡ����ID
        /// <summary>
        /// ��ȡ����ID
        /// </summary>
        /// <param name="WorkName">��������</param>
        /// <returns>���ع���ID</returns>
        public int GetWorkID(string WorkName)
        {
            string sqlString = "select WorkTypeID from WorkType_Info where WtName='" + WorkName + "'";
            return ddal.GetID(sqlString);
        }
        #endregion

        #region ������: ��� ������Ϣ ��

        public int SaveWorkData(string WtName, int CerTypeID, string WorkRemark,
            int MaxHour, int MaxMinute, int MaxSecond, int MinHour, int MinMinute, int MinSecond)
        {
            int MaxTimeSec, MinTimeSec;
            MaxTimeSec = MaxHour * 3600 + MaxMinute * 60 + MaxSecond;
            MinTimeSec = MinHour * 3600 + MinMinute * 60 + MinSecond;

            return ddal.SaveWorkData(WtName, CerTypeID, WorkRemark, MaxTimeSec, MinTimeSec);
        }

        #endregion

        #region ������: �޸� ������Ϣ ��

        public int UpDateWorkType(string WtName, int CerTypeID, string WorkRemark,
            int MaxHour, int MaxMinute, int MaxSecond, int MinHour, int MinMinute, int MinSecond)
        {
            int MaxTimeSec, MinTimeSec;
            MaxTimeSec = MaxHour * 3600 + MaxMinute * 60 + MaxSecond;
            MinTimeSec = MinHour * 3600 + MinMinute * 60 + MinSecond;

            return ddal.UpDateWorkType(WtName, CerTypeID, WorkRemark, MaxTimeSec, MinTimeSec);
        }

        #endregion

        #region ɾ�� ������Ϣ
        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="WorkTypeID">����ID</param>
        /// <returns>����Ӱ������</returns>
        public int DeleteWork(int WorkTypeID)
        {
            return ddal.DeleteWork(WorkTypeID);
        }
        #endregion
        #region �� ֤������
        public ComboBox GetWorkCerCmb(ComboBox cmb)
        {
            DataSet ds = ddal.GetWorkCerDataSet();
            if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = null;
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "CerName";
                cmb.ValueMember = "CerTypeID";
                cmb.SelectedIndex = 0;
            }
            return cmb;
        }
        #endregion
        #region �󶨹���(����DataGridViewKJ128)
        /// <summary>
        /// �󶨹���(����DataGridView)
        /// </summary>
        /// <returns>����DataGridView</returns>
        public DataGridViewKJ128 GetWorkTypeDgv(DataGridViewKJ128 dgv)
        {
            string strSql = "select * from KJ128N_WorkType_Info_Table";
            DataTable dt = GetDataTableWorkType(strSql);
            //DataGridViewColumn dgvc1=new DataGridViewColumn();
            //DataGridViewColumn dgvc2=new DataGridViewColumn();
            dgv.DataSource = dt;
            dgv.ReadOnly = true;
            dgv.Columns[0].DisplayIndex = 11;
            dgv.Columns[1].DisplayIndex = 11;
            dgv.Columns[4].Visible = false;
            dgv.Columns[9].Visible = false;
            dgv.Columns[10].Visible = false;
            dgv.Columns[11].Visible = false;
            dgv.Columns[2].Visible = false;
            dgv.Columns[8].Visible = false;
            return dgv;
        }
        #endregion

        #endregion
        #endregion

        #region [ ����� ]

        #region ���豸���ͣ����ʱʹ�ã�
        /// <summary>
        /// ���豸���ͣ����ʱʹ�ã�
        /// </summary>
        /// <param name="cmb">�ؼ�</param>
        public void getEquType(ComboBox cmb)
        {
            DataSet ds = deptdal.getEquTYpe();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                //DataRow dr = ds.Tables[0].NewRow();
                //dr[0] = 0;
                //dr[1] = "��";
                //ds.Tables[0].Rows.InsertAt(dr,0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Title";
                cmb.ValueMember = "EnumID";
            }
        }
        #endregion 

        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="cmb"></param>
        public void getFactory(ComboBox cmb)
        {
            DataSet ds = deptdal.getEquFactory();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                //DataRow dr = ds.Tables[0].NewRow();
                //dr[0] = 0;
                //dr[1] = "��";
                //ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "FactoryName";
                cmb.ValueMember = "FactoryID";
            }
        }
        #endregion 

        #region �󶨲���
        /// <summary>
        ///  �󶨲���
        /// </summary>
        /// <param name="cmb">�ؼ���</param>
        public void getDept(ComboBox cmb)
        {
            DataSet ds = deptdal.getDept();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                //cmb.Items.Clear();
                //DataRow dr = ds.Tables[0].NewRow();
                //dr[0] = 0;
                //dr[1] = "��";
                //ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "DeptName";
                cmb.ValueMember = "DeptID";
            }
        }

        //��ӡ����С�Ԫ�صĲ��Ű�
        public void getDeptAddAll(ComboBox cmb)
        {
            DataSet ds = deptdal.getDept();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                //cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = "0";
                dr[2] = "����";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "DeptName";
                cmb.ValueMember = "DeptID";
               
            }
        }

        //��ӡ����С�Ԫ�صĲ��Ű�
        public void getDeptAddAll1(ComboBox cmb)
        {
            DataSet ds = deptdal.getDept();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                //cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = "0";
                dr[2] = "ѡ��";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "DeptName";
                cmb.ValueMember = "DeptID";

            }
        }
        #endregion 

        #region ���豸״̬
        /// <summary>
        /// ���豸״̬
        /// </summary>
        /// <param name="cmb">�ؼ���</param>
        public void getEquState(ComboBox cmb)
        {
            DataSet ds = deptdal.getEquStation();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                //DataRow dr = ds.Tables[0].NewRow();
                //dr[0] = 0;
                //dr[1] = "��";
                //ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Title";
                cmb.ValueMember = "EnumID";
            }
        }
        #endregion 

        #endregion 

        #region [ ��Web�ؼ���� ]

        #region �󶨲�����Ϣ��ListBox��Web�ؼ���
        public void BindDetpLB(System.Web.UI.WebControls.ListBox lb)
        {
            DataSet ds = deptdal.getDept();

            if (ds != null)
            {
                lb.DataSource = ds;
                lb.DataTextField = "DeptName";
                lb.DataValueField = "DeptID";
                lb.DataBind();

                lb.Items.Insert(0, new ListItem("���в���", "0"));
            }
        }
        #endregion

        #region �󶨲�����Ϣ��DropDownList��Web�ؼ���
        public void BindDetpDDL(System.Web.UI.WebControls.DropDownList ddl)
        {
            DataSet ds = deptdal.getDept();

            if (ds != null)
            {
                ddl.DataSource = ds;
                ddl.DataTextField = "DeptName";
                ddl.DataValueField = "DeptID";
                ddl.DataBind();

                ddl.Items.Insert(0, new ListItem("���в���", "0"));
            }
        }
        #endregion

        #region ���ݲ�����ˮ�õ�ʱ����Ϣ
        public DataSet GetClassInfo(int intDeptId, out string strErrMsg)
        {
            return deptdal.GetClassInfo(intDeptId, out strErrMsg);
        }
        #endregion

        #region ��ѯ���Ź�ʱ������Ϣ
        public DataSet GetUnitPriceInfo(string strWhere, out string strErr)
        {
            return deptdal.GetUnitPriceInfo(strWhere, out strErr);
        }
        #endregion

        #region ��Ӳ��Ź�ʱ������Ϣ
        public int InsertUnitPriceInfo(int intDeptID, float fUnitPrice, string strRemark, out string strErr)
        {
            return deptdal.InsertUnitPriceInfo(intDeptID, fUnitPrice, strRemark, out strErr);
        }
        #endregion

        #region �޸Ĳ��Ź�ʱ������Ϣ
        public int UpdateUnitPriceInfo(int intDeptID, float fUnitPrice, string strRemark, out string strErr)
        {
            return deptdal.UpdateUnitPriceInfo(intDeptID, fUnitPrice, strRemark, out strErr);
        }
        #endregion

        #region ɾ�����Ź�ʱ������Ϣ
        public int DeleteUnitPriceInfo(int intDeptID, out string strErr)
        {
            return deptdal.DeleteUnitPriceInfo(intDeptID, out strErr);
        }
        #endregion
        #endregion

        #region [ �޸� ]

        #region [ KJ128N_AllDept ]

        public DataSet GetKJ128NAllDept(int tempDept_ID)
        {
            return ddal.GetKJ128NAllDept(tempDept_ID);
        }

        #endregion

        #region [ ����: ���ݲ���DeptID��ȡ������Ϣ ]

        public DataSet GetIDDeptInfo(string strDeptID)
        {
            return ddal.GetIDDeptInfo(strDeptID);
        }

        #endregion

        #region [ ����: ����EmpID�õ���Ա��Ϣ ]

        public DataSet GetEmpIDEmpInfo(string empID)
        {
            return deptdal.GetEmpIDEmpInfo(empID);
        }

        #endregion

        #region [ ����: ��֤���ű��Ψһ�� ]

        public DataSet GetIDDeptID(string deptID)
        {
            return deptdal.GetIDDeptID(deptID);
        }

        #endregion

        #region [ ����: ����ְ����Ϣ ]

        public DataSet GetDutyInfoTable(string empName)
        {
            return deptdal.GetDutyInfoTable(empName);
        }

        #endregion

        #region [ ����: ��֤�����쵼 ]

        public DataSet GetEmpNameEmpInfo(string empName)
        {
            return deptdal.GetEmpNameEmpInfo(empName);
        }

        #endregion

        #region [ ����: KJ128N_Duty_Info_Table ]

        public DataSet GetIDDutyInfoTable(int tempDuty_ID)
        {
            return deptdal.GetIDDutyInfoTable(tempDuty_ID) ;
        }

        #endregion

        #region [ ����: KJ128N_Duty_Info_Table ]

        public DataSet GetIDWorkTypeInfoTable(int tempWork_ID)
        {
            return deptdal.GetIDWorkTypeInfoTable(tempWork_ID) ;
        }

        #endregion

        #region [ ����: KJ128N_Duty_Info_Table ]

        public DataSet GetNameWorkTypeInfoTable(string WtName)
        {
            return deptdal.GetNameWorkTypeInfoTable(WtName);
        }

        #endregion

        #region [ ����: ���ְ��ȼ� ]

        public DataSet GetDutyGrade()
        {
            return deptdal.GetDutyGrade() ;

        }

        #endregion

        #region [ ����: ���֤����Ϣ ]

        public DataSet GetCertificateInfo(int tempCer_ID)
        {
            return deptdal.GetCertificateInfo(tempCer_ID);
        }

        #endregion

        #endregion

        #region ��Czlt-2011-06-14 �쵼�ɲ��ȼ���ѯ��

        public ComboBox CzltGetDutyClassCmb(ComboBox cmb)
        {
            DataSet ds = deptdal.CzltGetDutyClassInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "����";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Title";
                cmb.ValueMember = "EnumID";
            }
            return cmb;
        }
        #endregion

        #region ��Czlt-2012-05-17��
        /// <summary>
        /// Czlt-2012-5-21 ���ݲ������Ʋ��������Ӳ���
        /// </summary>
        /// <param name="isName">�Ƿ񷵻�����</param>
        /// <param name="strDeptName">����������</param>
        /// <returns></returns>
        public string GetValueOrId(bool isName,string strDeptName)
        {
            string strValue = string.Empty;
            string strSql = "select deptId,deptname from dept_info where ParentDeptID=(select deptId from Dept_info where deptName='" + strDeptName + "') or deptName='" + strDeptName + "'";
            DataTable dt = deptdal.GetDeptId(strSql);
            if (dt != null || dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (isName)
                    {
                        strValue += dr[1].ToString()+"','";
                    }
                    else
                    {
                        strValue += dr[0].ToString()+"','";
                    }
                }
               
            }
            if (strValue.Length > 0)
                strValue = strValue.Substring(0, strValue.Length - 3);
            return strValue;
        }

        /// <summary>
        /// Czlt-2012-5-17 ����ID��ѯ
        /// </summary>
        /// <param name="isName"></param>
        /// <param name="strDeptName"></param>
        /// <returns></returns>
        public string GetValueOrIdByID(bool isName, string strDeptName)
        {
            string strValue = string.Empty;
            string strSql = "select deptId,deptname from dept_info where ParentDeptID='" + strDeptName + "' or deptID='" + strDeptName + "'";
            DataTable dt = deptdal.GetDeptId(strSql);
            if (dt != null || dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (isName)
                    {
                        strValue += dr[1].ToString() + "','";
                    }
                    else
                    {
                        strValue += dr[0].ToString() + "','";
                    }
                }

            }
            if (strValue.Length > 0)
                strValue = strValue.Substring(0, strValue.Length - 3);
            return strValue;
        }
        #endregion

    }
}
