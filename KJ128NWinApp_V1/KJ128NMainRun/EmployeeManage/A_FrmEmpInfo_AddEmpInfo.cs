using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using ZdcCommonLibrary;
using KJ128NModel;
using Shine.Logs;
using Shine.Logs.LogType;
using System.IO;
using System.Text.RegularExpressions;
using Shine;
using KJ128NDataBase;
using System.Xml;

namespace KJ128NMainRun.EmployeeManage
{
    public partial class A_FrmEmpInfo_AddEmpInfo : Form
    {

        #region【声明】

        private A_AddEmpBLL aebll = new A_AddEmpBLL();

        private OpenFileDialog ofd = new OpenFileDialog();
        private Byte[] bPhoto;

        /// <summary>
        /// 是否更新员工照片，true表示更新
        /// </summary>
        bool isUpDatePhoto;
        /// <summary>
        /// 员工ID（-1表示增加，其余表示要修改的员工ID）
        /// </summary>
        public int tempEmpID = -1;

        public bool blIsUpdate = false;

        private A_FrmEmpInfo frmEi;

        /// <summary>
        /// 修改时获取到的员工的照片ID，-1表示无
        /// </summary>
        public int tempEmpPhotoID = -1;

        /// <summary>
        /// 要修改员工的工种1 EmpWorkTypeID
        /// </summary>
        public int tempEmpWorkTypeID1 = 0;

        private string strEmpNO = "";

        #endregion

        #region【构造函数】

        public A_FrmEmpInfo_AddEmpInfo(A_FrmEmpInfo frm)
        {
            InitializeComponent();
            frmEi = frm;
            blIsUpdate = frm.blIsUpdate;
            tempEmpID = frm.tempEmpID;
            GetEmpInfo_Add();
        }

        #endregion


        #region 【方法: 验证 员工信息】
        /// <summary>
        /// 验证员工信息
        /// </summary>
        /// <returns>是否验证成功</returns>
        private bool CheckingEmployeeBaseInfo()
        {
            bool bool_Checking = true;

            CheckingInputOutput checking = new CheckingInputOutput();

            #region 【验证员工编号不能为空】

            if (textBox_EmployeeNO.Text.Trim().Equals(""))
            {
                this.SetTipsInfo(lb_EmpTipsInfo, false, "员工编号不能为空！");
                textBox_EmployeeNO.Focus();
                textBox_EmployeeNO.SelectAll();
                return false;
            }

            #endregion

            #region【员工姓名不能为空】

            if (textBox_EmplyeeName.Text.Trim().Equals(""))
            {
                this.SetTipsInfo(lb_EmpTipsInfo, false, "员工姓名不能为空！");
                textBox_EmplyeeName.Focus();
                textBox_EmplyeeName.SelectAll();
                return false;
            }

            #endregion

            #region 验证员工编号　长度　记录是否重复
            bool_Checking = checking.CheckingString(textBox_EmployeeNO.Text, 10, 1);
            if (!bool_Checking)
            {
                this.SetTipsInfo(lb_EmpTipsInfo, false, "员工编号不能超过10个字符！");
                return false;
            }
            else
            {
                //判断是修改还是新增
                if (tempEmpID == -1 || (tempEmpID != -1 && !textBox_EmployeeNO.Text.Trim().Equals(strEmpNO)))       //新增
                {
                    //数据库此数据是否已存在
                    if (aebll.IsEmp(textBox_EmployeeNO.Text.Trim()))
                    {
                        this.SetTipsInfo(lb_EmpTipsInfo, false, "此员工编号已存在");
                        textBox_EmployeeNO.Focus();
                        textBox_EmployeeNO.SelectAll();
                        return false;
                    }

                    #region 【验证员工姓名是否重复】
                    ////数据库此数据是否已存在
                    //if (aebll.IsEmpName(textBox_EmplyeeName.Text.Trim()))
                    //{
                    //    this.SetTipsInfo(lb_EmpTipsInfo, false, "此人员姓名已存在");
                    //    textBox_EmplyeeName.Focus();
                    //    textBox_EmplyeeName.SelectAll();
                    //    return false;
                    //}
                    #endregion
                }
                else
                {
                    #region 【验证员工姓名是否重复】
                    ////数据库此数据是否已存在
                    //if (aebll.IsEmpName(textBox_EmplyeeName.Text.Trim(), textBox_EmployeeNO.Text.Trim()))
                    //{
                    //    this.SetTipsInfo(lb_EmpTipsInfo, false, "此人员姓名已存在");
                    //    textBox_EmplyeeName.Focus();
                    //    textBox_EmplyeeName.SelectAll();
                    //    return false;
                    //}
                    #endregion
                }

            }
            #endregion

            #region 验证是否选择了部门

            if (comboBox_EmployeeDepartment.SelectedValue != null)
            {
                if (comboBox_EmployeeDepartment.SelectedValue.ToString().Equals("0"))
                {
                    this.SetTipsInfo(lb_EmpTipsInfo, false, "请选择部门！");
                    comboBox_EmployeeDepartment.Focus();
                    return false;
                }
            }
            else
            {
                this.SetTipsInfo(lb_EmpTipsInfo, false, "请选择部门！");
                comboBox_EmployeeDepartment.Focus();
                return false;
 
            }

            #endregion

            #region 验证试用日期、转正日期、离职日期

            if (cb_EmployeeProbationDate.Checked && cb_EmployeeOfficiallyDate.Checked)
            {
                if (dtp_EmployeeProbationDate.Value > dtp_EmployeeOfficiallyDate.Value)
                {
                    this.SetTipsInfo(lb_EmpTipsInfo, false, "试用日期不能大于转正日期！");
                    dtp_EmployeeOfficiallyDate.Focus();
                    return false;
                }
            }

            if (cb_EmployeeProbationDate.Checked && cb_EmployeeDimissionTime.Checked)
            {
                if (dtp_EmployeeProbationDate.Value> dtp_EmployeeDimissionTime.Value)
                {
                    this.SetTipsInfo(lb_EmpTipsInfo, false, "试用日期不能大于离职日期！");
                    dtp_EmployeeDimissionTime.Focus();
                    return false;
                }
            }
            if (cb_EmployeeOfficiallyDate.Checked && cb_EmployeeDimissionTime.Checked)
            {
                if (dtp_EmployeeOfficiallyDate.Value>dtp_EmployeeDimissionTime.Value)
                {
                    this.SetTipsInfo(lb_EmpTipsInfo, false, "转正日期不能大于离职日期！");
                    dtp_EmployeeDimissionTime.Focus();
                    return false;
                }
            }
            #endregion


            #region 验证移动电话
            if (textBox_EmployeeTel1.Text != "")
            {
                if (!Regex.IsMatch(textBox_EmployeeTel1.Text.Trim(), @"^\d{11}$"))
                {
                    this.SetTipsInfo(lb_EmpTipsInfo, false, "移动电话输入错误，请重新输入！");
                    textBox_EmployeeTel1.Focus();
                    textBox_EmployeeTel1.SelectAll();
                    return false;
                }
            }

            #endregion

            #region 验证身份证

            if (textBox_EmployeeIdentityCard.Text != "")
            {
                if (!Regex.IsMatch(textBox_EmployeeIdentityCard.Text.Trim(), @"^\d{15}$") && !Regex.IsMatch(textBox_EmployeeIdentityCard.Text.Trim(), @"^\d{17}(?:\d|x)$"))
                {
                    this.SetTipsInfo(lb_EmpTipsInfo, false, "身份证输入错误，请重新输入！");
                    textBox_EmployeeIdentityCard.Focus();
                    textBox_EmployeeIdentityCard.SelectAll();
                    return false;
                }
            }
            #endregion

            #region 验证最大、最小工作时间

            if (textBox_EmpMaxHour.Text == string.Empty)
            {
                this.SetTipsInfo(lb_EmpTipsInfo, false, "请输入最大工作时间！");
                textBox_EmpMaxHour.Focus();
                textBox_EmpMaxHour.SelectAll();
                return false;
            }
            else if (textBox_EmpMaxMinute.Text == string.Empty)
            {
                this.SetTipsInfo(lb_EmpTipsInfo, false, "请输入最大工作时间！");
                textBox_EmpMaxMinute.Focus();
                textBox_EmpMaxMinute.SelectAll();
                return false;
            }
            else if (textBox_EmpMaxSecond.Text == string.Empty)
            {
                this.SetTipsInfo(lb_EmpTipsInfo, false, "请输入最大工作时间！");
                textBox_EmpMaxSecond.Focus();
                textBox_EmpMaxSecond.SelectAll();
                return false;
            }
            else if (textBox_EmpMinHour.Text == string.Empty)
            {
                this.SetTipsInfo(lb_EmpTipsInfo, false, "请输入最小工作时间！");
                textBox_EmpMinHour.Focus();
                textBox_EmpMinHour.SelectAll();
                return false;
            }
            else if (textBox_EmpMinMinute.Text == string.Empty)
            {
                this.SetTipsInfo(lb_EmpTipsInfo, false, "请输入最小工作时间！");
                textBox_EmpMinMinute.Focus();
                textBox_EmpMinMinute.SelectAll();
                return false;
            }
            else if (textBox_EmpMinSecond.Text == string.Empty)
            {
                this.SetTipsInfo(lb_EmpTipsInfo, false, "请输入最小工作时间！");
                textBox_EmpMinSecond.Focus();
                textBox_EmpMinSecond.SelectAll();
                return false;
            }

            if (!CheckTimeN())
            {
                return false;
            }

            int intMax, intMin;
            intMax = Convert.ToInt32(textBox_EmpMaxHour.Text.Trim()) * 3600 + Convert.ToInt32(textBox_EmpMaxMinute.Text.Trim()) * 60 + Convert.ToInt32(textBox_EmpMaxSecond.Text.Trim());
            intMin = Convert.ToInt32(textBox_EmpMinHour.Text.Trim()) * 3600 + Convert.ToInt32(textBox_EmpMinMinute.Text.Trim()) * 60 + Convert.ToInt32(textBox_EmpMinSecond.Text.Trim());
            if (intMax < intMin)
            {
                this.SetTipsInfo(lb_EmpTipsInfo, false, "最小工作时间不能大于最大工作时间！");
                textBox_EmpMinHour.Focus();
                textBox_EmpMinHour.SelectAll();
                return false;
            }

            if (intMax == 0)
            {
                this.SetTipsInfo(lb_EmpTipsInfo, false, "最大工作时间不能等于0！");
                textBox_EmpMaxHour.Focus();
                textBox_EmpMaxHour.SelectAll();
                return false;
            }

            #endregion

            #region 验证启用模式为按工种设置时，是否选择工种
            if (rdb_WorkType.Checked && Convert.ToInt32(comboBox_EmpWorkTypeName.SelectedValue) == 0)
            {
                this.SetTipsInfo(lb_EmpTipsInfo, false, "启用模式为按工种设置，但却没有选择工种！");
                return false;
            }
            #endregion

            return true;
        }
        #endregion


