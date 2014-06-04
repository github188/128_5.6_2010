using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;
using System.Windows.Forms;

namespace KJ128NDBTable
{
    public class HolidayManageBLL
    {
        HolidayManageDAL HMDAL = new HolidayManageDAL();
        public int HolidayManage_Insert(int intBlockID, string strEmployeeName, int intDeptID, string strBeginWorkDate, string strHolidayName, int intOperatorID, int classId,out string strErr)
        {
            return HMDAL.HolidayManage_Insert(intBlockID, strEmployeeName, intDeptID, strBeginWorkDate, strHolidayName, intOperatorID, classId, out strErr);
        }

        public int HolidayManage_Update(long intID, int intBlockID, string strEmployeeName, int intDeptID, string strBeginWorkDate, string strHolidayName, int intOperatorID,int classId, out string strErr)
        {
            return HMDAL.HolidayManage_Update(intID, intBlockID, strEmployeeName, intDeptID, strBeginWorkDate, strHolidayName, intOperatorID,classId, out strErr);
        }

        public int HolidayManage_Delete(long intID,string strTableName, out string strErr)
        {
            return HMDAL.HolidayManage_Delete(intID, strTableName, out strErr);
        }

        public DataSet HolidayManage_Query(int intPageIndex, int intPageSize, string strWhere, string strTableName, string strTableName2)
        {
            return HMDAL.HolidayManage_Query(intPageIndex,intPageSize,strWhere,strTableName,strTableName2);
        }


        #region 【方法：绑定标识卡信息】
        /// <summary>
        /// 绑定标识卡号信息
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="deptID"></param>
        public void CardInfoBindComboBox(ComboBox cmb,string deptID)
        {
            DataSet ds = null;
            try
            {
                ds = HMDAL.GetEmpInfo(deptID);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    DataRow dr = dt.NewRow();
                    dr["CodeSenderAddress"] = "所有";
                    dr["empName"] = "0";
                    dt.Rows.InsertAt(dr, 0);
                    dt.AcceptChanges();

                    cmb.DataSource = dt;
                    cmb.DisplayMember = "CodeSenderAddress";
                    cmb.ValueMember = "empName";
                }
                else
                {
                    cmb.Items.Add("所有");
                }
            }
            catch
            {
                cmb.Items.Add("所有");
            }
        }
        #endregion
    }
}
