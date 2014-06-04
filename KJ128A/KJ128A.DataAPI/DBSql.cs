using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace KJ128A.DataAPI
{
    /// <summary>
    /// SQL Server 数据库
    /// </summary>
    public class DBSql: IDisposable
    {
        private readonly string _DBConnectionString = string.Empty;

        private readonly IDbFactory _dbFactory;
        private IDbConnection _dbConn;
        private IDbCommand _dbCommand;

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        public DBSql(string strConnectionString, EnumDBType enumDBType)
        {
            _dbFactory = DBFactory.CreateInstance(enumDBType);

            // 设置连接字符串
            _DBConnectionString = strConnectionString;

            CreateConnection();
        }

        #endregion

        #region [ 方法: 创建连接 ]

        /// <summary>
        /// 创建连接
        /// </summary>
        /// <returns></returns>
        private bool CreateConnection()
        {
            _dbConn = _dbFactory.CreateConnection();
            _dbConn.ConnectionString = _DBConnectionString;

            return true;
        }

        #endregion

        #region [ 方法: 创建命令 ]

        /// <summary>
        /// 创建命令
        /// </summary>
        /// <returns></returns>
        private bool CreateCommand(string strCmdText, CommandType cmdType)
        {
            _dbCommand = _dbFactory.CreateCommand();
            _dbCommand.Connection = _dbConn;

            _dbCommand.CommandText = strCmdText;
            _dbCommand.CommandType = cmdType;

            return true;
        }

        #endregion

        #region [ 方法: 执行存储过程 ]

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <returns></returns>
        public int ExecProc(string strCmdText, IDbDataParameter[] dbParams)
        {
            CreateCommand(strCmdText, CommandType.StoredProcedure);

            foreach (IDbDataParameter sqlParameter in dbParams)
            {
                _dbCommand.Parameters.Add(sqlParameter);
            }

            return _dbCommand.ExecuteNonQuery();
        }

        #endregion

        #region [ 方法: 打开连接 ]

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <returns></returns>
        public bool Open()
        {
            try
            {
                _dbConn.Open();
            }
            catch
            {
                
            }
            
            return true;
        }

        #endregion

        #region [ 方法: 关闭连接 ]

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        /// <returns></returns>
        public bool Close()
        {
            _dbConn.Close();
            return true;
        }

        #endregion

        #region [ 属性: 有无连接到数据库 ]

        private bool _ConnectionToDB;

        /// <summary>
        /// 有无连接到数据库
        /// </summary>
        public bool ConnectionToDB
        {
            get { return _ConnectionToDB ; }
            set { _ConnectionToDB = value; }
        }

        #endregion

        #region IDisposable 成员

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            _dbConn.Dispose();
            _dbConn = null;
        }

        #endregion
    }
}
