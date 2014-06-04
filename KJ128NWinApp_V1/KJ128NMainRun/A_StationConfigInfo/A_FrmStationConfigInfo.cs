using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NMainRun.FromModel;
using KJ128NDBTable;
using PrintCore;
using KJ128NInterfaceShow;
using System.Xml;
using System.IO;
using Wilson.Controls.Docking;

namespace KJ128NMainRun.A_StationConfigInfo
{
    public partial class A_FrmStationConfigInfo : FrmModel
    {
        #region[构造函数]
        DockPanel dockPanel = null;
        public A_FrmStationConfigInfo(DockPanel Panel)
        {
            InitializeComponent();
            dockPanel = Panel;
            AddControl();
        }

        #endregion

        #region[字段]

        /// <summary>
        /// 0表示传传输分站 1表示读卡分站 2表示全部读卡分站
        /// </summary>
        private int selectModel = 0;

        /// <summary>
        /// 打印标题
        /// </summary>
        private string printTitle = "传输分站配置信息";

        private A_StationConfigInfoBLL bll = new A_StationConfigInfoBLL();

        private A_HisAlarmBLL rtabll = new A_HisAlarmBLL();

        private int intTempStationAddress = 0;
        private bool blSelectAll = true;
        private string strTempWhere = "";

        private string strWhere = " 1=1 ";
        private DataSet ds;

        //czlt-2010-9-16*start*****
        SortOrder sortDirection = new SortOrder();
        private int index = 0;
        private bool isHearderSort = false;
        private bool isClickSort;
        ListSortDirection listSort;
        //czlt-2010-9-16*end*****

        #endregion

        #region[方法]

        /// <summary>
        /// 添加抽屉菜单面板
        /// </summary>
        private void AddControl()
        {
            //添加抽屉菜单面板并重置

            drawerLeftMain.Add(pnlStation, true);
            drawerLeftMain.Add(pnlStationHead);
            drawerLeftMain.LeftPartResize();

            //设置选择的抽屉菜单类型

        }

        /// <summary>
        /// 初始化树控件
        /// </summary>
        private void InitializeTreeView()
        {
            using (ds = new DataSet())
            {
                ds = rtabll.GetTree_Station();
                LoadTree(tvStation, ds, "人", false, "所有");
                tvStation.ExpandAll();
            }
        }

