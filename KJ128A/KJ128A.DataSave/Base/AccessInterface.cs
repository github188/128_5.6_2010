using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Threading;

namespace KJ128A.DataSave.Base
{
    /// <summary>
    /// Access�����ӿ�
    /// </summary>
    public class AccessInterface
    {
        #region [ ���� ]

        private readonly AccessInsert insertAcc = new AccessInsert();    // Access ����    
        private readonly AccessSelect selectAcc = new AccessSelect();    // Access ����
        private readonly AccessUpdate updateAcc = new AccessUpdate();    // Access ����

        private readonly AccessBase accImp = new AccessBase();       // Access ���÷���
        //private  OleDbConnection dbConn = null;
        private string strSQL = String.Empty;

        #endregion

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

        /*
         * ���캯��
         */

        #region [ ���캯�� ]

        /// <summary>
        /// ���캯��
        /// </summary>
        public AccessInterface()
        {
            //ע�ᵯ���Ի���ί���¼�
            insertAcc.ErrorMessage += _ErrorMessage;
            updateAcc.ErrorMessage += _ErrorMessage;
            updateAcc.ErrorMessage += _ErrorMessage;
            accImp.ErrorMessage += _ErrorMessage;
        }

        #endregion

        #region [ ע��ί�� ]

        /// <summary>
        /// ע�������Ϣ����
        /// </summary>
        /// <param name="iErrNO">������Ϣ���</param>
        /// <param name="strStackTrace">��ȡ��ǰ�쳣����ʱ���ö�ջ�ϵ�֡���ַ�����ʾ��ʽ</param>
        /// <param name="strSource">��ʶ��ǰ��һ�γ�����Ĵ���</param>
        /// <param name="strMessage">��ȡ������ǰ�쳣����Ϣ</param>
        void _ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            string strError=String.Empty;
            switch (iErrNO)
            {
                #region Access���ݿ����

                case 6020001:
                    strError = "����Access���ݿ�ʧ�ܣ�ԭ��" + strMessage;
                    break;
                case 6020004:
                    strError = "�޷���ȡAccessDB�ļ������������ݿ�����ƣ�ԭ��Ϊ��" + strMessage;
                    break;
                case 6020006:
                    strError = "��Access���ݿ��в������ݳ���ԭ��Ϊ��" + strMessage;
                    break;
                case 6020010:
                    strError = "�ر�Access���ݿ�����ʧ�ܣ�ԭ��" + strMessage;
                    break;
                case 6020011:
                    strError = "��ѯAccess���ݿ��е����ݳ���ԭ��" + strMessage;
                    break;
                case 6020012:
                    strError = "����Access���ݿ��е����ݳ���ԭ��" + strMessage;
                    break;
                case 6020014:
                    strError = strMessage;
                    break;
                case 6020015:
                    strError = strMessage;
                    break;

                #endregion

                #region SQL���ݿ����

                case 6020007:
                    strError = "����SQL���ݿ�ʧ�ܣ�ԭ��" + strMessage;
                    break;
                case 6020008:
                    strError = "ִ��SQL�洢����ʧ�ܣ�ԭ��" + strMessage;
                    break;
                case 6020009:
                    strError = "�ر�SQL���ݿ�����ʧ�ܣ�ԭ��" + strMessage;
                    break;

                #endregion

                #region ����ʣ���������

                case 4020001:
                    strError = "ע�⣺ϵͳ�Ѿ����������һЩ���̿ռ䣬Ϊ��֤�������ȷ���������������������̣�";
                    break;
                case 4020002:
                    strError = "ע�⣺���̿ռ䲻��200M���뾡��������̣�����������С��100Mʱ�����ǽ�ǿ��������̣�";
                    break;
                #endregion

                #region  �ļ�����

                case 6020002:
                    strError = "�޷������µ�Access���ݿ⣬ԭ��" + strMessage;
                    break;
                case 4020003:
                    strError = "Interop.MSAdodcLib.Modle.dll( ���ݿ�ģ�� ���ļ���ɾ����";
                    break;
                case 6020005:
                    strError = "�޷�ȡ���ļ���ֻ�����ԣ�ԭ��Ϊ��" + strMessage;
                    break;
                case 6020013:
                    strError = "�޷�ɾ�����ݿ��ļ���ԭ��Ϊ��" + strMessage;
                    break;
                #endregion
               
                default:
                    break;
            }
            if (ErrorMessage != null)
            {
                ErrorMessage(iErrNO, strStackTrace, strSource, strError);
            }
        }

