using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace KJ128A.DataSave
{
    /// <summary>
    /// 数据库存储
    /// </summary>
    public class SQLSave
    {
        #region [ 属性 ]

        /// <summary>
        /// 主数据库连接字符串
        /// </summary>
        //private readonly string m_ConnectionString_KJ128 = "server=.;database=kj128N;uid=sa;pwd=sa;Connection Timeout=5";
        private string m_ConnectionString_KJ128 = "server=.;database=wifi;uid=sa;pwd=128;Connection Timeout=15";

        /// <summary>
        /// 备数据库连接字符串
        /// </summary>
        //private string m_ConnectionString_KJ128back = "server=.;database=kj128NbackUp;uid=sa;pwd=sa;Connection Timeout=5";
        private string m_ConnectionString_KJ128back = "server=.;database=wifi;uid=sa;pwd=128;Connection Timeout=15";


        /// <summary>
        /// 主数据库连接
        /// </summary>
        private SqlConnection sqlConn;// = new SqlConnection(m_ConnectionString_KJ128);  

        /// <summary>
        /// 备数据库连接
        /// </summary>
        private SqlConnection sqlConnBack;// = new SqlConnection(m_ConnectionString_KJ128back);  


        /// <summary>
        /// 主数据库连接的状态
        /// </summary>
        public static bool bConStateFlag = true;

        /// <summary>
        /// 备数据库连接的状态
        /// </summary>
        public static bool bConBackStateFlag = true;

        #endregion

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        public SQLSave()
        {
            //SetConFlag(true);
            //SetConFlag(false);
            m_ConnectionString_KJ128 = GetConfigValue("ConnectionString");
            m_ConnectionString_KJ128back = GetConfigValue("ConnectionString");
        }

        #endregion

        /*
         * 委托
         */

        #region [ 委托: 错误消息事件 ]

        /// <summary>
        /// 错误消息声明
        /// </summary>
        /// <param name="iErrNO">错误编号</param>
        /// <param name="strStackTrace">获取当前异常发生时调用堆栈上的帧的字符串表示形式</param>
        /// <param name="strSource">标识当前哪一段程序出的错误</param>
        /// <param name="strMessage">获取描述当前异常的消息</param>
        public delegate void ErrorMessageEventHandler(int iErrNO, string strStackTrace, string strSource, string strMessage);

        /// <summary>
        /// 错误消息事件
        /// </summary>
        public event ErrorMessageEventHandler ErrorMessage;

        #endregion

        /*
         * 接口
         */


        #region [ 接口: 关闭连接 ]

        /// <summary>
        /// 关闭连接
        /// </summary>
        /// <returns>成功返回True</returns>
        public bool CloseSQLConnect()
        {
            try
            {
                if (sqlConn != null)
                {
                    sqlConn.Dispose();
                }
                if (sqlConnBack != null)
                {
                    sqlConnBack.Dispose();
                }
            }
            catch (SqlException se)
            {
                if (ErrorMessage != null)
                {
                    if (se.ErrorCode != -2146232060)
                    {
                        ErrorMessage(6020008, se.StackTrace, "[SQLSave:ExecuteSql]", se.Message);
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6020009, ex.StackTrace, "[SQLSave:CloseSQLConnect]", ex.Message);
                }
                return false;
            }
            return true;
        }

        #endregion

        #region [ 接口: 执行SQL语句或存储过程，成功返回True]

        /// <summary>
        /// 调用主/备机中存储过程
        /// </summary>
        /// <param name="flag">true，表示主机；false，表示备机</param>
        /// <param name="procName">存储过程名</param>
        /// <param name="sqlParameters">存储过程参数</param>
        /// <returns>false执行失败</returns>
        public bool ExecuteSql(bool flag, string procName, SqlParameter[] sqlParameters)
        {
            if (flag)
            {
                if (sqlConn == null)
                {
                    SetConFlag(flag);
                }
                return ExecuteSql(flag, procName, sqlConn, sqlParameters);
            }
            else
            {
                if (sqlConnBack == null)
                {
                    SetConFlag(flag);
                }
                return ExecuteSql(flag, procName, sqlConnBack, sqlParameters);
            }
        }

        #endregion

        #region [ 接口: 执行SQL语句或存储过程，成功则返回DataTabel，失败则返回NULL ]

        /// <summary>
        ///  执行SQL语句或存储过程，成功则返回DataTabel，失败则返回NULL
        /// </summary>
        /// <param name="flag">True:KJ128N数据库;False:KJ128NBackUp数据库</param>
        /// <param name="procName">存储过程名</param>
        /// <param name="sqlParameters">存储过程参数</param>
        /// <returns>成功则返回查询结果(DataTable),失败则返回NULL</returns>
        public DataTable GetDataTabel(bool flag, string procName, SqlParameter[] sqlParameters)
        {
            DataSet ds;
            if (flag)
            {
                ds = GetDataSet(flag, procName, sqlConn, sqlParameters);
                if (ds != null)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                ds = GetDataSet(flag, procName, sqlConnBack, sqlParameters);
                if (ds != null)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

        /*
         * 方法
         */

        #region [ 方法: 执行SQL语句或存储过程，成功返回True]

        /// <summary>
        ///  执行SQL语句或存储过程，成功返回True
        /// </summary>
        /// <param name="flag">主/备服务器标识</param>
        /// <param name="procName">存储过程名</param>
        /// <param name="conn">连接</param>
        /// <param name="sqlParameters">存储过程参数</param>
        /// <returns>false执行失败</returns>
        private bool ExecuteSql(bool flag, string procName, SqlConnection conn, SqlParameter[] sqlParameters)
        {
            bool falg = true;
            SqlCommand sqlComm = null;
            try
            {
                if (conn == null || conn.ConnectionString.Equals("") || conn.ConnectionString.Equals(string.Empty))
                {
                    conn = SetConFlag(flag);
                }
                if (conn != null && conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                sqlComm = new SqlCommand(procName, conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                if (sqlParameters != null && sqlParameters.Length>0)
                {
                    foreach (SqlParameter sqlParameter in sqlParameters)
                    {
                        sqlComm.Parameters.Add(sqlParameter);
                    }
                }
                sqlComm.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                if (ErrorMessage != null)
                {
                    //if (se.ErrorCode != -2146232060)
                    //{
                    //    ErrorMessage(6020008, se.StackTrace, "[SQLSave:ExecuteSql]", se.Message);
                    //}
                    ErrorMessage(6020008, se.StackTrace, "[SQLSave:ExecuteSql][" + procName + "]", se.Message);
                }
                SetConFlag(flag);   //重新连接数据库
                falg = false;
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6020008, ex.StackTrace, "[SQLSave:ExecuteSql][" + procName + "]", ex.Message);
                }
                SetConFlag(flag);   //重新连接数据库
                falg = false;
            }
            finally
            {
                if (sqlComm != null)
                {
                    sqlComm.Dispose();
                    sqlComm = null;
                }
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
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

        #region [ 方法: 执行一个存储过程，返回一个DataSet记录集 ]

        /// <summary>
        /// 执行一个存储过程，返回一个DataSet记录集
        /// </summary>
        /// <param name="flag">True:KJ128N数据库;False:KJ128NBackUp数据库</param>
        /// <param name="procName">存储过程的名字</param>
        /// <param name="conn">SQLConnection的连接</param>
        /// <param name="sqlParmeters">存储过程的参数</param>
        /// <returns>DataSet表的记录集</returns>
        private DataSet GetDataSet(bool flag, string procName, SqlConnection conn, SqlParameter[] sqlParmeters)
        {
            DataSet ds = null;
            SqlDataAdapter sqlDataAdapter = null;
            //打开一个连接
            try
            {
                if (conn == null || conn.ConnectionString.Equals("") || conn.ConnectionString.Equals(string.Empty))
                {
                    conn = SetConFlag(flag);
                }
                ds = new DataSet();
                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = BuildSqlCommand(conn, procName, sqlParmeters);
                sqlDataAdapter.Fill(ds);
            }
            catch (SqlException se)
            {
                if (ErrorMessage != null)
                {
                    if (se.ErrorCode != -2146232060)
                    {
                        ErrorMessage(6020008, se.StackTrace, "[SQLSave:ExecuteSql][" + procName + "]", se.Message);
                    }
                }
                SetConFlag(flag);   //重新连接数据库
            }
            catch(Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6020008, ex.StackTrace, "[SQLSave:ExecuteSql][" + procName + "]", ex.Message);
                }
                SetConFlag(flag);   //重新连接数据库
            }
            finally
            {
                if (sqlDataAdapter != null)
                {
                    sqlDataAdapter.Dispose();
                    sqlDataAdapter = null;
                }
                if (conn != null)
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                    conn.Dispose();
                    conn = null;
                }
            }
            return ds;
        }

        #endregion

        #region [ 方法: 构造一个SqlCommand对象 ]
        /// <summary>
        /// 构造一个SqlCommand对象
        /// </summary>
        /// <param name="sqlConn">SQLConnection的连接</param>
        /// <param name="procName">过程名称</param>
        /// <param name="sqlParmeters">参数内容</param>
        /// <returns>SqlCommand</returns>
        private SqlCommand BuildSqlCommand(SqlConnection sqlConn, string procName, SqlParameter[] sqlParmeters)
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

        #endregion

        #region[ 方法: 创建数据库连接并设置连接状态标识 ]

        /// <summary>
        /// 创建数据库连接并设置连接状态标识
        /// </summary>
        /// <param name="flag">true，表示主机；false，表示备机</param>
        private SqlConnection SetConFlag(bool flag)
        {
            if (flag)
            {
                sqlConn = GetCon(m_ConnectionString_KJ128, out bConStateFlag);
                return sqlConn;
            }
            else
            {
                sqlConnBack = GetCon(m_ConnectionString_KJ128back, out bConBackStateFlag);
                return sqlConnBack;
            }
        }

        #endregion

        #region [ 方法: 创建数据库连接 ]

        /// <summary>
        /// 创建数据库连接
        /// </summary>
        /// <param name="strCon">连接字符串</param>
        /// <param name="bSuccess">是否成功</param>
        /// <returns>返回连接实例</returns>
        private SqlConnection GetCon(string strCon, out bool bSuccess)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(strCon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    // 丁修改
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(8020001, "", "[SQLSave:GetCon]", "连接成功");
                    }
                }
                bSuccess = true;
            }
            //catch (SqlException se)
            //{
            //    if (ErrorMessage != null)
            //    {
            //        if (se.ErrorCode != -2146232060)
            //        {
            //            ErrorMessage(6020007, se.StackTrace, "[SQLSave:ExecuteSql]", se.Message);
            //        }
            //    }
            //    bSuccess = false;
            //}
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6020007, ex.StackTrace, "[SQLSave:GetCon]", ex.Message);
                }
                //此处需要错误处理
                bSuccess = false;
            }
            return con;
        }

        #endregion

        #region 【方法：数据库连接判断】
        public void IsConnection(bool flag)
        {
            SqlConnection sqlC = null;
            try
            {
                sqlC = SetConFlag(flag);
            }
            catch { }
            finally
            {
                if (sqlC != null)
                {
                    if (sqlC.State == ConnectionState.Open)
                    {
                        sqlC.Close();
                    }
                    sqlC.Dispose();
                }
            }

        }
        #endregion
        /*
         * 释放资源
         */

        #region IDisposable 成员

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if (sqlConn != null)
            {
                sqlConn.Dispose();
            }
            if (sqlConnBack != null)
            {
                sqlConnBack.Dispose();
            }
        }

        #endregion

        #region【Czlt-2013-05-14 修改数据库配置】
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appKey"></param>
        /// <returns></returns>
        public string GetConfigValue(string appKey)
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
