using System;
using System.Text;
using System.Threading;
using KJ128A.Controls.Batman;
using KJ128A.Protocol;
using System.IO;

namespace KJ128A.Ports
{
    /// <summary>
    /// ����������շ�װ
    /// </summary>
    public class KJSerialPort : KJ128N_Port
    {

        #region [ ���� ]

        /// <summary>
        /// ��������ʱ����Ѳ������ʱ�䣨���룩
        /// </summary>
        private int intHostTime = 1200;

        /// <summary>
        /// ��������ʱ����Ѳ������ʱ�䣨���룩
        /// </summary>
        private int intBackerTime = 1900;

        /// <summary>
        /// �������ʹ���
        /// </summary>
        private int backerSendCount = 0;

        private int sqlSend = 0;
        #endregion

        #region [ ���� ] �Ƿ����ݱ���

        private bool _IsSaveData;

        /// <summary>
        /// �Ƿ����ݱ���
        /// </summary>
        public bool IsSaveData
        {
            get { return _IsSaveData; }
            set { _IsSaveData = value; }
        }

        #endregion

        #region [ ���� ] �Ƿ��ȱ�ͨѶ��

        private int _IsMark;

        /// <summary>
        /// �Ƿ����ݱ���
        /// </summary>
        public int IsMark
        {
            get { return _IsMark; }
            set { _IsMark = value; }
        }

        #endregion

        #region [���ԣ��Ƿ��������ȱ�]
        private bool _IsStartHostBacker;
        /// <summary>
        /// �Ƿ��������ȱ�
        /// </summary>
        public bool IsStartHostBacker
        {
            get { return _IsStartHostBacker; }
            set { _IsStartHostBacker = value; }
        }
        #endregion [���ԣ��Ƿ��������ȱ�]

        #region [���ԣ��Ƿ�����/����]
        private bool _IsHost;
        /// <summary>
        /// �Ƿ�����/����  trueΪ����  falseΪ����
        /// </summary>
        public bool IsHost
        {
            get { return _IsHost; }
            set { _IsHost = value; }
        }
        #endregion [���ԣ��Ƿ�����/����]

        #region [���ԣ������Ƿ�����]
        /// <summary>
        /// �����Ƿ�����
        /// </summary>
        private bool _isNetWork;
        /// <summary>
        /// �����Ƿ�����
        /// </summary>
        public bool IsNetWork
        {
            get { return _isNetWork; }
            set { _isNetWork = value; }
        }
        #endregion

        #region �����ԣ����ݿ��Ƿ����ӳɹ���
        private bool _isDatabaseConnect;
        /// <summary>
        /// �������ݿ��Ƿ����ӳɹ�
        /// </summary>
        public bool IsDataBaseConnect
        {
            get { return _isDatabaseConnect; }
            set { _isDatabaseConnect = value; }
        }
        #endregion

        #region �����ԣ��Ƿ��ڴ����ݿ⡿
        private bool _isSaveSql;
        public bool IsSaveSql
        {
            get { return _isSaveSql; }
            set { _isSaveSql = value; }
        }
        #endregion

        #region �����ԣ��ȱ��Ƿ��������С�
        private bool m_RbSend;
        public bool RbSend
        {
            get { return m_RbSend; }
            set { m_RbSend = value; }
        }
        #endregion

        #region [ ���캯�� ]

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="index">������</param>
        /// <param name="strPortName">��������</param>
        /// <param name="iGroup">��վ����</param>
        /// <param name="iMark">������־</param>
        public KJSerialPort(int index, string strPortName, int iGroup, int iMark)
        {
            Index = index;
            PortName = strPortName;
            Group = iGroup;
            Mark = iMark;
            intHostTime = base.sendTime;
            intBackerTime = base.sendTime + 400;

        }

        #endregion

        #region [ ����: ί�� ] ��վ״̬�ı�

        /// <summary>
        /// ��վ״̬�ı�ί������
        /// </summary>
        public delegate void StationStateChangedEventHandler(int index, int iAddress, int iState, string strStateRemark);

        /// <summary>
        /// ��վ״̬�ı�
        /// </summary>
        public event StationStateChangedEventHandler StationStateChanged;

        #endregion

        #region [ ����: ί�� ] ��������״̬�л�

        /// <summary>
        /// ��������״̬�л�ί������
        /// </summary>
        public delegate void MarkStateChangedEventHandler(int index, int IsMark);

        /// <summary>
        /// ��������״̬�л�
        /// </summary>
        public event MarkStateChangedEventHandler MarkStateChanged;

        #endregion

        #region [ ����: ί�� ] ���ݵִ�

        /// <summary>
        /// ���ݵִ�ί������
        /// </summary>
        /// <param name="cmdReceived"></param>
        /// <param name="iMark"></param>
        public delegate void DataReceivedEventHandler(byte[] cmdReceived, int iMark, int iGroup);

        /// <summary>
        /// ���ݵִ�
        /// </summary>
        public event DataReceivedEventHandler DataReceived;

        #endregion

        #region [ ����: ����ָ�� ]

        private int iStationLoc = 0;        // ��ǰ�����Ļ�վλ��

        /// <summary>
        /// ����ָ��
        /// </summary>
        public void SendCmd()
        {
            try
            {
                if (_isDatabaseConnect == true && m_RbSend == true)//���ݿ����ӷ���
                {
                    if (_isSaveSql == false)//���ݿ��Ƿ����ڱ���,�����������
                    {
                        try
                        {
                            bool isSend = false;

                            #region �Ƿ�������
                            //�Ƿ������ȱ�
                            if (_IsStartHostBacker)
                            {
                                if (_IsHost)//����
                                {
                                    isSend = true;
                                }
                                else//����
                                {
                                    if (_isNetWork)//��������
                                    {
                                        isSend = false;

                                        // �����ǰ״̬���Ϊ���ȱ�״̬����֪ͨͨѶ�����ȱ��Ѿ��л����Խ�ΰ�ȱ��߼���Ҫ�õ���
                                        if (IsMark == 0 || IsMark == 2)
                                        {
                                            IsMark = 1;
                                            MarkStateChanged(1, IsMark);
                                            base.timer.Interval = base.sendTime + 400;
                                        }

                                        // �������һ����վ���ȱ������϶��ô������л�վ�������ȱ�״̬��
                                        for (int i = 0; i < _Stations.Length; i++)
                                        {
                                            if (_Stations[i].State != -10000)
                                            {
                                                _Stations[i].State = -10000;
                                                StationStateChanged(1, _Stations[i].Address, _Stations[i].State, _Stations[i].CState);
                                                Thread.Sleep(10);
                                            }
                                        }
                                        for (int i = 0; i < _TempStations.Length; i++)
                                        {
                                            if (_TempStations[i].State != -10000)
                                            {
                                                _TempStations[i].State = -10000;
                                            }
                                        }

                                    }
                                    else//���粻����
                                    {
                                        isSend = true;
                                    }
                                }
                            }
                            else//�������ȱ�
                            {
                                isSend = true;
                            }
                            #endregion

                            if (isSend)
                            {
                                timer.Enabled = true;
                                SendCmd(ref iStationLoc);
                            }
                            else
                            {
                                timer.Enabled = true;
                            }
                        }
                        catch { timer.Enabled = true; }
                    }
                    else
                    {
                        timer.Enabled = true;
                    }
                }
                else//���ݿ�δ����
                {
                    timer.Enabled = true;
                }
            }
            catch { timer.Enabled = true; }
        }

