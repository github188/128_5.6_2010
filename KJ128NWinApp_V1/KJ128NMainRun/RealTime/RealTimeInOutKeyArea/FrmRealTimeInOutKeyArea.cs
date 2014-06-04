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
    public partial class FrmRealTimeInOutKeyArea : Wilson.Controls.Docking.DockContent
    {

        #region 【 声明 】

        private RealTimeInOutKeyAreaBLL rtika = new RealTimeInOutKeyAreaBLL();

        private string strCounts = string.Empty;

        #endregion

        #region 【 构造函数 】

        public FrmRealTimeInOutKeyArea()
        {
            InitializeComponent();
        }

        #endregion

        #region 【 方法: 初始化 】

        private void InitialzeDeptComboBox()
        {
            DataTable dt = GetDeptInfo();

            DataRow dr = dt.NewRow();
            dr["DeptId"] = 0;
            dr["DeptName"] = "所有";
            dt.Rows.InsertAt(dr, 0);

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
            dtpBegin.Text = DateTime.Today.ToString();
            dtpEnd.Text = DateTime.Now.ToString();
        }

        #endregion

        #region 【 方法: 加载区域名称 】

        private DataTable GetKeyAreaInfo()
        {
            DataTable dt = DataHelper.GetKeyAreaInfo();

            if (dt != null)
            {
                DataRow dr = dt.NewRow();

                dr["TerritorialID"] = "0";
                dr["TerritorialName"] = "所有";

                dt.Rows.InsertAt(dr, 0);
            }
            return dt;
        }

        private void InitialzeKeyAreaComboBox()
        {
            DataTable dt = GetKeyAreaInfo();

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

        #region 【 方法: 加载部门名称 】

        private DataTable GetDeptInfo()
        {
            return DataHelper.GetDeptInfo();
        }

        #endregion

        #region 【 事件: 窗体加载事件 】

        private void FrmRealTimeInOutKeyArea_Load(object sender, EventArgs e)
        {
            //加载部门信息
            InitialzeDeptComboBox();

            //加载区域名称
            InitialzeKeyAreaComboBox();

            //查询
            bcpSelect_Click(sender, e);
        }

        #endregion

        #region 【 事件: 查询重点区域信息 】

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


            if (rtika == null)
            {
                rtika = new RealTimeInOutKeyAreaBLL();
            }

            DataTable dt = rtika.SelectRealTimeInOutKeyAreaInfo(strSQL);
            if (dt != null)
            {
                strCounts = dt.Rows.Count.ToString();
            }
            else
            {
                strCounts = "0";
            }

            buttonCaptionPanel1.CaptionTitle = "实时进出重点区域信息显示：\t\t共 " + strCounts + " 人次";

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
            PrintBLL.Print(dgvMain, this.Text, "共 "+strCounts+" 人次");
        }

        #endregion
    }
}
