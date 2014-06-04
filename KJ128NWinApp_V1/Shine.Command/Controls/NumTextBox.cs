using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.ComponentModel;

namespace Shine.Command.Controls
{
    /// <summary>
    /// 此控件由丁静超编写，有空时需要整理
    /// </summary>
    public class NumTextBox : TextBox
    {
         #region [ 声明: 委托 ] 错误消息事件

        /// <summary>
        /// 错误消息声明
        /// </summary>
        /// <param name="iErr"></param>
        /// <param name="strErrInfo"></param>
        public delegate void ErrorMessageEventHandler(int iErr, string strErrInfo);

        /// <summary>
        /// 错误消息事件
        /// </summary>
        public event ErrorMessageEventHandler ErrorMessage;

        #endregion

        #region [ 变量 ]

        protected readonly NumberValidate nv = new NumberValidate();


        

        /// <summary>
        /// 默认验证
        /// </summary>
        protected bool defaultStyle = true;
        /// <summary>
        /// 错误信息
        /// </summary>
        protected string strErr = string.Empty;
        /// <summary>
        /// 错误时保存Text文本
        /// </summary>
        protected string oldText = string.Empty;

        /// <summary>
        /// 默认类型为Int
        /// </summary>
        protected NumberValidate.NumberType numberType = NumberValidate.NumberType.Int;

        #endregion

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        public NumTextBox()
        {
            nv.ErrorMessage += nv_ErrorMessage;
        }

        #endregion

        #region [ 错误处理 ]

        /// <summary>
        /// 错误处理
        /// </summary>
        /// <param name="iErr"></param>
        /// <param name="strErrInfo"></param>
        protected void nv_ErrorMessage(int iErr, string strErrInfo)
        {
            if (defaultStyle)
            {
                ErrStyle();
                Text = strErrInfo;
            }
            else
            {
                // 把错误抛出
                if (ErrorMessage != null)
                {
                    ErrorMessage(iErr, strErrInfo);
                }
            }
            strErr = strErrInfo;
        }

        #endregion

        #region [ 错误默认显示方式 ]

        private void ErrStyle()
        {
            // 已经错误时不处理 只改变显示的错误信息
            if (!ReadOnly)
            {
                ReadOnly = true;
                ForeColor = Color.Red;
                BackColor = Color.White;
                if (oldText == string.Empty)
                {
                    oldText = Text;
                }
            }
        }

        #endregion

        #region [ 方法: 错误后再次输入时效果 ]

        /// <summary>
        /// 错误后再次输入时效果
        /// </summary>
        protected void ErrStyleCancel()
        {
            // 错误后输入
            if (defaultStyle && ReadOnly)
            {
                ReadOnly = false;
                ForeColor = Color.Black;
                Text = oldText;                                 // 恢复原值
                oldText = string.Empty;                         // 清空保存数据
                SelectionStart = Text.Length;                   // 插入点
            }
        }

        #endregion

        #region [ 方法: 鼠标单击控件 ]

        /// <summary>
        /// 鼠标单击控件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            // 取消错误效果
            ErrStyleCancel();
            base.OnMouseClick(e);
        }

        #endregion

        #region [ 属性 ]

        #region [ 属性: 值范围 ]

        /// <summary>
        /// 大小范围
        /// </summary>
        protected string boundValue = "-2147483648-2147483647";

        /// <summary>
        /// 值范围
        /// </summary>
        [Browsable(true)]
        [Description("值范围 格式为 1-10或-10-0,5-10"), Category("自定义")]
        public string BoundValue
        {
            get { return boundValue; }
            set { boundValue = value; }
        }

        #endregion

        #region [ 属性: 负数 ]

        /// <summary>
        /// 是否允许输入负数
        /// </summary>
        protected bool isUseNegative = false;

        /// <summary>
        /// 是否允许输入负数
        /// </summary>
        [Browsable(true)]
        [Description("是否允许输入负数"), Category("自定义")]
        public bool IsUseNegative
        {
            get { return isUseNegative; }
            set { isUseNegative = value; }
        }

        #endregion

