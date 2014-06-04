using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NDataBase;

namespace KJ128NMainRun.AttendanceInfoSet
{
    public partial class FrmHoilidayAdd : Form
    {
        #region 【自定义参数】
        /// <summary>
        /// 窗体显示类型
        /// </summary>
        private int m_type;
        private A_NewHolidayMange m_frmHoilidayMange;
        private HolidayTypeBLL HTBLL = new HolidayTypeBLL();
        int id = 0;
        private DataGridViewRow m_dgvRow;
        /// <summary>
        /// 获取的数据
        /// </summary>
        public DataGridViewRow DgvRow
        {
            set { m_dgvRow = value; }
        }
        #endregion

        #region 【构造函数】
        public FrmHoilidayAdd(int type, A_NewHolidayMange frmHoilidayMange)
        {
            InitializeComponent();
            m_type = type;
            m_frmHoilidayMange = frmHoilidayMange;
        }
        #endregion


        #region 【自定义方法】
        #region 【方法：保存修改操作前期判断】
        /// <summary>
        /// 保存修改操作前期判断
        /// </summary>
        /// <returns></returns>
        private bool Check()
        {
            if (txtID.Text.Trim().Equals(""))
            {
                SetShowInfo("请输入假别编号", Color.Blue);
                return false;
            }

            if (txtName.Text.Trim().Equals(""))
            {
                SetShowInfo("请输入假别全称", Color.Blue);
                return false;
            }

            if (txtShortName.Text.Trim().Equals(""))
            {
                SetShowInfo("请输入假别简称", Color.Blue);
                return false;
            }
            return true;
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

        #region 【方法：获取信息】
        /// <summary>
        /// 获取从界面传过来的数据
        /// </summary>
        private void GetHoilidayInfo()
        {
            try
            {
                id = int.Parse(m_dgvRow.Cells["id"].Value.ToString());
                txtID.Text = m_dgvRow.Cells[2].Value.ToString();
                txtName.Text = m_dgvRow.Cells[3].Value.ToString();
                txtShortName.Text = m_dgvRow.Cells[4].Value.ToString();
                txtRemark.Text = m_dgvRow.Cells[5].Value.ToString();
            }
            catch
            { }
        }
        #endregion 
        #endregion

        #region 【系统事件方法】
        #region 【事件方法：窗体加载】
        private void FrmHoilidayAdd_Load(object sender, EventArgs e)
        {
            switch (m_type)
            {
                case 1://添加
                    this.Text = "新增假别";
                    break;
                case 2://修改
                    this.Text = "修改假别";
                    GetHoilidayInfo();
                    txtID.Enabled = false;

                    break;
            }
        }
        #endregion

        #region 【事件方法：窗体关闭】
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 【事件方法：输入框重置】
        private void btnReset_Click(object sender, EventArgs e)
        {
            switch (m_type)
            {
                case 1://添加
                    txtID.Text = "";
                    txtName.Text = "";
                    txtShortName.Text = "";
                    txtRemark.Text = "";
                    break;
                case 2://修改
                    GetHoilidayInfo();
                    break;
            }
        }
        #endregion

        #region 【事件方法：保存数据】
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                string strError = "";
                int rowCount = 0;
                switch (m_type)
                {
                    case 1://添加
                        rowCount = HTBLL.HolidayType_Insert(txtID.Text, txtName.Text, txtShortName.Text, txtRemark.Text, out strError);
                        if (!strError.Equals("Succeeds"))
                        {
                            SetShowInfo("保存失败", Color.Red);
                            return;
                        }
                        if (rowCount <= 0)
                        {
                            SetShowInfo("您已添加该假别信息", Color.Red);
                            return;
                        }
                        SetShowInfo("保存成功", Color.Black);
                        break;
                    case 2://修改
                        HTBLL.HolidayType_Update(id, txtID.Text, txtName.Text, txtShortName.Text, txtRemark.Text, out strError);
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
                    m_frmHoilidayMange.BindDataGridView();
                    m_frmHoilidayMange.LoadHoildTree();
                }
                else                                //热备版，启用定时器
                {
                    m_frmHoilidayMange.HostBackRefresh(true);
                }
            }
        }
        #endregion

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
        #endregion

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtShortName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

    }
}
