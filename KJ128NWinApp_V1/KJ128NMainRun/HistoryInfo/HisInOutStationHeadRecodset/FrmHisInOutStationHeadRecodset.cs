using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KJ128NDBTable;
using KJ128NDataBase;

namespace KJ128NInterfaceShow
{
    /// <summary>
    /// ��ʷԭʼ��¼��ʾ
    /// </summary>
    public partial class FrmHisInOutStationHead : Wilson.Controls.Docking.DockContent
    {
        //����
        private Li_HisInOutStationHeadRecodset_BLL lhsh = new Li_HisInOutStationHeadRecodset_BLL();
        private Li_HistoryInOutAntenna_BLL lhab = new Li_HistoryInOutAntenna_BLL();

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

        #region ��Ա

        //����
        #region ҳ�����
        public FrmHisInOutStationHead()
        {
            InitializeComponent();

            label8.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + ":";
            label4.Text = HardwareName.Value(CorpsName.StationSplace) + ":";
            label5.Text = HardwareName.Value(CorpsName.StaHeadSplace) + ":";

            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString();


            #region ���ز���, ����, ֤��, ְ��, ְ��ȼ� ��Ϣ
            if (!lhsh.LoadInfo(treeInfo, cmbWorkType, cmbCerType, cmbDutyName, cmbDutyClass, 1))
            {
                    MessageBox.Show("�Բ���, �������ݼ���ʧ�ܣ�");
                    return;
            }
            #endregion

            #region ���ط�վ��Ϣ
            lhab.LoadInfo(cmb_Station, cmb_StaHead, false);
            #endregion

            treeInfo.ExpandAll();
            treeInfo.SelectedNode = treeInfo.Nodes[0];

            cbPSize.SelectedIndex = 0;

            // �����豸���ͣ���������
            DeptBLL deptbll = new DeptBLL();
            deptbll.getEquTYpeCmb(cmbEquType);             // �豸����
            deptbll.getEquFactoryCmb(cmbFactory);          // ��������
        }
        #endregion

        #region �����ѯ, �����¼� Click
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
            // �ж�����Ա��ѯ�����豸��ѯ
            if (rbtnEmp.Checked)
            {
                // ��Ա��ѯ
                if (treeInfo.SelectedNode.Name == "0")
                {
                    deptName = "";
                }
                else
                {
                    deptName = " '" + treeInfo.SelectedNode.Text + "' ";
                    GetNodeAllChild(treeInfo.SelectedNode);
                }

                where = lhsh.SelectWhere(dtStartTime.Text.Trim(), dtEndTime.Text.Trim(), txtName.Text.Trim(), txtCardAddress.Text.Trim(), txtEmpCard.Text.Trim(),
                                deptName, cmbCerType.SelectedValue.ToString(), cmbDutyName.SelectedValue.ToString(), cmb_Station.SelectedValue.ToString(),
                                cmb_StaHead.SelectedValue.ToString());
                SelectInfo(1);          //��ҳ��ѯ
                cpUp.Enabled = false;
                cpDown.Enabled = true;

            }
            else
            {
                // �豸��ѯ

                DataTable dt = lhsh.GetConditionEqu(txtEquName.Text.Trim() == "" ? "0" : txtEquName.Text.Trim(),
                    treeInfo.SelectedNode.Text.Trim() == "���в���" ? "0" : treeInfo.SelectedNode.Text.Trim(),
                    cmbFactory.SelectedValue.ToString(), cmbEquType.SelectedValue.ToString(), dtStartTime.Text.Trim(), dtEndTime.Text.Trim()).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    dgvEquQuery.Columns.Clear();

                    dgvEquQuery.DataSource = dt;
                }
                else
                {
                    while (this.dgvEquQuery.Rows.Count != 0)
                    {
                        this.dgvEquQuery.Rows.RemoveAt(0);
                    }
                    MessageBox.Show("û����Ҫ���ҵ�����");
                }
            }

