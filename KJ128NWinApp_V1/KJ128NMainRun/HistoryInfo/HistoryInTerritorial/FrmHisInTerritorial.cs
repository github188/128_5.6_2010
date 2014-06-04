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

namespace KJ128NMainRun.HistoryInfo.HistoryInTerritorial
{
    public partial class FrmHisInTerritorial : Wilson.Controls.Docking.DockContent
    {
        private HisInTerritorialBLL hitbll = new HisInTerritorialBLL();

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
        #endregion

        #region 构造函数
        public FrmHisInTerritorial()
        {
            InitializeComponent();

            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString();

            #region 加载区域名称
            hitbll.LoadTerName(cmb_TerName);
            #endregion

            #region 加载区域类别
            hitbll.LoadTerTypeName(cmb_TerTypeName);
            #endregion

            cbPSize.SelectedIndex = 0;

            dvEmp.Columns[0].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);
            dvEqu.Columns[0].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);
        }
        #endregion

        //事件
        #region 重置 单击事件 Click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString();

            hitbll.LoadTerName(cmb_TerName);                        //初始化区域名称
            hitbll.LoadTerTypeName(cmb_TerTypeName);                //初始化区域类别

            rbEmp.Checked = true;
            cmb_TerName.SelectedValue = 0;
            cmb_TerTypeName.SelectedValue = 0;

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
            if (rbEmp.Checked)
            {
                dvEmp.Visible = true;
                dvEqu.Visible = false;
                buttonCaptionPanel1.CaptionTitle = "历史区域人员信息：";
                where = hitbll.SelectWhere(dtStartTime.Text, dtEndTime.Text, cmb_TerTypeName.Text, cmb_TerName.Text, true);
                SelectInfo(1);      //分页查询
            }
            else
            {
                dvEqu.Visible = true;
                dvEmp.Visible = false;
                buttonCaptionPanel1.CaptionTitle = "历史区域设备信息：";
                where = hitbll.SelectWhere(dtStartTime.Text, dtEndTime.Text, cmb_TerTypeName.Text, cmb_TerName.Text, false);
                SelectInfo(1);      //分页查询
            }
            cpUp.Enabled = false;
            cpDown.Enabled = true;
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
            btnSearch_Click(sender, e);
            //SelectInfo(1);
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
            DataSet ds = hitbll.GetHisInTerInfoSet(pIndex, pSize, where, rbEmp.Checked);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                if (sumPage > 1)
                {
                    bcpPageSum.Visible = true;
                    bcpPageSum.Location = new Point(338, 7);
                }
                else
                {
                    bcpPageSum.Visible = true;
                    bcpPageSum.Location = new Point(643, 7);
                }
                if (pIndex > sumPage)
                {
                    if (sumPage == 0)
                    {
                        if (rbEmp.Checked)
                        {
                            dvEmp.Columns.Clear();
                            dvEmp.DataSource = ds.Tables[0];
                            dvEmp.Columns[8].Visible = false;
                            dvEmp.Columns[9].Visible = false;
                        }
                        else
                        {
                            dvEqu.Columns.Clear();
                            dvEqu.DataSource = ds.Tables[0];
                            dvEqu.Columns[8].Visible = false;
                            dvEqu.Columns[9].Visible = false;
                        }
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
                if (rbEmp.Checked)
                {
                    dvEmp.Columns.Clear();
                    dvEmp.DataSource = ds.Tables[0];
                    dvEmp.Columns[8].Visible = false;
                    dvEmp.Columns[9].Visible = false;
                    dvEmp.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    dvEmp.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                }
                else
                {
                    dvEqu.Columns.Clear();
                    dvEqu.DataSource = ds.Tables[0];
                    dvEqu.Columns[8].Visible = false;
                    dvEqu.Columns[9].Visible = false;
                    dvEqu.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    dvEqu.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                }
                //intSize = ds.Tables[0].Rows.Count;
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

        #region 导出 Excel
        private void cpToExcel_Click(object sender, EventArgs e)
        {
            DataGridViewKJ128 dgv = new DataGridViewKJ128();
            if (rbEmp.Checked)
            {
                dgv = dvEmp;
                //if (dgv.Columns.Count > 8)
                //{
                //    dgv.Columns.Remove(dgv.Columns[8]);
                //    dgv.Columns.Remove(dgv.Columns[8]);
                //}
            }
            else
            {
                dgv = dvEqu;
                //if (dgv.Columns.Count > 8)
                //{
                //    dgv.Columns.Remove(dgv.Columns[8]);
                //    dgv.Columns.Remove(dgv.Columns[8]);
                //}
            }
            PrintBLL.Print(dgv,Text);
        }
        #endregion
    }
}