        #endregion

        #region [ ����: ������� ]

        /// <summary>
        /// �������
        /// </summary>
        public void CmdError(string strErr, int stationModel)
        {
            try
            {
                switch (stationModel)
                {
                    case 1:
                    case 3:
                        // ��ȡ����
                        int iErrCmd = iEndLoc - iStartLoc + 1;
                        byte[] cmdErr = new byte[iErrCmd];
                        if (iStartLoc >= 0)
                        {
                            for (int k = 0; k < iErrCmd; k++)
                            {
                                cmdErr[k] = byteBuffer[iStartLoc + k];
                            }
                        }
                        // ��ʾ������Ϣ
                        //if (RTxtMsge != null && cmdErr.Length > 0)
                        //{
                        //    RTxtMsge.WriteTxt(cmdErr, strErr, true, 0);
                        //}
                        for (int i = 0; i < byteBuffer.Length; i++)
                        {
                            byteBuffer[i] = (byte)0;
                        }

                        break;
                    default:
                        for (int i = 0; i < byteBuffer.Length; i++)
                        {
                            byteBuffer[i] = (byte)0;
                        }
                        // ��ʾ������Ϣ
                        //if (RTxtMsge != null)
                        //{
                        //    RTxtMsge.WriteTxt(new byte[1], strErr, true, 0);
                        //}
                        break;
                }

            }
            catch { }

            cmdNewBytes = null;


            iStartLoc = -1;
            iEndLoc = -1;
            iEndStartLoc = -1;

            // ������һ��ָ��
            if (!_Stations[iStationLoc].IsPointSelect)
            {
                iStationLoc++;
            }
            SendCmd();
        }

        #endregion

        #region [ ���ݵִ� ]