        #region [ 属性: 是否允许使用拷贝、剪切、粘贴操作 ]

        /// <summary>
        /// 是否允许使用拷贝操作
        /// </summary>
        protected bool isUseCopy = true;

        /// <summary>
        /// 是否允许使用拷贝操作
        /// </summary>
        [Browsable(true)]
        [Description("是否允许使用拷贝操作 (Ctrl+C)"), Category("自定义")]
        public bool IsUseCopy
        {
            get { return isUseCopy; }
            set { isUseCopy = value; }
        }

        /// <summary>
        /// 是否允许使用剪切操作
        /// </summary>
        protected bool isUseCut = true;

        /// <summary>
        /// 是否允许使用剪切操作
        /// </summary>
        [Browsable(true)]
        [Description("是否允许使用剪切操作 (Ctrl+X)"), Category("自定义")]
        public bool IsUseCut
        {
            get { return isUseCut; }
            set { isUseCut = value; }
        }

        /// <summary>
        /// 是否允许使用粘贴操作
        /// </summary>
        protected bool isUseStickUP = true;

        /// <summary>
        /// 是否允许使用粘贴操作
        /// </summary>
        [Browsable(true)]
        [Description("是否允许使用粘贴操作 (Ctrl+V)"), Category("自定义")]
        public bool IsUseStickUP
        {
            get { return isUseStickUP; }
            set { isUseStickUP = value; }
        }

        #endregion

        #region [ 属性: 默认验证样式 ]
        /// <summary>
        /// 
        /// </summary>
        [Browsable(true)]
        [Description("默认验证样式"), Category("自定义")]
        public bool DefaultStyle
        {
            get { return defaultStyle; }
            set { defaultStyle = value; }
        }

        #endregion

        #region [ 属性: 错误信息 ]
        /// <summary>
        /// 
        /// </summary>
        [Browsable(true)]
        [Description("错误信息"), Category("自定义")]
        public string ErrorMassage
        {
            get { return strErr; }
        }

        #region [ 属性: 类型 ]
        /// <summary>
        /// 
        /// </summary>
        [Browsable(true)]
        [Description("类型"), Category("自定义")]
        public NumberValidate.NumberType NumberTypes
        {
            get { return numberType; }
            set { numberType = value; }
        }

        #endregion

        #endregion

        #endregion

        #region [ 方法: 输入处理 ]

        /// <summary>
        /// OnKeyPress 事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            int keyChar = (int)e.KeyChar;

            // 文本所有数据
            string strAllText = string.Empty;

            // 新输入的数据
            string strInputText = Convert.ToString(e.KeyChar);

            #region [ 复制 剪切 粘贴 ]

            // 复制                       剪切
            if (isUseCopy && (keyChar == 3 || keyChar == 24))
            {
                // 取消错误效果
                ErrStyleCancel();
                return;
            }

            // 粘贴
            if (isUseStickUP && keyChar == 22)
            {
                // 获得剪贴板数据
                string strClipboard = nv.ClipboardValidate();
                if (strClipboard == string.Empty)
                {
                    e.Handled = true;
                }
                else
                {
                    // 剪贴板数据赋给输入数据
                    strInputText = strClipboard;
                    e.Handled = false;
                }
            }

            #endregion

            #region [ 新输入的数据和原数据 拼接 ]

            if (!ReadOnly)
            {
                // 把数字插入到光标点
                if (SelectionLength > 0)
                {
                    int iStart = SelectionStart;
                    strAllText = Replace(Text, strInputText, SelectionStart, SelectionStart + SelectionLength);
                }
                else
                {
                    strAllText = Text.Insert(SelectionStart, strInputText);
                }
            }
            else
            {
                strAllText = oldText + strInputText;
            }

            #endregion

            #region [ 退格键的处理 ]

            // 验证错误状态下 点击退格
            if (keyChar == 8)
            {
                if (ReadOnly)
                {
                    // 取消错误效果
                    ErrStyleCancel();
                    e.Handled = true;
                    SelectionStart = Text.Length;
                }
                else
                {
                    //插入数据为空
                    e.Handled = false;
                }
                return;
            }

