namespace KJ128A.Protocol
{
    /// <summary>
    /// У����
    /// </summary>
    public class CRCVerify
    {
        #region Crc16У�鷽��

        private static readonly CRC16.CRC16 m_crc16 = new CRC16.CRC16();

        /// <summary>
        /// Crc16Ч�鷽��
        /// </summary>
        /// <param name="getByte">ҪЧ����ֽ�</param>
        /// <param name="lenth">Ч��ó���</param>
        /// <param name="handIndex">ҪЧ���ֽڵÿ�ʼλ��</param>
        /// <returns>Ч���ֽ� byte[0]Ϊ��λ��byte[1]Ϊ��λ</returns>
        public static byte[] Crc(byte[] getByte, int lenth, int handIndex)
        {
            lenth--;
            byte[] eBit;

            try
            {
                if (getByte.Length < 7) return null;
                eBit = m_crc16.CRC(getByte, (short)lenth, (short)handIndex);
            }
            catch
            {
                eBit = null;
            }

            return eBit;
        }

        #endregion

        #region ��֤�����Ƿ�Ϸ�

        /// <summary>
        /// ��֤�����Ƿ�Ϸ�
        /// </summary>
        /// <param name="cmdBytes"></param>
        /// <param name="int_Length"></param>
        /// <param name="int_Index"></param>
        /// <returns></returns>
        public static bool CmdCrc(byte[] cmdBytes, int int_Length, int int_Index)
        {
            try
            {
                // �õ�У��λ���˳���ȥ����У��λ ע��У��λ�������ܳ���ռ�����ֽڣ�
                byte[] eBit = Crc(cmdBytes, int_Length - 2, int_Index);

                // Ч��λ�жϺͻ�վ���ж�
                if (eBit != null)
                {
                    if (eBit[0] == cmdBytes[int_Length - 1] && eBit[1] == cmdBytes[int_Length - 2])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
