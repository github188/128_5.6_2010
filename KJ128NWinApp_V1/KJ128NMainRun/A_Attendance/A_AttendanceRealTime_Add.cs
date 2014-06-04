using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using KJ128NDBTable;
using KJ128NModel;
using Shine.Logs;
using Shine.Logs.LogType;
using KJ128NDataBase;
using KJ128A.HostBack;

namespace KJ128NMainRun.A_Attendance
{
    public partial class A_AttendanceRealTime_Add : Form
    {

        InfoClassBLL icBLL = new InfoClassBLL();
        TimerIntervalBLL tiBLL = new TimerIntervalBLL();
        AttendanceBLL aBLL = new AttendanceBLL();
        DeptBLL dBLL = new DeptBLL();
        HistoryAttendanceModel ham = new HistoryAttendanceModel();
        StationBLL sBLL = new StationBLL();
        DBAcess db = new DBAcess();
        string strErr = string.Empty;
        private int codeid = A_AttendanceRealTime.intUpDateID;
        private string name = A_AttendanceRealTime.name;
        private string deptname = A_AttendanceRealTime.deptname;
        private string strInWellDateTime = A_AttendanceRealTime.strInWellDatetime;
        private string strShortName = A_AttendanceRealTime.strShortName;
        private bool IsLoading = true;
        private A_AttendanceRealTime frmARt;

        public A_AttendanceRealTime_Add(A_AttendanceRealTime frm)
        {
            InitializeComponent();
            frmARt = frm;

            bindcombox(ddlClassAdd, ddlTimerIntervalAdd);
            sBLL.GetOutWellStationInfo(cbOutStation);
            dBLL.getDept(ddlDeptAdd);
           // MessageBox.Show(codeid.ToString());
            if (codeid != null && codeid.ToString().Length > 0)
            {
                txtBlockAdd.Text = codeid.ToString();
            }
            if (name != null && name.ToString().Length > 0)
            {
                txtUserNameAdd.Text = name;
            }
            if (deptname != null && deptname.ToString().Length > 0)
            {
                textBox_dep.Text = deptname;
            }
            try
            {
                if (strInWellDateTime != null)
                {
                    dtpBeginTimeAdd.Value = Convert.ToDateTime(strInWellDateTime);
                }
            }
            catch
            {

                dtpBeginTimeAdd.Value = DateTime.Now;
            }
            if (strShortName != null && strShortName.Length>0)
            {
                ddlTimerIntervalAdd.Text = strShortName;
            }
        }




        #region [ 事件: 补单按钮的单击事件 ]

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                lblErr.Text = "";

                if (ddlClassAdd.SelectedValue.ToString() == "0")
                {
                    lblErr.ForeColor = Color.Red;
                    lblErr.Text = "班制不能选所有!";
                    return;

                }
                if (ddlTimerIntervalAdd.SelectedValue.ToString() == "0")
                {
                    lblErr.ForeColor = Color.Red;
                    lblErr.Text = "时段不能选所有!";
                    return;

                }
                if (txtBlockAdd.Text.Trim() == "")
                {
                    lblErr.ForeColor = Color.Red;
                    lblErr.Text = "标识卡不能为空！";
                    return;
                }
                if (txtUserNameAdd.Text.Trim() == "")
                {
                    lblErr.ForeColor = Color.Red;
                    lblErr.Text = "姓名不能为空！";
                    return;
                }

                if (dtpEndTimeAdd.Value > DateTime.Now)
                {
                    lblErr.ForeColor = Color.Red;
                    lblErr.Text = "下班时间不能大于当前时间！";
                    return;
                }

                if (dtpDataAttendanceAdd.Value > DateTime.Now)
                {
                    lblErr.ForeColor = Color.Red;
                    lblErr.Text = "记工日期不能大于当前时间！";
                    return;
                }

                if (dtpBeginTimeAdd.Value > dtpEndTimeAdd.Value)
                {
                    lblErr.ForeColor = Color.Red;
                    lblErr.Text = "上班时间不能大于下班时间！";
                    return;
                }


                ham.BlockID = Convert.ToInt32(txtBlockAdd.Text.Trim());
                ham.EmployeeName = txtUserNameAdd.Text;
              //  ham.DeptID = Convert.ToInt32(ddlDeptAdd.SelectedValue.ToString());
                ham.TimerIntervalID = Convert.ToInt32(ddlTimerIntervalAdd.SelectedValue.ToString());
                ham.ClassShortName = ddlTimerIntervalAdd.Text.ToString();
                ham.ClassID = Convert.ToInt32(ddlClassAdd.SelectedValue.ToString());
                ham.BeginWorkTime = dtpBeginTimeAdd.Value.ToString();
                ham.EndWorkTime = dtpEndTimeAdd.Value.ToString();
                ham.DataAttendance = dtpDataAttendanceAdd.Value.ToString();
                ham.Remark = txtRemark.Text.Trim();


