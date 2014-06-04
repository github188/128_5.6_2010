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

        private string strWhere_Territorial;

        #endregion

        #region 【方法: 查询信息】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_Territorial()
        {
            string strTempWhere = " InTerritorialTime >= '" + dtp_Territorial_Begin.Text + "' And InTerritorialTime <='" + dtp_Territorial_End.Text + "'  and IsAlarm=1 and ContinueTime >0 ";

            if (tvc_Territorial.SelectedNode != null && !tvc_Territorial.SelectedNode.Name.Equals("0"))
            {
                if (tvc_Territorial.SelectedNode.Name.Substring(0, 1).Equals("T"))  //区域类型
                {
                    strTempWhere += " And TerritorialTypeName = '" + tvc_Territorial.SelectedNode.Tag.ToString() + "' ";
                }
                else if (tvc_Territorial.SelectedNode.Name.Substring(0, 1).Equals("I"))  //区域名称
                {
                    strTempWhere += " And TerritorialName = '" + tvc_Territorial.SelectedNode.Tag.ToString() + "' ";
                }
            }

            if (!txt_Territorial_EmpName.Text.Trim().Equals(""))
            {
                strTempWhere += " And UserName like  '%" + txt_Territorial_EmpName.Text.Trim() + "%' ";
            }

            if (!txt_Territorial_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And CodeSenderAddress = " + txt_Territorial_CodeSenderAddress.Text.Trim();
            }

            return strTempWhere;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pIndex">所有查询的页数</param>
        public void SelectInfo_Territorial(int pIndex)
        {
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }

            DataSet ds = rtabll.GetInfo_HisTerritorial(pIndex, pSize, strWhere_Territorial);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                ds.Tables[0].TableName = "A_FrmHisAlarm_Area";
                if (sumPage == 0)
                {
                    
                    dgv_Main.DataSource = ds.Tables[0];

                    //lblMainTitle.Text = "历史区域报警：  共 0 人";
                    lblCounts.Text = "共 0 条记录";

                    lblPageCounts.Text = "1";
                    lblSumPage.Text = "/1页";

                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    //lblMainTitle.Text = "历史区域报警：  共 " + ds.Tables[2].Rows[0][0].ToString() + " 人";
                    lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条记录";

                    lblPageCounts.Text = pIndex.ToString();
                    lblSumPage.Text = "/" + sumPage + "页";

                    //控制翻页状态
                    SetPageEnable(pIndex, sumPage);
                }
                if (dgv_Main.Columns.Count >= 0)
                {
                    dgv_Main.Columns["InTerritorialTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    dgv_Main.Columns["OutTerritorialTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    dgv_Main.Columns["HisTerritorialID"].Visible = false;

                    dgv_Main.Columns["CodeSenderAddress"].HeaderText = "标识卡号";
                    dgv_Main.Columns["CodeSenderAddress"].DisplayIndex = 0;
                    dgv_Main.Columns["UserName"].HeaderText = "姓名";
                    dgv_Main.Columns["UserName"].DisplayIndex = 1;
                    dgv_Main.Columns["WorkTypeName"].HeaderText = "工种";
                    dgv_Main.Columns["WorkTypeName"].DisplayIndex = 2;
                    dgv_Main.Columns["TerritorialTypeName"].HeaderText = "区域类型";
                    dgv_Main.Columns["TerritorialTypeName"].DisplayIndex = 3;
                    dgv_Main.Columns["TerritorialName"].HeaderText = "区域名称";
                    dgv_Main.Columns["TerritorialName"].DisplayIndex = 4;

                    dgv_Main.Columns["InTerritorialTime"].HeaderText = "进入区域时间";
                    dgv_Main.Columns["InTerritorialTime"].DisplayIndex = 5;
                    dgv_Main.Columns["OutTerritorialTime"].HeaderText = "离开区域时间";
                    dgv_Main.Columns["OutTerritorialTime"].DisplayIndex = 6;
                    dgv_Main.Columns["ContinueTime"].HeaderText = "滞留时长";
                    dgv_Main.Columns["ContinueTime"].DisplayIndex = 7;
                    dgv_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_Main.Columns["WorkTypeName"].HeaderText = "工种";
                    dgv_Main.Columns["WorkTypeName"].DefaultCellStyle.NullValue = "——";

                    dgv_Main.Columns["TerritorialID"].Visible = false;
                    dgv_Main.Columns["UserNo"].Visible = false;
                    dgv_Main.Columns["DeptID"].Visible = false;
                    dgv_Main.Columns["DutyID"].Visible = false;
                    dgv_Main.Columns["WorkTypeID"].Visible = false;
                    dgv_Main.Columns["IsAlarm"].Visible = false;
                    dgv_Main.Columns["DeptName"].Visible = false;
                    dgv_Main.Columns["DutyName"].Visible = false;
                    dgv_Main.Columns["ContinueTime"].Visible = false;
                    dgv_Main.Columns["UserID"].Visible = false;

                    if (ds.Tables.Count > 0)
                    {
                        DataColumn dc = new DataColumn("持续时长");
                        ds.Tables[0].Columns.Add(dc);

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Int64 iTime = Int64.Parse(ds.Tables[0].Rows[i]["ContinueTime"].ToString());
                            int iDay = (int)(iTime / 86400);
                            int iHour = (int)((iTime - iDay * 86400) / 3600);
                            int iMinute = (int)((iTime - iDay * 86400 - iHour * 3600) / 60);
                            ds.Tables[0].Rows[i]["持续时长"] = string.Format("{0}天{1}时{2}分{3}秒",
                                iDay, iHour, iMinute, iTime % 60);
                        }
                    }

                }
            }
        }
        #endregion



    }
}
