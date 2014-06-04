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
    public partial class FrmHistoryTotalInfo : Wilson.Controls.Docking.DockContent
    {
        //定义
        Li_HistoryTotal_BLL liht = new Li_HistoryTotal_BLL();

        #region 人员功能按钮
        private ButtonCaptionPanel bcpPelDept = new ButtonCaptionPanel();
        private ButtonCaptionPanel bcpPelWorkType = new ButtonCaptionPanel();
        private ButtonCaptionPanel bcpPelBusiness = new ButtonCaptionPanel();
        private ButtonCaptionPanel bcpPelLevel = new ButtonCaptionPanel();
        private ButtonCaptionPanel bcpTerritorial = new ButtonCaptionPanel();
        #endregion

        #region 设备功能按钮
        private ButtonCaptionPanel bcpEquDept = new ButtonCaptionPanel();
        #endregion
        //函数
        #region 页面加载
        public FrmHistoryTotalInfo()
        {
            InitializeComponent();

            dtEndTime.Text =  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
            #region 人员功能按钮定义
            bcpPelDept.CaptionTitle = "按部门汇总";
            bcpPelWorkType.CaptionTitle = "按工种汇总";
            bcpPelBusiness.CaptionTitle = "按职务汇总";
            bcpPelLevel.CaptionTitle = "按职务等级汇总";
            bcpTerritorial.CaptionTitle = "按区域汇总";

            bcpPelDept.CaptionHeight = 30;
            bcpPelWorkType.CaptionHeight = 30;
            bcpPelBusiness.CaptionHeight = 30;
            bcpPelLevel.CaptionHeight = 30;
            bcpTerritorial.CaptionHeight = 30;

            bcpPelDept.CaptionTitleLeft = 8;
            bcpPelDept.CaptionTitleTop = 8;
            bcpPelWorkType.CaptionTitleLeft = 8;
            bcpPelWorkType.CaptionTitleTop = 8;
            bcpPelBusiness.CaptionTitleLeft = 8;
            bcpPelBusiness.CaptionTitleTop = 8;
            bcpPelLevel.CaptionTitleLeft = 8;
            bcpPelLevel.CaptionTitleTop = 8;
            bcpTerritorial.CaptionTitleLeft = 8;
            bcpTerritorial.CaptionTitleTop = 8;

            bcpPelDept.IsBorderLine = true;
            bcpPelDept.IsCaptionSingleColor = true;
            bcpPelDept.IsOnlyCaption = true;
            bcpPelDept.IsPanelImage = true;
            bcpPelDept.IsUserButtonClose = false;
            bcpPelDept.IsUserCaptionBottomLine = false;
            bcpPelDept.IsUserSystemCloseButtonLeft = true;
            bcpPelDept.Width = 140;
            bcpPelDept.Height = 31;
            bcpPelDept.Location = new Point(5, 15);

            bcpPelWorkType.IsBorderLine = false;
            bcpPelWorkType.IsCaptionSingleColor = true;
            bcpPelWorkType.IsOnlyCaption = true;
            bcpPelWorkType.IsPanelImage = true;
            bcpPelWorkType.IsUserButtonClose = false;
            bcpPelWorkType.IsUserCaptionBottomLine = false;
            bcpPelWorkType.IsUserSystemCloseButtonLeft = true;
            bcpPelWorkType.Width = 140;
            bcpPelWorkType.Height = 31;
            bcpPelWorkType.Location = new Point(5, 53);

            bcpPelBusiness.IsBorderLine = false;
            bcpPelBusiness.IsCaptionSingleColor = true;
            bcpPelBusiness.IsOnlyCaption = true;
            bcpPelBusiness.IsPanelImage = true;
            bcpPelBusiness.IsUserButtonClose = false;
            bcpPelBusiness.IsUserCaptionBottomLine = false;
            bcpPelBusiness.IsUserSystemCloseButtonLeft = true;
            bcpPelBusiness.Width = 140;
            bcpPelBusiness.Height = 31;
            bcpPelBusiness.Location = new Point(5, 90);

            bcpPelLevel.IsBorderLine = false;
            bcpPelLevel.IsCaptionSingleColor = true;
            bcpPelLevel.IsOnlyCaption = true;
            bcpPelLevel.IsPanelImage = true;
            bcpPelLevel.IsUserButtonClose = false;
            bcpPelLevel.IsUserCaptionBottomLine = false;
            bcpPelLevel.IsUserSystemCloseButtonLeft = true;
            bcpPelLevel.Width = 140;
            bcpPelLevel.Height = 31;
            bcpPelLevel.Location = new Point(5, 127);

            bcpTerritorial.IsBorderLine = false;
            bcpTerritorial.IsCaptionSingleColor = true;
            bcpTerritorial.IsOnlyCaption = true;
            bcpTerritorial.IsPanelImage = true;
            bcpTerritorial.IsUserButtonClose = false;
            bcpTerritorial.IsUserCaptionBottomLine = false;
            bcpTerritorial.IsUserSystemCloseButtonLeft = true;
            bcpTerritorial.Width = 140;
            bcpTerritorial.Height = 31;
            bcpTerritorial.Location = new Point(5, 164);

            bcpPelDept.SetButtonStyle = ButtonCaptionPanelButtonStyle.WindowsStyle;
            bcpPelDept.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            bcpPelWorkType.SetButtonStyle = ButtonCaptionPanelButtonStyle.WindowsStyle;
            bcpPelWorkType.SetCaptionPanelStyle = CaptionPanelStyleEnum.DeepPaleCaptionNoBorder;
            bcpPelBusiness.SetButtonStyle = ButtonCaptionPanelButtonStyle.WindowsStyle;
            bcpPelBusiness.SetCaptionPanelStyle = CaptionPanelStyleEnum.DeepPaleCaptionNoBorder;
            bcpPelLevel.SetButtonStyle = ButtonCaptionPanelButtonStyle.WindowsStyle;
            bcpPelLevel.SetCaptionPanelStyle = CaptionPanelStyleEnum.DeepPaleCaptionNoBorder;
            bcpTerritorial.SetButtonStyle = ButtonCaptionPanelButtonStyle.WindowsStyle;
            bcpTerritorial.SetCaptionPanelStyle = CaptionPanelStyleEnum.DeepPaleCaptionNoBorder;
            #endregion

            #region 设备功能按钮定义
            bcpEquDept.CaptionTitle = "按部门汇总";

            bcpEquDept.CaptionHeight = 30;

            bcpEquDept.CaptionTitleLeft = 8;
            bcpEquDept.CaptionTitleTop = 8;

            bcpEquDept.CaptionTitleLeft = 8;
            bcpEquDept.CaptionTitleTop = 8;

            bcpEquDept.IsBorderLine = true;
            bcpEquDept.IsCaptionSingleColor = true;
            bcpEquDept.IsOnlyCaption = true;
            bcpEquDept.IsPanelImage = true;
            bcpEquDept.IsUserButtonClose = false;
            bcpEquDept.IsUserCaptionBottomLine = false;
            bcpEquDept.IsUserSystemCloseButtonLeft = true;
            bcpEquDept.Width = 140;
            bcpEquDept.Height = 31;
            bcpEquDept.Location = new Point(5, 15);

            bcpEquDept.SetButtonStyle = ButtonCaptionPanelButtonStyle.WindowsStyle;
            bcpEquDept.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            #endregion

            #region 人员功能按钮事件
            bcpPelDept.Click += new EventHandler(bcpPelDept_Click);
            bcpPelWorkType.Click += new EventHandler(bcpPelWorkType_Click);
            bcpPelBusiness.Click += new EventHandler(bcpPelBusiness_Click);
            bcpPelLevel.Click += new EventHandler(bcpPelLevel_Click);
            #endregion

            #region 设备功能按钮事件
            bcpEquDept.Click += new EventHandler(bcpEquDept_Click);
            #endregion

            #region 区域功能按钮市事件
            bcpTerritorial.Click += new EventHandler(bcpTerritorial_Click);
            #endregion

            //加载人员功能按钮
            LoadEmpFunButton();
        }

        

        #endregion

        #region 加载人员功能按钮
        private void LoadEmpFunButton()
        {
            if (!plFunction.Contains(bcpPelDept))
            { plFunction.Controls.Add(bcpPelDept); }

            if (!plFunction.Contains(bcpPelWorkType))
            { plFunction.Controls.Add(bcpPelWorkType); }

            if (!plFunction.Contains(bcpPelBusiness))
            { plFunction.Controls.Add(bcpPelBusiness); }

            if (!plFunction.Contains(bcpPelLevel))
            { plFunction.Controls.Add(bcpPelLevel); }

            if (!plFunction.Contains(bcpTerritorial))
            { plFunction.Controls.Add(bcpTerritorial); }

            bcpPelDept.Visible = true;
            bcpPelWorkType.Visible = true;
            bcpPelBusiness.Visible = true;
            bcpPelLevel.Visible = true;

            bcpEquDept.Visible = false;

            bcpPensonel.CaptionForeColor = Color.FromArgb(62, 22, 110);
            bcpEpu.CaptionForeColor = Color.FromArgb(0, 0, 0);

            bcpPensonel.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaption;
            bcpEpu.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;

            bcpPensonel.IsCaptionSingleColor = true;
            bcpPensonel.IsUserCaptionBottomLine = true;
            bcpEpu.IsCaptionSingleColor = false;
            bcpEpu.IsUserCaptionBottomLine = false;

            if (liht.LoadInfo(treeInfo, "Dept", 0, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")))
            {
                treeInfo.ExpandAll();

                bcpPelDept.IsBorderLine = true;
                bcpPelDept.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
                bcpPelWorkType.IsBorderLine = false;
                bcpPelWorkType.SetCaptionPanelStyle = CaptionPanelStyleEnum.DeepPaleCaptionNoBorder;
                bcpPelBusiness.IsBorderLine = false;
                bcpPelBusiness.SetCaptionPanelStyle = CaptionPanelStyleEnum.DeepPaleCaptionNoBorder;
                bcpPelLevel.IsBorderLine = false;
                bcpPelLevel.SetCaptionPanelStyle = CaptionPanelStyleEnum.DeepPaleCaptionNoBorder;
                bcpTerritorial.IsBorderLine = false;
                bcpTerritorial.SetCaptionPanelStyle = CaptionPanelStyleEnum.DeepPaleCaptionNoBorder;
            }
        }
        #endregion

        //事件
        #region 点击人员/设备事件 Click
        private void bcpPensonel_Click(object sender, EventArgs e)
        {
            LoadEmpFunButton();
        }

        private void bcpEpu_Click(object sender, EventArgs e)
        {
            if (!plFunction.Contains(bcpEquDept))
            {plFunction.Controls.Add(bcpEquDept);}

            bcpEquDept.Visible = true;

            bcpPelDept.Visible = false;
            bcpPelWorkType.Visible = false;
            bcpPelBusiness.Visible = false;
            bcpPelLevel.Visible = false;

            bcpPensonel.CaptionForeColor = Color.FromArgb(0, 0, 0);
            bcpEpu.CaptionForeColor = Color.FromArgb(62, 22, 110);

            bcpPensonel.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
            bcpEpu.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaption;

            bcpPensonel.IsCaptionSingleColor = false;
            bcpPensonel.IsUserCaptionBottomLine = false;
            bcpEpu.IsCaptionSingleColor = true;
            bcpEpu.IsUserCaptionBottomLine = true;
        }
        #endregion

        #region 点击人员功能按钮事件 Click
        void bcpPelLevel_Click(object sender, EventArgs e)
        {
            if (liht.LoadInfo(treeInfo, "BusLevel", 0, dtStartTime.Text.Trim(), dtEndTime.Text.Trim()))
            {
                treeInfo.ExpandAll();

                bcpPelDept.IsBorderLine = false;
                bcpPelDept.SetCaptionPanelStyle = CaptionPanelStyleEnum.DeepPaleCaptionNoBorder;
                bcpPelWorkType.IsBorderLine = false;
                bcpPelWorkType.SetCaptionPanelStyle = CaptionPanelStyleEnum.DeepPaleCaptionNoBorder;
                bcpPelBusiness.IsBorderLine = false;
                bcpPelBusiness.SetCaptionPanelStyle = CaptionPanelStyleEnum.DeepPaleCaptionNoBorder;
                bcpPelLevel.IsBorderLine = true;
                bcpPelLevel.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            }
        }

        void bcpPelBusiness_Click(object sender, EventArgs e)
        {
            if (liht.LoadInfo(treeInfo, "Business", 0, dtStartTime.Text.Trim(), dtEndTime.Text.Trim()))
            {
                treeInfo.ExpandAll();

                bcpPelDept.IsBorderLine = false;
                bcpPelDept.SetCaptionPanelStyle = CaptionPanelStyleEnum.DeepPaleCaptionNoBorder;
                bcpPelWorkType.IsBorderLine = false;
                bcpPelWorkType.SetCaptionPanelStyle = CaptionPanelStyleEnum.DeepPaleCaptionNoBorder;
                bcpPelBusiness.IsBorderLine = true;
                bcpPelBusiness.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
                bcpPelLevel.IsBorderLine = false;
                bcpPelLevel.SetCaptionPanelStyle = CaptionPanelStyleEnum.DeepPaleCaptionNoBorder;
            }
        }

        void bcpPelWorkType_Click(object sender, EventArgs e)
        {
            if (liht.LoadInfo(treeInfo, "WorkType", 0, dtStartTime.Text.Trim(), dtEndTime.Text.Trim()))
            {
                treeInfo.ExpandAll();

                bcpPelDept.IsBorderLine = false;
                bcpPelDept.SetCaptionPanelStyle = CaptionPanelStyleEnum.DeepPaleCaptionNoBorder;
                bcpPelWorkType.IsBorderLine = true;
                bcpPelWorkType.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
                bcpPelBusiness.IsBorderLine = false;
                bcpPelBusiness.SetCaptionPanelStyle = CaptionPanelStyleEnum.DeepPaleCaptionNoBorder;
                bcpPelLevel.IsBorderLine = false;
                bcpPelLevel.SetCaptionPanelStyle = CaptionPanelStyleEnum.DeepPaleCaptionNoBorder;
            }
        }

        void bcpPelDept_Click(object sender, EventArgs e)
        {
            if (liht.LoadInfo(treeInfo, "Dept", 0, dtStartTime.Text.Trim(), dtEndTime.Text.Trim()))
            {
                treeInfo.ExpandAll();

                bcpPelDept.IsBorderLine = true;
                bcpPelDept.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
                bcpPelWorkType.IsBorderLine = false;
                bcpPelWorkType.SetCaptionPanelStyle = CaptionPanelStyleEnum.DeepPaleCaptionNoBorder;
                bcpPelBusiness.IsBorderLine = false;
                bcpPelBusiness.SetCaptionPanelStyle = CaptionPanelStyleEnum.DeepPaleCaptionNoBorder;
                bcpPelLevel.IsBorderLine = false;
                bcpPelLevel.SetCaptionPanelStyle = CaptionPanelStyleEnum.DeepPaleCaptionNoBorder;
            }
        }

        void bcpTerritorial_Click(object sender, EventArgs e)
        {
            if (liht.LoadInfo(treeInfo, "Territorial", 0, dtStartTime.Text.Trim(), dtEndTime.Text.Trim()))
            {
                treeInfo.ExpandAll();
            }
        }

        #endregion

        #region 点击设备功能按钮事件 Click
        void bcpEquDept_Click(object sender, EventArgs e)
        {
            if (liht.LoadInfo(treeInfo, "Dept", 2, dtStartTime.Text.Trim(), dtEndTime.Text.Trim()))
            {
                treeInfo.ExpandAll();
            }
        }
        #endregion

        
        

 
    }
}