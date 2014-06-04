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
    /// 密码修改窗体
    /// </summary>
    public partial class FrmChangePwd : Form
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

        #region [ 声明 ]

        private readonly IFrmMain frmMain = null;
        private readonly string strPath = "Login.xml";

        #endregion

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="frm">窗体对象</param>
        /// <param name="strFilePath">文件保存路径</param>
        public FrmChangePwd(IFrmMain frm, string strFilePath)
        {
            InitializeComponent();
            frmMain = frm;
            strPath = System.Windows.Forms.Application.StartupPath.ToString() + @"\" + strFilePath;

            lblLoginName.Text = "当前用户的帐号为: " + frmMain.GetLoginInfo();
            lblLoginName.Left = (this.Width - lblLoginName.Width) / 2;
        }

        #endregion

        #region [ 事件: 修改密码 ]

        private void btnUpdatePwd_Click(object sender, EventArgs e)
        {
            string strLoginName = frmMain.GetLoginInfo();

            // 首先判断填写是否完整
            if (txtOldPwd.Text == "" || txtNewPwd.Text == "" || txtAccPwd.Text == "")
            {
                ErrorMessage(3010001, string.Empty, "FrmChangePwd:btnUpdatePwd_Click", string.Empty);
                return;
            }

            // 判断输入的新密码和验证密码是否相同
            if (!txtAccPwd.Text.Equals(txtNewPwd.Text))
            {
                ErrorMessage(3010002, string.Empty, "FrmChangePwd:btnUpdatePwd_Click", string.Empty);
                return;
            }

            // 判断原始密码是否正确并修改XML中的密码
            if (UpdatePwd(Crypt.Encrypt(strLoginName), Crypt.MD5_16(txtOldPwd.Text),
                          Crypt.MD5_16(txtNewPwd.Text)))
            {
                Close();
            }
        }

        #endregion

        #region [ 事件: 取消按钮 ]

        private void btnCanal_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region [ 方法: 修改密码 ]

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="strLoginName">用户名</param>
        /// <param name="strPwd">密码</param>
        /// <param name="strNewPwd">要修改的密码</param>
        /// <returns>是否修改成功</returns>
        public bool UpdatePwd(string strLoginName, string strPwd, string strNewPwd)
        {
            DataTable dtLogin = MainHelper.BuildLoginTable();

            if (File.Exists(strPath))
            {
                try
                {
                    dtLogin.ReadXml(strPath);
                    DataRow[] drs = dtLogin.Select(" Account = '" + strLoginName + "' and Password ='" + strPwd + "'");

                    if (drs.Length < 1)
                    {
                        // 提示输入的密码有误
                        ErrorMessage(3010003, string.Empty, "[FrmChangePwd:UpdatePwd]]", frmMain.GetLoginInfo());
                        return false;
                    }

                    for (int i = 0; i < drs.Length; i++)
                    {
                        // 修改用户密码
                        drs[i][1] = strNewPwd;
                        dtLogin.WriteXml(strPath);

                        // 提示修改成功
                        ErrorMessage(3010004, string.Empty, "[FrmChangePwd:UpdatePwd]", frmMain.GetLoginInfo());
                    }
                    return true;
                }
                catch
                {
                    // 提示XML文件格式错误
                    ErrorMessage(3010005, string.Empty, "[FrmChangePwd:UpdatePwd]", strPath);
                    return false;
                }
            }
            else
            {
                // 提示没有该XML文件
                ErrorMessage(3010006, string.Empty, "[FrmChangePwd:UpdatePwd]", strPath);
                return false;
            }
        }

        #endregion

        private void txtOldPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtNewPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtAccPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
    }
}