        #region 【方法：实例化员工信息】
        private EmpModel SetEmpModel()
        {
            #region 实例化员工类并赋值

            EmpModel empModel = new EmpModel();

            //员工基本信息
            empModel.EmpNO = textBox_EmployeeNO.Text;
            empModel.EmpName = textBox_EmplyeeName.Text;
            empModel.Sex = Convert.ToBoolean(comboBox_EmployeeSex.SelectedValue);
            empModel.BaseRemark = textBox_EmployeeDemo.Text;

            //员工详细信息
            string strEmpBirDay;

            if (cb_EmpBirthDay.Checked)
            {
                strEmpBirDay = dtp_EmpBirthDay.Value.ToString();
            }
            else
            {
                strEmpBirDay = "1900-1-1 00:00:01";
            }

            empModel.Nation = textBox_EmployeeNation.Text;

            empModel.NativePlace = textBox_EmployeeNativePlace.Text;

            empModel.Wedlock = comboBox_EmployeeWedlock.Text;
            empModel.Clan = comboBox_EmployeeClan.Text;
            empModel.CensusRegister = textBox_EmployeeCensusRegister.Text;
            empModel.SchoolRecord = comboBox_EmployeeSchoolRecord.Text;
            empModel.GraduateFrom = textBox_EmployeeGraduateFrom.Text;
            empModel.Specialty = textBox_EmployeeSpecialty.Text;
            empModel.OfficialDesignation = textBox_EmployeeOfficialDesignation.Text;
            empModel.BirthDay = Convert.ToDateTime(strEmpBirDay);
            empModel.IdCard = textBox_EmployeeIdentityCard.Text;
            empModel.Company = txt_Company.Text;

            //员工联系方式信息
            empModel.HomeTel1 = textBox_EmployeeTel1.Text;
            empModel.HomeTel2 = textBox_EmployeeTel2.Text;

            //员工健康信息
            if (textBox_EmpHeight.Text.Equals(""))
            {
                empModel.Height = 0;
            }
            else
            {
                empModel.Height = Convert.ToInt32(textBox_EmpHeight.Text);
            }
            if (textBox_EmpWeight.Text.Equals(""))
            {
                empModel.Weight = 0;
            }
            else
            {
                empModel.Weight = Convert.ToInt32(textBox_EmpWeight.Text);
            }
            //empModel.Weight = Convert.ToInt32(textBox_EmpWeight.Text);
            empModel.StateOfHealth = textBox_EmpStateOfHealth.Text;

            //员工家庭信息
            empModel.HomeAddress = textBox_EmployeeHomeAddress.Text;

            #region 为员工试用日期，员工转正日期，合同有效期，续签有效期，离职日期赋值

            string strEmpProDate, strEmpOffDate, strEmpConExpDate, strEmpConExpAppDate, strEmpDimTime;
            if (cb_EmployeeProbationDate.Checked)
            {
                strEmpProDate = dtp_EmployeeProbationDate.Value.ToString();
            }
            else
            {
                strEmpProDate = "1900-1-1 00:00:01";
            }
            if (cb_EmployeeOfficiallyDate.Checked)
            {
                strEmpOffDate = dtp_EmployeeOfficiallyDate.Value.ToString();
            }
            else
            {
                strEmpOffDate = "1900-1-1 00:00:01";
            }
            if (cb_EmployeeContractExpDate.Checked)
            {
                strEmpConExpDate = dtp_EmployeeContractExpDate.Value.ToString();
            }
            else
            {
                strEmpConExpDate = "1900-1-1 00:00:01";
            }
            if (cb_EmployeeContractExpAppendDate.Checked)
            {
                strEmpConExpAppDate = dtp_EmployeeContractExpAppendDate.Value.ToString();
            }
            else
            {
                strEmpConExpAppDate = "1900-1-1 00:00:01";
            }
            if (cb_EmployeeDimissionTime.Checked)
            {
                strEmpDimTime = dtp_EmployeeDimissionTime.Value.ToString();
            }
            else
            {
                strEmpDimTime = "1900-1-1 00:00:01";
            }
            #endregion

            //员工进公司信息
            empModel.ProbationDate = Convert.ToDateTime((strEmpProDate));


            empModel.OfficiallyDate = Convert.ToDateTime(strEmpOffDate);
            empModel.ContractExpDate = Convert.ToDateTime(strEmpConExpDate);
            empModel.ContractExpAppendDate = Convert.ToDateTime(strEmpConExpAppDate);
            empModel.IsGearShift = checkbox_EmployeeGearShift.Checked;
            empModel.HireTypeID = Convert.ToInt32(combobox_EmployeeHireType.SelectedValue);
            empModel.Archives = textBox_EmployeeArchives.Text;
            empModel.DimissionTime = Convert.ToDateTime(strEmpDimTime);

            //员工在公司信息
            empModel.DeptID = Convert.ToInt32(comboBox_EmployeeDepartment.SelectedValue);
            empModel.DeptName = comboBox_EmployeeDepartment.Text;
            empModel.DutyID = Convert.ToInt32(combobox_EmployeeDuty.SelectedValue);
            empModel.DutyName = combobox_EmployeeDuty.Text;

            empModel.MaxSecTime = (Convert.ToInt32(textBox_EmpMaxHour.Text) * 3600)
                + (Convert.ToInt32(textBox_EmpMaxMinute.Text) * 60)
                + Convert.ToInt32(textBox_EmpMaxSecond.Text);

            empModel.MinSecTime = (Convert.ToInt32(textBox_EmpMinHour.Text) * 3600)
                + (Convert.ToInt32(textBox_EmpMinMinute.Text) * 60)
                + Convert.ToInt32(textBox_EmpMinSecond.Text);

            int intSelectMode;
            if (rdb_Dept.Checked)
            {
                intSelectMode = 1;
            }
            else if (rdb_Emp.Checked)
            {
                intSelectMode = 2;
            }
            else
            {
                intSelectMode = 3;
            }
            empModel.SelectMode = intSelectMode;

            empModel.ClassGroup = textBox_EmpGroup.Text.Trim();
            empModel.WorkPlace = textBox_EmpWorkPlace.Text.Trim();

            //员工照片信息
            if (bPhoto != null)
            {
                empModel.Photo = bPhoto;
            }

            //员工工种信息

            //工种1
            EmpWorkType empWorkType1 = new EmpWorkType();

            //if (Convert.ToInt32(comboBox_EmpWorkTypeName.SelectedValue) != 0)
            //{
                empWorkType1.WorkTypeID = Convert.ToInt32(comboBox_EmpWorkTypeName.SelectedValue);
                empWorkType1.WorkTypeName = comboBox_EmpWorkTypeName.Text;
                empWorkType1.IsMostly = true;
                empWorkType1.IsEnable = true;

                empModel.WorkType1 = empWorkType1;
            //}
          

            #endregion
            return empModel;
        }
        #endregion

