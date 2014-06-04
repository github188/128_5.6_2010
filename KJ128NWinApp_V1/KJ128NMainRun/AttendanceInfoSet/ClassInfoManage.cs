using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using Shine.Logs;
using Shine.Logs.LogType;
using KJ128NDataBase;

namespace KJ128NInterfaceShow
{
    public partial class ClassInfoManage : Wilson.Controls.Docking.DockContent
    {
        static string strErr = string.Empty;
        InfoClassBLL ICBLL = new InfoClassBLL();

        #region 窗体初始化
        public ClassInfoManage()
        {
            InitializeComponent();
        }
        #endregion

        #region 数据绑定
        void BindData()
        {
            DataSet ds = ICBLL.InfoClass_Query("");

            if (ds != null)
            {
                dgrd.AutoGenerateColumns = true;
                dgrd.DataSource = ds.Tables[0];
                dgrd.Columns[3].HeaderText = "班制全称";
                dgrd.Columns[4].HeaderText = "班制简称";
                dgrd.Columns[5].HeaderText = "备注";
                dgrd.Columns[2].Visible = false;
                dgrd.Columns[0].DisplayIndex = 5;
                dgrd.Columns[1].DisplayIndex = 5;
                dgrd.Columns[1].Visible = false;
            }
        }
        #endregion

        #region 窗体加载事件
        private void ClassInfoManage_Load(object sender, EventArgs e)
        {
            captionPanel1.Width = this.Width;
            captionPanel1.Height = this.Height - 35;
          
            dgrd.Width = this.Width;
            dgrd.Height = this.Height - 56;

            ShowOrHiddenControl(false,true);
            BindData();
        }
        #endregion

        #region 控件加载函数
        void ShowOrHiddenControl(bool budgrd,bool bdgrd)
        {
            cpModify.Visible = budgrd;
            labelTransparent1.Visible = budgrd;
            labelTransparent2.Visible = budgrd;
            labelTransparent3.Visible = budgrd;
            txtName.Visible = budgrd;
            txtRemark.Visible = budgrd;
            txtShortName.Visible = budgrd;
            buttonCPCancel.Visible = budgrd;
            buttonCPModify.Visible = budgrd;
            lblValidate1.Visible = budgrd;
            lblValidate2.Visible = budgrd;
            dgrd.Visible = bdgrd;

        }
        #endregion

        #region DataGridView的单元格的单击按钮
        private void dgrd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblErr.Text = "";
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                
                ShowOrHiddenControl(true,false);
                buttonCPModify.CaptionTitle = "修 改";
                this.txtName.Text=dgrd.Rows[e.RowIndex].Cells[3].Value.ToString();
                this.txtShortName.Text = dgrd.Rows[e.RowIndex].Cells[4].Value.ToString();
                this.txtRemark.Text = dgrd.Rows[e.RowIndex].Cells[5].Value.ToString();
                this.lblID.Text = dgrd.Rows[e.RowIndex].Cells[2].Value.ToString();
               
            }
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                if (MessageBox.Show("你确定在删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //存入日志
                    LogSave.Messages("[ClassInfoManage]", LogIDType.UserLogID, "删除班制信息，班制全称：" + dgrd.Rows[e.RowIndex].Cells[3].Value.ToString()
                        + "，班制简称：" + dgrd.Rows[e.RowIndex].Cells[4].Value.ToString() + "。");

                    ICBLL.InfoClass_Delete(Convert.ToInt32(dgrd.Rows[e.RowIndex].Cells[2].Value.ToString()), out strErr);
                    if (strErr == "Succeeds")
                    {
                        lblErr.ForeColor = Color.Blue;
                        lblErr.Text = "删除成功!";

                        if (!New_DBAcess.IsDouble)
                        {
                            BindData();
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

        #region 添加/修改的按钮的单击事件
        private void buttonCPModify_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "班制全称不能为空!";
                return;
            }
            if (txtShortName.Text == "")
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "班制简称不能为空!";
                return;
            }
            lblErr.Text = "";
            try
            {
                if (buttonCPModify.CaptionTitle == "修 改")
                {
                    //存入日志
                    LogSave.Messages("[ClassInfoManage]", LogIDType.UserLogID, "修改班制信息，班制全称：" + txtName.Text + "，班制简称：" + txtShortName.Text + "。");

                    ICBLL.InfoClass_Update(Convert.ToInt32(lblID.Text.ToString()), txtName.Text, txtShortName.Text, txtRemark.Text, out strErr);
                    if (strErr == "Succeeds")
                    {
                        lblErr.Text = "修改成功!";
                    }
                }
                else
                {
                    //存入日志
                    LogSave.Messages("[ClassInfoManage]", LogIDType.UserLogID, "增加班制信息，班制全称：" + txtName.Text + "，班制简称：" + txtShortName.Text + "。");

                    ICBLL.InfoClass_Insert(txtName.Text.ToString(), txtShortName.Text.ToString(), txtRemark.Text.ToString(), out strErr);
                    if (strErr == "Succeeds")
                    {
                        lblErr.Text = "添加成功!";
                    }
                }
            }
            catch (Exception ex)
            {
                lblErr.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region 取消按钮的单击事件
        private void buttonCPCancel_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            ShowOrHiddenControl(false,true);
            if (!New_DBAcess.IsDouble)
            {
                BindData();
            }
            else
            {
                timer1.Start();
            }
        }
        #endregion

        #region 添加按钮的单击事件
        private void bcpAdd_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            ShowOrHiddenControl(true, false);
            txtName.Text = "";
            txtRemark.Text = "";
            txtShortName.Text = "";
            buttonCPModify.CaptionTitle = "添 加";
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

            if (times < maxTimes)
            {
                BindData();

                times++;
                timer1_Tick(sender, e);
            }
            else
            {
                times = 0;
                //关闭timer1
                timer1.Stop();
            }
        }

        #endregion        

        private void bcpRef_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}