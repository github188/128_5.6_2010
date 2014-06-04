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
    /// �˿ؼ��ɶ�������д���п�ʱ��Ҫ����
    /// </summary>
    public class NumTextBox : TextBox
    {
         #region [ ����: ί�� ] ������Ϣ�¼�

        /// <summary>
        /// ������Ϣ����
        /// </summary>
        /// <param name="iErr"></param>
        /// <param name="strErrInfo"></param>
        public delegate void ErrorMessageEventHandler(int iErr, string strErrInfo);

        /// <summary>
        /// ������Ϣ�¼�
        /// </summary>
        public event ErrorMessageEventHandler ErrorMessage;

        #endregion

        #region [ ���� ]

        protected readonly NumberValidate nv = new NumberValidate();


        

        /// <summary>
        /// Ĭ����֤
        /// </summary>
        protected bool defaultStyle = true;
        /// <summary>
        /// ������Ϣ
        /// </summary>
        protected string strErr = string.Empty;
        /// <summary>
        /// ����ʱ����Text�ı�
        /// </summary>
        protected string oldText = string.Empty;

        /// <summary>
        /// Ĭ������ΪInt
        /// </summary>
        protected NumberValidate.NumberType numberType = NumberValidate.NumberType.Int;

        #endregion

        #region [ ���캯�� ]

        /// <summary>
        /// ���캯��
        /// </summary>
        public NumTextBox()
        {
            nv.ErrorMessage += nv_ErrorMessage;
        }

        #endregion

        #region [ ������ ]

        /// <summary>
        /// ������
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
                // �Ѵ����׳�
                if (ErrorMessage != null)
                {
                    ErrorMessage(iErr, strErrInfo);
                }
            }
            strErr = strErrInfo;
        }

        #endregion

        #region [ ����Ĭ����ʾ��ʽ ]

        private void ErrStyle()
        {
            // �Ѿ�����ʱ������ ֻ�ı���ʾ�Ĵ�����Ϣ
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

        #region [ ����: ������ٴ�����ʱЧ�� ]

        /// <summary>
        /// ������ٴ�����ʱЧ��
        /// </summary>
        protected void ErrStyleCancel()
        {
            // ���������
            if (defaultStyle && ReadOnly)
            {
                ReadOnly = false;
                ForeColor = Color.Black;
                Text = oldText;                                 // �ָ�ԭֵ
                oldText = string.Empty;                         // ��ձ�������
                SelectionStart = Text.Length;                   // �����
            }
        }

        #endregion

        #region [ ����: ��굥���ؼ� ]

        /// <summary>
        /// ��굥���ؼ�
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            // ȡ������Ч��
            ErrStyleCancel();
            base.OnMouseClick(e);
        }

        #endregion

        #region [ ���� ]

        #region [ ����: ֵ��Χ ]

        /// <summary>
        /// ��С��Χ
        /// </summary>
        protected string boundValue = "-2147483648-2147483647";

        /// <summary>
        /// ֵ��Χ
        /// </summary>
        [Browsable(true)]
        [Description("ֵ��Χ ��ʽΪ 1-10��-10-0,5-10"), Category("�Զ���")]
        public string BoundValue
        {
            get { return boundValue; }
            set { boundValue = value; }
        }

        #endregion

        #region [ ����: ���� ]

        /// <summary>
        /// �Ƿ��������븺��
        /// </summary>
        protected bool isUseNegative = false;

        /// <summary>
        /// �Ƿ��������븺��
        /// </summary>
        [Browsable(true)]
        [Description("�Ƿ��������븺��"), Category("�Զ���")]
        public bool IsUseNegative
        {
            get { return isUseNegative; }
            set { isUseNegative = value; }
        }

        #endregion

        #region [ ����: �Ƿ�����ʹ�ÿ��������С�ճ������ ]

        /// <summary>
        /// �Ƿ�����ʹ�ÿ�������
        /// </summary>
        protected bool isUseCopy = true;

        /// <summary>
        /// �Ƿ�����ʹ�ÿ�������
        /// </summary>
        [Browsable(true)]
        [Description("�Ƿ�����ʹ�ÿ������� (Ctrl+C)"), Category("�Զ���")]
        public bool IsUseCopy
        {
            get { return isUseCopy; }
            set { isUseCopy = value; }
        }

        /// <summary>
        /// �Ƿ�����ʹ�ü��в���
        /// </summary>
        protected bool isUseCut = true;

        /// <summary>
        /// �Ƿ�����ʹ�ü��в���
        /// </summary>
        [Browsable(true)]
        [Description("�Ƿ�����ʹ�ü��в��� (Ctrl+X)"), Category("�Զ���")]
        public bool IsUseCut
        {
            get { return isUseCut; }
            set { isUseCut = value; }
        }

        /// <summary>
        /// �Ƿ�����ʹ��ճ������
        /// </summary>
        protected bool isUseStickUP = true;

        /// <summary>
        /// �Ƿ�����ʹ��ճ������
        /// </summary>
        [Browsable(true)]
        [Description("�Ƿ�����ʹ��ճ������ (Ctrl+V)"), Category("�Զ���")]
        public bool IsUseStickUP
        {
            get { return isUseStickUP; }
            set { isUseStickUP = value; }
        }

        #endregion

        #region [ ����: Ĭ����֤��ʽ ]
        /// <summary>
        /// 
        /// </summary>
        [Browsable(true)]
        [Description("Ĭ����֤��ʽ"), Category("�Զ���")]
        public bool DefaultStyle
        {
            get { return defaultStyle; }
            set { defaultStyle = value; }
        }

        #endregion

        #region [ ����: ������Ϣ ]
        /// <summary>
        /// 
        /// </summary>
        [Browsable(true)]
        [Description("������Ϣ"), Category("�Զ���")]
        public string ErrorMassage
        {
            get { return strErr; }
        }

        #region [ ����: ���� ]
        /// <summary>
        /// 
        /// </summary>
        [Browsable(true)]
        [Description("����"), Category("�Զ���")]
        public NumberValidate.NumberType NumberTypes
        {
            get { return numberType; }
            set { numberType = value; }
        }

        #endregion

        #endregion

        #endregion

        #region [ ����: ���봦�� ]

        /// <summary>
        /// OnKeyPress �¼�
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            int keyChar = (int)e.KeyChar;

            // �ı���������
            string strAllText = string.Empty;

            // �����������
            string strInputText = Convert.ToString(e.KeyChar);

            #region [ ���� ���� ճ�� ]

            // ����                       ����
            if (isUseCopy && (keyChar == 3 || keyChar == 24))
            {
                // ȡ������Ч��
                ErrStyleCancel();
                return;
            }

            // ճ��
            if (isUseStickUP && keyChar == 22)
            {
                // ��ü���������
                string strClipboard = nv.ClipboardValidate();
                if (strClipboard == string.Empty)
                {
                    e.Handled = true;
                }
                else
                {
                    // ���������ݸ�����������
                    strInputText = strClipboard;
                    e.Handled = false;
                }
            }

            #endregion

            #region [ ����������ݺ�ԭ���� ƴ�� ]

            if (!ReadOnly)
            {
                // �����ֲ��뵽����
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

            #region [ �˸���Ĵ��� ]

            // ��֤����״̬�� ����˸�
            if (keyChar == 8)
            {
                if (ReadOnly)
                {
                    // ȡ������Ч��
                    ErrStyleCancel();
                    e.Handled = true;
                    SelectionStart = Text.Length;
                }
                else
                {
                    //��������Ϊ��
                    e.Handled = false;
                }
                return;
            }

            #endregion

            #region [ �������� ]

            // ֻ������һ������
            if (keyChar == 45)
            {
                if (isUseNegative)
                {
                    if (strAllText.LastIndexOf("-") < 1)
                    {
                        // ȡ������Ч��
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

            #region [ ��֤���� ]

            if (nv.CheckNumber((NumberValidate.NumberType)numberType, strAllText, boundValue))
            {
                // ȡ������Ч��
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

        #region [ ����: �滻ָ��λ���ַ��� ]

        /// <summary>
        /// �滻ָ��λ���ַ���
        /// </summary>
        /// <param name="strInfo">ԭ�ַ���</param>    
        /// <param name="strReplace">Ҫ�滻���ַ���</param>
        /// <param name="iStart">��strInfoҪ�滻�Ŀ�ʼλ��</param>
        /// <param name="iEnd">��strInfoҪ�滻�Ľ���λ��</param>
        /// <returns></returns>
        private string Replace(string strInfo, string strReplace, int iStart, int iEnd)
        {
            string strStart = strInfo.Substring(0, iStart);
            string strEnd = strInfo.Substring(iEnd);
            return strStart + strReplace + strEnd;
        }

        #endregion
    }

    
    #region [ ��: ��֤����ʹ�õķ��� ]

    /// <summary>
    /// ��֤����
    /// </summary>
    public class NumberValidate
    {

        #region [ ����: ί�� ] ������Ϣ����

        /// <summary>
        /// ������Ϣ����
        /// </summary>
        /// <param name="iErr"></param>
        /// <param name="strErrInfo"></param>
        public delegate void ErrorMessageEventHandler(int iErr, string strErrInfo);

        /// <summary>
        /// ������Ϣ�¼�
        /// </summary>
        public event ErrorMessageEventHandler ErrorMessage;

        #endregion

        #region [ ����: �ж�KeyChar�Ƿ�Ϊ���ֺ��˸� ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyChar"></param>
        /// <returns></returns>
        public bool KeyCharValidate(int keyChar)
        {
            #region [ �˸��� ]
            if (keyChar == 8)
            {
                keyChar = 48;
            }
            #endregion

            if (keyChar < 48 || keyChar > 57)
            {
                ErrorMessage(1, "��ʽ����ȷ:" + ((char)keyChar).ToString());
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region [ ����: ������ӵ������� ]

        /// <summary>
        /// ������ӵ�������
        /// </summary>
        /// <param name="value"></param>
        public void SetClipboard(string value)
        {
            IDataObject cb = Clipboard.GetDataObject();
            cb.SetData(DataFormats.Text, value);
            cb = null;
        }

        #endregion

        #region [ ����: �ж���ֵ��Χ ]

        /// <summary>
        /// �ж���ֵ��Χ
        /// </summary>
        /// <param name="boundValue"></param>
        /// <param name="objValue"></param>
        /// <param name="numberType"></param>
        /// <returns></returns>
        private bool CheckBoundValue(string boundValue, object objValue, NumberType numberType)
        {
            string[] strAll = boundValue.Split(',');
            // ����Ϊ Int��BeginInt
            if (numberType == NumberType.Int || numberType == NumberType.Begint)
            {
                int value = int.Parse(objValue.ToString());
                bool _bl = false;
                string strErr = "����[" + objValue.ToString() + "]���� ";
                #region
                foreach (string strBound in strAll)
                {
                    string[] s = strBound.Split('-');
                    // һ����ʱ
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
                    // �и���ʱ
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
                strErr = strErr.Substring(0, strErr.Length-1) + " ��Χ��";
                ErrorMessage(1, strErr);
                return _bl;
            }
            // ����Ϊ Float
            if (numberType == NumberType.Float)
            {
                float fValue = Convert.ToSingle(objValue.ToString());
                bool _bl = false;
                string strErr = "����[" + objValue.ToString() + "]���� ";
                #region
                foreach (string strBound in strAll)
                {
                    string[] s = strBound.Split('-');
                    // һ����ʱ
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
                    // �и���ʱ
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
                strErr = strErr.Substring(0, strErr.Length-1) + " ��Χ��";
                ErrorMessage(1, strErr);
                return _bl;
            }

            return true;
        }

        #endregion

        #region [ ����: ��֤���� ]

        /// <summary>
        /// ��֤����
        /// </summary>
        /// <param name="numberType"></param>
        /// <param name="strInfo"></param>
        /// <param name="boundValue"></param>
        /// <returns></returns>
        public bool CheckNumber(NumberType numberType, string strInfo, string boundValue)
        {
            // �����ж�
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
                        // ���� ����
                        ErrorMessage(1, "��ʽ����");
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
                        // ���� ����
                        ErrorMessage(1, "��ʽ����");
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
                        // ���� ����
                        ErrorMessage(1, "��ʽ����");
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

        #region [ ö��: ���� ]

        /// <summary>
        /// ����
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

        #region [ ����: ������������֤ ]

        /// <summary>
        /// ������������֤
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
