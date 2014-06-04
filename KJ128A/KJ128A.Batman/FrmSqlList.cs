using System;
using System.Windows.Forms;
using KJ128A.BatmanAPI;

namespace KJ128A.Batman
{
    /// <summary>
    /// 选择服务器窗体
    /// </summary>
    public partial class FrmSqlList : Form
    {

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmSqlList(FrmDBSet frm, IFrmMain frmM)
        {
            InitializeComponent();
            frmDBSet = frm;        //父窗体
            frmMain = frmM;        //主窗体
        }

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

        #region [ 声明 : 窗体变量]

        private FrmDBSet frmDBSet = null;       //父窗体
        private IFrmMain frmMain = null;         //主窗体

        #endregion


        #region [ 事件: 窗体加载 ]

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSqlList_Load(object sender, EventArgs e)
        {
            SQLDMO.Application sqlApp = new SQLDMO.ApplicationClass(); //分布式管理对象

            try
            {
                SQLDMO.NameList serverList = sqlApp.ListAvailableSQLServers();//获取服务器名称列表

                if (serverList.Count > 0)
                {
                    for (int i = 1; i <= serverList.Count; i++)
                    {
                        ltbServer.Items.Add(serverList.Item(i));//绑定到ListBox
                    }
                }
                else
                {
                    ltbServer.Items.Add("(local)"); //如果没有活动的服务器，加载本机
                }

                ltbServer.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ErrorMessage(3010010, ex.StackTrace, "[FrmDBSet:LoadSqlList]", ex.Message);
               //3010010frmMain.ErrorMessage(ee.Message, true, false);
            }
            finally
            {
                sqlApp.Quit();
            }
        }

        #endregion 

        #region [ 事件: 取消按钮 ]

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmDBSet.UpdateServerName("", true);   //跳转到“开始”面板
            this.Close();
        }

        #endregion

        #region [ 事件: 点击确定按钮 ]

        /// <summary>
        /// 点击确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            ReturnServerName();
        }

        #endregion

        #region [ 事件: 选中服务器名称 ]

        /// <summary>
        /// 选中服务器名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ltbServer_DoubleClick(object sender, EventArgs e)
        {
            ReturnServerName();
        }

        #endregion


        #region [ 方法: 把服务器名称返回给调用界面 ]

        /// <summary>
        /// 把服务器名称返回给调用界面
        /// </summary>
        private void ReturnServerName()
        {
            frmDBSet.UpdateServerName(ltbServer.SelectedItem.ToString(), true);
            this.Close();
        }

        #endregion
    }
}