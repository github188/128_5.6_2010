using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using System.Collections;
using System.Web.UI.WebControls;
using KJ128NDataBase;

namespace KJ128NMainRun
{
    public partial class SpecialWorkTypeTerrialSet : Wilson.Controls.Docking.DockContent
    {

        #region 私有变量

        DeptBLL dBLL = new DeptBLL();
        AreaBLL ABLL = new AreaBLL();
        SpecialWorkTypeTerrialSetBLL swtsBLL = new SpecialWorkTypeTerrialSetBLL();
        string strErr = string.Empty;
        int intTerrialAlarmID = 0;
        static int intPageIndex = 1;
        static int intPageCountShow = 0;//页索引
        

        #endregion

        public SpecialWorkTypeTerrialSet()//总页数
        {
            InitializeComponent();
        }

        #region 窗体加载事件
        private void SpecialWorkTypeTerrialSet_Load(object sender, EventArgs e)
        {
            lblErr.Text = "";
            BindComboBox();
            if (ddlWorkTypeAdd.SelectedValue.ToString() == "0")
            {
                chkAllAlarm.Enabled = false;
            }
            else
            {
                chkAllAlarm.Enabled = true;

            }
            if (ddlEmployeeNameAdd.SelectedValue.ToString() == "0")
            {
                chkEmployeeAlarm.Enabled = false;
            }
            else
            {
                chkEmployeeAlarm.Enabled = true;
            }

            IsShowAddOrModifyPanel(false);

            this.BindRowsSet();

            BindDataGridView();
        }
        #endregion

        #region 绑定下拉列表
        void BindComboBox()
        {
            
            ABLL.GetTerTypeCmb1(ddlAreaTypeStation);
            swtsBLL.Query_TerrialInfo(ddlAreaNameStation, int.Parse(ddlAreaTypeStation.SelectedValue.ToString()), 1, out strErr);
            swtsBLL.Query_TerrialType(ddlAreaTypeAdd, out strErr);
            swtsBLL.Query_TerrialInfo(ddlAreaNameAdd, int.Parse(ddlAreaTypeAdd.SelectedValue.ToString()), 2,out strErr);
            swtsBLL.Querey_WorkType(ddlWorkTypeAdd,2, out strErr);
            swtsBLL.Querey_WorkType(ddlWorkTypeStation, 1, out strErr);
            swtsBLL.Query_Employee_ByWorkType(ddlEmployeeNameAdd, int.Parse(ddlWorkTypeAdd.SelectedValue.ToString()), out strErr);
            ddlPageSize.SelectedText = "100";

        }
        #endregion

        #region 查询时区域类别下拉列表内容改变事件
        private void ddlAreaTypeStation_SelectionChangeCommitted(object sender, EventArgs e)
        {

            swtsBLL.Query_TerrialInfo(ddlAreaNameStation, int.Parse(ddlAreaTypeStation.SelectedValue.ToString()), 1, out strErr);
        }
        #endregion

        #region 添加/修改时区域类别下拉列表内容改变事件
        private void ddlAreaTypeAdd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblErr.Text = "";
            swtsBLL.Query_TerrialInfo(ddlAreaNameAdd, int.Parse(ddlAreaTypeAdd.SelectedValue.ToString()), 2, out strErr);
        }
        #endregion

        #region 添加/修改时工种下拉列表内容的修改事件
        private void ddlWorkTypeAdd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblErr.Text = "";
            swtsBLL.Query_Employee_ByWorkType(ddlEmployeeNameAdd, int.Parse(ddlWorkTypeAdd.SelectedValue.ToString()), out strErr);

