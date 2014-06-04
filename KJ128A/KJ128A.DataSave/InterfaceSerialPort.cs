using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Threading;
using KJ128A.BatmanAPI;
using KJ128A.DataAnalyzing;
using KJ128A.DataSave.Base;
//using KJ128A.HostBack;

namespace KJ128A.DataSave
{

    /// <summary>
    /// 数据库存储
    /// </summary>
    public class InterfaceSerialPort
    {
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

        //private readonly AccessInterface accInter = new AccessInterface();

        #endregion

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        public InterfaceSerialPort()
        {
            //accInter.ErrorMessage += accInter_ErrorMessage;
        }

        #endregion

        #region [ 错误消息处理 ]

        /// <summary>
        /// 错误消息处理
        /// </summary>
        /// <param name="iErrNO"></param>
        /// <param name="strStackTrace"></param>
        /// <param name="strSource"></param>
        /// <param name="strMessage"></param>
        private void accInter_ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            //if (ErrorMessage != null)
            //{
            //    ErrorMessage(iErrNO, strStackTrace, strSource, strMessage);
            //}
        }

        #endregion

        /*
         *  接口 
         */
        #region [ 接口: 数据抵达 ]
        /// <summary>
        /// 数据抵达
        /// </summary>
        /// <param name="cmdBytes"></param>
        /// <param name="blnHost">True:主机;False:备机</param>
        /// <returns></returns>
        public bool DataReceived(byte[] cmdBytes, bool blnHost)
        {
            bool flag=true;
            if (blnHost)             //主机
            {
                //写入Access数据库的原始表（OrgData），并将已同步（IsSync）置为False、、同步中（IsSyncing）置为False
                //flag = accInter.InsertData_OrgData(DateTime.Now, cmdBytes, false, 0);

            }
            else                    //备机
            {
                //写入Access数据库的发送表（NewData）
                //flag = accInter.InsertData_NewData(DateTime.Now.ToString("yyyyMMddHHmmssfff"), cmdBytes, false, false, 0);

            }

            return flag;
            
        }

        /// <summary>
        /// 数据抵达（配置数据库）
        /// </summary>
        /// <param name="cmdBytes"></param>
        /// <returns></returns>
        public bool DataReceived(byte[] cmdBytes)
        {
            bool falg = true;
            //falg = accInter.InsertData_Config(DateTime.Now.ToString("yyyyMMddHHmmssfff"), cmdBytes, false, 0);
            return falg;

        }
        #endregion


        #region [ 接口: 退出线程 ]

        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public bool Exit()
        {
            //关闭 Access数据库连接
            
                //accInter.CloeseConnect();
            
            return true;
        }

        #endregion

    }
}