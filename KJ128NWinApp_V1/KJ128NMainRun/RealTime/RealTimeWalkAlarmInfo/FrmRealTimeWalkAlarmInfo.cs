using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NMainRun
{
    /// <summary>
    /// 实时行走异常报警信息
    /// </summary>
    public partial class FrmRealTimeWalkAlarmInfo : Form
    {
        #region [私有变量]

        private RealTimeWalkBLL bll = new RealTimeWalkBLL();

        #endregion

        #region [构造函数]

        public FrmRealTimeWalkAlarmInfo()
        {
            InitializeComponent();
        }

        #endregion

        #region [私有方法]

        private void BandingDataGridView(string condition)
        {
            DataTable dt = SelectRealTimeWalkAlarmInfo(condition);

            this.dgvMain.DataSource = dt;

            if (dt != null)
            {
                this.captionPanel1.CaptionTitle = "实时行走异常报警信息：\t共" + dt.Rows.Count.ToString() + "条";
            }
            else
            {
                this.captionPanel1.CaptionTitle = "实时行走异常报警信息：\t共0条";
            }
        }


        /// <summary>
        /// 查询实时行走异常报警信息
        /// </summary>
        /// <returns>返回结果记录</returns>
        private DataTable SelectRealTimeWalkAlarmInfo(string condition)
        {
            if (bll == null)
                bll = new RealTimeWalkBLL();

            return bll.SelectRealTimeWalkAlarmInfo(condition);
        }

        /// <summary>
        /// 修改实时行走异常报警措施
        /// </summary>
        /// <param name="id">报警信息ID</param>
        /// <returns>返回执行信息条数</returns>
        private int UpdateRealTimeWalkMeasure(int id, string measure)
        {
            if (bll == null)
                bll = new RealTimeWalkBLL();

            return bll.UpdateRealTimeWalkMeasure(id, measure);
        }

        /// <summary>
        /// 删除（完成）实时行走异常报警，写入历史
        /// </summary>
        /// <param name="id">报警信息ID</param>
        /// <returns>返回执行信息条数</returns>
        private int DeleteRealTimeWalkInfoToHistroy(int id)
        {
            if (bll == null)
                bll = new RealTimeWalkBLL();

            return bll.DeleteRealTimeWalkInfoToHistroy(id);
        }

        private void FrmRealTimeWalkAlarmInfo_Load(object sender, EventArgs e)
        {
            BandingDataGridView("");
        }

        private void bcpSelect_Click(object sender, EventArgs e)
        {
            try
            {
                string condition = String.Empty;

                if (txtEmpName.Text.Trim() != "")
                {
                    condition = " and EmpName like '%" + txtEmpName.Text + "%'";
                }
                else
                {
                    condition = "1=1";
                }

                if (txtCodeSenderAddress.Text.Trim() != "")
                {
                    condition += " and CodeSenderAddress=" + txtCodeSenderAddress.Text;
                }

                BandingDataGridView(condition);
            }
            catch (Exception ex)
            {
                MessageBox.Show("组织查询条件导致SQL查询错误\n错误消息：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 给GridView排序
        /// </summary>
        private void SortColumns()
        {
            if (this.dgvMain.ColumnCount > 0)
            {
                //隐藏字段
                dgvMain.Columns["WalkConfigId"].Visible = false;
                dgvMain.Columns["EmpID"].Visible = false;
                dgvMain.Columns["DeptID"].Visible = false;

                //设置显示顺序
                dgvMain.Columns["CodeSenderAddress"].DisplayIndex = 0;
                dgvMain.Columns["CodeSenderAddress"].HeaderText = "标识卡编号";

                dgvMain.Columns["EmpName"].DisplayIndex = 1;
                dgvMain.Columns["EmpName"].HeaderText = "姓名";

                dgvMain.Columns["DeptName"].DisplayIndex = 2;
                dgvMain.Columns["DeptName"].HeaderText = "部门";


                dgvMain.Columns["FirstStationAddress"].DisplayIndex = 3;
                dgvMain.Columns["FirstStationAddress"].HeaderText = "第一传输分站编号";

                dgvMain.Columns["FirstStationHeadAddress"].DisplayIndex = 4;
                dgvMain.Columns["FirstStationHeadAddress"].HeaderText = "第一读卡分站编号";

                dgvMain.Columns["FirstStationHeadAntennaA"].DisplayIndex = 5;
                dgvMain.Columns["FirstStationHeadAntennaA"].HeaderText = "第一天线A";

                dgvMain.Columns["FirstStationHeadAntennaB"].DisplayIndex = 6;
                dgvMain.Columns["FirstStationHeadAntennaB"].HeaderText = "第一天线B";

                dgvMain.Columns["firstPlace"].DisplayIndex = 7;
                dgvMain.Columns["firstPlace"].HeaderText = "第一读卡分站安装位置";


                dgvMain.Columns["MiddleStationAddress"].DisplayIndex = 8;
                dgvMain.Columns["MiddleStationAddress"].HeaderText = "中间传输分站编号";

                dgvMain.Columns["MiddleStationHeadAddress"].DisplayIndex = 9;
                dgvMain.Columns["MiddleStationHeadAddress"].HeaderText = "中间读卡分站编号";

                dgvMain.Columns["MiddleStationHeadAntennaA"].DisplayIndex = 10;
                dgvMain.Columns["MiddleStationHeadAntennaA"].HeaderText = "中间天线A";

                dgvMain.Columns["MiddleStationHeadAntennaB"].DisplayIndex = 11;
                dgvMain.Columns["MiddleStationHeadAntennaB"].HeaderText = "中间天线B";

                dgvMain.Columns["middlePlace"].DisplayIndex = 12;
                dgvMain.Columns["middlePlace"].HeaderText = "中间读卡分站安装位置";


                dgvMain.Columns["LastStationAddress"].DisplayIndex = 13;
                dgvMain.Columns["LastStationAddress"].HeaderText = "最后传输分站编号";

                dgvMain.Columns["LastStationHeadAddress"].DisplayIndex = 14;
                dgvMain.Columns["LastStationHeadAddress"].HeaderText = "最后读卡分站编号";

                dgvMain.Columns["LastStationHeadAntennaA"].DisplayIndex = 15;
                dgvMain.Columns["LastStationHeadAntennaA"].HeaderText = "最后天线A";

                dgvMain.Columns["LastStationHeadAntennaB"].DisplayIndex = 16;
                dgvMain.Columns["LastStationHeadAntennaB"].HeaderText = "最后天线B";

                dgvMain.Columns["lastPlace"].DisplayIndex = 17;
                dgvMain.Columns["lastPlace"].HeaderText = "最后读卡分站安装位置";


                dgvMain.Columns["TimeValue"].DisplayIndex = 18;
                dgvMain.Columns["TimeValue"].HeaderText = "规定时间";


                //dgvMain.Columns["Edit"].DisplayIndex = 19;

                //dgvMain.Columns["Delete"].DisplayIndex = 20;

            }
        }

        private void bcpExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(this.dgvMain, "实时行走异常报警信息");
        }

        #endregion  
    }
}
