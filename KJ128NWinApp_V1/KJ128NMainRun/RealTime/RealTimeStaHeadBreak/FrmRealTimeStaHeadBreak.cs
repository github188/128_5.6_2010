using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KJ128NDBTable;
using KJ128NInterfaceShow;

namespace KJ128NMainRun.RealTime.RealTimeStaHeadBreak
{
    public partial class FrmRealTimeStaHeadBreak : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]

        private RealTimeStaHeadBreakBLL rtshbll = new RealTimeStaHeadBreakBLL();
        
        /// <summary>
        /// 判断是否是报警
        /// </summary>
        private bool blIsAlarm = false;

        #endregion


        #region [ 构造函数 ]

        public FrmRealTimeStaHeadBreak(bool bl)
        {
            InitializeComponent();
            blIsAlarm = bl;
        }

        #endregion

        /*
         * 方法
         */ 

        #region [ 方法: 查询接收器实时信息 ]

        private void SearchStaHeadBreakInfo()
        {
            rtshbll.N_SearchStaHeadBreakInfo(cbStaHeadState.Text.ToString(), dvStaHead);
        }

        #endregion

        /*
         * 事件
         */
 
        #region [ 事件: 窗体加载 ]

        private void FrmRealTimeStaHeadBreak_Load(object sender, EventArgs e)
        {
            //SearchStaHeadBreakInfo();
            if (blIsAlarm)
            {
                cbStaHeadState.SelectedIndex = 3;
                cbStaHeadState.Enabled = false;
            }
            else
            {
                cbStaHeadState.SelectedIndex = 0;
                cbStaHeadState.Enabled = true;
            }
            SearchStaHeadBreakInfo();
        }

        #endregion

        #region [ 事件: 定时器 ]

        private void timeControl_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                SearchStaHeadBreakInfo();
            }
        }
        
        #endregion

        #region [ 事件: 是否实时更新数据 ]

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (chk.Checked)
            {
                timeControl.Start();
            }
            else
            {
                timeControl.Stop();
            }
        }
        
        #endregion

        #region [ 事件: 选择接收器状态 ]

        private void cbStaHeadState_DropDownClosed(object sender, EventArgs e)
        {
            SearchStaHeadBreakInfo();
        }
        
        #endregion

        #region [ 事件: 打印 ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dvStaHead,Text);
        }
        
        #endregion
    }
}