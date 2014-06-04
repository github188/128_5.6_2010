using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using DegonControlLib;
using KJ128NDataBase;
using KJ128NInterfaceShow;
using Shine.Logs;
using Shine.Logs.LogType;

namespace KJ128NMainRun.A_Speed
{
    public partial class A_FrmWalkConfig : KJ128NMainRun.FromModel.FrmModel
    {
        #region【声明】

        private A_StationBLL sbll = new A_StationBLL();
        private A_WalkConfigBLL scbll = new A_WalkConfigBLL();
        private DataSet ds;

        private bool blIsBegin = true;

        private string strWhere = " 1 = 1 ";

        private int intOverSpeedID = -1;

        private int intRefReshCount = 0;

        private int intHostBackRefCount = 2;

        #endregion

        #region【构造函数】

        public A_FrmWalkConfig()
        {
            InitializeComponent();

            intHostBackRefCount = RefReshTime.intHostBackRefCount;
            timer_Refresh.Interval = RefReshTime.intHostBackRefTime;
        }

        #endregion


        #region【窗体加载】

        private void A_FrmWalkConfig_Load(object sender, EventArgs e)
        {
            LoadTreeView_StaHead(tvc_BeginStaHead_Select, true);
            LoadTreeView_StaHead(tvc_EndStaHead_Select, true);
            tvc_BeginStaHead_Select.ExpandAll();
            tvc_EndStaHead_Select.ExpandAll();
            SelectInfo();
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
        private void LoadTreeView_StaHead(TreeViewControl tvc, bool blIsAll)
        {
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
                    SetDataRow(ref dr, "0", "所有", "-1", false, false, 0);
                    dt.Rows.Add(dr);
                }

                tvc.DataSouce = dt;
                tvc.LoadNode("人");
            }
        }

        #endregion

        #region 【方法: 查询信息】

        /// <summary>
        /// 获取查询条件
        /// </summary>
        private string SelectWhere()
        {
            string strWhere_Temp = " 1=1 ";

            if (blIsBegin)
            {
                if (tvc_BeginStaHead_Select.SelectedNode != null && tvc_BeginStaHead_Select.SelectedNode.Name != "0")
                {
                    if (tvc_BeginStaHead_Select.SelectedNode.Parent.Name.Equals("0"))
                    {
                        strWhere_Temp += " And FirstStationAddress = " + tvc_BeginStaHead_Select.SelectedNode.Name.Substring(1);
                    }
                    else
                    {
                        strWhere_Temp += " And FirstStationAddress = " + tvc_BeginStaHead_Select.SelectedNode.Parent.Name.Substring(1) +
                            " And FirstStationHeadAddress = " + tvc_BeginStaHead_Select.SelectedNode.Name.Substring(1);
                    }
                }
            }
            else
            {
                if (tvc_EndStaHead_Select.SelectedNode != null && tvc_EndStaHead_Select.SelectedNode.Name != "0")
                {
                    if (tvc_EndStaHead_Select.SelectedNode.Parent.Name.Equals("0"))
                    {
                        strWhere_Temp += " And LastStationAddress = " + tvc_EndStaHead_Select.SelectedNode.Name.Substring(1);
                    }
                    else
                    {
                        strWhere_Temp += " And LastStationAddress = " + tvc_EndStaHead_Select.SelectedNode.Parent.Name.Substring(1) +
                            " And LastStationHeadAddress = " + tvc_EndStaHead_Select.SelectedNode.Name.Substring(1);
                    }
                }
            }
            return strWhere_Temp;
        }

        /// <summary>
        /// 查询
        /// </summary>
        public void SelectInfo()
        {
            using (ds = new DataSet())
            {
                ds = scbll.SelectSpeedConfig(strWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmWalkConfig_1";
                    dgv_Main.DataSource = ds.Tables[0];

                    dgv_Main.Columns["OverSpeedTime"].HeaderText = "额定行走时间(超速)";
                    dgv_Main.Columns["LackSpeedTime"].HeaderText = "额定行走时间(欠速)";

                    dgv_Main.Columns["OverSpeedTime"].DefaultCellStyle.NullValue = "——";
                    dgv_Main.Columns["LackSpeedTime"].DefaultCellStyle.NullValue = "——";
                    dgv_Main.Columns["OverSpeedID"].Visible = false;

                    dgv_Main.Columns["cl"].Width = 40;

                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个工作异常配置信息";
                }
                else
                {
                    dgv_Main.DataSource = null;
                    lblCounts.Text = "共 0 个工作异常配置信息";
                }
                if (btnSelectAll.Text.Equals("取消"))
                {
                    btnSelectAll.Text = "全选";
                }
            }
        }

        #endregion

        #region【方法：热备刷新】

