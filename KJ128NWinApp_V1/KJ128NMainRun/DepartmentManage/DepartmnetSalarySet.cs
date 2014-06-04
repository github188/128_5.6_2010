using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using System.IO;
using Shine.Logs;
using Shine.Logs.LogType;
using KJ128NDataBase;

namespace KJ128NInterfaceShow
{
    public partial class DepartmnetSalarySet : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]

        DeptBLL dBLL = new DeptBLL();
        string strErr = string.Empty;
        static int intDeptID = 0;

        #endregion

        #region [ 构造函数 ]

        public DepartmnetSalarySet()
        {
            InitializeComponent();
        }

        #endregion

        /*
         * 方法
         */ 

        #region [ 方法: dgrd数据绑定 ]
        public void BindDataGridView()
        {
            string strWhere = string.Empty;
            if (ddlDeptStation.SelectedValue.ToString() != "0")
            {
                strWhere = " where upc.DeptID = "+ddlDeptStation.SelectedValue.ToString();
            }

            DataSet ds = dBLL.GetUnitPriceInfo(strWhere, out strErr);
            if (strErr.ToString() == "Succeeds")
            {
                dgrd.DataSource = ds.Tables[0];
                dgrd.Columns[0].DisplayIndex = 5;
                dgrd.Columns[1].DisplayIndex = 5;
                dgrd.Columns[2].Visible = false;
            }


        }
        #endregion

        /*
         * 事件
         */ 

        #region [ 事件: 窗体加载 ]

        private void DepartmnetSalarySet_Load(object sender, EventArgs e)
        {
            dBLL.getDeptAddAll(ddlDeptStation);
            dBLL.getDept(ddlAdd);
            gbStation.Visible = false;
            capModify.Visible = false;
            lblErr.Visible = false;
            BindDataGridView();

        }
        #endregion

        #region [ 事件: 复选框的单击事件 ]

        private void ckAll_Click(object sender, EventArgs e)
        {
            if (ckAll.Checked)
            {
                dBLL.getDeptAddAll(ddlAdd);
                ddlAdd.SelectedValue = "0";
                this.ddlAdd.Enabled = false;
            }
            if(!ckAll.Checked)
            {
                if (btnModify.CaptionTitle != "修 改")
                {
                    this.ddlAdd.Enabled = true;
                    dBLL.getDept(ddlAdd);


                }
                else
                {
                    dBLL.getDept(ddlAdd);
                    ddlAdd.SelectedValue = lblTemp.Text.ToString();
                }
            }
        }
        #endregion

        #region [ 事件: 添加按钮的单击事件 ]

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            lblErr.Text = "";
            ckAll.Enabled = true;
            ckAll.Visible = true;
            capModify.Visible = true;
            lblErr.Visible = true;
            gbStation.Visible = true;
            txtUnit.Text = "";
            txtRemark.Text = "";
            ddlAdd.Enabled = true;
            btnModify.CaptionTitle = "添 加";
            capModify.CaptionTitle = "添加部门工时单价";
            ckAll.Checked = false;
            dBLL.getDept(ddlAdd);
            BindDataGridView();
            if (ddlAdd.Items.Count == 0)
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "没有部门或部门没有配置员工！";
                return;
            }

           
        }
        #endregion

        #region [ 事件: 返回按钮的单击事件 ]

        private void btnReturn_Click(object sender, EventArgs e)
        {
            capModify.Visible = false;
            gbStation.Visible = false;
            lblErr.Visible = false;
        }
        #endregion

        #region [ 事件: 查询按钮的单击事件 ]

        private void btnQuery_Click(object sender, EventArgs e)
        {
            BindDataGridView();
        }
        #endregion

        #region [ 事件: 修改/添加按钮的单击事件 ]

        private void btnModify_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            if (ddlAdd.Items.Count == 0)
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "没有部门或部门没有配置员工！";
                return;
            }

            if (txtUnit.Text.Trim() == "")
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "单价不能为空!";
                return;
            }
            else
            {
                try
                {
                    Convert.ToDouble(txtUnit.Text.Trim());
                    if (Convert.ToDouble(txtUnit.Text.Trim()) < 0)
                    {
                        lblErr.ForeColor = Color.Red;
                        lblErr.Text = "单价不能为负数!";
                        return;
                    }
                }
                catch
                {
                    lblErr.ForeColor = Color.Red;
                    lblErr.Text = "单价只能为整数或小数!";
                    return;
                }
            }
            if (btnModify.CaptionTitle == "修 改")
            {
                //存入日志
                LogSave.Messages("[DepartmnetSalarySet]", LogIDType.UserLogID, "修改部门工时单价，部门：" + ddlAdd.SelectedText + "，单价：" + txtUnit.Text + "。");

                operated = 3;

                dBLL.UpdateUnitPriceInfo(intDeptID, (float)Convert.ToDouble(txtUnit.Text.ToString()), txtRemark.Text, out strErr);
                if (strErr.ToString() == "Succeeds")
                {
                    lblErr.ForeColor = Color.Blue;
                    lblErr.Text = "修改成功!";

                    if (!New_DBAcess.IsDouble)
                    {
                        BindDataGridView();
                    }
                    else
                    {
                        timer1.Start();
                    }
                }
            }
            else
            {
                //存入日志
                LogSave.Messages("[DepartmnetSalarySet]", LogIDType.UserLogID, "增加新的部门工时单价，部门：" + ddlAdd.SelectedText + "，单价：" + txtUnit.Text + "。");

                if (ckAll.Checked)
                {
                    for (int i = 1; i < ddlAdd.Items.Count; i++)
                    {
                        DataRowView drv = (DataRowView)ddlAdd.Items[i];
                        string strDeptID = drv["DeptID"].ToString();

                        operated = 1;

                        dBLL.InsertUnitPriceInfo(Convert.ToInt32(strDeptID), (float)Convert.ToDouble(txtUnit.Text.ToString()), txtRemark.Text, out strErr);
                        if (strErr == "Succeeds")
                        {
                            lblErr.ForeColor = Color.Blue;
                            lblErr.Text = "添加成功!";
                            if (!New_DBAcess.IsDouble)
                            {
                                BindDataGridView();
                            }
                            else
                            {
                                timer1.Start();
                            }
                        }
                        else
                        {
                            lblErr.ForeColor = Color.Red;
                            lblErr.Text = "添加失败!";
                        }
                    }
                    
                }
                else
                {
                    if (ddlAdd.SelectedValue != null)
                    {
                        operated = 1;

                        dBLL.InsertUnitPriceInfo(Convert.ToInt32(ddlAdd.SelectedValue.ToString()), (float)Convert.ToDouble(txtUnit.Text.ToString()), txtRemark.Text, out strErr);
                        if (strErr == "Succeeds")
                        {
                            lblErr.ForeColor = Color.Blue;
                            lblErr.Text = "添加成功!";
                            if (!New_DBAcess.IsDouble)
                            {
                                BindDataGridView();
                            }
                            else
                            {
                                timer1.Start();
                            }
                        }
                        else
                        {
                            lblErr.ForeColor = Color.Red;
                            lblErr.Text = "添加失败!";
                        }
                    }
                    else
                    {
                        lblErr.ForeColor = Color.Red;
                        lblErr.Text = "请先添加部门!";
                    }
                }
            }
        }
        #endregion

        #region [ 事件: DataGridView单元格的单击事件 ]

        private void dgrd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblErr.Text = "";
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                intDeptID = Convert.ToInt32(dgrd.Rows[e.RowIndex].Cells[2].Value.ToString());
                ddlAdd.SelectedValue = dgrd.Rows[e.RowIndex].Cells[2].Value.ToString();
                lblTemp.Text = dgrd.Rows[e.RowIndex].Cells[2].Value.ToString();
                ddlAdd.Enabled = false;
                txtUnit.Text = dgrd.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtRemark.Text = dgrd.Rows[e.RowIndex].Cells[5].Value.ToString();
                gbStation.Visible = true;
                capModify.Visible = true;
                lblErr.Visible = true;
                btnModify.CaptionTitle = "修 改";
                capModify.CaptionTitle = "修改部门工时单价";
                ckAll.Checked = false;
                ckAll.Enabled = false;
            }
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                //存入日志
                LogSave.Messages("[DepartmnetSalarySet]", LogIDType.UserLogID, "删除部门工时单价，部门：" + dgrd.Rows[e.RowIndex].Cells[3].Value + "，单价：" + dgrd.Rows[e.RowIndex].Cells[4].Value + "。");

                if (MessageBox.Show("你确定要删除吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    operated = 2;

                    dBLL.DeleteUnitPriceInfo(Convert.ToInt32(dgrd.Rows[e.RowIndex].Cells[2].Value.ToString()),out strErr);
                    if (strErr == "Succeeds")
                    {
                        lblErr.ForeColor = Color.Blue;
                        lblErr.Text = "删除成功!";

                        if (!New_DBAcess.IsDouble)
                        {
                            BindDataGridView();
                        }
                        else
                        {
                            timer1.Start();
                        }
                    }
                }
            }
        }

        #endregion

        #region [ 事件: 导出Excel ]

        private void buttonCaptionPanel2_Click(object sender, EventArgs e)
        {
            ExcelExports.ExportDataGridViewToExcel(dgrd);
        }

        #endregion

        #region [热备定时刷新]

        /// <summary>
        /// 最大刷新次数
        /// </summary>
        private int maxTimes = 2;

        /// <summary>
        /// 查询刷新次数
        /// </summary>
        private int times = 0;

        /// <summary>
        /// 1表示 增加，修改 2 表示删除,3表示修改
        /// </summary>
        private int operated = 1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            //增加
            if (operated == 1)
            {
                string value = ddlAdd.SelectedValue.ToString();

                if (RecordSearch.IsRecordExists("UnitPrice", "DeptID", value, DataType.Int))
                {
                    //刷新

                    BindDataGridView();

                    times = 0;
                    //关闭timer1
                    timer1.Stop();
                }
                else
                {
                    if (times < maxTimes)
                    {
                        times++;
                        timer1.Stop();
                        timer1.Start();
                    }
                    else
                    {
                        times = 0;
                        //关闭timer1
                        timer1.Stop();
                    }
                }
            }
            //删除
            else if (operated == 2)
            {
                string value = dgrd.CurrentRow.Cells[2].Value.ToString();

                if (!RecordSearch.IsRecordExists("UnitPrice", "DeptID", value, DataType.Int))
                {
                    //刷新

                    BindDataGridView();

                    times = 0;
                    //关闭timer1
                    timer1.Stop();
                }
                else
                {
                    if (times < maxTimes)
                    {
                        times++;
                        timer1.Stop();
                        timer1.Start();
                    }
                    else
                    {
                        times = 0;
                        //关闭timer1
                        timer1.Stop();
                    }
                }
            }
            //修改
            else
            {
                string strWhere = "DeptID=" + ddlAdd.SelectedValue.ToString()
                    + "and UnitPrice=" + txtUnit.Text
                    + " and Remark ='" + txtRemark.Text + "'";

                if (RecordSearch.IsRecordExists("UnitPrice", strWhere))
                {
                    //刷新
                    BindDataGridView();

                    times = 0;
                    //关闭timer1
                    timer1.Stop();
                }
                else
                {
                    if (times < maxTimes)
                    {
                        times++;
                        timer1.Stop();
                        timer1.Start();
                    }
                    else
                    {
                        times = 0;
                        //关闭timer1
                        timer1.Stop();
                    }
                }
            }
        }

        #endregion        

        private void bcpRef_Click(object sender, EventArgs e)
        {
            BindDataGridView();
        }
    }
}