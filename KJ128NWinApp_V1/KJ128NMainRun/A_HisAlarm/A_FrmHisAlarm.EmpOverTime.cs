﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace KJ128NMainRun.A_HisAlarm
{
    partial class A_FrmHisAlarm
    {

        #region【声明】

        private string strWhere_EmpOverTime;

        #endregion


        #region 【方法: 查询信息】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_EmpOverTime()
        {
            string strTempWhere = " CsTypeID=0 And 开始时间 >= '" + dtp_EmpOverTime_Begin.Text + 
                "' And 开始时间 <='" + dtp_EmpOverTime_End.Text + "' ";

            if (!txt_EmpOverTime_EmpName.Text.Trim().Equals(""))
            {
                strTempWhere += " And 姓名 like  '%" + txt_EmpOverTime_EmpName.Text.Trim() + "%' ";
            }

            if (!txt_EmpOverTime_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And 标识卡号 = " + txt_EmpOverTime_CodeSenderAddress.Text.Trim();
            }

            if (tvc_EmpOverTime_Dept.SelectedNode != null && !tvc_EmpOverTime_Dept.SelectedNode.Name.Equals("0"))
            {
                strTempWhere += " And ( 部门 = " + GetNodeAllChild(tvc_EmpOverTime_Dept.SelectedNode) + " )";
            }
            return strTempWhere;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pIndex">所有查询的页数</param>
        public void SelectInfo_EmpOverTime(int pIndex)
        {
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }

            DataSet ds = rtabll.GetOverTimeSet(pIndex, pSize, strWhere_EmpOverTime);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                ds.Tables[0].TableName = "A_FrmHisAlarm_OverTime";
                if (sumPage == 0)
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    //lblMainTitle.Text = "历史超时报警：  共 0 人";
                    lblCounts.Text = "共 0 条记录";

                    lblPageCounts.Text ="1";
                    lblSumPage.Text = "/1页";

                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    //lblMainTitle.Text = "历史超时报警：  共 " + ds.Tables[2].Rows[0][0].ToString() + " 人";
                    lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条记录";

                    lblPageCounts.Text = pIndex.ToString();
                    lblSumPage.Text = "/" + sumPage + "页";

                    //控制翻页状态
                    SetPageEnable(pIndex, sumPage);     
                }
                if (dgv_Main.Columns.Count >= 8)
                {
                    dgv_Main.Columns["开始时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    dgv_Main.Columns["结束时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    dgv_Main.Columns["CsTypeID"].Visible = false;
                    dgv_Main.Columns["HisOverTimeAlarmID"].Visible = false;

                    dgv_Main.Columns["标识卡号"].DisplayIndex = 0;
                    dgv_Main.Columns["姓名"].DisplayIndex = 1;
                    dgv_Main.Columns["部门"].DisplayIndex = 2;
                    dgv_Main.Columns["职务"].DisplayIndex = 3;
                    dgv_Main.Columns["工种"].DisplayIndex = 4;
                    dgv_Main.Columns["开始时间"].DisplayIndex = 5;
                    dgv_Main.Columns["结束时间"].DisplayIndex = 6;
                    dgv_Main.Columns["持续时长"].DisplayIndex = 7;
                    dgv_Main.Columns["职务"].DefaultCellStyle.NullValue = "——";
                    dgv_Main.Columns["工种"].DefaultCellStyle.NullValue = "——";
                }
            }
        }
        #endregion

    }
}
