using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using KJ128A.BatmanAPI;
using KJ128A.Controls.Batman;
using KJ128NMainRun;

namespace KJ128A.Batman
{
    /// <summary>
    /// 登录窗体
    /// </summary>
    public partial class FrmLogin : Form
    {
        #region [ 声明: 委托 ] 错误消息事件

        #region Delegates

        /// <summary>
        /// 错误消息声明
        /// </summary>
        /// <param name="iErrNO">错误编号</param>
        /// <param name="strStackTrace">获取当前异常发生时调用堆栈上的帧的字符串表示形式</param>
        /// <param name="strSource">标识当前哪一段程序出的错误</param>
        /// <param name="strMessage">获取描述当前异常的消息</param>
        public delegate void ErrorMessageEventHandler(
            int iErrNO, string strStackTrace, string strSource, string strMessage);

        #endregion

        /// <summary>
        /// 错误消息事件
        /// </summary>
        public event ErrorMessageEventHandler ErrorMessage;

        #endregion

        private readonly IFrmMain frmMain = null;
        private readonly string strPath = "Login.xml";

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="frm">主窗体</param>
        /// <param name="strFilePath">文件保存路径</param>
        public FrmLogin(IFrmMain frm, string strFilePath)
        {
            InitializeComponent();

            strPath = System.Windows.Forms.Application.StartupPath.ToString() + @"\" + strFilePath;
            frmMain = frm;
        }

        #endregion

        #region [ 事件: 登录按钮 ]

        private void btnLoginIn_Click(object sender, EventArgs e)
        {
            // 判断是否输入了用户名和密码
            string strLoginName = txtLoginName.Text.Trim(); // 用户名
            string strPwd = txtPassword.Text.Trim(); // 密码

            if (strLoginName == "" || strPwd == "")
            {
                ErrorMessage(3010007, string.Empty, "[FrmLogin:btnLoginIn_Click]", string.Empty);
                return;
            }
            // 获取权限
            int iComp = Proving(Crypt.Encrypt(strLoginName), Crypt.MD5_16(strPwd));

            if (iComp != 0)
            {
                // 记录登录名
                frmMain.SetLoginInfo(strLoginName);

                EnumPowers enumComp = (EnumPowers) iComp;

                // 根据不同的权限，加载不同的菜单
                frmMain.MenuPowerChange(enumComp);

                // 提示登录成功
                ErrorMessage(8010020, string.Empty, "[FrmLogin:btnLoginIn_Click]", strLoginName);

                Close();
            }
        }

        #endregion

        #region [ 事件: 取消按钮 ]

        private void btnLoginOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region [ 方法: 验证用户名密码是否正确并获取权限 ]

        /// <summary>
        /// 验证用户名密码是否正确并获取权限
        /// </summary>
        /// <param name="strLoginName">用户名</param>
        /// <param name="strPwd">密码</param>
        /// <returns>用户权限</returns>
        public int Proving(string strLoginName, string strPwd)
        {
            int iComp = 0; // 权限默认为 0

            DataTable dtLogin = MainHelper.BuildLoginTable();

            if (File.Exists(strPath))
            {
                try
                {
                    dtLogin.ReadXml(strPath);

                    DataRow[] drs = dtLogin.Select(" Account = '" + strLoginName + "'");

                    if (drs.Length < 1)
                    {
                        // 提示用户名错误
                        ErrorMessage(3010008, string.Empty, "[FrmLogin:Proving]", Crypt.Decrypt(strLoginName));
                        return iComp;
                    }

                    for (int i = 0; i < drs.Length; i++)
                    {
                        if (drs[i][1].ToString().Equals(strPwd))
                        {
                            // 获取用户权限
                            iComp = int.Parse(drs[i][2].ToString());
                            return iComp;
                        }
                    }
                }
                catch
                {
                    // 文件格式不正确
                    ErrorMessage(3010005, string.Empty, "[FrmLogin:Proving]", strPath);
                    return iComp;
                }

                // 用户名和密码错误
                ErrorMessage(3010009, string.Empty, "[FrmLogin:Proving]", Crypt.Decrypt(strLoginName));
                return iComp;
            }
            else
            {
                // 没有Login.xml文件
                ErrorMessage(3010006, string.Empty, "[FrmLogin:Proving]", strPath);
                return iComp;
            }
        }

        #endregion

        private void FrmLogin_Load(object sender, EventArgs e)
        {


        }

        private void txtLoginName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
    }
}