using System;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Management;
using System.Collections;
using System.Timers;
using System.Xml;

namespace KJ128A.Controls.Batman
{
    /// <summary>
    /// 串口类
    /// </summary>
    public class Base_SerialPort
    {
        #region【Czlt-2010-11-29 双向通讯】
        #region [ 事件: 时间-定时取消双向通讯 ]

        /// <summary>
        /// 时间-定时取消双向通讯
        /// </summary>
        protected Timer timer_Call = new Timer();

        /// <summary>
        /// 时间控件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void timer_Call_Elapsed(object sender, ElapsedEventArgs e)
        {


        }

        #endregion
        #endregion
        #region [ 参数 ]

        /// <summary>
        /// 数据缓冲区的大小
        /// </summary>
        protected static int iBufferSize = 2048;
        /// <summary>
        /// 错误标志位
        /// </summary>
        private bool flag = false;
        /// <summary>
        /// 发送时间
        /// </summary>
        protected int sendTime = 660;
        #endregion

        #region [ 声明:委托 ] 错误消息事件

        /// <summary>
        /// 错误消息声明
        /// </summary>
        /// <param name="index">索引, 当初始化多个串口时, 用来做串口的初始化标识</param>
        /// <param name="iErrNO">错误编号</param>
        /// <param name="strStackTrace">获取当前异常发生时调用堆栈上的帧的字符串表示形式</param>
        /// <param name="strSource">标识当前哪一段程序出的错误</param>
        /// <param name="strMessage">获取描述当前异常的消息</param>
        public delegate void ErrorMessageEventHandler(int index, int iErrNO, string strStackTrace, string strSource, string strMessage);

        /// <summary>
        /// 错误消息事件
        /// </summary>
        public event ErrorMessageEventHandler ErrorMessage;

        #endregion

        #region [ 属性 ] 串口名称

        /// <summary>
        /// 获取或设置串口名称
        /// </summary>
        public string PortName
        {
            get { return serialPort.PortName; }
            set { serialPort.PortName = value; }
        }

        #endregion

        #region [ 属性 ] 索引

        private int _Index;

        /// <summary>
        /// 索引, 当初始化多个串口时, 用来做串口的初始化标识
        /// </summary>
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        #endregion

        #region [ 属性 ] 间隔时间

        private double _Interval;

        /// <summary>
        /// 获取或设置间隔时间
        /// </summary>
        public double Interval
        {
            get
            {
                _Interval = timer.Interval;
                return _Interval; 
            }
            set 
            {
                timer.Interval = value;
                _Interval = value; 
            }
        }

        #endregion

        #region [ 事件: 时间 ]

        /// <summary>
        /// 串口收发数据的计时器
        /// </summary>
        protected readonly Timer timer = new Timer();

        /// <summary>
        /// 时间控件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void timer_Elapsed(object sender, ElapsedEventArgs e)
        {

        }

        #endregion

        #region [ 构造函数 ]

        /// <summary>
        /// 串行资源端口
        /// </summary>
        protected readonly SerialPort serialPort = new SerialPort();

        /// <summary>
        /// 构造函数
        /// </summary>
        public Base_SerialPort()
        {
            LoadSendTimeFile();
            // 串口参数设置
            serialPort.BaudRate = 1200;
            serialPort.Encoding = Encoding.UTF8;
            serialPort.Parity = Parity.Even;

            // 串口数据抵达事件
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);

            // 时间事件及触发间隔
            timer.Interval = sendTime;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);


