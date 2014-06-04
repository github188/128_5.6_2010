using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NDataBase;

namespace KJ128NMainRun.AssociateWithEmp
{
    public partial class FrmAssociateAdd : Form
    {
        #region 【自定义参数】
        private AssociateBLL associateBll = new AssociateBLL();
        /// <summary>
        /// 异地交接班信息配置界面
        /// </summary>
        private FrmAssociateManage m_frmAssociateManage;
        #endregion

        public FrmAssociateAdd(FrmAssociateManage frmAssociateManage)
        {
            InitializeComponent();
            m_frmAssociateManage = frmAssociateManage;
        }

        #region 【自定义方法】
        #region 【方法：设置显示提示信息】
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

        #region 【方法：获取传输分站下拉列表框信息】
        /// <summary>
        /// 获取传输分站下拉列表框信息
        /// </summary>
        private void GetCmbStationID()
        {
            associateBll.GetStationInfoComboBox(cmbStationID);
        }
        #endregion

        #region 【方法：获取读卡分站下拉列表框信息】
        /// <summary>
        /// 获取读卡分站下拉列表框信息
        /// </summary>
        /// <param name="stationHeadID"></param>
        private void GetCmbStationHeadID(string strWhere)
        {
            associateBll.GetStationHeadInfoComboBox(cmbStationHeadID, strWhere);
        }
        #endregion

        #region 【方法：获取工种下拉列表框信息】
        /// <summary>
        /// 获取工种的下拉列表框信息
        /// </summary>
        private void GetCmbWorkType()
        {
            associateBll.GetWorkTypeInfoComboBox(cmbWorkType1);
            associateBll.GetWorkTypeInfoComboBox(cmbWorkType2);
        }
        #endregion

        #region 【方法：获取人员姓名下拉列表框信息】
        /// <summary>
        /// 获取人员姓名下拉列表框信息
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="strWhere"></param>
        private void GetCmbEmpName(ComboBox cmb, string strWhere)
        {
            associateBll.GetEmpInfoComboBox(cmb, strWhere);
        }
        #endregion


        #region 【方法：添加前期判断】
        /// <summary>
        /// 添加前期判断
        /// </summary>
        /// <returns></returns>
        private bool Check()
        {
            string message = "";
            if (cmbStationID.SelectedIndex < 1)
            {
                message = "请选择传输分站号";
                SetShowInfo(message, Color.Red);
                cmbStationID.Focus();
                return false;
            }
            if (cmbStationHeadID.SelectedIndex < 1)
            {
                message = "请选择读卡分站号";
                SetShowInfo(message, Color.Red);
                cmbStationHeadID.Focus();
                return false;
            }

            DateTime dtimeBegin = DateTime.Parse(dtpBeginDate.Value.ToString("yyyy-MM-dd") + " " + dtpBeginTime.Value.ToString("HH:mm:ss"));

            if (DateTime.Now.AddHours(1) > dtimeBegin)
            {
                message = "保存的配置时间必须大于当前时间后一小时";
                SetShowInfo(message, Color.Red);
                return false;
            }

            if (dtpBeginDate.Value>dtpEndDate.Value)
            {
                message = "结束日期必须大于开始日期";
                SetShowInfo(message, Color.Red);
                return false;
            }

            if (dtpBeginDate.Value.AddDays(90)<dtpEndDate.Value)
            {
                message = "输入的日期范围不能大于90天";
                SetShowInfo(message, Color.Red);
                return false;
            }

            if (cmbWorkType1.SelectedIndex < 1)
            {
                message = "请选择交接人员1的工种信息";
                SetShowInfo(message, Color.Red);
                cmbWorkType1.Focus();
                return false;
            }
            if (cmbEmpName1.SelectedIndex < 1)
            {
                message = "请选择交接人员1的姓名";
                SetShowInfo(message, Color.Red);
                cmbEmpName1.Focus();
                return false;
            }
            if (cmbWorkType2.SelectedIndex < 1)
            {
                message = "请选择交接人员2的工种信息";
                SetShowInfo(message, Color.Red);
                cmbWorkType2.Focus();
                return false;
            }
            if (cmbEmpName2.SelectedIndex < 1)
            {
                message = "请选择交接人员2的姓名";
                SetShowInfo(message, Color.Red);
                cmbEmpName2.Focus();
                return false;
            }
            if (cmbEmpName1.Text.Equals(cmbEmpName2.Text))
            {
                message = "不能选择同一个人，请重新选择";
                SetShowInfo(message, Color.Red);
                return false;
            }
            return true;
        }
        #endregion

        #endregion

