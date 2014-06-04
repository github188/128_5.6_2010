using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NMainRun
{
    /// <summary>
    /// 历史行走异常信息
    /// </summary>
    public partial class FrmHistoryWalkInfo : Form
    {
        #region[私有字段]

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


        private HistoryWalkBLL bll = new HistoryWalkBLL();

        #endregion

        #region[构造函数]

        public FrmHistoryWalkInfo()
        {
            InitializeComponent();
        }

        #endregion

        #region[私有方法]

        #region【给GridView排序】

        /// <summary>
        /// 给GridView排序
        /// </summary>
        private void SortColumns()
        {
            if (this.dgvMain.ColumnCount > 0)
            {
                //隐藏字段
                dgvMain.Columns["WalkConfigId"].Visible = false;
                dgvMain.Columns["EmpID"].Visible = false;
                dgvMain.Columns["DeptID"].Visible = false;

                //设置显示顺序
                dgvMain.Columns["CodeSenderAddress"].DisplayIndex = 0;
                dgvMain.Columns["CodeSenderAddress"].HeaderText = "标识卡编号";

                dgvMain.Columns["EmpName"].DisplayIndex = 1;
                dgvMain.Columns["EmpName"].HeaderText = "姓名";

                dgvMain.Columns["DeptName"].DisplayIndex = 2;
                dgvMain.Columns["DeptName"].HeaderText = "部门";


                dgvMain.Columns["FirstStationAddress"].DisplayIndex = 3;
                dgvMain.Columns["FirstStationAddress"].HeaderText = "第一传输分站编号";

                dgvMain.Columns["FirstStationHeadAddress"].DisplayIndex = 4;
                dgvMain.Columns["FirstStationHeadAddress"].HeaderText = "第一读卡分站编号";

                dgvMain.Columns["FirstStationHeadAntennaA"].DisplayIndex = 5;
                dgvMain.Columns["FirstStationHeadAntennaA"].HeaderText = "第一天线A";

                dgvMain.Columns["FirstStationHeadAntennaB"].DisplayIndex = 6;
                dgvMain.Columns["FirstStationHeadAntennaB"].HeaderText = "第一天线B";

                dgvMain.Columns["firstPlace"].DisplayIndex = 7;
                dgvMain.Columns["firstPlace"].HeaderText = "第一读卡分站安装位置";


                dgvMain.Columns["MiddleStationAddress"].DisplayIndex = 8;
                dgvMain.Columns["MiddleStationAddress"].HeaderText = "中间传输分站编号";

                dgvMain.Columns["MiddleStationHeadAddress"].DisplayIndex = 9;
                dgvMain.Columns["MiddleStationHeadAddress"].HeaderText = "中间读卡分站编号";

                dgvMain.Columns["MiddleStationHeadAntennaA"].DisplayIndex = 10;
                dgvMain.Columns["MiddleStationHeadAntennaA"].HeaderText = "中间天线A";

                dgvMain.Columns["MiddleStationHeadAntennaB"].DisplayIndex = 11;
                dgvMain.Columns["MiddleStationHeadAntennaB"].HeaderText = "中间天线B";

                dgvMain.Columns["middlePlace"].DisplayIndex = 12;
                dgvMain.Columns["middlePlace"].HeaderText = "中间读卡分站安装位置";


                dgvMain.Columns["LastStationAddress"].DisplayIndex = 13;
                dgvMain.Columns["LastStationAddress"].HeaderText = "最后传输分站编号";

                dgvMain.Columns["LastStationHeadAddress"].DisplayIndex = 14;
                dgvMain.Columns["LastStationHeadAddress"].HeaderText = "最后读卡分站编号";

                dgvMain.Columns["LastStationHeadAntennaA"].DisplayIndex = 15;
                dgvMain.Columns["LastStationHeadAntennaA"].HeaderText = "最后天线A";

                dgvMain.Columns["LastStationHeadAntennaB"].DisplayIndex = 16;
                dgvMain.Columns["LastStationHeadAntennaB"].HeaderText = "最后天线B";

                dgvMain.Columns["lastPlace"].DisplayIndex = 17;
                dgvMain.Columns["lastPlace"].HeaderText = "最后读卡分站安装位置";


                dgvMain.Columns["TimeValue"].DisplayIndex = 18;
                dgvMain.Columns["TimeValue"].HeaderText = "规定行走时间";


                //dgvMain.Columns["Edit"].DisplayIndex = 19;

                //dgvMain.Columns["Delete"].DisplayIndex = 20;

            }
        }

        #endregion

        #region 【窗体加载】

        private void FrmHistoryWalkInfo_Load(object sender, EventArgs e)
        {
            BuildString();
            SelectInfo(1);

            SortColumns();
        }

        #endregion

        #region 【 方法: 构造查询条件】

        /// <summary>
        /// 构造查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        public void BuildString()
        {
            try
            {
                if (!txtEmpName.Text.Trim().Equals(""))
                {
                    where += " And EmpName like '%" + txtEmpName.Text.Trim() + "%' ";
                }

                //if (!txtCodeSenderAddress.Text.Trim().Equals(""))
                //{
                //    where += " And 标识卡编号 =" + txtCodeSenderAddress.Text.Trim();
                //}
            }
            catch(Exception ex)
            {
                MessageBox.Show("组织查询条件导致SQL查询失败\n失败消息：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region 【 方法: 查询 】

        private void bcpSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.BuildString();
                SelectInfo(1);
                SortColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败\n失败消息：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        #region 【 方法: 分页查询 】

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
            DataSet ds = bll.SelectHiatoryWalkInfo(pIndex, pSize, where);

            if (ds != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                if (sumPage <= 1)
                {
                    cpDown.Enabled = false;
                    cpUp.Enabled = false;
                }
                else if (pIndex == 1)
                {
                    cpUp.Enabled = false;
                    cpDown.Enabled = true;
                }
                else if (pIndex > sumPage)
                {
                    cpUp.Enabled = true;
                    cpDown.Enabled = false;
                    return;
                }
                else if (pIndex == sumPage)
                {
                    cpUp.Enabled = true;
                    cpDown.Enabled = false;
                }
                else
                {
                    cpUp.Enabled = true;
                    cpDown.Enabled = true;
                }

                if (sumPage == 0)
                {
                    dgvMain.Columns.Clear();
                    dgvMain.DataSource = ds.Tables[0];

                    if (ds.Tables[0] != null)
                    {
                        SortColumns();

                    }

                    bcpPageSum.CaptionTitle = "共 0 条记录";

                    return;
                }

                bcpPageSum.CaptionTitle = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条记录";
                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "页";

                dgvMain.Columns.Clear();
                dgvMain.DataSource = ds.Tables[0];

                if (ds.Tables[0] != null)
                {
                    SortColumns();
                }
            }
        }
        #endregion

        #region 【 事件: 翻页 】
        //上一页
        private void cpUp_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page--;
            //cpDown.Cursor = Cursors.Hand;
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
            else if (countPage == 0)
            {
                cpUp.Enabled = false;
                cpDown.Enabled = false;
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

        #region 【 事件: 选择每页行数 】

        private void cbPSize_DropDownClosed(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cbPSize.SelectedItem);
            SelectInfo(1);
        }
        #endregion

        #region 【 事件: 打印 】

        private void bcpExcel_Click(object sender, EventArgs e)
        {
            try
            {
                PrintBLL.Print(this.dgvMain, "历史行走异常报警信息");
            }
            catch
            {
                MessageBox.Show("打印失败，请重新打印", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        #endregion
    }
}
