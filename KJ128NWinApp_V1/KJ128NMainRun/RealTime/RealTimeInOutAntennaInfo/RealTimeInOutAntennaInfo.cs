using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KJ128NDBTable;
using KJ128NDataBase;

namespace KJ128NInterfaceShow
{
    public partial class RealTimeInOutAntennaInfo : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]

        private Li_RealTimeInOutAntennaInfo_BLL lrib = new Li_RealTimeInOutAntennaInfo_BLL();

        private int intScrollOldValue = 0;

        /// <summary>
        /// 发码器类型 0:人员;1:设备;2:未登记;3:所有
        /// </summary>
        private int intUserType = 3;

        #endregion


        #region [ 构造函数 ]

        public RealTimeInOutAntennaInfo()
        {
            InitializeComponent();

            dtStartTime.Text = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00";
            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            #region 加载分站信息
            lrib.LoadInfo(cmbStationAddress, cmbStationHeadAddress, false);
            #endregion
        }

        #endregion

        /*
         * 方法
         */

        #region [ 方法: 查询实时进出天线信息 ]

        /// <summary>
        /// 查询实时进出天线信息
        /// </summary>
        private void SelectInfo()
        {
            string strCounts;
            if (rbEmp.Checked)
            {
                intUserType = 0;
            }
            else if (rbEqu.Checked)
            {
                intUserType = 1;
            }
            else if (rbNotCode.Checked)
            {
                intUserType = 2;
            }
            else
            {
                intUserType = 3;
            }
            lrib.N_SearchRTInOutAntennaInfo(
                dtStartTime.Text.Trim(),
                dtEndTime.Text.Trim(),
                txtCard.Text.Trim(),
                cmbStationAddress.SelectedValue.ToString(),
                cmbStationHeadAddress.SelectedValue.ToString(),
                intUserType,
                dgValue, out strCounts);

            if (strCounts != "-1")
            {
                //bcpPageSum.CaptionTitle = "共" + strCounts + "条";
                if(rbEmp.Checked)           //人员
                {
                    lb_Counts.Text = "共 " + strCounts + " 人";
                }
                else if (rbEqu.Checked)      //设备
                {
                    lb_Counts.Text = "共 " + strCounts + " 个设备";
                }
                else                         //发码器
                {
                    lb_Counts.Text = "共 " + strCounts + " 个"+HardwareName.Value(CorpsName.CodeSender);
                }
            }
        }

        #endregion

        /*
         * 事件
         */

        #region [ 事件: 窗体加载 ]

        private void RealTimeInOutAntennaInfo_Load(object sender, EventArgs e)
        {
            this.SelectInfo();

            sxpPanel1.Caption ="进入"+ HardwareName.Value(CorpsName.StaHead)+"时间";
            label3.Text = HardwareName.Value(CorpsName.CodeSenderAddress);
            label4.Text = HardwareName.Value(CorpsName.StationSplace);
            label5.Text = HardwareName.Value(CorpsName.StaHeadSplace);
            rbNotCode.Text = "未登记的" + HardwareName.Value(CorpsName.CodeSender);
        }

        #endregion

        #region [ 事件: 选择分站_SelectionChangeCommitted事件 ]

        private void cmbStationAddress_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lrib.LoadInfo(cmbStationAddress, cmbStationHeadAddress, true);
        }

        #endregion

        #region [ 事件: 查询按钮_Click事件 ]

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.SelectInfo();
        }

        #endregion

        #region [ 事件: 重置按钮_Click事件 ]

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtStartTime.Text = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00";
            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            
            rbAll.Checked = true;
            txtCard.Text = "";
            lrib.LoadInfo(cmbStationAddress, cmbStationHeadAddress, false);
        }

        #endregion

        #region [ 事件: 定时器]

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                this.SelectInfo();

                dgValue.VerticalScrollBarValue = intScrollOldValue > dgValue.VerticalScrollBarMax ? 0 : intScrollOldValue;
            }
        }
        #endregion

        #region [ 事件: DataGridView滚动条_Scroll事件 ]

        private void dgValue_Scroll(object sender, ScrollEventArgs e)
        {
            intScrollOldValue = dgValue.VerticalScrollBarValue;
        }

        #endregion

        #region [ 事件: 是否实时更新数据 ]

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (chk.Checked)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
        }

        #endregion

        #region [ 事件: 打印 ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgValue, Text, lb_Counts.Text);
        }

        #endregion

    }
}