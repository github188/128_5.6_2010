using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using System.Collections;
using System.Web.UI.WebControls;

namespace KJ128NMainRun
{
    public partial class FrmHisArea : Wilson.Controls.Docking.DockContent
    {
        private DeptBLL dBLL = new DeptBLL();
        private HisDirectionalAntennaBLL hisbll = new HisDirectionalAntennaBLL();
        private RealTimeBLL rtbll = new RealTimeBLL();
        private string strErr = string.Empty;
        private AreaBLL ABLL = new AreaBLL();
        private SpecialWorkTypeTerrialSetBLL swtsBLL = new SpecialWorkTypeTerrialSetBLL();
        static int intPageIndex = 1;
        static int intPageCountShow = 0;//页索引

        public FrmHisArea()//总页数
        {
            InitializeComponent();
        }

        #region 窗体加载事件
        private void SpecialWorkTypeTerrialSet_Load(object sender, EventArgs e)
        {

            dtStartTime.Value = DateTime.Now.AddDays(-1);
            dtEndTime.Value = DateTime.Now.AddDays(1);
            BindComboBox();

            this.BindRowsSet();

            BindDataGridView();
        }
        #endregion

        #region 绑定下拉列表
        void BindComboBox()
        {
            
            ABLL.GetTerTypeCmb1(cmbAreaType);
            swtsBLL.Query_TerrialInfo(cmbAreaName, int.Parse(cmbAreaType.SelectedValue.ToString()), 1, out strErr);
        }

        private void cmbAreaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            swtsBLL.Query_TerrialInfo(cmbAreaName, int.Parse(cmbAreaType.SelectedValue.ToString()), 1, out strErr);
        }

        #endregion

        #region 得到返回的条件
        public string GetWhere()
        {
            string[,] strArray = null;
            strArray = new string[6, 4]{{"EmpName","=",TxtEmployeeNameStation.Text,"string"},
                    {"CodeSenderAddress","=",txtBlockIDStation.Text,"string"},
                    {"AreaTypeName","=",cmbAreaType.Text=="所有"?"":cmbAreaType.Text,"string"},
                    {"AreaName","=",cmbAreaName.Text=="所有"?"":cmbAreaName.Text,"string"},
                    {"InTime",">=",dtStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),"string"},
                    {"InTime","<=",dtEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),"string"}
            };

            return rtbll.SelectWhere(strArray, 1);
        }
        #endregion

        #region 绑定DataGridView
        public void BindDataGridView()
        {
            if (txtBlockIDStation.Text != "")
            {
                try
                {
                    int.Parse(txtBlockIDStation.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("标识卡编号只能为数字！");
                    return;
                }
            }
            int intPageSizedll = int.Parse(ddlPageSize.SelectedValue.ToString().ToString());

            DataSet ds = hisbll.Query_His_InOutArea(intPageIndex, intPageSizedll, GetWhere(), out strErr);

            if (ds != null && ds.Tables.Count > 0)
            {
                dgrd.DataSource = ds.Tables[0].DefaultView;

                int intPageSum = int.Parse(ds.Tables[1].Rows[0][0].ToString());

                if (intPageSum % intPageSizedll == 0)
                {
                    intPageCountShow = intPageSum / intPageSizedll;
                }
                else
                {
                    intPageCountShow = intPageSum / intPageSizedll + 1;
                }

                if (intPageCountShow == 0)
                {
                    intPageCountShow = 1;
                }
                // 将时间精确到秒
                dgrd.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dgrd.Columns[7].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                PanelPageIndex.CaptionTitle = "第" + intPageIndex.ToString() + "页";
                PanelPageCount.CaptionTitle = "共" + intPageCountShow.ToString() + "页";

                PanelRowsCount.CaptionTitle = "共" + intPageSum.ToString() + "条";
                lblEmpCount.Text = "共"+ds.Tables[2].Rows[0][0].ToString()+"人";
            }
            else
            {
                PanelRowsCount.CaptionTitle = "共0条";
                lblEmpCount.Text = "共0人";
            }
           
        }
        #endregion

        #region [ 方法: 绑定多少行 ]

        void BindRowsSet()
        {
            ArrayList al = new ArrayList();
            
            al.Add(new ListItem("40", "每页显示40行"));
            al.Add(new ListItem("50", "每页显示50行"));
            al.Add(new ListItem("100", "每页显示100行"));
            al.Add(new ListItem("200", "每页显示200行"));
            al.Add(new ListItem("500", "每页显示500行"));
            this.ddlPageSize.DataSource = al;
            ddlPageSize.DisplayMember = "Name";
            
        }

        #endregion

        #region 查询按钮的单击事件
        private void btnQuery_Click(object sender, EventArgs e)
        {
            BindDataGridView();
        }
        #endregion

        #region 重置按钮的单击事件
        private void btnReset_Click(object sender, EventArgs e)
        {
            TxtEmployeeNameStation.Text = "";
            txtBlockIDStation.Text = "";
        }
        #endregion

        #region 首页的单击事件
        private void btnFirst_Click(object sender, EventArgs e)
        {
            intPageIndex = 1;
            BindDataGridView();
        }
        #endregion

        #region 上一页的单击事件
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (intPageIndex > 1)
            {
                intPageIndex--;
                BindDataGridView();
            }
        }
        #endregion

        #region 下一页的单击事件
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (intPageIndex < intPageCountShow)
            {
                intPageIndex++;
                BindDataGridView();
            }
        }
        #endregion

        #region 尾页的单击事件
        private void btnLast_Click(object sender, EventArgs e)
        {
            intPageIndex = intPageCountShow;

            BindDataGridView();
        }
        #endregion

        #region 跳转按钮的单击事件
        private void btnJump_Click(object sender, EventArgs e)
        {
            if (txtPageIndex.Text.Trim() == "" || txtPageIndex.Text.Trim() == "0")
            {
                MessageBox.Show("跳转页数不能为空或零！");
                return;
            }
            try
            {
                int.Parse(txtPageIndex.Text);
            }
            catch
            {
                MessageBox.Show("跳转页数只能为数字！");
                return;
            }

            if (int.Parse(txtPageIndex.Text.Trim()) > intPageCountShow)
            {
                intPageIndex = intPageCountShow;
            }
            else
            {
                intPageIndex = int.Parse(txtPageIndex.Text.Trim());
            }

            BindDataGridView();
        }
        #endregion

        #region 页面大小选择变化事件
        private void ddlPageSize_SelectionChangeCommitted(object sender, EventArgs e)
        {
            intPageIndex = 1;
            BindDataGridView();
        }
        #endregion

       
    }
}