using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using KJ128NModel;
using System.Xml;
namespace KJ128NDataBase
{
/// <summary>
/// 修改说明
/// 本次把Sqlhelper作为对象序列化次，把
/// </summary>
    public class DbHelperSQL
    {

        protected static string connectionString = string.Empty;

        New_DbHelperSQL NDBH = new New_DbHelperSQL();
        DBAcess DBA = new DBAcess();
        SerialModel SM = new SerialModel();
        SerialAndReserialOperate SARO = new SerialAndReserialOperate();
        public DbHelperSQL()
        {

        }

        #region 返回 DataTable

        public  DataTable ReturnDataTable(string storedProcName, SqlParameter[] parameters)
        {
            return NDBH.ReturnDataTable(storedProcName, parameters);
        }

        #endregion

        #region 返回 DataSet

        public DataSet ReturnDataSet(string storedProcName, SqlParameter[] parameters)
        {
            return NDBH.ReturnDataSet(storedProcName, parameters);
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
            return NDBH.RunProcedureByReader(storedProcName, parameters);
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

            Int64 intValue = 0;
            //if (DBA.CheckIsKJ128A())
            //{
            //    SM.FuntionName = "Helper_ExecuteSql1";
            //    SM.parameter = new parameters[parameters.Length];
            //    for (int i = 0; i < parameters.Length; i++)
            //    {
            //        SM.parameter[i].ParameterName = parameters[i].ParameterName;
            //        SM.parameter[i].ParameterType = parameters[i].SqlDbType;
            //        SM.parameter[i].intLongth = parameters[i].Size;
            //        SM.parameter[i].objValue = parameters[i].Value;

            //    }
            //    SM.RestoryProcedureName = storedProcName;

            //    if (SARO.DataReceived(SARO.SerialOperate(SM)))
            //    {
            //        intValue = 1;
            //        ErrMsgString = "Succeeds";

            //    }
            //    else
            //    {
            //        intValue = -1;
            //    }

            //}
            //else
            //{
                intValue = NDBH.RunProcedureByInt64(storedProcName, parameters, out ErrMsgString);
            //}
            ErrMsgString = "Succeeds";
            return intValue;
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

            ErrMsgString = string.Empty;
            int intValue = 0;
            //if (DBA.CheckIsKJ128A())
            //{
            //    SM.FuntionName = "Helper_ExecuteSql2";
            //    SM.parameter = new parameters[parameters.Length];
            //    SM.parameter = new parameters[parameters.Length];
            //    for (int i = 0; i < parameters.Length; i++)
            //    {
            //        SM.parameter[i].ParameterName = parameters[i].ParameterName;
            //        SM.parameter[i].ParameterType = parameters[i].SqlDbType;
            //        SM.parameter[i].intLongth = parameters[i].Size;
            //        SM.parameter[i].objValue = parameters[i].Value;

            //    }
            //    SM.RestoryProcedureName = storedProcName;

            //    if (SARO.DataReceived(SARO.SerialOperate(SM)))
            //    {
            //        intValue = 1;
            //        ErrMsgString = "Succeeds";
            //    }
            //    else
            //    {
            //        intValue = -1;
            //    }

            //}
            //else
            //{
                intValue = NDBH.RunProcedureByInt(storedProcName, parameters, out ErrMsgString);
            //}
            //ErrMsgString = "Succeeds";
            return intValue;
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
            int intValue = 0;
            //if (DBA.CheckIsKJ128A())
            //{
            //    SM.FuntionName = "Helper_ExecuteSql3";
            //    SM.RestoryProcedureName = storedProcName;

            //    if (SARO.DataReceived(SARO.SerialOperate(SM)))
            //    {
            //        intValue = 1;
            //        ErrMsgString = "Succeeds";
            //    }
            //    else
            //    {
            //        intValue = -1;
            //    }

            //}
            //else
            //{
                intValue = NDBH.RunProcedureByInt(storedProcName, out ErrMsgString);
            //}
            ErrMsgString = "Succeeds";
            return intValue;
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
            return NDBH.RunProcedureByDataSet(storedProcName, tableName, out ErrMsgString);
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
        public DataSet RunProcedureByDataSet(string storedProcName, string tableName, SqlParameter[] parameters,out string ErrMsgString)
        {
            return NDBH.RunProcedureByDataSet(storedProcName, tableName, parameters, out ErrMsgString);
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
            return NDBH.RunProcedureReturnString(storedProcName, parameters, out ErrMsgString);
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
            int intValue = 0;
            //if (DBA.CheckIsKJ128A())
            //{
            //    SM.FuntionName = "Helper_ExecuteSql4";
            //    SM.parameter = new parameters[parameters.Length];
            //    for (int i = 0; i < parameters.Length; i++)
            //    {
            //        SM.parameter[i].ParameterName = parameters[i].ParameterName;
            //        SM.parameter[i].ParameterType = parameters[i].SqlDbType;
            //        SM.parameter[i].intLongth = parameters[i].Size;
            //        SM.parameter[i].objValue = parameters[i].Value;

            //    }
            //    SM.RestoryProcedureName = storedProcName;

            //    if (SARO.DataReceived(SARO.SerialOperate(SM)))
            //    {
            //        intValue = 1;
            //        ErrMsgString = "Succeeds";
            //    }
            //    else
            //    {
            //        intValue = -1;
            //    }

            //}
            //else
            //{
                intValue = NDBH.RunProcedureReturnInt(storedProcName, parameters, out ErrMsgString);
            //}
            ErrMsgString = "Succeeds";
            return intValue;
        }

        #region 公用方法

        public int GetMaxID(string FieldName, string TableName)
        {
            return NDBH.GetMaxID(FieldName, TableName);
        }

        public bool Exists(string strSql)
        {
            return NDBH.Exists(strSql);
        }

        public bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            return NDBH.Exists(strSql, cmdParms);
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
             int intValue = 0;
            //if (DBA.CheckIsKJ128A())
            //{
            //    SM.FuntionName = "Helper_ExecuteSql5";
                
            //    SM.strSql = SQLString;

            //    if (SARO.DataReceived(SARO.SerialOperate(SM)))
            //    {
            //        intValue = 1;
            //    }
            //    else
            //    {
            //        intValue = -1;
            //    }

            //}
            //else
            //{
                intValue = NDBH.ExecuteSql(SQLString);
            //}
            return intValue;
        }

