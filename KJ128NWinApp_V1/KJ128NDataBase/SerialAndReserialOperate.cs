using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using KJ128NModel;
using System.Configuration;
using System.Xml;
using System.Data.SqlClient;
using KJ128A.DataSave;
namespace KJ128NDataBase
{
    public class SerialAndReserialOperate
    {

        string strOppent = Application.StartupPath + "\\HostIPConfig.xml";
        #region 对象序列化
        /// <summary>
        /// 对象序列化
        /// </summary>
        /// <param name="obj">传输对象</param>
        /// <returns></returns>
        public byte[] SerialOperate(object obj)
        {
            byte[] ReturnStream;
            string strSerialPath = Application.StartupPath.ToString() + "\\SerialsData.dat";
            try
            {
                Stream stream = new FileStream(strSerialPath, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, obj);
                stream.Close();
                ReturnStream = File.ReadAllBytes(strSerialPath);



                byte[] ArrayHead ={ Convert.ToByte("255"), Convert.ToByte("100") };

                byte[] DestinationArray = new byte[ReturnStream.Length + ArrayHead.Length];

                Array.Copy(ArrayHead, 0, DestinationArray, 0, ArrayHead.Length);
                Array.Copy(ReturnStream, 0, DestinationArray, ArrayHead.Length, ReturnStream.Length);
                
                return DestinationArray;


            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message.ToString());
            }
            finally
            {

            }
            return null;

        }
        #endregion


