using System;
using System.Collections.Generic;
using System.Text;
using SQLDMO;
using System.IO;
using System.Xml;

namespace KJ128A.DataSave
{
    /// <summary>
    /// 
    /// </summary>
    public class DataBaseManage : IDisposable
    {
        #region [ ����: ί�� ] ������Ϣ�¼�

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

        #region [ ����: ί�� ] ���ͬ��

        /// <summary>
        /// ���ͬ��
        /// </summary>
        public delegate void SyncCompleteEventHandler();

        /// <summary>
        /// ���ͬ��
        /// </summary>
        public event SyncCompleteEventHandler SyncComplete;

        #endregion

        #region [ ί��: ���ؽ�ȥ�ٷֱ� ]

        /// <summary>
        /// ί��
        /// </summary>
        /// <param name="percent">�������Ȱٷֱ�</param>
        public delegate void GuageEventHandler(int percent);

        /// <summary>
        /// �¼�
        /// </summary>
        public event GuageEventHandler GuageEvent;

        private void GuageEventFun(int percent)
        {
            if (GuageEvent != null)
            {
                GuageEvent(percent);
            }
        }

        #endregion

        #region [ ����: ���ݿ���� ]

        private string dbName = "kj128n", dbBackUpName = "kj128nbackup";
        private SQLServer svr = null;
        private string backPath = @"d:\database\backup\", dbPath = @"d:\database\";
        private FileCopy fc = null;
        #endregion

        #region [ ����: ���캯�� ]

