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
using System.Threading;

namespace KJ128NMainRun.A_Report_Forms
{
    public partial class A_Month_Down_Mine_Count : KJ128NMainRun.FromModel.FrmModel
    {
        #region【定义】

        private HisStatEmpInMineBLL bll = new HisStatEmpInMineBLL();
        
        KJ128NDBTable.A_Attendance.A_AttendaceBLL T_bll = new KJ128NDBTable.A_Attendance.A_AttendaceBLL();
        
        private int countPage;
        private string where = "";
        private string date = "";

        delegate void Binddgv(DataTable dt);
        delegate void columnsvis(string str);
        delegate void LableGetStr(string str);
        delegate void picbool(bool bl);
        private Thread th = null;
        private void bind(DataTable dt)
        {
            if (dgrd.InvokeRequired)
            {
                Binddgv b = new Binddgv(bind);
                this.Invoke(b, new object[] { dt });
            }
            else
            {
                dgrd.DataSource = dt;
            }
        }
        private void cvis(string str)
        {
            if (dgrd.InvokeRequired)
            {
                columnsvis b = new columnsvis(cvis);
                this.Invoke(b, new object[] { str });
            }
            else
            {
                dgrd.Columns[str].Visible = false;
            }
        }
        private void lagetstr(string str)
        {
            if (lblCounts.InvokeRequired)
            {
                LableGetStr b = new LableGetStr(lagetstr);
                this.Invoke(b, new object[] { str });
            }
            else
            {
                lblCounts.Text = str;
            }
        }
        private void pic(bool bl)
        {
            if (pictureBox1.InvokeRequired)
            {
                picbool b = new picbool(pic);
                this.Invoke(b, new object[] { bl });

            }
            else
            {
                pictureBox1.Visible = bl;
            }
        }

        private string ud;
        public string _ud
        {
            get { return ud; }
            set { ud = value; }
        }
        private string dd;
        public string _dd
        {
            get { return dd; }
            set { dd = value; }
        }

        /// <summary>
        /// 是否启用自定义时间（false:采用默认时间，true：采用自定义时间）
        /// </summary>
        public bool blIsCustom = false;

        #endregion

        #region【构造函数】

        public A_Month_Down_Mine_Count()
        {
            InitializeComponent();
            pictureBox1.Visible = false;
            loadTree();
            BindCmd();

        }

        #endregion

        #region[绑定部门树]
        private void loadTree()
        {
            DeptTree.Nodes.Clear();
            DataTable dt = T_bll.Dept_Tree_Static();
            DeptTree.DataSouce = dt;
            DeptTree.LoadNode("");
            DeptTree.ExpandAll();
        }
        #endregion

        #region[绑定年]

        private void BindCmd()
        {
            int iYear = DateTime.Now.Year;
            for (int i = iYear - 5; i < iYear + 5; i++)
            {
                cmbYear.Items.Add(i.ToString());
            }
            //cmbYear.SelectedIndex = 5;
            cmbYear.Text = DateTime.Now.Year.ToString();
        }
        #endregion


        #region【方法：控制翻页状态】

        private void SetPageEnable(int pIndex, int sumPage)
        {
            if (pIndex == 1)
            {
                if (sumPage == 1)
                {
                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = true;
                }
            }
            else if (pIndex >= sumPage)
            {
                btnUpPage.Enabled = true;
                btnDownPage.Enabled = false;
            }
            else
            {
                btnUpPage.Enabled = true;
                btnDownPage.Enabled = true;
            }
        }

        #endregion



        #region [ 方法: 查询——无分页 ]

