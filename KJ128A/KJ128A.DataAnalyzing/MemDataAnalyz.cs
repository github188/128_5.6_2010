using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128A.DataAnalyzing
{
    public struct MemDataAnalyz
    {
        /// <summary>
        /// ��������
        /// </summary>
        public EnumDataType enumAnalyzing;

        /// <summary>
        /// ��վ��ַ
        /// </summary>
        public int StationAddress; 

        /// <summary>
        /// ��վ�汾��
        /// </summary>
        public int StationVer;

        /// <summary>
        /// ��־λ
        /// </summary>
        public int Mark;

        /// <summary>
        /// �����Ƿ���Ч, true ʱ�ýṹ���������Ϊ��Ч���ݣ� false ʱ�ýṹ��Ϊ��Ч����
        /// </summary>
        public bool IsEnable;

        /// <summary>
        /// �����
        /// </summary>
        public int CmdLength;

        /// <summary>
        /// ̽ͷ
        /// </summary>
        public MemHead[] memHead;
        
    }
}
