using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NDataBase;

namespace KJ128NMainRun.A_RT_OverSee
{
    public partial class A_RT_Station_Head : FromModel.FrmModel
    {
        private DataSet ds;

        KJ128NDBTable.A_RT_OverSee.A_Station_HeadBLL bll = new KJ128NDBTable.A_RT_OverSee.A_Station_HeadBLL();

        private A_TreeBLL tbll = new A_TreeBLL();

        int button3click;
        private string time1;
        public string _time1
        {
            get { return time1; }
            set{
                time1=value;
            }
        }
        private string time2;
        public string _time2
        {
            get { return time2; }
            set
            {
                time2 = value;
            }
        }

        public A_RT_Station_Head()
        {
            InitializeComponent();
            base.Text = "实时读卡分站";
            base.lblMainTitle.Hide();
            base.btnAdd.Hide();
            base.btnSelectAll.Hide();
            base.btnLaws.Hide();
            base.btnDelete.Hide();
            base.btnUpPage.Hide();
            base.lblPageCounts.Hide();
            base.lblSumPage.Hide();
            base.btnDownPage.Hide();
            base.label6.Hide();
            base.txtSkipPage.Hide();
            base.label7.Hide();
            base.label8.Hide();
            base.cmbSelectCounts.Hide();
            base.label9.Hide();
            button3.Hide();
            timer1.Interval= KJ128NInterfaceShow.RefReshTime._rtTime;
            //bindcombox();
            dataGridView1.DataSource = bll.A_RT_Station_Head("1=1", 1);
            lblCounts.Text = "符合筛选条件：共 " + bll.A_RT_Station_Head_count("1=1", 1) + " 人";
            loadTree();
        }
        #region[方法：查询字符串]
        private string StrWhere()
        {
            //string str = " 1 = 1 ";
            //if (radioemp.Checked)       //人员
            //{
            //    if (!codetextBox.Text.Trim().Equals(""))
            //    {
            //        str += " And Si.StationAddress=" + sendtextBox.Text.Trim();
            //    }
            //    if (!sendtextBox.Text.Trim().Equals(""))
            //    {
            //        str += " And Ei.EmpName like ('%" + nametextBox.Text.Trim() + "%')";
            //    }
            //}
            //else                        //设备
            //{
            //    if (!codetextBox.Text.Trim().Equals(""))
            //    {
            //        str += " And Si.StationHeadAddress=" + sendtextBox.Text.Trim();
            //    }
            //    if (!sendtextBox.Text.Trim().Equals(""))
            //    {
            //        str += " And Ei.EmpName like ('%" + nametextBox.Text.Trim() + "%')";
            //    }
            //}

            string str = "";
            if (radioemp.Checked)
            {
                if (codetextBox.Text == "")
                {
                    if (sendtextBox.Text == "")
                    {
                        if (readtextBox.Text == "")
                        {
                            str = "Ei.EmpName like ('%" + nametextBox.Text.Trim() + "%')";
                        }
                        else
                        {
                            str = "Si.StationHeadAddress=" + readtextBox.Text + " and Ei.EmpName like '%" + nametextBox.Text.Trim() + "%'";
                        }
                    }
                    else
                    {
                        if (readtextBox.Text == "")
                        {
                            str = "Si.StationAddress=" + sendtextBox.Text + " and Ei.EmpName like '%" + nametextBox.Text.Trim() + "%'";
                        }
                        else
                        {
                            str = "Si.StationAddress=" + sendtextBox.Text + " and  Si.StationHeadAddress=" + readtextBox.Text + " and Ei.EmpName like '%" + nametextBox.Text.Trim() + "%'";
                        }
                    }
                }
                else
                {
                    if (sendtextBox.Text == "")
                    {
                        if (readtextBox.Text == "")
                        {
                            str = "Ri.CodeSenderAddress=" + codetextBox.Text + " and Ei.EmpName like '%" + nametextBox.Text.Trim() + "%'";
                        }
                        else
                        {
                            str = "Ri.CodeSenderAddress=" + codetextBox.Text + " and Si.StationHeadAddress=" + readtextBox.Text + " and Ei.EmpName like '%" + nametextBox.Text.Trim() + "%'";
                        }
                    }
                    else
                    {
                        if (readtextBox.Text == "")
                        {
                            str = "Ri.CodeSenderAddress=" + codetextBox.Text + " and Si.StationAddress=" + sendtextBox.Text + " and Ei.EmpName like '%" + nametextBox.Text.Trim() + "%'";
                        }
                        else
                        {
                            str = "Ri.CodeSenderAddress=" + codetextBox.Text + " and Si.StationAddress=" + sendtextBox.Text + " and  Si.StationHeadAddress=" + readtextBox.Text + " and Ei.EmpName like '%" + nametextBox.Text.Trim() + "%'";
                        }
                    }
                }

            }
            if (radioeqe.Checked)
            {
                if (codetextBox.Text == "")
                {
                    if (sendtextBox.Text == "")
                    {
                        if (readtextBox.Text == "")
                        {
                            str = "Eb.EquName like '%" + nametextBox.Text.Trim() + "%'";
                        }
                        else
                        {
                            str = "Si.StationHeadAddress=" + readtextBox.Text + " and Eb.EquName like '%" + nametextBox.Text.Trim() + "%'";
                        }
                    }
                    else
                    {
                        if (readtextBox.Text == "")
                        {
                            str = "Si.StationAddress=" + sendtextBox.Text + " and Eb.EquName like '%" + nametextBox.Text.Trim() + "%'";
                        }
                        else
                        {
                            str = "Si.StationAddress=" + sendtextBox.Text + " and  Si.StationHeadAddress=" + readtextBox.Text + " and Eb.EquName like '%" + nametextBox.Text.Trim() + "%'";
                        }
                    }
                }
                else
                {
                    if (sendtextBox.Text == "")
                    {
                        if (readtextBox.Text == "")
                        {
                            str = "Ri.CodeSenderAddress=" + codetextBox.Text + " and Eb.EquName like '%" + nametextBox.Text.Trim() + "%'";
                        }
                        else
                        {
                            str = "Ri.CodeSenderAddress=" + codetextBox.Text + " and Si.StationHeadAddress=" + readtextBox.Text + " and Eb.EquName like '%" + nametextBox.Text.Trim() + "%'";
                        }
                    }
                    else
                    {
                        if (readtextBox.Text == "")
                        {
                            str = "Ri.CodeSenderAddress=" + codetextBox.Text + " and Si.StationAddress=" + sendtextBox.Text + " and Eb.EquName like '%" + nametextBox.Text.Trim() + "%'";
                        }
                        else
                        {
                            str = "Ri.CodeSenderAddress=" + codetextBox.Text + " and Si.StationAddress=" + sendtextBox.Text + " and  Si.StationHeadAddress=" + readtextBox.Text + " and Eb.EquName like '%" + nametextBox.Text.Trim() + "%'";
                        }
                    }
                }
            }
            return str;
        }
        #endregion
        private void loadTree()
        {
            if (radioemp.Checked)
            {
                //treeViewControl1.Nodes.Clear();
                using (ds = new DataSet())
                {
                    ds = bll.A_RT_Dept_Tree(0);

                    tbll.AddTreeRoot(treeViewControl1, ds, "所有", "人");

                    //if (ds != null && ds.Tables.Count > 0)
                    //{
                    //    treeViewControl1.DataSouce = ds.Tables[0];
                    //    treeViewControl1.LoadNode("人");
                    //}
                }
                
            }
            if (radioeqe.Checked)
            {
                //treeViewControl1.Nodes.Clear();
                using (ds = new DataSet())
                {
                    ds = bll.A_RT_Dept_Tree(1);
                    tbll.AddTreeRoot(treeViewControl1, ds, "所有", "台");
                    //if (ds != null && ds.Tables.Count > 0)
                    //{
                    //    treeViewControl1.DataSouce = ds.Tables[0];
                    //    treeViewControl1.LoadNode("台");
                    //}
                }
            }
            //treeViewControl1.ExpandAll();

        }
        //private void bindcombox()
        //{
        //    comboBox1.DataSource = bll.A_exSQL("select distinct DeptName from dbo.Dept_Info");
        //    comboBox1.DisplayMember = "DeptName";

