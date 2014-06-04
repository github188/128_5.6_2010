using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NModel;
using KJ128NDataBase;
using KJ128WindowsLibrary;
using Shine.Logs;
using Shine.Logs.LogType;

namespace KJ128NMainRun
{
    public partial class FrmWalkConfigInfo : Form
    {
        #region [构造函数]

        public FrmWalkConfigInfo()
        {
            InitializeComponent();
        }

        #endregion

        #region [字段]

        private WalkConfigBLL bll = new WalkConfigBLL();

        private DataTable dtEmp = null;

        private DataTable dtDept = null;

        private DataTable dtdept = null;

        private DataTable dtStationFS = null;
        private DataTable dtStationMS = null;
        private DataTable dtStationLS = null;

        /// <summary>
        /// 临时保存记录ID
        /// </summary>
        private int walkId = 0;

        #endregion

        #region [方法]

        #region [拖拽]

        /// <summary>
        /// 是否启用拖拽
        /// </summary>
        private bool moveAble = false;
        /// <summary>
        /// 左边距离
        /// </summary>
        private int left = 0;
        /// <summary>
        /// 上边距离 
        /// </summary>
        private int top = 0;

        /// <summary>
        /// 移动的方法
        /// </summary>
        /// <param name="obj">移动的对象</param>
        /// <param name="leftSize">左边距离</param>
        /// <param name="topSize">上边距离</param>
        private void ToMove(VSPanel obj, int leftSize, int topSize)
        {

            obj.Left += (Cursor.Position.X - leftSize);
            obj.Top += (Cursor.Position.Y - topSize);


            this.Cursor = Cursors.SizeAll;
            left = Cursor.Position.X;
            top = Cursor.Position.Y;

        }

        private void bcpAdd_MouseDown(object sender, MouseEventArgs e)
        {
            moveAble = true;

            left = Cursor.Position.X;
            top = Cursor.Position.Y;
        }

