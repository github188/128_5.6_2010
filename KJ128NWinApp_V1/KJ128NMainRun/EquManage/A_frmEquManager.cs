using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NMainRun.FromModel;
using KJ128NDBTable;
using KJ128NDataBase;

namespace KJ128NMainRun.EquManage
{
    public partial class A_frmEquManager : FrmModel
    {

        #region【声明】

        private A_EquBLL bll = new A_EquBLL();

        private bool isEqu = true;

        private string strFactoryTree = "all";

        private string strEquTree = "";


        public string strUpDateFactoryID = "-1";

        public string strUpDateEquID = "-1";

        #endregion

        #region【构造函数】

        public A_frmEquManager()
        {
            InitializeComponent();
            this.drawerLeftMain.Add(pnlEqu, true);
            this.drawerLeftMain.Add(pnlFactory);
            this.drawerLeftMain.LeftPartResize();
        }

        #endregion

        #region【窗体加载】

        private void A_frmEquManager_Load(object sender, EventArgs e)
        {
            Refresh_Equ();
        }

        #endregion

        #region【事件：抽屉事件——设备】

        private void btnEqu_Click(object sender, EventArgs e)
        {
            this.drawerLeftMain.ButtonClick(pnlEqu.Name);
            this.trvEqu.SelectedNode = trvEqu.Nodes[0];
            trvEqu_AfterSelect(this, new TreeViewEventArgs(this.trvEqu.SelectedNode));
            isEqu = true;
            LoadTree();
        }

        #endregion

        #region【事件：抽屉事件——生产厂家】

        private void btnFactory_Click(object sender, EventArgs e)
        {
            this.drawerLeftMain.ButtonClick(pnlFactory.Name);
            this.trvFactory.SelectedNode = trvFactory.Nodes[0];
            trvFactory_AfterSelect(this, new TreeViewEventArgs(this.trvFactory.SelectedNode));
            isEqu = false;
            LoadTree();
        }

        #endregion

        #region【方法：加载树】

        private void LoadTree()
        {
            trvEqu.Nodes.Clear();
            trvEqu.Nodes.Add("all", "设备");
            DataTable equdt = bll.GetEquTypes();
            for (int i = 0; i < equdt.Rows.Count; i++)
            {
                trvEqu.Nodes[0].Nodes.Add(equdt.Rows[i][1].ToString(), equdt.Rows[i][0].ToString());
            }
            trvEqu.Nodes[0].Expand();
            trvFactory.Nodes.Clear();
            trvFactory.Nodes.Add("all", "所有");
            DataTable factorydt = bll.GetFactoryNames();
            for (int i = 0; i < factorydt.Rows.Count; i++)
            {
                trvFactory.Nodes[0].Nodes.Add(factorydt.Rows[i][1].ToString(), factorydt.Rows[i][0].ToString());
            }
            trvFactory.Nodes[0].Expand();
        }

        #endregion

        #region【方法：刷新——设备】

        public void Refresh_Equ()
        {
            //trvEqu_AfterSelect(this, new TreeViewEventArgs(this.trvEqu.SelectedNode));
            Select_Equ();
            LoadTree();
        }

        #endregion


        #region【方法：刷新——生产厂家】

        public void Refresh_Factory()
        {
            Select_Factory();
            LoadTree();
        }

        #endregion

        #region【方法：查询——设备】

        private void Select_Equ()
        {
            DataTable dt = bll.GetEquInfo(strEquTree);
            dt.TableName = "A_FrmEquManager_equ";
            dgv.DataSource = dt;

            //int width = (dgv.Width - 50 - 2) / (dgv.Columns.Count - 1);
            for (int i = 1; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].ReadOnly = false;
                //dgv.Columns[i].Width = width;
            }

            if (dgv.Columns.Contains("EquID"))
            {
                dgv.Columns["EquID"].Visible = false;
            }

            lblCounts.Text = "共 " + dt.Rows.Count.ToString() + " 条记录";
            if (btnSelectAll.Text.Equals("取消"))
            {
                btnSelectAll.Text = "全选";
            }
        }