        //}
        private void loaddatagridview(string sr)
        {
            if (radioemp.Checked)
            {
                if (treeViewControl1.SelectedNode == null)
                {
                    
                    dataGridView1.DataSource = bll.A_RT_Station_Head("1=1", 1);
                    lblCounts.Text = "符合筛选条件：共 " + bll.A_RT_Station_Head_count("1=1", 1) + " 人";
                }
                else
                {
                    if (treeViewControl1.SelectedNode.Name == "0")
                    {
                        dataGridView1.DataSource = bll.A_RT_Station_Head("1=1", 1);
                        lblCounts.Text = "符合筛选条件：共 " + bll.A_RT_Station_Head_count("1=1", 1) + " 人";
                    }
                    dataGridView1.DataSource = bll.A_RT_Station_Head(sr, 1);
                    lblCounts.Text = "符合筛选条件：共 " + bll.A_RT_Station_Head_count(sr, 1) + " 人";
                }
            }
            if (radioeqe.Checked)
            {
                if (treeViewControl1.SelectedNode == null)
                {
                    dataGridView1.DataSource = bll.A_RT_Station_Head("1=1", 0);
                    lblCounts.Text = "符合筛选条件：共 " + bll.A_RT_Station_Head_count("1=1", 0) + " 台";
                }
                else
                {
                    dataGridView1.DataSource = bll.A_RT_Station_Head(sr, 0);
                    lblCounts.Text = "符合筛选条件：共 " + bll.A_RT_Station_Head_count(sr, 0) + " 台";

                }
            }
        }
        private void radioemp_Click(object sender, EventArgs e)
        {
            label2.Text = "姓  名：";
        }

