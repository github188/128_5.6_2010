using System;
using System.Data.SqlClient;
using KJ128A.DataSave.Base;
using System.Data;

namespace KJ128A.DataSave
{
    /// <summary>
    /// 支持热备的接口
    /// </summary>
    public class InterfaceHostBack
    {
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

        #region [ 声明 ]
        /// <summary>
        /// 存SQL Server数据库
        /// </summary>
        public SQLSave sqlSave;

        #endregion

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        public InterfaceHostBack()
        {
            sqlSave = new SQLSave();
            sqlSave.ErrorMessage += _ErrorMessage;
        }

        #endregion

        #region [ 委托方法 ]
        /// <summary>
        /// 注册错误消息处理
        /// </summary>
        /// <param name="iErrNO">错误消息编号</param>
        /// <param name="strStackTrace">获取当前异常发生时调用堆栈上的帧的字符串表示形式</param>
        /// <param name="strSource">标识当前哪一段程序出的错误</param>
        /// <param name="strMessage">获取描述当前异常的消息</param>
        void _ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            if (ErrorMessage != null)
            {
                ErrorMessage(iErrNO, strStackTrace, strSource, strMessage);
            }
        }

        #endregion

        /*
         * SQL数据库操作
         */

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
            
             return sqlSave.ExecuteSql(flag, procName, sqlParameters);
            
        }

        #endregion

        #region [ 接口: 执行存储过程，返回DataTable ]

        /// <summary>
        /// 执行存储过程，返回DataTable
        /// </summary>
        /// <param name="flag">true，表示主机；false，表示备机</param>
        /// <param name="procName">存储过程名</param>
        /// <param name="sqlParameters">存储过程参数</param>
        /// <returns>成功则返回DataTable，失败则返回Null</returns>
        public DataTable GetDataTabel(bool flag, string procName, SqlParameter[] sqlParameters)
        {
            
                return sqlSave.GetDataTabel(flag, procName, sqlParameters);
            
        }

        #endregion

        #region [方法：判断数据库连接]
        /// <summary>
        /// 判断数据库连接状态
        /// </summary>
        /// <param name="flag">true 主机  false 备机</param>
        public void IsConnect(bool flag)
        {
            sqlSave.IsConnection(flag);
        }
        #endregion

        #region [ 接口:关闭数据库的连接 ]

        /// <summary>
        ///  关闭数据库的连接
        /// </summary>
        public bool CloeseConnect()
        {
           
                return sqlSave.CloseSQLConnect();
            
        }

        #endregion
    }
}
