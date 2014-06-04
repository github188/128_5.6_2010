using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using System.Threading;
using System.IO;

namespace KJ128NMainRun.A_His_StationHead
{
    public partial class A_FrmHisStationHead : FromModel.FrmModel
    {

        #region【声明】

        private A_TreeBLL tbll = new A_TreeBLL();
        private int flag = 0;
        private A_HisStationHeadBLL rtsbll = new A_HisStationHeadBLL();

        Thread t = null;
        Thread pageThread = null;
        private DataSet ds;

        private bool blIsEmp = true;

        private string strWhere = "1=1";

        //private delegate void SelectEmp(int pindex);

        //private delegate void SelectEqu(int pindex);

        int ppindex;

        delegate void Threadas(int pindex);


        /// <summary>
        /// 每页条数
        /// </summary>
        private static int pSize = 40;

        /// <summary>
        /// 查询到记录的总页数
        /// </summary>
        private int countPage;
        private int countSize = 0;
        #endregion


        #region【构造函数】

        public A_FrmHisStationHead()
        {
            InitializeComponent();
            LoadTree(1);
            dtp_Ter_Begin.Value = DateTime.Now.Date;
            dtp_Ter_End.Value = DateTime.Now;
            pictureBox1.Visible = false;
        }

        #endregion

        #region【窗体加载】

        private void A_FrmHisStationHead_Load(object sender, EventArgs e)
        {
            LoadTree(2);
            tvc_StationHead.ExpandAll();
        }

        #endregion