            treeInfo.Focus();
        }
        #endregion

        #region ���� �����¼� Click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString();

            txtName.Text = "";
            txtCardAddress.Text = "";
            txtEmpCard.Text = "";

            treeInfo.SelectedNode = treeInfo.Nodes[0];
            cmbWorkType.SelectedIndex = cmbCerType.SelectedIndex = cmbDutyName.SelectedIndex = cmbDutyClass.SelectedIndex = 0;

            // �豸
            txtEquName.Text = "";
            cmbFactory.SelectedIndex = cmbEquType.SelectedIndex = 0;
        }
        #endregion

        #endregion

        #region �л����

        // �����豸ʱ����
        private void btnPanelEqu_Click(object sender, EventArgs e)
        {
            
        }

        // ������Աʱ����
        private void btnPanelPerson_Click(object sender, EventArgs e)
        {
            
        }

        #region �жϽ���������ʾ��Ա��ѯ�����豸��ѯ
        // �жϽ���������ʾ��Ա��ѯ�����豸��ѯ
        public void IsEquOrPer(bool bl)
        {
            gbx0.Visible = !bl;
            gbEqu.Visible = bl;
            // ��Ա����ѯ����ʾ
            dgValue.Visible = !bl;

            gbEqu.Visible = bl;
            gbEqu.Left = gbx0.Left;
            gbEqu.Top = gbx0.Top;
            dgvEquQuery.Visible = bl;
            dgvEquQuery.Left = dgValue.Left;
            dgvEquQuery.Top = dgValue.Top;
        }
        #endregion

        private void gbEqu_Enter(object sender, EventArgs e)
        {

        }

        #endregion 

        #region ѡ���վ�¼� SelectionChangeCommitted
        private void cmb_Station_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lhab.LoadInfo(cmb_Station, cmb_StaHead, true);
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
            DataSet ds = lhsh.GetInOutStationHeadSet(pIndex, pSize, where);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                //���ķ�����->��������ŵ���Ϣ
                ds.Tables[0].Columns[0].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);
                ds.Tables[0].Columns[4].ColumnName = HardwareName.Value(CorpsName.StationAddress);
                ds.Tables[0].Columns[5].ColumnName = HardwareName.Value(CorpsName.StaHeadAddress);
                ds.Tables[0].Columns[6].ColumnName = HardwareName.Value(CorpsName.StaHeadSplace);

                // ��������ҳ��
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                //if (sumPage > 1)
                //{
                //    bcpPageSum.Visible = true;
                //    bcpPageSum.Location = new Point(340, 9);
                //}
                //else
                //{
                //    bcpPageSum.Visible = true;
                //    bcpPageSum.Location = new Point(633, 9);

                //}
                string strTemp = rbtnEmp.Checked ? " ��" : " ��";
                if (pIndex > sumPage)
                {
                    if (sumPage == 0)
                    {
                        dgValue.Columns.Clear();
                        dgValue.DataSource = ds.Tables[0];
                        dgValue.Columns[0].FillWeight = 60;
                        dgValue.Columns[1].FillWeight = 60;
                        dgValue.Columns[2].FillWeight = 70;
                        dgValue.Columns[4].FillWeight = 50;
                        dgValue.Columns[5].FillWeight = 60;
                        dgValue.Columns[6].FillWeight = 180;
                        dgValue.Columns[7].FillWeight = 120;
                        dgValue.Columns[8].FillWeight = 120;
                        dgValue.Columns[10].Visible = false;
                        dgValue.Columns[11].Visible = false;
                        dgValue.Columns[12].Visible = false;
                        dgValue.Columns[13].Visible = false;
                        buttonCaptionPanel1.CaptionTitle = "��ʷ����������վ��¼��ʾ: �� 0"+strTemp;
                        pageControlsVisible(false);
                        return;
                    }
                    // �������һҳ
                    return;
                }

                buttonCaptionPanel1.CaptionTitle = "��ʷ����������վ��¼��ʾ: ��" + ds.Tables[1].Rows[0][0].ToString() + strTemp;
                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "ҳ";
                dgValue.Columns.Clear();
                dgValue.DataSource = ds.Tables[0];
                dgValue.Columns[0].FillWeight = 55;
                dgValue.Columns[1].FillWeight = 60;
                dgValue.Columns[2].FillWeight = 70;
                dgValue.Columns[4].FillWeight = 50;
                dgValue.Columns[5].FillWeight = 55;
                dgValue.Columns[6].FillWeight = 180;
                dgValue.Columns[7].FillWeight = 120;
                dgValue.Columns[8].FillWeight = 120;
                dgValue.Columns[10].Visible = false;
                dgValue.Columns[11].Visible = false;
                dgValue.Columns[12].Visible = false;
                dgValue.Columns[13].Visible = false;

                dgValue.Columns[7].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dgValue.Columns[8].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

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

        #region ѡ��ÿҳ��ʾ����
        private void cbPSize_DropDownClosed(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cbPSize.SelectedItem);
            //SelectInfo(1);
            btnSearch_Click(sender, e);
            cpUp.Enabled = false;
            cpDown.Enabled = true;
        }
        #endregion

        #region [ �¼�: ��ӡ ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgValue,Text);
        }

        #endregion

        //��Ա
        private void rbtnEmp_Click(object sender, EventArgs e)
        {
            IsEquOrPer(false);

            // �����Ա��ʾ�Ľ���
            while (this.dgValue.Rows.Count != 0)
            {
                this.dgValue.Rows.RemoveAt(0);
            }
        }

        //�����豸
        private void rbtnEqu_Click(object sender, EventArgs e)
        {
            IsEquOrPer(true);

            // ����豸��ʾ�Ľ���
            while (this.dgvEquQuery.Rows.Count != 0)
            {
                this.dgvEquQuery.Rows.RemoveAt(0);
            }
        }

    }
}