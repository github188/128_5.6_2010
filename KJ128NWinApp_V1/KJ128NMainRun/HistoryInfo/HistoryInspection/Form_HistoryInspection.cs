using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using PrintCore;

namespace KJ128NMainRun.HistoryInfo.HistoryInspection
{
    public partial class Form_HistoryInspection : KJ128NMainRun.FromModel.FrmModel
    {

        #region【声明】

        private A_HisPathBLL hpbll = new A_HisPathBLL();

        private A_TreeBLL tbll = new A_TreeBLL();

        private DataSet ds;

        private string strWhere = " 1=1";

        /// <summary>
        /// 每页条数
        /// </summary>
        private static int pSize = 40;

        /// <summary>
        /// 查询到记录的总页数
        /// </summary>
        private int countPage;

        #endregion

        #region【构造函数】

        public Form_HistoryInspection()
        {
            InitializeComponent();
            
            dtp_Begin.Value = DateTime.Now.Date;
            dtp_End.Value = DateTime.Now;

            LoadTree();
        }

        #endregion


        #region【窗体加载】

        private void Form_HistoryInspection_Load(object sender, EventArgs e)
        {
            cmbSelectCounts.Text = "40";

            //默认查询人员信息
            //strWhere = StrWhere();
            //Select_Territorial_Emp(1);
        }

        #endregion



        #region【方法：加载树】

        /// <summary>
        /// 加载树
        /// </summary>
        private void LoadTree()
        {
            using (ds = new DataSet())
            {
                ds = hpbll.GetPathTree();
                tvc_Path.Nodes.Clear();
                tbll.LoadTree(tvc_Path, ds, "人", false, "所有");
                tvc_Path.ExpandAll();
            }
        }

        #endregion

        #region【方法：控制翻页状态】

        private void SetPageEnable(int pIndex, int sumPage)
        {
            if (pIndex == 1)
            {
                if (sumPage == 1)
                {
                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = true;
                }
            }
            else if (pIndex >= sumPage)
            {
                btnUpPage.Enabled = true;
                btnDownPage.Enabled = false;
            }
            else
            {
                btnUpPage.Enabled = true;
                btnDownPage.Enabled = true;
            }
        }

        #endregion

        #region 【方法: 组织查询条件】

        private string StrWhere()
        {
            string strTempWhere = " 开始时间 >= '" + dtp_Begin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' And 开始时间 <='" + dtp_End.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' ";

            if (tvc_Path.SelectedNode != null && !tvc_Path.SelectedNode.Name.Equals("0"))
            {
                strTempWhere += " And 巡检路线 = '" + tvc_Path.SelectedNode.Tag.ToString() + "' ";
            }

            if (!txt_EmpName.Text.Trim().Equals(""))
            {
                strTempWhere += " And 姓名 like  '%" + txt_EmpName.Text.Trim() + "%' ";

            }

            if (!txt_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And 标识卡号 = " + txt_CodeSenderAddress.Text.Trim();
            }

            return strTempWhere;
        }

        #endregion

        #region【方法：查询——人员】

        public void Select_Territorial_Emp(int pIndex)
        {
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }

            DataSet ds = hpbll.GetInfo_HisPath(pIndex, pSize, strWhere);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                if (sumPage == 0)
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    lblMainTitle.Text = "历史巡检：  共 0 人";
                    lblCounts.Text = "共 0 条记录";

                    lblPageCounts.Text = "1";
                    lblSumPage.Text = "/1页";

                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    lblMainTitle.Text = "历史巡检：  共 " + ds.Tables[2].Rows[0][0].ToString() + " 人";
                    lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条记录";

                    lblPageCounts.Text = pIndex.ToString();
                    lblSumPage.Text = "/" + sumPage + "页";

                    //控制翻页状态
                    SetPageEnable(pIndex, sumPage);
                }
                if (dgv_Main.Columns.Count >= 10)
                {
                    dgv_Main.Columns["开始时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    dgv_Main.Columns["结束时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    dgv_Main.Columns["HisPathID"].Visible = false;

                    dgv_Main.Columns["标识卡号"].DisplayIndex = 0;
                    dgv_Main.Columns["姓名"].DisplayIndex = 1;
                    dgv_Main.Columns["部门"].DisplayIndex = 2;
                    dgv_Main.Columns["职务"].DisplayIndex = 3;
                    dgv_Main.Columns["工种"].DisplayIndex = 4;
                    dgv_Main.Columns["班次"].DisplayIndex = 5;
                    dgv_Main.Columns["巡检路线"].DisplayIndex = 6;
                    dgv_Main.Columns["开始时间"].DisplayIndex = 7;
                    dgv_Main.Columns["结束时间"].DisplayIndex = 8;
                    dgv_Main.Columns["持续时长"].DisplayIndex = 9;

                    dgv_Main.Columns["职务"].DefaultCellStyle.NullValue = "——";
                    dgv_Main.Columns["工种"].DefaultCellStyle.NullValue = "——";
                }
            }
        }
        #endregion

        #region【方法：判断时间】

        private bool DecideTime(DateTimePicker dtpBegin, DateTimePicker dtpEnd)
        {
            if (dtpEnd.Value > DateTime.Now)
            {
                dtpEnd.Value = DateTime.Now;
            }
            if (dtpBegin.Value >= dtpEnd.Value)
            {
                MessageBox.Show("开始时间不能大于结束时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (dtpBegin.Value.AddDays(7) < dtpEnd.Value)
            {
                MessageBox.Show("开始时间与结束时间相差不能大于7天！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            return true;
        }

        #endregion


        #region【事件：查询】

        private void bt_Enquiries_Click(object sender, EventArgs e)
        {
            if (DecideTime(dtp_Begin, dtp_End))
            {
                strWhere = StrWhere();
                Select_Territorial_Emp(1);
            }
        }

        #endregion

        #region【事件：重置】

        private void bt_Reset_Click(object sender, EventArgs e)
        {
            txt_CodeSenderAddress.Text = "";
            txt_EmpName.Text = "";
        }

        #endregion

        #region【事件：选择路线名称】

        private void tvc_Path_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strWhere = StrWhere();
            Select_Territorial_Emp(1);
        }

        #endregion

        #region【事件：打印】

        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgv_Main, "历史路线巡检信息", lblCounts.Text);
        }

        #endregion

        #region【事件：上一页】

        private void btnUpPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page--;
            if (page < 1)
            {
                return;
            }

            Select_Territorial_Emp(page);
        }

        #endregion

        #region【事件：下一页】

        private void btnDownPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page++;

            if (page > countPage)
            {
                return;
            }

            Select_Territorial_Emp(page);
        }

        #endregion

        #region【事件：跳至】

        private void txtSkipPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                string value = txtSkipPage.Text;
                if (value.CompareTo("") == 0)       //为空值时
                {
                    return;
                }
                else if (int.Parse(value) > 0)
                {
                    int page = int.Parse(value);
                    if (page > countPage)
                    {
                        page = countPage;
                    }

                    Select_Territorial_Emp(page);
                }
            }
        }

        #endregion

        #region【事件：选择每页显示条数】

        private void cmbSelectCounts_DropDownClosed(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cmbSelectCounts.SelectedItem);

            Select_Territorial_Emp(1);
        }

        #endregion

        private IButtonControl IB = null;
        private void txtSkipPage_Enter(object sender, EventArgs e)
        {
            this.IB = this.AcceptButton;
            this.AcceptButton = null;
        }

        private void txtSkipPage_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = this.IB;
        }

        private void txt_EmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

    }
}
