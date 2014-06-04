using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NInterfaceShow;

namespace KJ128NMainRun.ConfigInfo.ConDirectionalManage
{
    public partial class FrmConDirectionalManage : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]

        private ConDirectionalManageBLL cdmbll = new ConDirectionalManageBLL();

        #endregion


        #region [ 构造函数 ]

        public FrmConDirectionalManage()
        {
            InitializeComponent();

            bcpSelect_Click(null,null);
        }

        #endregion

        /*
         * 事件
         */ 

        #region [ 事件: 重置_Click事件 ]

        private void btnCanel_Click(object sender, EventArgs e)
        {
            txtDetection.Text = "";
            txtWhere.Text = "";
        }

        #endregion

        #region [ 事件: 查询_Click事件 ]

        private void bcpSelect_Click(object sender, EventArgs e)
        {
            string strCounts;
            cdmbll.N_SearchDirectionalManage(txtDetection.Text.Trim(), txtWhere.Text.Trim(), dgvDirectional,out strCounts);
            buttonCaptionPanel8.CaptionTitle = "方向性配置信息:\t共 " + strCounts + " 条记录";
        }

        #endregion

        #region [ 事件: 导出Excel ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvDirectional,Text);
        }

        #endregion
    }
}