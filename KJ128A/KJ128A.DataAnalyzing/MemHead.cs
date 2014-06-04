using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128A.DataAnalyzing
{
    public struct MemHead
    {
        /// <summary>
        /// ̽ͷ��
        /// </summary>
        public int HeadAddress;

        /// <summary>
        /// ʱ��
        /// </summary>
        public DateTime Time;

        /// <summary>
        /// ����
        /// </summary>
        public int CodeCount;

        /// <summary>
        /// ����
        /// </summary>
        public int Antenna;

        /// <summary>
        /// �Ƿ���ϣ�true Ϊ���ϣ�
        /// </summary>
        public bool IsBreak;

        /// <summary>
        /// A ���߽��յ��Ŀ���
        /// </summary>
        public string CodesA;

        /// <summary>
        /// B ���߽��յ��Ŀ���
        /// </summary>
        public string CodesB;

        /// <summary>
        /// ��̽ͷ����
        /// </summary>
        public string CodesC;

        /// <summary>
        /// ��ȿ���
        /// </summary>
        public string CodesD;

        /// <summary>
        ///  �͵���  A ���߽��յ��Ŀ���
        /// </summary>
        public string CodesE;
        /// <summary>
        /// �͵���  B ���߽��յ��Ŀ���
        /// </summary>
        public string CodesF;
        /// <summary>
        /// �͵���  ��̽ͷ����
        /// </summary>
        public string CodesG;
        /// <summary>
        /// �͵���  ��ȿ���
        /// </summary>
        public string CodesH;

        /// <summary>
        /// Czlt-2011-11-17 - ��ֱ������
        /// </summary>
        public string CodesDY;
    }
}
