using System;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using KJ128A.BatmanAPI;
using KJ128A.Controls.Batman;

namespace KJ128A.Ports
{
    /// <summary>
    /// ������������
    /// </summary>
    public class StartPort
    {
        #region [ ����:ί�� ] ��վ״̬�ı�

        /// <summary>
        /// ��վ״̬�ı�����
        /// </summary>
        public delegate void StationStateChangedEventHandler(int index, int iAddress, int iState, string strStateRemark);

        /// <summary>
        /// ��վ״̬�ı��¼�
        /// </summary>
        public event StationStateChangedEventHandler StationStateChanged;

        #endregion

        #region [ ����: ί�� ] ���ݵִ�

        /// <summary>
        /// ���ݵִ�ί������
        /// </summary>
        /// <param name="cmdReceived"></param>
        /// <param name="iHost"></param>
        public delegate void DataReceivedEventHandler(byte[] cmdReceived, int iHost,int iGroup);

        /// <summary>
        /// ���ݵִ�
        /// </summary>
        public event DataReceivedEventHandler DataReceived;

        #endregion

        #region [ ����:ί�� ] ������Ϣ

        /// <summary>
        /// ������Ϣ����
        /// </summary>
        /// <param name="index"></param>
        /// <param name="iErrNO"></param>
        /// <param name="strStackTrace"></param>
        /// <param name="Source"></param>
        /// <param name="strMessage"></param>
        public delegate void ErrorMessageEventHandler(int index, int iErrNO, string strStackTrace, string Source, string strMessage);

        /// <summary>
        /// ������Ϣ�¼�
        /// </summary>
        public event ErrorMessageEventHandler ErrorMessage;

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

        #region �����ԣ��ȱ��Ƿ��Ѿ��������С�
        private bool m_RbSend;
        /// <summary>
        /// �ȱ������б�־λ
        /// </summary>
        public bool RbSend
        {
            get { return m_RbSend; }
            set
            {
                m_RbSend = value;
                if (s_serialPort != null)
                {
                    for (int i = 0; i < s_serialPort.Length; i++)
                    {
                        if (s_serialPort[i] != null)
                        {
                            s_serialPort[i].RbSend = m_RbSend;
                        }
                    }
                }
            }
        }
        #endregion

        #region [���ԣ��Ƿ��������Ѿ�����]
        /// <summary>
        /// �Ƿ��������Ѿ�����
        /// </summary>
        private bool _IsNetWork;
        /// <summary>
        /// ���������Ƿ����ӣ�trueΪδ���ӣ�falseΪ������
        /// </summary>
        public bool IsNetWork
        {
            get { return _IsNetWork; }
            set
            {
                _IsNetWork = value;
                if (s_serialPort != null)
                {
                    for (int i = 0; i < s_serialPort.Length; i++)
                    {
                        if (s_serialPort[i] != null)
                        {
                            s_serialPort[i].IsNetWork = _IsNetWork;
                        }
                    }
                }
            }
        }
        #endregion

        #region �����ԣ��������ݿ��Ƿ��Ѿ����ӡ�
        /// <summary>
        /// �������ݿ��Ƿ��Ѿ�����
        /// </summary>
        private bool _IsDataBaseConnection;
        /// <summary>
        /// ���ñ������ݿ��Ƿ��Ѿ�����   true Ϊ����  false Ϊδ����
        /// </summary>
        public bool IsDataBaseConnection
        {
            get { return _IsDataBaseConnection; }
            set 
            {
                _IsDataBaseConnection = value;
                if (s_serialPort != null)
                {
                    for (int i = 0; i < s_serialPort.Length; i++)
                    {
                        if (s_serialPort[i]!=null)
                        {
                            s_serialPort[i].IsDataBaseConnect = _IsDataBaseConnection;
                        }
                    }
                }
            }
        }
        #endregion

        #region �����ԣ��Ƿ��ڴ����ݿ⡿
        private bool _IsSaveSql;
        public bool IsSaveSql
        {
            get { return _IsSaveSql; }
            set
            {
                _IsSaveSql = value;
                if (s_serialPort != null)
                {
                    for (int i = 0; i < s_serialPort.Length; i++)
                    {
                        if (s_serialPort[i] != null)
                        {
                            s_serialPort[i].IsSaveSql = _IsSaveSql;
                        }
                    }
                }
            }
        }
        #endregion

