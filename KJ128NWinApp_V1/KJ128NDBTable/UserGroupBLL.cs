using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
namespace KJ128NDBTable
{
    public class UserGroupBLL
    {

        //UserGroupDAL dal = new UserGroupDAL();
        DataSet ds = new DataSet();
        private DBAcess dbacc = new DBAcess();
        UserGroupDAL DAL = new UserGroupDAL();
        DbHelperSQL DB = new DbHelperSQL();

        #region 绑定用户组ComboBox控件
        public void setCboUserGroup(ComboBox comUserName)
        {
            DAL.setCboUserGroup(comUserName, LoginBLL.user);
        }
        #endregion

        #region 绑定用户组权限ComboBox控件
        public void setCboUserGroupspower(ComboBox comUserName)
        {

            DAL.setCboUserGroupspower(comUserName, LoginBLL.user);
        }
        #endregion


        #region  根据用户组获取菜单

        /// <summary>
        /// 根据用户组获取菜单

        /// </summary>
        /// <param name="UserGroupID">用户组id</param>
        /// <returns>用户组的菜单项</returns>
        public DataSet selectUserGroups(int UserGroupID)
        {
            return DAL.selectUserGroups(UserGroupID);
        }
        #endregion

        #region 登陆用户菜单信息
        /// <summary>
        /// 登陆用户菜单信息
        /// </summary>
        /// <param name="account">用户名</param>
        /// <returns></returns>
        public DataSet selectUserGroups(string account)
        {
            return DAL.selectUserGroups(account);
        }

        #endregion

        #region 修改用户组菜单

        /// <summary>
        /// 修改用户组菜单

        /// </summary>
        /// <param name="UserGroupID">用户组id</param>
        /// <param name="name">菜单项</param>
        /// <param name="ISuse">是否可用</param>
        /// <returns>true 执行成功 false 失败</returns>
        public bool insertUserGroups(int UserGroupID, string name, bool ISuse)
        {
            return DAL.insertUserGroups(UserGroupID, name, ISuse);
        }
        #endregion


        #region 增加一条记录


        /// <summary>
        /// 增加一条记录

        /// </summary>
        public void Add(string UGName, bool IsEnable, bool IsUseEndDate, DateTime UseEndDate, string Remark, out string ErrMsgString)
        {
            DAL.Add(UGName, IsEnable, IsUseEndDate, UseEndDate, Remark, out ErrMsgString);
        }

        #endregion

        #region 更新一条记录


        /// <summary>
        ///  更新一条数据

        /// </summary>
        public void Update(int id, string UGName, bool IsEnable, bool IsUseEndDate, DateTime UseEndDate, string Remark, out string ErrMsgString)
        {
            DAL.Update(id, UGName, IsEnable, IsUseEndDate, UseEndDate, Remark, LoginBLL.user, out ErrMsgString);
        }

        #endregion

        #region 删除一条记录


        /// <summary>
        /// 删除一条数据

        /// </summary>
        public void DeleteByID(int id, out string ErrMsgString)
        {
            DAL.DeleteByID(id, LoginBLL.user, out ErrMsgString);

        }

        #endregion

        #region 得到所有的用户组


        public DataSet getallUserGroup()
        {
            return DAL.getallUserGroup();
        }
        #endregion


        #region 比较用户权限等级



        public bool isBigUserPowerID(int id)
        {
            return DAL.isBigUserPowerID(id, LoginBLL.user);
        }

        #endregion

        #region 用户组个数

        public bool getUserCount(string account)
        {
            return DAL.getUserCount(account);
        }
        #endregion
    }
}