        #endregion

        /*
         *  ����в�������
         */

        /// <summary>
        /// ��������Ϣ��ӵ����ñ���
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="bytes"></param>
        /// <param name="bIsSync"></param>
        /// <param name="intIsSyncing"></param>
        /// <returns></returns>
        public bool InsertData_Config(DateTime dateTime, byte[] bytes, bool bIsSync, int intIsSyncing)
        {
            return InsertData_Config(dateTime.ToString("yyyyMMddHHmmssfff"), bytes, bIsSync, intIsSyncing);
        }
        /// <summary>
        /// ��������Ϣ��ӵ����ñ���
        /// </summary>
        /// <param name="strDateTime"></param>
        /// <param name="bytes"></param>
        /// <param name="bIsSync"></param>
        /// <param name="intIsSyncing"></param>
        /// <returns></returns>
        public bool InsertData_Config(string strDateTime, byte[] bytes, bool bIsSync, int intIsSyncing)
        {
            return insertAcc.SveDate_Config(strDateTime, bytes, bIsSync, intIsSyncing);
        }

        #region [ �ӿ�: ��ԭʼ��(OrgData)�в������� ]

        /// <summary>
        /// ��ԭʼ��(OrgData)�в�������
        /// </summary>
        /// <param name="dt">ʱ��</param>
        /// <param name="dataStream">������</param>
        /// <param name="bIsSync">�Ƿ�ͬ��</param>
        /// <param name="intIsSyncing">�Ƿ�ͬ����</param>
        /// <returns>�����ɹ�����True</returns>
        public bool InsertData_OrgData( DateTime dt, byte[] dataStream, bool bIsSync, int intIsSyncing)
        {
            //OleDbConnection dbConn = (OleDbConnection)insertAcc.GetConnectionByTime(dt);     // ��ȡ��Ч������

            return insertAcc.SaveData_OrgData( dt, dataStream, bIsSync, intIsSyncing); // �������������ݿ�
        }

        // <summary>
        /// ��ԭʼ��(OrgData)�в�������
        /// </summary>
        /// <param name="strDatetime">ʱ��</param>
        /// <param name="dataStream">������</param>
        /// <param name="bIsSync">�Ƿ�ͬ��</param>
        /// <param name="intIsSyncing">�Ƿ�ͬ����</param>
        /// <returns>�����ɹ�����True</returns>
        public bool InsertData_OrgData( string strDatetime, byte[] dataStream, bool bIsSync, int intIsSyncing)
        {
            //OleDbConnection dbConn = (OleDbConnection)insertAcc.GetConnectionByTime(dt);     // ��ȡ��Ч������

            return insertAcc.SaveData_OrgData( strDatetime, dataStream, bIsSync, intIsSyncing); // �������������ݿ�
        }

        #endregion

        #region [ �ӿ�: ���ͱ�(NewData)�в������� ]

        /// <summary>
        /// ���ͱ�(NewData)�в�������
        /// </summary>
        /// <param name="strCreateInfo">ʱ���ַ���</param>
        /// <param name="dataStream">������</param>
        /// <param name="bIsSend">�Ƿ�ͬ��</param>
        /// <param name="bIsSending">�Ƿ�ͬ����</param>
        /// <param name="iSaveState">�洢״̬</param>
        /// <returns>�����ɹ�����True</returns>
        public bool InsertData_NewData( string strCreateInfo, byte[] dataStream, bool bIsSend, bool bIsSending, int iSaveState)
        {
            //��ʱ���ַ���ת����DateTime
            //string newTime = strCreateInfo.Substring(0, 4) + "." + strCreateInfo.Substring(4, 2) + "." +
            //                 strCreateInfo.Substring(6, 2);
            //DateTime dt = Convert.ToDateTime(newTime);

            //OleDbConnection dbConn = null;//(OleDbConnection)insertAcc.GetConnectionByTime(dt);     // ��ȡ��Ч������

            return insertAcc.SaveData_NewData(strCreateInfo, dataStream, bIsSend, bIsSending, iSaveState); // �������������ݿ�
        }