        #region [ ʵ�������� ]

        /// <summary>
        /// ����ʵ������
        /// </summary>
        public static KJSerialPort[] s_serialPort;

        #region InitSerialPort

        /// <summary>
        /// ʵ�������ڶ���
        /// </summary>
        /// <param name="memSerialPort"></param>
        /// <returns></returns>
        public bool InitSerialPort(MemSerialPort[] memSerialPort)
        {
            if (memSerialPort != null)
            {

                // ��ʼ������
                s_serialPort = new KJSerialPort[memSerialPort.Length];

                // ʵ����
                for (int i = 0; i < s_serialPort.Length; i++)
                {
                    s_serialPort[i] = new KJSerialPort(i, memSerialPort[i].PortName, memSerialPort[i].Group, memSerialPort[i].Mark);
                    s_serialPort[i].ErrorMessage += new Base_SerialPort.ErrorMessageEventHandler(StartPort_ErrorMessage);
                    s_serialPort[i].DataReceived += Port_DataReceived;
                    s_serialPort[i].StationStateChanged += delegate(int index, int iAddress, int iState, string strStateRemark)
                    {
                        if (StationStateChanged != null)
                        {
                            StationStateChanged(index, iAddress, iState, strStateRemark);
                        }
                    };
                    s_serialPort[i].MarkStateChanged += delegate(int index, int IsMark)
                    {
                        if (MarkStateChanged != null)
                        {
                            MarkStateChanged(index, IsMark);
                        }
                    };
                }

                if (!(s_serialPort != null && s_serialPort.Length > 0)) return false;

                return true;
            }
            else
            {
                return false;
            }
        }

        private void StartPort_ErrorMessage(int index, int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            if (ErrorMessage != null)
            {
                ErrorMessage(index, iErrNO, strStackTrace, strSource, strMessage);
            }
        }

        private void Port_DataReceived(byte[] cmdReceived, int iMark,int iGroup)
        {
            if (DataReceived != null)
            {
                DataReceived(cmdReceived, iMark,iGroup);
            }
        }

        #endregion

        #region InitStation

        /// <summary>
        /// ��ʼ����վ��Ϣ
        /// </summary>
        /// <param name="dgStation"></param>
        /// <param name="memStation"></param>
        /// <returns></returns>
        public bool InitStation(DataGridView[] dgStation, MemStation[] memStation)
        {
            if (!(s_serialPort != null && s_serialPort.Length > 0)) return false;

            if (memStation == null || memStation.Length <= 0) return false;

            for (int i = 0; i < s_serialPort.Length; i++)
            {
                ArrayList al = new ArrayList();

                // ���ݴ���Ѳ��Ļ�վ����ȡ���������Ļ�վ
                for (int j = 0; j < memStation.Length; j++)
                {
                    if (s_serialPort[i].Group == memStation[j].Group)
                    {
                        al.Add(memStation[j]);
                    }
                }

                // ������֯��վ����
                MemStation[] tmpStation = new MemStation[al.Count];
                for (int k = 0; k < al.Count; k++)
                {
                    tmpStation[k] = (MemStation)al[k];

                    if (tmpStation[k].StationModel == 1 || tmpStation[k].StationModel == 3)
                    {
                        // ��ʼ��У�԰汾������
                        tmpStation[k].CmdVersion = KJ128A.Protocol.P20071210.Version(tmpStation[k].Address, 0, s_serialPort[i].Mark);
                    }
                }

                // ���´����еĻ�վ����
                s_serialPort[i].Stations = tmpStation;
                s_serialPort[i].TempStations = tmpStation;
                s_serialPort[i].IsStationChange = false;
                // ���½�����ʾ�Ļ�վ����
                dgStation[i].Visible = false;
                dgStation[i].DataSource = s_serialPort[i].TempStations;
                dgStation[i].Visible = true;
                al = null;
            }

            return true;
        }

