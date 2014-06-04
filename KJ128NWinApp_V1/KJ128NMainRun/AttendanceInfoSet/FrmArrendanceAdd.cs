using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NDataBase;
using Microsoft.VisualBasic;

namespace KJ128NMainRun.AttendanceInfoSet
{
    public partial class FrmArrendanceAdd : Form
    {
        #region 【自定义参数】
        /// <summary>
        /// 班制逻辑对象
        /// </summary>
        private InfoClassBLL infoClassBll = new InfoClassBLL();
        /// <summary>
        /// 班次逻辑对象
        /// </summary>
        private TimerIntervalBLL timerIntervalBll = new TimerIntervalBLL();
        /// <summary>
        /// 窗体显示类型
        /// </summary>
        private int m_type;
        private FrmAttendanceManger m_FrmAttendance;

        private DataGridViewRow m_dgvRow;
        /// <summary>
        /// 获取的数据
        /// </summary>
        public DataGridViewRow DgvRow
        {
            set { m_dgvRow = value; }
        }


        //************czlt-2010-8-24*start*******       
        /// <summary>
        /// 班次显示表
        /// </summary>
        private DataTable dtCheckTimeInterval = new DataTable();
        private string timeMin = "";


        //************czlt-2010-8-24*end*********

        #endregion

        #region 【构造函数】
        public FrmArrendanceAdd(int type,FrmAttendanceManger frmAttendance)
        {
            InitializeComponent();
            //加载班制信息到下拉列表框
            infoClassBll.InfoClass_BindComboBox(cmbClass);
            m_type = type;
            m_FrmAttendance = frmAttendance;
            switch (type)
            {
                case 1://添加
                    this.Text = "新增班次";
                    //班制下拉列表框默认选择第一个
                    cmbClass.SelectedIndex = 0;
                    cmbBeginTime.SelectedIndex = 0;
                    cmbData.SelectedIndex = 0;
                    cmbEndTime.SelectedIndex = 0;
                    break;
                case 2://修改
                    this.Text = "修改班次";
                    txtClassName.Enabled = false;
                    break;
                default://查看
                    this.Text = "查看班次";
                    btnClose.Visible = false;
                    btnReset.Visible = false;
                    btnSave.Visible = false;
                    
                    break;
            }
            
            
        }
        #endregion

        #region 【自定义方法】

        #region 【数据显示到文本框和下拉列表框】
        /// <summary>
        /// 绑定文本框和选择项
        /// </summary>
        private void BindText()
        {
            try
            {
                txtClassName.Text = m_dgvRow.Cells["IntervalName"].Value.ToString();
                txtClassShortName.Text = m_dgvRow.Cells["NameShort"].Value.ToString();
                switch (m_dgvRow.Cells["DataAttendanceType"].Value.ToString())
                {
                    case "-1":
                        cmbData.SelectedIndex = 1;
                        break;
                    case "0":
                        cmbData.SelectedIndex = 2;
                        break;
                    case "1":
                        cmbData.SelectedIndex = 3;
                        break;
                    default:
                        cmbData.SelectedIndex = 0;
                        break;
                }
                cmbClass.SelectedValue = m_dgvRow.Cells["ClassID"].Value.ToString();
                switch (m_dgvRow.Cells["SwDateType"].Value.ToString())
                {
                    case "-1":
                        cmbBeginTime.SelectedIndex = 1;
                        break;
                    case "0":
                        cmbBeginTime.SelectedIndex = 2;
                        break;
                    case "1":
                        cmbBeginTime.SelectedIndex = 3;
                        break;
                    default:
                        break;
                }
                switch (m_dgvRow.Cells["EWDateType"].Value.ToString())
                {
                    case "-1":
                        cmbEndTime.SelectedIndex = 1;
                        break;
                    case "0":
                        cmbEndTime.SelectedIndex = 2;
                        break;
                    case "1":
                        cmbEndTime.SelectedIndex = 3;
                        break;
                    default:
                        break;
                }
                DateTime dtimeB;
                try
                {
                    dtimeB = DateTime.Parse(m_dgvRow.Cells["StartWorkTime"].Value.ToString());

                }
                catch
                {
                    dtimeB = new DateTime(2000, 1, 1, 0, 0, 0);
                }
                txtBeginHour.Text = dtimeB.Hour.ToString();
                txtBeginMin.Text = dtimeB.Minute.ToString();
                DateTime dtimeE;
                try
                {
                    dtimeE = DateTime.Parse(m_dgvRow.Cells["EndWorkTime"].Value.ToString());
                }
                catch
                {
                    dtimeE = new DateTime(2000, 1, 1, 0, 0, 0);
                }
                txtEndHour.Text = dtimeE.Hour.ToString();
                txtEndMin.Text = dtimeE.Minute.ToString();
                txtID.Text = m_dgvRow.Cells["ID"].Value.ToString();
                txtBeforeMin.Text = m_dgvRow.Cells["SWFrontTime"].Value.ToString();
            }
            catch { }
        }
        #endregion

