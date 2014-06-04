using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NMainRun.FromModel;
using KJ128NDBTable;
using KJ128NDataBase;
using Shine.Logs;
using Shine.Logs.LogType;
using PrintCore;

namespace KJ128NMainRun.AttendanceInfoSet
{
    public partial class A_NewHolidayMange : FrmModel
    {
        #region 【自定义参数】
        private NewHolidayTypeSetBLL bll = new NewHolidayTypeSetBLL();
        private HolidayTypeBLL HTBLL = new HolidayTypeBLL();
        string strWhere = "1=1";

        /// <summary>
        /// 热备当前刷新次数
        /// </summary>
        private int intRefReshCount = 0;

        /// <summary>
        /// 热备刷新最大次数
        /// </summary>
        private int intHostBackRefCount = 2;
        #endregion

        #region 【构造函数】
        public A_NewHolidayMange()
        {
            InitializeComponent();
            BindDataGridView();
            LoadHoildTree();
        }
        #endregion

        #region 【自定义方法】

        #region 【方法：加载假别树信息】
        /// <summary>
        /// 加载假别树信息
        /// </summary>
        public void LoadHoildTree()
        {
            DataSet dsHoiliday = bll.GetHolidayType(0, 99999, "1=1");
            
            treeViewHoliday.Nodes.Clear();
            DataTable dt = treeViewHoliday.BuildMenusEntity();
            DataRow dr = dt.NewRow();
            setDataRow(ref dr, "0", "所有", "-1", false, false, 0);
            dt.Rows.Add(dr);
            if (dsHoiliday!=null && dsHoiliday.Tables.Count>0)
            {
                foreach (DataRow dr1 in dsHoiliday.Tables[0].Rows)
                {
                    dr = dt.NewRow();
                    setDataRow(ref dr, dr1["id"].ToString(), dr1["假别全称"].ToString(), "0", true, false, 0);
                    dt.Rows.Add(dr);
                }
            }
            dt.AcceptChanges();
            treeViewHoliday.DataSouce = dt;
            treeViewHoliday.LoadNode("");
            treeViewHoliday.ExpandAll();
            dsHoiliday.Dispose();
        }

        private void setDataRow(ref DataRow dr, string id, string name, string parentid, bool isChild, bool isUserNum, int num)
        {
            dr[0] = id;
            dr[1] = name;
            dr[2] = parentid;
            dr[3] = isChild;
            dr[4] = isUserNum;
            dr[5] = num;
        }
        #endregion

        #region 【方法: DataGridView数据绑定函数】

        public void BindDataGridView()
        {
            btnSelectAll.Text = "全选";
            DataSet ds = bll.GetHolidayType(0, 99999, strWhere);

            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].TableName = "A_NewHolidayMange";
                dgvMain.DataSource = ds.Tables[0];
                dgvMain.Columns["id"].Visible = false;