        /// <summary>
        /// ���캯��
        /// </summary>
        public DataBaseManage()
        {
            
        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        /// <param name="oldDbName">ԭ���ݿ���</param>
        /// <param name="backUpName">�����ݿ���</param>
        /// <param name="backUpPath">�����ݿ��ļ�·��</param>
        /// <param name="oldDbPath">ԭ���ݿ��ļ�·��</param>
        public DataBaseManage(string oldDbName, string backUpName, string backUpPath, string oldDbPath)
        {
            dbName = oldDbName;
            dbBackUpName = backUpName;
            backPath = backUpPath;
            dbPath = oldDbPath;
        }

        #endregion

        #region [ ����: �������ݿ� ]

        private bool Open()
        {
            try
            {
                string strIP = GetConfigValue("Server").ToString();
                string uid = GetConfigValue("uid").ToString();
                string pwd = GetConfigValue("pwd").ToString();

                if (svr == null)
                {
                    svr = new SQLServerClass();
                   // svr.Connect(".", "sa", "sa");
                    svr.Connect(strIP, uid, pwd);
                }
                else
                {
                    svr.Close();
                    svr = new SQLServerClass();
                   // svr.Connect(".", "sa", "sa");
                    svr.Connect(strIP, uid, pwd);
                }
                
            }
            catch (System.Runtime.InteropServices.COMException ce)
            {
                if (ce.ErrorCode == -2147203048)
                {
                    ErrorMessage(2023048, ce.StackTrace, "[DataBaseManage:Open]", ce.Message);
                    return false;
                }

                //�����ڻ���ʱ��ܾ�
                if (ce.ErrorCode == -2147221504)
                {
                    ErrorMessage(2021504, ce.StackTrace, "[DataBaseManage:Open]", ce.Message);
                    return false;
                }
            }
            return true;
        }

        //private void LinkNull(SQLServer svr)
        //{
        //    //if (svr != null)
        //    //{
        //    //    svr.Close();
        //    //    svr = null;
        //    //}
        //}

        /// <summary>
        /// �������ݿⲢ����
        /// </summary>
        /// <returns>ִ�н��</returns>
        public bool LinkSql()
        {
            string strIP = GetConfigValue("Server").ToString();
            string uid = GetConfigValue("uid").ToString();
            string pwd = GetConfigValue("pwd").ToString();
            try
            {
               // svr.Start(true, ".", "sa", "sa");
                svr.Start(true, strIP, uid, pwd);
            }
            catch (System.Runtime.InteropServices.COMException ce)
            {
                //�����ڻ���ʱ��ܾ�
                if (ce.ErrorCode == -2147221504)
                {
                    //ErrorMessage(-2147221504, ce.StackTrace, "[DataBaseManage:InitCheckDB]", ce.Message);
                    ErrorMessage(2021504,ce.StackTrace,"[DataBaseManage:LinkSql]", ce.Message);
                    return false;
                }
                // ����ķ�������������
                if (ce.ErrorCode == -2147023840)
                {
                    //svr.Connect(".", "sa", "sa");
                    svr.Start(true, strIP, uid, pwd);
                }
            }
            return true;
        }

        #endregion

        #region [ ����: ������ݿ� ]

        /// <summary>
        /// ������ݿ�
        /// </summary>
        /// <returns></returns>
        public bool InitCheckDB()
        {
            // ������ݿ�
            return CheckDBState();
        }

        #endregion

        #region [ private����: ������ݿ� ]

        /// <summary>
        /// ������ݿ�
        /// </summary>
        private bool CheckDBState()
        {
            // �߼�:������ݿ�û�������ݿ���ʱ�鿴�ļ�,���ļ�����,�����ݿ�û�ļ�ʱͬ���������ݿ����ļ��򸽼�
            bool bl = false;
            bool falg = true;
            try
            {
                if (!Open())
                {
                    return false;
                }
                foreach (Database db in svr.Databases)
                {
                    if (db.Name != null && db.Name.ToLowerInvariant() == dbName)
                    {
                        bl = true;
                        break;
                    }
                }

                if (!bl)
                {
                    if (File.Exists(dbPath + dbName + ".mdf"))
                    {
                        svr.AttachDB(dbName, dbPath + dbName + ".mdf;" + dbPath + dbName + "_log.ldf");
                    }
                    else
                    {
                        ErrorMessage(2024001, "", "[DataBaseManage:CheckDBState]", "û�з���kj128���ݿ�");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(6024002, ex.StackTrace, "[DataBaseManage:CheckDBState]", ex.Message);
                falg = false;
            }
            //finally
            //{
            //    LinkNull(svr);
            //}
            return falg;
        }

        #endregion

        #region [ ����: ��� KJ128NBcakUp���ݿ��Ƿ���� ]
        /// <summary>
        /// ��� KJ128NBcakUp���ݿ��Ƿ����
        /// </summary>
        /// <returns>True:����;False:������</returns>
        public bool CheckBackUpDBState()
        {
            bool bl = false;
            try
            {
                if (!Open())
                {
                    return false;
                }
                foreach (Database db in svr.Databases)
                {
                    if (db.Name != null && db.Name.ToLowerInvariant() == "kj128nbackup")
                    {
                        bl = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(6024002, ex.StackTrace, "[DataBaseManage:CheckDBState]", ex.Message);
            }
            //finally
            //{
            //    LinkNull(svr);
            //}
            return bl;
        }

        #endregion

        #region [ ����: ɾ���������ݿ� ]

        /// <summary>
        /// ɾ���������ݿ�
        /// </summary>
        /// <returns></returns>
        public bool DBDelete()
        {
            bool falg = true;
            try
            {
                if (!Open())
                {
                    return false;
                }
                foreach (Database db in svr.Databases)
                {
                    if (db.Name != null && db.Name.ToLowerInvariant() == dbBackUpName)
                    {
                        #region �ر�sql����
                        // ��ȡ���еĽ����б�
                        SQLDMO.QueryResults qr = svr.EnumProcesses(-1);

                        // ���� SPID �� DBName ��λ��
                        int iColPIDNum = -1;        // ��� SPID ��λ��
                        int iColDbName = -1;        // ��� DBName ��λ��

                        for (int i = 1; i <= qr.Columns; i++)
                        {
                            string strName = qr.get_ColumnName(i);

                            if (strName.ToUpper().Trim() == "SPID")
                            {
                                // ��� SPID
                                iColPIDNum = i;
                            }
                            else if (strName.ToUpper().Trim() == "DBNAME")
                            {
                                // ��� DBName
                                iColDbName = i;
                            }

                            // ����ҵ� SPID �� DBName, ������ѭ��
                            if (iColPIDNum != -1 && iColDbName != -1)
                            {
                                break;
                            }
                        }

                        // �������ڲ���ָ���ָ������ݿ�Ľ��̣�����ǿ����ֹ
                        for (int i = 1; i <= qr.Rows; i++)
                        {
                            // ��ȡ�ý������ڲ��������ݿ�����
                            int lPID = qr.GetColumnLong(i, iColPIDNum);
                            string strDBName = qr.GetColumnString(i, iColDbName);

                            // �ȶԱ����������ݿ��Ƿ�������Ҫ��ԭ�����ݿ�
                            if (strDBName.ToUpper() == dbBackUpName.ToUpper())
                            {
                                svr.KillProcess(lPID);
                            }
                        }
                        #endregion

                        // ɾ�������ݿ�
                        svr.KillDatabase(dbBackUpName);

                        break;
                    }
                }
            }
            catch (System.Runtime.InteropServices.COMException ce)
            {
                if (ce.ErrorCode == -2147217803)
                {
                    // ������� ����ʹ���޷�ɾ��
                    ErrorMessage(202, ce.StackTrace, "[DBManage:DBDelete]", ce.Message);
                }
                falg = false;
            }
            //finally
            //{
            //    LinkNull(svr);
            //}
            return falg;

        }

        #endregion

        #region[�������ݿ�]
        public bool ZipDataBase()
        {
            bool falg = true;
            try
            {
                if (!Open())
                {
                    return false;
                }
                foreach (Database db in svr.Databases)
                {
                    if (db.Name != null && db.Name.ToLowerInvariant() == dbName)
                    {
                        #region �ر�sql����
                        // ��ȡ���еĽ����б�
                        SQLDMO.QueryResults qr = svr.EnumProcesses(-1);

                        // ���� SPID �� DBName ��λ��
                        int iColPIDNum = -1;        // ��� SPID ��λ��
                        int iColDbName = -1;        // ��� DBName ��λ��

                        for (int i = 1; i <= qr.Columns; i++)
                        {
                            string strName = qr.get_ColumnName(i);

                            if (strName.ToUpper().Trim() == "SPID")
                            {
                                // ��� SPID
                                iColPIDNum = i;
                            }
                            else if (strName.ToUpper().Trim() == "DBNAME")
                            {
                                // ��� DBName
                                iColDbName = i;
                            }

                            // ����ҵ� SPID �� DBName, ������ѭ��
                            if (iColPIDNum != -1 && iColDbName != -1)
                            {
                                break;
                            }
                        }

                        // �������ڲ���ָ���ָ������ݿ�Ľ��̣�����ǿ����ֹ
                        for (int i = 1; i <= qr.Rows; i++)
                        {
                            // ��ȡ�ý������ڲ��������ݿ�����
                            int lPID = qr.GetColumnLong(i, iColPIDNum);
                            string strDBName = qr.GetColumnString(i, iColDbName);

                            // �ȶԱ����������ݿ��Ƿ�������Ҫ��ԭ�����ݿ�
                            if (strDBName.ToUpper() == dbBackUpName.ToUpper())
                            {
                                svr.KillProcess(lPID);
                            }
                        }
                        #endregion
                        db.Shrink(-1, 0);

                        break;
                    }
                }
            }
            catch (System.Runtime.InteropServices.COMException ce)
            {
                if (ce.ErrorCode == -2147217803)
                {
                    if (ErrorMessage!=null)
                    {
                        // ������� ����ʹ���޷�ɾ��
                        ErrorMessage(202, ce.StackTrace, "[DBManage:DBzip]", ce.Message);
                    }
                }
                falg = false;
            }
            //finally
            //{
            //    LinkNull(svr);
            //}
            return falg;
        }
        #endregion

        #region [ ����: �������ݿ�ͬ�� ]

        /// <summary>
        /// ���ݿ�����ͬ��
        /// </summary>
        /// <returns></returns>
        public void DBSync()
        {
            try
            {
                // ɾ�������ݿ�
                if (!DBDelete())
                {

                }

                int dbSize = 1;
                Open();
                foreach (Database db in svr.Databases)
                {
                    if (db.Name == dbName)
                    {
                        //�õ����ݿ��С
                        dbSize = db.FileGroups.Item(1).DBFiles.Item(1).Size;
                        break;
                    }
                }
                #region [ �жϴ���ʣ��ռ��Ƿ�ɽ��б��� ]

                // ��ȡ����ʣ��ռ��С
                DriveInfo d = new DriveInfo(dbPath.Substring(0, 1));
                int diskSize = Convert.ToInt32(d.AvailableFreeSpace / 1024 / 1024);
                if (diskSize < dbSize)
                {
                    ErrorMessage(2024003, "", "[DataBaseManage:CheckDBState]", "�������ݿ�������̿ռ䲻��" + dbSize + "M\r\n����[" + d.Name + "]�洢�ռ��С,�޷�����");
                    return;
                }
                #endregion

                #region [ ǿ�ƹر������ݿ������ ]
                // ��ȡ���еĽ����б�
                SQLDMO.QueryResults qr = svr.EnumProcesses(-1);

                // ���� SPID �� DBName ��λ��
                int iColPIDNum = -1;        // ��� SPID ��λ��
                int iColDbName = -1;        // ��� DBName ��λ��

                for (int i = 1; i <= qr.Columns; i++)
                {
                    string strName = qr.get_ColumnName(i);

                    if (strName.ToUpper().Trim() == "SPID")
                    {
                        // ��� SPID
                        iColPIDNum = i;
                    }
                    else if (strName.ToUpper().Trim() == "DBNAME")
                    {
                        // ��� DBName
                        iColDbName = i;
                    }

                    // ����ҵ� SPID �� DBName, ������ѭ��
                    if (iColPIDNum != -1 && iColDbName != -1)
                    {
                        break;
                    }
                }

                // �������ڲ���ָ���ָ������ݿ�Ľ��̣�����ǿ����ֹ
                for (int i = 1; i <= qr.Rows; i++)
                {
                    // ��ȡ�ý������ڲ��������ݿ�����
                    int lPID = qr.GetColumnLong(i, iColPIDNum);
                    string strDBName = qr.GetColumnString(i, iColDbName);

                    // �ȶԱ����������ݿ��Ƿ�������Ҫ��ԭ�����ݿ�
                    if (strDBName.ToUpper() == dbName.ToUpper())
                    {
                        svr.KillProcess(lPID);
                    }
                }
                #endregion
                // ����ԭ���ݿ�
                string s = svr.DetachDB(dbName, false);

                // �ж� �ļ��в������򴴽� �ļ�������ɾ�� 
                if (!Directory.Exists(backPath))
                {
                    Directory.CreateDirectory(backPath);
                }

                try
                {
                    // ɾ�������ݿ�
                    svr.KillDatabase(dbBackUpName);
                }
                catch { }

                // �����ݿ����ļ�
                if (File.Exists(backPath + dbName + ".mdf"))
                {
                    // ����ԭ���ݿ�
                    try
                    {
                        svr.DetachDB(dbBackUpName, false);
                    }
                    catch { }
                    File.Delete(backPath + dbName + ".mdf");
                }
                // �����ݿ���־�ļ�
                if (File.Exists(backPath + dbBackUpName + "_log.ldf"))
                {
                    File.Delete(backPath + dbBackUpName + "_log.ldf");
                }

                #region copy�ļ�

                fc = new FileCopy(dbPath + dbName + ".mdf", backPath + dbName + ".mdf");
                fc.CopyComplete += new FileCopy.CopyCompleteEventHandler(fc_CopyComplete);
                fc.GuageEvent += new FileCopy.GuageEventHandler(fc_GuageEvent);
                // ��ʼcopy
                fc.Copy();
                
                #endregion

            }
            catch (System.Runtime.InteropServices.COMException ce)
            {
                if (ce.ErrorCode == -2147217803)//("��Ϊ����ǰ����ʹ��") != -1)
                {
                    // ������� ����ʹ���޷�ɾ��
                    ErrorMessage(-2147217803, ce.StackTrace, "[DBManage:DBSync]", ce.Message);
                }
            }
            //finally
            //{
            //    LinkNull(svr);
            //}
        }

        void fc_GuageEvent(int percent)
        {
            GuageEventFun(percent);
        }

        #region [ ����: ֹͣ���ݿ�ͬ�� ]

        /// <summary>
        /// ֹͣ���ݿ�ͬ��
        /// </summary>
        public void Close()
        {
            if (fc != null)
            {
                fc.Close();
                fc.Dispose();
                if (File.Exists(backPath + dbName + ".mdf"))
                {
                    try
                    {
                        File.Delete(backPath + dbName + ".mdf");
                    }
                    catch { }
                }
                // �����ݿ���־�ļ�
                if (File.Exists(backPath + dbBackUpName + "_log.ldf"))
                {
                    try
                    {
                        File.Delete(backPath + dbBackUpName + "_log.ldf");
                    }
                    catch { }
                }
                InitCheckDB();
            }
        }

        #endregion

        /// <summary>
        /// �������
        /// </summary>
        void fc_CopyComplete()
        {
            //try
            //{
            //    Open();
            //    // �������ݿ�
            //    svr.AttachDB(dbName, dbPath + dbName + @".mdf;" + dbPath + dbName + "_log.ldf");
            //    svr.AttachDBWithSingleFile(dbBackUpName, backPath + dbName + @".mdf");
            //}
            //catch (System.Runtime.InteropServices.COMException ce)
            //{
            //    //LinkNull(svr);
            //    if (ce.ErrorCode == -2147217803)//("��Ϊ����ǰ����ʹ��") != -1)
            //    {
            //        // ������� ����ʹ���޷�ɾ��
            //        ErrorMessage(-2147217803, ce.StackTrace, "[DBManage:DBSync]", ce.Message);
            //    }
            //}
            //finally
            //{
            //    LinkNull(svr);
            //}
            // ���ݿ�ͬ�����
            SyncCompleteFun();
        }

        private void SyncCompleteFun()
        {
            if (SyncComplete != null)
            {
                SyncComplete();
            }
        }

        #endregion

        #region [ ����: �ͷ� ]

        /// <summary>
        /// �ͷ�
        /// </summary>
        public void Dispose()
        {
            //if (svr != null)
            //{
            //    svr.Close();
            //    svr = null;
            //}
        }

        #endregion
        
        #region����ȡ���ݿ��������ӡ�
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appKey"></param>
        /// <returns></returns>
        private string GetConfigValue(string appKey)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(System.Windows.Forms.Application.StartupPath + "\\KJ128NMainRun.exe.config");

                XmlNode xNode;
                XmlElement xElem;
                xNode = xDoc.SelectSingleNode("//appSettings");
                xElem = (XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
                if (xElem != null)
                    return xElem.GetAttribute("value");
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
        #endregion
    }
}
