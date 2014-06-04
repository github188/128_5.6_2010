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

        private string strWhere_OverSpeed;

        #endregion

        #region 【方法: 查询信息】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_OverSpeed()
        {
            string strTempWhere = " 起始读卡分站监测时间 >= '" + dtp_OverSpeed_Begin.Text +
                "' And 起始读卡分站监测时间 <='" + dtp_OverSpeed_End.Text + "' ";

            if (!txt_OverSpeed_EmpName.Text.Trim().Equals(""))
            {
                strTempWhere += " And 姓名 like  '%" + txt_OverSpeed_EmpName.Text.Trim() + "%' ";
            }

            if (!txt_OverSpeed_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And 标识卡号 = " + txt_OverSpeed_CodeSenderAddress.Text.Trim();
            }

            if (tvc_OverSpeed_Dept.SelectedNode != null && !tvc_OverSpeed_Dept.SelectedNode.Name.Equals("0"))
            {
                strTempWhere += " And ( 部门 = " + GetNodeAllChild(tvc_OverSpeed_Dept.SelectedNode) + " )";
            }
            return strTempWhere;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pIndex">所有查询的页数</param>
        public void SelectInfo_OverSpeed(int pIndex)
        {
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }

            DataSet ds = rtabll.GetInfo_HisOverSpeed(pIndex, pSize, strWhere_OverSpeed);

            if (ds.Tables != null && ds.Tables.Count > 1)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                ds.Tables[0].TableName = "A_FrmHisAlarm_OverSpeed";
                if (sumPage == 0)
                {
                    
                    dgv_Main.DataSource = ds.Tables[0];

                    //lblMainTitle.Text = "历史超速报警：  共 0 人";
                    lblCounts.Text = "共 0 条记录";

                    lblPageCounts.Text = "1";
                    lblSumPage.Text = "/1页";

                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    //lblMainTitle.Text = "历史超速报警：  共 " + ds.Tables[2].Rows[0][0].ToString() + " 人";
                    lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条记录";

                    lblPageCounts.Text = pIndex.ToString();
                    lblSumPage.Text = "/" + sumPage + "页";

                    //控制翻页状态
                    SetPageEnable(pIndex, sumPage);
                }
                if (dgv_Main.Columns.Count >= 14)
                {
                    dgv_Main.Columns["起始读卡分站监测时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    dgv_Main.Columns["终点读卡分站监测时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    dgv_Main.Columns["HisOverSpeedID"].Visible = false;

                    dgv_Main.Columns["标识卡号"].DisplayIndex = 0;
                    dgv_Main.Columns["姓名"].DisplayIndex = 1;
                    dgv_Main.Columns["部门"].DisplayIndex = 2;
                    dgv_Main.Columns["起始传输分站编号"].DisplayIndex = 3;
                    dgv_Main.Columns["起始读卡分站编号"].DisplayIndex = 4;
                    dgv_Main.Columns["起始读卡分站位置"].DisplayIndex = 5;
                    dgv_Main.Columns["起始读卡分站监测时间"].DisplayIndex = 6;
                    dgv_Main.Columns["终点传输分站编号"].DisplayIndex = 7;
                    dgv_Main.Columns["终点读卡分站编号"].DisplayIndex = 8;
                    dgv_Main.Columns["终点读卡分站位置"].DisplayIndex = 9;
                    dgv_Main.Columns["终点读卡分站监测时间"].DisplayIndex = 10;
                    dgv_Main.Columns["额定行走时间"].DisplayIndex = 11;
                    dgv_Main.Columns["实际行走时间"].DisplayIndex = 12;
                }
            }
        }
        #endregion


    }
}
