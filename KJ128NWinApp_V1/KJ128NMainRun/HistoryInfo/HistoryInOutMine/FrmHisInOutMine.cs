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
    public partial class FrmHisInOutMine : Wilson.Controls.Docking.DockContent
    {
        //����
        private Li_HisInOutMine_BLL lhmb = new Li_HisInOutMine_BLL();

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
        public FrmHisInOutMine()
        {
            InitializeComponent();

            dtEndTime.Text =  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
            #region ���ز���, ����, ֤��, ְ��, ְ��ȼ� ��Ϣ
            if (!lhmb.LoadInfo(treeInfo, cmbWorkType, null, cmbDutyName, null, 1))
            {
                MessageBox.Show("�Բ���, �������ݼ���ʧ�ܣ�");
                return;
            }
            #endregion

            treeInfo.ExpandAll();
            treeInfo.SelectedNode = treeInfo.Nodes[0];

            // �����豸���ͣ���������
            DeptBLL deptbll = new DeptBLL();
            deptbll.getEquTYpeCmb(cmbEquType);             // �豸����
            deptbll.getEquFactoryCmb(cmbFactory);          // ��������

            label8.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + ":";
            dgValue.Columns[0].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);
            this.SelectInfo();
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
            //��ȡѡ��Ĳ��ż����Ӳ���
            if (treeInfo.SelectedNode.Text == "���в���")
            {
                deptName = "";
            }
            else
            {
                deptName = " '" + treeInfo.SelectedNode.Text + "' ";
                GetNodeAllChild(treeInfo.SelectedNode);
            }

            //ѡ����Ա���豸
            if (dgValue.Visible == true)
            {
                where= lhmb.SelectWhere(dtStartTime.Text.Trim(), dtEndTime.Text.Trim(), txtName.Text.Trim(), txtCardAddress.Text.Trim(),
                                deptName, cmbWorkType.SelectedValue.ToString(),  cmbDutyName.SelectedValue.ToString());
                SelectInfo();      //��ҳ��ѯ
            }
            //else
            //{
            //    dgvEquQuery.Columns.Clear();

            //    //  ��ȡ�豸�Ĳ�ѯ��¼
            //    dgvEquQuery.DataSource = lhmb.GetConditionEqu(txtEquName.Text.Trim() == "" ? "0" : txtEquName.Text.Trim(),
            //    treeInfo.SelectedNode.Text.Trim() == "���в���" ? "0" : treeInfo.SelectedNode.Text.Trim(),
            //    cmbFactory.SelectedValue.ToString(),cmbEquType.SelectedValue.ToString(), dtStartTime.Text.Trim(), dtEndTime.Text.Trim()).Tables[0];
            //}
        }
        #endregion

        #region ���� ����¼� Click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtEndTime.Text =  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
            txtName.Text = "";
            txtCardAddress.Text = "";
            
            treeInfo.SelectedNode = treeInfo.Nodes[0];
            cmbWorkType.SelectedIndex =  cmbDutyName.SelectedIndex = 0;
        }
        #endregion

        #region ѡ�����

        // ��ʾ�豸���
        private void btnPanelEqu_Click(object sender, EventArgs e)
        {
            btnCancel_Click(sender, e);
            IsEquOrPer(true);
            // ����豸����
            while (dgvEquQuery.Rows.Count != 0)
            {
                dgvEquQuery.Rows.RemoveAt(0);
            }
        }

        // ��ʾ��Ա
        private void btnPanelPerson_Click(object sender, EventArgs e)
        {
            //btnCancel_Click(sender, e);
            //IsEquOrPer(false);
            //// �����Ա����
            //while (this.dgValue.Rows.Count != 0)
            //{
            //    this.dgValue.Rows.RemoveAt(0);
            //}
        }

        #region �ж�ѡ���ĸ����
        /// <summary>
        /// �ж�ѡ���ĸ����
        /// </summary>
        /// <param name="bl">true ʱ��ѡ���豸���</param>
        public void IsEquOrPer(bool bl)
        {
            gbxEqu.Visible = bl;
            gbx0.Visible = !bl;
            dgvEquQuery.Visible = bl;
            dgValue.Visible = !bl;
            if (bl)
            {
                gbxEqu.Top = gbx0.Top;
                gbxEqu.Left = gbx0.Left;
                dgvEquQuery.Top = dgValue.Top;
                dgvEquQuery.Left = dgValue.Left;
            }
        }
        #endregion 

        #endregion


        //����
        #region ��ҳ��ѯ
        /// <summary>
        /// ��ҳ��ѯ
        /// </summary>
        /// <param name="pIndex">�ڼ�ҳ</param>
        private void SelectInfo()
        {
            DataSet ds = lhmb.GetHisInOutMineSet( where);

            if (ds != null && ds.Tables.Count > 0)
            {
                bcpPageSum.CaptionTitle = "��" + ds.Tables[0].Rows.Count.ToString() + "��";
                dgValue.Columns.Clear();
                dgValue.DataSource = ds.Tables[0];

                dgValue.Columns[0].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);
                //dgValue.Columns[6].Visible = false;
                //dgValue.Columns[7].Visible = false;
                //dgValue.Columns[8].Visible = false;
                //dgValue.Columns[9].Visible = false;
                //dgValue.Columns[10].Visible = false;
                //dgValue.Columns[11].Visible = false;
                //dgValue.Columns[12].Visible = false;
            }
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
                    deptName += " or Di.DeptName='" + n.Text.Trim() + "' ";
                }
            }
        }
        #endregion

        #region ���� Excel
        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgValue,Text);
            //DataGridViewKJ128 dgv = new DataGridViewKJ128();
            //dgv = dgValue;
            //if (dgv.Columns.Count > 6)
            //{
            //    dgv.Columns.Remove(dgv.Columns[6]);
            //    dgv.Columns.Remove(dgv.Columns[6]);
            //    dgv.Columns.Remove(dgv.Columns[6]);
            //    dgv.Columns.Remove(dgv.Columns[6]);
            //    dgv.Columns.Remove(dgv.Columns[6]);
            //    dgv.Columns.Remove(dgv.Columns[6]);
            //    dgv.Columns.Remove(dgv.Columns[6]);
            //}
            //ExcelExports.ExportDataGridViewToExcel(dgv);
        }
        #endregion
    }
}