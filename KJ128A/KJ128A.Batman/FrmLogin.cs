using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using KJ128A.BatmanAPI;
using KJ128A.Controls.Batman;
using KJ128NMainRun;

namespace KJ128A.Batman
{
    /// <summary>
    /// ��¼����
    /// </summary>
    public partial class FrmLogin : Form
    {
        #region [ ����: ί�� ] ������Ϣ�¼�

        #region Delegates

        /// <summary>
        /// ������Ϣ����
        /// </summary>
        /// <param name="iErrNO">������</param>
        /// <param name="strStackTrace">��ȡ��ǰ�쳣����ʱ���ö�ջ�ϵ�֡���ַ�����ʾ��ʽ</param>
        /// <param name="strSource">��ʶ��ǰ��һ�γ�����Ĵ���</param>
        /// <param name="strMessage">��ȡ������ǰ�쳣����Ϣ</param>
        public delegate void ErrorMessageEventHandler(
            int iErrNO, string strStackTrace, string strSource, string strMessage);

        #endregion

        /// <summary>
        /// ������Ϣ�¼�
        /// </summary>
        public event ErrorMessageEventHandler ErrorMessage;

        #endregion

        private readonly IFrmMain frmMain = null;
        private readonly string strPath = "Login.xml";

        #region [ ���캯�� ]

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="frm">������</param>
        /// <param name="strFilePath">�ļ�����·��</param>
        public FrmLogin(IFrmMain frm, string strFilePath)
        {
            InitializeComponent();

            strPath = System.Windows.Forms.Application.StartupPath.ToString() + @"\" + strFilePath;
            frmMain = frm;
        }

        #endregion

        #region [ �¼�: ��¼��ť ]

        private void btnLoginIn_Click(object sender, EventArgs e)
        {
            // �ж��Ƿ��������û���������
            string strLoginName = txtLoginName.Text.Trim(); // �û���
            string strPwd = txtPassword.Text.Trim(); // ����

            if (strLoginName == "" || strPwd == "")
            {
                ErrorMessage(3010007, string.Empty, "[FrmLogin:btnLoginIn_Click]", string.Empty);
                return;
            }
            // ��ȡȨ��
            int iComp = Proving(Crypt.Encrypt(strLoginName), Crypt.MD5_16(strPwd));

            if (iComp != 0)
            {
                // ��¼��¼��
                frmMain.SetLoginInfo(strLoginName);

                EnumPowers enumComp = (EnumPowers) iComp;

                // ���ݲ�ͬ��Ȩ�ޣ����ز�ͬ�Ĳ˵�
                frmMain.MenuPowerChange(enumComp);

                // ��ʾ��¼�ɹ�
                ErrorMessage(8010020, string.Empty, "[FrmLogin:btnLoginIn_Click]", strLoginName);

                Close();
            }
        }

        #endregion

        #region [ �¼�: ȡ����ť ]

        private void btnLoginOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region [ ����: ��֤�û��������Ƿ���ȷ����ȡȨ�� ]

        /// <summary>
        /// ��֤�û��������Ƿ���ȷ����ȡȨ��
        /// </summary>
        /// <param name="strLoginName">�û���</param>
        /// <param name="strPwd">����</param>
        /// <returns>�û�Ȩ��</returns>
        public int Proving(string strLoginName, string strPwd)
        {
            int iComp = 0; // Ȩ��Ĭ��Ϊ 0

            DataTable dtLogin = MainHelper.BuildLoginTable();

            if (File.Exists(strPath))
            {
                try
                {
                    dtLogin.ReadXml(strPath);

                    DataRow[] drs = dtLogin.Select(" Account = '" + strLoginName + "'");

                    if (drs.Length < 1)
                    {
                        // ��ʾ�û�������
                        ErrorMessage(3010008, string.Empty, "[FrmLogin:Proving]", Crypt.Decrypt(strLoginName));
                        return iComp;
                    }

                    for (int i = 0; i < drs.Length; i++)
                    {
                        if (drs[i][1].ToString().Equals(strPwd))
                        {
                            // ��ȡ�û�Ȩ��
                            iComp = int.Parse(drs[i][2].ToString());
                            return iComp;
                        }
                    }
                }
                catch
                {
                    // �ļ���ʽ����ȷ
                    ErrorMessage(3010005, string.Empty, "[FrmLogin:Proving]", strPath);
                    return iComp;
                }

                // �û������������
                ErrorMessage(3010009, string.Empty, "[FrmLogin:Proving]", Crypt.Decrypt(strLoginName));
                return iComp;
            }
            else
            {
                // û��Login.xml�ļ�
                ErrorMessage(3010006, string.Empty, "[FrmLogin:Proving]", strPath);
                return iComp;
            }
        }

        #endregion

        private void FrmLogin_Load(object sender, EventArgs e)
        {


        }

        private void txtLoginName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
    }
}