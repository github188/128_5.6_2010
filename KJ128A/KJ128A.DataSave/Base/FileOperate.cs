using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace KJ128A.DataSave
{
    /// <summary>
    /// 
    /// </summary>
    public class FileOperate:IDisposable
    {
        private FileStream readStream;
        private FileStream writeStream;
        private long formerFileSize, freshFileSize;
        private string formerFileName, freshFileName;

        #region [ 属性: 原文件 ]

        /// <summary>
        /// 原文件
        /// </summary>
        public string FormerFile
        {
            get{return formerFileName;}
            set{formerFileName = value;}
        }

        #endregion

        #region [ 属性: copy后的文件 ]

        /// <summary>
        /// copy后的文件
        /// </summary>
        public string FreshFile
        {
            get { return freshFileName; }
            set { freshFileName = value; }
        }

        #endregion

        #region [ 构造函数 ] 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formerFile"></param>
        /// <param name="freshFile"></param>
        public FileOperate(string formerFile, string freshFile)
        {
            formerFileName = formerFile;
            freshFileName = freshFile;
            
        }

        /// <summary>
        /// 
        /// </summary>
        ~FileOperate()
        {
            if (readStream != null)
            {
                readStream.Dispose();
                readStream = null;
            }
            if (writeStream != null)
            {
                writeStream.Dispose();
                writeStream = null;
            }
        }

        #endregion

        #region [ 方法: 初始化Stream ]

        /// <summary>
        /// 
        /// </summary>
        public void Open()
        {
            readStream = new FileStream(formerFileName, FileMode.Open, FileAccess.Read);
            FileInfo fInfo = new FileInfo(formerFileName);
            formerFileSize = Convert.ToInt32(fInfo.Length);            

            writeStream = new FileStream(freshFileName, FileMode.Append, FileAccess.Write);
            fInfo = new FileInfo(freshFileName);
            freshFileSize = Convert.ToInt32(fInfo.Length);
            fInfo = null;
        }

        #endregion

        #region [ 属性: 获取或设置读取的当前位置 ]

        /// <summary>
        /// 获取或设置读取的当前位置
        /// </summary>
        public long Position
        {
            get
            {
                return readStream.Position;
            }
            set
            {
                readStream.Position = value;
            }
        }

        #endregion

        #region [ 属性: 原文件大小 ]

        /// <summary>
        /// 原文件大小
        /// </summary>
        public long FormerFileSize
        {
            get
            {
                return formerFileSize;
            }
            set
            {
                formerFileSize = value;
            }
        }

        #endregion

        #region [ 属性: 新问件大小 ]

        /// <summary>
        /// 新文件大小
        /// </summary>
        public long FreshFileSize
        {
            get
            {
                return freshFileSize;
            }
            set
            {
                freshFileSize = value;
            }
        }

        #endregion

        #region [ 方法: 读取文件 ]

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="byteCache">指定读取当前位置到Size</param>
        /// <param name="size"></param>
        /// <returns></returns>
        public byte[] Read(byte[] byteCache,int size)
        {
            readStream.Read(byteCache, 0, size);
            return byteCache;
        }

        #endregion

        #region [ 方法: 追加数据 ]

        /// <summary>
        /// 追加数据
        /// </summary>
        /// <param name="byteData">追加的数据</param>
        /// <param name="size">追加数据大小</param>
        /// <returns></returns>
        public void WriteAppend(byte[] byteData, int size)
        {
            writeStream.Write(byteData, 0, size);
            writeStream.Flush();
        }

        /// <summary>
        /// 追加数据
        /// </summary>
        /// <param name="byteData">追加的数据</param>
        /// <param name="size">追加数据大小</param>
        /// <param name="stream">要写入的FileStream流</param>
        /// <returns></returns>
        public void WriteAppend(byte[] byteData, int size, FileStream stream)
        {
            stream.Write(byteData, 0, size);
            stream.Flush();
        }

        #endregion

        #region [ 方法: 关闭读取连接 ]

        /// <summary>
        /// 关闭读取连接
        /// </summary>
        public void ReadFileClose()
        {
            readStream.Close();
        }

        #endregion

        #region [ 方法: 关闭写入连接 ]

        /// <summary>
        /// 关闭写入连接
        /// </summary>
        public void WriteAppendFileClose()
        {
            writeStream.Close();
        }

        #endregion

        #region [ 方法: 释放连接 ]

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (readStream != null)
            {
                readStream.Close();
                readStream.Dispose();
            }
            if (writeStream != null)
            {
                writeStream.Close();
                writeStream.Dispose();
            }
        }

        #endregion

    }
}
