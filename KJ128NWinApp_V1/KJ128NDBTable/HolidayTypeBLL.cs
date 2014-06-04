using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;
using System.Windows.Forms;
namespace KJ128NDBTable
{
    public class HolidayTypeBLL
    {
        HolidayTypeDAL HTDAL = new HolidayTypeDAL();

        #region 添加假别类型
        public int HolidayType_Insert(string strHolidayCode, string strHolidayName, string strHolidayAcronym, string remark, out string strErr)
        {
            return HTDAL.HolidayType_Insert(strHolidayCode, strHolidayName, strHolidayAcronym,remark,out strErr);
        }
        #endregion

        #region 更新假别类型
        public int HolidayType_Update(int intID, string strHolidayCode, string strHolidayName, string strHolidayAcronym,string remark, out string strErr)
        {
            return HTDAL.HolidayType_Update(intID, strHolidayCode, strHolidayName, strHolidayAcronym,remark, out strErr);
        }
        #endregion

        #region 删除假别类型
        public int HolidayType_Delete(int intID, out string strErr)
        {
            return HTDAL.HolidayType_Delete(intID, out strErr);
        }
        #endregion

        #region 查询假别类型
        public DataSet HolidayType_Query(string strWhere)
        {
            return HTDAL.HolidayType_Query(strWhere);
        }
        #endregion

        public void GetHolidayType(ComboBox cb)
        {
            DataSet ds = HolidayType_Query("");
            if (ds != null)
            {
                cb.DataSource = ds.Tables[0];
                cb.DisplayMember = "HolidayName";
                cb.ValueMember = "ID";
            }
        }

        public void GetHolidayTypeAddAll(ComboBox cb)
        {
            DataSet ds = HolidayType_Query("");
            if (ds != null)
            {
                DataRow dr=ds.Tables[0].NewRow();
                dr[0] = "0";
                dr[2] = "所有";
                ds.Tables[0].Rows.InsertAt(dr, 0);
               
                cb.DataSource = ds.Tables[0];
                
                cb.DisplayMember = "HolidayName";
                cb.ValueMember = "ID";
            }
        }
    }
}
