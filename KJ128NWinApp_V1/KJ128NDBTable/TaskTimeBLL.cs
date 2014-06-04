using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Windows.Forms;
using System.Data;
using KJ128NInterfaceShow;
using PrintCore;

namespace KJ128NDBTable
{
    public class TaskTimeBLL
    {
        private TimePrintDAL tpdal = new TimePrintDAL();

        private DataSet ds;

        #region [ 方法: 保持打印设置 ]
        
        public int SavePrint(string str1, string str2, string str3, string str4, string str5, string str6, string str7, string strTime)
        {
            return tpdal.SavePrint(str1, str2, str3, str4, str5, str6, str7, strTime);
        }
        #endregion

        #region [ 方法: 获取打印项目 ]

        public DataTable GetPrint()
        {
            using (ds=new DataSet())
            {
                ds = tpdal.GetPrint();
                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;

        }

        #endregion

        #region [ 方法: 获取定时打印时间 ]

        public bool GetTime(ComboBox cmb_Hour, ComboBox cmb_Minute,CheckBox chb,GroupBox gbx)
        {
            using (ds=new DataSet())
            {
                ds = tpdal.GetTime();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables.Count > 0)
                    {
                        string str = ds.Tables[0].Rows[0][0].ToString();
                        if (str.Equals("0"))
                        {
                            chb.Checked = false;
                            gbx.Enabled = false;
                            cmb_Hour.Text = "00";
                            cmb_Minute.Text = "00";
                        }
                        else
                        {
                            chb.Checked = true;
                            gbx.Enabled = true;
                            cmb_Hour.Text = str.Substring(0, 2);
                            cmb_Minute.Text = str.Substring(3, 2);
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        #region [ 方法: 获得时间 ]

        public string GetTime()
        {
            DataSet ds = tpdal.GetTime();
            if (ds != null && ds.Tables.Count > 0)
            {
                string s = ds.Tables[0].Rows[0][0].ToString();
                return s;
            }
            return "";
        }

        #endregion

        #region [ 方法: 自动打印 ]

        //自动打印
        public void AutoPrint(DataGridViewKJ128 dgv, string title, string strSum)
        {
            //FormPrint print1 = new FormPrint();
            //print1.CallPrintForm(dgv, title, strSum, true);
            PrintBLL.Print(dgv, title, strSum);
        }

        #endregion

        private void Bind(DataGridViewKJ128 dgv,DataTable dt)
        {
            foreach (DataColumn col in dt.Columns)
            {
                DataGridViewColumn c = new DataGridViewColumn();
                c.DataPropertyName = col.ColumnName;
                //c.Name = col.ColumnName;
                c.HeaderText = col.ColumnName;
                dgv.Columns.Add(c);
            }
        }

        //FunID 16 时间 15是打印    EnumValue为0时不打印
        public void TimePrint()
        {
            string date = GetTime();
            DataTable dt = GetPrint();
            string s = "";
            if (date != "0")
            {
                string nowDate = DateTime.Now.ToString("HH")+":" + DateTime.Now.ToString("mm");
                if (nowDate == date)
                {
                    if (dt.Select("EnumID=1")[0]["EnumValue"].ToString() == "1")
                    {
                        s += "1,";
                        // 实时下井人员总数及人员
                        RealTimeBLL rtbll = new RealTimeBLL();
                        DataSet ds = rtbll.getRTInWellEmpInfo(0, 9999, "1=1");
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataGridViewKJ128 dgvRTInfo = new DataGridViewKJ128();
                            dgvRTInfo.DataSource = ds.Tables[0];
                            ds.Tables[0].TableName = "TaskTimeBLL_RtInOutMine";
                            Bind(dgvRTInfo,ds.Tables[0]);

                            dgvRTInfo.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                            dgvRTInfo.Columns[5].FillWeight = 130;
                            dgvRTInfo.Columns[5].HeaderText = HardwareName.Value(CorpsName.InWellTime);
                            dgvRTInfo.Columns[6].HeaderText = HardwareName.Value(CorpsName.StandingWellTime);
                            PrintBLL.Print(dgvRTInfo, "实时下井人员总数及人员", ds.Tables[1].Rows[0][0].ToString());

                            AutoPrint(dgvRTInfo, "实时下井人员总数及人员", "实时下井人员总数:" + ds.Tables[1].Rows[0][0].ToString());
                        }
                    }

                    if (dt.Select("EnumID=2")[0]["EnumValue"].ToString() == "1")
                    {
                        s += "2,";
                        // 重点区域人员总数及人员
                        RealTimeInTerritorialDAL dal = new RealTimeInTerritorialDAL();
                        DataGridViewKJ128 dgvzd = new DataGridViewKJ128();
                        ds = dal.GetAreaTable("重点");
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            dgvzd.DataSource = ds.Tables[0];
                            ds.Tables[0].TableName = "TaskTimeBLL_ImpArea";
                            Bind(dgvzd, ds.Tables[0]);
                            // print
                            AutoPrint(dgvzd, "重点区域人员总数及人员", "重点区域人员总数:" + ds.Tables[0].Rows.Count.ToString());

                        }
                    }

                    if (dt.Select("EnumID=3")[0]["EnumValue"].ToString() == "1")
                    {
                        s += "3,";
                        // 超时报警人员总数及人员
                        RealtimeOverTimeInfoBLL rtotbll = new RealtimeOverTimeInfoBLL();
                        DataGridViewKJ128 dgValue = new DataGridViewKJ128();
                        string strCounts = string.Empty;
                        rtotbll.SearchOverTimeInfo("", "", "", "0", "0", dgValue, out strCounts);

                        Bind(dgValue, ((DataView)dgValue.DataSource).Table);
                        //print
                        AutoPrint(dgValue, "超时报警人员总数及人员", "超时报警人员总数:" + ((DataView)dgValue.DataSource).Table.Rows.Count.ToString());
                    }

                    if (dt.Select("EnumID=4")[0]["EnumValue"].ToString() == "1")
                    {
                        s += "4,";
                        // 超员报警人员总数及人员
                        RealTimeOverEmpBLL rtoebll = new RealTimeOverEmpBLL();
                        DataGridViewKJ128 dgvOverEmp = new DataGridViewKJ128();
                        rtoebll.SelectOverEmp(1, dgvOverEmp);
                        Bind(dgvOverEmp, ((DataView)dgvOverEmp.DataSource).Table);
                        AutoPrint(dgvOverEmp, "超员报警人员总数及人员", "超员报警人员总数:" + ((DataView)dgvOverEmp.DataSource).Table.Rows.Count.ToString());

                    }

                    if (dt.Select("EnumID=5")[0]["EnumValue"].ToString() == "1")
                    {
                        s += "5,";
                        // 限制区域报警人员总数及人员
                        RealTimeInTerritorialDAL rtdal = new RealTimeInTerritorialDAL();
                        DataGridViewKJ128 dgvxz = new DataGridViewKJ128();
                        ds = rtdal.GetAreaTable("限制");
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            ds.Tables[0].TableName = "TaskTimeBLL_LimitArea";
                            dgvxz.DataSource = ds.Tables[0];
                            Bind(dgvxz, ds.Tables[0]);
                            AutoPrint(dgvxz, "限制区域报警人员总数及人员", "限制区域报警人员总数:" + ds.Tables[0].Rows.Count.ToString());

                            // print
                        }
                    }

                    if (dt.Select("EnumID=6")[0]["EnumValue"].ToString() == "1")
                    {
                        s += "6,";
                        // 特种作业人员工作异常报警总数及人员
                        SpecialWorkTypeTerrialSetBLL swt = new SpecialWorkTypeTerrialSetBLL();
                        DataGridViewKJ128 dgvWork = new DataGridViewKJ128();
                        string strErr = string.Empty;
                        DataSet dswork = swt.Query_RealTimeSpecialWorkTypeAlarm(1, 9999, "", out strErr);
                        if (dswork != null && dswork.Tables.Count > 0)
                        {
                            dswork.Tables[0].TableName = "TaskTimeBLL_Special";
                            dgvWork.DataSource = dswork.Tables[0];
                            if (dgvWork.Columns.Count > 0)
                            {
                                dgvWork.Columns[0].Visible = false;
                                Bind(dgvWork, dswork.Tables[0]);
                                AutoPrint(dgvWork, "特种作业人员工作异常报警总数及人员", "特种作业人员工作异常报警总数:" + dgvWork.RowCount.ToString());
                            }
                        }
                    }

                    string value = dt.Select("EnumID=7")[0]["EnumValue"].ToString();
                    if (value != "0")
                    {
                        string now = DateTime.Now.ToString("dd")+":" + DateTime.Now.ToString("HH")+":"+DateTime.Now.ToString("mm");
                        if (value == now)
                        {
                            s += "7,";
                            // 领导干部每月下井总数及时间统计
                            AttendanceBLL aBLL = new AttendanceBLL();
                            DataGridViewKJ128 dgv = new DataGridViewKJ128();
                            string strErr7 = string.Empty;
                            string where = "and DataAttendance >" + Convert.ToString(int.Parse(DateTime.Now.ToString("MM")) - 1) + "-1"
                               + " and DataAttendance<" + DateTime.Now.ToString("MM").ToString() + "-1";
                            ds = aBLL.GetAttendanceStatisticByDuty(where, " and en.DutyID in (select EnumID from EnumTable where FunID = 4 and EnumValue = '1'"
                                , out strErr7);
                            if (ds != null && ds.Tables.Count > 0)
                            {
                                ds.Tables[0].TableName = "TaskTimeBLL_LeaderMonth";
                                dgv.DataSource = ds.Tables[0];
                                Bind(dgv, ds.Tables[0]);
                                AutoPrint(dgv, "领导干部每月下井总数及时间统计", "共 " + ds.Tables[0].Rows.Count.ToString() + "人");
                            }
                        }
                    }
                    //MessageBox.Show(s);
                }
            }
        }
    }
}
