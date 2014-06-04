using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;
namespace KJ128NDataBase
{
    public class UserGroupDAL
    {
        DataSet ds = new DataSet();
        private DBAcess dbacc = new DBAcess();

        DbHelperSQL DB = new DbHelperSQL();

        #region 绑定用户组ComboBox控件
        public void setCboUserGroup(ComboBox comUserName, string user)
        {
            string strSql = "Select UGname,id  From UserGroups";
            //if (user == "3shine")
            //{
            //    strSql = " Select UGname,id  From UserGroups ";
            //}
            //else
            //{
            //    strSql = " getUserGroupsByAccount " + user;
            //}
            using (ds = new DataSet())
            {
                ds = dbacc.GetDataSet(strSql);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        comUserName.DataSource = ds.Tables[0].DefaultView;
                        comUserName.DisplayMember = "UGname";
                        comUserName.ValueMember = "id";
                        comUserName.SelectedIndex = 0;
                    }
                    else
                    {
                        DataRow dr = ds.Tables[0].NewRow();
                        dr["UGname"] = "无";
                        dr["id"] = "0";
                        ds.Tables[0].Rows.InsertAt(dr, 0);
                    }
                }
            }
        }
        #endregion

        #region 绑定用户组权限ComboBox控件
        public void setCboUserGroupspower(ComboBox comUserName, string user)
        {

            string strSql = "";
            if (user == "3shine")
            {
                strSql = " Select UGPowername,id  From UserGroupPower ";
            }
            else
            {
                strSql = " getUserGroupsPowerByAccount " + user;
            }
            using (ds = new DataSet())
            {
                ds = dbacc.GetDataSet(strSql);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        comUserName.DataSource = ds.Tables[0].DefaultView;
                        comUserName.DisplayMember = "UGPowername";
                        comUserName.ValueMember = "id";
                    }
                    else
                    {
                        DataRow dr = ds.Tables[0].NewRow();
                        dr["UGPowername"] = "无";
                        dr["id"] = "0";
                        ds.Tables[0].Rows.InsertAt(dr, 0);
                    }
                }
                //comUserName.SelectedIndex = 0;
            }
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
            SqlParameter[] para = { new SqlParameter("@UserGroupID", SqlDbType.Int) };
            para[0].Value = UserGroupID;
            return dbacc.ExecuteSqlDataSet("selectUserGrupByUserGroupID", para);
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
            SqlParameter[] para = { new SqlParameter("@account", SqlDbType.VarChar, 20) };
            para[0].Value = account;
            return dbacc.ExecuteSqlDataSet("selectUserGrupByAccountID", para);
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
            SqlParameter[] para = {new SqlParameter("@name",SqlDbType.VarChar ,50),
                                new SqlParameter("@UserGroupID",SqlDbType.Int),
                                  new SqlParameter("@ISuse",SqlDbType.Bit ),
            };
            para[0].Value = name;
            para[1].Value = UserGroupID;
            para[2].Value = ISuse;
            return (dbacc.ExecuteSql("insertUserGroupMenu1", para) == -1) ? false : true;
        }
        #endregion


        #region 增加一条记录

        /// <summary>
        /// 增加一条记录
        /// </summary>
        public void Add(string UGName, bool IsEnable, bool IsUseEndDate, DateTime UseEndDate, string Remark, out string ErrMsgString)
        {
            SqlParameter[] parameters = {
					
					new SqlParameter("@UGName", SqlDbType.VarChar,20),
					new SqlParameter("@IsEnable", SqlDbType.Bit,1),
					new SqlParameter("@IsUseEndDate", SqlDbType.Bit,1),
					new SqlParameter("@UseEndDate", SqlDbType.DateTime,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
			};

            parameters[0].Value = UGName;
            parameters[1].Value = IsEnable;
            parameters[2].Value = IsUseEndDate;
            parameters[3].Value = UseEndDate;
            parameters[4].Value = Remark;

            DB.RunProcedureByInt("Shine_UserGroups_Add1", parameters, out ErrMsgString);
        }

        #endregion

        #region 更新一条记录

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(int id, string UGName, bool IsEnable, bool IsUseEndDate, DateTime UseEndDate, string Remark, string user, out string ErrMsgString)
        {
            if (isBigUserPowerID(id, user))
            {
                SqlParameter[] parameters = {
				new SqlParameter("@ID", SqlDbType.Int,4),
				new SqlParameter("@UGName", SqlDbType.VarChar,20),
				new SqlParameter("@IsEnable", SqlDbType.Bit,1),
				new SqlParameter("@IsUseEndDate", SqlDbType.Bit,1),
				new SqlParameter("@UseEndDate", SqlDbType.DateTime,4),
				new SqlParameter("@Remark", SqlDbType.VarChar,200),
			};
                parameters[0].Value = id;
                parameters[1].Value = UGName;
                parameters[2].Value = IsEnable;
                parameters[3].Value = IsUseEndDate;
                parameters[4].Value = UseEndDate;
                parameters[5].Value = Remark;

                DB.RunProcedureByInt("Shine_UserGroups_Update", parameters, out ErrMsgString);
            }
            else
            {
                ErrMsgString = "当前用户所在用户组权限等级低于所的操作用户组，请用更高权限的用户进行操作";
            }
        }

        #endregion

        #region 删除一条记录

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteByID(int id, string user, out string ErrMsgString)
        {
            if (isBigUserPowerID(id, user))
            {
                SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int, 4)
				};
                parameters[0].Value = id;
                DB.RunProcedureByInt("Shine_UserGroups_ID_Delete", parameters, out ErrMsgString);
            }
            else
            {
                ErrMsgString = "当前用户所在用户组权限等级低于所的操作用户组，请用更高权限的用户进行操作";
            }

        }

        #endregion

        #region 得到所有的用户组

        public DataSet getallUserGroup()
        {
            return dbacc.GetDataSet("UserGroups_GetList");
        }
        #endregion


        #region 比较用户权限等级



        public bool isBigUserPowerID(int id, string user)
        {
            //string err;
            //SqlParameter[] parameters = new SqlParameter[] {   new SqlParameter("@Account", SqlDbType.NVarChar ,50)
            //,new SqlParameter("@ID", SqlDbType.Int, 4)
            //};
            //if (user == "3shine") return true;
            //parameters[0].Value = user;
            //parameters[1].Value = id;
            //DataSet ds = DB.RunProcedureByDataSet("Shine_UserGroup_GetUGPLevelID", "ds", parameters, out err);
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    return int.Parse(ds.Tables[0].Rows[0][0].ToString()) == 1;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }

        #endregion

        #region 用户组个数
        public bool getUserCount(string account)
        {
            DataSet ds = dbacc.GetDataSet("select id  from userGroups where UGName = '" + account + "'");
            if (ds != null & ds.Tables.Count > 0)
            {
                return ds.Tables[0].Rows.Count > 0;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
