using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Threading;

namespace KJ128A.DataSave
{
    /// <summary>
    /// 更改Access数据库
    /// </summary>
    public class AccessUpdate
    {
        #region[ 申明 ]

        private AccessBase accImp = new AccessBase();
        //private string strSQL = String.Empty;
        //private Random ra = new Random();

        #endregion

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

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        public AccessUpdate()
        {
            accImp.ErrorMessage += new AccessBase.ErrorMessageEventHandler(_ErrorMessage);
        }

        #endregion

        #region [ 注册委托 : 错误消息 ]

        /// <summary>
        /// 错误消息事件声明
        /// </summary>
        /// <param name="iErrNO">错误编号</param>
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

        #region  [ 方法: 执行command命令 ]

        /// <summary>
        /// 执行command命令(删除/插入/修改)
        /// </summary>
        /// <param name="strCommand">command命令字符</param>
        /// <param name="filename">数据库连接</param>
        /// <returns>成功返回true</returns>
        public bool ExcuteCommand(string strCommand,string filename)
        {
            bool falg = true;
            OleDbConnection conn = null;
            OleDbCommand command = null;
            try
            {
                conn = DAO.GetConn(filename);
                command = new OleDbCommand(strCommand, conn);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                int num = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (Thread.CurrentThread.Name == "DataSave")
                    Thread.Sleep(100);
                if (ex.Message.IndexOf("由于您和其他用户试图同时改变同一数据") != -1)
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                        conn.Dispose();
                        conn = null;
                    }
                    try
                    {
                        string strfilenameTemp = System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + filename.Replace(".mdb", ".ldb");
                        if (File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + filename))
                        {
                            File.Delete(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + filename);
                        }
                        File.Delete(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + filename);
                    }
                    catch { }
                    Thread.Sleep(100);
                    falg = false;
                }
                else if (ex.Message.IndexOf("不可识别的数据库格式") != -1)
                {
                    //if (ErrorMessage != null)
                    //{
                    //    ErrorMessage(6020012, ex.StackTrace, "[UpDataAccess:ExcuteCommand]", ex.Message + Thread.CurrentThread.Name);
                    //}
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                        conn.Dispose();
                        conn = null;
                    }
                    try
                    {
                        string strfilenameTemp = System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + filename.Replace(".mdb", ".ldb");
                        if (File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + filename))
                        {
                            File.Delete(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + filename);
                        }
                        File.Delete(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + filename);
                    }
                    catch { }
                    Thread.Sleep(100);
                    falg = false;
                }
                else
                {
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020012, ex.StackTrace, "[UpDataAccess:ExcuteCommand]", Thread.CurrentThread.Name + ex.Message + strCommand);
                    }
                    falg = false;
                }
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                    command = null;
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
    }
}