        #endregion

        #region【方法：查询——生产厂家】

        private void Select_Factory()
        {
            DataTable dt = bll.GetFactoryInfo(strFactoryTree);
            dt.TableName = "A_FrmEquManager_Man";
            dgv.DataSource = dt;

            //int width = (dgv.Width - 50 - 2) / (dgv.Columns.Count - 1);
            for (int i = 1; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].ReadOnly = false;
                //dgv.Columns[i].Width = width;
            }
            if (dgv.Columns.Contains("FactoryID"))
            {
                dgv.Columns["FactoryID"].Visible = false;
            }
            lblCounts.Text = "共 " + dt.Rows.Count.ToString() + " 条记录";
            if (btnSelectAll.Text.Equals("取消"))
            {
                btnSelectAll.Text = "全选";
            }

        }

        #endregion

        #region【事件：选择生产厂家（树）】

        private void trvFactory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvFactory.SelectedNode != null)
            {
                strFactoryTree = trvFactory.SelectedNode.Name;
                Select_Factory();
            }
        }

        #endregion

        #region【事件：选择设备（树）】

        private void trvEqu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvEqu.SelectedNode != null)
            {
                strEquTree = trvEqu.SelectedNode.Text;
                Select_Equ();
            }
        }

        #endregion


        #region【事件：新增】

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isEqu)
            {
                A_frmAddEqu addequ = new A_frmAddEqu(this);
                addequ.ShowDialog();
            }
            else
            {
                A_frmAddFactory f = new A_frmAddFactory(this);
                f.ShowDialog();
            }
            //Flash();
        }

        #endregion

        #region【刷新】

        private Timer t = null;
        private int FlashNum = 0;
        public void Flash()
        {
            if (!New_DBAcess.IsDouble)          //单机版，直接刷新
            {
                if (isEqu)
                {
                    Refresh_Equ();
                }
                else
                {
                    Refresh_Factory();
                }
            }
            else                                //热备版，启用定时器
            {
                FlashNum = KJ128NInterfaceShow.RefReshTime.intHostBackRefCount;
                int interval = KJ128NInterfaceShow.RefReshTime.intHostBackRefTime;
                if (t == null)
                {
                    t = new Timer();
                }
                t.Interval = interval;
                t.Tick += new EventHandler(t_Tick);
                t.Start();
            }
        }

        void t_Tick(object sender, EventArgs e)
        {
            if (FlashNum > 0)
            {
                FlashNum--;
                if (isEqu)
                {
                    //btnEqu_Click(this, new EventArgs());
                    Refresh_Equ();
                }
                else
                {
                    //btnFactory_Click(this, new EventArgs());
                    Refresh_Factory();
                }
            }
            else
            {
                t.Stop();
            }
        }

        #endregion

        #region【事件：全选】

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                if (btnSelectAll.Text == "全选")
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells["Column1"].Value = true;
                    }
                    btnSelectAll.Text = "取消";
                }
                else
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells["Column1"].Value = false;
                    }
                    btnSelectAll.Text = "全选";
                }
            }
        }

        #endregion

        #region【事件：删除】

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int num = 0;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells["Column1"].Value != null && dgv.Rows[i].Cells["Column1"].Value.Equals(true))
                {
                    num++;
                }
            }
            if (num == 0)
            {
                MessageBox.Show("请选择要删除的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            DialogResult drs;

            //***czlt-2010-09-15**中试***Start****************
            if (isEqu == true)
            {
                drs = MessageBox.Show("确定删除所选信息吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            }
            else
            {
                //删除该生产厂家以后与其相关的设备信息也将删除，是否删除？
                drs = MessageBox.Show("删除该生产厂家以后与其相关的设备信息也将删除，是否删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            }
            //***czlt-2010-09-15**中试***End*****************

            if (drs == DialogResult.Yes)
            {
                if (isEqu)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        if (dgv.Rows[i].Cells["Column1"].Value != null && dgv.Rows[i].Cells["Column1"].Value.Equals(true))
                        {
                            bll.DelEquInfo(dgv.Rows[i].Cells[1].Value.ToString());
                        }
                    }
                    Refresh_Equ();
                }
                else
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        if (dgv.Rows[i].Cells["Column1"].Value != null && dgv.Rows[i].Cells["Column1"].Value.Equals(true))
                        {
                            bll.DelFactory(dgv.Rows[i].Cells[1].Value.ToString());
                        }
                    }
                    Refresh_Factory();
                }

                //Czlt-2011-12-19 配置信息被修改，更新备机同步时间
                bll.UpdateTime();
            }
        }

        #endregion

        #region【事件：修改】

        private void btnLaws_Click(object sender, EventArgs e)
        {
            int num = 0;
            int index = -1;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells["Column1"].Value!=null && dgv.Rows[i].Cells["Column1"].Value.Equals(true))
                {
                    num++;
                    index = i;
                }
            }
            if (num == 0)
            {
                MessageBox.Show("请选择要修改的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (num > 1)
            {
                MessageBox.Show("每次只能修改一条记录！", "提示", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            else
            {
                if (index != -1)
                {
                    if (isEqu)
                    {
                        strUpDateEquID = dgv.Rows[index].Cells["EquID"].Value.ToString();
                        A_frmAddEqu f = new A_frmAddEqu(dgv.Rows[index].Cells[1].Value.ToString(), 1,this);
                        f.ShowDialog();
                    }
                    else
                    {
                        strUpDateFactoryID = dgv.Rows[index].Cells["FactoryID"].Value.ToString();
                        A_frmAddFactory f = new A_frmAddFactory(dgv.Rows[index].Cells[1].Value.ToString(), 1,this);
                        f.ShowDialog();
                    }
                    //Flash();
                }
            }
        }

        #endregion

       

        #region【事件：查看——双击单元格】

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (isEqu)
                {
                    A_frmAddEqu f = new A_frmAddEqu(dgv.Rows[e.RowIndex].Cells[1].Value.ToString(), -1, this);
                    f.ShowDialog();
                }
                else
                {
                    A_frmAddFactory f = new A_frmAddFactory(dgv.Rows[e.RowIndex].Cells[1].Value.ToString(), -1, this);
                    f.ShowDialog();
                }
            }
        }

        #endregion

        #region【事件：单元格单击事件——改变是否选中】

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgv.Columns[e.ColumnIndex].Name.Equals("Column1"))
                {
                    if (dgv.Rows[e.RowIndex].Cells["Column1"].Value != null && dgv.Rows[e.RowIndex].Cells["Column1"].Value.Equals(true))
                    {
                        dgv.Rows[e.RowIndex].Cells["Column1"].Value = false;
                        if (btnSelectAll.Text.Equals("取消"))
                        {
                            btnSelectAll.Text = "全选";
                        }
                    }
                    else
                    {
                        dgv.Rows[e.RowIndex].Cells["Column1"].Value = true;
                    }
                }
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

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (dgv.Columns.Count > 0)
                {
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        dgv.Columns[i].DefaultCellStyle.NullValue = "——";
                    }
                }
            }
            catch (Exception ex)
            { 
            
            }
        }

        private void A_frmEquManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigXmlWiter.Write("Factory.xml");
        }

        private IButtonControl IB = null;
        private void txtSkipPage_Enter(object sender, EventArgs e)
        {
            this.IB = this.AcceptButton;
            this.AcceptButton = null;
        }

        private void txtSkipPage_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = this.IB;
        }
        #region【事件：打印 导出】
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgv, PrintTableName());
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgv, PrintTableName(), "");
        }

        private string PrintTableName()
        {
            if (isEqu)
            {
                return "设备信息";
            }
            else
            {
                return "厂家信息";
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {

            KJ128NDBTable.PrintBLL.Print(dgv, PrintTableName(), lblCounts.Text);
            
        }

        #endregion
    }
}
