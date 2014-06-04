using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128A.BatmanAPI
{
    /// <summary>
    /// �ṹ��: ��վ��Ϣ
    /// </summary>
    public struct MemStation
    {
        #region [ ���� ] ���

        private int _ID;

        /// <summary>
        /// ��ȡ�����û�վ���
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        #endregion

        #region [���ԣ����ʹ���]
        private int _saveCount;
        /// <summary>
        /// ���Ϻ��л��������������
        /// </summary>
        public int SaveCount
        {
            get { return _saveCount; }
            set { _saveCount = value; }
        }
        #endregion

        #region [ ���� ] ��ַ��

        private int _Address;

        /// <summary>
        /// ��ַ��
        /// </summary>
        public int Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        #endregion

        #region [ ���� ] �汾��

        private int _Ver;

        /// <summary>
        /// �汾��
        /// </summary>
        public int Ver
        {
            get { return _Ver; }
            set { _Ver = value; }
        }

        #endregion

        #region [ ���� ] �����

        private int _Group;

        /// <summary>
        /// ��ȡ�����û�վ�����
        /// </summary>
        public int Group
        {
            get { return _Group; }
            set { _Group = value; }
        }

        #endregion

        #region [ ���� ] ״̬

        private int _State;

        /// <summary>
        /// ״̬
        /// </summary>
        public int State
        {
            get { return _State; }
            set
            {
                _State = value;
                switch (_State)
                {
                    case 3000:
                        _CState = "��ʼ��";
                        break;

                    case 5000:
                        _CState = "����";
                        break;

                    case -10000:
                        _CState = "�ȱ�ͨѶ";
                        break;

                    case -1000:
                        _CState = "����";
                        break;

                    //case -1000:
                    //    _CState = "ͨѶ����";
                    //    break;

                    case 0:
                        _CState = "δ��ʼ��";
                        break;

                    //case 2000:
                    //    _CState = "Ѳ��";
                    //    break;

                    //case 2100:
                    //    _CState = "��Ϣȷ��";
                    //    break;

                    //case 2200:
                    //    _CState = "��ѯ�汾";
                    //    break;

                    //case 2300:
                    //    _CState = "Уʱ";
                    //    break;

                    //case 2400:
                    //    _CState = "����Уʱ";
                    //    break;

                    //case 2500:
                    //    _CState = "��վ����";
                    //    break;

                    default:
                        _CState = "����";
                        break;

                }
            }
        }

        #endregion

        #region [ ���� ] ״̬����

        private string _CState;

        /// <summary>
        /// ״̬����
        /// </summary>
        public string CState
        {
            get { return _CState; }
            set { _CState = value; }
        }

        #endregion

        #region [����]  ���͵�״̬
        private int _Cmd;
        /// <summary>
        /// ���͵�״̬
        /// </summary>
        public int SCmd
        {
            get { return _Cmd; }
            set { _Cmd = value; }
        }
        #endregion

        #region [ ���� ] �޻���

        private int _NoAnswer;

        /// <summary>
        /// �޻���
        /// </summary>
        public int NoAnswer
        {
            get { return _NoAnswer; }
            set { _NoAnswer = value; }
        }

        #endregion

        #region [���ԣ��Ƿ񶨵�Ѳ��]
        private bool _IsPointSelect;
        /// <summary>
        /// �Ƿ񶨵�Ѳ��
        /// </summary>
        public bool IsPointSelect
        {
            get { return _IsPointSelect; }
            set { _IsPointSelect = value; }
        }
        #endregion [���ԣ��Ƿ񶨵�Ѳ��]

        #region [���ԣ��Ƿ�˫��ͨѶ]
        private bool _isTwo;
        /// <summary>
        /// �Ƿ�˫��ͨѶ
        /// </summary>
        public bool IsTwo
        {
            get { return _isTwo; }
            set { _isTwo = value; }
        }
        #endregion

        #region �����ԣ�����һ��ʱ���ʱУʱ��
        private DateTime m_timeCheckOut;
        /// <summary>
        /// ����һ��ʱ���ʱУʱ
        /// </summary>
        public DateTime TimeCheckOut
        {
            get { return m_timeCheckOut; }
            set { m_timeCheckOut = value; }
        }
        #endregion

        #region �����ԣ�Զ�������ַ��
        private string m_strIpAddress;
        /// <summary>
        /// Զ�������ַ
        /// </summary>
        public string IpAddress
        {
            get { return m_strIpAddress; }
            set { m_strIpAddress = value; }
        }
        #endregion �����ԣ�Զ�������ַ��

        #region �����ԣ�Զ������˿ڡ�
        private int m_port;
        /// <summary>
        /// Զ������˿�
        /// </summary>
        public int Port
        {
            get { return m_port; }
            set { m_port = value; }
        }
        #endregion �����ԣ�Զ������˿ڡ�

        #region [���ԣ���վ״̬]
        private int _StationModel;
        /// <summary>
        /// ��վ״̬
        /// </summary>
        public int StationModel
        {
            get { return _StationModel; }
            set { _StationModel = value; }
        }
        #endregion

        // �̶�����������

        #region [ ����:���� ] ��ȡ�汾��

        private byte[] _CmdVersion;

        /// <summary>
        /// ��ȡ�汾��
        /// </summary>
        public byte[] CmdVersion
        {
            get { return _CmdVersion; }
            set { _CmdVersion = value; }
        }

        #endregion

        #region [ ����:���� ] Ѳ��

        private byte[] _CmdPolling;

        /// <summary>
        /// Ѳ��
        /// </summary>
        public byte[] CmdPolling
        {
            get { return _CmdPolling; }
            set { _CmdPolling = value; }
        }

        #endregion

        #region [ ����:���� ] ��Ϣȷ��

        private byte[] _CmdPollingRight;

        /// <summary>
        /// ��Ϣȷ��
        /// </summary>
        public byte[] CmdPollingRight
        {
            get { return _CmdPollingRight; }
            set { _CmdPollingRight = value; }
        }

        #endregion

        #region [ ����:���� ] ����

        private byte[] _CmdReset;

        /// <summary>
        /// ��������
        /// </summary>
        public byte[] CmdReset
        {
            get { return _CmdReset; }
            set { _CmdReset = value; }
        }

        #endregion

        #region [���ԣ�����] ˫������
        private byte[] _cmdTwo;
        /// <summary>
        /// ˫������
        /// </summary>
        public byte[] CmdTwo
        {
            get { return _cmdTwo; }
            set { _cmdTwo = value; }
        }
        #endregion


        //#region ��Czlt-2011-12-20 ��վ������������վ��

        ///// <summary>
        ///// Czlt-2011-12-20 ��վ��Ϣ
        ///// </summary>
        //private bool _isStaFault;

        ///// <summary>
        ///// Czlt-2011-12-20 ��վ����ʱ����
        ///// </summary>
        //public bool IsStaFault
        //{
        //    get { return _isStaFault; }
        //    set { _isStaFault = value; }
        //}

        //#endregion
    }
}