        public void HostBackRefresh()
        {
            if (!New_DBAcess.IsDouble)          //单机版，直接刷新
            {
                SelectInfo();    //刷新
            }
            else
            {
                if (timer_Refresh.Enabled)
                {
                    timer_Refresh.Enabled = false;
                }
                intRefReshCount = 0;
                timer_Refresh.Enabled = true;
            }
        }

        #endregion



        #region【事件：选择选项卡事件——查询】

        private void tbc_Info_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage != null)
            {
                if (e.TabPage.Name == "tp_StaHead_Begin")      //起始分站
                {
                    if (!blIsBegin)
                    {
                        blIsBegin = true;
                        LoadTreeView_StaHead(tvc_BeginStaHead_Select, true);
                    }
                }
                else if (e.TabPage.Name == "tp_StaHead_End")   //终止分站
                {
                    if (blIsBegin)
                    {
                        blIsBegin = false;
                        LoadTreeView_StaHead(tvc_EndStaHead_Select, true);
                    }
                }
                SelectInfo();
            }
            
        }

        #endregion

        #region【事件：选择起始分站（树）】

        private void tvc_BeginStaHead_Select_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strWhere = SelectWhere();
            SelectInfo();
        }

        #endregion

        #region【事件：选择终止分站（树）】

        private void tvc_EndStaHead_Select_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strWhere = SelectWhere();
            SelectInfo();
        }

        #endregion

        #region【事件：新增】

        private void btnAdd_Click(object sender, EventArgs e)
        {
            A_FrmWalkConfig_Add wcadd = new A_FrmWalkConfig_Add(this);
            wcadd.ShowDialog();
        }

        #endregion

        #region【事件：全选】

        private void btnSelectAll_Click(object sender, EventArgs e)
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

        private void btnLaws_Click(object sender, EventArgs e)
        {
            int i = 0;
            int intUpDateID = -1;
            try
            {
                foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                {
                    if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                    {
                        intUpDateID = Convert.ToInt32(dgvr.Cells["OverSpeedID"].Value.ToString());
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
                MessageBox.Show("请选择要修改的行走异常信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (i > 1)
            {
                MessageBox.Show("所选行走异常信息不能大于1个，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (intUpDateID != -1)
                {
                    A_FrmWalkConfig_Add wcadd = new A_FrmWalkConfig_Add(this, intUpDateID, true);
                    wcadd.ShowDialog();
                }
            }

        }

        #endregion

        #region【事件：查看——单元格双击】

        private void dgv_Main_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                A_FrmWalkConfig_Add wcadd = new A_FrmWalkConfig_Add(this, Convert.ToInt32(dgv_Main.Rows[e.RowIndex].Cells["OverSpeedID"].Value.ToString()), false);
                wcadd.ShowDialog();
            }
        }

        #endregion

        #region【事件：删除】

        private void btnDelete_Click(object sender, EventArgs e)
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

                    if (strDeleteID == "")
                    {
                        strDeleteID = dgvr.Cells["OverSpeedID"].Value.ToString();
                        strDeleteName = "起始分站为：" + dgvr.Cells["起始传输分站编号"].Value.ToString() + " 号传输分站的 " + dgvr.Cells["起始读卡分站编号"].Value.ToString() + " 号读卡分站，" +
                            "终点分站：" + dgvr.Cells["终点传输分站编号"].Value.ToString() + " 号传输分站的 " + dgvr.Cells["终点读卡分站编号"].Value.ToString() + " 号读卡分站";
                    }
                    else
                    {
                        strDeleteID += "," + dgvr.Cells["OverSpeedID"].Value.ToString();
                        strDeleteName += "；起始分站为：" + dgvr.Cells["起始传输分站编号"].Value.ToString() + " 号传输分站的 " + dgvr.Cells["起始读卡分站编号"].Value.ToString() + " 号读卡分站，" +
                            "终点分站：" + dgvr.Cells["终点传输分站编号"].Value.ToString() + " 号传输分站的 " + dgvr.Cells["终点读卡分站编号"].Value.ToString() + " 号读卡分站";
                    }
                }
            }

            if (intDeleteCount == 0)
            {
                MessageBox.Show("请选择要删除的行走异常配置信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                result = MessageBox.Show("是否要删除所选行走异常配置信息？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Yes)
                {
                    scbll.WalkConfig_Delete(strDeleteID);

                    //存入日志
                    LogSave.Messages("[A_FrmWalkConfig]", LogIDType.UserLogID, "删除行走异常配置信息：" + strDeleteName);
                    this.HostBackRefresh();
                }
            }

        }

        #endregion

        #region【事件：单元格单击事件——改变是否选中】

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
                SelectInfo();
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

        private void A_FrmWalkConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigXmlWiter.Write("OverSpeed.xml");
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
        #region【事件：打印 导出】
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgv_Main, "行走异常配置信息");
        
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgv_Main, "行走异常配置信息", "");
        }
       

        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgv_Main, "行走异常配置信息", "共" + dgv_Main.Rows.Count.ToString() + "条记录");
        }

        #endregion
    }
}
