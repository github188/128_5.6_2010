using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KJ128NDBTable;
using KJ128NMainRun;
using KJ128NDataBase;

namespace KJ128NInterfaceShow
{
    public partial class FrmHisInMineRecordSet : Wilson.Controls.Docking.DockContent
    {
        //����
        Li_HisInMineRecordSet_BLL lhrb = new Li_HisInMineRecordSet_BLL();

        #region ˽�б���
        /// <summary>
        /// ��ѯ����
        /// </summary>
        private string where;
        /// <summary>
        /// ÿҳ��ʾ����
        /// </summary>
        private int pSize = 40;
        /// <summary>
        /// ��ѯ�������ҳ��
        /// </summary>
        private int countPage;
        /// <summary>
        /// ��ѯ�����в�����Ϣ
        /// </summary>
        private static string deptName = "";
        #endregion
        
        #region ҳ�����
        public FrmHisInMineRecordSet()
        {
            InitializeComponent();
            dtStartTime.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            #region ���ز���, ����, ֤��, ְ��, ְ��ȼ� ��Ϣ
            if (!lhrb.LoadInfo(treeInfo, cmbWorkType, cmbCerType, cmbDutyName, cmbDutyClass, 1))
            {
                MessageBox.Show("�Բ���, �������ݼ���ʧ�ܣ�");
                return;
            }
            #endregion

            treeInfo.ExpandAll();
            treeInfo.SelectedNode = treeInfo.Nodes[0];
            cbPSize.SelectedIndex = 0;
            label8.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + ":";
        }
        #endregion

        //�¼�
        #region ��ѯ ����¼� Click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtStartTime.Text.Trim() == "" || dtEndTime.Text.Trim() == "")
            {
                MessageBox.Show("�Բ���, ��ʼ�ͽ���ʱ�䶼����Ϊ�գ�");
                return;
            }
            if (DateTime.Compare(DateTime.Parse(dtStartTime.Text), DateTime.Parse(dtEndTime.Text)) > 0)
            {
                MessageBox.Show("�Բ���, ��ʼʱ�䲻�ܴ��ڽ���ʱ�䣡");
                return;
            }
            if (treeInfo.SelectedNode.Name == "0")
            {
                deptName = "";
            }
            else
            {
                deptName = " '" + treeInfo.SelectedNode.Text + "' ";
                GetNodeAllChild(treeInfo.SelectedNode);
            }


            where = lhrb.SelectWhere(dtStartTime.Text.Trim(), dtEndTime.Text.Trim(), txtName.Text.Trim(), txtCardAddress.Text.Trim(), txtEmpCard.Text.Trim(),
                    deptName, cmbWorkType.SelectedValue.ToString(), cmbCerType.SelectedValue.ToString(), cmbDutyName.SelectedValue.ToString(),
                    cmbDutyClass.SelectedValue.ToString());
            SelectInfo(1);
            cpUp.Enabled = false;
            cpDown.Enabled = true;
        }
        #endregion

        #region ���� ����¼� Click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtStartTime.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            txtName.Text = "";
            txtCardAddress.Text = "";
            txtEmpCard.Text = "";