            #endregion

            #region [ 负数处理 ]

            // 只能输入一个负号
            if (keyChar == 45)
            {
                if (isUseNegative)
                {
                    if (strAllText.LastIndexOf("-") < 1)
                    {
                        // 取消错误效果
                        ErrStyleCancel();
                        e.Handled = false;
                        return;
                    }
                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }

            #endregion

            #region [ 验证数据 ]

            if (nv.CheckNumber((NumberValidate.NumberType)numberType, strAllText, boundValue))
            {
                // 取消错误效果
                ErrStyleCancel();
                base.OnKeyPress(e);
            }
            else
            {
                e.Handled = true;
            }

            #endregion
        }

        #endregion

        #region [ 方法: 替换指定位置字符串 ]

        /// <summary>
        /// 替换指定位置字符串
        /// </summary>
        /// <param name="strInfo">原字符串</param>    
        /// <param name="strReplace">要替换的字符串</param>
        /// <param name="iStart">从strInfo要替换的开始位置</param>
        /// <param name="iEnd">从strInfo要替换的结束位置</param>
        /// <returns></returns>
        private string Replace(string strInfo, string strReplace, int iStart, int iEnd)
        {
            string strStart = strInfo.Substring(0, iStart);
            string strEnd = strInfo.Substring(iEnd);
            return strStart + strReplace + strEnd;
        }

