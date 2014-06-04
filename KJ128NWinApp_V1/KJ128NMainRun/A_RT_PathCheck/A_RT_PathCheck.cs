using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDataBase;
using KJ128NDBTable;

namespace KJ128NMainRun.A_RT_PathCheck
{
    public partial class A_RT_PathCheck : FromModel.FrmModel
    {
        DBAcess db = new DBAcess();

        A_RT_PathCheckBLL bll = new A_RT_PathCheckBLL();

        string strw = " 1=1";

        public A_RT_PathCheck()
        {
            InitializeComponent();
            btnAdd.Hide();
            btnDelete.Hide();
            btnDownPage.Hide();
            btnSelectAll.Hide();
            btnUpPage.Hide();
            btnLaws.Hide();
            cmbSelectCounts.Hide();
            lblPageCounts.Hide();
            lblSumPage.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            txtSkipPage.Hide();
            LoadTree();
            BindData();
        }

        public void LoadTree()
        {
            Path_Tree.DataSouce = db.GetDataSet("select 0 ID,'所有' Name,-1 as ParentID,'False' as IsChild ,'True' as IsUserNum, 0 Num union all select PIF.Id ID,PIF.pathname Name,0 as ParentID,'True' as IsChild ,'true' as IsUserNum ,(SELECT COUNT(rt.EmpID) FROM dbo.TimerInterval t INNER JOIN   dbo.RealTimePathCheck rt ON   t.ID = rt.Interval LEFT  JOIN   dbo.Path_Emp_Relation p INNER JOIN    dbo.Path_Info po ON p.PathNo = po.PathNo AND p.PathNo = po.PathNo ON rt.EmpID = p.EmpID  where po.Id=PIF.Id ) Num  from Path_Info AS PIF").Tables[0];
            Path_Tree.LoadNode("人");
            Path_Tree.ExpandAll();
        }

        private string StrWhere()
        {
            string str = " e.EmpName like ('%"+Text_Name.Text+"%')";
            if (Path_Tree.SelectedNode != null)
            {
                if (Path_Tree.SelectedNode.Name.Trim() != "0")
                {
                    str += " and Path_Info.Id=" + Path_Tree.SelectedNode.Name;
                }
            }
            if (Text_Code.Text.Trim() != "")
            {
                str += " and dbo.CodeSender_Set.CodeSenderAddress=" + Text_Code.Text;
            }
            return str;
            
        }


        private void BindData()
        {

            dgrd.DataSource = bll.A_RT_PathCheck(strw);
            dgrd.Columns["标识卡号"].DisplayIndex = 0;
            dgrd.Columns["姓名"].DisplayIndex = 1;
            dgrd.Columns["部门"].DisplayIndex = 2;
            dgrd.Columns["工种"].DisplayIndex = 3;
            dgrd.Columns["职务"].DisplayIndex = 4;
            dgrd.Columns["班次"].DisplayIndex = 5;
            dgrd.Columns["巡检路线"].DisplayIndex = 6;
            dgrd.Columns["开始巡检时间"].DisplayIndex = 7;
            dgrd.Columns["现处位置"].DisplayIndex = 8;
            dgrd.Columns["入现处位置时间"].DisplayIndex = 9;

            dgrd.Columns["ID"].Visible = false;
            dgrd.Columns["EmpID"].Visible = false;
            dgrd.Columns["pid"].Visible = false;
            dgrd.Columns["tid"].Visible = false;
            lblMainTitle.Text = "一共有" + dgrd.Rows.Count.ToString()+"人";
            lblCounts.Text = "符合条件：共有" + dgrd.Rows.Count.ToString() + "记录";
           
        }

        private void Quey_Click(object sender, EventArgs e)
        {
            strw = StrWhere();
            BindData();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BindData();
        }

        private void Path_Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadTree();
            strw = StrWhere();
            BindData();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgrd, "实时巡检", lblCounts.Text);
        }

        private void Return_Click(object sender, EventArgs e)
        {
            Text_Name.Text = "";
            Text_Code.Text = "";
            strw = StrWhere();
            BindData();
        }

        #region【事件：DataGridView错误处理】

        private void dgv_Main_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string strErr = e.Exception.Message;
            e.ThrowException = false;
        }

        #endregion

        private IButtonControl IB = null;
        private void txtSkipPage_Enter(object sender, EventArgs e)
        {
            this.IB = this.AcceptButton;
            this.AcceptButton = null;
        }

        private void txtSkipPage_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = this.IB;
        }

        private void Text_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
    }
}
