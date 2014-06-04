using System;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Configuration;
using System.Windows.Forms;
using KJ128NModel;
namespace KJ128NDataBase
{
    /// <summary>
    /// 数据访问层
    /// </summary>
    public class DBAcess:IDBAcess
    {
        #region 私有变量
        //private static string m_ConnectionString_KJ128 =ConfigurationSettings.AppSettings["ConnectionString"];
        //private SqlConnection m_SqlConnection=new SqlConnection(m_ConnectionString_KJ128);
        New_DBAcess NDA = new New_DBAcess();
        SerialModel SM = new SerialModel();
        SerialAndReserialOperate SARO = new SerialAndReserialOperate();
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public DBAcess()
        {
            //XmlDocument xmld = new XmlDocument();
            //xmld.Load(@"./app.config");
            //XmlNode xmldd = xmld.SelectSingleNode("add");
            //m_ConnectionString_KJ128 = xmldd.Attributes["connectionString"].ToString();
            //m_SqlConnection = new SqlConnection(m_ConnectionString_KJ128);
        }
        #endregion

        #region  【Czlt-2011-01-28 连接字符串】
        public string GetConn()
        {
            return New_DBAcess.strConn;
        }

        #endregion
        #region 连接字符串及测试连接
        /// <summary>
        ///  测试一个链接
        /// </summary>
        /// <returns>错误信息</returns>
        public int CreateConnection()
        {
            //try
            //{

            //    m_SqlConnection.Open();
            //    return 0;
            //}
            //catch
            //{
            //    return -1;
            //}
            return NDA.CreateConnection();
        }
        /// <summary>
        /// 关闭一个连接
        /// </summary>
        /// <returns></returns>
        public int CloseConnection()
        {
            //try
            //{
            //    m_SqlConnection.Close();
            //    return 0;
            //}
            //catch
            //{
            //    return -1;
            //}
            return NDA.CloseConnection();
        }
        #endregion

        #region 检测本版本是KJ128A，则返回True,如果版本为KJ128N，则返回False
        public bool CheckIsKJ128A()
        {
            bool Flag = false;
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.StartupPath+"\\IsKJ128AOrKJ128N.xml");
            if (Convert.ToBoolean(doc.ChildNodes[1].ChildNodes[0].InnerText))
            {
                Flag = true;
            }
            return Flag;
            
        }
        #endregion

        #region 方法

        #region 执行Sql语句或存储过程，返回一个DataSet
        /// <summary>
        /// 执行一个存储过程，返回一个DataSet记录集
        /// </summary>
        /// <param name="procName">存储过程的名字</param>
        /// <param name="sqlParmeters">存储过程的参数</param>
        /// <returns>DataSet表的记录集</returns>
        public DataSet GetDataSet(string procName,SqlParameter[] sqlParmeters)
        {
            return NDA.GetDataSet(procName, sqlParmeters);
            
        }
        /// <summary>
        ///执行一条SQL语句,返回一个DataSet记录集
        /// </summary>
        /// <param name="sqlText">一条Sql语句</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string sqlText)
        {
            return NDA.GetDataSet(sqlText);
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
            int intValue = 0;
            //if (CheckIsKJ128A())
            //{
            //    SM.FuntionName = "ACCESS_ExecuteSql1";
            //    SM.parameter = new parameters[sqlParameters.Length];
            //    for (int i = 0; i < sqlParameters.Length; i++)
            //    {
            //        SM.parameter[i].ParameterName = sqlParameters[i].ParameterName;
            //        SM.parameter[i].ParameterType = sqlParameters[i].SqlDbType;
            //        SM.parameter[i].intLongth = sqlParameters[i].Size;
            //        SM.parameter[i].objValue = sqlParameters[i].Value;
                    
            //    }
            //    SM.RestoryProcedureName = procName;

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
            intValue =  NDA.ExecuteSql(procName, sqlParameters);
            //}

            return intValue;
        }

        public int ExecCommand(SqlCommand comm)
        {
            return NDA.ExecCommand(comm);
        }


