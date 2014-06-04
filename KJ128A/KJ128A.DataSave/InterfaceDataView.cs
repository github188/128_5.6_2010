using System.Data;
using KJ128A.DataSave.Base;

namespace KJ128A.DataSave
{
    /// <summary>
    /// 支持DataView的接口
    /// </summary>
    public  class InterfaceDataView
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
        /// Access操作接口
        /// </summary>
        public AccessInterface accInteface = new AccessInterface();

        #endregion

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        public InterfaceDataView()
        {
            accInteface.ErrorMessage += accInteface_ErrorMessage;
        }

        #endregion

        #region  [ 委托方法 ]

        /// <summary>
        /// 注册错误消息处理
        /// </summary>
        /// <param name="iErrNO">错误消息编号</param>
        /// <param name="strStackTrace">获取当前异常发生时调用堆栈上的帧的字符串表示形式</param>
        /// <param name="strSource">标识当前哪一段程序出的错误</param>
        /// <param name="strMessage">获取描述当前异常的消息</param>
        void accInteface_ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            if (ErrorMessage != null)
            {
                ErrorMessage(iErrNO, strStackTrace, strSource, strMessage);
            }
        }

        #endregion

        #region  [ 接口: 已知一个数据库名称，返回一个表名数组 ]

        /// <summary>
        /// 已知一个数据库名称，返回一个表名数组
        /// </summary>
        /// <param name="strMDBName">数据库名称，例如："2008-1-25.mdb"</param>
        /// <returns>表名数组,查找失败返回空</returns>
        public string[] GetTableName(string strMDBName)
        {
           
                return accInteface.GetTableName(strMDBName);
           
        }

        #endregion

        #region  [ 接口: 已知数据库名称和表名，返回表中的数据 ]

        /// <summary>
        /// 已知数据库名称和表名，返回表中的数据
        /// </summary>
        /// <param name="strMDBName">数据库名称,如"2008-1-30.mdb"</param>
        /// <param name="strTableName">表名，如"NewData09"</param>
        /// <returns>数据表</returns>
        public DataTable DataSelectAll(string strMDBName, string strTableName)
        {
            
                return accInteface.DataSelectAll(strMDBName, strTableName);
            
        }

        #endregion 

        #region [ 接口:关闭数据库的连接 ]

        /// <summary>
        ///  关闭数据库的连接
        /// </summary>
        public bool CloeseConnect()
        {
            
                return accInteface.CloeseConnect();
            
        }

        #endregion
    }
}
