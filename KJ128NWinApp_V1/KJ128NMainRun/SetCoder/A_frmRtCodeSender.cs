using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NMainRun.SetCoder
{
    public partial class A_frmRtCodeSender : KJ128NMainRun.FromModel.FrmModel
    {
        private A_CodeSenderBLL bll = new A_CodeSenderBLL();

        private bool isFlash = false;
        private bool isDown = false;
        private bool isEmp = true;
        /// <summary>
        /// 查询条件
        /// </summary>
        private string mes = "";
        private int PageCount = 0;
        private string CodeSendAddress = string.Empty;
        private string objName = string.Empty;

        #region 【构造函数】
        public A_frmRtCodeSender()
        {
            InitializeComponent();
            drawerLeftMain.Add(pnl, true);
            drawerLeftMain.LeftPartResize();
        }
        #endregion

        #region 【系统事件方法】
        #region 【事件方法：窗体加载】
        private void A_frmRtCodeSender_Load(object sender, EventArgs e)
        {
            cmbSelectCounts.SelectedIndex = 0;
            TreeNode node=new TreeNode();
            node.ImageKey="all";
            node.Text="所有";
            trv.RootNode = node;
            LoadTree();
            trv.Nodes[0].Expand();
            GetScealSQL();
            int num = (new KJ128NDBTable.A_GraphicsBLL().GetFlashTime()) * 1000;
            Timer t = new Timer();
            t.Interval = num;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }
        #endregion

        #region 【事件方法：定时器】
        void t_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                if (chkRealTime.Checked)
                {
                    //LoadTree();
                    GetScealSQL();
                    int num = int.Parse(lblPageCounts.Text);
                    int rowcount = 0;
                    DataTable dt = bll.GetRTcodesender(mes, rbtEmp.Checked, chkDown.Checked, CodeSendAddress, objName, Convert.ToInt32(cmbSelectCounts.SelectedItem), num, out PageCount, out rowcount);
                    dgv.DataSource = dt;
                    for (int i = 1; i < dgv.Columns.Count; i++)
                    {
                        dgv.Columns[i].ReadOnly = true;
                    }
                    lblPageCounts.Text = num.ToString();
                    lblSumPage.Text = "/" + PageCount.ToString() + "页";
                    txtSkipPage.Text = num.ToString();
                    lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
                }
            }
        }
        #endregion

        #region 【事件方法：部门树选择】
        private void trv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //mes = "";
            //for (int i = 0; i < trv.ValueList.Count; i++)
            //{
            //    if (trv.ValueList[i] == "all")
            //        continue;
            //    mes = mes + trv.ValueList[i] + ",";
            //}
            //mes = "where deptid in (" + mes.Remove(mes.Length - 1) + ")";
            
            //获取查询条件
            GetScealSQL();
            //MessageBox.Show(mes);
            int rowcount = 0;
            DataTable dt = bll.GetRTcodesender(mes, rbtEmp.Checked, chkDown.Checked, CodeSendAddress, objName, Convert.ToInt32(cmbSelectCounts.SelectedItem), 1, out PageCount, out rowcount);
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

        #region 【事件方法：选择人员-显示人员数据】
        private void rbtEmp_CheckedChanged(object sender, EventArgs e)
        {
            if (!isEmp)
            {
                labObj.Text = "姓名";
                isEmp = true;
                FlashData();
            }
        }
        #endregion

        #region 【事件方法：选择设备-显示设备数据】
        private void rbtEqu_CheckedChanged(object sender, EventArgs e)
        {
            if (isEmp)
            {
                labObj.Text = "设备";
                isEmp = false;
                FlashData();
            }
        }
        #endregion

        #region 【事件方法：点击查询按钮显示数据】
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!txtCode.Text.Equals("") || !txtObj.Text.Equals(""))
            {
                if (!txtCode.Text.Equals(""))
                {
                    try
                    {
                        int.Parse(txtCode.Text);
                    }
                    catch
                    {
                        MessageBox.Show("标识卡格式不正确...", "提示", MessageBoxButtons.OK);
                        return;
                    }
                }
                this.CodeSendAddress = txtCode.Text;
                this.objName = txtObj.Text;
                FlashData();
            }
        }
        #endregion

        #region 【事件方法：改变仅下井人员单选项-显示人员数据】
        private void chkDown_CheckedChanged(object sender, EventArgs e)
        {
            int num = int.Parse(lblPageCounts.Text);
            int rowcount = 0;
            DataTable dt = bll.GetRTcodesender(mes, rbtEmp.Checked, chkDown.Checked, CodeSendAddress, objName, Convert.ToInt32(cmbSelectCounts.SelectedItem), num, out PageCount, out rowcount);
            dgv.DataSource = dt;
            for (int i = 1; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].ReadOnly = true;
            }
            lblPageCounts.Text = num.ToString();
            lblSumPage.Text = "/" + PageCount.ToString() + "页";
            txtSkipPage.Text = num.ToString();
            lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
        }
        #endregion

        #region 【事件方法：显示下一页数据】
        private void btnDownPage_Click(object sender, EventArgs e)
        {
            int num = int.Parse(lblPageCounts.Text);
            if (num < PageCount)
            {
                num++;
                int rowcount = 0;
                DataTable dt = bll.GetRTcodesender(mes, rbtEmp.Checked, chkDown.Checked, CodeSendAddress, objName, Convert.ToInt32(cmbSelectCounts.SelectedItem), num, out PageCount, out rowcount);
                dgv.DataSource = dt;
                for (int i = 1; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].ReadOnly = true;
                }
                lblPageCounts.Text = num.ToString();
                lblSumPage.Text = "/" + PageCount.ToString() + "页";
                txtSkipPage.Text = num.ToString();
                lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            }
        }
        #endregion

        #region 【事件方法：显示上一页数据】
        private void btnUpPage_Click(object sender, EventArgs e)
        {
            int num = int.Parse(lblPageCounts.Text);
            if (num > 1)
            {
                num--;
                int rowcount = 0;
                DataTable dt = bll.GetRTcodesender(mes, rbtEmp.Checked, chkDown.Checked, CodeSendAddress, objName, Convert.ToInt32(cmbSelectCounts.SelectedItem), num, out PageCount, out rowcount);
                dgv.DataSource = dt;
                for (int i = 1; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].ReadOnly = true;
                }
                lblPageCounts.Text = num.ToString();
                lblSumPage.Text = "/" + PageCount.ToString() + "页";
                txtSkipPage.Text = num.ToString();
                lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            }
        }
        #endregion

        #region 【事件方法：跳转页数】
        private void txtSkipPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtSkipPage.Text.Trim().Equals(""))
                {
                    txtSkipPage.Text = "1";
                }

                int num = int.Parse(txtSkipPage.Text);
                if (num >= PageCount)
                {
                    num = PageCount;
                }
                if (num<1)
                {
                    num = 1;
                    txtSkipPage.Text = "1";
                }
                int rowcount = 0;
                DataTable dt = bll.GetRTcodesender(mes, rbtEmp.Checked, chkDown.Checked, CodeSendAddress, objName, Convert.ToInt32(cmbSelectCounts.SelectedItem), num, out PageCount, out rowcount);
                dgv.DataSource = dt;
                for (int i = 1; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].ReadOnly = true;
                }
                lblPageCounts.Text = num.ToString();
                lblSumPage.Text = "/" + PageCount.ToString() + "页";
                txtSkipPage.Text = num.ToString();
                lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
            }
        }
        #endregion

        #region 【事件方法：显示每页显示个数】
        private void cmbSelectCounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = 1;
            int rowcount = 0;
            DataTable dt = bll.GetRTcodesender(mes, rbtEmp.Checked, chkDown.Checked, CodeSendAddress, objName, Convert.ToInt32(cmbSelectCounts.SelectedItem), num, out PageCount, out rowcount);
            dgv.DataSource = dt;
            for (int i = 1; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].ReadOnly = true;
            }
            lblPageCounts.Text = num.ToString();
            lblSumPage.Text = "/" + PageCount.ToString() + "页";
            txtSkipPage.Text = num.ToString();
            lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
        }
        #endregion

        #region 【事件方法：重置查询条件】
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtObj.Text = "";
            //rbtEmp.Checked = true;
            //rbtEqu.Checked = false;
            //chkDown.Checked = false;
            //chkRealTime.Checked = true;
            this.CodeSendAddress = string.Empty;
            this.objName = string.Empty;
            FlashData();
        }
        #endregion

        #region 【事件方法：打印】
        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgv, "实时标识卡", lblCounts.Text.Substring(lblCounts.Text.IndexOf("：")+1));
        }
        #endregion

        #endregion

        #region 【自定义方法】

        #region 【方法：获取部门树信息】
        /// <summary>
        /// 获取部门树信息
        /// </summary>
        private void LoadTree()
        {
            DataTable dt = bll.GetDeptInfo();
            this.trv.TreeDataSource = dt;
        }
        #endregion

        #region 【方法：加载数据】
        /// <summary>
        /// 加载数据
        /// </summary>
        private void FlashData()
        {
            LoadTree();
            int num = int.Parse(lblPageCounts.Text);
            int rowcount = 0;
            GetScealSQL();
            DataTable dt = bll.GetRTcodesender(mes, rbtEmp.Checked, chkDown.Checked, CodeSendAddress, objName, Convert.ToInt32(cmbSelectCounts.SelectedItem), num, out PageCount, out rowcount);
            dgv.DataSource = dt;
            for (int i = 1; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].ReadOnly = true;
            }
            lblPageCounts.Text = num.ToString();
            lblSumPage.Text = "/" + PageCount.ToString() + "页";
            txtSkipPage.Text = num.ToString();
            lblCounts.Text = "共 " + rowcount.ToString() + " 条";
        }
        #endregion

        #region 【方法：获取查询条件】
        /// <summary>
        /// 获取查询条件
        /// </summary>
        private void GetScealSQL()
        {
            mes = "";
            if (trv.ValueList.Count>0)
            {
                for (int i = 0; i < trv.ValueList.Count; i++)
                {
                    if (trv.ValueList[i] == "all")
                        continue;
                    mes = mes + trv.ValueList[i] + ",";
                }
                mes = "where deptid in (" + mes.Remove(mes.Length - 1) + ")";
            }
        }
        #endregion

        #endregion

        #region【事件：DataGridView错误处理】

        private void dgv_Main_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string strErr = e.Exception.Message;
            e.ThrowException = false;
        }

        #endregion

        private void txtObj_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
    }
}
