using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128NDataBase
{

    /// <summary>
    /// Ӳ���豸����ö��
    /// </summary>
    public enum CorpsName
    {
        /// <summary>
        /// ��վ
        /// </summary>
        Station,

        /// <summary>
        /// ��վ���
        /// </summary>
        StationAddress,

        /// <summary>
        /// ��վ��װλ��
        /// </summary>
        StationSplace,

        /// <summary>
        /// ������
        /// </summary>
        StaHead,

        /// <summary>
        /// ���������
        /// </summary>
        StaHeadAddress,

        /// <summary>
        /// ��������װλ��
        /// </summary>
        StaHeadSplace,

        /// <summary>
        /// ���ʱ��
        /// </summary>
        Inspect,

        /// <summary>
        /// ������
        /// </summary>
        CodeSender,

        /// <summary>
        /// ���������
        /// </summary>
        CodeSenderAddress,

        /// <summary>
        /// �뾮ʱ��
        /// </summary>
        InWellTime,

        /// <summary>
        /// ����ʱ��
        /// </summary>
        OutWellTime,

        /// <summary>
        /// �¾�����ʱ��
        /// </summary>
        StandingWellTime,

        /// <summary>
        /// ��������ʱ��
        /// </summary>
        InTerritorialTime,

        /// <summary>
        /// �뿪����ʱ��
        /// </summary>
        OutTerritorialTime,

        /// <summary>
        /// ����ʱ��
        /// </summary>
        StandingTime

    }

    /// <summary>
    /// Ӳ���豸����
    /// </summary>
    public class HardwareName
    {
        public static string Value(CorpsName hName)
        {
            string strTmp = string.Empty;
            switch (hName)
            {
                case CorpsName.Station:
                    strTmp = "�����վ";
                    break;
                case CorpsName.StationAddress:
                    strTmp = "�����վ���";
                    break;
                case CorpsName.StationSplace:
                    strTmp = "�����վ��װλ��";
                    break;
                case CorpsName.StaHead:
                    strTmp = "������վ";
                    break;
                case CorpsName.StaHeadAddress:
                    strTmp = "������վ���";
                    break;
                case CorpsName.StaHeadSplace:
                    strTmp = "������վ��װλ��";
                    break;
                case CorpsName.Inspect:
                    strTmp = "���ʱ��";
                    break;
                case CorpsName.CodeSender:
                    strTmp = "��ʶ��";
                    break;
                case CorpsName.CodeSenderAddress:
                    strTmp = "��ʶ�����";
                    break;
                case CorpsName.InWellTime:
                    strTmp = "�뾮ʱ��";
                    break;
                case CorpsName.OutWellTime:
                    strTmp = "����ʱ��";
                    break;
                case CorpsName.StandingWellTime:
                    strTmp = "�¾�����ʱ��";
                    break;
                case CorpsName.InTerritorialTime:
                    strTmp = "��������ʱ��";
                    break;
                case CorpsName.OutTerritorialTime:
                    strTmp = "�뿪����ʱ��";
                    break;
                case CorpsName.StandingTime:
                    strTmp = "����ʱ��";
                    break;
                default:
                    break;
            }
            return strTmp;
        }   
    }

    
}
