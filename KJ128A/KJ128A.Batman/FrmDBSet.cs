using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using KJ128A.BatmanAPI;
using KJ128A.Controls.Batman;

namespace KJ128A.Batman
{
    /// <summary>
    /// ���ݿ��������ô���
    /// </summary>
    public partial class FrmDBSet : Form
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

        #region [ ���캯�� ]

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="index"></param>
        /// <param name="strFilePath"></param>
        public FrmDBSet(IFrmMain frm, int index, string strFilePath)
        {
            InitializeComponent();

            frmMain = frm; //������
            dataIndex = index; //����������
          
            strPath = strFilePath; //XML�����ļ�����·��
        }

        #endregion

        #region [ ���� ]

        private string data_source = String.Empty; // ���ݿ�����

        private int dataIndex; // ��� 
        private DataRow[] drs;
        private DataTable dt = new DataTable(); // �����Ϣ�ı�
        private readonly IFrmMain frmMain = null; //������ 
        private bool loginModel_flag = true; // loginModel_flagΪtrueʱ��ΪWindows��֤��Ϊ0ʱ��ΪSQL��֤
        private string passID = String.Empty; // ����
        private ConnParamSet sqlCs = new ConnParamSet(); // ����һ�����ݿ��������ʵ��
        private string strPath = ""; //�ļ�·��
        private string strServerName = String.Empty; // ����������
        private string user = String.Empty; // �û���
        private string strFlag = String.Empty; //�������Ǳ���

        #endregion

        #region [ ����:����ʼ�����͡���һ��������л� ]

        /// <summary>
        /// ����ʼ�����͡���һ��������л�
        /// </summary>
        /// <param name="bln">�Ƿ���ʾ"��ʼ"���</param>
        private void PanelState(bool bln)
        {
            pnlNext.Visible = !bln;
            pnlStart.Visible = bln;
        }

        #endregion

        #region [ ����: Windows��֤��ѡ��ť��״̬ ]

        /// <summary>
        /// Windows��֤��ѡ��ť��״̬
        /// </summary>
        /// <param name="bWin">�Ƿ���Windows��֤</param>
        private void WindowsCon(bool bWin)
        {
            sql_rb.Checked = !bWin;
            win_rb.Checked = bWin;
            loginBox.Enabled = !bWin;
            mimaBox.Enabled = !bWin;
            label_loginID.Enabled = !bWin;
            lable_loginName.Enabled = !bWin;

            loginModel_flag = bWin; //������֤��ʽ��ʶ

            if (bWin)
            {
                loginBox.Clear();
                mimaBox.Clear();
            }
        }

        #endregion

        #region [ ����: ��֤��ť��״̬ ]

        /// <summary>
        /// ��֤��ť��״̬
        /// </summary>
        /// <param name="bStatu">�Ƿ���֤�ɹ�</param>
        private void ConSussesStatu(bool bStatu)
        {
            btnCommit.Enabled = bStatu;
            btnNext.Enabled = !bStatu;
        }

        #endregion

        #region [ ����: ��ȡXML�ļ� ]

        /// <summary>
        /// ��ȡXML�ļ�
        /// </summary>
        /// <param name="strPath">·��</param>
        /// <returns></returns>
        private DataTable ReadXmlToTable(string strPath)
        {
            DataTable dt = MainHelper.BuildDBConfigTable(strPath);
            try
            {
                dt.ReadXml(strPath); //��ȡ���ݿ������
            }
            catch
            {
                return dt;
            }

            return dt;
        }

        #endregion

        #region [ ����: ���ط��������� ]

        /// <summary>
        /// ���ط���������
        /// </summary>
        /// <param name="strSerName">����������</param>
        /// <param name="bEnble">���ҷ�������ť��Enable״̬</param>
        /// <returns></returns>
        public bool UpdateServerName(string strSerName, bool bEnble)
        {
            if (strSerName != "")
            {
                cbbServername.Text = strSerName;
            }

            btnSelectSQLName.Enabled = bEnble;

            CloseWaiteMessage(); //�رյȴ���ʾ

            return true;
        }

        #endregion

        #region  [ ����: ��ʾ�͹رյȴ��� ]

        /// <summary>
        /// ��ʾ�ȴ���
        /// </summary>
        /// <param name="strMessage">�ȴ�����ʾ����ʾ</param>
        private void OpenWaiteMessage(string strMessage)
        {
            lblMessage.Text = strMessage;
            lblMessage.Visible = true;
            lblMessage.Refresh();
        }

        /// <summary>
        /// �رյȴ���
        /// </summary>
        private void CloseWaiteMessage()
        {
            lblMessage.Visible = false;
            lblMessage.Text = "";
        }

