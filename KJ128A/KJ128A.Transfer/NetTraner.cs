using System.Text.RegularExpressions;
using System;
using System.Runtime.InteropServices;
namespace KJ128A.Transfer
{
    /// <summary>
    /// ���紫��
    /// </summary>
    public class NetTraner
    {

        #region [ ����:ί�� ] ������Ϣ�¼�

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

        #region [ ����: ί�� ] ���ݵִ���Ϣ�¼�

        /// <summary>
        /// ���ݵִ�����
        /// </summary>
        /// <param name="dataInfo">������Ϣ</param>
        /// <param name="result">����ִ�н��</param>
        public delegate void DataReceivedEventHandler(byte[] dataInfo, out bool result);

        /// <summary>
        /// ���ݵִ��¼�
        /// </summary>
        public event DataReceivedEventHandler DataReceived;

        #endregion

        #region [ ����: ί�� ] ���ͳ�������

        /// <summary>
        /// ���ͳ������� �� InitSendSocket ������
        /// </summary>
        public delegate void InitSendLinkEventHandler();

        /// <summary>
        /// ���ͳ��������¼�
        /// </summary>
        public event InitSendLinkEventHandler InitSendLink;

        #endregion

        #region [ ����: ί�� ] ������������

        /// <summary>
        /// ������������ �� Start ������
        /// </summary>
        public delegate void InitListenLinkEventHandler();

        /// <summary>
        /// �������������¼�
        /// </summary>
        public event InitListenLinkEventHandler InitListenLink;

        #endregion

        #region [ ����: ί�� ] �������ӶϿ�

        /// <summary>
        /// �������ӶϿ�
        /// </summary>
        public delegate void CutSendLinkEventHandler();

        /// <summary>
        /// �������ӶϿ�
        /// </summary>
        public event CutSendLinkEventHandler CutSendLink;

        #endregion

        #region [ ����: ������� ]

        private string sendIp;
        private int selfPort, sendPort;
        private NetAccess netAccess;

        #endregion

        #region [ ���캯��: ʵ��������ӿ� ]

        /// <summary>
        /// ��ʼ���������Ӳ���
        /// </summary>
        /// <param name="strIP">���ջ�IP</param>
        /// /// <param name="iSendPort">���ջ����Ķ˿�</param>
        /// <param name="iLinstenPort">���������˿�</param>
        public NetTraner(string strIP, int iSendPort, int iLinstenPort)
        {
            if (!Regex.IsMatch(strIP, @"^((0|(?:[1-9]\d{0,1})|(?:1\d{2})|(?:2[0-4]\d)|(?:25[0-5]))\.){3}((?:[1-9]\d{0,1})|(?:1\d{2})|(?:2[0-4]\d)|(?:25[0-5]))$"))
            {
                ErrorMessage(3100003, "123", "[NetAccess:SendTcpFun]", "ָ��IP��Ч");
                return;
            }
            sendIp = strIP;
            selfPort = iLinstenPort;    // ���������˿�
            sendPort = iSendPort;       // ���ջ����˿�
            // ʵ����netAccess
            netAccess = new NetAccess();
            // ����    �ֽ�1048576
            netAccess.StartListen(strIP, selfPort, iSendPort, 10485760);

            netAccess.ErrorMessage += netAccess_ErrorMessage;
            netAccess.DataReceived += netAccess_DataReceived;
            netAccess.InitSendLink += netAccess_InitSendLink;
            netAccess.InitListenLink += netAccess_InitListenLink;
            netAccess.CutSendLink += netAccess_CutSendLink;
        }

        void netAccess_CutSendLink()
        {
            if (CutSendLink != null)
            {
                CutSendLink();
            }
        }

        /// <summary>
        /// �������������ϴ���
        /// </summary>
        void netAccess_InitListenLink()
        {
            if (InitListenLink != null)                       //�¼���ע��ʱ
            {
                InitListenLink();
            }
        }

        /// <summary>
        /// ���ͳ��������ϴ���
        /// </summary>
        void netAccess_InitSendLink()
        {
            if (InitSendLink != null)                       //�¼���ע��ʱ
            {
                InitSendLink();
            }
        }

        /// <summary>
        /// ���ݵִ�
        /// </summary>
        /// <param name="dataInfo">������Ϣ</param>
        /// <param name="result">ִ�н��</param>
        void netAccess_DataReceived(byte[] dataInfo, out bool result)
        {
            result = true;
            if (DataReceived != null)                       //�¼���ע��ʱ
            {
                if (System.Text.Encoding.Default.GetString(dataInfo) == "ko")
                    return;
                DataReceived(dataInfo, out result);
            }
        }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="iErrNO">������</param>
        /// <param name="strStackTrace">��ȡ��ǰ�쳣����ʱ���ö�ջ�ϵ�֡���ַ�����ʾ��ʽ</param>
        /// <param name="strSource">��ʶ��ǰ��һ�γ�����Ĵ���</param>
        /// <param name="strMessage">��ȡ������ǰ�쳣����Ϣ</param>
        void netAccess_ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            if (ErrorMessage != null)                       //�¼���ע��ʱ
            {
                ErrorMessage(iErrNO, strStackTrace, strSource, strMessage);
            }
        }