        private void radioeqe_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "设  备：";
            loadTree();

            if (radioemp.Checked)
            {
                string strsql = "";
                if (treeViewControl1.SelectedNode != null)
                {
                    if (treeViewControl1.SelectedNode.Name != "0")
                    {
                        strsql = StrWhere() + " and Di.DeptID=" + treeViewControl1.SelectedNode.Name;
                    }
                    else
                    {
                        strsql = StrWhere();
                    }
                }
                else
                {
                    strsql = StrWhere();
                }
                dataGridView1.DataSource = bll.A_RT_Station_Head(strsql, 1);
                lblCounts.Text = "符合筛选条件：共 " + bll.A_RT_Station_Head_count(strsql, 1) + " 人";
            }
            if (radioeqe.Checked)
            {
                string strsql = "";
                if (treeViewControl1.SelectedNode != null)
                {
                    if (treeViewControl1.SelectedNode.Name != "0")
                    {
                        strsql = StrWhere() + " and Di.DeptID=" + treeViewControl1.SelectedNode.Name;
                    }
                    else
                    {
                        strsql = StrWhere();
                    }
                }
                else
                {
                    strsql = StrWhere();
                }
                dataGridView1.DataSource = bll.A_RT_Station_Head(strsql, 0);
                lblCounts.Text = "符合筛选条件：共 " + bll.A_RT_Station_Head_count(strsql, 0) + " 台";
            }


        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = true;

        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            //treeViewControl1.Hide();
            loadTree();
            //treeViewControl1.Show();
            if (treeViewControl1.SelectedNode != null)
            {
                loaddatagridview(" Di.DeptID=" + treeViewControl1.SelectedNode.Name);
            }
            else
            {
                loaddatagridview("1=1");
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            codetextBox.Text = "";
            sendtextBox.Text = "";
            readtextBox.Text = "";
            nametextBox.Text = "";
            button1_Click(null, null);
        }