        #endregion

        #region [ �¼�: ������� ]

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDBSet_Load(object sender, EventArgs e)
        {
            //byte[] bstream ={ 63 };
            //KJ128A.DataSave.LogsHelper.Save_DBAccess(DateTime.Now, bstream, false, false);

            //���ء�ѡ�����ݿ���塱
            PanelState(true);
            WindowsCon(false);

            dt = ReadXmlToTable(strPath);
            drs = dt.Select("ID='" + dataIndex + "'");
            if (drs != null && drs.Length > 0)
            {
                DataRow dr = drs[0];
                strServerName = Crypt.Decrypt(dr[1].ToString()); //����������
                cbbServername.Text = strServerName;
                data_source = Crypt.Decrypt(dr[5].ToString()); //���ݿ�����

                if (dr[2].ToString() == "Y") //�Ƿ�Windows��֤
                {
                    WindowsCon(true);
                }
                else
                {
                    WindowsCon(false);
                    user = Crypt.Decrypt(dr[3].ToString()); //��¼��
                    loginBox.Text = user;
                    passID = Crypt.Decrypt(dr[4].ToString()); //����
                    mimaBox.Text = passID;
                }

                ConSussesStatu(false); //����Ҫ��֤��ֱ�ӿ��Ե����һ��

                sqlCs.MyCon = sqlCs.connecting(loginModel_flag, strServerName, user, passID); //���ӵ����ݿ�
            }
            else
            {
                cbbServername.Text = "(local)";
            }
        }

        #endregion

        #region [ �¼�: ���ҷ��������� ]

        /// <summary>
        /// ���ҷ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectSQLName_Click(object sender, EventArgs e)
        {
            OpenWaiteMessage("�������Ӳ��Ҿ������ڵķ���������ȴ�...");

            FrmSqlList frmSearch = new FrmSqlList(this, frmMain);
            frmSearch.ShowDialog();

            ConSussesStatu(true);
        }

        #endregion

        #region [ �¼�: ����Windows��֤��ʽ ]

        /// <summary>
        /// ����Windows��֤��ʽ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void win_rb_CheckedChanged(object sender, EventArgs e)
        {
            WindowsCon(win_rb.Checked);
            ConSussesStatu(true);
        }

        #endregion

        #region [ �¼�: ����SQL��֤��ʽ ]

        /// <summary>
        /// ����SQL��֤��ʽ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sql_rb_CheckedChanged(object sender, EventArgs e)
        {
            WindowsCon(win_rb.Checked);
            ConSussesStatu(true);

            txtDataBaseName.Clear();
        }

        #endregion

        #region [ �¼�: ���������Ƹı� ]

        /// <summary>
        /// ���������Ƹı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbServername_SelectedValueChanged(object sender, EventArgs e)
        {
            ConSussesStatu(true);
        }

        #endregion

        #region [ �¼�: ���������û��� ]

        /// <summary>
        /// ���������û���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginBox_TextChanged(object sender, EventArgs e)
        {
            ConSussesStatu(true);
        }

        #endregion

        #region [ �¼�: ������������ ]

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mimaBox_TextChanged(object sender, EventArgs e)
        {
            ConSussesStatu(true);
        }

        #endregion

        #region [ �¼�: ��֤��ť ]

        /// <summary>
        /// ��֤���ݿ������Ƿ���ȷ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommit_Click(object sender, EventArgs e)
        {
            OpenWaiteMessage("������֤, ������̿��ܽ�����ʮ���룬��ȴ�...");

            strServerName = cbbServername.Text;

            if (loginModel_flag)
            {
                sqlCs.MyCon = sqlCs.connecting(loginModel_flag, strServerName, "", ""); //���ӵ����ݿ�
            }
            else
            {
                passID = mimaBox.Text;
                user = loginBox.Text;
                sqlCs.MyCon = sqlCs.connecting(loginModel_flag, strServerName, user, passID); //���ӵ����ݿ�
            }

            try
            {
                sqlCs.MyCon.Open(); //�����ݿ�
            }
            catch (Exception ex)
            {
                ErrorMessage(3010010, ex.StackTrace, "[FrmDBSet:btnCommit_Click]", ex.Message);
            }
            finally
            {
                if (sqlCs.MyCon.State == ConnectionState.Open)
                {
                    ErrorMessage(8010010, string.Empty, "[FrmDBSet:btnCommit_Click]", strServerName + "  [ " + dataIndex.ToString() + " ] ");
                    ConSussesStatu(false);
                }
                else
                {
                    mimaBox.Focus();
                    ConSussesStatu(true);
                }
            }
            sqlCs.MyCon.Close();

            CloseWaiteMessage();
        }

