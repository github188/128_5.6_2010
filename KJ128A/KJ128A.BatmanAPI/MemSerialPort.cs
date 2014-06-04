using System;
using System.Text;

namespace KJ128A.BatmanAPI
{
    /// <summary>
    /// 结构体: 串口信息
    /// </summary>
    public struct MemSerialPort
    {
        #region [ 属性 ] 编号

        private int _ID;

        /// <summary>
        /// 获取或设置通信端口编号
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        #endregion

        #region [ 属性 ] 端口名称

        private string _PortName;

        /// <summary>
        /// 获取或设置通信端口, 包括但不限于所有可用的 COM 端口
        /// </summary>
        public string PortName
        {
            get { return _PortName; }
            set { _PortName = value; }
        }

        #endregion

        #region [ 属性 ] 分组号

        private int _Group;

        /// <summary>
        /// 获取或设置与串口相关的基站分组号
        /// </summary>
        public int Group
        {
            get { return _Group; }
            set { _Group = value; }
        }

        #endregion

        #region [ 属性 ] 标志位

        private int _Mark;

        /// <summary>
        /// 获取或设置标志位
        /// </summary>
        public int Mark
        {
            get { return _Mark; }
            set { _Mark = value; }
        }

        #endregion
    }
}
