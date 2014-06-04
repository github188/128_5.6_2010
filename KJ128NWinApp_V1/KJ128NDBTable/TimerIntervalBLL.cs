using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KJ128NDataBase;
using System.Windows.Forms;
namespace KJ128NDBTable
{
    public class TimerIntervalBLL
    {

        #region [ 声明 ]

        TimerIntervalDAL TIDAL = new TimerIntervalDAL();

        #endregion

        /*
         * 方法
         */ 

        #region [ 方法: 添加时段信息 ]

        public int TimerInterval_Insert(string strIntervalName, string strNameShort, string strStartWorkTime, string strEndWorkTime, int intSWDateType, int intEWDateType, int intSWFrontTime, int intSWAfterTime, int intEWFrontTime, int intEWAfterTime, int intClassID,int intDataAttendanceType,out string strErr)
        {
            return TIDAL.TimerInterval_Insert(strIntervalName, strNameShort, strStartWorkTime, strEndWorkTime, intSWDateType, intEWDateType, intSWFrontTime, intSWAfterTime, intEWFrontTime, intEWAfterTime, intClassID,intDataAttendanceType, out strErr);
        }

        #endregion

        #region [ 方法: 更新时段信息 ]

        public int TimerInterval_Update(int intID, string strIntervalName, string strNameShort, string strStartWorkTime, string strEndWorkTime, int intSWDateType, int intEWDateType, int intSWFrontTime, int intSWAfterTime, int intEWFrontTime, int intEWAfterTime, int intClassID,int intDataAttendanceType,out string strErr)
        {
            return TIDAL.TimerInterval_Update(intID, strIntervalName, strNameShort, strStartWorkTime, strEndWorkTime, intSWDateType, intEWDateType, intSWFrontTime, intSWAfterTime, intEWFrontTime, intEWAfterTime, intClassID,intDataAttendanceType, out strErr);
        }

        #endregion

        #region [ 方法: 删除时段信息 ]

        public int TimerInterval_Delete(int intID, out string strErr)
        {
            return TIDAL.TimerInterval_Delete(intID, out strErr);
        }

        #endregion

        #region [ 方法: 查询时段信息 ]

        public DataSet TimerInterval_Query(string strWhere)
        {
            return TIDAL.TimerInterval_Query(strWhere);
        }

        #endregion

        /// <summary>
        /// 得到班次表数据信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTimeInterval(string strWhere)
        {
            DataTable dt = new DataTable();
            //dt.Columns.Add("ID", typeof(System.Int32));
            //dt.Columns.Add("ClassName", typeof(System.String));
            //dt.Columns.Add("IntervalName", typeof(System.String));
            //dt.Columns.Add("NameShort", typeof(System.String));
            
            
            
            //dt.Columns.Add("SWFrontTime", typeof(System.Int32));

            DataSet ds = TimerInterval_Query(strWhere);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                dt.Columns.Add("DataAttendanceTypeName", typeof(System.String));
                dt.Columns.Add("StartWorkTimeName", typeof(System.String));
                dt.Columns.Add("EndWorkTimeName", typeof(System.String));
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    switch (dr["DataAttendanceType"].ToString())
                    {
                        case "-1":
                            dr["DataAttendanceTypeName"] = "上一日";
                            break;
                        case "1":
                            dr["DataAttendanceTypeName"] = "下一日";
                            break;
                        default:
                            dr["DataAttendanceTypeName"] = "排班日";
                            break;
                    }
                    string strSwDataType = "";
                    DateTime dTimeStart;
                    switch (dr["SWDateType"].ToString())
                    {
                        case "-1":
                            strSwDataType = "上一日";
                            break;
                        case "1":
                            strSwDataType = "下一日";
                            break;
                        default:
                            strSwDataType = "排班日";
                            break;
                    }
                    dr["StartWorkTimeName"] = "错误时间";
                    try
                    {
                        dTimeStart = DateTime.Parse(dr["StartWorkTime"].ToString());
                        dr["StartWorkTimeName"] = strSwDataType + dTimeStart.Hour.ToString("00") + "时" + dTimeStart.Minute.ToString("00") + "分";
                    }
                    catch
                    { }

                    string strEWDataType = "";
                    DateTime dTimeEnd;
                    switch (dr["EWDateType"].ToString())
                    {
                        case "-1":
                            strEWDataType = "上一日";
                            break;
                        case "1":
                            strEWDataType = "下一日";
                            break;
                        default:
                            strEWDataType = "排班日";
                            break;
                    }
                    dr["EndWorkTimeName"] = "错误时间";
                    try
                    {
                        dTimeEnd = DateTime.Parse(dr["EndWorkTime"].ToString());
                        dr["EndWorkTimeName"] = strEWDataType + dTimeEnd.Hour.ToString("00") + "时" + dTimeEnd.Minute.ToString("00") + "分";
                    }
                    catch
                    { }
                }
            }
            dt.AcceptChanges();
            return dt;
        }

        #region 【方法：查询树时段信息】
        public DataTable TimeIntervalTree()
        {
            //获取班制表数据
            DataSet ds = TIDAL.TimerIntervalTree_Query();
            //构建树表结构
            DataTable dt = null;
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            else
            {
                dt = new DegonControlLib.TreeViewControl().BuildMenusEntity();
            }
            DataRow dr = dt.NewRow();
            setDataRow(ref dr, "0", "所有", "-1", false, false, 0);
            dt.Rows.Add(dr);
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

        #region [ 方法: 查询时用的时段下拉列表 ]

        public void BindComBoxAddAll(ComboBox CB)
        {
            DataSet ds = TimerInterval_Query("");

            if (ds != null)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["IntervalName"] = "所有";
                dr["ID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                CB.DataSource = ds.Tables[0];
                CB.DisplayMember = "IntervalName";
                CB.ValueMember = "ID";
            }
            else
            {
                CB.Items.Add("所有");
            }
        }

        public void BindComBoxAddAll(ComboBox CB,string strWhere)
        {
            DataSet ds =TimerInterval_Query(strWhere);

            if (ds != null)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["NameShort"] = "所有";
                dr["ID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                CB.DataSource = ds.Tables[0];
                CB.DisplayMember = "NameShort";
                CB.ValueMember = "ID";

                
            }
        }

        #endregion

        #region [ 方法: 添加/修改用的时段下拉列表 ]

        public void BindComBox(ComboBox CB, string strWhere)
        {
            DataSet ds = TimerInterval_Query(strWhere);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr["NameShort"] = "无";
                    dr["ID"] = "0";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                }
                CB.DataSource = ds.Tables[0];
                CB.DisplayMember = "NameShort";
                CB.ValueMember = "ID";


            }
        }

        #endregion

        #region[方法: Czlt-2010-09-21更新时段信息]

        public int UpdateSWAfterTimeBll(string strAfterTime, string strWhere)
        {
            return TIDAL.UpdateSWAfterTime(strAfterTime, strWhere);
        }
        #endregion

        #region【方法：Czlt-2011-12-10 修改时间】

        public void UpdateTime()
        {
            TIDAL.UpdateTime();
        }
        #endregion
    }
}