        /// <summary>
        /// 查询——无分页 
        /// </summary>
        private void SelectInfo_EmpInMine()
        {
            DataSet ds = bll.StatMonthEmp(date, where, rbtnCount.Checked ? "0" : "1");
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    //dgrd.DataSource = ds.Tables[0];
                    DataTable dt = ds.Tables[0];
                    //Czlt-2012-03-20 注销
                    //dt.Columns.Remove("EmpID");
                    //dt.TableName = "A_MonthDown_Mine_Count";
                    bind(dt);

                    //lblCounts.Text = "共 " + ds.Tables[0].Rows.Count.ToString() + " 个人";
                    lagetstr("共 " + ds.Tables[0].Rows.Count.ToString() + " 个人");

                    //if (dgrd.Columns.Count >= 15)
                    //{
                    //    //dgrd.Columns["EmpID"].Visible = false;
                    //    //cvis("EmpID");
                    //}
                }
                else
                {
                    DataTable dt = new DataTable("A_Month_Down_Mine_Count_BindDataGridView");
                    dt.Columns.Add("卡号");
                    dt.Columns.Add("姓名");
                    dt.Columns.Add("一月");
                    dt.Columns.Add("二月");
                    dt.Columns.Add("三月");
                    dt.Columns.Add("四月");
                    dt.Columns.Add("五月");
                    dt.Columns.Add("六月");
                    dt.Columns.Add("七月");
                    dt.Columns.Add("八月");
                    dt.Columns.Add("九月");
                    dt.Columns.Add("十月");
                    dt.Columns.Add("十一月");
                    dt.Columns.Add("十二月");
                    dt.Columns.Add("合计次数");
                    bind(dt);
                    lagetstr("共 0 个人");

                }
            }
            catch
            {
                DataTable dt = new DataTable("A_Month_Down_Mine_Count_BindDataGridView");
                dt.Columns.Add("卡号");
                dt.Columns.Add("姓名");
                dt.Columns.Add("一月");
                dt.Columns.Add("二月");
                dt.Columns.Add("三月");
                dt.Columns.Add("四月");
                dt.Columns.Add("五月");
                dt.Columns.Add("六月");
                dt.Columns.Add("七月");
                dt.Columns.Add("八月");
                dt.Columns.Add("九月");
                dt.Columns.Add("十月");
                dt.Columns.Add("十一月");
                dt.Columns.Add("十二月");
                dt.Columns.Add("合计次数");
                bind(dt);
                lagetstr("共 0 个人");

            }
            pic(false);
            th.Abort();

        }

        #endregion

        #region [ 方法: 组织查询条件 ]

        private string strWhere()
        {
            RealTimeBLL rtbll = new RealTimeBLL();

            string[,] strArray = null;
            string str = string.Empty;
            if (chkLead.Checked)
            {
                str = string.Format("(select EnumID from EnumTable"
                        + " where FunID = 4 and EnumValue = '1')");
            }
            if (!chkLead.Checked)
            {
                if (DeptTree.SelectedNode != null && DeptTree.SelectedNode.Name != "0")
                {
                    //strArray = new string[4, 4]{{"cs.CodeSenderAddress","=",txtCodeSender.Text,"int"},
                    //        {"ei.EmpName","=",txtEmpName.Text,"string"},
                    //        {"ei.DeptID","=",DeptTree.SelectedNode.Name,"int"},
                    //        {"di.DutyClassID","in",str,"int"}
                    //};

                    strArray = new string[3, 4]{{"codeSender","=",txtCodeSender.Text,"int"},
                            {"empName","=",txtEmpName.Text,"string"},
                            {"deptID","=",DeptTree.SelectedNode.Name,"int"}
                };
                }
                else
                {
                    //strArray = new string[3, 4]{{"cs.CodeSenderAddress","=",txtCodeSender.Text,"int"},
                    //        {"ei.EmpName","=",txtEmpName.Text,"string"},
                            
                    //        {"di.DutyClassID","in",str,"int"}
                    //};

                    strArray = new string[2, 4]{{"codeSender","=",txtCodeSender.Text,"int"},
                            {"empName","=",txtEmpName.Text,"string"}   
                };
                }
            }
            else
            {
                if (DeptTree.SelectedNode != null && DeptTree.SelectedNode.Name != "0")
                {
                    strArray = new string[4, 4]{{"cs.CodeSenderAddress","=",txtCodeSender.Text,"int"},
                            {"ei.EmpName","=",txtEmpName.Text,"string"},
                            
                            {"ei.DeptID","=",DeptTree.SelectedNode.Name,"int"},
                            {"di.DutyClassID","in",str,"int"}
                };
                }
                else
                {
                    strArray = new string[3, 4]{{"cs.CodeSenderAddress","=",txtCodeSender.Text,"int"},
                            {"ei.EmpName","=",txtEmpName.Text,"string"},
                            
                           
                            {"di.DutyClassID","in",str,"int"}
                };
                }
            }
            return rtbll.SelectWhere(strArray, 0);
        }

        #endregion


        #region【事件：查询】

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dgrd.Visible == true)
            {
                // 组织查询条件
                date = cmbYear.Text;
                where = strWhere();
                pictureBox1.Visible = true;
                dgrd.DataSource = null;
                ThreadStart run = new ThreadStart(SelectInfo_EmpInMine);
                th = new Thread(run);
                th.Start();
                //SelectInfo_EmpInMine();
            }
        }

        #endregion

        #region【事件：设置】

        private void btnLaws_Click(object sender, EventArgs e)
        {
            if (dgrd != null && dgrd.Rows.Count > 0)
            {
                //KJ128NDBTable.PrintBLL.Print(dgrd, "月下井次数", "共" + dgrd.Rows.Count.ToString() + "人");
                new PrintCore.ExportExcel().Sql_ExportExcel(dgrd, "");
            }
            else
            {
                MessageBox.Show("没有导出信息，请查询后导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        #endregion

       

        #region【事件：选择部门】

        private void DeptTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //if (dgrd.Visible == true)
            //{
            //    // 组织查询条件
            //    date = cmbYear.Text;
            //    where = strWhere();

            //    pictureBox1.Visible = true;
            //    ThreadStart run = new ThreadStart(SelectInfo_EmpInMine);
            //    th = new Thread(run);
            //    th.Start();

            //}
        }

        #endregion

        #region【窗体加载】

        private void A_Month_Down_Mine_Count_Load(object sender, EventArgs e)
        {
            // 组织查询条件
            date = cmbYear.Text;
            where = strWhere();

            //SelectInfo_EmpInMine();
        }

        #endregion

        private System.Windows.Forms.IButtonControl IB = null;
        private void txtSkipPage_Enter(object sender, EventArgs e)
        {
            this.IB = this.AcceptButton;
            this.AcceptButton = null;
        }

        private void txtSkipPage_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = this.IB;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmbYear.Text = DateTime.Now.Year.ToString();
            txtCodeSender.Text = "";
            txtEmpName.Text = "";
            rbtnCount.Checked = true;
            rbtnSumTime.Checked = false;
            chkLead.Checked = false;
            dgrd.DataSource = new DataTable();
            lblCounts.Text = "共 0 条记录";
        }

        private void txtEmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
        #region【事件：打印 导出】
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgrd, "月下井统计", "统计时间:" + cmbYear.Text);
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgrd, "月下井统计", "统计时间:" + cmbYear.Text);
        }
        

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgrd != null && dgrd.Rows.Count > 0)
            {
                //KJ128NDBTable.PrintBLL.Print(dgrd, cmbYear.Text + "年 每月下井次数统计", "统计时间:" + cmbYear.Text);
                KJ128NDBTable.PrintBLL.Print(dgrd, "月下井统计", "统计时间:" + cmbYear.Text);
            }
            else
            {
                MessageBox.Show("没有打印信息，请查询后打印！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
    }
}
