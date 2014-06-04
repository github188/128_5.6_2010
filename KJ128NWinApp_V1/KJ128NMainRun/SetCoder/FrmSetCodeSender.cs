using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDataBase;
using KJ128WindowsLibrary;
using System.Data.SqlClient;
using KJ128NDBTable;
using System.IO;
using Shine.Logs;
using Shine.Logs.LogType;

namespace KJ128NInterfaceShow
{
    /// <summary>
    /// 设置发码器


    /// </summary>
    public partial class FrmSetCodeSender : Wilson.Controls.Docking.DockContent
    {
        private CodeSenderBLL csbll = new CodeSenderBLL();
        private RealTimeBLL rtbll = new RealTimeBLL();
        private int pSize = 100;
        private string deptID = "1=1";

        //拖动
        private static Point point = new Point();
        private static bool isDrag = false;

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数

        /// </summary>
        public FrmSetCodeSender()
        {
            InitializeComponent();
            panelCodeSenderSet.Visible = false;
            vspAddNewCodeSenderPanel.Visible = false;
            Init();
            lblErrInfo.Text = "";
            bcpResult.CaptionTitle = "";
        }

        #endregion

        #region [ 私有变量 ]
        /// <summary>
        /// 发码器信息表
        /// </summary>
        DataTable dtCodeSender_Info;
        /// <summary>
        /// 发码器配置表
        /// </summary>
        DataTable dtCodeSenderSet;
        /// <summary>
        /// 员工信息
        /// </summary>
        DataTable dtEmployeeMent;
        /// <summary>
        /// 未使用的发码器信息表
        /// </summary>
        DataTable dtCodeSenderNoUser;
        #region 添加新的发码器面板


        /*
        /// <summary>
        /// 添加发码器信息的面板
        /// </summary>
        VSPanel vspAddNewCodeSenderPanel = new VSPanel();
        /// <summary>
        /// 添加发码器信息的标题栏


        /// </summary>
        ButtonCaptionPanel bcpAddNewCodeSenderTitle = new ButtonCaptionPanel();
        /// <summary>
        /// 发码器地址标签
        /// </summary>
        Label lbl_AddNewCodeSenderAddress = new Label();
        /// <summary>
        /// 发码器状态


        /// </summary>
        Label lbl_AddNewCodeSenderState=new Label();
        /// <summary>
        /// 发码器地址输入框


        /// </summary>
        TextBox txt_AddNewCodeSenderAddress = new TextBox();
        /// <summary>
        /// 发码器状态枚举


        /// </summary>
        ComboBox comboBox_AddNewCodeSenderState = new ComboBox();
        /// <summary>
        /// 是否批量添加
        /// </summary>
        CheckBox chk_IsBathAddNewCodeSender = new CheckBox();
        /// <summary>
        /// 存储并新增


        /// </summary>
        LinkLabel linkLabel_SaveAddNewCodeSender = new LinkLabel();
        /// <summary>
        /// 修改并关闭


        /// </summary>
        LinkLabel linkLabel_ModifyCodeSenderClose = new LinkLabel();
         */
        #endregion
        
        #endregion

        #region [ 方法: 处理空数据页数显示 ]

        // 处理空数据页数显示

        private void pageControlsVisible(bool bl)
        {
            cpUp.Visible = bl;
            cpDown.Visible = bl;
            txtPage.Visible = bl;
            lblSumPage.Visible = bl;
            txtCheckPage.Visible = bl;
            cpCheckPage.Visible = bl;
            //bcpPageSum.Visible = bl;
        }

        private void cpageControlsVisible(bool bl)
        {
            cpUpc.Visible = bl;
            cpDownc.Visible = bl;
            txtPagec.Visible = bl;
            lblSumPagec.Visible = bl;
            txtCheckPagec.Visible = bl;
            cpCheckPagec.Visible = bl;
            //bcpPageSumc.Visible = bl;
            
        }

        #endregion

        #region [ 方法: 初始化 ]

        private void Init()
        {
            BindDept();
            BindType();
            LoadInfo();
            LoadCodeSenderInfo();
            LoadCodeSenderConfig();
            cmb_Size.SelectedIndex = 3;         //每页显示行数为100
        }

        #endregion

        #region [ 方法: 加载类型cmb ]

        public void BindType()
        {
            EnumBLL dbll = new EnumBLL();
            DataSet ds = dbll.GetEnumList("3");
            DataRow dr = ds.Tables[0].NewRow();
            dr["EnumID"] = 0;
            dr["Title"] = "所有";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmbConfigType.DataSource = ds.Tables[0];
                cmbConfigType.DisplayMember = "Title";
                cmbConfigType.ValueMember = "EnumID";
            }
            cmbConfigType.Text = "所有";
        }

        #endregion

        #region [ 方法: 加载部门cmb ]