        /// <summary>
        /// ���ݵִ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            base.serialPort_DataReceived(sender, e);
            try
            {
                // ���û��һ������ָ��򲻴���
                if (cmdNewBytes == null)
                {
                    if (timer.Enabled == false)
                    {
                        timer.Enabled = true;
                    }
                    return;
                }

                // ��������С��5���򲻴���
                if (cmdNewBytes.Length < 3)
                {
                    if (timer.Enabled == false)
                    {
                        timer.Enabled = true;
                    }
                    return;
                }

                // ��������ָ��
                int iSAddress = cmdNewBytes[0];     // ��վ��
                int iCmdNO = cmdNewBytes[1];        // �����
                int iCmdLength = 0;
                int iOldState = 0;
                switch (_Stations[iStationLoc].StationModel)
                {
                    case 1:
                    case 3:
                        #region [ ��������ָ�� ]

                        // ��������ָ��
                        int iMark = cmdNewBytes[2];         // ������־

                        // ���������
                        if (iCmdNO == 20 || iCmdNO == 22)
                        {
                            iCmdLength = cmdNewBytes[3] + cmdNewBytes[4] * 256 + 7;
                        }
                        else
                        {
                            iCmdLength = 5;
                        }

                        if (_Stations == null || _Stations.Length <= 0)
                        {
                            if (_TempStations != null && _TempStations.Length > 0)
                            {
                                _Stations = _TempStations;
                            }
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        if (iMark == 0)
                        {
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }
                        // ��֤������־�Ƿ���ȷ
                        if (iMark != Mark)
                        {
                            // ��������ڻ�վ���򲻴���
                            if (_Stations.Length == 0)
                            {
                                if (timer.Enabled == false)
                                {
                                    timer.Enabled = true;
                                }
                                return;
                            }
                            if (_IsStartHostBacker)
                            {
                                if (!_IsHost)
                                {
                                    backerSendCount = 0;
                                    // �����ȱ�״̬ʱִ����������
                                    if (_Stations[iStationLoc].State != -10000)
                                    {
                                        if (_Stations[iStationLoc].State != -10100)
                                        {
                                            _Stations[iStationLoc].State = -10100;
                                            _Stations[iStationLoc].NoAnswer = 0;
                                        }
                                        else
                                        {
                                            _Stations[iStationLoc].NoAnswer--;

                                            // ���� 2 �λر�������ʱ����ʾ�ȱ�
                                            _Stations[iStationLoc].State = -10000;

                                            //// Error: ����߼�����������
                                            if (_Stations[iStationLoc].NoAnswer == -2)
                                            {
                                                if (StationStateChanged != null)
                                                {
                                                    StationStateChanged(Index, _Stations[iStationLoc].Address, _Stations[iStationLoc].State, _Stations[iStationLoc].CState);
                                                }
                                            }


                                            // �������һ����վ���ȱ������϶��ô������л�վ�������ȱ�״̬��
                                            for (int i = 0; i < _Stations.Length; i++)
                                            {
                                                _Stations[i].State = -10000;
                                            }
                                            for (int i = 0; i < _TempStations.Length; i++)
                                            {
                                                _TempStations[i].State = -10000;
                                            }



                                            // �����ǰ״̬���Ϊ���ȱ�״̬����֪ͨͨѶ�����ȱ��Ѿ��л����Խ�ΰ�ȱ��߼���Ҫ�õ���
                                            if (IsMark == 0 || IsMark == 2)
                                            {
                                                IsMark = 1;
                                                MarkStateChanged(Index, IsMark);
                                                base.timer.Interval = base.sendTime + 400;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (IsMark == 0 || IsMark == 2)
                                        {
                                            IsMark = 1;
                                            // �������һ����վ���ȱ������϶��ô������л�վ�������ȱ�״̬��
                                            for (int i = 0; i < _Stations.Length; i++)
                                            {
                                                _Stations[i].State = -10000;
                                            }
                                            for (int i = 0; i < _TempStations.Length; i++)
                                            {
                                                _TempStations[i].State = -10000;
                                            }
                                            MarkStateChanged(Index, IsMark);
                                            base.timer.Interval = base.sendTime + 400;
                                        }
                                    }
                                }
                                else
                                {
                                    timer_Elapsed(null, null);
                                }
                            }

                            #region [ ���ñ�־λ ]

                            // �������еı�־λ
                            iStartLoc = -1;
                            iEndLoc = -1;
                            iEndStartLoc = -1;

                            #endregion

                            // �ͷ���Ч����
                            cmdNewBytes = null;
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }
                        else
                        {
                            // �����ǰ״̬���Ϊ���ȱ�״̬����֪ͨͨѶ�����ȱ��Ѿ��л����Խ�ΰ�ȱ��߼���Ҫ�õ���
                            if (IsMark == 0 || IsMark == 1)
                            {

                                if (_IsStartHostBacker)
                                {
                                    if (!_IsHost)
                                    {
                                        // �������һ����վ���ȱ������϶��ô������л�վ�������ȱ�״̬��
                                        for (int i = 0; i < _Stations.Length; i++)
                                        {
                                            _Stations[i].State = 0;
                                        }
                                        for (int i = 0; i < _TempStations.Length; i++)
                                        {
                                            _TempStations[i].State = 0;
                                        }
                                        backerSendCount++;
                                        if (backerSendCount >= 30)
                                        {
                                            IsMark = 2;
                                            MarkStateChanged(Index, IsMark);
                                        }
                                    }
                                    else
                                    {
                                        IsMark = 2;
                                    }
                                }
                                else
                                {
                                    IsMark = 2;
                                }
                                base.timer.Interval = base.sendTime;
                            }
                        }

                        // ��֤�����
                        if (cmdNewBytes.Length != iCmdLength)
                        {
                            CmdError(" [���ȴ���]", _Stations[iStationLoc].StationModel);
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        // ��֤��վ���Ƿ���ȷ
                        if (iSAddress != _Stations[iStationLoc].Address)
                        {
                            CmdError(" [�����վ�Ŵ�]", _Stations[iStationLoc].StationModel);
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        // ��֤������Ƿ���ȷ iCmdNO != CmdNO
                        if (iCmdNO != _Stations[iStationLoc].SCmd && iCmdNO != 24 && iCmdNO != 33)
                        {
                            CmdError(" [����Ŵ�]", _Stations[iStationLoc].StationModel);
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        // Crc У��
                        byte[] cmdCrcNewBytes = new byte[cmdNewBytes.Length + 5];
                        for (int i = 0; i < 5; i++)
                        {
                            cmdCrcNewBytes[i] = 238;
                        }
                        for (int i = 5; i < cmdCrcNewBytes.Length; i++)
                        {
                            cmdCrcNewBytes[i] = cmdNewBytes[i - 5];
                        }
                        byte[] crcByte = CRCVerify.Crc(cmdCrcNewBytes, cmdCrcNewBytes.Length - 2, 0);
                        if (crcByte[0] != cmdCrcNewBytes[cmdCrcNewBytes.Length - 1] || crcByte[1] != cmdCrcNewBytes[cmdCrcNewBytes.Length - 2])
                        {
                            CmdError(" [CRCЧ���] ", _Stations[iStationLoc].StationModel);
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        if (RTxtMsg != null)
                        {
                            // ��ʾ����
                            RTxtMsg.WriteTxt(cmdNewBytes, " RX", true, 0);
                        }

                        // ��¼��վ�ϴ�״̬
                        iOldState = _Stations[iStationLoc].State;

                        #endregion
                        break;
                    default:
                        #region [ ��������ָ�� ]

                        // ��������ָ��
                        //int iMark = cmdNewBytes[2];         // ������־

                        // ���������

                        if (iCmdNO == 20 || iCmdNO == 22)
                        {
                            iCmdLength = cmdNewBytes[2] + cmdNewBytes[3] * 256 + 6;
                        }
                        else
                        {
                            iCmdLength = 4;
                        }

                        if (_Stations == null || _Stations.Length <= 0)
                        {
                            if (_TempStations != null && _TempStations.Length > 0)
                            {
                                _Stations = _TempStations;
                            }
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        #region ����ʱ����
                        // ��֤������־�Ƿ���ȷ
                        if (!_IsHost)
                        {
                            if (_isNetWork)
                            {
                                // ��������ڻ�վ���򲻴���
                                if (_Stations.Length == 0)
                                {
                                    if (timer.Enabled == false)
                                    {
                                        timer.Enabled = true;
                                    }
                                    return;
                                }
                                if (_IsStartHostBacker)
                                {
                                    // �����ȱ�״̬ʱִ����������
                                    if (_Stations[iStationLoc].State != -10000)
                                    {
                                        if (_Stations[iStationLoc].State != -10100)
                                        {
                                            _Stations[iStationLoc].State = -10100;
                                            _Stations[iStationLoc].NoAnswer = 0;
                                        }
                                        else
                                        {
                                            _Stations[iStationLoc].NoAnswer--;

                                            // ���� 2 �λر�������ʱ����ʾ�ȱ�
                                            _Stations[iStationLoc].State = -10000;

                                            //// Error: ����߼�����������
                                            if (_Stations[iStationLoc].NoAnswer == -2)
                                            {
                                                StationStateChanged(Index, _Stations[iStationLoc].Address, _Stations[iStationLoc].State, _Stations[iStationLoc].CState);
                                            }


                                            // �������һ����վ���ȱ������϶��ô������л�վ�������ȱ�״̬��
                                            for (int i = 0; i < _Stations.Length; i++)
                                            {
                                                _Stations[i].State = -10000;
                                            }
                                            for (int i = 0; i < _TempStations.Length; i++)
                                            {
                                                _TempStations[i].State = -10000;
                                            }

                                            // �����ǰ״̬���Ϊ���ȱ�״̬����֪ͨͨѶ�����ȱ��Ѿ��л����Խ�ΰ�ȱ��߼���Ҫ�õ���
                                            if (IsMark == 0 || IsMark == 2)
                                            {
                                                IsMark = 1;
                                                MarkStateChanged(Index, IsMark);
                                                base.timer.Interval = base.sendTime + 400;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (IsMark == 0 || IsMark == 2)
                                        {
                                            IsMark = 1;
                                            // �������һ����վ���ȱ������϶��ô������л�վ�������ȱ�״̬��
                                            for (int i = 0; i < _Stations.Length; i++)
                                            {
                                                _Stations[i].State = -10000;
                                            }
                                            for (int i = 0; i < _TempStations.Length; i++)
                                            {
                                                _TempStations[i].State = -10000;
                                            }
                                            MarkStateChanged(Index, IsMark);
                                            base.timer.Interval = base.sendTime + 400;
                                        }
                                    }
                                }
                                #region [ ���ñ�־λ ]

                                // �������еı�־λ
                                iStartLoc = -1;
                                iEndLoc = -1;
                                iEndStartLoc = -1;

                                #endregion

                                for (int i = 0; i < byteBuffer.Length; i++)
                                {
                                    byteBuffer[i] = (byte)0;
                                }
                                // �ͷ���Ч����
                                cmdNewBytes = null;
                                if (timer.Enabled == false)
                                {
                                    timer.Enabled = true;
                                }
                                return;
                            }
                            else
                            {
                                // �����ǰ״̬���Ϊ���ȱ�״̬����֪ͨͨѶ�����ȱ��Ѿ��л����Խ�ΰ�ȱ��߼���Ҫ�õ���
                                if (IsMark == 0 || IsMark == 1)
                                {
                                    IsMark = 2;
                                    if (_IsStartHostBacker)
                                    {
                                        // �������һ����վ���ȱ������϶��ô������л�վ�������ȱ�״̬��
                                        for (int i = 0; i < _Stations.Length; i++)
                                        {
                                            _Stations[i].State = 0;
                                        }
                                        for (int i = 0; i < _TempStations.Length; i++)
                                        {
                                            _TempStations[i].State = 0;
                                        }
                                    }
                                    MarkStateChanged(Index, IsMark);
                                    base.timer.Interval = base.sendTime;
                                }
                            }
                        }
                        #endregion

                        if (iCurLoc > iCmdLength + 5)
                        {
                            iCurLoc = 0;
                            for (int i = 0; i < byteBuffer.Length; i++)
                            {
                                byteBuffer[i] = (byte)0;
                            }
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        // ��֤�����
                        if (iCmdLength <= 6 && iCmdNO == 20)
                        {
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }
                        if (iSAddress == 0 || iCmdNO == 0)
                        {
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }
                        //if (cmdNewBytes[cmdNewBytes.Length - 1] == 0 && cmdNewBytes[cmdNewBytes.Length - 2] == 0)
                        //{
                        //    if (timer.Enabled == false)
                        //    {
                        //        timer.Enabled = true;
                        //    }
                        //    return;
                        //}
                        if (cmdNewBytes.Length != iCmdLength)
                        {
                            CmdError(" [���ȴ���]", _Stations[iStationLoc].StationModel);
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }


                        // ��֤��վ���Ƿ���ȷ
                        if (iSAddress != _Stations[iStationLoc].Address)
                        {
                            CmdError(" [��վ�Ŵ�]", _Stations[iStationLoc].StationModel);
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        // ��֤������Ƿ���ȷiCmdNO != CmdNO
                        if (iCmdNO != _Stations[iStationLoc].SCmd && iCmdNO != 24)
                        {
                            CmdError(" [����Ŵ�]", _Stations[iStationLoc].StationModel);
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        // Crc У��
                        if (!_crcByte[0].Equals(cmdNewBytes[cmdNewBytes.Length - 1]) || !_crcByte[1].Equals(cmdNewBytes[cmdNewBytes.Length - 2]))
                        {
                            //CmdError(" [Ч��λ��]");
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        if (RTxtMsg != null)
                        {
                            // ��ʾ����
                            RTxtMsg.WriteTxt(cmdNewBytes, " RX", true, 0);
                        }

                        // ��¼��վ�ϴ�״̬
                        iOldState = _Stations[iStationLoc].State;

                        #endregion
                        break;
                }

                #region [ ���ñ�־λ ]

                // �������еı�־λ
                iStartLoc = -1;
                iEndLoc = -1;
                iEndStartLoc = -1;

                #endregion

                switch (_Stations[iStationLoc].StationModel)
                {
                    case 1:
                    case 3:
                        // �������͵�����
                        DataAnalyzing(cmdNewBytes);
                        break;
                    default:
                        DataAnalyzing20060610(cmdNewBytes);
                        break;
                }

                #region [ ��Ӧָ�� ]

                // ��վ����Ӧ��������
                _Stations[iStationLoc].NoAnswer = 0;

                if (_Stations[iStationLoc].State != -1000)
                {
                    switch (_Stations[iStationLoc].StationModel)
                    {
                        case 1:
                            // ��Ӧ����
                            switch (iCmdNO)
                            {
                                #region [ ��Ӧ: ��ѯ�汾 ]

                                case 22:    // ��վ��Ӧ�˲�ѯ�汾
                                    //�����վ�ϴ�Ϊ���ϣ���ʱ����������
                                    _Stations[iStationLoc].State = 2200;


                                    // ���ɹ̶����������ʱ����Ҫÿ������
                                    switch (_Stations[iStationLoc].Ver)
                                    {
                                        case 256:

                                            // Ѳ������
                                            _Stations[iStationLoc].CmdPolling = KJ128A.Protocol.P20071210.Polling(_Stations[iStationLoc].Address, Mark);

                                            // ��Ϣȷ������
                                            _Stations[iStationLoc].CmdPollingRight = KJ128A.Protocol.P20071210.PollingRight(_Stations[iStationLoc].Address, Mark);

                                            // ��������
                                            _Stations[iStationLoc].CmdReset = KJ128A.Protocol.P20071210.Reset(_Stations[iStationLoc].Address, Mark, 0);

                                            break;
                                    }
                                    //if (!_Stations[iStationLoc].IsPointSelect)
                                    //{
                                    //    iStationLoc++;
                                    //}
                                    break;

                                #endregion

                                #region [ ��Ӧ: Уʱ���� ]

                                case 23:    // ��վ��Ӧ��Уʱ����
                                    ////Czlt-2011-12-20 �����վ�ϴ�Ϊ���ϣ���ʱ����������
                                    //if (_Stations[iStationLoc].IsStaFault)
                                    //{
                                    //    _Stations[iStationLoc].State = 2500;
                                    //    File.AppendAllText("D:\\CzltKJSerialPort.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 17-23 ��վ����Уʱ����,IsStaFault=true ", Encoding.Unicode);
                                    //}
                                    //else
                                    //{
                                        _Stations[iStationLoc].State = 2300;
                                    //}
                                  
                                    break;

                                #endregion

                                #region [ ��Ӧ: Ѳ������ ]

                                case 20:    // ��վ��Ӧ��Ѳ������
                                    _Stations[iStationLoc].State = 2000;
                                    break;

                                #endregion

                                #region [ ��Ӧ: ��Ϣȷ�� ]

                                case 21:    // ��վ��Ӧ����Ϣȷ������
                                    _Stations[iStationLoc].State = 2100;
                                    //if (!_Stations[iStationLoc].IsPointSelect)
                                    //{
                                    //    iStationLoc++;
                                    //}
                                    break;

                                #endregion

                                #region [ ��Ӧ: ����Уʱ ]

                                case 24:    // ��վ����Уʱ����
                                    _Stations[iStationLoc].State = 2400;
                                   // _Stations[iStationLoc].IsStaFault = true;
                                    break;

                                #endregion
                            }
                            break;
                        case 3:
                            switch (iCmdNO)
                            {
                                #region [ ��Ӧ: ��ѯ�汾 ]

                                case 22:    // ��վ��Ӧ�˲�ѯ�汾
                                    _Stations[iStationLoc].State = 2200;

                                    // ���ɹ̶����������ʱ����Ҫÿ������
                                    switch (_Stations[iStationLoc].Ver)
                                    {
                                        case 256:

                                            // Ѳ������
                                            _Stations[iStationLoc].CmdPolling = KJ128A.Protocol.P20071210.Polling(_Stations[iStationLoc].Address, Mark);

                                            // ��Ϣȷ������
                                            _Stations[iStationLoc].CmdPollingRight = KJ128A.Protocol.P20071210.PollingRight(_Stations[iStationLoc].Address, Mark);

                                            // ��������
                                            _Stations[iStationLoc].CmdReset = KJ128A.Protocol.P20071210.Reset(_Stations[iStationLoc].Address, Mark, 0);

                                            break;
                                    }
                                    //if (!_Stations[iStationLoc].IsPointSelect)
                                    //{
                                    //    iStationLoc++;
                                    //}
                                    break;

                                #endregion

                                #region [ ��Ӧ: Уʱ���� ]

                                case 23:    // ��վ��Ӧ��Уʱ����
                                    _Stations[iStationLoc].State = 2300;
                                    //if (!_Stations[iStationLoc].IsPointSelect)
                                    //{
                                    //    iStationLoc++;
                                    //}
                                    break;

                                #endregion

                                #region [ ��Ӧ: Ѳ������ ]

                                case 20:    // ��վ��Ӧ��Ѳ������
                                    _Stations[iStationLoc].State = 2100;
                                    break;

                                #endregion

                                #region [ ��Ӧ: ����Уʱ ]

                                case 24:    // ��վ����Уʱ����
                                    _Stations[iStationLoc].State = 2400;
                                    //_Stations[iStationLoc].IsStaFault = true;
                                    break;

                                #endregion
                                default:
                                    break;
                            }
                            break;
                        default:
                            // ��Ӧ����
                            switch (iCmdNO)
                            {
                                #region [ ��Ӧ: Уʱ���� ]

                                case 23:    // ��վ��Ӧ��Уʱ����
                                    _Stations[iStationLoc].State = 2300;
                                    if (_Stations[iStationLoc].CmdPolling == null || _Stations[iStationLoc].CmdPolling.Length < 4)
                                    {
                                        // Ѳ������
                                        _Stations[iStationLoc].CmdPolling = KJ128A.Protocol.P20060610.sendScout(_Stations[iStationLoc].Address);
                                    }
                                    if (_Stations[iStationLoc].CmdPollingRight == null || _Stations[iStationLoc].CmdPollingRight.Length < 4)
                                    {
                                        // ��Ϣȷ������
                                        _Stations[iStationLoc].CmdPollingRight = KJ128A.Protocol.P20060610.sendInfoAffirm(_Stations[iStationLoc].Address);
                                    }
                                    if (_Stations[iStationLoc].CmdReset == null || _Stations[iStationLoc].CmdReset.Length < 4)
                                    {
                                        // ��������
                                        _Stations[iStationLoc].CmdReset = KJ128A.Protocol.P20060610.Reset(_Stations[iStationLoc].Address);
                                    }
                                    break;

                                #endregion

                                #region [ ��Ӧ: Ѳ������ ]

                                case 20:    // ��վ��Ӧ��Ѳ������
                                    _Stations[iStationLoc].State = 2000;
                                    break;

                                #endregion

                                #region [ ��Ӧ: ��Ϣȷ�� ]

                                case 21:    // ��վ��Ӧ����Ϣȷ������
                                    _Stations[iStationLoc].State = 2100;
                                    break;

                                #endregion

                                #region [ ��Ӧ: ����Уʱ ]

                                case 24:    // ��վ����Уʱ����
                                    _Stations[iStationLoc].State = 2400;
                                    break;

                                #endregion
                            }
                            break;
                    }

                }

                #region [ ���»�վ״̬ ]

                if (iOldState != 2200 && iOldState != 2300 && iOldState != 2000 && iOldState != 2100 && iOldState != 2400)
                {
                    StationStateChanged(Index, _Stations[iStationLoc].Address, _Stations[iStationLoc].State, _Stations[iStationLoc].CState);
                }
                else
                {
                    if (_Stations[iStationLoc].SaveCount <= 10)
                    {
                        _Stations[iStationLoc].SaveCount++;
                        StationStateChanged(Index, _Stations[iStationLoc].Address, _Stations[iStationLoc].State, _Stations[iStationLoc].CState);
                    }
                }

                //// ��⵱ǰ��վ״̬
                //if (iOldState == 0 || iOldState == 3000 || iOldState == 5000 &&
                //    (_Stations[iStationLoc].State != 0 && _Stations[iStationLoc].State != 3000 && _Stations[iStationLoc].State != 5000))
                //{
                //    StationStateChanged(Index, _Stations[iStationLoc].Address, _Stations[iStationLoc].State, _Stations[iStationLoc].CState);
                //}

                #endregion

                #region [��վ�����ӣ�Ѳ����һ����¼]
                switch (iCmdNO)
                {
                    case 22:
                    case 23:
                    case 21:
                        if (!_Stations[iStationLoc].IsPointSelect)
                        {
                            iStationLoc++;
                        }
                        break;
                }
                #endregion

                // �ͷ���Ч����
                cmdNewBytes = null;

                #endregion

                if (timer.Enabled == false)
                {
                    timer.Enabled = true;
                }

                // ������һ��ָ��
                SendCmd();
            }
            catch
            {
                if (timer.Enabled == false)
                {
                    timer.Enabled = true;
                }
                #region [ ���ñ�־λ ]

                // �������еı�־λ
                iStartLoc = -1;
                iEndLoc = -1;
                iEndStartLoc = -1;

                #endregion

                for (int i = 0; i < byteBuffer.Length; i++)
                {
                    byteBuffer[i] = (byte)0;
                }
                // �ͷ���Ч����
                cmdNewBytes = null;
            }

        }

        #endregion

        #region [ ���ݷ��� ]

        /// <summary>
        /// �������͵�����
        /// </summary>
        /// <param name="cmdNewBytes">�ֽ�����</param>
        /// <returns></returns>
        private void DataAnalyzing(byte[] cmdNewBytes)
        {
            if (cmdNewBytes == null)
            {
                return;
            }

            // ������Чָ��
            int iSAddress = cmdNewBytes[0];     // ��վ��
            int iCmdNO = cmdNewBytes[1];        // �����

            switch (iCmdNO)
            {
                case 22:    // ��ѯ�汾

                    // ��ȡ�汾��
                    _Stations[iStationLoc].Ver = cmdNewBytes[6] + cmdNewBytes[7] * 256;

                    // ��֯������ʾ
                    if (RTxtMsgc != null)
                    {
                        RTxtMsgc.WriteTxt("�����վ [ " + iSAddress + " ] �İ汾��: " + _Stations[iStationLoc].Ver, " RX", true, System.Drawing.Color.Black);
                    }

                    break;

                case 23:    // Уʱ

                    // ��֯������ʾ
                    if (RTxtMsgc != null)
                    {
                        RTxtMsgc.WriteTxt("�����վ [ " + iSAddress + " ] Уʱ. ", " RX", true, System.Drawing.Color.Black);
                    }

                    break;

                case 20:    // Ѳ��

                    AnalysisPolling_20071210_1(cmdNewBytes);

                    break;

                case 21:    // ����ȷ��

                    // ��֯������ʾ
                    //if (RTxtMsgc != null)
                    //{
                    //    RTxtMsgc.WriteTxt("��վ [ " + iSAddress + " ] ����ȷ��. ", " RX", true);
                    //}

                    break;
                case 33:    // ���б�ʶ�������վȷ��

                    // ��֯������ʾ
                    if (RTxtMsgc != null)
                    {
                        RTxtMsgc.WriteTxt("�����վ [ " + iSAddress + " ] ���б�ʶ��ȷ��. ", " RX", true, System.Drawing.Color.Blue);
                    }

                    break;
            }

            // ���ݸ����ݴ洢ģ��
            switch (iCmdNO)
            {
                case 20:    // Ѳ��
                case 22:    // ��ѯ�汾
                    DataReceived(cmdNewBytes, Mark, Group);
                    break;
            }

            return;
        }

        /// <summary>
        /// �������͵�����
        /// </summary>
        /// <param name="cmdNewBytes">�ֽ�����</param>
        /// <returns></returns>
        private void DataAnalyzing20060610(byte[] cmdNewBytes)
        {
            if (cmdNewBytes == null)
            {
                return;
            }

            // ������Чָ��
            int iSAddress = cmdNewBytes[0];     // ��վ��
            int iCmdNO = cmdNewBytes[1];        // �����

            switch (iCmdNO)
            {
                case 22:    // ��ѯ�汾

                    //// ��ȡ�汾��
                    //_Stations[iStationLoc].Ver = cmdNewBytes[6] + cmdNewBytes[7] * 256;

                    //// ��֯������ʾ
                    //if (RTxtMsgc != null)
                    //{
                    //    RTxtMsgc.WriteTxt("��վ [ " + iSAddress + " ] �İ汾��: " + _Stations[iStationLoc].Ver, " RX", true);
                    //}

                    break;

                case 23:    // Уʱ

                    // ��֯������ʾ
                    if (RTxtMsgc != null)
                    {
                        RTxtMsgc.WriteTxt("��վ [ " + iSAddress + " ] Уʱ. ", " RX", true, System.Drawing.Color.Black);
                    }

                    break;

                case 20:    // Ѳ��

                    AnalysisPolling_20060610_1(cmdNewBytes);

                    break;

                case 21:    // ����ȷ��

                    // ��֯������ʾ
                    //if (RTxtMsgc != null)
                    //{
                    //    RTxtMsgc.WriteTxt("��վ [ " + iSAddress + " ] ����ȷ��. ", " RX", true);
                    //}

                    break;
            }

            // ���ݸ����ݴ洢ģ��
            switch (iCmdNO)
            {
                case 20:    // Ѳ��
                case 22:    // ��ѯ�汾
                    DataReceived(cmdNewBytes, Mark, Group);
                    break;
            }

            return;
        }

        #endregion

        #region [ ���� ] ʹ�� 2007-12-10 �� 1 ��Э���������

        /// <summary>
        /// ʹ�� 2007-12-10 �� 1 ��Э���������
        /// </summary>
        private void AnalysisPolling_20071210_1(byte[] cmdRight)
        {
            int iCmdLength = cmdRight[3] + cmdRight[4] * 256; // �����

            int iCmdLoc = 5;


            while (iCmdLoc < iCmdLength + 5)
            {
                #region [ ���̽ͷ����ʱ���״̬ ]

                bool blnIsShutDown = false;             // ̽ͷ�Ƿ����

                int iSHead = cmdRight[iCmdLoc];         // ̽ͷ��
                int iSecond = cmdRight[iCmdLoc + 4];    // �룬�������λ 1 ʱ��ʾ̽ͷ����

                DateTime dtTime = DateTime.Now;

                int iPerCount = 0;
                int iPerLength = 0;
                if (iSecond >= 128)
                {
                    // �����λΪ 1 ʱ̽ͷ����
                    iSecond = iSecond - 128;

                    if (cmdRight[iCmdLoc + 1] != 0)
                    {
                        // ���յ����ݵ�ʱ��
                        dtTime = BuildDateTime(cmdRight[iCmdLoc + 1],
                            cmdRight[iCmdLoc + 2], cmdRight[iCmdLoc + 3], iSecond);
                    }
                    if (RTxtMsgc != null)
                    {
                        RTxtMsgc.WriteTxt(dtTime + " [ " + cmdRight[0] + " ] �Ŵ����վ [ " + cmdRight[iCmdLoc] + " ] �Ŷ�����վ [ δ��¼ ]", " RX", true, System.Drawing.Color.Black);
                    }
                    blnIsShutDown = true;
                }
                else
                {
                    if (cmdRight[iCmdLoc + 1] != 0)
                    {
                        dtTime = BuildDateTime(cmdRight[iCmdLoc + 1],
                            cmdRight[iCmdLoc + 2], cmdRight[iCmdLoc + 3], iSecond);
                    }

                    iPerCount = cmdRight[iCmdLoc + 5];              // ����
                    iPerLength = cmdRight[iCmdLoc + 5] * 2;         // ����

                    //if (Base.KJ_bln_IsUseDataBase)
                    //{
                    //    // ���»�վ״̬����̽ͷ״̬Ϊ����
                    //    QueriesTableAdapter qtAdapter = new QueriesTableAdapter();
                    //    qtAdapter.Wwy_Station_StateChange(iStation, iSHead, 2000, DateTime.Now);
                    //}
                }

                // ��֤��������
                //if (cmdRight.Length < iCmdLoc + 6 + iPerLength - 1)
                //{
                //    return;
                //}

                #endregion

                #region [ ̽ͷ���յ��Ŀ��� ]

                StringBuilder sbHeadA = new StringBuilder();    // ̽ͷ A ���յ��ķ�����
                StringBuilder sbHeadB = new StringBuilder();    // ̽ͷ B ���յ��ķ�����
                StringBuilder sbHeadC = new StringBuilder();    // ̽ͷ ���յ�ȫΪ 0 �ķ�����
                StringBuilder sbHeadD = new StringBuilder();    // ̽ͷ ���յ�ȫΪ 1 �ķ�����   ���
                StringBuilder sbHeadE = new StringBuilder();    // �͵���   ̽ͷ A ���յ��ķ�����
                StringBuilder sbHeadF = new StringBuilder();    // �͵���   ̽ͷ B ���յ��ķ�����
                StringBuilder sbHeadG = new StringBuilder();    // �͵���   ̽ͷ ���յ�ȫΪ 0 �ķ�����   ��
                StringBuilder sbHeadH = new StringBuilder();    // �͵���   ̽ͷ ���յ�ȫΪ 1 �ķ�����   ���

                int i;
                for (i = iCmdLoc + 6; i < iCmdLoc + 6 + iPerLength; i += 2)
                {
                    int iCard = cmdRight[i] + cmdRight[i + 1] * 256;

                    if (iCard > 49152)//���
                    {
                        iCard = iCard - 49152;
                        if (iCard > 8192)
                        {
                            iCard = iCard - 8192;
                            sbHeadH.Append(iCard + ",");
                        }
                        else
                        {
                            sbHeadD.Append(iCard + ",");
                        }
                    }
                    else if (iCard >= 32768)//A����
                    {
                        iCard = iCard - 32768;
                        if (iCard > 8192)
                        {
                            iCard = iCard - 8192;
                            sbHeadE.Append(iCard + ",");
                        }
                        else
                        {
                            sbHeadA.Append(iCard + ",");
                        }
                    }
                    else if (iCard >= 16384)//B����
                    {
                        iCard = iCard - 16384;
                        if (iCard > 8192)
                        {
                            iCard = iCard - 8192;
                            sbHeadF.Append(iCard + ",");
                        }
                        else
                        {
                            sbHeadB.Append(iCard + ",");
                        }
                    }
                    else//��
                    {
                        if (iCard > 8192)
                        {
                            iCard = iCard - 8192;
                            sbHeadG.Append(iCard + ",");
                        }
                        else
                        {
                            sbHeadC.Append(iCard + ",");
                        }
                    }
                }

                if (blnIsShutDown)
                {
                    iCmdLoc = i - 1;
                }
                else
                {
                    iCmdLoc = i;
                }

                // ����Ҫ��ʾ������
                StringBuilder strMsg = new StringBuilder();
                strMsg.Append(dtTime + " [ " + cmdRight[0] + " ] �Ŵ����վ [ " + iSHead + " ] �Ŷ�����վ ����⵽: " + iPerCount + " �ű�ʶ��");
                if (sbHeadA.Length > 0) strMsg.Append("\n\t\t[��]: " + sbHeadA);
                if (sbHeadB.Length > 0) strMsg.Append("\n\t\t[��]: " + sbHeadB);
                if (sbHeadC.Length > 0) strMsg.Append("\n\t\t[��]: " + sbHeadC);
                if (sbHeadD.Length > 0) strMsg.Append("\n\t\t[���]: " + sbHeadD);
                if (sbHeadE.Length > 0) strMsg.Append("\n\t\t[��][��]:" + sbHeadE);
                if (sbHeadF.Length > 0) strMsg.Append("\n\t\t[��][��]:" + sbHeadF);
                if (sbHeadG.Length > 0) strMsg.Append("\n\t\t[��][��]:" + sbHeadG);
                if (sbHeadH.Length > 0) strMsg.Append("\n\t\t[��][���]:" + sbHeadH);
                strMsg.Append("\n");

                // ��ʾ̽ͷ�����������ſ�
                if (iPerCount > 0)
                {
                    if (RTxtMsgc != null)
                    {
                        RTxtMsgc.WriteTxt(strMsg.ToString(), " RX", true, System.Drawing.Color.Black);
                    }
                }

                #endregion

                #region [ �����λ�Ƿ���� ]

                if (cmdRight[iCmdLoc++] != 255)
                {
                    break;
                }

                #endregion
            }
        }

        #endregion

        #region [ ���� ] ʹ�� 2006-6-10 �� 1 ��Э���������

        /// <summary>
        /// ʹ�� 2006-6-10 �� 1 ��Э���������
        /// </summary>
        private void AnalysisPolling_20060610_1(byte[] cmdRight)
        {
            // �����
            int iCmdLength = cmdRight[2] + cmdRight[3] * 256;
            // ����
            int iPerCount = cmdRight[4] + cmdRight[5] * 256;
            //��ȡ���ݵ�ʱ��
            DateTime dtTime = BuildDateTime(cmdRight[6], cmdRight[7], cmdRight[8]);

            int iPerCount1 = 0;
            iPerCount1 = iPerCount;

            #region [ ��վ���յ��Ŀ��� ]
            StringBuilder sbHeadA = new StringBuilder();    // ��վ ���յ����λΪ 1 �ķ�����
            StringBuilder sbHeadB = new StringBuilder();    // ��վ ���յ��ڶ�λΪ 1 �ķ�����
            StringBuilder sbHeadC = new StringBuilder();    // ��վ ��һλ�͵ڶ�λΪ0 �ķ�����
            StringBuilder sbHeadD = new StringBuilder();    // �͵���
            StringBuilder sbHeadE = new StringBuilder();    // ��վ ���յ����λ�͵ڶ�λȫΪ 1 �ķ�����   �����
            for (int i = 0; i < iPerCount; i++)
            {
                int iCard;//��Ա����
                //�õ���ʱ���ź�״̬
                iCard = (int)cmdRight[9 + 2 * i] + (int)cmdRight[10 + 2 * i] * 256;
                if (iCard != 29998 && iCard != 62766 && iCard != 29999)
                {
                    if (iCard > 49152)
                    {
                        iCard = iCard - 49152;
                        if (iCard > 8192)
                        {
                            iCard = iCard - 8192;
                            sbHeadD.Append(iCard + ",");
                        }
                        sbHeadE.Append(iCard + ",");
                    }
                    else if (iCard >= 32768)
                    {
                        iCard = iCard - 32768;
                        if (iCard > 8192)
                        {
                            iCard = iCard - 8192;
                            sbHeadD.Append(iCard + ",");
                        }
                        sbHeadA.Append(iCard + ",");
                    }
                    else if (iCard >= 16384)
                    {
                        //iCard = iCard - 16384;
                        //if (iCard > 8192)
                        //{
                        //    iCard = iCard - 8192;
                        //    sbHeadD.Append(iCard + ",");
                        //}
                        //sbHeadB.Append(iCard + ",");
                    }
                    else
                    {
                        if (iCard > 8192)
                        {
                            iCard = iCard - 8192;
                            sbHeadD.Append(iCard + ",");
                        }
                        sbHeadC.Append(iCard + ",");
                    }
                }
                else
                {
                    iPerCount1--;
                }
            }

            // ����Ҫ��ʾ������
            StringBuilder strMsg = new StringBuilder();
            strMsg.Append(dtTime + " [ " + cmdRight[0] + " ] �Ż�վ  ����⵽: " + iPerCount1 + " �ſ�");
            if (sbHeadA.Length > 0) strMsg.Append("\n\t\t[��]: " + sbHeadA);
            if (sbHeadC.Length > 0) strMsg.Append("\n\t\t[��]: " + sbHeadC);
            if (sbHeadD.Length > 0) strMsg.Append("\n\t\t[��]: " + sbHeadD);
            if (sbHeadE.Length > 0) strMsg.Append("\n\t\t[���]" + sbHeadE);
            strMsg.Append("\n");

            // ��ʾ̽ͷ�����������ſ�
            if (iPerCount > 0)
            {
                if (RTxtMsgc != null)
                {
                    RTxtMsgc.WriteTxt(strMsg.ToString(), " RX", true, System.Drawing.Color.Black);
                }
            }

            #endregion
        }

        #endregion

        #region BuildDateTime ���ݽ��յ���ʱ�䣬�����µ�ʱ��

        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <param name="Day"></param>
        /// <param name="Hour"></param>
        /// <param name="Minute"></param>
        /// <param name="Second"></param>
        /// <returns></returns>
        public static DateTime BuildDateTime(int Day, int Hour, int Minute, int Second)
        {
            DateTime dtTime = DateTime.Now;

            try
            {
                // ʱ�䲻�Ϸ����򷵻�ϵͳ��Сʱ��
                if (Day >= 32 || Hour >= 24 || Minute >= 60 || Second >= 60)
                {
                    return new DateTime(2000, 1, 1, 0, 0, 1);
                }

                int int_Year = dtTime.Year;
                int int_Month = dtTime.Month;

                // ��ǰ��ĩ
                if (dtTime.Day == DateTime.DaysInMonth(int_Year, int_Month))
                {
                    // �ϴ�����Ϊ�³�
                    if (Day == 1)
                    {
                        int_Month++;
                    }
                }
                else
                {
                    // ��ǰ�³�
                    if (dtTime.Day == 1)
                    {
                        // �ϴ�����Ϊ��ĩ
                        if (int_Month == 1)
                        {
                            if (Day == DateTime.DaysInMonth(int_Year - 1, 12))
                            {
                                int_Month--;
                            }
                        }
                        else
                        {
                            if (Day == DateTime.DaysInMonth(int_Year, int_Month - 1))
                            {
                                int_Month--;
                            }
                        }
                    }
                    else
                    {
                        // ���³���ĩ
                        if (Day > dtTime.Day + 1)
                        {
                            int_Month--;
                        }
                    }
                }

                // �����µ�ʱ��
                if (int_Month < 1)
                {
                    int_Year--;
                    int_Month = 12;
                }

                if (int_Month > 12)
                {
                    int_Year++;
                    int_Month = 1;
                }

                return new DateTime(int_Year, int_Month, Day, Hour, Minute, Second);
            }
            catch
            {
                return new DateTime(2000, 1, 1, 0, 0, 1);
            }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <param name="Hour"></param>
        /// <param name="Minute"></param>
        /// <param name="Second"></param>
        /// <returns></returns>
        public static DateTime BuildDateTime(int Hour, int Minute, int Second)
        {
            //��ǰϵͳ��ʱ���֡���
            DateTime dtTime = DateTime.Now;

            try
            {
                // ʱ�䲻�Ϸ����򷵻�ϵͳ��Сʱ��
                if (Hour >= 24 || Minute >= 60 || Second >= 60)
                {
                    return new DateTime(2000, 1, 1, 0, 0, 1);
                }

                //���յ����ݵ�ʱ���֡���
                int int_Year = dtTime.Year;
                int int_Month = dtTime.Month;
                int int_Day = DateTime.Now.Day;
                DateTime dtTimeGet = new DateTime(int_Year, int_Month, int_Day, Hour, Minute, Second);

                if (dtTime >= dtTimeGet.AddMinutes(-5)) //��ǰʱ����ڷ������ݵ�ʱ��
                {
                    return dtTimeGet;
                }
                else //��һ��
                {
                    return dtTimeGet.AddDays(-1);
                }
            }
            catch
            {
                return new DateTime(2000, 1, 1, 0, 0, 1);
            }
        }

        #endregion

        #region [ �¼�: ��ʱ�������� ]

        /// <summary>
        /// ��ʱ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                timer.Stop();
                if (_isDatabaseConnect == true && m_RbSend == true)//���ݿ�����
                {
                    if (_isSaveSql == false)//���ݿ��Ƿ����ڱ���,�����������
                    {
                        //sqlSend = 0;
                        base.timer_Elapsed(sender, e);

                        if (IsPause)
                        {
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }

                            return;
                        }

                        // �����վ�����ڣ����˳�
                        if (_Stations == null || _Stations.Length <= 0)
                        {
                            iStationLoc = 0;
                            if (_isStationChange == true)
                            {
                                _Stations = _TempStations;
                                _isStationChange = false;
                            }
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        // ���������վ������ͷ��ʼѲ��
                        if (iStationLoc >= _Stations.Length)
                        {
                            iStationLoc = 0;
                            if (_isStationChange == true)
                            {
                                _Stations = _TempStations;
                                _isStationChange = false;
                            }
                        }

                        // �����վ�����ڣ����˳�
                        if (_Stations == null || _Stations.Length <= 0)
                        {
                            iStationLoc = 0;
                            if (_isStationChange == true)
                            {
                                _Stations = _TempStations;
                                _isStationChange = false;
                            }
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        //�����ȱ�
                        if (_IsStartHostBacker)
                        {
                            //�Ǳ���
                            if (!_IsHost)
                            {
                                backerSendCount++;
                                if (backerSendCount < 30)
                                {
                                    if (timer.Enabled == false)
                                    {
                                        timer.Enabled = true;
                                    }
                                    return;
                                }
                                backerSendCount = 30;
                            }
                        }

                        // ������ϴ������� 61000���򽫹��ϼ��� 60000
                        if (_Stations[iStationLoc].NoAnswer > 61000)
                        {
                            _Stations[iStationLoc].NoAnswer -= 60000;
                        }
                        else
                        {
                            _Stations[iStationLoc].NoAnswer++;
                        }

                        //Czlt-2012-3-28 ����ȱ�ͨѶ״̬���޸�  0:δ��ʼ��,3000:��ʼ��,-10000:�ȱ�ͨѶ
                        if (_Stations[iStationLoc].State == 0 || _Stations[iStationLoc].State == 3000 || _Stations[iStationLoc].State == -10000)
                        {
                            // ��վδ��ʼ��ʱ����������Ӧ�����ߣ��������Ӧ�ù���
                            if (_Stations[iStationLoc].NoAnswer == 3)
                            {
                                _Stations[iStationLoc].State = 3000;
                                _Stations[iStationLoc].SaveCount = 0;
                                StationStateChanged(Index, _Stations[iStationLoc].Address, _Stations[iStationLoc].State, _Stations[iStationLoc].CState);
                            }

                            if (_Stations[iStationLoc].NoAnswer == 5)
                            {
                                _Stations[iStationLoc].State = 5000;
                                _Stations[iStationLoc].SaveCount = 0;
                                StationStateChanged(Index, _Stations[iStationLoc].Address, _Stations[iStationLoc].State, _Stations[iStationLoc].CState);
                            }
                        }
                        else
                        {
                            // ������������г�����������Ӧ�����û�վ����
                            if (_Stations[iStationLoc].NoAnswer == 3 && _Stations[iStationLoc].State != -10000)
                            {
                                _Stations[iStationLoc].State = 5000;
                                _Stations[iStationLoc].SaveCount = 0;
                                StationStateChanged(Index, _Stations[iStationLoc].Address, _Stations[iStationLoc].State, _Stations[iStationLoc].CState);
                            }
                        }

                        iStartLoc = -1;
                        iEndLoc = -1;
                        iEndStartLoc = -1;

                        // ������һ��ָ��
                        if (!_Stations[iStationLoc].IsPointSelect)
                        {
                            iStationLoc++;
                        }
                        SendCmd();
                    }
                    else
                    {
                        //sqlSend++;
                        //if (sqlSend>1)
                        //{
                        //    _isSaveSql = false;
                        //}
                        timer.Enabled = true;
                    }
                }
                else//���ݿ�δ����
                {
                    timer.Enabled = true;
                }
            }
            catch { }
            finally
            {
                if (timer.Enabled == false)
                {
                    timer.Start();
                }
            }
        }

        #endregion
    }
}
