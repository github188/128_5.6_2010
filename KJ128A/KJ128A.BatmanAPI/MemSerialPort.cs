using System;
using System.Text;

namespace KJ128A.BatmanAPI
{
    /// <summary>
    /// �ṹ��: ������Ϣ
    /// </summary>
    public struct MemSerialPort
    {
        #region [ ���� ] ���

        private int _ID;

        /// <summary>
        /// ��ȡ������ͨ�Ŷ˿ڱ��
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        #endregion

        #region [ ���� ] �˿�����

        private string _PortName;

        /// <summary>
        /// ��ȡ������ͨ�Ŷ˿�, ���������������п��õ� COM �˿�
        /// </summary>
        public string PortName
        {
            get { return _PortName; }
            set { _PortName = value; }
        }

        #endregion

        #region [ ���� ] �����

        private int _Group;

        /// <summary>
        /// ��ȡ�������봮����صĻ�վ�����
        /// </summary>
        public int Group
        {
            get { return _Group; }
            set { _Group = value; }
        }

        #endregion

        #region [ ���� ] ��־λ

        private int _Mark;

        /// <summary>
        /// ��ȡ�����ñ�־λ
        /// </summary>
        public int Mark
        {
            get { return _Mark; }
            set { _Mark = value; }
        }

        #endregion
    }
}