        #region 【系统事件方法】
        #region 【事件方法：窗体加载】
        private void FrmAssociateAdd_Load(object sender, EventArgs e)
        {
            GetCmbStationID();
            GetCmbWorkType();
            cmbStationID.SelectedIndex = 0;
            cmbWorkType1.SelectedIndex = 0;
            cmbWorkType2.SelectedIndex = 0;
        }
        #endregion

        #region 【事件方法：传输分站号选择显示读卡分站信息】
        private void cmbStationID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strWhere = "1<>1";
            if (cmbStationID.SelectedIndex > 0)
            {
                strWhere = " stationAddress=" + cmbStationID.Text;
            }
            GetCmbStationHeadID(strWhere);
            cmbStationHeadID.SelectedIndex = 0;
        }
        #endregion

        #region 【事件方法：交接1中 工种选择显示人员姓名信息】
        private void cmbWorkType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strWhere = "1<>1";
            if (cmbWorkType1.SelectedIndex > 0)
            {
                strWhere = " workTypeID=" + cmbWorkType1.SelectedValue.ToString();
            }
            GetCmbEmpName(cmbEmpName1, strWhere);
            cmbEmpName1.SelectedIndex = 0;
        }
        #endregion

        #region 【事件方法：交接2中 工种选择显示人员姓名信息】
        private void cmbWorkType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strWhere = "1<>1";
            if (cmbWorkType2.SelectedIndex > 0)
            {
                strWhere = " workTypeID=" + cmbWorkType2.SelectedValue.ToString();
            }
            GetCmbEmpName(cmbEmpName2, strWhere);
            cmbEmpName2.SelectedIndex = 0;
        }
        #endregion

        #region 【事件方法：数据保存】
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                DateTime timeBegin = DateTime.Parse(dtpBeginDate.Value.ToString("yyyy-MM-dd") + " " + dtpBeginTime.Value.ToString("HH:mm:ss"));
                DateTime timeEnd = new DateTime();
                //获取保存的天数
                TimeSpan ts = (dtpEndDate.Value.Date - dtpBeginDate.Value.Date);
                int i = int.Parse(ts.TotalDays.ToString());
                //获取结束时间
                timeEnd = DateTime.Parse(dtpBeginDate.Value.ToString("yyyy-MM-dd") +" "+ dtpEndTime.Value.ToString("HH:mm:ss"));
                if (DateTime.Parse(dtpBeginTime.Value.ToString("HH:mm:ss")) > DateTime.Parse(timeEnd.ToString("HH:mm:ss")))//开始时间大于结束时间，则结束时间加一天
                {
                    timeEnd=timeEnd.AddDays(1);   
                }
                try
                {
                    for (int j = 0; j <= i; j++)
                    {
                        associateBll.AddAssociate(int.Parse(cmbStationID.Text), int.Parse(cmbStationHeadID.Text), txtStationHeadPlace.Text, timeBegin, timeEnd, int.Parse(cmbEmpName1.SelectedValue.ToString()), int.Parse(cmbEmpName2.SelectedValue.ToString()), cmbEmpName1.Text, cmbEmpName2.Text);
                        timeBegin = timeBegin.AddDays((double)1);
                        timeEnd = timeEnd.AddDays((double)1);
                    }
                    SetShowInfo("保存成功", Color.Black);
                }
                catch
                {
                    SetShowInfo("保存失败", Color.Red);
                }
                //刷新
                if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                {
                    m_frmAssociateManage.BindData(1);
                }
                else                                //热备版，启用定时器
                {
                    m_frmAssociateManage.HostBackRefresh(true);
                }
            }
        }
        #endregion

        #region 【事件方法：重置添加信息】
        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbStationID.SelectedIndex = 0;
            dtpBeginTime.Value = DateTime.Parse(DateTime.Now.AddHours(1).ToString("HH:mm:ss"));
            dtpEndTime.Value = dtpBeginTime.Value.AddHours(1);
            dtpBeginDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
            cmbWorkType1.SelectedIndex = 0;
            cmbWorkType2.SelectedIndex = 0;
            labMessage.Visible = false;
        }
        #endregion

        #region 【事件方法：关闭窗体】
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 【事件方法：读卡分站选择显示读卡分站安装位置】
        private void cmbStationHeadID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStationHeadID.SelectedIndex > 0)
            {
                txtStationHeadPlace.Text = cmbStationHeadID.SelectedValue.ToString();
            }
            else
            {
                txtStationHeadPlace.Text = "";
            }
        }
        #endregion

        private void txtStationHeadPlace_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }


        #endregion


    }
}