        public void BindDept()
        { 
            DeptBLL dbll = new DeptBLL();
            DataSet ds = dbll.GetDeptInfo();
            DataRow dr = ds.Tables[0].NewRow();
            dr["DeptID"] = 0;
            dr["DeptName"] = "所有";
            ds.Tables[0].Rows.InsertAt(dr,0);
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmbDeptList.DataSource = ds.Tables[0];
                cmbDeptList.DisplayMember = "DeptName";
                cmbDeptList.ValueMember = "DeptID";
            }
            cmbDeptList.Text = "所有";
        }

        #endregion

        #region [ 方法: 加载初始化信息 ]
        // 加载部门树信息

        private void LoadDept()
        {
            tvDepartMent.Nodes.Clear();
            DataTable dt = rtbll.getDeptInfo();
            tvDepartMent.ReadDept_Info(dt);
        }

        // 初始化发码器配置信息
        private void LoadCodeSenderConfig()
        {
            getInfoc(1);
        }

        // 初始化发码器信息
        private void LoadCodeSenderInfo()
        {
            getInfo(1);
        }

        // 加载选择信息
        private void LoadInfo()
        {
            csbll.bindCmbCodeSenderState(cmdAddCodeSenderState);        // 加载发码器状态


            cmdAddCodeSenderState.SelectedIndex = cmdAddCodeSenderState.FindString("正常");
            // 初始化单个添加发码器
            lblAddNewCodeSenderLine.Visible = false;
            txtAddCodeSenderAddressMax.Visible = false;
            txtAddCodeSenderAddressMin.Width = 140;
        }

        #endregion

        #region [ 方法: 分页处理 ]
        // 获取发码器查询条件

        private string GetStrWhere()
        {
            string[,] arr = new string[1, 4] { { "发码器地址", "=", txtCodeAddrss.Text,"string" } };
            return rtbll.SelectWhere(arr, 1);
        }
        //获取发码器配置查询条件

        private string GetStrWhereSet()
        {
            string strWhere = string.Empty;
            string tmpStr = cmbDeptList.SelectedValue.ToString();
            if (tmpStr == "0")
            {
                string[,] arr = new string[3, 4]
                {
                    {"发码器地址","=",txtCodeSet.Text,"int"},
                    {"称呼","=",txt.Text,"string"},
                    {"CsTypeID","=",cmbConfigType.Text.ToString() == "所有"?"":cmbConfigType.SelectedValue.ToString(),"int"}
                };
                strWhere = rtbll.SelectWhere(arr, 1);
            }
            else
            {
                DeptBLL dbll = new DeptBLL();
                DataSet ds = dbll.GetDeptInfoAll();
                strWhere = "DeptID = " + tmpStr;
                strWhere = dbll.GetDeptChildAll(ds, strWhere, int.Parse(tmpStr));

                string[,] arr = new string[3, 4]
                {
                    {"发码器地址","=",txtCodeSet.Text,"int"},
                    {"称呼","=",txt.Text,"string"},
                    {"CsTypeID","=",cmbConfigType.Text.ToString() == "所有"?"":cmbConfigType.SelectedValue.ToString(),"int"}
                };
                string tmp = rtbll.SelectWhere(arr, 1);
                // 如果没查询条件

                if (tmp != "")
                {
                    strWhere = "(" + strWhere;
                    strWhere += ") and " + tmp;
                }
            }
            return strWhere;
        }

        #region 翻页事件

        // 跳至
        void cpCheckPage_Click(object sender, EventArgs e)
        {
            if (txtCheckPage.Text == string.Empty) return;
            string value = txtCheckPage.Text;
            int page = int.Parse(value);
            getInfo(page);
        }

        // 下一页


        void cpDown_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page++;
            // 显示方式
            getInfo(page);

        }

        // 上一页


        void cpUp_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page--;
            // 显示方式
            getInfo(page);
        }

        #endregion

        // 页数加载
        private void getInfo(int pIndex)
        {
            dgvCodeSenderInfo.Columns.Clear();
            if (pIndex < 0) return;
            DataSet ds = null;
            ds = csbll.N_getKJ128N_CodeSender_Info_Table(pIndex - 1, pSize, GetStrWhere());
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;

                if (!cpUp.Enabled)
                {
                    cpUp.Enabled = true;
                }
                if (!cpDown.Enabled)
                {
                    cpDown.Enabled = true;
                }

                if (pIndex == 1)
                {
                    // 只有一页时
                    if (sumPage <= 1)
                    {
                        pageControlsVisible(false);
                    }
                    else
                    {
                        pageControlsVisible(true);
                        cpUp.Enabled = false;
                    }
                }
                else if (pIndex == sumPage)
                {
                    cpDown.Enabled = false;
                    // 最后一页

                }
                else if (pIndex > sumPage)
                {
                    // 大于最后一页

                    getInfo(sumPage);
                    return;
                }
                // bcpPageSum.CaptionTitle = "共"+ds.Tables[1].Rows[0][0].ToString()+"条/本页"+ds.Tables[0].Rows.Count.ToString() + "条";
                buttonCaptionPanel1.CaptionTitle = "标识卡信息:\t共 " + ds.Tables[1].Rows[0][0].ToString() + " 个标识卡";
                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "页";

                //删除
                DataGridViewLinkColumn dgvLBtnColRemove = new DataGridViewLinkColumn();
                dgvLBtnColRemove.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvLBtnColRemove.HeaderText = "操作";
                dgvLBtnColRemove.Name = "delete";
                dgvLBtnColRemove.DataPropertyName = "索引号";
                dgvLBtnColRemove.Text = "删  除";
                dgvLBtnColRemove.Visible = true;
                dgvLBtnColRemove.UseColumnTextForLinkValue = true;

                // 修改
                DataGridViewLinkColumn dgvLBtnColUpdate = new DataGridViewLinkColumn();
                dgvLBtnColUpdate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvLBtnColUpdate.HeaderText = "操作";
                dgvLBtnColUpdate.Name = "update";
                dgvLBtnColUpdate.DataPropertyName = "索引号";
                dgvLBtnColUpdate.Text = "修  改";
                dgvLBtnColUpdate.Visible = true;
                dgvLBtnColUpdate.UseColumnTextForLinkValue = true;

                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    ds.Tables[0].Rows[i]["索引编号"] = pSize * (pIndex - 1) + i + 1;
                //}
                dgvCodeSenderInfo.DataSource = ds.Tables[0];

                dgvCodeSenderInfo.Columns[2].HeaderText = "标识卡编号";


                dgvCodeSenderInfo.Columns["索引编号"].Visible = false;
                dgvCodeSenderInfo.Columns["索引号"].Visible = false;
                dgvCodeSenderInfo.Columns.Add(dgvLBtnColUpdate);
                dgvCodeSenderInfo.Columns.Add(dgvLBtnColRemove);
            }
        }

        // 修改 删除
        private void dgvCodeSenderInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 删除
            if (e.RowIndex > -1 && e.ColumnIndex == dgvCodeSenderInfo.Columns["delete"].Index)
            {
                dgvCodeSenderInfo.Rows[e.RowIndex].Selected = true;
                ((DataGridViewLinkColumn)dgvCodeSenderInfo.Columns["delete"]).VisitedLinkColor = Color.Blue;

                //MessageBox.Show(dgvCodeSenderInfo.CurrentRow.Cells["发码器编号"].Value.ToString());

                if (MessageBox.Show("您确认删除", "删  除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    operated = 2;
                    

                    int tmpInt = e.RowIndex;
                    csbll.removeCodeSender(int.Parse(dgvCodeSenderInfo.Rows[e.RowIndex].Cells[dgvCodeSenderInfo.Columns["索引号"].Index].Value.ToString()));

                    if (!New_DBAcess.IsDouble)
                    {
                        getInfo(int.Parse(txtPage.CaptionTitle));
                    }
                    else
                    {
                        timer1.Start();
                    }
                    dgvCodeSenderInfo.ClearSelection();
                    if (tmpInt > 0)
                    {
                        if (dgvCodeSenderInfo.Rows.Count > tmpInt + 1)
                        {
                            dgvCodeSenderInfo.Rows[tmpInt].Selected = true;
                        }
                        else
                        {
                            dgvCodeSenderInfo.Rows[tmpInt - 1].Selected = true;
                        }
                    }
                    getInfoc(int.Parse(txtPagec.CaptionTitle));
                }
            }
            else if (e.RowIndex > -1 && e.ColumnIndex == dgvCodeSenderInfo.Columns["update"].Index)
            {
                csClear();
                ((DataGridViewLinkColumn)dgvCodeSenderInfo.Columns["update"]).VisitedLinkColor = Color.Blue;
                DataSet ds = csbll.getCodeSender(int.Parse(dgvCodeSenderInfo.Rows[e.RowIndex].Cells[dgvCodeSenderInfo.Columns["索引号"].Index].Value.ToString()));
                if (ds.Tables != null && ds.Tables.Count > 0)
                {
                    lblAddNewCodeSenderLine.Visible = false;
                    txtAddCodeSenderAddressMax.Visible = false;
                    txtAddCodeSenderAddressMin.Enabled = false;
                    chkBatchAddCodeSender.Visible = false;
                    bcpAddNewCodeSenderTitle.CaptionTitle = "修改标识卡对话框";


                    txtAddCodeSenderAddressMin.Text = ds.Tables[0].Rows[0]["CodeSenderAddress"].ToString();
                    cmdAddCodeSenderState.SelectedValue = ds.Tables[0].Rows[0]["CodeSenderStateID"].ToString();
                    txtAddNewCodeSenderRemark.Text = ds.Tables[0].Rows[0]["Remark"] == null ? "" : ds.Tables[0].Rows[0]["Remark"].ToString();
                    vspAddNewCodeSenderPanel.Visible = true;
                    linkAddCodeSenderSaveAdd.Text = "修    改";
                }
            }
        }

        #region 翻页事件

        // 跳至
        void cpCheckPagec_Click(object sender, EventArgs e)
        {
            if (txtCheckPagec.Text == string.Empty) return;
            string value = txtCheckPagec.Text;
            int page = int.Parse(value);
            getInfoc(page);
        }

        // 下一页


        void cpDownc_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPagec.CaptionTitle);
            page++;
            // 显示方式
            getInfoc(page);

        }

        // 上一页


        void cpUpc_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPagec.CaptionTitle);
            page--;
            // 显示方式
            getInfoc(page);
        }

        #endregion

        private void getInfoc(int pIndex)
        {
            dgvCodeSenderSetInfo.Columns.Clear();
            if (pIndex < 0) return;
            DataSet ds = null;
            ds = csbll.N_getKJ128N_CodeSender_Set_Table(pIndex - 1, pSize, GetStrWhereSet());
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;

                if (!cpUpc.Enabled)
                {
                    cpUpc.Enabled = true;
                }
                if (!cpDownc.Enabled)
                {
                    cpDownc.Enabled = true;
                }

                if (pIndex == 1)
                {
                    // 只有一页时
                    if (sumPage <= 1)
                    {
                        cpageControlsVisible(false);
                    }
                    else
                    {
                        cpageControlsVisible(true);
                        cpUpc.Enabled = false;
                    }
                }
                else if (pIndex == sumPage)
                {
                    cpDownc.Enabled = false;
                    // 最后一页

                }
                else if (pIndex > sumPage)
                {
                    // 大于最后一页

                    getInfoc(sumPage);
                    return;
                }
                buttonCaptionPanel3.CaptionTitle = "标识卡配置信息:\t共" + ds.Tables[1].Rows[0][0].ToString() + " 条记录";
                txtPagec.CaptionTitle = pIndex.ToString();
                lblSumPagec.CaptionTitle = "/" + sumPage + "页";
                
                //删除
                DataGridViewLinkColumn dgvLBtnColRemove = new DataGridViewLinkColumn();
                dgvLBtnColRemove.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvLBtnColRemove.HeaderText = "操作";
                dgvLBtnColRemove.Name = "delete";
                dgvLBtnColRemove.DataPropertyName = "索引号";
                dgvLBtnColRemove.Text = "删  除";
                dgvLBtnColRemove.Visible = true;
                dgvLBtnColRemove.UseColumnTextForLinkValue = true;

                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    ds.Tables[0].Rows[i]["索引编号"] = pSize * (pIndex - 1) + i + 1;
                //}
                dgvCodeSenderSetInfo.DataSource = ds.Tables[0];
                dgvCodeSenderSetInfo.Columns["索引编号"].Visible = false;
                dgvCodeSenderSetInfo.Columns["CsSet"].Visible = false;
                dgvCodeSenderSetInfo.Columns["CodeSenderID"].Visible = false;
                dgvCodeSenderSetInfo.Columns.Add(dgvLBtnColRemove);
            }
        }

        // 
        private void dgvCodeSenderSetInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 删除
            if (e.RowIndex > -1 && e.ColumnIndex == dgvCodeSenderSetInfo.Columns["delete"].Index)
            {
                dgvCodeSenderSetInfo.Rows[e.RowIndex].Selected = true;
                ((DataGridViewLinkColumn)dgvCodeSenderSetInfo.Columns["delete"]).VisitedLinkColor = Color.Blue;

                if (MessageBox.Show("您确认删除", "删  除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int result = csbll.removeCodeSenderSet(int.Parse(dgvCodeSenderSetInfo.Rows[e.RowIndex].Cells[dgvCodeSenderSetInfo.Columns["CsSet"].Index].Value.ToString()));
                    int tmpInt = e.RowIndex;
                    if (result == 1)
                    {
                        getInfoc(int.Parse(txtPagec.CaptionTitle));
                        dgvCodeSenderSetInfo.ClearSelection();
                        if (tmpInt > 0)
                        {
                            if (dgvCodeSenderSetInfo.Rows.Count > tmpInt + 1)
                            {
                                dgvCodeSenderSetInfo.Rows[tmpInt].Selected = true;
                            }
                            else
                            {
                                dgvCodeSenderSetInfo.Rows[tmpInt - 1].Selected = true;
                            }
                        }
                        getInfo(int.Parse(txtPage.CaptionTitle));
                    }
                }
            }
        }

        #endregion

        #region [ 事件: 单击添加新的发码器标题的关闭按钮 ]

        private void bcpAddNewCodeSenderTitle_CloseButtonClick(object sender, EventArgs e)
        {
            vspAddNewCodeSenderPanel.Visible = false;
        }

        #endregion

        #region [ 事件: 批量添加选择框被选中时 ]

        private void chkBatchAddCodeSender_Click(object sender, EventArgs e)
        {
            if (chkBatchAddCodeSender.Checked)
            {
                txtAddCodeSenderAddressMax.Visible = true;
                lblAddNewCodeSenderLine.Visible = true;
                txtAddCodeSenderAddressMin.Width = 37;
            }
            else
            {
                lblAddNewCodeSenderLine.Visible = false;
                txtAddCodeSenderAddressMax.Visible = false;
                txtAddCodeSenderAddressMin.Width = 140;
            }
        }

        #endregion

        //
        private void bcpAddNewCodeSender_Click(object sender, EventArgs e)
        {
            bcpAddNewCodeSenderTitle.CaptionTitle = "添加标识卡对话框";
            txtAddCodeSenderAddressMin.Width = 140;

            vspAddNewCodeSenderPanel.Parent = this;
            vspAddNewCodeSenderPanel.BringToFront();

            vspAddNewCodeSenderPanel.Visible = true;
            lblAddNewCodeSenderLine.Visible = false;
            txtAddCodeSenderAddressMax.Visible = false;
            txtAddCodeSenderAddressMin.Enabled = true;
            chkBatchAddCodeSender.Visible = true;
            linkAddCodeSenderSaveAdd.Text = "存储并新增";
            csClear();
            cmdAddCodeSenderState.SelectedIndex = 0;
            txtAddNewCodeSenderRemark.Text = "";
            chkBatchAddCodeSender.Checked = false;
        }

        #region [ 方法: 配置新的发码器 ]

        private void bcpCodeSenderSet_Click(object sender, EventArgs e)
        {
            LoadDept();         // 加载部门树信息

            LoadCS();           // 加载发码器

            panelCodeSenderSet.Visible = true;
            panelCodeSenderSet.Parent = this;

            panelCodeSenderSet.BringToFront();
        }

        #endregion

        #region [ 方法: 加载发码器 ]

        private void LoadCS()
        {
            lbxCodeSender.Items.Clear();
            DataSet ds = csbll.getCS();
            if (ds.Tables !=null && ds.Tables.Count >0)
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    lbxCodeSender.Items.Add(new ListItem("0", "无"));
                }
                else
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (dr["Title"].ToString() == "正常")
                        {
                            lbxCodeSender.Items.Add(new ListItem(dr["CodeSenderID"].ToString(), dr["CodeSenderAddress"].ToString()));
                        }
                        else
                        {
                            lbxCodeSender.Items.Add(new ListItem(dr["CodeSenderID"].ToString(), dr["CodeSenderAddress"].ToString() + "   " + dr["Title"].ToString()));
                        }
                    }
                }
            }
        }

        #endregion

        #region [ 事件: 配置发码器 ]

        // 0人员 1设备
        private void bcpNewConfigCodeSender_Click(object sender, EventArgs e)
        {
            //存入日志
            LogSave.Messages("[FrmSetCodeSender]", LogIDType.UserLogID, "配置标识卡，标识卡名称：" + lbxCodeSender.Text + "，所属人员姓名：" + lbxEmployee.Text + "。");

            if (lbxEmployee.SelectedItem == null)
            {
                string str = rbtnEmp.Checked == true ? "人员" : "设备";
                MessageBox.Show("请选择"+str);
                return;
            }
            if (((ListItem)lbxEmployee.SelectedItem).ID == "0") return;
            if (lbxCodeSender.SelectedItem == null)
            {
                MessageBox.Show("请选择"+KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.CodeSender));
                return;
            }
            StationBLL s = new StationBLL();
            string tmpStr = ((ListItem)lbxCodeSender.SelectedItem).Name;
            if (s.IsNumeric(tmpStr))
            {
                int tmpInt = csbll.addCodeSender_Set(int.Parse(((ListItem)lbxCodeSender.SelectedItem).ID)
                        , int.Parse(((ListItem)lbxEmployee.SelectedItem).ID), rbtnEmp.Checked == true ? 0 : 1);

                if (tmpInt > 0)
                {
                    bcpResult.CaptionTitle = "配置成功!";

                    int emp = lbxEmployee.SelectedIndex;
                    int equ = lbxCodeSender.SelectedIndex;

                    lbxEmployee.Items.RemoveAt(emp);
                    lbxCodeSender.Items.RemoveAt(equ);

                    //
                    if (emp < 0)
                    {
                        lbxEmployee.SelectedIndex = -1;
                    }
                    else
                    {
                        if (lbxEmployee.Items.Count > emp + 1)
                        {
                            lbxEmployee.SelectedIndex = emp;
                        }
                        else
                        {
                            lbxEmployee.SelectedIndex = emp - 1;
                        }
                    }

                    if (equ < 0)
                    {
                        lbxCodeSender.SelectedIndex = -1;
                    }
                    else
                    {
                        if (lbxCodeSender.Items.Count > equ + 1)
                        {
                            lbxCodeSender.SelectedIndex = equ;
                        }
                        else
                        {
                            lbxCodeSender.SelectedIndex = equ - 1;
                        }
                    }

                    if (lbxCodeSender.Items.Count == 1)
                    {
                        lbxCodeSender.SelectedIndex = 0;
                    }

                    LoadCodeSenderConfig();           // 重新加载表格数据
                }
            }
            else
            {
                MessageBox.Show(KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.CodeSender) +tmpStr.Replace(" ", "") + " 请重新配置");
                // bcpResult.CaptionTitle = tmpStr;
            }
        }

        #endregion

        #region [ 事件: 隐藏添加发码器面板 ]

        private void bcpAddNewCode_CloseButtonClick(object sender, EventArgs e)
        {
            panelCodeSenderSet.Visible = false;
        }

        #endregion

        #region [ 方法: 双击显示详细信息 ]

        private void listBoxEmployee_DoubleClick(object sender, EventArgs e)
        {
            if (lbxEmployee.SelectedItem != null)
            {
                if (((ListItem)lbxEmployee.SelectedItem).ID == "0") return;
                DataSet ds = null;
                if (rbtnEmp.Checked)
                {
                    ds = csbll.getSmallEmpInfo(int.Parse(((ListItem)lbxEmployee.SelectedItem).ID));
                    if (ds.Tables != null && ds.Tables.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        bcpInfo1.CaptionTitle = "编    号: " + dr["EmpNO"].ToString();
                        bcpInfo2.CaptionTitle = "姓    名: " + dr["EmpName"].ToString();
                        bcpInfo3.CaptionTitle = "职    称: " + dr["OfficialDesignation"].ToString();
                        bcpInfo4.CaptionTitle = "部    门: " + dr["DeptName"].ToString();
                        bcpInfo5.CaptionTitle = "职    务: " + dr["DutyName"].ToString();
                        bcpInfo6.CaptionTitle = "出生日期: " + dr["BirthDay"].ToString();
                        if (dr["Photo"].ToString() != string.Empty)
                        {
                            pbPhoto.Visible = true;
                            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream((byte[])dr["Photo"]);
                            Bitmap bmp = new Bitmap(memoryStream);
                            Graphics g = Graphics.FromImage(bmp);
                            pbPhoto.Image = bmp;
                        }
                    }
                }
                else
                {
                    ds = csbll.getSmallEquInfo(int.Parse(((ListItem)lbxEmployee.SelectedItem).ID));
                    if (ds.Tables != null && ds.Tables.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        bcpInfo1.CaptionTitle = "编    号: " + dr["EquNO"].ToString();
                        bcpInfo2.CaptionTitle = "名    称: " + dr["EquName"].ToString();
                        bcpInfo3.CaptionTitle = "部    门: " + dr["DeptName"].ToString();
                        bcpInfo4.CaptionTitle = "类    型: " + dr["Title"].ToString();
                        bcpInfo5.CaptionTitle = "状    态: " + dr["State"].ToString();
                        bcpInfo6.CaptionTitle = "生产厂家: " + dr["FactoryName"].ToString();

                        pbPhoto.Visible = false;
                    }
                }
                pnlInfo.Visible = true;             //显示pnlInfo
            }
        }

        #endregion

        #region [ 事件: 添加发码器 ]

        // 添加发码器

        private void linkAddCodeSenderSaveAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //存入日志
            //  LogSave.Messages("[FrmSetCodeSender]", LogIDType.UserLogID, "添加发码器，发码器编号为：" + txtUser.Text.ToString() + "；人员编号为："+);

            if (linkAddCodeSenderSaveAdd.Text == "存储并新增")
            {
                operated = 1;

                insert();

                if (!New_DBAcess.IsDouble)
                {
                    getInfo(1);
                }
                else
                {
                    timer1.Start();
                }
            }
            else
            {
                operated = 3;

                address = txtAddCodeSenderAddressMin.Text;

                int result = csbll.updateCodeSender(int.Parse(cmdAddCodeSenderState.SelectedValue.ToString()), int.Parse(txtAddCodeSenderAddressMin.Text), txtAddNewCodeSenderRemark.Text);
                if (result == 1)
                {
                    MessageBox.Show("修改成功!");


                    if (!New_DBAcess.IsDouble)
                    {
                        getInfo(int.Parse(txtPage.CaptionTitle));
                    }
                    else
                    {
                        timer1.Start();
                    }
                }
            }
        }

        #region [ 方法: 添加 ]

        private void insert()
        {
            //存入日志
            LogSave.Messages("[FrmSetCodeSender]", LogIDType.UserLogID, "添加标识卡，标识卡编号：" + txtAddCodeSenderAddressMin.Text +"----"+txtAddCodeSenderAddressMax.Text
                + "状态" + cmdAddCodeSenderState.SelectedText + "。");
            address = txtAddCodeSenderAddressMin.Text;

            string stationArr = string.Empty;
            if (txtAddCodeSenderAddressMin.Text == string.Empty) return;
            int min = int.Parse(txtAddCodeSenderAddressMin.Text);
            if (min == 0) 
            { 
                MessageBox.Show(HardwareName.Value(CorpsName.CodeSenderAddress) + "不能为0"); 
                return; 
            }
            if (chkBatchAddCodeSender.Checked)
            {
                if (txtAddCodeSenderAddressMax.Text == string.Empty) return;
                int max = int.Parse(txtAddCodeSenderAddressMax.Text);
                if (max <= min) { MessageBox.Show(HardwareName.Value(CorpsName.CodeSenderAddress)+"范围应从小到大 例:1-10"); return; }
                // 组织分站地址列表

                if (max - min > 100)
                {
                    MessageBox.Show("只能批量添加100个标识卡！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }



                for (int i = min; i <= max; i++)
                {
                    if (i < max)
                        stationArr += i.ToString() + ",";
                    else
                        stationArr += i.ToString();
                }



                // 获得重复的发码器
                DataTable dt = csbll.getExistsCodeSenderAddressList(stationArr);

                //添加alarmElectricity默认为0 isCodeSenderUser默认为未使用2
                int resultInt = csbll.addCodeSenderInfo(stationArr, 0, int.Parse(cmdAddCodeSenderState.SelectedValue.ToString()), 2, txtAddNewCodeSenderRemark.Text == string.Empty ? "" : txtAddNewCodeSenderRemark.Text);

                // 添加成功后 组织重复的发码器地址
                string tempString = string.Empty;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        tempString += dr["col"].ToString() + ",";
                    }
                }
                if (tempString.Length > 0)
                {
                    tempString = tempString.Substring(0, tempString.Length - 1);
                    if (stationArr == tempString)
                    {
                        MessageBox.Show(HardwareName.Value(CorpsName.CodeSenderAddress)+"全部存在");
                        txtAddCodeSenderAddressMax.Text = "";
                        txtAddCodeSenderAddressMin.Text = "";
                        return;
                    }
                    MessageBox.Show(tempString + " " + KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.CodeSender) + "已经存在,其他已添加成功");
                    LoadCodeSenderInfo();               // 重新加载表格数据
                    return;
                    csClear();
                }
                else if (resultInt == -1)
                {
                    MessageBox.Show("添加失败");
                }
                else
                {
                    MessageBox.Show("添加成功");
                    LoadCodeSenderInfo();               // 重新加载表格数据
                }
                return;
            }
            else
            {
                int result = int.Parse(csbll.getExistsCodeSenderAddress(min, 0, int.Parse(cmdAddCodeSenderState.SelectedValue.ToString()), 2, txtAddNewCodeSenderRemark.Text == string.Empty ? "" : txtAddNewCodeSenderRemark.Text).ToString());
                //判断分站地址号是否存在

                address = txtAddCodeSenderAddressMin.Text;

                if ( result>= 1)
                {
                    MessageBox.Show("添加成功");
                    txtAddCodeSenderAddressMin.Text = "";
                    LoadCodeSenderInfo();               // 重新加载表格数据
                    
                }
                else if (result == 0)
                {
                    MessageBox.Show(HardwareName.Value(CorpsName.CodeSenderAddress)+":" + min.ToString() + "已经存在,请重新添加");
                    return;
                }
                
            }
        }

        #endregion

        #endregion

        #region [ 方法: 清空 ]

        // 发码器信息清空

        private void csClear()
        {
            txtAddCodeSenderAddressMax.Text = "";
            txtAddCodeSenderAddressMin.Text = "";
            cmdAddCodeSenderState.SelectedIndex = cmdAddCodeSenderState.FindString("正常");
        }

        #endregion

        #region [ 方法: 查询 ]

        //组织查询条件
        private string strWhere(string deptID)
        {
            string[,] strArray = null;
            if (rbtnEmp.Checked)
            {
                strArray = new string[1, 4] { { "DeptID", "=", deptID, "int" } };
            }
            else
            {
                strArray = new string[1, 4] { { "DeptID", "=", deptID, "int" } };
            }
            return rtbll.SelectWhere(strArray, 0);
        }

        // 绑定数据
        private void ListBoxBind(string where)
        {
            lbxEmployee.Items.Clear();
            DataSet ds = null;
            if (rbtnEmp.Checked)
            {
                ds = csbll.getEmpInfo(where);
                if (ds.Tables != null && ds.Tables.Count >= 0)
                {
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        lbxEmployee.Items.Add(new ListItem("0", "无"));
                    }
                    else
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            lbxEmployee.Items.Add(new ListItem(dr["EmpID"].ToString(), dr["EmpName"].ToString()));
                        }
                    }
                }
            }
            else
            {
                ds = csbll.getEquInfo(where);
                if (ds.Tables != null && ds.Tables.Count >= 0)
                {
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        lbxEmployee.Items.Add(new ListItem("0", "无"));
                    }
                    else
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            lbxEmployee.Items.Add(new ListItem(dr["EquID"].ToString(), dr["EquName"].ToString()));
                        }
                    }
                }
            }
        }

        #endregion

        #region [ 事件: 单击节点 ]

        // 单击节点
        private void tvDepartMent_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string tmpNode = e.Node.Name.Substring(1);
            if (tmpNode == "oot")
            {
                deptID = "1=1";
                ListBoxBind(deptID);
            }
            else
            {
                deptID = e.Node.Name.Substring(1);
                getNodeAllChild(e.Node);
                ListBoxBind(strWhere(deptID));
            }
        }

        // 遍历节点下的所有子节点
        private void getNodeAllChild(TreeNode tn)
        {
            if (tn.Nodes.Count > 0)
            {
                foreach (TreeNode n in tn.Nodes)
                {
                    if (n.Nodes.Count > 0)
                    {
                        getNodeAllChild(n);
                    }
                    deptID += " or DeptID=" + n.Name.Substring(1);
                }
            }
        }

        #endregion

        #region [ 事件: 单击人员单选按钮 ]

        private void rbtnEmp_CheckedChanged(object sender, EventArgs e)
        {
            lblName.Text = "人员姓名：";
            bcpInfoTitle.CaptionTitle = "人员信息";
            if (tvDepartMent.SelectedNode != null)
            {
                if (deptID == "1=1")
                {
                    ListBoxBind(deptID);
                }
                else
                {
                    ListBoxBind(strWhere(deptID));
                }
            }
        }

        #endregion

        #region  [ 事件: 单击设备单选按钮 ]

        private void rbtnEqu_CheckedChanged(object sender, EventArgs e)
        {
            lblName.Text = "设备名称：";
            bcpInfoTitle.CaptionTitle = "设备信息";
            if (tvDepartMent.SelectedNode != null)
            {
                if (deptID == "1=1")
                {
                    ListBoxBind(deptID);
                }
                else
                {
                    ListBoxBind(strWhere(deptID));
                }
            }
        }

        #endregion

        #region [ 事件: 查询 ]
        private void bcpSelect_Click(object sender, EventArgs e)
        {
            int index=lbxEmployee.FindString(txtName.Text);
            lbxEmployee.SelectedIndex = index;
            //lbxEmployee.SelectedIndex = index == -1 ? 0 : index;
            if (index == -1)
            {
                lblErrInfo.ForeColor = Color.Red;
                lblErrInfo.Text = "没有查询到" + txtName.Text;
            }
            else
            {
                lblErrInfo.ForeColor = Color.Blue;
                lblErrInfo.Text = "";
            }
        }

        #endregion

        #region [ 事件: 拖动 ]

        // 详细信息显示
        private void captionPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            isDrag = true;
            point = e.Location;
        }

        private void captionPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag)
            {
                pnlInfo.Location = new Point(pnlInfo.Left + e.Location.X - point.X, pnlInfo.Top + e.Location.Y - point.Y);
            }
        }

        private void captionPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
        }

        // 发码器配置


        private void bcpAddNewCode_MouseDown(object sender, MouseEventArgs e)
        {
            isDrag = true;
            point = e.Location;
        }

        private void bcpAddNewCode_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag)
            {
                panelCodeSenderSet.Location = new Point(panelCodeSenderSet.Left + e.Location.X - point.X, panelCodeSenderSet.Top + e.Location.Y - point.Y);
            }
        }

        private void bcpAddNewCode_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
        }

        // 发码器添加


        private void bcpAddNewCodeSenderTitle_MouseDown(object sender, MouseEventArgs e)
        {
            isDrag = true;
            point = e.Location;
        }

        private void bcpAddNewCodeSenderTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag)
            {
                vspAddNewCodeSenderPanel.Location = new Point(vspAddNewCodeSenderPanel.Left + e.Location.X - point.X, vspAddNewCodeSenderPanel.Top + e.Location.Y - point.Y);
            }
        }

        private void bcpAddNewCodeSenderTitle_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
        }

        #endregion

        #region [ 事件: 选择 每页显示行数 ]
        private void cmb_Size_SelectionChangeCommitted(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cmb_Size.SelectedItem);
            LoadCodeSenderInfo();
            LoadCodeSenderConfig();

        }
        #endregion

        #region [ 事件: 配置发码器界面中 重置 ]

        private void buttonCaptionPanel6_Click(object sender, EventArgs e)
        {
            //tvDepartMent.SelectedNode = tvDepartMent.Nodes[0];
            rbtnEmp.Checked = true;
            txtName.Text = "";
        }
        #endregion

        private void captionPanel1_CloseButtonClick(object sender, EventArgs e)
        {
            pnlInfo.Visible = false;
        }

        private void bcpCodeSetSelect_Click(object sender, EventArgs e)
        {
            getInfoc(1);
        }

        private void bcpCodeSenderSelect_Click(object sender, EventArgs e)
        {
            getInfo(1);
        }

        private void bcpInitAllCode_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认将所有标识卡状态修改为正常", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //存入日志
                LogSave.Messages("[FrmSetCodeSender]", LogIDType.UserLogID, "初始化标识卡状态");

                csbll.InitAllCode();

                //刷新DataGridView操作
                //未刷新DataGridView
            }
        }


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
        /// 1表示 增加，修改 2 表示删除,3表示修改
        /// </summary>
        private int operated = 1;

        private string address;

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (address == "" || address == String.Empty)
            {
                return;
            }

            //增加
            if (operated == 1)
            {
                string value = address;

                if (RecordSearch.IsRecordExists("CodeSender_Info", "CodeSenderAddress", value, DataType.Int))
                {
                    //刷新

                    getInfo(1);

                    times = 0;
                    //关闭timer1
                    timer1.Stop();
                }
                else
                {
                    if (times < maxTimes)
                    {
                        times++;
                        timer1.Stop();
                        timer1.Start();
                    }
                    else
                    {
                        times = 0;
                        //关闭timer1
                        timer1.Stop();
                    }
                }
            }
            //删除
            else if (operated == 2)
            {
                //string value = dgvCodeSenderInfo.CurrentRow.Cells["发码器编号"].Value.ToString();
                //if (!RecordSearch.IsRecordExists("CodeSender_Info", "CodeSenderAddress", value, DataType.Int))
                //{
                //    //刷新

                //    getInfo(int.Parse(txtPage.CaptionTitle));

                //    times = 0;
                //    //关闭timer1
                //    timer1.Stop();
                //}
                //else
                //{
                //    if (times < maxTimes)
                //    {
                //        times++;
                //        timer1_Tick(sender, e);
                //    }
                //    else
                //    {
                //        times = 0;
                //        //关闭timer1
                //        timer1.Stop();
                //    }
                //}

                if (times < maxTimes)
                {
                    getInfo(int.Parse(txtPage.CaptionTitle));

                    times++;

                    timer1.Interval = 1000;
                    timer1.Stop();
                    timer1.Start();
                }
                else
                {
                    times = 0;

                    timer1.Interval = 400;
                    //关闭timer1
                    timer1.Stop();
                }

            }
            //修改
            else
            {
                string add = address;
                string strWhere = "CodeSenderStateID=" + cmdAddCodeSenderState.SelectedValue.ToString()
                    + " and Remark='" + txtAddNewCodeSenderRemark.Text
                    + "' and CodeSenderAddress=" + add;

                if (RecordSearch.IsRecordExists("CodeSender_Info", strWhere))
                {
                    //刷新

                    getInfo(int.Parse(txtPage.CaptionTitle));

                    times = 0;
                    //关闭timer1
                    timer1.Stop();
                }
                else
                {
                    if (times < maxTimes)
                    {
                        times++;
                        timer1_Tick(sender, e);
                    }
                    else
                    {
                        times = 0;
                        //关闭timer1
                        timer1.Stop();
                    }
                }
            }
        }

        #endregion        

        #region 【 刷新界面 】

        private void buttonCaptionPanel5_Click(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cmb_Size.SelectedItem);
            LoadCodeSenderInfo();
            LoadCodeSenderConfig();
        }

        #endregion
    }

    #region [ ListItem ]

    public class ListItem
    {
        private string id = string.Empty;
        private string name = string.Empty;
        public ListItem(string sid, string sname)
        {
            id = sid;
            name = sname;
        }
        public override string ToString()
        {
            return this.name;
        }
        public string ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
    }

    #endregion
}