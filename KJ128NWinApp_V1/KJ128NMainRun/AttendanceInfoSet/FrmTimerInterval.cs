using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using KJ128NDBTable;
using Shine.Logs;
using Shine.Logs.LogType;
using KJ128NDataBase;

namespace KJ128NInterfaceShow
{
    public partial class FrmTimerInterval : Wilson.Controls.Docking.DockContent
    {
        string strErr = string.Empty;
        TimerIntervalBLL TIBLL = new TimerIntervalBLL();
        InfoClassBLL ICBLL = new InfoClassBLL();

        #region 构造函数
        public FrmTimerInterval()
        {
            InitializeComponent();
        }
        #endregion

        #region 窗体加载函数
        private void FrmTimerInterval_Load(object sender, EventArgs e)
        {
            captionPanel1.Width = this.Width;
            captionPanel1.Height = this.Height - 35;

            dgrd.Width = this.Width;
            dgrd.Height = this.Height - 56;
            
            BindData();
            ICBLL.InfoClass_BindComboBox(cbClass);
            BindComboBox(cbEndWorkType);
            BindComboBox(cbBeginWorkType);
            ShowOrHiddenControl(true, false);
            BindHourComboBox(cbBeginHour);
            BindHourComboBox(cbEndHour);
            BindMinuteComboBox(cbBeginMinute);
            BindMinuteComboBox(cbEndMinute);
            BindComboBox(DataAttendanceType);


        }
        #endregion

        #region 绑定DataGridView函数
        void BindData()
        {
            TIBLL.TimerInterval_Query("");
            DataSet ds = TIBLL.TimerInterval_Query("");

            if (ds != null)
            {
                
                dgrd.DataSource = ds.Tables[0];

                dgrd.Columns[2].Visible = false;
                dgrd.Columns[5].Visible = false;
                dgrd.Columns[6].Visible = false;
                dgrd.Columns[7].Visible = false;
                dgrd.Columns[8].Visible = false;
                dgrd.Columns[9].Visible = false;
                dgrd.Columns[10].Visible = false;
                dgrd.Columns[11].Visible = false;
                dgrd.Columns[12].Visible = false;
                dgrd.Columns[13].Visible = false;
                dgrd.Columns[15].Visible = false;
                dgrd.Columns[3].HeaderText = "时段全称";
                dgrd.Columns[4].HeaderText = "时段简称";
                dgrd.Columns[14].HeaderText = "所属班制";
                dgrd.Columns[0].DisplayIndex = 15;
                dgrd.Columns[1].DisplayIndex = 15;
                dgrd.Columns[1].Visible = false;
                

            }
        }
        #endregion

        #region 显示隐藏控件函数
        void ShowOrHiddenControl(bool bdgrd, bool budgrd)
        {

            cpModify.Visible = budgrd;
            label1.Visible = budgrd;
            label2.Visible = budgrd;
            label3.Visible = budgrd;
            label4.Visible = budgrd;
            label5.Visible = budgrd;
            label6.Visible = budgrd;
            label7.Visible = budgrd;
            label8.Visible = budgrd;
            label9.Visible = budgrd;
            label10.Visible = budgrd;
            label11.Visible = budgrd;
            label12.Visible = budgrd;
            label13.Visible = budgrd;
            label14.Visible = budgrd;
            label15.Visible = budgrd;
            label16.Visible = budgrd;
            label17.Visible = budgrd;
            label18.Visible = budgrd;
            label19.Visible = budgrd;
            label20.Visible = budgrd;
            label21.Visible = budgrd;
            label22.Visible = budgrd;
            label23.Visible = budgrd;
            label24.Visible = budgrd;
            DataAttendanceType.Visible = budgrd;
            btnModify.Visible = budgrd;
            btnCancel.Visible = budgrd;
            cbBeginHour.Visible = budgrd;
            cbBeginMinute.Visible = budgrd;
            txtBeginWorkAfter.Visible = budgrd;
            txtBeginWorkFront.Visible = budgrd;
            cbEndHour.Visible = budgrd;
            cbEndMinute.Visible = budgrd;
            txtEndWorkAfter.Visible = budgrd;
            txtEndWorkFront.Visible = budgrd;
            txtName.Visible = budgrd;
            txtShortName.Visible = budgrd;
            cbBeginWorkType.Visible = budgrd;
            cbEndWorkType.Visible = budgrd;
            cbClass.Visible = budgrd;
            
            dgrd.Visible = bdgrd;
        }
        #endregion

        #region 添加按钮的单击事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowOrHiddenControl(false, true);
            ClearAll();
            btnModify.CaptionTitle = "添 加";
            cpModify.CaptionTitle = "添加时段";
        }
        #endregion

