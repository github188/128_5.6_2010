using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    /// <summary>
    /// 存储数据库的接口
    /// </summary>
    public interface IDBAcess
    {
        /// <summary>
        /// 创建一个新连接
        /// </summary>
        /// <returns>-1 失败</returns>
         int CreateConnection();

         #region 执行SQL语句或存储过程，返回影响的行数 int
        /// <summary>
        ///  执行SQL语句或存储过程，返回影响的行数 int
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="sqlParameters">存储过程参数</param>
        /// <returns>影响的行数,-1 执行失败</returns>
         int ExecuteSql(string procName, SqlParameter[] sqlParameters);

        /// <summary>
        /// 执行SQL语句或存储过程，返回影响的行数 int
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="sqlParameters">存储过程参数</param>
        /// <param name="sqlConn">Sql连接对象</param>
        /// <returns>影响的行数,-1 执行失败</returns>
         int ExecuteSql(string procName, SqlParameter[] sqlParameters, SqlConnection sqlConn);
        /// <summary>
        /// 关闭一个连接　
        /// </summary>
        /// <returns>-1 失败</returns>
         int CloseConnection();
        bool CheckIsKJ128A();
        #endregion
    }
}
