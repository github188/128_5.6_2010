using System;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
//using KJ128A.SwitchDatabase;
using System.Threading;
using System.Diagnostics;

namespace KJ128NDataBase
{
    /// <summary>
    /// ���ݷ��ʲ�
    /// </summary>
    public class New_DBAcess
    {
        #region ˽�б���

        public static bool blIsClient = false;
        private string strIsClient;
        private string strHostIP;
        private string strBackIP;

        /// <summary>
        /// �Ƿ�����˫���ȱ�
        /// </summary>
        private static bool isDouble = false;

        /// <summary>
        /// �Ƿ�����˫���ȱ�
        /// </summary>
        public static bool IsDouble
        {
            get { return isDouble; }
        }


        private bool CheckDouble()
        {
            try
            {
                string path = Application.StartupPath + @"\IsKJ128AOrKJ128N.xml";

                if (File.Exists(path))
                {

                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);

                    XmlNode node = doc.ChildNodes[1].SelectSingleNode("IsKJ128A");

                    if (node != null)
                    {
                        if (node.InnerText.ToLower() == "true")
                        {
                            return true;
                        }
                    }
                }
                
                return false;
            }
            catch 
            {
                return false;
            }
        }


        private static string m_ConnectionString_KJ128 = string.Empty;
        private SqlConnection m_SqlConnection;
        //Czlt-2011-01-28
        public static string strConn = string.Empty;

        XmlDocument doc = new XmlDocument();

        //private SwitchDatabase swdb = new SwitchDatabase();

        /// <summary>
        /// �����л�ʱ����־λ
        /// </summary>
       // private int intFlag = 0;

        #endregion

        #region ���캯��
        /// <summary>
        /// ���캯��
        /// </summary>
        public New_DBAcess()
        {
            //swdb.BeginSwitchDatabase += new SwitchDatabase.BeginSwitchDatabaseEventHandler(swdb_BeginSwitchDatabase);
            //swdb.EndSwitchDatabase += new SwitchDatabase.EndSwitchDatabaseEventHandler(swdb_EndSwitchDatabase);

            //�ж��Ƿ�˫���ȱ�
            isDouble = CheckDouble();

            //if (File.Exists(Application.StartupPath + "\\Conn.dw"))
            //{
            //    m_ConnectionString_KJ128 = File.ReadAllText(Application.StartupPath + "\\Conn.dw");
            //    File.Delete(Application.StartupPath + "\\Conn.dw");
            //}
            if (m_ConnectionString_KJ128 == string.Empty)
            {
                this.ChangeDataBase();
            }
            m_SqlConnection = new SqlConnection(m_ConnectionString_KJ128);
            if (CreateConnection() == -1)
            {
                this.ChangeDataBase();
            }
            this.CloseConnection();
        }

        #endregion

        //#region [ �¼�: ��ʼ�л����ݿ� ]

        //void swdb_BeginSwitchDatabase(bool isHost)
        //{
        //    //��ʼ�л����ݿ⣬��Ҫ��ͣ���ݿ�����
        //    intFlag = -1;
        //}

        //#endregion

        //#region [ �¼�: �����л����ݿ� ]

        //void swdb_EndSwitchDatabase(bool isHost)
        //{
        //    if (isHost)
        //    {
        //        //�Ѿ��л��������ݿ⣬��Ҫ�ָ���������
        //        intFlag = 1;
        //    }
        //    else
        //    {
        //        //�Ѿ��л��ɱ����ݿ⣬��Ҫʹ�ñ����ݿ�
        //        intFlag = 2;
        //    }
        //}

        //#endregion

        #region ����

