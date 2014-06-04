using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DegonControlLib;
using KJ128NDBTable;
using KJ128WindowsLibrary;
using Shine.Logs;
using Shine.Logs.LogType;
using KJ128NInterfaceShow;
using KJ128NDataBase;


namespace KJ128NMainRun.StationManage
{
    public partial class A_FrmDirectionalManage : Wilson.Controls.Docking.DockContent
    {

        #region【声明】

        private A_StationBLL sbll = new A_StationBLL();
        private int pSize = 40;

        private DataSet ds;

        private string strStaHead = "";

        /// <summary>
        /// 查询条件
        /// </summary>
        private static string where;

        /// <summary>
        /// 查询到记录的总页数
        /// </summary>
        private int countPage;

        /// <summary>
        /// 记录本页的条数
        /// </summary>
        int intSize;

        private bool blIsBegin = true;

        /// <summary>
        /// 保存要修改的方向性ID，-1：新增
        /// </summary>
        public int tempCodeSenderDirlID = -1;

        /// <summary>
        /// 是否是查看信息
        /// </summary>
        public bool blIsSee = false;

        /// <summary>
        /// 热备当前刷新次数
        /// </summary>
        private int intRefReshCount = 0;

        /// <summary>
        /// 热备刷新最大次数
        /// </summary>
        private int intHostBackRefCount = 2;

        #endregion

        #region【构造函数】

        public A_FrmDirectionalManage()
        {
            InitializeComponent();

            intHostBackRefCount = RefReshTime.intHostBackRefCount;
            timer_Refresh.Interval = RefReshTime.intHostBackRefTime;

            dmc_Info.Add(pl_Directional, true);
            dmc_Info.LeftPartResize();

            cmb_SelectCounts.Text = "40";
        }

        #endregion



        #region【窗体加载】

        private void A_FrmDirectionalManage_Load(object sender, EventArgs e)
        {
            LoadTreeView_StaHead(tvc_BeginStaHead_Select, true);
            LoadTreeView_StaHead(tvc_EndStaHead_Select, true);
            this.AcceptButton = bt_Enquiries;
        }

        #endregion

        #region【方法：刷新——方向性】

        public void Refresh_Directional()
        {
            //LoadTreeView_StaHead(tvc_BeginStaHead_Select, true);
            //LoadTreeView_StaHead(tvc_EndStaHead_Select, true);

            //bt_Enquiries_Click(null, null);
            SelectInfo(Convert.ToInt32(lblPageCounts.Text));
        }

        #endregion

        #region 【方法：初始化探头树】

        /// <summary>
        /// 自定义树的表的行结构
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="parentid"></param>
        /// <param name="isChild"></param>
        /// <param name="isUserNum"></param>
        /// <param name="num"></param>
        private void SetDataRow(ref DataRow dr, string id, string name, string parentid, bool isChild, bool isUserNum, int num)
        {
            dr[0] = id;
            dr[1] = name;
            dr[2] = parentid;
            dr[3] = isChild;
            dr[4] = isUserNum;
            dr[5] = num;
        }

        /// <summary>
        /// 初始化部门树
        /// </summary>
        private void LoadTreeView_StaHead(TreeViewControl tvc,bool blIsAll)
        {
            if (tvc.Nodes.Count > 0)
            {
                tvc.Nodes.Clear();
            }
            DataTable dt;
            using (ds = new DataSet())
            {
                if (blIsAll)    //主节点是“所有”
                {
                    ds = sbll.GetStaHeadInfo();
                }
                else            //无主节点
                {
                    ds = sbll.GetStaHeadInfo_Binding();
                }

                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {
                    dt = tvc.BuildMenusEntity();
                }

                if (blIsAll)
                {
                    DataRow dr = dt.NewRow();
                    SetDataRow(ref dr,"0", "所有","-1", false, false, 0);
                    dt.Rows.Add(dr);
                }

                tvc.DataSouce = dt;
                tvc.LoadNode("人");
            }

            tvc.ExpandAll();
            if (blIsAll)
            {
                tvc.SelectedNode = tvc.Nodes[0];
                tvc.SetSelectNodeColor();
               // tvc.Focus();
            }
        }