        #endregion

        /*
        *   ��ѯ���� 
        */

        #region [���������ñ����Ƿ����"ͬ���У�IsSyncing >= 0�� �ļ�¼"]
        /// <summary>
        /// ��ȡ���ñ����Ƿ����"ͬ���У�IsSyncing >= 0�� �ļ�¼
        /// </summary>
        /// <param name="lastFindDate"></param>
        /// <param name="strTimeInfo"></param>
        /// <param name="byteCommands"></param>
        /// <param name="iIsSyncing"></param>
        /// <returns></returns>
        public bool IfExistConfigData_IsSyncing(DateTime lastFindDate, out string strTimeInfo, out byte[] byteCommands, out int iIsSyncing)
        {
            DataTable dt = selectAcc.DataSelectInAllMDB(" where IsSyncing >= 0 ", lastFindDate);
            return selectAcc.GetData(dt, out strTimeInfo,out byteCommands,out iIsSyncing);
        }
        #endregion

        #region [ �ӿ�: �Ƿ���ڡ�ͬ���У�IsSyncing >= 0�����ļ�¼ ]

        /// <summary>
        /// �Ƿ���ڡ�ͬ���У�IsSyncing > 0�����ļ�¼
        /// </summary>
        /// <param name="lastFindDate">���һ�β���ʱ��</param>
        /// <param name="strTimeInfo">������Ϣ</param>
        /// <param name="byteCommands">����</param>
        /// <param name="iIsSyncing">ͬ����״̬</param>
        /// <returns>���ڷ���true</returns>
        public bool IFExistData_IsSyncing(DateTime lastFindDate,out string strTimeInfo, out byte[] byteCommands, out int iIsSyncing)
        {
            //��ѯ����
            DataTable dt = selectAcc.DataSelectInAllMDB(2, " where IsSyncing >= 0 ", lastFindDate);

            //��ȡ��Ӧ���ֶΣ�����
            return selectAcc.GetData(dt, out strTimeInfo, out byteCommands, out iIsSyncing);
        }

        #endregion

        #region [ �ӿ�: �Ƿ���ڡ���ͬ����IsSync = False�����ļ�¼]     �ӿںϲ�

        /// <summary>
        /// �Ƿ���ڡ���ͬ����IsSync = False�����ļ�¼
        /// </summary>
        /// <param name="lastFindDate">���һ�β���ʱ��</param>
        /// <returns>���ڷ���True�������ڷ���False</returns>
        public bool IFExistDataInAllMDB_IsSync(DateTime lastFindDate)
        {
            //���Ҽ�¼
            DataTable dt = selectAcc.DataSelectInAllMDB(3, " where IsSync = false", lastFindDate);

            if (dt != null)
            {
                //���ؼ�¼�������Ƿ������
                return dt.Rows.Count > 0;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// �Ƿ���ڡ���ͬ����IsSync = False�����ļ�¼
        /// </summary>
        /// <param name="lastFindDate">���һ�β���ʱ��</param>
        /// <returns>���ڷ���True�������ڷ���False</returns>
        public bool IFExistDataInAllMDB_IsSync(DateTime lastFindDate,out string strTimeInfo,out byte [] byteDatas)
        {
            //���Ҽ�¼
            DataTable dt = selectAcc.DataSelectInAllMDB(3, " where IsSync = false", lastFindDate);

            //��ȡ��Ӧ���ֶ���Ϣ
            return selectAcc.GetData(dt, out strTimeInfo, out byteDatas);
        }

        #endregion 

        #region [ �ӿ�: ��ʱ���ַ�����Ϣ��ѯOrgData���м�¼ ]

        /// <summary>
        /// ��ʱ���ַ�����Ϣ��ѯOrgData���м�¼
        /// </summary>
        /// <param name="strTime">ʱ���ַ���</param>
        /// <returns>���ؼ�¼������ѯ���ɹ����ؿձ�</returns>
        public bool DataSelectInAllMDB_CreateInfo(string strTime)
        {
            //�������ݿ����ͱ���
            //string[] name = accImp.GetInforFromString(databaseType, strTime);
            string[] name = accImp.GetInforFromString(true, strTime);

            //command����
            string strCommand = "select * from " + name[1] +  " where CreateInfo = '" + strTime + "' ";

            //��������
            //OleDbConnection dbConn = accImp.SetConnect(name[0]);

            //��ѯ����
            DataTable dataTable = selectAcc.DataSelete(strCommand,name[0]);

            //���ؼ�¼
            return dataTable.Rows.Count>0;
        }

        #endregion

        #region [ �ӿ�: �Ƿ���ڡ�IsSend = false&SaveState = 0���ļ�¼ ]

        /// <summary>
        /// �Ƿ���ڡ�IsSend = false��SaveState = 0���ļ�¼
        /// </summary>
        /// <param name="lastFindDate">���һ�β���ʱ��</param>
        /// <param name="strTimeInfo">������Ϣ</param>
        /// <param name="byteCommands">����</param>
        /// <returns>���ڷ���True�������ڷ���False</returns>
        public bool IFExistDataInAllMDB_IsSend_SaveState(DateTime lastFindDate, out string strTimeInfo, out byte[] byteCommands)
        {
            //��ѯ���ݣ�����δ�洢δ���͵�����(IsSend = false��SaveState = 0)��
            DataTable dt = selectAcc.DataSelectInAllMDB(5, " where IsSend = false and SaveState = 0 order by id", lastFindDate);

            //��ȡ��Ӧ���ֶ���Ϣ
            return selectAcc.GetData(dt, out strTimeInfo, out byteCommands);
        }

        #endregion

        #region [ �ӿ�: �Ƿ���ڡ�IsSend = false���ļ�¼ ]

        /// <summary>
        /// �Ƿ���ڡ�IsSend = false���ļ�¼
        /// </summary>
        /// <param name="lastFindDate">���һ�β���ʱ��</param>
        /// <param name="strTimeInfo">������Ϣ</param>
        /// <param name="byteCommands">����</param>
        /// <returns>���ڷ���True�������ڷ���False</returns>
        public bool IFExistDataInAllMDB_IsSend(DateTime lastFindDate,out string strTimeInfo, out byte[] byteCommands)
        {
            DataTable dt = selectAcc.DataSelectInAllMDB(5, " where IsSend = false order by id", lastFindDate);
            //��ȡ��Ӧ���ֶ���Ϣ
            return selectAcc.GetData(dt, out strTimeInfo, out byteCommands);
        }

        #endregion

        /*
         * ��������
         */

        #region [����������config���е�����]

        /// <summary>
        /// ����OrgData���е����ݣ��ṩʱ����Ϣ�ַ�����
        /// </summary>
        /// <param name="strDateTime">��ʾʱ����ַ������磺20080215161656718</param>
        /// <param name="bIsSync">��ͬ��</param>
        /// <param name="iIsSyncing">ͬ���е�״̬</param>
        /// <returns>�����ɹ�����True</returns>
        public bool UpdataTable_Config(string strDateTime, bool bIsSync, int iIsSyncing)
        {
            string[] name = accImp.GetInforFromString(strDateTime);
            //Command����
            strSQL = " UpDate " + name[1] +
                     " SET IsSync=" + bIsSync + ",IsSyncing=" + iIsSyncing +
                     " WHERE CreateInfo='" + strDateTime + "'";

            //ִ������
            int intCounts = 0;
            while (!updateAcc.ExcuteCommand(strSQL,"config\\"+ name[0]))
            {
                if (intCounts >= 10)
                {
                    //д�������־
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020014, "", "[AccessInterface:UpDataTable_ConfigData]", "������ζ�δ�ɹ����ü�¼������������ʱ�䣩" + strDateTime + "�����ݱ�������ִ�е�Sql���Ϊ��" + strSQL);
                    }
                    return false;
                }
                intCounts++;
            }
            return true;
        }

