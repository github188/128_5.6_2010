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
    /// 数据访问层
    /// </summary>
    public class New_DBAcess
    {
        #region 私有变量

        public static bool blIsClient = false;
        private string strIsClient;
        private string strHostIP;
        private string strBackIP;

        /// <summary>
        /// 是否启用双机热备
        /// </summary>
        private static bool isDouble = false;

        /// <summary>
        /// 是否启用双机热备
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
        /// 主备切换时，标志位
        /// </summary>
       // private int intFlag = 0;

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public New_DBAcess()
        {
            //swdb.BeginSwitchDatabase += new SwitchDatabase.BeginSwitchDatabaseEventHandler(swdb_BeginSwitchDatabase);
            //swdb.EndSwitchDatabase += new SwitchDatabase.EndSwitchDatabaseEventHandler(swdb_EndSwitchDatabase);

            //判断是否双机热备
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

        //#region [ 事件: 开始切换数据库 ]

        //void swdb_BeginSwitchDatabase(bool isHost)
        //{
        //    //开始切换数据库，需要暂停数据库连接
        //    intFlag = -1;
        //}

        //#endregion

        //#region [ 事件: 结束切换数据库 ]

        //void swdb_EndSwitchDatabase(bool isHost)
        //{
        //    if (isHost)
        //    {
        //        //已经切换成主数据库，需要恢复正常连接
        //        intFlag = 1;
        //    }
        //    else
        //    {
        //        //已经切换成备数据库，需要使用备数据库
        //        intFlag = 2;
        //    }
        //}

        //#endregion

        #region 方法

        #region 连接字符串及测试连接
        /// <summary>
        ///  测试一个链接
        /// </summary>
        /// <returns>错误信息</returns>
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
        /// 关闭一个连接
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

        #region 执行Sql语句或存储过程，返回一个DataSet
        /// <summary>
        /// 执行一个存储过程，返回一个DataSet记录集
        /// </summary>
        /// <param name="procName">存储过程的名字</param>
        /// <param name="sqlParmeters">存储过程的参数</param>
        /// <returns>DataSet表的记录集</returns>
        public DataSet GetDataSet(string procName,SqlParameter[] sqlParmeters)
        {
            //打开一个连接
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
        ///执行一条SQL语句,返回一个DataSet记录集
        /// </summary>
        /// <param name="sqlText">一条Sql语句</param>
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
        /// 构造一个SqlCommand对象
        /// </summary>
        /// <param name="procName">过程名称</param>
        /// <param name="sqlParmeters">参数内容</param>
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
        /// 构造一个SqlCommand对象
        /// </summary>
        /// <param name="sqlConn">连接</param>
        /// <param name="sqlText">sql语句</param>
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

        #region 执行SQL语句或存储过程，返回影响的行数 int
        /// <summary>
        ///  执行SQL语句或存储过程，返回影响的行数 int
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="sqlParameters">存储过程参数</param>
        /// <returns>影响的行数,-1 执行失败</returns>
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
        ///  执行SQL语句或存储过程，返回影响的行数 int
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="sqlParameters">存储过程参数</param>
        /// <returns>影响的行数,-1 执行失败</returns>
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
        /// 执行SQL语句或存储过程，返回影响的行数 int
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="sqlParameters">存储过程参数</param>
        /// <param name="sqlConn">Sql连接对象</param>
        /// <returns>影响的行数,-1 执行失败</returns>
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
        ///  执行SQL语句或存储过程，返回影响的行数 int
        /// </summary>
        /// <param name="sqlString">Sql语句</param>
        /// <param name="sqlConn">sql连接对象</param>
        /// <returns>影响的行数 -1 失败</returns>
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
        ///  执行SQL语句或存储过程，返回影响的行数 int
        /// </summary>
        /// <param name="sqlString">Sql语句</param>
        /// <returns>影响的行数 -1 失败</returns>
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

        #region Connection打开 关闭

        private void ConnOpen()
        {
            if (File.Exists(Application.StartupPath + "\\Conn.dw"))
            {
                m_ConnectionString_KJ128 = File.ReadAllText(Application.StartupPath + "\\Conn.dw");
                File.Delete(Application.StartupPath + "\\Conn.dw");
            }
            m_SqlConnection = new SqlConnection(m_ConnectionString_KJ128);
            //Czlt-2011-01-28 获取字符串
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

        #region 返回结果集中第一行第一列的值

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
        ///  执行SQL语句或存储过程，返回影响的行数 int
        /// </summary>
        /// <param name="sqlString">Sql语句</param>
        /// <returns>影响的行数 -1 失败</returns>
        public int ExistsSql(string sqlString)
        {
            try
            {
                File.AppendAllText("D:\\CzltTestSqlError.txt","ExistsSql() 开始时间："+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n" , Encoding.Unicode);
                this.ConnOpen();

                SqlCommand sqlComm = new SqlCommand(sqlString);
                sqlComm.Connection = this.m_SqlConnection;
                sqlComm.CommandType = CommandType.Text;
                int result = int.Parse(sqlComm.ExecuteScalar().ToString());
                
                this.ConnClose();
                File.AppendAllText("D:\\CzltTestSqlError.txt", "ExistsSql() 结束时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n", Encoding.Unicode);
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

        #region 执行Sql语句或存储过程，返回一个DataSet
        /// <summary>
        /// 执行一个存储过程，返回一个DataSet记录集
        /// </summary>
        /// <param name="procName">存储过程的名字</param>
        /// <param name="sqlParmeters">存储过程的参数</param>
        /// <returns>DataSet表的记录集</returns>
        public SqlDataReader GetDataReader(string sqlString)
        {
            //打开一个连接
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

        #region 执行SQL语句或存储过程，返回DataSet
        /// <summary>
        /// 
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="sqlParameters">存储过程参数</param>
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
                    cmd.CommandTimeout = 0;//对历史标识卡查询取消超时概念。qyz 2011-12-20
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

        #region 属性
        /// <summary>
        /// 得到一个连接字符串
        /// </summary>
        public string ConnectionStringKJ128N
        {
            get { return m_ConnectionString_KJ128; }
            set { m_ConnectionString_KJ128 = value; }
        }
         #endregion

        #region 测试不同的IP，测试不同的连接，一旦连上，就把这个连接赋给静态变量
        public bool ChangeDataBase()
        {
            bool Flag = false;
            if (CheckIsKJ128A())                //为KJ128A
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
                    //异常处理
                }
                bool IsStartHost = Convert.ToBoolean(xmldoc.SelectSingleNode("//IsStartHost").ChildNodes[0].Value.ToString());

                //判断是否启用主备切换功能
                if (IsStartHost)
                {
                    //启用了主备切换功能

                    //得到本机是否为主/备机标志
                    bool bIsHost = Convert.ToBoolean(xmldoc.SelectSingleNode("//IsHost").ChildNodes[0].Value.ToString());
                    //判断本机是否为主机
                    if (bIsHost)
                    {
                        //本机为主机
                        //把数据库连接设置为本机的KJ128N数据库
                         //m_ConnectionString_KJ128 = "server=.;database=KJ128N;uid=sa;pwd=sa;Timeout=10";
                        m_ConnectionString_KJ128 = GetConn();
                        Flag = true;
                    }
                    else     //备机
                    {
                        int intFlag = GetDataBaseXMLValue();

                        //if (intFlag.Equals(-1))
                        //{
                        //    MessageBox.Show("开始切换主备数据库，请稍后...");
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
                            //读取IPAddress
                            string strIPAddress = xmldoc.SelectSingleNode("//IPAddress").ChildNodes[0].Value.ToString();
                            //m_ConnectionString_KJ128 = "server=" + strIPAddress + ";database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                            string con = ConfigurationSettings.AppSettings["ConnectionString"].ToString().Trim();
                            m_ConnectionString_KJ128 = "server=" + strIPAddress + con.Substring(con.IndexOf(';'));
                            try
                            {
                                //测试连接是否可用
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
                                //测试本机的连接是否可用
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
                            //如果本机为备机
                            //读取IPAddress
                            string strIPAddress = xmldoc.SelectSingleNode("//IPAddress").ChildNodes[0].Value.ToString();
                           // m_ConnectionString_KJ128 = "server=" + strIPAddress + ";database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                            string con = ConfigurationSettings.AppSettings["ConnectionString"].ToString().Trim();
                            m_ConnectionString_KJ128 = "server=" + strIPAddress + con.Substring(con.IndexOf(';'));
                            try
                            {
                                //测试连接是否可用
                                m_SqlConnection = new SqlConnection(m_ConnectionString_KJ128);
                                m_SqlConnection.Open();
                                m_SqlConnection.Close();
                                Flag = true;

                            }
                            catch
                            {
                                //连接不可用，则更换为本机的连接
                                //m_ConnectionString_KJ128 = "server = .;database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                                m_ConnectionString_KJ128 = GetConn();
                                try
                                {
                                    //测试本机的连接是否可用
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
                    //没有启用主备切换功能
                    //m_ConnectionString_KJ128 = "server=.;database=KJ128N;uid=sa;pwd=sa;Timeout=10";
                    m_ConnectionString_KJ128 = GetConn();
                    Flag = true;
                }
                //return Flag;
            }
            else          //为KJ128N,从AppConfig中读取数据库连接字段
            {
                if (this.GetIsClientXMLValue())     //KJ128A的客户端版本
                {
                   // m_ConnectionString_KJ128 = "server=" + strHostIP + ";database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                    string con = ConfigurationSettings.AppSettings["ConnectionString"].ToString().Trim();
                    m_ConnectionString_KJ128 = "server=" + strHostIP + con.Substring(con.IndexOf(';'));
                    try
                    {
                        //测试连接是否可用
                        m_SqlConnection = new SqlConnection(m_ConnectionString_KJ128);
                        m_SqlConnection.Open();
                        m_SqlConnection.Close();
                        Flag = true;

                    }
                    catch
                    {
                        //连接不可用，则更换为本机的连接
                       // m_ConnectionString_KJ128 = "server = " + strBackIP + ";database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                        m_ConnectionString_KJ128 = "server = " + strBackIP + con.Substring(con.IndexOf(';'));
                        try
                        {
                            //测试本机的连接是否可用
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
                else    //单机版(原来的KJ128N)
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


        #region 检测本版本是KJ128A，则返回True,如果版本为KJ128N，则返回False
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

        #region [ 方法: 读XML ]

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
                    //MessageBox.Show("文件[Sw.xml]不存在!");
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
                        //MessageBox.Show("文件[Sw.xml]不存在!");
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

        #region [ 方法: 连接错误 ]

        private void ErrorInfo(int ErrorNO)
        {
            ErrorDispose erid = new ErrorDispose();
            erid.ErrorDisposeInfo(ErrorNO);
        }

        #endregion

        #region [ 方法: 读是否是客户端(XML) ]

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

                        //获取是否是客户端
                        if (xnode1 != null)
                        {
                            strIsClient = xnode1.InnerText;
                        }
                        else
                        {
                            strIsClient = "false";
                        }

                        //获取主机IP
                        if (xnode2 != null)
                        {
                            strHostIP = xnode2.InnerText;
                        }
                        else
                        {
                            strHostIP = "";
                        }

                        //获取备机IP
                        if (xnode3 != null)
                        {
                            strBackIP = xnode3.InnerText;
                        }
                        else
                        {
                            strBackIP = "";
                        }

                        //返回是否启用客户端
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

        #region[Czlt-2013-03-21 配置Sql连接]

        /// <summary>
        /// 获取数据库连接工具
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
        /// 修改
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
