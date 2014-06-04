using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NMainRun.SetCoder
{
    public partial class A_FrmSetCodeSender : Wilson.Controls.Docking.DockContent
    {

        private A_CodeSenderBLL codebll = new A_CodeSenderBLL();

        private List<EmpMacCodeSender> list=new List<EmpMacCodeSender>();

        private List<string> ExitsEmpIdlist = new List<string>();

        private int pagecount = 0;

        private bool isCodeSenderSet = true;

        public A_FrmSetCodeSender()
        {
            InitializeComponent();
        }

        private void A_FrmSetCodeSender_Load(object sender, EventArgs e)
        {
            cmb_SelectCounts.SelectedIndex = 0;
            LoadTrvDept();
            //drawerMainControl1.Add();
            //drawerMainControl1.LeftPartResize()
            dmcPnl.Add(pnl1, true);
            dmcPnl.Add(pnl2);
            dmcPnl.LeftPartResize();
        }
        /// <summary>
        /// 载入部门树
        /// </summary>
        private void LoadTrvDept()
        {
            DataTable depttable = codebll.GetDeptInfo();
            trvDept.Nodes.Add("0", "所有");
            AddTreeNode(depttable, trvDept.Nodes[0]);
            trvPdept.Nodes.Add("0", "所有");
            AddTreeNode(depttable, trvPdept.Nodes[0]);
        }
        /// <summary>
        /// 递归载入部门树
        /// </summary>
        /// <param name="dt">部门表</param>
        /// <param name="node">当前节点</param>
        private void AddTreeNode(DataTable dt,TreeNode node)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["parentdeptid"].ToString() == node.Name)
                {
                    TreeNode childnode = new TreeNode(dt.Rows[i]["deptname"].ToString());
                    childnode.Name=dt.Rows[i]["deptid"].ToString();
                    node.Nodes.Add(childnode);
                    AddTreeNode(dt,childnode);
                }
            }
        }
        /// <summary>
        /// 点击部门树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvDept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //string type = "";
            //if (rdbEmp.Checked)
            //    type = rdbEmp.Text;
            //else
            //    type = rdbMch.Text;
            //int rowcount = 0;
            //DataTable codesenderdt = codebll.GetCodeSenderSet(trvDept.SelectedNode.Text, type, Convert.ToInt32(cmb_SelectCounts.SelectedItem), 1, out pagecount, out rowcount);
            //dgvCodeSenderSet.DataSource = codesenderdt;
            //this.lb_SumPage.Text = "/"+pagecount.ToString()+"页";
        }
        /// <summary>
        /// 下一页按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_UpPage_Click(object sender, EventArgs e)
        {
            if (isCodeSenderSet)
            {
                string type = "";
                if (rdbEmp.Checked)
                    type = rdbEmp.Text;
                else
                    type = rdbMch.Text;
                if (int.Parse(this.lb_PageCounts.Text) > 1)
                {
                    //lb_PageCounts.Text = Convert.ToString(int.Parse(lb_PageCounts.Text) - 1);
                    //DataTable codesenderdt = codebll.GetCodeSenderSet(trvDept.SelectedNode.Text, type, Convert.ToInt32(cmb_SelectCounts.SelectedItem), int.Parse(this.lb_PageCounts.Text), out pagecount);
                    //dgvCodeSenderSet.DataSource = codesenderdt;
                }
            }
            else
            {
                int num = 0;
                if (trvCodesender.SelectedNode.Text == "所有")
                {
                    num = 0;
                }
                if (trvCodesender.SelectedNode.Text == "配置")
                {
                    num = 1;
                }
                if (trvCodesender.SelectedNode.Text == "未配置")
                {
                    num = 2;
                }
                if (int.Parse(this.lb_PageCounts.Text) > 1)
                {
                    //lb_PageCounts.Text = Convert.ToString(int.Parse(lb_PageCounts.Text) - 1);
                    //DataTable codesenderdt = codebll.GetCodeSenderByUse(num, Convert.ToInt32(cmb_SelectCounts.SelectedItem), int.Parse(this.lb_PageCounts.Text), out pagecount);
                    //dgvCodeSenderSet.DataSource = codesenderdt;
                    ////this.lb_SumPage.Text = "/" + pagecount.ToString() + "页";
                }
            }
        }
        /// <summary>
        /// 上一页按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_DownPage_Click(object sender, EventArgs e)
        {
            if (isCodeSenderSet)
            {
                string type = "";
                if (rdbEmp.Checked)
                    type = rdbEmp.Text;
                else
                    type = rdbMch.Text;
                if (int.Parse(this.lb_PageCounts.Text) < pagecount)
                {
                    //lb_PageCounts.Text = Convert.ToString(int.Parse(lb_PageCounts.Text) + 1);
                    //DataTable codesenderdt = codebll.GetCodeSenderSet(trvDept.SelectedNode.Text, type, Convert.ToInt32(cmb_SelectCounts.SelectedItem), int.Parse(this.lb_PageCounts.Text), out pagecount);
                    //dgvCodeSenderSet.DataSource = codesenderdt;
                }
            }
            else
            {
                int num = 0;
                if (trvCodesender.SelectedNode.Text == "所有")
                {
                    num = 0;
                }
                if (trvCodesender.SelectedNode.Text == "配置")
                {
                    num = 1;
                }
                if (trvCodesender.SelectedNode.Text == "未配置")
                {
                    num = 2;
                }
                //if (int.Parse(this.lb_PageCounts.Text) < pagecount)
                //{
                //    lb_PageCounts.Text = Convert.ToString(int.Parse(lb_PageCounts.Text) + 1);
                //    DataTable codesenderdt = codebll.GetCodeSenderByUse(num, Convert.ToInt32(cmb_SelectCounts.SelectedItem), int.Parse(this.lb_PageCounts.Text), out pagecount);
                //    dgvCodeSenderSet.DataSource = codesenderdt;
                //    //this.lb_SumPage.Text = "/" + pagecount.ToString() + "页";
                //}
            }
        }

        /// <summary>
        /// 重新设定页显示数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_SelectCounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string type = "";
            //if (rdbEmp.Checked)
            //    type = rdbEmp.Text;
            //else
            //    type = rdbMch.Text;
            //try
            //{
            //    if (isCodeSenderSet)
            //    {
            //        //DataTable codesenderdt = codebll.GetCodeSenderSet(trvDept.SelectedNode.Text, type, Convert.ToInt32(cmb_SelectCounts.SelectedItem), 1, out pagecount);
            //        //dgvCodeSenderSet.DataSource = codesenderdt;
            //        //this.lb_PageCounts.Text = "1";
            //        //this.lb_SumPage.Text = "/" + pagecount.ToString() + "页";
            //    }
            //    else
            //    {
            //        int num = 0;
            //        if (trvCodesender.SelectedNode.Text == "所有")
            //        {
            //            num = 0;
            //        }
            //        if (trvCodesender.SelectedNode.Text == "配置")
            //        {
            //            num = 1;
            //        }
            //        if (trvCodesender.SelectedNode.Text == "未配置")
            //        {
            //            num = 2;
            //        }
            //        DataTable codesenderdt = codebll.GetCodeSenderByUse(num, Convert.ToInt32(cmb_SelectCounts.SelectedItem), 1, out pagecount);
            //        dgvCodeSenderSet.DataSource = codesenderdt;
            //        this.lb_PageCounts.Text = "1";
            //        this.lb_SumPage.Text = "/" + pagecount.ToString() + "页";
            //    }
            //}
            //catch (Exception ex)
            //{ 
                
            //}
        }
        /// <summary>
        /// 跳转到指定页数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_SkipPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            //string type = "";
            //if (rdbEmp.Checked)
            //    type = rdbEmp.Text;
            //else
            //    type = rdbMch.Text;
            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    try
            //    {
            //        if (isCodeSenderSet)
            //        {
            //            DataTable codesenderdt = codebll.GetCodeSenderSet(trvDept.SelectedNode.Text, type, Convert.ToInt32(cmb_SelectCounts.SelectedItem), int.Parse(txt_SkipPage.Text), out pagecount);
            //            lb_PageCounts.Text = txt_SkipPage.Text;
            //            if (codesenderdt.Rows.Count > 0)
            //            {
            //                dgvCodeSenderSet.DataSource = codesenderdt;
            //            }
            //        }
            //        else
            //        {
            //            int num = 0;
            //            if (trvCodesender.SelectedNode.Text == "所有")
            //            {
            //                num = 0;
            //            }
            //            if (trvCodesender.SelectedNode.Text == "配置")
            //            {
            //                num = 1;
            //            }
            //            if (trvCodesender.SelectedNode.Text == "未配置")
            //            {
            //                num = 2;
            //            }
            //            DataTable codesenderdt = codebll.GetCodeSenderByUse(num, Convert.ToInt32(cmb_SelectCounts.SelectedItem), 1, out pagecount);
            //            lb_PageCounts.Text = txt_SkipPage.Text;
            //            dgvCodeSenderSet.DataSource = codesenderdt;
            //            this.lb_SumPage.Text = "/" + pagecount.ToString() + "页";
            //        }
            //    }
            //    catch (Exception ex)
            //    { }
            //}
            //else
            //{
            //    try
            //    {
            //        int indexpage = int.Parse(txt_SkipPage.Text + e.KeyChar.ToString());
            //        if (indexpage > pagecount)
            //        {
            //            e.Handled = true;
            //            this.txt_SkipPage.Text = pagecount.ToString();
            //        }
            //    }
            //    catch (Exception ex)
            //    { }
            //}
        }
        /// <summary>
        /// 重置查询条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReSet_Click(object sender, EventArgs e)
        {
            this.txtCodeSender.Text = "";
        }
        /// <summary>
        /// 按指定条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if (txtCodeSender.Text == "")
            //{
            //    MessageBox.Show("标识卡尚未填写...", "提示", MessageBoxButtons.OK);
            //}
            //else
            //{
            //    trvDept.SelectedNode = null;
            //    string type="";
            //    if (rdbEmp.Checked)
            //        type = rdbEmp.Text;
            //    else
            //        type = rdbMch.Text;
            //    DataTable codesenderdt = codebll.GetCodeSenderSetByCode(txtCodeSender.Text, type, Convert.ToInt32(cmb_SelectCounts.SelectedItem), 1, out pagecount);
            //    dgvCodeSenderSet.DataSource = codesenderdt;
            //}
        }
        /// <summary>
        /// 全选按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_SelectAll_Click(object sender, EventArgs e)
        {
        //    if (bt_SelectAll.Text == "全选")
        //    {
        //        for (int i = 0; i < dgvCodeSenderSet.Rows.Count; i++)
        //        {
        //            ((DataGridViewCheckBoxCell)dgvCodeSenderSet.Rows[i].Cells[0]).Value = ((DataGridViewCheckBoxCell)dgvCodeSenderSet.Rows[i].Cells[0]).TrueValue;
        //        }
        //        bt_SelectAll.Text = "取消";
        //    }
        //    else
        //    {
        //        for (int i = 0; i < dgvCodeSenderSet.Rows.Count; i++)
        //        {
        //            ((DataGridViewCheckBoxCell)dgvCodeSenderSet.Rows[i].Cells[0]).Value = ((DataGridViewCheckBoxCell)dgvCodeSenderSet.Rows[i].Cells[0]).FalseValue;
        //        }
        //        bt_SelectAll.Text = "全选";
        //    }
        }

        /// <summary>
        /// 删除选中的项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Delete_Click(object sender, EventArgs e)
        {
            //for (int i = (dgvCodeSenderSet.Rows.Count-1); i >= 0; i--)
            //{
            //    if (((DataGridViewCheckBoxCell)dgvCodeSenderSet.Rows[i].Cells[0]).Value == ((DataGridViewCheckBoxCell)dgvCodeSenderSet.Rows[i].Cells[0]).TrueValue)
            //    {
            //        string codeaddress = dgvCodeSenderSet.Rows[i].Cells[1].Value.ToString();
            //        if (codebll.DeleteCodeSenderSet(codeaddress) > 0)
            //        {
            //            dgvCodeSenderSet.Rows.RemoveAt(i);
            //        }
            //    }
            //}
            //bt_SelectAll.Text = "全选";
        }

        /// <summary>
        /// 将已经经过匹配的人员或设备从指定的DT里面删除
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable RemoveExitsEmpMac(DataTable dt)
        {
            //if (list.Count > 0)
            //{
            //    for (int i = (dt.Rows.Count - 1); i >= 0; i--)
            //    {
            //        string empid = dt.Rows[i]["empid"].ToString();
            //        if (ExitsEmpIdlist.Contains(empid))
            //        {
            //            dt.Rows.RemoveAt(i);
            //        }
            //    }
            //    return dt;
            //}
            //else
            //{
            //    return dt;
            //}
            return null;
        }
        /// <summary>
        /// 匹配面板中部门树单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvPdept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //txtName.Text = "";
            //lsbEmpMac.Items.Clear();
            //lsbEmpMac.Values.Clear();
            //string type;
            //if (rbtEmp.Checked)
            //{
            //    type = "人员";
            //}
            //else
            //{
            //    type = "设备";
            //}
            //if (trvPdept.SelectedNode != null)
            //{
            //    DataTable empmacdt = codebll.GetLastEmpByDept(trvPdept.SelectedNode.Name, type);
            //    empmacdt = RemoveExitsEmpMac(empmacdt);
            //    for (int i = 0; i < empmacdt.Rows.Count; i++)
            //    {
            //        lsbEmpMac.AddItem(empmacdt.Rows[i][1].ToString(), empmacdt.Rows[i][0].ToString());
            //    }
            //}
        }
        /// <summary>
        /// 人员单选框变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtEmp_CheckedChanged(object sender, EventArgs e)
        {
            trvPdept.SelectedNode = null;
        }

        /// <summary>
        /// 添加匹配项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Add_Click(object sender, EventArgs e)
        {
            if (isCodeSenderSet)
            {
                pnlCodeSenderSet.Visible = true;
                lsbCodeSender.Items.Clear();
                DataTable dt = codebll.GetLastCodesender();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lsbCodeSender.Items.Add(dt.Rows[i][0].ToString());
                }
            }
            else
            {
                pnlCode.Visible = true;
            }
        }
        /// <summary>
        /// 返回按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            lsbEmpMac.Items.Clear();
            lsbEmpMac.Values.Clear();
            txtName.Text = "";
            list.Clear();
            ExitsEmpIdlist.Clear();
            dgvSet.DataSource = new DataTable();
            trvPdept.SelectedNode = null;
            labMessage.Visible = false;
            labOut.Visible = false;
            pnlCodeSenderSet.Visible = false;
        }
        /// <summary>
        /// 查询未匹配的人员或设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPsearch_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("名称尚未填写...", "提示", MessageBoxButtons.OK);
            }
            else
            {
                string type;
                if (rbtEmp.Checked)
                {
                    type = "人员";
                }
                else
                {
                    type = "设备";
                }
                DataTable empmacdt = codebll.GetLastEmpByName(txtName.Text, type);
                lsbEmpMac.Items.Clear();
                lsbEmpMac.Values.Clear();
                for (int i = 0; i < empmacdt.Rows.Count; i++)
                {
                    lsbEmpMac.AddItem(empmacdt.Rows[i][1].ToString(), empmacdt.Rows[i][0].ToString());
                }
            }
        }
        /// <summary>
        /// 匹配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPP_Click(object sender, EventArgs e)
        {
            if (lsbEmpMac.SelectedItems.Count > 0 && lsbCodeSender.SelectedItems.Count > 0)
            {
                int num = 0;
                if (lsbEmpMac.SelectedItems.Count < lsbCodeSender.SelectedItems.Count)
                {
                    num = lsbEmpMac.SelectedItems.Count;
                }
                else
                {
                    num = lsbCodeSender.SelectedItems.Count;
                }
                for (int i = (num-1); i >=0; i--)
                {
                    string name = lsbEmpMac.SelectedItems[i].ToString();
                    string empid = lsbEmpMac.Values[lsbEmpMac.Items.IndexOf(name)];
                    string codesender = lsbCodeSender.SelectedItems[i].ToString();
                    string type;
                    if (rbtEmp.Checked)
                        type = "0";
                    else
                        type = "1";
                    EmpMacCodeSender emcs = new EmpMacCodeSender(empid, name, codesender,type);
                    list.Insert(0, emcs);
                    ExitsEmpIdlist.Add(empid);
                    int index = lsbEmpMac.Values.IndexOf(empid);
                    lsbEmpMac.Items.RemoveAt(index);
                    lsbEmpMac.Values.RemoveAt(index);
                    lsbCodeSender.Items.Remove(codesender);
                }
                dgvSet.DataSource = list;
            }
            else
            {
                MessageBox.Show("人员设备或标识卡尚未选择...", "提示", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            list.Clear();
            ExitsEmpIdlist.Clear();
            dgvSet.DataSource = new DataTable();
            bt_Add_Click(this, new EventArgs());
            trvPdept_AfterSelect(this, new TreeViewEventArgs(trvPdept.SelectedNode));
            this.labOut.Visible = false;
            this.labMessage.Visible = false;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (list.Count > 0)
            {
                bool flag=true;
                
                for (int i = 0; i < list.Count; i++)
                {
                    string type;
                    if (list[i].类型.Equals("人员"))
                        type = "0";
                    else
                        type = "1";
                    if (!(codebll.InsertIntoCodesenderSet(list[i].标识卡, list[i].GetEmpID(), type) > 0))
                        flag = false;
                }
                if (!flag)
                {
                    labMessage.Text = "保存过程中发生错误...";
                    labOut.Visible = true;
                    labMessage.Visible = true;
                }
                else
                {
                    labMessage.Text = "保存成功";
                    labOut.Visible = true;
                    labMessage.Visible = true;
                }
            }
        }
        /// <summary>
        /// 双击匹配预览中的项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ExitsEmpIdlist.Remove(list[e.RowIndex].GetEmpID());
            list.RemoveAt(e.RowIndex);
            dgvSet.DataSource = new DataTable();
            dgvSet.DataSource = list;
            bt_Add_Click(this, new EventArgs());
            trvPdept_AfterSelect(this, new TreeViewEventArgs(trvPdept.SelectedNode));
        }

        private void btnCodesender_Click(object sender, EventArgs e)
        {
            isCodeSenderSet = true;
            trvCodesender.SelectedNode = null;
            trvDept.SelectedNode = null;
            dmcPnl.ButtonClick(pnl1.Name);
        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            isCodeSenderSet = false;
            trvCodesender.SelectedNode = null;
            trvDept.SelectedNode = null;
            dmcPnl.ButtonClick(pnl2.Name);
        }

        private void trvCodesender_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //int num = 0;
            //if (trvCodesender.SelectedNode.Text == "所有")
            //{
            //    num = 0;
            //}
            //if (trvCodesender.SelectedNode.Text == "配置")
            //{
            //    num = 1;
            //}
            //if (trvCodesender.SelectedNode.Text == "未配置")
            //{
            //    num = 2;
            //}
            //DataTable codesenderdt = codebll.GetCodeSenderByUse(num, Convert.ToInt32(cmb_SelectCounts.SelectedItem), 1, out pagecount);
            //dgvCodeSenderSet.DataSource = codesenderdt;
            //this.lb_PageCounts.Text = "1";
            //this.lb_SumPage.Text = "/" + pagecount.ToString() + "页";
        }

        private void chbMulit_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMulit.Checked)
            {
                txtCodeMaxNum.Enabled = true;
            }
            else
            {
                txtCodeMaxNum.Enabled = false;
            }
        }

        private void btnCodeReSet_Click(object sender, EventArgs e)
        {
            txtCodeMinNum.Text = "";
            txtCodeMaxNum.Text = "";
            rbtZC.Checked = true;
            rbtLost.Checked = false;
            rbtLowD.Checked = false;
            rbtBad.Checked = false;
            chbMulit.Checked = false;
            txtCodeReMark.Text = "";
        }

        private void btnCodeReturn_Click(object sender, EventArgs e)
        {
            btnCodeReSet_Click(this, new EventArgs());
            txtCodeMinNum.Enabled = true;
            chbMulit.Enabled = true;
            labCodeMassage.Visible = false;
            pnlCode.Visible = false;
        }

        private void dgvCodeSenderSet_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!isCodeSenderSet)
            {
                txtCodeMinNum.Text = dgvCodeSenderSet.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCodeMinNum.Enabled = false;
                chbMulit.Enabled = false;
                if (dgvCodeSenderSet.Rows[e.RowIndex].Cells[2].Value.ToString() == "正常")
                {
                    rbtZC.Checked = true;
                    rbtLost.Checked = false;
                    rbtLowD.Checked = false;
                    rbtBad.Checked = false;
                    chbMulit.Checked = false;
                }
                if (dgvCodeSenderSet.Rows[e.RowIndex].Cells[2].Value.ToString() == "低电量")
                {
                    rbtZC.Checked = false;
                    rbtLost.Checked = false;
                    rbtLowD.Checked = true;
                    rbtBad.Checked = false;
                    chbMulit.Checked = false;
                }
                if (dgvCodeSenderSet.Rows[e.RowIndex].Cells[2].Value.ToString() == "遗失")
                {
                    rbtZC.Checked = false;
                    rbtLost.Checked = true;
                    rbtLowD.Checked = false;
                    rbtBad.Checked = false;
                    chbMulit.Checked = false;
                }
                if (dgvCodeSenderSet.Rows[e.RowIndex].Cells[2].Value.ToString() == "损坏")
                {
                    rbtZC.Checked = false;
                    rbtLost.Checked = false;
                    rbtLowD.Checked = false;
                    rbtBad.Checked = true;
                    chbMulit.Checked = false;
                }
                txtCodeReMark.Text = dgvCodeSenderSet.Rows[e.RowIndex].Cells[4].Value.ToString();
                this.pnlCode.Visible = true;
            }
        }

        private void btnCodeSave_Click(object sender, EventArgs e)
        {
            int state = 0;
            if (rbtZC.Checked)
                state = 1;
            if (rbtBad.Checked)
                state = 2;
            if (rbtLost.Checked)
                state = 3;
            if (rbtLowD.Checked)
                state = 4;
            if (chbMulit.Checked)
            {
                try
                {
                    int min = int.Parse(txtCodeMinNum.Text);
                    int max = int.Parse(txtCodeMaxNum.Text);
                    //int state = 0;
                    bool flag = true;
                    //if (rbtZC.Checked)
                    //    state = 1;
                    //if (rbtBad.Checked)
                    //    state = 2;
                    //if (rbtLost.Checked)
                    //    state = 3;
                    //if (rbtLowD.Checked)
                    //    state = 4;
                    for (int i = min; i <= max; i++)
                    {
                        if (codebll.InsertCodeSender(i, 1, state, 2, txtCodeReMark.Text) <= 0)
                            flag = false;
                    }
                    if (flag)
                        labCodeMassage.Text = "保存成功";
                    else
                        labCodeMassage.Text = "保存失败";
                    labCodeMassage.Visible = true;
                }
                catch (Exception ex)
                {
                    labCodeMassage.Text = "保存失败";
                    labCodeMassage.Visible = true;
                }
            }
            else
            {
                if (txtCodeMinNum.Enabled)
                {
                    int code = int.Parse(txtCodeMinNum.Text);
                    if (codebll.InsertCodeSender(code, 1, state, 2, txtCodeReMark.Text) > 0)
                        labCodeMassage.Text = "保存成功";
                    else
                        labCodeMassage.Text = "保存失败";
                    labCodeMassage.Visible = true;
                }
                else
                {
                    int code = int.Parse(txtCodeMinNum.Text);
                    if(codebll.UpdateCodeSenderState(code,state)>0)
                        labCodeMassage.Text = "保存成功";
                    else
                        labCodeMassage.Text = "保存失败";
                    labCodeMassage.Visible = true;
                }
            }
        }

        private Point DownPoint;
        private Point PnlPoint;
        private void bcp_CerTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                DownPoint = bcp_CerTitle.PointToScreen(e.Location);
                PnlPoint = pnlCode.Location;
            }
        }

        private void bcp_CerTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                int x = bcp_CerTitle.PointToScreen(e.Location).X - DownPoint.X + PnlPoint.X;
                int y = bcp_CerTitle.PointToScreen(e.Location).Y - DownPoint.Y + PnlPoint.Y;
                pnlCode.Location = new Point(x, y);
            }
        }

        private void bcpnlCodePP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                DownPoint = bcpnlCodePP.PointToScreen(e.Location);
                PnlPoint = pnlCodeSenderSet.Location;
            }
        }

        private void bcpnlCodePP_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                int x = bcpnlCodePP.PointToScreen(e.Location).X - DownPoint.X + PnlPoint.X;
                int y = bcpnlCodePP.PointToScreen(e.Location).Y - DownPoint.Y + PnlPoint.Y;
                pnlCodeSenderSet.Location = new Point(x, y);
            }
        }

        private void bcpnlCodePP_CloseButtonClick(object sender, EventArgs e)
        {
            button3_Click(this, new EventArgs());
        }

        private void bcp_CerTitle_CloseButtonClick(object sender, EventArgs e)
        {
            btnCodeReturn_Click(this, new EventArgs());
        }

        private void btnCodeSearch_Click(object sender, EventArgs e)
        {
            DataTable codesenderdt = codebll.GetCodeSenderByAddress(txtCode.Text);
            pagecount = 1;
            dgvCodeSenderSet.DataSource = codesenderdt;
            this.lb_PageCounts.Text = "1";
            this.lb_SumPage.Text = "/" + pagecount.ToString() + "页";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            txtCode.Text = "";
        }

        private void txtCodeSender_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtCodeMinNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtCodeMaxNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

    }

    /// <summary>
    /// 匹配预览中匹配对的实体类
    /// </summary>
    class EmpMacCodeSender
    {
        /// <summary>
        /// 人员或者设备ID
        /// </summary>
        private string empid;

        public string Empid
        {
            set { empid = value; }
        }

        /// <summary>
        /// 标识卡号
        /// </summary>
        private string codeserder;

        public string 标识卡
        {
            get { return codeserder; }
            set { codeserder = value; }
        }

        
        /// <summary>
        /// 人员或者设备名称
        /// </summary>
        private string empmacname;

        public string 名称
        {
            get { return empmacname; }
            set { empmacname = value; }
        }

        private string m_typeID;
        public string 类型
        {
            get { return m_typeID; }
            set { m_typeID = value; }
        }
        public EmpMacCodeSender(string empid,string empname,string codesend,string typeID)
        {
            this.Empid = empid;
            this.empmacname = empname;
            this.标识卡 = codesend;
            this.类型 = typeID;
        }
        /// <summary>
        /// 获得人员或者设备ID
        /// </summary>
        /// <returns>人员或者设备ID</returns>
        public string GetEmpID()
        {
            return empid;
        }
       
    }
}