        #region 【方法：添加 员工信息】
        /// <summary>
        /// 向数据库中添加 员工信息
        /// </summary>
        private void SaveEmployeeData()
        {

            EmpModel empModel = new EmpModel();
            empModel = SetEmpModel();

            int result = aebll.InsertEmpInfo(empModel);
            if (result > 0)
            {
                //Czlt-2011-12-10 跟新配置时间
                aebll.UpdateTime();

                //存入日志
                LogSave.Messages("[A_FrmEmpInfo]", LogIDType.UserLogID, "增加员工信息，姓名：" + textBox_EmplyeeName.Text + "，编号：" + textBox_EmployeeNO.Text.Trim() + "。");

                this.SetTipsInfo(lb_EmpTipsInfo, true, "保存成功！");
            }
            else
            {
                this.SetTipsInfo(lb_EmpTipsInfo, false, "保存失败！");
            }
        }

        #endregion

        #region 【方法：修改 员工信息】
        /// <summary>
        /// 修改 员工信息
        /// </summary>
        private void UpDateEmployee()
        {

            #region 实例化员工类并赋值

            //EmpModel empModel = new EmpModel();

            ////员工基本信息
            //empModel.EmpNO = textBox_EmployeeNO.Text;
            //empModel.EmpName = textBox_EmplyeeName.Text;
            //empModel.Sex = Convert.ToBoolean(comboBox_EmployeeSex.SelectedValue);
            //empModel.BaseRemark = textBox_EmployeeDemo.Text;

            ////员工详细信息
            //string strEmpBirDay;

            //if (cb_EmpBirthDay.Checked)
            //{
            //    strEmpBirDay = dtp_EmpBirthDay.Value.ToString();
            //}
            //else
            //{
            //    strEmpBirDay = "1900-1-1 00:00:01";
            //}

            //empModel.Nation = textBox_EmployeeNation.Text;

            //empModel.NativePlace = textBox_EmployeeNativePlace.Text;

            //empModel.Wedlock = comboBox_EmployeeWedlock.SelectedText;
            //empModel.Clan = comboBox_EmployeeClan.SelectedText;
            //empModel.CensusRegister = textBox_EmployeeCensusRegister.Text;
            //empModel.SchoolRecord = comboBox_EmployeeSchoolRecord.SelectedText;
            //empModel.GraduateFrom = textBox_EmployeeGraduateFrom.Text;
            //empModel.Specialty = textBox_EmployeeSpecialty.Text;
            //empModel.OfficialDesignation = textBox_EmployeeOfficialDesignation.Text;
            //empModel.BirthDay = Convert.ToDateTime(strEmpBirDay);
            //empModel.IdCard = textBox_EmployeeIdentityCard.Text;
            //empModel.Company = txt_Company.Text;

            ////员工联系方式信息
            //empModel.EmpTel1 = textBox_EmployeeTel1.Text;
            //empModel.EmpTel2 = textBox_EmployeeTel2.Text;

            ////员工健康信息
            //if (textBox_EmpHeight.Text.Equals(""))
            //{
            //    empModel.Height = 0;
            //}
            //else
            //{
            //    empModel.Height = Convert.ToInt32(textBox_EmpHeight.Text);
            //}
            //if (textBox_EmpWeight.Text.Equals(""))
            //{
            //    empModel.Weight = 0;
            //}
            //else
            //{
            //    empModel.Weight = Convert.ToInt32(textBox_EmpWeight.Text);
            //}
            ////empModel.Weight = Convert.ToInt32(textBox_EmpWeight.Text);
            //empModel.StateOfHealth = textBox_EmpStateOfHealth.Text;

            ////员工家庭信息
            //empModel.HomeAddress = textBox_EmployeeHomeAddress.Text;

            //#region 为员工试用日期，员工转正日期，合同有效期，续签有效期，离职日期赋值

            //string strEmpProDate, strEmpOffDate, strEmpConExpDate, strEmpConExpAppDate, strEmpDimTime;
            //if (cb_EmployeeProbationDate.Checked)
            //{
            //    strEmpProDate = dtp_EmployeeProbationDate.Value.ToString();
            //}
            //else
            //{
            //    strEmpProDate = "1900-1-1 00:00:01";
            //}
            //if (cb_EmployeeOfficiallyDate.Checked)
            //{
            //    strEmpOffDate = dtp_EmployeeOfficiallyDate.Value.ToString();
            //}
            //else
            //{
            //    strEmpOffDate = "1900-1-1 00:00:01";
            //}
            //if (cb_EmployeeContractExpDate.Checked)
            //{
            //    strEmpConExpDate = dtp_EmployeeContractExpDate.Value.ToString();
            //}
            //else
            //{
            //    strEmpConExpDate = "1900-1-1 00:00:01";
            //}
            //if (cb_EmployeeContractExpAppendDate.Checked)
            //{
            //    strEmpConExpAppDate = dtp_EmployeeContractExpAppendDate.Value.ToString();
            //}
            //else
            //{
            //    strEmpConExpAppDate = "1900-1-1 00:00:01";
            //}
            //if (cb_EmployeeDimissionTime.Checked)
            //{
            //    strEmpDimTime = dtp_EmployeeDimissionTime.Value.ToString();
            //}
            //else
            //{
            //    strEmpDimTime = "1900-1-1 00:00:01";
            //}
            //#endregion

            ////员工进公司信息
            //empModel.ProbationDate = Convert.ToDateTime((strEmpProDate));


            //empModel.OfficiallyDate = Convert.ToDateTime(strEmpOffDate);
            //empModel.ContractExpDate = Convert.ToDateTime(strEmpConExpDate);
            //empModel.ContractExpAppendDate = Convert.ToDateTime(strEmpConExpAppDate);
            //empModel.IsGearShift = checkbox_EmployeeGearShift.Checked;
            //empModel.HireTypeID = Convert.ToInt32(combobox_EmployeeHireType.SelectedValue);
            //empModel.Archives = textBox_EmployeeArchives.Text;
            //empModel.DimissionTime = Convert.ToDateTime(strEmpDimTime);

            ////员工在公司信息
            //empModel.DeptID = Convert.ToInt32(comboBox_EmployeeDepartment.SelectedValue);
            //empModel.DutyID = Convert.ToInt32(combobox_EmployeeDuty.SelectedValue);

            //empModel.MaxSecTime = (Convert.ToInt32(textBox_EmpMaxHour.Text) * 3600)
            //    + (Convert.ToInt32(textBox_EmpMaxMinute.Text) * 60)
            //    + Convert.ToInt32(textBox_EmpMaxSecond.Text);

            //empModel.MinSecTime = (Convert.ToInt32(textBox_EmpMinHour.Text) * 3600)
            //    + (Convert.ToInt32(textBox_EmpMinMinute.Text) * 60)
            //    + Convert.ToInt32(textBox_EmpMinSecond.Text);

            //int intSelectMode;
            //if (rdb_Dept.Checked)
            //{
            //    intSelectMode = 1;
            //}
            //else if (rdb_Emp.Checked)
            //{
            //    intSelectMode = 2;
            //}
            //else
            //{
            //    intSelectMode = 3;
            //}
            //empModel.SelectMode = intSelectMode;

            //empModel.ClassGroup = textBox_EmpGroup.Text.Trim();
            //empModel.WorkPlace = textBox_EmpWorkPlace.Text.Trim();

            ////员工照片信息
            //if (bPhoto != null)
            //{
            //    empModel.Photo = bPhoto;
            //}

            ////员工工种信息

            ////工种1
            //EmpWorkType empWorkType1 = new EmpWorkType();

            //if (Convert.ToInt32(comboBox_EmpWorkTypeName.SelectedValue) != 0)
            //{
            //    empWorkType1.WorkTypeID = Convert.ToInt32(comboBox_EmpWorkTypeName.SelectedValue);
            //    empWorkType1.IsMostly = true;
            //    empWorkType1.IsEnable = true;

            //    empModel.WorkType1 = empWorkType1;
            //}

            #endregion

            EmpModel empModel = new EmpModel();
            empModel = SetEmpModel();

            int result = aebll.UpdateEmpInfo(empModel,tempEmpID);
            if (result > 0)
            {
                //Czlt-2011-12-10 跟新配置时间
                aebll.UpdateTime();

                //存入日志
                LogSave.Messages("[A_FrmEmpInfo]", LogIDType.UserLogID, "修改员工信息，姓名：" + textBox_EmplyeeName.Text + "，编号：" + textBox_EmployeeNO.Text.Trim() + "。");

                this.SetTipsInfo(lb_EmpTipsInfo, true, "修改成功！");
                strEmpNO = textBox_EmployeeNO.Text.Trim();
            }
            else
            {
                this.SetTipsInfo(lb_EmpTipsInfo, false, "修改失败！");
            }

        }

