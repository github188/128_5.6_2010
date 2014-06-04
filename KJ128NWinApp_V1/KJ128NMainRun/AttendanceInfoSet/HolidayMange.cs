using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using KJ128NDBTable;
using KJ128NDataBase;
using Shine.Logs;
using Shine.Logs.LogType;

namespace KJ128NInterfaceShow
{
    public partial class HolidayMange : Wilson.Controls.Docking.DockContent
    {
        DeptBLL db = new DeptBLL();
        HolidayTypeBLL htBLL = new HolidayTypeBLL();
        AddEmpBLL ABBL = new AddEmpBLL();
        HolidayManageBLL hmBLL = new HolidayManageBLL();
        string strErr = string.Empty;

        #region 初始化函数
        public HolidayMange()
        {
            InitializeComponent();

        }
        #endregion

        #region 绑定组合下拉列表
        void BindComboBox(ComboBox CB)
        {
            ArrayList al = new ArrayList();
            for(int i=1;i<=10;i++)
            {
                int j = i * 10;
                
                al.Add(new ListItem(j.ToString(),"每页显示"+j.ToString()+"行" ));
            }
            cbRowsSet.DataSource = al;
            cbRowsSet.DisplayMember = "Name";
            cbRowsSet.ValueMember = "ID";

        }
        #endregion

        #region 窗体加载事件
        private void HolidayMange_Load(object sender, EventArgs e)
        {
            captionPanel1.Width = this.Width;


            dgrd.Width = this.Width;
            dgrd.Height = this.Height - 56;

            BindComboBox(cbRowsSet);
            db.getDeptAddAll(cbDept);
            db.getDept(cbDeptAdd);
            htBLL.GetHolidayType(cbHolidayTypeAdd);
            htBLL.GetHolidayTypeAddAll(cbHolidayType);
            ShowOrHiddenControls(false);
            BindDataGridView();
            cbBeginTime.Text = DateTime.Today.ToString();
            cbEndTime.Text = DateTime.Now.ToString();
        }
        #endregion

        #region 显示隐藏控件
        void ShowOrHiddenControls(bool budgrd)
        {
            cpModify.Visible = budgrd;
            gbUpdate.Visible = budgrd;
            btnModify.Visible = budgrd;
            btnReturn.Visible = budgrd;
            txtBlockAdd.Visible = budgrd;
            txtEmpNameAdd.Visible = budgrd;
            cbDeptAdd.Visible = budgrd;
            cbHolidayTypeAdd.Visible = budgrd;
            lblID.Visible = false;
            lblPageIndex.Visible = false;

        }
        #endregion

        #region 添加按钮的单击事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            ShowOrHiddenControls(true);
            ClearAll();
            btnModify.CaptionTitle = "添 加";
            txtBlockAdd.Text = "";
            txtEmpNameAdd.Text = "";

        }
        #endregion

        #region 清空函数
        void ClearAll()
        {
            txtBlockAdd.Text = "";
            txtEmpNameAdd.Text = "";
        }
        #endregion

        #region 添加/修改按钮的单击事件
        private void btnModify_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            lblErr.ForeColor = Color.Red;
            if (txtEmpNameAdd.Text == "")
            {
                lblErr.Text = "员工姓名不能为空!";
                return;
            }
            
            lblErr.ForeColor = Color.Red;
            if (txtBlockAdd.Text == "")
            {
                lblErr.Text = "发码器编号不能为空!";
                return;
            }
            try
            {
                int intBlockID = Convert.ToInt32(txtBlockAdd.Text);
            }
            catch
            {

                lblErr.Text = "发码器编号只能为数字!";
                return;
            }