        #region【方法：绑定数据】

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="stationAddress"></param>
        /// <param name="selectModel"></param>
        /// <param name="selectAll"></param>
        /// <param name="whereString"></param>
        private void BandingDataGridView(int selectModel)
        {

            DataTable dt = GetStaionInfo(selectModel, strWhere);
            dt.TableName = "A_FrmStationConfigInfo";

            if (selectModel == 0)
            {
                //是否为环网
                string type = "";
                //是否为启用交直流
                string isOpen = "";
               

                
                if (File.Exists(Application.StartupPath + "\\PowerManager.xml"))
                {
                    XmlDocument dom = new XmlDocument();
                    dom.Load(Application.StartupPath + "\\PowerManager.Xml");
                    // string Location = xml1.SelectSingleNode("/Config/Location").InnerText;
                    //string staID = xml.SelectSingleNode("StationID").InnerText;
                    isOpen = dom.SelectSingleNode("Root/IsOpen").InnerText;
                }

                if (File.Exists(Application.StartupPath + "\\CommType.xml"))
                {
                    XmlDocument dom = new XmlDocument();
                    dom.Load(Application.StartupPath + "\\CommType.Xml");
                    // string Location = xml1.SelectSingleNode("/Config/Location").InnerText;
                    //string staID = xml.SelectSingleNode("StationID").InnerText;
                    type = dom.SelectSingleNode("comm/commType").InnerText;
                }

                //判断是否为环网  1-环网 0-串口
                if (type.Trim().Equals("1"))
                {
                    //判断是否启用交直流
                    if (isOpen.Trim().ToLower().Equals("true"))
                    {
                        //是否启用传输分站报警
                        if (!IsEnableAlarm(17))
                        {
                            dt.Columns.Remove("分站供电");
                        }
                        

                        //是否启用交换机报警
                        if (!IsEnableAlarm(18))
                        {
                            dt.Columns.Remove("串口服务器名称");
                            dt.Columns.Remove("串口服务器IP");
                            dt.Columns.Remove("串口服务器供电");
                        }
                        
                    }
                    else
                    {
                        dt.Columns.Remove("分站供电");
                        dt.Columns.Remove("串口服务器名称");
                        dt.Columns.Remove("串口服务器IP");
                        dt.Columns.Remove("串口服务器供电");
                    }

                }
                else
                {
                    //判断是否启用交直流
                    if (isOpen.Trim().ToLower().Equals("true"))
                    {
                        //是否启用传输分站报警
                        if (!IsEnableAlarm(17))
                        {
                            dt.Columns.Remove("分站供电");
                        }
                        
                        dt.Columns.Remove("分组编号");
                        dt.Columns.Remove("串口服务器名称");
                        dt.Columns.Remove("串口服务器IP");
                        dt.Columns.Remove("串口服务器供电");
                    }
                    else
                    {
                        dt.Columns.Remove("分组编号");
                        dt.Columns.Remove("分站供电");
                        dt.Columns.Remove("串口服务器名称");
                        dt.Columns.Remove("串口服务器IP");
                        dt.Columns.Remove("串口服务器供电");
                    }
 
                }

            }


            this.dgvMain.DataSource = dt;
            if (selectModel == 1)       //读卡分站
            {
                if (dt != null)
                {
                    try
                    {
                        this.dgvMain.Columns["天线B"].Visible = this.dgvMain.Columns["天线A"].Visible = false;
                    }
                    catch (Exception ex)
                    { }
                    lblCounts.Text = "共 " + dt.Rows.Count.ToString() + " 个读卡分站";

                    if (dgvMain.Columns.Count >= 10)
                    {
                        dgvMain.Columns["StationHeadAddress"].Visible = false;
                        dgvMain.Columns["StationAddress"].Visible = false;
                    }
                }
                else
                {
                    lblCounts.Text = "共 0 个读卡分站";
                }
            }
            else                        //传输分站
            {
                if (dt != null)
                {
                    lblCounts.Text = "共 " + dt.Rows.Count.ToString() + " 个传输分站";
                }
                else
                {
                    lblCounts.Text = "共 0 个传输分站";
                }
            }


            //****czlt-2010-9-16**start****
            if (isHearderSort == true)
            {
                DataGridViewColumn newColumn = dgvMain.Columns[index];
                dgvMain.Sort(newColumn, listSort);
            }
            //****czlt-2010-9-16**end****

        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="selectModel"></param>
        /// <param name="whereString"></param>
        /// <returns></returns>
        private DataTable GetStaionInfo(int selectModel, string whereString)
        {
            DataSet ds = bll.SelectStationConfigInfo(selectModel, whereString);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        #endregion

        #endregion

        #region[事件方法]

        private void btnStation_Click(object sender, EventArgs e)
        {
            selectModel = 0;
            printTitle = "传输分站配置信息";

            //****czlt-2010-9-16**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-16**end****

            if (!this.pnlStation.Contains(tvStation))
            {
                this.pnlStation.Controls.Add(tvStation);
                tvStation.BringToFront();
            }

            if (drawerLeftMain.ButtonClick(pnlStation.Name))
            {
                strWhere = " 1 = 1 ";
                BandingDataGridView(selectModel);
            }
        }

        private void btnStationHead_Click(object sender, EventArgs e)
        {
            selectModel = 1;
            printTitle = "读卡分站配置信息";

            //****czlt-2010-9-16**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-16**end****

            if (!this.pnlStationHead.Contains(tvStation))
            {
                this.pnlStationHead.Controls.Add(tvStation);
                tvStation.BringToFront();
            }

            if (drawerLeftMain.ButtonClick(pnlStationHead.Name))
            {
                strWhere = " 1 = 1 ";
                BandingDataGridView(selectModel);
            }
        }

        #region【窗体加载】

        private void A_FrmStationConfigInfo_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeTreeView();

                BandingDataGridView(0);

                this.timer_Alarm.Interval = RefReshTime._rtTime;
                timer_Alarm.Enabled = true;
                //Czlt-2010-12-24
                listSort = new ListSortDirection();
                isClickSort = false;
            }
            catch (Exception ex)
            { }
        }

        #endregion

        #region【方法：获取查询条件】

