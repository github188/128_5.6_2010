using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using System.Threading;

namespace KJ128NMainRun.A_His_InWellCounts
{
    public partial class A_FrmHisInWellCounts : Wilson.Controls.Docking.DockContent
    {

        #region【声明】

        private A_HisInWellCountBLL Hiw = new A_HisInWellCountBLL();

        private A_TreeBLL tbll = new A_TreeBLL();

        private DataSet ds;

        private string strWhere = " 1=1";

        private string strDateTime = "";
        private string TableName = string.Empty;
        private string TableName2 = string.Empty;
        /// <summary>
        /// 每页条数
        /// </summary>
        private static int pSize = 40;

        /// <summary>
        /// 查询到记录的总页数
        /// </summary>
        private int countPage;

        //Czlt-2010-11-30 线程优化
        Thread th = null;

        #endregion

        #region【构造函数】

        public A_FrmHisInWellCounts()
        {
            InitializeComponent();

            //Czlt-2010-11-30 进度条不显示
            pictureBox1.Visible = false;       
        }

        #endregion

        
        #region【方法：加载树】
        /// <summary>
        /// 加载树
        /// </summary>
        private void LoadTree()
        {
            using (ds = new DataSet())
            {
                ds = Hiw.GetDeptTree();
                tbll.LoadTree(tvc_Dept, ds, "人", false, "所有部门");
            }
        }

        #endregion

        #region【方法:Czlt-2010-12-06 加载工种树】
        private void LoadWorkTypeTree()
        {
            using (ds = new DataSet())
            {
                ds = Hiw.GetWorkTypeTree();
                tbll.LoadTree(tvc_WorkType, ds, "人", false, "所有工种");                
            }
        }
        #endregion

        #region【方法:Czlt-2010-12-06 加载职务树】
        private void LoadDutyTree()
        {
            using (ds = new DataSet())
            {
                ds = Hiw.GetDutyTree();
                tbll.LoadTree(tvc_Duty, ds, "人", false, "所有职务");               
            }
        }
        #endregion

        #region【窗体加载】

        private void A_FrmHisInWellCounts_Load(object sender, EventArgs e)
        {
            dtp_Begin.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
            dtp_End.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            LoadTree(); //加载部门树
            LoadDutyTree();//加载职务树  //Czlt-2010-12-07
            LoadWorkTypeTree();//加载工种树 //Czlt-2010-12-07
            tvc_Dept.ExpandAll();

            cmbSelectCounts.Text = "40";

            //Czlt-2010-11-30 不捕获对错误线程的调用
            //Control.CheckForIllegalCrossThreadCalls = false;
            //strWhere = StrWhere();
            //SelectInfo(1);
        }

        #endregion

        #region 【方法: 遍历节点下的所有子节点】