        /// <summary>
        /// ����config���е�����
        /// </summary>
        /// <param name="strDateTime"></param>
        /// <param name="IsSend"></param>
        /// <param name="bIsSending"></param>
        /// <param name="iSaveState"></param>
        /// <returns></returns>
        public bool UpdataTable_Config(string strDateTime, bool IsSend, bool bIsSending, int iSaveState)
        {
            //Command����
            strSQL = " Set IsSend=" + IsSend + ",IsSending=" + bIsSending + ",SaveState=" + iSaveState;
            return UpdataTable_Config(strSQL, strDateTime);
        }
        /// <summary>
        /// ����config���е�����
        /// </summary>
        /// <param name="strDateTime"></param>
        /// <param name="iSaveState"></param>
        /// <returns></returns>
        public bool UpdataTable_Config(string strDateTime, int iSaveState)
        {
            //Command����
            strSQL = " SET SaveState=" + iSaveState;
            return UpdataTable_Config(strSQL, strDateTime);
        }

        /// <summary>
        /// ����config���е�����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="strDateTime"></param>
        /// <returns></returns>
        private bool UpdataTable_Config(string strSql, string strDateTime)
        {
            string[] name = accImp.GetInforFromString(strDateTime);
            strSQL = " UpDate " + name[1] + strSql + " WHERE CreateInfo='" + strDateTime + "'";
            int intCounts = 0;
            while (!updateAcc.ExcuteCommand(strSQL, name[0]))
            {
                if (intCounts >= 10)
                {
                    //д�������־
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020014, "", "[AccessInterface:UpDataTable_Config]", "����ʮ�ζ�δ�ɹ����ü�¼������������ʱ�䣩" + strDateTime + "�����ݱ�������ִ�е�Sql���Ϊ��" + strSQL);
                    }
                    return false;
                }
                intCounts++;
                Thread.Sleep(10);
            }
            return true;
        }
        #endregion

        #region [ �ӿ�: ����NewData���е����ݣ��ṩʱ����Ϣ�ַ����� ]

        /// <summary>
        /// ����NewData���е����ݣ��ṩʱ����Ϣ�ַ�����
        /// </summary>
        /// <param name="strDateTime">��ʾʱ����ַ������磺20080215161656718</param>
        /// <param name="IsSend">�ѷ���</param>
        /// <param name="bIsSending">������</param>
        /// <param name="iSaveState">�洢��־λ</param>
        /// <returns>�ɹ�����True</returns>
        public bool UpDataTable_NewData(string strDateTime, bool IsSend, bool bIsSending, int iSaveState)
        {
            //Command����
            strSQL = " Set IsSend=" + IsSend + ",IsSending=" + bIsSending + ",SaveState=" + iSaveState;

            return UpDataTable_NewData(strSQL, strDateTime);
        }

        /// <summary>
        /// ����NewData���е����ݣ��ṩʱ����Ϣ�ַ�����
        /// </summary>
        /// <param name="strDateTime">��ʾʱ����ַ������磺20080215161656718</param>
        /// <param name="iSaveState">�洢��־λ</param>
        /// <returns>�ɹ�����True</returns>
        public bool UpDataTable_NewData(string strDateTime, int iSaveState)
        {
            //Command����
            strSQL = " SET SaveState=" + iSaveState;

            return UpDataTable_NewData( strSQL, strDateTime);
        }

        /// <summary>
        /// ����NewData���е����ݣ��ṩʱ����Ϣ�ַ�����
        /// </summary>
        /// <param name="strDateTime">��ʾʱ����ַ������磺20080215161656718</param>
        /// <param name="IsSend">�ѷ���</param>
        /// <param name="bIsSending">������</param>
        /// <returns>�ɹ�����True</returns>
        public bool UpDataTable_NewData(string strDateTime, bool IsSend, bool bIsSending)
        {
            strSQL = " SET IsSend=" + IsSend + ",IsSending=" + bIsSending;

            return UpDataTable_NewData( strSQL, strDateTime);
        }

        /// <summary>
        /// ����NewData���е�����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="strDateTime"></param>
        /// <returns></returns>
        private bool UpDataTable_NewData(string strSql, string strDateTime)
        {
            //string[] name = accImp.GetInforFromString(databaseType, strDateTime);
            string[] name = accImp.GetInforFromString(false, strDateTime);

            strSQL = " UpDate " + name[1] + strSql + " WHERE CreateInfo='" + strDateTime + "'";

            //��������
            //dbConn = accImp.SetConnect(name[0]);
            //OleDbConnection dbConn = null;
            //ִ������
            int intCounts = 0;
            while (!updateAcc.ExcuteCommand(strSQL,name[0]))
            {
                if (intCounts >= 10)
                {
                    //д�������־
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020014, "", "[AccessInterface:UpDataTable_NewData]", "����ʮ�ζ�δ�ɹ����ü�¼������������ʱ�䣩" + strDateTime + "�����ݱ�������ִ�е�Sql���Ϊ��" + strSQL);
                    }
                    return false;
                }
                intCounts++;
                Thread.Sleep(10);
            }
            return true;
        }

        #endregion

        #region [ �ӿ�: NewData���д���IsSending = True�ļ�¼ʱ����Ϊfalse ]

        /// <summary>
        /// NewData���д���IsSending = True�ļ�¼ʱ����Ϊfalse
        /// </summary>
        /// <returns>���ĳɹ�����true��û�м�¼Ҳ����true������ʧ�ܷ���False</returns>
        public bool UpDataTable_NewData_IsSending()
        {
            //���е����ݿ�����
            string[] strMDBNames = accImp.FindAllMDBOfFile();
            foreach (string strMDBName in strMDBNames)
            {
                //�������ݿ��е����б���
                string[] strTableNames = accImp.GetTableNameBase(strMDBName);
                foreach (string strTableName in strTableNames)
                {
                    //�����NewData�����и�������
                    if (strTableName.IndexOf("NewData") != -1)
                    {
                        //SQL���
                        strSQL = "UPDATE " + strTableName + " SET  IsSending = false  where IsSending = true ";
                        //���ݿ�����
                        //dbConn = accImp.SetConnect(strMDBName.Substring(strMDBName.LastIndexOf("\\") + 1));
                        //OleDbConnection dbConn = null;
                        //ִ��ʧ�ܷ���False
                        int intCounts = 0;
                        while (!updateAcc.ExcuteCommand(strSQL, strMDBName.Substring(strMDBName.LastIndexOf("\\") + 1)))
                        {
                            if (intCounts >= 10)
                            {
                                //д�������־
                                if (ErrorMessage != null)
                                {
                                    ErrorMessage(6020014, "", "[AccessInterface:UpDataTable_NewData_IsSending]", "������ζ�δ�ɹ������ݱ�������ִ�е�Sql���Ϊ��" + strSQL);
                                }
                                return false;
                            }
                            intCounts++;
                        }
                    }
                }
            }
            return true;
        }

        #endregion

        #region [ �ӿ�: ����OrgData���е����� ]

        /// <summary>
        /// ����OrgData���е����ݣ��ṩʱ����Ϣ�ַ�����
        /// </summary>
        /// <param name="strDateTime">��ʾʱ����ַ������磺20080215161656718</param>
        /// <param name="bIsSync">��ͬ��</param>
        /// <param name="iIsSyncing">ͬ���е�״̬</param>
        /// <returns>�����ɹ�����True</returns>
        public bool UpDataTable_OrgData( string strDateTime, bool bIsSync, int iIsSyncing)
        {
            //string[] name = accImp.GetInforFromString(databaseType, strDateTime);
            string[] name = accImp.GetInforFromString(true, strDateTime);
            //Command����
            strSQL = " UpDate " + name[1] +
                     " SET IsSync=" + bIsSync + ",IsSyncing=" + iIsSyncing +
                     " WHERE CreateInfo='" + strDateTime + "'";
            //��������
            //dbConn = accImp.SetConnect(name[0]);
            //OleDbConnection dbConn = null;
            //ִ������
            int intCounts = 0;
            while (!updateAcc.ExcuteCommand(strSQL, name[0]))
            {
                if (intCounts >= 10)
                {
                    //д�������־
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020014, "", "[AccessInterface:UpDataTable_OrgData]", "������ζ�δ�ɹ����ü�¼������������ʱ�䣩" + strDateTime + "�����ݱ�������ִ�е�Sql���Ϊ��" + strSQL);
                    }
                    return false;
                }
                intCounts++;
            }
            return true;
        }

        #endregion

        #region [ �ӿ�:  NewData��������δ���͵����ݵĴ洢��ʶ��Ϊ0 ]

        /// <summary>
        /// NewData��������δ���͵����ݵĴ洢��ʶ��Ϊ0
        /// </summary>
        /// <returns></returns>
        public bool UpData_NewData_SaveState()
        {
            //���е����ݿ�����
            string[] strMDBNames = accImp.FindAllMDBOfFile();
            foreach (string strMDBName in strMDBNames)
            {
                //�������ݿ��е����б���
                string[] strTableNames = accImp.GetTableNameBase(strMDBName);
                foreach (string strTableName in strTableNames)
                {
                    //�����NewData�����и�������
                    if (strTableName.IndexOf("NewData") != -1)
                    {
                        //SQL���
                        strSQL = "UPDATE " + strTableName + " SET SaveState = 0 where IsSend = false and SaveState <> 0";
                        //���ݿ�����
                        //dbConn = accImp.SetConnect(strMDBName.Substring(strMDBName.LastIndexOf("\\") + 1));
                        //OleDbConnection dbConn = null;
                        //ִ��ʧ�ܷ���False
                        int intCounts = 0;
                        while (!updateAcc.ExcuteCommand( strSQL, strMDBName.Substring(strMDBName.LastIndexOf("\\") + 1)))
                        {
                            if (intCounts >= 10)
                            {
                                //д�������־
                                if (ErrorMessage != null)
                                {
                                    ErrorMessage(6020014, "", "[AccessInterface:UpData_NewData_SaveState]", "������ζ�δ�ɹ������ݱ�������ִ�е�Sql���Ϊ��" + strSQL);
                                }
                                return false;
                            }
                            intCounts++;
                        }
                    }
                }
            }
            return true;
        }

        #endregion

        /*
         * �ر����ݿ�����
         */

        #region [ �ӿ�:�ر����ݿ������ ]

        /// <summary>
        ///  �ر����ݿ������
        /// </summary>
        public bool CloeseConnect()
        {
            try
            {
                //�ر����ݿ�������ݵ�����
                insertAcc.CloeseInsertConnect();
                //if (dbConn != null)
                //{
                //    if (dbConn.State == ConnectionState.Open)
                //    {
                //        dbConn.Close();
                //    }
                //}
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    _ErrorMessage(6020010, ex.StackTrace, ex.Source, ex.Message);
                }
                return false;
            }
            return true;
        }

        #endregion


        /*
         * ����� DataView ʹ��
         */

        #region  [ �ӿ�: ��֪һ�����ݿ����ƣ�����һ���������� ������ᰣ� ]

        /// <summary>
        /// ��֪һ�����ݿ����ƣ�����һ����������
        /// </summary>
        /// <param name="strMDBName">���ݿ����ƣ����磺"2008-1-25.mdb"</param>
        /// <returns>��������,����ʧ�ܷ��ؿ�</returns>
        public string[] GetTableName(string strMDBName)
        {
            //��ȡ���ݿ�·��
            string strDBPath = Application.StartupPath + @"\AccessDB\" + strMDBName;

            //��ѯ���ݿ�
            string[] strTableNames = accImp.GetTableNameBase(strDBPath);

            //�������ݿ�
            return strTableNames;
        }

        #endregion

        #region  [ �ӿ�: ��֪���ݿ����ƺͱ��������ر��е����� ������ᰣ� ]

        /// <summary>
        /// ��֪���ݿ����ƺͱ��������ر��е�����
        /// </summary>
        /// <param name="strMDBName">���ݿ�����,��"2008-1-30.mdb"</param>
        /// <param name="strTableName">��������"NewData09"</param>
        /// <returns>���ݱ�</returns>
        public DataTable DataSelectAll(string strMDBName, string strTableName)
        {
            //Command����
            string strCommand = " select * from " + strTableName;
            //�������ݿ�����
            //OleDbConnection dbConn = accImp.SetConnect(strMDBName);
            //��ѯ����
            return selectAcc.DataSelete(strCommand, strMDBName);
        }

        #endregion

    }
}