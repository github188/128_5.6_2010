using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NDataBase;

namespace KJ128NMainRun
{
    public partial class FrmHistoryPostInfo : Wilson.Controls.Docking.DockContent
    {
        #region 【私有字段】

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
        /// 历史岗位异常bll
        /// </summary>
        private HistoryPostBLL bll = new HistoryPostBLL();

        #endregion

        #region 【构造函数】

        public FrmHistoryPostInfo()
        {
            InitializeComponent();
        }

        #endregion

        #region 【方法】

        #region 【窗体加载】

        private void FrmHistoryPostInfo_Load(object sender, EventArgs e)
        {


            dtpBegin.Text = DateTime.Today.ToString();

            BuildString();
            SelectInfo(1);
        }

        #endregion

        #region 【 方法: 构造查询条件】

        /// <summary>
        /// 构造查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        public void BuildString()
        {

            where = " 开始工作时间>= '" + dtpBegin.Text + "' And 结束工作时间 <= '" + dtpEnd.Text + "' ";

            if (!txtEmpName.Text.Trim().Equals(""))
            {
                where += " And 姓名 like '%" + txtEmpName.Text.Trim() + "%' ";
            }

            if (!txtCodeSenderAddress.Text.Trim().Equals(""))
            {
                where += " And 标识卡编号 =" + txtCodeSenderAddress.Text.Trim();
            }

        }

        #endregion

        #region 【 方法: 查询 】

        private void bcpSearch_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(DateTime.Parse(dtpBegin.Text), DateTime.Parse(dtpEnd.Text)) > 0)
            {
                MessageBox.Show("对不起, 开始时间不能大于结束时间！");
                return;
            }

            this.BuildString();

            SelectInfo(1);
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
            DataSet ds = bll.SelectHistoryPostInfoByCondition(pIndex, pSize, where);

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
                        dgvMain.Columns["HisPostID"].Visible = false;
                        dgvMain.Columns["TerritorialID"].Visible = false;
                        dgvMain.Columns["EmpID"].Visible = false;

                        dgvMain.Columns["开始工作时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        dgvMain.Columns["结束工作时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";


                    }

                    bcpPageSum.CaptionTitle = "共 0 条记录";

                    return;
                }

                bcpPageSum.CaptionTitle = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 人次";
                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "页";

                dgvMain.Columns.Clear();
                dgvMain.DataSource = ds.Tables[0];

                if (ds.Tables[0] != null)
                {
                    dgvMain.Columns["HisPostID"].Visible = false;
                    dgvMain.Columns["TerritorialID"].Visible = false;
                    dgvMain.Columns["EmpID"].Visible = false;

                    dgvMain.Columns["开始工作时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    dgvMain.Columns["结束工作时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
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

        private void cpStationToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                PrintBLL.Print(dgvMain, this.Text, bcpPageSum.CaptionTitle);
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
