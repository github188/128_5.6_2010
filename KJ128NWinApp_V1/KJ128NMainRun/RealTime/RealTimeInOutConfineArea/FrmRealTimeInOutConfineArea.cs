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
    public partial class FrmRealTimeInOutConfineArea : Wilson.Controls.Docking.DockContent
    {
        private RealTimeInOutConfineAreaBLL bll = new RealTimeInOutConfineAreaBLL();

        private string strCounts = string.Empty;

        #region 【 构造函数 】

        public FrmRealTimeInOutConfineArea()
        {
            InitializeComponent();
        }

        #endregion


        private void InitialzeDeptComboBox()
        {
            DataTable dt = GetDeptInfo();

            if (dt != null)
            {
                this.cbDept.DisplayMember = "DeptName";
                this.cbDept.ValueMember = "DeptId";
                this.cbDept.DataSource = dt;
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

        private void FrmRealTimeInOutConfineArea_Load(object sender, EventArgs e)
        {
            dtpBegin.Text = DateTime.Today.ToString();
            dtpEnd.Text = DateTime.Now.ToString();

            //加载部门信息
            InitialzeDeptComboBox();

            //加载限制区域名称信息
            InitialzeConfineAreaComboBox();

            //查询
            bcpSelect_Click(null, null);
        }

        private DataTable GetConfineAreaInfo()
        {
            DataTable dt = DataHelper.GetConfineAreaInfo();

            if (dt != null)
            {
                DataRow dr = dt.NewRow();

                dr["TerritorialID"] = "0";
                dr["TerritorialName"] = "所有";

                dt.Rows.InsertAt(dr, 0);
            }
            return dt;
        }

        private void InitialzeConfineAreaComboBox()
        {
            DataTable dt = GetConfineAreaInfo();

            if (dt != null)
            {
                this.cbArea.DisplayMember = "TerritorialName";
                this.cbArea.ValueMember = "TerritorialID";
                this.cbArea.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    this.cbArea.SelectedIndex = 0;
                }
            }
        }

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
                bll = new RealTimeInOutConfineAreaBLL();
            }

            DataTable dt = bll.SelectRealTimeInOutConfineAreaInfo(strSQL);
            if (dt != null)
            {
                strCounts = dt.Rows.Count.ToString();
            }
            else
            {
                strCounts = "0";
            }

            buttonCaptionPanel1.CaptionTitle = "实时进出限制区域信息显示：\t\t共 " + strCounts + " 人次";

            this.dgvMain.DataSource = dt;

        }


        #region 【 事件: 定时刷新 】

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated && chk.Checked)
            {
                this.dtpEnd.Text = DateTime.Now.ToString();

                bcpSelect_Click(sender, e);
            }
        }

        #endregion

        #region 【 事件: 打印 】

        private void cpStationToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvMain, this.Text, "共 " + strCounts + " 人次");
        }

        #endregion
    }
}
