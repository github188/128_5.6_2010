using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KJ128NDBTable;
using KJ128NInterfaceShow;

namespace KJ128NMainRun.ConfigInfo.ConEquManage
{
    public partial class FrmConEquManage : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]

        private ConEquManageBLL cembll = new ConEquManageBLL();

        #endregion 


        #region [ 构造函数 ]

        public FrmConEquManage()
        {
            InitializeComponent();

            cembll.N_LoadInfo(cmbFacName1);
            cembll.N_LoadInfo(cmbFacName2);
            btnQuery1_Click(null,null);
            btnQuery2_Click(null,null);
        }

        #endregion

        /*
         * 事件
         */ 

        #region [ 事件: 设备查询_Click事件 ]

        private void btnQuery1_Click(object sender, EventArgs e)
        {
            string strCounts;
            cembll.N_SearchEquInfo(txtEquNo.Text.Trim(), txtEquName.Text.Trim(), cmbFacName1.SelectedValue.ToString(),dgvCode,out strCounts);
            captionPanel1.CaptionTitle = "设备信息:\t共 " + strCounts + " 个设备";
        }

        #endregion

        #region [ 事件: 设备重置_Click事件 ]

        private void btnCanel1_Click(object sender, EventArgs e)
        {
            txtEquNo.Text = "";
            txtEquName.Text = "";
            cmbFacName1.SelectedIndex = 0;
        }

        #endregion

        #region [ 事件: 厂家查询_Click事件 ]

        private void btnQuery2_Click(object sender, EventArgs e)
        {
            string strCounts;
            cembll.N_SearchFactoryInfo(txtFacNo.Text.Trim(), cmbFacName2.SelectedValue.ToString(),dgvCodeSender,out strCounts);
            //bcpPageSum2.Visible = true;
            buttonCaptionPanel2.CaptionTitle = "生产厂家信息:\t共 " + strCounts + " 个";
            //bcpPageSum2.CaptionTitle = "共" + strCounts + "条";
        }

        #endregion

        #region [ 事件: 厂家重置_Click事件 ]
        private void btnCanel2_Click(object sender, EventArgs e)
        {
            txtFacNo.Text = "";
            cmbFacName2.SelectedIndex = 0;
        }
        #endregion

        #region [ 事件: 设备信息打印 ]

        private void cpEquToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvCode,"设备信息");
        }

        #endregion

        #region [ 事件: 生产厂家信息打印 ]

        private void cpFacToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvCodeSender,"生产厂家信息");
        }

        #endregion
    }
}