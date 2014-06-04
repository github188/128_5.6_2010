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
    public partial class HolidayTypeSet : Wilson.Controls.Docking.DockContent
    {
        string strErr = string.Empty;
        HolidayTypeBLL HTBLL = new HolidayTypeBLL();

        #region 构造函数
        public HolidayTypeSet()
        {
            InitializeComponent();
        }
        #endregion

        #region DataGridView数据绑定函数
        void BindData()
        {
            DataSet ds = HTBLL.HolidayType_Query("");
            if (ds != null)
            {
                dgrd.DataSource = ds.Tables[0];

                dgrd.Columns[3].HeaderText = "假别代码";
                dgrd.Columns[4].HeaderText = "假别全称";
                dgrd.Columns[5].HeaderText = "假别简称";
                dgrd.Columns[2].Visible = false;
                dgrd.Columns[0].DisplayIndex = 5;
                dgrd.Columns[1].DisplayIndex = 5;
            }
            else
            {
                DataTable dt = new DataTable();
                dgrd.DataSource = dt;
            }
        }
        #endregion

        #region 窗体加载事件
        private void HolidayClassSet_Load(object sender, EventArgs e)
        {
            captionPanel1.Width = this.Width;
            captionPanel1.Height = this.Height - 35;

            dgrd.Width = this.Width;
            dgrd.Height = this.Height - 56;

            ShowOrHiddenControls(true, false);
            BindData();
        }
        #endregion

        #region 显示/隐藏控件函数
        void ShowOrHiddenControls(bool bdgrd, bool budgrd)
        {
            label1.Visible = budgrd;
            label2.Visible = budgrd;
            label3.Visible = budgrd;
            txtCode.Visible = budgrd;
            txtName.Visible = budgrd;
            txtShortName.Visible = budgrd;
            btnModify.Visible = budgrd;
            btnReturn.Visible = budgrd;
            cpModify.Visible = budgrd;

            dgrd.Visible = bdgrd;

        }
        #endregion

        #region 添加按钮的单击事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowOrHiddenControls(false, true);
            btnModify.CaptionTitle = "添 加";
            ClearAll();
        }
        #endregion

        #region 清空函数
        void ClearAll()
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtShortName.Text = "";
        }
        #endregion

        #region 添加/修改按钮的单击事件
        private void btnModify_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            lblErr.ForeColor = Color.Red;
            if (txtCode.Text == "")
            {
                lblErr.Text = "假别代码不能为空!";
                return;
            }
            if (txtName.Text == "")
            {
                lblErr.Text = "假别名称不能为空!";
                return;
            }
            if (txtShortName.Text == "")
            {
                lblErr.Text = "假别简称不能为空!";
                return;
            }
            if (btnModify.CaptionTitle == "修 改")
            {
                //存入日志
                LogSave.Messages("[HolidayTypeSet]", LogIDType.UserLogID, "添加假别，假别代码为："
                    +txtCode.Text+"，假别全称："+txtName.Text+"，假别简称："+txtShortName.Text +"。");
                    
                //HTBLL.HolidayType_Update(Convert.ToInt32(lblID.Text), txtCode.Text, txtName.Text, txtShortName.Text, out strErr);
                if (strErr == "Succeeds")
                {
                    lblErr.ForeColor = Color.Blue;
                    lblErr.Text = "修改成功!";
                }
                else
                {
                    lblErr.Text = strErr;
                }
            }
            else
            {
                //存入日志
                LogSave.Messages("[HolidayTypeSet]", LogIDType.UserLogID, "修改假别，假别代码为："
                    +txtCode.Text+"，假别全称："+txtName.Text+"，假别简称："+txtShortName.Text +"。");

                //HTBLL.HolidayType_Insert(txtCode.Text, txtName.Text, txtShortName.Text, out strErr);
                if (strErr == "Succeeds")
                {
                    lblErr.ForeColor = Color.Blue;
                    lblErr.Text = "添加成功!";
                    ClearAll();
                }
                else
                {
                    lblErr.ForeColor = Color.Red;
                    lblErr.Text = strErr;
                }

            }
        }
        #endregion

        #region DataGridView单元格内容的单击事件
        private void dgrd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblErr.Text = "";
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                ShowOrHiddenControls(false, true);
                btnModify.CaptionTitle = "修 改";
                lblID.Text = dgrd.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCode.Text = dgrd.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtName.Text = dgrd.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtShortName.Text = dgrd.Rows[e.RowIndex].Cells[5].Value.ToString();
                
            }
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                if (MessageBox.Show("你确定要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                     //存入日志
                    LogSave.Messages("[HolidayTypeSet]", LogIDType.UserLogID, "删除假别，假别代码为："+ dgrd.Rows[e.RowIndex].Cells[3].Value.ToString()
                        +"，假别全称："+dgrd.Rows[e.RowIndex].Cells[4].Value.ToString()+"，假别简称："+dgrd.Rows[e.RowIndex].Cells[5].Value.ToString() +"。");

                    HTBLL.HolidayType_Delete(Convert.ToInt32(dgrd.Rows[e.RowIndex].Cells[2].Value.ToString()), out strErr);
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

        #region 返回按钮的单击事件
        private void btnReturn_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            ShowOrHiddenControls(true, false);

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

        #endregion        

        private void bcpRef_Click(object sender, EventArgs e)
        {
            BindData();
        }

    }
}