using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128WindowsLibrary;
using KJ128NDBTable;
using KJ128NDataBase;
using KJ128NModel;
using Shine.Logs;
using Shine.Logs.LogType;
using PrintCore;

namespace KJ128NMainRun.PathManage
{
    public partial class FrmPathEmp : Wilson.Controls.Docking.DockContent
    {
        #region [构造函数]

        public FrmPathEmp()
        {
            InitializeComponent();
        }

        #endregion

        #region [字段]

        private PathInfoBll pathInfoBll = new PathInfoBll();

        private PathEmpRelationBll pathEmpRelationbll = new PathEmpRelationBll();

        //private KJ128NSerialAndDeserial KJ128Nsad = new KJ128NSerialAndDeserial();

        private DataTable dtEmp = null;

        private DataTable dtDept = null;


        #endregion

        #region [方法]

        #region [拖拽]

        /// <summary>
        /// 是否启用拖拽
        /// </summary>
        private bool moveAble = false;
        /// <summary>
        /// 左边距离
        /// </summary>
        private int left = 0;
        /// <summary>
        /// 上边距离 
        /// </summary>
        private int top = 0;

        /// <summary>
        /// 移动的方法
        /// </summary>
        /// <param name="obj">移动的对象</param>
        /// <param name="leftSize">左边距离</param>
        /// <param name="topSize">上边距离</param>
        private void ToMove(VSPanel obj, int leftSize, int topSize)
        {

            obj.Left += (Cursor.Position.X - leftSize);
            obj.Top += (Cursor.Position.Y - topSize);


            this.Cursor = Cursors.SizeAll;
            left = Cursor.Position.X;
            top = Cursor.Position.Y;

        }

        private void bcpAdd_MouseDown(object sender, MouseEventArgs e)
        {
            moveAble = true;

            left = Cursor.Position.X;
            top = Cursor.Position.Y;
        }

