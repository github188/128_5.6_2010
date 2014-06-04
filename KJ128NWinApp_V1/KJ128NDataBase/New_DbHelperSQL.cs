using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Xml;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace KJ128NDataBase
{
    public class New_DbHelperSQL
    {
        public static bool blIsClient = false;
        private string strIsClient;
        private string strHostIP;
        private string strBackIP;

        XmlDocument doc = new XmlDocument();
        protected static string connectionString = string.Empty;
        protected SqlConnection connTest;
        public New_DbHelperSQL()
        {
            //if (File.Exists(Application.StartupPath + "\\Conn.dw"))
            //{
            //    connectionString = File.ReadAllText(Application.StartupPath + "\\Conn.dw");
            //    File.Delete(Application.StartupPath + "\\Conn.dw");
            //}
            if (connectionString == string.Empty)
            {
                this.ChangeDataBase();
            }
            if (TestNowConnection() != 0)
            {
                this.ChangeDataBase();
            }
        }

        #region 返回 DataTable

        public DataTable ReturnDataTable(string storedProcName, SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter sda = null;

                try
                {
                    conn.Open();
                    sda = new SqlDataAdapter();
                    sda.SelectCommand = BuildQueryCommand(conn, storedProcName, parameters);
                    sda.Fill(ds, "ds");
                    conn.Close();
                }
                catch (System.Data.SqlClient.SqlException sqlex)
                {
                    ErrorInfo(sqlex.Number);
                }
                catch (Exception ex)
                {
                    //throw ex;
                }
                finally
                {
                    if (sda != null)
                    {
                        sda.SelectCommand.Dispose();
                        sda.Dispose();
                    }
                    if (conn.State.ToString() != "Open")
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }

            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region 返回 DataSet

        public DataSet ReturnDataSet(string storedProcName, SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter sda = null;

                try
                {
                    conn.Open();
                    sda = new SqlDataAdapter();
                    sda.SelectCommand = BuildQueryCommand(conn, storedProcName, parameters);
                    sda.Fill(ds, "ds");
                    conn.Close();
                }
                catch (System.Data.SqlClient.SqlException sqlex)
                {
                    ErrorInfo(sqlex.Number);
                }
                catch (Exception ex)
                {
                    //throw ex;
                }
                finally
                {
                    if (sda != null)
                    {
                        sda.SelectCommand.Dispose();
                        sda.Dispose();
                    }
                    if (conn.State.ToString() != "Open")
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }

            if (ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Tmp

        #region 执行存储过程

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader RunProcedureByReader(string storedProcName, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataReader returnReader;
                try
                {
                    conn.Open();
                    SqlCommand command = BuildQueryCommand(conn, storedProcName, parameters);
                    command.CommandType = CommandType.StoredProcedure;
                    returnReader = command.ExecuteReader();
                    return returnReader;
                }
                catch (System.Data.SqlClient.SqlException sqlex)
                {
                    ErrorInfo(sqlex.Number);
                    throw sqlex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn != null)
                    {
                        if (conn.State.ToString() == "Open")
                        {
                            conn.Close();
                        }
                        conn.Dispose();
                    }
                }
            }
        }

        #endregion

        #region 执行存储过程，返回影响的行数 (OK)

        /// <summary>
        /// 执行存储过程，返回影响的行数
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public Int64 RunProcedureByInt64(string storedProcName, SqlParameter[] parameters, out string ErrMsgString)
        {
            int rowsAffected = 0;

            ErrMsgString = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                Int64 result = 0;
                SqlCommand cmd = null;

                try
                {
                    conn.Open();
                    cmd = BuildIntCommand(conn, storedProcName, parameters);
                    rowsAffected = cmd.ExecuteNonQuery();
                    result = (Int64)cmd.Parameters["ReturnValue"].Value;

                    // 执行成功
                    ErrMsgString = "Succeeds";
                }
                catch (System.Data.SqlClient.SqlException sqlex)
                {
                    ErrorInfo(sqlex.Number);
                    ErrMsgString = sqlex.Message;
                    rowsAffected = -1;
                }
                catch (Exception ex)
                {
                    ErrMsgString = ex.Message;
                    rowsAffected = -1;
                }
                finally
                {
                    parameters = null;
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                    if (conn.State.ToString() == "Open")
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }

                return result;
            }
        }

        #endregion

        #region 执行存储过程，返回影响的行数 (OK)

        /// <summary>
        /// 执行存储过程，返回影响的行数
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public int RunProcedureByInt(string storedProcName, SqlParameter[] parameters, out string ErrMsgString)
        {
            // int rowsAffected = 0;

            ErrMsgString = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                int result = 0;
                SqlCommand cmd = null;

                try
                {
                    conn.Open();
                    cmd = BuildIntCommand(conn, storedProcName, parameters);
                    result = cmd.ExecuteNonQuery();
                    //result = (int)cmd.Parameters["ReturnValue"].Value;

                    // 执行成功
                    ErrMsgString = "Succeeds";
                }
                catch (System.Data.SqlClient.SqlException sqlex)
                {
                    ErrorInfo(sqlex.Number);
                    ErrMsgString = sqlex.Message;
                    result = -1;
                }
                catch (Exception ex)
                {
                    ErrMsgString = ex.Message;
                    result = -1;
                }
                finally
                {
                    parameters = null;
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                    if (conn.State.ToString() == "Open")
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }

                return result;
            }
        }

        #endregion

        #region 执行存储过程，并获取返回值 (OK)

        /// <summary>
        /// 执行存储过程，并获取返回值
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public int RunProcedureByInt(string storedProcName, out string ErrMsgString)
        {
            int result = 0;

            ErrMsgString = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = null;
                SqlParameter Param = null;

                try
                {
                    conn.Open();

                    cmd = new SqlCommand(storedProcName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    Param = new SqlParameter("@RC", SqlDbType.Int);
                    Param.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(Param);

                    cmd.ExecuteNonQuery();

                    ErrMsgString = "Succeeds";

                    result = (int)Param.Value;
                }
                catch (System.Data.SqlClient.SqlException sqlex)
                {
                    ErrorInfo(sqlex.Number);
                    ErrMsgString = sqlex.Message;
                    sqlex = null;
                }
                catch (Exception ex)
                {
                    ErrMsgString = ex.Message;
                    ex = null;
                }
                finally
                {
                    Param = null;
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                    if (conn.State.ToString() != "Open")
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }

            return result;
        }

        #endregion

        #region 执行存储过程，并返回DataSet (OK)

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcedureByDataSet(string storedProcName, string tableName, out string ErrMsgString)
        {
            ErrMsgString = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter sda = null;
                try
                {
                    DataSet dataSet = new DataSet();

                    conn.Open();

                    sda = new SqlDataAdapter();
                    sda.SelectCommand = BuildQueryCommand(conn, storedProcName);
                    sda.Fill(dataSet, tableName);

                    conn.Close();
                    ErrMsgString = "Succeeds";

                    return dataSet;
                }
                catch (System.Data.SqlClient.SqlException sqlex)
                {
                    ErrorInfo(sqlex.Number);
                    ErrMsgString = sqlex.Message;
                    //sqlex = null;
                }
                catch (Exception ex)
                {
                    ErrMsgString = ex.Message;
                    //	em = ErrInfo.BuildErrMsg(ex);
                    ex = null;
                }
                finally
                {
                    if (sda != null)
                    {
                        sda.SelectCommand.Dispose();
                        sda.Dispose();
                    }
                    if (conn.State.ToString() != "Open")
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }

            return null;
        }

        #endregion

        #region 执行存储过程，并返回DataSet (OK)

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcedureByDataSet(string storedProcName, string tableName, SqlParameter[] parameters,
                                                    out string ErrMsgString)
        {
            ErrMsgString = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter sda = null;

                try
                {
                    conn.Open();
                    sda = new SqlDataAdapter();
                    sda.SelectCommand = BuildQueryCommand(conn, storedProcName, parameters);
                    sda.Fill(ds, tableName);
                    conn.Close();

                    ErrMsgString = "Succeeds";


                    return ds;
                }
                catch (System.Data.SqlClient.SqlException sqlex)
                {
                    ErrorInfo(sqlex.Number);
                    ErrMsgString = sqlex.Message;
                    //sqlex = null;
                }
                catch (Exception ex)
                {
                    //	em = ErrInfo.BuildErrMsg(ex);
                    ErrMsgString = ex.Message;
                    ex = null;
                }
                finally
                {
                    if (sda != null)
                    {
                        sda.SelectCommand.Dispose();
                        sda.Dispose();
                    }
                    if (conn.State.ToString() != "Open")
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }

            return null;
        }

        #endregion

        #region 执行存储过程，并获取返回值 (OK)

        /// <summary>
        /// 执行存储过程，并获取返回值
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public string RunProcedureReturnString(string storedProcName, SqlParameter[] parameters,
                                                      out string ErrMsgString)
        {
            string result = string.Empty;

            ErrMsgString = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = null;
                SqlParameter Param = null;

                try
                {
                    conn.Open();

                    cmd = BuildQueryCommand(conn, storedProcName, parameters);

                    Param = new SqlParameter("@RC", SqlDbType.Int);
                    Param.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(Param);

                    result = cmd.ExecuteScalar().ToString();

                    ErrMsgString = "Succeeds";

                    return result;
                }
                catch (System.Data.SqlClient.SqlException sqlex)
                {
                    ErrorInfo(sqlex.Number);
                    ErrMsgString = sqlex.Message;
                    //sqlex = null;
                }
                catch (Exception ex)
                {
                    ErrMsgString = ex.Message;
                    ex = null;
                }
                finally
                {
                    Param = null;
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                    if (conn.State.ToString() != "Open")
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }

            return result;
        }

        #endregion

        /// <summary>
        /// 执行存储过程，并获取返回值
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public int RunProcedureReturnInt(string storedProcName, SqlParameter[] parameters, out string ErrMsgString)
        {
            int result = -1;

            ErrMsgString = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = null;
                SqlParameter Param = null;

                try
                {
                    conn.Open();

                    cmd = BuildQueryCommand(conn, storedProcName, parameters);

                    Param = new SqlParameter("@RC", SqlDbType.Int);
                    Param.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(Param);

                    result = cmd.ExecuteNonQuery();

                    ErrMsgString = "Succeeds";

                    return result;
                }
                catch (System.Data.SqlClient.SqlException sqlex)
                {
                    ErrorInfo(sqlex.Number);
                    ErrMsgString = sqlex.Message;
                    //sqlex = null;
                }
                catch (Exception ex)
                {
                    ErrMsgString = ex.Message;
                    ex = null;
                }
                finally
                {
                    Param = null;
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                    if (conn.State.ToString() != "Open")
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }

            return result;
        }

        #region 公用方法

        public int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        public bool Exists(string strSql)
        {
            object obj = GetSingle(strSql);
            int cmdresult;
            if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region  执行简单SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (SqlException E)
                    {
                        ErrorInfo(E.Number);
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        public int ExecuteSqlByTime(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (SqlException E)
                    {
                        ErrorInfo(E.Number);
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public void ExecuteSqlTran(ArrayList SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (SqlException E)
                {
                    ErrorInfo(E.Number);
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
            }
        }

        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                SqlParameter myParameter = new SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (SqlException E)
                {
                    ErrorInfo(E.Number);
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public object ExecuteSqlGet(string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                SqlParameter myParameter = new SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    object obj = cmd.ExecuteScalar();
                    if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (SqlException E)
                {
                    ErrorInfo(E.Number);
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(strSQL, connection);
                SqlParameter myParameter = new SqlParameter("@fs", SqlDbType.Image);
                myParameter.Value = fs;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (SqlException E)
                {
                    ErrorInfo(E.Number);
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (SqlException e)
                    {
                        ErrorInfo(e.Number);
                        connection.Close();
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader ExecuteReader(string strSQL)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                SqlDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (SqlException e)
            {
                ErrorInfo(e.Number);
                throw new Exception(e.Message);
            }
            //			finally
            //			{
            //				cmd.Dispose();
            //				connection.Close();
            //			}	
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                    //command.Fill(ds);

                }
                catch (SqlException ex)
                {
                    ErrorInfo(ex.Number);
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        public DataSet Query(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.SelectCommand.CommandTimeout = Times;
                    command.Fill(ds, "ds");
                }
                catch (SqlException ex)
                {
                    ErrorInfo(ex.Number);
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (SqlException E)
                    {
                        ErrorInfo(E.Number);
                        throw new Exception(E.Message);
                    }
                }
            }
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                            trans.Commit();
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        ErrorInfo(sqlEx.Number);
                        trans.Rollback();
                        throw;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }


        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (SqlException e)
                    {
                        ErrorInfo(e.Number);
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                SqlDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (SqlException e)
            {
                ErrorInfo(e.Number);
                throw new Exception(e.Message);
            }
            //			finally
            //			{
            //				cmd.Dispose();
            //				connection.Close();
            //			}	
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (SqlException ex)
                    {
                        ErrorInfo(ex.Number);
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }


        private void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText,
                                           SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text; //cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        #endregion

        #region 存储过程操作

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader RunProcedure(string storedProcName, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataReader returnReader;
                connection.Open();
                SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
                command.CommandType = CommandType.StoredProcedure;
                returnReader = command.ExecuteReader();
                return returnReader;
            }
        }


        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcedure(string storedProcName, SqlParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }

        public DataSet RunProcedure(string storedProcName, SqlParameter[] parameters, string tableName, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.SelectCommand.CommandTimeout = Times;
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }


        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName,
                                                    SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    if (parameter != null)
                    {
                        // 检查未分配值的输出参数,将其分配以DBNull.Value.
                        if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                            (parameter.Value == null))
                        {
                            parameter.Value = DBNull.Value;
                        }
                        command.Parameters.Add(parameter);
                    }
                }
            }

            return command;
        }

        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public int RunProcedure(string storedProcName, SqlParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                int result = 0;
                SqlCommand cmd = null;

                try
                {
                    conn.Open();
                    cmd = BuildIntCommand(conn, storedProcName, parameters);
                    rowsAffected = cmd.ExecuteNonQuery();
                    result = (int)cmd.Parameters["ReturnValue"].Value;
                }
                catch (SqlException sqlEx)
                {
                    ErrorInfo(sqlEx.Number);
                    rowsAffected = -1;
                }
                catch (Exception ex)
                {
                    ex = null;
                    rowsAffected = -1;
                }
                finally
                {
                    parameters = null;
                    cmd.Dispose();
                    conn.Close();
                    conn.Dispose();
                }

                return result;
            }
        }

        #region 执行存储过程，并获取返回整型值

        /// <summary>
        /// 执行存储过程，并获取返回值
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public int RunProcedure(string storedProcName)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = null;
                SqlParameter Param = null;

                try
                {
                    conn.Open();

                    cmd = new SqlCommand(storedProcName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    Param = new SqlParameter("@RC", SqlDbType.Int);
                    Param.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(Param);

                    cmd.ExecuteNonQuery();

                    result = (int)Param.Value;
                }
                catch (SqlException sqlEx)
                {
                    ErrorInfo(sqlEx.Number);

                }
                catch (Exception ex)
                {
                    //throw ex;
                }
                finally
                {
                    Param = null;
                    cmd.Dispose();
                    conn.Close();
                    conn.Dispose();
                }
            }

            return result;
        }

        #endregion

        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <returns>SqlCommand</returns>
        private SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;


            return command;
        }

        /// <summary>
        /// 创建 SqlCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand 对象实例</returns>
        private SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, SqlParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                                                    SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                                                    false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        #endregion

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
                        //connectionString = "server=.;database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                        connectionString = GetConn();
                        Flag = true;

                    }
                    else
                    {
                        #region []
                        ////如果本机为备机
                        ////读取IPAddress
                        //string strIPAddress = xmldoc.SelectSingleNode("//IPAddress").ChildNodes[0].Value.ToString();
                        //connectionString = "server=" + strIPAddress + ";database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                        //try
                        //{
                        //    //测试连接是否可用
                        //    connTest = new SqlConnection(connectionString);
                        //    connTest.Open();
                        //    connTest.Close();
                        //    Flag = true;

                        //}
                        //catch
                        //{
                        //    //连接不可用，则更换为本机的连接
                        //    connectionString = "server = .;database=KJ128NBackUp;uid=sa;pwd=sa;Timeout=5";
                        //    try
                        //    {
                        //        //测试本机的连接是否可用
                        //        connTest = new SqlConnection(connectionString);
                        //        connTest.Open();
                        //        connTest.Close();
                        //        Flag = true;

                        //    }
                        //    catch
                        //    {
                        //        Flag = false;
                        //    }
                        //}
                        #endregion
                        int intFlag = GetDataBaseXMLValue();

                        if (intFlag.Equals(1))
                        {
                            //读取IPAddress
                            string strIPAddress = xmldoc.SelectSingleNode("//IPAddress").ChildNodes[0].Value.ToString();
                            //connectionString = "server=" + strIPAddress + ";database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                            string con = ConfigurationSettings.AppSettings["ConnectionString"];
                            connectionString = "server=" + strIPAddress + con.Substring(con.IndexOf(';'));
                            try
                            {
                                //测试连接是否可用
                                connTest = new SqlConnection(connectionString);
                                connTest.Open();
                                connTest.Close();
                                Flag = true;

                            }
                            catch
                            {
                                Flag = false;
                            }
                        }
                        else if (intFlag.Equals(2))
                        {
                            //connectionString = "server = .;database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                            connectionString = GetConn();
                            try
                            {
                                //测试本机的连接是否可用
                                connTest = new SqlConnection(connectionString);
                                connTest.Open();
                                connTest.Close();
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
                            //connectionString = "server=" + strIPAddress + ";database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                            string con = ConfigurationSettings.AppSettings["ConnectionString"];
                            connectionString = "server=" + strIPAddress + con.Substring(con.IndexOf(';'));
                            try
                            {
                                //测试连接是否可用
                                connTest = new SqlConnection(connectionString);
                                connTest.Open();
                                connTest.Close();
                                Flag = true;

                            }
                            catch
                            {
                                //连接不可用，则更换为本机的连接
                                // connectionString = "server = .;database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                                connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
                                try
                                {
                                    //测试本机的连接是否可用
                                    connTest = new SqlConnection(connectionString);
                                    connTest.Open();
                                    connTest.Close();
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
                    //connectionString = "server=.;database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                    connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
                    Flag = true;
                }
                //return Flag;
            }
            else          //为KJ128N,从AppConfig中读取数据库连接字段
            {
                //connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
                if (this.GetIsClientXMLValue())     //KJ128A的客户端版本
                {
                    //connectionString = "server=" + strHostIP + ";database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                    string con = ConfigurationSettings.AppSettings["ConnectionString"];
                    connectionString = "server=" + strHostIP + con.Substring(con.IndexOf(';'));
                    try
                    {
                        //测试连接是否可用
                        connTest = new SqlConnection(connectionString);
                        connTest.Open();
                        connTest.Close();
                        Flag = true;

                    }
                    catch
                    {
                        //连接不可用，则更换为本机的连接
                        //connectionString = "server = " + strBackIP + ";database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                        con = ConfigurationSettings.AppSettings["ConnectionString"];
                        connectionString = "server=" + strBackIP + con.Substring(con.IndexOf(';'));
                        try
                        {
                            //测试本机的连接是否可用
                            connTest = new SqlConnection(connectionString);
                            connTest.Open();
                            connTest.Close();
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
                    connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
                    Flag = true;
                }
            }
            return Flag;
        }
        #endregion

        #region 测试现在的连接是否可用
        public int TestNowConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                conn.Close();
                return 0;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return -1;

        }
        #endregion


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
            catch { }
            return false;
        }

        #endregion

        #region[Czlt-2013-03-28 数据库连接字符串]


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
        #endregion
    }
}