        #region 反序列化
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="RecieveData">接收到的流</param>
        /// <returns></returns>
        public bool DeserialOperate(byte[] RecieveData, bool bFlag)
        {
            int ComandTime=0;
            ArrayList Arraylist=null;
            string strContent = string.Empty; ;
            byte[] fs1=null;
            int intRows = 0;
            SqlConnection conn = new SqlConnection();
            string strErr = string.Empty;
            SqlParameter[] parameters=null;
            string strsql = string.Empty;
            if (bFlag)
            {
               // strsql = "server=.;database=KJ128N;uid=sa;pwd=sa;Timeout=5";
                strsql = GetConfigValue("ConnectionString").Trim();
            }
            else
            {
               // strsql = "server=.;database=KJ128NBackUp;uid=sa;pwd=sa;Timeout=5";
                strsql = GetConfigValue("ConnectionString").Trim();
            }
            File.WriteAllText(Application.StartupPath + "\\Conn.dw", strsql, Encoding.Default);

            string err = string.Empty;
            err = "";
            int intFlag = 0;
            bool Flag = false;
            string strDeserialPath = Application.StartupPath.ToString() + "\\DesialsData.dat";
            FileStream fs = File.Create(strDeserialPath);
            fs.Write(RecieveData, 2, RecieveData.Length - 2);
            fs.Close();
            fs.Dispose();

            Stream stream = new FileStream(strDeserialPath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();


            SerialModel sbc = (SerialModel)bf.Deserialize(stream);
            stream.Close();
            if (sbc.parameter != null)
            {
                parameters = new SqlParameter[sbc.parameter.Length];
                for (int i = 0; i < sbc.parameter.Length; i++)
                {
                    parameters[i] = new SqlParameter();
                    parameters[i].ParameterName = sbc.parameter[i].ParameterName;
                    parameters[i].SqlDbType = sbc.parameter[i].ParameterType;
                    parameters[i].Size = sbc.parameter[i].intLongth;
                    parameters[i].Value = sbc.parameter[i].objValue;
                }
            }
            if (sbc.ComandTime != 0)
            {
                ComandTime = sbc.ComandTime;
            }
            if (sbc.Arraylist != null)
            {
                Arraylist = sbc.Arraylist;
            }
            if (sbc.fs != null)
            {
                fs1 = sbc.fs;
            }
            if (sbc.strContent != null)
            {
                strContent = sbc.strContent;
            }

            New_DBAcess NDBA;
            New_DbHelperSQL NDH;
            switch (sbc.FuntionName)
            {
                case "ACCESS_ExecuteSql1":
                    NDBA = new New_DBAcess();
                    NDBA.ExecuteSql(sbc.RestoryProcedureName, parameters);
                    break;
                case "ACCESS_ExecuteSql2":
                    NDBA = new New_DBAcess();
                    NDBA.ExecuteSql(sbc.RestoryProcedureName, parameters, out strErr);
                    break;
                case "ACCESS_ExecuteSql3":
                    NDBA = new New_DBAcess();
                    NDBA.ExecuteSql(sbc.RestoryProcedureName, parameters, conn);
                    break;
                case "ACCESS_ExecuteSql4":
                    NDBA = new New_DBAcess();
                    NDBA.ExecuteSql(sbc.strSql, conn);
                    break;
                case "ACCESS_ExecuteSql5":
                    NDBA = new New_DBAcess();
                    NDBA.ExecuteSql(sbc.strSql);
                    break;
                case "ACCESS_ExecuteSql6":
                    NDBA = new New_DBAcess();
                    NDBA.ExistsSql(sbc.strSql);
                    break;
                case "Helper_ExecuteSql1":
                    NDH = new New_DbHelperSQL();
                    NDH.RunProcedureByInt64(sbc.RestoryProcedureName, parameters, out strErr);
                    break;
                case "Helper_ExecuteSql2":
                    NDH = new New_DbHelperSQL();
                    NDH.RunProcedureByInt(sbc.RestoryProcedureName, parameters, out strErr);
                    break;
                case "Helper_ExecuteSql3":
                    NDH = new New_DbHelperSQL();
                    NDH.RunProcedureByInt(sbc.RestoryProcedureName, out strErr);
                    break;
                case "Helper_ExecuteSql4":
                    NDH = new New_DbHelperSQL();
                    NDH.RunProcedureReturnInt(sbc.RestoryProcedureName, parameters, out strErr);
                    break;
                case "Helper_ExecuteSql5":
                    NDH = new New_DbHelperSQL();
                    NDH.ExecuteSql(sbc.strSql);
                    break;
                case "Helper_ExecuteSql6":
                    NDH = new New_DbHelperSQL();
                    NDH.ExecuteSqlByTime(sbc.strSql, ComandTime);
                    break;
                case "Helper_ExecuteSql7":
                    NDH = new New_DbHelperSQL();
                    NDH.ExecuteSqlTran(Arraylist);
                    break;
                case "Helper_ExecuteSql8":
                    NDH = new New_DbHelperSQL();
                    NDH.ExecuteSql(sbc.strSql, sbc.strContent);
                    break;
                case "Helper_ExecuteSql9":
                    NDH = new New_DbHelperSQL();
                    NDH.ExecuteSqlGet(sbc.strSql, sbc.strContent);
                    break;
                case "Helper_ExecuteSql10":
                    NDH = new New_DbHelperSQL();
                    NDH.ExecuteSqlInsertImg(sbc.strSql, fs1);
                    break;
                case "Helper_ExecuteSql11":
                    NDH = new New_DbHelperSQL();
                    NDH.ExecuteSql(sbc.strSql, parameters);
                    break;
                case "Helper_ExecuteSql12":
                    NDH = new New_DbHelperSQL();
                    NDH.RunProcedure(sbc.RestoryProcedureName, parameters, out intRows);
                    break;
                case "Helper_ExecuteSql13":
                    NDH = new New_DbHelperSQL();
                    NDH.RunProcedure(sbc.RestoryProcedureName);
                    break;
                default:
                    break;
            }

            if (intFlag != -1)
            {
                Flag = true;
            }
            else
            {
                Flag = false;
            }

            if (File.Exists(Application.StartupPath + "\\Conn.dw"))
            {
                File.Delete(Application.StartupPath + "\\Conn.dw");
            }
            return Flag;
        }
        #endregion

        #region [ 方法：数据接收函数 ]
        public bool DataReceived(byte[] dataInfo)
        {
            #region 读取主备标志
            bool Flag = GetMainFlag();
            #endregion
            //存储Access是否成功的标志
            bool IsOperateSucceed = false;
            if (dataInfo != null)
            {
                
                //带出的错误
                string strErr = string.Empty;

                //实例化数据保存类
                InterfaceSerialPort DS = new InterfaceSerialPort();

                //日志文件路径
                string FileName = Application.StartupPath.ToString() + "\\LogInterFace.txt";

                //如果日志文件存在，则读取到Access文件后删除
                if (File.Exists(FileName))
                {
                    //DS.DataReceived(File.ReadAllBytes(FileName), Flag);
                    DS.DataReceived(File.ReadAllBytes(FileName));

                    //File.Delete(FileName);

                }

                //创建日志文件，并把数据流写入日志文件当中
                FileStream fs = File.Create(FileName);
                fs.Write(dataInfo, 0, dataInfo.Length);

                fs.Close();

                //存储到数据库中
                //DeserialOperate(dataInfo);

                //如果数据存储成功,则把数据保存到Access中
                //if (bIsSaveComplete)
                //{
                    //IsOperateSucceed = DS.DataReceived(dataInfo, Flag);
                    IsOperateSucceed = DS.DataReceived(dataInfo);
                    if (IsOperateSucceed)
                    {
                        File.Delete(FileName);
                    }
                //}

                DS.Exit();
            }
            return IsOperateSucceed;
        }
        #endregion

        #region 读取主备标志
        private bool GetMainFlag()
        {
            bool Flag = true;
            XmlDocument xmldoc = new XmlDocument();
            try
            {
                xmldoc.Load(strOppent);
            }
            catch (Exception ex)
            {
                //异常处理
            }

            bool IsStartHost = Convert.ToBoolean(xmldoc.SelectSingleNode("//IsStartHost").ChildNodes[0].Value.ToString());

            //判断是否启用主备切换功能
            if (IsStartHost)
            {
                //启用了主备切换功能

                //得到本机是否为主/备机标志
                bool bIsHost = Convert.ToBoolean(xmldoc.SelectSingleNode("//IsHost").ChildNodes[0].Value.ToString());
                //判断本机是否为主机
                if (!bIsHost)
                {
                    Flag = false;

                }
            }
            return Flag;
        }
        #endregion


        #region 【Czlt-2013-05-14 修改配置文件】
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appKey"></param>
        /// <returns></returns>
        public string GetConfigValue(string appKey)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(Application.StartupPath + "\\KJ128NMainRun.exe.config");

                XmlNode xNode;
                XmlElement xElem;
                xNode = xDoc.SelectSingleNode("//appSettings");
                xElem = (XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
                if (xElem != null)
                    return xElem.GetAttribute("value");
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
    
        #endregion
    }
}