        #region【方法：获取查询条件】

        //private string GetStrWhere_Emp()
        //{
        //    string strWhere = "1=1";
        //    if (treeViewControl1.SelectedNode != null)
        //    {

        //    }
        //}

        #endregion

        #region【方法：查询——人员】

        private void Select_Emp()
        {

        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                    if (radioemp.Checked)
                    {
                        string strsql = "";
                        if (treeViewControl1.SelectedNode != null)
                        {
                            if (treeViewControl1.SelectedNode.Name != "0")
                            {
                                strsql = StrWhere() + " and Di.DeptID=" + treeViewControl1.SelectedNode.Name;
                            }
                            else
                            {
                                strsql = StrWhere();
                            }
                        }
                        else
                        {
                            strsql = StrWhere();
                        }
                        dataGridView1.DataSource = bll.A_RT_Station_Head(strsql, 1);
                        lblCounts.Text = "符合筛选条件：共 " + bll.A_RT_Station_Head_count(strsql, 1) + " 人";
                    }
                    if (radioeqe.Checked)
                    {
                        string strsql = "";
                        if (treeViewControl1.SelectedNode != null)
                        {
                            if (treeViewControl1.SelectedNode.Name != "0")
                            {
                                strsql = StrWhere() + " and Di.DeptID=" + treeViewControl1.SelectedNode.Name;
                            }
                            else
                            {
                                strsql = StrWhere();
                            }
                        }
                        else
                        {
                            strsql = StrWhere();
                        }
                        dataGridView1.DataSource = bll.A_RT_Station_Head(strsql, 0);
                        lblCounts.Text = "符合筛选条件：共 " + bll.A_RT_Station_Head_count(strsql, 0) + " 台";
                    }
                    

                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                button3click = 1;
                A_RT_Time_Set st = new A_RT_Time_Set();
                DialogResult dr = st.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    button3.AccessibleDefaultActionDescription = StrWhere() + " And Ri.InStationHeadTime >= '" + time1 + "' And Ri.InStationHeadTime <= '" + time2 + "' ";
                }
                else
                {
                    button3.AccessibleDefaultActionDescription = StrWhere();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dataGridView1, "实时读卡分站");
        }

        private void treeViewControl1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (radioemp.Checked)
            {
                string strsql = "";
                if (treeViewControl1.SelectedNode != null)
                {
                    if (treeViewControl1.SelectedNode.Name != "0")
                    {
                        strsql = StrWhere() + " and Di.DeptID=" + treeViewControl1.SelectedNode.Name;
                    }
                    else
                    {
                        strsql = StrWhere();
                    }
                }
                else
                {
                    strsql = StrWhere();
                }
                dataGridView1.DataSource = bll.A_RT_Station_Head(strsql, 1);
                lblCounts.Text = "符合筛选条件：共 " + bll.A_RT_Station_Head_count(strsql, 1) + " 人";
            }
            if (radioeqe.Checked)
            {
                string strsql = "";
                if (treeViewControl1.SelectedNode != null)
                {
                    if (treeViewControl1.SelectedNode.Name != "0")
                    {
                        strsql = StrWhere() + " and Di.DeptID=" + treeViewControl1.SelectedNode.Name;
                    }
                    else
                    {
                        strsql = StrWhere();
                    }
                }
                else
                {
                    strsql = StrWhere();
                }
                dataGridView1.DataSource = bll.A_RT_Station_Head(strsql, 0);
                lblCounts.Text = "符合筛选条件：共 " + bll.A_RT_Station_Head_count(strsql, 0) + " 台";
            }
        }

        private void nametextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

       


        



       
    }
}
