using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using System.Collections;
using System.Web.UI.WebControls;

namespace KJ128NMainRun
{
    public partial class FrmRTArea : Wilson.Controls.Docking.DockContent
    {
        private DeptBLL dBLL = new DeptBLL();
        private RealTimeBLL rtbll = new RealTimeBLL();
        private AreaBLL ABLL = new AreaBLL();
        private SpecialWorkTypeTerrialSetBLL swtsBLL = new SpecialWorkTypeTerrialSetBLL();
        private string strErr = string.Empty;

        public FrmRTArea()//总页数
        {
            InitializeComponent();
        }

        #region 窗体加载事件
        private void SpecialWorkTypeTerrialSet_Load(object sender, EventArgs e)
        {
            BindComboBox();

            //this.BindRowsSet();

            BindDataGridView();
        }
        #endregion



        #region 绑定下拉列表
        void BindComboBox()
        {

            ABLL.GetTerTypeCmb1(cmbAreaType);
            swtsBLL.Query_TerrialInfo(cmbAreaName, int.Parse(cmbAreaType.SelectedValue.ToString()), 1, out strErr);
        }

        private void cmbAreaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            swtsBLL.Query_TerrialInfo(cmbAreaName, int.Parse(cmbAreaType.SelectedValue.ToString()), 1, out strErr);
        }

        #endregion

        #region 得到返回的条件
        public string GetWhere()
        {
            string[,] strArray = null;
            strArray = new string[4, 4]{{"EmpName","=",TxtEmployeeNameStation.Text,"string"},
                    {"CodeSenderAddress","=",txtBlockIDStation.Text,"string"},
                    {"AreaTypeName","=",cmbAreaType.Text=="所有"?"":cmbAreaType.Text,"string"},
                    {"AreaName","=",cmbAreaName.Text=="所有"?"":cmbAreaName.Text,"string"}
            };

            return rtbll.SelectWhere(strArray, 1);
        }
        #endregion

        #region 绑定DataGridView
        public void BindDataGridView()
        {
            if (txtBlockIDStation.Text != "")
            {
                try
                {
                    int.Parse(txtBlockIDStation.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("标识卡编号只能为数字！");
                    return;
                }
            }
            DataSet ds = rtbll.QueryRTArea(GetWhere());
            if (ds != null && ds.Tables.Count > 0)
            {
                dgrd.DataSource = ds.Tables[0].DefaultView;

                // 将时间精确到秒
                dgrd.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                PanelRowsCount.CaptionTitle = "共" + ds.Tables[0].Rows.Count.ToString() + "人";
            }
           
        }
        #endregion

        #region 查询按钮的单击事件
        private void btnQuery_Click(object sender, EventArgs e)
        {
            BindDataGridView();
        }
        #endregion

        #region 重置按钮的单击事件
        private void btnReset_Click(object sender, EventArgs e)
        {
            TxtEmployeeNameStation.Text = "";
            txtBlockIDStation.Text = "";
        }
        #endregion

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                BindDataGridView();
            }
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (chk.Checked)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}