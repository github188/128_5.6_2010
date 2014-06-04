using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using ADOX; //该命名空间包含创建ACCESS的类(方法)--解决方案 ==> 引用 ==> 添加引用 ==> 游览找到.dll
using JRO; //该命名空间包含压缩ACCESS的类(方法)

namespace KJ128A.DataSave
{
    /// <summary>
    /// Access数据基础操作类
    /// </summary>
    public class AccessBase
    {

        #region [ 属性 ]

        /// <summary>
        /// 定义最多保留多少个数据库
        /// </summary>
        private int iAccessMaxSum = 7;

        /// <summary>
        /// 
        /// </summary>
        public  OleDbConnection accessbaseconn = null;

        /// <summary>
        /// 
        /// </summary>
        public  OleDbConnection connAcc = null;
        /// <summary>
        /// 保存Access的目录
        /// </summary>
        private string strAccessPath = System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB";   

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

        /*
         * 数据库操作
         */

        #region [ 方法: 构造Command对象 ]

        /// <summary>
        /// 构造Command对象
        /// </summary>
        /// <param name="strCommand">Command字符串</param>
        /// <param name="dbParams">Command参数</param>
        /// <returns>返回Comand对象</returns>
        public OleDbCommand BuildOleDbCommand(string strCommand, OleDbParameter[] dbParams)
        {
            OleDbCommand command = new OleDbCommand();
            command.CommandText = strCommand;
            foreach (OleDbParameter oleParameter in dbParams)
            {
                command.Parameters.Add(oleParameter);
            }

            return command;
        }

        #endregion

        #region [ 方法:创建插入数据时，数据库的连接 ]

        /// <summary>
        /// 创建数据库连接
        /// </summary>
        /// <param name="strMDBName">数据库名称，例如“2008-1-23.mdb”</param>
        /// <returns></returns>
        public OleDbConnection SetConnect(string strMDBName)
        {
            //string strDBPath = System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + strMDBName;  //数据库路径
            //OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + strDBPath + ";Jet OLEDB:Database Password=shkj;");
            //return con;
            //accessbaseconn = DAO.GetConn(strMDBName);
            //return accessbaseconn;
            return DAO.GetConn(strMDBName);
        }

        #endregion

        #region [方法：创建一张配置表]
        /// <summary>
        /// 创建配置表
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public bool CreateConfigTable(string filename, string strTableName)
        {
            string strCommand = "CREATE TABLE " + strTableName +
                " (id int IDENTITY(1,1) ,CreateInfo varchar(128) PRIMARY KEY CLUSTERED ,CmdLen int,CmdInfo Image,IsSync bit,IsSyncing int)";
            return CreteTableBase(filename, strCommand);
        }
        #endregion

        #region [ 方法: 创建一张原始表 ]

        /// <summary>
        /// 创建原始表
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="strTableName">要创建的表</param>
        /// <returns>返回操作是否成功</returns>
        public bool CreateOrgTable(string filename, string strTableName)
        {
            string strCommand = "CREATE TABLE " + strTableName +
                " (id int IDENTITY(1,1) ,CreateInfo varchar(128) PRIMARY KEY CLUSTERED ,CmdLen int,CmdInfo Image,IsSync bit,IsSyncing int)";
            return CreteTableBase(filename, strCommand);
        }

        #endregion

        #region [ 方法: 创建一张发送表 ]

        /// <summary>
        /// 创建发送表
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="strTableName">要创建的表</param>
        /// <returns>返回操作是否成功</returns>
        public bool CreateNewTable(string filename, string strTableName)
        {
            string strCommand = "CREATE TABLE " + strTableName +
                " (id int IDENTITY(1,1) ,CreateInfo varchar(128)  PRIMARY KEY CLUSTERED ,CmdLen int,CmdInfo Image,IsSend bit,IsSending bit,SaveState int)";
            return CreteTableBase(filename, strCommand);
        }

        #endregion

        #region [ 方法: 向数据库中插入表 ]

