using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using Shine.Logs;
using Shine.Logs.LogType;

namespace KJ128NMainRun.A_Speed
{
    public partial class A_FrmWalkConfig_Add : Form
    {
        #region【声明】

        private A_WalkConfigBLL wcbll = new A_WalkConfigBLL();

        private int intOverSpeedID = -1;

        private A_FrmWalkConfig frmwc;

        private DataSet ds;

        #endregion

        #region【构造函数——新增】

        public A_FrmWalkConfig_Add(A_FrmWalkConfig frm)
        {
            InitializeComponent();

            frmwc = frm;
            InitWalkConfig();
        }

        #endregion

        #region【构造函数——修改、查看】

        public A_FrmWalkConfig_Add(A_FrmWalkConfig frm,int intID,bool blIsUpDate)
        {
            InitializeComponent();

            frmwc = frm;
            intOverSpeedID = intID;

            BindingWalkConfig(intOverSpeedID);

            if (blIsUpDate)                 //修改
            {
                gb_First.Enabled = false;
                gb_Last.Enabled = false;
                bt_Reset.Enabled = false;
                this.Text = "修改行走异常配置信息";
            }
            else                            //查看
            {
                gb_WalkInfo.Enabled = false;
                bt_Save.Enabled = bt_Reset.Enabled = false;
                this.Text = "查看行走异常配置信息";
            }
        }

        #endregion

        #region【方法：验证超速配置信息】

        private bool CheckingOverSpeedInfo()
        {
            if (cmb_FirstStation.SelectedValue == null || cmb_FirstStation.SelectedValue.ToString().Equals("无"))
            {
                SetTipsInfo(false, "请选择起始传输分站！");
                cmb_FirstStation.Focus();
                return false;
            }
            if (cmb_FirstStaHead.SelectedValue == null || cmb_FirstStaHead.SelectedValue.ToString().Equals("无"))
            {
                SetTipsInfo(false, "请选择起始读卡分站！");
                cmb_FirstStaHead.Focus();
                return false;
            }
            if (cmb_LastStation.SelectedValue == null || cmb_LastStation.SelectedValue.ToString().Equals("无"))
            {
                SetTipsInfo(false, "请选择终点传输分站！");
                cmb_LastStation.Focus();
                return false;
            }
            if (cmb_LastStaHead.SelectedValue == null || cmb_LastStaHead.SelectedValue.ToString().Equals("无"))
            {
                SetTipsInfo(false, "请选择终点读卡分站！");
                cmb_LastStaHead.Focus();
                return false;
            }
            if (cmb_FirstStation.SelectedValue.ToString().Equals(cmb_LastStation.SelectedValue.ToString()) && cmb_FirstStaHead.SelectedValue.ToString().Equals(cmb_LastStaHead.SelectedValue.ToString()))
            {
                SetTipsInfo(false, "起始测点和终点测点不能相同，请重新选择！");
                cmb_LastStation.Focus();
                return false;
            }
            if (intOverSpeedID == -1)       //新增
            {
                using (ds = new DataSet())
                {
                    ds = wcbll.CheckingOverSpeed(cmb_FirstStation.SelectedValue.ToString(), cmb_FirstStaHead.Text.ToString(),
                         cmb_LastStation.SelectedValue.ToString(), cmb_LastStaHead.Text.ToString());
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            SetTipsInfo(false, "系统中已存在该起始测点和终点测点！");
                            cmb_LastStation.Focus();
                            return false;
                        }
                    }
                }
            }

            if (!cb_Over.Checked && !cb_Lack.Checked)
            {
                SetTipsInfo(false, "至少设置一个超速或欠速的额定行走时间！");
                return false;
            }


            #region【验证时间格式】

