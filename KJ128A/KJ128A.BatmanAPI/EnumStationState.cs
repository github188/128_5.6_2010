using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128A.BatmanAPI
{
    /// <summary>
    /// ��վ״̬
    /// </summary>
    public enum EnumStationState
    {
        /// <summary>
        /// ��վδ����
        /// </summary>
        NoInit = 0,

        /// <summary>
        /// ��վ����
        /// </summary>
        Reset = 2500,

        /// <summary>
        /// ��վ����
        /// </summary>
        Sleep = -1000,

        /// <summary>
        /// ��վ����
        /// </summary>
        Leave = 3000,

        /// <summary>
        /// ��վ����
        /// </summary>
        Malfunction = 5000,

        /// <summary>
        /// ��ѯ�汾
        /// </summary>
        SelectEdition=2200,
        /// <summary>
        /// ����Ѳ��
        /// </summary>
        PointSelect=20000,
        /// <summary>
        /// ����Ѳ��
        /// </summary>
        PointCancal=20001,
    }
}