        /// <summary>
        /// 向数据库中插入表
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="strCommand">创建命令字符串</param>
        /// <returns>创建成功返回True</returns>
        private bool CreteTableBase(string filename, string strCommand)
        {
            OleDbConnection conn = DAO.GetConn(filename);
            OleDbCommand cmd = new OleDbCommand(strCommand, conn);
            bool falg = true;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6020006, ex.StackTrace, "[AccessImport:CreteTableBase]", ex.Message);
                }
                falg = false;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
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


        #region [方法：压缩修复数据库]
        public string[] Compact()
        {
            string[] strMDBName = FindAllMDBOfFile();
            return strMDBName;
            //for (int i = 0; i < strMDBName.Length; i++)
            //{
            //    Compact(strMDBName[i]);
            //}
        }
        public string[] Compact1()
        {
            string[] strMDBName = FindAllMDBOfFile(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\config");
            return strMDBName;
        }
        ///压缩修复ACCESS数据库,mdbPath为数据库绝对路径    
        public void Compact(string mdbPath)       
        {
            try
            {
                if (File.Exists(mdbPath)) //检查数据库是否已存在           
                {
                    string temp = DateTime.Now.Year.ToString();
                    string temp2 = null;
                    temp += DateTime.Now.Month.ToString();
                    temp += DateTime.Now.Day.ToString();
                    temp += DateTime.Now.Hour.ToString();
                    temp += DateTime.Now.Minute.ToString();
                    temp += DateTime.Now.Second.ToString() + ".bak";
                    temp = mdbPath.Substring(0, mdbPath.LastIndexOf("\\") + 1) + temp;        
                    //定义临时数据库的连接字符串           
                    temp2 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + temp + ";Jet OLEDB:Database Password=shkj;";        
                    //定义目标数据库的连接字符串            
                    string mdbPath2 = null;
                    mdbPath2 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mdbPath + ";Jet OLEDB:Database Password=shkj;";        
                    //创建一个JetEngineClass对象的实例           
                    JRO.JetEngineClass jt = new JRO.JetEngineClass();
                    //使用JetEngineClass对象的CompactDatabase方法压缩修复数据库           
                    jt.CompactDatabase(mdbPath2, temp2);
                    jt = null;
                    //拷贝临时数据库到目标数据库(覆盖)           
                    File.Copy(temp, mdbPath, true);
                    //最后删除临时数据库           
                    File.Delete(temp);
                }
            }
            catch(Exception ex) 
            {
                if (ex.Message.IndexOf("由于您和其他用户试图同时改变同一数据") != -1)
                {
                    try
                    {
                        string strfilenameTemp = mdbPath.Replace(".mdb", ".ldb");
                        if (File.Exists(strfilenameTemp))
                        {
                            File.Delete(strfilenameTemp);
                        }
                        File.Delete(mdbPath);
                    }
                    catch { }
                }
                else if (ex.Message.IndexOf("不可识别的数据库格式") != -1)
                {
                    try
                    {
                        string strfilenameTemp = mdbPath.Replace(".mdb", ".ldb");
                        if (File.Exists(strfilenameTemp))
                        {
                            File.Delete(strfilenameTemp);
                        }
                        File.Delete(mdbPath);
                    }
                    catch { }
                    //catch (Exception ee)
                    //{
                    //    string s = ee.Message;
                    //}
                }
                Thread.Sleep(100);
            }
        }

        #endregion 


        /*
         * 文件操作
         */ 

        #region [ 方法: 取消文件的只读属性 ]

        /// <summary>
        /// 取消文件的只读属性
        /// </summary>
        /// <param name="strPath">文件路径</param>
        public void CancelFileReadOnly(string strPath)
        {
            if (File.Exists(strPath))
            {
                try
                {
                    FileInfo fi = new FileInfo(strPath);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                    {
                        fi.Attributes = FileAttributes.Normal;
                    }
                    fi = null;
                }
                catch (Exception ex)
                {
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020005, ex.StackTrace, "[AccessImport:CancelFileReadOnly]", ex.Message);
                    }
                    return;
                }
            }
            
        }

        #endregion

        #region [ 方法: 当文件夹下的数据库个数大于7的时候，删除数据库 ]

        /// <summary>
        /// 删除数据库
        /// </summary>
        /// <param name="strPath">文件夹名称</param>
        public void DeleteMDBFile(string strPath)
        {
            string[] strFileName = FindAllMDBOfFile(strPath);
            //判断是否要删除数据库
            if (strFileName != null && strFileName.Length > iAccessMaxSum)
            {
                //计算要删除的数据库个数
                int num = strFileName.Length - (iAccessMaxSum);
                //删除数据库
                for (int i = 0; i < num; i++)
                {
                    try
                    {
                        File.Delete(strFileName[i]);
                    }
                    catch { }
                }
            }
        }

        #endregion

        #region [ 方法: 查找知道文件夹下所有数据库的名称集合 ]

        /// <summary>
        /// 查找知道文件夹下所有数据库的名称集合
        /// </summary>
        /// <returns>返回数据库名称</returns>
        public string[] FindAllMDBOfFile()
        {
            string destFileName;
            destFileName = strAccessPath;
            //switch (databaseType)
            //{
            //    case 1://new
            //        destFileName = strAccessPath + @"\new";     //目标文件
            //        break;
            //    case 2://orgback
            //        destFileName = strAccessPath + @"\orgback";     //目标文件
            //        break;
            //    case 3://newback
            //        destFileName = strAccessPath + @"\newback";     //目标文件
            //        break;
            //    default://org
            //        destFileName = strAccessPath + @"\org";     //目标文件
            //        break;
            //}
            return FindAllMDBOfFile(destFileName);
        }

        /// <summary>
        /// 查找知道文件夹下所有数据库的名称集合
        /// </summary>
        /// <param name="strFileName">文件夹名</param>
        /// <returns>返回数据库名称</returns>
        public string[] FindAllMDBOfFile(string strFileName)
        {
            ArrayList alst = new System.Collections.ArrayList();//建立ArrayList对象
            try
            {
                string[] files = Directory.GetFiles(strFileName);//得到文件
                foreach (string file in files)//循环文件
                {
                    string exname = file.Substring(file.LastIndexOf(".") + 1);//得到后缀名
                    if (".mdb".IndexOf(file.Substring(file.LastIndexOf(".") + 1)) > -1)//如果后缀名为.mdb文件
                    {
                        FileInfo fi = new FileInfo(file);//建立FileInfo对象
                        alst.Add(fi.FullName);//把.mdb文件全名加人到FileInfo对象
                        fi = null;
                    }
                    alst.Sort();
                }
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6020004, ex.StackTrace, "[AccessImport:FindAllMDBOfFile]", ex.Message);
                }
                return (string[])alst.ToArray(typeof(string));
            }
            return (string[])alst.ToArray(typeof(string));//把ArrayList转化为string[]
        }

        #endregion

        #region [ 方法: 判断是否生成新的数据库__例外未处理 ]

        /// <summary>
        /// 判断是否生成新的数据库
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns>操作成功返回True</returns>
        public bool CreateMDBFile(DateTime dt)
        {
            for (int i = 0; i < 4; i++)
            {
                string destFileName;
                switch (i)
                {
                    case 1://new
                        destFileName = strAccessPath + @"\new\new" + dt.ToString("yyyy-MM-dd") + ".mdb";     //目标文件
                        break;
                    case 2://orgback
                        destFileName = strAccessPath + @"\orgback\orgback" + dt.ToString("yyyy-MM-dd") + ".mdb";     //目标文件
                        break;
                    case 3://newback
                        destFileName = strAccessPath + @"\newback\newback" + dt.ToString("yyyy-MM-dd") + ".mdb";     //目标文件
                        break;
                    default://org
                        destFileName = strAccessPath + @"\org\org" + dt.ToString("yyyy-MM-dd") + ".mdb";     //目标文件
                        break;
                }
                
            
                //目标文件夹文件夹是否存在
                if (!Directory.Exists(strAccessPath))      
                {
                    Directory.CreateDirectory(strAccessPath);
                }

                //目标文件是否存在
                if (!File.Exists(destFileName))
                {
                    //生成新的数据库
                    CopyMDB(destFileName);
                }
            }
            
            return true;
        }

        #endregion

        #region [ 复制数据库的方式创建数据库 ]

        /// <summary>
        /// 复制数据库的方式创建数据库
        /// </summary>
        /// <param name="destFileName">生成的数据库名“2008-02-12.mdb”</param>
        /// <returns></returns>
        public bool CopyMDB(string destFileName)
        {
            string sourceFileName = System.Windows.Forms.Application.StartupPath.ToString() + @"\Interop.MSAdodcLib.Modle.dll";    //要复制的文件
            //目标文件Interop.MSAdodcLib.Modle.dll是否存在
            if (File.Exists(sourceFileName))
            {
                try
                {
                    //目标文件存在，复制文件
                    File.Copy(sourceFileName, destFileName, true);

                    //取消只读
                    CancelFileReadOnly(destFileName);

                    //文件夹下只允许保存十五天的数据库
                    DeleteMDBFile(strAccessPath);
                }
                catch (Exception ex)
                {
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020002, ex.StackTrace, "[AccessImport:CreateMDBFile]", ex.Message);
                    }
                    return false;
                }
            }
            else
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6020003, "提示", "[AccessImport:CreateMDBFile]", "");
                    return false;
                }
            }
            return true;
        }

         #endregion

        #region [ 方法: 输入表示时间的字符串，返回数据库名和表名 ]
        /// <summary>
        /// 输入表示时间的字符串，返回数据库名和表名
        /// </summary>
        /// <param name="flag">True，表示OrgData表;False，表示NewData表</param>
        /// <param name="strTime">"20080201001711000"</param>
        /// <returns>strName[0]为数据库名称，strName[1]为表名</returns>
        public string[] GetInforFromString(string strTime)
        {
            string[] strName = new string[2];
            string newTime = strTime.Substring(0, 4) + "." + strTime.Substring(4, 2) + "." + strTime.Substring(6, 2) + " " + strTime.Substring(8, 2) + ":" + strTime.Substring(10, 2) + ":" + strTime.Substring(12, 2);

            DateTime dt;
            try
            {
                dt = Convert.ToDateTime(newTime);
            }
            catch
            {
                dt = new DateTime(1999, 1, 1, 0, 0, 0);
            }
            strName[0] = "Config" + dt.ToString("yyyy-MM-dd") + ".mdb";   //存放数据库名称

            strName[1] = "ConfigData" + dt.ToString("HH");

            return strName;
        }


        /// <summary>
        /// 输入表示时间的字符串，返回数据库名和表名
        /// </summary>
        /// <param name="flag">True，表示OrgData表;False，表示NewData表</param>
        /// <param name="strTime">"20080201001711000"</param>
        /// <returns>strName[0]为数据库名称，strName[1]为表名</returns>
        public string[] GetInforFromString(bool flag, string strTime)
        {
            string[] strName = new string[2];
            string newTime = strTime.Substring(0, 4) + "." + strTime.Substring(4, 2) + "." + strTime.Substring(6, 2) + " " + strTime.Substring(8, 2) + ":" + strTime.Substring(10, 2) + ":" + strTime.Substring(12, 2);
            
            DateTime dt;
            try
            {
                dt = Convert.ToDateTime(newTime);
            }
            catch
            {
                dt = new DateTime(1999, 1, 1, 0, 0, 0);
            }
            strName[0] = dt.ToString("yyyy-MM-dd") + ".mdb";   //存放数据库名称
            if (flag)
            {
                strName[1] = "OrgData" + dt.ToString("HH");
            }
            else
            {
                strName[1] = "NewData" + dt.ToString("HH");
            }
            return strName;
        }

        #endregion

        #region  [ 方法: 已知一个数据库名称，返回一个表名数组 ]

        /// <summary>
        /// 已知一个数据库名称，返回一个表名数组
        /// </summary>
        /// <param name="strDBPath">数据库名称，例如："F:\\AccessMDB\\AccessMDB\\bin\\Debug\\AccessDB\\2008-1-25.mdb"</param>
        /// <returns>返回所有表名</returns>
        public string[] GetTableNameBase( string strDBPath)
        {
            string[] strTableName;                      //定义表名数组
            DataTable dtName = GetTableName(strDBPath);  //到数据库中查找表名 
            strTableName = fillData(dtName);              // 将查到的数据填充到表名数组
            dtName = null;
            return strTableName;                        //返回表名数组
        }

        #endregion

        #region [ 方法: 到数据库中查找表名 ]

        /// <summary>
        /// 到数据库中查找表名
        /// </summary>
        /// <param name="strPath">数据库名称，例如："F:\\AccessMDB\\AccessMDB\\bin\\Debug\\AccessDB\\2008-1-25.mdb"</param>
        /// <returns>返回所有表的名称</returns>
        private DataTable GetTableName(string strPath)
        {
            //OleDbConnection connAcc = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + strPath + ";Jet OLEDB:Database Password=shkj;");
            DataTable dtName = new DataTable();

            try
            {
                if (connAcc==null || connAcc.ConnectionString=="")
                {
                    connAcc = DAO.GetConnByPath(strPath);
                }
                if (connAcc.State == ConnectionState.Closed)
                {
                    connAcc.Open();
                }
                dtName = connAcc.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("由于您和其他用户试图同时改变同一数据") != -1)
                {
                    if (connAcc.State != ConnectionState.Closed)
                    {
                        connAcc.Close();
                        connAcc.Dispose();
                        connAcc = null;
                    }
                    try
                    {
                        string strfilenameTemp = strPath.Replace(".mdb", ".ldb");
                        if (File.Exists(strPath))
                        {
                            File.Delete(strPath);
                        }
                        File.Delete(strPath);
                    }
                    catch { }
                }
                else if (ex.Message.IndexOf("不可识别的数据库格式") != -1)
                {
                    //if (ErrorMessage != null)
                    //{
                    //    ErrorMessage(6020001, ex.StackTrace, "[AccessImport:GetTableName]", ex.Message);
                    //}
                    if (connAcc.State != ConnectionState.Closed)
                    {
                        connAcc.Close();
                        connAcc.Dispose();
                        connAcc = null;
                    }
                    try
                    {
                        string strfilenameTemp = strPath.Replace(".mdb", ".ldb");
                        if (File.Exists(strPath))
                        {
                            File.Delete(strPath);
                        }
                        File.Delete(strPath);
                    }
                    catch { }
                }
                else
                {
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020001, ex.StackTrace, "[AccessImport:GetTableName]", ex.Message);
                    }
                }
            }
            finally
            {
                if (connAcc.State != ConnectionState.Closed)
                {
                    connAcc.Close();
                }
                if (connAcc != null)
                {
                    connAcc.Dispose();
                    connAcc = null;
                }
            }
            return dtName;
        }

        #endregion

        #region [ 方法: 将查到的数据填充到表名数组 ]

        /// <summary>
        /// 将查到的数据填充到表名数组
        /// </summary>
        /// <param name="dtName">数据库名称，例如："F:\\AccessMDB\\AccessMDB\\bin\\Debug\\AccessDB\\2008-1-25.mdb"</param>
        /// <returns>返回所有表名</returns>
        private string[] fillData(DataTable dtName)
        {
            string[] strTableNames;

            int drCount = dtName.Rows.Count;
            strTableNames = new string[drCount];
            int index = 0;

            foreach (DataRow dr in dtName.Rows)
            {
                strTableNames.SetValue(dr[2].ToString(), index);
                index++;
            }

            return strTableNames;
        }

        #endregion
    }
}
