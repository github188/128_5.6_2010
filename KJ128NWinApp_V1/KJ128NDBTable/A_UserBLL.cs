using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDBTable
{
    public class A_UserBLL
    {
        KJ128NDataBase.A_UserDAL dal = new KJ128NDataBase.A_UserDAL();

        public DataTable GetUserGroups()
        {
            return dal.GetUserGroups();
        }

        public DataTable GetUserByUG(string usergroupid)
        {
            return dal.GetUserByUG(usergroupid);
        }

        public DataTable GetAdmins(string ugid)
        {
            return dal.GetAdmins(ugid);
        }

        public bool isExitsUserName(string username)
        {
            return dal.isExitsUserName(username);
        }

        public int insertAdmin(string strAccount, string password, string passwordback, bool isEnable, bool isUserEndDate, DateTime UseEndDate, int userGroupID, int CreateID, int CreateIP, string Remark, out string err)
        {
            return dal.insertAdmin(strAccount, password, passwordback, isEnable, isUserEndDate, UseEndDate, userGroupID, CreateID, CreateIP, Remark, out err);
        }

        public void DelUserByUserName(string username)
        {
            dal.DelUserByUserName(username);
        }

        public bool UpdateUserByUserName(string username, string gu, string isenable, string remark,string Password)
        {
            return dal.UpdateUserByUserName(username, gu, isenable, remark,Password);
        }

        public bool InsertUserGroup(string ugname)
        {
            return dal.InsertUserGroup(ugname);
        }

        public string GetUGidByName(string ugname)
        {
            return dal.GetUGidByName(ugname);
        }

        public string GetMenuPidByMenuName(string name)
        {
            return dal.GetMenuPidByMenuName(name);
        }

        public bool InsertMenu(string pid, string title, string name)
        {
            return dal.InsertMenu(pid, title, name);
        }

        public void DelMenuByUGid(string ugid)
        {
            dal.DelMenuByUGid(ugid);
        }

        public void InsertUGmenu(string ugid, string menuid, bool isuse, string remark)
        {
            if (isuse)
            {
                dal.InsertUGmenu(ugid, menuid, 1, remark);
            }
            else
            {
                dal.InsertUGmenu(ugid, menuid, 0, remark);
            }
        }

        public bool IsMenuSaved()
        {
            return dal.IsMenuSaved();
        }

        public bool DelUserGroupByID(string ugid)
        {
            return dal.DelUserGroupByID(ugid);
        }

        public bool GetUGMenuPower(string menuname, string ugid)
        {
            string result = dal.GetUGMenuPower(menuname, ugid);
            if (result == "True")
                return true;
            else
                return false;
        }

        public string GetPassWordByUserName(string username)
        {
            return dal.GetPassWordByUserName(username);
        }

        #region【方法：Czlt-2011-12-10 修改时间】

        public void UpdateTime()
        {
            dal.UpdateTime();
        }
        #endregion
    }
}