                lblCounts.Text = "共有 " + ds.Tables[0].Rows.Count.ToString() + " 个假别";
            }
            else
            {
                lblCounts.Text = "共有 0 个假别";
            }

        }
        #endregion

        #region 【方法：热备刷新】
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

        #endregion

        #region 【系统事件方法】
        #region 【事件方法：显示添加假别管理界面】
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmHoilidayAdd frmHoilidayAdd = new FrmHoilidayAdd(1, this);
            frmHoilidayAdd.ShowDialog(this);
        }
        #endregion

        #region 【事件方法：全选择】
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (btnSelectAll.Text.Trim().Equals("全选"))
            {
                btnSelectAll.Text = "取消";
                foreach (DataGridViewRow row in dgvMain.Rows)
                {
                    row.Cells[0].Value = "True";
                }
            }
            else
            {
                btnSelectAll.Text = "全选";
                foreach (DataGridViewRow row in dgvMain.Rows)
                {
                    row.Cells[0].Value = "False";
                }
            }
        }
        #endregion

        #region 【事件方法：单选】
        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    btnSelectAll.Text = "全选";
                    if (dgvMain.Rows[e.RowIndex].Cells[0].Value != null && dgvMain.Rows[e.RowIndex].Cells[0].Value.ToString().Equals("True"))
                    {
                        dgvMain.Rows[e.RowIndex].Cells[0].Value = "False";
                    }
                    else
                    {
                        dgvMain.Rows[e.RowIndex].Cells[0].Value = "True";
                    }
                }
            }
        }
        #endregion

        #region 【事件方法：删除选择信息】
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = 0;
            ArrayList al = new ArrayList();
            DialogResult result;
            string strError = "";
            foreach (DataGridViewRow dgvr in dgvMain.Rows)
            {
                if (dgvr.Cells["colDel"].Value != null && dgvr.Cells["colDel"].Value.Equals("True"))
                {
                    i += 1;
                    int id =int.Parse(dgvr.Cells["id"].Value.ToString());
                    al.Add(id);
                }
            }

            if (i == 0)
            {
                MessageBox.Show("请选择要删除的假别设置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            result = MessageBox.Show("是否要删除选中假别设置？", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                btnSelectAll.Text = "全选";
                for (int j = 0; j < al.Count; j++)
                {
                    int idTemp=(int)al[j];
                    //操作数据库删除
                    HTBLL.HolidayType_Delete(idTemp, out strError);
                    //存入日志
                    LogSave.Messages("[A_NewHolidayMange]", LogIDType.UserLogID, "删除假别设置，编号为：" + idTemp.ToString());
                }

                dgvMain.ClearSelection();
                if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                {
                    BindDataGridView();
                    LoadHoildTree();
                }
                else                                //热备版，启用定时器
                {
                    HostBackRefresh(true);
                }
            }
        }
        #endregion

        #region 【事件方法：修改假别设置信息】
        private void btnLaws_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = null;
            int i = 0;
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                if (row.Cells["colDel"].Value != null)
                {
                    if (row.Cells["colDel"].Value.Equals("True"))
                    {
                        i++;
                        if (i > 1)
                        {
                            break;
                        }
                        r = row;
                    }
                }
            }

            if (i == 0)
            {
                MessageBox.Show("请选择要修改的假别设置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else if (i > 1)
            {
                MessageBox.Show("所选假别设置不能大于1个，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (r != null)
            {
                FrmHoilidayAdd frmHoilidayAdd = new FrmHoilidayAdd(2, this);
                frmHoilidayAdd.DgvRow = r;
                frmHoilidayAdd.ShowDialog(this);
            }
        }
        #endregion

        #region 【事件方法：选择树节点查看信息】
        private void treeViewHoliday_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            btnSelectAll.Text = "全选";
            treeViewHoliday.SelectedNode = e.Node;
            int id = 0;
            strWhere = "1=1";
            if (e.Node.Level > 0)
            {
                switch (e.Node.Level)
                {
                    case 1:
                        strWhere = "id=" + e.Node.Name;
                        break;
                    default:
                        break;
                }
            }
            BindDataGridView();
        }
        #endregion

        #region 【事件方法：热备刷新 定时器】
        private void timer_Refresh_Tick(object sender, EventArgs e)
        {
            btnSelectAll.Text = "全选";
            if (intRefReshCount >= intHostBackRefCount)
            {
                intRefReshCount = 0;
                timer_Refresh.Enabled = false;
            }
            else
            {
                intRefReshCount = intRefReshCount + 1;

                #region【刷新界面】

                dgvMain.ClearSelection();
                //刷新
                BindDataGridView();
                LoadHoildTree();

                #endregion

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

        private void A_NewHolidayMange_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigXmlWiter.Write("Holiday.xml");
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
        #region【打印 导出】
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportExcel excel = new ExportExcel();
            excel.Sql_ExportExcel(dgvMain, "假别设置");
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgvMain, "假别设置", "");
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgvMain, "假别设置", "共" + dgvMain.Rows.Count.ToString() + "条记录");
        }
        #endregion
    }
}
