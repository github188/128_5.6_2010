using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using PrintCore;
 

namespace KJ128NMainRun
{
    public partial class FrmRealTimePathCheck : Wilson.Controls.Docking.DockContent
    {

       // private FormHisPassInfo frm = null;

        private RealTimePathCheckBll bll = new RealTimePathCheckBll();

        private PathInfoBll pbll = new PathInfoBll();

        public FrmRealTimePathCheck()
        {
            InitializeComponent();
        }

        private void FrmRealTimePathCheck_Load(object sender, EventArgs e)
        {
            InitializeTreeView();
            BandingTimeInterval();
            cbInterval.SelectedIndex = 0;
        }

        private DataTable InitializeData(string cond)
        {
            return pbll.SelectPathInfo(cond);
            //return new DataTable();
        }

        private void InitializeTreeView()
        {
            DataTable dt = InitializeData("");

            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                    //�����
                    twMain.Nodes[0].Nodes.Clear();


                    foreach (DataRow dr in dt.Rows)
                    {
                        TreeNode node = new TreeNode(dr["PathNo"].ToString());
                        node.Name = dr["PathNo"].ToString();
                        node.ToolTipText = "·�߱��:" + dr["PathNo"].ToString() + "\n"
                            + "·����:" + dr["PathName"].ToString() + "\n"
                            + "·�߱�ע��" + dr["Remark"].ToString();
                        twMain.Nodes[0].Nodes.Add(node);
                    }

                    twMain.ExpandAll();
                }
                catch
                {
                    MessageBox.Show("����·������Ϣʧ��", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void twMain_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Node.Nodes.Count < 1)
            {
                //MessageBox.Show(e.Node.Name);

                string pathNo = e.Node.Name;
                if (bll == null)
                    bll = new RealTimePathCheckBll();

                DataTable dt = bll.SelectRealTimePathCheckByPath(pathNo);
                this.dgvMain.DataSource = dt;
                this.dgvMain.Columns["ID"].Visible = false;
                this.dgvMain.Columns["EmpID"].Visible = false;

            }
        }

        private void bcpSelect_Click(object sender, EventArgs e)
        {
            if (cbInterval.Text != "")
            {
                int inter = Convert.ToInt32(cbInterval.SelectedValue);

                //MessageBox.Show(inter.ToString());

                if (bll == null)
                    bll = new RealTimePathCheckBll();

                DataTable dt = bll.SelectRealTimePathCheckByInterval(inter);
                this.dgvMain.DataSource = dt;
                this.dgvMain.Columns["ID"].Visible = false;
                this.dgvMain.Columns["EmpID"].Visible = false;
            }
        }

        private void dgvMain_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //MessageBox.Show(e.RowIndex.ToString() + "-" + e.ColumnIndex);

                string empID = dgvMain.Rows[e.RowIndex].Cells["EmpID"].Value.ToString();
                string empName = dgvMain.Rows[e.RowIndex].Cells["����"].Value.ToString();
                string beginTime = dgvMain.Rows[e.RowIndex].Cells["Ѳ��ʱ��"].Value.ToString();
                //MessageBox.Show(empNo);

                FormHisPassInfo frm = new FormHisPassInfo(empID, empName, beginTime);
                frm.ShowDialog();
                frm.Dispose();
                
            }
        }

        private void bcpPrint_Click(object sender, EventArgs e)
        {
            if (this.dgvMain.DataSource == null)
            {
                MessageBox.Show("��ӡʧ�ܣ�ԭ��:�����ݻ��ӡ���ݽṹ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return; 
            }
            //FormPrint frm = new FormPrint();
            //frm.CallPrintForm(this.dgvMain, "ʵʱ�����쳣Ѳ����Ϣ", "��" + dgvMain.Rows.Count.ToString() + "��ʵʱ�����쳣Ѳ����Ϣ");
            KJ128NDBTable.PrintBLL.Print(this.dgvMain, "ʵʱ�����쳣Ѳ����Ϣ", "��" + dgvMain.Rows.Count.ToString() + "��ʵʱ�����쳣Ѳ����Ϣ");
        }

        private void BandingTimeInterval()
        {
            DataTable dt = bll.GetTimeInterval();

            if (dt != null && dt.Rows.Count > 0)
            {
                cbInterval.DisplayMember = "IntervalName";
                cbInterval.ValueMember = "ID";

                cbInterval.DataSource = dt;
            }
        }

    }
}