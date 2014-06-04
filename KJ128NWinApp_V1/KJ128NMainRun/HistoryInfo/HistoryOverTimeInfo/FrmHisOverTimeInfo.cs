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

namespace KJ128NMainRun.HistoryInfo.HistoryOverTimeInfo
{
    public partial class FrmHisOverTimeInfo : Wilson.Controls.Docking.DockContent
    {
        private HisOverTimeInfoBLL hotibll = new HisOverTimeInfoBLL();

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

        #region 构造函数
        public FrmHisOverTimeInfo()
        {
            InitializeComponent();

            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString();

            #region 加载部门, 工种,  职务  信息
            if (!hotibll.LoadInfo(treeInfo))
            {
                MessageBox.Show("对不起, 基本数据加载失败！");
                return;
            }
            #endregion

            treeInfo.ExpandAll();
            treeInfo.SelectedNode = treeInfo.Nodes[0];
            cbPSize.SelectedIndex = 0;

            label8.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + ":";

            dgValue.Columns[0].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);
        }
        #endregion

        #region 查询 单击事件 Click
        private void btnSearch_Click(object sender, EventArgs e)
        {
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

            where = hotibll.SelectWhere(dtStartTime.Text, dtEndTime.Text, txtName.Text.Trim(), txtCardAddress.Text.Trim(), deptName);
            SelectInfo(1);      //分页查询
            cpUp.Enabled = false;
            cpDown.Enabled = true;
        }
        #endregion

        #region 重置 单击事件 Click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString();

            txtName.Text = "";
            txtCardAddress.Text = "";
            treeInfo.ExpandAll();
            treeInfo.SelectedNode = treeInfo.Nodes[0];
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
            btnSearch_Click(sender, e);
            //SelectInfo(1);
            cpUp.Enabled = false;
            cpDown.Enabled = true;
        }
        #endregion

        #region 处理空数据页数显示
        /// <summary>
        /// 处理空数据页数显示
        /// </summary>
        /// <param name="bl"></param>
        private void pageControlsVisible(bool bl)
        {
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
                    deptName += " or 部门='" + n.Text.Trim()+"' ";
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

            dgValue.Columns[0].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);

            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数！");
                return;
            }
            DataSet ds = hotibll.GetOverTimeSet(pIndex, pSize, where);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                if (sumPage > 1)
                {
                    bcpPageSum.Visible = true;
                    bcpPageSum.Location = new Point(333, 7);
                }
                else
                {
                    bcpPageSum.Visible = true;
                    bcpPageSum.Location = new Point(650, 7);
                }
                if (pIndex > sumPage)
                {
                    if (sumPage == 0)
                    {
                        dgValue.Columns.Clear();
                        dgValue.DataSource = ds.Tables[0];
                        dgValue.Columns[6].Visible = false;
                        dgValue.Columns[7].Visible = false;

                        bcpPageSum.CaptionTitle = "0 条";
                        pageControlsVisible(false);
                        return;
                    }
                    // 大于最后一页
                    return;
                }
                bcpPageSum.CaptionTitle = "共" + ds.Tables[1].Rows[0][0].ToString() + "条";
                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "页";
                dgValue.Columns.Clear();
                dgValue.DataSource = ds.Tables[0];
                dgValue.Columns[6].Visible = false;
                dgValue.Columns[7].Visible = false;

                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    buttonCaptionPanel1.CaptionTitle = "历史超时显示：\t共" + ds.Tables[0].Rows.Count.ToString() + "条信息";
                }
                else
                {
                    buttonCaptionPanel1.CaptionTitle = "历史超时显示：\t共0条信息";
                }

                dgValue.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dgValue.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

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

        #region [ 事件: 打印 ]
        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgValue,Text);
            //DataGridViewKJ128 dgv = new DataGridViewKJ128();
            //dgv = dgValue;
            ////if (dgv.Columns.Count > 6)
            ////{
            ////    dgv.Columns.Remove(dgv.Columns[6]);
            ////    dgv.Columns.Remove(dgv.Columns[6]);
            ////}
            //ExcelExports.ExportDataGridViewToExcel(dgv);
        }
        #endregion

        private void txtCardAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}