        #endregion
    }

    
    #region [ 类: 验证数据使用的方法 ]

    /// <summary>
    /// 验证数字
    /// </summary>
    public class NumberValidate
    {

        #region [ 声明: 委托 ] 错误消息声明

        /// <summary>
        /// 错误消息声明
        /// </summary>
        /// <param name="iErr"></param>
        /// <param name="strErrInfo"></param>
        public delegate void ErrorMessageEventHandler(int iErr, string strErrInfo);

        /// <summary>
        /// 错误消息事件
        /// </summary>
        public event ErrorMessageEventHandler ErrorMessage;

        #endregion

        #region [ 方法: 判断KeyChar是否为数字和退格 ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyChar"></param>
        /// <returns></returns>
        public bool KeyCharValidate(int keyChar)
        {
            #region [ 退格处理 ]
            if (keyChar == 8)
            {
                keyChar = 48;
            }
            #endregion

            if (keyChar < 48 || keyChar > 57)
            {
                ErrorMessage(1, "格式不正确:" + ((char)keyChar).ToString());
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region [ 方法: 数据添加到剪贴板 ]

        /// <summary>
        /// 数据添加到剪贴板
        /// </summary>
        /// <param name="value"></param>
        public void SetClipboard(string value)
        {
            IDataObject cb = Clipboard.GetDataObject();
            cb.SetData(DataFormats.Text, value);
            cb = null;
        }

        #endregion

        #region [ 方法: 判断数值范围 ]

        /// <summary>
        /// 判断数值范围
        /// </summary>
        /// <param name="boundValue"></param>
        /// <param name="objValue"></param>
        /// <param name="numberType"></param>
        /// <returns></returns>
        private bool CheckBoundValue(string boundValue, object objValue, NumberType numberType)
        {
            string[] strAll = boundValue.Split(',');
            // 类型为 Int和BeginInt
            if (numberType == NumberType.Int || numberType == NumberType.Begint)
            {
                int value = int.Parse(objValue.ToString());
                bool _bl = false;
                string strErr = "数字[" + objValue.ToString() + "]不在 ";
                #region
                foreach (string strBound in strAll)
                {
                    string[] s = strBound.Split('-');
                    // 一个数时
                    if (s.Length == 1)
                    {
                        if (value == int.Parse(s[0]))
                        {
                            return true;
                        }
                        strErr += s[0] + ",";
                    }
                    else if (s.Length == 2)
                    {
                        if (value >= Convert.ToInt64(s[0]) && value <= Convert.ToInt64(s[1]))
                        {
                            return true;
                        }
                        strErr += s[0] + "-" + s[1] + ",";
                    }
                    // 有负数时
                    else if (s.Length == 3)
                    {
                        if (value >= Convert.ToInt64("-" + s[1].ToString()) && value <= Convert.ToInt64(s[2].ToString()))
                        {
                            return true;
                        }
                        strErr += "-" + s[1] + "-" + s[2] + ",";
                    }
                }
                #endregion
                strErr = strErr.Substring(0, strErr.Length-1) + " 范围中";
                ErrorMessage(1, strErr);
                return _bl;
            }
            // 类型为 Float
            if (numberType == NumberType.Float)
            {
                float fValue = Convert.ToSingle(objValue.ToString());
                bool _bl = false;
                string strErr = "数字[" + objValue.ToString() + "]不在 ";
                #region
                foreach (string strBound in strAll)
                {
                    string[] s = strBound.Split('-');
                    // 一个数时
                    if (s.Length == 1)
                    {
                        if (fValue == Convert.ToSingle(s[0].ToString()))
                        {
                            return true;
                        }
                        strErr += s[0] + ",";
                    }
                    else if (s.Length == 2)
                    {
                        if (fValue >= Convert.ToSingle(s[0].ToString()) && fValue <= Convert.ToSingle(s[1].ToString()))
                        {
                            return true;
                        }
                        strErr += s[0] + "-" + s[1] + ",";
                    }
                    // 有负数时
                    else if (s.Length == 3)
                    {
                        if (fValue >= Convert.ToSingle("-" + s[1].ToString()) && fValue <= Convert.ToSingle(s[2].ToString()))
                        {
                            return true;
                        }
                        strErr += "-" + s[1] + "-" + s[2] + ",";
                    }
                }
                #endregion
                strErr = strErr.Substring(0, strErr.Length-1) + " 范围中";
                ErrorMessage(1, strErr);
                return _bl;
            }

            return true;
        }

        #endregion

        #region [ 方法: 验证数据 ]

        /// <summary>
        /// 验证数据
        /// </summary>
        /// <param name="numberType"></param>
        /// <param name="strInfo"></param>
        /// <param name="boundValue"></param>
        /// <returns></returns>
        public bool CheckNumber(NumberType numberType, string strInfo, string boundValue)
        {
            // 类型判断
            switch (numberType)
            {
                case NumberType.Int:
                    #region
                    try
                    {
                        int iTmp = Convert.ToInt32(strInfo);
                        if (!CheckBoundValue(boundValue, iTmp, numberType))
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {
                        // 错误 跳出
                        ErrorMessage(1, "格式错误");
                        return false;
                    }
                    #endregion
                    break;
                case NumberType.Float:
                    #region
                    try
                    {
                        float fTmp = Convert.ToSingle(strInfo);
                        if (!CheckBoundValue(boundValue, strInfo, numberType))
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {
                        // 错误 跳出
                        ErrorMessage(1, "格式错误");
                        return false;
                    }
                    #endregion
                    break;
                case NumberType.Begint:
                    #region
                    try
                    {
                        int iTmp = Convert.ToInt32(strInfo);
                        if (!CheckBoundValue(boundValue, strInfo, numberType))
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {
                        // 错误 跳出
                        ErrorMessage(1, "格式错误");
                        return false;
                    }
                    #endregion
                    break;
                default:
                    break;
            }
            return true;
        }

        #endregion

        #region [ 枚举: 类型 ]

        /// <summary>
        /// 类型
        /// </summary>
        public enum NumberType
        {
            /// <summary>
            /// int32
            /// </summary>
            Int = 1,
            /// <summary>
            /// float
            /// </summary>
            Float = 2,
            /// <summary>
            /// bigint
            /// </summary>
            Begint = 3
        }

        #endregion

        #region [ 方法: 剪贴板数据验证 ]

        /// <summary>
        /// 剪贴板数据验证
        /// </summary>
        /// <returns></returns>
        public string ClipboardValidate()
        {
            IDataObject cb = Clipboard.GetDataObject();
            if (cb.GetDataPresent(DataFormats.Text))
            {
                return (String)cb.GetData(DataFormats.Text);
            }
            else
            {
                return "";
            }
        }

        #endregion
    }

    #endregion
}
