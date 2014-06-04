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
    public partial class A_FrmEmpInfo_AddDutyInfo : Form
    {

        #region【声明】

        private A_DeptBLL dbll = new A_DeptBLL();

        /// <summary>
        /// 用于保存要修改的职务ID
        /// </summary>
        public int tempDuty_ID;

        public bool blIsUpdate = false;

        private DataSet ds;

        private A_FrmEmpInfo frmEi;

        private string strDutyName = "";

        #endregion

        #region【构造函数】

        public A_FrmEmpInfo_AddDutyInfo(A_FrmEmpInfo frm)
        {
            InitializeComponent();
            frmEi = frm;
            tempDuty_ID = frm.tempDuty_ID;
            blIsUpdate = frm.blIsUpdate;

            GetDutyInfo_Add();
        }

        #endregion

        #region【方法：验证职务信息】

        /// <summary>
        /// 验证职务信息
        /// </summary>
        /// <returns></returns>
        private bool CheckingDutyInfo()
        {
            #region 验证职务名称不能为空
            if (textBox_DutyName.Text.Trim().Equals(""))
            {
                this.SetTipsInfo(lb_DutyTipsInfo, false, "请输入职务名称！");
                textBox_DutyName.Focus();
                textBox_DutyName.SelectAll();

                return false;
            }
            #endregion

            #region 验证职务名称的唯一性
            if (tempDuty_ID == -1 || (tempDuty_ID != -1 && !textBox_DutyName.Text.Trim().Equals(strDutyName)))
            {
                using (ds = dbll.GetDutyInfoTable(textBox_DutyName.Text.Trim()))
                {
                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count != 0)
                        {
                            this.SetTipsInfo(lb_DutyTipsInfo, false, "职务名称已存在,请重新输入职务名称！");
                            textBox_DutyName.Focus();
                            textBox_DutyName.SelectAll();
                            return false;
                        }
                    }
                }
            }

            #endregion

            return true;
        }
        #endregion

        #region 【方法：添加 职务信息】

        /// <summary>
        /// 添加 职务信息
        /// </summary>
        private bool SaveSetDuty()
        {
            int intImpactCounts = 0;

            intImpactCounts = dbll.SaveDutyInfoData(textBox_DutyName.Text.Trim(), comboBox_DutyClass.SelectedIndex + 1, textBox_DutyRemark.Text.ToString());

            if (intImpactCounts > 0)
            {
                //存入日志
                LogSave.Messages("[A_FrmEmpInfo]", LogIDType.UserLogID, "添加职务信息，职务名称：" + textBox_DutyName.Text + "。");
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region【方法：修改 职务信息】

        /// <summary>
        /// 修改 职务信息
        /// </summary>
        private bool UpDateDuty()
        {
            int intImpactCounts = 0;

            intImpactCounts = dbll.UpDateDutyInfo(tempDuty_ID, textBox_DutyName.Text.ToString(), comboBox_DutyClass.SelectedIndex + 1, textBox_DutyRemark.Text.ToString());

            if (intImpactCounts > 0)
            {
                strDutyName = textBox_DutyName.Text.Trim();
                //存入日志
                LogSave.Messages("[A_FrmEmpInfo]", LogIDType.UserLogID, "修改职务信息，职务名称：" + textBox_DutyName.Text + "。");
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion


        #region 【方法：清空 增加职务信息】

        /// <summary>
        /// 清空 增加职务信息
        /// </summary>
        private void ClearDutyInfo()
        {
            textBox_DutyName.Text = "";
            textBox_DutyRemark.Text = "";
            comboBox_DutyClass.SelectedIndex = 0;
        }

        #endregion


        #region【方法：绑定修改的职务信息】

        private void BindingDuty(int intDutyID)
        {
            using (ds = dbll.GetIDDutyInfoTable(intDutyID))
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        textBox_DutyName.Text = dt.Rows[0]["名称"].ToString();
                        comboBox_DutyClass.Text = dt.Rows[0]["等级"].ToString();
                        textBox_DutyRemark.Text = dt.Rows[0]["备注"].ToString();
                        strDutyName = textBox_DutyName.Text.Trim();
                    }
                }
            }
        }

        #endregion


        #region【方法：加载职务信息（新增）】

        private void GetDutyInfo_Add()
        {
            InitComboBoxDutyClass();                //绑定职务等级
            ClearDutyInfo();                           //初始化信息

            lb_DutyTipsInfo.Visible = false;        //隐藏提示信息

            if (tempDuty_ID == -1)          //新增
            {
                this.Text = "新增职务信息";

                bt_Duty_Save.Enabled = bt_Duty_Reset.Enabled = gb_AddDutyInfo.Enabled = true;
                label88.Visible = true;
            }
            else                            
            {
                if (blIsUpdate)                 //修改
                {
                    this.Text = "修改职务信息";
                    textBox_DutyName.Enabled = false;
                    bt_Duty_Reset.Enabled = false;
                    bt_Duty_Save.Enabled = gb_AddDutyInfo.Enabled = true;
                    label88.Visible = true;
                }
                else                            //查看
                {
                    this.Text = "查看职务信息";
                    bt_Duty_Save.Enabled = bt_Duty_Reset.Enabled = gb_AddDutyInfo.Enabled = false;
                    label88.Visible = lb_DutyTipsInfo.Visible = false;
                }
                BindingDuty(tempDuty_ID);             //绑定修改的职务信息
            }
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

        #region【方法：初始化职务等级】

        /// <summary>
        /// 初始化职务等级
        /// </summary>
        private void InitComboBoxDutyClass()
        {
            using (ds = dbll.GetDutyGrade())
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count != 0)
                    {
                        comboBox_DutyClass.DataSource = dt;
                        comboBox_DutyClass.DisplayMember = "Title";
                        comboBox_DutyClass.SelectedIndex = 5;
                    }
                }
            }
        }
        #endregion



        #region【事件：保存】

        private void bt_Duty_Save_Click(object sender, EventArgs e)
        {
            if (CheckingDutyInfo()) //验证职务信息
            {
                if (tempDuty_ID == -1)      //添加
                {
                    if (SaveSetDuty())
                    {
                        SetTipsInfo(lb_DutyTipsInfo, true, "保存成功！");

                        //Czlt-2011-12-10 跟新修改日期
                        dbll.UpdateTime();

                        if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                        {
                            frmEi.Refresh_Duty();
                        }
                        else                                //热备版，启用定时器
                        {
                            frmEi.HostBackRefresh(true);
                        }
                    }
                    else
                    {
                        SetTipsInfo(lb_DutyTipsInfo, false, "保存失败！");
                    }
                }
                else                           //修改
                {
                    if (UpDateDuty())
                    {
                        SetTipsInfo(lb_DutyTipsInfo, true, "修改成功！");

                        //Czlt-2011-12-10 跟新修改日期
                        dbll.UpdateTime();

                        if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                        {
                            frmEi.Refresh_Duty();
                        }
                        else                                //热备版，启用定时器
                        {
                            frmEi.HostBackRefresh(true);
                        }
                    }
                    else
                    {
                        SetTipsInfo(lb_DutyTipsInfo, false, "修改失败！");
                    }
                }
            }
        }

        #endregion

        #region【事件：重置】

        private void bt_Duty_Reset_Click(object sender, EventArgs e)
        {
            ClearDutyInfo();
        }

        #endregion

        #region【事件：返回】

        private void bt_Duty_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void textBox_DutyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_DutyRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

    }
}
