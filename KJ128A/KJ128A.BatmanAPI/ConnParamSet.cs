using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Xml;

namespace KJ128A.BatmanAPI
{
    /// <summary>
    /// 配置信息的相关操作
    /// </summary>
    public class ConnParamSet
    {

        #region [ 声明: 创建数据库连接相关定义 ]
        /// <summary>
        /// 数据连接
        /// </summary>
        public OleDbConnection MyCon;       //定义连接

        #endregion

        #region [ 属性: 连接实例 ]

        /// <summary>
        /// 连接实例
        /// </summary>
        public OleDbConnection hanshu_MyCon
        {
            get
            {
                return MyCon;
            }
            set
            {
                MyCon = value;
            }
        }

        #endregion

        #region [方法:实现数据库的连接]

        /// <summary>
        /// 实现数据库的连接
        /// </summary>
        /// <param name="flag">flage==true时，采用windows验证方式；否则，采用用户名和密码登录</param>
        /// <param name="DataSource">服务器名称</param>
        /// <param name="strUserName">用户名</param>
        /// <param name="strPassWord">密码</param>
        /// <returns></returns>
        public OleDbConnection connecting(bool flag, string DataSource, string strUserName, string strPassWord)
        {
            string constr = String.Empty;               //定义连接字符串

            if (flag)
            {
                constr = " Provider = SQLOLEDB;Data Source =" + DataSource + ";Initial Catalog=NORTHWIND;Integrated Security=SSPI";
                MyCon = new OleDbConnection(constr);
            }
            else
            {
                constr = "Provider = SQLOLEDB;Data Source =" + DataSource + ";uid=" + strUserName + ";pwd=" + strPassWord + ";Initial Catalog=NORTHWIND";
                MyCon = new OleDbConnection(constr);
            }
            return MyCon;
        }

        #endregion

    }
}
