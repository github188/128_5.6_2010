using System;
using System.Collections;
using System.Text.RegularExpressions;//������ʽ�����
namespace ZdcCommonLibrary
{
    /// <summary>
    /// ��֤���������������֤�ı������֣����ڣ�ʱ���
    /// </summary>
    public class CheckingInputOutput
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public CheckingInputOutput()
        {
        }
        #region ����
        /// <summary>
        /// ��֤�ַ��еĳ���
        /// </summary>
        /// <param name="checkingString">����֤���ַ���</param>
        /// <param name="stringMaxLength">��󳤶�</param>
        /// <param name="stringMinLength">��С����</param>
        /// <returns>true ,��֤�ɹ���false ��֤ʧ��</returns>
        public bool CheckingString(string checkingString,int stringMaxLength,int stringMinLength)
        {
            if (checkingString.Length >= stringMinLength && checkingString.Length <= stringMaxLength)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        
        /// <summary>
        ///  �����û�������ַ�������֤�Ƿ��Ƿ���Ҫ�������
        /// </summary>
        /// <param name="inputString">������ַ���</param>
        /// <param name="minValue">��Сֵ</param>
        /// <param name="maxValue">���ֵ</param>
        /// <returns>true ����Ҫ��false ������Ҫ��</returns>
        public bool CheckingNumber(string inputString,int minValue,int maxValue)
    {
        
            
            return true;
            
    }
        #endregion
    }
}