using System;
using System.Collections.Generic;
using System.Text;


namespace KJ128A.Protocol
{
    /// <summary>
    /// 2007-12-10 ��Э��
    /// </summary>
    public class P20071210
    {
        #region Ѳ������ [20]

        /// <summary>
        /// Ѳ������
        /// </summary>
        /// <param name="iStationAddress">��վ��ַ</param>
        /// <param name="iMark">������־</param>
        /// <returns></returns>
        public static byte[] Polling(int iStationAddress, int iMark)
        {
            try
            {
                //byte[] eBit;
                //byte[] Fs = new byte[11];
                //Fs[0] = 10;
                //for (int i = 1; i <= 5; i++)
                //{
                //    Fs[i] = 255;
                //}
                //Fs[6] = (byte)iStationAddress; // ��վ��
                //Fs[7] = 20; // �����
                //Fs[8] = (byte)iMark; // ������־
                //eBit = CRCVerify.Crc(Fs, 9, 1);
                //Fs[9] = eBit[1]; // ��λ
                //Fs[10] = eBit[0]; // ��λ
                //return Fs;
                byte[] eBit;
                byte[] Fs = new byte[12];
                Fs[0] = 00;
                Fs[1] = 10;
                for (int i = 2; i <= 6; i++)
                {
                    Fs[i] = 255;
                }
                Fs[7] = (byte)iStationAddress; // ��վ��
                Fs[8] = 20; // �����
                Fs[9] = (byte)iMark; // ������־
                eBit = CRCVerify.Crc(Fs, 10, 2);
                Fs[10] = eBit[1]; // ��λ
                Fs[11] = eBit[0]; // ��λ
                return Fs;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region ����ȷ������ [21]

        /// <summary>
        /// ����ȷ������
        /// </summary>
        /// <param name="iStationAddress">��վ��ַ</param>
        /// <param name="iMark">������־</param>
        /// <returns></returns>
        public static byte[] PollingRight(int iStationAddress, int iMark)
        {
            try
            {
                //byte[] eBit;
                //byte[] Fs = new byte[11];
                //Fs[0] = 10;
                //for (int i = 1; i <= 5; i++)
                //{
                //    Fs[i] = 255;
                //}
                //Fs[6] = (byte)iStationAddress; // ��վ��
                //Fs[7] = 21; // �����
                //Fs[8] = (byte)iMark; // ������־
                //eBit = CRCVerify.Crc(Fs, 9, 1);
                //Fs[9] = eBit[1]; // ��λ
                //Fs[10] = eBit[0]; // ��λ
                //return Fs;

                byte[] eBit;
                byte[] Fs = new byte[12];
                Fs[0] = 00;
                Fs[1] = 10;
                for (int i = 2; i <= 6; i++)
                {
                    Fs[i] = 255;
                }
                Fs[7] = (byte)iStationAddress; // ��վ��
                Fs[8] = 21; // �����
                Fs[9] = (byte)iMark; // ������־
                eBit = CRCVerify.Crc(Fs, 10, 2);
                Fs[10] = eBit[1]; // ��λ
                Fs[11] = eBit[0]; // ��λ
                return Fs;

            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region ��վ��ʱ���� [23]

        /// <summary>
        /// ��վ��ʱ����
        /// </summary>
        /// <param name="iStationAddress">��վ��ַ</param>
        /// <param name="iMark">������־</param>
        /// <returns></returns>
        public static byte[] SyncDate(int iStationAddress, int iMark)
        {
            try
            {
                //DateTime tempDT = DateTime.Now;
                //byte[] eBit;
                //byte[] Fs = new byte[17];
                //Fs[0] = 10;
                //for (int i = 1; i <= 5; i++)
                //{
                //    Fs[i] = 255;
                //}
                //Fs[6] = (byte)iStationAddress; // ��վ��ַ��
                //Fs[7] = 23; // �����
                //Fs[8] = (byte)iMark; // ������־
                //Fs[9] = (byte)(tempDT.Year - 2000);     // ��
                //Fs[10] = (byte)tempDT.Month;            // ��
                //Fs[11] = (byte)tempDT.Day;             // ��
                //Fs[12] = (byte)tempDT.Hour; // ��ǰʱ���Сʱ����
                //Fs[13] = (byte)tempDT.Minute; // ��ǰʱ��ķֲ���
                //Fs[14] = (byte)tempDT.Second; // ��ǰʱ����벿��
                //eBit = CRCVerify.Crc(Fs, 15, 1);
                //Fs[15] = eBit[1]; //��λ
                //Fs[16] = eBit[0]; //��λ
                //return Fs;

                DateTime tempDT = DateTime.Now;
                byte[] eBit;
                byte[] Fs = new byte[18];
                Fs[0] = 00;
                Fs[1] = 10;
                for (int i = 2; i <= 6; i++)
                {
                    Fs[i] = 255;
                }
                Fs[7] = (byte)iStationAddress; // ��վ��ַ��
                Fs[8] = 23; // �����
                Fs[9] = (byte)iMark; // ������־
                Fs[10] = (byte)(tempDT.Year - 2000);     // ��
                Fs[11] = (byte)tempDT.Month;            // ��
                Fs[12] = (byte)tempDT.Day;             // ��
                Fs[13] = (byte)tempDT.Hour; // ��ǰʱ���Сʱ����
                Fs[14] = (byte)tempDT.Minute; // ��ǰʱ��ķֲ���
                Fs[15] = (byte)tempDT.Second; // ��ǰʱ����벿��
                eBit = CRCVerify.Crc(Fs, 16, 2);
                Fs[16] = eBit[1]; //��λ
                Fs[17] = eBit[0]; //��λ
                return Fs;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region ��վ�������� [25]

        /// <summary>
        /// ��վ��������
        /// </summary>
        /// <param name="iStationAddress">��վ��ַ</param>
        /// <param name="iMark">������־</param>
        /// <param name="iStationHead">��ͷ��ַ</param>
        /// <returns></returns>
        public static byte[] Reset(int iStationAddress, int iMark, int iStationHead)
        {
            try
            {
                //byte[] eBit;
                //byte[] Fs = new byte[12];
                //Fs[0] = 10;
                //for (int i = 1; i <= 5; i++)
                //{
                //    Fs[i] = 255;
                //}
                //Fs[6] = (byte)iStationAddress; // ��վ��
                //Fs[7] = 25; // �����
                //Fs[8] = (byte)iMark; // ������־
                //Fs[9] = (byte)iStationHead; // ̽ͷ��
                //eBit = CRCVerify.Crc(Fs, 10, 1);
                //Fs[10] = eBit[1]; // ��λ
                //Fs[11] = eBit[0]; // ��λ
                //return Fs;

                byte[] eBit;
                byte[] Fs = new byte[13];
                Fs[0] = 00;
                Fs[1] = 10;
                for (int i = 2; i <= 6; i++)
                {
                    Fs[i] = 255;
                }
                Fs[7] = (byte)iStationAddress; // ��վ��
                Fs[8] = 25; // �����
                Fs[9] = (byte)iMark; // ������־
                Fs[10] = (byte)iStationHead; // ̽ͷ��
                eBit = CRCVerify.Crc(Fs, 11, 2);
                Fs[11] = eBit[1]; // ��λ
                Fs[12] = eBit[0]; // ��λ
                return Fs;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region �汾�Ų�ѯ [22]

        /// <summary>
        /// �汾�Ų�ѯ
        /// </summary>
        /// <param name="iStationAddress">��վ��ַ</param>
        /// <param name="iStationHead">̽ͷ��ַ</param>
        /// <param name="iMark">������־</param>
        /// <returns></returns>
        public static byte[] Version(int iStationAddress, int iStationHead, int iMark)
        {
            try
            {
                //byte[] eBit;
                //byte[] Fs = new byte[12];
                //Fs[0] = 10;
                //for (int i = 1; i <= 5; i++)
                //{
                //    Fs[i] = 255;
                //}
                //Fs[6] = (byte)iStationAddress; // ��վ��
                //Fs[7] = 22; // �����
                //Fs[8] = (byte)iMark; // ������־
                //Fs[9] = (byte)iStationHead; // ̽ͷ��
                //eBit = CRCVerify.Crc(Fs, 10, 1);
                //Fs[10] = eBit[1]; // ��λ
                //Fs[11] = eBit[0]; // ��λ
                //return Fs;

                byte[] eBit;
                byte[] Fs = new byte[13];
                Fs[0] = 00;
                Fs[1] = 10;
                for (int i = 2; i <= 6; i++)
                {
                    Fs[i] = 255;
                }
                Fs[7] = (byte)iStationAddress; // ��վ��
                Fs[8] = 22; // �����
                Fs[9] = (byte)iMark; // ������־
                Fs[10] = (byte)iStationHead; // ̽ͷ��
                eBit = CRCVerify.Crc(Fs, 11, 2);
                Fs[11] = eBit[1]; // ��λ
                Fs[12] = eBit[0]; // ��λ
                return Fs;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region ˫��ͨѶ [33]

        /// <summary>
        /// ˫��ͨѶ������б�ʶ����
        /// </summary>
        /// <param name="iStationAddress">�����վ��</param>
        /// <param name="iStationHead">������վ��</param>
        /// /<param name="iCardNO">��ʶ������</param>
        /// <param name="iMark">������־</param>
        /// <returns></returns>       
        public static byte[] TwoMessage(int iStationAddress, int iStationHead, int iCardNO, int iMark)
        {
            try
            {
                //byte[] eBit;
                //byte[] iCard;
                //byte[] Fs = new byte[14];
                //Fs[0] = 10;
                //Fs[1] = 255;
                //Fs[2] = 255;
                //Fs[3] = 255;
                //Fs[4] = 255;
                //Fs[5] = 255;
                //Fs[6] = (byte)iStationAddress; // �����վ��
                //Fs[7] = 33; // �����
                //Fs[8] = (byte)iMark; // ������־
                //Fs[9] = (byte)iStationHead; // ������վ�ţ�0X00 ��0ʱ��ʾ���ж�����վ��

                //iCard = SetCardNO(iCardNO);//��ʶ������(0XFF+0XFF ��65535 ��ΪȺ��)
                //Fs[10] = iCard[0];
                //Fs[11] = iCard[1];
                //eBit = CRCVerify.Crc(Fs, 12, 1);
                //Fs[12] = eBit[1]; // ��λ
                //Fs[13] = eBit[0]; // ��λ
                //return Fs;

                byte[] eBit;
                byte[] iCard;
                byte[] Fs = new byte[15];
                Fs[0] = 00;
                Fs[1] = 10;
                Fs[2] = 255;
                Fs[3] = 255;
                Fs[4] = 255;
                Fs[5] = 255;
                Fs[6] = 255;
                Fs[7] = (byte)iStationAddress; // �����վ��
                Fs[8] = 33; // �����
                Fs[9] = (byte)iMark; // ������־
                Fs[10] = (byte)iStationHead; // ������վ�ţ�0X00 ��0ʱ��ʾ���ж�����վ��

                iCard = SetCardNO(iCardNO);//��ʶ������(0XFF+0XFF ��65535 ��ΪȺ��)
                Fs[11] = iCard[0];
                Fs[12] = iCard[1];
                eBit = CRCVerify.Crc(Fs, 13, 2);
                Fs[13] = eBit[1]; // ��λ
                Fs[14] = eBit[0]; // ��λ
                return Fs;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region�����������Ϳ���ת����byte���顿
        /// <summary>
        /// ���Ϳ���ת����byte����
        /// </summary>
        /// <param name="CardNO">��ʶ������</param>
        /// <returns></returns>
        private static byte[] SetCardNO(int CardNO)
        {
            try
            {
                byte[] icard = BitConverter.GetBytes(CardNO);
                byte[] Fs = new byte[2];
                Fs[0] = icard[1];
                Fs[1] = icard[0];
                return Fs;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        public static byte[] Two(int iStationAddress, int iMark,int iCard,string strMessage)
        {
            try
            {
                byte[] eBit;
                byte[] Fs = new byte[55];
                Fs[0] = 10;
                for (int i = 1; i <= 5; i++)
                {
                    Fs[i] = 255;
                }
                Fs[6] = (byte)iStationAddress; // ��վ��ַ��
                Fs[7] = 19; // �����
                Fs[8] = (byte)iMark; // ������־
                Fs[9] = (byte)43;     // ����
                Fs[10] = (byte)0;            // ����
                if (iCard > 0)
                {
                    if (iCard > 256)
                    {
                        Fs[11] = (byte)(iCard / 256);
                        Fs[12] = (byte)(iCard - 256);
                    }
                    else
                    {
                        Fs[11] = (byte)0;
                        Fs[12] = (byte)iCard;
                    }
                    
                }
                else
                {
                    Fs[11] = (byte)0; // ����
                    Fs[12] = (byte)0; // ����
                }
                byte[] bMessage = new byte[40];
                Encoding.ASCII.GetBytes(strMessage, 0, strMessage.Length, bMessage, 0);
                for (int i = 0; i < 40; i++)
                {
                    Fs[13 + i] = bMessage[i];
                }
                eBit = CRCVerify.Crc(Fs, 53, 1);
                Fs[53] = eBit[1]; //��λ
                Fs[54] = eBit[0]; //��λ
                return Fs;
            }
            catch
            {
                return null;
            }
        }
    }
}
