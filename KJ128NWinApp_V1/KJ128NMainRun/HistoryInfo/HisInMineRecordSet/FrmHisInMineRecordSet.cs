using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KJ128NDBTable;
using KJ128NMainRun;
using KJ128NDataBase;

namespace KJ128NInterfaceShow
{
    public partial class FrmHisInMineRecordSet : Wilson.Controls.Docking.DockContent
    {
        //定义
        Li_HisInMineRecordSet_BLL lhrb = new Li_HisInMineRecordSet_BLL();

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
        public FrmHisInMineRecordSet()
        {
            InitializeComponent();
            dtStartTime.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            #region 加载部门, 工种, 证书, 职务, 职务等级 信息
            if (!lhrb.LoadInfo(treeInfo, cmbWorkType, cmbCerType, cmbDutyName, cmbDutyClass, 1))
            {
                MessageBox.Show("对不起, 基本数据加载失败！");
                return;
            }
            #endregion

            treeInfo.ExpandAll();
            treeInfo.SelectedNode = treeInfo.Nodes[0];
            cbPSize.SelectedIndex = 0;
            label8.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + ":";
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
            if (treeInfo.SelectedNode.Name == "0")
            {
                deptName = "";
            }
            else
            {
                deptName = " '" + treeInfo.SelectedNode.Text + "' ";
                GetNodeAllChild(treeInfo.SelectedNode);
            }


            where = lhrb.SelectWhere(dtStartTime.Text.Trim(), dtEndTime.Text.Trim(), txtName.Text.Trim(), txtCardAddress.Text.Trim(), txtEmpCard.Text.Trim(),
                    deptName, cmbWorkType.SelectedValue.ToString(), cmbCerType.SelectedValue.ToString(), cmbDutyName.SelectedValue.ToString(),
                    cmbDutyClass.SelectedValue.ToString());
            SelectInfo(1);
            cpUp.Enabled = false;
            cpDown.Enabled = true;
        }
        #endregion

        #region 重置 点击事件 Click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtStartTime.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            txtName.Text = "";
            txtCardAddress.Text = "";
            txtEmpCard.Text = "";

            treeInfo.SelectedNode = treeInfo.Nodes[0];
            cmbWorkType.SelectedIndex = cmbCerType.SelectedIndex = cmbDutyName.SelectedIndex = cmbDutyClass.SelectedIndex = 0;
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

        #region 选择每页行数
        private void cbPSize_DropDownClosed(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cbPSize.SelectedItem);
            //SelectInfo(1);
            btnSearch_Click(sender, e);
            cpUp.Enabled = false;
            cpDown.Enabled = true;
        }
        #endregion

        //方法
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
            DataSet ds = lhrb.GetHisInMineSet(pIndex, pSize, where);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                //if (sumPage > 1)
                //{
                //    bcpPageSum.Visible = true;
                //    bcpPageSum.Location = new Point(321, 9);
                //}
                //else
                //{
                //    bcpPageSum.Visible = true;
                //    bcpPageSum.Location = new Point(629, 9);

                //}

                if (pIndex > sumPage)
                {
                    if (sumPage == 0)
                    {

                        dgValue.Columns.Clear();
                        dgValue.DataSource = ds.Tables[0];
                        dgValue.Columns[9].Visible = false;
                        dgValue.Columns[10].Visible = false;
                        dgValue.Columns[11].Visible = false;
                        dgValue.Columns[12].Visible = false;
                        dgValue.Columns[13].Visible = false;
                        dgValue.Columns[14].Visible = false;


                        dgValue.Columns[5].FillWeight = 130;
                        dgValue.Columns[7].FillWeight = 130;

                        dgValue.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        dgValue.Columns[7].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                        AddColumns();

                        buttonCaptionPanel1.CaptionTitle = "历史下井记录显示: 共 0 记录";
                        pageControlsVisible(false);
                        return;
                    }
                    // 大于最后一页
                    return;
                }
                buttonCaptionPanel1.CaptionTitle = "历史下井记录显示: 共 " + ds.Tables[1].Rows[0][0].ToString() + " 记录";
                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "页";

                dgValue.Columns.Clear();
                dgValue.DataSource = ds.Tables[0];
                dgValue.Columns[9].Visible = false;
                dgValue.Columns[10].Visible = false;
                dgValue.Columns[11].Visible = false;
                dgValue.Columns[12].Visible = false;
                dgValue.Columns[13].Visible = false;
                dgValue.Columns[14].Visible = false;

                dgValue.Columns[5].FillWeight = 130;
                dgValue.Columns[7].FillWeight = 130;

                dgValue.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dgValue.Columns[7].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                AddColumns();
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

        #region [ 事件: 打印 ]

        private void cpStationToExcel_Click(object sender, EventArgs e)
        {
            if (dgValue.DataSource != null)
            {
                PrintBLL.Print(dgValue, Text);
            }
            else
            {
                MessageBox.Show("查询无数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        #region [ 方法: 添加查看列 ]

        private void AddColumns()
        {
            DataGridViewLinkColumn dgvLink = new DataGridViewLinkColumn();
            dgvLink.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvLink.HeaderText = "查看员工信息";
            dgvLink.Name = "EmpInfo";
            dgvLink.Text = "查看";
            dgvLink.UseColumnTextForLinkValue = true;
            dgvLink.Resizable = DataGridViewTriState.False;
            dgValue.Columns.Add(dgvLink);
        }

        #endregion

        #region [ 事件: 单击单元格 ]
        private void dgValue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 15 && e.RowIndex >= 0)
            {
                string strCodeSenderAddress = dgValue.Rows[e.RowIndex].Cells["发码器编号"].Value.ToString();
                FrmEmpInfo frm = new FrmEmpInfo(strCodeSenderAddress,false);
                frm.ShowDialog();

                frm.Dispose();
            }
        }

        #endregion
    }
}