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
    public partial class Frm_Ip_Config_new : Form
    {
        #region 【自定义参数】
        private IpListDataSource_BAl myipbal = new IpListDataSource_BAl();
        private Frm_Ip_add_new1 frmipadd ;
        private string ipid="";
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
        public Frm_Ip_Config_new(Frm_Ip_add_new1 frm_add,int f_type)
        {
            InitializeComponent();
            frmipadd = frm_add;
            m_type = f_type;
        }
        #endregion

        #region 【自定义方法】

        #region 【方法：验证IP合法性】
        public static bool checkIpAddress(string strIpAddress)
        {
            try
            {
                string webServerAddress;
                Regex r = new Regex(@"^(\d+)\.(\d+)\.(\d+)\.(\d+)$");//IP地址的正则表达式
                Match m;
                webServerAddress = strIpAddress.Trim();
                m = r.Match(webServerAddress);
                if (m.Success)   //进一步判断IP地址的合法性
                {
                    //获取该IP地址的段数
                    int j = checkIpAddressMore(webServerAddress);
                    if (j == 4)
                        return true;// 满足IP地址格式的要求
                    else
                        return false;//非法地址
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private static int checkIpAddressMore(string strIpAdderss)
        {
            string[] stringArray;
            int j = 0;
            //分割字符串
            stringArray = strIpAdderss.Split('.');
            foreach (string strVar in stringArray)
            {
                if (int.Parse(strVar) <= 255)
                {
                    j++;
                }
                else
                {
                    break;
                }
            }
            return j;
        }

        #endregion

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

        #region 【方法：判断输入信息】
        /// <summary>
        /// 判断输入信息
        /// </summary>
        /// <returns></returns>
        private bool Check()
        {
            if (textBox_ip.Text.Length > 0)
            {
                if (!checkIpAddress(textBox_ip.Text))
                {
                    SetShowInfo("IP地址不正确,请重新输入," + "\r\n" + " 输入格式:192.168.1.1",Color.Red);
                    return false;
                }
            }
            else
            {
                SetShowInfo("IP不能为空，请重新输入", Color.Red);
                return false;
            }
            if (textBox_ipport.Text.Length < 1)
            {
                SetShowInfo("端口号不能为空", Color.Red);
                return false;
            }
            if (int.Parse(textBox_ipport.Text) <= 1024 || int.Parse(textBox_ipport.Text) >= 65535)
            {
                SetShowInfo("端口号配置不正确 " + "\r\n" + " 端口号为1024至65535", Color.Red);
                return false;
            }
            return true;
        }
        #endregion

        #region 【方法：绑定文本框】
        /// <summary>
        /// 绑定文本框
        /// </summary>
        private void BindText()
        {
            try
            {
                textBox_azwz.Text = m_dgvRow.Cells["安装地址"].Value.ToString();//安装位置
                textBox_ip.Text = m_dgvRow.Cells["IP地址"].Value.ToString();//IP地址
                textBox_ipport.Text = m_dgvRow.Cells["IP端口"].Value.ToString();//IP端口
                ipid = m_dgvRow.Cells["ipid"].Value.ToString();//ip编号
            }
            catch
            { }
        }
        #endregion
        #endregion

        #region 【系统事件方法】
        #region 【事件方法：窗体加载】
        private void Frm_Ip_Config_new_Load(object sender, EventArgs e)
        {
            switch (m_type)
            {
                case 0://添加
                    this.Text = "新增环网IP地址";
                    break;
                case 1://修改
                    this.Text = "修改环网IP地址";
                    textBox_ip.Enabled = false;
                    BindText();
                    break;
                default://查看
                    break;
            }
        }
        #endregion

        #region 【系统事件：保存TCP信息】
        private void buttonCaptionPanel_save_Click(object sender, EventArgs e)
        {
            if (m_type == 0)//新增环网IP地址
            {
                if (!Check())
                {
                    return;
                }
                if (RecordSearch.IsRecordExists("TcpIPConfig", "IPAddress ='"+ textBox_ip.Text.Trim()+"'"))
                {
                    SetShowInfo("IP不能为重复，请重新输入", Color.Red);
                    return;
                }

                int i = myipbal.addip(textBox_ip.Text.Trim(), textBox_ipport.Text.Trim(), textBox_azwz.Text.Trim());
                if (i == 1)
                {
                    SetShowInfo("添加成功", Color.Black);
                    frmipadd.Save = true;
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
                string ip = textBox_ip.Text.Trim();
                string port = textBox_ipport.Text.Trim();
                string address = textBox_azwz.Text.Trim();

                if (!Check())
                {
                    return;
                }
                if (RecordSearch.IsRecordExists("TcpIPConfig", "ipid<>" + ipid + " and ipaddress='" + textBox_ip.Text.Trim()+"'"))
                {
                    SetShowInfo("IP不能为重复，请重新输入", Color.Red);
                    return;
                }
                int i = myipbal.updateip(ip, port, address, int.Parse(ipid));
                if (i == 1)
                {
                    SetShowInfo("修改成功", Color.Black);
                    frmipadd.Save = true;
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

        #region 【系统事件：关闭窗体】
        private void buttonCaptionPanel_fanhui_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void textBox_azwz_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
        #endregion

        private void textBox_ip_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_ipport_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
    }
}
