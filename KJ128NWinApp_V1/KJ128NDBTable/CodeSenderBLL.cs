using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KJ128NDBTable
{
    public class CodeSenderBLL
    {
        private CodeSenderDAL csdal = new CodeSenderDAL();
        private RealTimeDAL rtdal = new RealTimeDAL();

        #region [ 方法: 所有发码器状态修改为正常 ]

        /// <summary>
        /// 所有发码器状态修改为正常
        /// </summary>
        /// <returns></returns>
        public void InitAllCode()
        {
            csdal.InitAllCode();
        }

        #endregion

        #region 删除发码器

        public int removeCodeSender(int id)
        {
            return csdal.removeCodeSender(id);
        }

        #endregion

        #region 删除配置信息

        public int removeCodeSenderSet(int id)
        {
            return csdal.removeCodeSenderSet(id);
        }

        #endregion

        #region 修改发码器

        // 返回指定发码器信息
        public DataSet getCodeSender(int id)
        {
            return csdal.getCodeSender(id);
        }

        // 修改
        public int updateCodeSender(int CodeSenderStateID, int id, string Remark)
        {
            return csdal.updateCodeSender(CodeSenderStateID,id ,Remark);
        }

        #endregion

        #region 配置发码器
        // 发码器类型 0人员 1设备
        public int addCodeSender_Set(int CodeSenderID, int UserID, int CsTypeID)
        {
            return csdal.addCodeSender_Set(CodeSenderID, UserID, CsTypeID);
        }

        #endregion

        #region 加载发码器状态

        public ComboBox bindCmbCodeSenderState(ComboBox cmb)
        {
            DataSet ds = csdal.getCodeSenderStateInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Title";
                cmb.ValueMember = "EnumID";
            }
            return cmb;
        }

        #endregion

        #region 添加发码器并检查是否存在

        // 检测发码器是否存在
        public int getExistsCodeSenderAddress(int address, int alarmElectricity, int codeSenderStateID, int isCodeSenderUser, string remark)
        {
            return csdal.getExistsCodeSenderAddress(address,alarmElectricity, codeSenderStateID,isCodeSenderUser,remark);
        }

        #endregion

        #region 批量添加时获得已经存在的分站地址

        public DataTable getExistsCodeSenderAddressList(string addressAll)
        {
            return csdal.getExistsCodeSenderAddressList(addressAll);
        }

        #endregion

        #region 批量添加发码器
        // alarmElectricity默认为0 isCodeSenderUser默认为未使用2
        public int addCodeSenderInfo(string addressAll, int alarmElectricity, int codeSenderStateID, int isCodeSenderUser, string remark)
        {
            return csdal.addCodeSenderInfo(addressAll, alarmElectricity, codeSenderStateID, isCodeSenderUser, remark);
        }

        #endregion

        #region 加载发码器详细信息

        public DataSet N_getKJ128N_CodeSender_Info_Table(int pageIndex, int pageSize, string strWhere)
        {
            DataSet ds = csdal.getKJ128N_CodeSender_Info_Table(pageIndex,pageSize,strWhere);
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns["发码器地址"].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);
                ds.Tables[0].Columns["发码器状态"].ColumnName = HardwareName.Value(CorpsName.CodeSender) + "状态";
            }
            return ds;
        }

        #endregion

        //KJ128N_CodeSender_Set_Table
        #region 加载发码器配置信息

        public DataSet N_getKJ128N_CodeSender_Set_Table(int pageIndex, int pageSize,string strWhere)
        {
            DataSet ds = csdal.getKJ128N_CodeSender_Set_Table(pageIndex,pageSize,strWhere);
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns["发码器地址"].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);
            }
            return ds;
        }

        #endregion


        #region 获得未配置设备信息

        public DataSet getEquInfo(string deptID)
        {

            return csdal.getEquInfo(deptID);
        }

        #endregion

        #region 获得未配置人员信息

        public DataSet getEmpInfo(string deptID)
        {
            return csdal.getEmpInfo(deptID);
        }

        #endregion

        #region 获得未配置发码器信息

        public DataSet getCS()
        {
            return csdal.getCS();
        }

        #endregion

        #region 获得人员信息

        public DataSet getSmallEmpInfo(int empID)
        {
            return csdal.getSmallEmpInfo(empID);
        }

        #endregion

        #region 获得人员信息

        public DataSet getSmallEquInfo(int equID)
        {
            return csdal.getSmallEquInfo(equID);
        }

        #endregion

    }
}
