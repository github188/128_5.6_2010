using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KJ128NDataBase;
using System.Windows.Forms;

namespace KJ128NDBTable
{
    public class InfoClassBLL
    {

        #region [ 声明 ]

        InfoClassDAL ICDAL = new InfoClassDAL();

        #endregion

        #region [ 方法: 添加班制信息 ]

        public int InfoClass_Insert(string strClassName, string strShortName, string strRemark, out string strErr)
        {
            return ICDAL.InfoClass_Insert(strClassName, strShortName, strRemark, out strErr);
        }

        #endregion

        #region [ 方法: 更新班制信息 ]

        public int InfoClass_Update(int intID, string strClassName, string strShortName, string strRemark, out string strErr)
        {
            return ICDAL.InfoClass_Update(intID, strClassName, strShortName, strRemark, out strErr);
        }

        #endregion

        #region [ 方法: 删除班制信息 ]

        public int InfoClass_Delete(int intID, out string strErr)
        {
            return ICDAL.InfoClass_Delete(intID, out strErr);
        }

        #endregion

        #region [ 方法: 查询班制信息 ]

        public DataSet InfoClass_Query(string strWhere)
        {
            return ICDAL.InfoClass_Query(strWhere);
        }

        #endregion

        #region 【方法：构建在TreeView中显示的班制表信息】
        /// <summary>
        /// 获取在TreeView中显示的班制表
        /// </summary>
        public DataTable getClassInfoTreeViewTable()
        {
            //获取班制表数据
            DataSet ds = InfoClass_Query("");
            //构建树表结构
            DataTable dt = new DegonControlLib.TreeViewControl().BuildMenusEntity();

            DataRow dr = dt.NewRow();
            setDataRow(ref dr, "0", "所有", "-1", false, false, 0);
            dt.Rows.Add(dr);
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    dr = dt.NewRow();
                    setDataRow(ref dr, dr1["ID"].ToString(), dr1["ClassName"].ToString(), "0", true, false, 0);
                    dt.Rows.Add(dr);
                }
            }
            dt.AcceptChanges();
            return dt;
        }

        private void setDataRow(ref DataRow dr, string id, string name, string parentid, bool isChild, bool isUserNum, int num)
        {
            dr[0] = id;
            dr[1] = name;
            dr[2] = parentid;
            dr[3] = isChild;
            dr[4] = isUserNum;
            dr[5] = num;
        }
        #endregion

        #region [ 方法: 绑定组合列表框的函数 ]

        public void InfoClass_BindComboBox(ComboBox CB)
        {
            DataSet ds = InfoClass_Query("");
            if (ds != null)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["ClassName"] = "所有";
                dr["ID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                ds.AcceptChanges();

                CB.DataSource = ds.Tables[0];
                CB.DisplayMember = "ClassName";
                CB.ValueMember = "ID";                
            }
        }

        #endregion

        #region [ 方法: 绑定组合列表_班制信息]

        public void BindComboBoxAddEmpty(ComboBox CB)
        {
            DataSet ds = InfoClass_Query("");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr["ClassName"] = "所有";
                    dr["ID"] = "0";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                }

                CB.DataSource = ds.Tables[0];
                CB.DisplayMember = "ClassName";
                CB.ValueMember = "ID";
            }
        }

        #endregion
    }
}
