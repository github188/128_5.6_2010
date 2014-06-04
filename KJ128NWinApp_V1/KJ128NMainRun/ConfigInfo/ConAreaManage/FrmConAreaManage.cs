using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KJ128NDBTable;
using KJ128NInterfaceShow;

namespace KJ128NMainRun.ConfigInfo.ConAreaManage
{
    public partial class FrmConAreaManage : Wilson.Controls.Docking.DockContent
    {

        #region [ 申明 ]

        private ConAreaManageBLL cambll = new ConAreaManageBLL();

        #endregion


        #region [ 构造函数 ]

        public FrmConAreaManage()
        {
            InitializeComponent();

            cambll.N_LoadInfo(cmbTerName, cmbTerType);            //加载 区域名称、区域类别
            string strCounts;

            int iSum = cambll.N_SearchTerInfo(dgvTerInfo);                   //加载 区域信息
            buttonCaptionPanel4.CaptionTitle = "区域信息:\t共 " + iSum.ToString() + " 条记录";

            cambll.N_SearchTerType(dgvTerType);                   //加载 区域类型
            buttonCaptionPanel7.CaptionTitle = "区域类别:\t共 " + iSum.ToString() + " 条记录";

            cambll.N_SearchTerSet("0", "0", dgvTerSet, out strCounts);           //加载 区域设置
            buttonCaptionPanel1.CaptionTitle = "区域设置信息:\t共  " + strCounts + " 条记录";
        }

        #endregion

        /*
         * 事件
         */ 

        #region [ 事件: 选择区域类别事件 ]

        private void cmbTerType_DropDownClosed(object sender, EventArgs e)
        {
            string strCounts;
            cambll.N_SearchTerSet(cmbTerName.SelectedValue.ToString(), cmbTerType.SelectedValue.ToString(), dgvTerSet,out strCounts);
            buttonCaptionPanel1.CaptionTitle = "区域设置信息:\t共  " + strCounts + " 条记录";
        }

        #endregion

        #region [ 事件: 选择区域名称事件 ]

        private void cmbTerName_DropDownClosed(object sender, EventArgs e)
        {
            string strCounts;
            cambll.N_SearchTerSet(cmbTerName.SelectedValue.ToString(), cmbTerType.SelectedValue.ToString(), dgvTerSet,out strCounts);
            buttonCaptionPanel1.CaptionTitle = "区域设置信息:\t共  " + strCounts + " 条记录";
        }

        #endregion

        #region [ 事件: 区域设置信息导出Excel ]

        private void cpTerSetToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvTerSet,"区域设置信息");
        }
        #endregion

        #region [ 事件: 区域类别信息导出Excel ]

        private void cpTerTypeToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvTerType,"区域类别信息");
        }

        #endregion

        #region [ 事件: 区域信息导出Excel ]

        private void cpTerInfoToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvTerInfo,"区域信息");
        }

        #endregion

    }
}