using System.Data;
using KJ128NDBTable;
using System;

namespace KJ128NMainRun.A_HisAlarm
{
    partial class A_FrmHisAlarm
    {
        //#region 【自定义参数】
        ///// <summary>
        ///// 查询条件
        ///// </summary>
        //string m_StrAssociateWhere = "";
        ///// <summary>
        ///// 异地交接班逻辑对象
        ///// </summary>
        //private AssociateBLL associateBll = new AssociateBLL();
        //#endregion

        //#region 【自定义方法】
        //#region 【方法：绑定分站树信息】
        ///// <summary>
        ///// 绑定分站树信息
        ///// </summary>
        //private void LoadStationTree()
        //{
        //    DataTable dt = associateBll.GetStationTree();
        //    treeViewControlStation.DataSouce = dt;
        //    treeViewControlStation.LoadNode("");

        //    treeViewControlStation.ExpandAll();
        //}
        //#endregion

        //#region 【方法：获取查询条件】
        ///// <summary>
        ///// 获取查询条件
        ///// </summary>
        //private void GetScaelSql()
        //{
        //    m_StrAssociateWhere = "";
        //    //员工1的姓名
        //    if (!txtEmpName1.Text.Trim().Equals(""))
        //    {
        //        m_StrAssociateWhere = " empName1 like '%" + txtEmpName1.Text + "%' ";
        //    }
        //    if (!txtEmpName2.Text.Trim().Equals(""))
        //    {
        //        if (!m_StrAssociateWhere.Equals(""))
        //        {
        //            m_StrAssociateWhere += " and ";
        //        }
        //        m_StrAssociateWhere += " empName2 like '%" + txtEmpName2.Text + "%' ";
        //    }
        //    if (treeViewControlStation.SelectedNode != null)
        //    {
        //        if (treeViewControlStation.SelectedNode.Level > 0)
        //        {
        //            if (!m_StrAssociateWhere.Equals(""))
        //            {
        //                m_StrAssociateWhere += " and ";
        //            }
        //            if (treeViewControlStation.SelectedNode.Level == 1)
        //            {
        //                m_StrAssociateWhere += "stationAddress=" + treeViewControlStation.SelectedNode.Name.Substring(1);
        //            }
        //            else
        //            {
        //                m_StrAssociateWhere += "stationAddress=" + treeViewControlStation.SelectedNode.Parent.Name.Substring(1);
        //            }
        //        }
        //        if (treeViewControlStation.SelectedNode.Level > 1)
        //        {
        //            if (!m_StrAssociateWhere.Equals(""))
        //            {
        //                m_StrAssociateWhere += " and ";
        //            }
        //            m_StrAssociateWhere += " stationHeadAddress=" + treeViewControlStation.SelectedNode.Name.Substring(1);
        //        }
        //    }
        //    if (checkBox1.Checked)
        //    {
        //        if (!m_StrAssociateWhere.Equals(""))
        //        {
        //            m_StrAssociateWhere += " and ";
        //        }
        //        m_StrAssociateWhere += " isFlagEmp1='异常' or isFlagEmp2='异常'";
        //    }
        //    if (!m_StrAssociateWhere.Equals(""))
        //    {
        //        m_StrAssociateWhere += " and ";
        //    }
        //    m_StrAssociateWhere += " beginTime>'" + dtpScealBeginDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and beginTime<'" + dtpScealEndData.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
        //}

        //#endregion

        //#region 【方法：重置查询条件】
        ///// <summary>
        ///// 重置查询条件
        ///// </summary>
        //private void ResetSceal()
        //{
        //    dtpScealBeginDate.Value = DateTime.Now.AddDays(-7);
        //    dtpScealEndData.Value = DateTime.Now;
        //    txtEmpName1.Text = "";
        //    txtEmpName2.Text = "";
        //    checkBox1.Checked = false;
        //}
        //#endregion

        //#region 【方法：绑定数据】
        ///// <summary>
        ///// 绑定数据
        ///// </summary>
        ///// <param name="pIndex"></param>
        //public void BindDataAssociate(int pIndex)
        //{
        //    if (pIndex < 1)
        //    {
        //        pIndex = 1;
        //        return;
        //    }

        //    if (pIndex == 1)
        //    {
        //        btnUpPage.Enabled = false;
        //    }

        //    DataSet ds = null;
        //    try
        //    {
        //        ds = associateBll.GetAssociateInfo(pIndex, m_PSize, m_StrWhere);
        //    }
        //    catch { }

        //    if (ds.Tables != null && ds.Tables.Count > 0)
        //    {
        //        // 重新设置页数
        //        int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
        //        if (sumPage != 0)
        //        {
        //            sumPage = sumPage % m_PSize != 0 ? sumPage / m_PSize + 1 : sumPage / m_PSize;
        //            m_PCounts = sumPage;//获取总页数
        //            if (pIndex > sumPage)
        //            {
        //                if (sumPage == 0)
        //                {
        //                    lblCounts.Text = "共 0 条信息";
        //                    lblPageCounts.Text = "1";
        //                    lblSumPage.Text = "/" + 1 + "页";
        //                    btnUpPage.Enabled = false;
        //                    btnDownPage.Enabled = false;
        //                    return;
        //                }
        //                pIndex = sumPage;
        //            }

        //            btnUpPage.Enabled = true;
        //            btnDownPage.Enabled = true;
        //            if (pIndex == 1)
        //            {
        //                btnUpPage.Enabled = false;
        //            }
        //            if (pIndex == sumPage)
        //            {
        //                btnDownPage.Enabled = false;
        //            }
        //        }
        //        else
        //        {
        //            btnUpPage.Enabled = false;
        //            btnDownPage.Enabled = false;
        //            pIndex = 1;
        //        }

        //        lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条信息";
        //        lblPageCounts.Text = pIndex.ToString();
        //        if (sumPage == 0)
        //        {
        //            sumPage = 1;
        //        }
        //        lblSumPage.Text = "/" + sumPage + "页";
        //        dgvMain.DataSource = ds.Tables[0];
        //    }
        //    else
        //    {
        //        lblCounts.Text = "共 0 条信息";
        //        btnDownPage.Enabled = false;
        //        btnUpPage.Enabled = false;
        //        lblPageCounts.Text = "1";
        //        lblSumPage.Text = "/" + 1 + "页";
        //    }
        //}
        //#endregion
        //#endregion


        //#region 【系统事件方法】
        //#region 【事件方法：抽屉控制】
        private void btnAssociate_Click(object sender, EventArgs e)
        {
            //if (intSelectModel != 11)
            //{
            //    lblMainTitle.Text = "历史异地交接班";
            //    intSelectModel = 11;
            //    LoadStationTree();
            //    ResetSceal();
            //    BindDataAssociate(1);
            //}
        }
        //#endregion

        #region 【事件方法：异地交接班历史信息按条件查询】
        private void btnSecalAssociate_Click(object sender, EventArgs e)
        {
            //GetScaelSql();
            //BindDataAssociate(1);
        }
        #endregion

        #region 【事件方法：异地交接班历史查询信息重置】
        private void btnResetAssociate_Click(object sender, EventArgs e)
        {
            //ResetSceal();
            //GetScaelSql();
            //BindDataAssociate(1);
        }
        #endregion
        //#endregion
    }
}