        #endregion

        #region [ �¼�: ��һ����ť ]

        /// <summary>
        /// ��һ����ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            strServerName = cbbServername.Text; //�������������
            PanelState(false); //��ʾ��ѡ�����ݿ⡱���
            LoadDataBaseName(sqlCs.MyCon); //������ѡ���������������ݿ�
        }

        #endregion

        #region [ ����: ���ط������е��������ݿ��� ]

        /// <summary>
        /// ���ط������е��������ݿ���
        /// </summary>
        /// <param name="odbconn"></param>
        private void LoadDataBaseName(OleDbConnection odbconn)
        {
            DataSet dsDBName = new DataSet();
            OleDbDataAdapter odbAdt = new OleDbDataAdapter("select name from master.dbo.sysdatabases", odbconn);

            try
            {
                odbAdt.Fill(dsDBName);
                foreach (DataRow dr in dsDBName.Tables[0].Rows)
                {
                    //��ȡ���ݿ��б�
                    ltbDataBaseName.Items.Add(dr[0].ToString());
                    if (drs != null && drs.Length > 0 && dr[0].ToString() == data_source)
                    {
                        ltbDataBaseName.SelectedItem = ltbDataBaseName.Items[ltbDataBaseName.Items.Count - 1];
                        txtDataBaseName.Text = data_source;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(3010011, ex.StackTrace, "[FrmDBSet:LoadDataBaseName]", ex.Message);
            }
            finally
            {
                if (odbconn.State == ConnectionState.Open)
                {
                    odbconn.Close();
                }
            }
        }

        #endregion

        #region [ �¼�: ��һ����ť ]

        /// <summary>
        /// ��һ����ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>    
        private void btnprv_Click(object sender, EventArgs e)
        {
            PanelState(true);
            txtDataBaseName.Clear();
            ltbDataBaseName.Items.Clear();
        }

        #endregion

        #region [ �¼�: ����ѡ�����ݿ��� ]

        /// <summary>
        /// ����ѡ�����ݿ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>       
        private void ltbDataBaseName_Click(object sender, EventArgs e)
        {
            if (ltbDataBaseName.SelectedItems.Count > 0)
            {
                txtDataBaseName.Text = ltbDataBaseName.SelectedItem.ToString();
            }
        }

        #endregion

        #region [ �¼�: ������水ť ]

        /// <summary>
        /// ������水ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDataBaseName.Text != "")
            {
                data_source = txtDataBaseName.Text;
                if (ISDBSame())
                {
                    //����������Ϣ
                    SaveParam();
                    ErrorMessage(8010011, string.Empty, "[FrmDBSet:btnSave_Click]", strServerName + "  [ " + dataIndex.ToString() + " ] ");
                    Close();
                }
                else
                {
                    ErrorMessage(3010012, string.Empty, "[FrmDBSet:LoadDataBaseName]", string.Empty);
                }
            }
            else
            {
                MessageBox.Show("��ѡ�����ݿ�!");
                txtDataBaseName.Focus();
            }
        }

        #endregion

        #region [ ����: ���������ļ� ]

        /// <summary>
        /// ���������ļ�
        /// </summary>
        public void SaveParam()
        {
            DataRow dr;

            if (drs != null && drs.Length == 0)
            {
                dr = dt.NewRow(); //����һ������
            }
            else
            {
                dr = drs[0];
            }

            dr[0] = dataIndex.ToString();
            dr[1] = Crypt.Encrypt(strServerName);

            //��֤��ʽ
            if (loginModel_flag)
            {
                dr[2] = "Y";
            }
            else
            {
                dr[2] = "N";
            }

            dr[3] = Crypt.Encrypt(user);
            dr[4] = Crypt.Encrypt(passID);
            dr[5] = Crypt.Encrypt(data_source);

            if (drs != null && drs.Length == 0)
            {
                dt.Rows.Add(dr);
            }

            dt.AcceptChanges();

            dt.WriteXml(strPath); //������д��XML�ļ�
        }

        #endregion

        /*
         * ��֤������
         */

        /*
         * ѡ�����ݿ� 
         */

        /*
         * ��������
         */

        /// <summary>
        /// �ж��������������Ƿ���ͬ
        /// </summary>
        /// <returns></returns>
        private bool ISDBSame()
        {
            DataRow[] mydrs = dt.Select("ID<>'" + dataIndex + "'");
            if (mydrs.Length > 0)
            {
                DataRow dr = mydrs[0];
                if (dr[1].ToString() == Crypt.Encrypt(strServerName) && dr[5].ToString() == Crypt.Encrypt(data_source))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }
    }
}