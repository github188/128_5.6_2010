using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDataBase;
using KJ128NDBTable;

namespace KJ128NMainRun.AttendanceInfoSet
{
    public partial class NewHolidayTypeSetAdd : Form
    {
        #region 【自定义参数】
        /// <summary>
        /// 请假管理逻辑对象
        /// </summary>
        private HolidayManageBLL hoilidayBll = new HolidayManageBLL();
        private HolidayTypeBLL holidayTypeBll = new HolidayTypeBLL();
        /// <summary>
        /// 窗体显示类型
        /// </summary>
        private int m_type;
        long id = 0;
        private DataGridViewRow m_dgvRow;
        /// <summary>
        /// 获取的数据
        /// </summary>
        public DataGridViewRow DgvRow
        {
            set { m_dgvRow = value; }
        }

        private NewHolidayTypeSet m_HoilidayType;

        /// <summary>
        /// 部门逻辑对象
        /// </summary>
        private DeptBLL deptBll = new DeptBLL();

        DBAcess db = new DBAcess();
        private int state = 0;
        #endregion


        #region 【构造函数】
        public NewHolidayTypeSetAdd(int type,NewHolidayTypeSet newHoilidayType)
        {
            InitializeComponent();
            m_type = type;
            m_HoilidayType = newHoilidayType;
            deptBll.getDeptAddAll(cmbDept);
            holidayTypeBll.GetHolidayTypeAddAll(cmbHoiliday);

            //Czlt-2011-04-02 - 加载班次信息
            GetClass();
        }
        #endregion

        #region 【自定义方法】

        #region 【方法：绑定数据】
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindText()
        {
            try
            {
                cmbDept.Text = m_dgvRow.Cells[6].Value.ToString();
                cmbCardID.Text = m_dgvRow.Cells[2].Value.ToString();
                txtName.Text = m_dgvRow.Cells[3].Value.ToString();
                cmbHoiliday.Text = m_dgvRow.Cells[5].Value.ToString();
                dateTimePickerData.Value =DateTime.Parse(m_dgvRow.Cells[7].Value.ToString());
                id = long.Parse(m_dgvRow.Cells[1].Value.ToString());

                cmbDept.Enabled = false;
                cmbCardID.Enabled = false;
                txtName.Enabled = false;
            }
            catch
            { }
        }
        #endregion

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

        #region 【方法：保存前期判断】
        /// <summary>
        /// 判断前期保存条件
        /// </summary>
        /// <returns></returns>
        private bool Check()
        {
            if (cmbDept.SelectedIndex<1)
            {
                SetShowInfo("请您选择部门", Color.Blue);
                return false;
            }
            if (cmbCardID.SelectedIndex<1)
            {
                SetShowInfo("请您选择标识卡号", Color.Blue);
                return false;
            }
            if (cmbHoiliday.SelectedIndex<1)
            {
                SetShowInfo("请您选择请假类别", Color.Blue);
                return false;
            }
            return true;
        }
        #endregion

        #endregion

        #region 【系统事件方法】
        #region 【事件方法：窗体加载】
        private void NewHolidayTypeSetAdd_Load(object sender, EventArgs e)
        {
            switch (m_type)
            {
                case 1:
                    this.Text = "新增请假管理";
                    cmbDept.SelectedIndex = 0;
                    cmbHoiliday.SelectedIndex = 0;
                    dateTimePickerData.Value = DateTime.Now;
                    break;
                case 2:
                    this.Text = "修改请假管理";
                    state = 0;
                    BindText();
                    break;
            }
        }
        #endregion

        #region 【事件方法：关闭窗体】
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 【事件方法：重置输入框】
        private void btnReset_Click(object sender, EventArgs e)
        {
            switch (m_type)
            {
                case 1:
                    txtName.Text = "";
                    cmbDept.SelectedIndex = 0;
                    cmbHoiliday.SelectedIndex = 0;
                    dateTimePickerData.Value = DateTime.Now;
                    break;
                case 2:
                    state = 0;
                    BindText();
                    break;
            }
        }
        #endregion

