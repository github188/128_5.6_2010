using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace KJ128NMainRun
{
    /// <summary>
    /// 查找窗体或进程是否存在或打开
    /// </summary>
    public class Searcher
    {
        /// <summary>
        /// 查找窗体是否打开
        /// </summary>
        /// <param name="formName">窗体名</param>
        /// <returns>返回true 表示存在 false 表示不存在</returns>
        public static bool FindFormByName(string formName)
        {
            #if DEBUG

            if (formName.Trim() == string.Empty)
            {
                throw new Exception("窗体名不能为空！");
            }

            #else

            if (formName.Trim() == string.Empty)
            {
                return false;
            }

            #endif
            Form frm = Application.OpenForms[formName];

            if (frm == null)
            {
                return false;
            }

            //激活窗体
            frm.Activate();

            return true;
        }

        /// <summary>
        /// 查找进程是否存在
        /// </summary>
        /// <param name="processName">进程名</param>
        /// <returns>返回true 表示进程存在 false 表示进程不存在</returns>
        public static bool FindProcessByName(string processName)
        {
            #if DEBUG

            if (processName.Trim() == string.Empty)
            {
                throw new Exception("进程名不能为空！");
            }

            #else

            if (processName.Trim() == string.Empty)
            {
                return false;
            }

            #endif

            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName.Equals(processName.Trim()))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
