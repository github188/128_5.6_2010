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
    public partial class RealTimeInOutStationHeadInfo : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]

        private Li_RealTimeInOutStationHeadInfo_BLL lrhb = new Li_RealTimeInOutStationHeadInfo_BLL();

        /// <summary>
        /// 记录选中的部门 DeptID 和其子部门的DeptID
        /// </summary>
        private static string deptID = "";

        #endregion

       
        #region [ 构造函数 ]

        public RealTimeInOutStationHeadInfo()
        {
            InitializeComponent();

            label8.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + ":";
            label1.Text = HardwareName.Value(CorpsName.StationSplace) + ":";
            label4.Text = HardwareName.Value(CorpsName.StaHeadSplace) + ":";

            dtStartTime.Text = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00";
            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            #region 加载分站信息
            lrhb.LoadInfo(cmbStationAddress, cmbStationHeadAddress, false);
            #endregion

            #region 加载(部门, 工种)信息
            lrhb.N_LoadInfo(treeInfo, cmbWorkType, 1);
            #endregion

            treeInfo.ExpandAll();
            treeInfo.SelectedNode = treeInfo.Nodes[0];
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
                    deptID += " or Di.DeptID=" + n.Name;
                }
            }
        }

        #endregion

        #region [ 方法: 查询实时进出接收器信息 ]

        /// <summary>
        /// 查询实时进出接收器信息

        /// </summary>
        private void SelectInOutStaHeadInfo()
        {
            if (treeInfo.SelectedNode.Name == "0")
            {
                deptID = "";
            }
            else
            {
                deptID = treeInfo.SelectedNode.Name;
                GetNodeAllChild(treeInfo.SelectedNode);
            }
            string strCounts;
            if (rbEmp.Checked)
            {
                lrhb.N_SearchRTInOutStationHeadInfo(
                    dtStartTime.Text.Trim(),
                    dtEndTime.Text.Trim(),
                    cmbStationAddress.SelectedValue.ToString(),
                    cmbStationHeadAddress.SelectedValue.ToString(),
                    txtName.Text.Trim(),
                    txtCard.Text.Trim(),
                    cmbWorkType.SelectedValue.ToString(),
                    /*treeInfo.SelectedNode.Text,*/
                    deptID,
                    0,
                    dgValue,
                    out strCounts);
                if (strCounts != "-1")
                {
                    //bcpPageSum.CaptionTitle = "共" + strCounts + "条";
                    lb_Counts.Text = "共 " + strCounts + " 人";
                }
            }
            else
            {
                lrhb.N_SearchRTInOutStationHeadInfo_Equ(dtStartTime.Text.Trim(), dtEndTime.Text.Trim(), cmbStationAddress.SelectedValue.ToString(),
                        cmbStationHeadAddress.SelectedValue.ToString(), txtEquName.Text.Trim(),txtEquAddress.Text.Trim(),txtEquNO.Text.Trim(), deptID, dgValue, out strCounts);

                if (strCounts != "-1")
                {
                    //bcpPageSum.CaptionTitle = "共" + strCounts + "条";
                    lb_Counts.Text = "共 " + strCounts + " 个设备";
                }
            }
        }

        #endregion

        /*
         * 事件
         */

        #region [ 事件: 窗体加载 ]

        private void RealTimeInOutStationHeadInfo_Load(object sender, EventArgs e)
        {
            this.SelectInOutStaHeadInfo();
        }

        #endregion

        #region [ 事件: 选择分站_SelectionChangeCommitted事件 ]

        private void cmbStationAddress_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lrhb.LoadInfo(cmbStationAddress, cmbStationHeadAddress, true);
        }

        #endregion

        #region [ 事件: 查询按钮_Click事件 ]

        private void btnSearch_Click(object sender, EventArgs e)
        {

            this.SelectInOutStaHeadInfo();
        }

        #endregion

        #region [ 事件: 重置按钮_Click事件 ]

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtStartTime.Text = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00";
            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            txtName.Text = "";
            txtCard.Text = "";

            lrhb.LoadInfo(cmbStationAddress, cmbStationHeadAddress, false);
            cmbWorkType.SelectedIndex = 0;
            treeInfo.SelectedNode = treeInfo.Nodes[0];
        }

        #endregion

        #region [ 事件: 定时器 ]

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                this.SelectInOutStaHeadInfo();
            }
        }

        #endregion

        #region [ 事件: 是否实时更新数据 ]

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (chk.Checked)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
        }

        #endregion

        #region [ 事件: 打印 ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgValue,Text,lb_Counts.Text);
        }

        #endregion

        #region [ 事件: 选择人员或设备 ]

        private void rbEmp_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEmp.Checked)
            {
                gbx_Emp.Visible = true;
                gbx_Equ.Visible = false;
            }
            else
            {
                gbx_Emp.Visible = false;
                gbx_Equ.Visible = true;
            }
        }

        #endregion

    }
}