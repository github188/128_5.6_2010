using System;
using System.Text;
using System.Windows.Forms;

namespace KJ128A.Controls.Batman
{
    /// <summary>
    /// ��Ϣ�ı���
    /// </summary>
    public class KJRichTextBox: RichTextBox
    {
        #region [ ���� ] KJMaxLength

        private int iKJMaxLength = 102400;

        //��ʶ���ʵ����������
        private string strTitle = string.Empty;
        /// <summary>
        /// ��󳤶ȣ������ó����Զ����
        /// </summary>
        public int KJMaxLength
        {
            get { return iKJMaxLength; }
            set { iKJMaxLength = value; }
        }

        #endregion

        #region [ ���캯�� ]

        /// <summary>
        /// KJRichTextBox���캯��
        /// </summary>
        /// <param name="strTitle">���ͷ</param>
        public KJRichTextBox(string strTitle)
        {
            this.strTitle = strTitle;
        }

        #endregion

        #region [ ���� ] ��ʾ��Ϣ [ �ı� ]

        private delegate void SetTextCallbackByText(string txtMsg, string strTip, bool blnIsShowTime,System.Drawing.Color color);

        /// <summary>
        /// ��ʾ��Ϣ
        /// </summary>
        public void WriteTxt(string txtMsg, string strTip, bool blnIsShowTime, System.Drawing.Color color)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    SetTextCallbackByText d = new SetTextCallbackByText(WriteTxt);
                    this.Invoke(d, new object[] { txtMsg, strTip, blnIsShowTime, color });
                }
                else
                {
                    //this.Focus();

                    try
                    {
                        StringBuilder strBuilder = new StringBuilder();

                        if (blnIsShowTime)
                        {
                            strBuilder.Append(DateTime.Now.ToLongTimeString());
                        }

                        strBuilder.Append(strTip + ":\t");

                        strBuilder.Append(txtMsg);
                        strBuilder.Append("\n");

                        this.SelectionStart = this.Text.Length;
                        this.SelectionColor = color;
                        this.AppendText(strBuilder.ToString());

                        strBuilder = null;

                        SaveTmpFile();      //������ʱ�ı��ļ�

                        if (this.Text.Length > KJMaxLength)
                        {
                            SaveFile();     //�����ı��ļ���
                            this.Text = "";
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            { }
        }

        #endregion

        #region [ ����: �����ļ� ]

        /// <summary>
        /// �����ļ�
        /// </summary>
        public void SaveFile()
        {
            try
            {
                DateTime dtNow = DateTime.Now;
                if (!System.IO.Directory.Exists(@"log\" + dtNow.Year + "-" + dtNow.Month + "-" + dtNow.Day))
                {
                    System.IO.Directory.CreateDirectory(@"log\" + dtNow.Year + "-" + dtNow.Month + "-" + dtNow.Day);
                }

                SaveFile(@"log\" + dtNow.Year + "-" + dtNow.Month + "-" + dtNow.Day + @"\" + strTitle + "-" +  dtNow.Hour + "_" + dtNow.Minute + "_" + dtNow.Second + ".rtf");
                string[] strDirs = System.IO.Directory.GetDirectories(System.IO.Directory.GetCurrentDirectory() + "\\log");
                if (strDirs.Length > 7)
                {
                    for (int i = 0; i < strDirs.Length; i++)
                    {
                        try
                        {
                            DateTime dtTime = DateTime.Parse(strDirs[i].Substring(strDirs[i].LastIndexOf("\\") + 1));
                            if (dtTime<dtNow.AddDays(-7))
                            {
                                System.IO.Directory.Delete(strDirs[i],true);
                            }
                        }
                        catch { }
                    }
                }
            }
            catch
            {
                // App.KJTp_SysMsg.WriteErrMsg("[KJTabPage:SaveFile]" + ex.Message, 3000);
            }
        }

        /// <summary>
        /// �����ļ� (��ʱ�ļ�)
        /// </summary>
        public void SaveTmpFile()
        {
            try
            {
                if (!System.IO.Directory.Exists(@"tmp"))
                {
                    System.IO.Directory.CreateDirectory(@"tmp");
                }
                SaveFile(@"tmp\$" +strTitle+  "_tmp.rtf");
            }
            catch
            {
                //App.KJTp_SysMsg.WriteErrMsg("[KJTabPage:SaveTmpFile]" + ex.Message, 3000);
            }
        }

        #endregion

        #region  [ ���� ] ��ʾ��Ϣ [ �ֽ� ]

        private delegate void SetTextCallbackByBytes(byte[] txtBytes, string strTip, bool blnIsShowTime, int iLocStart);

        /// <summary>
        /// ��ʾ��Ϣ
        /// </summary>
        public void WriteTxt(byte[] txtBytes, string strTip, bool blnIsShowTime, int iLocStart)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    SetTextCallbackByBytes d = new SetTextCallbackByBytes(WriteTxt);
                    this.Invoke(d, new object[] { txtBytes, strTip, blnIsShowTime, iLocStart });
                }
                else
                {
                    //this.Focus();

                    try
                    {
                        StringBuilder strBuilder = new StringBuilder();

                        if (blnIsShowTime)
                        {
                            strBuilder.Append(DateTime.Now.ToLongTimeString());
                        }

                        strBuilder.Append(strTip + ":\t");

                        for (int j = iLocStart; j < txtBytes.Length; j++)
                        {
                            strBuilder.Append(txtBytes[j].ToString("X2"));
                            strBuilder.Append(" ");
                        }
                        strBuilder.Append("\n");

                        this.AppendText(strBuilder.ToString());

                        strBuilder = null;

                        SaveTmpFile();      //������ʱ�ı��ļ�

                        if (this.Text.Length > KJMaxLength)
                        {
                            SaveFile();     //�����ı��ļ���
                            this.Text = "";
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch { }
        }

        #endregion


        #region  [ ���� ] ��ʾ��Ϣ [ �ֽ� ]

        private delegate void SetTextCallbackByBytes2(byte[] txtBytes);

        /// <summary>
        /// ��ʾ��Ϣ
        /// </summary>
        public void WriteTxt(byte[] txtBytes)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    SetTextCallbackByBytes2 d = new SetTextCallbackByBytes2(WriteTxt);
                    this.Invoke(d, new object[] { txtBytes });
                }
                else
                {
                    //this.Focus();

                    try
                    {
                        StringBuilder strBuilder = new StringBuilder();

                        for (int j = 0; j < txtBytes.Length; j++)
                        {
                            strBuilder.Append(txtBytes[j].ToString("X2"));
                            strBuilder.Append(" ");
                        }
                        strBuilder.Append("\n");

                        this.AppendText(strBuilder.ToString());

                        strBuilder = null;

                        if (this.Text.Length > KJMaxLength)
                        {
                            this.Text = "";
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch { }
        }

        #endregion

    }
}
