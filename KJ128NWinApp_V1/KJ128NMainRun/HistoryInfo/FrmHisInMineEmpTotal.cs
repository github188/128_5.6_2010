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
    public partial class FrmHisInMineEmpTotal : Wilson.Controls.Docking.DockContent
    {
        private HisInMineEmpTotalBLL himbll = new HisInMineEmpTotalBLL();
        private RealTimeBLL rtbll = new RealTimeBLL();
        private DeptBLL dbll = new DeptBLL();

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

        private int pages = 0;

        public FrmHisInMineEmpTotal()
        {
            InitializeComponent();
            Init();
        }

        #region [ 方法: 初始化 ]

        private void Init()
        {
            dbll.getDutyNameCmb(cmbDutyName);       // 绑定职务
            dbll.getDeptAddAll(cmbDept);            // 绑定部门

            SelectInfo(1);
            //if (cmbDutyName.Items.Count > 0)
            //{
            //    cmbDutyName.SelectedIndex = 0;
            //}
            //if (cmbDutyName.Items.Count > 0)
            //{
            //    cmbDutyName.SelectedIndex = 0;
            //}

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
            DataSet ds = himbll.HisInMineEmpTotal(pIndex, pSize, where);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                pages = sumPage;
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                bcpPageSum.Visible = true;

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


            /*
             * 这边有疑问
             */

            strArray = new string[6, 4]{
                    {"his.InTime",">",dtStartTime.Text,"string"},
                    {"his.InTime","<",dtEndTime.Text,"string"},
                    {"enc.DeptID","=",cmbDept.SelectedValue.ToString() == "0"?"":cmbDept.SelectedValue.ToString(),"int"},
                    {"enc.DutyID","=",cmbDutyName.SelectedValue.ToString() == "0"?"":cmbDutyName.SelectedValue.ToString(),"int"},
                    {"his.CodeSenderAddress","=",txtSendCoderAddress.Text,"int"},
                    {"ei.EmpName","=",txtName.Text,"string"}
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

        private void FrmHisInMineEmpTotal_Load(object sender, EventArgs e)
        {
            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
            cbPSize.SelectedIndex = 0;                      //设置每页显示行数为20;

            where = strWhere();                 // 默认查询当天的
            SelectInfo(1);
        }

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgValue, Text, "下井人员总数:共"+pages.ToString()+" 人");
        }

        private void gbx0_Enter(object sender, EventArgs e)
        {

        }

    }
}
