using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using KJ128NDataBase;
using System.Data;
using Microsoft.VisualBasic;
using System.Configuration;

namespace KJ128NMainRun
{
    public static class DataOperateBLL
    {
        private static ProgressBar pBar;

        #region [ ����: ��ȡ���ݿ�������б� ]

        // ���û�������ʱ��������Ҫ�г���ǰ�����������е����ݿ������������Ҫ�г�ָ�����������������ݿ⣬ʵ�ִ������£� 
        // ȡ�����ݿ�������б�

        /// <summary>
        /// ��ȡ���ݿ�������б�
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetServerList(out bool isErr)
        {
            ArrayList allServers = new ArrayList();
            try
            {
                SQLDMO.Application sqlApp = new SQLDMO.ApplicationClass();
                // ����������������ܹ�����SQL�ķ����������г�
                SQLDMO.NameList serverList = sqlApp.ListAvailableSQLServers();

                allServers.Add("(local)");
                for (int i = 1; i <= serverList.Count; i++)
                {
                    // ��ӵ��б���
                    allServers.Add(serverList.Item(i));
                }
                sqlApp.Quit();
                isErr = true;
            }
            catch (Exception e)
            {
                isErr = SqlErrRepair(e.Message.ToString());
                return GetServerList(out isErr);
            }
            return allServers;
        }

        #endregion

        #region [ ����: GetServerList���� �Ĵ����� ]

        /// <summary>
        /// GetServerList���� �Ĵ�����
        /// </summary>
        private static bool SqlErrRepair(string errInfo)
        {
            // ȱ��sqldmo.dll�ļ�
            if (errInfo.IndexOf("10020100-E260-11CF-AE68-00AA004A34D5") > 0 || errInfo.IndexOf("10020200-E260-11CF-AE68-00AA004A34D5") > 0)
            {
                // "ȱ��sqldmo.dll" �޸�
                try
                {
                    File.Copy(Application.StartupPath + "\\filebackup\\sqldmo.dll", @"C:\Program Files\Microsoft SQL Server\80\Tools\Binn\sqldmo.dll");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�޸�ʧ��:" + ex.Message.ToString());
                    return false;
                }
            }
            else if (errInfo.IndexOf("0022406-E260-11CF-AE68-00AA004A34D5") > 0)
            {
                MessageBox.Show("SqlServer2000 SP4����δ��װ��δ��װ����");
                return false;
            }
            else
            {
                MessageBox.Show("���ݿ������쳣:" + errInfo);
                return false;
            }
            return true;
        }

        #endregion

        #region [ ����: ��¼����������ȡ���ݿ��б� ]

