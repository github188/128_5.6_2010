using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128WindowsLibrary;
using Shine.Logs;
using Shine.Logs.LogType;
using KJ128NMainRun.AreaManage;
using KJ128NInterfaceShow;
using KJ128NDataBase;

namespace KJ128NMainRun
{
    public partial class A_FrmAreaManage : FromModel.FrmModel
    {

        #region【声明】

        //*******czlt-2010-9-13-部门BLL**start*******
        private A_DeptBLL dbll = new A_DeptBLL();
        //*******czlt-2010-9-13-部门BLL**End*********
        private A_AreaBLL areaBll = new A_AreaBLL();

        private int intSelectModel = 1;

        private DataSet ds;

        public int tempTerritorialTypeID = -1;

        public int tempTerritorialID = -1;


        public bool blIsUpDate = false;

        private Color clColore = Color.Green;


        /// <summary>
        /// 查询条件
        /// </summary>
        private string where;

        /// <summary>
        /// 每页条数
        /// </summary>
        private static int pSize = 40;

        /// <summary>
        /// 查询到记录的总页数
        /// </summary>
        private int countPage;

        public int tempTerritorialID_TerSet = -1;

        public bool blIsSee_TerSet = false;

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

        public A_FrmAreaManage()
        {
            InitializeComponent();

            intHostBackRefCount = RefReshTime.intHostBackRefCount;
            timer_Refresh.Interval = RefReshTime.intHostBackRefTime;

            dmc_Info.Add(pl_TerSet,true);
            dmc_Info.Add(pl_Swork);
            dmc_Info.Add(pl_TerInfo);
            dmc_Info.Add(pl_TerType);

            dmc_Info.LeftPartResize();


            LoadTerSet();              //加载区域范围树——区域范围
            LoadTerSet1();
            //刷新——区域范围
            Refresh_TerSet();
            TerSetBution(true);
            cmbSelectCounts.Text = "40";
        }

        #endregion


        #region【公共方法】


        #region 【方法：设置提示信息】