        #region 【事件方法：保存数据】
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strError = "";
            int rowCount = 0;
            if (Check())
            {
                switch (m_type)
                {
                    case 1://添加
                        rowCount = hoilidayBll.HolidayManage_Insert(int.Parse(cmbCardID.Text), txtName.Text,int.Parse(cmbDept.SelectedValue.ToString()), dateTimePickerData.Value.ToString("yyyy-MM-dd"), cmbHoiliday.Text, 0,Convert.ToInt32(cmbClassID.SelectedValue.ToString()), out strError);
                        if (!strError.Equals("Succeeds"))
                        {
                            SetShowInfo("保存失败", Color.Red);
                            return;
                        }
                        if (rowCount<=0)
                        {
                            SetShowInfo("该人员请假信息已输入", Color.Red);
                            return;
                        }
                        SetShowInfo("保存成功", Color.Black);
                        break;
                    case 2://修改
                        hoilidayBll.HolidayManage_Update(id, int.Parse(cmbCardID.Text), txtName.Text, int.Parse(cmbDept.SelectedValue.ToString()), dateTimePickerData.Value.ToString("yyyy-MM-dd"), cmbHoiliday.Text, 0, Convert.ToInt32(cmbClassID.SelectedValue.ToString()), out strError);
                        if (!strError.Equals("Succeeds"))
                        {
                            SetShowInfo("修改失败", Color.Red);
                            return;
                        }
                        SetShowInfo("修改成功", Color.Black);
                        break;
                }

                if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                {
                    m_HoilidayType.m_StrWhere = " and h.DataAttendance>='" + m_HoilidayType.dateTimePickerBegin.Value.ToString("yyyy-MM-dd") + "' and h.DataAttendance<='" + m_HoilidayType.dateTimePickerEnd.Value.ToString("yyyy-MM-dd") + "'";
                    m_HoilidayType.BindDataGridView(1, m_HoilidayType.dateTimePickerBegin.Value.ToString("yyyyM"));
                }
                else                                //热备版，启用定时器
                {
                    m_HoilidayType.HostBackRefresh(true);
                }
            }
        }
        #endregion

        #region 【事件方法：部门下拉列表框被改变】
        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCardID.DataSource = null;
            cmbCardID.Items.Clear();
            if (cmbDept.SelectedIndex > 0)
            {
                //绑定人员下拉列表
                hoilidayBll.CardInfoBindComboBox(cmbCardID, cmbDept.SelectedValue.ToString());
                switch (m_type)
                {
                    case 1:
                        cmbCardID.SelectedIndex = 0;
                        break;
                    case 2:
                        if (state == 0)
                        {
                            cmbCardID.SelectedValue = m_dgvRow.Cells[6].Value.ToString();
                            state = 1;
                        }
                        else
                        {
                            cmbCardID.SelectedIndex = 0;
                        }
                        break;
                }
            }
            else
            {
                cmbCardID.DataSource = null;
                cmbCardID.Items.Clear();
                cmbCardID.Items.Add("所有");
                cmbCardID.SelectedIndex = 0;
            }
        }
        #endregion

        #region 【事件方法：人员下拉列表框被改变】
        private void cmbCardID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCardID.SelectedIndex > 0)
            {
                txtName.Text = cmbCardID.SelectedValue.ToString();
            }
            else
            {
                txtName.Text = "";
            }
        }
        #endregion
        #endregion


        #region 【Czlt-2011-04-02-添加班次】
        private void GetClass()
        {
            cmbClassID.DataSource = db.GetDataSet("select ID,NameShort from TimerInterval ").Tables[0];
            cmbClassID.DisplayMember = "NameShort";
            cmbClassID.ValueMember = "ID";
        }
        #endregion

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

    }
}
