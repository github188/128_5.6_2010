namespace KJ128A.Protocol
{
    /// <summary>
    /// 校验类
    /// </summary>
    public class CRCVerify
    {
        #region Crc16校验方法

        private static readonly CRC16.CRC16 m_crc16 = new CRC16.CRC16();

        /// <summary>
        /// Crc16效验方法
        /// </summary>
        /// <param name="getByte">要效验得字节</param>
        /// <param name="lenth">效验得长度</param>
        /// <param name="handIndex">要效验字节得开始位置</param>
        /// <returns>效验字节 byte[0]为高位，byte[1]为低位</returns>
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

        #region 验证命令是否合法

        /// <summary>
        /// 验证命令是否合法
        /// </summary>
        /// <param name="cmdBytes"></param>
        /// <param name="int_Length"></param>
        /// <param name="int_Index"></param>
        /// <returns></returns>
        public static bool CmdCrc(byte[] cmdBytes, int int_Length, int int_Index)
        {
            try
            {
                // 得到校验位（此长度去掉了校验位 注：校验位在命令总长中占两个字节）
                byte[] eBit = Crc(cmdBytes, int_Length - 2, int_Index);

                // 效验位判断和基站号判断
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
