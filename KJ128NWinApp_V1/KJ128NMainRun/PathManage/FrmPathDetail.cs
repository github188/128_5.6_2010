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
    public partial class FrmPathDetail : Wilson.Controls.Docking.DockContent
    {

        #region [构造函数]

        public FrmPathDetail()
        {
            InitializeComponent();
        }

        #endregion

        #region [字段]

        private PathInfoBll pathInfoBll = new PathInfoBll();

        private PathDetailBll pathDetailBll = new PathDetailBll();

        DataTable dtStation = null;

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
            this.tbPathNum.Text = tvMain.SelectedNode.Name;
            this.tbPathN.Text = tvMain.SelectedNode.Text;

            //初始化分站信息ComboBox
            InitialzeStationComboBox();

            this.bcpAdd.CaptionTitle = "增加接收器信息";
            this.btnAddOrEdit.CaptionTitle = "增加";

        }

        /// <summary>
        /// 初始化修改
        /// </summary>
        private void InitialzeUpdate()
        {
            this.tbPathNum.Text = dgvMain.CurrentRow.Cells["PathNo"].Value.ToString();
            this.tbPathN.Text = dgvMain.CurrentRow.Cells["PathName"].Value.ToString();

            this.bcpAdd.CaptionTitle = "修改接收器信息";
            this.btnAddOrEdit.CaptionTitle = "修改";

            //初始化分站信息ComboBox
            InitialzeStationComboBox();

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
                node.ToolTipText =  "路线编号:" + dr["PathNo"].ToString() + "\n"
                    + "路线名:" + dr["PathName"].ToString() + "\n"
                    + "备注:" + dr["Remark"].ToString();

                tvMain.Nodes[0].Nodes.Add(node);
            }

            this.tvMain.ExpandAll();
        }

        /// <summary>
        /// 加载分站ComboBox
        /// </summary>
        private void InitialzeStationComboBox()
        {
            if (dtStation == null)
                dtStation = GetStationInfo();

            //加载列表
            cbstation.DisplayMember = "StationPlace";
            cbstation.ValueMember = "StationAddress";

            cbstation.DataSource = dtStation;
            if (dtStation.Rows.Count > 0)
            {
                cbstation.SelectedIndex = 0;
            }

        }

        /// <summary>
        /// 加载接收器ComboBox
        /// </summary>
        private void InitialzePointComboBox(int stationAddress)
        {
            DataTable dt = DataHelper.GetPointInfo(stationAddress);

            cbPiont.DisplayMember = "StationHeadPlace";
            cbPiont.ValueMember = "StationHeadAddress";
            cbPiont.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                cbPiont.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 按一定的查询条件获得数据表
        /// </summary>
        /// <param name="condition"> 查询条件，如果condition为空，表示全部查找</param>
        /// <returns>数据表</returns>
        private DataTable GetDataTable(string condition)
        {
            DataTable dt = pathDetailBll.SelectPathDetail(condition);
            return dt;
        }

        /// <summary>
        /// 获取分站信息，用于绑定ComboBox
        /// </summary>
        /// <returns>分站表</returns>
        private DataTable GetStationInfo()
        {
            DataTable dt = DataHelper.GetStationInfo();
            
            return dt;
        }

        /// <summary>
        /// 获取接收器信息，用于绑定ComboBox
        /// </summary>
        /// <param name="tationAddress">分站地址，根据分站地址获取接收器信息</param>
        /// <returns>接收器表</returns>
        private DataTable GetPointInfo(int stationAddress)
        {
            DataTable dt = DataHelper.GetPointInfo(stationAddress);

            return dt;
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
                
                MessageBox.Show("请在左边选择要添加接收器的路线", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                    int result = AddPathDetailInfo();
                    if (result == 1)
                    {
                        
                        
                        if (pathDetailBll == null)
                            pathDetailBll = new PathDetailBll();

                        MessageBox.Show("增加信息成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (!New_DBAcess.IsDouble)
                        {
                            DataTable dt = pathDetailBll.SelectPathDetail("");

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

                    int result = UpdatePathDetailInfo();
                    if (result == 1)
                    {
                        if (pathDetailBll == null)
                            pathDetailBll = new PathDetailBll();
                        MessageBox.Show("修改信息成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (!New_DBAcess.IsDouble)
                        {
                            DataTable dt = pathDetailBll.SelectPathDetail("");

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
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPathDetail_Load(object sender, EventArgs e)
        {
            //加载树
            InitialzeTreeView();

            //加载DataGrid
            InitialzeDataGridView();
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

        private void bcpSearch_Click(object sender, EventArgs e)
        {

            try
            {
                string condition = String.Empty;

                if (tbPathNo.Text.Trim() != "")
                {
                    condition = "pd.PathNo like '%" + tbPathNo.Text + "%'";
                }
                else
                {
                    condition = "1=1";
                }

                if (tbStationAddress.Text.Trim() != "")
                {
                    condition += "and pd.StationAddress like '%" + Convert.ToInt32(tbStationAddress.Text).ToString() + "%'";
                }

                if (tbPointAddress.Text.Trim() != "")
                {
                    condition += "and pd.StationHeadAddress like '%" + Convert.ToInt32(tbPointAddress.Text).ToString() + "%'";
                }

                if (pathDetailBll == null)
                    pathDetailBll = new PathDetailBll();

                DataTable dt = pathDetailBll.SelectPathDetail(condition);

                SortDataGrid(dt);
            }
            catch( Exception ex)
            {
                MessageBox.Show("查询条件错误，分站或接收器地址应该为整数",ex.Message,MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 根据Station选择的项，加载Point信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbstation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int stationAddress = Convert.ToInt32(cbstation.SelectedValue);
            InitialzePointComboBox(stationAddress);
            //MessageBox.Show(cbstation.SelectedValue + "----" + cbstation.Text);
        }

        private void cbPiont_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cbPiont.SelectedValue + "----" + cbPiont.Text);
        }

        /// <summary>
        /// 绑定Station信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbStation_Click(object sender, EventArgs e)
        {
            dtStation = GetStationInfo();

            //绑定分站信息
            InitialzeStationComboBox();
        }

        /// <summary>
        /// 绑定Point信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbPoint_Click(object sender, EventArgs e)
        {
            if (cbstation.SelectedItem != null)
            {
                int stationAddress = Convert.ToInt32(cbstation.SelectedValue);

                //绑定接收器信息
                InitialzePointComboBox(stationAddress);
            }
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
                        DialogResult dr =  MessageBox.Show("您确认要删除这条记录？","确认提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            operated = 2;

                            //存入日志
                            LogSave.Messages("[FrmPathDetail]", LogIDType.UserLogID, "删除路径详细信息，路线编号：" + dgvMain.CurrentRow.Cells["PathNo"].Value.ToString()
                                + "，分站安装位置：" +this.cbstation.SelectedText + "，接收器位置：" + this.cbPiont.SelectedText + "。");

                            int id = Convert.ToInt32(dgvMain.CurrentRow.Cells["Id"].Value.ToString());

                            int count =  pathDetailBll.DeletePathDetail(id);

                            bool flag = (count == 1 ? true : false);

                            if (flag)
                            {
                                //刷新界面

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
        /// 增加PathDetail信息
        /// </summary>
        /// <returns>返回操作结果 返回操作结果 1表示成功</returns>
        private int AddPathDetailInfo()
        {
            try
            {
                //Serial_Path_Detail serialPathDetail = new Serial_Path_Detail();

                //serialPathDetail.Operate = 1;
                //serialPathDetail.TableName = "Path_Detail";
                //serialPathDetail.PathNo = this.tbPathNum.Text;
                //serialPathDetail.StationAddress = Convert.ToInt32(this.cbstation.SelectedValue);
                //serialPathDetail.StationHeadAddress = Convert.ToInt32(this.cbPiont.SelectedValue);

                //bool flag = KJ128Nsad.DataReceived(KJ128Nsad.SerialOperate(serialPathDetail));

                //存入日志
                LogSave.Messages("[FrmPathDetail]", LogIDType.UserLogID, "添加路径详细信息，路线编号："+tbPathNum.Text
                    +"，分站安装位置："+this.cbstation.SelectedText+"，接收器位置："+this.cbPiont.SelectedText+"。");

                PathDetailModel model = new PathDetailModel();

                model.PathNo = this.tbPathNum.Text;
                model.StationAddress = Convert.ToInt32(this.cbstation.SelectedValue); 
                model.StationHeadAddress = Convert.ToInt32(this.cbPiont.SelectedValue);

                int count = pathDetailBll.InsertPathDetail(model);

                bool flag = (count == 1 ? true : false);

                if (flag)
                {
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
        /// 修改PathDetail信息
        /// </summary>
        /// <returns>返回操作结果 1表示成功</returns>
        private int UpdatePathDetailInfo()
        {
            try
            {
                //Serial_Path_Detail serialPathDetail = new Serial_Path_Detail();

                //serialPathDetail.Operate = 2;
                //serialPathDetail.TableName = "Path_Detail";
                //serialPathDetail.Id = Convert.ToInt32(dbgvMain.CurrentRow.Cells["Id"].Value.ToString());
                //serialPathDetail.PathNo = dbgvMain.CurrentRow.Cells["PathNo"].Value.ToString();
                //serialPathDetail.StationAddress = Convert.ToInt32(this.cbstation.SelectedValue);
                //serialPathDetail.StationHeadAddress = Convert.ToInt32(this.cbPiont.SelectedValue);

                //bool flag = KJ128Nsad.DataReceived(KJ128Nsad.SerialOperate(serialPathDetail));


                PathDetailModel model = new PathDetailModel();

                model.Id = Convert.ToInt32(dgvMain.CurrentRow.Cells["Id"].Value.ToString());
                model.PathNo = this.tbPathNum.Text;
                model.StationAddress = Convert.ToInt32(this.cbstation.SelectedValue);
                model.StationHeadAddress = Convert.ToInt32(this.cbPiont.SelectedValue);

                //存入日志
                LogSave.Messages("[FrmPathDetail]", LogIDType.UserLogID, "修改路径详细信息，路线编号：" + model.PathNo
                    + "，分站安装位置：" + this.cbstation.SelectedText + "，接收器位置：" + this.cbPiont.SelectedText + "。");

                int count = pathDetailBll.UpdatePathDetail(model);

                bool flag = (count == 1 ? true : false);

                if (flag)
                {
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
            if (cbstation.Text.Trim() == "")
            {
                MessageBox.Show("分站地点不要为空","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return false;
            }

            if (cbPiont.Text.Trim() == "")
            {
                MessageBox.Show("接收器地点不要为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void dbgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (vspnlAdd.Visible == true && bcpAdd.CaptionTitle == "修改接收器信息")
                {
                    tbPathNum.Text = dgvMain.CurrentRow.Cells["PathNo"].Value.ToString();
                    tbPathN.Text = dgvMain.CurrentRow.Cells["PathName"].Value.ToString();
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
            this.dgvMain.Columns["PathNo"].HeaderText  = "路线编号";
            this.dgvMain.Columns["PathName"].HeaderText = "路线名称";




            //this.dbgvMain.Columns["Id"].DisplayIndex = 0;
            //this.dbgvMain.Columns["PathNo"].DisplayIndex = 1;
            //this.dbgvMain.Columns["PathName"].DisplayIndex = 2;
            //this.dbgvMain.Columns["StationAddress"].DisplayIndex = 3;
            //this.dbgvMain.Columns["StationPlace"].DisplayIndex = 4;
            //this.dbgvMain.Columns["StationHeadAddress"].DisplayIndex = 5;
            //this.dbgvMain.Columns["StationHeadPlace"].DisplayIndex = 6;
            //this.dbgvMain.Columns["edit"].DisplayIndex = 7;
            //this.dbgvMain.Columns["delete"].DisplayIndex = 8;

            //更改名称,基站->分站 等
            this.dgvMain.Columns["StationAddress"].HeaderText = HardwareName.Value(CorpsName.StationAddress);
            this.dgvMain.Columns["StationPlace"].HeaderText = HardwareName.Value(CorpsName.StationSplace);
            this.dgvMain.Columns["StationHeadAddress"].HeaderText = HardwareName.Value(CorpsName.StaHeadAddress);
            this.dgvMain.Columns["StationHeadPlace"].HeaderText = HardwareName.Value(CorpsName.StaHeadSplace);


        }

        private void tvMain_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Node.Nodes.Count < 1)
            {
                //MessageBox.Show(e.Node.Name);

                string pathNo = e.Node.Name;
                if (pathDetailBll == null)
                    pathDetailBll = new PathDetailBll();

                string condition = "pd.PathNo='" + pathNo + "'";

                DataTable dt = pathDetailBll.SelectPathDetail(condition);
                SortDataGrid(dt);
            }

            
        }

        private void bcpPrint_Click(object sender, EventArgs e)
        {
            //FormPrint frm = new FormPrint();
            //frm.CallPrintForm(this.dgvMain, "路线详细信息", "");
            KJ128NDBTable.PrintBLL.Print(this.dgvMain, "路线详细信息", "");
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

                //刷最大次数(两次)
                if (times < maxTimes)
                {
                    times++;

                    //刷新
                    InitialzeDataGridView();
                }
                else
                {
                    times = 0;
                    timer1.Stop();
                }
            }
                //删除
            else if (operated == 2)
            {
                if (times < maxTimes)
                {

                    timer1.Interval = 1000;
                    times++;

                    InitialzeDataGridView();

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
                //修改
            else
            {
                timer1.Interval = 400;

                string ID = dgvMain.CurrentRow.Cells["Id"].Value.ToString();
                string strWhere = "PathNo='" + tbPathNum.Text 
                    + "' and StationAddress="+ cbstation.SelectedValue.ToString()
                    + " and StationHeadAddress="+ cbPiont.SelectedValue.ToString()
                    + " and Id=" + ID;

                if (RecordSearch.IsRecordExists("Path_Detail", strWhere))
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
        }

        #endregion        

        private void bcpRef_Click(object sender, EventArgs e)
        {
            InitialzeDataGridView();
        }
    }
}