        #endregion

        #region 【方法: 查询信息】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere()
        {
            string strSQL;

            strSQL = " 1=1 ";

            if (strStaHead!="")
            {
                strSQL += strStaHead;
            }

            if (!txt_Description_Select.Text.Trim().Equals(""))
            {
                strSQL += " And 描述 like '%" + txt_Description_Select.Text.Trim() + "%' ";
            }

            return strSQL;
        }

         /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pIndex">所有查询的页数</param>
        public void SelectInfo(int pIndex)
        {
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }


            DataSet ds = sbll.GetDirectionalInfo(pIndex, pSize, where);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                ds.Tables[0].TableName = "A_FrmDirectionalManager";
                if (sumPage == 0)
                {
                    
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 0 个方向性信息";

                    lblPageCounts.Text = "1";
                    lblSumPage.Text = "/1页";

                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 个方向性信息";

                    lblPageCounts.Text = pIndex.ToString();
                    lblSumPage.Text = "/" + sumPage + "页";

                    //控制翻页状态
                    SetPageEnable(pIndex, sumPage);
                }

                if (dgv_Main.Columns.Count >= 9)
                {
                    dgv_Main.Columns["CodeSenderDirlID"].Visible = false;

                    //dgv_Main.Columns["cl"].DisplayIndex = 0;
                    //dgv_Main.Columns["clBeginStationAddress"].DisplayIndex = 1;
                    //dgv_Main.Columns["clBeginStationHeadAddress"].DisplayIndex = 2;
                    //dgv_Main.Columns["clBeginPlace"].DisplayIndex = 3;
                    //dgv_Main.Columns["clEndStationAddress"].DisplayIndex = 4;
                    //dgv_Main.Columns["clEndStationHeadAddress"].DisplayIndex = 5;
                    //dgv_Main.Columns["clEndPlace"].DisplayIndex = 6;
                    //dgv_Main.Columns["clDirectional"].DisplayIndex = 7;
                }