        public int ExecuteSqlByTime(string SQLString, int Times)
        {
            int intValue = 0;
            //if (DBA.CheckIsKJ128A())
            //{
            //    SM.FuntionName = "Helper_ExecuteSql6";
            //    SM.strSql = SQLString;
            //    SM.ComandTime = Times;
            //    if (SARO.DataReceived(SARO.SerialOperate(SM)))
            //    {
            //        intValue = 1;
            //    }
            //    else
            //    {
            //        intValue = -1;
            //    }

            //}
            //else
            //{
                intValue = NDBH.ExecuteSqlByTime(SQLString,Times);
            //}
            return intValue;
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public void ExecuteSqlTran(ArrayList SQLStringList)
        {
            
            //if (DBA.CheckIsKJ128A())
            //{
            //    SM.FuntionName = "Helper_ExecuteSql7";
            //    SM.Arraylist = SQLStringList;
            //    SARO.DataReceived(SARO.SerialOperate(SM));
            //}
            //else
            //{
                NDBH.ExecuteSqlTran(SQLStringList);
            //}
            
        }

        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString, string content)
        {
            int intValue = 0;
            //if (DBA.CheckIsKJ128A())
            //{
            //    SM.FuntionName = "Helper_ExecuteSql8";
            //    SM.strSql = SQLString;
            //    SM.strContent = content;
            //    if (SARO.DataReceived(SARO.SerialOperate(SM)))
            //    {
            //        intValue = 1;
            //    }
            //    else
            //    {
            //        intValue = -1;
            //    }

            //}
            //else
            //{
                intValue = NDBH.ExecuteSql(SQLString,content);
            //}

            return intValue;
        }

        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public object ExecuteSqlGet(string SQLString, string content)
        {
            object obj = null;
            //if (DBA.CheckIsKJ128A())
            //{
            //    SM.FuntionName = "Helper_ExecuteSql9";
            //    SM.strSql = SQLString;
            //    SM.strContent = content;
            //    SARO.DataReceived(SARO.SerialOperate(SM));
            //}
            //else
            //{
                obj=NDBH.ExecuteSqlGet(SQLString, content);
            //}

            return obj;
        }

