using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KJ128NMainRun.RealTime.RealTimeInWellInfo;
using KJ128NMainRun.EquManage;
using KJ128NMainRun.StationManage;
using KJ128NMainRun.RealTime;
using System.Diagnostics;
using KJ128NDataBase;
using KJ128NMainRun;
using System.IO;
using SoftDog;
using System.Threading;
using KJ128NInterfaceShow;
using KJ128NMainRun.HistoryInfo;
using System.Xml;
using System.Data.SqlClient;
using KJ128NMainRun.A_InMineDayReport;

namespace KJ128NInterfaceShow
{
	public static class RefReshTime
	{

		/// <summary>
		/// 实时刷新时间
		/// </summary>
		public static int _rtTime = 3000;

		/// <summary>
		/// 热备刷新间隔时间（毫秒），默认400毫秒
		/// </summary>
		public static int intHostBackRefTime = 400;

		/// <summary>
		/// 热备刷新次数，默认2次
		/// </summary>
		public static int intHostBackRefCount = 2;

		/// <summary>
		/// 是否启用人员求救，true：启用;false：不启用
		/// </summary>
		public static bool blIsLoadEmpHelp = false;
	}

	static class Program
	{

		//创建一个委托
		public delegate string CurrentStateDelegate(string name);

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
			#region[程序启动代码]

			try
			{

				#region[系统启用应用程序样式]

				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);

				#endregion

				#region [ 删除 .dw 后缀的文件]


				if (File.Exists(Application.StartupPath + "\\Conn.dw"))
				{
					File.Delete(Application.StartupPath + "\\Conn.dw");
				}

				#endregion

				#region [ 防止程序被多次打开 ]

				int iCount = 0;
				foreach (Process process in Process.GetProcesses())
				{
					if (process.ProcessName.Equals("KJ128NMainRun"))
					{
						iCount++;
					}
				}

				//Czlt-2011-01-25 删除打开多个程序控制
				//qyz-2011-11-27 加入多开限制
				if (iCount > 1)
				{
					MessageBox.Show("已经有一个KJ128A桌面程序在运行,请勿重复打开!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				#endregion

				#region [ 打开欢迎画面 ]

				FrmWelcome frm = new FrmWelcome();

				frm.Show();
				Thread.Sleep(100);

				#endregion

				#region 【实例化委托】
				CurrentStateDelegate czltCurrentState = new CurrentStateDelegate(frm.CurrentState);
				#endregion

				#region[判断是否是客户端]

				bool isClient = false;

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
								isClient = true;
							}
						}
					}
				}
				catch { }

				#endregion

				#region [ 检测软件狗 ]
				DialogResult result;
#if DEBUG

#else
                if (!isClient)
                {
                    //frm.CurrentState = "正在检测软件狗";
                    czltCurrentState("正在检测软件狗");
                    Thread.Sleep(200);


                    SoftDogJudge sdj = new SoftDogJudge();
                    string strSoftDog = sdj.Judge(ShowType.WinForm, "KJ128", "128");
                    if (!strSoftDog.Equals(""))
                    {
                        result = MessageBox.Show(strSoftDog, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (result == DialogResult.OK)
                        {
							return;
                        }
                    }
                }
#endif
				#endregion

				#region [ 打开热备通讯程序 ]

#if DEBUG

#else

                if (!isClient)
                {
                    //frm.CurrentState = "正在打开热备通讯程序";
                    czltCurrentState("正在打开热备通讯程序");
                    Thread.Sleep(100);

                    bool flag = false;
                    foreach (Process process in Process.GetProcesses())
                    {
                        if (process.ProcessName.Equals("KJ128A.Batman"))
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        if (File.Exists(Application.StartupPath + "\\KJ128A.Batman.exe"))
                        {
                            string strPath = @"KJ128A.Batman.exe";
                            Process TongXun = new Process();
                            TongXun.StartInfo.FileName = Application.StartupPath + @"\" + strPath;
                            TongXun.Start();
                        }
                    }
                }
#endif
				#endregion

				#region [ 检测数据库 ]



				//frm.CurrentState = "正在检测连接数据库";
				czltCurrentState("正在检测连接数据库");
				Thread.Sleep(100);

				DBAcess dbacc = new DBAcess();
				DbHelperSQL dbsql = new DbHelperSQL();
				if (dbacc.CreateConnection() == -1)
				{

					result = MessageBox.Show("数据库未连接，可能是数据库没有安装或数据库没有打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					if (result == DialogResult.OK)
					{
						return;
					}

				}

				////取消数据库收缩
				//if (!isClient)
				//{
				//    new KJ128A.DataSave.DataBaseManage().ZipDataBase();
				//}

				#endregion

				#region [ 打开主界面 ]

				//frm.CurrentState = "请稍等,正在打开主程序......";
				czltCurrentState("请稍等,正在打开主程序......");

				Application.Run(new A_FrmMain());

				//A_FrmToolOptions  KJ128NMainRun.A_FrmMain
				#endregion

			}
			catch (SqlException ex)
			{
				//string strErr = "在向服务器发送请求时发生传输级错误。 (provider: TCP 提供程序, error: 0 - 远程主机强迫关闭了一个现有的连接。)";
				//if (ex.Message.Equals(strErr))
				//{
				//MessageBox.Show("数据库连接失败，请重新打开应用程序！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Process pr = Process.GetCurrentProcess();
				if (pr.ProcessName.Equals("KJ128NMainRun"))
				{
					pr.Kill();
				}
				//}
			}

			#endregion
		}
	}
}