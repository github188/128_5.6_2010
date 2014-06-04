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

namespace KJ128NMainRun.HistoryInfo.HistoryStationBreak
{
    public partial class FrmHisStationBreak : Wilson.Controls.Docking.DockContent
    {
        private HisStationBreakBLL hsbbll = new HisStationBreakBLL();

        private int intBreak;

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
        public FrmHisStationBreak(int intBreak)
        {
            InitializeComponent();

            label10.Text = HardwareName.Value(CorpsName.StationSplace) + ":";

            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString();
            this.intBreak = intBreak;

            label10.Text = HardwareName.Value(CorpsName.StationSplace);

        }
        #endregion

        //事件
        #region 查询 单击事件 Click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(DateTime.Parse(dtStartTime.Text), DateTime.Parse(dtEndTime.Text)) > 0)
            {
                MessageBox.Show("对不起, 开始时间不能大于结束时间！");
                return;
            }
            where = hsbbll.SelectWhere(dtStartTime.Text, dtEndTime.Text, cmb_StaPlace.SelectedValue.ToString(), cmb_StaBreak.Text);
            SelectInfo(1);
            cpUp.Enabled = false;
            cpDown.Enabled = true;
        }
        #endregion

        #region 重置 单击事件 Click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            cmb_StaBreak.SelectedIndex = 0;
            cmb_StaPlace.SelectedValue = 0;
            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString();
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
            DataSet ds = hsbbll.GetHisInTerInfoSet(pIndex, pSize, where);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                //更改 基站->分站 等信息
                ds.Tables[0].Columns[0].ColumnName = HardwareName.Value(CorpsName.StationAddress);
                ds.Tables[0].Columns[1].ColumnName = HardwareName.Value(CorpsName.StaHeadAddress);
                ds.Tables[0].Columns[3].ColumnName = HardwareName.Value(CorpsName.Station) + "或" + HardwareName.Value(CorpsName.StaHead) + "安装位置";
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                if (sumPage > 1)
                {
                    bcpPageSum.Visible = true;
                    //bcpPageSum.Location = new Point(170, 167);
                }
                else
                {
                    bcpPageSum.Visible = true;
                    //bcpPageSum.Location = new Point(465, 167);
                }
                if (pIndex > sumPage)
                {
                    if (sumPage == 0)
                    {
                        dgValue.Columns.Clear();
                        dgValue.DataSource = ds.Tables[0];
                        dgValue.Columns[0].Width = 50;
                        dgValue.Columns[1].Width = 50;
                        dgValue.Columns[3].Width = 138;
                        //dgValue.Columns[6].Visible = false;
                        dgValue.Columns[7].Visible = false;

                        //将故障时间精确到秒
                        dgValue.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        dgValue.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                        if (cmb_StaBreak.SelectedIndex == 1)
                        {
                            dgValue.Columns[1].Visible = false;
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

                dgValue.Columns.Clear();
                dgValue.DataSource = ds.Tables[0];
                dgValue.Columns[0].Width = 50;
                dgValue.Columns[1].Width = 50;
                dgValue.Columns[3].Width = 138;
                //dgValue.Columns[6].Visible = false;
                dgValue.Columns[7].Visible = false;
                //将故障时间精确到秒
                dgValue.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dgValue.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                if (cmb_StaBreak.SelectedIndex == 1)
                {
                    dgValue.Columns[1].Visible = false;
                }

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
            PrintBLL.Print(dgValue,Text);
            //DataGridViewKJ128 dgv = new DataGridViewKJ128();
            //dgv = dgValue;
            ////if (dgv.Columns.Count > 6)
            ////{
            ////    dgv.Columns.Remove(dgv.Columns[6]);
            ////}
            //ExcelExports.ExportDataGridViewToExcel(dgv);
        }
        #endregion

        #region [ 事件: 窗体初次加载事件 ]

        private void FrmHisStationBreak_Load(object sender, EventArgs e)
        {
            cmb_StaBreak.SelectedIndex = intBreak;

            hsbbll.LoadStaPlace(cmb_StaPlace);
            cbPSize.SelectedIndex = 0;

            btnSearch_Click(sender, e);
        }

        #endregion
    }
}