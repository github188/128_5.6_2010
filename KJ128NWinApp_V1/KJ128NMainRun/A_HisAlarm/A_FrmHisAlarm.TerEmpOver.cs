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

        private string strWhere_TerOverEmp;

        #endregion


        #region 【方法: 查询信息】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_TerOverEmp()
        {
            string strTempWhere = " 开始时间 >= '" + dtp_TerOverEmp_Begin.Text + "' And 开始时间 <='" + dtp_TerOverEmp_End.Text + "' ";

            if (tvc_TerOverEmp.SelectedNode != null && !tvc_TerOverEmp.SelectedNode.Name.Equals("0"))
            {
                if (tvc_TerOverEmp.SelectedNode.Name.Substring(0, 1).Equals("T"))  //区域类型
                {
                    strTempWhere += " And 区域类型 = '" + tvc_TerOverEmp.SelectedNode.Tag.ToString() + "' ";
                }
                else if (tvc_TerOverEmp.SelectedNode.Name.Substring(0, 1).Equals("I"))  //区域名称
                {
                    strTempWhere += " And 区域名称 = '" + tvc_TerOverEmp.SelectedNode.Tag.ToString() + "' ";
                }
            }

            return strTempWhere;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pIndex">所有查询的页数</param>
        public void SelectInfo_TerOverEmp(int pIndex)
        {
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }

            DataSet ds = rtabll.GetInfo_HisTerOverEmp(pIndex, pSize, strWhere_TerOverEmp);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                ds.Tables[0].TableName = "A_FrmHisAlarm_EmpOver";
                if (sumPage == 0)
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    //lblMainTitle.Text = "历史区域超员报警：  共 0 人";
                    lblCounts.Text = "共 0 条记录";

                    lblPageCounts.Text = "1";
                    lblSumPage.Text = "/1页";

                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条记录";

                    lblPageCounts.Text = pIndex.ToString();
                    lblSumPage.Text = "/" + sumPage + "页";

                    //控制翻页状态
                    SetPageEnable(pIndex, sumPage);
                }
                if (dgv_Main.Columns.Count >= 7)
                {
                    dgv_Main.Columns["开始时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    dgv_Main.Columns["结束时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    dgv_Main.Columns["HisTerOverEmpID"].Visible = false;

                    dgv_Main.Columns["区域名称"].DisplayIndex = 0;
                    dgv_Main.Columns["区域类型"].DisplayIndex = 1;
                    dgv_Main.Columns["区域额定工作人数"].DisplayIndex = 2;
                    dgv_Main.Columns["最大超员人数"].DisplayIndex = 3;
                    dgv_Main.Columns["开始时间"].DisplayIndex = 4;
                    dgv_Main.Columns["结束时间"].DisplayIndex = 5;
                }
                if (dgv_Main.Columns.Count * 100 >= this.dgv_Main.Width)
                {
                    dgv_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    dgv_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }
        #endregion

    }
}
