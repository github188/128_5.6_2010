using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using System.Collections;
using KJ128NModel;
using KJ128NDataBase;

namespace KJ128NMainRun.EmployeeManage
{
    public partial class FrmEmpPost : Wilson.Controls.Docking.DockContent
    {

        #region 【声明】

        private EmpPostBLL epbll = new EmpPostBLL();

        private DataSet ds;

        private string strEmpID;

        #endregion

        #region 【构造函数】

        public FrmEmpPost()
        {
            InitializeComponent();
        }

        #endregion

        #region 【事件：窗体加载】

        private void FrmEmpPost_Load(object sender, EventArgs e)
        {
            timer1.Stop();

            GetDeptName(ddlDeptName);
            GetTerrName(ddlAreaNameStation,true);
            GetEmpPostInfo();
        }

        #endregion

        #region 【方法：加载部门名称】

        private bool GetDeptName(ComboBox cmb)
        {
            try
            {
                if (cmb != null)
                {
                    using (ds = new DataSet())
                    {
                        ds = epbll.GetDeptInfo();
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            ArrayList mylist = new ArrayList();
                            mylist.Add(new DictionaryEntry("0", "所有"));

                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                mylist.Add(new DictionaryEntry(dr["DeptID"].ToString(), dr["DeptName"].ToString()));
                            }

                            cmb.DataSource = mylist;
                            cmb.DisplayMember = "Value";
                            cmb.ValueMember = "Key";
                            cmb.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch 
            {
                return false;
            }
            return false;
        }

        #endregion

        #region 【方法：加载区域名称 】

        private bool GetTerrName(ComboBox cmb,bool blIsAll)
        {
            try
            {
                if (cmb != null)
                {
                    using (ds = new DataSet())
                    {
                        ds = epbll.GetTerrInfo();
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            ArrayList mylist = new ArrayList();
                            if (blIsAll)
                            {
                                mylist.Add(new DictionaryEntry("0", "所有"));
                            }
                            //else
                            //{
                            //    mylist.Add(new DictionaryEntry("0", "无"));
                            //}

                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                mylist.Add(new DictionaryEntry(dr["TerritorialID"].ToString(), dr["TerritorialName"].ToString()));
                            }

                            cmb.DataSource = mylist;
                            cmb.DisplayMember = "Value";
                            cmb.ValueMember = "Key";
                            cmb.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }


        #endregion

        #region 【方法：验证员工数据 】

        private bool ValidateEmp()
        {
            if (ddlAreaNameAdd.SelectedValue==null)
            {
                MessageBox.Show("请选择该员工所在工作岗位的区域名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (txt_CodeSenderAddress.Text.Trim().Equals(""))
            {
                MessageBox.Show("标识卡编号不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                return false;
            }

            if (txt_EmpName.Text.Trim().Equals(""))
            {
                MessageBox.Show("不存在与该标识卡绑定的员工！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            if (btnAddOrModify.CaptionTitle.Equals(" 添 加"))
            {
                using (ds = new DataSet())
                {
                    ds = epbll.IsEmpPost(txt_CodeSenderAddress.Text.Trim());
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("存在该员工的岗位配置信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return false;
                        }
                    }
                }
            }


            return true;

        }

        #endregion

        #region 【方法：查询信息】

        private bool GetEmpPostInfo()
        {
            try
            {
                using (ds = new DataSet())
                {
                    ds = epbll.GetEmpPostInfo(Convert.ToInt32(ddlDeptName.SelectedValue.ToString()),
                        Convert.ToInt32(ddlAreaNameStation.SelectedValue), txtBlockIDStation.Text.Trim(),
                        TxtEmployeeNameStation.Text.Trim());
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        dgrd.DataSource = ds.Tables[0];
                        dgrd.Columns["Edit"].DisplayIndex = dgrd.Columns.Count - 1;
                        dgrd.Columns["Delete"].DisplayIndex = dgrd.Columns.Count - 1;
                        dgrd.Columns["EmpID"].Visible = false;
                        dgrd.Columns["TerritorialID"].Visible = false;
                        dgrd.Columns["WorkTime"].Visible = false;
                    }
                }


            }
            catch 
            {
                dgrd.DataSource = null;
            }
            return true;
        }

        #endregion


        #region 【事件：添加单击事件 】

        private void btnAddMain_Click(object sender, EventArgs e)
        {
            plAdd.Visible = true;
            GetTerrName(ddlAreaNameAdd, false);

            PanelModify.CaptionTitle = "添加员工岗位信息";
            btnAddOrModify.CaptionTitle = " 添 加";

            txt_CodeSenderAddress.Text = "";
            txt_EmpName.Text = "";
            txt_Hour.Text = "1";
            txt_Minute.Text = "0";
            txt_Second.Text = "0";
            txtRemark.Text = "";

            txt_CodeSenderAddress.Enabled = true;
        }

        #endregion

        #region 【事件：返回单击事件 】

        private void btnReturn_Click(object sender, EventArgs e)
        {
            plAdd.Visible = false;
        }

        #endregion

        #region 【事件：添加、修改数据 】

        private void btnAddOrModify_Click(object sender, EventArgs e)
        {
            if (ValidateEmp())
            {
                EmpPostModel empPostModel = new EmpPostModel();
                
                int intWorkTime;

                try
                {
                    empPostModel.CodeSenderAddress = Convert.ToInt32(txt_CodeSenderAddress.Text.Trim());
                    empPostModel.TerritorialID = Convert.ToInt32(ddlAreaNameAdd.SelectedValue.ToString());
                }
                catch
                {
                    return;
                }
                try
                {
                    intWorkTime = Convert.ToInt32(txt_Hour.Text.Trim()) * 3600 + Convert.ToInt32(txt_Minute.Text.Trim()) * 60 + Convert.ToInt32(txt_Second.Text.Trim());
                }
                catch 
                {
                    intWorkTime = 3600;
                }

                empPostModel.WorkTime = intWorkTime;
                empPostModel.Remark = txtRemark.Text.Trim();

                if (PanelModify.CaptionTitle.Equals("添加员工岗位信息"))          //添加
                {
                    if (epbll.InsertEmpInfo(empPostModel) > 0)
                    {
                        MessageBox.Show("添加成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        
                        if (!New_DBAcess.IsDouble)
                        {
                            GetEmpPostInfo();
                        }
                        else
                        {
                            timer1.Stop();
                            timer1.Start();
                        }
                    }
                    else
                    {
                        MessageBox.Show("添加失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else                                            //修改
                {
                    if (epbll.UpDataEmpInfo(empPostModel) > 0)
                    {
                        MessageBox.Show("修改成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        
                        if (!New_DBAcess.IsDouble)
                        {
                            GetEmpPostInfo();
                        }
                        else
                        {
                            timer1.Stop();
                            timer1.Start();
                        }
                    }
                    else
                    {
                        MessageBox.Show("修改失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
        }

        #endregion

        #region 【事件：获取员工姓名 】

        private void txt_CodeSenderAddress_Leave(object sender, EventArgs e)
        {
            try
            {
                txt_EmpName.Text = "";

                if (!txt_CodeSenderAddress.Text.Trim().Equals(""))
                {
                    using (ds = new DataSet())
                    {
                        ds = epbll.GetEmpName(txt_CodeSenderAddress.Text.Trim());
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                txt_EmpName.Text = ds.Tables[0].Rows[0][0].ToString();
                            }
                        }
                    }
                }

            }
            catch
            {
                txt_EmpName.Text = "";
            }

        }

        #endregion

        #region 【事件：查询员工岗位信息】

        private void btnQuery_Click(object sender, EventArgs e)
        {
            GetEmpPostInfo();
        }

        #endregion

        #region 【事件：修改、删除 】

        private void dgrd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)  //修改
                {

                    plAdd.Visible = true;
                    PanelModify.CaptionTitle = "修改员工岗位信息";
                    btnAddOrModify.CaptionTitle = " 修 改";

                    GetTerrName(ddlAreaNameAdd, false);

                    strEmpID = dgrd.Rows[e.RowIndex].Cells["EmpID"].Value.ToString();

                    ddlAreaNameAdd.Text = dgrd.Rows[e.RowIndex].Cells["岗位区域"].Value.ToString();

                    txt_CodeSenderAddress.Text = dgrd.Rows[e.RowIndex].Cells["标识卡编号"].Value.ToString();
                    txt_EmpName.Text = dgrd.Rows[e.RowIndex].Cells["姓名"].Value.ToString();

                    int intMax = Convert.ToInt32(dgrd.Rows[e.RowIndex].Cells["WorkTime"].Value.ToString());
                    int hourMax = intMax / 3600;
                    int minuteMax = (intMax - hourMax * 3600) / 60;
                    int secondMax = intMax % 60;
                    txt_Hour.Text = hourMax.ToString();
                    txt_Minute.Text = minuteMax.ToString();
                    txt_Second.Text = secondMax.ToString();

                    txtRemark.Text = dgrd.Rows[e.RowIndex].Cells["备注"].Value.ToString();

                    txt_CodeSenderAddress.Enabled = false;


                }
                else if (e.RowIndex >= 0 && e.ColumnIndex == 1)     //删除
                {
                    if (MessageBox.Show("你确定要删除吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int intDeleteCount;
                        intDeleteCount= epbll.DeleteEmpPost(Convert.ToInt32(dgrd.Rows[e.RowIndex].Cells["EmpID"].Value.ToString()));

                        if (intDeleteCount > 0)
                        {
                            if (!New_DBAcess.IsDouble)
                            {
                                GetEmpPostInfo();
                            }
                            else
                            {
                                timer1.Stop();
                                timer1.Start();
                            }
                        }
                    }
                }
            }
            catch {}
        }

        #endregion

        #region 【事件：热备刷新】
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            GetEmpPostInfo();
            timer1.Stop();
        }

        #endregion

        #region 【事件：刷新】

        private void bcpRef_Click(object sender, EventArgs e)
        {
            GetEmpPostInfo();
        }

        #endregion

        #region 【事件：打印】

        private void btnReset_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgrd, Text);
        }

        #endregion

    }
}
