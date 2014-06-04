using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace KJ128A.Batman
{
    /// <summary>
    /// 错误日志写入类
    /// </summary>
    public class ErrorWriter
    {

        #region[将错误信息写入文件]

        /// <summary>
        ///程序集错误写入方法
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <returns>成功返回true失败返回false</returns>
        public bool ApplictionErrorWrite(string message)
        {
            try
            {
                if (!Directory.Exists("Error"))
                {
                    Directory.CreateDirectory("Error");
                }
                ErrorWriterToFile(message, @"Error/ApplictionErrors.txt");
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 月错误写入方法
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <returns>成功返回true失败返回false</returns>
        public bool MonthErrorWriter(string message)
        {
            try
            {
                if (!Directory.Exists(@"Error/" + DateTime.Now.ToString("yyyy-MM")))
                {
                    Directory.CreateDirectory(@"Error/" + DateTime.Now.ToString("yyyy-MM"));
                }
                ErrorWriterToFile(message, @"Error/" + DateTime.Now.ToString("yyyy-MM") + @"/" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 将信息写入文件
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <param name="path">文件路径</param>
        public void ErrorWriterToFile(string message, string path)
        {
            try
            {
                if (!File.Exists(path))
                    File.Create(path);
                FileStream filestream = new FileStream(path, FileMode.Append, FileAccess.Write);
                StreamWriter streamwriter = new StreamWriter(filestream);
                streamwriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss\t") + message);
                streamwriter.Flush();
                streamwriter.Close();
                streamwriter.Dispose();
                filestream.Close();
                filestream.Dispose();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
        #endregion
    }
}
