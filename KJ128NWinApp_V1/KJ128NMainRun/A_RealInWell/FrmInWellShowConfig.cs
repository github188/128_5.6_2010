using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJ128NMainRun.A_RealInWell
{
    public partial class FrmInWellShowConfig : Form
    {
        #region 【自定义参数】
        /// <summary>
        /// 实时下井界面对象
        /// </summary>
        private FrmRealInWell m_frmRealtimeInWell = null;
        #endregion

        #region 【构造函数】
        public FrmInWellShowConfig(FrmRealInWell frmRealtimeInWell)
        {
            InitializeComponent();
            //m_frmRealtimeInWell = frmRealtimeInWell;
            //RealShowConfig();
        }
        #endregion

        #region【qyz 2012-3-23 屏蔽】
        //#region 【自定义方法】
        //#region【方法：读取人员显示设置】
        ///// <summary>
        ///// 读取人员显示配置信息
        ///// </summary>
        //private void RealShowConfig()
        //{
        //    for (int i = 0; i < m_frmRealtimeInWell.columnConfigs.Length; i++)
        //    {
        //        switch (m_frmRealtimeInWell.columnConfigs[i].columnName)
        //        {
        //            case "标识卡号":
        //                Cbx_CodeAddress.Checked = m_frmRealtimeInWell.columnConfigs[i].isShow;
        //                break;
        //            case "姓名":
        //                Cbx_Name.Checked = m_frmRealtimeInWell.columnConfigs[i].isShow;
        //                break;
        //            case "人员编号":
        //                Cbx_Empid.Checked = m_frmRealtimeInWell.columnConfigs[i].isShow;
        //                break;
        //            case "部门":
        //                Cbx_Dept.Checked = m_frmRealtimeInWell.columnConfigs[i].isShow;
        //                break;
        //            case "工种":
        //                Cbx_WorkType.Checked = m_frmRealtimeInWell.columnConfigs[i].isShow;
        //                break;
        //            case "职务":
        //                Cbx_duty.Checked = m_frmRealtimeInWell.columnConfigs[i].isShow;
        //                break;
        //            case "班组":
        //                Cbx_Class.Checked = m_frmRealtimeInWell.columnConfigs[i].isShow;
        //                break;
        //            case "班制":
        //                Cbx_ClassSet.Checked = m_frmRealtimeInWell.columnConfigs[i].isShow;
        //                break;
        //            case "班次":
        //                Cbx_ClassNum.Checked = m_frmRealtimeInWell.columnConfigs[i].isShow;
        //                break;
        //            case "入井位置":
        //                Cbx_InPalce.Checked = m_frmRealtimeInWell.columnConfigs[i].isShow;
        //                break;
        //            case "入井时刻":
        //                Cbx_InTime.Checked = m_frmRealtimeInWell.columnConfigs[i].isShow;
        //                break;
        //            case "入井工作时长":
        //                Cbx_InWorkTime.Checked = m_frmRealtimeInWell.columnConfigs[i].isShow;
        //                break;
        //            case "现处位置":
        //                Cbx_NowPlace.Checked = m_frmRealtimeInWell.columnConfigs[i].isShow;
        //                break;
        //            case "现位置持续时长":
        //                Cbx_NowTime.Checked = m_frmRealtimeInWell.columnConfigs[i].isShow;
        //                break;
        //            case "进入现位置时刻":
        //                Cbx_InNowPlaceTime.Checked = m_frmRealtimeInWell.columnConfigs[i].isShow;
        //                break;
        //            case "方向性":
        //                Cbx_Direction.Checked = m_frmRealtimeInWell.columnConfigs[i].isShow;
        //                break;
        //        }
        //    }

        //    for (int i = 0; i < m_frmRealtimeInWell.tabpageConfigs.Length; i++)
        //    {
        //        switch (m_frmRealtimeInWell.tabpageConfigs[i].tabpageName)
        //        {
        //            case "部门":
        //                Cbx_Dept_Sum.Checked = m_frmRealtimeInWell.tabpageConfigs[i].isShow;
        //                break;
        //            case "工种":
        //                Cbx_WorkType_Sum.Checked = m_frmRealtimeInWell.tabpageConfigs[i].isShow;
        //                break;
        //            case "职务":
        //                Cbx_Duty_Sum.Checked = m_frmRealtimeInWell.tabpageConfigs[i].isShow;
        //                break;
        //            case "方向性":
        //                Cbx_Direction_Sum.Checked = m_frmRealtimeInWell.tabpageConfigs[i].isShow;
        //                break;
        //            case "职务等级":
        //                Cbx_DutyRank_Sum.Checked = m_frmRealtimeInWell.tabpageConfigs[i].isShow;
        //                break;
        //        }
        //    }
        //}
        //#endregion

        //#region 【方法：修改显示xml文件】
        ///// <summary>
        ///// 修改显示配置文件
        ///// </summary>
        //private void updateShowXml()
        //{
        //    for (int i = 0; i < m_frmRealtimeInWell.columnConfigs.Length; i++)
        //    {
        //        switch (m_frmRealtimeInWell.columnConfigs[i].columnName)
        //        {
        //            case "标识卡号":
        //                m_frmRealtimeInWell.columnConfigs[i].isShow = Cbx_CodeAddress.Checked;
        //                break;
        //            case "姓名":
        //                m_frmRealtimeInWell.columnConfigs[i].isShow = Cbx_Name.Checked;
        //                break;
        //            case "人员编号":
        //                m_frmRealtimeInWell.columnConfigs[i].isShow = Cbx_Empid.Checked;
        //                break;
        //            case "部门":
        //                m_frmRealtimeInWell.columnConfigs[i].isShow = Cbx_Dept.Checked;
        //                break;
        //            case "工种":
        //                m_frmRealtimeInWell.columnConfigs[i].isShow = Cbx_WorkType.Checked;
        //                break;
        //            case "职务":
        //                m_frmRealtimeInWell.columnConfigs[i].isShow=Cbx_duty.Checked;
        //                break;
        //            case "班组":
        //                m_frmRealtimeInWell.columnConfigs[i].isShow=Cbx_Class.Checked ;
        //                break;
        //            case "班制":
        //                m_frmRealtimeInWell.columnConfigs[i].isShow = Cbx_ClassSet.Checked;
        //                break;
        //            case "班次":
        //                m_frmRealtimeInWell.columnConfigs[i].isShow = Cbx_ClassNum.Checked;
        //                break;
        //            case "入井位置":
        //                m_frmRealtimeInWell.columnConfigs[i].isShow = Cbx_InPalce.Checked;
        //                break;
        //            case "入井时刻":
        //                m_frmRealtimeInWell.columnConfigs[i].isShow = Cbx_InTime.Checked;
        //                break;
        //            case "入井工作时长":
        //                m_frmRealtimeInWell.columnConfigs[i].isShow = Cbx_InWorkTime.Checked;
        //                break;
        //            case "现处位置":
        //                m_frmRealtimeInWell.columnConfigs[i].isShow = Cbx_NowPlace.Checked;
        //                break;
        //            case "现位置持续时长":
        //                m_frmRealtimeInWell.columnConfigs[i].isShow = Cbx_NowTime.Checked;
        //                break;
        //            case "进入现位置时刻":
        //                m_frmRealtimeInWell.columnConfigs[i].isShow = Cbx_InNowPlaceTime.Checked;
        //                break;
        //            case "方向性":
        //                m_frmRealtimeInWell.columnConfigs[i].isShow = Cbx_Direction.Checked;
        //                break;
        //        }
        //    }

        //    for (int i = 0; i < m_frmRealtimeInWell.tabpageConfigs.Length; i++)
        //    {
        //        switch (m_frmRealtimeInWell.tabpageConfigs[i].tabpageName)
        //        {
        //            case "部门":
        //                m_frmRealtimeInWell.tabpageConfigs[i].isShow = Cbx_Dept_Sum.Checked;
        //                break;
        //            case "工种":
        //                m_frmRealtimeInWell.tabpageConfigs[i].isShow=Cbx_WorkType_Sum.Checked  ;
        //                break;
        //            case "职务":
        //                m_frmRealtimeInWell.tabpageConfigs[i].isShow=Cbx_Duty_Sum.Checked;
        //                break;
        //            case "方向性":
        //                m_frmRealtimeInWell.tabpageConfigs[i].isShow=Cbx_Direction_Sum.Checked ;
        //                break;
        //            case "职务等级":
        //                m_frmRealtimeInWell.tabpageConfigs[i].isShow=Cbx_DutyRank_Sum.Checked ;
        //                break;
        //        }
        //    }

        //    try
        //    {
        //        File.Delete(m_frmRealtimeInWell.m_strPath);
        //    }
        //    catch
        //    { }
        //    try
        //    {
        //        m_frmRealtimeInWell.CreateRealTimeInWellShowConfig();
        //    }
        //    catch
        //    { }

        //    m_frmRealtimeInWell.BindTabPages();
        //    m_frmRealtimeInWell.BindDataGridViewColumn();
        //    //m_frmRealtimeInWell.BindData(1);
        //    this.Close();
        //}
        //#endregion

        
        //#endregion

        //#region 【系统事件方法】
        //#region 【事件方法：重置】
        //private void Btn__Click(object sender, EventArgs e)
        //{
        //    RealShowConfig();
        //}
        //#endregion

        //#region 【事件方法：关闭】
        //private void Btn_Return_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
        //#endregion

        //#region 【事件方法：保存】
        //private void Btn_Save_Click(object sender, EventArgs e)
        //{
        //    updateShowXml();
        //    //m_frmRealtimeInWell.ReadConfigXml();
        //    //m_frmRealtimeInWell.BindDataGridViewColumn();
        //    //m_frmRealtimeInWell.BindTabPages();
        //    //this.Close();
        //}
        //#endregion

        //#endregion
        #endregion
    }
}
