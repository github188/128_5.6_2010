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

        #region ���û���ComboBox�ؼ�
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
                        dr["UGname"] = "��";
                        dr["id"] = "0";
                        ds.Tables[0].Rows.InsertAt(dr, 0);
                    }
                }
            }
        }
        #endregion

        #region ���û���Ȩ��ComboBox�ؼ�
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
                        dr["UGPowername"] = "��";
                        dr["id"] = "0";
                        ds.Tables[0].Rows.InsertAt(dr, 0);
                    }
                }
                //comUserName.SelectedIndex = 0;
            }
        }
        #endregion


        #region  �����û����ȡ�˵�
        /// <summary>
        /// �����û����ȡ�˵�
        /// </summary>
        /// <param name="UserGroupID">�û���id</param>
        /// <returns>�û���Ĳ˵���</returns>
        public DataSet selectUserGroups(int UserGroupID)
        {
            SqlParameter[] para = { new SqlParameter("@UserGroupID", SqlDbType.Int) };
            para[0].Value = UserGroupID;
            return dbacc.ExecuteSqlDataSet("selectUserGrupByUserGroupID", para);
        }
        #endregion

        #region ��½�û��˵���Ϣ
        /// <summary>
        /// ��½�û��˵���Ϣ
        /// </summary>
        /// <param name="account">�û���</param>
        /// <returns></returns>
        public DataSet selectUserGroups(string account)
        {
            SqlParameter[] para = { new SqlParameter("@account", SqlDbType.VarChar, 20) };
            para[0].Value = account;
            return dbacc.ExecuteSqlDataSet("selectUserGrupByAccountID", para);
        }

        #endregion

        #region �޸��û���˵�
        /// <summary>
        /// �޸��û���˵�
        /// </summary>
        /// <param name="UserGroupID">�û���id</param>
        /// <param name="name">�˵���</param>
        /// <param name="ISuse">�Ƿ����</param>
        /// <returns>true ִ�гɹ� false ʧ��</returns>
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


        #region ����һ����¼

        /// <summary>
        /// ����һ����¼
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

        #region ����һ����¼

        /// <summary>
        ///  ����һ������
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
                ErrMsgString = "��ǰ�û������û���Ȩ�޵ȼ��������Ĳ����û��飬���ø���Ȩ�޵��û����в���";
            }
        }

        #endregion

        #region ɾ��һ����¼

        /// <summary>
        /// ɾ��һ������
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
                ErrMsgString = "��ǰ�û������û���Ȩ�޵ȼ��������Ĳ����û��飬���ø���Ȩ�޵��û����в���";
            }

        }

        #endregion

        #region �õ����е��û���

        public DataSet getallUserGroup()
        {
            return dbacc.GetDataSet("UserGroups_GetList");
        }
        #endregion


        #region �Ƚ��û�Ȩ�޵ȼ�



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

        #region �û������
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
