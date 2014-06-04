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
    public partial class HistorySpecialWorkTypeTerrialAlarm : Wilson.Controls.Docking.DockContent
    {
        DeptBLL dBLL = new DeptBLL();
        AreaBLL ABLL = new AreaBLL();
        SpecialWorkTypeTerrialSetBLL swtsBLL = new SpecialWorkTypeTerrialSetBLL();
        string strErr = string.Empty;
        int intTerrialAlarmID = 0;
        static int intPageIndex = 1;
        static int intPageCountShow = 0;//页索引

        public HistorySpecialWorkTypeTerrialAlarm()//总页数
        {
            InitializeComponent();
        }

        #region 窗体加载事件
        private void SpecialWorkTypeTerrialSet_Load(object sender, EventArgs e)
        {
            dtBeginTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
            dtEndTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            BindComboBox();

            this.BindRowsSet();

            BindDataGridView();
        }
        #endregion

        #region 绑定下拉列表
        void BindComboBox()
        {
            
            ABLL.GetTerTypeCmb1(ddlAreaTypeStation);
            swtsBLL.Query_TerrialInfo(ddlAreaNameStation, int.Parse(ddlAreaTypeStation.SelectedValue.ToString()), 1, out strErr);
            swtsBLL.Querey_WorkType(ddlWorkTypeStation, 1, out strErr);
            ddlPageSize.SelectedText = "100";

        }
        #endregion

        #region 查询时区域类别下拉列表内容改变事件
        private void ddlAreaTypeStation_SelectionChangeCommitted(object sender, EventArgs e)
        {

            swtsBLL.Query_TerrialInfo(ddlAreaNameStation, int.Parse(ddlAreaTypeStation.SelectedValue.ToString()), 1, out strErr);
        }
        #endregion

        #region 得到返回的条件
        public string GetWhere()
        {
            string strWhere = string.Empty;

            if(ddlAreaTypeStation.SelectedValue.ToString() != "0")
            {
                strWhere += " and TerritorialTypeID="+ddlAreaTypeStation.SelectedValue.ToString();
            }
            if (ddlAreaNameStation.SelectedValue.ToString() != "0")
            {
                strWhere += " and TerritorialID=" + ddlAreaNameStation.SelectedValue.ToString();
            }

            if (ddlWorkTypeStation.SelectedValue.ToString() != "0")
            {
                strWhere += " and WorkTypeID="+ddlWorkTypeStation.SelectedValue.ToString();
            }

            if (TxtEmployeeNameStation.Text.Trim() != "")
            {
                strWhere += " and UserName like '%"+TxtEmployeeNameStation.Text+"%'";
            }

            if (txtBlockIDStation.Text.Trim() != "")
            {
                strWhere += " and CodeSenderAddress="+txtBlockIDStation.Text;
            }
            strWhere += " and InTerritorialTime>='" + dtBeginTime.Text + "'";
            strWhere += "and OutTerritorialTime<='" + dtEndTime.Text + "'";
            return strWhere;
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
                    MessageBox.Show("发码器编号只能为数字！");
                    return;
                }
            }
            int intPageSizedll = int.Parse(ddlPageSize.SelectedValue.ToString().ToString());
            
            DataSet ds = swtsBLL.Query_HistorySpecialWorkTypeAlarm(intPageIndex, intPageSizedll, GetWhere(), out strErr);

            if (ds != null && ds.Tables.Count > 0)
            {
                dgrd.DataSource = ds.Tables[0].DefaultView;


                dgrd.Columns[0].Visible = false;
                dgrd.Columns[1].Visible = false;


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

                PanelPageIndex.CaptionTitle = "第" + intPageIndex.ToString() + "页";
                PanelPageCount.CaptionTitle = "共" + intPageCountShow.ToString() + "页";

                PanelRowsCount.CaptionTitle = "共" + intPageSum.ToString() + "条";
            }
           
        }
        #endregion

        #region [ 方法: 绑定多少行 ]

        void BindRowsSet()
        {
            ArrayList al = new ArrayList();
            for (int i = 1; i <= 10; i++)
            {
                int j = i * 100;

                al.Add(new ListItem(j.ToString(), "每页显示" + j.ToString() + "行"));
            }
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
            if (intPageCountShow == 0)
            {
                intPageIndex = 1;
            }
            else
            {
                intPageIndex = intPageCountShow;
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
    }
}