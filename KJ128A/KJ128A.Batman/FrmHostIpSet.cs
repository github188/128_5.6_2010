using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using KJ128NMainRun;

namespace KJ128A.Batman
{
    /// <summary>
    /// 热备配置窗体
    /// </summary>
    public partial class FrmHostIpSet : Form
    {
        #region [ 声明 ]
        
        /// <summary>
        /// 配置文件保存路径
        /// </summary>
        public readonly string strPath = String.Empty;  

        /// <summary>
        /// 临时存放热备配置的表
        /// </summary>
        public DataTable dtSave = new DataTable();

        #endregion

        /*
         * 委托
         */

        #region [ 声明:委托 ] 热备配置更改事件

       /// <summary>
       /// 监听用户更改热备配置
       /// </summary>
       /// <param name="bIsStartHost">是否启用热备</param>
       /// <param name="IsHost">是否主机</param>
       /// <param name="strIpAddress">Ip地址</param>
       /// <param name="strPort">监听端口号</param>
        public delegate void ListenHostSetEventHandler(bool bIsStartHost,bool IsHost,string strIpAddress,string strPort);

        /// <summary>
        /// 监听用户更改热备配置事件
        /// </summary>
        public event ListenHostSetEventHandler ListenHostSet;

        #endregion

        #region [ 声明:委托 ] 错误消息事件

        /// <summary>
        /// 错误消息声明
        /// </summary>
        /// <param name="iErrNO">错误编号</param>
        /// <param name="strStackTrace">获取当前异常发生时调用堆栈上的帧的字符串表示形式</param>
        /// <param name="strSource">标识当前哪一段程序出的错误</param>
        /// <param name="strMessage">获取描述当前异常的消息</param>
        public delegate void ErrorMessageEventHandler(int iErrNO, string strStackTrace, string strSource, string strMessage);

        /// <summary>
        /// 错误消息事件
        /// </summary>
        public event ErrorMessageEventHandler ErrorMessage;

        #endregion

        #region [ 错误类编号 ]
        
        /// <summary>
        /// 处理错误信息
        /// </summary>
        /// <param name="iErrNO">错误编号</param>
        /// <param name="strStackTrace">获取当前异常发生时调用堆栈上的帧的字符串表示形式</param>
        /// <param name="strSource">标识当前哪一段程序出的错误</param>
        /// <param name="strMessage">获取描述当前异常的消息</param>
        public void _ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            string strError = String.Empty;
            switch (iErrNO)
            {
                case 6010001:
                    strError = "读取XML文件出错，具体原因为：" + strMessage;
                    break;
                case 6010002:
                    strError = "写XML文件出错，具体原因为：" + strMessage;
                    break;
                default:
                    break;
            }
            if (ErrorMessage != null)
            {
                ErrorMessage(iErrNO, strStackTrace, strSource, strError);
            }
        }

        #endregion

        /*
         * 构造函数
         */

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strXMLPath">XML配置文件保存路径</param>
        public FrmHostIpSet(string strXMLPath)
        {
            strPath = System.Windows.Forms.Application.StartupPath.ToString() + @"\" + strXMLPath;
            InitializeComponent();
        }

        #endregion

        /*
         * 事件
         */

        #region [ 事件: 窗体加载 ]

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmHostIpSet_Load(object sender, EventArgs e)       
        {
            //构造配置表
            BuildTable();
            ReadXmlToTable();
        }

        #endregion

        #region [ 事件: 点击“取消”按钮 ]

