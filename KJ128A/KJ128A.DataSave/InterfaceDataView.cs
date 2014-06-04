using System.Data;
using KJ128A.DataSave.Base;

namespace KJ128A.DataSave
{
    /// <summary>
    /// ֧��DataView�Ľӿ�
    /// </summary>
    public  class InterfaceDataView
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
        /// Access�����ӿ�
        /// </summary>
        public AccessInterface accInteface = new AccessInterface();

        #endregion

        #region [ ���캯�� ]

        /// <summary>
        /// ���캯��
        /// </summary>
        public InterfaceDataView()
        {
            accInteface.ErrorMessage += accInteface_ErrorMessage;
        }

        #endregion

        #region  [ ί�з��� ]

        /// <summary>
        /// ע�������Ϣ����
        /// </summary>
        /// <param name="iErrNO">������Ϣ���</param>
        /// <param name="strStackTrace">��ȡ��ǰ�쳣����ʱ���ö�ջ�ϵ�֡���ַ�����ʾ��ʽ</param>
        /// <param name="strSource">��ʶ��ǰ��һ�γ�����Ĵ���</param>
        /// <param name="strMessage">��ȡ������ǰ�쳣����Ϣ</param>
        void accInteface_ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            if (ErrorMessage != null)
            {
                ErrorMessage(iErrNO, strStackTrace, strSource, strMessage);
            }
        }

        #endregion

        #region  [ �ӿ�: ��֪һ�����ݿ����ƣ�����һ���������� ]

        /// <summary>
        /// ��֪һ�����ݿ����ƣ�����һ����������
        /// </summary>
        /// <param name="strMDBName">���ݿ����ƣ����磺"2008-1-25.mdb"</param>
        /// <returns>��������,����ʧ�ܷ��ؿ�</returns>
        public string[] GetTableName(string strMDBName)
        {
           
                return accInteface.GetTableName(strMDBName);
           
        }

        #endregion

        #region  [ �ӿ�: ��֪���ݿ����ƺͱ��������ر��е����� ]

        /// <summary>
        /// ��֪���ݿ����ƺͱ��������ر��е�����
        /// </summary>
        /// <param name="strMDBName">���ݿ�����,��"2008-1-30.mdb"</param>
        /// <param name="strTableName">��������"NewData09"</param>
        /// <returns>���ݱ�</returns>
        public DataTable DataSelectAll(string strMDBName, string strTableName)
        {
            
                return accInteface.DataSelectAll(strMDBName, strTableName);
            
        }

        #endregion 

        #region [ �ӿ�:�ر����ݿ������ ]

        /// <summary>
        ///  �ر����ݿ������
        /// </summary>
        public bool CloeseConnect()
        {
            
                return accInteface.CloeseConnect();
            
        }

        #endregion
    }
}