        #region �����ַ�������������
        /// <summary>
        ///  ����һ������
        /// </summary>
        /// <returns>������Ϣ</returns>
        public int CreateConnection()
        {
            try
            {
                
                m_SqlConnection.Open();
                return 0;
            }
           catch
            {
                return -1;
            }
        }
        /// <summary>
        /// �ر�һ������
        /// </summary>
        /// <returns></returns>
        public int CloseConnection()
        {
            try
            {
                m_SqlConnection.Close();
                return 0;
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region ִ��Sql����洢���̣�����һ��DataSet
        /// <summary>
        /// ִ��һ���洢���̣�����һ��DataSet��¼��
        /// </summary>
        /// <param name="procName">�洢���̵�����</param>
        /// <param name="sqlParmeters">�洢���̵Ĳ���</param>
        /// <returns>DataSet��ļ�¼��</returns>
        public DataSet GetDataSet(string procName,SqlParameter[] sqlParmeters)
        {
            //��һ������
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(m_ConnectionString_KJ128))
                {
                    sqlConn.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = BuildSqlCommand(sqlConn, procName, sqlParmeters);
                    sqlDataAdapter.Fill(ds);
                    sqlDataAdapter = null;
                    sqlConn.Close();
                    return ds;
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                ErrorInfo(sqlex.Number);
                return null;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        ///ִ��һ��SQL���,����һ��DataSet��¼��
        /// </summary>
        /// <param name="sqlText">һ��Sql���</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string sqlText)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(m_ConnectionString_KJ128))
                {
                    sqlConn.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = BuildSqlCommand(sqlConn, sqlText);
                    sqlDataAdapter.Fill(ds);
                    sqlDataAdapter = null;
                    sqlConn.Close();
                    return ds;
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                ErrorInfo(sqlex.Number);
                return null;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// ����һ��SqlCommand����
        /// </summary>
        /// <param name="procName">��������</param>
        /// <param name="sqlParmeters">��������</param>
        /// <returns>SqlCommand</returns>
        private SqlCommand BuildSqlCommand(SqlConnection sqlConn,string procName,SqlParameter[] sqlParmeters)
        {
            SqlCommand sqlComm = new SqlCommand(procName, sqlConn);
            sqlComm.CommandType = CommandType.StoredProcedure;
            if (sqlParmeters != null)
            {
                foreach (SqlParameter sqlParameter in sqlParmeters)
                {
                    sqlComm.Parameters.Add(sqlParameter);
                }
            }
            return sqlComm;
        }
        /// <summary>
        /// ����һ��SqlCommand����
        /// </summary>
        /// <param name="sqlConn">����</param>
        /// <param name="sqlText">sql���</param>
        /// <returns>SqlCommand</returns>
        private SqlCommand BuildSqlCommand(SqlConnection sqlConn, string sqlText)
        {
            SqlCommand sqlComm = new SqlCommand(sqlText, sqlConn);
            sqlComm.CommandType = CommandType.Text;
            return sqlComm;
        }
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

     
        #endregion

        #region ִ��SQL����洢���̣�����Ӱ������� int
        /// <summary>
        ///  ִ��SQL����洢���̣�����Ӱ������� int
        /// </summary>
        /// <param name="procName">�洢������</param>
        /// <param name="sqlParameters">�洢���̲���</param>
        /// <returns>Ӱ�������,-1 ִ��ʧ��</returns>
        public int ExecuteSql(string procName,SqlParameter[] sqlParameters)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(m_ConnectionString_KJ128))
                {
                    SqlCommand sqlComm = new SqlCommand(procName, sqlConn);
                    sqlConn.Open();
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter sqlParameter in sqlParameters)
                    {
                        sqlComm.Parameters.Add(sqlParameter);
                    }
                    return (int)sqlComm.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                ErrorInfo(sqlex.Number);

                return -1;
                
            }
            catch
            {
                return -1;
            }
        }

        public int ExecCommand(SqlCommand comm)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(m_ConnectionString_KJ128))
                {
                    comm.Connection = sqlConn;
                    sqlConn.Open();
                    return comm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        /// <summary>
        ///  ִ��SQL����洢���̣�����Ӱ������� int
        /// </summary>
        /// <param name="procName">�洢������</param>
        /// <param name="sqlParameters">�洢���̲���</param>
        /// <returns>Ӱ�������,-1 ִ��ʧ��</returns>
        public int ExecuteSql(string procName, SqlParameter[] sqlParameters,out string strErr)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(m_ConnectionString_KJ128))
                {
                    SqlCommand sqlComm = new SqlCommand(procName, sqlConn);
                    sqlConn.Open();
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter sqlParameter in sqlParameters)
                    {
                        sqlComm.Parameters.Add(sqlParameter);
                    }