        #endregion

        #region【方法：判断时间】

        private bool CheckTimeN()
        {
            try
            {
                int iMinute = int.Parse(textBox_EmpMaxMinute.Text);
                int iSecond = int.Parse(textBox_EmpMaxSecond.Text);
                int i1 = int.Parse(textBox_EmpMinMinute.Text);
                int i2 = int.Parse(textBox_EmpMinSecond.Text);
                if (Check(iMinute) && Check(iSecond) && Check(i1) && Check(i2))
                {
                    return true;
                }
                else
                {
                    this.SetTipsInfo(lb_EmpTipsInfo, false, "在单位情况中分和秒不能大于60且不能小于0！");
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

        #region【方法：重置（添加员工信息）】

        private void EmpReset(TabControl tb)
        {
            foreach (TabPage tbp in tb.TabPages)
            {
                EmpResetTabPage(tbp);
            }
        }

        private void EmpResetTabPage(TabPage tbp)
        {
            foreach (Control cl in tbp.Controls)
            {
                if (cl.GetType() == typeof(GroupBox))
                {
                    EmpResetGroupBox((GroupBox)cl);
                }
            }
        }

        private void EmpResetGroupBox(GroupBox gb)
        {
            foreach (Control cl in gb.Controls)
            {
                if (cl.GetType() == typeof(GroupBox))
                {
                    EmpResetGroupBox((GroupBox)cl);
                }
                if (cl.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)cl).SelectedIndex = 0;
                }
                if (cl.GetType() == typeof(TextBox))
                {
                    ((TextBox)cl).Text = "";
                }
                if (cl.GetType() == typeof(DateTimePicker))
                {
                    ((DateTimePicker)cl).Text = DateTime.Now.Date.ToString();
                    ((DateTimePicker)cl).Enabled = false;
                }
                if (cl.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)cl).Checked = false;
                }
                if (cl.GetType() == typeof(ShineTextBox))
                {
                    ((ShineTextBox)cl).Text = "";
                }
            }
        }

        #endregion

        #region【方法：加载添加人员信息（新增）】

        private void GetEmpInfo_Add()
        {
            aebll.GetDeptNameCmb(comboBox_EmployeeDepartment);              //初始化部门名词(comboBox)
            aebll.GetDutyNameCmb(combobox_EmployeeDuty, false);             //初始化职务名称(comboBox)
            aebll.GetWorkTypeCmb(comboBox_EmpWorkTypeName);                 //初始化工种名称(comboBox)
            comboBox_EmployeeSex.DataSource = aebll.GetEmpSexTab();         //初始化性别(comboBox)
            comboBox_EmployeeClan.DataSource = aebll.GetEmpClanTab();       //初始化政治面貌(comboBox)
            comboBox_EmployeeWedlock.DataSource = aebll.GetEmpWedlockTab(); //初始化婚姻状况(comboBox)
            comboBox_EmployeeSchoolRecord.DataSource = aebll.GetEmpSchoolRecordTab();   //初始化学历(comboBox)
            combobox_EmployeeHireType.DataSource = aebll.GetEmpHireTypeTab();           //初始化聘用形式(comboBox)

            lb_EmpTipsInfo.Visible = false;     //隐藏提示信息

            if (tempEmpID == -1)    //新增
            {
                bt_AddEmpSave.Enabled = bt_AddEmpReset.Enabled = groupBox1.Enabled = groupBox3.Enabled = groupBox4.Enabled = groupBox5.Enabled = groupBox6.Enabled = true;
                tbc_EmpInfo.SelectedTab = tbp_EmpBasic;

                textBox_EmployeeNO.Enabled = true;
                this.Text= "新增员工信息";
                lb_Photo.Visible = true;
                strEmpNO = "";
            }
            else                   
            {
                if (blIsUpdate)                 //修改
                { 
                    this.Text = "修改员工信息";
                    bt_AddEmpReset.Enabled = false;

                    bt_AddEmpSave.Enabled = groupBox1.Enabled = groupBox3.Enabled = groupBox4.Enabled = groupBox5.Enabled = groupBox6.Enabled = true;
                    //1 不可修改
                    if (GetConfigValue("IsUpdateUserNo").ToLower().Trim().Equals("1"))
                    {
                        textBox_EmployeeNO.Enabled = false;
                    }
                        //0 可修改
                    else if (GetConfigValue("IsUpdateUserNo").ToLower().Trim().Equals("0"))
                    {
                        textBox_EmployeeNO.Enabled = true;
                    }
                }
                else                            //查看
                {
                    this.Text = "查看员工信息";
                    bt_AddEmpSave.Enabled = bt_AddEmpReset.Enabled = groupBox1.Enabled = groupBox3.Enabled = groupBox4.Enabled = groupBox5.Enabled = groupBox6.Enabled = false;
                }
                GetEmpTable(tempEmpID);
            }
            tbc_EmpInfo.SelectedTab = tbp_EmpBasic;
        }

        #endregion

        #region【方法: 获取和绑定要修改人员的信息】

