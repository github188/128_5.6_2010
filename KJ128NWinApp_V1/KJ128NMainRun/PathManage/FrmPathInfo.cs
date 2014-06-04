using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using KJ128NModel;
using System.Text;
using System.Windows.Forms;
using KJ128NInterfaceShow;
using ZdcCommonLibrary;
using KJ128WindowsLibrary;
using KJ128NDBTable;
using Shine.Logs;
using Shine.Logs.LogType;
using PrintCore;
using KJ128NDataBase;


namespace KJ128NMainRun.PathManage
{
    public partial class FrmPathInfo : Wilson.Controls.Docking.DockContent
    {
        #region [构造函数]

        public FrmPathInfo()
        {
            InitializeComponent();
        }

        #endregion

        #region [字段]

        private PathInfoBll infoBll = new PathInfoBll();

        //private KJ128NSerialAndDeserial KJ128Nsad = new KJ128NSerialAndDeserial();

        #endregion

        #region [私有方法]

        #region [增加修改操作]

        /// <summary>
        /// 关闭隐藏面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcpAdd_CloseButtonClick(object sender, EventArgs e)
        {
            this.vspnlAdd.Visible = false;
        }

        /// <summary>
        /// 点击"新增线路",显示操作面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcpNew_Click(object sender, EventArgs e)
        {
            InitializeToNew();
        }

        /// <summary>
        /// 点击"新增线路"，初始化新增信息状态
        /// </summary>
        private void InitializeToNew()
        {
            this.lblPathId.Visible = false;
            this.tbPathId.Visible = false;
            this.btnAddNew.Visible = true;
            this.tbPathNo.Text = "";
            this.tbPathName.Text = "";
            this.tbRemark.Text = "";
            this.btnAddNew.CaptionTitle = "保存并新增";
            this.btnAdd.CaptionTitle = "保存";
            this.bcpAdd.CaptionTitle = "增加线路信息";
            this.vspnlAdd.Visible = true;
        }

        /// <summary>
        /// 修改路线信息时，初始化修改信息状态
        /// </summary>
        /// <param name="pachinfo"></param>
        private void InitializeToUpdate(PathInfoModel pathInfo)
        {
            if (pathInfo != null)
            {
                //this.lblPathId.Visible = true;
                //this.tbPathId.Visible = true;
                this.btnAddNew.Visible = false;
                this.tbPathId.Text = pathInfo.Id.ToString();
                this.tbPathNo.Text = pathInfo.PathNo.ToString();
                this.tbPathName.Text = pathInfo.PathName;
                this.tbRemark.Text = pathInfo.Remark;
                this.bcpAdd.CaptionTitle = "修改线路信息";
                this.btnAdd.CaptionTitle = "修改";
                this.vspnlAdd.Visible = true;
            }
        }

