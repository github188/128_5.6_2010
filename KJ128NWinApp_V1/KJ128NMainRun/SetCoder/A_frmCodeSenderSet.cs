using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NDataBase;

namespace KJ128NMainRun.SetCoder
{
    public partial class A_frmCodeSenderSet : Form
    {
        private A_CodeSenderBLL codebll = new A_CodeSenderBLL();

        private List<EmpMacCodeSender> list = new List<EmpMacCodeSender>();

        private List<string> ExitsEmpIdlist = new List<string>();

        private A_frmCodeSender a_FrmCodeSender;

        #region 【构造函数】
        public A_frmCodeSenderSet(A_frmCodeSender a_frmcode)
        {
            InitializeComponent();
            a_FrmCodeSender = a_frmcode;
            dgvSet.DataError += new DataGridViewDataErrorEventHandler(dgvSet_DataError);
        }

        void dgvSet_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string strErr = e.Exception.Message;
            e.ThrowException = false;
        }

        private void A_frmCodeSenderSet_Load(object sender, EventArgs e)
        {
            LoadTrvDept();
            lsbCodeSender.Items.Clear();
            DataTable dt = codebll.GetLastCodesender();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lsbCodeSender.Items.Add(dt.Rows[i][0].ToString());
            }
            GetEmp();
        }
        #endregion

        #region 【方法：加载部门树】
        private void LoadTrvDept()
        {
            DataTable depttable = codebll.GetDeptInfo();
            //trvDept.Nodes.Add("0", "所有");
            //AddTreeNode(depttable, trvDept.Nodes[0]);
            trvPdept.Nodes.Add("0", "所有");
            AddTreeNode(depttable, trvPdept.Nodes[0]);
            trvPdept.ExpandAll();
        }
        #endregion

        #region 【事件方法：添加树节点】
        private void AddTreeNode(DataTable dt, TreeNode node)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["parentdeptid"].ToString() == node.Name)
                {
                    TreeNode childnode = new TreeNode(dt.Rows[i]["deptname"].ToString());
                    childnode.Name = dt.Rows[i]["deptid"].ToString();
                    node.Nodes.Add(childnode);
                    AddTreeNode(dt, childnode);
                }
            }
        }
        #endregion

        #region 【事件方法：部门树选择后筛选】
        private void trvPdept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            GetEmp();
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
            //    DataTable empmacdt = codebll.GetLastEmpByDept(trvPdept.SelectedNode.Name.Trim(), type,txtName.Text.Trim());
            //    empmacdt = RemoveExitsEmpMac(empmacdt);
            //    for (int i = 0; i < empmacdt.Rows.Count; i++)
            //    {
            //        lsbEmpMac.AddItem(empmacdt.Rows[i][1].ToString(), empmacdt.Rows[i][0].ToString());
            //    }
            //}
        }
        #endregion

        #region 【方法：将已经经过匹配的人员或设备从指定的DT里面删除】
        /// <summary>
        /// 将已经经过匹配的人员或设备从指定的DT里面删除
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable RemoveExitsEmpMac(DataTable dt)
        {
            if (list.Count > 0)
            {
                for (int i = (dt.Rows.Count - 1); i >= 0; i--)
                {
                    string empid = dt.Rows[i]["empid"].ToString();
                    if (ExitsEmpIdlist.Contains(empid))
                    {
                        dt.Rows.RemoveAt(i);
                    }
                }
                return dt;
            }
            else
            {
                return dt;
            }
        }
        #endregion

        #region 【方法：加载未关联的人员数据】
        private void GetEmp()
        {
            string type;
            string strDept = "";
            if (rbtEmp.Checked)
            {
                type = "人员";
            }
            else
            {
                type = "设备";
            }
            if (trvPdept.SelectedNode!=null)
            {
                strDept = trvPdept.SelectedNode.Name.Trim();
            }

            DataTable empmacdt = codebll.GetLastEmpByDept(strDept, type, txtName.Text.Trim());
            lsbEmpMac.Items.Clear();
            lsbEmpMac.Values.Clear();
            for (int i = 0; i < empmacdt.Rows.Count; i++)
            {
                lsbEmpMac.AddItem(empmacdt.Rows[i][1].ToString(), empmacdt.Rows[i][0].ToString());
            }

            try
            {
                //新增修改，移除已经匹配到匹配预览中的人员
                if (list.Count > 0)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        for (int i = 0; i < lsbEmpMac.Items.Count; i++)
                        {
                            if (list[j].名称 == lsbEmpMac.Items[i].ToString())
                            {
                                lsbEmpMac.Items.RemoveAt(i);
                                lsbEmpMac.Values.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }
            }
            catch
            { } 
        }
        #endregion

        #region 【事件方法：按条件查找】
        private void btnPsearch_Click(object sender, EventArgs e)
        {
            GetEmp();
            //string type;
            //if (rbtEmp.Checked)
            //{
            //    type = "人员";
            //}
            //else
            //{
            //    type = "设备";
            //}
            //DataTable empmacdt = codebll.GetLastEmpByDept(trvPdept.SelectedNode.Name.Trim(), type, txtName.Text.Trim());
            //lsbEmpMac.Items.Clear();
            //lsbEmpMac.Values.Clear();
            //for (int i = 0; i < empmacdt.Rows.Count; i++)
            //{
            //    lsbEmpMac.AddItem(empmacdt.Rows[i][1].ToString(), empmacdt.Rows[i][0].ToString());
            //}
        }
        #endregion


        #region 【事件方法：网格单元格双击查看】
        private void dgvSet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ExitsEmpIdlist.Remove(list[e.RowIndex].GetEmpID());
            list.RemoveAt(e.RowIndex);
            dgvSet.DataSource = new DataTable();
            dgvSet.DataSource = list;
            ReLoad();
            trvPdept_AfterSelect(this, new TreeViewEventArgs(trvPdept.SelectedNode));
        }
        #endregion



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
                for (int i = (num - 1); i >= 0; i--)
                {
                    string name = lsbEmpMac.SelectedItems[i].ToString();
                    string empid = lsbEmpMac.Values[lsbEmpMac.Items.IndexOf(name)];
                    string codesender = lsbCodeSender.SelectedItems[i].ToString();
                    string type;
                    if (rbtEmp.Checked)
                        type = "人员";
                    else
                        type = "设备";
                    EmpMacCodeSender emcs = new EmpMacCodeSender(empid, name, codesender,type);
                    list.Insert(0, emcs);
                    ExitsEmpIdlist.Add(empid);
                    int index = lsbEmpMac.Values.IndexOf(empid);
                    lsbEmpMac.Items.RemoveAt(index);
                    lsbEmpMac.Values.RemoveAt(index);
                    lsbCodeSender.Items.Remove(codesender);
                }
                
                try
                {
                    dgvSet.DataSource = new DataTable();
                    dgvSet.DataSource = list;
                }
                catch
                {dgvSet.DataSource = new DataTable(); }
            }
            else
            {
                MessageBox.Show("人员设备或标识卡尚未选择...", "提示", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (list.Count > 0)
            {
                bool flag = true;
                
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
                    //MessageBox.Show("保存失败...", "提示", MessageBoxButtons.OK);
                    labMessage.Text = "保存失败";
                    labMessage.ForeColor = Color.Red;
                    labOut.Visible = true;
                    labMessage.Visible = true;
                }
                else
                {
                    //btnPReset_Click(this, new EventArgs());
                    list.Clear();
                    labMessage.Text = "保存成功!";
                    labMessage.ForeColor = Color.Black;
                    labOut.Visible = true;
                    labMessage.Visible = true;

                    //Czlt-2011-12-10 跟新时间
                    codebll.UpdateTime();


                    if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                    {
                        btnPReset_Click(this, new EventArgs());
                        a_FrmCodeSender.BindCodeSet(1);
                    }
                    else                                //热备版，启用定时器
                    {
                        dgvSet.DataSource = new DataTable();
                        a_FrmCodeSender.HostBackRefresh(true);
                    }
                }
            }
        }

        private void btnPReset_Click(object sender, EventArgs e)
        {
            list.Clear();
            ExitsEmpIdlist.Clear();
            dgvSet.DataSource = new DataTable();
            ReLoad();
            trvPdept_AfterSelect(this, new TreeViewEventArgs(trvPdept.SelectedNode));
            this.labOut.Visible = false;
            this.labMessage.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReLoad()
        {
            lsbCodeSender.Items.Clear();
            DataTable dt = codebll.GetLastCodesender();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lsbCodeSender.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        private void rbtEmp_CheckedChanged(object sender, EventArgs e)
        {
            txtName.Text = "";
            GetEmp();
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
            //    DataTable empmacdt = codebll.GetLastEmpByDept(trvPdept.SelectedNode.Name, type, txtName.Text.Trim());
            //    empmacdt = RemoveExitsEmpMac(empmacdt);
            //    for (int i = 0; i < empmacdt.Rows.Count; i++)
            //    {
            //        lsbEmpMac.AddItem(empmacdt.Rows[i][1].ToString(), empmacdt.Rows[i][0].ToString());
            //    }
            //}
        }

        private void rbtMac_CheckedChanged(object sender, EventArgs e)
        {
            ////txtName.Text = "";
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

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

    }
}
