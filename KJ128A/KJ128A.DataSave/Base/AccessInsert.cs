using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Threading;

namespace KJ128A.DataSave
{

    /// <summary>
    /// Access���ݲ�����
    /// </summary>
    public class AccessInsert
    {

        #region [ ���� ]

        // �������ݿ�ʵʱ����
        private static OleDbConnection dbNewSql = null;

        //����Access��Ŀ¼·��
        private readonly string strAccessPath = System.Windows.Forms.Application.StartupPath + @"\AccessDB";

        private DateTime nowMark;  // ʵʱ���ݱ�־

        private readonly AccessBase accImp = new AccessBase();

        private readonly DiskCheck check = new DiskCheck();

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
        public AccessInsert()
        {
            //ע��ί���¼�
            check.InitListenFreeSpace += c_FreeSpace;
            accImp.ErrorMessage += _ErrorMessage;
            //ʵ����
            nowMark = DateTime.Now;
            //��鲢�������ݿ�
            accImp.CreateMDBFile(nowMark);
            //��������
            //dbNewSql = accImp.SetConnect(nowMark.ToString("yyyy-MM-dd") + ".mdb");
        }

        #endregion

        #region [ ע��ί�� : ������Ϣ ]

        /// <summary>
        /// ������Ϣ�¼�����
        /// </summary>
        /// <param name="iErrNO">������</param>
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

