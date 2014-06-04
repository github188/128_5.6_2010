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

        private string strWhere_StationHead;

        #endregion

        #region 【方法: 查询信息】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_StationHead()
        {
            string strTempWhere = " 故障开始时间 >= '" + dtp_StationHead_Begin.Text +
                "' And 故障开始时间 <='" + dtp_StationHead_End.Text + "' ";

            try
            {
                if (tvc_StationHead != null && tvc_StationHead.SelectedNode != null && !tvc_StationHead.SelectedNode.Name.Equals("0"))
                {
                    if (tvc_StationHead.SelectedNode.Name.Substring(0, 1).Equals("S"))
                    {
                        strTempWhere += " And 传输分站编号 = " + tvc_StationHead.SelectedNode.Name.Substring(1);
                    }
                    else if (tvc_StationHead.SelectedNode.Name.Substring(0, 1).Equals("H"))
                    {
                        strTempWhere += " And 读卡分站编号 = " + tvc_StationHead.SelectedNode.Name.Substring(tvc_StationHead.SelectedNode.Name.Length - 1);
                        strTempWhere += " And 传输分站编号 = " + tvc_StationHead.SelectedNode.Name.Substring(1, tvc_StationHead.SelectedNode.Name.Length - 2);
                    }

                }
            }
            catch (Exception ex)
            { }

            return strTempWhere;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pIndex">所有查询的页数</param>
        public void SelectInfo_StationHead(int pIndex)
        {
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }

            DataSet ds = rtabll.GetInfo_HisStationHead(pIndex, pSize, strWhere_StationHead);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                ds.Tables[0].TableName = "A_FrmHisAlarm_StationHead";
                if (sumPage == 0)
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    //lblMainTitle.Text = "历史读卡分站故障报警：  共 0 个";
                    lblCounts.Text = "共 0 条记录";

                    lblPageCounts.Text = "1";
                    lblSumPage.Text = "/1页";

                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    //lblMainTitle.Text = "历史读卡分站故障报警：  共 " + ds.Tables[2].Rows[0][0].ToString() + " 个";
                    lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条记录";

                    lblPageCounts.Text = pIndex.ToString();
                    lblSumPage.Text = "/" + sumPage + "页";

                    //控制翻页状态
                    SetPageEnable(pIndex, sumPage);
                }
                if (dgv_Main.Columns.Count >= 6)
                {
                    dgv_Main.Columns["故障开始时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    dgv_Main.Columns["故障结束时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    dgv_Main.Columns["HistoryBadStationsID"].Visible = false;

                    dgv_Main.Columns["传输分站编号"].DisplayIndex = 0;
                    dgv_Main.Columns["读卡分站编号"].DisplayIndex = 1;
                    dgv_Main.Columns["读卡分站位置"].DisplayIndex = 2;
                    dgv_Main.Columns["故障开始时间"].DisplayIndex = 3;
                    dgv_Main.Columns["故障结束时间"].DisplayIndex = 4;
                    dgv_Main.Columns["故障持续时长"].DisplayIndex = 5;
                    dgv_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }
        #endregion


    }
}
