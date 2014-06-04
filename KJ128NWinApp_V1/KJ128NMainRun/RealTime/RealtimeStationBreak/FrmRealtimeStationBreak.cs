using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KJ128NDBTable;
using KJ128NInterfaceShow;

namespace KJ128NMainRun.RealTime.RealtimeStationBreak
{
    public partial class FrmRealtimeStationBreak : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]

        private RealtimeStationBreakBLL rsbbll = new RealtimeStationBreakBLL();
        
        private bool blIsAlarm = false;

        #endregion

        #region [ 构造函数 ]

        public FrmRealtimeStationBreak(bool bl)
        {
            InitializeComponent();
            blIsAlarm = bl;
        }

        #endregion

        /*
         * 方法
         */ 

        #region [ 方法: 查询实时分站信息 ]

        private void SearchStaBreakInfo()
        {
            rsbbll.N_SearchStaBreakInfo(cbStaState.Text.Trim(), dvSta);

            //判断是否故障，如果故障显示红色
            StationBadToRed();
        }

        /// <summary>
        /// 判断传输分站是否故障，如果故障在GridView里显示红色
        /// </summary>
        private void StationBadToRed()
        {
            foreach (DataGridViewRow dr in dvSta.Rows)
            {
                if (dr.Cells["分站状态"].Value.ToString() == "故障")
                {
                    dr.Cells["分站状态"].Style.ForeColor = Color.Red; 
                }
                else
                {
                    dr.Cells["分站状态"].Style.ForeColor = Color.Green;
                }
            }
        }

        #endregion

        /*
         * 事件
         */ 

        #region [ 事件: 窗体加载 ]

        private void FrmRealtimeStationBreak_Load(object sender, EventArgs e)
        {
            if (blIsAlarm)
            {
                cbStaState.SelectedIndex = 3;
                cbStaState.Enabled = false;
                
            }
            else
            {
                cbStaState.SelectedIndex = 0;
                cbStaState.Enabled = true;
            }
        }

        #endregion

        #region [ 事件: 定时器 ]

        private void timeControl_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                SearchStaBreakInfo();
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

        #region [ 事件: 选择分站状态 ]

        private void cbStaState_DropDownClosed(object sender, EventArgs e)
        {
            SearchStaBreakInfo();
        }

        #endregion

        #region [ 事件: 打印 ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dvSta,Text);
        }

        #endregion

        private void FrmRealtimeStationBreak_Shown(object sender, EventArgs e)
        {
            SearchStaBreakInfo();
        }

        private void dvSta_Sorted(object sender, EventArgs e)
        {
            StationBadToRed();
        }

    }
}