            if (cb_Over.Checked)
            {
                if (txt_OverHour.Text.Equals(""))
                {
                    SetTipsInfo(false, "额定行走时间(超速)不能为空！");
                    txt_OverHour.Focus();
                    txt_OverHour.SelectAll();
                    return false;
                }
                if (txt_OverMinute.Text.Equals(""))
                {
                    SetTipsInfo(false, "额定行走时间(超速)不能为空！");
                    txt_OverMinute.Focus();
                    txt_OverMinute.SelectAll();
                    return false;
                }
                if (txt_OverSecond.Text.Equals(""))
                {
                    SetTipsInfo(false, "额定行走时间(超速)不能为空！");
                    txt_OverSecond.Focus();
                    txt_OverSecond.SelectAll();
                    return false;
                }

                if (Convert.ToInt32(txt_OverMinute.Text.Trim()) >= 60)
                {
                    SetTipsInfo(false, "分钟不能大于等于60！");
                    txt_OverMinute.Focus();
                    txt_OverMinute.SelectAll();
                    return false;
                }

                if (Convert.ToInt32(txt_OverSecond.Text.Trim()) >= 60)
                {
                    SetTipsInfo(false, "秒不能大于等于60！");
                    txt_OverSecond.Focus();
                    txt_OverSecond.SelectAll();
                    return false;
                }
            }
            if (cb_Lack.Checked)
            {
                if (txt_LackHour.Text.Equals(""))
                {
                    SetTipsInfo(false, "额定行走时间(欠速)不能为空！");
                    txt_LackHour.Focus();
                    txt_LackHour.SelectAll();
                    return false;
                }
                if (txt_LackMinute.Text.Equals(""))
                {
                    SetTipsInfo(false, "额定行走时间(欠速)不能为空！");
                    txt_LackMinute.Focus();
                    txt_LackMinute.SelectAll();
                    return false;
                }
                if (txt_LackSecond.Text.Equals(""))
                {
                    SetTipsInfo(false, "额定行走时间(欠速)不能为空！");
                    txt_LackSecond.Focus();
                    txt_LackSecond.SelectAll();
                    return false;
                }

                if (Convert.ToInt32(txt_LackMinute.Text.Trim()) >= 60)
                {
                    SetTipsInfo(false, "分钟不能大于等于60！");
                    txt_LackMinute.Focus();
                    txt_LackMinute.SelectAll();
                    return false;
                }

                if (Convert.ToInt32(txt_LackSecond.Text.Trim()) >= 60)
                {
                    SetTipsInfo(false, "秒不能大于等于60！");
                    txt_LackSecond.Focus();
                    txt_LackSecond.SelectAll();
                    return false;
                }
            }

            if (cb_Over.Checked && cb_Lack.Checked)
            {
                int intOver, intLack;
                intOver = Convert.ToInt32(txt_OverHour.Text.Trim()) * 3600 + Convert.ToInt32(txt_OverMinute.Text.Trim()) * 60 + Convert.ToInt32(txt_OverSecond.Text.Trim());
                intLack = Convert.ToInt32(txt_LackHour.Text.Trim()) * 3600 + Convert.ToInt32(txt_LackMinute.Text.Trim()) * 60 + Convert.ToInt32(txt_LackSecond.Text.Trim());

                if (intOver > intLack)
                {
                    SetTipsInfo(false, "额定行走时间（超速）不能大于额定行走时间（欠速）！");
                    txt_OverHour.Focus();
                    txt_OverHour.SelectAll();
                    return false;
                }
            }

            #endregion