        #endregion

        #region [ �ӿ�: ������Ϣ ]

        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="dataBytes">��Ϣ����</param>
        public bool SendMessage(byte[] dataBytes)
        {
            return netAccess.SendTcpFun(dataBytes, 50);
        }

        #endregion

        #region [ �ӿ�: ���Ͷ�ʱ���� ]

        /// <summary>
        /// ����һ���η�����������
        /// </summary>
        /// <param name="dataBytes"></param>
        /// <returns></returns>
        public bool SendOnce(byte[] dataBytes)
        {
            return netAccess.SendTcpFun(dataBytes);
        }

        #endregion

        #region [ ����: ������ ]

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="iErrNO">������</param>
        /// <param name="isShowMsgBox">�Ƿ��� MessageBox ����ʾ</param>
        /// <param name="isExit">�Ƿ��˳�</param>
        public void ErrorMessageFun(int iErrNO, bool isShowMsgBox, bool isExit)
        {
            string strErrMsg = string.Empty;        // ������Ϣ����
            switch (iErrNO)
            {
                case 2100003:
                    strErrMsg = "ָ��IP��Ч";
                    break;
                case 2100048:
                    strErrMsg = "�˿��ѱ�ռ��";
                    break;
                case 7100053:
                    strErrMsg = "Զ�̻����Ͽ�����";
                    break;
                case 7100054:
                    strErrMsg = "Զ�̻����Ͽ�����";   //Զ������ǿ�ȹر���һ�����е�����
                    break;
                case 7100057:
                    strErrMsg = "���ͻ�������ݵ�����û�б�����";
                    break;
                case 7100060:
                    strErrMsg = "���ӳ�ʱԶ�̻�������ʧ��";
                    break;
                case 7100061:
                    strErrMsg = "ͨѶ����δ����";
                    break;
                case 7100065:
                    strErrMsg = "���粻ͨ�����δ����";
                    break;
                case 6100002:
                    strErrMsg = "�������ݲ���Ϊ��";
                    break;
                default: break;
            }
        }

        #endregion

        #region [ ����: �ͷ� ]

        /// <summary>
        /// �ͷ�tcp����
        /// </summary>
        public void Dispose()
        {
            netAccess.Dispose();
        }

        #endregion

        /// <summary>
        /// ���ñ���ʱ��
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public extern static int SetLocalTime(ref SystemTime st);

        #region [ �ṹ: SystemTime ]

        /// <summary>
        /// SystemTime
        /// </summary>
        public struct SystemTime
        {
            /// <summary>
            /// wYear
            /// </summary>
            public short wYear;
            /// <summary>
            /// wMonth
            /// </summary>
            public short wMonth;
            /// <summary>
            /// wDayOfWeek
            /// </summary>
            public short wDayOfWeek;
            /// <summary>
            /// wDay
            /// </summary>
            public short wDay;
            /// <summary>
            /// wHour
            /// </summary>
            public short wHour;
            /// <summary>
            /// wMinute
            /// </summary>
            public short wMinute;
            /// <summary>
            /// wSecond
            /// </summary>
            public short wSecond;
            /// <summary>
            /// wMilliseconds
            /// </summary>
            public short wMilliseconds;

        }
        #endregion

        #region [ ����: �޸ļ����ʱ�� ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strTime"></param>
        /// <returns></returns>
        private bool EditTime(string strTime)
        {
            try
            {
                SystemTime systNew = new SystemTime();

                string[] sArray = strTime.Split(' ');
                string[] sArrYear = sArray[0].ToString().Split('-');
                string[] sArrTime = sArray[1].ToString().Split(':');

                systNew.wYear = Convert.ToInt16(sArrYear[0].ToString());
                systNew.wMonth = Convert.ToInt16(sArrYear[1].ToString());
                systNew.wDay = Convert.ToInt16(sArrYear[2].ToString());
                systNew.wHour = Convert.ToInt16(sArrTime[0].ToString());
                systNew.wMinute = Convert.ToInt16(sArrTime[1].ToString());
                systNew.wSecond = Convert.ToInt16(sArrTime[2].ToString());
                int result = SetLocalTime(ref systNew);


                if (result == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                if (ex.Message == "���Զ�ȡ��д���ܱ������ڴ档��ͨ��ָʾ�����ڴ����𻵡�")
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region [ ʱ��ͬ�� ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strTime">yyyy-MM-dd HH:mm:ss</param>
        /// <returns></returns>
        public bool SyncTime(string strTime)
        {
            return EditTime(strTime);
        }

        #endregion

    }
}



