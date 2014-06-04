using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NDataBase;
namespace KJ128NInterfaceShow
{
    public partial class AttendanceQuerySalary :KJ128NMainRun.FromModel.FrmModel
    {

        #region [ ���� ]

        DeptBLL dBLL = new DeptBLL();
        AttendanceBLL aBLL = new AttendanceBLL();
        string strErr = string.Empty;

        #endregion


        #region [ ���캯�� ]

        public AttendanceQuerySalary()
        {
            InitializeComponent();
            base.Text = "Ա�������Ͷ�����";
            base.lblMainTitle.Hide();
            base.btnAdd.Hide();
            base.btnSelectAll.Hide();
            base.btnLaws.Hide();
            base.btnDelete.Hide();
            base.btnUpPage.Hide();
            base.lblPageCounts.Hide();
            base.lblSumPage.Hide();
            base.btnDownPage.Hide();
            base.label6.Hide();
            base.txtSkipPage.Hide();
            base.label7.Hide();
            base.label8.Hide();
            base.cmbSelectCounts.Hide();
            base.label9.Hide();
            lblCounts.Text = "";
        }

        #endregion

        /*
         * �¼�
         */ 

        #region[ ����: DataGridView���ݰ� ]

        void BindDataGridView()
        {
            lblErr.Text = "";
            if (txtBlock.Text.ToString() != "")
            {
                try
                {
                    Convert.ToInt32(txtBlock.Text);
                }
                catch
                {
                    lblCounts.ForeColor = Color.Red;
                    lblCounts.Text = "����ֻ��Ϊ���֣�";
                    return;
                }
            }
            if (txtStandardTime.Text == "")
            {
                lblCounts.ForeColor = Color.Red;
                lblCounts.Text = "���ʱ����Ϊ��!";
                return;
            }
            if (this.txtStandardTime.Text.ToString() != "")
            {
                try
                {
                    Convert.ToInt32(this.txtStandardTime.Text);
                }
                catch
                {
                    lblCounts.ForeColor = Color.Red;
                    lblCounts.Text = "���ʱֻ��Ϊ���֣�";
                    return;
                }
            }
            string strWhere = " and DataAttendance >='" + dtpStartTime.Text.ToString() + "' and DataAttendance <='" + dtpEndTime.Text.ToString() + "'";
            if (ddlDept.SelectedValue.ToString() != "0")
            {
                strWhere = strWhere + " and DeptID = " + ddlDept.SelectedValue.ToString();
            }

            if (txtEmployeeName.Text.ToString() != "")
            {
                strWhere = strWhere + " and EmployeeName = '" + txtEmployeeName.Text.ToString() + "'";
            }

            if (txtBlock.Text.ToString() != "")
            {
                strWhere = strWhere + " and BlockID = " + txtBlock.Text.ToString();
               
            }

            DataSet ds = aBLL.GetAttendanceSalary(strWhere,Convert.ToInt32(txtStandardTime.Text), out strErr);

            if (strErr.ToString() == "Succeeds")
            {
                ds.Tables[0].Columns[2].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);

                dgrd.DataSource = ds.Tables[0];
                lblCounts.ForeColor = Color.Blue;
                lblCounts.Text = "���� " + ds.Tables[0].Rows.Count.ToString() + " ����¼";
            }
        }

        #endregion

        /*
         * �¼�
         */ 

        #region [ �¼�: ������� ]

        private void AttendanceQuerySalary_Load(object sender, EventArgs e)
        {
            dtpStartTime.Text = DateTime.Now.ToString("yyyy-MM") + "-01";
            dtpEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd");

            dBLL.getDeptAddAll(ddlDept);
            BindDataGridView();
            
        }

        #endregion

        #region [ �¼�: ��ѯ��ť_Click�¼� ]

        private void btnQuery_Click(object sender, EventArgs e)
        {
            BindDataGridView();
        }

        #endregion

    
      

    }
}