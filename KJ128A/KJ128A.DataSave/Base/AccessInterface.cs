using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Threading;

namespace KJ128A.DataSave.Base
{
    /// <summary>
    /// Access操作接口
    /// </summary>
    public class AccessInterface
    {
        #region [ 属性 ]

        private readonly AccessInsert insertAcc = new AccessInsert();    // Access 插入    
        private readonly AccessSelect selectAcc = new AccessSelect();    // Access 查找
        private readonly AccessUpdate updateAcc = new AccessUpdate();    // Access 更新

        private readonly AccessBase accImp = new AccessBase();       // Access 公用方法
        //private  OleDbConnection dbConn = null;
        private string strSQL = String.Empty;

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
         * 构造函数
         */

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        public AccessInterface()
        {
            //注册弹出对话框委托事件
            insertAcc.ErrorMessage += _ErrorMessage;
            updateAcc.ErrorMessage += _ErrorMessage;
            updateAcc.ErrorMessage += _ErrorMessage;
            accImp.ErrorMessage += _ErrorMessage;
        }

        #endregion

        #region [ 注册委托 ]

        /// <summary>
        /// 注册错误消息处理
        /// </summary>
        /// <param name="iErrNO">错误消息编号</param>
        /// <param name="strStackTrace">获取当前异常发生时调用堆栈上的帧的字符串表示形式</param>
        /// <param name="strSource">标识当前哪一段程序出的错误</param>
        /// <param name="strMessage">获取描述当前异常的消息</param>
        void _ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            string strError=String.Empty;
            switch (iErrNO)
            {
                #region Access数据库操作

                case 6020001:
                    strError = "连接Access数据库失败，原因：" + strMessage;
                    break;
                case 6020004:
                    strError = "无法获取AccessDB文件夹下所有数据库的名称，原因为：" + strMessage;
                    break;
                case 6020006:
                    strError = "向Access数据库中插入数据出错，原因为：" + strMessage;
                    break;
                case 6020010:
                    strError = "关闭Access数据库连接失败，原因：" + strMessage;
                    break;
                case 6020011:
                    strError = "查询Access数据库中的数据出错，原因：" + strMessage;
                    break;
                case 6020012:
                    strError = "更改Access数据库中的数据出错，原因：" + strMessage;
                    break;
                case 6020014:
                    strError = strMessage;
                    break;
                case 6020015:
                    strError = strMessage;
                    break;

                #endregion

                #region SQL数据库操作

                case 6020007:
                    strError = "连接SQL数据库失败，原因：" + strMessage;
                    break;
                case 6020008:
                    strError = "执行SQL存储过程失败，原因：" + strMessage;
                    break;
                case 6020009:
                    strError = "关闭SQL数据库连接失败，原因：" + strMessage;
                    break;

                #endregion

                #region 磁盘剩余容量检测

                case 4020001:
                    strError = "注意：系统已经帮您清理出一些磁盘空间，为保证程序的正确运行请您尽快大量清理磁盘！";
                    break;
                case 4020002:
                    strError = "注意：磁盘空间不足200M，请尽快清理磁盘！当磁盘容量小于100M时，我们将强制清理磁盘！";
                    break;
                #endregion

                #region  文件操作

                case 6020002:
                    strError = "无法创建新的Access数据库，原因：" + strMessage;
                    break;
                case 4020003:
                    strError = "Interop.MSAdodcLib.Modle.dll( 数据库模板 ）文件被删除！";
                    break;
                case 6020005:
                    strError = "无法取消文件的只读属性，原因为：" + strMessage;
                    break;
                case 6020013:
                    strError = "无法删除数据库文件，原因为：" + strMessage;
                    break;
                #endregion
               
                default:
                    break;
            }
            if (ErrorMessage != null)
            {
                ErrorMessage(iErrNO, strStackTrace, strSource, strError);
            }
        }

        #endregion

        /*
         *  向表中插入数据
         */

        /// <summary>
        /// 把配置信息添加到配置表中
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="bytes"></param>
        /// <param name="bIsSync"></param>
        /// <param name="intIsSyncing"></param>
        /// <returns></returns>
        public bool InsertData_Config(DateTime dateTime, byte[] bytes, bool bIsSync, int intIsSyncing)
        {
            return InsertData_Config(dateTime.ToString("yyyyMMddHHmmssfff"), bytes, bIsSync, intIsSyncing);
        }
        /// <summary>
        /// 把配置信息添加到配置表中
        /// </summary>
        /// <param name="strDateTime"></param>
        /// <param name="bytes"></param>
        /// <param name="bIsSync"></param>
        /// <param name="intIsSyncing"></param>
        /// <returns></returns>
        public bool InsertData_Config(string strDateTime, byte[] bytes, bool bIsSync, int intIsSyncing)
        {
            return insertAcc.SveDate_Config(strDateTime, bytes, bIsSync, intIsSyncing);
        }