                if (btnSelectAll.Text.Equals("取消"))
                {
                    btnSelectAll.Text = "全选";
                }
           
            }
        }

        #endregion

        #region【方法：热备刷新】

        /// <summary>
        /// 热备刷新
        /// </summary>
        /// <param name="bl">true:开启刷新;false:终止刷新</param>
        public void HostBackRefresh(bool bl)
        {
            if (bl)
            {
                if (timer_Refresh.Enabled)
                {
                    timer_Refresh.Enabled = false;
                }
                intRefReshCount = 0;
                timer_Refresh.Enabled = true;
            }
            else
            {
                intRefReshCount = 0;
                timer_Refresh.Enabled = false;
            }
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


        #region【事件：探头树点击事件——查询】

        //起始探头树
        private void tvc_BeginStaHead_Select_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (e.Node != null && e.Node.Name != "0")
            {
                if (e.Node.Parent.Name.Equals("0"))
                {
                    strStaHead = " And 起始传输分站 = " + e.Node.Name.Substring(1);
                }
                else
                {
                    strStaHead = " And 起始传输分站 = " + e.Node.Parent.Name.Substring(1) + " And 起始读卡分站 = " + e.Node.Name.Substring(1);
                }
            }
            else
            {
                strStaHead = "";
            }
            where = StrWhere();
            SelectInfo(1);
        }

        //终止探头树
        private void tvc_EndStaHead_Select_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Name != "0")
            {
                if (e.Node.Parent.Name.Equals("0"))
                {
                    strStaHead = " And 终止传输分站 = " + e.Node.Name.Substring(1);
                }
                else
                {
                    strStaHead = " And 终止传输分站 = " + e.Node.Parent.Name.Substring(1) + " And 终止读卡分站 = " + e.Node.Name.Substring(1);
                }
            }
            else
            {
                strStaHead = "";
            }
            where = StrWhere();
            SelectInfo(1);
        }

        #endregion

        #region【事件：查询】

        private void bt_Enquiries_Click(object sender, EventArgs e)
        {
            where = StrWhere();
            SelectInfo(1);
        }

        #endregion

        #region【事件：重置——查询】

        private void bt_Reset_Click(object sender, EventArgs e)
        {
            tbc_Info.SelectedTab = tp_StaHead_Begin;
            strStaHead = "";
            tvc_BeginStaHead_Select.SelectedNode = tvc_BeginStaHead_Select.Nodes[0];
            tvc_BeginStaHead_Select.SetSelectNodeColor();
            txt_Description_Select.Text = "";
        }

        #endregion

        #region【事件：起始分站、终止分站选择——选项卡切换事件】

        private void tbc_Info_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage != null)
            {
                if (e.TabPage.Name == "tp_StaHead_Begin")      //起始分站
                {
                    if (!blIsBegin)
                    {
                        //tvc_BeginStaHead_Select.SelectedNode = tvc_BeginStaHead_Select.Nodes[0];
                        //tvc_BeginStaHead_Select.SetSelectNodeColor();
                        LoadTreeView_StaHead(tvc_BeginStaHead_Select, true);
                        strStaHead = "";
                        blIsBegin = true;
                    }
                }
                else if (e.TabPage.Name == "tp_StaHead_End")   //终止分站
                {
                    if (blIsBegin)
                    {
                        //tvc_EndStaHead_Select.SelectedNode = tvc_EndStaHead_Select.Nodes[0];
                        //tvc_EndStaHead_Select.SetSelectNodeColor();
                        LoadTreeView_StaHead(tvc_EndStaHead_Select, true);
                        strStaHead = "";
                        blIsBegin = false;
                    }
                }
            }
        }

        #endregion


        #region 【事件: 上一页 单击事件 Click】

        private void bt_UpPage_Click(object sender, EventArgs e)
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

        #region 【事件: 下一页 单击事件 Click】
        private void bt_DownPage_Click(object sender, EventArgs e)
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

        private void txt_SkipPage_KeyDown(object sender, KeyEventArgs e)
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
                    else if (int.Parse(value) >= 0)
                    {
                        int page = int.Parse(value);
                        if (page == 0)
                        {
                            page = 1;
                        }
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

        #region【事件：选择每页显示行数】

        private void cmb_SelectCounts_DropDownClosed(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cmb_SelectCounts.SelectedItem);
            SelectInfo(1);
        }

        #endregion

        #region【事件：单元格单击事件】

        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgv_Main.Columns[e.ColumnIndex].Name.Equals("cl"))
                {
                    if (dgv_Main.Rows[e.RowIndex].Cells["cl"].Value != null && dgv_Main.Rows[e.RowIndex].Cells["cl"].Value.ToString().Equals("1"))
                    {
                        dgv_Main.Rows[e.RowIndex].Cells["cl"].Value = 0;

                        if (btnSelectAll.Text.Equals("取消"))
                        {
                            btnSelectAll.Text = "全选";
                        }
                    }
                    else
                    {
                        dgv_Main.Rows[e.RowIndex].Cells["cl"].Value = 1;
                    }
                }
            }
        }

        #endregion


        #region【事件：新增】

        private void bt_Add_Click(object sender, EventArgs e)
        {
            tempCodeSenderDirlID = -1;
            A_FrmDirectionalManage_Add frmDma = new A_FrmDirectionalManage_Add(this);
            frmDma.ShowDialog();
        }

        #endregion

        #region【事件：全部选择】

        private void bt_SelectAll_Click(object sender, EventArgs e)
        {
            if (btnSelectAll.Text.Equals("全选"))
            {
                foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                {
                    dgvr.Cells["cl"].Value = 1;
                }
                btnSelectAll.Text = "取消";
            }
            else
            {
                foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                {
                    dgvr.Cells["cl"].Value = 0;
                }
                btnSelectAll.Text = "全选";
            }
        }

        #endregion

        #region【事件：修改】

        private void bt_Laws_Click(object sender, EventArgs e)
        {
            int i = 0;

            int intUpDateID = -1;

            try
            {
                foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                {
                    if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                    {
                        intUpDateID = Convert.ToInt32(dgvr.Cells["CodeSenderDirlID"].Value.ToString());
                        i += 1;
                    }
                }
            }
            catch
            {
                intUpDateID = -1;
                i = 0;
            }
            if (i == 0)
            {
                MessageBox.Show("请选择要修改的方向性", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (i > 1)
            {
                MessageBox.Show("所选方向性不能大于1个，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                tempCodeSenderDirlID = intUpDateID;

                A_FrmDirectionalManage_Add frmDma = new A_FrmDirectionalManage_Add(this);
                frmDma.ShowDialog();
            }

        }

        #endregion

        #region【事件：删除】

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            int intDeleteCount = 0;
            string strDeleteID = "";
            string strDeleteName = "";
            DialogResult result;

            foreach (DataGridViewRow dgvr in dgv_Main.Rows)
            {
                if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                {
                    intDeleteCount += 1;

                    if (strDeleteName == "")
                    {
                        strDeleteID = " CodeSenderDirlID = " + dgvr.Cells["CodeSenderDirlID"].Value.ToString();

                        strDeleteName = dgvr.Cells["CodeSenderDirlID"].Value.ToString();
                    }
                    else
                    {
                        strDeleteID += " Or CodeSenderDirlID = " + dgvr.Cells["CodeSenderDirlID"].Value.ToString();
                        strDeleteName += "，" + dgvr.Cells["CodeSenderDirlID"].Value.ToString();
                    }
                }
            }

            if (intDeleteCount == 0)
            {
                MessageBox.Show("请选择要删除的方向性！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            result = MessageBox.Show("是否要删除选中的方向性？", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                sbll.DeleteDirectional(strDeleteID);

                dgv_Main.ClearSelection();

                //存入日志
                LogSave.Messages("[A_FrmDirectionalManage]", LogIDType.UserLogID, "删除方向性信息，方向性描述为：" + strDeleteName);

                if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                {
                    Refresh_Directional();
                }
                else                                //热备版，启用定时器
                {
                    HostBackRefresh(true);
                }

            }

        }

        #endregion

       

        #region【事件：双击单元格（查看具体信息）】

        private void dgv_Main_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                blIsSee = true;

                tempCodeSenderDirlID = int.Parse(dgv_Main.Rows[e.RowIndex].Cells["CodeSenderDirlID"].Value.ToString());
                A_FrmDirectionalManage_Add frmDma = new A_FrmDirectionalManage_Add(this);
                frmDma.ShowDialog();

                blIsSee = false;
            }
        }

        #endregion

        #region【事件：热备刷新】

        private void timer_Refresh_Tick(object sender, EventArgs e)
        {
            if (intRefReshCount >= intHostBackRefCount)
            {
                intRefReshCount = 0;
                timer_Refresh.Enabled = false;
            }
            else
            {
                intRefReshCount = intRefReshCount + 1;
                Refresh_Directional();
                //SelectInfo(Convert.ToInt32(lb_PageCounts.Text));
            }
        }

        #endregion

        #region【事件：DataGridView错误处理】

        private void dgv_Main_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string strErr = e.Exception.Message;
            e.ThrowException = false;
        }

        #endregion

        private void dgv_Main_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (dgv_Main.Columns.Count > 0)
                {
                    for (int i = 0; i < dgv_Main.Columns.Count; i++)
                    {
                        dgv_Main.Columns[i].DefaultCellStyle.NullValue = "——";
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void A_FrmDirectionalManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigXmlWiter.Write("Directional.xml");
        }

        private void dgv_Main_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private IButtonControl IB = null;
        private void txtSkipPage_Enter(object sender, EventArgs e)
        {
            this.IB = this.AcceptButton;
            this.AcceptButton = null;
        }

        private void txtSkipPage_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = IB;
        }

        private void txt_Description_Select_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        #region【事件：打印 导出】
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgv_Main, "方向性信息");
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgv_Main, "方向性信息", "");
        }
       

        private void bt_Print_Click(object sender, EventArgs e)
        {
            //PrintBLL.Print(dgv_Main, "员工信息","共37人");
            KJ128NDBTable.PrintBLL.Print(dgv_Main, "方向性信息", lblCounts.Text);
        }

        #endregion
    }
}