            //Czlt-2010-11-29 -双向通讯
            timer_Call.Interval = 1800000;
            timer_Call.Elapsed += new ElapsedEventHandler(timer_Call_Elapsed);
            timer_Call.Enabled = false;
        }

        //public Base_SerialPort(string strPortName)
        //    : this()
        //{

        //}

        #endregion

        #region 【方法：加载发送时间】
        /// <summary>
        /// 加载发送时间文件
        /// </summary>
        private void LoadSendTimeFile()
        {
            //创建
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\SendTime.xml"))
            {
                try
                {
                    FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\SendTime.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
                    sw.WriteLine("<SendTime>");
                    sw.WriteLine("<send>1200</send>");
                    sw.WriteLine("</SendTime>");
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                    fs.Close();
                    fs.Dispose();
                }
                catch { }
            }
            else
            {
                XmlDocument xmldocument = new XmlDocument();
                try
                {
                    //加载
                    xmldocument.Load(Directory.GetCurrentDirectory() + "\\SendTime.xml");
                    XmlNode node = xmldocument.SelectSingleNode("SendTime/send");
                    sendTime = int.Parse(node.InnerText);
                }
                catch
                {
                    sendTime = 1200;
                }
            }
        }
        #endregion

        /*
         * 串口的相关操作
         */

        #region [ 事件:数据抵达 ]

        /// <summary>
        /// 当前缓冲区的指针
        /// </summary>
        protected int iCurLoc = 0;

        /// <summary>
        /// 数据缓冲区
        /// </summary>
        protected byte[] byteBuffer = new byte[iBufferSize];

        /// <summary>
        /// 串口的数据抵达事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (timer.Enabled == true)
            {
                timer.Enabled = false;
            }
            try
            {
                // 接收缓冲区中数据的字节数
                int int_Len = serialPort.BytesToRead;

                // 接收数据
                byte[] bytes = new byte[int_Len];
                serialPort.Read(bytes, 0, int_Len);

                if (RTxtMsgo != null)
                {
                    RTxtMsgo.WriteTxt(bytes, " RX ", true, 0);
                }

                // 缓冲区溢出
                if (iCurLoc + int_Len > iBufferSize)
                {
                    iCurLoc = 0;
                    return;
                }

                // 将数据存入缓冲区
                for (int i = 0; i < int_Len; i++)
                {
                    byteBuffer[iCurLoc + i] = bytes[i];
                }

                bytes = null;

                // 修改当前指针的位置
                iCurLoc += int_Len;
            }
            catch 
            {
                if (timer.Enabled == false)
                {
                    timer.Enabled = true;
                }
            }
            finally
            {
                //if (timer.Enabled == false)
                //{
                //    timer.Enabled = true;
                //}
            }
        }

        #endregion

        #region [ 方法 ] 打开串口

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <returns></returns>
        public bool Open()
        {
            try
            {
                if (!serialPort.IsOpen)
                {
                    serialPort.Open();
                }
                if (flag)
                {
                    ErrorMessage(Index, 0, "", "[Base_SerialPort:Open]", serialPort.PortName + "已重新打开");
                    flag = false;
                }
                return true;
            }
            catch (Exception ex)
            {
                if (!flag)
                {
                    ErrorMessage(Index, 1, ex.StackTrace, "[Base_SerialPort:Open]", ex.Message);
                    flag = true;
                }
                return false;
            }
        }

        #endregion

        #region [ 方法 ] 关闭串口

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <returns></returns>
        public bool Close()
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                flag = false;
                return true;
            }
            catch (Exception ex)
            {
                if (!flag)
                {
                    ErrorMessage(Index, 2, ex.StackTrace, "[Base_SerialPort:Close]", ex.Message);
                    flag = true;
                }
                return false;
            }
        }

        #endregion

        #region [ 方法 ] 往串口中写数据

        /// <summary>
        /// 往串口写数据
        /// </summary>
        /// <param name="bytes">需要发送的字节数组</param>
        /// <returns></returns>
        public bool Write(byte[] bytes)
        {
            try
            {
                //Czlt-20140213 在接收数据前丢失所有缓存数据
                serialPort.DiscardInBuffer();

                //发送之前主线程休眠20毫秒
                //System.Threading.Thread.Sleep(20);

                // 写数据
                serialPort.Write(bytes, 0, bytes.Length);
                if (flag)
                {
                    ErrorMessage(Index, 0, "", "[Base_SerialPort:Open]", serialPort.PortName + "已重新打开");
                    flag = false;
                }
                return true;
            }
            catch (Exception ex)
            {
                if (serialPort != null && serialPort.IsOpen == false)
                {
                    Open();

                    try
                    {
                        serialPort.Write(bytes, 0, bytes.Length);
                    }
                    catch
                    {
                    }
                }
                if (!flag)
                {
                    ErrorMessage(Index, 4, ex.StackTrace, "[Base_SerialPort:Write]", ex.Message);
                    flag = true;
                }

                return false;
            }
            finally
            {
                timer.Enabled = true;
            }
        }

        #endregion
        
        #region [ 方法 ] 测试串口是否已经打开

        /// <summary>
        /// 测试串口是否已经打开
        /// </summary>
        /// <returns></returns>
        public bool IsOpen()
        {
            try
            {
                if (serialPort == null)
                {
                    return false;
                }

                return serialPort.IsOpen;
            }
            catch (Exception ex)
            {
                ErrorMessage(Index, 3, ex.StackTrace, "[Base_SerialPort:IsOpen]", ex.Message);
                return false;
            }
        }

        #endregion

        #region [ 方法 ] 获取串口的列表

        /// <summary>
        /// 获取串口的列表
        /// </summary>
        /// <returns></returns>
        public static ArrayList List()
        {
            try
            {
                ArrayList al = new ArrayList();

                ManagementClass mc = new ManagementClass("Win32_SerialPort");
                ManagementObjectCollection moc = mc.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    al.Add(mo["DeviceID"].ToString());
                }

                return al;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        /*
         * 原始数据显示面板
         */

        #region [ 属性 ] 原始数据

        private KJRichTextBox _RTxtMsgo = null;

        /// <summary>
        /// 原始数据
        /// </summary>
        public KJRichTextBox RTxtMsgo
        {
            get { return _RTxtMsgo; }
            set { _RTxtMsgo = value; }
        }

        #endregion


        #region [ 属性 ] 标志位

        private int _Mark;

        /// <summary>
        /// 标志位
        /// </summary>
        public int Mark
        {
            get { return _Mark; }
            set { _Mark = value; }
        }

        #endregion

    }
}
