using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KJ128NDBTable;

namespace KJ128NInterfaceShow
{
    public partial class HistoryTimeOut : Wilson.Controls.Docking.DockContent
    {
        // 没有使用
        //定义
        private Li_HistoryTimeOut_BLL lhob = new Li_HistoryTimeOut_BLL();
        
        //函数
        #region 页面加载
        public HistoryTimeOut()
        {
            InitializeComponent();

            dtEndTime.Text = dtStartTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion

        //事件
        #region 点击查询, 重置按钮事件 Click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            lhob.SearchHisTimeOut(
                dtStartTime.Text.Trim(), 
                dtEndTime.Text.Trim(), 
                txtCard.Text.Trim(), 
                dgValue);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtEndTime.Text = dtStartTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtCard.Text = "";
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