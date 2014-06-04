using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KJ128NDBTable;
using KJ128NInterfaceShow;

namespace KJ128NMainRun.ConfigInfo.ConEmployeeInfo
{
    public partial class FrmConEmployeeInfo : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]

        private ConEmployeeInfoBLL ceibll = new ConEmployeeInfoBLL();

        /// <summary>
        /// 记录选中的部门 DeptID 和子部门 DeptID
        /// </summary>
        private static string deptID = "";

        #endregion


        #region [ 构造函数 ]

        public FrmConEmployeeInfo()
        {
            InitializeComponent();

            #region 加载部门, 工种, 证书, 职务, 职务等级 信息
            if (!ceibll.LoadInfo(tvDepartment, cmb_EmpWtName, cmb_EmpDutyName, 1))
            {
                MessageBox.Show("对不起, 基本数据加载失败！");
                return;
            }

            tvDepartment.ExpandAll();
            tvDepartment.SelectedNode = tvDepartment.Nodes[0];
            #endregion

            cbpSearch_Click(null,null);
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

        /*
         * 事件
         */ 

        #region [ 事件: 重置_Click事件 ]

        private void cbtClear_Click(object sender, EventArgs e)
        {
            tvDepartment.ExpandAll();
            tvDepartment.SelectedNode = tvDepartment.Nodes[0];
            txt_EmpName.Text = "";
            txt_EmpNo.Text = "";
            txt_EmpIDcard.Text = "";
            cmb_EmpWtName.SelectedIndex = 0;
            cmb_EmpDutyName.SelectedIndex = 0;
        }

        #endregion

        #region [ 事件: 查询_Click事件 ]

        private void cbpSearch_Click(object sender, EventArgs e)
        {
            if (tvDepartment.SelectedNode.Name == "0")
            {
                deptID = "";
            }
            else
            {
                deptID = tvDepartment.SelectedNode.Name;
                GetNodeAllChild(tvDepartment.SelectedNode);
            }
            string strCounts;
            ceibll.N_SearchConEmployeeInfo(txt_EmpName.Text.Trim(), txt_EmpNo.Text.Trim(), txt_EmpIDcard.Text.Trim(), deptID, cmb_EmpWtName.SelectedValue.ToString(), cmb_EmpDutyName.SelectedValue.ToString(), dgValue,out strCounts);
            //bcpPageSum.Visible = true;
            cpEmployeeInfo.CaptionTitle = "符合筛选条件的员工信息:\t共 " + strCounts + " 人";
            //bcpPageSum.CaptionTitle = ";
        }
        #endregion

        #region [ 事件: 打印 ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgValue,Text);
        }

        #endregion
    }
}