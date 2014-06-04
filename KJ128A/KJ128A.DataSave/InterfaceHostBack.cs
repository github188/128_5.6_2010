using System;
using System.Data.SqlClient;
using KJ128A.DataSave.Base;
using System.Data;

namespace KJ128A.DataSave
{
    /// <summary>
    /// ֧���ȱ��Ľӿ�
    /// </summary>
    public class InterfaceHostBack
    {
        /*
        * ί��
        */

        #region [ ί��: ������Ϣ�¼� ]

        /// <summary>
        /// ������Ϣ����
        /// </summary>
        /// <param name="iErrNO">������</param>
        /// <param name="strStackTrace">��ȡ��ǰ�쳣����ʱ���ö�ջ�ϵ�֡���ַ�����ʾ��ʽ</param>
        /// <param name="strSource">��ʶ��ǰ��һ�γ�����Ĵ���</param>
        /// <param name="strMessage">��ȡ������ǰ�쳣����Ϣ</param>
        public delegate void ErrorMessageEventHandler(int iErrNO, string strStackTrace, string strSource, string strMessage);

        /// <summary>
        /// ������Ϣ�¼�
        /// </summary>
        public event ErrorMessageEventHandler ErrorMessage;

        #endregion

        #region [ ���� ]
        /// <summary>
        /// ��SQL Server���ݿ�
        /// </summary>
        public SQLSave sqlSave;

        #endregion

        #region [ ���캯�� ]

        /// <summary>
        /// ���캯��
        /// </summary>
        public InterfaceHostBack()
        {
            sqlSave = new SQLSave();
            sqlSave.ErrorMessage += _ErrorMessage;
        }

        #endregion

        #region [ ί�з��� ]
        /// <summary>
        /// ע�������Ϣ����
        /// </summary>
        /// <param name="iErrNO">������Ϣ���</param>
        /// <param name="strStackTrace">��ȡ��ǰ�쳣����ʱ���ö�ջ�ϵ�֡���ַ�����ʾ��ʽ</param>
        /// <param name="strSource">��ʶ��ǰ��һ�γ�����Ĵ���</param>
        /// <param name="strMessage">��ȡ������ǰ�쳣����Ϣ</param>
        void _ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            if (ErrorMessage != null)
            {
                ErrorMessage(iErrNO, strStackTrace, strSource, strMessage);
            }
        }

        #endregion

        /*
         * SQL���ݿ����
         */

        #region [ �ӿ�: ִ��SQL����洢���̣��ɹ�����True]

        /// <summary>
        /// ������/�����д洢����
        /// </summary>
        /// <param name="flag">true����ʾ������false����ʾ����</param>
        /// <param name="procName">�洢������</param>
        /// <param name="sqlParameters">�洢���̲���</param>
        /// <returns>falseִ��ʧ��</returns>
        public bool ExecuteSql(bool flag, string procName, SqlParameter[] sqlParameters)
        {
            
             return sqlSave.ExecuteSql(flag, procName, sqlParameters);
            
        }

        #endregion

        #region [ �ӿ�: ִ�д洢���̣�����DataTable ]

        /// <summary>
        /// ִ�д洢���̣�����DataTable
        /// </summary>
        /// <param name="flag">true����ʾ������false����ʾ����</param>
        /// <param name="procName">�洢������</param>
        /// <param name="sqlParameters">�洢���̲���</param>
        /// <returns>�ɹ��򷵻�DataTable��ʧ���򷵻�Null</returns>
        public DataTable GetDataTabel(bool flag, string procName, SqlParameter[] sqlParameters)
        {
            
                return sqlSave.GetDataTabel(flag, procName, sqlParameters);
            
        }

        #endregion

        #region [�������ж����ݿ�����]
        /// <summary>
        /// �ж����ݿ�����״̬
        /// </summary>
        /// <param name="flag">true ����  false ����</param>
        public void IsConnect(bool flag)
        {
            sqlSave.IsConnection(flag);
        }
        #endregion

        #region [ �ӿ�:�ر����ݿ������ ]

        /// <summary>
        ///  �ر����ݿ������
        /// </summary>
        public bool CloeseConnect()
        {
           
                return sqlSave.CloseSQLConnect();
            
        }

        #endregion
    }
}
