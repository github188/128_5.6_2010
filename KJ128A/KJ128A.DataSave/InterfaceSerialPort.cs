using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Threading;
using KJ128A.BatmanAPI;
using KJ128A.DataAnalyzing;
using KJ128A.DataSave.Base;
//using KJ128A.HostBack;

namespace KJ128A.DataSave
{

    /// <summary>
    /// ���ݿ�洢
    /// </summary>
    public class InterfaceSerialPort
    {
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

        //private readonly AccessInterface accInter = new AccessInterface();

        #endregion

        #region [ ���캯�� ]

        /// <summary>
        /// ���캯��
        /// </summary>
        public InterfaceSerialPort()
        {
            //accInter.ErrorMessage += accInter_ErrorMessage;
        }

        #endregion

        #region [ ������Ϣ���� ]

        /// <summary>
        /// ������Ϣ����
        /// </summary>
        /// <param name="iErrNO"></param>
        /// <param name="strStackTrace"></param>
        /// <param name="strSource"></param>
        /// <param name="strMessage"></param>
        private void accInter_ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            //if (ErrorMessage != null)
            //{
            //    ErrorMessage(iErrNO, strStackTrace, strSource, strMessage);
            //}
        }

        #endregion

        /*
         *  �ӿ� 
         */
        #region [ �ӿ�: ���ݵִ� ]
        /// <summary>
        /// ���ݵִ�
        /// </summary>
        /// <param name="cmdBytes"></param>
        /// <param name="blnHost">True:����;False:����</param>
        /// <returns></returns>
        public bool DataReceived(byte[] cmdBytes, bool blnHost)
        {
            bool flag=true;
            if (blnHost)             //����
            {
                //д��Access���ݿ��ԭʼ��OrgData����������ͬ����IsSync����ΪFalse����ͬ���У�IsSyncing����ΪFalse
                //flag = accInter.InsertData_OrgData(DateTime.Now, cmdBytes, false, 0);

            }
            else                    //����
            {
                //д��Access���ݿ�ķ��ͱ�NewData��
                //flag = accInter.InsertData_NewData(DateTime.Now.ToString("yyyyMMddHHmmssfff"), cmdBytes, false, false, 0);

            }

            return flag;
            
        }

        /// <summary>
        /// ���ݵִ�������ݿ⣩
        /// </summary>
        /// <param name="cmdBytes"></param>
        /// <returns></returns>
        public bool DataReceived(byte[] cmdBytes)
        {
            bool falg = true;
            //falg = accInter.InsertData_Config(DateTime.Now.ToString("yyyyMMddHHmmssfff"), cmdBytes, false, 0);
            return falg;

        }
        #endregion


        #region [ �ӿ�: �˳��߳� ]

        /// <summary>
        /// �˳�
        /// </summary>
        /// <returns></returns>
        public bool Exit()
        {
            //�ر� Access���ݿ�����
            
                //accInter.CloeseConnect();
            
            return true;
        }

        #endregion

    }
}