        /// <summary>
        /// 取消按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dtSave.Rows.Count > 0)
            {
                //重新加载原有配置
                LoadOldIpSet();
            }
            else
            {
                //初始化控件
                ckbStartHost.Checked = false;
            }
        }

        #endregion

        #region [ 事件: 是否启用热备 ]

        private void ckbStartHost_CheckedChanged(object sender, EventArgs e)
        {
            ckbStartHost_change();
        }

        #endregion

        #region [ 事件: 点击“保存”按钮 ]

        /// <summary>
        /// 点击“保存”按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ckbStartHost.Checked)
            {
                if (CheckEmpty())
                {
                    if (CheckIP(txtIpAddress))
                    {
                        
                        if (SaveBuildXml())
                        {
                            if (ErrorMessage != null)
                            {
                                string strMessage = "热备已启用！IP地址："+txtIpAddress.Text.Trim()+"  对方监听端口号："+
                                    txtPort.Text.Trim();
                                ErrorMessage(8010013, string.Empty, "[FrmHostIP:btnSave_Click]", strMessage);
                            }
                            if (ListenHostSet != null)
                            {
                                ListenHostSet(true, rbtnHost.Checked, txtIpAddress.Text.Trim(), txtPort.Text.Trim());
                            }
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                //File.Delete(strPath);
                SaveBuildXml();

                if (ErrorMessage != null)
                {
                    ErrorMessage(8010013, "", "[FrmHostIP:btnSave_Click]", "[ 热备已停用！]");
                }

                if (ListenHostSet != null)
                {
                    ListenHostSet(false,false,"", "");
                }

                this.Close();
            }
        }

        #endregion

        /*
         * 外部方法
         */

        #region [ 接口: 提取热备的配置信息 ]

        /// <summary>
        /// 提取热备的配置信息
        /// </summary>
        /// <param name="bIsStartHost">是否启用热备</param>
        /// <param name="bIsHost">是否为主机</param>
        /// <param name="strIpAddress">对方IP</param>
        /// <param name="strPort">对方监听端口号</param>
        public bool ReturnHostSet(out bool bIsStartHost,out bool bIsHost,out string strIpAddress,out string strPort)
        {
            bIsStartHost = false;
            bIsHost = false;
            strIpAddress = String.Empty;
            strPort = String.Empty;

            if (File.Exists(strPath))
            {
                try
                {
                    //构造配置表
                    BuildTable();
                    dtSave.ReadXml(strPath); //读取数据库的配置

                    if (dtSave.Rows.Count > 0)
                    {
                        DataRow dr = dtSave.Rows[0];
                        bIsStartHost = Convert.ToBoolean(dr["IsStartHost"].ToString());
                        bIsHost = Convert.ToBoolean(dr["IsHost"].ToString());
                        strIpAddress = dr["IPAddress"].ToString();
                        strPort = dr["PortID"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    _ErrorMessage(6010001, ex.StackTrace, ex.Source, ex.Message);
                    return false;
                }
                return true;
            }
            else
            {
                return true;
            }
        }

        #endregion
        
        /*
         * 方法
         */

        #region [ 方法: 构造配置表 ]

        /// <summary>
        /// 构造配置表
        /// </summary>
        private void BuildTable()
        {
            dtSave.TableName = "IPHostBuild";
            dtSave.Columns.Add("IsStartHost");
            dtSave.Columns.Add("IsHost");
            dtSave.Columns.Add("IPAddress");
            dtSave.Columns.Add("PortID");
            dtSave.AcceptChanges();
        }

        #endregion

        #region [ 方法: 保存配置信息到XML文件 ]

        /// <summary>
        /// 保存配置信息到XML文件
        /// </summary>
        private bool SaveBuildXml()
        {
            dtSave.Rows.Clear();

            //增加IP配置一
            DataRow dr = dtSave.NewRow();
            dr["IsStartHost"] = ckbStartHost.Checked;
            dr["IsHost"] = rbtnHost.Checked;
            dr["IPAddress"] = txtIpAddress.Text.Trim();
            dr["PortID"] = txtPort.Text.Trim();
          
            //将配置添加到表
            dtSave.Rows.Add(dr);
            dtSave.AcceptChanges();

            try
            {
                //存储为XML文件格式
                dtSave.WriteXml(strPath, true);
            }
            catch(Exception ex)
            {
                _ErrorMessage(6010002, ex.StackTrace, ex.Source, ex.Message);
                return false;
            }
            return true;
        }

        #endregion

        #region [ 方法: 检查文本框是否为空 ]

        /// <summary>
        /// 检查文本框是否为空
        /// </summary>
        /// <returns></returns>
        private bool CheckEmpty()
        {
            if (txtIpAddress.Text.Trim() == "")
            {
                return ShowError("请输入IP地址！", txtIpAddress);
            }
            else if (txtPort.Text.Trim() == "")
            {
                return ShowError("请配置端口号！", txtPort);
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region [ 方法: 正则表达式初步验证IP地址]

        /// <summary>
        /// 正则表达式初步验证IP地址
        /// </summary>
        /// <param name="txtIP">IP配置文本框</param>
        /// <returns></returns>
        public bool CheckIP(TextBox txtIP)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtIP.Text.Trim(), @"^((0|(?:[1-9]\d{0,1})|(?:1\d{2})|(?:2[0-4]\d)|(?:25[0-5]))\.){3}((?:[1-9]\d{0,1})|(?:1\d{2})|(?:2[0-4]\d)|(?:25[0-5]))$"))
            {
                ttpMessage.SetToolTip(btnSave, "输入的IP地址格式不对！");
                txtIP.SelectAll();
                txtIP.Focus();
                return false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtPort.Text.Trim(), @"^[1-9]\d*$") )
            {
                ttpMessage.SetToolTip(btnSave, "输入的端口号格式不对！");
                txtPort.SelectAll();
                txtPort.Focus();
                return false;
            }
            else if (Convert.ToInt32(txtPort.Text.Trim())>65535)
            {
                ttpMessage.SetToolTip(btnSave, "输入的端口号不可以大于65535！");
                txtPort.SelectAll();
                txtPort.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region  [ 方法: 提示用户有文本框未填写 ]

        /// <summary>
        /// 提示用户有文本框未填写
        /// </summary>
        /// <param name="strMessage">提示信息</param>
        /// <param name="txt">文本框</param>
        private bool ShowError(string strMessage, TextBox txt)
        {
            ttpMessage.SetToolTip(btnSave, strMessage);
            txt.Focus();
            return false;
        }

        #endregion

        #region [ 方法: 加载XML配置文件 ]

        /// <summary>
        /// 加载XML配置文件
        /// </summary>
        private void LoadOldIpSet()
        {
            if (dtSave.Rows.Count > 0)
            {
                DataRow dr = dtSave.Rows[0];
                ckbStartHost.Checked = Convert.ToBoolean(dr["IsStartHost"].ToString());
                rbtnHost.Checked = Convert.ToBoolean(dr["IsHost"].ToString());
                rbtnBack.Checked = !rbtnHost.Checked;
                txtIpAddress.Text = dr["IPAddress"].ToString();
                txtPort.Text = dr["PortID"].ToString();
                ckbStartHost_change();
            }
        }

        #endregion

        #region [ 方法: 是否启用热备 ]

        /// <summary>
        /// 是否启用热备
        /// </summary>
        private void ckbStartHost_change()
        {
            gpbMax.Enabled = ckbStartHost.Checked;
            if (!ckbStartHost.Checked)
            {
                txtIpAddress.Clear();
                txtPort.Text = "60001";
            }
        }

        #endregion

        #region [ 方法: 读取XML文件 ]

        /// <summary>
        /// 读取XML文件
        /// </summary>
        /// <returns></returns>
        private bool ReadXmlToTable()
        {
            dtSave.Rows.Clear();
            if (File.Exists(strPath))
            {
                try
                {
                    dtSave.ReadXml(strPath); //读取数据库的配置
                    LoadOldIpSet();
                }
                catch (Exception ex)
                {
                    _ErrorMessage(6010001, ex.StackTrace, ex.Source, ex.Message);
                    return false;
                }
                return true;
            }
            else
            {
                ckbStartHost.Checked = false;
                gpbMax.Enabled = ckbStartHost.Checked;
                return false;
            }
        }

        #endregion

        private void txtIpAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

    }
}