        #region [ 接口: 向原始表(OrgData)中插入数据 ]

        /// <summary>
        /// 向原始表(OrgData)中插入数据
        /// </summary>
        /// <param name="dt">时间</param>
        /// <param name="dataStream">数据流</param>
        /// <param name="bIsSync">是否同步</param>
        /// <param name="intIsSyncing">是否同步中</param>
        /// <returns>操作成功返回True</returns>
        public bool InsertData_OrgData( DateTime dt, byte[] dataStream, bool bIsSync, int intIsSyncing)
        {
            //OleDbConnection dbConn = (OleDbConnection)insertAcc.GetConnectionByTime(dt);     // 获取有效的连接

            return insertAcc.SaveData_OrgData( dt, dataStream, bIsSync, intIsSyncing); // 保存数据至数据库
        }

        // <summary>
        /// 向原始表(OrgData)中插入数据
        /// </summary>
        /// <param name="strDatetime">时间</param>
        /// <param name="dataStream">数据流</param>
        /// <param name="bIsSync">是否同步</param>
        /// <param name="intIsSyncing">是否同步中</param>
        /// <returns>操作成功返回True</returns>
        public bool InsertData_OrgData( string strDatetime, byte[] dataStream, bool bIsSync, int intIsSyncing)
        {
            //OleDbConnection dbConn = (OleDbConnection)insertAcc.GetConnectionByTime(dt);     // 获取有效的连接

            return insertAcc.SaveData_OrgData( strDatetime, dataStream, bIsSync, intIsSyncing); // 保存数据至数据库
        }

        #endregion

        #region [ 接口: 向发送表(NewData)中插入数据 ]

        /// <summary>
        /// 向发送表(NewData)中插入数据
        /// </summary>
        /// <param name="strCreateInfo">时间字符串</param>
        /// <param name="dataStream">数据流</param>
        /// <param name="bIsSend">是否同步</param>
        /// <param name="bIsSending">是否同步中</param>
        /// <param name="iSaveState">存储状态</param>
        /// <returns>操作成功返回True</returns>
        public bool InsertData_NewData( string strCreateInfo, byte[] dataStream, bool bIsSend, bool bIsSending, int iSaveState)
        {
            //将时间字符串转换成DateTime
            //string newTime = strCreateInfo.Substring(0, 4) + "." + strCreateInfo.Substring(4, 2) + "." +
            //                 strCreateInfo.Substring(6, 2);
            //DateTime dt = Convert.ToDateTime(newTime);

            //OleDbConnection dbConn = null;//(OleDbConnection)insertAcc.GetConnectionByTime(dt);     // 获取有效的连接

            return insertAcc.SaveData_NewData(strCreateInfo, dataStream, bIsSend, bIsSending, iSaveState); // 保存数据至数据库
        }

        #endregion

        /*
        *   查询数据 
        */

        #region [方法：配置表中是否存在"同步中（IsSyncing >= 0） 的记录"]
        /// <summary>
        /// 获取配置表中是否存在"同步中（IsSyncing >= 0） 的记录
        /// </summary>
        /// <param name="lastFindDate"></param>
        /// <param name="strTimeInfo"></param>
        /// <param name="byteCommands"></param>
        /// <param name="iIsSyncing"></param>
        /// <returns></returns>
        public bool IfExistConfigData_IsSyncing(DateTime lastFindDate, out string strTimeInfo, out byte[] byteCommands, out int iIsSyncing)
        {
            DataTable dt = selectAcc.DataSelectInAllMDB(" where IsSyncing >= 0 ", lastFindDate);
            return selectAcc.GetData(dt, out strTimeInfo,out byteCommands,out iIsSyncing);
        }
        #endregion

        #region [ 接口: 是否存在“同步中（IsSyncing >= 0）”的记录 ]

