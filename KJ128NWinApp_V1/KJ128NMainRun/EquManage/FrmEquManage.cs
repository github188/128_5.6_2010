using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDataBase;
using KJ128NInterfaceShow;
using KJ128NDBTable;
using Shine.Logs;
using Shine.Logs.LogType;

namespace KJ128NMainRun.EquManage
{
    public partial class FrmEquManage : Wilson.Controls.Docking.DockContent
    {
        EquBLL equDAL = new EquBLL();
        DataTable dtFactoryInfo = null;

        #region 初始化
        public FrmEquManage()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            // 绑定厂家名称
            BindFactoyName();

            // 绑定厂家名称信息
            BinddgvFactory();

            // 绑定设备信息
            BinddgvEqu();
        }
        #endregion 

        #region 设备信息操作

        #region 判断是否要添加生产厂家
        /// <summary>
        /// 判断是否要添加生产厂家
        /// </summary>
        /// <returns>true 有生产厂家存在</returns>
        public bool IsNotFactory()
        { 
            // 在没有添加生产厂家时添加或修改都会出现错误所以在添加和修改之前做出判断
            // 当有生产厂家存在时让其正常添加修改，否则让用户添加一个生产厂家
            bool bl = true;
            if (dtFactoryInfo.Rows.Count > 0)
            {
                bl = true;
            }
            else
            {
                bl = false;
            }
            return bl;
        }
        #endregion

        #region 绑定厂家名称
        // 绑定厂家名称
        public void BindFactoyName()
        {
            //cmbFactory.Items.Clear();
            DataTable  dt = equDAL.GetFactoryInfo();
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[2] = "所有";
            dt.Rows.InsertAt(dr, 0);
            cmbFactory.DataSource = dt;

            cmbFactory.DisplayMember = "FactoryName";
            cmbFactory.ValueMember = "FactoryID";

            cmbFactory.Text = "所有";
        }
        #endregion

        #region 初始化 dgvEqu （显示全部信息）

        public void BinddgvEqu()
        { 
            DataTable dt = equDAL.GetEquInfo();
            BinddgvEquInfo(dt);
            captionPanel1.CaptionTitle = "设备信息管理:\t共 " + dt.Rows.Count.ToString() + " 个设备";
        }

        /// <summary>
        /// 初始化 dgvEqu （显示全部信息）
        /// </summary>
        public void BinddgvEquInfo(DataTable dt)
        {
            dgvEqu.DataSource = dt;
            dgvEqu.Columns["EquID"].Visible = false;
            dgvEqu.Columns["EquNO"].HeaderText = "设备编号";
            dgvEqu.Columns["EquName"].HeaderText = "设备名称";
            dgvEqu.Columns["DeptID"].HeaderText = "所属部门";
            dgvEqu.Columns["EquType"].HeaderText = "设备类型";
            dgvEqu.Columns["EquState"].HeaderText = "设备状态";
            dgvEqu.Columns["FactoryID"].HeaderText = "生产厂家";
            dgvEqu.Columns["Remark"].HeaderText = "备  注";
            dgvEqu.Columns["EquNO"].Width = 50;
            dgvEqu.Columns["EquName"].Width = 60;
            if (dgvEqu.Columns["update"] == null)
            {
                DataGridViewLinkColumn colUpdateEqu = new DataGridViewLinkColumn();
                colUpdateEqu.Name = "update";
                colUpdateEqu.HeaderText = "修改";
                colUpdateEqu.Text = "修改";
                colUpdateEqu.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                colUpdateEqu.UseColumnTextForLinkValue = true;

                DataGridViewLinkColumn colDelEqu = new DataGridViewLinkColumn();
                colDelEqu.HeaderText = "删除";
                colDelEqu.Text = "删除";
                colDelEqu.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                colDelEqu.UseColumnTextForLinkValue = true;

                dgvEqu.Columns.Insert(8, colUpdateEqu);
                dgvEqu.Columns.Insert(9, colDelEqu);
            }
        }
        #endregion 

        #region 按钮事件