        /// <summary>
        /// 遍历节点下的所有子节点
        /// </summary>
        /// <param name="tn"></param>
        private string GetNodeAllChild(TreeNode tn)
        {
            string strNodeChildName;

            strNodeChildName = " '" + tn.Tag.ToString() + "' ";
            if (tn.Nodes.Count > 0)
            {
                foreach (TreeNode n in tn.Nodes)
                {
                    string strId = string.Empty;
                    if (n.Nodes.Count > 0)
                    {
                        strId =GetNodeAllChild(n);
                    }
                    if (!strId.Equals(""))
                    {
                        strNodeChildName += " or Ei.DeptName=  "+strId;
                    }
                    else
                    {
                        strNodeChildName += " or Ei.DeptName= '" + n.Tag.ToString() + "' ";
                    }
                }
            }
            return strNodeChildName;
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

        #region 【方法: 组织查询条件】

        private string StrWhere()
        {
            strDateTime = " InTime >= '" + dtp_Begin.Text + "' And InTime <='" + dtp_End.Text + "' ";

            string strTempWhere = " 1=1 ";

            if (!txt_EmpName.Text.Trim().Equals(""))
            {
                strTempWhere += " And Ei.EmpName like  '%" + txt_EmpName.Text.Trim() + "%' ";
            }

            if (!txt_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And Hi.CodeSenderAddress = " + txt_CodeSenderAddress.Text.Trim();
            }
            
            if (tvc_Dept.SelectedNode != null && !tvc_Dept.SelectedNode.Name.Equals("0"))
            {
                //strTempWhere += " And ( Ei.DeptName  = " + GetNodeAllChild(tvc_Dept.SelectedNode) + ") ";
                string strD = GetNodeAllChild(tvc_Dept.SelectedNode);
                strTempWhere += " And ( Ei.DeptName  = " + strD  + ") ";
            }

            //Czlt-2010-11-06 职务
            if (tvc_Duty.SelectedNode != null && !tvc_Duty.SelectedNode.Name.Equals("0"))
            {
                if (tvc_Duty.SelectedNode.Name.Equals("99999"))
                {
                    strTempWhere += " And ( Ei.DutyName  = '无' or Ei.DutyName is null ) ";
                }
                else
                {
                    strTempWhere += " And ( Ei.DutyID  = " + tvc_Duty.SelectedNode.Name + ") ";
                }
            }

            //Czlt-2010-11-06 工种
            if (tvc_WorkType.SelectedNode != null && !tvc_WorkType.SelectedNode.Name.Equals("0"))
            {
                if (tvc_WorkType.SelectedNode.Name.Equals("99999"))
                {
                    //6668930
                    strTempWhere += " And ( Ei.workTypeName is null ) ";
                }
                else
                {
                    strTempWhere += " And ( Ei.workTypeID  = " + tvc_WorkType.SelectedNode.Name + ") ";
                }
            }

            return strTempWhere;
        }

        #endregion

        #region【方法：查询——人员】
        //qyz 增加跨月查询
        public void SelectInfo(int pIndex)
        {
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }
            if (DecideTime(dtp_Begin, dtp_End))
            {
                DataSet ds = Hiw.GetInfo_HisInWellCounts(pIndex, pSize, strWhere, strDateTime,TableName,TableName2);
                if (this.IsHandleCreated)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {

                        if (ds.Tables != null && ds.Tables.Count > 0)
                        {
                            // 重新设置页数
                            int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                            sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                            countPage = sumPage;
                            if (sumPage == 0)
                            {
                                dgv_Main.DataSource = ds.Tables[0];
                                lblCounts.Text = "共 0 条记录";

                                lblPageCounts.Text = "1";
                                lblSumPage.Text = "/1页";

                                btnUpPage.Enabled = false;
                                btnDownPage.Enabled = false;
                            }
                            else
                            {
                                ds.Tables[0].TableName = "A_FrmHisInWellCounts";
                                dgv_Main.DataSource = ds.Tables[0];

                                lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条记录";

                                lblPageCounts.Text = pIndex.ToString();
                                lblSumPage.Text = "/" + sumPage + "页";

                                //控制翻页状态
                                SetPageEnable(pIndex, sumPage);
                            }
                            if (dgv_Main.Columns.Count >= 6)
                            {

                                dgv_Main.Columns["标识卡号"].DisplayIndex = 0;
                                dgv_Main.Columns["姓名"].DisplayIndex = 1;
                                dgv_Main.Columns["部门"].DisplayIndex = 2;
                                dgv_Main.Columns["职务"].DisplayIndex = 3;  //Czlt-2010-12-07添加职务信息
                                dgv_Main.Columns["工种"].DisplayIndex = 4;
                                dgv_Main.Columns["下井次数"].DisplayIndex = 5;
                                dgv_Main.Columns["下井时长"].DisplayIndex = 6;

                                dgv_Main.Columns["职务"].DefaultCellStyle.NullValue = "——";//Czlt-2010-12-07添加职务信息
                                dgv_Main.Columns["工种"].DefaultCellStyle.NullValue = "——";
                            }
                        }
                    }));
                }
            }
        }
        #endregion

        #region【方法：判断时间】

        private bool DecideTime(DateTimePicker dtpBegin, DateTimePicker dtpEnd)
        {
            if ((dtpBegin.Value.AddYears(1).Year == dtpEnd.Value.Year || dtpBegin.Value.Year == dtpEnd.Value.Year) && ((dtpBegin.Value.Month == dtpEnd.Value.Month) || (dtpBegin.Value.AddMonths(1).Month == dtpEnd.Value.Month)))
            {
                this.TableName = "His_InOutMine_" + dtpBegin.Value.Year.ToString() + dtpBegin.Value.Month.ToString();
                this.TableName2 = "His_InOutMine_" + dtpEnd.Value.Year.ToString() + dtpEnd.Value.Month.ToString();
            }
            else
            {
                MessageBox.Show("不能跨多月份查询！", "提示", MessageBoxButtons.OK);
                return false;
            }
            if (Convert.ToDateTime(dtpEnd.Text) > DateTime.Now)
            {
                dtpEnd.Value = DateTime.Now;
            }
            if (Convert.ToDateTime(dtpBegin.Value) >= Convert.ToDateTime(dtpEnd.Value))
            {
                MessageBox.Show("开始时间不能大于结束时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            //Czlt-2010-11-30 优化
            //if (Convert.ToDateTime(dtpBegin.Text).AddDays(7) < Convert.ToDateTime(dtpEnd.Text))
            //{
            //    MessageBox.Show("开始时间与结束时间相差不能大于7天！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return false;
            //}
            return true;
        }

        #endregion


        #region【事件：查询】

        private void bt_Enquiries_Click(object sender, EventArgs e)
        {
            if (dtp_Begin.Text.Trim() == "" || dtp_End.Text.Trim() == "")
            {
                MessageBox.Show("开始和结束时间都不能为空！");
                return;
            }
            if (!DecideTime(dtp_Begin, dtp_End))
            {
                return;
            }

            pictureBox1.Visible = true;
            strWhere = StrWhere();
            //SelectInfo(1);
            
            //Czlt-2010-11-30 显示进度条
            pl_HisTerritorial.Enabled = false;
            th = new Thread(new ThreadStart(SelectInfo));
            th.Start();

        }

        private void SelectInfo()
        {
            SelectInfo(1);
            if (this.IsHandleCreated)
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    this.pictureBox1.Visible = false;
                    pl_HisTerritorial.Enabled = true;
                }));
            }
            th.Abort();
        }

        #endregion

        #region【事件：重置】

        private void bt_Reset_Click(object sender, EventArgs e)
        {
            dtp_Begin.Value = DateTime.Now.Date;
            dtp_End.Value = DateTime.Now;
            txt_CodeSenderAddress.Text = "";
            txt_EmpName.Text = "";
            dgv_Main.DataSource = new DataTable();
            lblCounts.Text = "共 0 条记录";
        }

        #endregion

        #region【事件：选择部门】

        private void tvc_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //tvc_Dept.SelectedNode = e.Node;
            //if (!DecideTime(dtp_Begin, dtp_End))
            //{
            //    dtp_Begin.Focus();
            //    return;
            //}

            //strWhere = StrWhere();
            //SelectInfo(1);
        }

        #endregion


        #region【事件：上一页】

        private void btnUpPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page--;
            if (page < 1)
            {
                return;
            }

            SelectInfo(page);
        }

        #endregion

        #region【事件：下一页】

        private void btnDownPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page++;

            if (page > countPage)
            {
                return;
            }

            SelectInfo(page);
        }

        #endregion

        #region【事件：跳至】

        private void txtSkipPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    string value = txtSkipPage.Text;
                    if (value.CompareTo("") == 0)       //为空值时
                    {
                        return;
                    }
                    else if (int.Parse(value) > 0)
                    {
                        int page = int.Parse(value);
                        if (page > countPage)
                        {
                            page = countPage;
                        }

                        SelectInfo(page);
                    }
                }
                catch (Exception ex)
                { }
            }
        }

        #endregion

        #region【事件：选择每页显示条数】

        private void cmbSelectCounts_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbSelectCounts.Text.Trim() == "全部")
                pSize = 9999999;
            else
                pSize = Convert.ToInt32(cmbSelectCounts.SelectedItem);

            SelectInfo(1);
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


        #region 【Czlt-2010-12-07】
        private void tvc_Duty_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //tvc_Duty.SelectedNode = e.Node;
            //if (!DecideTime(dtp_Begin, dtp_End))
            //{
            //    dtp_Begin.Focus();
            //    return;
            //}

            //strWhere = StrWhere();
            //SelectInfo(1);
        }

        private void tvc_WorkType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //tvc_WorkType.SelectedNode = e.Node;
            //if (!DecideTime(dtp_Begin, dtp_End))
            //{
            //    dtp_Begin.Focus();
            //    return;
            //}

            //strWhere = StrWhere();
            //SelectInfo(1);
        }


        private void tbc_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage != null)
            {
                switch (e.TabPageIndex)
                {
                    case 0:
                        LoadTree();
                        break;
                    case 1:
                        LoadDutyTree();
                        break;
                    case 2:
                        LoadWorkTypeTree();
                        break;
                }
            }

        }
        #endregion

        private void txt_EmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
        #region【事件：打印 导出】
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgv_Main, "历史下井人员次数", "统计时间:" + dtp_Begin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "--" + dtp_End.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgv_Main, "历史下井人员次数", "统计时间:" + dtp_Begin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "--" + dtp_End.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }
       

        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgv_Main, "历史下井人员次数", "统计时间:" + dtp_Begin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "--" + dtp_End.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        #endregion

       
    }
}