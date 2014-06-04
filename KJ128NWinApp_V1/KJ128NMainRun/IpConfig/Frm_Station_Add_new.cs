using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128WindowsLibrary;
using ZdcCommonLibrary;
using KJ128NDataBase;
using System.Data.SqlClient;

using Shine.Logs;
using Shine.Logs.LogType;

using System.Text.RegularExpressions;
using KJ128NDBTable;
namespace KJ128NMainRun.IpConfig
{
    public partial class Frm_Station_Add_new : Form
    {
        #region 【自定义参数】
        private IpListDataSource_BAl myipbal = new IpListDataSource_BAl();
        private Frm_Ip_add_new1 frmipadd;
        private string tempip;
        /// <summary>
        /// 操作类型  1添加  2修改
        /// </summary>
        private int m_type;
        /// <summary>
        /// 传入数据
        /// </summary>
        private DataGridViewRow m_dgvRow;
        /// <summary>
        /// 获取的数据
        /// </summary>
        public DataGridViewRow DgvRow
        {
            set { m_dgvRow = value; }
        }
        #endregion

        #region 【构造函数】
        public Frm_Station_Add_new(Frm_Ip_add_new1 frm_add,int f_type)
        {
            InitializeComponent();
            frmipadd = frm_add;
            m_type = f_type;
            
        }
        #endregion

        #region 【自定义方法】
        #region 【方法：设置显示提示信息】
        /// <summary>
        /// 设置显示提示信息
        /// </summary>
        /// <param name="strMessage">显示信息</param>
        /// <param name="c">颜色</param>
        private void SetShowInfo(string strMessage, Color c)
        {
            labMessage.Visible = true;
            labMessage.ForeColor = c;
            labMessage.Text = strMessage;
        }
        #endregion

        #region 【方法：获取传输分站下拉列表框信息】
        /// <summary>
        /// 获取传输分站下拉列表框
        /// </summary>
        private void stationdrop()
        {
            try
            {
                DataSet ds = myipbal.getstationdrop();
                DataTable dt = new DataTable();
                DataRow dr = null;
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                    dr = dt.NewRow();
                    dr["stationid"] = 0;
                    dr["stationaddress"] = "选择";
                    dt.Rows.InsertAt(dr, 0);
                    comboBox_station.DataSource = dt;
                    comboBox_station.ValueMember = "stationid";
                    comboBox_station.DisplayMember = "stationaddress";
                }
            }
            catch { }
        }
        #endregion

