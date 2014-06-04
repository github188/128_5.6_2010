using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128WindowsLibrary;
using KJ128NDBTable;

namespace KJ128NInterfaceShow
{
    public partial class EmployeeClassify : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]

        private RTClassifyBLL rtcbll = new RTClassifyBLL();

        private int intSelect = 0;

        #endregion


        #region [ 构造函数 ]

        public EmployeeClassify()
        {
            InitializeComponent();
            //设置默认为下井工种汇总
            captionPanel1.SetCaptionPanelStyle = CaptionPanelStyleEnum.Office2007Panel;
            captionPanel2.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
            captionPanel3.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
            captionPanel4.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
            captionPanel5.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
            dgv_WorkType.Visible = false;

            rtcbll.N_LoadInfo(treeView1, "WorkType", 0);
        }
        #endregion

        /*
         * 事件
         */ 

        #region [ 事件: 按工种汇总_Click事件 ]

        private void captionPanel1_Click(object sender, EventArgs e)
        {
            if (rtcbll.N_LoadInfo(treeView1, "WorkType", 0))
            {
                captionPanel1.SetCaptionPanelStyle = CaptionPanelStyleEnum.Office2007Panel;
                captionPanel2.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel3.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel4.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel5.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel6.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;

                buttonCaptionPanel1.CaptionTitle = "根据不同的工种对员工下井信息进行汇总:";
                dgv_WorkType.Visible = false;
                treeView1.Visible = true;
                intSelect = 1;
            }
        }

        #endregion

        #region [ 事件: 按部门汇总_Click事件 ]

        private void captionPanel2_Click(object sender, EventArgs e)
        {
            if (rtcbll.N_LoadInfo(treeView1, "Dept", 0))
            {
                captionPanel1.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel2.SetCaptionPanelStyle = CaptionPanelStyleEnum.Office2007Panel;
                captionPanel3.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel4.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel5.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel6.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;

                buttonCaptionPanel1.CaptionTitle = "根据不同的部门对员工下井信息进行汇总:";
                dgv_WorkType.Visible = false;
                treeView1.Visible = true;
                intSelect = 2;
            }
        }

        #endregion

        #region [ 事件: 按职务汇总_Click事件 ]

        private void captionPanel3_Click(object sender, EventArgs e)
        {
            if (rtcbll.N_LoadInfo(treeView1, "Business", 0))
            {
                captionPanel1.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel2.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel3.SetCaptionPanelStyle = CaptionPanelStyleEnum.Office2007Panel;
                captionPanel4.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel5.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel6.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;

                buttonCaptionPanel1.CaptionTitle = "根据不同的职务对员工下井信息进行汇总:";
                dgv_WorkType.Visible = false;
                treeView1.Visible = true;
                intSelect = 3;
            }

        }

        #endregion

        #region [ 事件: 按职务等级汇总_Click事件 ]

        private void captionPanel5_Click(object sender, EventArgs e)
        {
            if (rtcbll.N_LoadInfo(treeView1, "BusLevel", 0))
            {
                captionPanel1.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel2.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel3.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel4.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel5.SetCaptionPanelStyle = CaptionPanelStyleEnum.Office2007Panel;
                captionPanel6.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;

                buttonCaptionPanel1.CaptionTitle = "根据不同的职务等级对员工下井信息进行汇总:";
                dgv_WorkType.Visible = false;
                treeView1.Visible = true;
                intSelect = 5;
            }
        }

        #endregion

        #region [ 事件: 按方向性汇总_Click事件 ]

        private void captionPanel4_Click(object sender, EventArgs e)
        {
            if (rtcbll.N_LoadInfo(treeView1, "Directional", 0))
            {
                captionPanel1.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel2.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel3.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel4.SetCaptionPanelStyle = CaptionPanelStyleEnum.Office2007Panel;
                captionPanel5.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel6.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;

                buttonCaptionPanel1.CaptionTitle = "根据不同的方向性对员工下井信息进行汇总:";

                intSelect = 4;
                treeView1.ExpandAll();
            }
            
        }

        #endregion

        #region [ 事件：按区域汇总_Click事件]

        private void captionPanel6_Click(object sender, EventArgs e)
        {
            if (rtcbll.N_LoadInfo(treeView1, "Territorial", 0))
            {
                captionPanel1.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel2.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel3.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel4.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel5.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel6.SetCaptionPanelStyle = CaptionPanelStyleEnum.Office2007Panel;

                buttonCaptionPanel1.CaptionTitle = "根据不同的区域对员工下井信息进行汇总:";

                intSelect = 6;
                treeView1.ExpandAll();
            }
        }

        #endregion

        #region [ 事件: 定时器 ]

        private void timeControl_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                switch (intSelect)
                {
                    case 1:                             //工种
                        captionPanel1_Click(sender, e);
                        break;
                    case 2:                             //部门
                        captionPanel2_Click(sender, e);
                        break;
                    case 3:                             //职务
                        captionPanel3_Click(sender, e);
                        break;
                    case 4:                             //方向性
                        captionPanel4_Click(sender, e);
                        break;
                    case 5:                             //职务等级
                        captionPanel5_Click(sender, e);
                        break;
                    case 6:                             //区域
                        captionPanel6_Click(sender, e);
                        break;
                    default:
                        break;
                }
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

        
    }
}