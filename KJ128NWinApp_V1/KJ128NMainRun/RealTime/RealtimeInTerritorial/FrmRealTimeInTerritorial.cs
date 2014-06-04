using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KJ128NDBTable;
using KJ128NInterfaceShow;

namespace KJ128NMainRun.RealTime.RealtimeInTerritorial
{
    public partial class FrmRealTimeInTerritorial : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]

        private RealTimeInTerritorialBLL rttbll = new RealTimeInTerritorialBLL();

        private static int intTerTypeID;
        private static string strTerName ;
        private static bool blIsEmp ;
        private bool blIsFirst = false;
        private bool blIsAlarm = false;

        #endregion
        

        #region [ 构造函数 ]

        public FrmRealTimeInTerritorial(bool bl)
        {
            InitializeComponent();

            #region 加载区域名称
            rttbll.N_LoadTerName(cmb_TerName);
            #endregion

            #region 加载区域类别
            rttbll.N_LoadTerTypeName(cmb_TerTypeName);
            #endregion
            blIsAlarm = bl;

            cmb_IsAlarm.SelectedIndex = 0;

        }

        #endregion

        /*
         * 方法
         */
 
        #region [ 方法: 查询实时区域信息 ]

        /// <summary>
        /// 查询 实时区域信息
        /// </summary>
        private void SelectRTInTer()
        {
            string strCounts;
            if (blIsEmp)
            {
                rttbll.N_SearchRTInTerritorialInfo(intTerTypeID, strTerName, blIsEmp,cmb_IsAlarm.Text.Trim(), dvEmp,out strCounts);
                lb_Counts.Text = "共 " + strCounts + " 人";
            }
            else
            {
                rttbll.N_SearchRTInTerritorialInfo(intTerTypeID, strTerName, blIsEmp,cmb_IsAlarm.Text.Trim(), dvEqu,out strCounts);
                lb_Counts.Text = "共 " + strCounts + " 个设备";
            }
        }

        #endregion

        /*
         * 事件
         */
 
        #region [ 事件: 窗体加载 ]

        private void FrmRealTimeInTerritorial_Load(object sender, EventArgs e)
        {
            if (blIsAlarm)
            {
                cmb_IsAlarm.SelectedIndex = 1;

                if (rttbll.IsEmpAlarm())
                {
                    rbEmp.Checked = true;
                }
                else
                {
                    rbEqu.Checked = true;
                }

            }
            btnSearch_Click(sender, e);
        }

        #endregion

        #region [ 事件: 查询按钮_Click事件 ]

        private void btnSearch_Click(object sender, EventArgs e)
        {
            intTerTypeID = Convert.ToInt32(cmb_TerTypeName.SelectedValue);
            strTerName = cmb_TerName.Text;
            blIsEmp = rbEmp.Checked;
            blIsFirst = true;

            if (rbEmp.Checked)
            {
                dvEmp.Visible = true;
                dvEqu.Visible = false;
                buttonCaptionPanel1.CaptionTitle = "实时区域人员信息：";
            }
            if (rbEqu.Checked)
            {
                dvEmp.Visible = false;
                dvEqu.Visible = true;
                buttonCaptionPanel1.CaptionTitle = "实时区域设备信息：";
            }
            
            SelectRTInTer();                //查询实时区域信息
        }

        #endregion

        #region [ 事件: 重置按钮_Click事件  ]

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cmb_TerName.SelectedValue = 0;
            cmb_TerTypeName.SelectedValue = 0;
            rbEmp.Checked = true;

            //dvEmp.Visible = true;
            //dvEqu.Visible = false;
        }

        #endregion

        #region [ 事件: 是否实时更新数据 ]

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                timeControl.Start();
            }
            else
            {
                timeControl.Stop();
            }
        }

        #endregion

        #region [ 事件: 定时器 ]

        private void timeControl_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                if (blIsFirst)
                {
                    SelectRTInTer();                //查询实时区域信息
                }
            }
        }

        #endregion

        #region [ 事件: 导出Excel ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            DataGridViewKJ128 dgv = new DataGridViewKJ128();
            if (rbEmp.Checked)
            {
                
                dgv = dvEmp;
            }
            else
            {
                dgv = dvEqu;
            }
            PrintBLL.Print(dgv, Text, lb_Counts.Text);
            
        }

        #endregion
    }
}