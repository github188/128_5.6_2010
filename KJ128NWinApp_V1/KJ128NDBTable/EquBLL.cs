using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class EquBLL
    {
        private EquDAL edal = new EquDAL();

        #region ���������ҵĲ���

        #region ����������ҵ���Ϣ
        /// <summary>
        /// �����������ҵı�Ż��һ������
        /// </summary>
        /// <param name="int_FactoryID">�������ұ��</param>
        /// <returns>����������һ������</returns>
        public DataTable GetFactoryInfo(int int_FactoryID)
        {
            return edal.GetFactoryInfo(int_FactoryID);
        }

        /// <summary>
        /// ���ȫ������
        /// </summary>
        /// <returns></returns>
        public DataTable GetFactoryInfo()
        {
            return edal.GetFactoryInfo();
        }
        #endregion

        #region ɾ����������
        /// <summary>
        /// ɾ����������
        /// </summary>
        /// <param name="int_FactoryID">���</param>
        /// <returns>������Ӱ���������-1Ϊɾ��ʧ�ܣ�</returns>
        public int DelFactory(int int_FactoryID)
        {
            return edal.DelFactory(int_FactoryID);
        }
        #endregion

        #region �޸��������ҵ���ϸ��Ϣ
        /// <summary>
        /// �޸��������ҵ���ϸ��Ϣ
        /// </summary>
        /// <param name="str_FactoryNO">���ұ��</param>
        /// <param name="str_FactoryName">��������</param>
        /// <param name="str_FactoryAddress">���ҵ�ַ</param>
        /// <param name="str_FactoryFax">���Ҵ���</param>
        /// <param name="str_FactoryTel">���ҵ绰</param>
        /// <param name="str_FactoryEmployee">��ϵ��</param>
        /// <param name="str_FactoryEmpoyeeTel">��ϵ�˵绰</param>
        /// <param name="str_Remark">��ע</param>
        /// <param name="int_FactoryID">���</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdateFactory(string str_FactoryNO, string str_FactoryName, string str_FactoryAddress, string str_FactoryFax, string str_FactoryTel, string str_FactoryEmployee, string str_FactoryEmpoyeeTel, string str_Remark, int int_FactoryID)
        {
            return edal.UpdateFactory(str_FactoryNO, str_FactoryName, str_FactoryAddress, str_FactoryFax, str_FactoryTel,str_FactoryEmployee, str_FactoryEmpoyeeTel, str_Remark,int_FactoryID);
        }
        #endregion

        #region ���һ���³���
        /// <summary>
        /// ���һ���³���
        /// </summary>
        /// <param name="str_FactoryNO">���ұ��</param>
        /// <param name="str_FactoryName">��������</param>
        /// <param name="str_FactoryAddress">���ҵ�ַ</param>
        /// <param name="str_FactoryFax">���Ҵ���</param>
        /// <param name="str_FactoryTel">���ҵ绰</param>
        /// <param name="str_FactoryEmployee">��ϵ��</param>
        /// <param name="str_FactoryEmpoyeeTel">��ϵ�˵绰</param>
        /// <param name="str_Remark">��ע</param>
        /// <returns>��Ӱ�������(����1����ɹ�������0˵����FactoryNO��ͬ�Ĵ���)</returns>
        public int AddFactory(string str_FactoryNO, string str_FactoryName, string str_FactoryAddress, string str_FactoryFax, string str_FactoryTel, string str_FactoryEmployee, string str_FactoryEmpoyeeTel, string str_Remark)
        {
            return edal.AddFactory(str_FactoryNO, str_FactoryName, str_FactoryAddress, str_FactoryFax, str_FactoryTel, str_FactoryEmployee, str_FactoryEmpoyeeTel, str_Remark);
        }
        #endregion

        #endregion

        #region �豸����

        #region ������Ϣ

        #region ����豸��Ϣ
        /// <summary>
        /// ���ȫ������
        /// </summary>
        /// <returns>��</returns>
        public DataTable GetEquInfo()
        {
            return edal.GetEquInfo();
        }

        /// <summary>
        /// �����豸��Ų�ѯ
        /// </summary>
        /// <param name="int_EquID">�豸���</param>
        /// <returns>��</returns>
        public DataTable GetEquInfo(int int_EquID)
        {
            return edal.GetEquInfo(int_EquID);
        }

        /// <summary>
        /// ���ݻ�����Ų�ѯ���
        /// </summary>
        /// <param name="strEquNO">�������</param>
        /// <returns></returns>
        public DataTable GetEquID(string strEquNO)
        {
            return edal.GetEquID(strEquNO);
        }

        #endregion

        #region ɾ��
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="int_EquID">�豸���</param>
        /// <returns>Ӱ������</returns>
        public int DelEqu_BaseInfo(int int_EquID)
        {
            return edal.DelEqu_BaseInfo(int_EquID);
        }
        #endregion

        #region �޸�
        //�޸�
        public int UpdateEqu_BaseInfo(string strEquNO, string strEquName, int intDeptID, int intEquType, int intEquState, int intFactoryID, string strRemark, int intEquID)
        {
            return edal.UpdateEqu_BaseInfo(strEquNO, strEquName, intDeptID, intEquType, intEquState, intFactoryID, strRemark, intEquID);
        }
        #endregion

        #region ���
        // ���
        public int AddEqu_BaseInfo(string strEquNO, string strEquName, int intDeptID, int intEquType, int intEquState, int intFactoryID, string strRemark)
        {
            // ��Ҫ�ж�һ��

            //string str = string.Format("insert into Equ_BaseInfo(EquNO,EquName,DeptID,EquType,EquState,FactoryID,Remark) select '{0}','{1}',{2},{3},{4},{5},'{6}' "+
            //    "from (select '{0}' as EquNo ,Count(1) as iCount From Equ_BaseInfo Where EquNo ='{0}' ) AS Tmp where iCount <1 ",
            //    strEquNO, strEquName, intDeptID, intEquType, intEquState, intFactoryID, strRemark);

            //return dba.ExecuteSql(str);

            return edal.AddEqu_BaseInfo(strEquNO, strEquName, intDeptID, intEquType, intEquState, intFactoryID, strRemark);
        }
        #endregion

        #endregion

        #region  ѡ����Ϣ

        #region ��ϸ��Ϣ
        /// <summary>
        /// �����豸��Ų�ѯ��ϸ��Ϣ
        /// </summary>
        /// <param name="int_EquID"></param>
        /// <returns></returns>
        public DataTable GetEquEqu_DetailInfo(int int_EquID)
        {
            return edal.GetEquEqu_DetailInfo(int_EquID);
        }
        #endregion

        #region �޸���ϸ��Ϣ

        // �޸���ϸ��Ϣ
        public int UpdateEqu_Detail(string strModelSpecial, string strDutyEmployee, string strUseRange, string dtProductionDate, int intEquHeight, int intEquPower, string dtUserDate, int intEquDetailID)
        {

            return edal.UpdateEqu_Detail(strModelSpecial, strDutyEmployee, strUseRange, dtProductionDate, intEquHeight, intEquPower, dtUserDate, intEquDetailID);
        }
        #endregion

        #region �����ϸ��Ϣ

        // �����ϸ��Ϣ
        public int AddEqu_Detail(string EquNO, string strModelSpecial, string strDutyEmployee, string strUseRange, string dtProductionDate, int intEquHeight, int intEquPower, string dtUserDate)
        {
            return edal.AddEqu_Detail(EquNO, strModelSpecial, strDutyEmployee, strUseRange, dtProductionDate,
                intEquHeight, intEquPower,dtUserDate);
        }

        public int AddEqu_Detail(int intEupID, string strModelSpecial, string strDutyEmployee, string strUseRange, string dtProductionDate, int intEquHeight, int intEquPower, string dtUserDate)
        {
            return edal.AddEqu_Detail(intEupID, strModelSpecial, strDutyEmployee, strUseRange, dtProductionDate,
                intEquHeight, intEquPower, dtUserDate);
        }
        #endregion

        #endregion

        #endregion

        #region ��ѯ
        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <param name="strEquName">�豸����</param>
        /// <param name="strFactoryID">��������</param>
        /// <returns></returns>
        public DataSet Equ_Query(string strEquName, string strFactoryID)
        {
            return edal.Equ_Query(strEquName, strFactoryID);
        }
        #endregion 
    }
}
