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
    public partial class FrmHisPathCheck : Wilson.Controls.Docking.DockContent
    {
        private HisPathCheckBll hbll = new HisPathCheckBll();

        private PathInfoBll bll = new PathInfoBll();

        public FrmHisPathCheck()
        {
            InitializeComponent();
        }

        private void FrmHisPathCheck_Load(object sender, EventArgs e)
        {

            BandingTimeInterval();

            InitializeTreeView();

            //cbInterval.SelectedIndex = 0;
        }

        private DataTable InitializeData(string cond)
        {
            return bll.SelectPathInfo(cond);
            //return new DataTable();
        }

        //private void InitializePath()
        //{
        //    this.cbPath.DisplayMember = "PathName";
        //    this.cbPath.ValueMember = "PathNo";
        //    this.cbPath.DataSource = InitializeData("");
        //}

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
                if (hbll == null)
                    hbll = new HisPathCheckBll();

                DataTable dt = hbll.SelectHisPathCheckByPath(pathNo);
                this.dgvMain.DataSource = dt;
                this.dgvMain.Columns["ID"].Visible = false;

            }
        }

        private void bcpSelect_Click(object sender, EventArgs e)
        {
            if (cbInterval.Text != "")
            {
                int inter = (int)cbInterval.SelectedValue;

                //MessageBox.Show(inter.ToString());

                if (hbll == null)
                    hbll = new HisPathCheckBll();

                DataTable dt = hbll.SelectHisPathCheckInterval(inter);
                this.dgvMain.DataSource = dt;
                this.dgvMain.Columns["ID"].Visible = false;
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
            //frm.CallPrintForm(this.dgvMain, "��ʷ·��Ѳ����Ϣ", "��" + dgvMain.Rows.Count.ToString() + "����ʷ·��Ѳ����Ϣ");
            KJ128NDBTable.PrintBLL.Print(this.dgvMain, "��ʷ·��Ѳ����Ϣ", "��" + dgvMain.Rows.Count.ToString() + "����ʷ·��Ѳ����Ϣ");
        }

        private void BandingTimeInterval()
        {
            DataTable dt = hbll.GetTimeInterval();

            if (dt != null && dt.Rows.Count > 0)
            {
                cbInterval.DisplayMember = "IntervalName";
                cbInterval.ValueMember = "ID";

                cbInterval.DataSource = dt;
            }
        }


    }
}