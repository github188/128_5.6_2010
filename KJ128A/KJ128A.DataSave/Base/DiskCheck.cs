using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace KJ128A.DataSave
{
    /// <summary>
    /// 磁盘检测
    /// </summary>
    public class DiskCheck
    {

        #region [ 声明 ]

        /// <summary>
        /// 当磁盘空闲容量小于多少时提示用户清理磁盘
        /// </summary>
        private long l_SpaceMin = (long)200 * 1024 * 1024;     //200M

        /// <summary>
        /// 当磁盘空闲容量小于多少时直接清理磁盘
        /// </summary>
        private long l_Spaceless = (long)100 * 1024 * 1024;    //100M

        #endregion

        #region [ 委托 ]

        /// <summary>
        /// 监听磁盘容量
        /// </summary>
        /// <param name="flag">1，表示需要用户清理磁盘空间；2，表示程序直接清理磁盘空间</param>
        public delegate void InitListenFreeSpaceEventHandler(int flag);

        /// <summary>
        /// 监听磁盘容量事件
        /// </summary>
        public event InitListenFreeSpaceEventHandler InitListenFreeSpace;

        #endregion

        #region [ 方法: 获取程序运行的磁盘的空闲容量 ]

        /// <summary>
        /// 获取程序运行的磁盘的空闲容量
        /// </summary>
        /// <returns>空间空闲容量</returns>
        private long GetDriverFreeSpace(string strPath)
        {
            string strDriverName = Directory.GetDirectoryRoot(strPath);
            DriveInfo dInfo = new DriveInfo(strDriverName);
            long lSum = dInfo.AvailableFreeSpace;    //磁盘空闲容量
            return lSum;
        }

        #endregion

        #region [ 接口: 每天定时检测磁盘的空间，并做出处理 ]

        /// <summary>
        /// 检查磁盘剩余容量，并进行处理
        /// </summary>
        public void hardCheckMessure()
        {
            long lSpace = GetDriverFreeSpace(Application.StartupPath);

            if (l_Spaceless < lSpace && lSpace < l_SpaceMin)
            {
                if (InitListenFreeSpace != null)
                {
                    //提示用户清理磁盘
                    InitListenFreeSpace(1);     //磁盘空间不足，提示用户清理磁盘！
                }
            }
            else if (lSpace < l_Spaceless)
            {
                if (InitListenFreeSpace != null)
                {
                    //自动清理磁盘
                    InitListenFreeSpace(2);     //磁盘空间太小，程序自动清理磁盘
                }
            }
        }

        #endregion
    }
}
