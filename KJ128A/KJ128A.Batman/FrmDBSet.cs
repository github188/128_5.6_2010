using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using KJ128A.BatmanAPI;
using KJ128A.Controls.Batman;

namespace KJ128A.Batman
{
    /// <summary>
    /// 数据库连接设置窗体
    /// </summary>
    public partial class FrmDBSet : Form
    {
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

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="index"></param>
        /// <param name="strFilePath"></param>
        public FrmDBSet(IFrmMain frm, int index, string strFilePath)
        {
            InitializeComponent();

            frmMain = frm; //主界面
            dataIndex = index; //服务器索引
          
            strPath = strFilePath; //XML配置文件保存路径
        }

        #endregion

        #region [ 声明 ]

        private string data_source = String.Empty; // 数据库名称

        private int dataIndex; // 编号 
        private DataRow[] drs;
        private DataTable dt = new DataTable(); // 存放信息的表
        private readonly IFrmMain frmMain = null; //主窗体 
        private bool loginModel_flag = true; // loginModel_flag为true时，为Windows验证；为0时，为SQL验证
        private string passID = String.Empty; // 密码
        private ConnParamSet sqlCs = new ConnParamSet(); // 创建一个数据库连接类的实例
        private string strPath = ""; //文件路径
        private string strServerName = String.Empty; // 服务器名称
        private string user = String.Empty; // 用户名
        private string strFlag = String.Empty; //主机还是备机

        #endregion

        #region [ 方法:“开始”面板和“下一步”面板切换 ]

        /// <summary>
        /// “开始”面板和“下一步”面板切换
        /// </summary>
        /// <param name="bln">是否显示"开始"面板</param>
        private void PanelState(bool bln)
        {
            pnlNext.Visible = !bln;
            pnlStart.Visible = bln;
        }

        #endregion

        #region [ 方法: Windows验证单选按钮的状态 ]

        /// <summary>
        /// Windows验证单选按钮的状态
        /// </summary>
        /// <param name="bWin">是否是Windows验证</param>
        private void WindowsCon(bool bWin)
        {
            sql_rb.Checked = !bWin;
            win_rb.Checked = bWin;
            loginBox.Enabled = !bWin;
            mimaBox.Enabled = !bWin;
            label_loginID.Enabled = !bWin;
            lable_loginName.Enabled = !bWin;

            loginModel_flag = bWin; //保存验证形式标识

            if (bWin)
            {
                loginBox.Clear();
                mimaBox.Clear();
            }
        }

        #endregion

        #region [ 方法: 验证按钮的状态 ]

        /// <summary>
        /// 验证按钮的状态
        /// </summary>
        /// <param name="bStatu">是否验证成功</param>
        private void ConSussesStatu(bool bStatu)
        {
            btnCommit.Enabled = bStatu;
            btnNext.Enabled = !bStatu;
        }

        #endregion

        #region [ 方法: 读取XML文件 ]

        /// <summary>
        /// 读取XML文件
        /// </summary>
        /// <param name="strPath">路径</param>
        /// <returns></returns>
        private DataTable ReadXmlToTable(string strPath)
        {
            DataTable dt = MainHelper.BuildDBConfigTable(strPath);
            try
            {
                dt.ReadXml(strPath); //读取数据库的配置
            }
            catch
            {
                return dt;
            }

            return dt;
        }

        #endregion

        #region [ 方法: 返回服务器名称 ]

        /// <summary>
        /// 返回服务器名称
        /// </summary>
        /// <param name="strSerName">服务器名称</param>
        /// <param name="bEnble">查找服务器按钮的Enable状态</param>
        /// <returns></returns>
        public bool UpdateServerName(string strSerName, bool bEnble)
        {
            if (strSerName != "")
            {
                cbbServername.Text = strSerName;
            }

            btnSelectSQLName.Enabled = bEnble;

            CloseWaiteMessage(); //关闭等待提示

            return true;
        }

        #endregion

        #region  [ 方法: 显示和关闭等待条 ]

        /// <summary>
        /// 显示等待条
        /// </summary>
        /// <param name="strMessage">等待是显示的提示</param>
        private void OpenWaiteMessage(string strMessage)
        {
            lblMessage.Text = strMessage;
            lblMessage.Visible = true;
            lblMessage.Refresh();
        }

        /// <summary>
        /// 关闭等待条
        /// </summary>
        private void CloseWaiteMessage()
        {
            lblMessage.Visible = false;
            lblMessage.Text = "";
        }

        #endregion

