using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using ADOX; //�������ռ��������ACCESS����(����)--������� ==> ���� ==> ������� ==> �����ҵ�.dll
using JRO; //�������ռ����ѹ��ACCESS����(����)

namespace KJ128A.DataSave
{
    /// <summary>
    /// Access���ݻ���������
    /// </summary>
    public class AccessBase
    {

        #region [ ���� ]

        /// <summary>
        /// ������ౣ�����ٸ����ݿ�
        /// </summary>
        private int iAccessMaxSum = 7;

        /// <summary>
        /// 
        /// </summary>
        public  OleDbConnection accessbaseconn = null;

        /// <summary>
        /// 
        /// </summary>
        public  OleDbConnection connAcc = null;
        /// <summary>
        /// ����Access��Ŀ¼
        /// </summary>
        private string strAccessPath = System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB";   

        #endregion

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
         * ���ݿ����
         */

        #region [ ����: ����Command���� ]

        /// <summary>
        /// ����Command����
        /// </summary>
        /// <param name="strCommand">Command�ַ���</param>
        /// <param name="dbParams">Command����</param>
        /// <returns>����Comand����</returns>
        public OleDbCommand BuildOleDbCommand(string strCommand, OleDbParameter[] dbParams)
        {
            OleDbCommand command = new OleDbCommand();
            command.CommandText = strCommand;
            foreach (OleDbParameter oleParameter in dbParams)
            {
                command.Parameters.Add(oleParameter);
            }

            return command;
        }

        #endregion

        #region [ ����:������������ʱ�����ݿ������ ]

        /// <summary>
        /// �������ݿ�����
        /// </summary>
        /// <param name="strMDBName">���ݿ����ƣ����硰2008-1-23.mdb��</param>
        /// <returns></returns>
        public OleDbConnection SetConnect(string strMDBName)
        {
            //string strDBPath = System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + strMDBName;  //���ݿ�·��
            //OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + strDBPath + ";Jet OLEDB:Database Password=shkj;");
            //return con;
            //accessbaseconn = DAO.GetConn(strMDBName);
            //return accessbaseconn;
            return DAO.GetConn(strMDBName);
        }

        #endregion

        #region [����������һ�����ñ�]
        /// <summary>
        /// �������ñ�
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public bool CreateConfigTable(string filename, string strTableName)
        {
            string strCommand = "CREATE TABLE " + strTableName +
                " (id int IDENTITY(1,1) ,CreateInfo varchar(128) PRIMARY KEY CLUSTERED ,CmdLen int,CmdInfo Image,IsSync bit,IsSyncing int)";
            return CreteTableBase(filename, strCommand);
        }
        #endregion

        #region [ ����: ����һ��ԭʼ�� ]

        /// <summary>
        /// ����ԭʼ��
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="strTableName">Ҫ�����ı�</param>
        /// <returns>���ز����Ƿ�ɹ�</returns>
        public bool CreateOrgTable(string filename, string strTableName)
        {
            string strCommand = "CREATE TABLE " + strTableName +
                " (id int IDENTITY(1,1) ,CreateInfo varchar(128) PRIMARY KEY CLUSTERED ,CmdLen int,CmdInfo Image,IsSync bit,IsSyncing int)";
            return CreteTableBase(filename, strCommand);
        }

        #endregion

        #region [ ����: ����һ�ŷ��ͱ� ]

        /// <summary>
        /// �������ͱ�
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="strTableName">Ҫ�����ı�</param>
        /// <returns>���ز����Ƿ�ɹ�</returns>
        public bool CreateNewTable(string filename, string strTableName)
        {
            string strCommand = "CREATE TABLE " + strTableName +
                " (id int IDENTITY(1,1) ,CreateInfo varchar(128)  PRIMARY KEY CLUSTERED ,CmdLen int,CmdInfo Image,IsSend bit,IsSending bit,SaveState int)";
            return CreteTableBase(filename, strCommand);
        }

        #endregion

        #region [ ����: �����ݿ��в���� ]

