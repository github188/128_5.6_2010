using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KJ128NDBTable;
using KJ128NInterfaceShow;
using KJ128NDataBase;

namespace KJ128NMainRun.RealTime.RealtimeOverTimeInfo
{
    public partial class FrmRealtimeOverTimeInfo : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]
        
        private RealtimeOverTimeInfoBLL rtotbll = new RealtimeOverTimeInfoBLL();
        private static string strName;
        private static string strCard;
        private static string strWorkTypeId;
        private static string strDutyId;
        private bool blIsFirst = false;
        private bool blIsAlarm = false;

        /// <summary>
        /// 记录选中的部门 DeptID 和子部门 DeptID
        /// </summary>
        private static string deptID = "";

        #endregion


        #region [ 构造函数 ]

        public FrmRealtimeOverTimeInfo(bool bl)
        {

            InitializeComponent();

            #region 加载部门, 工种,  职务  信息
            if (!rtotbll.N_LoadInfo(treeInfo, cmbWorkType,cmbDutyName, 1))
            {
                MessageBox.Show("对不起, 基本数据加载失败！");
                return;
            }
            #endregion

            treeInfo.ExpandAll();
            treeInfo.SelectedNode = treeInfo.Nodes[0];
            blIsAlarm = bl;

            label8.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + ":";
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
                    deptID += " or Dei.DeptID=" + n.Name;
                }
            }
        }

        #endregion

        #region [ 方法: 查询实时超时信息 ]

        /// <summary>
        /// 查询实时超时信息
        /// </summary>
        private void SelectOverTimeInfo()
        {
            string strCounts;
            rtotbll.N_SearchOverTimeInfo(strName, strCard, deptID, strWorkTypeId, strDutyId, dgValue,out strCounts);
            //bcpPageSum.CaptionTitle = "共" + strCounts + "条";
            lb_Counts.Text = "共 " + strCounts + " 人";
        }

        #endregion

        /*
         * 事件
         */
 
        #region [ 事件: 查询_Click事件 ]

        private void btnSearch_Click(object sender, EventArgs e)
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

            strName = txtName.Text.Trim();
            strCard = txtCardAddress.Text.Trim();
            //strDeptName = treeInfo.SelectedNode.Text.Trim();
            strWorkTypeId = cmbWorkType.SelectedValue.ToString();
            strDutyId = cmbDutyName.SelectedValue.ToString();
            blIsFirst = true;

            SelectOverTimeInfo();       //查询 实时超时信息
        }

        #endregion

        #region [ 事件: 重置_Click事件 ]

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtCardAddress.Text = "";
            cmbDutyName.SelectedValue = 0;
            cmbWorkType.SelectedValue = 0;

            treeInfo.ExpandAll();
            treeInfo.SelectedNode = treeInfo.Nodes[0];
        }

        #endregion

        #region [ 事件: 是否实时更新数据 ]

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                timeControl.Start();        //实时更新
            }
            else
            {
                timeControl.Stop();         //不实时更新
            }
        }

        #endregion

        #region [ 事件: 定时器 ]

        private void timeControl_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                if (blIsFirst)
                {
                    SelectOverTimeInfo();       //查询实时超时信息
                }
            }
        }

        #endregion

        #region [ 事件: 窗体加载 ]

        private void FrmRealtimeOverTimeInfo_Load(object sender, EventArgs e)
        {
            //if (blIsAlarm)
            //{
                btnSearch_Click(sender, e);
           // }
        }

        #endregion

        #region [ 事件: 导出Excel ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgValue, Text, lb_Counts.Text);
        }

        #endregion
    }
}