using System;
using System.Collections;
using System.Text.RegularExpressions;//正则表达式的类库
namespace ZdcCommonLibrary
{
    /// <summary>
    /// 验证输入输出，可以验证文本，数字，日期，时间等
    /// </summary>
    public class CheckingInputOutput
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CheckingInputOutput()
        {
        }
        #region 方法
        /// <summary>
        /// 验证字符中的长度
        /// </summary>
        /// <param name="checkingString">需验证的字符串</param>
        /// <param name="stringMaxLength">最大长度</param>
        /// <param name="stringMinLength">最小长度</param>
        /// <returns>true ,验证成功　false 验证失败</returns>
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
        ///  根据用户输入的字符串，验证是否是符合要求的数字
        /// </summary>
        /// <param name="inputString">输入的字符串</param>
        /// <param name="minValue">最小值</param>
        /// <param name="maxValue">最大值</param>
        /// <returns>true 符合要求　false 不符合要求</returns>
        public bool CheckingNumber(string inputString,int minValue,int maxValue)
    {
        
            
            return true;
            
    }
        #endregion
    }
}