        private void SetTipsInfo(Label lb, bool blIsSuccess, string strInfo)
        {
            lb.Text = strInfo;
            if (blIsSuccess)
            {
                lb.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                lb.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion

        #region【方法：自定义树的表的行结构】

        private void SetDataRow(ref DataRow dr, string id, string name, string parentid, bool isChild, bool isUserNum, int num)
        {
            dr[0] = id;
            dr[1] = name;
            dr[2] = parentid;
            dr[3] = isChild;
            dr[4] = isUserNum;
            dr[5] = num;
        }

        #endregion

        #region【方法：是否显示 翻页】

        /// <summary>
        /// 是否显示 翻页
        /// </summary>
        /// <param name="blIsVisible">true:显示；false：隐藏</param>
        private void IsVisiblePage(bool blIsVisible)
        {
            btnUpPage.Visible = lblPageCounts.Visible = lblSumPage.Visible = btnDownPage.Visible = label6.Visible = txtSkipPage.Visible = label7.Visible = label8.Visible = cmbSelectCounts.Visible = label9.Visible = blIsVisible;
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

        #endregion


        #region【公共事件】

        #region【事件：新增】

        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (intSelectModel)
            {
                case 2:

                    #region【区域信息】

                    tempTerritorialID = -1;

                    A_FrmAreaManage_AddTerInfo frmAmTer = new A_FrmAreaManage_AddTerInfo(this);
                    frmAmTer.ShowDialog();

                    #endregion

                    break;
                case 3:

                    #region【区域类型】

                    tempTerritorialTypeID = -1;

                    A_FrmAreaManage_AddTerType frmAmTerType = new A_FrmAreaManage_AddTerType(this);
                    frmAmTerType.ShowDialog();

                    #endregion

                    break;
                default:
                    break;
            }
        }

        #endregion

        #region【事件：修改】

        private void btnLaws_Click(object sender, EventArgs e)
        {

            int i = 0;

            int intUpDateID = -1;

            switch (intSelectModel)
            {
                case 1:

                    bool blIsSame = true;
                    int intTerID = 0; ;
                    #region【区域范围】

                    try
                    {
                        foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                        {
                            if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                            {
                                intUpDateID = Convert.ToInt32(dgvr.Cells["TerritorialID"].Value.ToString());
                                i += 1;
                                if (intTerID != 0)
                                {
                                    if (intTerID != Convert.ToInt32(dgvr.Cells["TerritorialID"].Value.ToString()))
                                    {
                                        blIsSame = false;
                                    }
                                }
                                intTerID = Convert.ToInt32(dgvr.Cells["TerritorialID"].Value.ToString());
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
                        MessageBox.Show("请选择要配置的区域", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (i > 1 && !blIsSame)
                    {
                        MessageBox.Show("所选区域不能大于1个，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        tempTerritorialID_TerSet = intTerID;

                        A_FrmAreaManage_AddTerSet frmAmadd = new A_FrmAreaManage_AddTerSet(this);
                        frmAmadd.ShowDialog();
                    }


                    #endregion

                    break;
                case 2:

                    #region【区域信息】
                    try
                    {
                        foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                        {
                            if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                            {
                                intUpDateID = Convert.ToInt32(dgvr.Cells["TerritorialID"].Value.ToString());
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
                        MessageBox.Show("请选择要修改的区域信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (i > 1)
                    {
                        MessageBox.Show("所选区域信息不能大于1个，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        blIsUpDate = true;
                        tempTerritorialID = intUpDateID;

                        A_FrmAreaManage_AddTerInfo frmAmTer = new A_FrmAreaManage_AddTerInfo(this);
                        frmAmTer.ShowDialog();

                    }

                    #endregion

                    break;
                case 3:

                    #region【区域类型】

                    try
                    {
                        foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                        {
                            if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                            {
                                intUpDateID = Convert.ToInt32(dgvr.Cells["TerritorialTypeID"].Value.ToString());
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
                        MessageBox.Show("请选择要修改的区域类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (i > 1)
                    {
                        MessageBox.Show("所选区域类型不能大于1个，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        blIsUpDate = true;
                        tempTerritorialTypeID = intUpDateID;

                        A_FrmAreaManage_AddTerType frmAmTerType = new A_FrmAreaManage_AddTerType(this);
                        frmAmTerType.ShowDialog();

                    }

                    #endregion

                    break;

                case 4:
                    #region[特殊工种配置]
                    A_frmSWrokSet f = new A_frmSWrokSet(this);
                    f.ShowDialog();
                    #endregion
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region【事件：删除】

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int intDeleteCount = 0;
            string strDeleteID = "";
            string strDeleteUserID = "";
            string strDeleteNO = "";
            string strDeleteName = "";
            DialogResult result;

            switch (intSelectModel)
            {
                case 1:

                    #region【区域范围】

                    foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                    {
                        if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                        {
                            if (!dgvr.Cells["TerritorialSetID"].Value.ToString().Equals(""))
                            {
                                intDeleteCount += 1;

                                if (strDeleteName == "")
                                {
                                    strDeleteID = " TerritorialSetID = " + dgvr.Cells["TerritorialSetID"].Value.ToString();
                                    strDeleteName = " 区域名称为：" + dgvr.Cells["区域名称"].Value.ToString() + "，传输分站编号：" + dgvr.Cells["传输分站编号"].Value.ToString() + ",读卡分站编号：" + dgvr.Cells["读卡分站编号"].Value.ToString();
                                }
                                else
                                {
                                    strDeleteID += " Or TerritorialSetID = " + dgvr.Cells["TerritorialSetID"].Value.ToString();
                                    strDeleteName += "；区域名称为：" + dgvr.Cells["区域名称"].Value.ToString() + "，传输分站编号：" + dgvr.Cells["传输分站编号"].Value.ToString() + ",读卡分站编号：" + dgvr.Cells["读卡分站编号"].Value.ToString();
                                }
                            }
                        }
                    }

                    if (intDeleteCount == 0)
                    {
                        MessageBox.Show("请选择要删除的区域信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {
                        result = MessageBox.Show("删除区域范围，将会导致区域范围相关的信息丢失，确定删除吗？", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk);
                        if (result == DialogResult.Yes)
                        {
                            areaBll.DeleteTerSet(strDeleteID);

                            dgv_Main.ClearSelection();

                            //Czlt-2011-12-19 删除后做主备机同步
                            areaBll.UpdateTime();
                            //存入日志
                            LogSave.Messages("[A_FrmAreaManage]", LogIDType.UserLogID, "删除区域范围，删除的信息为：" + strDeleteName);

                            if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                            {
                                Refresh_TerSet();
                            }
                            else                                //热备版，启用定时器
                            {
                                HostBackRefresh(true);
                            }
                        }
                    }

                    #endregion

                    break;
                case 2:

                    #region【区域信息】
                    foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                    {
                        if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                        {
                            intDeleteCount += 1;

                            if (strDeleteName == "")
                            {
                                strDeleteID = " TerritorialID = " + dgvr.Cells["TerritorialID"].Value.ToString();
                                strDeleteName = dgvr.Cells["区域名称"].Value.ToString();
                            }
                            else
                            {
                                strDeleteID += " Or TerritorialID = " + dgvr.Cells["TerritorialID"].Value.ToString();
                                strDeleteName += "，" + dgvr.Cells["区域名称"].Value.ToString();
                            }
                        }
                    }

                    if (intDeleteCount == 0)
                    {
                        MessageBox.Show("请选择要删除的区域信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {
                        result = MessageBox.Show("删除区域信息，将会导致区域信息相关的信息丢失，确定删除吗？", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk);
                        if (result == DialogResult.Yes)
                        {
                            areaBll.DeleteTer(strDeleteID);

                            dgv_Main.ClearSelection();


                            //Czlt-2011-12-19 删除后做主备机同步
                            areaBll.UpdateTime();
                            //存入日志
                            LogSave.Messages("[A_FrmAreaManage]", LogIDType.UserLogID, "删除区域信息，区域名称为：" + strDeleteName);

                            if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                            {
                                Refresh_Ter();
                            }
                            else                                //热备版，启用定时器
                            {
                                HostBackRefresh(true);
                            }
                        }
                    }

                    #endregion

                    break;
                case 3:

                    #region【区域类型】

                    foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                    {
                        if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                        {
                            intDeleteCount += 1;

                            if (strDeleteName == "")
                            {
                                strDeleteID = " TerritorialTypeID = " + dgvr.Cells["TerritorialTypeID"].Value.ToString();
                                strDeleteName = dgvr.Cells[1].Value.ToString();
                            }
                            else
                            {
                                strDeleteID += " Or TerritorialTypeID = " + dgvr.Cells["TerritorialTypeID"].Value.ToString();
                                strDeleteName += "，" + dgvr.Cells[1].Value.ToString();
                            }
                        }
                    }

                    if (intDeleteCount == 0)
                    {
                        MessageBox.Show("请选择要删除的区域类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {
                        if (intDeleteCount == 1)
                        {
                            if (strDeleteName.Equals("重点区域") || strDeleteName.Equals("限制区域") || strDeleteName.Equals("地域"))
                            {
                                MessageBox.Show("该类型是系统必备的类型，无法删除！", "提示", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                                return;
                            }
                        }
                        result = MessageBox.Show("删除区域类型，将会导致区域类型相关的信息丢失，确定删除吗？", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk);
                        if (result == DialogResult.Yes)
                        {
                            areaBll.DeleteTerType(strDeleteID);

                            dgv_Main.ClearSelection();


                            //Czlt-2011-12-19 删除后做主备机同步
                            areaBll.UpdateTime();
                            //存入日志
                            LogSave.Messages("[A_FrmAreaManage]", LogIDType.UserLogID, "删除区域类型，名称为：" + strDeleteName);

                            if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                            {
                                Refresh_TerType();
                            }
                            else                                //热备版，启用定时器
                            {
                                HostBackRefresh(true);
                            }
                        }
                    }

                    #endregion

                    break;
                case 4:
                    #region[特殊工种区域配置]
                    List<string> idlist = new List<string>();
                    //**************czlt-2010-9-13****************
                    List<string> workTypelist = new List<string>();

                    foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                    {
                        //*******Czlt-2010-9-16*添加代码*Start**************
                        if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                        {
                            //区域ID
                            if (!dgvr.Cells["TerriAlarmID"].Value.ToString().Equals(""))
                            {
                                string alarmID = "";
                                alarmID = dgvr.Cells["TerriAlarmID"].Value.ToString();
                                DataSet ds = dbll.GetNameWorkTypeInfoTable(dgvr.Cells[1].Value.ToString());
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    alarmID += "," + ds.Tables[0].Rows[0]["工种编号"].ToString();
                                }

                                idlist.Add(alarmID);

                                //************czlt-2010-9-13-
                                // idlist.Add(dgvr.Cells["TerriAlarmID"].Value.ToString());
                            }

                        }
                        //*******Czlt-2010-9-16*添加代码*End**************

                        //***************czlt-2010-9-16-注销代码*Start**********
                        //if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                        //{
                           
                        //    if (!dgvr.Cells["TerriAlarmID"].Value.ToString().Equals(""))
                        //    {
                        //        idlist.Add(dgvr.Cells["TerriAlarmID"].Value.ToString());
                        //    }
                        //}
                        //***************czlt-2010-9-16-注销代码*End**********
                    }
                    if (idlist.Count == 0)
                    {
                        MessageBox.Show("请选择要删除的特殊工种区域配置信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    { 
                        result = MessageBox.Show("确定要删除配置的特殊工种区域信息吗？", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk);
                        if (result == DialogResult.Yes)
                        {
                            foreach (string id in idlist)
                            {
                                //********Czlt-2010-9-16***start***
                                string[] str = id.Split(',');
                                new SpecialWorkTypeTerrialSetBLL().DelSWTer(str[0], str[1]);
                                //********Czlt-2010-9-16***End***

                                //new SpecialWorkTypeTerrialSetBLL().DelSWTer(id);
                            }


                            //Czlt-2011-12-19 删除后做主备机同步
                            areaBll.UpdateTime();

                            if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                            {
                                SelectInfoSWork(1);
                            }
                            else                                //热备版，启用定时器
                            {
                                HostBackRefresh(true);
                            }
                        }
                    }
                    #endregion
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region【事件：查看——双击单元格】

        private void dgv_Main_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (intSelectModel)
                {
                    case 1:

                        #region【区域范围】

                        blIsSee_TerSet = true;

                        tempTerritorialID_TerSet = Convert.ToInt32(dgv_Main.Rows[e.RowIndex].Cells["TerritorialID"].Value.ToString());

                        A_FrmAreaManage_AddTerSet frmAmadd = new A_FrmAreaManage_AddTerSet(this);
                        frmAmadd.ShowDialog();

                        blIsSee_TerSet = false;
                        #endregion

                        break;
                    case 2:

                        #region【区域信息】

                        blIsUpDate = false;
                        tempTerritorialID = Convert.ToInt32(dgv_Main.Rows[e.RowIndex].Cells["TerritorialID"].Value.ToString());
 
                        A_FrmAreaManage_AddTerInfo frmAmTer = new A_FrmAreaManage_AddTerInfo(this);
                        frmAmTer.ShowDialog();

                        #endregion

                        break;
                    case 3:

                        #region【区域类型】

                        blIsUpDate = false;
                        tempTerritorialTypeID = Convert.ToInt32(dgv_Main.Rows[e.RowIndex].Cells["TerritorialTypeID"].Value.ToString());

                        A_FrmAreaManage_AddTerType frmAmTerType = new A_FrmAreaManage_AddTerType(this);
                        frmAmTerType.ShowDialog();

                        #endregion

                        break;
                    default:
                        break;
                }
            }
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

                #region【刷新界面】

                switch (intSelectModel)
                {
                    case 1:

                        #region【区域范围】

                        Refresh_TerSet();

                        #endregion

                        break;
                    case 2:

                        #region【区域信息】

                        Refresh_Ter();

                        #endregion

                        break;
                    case 3:

                        #region【区域类型】

                        Refresh_TerType();

                        #endregion

                        break;
                    case 4:
                    #region[特殊工种区域配置]
                        SelectInfoSWork(1);
                    #endregion
                        break;
                    default:
                        break;
                }

                #endregion

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

        #endregion


        #region【区域类型】

        #region【方法：刷新——区域类型】

        public void Refresh_TerType()
        {
            LoadTerType();              //加载区域类型树——区域类型

            SelectTerTypeInfo();        //加载区域类型查询信息——区域类型
        }

        #endregion

        #region【方法：查询区域类型信息】

        private void SelectTerTypeInfo()
        {

            string strWhere = " 1=1 ";

            using (ds = new DataSet())
            {
                if (tvc_TerType_TerType.SelectedNode != null && !tvc_TerType_TerType.SelectedNode.Name.Equals("0"))
                {
                    strWhere += " And TerritorialTypeID = " + tvc_TerType_TerType.SelectedNode.Name;
                }

                ds = areaBll.SelectTerTypeInfo(strWhere);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmAreaManager_Type";
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个区域类型";

                    dgv_Main.Columns["TerritorialTypeID"].Visible = false;

                }
                else
                {
                    dgv_Main.DataSource = null;
                    lblCounts.Text = "共 0 个区域类型";
                }
                if (btnSelectAll.Text.Equals("取消"))
                {
                    btnSelectAll.Text = "全选";
                }
            }

        }

        #endregion

        #region 【方法：初始化区域类型——区域类型】

        /// <summary>
        /// 初始化区域类型——区域类型
        /// </summary>
        private void LoadTerType()
        {
            if (tvc_TerType_TerType.Nodes.Count > 0)
            {
                tvc_TerType_TerType.Nodes.Clear();
            }
            DataTable dt;
            using (ds = new DataSet())
            {
                ds = areaBll.GetTerType_TerType();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {
                    dt = tvc_TerType_TerType.BuildMenusEntity();
                }

                DataRow dr = dt.NewRow();
                SetDataRow(ref dr, "0", "所有", "-1", false, false, 0);
                dt.Rows.Add(dr);

                tvc_TerType_TerType.DataSouce = dt;
                tvc_TerType_TerType.LoadNode("人");
            }

            tvc_TerType_TerType.ExpandAll();
            tvc_TerType_TerType.SelectedNode = tvc_TerType_TerType.Nodes[0];
            tvc_TerType_TerType.SetSelectNodeColor();
        }

        #endregion


        #region【事件：选择区域类型——抽屉式菜单】

        private void bt_TerTypeInfo_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 3)
            {
                HostBackRefresh(false);

                dmc_Info.ButtonClick(pl_TerType.Name);

                intSelectModel = 3;

                IsVisiblePage(false);

                //刷新
                Refresh_TerType();

                TerSetBution(false);
            }
        }

        #endregion

        #region【事件：区域类型——区域类型树单击事件】

        private void tvc_TerType_TerType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectTerTypeInfo();
        }

        #endregion

        #endregion


        #region【区域信息】

        #region【方法：刷新——区域信息】

        public void Refresh_Ter()
        {
            LoadTer();              //加载区域信息树——区域信息

            SelectTerInfo();        //加载区域信息查询信息——区域信息
        }

        #endregion

        #region【方法：查询区域信息】

        private void SelectTerInfo()
        {

            string strWhere = " 1=1 ";

            using (ds = new DataSet())
            {
                if (tvc_Ter_Ter.SelectedNode != null && !tvc_Ter_Ter.SelectedNode.Name.Equals("0"))
                {
                    if (tvc_Ter_Ter.SelectedNode.Name.Substring(0, 1).Equals("T"))
                    {
                        strWhere += " And TerritorialTypeID = " + tvc_Ter_Ter.SelectedNode.Name.Substring(1);
                    }
                    else if (tvc_Ter_Ter.SelectedNode.Name.Substring(0,1).Equals("I"))
                    {
                        strWhere += " And TerritorialID = " + tvc_Ter_Ter.SelectedNode.Name.Substring(1);    
                    }
                }

                ds = areaBll.SelectTerInfo(strWhere);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmAreaManage_Ter";
                    dgv_Main.DataSource = ds.Tables[0];

                    dgv_Main.Columns["最大工作时间"].DefaultCellStyle.NullValue = "——";
                    dgv_Main.Columns["最大工作人数"].DefaultCellStyle.NullValue = "——";
                    dgv_Main.Columns["备注"].DefaultCellStyle.NullValue = "——";
                    dgv_Main.Columns["备注"].DisplayIndex = dgv_Main.Columns.Count - 1;
                    dgv_Main.Columns["区域名称"].DisplayIndex = 2;
                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个区域信息";

                    dgv_Main.Columns["TerritorialTypeID"].Visible = false;
                    dgv_Main.Columns["TerritorialID"].Visible = false;
                }
                else
                {
                    dgv_Main.DataSource = null;
                    lblCounts.Text = "共 0 个区域信息";
                }
                if (btnSelectAll.Text.Equals("取消"))
                {
                    btnSelectAll.Text = "全选";
                }
            }

        }

        #endregion

        #region 【方法：初始化区域信息——区域信息】

        /// <summary>
        /// 初始化区域信息——区域信息
        /// </summary>
        private void LoadTer()
        {
            if (tvc_Ter_Ter.Nodes.Count > 0)
            {
                tvc_Ter_Ter.Nodes.Clear();
            }
            DataTable dt;
            using (ds = new DataSet())
            {
                ds = areaBll.GetTer_Ter();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {
                    dt = tvc_Ter_Ter.BuildMenusEntity();
                }

                DataRow dr = dt.NewRow();
                SetDataRow(ref dr, "0", "所有", "-1", false, false, 0);
                dt.Rows.Add(dr);

                tvc_Ter_Ter.DataSouce = dt;
                tvc_Ter_Ter.LoadNode("人");
            }

            tvc_Ter_Ter.ExpandAll();
            tvc_Ter_Ter.SelectedNode = tvc_Ter_Ter.Nodes[0];
            tvc_Ter_Ter.SetSelectNodeColor();
        }

        #endregion



        #region【事件：选择区域类型——抽屉式菜单】

        private void bt_TerInfo_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 2)
            {
                HostBackRefresh(false);

                dmc_Info.ButtonClick(pl_TerInfo.Name);

                intSelectModel = 2;

                IsVisiblePage(false);

                //刷新
                Refresh_Ter();

                TerSetBution(false);
            }
        }

        #endregion

        #region【事件：区域信息——区域信息树单击事件】

        private void tvc_Ter_Ter_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectTerInfo();
        }

        #endregion

        #endregion


        #region【区域范围】

        #region【方法：区域范围定制按钮】

        private void TerSetBution(bool blIsTerSet)
        {
            if (blIsTerSet)         //区域范围
            {
                btnAdd.Visible = false;
                btnLaws.Text = "配置";
            }
            else                    //不是区域范围
            {
                btnAdd.Visible = true;
                btnLaws.Text = "修改";
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

        #region 【方法: 查询信息】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere()
        {
            string strSQL = "1=1";
            if (tvc_TerSet_TerSet.SelectedNode != null && !tvc_TerSet_TerSet.SelectedNode.Name.Equals("0"))
            {
                if (tvc_TerSet_TerSet.SelectedNode.Name.Substring(0, 1).Equals("T"))
                {
                    strSQL += " And TerritorialTypeID = " + tvc_TerSet_TerSet.SelectedNode.Name.Substring(1);
                }
                else if (tvc_TerSet_TerSet.SelectedNode.Name.Substring(0, 1).Equals("I"))
                {
                    strSQL += " And TerritorialID = " + tvc_TerSet_TerSet.SelectedNode.Name.Substring(1);
                }
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


            DataSet ds = areaBll.GetTerSet(pIndex, pSize, where);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                ds.Tables[0].TableName = "A_FrmAreaManager_Info";
                if (sumPage == 0)
                {
                    
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 0 个区域范围信息";

                    lblPageCounts.Text = "1";
                    lblSumPage.Text = "/1页";

                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 个区域范围信息";

                    lblPageCounts.Text = pIndex.ToString();
                    lblSumPage.Text = "/" + sumPage + "页";

                    //控制翻页状态
                    SetPageEnable(pIndex, sumPage);
                }

                if (dgv_Main.Columns.Count >= 10)
                {
                    dgv_Main.Columns["TerritorialSetID"].Visible = false;
                    dgv_Main.Columns["TerritorialTypeID"].Visible = false;
                    dgv_Main.Columns["TerritorialID"].Visible = false;

                    dgv_Main.Columns["cl"].DisplayIndex = 0;
                    dgv_Main.Columns["区域名称"].DisplayIndex = 1;
                    dgv_Main.Columns["区域类型"].DisplayIndex = 2;
                    dgv_Main.Columns["传输分站编号"].DisplayIndex = 3;
                    dgv_Main.Columns["读卡分站编号"].DisplayIndex = 4;
                    dgv_Main.Columns["读卡分站位置"].DisplayIndex = 5;
                    dgv_Main.Columns["是否为区域口"].DisplayIndex = 6;
                }

                if (btnSelectAll.Text.Equals("取消"))
                {
                    btnSelectAll.Text = "全选";
                }
            }
        }
        #endregion

        #region【方法：刷新——区域范围】

        public void Refresh_TerSet()
        {
            //LoadTerSet();              //加载区域范围树——区域范围

            where = StrWhere();
            SelectInfo(1);        //加载区域范围查询信息——区域范围
        }

        #endregion

        #region 【方法：初始化区域信息——区域信息】

        /// <summary>
        /// 初始化区域信息——区域信息
        /// </summary>
        private void LoadTerSet()
        {
            if (tvc_TerSet_TerSet.Nodes.Count > 0)
            {
                tvc_TerSet_TerSet.Nodes.Clear();
            }
            DataTable dt;
            using (ds = new DataSet())
            {
                ds = areaBll.GetTer_Ter();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {
                    dt = tvc_TerSet_TerSet.BuildMenusEntity();
                }

                DataRow dr = dt.NewRow();
                SetDataRow(ref dr, "0", "所有", "-1", false, false, 0);
                dt.Rows.Add(dr);

                tvc_TerSet_TerSet.DataSouce = dt;
                tvc_TerSet_TerSet.LoadNode("人");
            }

            tvc_TerSet_TerSet.ExpandAll();
            tvc_TerSet_TerSet.SelectedNode = tvc_TerSet_TerSet.Nodes[0];
            tvc_TerSet_TerSet.SetSelectNodeColor();
        }

        private void LoadTerSet1()
        {
            if (trvTer.Nodes.Count > 0)
            {
                trvTer.Nodes.Clear();
            }
            DataTable dt;
            using (ds = new DataSet())
            {
                ds = areaBll.GetTer_Ter();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {
                    dt = trvTer.BuildMenusEntity();
                }

                DataRow dr = dt.NewRow();
                SetDataRow(ref dr, "0", "所有", "-1", false, false, 0);
                dt.Rows.Add(dr);

                trvTer.DataSouce = dt;
                trvTer.LoadNode("人");
            }

            trvTer.ExpandAll();
            trvTer.SelectedNode = tvc_TerSet_TerSet.Nodes[0];
            trvTer.SetSelectNodeColor();
        }


        #endregion


        #region【事件：选择区域范围——抽屉式菜单】

        private void bt_TerSet_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 1)
            {
                HostBackRefresh(false);

                dmc_Info.ButtonClick(pl_TerSet.Name);

                intSelectModel = 1;

                IsVisiblePage(true);

                LoadTerSet();              //加载区域范围树——区域范围

                //刷新
                Refresh_TerSet();

                TerSetBution(true);
            }
        }

        #endregion

        #region【事件：区域范围——区域范围树单击事件】

        private void tvc_TerSet_TerSet_AfterSelect(object sender, TreeViewEventArgs e)
        {
            where = StrWhere();
            SelectInfo(1);
        }

        #endregion

        #region 【事件: 上一页】

        private void btnUpPage_Click(object sender, EventArgs e)
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

        private void btnDownPage_Click(object sender, EventArgs e)
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

        private void txtSkipPage_KeyDown(object sender, KeyEventArgs e)
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
                    else if (int.Parse(value) > 0)
                    {
                        int page = int.Parse(value);
                        if (page > countPage)
                        {
                            page = countPage;
                        }
                        SelectInfo(page);
                    }
                }catch(Exception ex)
                {
                    
                }
            }
        }

        #endregion

        #region【事件：选择每页显示行数】

        private void cmbSelectCounts_DropDownClosed(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cmbSelectCounts.SelectedItem);
            SelectInfo(1);
        }

        #endregion

        private void A_FrmAreaManage_Load(object sender, EventArgs e)
        {

        }

        #endregion

        private void btn_SWorkType_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 4)
            {
                HostBackRefresh(false);

                dmc_Info.ButtonClick(pl_Swork.Name);

                intSelectModel = 4;

                IsVisiblePage(true);

                LoadTerSet1();              //加载区域范围树——区域范围
                tvc_TerSet_TerSet.SelectedNode = tvc_TerSet_TerSet.Nodes[0];
                SWorkWhere();
                SelectInfoSWork(1);
                //刷新
                //Refresh_TerSet();

                TerSetBution(true);
            }
        }

        private void trvTer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            where = SWorkWhere();
            SelectInfoSWork(1);
        }

        private string SWorkWhere()
        {
            string strSQL = "1=1";
            if (trvTer.SelectedNode != null && !trvTer.SelectedNode.Name.Equals("0"))
            {
                if (trvTer.SelectedNode.Name.Substring(0, 1).Equals("T"))
                {
                    strSQL += " And TerritorialTypeID = " + trvTer.SelectedNode.Name.Substring(1);
                }
                else if (trvTer.SelectedNode.Name.Substring(0, 1).Equals("I"))
                {
                    strSQL += " And TerritorialID = " + trvTer.SelectedNode.Name.Substring(1);
                }
            }
            return strSQL;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pIndex">所有查询的页数</param>
        public void SelectInfoSWork(int pIndex)
        {
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }


            DataSet ds = areaBll.GetSWork(pIndex, pSize, where);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;

                if (sumPage == 0)
                {
                    ds.Tables[0].TableName = "A_FrmAreaManage_Work";
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 0 个特殊工种配置信息";

                    lblPageCounts.Text = "1";
                    lblSumPage.Text = "/1页";

                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 个特殊工种配置信息";

                    lblPageCounts.Text = pIndex.ToString();
                    lblSumPage.Text = "/" + sumPage + "页";

                    //控制翻页状态
                    SetPageEnable(pIndex, sumPage);
                }
                dgv_Main.Columns["TerriAlarmID"].Visible = false;
                //if (dgv_Main.Columns.Count >= 10)
                //{
                //    dgv_Main.Columns["TerritorialSetID"].Visible = false;
                //    dgv_Main.Columns["TerritorialTypeID"].Visible = false;
                //    dgv_Main.Columns["TerritorialID"].Visible = false;

                //    dgv_Main.Columns["cl"].DisplayIndex = 0;
                //    dgv_Main.Columns["区域名称"].DisplayIndex = 1;
                //    dgv_Main.Columns["区域类型"].DisplayIndex = 2;
                //    dgv_Main.Columns["传输分站编号"].DisplayIndex = 3;
                //    dgv_Main.Columns["读卡分站编号"].DisplayIndex = 4;
                //    dgv_Main.Columns["读卡分站位置"].DisplayIndex = 5;
                //    dgv_Main.Columns["是否为区域口"].DisplayIndex = 6;
                //}

                //if (btnSelectAll.Text.Equals("取消"))
                //{
                //    btnSelectAll.Text = "全选";
                //}
            }
        }

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

        private void A_FrmAreaManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigXmlWiter.Write("Territorial.xml");
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
            excel.Sql_ExportExcel(dgv_Main, "区域信息");
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgv_Main, "区域信息", "");
        }
        

        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgv_Main, "区域信息", lblCounts.Text);
        }

        #endregion
    }
}
