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
    public partial class A_FrmEmpInfo_AddDeptInfo : Form
    {


        #region【声明】

        private A_DeptBLL dbll = new A_DeptBLL();
        //private A_AddEmpDAL adal = new A_AddEmpDAL();

        private DataSet ds;

        /// <summary>
        /// 用于保存要修改的部门ID
        /// </summary>
        private int tempDept_ID;

        public bool blIsUpdate = false;

        private A_FrmEmpInfo frmEi;

        private string strDeptNO = "";

        #endregion

        #region【构造函数】

        public A_FrmEmpInfo_AddDeptInfo(A_FrmEmpInfo frm)
        {
            InitializeComponent();
            frmEi = frm;
            tempDept_ID = frm.tempDept_ID;
            blIsUpdate = frm.blIsUpdate;
            
            GetDeptInfo_Add();

        }

        #endregion

        #region 【方法：验证部门信息】
        /// <summary>
        /// 验证部门信息是否符合要求
        /// </summary>
        /// <returns>返回是否通过验证</returns>
        private bool CheckingDeptInfo()
        {

            #region 验证部门编号不能为空
            if (textBox_DeptNO.Text.ToString().CompareTo("") == 0)
            {
                this.SetTipsInfo(lb_DeptTipsInfo, false, "请输入部门代号！");
                textBox_DeptNO.Focus();
                textBox_DeptNO.SelectAll();
                return false;
            }
            #endregion
            #region 验证部门名称不能为空
            if (textBox_DeptName.Text.ToString().CompareTo("") == 0)
            {
                this.SetTipsInfo(lb_DeptTipsInfo, false, "请输入部门名称！");
                textBox_DeptName.Focus();
                textBox_DeptName.SelectAll();
                return false;
            }
            #endregion
            #region 验证部门编号的唯一性

            if (tempDept_ID == -1 ||( tempDept_ID !=-1 && !textBox_DeptNO.Text.Trim().Equals(strDeptNO)))
            {
                using (DataSet ds = dbll.GetIDDeptID(textBox_DeptNO.Text.ToString()))
                {
                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count != 0)
                        {
                            this.SetTipsInfo(lb_DeptTipsInfo, false, "部门代号已存在,请重新输入部门代号！");
                            textBox_DeptNO.Focus();
                            textBox_DeptNO.SelectAll();
                            return false;
                        }
                    }
                }
            }
            #endregion
            #region 验证当输入领导上任时间时，部门领导不能为空

            if (textBox_DeptLeadName.Text.ToString().CompareTo("") == 0 && cb_LeadDateTime.Checked)
            {
                this.SetTipsInfo(lb_DeptTipsInfo, false, "有领导上任时间，但没输入领导，请输入部门领导！");
                textBox_DeptLeadName.Focus();
                textBox_DeptLeadName.SelectAll();
                return false;
            }
            #endregion
            #region 验证部门领导是否存在
            if (textBox_DeptLeadName.Text.ToString().CompareTo("") != 0)
            {
                using (DataSet ds = dbll.GetEmpNameEmpInfo(textBox_DeptLeadName.Text.ToString()))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count == 0)
                        {
                            this.SetTipsInfo(lb_DeptTipsInfo, false, "部门领导不存在,请重新输入部门领导！");
                            textBox_DeptLeadName.Focus();
                            textBox_DeptLeadName.SelectAll();
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            #endregion
            #region 验证 最小工作时间、最大工作时间

            if (textBox_Dept_MaxHour.Text == string.Empty)
            {
                this.SetTipsInfo(lb_DeptTipsInfo, false, "请输入最大工作时间！");
                textBox_Dept_MaxHour.Focus();
                textBox_Dept_MaxHour.SelectAll();
                return false;
            }
            else if (textBox_Dept_MaxMinute.Text == string.Empty)
            {
                this.SetTipsInfo(lb_DeptTipsInfo, false, "请输入最大工作时间！");
                textBox_Dept_MaxMinute.Focus();
                textBox_Dept_MaxMinute.SelectAll();
                return false;
            }
            else if (textBox_Dept_MaxSecond.Text == string.Empty)
            {
                this.SetTipsInfo(lb_DeptTipsInfo, false, "请输入最大工作时间！");
                textBox_Dept_MaxSecond.Focus();
                textBox_Dept_MaxSecond.SelectAll();
                return false;
            }
            else if (textBox_Dept_MinHour.Text == string.Empty)
            {
                this.SetTipsInfo(lb_DeptTipsInfo, false, "请输入最小工作时间！");
                textBox_Dept_MinHour.Focus();
                textBox_Dept_MinHour.SelectAll();
                return false;
            }
            else if (textBox_Dept_MinMinute.Text == string.Empty)
            {
                this.SetTipsInfo(lb_DeptTipsInfo, false, "请输入最小工作时间！");
                textBox_Dept_MinMinute.Focus();
                textBox_Dept_MinMinute.SelectAll();
                return false;
            }
            else if (textBox_Dept_MinSecond.Text == string.Empty)
            {
                this.SetTipsInfo(lb_DeptTipsInfo, false, "请输入最小工作时间！");
                textBox_Dept_MinSecond.Focus();
                textBox_Dept_MinSecond.SelectAll();
                return false;
            }

            int intMax, intMin;
            intMax = Convert.ToInt32(textBox_Dept_MaxHour.Text) * 3600 + Convert.ToInt32(textBox_Dept_MaxMinute.Text) * 60 + Convert.ToInt32(textBox_Dept_MaxSecond.Text);
            intMin = Convert.ToInt32(textBox_Dept_MinHour.Text) * 3600 + Convert.ToInt32(textBox_Dept_MinMinute.Text) * 60 + Convert.ToInt32(textBox_Dept_MinSecond.Text);

            if (intMax < intMin)
            {
                this.SetTipsInfo(lb_DeptTipsInfo, false, "最小工作时间不能大于最大工作时间！");
                textBox_Dept_MinHour.Focus();
                textBox_Dept_MinHour.SelectAll();
                return false;
            }

            if (intMax == 0)
            {
                this.SetTipsInfo(lb_DeptTipsInfo, false, "最大工作时间不能为0！");
                textBox_Dept_MaxHour.Focus();
                textBox_Dept_MaxHour.SelectAll();
                return false;
            }

            try
            {
                int iMinute = int.Parse(textBox_Dept_MaxMinute.Text);
                int iSecond = int.Parse(textBox_Dept_MaxSecond.Text);
                int i1 = int.Parse(textBox_Dept_MinMinute.Text);
                int i2 = int.Parse(textBox_Dept_MinSecond.Text);
                if (Check(iMinute) && Check(iSecond) && Check(i1) && Check(i2))
                {

                }
                else
                {
                    this.SetTipsInfo(lb_DeptTipsInfo, false, "分和秒不能大于60且不能小于0！");
                    return false;
                }
            }
            catch
            {
                return false;
            }

            #endregion

            #region[部门排列序号不能为空]

            if (txt_SerialNO.Text.Equals(""))
            {
                MessageBox.Show("部门排列序号必须不能空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_SerialNO.Focus();
                txt_SerialNO.SelectAll();
                return false;
            }

            #endregion
            #region【验证部门排列序号】

            if (Convert.ToInt32(txt_SerialNO.Text.Trim()) < 1)
            {
                MessageBox.Show("部门排列序号必须大于0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_SerialNO.Focus();
                txt_SerialNO.SelectAll();
                return false;
            }

            #endregion

            #region【验证部门工时单价】

            try
            {
                if (!txt_UnitPrice.Text.Trim().Equals(""))
                {
                    float ft = float.Parse(txt_UnitPrice.Text.Trim());
                }
            }
            catch
            {
                MessageBox.Show("部门工时单价只能为数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_UnitPrice.Focus();
                txt_UnitPrice.SelectAll();
                return false;
            }

            #endregion

            #region 【设置上级部门不能超过三级】
            
            if (!comboBox_ParentDept.Text.Trim().Equals(""))
            {
                int ParentDept_ID = Convert.ToInt32(comboBox_ParentDept.SelectedValue);      //获取上级部门编号
                int DeptLevel_ID = dbll.GetDeptLevelID(ParentDept_ID);//获取部门级别
                if (DeptLevel_ID >= 4)
                {
                    MessageBox.Show("上级部门不能超过三级！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    comboBox_ParentDept.Focus();
                    
                    return false;
 
                }
            }
            #endregion

            return true;
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

        #region 【方法：添加 部门信息】

        /// <summary>
        /// 添加 部门信息
        /// </summary>
        private bool SaveSetDept()
        {
            int ParentDept_ID = Convert.ToInt32(comboBox_ParentDept.SelectedValue);      //获取上级部门编号
            int DeptLevel_ID = dbll.GetDeptLevelID(ParentDept_ID);//获取部门级别
            int intImpactCounts = 0;

            float flUnitPrice = -1000;

            string strLeadDate;
            if (textBox_DeptLeadName.Text.ToString().CompareTo("") != 0)  //判断部门领导不为空
            {
                if (cb_LeadDateTime.Checked)
                {
                    strLeadDate = textBox_LeadDateTime.Value.ToString("yyyy-MM-dd");
                }
                else
                {
                    strLeadDate = "";
                }
            }
            else
            {
                strLeadDate = "";
            }

            try
            {
                flUnitPrice = float.Parse(txt_UnitPrice.Text.Trim());
            }
            catch
            {
                flUnitPrice = -1000;
            }

            intImpactCounts = dbll.SaveDeptInfo(ParentDept_ID, DeptLevel_ID, textBox_DeptNO.Text.Trim(), textBox_DeptName.Text.ToString().Trim(),Convert.ToInt32(comboBox_ClassName.SelectedValue),textBox_Remark.Text.Trim().ToString(),
                textBox_DeptTel1.Text.ToString(), textBox_DeptTel2.Text.ToString(), textBox_DeptFax.Text.ToString(), textBox_DeptPost.Text.ToString(), textBox_DeptAddress.Text.ToString(), textBox_DeptEmail.Text.ToString(),
                Convert.ToInt32(textBox_Dept_MaxHour.Text.ToString()), Convert.ToInt32(textBox_Dept_MaxMinute.Text.ToString()), Convert.ToInt32(textBox_Dept_MaxSecond.Text.ToString()), Convert.ToInt32(textBox_Dept_MinHour.Text.ToString()), Convert.ToInt32(textBox_Dept_MinMinute.Text.ToString()), Convert.ToInt32(textBox_Dept_MinSecond.Text.ToString()),
                textBox_DeptLeadName.Text.ToString(), strLeadDate, flUnitPrice, Convert.ToInt32(txt_SerialNO.Text.Trim()));
            if (intImpactCounts > 0)
            {
                //存入日志
                LogSave.Messages("[A_FrmEmpInfo]", LogIDType.UserLogID, "添加部门信息，部门编号：" + textBox_DeptNO.Text.Trim() + "，部门名称：" + textBox_DeptName.Text.ToString() + "。");
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region【方法：修改 部门信息】
        /// <summary>
        /// 修改 部门信息
        /// </summary>
        private bool UpDateDept()
        {
            int ParentDept_ID = Convert.ToInt32(comboBox_ParentDept.SelectedValue);      //获取上级部门编号
            int DeptLevel_ID = dbll.GetDeptLevelID(ParentDept_ID);//获取部门级别
            int intImpactCounts = 0;

            float flUnitPrice = -1000;

            string strLeadDate;
            if (!textBox_DeptLeadName.Text.Trim().ToString().Equals(""))  //判断部门领导不为空
            {
                if (cb_LeadDateTime.Checked)
                {
                    strLeadDate = textBox_LeadDateTime.Value.ToString("yyyy-MM-dd");
                }
                else
                {
                    strLeadDate = "";
                }
            }
            else
            {
                strLeadDate = "";
            }

            try
            {
                flUnitPrice = float.Parse(txt_UnitPrice.Text.Trim());
            }
            catch
            {
                flUnitPrice = -1000;
            }

            intImpactCounts = dbll.UpdateDeptInfo(ParentDept_ID, DeptLevel_ID, textBox_DeptNO.Text.Trim(), textBox_DeptName.Text.ToString().Trim(), textBox_Remark.Text.ToString(), Convert.ToInt32(comboBox_ClassName.SelectedValue),
                textBox_DeptTel1.Text.ToString(), textBox_DeptTel2.Text.ToString(), textBox_DeptFax.Text.ToString(), textBox_DeptPost.Text.ToString(), textBox_DeptAddress.Text.ToString(), textBox_DeptEmail.Text.ToString(),
                Convert.ToInt32(textBox_Dept_MaxHour.Text.ToString()), Convert.ToInt32(textBox_Dept_MaxMinute.Text.ToString()), Convert.ToInt32(textBox_Dept_MaxSecond.Text.ToString()), Convert.ToInt32(textBox_Dept_MinHour.Text.ToString()), Convert.ToInt32(textBox_Dept_MinMinute.Text.ToString()), Convert.ToInt32(textBox_Dept_MinSecond.Text.ToString()),
                textBox_DeptLeadName.Text.Trim().ToString(), strLeadDate, flUnitPrice, tempDept_ID, Convert.ToInt32(txt_SerialNO.Text.Trim()));
            if (intImpactCounts > 0)
            {
                strDeptNO = textBox_DeptNO.Text.Trim();
                //存入日志
                LogSave.Messages("[A_FrmEmpInfo]", LogIDType.UserLogID, "修改部门信息，部门编号：" + textBox_DeptNO.Text.Trim() + "，部门名称：" + textBox_DeptName.Text.ToString() + "。");
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 【方法：初始化上级部门名称】

        /// <summary>
        /// 初始化上级部门名称
        /// </summary>
        private void SetComboBoxParentDept()
        {
            dbll.GetParentDeptCmb(comboBox_ParentDept);
        }

        #endregion

        #region 【方法：初始化班制名称】

        /// <summary>
        /// 初始化班制名称
        /// </summary>
        private void SetComboBoxClassName()
        {
            dbll.GetClassNameCmb(comboBox_ClassName);
        }

        #endregion


        #region【方法：加载部门信息（新增）】

        private void GetDeptInfo_Add()
        {

            SetComboBoxParentDept();                //初始化上级部门名称
            SetComboBoxClassName();                 //初始化班制名称

            lb_DeptTipsInfo.Visible = false;        //隐藏提示信息

            if (tempDept_ID == -1)    //新增
            {
                textBox_DeptNO.Enabled = true;

                this.Text = "新增部门信息";

                ClearDeptInfo();                           //初始化信息
                bt_Dept_Save.Enabled = bt_Dept_Reset.Enabled = gb_AddDeptInfo.Enabled = label87.Enabled = true;
                
            }
            else                   
            {
                if (blIsUpdate)             //修改
                {
                    textBox_DeptNO.Enabled = false;

                    this.Text = "修改部门信息";
                    bt_Dept_Save.Enabled = gb_AddDeptInfo.Enabled = label87.Enabled = true;
                    bt_Dept_Reset.Enabled = false;
                }
                else                       //查看
                {
                    this.Text = "查看部门信息";
                    bt_Dept_Save.Enabled = bt_Dept_Reset.Enabled = gb_AddDeptInfo.Enabled = label87.Enabled = lb_DeptTipsInfo.Enabled = false;
                
                }
                BindingUpDateDept(tempDept_ID);             //绑定修改、查看的部门信息
            }
        }

        #endregion

        #region 【方法：清空 增加部门信息】

        /// <summary>
        /// 清空 增加部门信息
        /// </summary>
        private void ClearDeptInfo()
        {
            foreach (Control cl in gb_AddDeptInfo.Controls)
            {
                if (cl.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)cl).SelectedIndex = 0;
                }
                if (cl.GetType() == typeof(Shine.ShineTextBox))
                {
                    ((Shine.ShineTextBox)cl).Text = "";
                }
            }
            textBox_Dept_MaxHour.Text = "10";
            textBox_Dept_MaxMinute.Text = "0";
            textBox_Dept_MaxSecond.Text = "0";
            textBox_Dept_MinHour.Text = "0";
            textBox_Dept_MinMinute.Text = "0";
            textBox_Dept_MinSecond.Text = "0";
            txt_SerialNO.Text = "1";
            cb_LeadDateTime.Checked = false;
            textBox_LeadDateTime.Enabled = false;
        }

        #endregion

        #region【方法：绑定修改的部门信息】

        private void BindingUpDateDept(int intDeptID)
        {
            using (ds = dbll.GetKJ128NAllDept(intDeptID))
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable drTempDeptInfo = ds.Tables[0];
                    if (drTempDeptInfo.Rows.Count == 1)
                    {
                        //tempDept_NO = drTempDeptInfo.Rows[0][2].ToString();
                        textBox_DeptNO.Text = drTempDeptInfo.Rows[0][2].ToString();     //获取部门编号
                        strDeptNO = drTempDeptInfo.Rows[0][2].ToString();
                        textBox_DeptName.Text = drTempDeptInfo.Rows[0][3].ToString();   //获取部门名称
                        textBox_Remark.Text = drTempDeptInfo.Rows[0][4].ToString();     //获取部门备注
                        
                        #region 获取上级部门名称
                        using (DataSet dsTemp = dbll.GetIDDeptInfo(drTempDeptInfo.Rows[0][1].ToString()))
                        {
                            if (dsTemp != null && dsTemp.Tables.Count > 0)
                            {
                                DataTable drTemp = dsTemp.Tables[0];
                                if (drTemp.Rows.Count == 1)
                                {
                                    comboBox_ParentDept.Text = drTemp.Rows[0][4].ToString();
                                }
                                else if (drTemp.Rows.Count == 0)
                                {
                                    comboBox_ParentDept.Text = "无";
                                }
                            }
                            else
                            {
                                comboBox_ParentDept.Text = "无";
                            }
                        }
                        #endregion

                        #region 计算最大工作时间

                        if (drTempDeptInfo.Rows[0][5].ToString().CompareTo("") == 0)
                        {
                            textBox_Dept_MaxHour.Text = "";
                            textBox_Dept_MaxMinute.Text = "";
                            textBox_Dept_MaxSecond.Text = "";
                        }
                        else
                        {
                            int intMax = Convert.ToInt32(drTempDeptInfo.Rows[0][5]);
                            int hourMax = intMax / 3600;
                            int minuteMax = (intMax - hourMax * 3600) / 60;
                            int secondMax = intMax % 60;
                            textBox_Dept_MaxHour.Text = hourMax.ToString();
                            textBox_Dept_MaxMinute.Text = minuteMax.ToString();
                            textBox_Dept_MaxSecond.Text = secondMax.ToString();
                        }
                        #endregion
                        #region 计算最小工作时间

                        if (drTempDeptInfo.Rows[0][6].ToString().CompareTo("") == 0)
                        {
                            textBox_Dept_MinHour.Text = "";
                            textBox_Dept_MinMinute.Text = "";
                            textBox_Dept_MinSecond.Text = "";
                        }
                        else
                        {
                            int intMin = Convert.ToInt32(drTempDeptInfo.Rows[0][6]);
                            int hourMin = intMin / 3600;
                            int minuteMin = (intMin - hourMin * 3600) / 60;
                            int secondMin = intMin % 60;
                            textBox_Dept_MinHour.Text = hourMin.ToString();
                            textBox_Dept_MinMinute.Text = minuteMin.ToString();
                            textBox_Dept_MinSecond.Text = secondMin.ToString();
                        }
                        #endregion
                        textBox_DeptTel1.Text = drTempDeptInfo.Rows[0][9].ToString();       //获取部门电话1
                        textBox_DeptTel2.Text = drTempDeptInfo.Rows[0][10].ToString();      //获取部门电话2
                        textBox_DeptFax.Text = drTempDeptInfo.Rows[0][11].ToString();       //获取部门传真
                        textBox_DeptEmail.Text = drTempDeptInfo.Rows[0][14].ToString();     //获取部门电子邮箱
                        textBox_DeptPost.Text = drTempDeptInfo.Rows[0][12].ToString();      //获取部门邮编
                        textBox_DeptAddress.Text = drTempDeptInfo.Rows[0][13].ToString();   //获取部门地址

                        #region 获取部门领导姓名和上任时间

                        string strDeptLeadID;
                        strDeptLeadID = drTempDeptInfo.Rows[0][7].ToString();
                        if (!strDeptLeadID.Equals(""))
                        {
                            textBox_DeptLeadName.Text = strDeptLeadID;
                            
                            if (drTempDeptInfo.Rows[0][8].ToString().CompareTo("") == 0)
                            {
                                textBox_LeadDateTime.Value = DateTime.Now.Date;
                                textBox_LeadDateTime.Enabled = false;
                                cb_LeadDateTime.Checked = false;
                            }
                            else
                            {
                                textBox_LeadDateTime.Enabled = true;
                                cb_LeadDateTime.Checked = true;
                                textBox_LeadDateTime.Value = Convert.ToDateTime(drTempDeptInfo.Rows[0][8].ToString());
                            }
                        }
                        else
                        {
                            textBox_DeptLeadName.Text = "";
                            textBox_LeadDateTime.Value = DateTime.Now.Date;
                            textBox_LeadDateTime.Enabled = false;
                            cb_LeadDateTime.Checked = false;
                        }
                        #endregion
                        #region 获取班制名称
                        if (drTempDeptInfo.Rows[0][15].ToString() != "")
                        {
                            comboBox_ClassName.SelectedValue = Convert.ToInt32(drTempDeptInfo.Rows[0][15]);
                        }
                        #endregion
                        comboBox_ParentDept.Enabled = false;

                        //部门工时单价
                        txt_UnitPrice.Text = drTempDeptInfo.Rows[0]["UnitPrice"].ToString();

                        //获取部门排列序号
                        txt_SerialNO.Text = drTempDeptInfo.Rows[0]["SerialNO"].ToString();  
                    }
                }

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



        #region【事件：保存】

        private void bt_Dept_Save_Click(object sender, EventArgs e)
        {
            if (CheckingDeptInfo())     //验证
            {
                if (tempDept_ID == -1)      //添加
                {
                    if (SaveSetDept())
                    {
                        SetTipsInfo(lb_DeptTipsInfo, true, "保存成功！");

                        //Czlt-2011-12-10 跟新配置信息
                        dbll.UpdateTime();

                        if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                        {
                            frmEi.Refresh_Dept();
                            SetComboBoxParentDept();
                        }
                        else                                //热备版，启用定时器
                        {
                            frmEi.HostBackRefresh(true);
                        }
                    }
                    else
                    {
                        SetTipsInfo(lb_DeptTipsInfo, false, "保存失败！");
                    }
                }
                else                       //修改
                {
                    if (UpDateDept())
                    {
                        SetTipsInfo(lb_DeptTipsInfo, true, "修改成功！");

                        //Czlt-2011-12-10 跟新配置信息
                        dbll.UpdateTime();

                        if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                        {
                            frmEi.Refresh_Dept();
                            SetComboBoxParentDept();
                        }
                        else                                //热备版，启用定时器
                        {
                            frmEi.HostBackRefresh(true);
                        }
                    }
                    else
                    {
                        SetTipsInfo(lb_DeptTipsInfo, false, "修改失败！");
                    }
                }
            }
        }

        #endregion

        #region【事件：重置】

        private void bt_Dept_Reset_Click(object sender, EventArgs e)
        {
            ClearDeptInfo();
        }

        #endregion

        #region【事件：返回】

        private void bt_Dept_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #region【事件：是否启用领导上任时间】

        private void cb_LeadDateTime_CheckedChanged(object sender, EventArgs e)
        {
            textBox_LeadDateTime.Enabled = cb_LeadDateTime.Checked;
        }

        #endregion

        private void textBox_DeptNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_DeptName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_UnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_DeptTel1_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_DeptTel2_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_DeptFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_DeptPost_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_DeptAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_DeptEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_DeptLeadName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_Remark_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

  
    }
}
