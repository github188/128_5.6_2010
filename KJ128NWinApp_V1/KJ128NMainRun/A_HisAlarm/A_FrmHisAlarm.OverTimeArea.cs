using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using KJ128NDataBase;

namespace KJ128NMainRun.A_HisAlarm
{
    partial class A_FrmHisAlarm
    {
        private DBAcess dba = new DBAcess();
        private void loadterovertimetree()
        {
            tvc_TerOverTime_Dept.DataSouce = dba.GetDataSet("select 0 ID,'所有' Name,-1 ParentID,'false' IsChild,'false' IsUserNum,0 Num union select t.DeptID ID,t.DeptName name,t.ParentDeptID ParentID, 'true' IsChild,'false' IsUserNum, 0 Num from dbo.Dept_Info as t").Tables[0];
            tvc_TerOverTime_Dept.LoadNode("");
            tvc_TerOverTime_Dept.ExpandAll();
        }

        private string strWhere()
        {
            string str = "  姓名 like ('%" + txt_TerOverTime_EmpName.Text + "%')  And 开始时间 >= '" + dtp_TerOverTime_Begin.Value.ToString() +
                "' And 开始时间 <='" + dtp_TerOverTime_End.Value.ToString() + "' ";
            if (tvc_TerOverTime_Dept.SelectedNode != null)
            {
                if (tvc_TerOverTime_Dept.SelectedNode.Name != "0")
                {
                    str += " and deid=" + tvc_TerOverTime_Dept.SelectedNode.Name;
                }
            }
            if (cmbAreaType.SelectedValue != null)
            {
                if (cmbAreaType.SelectedValue.ToString() != "0")
                {
                    str += " and 区域类型='" + cmbAreaType.Text + "'";
                }
            }
            if (cmbAreaName.SelectedValue != null)
            {
                if (cmbAreaName.SelectedValue.ToString() != "0")
                {
                    str += " and tid=" + cmbAreaName.SelectedValue.ToString();
                }
            }
            if (!txt_TerOverTime_CodeSenderAddress.Text.Trim().Equals(""))
            {
                str += " and 标识卡=" + txt_TerOverTime_CodeSenderAddress.Text;
            }
 
            return str;
            

        }

        private void SelectInfo_AreaOverTime(int pIndex)
        {
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }
            string str=strWhere();
            DataSet ds = rtabll.GetHisTerOverTime(pIndex, pSize, str);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                if (sumPage == 0)
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    //lblMainTitle.Text = "历史区域超时报警：  共 0 人";
                    lblCounts.Text = "共 0 条记录";

                    lblPageCounts.Text = "1";
                    lblSumPage.Text = "/1页";

                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    //lblMainTitle.Text = "历史区域超时报警：  共 " + ds.Tables[2].Rows[0][0].ToString() + " 人";
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

                    dgv_Main.Columns["id"].Visible = false;
                    dgv_Main.Columns["deid"].Visible = false;
                    dgv_Main.Columns["tid"].Visible = false;

                    dgv_Main.Columns["标识卡"].DisplayIndex = 0;
                    dgv_Main.Columns["姓名"].DisplayIndex = 1;
                    dgv_Main.Columns["部门"].DisplayIndex = 2;
                    dgv_Main.Columns["职务"].DisplayIndex = 3;
                    dgv_Main.Columns["工种"].DisplayIndex = 4;
                    dgv_Main.Columns["区域名称"].DisplayIndex = 5;
                    dgv_Main.Columns["区域类型"].DisplayIndex = 6;
                    dgv_Main.Columns["开始时间"].DisplayIndex = 7;
                    dgv_Main.Columns["结束时间"].DisplayIndex = 8;
                    dgv_Main.Columns["持续时长"].DisplayIndex = 9;

                    dgv_Main.Columns["职务"].DefaultCellStyle.NullValue = "——";
                    dgv_Main.Columns["工种"].DefaultCellStyle.NullValue = "——";
                }
            }
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
                cmbAreaName.DataSource = dba.GetDataSet("select 0 ID,'所有' Name union select TerritorialID ID, TerritorialName Name from dbo.Territorial_Info where TerritorialTypeID=" + cmbAreaType.SelectedValue.ToString()).Tables[0];
                cmbAreaName.DisplayMember = "Name";
                cmbAreaName.ValueMember = "ID";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 12)
            {
                dmc_Info.ButtonClick(pl_AreaOverTime.Name);
                this.AcceptButton = button2;
                dtp_TerOverTime_Begin.Value = DateTime.Parse( DateTime.Today.ToString("yyyy-MM-dd 00:00:00"));
                dtp_TerOverTime_End.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                lblMainTitle.Text = "历史区域超时报警";
                intSelectModel = 12;

                tvc_TerOverTime_Dept.Nodes.Clear();
                loadterovertimetree();    //加载部门树——历史超时
                bindcombox();
                //查询
                //SelectInfo_AreaOverTime(1);
                dgv_Main.DataSource = null;
            }
        }


        private void tvc_TerOverTime_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!DecideTime(dtp_TerOverTime_Begin, dtp_TerOverTime_End))
            {
                return;
            }
            SelectInfo_AreaOverTime(1);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (!DecideTime(dtp_TerOverTime_Begin, dtp_TerOverTime_End))
            {
                return;
            }
            SelectInfo_AreaOverTime(1);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            dtp_TerOverTime_Begin.Value = DateTime.Parse(DateTime.Today.ToString("yyyy-MM-dd 00:00:00"));
            dtp_TerOverTime_End.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            txt_TerOverTime_CodeSenderAddress.Text = "";
            txt_TerOverTime_EmpName.Text = "";
            cmbAreaName.SelectedIndex = 0;
            cmbAreaType.SelectedIndex = 0;
            dgv_Main.DataSource = null;
            //SelectInfo_AreaOverTime(1);
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