        /// <summary>
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            int intValue = 0;
            //if (DBA.CheckIsKJ128A())
            //{
            //    SM.FuntionName = "Helper_ExecuteSql10";
            //    SM.strSql = strSQL;
            //    SM.fs = fs;
            //    if (SARO.DataReceived(SARO.SerialOperate(SM)))
            //    {
            //        intValue = 1;
            //    }
            //    else
            //    {
            //        intValue = -1;
            //    }

            //}
            //else
            //{
                intValue = NDBH.ExecuteSqlInsertImg(strSQL, fs);
            //}

            return intValue;
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string SQLString)
        {

            return NDBH.GetSingle(SQLString);
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader ExecuteReader(string strSQL)
        {
            return NDBH.ExecuteReader(strSQL);
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
            return NDBH.Query(SQLString);
        }

        public DataSet Query(string SQLString, int Times)
        {
            return NDBH.Query(SQLString, Times);
        }

        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString,SqlParameter[] cmdParms)
        {
            int intValue = 0;
            //if (DBA.CheckIsKJ128A())
            //{
            //    SM.FuntionName = "Helper_ExecuteSql11";
            //    SM.parameter = new parameters[cmdParms.Length];
            //    SM.strSql = SQLString;
            //    for (int i = 0; i < cmdParms.Length; i++)
            //    {
            //        SM.parameter[i].ParameterName = cmdParms[i].ParameterName;
            //        SM.parameter[i].ParameterType = cmdParms[i].SqlDbType;
            //        SM.parameter[i].intLongth = cmdParms[i].Size;
            //        SM.parameter[i].objValue = cmdParms[i].Value;

            //    }
            //    if (SARO.DataReceived(SARO.SerialOperate(SM)))
            //    {
            //        intValue = 1;
            //    }
            //    else
            //    {
            //        intValue = -1;
            //    }

            //}
            //else
            //{
                intValue = NDBH.ExecuteSql(SQLString, cmdParms);
            //}

            return intValue;
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public void ExecuteSqlTran(Hashtable SQLStringList)
        {
             NDBH.ExecuteSqlTran(SQLStringList);
        }


        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            return NDBH.GetSingle(SQLString, cmdParms);
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
        {
            return NDBH.ExecuteReader(SQLString, cmdParms);
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
            return NDBH.Query(SQLString, cmdParms);
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
            return NDBH.RunProcedure(storedProcName, parameters);
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
            return NDBH.RunProcedure(storedProcName, parameters, tableName);
        }

        public DataSet RunProcedure(string storedProcName, SqlParameter[] parameters, string tableName, int Times)
        {
            return NDBH.RunProcedure(storedProcName, parameters, tableName, Times);
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
            int intValue = 0;
            //if (DBA.CheckIsKJ128A())
            //{
            //    SM.FuntionName = "Helper_ExecuteSql12";
            //    SM.parameter = new parameters[parameters.Length];
            //    SM.RestoryProcedureName = storedProcName;
            //    for (int i = 0; i < parameters.Length; i++)
            //    {
            //        SM.parameter[i].ParameterName = parameters[i].ParameterName;
            //        SM.parameter[i].ParameterType = parameters[i].SqlDbType;
            //        SM.parameter[i].intLongth = parameters[i].Size;
            //        SM.parameter[i].objValue = parameters[i].Value;

            //    }
            //    if (SARO.DataReceived(SARO.SerialOperate(SM)))
            //    {
            //        intValue = 1;
            //        rowsAffected = 1;
            //    }
            //    else
            //    {
            //        intValue = -1;
            //        rowsAffected = -1;
            //    }

            //}
            //else
            //{
                intValue = NDBH.RunProcedure(storedProcName,parameters,out rowsAffected);
            //}
            rowsAffected = 0;
            return intValue;
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
            int intValue = 0;
            //if (DBA.CheckIsKJ128A())
            //{
            //    SM.FuntionName = "Helper_ExecuteSql13";
            //    SM.RestoryProcedureName = storedProcName;
                
            //    if (SARO.DataReceived(SARO.SerialOperate(SM)))
            //    {
            //        intValue = 1;
            //    }
            //    else
            //    {
            //        intValue = -1;
            //    }

            //}
            //else
            //{
                intValue = NDBH.RunProcedure(storedProcName);
            //}
            return intValue;
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
    }
}
