using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NMainRun.HistoryInfo
{
    public partial class FrmHisOverEmp : Wilson.Controls.Docking.DockContent
    {
        #region [ 变量 ]
        
        /// <summary>
        /// 每页显示条数
        /// </summary>
        private int pSize = 40;

        /// <summary>
        /// 查询结果的总页数
        /// </summary>
        private int countPage;

        /// <summary>
        /// 查询条件
        /// </summary>
        private string where = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private HisOverEmpBLL his = new HisOverEmpBLL();

        private RealTimeBLL rtbll = new RealTimeBLL();

        #endregion

        #region [ 构造函数 ]

        public FrmHisOverEmp()
        {
            InitializeComponent();

            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
            cbPSize.SelectedIndex = 0;                      //设置每页显示行数为20;

            where = strWhere();                 // 默认查询当天的
            SelectInfo(1);
        }

        #endregion

        #region [ 方法: 翻页 ]
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

        #region [ 方法: 选择每页显示行数 ]

        private void cbPSize_DropDownClosed(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cbPSize.SelectedItem);
            btnSearch_Click(sender, e);
            cpUp.Enabled = false;
            cpDown.Enabled = true;
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
            DataSet ds = his.GetHisOverEmpAll(pIndex, pSize, where);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                if (sumPage > 1)
                {
                    bcpPageSum.Visible = true;
                    bcpPageSum.Location = new Point(261, 8);
                }
                else
                {
                    bcpPageSum.Visible = true;
                    bcpPageSum.Location = new Point(631, 8);
                }

                if (pIndex > sumPage)
                {
                    if (sumPage == 0)
                    {
                        dgValue.Columns.Clear();
                        dgValue.DataSource = ds.Tables[0];

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

                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    buttonCaptionPanel1.CaptionTitle = "历史超员显示：\t共" + ds.Tables[0].Rows.Count.ToString() + "条信息";
                }
                else
                {
                    buttonCaptionPanel1.CaptionTitle = "历史超员显示：\t共0条信息";
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

        #region 查询

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns></returns>
        private string strWhere()
        {
            string[,] strArray = null;

            strArray = new string[2, 4]{{"His_OverEmployeeBeginTime",">",dtStartTime.Text,"string"},
                    {"His_OverEmployeeBeginTime","<",dtEndTime.Text,"string"}
            };

            return rtbll.SelectWhere(strArray, 1);
        }

        #endregion

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

            if (dgValue.Visible == true)
            {
                // 组织查询条件
                where = strWhere();
                SelectInfo(1);      //分页查询
                cpUp.Enabled = false;
                cpDown.Enabled = true;
            }
        }
        #endregion

        #region [ 事件: 打印 ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgValue, Text);
        }

        #endregion
    }
}