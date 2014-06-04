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
using System.Web.UI.WebControls;

namespace KJ128NMainRun.A_Attendance
{
    public partial class A_AddHistoryAttendance_Add : Form
    {
        
        InfoClassBLL icBLL = new InfoClassBLL();
        TimerIntervalBLL tiBLL = new TimerIntervalBLL();
        DeptBLL dBLL = new DeptBLL();
        AttendanceBLL aBLL = new AttendanceBLL();
        AddEmpBLL aeBLL = new AddEmpBLL();
        string strErr = string.Empty;
        HistoryAttendanceModel ham = new HistoryAttendanceModel();
        DBAcess db = new DBAcess();
        private A_AddHistoryAttendance Afr;
        private DataSet ds;

        private bool blIsAdd = true;
        private bool IsLoading = true;

        //Czlt-2010-10-3
        A_HisInWellCountBLL hisWellBll = new A_HisInWellCountBLL();

        #region【构造函数】

        public A_AddHistoryAttendance_Add(A_AddHistoryAttendance frm)
        {
            InitializeComponent();
            Afr = frm;
            blIsAdd = frm._isAdd;

            bindcombox(ddlClassAdd, ddlTimerIntervalAdd);

            if (blIsAdd)        //补单
            {
                GetDeptInfo();          //部门
                GetEmpName(cmbDept);    //姓名
            }
            else                //修改
            {
                if (Afr._id != null && Afr._id != "")
                {
                    DataSet dsHisA;
                    using (dsHisA = new DataSet())
                    {
                        dsHisA = aBLL.GetEmployeeAttendanceHistoryList(" and H.ID=" + Afr._id, 1, 1,frm.dtpStartTime.Value.ToString("yyyyM"),frm.dtpStartTime.Value.ToString("yyyyM"), out strErr);
                        if (dsHisA != null && dsHisA.Tables.Count > 0)
                        {
                            GetDeptInfo();          //部门

                            cmbDept.SelectedValue = dsHisA.Tables[0].Rows[0]["DeptID"].ToString();

                            GetEmpName(cmbDept);    //姓名
                            cmbEmpName.Text = dsHisA.Tables[0].Rows[0]["EmployeeName"].ToString();

                            txtCodeSenderAddress.Text = dsHisA.Tables[0].Rows[0]["BlockID"].ToString();
                            ddlClassAdd.SelectedValue = dsHisA.Tables[0].Rows[0]["ClassID"].ToString();
                            dtpBeginTimeAdd.Text = dsHisA.Tables[0].Rows[0]["BeginWorkTime"].ToString();
                            dtpEndTimeAdd.Text = dsHisA.Tables[0].Rows[0]["EndWorkTime"].ToString();
                            txtRemarkAdd.Text = dsHisA.Tables[0].Rows[0]["Remark"].ToString();
                            ddlTimerIntervalAdd.Text = dsHisA.Tables[0].Rows[0]["ClassShortName"].ToString();
                        }
                    }
                }
                cmbDept.Enabled = false;
                txtCodeSenderAddress.Enabled = false;
                cmbEmpName.Enabled = false;
                btnReset.Enabled = false;
            }
        }

        #endregion

        #region【方法：加载部门信息】

        private void GetDeptInfo()
        {
            using (ds = new DataSet())
            {
                ds = aBLL.getDept();
                if (ds!= null && ds.Tables.Count > 0)
                {
                    cmbDept.DataSource = ds.Tables[0];
                    cmbDept.DisplayMember = "DeptName";
                    cmbDept.ValueMember = "DeptID";
                }
            }
        }

        #endregion

        #region【方法：加载人员信息】

        private void GetEmpName(ComboBox cmb)
        {
            using (ds=new DataSet())
            {
                string strDeptID;
                if (cmb.SelectedValue != null)
                {
                    strDeptID = cmb.SelectedValue.ToString();
                }
                else
                {
                    strDeptID = "0";
                }
                ds = aBLL.getEmpName(strDeptID);
                if (ds != null && ds.Tables.Count > 0)
                {
                    cmbEmpName.DataSource = ds.Tables[0];
                    cmbEmpName.DisplayMember = "EmpName";
                    cmbEmpName.ValueMember = "EmpID";
                }
            }
        }

