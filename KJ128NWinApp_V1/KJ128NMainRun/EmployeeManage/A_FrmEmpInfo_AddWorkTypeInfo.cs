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

namespace KJ128NMainRun.EmployeeManage
{
    public partial class A_FrmEmpInfo_AddWorkTypeInfo : Form
    {

        #region【声明】

        private A_DeptBLL dbll = new A_DeptBLL();

        /// <summary>
        /// 用于保存要修改的工种ID
        /// </summary>
        private int tempWork_ID;

        public bool blIsUpdate = false;

        private DataSet ds;

        private A_FrmEmpInfo frmEi;

        private string strUpdateName;

        private string strWorkTypeName;

        #endregion

        #region【构造函数】

        public A_FrmEmpInfo_AddWorkTypeInfo(A_FrmEmpInfo frm)
        {
            InitializeComponent();
            frmEi = frm;
            blIsUpdate = frm.blIsUpdate;
            tempWork_ID = frm.tempWork_ID;
            GetWorkTypeInfo_Add();
        }

        #endregion


        #region【方法：验证 工种信息】

        /// <summary>
        /// 验证工种信息
        /// </summary>
        /// <returns></returns>
        private bool CheckingWork()
        {
            string sqlString;
            #region 验证工种名称不能为空
            if (textBox_WtName.Text.Trim().Equals(""))
            {
                this.SetTipsInfo(lb_WorkTypeTipsInfo, false, "工种名称不能为空,请输入工种名称！");
                textBox_WtName.Focus();
                textBox_WtName.SelectAll();
                return false;
            }
            #endregion
            #region 验证工种名称的唯一性

            if (tempWork_ID == -1 ||(tempWork_ID!=-1 && !textBox_WtName.Text.Trim().Equals(strWorkTypeName)))
            {
                using (ds = dbll.GetNameWorkTypeInfoTable(textBox_WtName.Text.Trim()))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count != 0)
                        {
                            this.SetTipsInfo(lb_WorkTypeTipsInfo, false, "工种名称已存在,请重新输入工种名称！");
                            textBox_WtName.Focus();
                            textBox_WtName.SelectAll();
                            return false;
                        }
                    }
                }
            }
            #endregion
            #region 验证是否有证书信息
            if (comboBox_CerTypeName.DataSource == null)
            {
                this.SetTipsInfo(lb_WorkTypeTipsInfo, false, "未输入证书信息，请先增加证书信息！");
                return false;
            }
            #endregion
            #region 验证 最小工作时间、最大工作时间

            if (textBox_WorkMaxHour.Text == string.Empty)
            {
                this.SetTipsInfo(lb_WorkTypeTipsInfo, false, "请输入最大工作时间！");
                textBox_WorkMaxHour.Focus();
                textBox_WorkMaxHour.SelectAll();
                return false;
            }
            else if (textBox_WorkMaxMinute.Text == string.Empty)
            {
                this.SetTipsInfo(lb_WorkTypeTipsInfo, false, "请输入最大工作时间！");
                textBox_WorkMaxMinute.Focus();
                textBox_WorkMaxMinute.SelectAll();
                return false;
            }
            else if (textBox_WorkMaxSecond.Text == string.Empty)
            {
                this.SetTipsInfo(lb_WorkTypeTipsInfo, false, "请输入最大工作时间！");
                textBox_WorkMaxSecond.Focus();
                textBox_WorkMaxSecond.SelectAll();
                return false;
            }
            else if (textBox_WorkMinHour.Text == string.Empty)
            {
                this.SetTipsInfo(lb_WorkTypeTipsInfo, false, "请输入最小工作时间！");
                textBox_WorkMinHour.Focus();
                textBox_WorkMinHour.SelectAll();
                return false;
            }
            else if (textBox_WorkMinMinute.Text == string.Empty)
            {
                this.SetTipsInfo(lb_WorkTypeTipsInfo, false, "请输入最小工作时间！");
                textBox_WorkMinMinute.Focus();
                textBox_WorkMinMinute.SelectAll();
                return false;
            }
            else if (textBox_WorkMinSecond.Text == string.Empty)
            {
                this.SetTipsInfo(lb_WorkTypeTipsInfo, false, "请输入最小工作时间！");
                textBox_WorkMinSecond.Focus();
                textBox_WorkMinSecond.SelectAll();
                return false;
            }

            int intMax, intMin;
            intMax = Convert.ToInt32(textBox_WorkMaxHour.Text) * 3600 + Convert.ToInt32(textBox_WorkMaxMinute.Text) * 60 + Convert.ToInt32(textBox_WorkMaxSecond.Text);
            intMin = Convert.ToInt32(textBox_WorkMinHour.Text) * 3600 + Convert.ToInt32(textBox_WorkMinMinute.Text) * 60 + Convert.ToInt32(textBox_WorkMinSecond.Text);

            if (intMax < intMin)
            {
                this.SetTipsInfo(lb_WorkTypeTipsInfo, false, "最小工作时间不能大于最大工作时间！");
                textBox_WorkMinHour.Focus();
                textBox_WorkMinHour.SelectAll();
                return false;
            }

            if (intMax == 0)
            {
                this.SetTipsInfo(lb_WorkTypeTipsInfo, false, "最大工作时间不能为0！");
                textBox_WorkMaxHour.Focus();
                textBox_WorkMaxHour.SelectAll();
                return false;
            }

            #endregion
            return true;
        }

        #endregion

        #region 【方法: 增加工种信息 】

        /// <summary>
        /// 增加工种信息
        /// </summary>
        /// <returns></returns>
        private bool SaveWorkTypeInfo()
        {
            int intValue = 0;

            intValue = dbll.SaveWorkData(textBox_WtName.Text, dbll.GetCerID(comboBox_CerTypeName.Text), textBox_WorkRemark.Text,
                Convert.ToInt32(textBox_WorkMaxHour.Text), Convert.ToInt32(textBox_WorkMaxMinute.Text),
                Convert.ToInt32(textBox_WorkMaxSecond.Text), Convert.ToInt32(textBox_WorkMinHour.Text),
                Convert.ToInt32(textBox_WorkMinMinute.Text), Convert.ToInt32(textBox_WorkMinSecond.Text));
            if (intValue > 0)
            {
                //存入日志
                LogSave.Messages("[A_FrmEmpInfo]", LogIDType.UserLogID, "添加工种信息，工种名称：" + textBox_WtName.Text + "，证书名称：" + comboBox_CerTypeName.Text + "。");

                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 【方法: 修改工种信息 】

        /// <summary>
        /// 修改工种信息
        /// </summary>
        /// <returns></returns>
        private bool UpdateWorkTypeInfo()
        {
            int intValue = 0;

            intValue = dbll.UpDateWorkType(textBox_WtName.Text, dbll.GetCerID(comboBox_CerTypeName.Text), textBox_WorkRemark.Text,
                Convert.ToInt32(textBox_WorkMaxHour.Text), Convert.ToInt32(textBox_WorkMaxMinute.Text),
                Convert.ToInt32(textBox_WorkMaxSecond.Text), Convert.ToInt32(textBox_WorkMinHour.Text),
                Convert.ToInt32(textBox_WorkMinMinute.Text), Convert.ToInt32(textBox_WorkMinSecond.Text),tempWork_ID);
            if (intValue > 0)
            {
                strWorkTypeName = textBox_WtName.Text.Trim();
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region【方法：清空 工种信息】

        /// <summary>
        /// 清空工种信息
        /// </summary>
        private void ClearWork()
        {
            textBox_WtName.Text = "";
            InitComboBoxCerName();
            textBox_WorkMaxHour.Text = "10";
            textBox_WorkMaxMinute.Text = "0";
            textBox_WorkMaxSecond.Text = "0";
            textBox_WorkMinHour.Text = "0";
            textBox_WorkMinMinute.Text = "0";
            textBox_WorkMinSecond.Text = "0";
            textBox_WorkRemark.Text = "";
        }
        #endregion

        #region【方法：初始化证书名称】

        /// <summary>
        /// 初始化证书名称
        /// </summary>
        private void InitComboBoxCerName()
        {
            dbll.GetWorkCerCmb(comboBox_CerTypeName);
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

        #region【方法：验证分、秒不能大于60】

        private bool CheckTime_WorkType()
        {
            try
            {
                int iMinute = int.Parse(textBox_WorkMaxMinute.Text);
                int iSecond = int.Parse(textBox_WorkMaxSecond.Text);
                int i1 = int.Parse(textBox_WorkMinMinute.Text);
                int i2 = int.Parse(textBox_WorkMinSecond.Text);
                if (Check(iMinute) && Check(iSecond) && Check(i1) && Check(i2))
                {
                    return true;
                }
                else
                {
                    this.SetTipsInfo(lb_WorkTypeTipsInfo, false, "分和秒不能大于60且不能小于0！");
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private bool Check(int i)
        {
            if (i >= 0 && i <= 60)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region【方法：加载工种信息（新增）】

        private void GetWorkTypeInfo_Add()
        {
            ClearWork();
            lb_WorkTypeTipsInfo.Visible = false;        //隐藏提示信息

            if (tempWork_ID == -1)          //新增
            {
                this.Text = "新增工种信息";

                bt_WorkType_Save.Enabled = bt_WorkType_Reset.Enabled = gb_AddWorkTypeInfo.Enabled = true;
                label89.Visible =  true;
            }
            else                            
            {
                if (blIsUpdate)                 //修改
                {
                    this.Text = "修改工种信息";
                    textBox_WtName.Enabled = false;
                    bt_WorkType_Reset.Enabled = false;
                    bt_WorkType_Save.Enabled = gb_AddWorkTypeInfo.Enabled = true;
                    label89.Visible =  true;

                }
                else                            //查看
                {
                    this.Text = "查看工种信息";
                    bt_WorkType_Save.Enabled = bt_WorkType_Reset.Enabled = gb_AddWorkTypeInfo.Enabled = false;
                    label89.Visible = lb_WorkTypeTipsInfo.Visible = false;
                }
                BindingWorkType(tempWork_ID);             //绑定修改的工种信息
            }
        }

        #endregion

        #region【方法：绑定修改的工种信息】

        private void BindingWorkType(int intWorkTypeID)
        {
            using (ds = dbll.GetIDWorkTypeInfoTable(intWorkTypeID))
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        strUpdateName = dt.Rows[0]["工种"].ToString();
                        strWorkTypeName = dt.Rows[0]["工种"].ToString();
                        textBox_WtName.Text = dt.Rows[0]["工种"].ToString();
                        comboBox_CerTypeName.Text = dt.Rows[0]["证书"].ToString();

                        #region 计算最大工作时间
                        if (dt.Rows[0]["最大工作时间"].ToString().CompareTo("") == 0)
                        {
                            textBox_WorkMaxHour.Text = "";
                            textBox_WorkMaxMinute.Text = "";
                            textBox_WorkMaxSecond.Text = "";
                        }
                        else
                        {
                            int intMax = Convert.ToInt32(dt.Rows[0]["MaxTimeSec"]);
                            int hourMax = intMax / 3600;
                            int minuteMax = (intMax - hourMax * 3600) / 60;
                            int secondMax = intMax % 60;
                            textBox_WorkMaxHour.Text = hourMax.ToString();
                            textBox_WorkMaxMinute.Text = minuteMax.ToString();
                            textBox_WorkMaxSecond.Text = secondMax.ToString();
                        }
                        #endregion

                        #region 计算最小工作时间

                        if (dt.Rows[0]["最小工作时间"].ToString().CompareTo("") == 0)
                        {
                            textBox_WorkMinHour.Text = "";
                            textBox_WorkMinMinute.Text = "";
                            textBox_WorkMinSecond.Text = "";
                        }
                        else
                        {
                            int intMin = Convert.ToInt32(dt.Rows[0]["MinTimeSec"]);
                            int hourMin = intMin / 3600;
                            int minuteMin = (intMin - hourMin * 3600) / 60;
                            int secondMin = intMin % 60;
                            textBox_WorkMinHour.Text = hourMin.ToString();
                            textBox_WorkMinMinute.Text = minuteMin.ToString();
                            textBox_WorkMinSecond.Text = secondMin.ToString();
                        }
                        #endregion

                        textBox_WorkRemark.Text = dt.Rows[0]["备注"].ToString();
                    }
                }
            }


        }

        #endregion



        #region【事件：保存】

        private void bt_WorkType_Save_Click(object sender, EventArgs e)
        {
            if (CheckingWork())
            {
                if (!CheckTime_WorkType())
                {
                    return;
                }
                if (tempWork_ID == -1)         //新增
                {
                    if (SaveWorkTypeInfo())
                    {
                        SetTipsInfo(lb_WorkTypeTipsInfo, true, "保存成功！");

                        //Czlt-2011-12-10 更新时间
                        dbll.UpdateTime();

                        if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                        {
                            frmEi.Refresh_WorkType();
                        }
                        else                                //热备版，启用定时器
                        {
                            frmEi.HostBackRefresh(true);
                        }
                    }
                    else
                    {
                        SetTipsInfo(lb_WorkTypeTipsInfo, false, "保存失败！");
                    }
                }
                else                           //修改
                {
                    if (UpdateWorkTypeInfo())
                    {
                        SetTipsInfo(lb_WorkTypeTipsInfo, true, "修改成功！");

                        //Czlt-2011-12-10 更新时间
                        dbll.UpdateTime();

                        if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                        {
                            frmEi.Refresh_WorkType();
                        }
                        else                                //热备版，启用定时器
                        {
                            frmEi.HostBackRefresh(true);
                        }
                    }
                    else
                    {
                        SetTipsInfo(lb_WorkTypeTipsInfo, false, "修改失败！");
                    }
                }

            }
        }

        #endregion

        #region【事件：重置】

        private void bt_WorkType_Reset_Click(object sender, EventArgs e)
        {
            ClearWork();
        }

        #endregion

        #region【事件：返回】

        private void bt_WorkType_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void textBox_WtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_WorkRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

    }
}