        /// <summary>
        /// ��վ��Ϣ�ı�
        /// </summary>
        /// <param name="dgStation"></param>
        /// <param name="memStation"></param>
        /// <returns></returns>
        public bool StationChange(DataGridView[] dgStation, MemStation[] memStation)
        {
            if (!(s_serialPort != null && s_serialPort.Length > 0)) return false;

            for (int i = 0; i < s_serialPort.Length; i++)
            {
                ArrayList al = new ArrayList();

                // ���ݴ���Ѳ��Ļ�վ����ȡ���������Ļ�վ
                for (int j = 0; j < memStation.Length; j++)
                {
                    if (s_serialPort[i].Group == memStation[j].Group)
                    {
                        al.Add(memStation[j]);
                    }
                }

                // ������֯��վ����
                MemStation[] tmpStation = new MemStation[al.Count];
                MemStation[] oldStations = s_serialPort[i].Stations;
                for (int k = 0; k < al.Count; k++)
                {
                    tmpStation[k] = (MemStation)al[k];
                    if (oldStations != null)
                    {
                        for (int m = 0; m < oldStations.Length; m++)
                        {
                            if (oldStations[m].Address == tmpStation[k].Address && oldStations[m].ID == tmpStation[k].ID && oldStations[m].StationModel == tmpStation[k].StationModel)
                            {
                                tmpStation[k] = oldStations[m];
                                tmpStation[k].NoAnswer = 0;
                                break;
                            }
                        }
                    }
                    if (tmpStation[k].CmdVersion == null)
                    {
                        if (tmpStation[k].StationModel == 1 || tmpStation[k].StationModel == 3)
                        {
                            // ��ʼ��У�԰汾������
                            tmpStation[k].CmdVersion = KJ128A.Protocol.P20071210.Version(tmpStation[k].Address, 0, s_serialPort[i].Mark);
                        }
                    }

                    if (!IsHost)
                    {
                        tmpStation[k].State = -10000;
                        //if (tmpStation[k].State != -10000)
                        //{
                        //    tmpStation[k].State = 0;
                        //}
                        //else
                        //{
                            
                        //}
                    }
                    else
                    {
                        tmpStation[k].State = 0;
                    }
                }

                // ���´����еĻ�վ����
                s_serialPort[i].TempStations = tmpStation;
                s_serialPort[i].IsStationChange = true;
                // ���½�����ʾ�Ļ�վ����
                dgStation[i].Visible = false;
                dgStation[i].DataSource = s_serialPort[i].TempStations;
                dgStation[i].Visible = true;
                al = null;
            }

            return true;
        }

        #endregion
        
        #endregion

        #region [ ����: ���ô��� ]

        /// <summary>
        /// ���ô��ڴ���
        /// </summary>
        /// <param name="strFilePath">�����ļ����·��</param>
        /// <param name="frm">������</param>
        public static void ShowCommSetDialog(string strFilePath, IFrmMain frm)
        {
            FrmCommSet frmCommSet = new FrmCommSet(strFilePath, frm);
            frmCommSet.ShowDialog();
            frmCommSet = null;
        }


        #endregion

        #region [ ���� ]

        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            if (s_serialPort == null || s_serialPort.Length == 0) return false;

            for (int i = 0; i < s_serialPort.Length; i++)
            {
                s_serialPort[i].IsStartHostBacker = _IsStartHostBacker;
                s_serialPort[i].IsHost = _IsHost;
                //��ʼ����վ�ı�״̬Ϊδ�ı�
                s_serialPort[i].IsStationChange = false;
                //��ʼ���ȱ���������Ϊδ����
                s_serialPort[i].IsNetWork = _IsNetWork;
                //��ʼ�����ݿ�����״̬Ϊδ����
                s_serialPort[i].IsDataBaseConnect = _IsDataBaseConnection;
                //��ʼ��Ϊ���ڱ������ݿ�
                s_serialPort[i].IsSaveSql = false;
                s_serialPort[i].RbSend = m_RbSend;
                if (s_serialPort[i] != null)
                {
                    if (s_serialPort[i].Stations != null)
                    {
                        for (int j = 0; j < s_serialPort[i].Stations.Length; j++)
                        {
                            if (_IsStartHostBacker)
                            {
                                if (!_IsHost)
                                {
                                    s_serialPort[i].Stations[j].State = -10000;
                                }
                            }
                        }
                    }
                    s_serialPort[i].Open();
                    s_serialPort[i].SendCmd();
                }
            }
            return true;
        }

        #endregion

    }
}