        #endregion

        #region【事件：选择班制】

        private void ddlClassAdd_SelectedValueChanged(object sender, EventArgs e)
        {
            bindcombox(ddlClassAdd, ddlTimerIntervalAdd);
        }

        #endregion


        #region【事件：保存】

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";

            if (cmbDept.SelectedValue == null || cmbDept.Text.Equals("无"))
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "请选择部门！";
                return;
            }

            if (cmbEmpName.SelectedValue==null || cmbEmpName.Text.Equals("无"))
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "请选择姓名！";
                return;
            }
            if (this.txtCodeSenderAddress.Text.Trim() == "")
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "标识卡号不能为空!";
                return;
            }
            if (this.ddlClassAdd.Items.Count == 0)
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "没有班制，无法进行下一步的操作!";
                return;
            }

            if (ddlTimerIntervalAdd.Items.Count == 0)
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "没有时段，无法进行下一步的操作!!";
                return;
            }
            if (dtpBeginTimeAdd.Value > dtpEndTimeAdd.Value)
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "上班时间不能大于下班时间!";
                return;
            }
            if (dtpEndTimeAdd.Value > DateTime.Now)
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "下班时间不能大于当前时间!";
                return;
            }
            if (dtpBeginTimeAdd.Value.AddMinutes(30) > dtpEndTimeAdd.Value)
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "上班时间要比下班时间提前30分钟!";
                return;
            }

            ham.ID_HistoryAttendance = Convert.ToInt64(Afr._id);
            ham.BlockID = Convert.ToInt32(txtCodeSenderAddress.Text.Trim());
            ham.EmployeeID = int.Parse(cmbEmpName.SelectedValue.ToString());
            ham.EmployeeName = cmbEmpName.Text;
            ham.DeptID = Convert.ToInt32(cmbDept.SelectedValue.ToString());
            ham.ClassID = Convert.ToInt32(ddlClassAdd.SelectedValue.ToString());
            ham.TimerIntervalID = Convert.ToInt32(ddlTimerIntervalAdd.SelectedValue.ToString());
            ham.ClassShortName = ddlTimerIntervalAdd.Text.Trim();
            ham.BeginWorkTime = dtpBeginTimeAdd.Value.ToString();
            ham.EndWorkTime = dtpEndTimeAdd.Value.ToString();
            ham.DataAttendance = dtpDataAttendanceAdd.Value.ToString("yyyy-MM-dd");
            ham.Remark = txtRemarkAdd.Text.Trim();
            ham.OperatorID = 0;
            if (Afr._isAdd)
            {
                if (MessageBox.Show("是否同意添加数据，添加后将不能修改、删除", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                   // aBLL.AddEmployeeAttendanceHistory(ham, dtpDataAttendanceAdd.Value.ToString("yyyyM"), out strErr);
                    //Czlt-2010-11-03 - 判断当日补单中有没有重复班次
                    if (IsExists(ham))
                    {
                        MessageBox.Show("员工 " + ham.EmployeeName + " " + ham.DataAttendance + "日 " + ham.ClassShortName + "班次的信息已经存在\n\n           不能进行历史补单操作！", "提示", MessageBoxButtons.OK);
                        return;
                    }

                    //Czlt-2010-11-03 - 向考勤表里面插入一条记录
                    aBLL.AddEmployeeAttendanceHistory(ham, dtpDataAttendanceAdd.Value.ToString("yyyyM"), out strErr);

                    //Czlt-2010-11-03 - 向历史进出分站表里面插入一条上下班记录
                    AddHisInOutStation(ham);


                    if (strErr == "Succeeds")
                    {
                        //获取统计表中该卡的信息
                        DataSet dsKqtj = aBLL.GetKQTJbyCards(txtCodeSenderAddress.Text.Trim(), dtpDataAttendanceAdd.Value, out strErr);


                        if (strErr.Equals("Succeeds"))
                        {
                            //插入信息               
                            if (dsKqtj.Tables.Count > 0 && dsKqtj.Tables[0].Rows.Count > 0)
                            {
                                
                            }
                            else
                            {
                                aBLL.AddKQTJ(dtpDataAttendanceAdd.Value, ham.BlockID, ham.EmployeeName, ham.DeptID, cmbDept.Text, out strErr);
                            }

                            aBLL.UpdateKQTJ(dtpDataAttendanceAdd.Value, ham.BlockID, ham.ClassShortName,ham.DeptID,cmbDept.Text, out strErr);

                            //存入日志
                            LogSave.Messages("[AddHistoryAttendance]", LogIDType.UserLogID, "添加历史补单，部门编号为："
                                + ham.DeptID.ToString() + "，发码器编号：" + ham.BlockID.ToString() + "，员工姓名：" + ham.EmployeeName
                                + "，上班时间：" + ham.BeginWorkTime + "。");


                            lblErr.ForeColor = Color.Black;
                            lblErr.Text = "保存成功!";
                            Afr.RefreshBackUp();
                        }
                        else
                        {
                            lblErr.ForeColor = Color.Red;
                            lblErr.Text = "保存失败!";
                        }
                    }
                    else
                    {
                        lblErr.ForeColor = Color.Red;
                        lblErr.Text = "保存失败!";
                    }
                }
            }
            else
            {

                aBLL.UpdateEmployeeAttendanceHistory(ham, out strErr);
                if (strErr == "Succeeds")
                {
                    //存入日志
                    LogSave.Messages("[AddHistoryAttendance]", LogIDType.UserLogID, "修改历史补单，部门编号为："
                        + ham.DeptID.ToString() + "，发码器编号：" + ham.BlockID.ToString() + "，员工姓名：" + ham.EmployeeName
                        + "，上班时间：" + ham.BeginWorkTime + "。");

                    lblErr.ForeColor = Color.Black;
                    lblErr.Text = "修改成功!";
                    Afr.RefreshBackUp();
                }
                else
                {
                    lblErr.ForeColor = Color.Red;
                    lblErr.Text = "修改失败!";
                }
            }
        }

        #endregion

        #region【事件：重置】

        private void btnReset_Click(object sender, EventArgs e)
        {
            GetDeptInfo();          //部门
            GetEmpName(cmbDept);    //姓名

            bindcombox(ddlClassAdd, ddlTimerIntervalAdd);

            txtCodeSenderAddress.Text = "";
            
            txtRemarkAdd.Text = "";
        }

        #endregion

        #region【事件：返回】

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region【方法：绑定班制、班次】

        private void bindcombox(ComboBox cb1, ComboBox cb2)
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

        #endregion


        #region【事件：选择部门】

        private void cmbDept_DropDownClosed(object sender, EventArgs e)
        {
            GetEmpName(cmbDept);    //姓名
        }

        #endregion

        #region【事件：选择姓名】

        private void cmbEmpName_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbEmpName.SelectedValue != null)
            {
                txtCodeSenderAddress.Text = GetCodeSenderAddress(cmbEmpName.SelectedValue.ToString());
            }
            else
            {
                txtCodeSenderAddress.Text = "";
            }
        }

        #endregion

        #region【方法：获取员工的标识卡号】

        private string GetCodeSenderAddress(string strEmpID)
        {
            using (ds=new DataSet())
            {
                ds = aBLL.getCodeSenderAddress(strEmpID);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return ds.Tables[0].Rows[0][0].ToString();
                    }
                }
            }
            return "";
        }

        #endregion

        #region【Czlt-2010-11-03 - 向历史进出分站表里面插入一条记录】

        private void AddHisInOutStation(HistoryAttendanceModel haModel)
        {
            string strStatHead = hisWellBll.GetStationHeadInfo();
            DataTable dtHisInOutMine = CreateHisInOutMine();
            DataRow drHis = dtHisInOutMine.NewRow();
            DataSet dsEmp = hisWellBll.GetEmpInfoBll(haModel.EmployeeID.ToString());
            if (String.IsNullOrEmpty(strStatHead))
            {
                strStatHead = "0,0,0";
            }
            string[] strSta = strStatHead.Split(',');

            if (dsEmp != null && dsEmp.Tables.Count > 0)
            {
                drHis["HisInOutMineID"] = Int64.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + int.Parse(haModel.BlockID.ToString()).ToString("0000"));
                drHis["InStationAddress"] = Int32.Parse(strSta[0].ToString());
                drHis["InStationHeadAddress"] = Int32.Parse(strSta[1].ToString());
                drHis["InWellPlace"] = strSta[2].ToString();
                drHis["CodeSenderAddress"] = haModel.BlockID.ToString();
                drHis["UserID"] = dsEmp.Tables[0].Rows[0]["EmpId"];
                drHis["UserNo"] = dsEmp.Tables[0].Rows[0]["EmpNo"];
                drHis["UserName"] = dsEmp.Tables[0].Rows[0]["EmpName"];
                drHis["DeptID"] = dsEmp.Tables[0].Rows[0]["DeptID"];
                drHis["DeptName"] = dsEmp.Tables[0].Rows[0]["DeptName"];
                drHis["DutyID"] = dsEmp.Tables[0].Rows[0]["DutyID"];
                drHis["DutyName"] = dsEmp.Tables[0].Rows[0]["DutyName"];
                drHis["WorkTypeID"] = dsEmp.Tables[0].Rows[0]["workTypeID"];
                drHis["WorkTypeName"] = dsEmp.Tables[0].Rows[0]["WorkTypeName"];
                drHis["InTime"] = haModel.BeginWorkTime;
                drHis["OutStationAddress"] = Int32.Parse(strSta[0].ToString());
                drHis["OutStationHeadAddress"] = Int32.Parse(strSta[1].ToString());
                drHis["OutWellPlace"] = strSta[2].ToString();
                drHis["OutTime"] = haModel.EndWorkTime;
                drHis["ContinueTime"] = (int)(((TimeSpan)(DateTime.Parse(haModel.EndWorkTime) - DateTime.Parse(haModel.BeginWorkTime))).TotalSeconds);
                drHis["IsMend"] = 1;

                hisWellBll.AddHisInOutMineBll(drHis, DateTime.Parse(haModel.BeginWorkTime).ToString("yyyyM"));

            }
        }

        /// <summary>
        /// 判断历史表中是不是有该员工补单日的班次信息
        /// </summary>
        /// <param name="haModel"></param>
        /// <returns></returns>
        private bool IsExists(HistoryAttendanceModel haModel)
        {
            return hisWellBll.GetEmpClassInfo(DateTime.Parse(haModel.BeginWorkTime).ToString("yyyyM"), haModel.BlockID.ToString(), haModel.EmployeeID.ToString(), haModel.ClassID.ToString(), haModel.ClassShortName, haModel.DataAttendance);
        }

        #region 【方法：构建历史进出井表】
        /// <summary>
        /// 构造历史进出井表
        /// </summary>
        /// <returns></returns>
        private DataTable CreateHisInOutMine()
        {
            DataTable dt = new DataTable("His_InOutMine");
            dt.Columns.Add("HisInOutMineID", typeof(System.Int64));
            dt.Columns.Add("InStationAddress", typeof(System.Int32));
            dt.Columns.Add("InStationHeadAddress", typeof(System.Int32));
            dt.Columns.Add("InWellPlace", typeof(System.String));
            dt.Columns.Add("CodeSenderAddress", typeof(System.Int32));
            dt.Columns.Add("UserID", typeof(System.Int32));
            dt.Columns.Add("UserNo", typeof(System.String));
            dt.Columns.Add("UserName", typeof(System.String));
            dt.Columns.Add("DeptID", typeof(System.Int32));
            dt.Columns.Add("DeptName", typeof(System.String));
            dt.Columns.Add("DutyID", typeof(System.Int32));
            dt.Columns.Add("DutyName", typeof(System.String));
            dt.Columns.Add("WorkTypeID", typeof(System.Int32));
            dt.Columns.Add("WorkTypeName", typeof(System.String));
            dt.Columns.Add("InTime", typeof(System.DateTime));
            dt.Columns.Add("OutStationAddress", typeof(System.Int32));
            dt.Columns.Add("OutStationHeadAddress", typeof(System.Int32));
            dt.Columns.Add("OutWellPlace", typeof(System.String));
            dt.Columns.Add("OutTime", typeof(System.DateTime));
            dt.Columns.Add("ContinueTime", typeof(System.Int64));
            dt.Columns.Add("isMend", typeof(System.Boolean));
            return dt;
        }
        #endregion

        private void txtRemarkAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

      
        #endregion

    }
}