        /// <summary>
        /// 是否存在“同步中（IsSyncing > 0）”的记录
        /// </summary>
        /// <param name="lastFindDate">最后一次查找时间</param>
        /// <param name="strTimeInfo">创建信息</param>
        /// <param name="byteCommands">命令</param>
        /// <param name="iIsSyncing">同步中状态</param>
        /// <returns>存在返回true</returns>
        public bool IFExistData_IsSyncing(DateTime lastFindDate,out string strTimeInfo, out byte[] byteCommands, out int iIsSyncing)
        {
            //查询数据
            DataTable dt = selectAcc.DataSelectInAllMDB(2, " where IsSyncing >= 0 ", lastFindDate);

            //提取相应的字段，返回
            return selectAcc.GetData(dt, out strTimeInfo, out byteCommands, out iIsSyncing);
        }

        #endregion

        #region [ 接口: 是否存在“已同步（IsSync = False）”的记录]     接口合并

        /// <summary>
        /// 是否存在“已同步（IsSync = False）”的记录
        /// </summary>
        /// <param name="lastFindDate">最后一次查找时间</param>
        /// <returns>存在返回True，不存在返回False</returns>
        public bool IFExistDataInAllMDB_IsSync(DateTime lastFindDate)
        {
            //查找记录
            DataTable dt = selectAcc.DataSelectInAllMDB(3, " where IsSync = false", lastFindDate);

            if (dt != null)
            {
                //返回记录的条数是否大于零
                return dt.Rows.Count > 0;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否存在“已同步（IsSync = False）”的记录
        /// </summary>
        /// <param name="lastFindDate">最后一次查找时间</param>
        /// <returns>存在返回True，不存在返回False</returns>
        public bool IFExistDataInAllMDB_IsSync(DateTime lastFindDate,out string strTimeInfo,out byte [] byteDatas)
        {
            //查找记录
            DataTable dt = selectAcc.DataSelectInAllMDB(3, " where IsSync = false", lastFindDate);

            //提取相应的字段信息
            return selectAcc.GetData(dt, out strTimeInfo, out byteDatas);
        }

        #endregion 

        #region [ 接口: 按时间字符串信息查询OrgData表中记录 ]

        /// <summary>
        /// 按时间字符串信息查询OrgData表中记录
        /// </summary>
        /// <param name="strTime">时间字符串</param>
        /// <returns>返回记录集，查询不成功返回空表</returns>
        public bool DataSelectInAllMDB_CreateInfo(string strTime)
        {
            //查找数据库名和表名
            //string[] name = accImp.GetInforFromString(databaseType, strTime);
            string[] name = accImp.GetInforFromString(true, strTime);

            //command命令
            string strCommand = "select * from " + name[1] +  " where CreateInfo = '" + strTime + "' ";

            //创建连接
            //OleDbConnection dbConn = accImp.SetConnect(name[0]);

            //查询数据
            DataTable dataTable = selectAcc.DataSelete(strCommand,name[0]);

            //返回记录
            return dataTable.Rows.Count>0;
        }

        #endregion

        #region [ 接口: 是否存在“IsSend = false&SaveState = 0”的记录 ]

        /// <summary>
        /// 是否存在“IsSend = false且SaveState = 0”的记录
        /// </summary>
        /// <param name="lastFindDate">最后一次查找时间</param>
        /// <param name="strTimeInfo">创建信息</param>
        /// <param name="byteCommands">命令</param>
        /// <returns>存在返回True，不存在返回False</returns>
        public bool IFExistDataInAllMDB_IsSend_SaveState(DateTime lastFindDate, out string strTimeInfo, out byte[] byteCommands)
        {
            //查询数据（表中未存储未发送的数据(IsSend = false且SaveState = 0)）
            DataTable dt = selectAcc.DataSelectInAllMDB(5, " where IsSend = false and SaveState = 0 order by id", lastFindDate);

            //提取相应的字段信息
            return selectAcc.GetData(dt, out strTimeInfo, out byteCommands);
        }

        #endregion

        #region [ 接口: 是否存在“IsSend = false”的记录 ]

        /// <summary>
        /// 是否存在“IsSend = false”的记录
        /// </summary>
        /// <param name="lastFindDate">最后一次查找时间</param>
        /// <param name="strTimeInfo">创建信息</param>
        /// <param name="byteCommands">命令</param>
        /// <returns>存在返回True，不存在返回False</returns>
        public bool IFExistDataInAllMDB_IsSend(DateTime lastFindDate,out string strTimeInfo, out byte[] byteCommands)
        {
            DataTable dt = selectAcc.DataSelectInAllMDB(5, " where IsSend = false order by id", lastFindDate);
            //提取相应的字段信息
            return selectAcc.GetData(dt, out strTimeInfo, out byteCommands);
        }

        #endregion

        /*
         * 更改数据
         */

        #region [方法：更改config表中的数据]

        /// <summary>
        /// 更改OrgData表中的数据（提供时间信息字符串）
        /// </summary>
        /// <param name="strDateTime">表示时间的字符串，如：20080215161656718</param>
        /// <param name="bIsSync">已同步</param>
        /// <param name="iIsSyncing">同步中的状态</param>
        /// <returns>操作成功返回True</returns>
        public bool UpdataTable_Config(string strDateTime, bool bIsSync, int iIsSyncing)
        {
            string[] name = accImp.GetInforFromString(strDateTime);
            //Command命令
            strSQL = " UpDate " + name[1] +
                     " SET IsSync=" + bIsSync + ",IsSyncing=" + iIsSyncing +
                     " WHERE CreateInfo='" + strDateTime + "'";

            //执行命令
            int intCounts = 0;
            while (!updateAcc.ExcuteCommand(strSQL,"config\\"+ name[0]))
            {
                if (intCounts >= 10)
                {
                    //写入错误日志
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020014, "", "[AccessInterface:UpDataTable_ConfigData]", "更新五次都未成功，该记录的主键（创建时间）" + strDateTime + "，数据被抛弃，执行的Sql语句为：" + strSQL);
                    }
                    return false;
                }
                intCounts++;
            }
            return true;
        }

