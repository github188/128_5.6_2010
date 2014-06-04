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
using KJ128NDataBase;

namespace KJ128NMainRun.AreaManage
{
    public partial class A_FrmAreaManage_AddTerInfo : Form
    {

        #region【声明】

        private A_AreaBLL areaBll = new A_AreaBLL();

        private bool blIsUpDate = false;

        private DataSet ds;

        private int tempTerritorialID = -1;

        private A_FrmAreaManage frmAm;

        private string strTerName = "";

        #endregion

        #region【构造函数】

        public A_FrmAreaManage_AddTerInfo(A_FrmAreaManage frm)
        {
            InitializeComponent();
            frmAm = frm;
            tempTerritorialID = frm.tempTerritorialID;

            blIsUpDate = frm.blIsUpDate;
            GetTer_Add();
        }

        #endregion


        #region【方法：验证 区域信息】

        private bool CheckingTerInfo()
        {

            if (textBox_TerInfoName.Text.CompareTo("") == 0)
            {
                SetTipsInfo(lb_TerTipsInfo, false, "区域名称不能为空,请输入区域名称!");
                textBox_TerInfoName.Focus();
                textBox_TerInfoName.SelectAll();
                return false;
            }

            if (txtNO.Text.Trim().Length == 0)
            {
                SetTipsInfo(lb_TerTipsInfo, false, "区域编号不能为空,请输入区域编号!");
                txtNO.Focus();
                txtNO.SelectAll();
                return false;
            }
            if (tempTerritorialID == -1)
            {
                if (areaBll.IsExistsTNO(txtNO.Text.Trim()))
                {
                    SetTipsInfo(lb_TerTipsInfo, false, "区域编号已存在!");
                    txtNO.Focus();
                    txtNO.SelectAll();
                    return false;
                }
            }

            #region 验证 区域名称不重复

            if (tempTerritorialID == -1 || (tempTerritorialID != -1 && !textBox_TerInfoName.Text.Trim().Equals(strTerName)))
            {
                using (DataSet ds = areaBll.GetTreInfoTable(textBox_TerInfoName.Text.ToString()))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            SetTipsInfo(lb_TerTipsInfo, false, "区域名称已存在,请重新输入区域名称！");
                            textBox_TerInfoName.Focus();
                            textBox_TerInfoName.SelectAll();
                            return false;
                        }
                    }
                }
            }
            #endregion

            if (cb_TerEmpCounts.Checked)
            {
                if (txt_TerMaxEmpCounts.Text.Trim() == "")
                {
                    SetTipsInfo(lb_TerTipsInfo, false, "请输入区域额定工作人数！");
                    txt_TerMaxEmpCounts.Focus();
                    txt_TerMaxEmpCounts.SelectAll();
                    return false;
                }
            }
            if (cb_TerWorkTime.Checked)
            {
                if (textBox_Ter_MaxHour.Text.Trim() == "" )
                {
                    SetTipsInfo(lb_TerTipsInfo, false, "最大工作时间不能为空！");
                    textBox_Ter_MaxHour.Focus();
                    textBox_Ter_MaxHour.SelectAll();
                    return false;
                }
                if (textBox_Ter_MaxMinute.Text.Trim() == "")
                {
                    SetTipsInfo(lb_TerTipsInfo, false, "最大工作时间不能为空！");
                    textBox_Ter_MaxMinute.Focus();
                    textBox_Ter_MaxMinute.SelectAll();
                    return false;
                }
                if (textBox_Ter_MaxSecond.Text.Trim() == "")
                {
                    SetTipsInfo(lb_TerTipsInfo, false, "最大工作时间不能为空！");
                    textBox_Ter_MaxSecond.Focus();
                    textBox_Ter_MaxSecond.SelectAll();
                    return false;
                }
                if (Convert.ToInt32(textBox_Ter_MaxMinute.Text.Trim()) > 59)
                {
                    SetTipsInfo(lb_TerTipsInfo, false, "分钟不能大于59，请重新填写！");
                    textBox_Ter_MaxMinute.Focus();
                    textBox_Ter_MaxMinute.SelectAll();
                    return false;
                }
                if (Convert.ToInt32(textBox_Ter_MaxSecond.Text.Trim()) > 59)
                {
                    SetTipsInfo(lb_TerTipsInfo, false, "秒不能大于59，请重新填写！");
                    textBox_Ter_MaxSecond.Focus();
                    textBox_Ter_MaxSecond.SelectAll();
                    return false;
                }
            }
      
            return true;
        }

        #endregion

        #region【方法：添加 区域信息】

        private bool SaveTer()
        {
            int intImpactCounts = 0;
            int intTerEmpCounts = -1;
            int intTerWorkTime = -1;

            if (!txt_TerMaxEmpCounts.Text.Trim().Equals(""))
            {
                intTerEmpCounts = Convert.ToInt32(txt_TerMaxEmpCounts.Text.Trim());
            }
            if (!textBox_Ter_MaxHour.Text.Trim().Equals("") && !textBox_Ter_MaxMinute.Text.Trim().Equals("") && !textBox_Ter_MaxSecond.Text.Trim().Equals(""))
            {
                intTerWorkTime = Convert.ToInt32(textBox_Ter_MaxHour.Text.Trim()) * 3600 + Convert.ToInt32(textBox_Ter_MaxMinute.Text.Trim()) * 60 +
                Convert.ToInt32(textBox_Ter_MaxSecond.Text.Trim());
            }

            intImpactCounts = areaBll.SaveTer(textBox_TerInfoName.Text.Trim(), Convert.ToInt32(comBox_TerInfoType.SelectedValue),
                intTerEmpCounts, intTerWorkTime, textBox_TerInfoRemark.Text.Trim(), txtNO.Text);

            if (intImpactCounts > 0)
            {
                //存入日志
                LogSave.Messages("[A_FrmAreaManage]", LogIDType.UserLogID, "添加区域信息，区域名称：" + textBox_TerInfoName.Text + "，区域类别：" + comBox_TerInfoType.SelectedText + "。");
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region【方法：修改 区域信息】

        private bool UpDateTer()
        {
            int intImpactCounts = 0;

            int intTerEmpCounts = -1;
            int intTerWorkTime = -1;

            if (!txt_TerMaxEmpCounts.Text.Trim().Equals(""))
            {
                intTerEmpCounts = Convert.ToInt32(txt_TerMaxEmpCounts.Text.Trim());
            }
            if (!textBox_Ter_MaxHour.Text.Trim().Equals("") && !textBox_Ter_MaxMinute.Text.Trim().Equals("") && !textBox_Ter_MaxSecond.Text.Trim().Equals(""))
            {
                intTerWorkTime = Convert.ToInt32(textBox_Ter_MaxHour.Text.Trim()) * 3600 + Convert.ToInt32(textBox_Ter_MaxMinute.Text.Trim()) * 60 +
                Convert.ToInt32(textBox_Ter_MaxSecond.Text.Trim());
            }

            intImpactCounts = areaBll.UpDateTer(textBox_TerInfoName.Text.Trim(), Convert.ToInt32(comBox_TerInfoType.SelectedValue),
                intTerEmpCounts, intTerWorkTime, textBox_TerInfoRemark.Text.Trim(),tempTerritorialID,txtNO.Text.Trim());
            if (intImpactCounts > 0)
            {
                strTerName = textBox_TerInfoName.Text.Trim();
                //存入日志
                LogSave.Messages("[A_FrmAreaManage]", LogIDType.UserLogID, "修改区域信息，区域名称：" + textBox_TerInfoName.Text + "，区域类别：" + comBox_TerInfoType.SelectedText + "。");
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region【方法：绑定修改的区域信息】

        private void BindingTer(int intID)
        {
            using (ds = areaBll.GetTer_Binding(intID))
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        textBox_TerInfoName.Text = dt.Rows[0]["TerritorialName"].ToString();
                        strTerName = dt.Rows[0]["TerritorialName"].ToString();
                        txtNO.Text = dt.Rows[0]["TerritorialNO"].ToString();

                        comBox_TerInfoType.SelectedValue = Convert.ToInt32(dt.Rows[0]["TerritorialTypeID"].ToString());
                        textBox_TerInfoRemark.Text = dt.Rows[0]["Remark"].ToString();
                        if (dt.Rows[0]["TerEmpCount"].ToString().Equals("") || dt.Rows[0]["TerEmpCount"].ToString().Equals("-1"))
                        {
                            txt_TerMaxEmpCounts.Text = "";
                            cb_TerEmpCounts.Checked = false;
                        }
                        else
                        {
                            txt_TerMaxEmpCounts.Text = dt.Rows[0]["TerEmpCount"].ToString();
                            cb_TerEmpCounts.Checked = true;
                        }
                        if (dt.Rows[0]["TerWorkTime"].ToString().Equals("") || dt.Rows[0]["TerWorkTime"].ToString().Equals("-1"))
                        {
                            cb_TerWorkTime.Checked = false;
                            textBox_Ter_MaxHour.Text = "";
                            textBox_Ter_MaxMinute.Text = "";
                            textBox_Ter_MaxSecond.Text = "";
                        }
                        else
                        {
                            int intMax = Convert.ToInt32(dt.Rows[0]["TerWorkTime"].ToString());
                            int hourMax = intMax / 3600;
                            int minuteMax = (intMax - hourMax * 3600) / 60;
                            int secondMax = intMax % 60;
                            textBox_Ter_MaxHour.Text = hourMax.ToString();
                            textBox_Ter_MaxMinute.Text = minuteMax.ToString();
                            textBox_Ter_MaxSecond.Text = secondMax.ToString();
                            cb_TerWorkTime.Checked = true;
                        }
                    }
                }
            }


        }

        #endregion

        #region【方法：加载添加区域信息（新增）】

        /// <summary>
        /// 加载添加区域信息（新增）
        /// </summary>
        private void GetTer_Add()
        {
            Empty_Ter();                    //清空区域类型

            if (tempTerritorialID == -1)    //新增
            {
                this.Text = "新增区域信息";
                textBox_TerInfoName.Enabled = true;

                gb_AddTerInfo.Enabled = bt_Ter_Save.Enabled = bt_Ter_Reset.Enabled = true;
                lb_TerTipsInfo2.Visible =  true;
                lb_TerTipsInfo.Visible = false;
            }
            else
            {
                if (blIsUpDate)         //修改
                {
                    this.Text = "修改区域信息";
                    textBox_TerInfoName.Enabled = false;

                    gb_AddTerInfo.Enabled = bt_Ter_Save.Enabled = true;
                    bt_Ter_Reset.Enabled = false;
                    lb_TerTipsInfo2.Visible = true;
                    lb_TerTipsInfo.Visible = false;
                    txtNO.Enabled = false;
                }
                else                            //查看
                {
                    this.Text = "查看区域信息";

                    gb_AddTerInfo.Enabled = bt_Ter_Save.Enabled = false;
                    bt_Ter_Reset.Enabled = false;
                    lb_TerTipsInfo2.Visible = lb_TerTipsInfo.Visible = false;
                    txtNO.Enabled = false;
                }
                BindingTer(tempTerritorialID);
            }
        }

        #endregion

        #region【方法：清空——区域类型】

        private void Empty_Ter()
        {
            areaBll.GetTerTypeCmb2(comBox_TerInfoType);

            textBox_TerInfoName.Text = txt_TerMaxEmpCounts.Text = textBox_Ter_MaxHour.Text = textBox_Ter_MaxMinute.Text = textBox_Ter_MaxSecond.Text = textBox_TerInfoRemark.Text = txtNO.Text = "";

        }

        #endregion

        #region 【方法：设置提示信息】

        private void SetTipsInfo(Label lb, bool blIsSuccess, string strInfo)
        {
            lb.Text = strInfo;
            lb.Visible = true;
            if (blIsSuccess)
            {
                lb.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                lb.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion



        #region【事件：保存】

        private void bt_Ter_Save_Click(object sender, EventArgs e)
        {
            if (CheckingTerInfo())
            {
                if (tempTerritorialID == -1)            //新增
                {
                    if (SaveTer())      //成功                      
                    {
                        SetTipsInfo(lb_TerTipsInfo, true, "保存成功！");

                        //Czlt-2011-12-10 跟新时间
                        areaBll.UpdateTime();


                        if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                        {
                            frmAm.Refresh_Ter();
                        }
                        else                                //热备版，启用定时器
                        {
                            frmAm.HostBackRefresh(true);
                        }
                    }
                    else                //失败
                    {
                        SetTipsInfo(lb_TerTipsInfo, false, "保存失败！");
                    }
                }
                else                                    //修改
                {
                    if (UpDateTer())    //成功
                    {
                        SetTipsInfo(lb_TerTipsInfo, true, "修改成功！");

                        //Czlt-2011-12-10 跟新时间
                        areaBll.UpdateTime();


                        if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                        {
                            frmAm.Refresh_Ter();
                        }
                        else                                //热备版，启用定时器
                        {
                            frmAm.HostBackRefresh(true);
                        }
                    }
                    else                //失败
                    {
                        SetTipsInfo(lb_TerTipsInfo, false, "修改失败！");
                    }
                }

            }
        }

        #endregion

        #region【事件：重置】

        private void bt_Ter_Reset_Click(object sender, EventArgs e)
        {
            Empty_Ter();
        }

        #endregion

        #region【事件：返回】

        private void bt_Ter_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region【事件：是否启用区域额定人数】

        private void cb_TerEmpCounts_CheckedChanged(object sender, EventArgs e)
        {
            txt_TerMaxEmpCounts.Enabled = cb_TerEmpCounts.Checked;
            if (!cb_TerEmpCounts.Checked)
            {
                txt_TerMaxEmpCounts.Text = "";
            }
        }

        #endregion

        #region【事件：是否启用区域额定工作时间】

        private void cb_TerWorkTime_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Ter_MaxHour.Enabled = textBox_Ter_MaxMinute.Enabled = textBox_Ter_MaxSecond.Enabled = cb_TerWorkTime.Checked;
            if (!cb_TerWorkTime.Checked)
            {
                textBox_Ter_MaxHour.Text = textBox_Ter_MaxMinute.Text = textBox_Ter_MaxSecond.Text = "";
            }
        }

        #endregion

        private void textBox_TerInfoName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_TerInfoRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }



    }
}