                if (cbOutStation.Text == "无")
                {
                    lblErr.ForeColor = Color.Red;
                    lblErr.Text = "出井分站不能选无!";
                    return;
                }

                string[] str = this.cbOutStation.SelectedValue.ToString().Split(new char[] { ',' });
                DataSave dsave = new DataSave();

                if (dsave.SaveCodeSenderInfo(Convert.ToInt32(str[0]), Convert.ToInt32(str[1]), 0, 0, Convert.ToDateTime(ham.EndWorkTime), ham.BlockID.ToString(),true))
                {
                    dsave.SaveCodeSenderInfo(Convert.ToInt32(str[0]), Convert.ToInt32(str[1]), 0, 1, Convert.ToDateTime(ham.EndWorkTime).AddSeconds(16), ham.BlockID.ToString(),true);

                    //aBLL.InertHistoryOutStationAndDeleteRealTimeInStation(ham.BlockID, Convert.ToDateTime(ham.EndWorkTime), Convert.ToInt32(str[0]), Convert.ToInt32(str[1]), out strErr);

                    //aBLL.GetEmployeeAttendanceRealTimeInsertAndDelete(ham, out strErr);
                    //if (strErr.ToString() == "Succeeds")
                    //{
                    //    aBLL.GetEmployeeAttendanceRealTimeDelete(ham.BlockID, out strErr);
                        //存入日志
                        LogSave.Messages("[AttendanceRealTime]", LogIDType.UserLogID, "实时考勤补单，部门为："
                            + textBox_dep.Text + "，发码器编号：" + txtBlockAdd.Text + "，员工姓名：" + txtUserNameAdd.Text
                            + "，上班时间：" + dtpBeginTimeAdd.Value.ToString("yyyy-MM-dd HH:mm:ss") + "，下班时间为：" + dtpEndTimeAdd.Value.ToString("yyyy-MM-dd HH:mm:ss") + "。");

                        bt_Save.Enabled = false;

                        lblErr.ForeColor = Color.Black;
                        lblErr.Text = "保存成功!";

                        frmARt.RefreshBackUp();

                    //}
                }
                else
                {
                    lblErr.ForeColor = Color.Red;
                    lblErr.Text = "保存失败!";
                }
            }
            catch
            {
                lblErr.Text = "填写格式不正确";
                lblErr.ForeColor = Color.Red;
            }
        }

        #endregion

        #region【事件：返回】

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void bindcombox(ComboBox cb1,ComboBox cb2)
        {
            if (IsLoading)//钱耀祖 2012-6-11 修改(支持多个班次切换)
            {
                cb1.DataSource = db.GetDataSet("select ID,ShortName from InfoClass").Tables[0];
                cb1.DisplayMember = "ShortName";
                cb1.ValueMember = "ID";
                IsLoading = false;
            }
            if (cb1.SelectedValue != null)
            {
                cb2.DataSource = db.GetDataSet("select ID,NameShort from TimerInterval where ClassID=" + cb1.SelectedValue.ToString()).Tables[0];
                cb2.DisplayMember = "NameShort";
                cb2.ValueMember = "ID";
            }
        }

        private void ddlClassAdd_SelectedValueChanged(object sender, EventArgs e)
        {
            bindcombox(ddlClassAdd, ddlTimerIntervalAdd);
        }

        private void cbOutStation_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtBlockAdd_TextChanged(object sender, EventArgs e)
        {
            //if (txtBlockAdd.Text.Equals(""))
            //{
            //    txtUserNameAdd.Enabled = false;
            //}
            //{
            //    DataTable dt = db.GetDataSet("select e.EmpName from dbo.Emp_Info as e left join dbo.CodeSender_Set as c on c.UserID=e.EmpID where c.CsTypeID=0 and c.CodeSenderID=" + txtBlockAdd.Text).Tables[0];
            //    if (dt != null && dt.Rows.Count > 0)
            //    {
            //        txtUserNameAdd.Text = dt.Rows[0][0].ToString();
            //        txtUserNameAdd.Enabled = false;
            //    }
            //    else
            //    {
            //        txtUserNameAdd.Enabled = true;
            //    }
            //}
        }

        private void txtUserNameAdd_KeyPress(object sender, KeyPressEventArgs e)
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
