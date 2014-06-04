using System;
using System.Collections.Generic;
using System.Text;
using KJ128A.Protocol;
using KJ128A.BatmanAPI;
using System.Data;
using System.IO;


namespace KJ128A.Controls.Batman
{
    /// <summary>
    /// KJ128N ����Ҫ�Ĵ�������η�װ
    /// </summary>
    public class KJ128N_Port: Base_SerialPort
    {

        #region ��Czlt-2010-11-29 ˫��ͨѶ��

        #region �����ԡ�
        GetCardInfo getCardInfo = new GetCardInfo();
        /// <summary>
        /// �Ƿ����˫ͨѶ
        /// </summary>
        private bool iScloseCall = true;
        #endregion

        #region �����ԡ� ˫��ͨ��״̬
        /// <summary>
        /// ˫��ͨ��״̬
        /// </summary>
        private bool _IsTwoMessage;

        /// <summary>
        /// ˫��ͨ��״̬
        /// </summary>
        public bool IsTwoMessage
        {
            get { return _IsTwoMessage; }
            set
            {
                _IsTwoMessage = value;
                timer_Call.Enabled = value;
            }
        }

        #endregion


        #region �����ԡ� Ҫ���еı�ʶ��
        /// <summary>
        /// Ҫ���еı�ʶ��������ʵʱ��״̬��
        /// </summary>
        public int[] CardToCall;


        #endregion

        #region �����ԡ� ˫��ͨѶ�㲥��Ϣ
        /// <summary>
        /// ˫��ͨѶ�㲥��Ϣ��0-�����վ��1-������վ��2-��ʶ���ţ�
        /// </summary>
        public int[] CallOrder;

        /// <summary>
        /// Czlt-2012-04-21 ����վ�ı�ʶ��
        /// </summary>
        public string strOutCard;

        #endregion

        /// <summary>
        /// ˫��ͨѶ���
        /// </summary>
        protected byte[][] CallOrders;


        /// <summary>
        /// ��ʶ�����ڷ�վ
        /// </summary>
        private DataTable dtStn;

        #endregion

        #region [ ���� ] ��׼�������

        private KJRichTextBox _RTxtMsg = null;

        /// <summary>
        /// ��׼�������
        /// </summary>
        public KJRichTextBox RTxtMsg
        {
            get { return _RTxtMsg; }
            set { _RTxtMsg = value; }
        }

        #endregion

        #region [ ���� ] �����������

        private KJRichTextBox _RTxtMsge = null;

        /// <summary>
        /// �����������
        /// </summary>
        public KJRichTextBox RTxtMsge
        {
            get { return _RTxtMsge; }
            set { _RTxtMsge = value; }
        }

        #endregion

        #region [ ���� ] �����������

        private KJRichTextBox _RTxtMsgc = null;

