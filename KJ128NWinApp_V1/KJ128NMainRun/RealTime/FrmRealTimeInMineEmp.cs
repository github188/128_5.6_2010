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
using System.Threading;

namespace KJ128NMainRun.RealTime
{
    public partial class FrmRealTimeInMineEmp : KJ128NMainRun.FromModel.FrmModel
    {

        #region[声明]

        private bool isFirst = false;

        RT_InOutMineEmpNameListBLL bll = new RT_InOutMineEmpNameListBLL();
        KJ128NDBTable.A_RT_Mine_List.A_RT_Mine_ListBLL abll = new KJ128NDBTable.A_RT_Mine_List.A_RT_Mine_ListBLL();
        KJ128NDBTable.A_RT_OverSee.A_Station_HeadBLL bbll = new KJ128NDBTable.A_RT_OverSee.A_Station_HeadBLL();

        private A_TreeBLL tbll = new A_TreeBLL();

        DataSet ds;

        DBAcess dbacc = new DBAcess();
        DbHelperSQL db = new DbHelperSQL();

        private DockPanel DockPnl = null;

        private A_FrmDCfgRealTime HisRouteFrm = null;

        int ppindex;

        /// <summary>
        /// 每页条数
        /// </summary>
        //private static int pSize = 40;
        private  int pSize = 40;
        /// <summary>
        /// 查询到记录的总页数
        /// </summary>
        private int countPage;

        #region 【Czlt-2011-01-20 实时颜色】
        DateTime startTime;
        DateTime endTime;
        DateTime curTime;
        int currentIndex = 0;
        #endregion

        #endregion

        #region[构造函数]
        public FrmRealTimeInMineEmp(DockPanel dpnl)
        {
            InitializeComponent();
            try
            {
                cmbSelectCounts.SelectedIndex = 0;
                
                base.Text = "实时人员下井名单";
                base.btnAdd.Hide();
                base.btnLaws.Hide();
                base.btnDelete.Hide();
                base.btnSelectAll.Hide();
                base.btnPrint.Hide();
                base.lblMainTitle.Hide();
                this.DockPnl = dpnl;
                //treeView1.Controls.Add(EmpPL);
                EmpPL.Hide();
                listView1.Columns.Add("姓名");
                listView1.Columns.Add("部门");
                listView1.Columns.Add("职务");
                listView1.Columns.Add("入井时间").AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);


                timer1.Interval = KJ128NInterfaceShow.RefReshTime._rtTime;
                //timer2.Interval = KJ128NInterfaceShow.RefReshTime._rtTime;
                LoadDeptTree();
                loaddutytree();
                LoadStnTree();
            }
            catch (Exception ex)
            { }
            //loadimagelist();

        }

        #endregion


