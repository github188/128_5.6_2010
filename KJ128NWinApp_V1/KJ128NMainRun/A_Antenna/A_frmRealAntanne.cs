using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJ128NMainRun.A_Antenna
{
    public partial class A_frmRealAntanne : KJ128NMainRun.FromModel.FrmModel
    {
        private KJ128NDBTable.A_AntennaBLL bll = new KJ128NDBTable.A_AntennaBLL();

        private string station = "";
        private string stationhead = "";
        private string atnenna = "";
        private string type = "0";
        private int PageCount = 0;
        private bool IsUse = false;
        private string StartDate = "";
        private string EndDate = "";
        private bool isSearch = false;
        private string Search = string.Empty;
        private bool ShowMine = true;
        private string CodeSenderAddress = string.Empty;
        private string strName = "";

        public A_frmRealAntanne()
        {
            InitializeComponent();
            drawerLeftMain.Add(pnl1, true);
            drawerLeftMain.LeftPartResize();
        }

        private void A_frmRealAntanne_Load(object sender, EventArgs e)
        {
            trvHead.Nodes.Add("all", "所有");
            LoadTree();
            trvHead.Nodes[0].Expand();
            cmbSelectCounts.SelectedIndex = 0;
            btnRtAntenna_Click(this, new EventArgs());
            int num = (new KJ128NDBTable.A_GraphicsBLL().GetFlashTime())*1000;
            Timer t = new Timer();
            t.Interval = num;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }

        void t_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                if (chbRtTime.Checked)
                {
                    //LoadTree();
                    //if (!isSearch)
                    //{                        
                        int rowcount = 0;
                        DataTable dt = bll.GetRTantennaInfo(station, stationhead, atnenna, type, StartDate, EndDate, ShowMine, CodeSenderAddress, Convert.ToInt32(cmbSelectCounts.SelectedItem), int.Parse(lblPageCounts.Text),strName, out PageCount, out rowcount);
                        dgv.DataSource = dt;
                        for (int i = 1; i < dgv.Columns.Count; i++)
                        {
                            dgv.Columns[i].ReadOnly = true;
                        }
                        //lblPageCounts.Text = "1";
                        lblSumPage.Text = "/" + PageCount.ToString() + "页";
                        txtSkipPage.Text = "1";
                        lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
                    //}
                    //else
                    //{
                    //    int rowcount = 0;
                    //    DataTable dt = bll.GetRTantennaInfoByCodeSenderAddress(Search, ShowMine, type, Convert.ToInt32(cmbSelectCounts.SelectedItem), 1, out PageCount, out rowcount);
                    //    dgv.DataSource = dt;
                    //    for (int i = 1; i < dgv.Columns.Count; i++)
                    //    {
                    //        dgv.Columns[i].ReadOnly = true;
                    //    }
                    //    lblPageCounts.Text = "1";
                    //    lblSumPage.Text = "/" + PageCount.ToString() + "页";
                    //    txtSkipPage.Text = "1";
                    //    lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
                    //}
                }
            }
        }

        private void LoadTree()
        {
            DataTable dt = bll.GetAllStation();
            int count = trvHead.Nodes[0].Nodes.Count > dt.Rows.Count ? trvHead.Nodes[0].Nodes.Count : dt.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                try
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
                catch (Exception ex)
                { }
            }

        }

        #region【事件：选择树】

        private void trvHead_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = trvHead.SelectedNode;
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
            isSearch = false;
            int rowcount = 0;
            DataTable dt = bll.GetRTantennaInfo(station, stationhead, atnenna, type, StartDate, EndDate, ShowMine, CodeSenderAddress, Convert.ToInt32(cmbSelectCounts.SelectedItem), 1,strName, out PageCount, out rowcount);
            dgv.DataSource = dt;
            for (int i = 1; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].ReadOnly = true;
            }
            lblPageCounts.Text = "1";
            lblSumPage.Text = "/" + PageCount.ToString() + "页";
            txtSkipPage.Text = "1";
            lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
        }

        #endregion

        #region【事件：选择人员】

        private void rbtemp_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtemp.Checked)
            {
                label2.Text = "姓名：";
                txt_Name.Text = "";
                txt_Name.Enabled = true;
            }

            type = "0";
            if (!isSearch)
            {
                int rowcount = 0;
                DataTable dt = bll.GetRTantennaInfo(station, stationhead, atnenna, type, StartDate, EndDate, ShowMine, CodeSenderAddress, Convert.ToInt32(cmbSelectCounts.SelectedItem), int.Parse(lblPageCounts.Text),strName, out PageCount, out rowcount);
                dgv.DataSource = dt;
                for (int i = 1; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].ReadOnly = true;
                }
                //lblPageCounts.Text = "1";
                lblSumPage.Text = "/" + PageCount.ToString() + "页";
                txtSkipPage.Text = "1";
                lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            }
            else
            {
                int rowcount = 0;
                DataTable dt = bll.GetRTantennaInfoByCodeSenderAddress(Search, ShowMine, type, Convert.ToInt32(cmbSelectCounts.SelectedItem), 1, out PageCount, out rowcount);
                dgv.DataSource = dt;
                for (int i = 1; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].ReadOnly = true;
                }
                lblPageCounts.Text = "1";
                lblSumPage.Text = "/" + PageCount.ToString() + "页";
                txtSkipPage.Text = "1";
                lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            }
        }

        #endregion

        #region【事件：选择设备】

        private void rbtequ_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtequ.Checked)
            {
                label2.Text = "名称：";
                txt_Name.Text = "";
                txt_Name.Enabled = true;
            }

            type = "1";
            if (!isSearch)
            {
                int rowcount = 0;
                DataTable dt = bll.GetRTantennaInfo(station, stationhead, atnenna, type, StartDate, EndDate, ShowMine, CodeSenderAddress, Convert.ToInt32(cmbSelectCounts.SelectedItem), int.Parse(lblPageCounts.Text),strName, out PageCount, out rowcount);
                dgv.DataSource = dt;
                for (int i = 1; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].ReadOnly = true;
                }
                //lblPageCounts.Text = "1";
                lblSumPage.Text = "/" + PageCount.ToString() + "页";
                txtSkipPage.Text = "1";
                lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            }
            else
            {
                int rowcount = 0;
                DataTable dt = bll.GetRTantennaInfoByCodeSenderAddress(Search, ShowMine, type, Convert.ToInt32(cmbSelectCounts.SelectedItem), 1, out PageCount, out rowcount);
                dgv.DataSource = dt;
                for (int i = 1; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].ReadOnly = true;
                }
                lblPageCounts.Text = "1";
                lblSumPage.Text = "/" + PageCount.ToString() + "页";
                txtSkipPage.Text = "1";
                lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            }
        }

        #endregion

        #region【事件：选择未登记的卡】

        private void rbtno_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtno.Checked)
            {
                label2.Text = "名称：";
                txt_Name.Text = "";
                txt_Name.Enabled = false;
            }

            type = "null";
            if (!isSearch)
            {
                int rowcount = 0;
                DataTable dt = bll.GetRTantennaInfo(station, stationhead, atnenna, type, StartDate, EndDate, ShowMine, CodeSenderAddress, Convert.ToInt32(cmbSelectCounts.SelectedItem), int.Parse(lblPageCounts.Text),strName, out PageCount, out rowcount);
                dgv.DataSource = dt;
                for (int i = 1; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].ReadOnly = true;
                }
                //lblPageCounts.Text = "1";
                lblSumPage.Text = "/" + PageCount.ToString() + "页";
                txtSkipPage.Text = "1";
                lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            }
            else
            {
                int rowcount = 0;
                DataTable dt = bll.GetRTantennaInfoByCodeSenderAddress(Search, ShowMine, type, Convert.ToInt32(cmbSelectCounts.SelectedItem), 1, out PageCount, out rowcount);
                dgv.DataSource = dt;
                for (int i = 1; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].ReadOnly = true;
                }
                lblPageCounts.Text = "1";
                lblSumPage.Text = "/" + PageCount.ToString() + "页";
                txtSkipPage.Text = "1";
                lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            }
        }

        #endregion

        #region【事件：选择所有标识卡】

        private void rbtall_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtall.Checked)
            {
                label2.Text = "名称：";
                txt_Name.Text = "";
                txt_Name.Enabled = true;
            }

            type = "";
            if (!isSearch)
            {
                int rowcount = 0;
                DataTable dt = bll.GetRTantennaInfo(station, stationhead, atnenna, type, StartDate, EndDate, ShowMine, CodeSenderAddress, Convert.ToInt32(cmbSelectCounts.SelectedItem), int.Parse(lblPageCounts.Text),strName, out PageCount, out rowcount);
                dgv.DataSource = dt;
                for (int i = 1; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].ReadOnly = true;
                }
                //lblPageCounts.Text = "1";
                lblSumPage.Text = "/" + PageCount.ToString() + "页";
                txtSkipPage.Text = "1";
                lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            }
            else
            {
                int rowcount = 0;
                DataTable dt = bll.GetRTantennaInfoByCodeSenderAddress(Search, ShowMine, type, Convert.ToInt32(cmbSelectCounts.SelectedItem), 1, out PageCount, out rowcount);
                dgv.DataSource = dt;
                for (int i = 1; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].ReadOnly = true;
                }
                lblPageCounts.Text = "1";
                lblSumPage.Text = "/" + PageCount.ToString() + "页";
                txtSkipPage.Text = "1";
                lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            }
        }

        #endregion

        private void btnUpPage_Click(object sender, EventArgs e)
        {
            int num = int.Parse(lblPageCounts.Text);
            if (num > 1)
            {
                num--;
                int rowcount = 0;
                DataTable dt = bll.GetRTantennaInfo(station, stationhead, atnenna, type, StartDate, EndDate, ShowMine, CodeSenderAddress, Convert.ToInt32(cmbSelectCounts.SelectedItem), num,strName, out PageCount, out rowcount);
                dgv.DataSource = dt;
                for (int i = 1; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].ReadOnly = true;
                }
                lblPageCounts.Text = num.ToString();
                lblSumPage.Text = "/" + PageCount.ToString() + "页";
                lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            }
        }

        private void btnDownPage_Click(object sender, EventArgs e)
        {
            int num = int.Parse(lblPageCounts.Text);
            if (num < PageCount)
            {
                num++;
                int rowcount = 0;
                DataTable dt = bll.GetRTantennaInfo(station, stationhead, atnenna, type, StartDate, EndDate, ShowMine, CodeSenderAddress, Convert.ToInt32(cmbSelectCounts.SelectedItem), num,strName, out PageCount, out rowcount);
                dgv.DataSource = dt;
                for (int i = 1; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].ReadOnly = true;
                }
                lblPageCounts.Text = num.ToString();
                lblSumPage.Text = "/" + PageCount.ToString() + "页";
                lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            }
        }

        private void txtSkipPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int num = int.Parse(txtSkipPage.Text);
                if (num >= PageCount)
                {
                    num = PageCount;
                }
                int rowcount = 0;
                DataTable dt = bll.GetRTantennaInfo(station, stationhead, atnenna, type, StartDate, EndDate, ShowMine, CodeSenderAddress, Convert.ToInt32(cmbSelectCounts.SelectedItem), num,strName, out PageCount, out rowcount);
                dgv.DataSource = dt;
                for (int i = 1; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].ReadOnly = true;
                }
                lblPageCounts.Text = num.ToString();
                lblSumPage.Text = "/" + PageCount.ToString() + "页";
                lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            }
        }

        private void cmbSelectCounts_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (!isSearch)
            {
                int rowcount = 0;
                DataTable dt = bll.GetRTantennaInfo(station, stationhead, atnenna, type, StartDate, EndDate, ShowMine, CodeSenderAddress, Convert.ToInt32(cmbSelectCounts.SelectedItem), 1,strName, out PageCount, out rowcount);
                dgv.DataSource = dt;
                for (int i = 1; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].ReadOnly = true;
                }
                lblPageCounts.Text = "1";
                lblSumPage.Text = "/" + PageCount.ToString() + "页";
                txtSkipPage.Text = "1";
                lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            }
            else
            {
                int rowcount = 0;
                DataTable dt = bll.GetRTantennaInfoByCodeSenderAddress(Search, ShowMine, type, Convert.ToInt32(cmbSelectCounts.SelectedItem), 1, out PageCount, out rowcount);
                dgv.DataSource = dt;
                for (int i = 1; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].ReadOnly = true;
                }
                lblPageCounts.Text = "1";
                lblSumPage.Text = "/" + PageCount.ToString() + "页";
                txtSkipPage.Text = "1";
                lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            }
        }

        private void btnReSet_Click(object sender, EventArgs e)
        {
            txtCodeSenderAddress.Text = "";
            CodeSenderAddress = string.Empty;
            trvHead.SelectedNode = trvHead.Nodes[0];
            rbtemp.Checked = true;
            rbtequ.Checked = false;
            rbtno.Checked = false;
            rbtall.Checked = false;
            trvHead_AfterSelect(this, new TreeViewEventArgs(trvHead.SelectedNode));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtCodeSenderAddress.Text.Trim().Equals("0"))
            {
                MessageBox.Show("标识卡编号不能为0，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            strName = txt_Name.Text.Trim();
            CodeSenderAddress = txtCodeSenderAddress.Text;
            this.trvHead_AfterSelect(this, new TreeViewEventArgs(trvHead.SelectedNode));
            //if (txtCodeSenderAddress.Text == "")
            //{
            //    MessageBox.Show("标识卡号不能为空...", "提示", MessageBoxButtons.OK);
            //}
            //else
            //{
            //    try
            //    {
            //        int.Parse(txtCodeSenderAddress.Text);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("标识卡号格式不正确...", "提示", MessageBoxButtons.OK);
            //    }
            //    isSearch = true;
            //    Search = txtCodeSenderAddress.Text;
            //    int rowcount = 0;
            //    DataTable dt = bll.GetRTantennaInfoByCodeSenderAddress(Search, ShowMine, type, Convert.ToInt32(cmbSelectCounts.SelectedItem), 1, out PageCount, out rowcount);
            //    dgv.DataSource = dt;
            //    for (int i = 1; i < dgv.Columns.Count; i++)
            //    {
            //        dgv.Columns[i].ReadOnly = true;
            //    }
            //    lblPageCounts.Text = "1";
            //    lblSumPage.Text = "/" + PageCount.ToString() + "页";
            //    txtSkipPage.Text = "1";
            //    lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            //}
        }

        private void btnLaws_Click(object sender, EventArgs e)
        {
            A_frmRTAntennaConfig f = null;
            if (IsUse)
            {
                f = new A_frmRTAntennaConfig(IsUse, DateTime.Parse(this.StartDate), DateTime.Parse(this.EndDate), ShowMine);
            }
            else
            {
                f = new A_frmRTAntennaConfig(ShowMine);
            }
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.IsUse = f.IsUse;
                this.ShowMine = f.ShowMine;
                if (this.IsUse)
                {
                    this.StartDate = f.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
                    this.EndDate = f.EndTime.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    this.StartDate = "";
                    this.EndDate = "";
                }
                int rowcount = 0;
                DataTable dt = bll.GetRTantennaInfo(station, stationhead, atnenna, type, StartDate, EndDate, ShowMine, CodeSenderAddress, Convert.ToInt32(cmbSelectCounts.SelectedItem), 1,strName, out PageCount, out rowcount);
                dgv.DataSource = dt;
                for (int i = 1; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].ReadOnly = true;
                }
                lblPageCounts.Text = "1";
                lblSumPage.Text = "/" + PageCount.ToString() + "页";
                txtSkipPage.Text = "1";
                lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            }
        }

        private void btnRtAntenna_Click(object sender, EventArgs e)
        {
            this.trvHead.SelectedNode = trvHead.Nodes[0];
            trvHead_AfterSelect(this, new TreeViewEventArgs(trvHead.SelectedNode));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgv, "实时天线", lblCounts.Text.Substring(lblCounts.Text.IndexOf("：") + 1));
        }

        #region【事件：DataGridView错误处理】

        private void dgv_Main_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string strErr = e.Exception.Message;
            e.ThrowException = false;
        }

        #endregion

        private void txt_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
    }
}
