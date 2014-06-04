using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace KJ128NMainRun.A_Antenna
{
    public partial class A_frmHisAntenna : KJ128NMainRun.FromModel.FrmModel
    {
        private KJ128NDBTable.A_AntennaBLL bll = new KJ128NDBTable.A_AntennaBLL();

        #region 载入数据等待
        private int Index = 1;
        private Thread th = null;
        delegate void Binddgv(DataTable dt);
        delegate void dgvvisible(string str);
        delegate void stringget(Label lb,string str);
        delegate void boolget(Button bn,bool bl);
        delegate void pic(bool bl);
        private void ObjectEnable(Button bn, bool bl)
        {
            if (bn.InvokeRequired)
            {
                boolget bg = new boolget(ObjectEnable);
                this.Invoke(bg, new object[] { bn, bl });
            }
            else
            {
                bn.Enabled = bl;
            }
        }
        private void labtext(Label lb, string str)
        {
            if (lb.InvokeRequired)
            {
                stringget sg = new stringget(labtext);
                this.Invoke(sg, new object[] { lb, str });
            }
            else
            {
                lb.Text = str;
            }
        }
        private void Bind(DataTable dt)
        {
            if (dgv.InvokeRequired)
            {
                Binddgv dv = new Binddgv(Bind);
                this.Invoke(dv, new object[] { dt });
            }
            else
            {
                if (dt != null)
                {
                    dgv.DataSource = dt;
                }
                else
                {
                    dgv.DataSource = new DataTable();
                }
            }
        }
        private void dgvv(string str)
        {
            if (dgv.InvokeRequired)
            {
                dgvvisible dv = new dgvvisible(dgvv);
                this.Invoke(dv, new object[] { str });
            }
            else
            {
                dgv.Columns[str].Visible = false;
            }
        }
        private void piccc(bool bl)
        {
            if (pictureBox1.InvokeRequired)
            {
                pic p = new pic(piccc);
                this.Invoke(p, new object[] { bl });
            }
            else
            {
                pictureBox1.Visible = bl;
            }
        }

        private delegate void SetEnable(bool enable);
        private void SetBtnSearch(bool enable)
        {
            this.btnSearch.Enabled = enable;
        }
        private void SetBtnReset(bool enable)
        {
            this.btnReSet.Enabled = enable;
        }

        private delegate void SetConEnable(Control c, bool enable);
        private void ConEnableSet(Control c, bool enable)
        {
            c.Enabled = enable;
        }
        private void SetAllEnable(bool enable)
        {
            panel3.Invoke(new SetConEnable(this.ConEnableSet), new object[] { panel3, enable });
            groupBox1.Invoke(new SetConEnable(this.ConEnableSet), new object[] { groupBox1, enable });
            btnUpPage.Invoke(new SetConEnable(this.ConEnableSet), new object[] { btnUpPage, enable });
            btnDownPage.Invoke(new SetConEnable(this.ConEnableSet), new object[] { btnDownPage, enable });
            txtSkipPage.Invoke(new SetConEnable(this.ConEnableSet), new object[] { txtSkipPage, enable });
            cmbSelectCounts.Invoke(new SetConEnable(this.ConEnableSet), new object[] { cmbSelectCounts, enable });
        }
        #endregion
        private string station = "";
        private string stationhead = "";
        private string atnenna = "";
        private string type = "0";
        private string strName = "";
        private int PageCount = 0;
        private bool IsUse = true;
        private string StartDate = "";
        private string EndDate = "";
        private bool isSearch = false;
        /// <summary>
        /// 查询条件
        /// </summary>
        private string m_StrWhere = "";
        /// <summary>
        /// 页显示行数
        /// </summary>
        private int m_PSize = 40;

        private int m_PCounts = 0;
        #region 【构造函数】
        public A_frmHisAntenna()
        {
            InitializeComponent();
            drawerLeftMain.Add(pnl, true);
            drawerLeftMain.LeftPartResize();
            pictureBox1.Visible = false;
        }
        #endregion

        #region 【自定义方法】

        #region 【方法：加载部门树信息】
        /// <summary>
        /// 加载部门树
        /// </summary>
        private void LoadTree()
        {
            DataTable dt = bll.GetAllStation();
            int count = trvHead.Nodes[0].Nodes.Count > dt.Rows.Count ? trvHead.Nodes[0].Nodes.Count : dt.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                TreeNode node = null;
                if (i < trvHead.Nodes[0].Nodes.Count && i < dt.Rows.Count)
                {
                    node = trvHead.Nodes[0].Nodes[i];
                    node.Name = dt.Rows[i][0].ToString();
                    node.Text = dt.Rows[i][1].ToString();
                    node.ImageKey = "1";
                }
                if (i < dt.Rows.Count && i >= trvHead.Nodes[0].Nodes.Count)
                {
                    node = new TreeNode();
                    node.Name = dt.Rows[i][0].ToString();
                    node.Text = dt.Rows[i][1].ToString();
                    node.ImageKey = "1";
                    trvHead.Nodes[0].Nodes.Add(node);
                }
                if (i < trvHead.Nodes[0].Nodes.Count && i >= dt.Rows.Count)
                {
                    trvHead.Nodes[0].Nodes.RemoveAt(i);
                    continue;
                }
                DataTable headdt = bll.GetStationHeadByStationAddress(node.Name);
                int nodecount = node.Nodes.Count > headdt.Rows.Count ? node.Nodes.Count : headdt.Rows.Count;
                for (int j = 0; j < nodecount; j++)
                {
                    TreeNode headnode = null;
                    if (j < node.Nodes.Count && j < headdt.Rows.Count)
                    {
                        headnode = node.Nodes[j];
                        headnode.Name = headdt.Rows[j][1].ToString();
                        headnode.Text = headdt.Rows[j][2].ToString();
                        headnode.ImageKey = "2";
                    }
                    if (j >= node.Nodes.Count && j < headdt.Rows.Count)
                    {
                        headnode = new TreeNode();
                        node.Nodes.Add(headnode);
                        headnode.Name = headdt.Rows[j][1].ToString();
                        headnode.Text = headdt.Rows[j][2].ToString();
                        headnode.ImageKey = "2";
                    }
                    if (j < node.Nodes.Count && j >= headdt.Rows.Count)
                    {
                        node.Nodes.RemoveAt(j);
                        continue;
                    }
                    TreeNode node1 = null;
                    TreeNode node2 = null;
                    if (headnode.Nodes.Count > 0)
                    {
                        node1 = headnode.Nodes[0];
                        node2 = headnode.Nodes[1];
                    }
                    else
                    {
                        node1 = new TreeNode();
                        node2 = new TreeNode();
                        headnode.Nodes.Add(node1);
                        headnode.Nodes.Add(node2);
                    }
                    node1.Name = "1";
                    node1.Text = headdt.Rows[j][3].ToString();
                    if (node1.Text.Trim() == "")
                        node1.Text = "天线A";
                    node1.ImageKey = "3";
                    node2.Name = "2";
                    node2.Text = headdt.Rows[j][4].ToString();
                    if (node2.Text.Trim() == "")
                        node2.Text = "天线B";
                    node2.ImageKey = "3";
                }
            }

        }
        #endregion

        #region 【方法：获取查询条件】
        /// <summary>
        /// 获取查询条件
        /// </summary>
        private void GetScaleString()
        {
            string strWhereSql = string.Format(" 结束巡检时间 between '{0}' and '{1}'", this.StartDate, this.EndDate);

            TreeNode node = trvHead.SelectedNode;
            if (node != null)
            {
                if (node.ImageKey == "3")
                {
                    atnenna = node.Name;
                    stationhead = node.Parent.Name;
                    station = node.Parent.Parent.Name;
                }
                if (node.ImageKey == "2")
                {
                    atnenna = "";
                    stationhead = node.Name;
                    station = node.Parent.Name;
                }
                if (node.ImageKey == "1")
                {
                    atnenna = "";
                    stationhead = "";
                    station = node.Name;
                }
                if (node.ImageKey == "")
                {
                    atnenna = "";
                    stationhead = "";
                    station = "";
                }
            }
            else
            {
                atnenna = "";
                stationhead = "";
                station = "";
            }

            if (station != "")
            {
                strWhereSql = string.Format(strWhereSql + " and stationaddress={0}", station);
            }
            if (stationhead != "")
            {
                strWhereSql = string.Format(strWhereSql + " and stationheadaddress={0}", stationhead);
            }
            if (atnenna != "")
            {
                strWhereSql = string.Format(strWhereSql + " and instationantenna={0}", atnenna);
            }


            if (type != "")
            {
                if (type != "null")
                {
                    strWhereSql = string.Format(strWhereSql + " and cstypeid={0}", type);
                }
                else
                {
                    strWhereSql = string.Format(strWhereSql + " and cstypeid is {0}", type);
                }
            }

            //获取标识卡条件
            if (!txtCodeSender.Text.Trim().Equals(""))
            {
                strWhereSql += " and 标识卡号=" + txtCodeSender.Text.Trim();
            }

            if (!txtScealName.Text.Trim().Equals(""))
            {
                strWhereSql += " and  称呼 like '%" + txtScealName.Text.Trim() + "%'";
            }

            m_StrWhere = strWhereSql;
        }
        #endregion

        #region 【方法：绑定数据】
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="pIndex">页索引</param>
        private void BindData()
        {
            try
            {
                btnSearch.Invoke(new SetEnable(this.SetBtnSearch), new object[] { false });
                btnReSet.Invoke(new SetEnable(this.SetBtnReset), new object[] { false });
                SetAllEnable(false);
                int pIndex = Index;
                if (pIndex < 1)
                {
                    pIndex = 1;
                    return;
                }

                if (pIndex == 1)
                {
                    ObjectEnable(btnUpPage, false);
                    //btnUpPage.Enabled = false;
                }

                DataSet ds = null;
                try
                {
                    ds = bll.GetHisantennaInfoByCodeSenderAddress(pIndex, m_PSize, m_StrWhere);
                }
                catch { }

                if (ds.Tables != null && ds.Tables.Count > 0)
                {
                    // 重新设置页数
                    int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                    if (sumPage != 0)
                    {
                        sumPage = sumPage % m_PSize != 0 ? sumPage / m_PSize + 1 : sumPage / m_PSize;
                        m_PCounts = sumPage;//获取总页数
                        if (pIndex > sumPage)
                        {
                            if (sumPage == 0)
                            {

                                //lblCounts.Text = "符合筛选条件：共 0 条信息";
                                labtext(lblCounts, "符合筛选条件：共 0 条信息");
                                //lblPageCounts.Text = "1";
                                labtext(lblPageCounts, "1");
                                //lblSumPage.Text = "/" + 1 + "页";
                                labtext(lblSumPage, "/" + 1 + "页");
                                //btnUpPage.Enabled = false;
                                ObjectEnable(btnUpPage, false);
                                //btnDownPage.Enabled = false;
                                ObjectEnable(btnDownPage, false);
                                return;
                            }
                            pIndex = sumPage;
                        }

                        //btnUpPage.Enabled = true;
                        ObjectEnable(btnUpPage, true);
                        //btnDownPage.Enabled = true;
                        ObjectEnable(btnDownPage, true);
                        if (pIndex == 1)
                        {
                            //btnUpPage.Enabled = false;
                            ObjectEnable(btnUpPage, false);
                        }
                        if (pIndex == sumPage)
                        {
                            ObjectEnable(btnDownPage, false);
                            //btnDownPage.Enabled = false;
                        }
                    }
                    else
                    {
                        //btnUpPage.Enabled = false;
                        //btnDownPage.Enabled = false;
                        ObjectEnable(btnUpPage, false);
                        ObjectEnable(btnDownPage, false);
                        pIndex = 0;
                    }
                    //lblCounts.Text = "符合筛选条件：共 " + ds.Tables[1].Rows[0][0].ToString() + " 条信息";
                    labtext(lblCounts, "符合筛选条件：共 " + ds.Tables[1].Rows[0][0].ToString() + " 条信息");


                    //lblPageCounts.Text = pIndex.ToString();
                    labtext(lblPageCounts, pIndex.ToString());
                    //lblSumPage.Text = "/" + sumPage + "页";
                    labtext(lblSumPage, "/" + sumPage + "页");
                    //dgv.DataSource = ds.Tables[0];
                    Bind(ds.Tables[0]);
                    //dgv.Columns["HisInStationID"].Visible = false;
                    dgvv("HisInStationID");
                    //dgv.Columns["stationAddress"].Visible = false;
                    dgvv("stationAddress");
                    //dgv.Columns["StationHeadAddress"].Visible = false;
                    dgvv("StationHeadAddress");
                    //dgv.Columns["InStationAntenna"].Visible = false;
                    dgvv("InStationAntenna");
                    //dgv.Columns["CsTypeID"].Visible = false;
                    dgvv("CsTypeID");
                }
                else
                {
                    Bind(new DataTable());
                    //lblCounts.Text = "符合筛选条件：共 0 条信息";
                    labtext(lblCounts, "符合筛选条件：共 0 条信息");
                    //btnUpPage.Enabled = false;
                    ObjectEnable(btnUpPage, false);
                    //btnDownPage.Enabled = false;
                    ObjectEnable(btnDownPage, false);
                    //lblPageCounts.Text = "1";
                    labtext(lblPageCounts, "1");
                    //lblSumPage.Text = "/" + 1 + "页";
                    labtext(lblSumPage, "/" + 1 + "页");
                }
                piccc(false);
                btnSearch.Invoke(new SetEnable(this.SetBtnSearch), new object[] { true });
                btnReSet.Invoke(new SetEnable(this.SetBtnReset), new object[] { true });
                SetAllEnable(true);
            }
            catch (Exception ex)
            { }
            th.Abort();
        }
        #endregion
        #endregion

        #region 【系统事件方法】
        #region 【事件方法：窗体加载】
        private void A_frmHisAntenna_Load(object sender, EventArgs e)
        {
            dtpStartTime.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
            dtpEndTime.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            dtpStartTime.MaxDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
            dtpEndTime.MaxDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
            this.EndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.StartDate= DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            trvHead.Nodes.Add("all", "所有");
            LoadTree();
            trvHead.Nodes[0].Expand();
            cmbSelectCounts.SelectedIndex = 0;

            GetScaleString();
            //BindData(1);
            //btnHisAntenna_Click(this, new EventArgs());
        }
        #endregion

        #region 【事件方法：选择显示人员数据】
        private void rbtemp_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtemp.Checked)
            {
                lblName.Text = "姓名：";
                txtScealName.Enabled = true;
                type = "0";
                GetScaleString();
                pictureBox1.Visible = true;
                Index = 1;
                ThreadStart run = new ThreadStart(BindData);
                th = new Thread(run);
                th.Start();
                //BindData();
            }
        }
        #endregion

        #region 【事件方法：选择显示设备数据】
        private void rbtequ_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtequ.Checked)
            {
                lblName.Text = "设备：";
                txtScealName.Enabled = true;
                type = "1";
                GetScaleString();
                pictureBox1.Visible = true;
                Index = 1;
                ThreadStart run = new ThreadStart(BindData);
                th = new Thread(run);
                th.Start();
                //BindData();
            }
        }
        #endregion

        #region 【事件方法：选择显示未登记数据】
        private void rbtno_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtno.Checked)
            {
                lblName.Text = "姓名：";
                txtScealName.Text = "";
                txtScealName.Enabled = false;
                type = "null";

                GetScaleString();
                pictureBox1.Visible = true;
                Index = 1;
                ThreadStart run = new ThreadStart(BindData);
                th = new Thread(run);
                th.Start();
                //BindData();
            }
        }
        #endregion

        #region 【事件方法：选择显示所有数据】
        private void rbtall_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtall.Checked)
            {
                lblName.Text = "称呼：";
                txtScealName.Enabled = true;
                type = "";

                GetScaleString();
                pictureBox1.Visible = true;
                Index = 1;
                ThreadStart run = new ThreadStart(BindData);
                th = new Thread(run);
                th.Start();
                //BindData(1);
            }
        }
        #endregion

        #region 【事件方法：传输分站和读卡分站树点击查询】
        private void trvHead_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (DateTime.Parse(this.StartDate).CompareTo(DateTime.Parse(this.EndDate)) >= 0)
            {
                MessageBox.Show("开始时间应小于结束时间...", "提示", MessageBoxButtons.OK);
                return;
            }
            if (DateTime.Parse(this.EndDate).AddDays(-7).CompareTo(DateTime.Parse(this.StartDate)) > 0)
            {
                MessageBox.Show("时间间隔不能大于7天...", "提示", MessageBoxButtons.OK);
                return;
            }
            GetScaleString();
            pictureBox1.Visible = true;
            Index = 1;
            ThreadStart run = new ThreadStart(BindData);
            th = new Thread(run);
            th.Start();
            //Index = 1;
            //BindData();


            //TreeNode node = trvHead.SelectedNode;
            //if (node.ImageKey == "3")
            //{
            //    atnenna = node.Name;
            //    stationhead = node.Parent.Name;
            //    station = node.Parent.Parent.Name;
            //}
            //if (node.ImageKey == "2")
            //{
            //    atnenna = "";
            //    stationhead = node.Name;
            //    station = node.Parent.Name;
            //}
            //if (node.ImageKey == "1")
            //{
            //    atnenna = "";
            //    stationhead = "";
            //    station = node.Name;
            //}
            //if (node.ImageKey == "")
            //{
            //    atnenna = "";
            //    stationhead = "";
            //    station = "";
            //}
            //isSearch = false;
            //int rowcount = 0;
            //DataTable dt = bll.GetHisantennaInfo(station, stationhead, atnenna, type, StartDate, EndDate, Convert.ToInt32(cmbSelectCounts.SelectedItem), 1, out PageCount, out rowcount);
            //dgv.DataSource = dt;
            //int width = 0;
            //try
            //{
            //    width = (dgv.Width - 2) / (dgv.Columns.Count);
            //}
            //catch (Exception ex)
            //{ }
            //for (int i = 0; i < dgv.Columns.Count; i++)
            //{
            //    dgv.Columns[i].ReadOnly = true;
            //    dgv.Columns[i].Width = width;
            //}
            //lblPageCounts.Text = "1";
            //lblSumPage.Text = "/" + PageCount.ToString() + "页";
            //txtSkipPage.Text = "1";
            //lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
        }
        #endregion

        #region【事件方法：查询按钮查询】
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (DateTime.Parse(this.StartDate).CompareTo(DateTime.Parse(this.EndDate)) >= 0)
            {
                MessageBox.Show("开始时间应小于结束时间...", "提示", MessageBoxButtons.OK);
                return;
            }
            if (DateTime.Parse(this.EndDate).AddDays(-7).CompareTo(DateTime.Parse(this.StartDate)) > 0)
            {
                MessageBox.Show("时间间隔不能大于7天...", "提示", MessageBoxButtons.OK);
                return;
            }
            GetScaleString();
            pictureBox1.Visible = true;
            Index = 1;
            ThreadStart run = new ThreadStart(BindData);
            th = new Thread(run);
            th.Start();
            //Index = 1;
            //BindData();
        }
        #endregion

        #region 【事件方法：查询开始时间改变后保存】
        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            //if (dtpStartTime.Value.CompareTo(dtpEndTime.Value) < 0)
            //{
            //    if (dtpEndTime.Value.AddDays(-7).CompareTo(dtpStartTime.Value) > 0)
            //    {
            //        MessageBox.Show("时间间隔不能大于7天...", "提示", MessageBoxButtons.OK);
            //        return;
            //    }
            //    else
            //    {
                    this.StartDate = dtpStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //        if (txtCodeSender.Text == "")
            //            isSearch = false;
            //        if (!isSearch)
            //            btnHisAntenna_Click(this, new EventArgs());
            //        else
            //            btnSearch_Click(this, new EventArgs());
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("开始时间应小于结束时间...", "提示", MessageBoxButtons.OK);
            //    dtpStartTime.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
            //}
        }
        #endregion

        #region 【事件方法：查询结束时间改变后保存】
        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            //if (dtpStartTime.Value.CompareTo(dtpEndTime.Value) < 0)
            //{
            //    if (dtpEndTime.Value.AddDays(-7).CompareTo(dtpStartTime.Value) > 0)
            //    {
            //        MessageBox.Show("时间间隔不能大于7天...", "提示", MessageBoxButtons.OK);
            //    }
            //    else
            //    {
                    this.EndDate = dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //        if (txtCodeSender.Text == "")
            //            isSearch = false;
            //        if (!isSearch)
            //            btnHisAntenna_Click(this, new EventArgs());
            //        else
            //            btnSearch_Click(this, new EventArgs());
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("开始时间应小于结束时间...", "提示", MessageBoxButtons.OK);
            //    dtpEndTime.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //}
        }
        #endregion

        #region 【事件方法：重置】
        private void btnReSet_Click(object sender, EventArgs e)
        {
            txtCodeSender.Text = "";
            txtScealName.Text = "";
            dtpStartTime.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
            dtpEndTime.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            dtpStartTime.MaxDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
            dtpEndTime.MaxDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
            this.EndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.StartDate = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            pictureBox1.Visible = true;
            GetScaleString();
            Index = 1;
            ThreadStart run = new ThreadStart(BindData);
            th = new Thread(run);
            th.Start();
            //Index = 1;
            //BindData();
        }
        #endregion

        #region 【事件方法：显示上一页数据】
        private void btnUpPage_Click(object sender, EventArgs e)
        {

            int page = int.Parse(lblPageCounts.Text);
            page--;
            if (!btnDownPage.Enabled)
            {
                btnDownPage.Enabled = true;
            }
            if (page == 1)              //第一页时
            {

                btnUpPage.Enabled = false;
            }
            else if (page < 1)          //小于1时
            {
                return;
            }
            else
            {
                btnUpPage.Enabled = true;
            }
            pictureBox1.Visible = true;
            Index = page;
            //Index = 1;
            ThreadStart run = new ThreadStart(BindData);
            th = new Thread(run);
            th.Start();
            //BindData();

            //int num = int.Parse(lblPageCounts.Text);
            //if (num > 1)
            //{
            //    num--;
            //    int rowcount = 0;
            //    DataTable dt = bll.GetHisantennaInfo(station, stationhead, atnenna, type, StartDate, EndDate, Convert.ToInt32(cmbSelectCounts.SelectedItem), num, out PageCount, out rowcount);
            //    dgv.DataSource = dt;
            //    int width = 0;
            //    try
            //    {
            //        width = (dgv.Width - 2) / (dgv.Columns.Count);
            //    }
            //    catch (Exception ex)
            //    { }
            //    for (int i = 0; i < dgv.Columns.Count; i++)
            //    {
            //        dgv.Columns[i].ReadOnly = true;
            //        dgv.Columns[i].Width = width;
            //    }
            //    lblPageCounts.Text = num.ToString();
            //    lblSumPage.Text = "/" + PageCount.ToString() + "页";
            //    lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            //}
        }
        #endregion

        #region 【事件方法：显示下一页数据】
        private void btnDownPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page++;

            if (!btnUpPage.Enabled)
            {
                btnUpPage.Enabled = true;
            }
            if (page == m_PCounts)              //最后一页时
            {

                btnDownPage.Enabled = false;
            }
            else if (page > m_PCounts)          //大于最后一页时
            {
                return;
            }
            else
            {
                btnDownPage.Enabled = true;

            }
            pictureBox1.Visible = true;
            Index = page;
            //Index = 1;
            ThreadStart run = new ThreadStart(BindData);
            th = new Thread(run);
            th.Start();
            //BindData();

            //int num = int.Parse(lblPageCounts.Text);
            //if (num < PageCount)
            //{
            //    num++;
            //    int rowcount = 0;
            //    DataTable dt = bll.GetHisantennaInfo(station, stationhead, atnenna, type, StartDate, EndDate, Convert.ToInt32(cmbSelectCounts.SelectedItem), num, out PageCount, out rowcount);
            //    dgv.DataSource = dt;
            //    int width = 0;
            //    try
            //    {
            //        width = (dgv.Width - 2) / (dgv.Columns.Count);
            //    }
            //    catch (Exception ex)
            //    { }
            //    for (int i = 0; i < dgv.Columns.Count; i++)
            //    {
            //        dgv.Columns[i].ReadOnly = true;
            //        dgv.Columns[i].Width = width;
            //    }
            //    lblPageCounts.Text = num.ToString();
            //    lblSumPage.Text = "/" + PageCount.ToString() + "页";
            //    lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            //}
        }
        #endregion

        #region 【事件方法：跳转页数】
        private void txtSkipPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string value = txtSkipPage.Text;
                if (value.CompareTo("") == 0)       //为空值时
                {
                    return;
                }
                else if (int.Parse(value) > 0)
                {
                    int page = int.Parse(value);
                    if (page == 1)                  //跳至第一页时
                    {
                        btnUpPage.Enabled = false;
                        btnDownPage.Enabled = true;
                    }
                    else if (page == m_PCounts)     //跳至最后一页时
                    {
                        btnUpPage.Enabled = true;
                        btnDownPage.Enabled = false;
                    }
                    else
                    {
                        btnUpPage.Enabled = true;
                        btnDownPage.Enabled = true;
                    }
                    if (page > m_PCounts)           //大于记录的总页数
                    {
                        page = m_PCounts;
                        btnUpPage.Enabled = true;
                        btnDownPage.Enabled = false;
                    }
                    pictureBox1.Visible = true;
                    Index = page;
                    //BindData();
                    //Index = 1;
                    ThreadStart run = new ThreadStart(BindData);
                    th = new Thread(run);
                    th.Start();
                }
            }

            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    int num = int.Parse(txtSkipPage.Text);
            //    if (num >= PageCount)
            //    {
            //        num = PageCount;
            //    }
            //    int rowcount = 0;
            //    DataTable dt = bll.GetHisantennaInfo(station, stationhead, atnenna, type, StartDate, EndDate, Convert.ToInt32(cmbSelectCounts.SelectedItem), num, out PageCount, out rowcount);
            //    dgv.DataSource = dt;
            //    int width = 0;
            //    try
            //    {
            //        width = (dgv.Width - 2) / (dgv.Columns.Count);
            //    }
            //    catch (Exception ex)
            //    { }
            //    for (int i = 0; i < dgv.Columns.Count; i++)
            //    {
            //        dgv.Columns[i].ReadOnly = true;
            //        dgv.Columns[i].Width = width;
            //    }
            //    lblPageCounts.Text = num.ToString();
            //    lblSumPage.Text = "/" + PageCount.ToString() + "页";
            //    lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            //}
        }
        #endregion

        #region 【事件方法：每页显示个数改变】
        private void cmbSelectCounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_PSize != int.Parse(cmbSelectCounts.SelectedItem.ToString()))
            {
                m_PSize = int.Parse(cmbSelectCounts.SelectedItem.ToString());
                //Index = 1;
                //BindData();
                pictureBox1.Visible = true;
                Index = 1;
                ThreadStart run = new ThreadStart(BindData);
                th = new Thread(run);
                th.Start();
            }

            //if (!isSearch)
            //{ 
            //    int rowcount = 0;
            //    DataTable dt = bll.GetHisantennaInfo(station, stationhead, atnenna, type, StartDate, EndDate, Convert.ToInt32(cmbSelectCounts.SelectedItem), 1, out PageCount, out rowcount);
            //    dgv.DataSource = dt;
            //    int width = 0;
            //    try
            //    {
            //        width = (dgv.Width - 2) / (dgv.Columns.Count);
            //    }
            //    catch (Exception ex)
            //    { }
            //    for (int i = 0; i < dgv.Columns.Count; i++)
            //    {
            //        dgv.Columns[i].ReadOnly = true;
            //        dgv.Columns[i].Width = width;
            //    }
            //    lblPageCounts.Text = "1";
            //    lblSumPage.Text = "/" + PageCount.ToString() + "页";
            //    txtSkipPage.Text = "1";
            //    lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            //}
            //else
            //{
            //    btnSearch_Click(this, new EventArgs());
            //}
        }
        #endregion

        #region 【事件方法：打印】
        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgv, "历史天线", lblCounts.Text.Substring(lblCounts.Text.IndexOf("：") + 1));
        }
        #endregion

        private void txtScealName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        #endregion
    }
}