            return true;
        }

        #endregion

        #region【方法：绑定数据】

        private void BindingWalkConfig(int intID)
        {
            DataSet dsBing;
            using (dsBing = new DataSet())
            {
                dsBing = wcbll.SelectWalkConfig_Binding(intOverSpeedID);
                if (dsBing != null && dsBing.Tables.Count > 0 && dsBing.Tables[0].Rows.Count > 0)
                {
                    #region【绑定数据】

                    wcbll.LoadInfo(cmb_FirstStation, cmb_FirstStaHead, false);
                    cmb_FirstStation.SelectedValue = dsBing.Tables[0].Rows[0]["FirstStationAddress"].ToString();

                    wcbll.LoadInfo(cmb_FirstStation, cmb_FirstStaHead, true);
                    cmb_FirstStaHead.Text = dsBing.Tables[0].Rows[0]["FirstStationHeadAddress"].ToString();
                    txt_FirstStationHeadPlace.Text = cmb_FirstStaHead.SelectedValue.ToString();

                    wcbll.LoadInfo(cmb_LastStation, cmb_LastStaHead, false);
                    cmb_LastStation.SelectedValue = dsBing.Tables[0].Rows[0]["LastStationAddress"].ToString();
                    wcbll.LoadInfo(cmb_LastStation, cmb_LastStaHead, true);
                    cmb_LastStaHead.Text = dsBing.Tables[0].Rows[0]["LastStationHeadAddress"].ToString();
                    txt_LastStationHeadPlace.Text = cmb_LastStaHead.SelectedValue.ToString();


                    #region【超速】

                    if (dsBing.Tables[0].Rows[0]["WalkTime"].ToString() != "" && dsBing.Tables[0].Rows[0]["WalkTime"].ToString() != "-1")
                    {
                        int intOver, intOverHour, intOverMinute, intOverSecond;
                        intOver = Convert.ToInt32(dsBing.Tables[0].Rows[0]["WalkTime"].ToString());
                        cb_Over.Checked = true;
                        intOverHour = intOver / 3600;
                        intOverMinute = (intOver - intOverHour * 3600) / 60;
                        intOverSecond = intOver % 60;

                        txt_OverHour.Text = intOverHour.ToString();
                        txt_OverMinute.Text = intOverMinute.ToString();
                        txt_OverSecond.Text = intOverSecond.ToString();
                    }
                    else
                    {
                        cb_Over.Checked = false;
                    }
                    #endregion

                    #region【欠速】

                    if (dsBing.Tables[0].Rows[0]["LackWalkTime"].ToString() != "" && dsBing.Tables[0].Rows[0]["LackWalkTime"].ToString()!="-1")
                    {
                        int intLack, intLackHour, intLackMinute, intLackSecond;
                        intLack = Convert.ToInt32(dsBing.Tables[0].Rows[0]["LackWalkTime"].ToString());
                        cb_Lack.Checked = true;
                        intLackHour = intLack / 3600;
                        intLackMinute = (intLack - intLackHour * 3600) / 60;
                        intLackSecond = intLack % 60;

                        txt_LackHour.Text = intLackHour.ToString();
                        txt_LackMinute.Text = intLackMinute.ToString();
                        txt_LackSecond.Text = intLackSecond.ToString();
                    }
                    else
                    {
                        cb_Lack.Checked = false;
                    }
                    #endregion

                    txt_Remark.Text = dsBing.Tables[0].Rows[0]["Remark"].ToString();

                    #endregion
                }
            }
        }

        #endregion

        #region 【方法：设置提示信息】

        private void SetTipsInfo(bool blIsSuccess, string strInfo)
        {
            lb_TipsInfo.Text = strInfo;
            if (blIsSuccess)
            {
                lb_TipsInfo.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                lb_TipsInfo.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion

        #region【方法：初始化行走异常配置信息】

        private void InitWalkConfig()
        {
            #region【加载起始测点】

            wcbll.LoadInfo(cmb_FirstStation, cmb_FirstStaHead, false);

            #endregion

            #region【加载最后一个测点】

            wcbll.LoadInfo(cmb_LastStation, cmb_LastStaHead, false);

            #endregion

            txt_OverHour.Text = "1";
            txt_LackHour.Text = "2";
            txt_OverMinute.Text = txt_OverSecond.Text = txt_LackMinute.Text = txt_LackSecond.Text = "0";
            txt_Remark.Text = "";
            cb_Lack.Checked = cb_Over.Checked = true;
        }

        #endregion

        #region【方法：启用超速】

        private void IsEnableOver(bool bl)
        {
            if (bl)
            {
                txt_OverHour.Enabled = txt_OverMinute.Enabled = txt_OverSecond.Enabled = true;
            }
            else
            {
                txt_OverHour.Text = txt_OverMinute.Text = txt_OverSecond.Text = "";
                txt_OverHour.Enabled = txt_OverMinute.Enabled = txt_OverSecond.Enabled = false;
            }

        }

        #endregion

        #region【方法：启用欠速】

        private void IsEnableLack(bool bl)
        {
            if (bl)
            {
                txt_LackHour.Enabled = txt_LackMinute.Enabled = txt_LackSecond.Enabled = true;
            }
            else
            {
                txt_LackHour.Text = txt_LackMinute.Text = txt_LackSecond.Text = "";
                txt_LackHour.Enabled = txt_LackMinute.Enabled = txt_LackSecond.Enabled = false;
            }

        }

        #endregion


        #region【事件：选择起始分站】

        //传输分站
        private void cmb_FirstStation_DropDownClosed(object sender, EventArgs e)
        {
            wcbll.LoadInfo(cmb_FirstStation, cmb_FirstStaHead, true);
        }

        //读卡分站
        private void cmb_FirstStaHead_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_FirstStaHead.SelectedIndex > 0)
            {
                txt_FirstStationHeadPlace.Text = cmb_FirstStaHead.SelectedValue.ToString();
            }
            else if (cmb_FirstStaHead.SelectedIndex == 0)
            {
                txt_FirstStationHeadPlace.Text = "";
            }
        }

        private void cmb_FirstStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_FirstStation.SelectedIndex == 0)
            {
                txt_FirstStationHeadPlace.Text = "";
            }
        }

        #endregion

        #region【事件：选择终点分站】

        private void cmb_LastStation_DropDownClosed(object sender, EventArgs e)
        {
            wcbll.LoadInfo(cmb_LastStation, cmb_LastStaHead, true);
        }

        private void cmb_LastStaHead_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_LastStaHead.SelectedIndex > 0)
            {
                txt_LastStationHeadPlace.Text = cmb_LastStaHead.SelectedValue.ToString();
            }
            else if (cmb_LastStaHead.SelectedIndex == 0)
            {
                txt_LastStationHeadPlace.Text = "";
            }
        }

        private void cmb_LastStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_LastStation.SelectedIndex == 0)
            {
                txt_LastStationHeadPlace.Text = "";
            }
        }

        #endregion

        #region【事件：保存】

        private void bt_Save_Click(object sender, EventArgs e)
        {
            lb_TipsInfo.Visible = true;

            int intImpactCounts = 0;    //影响行数

            if (CheckingOverSpeedInfo())        //验证
            {
                int intWalkTime = -1;
                int intLackWalkTime = -1;
                if (cb_Over.Checked)
                {
                    intWalkTime = Convert.ToInt32(txt_OverHour.Text.Trim()) * 3600 + Convert.ToInt32(txt_OverMinute.Text.Trim()) * 60 + Convert.ToInt32(txt_OverSecond.Text.Trim());
                }
                if (cb_Lack.Checked)
                {
                    intLackWalkTime = Convert.ToInt32(txt_LackHour.Text.Trim()) * 3600 + Convert.ToInt32(txt_LackMinute.Text.Trim()) * 60 + Convert.ToInt32(txt_LackSecond.Text.Trim());
                }

                intImpactCounts = wcbll.WalkConfig_InsertAndUpDate(Convert.ToInt32(cmb_FirstStation.SelectedValue), Convert.ToInt32(cmb_FirstStaHead.Text),
                    Convert.ToInt32(cmb_LastStation.SelectedValue), Convert.ToInt32(cmb_LastStaHead.Text), intWalkTime, txt_Remark.Text.Trim(), intLackWalkTime);

                if (intImpactCounts > 0)        //保存成功
                {
                    frmwc.HostBackRefresh();        //刷新

                    #region【存入日志】

                    if (intOverSpeedID == -1)       //新增
                    {
                        LogSave.Messages("[A_FrmWalkConfig_Add]", LogIDType.UserLogID, "新增超速配置信息，起始测点为：" + cmb_FirstStation.SelectedValue.ToString() +
                            " 号传输分站的 " + cmb_FirstStaHead.SelectedValue.ToString() + " 号读卡分站，终止测点为：" + cmb_LastStation.SelectedValue.ToString() +
                            " 号传输分站的 " + cmb_LastStaHead.SelectedValue.ToString() + " 号读卡分站。");
                    }
                    else                            //修改
                    {
                        LogSave.Messages("[A_FrmWalkConfig_Add]", LogIDType.UserLogID, "修改超速配置信息，起始测点为：" + cmb_FirstStation.SelectedValue.ToString() +
                            " 号传输分站的 " + cmb_FirstStaHead.SelectedValue.ToString() + " 号读卡分站，终止测点为：" + cmb_LastStation.SelectedValue.ToString() +
                            " 号传输分站的 " + cmb_LastStaHead.SelectedValue.ToString() + " 号读卡分站。");
                    }

                    #endregion

                    SetTipsInfo(true, "保存成功！");
                }
                else                            //保存失败
                {
                    SetTipsInfo(false, "保存失败！");
                }
            }
        }

        #endregion

        #region【事件：重置】

        private void bt_Reset_Click(object sender, EventArgs e)
        {
            InitWalkConfig();
        }

        #endregion

        #region【事件：返回】

        private void bt_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region【事件：是否启用超速】

        private void cb_Over_CheckedChanged(object sender, EventArgs e)
        {
            IsEnableOver(cb_Over.Checked);
        }

        #endregion

        #region【事件：是否启用欠速】

        private void cb_Lack_CheckedChanged(object sender, EventArgs e)
        {
            IsEnableLack(cb_Lack.Checked);
        }

        #endregion

        private void txt_FirstStationHeadPlace_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
    }
}