            if (btnModify.CaptionTitle == "添 加")
            {
                //存入日志
                LogSave.Messages("[HolidayMange]", LogIDType.UserLogID, "添加请假信息，发码器编号：" + txtBlockAdd.Text + "，员工姓名：" + txtEmpNameAdd.Text);

                //hmBLL.HolidayManage_Insert(Convert.ToInt32(txtBlockAdd.Text), txtEmpNameAdd.Text, Convert.ToInt32(cbDeptAdd.SelectedValue.ToString()), dtHoliday.Value.ToString(), cbHolidayTypeAdd.Text, 0, out strErr);
                if (strErr == "Succeeds")
                {
                    lblErr.ForeColor = Color.Blue;
                    lblErr.Text = "添加成功!";

                    if (!New_DBAcess.IsDouble)
                    {
                        BindDataGridView();
                    }
                    else
                    {
                        timer1.Start();
                    }

                    txtBlockAdd.Text = "";
                    txtEmpNameAdd.Text = "";
                }
            }
            else
            {
                //存入日志
                LogSave.Messages("[HolidayMange]", LogIDType.UserLogID, "修改请假信息，发码器编号：" + txtBlockAdd.Text + "，员工姓名：" + txtEmpNameAdd.Text);

               // hmBLL.HolidayManage_Update(Convert.ToInt32(lblID.Text),Convert.ToInt32(txtBlockAdd.Text), txtEmpNameAdd.Text, Convert.ToInt32(cbDeptAdd.SelectedValue.ToString()), dtHoliday.Value.ToString(), cbHolidayTypeAdd.Text, 0, out strErr);
                if (strErr == "Succeeds")
                {
                    lblErr.ForeColor = Color.Blue;
                    lblErr.Text = "修改成功!";

                    if (!New_DBAcess.IsDouble)
                    {
                        BindDataGridView();
                    }
                    else
                    {
                        timer1.Start();
                    }
                }
            }
        }
        #endregion

        #region 返回按钮的单击事件
        private void btnReturn_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            ShowOrHiddenControls(false);
        }
        #endregion

        #region 得到条件的函数
        public string GetWhere()
        {
            string strWhere = string.Empty;

            if (cbDept.SelectedValue.ToString() != "0")
            {
                strWhere = " and h.DeptID ="+cbDept.SelectedValue;
            }
            if (txtEmpName.Text != "")
            {
                strWhere += " and h.EmployeeName='" + txtEmpName.Text+"'";
            }
            if (txtCSAddress.Text != "")
            {
                strWhere += " and h.BlockID = "+txtCSAddress.Text;
            }
            if (cbHolidayType.SelectedValue.ToString() != "0")
            {
                strWhere += " and h.ClassShortName='"+cbHolidayType.Text+"'";
            }

            strWhere += " and h.DataAttendance >='"+cbBeginTime.Value+"' and h.DataAttendance<='"+cbEndTime.Value+"'";
            return strWhere;
        }
        #endregion

        #region 员工姓名文本框的单击事件
        private void txtEmpNameAdd_Enter(object sender, EventArgs e)
        {
            lblErr.Text = "";
            lblErr.ForeColor = Color.Red;
            if (txtBlockAdd.Text == "")
            {
                lblErr.Text = "发码器编号不能为空!";
                return;
            }
            try
            {
                int intBlockID = Convert.ToInt32(txtBlockAdd.Text);
            }
            catch
            {

                lblErr.Text = "发码器编号只能为数字!";
                return;
            }

            DataSet ds = ABBL.GetEmployeeNameByDeptIDAndCoderSenderID(Convert.ToInt32(cbDeptAdd.SelectedValue), Convert.ToInt32(txtBlockAdd.Text));
            if (ds == null || ds.Tables[0].Rows.Count != 0)
            {
                txtEmpNameAdd.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                txtEmpNameAdd.Text = "";
            }
        }
        #endregion

        #region DataGridView单元格任何部分改变的事件
        private void dgrd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblErr.Text = "";
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                if (dgrd.Rows[e.RowIndex].Cells[0].Value.ToString() == "修改")
                {
                    lblID.Text = dgrd.Rows[e.RowIndex].Cells[2].Value.ToString();
                    btnModify.CaptionTitle = "修 改";
                    ShowOrHiddenControls(true);
                    cbDeptAdd.Text = dgrd.Rows[e.RowIndex].Cells[7].Value.ToString();
                    cbHolidayTypeAdd.Text = dgrd.Rows[e.RowIndex].Cells[6].Value.ToString();
                    txtBlockAdd.Text = dgrd.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtEmpNameAdd.Text = dgrd.Rows[e.RowIndex].Cells[4].Value.ToString();
                    dtHoliday.Value = Convert.ToDateTime(dgrd.Rows[e.RowIndex].Cells[8].Value.ToString());

                    //存入日志
                    LogSave.Messages("[HolidayMange]", LogIDType.UserLogID, "修改请假信息，发码器编号：" + txtBlockAdd.Text + "，员工姓名：" + txtEmpNameAdd.Text);

                }
            }

            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                if (dgrd.Rows[e.RowIndex].Cells[1].Value.ToString() == "删除")
                {
                    if (MessageBox.Show("你确定要删除吗?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //存入日志
                        LogSave.Messages("[HolidayMange]", LogIDType.UserLogID, "删除请假信息，发码器编号：" + dgrd.Rows[e.RowIndex].Cells[3].Value.ToString() + "，员工姓名：" + dgrd.Rows[e.RowIndex].Cells[4].Value.ToString());

                        //hmBLL.HolidayManage_Delete(Convert.ToInt32(dgrd.Rows[e.RowIndex].Cells[2].Value.ToString()), out strErr);

                        if (!New_DBAcess.IsDouble)
                        {
                            BindDataGridView();
                        }
                        else
                        {
                            timer1.Start();
                        }
                    }
                }
            }
        }
        #endregion

        #region DataGridView的数据绑定函数（分页中的首页索引为1）
        void BindDataGridView()
        {
            //DataSet ds = hmBLL.HolidayManage_Query(Convert.ToInt32(lblPageIndex.Text.Trim()), Convert.ToInt32(cbRowsSet.SelectedValue.ToString()), GetWhere());
            DataSet ds = new DataSet();
            if (ds != null && ds.Tables.Count>0)
            {
                //更改名称 发码器->发码器编号
                ds.Tables[0].Columns[1].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);

                dgrd.AutoGenerateColumns = true;
                dgrd.DataSource = ds.Tables[0].DefaultView;
                dgrd.Columns[2].Visible = false;
                dgrd.Columns[5].Visible = false;
                dgrd.Columns[0].DisplayIndex = 8;
                dgrd.Columns[1].DisplayIndex = 8;

                btnRowsCount.CaptionTitle = "有"+ds.Tables[1].Rows[0][0].ToString()+"条记录";

                int intPageCount = Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString()) / Convert.ToInt32(cbRowsSet.SelectedValue.ToString());


                if (Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString()) % Convert.ToInt32(cbRowsSet.SelectedValue.ToString()) != 0)
                {
                    intPageCount++;
                }

                if (intPageCount == 0)
                {
                    intPageCount++;
                }
                if (lblPageIndex.Text == "1")
                {
                    btnpreview.Enabled = false;
                }
                else
                {
                    btnpreview.Enabled = true;
                }

                if (lblPageIndex.Text.ToString() == intPageCount.ToString())
                {
                    btnNext.Enabled = false;
                }
                else
                {
                    btnNext.Enabled = true;
                }
                lblPageCount.Text = intPageCount.ToString();

                btnCurrentPageIndex.CaptionTitle = lblPageIndex.Text + "/" + intPageCount.ToString();
                
            }
        }
        #endregion

        #region 查询按钮的单击事件
        private void btnQuery_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            BindDataGridView();
        }
        #endregion

        #region DataGrid行数设置
        private void cbRowsSet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblErr.Text = "";
            lblPageIndex.Text = "1";
            BindDataGridView();
        }
        #endregion

        #region 页面跳转按钮的单击事件
        private void btnJump_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            lblErr.ForeColor = Color.Red;
            if (txtJump.Text.Trim() == "")
            {
                lblErr.Text = "跳转页数不能为空!";
                return;
            }
            if (txtJump.Text.Trim() == "0")
            {
                lblErr.Text = "跳转页数不能为零!";
                return;
            }

            try
            {
                Convert.ToInt32(txtJump.Text.Trim());
            }
            catch
            {
                lblErr.Text = "跳转页数只能为数字!";
                return;
            }


            try
            {
                if (lblPageCount.Text.Trim() != "")
                {
                    if (Convert.ToInt32(txtJump.Text.Trim()) >= Convert.ToInt32(lblPageCount.Text))
                    {
                        lblPageIndex.Text = lblPageCount.Text;
                        txtJump.Text = lblPageCount.Text;
                    }
                    else
                    {
                        lblPageIndex.Text = txtJump.Text;
                    }
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("出现跳转错误");
            }

           
            BindDataGridView();

        }
        #endregion

        #region 上一页的单击事件
        private void btnpreview_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblPageIndex.Text) >1)
            {
                lblPageIndex.Text = Convert.ToString(Convert.ToInt32(lblPageIndex.Text) - 1);
                BindDataGridView();
            }
        }
        #endregion

        #region 下一页的单击事件
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(lblPageIndex.Text) < Convert.ToInt32(lblPageCount.Text))
                {
                    lblPageIndex.Text = Convert.ToString(Convert.ToInt32(lblPageIndex.Text) + 1);
                    BindDataGridView();
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show("请输入符合规定的信息！");
            }
        }
        #endregion

        #region 重置按钮的单击事件
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtEmpName.Text = "";
            txtCSAddress.Text = "";
            cbBeginTime.Text = DateTime.Today.ToString();
            cbEndTime.Text = DateTime.Now.ToString();
        }
        #endregion

        #region [热备定时刷新]

        /// <summary>
        /// 最大刷新次数
        /// </summary>
        private int maxTimes = 2;

        /// <summary>
        /// 查询刷新次数
        /// </summary>
        private int times = 0;

        /// <summary>
        /// 1表示 增加，修改 2 表示删除,3表示修改
        /// </summary>
        private int operated = 1;

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (times < maxTimes)
            {

                BindDataGridView();
                times++;
                timer1.Stop();
                timer1.Start();
            }
            else
            {
                times = 0;
                //关闭timer1
                timer1.Stop();
            }
        }

        #endregion        

        private void bcpRef_Click(object sender, EventArgs e)
        {
            BindDataGridView();
        }
    }
}