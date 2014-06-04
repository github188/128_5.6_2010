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

namespace KJ128NMainRun.A_Report_Forms
{
    public partial class A_Day_Walk_ReportForm : FromModel.FrmModel
    {
        DBAcess db = new DBAcess();
        private string dutyclassid="";
        public string _dutyclassid
        {
            get { return dutyclassid; }
            set{
                dutyclassid=value;
            }
        }
        KJ128NDBTable.A_Attendance.A_AttendaceBLL bll = new KJ128NDBTable.A_Attendance.A_AttendaceBLL();
        KJ128NDBTable.A_Report_Forms.A_Report_FormsBLL A_bll= new KJ128NDBTable.A_Report_Forms.A_Report_FormsBLL();
        public A_Day_Walk_ReportForm()
        {
            //db.ExistsSql("delete from dbo.A_baobiao ");
            //A_bll.AutoInsertReportForm();
            InitializeComponent();
            beginTime.Value = System.DateTime.Now;
            db.ExistsSql("delete from dbo.A_baobiao ");
            A_bll.AutoInsertReportForm(beginTime.Value);
            base.Text = "日下井行进路线";
            btnLaws.Text = "设置";
            base.lblMainTitle.Hide();
            base.btnAdd.Hide();
            base.btnSelectAll.Hide();
            base.btnDelete.Hide();
            base.btnUpPage.Hide();
            base.lblPageCounts.Hide();
            base.lblSumPage.Hide();
            base.btnDownPage.Hide();
            base.label6.Hide();
            base.txtSkipPage.Hide();
            base.label7.Hide();
            base.label8.Hide();
            base.cmbSelectCounts.Hide();
            base.label9.Hide();
            lblCounts.Text = "";
            loadTree();
            bindDtaGridView();
        }
        private void loadTree()

        {
            try
            {
                DeptTree.Nodes.Clear();
                DataTable dt = bll.Dept_Tree_Static();
                DeptTree.DataSouce = dt;
                DeptTree.LoadNode("");
                DeptTree.ExpandAll();
            }
            catch (Exception ex)
            { 
            }
        }
        private void bindDtaGridView()
        {
            string str = " 1=1 ";
            if (codeText.Text.Trim() != "")
            {
                str = str + " and codeID=" + codeText.Text;
            }
            if (nameText.Text.Trim() != "")
            {
                str = str + " and 姓名 like ('%" + nameText.Text + "%')";
            }
            //if (timecb.SelectedValue.ToString().Trim() != "")
            //{
            //    str = str + " and 入井时间>='" + timecb.SelectedValue.ToString() + "'";
            //}
            if (DeptTree.SelectedNode != null)
            {
                if (DeptTree.SelectedNode.Level != 0)
                {
                    str = str + " and Deptid=" + DeptTree.SelectedNode.Name;
                }
            }
            if (dutyclassid != "")
            {
                str = str + " and DutyClassID>=" + dutyclassid;
            }
            dgrd.DataSource=A_bll.selectA_baobiao(str);
            if (dgrd.Rows.Count > 0)
            {
                for (int i = 0; i < dgrd.Columns.Count; i++)
                {
                    int k = 0;
                    for (int j = 0; j < dgrd.Rows.Count; j++)
                    {
                        
                        if (dgrd[i, j].Value.ToString().Trim().Equals(""))
                        {
                            k = k + 1;
                        }
                      

                    }
                    if (k == dgrd.Columns.Count)
                    {
                        dgrd.Columns[i].Visible = false;
                    }
                }
                for (int i = 0; i < dgrd.Rows.Count; i++)
                {
                    int k = 0;
                    for (int j = 0; j < dgrd.Columns.Count; j++)
                    {
                        if (dgrd.Rows[i].Cells[j].Value.ToString().Trim().Equals(""))
                        {
                            k = k + 1;
                        }
                    }
                    if (k == dgrd.Rows.Count)
                    {
                        dgrd.Rows[i].Visible = false;
                    }
                    
                }
            }
            dgrd.Columns[0].Visible = false;
            dgrd.Columns[1].Visible = false;
            dgrd.Columns[2].Visible = false;
            dgrd.Columns[3].Visible = false;
            lblCounts.Text = "符合条件的有：" + db.GetDataSet("select count(*) from(select distinct * from dbo.A_baobiao where codeID  is not  null and " + str+" ) as t").Tables[0].Rows[0][0].ToString() + "条记录";
        }
   

        private void button2_Click(object sender, EventArgs e)
        {

            bindDtaGridView();
        }

        private void DeptTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            bindDtaGridView();
        }

        private void btnLaws_Click(object sender, EventArgs e)
        {
            A_Day_Walk_ReportForm_Set fre = new A_Day_Walk_ReportForm_Set();
            DialogResult dr = fre.ShowDialog();
            if (dr ==DialogResult.OK)
            {
                bindDtaGridView();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgrd, "日下井行进路线");
        }

        private void beginTime_ValueChanged(object sender, EventArgs e)
        {
            db.ExistsSql("delete from dbo.A_baobiao ");
            A_bll.AutoInsertReportForm(beginTime.Value);
        }

        private void nameText_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
    }
}