            if (ddlEmployeeNameAdd.SelectedValue.ToString() == "0")
            {
                this.chkEmployeeAlarm.Checked = false;
                chkEmployeeAlarm.Enabled = false;
            }
            else
            {
                chkEmployeeAlarm.Enabled = true;
            }

            

        }
        #endregion

        #region 全部工种都报警复选框的单击事件
        private void chkAllAlarm_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllAlarm.Checked)
            {
                chkEmployeeAlarm.Enabled = false;
                ddlEmployeeNameAdd.Enabled = false;
            }
            else
            {
                chkEmployeeAlarm.Enabled = true;
                ddlEmployeeNameAdd.Enabled = true;
            }
        }
        #endregion

        #region 员工是否报警复选框的单击事件
        private void chkEmployeeAlarm_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEmployeeAlarm.Checked)
            {
                chkAllAlarm.Checked = false;
                chkAllAlarm.Enabled = false;
            }
            else
            {
                chkAllAlarm.Enabled = true;
            }
        }
        #endregion

        #region 添加/修改员工的单击事件
        private void btnAddOrModify_Click(object sender, EventArgs e)
        {

            string strWhere = string.Empty;
            if (ddlAreaNameAdd.Text == "无")
            {
                MessageBox.Show("无区域名称可选，请先添加区域名称!","提示");
                return;
            }

            lblErr.Text = "";
            bool Flag = false;
            int intEmployeeID = 0;
            int intAreaID = int.Parse(ddlAreaNameAdd.SelectedValue.ToString());
            int intWorkTypeID = int.Parse(ddlWorkTypeAdd.SelectedValue.ToString());
            int intAreaTypeID = int.Parse(ddlAreaTypeAdd.SelectedValue.ToString());
            string strRemark = txtRemark.Text;
            if (chkAllAlarm.Checked)
            {
                strWhere = " and WorkTypeID=" + intWorkTypeID.ToString();
            }
            else
            {
                strWhere = " and TerriAlarmID="+intTerrialAlarmID.ToString();
            }

            if (chkAllAlarm.Checked || chkEmployeeAlarm.Checked)
            {
                Flag = true;
            }
            if (btnAddOrModify.CaptionTitle == " 添 加")
            {

                if (ddlEmployeeNameAdd.SelectedValue.ToString() == "0")
                {
                    lblErr.ForeColor = Color.Red;
                    lblErr.Text = "没有员工可以添加！";
                    return;
                }

                if (chkAllAlarm.Checked || chkEmployeeAlarm.Checked)
                {
                    Flag = true;
                }

                

                if (chkAllAlarm.Checked)
                {
                    for (int i = 0; i < ddlEmployeeNameAdd.Items.Count; i++)
                    {
                        intEmployeeID = int.Parse(((DataRowView)(ddlEmployeeNameAdd.Items[i])).Row[0].ToString());
                        swtsBLL.Insert_SpecialWorkTypeTerrialSet(intEmployeeID, intAreaID, intWorkTypeID, Flag, strRemark, out strErr);
                        if (strErr == "Succeeds")
                        {
                            lblErr.ForeColor = Color.Blue;
                            lblErr.Text = "添加成功!";
                            //timer1.Start();
                        }
                    }

                }
                else
                {
                    intEmployeeID = int.Parse(ddlEmployeeNameAdd.SelectedValue.ToString());
                    swtsBLL.Insert_SpecialWorkTypeTerrialSet(intEmployeeID, intAreaID, intWorkTypeID, Flag, strRemark, out strErr);
                    if (strErr == "Succeeds")
                    {
                        lblErr.ForeColor = Color.Blue;
                        lblErr.Text = "添加成功!";
                        //timer1.Start();
                    }
                }
            }
            else
            {
                if (ddlEmployeeNameAdd.SelectedValue.ToString() == "0")
                {
                    lblErr.ForeColor = Color.Red;
                    lblErr.Text = "没有员工可以添加！";
                    return;
                }

                intEmployeeID = int.Parse(ddlEmployeeNameAdd.SelectedValue.ToString());

                swtsBLL.Update_SpecialWorkTypeTerrialSet(intTerrialAlarmID, intEmployeeID, intAreaID, intWorkTypeID, Flag, strRemark,strWhere, out strErr);
                if (strErr == "Succeeds")
                {
                    lblErr.ForeColor = Color.Blue;
                    lblErr.Text = "修改成功!";
                    //timer1.Start();
                }

            }

            if (!New_DBAcess.IsDouble)
            {

                BindDataGridView();
            }
            else
            {
                timer2.Start();
            }

            timer1.Start();
        }
        #endregion

        #region 显示隐藏添加/修改面板
        public void IsShowAddOrModifyPanel(bool bFlag)
        {
            if (bFlag)
            {
               
                GB.Visible = true;
                lblErr.Visible = true;
                btnAddOrModify.Visible = true;
                btnReturn.Visible = true;
                PanelModify.Visible = true;
            }
            else
            {
                PanelModify.Visible = false;
                GB.Visible = false;
                lblErr.Visible = false;
                btnAddOrModify.Visible = false;
                btnReturn.Visible = false;
            }
        }
        #endregion

        #region 添加按钮的单击事件
        private void btnAddMain_Click(object sender, EventArgs e)
        {
            IsShowAddOrModifyPanel(true);
            btnAddOrModify.CaptionTitle = " 添 加";
            PanelModify.CaptionTitle = "添加特殊工种进出区域信息";
            lblErr.Text = "";
        }
        #endregion

        #region 得到返回的条件
        public string GetWhere()
        {
            string strWhere = string.Empty;
            if(ddlAreaTypeStation.SelectedValue.ToString() != "0")
            {
                strWhere += " and TerritorialTypeID="+ddlAreaTypeStation.SelectedValue.ToString();
            }
            if (ddlAreaNameStation.SelectedValue.ToString() != "0")
            {
                strWhere += " and TerritorialID=" + ddlAreaNameStation.SelectedValue.ToString();
            }

            if (ddlWorkTypeStation.SelectedValue.ToString() != "0")
            {
                strWhere += " and WorkTypeID="+ddlWorkTypeStation.SelectedValue.ToString();
            }

            if (TxtEmployeeNameStation.Text.Trim() != "")
            {
                strWhere += " and EmpName like '%"+TxtEmployeeNameStation.Text+"%'";
            }

            if (txtBlockIDStation.Text.Trim() != "")
            {
                strWhere += " and CodeSenderAddress="+txtBlockIDStation.Text;
            }

            return strWhere;
        }
        #endregion

        #region 绑定DataGridView
        public void BindDataGridView()
        {
            if (txtBlockIDStation.Text != "")
            {
                try
                {
                    int.Parse(txtBlockIDStation.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("标识卡编号只能为数字！");
                    return;
                }
            }
            int intPageSizedll = int.Parse(ddlPageSize.SelectedValue.ToString().ToString());
            
            DataSet ds = swtsBLL.Query_SpecialWorkTypeTerrialSet(intPageIndex, intPageSizedll, GetWhere(), out strErr);
            if (ds != null)
            {

                dgrd.DataSource = ds.Tables[0];

                if (ds.Tables[0] != null)
                {
                    dgrd.Columns[3].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);
                    dgrd.Columns[2].Visible = false;
                    dgrd.Columns[0].DisplayIndex = 8;
                    dgrd.Columns[1].DisplayIndex = 8;

                }
                int intPageSum = int.Parse(ds.Tables[1].Rows[0][0].ToString());

                if (intPageSum % intPageSizedll == 0)
                {
                    intPageCountShow = intPageSum / intPageSizedll;
                }
                else
                {
                    intPageCountShow = intPageSum / intPageSizedll + 1;
                }

                if (intPageCountShow == 0)
                {
                    intPageCountShow = 1;
                }
                PanelPageIndex.CaptionTitle = "第" + intPageIndex.ToString() + "页";
                PanelPageCount.CaptionTitle = "共" + intPageCountShow.ToString() + "页";

                PanelRowsCount.CaptionTitle = "共" + intPageSum.ToString() + "条";
            }
           
        }
        #endregion

        #region [ 方法: 绑定多少行 ]

        void BindRowsSet()
        {
            ArrayList al = new ArrayList();
            for (int i = 1; i <= 10; i++)
            {
                int j = i * 100;

                al.Add(new ListItem(j.ToString(), "每页显示" + j.ToString() + "行"));
            }
            this.ddlPageSize.DataSource = al;
            ddlPageSize.DisplayMember = "Name";
            
        }

        #endregion

        #region 查询按钮的单击事件
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (txtBlockIDStation.Text != "")
            {
                try
                {
                    int.Parse(txtBlockIDStation.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("标识卡编号只能为数字！");
                    return;
                }
            }
            BindDataGridView();
            lblErr.Text = "";
        }
        #endregion

        #region 重置按钮的单击事件
        private void btnReset_Click(object sender, EventArgs e)
        {
            TxtEmployeeNameStation.Text = "";
            txtBlockIDStation.Text = "";
            lblErr.Text = "";
        }
        #endregion

        #region 返回按钮的单击事件
        private void btnReturn_Click(object sender, EventArgs e)
        {
            IsShowAddOrModifyPanel(false);
            BindDataGridView();
            lblErr.Text = "";
        }
        #endregion

        #region 首页的单击事件
        private void btnFirst_Click(object sender, EventArgs e)
        {
            intPageIndex = 1;
            BindDataGridView();
            lblErr.Text = "";
        }
        #endregion

        #region 上一页的单击事件
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (intPageIndex > 1)
            {
                intPageIndex--;
                BindDataGridView();
            }
            lblErr.Text = "";
        }
        #endregion

        #region 下一页的单击事件
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (intPageIndex < intPageCountShow)
            {
                intPageIndex++;
                BindDataGridView();
            }
            lblErr.Text = "";
        }
        #endregion

        #region 尾页的单击事件
        private void btnLast_Click(object sender, EventArgs e)
        {
            intPageIndex = intPageCountShow;

            BindDataGridView();
            lblErr.Text = "";
        }
        #endregion

        #region 页面大小选择变化事件
        private void ddlPageSize_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            intPageIndex = 1;
            BindDataGridView();
            lblErr.Text = "";
        }
        #endregion

        #region 跳转按钮的单击事件
        private void btnJump_Click(object sender, EventArgs e)
        {

            //PanelPageCount

            if (txtPageIndex.Text.Trim() == "" || txtPageIndex.Text.Trim() == "0")
            {
                MessageBox.Show("跳转页数不能为空或零！");
                return;
            }
            try
            {
                int.Parse(txtPageIndex.Text);
            }
            catch
            {
                MessageBox.Show("跳转页数只能为数字！");
                return;
            }


            if (Convert.ToInt32(txtPageIndex.Text) < 0 || txtPageIndex.Text.StartsWith("-"))
            {
                MessageBox.Show("跳转页数只能为正整数！");
                return;
            }


            if (Convert.ToInt32(txtPageIndex.Text) > intPageCountShow)
            {
                MessageBox.Show("跳转页数不能大于总页数！");
                return;
            }
            

            if (int.Parse(txtPageIndex.Text.Trim()) > intPageCountShow)
            {
                intPageIndex = intPageCountShow;
            }
            else
            {
                intPageIndex = int.Parse(txtPageIndex.Text.Trim());
            }

            BindDataGridView();
            lblErr.Text = "";
        }
        #endregion

        #region dgrd单元格的单击事件
        private void dgrd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblErr.Text = "";
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                intTerrialAlarmID = int.Parse(dgrd.Rows[e.RowIndex].Cells[2].Value.ToString());

                ddlWorkTypeAdd.Text = dgrd.Rows[e.RowIndex].Cells[5].Value.ToString();
                swtsBLL.Query_Employee_ByWorkType(ddlEmployeeNameAdd, int.Parse(ddlWorkTypeAdd.SelectedValue.ToString()), out strErr);
                ddlEmployeeNameAdd.Text = dgrd.Rows[e.RowIndex].Cells[4].Value.ToString();

                ddlAreaTypeAdd.Text = dgrd.Rows[e.RowIndex].Cells[7].Value.ToString();
                swtsBLL.Query_TerrialInfo(ddlAreaNameAdd, int.Parse(ddlAreaTypeAdd.SelectedValue.ToString()), 2, out strErr);
                ddlAreaNameAdd.Text = dgrd.Rows[e.RowIndex].Cells[6].Value.ToString();
               

                if (dgrd.Rows[e.RowIndex].Cells[8].Value.ToString() == "True")
                {
                    this.chkEmployeeAlarm.Checked = true;
                }
                else
                {
                    this.chkEmployeeAlarm.Checked = false;
                }

                
                IsShowAddOrModifyPanel(true);
                btnAddOrModify.CaptionTitle = " 修 改";

                PanelModify.CaptionTitle = "修改特殊工种进出区域信息";
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                if (MessageBox.Show("你确定要删除吗？","提示",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    swtsBLL.Delete_SpecialWorkTypeTerrialSet(int.Parse(dgrd.Rows[e.RowIndex].Cells[2].Value.ToString()), out strErr);
                    if (strErr == "Succeeds")
                    {
                        lblErr.ForeColor = Color.Blue;
                        lblErr.Text = "删除成功了!";

                        if (!New_DBAcess.IsDouble)
                        {
                            BindDataGridView();
                        }
                        else
                        {
                            timer2.Start();
                        }
                    }
                    
                }
            }

            lblErr.Text = "";
        }
        #endregion

        #region 时钟

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblErr.Text = "";
            timer1.Stop();
        }

        #endregion

        #region [热备定时刷新]

        /// <summary>
        /// 最大刷新次数
        /// </summary>
        private int maxTimes = 2;

        /// <summary>
        /// 查询刷新次数
        /// </summary>
        private int times = 0;

        /// <summary>
        /// 1表示 增加，修改 2 表示删除 
        /// </summary>
        //private int operated = 1;

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (times < maxTimes)
            {
                times++;

                //刷新
                BindDataGridView();

                this.timer2.Stop();
                this.timer2.Start();
            }
            else
            {
                times = 0;
                timer2.Stop();
            }
        }

        #endregion

        private void bcpRef_Click(object sender, EventArgs e)
        {
            BindDataGridView();
        }
    }
}