        #region [ ע��ί�� : ������̷��� ]

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="flag">1����ʾ��Ҫ�û�������̿ռ䣻2����ʾ����ֱ��������̿ռ�</param>
        private void c_FreeSpace(int flag)
        {
            if (flag == 2)
            {
                string[] strFileName =accImp.FindAllMDBOfFile(strAccessPath);
                if (strFileName != null)
                {
                    if (strFileName.Length > 0)
                    {
                        try
                        {
                            accImp.CancelFileReadOnly(strFileName[0]);
                            File.Delete(strFileName[0]);
                            if (ErrorMessage != null)
                            {
                                ErrorMessage(4020001, "", "", "");
                                //ShowMessage("ע�⣺ϵͳ�Ѿ����������һЩ���̿ռ䣬Ϊ��֤�������ȷ���������������������̣�", true);
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ErrorMessage != null)
                            {
                                ErrorMessage(6020013, ex.StackTrace, ex.Source, ex.Message);
                            }
                        }
                    }
                }
            }
            else if (flag == 1)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(4020002, "", "", "");
                    //ShowMessage("ע�⣺���̿ռ䲻��200M���뾡��������̣�����������С��100Mʱ�����ǽ�ǿ��������̣�", true);
                }
            }
        }

        #endregion

        /*
         * �ⲿ����
         */

        #region [ ����:�ر����ݿ�������ݵ����� ]

        /// <summary>
        ///  �ر����ݿ�������ݵ�����
        /// </summary>
        public bool CloeseInsertConnect()
        {
            try
            {
                if (dbNewSql != null)
                {
                    dbNewSql.Dispose();
                    dbNewSql = null;
                }
            }
            catch(Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6020010, ex.StackTrace, "[InsertAccess:CloeseInsertConnect]", ex.Message);
                }
                return false;
            }

            return true;
        }

        #endregion

        #region [����������������Ϣ]
        /// <summary>
        /// ����������Ϣ
        /// </summary>
        /// <param name="strDateTime"></param>
        /// <param name="bytes"></param>
        /// <param name="bIsSync"></param>
        /// <param name="intIsSyncing"></param>
        /// <returns></returns>
        public bool SveDate_Config(string strDateTime, byte[] bytes, bool bIsSync, int intIsSyncing)
        {
            OleDbCommand oleDbComm = SetOleDBPar_Config(strDateTime, bytes, bIsSync, intIsSyncing);   // �����������Command����
            bool falg = true;
            int intCounts = 0;
            while (!InsertData(1,oleDbComm, strDateTime, bytes))
            {
                if (intCounts >= 5)
                {
                    //д�������־
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020015, "", "[AccessInsert:SaveData_Config]", "������ζ�δ�ɹ����ü�¼������������ʱ�䣩" + strDateTime);
                    }
                    falg = false;
                    break;
                }
                intCounts++;
                Thread.Sleep(10);
            }
            if (oleDbComm != null)
            {
                oleDbComm.Dispose();
                oleDbComm = null;
            }
            return falg;
        }

        #endregion

        #region [ ����: ����ԭʼ��(OrgData)���� ]

        /// <summary>
        /// ����ԭʼ��(OrgData)����
        /// </summary>
        /// <param name="dt">����ʱ��</param>
        /// <param name="dataStream">��������(Byte[])</param>
        /// <param name="bIsSync">��ͬ����־λ</param>
        /// <param name="intIsSyncing">ͬ���е�״̬</param>
        /// <returns>True:�ɹ�; False:ʧ��</returns>
        public bool SaveData_OrgData(DateTime dt, byte[] dataStream, bool bIsSync, int intIsSyncing)
        {
            OleDbCommand oleDbComm = SetOleDbPar_OrgData(dt, dataStream, bIsSync, intIsSyncing);   // �����������Command����
            bool falg = true;
            int intCounts = 0;
            while (!InsertData(0,oleDbComm, dt.ToString("yyyyMMddHHmmssfff"), dataStream))
            {
                if (intCounts >= 5)
                {
                    //д�������־
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020015, "", "[AccessInsert:SaveData_OrgData]", "������ζ�δ�ɹ����ü�¼������������ʱ�䣩" + dt.ToString("yyyyMMddHHmmssfff"));
                    }
                    falg = false;
                    break;
                }
                //dbConn = accImp.SetConnect(dbConn.DataSource.Substring(dbConn.DataSource.LastIndexOf("\\")+1));
                intCounts++;
                Thread.Sleep(10);
            }
            if (oleDbComm != null)
            {
                oleDbComm.Dispose();
                oleDbComm = null;
            }
            return falg;
        }
        /// <summary>
        /// ����ԭʼ��(OrgData)����
        /// </summary>
        /// <param name="strDateTime">����ʱ��</param>
        /// <param name="dataStream">��������(Byte[])</param>
        /// <param name="bIsSync">��ͬ����־λ</param>
        /// <param name="intIsSyncing">ͬ���е�״̬</param>
        /// <returns>True:�ɹ�; False:ʧ��</returns>
        public bool SaveData_OrgData(string strDateTime, byte[] dataStream, bool bIsSync, int intIsSyncing)
        {
            OleDbCommand oleDbComm = SetOleDbPar_OrgData(strDateTime, dataStream, bIsSync, intIsSyncing);   // �����������Command����
            bool falg = true;
            int intCounts = 0;
            while (!InsertData(0,oleDbComm, strDateTime, dataStream))
            {
                if (intCounts >= 5)
                {
                    //д�������־
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020015, "", "[AccessInsert:SaveData_OrgData]", "������ζ�δ�ɹ����ü�¼������������ʱ�䣩" + strDateTime);
                    }
                    falg = false;
                    break;
                }
                //dbConn = accImp.SetConnect(dbConn.DataSource.Substring(dbConn.DataSource.LastIndexOf("\\")+1));
                intCounts++;
                Thread.Sleep(10);
            }
            if (oleDbComm != null)
            {
                oleDbComm.Dispose();
                oleDbComm = null;
            }
            return falg;
        }
        #endregion

        #region [ ����: ���淢�ͱ�(NewData)���� ]

        /// <summary>
        /// ���淢�ͱ�(NewData)����
        /// </summary>
        /// <param name="strCreateInfo">����ʱ���ַ���</param>
        /// <param name="dataStream">��������(Byte[])</param>
        /// <param name="bIsSend">�ѷ��ͱ�־λ</param>
        /// <param name="bIsSending">�����е�״̬</param>
        /// <param name="iSaveState">�洢״̬</param>
        /// <returns>True:�ɹ�; False:ʧ��</returns>
        public bool SaveData_NewData( string strCreateInfo, byte[] dataStream, bool bIsSend, bool bIsSending, int iSaveState)
        {
            bool falg = true;
            OleDbCommand oleDbComm =
                SetOleDbPar_NewData(strCreateInfo, dataStream, bIsSend, bIsSending, iSaveState);

            int intCounts = 0;
            while (!InsertData(0,oleDbComm, strCreateInfo, dataStream))
            {
                if (intCounts >= 5)
                {
                    //д�������־
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020015, "", "[AccessInsert:SaveData_NewData]", "������ζ�δ�ɹ����ü�¼������������ʱ�䣩" + strCreateInfo);
                    }
                    falg = false;
                    break;
                }
                intCounts++;
                Thread.Sleep(10);
            }
            if (oleDbComm != null)
            {
                oleDbComm.Dispose();
                oleDbComm = null;
            }
            
            return falg;
        }

        #endregion

        /*
         * �ڲ�����
         */

        #region [ ����: ��ȡ��ǰ��Ч���� ]

        /// <summary>
        /// ��ȡ��ǰ��Ч����
        /// </summary>
        /// <param name="dt">����ʱ�����</param>
        /// <returns>���ݿ�����</returns>
        public  IDbConnection GetConnectionByTime(DateTime dt)
        {
           
            // ��������ں͵�ǰ���ӵ����ڲ����
            if (dt.Year * 10000 + dt.Month * 100 + dt.Day != nowMark.Year * 10000 + nowMark.Month * 100 + nowMark.Day)
            {
                nowMark = dt;

                //���̿ռ���
                check.hardCheckMessure();

                //����Ƿ�Ҫ�����µ����ݿ�
                accImp.CreateMDBFile(nowMark);

                //ʵ�����ݿ�����
                //dbNewSql = accImp.SetConnect(nowMark.ToString("yyyy-MM-dd") + ".mdb");

                return dbNewSql;
            }
            else
            {
                return dbNewSql;
            }
        }

        #endregion

        #region [�������������ñ�Command����]
        /// <summary>
        /// �������ñ�Command����
        /// </summary>
        /// <param name="strDatetime"></param>
        /// <param name="bytes"></param>
        /// <param name="bIsSync"></param>
        /// <param name="intIsSyncing"></param>
        /// <returns></returns>
        public OleDbCommand SetOleDBPar_Config(string strDatetime, byte[] bytes, bool bIsSync, int intIsSyncing)
        {
            string[] name = accImp.GetInforFromString(strDatetime);
            string strTableName = name[1];        // ����
            string strCreateInfo = strDatetime;    // CreateInfo �ֶ���Ϣ  ���ݿ��������Ϣ
            int intDataLen = bytes.Length;                         // �ֽ����鳤��

            string strCommand = "INSERT INTO " + strTableName + " ( CreateInfo,CmdLen,CmdInfo,IsSync,IsSyncing ) VALUES(@strCreateInfo,@intDataLen,@dataStream,@bIsSync,@intIsSyncing)";

            OleDbParameter[] oleParmeters ={
                new OleDbParameter("@strCreateInfo", OleDbType.VarWChar),
                new OleDbParameter("@intDataLen", OleDbType.Integer),
                new OleDbParameter("@dataStream", OleDbType.Binary),
                new OleDbParameter("@bIsSync", OleDbType.Boolean),
                new OleDbParameter("@intIsSyncing", OleDbType.Integer)
                };
            oleParmeters[0].Value = strCreateInfo;
            oleParmeters[1].Value = intDataLen;
            oleParmeters[2].Value = bytes;
            oleParmeters[3].Value = bIsSync;
            oleParmeters[4].Value = intIsSyncing;

            return accImp.BuildOleDbCommand(strCommand, oleParmeters);
        }
        #endregion

        #region[ ����: ����ԭʼ��(OrgData)Command���� ]

        /// <summary>
        /// ����ԭʼ��(OrgData)Command����
        /// </summary>
        /// <param name="dt">����ʱ��</param>
        /// <param name="dataStream">��������(Byte[])</param>
        /// <param name="bIsSync">��ͬ����־λ</param>
        /// <param name="intIsSyncing">ͬ���е�״̬</param>
        /// <returns>����Command����</returns>
        public OleDbCommand SetOleDbPar_OrgData(DateTime dt, byte[] dataStream, bool bIsSync, int intIsSyncing)
        {

            string strTableName = "OrgData" + dt.ToString("HH");        // ����
            string strCreateInfo = dt.ToString("yyyyMMddHHmmssfff");    // CreateInfo �ֶ���Ϣ  ���ݿ��������Ϣ
            int intDataLen = dataStream.Length;                         // �ֽ����鳤��

            string strCommand = "INSERT INTO " + strTableName + " ( CreateInfo,CmdLen,CmdInfo,IsSync,IsSyncing ) VALUES(@strCreateInfo,@intDataLen,@dataStream,@bIsSync,@intIsSyncing)";

            OleDbParameter[] oleParmeters ={
                new OleDbParameter("@strCreateInfo", OleDbType.VarWChar),
                new OleDbParameter("@intDataLen", OleDbType.Integer),
                new OleDbParameter("@dataStream", OleDbType.Binary),
                new OleDbParameter("@bIsSync", OleDbType.Boolean),
                new OleDbParameter("@intIsSyncing", OleDbType.Integer)
                };
            oleParmeters[0].Value = strCreateInfo;
            oleParmeters[1].Value = intDataLen;
            oleParmeters[2].Value = dataStream;
            oleParmeters[3].Value = bIsSync;
            oleParmeters[4].Value = intIsSyncing;

            return accImp.BuildOleDbCommand(strCommand, oleParmeters);
        }

        /// <summary>
        /// ����ԭʼ��(OrgData)Command����
        /// </summary>
        /// <param name="strDateTime">����ʱ��</param>
        /// <param name="dataStream">��������(Byte[])</param>
        /// <param name="bIsSync">��ͬ����־λ</param>
        /// <param name="intIsSyncing">ͬ���е�״̬</param>
        /// <returns>����Command����</returns>
        public OleDbCommand SetOleDbPar_OrgData(string strDateTime, byte[] dataStream, bool bIsSync, int intIsSyncing)
        {
            //string[] name = accImp.GetInforFromString(databaseType, strDateTime);
            string[] name = accImp.GetInforFromString(true, strDateTime);
            string strTableName = name[1];     //����
            string strCreateInfo = strDateTime;    // CreateInfo �ֶ���Ϣ  ���ݿ��������Ϣ
            int intDataLen = dataStream.Length;                         // �ֽ����鳤��

            string strCommand = "INSERT INTO " + strTableName + " ( CreateInfo,CmdLen,CmdInfo,IsSync,IsSyncing ) VALUES(@strCreateInfo,@intDataLen,@dataStream,@bIsSync,@intIsSyncing)";

            OleDbParameter[] oleParmeters ={
                new OleDbParameter("@strCreateInfo", OleDbType.VarWChar),
                new OleDbParameter("@intDataLen", OleDbType.Integer),
                new OleDbParameter("@dataStream", OleDbType.Binary),
                new OleDbParameter("@bIsSync", OleDbType.Boolean),
                new OleDbParameter("@intIsSyncing", OleDbType.Integer)
                };
            oleParmeters[0].Value = strCreateInfo;
            oleParmeters[1].Value = intDataLen;
            oleParmeters[2].Value = dataStream;
            oleParmeters[3].Value = bIsSync;
            oleParmeters[4].Value = intIsSyncing;

            return accImp.BuildOleDbCommand(strCommand, oleParmeters);
        }

        #endregion

        #region[ ����: ���÷��ͱ�(NewData)Command���� ]

        /// <summary>
        /// ���÷��ͱ�(NewData)Command����
        /// </summary>
        /// <param name="strCreateInfo">����ʱ���ַ���</param>
        /// <param name="dataStream">��������(Byte[])</param>
        /// <param name="bIsSend">�ѷ��ͱ�־λ</param>
        /// <param name="bIsSending">�����е�״̬</param>
        /// <param name="iSaveState">�洢״̬</param>
        /// <returns>����Command����</returns>
        public OleDbCommand SetOleDbPar_NewData(string strCreateInfo, byte[] dataStream, bool bIsSend, bool bIsSending, int iSaveState)
        {
            //string[] name = accImp.GetInforFromString(databaseType, strCreateInfo);
            string[] name = accImp.GetInforFromString(false, strCreateInfo);
            string strTableName = name[1];     //����
            int intDataLen = dataStream.Length;     //CmdLen�ֶ�
            string strCommand = "INSERT INTO " + strTableName + " ( CreateInfo,CmdLen,CmdInfo,IsSend,IsSending,SaveState ) VALUES(@strCreateInfo,@intDataLen,@dataStream,@bIsSend,@bIsSending,@iSaveState)";

            OleDbParameter[] oleParmeters ={
                new OleDbParameter("@strCreateInfo", OleDbType.VarWChar),
                new OleDbParameter("@intDataLen", OleDbType.Integer),
                new OleDbParameter("@dataStream", OleDbType.Binary),
                new OleDbParameter("@bIsSend", OleDbType.Boolean),
                new OleDbParameter("@bIsSending", OleDbType.Boolean),
                new OleDbParameter("@iSaveState",OleDbType.Integer)
            };
            oleParmeters[0].Value = strCreateInfo;
            oleParmeters[1].Value = intDataLen;
            oleParmeters[2].Value = dataStream;
            oleParmeters[3].Value = bIsSend;
            oleParmeters[4].Value = bIsSending;
            oleParmeters[5].Value = iSaveState;

            return accImp.BuildOleDbCommand(strCommand, oleParmeters);
        }

        #endregion

        #region [ ����: ����в������ݣ�����������]

        /// <summary>
        /// ����в������ݣ�����������
        /// </summary>
        /// <param name="dbCommand">Command����</param>
        /// <param name="strCreateInfo"></param>
        /// <param name="dataStream"></param>
        /// <returns>�����ɹ�����True</returns>
        private bool InsertData(int insertType,OleDbCommand dbCommand, string strCreateInfo, byte[] dataStream)
        {
            bool falg = true;
            DateTime dt = new DateTime(2000, 1, 1, 0, 0, 0);
            try
            {
                string newTime = strCreateInfo.Substring(0, 4) + "." + strCreateInfo.Substring(4, 2) + "." +
                             strCreateInfo.Substring(6, 2);
                dt = Convert.ToDateTime(newTime);
            }
            catch
            {
                return true;
            }
            if (dt.Equals(new DateTime(2000, 1, 1, 0, 0, 0)))
            {
                return true;
            }
            string filename;
            filename = dt.ToString("yyyy-MM-dd") + ".mdb";
            if (insertType != 0)
            {
                filename = "Config\\config" + filename;
            }
            OleDbConnection conn = null; // ��ȡ��Ч������
            
            try
            {
                conn = DAO.GetConn(filename); // ��ȡ��Ч������
                dbCommand.Connection = conn;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                dbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                if (Thread.CurrentThread.Name == "DataSave")
                    Thread.Sleep(100);
                if (ex.Message.IndexOf("�Ҳ��������") != -1)
                {
                    try
                    {
                        if (ex.Message.IndexOf("NewData") != -1)
                        {
                            //����New��
                            accImp.CreateNewTable(filename, ex.Message.Substring(ex.Message.IndexOf("'") + 1, 9));
                        }
                        else if(ex.Message.IndexOf("OrgData") != -1)
                        {
                            //����Org��
                            accImp.CreateOrgTable(filename, ex.Message.Substring(ex.Message.IndexOf("'") + 1, 9));
                        }
                        else if (ex.Message.IndexOf("ConfigData") != -1)
                        {
                            //����Config��
                            accImp.CreateConfigTable(filename, ex.Message.Substring(ex.Message.IndexOf("'") + 1, 12));
                        }
                    }
                    catch { }
                    falg = false;
                }
                else if (ex.Message.IndexOf("��������ʹ��һ���ɸ��µĲ�ѯ") != -1)
                {
                    try
                    {
                        accImp.CancelFileReadOnly(conn.DataSource);
                    }
                    catch { }
                    falg = false;
                }
                else if (ex.Message.IndexOf("�Ҳ����ļ�") != -1)
                {
                    try
                    {
                        accImp.CopyMDB(conn.DataSource);
                    }
                    catch { }
                    falg = false;
                }
                else if (ex.Message.IndexOf("�����ظ���ֵ") != -1)
                {
                    //if (ErrorMessage != null)
                    //{
                    //    ErrorMessage(6020006, ex.StackTrace, "[InsertAccess:InsertData]", "���ظ���ֵ����" + dataStream[0].ToString() + "." + dataStream[1].ToString() + "." + dataStream[2].ToString() + "." + strCreateInfo);
                    //}
                    falg = true;
                    //Thread.Sleep(80);
                }
                else if (ex.Message.IndexOf("��ǰ������") != -1)
                {
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020006, ex.StackTrace, "[InsertAccess:InsertData]", ex.Message + Thread.CurrentThread.Name);
                    }
                    falg = false;
                    Thread.Sleep(100);
                }
                else if (ex.Message.IndexOf("�������������û���ͼͬʱ�ı�ͬһ����") != -1)
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                        conn.Dispose();
                        conn = null;
                    }
                    try
                    {
                        string strfilenameTemp = filename.Replace(".mdb", ".ldb");
                        if (File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + strfilenameTemp))
                        {
                            File.Delete(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + strfilenameTemp);
                        }
                        File.Delete(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + filename);
                    }
                    catch { }
                    Thread.Sleep(100);
                    falg = false;
                }
                else if (ex.Message.IndexOf("����ʶ������ݿ��ʽ") != -1)
                {
                    //if (ErrorMessage != null)
                    //{
                    //    ErrorMessage(6020006, ex.StackTrace, "[InsertAccess:InsertData]", ex.Message + Thread.CurrentThread.Name);
                    //}
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                        conn.Dispose();
                        conn = null;
                    }
                    try
                    {
                        string strfilenameTemp = filename.Replace(".mdb", ".ldb");
                        if (File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + strfilenameTemp))
                        {
                            File.Delete(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + strfilenameTemp);
                        }
                        File.Delete(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + filename);
                    }
                    catch{}
                    //catch(Exception ee) 
                    //{
                    //    string s = ee.Message;
                    //}
                    Thread.Sleep(100);
                    falg = false;
                }
                else
                {
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020006, ex.StackTrace, "[InsertAccess:InsertData]", ex.Message + Thread.CurrentThread.Name);
                    }
                    Thread.Sleep(100);
                    falg = false;
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                    conn = null;
                }
            }
            return falg;
        }

        #endregion

    }
}