        #region[treeview中加载]
        private void LoadDeptTree()
        {
            using (ds = new DataSet())
            {

                ds = db.Query("select 0 ID,'所有' Name,-1 ParentID,'false' IsChild,'true' IsUserNum,(select count(*) from dbo.view_RT_InOutMineEmpNameList where 部门ID is null) Num  union all  select ID,name,parentid,ischild,isusernum,isnull(num,0)  from ( SELECT  top 600  DeptID AS ID, DeptName AS name, ParentDeptID AS ParentID, 'true' AS IsChild, 'true' AS IsUserNum,(SELECT     num FROM (SELECT     部门ID, 员工部门, COUNT(员工ID) AS num FROM dbo.view_RT_InOutMineEmpNameList GROUP BY 部门ID, 员工部门) AS dd WHERE (部门ID = t.DeptID)) AS Num, SerialNO FROM dbo.Dept_Info AS t order by  SerialNO, name ) tt");
                //ds = abll.GetDeptDs();
                treeView1.DataSouce = ds.Tables[0];
                treeView1.LoadNode("人");
            }
            treeView1.ExpandAll();
        }
        #endregion

      
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                pSize = Convert.ToInt32(cmbSelectCounts.SelectedItem);
                loadlistview1();
            }
            catch (Exception ex)
            { }
        }

        //绑定到UI
        Dictionary<string, ListViewGroup> group = new Dictionary<string, ListViewGroup>();
        Dictionary<string, ListViewItem> Item = new Dictionary<string, ListViewItem>();
        private void RunExcute()
        {
            if (ppindex < 1)
            {
                ppindex = 1;
            }
            int sumPage = 1;
            if (group.Count > 0 || Item.Count > 0)
            {
                group.Clear();
                Item.Clear();
            }

            DataTable DeptDT = bll.ALL_DeptNAME(where);

            
            if (DeptDT.Rows.Count > 0)
            {
                #region 【获取当前井下员信息】
                DataSet dsEmpDt = new DataSet();
                DataTable empDT = new DataTable();


                dsEmpDt = bll.RT_InOutEmp(ppindex, pSize, where);
                if (dsEmpDt.Tables != null && dsEmpDt.Tables.Count > 1)
                {
                    empDT = dsEmpDt.Tables[0];
                    DeptDT = empDT.DefaultView.ToTable(true, new string[] { "员工部门" });
                    // 重新设置页数
                    sumPage = int.Parse(dsEmpDt.Tables[1].Rows[0][0].ToString());
                    sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                    countPage = sumPage;
                    if (sumPage == 0)
                    {
                        if (this.IsHandleCreated)
                            this.Invoke(new MethodInvoker(delegate()
                            {
                                lblPageCounts.Text = "1";
                                lblSumPage.Text = "/1页";
                            }));
                    }
                    else
                    {
                        if (this.IsHandleCreated)
                            this.Invoke(new MethodInvoker(delegate()
                            {
                                lblPageCounts.Text = ppindex.ToString();
                                lblSumPage.Text = "/" + sumPage + "页";
                            }));
                    }
                    if (ppindex > sumPage)
                    {
                        ppindex = 1;
                    }
                }
                else
                {
                    if (this.IsHandleCreated)
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            lblPageCounts.Text = "1";
                            lblSumPage.Text = "/1页";
                        }));
                    ppindex = 1;
                }


                if (isFirst)
                {
                    if (this.IsHandleCreated)
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            listView1.Groups.Clear();
                            listView1.Items.Clear();
                        }));
                    isFirst = false;
                }
                else
                {
                    if (this.IsHandleCreated)
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            for (int i = listView1.Groups.Count - 1; i >= 0; i--)
                            {
                                if (DeptDT.Select("员工部门='" + listView1.Groups[i].Header + "'").Length <= 0)
                                {
                                    listView1.Groups[i].Items.Clear();
                                    listView1.Groups.RemoveAt(i);
                                }
                            }
                        }));
                }
                #endregion

               
                foreach (DataRow dr in DeptDT.Rows)
                {
                    ListViewGroup g = new ListViewGroup(dr["员工部门"].ToString());
                    g.Name = dr["员工部门"].ToString();
                    group.Add(g.Name, g);
                    if (empDT != null && empDT.Rows.Count > 0)
                    {
                        DataRow[] dr2 = empDT.Select("员工部门='" + dr["员工部门"].ToString() + "'");
                        for (int i = 0; i < dr2.Length; i++)
                        {

                            ListViewItem it = new ListViewItem();
                            it.Name = dr2[i]["员工ID"].ToString();
                            it.Text = dr2[i]["员工姓名"].ToString();

                            if (dr2[i]["职务类型"].ToString() != "")
                            {
                                if (int.Parse(dr2[i]["职务类型"].ToString()) < 6)
                                {
                                    it.ImageIndex = 0;
                                }
                                else
                                {
                                    it.ImageIndex = 1;
                                }
                            }
                            else
                            {
                                it.ImageIndex = 1;
                            }
                            it.Group = g;
                            it.Tag = dr2[i]["员工部门"].ToString();
                            it.ToolTipText = "姓名:" + dr2[i]["员工姓名"].ToString() + "\n部门:" + dr2[i]["员工部门"].ToString() + "\n职务:" + dr2[i]["职务名"].ToString() + "\n入井时间:" + dr2[i]["入井时间"].ToString();
                            it.SubItems.Add(dr2[i]["员工部门"].ToString());
                            it.SubItems.Add(dr2[i]["职务名"].ToString());
                            it.SubItems.Add(dr2[i]["入井时间"].ToString());
                            //Czlt-2011-01-20 设置三班颜色
                            //SetColor(currentIndex, it);
                            //判断人员信息有没有添加到列表中
                            if (!Item.ContainsKey(it.Name))
                            {
                                Item.Add(it.Name, it);
                            }
                        }
                    }
                }
                if (listView1.IsHandleCreated)
                    listView1.Invoke(new MethodInvoker(delegate()
                    {
                        //加入listview中没有分组
                        //listView1.BeginUpdate();
                        foreach (ListViewGroup g in group.Values)
                        {
                            if (listView1.Groups[g.Name] == null)
                            {
                                listView1.Groups.Add(g);
                            }
                        }

                        //清空listview中没有的分组和子集
                        for (int i = listView1.Groups.Count - 1; i >= 0; i--)
                        {
                            if (!group.ContainsKey(listView1.Groups[i].Name))
                            {
                                listView1.Groups[i].Items.Clear();
                                listView1.Groups.RemoveAt(i);
                            }
                        }
                        //删除没有分组的子集
                        for (int i = listView1.Items.Count - 1; i >= 0; i--)
                        {
                            if (listView1.Items[i].Group == null )
                                listView1.Items.RemoveAt(i);
                        }

                        //删除没有的子集(重新刷新)
                        for (int i = listView1.Items.Count - 1; i >= 0; i--)
                        {
                            if (!Item.ContainsKey(listView1.Items[i].Name))
                            {
                                listView1.Items.RemoveAt(i);
                            }
                        }

                        //加入listview中没有子集
                        foreach (ListViewItem i in Item.Values)
                        {
                            if (listView1.Items[i.Name] == null)
                            {
                                i.Group = listView1.Groups[i.Tag.ToString()];
                                listView1.Items.Add(i);
                            }
                        }
                        //listView1.EndUpdate();
                    }));
            }
            else
            {
                if (listView1.IsHandleCreated)
                    listView1.Invoke(new MethodInvoker(delegate()
                    {
                        listView1.Items.Clear();
                    }));
            }
            if (this.IsHandleCreated)
                this.Invoke(new MethodInvoker(delegate()
                {
                   
                    listView1.ShowGroups = true;
                    timer1.Enabled = true;
                    //pictureBox2.Visible = false;
                    //SetEnable(true);
                }));
            if (group.Count > 0 || Item.Count > 0)
            {
                group.Clear();
                Item.Clear();
            }
            flag = false;
            th.Abort();
        }

        Thread th = null;
        private bool flag = false;
        private string where = string.Empty;
        private void loadlistview1()
        {
            if (flag == true)
            {
                return;
            }
            //pictureBox2.Visible = true;
            timer1.Enabled = false;
            flag = true;
            //SetEnable(false);
            where = GetWhere();//获取查询条件
            th = new Thread(RunExcute);
            th.IsBackground = true;
           
            th.Start();

        }
        //获得选择条件
        private string GetWhere()
        {
            string where = string.Empty;
            if (tabControl1.SelectedIndex == 0)
            {
                if (treeView1.SelectedNode != null)
                {
                    if (treeView1.SelectedNode.Level == 0)
                    {
                        where = " 1=1 ";
                    }
                    else
                    {
                       //// where = " 部门ID=" + treeView1.SelectedNode.Name;
                       // where = "  部门ID in (" + GetNodeAllChild(treeView1.SelectedNode) + " )";
                        string strDeptId = GetNodeAllChild(treeView1.SelectedNode);                      
                        where = "  部门ID in (" + strDeptId + " )";
                    }
                }
                else
                {
                    where = " 1=1";
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                if (DutyTree.SelectedNode != null)
                {
                    if (DutyTree.SelectedNode.Level == 0)
                    {
                        where = " 1=1";
                    }
                    else
                    {
                        if (DutyTree.SelectedNode.Name == "-2")
                        {
                            where = " (职务ID is null or 职务ID=0)";
                        }
                        else
                        {
                            where = " 职务ID=" + DutyTree.SelectedNode.Name;
                        }
                    }
                }
                else
                {
                    where = " 1=1";
                }
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                if (tv_Stn.SelectedNode != null)
                {
                    if (tv_Stn.SelectedNode.Level == 0)
                    {
                        where = " 1=1";
                    }
                    else
                    {
                        if (tv_Stn.SelectedNode.Name.Substring(0, 1).Equals("S"))
                        {
                            where = " 基站号=" + tv_Stn.SelectedNode.Name.Substring(1);
                        }
                        else
                        {
                            where = " 分站ID=" + tv_Stn.SelectedNode.Name.Substring(1);
                        }
                    }
                }
                else
                {
                    where = " 1=1";
                }
            }
            else
            {
                where = " 1=1";
            }
            return where;
        }
        private void SetEnable(bool b)
        {
            treeView1.Enabled = b;
            DutyTree.Enabled = b;
            tv_Stn.Enabled = b;
        }

        #region[toolstrip选择listview显示方式]

        private void 大图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void 小图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }


        private void 平铺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.Tile;
        }



        #endregion

        private void loaddutytree()
        {
            DataTable dt = new DataTable();
            dt = abll.DutyTree();
            DutyTree.DataSouce = dt;
            DutyTree.LoadNode("人");
            DutyTree.ExpandAll();


        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
            isFirst = true;
            loadlistview1();
        }

        private void DutyTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            isFirst = true;
            loadlistview1();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //loadimagelist();
            //qyz 修改获得焦点刷新
            if (this.IsActivated || this.DockHandler == DockPnl.ActiveDocument.DockHandler)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    LoadDeptTree();
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    loaddutytree();
                }
                else
                {
                    LoadStnTree();
                }
                loadlistview1();

            }
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            //loadimagelist();
            loadlistview1();
            if (checkBox1.Checked)
            {
                timer1.Start();

            }
            else
            {
                timer1.Stop();


            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string empid = listView1.SelectedItems[0].Name;
                string empname = listView1.SelectedItems[0].Text;
                string time = listView1.SelectedItems[0].ToolTipText.Substring(listView1.SelectedItems[0].ToolTipText.IndexOf("入井时间:") + 5);
                //if (HisRouteFrm == null)
                //{
                //    HisRouteFrm = new A_FrmDCfgRealTime();
                //    HisRouteFrm.Show(DockPnl, DockState.Document);
                //    HisRouteFrm.PlayHisRoute(empid, empname, time);
                //}
                //else
                //{
                //    if(HisRouteFrm.DockState == DockState.Unknown)
                //    {
                //HisRouteFrm.Close();
                //HisRouteFrm.Dispose();
                //HisRouteFrm = new A_FrmDCfgRealTime();
                //HisRouteFrm.Show(DockPnl, DockState.Document);
                //HisRouteFrm.PlayHisRoute(empid, empname, time);
                //    }
                //    HisRouteFrm.Activate();
                //    HisRouteFrm.PlayHisRoute(empid, empname, time);
                //}
                if (HisRouteFrm == null)
                {
                    HisRouteFrm = new A_FrmDCfgRealTime();
                    HisRouteFrm.Show(DockPnl, DockState.Document);
                    HisRouteFrm.PlayHisRoute(empid, empname, time);
                }
                else
                {
                    try
                    {
                        HisRouteFrm.Close();
                        //HisRouteFrm.Dispose();
                        HisRouteFrm = new A_FrmDCfgRealTime();
                        HisRouteFrm.Show(DockPnl, DockState.Document);
                        HisRouteFrm.PlayHisRoute(empid, empname, time);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private void listView1_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            Rectangle er = listView1.GetItemRect(listView1.Items.IndexOf(e.Item));
            int x = er.X + er.Width / 2;
            int y = er.Y + er.Height / 2;
            Point pt = new Point();
            if (x + EmpPL.Width <= listView1.Width)
            {
                pt.X = x;
            }
            else
            {
                pt.X = x - EmpPL.Width;
            }
            if (y + EmpPL.Height <= listView1.Height)
            {
                pt.Y = y;
            }
            else
            {
                pt.Y = y - EmpPL.Height;
            }
            //pt = listView1.PointToScreen(pt);


            //EmpPL.Size = new Size(80, 80);
            EmpPL.Location = pt;
            DataTable paneldt = new DataTable();
            paneldt = abll.Get_Mine_Panel(e.Item.Name);
            if (paneldt.Rows[0]["pic"].ToString().Trim() != "")
            {
                try
                {
                    pictureBox1.Hide();
                    System.IO.MemoryStream memoryStream = new System.IO.MemoryStream((byte[])paneldt.Rows[0]["pic"]);
                    Bitmap bmp = new Bitmap(memoryStream);
                    EmpPicture.Image = bmp;
                    EmpPicture.Show();
                }
                catch
                {
                    pictureBox1.Show();
                    EmpPicture.Hide();
                }
            }
            else
            {
                pictureBox1.Show();
                EmpPicture.Hide();
            }

            EmpLbl.Text = "标识卡:" + paneldt.Rows[0]["标识卡"].ToString() + "\n\n姓名:" + paneldt.Rows[0]["姓名"].ToString() + "\n\n部门:" + paneldt.Rows[0]["部门"].ToString() + "\n\n职务:" + paneldt.Rows[0]["职务"].ToString() + "\n\n现在位置:\n" + paneldt.Rows[0]["地址"].ToString() + "\n\n进入位置的时间:\n" + paneldt.Rows[0]["时间"].ToString();
            EmpPL.BringToFront();
            EmpPL.Show();
        }

        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (listView1.GetItemAt(e.X, e.Y) == null)
            {
                EmpPL.Hide();
            }
        }

        private void btnUpPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page--;
            if (page < 1)
            {
                return;
            }
            isFirst = true;
            ppindex = page;
            loadlistview1();
        }

        private void btnDownPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page++;

            if (page > countPage)
            {
                return;
            }
            ppindex = page;
            isFirst = true;
            loadlistview1();
        }

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
                        ppindex = page;
                        isFirst = true;
                        loadlistview1();
                    }
                }
                catch
                {
                }
            }
        }

        private void cmbSelectCounts_DropDownClosed(object sender, EventArgs e)
        {
            isFirst = true;
            pSize = Convert.ToInt32(cmbSelectCounts.SelectedItem);
            ppindex = 1;
            loadlistview1();
        }







        #region【加载分站树】
        /// <summary>
        /// 加载分站树
        /// </summary>
        private void LoadStnTree()
        {
            using (ds = new DataSet())
            {
                ds = db.Query(" select '0' ID,'所有' Name,'-1' ParentID,'false' IsChild,'true' IsUserNum,0 Num union Select 'S'+ CONVERT(varchar,Si.StationAddress) as ID, Si.StationPlace as Name, "
                            + "  '0' as ParentID,  'true' as IsChild ,  'true' as IsUserNum , "
                            + "  '0'  as Num  "
                            + " From Station_Info as Si  "
                            + "  Union  Select 'H'+ CONVERT(varchar,Shi.StationHeadID) as ID,  Shi.StationHeadPlace as Name, "
                            + " 'S'+ CONVERT(varchar,Shi.StationAddress) as ParentID, 'true' as IsChild , "
                            + "  'true' as IsUserNum ,  (select count(*) from  view_RT_InOutMineEmpNameList_FW As Ri where  Ri.分站ID =Shi.StationHeadID) as Num  From Station_Head_Info as Shi ");
                //ds = abll.GetStaDs();
                tv_Stn.DataSouce = ds.Tables[0];
                tv_Stn.LoadNode("人");
            }
            tv_Stn.ExpandAll();
        }
        #endregion

        private void tv_Stn_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            isFirst = true;
            loadlistview1();
        }


        #region 【Czlt-2011-01-20 - 用颜色区分实时下井人员信息】
        private string GetIndex(string inTime, string classId)
        {
            string str = "";
            if (!classId.Equals(""))
            {

                DataSet dsClass;
                using (dsClass = new DataSet())
                {
                    ds = db.Query("select IntervalName,StartWorkTime,EndWorkTime,NameShort from dbo.TimerInterval where ClassID = " + Convert.ToInt32(classId));
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            startTime = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[1].ToString());
                            endTime = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[2].ToString());
                            curTime = Convert.ToDateTime(inTime);
                            if (startTime.Hour <= curTime.Hour && endTime.Hour >= curTime.Hour)
                            {

                                currentIndex = i;
                                str = ds.Tables[0].Rows[i].ItemArray[0].ToString();

                            }

                            //Czlt-2011-04-09 处理跨天的班次
                            if (startTime.Hour > endTime.Hour)
                            {
                                if ((startTime.Hour <= curTime.Hour) || (endTime.Hour >= curTime.Hour))
                                {

                                    currentIndex = i;
                                    str = ds.Tables[0].Rows[i].ItemArray[0].ToString();

                                }
                            }
                        }
                    }

                }
            }
            return str;

        }

        private void SetColor(int index, ListViewItem it)
        {
            switch (index)
            {
                case 0:
                    it.ForeColor = Color.Blue;
                    break;
                case 1:
                    it.ForeColor = Color.Red;
                    break;
                case 2:
                    it.ForeColor = Color.Green;
                    break;
                case 3:
                    it.ForeColor = Color.BlueViolet;
                    break;
                case 4:
                    it.ForeColor = Color.Tomato;
                    break;
                default:
                    it.ForeColor = Color.Black;
                    break;


            }
        }

        #endregion

        private void FrmRealTimeInMineEmp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (th != null)
            {
                try
                {
                    timer1.Enabled = false;
                    listView1.Visible = false;
                    th.Abort();
                }
                catch { }
            }
        }


        #region 【方法: 遍历节点下的所有子节点】

        /// <summary>
        /// 遍历节点下的所有子节点
        /// </summary>
        /// <param name="tn"></param>
        private string GetNodeAllChild(TreeNode tn)
        {
            string strNodeChildName=string.Empty;

            //strNodeChildName = tn.Name;
            //if (tn.Nodes.Count > 0)
            //{
            //    foreach (TreeNode n in tn.Nodes)
            //    {
            //        string strDid = string.Empty;
            //        if (n.Nodes.Count > 0)
            //        {
            //            strDid = GetNodeAllChild(n);
            //        }
            //        if (!strDid.Equals(""))
            //        {
            //            strNodeChildName += "," + n.Name + "," + strDid;
            //        }
            //        else
            //        {
            //            strNodeChildName += "," + n.Name;
            //        }
            //    }
            //}
            DataSet ds = abll.GetDetpLevId(tn.Name.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    strNodeChildName += dr[0].ToString() + ",";
 
                }

                if (strNodeChildName.Length > 0)
                {
                    strNodeChildName = strNodeChildName.Substring(0, strNodeChildName.Length - 1);
                }

            }
            else
            {
                strNodeChildName = tn.Name;
 
            }
            return strNodeChildName;
        }
        #endregion




    }
}