using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NDataBase;
using Wilson.Controls.Docking;
using KJ128NMainRun.Graphics.DPic;


namespace KJ128NMainRun
{
    public partial class FrmRealTimeOutMineEmp : FromModel.FrmModel
    {
        RT_InOutMineEmpNameListBLL bll = new RT_InOutMineEmpNameListBLL();

        KJ128NDBTable.A_RT_Mine_List.A_RT_Mine_ListBLL abll = new KJ128NDBTable.A_RT_Mine_List.A_RT_Mine_ListBLL();
        KJ128NDBTable.A_RT_OverSee.A_Station_HeadBLL bbll = new KJ128NDBTable.A_RT_OverSee.A_Station_HeadBLL();

        private A_TreeBLL tbll = new A_TreeBLL();

        DataSet ds;

        DBAcess dbacc = new DBAcess();
        DbHelperSQL db = new DbHelperSQL();

        public FrmRealTimeOutMineEmp()
        {
            InitializeComponent();

            try
            {
                base.Text = "现升井人员";
            }
            catch (Exception ex)
            { }
            timer1.Start();
        }

        private void FrmRealTimeOutMineEmp_Load(object sender, EventArgs e)
        {
            displayData("");
        }

        #region[treeview中加载]
        private void LoadDeptTree(DateTime dateTimeStart, DateTime dateTimeEnd)
        {
            using (ds = new DataSet())
            {
                ds = db.Query("select 0 ID,'所有' Name,-1 ParentID,'false' IsChild,'true' IsUserNum,0 "+
                "Num union all select ID,name,parentid,ischild,isusernum,num from (select top 1000 t.DeptID ID,t.DeptName name,t.ParentDeptID ParentID, 'true' IsChild,'true' IsUserNum,(select count(*) from (select A.codeSenderAddress as 标识卡号,A.UserName as 姓名,A.DeptName as 部门,A.InTime as 下井时间,A.OutTime as 上井时间,A.DeptID from " +
                "dbo.His_InOutMine_" + dateTimeStart.ToString("yyyyM") + " A join Emp_Info as B on A.UserID=B.EmpID where InTime >='" + dateTimeStart.ToString("yyyy-MM-dd HH:mm:ss") + "' and inTime<='" + dateTimeEnd.ToString("yyyy-MM-dd HH:mm:ss") + "' and CodeSenderAddress not in (select CodeSenderAddress from dbo.RT_InOutMine) ) As Ri where  Ri.DeptID=t.DeptID) Num,t.serialno from dbo.Dept_Info as t order by t.serialno) m");

                treeView1.DataSouce = ds.Tables[0];
                treeView1.LoadNode("人");
            }
            treeView1.ExpandAll();
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            //displayData("");
            if (treeView1.Tag == null||treeView1.Tag.ToString() == "所有")
            {
                displayData("");
            }
            else
            {
                displayData("and DeptName = '" + treeView1.Tag.ToString() + "'");
            }
        }

        //DataGridView中的数据显示
        public void displayData(string strTemp)
        {
            DataTable dt = new DataTable();
            try
            {
                //查询考勤配置里的时间
                DataTable dtTime = new DataTable();
                DateTime dateTimeStart = new DateTime(2000, 1, 1);
                DateTime dateTimeStartTemp = new DateTime(2000, 1, 1);
                DateTime dateTimeEnd = new DateTime(2000, 1, 1);
                DateTime dateTimeEndTemp = new DateTime(2000, 1, 1);

                dtTime = bll.GetClassTimeByNowTime(DateTime.Now);

                if (dtTime != null && dtTime.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtTime.Rows)
                    {
                        //开始时间
                        if (dateTimeStart.Year == 2000)
                        {
                            dateTimeStart = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Parse(dr["StartWorkTime1"].ToString()).ToString("HH:mm:ss"));
                        }
                        else
                        {
                            if (dr["SwDateType"].ToString().Equals("-1"))
                            {
                                if (DateTime.Parse(dr["StartWorkTime1"].ToString()) <= DateTime.Parse(DateTime.Now.ToString("HH:mm:ss")))
                                {
                                    dateTimeStartTemp = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Parse(dr["StartWorkTime1"].ToString()).ToString("HH:mm:ss"));
                                }
                                else
                                {
                                    dateTimeStartTemp = DateTime.Parse(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " " + DateTime.Parse(dr["StartWorkTime1"].ToString()).ToString("HH:mm:ss"));
                                }
                            }

                            if (dateTimeStartTemp < dateTimeStart && dateTimeStartTemp.Year != 2000)
                            {
                                dateTimeStart = dateTimeStartTemp;
                            }
                        }

                        //结束时间
                        if (dateTimeEnd.Year == 2000)
                        {
                            dateTimeEnd = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Parse(dr["EndWorkTime1"].ToString()).ToString("HH:mm:ss"));
                        }
                        else
                        {
                            if (dr["EWdateType"].ToString().Equals("1"))
                            {
                                if (DateTime.Parse(dr["EndWorkTime1"].ToString()) <= DateTime.Parse(DateTime.Now.ToString("HH:mm:ss")))
                                {
                                    dateTimeEndTemp = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Parse(dr["EndWorkTime1"].ToString()).ToString("HH:mm:ss"));
                                }
                                else
                                {
                                    dateTimeEndTemp = DateTime.Parse(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " " + DateTime.Parse(dr["EndWorkTime1"].ToString()).ToString("HH:mm:ss"));
                                }
                            }

                            if (dateTimeEndTemp > dateTimeEnd && dateTimeEndTemp.Year != 2000)
                            {
                                dateTimeEnd = dateTimeEndTemp;
                            }
                        }
                    }

                    LoadDeptTree(dateTimeStart, dateTimeEnd);

                    //按照考勤配置时间查询历史下井人员
                    dt = bll.GetEmpRealTimeOutMine(dateTimeStart, dateTimeEnd, strTemp);

                    this.dataGridView1.DataSource = dt;
                }
            }
            catch { }
        }

        //点击实时更新按钮时触发timer控件的开关。
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        //鼠标点击treeview控件，按照部门筛选人员。
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.Tag = e.Node.Tag;
            if (treeView1.Tag.ToString()=="所有")
            {
                displayData("");
            }
            else
            {
                displayData("and A.DeptName = '" + treeView1.Tag.ToString()+"'");
            }
        }
    }
}