        /// <summary>
        /// �����ݿ��в����
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="strCommand">���������ַ���</param>
        /// <returns>�����ɹ�����True</returns>
        private bool CreteTableBase(string filename, string strCommand)
        {
            OleDbConnection conn = DAO.GetConn(filename);
            OleDbCommand cmd = new OleDbCommand(strCommand, conn);
            bool falg = true;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6020006, ex.StackTrace, "[AccessImport:CreteTableBase]", ex.Message);
                }
                falg = false;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
                if (conn != null)
                {
                    conn.Dispose();
                    conn = null;
                }
            }
            return falg;
        }

        #endregion


        #region [������ѹ���޸����ݿ�]
        public string[] Compact()
        {
            string[] strMDBName = FindAllMDBOfFile();
            return strMDBName;
            //for (int i = 0; i < strMDBName.Length; i++)
            //{
            //    Compact(strMDBName[i]);
            //}
        }
        public string[] Compact1()
        {
            string[] strMDBName = FindAllMDBOfFile(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\config");
            return strMDBName;
        }
        ///ѹ���޸�ACCESS���ݿ�,mdbPathΪ���ݿ����·��    
        public void Compact(string mdbPath)       
        {
            try
            {
                if (File.Exists(mdbPath)) //������ݿ��Ƿ��Ѵ���           
                {
                    string temp = DateTime.Now.Year.ToString();
                    string temp2 = null;
                    temp += DateTime.Now.Month.ToString();
                    temp += DateTime.Now.Day.ToString();
                    temp += DateTime.Now.Hour.ToString();
                    temp += DateTime.Now.Minute.ToString();
                    temp += DateTime.Now.Second.ToString() + ".bak";
                    temp = mdbPath.Substring(0, mdbPath.LastIndexOf("\\") + 1) + temp;        
                    //������ʱ���ݿ�������ַ���           
                    temp2 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + temp + ";Jet OLEDB:Database Password=shkj;";        
                    //����Ŀ�����ݿ�������ַ���            
                    string mdbPath2 = null;
                    mdbPath2 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mdbPath + ";Jet OLEDB:Database Password=shkj;";        
                    //����һ��JetEngineClass�����ʵ��           
                    JRO.JetEngineClass jt = new JRO.JetEngineClass();
                    //ʹ��JetEngineClass�����CompactDatabase����ѹ���޸����ݿ�           
                    jt.CompactDatabase(mdbPath2, temp2);
                    jt = null;
                    //������ʱ���ݿ⵽Ŀ�����ݿ�(����)           
                    File.Copy(temp, mdbPath, true);
                    //���ɾ����ʱ���ݿ�           
                    File.Delete(temp);
                }
            }
            catch(Exception ex) 
            {
                if (ex.Message.IndexOf("�������������û���ͼͬʱ�ı�ͬһ����") != -1)
                {
                    try
                    {
                        string strfilenameTemp = mdbPath.Replace(".mdb", ".ldb");
                        if (File.Exists(strfilenameTemp))
                        {
                            File.Delete(strfilenameTemp);
                        }
                        File.Delete(mdbPath);
                    }
                    catch { }
                }
                else if (ex.Message.IndexOf("����ʶ������ݿ��ʽ") != -1)
                {
                    try
                    {
                        string strfilenameTemp = mdbPath.Replace(".mdb", ".ldb");
                        if (File.Exists(strfilenameTemp))
                        {
                            File.Delete(strfilenameTemp);
                        }
                        File.Delete(mdbPath);
                    }
                    catch { }
                    //catch (Exception ee)
                    //{
                    //    string s = ee.Message;
                    //}
                }
                Thread.Sleep(100);
            }
        }

        #endregion 


        /*
         * �ļ�����
         */ 

        #region [ ����: ȡ���ļ���ֻ������ ]

        /// <summary>
        /// ȡ���ļ���ֻ������
        /// </summary>
        /// <param name="strPath">�ļ�·��</param>
        public void CancelFileReadOnly(string strPath)
        {
            if (File.Exists(strPath))
            {
                try
                {
                    FileInfo fi = new FileInfo(strPath);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                    {
                        fi.Attributes = FileAttributes.Normal;
                    }
                    fi = null;
                }
                catch (Exception ex)
                {
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020005, ex.StackTrace, "[AccessImport:CancelFileReadOnly]", ex.Message);
                    }
                    return;
                }
            }
            
        }

        #endregion

        #region [ ����: ���ļ����µ����ݿ��������7��ʱ��ɾ�����ݿ� ]

        /// <summary>
        /// ɾ�����ݿ�
        /// </summary>
        /// <param name="strPath">�ļ�������</param>
        public void DeleteMDBFile(string strPath)
        {
            string[] strFileName = FindAllMDBOfFile(strPath);
            //�ж��Ƿ�Ҫɾ�����ݿ�
            if (strFileName != null && strFileName.Length > iAccessMaxSum)
            {
                //����Ҫɾ�������ݿ����
                int num = strFileName.Length - (iAccessMaxSum);
                //ɾ�����ݿ�
                for (int i = 0; i < num; i++)
                {
                    try
                    {
                        File.Delete(strFileName[i]);
                    }
                    catch { }
                }
            }
        }

        #endregion

        #region [ ����: ����֪���ļ������������ݿ�����Ƽ��� ]

        /// <summary>
        /// ����֪���ļ������������ݿ�����Ƽ���
        /// </summary>
        /// <returns>�������ݿ�����</returns>
        public string[] FindAllMDBOfFile()
        {
            string destFileName;
            destFileName = strAccessPath;
            //switch (databaseType)
            //{
            //    case 1://new
            //        destFileName = strAccessPath + @"\new";     //Ŀ���ļ�
            //        break;
            //    case 2://orgback
            //        destFileName = strAccessPath + @"\orgback";     //Ŀ���ļ�
            //        break;
            //    case 3://newback
            //        destFileName = strAccessPath + @"\newback";     //Ŀ���ļ�
            //        break;
            //    default://org
            //        destFileName = strAccessPath + @"\org";     //Ŀ���ļ�
            //        break;
            //}
            return FindAllMDBOfFile(destFileName);
        }

        /// <summary>
        /// ����֪���ļ������������ݿ�����Ƽ���
        /// </summary>
        /// <param name="strFileName">�ļ�����</param>
        /// <returns>�������ݿ�����</returns>
        public string[] FindAllMDBOfFile(string strFileName)
        {
            ArrayList alst = new System.Collections.ArrayList();//����ArrayList����
            try
            {
                string[] files = Directory.GetFiles(strFileName);//�õ��ļ�
                foreach (string file in files)//ѭ���ļ�
                {
                    string exname = file.Substring(file.LastIndexOf(".") + 1);//�õ���׺��
                    if (".mdb".IndexOf(file.Substring(file.LastIndexOf(".") + 1)) > -1)//�����׺��Ϊ.mdb�ļ�
                    {
                        FileInfo fi = new FileInfo(file);//����FileInfo����
                        alst.Add(fi.FullName);//��.mdb�ļ�ȫ�����˵�FileInfo����
                        fi = null;
                    }
                    alst.Sort();
                }
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6020004, ex.StackTrace, "[AccessImport:FindAllMDBOfFile]", ex.Message);
                }
                return (string[])alst.ToArray(typeof(string));
            }
            return (string[])alst.ToArray(typeof(string));//��ArrayListת��Ϊstring[]
        }

        #endregion

        #region [ ����: �ж��Ƿ������µ����ݿ�__����δ���� ]

        /// <summary>
        /// �ж��Ƿ������µ����ݿ�
        /// </summary>
        /// <param name="dt">ʱ��</param>
        /// <returns>�����ɹ�����True</returns>
        public bool CreateMDBFile(DateTime dt)
        {
            for (int i = 0; i < 4; i++)
            {
                string destFileName;
                switch (i)
                {
                    case 1://new
                        destFileName = strAccessPath + @"\new\new" + dt.ToString("yyyy-MM-dd") + ".mdb";     //Ŀ���ļ�
                        break;
                    case 2://orgback
                        destFileName = strAccessPath + @"\orgback\orgback" + dt.ToString("yyyy-MM-dd") + ".mdb";     //Ŀ���ļ�
                        break;
                    case 3://newback
                        destFileName = strAccessPath + @"\newback\newback" + dt.ToString("yyyy-MM-dd") + ".mdb";     //Ŀ���ļ�
                        break;
                    default://org
                        destFileName = strAccessPath + @"\org\org" + dt.ToString("yyyy-MM-dd") + ".mdb";     //Ŀ���ļ�
                        break;
                }
                
            
                //Ŀ���ļ����ļ����Ƿ����
                if (!Directory.Exists(strAccessPath))      
                {
                    Directory.CreateDirectory(strAccessPath);
                }

                //Ŀ���ļ��Ƿ����
                if (!File.Exists(destFileName))
                {
                    //�����µ����ݿ�
                    CopyMDB(destFileName);
                }
            }
            
            return true;
        }

        #endregion

        #region [ �������ݿ�ķ�ʽ�������ݿ� ]

        /// <summary>
        /// �������ݿ�ķ�ʽ�������ݿ�
        /// </summary>
        /// <param name="destFileName">���ɵ����ݿ�����2008-02-12.mdb��</param>
        /// <returns></returns>
        public bool CopyMDB(string destFileName)
        {
            string sourceFileName = System.Windows.Forms.Application.StartupPath.ToString() + @"\Interop.MSAdodcLib.Modle.dll";    //Ҫ���Ƶ��ļ�
            //Ŀ���ļ�Interop.MSAdodcLib.Modle.dll�Ƿ����
            if (File.Exists(sourceFileName))
            {
                try
                {
                    //Ŀ���ļ����ڣ������ļ�
                    File.Copy(sourceFileName, destFileName, true);

                    //ȡ��ֻ��
                    CancelFileReadOnly(destFileName);

                    //�ļ�����ֻ������ʮ��������ݿ�
                    DeleteMDBFile(strAccessPath);
                }
                catch (Exception ex)
                {
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020002, ex.StackTrace, "[AccessImport:CreateMDBFile]", ex.Message);
                    }
                    return false;
                }
            }
            else
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6020003, "��ʾ", "[AccessImport:CreateMDBFile]", "");
                    return false;
                }
            }
            return true;
        }

         #endregion

        #region [ ����: �����ʾʱ����ַ������������ݿ����ͱ��� ]
        /// <summary>
        /// �����ʾʱ����ַ������������ݿ����ͱ���
        /// </summary>
        /// <param name="flag">True����ʾOrgData��;False����ʾNewData��</param>
        /// <param name="strTime">"20080201001711000"</param>
        /// <returns>strName[0]Ϊ���ݿ����ƣ�strName[1]Ϊ����</returns>
        public string[] GetInforFromString(string strTime)
        {
            string[] strName = new string[2];
            string newTime = strTime.Substring(0, 4) + "." + strTime.Substring(4, 2) + "." + strTime.Substring(6, 2) + " " + strTime.Substring(8, 2) + ":" + strTime.Substring(10, 2) + ":" + strTime.Substring(12, 2);

            DateTime dt;
            try
            {
                dt = Convert.ToDateTime(newTime);
            }
            catch
            {
                dt = new DateTime(1999, 1, 1, 0, 0, 0);
            }
            strName[0] = "Config" + dt.ToString("yyyy-MM-dd") + ".mdb";   //������ݿ�����

            strName[1] = "ConfigData" + dt.ToString("HH");

            return strName;
        }


        /// <summary>
        /// �����ʾʱ����ַ������������ݿ����ͱ���
        /// </summary>
        /// <param name="flag">True����ʾOrgData��;False����ʾNewData��</param>
        /// <param name="strTime">"20080201001711000"</param>
        /// <returns>strName[0]Ϊ���ݿ����ƣ�strName[1]Ϊ����</returns>
        public string[] GetInforFromString(bool flag, string strTime)
        {
            string[] strName = new string[2];
            string newTime = strTime.Substring(0, 4) + "." + strTime.Substring(4, 2) + "." + strTime.Substring(6, 2) + " " + strTime.Substring(8, 2) + ":" + strTime.Substring(10, 2) + ":" + strTime.Substring(12, 2);
            
            DateTime dt;
            try
            {
                dt = Convert.ToDateTime(newTime);
            }
            catch
            {
                dt = new DateTime(1999, 1, 1, 0, 0, 0);
            }
            strName[0] = dt.ToString("yyyy-MM-dd") + ".mdb";   //������ݿ�����
            if (flag)
            {
                strName[1] = "OrgData" + dt.ToString("HH");
            }
            else
            {
                strName[1] = "NewData" + dt.ToString("HH");
            }
            return strName;
        }

        #endregion

        #region  [ ����: ��֪һ�����ݿ����ƣ�����һ���������� ]

        /// <summary>
        /// ��֪һ�����ݿ����ƣ�����һ����������
        /// </summary>
        /// <param name="strDBPath">���ݿ����ƣ����磺"F:\\AccessMDB\\AccessMDB\\bin\\Debug\\AccessDB\\2008-1-25.mdb"</param>
        /// <returns>�������б���</returns>
        public string[] GetTableNameBase( string strDBPath)
        {
            string[] strTableName;                      //�����������
            DataTable dtName = GetTableName(strDBPath);  //�����ݿ��в��ұ��� 
            strTableName = fillData(dtName);              // ���鵽��������䵽��������
            dtName = null;
            return strTableName;                        //���ر�������
        }

        #endregion

        #region [ ����: �����ݿ��в��ұ��� ]

        /// <summary>
        /// �����ݿ��в��ұ���
        /// </summary>
        /// <param name="strPath">���ݿ����ƣ����磺"F:\\AccessMDB\\AccessMDB\\bin\\Debug\\AccessDB\\2008-1-25.mdb"</param>
        /// <returns>�������б������</returns>
        private DataTable GetTableName(string strPath)
        {
            //OleDbConnection connAcc = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + strPath + ";Jet OLEDB:Database Password=shkj;");
            DataTable dtName = new DataTable();

            try
            {
                if (connAcc==null || connAcc.ConnectionString=="")
                {
                    connAcc = DAO.GetConnByPath(strPath);
                }
                if (connAcc.State == ConnectionState.Closed)
                {
                    connAcc.Open();
                }
                dtName = connAcc.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("�������������û���ͼͬʱ�ı�ͬһ����") != -1)
                {
                    if (connAcc.State != ConnectionState.Closed)
                    {
                        connAcc.Close();
                        connAcc.Dispose();
                        connAcc = null;
                    }
                    try
                    {
                        string strfilenameTemp = strPath.Replace(".mdb", ".ldb");
                        if (File.Exists(strPath))
                        {
                            File.Delete(strPath);
                        }
                        File.Delete(strPath);
                    }
                    catch { }
                }
                else if (ex.Message.IndexOf("����ʶ������ݿ��ʽ") != -1)
                {
                    //if (ErrorMessage != null)
                    //{
                    //    ErrorMessage(6020001, ex.StackTrace, "[AccessImport:GetTableName]", ex.Message);
                    //}
                    if (connAcc.State != ConnectionState.Closed)
                    {
                        connAcc.Close();
                        connAcc.Dispose();
                        connAcc = null;
                    }
                    try
                    {
                        string strfilenameTemp = strPath.Replace(".mdb", ".ldb");
                        if (File.Exists(strPath))
                        {
                            File.Delete(strPath);
                        }
                        File.Delete(strPath);
                    }
                    catch { }
                }
                else
                {
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020001, ex.StackTrace, "[AccessImport:GetTableName]", ex.Message);
                    }
                }
            }
            finally
            {
                if (connAcc.State != ConnectionState.Closed)
                {
                    connAcc.Close();
                }
                if (connAcc != null)
                {
                    connAcc.Dispose();
                    connAcc = null;
                }
            }
            return dtName;
        }

        #endregion

        #region [ ����: ���鵽��������䵽�������� ]

        /// <summary>
        /// ���鵽��������䵽��������
        /// </summary>
        /// <param name="dtName">���ݿ����ƣ����磺"F:\\AccessMDB\\AccessMDB\\bin\\Debug\\AccessDB\\2008-1-25.mdb"</param>
        /// <returns>�������б���</returns>
        private string[] fillData(DataTable dtName)
        {
            string[] strTableNames;

            int drCount = dtName.Rows.Count;
            strTableNames = new string[drCount];
            int index = 0;

            foreach (DataRow dr in dtName.Rows)
            {
                strTableNames.SetValue(dr[2].ToString(), index);
                index++;
            }

            return strTableNames;
        }

        #endregion
    }
}
