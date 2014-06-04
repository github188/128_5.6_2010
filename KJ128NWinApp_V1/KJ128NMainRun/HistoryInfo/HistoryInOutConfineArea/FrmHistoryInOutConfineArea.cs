using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDataBase;
using KJ128NDBTable;

namespace KJ128NMainRun
{
    public partial class FrmHistoryInOutConfineArea : Wilson.Controls.Docking.DockContent
    {
        #region 【 声明 】

        private HistoryInOutConfineAreaBLL bll = new HistoryInOutConfineAreaBLL();

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

        #region 【 构造函数 】

        public FrmHistoryInOutConfineArea()
        {
            InitializeComponent();
        }

        #endregion

        #region 【 事件: 窗体加载 】

        private void FrmHistoryInOutConfineArea_Load(object sender, EventArgs e)
        {
            //加载部门信息
            InitialzeDeptComboBox();

            //加载限制区域名称信息
            InitialzeConfineAreaComboBox();

            //初始化每页选择行数
            cbPSize.SelectedIndex = 0;

            dtpEnd.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtpBegin.Text = DateTime.Today.ToString();

            bcpSelect_Click(sender, e);
        }

        #endregion

        #region 【 方法: 加载部门信息 】

        private void InitialzeDeptComboBox()
        {
            DataTable dt = GetDeptInfo();
            if (dt != null)
            {
                this.cbDept.DisplayMember = "DeptName";
                this.cbDept.ValueMember = "DeptId";
                this.cbDept.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    this.cbDept.SelectedIndex = 0;
                }
            }
        }

        private DataTable GetDeptInfo()
        {
            DataTable dt =  DataHelper.GetDeptInfo();
            if (dt != null)
            {
                DataRow dr = dt.NewRow();

                dr["DeptId"] = "0";
                dr["DeptName"] = "所有";

                dt.Rows.InsertAt(dr, 0);
            }
            return dt;
        }

        #endregion

        #region 【 方法: 加载区域信息 】

        private DataTable GetConfineAreaInfo()
        {
            DataTable dt = DataHelper.GetConfineAreaInfo();

            if (dt != null)
            {
                DataRow dr = dt.NewRow();

                dr["TerritorialID"] = "0";
                dr["TerritorialName"] = "所有";

                dt.Rows.InsertAt(dr, 0);
            }
            return dt;
        }

        private void InitialzeConfineAreaComboBox()
        {
            DataTable dt = GetConfineAreaInfo();
            if (dt != null)
            {
                this.cbArea.DisplayMember = "TerritorialName";
                this.cbArea.ValueMember = "TerritorialID";
                this.cbArea.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    this.cbArea.SelectedIndex = 0;
                }
            }
        }

        #endregion

        #region 【 方法: 构造查询条件】

        /// <summary>
        /// 构造查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        public void BuildString()
        {

            where = " InTerritorialTime>= '" + dtpBegin.Text + "' And InTerritorialTime <= '" + dtpEnd.Text + "' ";
            if (cbDept.SelectedValue != null)
            {
                if (!cbDept.SelectedValue.Equals(0))
                {
                    where += " And DeptName =  '" + cbDept.Text.Trim() + "' ";
                }
            }

            if (cbArea.SelectedValue != null)
            {
                if (!cbArea.SelectedValue.Equals(0))
                {
                    where += " And TerritorialName = '" + cbArea.Text.Trim() + "' ";
                }
            }

            if (!txtEmpName.Text.Trim().Equals(""))
            {
                where += " And UserName like '%" + txtEmpName.Text.Trim() + "%' ";
            }

            if (!txtCodeSenderAddress.Text.Trim().Equals(""))
            {
                where += " And CodeSenderAddress =" + txtCodeSenderAddress.Text.Trim();
            }

        }

        #endregion

        #region 【 方法: 查询 】

        private void bcpSelect_Click(object sender, EventArgs e)
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
            DataSet ds = bll.SelectHistoryInOutConfineAreaInfo(pIndex, pSize, where);

            if (ds!=null && ds.Tables.Count > 0)
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
                else if (pIndex==sumPage)
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
                        dgvMain.Columns["CodeSenderAddress"].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);
                        dgvMain.Columns["UserName"].HeaderText = "姓名";
                        dgvMain.Columns["DeptName"].HeaderText = "部门";
                        dgvMain.Columns["TerritorialName"].HeaderText = "区域名称";
                        dgvMain.Columns["InTerritorialTime"].HeaderText = "进入限制区域时间";
                        dgvMain.Columns["OutTerritorialTime"].HeaderText = "离开限制区域时间";
                        dgvMain.Columns["ContinueTime"].HeaderText = "滞留时间";

                        dgvMain.Columns["InTerritorialTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        dgvMain.Columns["OutTerritorialTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                        dgvMain.Columns["HisTerritorialID"].Visible = false;
                        dgvMain.Columns["TerritorialID"].Visible = false;
                    }

                    bcpPageSum.CaptionTitle = "共 0 人次";
                    
                    return;
                }

                bcpPageSum.CaptionTitle = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 人次";
                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "页";

                dgvMain.Columns.Clear();
                dgvMain.DataSource = ds.Tables[0];

                if (ds.Tables[0] != null)
                {
                    dgvMain.Columns["CodeSenderAddress"].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);
                    dgvMain.Columns["UserName"].HeaderText = "姓名";
                    dgvMain.Columns["DeptName"].HeaderText = "部门";
                    dgvMain.Columns["TerritorialName"].HeaderText = "区域名称";
                    dgvMain.Columns["InTerritorialTime"].HeaderText = "进入限制区域时间";
                    dgvMain.Columns["OutTerritorialTime"].HeaderText = "离开限制区域时间";
                    dgvMain.Columns["ContinueTime"].HeaderText = "滞留时间";

                    dgvMain.Columns["InTerritorialTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    dgvMain.Columns["OutTerritorialTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    dgvMain.Columns["HisTerritorialID"].Visible = false;
                    dgvMain.Columns["TerritorialID"].Visible = false;
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
            PrintBLL.Print(dgvMain, this.Text, bcpPageSum.CaptionTitle);
        }

        #endregion
    }
}