        /// <summary>
        /// 操作数据库
        /// </summary>
        /// <param name="type"></param>
        private void OperatorData(int type)
        {
            string strError="";
            #region 【从界面获取输入数据】
            
            string strClassName = txtClassName.Text;
            string strClassShortName = txtClassShortName.Text;
            string strBeginTime = txtBeginHour.Text + ":" + txtBeginMin.Text + ":00";
            string strEndTime = txtEndHour.Text + ":" + txtEndMin.Text + ":00";
            int begionTimeType;
            DateTime dtimeBegin;
            switch (cmbBeginTime.SelectedIndex)
            {
                case 1:
                    begionTimeType = -1;
                    try
                    {
                        dtimeBegin = new DateTime(2000, 1, 1, int.Parse(txtBeginHour.Text), int.Parse(txtBeginMin.Text), 0);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("时间输入有误,请检查...", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    break;
                case 3:
                    begionTimeType = 1;
                    try
                    {
                        dtimeBegin = new DateTime(2000, 1, 3, int.Parse(txtBeginHour.Text), int.Parse(txtBeginMin.Text), 0);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("时间输入有误,请检查...", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    break;
                default:
                    begionTimeType = 0;
                    try
                    {
                        dtimeBegin = new DateTime(2000, 1, 2, int.Parse(txtBeginHour.Text), int.Parse(txtBeginMin.Text), 0);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("时间输入有误,请检查...", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    break;
            }
            int endTimeType;
            DateTime dtimeEnd;
            switch (cmbEndTime.SelectedIndex)
            {
                case 1:
                    endTimeType = -1;
                    try
                    {
                        dtimeEnd = new DateTime(2000, 1, 1, int.Parse(txtEndHour.Text), int.Parse(txtEndMin.Text), 0);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("时间输入有误,请检查...", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    break;
                case 3:
                    endTimeType = 1;
                    try
                    {
                        dtimeEnd = new DateTime(2000, 1, 3, int.Parse(txtEndHour.Text), int.Parse(txtEndMin.Text), 0);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("时间输入有误,请检查...", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    break;
                default:
                    endTimeType = 0;
                    try
                    {
                        dtimeEnd = new DateTime(2000, 1, 2, int.Parse(txtEndHour.Text), int.Parse(txtEndMin.Text), 0);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("时间输入有误,请检查...", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    break;
            }
            int beforeTime = int.Parse(txtBeforeMin.Text);
            int lateTime = int.Parse(((TimeSpan)(dtimeEnd - dtimeBegin)).TotalMinutes.ToString());
            int classID = int.Parse(cmbClass.SelectedValue.ToString());
            int timeType;
            switch (cmbData.SelectedIndex)
            {
                case 1:
                    timeType = -1;
                    break;
                case 3:
                    timeType = 1;
                    break;
                default:
                    timeType = 0;
                    break;
            }
            #endregion
            int rowCount = 0;

            //********czlt-2010*新增判断检测时间区间是不是完整********
            if (IsTimeCheck(type, classID, dtimeBegin))
            {
                switch (type)
                {
                    case 1://添加
                        rowCount = timerIntervalBll.TimerInterval_Insert(strClassName, strClassShortName, strBeginTime, strEndTime, begionTimeType, endTimeType, beforeTime, lateTime, 0, 0, classID, timeType, out strError);
                        if (!strError.Equals("Succeeds"))
                        {
                            SetShowInfo("保存失败", Color.Red);
                            return;
                        }
                        if (rowCount > 0)
                        {
                            SetShowInfo("保存成功", Color.Black);
                        }
                        else
                        {
                            SetShowInfo("添加重复数据", Color.Red);
                        }
                        break;
                    case 2://修改
                        int id = int.Parse(txtID.Text);
                        timerIntervalBll.TimerInterval_Update(id, strClassName, strClassShortName, strBeginTime, strEndTime, begionTimeType, endTimeType, beforeTime, lateTime, 0, 0, classID, timeType, out strError);
                        if (!strError.Equals("Succeeds"))
                        {
                            SetShowInfo("修改失败", Color.Red);
                            return;
                        }
                        SetShowInfo("修改成功", Color.Black);
                        break;
                    default:
                        return;
                }

                //Czlt-2010-9-21
                UpdateSWfrontTime(beforeTime.ToString(), classID.ToString());

                if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                {
                    m_FrmAttendance.Bind("");
                    m_FrmAttendance.SetTimeIntervalTreeView();
                }
                else                                //热备版，启用定时器
                {
                    m_FrmAttendance.HostBackRefresh(true);
                }
            }
            
        }

        #region 【界面框输入判断和逻辑判断】
        /// <summary>
        /// 界面框判断和逻辑判断
        /// </summary>
        /// <returns></returns>
        private bool Check()
        {
            if (txtClassName.Text.Trim().Equals(""))
            {
                SetShowInfo("请输入班次全称", Color.Blue);
                return false;
            }
            if (txtClassShortName.Text.Trim().Equals(""))
            {
                SetShowInfo("请输入班次简称", Color.Blue);
                return false;
            }
            if (cmbData.SelectedIndex<1)
            {
                SetShowInfo("请选择记工日期", Color.Blue);
                return false;
            }
            if (cmbClass.SelectedIndex<1)
            {
                SetShowInfo("请选择所属班制", Color.Blue);
                return false;
            }
            if (cmbBeginTime.SelectedIndex<1)
            {
                SetShowInfo("请选择开始时间的排班日", Color.Blue);
                return false;
            }
            if (txtBeginHour.Text.Trim().Equals(""))
            {
                SetShowInfo("请输入开始时间的小时数", Color.Blue);
                return false;
            }
            if (!Information.IsNumeric(txtBeginHour.Text))
            {
                SetShowInfo("开始时间的小时数输入错误，请输入数字", Color.Blue);
                return false;
            }
            if (int.Parse(txtBeginHour.Text)<0 || int.Parse(txtBeginHour.Text)>23)
            {
                SetShowInfo("开始时间的小时数输入范围应为（0-23），请重新输入", Color.Blue);
                return false;
            }
            if (txtBeginMin.Text.Trim().Equals(""))
            {
                SetShowInfo("请输入开始时间的分钟数", Color.Blue);
                return false;
            }
            if (!Information.IsNumeric(txtBeginMin.Text))
            {
                SetShowInfo("开始时间的分钟数输入错误，请输入数字", Color.Blue);
                return false;
            }
            if (int.Parse(txtBeginMin.Text) < 0 || int.Parse(txtBeginMin.Text) > 60)
            {
                SetShowInfo("开始时间的分钟数输入范围应为（0-59），请重新输入", Color.Blue);
                return false;
            }
            if (cmbEndTime.SelectedIndex < 1)
            {
                SetShowInfo("请选择结束时间的排班日", Color.Blue);
                return false;
            }
            if (txtEndHour.Text.Trim().Equals(""))
            {
                SetShowInfo("请输入结束时间的小时数", Color.Blue);
                return false;
            }
            if (!Information.IsNumeric(txtEndHour.Text))
            {
                SetShowInfo("结束时间的小时数输入错误，请输入数字", Color.Blue);
                return false;
            }
            if (int.Parse(txtEndHour.Text) < 0 || int.Parse(txtEndHour.Text) > 23)
            {
                SetShowInfo("结束时间的小时数输入范围应为（0-23），请重新输入", Color.Blue);
                return false;
            }
            if (txtEndMin.Text.Trim().Equals(""))
            {
                SetShowInfo("请输入结束时间的分钟数", Color.Blue);
                return false;
            }
            if (!Information.IsNumeric(txtEndMin.Text))
            {
                SetShowInfo("结束时间的分钟数输入错误，请输入数字", Color.Blue);
                return false;
            }
            if (int.Parse(txtEndMin.Text) < 0 || int.Parse(txtEndMin.Text) > 60)
            {
                SetShowInfo("结束时间的分钟数输入范围应为（0-59），请重新输入", Color.Blue);
                return false;
            }
            if (cmbBeginTime.SelectedIndex > cmbEndTime.SelectedIndex)
            {
                SetShowInfo("开始时间应比结束时间小，请重新输入", Color.Blue);
                return false;
            }
            else if (cmbBeginTime.SelectedIndex == cmbEndTime.SelectedIndex)
            {
                if (int.Parse(txtBeginHour.Text)*60 + int.Parse(txtBeginMin.Text) >=int.Parse(txtEndHour.Text)*60 +int.Parse(txtEndMin.Text))
                {
                    SetShowInfo("开始时间应比结束时间小，请重新输入", Color.Blue);
                    return false;
                }
            }
            if (txtBeforeMin.Text.Trim().Equals(""))
            {
                SetShowInfo("请输入提前考勤分钟数", Color.Blue);
                return false;
            }
            if (!Information.IsNumeric(txtBeforeMin.Text))
            {
                SetShowInfo("提前考勤分钟数输入错误，请输入数字", Color.Blue);
                return false;
            }
            if (int.Parse(txtBeforeMin.Text) < 0)
            {
                SetShowInfo("提前考勤分钟数输入错误，请输入正整数", Color.Blue);
                return false;
            }

            return true;
        }
        #endregion 

        /// <summary>
        /// 设置显示提示信息
        /// </summary>
        /// <param name="strMessage">显示信息</param>
        /// <param name="c">颜色</param>
        private void SetShowInfo(string strMessage, Color c)
        {
            labMessage.Visible = true;
            labMessage.ForeColor = c;
            labMessage.Text = strMessage;
        }
        #endregion

        #region 【系统事件方法】
        private void FrmArrendanceAdd_Load(object sender, EventArgs e)
        {
            switch (m_type)
            {
                case 1:
                    break;
                case 2:
                    BindText();
                    break;
                default:
                    BindText();
                    groupBox1.Enabled = false;
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                OperatorData(m_type);

                //Czlt-2011-12-10 更改时间
                timerIntervalBll.UpdateTime();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            switch (m_type)
            {
                case 1:
                    txtClassName.Text = "";
                    txtClassShortName.Text = "";
                    cmbData.SelectedIndex = 0;
                    cmbClass.SelectedIndex = 0;
                    cmbBeginTime.SelectedIndex = 0;
                    cmbEndTime.SelectedIndex = 0;
                    txtBeginHour.Text = "";
                    txtBeginMin.Text = "";
                    txtEndHour.Text = "";
                    txtEndMin.Text = "";
                    txtBeforeMin.Text = "";
                    break;
                case 2:
                    BindText();
                    break;
            }
        }
        #endregion


        #region【Czlt-2010-10-19】 班次功能新增

        #region 【**czlt-2010-8-24*新增时间区间判断方法**】
        /// <summary>
        /// 输入的时间检查
        /// </summary>
        /// <returns></returns>
        private bool IsTimeCheck(int type, int classid, DateTime startTime)
        {
            string strSqlWhere = string.Empty;
            DateTime checkOldEndTime = DateTime.Now;
            strSqlWhere = "classid=" + classid + " order by endWorkTime ";
            dtCheckTimeInterval = timerIntervalBll.getTimeInterval(strSqlWhere);
            //新增
            if (type == 1)
            {
                if (dtCheckTimeInterval.Rows.Count > 0)
                {
                    checkOldEndTime = DateTime.Parse(dtCheckTimeInterval.Rows[(dtCheckTimeInterval.Rows.Count - 1)].ItemArray[4].ToString());
                    checkOldEndTime = GetEndTime(checkOldEndTime);
                    int checkTime = int.Parse(((TimeSpan)(startTime - checkOldEndTime)).TotalMinutes.ToString());
                    if (checkTime > 0)
                    {
                        SetShowInfo("本班次开始的时间必须要小于或等于上一班次的结束时间:" + dtCheckTimeInterval.Rows[(dtCheckTimeInterval.Rows.Count - 1)].ItemArray[4].ToString().Substring(10, 6), Color.Blue);
                        timeMin = dtCheckTimeInterval.Rows[(dtCheckTimeInterval.Rows.Count - 1)].ItemArray[4].ToString().Substring(10, 6);
                        this.btnUpdate.Visible = true;
                        return false;
                    }
                }
            }
            //修改
            else if (type == 2)
            {
                if (dtCheckTimeInterval.Rows.Count > 0)
                {
                    int shiftid = int.Parse(txtID.Text);
                    int checkIndex = 0;
                    for (int i = 0; i < dtCheckTimeInterval.Rows.Count; i++)
                    {
                        if (dtCheckTimeInterval.Rows[i].ItemArray[0].ToString().Trim().Equals(shiftid.ToString().Trim()))
                        {
                            checkIndex = i;
                        }
                    }
                    if (checkIndex != 0)
                    {
                        checkOldEndTime = DateTime.Parse(dtCheckTimeInterval.Rows[(checkIndex - 1)].ItemArray[4].ToString());
                        checkOldEndTime = GetEndTime(checkOldEndTime);
                        int checkTime = int.Parse(((TimeSpan)(startTime - checkOldEndTime)).TotalMinutes.ToString());
                        if (checkTime > 0)
                        {
                            SetShowInfo("本班次开始的时间必须要小于或等于上一班次的结束时间:" + dtCheckTimeInterval.Rows[(checkIndex - 1)].ItemArray[4].ToString().Substring(10, 6), Color.Blue);
                            timeMin = dtCheckTimeInterval.Rows[(checkIndex - 1)].ItemArray[4].ToString().Substring(10, 6);
                            this.btnUpdate.Visible = true;
                            return false;
                        }
                    }
                }
            }
            return true;

        }

        //返回符合规定的结束时间
        private DateTime GetEndTime(DateTime endOldTime)
        {
            DateTime dtimeEnd = new DateTime();
            string[] str = endOldTime.ToShortTimeString().Split(':');

            switch (cmbEndTime.SelectedIndex)
            {
                case 1:
                    try
                    {
                        dtimeEnd = new DateTime(2000, 1, 1, int.Parse(str[0]), int.Parse(str[1]), 0);
                    }
                    catch (Exception ex)
                    {
                    }
                    break;
                case 3:
                    try
                    {
                        dtimeEnd = new DateTime(2000, 1, 3, int.Parse(str[0]), int.Parse(str[1]), 0);
                    }
                    catch (Exception ex)
                    {
                    }
                    break;
                default:
                    try
                    {
                        dtimeEnd = new DateTime(2000, 1, 2, int.Parse(str[0]), int.Parse(str[1]), 0);
                    }
                    catch (Exception ex)
                    {
                    }
                    break;
            }

            return dtimeEnd;
        }

        //Czlt-2010-9-21- 修改提前多久计时
        private void UpdateSWfrontTime(string swAfterTime, string strClassId)
        {
            string strWhere = "classID = " + strClassId;
            timerIntervalBll.UpdateSWAfterTimeBll(swAfterTime, strWhere);
        }


        #endregion


        /// <summary>
        /// 建议功能修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string[] strTime = timeMin.Split(':');
            this.txtBeginHour.Text = strTime[0].ToString().Trim();
            this.txtBeginMin.Text = strTime[1].ToString();
            this.btnUpdate.Visible = false;
        }
        #endregion

        private void txtClassName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtClassShortName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

    }
}
