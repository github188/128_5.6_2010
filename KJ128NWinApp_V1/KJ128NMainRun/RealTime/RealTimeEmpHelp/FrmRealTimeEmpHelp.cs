using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NDataBase;
using KJ128WindowsLibrary;

namespace KJ128NMainRun.RealTime
{
    public partial class FrmRealTimeEmpHelp : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]

        private Li_HisInMineRecordSet_BLL lhimbll = new Li_HisInMineRecordSet_BLL();
        private Li_HistoryInOutAntenna_BLL lhab = new Li_HistoryInOutAntenna_BLL();
        private RTEmpHelpBLL rtebll = new RTEmpHelpBLL();


        //拖动
        private bool isMove = false;            // (设置面板) 是否移动
        private int mleft = 0;
        private int mtop = 0;

        /// <summary>
        /// 修改措施的员工ID
        /// </summary>
        private string strEmpID_Measure = string.Empty;

        /// <summary>
        /// 查询条件中部门信息
        /// </summary>
        private static string deptName = "";

        #endregion

        #region [ 构造函数 ]

        public FrmRealTimeEmpHelp()
        {
            InitializeComponent();

            label7.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + ":";

            label8.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + ":";

            label6.Text = HardwareName.Value(CorpsName.StationSplace) + ":";

            label3.Text = HardwareName.Value(CorpsName.StaHeadSplace) + ":";

            dgvRTEmpHelp.Columns[0].HeaderText = HardwareName.Value(CorpsName.StationAddress);
            dgvRTEmpHelp.Columns[1].HeaderText = HardwareName.Value(CorpsName.StationSplace);
            dgvRTEmpHelp.Columns[2].HeaderText = HardwareName.Value(CorpsName.StaHeadAddress);
            dgvRTEmpHelp.Columns[3].HeaderText = HardwareName.Value(CorpsName.StaHeadSplace);
            dgvRTEmpHelp.Columns[4].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);

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
                    deptName += " or 部门='" + n.Text.Trim() + "' ";
                }
            }
        }

        #endregion

        #region 处理空数据页数显示
        /// <summary>
        /// 处理空数据页数显示
        /// </summary>
        /// <param name="bl"></param>
        private void pageControlsVisible(bool bl)
        {
            //bcpPageSum.Visible = bl;
            //cpUp.Visible = bl;
            //cpDown.Visible = bl;
            //txtPage.Visible = bl;
            //lblSumPage.Visible = bl;
            //txtCheckPage.Visible = bl;
            //cpCheckPage.Visible = bl;
        }
        #endregion


        /*
         * 事件
         */ 

        #region [ 事件: 窗体加载 ]

        private void FrmHisEmpHelp_Load(object sender, EventArgs e)
        {

            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString();

            #region 加载部门、工种、职务信息

            lhimbll.LoadInfo(treeInfo, cmbWorkType, null, cmbDutyName, null, 1);
            treeInfo.ExpandAll();
            treeInfo.SelectedNode = treeInfo.Nodes[0];

            #endregion

            #region 加载分站、接收器信息

            lhab.LoadInfo(cmb_Station, cmb_StaHead, false);

            #endregion

        }

        #endregion

        #region [ 事件: 选择分站事件 ]

        private void cmb_Station_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lhab.LoadInfo(cmb_Station, cmb_StaHead, true);
        }

        #endregion

        #region [ 事件: 查询_Click事件 ]

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

            if (treeInfo.SelectedNode.Text.Equals("所有部门"))
            {
                deptName = "所有部门";
            }
            else
            {
                deptName = " '" + treeInfo.SelectedNode.Text + "' ";
                GetNodeAllChild(treeInfo.SelectedNode);
            }

            rtebll.GetRTEmpHelpInfo(dtStartTime.Text.Trim(), dtEndTime.Text.Trim(), txtCardAddress.Text.Trim(), cmb_Station.SelectedIndex.ToString(), cmb_StaHead.SelectedIndex.ToString(),txtName.Text.Trim(), deptName, cmbDutyName.Text.Trim(), cmbWorkType.Text.Trim(), txt_Measure.Text.Trim(), dgvRTEmpHelp);
        }

        #endregion

        #region [ 事件: 重置_Click事件 ]

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString();

            txtName.Text = "";
            txt_Measure.Text = "";
            txtCardAddress.Text = "";

            treeInfo.SelectedNode = treeInfo.Nodes[0];
            cmbWorkType.SelectedIndex = cmbDutyName.SelectedIndex = cmb_Station.SelectedIndex = cmb_StaHead.SelectedIndex = 0;

        }

        #endregion

        #region [ 事件: 打印 ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvRTEmpHelp, "历史求救信息");
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

        #region [ 事件: 定时器 ]

        private void timeControl_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                btnSearch_Click(null, null);
            }
        }

        #endregion

        #region [ 事件: DataGridView单元格单击事件 ]

        private void dgvRTEmpHelp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRTEmpHelp.Columns[e.ColumnIndex].Name.Equals("Measure") && e.RowIndex >= 0)                 //点击“修改补救措施”
            {
                strEmpID_Measure = dgvRTEmpHelp.Rows[e.RowIndex].Cells["EmpID"].Value.ToString();
                
                vsp_Measure.Visible = true;

                textBox_Measure.Text = rtebll.GetMeasure(strEmpID_Measure);
                textBox_CodeSenderAddress.Text = dgvRTEmpHelp.Rows[e.RowIndex].Cells["发码器编号"].Value.ToString();
                textBox_EmpName.Text = dgvRTEmpHelp.Rows[e.RowIndex].Cells["姓名"].Value.ToString();

            }
            else if (dgvRTEmpHelp.Columns[e.ColumnIndex].Name.Equals("EndHelp") && e.RowIndex >= 0)                 //点击“完成救援”
            {
                string strEmpID = dgvRTEmpHelp.Rows[e.RowIndex].Cells["EmpID"].Value.ToString();

                if (MessageBox.Show("确定救援已完成?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)    //确认救援已完成
                {
                    rtebll.DeleteRTEmpHelp(strEmpID);
                    btnSearch_Click(null, null);
                }
            }
        }

        #endregion

        #region [ 事件: 关闭 修改救援措施 ]

        private void buttonCaptionPanel13_CloseButtonClick(object sender, EventArgs e)
        {
            vsp_Measure.Visible = false;
        }

        #endregion

        #region [ 事件: 返回 ]

        private void buttonCaptionPanel15_Click(object sender, EventArgs e)
        {
            vsp_Measure.Visible = false;
        }

        #endregion

        #region [ 事件: 保存措施 ]

        private void buttonCaptionPanel14_Click(object sender, EventArgs e)
        {
            rtebll.SaveMeasure(strEmpID_Measure, textBox_Measure.Text.Trim());
            btnSearch_Click(sender, e);
            //DutyErorrInfo.CaptionTitle = "提示信息：保存成功!";
            vsp_Measure.Visible = false;
        }

        #endregion

        #region [ 事件: 拖动 ]

        private void buttonCaptionPanel3_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            VSPanel p = (VSPanel)((CaptionPanel)sender).Parent;
            mleft = e.Location.X;
            mtop = e.Location.Y;
        }
        private void buttonCaptionPanel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                VSPanel p = (VSPanel)((CaptionPanel)sender).Parent;
                p.Location = new Point(p.Left + e.Location.X - mleft, p.Top + e.Location.Y - mtop);
            }
        }

        private void buttonCaptionPanel3_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }
        #endregion

        #region [ 事件: 窗体关闭 ]

        private void FrmRealTimeEmpHelp_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!rtebll.GetEmpHelpCounts().Equals("0"))
            //{
            //    MessageBox.Show("还有未完成的求救信息,不能关闭本窗体!");
            //    e.Cancel = true;
            //}
        }

        #endregion

        #region [ 事件: 窗体第一次显示事件 ]

        private void FrmRealTimeEmpHelp_Shown(object sender, EventArgs e)
        {

            btnSearch_Click(null, null);
        }

        #endregion
    }
}