                    strErr = "Succeeds";
                    return (int)sqlComm.ExecuteNonQuery();

                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                ErrorInfo(sqlex.Number);
                strErr = sqlex.Message.ToString();
            }
            catch (Exception ex)
            {
                strErr = ex.Message.ToString();
            }
            return 1;
        }
        /// <summary>
        /// ִ��SQL����洢���̣�����Ӱ������� int
        /// </summary>
        /// <param name="procName">�洢������</param>
        /// <param name="sqlParameters">�洢���̲���</param>
        /// <param name="sqlConn">Sql���Ӷ���</param>
        /// <returns>Ӱ�������,-1 ִ��ʧ��</returns>
        public int ExecuteSql(string procName,SqlParameter[] sqlParameters,SqlConnection sqlConn)
        {
            try
            {
                SqlCommand sqlComm = new SqlCommand(procName, sqlConn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                foreach(SqlParameter sqlParameter in sqlParameters)
                {
                    sqlComm.Parameters.Add(sqlParameter);
                }
                return (int)sqlComm.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                ErrorInfo(sqlex.Number);
                return -1;
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        ///  ִ��SQL����洢���̣�����Ӱ������� int
        /// </summary>
        /// <param name="sqlString">Sql���</param>
        /// <param name="sqlConn">sql���Ӷ���</param>
        /// <returns>Ӱ������� -1 ʧ��</returns>
        public int ExecuteSql(string sqlString,SqlConnection sqlConn)
        {
            try
            {
                    SqlCommand sqlComm = new SqlCommand(sqlString, sqlConn);
                    sqlComm.CommandType = CommandType.Text;
                    return (int)sqlComm.ExecuteNonQuery();
             }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                ErrorInfo(sqlex.Number);
                return -1;
            }
            catch
            {
                return -1;
            }

        }


        /// <summary>
        ///  ִ��SQL����洢���̣�����Ӱ������� int
        /// </summary>
        /// <param name="sqlString">Sql���</param>
        /// <returns>Ӱ������� -1 ʧ��</returns>
        public int ExecuteSql(string sqlString)
        {
            try
            {
                this.ConnOpen();

                SqlCommand sqlComm = new SqlCommand(sqlString);
                sqlComm.Connection = this.m_SqlConnection;
                sqlComm.CommandType = CommandType.Text;
                int result = sqlComm.ExecuteNonQuery();

                this.ConnClose();
                return result;
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                ErrorInfo(sqlex.Number);
                string s = sqlex.Message;
                return -1;
            }
            catch(Exception e)
            {
                string s = e.Message;
                return -1;
            }

        }

        #region Connection�� �ر�

        private void ConnOpen()
        {
            if (File.Exists(Application.StartupPath + "\\Conn.dw"))
            {
                m_ConnectionString_KJ128 = File.ReadAllText(Application.StartupPath + "\\Conn.dw");
                File.Delete(Application.StartupPath + "\\Conn.dw");
            }
            m_SqlConnection = new SqlConnection(m_ConnectionString_KJ128);
            //Czlt-2011-01-28 ��ȡ�ַ���
            strConn = m_ConnectionString_KJ128;

            if (this.m_SqlConnection.State != ConnectionState.Open)
            {
                this.m_SqlConnection.Open();
            }
        }

        private void ConnClose()
        {
            if (this.m_SqlConnection.State != ConnectionState.Closed)
            {
                this.m_SqlConnection.Close();
            }
        }

        #endregion

        #region ���ؽ�����е�һ�е�һ�е�ֵ

        public string ExecuteScalarSql(string sqlString)
        {
            try
            {
                this.ConnOpen();

                SqlCommand sqlComm = new SqlCommand(sqlString);
                sqlComm.Connection = this.m_SqlConnection;
                sqlComm.CommandType = CommandType.Text;
                string result = sqlComm.ExecuteScalar().ToString();

                this.ConnClose();
                return result;
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                ErrorInfo(sqlex.Number);
                return "";
            }
            catch
            {
                return "";
            }

        }

        #endregion

        /// <summary>
        ///  ִ��SQL����洢���̣�����Ӱ������� int
        /// </summary>
        /// <param name="sqlString">Sql���</param>
        /// <returns>Ӱ������� -1 ʧ��</returns>
        public int ExistsSql(string sqlString)
        {
            try
            {
                File.AppendAllText("D:\\CzltTestSqlError.txt","ExistsSql() ��ʼʱ�䣺"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n" , Encoding.Unicode);
                this.ConnOpen();

                SqlCommand sqlComm = new SqlCommand(sqlString);
                sqlComm.Connection = this.m_SqlConnection;
                sqlComm.CommandType = CommandType.Text;
                int result = int.Parse(sqlComm.ExecuteScalar().ToString());
                
                this.ConnClose();
                File.AppendAllText("D:\\CzltTestSqlError.txt", "ExistsSql() ����ʱ�䣺" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n", Encoding.Unicode);
                return result;

            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                ErrorInfo(sqlex.Number);
                string s = sqlex.Message;
                File.AppendAllText("D:\\CzltTestSqlError.txt",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"\r\n"+s+"\r\n",Encoding.Unicode);
                return -1;
            }
            catch(Exception e)
            {
                string s = e.Message;
                File.AppendAllText("D:\\CzltTestSqlError.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n" + s + "\r\n", Encoding.Unicode);
                return -1;
            }

        }
        #endregion

        #region MyRegion

        #region ִ��Sql����洢���̣�����һ��DataSet
        /// <summary>
        /// ִ��һ���洢���̣�����һ��DataSet��¼��
        /// </summary>
        /// <param name="procName">�洢���̵�����</param>
        /// <param name="sqlParmeters">�洢���̵Ĳ���</param>
        /// <returns>DataSet��ļ�¼��</returns>
        public SqlDataReader GetDataReader(string sqlString)
        {
            //��һ������
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(m_ConnectionString_KJ128))
                {
                    sqlConn.Open();
                    SqlCommand sqlcomm = new SqlCommand(sqlString,sqlConn);
                    SqlDataReader sqldr = sqlcomm.ExecuteReader();
                    //sqlConn.Close();
                    return sqldr;
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                ErrorInfo(sqlex.Number);
                return null;
            }
            catch
            {
                return null;
            }
        }

        #endregion
        #endregion

        #endregion

        #region ִ��SQL����洢���̣�����DataSet
        /// <summary>
        /// 
        /// </summary>
        /// <param name="procName">�洢������</param>
        /// <param name="sqlParameters">�洢���̲���</param>
        /// <returns>DataSet</returns>
        public DataSet ExecuteSqlDataSet(string procName, SqlParameter[] sqlParameters)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(m_ConnectionString_KJ128))
                {
                    //SqlDataAdapter sqlda = new SqlDataAdapter(procName, sqlConn);

                    SqlCommand cmd = new SqlCommand(procName, sqlConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;//����ʷ��ʶ����ѯȡ����ʱ���qyz 2011-12-20
                    cmd.CommandText = procName;
                    foreach (SqlParameter sqlParameter in sqlParameters)
                    {
                        cmd.Parameters.Add(sqlParameter);
                    }

                    SqlDataAdapter sqlda = new SqlDataAdapter(cmd);

                    //sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //foreach (SqlParameter sqlParameter in sqlParameters)
                    //{
                    //    sqlda.SelectCommand.Parameters.Add(sqlParameter);
                    //}
                    DataSet ds = new DataSet();
                    sqlda.Fill(ds);

                    cmd.Parameters.Clear();
                    return ds;
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                ErrorInfo(sqlex.Number);
                return new DataSet();
            }
            catch(Exception ex)
            {
                return new DataSet();
            }
        }
        public  DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {//string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters
            // SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            //bool mustCloseConnection = false;
            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);

            // Create the DataAdapter & DataSet
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();

                // Fill the DataSet using default values for DataTable names, etc
                da.Fill(ds);

                // Detach the SqlParameters from the command object, so they can be used again
                cmd.Parameters.Clear();
                conn.Close();
                // Return the dataset

                return ds;
            }
        }
        #endregion

        #region ����
        /// <summary>
        /// �õ�һ�������ַ���
        /// </summary>
        public string ConnectionStringKJ128N
        {
            get { return m_ConnectionString_KJ128; }
            set { m_ConnectionString_KJ128 = value; }
        }
         #endregion

        #region ���Բ�ͬ��IP�����Բ�ͬ�����ӣ�һ�����ϣ��Ͱ�������Ӹ�����̬����
        public bool ChangeDataBase()
        {
            bool Flag = false;
            if (CheckIsKJ128A())                //ΪKJ128A
            {
                string strOppentIP = string.Empty;
                string strOppent = Application.StartupPath + "\\HostIPConfig.xml";

                XmlDocument xmldoc = new XmlDocument();
                try
                {
                    xmldoc.Load(strOppent);
                }
                catch (Exception ex)
                {
                    //�쳣����
                }
                bool IsStartHost = Convert.ToBoolean(xmldoc.SelectSingleNode("//IsStartHost").ChildNodes[0].Value.ToString());

                //�ж��Ƿ����������л�����
                if (IsStartHost)
                {
                    //�����������л�����

                    //�õ������Ƿ�Ϊ��/������־
                    bool bIsHost = Convert.ToBoolean(xmldoc.SelectSingleNode("//IsHost").ChildNodes[0].Value.ToString());
                    //�жϱ����Ƿ�Ϊ����
                    if (bIsHost)
                    {
                        //����Ϊ����
                        //�����ݿ���������Ϊ������KJ128N���ݿ�
                         //m_ConnectionString_KJ128 = "server=.;database=KJ128N;uid=sa;pwd=sa;Timeout=10";
                        m_ConnectionString_KJ128 = GetConn();
                        Flag = true;
                    }
                    else     //����
                    {
                        int intFlag = GetDataBaseXMLValue();

                        //if (intFlag.Equals(-1))
                        //{
                        //    MessageBox.Show("��ʼ�л��������ݿ⣬���Ժ�...");
                        //    while (true)
                        //    {
                        //        if (!GetDataBaseXMLValue().Equals(-1))
                        //        {
                        //            break;
                        //        }
                        //        Thread.Sleep(1000);
                        //    }
                        //}

                        if (intFlag.Equals(1))
                        {
                            //��ȡIPAddress
                            string strIPAddress = xmldoc.SelectSingleNode("//IPAddress").ChildNodes[0].Value.ToString();
                            //m_ConnectionString_KJ128 = "server=" + strIPAddress + ";database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                            string con = ConfigurationSettings.AppSettings["ConnectionString"].ToString().Trim();
                            m_ConnectionString_KJ128 = "server=" + strIPAddress + con.Substring(con.IndexOf(';'));
                            try
                            {
                                //���������Ƿ����
                                m_SqlConnection = new SqlConnection(m_ConnectionString_KJ128);
                                m_SqlConnection.Open();
                                m_SqlConnection.Close();
                                Flag = true;

                            }
                            catch
                            {
                                Flag = false;
                            }
                        }
                        else if (intFlag.Equals(2))
                        {
                            //m_ConnectionString_KJ128 = "server = .;database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                            m_ConnectionString_KJ128 = GetConn();
                            try
                            {
                                //���Ա����������Ƿ����
                                m_SqlConnection = new SqlConnection(m_ConnectionString_KJ128);
                                m_SqlConnection.Open();
                                m_SqlConnection.Close();
                                Flag = true;

                            }
                            catch
                            {
                                Flag = false;
                            }
                        }
                        else
                        {
                            //�������Ϊ����
                            //��ȡIPAddress
                            string strIPAddress = xmldoc.SelectSingleNode("//IPAddress").ChildNodes[0].Value.ToString();
                           // m_ConnectionString_KJ128 = "server=" + strIPAddress + ";database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                            string con = ConfigurationSettings.AppSettings["ConnectionString"].ToString().Trim();
                            m_ConnectionString_KJ128 = "server=" + strIPAddress + con.Substring(con.IndexOf(';'));
                            try
                            {
                                //���������Ƿ����
                                m_SqlConnection = new SqlConnection(m_ConnectionString_KJ128);
                                m_SqlConnection.Open();
                                m_SqlConnection.Close();
                                Flag = true;

                            }
                            catch
                            {
                                //���Ӳ����ã������Ϊ����������
                                //m_ConnectionString_KJ128 = "server = .;database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                                m_ConnectionString_KJ128 = GetConn();
                                try
                                {
                                    //���Ա����������Ƿ����
                                    m_SqlConnection = new SqlConnection(m_ConnectionString_KJ128);
                                    m_SqlConnection.Open();
                                    m_SqlConnection.Close();
                                    Flag = true;

                                }
                                catch
                                {
                                    Flag = false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    //û�����������л�����
                    //m_ConnectionString_KJ128 = "server=.;database=KJ128N;uid=sa;pwd=sa;Timeout=10";
                    m_ConnectionString_KJ128 = GetConn();
                    Flag = true;
                }
                //return Flag;
            }
            else          //ΪKJ128N,��AppConfig�ж�ȡ���ݿ������ֶ�
            {
                if (this.GetIsClientXMLValue())     //KJ128A�Ŀͻ��˰汾
                {
                   // m_ConnectionString_KJ128 = "server=" + strHostIP + ";database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                    string con = ConfigurationSettings.AppSettings["ConnectionString"].ToString().Trim();
                    m_ConnectionString_KJ128 = "server=" + strHostIP + con.Substring(con.IndexOf(';'));
                    try
                    {
                        //���������Ƿ����
                        m_SqlConnection = new SqlConnection(m_ConnectionString_KJ128);
                        m_SqlConnection.Open();
                        m_SqlConnection.Close();
                        Flag = true;

                    }
                    catch
                    {
                        //���Ӳ����ã������Ϊ����������
                       // m_ConnectionString_KJ128 = "server = " + strBackIP + ";database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                        m_ConnectionString_KJ128 = "server = " + strBackIP + con.Substring(con.IndexOf(';'));
                        try
                        {
                            //���Ա����������Ƿ����
                            m_SqlConnection = new SqlConnection(m_ConnectionString_KJ128);
                            m_SqlConnection.Open();
                            m_SqlConnection.Close();
                            Flag = true;

                        }
                        catch
                        {
                            Flag = false;
                        }
                    }
                }
                else    //������(ԭ����KJ128N)
                {
                   // m_ConnectionString_KJ128 = ConfigurationSettings.AppSettings["ConnectionString"];
                    m_ConnectionString_KJ128 = GetConn();
                    Flag = true;
                }
            }
            return Flag;
        }
        #endregion

        //#region
        // ~DBAcess()
        //{
        //    if (m_ConnectionString_KJ128 == "server=.;database=KJ128N;uid=sa;pwd=sa;Timeout=1")
        //    {
        //        m_ConnectionString_KJ128 = string.Empty;
        //    }
        //}


        //#endregion


        #region ��Ȿ�汾��KJ128A���򷵻�True,����汾ΪKJ128N���򷵻�False
        public bool CheckIsKJ128A()
        {
            bool Flag = false;
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.StartupPath + "\\IsKJ128AOrKJ128N.xml");
            if (Convert.ToBoolean(doc.ChildNodes[1].ChildNodes[0].InnerText))
            {
                Flag = true;
            }
            return Flag;

        }
        #endregion

        #region [ ����: ��XML ]

        private int GetDataBaseXMLValue()
        {
            try
            {

                if (doc == null)
                {
                    doc = new XmlDocument();
                }

                if (File.Exists("SwitchDatabase.xml"))
                {
                    doc.Load("SwitchDatabase.xml");
                    string value = doc.ChildNodes[1].InnerText;
                    return Convert.ToInt32(value);
                }
                else
                {
                    //MessageBox.Show("�ļ�[Sw.xml]������!");
                    return 0;
                }
            }
            catch
            {
                try
                {
                    Thread.Sleep(500);

                    if (doc == null)
                    {
                        doc = new XmlDocument();
                    }

                    if (File.Exists("SwitchDatabase.xml"))
                    {
                        doc.Load("SwitchDatabase.xml");
                        string value = doc.ChildNodes[1].InnerText;
                        return Convert.ToInt32(value);
                    }
                    else
                    {
                        //MessageBox.Show("�ļ�[Sw.xml]������!");
                        return 0;
                    }

                }
                catch
                {
                    return 0;
                }
            }
        }

        #endregion

        #region [ ����: ���Ӵ��� ]

        private void ErrorInfo(int ErrorNO)
        {
            ErrorDispose erid = new ErrorDispose();
            erid.ErrorDisposeInfo(ErrorNO);
        }

        #endregion

        #region [ ����: ���Ƿ��ǿͻ���(XML) ]

        private bool GetIsClientXMLValue()
        {
            try
            {
                if (doc == null)
                {
                    doc = new XmlDocument();
                }

                if (File.Exists("IsClient.xml"))
                {
                    doc.Load("IsClient.xml");
                    XmlNode xnode = doc.SelectSingleNode("Root");
                    if (xnode != null)
                    {
                        XmlNode xnode1 = xnode.SelectSingleNode("IsClient");
                        XmlNode xnode2 = xnode.SelectSingleNode("HostIP");
                        XmlNode xnode3 = xnode.SelectSingleNode("BackIP");

                        //��ȡ�Ƿ��ǿͻ���
                        if (xnode1 != null)
                        {
                            strIsClient = xnode1.InnerText;
                        }
                        else
                        {
                            strIsClient = "false";
                        }

                        //��ȡ����IP
                        if (xnode2 != null)
                        {
                            strHostIP = xnode2.InnerText;
                        }
                        else
                        {
                            strHostIP = "";
                        }

                        //��ȡ����IP
                        if (xnode3 != null)
                        {
                            strBackIP = xnode3.InnerText;
                        }
                        else
                        {
                            strBackIP = "";
                        }

                        //�����Ƿ����ÿͻ���
                        if (strIsClient.ToLower().Equals("true"))
                        {
                            blIsClient = true;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch{ }
            return false;
        }

        #endregion

        #region[Czlt-2013-03-21 ����Sql����]

        /// <summary>
        /// ��ȡ���ݿ����ӹ���
        /// </summary>
        /// <returns></returns>
        private string GetConn()
        {
            string constr = "";
            string server = GetConfigValue("Server").ToString();
            string database = GetConfigValue("database").ToString();
            string uid = GetConfigValue("uid").ToString();
            string pwd = GetConfigValue("pwd").ToString();
            if (server == "" || database == "" || uid == "" || pwd == "")
            {
                constr = "server = .;database=wifi;uid=sa;pwd=128;Timeout=5";
            }
            else
            {
                constr = "server= " + server + ";database=" + database + ";uid=" + uid + ";pwd=" + pwd + ";Connection Timeout=2;";
            }
            return constr;
        }
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="appKey"></param>
        /// <returns></returns>
        public string GetConfigValue(string appKey)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(System.Windows.Forms.Application.ExecutablePath + @".config");

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
