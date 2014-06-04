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
    /// �����޸Ĵ���
    /// </summary>
    public partial class FrmChangePwd : Form
    {
        #region [ ����:ί�� ] ������Ϣ�¼�

        /// <summary>
        /// ������Ϣ����
        /// </summary>
        /// <param name="iErrNO">������</param>
        /// <param name="strStackTrace">��ȡ��ǰ�쳣����ʱ���ö�ջ�ϵ�֡���ַ�����ʾ��ʽ</param>
        /// <param name="strSource">��ʶ��ǰ��һ�γ�����Ĵ���</param>
        /// <param name="strMessage">��ȡ������ǰ�쳣����Ϣ</param>
        public delegate void ErrorMessageEventHandler(int iErrNO, string strStackTrace, string strSource, string strMessage);

        /// <summary>
        /// ������Ϣ�¼�
        /// </summary>
        public event ErrorMessageEventHandler ErrorMessage;

        #endregion

        #region [ ���� ]

        private readonly IFrmMain frmMain = null;
        private readonly string strPath = "Login.xml";

        #endregion

        #region [ ���캯�� ]

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="frm">�������</param>
        /// <param name="strFilePath">�ļ�����·��</param>
        public FrmChangePwd(IFrmMain frm, string strFilePath)
        {
            InitializeComponent();
            frmMain = frm;
            strPath = System.Windows.Forms.Application.StartupPath.ToString() + @"\" + strFilePath;

            lblLoginName.Text = "��ǰ�û����ʺ�Ϊ: " + frmMain.GetLoginInfo();
            lblLoginName.Left = (this.Width - lblLoginName.Width) / 2;
        }

        #endregion

        #region [ �¼�: �޸����� ]

        private void btnUpdatePwd_Click(object sender, EventArgs e)
        {
            string strLoginName = frmMain.GetLoginInfo();

            // �����ж���д�Ƿ�����
            if (txtOldPwd.Text == "" || txtNewPwd.Text == "" || txtAccPwd.Text == "")
            {
                ErrorMessage(3010001, string.Empty, "FrmChangePwd:btnUpdatePwd_Click", string.Empty);
                return;
            }

            // �ж���������������֤�����Ƿ���ͬ
            if (!txtAccPwd.Text.Equals(txtNewPwd.Text))
            {
                ErrorMessage(3010002, string.Empty, "FrmChangePwd:btnUpdatePwd_Click", string.Empty);
                return;
            }

            // �ж�ԭʼ�����Ƿ���ȷ���޸�XML�е�����
            if (UpdatePwd(Crypt.Encrypt(strLoginName), Crypt.MD5_16(txtOldPwd.Text),
                          Crypt.MD5_16(txtNewPwd.Text)))
            {
                Close();
            }
        }

        #endregion

        #region [ �¼�: ȡ����ť ]

        private void btnCanal_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region [ ����: �޸����� ]

        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="strLoginName">�û���</param>
        /// <param name="strPwd">����</param>
        /// <param name="strNewPwd">Ҫ�޸ĵ�����</param>
        /// <returns>�Ƿ��޸ĳɹ�</returns>
        public bool UpdatePwd(string strLoginName, string strPwd, string strNewPwd)
        {
            DataTable dtLogin = MainHelper.BuildLoginTable();

            if (File.Exists(strPath))
            {
                try
                {
                    dtLogin.ReadXml(strPath);
                    DataRow[] drs = dtLogin.Select(" Account = '" + strLoginName + "' and Password ='" + strPwd + "'");

                    if (drs.Length < 1)
                    {
                        // ��ʾ�������������
                        ErrorMessage(3010003, string.Empty, "[FrmChangePwd:UpdatePwd]]", frmMain.GetLoginInfo());
                        return false;
                    }

                    for (int i = 0; i < drs.Length; i++)
                    {
                        // �޸��û�����
                        drs[i][1] = strNewPwd;
                        dtLogin.WriteXml(strPath);

                        // ��ʾ�޸ĳɹ�
                        ErrorMessage(3010004, string.Empty, "[FrmChangePwd:UpdatePwd]", frmMain.GetLoginInfo());
                    }
                    return true;
                }
                catch
                {
                    // ��ʾXML�ļ���ʽ����
                    ErrorMessage(3010005, string.Empty, "[FrmChangePwd:UpdatePwd]", strPath);
                    return false;
                }
            }
            else
            {
                // ��ʾû�и�XML�ļ�
                ErrorMessage(3010006, string.Empty, "[FrmChangePwd:UpdatePwd]", strPath);
                return false;
            }
        }

        #endregion

        private void txtOldPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtNewPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtAccPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
    }
}