        private void bcpAdd_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveAble)
            {
                ToMove(vspnlAdd, left, top);
            }
        }

        private void bcpAdd_MouseUp(object sender, MouseEventArgs e)
        {
            moveAble = false;
            this.Cursor = Cursors.Default;
        }

        #endregion

        private void bcpAdd_CloseButtonClick(object sender, EventArgs e)
        {
            vspnlAdd.Visible = false;
        }

        /// <summary>
        /// 初始化增加
        /// </summary>
        private void InitialzeNew()
        {
            this.tbPathNo.Text = tvMain.SelectedNode.Name;
            this.tbPathName.Text = tvMain.SelectedNode.Text;

            //InitialzeEmpComboBox();

            InitialzeDeptComboBox();

            this.bcpAdd.CaptionTitle = "增加信息";
            this.btnAddOrEdit.CaptionTitle = "增加";

        }

        /// <summary>
        /// 初始化修改
        /// </summary>
        private void InitialzeUpdate()
        {
            this.tbPathNo.Text = dgvMain.CurrentRow.Cells["PathNo"].Value.ToString();
            this.tbPathName.Text = dgvMain.CurrentRow.Cells["PathName"].Value.ToString();

            //InitialzeEmpComboBox();
            InitialzeDeptComboBox();

            this.bcpAdd.CaptionTitle = "修改信息";
            this.btnAddOrEdit.CaptionTitle = "修改";
            this.vspnlAdd.Visible = true;
        }

        /// <summary>
        /// 初始化DataGridView
        /// </summary>
        private void InitialzeDataGridView()
        {
            //获得DataTable填充数据
            DataTable dt = GetDataTable("");
            //this.dbgvMain.DataSource = dt;
            SortDataGrid(dt);
        }

        /// <summary>
        /// 初始化树
        /// </summary>
        private void InitialzeTreeView()
        {
            //获得路线信息(PathInfo)DataTable填充数据
            DataTable dt = GetPathInfo("");

            tvMain.Nodes[0].Nodes.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                TreeNode node = new TreeNode();
                node.Name = dr["PathNo"].ToString();
                node.Text = dr["PathName"].ToString();

                //node.ToolTipText = "路线Id:" + dr["Id"].ToString() + "\n"
                node.ToolTipText = "路线编号:" + dr["PathNo"].ToString() + "\n"
                    + "路线名:" + dr["PathName"].ToString() + "\n"
                    + "备注:" + dr["Remark"].ToString();

                tvMain.Nodes[0].Nodes.Add(node);
            }

            this.tvMain.ExpandAll();
        }

        ///// <summary>
        ///// 加载分站ComboBox
        ///// </summary>
        //private void InitialzeStationComboBox()
        //{
        //    if (dtStation == null)
        //        dtStation = GetStationInfo();

        //    //加载列表
        //    cbstation.DisplayMember = "StationPlace";
        //    cbstation.ValueMember = "StationAddress";

        //    cbstation.DataSource = dtStation;

        //    cbstation.SelectedIndex = 0;

        //}

        /// <summary>
        /// 加载探头ComboBox
        /// </summary>
        //private void InitialzePointComboBox(int stationAddress)
        //{
        //    DataTable dt = DataHelper.GetPointInfo(stationAddress);

        //    cbPiont.DisplayMember = "StationHeadPlace";
        //    cbPiont.ValueMember = "StationHeadAddress";
        //    cbPiont.DataSource = dt;

        //}

        /// <summary>
        /// 按一定的查询条件获得数据表
        /// </summary>
        /// <param name="condition"> 查询条件，如果condition为空，表示全部查找</param>
        /// <returns>数据表</returns>
        private DataTable GetDataTable(string condition)
        {
            DataTable dt = pathEmpRelationbll.SelectPathEmpRelation(condition);
            return dt;
        }

        /// <summary>
        /// 获取人员信息，用于绑定ComboBox
        /// </summary>
        /// <param name="tationAddress">分站地址，根据分站地址获取探头信息</param>
        /// <returns>探头表</returns>
        private DataTable GetEmpInfo(int deptId)
        {
            //if (dtEmp==null)
                dtEmp = DataHelper.GetEmpInfo(deptId);

            return dtEmp;
        }

        private DataTable GetDeptInfo()
        {
            //if (dtDept == null)
                dtDept = DataHelper.GetDeptInfo();
            return dtDept;
        }

        /// <summary>
        /// 获取人员信息，加载到 ComboBox 中去
        /// </summary>
        private void InitialzeEmpComboBox(int deptId)
        {
            DataTable dt = GetEmpInfo(deptId);

            this.cbEmp.DisplayMember = "EmpName";
            this.cbEmp.ValueMember = "EmpID";
            this.cbEmp.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                this.cbEmp.SelectedIndex = 0;
            }
        }

        private void InitialzeDeptComboBox()
        {
            DataTable dt = GetDeptInfo();

            this.cbDept.DisplayMember = "DeptName";
            this.cbDept.ValueMember = "DeptId";
            this.cbDept.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                this.cbDept.SelectedIndex = 0;
            }
        }

        
        /// <summary>
        /// 获取PathInfo信息
        /// </summary>
        /// <param name="conditon">查询条件</param>
        /// <returns>PathInfo信息</returns>
        private DataTable GetPathInfo(string conditon)
        {
            if (pathInfoBll == null)
            {
                pathInfoBll = new PathInfoBll();
            }
            DataTable dt = pathInfoBll.SelectPathInfo(conditon);
            return dt;
        }

        /// <summary>
        /// 添加路线的具体信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcp_Add_Click(object sender, EventArgs e)
        {
            if (tvMain.SelectedNode == null || tvMain.SelectedNode == tvMain.TopNode)
            {

                MessageBox.Show("请在左边选择要添加探头的路线", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //初始化增加
                InitialzeNew();
                vspnlAdd.Visible = true;
            }
        }

        /// <summary>
        /// 操作 “增加” 或 “修改”时的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            if (CheckValue())
            {
                if (btnAddOrEdit.CaptionTitle == "增加")
                {
                    operated = 1;
                    int result = AddPathEmpRelation();
                    if (result == 1)
                    {
                        if (pathEmpRelationbll == null)
                            pathEmpRelationbll = new  PathEmpRelationBll();

                        MessageBox.Show("增加信息成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!New_DBAcess.IsDouble)
                        {
                            DataTable dt = pathEmpRelationbll.SelectPathEmpRelation("");

                            SortDataGrid(dt);
                        }
                        else
                        {
                            timer1.Start();
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("增加操作失败,记录可能已存在，不能增加重复记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (btnAddOrEdit.CaptionTitle == "修改")
                {
                    operated = 3;

                    int result = UpdatePathEmpRelation();
                    if (result == 1)
                    {
                        if (pathEmpRelationbll == null)
                            pathEmpRelationbll = new PathEmpRelationBll();

                        MessageBox.Show("修改信息成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (!New_DBAcess.IsDouble)
                        {
                            DataTable dt = pathEmpRelationbll.SelectPathEmpRelation("");

                            SortDataGrid(dt);
                        }
                        else
                        {
                            timer1.Start();
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("修改操作失败，记录可能已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        /// <summary>
        /// 刷新树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcpRefresh_Click(object sender, EventArgs e)
        {
            //加载树
            InitialzeTreeView();
        }

        /// <summary>
        /// 单击单元格：删除，修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dbgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string operate = dgvMain.CurrentRow.Cells[e.ColumnIndex].Value.ToString();

                if (operate == "修改")
                {
                    InitialzeUpdate();
                }

                else if (operate == "删除")
                {
                    try
                    {
                        DialogResult dr = MessageBox.Show("您确认要删除这条记录？", "确认提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            operated = 2;

                            //存入日志
                            LogSave.Messages("[FrmPathEmp]", LogIDType.UserLogID, "删除员工路径关系信息，路线编号："
                                + dgvMain.CurrentRow.Cells["PathNo"].Value.ToString() + "，员工姓名：" + dgvMain.CurrentRow.Cells[5].Value.ToString() + "。");

                            int id = Convert.ToInt32(dgvMain.CurrentRow.Cells["Id"].Value.ToString());
                            int count = pathEmpRelationbll.DeletePathEmpRelation(id);

                            bool flag = (count == 1 ? true : false);

                            if (flag)
                            {
                                if (!New_DBAcess.IsDouble)
                                {
                                    InitialzeDataGridView();
                                }
                                else
                                {
                                    timer1.Start();
                                }
                            }
                            else
                            {
                                MessageBox.Show("删除操作失败", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("操作失败:" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// 增加PathEmpRelation信息
        /// </summary>
        /// <returns>返回操作结果 返回操作结果 1表示成功</returns>
        private int AddPathEmpRelation()
        {
            try
            {
                //存入日志
                LogSave.Messages("[FrmPathEmp]", LogIDType.UserLogID, "增加员工路径关系信息，路线编号："
                    + this.tbPathNo.Text + "，员工姓名：" + this.cbEmp.SelectedText.ToString() + "。");

                KJ128NModel.PathEmpRelationModel model = new PathEmpRelationModel();

                if (this.cbEmp.SelectedValue != null)
                {
                    model.EmpID = Convert.ToInt32(this.cbEmp.SelectedValue);
                }
                else
                {
                    MessageBox.Show("添加员工信息不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 0;
                }
                model.PathNo = this.tbPathNo.Text;
                string strMessage = "";
                int count = pathEmpRelationbll.InsertPathEmpRelation(model,out strMessage);

                bool flag = (count == 1 ? true : false);

                if (flag)
                {
                    this.vspnlAdd.Visible = false;
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 修改PathEmpRelation信息
        /// </summary>
        /// <returns>返回操作结果 1表示成功</returns>
        private int UpdatePathEmpRelation()
        {
            try
            {
                //存入日志
                LogSave.Messages("[FrmPathEmp]", LogIDType.UserLogID, "修改员工路径关系信息，路线编号："
                    + this.tbPathNo.Text + "，员工姓名：" + this.cbEmp.SelectedText.ToString() + "。");

                KJ128NModel.PathEmpRelationModel model = new PathEmpRelationModel();
                model.Id = Convert.ToInt32(dgvMain.CurrentRow.Cells["Id"].Value.ToString());

                if (this.cbEmp.SelectedValue != null)
                {
                    model.EmpID = Convert.ToInt32(this.cbEmp.SelectedValue.ToString());
                }
                else
                {
                    MessageBox.Show("修改员工信息不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 0;
                }
                model.PathNo = this.tbPathNo.Text;
                string strMessage = "";
                int count = pathEmpRelationbll.UpdatePathEmpRelation(model,out strMessage);

                bool flag = (count == 1 ? true : false);

                if (flag)
                {
                    this.vspnlAdd.Visible = false;
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 检查数据
        /// </summary>
        /// <returns></returns>
        private bool CheckValue()
        {
            if (cbEmp.Text.Trim() == "")
            {
                MessageBox.Show("员工姓名不要为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 修改面板显示时，单击DataGrid时发生的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dbgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (vspnlAdd.Visible == true && bcpAdd.CaptionTitle == "修改探头信息")
                {
                    tbPathNo.Text = dgvMain.CurrentRow.Cells["PathNo"].Value.ToString();
                    tbPathName.Text = dgvMain.CurrentRow.Cells["PathName"].Value.ToString();
                }
            }
        }

        /// <summary>
        /// 给DataGrid赋值数据源，并且对列进行顺序
        /// </summary>
        private void SortDataGrid(DataTable dt)
        {
            this.dgvMain.Columns.Clear();

            this.dgvMain.DataSource = dt;

            DataGridViewLinkColumn editCol = new DataGridViewLinkColumn();
            editCol.Name = "edit";
            editCol.HeaderText = "修改信息";
            editCol.Text = "修改";
            editCol.Width = 60;
            editCol.UseColumnTextForLinkValue = true;
            this.dgvMain.Columns.Add(editCol);

            DataGridViewLinkColumn deleteCol = new DataGridViewLinkColumn();
            deleteCol.Name = "delete";
            deleteCol.HeaderText = "删除信息";
            deleteCol.Text = "删除";
            deleteCol.Width = 60;
            deleteCol.UseColumnTextForLinkValue = true;
            this.dgvMain.Columns.Add(deleteCol);


            this.dgvMain.Columns["Id"].Visible = false;
            this.dgvMain.Columns["EmpID"].Visible = false;
            this.dgvMain.Columns["PathNo"].HeaderText = "路线编号";
            this.dgvMain.Columns["PathName"].HeaderText = "路线名称";

            //this.dbgvMain.Columns["Id"].DisplayIndex = 0;
            //this.dbgvMain.Columns["PathNo"].DisplayIndex = 1;
            //this.dbgvMain.Columns["PathName"].DisplayIndex = 2;
            this.dgvMain.Columns["EmpNo"].HeaderText = "员工编号";
            this.dgvMain.Columns["EmpName"].HeaderText = "员工姓名";
        }

        /// <summary>
        /// 单击树节点时，DataGrid里显示相应的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvMain_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Node.Nodes.Count < 1)
            {
                string pathNo = e.Node.Name;
                if (pathEmpRelationbll == null)
                    pathEmpRelationbll = new PathEmpRelationBll();

                string condition = "per.PathNo='" + pathNo + "'";

                DataTable dt = pathEmpRelationbll.SelectPathEmpRelation(condition);
                SortDataGrid(dt);
            }
        }

        /// <summary>
        /// 点击新增时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcpAddInfo_Click(object sender, EventArgs e)
        {
            if (tvMain.SelectedNode == null || tvMain.SelectedNode == tvMain.TopNode)
            {
                MessageBox.Show("请在左边选择要添加员工信息的路线", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //初始化增加
                InitialzeNew();
                vspnlAdd.Visible = true;
            }
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPathEmp_Load(object sender, EventArgs e)
        {
            //加载树
            InitialzeTreeView();

            //加载DataGrid
            InitialzeDataGridView();
        }

        /// <summary>
        /// 加载人员信息，填充ConboBox重
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbEmp_Click(object sender, EventArgs e)
        {
            if (cbDept.Text != "")
            {
                int deptId = Convert.ToInt32(cbDept.SelectedValue);
                InitialzeEmpComboBox(deptId);
            }
        }

        /// <summary>
        /// 查找信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcpSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string condition = String.Empty;

                if (tbPNo.Text.Trim() != "")
                {
                    condition = "per.PathNo like '%" + tbPNo.Text + "%'";
                }
                else
                {
                    condition = "1=1";
                }

                if (tbPName.Text.Trim() != "")
                {
                    condition += "and pi.PathName like '%" + tbPName.Text + "%'";
                }

                if (tbEmpNo.Text.Trim() != "")
                {
                    condition += "and per.EmpNo like '%" + tbEmpNo.Text + "%'";
                }

                if (tbEmpName.Text.Trim() != "")
                {
                    condition += "and ei.EmpName like '%" + tbEmpName.Text + "%'";
                }

                if (pathEmpRelationbll == null)
                    pathEmpRelationbll = new PathEmpRelationBll();

                DataTable dt = pathEmpRelationbll.SelectPathEmpRelation(condition);

                SortDataGrid(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询条件错误，分站或探头地址应该为整数", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pbDept_Click(object sender, EventArgs e)
        {
            InitialzeDeptComboBox();
        }

        private void cbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            int deptId = Convert.ToInt32(cbDept.SelectedValue);
            InitialzeEmpComboBox(deptId);
        }


        private void bcpPrint_Click(object sender, EventArgs e)
        {
            //FormPrint frm = new FormPrint();
            //frm.CallPrintForm(this.dgvMain, "员工路线关系信息", "");
            KJ128NDBTable.PrintBLL.Print(this.dgvMain, "员工路线关系信息", "");
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
        /// 1表示 增加，修改 2 表示删除,3表示修改
        /// </summary>
        private int operated = 1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            //增加
            if (operated == 1)
            {
                timer1.Interval = 400;

                string strWhere = "PathNo='" + tbPathNo.Text
                    + "' and EmpNo='" + cbEmp.SelectedValue.ToString() + "'";

                if (RecordSearch.IsRecordExists("Path_Emp_Relation", strWhere))
                {
                    //刷新

                    InitialzeDataGridView();

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
            //删除
            else if (operated == 2)
            {
                timer1.Interval = 1000;

                string value = dgvMain.CurrentRow.Cells["Id"].Value.ToString();
                if (!RecordSearch.IsRecordExists("Path_Emp_Relation", "Id", value, DataType.String))
                {
                    //刷新

                    InitialzeDataGridView();

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
            //修改
            else
            {
                timer1.Interval = 400;

                string ID = dgvMain.CurrentRow.Cells["Id"].Value.ToString();
                string strWhere = "PathNo='" + tbPathNo.Text
                    + "' and EmpNo='" + cbEmp.SelectedValue.ToString()
                    + "' and Id=" + ID;

                if (RecordSearch.IsRecordExists("Path_Emp_Relation", strWhere))
                {
                    //刷新

                    InitialzeDataGridView();

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

        private void bcpRef_Click(object sender, EventArgs e)
        {
            InitialzeDataGridView();
        }
    }
}