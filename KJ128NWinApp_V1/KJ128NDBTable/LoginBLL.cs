using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

using KJ128NDataBase;
using System.Windows.Forms;
using System.Net;

namespace KJ128NDBTable
{
    public class LoginBLL
    {
        #region [ 桃源 ]

        private DBAcess dbacc = new DBAcess();
        private DataSet ds;
        private string strSql = string.Empty;
        public static string user = "guest";
        public static string pwd = string.Empty;
        LoginDAL dal = new LoginDAL();
        #region 登录
        public bool SearchLoginInfo(string strAccount, string strPassword, out string strErr)
        {

            if (strAccount == "guest")
            {
                strErr = "登陆成功!";
                return true;
            }

            string result = dal.Login(strAccount, strPassword, "", out strErr);
            if (strErr == "Succeeds" && result == "")
            {
                strErr = "登陆成功!";
                user = strAccount;
                return true;
            }
            else
            {
                strErr = result;
                return false;
            }


        }

        /// <summary>
        /// int转换Ip
        /// </summary>
        /// <param name="intConverIp"></param>
        /// <returns></returns>
        public int IntConversionIp()
        {
            string cc = Dns.GetHostName();                             //得到字符串型的主机名称   
            IPHostEntry myHost = Dns.GetHostEntry(cc);
            string ip = myHost.AddressList[0].ToString();
            string[] str = new string[3];
            str = ip.Split('.');
            int intConverIp = int.Parse(str[0]) * (256 * 256 * 256) + int.Parse(str[1]) * (256 * 256) + int.Parse(str[2]) * 256 +
                              int.Parse(str[3]) * 1;

            return intConverIp;
        }
        #endregion

        #region 用户
        public void getUsername(ComboBox comUserName)
        {
            strSql = " Select Account  From Admins ";
            ds = null;
            using (ds = new DataSet())
            {
                ds = dbacc.GetDataSet(strSql);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    comUserName.DataSource = ds.Tables[0];
                    comUserName.DisplayMember = "Account";
                }
            }
        }

        #endregion

        #endregion

        #region [ 方法: 根据用户获得菜单 ]

        public DataTable GetUserMenu(string strAccount)
        {
            DataSet ds = dal.GetUserMenu(strAccount);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        #endregion

        #region
        /*
        #region [ 声明 ]

        private DataSet ds;

        private LoginDAL ldal = new LoginDAL();

        #endregion

        #region [ 方法: 登录 ]

        public bool SearchLoginInfo(string strUserName,string strPassWord,out string strErr)
        {

            using (ds = new DataSet())
            {
                ds = ldal.GetLoginInfo(strUserName);

                if (ds == null)
                {
                    strErr = "登录失败";
                    return false;
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == strPassWord)
                    {
                        strErr = "";
                        return true;
                    }
                    else
                    {
                        strErr = "密码错误！";
                        return false;
                    }
                }
                else
                {
                    strErr = "用户名不存！";
                    return false;
                }
            }
        }
        #endregion
        */
        #endregion
    }
}
