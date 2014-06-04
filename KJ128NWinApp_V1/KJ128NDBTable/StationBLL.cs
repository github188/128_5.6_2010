using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KJ128NDataBase;
using KJ128WindowsLibrary;
using System.Windows.Forms;
using System.Drawing;

namespace KJ128NDBTable
{
    public class StationBLL
    {

        #region [ 声明 ]

        private StationDAL sdal = new StationDAL();
        private EnumInfoDAL eidal = new EnumInfoDAL();
        private RealTimeDAL rtdal = new RealTimeDAL();

        #endregion


        #region [ 方法: 判断是否是数字 ]

        /// <summary>
        ///  判断是否是数字
        /// </summary>
        /// <param name="str">字符转</param>
        /// <returns>是否是数字</returns>
        public bool IsNumeric(string str)
        {
            if (str == null || str.Length == 0)
                return false;
            foreach (char c in str)
            {
                if (!Char.IsNumber(c))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region [ 方法: 判断是否是电话 ]

        /// <summary>
        ///  
        /// </summary>
        /// <param name="str">字符转</param>
        /// <returns></returns>
        public bool IsTel(string str)
        {
            if (str == null || str.Length == 0)
                return false;
            foreach (char c in str)
            {
                if (!Char.IsNumber(c))
                {
                    if (c != '-')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion

        #region [ 方法: 分站信息管理 ]

        #region 添加分站地址号

        public void addSatationAddress(int min, int max, string place, string tel, int typeId, string typeName, int group, bool enabledBatch, out string result)
        {
            if (min == 0) { result = HardwareName.Value(CorpsName.StationAddress)+"不能为0"; return; }
            string stationArr = string.Empty;
            //判断是否是批量添加
            if (enabledBatch)
            {
                if (max <= min) { result = HardwareName.Value(CorpsName.StationAddress)+"范围应从小到大 例:1-10"; return; }
                // 组织分站地址列表
                if (max - min > 100) { result = "分站批量添加一次最多100个分站"; return; };
                for (int i = min; i <= max; i++)
                {
                    if (i < max)
                        stationArr += i.ToString() + ",";
                    else
                        stationArr += i.ToString();
                }

                // 获得
                DataTable dt = sdal.getExistsStationAddress(stationArr);
                //添加
                int resultInt = sdal.insertStationAddress(stationArr, place, tel, typeId, typeName, group);

                // 添加成功后 得到重复的分站地址
                StringBuilder tempString = new StringBuilder();
                if (dt.Rows.Count == max)
                {
                    result = HardwareName.Value(CorpsName.StationAddress)+ "全部存在";
                }
                else if (dt.Rows.Count > 0 && dt.Rows.Count < max)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        tempString.Append(dr["col"].ToString() + ",");
                    }
                    tempString = tempString.Remove(tempString.Length - 1, 1);
                    result = tempString.Append(" 号已经存在,其他已添加成功").ToString();
                }
                else if (resultInt == -1)
                {
                    result = "添加失败";
                }
                else
                {
                    result = "添加成功";
                }
                return;
            }
            else
            {
                //判断分站地址号是否存在
                if (sdal.existsStationAddress(min) >= 1)
                {
                    result = HardwareName.Value(CorpsName.StationAddress)+":" + min.ToString() + "已经存在,请重新添加";
                    return;
                }
                else
                {
                    stationArr = min.ToString();
                    //添加
                    if (sdal.insertStationAddress(stationArr, place, tel, typeId, typeName, group) >= 1)
                    {
                        result = "添加成功";
                        return;
                    }
                    else
                    {
                        result = "添加失败";
                        return;
                    }
                }
            }
        }

        #endregion

        #region 获得分站类型Table

        public DataTable getStationTypeTab()
        {
            return eidal.getEnumInfo(1);
        }

        #endregion

        #region 接收地址号获得分站信息return DataRow

        public DataRow getStationInfo(int stationAddress)
        {
            return sdal.getStationInfo(stationAddress);
        }

        #endregion

        #region 添加接收器 return int

        public int insertStationHead(int stationAddress, int shAddress, string shPlace, string shTel, int shTypeId, string shType, string antennaA, string antennaB, string remark)
        {
            return sdal.insertStationHead(stationAddress, shAddress, shPlace, shTel, shTypeId, shType, 0, 0, 1, antennaA, antennaB, remark);
        }

        #endregion

        #region 查看接收器地址号是否已存在 return int

        public int existsStationHeadAddress(int addressHead, int address)
        {
            return sdal.existsStationHeadAddress(addressHead, address);
        }

        #endregion

        #region 分站和接收器号

        public DataSet getStationHeadInfo(int pageIndex, int pageSize)
        {
            return sdal.getStationHeadInfo(pageIndex, pageSize);
        }

        #endregion

        #region 获得指定分站的接收器

        public DataTable getStationHeadInfoAll(int stationAddress)
        {
            return sdal.getStationHeadInfoAll(stationAddress);
        }

        #endregion

        #region 删除接收器

        public int deleteStationHead(int id)
        {
            return sdal.deletdStationHead(id);
        }

        #endregion

        #region 修改分站信息

        public int updateStation(int sAddress, string place, string tel, int typeId, string typeName, int group)
        {
            return sdal.updateStation(sAddress, place, tel, typeId, typeName, group);
        }

        #endregion

        #region 获得该接收器信息 return DataRow

        public DataRow getStationHeadRowInfo(int id)
        {
            return sdal.getStationHeadRowInfo(id);
        }

        #endregion

        #region 修改接收器信息

        public int updateStationHead(int headId, string shPlace, string shTel, int shTypeId, string shType, string antennaA, string antennaB, string remark)
        {
            return sdal.updateStationHead(headId, shPlace, shTel, shTypeId, shType, antennaA, antennaB, remark);
        }

        #endregion

        #region 删除分站信息

        public int deleteStation(int stationAddress)
        {
            //sdal.deleteStationHeads(stationAddress);//删除该分站的所有接收器
            return sdal.deleteStation(stationAddress);
        }

        #endregion

        #endregion

        #region [ 方法: 分站信息显示 ]

        #region 获取分站实时信息
        /// <summary>
        /// 分站信息
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="sumType">显示类型 0人员 1设备 2卡</param>
        /// <returns></returns>
        public DataSet GetRTStationInfo(int pageIndex, int pageSize, int sumType)
        {
            SqlParameter[] para = {new SqlParameter("@pageIndex",SqlDbType.Int),
                                new SqlParameter("@pageSize",SqlDbType.Int),
                                new SqlParameter("@sumType",SqlDbType.Int)
            };
            para[0].Value = pageIndex;
            para[1].Value = pageSize;
            para[2].Value = sumType;
            return sdal.GetRTStationInfo(para);
        }

        /// <summary>
        /// 分站接收器信息
        /// </summary>
        /// <param name="addressList">分站列表(1,2,3)</param>
        /// <returns>StationAddress,StationHeadAddress,InStationHeadAntenna,SumCard</returns>
        public DataSet GetRTStationHeadInfo(string addressList, int sumType)
        {
            SqlParameter[] para = {new SqlParameter("@addressList",SqlDbType.VarChar,2000),
                                new SqlParameter("@sumType",SqlDbType.Int)
            };
            para[0].Value = addressList;
            para[1].Value = sumType;
            return sdal.GetRTStationHeadInfo(para);
        }

        /// <summary>
        /// 分站接收器信息
        /// </summary>
        /// <param name="pageIndex">页码索引</param>
        /// <param name="pageSize">每页尺度</param>
        /// <param name="sumType">统计类型</param>
        /// <returns>返回实时显示接收器信息</returns>
        public DataSet GetRTDisplayStationHeadInfo(int pageIndex, int pageSize, int sumType)
        {
            SqlParameter[] para = {new SqlParameter("@pageIndex",SqlDbType.Int),
                                new SqlParameter("@pageSize",SqlDbType.Int),
                                new SqlParameter("@sumType",SqlDbType.Int)
            };
            para[0].Value = pageIndex;
            para[1].Value = pageSize;
            para[2].Value = sumType;
            return sdal.GetRTDisplayStationHeadInfo(para);
        }
        #endregion

        #region 部门信息

        public DataSet GetRTDeptSmallInfo(int displayType)
        {
            SqlParameter[] para = { new SqlParameter("@displayType", SqlDbType.Int) };
            para[0].Value = displayType;
            return sdal.GetRTDeptSmallInfo(para);
        }

        #endregion

        #endregion

        #region 接收器方向性添加及判断是否存在

        public int addDirectionalAntenna(string detectionInfo, string directional)
        {
            return sdal.addDirectionalAntenna(detectionInfo, directional);
        }

        #endregion

        #region 接收器方向性修改

        public int upDateDirectionalAntenna(int CodeSenderDirlID, string Directional)
        {
            return sdal.upDateDirectionalAntenna(CodeSenderDirlID, Directional);
        }

        #endregion

        #region 接收器方向性删除

        public int removeDirectionalAntenna(int CodeSenderDirlID)
        {
            return sdal.removeDirectionalAntenna(CodeSenderDirlID);
        }

        #endregion

        #region [ 方法: 方向性管理 ]

        #region FrmDirectional获得分站和接收器数据

        public DataSet GetStationAndHead()
        {
            return sdal.GetStationAndHead();
        }

        #endregion

        #region 判断方向性是否存在

        public int existsDirectional(string dStr)
        {
            return sdal.existsDirectional(dStr);
        }

        #endregion

        #region 方向性添加及判断是否存在

        public int addDirectional(string detectionInfo, string directional)
        {
            return sdal.addDirectional(detectionInfo, directional);
        }

        #endregion

        #region 获得配置的方向性

        public DataSet getAllDirectional(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@keyField",SqlDbType.VarChar,255),
                                    new SqlParameter("@fieldList",SqlDbType.VarChar,2000),
                                    new SqlParameter("@orderField",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,8000),
                                    new SqlParameter("@orderType",SqlDbType.Bit)
            };
            para[0].Value = "View_GetAllDirectional";
            para[1].Value = "DetectionInfo";
            para[2].Value = "CodeSenderDirlID as 索引号,DetectionInfo as 标识,DetectionPlace as 位置,Directional as 方向性描述";//
            para[3].Value = "DetectionInfo";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            para[6].Value = where;
            para[7].Value = 0;

            return rtdal.getRTDeptInfo(para);
        }

        #endregion

        #region 获得配置的方向性

        public DataSet getAllDirectionalAntenna(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@keyField",SqlDbType.VarChar,255),
                                    new SqlParameter("@fieldList",SqlDbType.VarChar,2000),
                                    new SqlParameter("@orderField",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,8000),
                                    new SqlParameter("@orderType",SqlDbType.Bit)
            };
            para[0].Value = "View_GetAllDirectionalAntenna";
            para[1].Value = "DetectionInfo";
            para[2].Value = "CodeSenderDirlID as 索引号,DetectionInfo as 标识,DetectionPlace as 位置,Directional as 方向性描述";//
            para[3].Value = "DetectionInfo";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            para[6].Value = where;
            para[7].Value = 0;

            return rtdal.getRTDeptInfo(para);
        }

        #endregion

        #region 方向性删除

        public int removeDirectional(int CodeSenderDirlID)
        {
            return sdal.removeDirectional(CodeSenderDirlID);
        }

        #endregion

        #region 方向性修改

        public int upDateDirectional(int CodeSenderDirlID, string Directional)
        {
            return sdal.upDateDirectional(CodeSenderDirlID, Directional);
        }

        #endregion

        #endregion

        #region [ 方法: 得到出井分站信息 ]
        public void GetOutWellStationInfo(ComboBox CB)
        {
            string strErr = string.Empty;
            DataSet ds = sdal.GetOutWellStationInfo(out strErr);

            CB.Items.Clear();
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = "0";
                dr[1] = "无";
                ds.Tables[0].Rows.InsertAt(dr, 0);
            }

            CB.DataSource = ds.Tables[0];
            CB.DisplayMember = "StationHeadPlace";
            CB.ValueMember = "StationAddressAndStationHeadAddress";

        }
        #endregion

    }
}
