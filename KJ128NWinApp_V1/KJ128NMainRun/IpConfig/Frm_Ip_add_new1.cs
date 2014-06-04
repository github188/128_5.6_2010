using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using PrintCore;
using KJ128NInterfaceShow;
using KJ128NMainRun.FromModel;
using KJ128NDataBase;

using Shine.Logs;
using Shine.Logs.LogType;

using System.Text.RegularExpressions;
using System.Xml;
using System.IO;

namespace KJ128NMainRun.IpConfig
{
    public partial class Frm_Ip_add_new1 : FrmModel
    {
       #region 【自定义参数】
        /// <summary>
        /// 查询条件
        /// </summary>
       private string m_strWhere = "1=1";
        /// <summary>
        /// 选择的菜单类型  0为TCP关联  1为TCP配置
        /// </summary>
        private int selectPanleType = 0;
        /// <summary>
        /// 环网逻辑对象
        /// </summary>
       private IpListDataSource_BAl myipbal = new IpListDataSource_BAl();
       /// <summary>
       /// 热备当前刷新次数
       /// </summary>
       private int intRefReshCount = 0;
       /// <summary>
       /// 热备刷新最大次数
       /// </summary>
       private int intHostBackRefCount = 2;

       public bool Save = false;
       #endregion


       #region 【构造函数】
       public Frm_Ip_add_new1( )
        {
            InitializeComponent();
            //添加抽屉菜单
            this.drawerMainControl1.Add(panel_guanglian, true);
            this.drawerMainControl1.Add(panel_peizhi);
            this.drawerMainControl1.LeftPartResize();

            //设置选择的抽屉菜单类型
            selectPanleType = 0;

           //绑定表格
            BindGirdview();
            LoadTcpTree();
        }
        #endregion

        #region 【自定义方法】
        #region 【方法：加载TCP树信息】
        /// <summary>
        /// 加载树信息
        /// </summary>
        public void LoadTcpTree()
        {
            DataTable ds = myipbal.guanlian_tree();
            //DataTable ds1 = myipbal.station_tree();
            if (selectPanleType == 0)//TCP配置
            {
                LoadTree(tvcTcpConfig, ds, " ", false);
            }
            else//Tcp分站关联
            {
                LoadTree(tvcStationTcp, ds, " ", false);
            }
        }
        private void SetDataRow(ref DataRow dr, int id, string name, int parentid, bool isChild, bool isUserNum, int num)
        {
            dr[0] = id;
            dr[1] = name;
            dr[2] = parentid;
            dr[3] = isChild;
            dr[4] = isUserNum;
            dr[5] = num;
        }
        private void LoadTree(DegonControlLib.TreeViewControl tvc, DataTable dsTemp, string strName, bool blCount)
        {
            DataTable dt;

            if (dsTemp != null && dsTemp.Rows.Count > 0)
            {
                dt = dsTemp;
            }
            else
            {
                dt = tvc.BuildMenusEntity();
            }

            DataRow dr = dt.NewRow();
            SetDataRow(ref dr, 0, "所有", -1, false, blCount, 0);
            dt.Rows.Add(dr);
            dt.AcceptChanges();
            tvc.Nodes.Clear();
            tvc.DataSouce = dt;
            tvc.LoadNode(strName);
            tvc.ExpandAll();
        }
        #endregion

