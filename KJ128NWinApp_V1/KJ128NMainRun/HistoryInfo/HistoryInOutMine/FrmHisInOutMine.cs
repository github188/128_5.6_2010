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
        //定义
        private Li_HisInOutMine_BLL lhmb = new Li_HisInOutMine_BLL();

        #region 私有变量
        /// <summary>
        /// 查询条件
        /// </summary>
        private string where;
        /// <summary>
        /// 每页显示条数
        /// </summary>
        private int pSize = 40;
        /// <summary>
        /// 查询结果的总页数
        /// </summary>
        private int countPage;
        /// <summary>
        /// 查询条件中部门信息
        /// </summary>
        private static string deptName = "";
        #endregion

        #region 页面加载
        public FrmHisInOutMine()
        {
            InitializeComponent();

            dtEndTime.Text =  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
            #region 加载部门, 工种, 证书, 职务, 职务等级 信息
            if (!lhmb.LoadInfo(treeInfo, cmbWorkType, null, cmbDutyName, null, 1))
            {
                MessageBox.Show("对不起, 基本数据加载失败！");
                return;
            }
            #endregion

            treeInfo.ExpandAll();
            treeInfo.SelectedNode = treeInfo.Nodes[0];

            // 加载设备类型，生产厂家
            DeptBLL deptbll = new DeptBLL();
            deptbll.getEquTYpeCmb(cmbEquType);             // 设备类型
            deptbll.getEquFactoryCmb(cmbFactory);          // 生产厂家

            label8.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + ":";
            dgValue.Columns[0].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);
            this.SelectInfo();
        }
        #endregion

        //事件
        #region 查询 点击事件 Click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtStartTime.Text.Trim() == "" || dtEndTime.Text.Trim() == "")
            {
                MessageBox.Show("对不起, 开始和结束时间都不能为空！");
                return;
            }
            if (DateTime.Compare(DateTime.Parse(dtStartTime.Text), DateTime.Parse(dtEndTime.Text)) > 0)
            {
                MessageBox.Show("对不起, 开始时间不能大于结束时间！");
                return;
            }
            //获取选择的部门及其子部门
            if (treeInfo.SelectedNode.Text == "所有部门")
            {
                deptName = "";
            }
            else
            {
                deptName = " '" + treeInfo.SelectedNode.Text + "' ";
                GetNodeAllChild(treeInfo.SelectedNode);
            }

            //选择人员或设备
            if (dgValue.Visible == true)
            {
                where= lhmb.SelectWhere(dtStartTime.Text.Trim(), dtEndTime.Text.Trim(), txtName.Text.Trim(), txtCardAddress.Text.Trim(),
                                deptName, cmbWorkType.SelectedValue.ToString(),  cmbDutyName.SelectedValue.ToString());
                SelectInfo();      //分页查询
            }
            //else
            //{
            //    dgvEquQuery.Columns.Clear();

            //    //  获取设备的查询记录
            //    dgvEquQuery.DataSource = lhmb.GetConditionEqu(txtEquName.Text.Trim() == "" ? "0" : txtEquName.Text.Trim(),
            //    treeInfo.SelectedNode.Text.Trim() == "所有部门" ? "0" : treeInfo.SelectedNode.Text.Trim(),
            //    cmbFactory.SelectedValue.ToString(),cmbEquType.SelectedValue.ToString(), dtStartTime.Text.Trim(), dtEndTime.Text.Trim()).Tables[0];
            //}
        }
        #endregion

        #region 重置 点击事件 Click
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

        #region 选择面板

        // 显示设备面板
        private void btnPanelEqu_Click(object sender, EventArgs e)
        {
            btnCancel_Click(sender, e);
            IsEquOrPer(true);
            // 清空设备界面
            while (dgvEquQuery.Rows.Count != 0)
            {
                dgvEquQuery.Rows.RemoveAt(0);
            }
        }

        // 显示人员
        private void btnPanelPerson_Click(object sender, EventArgs e)
        {
            //btnCancel_Click(sender, e);
            //IsEquOrPer(false);
            //// 清空人员界面
            //while (this.dgValue.Rows.Count != 0)
            //{
            //    this.dgValue.Rows.RemoveAt(0);
            //}
        }

        #region 判断选择哪个面板
        /// <summary>
        /// 判断选择哪个面板
        /// </summary>
        /// <param name="bl">true 时是选择设备面板</param>
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


        //方法
        #region 分页查询
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pIndex">第几页</param>
        private void SelectInfo()
        {
            DataSet ds = lhmb.GetHisInOutMineSet( where);

            if (ds != null && ds.Tables.Count > 0)
            {
                bcpPageSum.CaptionTitle = "共" + ds.Tables[0].Rows.Count.ToString() + "条";
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

        #region 遍历节点下的所有子节点
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
                    deptName += " or Di.DeptName='" + n.Text.Trim() + "' ";
                }
            }
        }
        #endregion

        #region 导出 Excel
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