using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Threading;

namespace KJ128A.DataSave
{
    /// <summary>
    /// 查询Access数据库的相关操作
    /// </summary>
    public class AccessSelect
    {
        #region [ 属性 ]

        private AccessBase accImp = new AccessBase();

        //public static OleDbConnection dbcon = null;
        
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

        #region [构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        public AccessSelect()
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

        /*
         * 外部调用
         */      

        #region [ 方法: 按条件查询 ]

        /// <summary>
        /// 查询Access数据库
        /// </summary>
        /// <param name="strCommand">命令</param>
        /// <param name="name0">连接字符串</param>
        /// <returns>数据集</returns>
        public DataTable DataSelete(string strCommand, string name0)
        {
            DataTable dtSelect = new DataTable();
            OleDbConnection connAcc = null;
            OleDbDataAdapter myDA = null;
            try
            {
                connAcc = DAO.GetConn(name0);
                myDA = new OleDbDataAdapter();
                myDA.SelectCommand = new OleDbCommand(strCommand, connAcc);
                myDA.Fill(dtSelect);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("找不到输出表") != -1)
                {
                    if (ex.Message.IndexOf("NewData") != -1)
                    {
                        //插入New表
                        accImp.CreateNewTable(name0, ex.Message.Substring(ex.Message.IndexOf("'") + 1, 9));
                    }
                    else if (ex.Message.IndexOf("OrgData") != -1)
                    {
                        //插入Org表
                        accImp.CreateOrgTable(name0, ex.Message.Substring(ex.Message.IndexOf("'") + 1, 9));
                    }
                    else if (ex.Message.IndexOf("ConfigData") != -1)
                    {
                        //插入Config表
                        accImp.CreateConfigTable(name0, ex.Message.Substring(ex.Message.IndexOf("'") + 1, 12));
                    }
                }
                else if (ex.Message.IndexOf("操作必须使用一个可更新的查询") != -1)
                {
                    try
                    {
                        accImp.CancelFileReadOnly(connAcc.DataSource);
                    }
                    catch { }
                }
                else if (ex.Message.IndexOf("找不到文件") != -1)
                {
                    try
                    {
                        accImp.CopyMDB(connAcc.DataSource);
                    }
                    catch { }
                }
                else if (ex.Message.IndexOf("当前被锁定") != -1)
                {
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020006, ex.StackTrace, "[InsertAccess:InsertData]", ex.Message + Thread.CurrentThread.Name);
                    }
                    Thread.Sleep(100);
                }
                else if (ex.Message.IndexOf("由于您和其他用户试图同时改变同一数据") != -1)
                {
                    if (connAcc.State != ConnectionState.Closed)
                    {
                        connAcc.Close();
                        connAcc.Dispose();
                        connAcc = null;
                    }
                    try
                    {
                        string strfilenameTemp = name0.Replace(".mdb", ".ldb");
                        if (File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + strfilenameTemp))
                        {
                            File.Delete(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + strfilenameTemp);
                        }
                        File.Delete(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + name0);
                    }
                    catch { }
                    Thread.Sleep(100);
                }
                else if (ex.Message.IndexOf("不可识别的数据库格式") != -1)
                {
                    //if (ErrorMessage != null)
                    //{
                    //    ErrorMessage(6020006, ex.StackTrace, "[InsertAccess:InsertData]", ex.Message + Thread.CurrentThread.Name);
                    //}
                    if (connAcc.State != ConnectionState.Closed)
                    {
                        connAcc.Close();
                        connAcc.Dispose();
                        connAcc = null;
                    }
                    try
                    {
                        string strfilenameTemp = name0.Replace(".mdb", ".ldb");
                        if (File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + strfilenameTemp))
                        {
                            File.Delete(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + strfilenameTemp);
                        }
                        File.Delete(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + name0);
                    }
                    catch { }
                    //catch (Exception ee)
                    //{
                    //    string s = ee.Message;
                    //}
                    Thread.Sleep(100);
                }

                if (ErrorMessage != null)
                {
                    ErrorMessage(6020011, ex.StackTrace, "[SelectAccess:DataSelete]", ex.Message);
                }
            }
            finally
            {
                if (myDA != null)
                {
                    myDA.Dispose();
                    myDA = null;
                }
                if (connAcc != null)
                {
                    connAcc.Dispose();
                    connAcc = null;
                }
            }

            return dtSelect;
        }

        #endregion

        #region [ 方法: 提在所有数据库中查找符合相应条件的记录 ]
        /// <summary>
        /// 提在所有数据库中查找符合相应条件的记录
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="lastFindDate">最后一次查询的时间</param>
        /// <returns>返回记录集</returns>
        public DataTable DataSelectInAllMDB(string strWhere, DateTime lastFindDate)
        {
            DataTable dtSelect = new DataTable();
            string strSelect = "Select *";
            string strNameComp = "ConfigData";
            //查找到所有config access数据库的名称
            string[] strMDBName = accImp.FindAllMDBOfFile(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\config");
            //查询数据
            dtSelect = SelectFirstData1(strMDBName, strNameComp, strSelect, strWhere, lastFindDate);

            return dtSelect;
        }
        /// <summary>
        /// 提在所有数据库中查找符合相应条件的记录
        /// </summary>
        /// <param name="flag">1，NewData表中是否存在“发送中”数据；2，OrgData表中是否存在“同步中”数据；3，OrgData表中是否存在“已同步”为False的数据。</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="lastFindDate">最后一次查询的时间</param>
        /// <returns>返回数据集</returns>
        public DataTable DataSelectInAllMDB(int flag, string strWhere,DateTime lastFindDate)
        {
            DataTable dtSelect = new DataTable();
            string strSelect = String.Empty;    //存放查询的字段，如 “Select *”
            string strNameComp = String.Empty;  //用于比较是New表还是“Org”表
            switch (flag)
            {
                case 1:
                case 4:
                    strNameComp = "NewData";
                    strSelect = "Select *";
                    break;
                case 2:
                case 3:
                    strNameComp = "OrgData";
                    strSelect = "Select *";
                    break;
                case 5:
                    strNameComp = "NewData";
                    strSelect = "Select top 1 *";
                    break;
                default:
                    break;
            }
            //查找所有Access数据库的名称
            string[] strMDBName = accImp.FindAllMDBOfFile();
            //查询数据
            dtSelect = SelectFirstData(strMDBName, strNameComp, strSelect, strWhere, lastFindDate);
           
            return dtSelect;
        }

        #endregion

        #region [ 方法: 提取表中相应字段 ]

        /// <summary>
        /// 提取表中相应字段
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="strTimeInfo">创建信息</param>
        /// <param name="byteCommands">命令</param>
        /// <param name="iIsSyncing">同步中状态</param>
        /// <returns>存在返回true</returns>
        public bool GetData(DataTable dt, out string strTimeInfo, out byte[] byteCommands, out int iIsSyncing)
        {
            bool falg = true;
            if (dt !=null && dt.Rows.Count > 0)
            {
                strTimeInfo = dt.Rows[0]["CreateInfo"].ToString();
                if (dt.Rows[0]["CmdInfo"] != null)
                {
                    try
                    {
                        byteCommands = (byte[])dt.Rows[0]["CmdInfo"];
                    }
                    catch 
                    {
                        byteCommands = new byte[1];
                    }
                }
                else
                {
                    byteCommands = new byte[1];
                }
                iIsSyncing = (int)dt.Rows[0]["IsSyncing"];
            }
            else
            {
                strTimeInfo = String.Empty;
                byteCommands = new byte[1];
                iIsSyncing = 0;
                falg = false;
            }
            if (dt != null)
            {
                dt.Dispose();
                dt = null;
            }
            return falg;
        }

        /// <summary>
        /// 提取表中相应字段
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="strTimeInfo">创建信息</param>
        /// <param name="byteCommands">命令</param>
        /// <returns></returns>
        public bool GetData(DataTable dt, out string strTimeInfo, out byte[] byteCommands)
        {
            bool falg = true;
            if (dt != null && dt.Rows.Count > 0)
            {
                strTimeInfo = dt.Rows[0]["CreateInfo"].ToString();
                if (dt.Rows[0]["CmdInfo"] != null)
                {
                    try
                    {
                        byteCommands = (byte[])dt.Rows[0]["CmdInfo"];
                    }
                    catch
                    {
                        byteCommands = new byte[1];
                    }
                }
                else
                {
                    byteCommands = new byte[1];
                }
            }
            else
            {
                strTimeInfo = String.Empty;
                byteCommands = new byte[1];
                falg = false;
            }
            if (dt != null)
            {
                dt.Dispose();
                dt = null;
            }
            return falg;
        }

        #endregion
        /*
         * 内部调用
         */

        #region [ 方法: 在所有数据库中查找符合条件的第一条记录 ]
        /// <summary>
        /// 在所有数据库中查找符合条件的第一条记录
        /// </summary>
        /// <param name="strMDBNames">数据库名称数组</param>
        /// <param name="strTable">查询Org表传入“OrgData”，查询New表传入“NewData”</param>
        /// <param name="strSelect">查询的信息列表，如“Select top 1 *”</param>
        /// <param name="strWhere">查询条件，如“where 字段名 = 值”</param>
        /// <param name="lastFindData">最后一次查找时间</param>
        /// <returns>返回查找到的第一条数据</returns>
        private DataTable SelectFirstData1(string[] strMDBNames, string strTable, string strSelect, string strWhere, DateTime lastFindDate)
        {
            DataTable dtSelect = null;
            DateTime accessDate;
            if (strMDBNames != null && strMDBNames.Length > 0)
            {
                int len = strMDBNames.Length;
                for (int i = 0; i <= len - 1; i++)
                {
                    #region [获取ACCESS文件的时间]
                    try
                    {
                        accessDate = DateTime.Parse(strMDBNames[i].Substring(strMDBNames[i].LastIndexOf("\\") + 7).Replace(".mdb", ""));
                    }
                    catch { return null; }
                    #endregion [获取ACCESS文件的时间]

                    //获取得到的access文件的日期部分和最后一次读取文件的日期部分不符，则执行下步
                    if (accessDate.Date >= lastFindDate.Date)
                    {
                        //查找所有表
                        string[] strTableName = accImp.GetTableNameBase(strMDBNames[i]);
                        if (strTableName != null && strTableName.Length > 0)
                        {
                            for (int j = 0; j <= strTableName.Length - 1; j++)
                            {
                                if (strTableName[j].IndexOf(strTable) != -1)
                                {
                                    //获取表的时间
                                    int tableHour = int.Parse(strTableName[j].Replace(strTable, ""), System.Globalization.NumberStyles.Any);
                                    if (accessDate.Date > lastFindDate.Date || tableHour >= lastFindDate.Hour)
                                    {
                                        string strCommand = strSelect + " from " + strTableName[j] + strWhere;
                                        //OleDbConnection dbcon = accImp.SetConnect(strMDBNames[i].Substring(strMDBNames[i].LastIndexOf("\\") + 1));
                                        dtSelect = DataSelete(strCommand,"config\\"+ strMDBNames[i].Substring(strMDBNames[i].LastIndexOf("\\") + 1));
                                        if (dtSelect.Rows.Count > 0)
                                        {
                                            return dtSelect;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return dtSelect;
        }
        /// <summary>
        /// 在所有数据库中查找符合条件的第一条记录
        /// </summary>
        /// <param name="strMDBNames">数据库名称数组</param>
        /// <param name="strTable">查询Org表传入“OrgData”，查询New表传入“NewData”</param>
        /// <param name="strSelect">查询的信息列表，如“Select top 1 *”</param>
        /// <param name="strWhere">查询条件，如“where 字段名 = 值”</param>
        /// <param name="lastFindData">最后一次查找时间</param>
        /// <returns>返回查找到的第一条数据</returns>
        private DataTable SelectFirstData(string[] strMDBNames, string strTable, string strSelect, string strWhere,DateTime lastFindDate)
        {
            DataTable dtSelect = null;
            DateTime accessDate;
            if (strMDBNames != null && strMDBNames.Length > 0)
            {
                int len = strMDBNames.Length;
                for (int i = 0; i <= len - 1; i++)
                {
                    #region [获取ACCESS文件的时间]
                    try
                    {
                        accessDate = DateTime.Parse(strMDBNames[i].Substring(strMDBNames[i].LastIndexOf("\\") + 1).Replace(".mdb", ""));
                    }
                    catch { return null; }
                    #endregion [获取ACCESS文件的时间]

                    //获取得到的access文件的日期部分和最后一次读取文件的日期部分不符，则执行下步
                    if (accessDate.Date >= lastFindDate.Date)
                    {
                        //查找所有表
                        string[] strTableName = accImp.GetTableNameBase(strMDBNames[i]);
                        if (strTableName != null && strTableName.Length > 0)
                        {
                            for (int j = 0; j <= strTableName.Length - 1; j++)
                            {
                                if (strTableName[j].IndexOf(strTable) != -1)
                                {
                                    //获取表的时间
                                    int tableHour = int.Parse(strTableName[j].Replace(strTable, ""), System.Globalization.NumberStyles.Any);
                                    if (accessDate.Date > lastFindDate.Date || tableHour >= lastFindDate.Hour)
                                    { 
                                        string strCommand = strSelect + " from " + strTableName[j] + strWhere;
                                        //OleDbConnection dbcon = accImp.SetConnect(strMDBNames[i].Substring(strMDBNames[i].LastIndexOf("\\") + 1));
                                        dtSelect = DataSelete(strCommand, strMDBNames[i].Substring(strMDBNames[i].LastIndexOf("\\") + 1));
                                        if (dtSelect.Rows.Count > 0)
                                        {
                                            return dtSelect;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return dtSelect;
        }

        #endregion
       
    }
}
