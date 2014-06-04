using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NInterfaceShow;

namespace KJ128NMainRun.RealTime.RealtimeAlarmElectricity
{
    public partial class FrmRealtimeAlarmElectricity : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]
        
        private RealtimeAlarmElectricityBLL raebll = new RealtimeAlarmElectricityBLL();

        private int intCsTypeID = 2;
        #endregion

        #region [ 构造函数 ]

        public FrmRealtimeAlarmElectricity()
        {
            InitializeComponent();
            SelectRealtimeAlarmElectricity();
        }

        #endregion

        /*
         * 方法
         */ 

        #region [ 方法: 查询实时低电量信息 ]

        private void SelectRealtimeAlarmElectricity()
        {
            string strCounts;
            if (rbEmp.Checked)
            {
                intCsTypeID = 0;
            }
            else if (rbEqu.Checked)
            {
                intCsTypeID = 1;
            }
            else if (rbNotRegister.Checked)
            {
                intCsTypeID = 2;
            }
            else
            {
                intCsTypeID = 3;
            }
            raebll.N_SelectAlarmElectricity(4,intCsTypeID, dgvInfo,out strCounts);
            //bcpPageSum.Visible = true;
           // bcpPageSum.CaptionTitle = "共 " + strCounts + " 个发码器";
            if (rbEmp.Checked)
            {
                lb_Counts.Text = "共 " + strCounts + " 人";
            }
            else if (rbEqu.Checked)
            {
                lb_Counts.Text = "共 " + strCounts + " 个设备";
            }
            else
            {
                lb_Counts.Text = "共 " + strCounts + " 个标识卡";
            }
        }

        #endregion
        
        /*
         * 事件
         */ 

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

        #region [ 事件: 定时器事件 ]

        private void timeControl_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                SelectRealtimeAlarmElectricity();                //查询实时低电量信息
            }
        }

        #endregion

        #region [ 事件: 打印 ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvInfo,Text);
        }

        #endregion

        #region [ 事件: 选择人员 ]

        private void rbEmp_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEmp.Checked)
            {
                this.SelectRealtimeAlarmElectricity();
            }
        }

        #endregion

        #region [ 事件: 选择设备 ]

        private void rbEqu_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEqu.Checked)
            {
                this.SelectRealtimeAlarmElectricity();
            }
        }

        #endregion

        #region [ 事件: 选择所有发码器 ]

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAll.Checked)
            {
                this.SelectRealtimeAlarmElectricity();
            }
        }

        #endregion

        #region [ 事件: 选择未登记的发码器 ]

        private void rbNotRegister_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNotRegister.Checked)
            {
                this.SelectRealtimeAlarmElectricity();
            }
        }

        #endregion
    }

}