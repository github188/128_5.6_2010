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
        #region [ ���� ]

        private FileOperate fOperate;
        private Thread thCopy;
        private int _iCacheSize=1024*1024;
        private bool _blState = true;

        #endregion

        #region [ ί��: ������� ]

        /// <summary>
        /// ί��
        /// </summary>
        public delegate void CopyCompleteEventHandler();

        /// <summary>
        /// �¼�
        /// </summary>
        public event CopyCompleteEventHandler CopyComplete;

        #endregion

        #region [ ί��: ���ؽ��Ȱٷֱ� ]

        /// <summary>
        /// ί��
        /// </summary>
        /// <param name="percent">�������Ȱٷֱ�</param>
        public delegate void GuageEventHandler(int percent);

        /// <summary>
        /// �¼�
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

        #region [ ���캯�� ]

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

        #region [ ����: ɾ�����ļ� ]

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

        #region [ ����: ֹͣ ]

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

        #region [ ����: ���� ]

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

        #region [ ����: �����߳� ]

        /// <summary>
        /// ��������
        /// </summary>
        private void StartCopy()
        {
            try
            {
                #region
                byte[] byteCache = new byte[_iCacheSize];
                // ���ļ���С
                long _iCount = 0;
                // ԭ�ļ���С
                long _iSize = fOperate.FormerFileSize;
                // �ļ���ȡλ��
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

        #region [ ����: ������� ]

        private void CopyCompleteFun()
        {
            if (CopyComplete != null)
            {
                CopyComplete();
            }
        }

        #endregion

        #region IDisposable ��Ա

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
