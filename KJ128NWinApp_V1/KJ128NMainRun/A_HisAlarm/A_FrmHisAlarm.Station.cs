using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace KJ128NMainRun.A_HisAlarm
{
    partial class A_FrmHisAlarm
    {

        #region【声明】

        private string strWhere_Station;

        #endregion

        #region 【方法: 查询信息】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_Station()
        {
            string strTempWhere = " 故障开始时间 >= '" + dtp_Station_Begin.Text +
                "' And 故障开始时间 <='" + dtp_Station_End.Text + "' ";

            if (tvc_Station != null && tvc_Station.SelectedNode != null && !tvc_Station.SelectedNode.Name.Equals("0"))
            {
                strTempWhere += " And 分站编号 = " + tvc_Station.SelectedNode.Name;
            }

            return strTempWhere;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pIndex">所有查询的页数</param>
        public void SelectInfo_Station(int pIndex)
        {
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }

            DataSet ds = rtabll.GetInfo_HisStation(pIndex, pSize, strWhere_Station);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                if (sumPage == 0)
                {
                    ds.Tables[0].TableName = "A_FrmHisAlarm_Station";
                    dgv_Main.DataSource = ds.Tables[0];

                    //lblMainTitle.Text = "历史传输分站故障报警：  共 0 个";
                    lblCounts.Text = "共 0 条记录";

                    lblPageCounts.Text = "1";
                    lblSumPage.Text = "/1页";

                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    //lblMainTitle.Text = "历史传输分站故障报警：  共 " + ds.Tables[2].Rows[0][0].ToString() + " 个";
                    lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条记录";

                    lblPageCounts.Text = pIndex.ToString();
                    lblSumPage.Text = "/" + sumPage + "页";

                    //控制翻页状态
                    SetPageEnable(pIndex, sumPage);
                }
                if (dgv_Main.Columns.Count >= 5)
                {
                    dgv_Main.Columns["故障开始时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    dgv_Main.Columns["故障结束时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    dgv_Main.Columns["HistoryBadStationsID"].Visible = false;

                    dgv_Main.Columns["分站编号"].DisplayIndex = 0;
                    dgv_Main.Columns["分站位置"].DisplayIndex = 1;
                    dgv_Main.Columns["故障开始时间"].DisplayIndex = 2;
                    dgv_Main.Columns["故障结束时间"].DisplayIndex = 3;
                    dgv_Main.Columns["故障持续时长"].DisplayIndex = 4;
                    dgv_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }
        #endregion


    }
}