        private void bcpAdd_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveAble)
            {
                ToMove(vspnlAdd, left, top);
            }
        }

        private void bcpAdd_MouseUp(object sender, MouseEventArgs e)
        {
            moveAble = false;
            this.Cursor = Cursors.Default;
        }

        #endregion

        private void FrmWalkConfigInfo_Load(object sender, EventArgs e)
        {
            InitialzeSearchDeptComboBox();

            BandingDataGridView("");
        }

        private int InitializeUpdate(WalkConfigModel model)
        {
            return bll.UpdateWalkConfigInfo(model);
        }

        private void BandingDataGridView(string condition)
        {
            DataTable dt = SelectWalkConfigInfo(condition);
            this.dgvMain.DataSource = dt;

            SortColumns();
        }

        private DataTable SelectWalkConfigInfo(string condition)
        {
            return bll.SelectWalkConfigInfo(condition);
        }

        private void bcpAdd_CloseButtonClick(object sender, EventArgs e)
        {
            vspnlAdd.Visible = false;
        }

        /// <summary>
        /// 初始化增加
        /// </summary>
        private void InitialzeNew()
        {
            InitialzeDeptComboBox();

            InitialzeStationComboBox();

            this.txtHour.Text = "0";
            this.txtMin.Text = "0";
            this.txtSec.Text = "0";

            this.bcpAdd.CaptionTitle = "增加信息";
            this.btnAddOrEdit.CaptionTitle = "增加";

            vspnlAdd.Visible = true;
        }

        /// <summary>
        /// 初始化修改
        /// </summary>
        private void InitialzeUpdate()
        {
            try
            {
                walkId = Convert.ToInt32(this.dgvMain.CurrentRow.Cells["WalkConfigId"].Value.ToString());

                InitialzeDeptComboBox();

                InitialzeStationComboBox();

                this.txtHour.Text = "0";
                this.txtMin.Text = "0";
                this.txtSec.Text = "0";

                this.bcpAdd.CaptionTitle = "修改信息";
                this.btnAddOrEdit.CaptionTitle = "修改";
                this.vspnlAdd.Visible = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("修改初始化操作失败，失败消息：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 获取人员信息，用于绑定ComboBox
        /// </summary>
        /// <param name="tationAddress">分站地址，根据分站地址获取探头信息</param>
        /// <returns>探头表</returns>
        private DataTable GetEmpInfo(int deptId)
        {
            //if (dtEmp==null)
            dtEmp = DataHelper.GetEmpInfo(deptId);

            return dtEmp;
        }

        private DataTable GetDeptInfo()
        {
            //if (dtDept == null)
            dtDept = DataHelper.GetDeptInfo();
            return dtDept;
        }

        /// <summary>
        /// 获取人员信息，加载到 ComboBox 中去
        /// </summary>
        private void InitialzeEmpComboBox(int deptId)
        {
            DataTable dt = GetEmpInfo(deptId);

            this.cbEmp.DisplayMember = "EmpName";
            this.cbEmp.ValueMember = "EmpID";
            this.cbEmp.DataSource = dt;
            if (dt != null && dt.Rows.Count > 0)
            {
                this.cbEmp.SelectedIndex = 0;
            }
        }

        private void InitialzeDeptComboBox()
        {
            DataTable dt = GetDeptInfo();

            this.cbDept.DisplayMember = "DeptName";
            this.cbDept.ValueMember = "DeptId";
            this.cbDept.DataSource = dt;
            if (dt!=null && dt.Rows.Count > 0)
            {
                this.cbDept.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 加载查询时的部门信息
        /// </summary>
        private void InitialzeSearchDeptComboBox()
        {
            DataTable dt = GetDeptInfo();

            this.cbdpt.DisplayMember = "DeptName";
            this.cbdpt.ValueMember = "DeptId";
            this.cbdpt.DataSource = dt;
            if (dt != null && dt.Rows.Count > 0)
            {
                this.cbdpt.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 添加路线的具体信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcp_Add_Click(object sender, EventArgs e)
        {
                //初始化增加
                InitialzeNew();
        }

        /// <summary>
        /// 操作 “增加” 或 “修改”时的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            if (CheckValue())
            {
                try
                {
                    WalkConfigModel model = new WalkConfigModel();

                    model.EmpId = Convert.ToInt32(cbEmp.SelectedValue);
                    model.TimeValue = Convert.ToInt32(txtHour.Text) * 3600 + Convert.ToInt32(txtMin.Text) * 60 + Convert.ToInt32(txtSec.Text);

                    StationHeadModel fmodel = new StationHeadModel();
                    fmodel.StationAddress = Convert.ToInt32(cbFS.SelectedValue);
                    fmodel.StationHeadAddress = Convert.ToInt32(cbFSH.SelectedValue);
                    fmodel.StationHeadAntennaA = rbFA.Checked;
                    fmodel.StationHeadAntennaB = rbFB.Checked; ;

                    StationHeadModel mmodel = new StationHeadModel();
                    mmodel.StationAddress = Convert.ToInt32(cbMS.SelectedValue);
                    mmodel.StationHeadAddress = Convert.ToInt32(cbMSH.SelectedValue);
                    mmodel.StationHeadAntennaA = rbMA.Checked;
                    mmodel.StationHeadAntennaB = rbMB.Checked;

                    StationHeadModel lmodel = new StationHeadModel();
                    lmodel.StationAddress = Convert.ToInt32(cbLS.SelectedValue);
                    lmodel.StationHeadAddress = Convert.ToInt32(cbLSH.SelectedValue);
                    lmodel.StationHeadAntennaA = rbLA.Checked;
                    lmodel.StationHeadAntennaB = rbLB.Checked;

                    model.FirstStationHead = fmodel;
                    model.MiddleStationHead = mmodel;
                    model.LastStationHead = lmodel;

                    if (btnAddOrEdit.CaptionTitle == "增加")
                    {
                        int result = bll.InsertWalkConfigInfo(model);
                        if (result == 1)
                        {

                            MessageBox.Show("增加信息成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("增加操作失败,记录可能已存在，不能增加重复记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else if (btnAddOrEdit.CaptionTitle == "修改")
                    {
                        model.WalkConfigId = walkId;

                        int result = bll.UpdateWalkConfigInfo(model);
                        if (result == 1)
                        {

                            MessageBox.Show("修改信息成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("修改操作失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("操作失败,失败消息:" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 单击单元格：删除，修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dbgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string operate = dgvMain.CurrentRow.Cells[e.ColumnIndex].Value.ToString();

                if (operate == "修改")
                {
                    InitialzeUpdate();
                }

                else if (operate == "删除")
                {
                    try
                    {
                        DialogResult dr = MessageBox.Show("您确认要删除这条记录？", "确认提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            //存入日志
                            LogSave.Messages("[FrmWalkConfigInfo]", LogIDType.UserLogID, "删除行走异常配置信息，行走异常配置信息编号："
                                + dgvMain.CurrentRow.Cells["ID"].Value.ToString() + "，员工姓名：" + dgvMain.CurrentRow.Cells["EmpName"].Value.ToString() + "。");

                            int id = Convert.ToInt32(dgvMain.CurrentRow.Cells["Id"].Value.ToString());
                            int count = bll.DeleteWalkConfigInfo(id);

                            bool flag = (count == 1 ? true : false);

                            if (flag)
                            {
                                BandingDataGridView("");
                            }
                            else
                            {
                                MessageBox.Show("删除操作失败", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("操作失败:" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// 检查数据合法性
        /// </summary>
        /// <returns></returns>
        private bool CheckValue()
        {
            if (cbEmp.Text.Trim() == "")
            {
                MessageBox.Show("员工姓名不要为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtHour.Text.Trim() == "" && txtMin.Text.Trim() == "" && txtSec.Text.Trim() == "")
            {
                MessageBox.Show("行走时间不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cbFS.SelectedValue == null || cbMS.SelectedValue == null || cbFSH.SelectedValue == null || cbMSH.SelectedValue == null
                || cbLS.SelectedValue == null || cbLSH.SelectedValue == null)
            {
                MessageBox.Show("选择的三个探测器不能有空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            if ((cbFS.SelectedValue.ToString() == cbMS.SelectedValue.ToString() && cbFSH.SelectedValue.ToString() == cbMSH.SelectedValue.ToString())
                || (cbFS.SelectedValue.ToString() == cbLS.SelectedValue.ToString() && cbFSH.SelectedValue.ToString() == cbLSH.SelectedValue.ToString())
                || (cbMS.SelectedValue.ToString() == cbLS.SelectedValue.ToString() && cbMSH.SelectedValue.ToString() == cbLSH.SelectedValue.ToString()))
            {
                MessageBox.Show("选择的三个探测器不能有相同", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (Convert.ToInt32(txtHour.Text.Trim()) < 0)
            {
                MessageBox.Show("行走小时数不能0", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (Convert.ToInt32(txtMin.Text.Trim()) < 0)
            {
                MessageBox.Show("行走分钟数不能小于0", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (Convert.ToInt32(txtSec.Text.Trim()) < 0)
            {
                MessageBox.Show("行走秒数不能小于0", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 点击新增时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcpAddInfo_Click(object sender, EventArgs e)
        {
            //初始化增加
            InitialzeNew();
        }

        private void cbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDept.SelectedValue != null)
            {
                int deptId = Convert.ToInt32(cbDept.SelectedValue.ToString());
                InitialzeEmpComboBox(deptId);
            }
        }

        /// <summary>
        /// 加载分站ComboBox
        /// </summary>
        private void InitialzeStationComboBox()
        {
            if (dtStationFS == null)
                dtStationFS = GetStationInfo();

            if (dtStationMS == null)
                dtStationMS = GetStationInfo();

            if (dtStationLS == null)
                dtStationLS = GetStationInfo();

            //加载列表
            cbFS.DisplayMember = "StationPlace";
            cbFS.ValueMember = "StationAddress";

            cbFS.DataSource = dtStationFS;
            if (dtStationFS != null && dtStationFS.Rows.Count > 0)
            {
                cbFS.SelectedIndex = 0;
            }

            //加载列表
            cbMS.DisplayMember = "StationPlace";
            cbMS.ValueMember = "StationAddress";

            cbMS.DataSource = dtStationMS;
            if (dtStationMS != null && dtStationMS.Rows.Count > 0)
            {
                cbMS.SelectedIndex = 0;
            }

            //加载列表
            cbLS.DisplayMember = "StationPlace";
            cbLS.ValueMember = "StationAddress";

            cbLS.DataSource = dtStationLS;
            if (dtStationLS != null && dtStationLS.Rows.Count > 0)
            {
                cbLS.SelectedIndex = 0;
            }

        }

        /// <summary>
        /// 获取分站信息，用于绑定ComboBox
        /// </summary>
        /// <returns>分站表</returns>
        private DataTable GetStationInfo()
        {
            DataTable dt = DataHelper.GetStationInfo();

            return dt;
        }

        private void cbFS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFS.SelectedValue != null)
            {
                int stationAddress = Convert.ToInt32(cbFS.SelectedValue.ToString());

                DataTable dt = DataHelper.GetPointInfo(stationAddress);

                cbFSH.DisplayMember = "StationHeadPlace";
                cbFSH.ValueMember = "StationHeadAddress";
                cbFSH.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    cbFSH.SelectedIndex = 0;
                }
            }
        }

        private void cbMS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMS.SelectedValue != null)
            {
                int stationAddress = Convert.ToInt32(cbMS.SelectedValue.ToString());

                DataTable dt = DataHelper.GetPointInfo(stationAddress);

                cbMSH.DisplayMember = "StationHeadPlace";
                cbMSH.ValueMember = "StationHeadAddress";
                cbMSH.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    cbMSH.SelectedIndex = 0;
                }
            }
        }

        private void cbLS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLS.SelectedValue != null)
            {
                int stationAddress = Convert.ToInt32(cbLS.SelectedValue.ToString());

                DataTable dt = DataHelper.GetPointInfo(stationAddress);

                cbLSH.DisplayMember = "StationHeadPlace";
                cbLSH.ValueMember = "StationHeadAddress";
                cbLSH.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    cbLSH.SelectedIndex = 0;
                }
            }
        }

        private void txtHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || e.KeyChar == '\b'))
            {
                e.Handled = true;
            }
        }

        private void bcpSelect_Click(object sender, EventArgs e)
        {
            try
            {
                string condition = String.Empty;

                if (cbdpt.SelectedValue != null)
                {
                    condition = " DeptID=" + cbdpt.SelectedValue.ToString();
                }
                else
                {
                    condition = " 1=1 ";
                }

                if (txtEmpName.Text.Trim() != "")
                {
                    condition += " and EmpName like '%" + txtEmpName.Text + "%'";
                }

                if (txtCodeSenderAddress.Text.Trim() != "")
                {
                    condition += " and CodeSenderAddress=" + txtCodeSenderAddress.Text;
                }

                BandingDataGridView(condition);
            }
            catch (Exception ex)
            {
                MessageBox.Show("组织查询条件导致SQL查询错误\n错误消息：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 给GridView的列头进行排序
        /// </summary>
        private void SortColumns()
        {
            if (this.dgvMain.ColumnCount > 0)
            {
                //隐藏字段
                dgvMain.Columns["WalkConfigId"].Visible = false;
                dgvMain.Columns["EmpID"].Visible = false;
                dgvMain.Columns["DeptID"].Visible = false;

                //设置显示顺序
                dgvMain.Columns["CodeSenderAddress"].DisplayIndex = 0;
                dgvMain.Columns["CodeSenderAddress"].HeaderText = "标识卡编号";

                dgvMain.Columns["EmpName"].DisplayIndex = 1;
                dgvMain.Columns["EmpName"].HeaderText = "姓名";

                dgvMain.Columns["DeptName"].DisplayIndex = 2;
                dgvMain.Columns["DeptName"].HeaderText = "部门";


                dgvMain.Columns["FirstStationAddress"].DisplayIndex = 3;
                dgvMain.Columns["FirstStationAddress"].HeaderText = "第一传输分站编号";

                dgvMain.Columns["FirstStationHeadAddress"].DisplayIndex = 4;
                dgvMain.Columns["FirstStationHeadAddress"].HeaderText = "第一读卡分站编号";

                dgvMain.Columns["FirstStationHeadAntennaA"].DisplayIndex = 5;
                dgvMain.Columns["FirstStationHeadAntennaA"].HeaderText = "第一天线A";

                dgvMain.Columns["FirstStationHeadAntennaB"].DisplayIndex = 6;
                dgvMain.Columns["FirstStationHeadAntennaB"].HeaderText = "第一天线B";

                dgvMain.Columns["firstPlace"].DisplayIndex = 7;
                dgvMain.Columns["firstPlace"].HeaderText = "第一读卡分站安装位置";


                dgvMain.Columns["MiddleStationAddress"].DisplayIndex = 8;
                dgvMain.Columns["MiddleStationAddress"].HeaderText = "中间传输分站编号";

                dgvMain.Columns["MiddleStationHeadAddress"].DisplayIndex = 9;
                dgvMain.Columns["MiddleStationHeadAddress"].HeaderText = "中间读卡分站编号";

                dgvMain.Columns["MiddleStationHeadAntennaA"].DisplayIndex = 10;
                dgvMain.Columns["MiddleStationHeadAntennaA"].HeaderText = "中间天线A";

                dgvMain.Columns["MiddleStationHeadAntennaB"].DisplayIndex = 11;
                dgvMain.Columns["MiddleStationHeadAntennaB"].HeaderText = "中间天线B";

                dgvMain.Columns["middlePlace"].DisplayIndex = 12;
                dgvMain.Columns["middlePlace"].HeaderText = "中间读卡分站安装位置";


                dgvMain.Columns["LastStationAddress"].DisplayIndex = 13;
                dgvMain.Columns["LastStationAddress"].HeaderText = "最后传输分站编号";

                dgvMain.Columns["LastStationHeadAddress"].DisplayIndex = 14;
                dgvMain.Columns["LastStationHeadAddress"].HeaderText = "最后读卡分站编号";

                dgvMain.Columns["LastStationHeadAntennaA"].DisplayIndex = 15;
                dgvMain.Columns["LastStationHeadAntennaA"].HeaderText = "最后天线A";

                dgvMain.Columns["LastStationHeadAntennaB"].DisplayIndex = 16;
                dgvMain.Columns["LastStationHeadAntennaB"].HeaderText = "最后天线B";

                dgvMain.Columns["lastPlace"].DisplayIndex = 17;
                dgvMain.Columns["lastPlace"].HeaderText = "最后读卡分站安装位置";


                dgvMain.Columns["TimeValue"].DisplayIndex = 18;
                dgvMain.Columns["TimeValue"].HeaderText = "规定时间";

                //不让修改
                dgvMain.Columns["Edit"].DisplayIndex = 19;
                dgvMain.Columns["Edit"].Visible = false;

                dgvMain.Columns["Delete"].DisplayIndex = 20;
  
            }
        }

        #endregion
    }
}