        #region 绑定组合下拉框函数
        void BindComboBox(ComboBox CB)
        {            
            ArrayList al = new ArrayList();
            al.Add(new ListItem("-1", "前一日"));
            al.Add(new ListItem("0","排班日"));
            al.Add(new ListItem("1", "后一日"));
            CB.DataSource = al;
            CB.DisplayMember = "Name";
            CB.ValueMember = "ID";

            CB.Text = CB.Items[1].ToString();


        }
        #endregion

        #region 关闭按钮的单击事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            ShowOrHiddenControl(true, false);

            if (!New_DBAcess.IsDouble)
            {
                BindData();
            }
            else
            {
                timer1.Start();
            }
        }
        #endregion

        #region 给小时的下拉列表添加内容
        void BindHourComboBox(ComboBox CB)
        {
            ArrayList al = new ArrayList();
            for (int i=0; i < 24; i++)
            {
                string str;
                if (i < 10)
                {
                    str = "0" + i.ToString();
                }
                else
                {
                    str = i.ToString();
                }
               
                al.Add(new ListItem(str, str));
            }
            CB.DataSource = al;
            CB.DisplayMember = "Name";
            CB.ValueMember = "ID";

            CB.Text = CB.Items[1].ToString();
        }
        #endregion

        #region 给分钟的下拉列表添加内容
        void BindMinuteComboBox(ComboBox CB)
        {
            ArrayList al = new ArrayList();
            for (int i=0; i < 60; i++)
            {
                string str;
                if (i < 10)
                {
                    str = "0" + i.ToString();
                }
                else
                {
                    str = i.ToString();
                }
                
                al.Add(new ListItem(str, str));
            }
            CB.DataSource = al;
            CB.DisplayMember = "Name";
            CB.ValueMember = "ID";

            CB.Text = CB.Items[0].ToString();
        }
        #endregion

        #region 修改/添加按钮的单击事件
        private void btnModify_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            lblErr.ForeColor = Color.Red;

            if (txtName.Text.Trim().Equals(""))
            {
                lblErr.Text = "时段全称不能为空!";
                return;
            }
            if (txtShortName.Text.Trim().Equals(""))
            {
                lblErr.Text = "时段简称不能为空!";
                return;
            }
            if (txtBeginWorkAfter.Text == "")
            {
                lblErr.Text = "考勤开始后的时间不能为空!";
                return;
            }
            else
            {
                try
                {
                    Convert.ToInt32(txtBeginWorkAfter.Text);
                }
                catch
                {
                    lblErr.Text = "考勤开始后的时间必须为数字!";
                    return;
                }
            }
            if (txtBeginWorkFront.Text == "")
            {
                lblErr.Text = "考勤提前开始时间不能为空!";
                return;
            }
            else
            {
                try
                {
                    Convert.ToInt32(txtBeginWorkFront.Text);
                }
                catch
                {
                    lblErr.Text = "考勤提前开始时间必须为数字!";
                    return;
                }
            }

            if (txtEndWorkFront.Text == "")
            {
                lblErr.Text = "考勤结束前时间不能为空!";
                return;
            }
            else
            {
                try
                {
                    Convert.ToInt32(txtEndWorkFront.Text);
                }
                catch
                {
                    lblErr.Text = "考勤结束前时间必须为数字!";
                    return;
                }
            }

            if (txtEndWorkAfter.Text == "")
            {
                lblErr.Text = "考勤结束后时间不能为空!";
                return;
            }
            else
            {
                try
                {
                    Convert.ToInt32(txtEndWorkAfter.Text);
                }
                catch
                {
                    lblErr.Text = "考勤结束后时间必须为数字!";
                    return;
                }
            }

            if (btnModify.CaptionTitle == "修 改")
            {
                //存入日志
                LogSave.Messages("[FrmTimerInterval]", LogIDType.UserLogID, "修改考勤时段，时段全称："+txtName.Text+"，简称："
                    + txtShortName.Text + "，所属班制：" + cbClass.SelectedText + "。");

                TIBLL.TimerInterval_Update(Convert.ToInt32(lblID.Text), 
                    txtName.Text, txtShortName.Text, "1900-01-01 " + cbBeginHour.SelectedValue + ":" + cbBeginMinute.SelectedValue + ":30", 
                    "1900-01-01 " + cbEndHour.SelectedValue + ":" + cbEndMinute.SelectedValue + ":30", 
                    Convert.ToInt32(cbBeginWorkType.SelectedValue.ToString()), 
                    Convert.ToInt32(cbEndWorkType.SelectedValue), Convert.ToInt32(txtBeginWorkFront.Text), 
                    Convert.ToInt32(txtBeginWorkAfter.Text), Convert.ToInt32(txtEndWorkFront.Text), 
                    Convert.ToInt32(txtEndWorkAfter.Text), Convert.ToInt32(cbClass.SelectedValue), Convert.ToInt32(DataAttendanceType.SelectedValue.ToString()), out strErr);
                if (strErr == "Succeeds") 
                {
                    lblErr.ForeColor = Color.Blue;
                    lblErr.Text = "修改成功!";
                }
            }
            else
            {
                //存入日志
                LogSave.Messages("[FrmTimerInterval]", LogIDType.UserLogID, "添加考勤时段，时段全称：" + txtName.Text + "，简称："
                    + txtShortName.Text + "，所属班制：" + cbClass.SelectedText + "。");

                TIBLL.TimerInterval_Insert(txtName.Text, txtShortName.Text, "1900-01-01 " + cbBeginHour.SelectedValue + ":" + cbBeginMinute.SelectedValue + ":30",
                    "1900-01-01 " + cbEndHour.SelectedValue + ":" + cbEndMinute.SelectedValue + ":30",
                    Convert.ToInt32(cbBeginWorkType.SelectedValue.ToString()),
                    Convert.ToInt32(cbEndWorkType.SelectedValue), Convert.ToInt32(txtBeginWorkFront.Text),
                    Convert.ToInt32(txtEndWorkAfter.Text), Convert.ToInt32(txtEndWorkFront.Text),
                    Convert.ToInt32(txtEndWorkAfter.Text), Convert.ToInt32(cbClass.SelectedValue),Convert.ToInt32(DataAttendanceType.SelectedValue.ToString()), out strErr);
                if (strErr == "Succeeds")
                {
                    ClearAll();
                    lblErr.ForeColor = Color.Blue;
                    lblErr.Text = "添加成功!";
                }
            }
        }
        #endregion

        #region 清空控件内容的函数
        void ClearAll()
        {
            txtName.Text = "";
            txtShortName.Text = "";
            txtBeginWorkAfter.Text = "";
            txtEndWorkAfter.Text = "";
            txtBeginWorkFront.Text = "";
            txtEndWorkFront.Text = "";
        }
        #endregion

        #region DataGridView单元格内容单击事件
        private void dgrd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblErr.Text = "";
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                ShowOrHiddenControl(false, true);
                btnModify.CaptionTitle = "修 改";
                lblID.Text = dgrd.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtName.Text = dgrd.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtShortName.Text = dgrd.Rows[e.RowIndex].Cells[4].Value.ToString();
                cbClass.SelectedValue = dgrd.Rows[e.RowIndex].Cells[13].Value.ToString();
                cbBeginWorkType.SelectedValue = dgrd.Rows[e.RowIndex].Cells[7].Value.ToString();
                cbEndWorkType.SelectedValue = dgrd.Rows[e.RowIndex].Cells[8].Value.ToString();
                cbBeginHour.SelectedValue = dgrd.Rows[e.RowIndex].Cells[5].Value.ToString().Substring(11, 2);
                cbBeginMinute.SelectedValue = dgrd.Rows[e.RowIndex].Cells[5].Value.ToString().Substring(14, 2);
                cbEndHour.SelectedValue = dgrd.Rows[e.RowIndex].Cells[6].Value.ToString().Substring(11, 2);
                cbEndMinute.SelectedValue = dgrd.Rows[e.RowIndex].Cells[6].Value.ToString().Substring(14, 2);
                txtEndWorkAfter.Text = dgrd.Rows[e.RowIndex].Cells[12].Value.ToString();
                txtEndWorkFront.Text = dgrd.Rows[e.RowIndex].Cells[11].Value.ToString();
                txtBeginWorkAfter.Text = dgrd.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtBeginWorkFront.Text = dgrd.Rows[e.RowIndex].Cells[9].Value.ToString();
                DataAttendanceType.SelectedValue = dgrd.Rows[e.RowIndex].Cells[15].Value.ToString();
                cpModify.CaptionTitle = "修改时段";

                //存入日志
                LogSave.Messages("[FrmTimerInterval]", LogIDType.UserLogID, "修改考勤时段，时段全称：" + txtName.Text + "，简称："
                    + txtShortName.Text + "，所属班制：" + cbClass.SelectedText + "。");

            }
            if(e.RowIndex>=0 && e.ColumnIndex==1)
            {
                if (MessageBox.Show("你确定要删除吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //存入日志
                    LogSave.Messages("[FrmTimerInterval]", LogIDType.UserLogID, "删除考勤时段，时段全称：" + dgrd.Rows[e.RowIndex].Cells[3].Value.ToString()
                        + "，简称：" + dgrd.Rows[e.RowIndex].Cells[4].Value.ToString() + "，所属班制：" + dgrd.Rows[e.RowIndex].Cells[13].Value.ToString() + "。");

                    TIBLL.TimerInterval_Delete(Convert.ToInt32(dgrd.Rows[e.RowIndex].Cells[2].Value.ToString()), out strErr);
                    if (strErr == "Succeeds")
                    {
                        lblErr.ForeColor=Color.Blue;
                        lblErr.Text = "删除成功";

                        if (!New_DBAcess.IsDouble)
                        {
                            BindData();
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
                BindData();

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
            BindData();
        }
    }
}