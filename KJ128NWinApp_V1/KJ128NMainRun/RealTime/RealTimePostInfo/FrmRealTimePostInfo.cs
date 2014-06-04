using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using System.Collections;

namespace KJ128NMainRun
{
    public partial class FrmRealTimePostInfo : Wilson.Controls.Docking.DockContent
    {

        #region 【声明】

        private RealTimePostBLL bll = new RealTimePostBLL();

        private EmpPostBLL epbll = new EmpPostBLL();

        private DataSet ds;

        #endregion

        #region 【构造函数】

        public FrmRealTimePostInfo()
        {
            InitializeComponent();
        }

        #endregion

        #region 【方法：加载区域名称 】

        private bool GetTerrName(ComboBox cmb)
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
                           
                            mylist.Add(new DictionaryEntry("0", "所有"));

                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                mylist.Add(new DictionaryEntry(dr["TerritorialID"].ToString(), dr["TerritorialName"].ToString()));
                            }

                            cmb.DataSource = mylist;
                            cmb.DisplayMember = "Value";
                            cmb.ValueMember = "Key";
                            if (cmb.Items.Count > 0)
                            {
                                cmb.SelectedIndex = 0;
                            }
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }


        #endregion

        #region 【方法：查询】

        private DataTable SelectRealTimePostInfo(string condition)
        {
            return bll.SelectRealTimePostInfo(condition);
        }

        private void BandingDataGridView(string condition)
        {
            DataTable dt = SelectRealTimePostInfo(condition);
            this.dgvMain.DataSource = dt;
            if (dt != null)
            {
                dgvMain.Columns["CodeSenderAddress"].HeaderText = "标识卡编号";
                dgvMain.Columns["EmpName"].HeaderText = "姓名";
                dgvMain.Columns["DeptName"].HeaderText = "部门";
                dgvMain.Columns["TerritorialName"].HeaderText = "岗位区域";
                dgvMain.Columns["IsArrive"].HeaderText = "是否到岗位";
                dgvMain.Columns["BeginTime"].HeaderText = "到岗位时间";
                dgvMain.Columns["BeginTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dgvMain.Columns["TerritorialID"].Visible = false;

                captionPanel1.CaptionTitle = "实时岗位异常信息:\t" + "共 " + dt.Rows.Count.ToString() + " 人";

            }
            else
            {
                captionPanel1.CaptionTitle = "实时岗位异常信息:\t" + "共 0 人";
            }
        }

        #endregion

        #region 【事件：窗体加载】

        private void FrmRealTimePostInfo_Load(object sender, EventArgs e)
        {
            BandingDataGridView("");

            if (!GetTerrName(ddlAreaNameStation))
            {
                MessageBox.Show("加载区域名称信息失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.Activate();
        }

        #endregion

        #region 【事件：查询】

        private void bcpSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string condition = String.Empty;

                if (txtEmpName.Text.Trim() != "")
                {
                    condition = " EmpName like '%" + txtEmpName.Text + "%'";
                }
                else
                {
                    condition = "1=1";
                }

                if (txtCodeSenderAddress.Text.Trim() != "")
                {
                    condition += " and CodeSenderAddress=" + txtCodeSenderAddress.Text;
                }

                if (ddlAreaNameStation.SelectedValue != null && !ddlAreaNameStation.SelectedValue.Equals("0"))
                {
                    condition += " And TerritorialID=" + ddlAreaNameStation.SelectedValue;
                }

                //condition += " and Begintime>='" + dtpBegin.Text + "' and Begintime<='" + dtpEnd.Text + "'";

                BandingDataGridView(condition);
            }
            catch (Exception ex)
            {
                MessageBox.Show("组织查询条件导致SQL查询错误\n错误消息：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region 【事件：实时刷新数据】

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                if (chk.Checked)
                {
                    bcpSearch_Click(null, null);
                }
            }
        }

        #endregion

        #region 【事件：打印】

        private void buttonCaptionPanel1_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvMain, Text);
        }

        #endregion
    }
}