        #region 修改和删除
        // 修改和删除
        private void dgvEqu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                // 调用修改页面
                DataTable dt = equDAL.GetEquInfo(int.Parse(dgvEqu.Rows[e.RowIndex].Cells[2].Value.ToString()));
                DataTable dtDetail = equDAL.GetEquEqu_DetailInfo(int.Parse(dgvEqu.Rows[e.RowIndex].Cells[2].Value.ToString()));
                FrmEquEdit frm = new FrmEquEdit();
                frm.Text = "修改设备信息";
                if (IsNotFactory())
                {
                    frm.ShowDialog(dt, dtDetail);

                    // 重新绑定
                    BinddgvEqu();
                }
                else
                {
                    MessageBox.Show("请先添加生产厂家");
                    btnFactoryAdd_Click(sender, e);
                }
            }
            else if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {

                model = 1;

                // 删除
                if (MessageBox.Show("您确定要删除编号为【 " + dgvEqu.Rows[e.RowIndex].Cells[3].Value.ToString() + " 】的设备【 " + dgvEqu.Rows[e.RowIndex].Cells[4].Value.ToString() + " 】吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //存入日志
                    LogSave.Messages("[FrmEquManage]", LogIDType.UserLogID, "删除设备信息，生产厂家：" + dgvEqu.Rows[e.RowIndex].Cells[3].Value.ToString() + "，设备名称：" + dgvEqu.Rows[e.RowIndex].Cells[4].Value.ToString());

                    int intCount = equDAL.DelEqu_BaseInfo(int.Parse(dgvEqu.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    if (intCount == -1)
                    {
                        MessageBox.Show("删除失败");
                        return;
                    }

                    if (!New_DBAcess.IsDouble)
                    {
                        // 重新绑定
                        BinddgvEqu();
                    }
                    else
                    {
                        timer1.Stop();
                        timer1.Start();
                    }
                }
            }
        }

        #endregion 

        #region 添加
        // 添加
        private void btnEquAdd_Click(object sender, EventArgs e)
        {
            FrmEquEdit frm = new FrmEquEdit();
            frm.Text = "添加设备信息";
            if (IsNotFactory())
            {
                frm.ShowDialog(null, null);

                // 重新绑定
                BinddgvEqu();
            }
            else
            {
                MessageBox.Show("请先添加生产厂家");
                btnFactoryAdd_Click(sender, e);
            }
        }
        #endregion 

        #endregion

        #endregion 

        #region 工厂信息操作

        #region 初始化 dgvFactory （显示全部信息）

        public void BinddgvFactory()
        {
            dtFactoryInfo = equDAL.GetFactoryInfo();
            BinddgvFactoryInfo(dtFactoryInfo);
            buttonCaptionPanel2.CaptionTitle = "生产厂家信息:\t共 " + dtFactoryInfo.Rows.Count.ToString() + " 个";
        }

        // 初始化 dgvFactory （显示全部信息）
        public void BinddgvFactoryInfo(DataTable dt)
        {
            dgvFactory.DataSource = dt;

                // 隐藏一些不要显示的列 
                dgvFactory.Columns["FactoryID"].Visible = false;
                dgvFactory.Columns["FactoryNO"].HeaderText = "厂家编号";
                dgvFactory.Columns["FactoryName"].HeaderText = "厂家名称";
                dgvFactory.Columns["FactoryAddress"].HeaderText = "厂家地址";
                dgvFactory.Columns["FactoryFax"].HeaderText = "厂家传真";
                dgvFactory.Columns["FactoryTel"].HeaderText = "联系电话";
                dgvFactory.Columns["FactoryEmployee"].HeaderText = "联系人";
                dgvFactory.Columns["FactoryEmpoyeeTel"].HeaderText = "联系人电话";
                dgvFactory.Columns["Remark"].HeaderText = "备注";

                // 判断是否已经存在修改和删除两列
                if (dgvFactory.Columns["update"] == null)
                {

                    // 添加修改和删除
                    DataGridViewLinkColumn colUpdateFactory = new DataGridViewLinkColumn();
                    colUpdateFactory.Text = "修改";
                    colUpdateFactory.HeaderText = "修改";
                    colUpdateFactory.Name = "update";
                    colUpdateFactory.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    colUpdateFactory.UseColumnTextForLinkValue = true;

                    DataGridViewLinkColumn colDelFactory = new DataGridViewLinkColumn();
                    colDelFactory.Text = "删除";
                    colDelFactory.HeaderText = "删除";
                    colDelFactory.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    colDelFactory.UseColumnTextForLinkValue = true;
                    dgvFactory.Columns.Insert(9, colUpdateFactory);
                    dgvFactory.Columns.Insert(10, colDelFactory);
                }
        }
        #endregion 

        #region 修改和删除

        // 修改和删除
        private void dgvFactory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {

                
                // 调用修改页面

                // 传入要修改的那一条数据
                DataTable dt = equDAL.GetFactoryInfo(int.Parse(dgvFactory.Rows[e.RowIndex].Cells[2].Value.ToString()));
                FrmFactoryEdit frm = new FrmFactoryEdit();
                frm.Text = "修改厂家信息";
                frm.ShowDialog(dt);

                // 重新绑定
                BinddgvFactory();
                BinddgvEqu();
            }
            else if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {

                model = 2;

                // 删除
                if (MessageBox.Show("您确定要删除【 " + dgvFactory.Rows[e.RowIndex].Cells[4].Value.ToString() + " 】这个厂家吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //存入日志
                    LogSave.Messages("[FrmFactoryEdit]", LogIDType.UserLogID, "删除生产厂家信息，生产厂家编号：" + dgvFactory.Rows[e.RowIndex].Cells[2].Value.ToString()
                        + "，生产厂家名称：" + dgvFactory.Rows[e.RowIndex].Cells[4].Value.ToString());

                    // 删除这条记录
                    int int_isOk = equDAL.DelFactory(int.Parse(dgvFactory.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    //int_isOk 为1时删除成功
                    if (int_isOk == -1)
                    {
                        // 删除失败
                        MessageBox.Show("删除失败");
                        return;
                    }

                    if (!New_DBAcess.IsDouble)
                    {
                        // 重新绑定
                        BinddgvFactory();
                        BinddgvEqu();
                    }
                    else
                    {
                        timer1.Stop();
                        timer1.Start();
                    }
                }
            }

            BindFactoyName();
        }
        #endregion 

        #region 添加生产厂家
        // 添加生产厂家
        private void btnFactoryAdd_Click(object sender, EventArgs e)
        {
            FrmFactoryEdit frm = new FrmFactoryEdit();
            DataTable dt = null;
            int i = 0;
            frm.Text = "添加厂家信息";
            frm.ShowDialog(dt);

            // 重新绑定
            BinddgvFactory();
            BindFactoyName();
        }
        #endregion 

        #endregion 

        #region 查询 取消

        private void btnCanel_Click(object sender, EventArgs e)
        {
            // 查询 取消
            txtEquName.Text ="";
            //cmbFactory.Text = "不选择此项";
        }
        #endregion 

        #region 查询

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DataSet ds = equDAL.Equ_Query(txtEquName.Text,cmbFactory.SelectedValue.ToString() == "0"?"":cmbFactory.SelectedValue.ToString());
            // 绑定设备信息
            BinddgvEquInfo(ds.Tables[0]);
            captionPanel1.CaptionTitle = "设备信息管理:\t共 "+ds.Tables[0].Rows.Count.ToString()+" 个设备";
            // 绑定生产厂家
            //BinddgvFactoryInfo(ds.Tables[1]);
            //buttonCaptionPanel2.CaptionTitle = "设备信息管理:\t共 " + ds.Tables[1].Rows.Count.ToString() + " 个";
        }
        #endregion

        #region [ 事件: 设备信息导出Excel ]

        private void buttonCaptionPanel3_Click(object sender, EventArgs e)
        {
            ExcelExports.ExportDataGridViewToExcel(dgvEqu);
        }

        #endregion

        #region [ 事件: 生产厂家信息导出Excel ]

        private void buttonCaptionPanel4_Click(object sender, EventArgs e)
        {
            ExcelExports.ExportDataGridViewToExcel(dgvFactory);
        }

        #endregion

        private void bcpfaSelect_Click(object sender, EventArgs e)
        {
            DataSet ds = equDAL.Equ_Query(txtEquName.Text, cmbFactory.SelectedValue.ToString() == "0" ? "" : cmbFactory.SelectedValue.ToString());
            BinddgvFactoryInfo(ds.Tables[1]);
            buttonCaptionPanel2.CaptionTitle = "设备信息管理:\t共 " + ds.Tables[1].Rows.Count.ToString() + " 个";
        }

        private void bcpCancel_Click(object sender, EventArgs e)
        {
            //txtEquName.Text = "";
            cmbFactory.Text = "所有";
        }



        #region[热备刷新]
 
        private int model = 1;


        private int time = 0;

        private int maxTimes = 2;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (model == 1)
            {
                if (time < maxTimes)
                {
                    time++;

                    //刷新

                    BinddgvEqu();
                }
                else
                {
                    time = 0;
                    timer1.Stop();
                }
            }
            else
            {
                if (time < maxTimes)
                {
                    time++;

                    //刷新
                    BinddgvFactory();
                    BinddgvEqu();
                }
                else
                {
                    time = 0;
                    timer1.Stop();
                }
            }
        }

        #endregion

        #region [ 事件: 刷新设备信息 ]

        private void buttonCaptionPanel5_Click(object sender, EventArgs e)
        {
            BinddgvEqu();
        }
        #endregion

        #region [ 事件: 刷新生产厂家 ]

        private void buttonCaptionPanel6_Click(object sender, EventArgs e)
        {
            //刷新
            BinddgvFactory();
            BinddgvEqu();
        }

        #endregion
    }
}