        #region [ 事件: 窗体加载 ]

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDBSet_Load(object sender, EventArgs e)
        {
            //byte[] bstream ={ 63 };
            //KJ128A.DataSave.LogsHelper.Save_DBAccess(DateTime.Now, bstream, false, false);

            //隐藏“选择数据库面板”
            PanelState(true);
            WindowsCon(false);

            dt = ReadXmlToTable(strPath);
            drs = dt.Select("ID='" + dataIndex + "'");
            if (drs != null && drs.Length > 0)
            {
                DataRow dr = drs[0];
                strServerName = Crypt.Decrypt(dr[1].ToString()); //服务器名称
                cbbServername.Text = strServerName;
                data_source = Crypt.Decrypt(dr[5].ToString()); //数据库名称

                if (dr[2].ToString() == "Y") //是否Windows验证
                {
                    WindowsCon(true);
                }
                else
                {
                    WindowsCon(false);
                    user = Crypt.Decrypt(dr[3].ToString()); //登录名
                    loginBox.Text = user;
                    passID = Crypt.Decrypt(dr[4].ToString()); //密码
                    mimaBox.Text = passID;
                }

                ConSussesStatu(false); //不需要验证，直接可以点击下一步

                sqlCs.MyCon = sqlCs.connecting(loginModel_flag, strServerName, user, passID); //连接到数据库
            }
            else
            {
                cbbServername.Text = "(local)";
            }
        }

        #endregion

        #region [ 事件: 查找服务器名称 ]

        /// <summary>
        /// 查找服务器名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectSQLName_Click(object sender, EventArgs e)
        {
            OpenWaiteMessage("正在连接查找局域网内的服务器，请等待...");

            FrmSqlList frmSearch = new FrmSqlList(this, frmMain);
            frmSearch.ShowDialog();

            ConSussesStatu(true);
        }

        #endregion

        #region [ 事件: 采用Windows验证方式 ]

        /// <summary>
        /// 采用Windows验证方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void win_rb_CheckedChanged(object sender, EventArgs e)
        {
            WindowsCon(win_rb.Checked);
            ConSussesStatu(true);
        }

        #endregion

        #region [ 事件: 采用SQL验证方式 ]

        /// <summary>
        /// 采用SQL验证方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sql_rb_CheckedChanged(object sender, EventArgs e)
        {
            WindowsCon(win_rb.Checked);
            ConSussesStatu(true);

            txtDataBaseName.Clear();
        }

        #endregion

        #region [ 事件: 服务器名称改变 ]

        /// <summary>
        /// 服务器名称改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbServername_SelectedValueChanged(object sender, EventArgs e)
        {
            ConSussesStatu(true);
        }

        #endregion

        #region [ 事件: 重新输入用户名 ]

        /// <summary>
        /// 重新输入用户名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginBox_TextChanged(object sender, EventArgs e)
        {
            ConSussesStatu(true);
        }

        #endregion

        #region [ 事件: 重新输入密码 ]

        /// <summary>
        /// 重新输入密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mimaBox_TextChanged(object sender, EventArgs e)
        {
            ConSussesStatu(true);
        }

        #endregion

        #region [ 事件: 验证按钮 ]

        /// <summary>
        /// 验证数据库连接是否正确
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommit_Click(object sender, EventArgs e)
        {
            OpenWaiteMessage("正在验证, 这个过程可能将持续十几秒，请等待...");

            strServerName = cbbServername.Text;

            if (loginModel_flag)
            {
                sqlCs.MyCon = sqlCs.connecting(loginModel_flag, strServerName, "", ""); //连接到数据库
            }
            else
            {
                passID = mimaBox.Text;
                user = loginBox.Text;
                sqlCs.MyCon = sqlCs.connecting(loginModel_flag, strServerName, user, passID); //连接到数据库
            }

            try
            {
                sqlCs.MyCon.Open(); //打开数据库
            }
            catch (Exception ex)
            {
                ErrorMessage(3010010, ex.StackTrace, "[FrmDBSet:btnCommit_Click]", ex.Message);
            }
            finally
            {
                if (sqlCs.MyCon.State == ConnectionState.Open)
                {
                    ErrorMessage(8010010, string.Empty, "[FrmDBSet:btnCommit_Click]", strServerName + "  [ " + dataIndex.ToString() + " ] ");
                    ConSussesStatu(false);
                }
                else
                {
                    mimaBox.Focus();
                    ConSussesStatu(true);
                }
            }
            sqlCs.MyCon.Close();

            CloseWaiteMessage();
        }

        #endregion