        /// <summary>
        /// 获取和绑定要修改人员的信息
        /// </summary>
        private void GetEmpTable(int intTempEmpID)
        {
            #region 员工基本信息
            DataTable dtEmpBaseInfo = aebll.GetEmpBaseInfoTab(intTempEmpID);
            if (dtEmpBaseInfo != null)
            {
                if (dtEmpBaseInfo.Rows.Count != 0)
                {
                    textBox_EmplyeeName.Text = dtEmpBaseInfo.Rows[0]["EmpName"].ToString();//姓名
                    strEmpNO = textBox_EmployeeNO.Text = dtEmpBaseInfo.Rows[0]["EmpNo"].ToString();//编号
                    comboBox_EmployeeSex.SelectedValue = Convert.ToInt32(dtEmpBaseInfo.Rows[0]["Sex"]);//性别
                    textBox_EmployeeIdentityCard.Text = dtEmpBaseInfo.Rows[0]["IdCard"].ToString();//身份证
                    if (dtEmpBaseInfo.Rows[0]["DeptID"].ToString() != "")//部门
                    {
                        comboBox_EmployeeDepartment.SelectedValue = Convert.ToInt32(dtEmpBaseInfo.Rows[0]["DeptID"]);
                    }
                    else
                    {
                        comboBox_EmployeeDepartment.SelectedValue = 0;
                    }
                    if (dtEmpBaseInfo.Rows[0]["DutyID"].ToString() != "")//职务
                    {
                        combobox_EmployeeDuty.SelectedValue = Convert.ToInt32(dtEmpBaseInfo.Rows[0]["DutyID"]);
                    }
                    else
                    {
                        combobox_EmployeeDuty.SelectedValue = 0;
                    }
                    if (!dtEmpBaseInfo.Rows[0]["workTypeID"].ToString().Equals(""))
                    {
                        comboBox_EmpWorkTypeName.SelectedValue = tempEmpWorkTypeID1 = Convert.ToInt32(dtEmpBaseInfo.Rows[0]["workTypeID"].ToString());//员工工种编号
                    }
                    else
                    {
                        comboBox_EmpWorkTypeName.SelectedValue = tempEmpWorkTypeID1 = 0;
                    }
                    //工作时间选择
                    if (dtEmpBaseInfo.Rows[0]["Selectmode"].ToString() == "1")
                    {
                        rdb_Dept.Checked = true;
                    }
                    else if (dtEmpBaseInfo.Rows[0]["Selectmode"].ToString() == "2")
                    {
                        rdb_Emp.Checked = true;
                    }
                    else
                    {
                        rdb_WorkType.Checked = true;
                    }
                    //读取数据库照片信息
                    if (dtEmpBaseInfo.Rows[0]["photo"].ToString() != "")
                    {
                        //QYZ-2011-03-18--
                        try
                        {
                            byte[] bytes = (byte[])dtEmpBaseInfo.Rows[0]["photo"];
                            MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length);

                            ptb_EmpPhoto.Image = Image.FromStream(ms);
                        }
                        catch { }
                    }


                    if (rdb_Dept.Checked)
                    {
                        textBox_EmpMaxHour.Enabled = false;
                        textBox_EmpMaxMinute.Enabled = false;
                        textBox_EmpMaxSecond.Enabled = false;
                        textBox_EmpMinHour.Enabled = false;
                        textBox_EmpMinMinute.Enabled = false;
                        textBox_EmpMinSecond.Enabled = false;
                    }
                    else if (rdb_Emp.Checked)
                    {
                        textBox_EmpMaxHour.Enabled = true;
                        textBox_EmpMaxMinute.Enabled = true;
                        textBox_EmpMaxSecond.Enabled = true;
                        textBox_EmpMinHour.Enabled = true;
                        textBox_EmpMinMinute.Enabled = true;
                        textBox_EmpMinSecond.Enabled = true;
                    }
                    else if (rdb_WorkType.Checked)
                    {
                        textBox_EmpMaxHour.Enabled = false;
                        textBox_EmpMaxMinute.Enabled = false;
                        textBox_EmpMaxSecond.Enabled = false;
                        textBox_EmpMinHour.Enabled = false;
                        textBox_EmpMinMinute.Enabled = false;
                        textBox_EmpMinSecond.Enabled = false;
                    }
                    textBox_EmpGroup.Text = dtEmpBaseInfo.Rows[0]["classGroup"].ToString();//所在班组
                    textBox_EmpWorkPlace.Text = dtEmpBaseInfo.Rows[0]["workPlace"].ToString();//工作地点

                    #region 计算最大工作时间
                    if (dtEmpBaseInfo.Rows[0]["MaxSecTime"].ToString().CompareTo("") == 0)
                    {
                        textBox_EmpMaxHour.Text = "0";
                        textBox_EmpMaxMinute.Text = "0";
                        textBox_EmpMaxSecond.Text = "0";
                    }
                    else
                    {
                        int intMax = Convert.ToInt32(dtEmpBaseInfo.Rows[0]["MaxSecTime"]);
                        int hourMax = intMax / 3600;
                        int minuteMax = (intMax - hourMax * 3600) / 60;
                        int secondMax = intMax % 60;
                        textBox_EmpMaxHour.Text = hourMax.ToString();
                        textBox_EmpMaxMinute.Text = minuteMax.ToString();
                        textBox_EmpMaxSecond.Text = secondMax.ToString();
                    }
                    #endregion
                    #region 计算最小工作时间

                    if (dtEmpBaseInfo.Rows[0]["MinSecTime"].ToString().CompareTo("") == 0)
                    {
                        textBox_EmpMinHour.Text = "0";
                        textBox_EmpMinMinute.Text = "0";
                        textBox_EmpMinSecond.Text = "0";
                    }
                    else
                    {
                        int intMin = Convert.ToInt32(dtEmpBaseInfo.Rows[0]["MinSecTime"]);
                        int hourMin = intMin / 3600;
                        int minuteMin = (intMin - hourMin * 3600) / 60;
                        int secondMin = intMin % 60;
                        textBox_EmpMinHour.Text = hourMin.ToString();
                        textBox_EmpMinMinute.Text = minuteMin.ToString();
                        textBox_EmpMinSecond.Text = secondMin.ToString();
                    }
                    #endregion

                    
                    if (dtEmpBaseInfo.Rows[0]["photo"] != null && !dtEmpBaseInfo.Rows[0]["photo"].ToString().Equals(""))//绑定图片
                    {
                        try
                        {
                            bPhoto = (byte[])dtEmpBaseInfo.Rows[0]["photo"];

                            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream((byte[])dtEmpBaseInfo.Rows[0]["photo"]);
                            Bitmap bmp = new Bitmap(memoryStream);
                            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
                            ptb_EmpPhoto.Image = bmp;
                            isUpDatePhoto = false;
                            lb_Photo.Visible = false;
                        }
                        catch { }
                    }
                    else
                    {
                        lb_Photo.Visible = true;
                    }
                    textBox_EmployeeDemo.Text = dtEmpBaseInfo.Rows[0]["Remark"].ToString();
                }
            }
            #endregion

