using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace KJ128A.DataSave
{
    /// <summary>
    /// 
    /// </summary>
    public class FileCopy:IDisposable
    {
        #region [ 变量 ]

        private FileOperate fOperate;
        private Thread thCopy;
        private int _iCacheSize=1024*1024;
        private bool _blState = true;

        #endregion

        #region [ 委托: 拷贝完成 ]

        /// <summary>
        /// 委托
        /// </summary>
        public delegate void CopyCompleteEventHandler();

        /// <summary>
        /// 事件
        /// </summary>
        public event CopyCompleteEventHandler CopyComplete;

        #endregion

        #region [ 委托: 返回进度百分比 ]

        /// <summary>
        /// 委托
        /// </summary>
        /// <param name="percent">拷贝进度百分比</param>
        public delegate void GuageEventHandler(int percent);

        /// <summary>
        /// 事件
        /// </summary>
        public event GuageEventHandler GuageEvent;

        private void GuageEventFun(int percent)
        {
            if (GuageEvent != null)
            {
                GuageEvent(percent);
            }
        }

        #endregion

        #region [ 构造函数 ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formerFile"></param>
        /// <param name="freshFile"></param>
        public FileCopy(string formerFile, string freshFile)
        {
            fOperate = new FileOperate(formerFile, freshFile);
        }

        #endregion

        #region [ 方法: 删除新文件 ]

        /// <summary>
        /// 
        /// </summary>
        public void DeleteFreshFile()
        {
            if (File.Exists(fOperate.FreshFile))
            {
                File.Delete(fOperate.FreshFile);
            }
        }

        #endregion

        #region [ 方法: 停止 ]

        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            _blState = false;
            if (thCopy != null)
            {
                thCopy.Abort();
            }
            fOperate.Dispose();
            Thread.Sleep(1000);
        }

        #endregion

        #region [ 方法: 拷贝 ]

        /// <summary>
        /// 
        /// </summary>
        public void Copy()
        {
            _blState = true;
            fOperate.Open();
            thCopy = new Thread(StartCopy);
            thCopy.Start();
        }

        #endregion

        #region [ 方法: 拷贝线程 ]

        /// <summary>
        /// 拷贝数据
        /// </summary>
        private void StartCopy()
        {
            try
            {
                #region
                byte[] byteCache = new byte[_iCacheSize];
                // 新文件大小
                long _iCount = 0;
                // 原文件大小
                long _iSize = fOperate.FormerFileSize;
                // 文件读取位置
                long i = _iSize / 100;
                fOperate.Position = fOperate.FreshFileSize;
                if (_iSize > _iCacheSize)
                {
                    for (_iCount = fOperate.FreshFileSize; _iCount + _iCacheSize < _iSize; _iCount += _iCacheSize)
                    {
                        if (_blState)
                        {
                            fOperate.WriteAppend(fOperate.Read(byteCache, _iCacheSize), _iCacheSize);
                            GuageEventFun(Convert.ToInt32(_iCount / i));
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                if (!_blState)
                {
                    return;
                }
                if (_iSize > fOperate.Position)
                {
                    int iSpare =Convert.ToInt32(_iSize - Convert.ToInt64(fOperate.Position));
                    byteCache = new byte[iSpare];
                    fOperate.WriteAppend(fOperate.Read(byteCache, iSpare), iSpare);

                    GuageEventFun(100);
                }
                byteCache = null;
                fOperate.Dispose();
                #endregion
            }
            catch (System.OutOfMemoryException)
            {

            }
            catch (System.IO.IOException)
            {

            }
            CopyCompleteFun();
        }

        #endregion

        #region [ 方法: 拷贝完成 ]

        private void CopyCompleteFun()
        {
            if (CopyComplete != null)
            {
                CopyComplete();
            }
        }

        #endregion

        #region IDisposable 成员

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            
            if (thCopy != null)
            {
                thCopy.Abort();
            }
        }

        #endregion
    }
}
