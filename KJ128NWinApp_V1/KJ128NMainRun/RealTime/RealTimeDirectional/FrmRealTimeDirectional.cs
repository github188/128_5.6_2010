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

        #region [ 声明 ]

        private Li_HisInOutStationHeadRecodset_BLL lhishbll = new Li_HisInOutStationHeadRecodset_BLL();
        private RealTimeDirectionalBLL rtdbll = new RealTimeDirectionalBLL();
        private static string strDeptName = string.Empty;
        private bool blIsDept = false;

        #endregion


        #region [ 构造函数 ]

        public FrmRealTimeDirectional(bool bl, string strDir, int intDirectional, string strStaAddress)
        {
            InitializeComponent();

            label3.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + ":";
            label2.Text = HardwareName.Value(CorpsName.StationAddress) + ":";
            label4.Text = HardwareName.Value(CorpsName.StaHeadAddress) + ":";


            lhishbll.LoadInfo(cmbStation, cmbStaHead, false);
            rtdbll.N_LoadDept(tvDept);

            tvDept.SelectedNode = tvDept.Nodes[0];
            #region 为主界面中方向性查询赋值
            if (bl)
            {
                if (intDirectional == 0)            //员工
                {
                    rbtnEmp.Checked = true;             
                }
                else if (intDirectional == 1)       //设备
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
         * 方法
         */
 
        #region [ 方法: 遍历节点下的所有子节点 ]

        /// <summary>
        /// 遍历节点下的所有子节点
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
                    strDeptName += " or 部门='" + n.Text.Trim() + "' ";
                }
            }
        }

        #endregion

        /*
         * 事件
         */
         
        #region [ 事件: 窗体加载 ]

        private void FrmRealTimeDirectional_Load(object sender, EventArgs e)
        {
            cbpExec_Click(sender, e);
        }

        #endregion

        #region [ 事件: 选择分站事件 ]

        private void cmbStation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lhishbll.LoadInfo(cmbStation, cmbStaHead, true);
        }

        #endregion

        #region [ 事件: 定时器 ]

        private void timeControl_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                if (blIsDept)
                {
                    string strCounts;
                    rtdbll.N_SelectRTDirectional(strDeptName, "", "", "0", "0", rbtnEmp.Checked, "", dgvRTInfo, out strCounts);
                    bcpPageSum.CaptionTitle = "共" + strCounts + "条";
                }
                else
                {
                    cbpExec_Click(sender, e);
                }
            }
        }

        #endregion

        #region [ 事件: 是否实时更新数据 ]

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

        #region [ 事件: 查询_Click事件 ]

        private void cbpExec_Click(object sender, EventArgs e)
        {
            string strCounts;
            blIsDept = false;
            strDeptName = string.Empty;
            if (tvDept.SelectedNode.Text == "所有部门")
            {
                strDeptName = "";
            }
            else
            {
                strDeptName = " '" + tvDept.SelectedNode.Text + "' ";
                GetNodeAllChild(tvDept.SelectedNode);
            }
            rtdbll.N_SelectRTDirectional(strDeptName, txtName.Text.Trim(), txtCardAddress.Text.Trim(), cmbStation.SelectedValue.ToString(), cmbStaHead.SelectedValue.ToString(), rbtnEmp.Checked, txtDirectional.Text.Trim(), dgvRTInfo, out strCounts);
            //bcpPageSum.CaptionTitle = "共" + strCounts + "条";
            if (rbtnEmp.Checked)
            {
                buttonCaptionPanel8.CaptionTitle = "实时方向性信息:\t\t\t\t\t\t\t\t\t" + "共 " + strCounts + " 人";
            }
            else
            {
                buttonCaptionPanel8.CaptionTitle = "实时方向性信息:\t\t\t\t\t\t\t\t\t" + "共 " + strCounts + " 个设备";
            }
        }

        #endregion

        #region [ 事件: 重置_Click事件 ]

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

        #region [ 事件: 选择部门 ]

        private void tvDept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            blIsDept = true;
            strDeptName = string.Empty;
            string strCounts;
            if (tvDept.SelectedNode.Text == "所有部门")
            {
                strDeptName = "";
            }
            else
            {
                strDeptName = " '" + tvDept.SelectedNode.Text + "' ";
                GetNodeAllChild(tvDept.SelectedNode);
            }

            rtdbll.N_SelectRTDirectional(strDeptName, "", "", "0", "0", rbtnEmp.Checked, "", dgvRTInfo, out strCounts);
            bcpPageSum.CaptionTitle = "共" + strCounts + "条";
        }

        #endregion

        #region [ 事件: 打印 ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvRTInfo,Text);
        }

        #endregion
    }
}