        #region 【方法：刷新表格数据】
        /// <summary>
        /// 绑定表格数据
        /// </summary>
        public void BindGirdview()
        {
            if (selectPanleType == 0)
            {
                DataTable dt=myipbal.Getlistbyipid(m_strWhere);
                dt.TableName="Frm_Ip_add_new1_1";
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["ipid"].Visible = false;
            }
            else
            {
                DataTable dt = myipbal.Getstationlistnyipid(m_strWhere);
                dt.TableName = "Frm_Ip_add_new1_2";
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["ipid"].Visible = false;
                dataGridView1.Columns["Stationid"].Visible = false;
            }
            
            btnSelectAll.Text = "全选";
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

        #region 【方法：删除TCP和分站关联信息】
        /// <summary>
        /// 删除TCP和分站关联信息
        /// </summary>
        private void DeleteTcpStation()
        {
            int i = 0;
            ArrayList al = new ArrayList();
            DialogResult result;
            foreach (DataGridViewRow dgvr in dataGridView1.Rows)
            {
                if (dgvr.Cells[0].Value != null && dgvr.Cells[0].Value.Equals("True"))
                {
                    i += 1;
                    string strID = dgvr.Cells["传输分站号"].Value.ToString();
                    al.Add(strID);
                }
            }

            if (i == 0)
            {
                MessageBox.Show("请选择要删除的TCP和分站关联信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            result = MessageBox.Show("是否要删除选中的TCP和分站关联信息？", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                btnSelectAll.Text = "全选";
                for (int j = 0; j < al.Count; j++)
                {
                    string strTemp = (string)al[j];
                    //操作数据库删除
                    myipbal.delstation(int.Parse(strTemp));
                    //存入日志
                    LogSave.Messages("[FrmIpManage]", LogIDType.UserLogID, "删除TCP和分站关联信息，编号为：" + strTemp[0]);
                }

                dataGridView1.ClearSelection();

                if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                {
                    //刷新
                    //绑定表格
                    BindGirdview();
                    LoadTcpTree();
                }
                else                                //热备版，启用定时器
                {
                    HostBackRefresh(true);
                }
                #region[保存环网信息]
                DataTable dt = myipbal.GetTcpIpConfig();
                ReplaceNetXml(dt, Application.StartupPath + "\\TcpServer.xml");
                dt = this.GetStationTable();
                ReplaceStationXml(dt, Application.StartupPath + "\\Station.xml");
                #endregion
            }
        }
        #endregion

        #region 【方法：删除TCP信息】
        /// <summary>
        /// 删除TCP信息
        /// </summary>
        private void DeleteTcp()
        {
            int i = 0;
            ArrayList al = new ArrayList();
            DialogResult result;
            foreach (DataGridViewRow dgvr in dataGridView1.Rows)
            {
                if (dgvr.Cells[0].Value != null && dgvr.Cells[0].Value.Equals("True"))
                {
                    i += 1;
                    string strID = dgvr.Cells["ipid"].Value.ToString();
                    al.Add(strID);
                }
            }

            if (i == 0)
            {
                MessageBox.Show("请选择要删除的TCP信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            result = MessageBox.Show("是否要删除选中的TCP信息？", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                btnSelectAll.Text = "全选";
                for (int j = 0; j < al.Count; j++)
                {
                    string strTemp = (string)al[j];
                    //操作数据库删除
                    myipbal.deleteip(int.Parse(strTemp));
                    //存入日志
                    LogSave.Messages("[FrmIpManage]", LogIDType.UserLogID, "删除TCP信息，编号为：" + strTemp[0]);
                }

                dataGridView1.ClearSelection();

                if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                {
                    //刷新
                    //绑定表格
                    BindGirdview();
                    LoadTcpTree();
                }
                else                                //热备版，启用定时器
                {
                    HostBackRefresh(true);
                }
                #region[保存环网信息]
                DataTable dt = myipbal.GetTcpIpConfig();
                ReplaceNetXml(dt, Application.StartupPath + "\\TcpServer.xml");
                dt = this.GetStationTable();
                ReplaceStationXml(dt, Application.StartupPath + "\\Station.xml");
                #endregion
            }
        }
        #endregion

        #endregion

        #region 【系统事件方法】
        #region 【事件方法：切换成关联分站的TCP界面】
        private void button_guanlian_Click(object sender, EventArgs e)
        {
            if (this.drawerMainControl1.ButtonClick(panel_guanglian.Name))
            {
                m_strWhere = "1=1";
                //环网关联
                selectPanleType = 0;
                //刷新表格
                BindGirdview();
                LoadTcpTree();
            }
        }
        #endregion

        #region 【事件方法：切换成配置TCP界面】
        private void button_peizhi_Click(object sender, EventArgs e)
        {
            if (this.drawerMainControl1.ButtonClick(panel_peizhi.Name))
            {
                m_strWhere = "1=1";
                //环网配置
                selectPanleType = 1;
                //刷新表格
                BindGirdview();
                LoadTcpTree();
            }
        }
        #endregion

        #region 【事件方法：新增配置界面】
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (selectPanleType==0)
            {
                //IP地址添加
                Frm_Ip_Config_new frm = new Frm_Ip_Config_new(this, 0);
                frm.ShowDialog(this);
            }
            else
            {
                //关联配置
                Frm_Station_Add_new frmS = new Frm_Station_Add_new(this, 0);
                frmS.ShowDialog(this);
            }

        }
        #endregion

        #region 【事件方法：全选】
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (btnSelectAll.Text.Equals("全选"))
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        ((DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0]).Value = ((DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0]).TrueValue;
                    }
                    btnSelectAll.Text = "取消";
                }
                else
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        ((DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0]).Value = ((DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0]).FalseValue;
                    }
                    btnSelectAll.Text = "全选";
                }
            }
        } 
        #endregion

        #region 【事件方法：单选】
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    btnSelectAll.Text = "全选";
                    if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null && dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Equals("True"))
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[0].Value = "False";
                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[0].Value = "True";
                    }
                }
            }
        }
        #endregion

        #region 【事件方法：修改】
        private void btnLaws_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = null;
            int i = 0;
            switch (selectPanleType)
            {
                case 0://配置TCP信息
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            if (row.Cells[0].Value.Equals("True"))
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
                        MessageBox.Show("请选择要修改的TCP关联配置信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else if (i > 1)
                    {
                        MessageBox.Show("所选TCP关联配置信息不能大于1个，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if (r != null)
                    {
                        Frm_Ip_Config_new Frm = new Frm_Ip_Config_new(this, 1);
                        Frm.DgvRow = r;
                        Frm.ShowDialog(this);
                    }
                    break;
                case 1://关联TCP和分站信息
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            if (row.Cells[0].Value.Equals("True"))
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
                        MessageBox.Show("请选择要修改的TCP关联配置信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else if (i > 1)
                    {
                        MessageBox.Show("所选TCP关联配置信息不能大于1个，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if (r != null)
                    {
                        Frm_Station_Add_new FrmStationAdd = new Frm_Station_Add_new(this, 1);
                        FrmStationAdd.DgvRow = r;
                        FrmStationAdd.ShowDialog();
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 【系统方法：删除信息】
        private void btnDelete_Click(object sender, EventArgs e)
        {
            switch (selectPanleType)
            {
                case 0://TCP配置
                    DeleteTcp();
                    Save = true;
                    #region[保存环网信息]
                    ConfigXmlWiter.Write("TCPIP.xml");
                    DataTable dt = myipbal.GetTcpIpConfig();
                    ReplaceNetXml(dt, Application.StartupPath + "\\TcpServer.xml");
                    dt = this.GetStationTable();
                    ReplaceStationXml(dt, Application.StartupPath + "\\Station.xml");
                    #endregion
                    break;
                case 1://TCP分站关联
                    DeleteTcpStation();
                    Save = true;
                    #region[保存环网信息]
                    ConfigXmlWiter.Write("TCPIP.xml");
                    DataTable dtt = myipbal.GetTcpIpConfig();
                    ReplaceNetXml(dtt, Application.StartupPath + "\\TcpServer.xml");
                    dtt = this.GetStationTable();
                    ReplaceStationXml(dtt, Application.StartupPath + "\\Station.xml");
                    #endregion
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region【系统方法：热备刷新】
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
                switch (selectPanleType)
                {
                    case 0://TCP分站关联
                        //刷新
                        BindGirdview();
                        LoadTcpTree();
                        break;
                    case 1://TCP配置
                        //刷新
                        BindGirdview();
                        LoadTcpTree();
                        break;
                }
                #endregion

            }
        }
        #endregion

        #region 【事件方法：分站TCP关联界面树单击查询】
        private void tvcStationTcp_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tvcStationTcp.SelectedNode = e.Node;
            switch (e.Node.Level)
            {
                case 0:
                    m_strWhere = "1=1";
                    break;
                case 1:
                    m_strWhere = "ipid=" + e.Node.Name;
                    break;
                default:
                    break;
            }
            BindGirdview();
        }
        #endregion

        #region 【事件方法：TCP配置界面树单击查询】
        private void tvcTcpConfig_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tvcTcpConfig.SelectedNode = e.Node;
            switch (e.Node.Level)
            {
                case 0:
                    m_strWhere = "1=1";
                    break;
                case 1:
                    m_strWhere = "ipid=" + e.Node.Name;
                    break;
                default:
                    break;
            }
            BindGirdview();
        }
        #endregion

        #region【事件：DataGridView错误处理】

        private void dgv_Main_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string strErr = e.Exception.Message;
            e.ThrowException = false;
        }

        #endregion

       

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (dataGridView1.Columns.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        dataGridView1.Columns[i].DefaultCellStyle.NullValue = "——";
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        private void Frm_Ip_add_new1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigXmlWiter.Write("TCPIP.xml");
            if (Save)
            {
                #region[保存环网信息]
                //Czlt-2012-3-28 注销 关闭和保存时都刷新,有重复去掉
                //DataTable dt = myipbal.GetTcpIpConfig();
                //ReplaceNetXml(dt, Application.StartupPath + "\\TcpServer.xml");
                //dt = this.GetStationTable();
                //ReplaceStationXml(dt, Application.StartupPath + "\\Station.xml");
                #endregion
            }
        }



        public bool ReplaceNetXml(DataTable dt, string strPath)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(strPath);
                XmlNode rootnode = xmldoc.SelectSingleNode("DocumentElement");
                rootnode.RemoveAll();
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        XmlNode node = xmldoc.CreateElement("TcpIpConfig");
                        XmlNode idNode = xmldoc.CreateElement("ipID");
                        idNode.InnerText = dt.Rows[i]["ipID"].ToString();
                        XmlNode ipaddressNode = xmldoc.CreateElement("IpAddress");
                        ipaddressNode.InnerText = dt.Rows[i]["IpAddress"].ToString();
                        XmlNode ipPort = xmldoc.CreateElement("IpPort");
                        ipPort.InnerText = dt.Rows[i]["IpPort"].ToString();
                        node.AppendChild(idNode);
                        node.AppendChild(ipaddressNode);
                        node.AppendChild(ipPort);
                        rootnode.AppendChild(node);
                    }
                }
                xmldoc.Save(strPath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #region[分站]
        public DataTable GetStationTable()
        {
            bool commType = this.GetCommType();
            if (!commType)
            {
                return this.GetStationInfo(1);
            }
            else
            {
                return this.GetStationInfo(2);
            }
        }

        public DataTable GetStationInfo(int sign)
        {
            return new A_StationBLL().Get_StationInfo(sign);
        }

        /// <summary>
        /// 重写Station.xml文件
        /// </summary>
        /// <returns>true重写成功false重写失败</returns>
        public bool ReplaceStationXml(DataTable dt, string strPath)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(System.Windows.Forms.Application.StartupPath.ToString() + @"\SerialPort.xml");
                XmlNode markrootnode = xml.SelectSingleNode("DocumentElement");
                int commType = 0;
                int tcpMark = 0;
                XmlDocument xmlcomm = new XmlDocument();
                if (File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\CommType.xml"))
                {
                    xmlcomm.Load(System.Windows.Forms.Application.StartupPath.ToString() + @"\CommType.xml");
                    try
                    {
                        XmlNode xmlnodeComm = xmlcomm.SelectSingleNode("/comm/commType");
                        if (xmlnodeComm != null)
                        {
                            commType = int.Parse(xmlnodeComm.InnerText);
                        }
                    }
                    catch
                    {
                    }
                    if (commType != 0)
                    {
                        try
                        {
                            XmlNode xmlnodeTcpMark = xmlcomm.SelectSingleNode("/comm/TcpMark");
                            if (xmlnodeTcpMark != null)
                            {
                                tcpMark = int.Parse(xmlnodeTcpMark.InnerText);
                            }
                        }
                        catch { }
                    }
                }

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(strPath);
                XmlNode rootnode = xmldoc.SelectSingleNode("DocumentElement");
                rootnode.RemoveAll();
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < markrootnode.ChildNodes.Count; j++)
                        {
                            if (commType == 0)
                            {
                                XmlNode Groupnode = xmldoc.CreateElement("Group");
                                if (markrootnode.ChildNodes[j].ChildNodes[2].InnerText.Equals(dt.Rows[i]["StationGroup"].ToString()))
                                {
                                    Groupnode.InnerText = dt.Rows[i]["StationGroup"].ToString();
                                    XmlNode node = xmldoc.CreateElement("Station");
                                    XmlNode idnode = xmldoc.CreateElement("ID");
                                    idnode.InnerText = dt.Rows[i]["ID"].ToString();
                                    XmlNode addressnode = xmldoc.CreateElement("Address");
                                    addressnode.InnerText = dt.Rows[i]["Address"].ToString();

                                    XmlNode statenode = xmldoc.CreateElement("State");
                                    statenode.InnerText = "0";
                                    XmlNode marknode = xmldoc.CreateElement("Mark");

                                    marknode.InnerText = markrootnode.ChildNodes[j].ChildNodes[3].InnerText;

                                    XmlNode isenablenode = xmldoc.CreateElement("Ver");
                                    isenablenode.InnerText = dt.Rows[i]["Ver"].ToString();
                                    XmlNode ipaddressNode = xmldoc.CreateElement("IpAddress");
                                    ipaddressNode.InnerText = dt.Rows[i]["IpAddress"].ToString();
                                    XmlNode ipPort = xmldoc.CreateElement("IpPort");
                                    ipPort.InnerText = dt.Rows[i]["IpPort"].ToString();
                                    XmlNode stationModelNode = xmldoc.CreateElement("StationModel");
                                    stationModelNode.InnerText = dt.Rows[i]["StationModel"].ToString();
                                    node.AppendChild(idnode);
                                    node.AppendChild(addressnode);
                                    node.AppendChild(Groupnode);
                                    node.AppendChild(statenode);
                                    node.AppendChild(marknode);
                                    node.AppendChild(isenablenode);
                                    node.AppendChild(ipaddressNode);
                                    node.AppendChild(ipPort);
                                    node.AppendChild(stationModelNode);
                                    rootnode.AppendChild(node);
                                }
                            }
                            else
                            {
                                XmlNode Groupnode = xmldoc.CreateElement("Group");
                                if (markrootnode.ChildNodes[j].ChildNodes[2].InnerText.Equals(dt.Rows[i]["StationGroup"].ToString()))
                                {
                                    Groupnode.InnerText = dt.Rows[i]["StationGroup"].ToString();
                                    XmlNode node = xmldoc.CreateElement("Station");
                                    XmlNode idnode = xmldoc.CreateElement("ID");
                                    idnode.InnerText = dt.Rows[i]["ID"].ToString();
                                    XmlNode addressnode = xmldoc.CreateElement("Address");
                                    addressnode.InnerText = dt.Rows[i]["Address"].ToString();

                                    XmlNode statenode = xmldoc.CreateElement("State");
                                    statenode.InnerText = "0";
                                    XmlNode marknode = xmldoc.CreateElement("Mark");

                                    marknode.InnerText = tcpMark.ToString();

                                    XmlNode isenablenode = xmldoc.CreateElement("Ver");
                                    isenablenode.InnerText = dt.Rows[i]["Ver"].ToString();
                                    XmlNode ipaddressNode = xmldoc.CreateElement("IpAddress");
                                    ipaddressNode.InnerText = dt.Rows[i]["IpAddress"].ToString();
                                    XmlNode ipPort = xmldoc.CreateElement("IpPort");
                                    ipPort.InnerText = dt.Rows[i]["IpPort"].ToString();
                                    XmlNode stationModelNode = xmldoc.CreateElement("StationModel");
                                    stationModelNode.InnerText = dt.Rows[i]["StationModel"].ToString();
                                    node.AppendChild(idnode);
                                    node.AppendChild(addressnode);
                                    node.AppendChild(Groupnode);
                                    node.AppendChild(statenode);
                                    node.AppendChild(marknode);
                                    node.AppendChild(isenablenode);
                                    node.AppendChild(ipaddressNode);
                                    node.AppendChild(ipPort);
                                    node.AppendChild(stationModelNode);
                                    rootnode.AppendChild(node);
                                }

                            }
                        }
                    }
                }
                xmldoc.Save(strPath);
                return true;
            }
            catch
            {
                return false;
            }
        }


        private bool GetCommType()
        {
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "CommType.xml");
                XmlNode node = xmlDocument.SelectSingleNode("/comm/commType");
                if (node.InnerText != "" && node.InnerText.Equals("1") == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

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
        #region 【事件：打印 导出】
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dataGridView1, PrintTableName());
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dataGridView1, PrintTableName(), "");
        }
        private string PrintTableName()
        {
            switch (selectPanleType)
            {
                case 0://人员巡检
                    return "环网配置信息";
                case 1://巡检路径
                    return "传输分站与环网关联信息";
                default: return "环网配置信息";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
          
            KJ128NDBTable.PrintBLL.Print(dataGridView1, PrintTableName(), lblCounts.Text);
        }
        #endregion
    }
}
