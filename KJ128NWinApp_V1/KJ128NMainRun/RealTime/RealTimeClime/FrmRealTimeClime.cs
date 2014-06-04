using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDataBase;
using KJ128NDBTable;

namespace KJ128NMainRun
{
    public partial class FrmRealTimeClime : Wilson.Controls.Docking.DockContent
    {

        #region 【 声明 】

        private string strCounts = string.Empty; 

        private RealTimeClimeBLL bll = new RealTimeClimeBLL();

        #endregion

        #region 【 构造函数 】

        public FrmRealTimeClime()
        {
            InitializeComponent();
        }

        #endregion



        #region 【 事件: 窗体加载 】

        private void FrmRealTimeClime_Load(object sender, EventArgs e)
        {
            dtpBegin.Text = DateTime.Today.ToString();
            dtpEnd.Text = DateTime.Now.ToString();

            //加载部门信息
            InitialzeDeptComboBox();

            //加载地域名称信息
            InitialzeClimeComboBox();

            dtpBegin.Text = DateTime.Today.ToString();
            dtpEnd.Text = DateTime.Now.ToString();

            bcpSelect_Click(sender, e);
        }

        #endregion

        #region 【 事件: 查询地域信息 】


        private void bcpSelect_Click(object sender, EventArgs e)
        {
            string strSQL = string.Empty;

            strSQL = " InTerritorialTime >='" + dtpBegin.Text + "' And InTerritorialTime <='" + dtpEnd.Text + "' ";

            if (!cbDept.SelectedValue.Equals(0))
            {
                strSQL += " And Dei.DeptID=" + cbDept.SelectedValue.ToString();
            }

            if (!txtEmpName.Text.Trim().Equals(""))
            {
                strSQL += " And EmpName like '%" + txtEmpName.Text.Trim() + "%' ";
            }

            if (!txtCodeSenderAddress.Text.Trim().Equals(""))
            {
                strSQL += " And CodeSenderAddress =" + txtCodeSenderAddress.Text.Trim();
            }

            if (cbArea.SelectedValue != null)
            {
                if (!cbArea.SelectedValue.Equals(0))
                {
                    strSQL += " And TerritorialID = " + cbArea.SelectedValue.ToString();
                }
            }


            if (bll == null)
            {
                bll = new RealTimeClimeBLL();
            }

            DataTable dt = bll.SelectRealTimeClimeInfo(strSQL);
            if (dt != null)
            {
                strCounts = dt.Rows.Count.ToString();
            }
            else
            {
                strCounts = "0";
            }

            buttonCaptionPanel1.CaptionTitle = "实时地域信息显示：\t\t共 " + strCounts + " 人次";

            this.dgvMain.DataSource = dt;

        }

        #endregion

        #region 【 事件: 定时刷新 】

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated && chk.Checked)
            {
                this.dtpEnd.Text = DateTime.Now.ToString();

                bcpSelect_Click(null, null);
            }
        }

        #endregion

        #region 【 事件: 打印 】

        private void cpStationToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvMain, this.Text, "共 " + strCounts + " 人次");
        }

        #endregion


        #region 【 方法: 加载部门信息】

        private void InitialzeDeptComboBox()
        {
            DataTable dt = GetDeptInfo();

            this.cbDept.DisplayMember = "DeptName";
            this.cbDept.ValueMember = "DeptId";
            this.cbDept.DataSource = dt;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    this.cbDept.SelectedIndex = 0;
                }
            }
        }

        private DataTable GetDeptInfo()
        {
            DataTable dt = DataHelper.GetDeptInfo();

            if (dt != null)
            {
                DataRow dr = dt.NewRow();

                dr["DeptId"] = "0";
                dr["DeptName"] = "所有";

                dt.Rows.InsertAt(dr, 0);
            }
            return dt;
        }

        #endregion

        #region 【 方法：加载地域名称 】

        private DataTable GetClimeInfo()
        {
            DataTable dt = DataHelper.GetClimeInfo();

            if (dt != null)
            {
                DataRow dr = dt.NewRow();

                dr["TerritorialID"] = "0";
                dr["TerritorialName"] = "所有";

                dt.Rows.InsertAt(dr, 0);
            }
            return dt;
        }

        private void InitialzeClimeComboBox()
        {
            DataTable dt = GetClimeInfo();

            this.cbArea.DisplayMember = "TerritorialName";
            this.cbArea.ValueMember = "TerritorialID";
            this.cbArea.DataSource = dt;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    this.cbArea.SelectedIndex = 0;
                }
            }
        }

        #endregion
    }
}