        /// <summary>
        /// ��¼����������ȡ���ݿ��б�
        /// </summary>
        /// <param name="strServerName">����������</param>
        /// <param name="strUserName">�û���</param>
        /// <param name="strPwd">����</param>
        /// <returns></returns>
        public static ArrayList GetDbList(string strServerName, string strUserName, string strPwd)
        {
            ArrayList alDbs = new ArrayList();

            SQLDMO.Application sqlApp = new SQLDMO.ApplicationClass();
            SQLDMO.SQLServer svr = new SQLDMO.SQLServerClass();
            try
            {
                // ���ӵ����ݿ�
                svr.Connect(strServerName, strUserName, strPwd);

                // �������������е����ݿ����
                foreach (SQLDMO.Database db in svr.Databases)
                {
                    if (db.Name != null)
                    {
                        if (db.Name != "master" && db.Name != "model"
                        && db.Name != "msdb" && db.Name != "pubs"
                        && db.Name != "Northwind" && db.Name != "tempdb")
                        {
                            alDbs.Add(db.Name);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                //throw (new Exception("�������ݿ����" + e.Message));
                MessageBox.Show("���ݿ�����ʧ��");
            }
            finally
            {
                svr.DisConnect();
                sqlApp.Quit();
            }
            return alDbs;
        }

        #endregion

        #region [ ����: ����ָ�����ݿ��ļ� ]

        /// <summary>
        /// ����ָ�����ݿ��ļ�
        /// </summary>
        /// <param name="strDbName">���ݿ�����</param>
        /// <param name="strFileName">�������ݿ��·��</param>
        /// <param name="strServerName">����������</param>
        /// <param name="strUserName">�û���</param>
        /// <param name="strPassword">����</param>
        /// <param name="prosBar">������</param>
        /// <returns></returns>
        public static bool BackUPDB(string strDbName, string strFileName, string strServerName, string strUserName, string strPassword, ProgressBar bar)
        {
            #region [ �жϴ���ʣ��ռ��Ƿ�ɽ��б��� ]

            DBAcess dba = new DBAcess();
            DataSet tmpds = dba.GetDataSet("exec sp_spaceused");
            if (tmpds.Tables.Count > 0 && tmpds.Tables[0] != null)
            {
                // �õ����ݿ��С
                string tmpStr = tmpds.Tables[0].Rows[0]["database_size"].ToString();
                int dbSize = Convert.ToInt32(tmpStr.Substring(0, tmpStr.LastIndexOf(".")));
                // ��ȡ����ʣ��ռ��С
                try
                {
                    DriveInfo d = new DriveInfo(strFileName.Substring(0, 1));
                    int diskSize = Convert.ToInt32(d.AvailableFreeSpace / 1024 / 1024);
                    if (diskSize < dbSize)
                    {
                        MessageBox.Show("�������ݿ�����ռ䲻��С��" + dbSize + "M\r\n����[" + d.Name + "]�洢�ռ��С,�޷�����");
                        return false;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("·������ȷ");
                    return false;
                    //throw;
                }
            }

            #endregion

            pBar = bar;
            string strTmp = "";
            string tmpPath = strFileName.Substring(0, strFileName.LastIndexOf("\\")).ToString();
            int isEmpty = tmpPath.IndexOf(" ");
            SQLDMO.SQLServer svr = null;
            try
            {
                svr = new SQLDMO.SQLServerClass();
                // ���ӵ����ݿ�
                svr.Connect(strServerName, strUserName, strPassword);
                SQLDMO.Backup bak = new SQLDMO.BackupClass();
                bak.Action = 0;
                bak.Initialize = true;

                #region ����������

                if (pBar != null)
                {
                    pBar.Visible = true;
                    SQLDMO.BackupSink_PercentCompleteEventHandler pceh = new SQLDMO.BackupSink_PercentCompleteEventHandler(Step);
                    bak.PercentComplete += pceh;
                }

                #endregion

                #region [ �ļ����������пո�: ����ǰ�Ĵ��� ]

                // �ļ��в�����ʱ�Զ�����
                if (!Directory.Exists(tmpPath))
                {
                    Directory.CreateDirectory(tmpPath);
                }

                // �ļ������� ���пո� �����ļ�·������Ϊ��Ŀ¼����ʱ�ļ���tmpBackup��
                if (isEmpty > 1 && strFileName.Substring(4).LastIndexOf("\\") > 1)
                {
                    strTmp = strFileName.Substring(0, 1).ToString() + ":\\tmp_backup.kj";
                }
                else
                {
                    strTmp = strFileName;
                }

                #endregion

                // ���ݿ�ı��ݵ����Ƽ��ļ����λ��
                bak.Files = strTmp;
                bak.Database = strDbName;

                // ����
                bak.SQLBackup(svr);
            }
            catch (Exception err)
            {
                if (SqlErrRepair(err.Message.ToString()))
                {
                    BackUPDB(strDbName, strFileName, strServerName, strUserName, strPassword, pBar);
                    return true;
                }
                return false;
                //MessageBox.Show("�������ݿ�ʧ��");

            }
            finally
            {
                if (svr != null)
                {
                    svr.DisConnect();
                }

                #region [ �ļ����������пո�: ������ɺ�Ĵ��� ]

                // �ļ������� ���пո� �����ݵ��ļ��ƶ����û�ָ�����ļ��в�����ʱĿ¼ɾ��
                if (isEmpty > 1 && strFileName.Substring(4).LastIndexOf("\\") > 1)
                {
                    // �ļ��������滻
                    if (File.Exists(strFileName.Substring(strFileName.LastIndexOf("\\") + 2)))
                    {
                        File.Delete(strFileName.Substring(strFileName.LastIndexOf("\\") + 2));
                    }
                    File.Move(strTmp, strFileName);
                }

                #endregion
            }
            return true;
        }

        #endregion

        #region [ ����: �ָ�ָ�����ݿ��ļ� ]

        /// <summary>
        /// �ָ�ָ�����ݿ��ļ�
        /// </summary>
        /// <param name="strDbName">���ݿ�����</param>
        /// <param name="strFileName">��ԭ�ļ�·��</param>
        /// <param name="strServerName">����������</param>
        /// <param name="strUserName">�û���</param>
        /// <param name="strPassword">����</param>
        /// <returns></returns>
        public static bool RestoreDB(string strDbName, string strFileName, string strServerName, string strUserName, string strPassword, ProgressBar bar)
        {
            pBar = bar;
            SQLDMO.SQLServer sqlServer = new SQLDMO.SQLServerClass();
            string str = "";
            string tmpPath = strFileName.Substring(0, strFileName.LastIndexOf("\\")).ToString();
            int isEmpty = tmpPath.IndexOf(" ");

            try
            {
                // ���ӵ����ݿ������
                sqlServer.Connect(strServerName, strUserName, strPassword);

                // ��ȡ���еĽ����б�
                SQLDMO.QueryResults qr = sqlServer.EnumProcesses(-1);

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
                    if (strDBName.ToUpper() == strDbName.ToUpper())
                    {
                        sqlServer.KillProcess(lPID);
                    }
                }

                // ʵ������ԭ��������
                SQLDMO.Restore res = new SQLDMO.RestoreClass();

                // ·�����пո�(�������ļ���) ���ݵ�·���ĸ�Ŀ¼����ʱ�ļ���tmpBackup��
                if (isEmpty > 1 && strFileName.Substring(4).LastIndexOf("\\") > 1)
                {
                    str = strFileName.Substring(0, 1).ToString() + ":\\tmp_backup.kj";
                    File.Move(strFileName, str);
                }
                else
                {
                    str = strFileName;
                }

                // ���ݿ��ŵ�·����Ҫ�ָ������ݿ�����
                res.Files = str;
                res.Database = strDbName;

                // ���ָ������ݿ��ļ�������
                res.Action = SQLDMO.SQLDMO_RESTORE_TYPE.SQLDMORestore_Database;
                res.ReplaceDatabase = true;

                #region ����������

                if (pBar != null)
                {
                    pBar.Visible = true;
                    SQLDMO.RestoreSink_PercentCompleteEventHandler pceh = new SQLDMO.RestoreSink_PercentCompleteEventHandler(Step);
                    res.PercentComplete += pceh;
                }

                #endregion

                // ִ�����ݿ�ָ�
                res.SQLRestore(sqlServer);
                return true;
            }
            catch (Exception ex)
            {
                string tmpErr = "��ԭʧ��";
                if (ex.Message.IndexOf("�ļ�������Ч�� Microsoft �Ŵ���ʽ���ݼ�") > 1)
                {
                    tmpErr = "�ļ���ʽ����ȷ";
                }
                MessageBox.Show(tmpErr);
                return false;
            }
            finally
            {
                sqlServer.DisConnect();
                // �ļ����������пո� �����ݵ��ļ��ƻص��û�ָ�����ļ��в�����ʱĿ¼ɾ��
                if (isEmpty > 1 && strFileName.Substring(4).LastIndexOf("\\") > 1)
                {
                    File.Move(str, strFileName);
                }
            }
        }

        #endregion

        #region [ ����: ��չ���ݿ� ]

        public static void ShrinkDataBase()
        {
            DBAcess dba = new DBAcess();
            try
            {
                // ���ݿ����������ַ����еõ�
                string dbName = ConfigurationSettings.AppSettings["ConnectionString"];//dba.ConnectionStringKJ128N;
                dbName = dbName.Substring(dbName.IndexOf("database=") + 9);
                dbName = dbName.Substring(0, dbName.IndexOf(";"));
                dba.GetDataSet("DUMP TRANSACTION " + dbName + " WITH NO_LOG");
                MessageBox.Show("�����־�ɹ�");
            }
            catch (Exception ex)
            {
                MessageBox.Show("�����־ʧ��");
            }
        }

        #endregion

        #region [ �¼�: �������ı仯 ]

        private static void Step(string message, int percent)
        {
            pBar.Value = percent;
            // �����ȴﵽ100ʱ������������
            //if (pBar.Value >= 100)
            //{
            //    pBar.Visible = false;
            //}
        }

        #endregion
    }
}
