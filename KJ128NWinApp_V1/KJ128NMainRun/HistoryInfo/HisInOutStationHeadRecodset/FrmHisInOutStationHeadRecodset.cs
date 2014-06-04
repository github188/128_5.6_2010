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
    /// <summary>
    /// 历史原始记录显示
    /// </summary>
    public partial class FrmHisInOutStationHead : Wilson.Controls.Docking.DockContent
    {
        //定义
        private Li_HisInOutStationHeadRecodset_BLL lhsh = new Li_HisInOutStationHeadRecodset_BLL();
        private Li_HistoryInOutAntenna_BLL lhab = new Li_HistoryInOutAntenna_BLL();

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

        #region 人员

        //函数
        #region 页面加载
        public FrmHisInOutStationHead()
        {
            InitializeComponent();

            label8.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + ":";
            label4.Text = HardwareName.Value(CorpsName.StationSplace) + ":";
            label5.Text = HardwareName.Value(CorpsName.StaHeadSplace) + ":";

            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString();


            #region 加载部门, 工种, 证书, 职务, 职务等级 信息
            if (!lhsh.LoadInfo(treeInfo, cmbWorkType, cmbCerType, cmbDutyName, cmbDutyClass, 1))
            {
                    MessageBox.Show("对不起, 基本数据加载失败！");
                    return;
            }
            #endregion

            #region 加载分站信息
            lhab.LoadInfo(cmb_Station, cmb_StaHead, false);
            #endregion

            treeInfo.ExpandAll();
            treeInfo.SelectedNode = treeInfo.Nodes[0];

            cbPSize.SelectedIndex = 0;

            // 加载设备类型，生产厂家
            DeptBLL deptbll = new DeptBLL();
            deptbll.getEquTYpeCmb(cmbEquType);             // 设备类型
            deptbll.getEquFactoryCmb(cmbFactory);          // 生产厂家
        }
        #endregion

        #region 点击查询, 重置事件 Click
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
            // 判断是人员查询还是设备查询
            if (rbtnEmp.Checked)
            {
                // 人员查询
                if (treeInfo.SelectedNode.Name == "0")
                {
                    deptName = "";
                }
                else
                {
                    deptName = " '" + treeInfo.SelectedNode.Text + "' ";
                    GetNodeAllChild(treeInfo.SelectedNode);
                }

                where = lhsh.SelectWhere(dtStartTime.Text.Trim(), dtEndTime.Text.Trim(), txtName.Text.Trim(), txtCardAddress.Text.Trim(), txtEmpCard.Text.Trim(),
                                deptName, cmbCerType.SelectedValue.ToString(), cmbDutyName.SelectedValue.ToString(), cmb_Station.SelectedValue.ToString(),
                                cmb_StaHead.SelectedValue.ToString());
                SelectInfo(1);          //分页查询
                cpUp.Enabled = false;
                cpDown.Enabled = true;

            }
            else
            {
                // 设备查询

                DataTable dt = lhsh.GetConditionEqu(txtEquName.Text.Trim() == "" ? "0" : txtEquName.Text.Trim(),
                    treeInfo.SelectedNode.Text.Trim() == "所有部门" ? "0" : treeInfo.SelectedNode.Text.Trim(),
                    cmbFactory.SelectedValue.ToString(), cmbEquType.SelectedValue.ToString(), dtStartTime.Text.Trim(), dtEndTime.Text.Trim()).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    dgvEquQuery.Columns.Clear();

                    dgvEquQuery.DataSource = dt;
                }
                else
                {
                    while (this.dgvEquQuery.Rows.Count != 0)
                    {
                        this.dgvEquQuery.Rows.RemoveAt(0);
                    }
                    MessageBox.Show("没有您要查找的数据");
                }
            }

            treeInfo.Focus();
        }
        #endregion

        #region 重置 单击事件 Click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString();

            txtName.Text = "";
            txtCardAddress.Text = "";
            txtEmpCard.Text = "";

            treeInfo.SelectedNode = treeInfo.Nodes[0];
            cmbWorkType.SelectedIndex = cmbCerType.SelectedIndex = cmbDutyName.SelectedIndex = cmbDutyClass.SelectedIndex = 0;

            // 设备
            txtEquName.Text = "";
            cmbFactory.SelectedIndex = cmbEquType.SelectedIndex = 0;
        }
        #endregion

        #endregion

        #region 切换面板

        // 单击设备时发生
        private void btnPanelEqu_Click(object sender, EventArgs e)
        {
            
        }

        // 单击人员时发生
        private void btnPanelPerson_Click(object sender, EventArgs e)
        {
            
        }

        #region 判断界面上是显示人员查询还是设备查询
        // 判断界面上是显示人员查询还是设备查询
        public void IsEquOrPer(bool bl)
        {
            gbx0.Visible = !bl;
            gbEqu.Visible = bl;
            // 人员类别查询不显示
            dgValue.Visible = !bl;

            gbEqu.Visible = bl;
            gbEqu.Left = gbx0.Left;
            gbEqu.Top = gbx0.Top;
            dgvEquQuery.Visible = bl;
            dgvEquQuery.Left = dgValue.Left;
            dgvEquQuery.Top = dgValue.Top;
        }
        #endregion

        private void gbEqu_Enter(object sender, EventArgs e)
        {

        }

        #endregion 

        #region 选择分站事件 SelectionChangeCommitted
        private void cmb_Station_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lhab.LoadInfo(cmb_Station, cmb_StaHead, true);
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
            cpUp.Visible = bl;
            cpDown.Visible = bl;
            txtPage.Visible = bl;
            lblSumPage.Visible = bl;
            txtCheckPage.Visible = bl;
            cpCheckPage.Visible = bl;
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
                    deptName += " or 部门='" + n.Text.Trim() + "' ";
                }
            }
        }
        #endregion

        #region 分页查询
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
            DataSet ds = lhsh.GetInOutStationHeadSet(pIndex, pSize, where);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                //更改发码器->发码器编号等信息
                ds.Tables[0].Columns[0].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);
                ds.Tables[0].Columns[4].ColumnName = HardwareName.Value(CorpsName.StationAddress);
                ds.Tables[0].Columns[5].ColumnName = HardwareName.Value(CorpsName.StaHeadAddress);
                ds.Tables[0].Columns[6].ColumnName = HardwareName.Value(CorpsName.StaHeadSplace);

                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                //if (sumPage > 1)
                //{
                //    bcpPageSum.Visible = true;
                //    bcpPageSum.Location = new Point(340, 9);
                //}
                //else
                //{
                //    bcpPageSum.Visible = true;
                //    bcpPageSum.Location = new Point(633, 9);

                //}
                string strTemp = rbtnEmp.Checked ? " 人" : " 个";
                if (pIndex > sumPage)
                {
                    if (sumPage == 0)
                    {
                        dgValue.Columns.Clear();
                        dgValue.DataSource = ds.Tables[0];
                        dgValue.Columns[0].FillWeight = 60;
                        dgValue.Columns[1].FillWeight = 60;
                        dgValue.Columns[2].FillWeight = 70;
                        dgValue.Columns[4].FillWeight = 50;
                        dgValue.Columns[5].FillWeight = 60;
                        dgValue.Columns[6].FillWeight = 180;
                        dgValue.Columns[7].FillWeight = 120;
                        dgValue.Columns[8].FillWeight = 120;
                        dgValue.Columns[10].Visible = false;
                        dgValue.Columns[11].Visible = false;
                        dgValue.Columns[12].Visible = false;
                        dgValue.Columns[13].Visible = false;
                        buttonCaptionPanel1.CaptionTitle = "历史进出读卡分站记录显示: 共 0"+strTemp;
                        pageControlsVisible(false);
                        return;
                    }
                    // 大于最后一页
                    return;
                }

                buttonCaptionPanel1.CaptionTitle = "历史进出读卡分站记录显示: 共" + ds.Tables[1].Rows[0][0].ToString() + strTemp;
                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "页";
                dgValue.Columns.Clear();
                dgValue.DataSource = ds.Tables[0];
                dgValue.Columns[0].FillWeight = 55;
                dgValue.Columns[1].FillWeight = 60;
                dgValue.Columns[2].FillWeight = 70;
                dgValue.Columns[4].FillWeight = 50;
                dgValue.Columns[5].FillWeight = 55;
                dgValue.Columns[6].FillWeight = 180;
                dgValue.Columns[7].FillWeight = 120;
                dgValue.Columns[8].FillWeight = 120;
                dgValue.Columns[10].Visible = false;
                dgValue.Columns[11].Visible = false;
                dgValue.Columns[12].Visible = false;
                dgValue.Columns[13].Visible = false;

                dgValue.Columns[7].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dgValue.Columns[8].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

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

        #region 翻页
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

        #region 选择每页显示行数
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
            PrintBLL.Print(dgValue,Text);
        }

        #endregion

        //人员
        private void rbtnEmp_Click(object sender, EventArgs e)
        {
            IsEquOrPer(false);

            // 清空人员显示的界面
            while (this.dgValue.Rows.Count != 0)
            {
                this.dgValue.Rows.RemoveAt(0);
            }
        }

        //单击设备
        private void rbtnEqu_Click(object sender, EventArgs e)
        {
            IsEquOrPer(true);

            // 清空设备显示的界面
            while (this.dgvEquQuery.Rows.Count != 0)
            {
                this.dgvEquQuery.Rows.RemoveAt(0);
            }
        }

    }
}