        #region [ 事件: 下一步按钮 ]

        /// <summary>
        /// 下一步按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            strServerName = cbbServername.Text; //保存服务器名称
            PanelState(false); //显示“选择数据库”面板
            LoadDataBaseName(sqlCs.MyCon); //加载所选服务器的所有数据库
        }

        #endregion

        #region [ 方法: 加载服务器中的所有数据库名 ]

        /// <summary>
        /// 加载服务器中的所有数据库名
        /// </summary>
        /// <param name="odbconn"></param>
        private void LoadDataBaseName(OleDbConnection odbconn)
        {
            DataSet dsDBName = new DataSet();
            OleDbDataAdapter odbAdt = new OleDbDataAdapter("select name from master.dbo.sysdatabases", odbconn);

            try
            {
                odbAdt.Fill(dsDBName);
                foreach (DataRow dr in dsDBName.Tables[0].Rows)
                {
                    //读取数据库列表
                    ltbDataBaseName.Items.Add(dr[0].ToString());
                    if (drs != null && drs.Length > 0 && dr[0].ToString() == data_source)
                    {
                        ltbDataBaseName.SelectedItem = ltbDataBaseName.Items[ltbDataBaseName.Items.Count - 1];
                        txtDataBaseName.Text = data_source;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(3010011, ex.StackTrace, "[FrmDBSet:LoadDataBaseName]", ex.Message);
            }
            finally
            {
                if (odbconn.State == ConnectionState.Open)
                {
                    odbconn.Close();
                }
            }
        }

        #endregion

        #region [ 事件: 上一步按钮 ]

        /// <summary>
        /// 上一步按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>    
        private void btnprv_Click(object sender, EventArgs e)
        {
            PanelState(true);
            txtDataBaseName.Clear();
            ltbDataBaseName.Items.Clear();
        }

        #endregion

        #region [ 事件: 单击选中数据库名 ]

        /// <summary>
        /// 单击选中数据库名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>       
        private void ltbDataBaseName_Click(object sender, EventArgs e)
        {
            if (ltbDataBaseName.SelectedItems.Count > 0)
            {
                txtDataBaseName.Text = ltbDataBaseName.SelectedItem.ToString();
            }
        }

        #endregion

        #region [ 事件: 点击保存按钮 ]

        /// <summary>
        /// 点击保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDataBaseName.Text != "")
            {
                data_source = txtDataBaseName.Text;
                if (ISDBSame())
                {
                    //保存配置信息
                    SaveParam();
                    ErrorMessage(8010011, string.Empty, "[FrmDBSet:btnSave_Click]", strServerName + "  [ " + dataIndex.ToString() + " ] ");
                    Close();
                }
                else
                {
                    ErrorMessage(3010012, string.Empty, "[FrmDBSet:LoadDataBaseName]", string.Empty);
                }
            }
            else
            {
                MessageBox.Show("请选择数据库!");
                txtDataBaseName.Focus();
            }
        }

        #endregion

        #region [ 方法: 保存配置文件 ]

        /// <summary>
        /// 保存配置文件
        /// </summary>
        public void SaveParam()
        {
            DataRow dr;

            if (drs != null && drs.Length == 0)
            {
                dr = dt.NewRow(); //增加一个新行
            }
            else
            {
                dr = drs[0];
            }

            dr[0] = dataIndex.ToString();
            dr[1] = Crypt.Encrypt(strServerName);

            //验证方式
            if (loginModel_flag)
            {
                dr[2] = "Y";
            }
            else
            {
                dr[2] = "N";
            }

            dr[3] = Crypt.Encrypt(user);
            dr[4] = Crypt.Encrypt(passID);
            dr[5] = Crypt.Encrypt(data_source);

            if (drs != null && drs.Length == 0)
            {
                dt.Rows.Add(dr);
            }

            dt.AcceptChanges();

            dt.WriteXml(strPath); //把配置写入XML文件
        }

        #endregion

        /*
         * 验证服务器
         */

        /*
         * 选择数据库 
         */

        /*
         * 保存配置
         */

        /// <summary>
        /// 判断主备机的配置是否相同
        /// </summary>
        /// <returns></returns>
        private bool ISDBSame()
        {
            DataRow[] mydrs = dt.Select("ID<>'" + dataIndex + "'");
            if (mydrs.Length > 0)
            {
                DataRow dr = mydrs[0];
                if (dr[1].ToString() == Crypt.Encrypt(strServerName) && dr[5].ToString() == Crypt.Encrypt(data_source))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }
    }
}