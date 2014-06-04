using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDataBase;
using KJ128NInterfaceShow;
using KJ128NDBTable;
using Shine.Logs;
using Shine.Logs.LogType;

namespace KJ128NMainRun.EquManage
{
    public partial class FrmEquManage : Wilson.Controls.Docking.DockContent
    {
        EquBLL equDAL = new EquBLL();
        DataTable dtFactoryInfo = null;

        #region ��ʼ��
        public FrmEquManage()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            // �󶨳�������
            BindFactoyName();

            // �󶨳���������Ϣ
            BinddgvFactory();

            // ���豸��Ϣ
            BinddgvEqu();
        }
        #endregion 

        #region �豸��Ϣ����

        #region �ж��Ƿ�Ҫ�����������
        /// <summary>
        /// �ж��Ƿ�Ҫ�����������
        /// </summary>
        /// <returns>true ���������Ҵ���</returns>
        public bool IsNotFactory()
        { 
            // ��û�������������ʱ��ӻ��޸Ķ�����ִ�����������Ӻ��޸�֮ǰ�����ж�
            // �����������Ҵ���ʱ������������޸ģ��������û����һ����������
            bool bl = true;
            if (dtFactoryInfo.Rows.Count > 0)
            {
                bl = true;
            }
            else
            {
                bl = false;
            }
            return bl;
        }
        #endregion

        #region �󶨳�������
        // �󶨳�������
        public void BindFactoyName()
        {
            //cmbFactory.Items.Clear();
            DataTable  dt = equDAL.GetFactoryInfo();
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[2] = "����";
            dt.Rows.InsertAt(dr, 0);
            cmbFactory.DataSource = dt;

            cmbFactory.DisplayMember = "FactoryName";
            cmbFactory.ValueMember = "FactoryID";

            cmbFactory.Text = "����";
        }
        #endregion

        #region ��ʼ�� dgvEqu ����ʾȫ����Ϣ��

        public void BinddgvEqu()
        { 
            DataTable dt = equDAL.GetEquInfo();
            BinddgvEquInfo(dt);
            captionPanel1.CaptionTitle = "�豸��Ϣ����:\t�� " + dt.Rows.Count.ToString() + " ���豸";
        }

        /// <summary>
        /// ��ʼ�� dgvEqu ����ʾȫ����Ϣ��
        /// </summary>
        public void BinddgvEquInfo(DataTable dt)
        {
            dgvEqu.DataSource = dt;
            dgvEqu.Columns["EquID"].Visible = false;
            dgvEqu.Columns["EquNO"].HeaderText = "�豸���";
            dgvEqu.Columns["EquName"].HeaderText = "�豸����";
            dgvEqu.Columns["DeptID"].HeaderText = "��������";
            dgvEqu.Columns["EquType"].HeaderText = "�豸����";
            dgvEqu.Columns["EquState"].HeaderText = "�豸״̬";
            dgvEqu.Columns["FactoryID"].HeaderText = "��������";
            dgvEqu.Columns["Remark"].HeaderText = "��  ע";
            dgvEqu.Columns["EquNO"].Width = 50;
            dgvEqu.Columns["EquName"].Width = 60;
            if (dgvEqu.Columns["update"] == null)
            {
                DataGridViewLinkColumn colUpdateEqu = new DataGridViewLinkColumn();
                colUpdateEqu.Name = "update";
                colUpdateEqu.HeaderText = "�޸�";
                colUpdateEqu.Text = "�޸�";
                colUpdateEqu.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                colUpdateEqu.UseColumnTextForLinkValue = true;

                DataGridViewLinkColumn colDelEqu = new DataGridViewLinkColumn();
                colDelEqu.HeaderText = "ɾ��";
                colDelEqu.Text = "ɾ��";
                colDelEqu.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                colDelEqu.UseColumnTextForLinkValue = true;

                dgvEqu.Columns.Insert(8, colUpdateEqu);
                dgvEqu.Columns.Insert(9, colDelEqu);
            }
        }
        #endregion 

        #region ��ť�¼�

        #region �޸ĺ�ɾ��
        // �޸ĺ�ɾ��
        private void dgvEqu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                // �����޸�ҳ��
                DataTable dt = equDAL.GetEquInfo(int.Parse(dgvEqu.Rows[e.RowIndex].Cells[2].Value.ToString()));
                DataTable dtDetail = equDAL.GetEquEqu_DetailInfo(int.Parse(dgvEqu.Rows[e.RowIndex].Cells[2].Value.ToString()));
                FrmEquEdit frm = new FrmEquEdit();
                frm.Text = "�޸��豸��Ϣ";
                if (IsNotFactory())
                {
                    frm.ShowDialog(dt, dtDetail);

                    // ���°�
                    BinddgvEqu();
                }
                else
                {
                    MessageBox.Show("���������������");
                    btnFactoryAdd_Click(sender, e);
                }
            }
            else if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {

                model = 1;

                // ɾ��
                if (MessageBox.Show("��ȷ��Ҫɾ�����Ϊ�� " + dgvEqu.Rows[e.RowIndex].Cells[3].Value.ToString() + " �����豸�� " + dgvEqu.Rows[e.RowIndex].Cells[4].Value.ToString() + " ����", "��ʾ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //������־
                    LogSave.Messages("[FrmEquManage]", LogIDType.UserLogID, "ɾ���豸��Ϣ���������ң�" + dgvEqu.Rows[e.RowIndex].Cells[3].Value.ToString() + "���豸���ƣ�" + dgvEqu.Rows[e.RowIndex].Cells[4].Value.ToString());

                    int intCount = equDAL.DelEqu_BaseInfo(int.Parse(dgvEqu.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    if (intCount == -1)
                    {
                        MessageBox.Show("ɾ��ʧ��");
                        return;
                    }

                    if (!New_DBAcess.IsDouble)
                    {
                        // ���°�
                        BinddgvEqu();
                    }
                    else
                    {
                        timer1.Stop();
                        timer1.Start();
                    }
                }
            }
        }

        #endregion 

        #region ���
        // ���
        private void btnEquAdd_Click(object sender, EventArgs e)
        {
            FrmEquEdit frm = new FrmEquEdit();
            frm.Text = "����豸��Ϣ";
            if (IsNotFactory())
            {
                frm.ShowDialog(null, null);

                // ���°�
                BinddgvEqu();
            }
            else
            {
                MessageBox.Show("���������������");
                btnFactoryAdd_Click(sender, e);
            }
        }
        #endregion 

        #endregion

        #endregion 

        #region ������Ϣ����

        #region ��ʼ�� dgvFactory ����ʾȫ����Ϣ��

        public void BinddgvFactory()
        {
            dtFactoryInfo = equDAL.GetFactoryInfo();
            BinddgvFactoryInfo(dtFactoryInfo);
            buttonCaptionPanel2.CaptionTitle = "����������Ϣ:\t�� " + dtFactoryInfo.Rows.Count.ToString() + " ��";
        }

        // ��ʼ�� dgvFactory ����ʾȫ����Ϣ��
        public void BinddgvFactoryInfo(DataTable dt)
        {
            dgvFactory.DataSource = dt;

                // ����һЩ��Ҫ��ʾ���� 
                dgvFactory.Columns["FactoryID"].Visible = false;
                dgvFactory.Columns["FactoryNO"].HeaderText = "���ұ��";
                dgvFactory.Columns["FactoryName"].HeaderText = "��������";
                dgvFactory.Columns["FactoryAddress"].HeaderText = "���ҵ�ַ";
                dgvFactory.Columns["FactoryFax"].HeaderText = "���Ҵ���";
                dgvFactory.Columns["FactoryTel"].HeaderText = "��ϵ�绰";
                dgvFactory.Columns["FactoryEmployee"].HeaderText = "��ϵ��";
                dgvFactory.Columns["FactoryEmpoyeeTel"].HeaderText = "��ϵ�˵绰";
                dgvFactory.Columns["Remark"].HeaderText = "��ע";

                // �ж��Ƿ��Ѿ������޸ĺ�ɾ������
                if (dgvFactory.Columns["update"] == null)
                {

                    // ����޸ĺ�ɾ��
                    DataGridViewLinkColumn colUpdateFactory = new DataGridViewLinkColumn();
                    colUpdateFactory.Text = "�޸�";
                    colUpdateFactory.HeaderText = "�޸�";
                    colUpdateFactory.Name = "update";
                    colUpdateFactory.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    colUpdateFactory.UseColumnTextForLinkValue = true;

                    DataGridViewLinkColumn colDelFactory = new DataGridViewLinkColumn();
                    colDelFactory.Text = "ɾ��";
                    colDelFactory.HeaderText = "ɾ��";
                    colDelFactory.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    colDelFactory.UseColumnTextForLinkValue = true;
                    dgvFactory.Columns.Insert(9, colUpdateFactory);
                    dgvFactory.Columns.Insert(10, colDelFactory);
                }
        }
        #endregion 

        #region �޸ĺ�ɾ��

        // �޸ĺ�ɾ��
        private void dgvFactory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {

                
                // �����޸�ҳ��

                // ����Ҫ�޸ĵ���һ������
                DataTable dt = equDAL.GetFactoryInfo(int.Parse(dgvFactory.Rows[e.RowIndex].Cells[2].Value.ToString()));
                FrmFactoryEdit frm = new FrmFactoryEdit();
                frm.Text = "�޸ĳ�����Ϣ";
                frm.ShowDialog(dt);

                // ���°�
                BinddgvFactory();
                BinddgvEqu();
            }
            else if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {

                model = 2;

                // ɾ��
                if (MessageBox.Show("��ȷ��Ҫɾ���� " + dgvFactory.Rows[e.RowIndex].Cells[4].Value.ToString() + " �����������", "��ʾ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //������־
                    LogSave.Messages("[FrmFactoryEdit]", LogIDType.UserLogID, "ɾ������������Ϣ���������ұ�ţ�" + dgvFactory.Rows[e.RowIndex].Cells[2].Value.ToString()
                        + "�������������ƣ�" + dgvFactory.Rows[e.RowIndex].Cells[4].Value.ToString());

                    // ɾ��������¼
                    int int_isOk = equDAL.DelFactory(int.Parse(dgvFactory.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    //int_isOk Ϊ1ʱɾ���ɹ�
                    if (int_isOk == -1)
                    {
                        // ɾ��ʧ��
                        MessageBox.Show("ɾ��ʧ��");
                        return;
                    }

                    if (!New_DBAcess.IsDouble)
                    {
                        // ���°�
                        BinddgvFactory();
                        BinddgvEqu();
                    }
                    else
                    {
                        timer1.Stop();
                        timer1.Start();
                    }
                }
            }

            BindFactoyName();
        }
        #endregion 

        #region �����������
        // �����������
        private void btnFactoryAdd_Click(object sender, EventArgs e)
        {
            FrmFactoryEdit frm = new FrmFactoryEdit();
            DataTable dt = null;
            int i = 0;
            frm.Text = "��ӳ�����Ϣ";
            frm.ShowDialog(dt);

            // ���°�
            BinddgvFactory();
            BindFactoyName();
        }
        #endregion 

        #endregion 

        #region ��ѯ ȡ��

        private void btnCanel_Click(object sender, EventArgs e)
        {
            // ��ѯ ȡ��
            txtEquName.Text ="";
            //cmbFactory.Text = "��ѡ�����";
        }
        #endregion 

        #region ��ѯ

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DataSet ds = equDAL.Equ_Query(txtEquName.Text,cmbFactory.SelectedValue.ToString() == "0"?"":cmbFactory.SelectedValue.ToString());
            // ���豸��Ϣ
            BinddgvEquInfo(ds.Tables[0]);
            captionPanel1.CaptionTitle = "�豸��Ϣ����:\t�� "+ds.Tables[0].Rows.Count.ToString()+" ���豸";
            // ����������
            //BinddgvFactoryInfo(ds.Tables[1]);
            //buttonCaptionPanel2.CaptionTitle = "�豸��Ϣ����:\t�� " + ds.Tables[1].Rows.Count.ToString() + " ��";
        }
        #endregion

        #region [ �¼�: �豸��Ϣ����Excel ]

        private void buttonCaptionPanel3_Click(object sender, EventArgs e)
        {
            ExcelExports.ExportDataGridViewToExcel(dgvEqu);
        }

        #endregion

        #region [ �¼�: ����������Ϣ����Excel ]

        private void buttonCaptionPanel4_Click(object sender, EventArgs e)
        {
            ExcelExports.ExportDataGridViewToExcel(dgvFactory);
        }

        #endregion

        private void bcpfaSelect_Click(object sender, EventArgs e)
        {
            DataSet ds = equDAL.Equ_Query(txtEquName.Text, cmbFactory.SelectedValue.ToString() == "0" ? "" : cmbFactory.SelectedValue.ToString());
            BinddgvFactoryInfo(ds.Tables[1]);
            buttonCaptionPanel2.CaptionTitle = "�豸��Ϣ����:\t�� " + ds.Tables[1].Rows.Count.ToString() + " ��";
        }

        private void bcpCancel_Click(object sender, EventArgs e)
        {
            //txtEquName.Text = "";
            cmbFactory.Text = "����";
        }



        #region[�ȱ�ˢ��]
 
        private int model = 1;


        private int time = 0;

        private int maxTimes = 2;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (model == 1)
            {
                if (time < maxTimes)
                {
                    time++;

                    //ˢ��

                    BinddgvEqu();
                }
                else
                {
                    time = 0;
                    timer1.Stop();
                }
            }
            else
            {
                if (time < maxTimes)
                {
                    time++;

                    //ˢ��
                    BinddgvFactory();
                    BinddgvEqu();
                }
                else
                {
                    time = 0;
                    timer1.Stop();
                }
            }
        }

        #endregion

        #region [ �¼�: ˢ���豸��Ϣ ]

        private void buttonCaptionPanel5_Click(object sender, EventArgs e)
        {
            BinddgvEqu();
        }
        #endregion

        #region [ �¼�: ˢ���������� ]

        private void buttonCaptionPanel6_Click(object sender, EventArgs e)
        {
            //ˢ��
            BinddgvFactory();
            BinddgvEqu();
        }

        #endregion
    }
}