        private string GetStrWhere()
        {
            string strTemp = " 1=1 ";

            if (tvStation.SelectedNode != null && !tvStation.SelectedNode.Text.Equals("所有"))
            {
                strTemp += " And StationAddress =" + tvStation.SelectedNode.Name;
            }

            if (selectModel == 0)                    //传输分站
            {
                if (!txtPlace.Text.Trim().Equals(""))
                {
                    strTemp += " And StationPlace like '%" + txtPlace.Text.Trim() + "%' ";
                }
            }
            else                                     //读卡分站
            {
                if (!txtPlace.Text.Trim().Equals(""))
                {
                    strTemp += " And 安装位置 like '%" + txtPlace.Text.Trim() + "%' ";
                }
            }

            return strTemp;
        }

        #endregion

        #region【事件：树选择】


        private void tvStation_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //****czlt-2010-9-13**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-13**end****

            strWhere = GetStrWhere();
            BandingDataGridView(selectModel);
        }

        #endregion

        #region【事件：查询】

        private void btnQuery_Click(object sender, EventArgs e)
        {
            //****czlt-2010-9-13**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-13**end****

            strWhere = GetStrWhere();
            BandingDataGridView(selectModel);
        }

        #endregion

        #region【事件：重置】

        private void btnClear_Click(object sender, EventArgs e)
        {
            //****czlt-2010-9-13**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-13**end****

            tvStation.Nodes.Clear();
            InitializeTreeView();

            txtPlace.Text = "";
            intTempStationAddress = 0;
            blSelectAll = true;
            strTempWhere = "";

            strWhere = GetStrWhere();
            BandingDataGridView(selectModel);
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

        #region【事件：定时器】

        private void timer_Alarm_Tick(object sender, EventArgs e)
        {
            //qyz 修改 获得焦点更新
            if ((this.IsActivated || this.DockHandler == dockPanel.ActiveDocument.DockHandler) && chb.Checked)
            {
                BandingDataGridView(selectModel);
                InitializeTreeView();
            }
        }

        #endregion



        #region【方法：自定义树的表的行结构】


        private void SetDataRow(ref DataRow dr, int id, string name, int parentid, bool isChild, bool isUserNum, int num)
        {
            dr[0] = id;
            dr[1] = name;
            dr[2] = parentid;
            dr[3] = isChild;
            dr[4] = isUserNum;
            dr[5] = num;
        }

        #endregion

        #region 【方法：初始化部门树（查询）】

        /// <summary>
        /// 初始化部门树
        /// </summary>
        private void LoadTree(DegonControlLib.TreeViewControl tvc, DataSet dsTemp, string strName, bool blCount, string strHeadTip)
        {
            DataTable dt;

            if (dsTemp != null && dsTemp.Tables.Count > 0)
            {
                dt = dsTemp.Tables[0];
            }
            else
            {
                dt = tvc.BuildMenusEntity();
            }

            DataRow dr = dt.NewRow();

            SetDataRow(ref dr, 0, strHeadTip, -1, false, blCount, 0);

            dt.Rows.Add(dr);

            tvc.DataSouce = dt;
            tvc.LoadNode(strName);
        }

        #endregion

        private void dgvMain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
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

        //******Czlt-2010-9-16*Start**
        /// <summary>
        /// 单击列标题事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMain_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (index != e.ColumnIndex)
            {

                index = e.ColumnIndex;
                isClickSort = false;
            }
            if (isClickSort == false)
            {
                listSort = ListSortDirection.Ascending;
                isClickSort = true;
            }
            else if (isClickSort == true)
            {
                listSort = ListSortDirection.Descending;
                isClickSort = false;
            }
            isHearderSort = true;
        }

        private void txtPlace_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void A_FrmStationConfigInfo_Activated(object sender, EventArgs e)
        {
            InitializeTreeView();
        }
        #region【事件：打印 导出】
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgvMain, "实时分站状态信息");
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgvMain, "实时分站状态信息", "");
        }
       

        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(this.dgvMain, "实时分站状态信息", "共" + this.dgvMain.Rows.Count.ToString() + "条记录");
        }

        #endregion



        #region【方法：获取是否启用该报警】

        private bool IsEnableAlarm(int intAlarm)
        {
            bool blIsEnable = false;
            try
            {
                using (ds = new DataSet())
                {
                    ds = rtabll.IsEnableAlarm(intAlarm);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0][0].ToString().Equals("1"))
                        {
                            blIsEnable = true;
                        }
                    }
                }
            }
            catch { }

            return blIsEnable;
        }

        #endregion

    }
}
