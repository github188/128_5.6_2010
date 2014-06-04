using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Xml;
using System.IO;

namespace KJ128NDataBase
{
    public class ErrorDispose
    {

        #region [ 声明 ]

        private static bool blError;

        public Thread myThread;

        #endregion

        #region [ 方法: 连接数据库失败处理 ]

        public  void ErrorDisposeInfo(int intErrorNo)
        {
            if (!blError)
            {
                //if (intErrorNo.Equals(10054) || intErrorNo.Equals(4) || intErrorNo.Equals(-1073741769) || intErrorNo.Equals(1231) || intErrorNo.Equals(1236) || intErrorNo.Equals(64) || intErrorNo.Equals(121))
                if (intErrorNo.Equals(10054) || intErrorNo.Equals(-1073741769) || intErrorNo.Equals(1231) || intErrorNo.Equals(1236) || intErrorNo.Equals(64) || intErrorNo.Equals(121))
                {
                    blError = true;
                    if (IsClient())
                    {
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Thread.Sleep(10000);
                    }
                    if (myThread == null)
                    {
                        myThread = new Thread(this.Run);
                        myThread.Name = "ErrorDispose";
                        myThread.IsBackground = true;
                        myThread.Start();
                    }
                }
            }
            while (myThread!=null)//(blError)
            {
                Thread.Sleep(1000);
            }

        }

        #endregion

        #region [ 方法: 应用程序自杀 ]

        private void Run()
        {
            Process pr = Process.GetCurrentProcess();
            if (pr.ProcessName.Equals("KJ128NMainRun"))
            {
                MessageBox.Show("数据库连接失败，请重新打开应用程序！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                try
                {
                    pr.Kill();
                }
                catch { }
            }
            else
            {
                blError = false;
                myThread.Abort();
                myThread = null;
            }
        }

        #endregion

        #region 【方法: 判断是否是客户端 】

        private bool IsClient()
        {
            try
            {
                string path = Application.StartupPath + @"\IsClient.xml";

                if (File.Exists(path))
                {

                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);

                    XmlNode node = doc.ChildNodes[1].SelectSingleNode("IsClient");

                    if (node != null)
                    {
                        if (node.InnerText.ToLower().Equals("true"))
                        {
                            return true;
                        }
                    }
                }
            }
            catch { }

            return false;
        }
        #endregion

    }
}