        /// <summary>
        /// �����������
        /// </summary>
        public KJRichTextBox RTxtMsgc
        {
            get { return _RTxtMsgc; }
            set { _RTxtMsgc = value; }
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

        #region [ ���� ] �����

        private int _CmdNO;

        /// <summary>
        /// ��ȡ�����÷��͵������
        /// </summary>
        public int CmdNO
        {
            get { return _CmdNO; }
            set { _CmdNO = value; }
        }

        #endregion

        #region [ ���� ] ��Ѳ��Ļ�վ����

        /// <summary>
        /// ��Ѳ��Ļ�վ����
        /// </summary>
        protected MemStation[] _Stations;

        /// <summary>
        /// ��Ѳ��Ļ�վ����
        /// </summary>
        public MemStation[] Stations
        {
            get { return _Stations; }
            set { _Stations = value; }
        }

        protected MemStation[] _TempStations;

        /// <summary>
        /// ��ʱѲ���վ����
        /// </summary>
        public MemStation[] TempStations
        {
            get { return _TempStations; }
            set { _TempStations = value; }
        }
        #endregion

        #region [����] ��վ�����Ƿ�ı�
        protected bool _isStationChange;
        /// <summary>
        /// �Ƿ��վ�����Ѿ��ı�
        /// </summary>
        public bool IsStationChange
        {
            get { return _isStationChange; }
            set { _isStationChange = value; }
        }
        #endregion

        #region [���ԣ����յ������ݷ�����Ч��λ]
        protected byte[] _crcByte = new byte[1];
        #endregion

        #region [ ���� ] ��ͣ�շ�

        private bool _IsPause;

        /// <summary>
        /// ��ͣ�շ�
        /// </summary>
        public bool IsPause
        {
            get { return _IsPause; }
            set
            {
                _IsPause = value;
                if (_IsPause)
                {
                    timer.Enabled = false;
                }
                else
                {
                    timer.Enabled = true;
                }
            }
        }

        #endregion

        #region [ ���� ] ��������

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="iStationLoc"></param>
        protected void SendCmd(ref int iStationLoc)
        {
            if (timer.Enabled == false)
            {
                timer.Enabled = true;
            }
            // �Ƿ���ͣ����
            if (IsPause)
            {
                return;
            }

            #region ��Czlt-2010-11-29 ˫��ͨѶ��
            if (!iScloseCall)
            {
                iScloseCall = true;
                timer_Call.Enabled = false;
                _IsTwoMessage = false;
                CallOrder = null;
                CallOrders = null;
                CardToCall = null;
                dtStn = null;
            }

            #endregion

            if (_Stations == null || _Stations.Length <= 0)
            {
                iStationLoc = 0;
                if (_isStationChange == true)
                {
                    _Stations = _TempStations;
                    _isStationChange = false;
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
                return;
            }
            //else
            //{
            //    timer.Enabled = false;
            //}
            iCurLoc = 0;
            for (int i = 0; i < byteBuffer.Length; i++)
			{
                byteBuffer[i] = 0;
			}

            // �������еı�־λ
            iStartLoc = -1;
            iEndLoc = -1;
            iEndStartLoc = -1;

            byte[] cmdBytes = null;
            switch (_Stations[iStationLoc].StationModel)
            {
                case 1:
                case 3:
                    #region [KJ128A����ָ��]
                    //// ���ݻ�վ״̬�����ɴ���ָ��
                    //if (_Stations[iStationLoc].IsTwo == true)
                    //{
                    //    //switch (_Stations[iStationLoc].Ver)
                    //    //{
                    //    //    case 256:
                    //    cmdBytes = _Stations[iStationLoc].CmdTwo;
                    //    _Stations[iStationLoc].SCmd = 19;
                    //    CmdNO = 19;
                    //    _Stations[iStationLoc].IsTwo = false;
                    //    //        break;
                    //    //}
                    //}
                    //if (iStationLoc == 0 && _IsTwoMessage == true)
                    if ( _IsTwoMessage == true)
                    {
                        ///Czlt-2012-04-22 ���ں�������Ŀ�
                        if (strOutCard != null && !strOutCard.Trim().Equals(""))
                        {
                            RTxtMsgc.WriteTxt(strOutCard + " �ű�ʶ�����ں��������ڣ�", " RX", true, System.Drawing.Color.Red);
                            strOutCard = string.Empty;
                        }
                        #region[���ں��������־ʱ]

                        if (CallOrder != null && CallOrder.Length == 3)
                        {
                            cmdBytes = KJ128A.Protocol.P20071210.TwoMessage(CallOrder[0], CallOrder[1], CallOrder[2], Mark);
                            //Czlt-2011-11-22 ���ȷ����ʾ��־
                            if (RTxtMsgc != null)
                            {
                                RTxtMsgc.WriteTxt(CallOrder[0] + "�Ŵ��� " + CallOrder[1] + "�Ŷ�����վ ��" + CallOrder[2] + " �ű�ʶ���������У�", " RX", true, System.Drawing.Color.Blue);
                            }

                            CallOrders = null;
                            CardToCall = null;
                            _IsTwoMessage = false;
                        }
                        else if (CardToCall != null)
                        {
                            if (CallOrders == null)
                            {
                                CallOrder = null;
                                string strCard = SetCardToStr(CardToCall);
                                dtStn = getCardInfo.GetRTStnHead(strCard);
                                int iCount = dtStn.Rows.Count;
                                if (iCount > 0)
                                {
                                    byte[][] tmp = new byte[iCount][];
                                    for (int i = 0; i < iCount; i++)
                                    {
                                        int iStn = Convert.ToInt32(dtStn.Rows[i]["StationAddress"].ToString());
                                        int iStnHead = Convert.ToInt32(dtStn.Rows[i]["StationHeadAddress"].ToString()); ;
                                        int iCard = Convert.ToInt32(dtStn.Rows[i]["CodeSenderAddress"].ToString()); ;
                                        tmp[i] = KJ128A.Protocol.P20071210.TwoMessage(iStn, iStnHead, iCard, Mark);
                                    }

                                    CallOrders = tmp;

                                    if (iCount >= CardToCall.Length)
                                    {
                                        CardToCall = null;
                                    }
                                    else
                                    {
                                        for (int j = 0; j < CardToCall.Length; j++)
                                        {
                                            for (int s = 0; s < iCount; s++)
                                            {
                                                if (CardToCall[j] == Convert.ToInt32(dtStn.Rows[s]["CodeSenderAddress"].ToString()))
                                                {
                                                    CardToCall[j] = 0;
                                                    break;
                                                }
                                            }
                                        }
                                        int[] iTempCard = new int[CardToCall.Length - iCount];

                                        int iIdex = 0;
                                        for (int x = 0; x < CardToCall.Length; x++)
                                        {
                                            if (CardToCall[x] != 0)
                                            {
                                                iTempCard[iIdex] = CardToCall[x];
                                                iIdex++;
                                            }
                                        }
                                        CardToCall = iTempCard;//״̬��Ϊ���ı�ʶ��
                                    }

                                }
                                int iRowcount = -1;
                                if (CallOrders != null)
                                {
                                    iRowcount = CallOrders.GetLength(0);
                                    cmdBytes = CallOrders[0];
                                    if (iRowcount > 1)
                                    {
                                        byte[][] tmpOrder = new byte[iRowcount - 1][];
                                        for (int i = 0; i < iRowcount - 1; i++)
                                        {
                                            tmpOrder[i] = CallOrders[i + 1];
                                        }

                                        CallOrders = tmpOrder;

                                    }
                                    else
                                    {
                                        CallOrders = null;
                                        if (CardToCall == null)
                                        {
                                            _IsTwoMessage = false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                int iRowcount = -1;
                                if (CallOrders != null)
                                {
                                    iRowcount = CallOrders.GetLength(0);
                                    cmdBytes = CallOrders[0];
                                    if (iRowcount > 1)
                                    {
                                        byte[][] tmpOrder = new byte[iRowcount - 1][];
                                        for (int i = 0; i < iRowcount - 1; i++)
                                        {
                                            tmpOrder[i] = CallOrders[i + 1];
                                        }

                                        CallOrders = tmpOrder;

                                    }
                                    else
                                    {
                                        CallOrders = null;
                                        if (CardToCall == null)
                                        {
                                            _IsTwoMessage = false;
                                        }
                                    }
                                }
                            }


                        }
                        else if (CallOrders != null)
                        {
                            int iRowcount = -1;
                            if (CallOrders != null)
                            {
                                iRowcount = CallOrders.GetLength(0);
                                cmdBytes = CallOrders[0];
                                if (iRowcount > 1)
                                {
                                    byte[][] tmpOrder = new byte[iRowcount - 1][];
                                    for (int i = 0; i < iRowcount - 1; i++)
                                    {
                                        tmpOrder[i] = CallOrders[i + 1];
                                    }

                                    CallOrders = tmpOrder;

                                }
                                else
                                {
                                    CallOrders = null;
                                    if (CardToCall == null)
                                    {
                                        _IsTwoMessage = false;
                                    }
                                }
                            }
                        }

                        #region[���û�����ɺ��������λ�õķ�վ������Ӧ��������ѯ����]
                        if (cmdBytes == null)
                        {
                            switch (_Stations[iStationLoc].State)
                            {
                                case -10000:    // �ȱ�
                                case 5000:      // ��վ����
                                case 3000:      // ��վδ��¼
                                case 2400:      // ��Ӧ��վ����Уʱ����
                                case 1900:      //˫������
                                case 0:         // δ��ʼ����ִ�в�ѯ�汾����
                                    cmdBytes = _Stations[iStationLoc].CmdVersion;
                                    _Stations[iStationLoc].SCmd = 22;
                                    CmdNO = 22;
                                    break;

                                case 2200:  // ��ѯ�汾������ִ��Уʱ����
                                    switch (_Stations[iStationLoc].Ver)
                                    {
                                        case 256:   // N �� V1.0
                                            _Stations[iStationLoc].TimeCheckOut = DateTime.Now;
                                            cmdBytes = KJ128A.Protocol.P20071210.SyncDate(_Stations[iStationLoc].Address, Mark);
                                            _Stations[iStationLoc].SCmd = 23;
                                            CmdNO = 23;
                                            break;
                                    }
                                    break;

                                case 2300:  // Уʱ���������ִ��Ѳ������
                                    switch (_Stations[iStationLoc].Ver)
                                    {
                                        case 256:
                                            cmdBytes = _Stations[iStationLoc].CmdPolling;
                                            _Stations[iStationLoc].SCmd = 20;
                                            CmdNO = 20;
                                            break;
                                    }
                                    break;

                                case 2000:  // Ѳ�����������ִ����Ϣȷ������
                                    switch (_Stations[iStationLoc].Ver)
                                    {
                                        case 256:
                                            cmdBytes = _Stations[iStationLoc].CmdPollingRight;
                                            _Stations[iStationLoc].SCmd = 21;
                                            CmdNO = 21;
                                            break;
                                    }
                                    break;

                                case 2100:  // ��Ϣȷ����������󣬷���Ѳ������
                                    switch (_Stations[iStationLoc].Ver)
                                    {
                                        case 256:
                                            if (_Stations[iStationLoc].TimeCheckOut.AddMinutes(30) <= DateTime.Now)
                                            {
                                                _Stations[iStationLoc].TimeCheckOut = DateTime.Now;
                                                cmdBytes = KJ128A.Protocol.P20071210.SyncDate(_Stations[iStationLoc].Address, Mark);
                                                _Stations[iStationLoc].SCmd = 23;
                                                CmdNO = 23;
                                            }
                                            else
                                            {
                                                cmdBytes = _Stations[iStationLoc].CmdPolling;
                                                _Stations[iStationLoc].SCmd = 20;
                                                CmdNO = 20;
                                            }
                                            break;
                                    }
                                    break;                               

                                case -1000: // ����
                                    iStationLoc++;
                                    SendCmd(ref iStationLoc);
                                    return;

                                case 2500:  // ����
                                    switch (_Stations[iStationLoc].Ver)
                                    {
                                        case 256:
                                            cmdBytes = _Stations[iStationLoc].CmdReset;
                                            _Stations[iStationLoc].SCmd = 25;
                                            CmdNO = 25;
                                            break;
                                    }
                                    break;
                            }
                        }
                        #endregion

                        #endregion
                    }
                    else
                    {
                        #region ����˫��ͨѶ��ʶ����ʱ��
                        ///Czlt-2012-04-22 ���ں�������Ŀ�
                        if (strOutCard != null && !strOutCard.Trim().Equals(""))
                        {
                            RTxtMsgc.WriteTxt(strOutCard + " �ű�ʶ�����ں��������ڣ�", " RX", true, System.Drawing.Color.Red);
                            strOutCard = string.Empty;
                        }
                        switch (_Stations[iStationLoc].State)
                        {
                            case -10000:    // �ȱ�
                            case 5000:      // ��վ����
                            case 3000:      // ��վδ��¼
                            //case 2400:      // ��Ӧ��վ����Уʱ����
                            case 1900:      //˫������
                            case 0:         // δ��ʼ����ִ�в�ѯ�汾����
                                cmdBytes = _Stations[iStationLoc].CmdVersion;
                                _Stations[iStationLoc].SCmd = 22;
                                CmdNO = 22;
                                break;

                            case 2200:  // ��ѯ�汾������ִ��Уʱ����
                                switch (_Stations[iStationLoc].Ver)
                                {
                                    case 256:   // N �� V1.0
                                        ////Czlt-2011-12-21 �����վ����ֱ�ӷ����������ݵ�����
                                        //if (_Stations[iStationLoc].IsStaFault)
                                        //{
                                        //    File.AppendAllText("D:\\CzltKJ128N_Port.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 16-22  �����վ����ֱ�ӷ����������ݵ����� 22 ", Encoding.Unicode);
                                        //    cmdBytes = _Stations[iStationLoc].CmdPolling;
                                        //    _Stations[iStationLoc].SCmd = 20;
                                        //    CmdNO = 20;

                                        //    //Czlt-2011-12-20 ���ù��ϱ�ʶλ
                                        //    _Stations[iStationLoc].IsStaFault = false;
 
                                        //}
                                        //else
                                        //{
                                            _Stations[iStationLoc].TimeCheckOut = DateTime.Now;
                                            cmdBytes = KJ128A.Protocol.P20071210.SyncDate(_Stations[iStationLoc].Address, Mark);
                                            _Stations[iStationLoc].SCmd = 23;
                                            CmdNO = 23;
                                        //}
                                        break;
                                }
                                break;

                            case 2300:  // Уʱ���������ִ��Ѳ������
                                switch (_Stations[iStationLoc].Ver)
                                {
                                    case 256:
                                        cmdBytes = _Stations[iStationLoc].CmdPolling;
                                        _Stations[iStationLoc].SCmd = 20;
                                        CmdNO = 20;
                                        break;
                                }
                                break;

                            case 2000:  // Ѳ�����������ִ����Ϣȷ������
                                switch (_Stations[iStationLoc].Ver)
                                {
                                    case 256:
                                        cmdBytes = _Stations[iStationLoc].CmdPollingRight;
                                        _Stations[iStationLoc].SCmd = 21;
                                        CmdNO = 21;
                                        break;
                                }
                                break;

                            case 2100:  // ��Ϣȷ����������󣬷���Ѳ������
                                switch (_Stations[iStationLoc].Ver)
                                {
                                    case 256:
                                        if (_Stations[iStationLoc].TimeCheckOut.AddMinutes(30) <= DateTime.Now || _Stations[iStationLoc].TimeCheckOut.AddMinutes(-30)>DateTime.Now)
                                        {
                                            _Stations[iStationLoc].TimeCheckOut = DateTime.Now;
                                            cmdBytes = KJ128A.Protocol.P20071210.SyncDate(_Stations[iStationLoc].Address, Mark);
                                            _Stations[iStationLoc].SCmd = 23;
                                            CmdNO = 23;
                                        }
                                        else
                                        {
                                            cmdBytes = _Stations[iStationLoc].CmdPolling;
                                            _Stations[iStationLoc].SCmd = 20;
                                            CmdNO = 20;
                                        }
                                        break;
                                }
                                break;
                            case 2400:      // ��Ӧ��վ����Уʱ����
                                ////Czlt-2011-12-20 �����վ����������ʱ�����ֱ�Ӹ����ʱ
                                //if (_Stations[iStationLoc].IsStaFault)
                                //{
                                //    File.AppendAllText("D:\\CzltKJ128N_Port.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 17-23 ��Ӧ��վ����Уʱ������Ͷ�ʱ���� 23 ", Encoding.Unicode);
                                //    _Stations[iStationLoc].TimeCheckOut = DateTime.Now;
                                //    cmdBytes = KJ128A.Protocol.P20071210.SyncDate(_Stations[iStationLoc].Address, Mark);
                                //    _Stations[iStationLoc].SCmd = 23;
                                //    CmdNO = 23;
                                //}
                                break;
                            case -1000: // ����
                                iStationLoc++;
                                SendCmd(ref iStationLoc);
                                return;

                            case 2500:  // ����
                                switch (_Stations[iStationLoc].Ver)
                                {
                                    case 256:
                                        //Czlt-2011-12-10 ��������ʶλ��ֵ
                                        //_Stations[iStationLoc].IsStaFault = false;
                                        cmdBytes = _Stations[iStationLoc].CmdReset;
                                        _Stations[iStationLoc].SCmd = 25;
                                        CmdNO = 25;
                                        break;
                                }
                                break;
                        }
                        #endregion
                    }
                    #endregion
                    break;
                default:
                    #region [KJ128V2����ָ��]
                    switch (_Stations[iStationLoc].State)
                    {
                        case -10000:    // �ȱ�
                        case 5000:      // ��վ����
                        case 3000:      // ��վδ��¼
                        case 2400:      // ��Ӧ��վ����Уʱ����
                        case 1900:      // ˫������
                        case 0:         // δ��ʼ����ִ�в�ѯ�汾����
                            _Stations[iStationLoc].TimeCheckOut = DateTime.Now;
                            cmdBytes = KJ128A.Protocol.P20060610.sendTime(_Stations[iStationLoc].Address);
                            _Stations[iStationLoc].SCmd = 23;
                            CmdNO = 23;
                            break;

                        case 2300:  // Уʱ���������ִ��Ѳ������
                            cmdBytes = _Stations[iStationLoc].CmdPolling;
                            _Stations[iStationLoc].SCmd = 20;
                            CmdNO = 20;
                            break;

                        case 2000:  // Ѳ�����������ִ����Ϣȷ������
                            cmdBytes = _Stations[iStationLoc].CmdPollingRight;
                            _Stations[iStationLoc].SCmd = 21;
                            CmdNO = 21;
                            break;

                        case 2100:  // ��Ϣȷ����������󣬷���Ѳ������
                            if (_Stations[iStationLoc].TimeCheckOut.AddMinutes(30) <= DateTime.Now || _Stations[iStationLoc].TimeCheckOut.AddMinutes(-30) > DateTime.Now)
                            {
                                _Stations[iStationLoc].TimeCheckOut = DateTime.Now;
                                cmdBytes = KJ128A.Protocol.P20060610.sendTime(_Stations[iStationLoc].Address);
                                _Stations[iStationLoc].SCmd = 23;
                                CmdNO = 23;
                            }
                            else
                            {
                                cmdBytes = _Stations[iStationLoc].CmdPolling;
                                _Stations[iStationLoc].SCmd = 20;
                                CmdNO = 20;
                            }
                            break;
                        case -1000: // ����
                            iStationLoc++;
                            SendCmd(ref iStationLoc);
                            return;

                        case 2500:  // ����
                            cmdBytes = _Stations[iStationLoc].CmdReset;
                            _Stations[iStationLoc].SCmd = 25;
                            CmdNO = 25;
                            break;
                    }
                    #endregion
                    break;
            }
            if (cmdBytes != null)
            {
                if (RTxtMsg != null)
                {
                    //Czlt-2012-04-20 ע��
                   // RTxtMsg.WriteTxt(cmdBytes, " TX", true, 6);


                    //Czlt-2012-04-20 ͨѶǰ�������00
                    RTxtMsg.WriteTxt(cmdBytes, " TX", true, 7);
                }
                Write(cmdBytes);

                // �����վ״̬�������Ļ�����������Ѳ��
                if (_Stations[iStationLoc].State == 2500)
                {
                    _Stations[iStationLoc].State = 0;

                    iStationLoc++;
                    SendCmd(ref iStationLoc);
                }
            }

        }

        #endregion

        #region [ ���� ] ���ݵִ�

        /// <summary>
        /// ��ʼ��־
        /// </summary>
        protected int iStartLoc = -1;     // ��ʼ��־

        /// <summary>
        /// ������־
        /// </summary>
        protected int iEndLoc = -1;       // ������־

        /// <summary>
        /// �ҵ�����λ�Ŀ�ʼ���
        /// </summary>
        protected int iEndStartLoc = -1;  // �ҽ���λ�Ŀ�ʼ���

        /// <summary>
        /// �µ�����
        /// </summary>
        protected byte[] cmdNewBytes = null;

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
                #region [ ��������� ]

                // �������������
                if (iCurLoc == 0)
                {
                    iStartLoc = -1;
                    iEndLoc = -1;
                    iEndStartLoc = -1;
                    if (timer.Enabled == false)
                    {
                        timer.Enabled = true;
                    }
                    return;
                }

                #endregion

                #region [ Ѱ�ҿ�ʼ��� ]

                // Ѱ�ҿ�ʼ���
                int i238;
                if (iStartLoc == -1)
                {
                    i238 = 0;
                    for (int i = 0; i < iCurLoc; i++)
                    {
                        if (byteBuffer[i] == 238)
                        {
                            i238++;
                        }
                        else
                        {
                            i238 = 0;
                        }

                        if (i238 >= 5)
                        {
                            iStartLoc = i - 5;
                            iEndStartLoc = i + 1;
                            break;
                        }
                    }
                }

                if (iEndStartLoc == -1) return;

                #endregion

                #region [��ȡ��վ��Ϣ]
                //��վ��ַ��
                int address = (int)byteBuffer[iStartLoc + 6];
                MemStation mStation = new MemStation();
                if (address != 0)
                {
                    mStation = GetStation(address);
                }
                if (mStation.Address == 0)
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
                #endregion

                int iCmdNewLength = 0;

                switch (mStation.StationModel)
                {
                    case 1://KJ128A
                    case 3:
                        #region [ Ѱ�ҽ������ ]

                        // Ѱ�ҽ������
                        int i254;
                        if (iEndLoc == -1)
                        {
                            i254 = 0;
                            int iTmp = 0;
                            for (iTmp = iEndStartLoc; iTmp < iCurLoc; iTmp++)
                            {
                                if (byteBuffer[iTmp] == 254)
                                {
                                    i254++;
                                }
                                else
                                {
                                    i254 = 0;
                                }

                                if (i254 >= 3)
                                {
                                    iEndLoc = iTmp;
                                    break;
                                }
                            }

                            // ��¼��һ�ο�ʼѰ�ҽ�����־��λ��
                            if (iEndLoc == -1)
                            {
                                iEndStartLoc = iTmp - 2;
                                return;
                            }
                        }

                        // Error: д��־
                        if (iEndStartLoc == -1) return;

                        #endregion

                        #region [ �����ظ���ʼ��־ ]

                        // ������ʼ��־�󣬽�����־ǰ���Ƿ��еڶ�����ʼ��־
                        i238 = 0;
                        for (int i = iEndLoc - 2; i > iStartLoc + 4; i--)
                        {
                            if (byteBuffer[i] == 238)
                            {
                                i238++;
                            }
                            else
                            {
                                i238 = 0;
                            }

                            if (i238 >= 5)
                            {
                                // ��ȡ�ظ���־λ������
                                int iErrCmd = iEndLoc - iStartLoc + 1;
                                byte[] cmdErr = new byte[iErrCmd];
                                for (int k = 0; k < iErrCmd; k++)
                                {
                                    if (iStartLoc > -1)
                                    {
                                        cmdErr[k] = byteBuffer[iStartLoc + k];
                                    }
                                }

                                // ��ʾ�ظ���־λ������
                                //if (RTxtMsge != null)
                                //{
                                //    RTxtMsge.WriteTxt(cmdErr, " [��־�ظ�]", true, 0);
                                //}
                                for (int j = 0; j < byteBuffer.Length; j++)
                                {
                                    byteBuffer[j] = (byte)0;
                                }
                                iStartLoc = i - 1;
                                break;
                            }
                        }

                        #endregion

                        #region [ ��ȡ�������� ]

                        // ��������ȣ����������ŵĿռ�
                        iCmdNewLength = iEndLoc - iStartLoc - 9;
                        if (iCmdNewLength < 1)
                        {
                            // Error: 
                            string str = string.Empty;
                            return;
                        }
                        cmdNewBytes = new byte[iCmdNewLength];

                        // ��ȡ��������
                        for (int i = 0; i < iCmdNewLength; i++)
                        {
                            cmdNewBytes[i] = byteBuffer[iStartLoc + i + 6];
                        }

                        iCurLoc = 0;
                        for (int i = 0; i < byteBuffer.Length; i++)
                        {
                            byteBuffer[i] = (byte)0;
                        }

                        //// ����������ǰ��
                        //if (iEndLoc + 1 < iCurLoc)
                        //{
                        //    iEndLoc++;

                        //    int iCmdTmpLength = iCurLoc - iEndLoc;
                        //    for (int i = 0; i <= iCmdTmpLength; i++)
                        //    {
                        //        byteBuffer[i] = byteBuffer[iEndLoc + i];
                        //    }

                        //    iCurLoc = iCmdTmpLength;
                        //}
                        //else
                        //{
                        //    iCurLoc = 0;
                        //}

                        #endregion
                        break;
                    default://KJ128V2
                        #region [ ��ȡ�������� ]
                        try
                        {
                            iCmdNewLength = 0;
                            if (byteBuffer.Length > 9)
                            {
                                switch (byteBuffer[iStartLoc + 7])
                                {
                                    case 20://���ݻ���
                                        iCmdNewLength = 6 + int.Parse(byteBuffer[iStartLoc + 8].ToString()) + int.Parse(byteBuffer[iStartLoc + 9].ToString()) * 256;
                                        if (iCmdNewLength <= 6)
                                        {
                                            cmdNewBytes = null;
                                            if (timer.Enabled == false)
                                            {
                                                timer.Enabled = true;
                                            }
                                            return;
                                        }
                                        if (byteBuffer.Length < iCmdNewLength + 6)
                                        {
                                            iCmdNewLength = 0;
                                            for (int i = 0; i < byteBuffer.Length; i++)
                                            {
                                                byteBuffer[i] = (byte)0;
                                            }
                                        }
                                        break;
                                    case 21://���ݻ��ͳɹ�ȷ��
                                    case 23://��ʱ�ɹ�ȷ��
                                    case 24://�����ʱ
                                        iCmdNewLength = 4;
                                        break;
                                    default:
                                        for (int i = 0; i < byteBuffer.Length; i++)
                                        {
                                            byteBuffer[i] = (byte)0;
                                        }
                                        break;
                                }
                            }


                            // ��������ȣ����������ŵĿռ�
                            if (iCmdNewLength < 1)
                            {
                                // Error: 
                                string str = string.Empty;
                                cmdNewBytes = null;
                                if (timer.Enabled == false)
                                {
                                    timer.Enabled = true;
                                }
                                return;
                            }
                            cmdNewBytes = new byte[iCmdNewLength];
                            byte[] cmdBytesAll = new byte[iCmdNewLength + 5];
                            for (int i = 0; i < iCmdNewLength + 5; i++)
                            {
                                cmdBytesAll[i] = byteBuffer[iStartLoc + i + 1];
                            }
                            // ��ȡ��������
                            for (int i = 0; i < iCmdNewLength; i++)
                            {
                                cmdNewBytes[i] = byteBuffer[iStartLoc + i + 6];
                            }

                            #region [����Ч��λ]
                            _crcByte = CRCVerify.Crc(cmdBytesAll, iCmdNewLength + 3, 0);
                            #endregion

                            if (_crcByte == null)
                            {
                                cmdNewBytes = null;
                                if (timer.Enabled == false)
                                {
                                    timer.Enabled = true;
                                }
                                return;
                            }
                            if (cmdNewBytes[1] == 0)
                            {
                                cmdNewBytes = null;
                                if (timer.Enabled == false)
                                {
                                    timer.Enabled = true;
                                }
                                return;
                            }
                            //if (cmdNewBytes[cmdNewBytes.Length - 1] == 0 && cmdNewBytes[cmdNewBytes.Length - 2] == 0)
                            //    return;
                            // ��֤������Ƿ���ȷ  cmdNewBytes[1] != CmdNO
                            if (cmdNewBytes[1] != mStation.SCmd && cmdNewBytes[1] != 24)
                            {
                                for (int i = 0; i < byteBuffer.Length; i++)
                                {
                                    byteBuffer[i] = (byte)0;
                                }
                                cmdNewBytes = null;
                                if (timer.Enabled == false)
                                {
                                    timer.Enabled = true;
                                }
                                return;
                            }
                            // Crc У��
                            if (!_crcByte[0].Equals(cmdNewBytes[cmdNewBytes.Length - 1]) || !_crcByte[1].Equals(cmdNewBytes[cmdNewBytes.Length - 2]))
                            {
                                cmdNewBytes = null;
                                if (timer.Enabled == false)
                                {
                                    timer.Enabled = true;
                                }
                                return;
                            }
                            iCurLoc = 0;
                            for (int i = 0; i < byteBuffer.Length; i++)
                            {
                                byteBuffer[i] = (byte)0;
                            }
                        }
                        catch
                        {
                            for (int i = 0; i < byteBuffer.Length; i++)
                            {
                                byteBuffer[i] = (byte)0;
                            }
                            cmdNewBytes = null;
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                        }

                        #endregion
                        break;
                }
            }
            catch
            {
                cmdNewBytes = null;
                if (timer.Enabled == false)
                {
                    timer.Enabled = true;
                }
            }
            
            //// �������еı�־λ
            //iStartLoc = -1;
            //iEndLoc = -1;
            //iEndStartLoc = -1;
        }

        #endregion

        #region [ ���� ] ���ݻ�վ��ַ��ȡ��վ���

        /// <summary>
        /// ���ݻ�վ��ַ��ȡ��վ���
        /// </summary>
        /// <param name="iAddress">��վ��ַ��</param>
        public int GetStationID(int iAddress)
        {
            for (int i = 0; i < Stations.Length; i++)
            {
                if (Stations[i].Address == iAddress)
                {
                    return Stations[i].ID;
                }
            }

            return -1;
        }

        /// <summary>
        /// ���ݷ�վ��ַ��ȡ��վ��Ϣ
        /// </summary>
        /// <param name="iAddress">��վ��ַ��</param>
        /// <returns>��վ��Ϣ</returns>
        public MemStation GetStation(int iAddress)
        {
            for (int i = 0; i < Stations.Length; i++)
            {
                if (Stations[i].Address == iAddress)
                {
                    return Stations[i];
                }
            }
            return new MemStation();
        }

        #endregion


        #region��Czlt-2010-11-29 ˫��ͨѶ��
        #region ����������ȡҪ���еı�ʶ����
        /// <summary>
        /// ��ȡҪ���еı�ʶ��
        /// </summary>
        /// <param name="iCards">��ʶ������</param>
        /// <returns></returns>
        public string SetCardToStr(int[] iCards)
        {
            try
            {
                string strCard = "";

                if (iCards.Length < 1)
                {
                    return null;
                }

                for (int i = 0; i < iCards.Length; i++)
                {
                    if (i == iCards.Length - 1)
                    {
                        strCard += iCards[i];
                    }
                    else
                    {
                        strCard += iCards[i] + ",";
                    }
                }
                return strCard;
            }
            catch
            {
                return null;
            }

        }
        #endregion


        public override void timer_Call_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            iScloseCall = false;
        }
        #endregion

    }
}
