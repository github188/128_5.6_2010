using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NInterfaceShow;
using System.IO;
using KJ128NDataBase;
namespace KJ128NMainRun.RealTime.RealTimeDirectional
{
    public partial class FrmRealTimeDirectional : Wilson.Controls.Docking.DockContent
    {

        #region [ ���� ]

        private Li_HisInOutStationHeadRecodset_BLL lhishbll = new Li_HisInOutStationHeadRecodset_BLL();
        private RealTimeDirectionalBLL rtdbll = new RealTimeDirectionalBLL();
        private static string strDeptName = string.Empty;
        private bool blIsDept = false;

        #endregion


        #region [ ���캯�� ]

        public FrmRealTimeDirectional(bool bl, string strDir, int intDirectional, string strStaAddress)
        {
            InitializeComponent();

            label3.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + ":";
            label2.Text = HardwareName.Value(CorpsName.StationAddress) + ":";
            label4.Text = HardwareName.Value(CorpsName.StaHeadAddress) + ":";


            lhishbll.LoadInfo(cmbStation, cmbStaHead, false);
            rtdbll.N_LoadDept(tvDept);

            tvDept.SelectedNode = tvDept.Nodes[0];
            #region Ϊ�������з����Բ�ѯ��ֵ
            if (bl)
            {
                if (intDirectional == 0)            //Ա��
                {
                    rbtnEmp.Checked = true;             
                }
                else if (intDirectional == 1)       //�豸
                {
                    rbtnEqu.Checked = true;
                }
                txtDirectional.Text = strDir;
                if (rtdbll.SelectStationPlace(strStaAddress) != null)
                {
                    cmbStation.Text = rtdbll.SelectStationPlace(strStaAddress);
                } 
            }
            #endregion

        }

        #endregion

        /*
         * ����
         */
 
        #region [ ����: �����ڵ��µ������ӽڵ� ]

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
                    strDeptName += " or ����='" + n.Text.Trim() + "' ";
                }
            }
        }

        #endregion

        /*
         * �¼�
         */
         
        #region [ �¼�: ������� ]

        private void FrmRealTimeDirectional_Load(object sender, EventArgs e)
        {
            cbpExec_Click(sender, e);
        }

        #endregion

        #region [ �¼�: ѡ���վ�¼� ]

        private void cmbStation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lhishbll.LoadInfo(cmbStation, cmbStaHead, true);
        }

        #endregion

        #region [ �¼�: ��ʱ�� ]

        private void timeControl_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                if (blIsDept)
                {
                    string strCounts;
                    rtdbll.N_SelectRTDirectional(strDeptName, "", "", "0", "0", rbtnEmp.Checked, "", dgvRTInfo, out strCounts);
                    bcpPageSum.CaptionTitle = "��" + strCounts + "��";
                }
                else
                {
                    cbpExec_Click(sender, e);
                }
            }
        }

        #endregion

        #region [ �¼�: �Ƿ�ʵʱ�������� ]

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (chk.Checked)
            {
                timeControl.Start();
            }
            else
            {
                timeControl.Stop();
            }
        }

        #endregion

        #region [ �¼�: ��ѯ_Click�¼� ]

        private void cbpExec_Click(object sender, EventArgs e)
        {
            string strCounts;
            blIsDept = false;
            strDeptName = string.Empty;
            if (tvDept.SelectedNode.Text == "���в���")
            {
                strDeptName = "";
            }
            else
            {
                strDeptName = " '" + tvDept.SelectedNode.Text + "' ";
                GetNodeAllChild(tvDept.SelectedNode);
            }
            rtdbll.N_SelectRTDirectional(strDeptName, txtName.Text.Trim(), txtCardAddress.Text.Trim(), cmbStation.SelectedValue.ToString(), cmbStaHead.SelectedValue.ToString(), rbtnEmp.Checked, txtDirectional.Text.Trim(), dgvRTInfo, out strCounts);
            //bcpPageSum.CaptionTitle = "��" + strCounts + "��";
            if (rbtnEmp.Checked)
            {
                buttonCaptionPanel8.CaptionTitle = "ʵʱ��������Ϣ:\t\t\t\t\t\t\t\t\t" + "�� " + strCounts + " ��";
            }
            else
            {
                buttonCaptionPanel8.CaptionTitle = "ʵʱ��������Ϣ:\t\t\t\t\t\t\t\t\t" + "�� " + strCounts + " ���豸";
            }
        }

        #endregion

        #region [ �¼�: ����_Click�¼� ]

        private void bcpClear_Click(object sender, EventArgs e)
        {
            tvDept.SelectedNode = tvDept.Nodes[0];
            txtCardAddress.Text = "";
            txtDirectional.Text = "";
            txtName.Text = "";
            cmbStaHead.SelectedIndex = 0;
            cmbStation.SelectedIndex = 0;
            rbtnEmp.Checked = true;
        }

        #endregion

        #region [ �¼�: ѡ���� ]

        private void tvDept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            blIsDept = true;
            strDeptName = string.Empty;
            string strCounts;
            if (tvDept.SelectedNode.Text == "���в���")
            {
                strDeptName = "";
            }
            else
            {
                strDeptName = " '" + tvDept.SelectedNode.Text + "' ";
                GetNodeAllChild(tvDept.SelectedNode);
            }

            rtdbll.N_SelectRTDirectional(strDeptName, "", "", "0", "0", rbtnEmp.Checked, "", dgvRTInfo, out strCounts);
            bcpPageSum.CaptionTitle = "��" + strCounts + "��";
        }

        #endregion

        #region [ �¼�: ��ӡ ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvRTInfo,Text);
        }

        #endregion
    }
}