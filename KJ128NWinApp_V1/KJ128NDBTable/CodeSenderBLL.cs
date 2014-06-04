using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KJ128NDBTable
{
    public class CodeSenderBLL
    {
        private CodeSenderDAL csdal = new CodeSenderDAL();
        private RealTimeDAL rtdal = new RealTimeDAL();

        #region [ ����: ���з�����״̬�޸�Ϊ���� ]

        /// <summary>
        /// ���з�����״̬�޸�Ϊ����
        /// </summary>
        /// <returns></returns>
        public void InitAllCode()
        {
            csdal.InitAllCode();
        }

        #endregion

        #region ɾ��������

        public int removeCodeSender(int id)
        {
            return csdal.removeCodeSender(id);
        }

        #endregion

        #region ɾ��������Ϣ

        public int removeCodeSenderSet(int id)
        {
            return csdal.removeCodeSenderSet(id);
        }

        #endregion

        #region �޸ķ�����

        // ����ָ����������Ϣ
        public DataSet getCodeSender(int id)
        {
            return csdal.getCodeSender(id);
        }

        // �޸�
        public int updateCodeSender(int CodeSenderStateID, int id, string Remark)
        {
            return csdal.updateCodeSender(CodeSenderStateID,id ,Remark);
        }

        #endregion

        #region ���÷�����
        // ���������� 0��Ա 1�豸
        public int addCodeSender_Set(int CodeSenderID, int UserID, int CsTypeID)
        {
            return csdal.addCodeSender_Set(CodeSenderID, UserID, CsTypeID);
        }

        #endregion

        #region ���ط�����״̬

        public ComboBox bindCmbCodeSenderState(ComboBox cmb)
        {
            DataSet ds = csdal.getCodeSenderStateInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Title";
                cmb.ValueMember = "EnumID";
            }
            return cmb;
        }

        #endregion

        #region ��ӷ�����������Ƿ����

        // ��ⷢ�����Ƿ����
        public int getExistsCodeSenderAddress(int address, int alarmElectricity, int codeSenderStateID, int isCodeSenderUser, string remark)
        {
            return csdal.getExistsCodeSenderAddress(address,alarmElectricity, codeSenderStateID,isCodeSenderUser,remark);
        }

        #endregion

        #region �������ʱ����Ѿ����ڵķ�վ��ַ

        public DataTable getExistsCodeSenderAddressList(string addressAll)
        {
            return csdal.getExistsCodeSenderAddressList(addressAll);
        }

        #endregion

        #region ������ӷ�����
        // alarmElectricityĬ��Ϊ0 isCodeSenderUserĬ��Ϊδʹ��2
        public int addCodeSenderInfo(string addressAll, int alarmElectricity, int codeSenderStateID, int isCodeSenderUser, string remark)
        {
            return csdal.addCodeSenderInfo(addressAll, alarmElectricity, codeSenderStateID, isCodeSenderUser, remark);
        }

        #endregion

        #region ���ط�������ϸ��Ϣ

        public DataSet N_getKJ128N_CodeSender_Info_Table(int pageIndex, int pageSize, string strWhere)
        {
            DataSet ds = csdal.getKJ128N_CodeSender_Info_Table(pageIndex,pageSize,strWhere);
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns["��������ַ"].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);
                ds.Tables[0].Columns["������״̬"].ColumnName = HardwareName.Value(CorpsName.CodeSender) + "״̬";
            }
            return ds;
        }

        #endregion

        //KJ128N_CodeSender_Set_Table
        #region ���ط�����������Ϣ

        public DataSet N_getKJ128N_CodeSender_Set_Table(int pageIndex, int pageSize,string strWhere)
        {
            DataSet ds = csdal.getKJ128N_CodeSender_Set_Table(pageIndex,pageSize,strWhere);
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns["��������ַ"].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);
            }
            return ds;
        }

        #endregion


        #region ���δ�����豸��Ϣ

        public DataSet getEquInfo(string deptID)
        {

            return csdal.getEquInfo(deptID);
        }

        #endregion

        #region ���δ������Ա��Ϣ

        public DataSet getEmpInfo(string deptID)
        {
            return csdal.getEmpInfo(deptID);
        }

        #endregion

        #region ���δ���÷�������Ϣ

        public DataSet getCS()
        {
            return csdal.getCS();
        }

        #endregion

        #region �����Ա��Ϣ

        public DataSet getSmallEmpInfo(int empID)
        {
            return csdal.getSmallEmpInfo(empID);
        }

        #endregion

        #region �����Ա��Ϣ

        public DataSet getSmallEquInfo(int equID)
        {
            return csdal.getSmallEquInfo(equID);
        }

        #endregion

    }
}
