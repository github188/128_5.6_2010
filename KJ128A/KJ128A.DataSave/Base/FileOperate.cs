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

        #region [ ����: ԭ�ļ� ]

        /// <summary>
        /// ԭ�ļ�
        /// </summary>
        public string FormerFile
        {
            get{return formerFileName;}
            set{formerFileName = value;}
        }

        #endregion

        #region [ ����: copy����ļ� ]

        /// <summary>
        /// copy����ļ�
        /// </summary>
        public string FreshFile
        {
            get { return freshFileName; }
            set { freshFileName = value; }
        }

        #endregion

        #region [ ���캯�� ] 

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

        #region [ ����: ��ʼ��Stream ]

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

        #region [ ����: ��ȡ�����ö�ȡ�ĵ�ǰλ�� ]

        /// <summary>
        /// ��ȡ�����ö�ȡ�ĵ�ǰλ��
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

        #region [ ����: ԭ�ļ���С ]

        /// <summary>
        /// ԭ�ļ���С
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

        #region [ ����: ���ʼ���С ]

        /// <summary>
        /// ���ļ���С
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

        #region [ ����: ��ȡ�ļ� ]

        /// <summary>
        /// ��ȡ�ļ�
        /// </summary>
        /// <param name="byteCache">ָ����ȡ��ǰλ�õ�Size</param>
        /// <param name="size"></param>
        /// <returns></returns>
        public byte[] Read(byte[] byteCache,int size)
        {
            readStream.Read(byteCache, 0, size);
            return byteCache;
        }

        #endregion

        #region [ ����: ׷������ ]

        /// <summary>
        /// ׷������
        /// </summary>
        /// <param name="byteData">׷�ӵ�����</param>
        /// <param name="size">׷�����ݴ�С</param>
        /// <returns></returns>
        public void WriteAppend(byte[] byteData, int size)
        {
            writeStream.Write(byteData, 0, size);
            writeStream.Flush();
        }

        /// <summary>
        /// ׷������
        /// </summary>
        /// <param name="byteData">׷�ӵ�����</param>
        /// <param name="size">׷�����ݴ�С</param>
        /// <param name="stream">Ҫд���FileStream��</param>
        /// <returns></returns>
        public void WriteAppend(byte[] byteData, int size, FileStream stream)
        {
            stream.Write(byteData, 0, size);
            stream.Flush();
        }

        #endregion

        #region [ ����: �رն�ȡ���� ]

        /// <summary>
        /// �رն�ȡ����
        /// </summary>
        public void ReadFileClose()
        {
            readStream.Close();
        }

        #endregion

        #region [ ����: �ر�д������ ]

        /// <summary>
        /// �ر�д������
        /// </summary>
        public void WriteAppendFileClose()
        {
            writeStream.Close();
        }

        #endregion

        #region [ ����: �ͷ����� ]

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