            treeInfo.SelectedNode = treeInfo.Nodes[0];
            cmbWorkType.SelectedIndex = cmbCerType.SelectedIndex = cmbDutyName.SelectedIndex = cmbDutyClass.SelectedIndex = 0;
        }
        #endregion
        
        #region ��ҳ
        //��һҳ
        private void cpUp_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page--;
            cpDown.Cursor = Cursors.Hand;
            cpDown.Enabled = true;
            if (page == 1)
            {
                cpUp.Enabled = false;
            }
            else if (page < 1)
            {
                return;
            }
            SelectInfo(page);
        }

        //��һҳ
        private void cpDown_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page++;
            cpUp.Enabled = true;
            if (page == countPage)
            {
                cpDown.Enabled = false;
            }
            else if (page > countPage)
            {

                return;
            }
            SelectInfo(page);
        }

        //����
        private void cpCheckPage_Click(object sender, EventArgs e)
        {
            string value = txtCheckPage.Text;
            if (value.CompareTo("") == 0)
            {
                return;
            }
            else if (int.Parse(value) > 0)
            {
                int page = int.Parse(value);
                if (page == 1)
                {
                    cpUp.Enabled = false;
                    cpDown.Enabled = true;
                }
                else if (page == countPage)
                {
                    cpUp.Enabled = true;
                    cpDown.Enabled = false;
                }
                else
                {
                    cpUp.Enabled = true;
                    cpDown.Enabled = true;
                }
                if (page > countPage)
                {
                    page = countPage;
                    cpUp.Enabled = true;
                    cpDown.Enabled = false;
                }
                SelectInfo(page);
            }
        }
        #endregion

        #region ѡ��ÿҳ����
        private void cbPSize_DropDownClosed(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cbPSize.SelectedItem);
            //SelectInfo(1);
            btnSearch_Click(sender, e);
            cpUp.Enabled = false;
            cpDown.Enabled = true;
        }
        #endregion

        //����
        #region ��ҳ��ѯ
        /// <summary>
        /// ��ҳ��ѯ
        /// </summary>
        /// <param name="pIndex">�ڼ�ҳ</param>
        private void SelectInfo(int pIndex)
        {
            if (pIndex < 1)
            {
                MessageBox.Show("�������ҳ��������Χ,����ȷ����ҳ����");
                return;
            }
            DataSet ds = lhrb.GetHisInMineSet(pIndex, pSize, where);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // ��������ҳ��
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                //if (sumPage > 1)
                //{
                //    bcpPageSum.Visible = true;
                //    bcpPageSum.Location = new Point(321, 9);
                //}
                //else
                //{
                //    bcpPageSum.Visible = true;
                //    bcpPageSum.Location = new Point(629, 9);

                //}

                if (pIndex > sumPage)
                {
                    if (sumPage == 0)
                    {

                        dgValue.Columns.Clear();
                        dgValue.DataSource = ds.Tables[0];
                        dgValue.Columns[9].Visible = false;
                        dgValue.Columns[10].Visible = false;
                        dgValue.Columns[11].Visible = false;
                        dgValue.Columns[12].Visible = false;
                        dgValue.Columns[13].Visible = false;
                        dgValue.Columns[14].Visible = false;


                        dgValue.Columns[5].FillWeight = 130;
                        dgValue.Columns[7].FillWeight = 130;

                        dgValue.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        dgValue.Columns[7].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                        AddColumns();

                        buttonCaptionPanel1.CaptionTitle = "��ʷ�¾���¼��ʾ: �� 0 ��¼";
                        pageControlsVisible(false);
                        return;
                    }
                    // �������һҳ
                    return;
                }
                buttonCaptionPanel1.CaptionTitle = "��ʷ�¾���¼��ʾ: �� " + ds.Tables[1].Rows[0][0].ToString() + " ��¼";
                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "ҳ";

                dgValue.Columns.Clear();
                dgValue.DataSource = ds.Tables[0];
                dgValue.Columns[9].Visible = false;
                dgValue.Columns[10].Visible = false;
                dgValue.Columns[11].Visible = false;
                dgValue.Columns[12].Visible = false;
                dgValue.Columns[13].Visible = false;
                dgValue.Columns[14].Visible = false;

                dgValue.Columns[5].FillWeight = 130;
                dgValue.Columns[7].FillWeight = 130;

                dgValue.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dgValue.Columns[7].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                AddColumns();
                #region ���ơ���һҳ��������һҳ���Ȱ�ť����ʾ״̬
                if (Convert.ToInt32(ds.Tables[1].Rows[0][0]) <= pSize)
                {
                    pageControlsVisible(false);
                }
                else
                {
                    pageControlsVisible(true);
                }
                #endregion
            }
        }
        #endregion

        #region ���������ҳ����ʾ
        /// <summary>
        /// ���������ҳ����ʾ
        /// </summary>
        /// <param name="bl"></param>
        private void pageControlsVisible(bool bl)
        {
            //bcpPageSum.Visible = bl;
            cpUp.Visible = bl;
            cpDown.Visible = bl;
            txtPage.Visible = bl;
            lblSumPage.Visible = bl;
            txtCheckPage.Visible = bl;
            cpCheckPage.Visible = bl;
        }
        #endregion
       
        #region �����ڵ��µ������ӽڵ�
        /// <summary>
        /// �����ڵ��µ������ӽڵ�
        /// </summary>
        /// <param name="tn"></param>
        private void GetNodeAllChild(TreeNode tn)
        {
            if (tn.Nodes.Count > 0)
            {
                foreach (TreeNode n in tn.Nodes)
                {
                    if (n.Nodes.Count > 0)
                    {
                        GetNodeAllChild(n);
                    }
                    deptName += " or ����='" + n.Text.Trim() + "' ";
                }
            }
        }
        #endregion

        #region [ �¼�: ��ӡ ]

        private void cpStationToExcel_Click(object sender, EventArgs e)
        {
            if (dgValue.DataSource != null)
            {
                PrintBLL.Print(dgValue, Text);
            }
            else
            {
                MessageBox.Show("��ѯ������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        #region [ ����: ��Ӳ鿴�� ]

        private void AddColumns()
        {
            DataGridViewLinkColumn dgvLink = new DataGridViewLinkColumn();
            dgvLink.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvLink.HeaderText = "�鿴Ա����Ϣ";
            dgvLink.Name = "EmpInfo";
            dgvLink.Text = "�鿴";
            dgvLink.UseColumnTextForLinkValue = true;
            dgvLink.Resizable = DataGridViewTriState.False;
            dgValue.Columns.Add(dgvLink);
        }

        #endregion

        #region [ �¼�: ������Ԫ�� ]
        private void dgValue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 15 && e.RowIndex >= 0)
            {
                string strCodeSenderAddress = dgValue.Rows[e.RowIndex].Cells["���������"].Value.ToString();
                FrmEmpInfo frm = new FrmEmpInfo(strCodeSenderAddress,false);
                frm.ShowDialog();

                frm.Dispose();
            }
        }

        #endregion
    }
}