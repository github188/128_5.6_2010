using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace KJ128A.Batman
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                #region [ 防止程序被多次打开 ]

                int iCount = 0;
                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName.Equals("KJ128A.Batman"))
                    {
                        iCount++;
                    }
                }
                if (iCount > 1)
                {
                    MessageBox.Show("已经有一个KJ128A通讯程序在运行,请勿重复打开!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmMain());
                //Application.Run(new FrmMain());
                // Application.Run(new FrmDBSet());
            }
            catch(Exception ex) {
                File.AppendAllText("D:\\CzltException.txt", ex.ToString(), Encoding.Unicode);
            }
            //catch (Exception ex)
            //{
            //    new ErrorWriter().ApplictionErrorWrite(ex.Message);
            //}
        }
    }
}