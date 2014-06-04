using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace KJ128A.DataSave
{
    /// <summary>
    /// �������ݿ�ͬ��
    /// </summary>
    public class DataBaseSync:IDisposable
    {
        private DataBaseManage dbm;

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

        #region [ ����: ���캯�� ]

        /// <summary>
        /// ���캯��
        /// </summary>
        public DataBaseSync()
        {
            try
            {
                dbm = new DataBaseManage();
                dbm.SyncComplete += new DataBaseManage.SyncCompleteEventHandler(dbm_SyncComplete);
                dbm.GuageEvent += new DataBaseManage.GuageEventHandler(dbm_GuageEvent);
                dbm.ErrorMessage += new DataBaseManage.ErrorMessageEventHandler(dbm_ErrorMessage);
            }
            catch (Exception errInfo)
            {
                // ȱ��sqldmo.dll�ļ�
                if (errInfo.Message.IndexOf("10020100-E260-11CF-AE68-00AA004A34D5") > 0 || errInfo.Message.IndexOf("10020200-E260-11CF-AE68-00AA004A34D5") > 0)
                {
                    try
                    {
                        
                        // "ȱ��sqldmo.dll" �޸�
                        //File.Copy(Application.StartupPath + "\\filebackup\\sqldmo.dll", @"C:\Program Files\Microsoft SQL Server\80\Tools\Binn\sqldmo.dll");
                    }catch(Exception ce)
                    {
                        ErrorMessage(2021504, ce.StackTrace, "[DataBaseSync:DataBaseSync]", "sqldmo�޸�ʧ��");
                        //"sqldmo�޸�ʧ��";
                    }
                }
                else if (errInfo.Message.IndexOf("0022406-E260-11CF-AE68-00AA004A34D5") > 0)
                {

                    //dbm_ErrorMessage(1, "", "[ DBBackUp:DBBackUp ]", "SqlServer2000 SP4����δ��װ��δ��װ����");
                    //"SqlServer2000 SP4����δ��װ��δ��װ����";
                }
            }
        }

        void dbm_SyncComplete()
        {
            if (SyncComplete != null)
            {
                SyncComplete();
            }
        }

        void dbm_GuageEvent(int percent)
        {
            if (GuageEvent != null)
            {
                GuageEvent(percent);
            }
        }

        void dbm_ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            if (ErrorMessage != null)
            {
                ErrorMessage(iErrNO, strStackTrace,strSource,strMessage);
            }
        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        /// <param name="oldDbName">ԭ���ݿ���</param>
        /// <param name="backUpName">�����ݿ���</param>
        /// <param name="backUpPath">�����ݿ��ļ�·��</param>
        /// <param name="oldDbPath">ԭ���ݿ��ļ�·��</param>
        public DataBaseSync(string oldDbName, string backUpName, string backUpPath, string oldDbPath)
        {
            try
            {
                dbm = new DataBaseManage(oldDbName,backUpName,backUpPath,oldDbPath);
            }
            catch (Exception errInfo)
            {
                // ȱ��sqldmo.dll�ļ�
                if (errInfo.Message.IndexOf("10020100-E260-11CF-AE68-00AA004A34D5") > 0 || errInfo.Message.IndexOf("10020200-E260-11CF-AE68-00AA004A34D5") > 0)
                {
                    try
                    {
                        // "ȱ��sqldmo.dll" �޸�
                        File.Copy(Application.StartupPath + "\\filebackup\\sqldmo.dll", @"C:\Program Files\Microsoft SQL Server\80\Tools\Binn\sqldmo.dll");
                    }
                    catch (Exception)
                    {
                        //"sqldmo�޸�ʧ��";
                    }
                }
                else if (errInfo.Message.IndexOf("0022406-E260-11CF-AE68-00AA004A34D5") > 0)
                {
                    //"SqlServer2000 SP4����δ��װ��δ��װ����";
                    //dbm_ErrorMessage(1, "", "[ DBBackUp:DBBackUp ]", "SqlServer2000 SP4����δ��װ��δ��װ����");
                }
            }
        }

        #endregion

        #region [ ����: ֹͣ���ݿ�ͬ�� ]

        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            dbm.Close();
        }

        #endregion

        #region [ ����: �������ݿ� ]

        ///// <summary>
        ///// ��ʼ���������ݿ�
        ///// </summary>
        ///// <returns></returns>
        //public bool LinkSqlServer()
        //{
        //    return dbm.LinkSql();
        //}

        #endregion

        #region [ ����: ������ݿ� ]

        /// <summary>
        /// ������ݿ�
        /// </summary>
        /// <returns></returns>
        public bool InitCheckDB()
        {
            // ��ʼ��������ݿ�
            return dbm.InitCheckDB();
        }

        #endregion

        #region [ ����: ��� KJ128NBackUp���ݿ��Ƿ���� ]

        /// <summary>
        /// ������ݿ�
        /// </summary>
        /// <returns></returns>
        public bool CheckBackUpDBState()
        {
            // ��ʼ��������ݿ�
            return dbm.CheckBackUpDBState();
        }

        #endregion

        #region [ ����: ɾ�������ݿ� ]

        /// <summary>
        /// ɾ�������ݿ�
        /// </summary>
        /// <returns></returns>
        public bool DBDeleteBackUP()
        {
            return dbm.DBDelete();
        }

        #endregion

        #region [ ����: �������ݿ�ͬ�� ]

        /// <summary>
        /// �������ݿ�ͬ��
        /// </summary>
        /// <returns></returns>
        public void DBSync()
        {
            dbm.DBSync();
        }

        #endregion

        #region [ ����: ������ ]

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="iErrNO">������</param>
        public void ErrorMessageFun(int iErrNO)
        {
            string strErrMsg = string.Empty;        // ������Ϣ����
            switch (iErrNO)
            {
                case 2023048:
                    strErrMsg = "SqlServer����ʧ��";
                    break;
                case 2021504:
                    strErrMsg = "���ݿⲻ���ڻ���ʱ��ܾ�";
                    break;
                default: break;
            }
        }

        #endregion

        #region [ ����: �ͷ� ]

        /// <summary>
        /// �ͷŶ���
        /// </summary>
        public void Dispose()
        {
            dbm.Dispose();
        }

        #endregion
    }
}