        /// <summary>
        /// 点击 "增加" "修改" 前对数据的检查
        /// </summary>
        /// <returns>是否验证通过</returns>
        private bool CheckValue()
        {
            try
            {
                //if (tbPathId.Text.Trim() == "")
                //{
                //    MessageBox.Show("线路Id不能为空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return false;
                //}

                if (tbPathNo.Text.Trim() == "")
                {
                    MessageBox.Show("线路编号不能为空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (tbPathName.Text.Trim() == "")
                {
                    MessageBox.Show("线路名不能为空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                return true;
            }
            catch (FormatException fe)
            {
                MessageBox.Show("检查线路Id是否为整数", fe.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// 添加和修改PathInfo信息（添加）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValue())
                {
                    operated = 1;

                    //增加信息
                    if (btnAdd.CaptionTitle == "保存")
                    {
                        //MessageBox.Show("保存");

                        pathnum = tbPathNo.Text;

                        int result = AddPathInfoModel();

                        if (result > 0)
                        {
                            vspnlAdd.Visible = false;
                            MessageBox.Show("添加信息成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (!New_DBAcess.IsDouble)
                            {
                                InitializeTreeView("");

                                InitializeGridView("");
                            }
                            else
                            {
                                timer1.Start();
                            }
                        }
                        else
                        {
                            MessageBox.Show("添加信息失败,记录已经存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                    //修改信息
                    else if (btnAdd.CaptionTitle == "修改")
                    {
                        pathnum = tbPathNo.Text;

                        int result = UpdatePathInfoModel();

                        if (result > 0)
                        {
                            vspnlAdd.Visible = false;
                            MessageBox.Show("修改信息成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (!New_DBAcess.IsDouble)
                            {
                                InitializeTreeView("");

                                InitializeGridView("");
                            }
                            else
                            {
                                timer1.Start();
                            }
                        }
                        else
                        {
                            MessageBox.Show("修改信息失败,记录已经存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "出错提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 添加和修改PathInfo信息（添加并新增）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValue())
                {
                    if (btnAddNew.CaptionTitle == "保存并新增")
                    {

                        operated = 1;

                        int result = AddPathInfoModel();

                        pathnum = tbPathNo.Text;

                        if (result > 0)
                        {
                            MessageBox.Show("添加信息成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);



                            InitializeToNew();

                            if (!New_DBAcess.IsDouble)
                            {
                                InitializeTreeView("");

                                InitializeGridView("");
                            }
                            else
                            {
                                timer1.Start();
                            }
                        }
                        else
                        {
                            MessageBox.Show("添加信息失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "出错提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 增加信息
        /// </summary>
        /// <returns></returns>
        private int AddPathInfoModel()
        {
            try
            {

                //Serial_Path_Info serialPathInfo = new Serial_Path_Info();

                //serialPathInfo.Operate = 1;
                //serialPathInfo.TableName = "Path_Info";
                //serialPathInfo.PathNo = this.tbPathNo.Text;
                //serialPathInfo.PathName = this.tbPathName.Text;
                //serialPathInfo.Remark = this.tbRemark.Text;

                //bool flag = KJ128Nsad.DataReceived(KJ128Nsad.SerialOperate(serialPathInfo));

                //存入日志
                LogSave.Messages("[FrmPathInfo]", LogIDType.UserLogID, "添加路径基本信息，路线编号：" + this.tbPathNo.Text + "，路线名：" + this.tbPathName.Text + "。");


                KJ128NModel.PathInfoModel model = new PathInfoModel();
                model.PathNo = this.tbPathNo.Text;
                model.PathName = this.tbPathName.Text;
                model.Remark = this.tbRemark.Text;
                string strMessage="";
                 int count = infoBll.InsertPathInfo(model,out strMessage);

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
        /// 修改信息
        /// </summary>
        /// <returns></returns>
        private int UpdatePathInfoModel()
        {
            try
            {

                //Serial_Path_Info serialPathInfo = new Serial_Path_Info();

                //serialPathInfo.Operate = 2;
                //serialPathInfo.TableName = "Path_Info";
                //serialPathInfo.Id = Convert.ToInt32(this.tbPathId.Text.Trim());
                //serialPathInfo.PathNo = this.tbPathNo.Text;
                //serialPathInfo.PathName = this.tbPathName.Text;
                //serialPathInfo.Remark = this.tbRemark.Text;

                //bool flag = KJ128Nsad.DataReceived(KJ128Nsad.SerialOperate(serialPathInfo));

                //存入日志
                LogSave.Messages("[FrmPathInfo]", LogIDType.UserLogID, "修改路径基本信息，路线编号：" + this.tbPathNo.Text + "，路线名：" + this.tbPathName.Text + "。");

                KJ128NModel.PathInfoModel model = new PathInfoModel();
                model.Id = Convert.ToInt32(this.tbPathId.Text.Trim());
                model.PathNo = this.tbPathNo.Text;
                model.PathName = this.tbPathName.Text;
                model.Remark = this.tbRemark.Text;
                string strMessage = "";
                int count = infoBll.UpdatePathInfo(model,out strMessage);

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

        #endregion

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

        #region [取数据和刷新界面]

        /// <summary>
        /// 获取PathInfo信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>查询到的表</returns>
        private DataTable GetPathInfo(string condition)
        {
            if (infoBll == null)
                infoBll = new PathInfoBll();

            DataTable dt = infoBll.SelectPathInfo(condition);

            return dt;
        }

        /// <summary>
        /// 填充树形控件
        /// </summary>
        private void InitializeTreeView(string condition)
        {
            try
            {
                //清楚树
                tvPathInfo.Nodes[0].Nodes.Clear();

                DataTable dt = GetPathInfo(condition);

                foreach (DataRow dr in dt.Rows)
                {
                    TreeNode node = new TreeNode(dr["PathName"].ToString());

                    node.Name = dr["Id"].ToString();

                    node.Text = dr["PathName"].ToString();

                    node.ToolTipText = "路线编号:" + dr["PathNo"].ToString() + "\n"
                        + "路线名:" + dr["PathName"].ToString() + "\n"
                        + "路线备注：" + dr["Remark"].ToString();
                    tvPathInfo.Nodes[0].Nodes.Add(node);
                }

                tvPathInfo.ExpandAll();
            }
            catch
            {
                MessageBox.Show("加载路线树信息失败", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 填充DataGridView
        /// </summary>
        private void InitializeGridView(string condition)
        {
            DataTable dt = GetPathInfo(condition);
            this.dgvMain.DataSource = dt;
            dgvMain.Columns["PathName"].DisplayIndex = 2;
        }

        /// <summary>
        /// 刷新树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcpRefresh_Click(object sender, EventArgs e)
        {
            InitializeTreeView("");

            InitializeGridView("");
        }

        #endregion

        #region [窗体加载时加载信息]

        private void FrmPathInfo_Load(object sender, EventArgs e)
        {
            //加载树
            InitializeTreeView("");

            //加载DataGrid
            InitializeGridView("");

        }

        #endregion

        #region [查找按钮功能]

        /// <summary>
        /// 查找方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSerch_Click(object sender, EventArgs e)
        {
            try
            {
                string condition = String.Empty;

                if (tbpId.Text.Trim() != "")
                {
                    condition = "Id like '%" + tbpId.Text + "%'";
                }
                else
                {
                    condition = "1=1";
                }
                if (tbpNo.Text.Trim() != "")
                {
                    condition += " and PathNo like '%" + tbpNo.Text + "%'";
                }

                if (tbpName.Text.Trim() != "")
                {
                    condition += " and PathName like '%" + tbpName.Text + "%'";
                }

                if (tbpRemark.Text.Trim() != "")
                {
                    condition += " and Remark like '%" + tbpRemark.Text + "%'";
                }

                if (infoBll == null)
                    infoBll = new PathInfoBll();
                DataTable dt = infoBll.SelectPathInfo(condition);

                this.dgvMain.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("查找条件错误，未能查询到数据", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region [调修改界面，实际删除]

        /// <summary>
        /// 单击DataGridView的修改和删除操作
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
                    PathInfoModel info = new PathInfoModel();

                    info.Id = Convert.ToInt32(dgvMain.CurrentRow.Cells["PathId"].Value.ToString());
                    info.PathNo = dgvMain.CurrentRow.Cells["PathNo"].Value.ToString();
                    info.PathName = dgvMain.CurrentRow.Cells["PathName"].Value.ToString();
                    info.Remark = dgvMain.CurrentRow.Cells["Remark"].Value.ToString();

                    InitializeToUpdate(info);
                }

                else if (operate == "删除")
                {
                    operated = 2;

                    try
                    {
                        this.vspnlAdd.Visible = false;

                        DialogResult dr = MessageBox.Show("您是否确认删除？如果确认将会删除与其相关联的数据，无法恢复", "重要确认提示",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            //存入日志
                            LogSave.Messages("[FrmPathInfo]", LogIDType.UserLogID, "删除路径基本信息，路线编号：" + dgvMain.CurrentRow.Cells["PathNo"].Value.ToString()
                                + "，路线名：" + dgvMain.CurrentRow.Cells["PathName"].Value.ToString() + "。");

                            ////Serial_Path_Info serialPathInfo = new Serial_Path_Info();

                            ////serialPathInfo.Operate = 3;
                            ////serialPathInfo.TableName = "Path_Info";
                            ////serialPathInfo.Id = Convert.ToInt32(dbgvMain.CurrentRow.Cells["PathId"].Value.ToString());

                            ////bool flag = KJ128Nsad.DataReceived(KJ128Nsad.SerialOperate(serialPathInfo));
                            //(count == 1 ? true : false);
                            int id = Convert.ToInt32(dgvMain.CurrentRow.Cells["PathId"].Value.ToString());

                            int count = infoBll.DeletePathInfo(id);

                            bool flag = (count == 1 ? true : false);

                            if (flag)
                            {
                                if (!New_DBAcess.IsDouble)
                                {
                                    InitializeTreeView("");
                                    InitializeGridView("");
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
                        MessageBox.Show("删除失败:" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        private void bcpPrint_Click(object sender, EventArgs e)
        {
            //FormPrint frm = new FormPrint();
            //frm.CallPrintForm(this.dgvMain,"路线基本信息","");
            KJ128NDBTable.PrintBLL.Print(this.dgvMain, "路线基本信息", "");
        }

        private void cpnlTile_Load(object sender, EventArgs e)
        {

        }

        private void pnlSerach_Paint(object sender, PaintEventArgs e)
        {

        }

        #region [树操作]
        //private void tvPathInfo_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        if (e.Node.Parent == null)
        //        {
        //            MessageBox.Show("根极点");
        //        }
        //        else
        //        {
        //            MessageBox.Show(e.Node.Name.ToString());
        //        }
        //    }
        //}
        #endregion

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
        private int operated = 1;

        private string pathnum = ""; 

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (operated == 1)
            {
                if (RecordSearch.IsRecordExists("Path_Info", "PathNo", pathnum, DataType.String))
                {
                    //刷新

                    InitializeTreeView("");

                    InitializeGridView("");

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
            else
            {
                string value = dgvMain.CurrentRow.Cells["PathNo"].Value.ToString();

                if (!RecordSearch.IsRecordExists("Path_Info", "PathNo", value, DataType.String))
                {
                    //刷新

                    InitializeTreeView("");

                    InitializeGridView("");

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
            InitializeTreeView("");
            InitializeGridView("");
        }
    }
}