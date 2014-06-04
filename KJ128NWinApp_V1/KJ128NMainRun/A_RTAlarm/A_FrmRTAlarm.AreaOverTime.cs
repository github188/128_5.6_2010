using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;
using System.Windows.Forms;

namespace KJ128NMainRun.A_RTAlarm
{
    partial class A_FrmRTAlarm
    {
        private DBAcess dba = new DBAcess();

        private string strwhereall = " ";

        private void Refresh_EmpTerOverTime()
        {
            Select_EmpTerOverTime();
            loadterovertimetree();


        }
        private string strwhere()
        {
            string str = " ";
            if (TerOverTime_DeptTree.SelectedNode != null)
            {
                if (TerOverTime_DeptTree.SelectedNode.Name != "0")
                {
                    str += " and em.DeptID=" + TerOverTime_DeptTree.SelectedNode.Name;
                }
            }
            if (cmbAreaType.SelectedValue != null)
            {
                if (cmbAreaType.SelectedValue.ToString() != "0")
                {
                    str += " and rt.TerritorialTypeID=" + cmbAreaType.SelectedValue.ToString();
                }
            }
            if (cmbAreaName.ValueMember != null)
            {
                if (cmbAreaName.SelectedValue.ToString() != "0")
                {
                    str += " and rt.TerritorialID=" + cmbAreaName.SelectedValue.ToString();
                }
            }
            if (!txt_OverTimeTer_CodeSenderAddress.Text.Trim().Equals(""))
            {
                str += " and rt.CodeSenderAddress=" + txt_OverTimeTer_CodeSenderAddress.Text;
            }
            str += " and rt.EmpName like ('%" + txt_OverTimeTer_EmpName.Text + "%')";
            return str;
        }
        private void Select_EmpTerOverTime()
        {
            using (ds = new DataSet())
            {

                ds = rtabll.Select_EmpTerOverTime(strwhereall);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmRTAlarm_EmpTerOverTime";
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个报警记录";
                    //lblMainTitle.Text = "超时报警：  共 " + ds.Tables[1].Rows[0][0].ToString() + " 人";
                    if (dgv_Main.Columns.Count >= 7)
                    {
                        dgv_Main.Columns["标识卡"].DisplayIndex = 0;
                        dgv_Main.Columns["姓名"].DisplayIndex = 1;
                        dgv_Main.Columns["部门"].DisplayIndex = 2;
                        dgv_Main.Columns["职务"].DisplayIndex = 3;
                        dgv_Main.Columns["工种"].DisplayIndex = 4;
                        dgv_Main.Columns["区域名称"].DisplayIndex = 5;
                        dgv_Main.Columns["区域类型"].DisplayIndex = 6;
                        dgv_Main.Columns["开始时间"].DisplayIndex = 7;
                        dgv_Main.Columns["持续时长"].DisplayIndex = 8;
                    }

                    //dgv_Main.Columns["CerTypeID"].Visible = false;
                    dgv_Main.Columns["开始时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    
                }
                else
                {
                    dgv_Main.DataSource = null;
                    lblCounts.Text = "共 0 个报警记录";
                    //lblMainTitle.Text = "超时报警：  共 0 人";
                }
            }
        }
        private void loadterovertimetree()
        {
            TerOverTime_DeptTree.DataSouce = dba.GetDataSet("select 0 ID,'所有' Name,-1 ParentID,'False' IsChild,'True' IsUserNum,0 Num union all select t.DeptID ID,t.DeptName name,t.ParentDeptID ParentID, 'True' IsChild,'True' IsUserNum,(select count(distinct rt.CodeSenderAddress)  from dbo.RT_Terr_OverTime as rt left join dbo.CodeSender_Set as cs on rt.CodeSenderAddress=cs.CodeSenderAddress left join dbo.Emp_info as em on cs.UserID=em.EmpID left join dbo.Dept_Info as de on em.DeptID=de.DeptID where cs.CsTypeID=0 and em.DeptID=t.DeptID) Num from dbo.Dept_Info as t").Tables[0];
            TerOverTime_DeptTree.LoadNode("人");
            TerOverTime_DeptTree.ExpandAll();
        }
        private void bindcombox()
        {
            DataTable dt = dba.GetDataSet("select 0 ID,'所有' Name union select TerritorialTypeID ID,TypeName Name from Territorial_Type").Tables[0];
            cmbAreaType.DisplayMember = "Name";
            cmbAreaType.ValueMember = "ID";
            cmbAreaType.DataSource = dt;
            
            if (cmbAreaType.SelectedValue == null || cmbAreaType.SelectedValue.ToString() == "0")
            {
                cmbAreaName.DataSource = dba.GetDataSet("select 0 ID,'所有' Name union select TerritorialID ID, TerritorialName Name from dbo.Territorial_Info ").Tables[0];
                cmbAreaName.DisplayMember = "Name";
                cmbAreaName.ValueMember = "ID";
            }
            else
            {
                cmbAreaName.DataSource = dba.GetDataSet("select 0 ID,'所有' Name union select TerritorialID ID, TerritorialName Name from dbo.Territorial_Info where TerritorialTypeID="+cmbAreaType.SelectedValue.ToString()).Tables[0];
                cmbAreaName.DisplayMember = "Name";
                cmbAreaName.ValueMember = "ID";
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dmc_Info.ButtonClick(pl_TerOverTime.Name);
            this.AcceptButton = bt_OverTimeTer_Enquiries;
            bindcombox();
            tvc_EmpOverTime_Dept.Nodes.Clear();
            intSelectModel = 11;
            //刷新
            Refresh_EmpTerOverTime();
            tvc_EmpOverTime_Dept.ExpandAll();

            lblMainTitle.Text = "区域超时报警";

            this.btnPrint.Text = "打印";
            //刷新报警按钮
            SelctText(!IsAlarmFull[10]);
            

            IsShowRescue(false);
        }
        private void bt_OverTimeTer_Enquiries_Click(object sender, EventArgs e)
        {
            strwhereall = strwhere();
            Select_EmpTerOverTime();
        }
        private void bt_OverTimeTer_Reset_Click(object sender, EventArgs e)
        {
            cmbAreaName.SelectedIndex = 0;
            cmbAreaType.SelectedIndex = 0;
            txt_OverTimeTer_CodeSenderAddress.Text = "";
            txt_OverTimeTer_EmpName.Text = "";
            strwhereall = strwhere();
            Select_EmpTerOverTime();

        }
        private void TerOverTime_DeptTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strwhereall = strwhere();
            Select_EmpTerOverTime();
        }
        private void cmbAreaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAreaType.SelectedValue == null || cmbAreaType.SelectedValue.ToString() == "0")
            {
                cmbAreaName.DataSource = dba.GetDataSet("select 0 ID,'所有' Name union select TerritorialID ID, TerritorialName Name from dbo.Territorial_Info ").Tables[0];
                cmbAreaName.DisplayMember = "Name";
                cmbAreaName.ValueMember = "ID";
            }
            else
            {
                cmbAreaName.DataSource = dba.GetDataSet("select 0 ID,'所有' Name union select TerritorialID ID, TerritorialName Name from dbo.Territorial_Info where TerritorialTypeID=" + cmbAreaType.SelectedValue.ToString()).Tables[0];
                cmbAreaName.DisplayMember = "Name";
                cmbAreaName.ValueMember = "ID";
            }
        }
    }
}
