using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NMainRun.A_InMineDayReport
{
    /// <summary>
    /// 下井日报表
    /// </summary>
    public partial class FrmInMineDayReport : FromModel.FrmModel
    {
        #region [构造函数]

        public FrmInMineDayReport()
        {
            InitializeComponent();
        }

        #endregion

        #region[私有字段]

        private A_InMineDayReportBLL bll = new A_InMineDayReportBLL();

        //private A_TreeBLL tbll = new A_TreeBLL();

        //private A_HisStationHeadBLL rtsbll = new A_HisStationHeadBLL();

        #endregion

        #region[私有方法]

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="ds"></param>
        private void BandingDataGridView(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                this.dgvMain.DataSource = dt;
            }
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmInMineDayReport_Load(object sender, EventArgs e)
        {
            DataTable dt =  bll.SelectInMineDayReportInfo("");
            BandingDataGridView(dt);
        }

        /// <summary>
        /// 重置按钮事件方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReSet_Click(object sender, EventArgs e)
        {
            this.dtpDate.Text = DateTime.Today.ToString();
            this.txtCodeSenderAddress.Text = "";
            this.txtEmpName.Text = "";
        }

        /// <summary>
        /// 查询按钮时间方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            string strWhere = BuildWhereString();

            DataTable dt = bll.SelectInMineDayReportInfo(0, 40, strWhere);
            BandingDataGridView(dt);
        }

        /// <summary>
        /// 构造查询条件字符
        /// </summary>
        /// <returns>返回查询条件字符</returns>
        private string BuildWhereString()
        {
            return "";
        }

        private void txtEmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }


        /*
         * 
          ds = rtsbll.GetStaHeadTree();

          tbll.LoadTree(tvc_StationHead, ds, "人", false, "所有");
         * 
         */

        #endregion
    }
}
