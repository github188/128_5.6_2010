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
    public partial class FrmQueryTime : Wilson.Controls.Docking.DockContent
    {
        private DeptBLL dBLL = new DeptBLL();
        private RealTimeBLL rtbll = new RealTimeBLL();
        private string strErr = string.Empty;
        static int intPageIndex = 1;
        static int intPageCountShow = 0;//页索引

        public FrmQueryTime()//总页数
        {
            InitializeComponent();
        }

        #region 窗体加载事件
        private void SpecialWorkTypeTerrialSet_Load(object sender, EventArgs e)
        {

            dtStartTime.Value = DateTime.Now.AddDays(-1);
            dtEndTime.Value = DateTime.Now.AddDays(1);

            BindDataGridView();
        }
        #endregion

        #region 得到返回的条件
        public string GetWhere()
        {
            string[,] strArray = null;
            strArray = new string[2, 4]{
                    {"InStationHeadTime",">=",dtStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),"string"},
                    {"InStationHeadTime","<=",dtEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),"string"}
            };

            return rtbll.SelectWhere(strArray, 1);
        }
        #endregion

        #region 绑定DataGridView
        public void BindDataGridView()
        {
            DataSet ds = rtbll.QueryByTime(GetWhere());

            if (ds != null && ds.Tables.Count > 0)
            {
                dgrd.DataSource = ds.Tables[0].DefaultView;

                int intPageSum = int.Parse(ds.Tables[1].Rows[0][0].ToString());

                if (intPageCountShow == 0)
                {
                    intPageCountShow = 1;
                }
                // 将时间精确到秒
                dgrd.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dgrd.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dgrd.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dgrd.Columns[8].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                pnlCount.CaptionTitle = "共" + intPageSum.ToString() + "条记录";
                pnlEmpCount.CaptionTitle = "共" + ds.Tables[2].Rows[0][0].ToString() + "人";
            }
            else
            {
                pnlCount.CaptionTitle = "共0条记录";
                pnlEmpCount.CaptionTitle = "共0人";
            }
           
        }
        #endregion

        #region 查询按钮的单击事件
        private void btnQuery_Load(object sender, EventArgs e)
        {
            BindDataGridView();
        }        
        #endregion

    }
}