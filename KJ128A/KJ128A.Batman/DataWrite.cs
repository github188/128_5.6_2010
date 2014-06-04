using System;
using System.Text;
using System.IO;

namespace KJ128A.Batman
{
    public class DataWrite
    {
        #region 【自定义全局变量】
        /// <summary>
        /// 文件目录
        /// </summary>
        private string m_strFileDirectory = string.Empty;
        /// <summary>
        /// 字符编码
        /// </summary>
        private Encoding m_encoding = Encoding.Default;
        #endregion

        #region 【自定义属性】
        /// <summary>
        /// 设置文件目录
        /// </summary>
        public string FileDirectory
        {
            set 
            {
                m_strFileDirectory = value;
            }
            get { return m_strFileDirectory; }
        }

        /// <summary>
        /// 设置字符编码
        /// </summary>
        public Encoding MyEncoding
        {
            set { m_encoding = value; }
            get { return m_encoding; }
        }
        #endregion

        #region 【构造函数】
        /// <summary>
        /// 写入文件
        /// </summary>
        public DataWrite()
        { 
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="strFileDirectory">文件目录</param>
        /// <param name="encoding">字符编码</param>
        public DataWrite(string strFileDirectory,Encoding encoding)
        {
            m_strFileDirectory = strFileDirectory;  //文件存储目录
            m_encoding = encoding;//文件存入字符编码
        }
        #endregion

        #region 【方法：读取文本内容】
        /// <summary>
        /// 读取文本文件内容
        /// </summary>
        /// <param name="strFileName">文件名称</param>
        /// <returns></returns>
        public string ReadFile(string strFileName)
        {
            try
            {
                string strContent = string.Empty;
                if (Directory.Exists(m_strFileDirectory))
                {
                    strContent = File.ReadAllText(m_strFileDirectory + "\\" + strFileName, m_encoding);
                }
                return strContent;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region 【方法：创建文本文件，并写入数据】
        /// <summary>
        /// 创建文本文件
        /// </summary>
        /// <param name="strFileName">文件名称+后缀名</param>
        /// <param name="blOverlay">是覆盖原文件，还是追加数据  true 覆盖  false 追加</param>
        public void CreateFile(string strFileName,string strContent, bool blOverlay)
        {
            if (!string.IsNullOrEmpty(m_strFileDirectory.Trim()))
            {
                //如果目录不存在，则创建目录
                if (!Directory.Exists(m_strFileDirectory))
                {
                    Directory.CreateDirectory(m_strFileDirectory);
                }

                /*===================================== 覆盖原文件的情况====================================*/
                if (blOverlay)
                {
                    try
                    {
                        File.WriteAllText(m_strFileDirectory + "\\" + strFileName, strContent, m_encoding);
                    }
                    catch
                    {
                        throw;
                    }
                }
                /*===================================== 追加原文件的情况====================================*/
                else
                {
                    try
                    {
                        File.AppendAllText(m_strFileDirectory + "\\" + strFileName, strContent, m_encoding);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }
        #endregion

        #region 【方法：清理文件】
        /// <summary>
        /// 清理文件
        /// </summary>
        /// <param name="strFilePath"></param>
        public void CleanFile(string strFilePath)
        {
            try
            {
                if (File.Exists(strFilePath))
                {
                    File.Delete(strFilePath);
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