            #region 员工信息明细
            DataTable dtEmpDetail = aebll.GetEmpDetailTab(intTempEmpID);
            if (dtEmpDetail != null)
            {
                if (dtEmpDetail.Rows.Count != 0)
                {
                    textBox_EmployeeNation.Text = dtEmpDetail.Rows[0]["Nation"].ToString();
                    try
                    {
                        comboBox_EmployeeWedlock.Text = dtEmpDetail.Rows[0]["Wedlock"].ToString();
                    }
                    catch
                    {
                        comboBox_EmployeeWedlock.SelectedIndex = 0;
                    }
                    try
                    {
                        comboBox_EmployeeClan.Text = dtEmpDetail.Rows[0]["Clan"].ToString();
                    }
                    catch
                    {
                        comboBox_EmployeeClan.SelectedIndex = 0;
                    }
                    textBox_EmployeeNativePlace.Text = dtEmpDetail.Rows[0]["NativePlace"].ToString();
                    textBox_EmployeeCensusRegister.Text = dtEmpDetail.Rows[0]["CensusRegister"].ToString();
                    try
                    {
                        comboBox_EmployeeSchoolRecord.Text = dtEmpDetail.Rows[0]["SchoolRecord"].ToString();
                    }
                    catch
                    {
                        comboBox_EmployeeSchoolRecord.SelectedIndex = 0;
                    }
                    textBox_EmployeeGraduateFrom.Text = dtEmpDetail.Rows[0]["GraduateFrom"].ToString();
                    textBox_EmployeeSpecialty.Text = dtEmpDetail.Rows[0]["Specialty"].ToString();
                    textBox_EmployeeOfficialDesignation.Text = dtEmpDetail.Rows[0]["OfficialDesignation"].ToString();
                    txt_Company.Text = dtEmpDetail.Rows[0]["blood"].ToString();

                    if (dtEmpDetail.Rows[0]["BirthDay"].ToString().CompareTo("") == 0)
                    {
                        cb_EmpBirthDay.Checked = false;
                        dtp_EmpBirthDay.Enabled = false;
                    }
                    else
                    {
                        cb_EmpBirthDay.Checked = true;
                        dtp_EmpBirthDay.Enabled = true;
                        dtp_EmpBirthDay.Text = dtEmpDetail.Rows[0]["BirthDay"].ToString();
                    }
                    textBox_EmployeeTel1.Text = dtEmpDetail.Rows[0]["HomeTel"].ToString();
                    textBox_EmployeeTel2.Text = dtEmpDetail.Rows[0]["Tel"].ToString();
                    textBox_EmployeeHomeAddress.Text = dtEmpDetail.Rows[0]["HomeAddress"].ToString();
                    if (dtEmpDetail.Rows[0]["Height"].ToString().CompareTo("") == 0 || Convert.ToInt32(dtEmpDetail.Rows[0]["Height"]) == 0)
                    {
                        textBox_EmpHeight.Text = "";
                    }
                    else
                    {
                        textBox_EmpHeight.Text = dtEmpDetail.Rows[0]["Height"].ToString();
                    }
                    if (dtEmpDetail.Rows[0]["Weight"].ToString().CompareTo("") == 0 || Convert.ToInt32(dtEmpDetail.Rows[0]["Weight"]) == 0)
                    {
                        textBox_EmpWeight.Text = "";
                    }
                    else
                    {
                        textBox_EmpWeight.Text = dtEmpDetail.Rows[0]["Weight"].ToString();
                    }
                    textBox_EmpStateOfHealth.Text = dtEmpDetail.Rows[0]["StateOfHealth"].ToString();
                    if (dtEmpDetail.Rows[0]["probationDate"].ToString().CompareTo("") == 0)
                    {

                        dtp_EmployeeProbationDate.Enabled = false;
                        cb_EmployeeProbationDate.Checked = false;
                    }
                    else
                    {
                        dtp_EmployeeProbationDate.Text = dtEmpDetail.Rows[0]["probationDate"].ToString();
                        dtp_EmployeeProbationDate.Enabled = true;
                        cb_EmployeeProbationDate.Checked = true;
                    }
                    if (dtEmpDetail.Rows[0]["OfficiallyDate"].ToString().CompareTo("") == 0)
                    {

                        dtp_EmployeeOfficiallyDate.Enabled = false;
                        cb_EmployeeOfficiallyDate.Checked = false;
                    }
                    else
                    {
                        dtp_EmployeeOfficiallyDate.Text = dtEmpDetail.Rows[0]["OfficiallyDate"].ToString();
                        dtp_EmployeeOfficiallyDate.Enabled = true;
                        cb_EmployeeOfficiallyDate.Checked = true;
                    }
                    if (dtEmpDetail.Rows[0]["ContractExpDate"].ToString().CompareTo("") == 0)
                    {

                        dtp_EmployeeContractExpDate.Enabled = false;
                        cb_EmployeeContractExpDate.Checked = false;
                    }
                    else
                    {
                        dtp_EmployeeContractExpDate.Text = dtEmpDetail.Rows[0]["ContractExpDate"].ToString();
                        dtp_EmployeeContractExpDate.Enabled = true;
                        cb_EmployeeContractExpDate.Checked = true;
                    }
                    if (dtEmpDetail.Rows[0]["ContractExpAppendDate"].ToString().CompareTo("") == 0)
                    {

                        dtp_EmployeeContractExpAppendDate.Enabled = false;
                        cb_EmployeeContractExpAppendDate.Checked = false;
                    }
                    else
                    {
                        dtp_EmployeeContractExpAppendDate.Text = dtEmpDetail.Rows[0]["ContractExpAppendDate"].ToString();
                        dtp_EmployeeContractExpAppendDate.Enabled = true;
                        cb_EmployeeContractExpAppendDate.Checked = true;
                    }
                    if (!dtEmpDetail.Rows[0]["IsGearShift"].ToString().Equals(""))
                    {
                        checkbox_EmployeeGearShift.Checked = Convert.ToBoolean(dtEmpDetail.Rows[0]["IsGearShift"]);
                    }
                    else
                    {
                        checkbox_EmployeeGearShift.Checked = false;
                    }
                    if (!dtEmpDetail.Rows[0]["HireTypeID"].ToString().Equals(""))
                    {
                        combobox_EmployeeHireType.SelectedValue = Convert.ToInt32(dtEmpDetail.Rows[0]["HireTypeID"]);
                    }
                    else
                    {
                        combobox_EmployeeHireType.SelectedValue = 0;
                    }
                    if (!checkbox_EmployeeGearShift.Checked)
                    {
                        textBox_EmployeeArchives.Text = "";
                        textBox_EmployeeArchives.Enabled = false;
                        checkbox_EmployeeGearShift.Checked = false;
                    }
                    else
                    {
                        textBox_EmployeeArchives.Enabled = true;
                        textBox_EmployeeArchives.Text = dtEmpDetail.Rows[0]["Archives"].ToString();
                        checkbox_EmployeeGearShift.Checked = true;
                    }

                    if (dtEmpDetail.Rows[0]["DimissionTime"].ToString().CompareTo("") == 0)
                    {

                        dtp_EmployeeDimissionTime.Enabled = false;
                        cb_EmployeeDimissionTime.Checked = false;
                    }
                    else
                    {
                        dtp_EmployeeDimissionTime.Text = dtEmpDetail.Rows[0]["DimissionTime"].ToString();
                        dtp_EmployeeDimissionTime.Enabled = true;
                        cb_EmployeeDimissionTime.Checked = true;
                    }
                }
            }
            #endregion
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



        #region【事件：添加照片】