        #region【方法：加载树】
        /// <summary>
        /// 加载树
        /// </summary>
        /// <param name="intModel">1:部门树，2：分站树</param>
        private void LoadTree(int intModel)
        {
            switch (intModel)
            {
                case 1:

                    #region【部门树】

                    using (ds = new DataSet())
                    {
                        ds = rtsbll.GetDeptTree();

                        tbll.LoadTree(tvc_Dept, ds, "人", false, "所有部门");
                    }

                    #endregion

                    break;

                case 2:

                    #region【分站树】

                    using (ds = new DataSet())
                    {
                        ds = rtsbll.GetStaHeadTree();

                        tbll.LoadTree(tvc_StationHead, ds, "人", false, "所有分站");
                    }

                    #endregion

                    break;
                case 3: //czlt-2010-12-07
                    #region【添加工种树】
                    using (ds = new DataSet())
                    {
                        ds = rtsbll.GetDuty();

                        tbll.LoadTree(tvc_WorkType, ds, "人", false, "所有工种");
                    }
                    #endregion
                    break;

                default:
                    break;
            }
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

            strNodeChildName = tn.Name;
            if (tn.Nodes.Count > 0)
            {
                foreach (TreeNode n in tn.Nodes)
                {

                    string strDid = string.Empty;
                    if (n.Nodes.Count > 0)
                    {
                        strDid=GetNodeAllChild(n);
                    }
                    if (!strDid.Equals(""))
                    {
                        strNodeChildName += " or deptid = " + n.Name + " or deptid = " + strDid;
                    }
                    else
                    {
                        strNodeChildName += " or deptid = " + n.Name;
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
                if (sumPage == 1 || sumPage == 0)
                {
                    btnUpPage.Invoke(new SetEnable(this.SetbtnUpPage), new object[] { false });
                    btnDownPage.Invoke(new SetEnable(this.SetbtnDownPage), new object[] { false });
                }
                else
                {
                    btnUpPage.Invoke(new SetEnable(this.SetbtnUpPage), new object[] { false });
                    btnDownPage.Invoke(new SetEnable(this.SetbtnDownPage), new object[] { true });
                }
            }
            else if (pIndex >= sumPage)
            {
                btnUpPage.Invoke(new SetEnable(this.SetbtnUpPage), new object[] { true });
                btnDownPage.Invoke(new SetEnable(this.SetbtnDownPage), new object[] { false });
            }
            else
            {
                btnUpPage.Invoke(new SetEnable(this.SetbtnUpPage), new object[] { true });
                btnDownPage.Invoke(new SetEnable(this.SetbtnDownPage), new object[] { true });
            }
        }

        #endregion

        #region 【方法: 组织查询条件】

        private string StrWhere()
        {
            string strTempWhere = " InStationHeadTime >= '" + dtp_Ter_Begin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' And InStationHeadTime <='" + dtp_Ter_End.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' ";

            if (tbc.SelectedTab != null)
            {
                if (tbc.SelectedTab.Name.Equals("tbp_Dept"))        //部门
                {
                    if (tvc_Dept.SelectedNode != null && !tvc_Dept.SelectedNode.Name.Equals("0"))
                    {
                        string strD = GetNodeAllChild(tvc_Dept.SelectedNode);
                        strTempWhere += " And ( deptid = " + strD + " )";

                        //strTempWhere += " And ( deptid = " + GetNodeAllChild(tvc_Dept.SelectedNode) + " )";
                    }
                }
                else if (tbc.SelectedTab.Name.Equals("tbp_StationHead"))    //分站
                {
                    if (tvc_StationHead.SelectedNode != null && !tvc_StationHead.SelectedNode.Name.Equals("0"))
                    {
                        if (tvc_StationHead.SelectedNode.Name.Substring(0, 1).Equals("S"))     //传输分站  
                        {
                            strTempWhere += " And  StationAddress  = " + tvc_StationHead.SelectedNode.Name.Substring(1);
                        }
                        else if (tvc_StationHead.SelectedNode.Name.Substring(0, 1).Equals("H"))
                        {
                            strTempWhere += " And  StationHeadAddress  = " + tvc_StationHead.SelectedNode.Name.Substring(1) + " And StationAddress  = " + tvc_StationHead.SelectedNode.Parent.Name.Substring(1);
                        }
                    }
                }
                else if (tbc.SelectedTab.Name.Equals("tbp_WorkType"))
                {
                    if (tvc_WorkType.SelectedNode != null && !tvc_WorkType.SelectedNode.Name.Equals("0"))
                    {
                        if (tvc_WorkType.SelectedNode.Name.Equals("99999"))
                        {
                            strTempWhere += "And WorkTypeName is null ";
                        }
                        else
                        {
                            strTempWhere += "And WorkTypeID =" + tvc_WorkType.SelectedNode.Name;
                        }
                    }
                }
            }

            if (!txt_EmpName.Text.Trim().Equals(""))
            {
                if (blIsEmp)            //人员
                {
                    strTempWhere += " And UserName  like  '%" + txt_EmpName.Text.Trim() + "%' ";
                }
                else                    //设备
                {
                    strTempWhere += " And UserName  like  '%" + txt_EmpName.Text.Trim() + "%' ";
                }
            }

            if (!txt_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And CodeSenderAddress  = " + txt_CodeSenderAddress.Text.Trim();
            }
            if (rb_Emp.Checked)
            {
                strTempWhere += " and cstypeid=0";
            }
            if (rb_Equ.Checked)
            {
                strTempWhere += " and cstypeid=1";
            }
            if (rbtNoSet.Checked)
            {
                strTempWhere += " and cstypeid is null";
            }
            return strTempWhere;
        }

        #endregion

        #region[线程方法]
        private delegate void DgvBinder(DataSet ds);
        private void DgvBind(DataSet ds)
        {
            //DateTime dts = DateTime.Now;
            ds.Tables[0].TableName = "A_FrmHisStationHead_Info";
            dgv_Main.DataSource = ds.Tables[0];
            //File.AppendAllText("D:\\TempTxt.txt", "绑定数据时间：" + (DateTime.Now - dts).TotalSeconds.ToString() + Environment.NewLine, Encoding.Unicode);
        }

        private delegate void DgvColumnVisibleSet(string columnname, bool visible);
        private void SetDgvColumnVisible(string columnname, bool visible)
        {
            dgv_Main.Columns[columnname].Visible = visible;
        }

        private delegate void DgvColumnFormatSet(string columnname);
        private void SetDgvColumnFormat(string columnname)
        {
            dgv_Main.Columns[columnname].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
        }

        private delegate void DgvColumnDisplaySet(string columnname, int index);
        private void SetDgvColumnDisplay(string columnname, int index)
        {
            dgv_Main.Columns[columnname].DisplayIndex = index;
        }

        private delegate void SetText(string text);
        private void SetlblMainTitle(string text)
        {
            lblMainTitle.Text = text;
        }
        private void SetlblCounts(string text)
        {
            lblCounts.Text = text;
        }
        private void SetlblPageCounts(string text)
        {
            lblPageCounts.Text = text;
        }
        private void SetlblSumPage(string text)
        {
            lblSumPage.Text = text;
        }

        private delegate void SetEnable(bool enable);
        private void SetbtnUpPage(bool enable)
        {
            btnUpPage.Enabled = enable;
        }
        private void SetbtnDownPage(bool enable)
        {
            btnDownPage.Enabled = enable;
        }
        private void SetPicVisible(bool vis)
        {
            pictureBox1.Visible = vis;
        }
        private void SetBtnSearch(bool enable)
        {
            bt_EmpOverTime_Enquiries.Enabled = enable;
        }
        private void SetBtnReset(bool enable)
        {
            bt_EmpOverTime_Reset.Enabled = enable;
        }

        private delegate void ControlEnableSet(Control c, bool enable);
        private void SetControlEnable(Control c, bool enable)
        {
            c.Enabled = enable;
        }

        private void ControlSet(bool enable)
        {
            try
            {
                tvc_StationHead.Invoke(new ControlEnableSet(this.SetControlEnable), new object[] { tvc_StationHead, enable });
                tvc_Dept.Invoke(new ControlEnableSet(this.SetControlEnable), new object[] { tvc_Dept, enable });
                groupBox1.Invoke(new ControlEnableSet(this.SetControlEnable), new object[] { groupBox1, enable });
                btnUpPage.Invoke(new ControlEnableSet(this.SetControlEnable), new object[] { btnUpPage, enable });
                btnDownPage.Invoke(new ControlEnableSet(this.SetControlEnable), new object[] { btnDownPage, enable });
                txtSkipPage.Invoke(new ControlEnableSet(this.SetControlEnable), new object[] { txtSkipPage, enable });
                cmbSelectCounts.Invoke(new ControlEnableSet(this.SetControlEnable), new object[] { cmbSelectCounts, enable });
                bt_EmpOverTime_Enquiries.Invoke(new ControlEnableSet(this.SetControlEnable), new object[] { bt_EmpOverTime_Enquiries, enable });
                bt_EmpOverTime_Reset.Invoke(new ControlEnableSet(this.SetControlEnable), new object[] { bt_EmpOverTime_Reset, enable });   
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        

        #region【方法：判断时间】
        private string TableName = string.Empty;
        private string TableName2 = string.Empty;
        private bool DecideTime(DateTimePicker dtpBegin, DateTimePicker dtpEnd)
        {
            //Czlt-2011-04-09 可以跨月查询
            if ((dtpBegin.Value.AddYears(1).Year == dtpEnd.Value.Year || dtpBegin.Value.Year == dtpEnd.Value.Year) && ((dtpBegin.Value.Month == dtpEnd.Value.Month) || (dtpBegin.Value.AddMonths(1).Month == dtpEnd.Value.Month)))
            {
                this.TableName = "His_InOutStationHead_" + dtpBegin.Value.Year.ToString() + dtpBegin.Value.Month.ToString();
                this.TableName2 = "His_InOutStationHead_" + dtpEnd.Value.Year.ToString() + dtpEnd.Value.Month.ToString();
            }
            else
            {
                MessageBox.Show("不能跨多月份查询！", "提示", MessageBoxButtons.OK);
                return false;
            }
            TimeSpan ts1 = new TimeSpan(dtpBegin.Value.Ticks);
            TimeSpan ts2 = new TimeSpan(dtpEnd.Value.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            if ((int)ts.Days > 31)
            {
                MessageBox.Show("跨月查询不能多于三十一天！", "提示", MessageBoxButtons.OK);
                return false;
            }
            if (Convert.ToDateTime(dtpEnd.Value) > DateTime.Now)
            {
                dtpEnd.Value = DateTime.Now;
            }
            if (Convert.ToDateTime(dtpBegin.Value) >= Convert.ToDateTime(dtpEnd.Value))
            {
                MessageBox.Show("开始时间不能大于结束时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            
            return true;
        }

        #endregion

        #region【事件：选项卡事件】

        private void tbc_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage != null)
            {
                if (e.TabPage.Name == "tbp_Dept")       //部门
                {
                    LoadTree(1);
                    tvc_Dept.ExpandAll();
                }
                else if (e.TabPage.Name == "tbp_StationHead")   //分站
                {
                    LoadTree(2);
                    tvc_StationHead.ExpandAll();
                }
                else if (e.TabPage.Name == "tbp_WorkType")   //职务
                {
                    LoadTree(3);
                    tvc_WorkType.ExpandAll();
                }
            }
        }

        #endregion

        #region【事件：查询】
        private void bt_EmpOverTime_Enquiries_Click(object sender, EventArgs e)
        {
            if (!DecideTime(dtp_Ter_Begin, dtp_Ter_End))
            {
                return;
            }
            if (!ifSelect())
            {
                return;
            }
            pictureBox1.Visible = true;
            ControlSet(false);
            strWhere = StrWhere();
            t = new Thread(new ThreadStart(Select_StationHead_Emp));
            t.Start();
        }

        

        #region【方法：查询——人员】

        public void Select_StationHead_Emp()
        {
            try
            {
                GC.Collect();
                DataSet ds = rtsbll.GetInfo_HisStationHead_Emp(strWhere, TableName, TableName2);
                
                if (ds.Tables != null && ds.Tables.Count > 0)
                {
                    dgv_Main.Invoke(new DgvBinder(this.DgvBind), new object[] { ds });
                    //Czlt-2012-04-20 设置默认显示的时间
                    dgv_Main.Columns["进入时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    dgv_Main.Columns["离开时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    lblCounts.Invoke(new SetText(this.SetlblCounts), new object[] { "共 " + ds.Tables[0].Rows.Count.ToString() + " 条记录" });
                }
                else
                {
                    ds = new DataSet();
                    ds.Tables.Add(new DataTable());
                    dgv_Main.Invoke(new DgvBinder(this.DgvBind), new object[] { ds });
                }
                
                ControlSet(true);
                pictureBox1.Invoke(new SetEnable(this.SetPicVisible), new object[] { false });
                
            }
            catch (Exception ex)
            {
                try
                {
                    ControlSet(true);
                    pictureBox1.Invoke(new SetEnable(this.SetPicVisible), new object[] { false });
                }
                catch (Exception exp)
                { }
            }
            finally
            {
                try
                {
                    if (bt_EmpOverTime_Enquiries.IsHandleCreated)
                    {
                        bt_EmpOverTime_Enquiries.Invoke(new SetEnable(this.SetBtnSearch), new object[] { true });
                        bt_EmpOverTime_Reset.Invoke(new SetEnable(this.SetBtnReset), new object[] { true });
                    }
                }
                catch
                {
                }
            }
            t.Abort();
        }
        #endregion
        private bool ifSelect()
        {
            if (tbc.SelectedTab.Name == "tbp_Dept")
            {
                if (tvc_Dept.SelectedNode.Text !="所有部门" || txt_CodeSenderAddress.Text.Trim() != "" || txt_EmpName.Text.Trim() != "")
                {
                   
                    return true;
                }
                else
                {
                    MessageBox.Show("请选择至少一个查询条件(标识卡号,姓名或者部门)", "提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return false;
                }
            }
            else if (tbc.SelectedTab.Name == "tbp_StationHead")
            {
                if (tvc_StationHead.SelectedNode.Text!="所有分站" || txt_CodeSenderAddress.Text.Trim() != "" || txt_EmpName.Text.Trim() != "")
                {
                    
                    return true;
                }
                else
                {
                    MessageBox.Show("请选择至少一个查询条件(标识卡号,姓名或者分站)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else if (tbc.SelectedTab.Name == "tbp_WorkType")
            {
                if (tvc_WorkType.SelectedNode.Text!="所有工种" || txt_CodeSenderAddress.Text.Trim() != "" || txt_EmpName.Text.Trim() != "")
                {
                   
                    return true;
                }
                else
                {
                    MessageBox.Show("请选择至少一个查询条件(标识卡号,姓名或者工种)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return false;
        }

        #endregion



        #region[废弃代码]
        #region【方法：查询——设备】

        public void Select_StationHead_Equ()
        {
            try
            {
                int pIndex = ppindex;
                if (pIndex < 1)
                {
                    MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                    throw new Exception();
                }
                bt_EmpOverTime_Enquiries.Invoke(new SetEnable(this.SetBtnSearch), new object[] { false });
                bt_EmpOverTime_Reset.Invoke(new SetEnable(this.SetBtnReset), new object[] { false });
                ControlSet(false);
                DataSet ds = rtsbll.GetInfo_HisStationHead_Equ(pIndex, pSize, strWhere);

                if (ds.Tables != null && ds.Tables.Count > 1)
                {
                    // 重新设置页数
                    int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                    sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                    countPage = sumPage;
                    if (sumPage == 0)
                    {
                        //dgv_Main.DataSource = ds.Tables[0];

                        //lblMainTitle.Text = "历史读卡分站：  共 0 台";
                        //lblCounts.Text = "共 0 条记录";

                        //lblPageCounts.Text = "1";
                        //lblSumPage.Text = "/1页";

                        //btnUpPage.Enabled = false;
                        //btnDownPage.Enabled = false;

                        dgv_Main.Invoke(new DgvBinder(this.DgvBind), new object[] { ds });
                        //lblMainTitle.Invoke(new SetText(this.SetlblMainTitle), new object[] { "历史读卡分站：  共 0 台" });
                        lblCounts.Invoke(new SetText(this.SetlblCounts), new object[] { "共 0 条记录" });
                        lblPageCounts.Invoke(new SetText(this.SetlblPageCounts), new object[] { "1" });
                        lblSumPage.Invoke(new SetText(this.SetlblSumPage), new object[] { "/1页" });

                        //控制翻页状态
                        SetPageEnable(pIndex, sumPage);
                    }
                    else
                    {
                        //dgv_Main.DataSource = ds.Tables[0];

                        //lblMainTitle.Text = "历史读卡分站：  共 " + ds.Tables[2].Rows[0][0].ToString() + " 台";
                        //lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条记录";

                        //lblPageCounts.Text = pIndex.ToString();
                        //lblSumPage.Text = "/" + sumPage + "页";

                        ////控制翻页状态
                        //SetPageEnable(pIndex, sumPage);


                        dgv_Main.Invoke(new DgvBinder(this.DgvBind), new object[] { ds });
                        //lblMainTitle.Invoke(new SetText(this.SetlblMainTitle), new object[] { "历史读卡分站：  共 " + ds.Tables[2].Rows[0][0].ToString() + " 台" });
                        lblCounts.Invoke(new SetText(this.SetlblCounts), new object[] { "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条记录" });
                        lblPageCounts.Invoke(new SetText(this.SetlblPageCounts), new object[] { pIndex.ToString() });
                        lblSumPage.Invoke(new SetText(this.SetlblSumPage), new object[] { "/" + sumPage + "页" });

                        //控制翻页状态
                        SetPageEnable(pIndex, sumPage);
                    }
                    if (dgv_Main.Columns.Count >= 9)
                    {
                        dgv_Main.Columns["进入时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        dgv_Main.Columns["离开时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                        dgv_Main.Invoke(new DgvColumnVisibleSet(this.SetDgvColumnVisible), new object[] { "HisStationHeadID", false });
                        //dgv_Main.Columns["HisStationHeadID"].Visible = false;

                        dgv_Main.Columns["标识卡号"].DisplayIndex = 0;
                        dgv_Main.Columns["设备名称"].DisplayIndex = 1;
                        dgv_Main.Columns["部门"].DisplayIndex = 2;
                        dgv_Main.Columns["传输分站编号"].DisplayIndex = 3;
                        dgv_Main.Columns["读卡分站编号"].DisplayIndex = 4;
                        dgv_Main.Columns["读卡分站位置"].DisplayIndex = 5;
                        dgv_Main.Columns["进入时间"].DisplayIndex = 6;
                        dgv_Main.Columns["离开时间"].DisplayIndex = 7;
                        dgv_Main.Columns["持续时长"].DisplayIndex = 8;

                        dgv_Main.Invoke(new DgvColumnDisplaySet(this.SetDgvColumnDisplay), new object[] { "标识卡号", 0 });
                        dgv_Main.Invoke(new DgvColumnDisplaySet(this.SetDgvColumnDisplay), new object[] { "设备名称", 1 });
                        dgv_Main.Invoke(new DgvColumnDisplaySet(this.SetDgvColumnDisplay), new object[] { "部门", 2 });
                        dgv_Main.Invoke(new DgvColumnDisplaySet(this.SetDgvColumnDisplay), new object[] { "传输分站编号", 3 });
                        dgv_Main.Invoke(new DgvColumnDisplaySet(this.SetDgvColumnDisplay), new object[] { "读卡分站编号", 4 });
                        dgv_Main.Invoke(new DgvColumnDisplaySet(this.SetDgvColumnDisplay), new object[] { "读卡分站位置", 5 });
                        dgv_Main.Invoke(new DgvColumnDisplaySet(this.SetDgvColumnDisplay), new object[] { "进入时间", 6 });
                        dgv_Main.Invoke(new DgvColumnDisplaySet(this.SetDgvColumnDisplay), new object[] { "离开时间", 7 });
                        dgv_Main.Invoke(new DgvColumnDisplaySet(this.SetDgvColumnDisplay), new object[] { "持续时长", 8 });
                    }
                }
                else
                {
                    ds = new DataSet();
                    ds.Tables.Add(new DataTable());
                    dgv_Main.Invoke(new DgvBinder(this.DgvBind), new object[] { ds });
                    lblMainTitle.Invoke(new SetText(this.SetlblMainTitle), new object[] { "历史读卡分站：  共 0 台" });
                    lblCounts.Invoke(new SetText(this.SetlblCounts), new object[] { "共 0 条记录" });
                    lblPageCounts.Invoke(new SetText(this.SetlblPageCounts), new object[] { "1" });
                    lblSumPage.Invoke(new SetText(this.SetlblSumPage), new object[] { "/1页" });

                    //控制翻页状态
                    btnUpPage.Invoke(new SetEnable(this.SetbtnUpPage), new object[] { false });
                    //btnDownPage.Enabled = false;
                    btnDownPage.Invoke(new SetEnable(this.SetbtnDownPage), new object[] { false });
                }
                pictureBox1.Invoke(new SetEnable(this.SetPicVisible), new object[] { false });
                bt_EmpOverTime_Enquiries.Invoke(new SetEnable(this.SetBtnSearch), new object[] { true });
                bt_EmpOverTime_Reset.Invoke(new SetEnable(this.SetBtnReset), new object[] { true });
                ControlSet(true);
            }
            catch (Exception ex)
            {

            }
            t.Abort();
        }
        #endregion


        #region【事件：上一页】

        private void btnUpPage_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            int page = int.Parse(lblPageCounts.Text);
            page--;
            if (page < 1)
            {
                pictureBox1.Visible = true;
                return;
            }
            ppindex = page;

            t = new Thread(new ThreadStart(Select_StationHead_Emp));
            t.Start();
           
        }

        #endregion

        #region【事件：下一页】

        private void btnDownPage_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            int page = int.Parse(lblPageCounts.Text);
            page++;

            if (page > countPage)
            {
                pictureBox1.Visible = true;
                return;
            }
            ppindex = page;

            t = new Thread(new ThreadStart(Select_StationHead_Emp));
            t.Start();

           
        }

        #endregion

        #region【事件：跳至】

        private void txtSkipPage_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyValue == 13)
            {
                try
                {
                    pictureBox1.Visible = true;
                    string value = txtSkipPage.Text;
                    if (value.CompareTo("") == 0)       //为空值时
                    {
                        pictureBox1.Visible = false;
                        return;
                    }
                    else if (int.Parse(value) > 0)
                    {
                        int page = int.Parse(value);
                        //ppindex = page;
                        if (page > countPage)
                        {
                            page = countPage;
                            txtSkipPage.Text = page.ToString();
                        }
                        ppindex = page;

                        t = new Thread(new ThreadStart(Select_StationHead_Emp));
                        t.Start();

                       
                    }
                }
                catch (Exception ex)
                {
                    pictureBox1.Visible = false;
                }
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
            //ppindex = 1;
            
            pictureBox1.Visible = true;
            t = new Thread(new ThreadStart(Select_StationHead_Emp));
            t.Start();
            
        }


        #endregion

        #region【事件：重置】

        private void bt_EmpOverTime_Reset_Click(object sender, EventArgs e)
        {
          
            ControlSet(true);
            pictureBox1.Visible = false;
            dtp_Ter_Begin.Value = DateTime.Now.Date;
            dtp_Ter_End.Value = DateTime.Now;

            txt_CodeSenderAddress.Text = "";
            txt_EmpName.Text = "";
            dgv_Main.DataSource = new DataTable();
            lblCounts.Text = "符合筛选条件：";

           
        }

        #endregion

        #endregion



        private void A_FrmHisStationHead_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                t.Abort();
            }
            catch (Exception ex)
            { }
        }

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
        private void txt_EmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
        #region【事件：打印 导出】
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgv_Main, "历史标识卡信息", "统计时间:" + dtp_Ter_Begin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "--" + dtp_Ter_End.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgv_Main, "历史标识卡信息", "统计时间:" + dtp_Ter_Begin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "--" + dtp_Ter_End.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }
       

        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgv_Main, "历史标识卡信息", "统计时间:" + dtp_Ter_Begin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "--" + dtp_Ter_End.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        #endregion
        
    }
}
