using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KJ128NDBTable;
using KJ128WindowsLibrary;
using KJ128NInterfaceShow;

namespace KJ128NMainRun.ConfigInfo.ConDeptManage
{
    public partial class FrmConDeptManage : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]

        private ConDeptManageBLL cdmbll = new ConDeptManageBLL();
        
        private string strDeptID;

        private string strType = "工种信息";

        #endregion


        #region [ 构造函数 ]

        public FrmConDeptManage()
        {
            InitializeComponent();

            #region 加载部门, 工种, 证书, 职务, 职务等级 信息
            if (!cdmbll.N_LoadInfo(tvDepartment, 1))
            {
                MessageBox.Show("对不起, 基本数据加载失败！");
                return;
            }

            tvDepartment.ExpandAll();
            tvDepartment.SelectedNode = tvDepartment.Nodes[0];
            #endregion

            cdmbll.N_SearchDeptInfo(dgvDept, "");
            int iSum = cdmbll.N_SearchInfo(dgValue, "WorkType");
            captionPanel5.CaptionTitle += ":\t共 " + iSum.ToString() + " 条记录";
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
                    strDeptID += " or Di1.DeptID=" + n.Name;
                }
            }
        }

        #endregion

        /*
         * 事件
         */ 

        #region  [ 事件: 部门树单击事件 ]

        private void tvDepartment_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvDepartment.SelectedNode.Name == "0")
            {
                strDeptID = "";
            }
            else
            {
                strDeptID = tvDepartment.SelectedNode.Name;
                GetNodeAllChild(tvDepartment.SelectedNode);
            }
            int iSum = cdmbll.N_SearchDeptInfo(dgvDept, strDeptID);
            buttonCaptionPanel2.CaptionTitle = "部门信息一览表:\t共 " + iSum .ToString()+ " 人";
        }

        #endregion

        #region [ 事件: 工种信息_Click事件 ]

        private void cap_WorkType_Click(object sender, EventArgs e)
        {
            strType = "工种信息";
            cap_WorkType.SetCaptionPanelStyle = CaptionPanelStyleEnum.BlueCaption;
            cap_Cer.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            cap_Duty.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            captionPanel5.CaptionTitle = "工种信息一览表";
            int iSum=cdmbll.N_SearchInfo(dgValue, "WorkType");
            captionPanel5.CaptionTitle += ":\t共 " + iSum .ToString()+ " 条";
        }

        #endregion

        #region [ 事件: 证书信息_Click事件 ]

        private void cap_Cer_Click(object sender, EventArgs e)
        {
            strType = "证书信息";
            cap_WorkType.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            cap_Cer.SetCaptionPanelStyle = CaptionPanelStyleEnum.BlueCaption;
            cap_Duty.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            captionPanel5.CaptionTitle = "证书信息一览表";
            int iSum=cdmbll.N_SearchInfo(dgValue,"Certificate");
            captionPanel5.CaptionTitle += ":\t共 " + iSum.ToString() + " 条";
        }

        #endregion

        #region [ 事件: 职务信息_Click事件 ]

        private void cap_Duty_Click(object sender, EventArgs e)
        {
            strType = "职务信息";
            cap_WorkType.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            cap_Cer.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            cap_Duty.SetCaptionPanelStyle = CaptionPanelStyleEnum.BlueCaption;
            captionPanel5.CaptionTitle = "职务信息一览表";
            int iSum=cdmbll.N_SearchInfo(dgValue, "Duty");
            captionPanel5.CaptionTitle += ":\t共 " + iSum.ToString() + " 条";
        }

        #endregion

        #region [ 事件: 部门信息导入Excel ]

        private void cpDeptToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvDept,"部门信息");
        }

        #endregion

        #region [ 事件: 证书、职务、工种信息打印 ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgValue,strType);
        }

        #endregion
    }
}