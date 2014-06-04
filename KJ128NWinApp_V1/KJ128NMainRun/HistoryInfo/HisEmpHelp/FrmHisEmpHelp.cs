using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NDataBase;

namespace KJ128NMainRun.HistoryInfo
{
    public partial class FrmHisEmpHelp : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]

        private Li_HisInMineRecordSet_BLL lhimbll = new Li_HisInMineRecordSet_BLL();
        private Li_HistoryInOutAntenna_BLL lhab = new Li_HistoryInOutAntenna_BLL();
        private HisEmpHelpBLL hehbll = new HisEmpHelpBLL();

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

        #region [ 构造函数 ]

        public FrmHisEmpHelp()
        {
            InitializeComponent();

            label8.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + ":";

            label6.Text = HardwareName.Value(CorpsName.StationSplace) + ":";

            label3.Text = HardwareName.Value(CorpsName.StaHeadSplace) + ":";

            dgValue.Columns[0].HeaderText = HardwareName.Value(CorpsName.StationAddress);
            dgValue.Columns[1].HeaderText = HardwareName.Value(CorpsName.StationSplace);
            dgValue.Columns[2].HeaderText = HardwareName.Value(CorpsName.StaHeadAddress);
            dgValue.Columns[3].HeaderText = HardwareName.Value(CorpsName.StaHeadSplace);
            dgValue.Columns[4].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);
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

        #region [ 方法: 分页查询 ]

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pIndex">第几页</param>
        private void SelectInfo(int pIndex)
        {
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数！");
                return;
            }
            DataSet ds = hehbll.GetEmpHelpInfo(pIndex, pSize, where);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {

                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;

                if (pIndex > sumPage)
                {
                    if (sumPage == 0)
                    {
                        dgValue.Columns.Clear();
                        dgValue.DataSource = ds.Tables[0];

                        buttonCaptionPanel1.CaptionTitle = "历史求救信息显示: 共 0" + " 记录";
                        pageControlsVisible(false);

                        dgValue.Columns[13].Visible = false;
                        dgValue.Columns[0].HeaderText = HardwareName.Value(CorpsName.StationAddress);
                        dgValue.Columns[1].HeaderText = HardwareName.Value(CorpsName.StationSplace);
                        dgValue.Columns[2].HeaderText = HardwareName.Value(CorpsName.StaHeadAddress);
                        dgValue.Columns[3].HeaderText = HardwareName.Value(CorpsName.StaHeadSplace);
                        dgValue.Columns[4].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);

                        return;
                    }

                    dgValue.Columns[0].HeaderText = HardwareName.Value(CorpsName.StationAddress);
                    dgValue.Columns[1].HeaderText = HardwareName.Value(CorpsName.StationSplace);
                    dgValue.Columns[2].HeaderText = HardwareName.Value(CorpsName.StaHeadAddress);
                    dgValue.Columns[3].HeaderText = HardwareName.Value(CorpsName.StaHeadSplace);
                    dgValue.Columns[4].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);

                    // 大于最后一页
                    return;
                }

                dgValue.Columns[0].HeaderText = HardwareName.Value(CorpsName.StationAddress);
                dgValue.Columns[1].HeaderText = HardwareName.Value(CorpsName.StationSplace);
                dgValue.Columns[2].HeaderText = HardwareName.Value(CorpsName.StaHeadAddress);
                dgValue.Columns[3].HeaderText = HardwareName.Value(CorpsName.StaHeadSplace);
                dgValue.Columns[4].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);

                buttonCaptionPanel1.CaptionTitle = "历史求救信息显示: 共" + sumPage + " 记录";
                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "页";
                dgValue.Columns.Clear();
                dgValue.DataSource = ds.Tables[0];

                dgValue.Columns[9].Width = 150;
                dgValue.Columns[10].Width = 120;
                dgValue.Columns[11].Width = 120;


                dgValue.Columns[10].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dgValue.Columns[11].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                dgValue.Columns[13].Visible = false;

                #region 控制“上一页”、“下一页”等按钮的显示状态
                if (Convert.ToInt32(ds.Tables[1].Rows[0][0]) <= pSize)
                {
                    pageControlsVisible(false);
                }
                else
                {
                    pageControlsVisible(true);
                }
                #endregion
            }
        }
        #endregion

        #region [ 方法: 处理空数据页数显示 ]

        /// <summary>
        /// 处理空数据页数显示
        /// </summary>
        /// <param name="bl"></param>
        private void pageControlsVisible(bool bl)
        {
            //bcpPageSum.Visible = bl;
            cpUp.Visible = bl;
            cpDown.Visible = bl;
            txtPage.Visible = bl;
            lblSumPage.Visible = bl;
            txtCheckPage.Visible = bl;
            cpCheckPage.Visible = bl;
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

            cbPSize.SelectedIndex = 0;

            btnSearch_Click(sender, e);
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

            where = hehbll.SelectWhere(dtStartTime.Text.Trim(), dtEndTime.Text.Trim(), txtName.Text.Trim(), txtCardAddress.Text.Trim(), cmbWorkType.Text.Trim(), deptName,
                                cmbDutyName.Text.Trim(), cmb_Station.SelectedValue.ToString(), cmb_StaHead.SelectedValue.ToString() ,txt_Measure.Text.Trim());

            SelectInfo(1);
        }

        #endregion

        #region [ 事件:重置 单击事件 Click ]

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString();

            txtName.Text = "";
            txt_Measure.Text = "";
            txtCardAddress.Text = "";

            treeInfo.SelectedNode = treeInfo.Nodes[0];
            cmbWorkType.SelectedIndex =  cmbDutyName.SelectedIndex =cmb_Station.SelectedIndex=cmb_StaHead.SelectedIndex= 0;

        }
        #endregion

        #region [ 事件: 翻页 ]

        //上一页
        private void cpUp_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page--;
            cpDown.Cursor = Cursors.Hand;
            cpDown.Enabled = true;
            if (page == 1)
            {
                cpUp.Enabled = false;
            }
            else if (page < 1)
            {
                return;
            }
            SelectInfo(page);
        }

        //下一页
        private void cpDown_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page++;
            cpUp.Enabled = true;
            if (page == countPage)
            {
                cpDown.Enabled = false;
            }
            else if (page > countPage)
            {

                return;
            }
            SelectInfo(page);
        }


        //跳至
        private void cpCheckPage_Click(object sender, EventArgs e)
        {
            string value = txtCheckPage.Text;
            if (value.CompareTo("") == 0)
            {
                return;
            }
            else if (int.Parse(value) > 0)
            {
                int page = int.Parse(value);
                if (page == 1)
                {
                    cpUp.Enabled = false;
                    cpDown.Enabled = true;
                }
                else if (page == countPage)
                {
                    cpUp.Enabled = true;
                    cpDown.Enabled = false;
                }
                else
                {
                    cpUp.Enabled = true;
                    cpDown.Enabled = true;
                }
                if (page > countPage)
                {
                    page = countPage;
                    cpUp.Enabled = true;
                    cpDown.Enabled = false;
                }
                SelectInfo(page);
            }
        }
        #endregion

        #region [ 事件: 选择每页显示行数 ]

        private void cbPSize_DropDownClosed(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cbPSize.SelectedItem);
            //SelectInfo(1);
            btnSearch_Click(sender, e);
            cpUp.Enabled = false;
            cpDown.Enabled = true;
        }

        #endregion

        #region [ 事件: 打印 ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgValue,"历史求救信息");
        }

        #endregion

    }
}