        #region 【方法：获取环网配置信息下拉列表框】
        /// <summary>
        /// 获取环网配置下拉列表框
        /// </summary>
        private void ipdrop()
        {
            try
            {
                DataSet ds = myipbal.getipdrop();
                DataTable dt = new DataTable();
                DataRow dr = null;
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                    dr = dt.NewRow();
                    dr["ipid"] = 0;
                    dr["ipaddress"] = "选择";
                    dt.Rows.InsertAt(dr, 0);
                    comboBox_ip.DataSource = dt;
                    comboBox_ip.ValueMember = "ipid";
                    comboBox_ip.DisplayMember = "ipaddress";
                }
            }
            catch { }
            //if (myipbal.getipdrop().Tables[0].Rows.Count > 0)
            //{
            //    comboBox_ip.DataSource = myipbal.getipdrop().Tables[0];
            //    comboBox_ip.ValueMember = "ipid";
            //    comboBox_ip.DisplayMember = "ipaddress";
            //}

        }
        #endregion

        #region 【方法：绑定修改数据】
        private void bindtext()
        {
            try
            {
                comboBox_ip.SelectedValue = m_dgvRow.Cells["ipid"].Value.ToString();
            }
            catch
            {
                if (comboBox_ip.Items.Count > 0)
                {
                    comboBox_ip.SelectedIndex = 0;
                }
                else
                {
                    comboBox_ip.SelectedIndex = -1;
                }
            }
            try
            {
                comboBox_station.SelectedValue = m_dgvRow.Cells["Stationid"].Value.ToString();
            }
            catch
            {
                if (comboBox_station.Items.Count > 0)
                {
                    comboBox_station.SelectedIndex = 0;
                }
                else
                {
                    comboBox_station.SelectedIndex = -1;
                }
            }
        }
        #endregion

        #region 【方法：判断】
        private bool Check()
        {
            if (comboBox_ip.SelectedIndex<=0)
            {
                SetShowInfo("请选择IP地址信息", Color.Red);
                return false;
            }
            if (comboBox_station.SelectedIndex<=0)
            {
                SetShowInfo("请选择传输分站信息", Color.Red);
                return false;
            }
            return true;
        }
        #endregion
        #endregion

        #region 【系统事件方法】
        #region 【事件方法：窗体加载】
        private void Frm_Station_Add_new_Load(object sender, EventArgs e)
        {
            ipdrop();
            stationdrop();

            if (m_type == 0)
            {
                this.Text = "新增环网关联配置";
                if (comboBox_ip.Items.Count > 0)
                {
                    comboBox_ip.SelectedIndex = 0;
                }
                if (comboBox_station.Items.Count > 0)
                {
                    comboBox_station.SelectedIndex = 0;
                }
            }
            else
            {
                this.Text = "修改环网关联配置";
                bindtext();
                comboBox_station.Enabled = false;
            }
        }
        #endregion

        #region 【事件方法：关闭窗体】
        private void bCPl_return_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 【事件方法：IP下拉列表选择】
        private void comboBox_ip_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox_ip.SelectedIndex > 0)
            {
                int ipid = Convert.ToInt32(comboBox_ip.SelectedValue.ToString());

                textBox_ipweizhi.Text = myipbal.ipplace(ipid);

            }
            else
            {
                textBox_ipweizhi.Text = "";
            }
        }
        #endregion

        #region 【事件方法：传输分站下拉列表选择】
        private void comboBox_station_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_station.SelectedIndex > 0)
            {
                //分站安装位置
                int stationid = Convert.ToInt32(comboBox_station.SelectedValue.ToString());

                textBox_place.Text = myipbal.stationplace(stationid);
            }
            else
            {
                textBox_place.Text = "";
            }
        }
        #endregion

        #region 【事件方法：保存数据】
        private void bCPl_save_Click(object sender, EventArgs e)
        {
            if (m_type == 0)//新增环网IP地址
            {
                if (!Check())
                {
                    return;
                }
                string ipid = comboBox_ip.SelectedValue.ToString();
                string stationid = comboBox_station.SelectedValue.ToString();

                if (RecordSearch.IsRecordExists("station_info", "IPAddressID <>0 and stationid=" + stationid))
                {
                    SetShowInfo("该传输分站已配置进环网", Color.Red);
                    return;
                }

                int i = myipbal.updatestation(Convert.ToInt32(stationid), Convert.ToInt32(ipid));
                if (i == 1)
                {
                    SetShowInfo("添加成功", Color.Black);
                    frmipadd.Save = true;

                    //Czlt-2011-12-10 修改时间
                    myipbal.UpdateTime();
                   
                    //刷新
                    if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                    {
                        frmipadd.BindGirdview();
                        frmipadd.LoadTcpTree();
                    }
                    else                                //热备版，启用定时器
                    {
                        frmipadd.HostBackRefresh(true);
                    }
                    #region[保存环网信息]
                    //Czlt-2012-3-28 热备配置文件
                    ConfigXmlWiter.Write("TCPIP.xml");
                    //Czlt-2012-3-28 刷新分站列表
                    DataTable dt = myipbal.GetTcpIpConfig();
                    frmipadd.ReplaceNetXml(dt, Application.StartupPath + "\\TcpServer.xml");
                    dt = frmipadd.GetStationTable();
                    frmipadd.ReplaceStationXml(dt, Application.StartupPath + "\\Station.xml");
                    #endregion
                }
                else
                {
                    SetShowInfo("添加失败", Color.Black);
                }
            }
            else//修改环网IP地址
            {
                if (!Check())
                {
                    return;
                }

                string ipid = comboBox_ip.SelectedValue.ToString();
                string stationid = comboBox_station.SelectedValue.ToString();

                int i = myipbal.updatestation(Convert.ToInt32(stationid), Convert.ToInt32(ipid));
                if (i == 1)
                {
                    SetShowInfo("修改成功", Color.Black);
                    frmipadd.Save = true;

                    //Czlt-2011-12-10 修改时间
                    myipbal.UpdateTime();
                   
                    if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                    {
                        frmipadd.BindGirdview();
                        frmipadd.LoadTcpTree();
                    }
                    else                                //热备版，启用定时器
                    {
                        frmipadd.HostBackRefresh(true);
                    }
                    #region[保存环网信息]
                    //Czlt-2012-3-28 热备配置文件
                    ConfigXmlWiter.Write("TCPIP.xml");
                    //Czlt-2012-3-28 刷新分站列表
                    DataTable dt = myipbal.GetTcpIpConfig();
                    frmipadd.ReplaceNetXml(dt, Application.StartupPath + "\\TcpServer.xml");
                    dt = frmipadd.GetStationTable();
                    frmipadd.ReplaceStationXml(dt, Application.StartupPath + "\\Station.xml");
                    #endregion
                }
                else
                {
                    SetShowInfo("修改失败", Color.Red);
                }

            }
        }
        #endregion
        #endregion
    }
}