        private void bcp_EmpPhoto_Click(object sender, EventArgs e)
        {
            ofd.Filter = "JPEG(*.jpg;*.jpeg)|*.jpg;*.jpeg|位图文件|*.bmp|所有文件(*.*)|*.*";
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                // 存

                lb_Photo.Visible = false;
                StreamReader sr = new StreamReader(ofd.FileName);
                System.IO.Stream s = sr.BaseStream;
                bPhoto = new byte[s.Length];
                s.Read(bPhoto, 0, Convert.ToInt32(s.Length));


                //取
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(bPhoto);
                Bitmap bmp;
                try
                {
                    bmp = new Bitmap(memoryStream);
                }
                catch
                {
                    bmp = null;
                    bPhoto = null;
                    lb_Photo.Visible = true;
                }
                ptb_EmpPhoto.Image = bmp;
                isUpDatePhoto = true;
            }
        }

        #endregion

        #region【事件：删除照片】

        private void bcp_EmpDelPhoto_Click(object sender, EventArgs e)
        {
            bPhoto = null;
            ptb_EmpPhoto.Image = null;
            tempEmpPhotoID = -1;
            lb_Photo.Visible = true;
        }

        #endregion

        #region【事件：是否启用出身年月】

        private void cb_EmpBirthDay_Click(object sender, EventArgs e)
        {
            dtp_EmpBirthDay.Enabled = cb_EmpBirthDay.Checked;
        }

        #endregion

        #region【事件：是否已调档】
        private void checkbox_EmployeeGearShift_CheckedChanged(object sender, EventArgs e)
        {
            textBox_EmployeeArchives.Enabled = checkbox_EmployeeGearShift.Checked;
        }

        #endregion

        #region【事件：是否启用——试用日期】

        private void cb_EmployeeProbationDate_CheckedChanged(object sender, EventArgs e)
        {
            dtp_EmployeeProbationDate.Enabled = cb_EmployeeProbationDate.Checked;
        }

        #endregion

        #region【事件：是否启用——转正日期】

        private void cb_EmployeeOfficiallyDate_CheckedChanged(object sender, EventArgs e)
        {
            dtp_EmployeeOfficiallyDate.Enabled = cb_EmployeeOfficiallyDate.Checked;
        }

        #endregion

        #region【事件：是否启用——合同有效期】

        private void cb_EmployeeContractExpDate_CheckedChanged(object sender, EventArgs e)
        {
            dtp_EmployeeContractExpDate.Enabled = cb_EmployeeContractExpDate.Checked;
        }

        #endregion

        #region【事件：是否启用——签约有效期】

        private void cb_EmployeeContractExpAppendDate_CheckedChanged(object sender, EventArgs e)
        {
            dtp_EmployeeContractExpAppendDate.Enabled = cb_EmployeeContractExpAppendDate.Checked;
        }

        #endregion

        #region【事件：是否启用——离职日期】

        private void cb_EmployeeDimissionTime_CheckedChanged(object sender, EventArgs e)
        {
            dtp_EmployeeDimissionTime.Enabled = cb_EmployeeDimissionTime.Checked;
        }

        #endregion

        #region【事件：选项卡选择事件】

        private void tbc_EmpInfo_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Name == "tbp_EmpPersonal")
            {
                //个人信息中姓名与基本信息中姓名同步
                txt_EmpName2.Text = textBox_EmplyeeName.Text;
            }
        }

        #endregion

        #region【事件：启用模式为：部门】

        private void rdb_Dept_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Dept.Checked)
            {
                DataTable dt = aebll.GetDeptSysSetTab(Convert.ToInt32(comboBox_EmployeeDepartment.SelectedValue));
                if (dt != null && dt.Rows.Count != 0)
                {
                    #region 绑定最大工作时间
                    if (dt.Rows[0][2].ToString().CompareTo("") == 0)
                    {
                        textBox_EmpMaxHour.Text = "0";
                        textBox_EmpMaxMinute.Text = "0";
                        textBox_EmpMaxSecond.Text = "0";
                    }
                    else
                    {
                        int intMax = Convert.ToInt32(dt.Rows[0][2]);
                        int hourMax = intMax / 3600;
                        int minuteMax = (intMax - hourMax * 3600) / 60;
                        int secondMax = intMax % 60;
                        textBox_EmpMaxHour.Text = hourMax.ToString();
                        textBox_EmpMaxMinute.Text = minuteMax.ToString();
                        textBox_EmpMaxSecond.Text = secondMax.ToString();
                    }
                    #endregion
                    #region 绑定最小工作时间
                    if (dt.Rows[0][3].ToString().CompareTo("") == 0)
                    {
                        textBox_EmpMinHour.Text = "0";
                        textBox_EmpMinMinute.Text = "0";
                        textBox_EmpMinSecond.Text = "0";
                    }
                    else
                    {
                        int intMin = Convert.ToInt32(dt.Rows[0][3]);
                        int hourMin = intMin / 3600;
                        int minuteMin = (intMin - hourMin * 3600) / 60;
                        int secondMin = intMin % 60;
                        textBox_EmpMinHour.Text = hourMin.ToString();
                        textBox_EmpMinMinute.Text = minuteMin.ToString();
                        textBox_EmpMinSecond.Text = secondMin.ToString();
                    }
                    #endregion
                }
                textBox_EmpMaxHour.Enabled = false;
                textBox_EmpMaxMinute.Enabled = false;
                textBox_EmpMaxSecond.Enabled = false;
                textBox_EmpMinHour.Enabled = false;
                textBox_EmpMinMinute.Enabled = false;
                textBox_EmpMinSecond.Enabled = false;
            }
        }

        #endregion

        #region【事件：启用模式为：工种】

        private void rdb_WorkType_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_WorkType.Checked)
            {
                if (comboBox_EmpWorkTypeName.SelectedValue == null || comboBox_EmpWorkTypeName.SelectedValue.Equals(0))
                {
                    textBox_EmpMaxHour.Enabled = false;
                    textBox_EmpMaxMinute.Enabled = false;
                    textBox_EmpMaxSecond.Enabled = false;
                    textBox_EmpMinHour.Enabled = false;
                    textBox_EmpMinMinute.Enabled = false;
                    textBox_EmpMinSecond.Enabled = false;
                    this.SetTipsInfo(lb_EmpTipsInfo, false, "请选择工种名称！");
                }
                else
                {
                    DataTable dtWorkSet = aebll.GetWorkTypeSysSetTab(Convert.ToInt32(comboBox_EmpWorkTypeName.SelectedValue));
                    if (dtWorkSet != null && dtWorkSet.Rows.Count != 0)
                    {
                        #region 绑定最大工作时间
                        if (dtWorkSet.Rows[0][2].ToString().CompareTo("") == 0)
                        {
                            textBox_EmpMaxHour.Text = "0";
                            textBox_EmpMaxMinute.Text = "0";
                            textBox_EmpMaxSecond.Text = "0";
                        }
                        else
                        {
                            int intMax = Convert.ToInt32(dtWorkSet.Rows[0][2]);
                            int hourMax = intMax / 3600;
                            int minuteMax = (intMax - hourMax * 3600) / 60;
                            int secondMax = intMax % 60;
                            textBox_EmpMaxHour.Text = hourMax.ToString();
                            textBox_EmpMaxMinute.Text = minuteMax.ToString();
                            textBox_EmpMaxSecond.Text = secondMax.ToString();
                        }
                        #endregion

                        #region 绑定最小工作时间
                        if (dtWorkSet.Rows[0][3].ToString().CompareTo("") == 0)
                        {
                            textBox_EmpMinHour.Text = "0";
                            textBox_EmpMinMinute.Text = "0";
                            textBox_EmpMinSecond.Text = "0";
                        }
                        else
                        {
                            int intMin = Convert.ToInt32(dtWorkSet.Rows[0][3]);
                            int hourMin = intMin / 3600;
                            int minuteMin = (intMin - hourMin * 3600) / 60;
                            int secondMin = intMin % 60;
                            textBox_EmpMinHour.Text = hourMin.ToString();
                            textBox_EmpMinMinute.Text = minuteMin.ToString();
                            textBox_EmpMinSecond.Text = secondMin.ToString();
                        }
                        #endregion

                        textBox_EmpMaxHour.Enabled = false;
                        textBox_EmpMaxMinute.Enabled = false;
                        textBox_EmpMaxSecond.Enabled = false;
                        textBox_EmpMinHour.Enabled = false;
                        textBox_EmpMinMinute.Enabled = false;
                        textBox_EmpMinSecond.Enabled = false;
                    }
                }
            }
        }

        #endregion

        #region【事件：启用模式为：员工】

        private void rdb_Emp_CheckedChanged(object sender, EventArgs e)
        {
            #region 初始化最大工作时间 为10小时0分0秒
            textBox_EmpMaxHour.Text = "10";
            textBox_EmpMaxMinute.Text = "0";
            textBox_EmpMaxSecond.Text = "0";
            #endregion
            #region 初始化最小工作时间 为0小时0分0秒
            textBox_EmpMinHour.Text = "0";
            textBox_EmpMinMinute.Text = "0";
            textBox_EmpMinSecond.Text = "0";
            #endregion
            textBox_EmpMaxHour.Enabled = true;
            textBox_EmpMaxMinute.Enabled = true;
            textBox_EmpMaxSecond.Enabled = true;
            textBox_EmpMinHour.Enabled = true;
            textBox_EmpMinMinute.Enabled = true;
            textBox_EmpMinSecond.Enabled = true;
        }

        #endregion

        #region【事件: 自动根据部门填入最大、最小工作时间】

        private void comboBox_EmployeeDepartment_DropDownClosed(object sender, EventArgs e)
        {
            if (rdb_Dept.Checked)            //确定启动模式是按部门设置
            {
                DataTable dt = aebll.GetDeptSysSetTab(Convert.ToInt32(comboBox_EmployeeDepartment.SelectedValue));
                if (dt != null && dt.Rows.Count != 0)
                {
                    #region 绑定最大工作时间
                    if (dt.Rows[0][2].ToString().CompareTo("") == 0)
                    {
                        textBox_EmpMaxHour.Text = "0";
                        textBox_EmpMaxMinute.Text = "0";
                        textBox_EmpMaxSecond.Text = "0";
                    }
                    else
                    {
                        int intMax = Convert.ToInt32(dt.Rows[0][2]);
                        int hourMax = intMax / 3600;
                        int minuteMax = (intMax - hourMax * 3600) / 60;
                        int secondMax = intMax % 60;
                        textBox_EmpMaxHour.Text = hourMax.ToString();
                        textBox_EmpMaxMinute.Text = minuteMax.ToString();
                        textBox_EmpMaxSecond.Text = secondMax.ToString();
                    }
                    #endregion
                    #region 绑定最小工作时间
                    if (dt.Rows[0][3].ToString().CompareTo("") == 0)
                    {
                        textBox_EmpMaxHour.Text = "0";
                        textBox_EmpMaxMinute.Text = "0";
                        textBox_EmpMaxSecond.Text = "0";
                    }
                    else
                    {
                        int intMin = Convert.ToInt32(dt.Rows[0][3]);
                        int hourMin = intMin / 3600;
                        int minuteMin = (intMin - hourMin * 3600) / 60;
                        int secondMin = intMin % 60;
                        textBox_EmpMinHour.Text = hourMin.ToString();
                        textBox_EmpMinMinute.Text = minuteMin.ToString();
                        textBox_EmpMinSecond.Text = secondMin.ToString();
                    }
                    #endregion
                }
            }
        }

        #endregion

        #region【事件: 自动根据工种填入最大、最小工作时间】

        private void comboBox_EmpWorkTypeName_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox_EmpWorkTypeName.SelectedValue != null && Convert.ToInt32(comboBox_EmpWorkTypeName.SelectedValue) != 0)
            {
                rdb_WorkType.Enabled = true;
                if (rdb_WorkType.Checked)
                {
                    DataTable dtWorkSet = aebll.GetWorkTypeSysSetTab(Convert.ToInt32(comboBox_EmpWorkTypeName.SelectedValue));
                    if (dtWorkSet != null && dtWorkSet.Rows.Count != 0)
                    {
                        #region 绑定最大工作时间
                        if (dtWorkSet.Rows[0][2].ToString().CompareTo("") == 0)
                        {
                            textBox_EmpMaxHour.Text = "0";
                            textBox_EmpMaxMinute.Text = "0";
                            textBox_EmpMaxSecond.Text = "0";
                        }
                        else
                        {
                            int intMax = Convert.ToInt32(dtWorkSet.Rows[0][2]);
                            int hourMax = intMax / 3600;
                            int minuteMax = (intMax - hourMax * 3600) / 60;
                            int secondMax = intMax % 60;
                            textBox_EmpMaxHour.Text = hourMax.ToString();
                            textBox_EmpMaxMinute.Text = minuteMax.ToString();
                            textBox_EmpMaxSecond.Text = secondMax.ToString();
                        }
                        #endregion
                        #region 绑定最小工作时间
                        if (dtWorkSet.Rows[0][3].ToString().CompareTo("") == 0)
                        {
                            textBox_EmpMaxHour.Text = "0";
                            textBox_EmpMaxMinute.Text = "0";
                            textBox_EmpMaxSecond.Text = "0";
                        }
                        else
                        {
                            int intMin = Convert.ToInt32(dtWorkSet.Rows[0][3]);
                            int hourMin = intMin / 3600;
                            int minuteMin = (intMin - hourMin * 3600) / 60;
                            int secondMin = intMin % 60;
                            textBox_EmpMinHour.Text = hourMin.ToString();
                            textBox_EmpMinMinute.Text = minuteMin.ToString();
                            textBox_EmpMinSecond.Text = secondMin.ToString();
                        }
                        #endregion
                    }
                }
            }
            else
            {
                if (rdb_WorkType.Checked)
                {
                    rdb_Dept.Checked = true;
                }
                rdb_WorkType.Enabled = false;
            }
        }

        #endregion

        #region【事件：保存】

        private void bt_AddEmpSave_Click(object sender, EventArgs e)
        {
            if (CheckingEmployeeBaseInfo())
            {
                if (tempEmpID == -1)    //新增
                {
                    SaveEmployeeData();
                }
                else                    //修改
                {
                    UpDateEmployee();
                }

                if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                {
                    frmEi.Refresh_Emp(); 
                }
                else                                //热备版，启用定时器
                {
                    frmEi.HostBackRefresh(true);
                }
            }
        }

        #endregion

        #region【事件：重置】

        private void bt_AddEmpReset_Click(object sender, EventArgs e)
        {
            EmpReset(this.tbc_EmpInfo);
            rdb_Dept.Checked = true;
            textBox_EmpHeight.Text = textBox_EmpWeight.Text = "0";

            ptb_EmpPhoto.Image = null;              //清空员工照片
            bPhoto = null;                          //清空员工照片的Byte[]数组

            if (rdb_Dept.Checked)                //启用模式为 按部门设置
            {
                DataTable dt = aebll.GetDeptSysSetTab(Convert.ToInt32(comboBox_EmployeeDepartment.SelectedValue));
                if (dt != null && dt.Rows.Count != 0)
                {
                    #region 绑定最大工作时间
                    if (dt.Rows[0][2].ToString().CompareTo("") == 0)
                    {
                        //textBox_EmpMaxHour.Text = "0";
                        //textBox_EmpMaxMinute.Text = "0";
                        //textBox_EmpMaxSecond.Text = "0";
                    }
                    else
                    {
                        int intMax = Convert.ToInt32(dt.Rows[0][2]);
                        int hourMax = intMax / 3600;
                        int minuteMax = (intMax - hourMax * 3600) / 60;
                        int secondMax = intMax % 60;
                        textBox_EmpMaxHour.Text = hourMax.ToString();
                        textBox_EmpMaxMinute.Text = minuteMax.ToString();
                        textBox_EmpMaxSecond.Text = secondMax.ToString();
                    }
                    #endregion
                    #region 绑定最小工作时间
                    if (dt.Rows[0][3].ToString().CompareTo("") == 0)
                    {
                        //textBox_EmpMinHour.Text = "0";
                        //textBox_EmpMinMinute.Text = "0";
                        //textBox_EmpMinSecond.Text = "0";
                    }
                    else
                    {
                        int intMin = Convert.ToInt32(dt.Rows[0][3]);
                        int hourMin = intMin / 3600;
                        int minuteMin = (intMin - hourMin * 3600) / 60;
                        int secondMin = intMin % 60;
                        textBox_EmpMinHour.Text = hourMin.ToString();
                        textBox_EmpMinMinute.Text = minuteMin.ToString();
                        textBox_EmpMinSecond.Text = secondMin.ToString();
                    }
                    #endregion
                }
                textBox_EmpMaxHour.Enabled = false;
                textBox_EmpMaxMinute.Enabled = false;
                textBox_EmpMaxSecond.Enabled = false;
                textBox_EmpMinHour.Enabled = false;
                textBox_EmpMinMinute.Enabled = false;
                textBox_EmpMinSecond.Enabled = false;
            }
        }

        #endregion

        #region【事件：返回】

        private void bt_AddEmpClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void textBox_EmployeeNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_EmplyeeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_EmployeeDemo_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_EmpName2_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_EmployeeIdentityCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_EmployeeNation_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_Company_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_EmpStateOfHealth_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_EmployeeGraduateFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_EmployeeSpecialty_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_EmployeeNativePlace_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_EmployeeCensusRegister_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_EmployeeHomeAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_EmployeeTel2_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_EmployeeTel1_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_EmpGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_EmpWorkPlace_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_EmployeeArchives_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private string GetConfigValue(string appKey)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(System.Windows.Forms.Application.ExecutablePath + @".config");

                XmlNode xNode;
                XmlElement xElem;
                xNode = xDoc.SelectSingleNode("//appSettings");
                xElem = (XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
                if (xElem != null)
                    return xElem.GetAttribute("value");
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        } 

    }
}
