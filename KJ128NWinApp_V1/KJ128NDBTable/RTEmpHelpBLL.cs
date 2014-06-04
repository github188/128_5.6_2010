using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using KJ128NDataBase;
using KJ128NInterfaceShow;
using Microsoft.Office.Tools.Excel.Controls;

namespace KJ128NDBTable
{
    public class RTEmpHelpBLL
    {

        #region [ 声明 ]
        

        private RealTimeEmpHelpDAL dal = new RealTimeEmpHelpDAL();

        private DataSet ds;

        #endregion

        #region [ 方法: 查询实时求救信息]

        public bool GetRTEmpHelpInfo(string strBeginTime, string strEndTime, string strCodeSenderAddress, string strSatationAddress, string strStaHeadAddress, string strEmpName, string strDeptName, string strDutyName, string strWtName, string strMeasure, DataGridViewKJ128 dgv)
        {
            try
            {

                using (ds = new DataSet())
                {
                    ds = dal.SelectRealTimeEmpHelpInfo(strBeginTime, strEndTime, strCodeSenderAddress, strSatationAddress, strStaHeadAddress, strEmpName, strDeptName, strDutyName, strWtName, strMeasure);

                    if (ds != null && ds.Tables.Count > 0)
                    {
                        dgv.Columns.Clear();
                        dgv.DataSource = ds.Tables[0];
                        AddColumns(dgv);

                        
                        dgv.Columns[0].HeaderText = HardwareName.Value(CorpsName.StationAddress);
                        dgv.Columns[1].HeaderText = HardwareName.Value(CorpsName.StationSplace);
                        dgv.Columns[2].HeaderText = HardwareName.Value(CorpsName.StaHeadAddress);
                        dgv.Columns[3].HeaderText = HardwareName.Value(CorpsName.StaHeadSplace);
                        dgv.Columns[4].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);
                    
                        dgv.Columns[0].Width = 50;
                        dgv.Columns[2].Width = 50;
                        dgv.Columns[4].Width = 50;
                        dgv.Columns[5].Width = 70;
                        dgv.Columns[6].Width = 70;
                        dgv.Columns[7].Width = 70;
                        dgv.Columns[8].Width = 70;

                        dgv.Columns[9].Width = 80;
                        dgv.Columns[10].Width = 140;
                        dgv.Columns[10].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                        dgv.Columns[11].Visible = false;

                        if (New_DBAcess.blIsClient)
                        {
                            dgv.Columns["Measure"].Visible=false;
                            dgv.Columns["EndHelp"].Visible = false;
                        }

                    }

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region [ 方法: 添加列 ]

        private void AddColumns(System.Windows.Forms.DataGridView dgvTmep)
        {
            DataGridViewLinkColumn dgvLink1 = new DataGridViewLinkColumn();
            dgvLink1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvLink1.HeaderText = "修改救援措施";
            dgvLink1.Name = "Measure";
            dgvLink1.Text = "修改";
            dgvLink1.UseColumnTextForLinkValue = true;
            dgvLink1.Resizable = DataGridViewTriState.False;
            dgvTmep.Columns.Add(dgvLink1);

            DataGridViewLinkColumn dgvLink2 = new DataGridViewLinkColumn();
            dgvLink2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvLink2.HeaderText = "完成救援";
            dgvLink2.Name = "EndHelp";
            dgvLink2.Text = "完成";
            dgvLink2.UseColumnTextForLinkValue = true;
            dgvLink2.Resizable = DataGridViewTriState.False;
            dgvTmep.Columns.Add(dgvLink2);

        }

        #endregion

        #region [ 方法: 获取救援措施 ]
        /// <summary>
        /// 获取救援措施
        /// </summary>
        /// <param name="strEmpID">员工ID</param>
        /// <returns>救援措施</returns>
        public string GetMeasure(string strEmpID)
        {
           return dal.GetMeasure(strEmpID);
        }

        #endregion

        #region [ 方法: 保存救援措施 ]
        /// <summary>
        /// 保存救援措施
        /// </summary>
        /// <param name="strEmpID">员工ID</param>
        /// <param name="strMeasure">救援措施</param>
        /// <returns>影响行数</returns>
        public int SaveMeasure(string strEmpID, string strMeasure)
        {
            return dal.SaveMeasure(strEmpID, strMeasure);
        }

        #endregion

        #region [ 方法: 查询求救信息的总数 ]
        /// <summary>
        /// 查询求救信息的总数
        /// </summary>
        /// <returns>实时求救信息总数</returns>
        public string GetEmpHelpCounts()
        {
            return dal.GetEmpHelpCounts();
        }

        #endregion

        #region [ 方法: 删除实时求救信息 ]
        /// <summary>
        /// 删除实时求救信息
        /// </summary>
        /// <param name="strEmpID">员工ID</param>
        /// <returns>返回影响行数</returns>
        public int DeleteRTEmpHelp(string strEmpID)
        {
            return dal.DeleteRTEmpHelp(strEmpID);
        }

        #endregion

    }
}