        /// <summary>
        /// 更改config表中的数据
        /// </summary>
        /// <param name="strDateTime"></param>
        /// <param name="IsSend"></param>
        /// <param name="bIsSending"></param>
        /// <param name="iSaveState"></param>
        /// <returns></returns>
        public bool UpdataTable_Config(string strDateTime, bool IsSend, bool bIsSending, int iSaveState)
        {
            //Command命令
            strSQL = " Set IsSend=" + IsSend + ",IsSending=" + bIsSending + ",SaveState=" + iSaveState;
            return UpdataTable_Config(strSQL, strDateTime);
        }
        /// <summary>
        /// 更改config表中的数据
        /// </summary>
        /// <param name="strDateTime"></param>
        /// <param name="iSaveState"></param>
        /// <returns></returns>
        public bool UpdataTable_Config(string strDateTime, int iSaveState)
        {
            //Command命令
            strSQL = " SET SaveState=" + iSaveState;
            return UpdataTable_Config(strSQL, strDateTime);
        }

        /// <summary>
        /// 更改config表中的数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="strDateTime"></param>
        /// <returns></returns>
        private bool UpdataTable_Config(string strSql, string strDateTime)
        {
            string[] name = accImp.GetInforFromString(strDateTime);
            strSQL = " UpDate " + name[1] + strSql + " WHERE CreateInfo='" + strDateTime + "'";
            int intCounts = 0;
            while (!updateAcc.ExcuteCommand(strSQL, name[0]))
            {
                if (intCounts >= 10)
                {
                    //写入错误日志
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020014, "", "[AccessInterface:UpDataTable_Config]", "更新十次都未成功，该记录的主键（创建时间）" + strDateTime + "，数据被抛弃，执行的Sql语句为：" + strSQL);
                    }
                    return false;
                }
                intCounts++;
                Thread.Sleep(10);
            }
            return true;
        }
        #endregion

        #region [ 接口: 更改NewData表中的数据（提供时间信息字符串） ]

        /// <summary>
        /// 更改NewData表中的数据（提供时间信息字符串）
        /// </summary>
        /// <param name="strDateTime">表示时间的字符串，如：20080215161656718</param>
        /// <param name="IsSend">已发送</param>
        /// <param name="bIsSending">发送中</param>
        /// <param name="iSaveState">存储标志位</param>
        /// <returns>成功返回True</returns>
        public bool UpDataTable_NewData(string strDateTime, bool IsSend, bool bIsSending, int iSaveState)
        {
            //Command命令
            strSQL = " Set IsSend=" + IsSend + ",IsSending=" + bIsSending + ",SaveState=" + iSaveState;

            return UpDataTable_NewData(strSQL, strDateTime);
        }

        /// <summary>
        /// 更改NewData表中的数据（提供时间信息字符串）
        /// </summary>
        /// <param name="strDateTime">表示时间的字符串，如：20080215161656718</param>
        /// <param name="iSaveState">存储标志位</param>
        /// <returns>成功返回True</returns>
        public bool UpDataTable_NewData(string strDateTime, int iSaveState)
        {
            //Command命令
            strSQL = " SET SaveState=" + iSaveState;

            return UpDataTable_NewData( strSQL, strDateTime);
        }

        /// <summary>
        /// 更改NewData表中的数据（提供时间信息字符串）
        /// </summary>
        /// <param name="strDateTime">表示时间的字符串，如：20080215161656718</param>
        /// <param name="IsSend">已发送</param>
        /// <param name="bIsSending">发送中</param>
        /// <returns>成功返回True</returns>
        public bool UpDataTable_NewData(string strDateTime, bool IsSend, bool bIsSending)
        {
            strSQL = " SET IsSend=" + IsSend + ",IsSending=" + bIsSending;

            return UpDataTable_NewData( strSQL, strDateTime);
        }

        /// <summary>
        /// 更改NewData表中的数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="strDateTime"></param>
        /// <returns></returns>
        private bool UpDataTable_NewData(string strSql, string strDateTime)
        {
            //string[] name = accImp.GetInforFromString(databaseType, strDateTime);
            string[] name = accImp.GetInforFromString(false, strDateTime);

            strSQL = " UpDate " + name[1] + strSql + " WHERE CreateInfo='" + strDateTime + "'";

            //创建连接
            //dbConn = accImp.SetConnect(name[0]);
            //OleDbConnection dbConn = null;
            //执行命令
            int intCounts = 0;
            while (!updateAcc.ExcuteCommand(strSQL,name[0]))
            {
                if (intCounts >= 10)
                {
                    //写入错误日志
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020014, "", "[AccessInterface:UpDataTable_NewData]", "更新十次都未成功，该记录的主键（创建时间）" + strDateTime + "，数据被抛弃，执行的Sql语句为：" + strSQL);
                    }
                    return false;
                }
                intCounts++;
                Thread.Sleep(10);
            }
            return true;
        }

        #endregion

        #region [ 接口: NewData表中存在IsSending = True的记录时，置为false ]

        /// <summary>
        /// NewData表中存在IsSending = True的记录时，置为false
        /// </summary>
        /// <returns>更改成功返回true，没有记录也返回true，更改失败返回False</returns>
        public bool UpDataTable_NewData_IsSending()
        {
            //所有的数据库名称
            string[] strMDBNames = accImp.FindAllMDBOfFile();
            foreach (string strMDBName in strMDBNames)
            {
                //查找数据库中的所有表名
                string[] strTableNames = accImp.GetTableNameBase(strMDBName);
                foreach (string strTableName in strTableNames)
                {
                    //如果是NewData表，进行更改数据
                    if (strTableName.IndexOf("NewData") != -1)
                    {
                        //SQL语句
                        strSQL = "UPDATE " + strTableName + " SET  IsSending = false  where IsSending = true ";
                        //数据库连接
                        //dbConn = accImp.SetConnect(strMDBName.Substring(strMDBName.LastIndexOf("\\") + 1));
                        //OleDbConnection dbConn = null;
                        //执行失败返回False
                        int intCounts = 0;
                        while (!updateAcc.ExcuteCommand(strSQL, strMDBName.Substring(strMDBName.LastIndexOf("\\") + 1)))
                        {
                            if (intCounts >= 10)
                            {
                                //写入错误日志
                                if (ErrorMessage != null)
                                {
                                    ErrorMessage(6020014, "", "[AccessInterface:UpDataTable_NewData_IsSending]", "更新五次都未成功，数据被抛弃，执行的Sql语句为：" + strSQL);
                                }
                                return false;
                            }
                            intCounts++;
                        }
                    }
                }
            }
            return true;
        }

        #endregion

        #region [ 接口: 更改OrgData表中的数据 ]

        /// <summary>
        /// 更改OrgData表中的数据（提供时间信息字符串）
        /// </summary>
        /// <param name="strDateTime">表示时间的字符串，如：20080215161656718</param>
        /// <param name="bIsSync">已同步</param>
        /// <param name="iIsSyncing">同步中的状态</param>
        /// <returns>操作成功返回True</returns>
        public bool UpDataTable_OrgData( string strDateTime, bool bIsSync, int iIsSyncing)
        {
            //string[] name = accImp.GetInforFromString(databaseType, strDateTime);
            string[] name = accImp.GetInforFromString(true, strDateTime);
            //Command命令
            strSQL = " UpDate " + name[1] +
                     " SET IsSync=" + bIsSync + ",IsSyncing=" + iIsSyncing +
                     " WHERE CreateInfo='" + strDateTime + "'";
            //创建连接
            //dbConn = accImp.SetConnect(name[0]);
            //OleDbConnection dbConn = null;
            //执行命令
            int intCounts = 0;
            while (!updateAcc.ExcuteCommand(strSQL, name[0]))
            {
                if (intCounts >= 10)
                {
                    //写入错误日志
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020014, "", "[AccessInterface:UpDataTable_OrgData]", "更新五次都未成功，该记录的主键（创建时间）" + strDateTime + "，数据被抛弃，执行的Sql语句为：" + strSQL);
                    }
                    return false;
                }
                intCounts++;
            }
            return true;
        }

        #endregion

        #region [ 接口:  NewData表中所有未发送的数据的存储标识置为0 ]

        /// <summary>
        /// NewData表中所有未发送的数据的存储标识置为0
        /// </summary>
        /// <returns></returns>
        public bool UpData_NewData_SaveState()
        {
            //所有的数据库名称
            string[] strMDBNames = accImp.FindAllMDBOfFile();
            foreach (string strMDBName in strMDBNames)
            {
                //查找数据库中的所有表名
                string[] strTableNames = accImp.GetTableNameBase(strMDBName);
                foreach (string strTableName in strTableNames)
                {
                    //如果是NewData表，进行更改数据
                    if (strTableName.IndexOf("NewData") != -1)
                    {
                        //SQL语句
                        strSQL = "UPDATE " + strTableName + " SET SaveState = 0 where IsSend = false and SaveState <> 0";
                        //数据库连接
                        //dbConn = accImp.SetConnect(strMDBName.Substring(strMDBName.LastIndexOf("\\") + 1));
                        //OleDbConnection dbConn = null;
                        //执行失败返回False
                        int intCounts = 0;
                        while (!updateAcc.ExcuteCommand( strSQL, strMDBName.Substring(strMDBName.LastIndexOf("\\") + 1)))
                        {
                            if (intCounts >= 10)
                            {
                                //写入错误日志
                                if (ErrorMessage != null)
                                {
                                    ErrorMessage(6020014, "", "[AccessInterface:UpData_NewData_SaveState]", "更新五次都未成功，数据被抛弃，执行的Sql语句为：" + strSQL);
                                }
                                return false;
                            }
                            intCounts++;
                        }
                    }
                }
            }
            return true;
        }

        #endregion

        /*
         * 关闭数据库连接
         */

        #region [ 接口:关闭数据库的连接 ]

        /// <summary>
        ///  关闭数据库的连接
        /// </summary>
        public bool CloeseConnect()
        {
            try
            {
                //关闭数据库插入数据的连接
                insertAcc.CloeseInsertConnect();
                //if (dbConn != null)
                //{
                //    if (dbConn.State == ConnectionState.Open)
                //    {
                //        dbConn.Close();
                //    }
                //}
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    _ErrorMessage(6020010, ex.StackTrace, ex.Source, ex.Message);
                }
                return false;
            }
            return true;
        }

        #endregion


        /*
         * 易晓岚 DataView 使用
         */

        #region  [ 接口: 已知一个数据库名称，返回一个表名数组 （易晓岚） ]

        /// <summary>
        /// 已知一个数据库名称，返回一个表名数组
        /// </summary>
        /// <param name="strMDBName">数据库名称，例如："2008-1-25.mdb"</param>
        /// <returns>表名数组,查找失败返回空</returns>
        public string[] GetTableName(string strMDBName)
        {
            //获取数据库路径
            string strDBPath = Application.StartupPath + @"\AccessDB\" + strMDBName;

            //查询数据库
            string[] strTableNames = accImp.GetTableNameBase(strDBPath);

            //返回数据库
            return strTableNames;
        }

        #endregion

        #region  [ 接口: 已知数据库名称和表名，返回表中的数据 （易晓岚） ]

        /// <summary>
        /// 已知数据库名称和表名，返回表中的数据
        /// </summary>
        /// <param name="strMDBName">数据库名称,如"2008-1-30.mdb"</param>
        /// <param name="strTableName">表名，如"NewData09"</param>
        /// <returns>数据表</returns>
        public DataTable DataSelectAll(string strMDBName, string strTableName)
        {
            //Command命令
            string strCommand = " select * from " + strTableName;
            //创建数据库连接
            //OleDbConnection dbConn = accImp.SetConnect(strMDBName);
            //查询数据
            return selectAcc.DataSelete(strCommand, strMDBName);
        }

        #endregion

    }
}