        /// <summary>
        ///  执行SQL语句或存储过程，返回影响的行数 int
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="sqlParameters">存储过程参数</param>
        /// <returns>影响的行数,-1 执行失败</returns>
        public int ExecuteSql(string procName, SqlParameter[] sqlParameters,out string strErr)
        {
            int intValue = 0;
            //if (CheckIsKJ128A())
            //{
            //    SM.FuntionName = "ACCESS_ExecuteSql2";
            //    SM.parameter = new parameters[sqlParameters.Length];
            //    for (int i = 0; i < sqlParameters.Length; i++)
            //    {
            //        SM.parameter[i].ParameterName = sqlParameters[i].ParameterName;
            //        SM.parameter[i].ParameterType = sqlParameters[i].SqlDbType;
            //        SM.parameter[i].intLongth = sqlParameters[i].Size;
            //        SM.parameter[i].objValue = sqlParameters[i].Value;

            //    }
            //    SM.RestoryProcedureName = procName;

            //    if (SARO.DataReceived(SARO.SerialOperate(SM)))
            //    {
            //        intValue = 1;
            //        strErr = "Succeeds";
            //    }
            //    else
            //    {
            //        intValue = -1;
            //    }

            //}
            //else
            //{
                intValue =  NDA.ExecuteSql(procName, sqlParameters, out strErr);
            //}
            strErr = "Succeeds";
            return intValue;
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
            int intValue = 0;
            //if (CheckIsKJ128A())
            //{
            //    SM.FuntionName = "ACCESS_ExecuteSql3";
            //    SM.parameter = new parameters[sqlParameters.Length];
            //    for (int i = 0; i < sqlParameters.Length; i++)
            //    {
            //        SM.parameter[i].ParameterName = sqlParameters[i].ParameterName;
            //        SM.parameter[i].ParameterType = sqlParameters[i].SqlDbType;
            //        SM.parameter[i].intLongth = sqlParameters[i].Size;
            //        SM.parameter[i].objValue = sqlParameters[i].Value;

            //    }
            //    SM.RestoryProcedureName = procName;

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
                intValue = NDA.ExecuteSql(procName, sqlParameters, sqlConn);
            //}

            return intValue;
        }
        /// <summary>
        ///  执行SQL语句或存储过程，返回影响的行数 int
        /// </summary>
        /// <param name="sqlString">Sql语句</param>
        /// <param name="sqlConn">sql连接对象</param>
        /// <returns>影响的行数 -1 失败</returns>
        public int ExecuteSql(string sqlString,SqlConnection sqlConn)
        {
            int intValue = 0;
            //if (CheckIsKJ128A())
            //{
            //    SM.FuntionName = "ACCESS_ExecuteSql4";
               
            //    SM.strSql = sqlString;

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
                intValue =  NDA.ExecuteSql(sqlString, sqlConn);
            //}
            return intValue;
        }


        /// <summary>
        ///  执行SQL语句或存储过程，返回影响的行数 int
        /// </summary>
        /// <param name="sqlString">Sql语句</param>
        /// <returns>影响的行数 -1 失败</returns>
        public int ExecuteSql(string sqlString)
        {
            int intValue = 0;
            //if (CheckIsKJ128A())
            //{
            //    SM.FuntionName = "ACCESS_ExecuteSql5";

            //    SM.strSql = sqlString;


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
                intValue=NDA.ExecuteSql(sqlString);
            //}
            return intValue;

        }

        #region Connection打开 关闭

        //private void ConnOpen()
        //{
        //    if (this.m_SqlConnection.State != ConnectionState.Open)
        //    {
        //        this.m_SqlConnection.Open();
        //    }
        //}

        //private void ConnClose()
        //{
        //    if (this.m_SqlConnection.State != ConnectionState.Closed)
        //    {
        //        this.m_SqlConnection.Close();
        //    }
        //}

        #endregion

        #region 返回结果集中第一行第一列的值

        public string ExecuteScalarSql(string sqlString)
        {
            return NDA.ExecuteScalarSql(sqlString);

        }

        #endregion

        /// <summary>
        ///  执行SQL语句或存储过程，返回影响的行数 int
        /// </summary>
        /// <param name="sqlString">Sql语句</param>
        /// <returns>影响的行数 -1 失败</returns>
        public int ExistsSql(string sqlString)
        {
            int intValue = 0;
            //if (CheckIsKJ128A())
            //{
            //    SM.FuntionName = "ACCESS_ExecuteSql6";

            //    SM.strSql = sqlString;


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
                intValue = NDA.ExistsSql(sqlString);
            //}

            return intValue;

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
            return NDA.GetDataReader(sqlString);
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
            DataSet ds = NDA.ExecuteSqlDataSet(procName, sqlParameters) == null ? new DataSet() : NDA.ExecuteSqlDataSet(procName, sqlParameters);
            return ds;
        }

        #endregion

        #region 属性
        /// <summary>
        /// 得到一个连接字符串
        /// </summary>
        //public string ConnectionStringKJ128N
        //{
        //    get { return m_ConnectionString_KJ128; }
        //    set { m_ConnectionString_KJ128 = value; }
        //}
        #endregion

    }
}
