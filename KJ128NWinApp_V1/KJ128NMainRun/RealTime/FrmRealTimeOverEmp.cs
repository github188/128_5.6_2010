using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NMainRun.RealTime
{
    public partial class FrmRealTimeOverEmp : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]

        private RealTimeOverEmpBLL rtoebll = new RealTimeOverEmpBLL();

        #endregion

        #region [ 构造函数 ]

        public FrmRealTimeOverEmp()
        {
            InitializeComponent();

            //查询超员信息
            SelectOverEmp();
        }

        #endregion

        /*
         * 方法
         */ 

        #region [ 方法: 查询超员信息 ]

        private void SelectOverEmp()
        {
            rtoebll.SelectOverEmp(1, dgvOverEmp);

            buttonCaptionPanel1.CaptionTitle = "实时超员显示：\t共" + dgvOverEmp.Rows.Count.ToString() + "条信息";

        }

        #endregion

        /*
         * 事件
         */ 
         
        #region [ 事件: 是否启用实时更新 ]

        private void chk_EnabledChanged(object sender, EventArgs e)
        {
            if (chk.Checked)
            {
                this.timer.Start();
            }
            else
            {
                this.timer.Stop();
            }
        }

        #endregion

        #region [ 事件: 定时器 ]

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                this.SelectOverEmp();
            }
        }

        #endregion

        #region [ 事件: 打印 ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvOverEmp,Text);
        }

        #endregion

    }
}