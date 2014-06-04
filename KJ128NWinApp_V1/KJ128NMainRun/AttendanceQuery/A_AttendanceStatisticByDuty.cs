using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NDataBase;
using KJ128NMainRun;
namespace KJ128NInterfaceShow
{
    public partial class AttendanceStatisticByDuty : KJ128NMainRun.FromModel.FrmModel
    {

        #region [ ���� ]

        DeptBLL dBLL = new DeptBLL();
        AttendanceBLL aBLL = new AttendanceBLL();
        string strErr = string.Empty;

        #endregion

        #region [ ���캯�� ]

        public AttendanceStatisticByDuty()
        {
            InitializeComponent();
            base.Text = "�����Ÿɲ��¾�ͳ�Ʊ���";
            base.lblMainTitle.Hide();
            base.btnAdd.Hide();
            base.btnSelectAll.Hide();
            base.btnLaws.Hide();
            base.btnDelete.Hide();
            base.btnUpPage.Hide();
            base.lblPageCounts.Hide();
            base.lblSumPage.Hide();
            base.btnDownPage.Hide();
            base.txtSkipPage.Hide();
            base.cmbSelectCounts.Hide();
            base.label6.Hide();
            base.label7.Hide();
            base.label8.Hide();
            base.label9.Hide();
        }

        #endregion

        /*
         * ����
         */ 

        #region [ ����: DataGridView�󶨺��� ]

        void BindDataGridView()
        {
            lblCounts.Text = "";
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
            #region �õ���ѯ����
            string strWhere = string.Empty;
            string strTime = string.Empty;

            strWhere = " and DataAttendance >='" + dtpStartTime.Text + "' and DataAttendance <='" + dtpEndTime.Text + "'";

            if (ddlDept.SelectedValue.ToString() != "0")
            {
                strTime = " en.DeptID =" + ddlDept.SelectedValue.ToString();
            }
            if (ddlDuty.SelectedValue.ToString() != "0")
            {
                if (strTime != "")
                {
                    strTime = strTime + " and en.DutyID =" + ddlDuty.SelectedValue.ToString();
                }
                else
                {
                    strTime = " en.DutyID =" + ddlDuty.SelectedValue.ToString();
                }
            }
            if (this.txtEmployeeName.Text.Trim() != "")
            {
                if (strTime != "")
                {
                    strTime = strTime + " and ei.EmpName like ('" + txtEmployeeName.Text.Trim() + "')";
                }
                else
                {
                    strTime = " ei.EmpName like ('" + txtEmployeeName.Text.Trim() + "')";
                }
            }
            if (txtBlock.Text.Trim() != "")
            {
                if (strTime != "")
                {
                    strTime = strTime + " and A.���� = " + txtBlock.Text.Trim();
                }
                else
                {
                    strTime = " A.���� = " + txtBlock.Text.Trim();
                }
            }
            if (strTime != "")
            {
                strTime = " where " + strTime;
            }
            #endregion
            strWhere += " And EmployeeID is not null ";
            DataSet ds = aBLL.GetAttendanceStatisticByDuty(strWhere, strTime, out strErr);

            if (strErr.ToString() == "Succeeds")
            {
                ds.Tables[0].Columns[1].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);

                dgrd.DataSource = ds.Tables[0];
               
                dgrd.AddSpanHeader(6, 3, "�� ��");

                lblCounts.ForeColor = Color.Blue;
                lblCounts.Text = "���� " + ds.Tables[0].Rows.Count.ToString() + " ����¼";
            }
        }

        #endregion

        /*
         * �¼�
         */ 

        #region [ �¼�: ������� ]

        private void AttendanceStatisticByDuty_Load(object sender, EventArgs e)
        {
           
            dtpStartTime.Text = DateTime.Now.ToString("yyyy-MM") + "-01";
            dtpEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dBLL.getDeptAddAll(ddlDept);
            dBLL.getDutyNameCmb(ddlDuty);
            BindDataGridView();
        }

        #endregion

        #region [ �¼�: ��ѯ��ť�ĵ����¼� ]

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (dtpStartTime.Text.Trim() == "" || dtpEndTime.Text.Trim() == "")
            {
                MessageBox.Show("��ʼ�ͽ���ʱ�䶼����Ϊ�գ�");
                return;
            }
            if (DateTime.Compare(DateTime.Parse(dtpStartTime.Text), DateTime.Parse(dtpEndTime.Text)) > 0)
            {
                MessageBox.Show("��ʼʱ�䲻�ܴ��ڽ���ʱ�䣬������ѡ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DateTime.Compare(DateTime.Parse(dtpStartTime.Text), DateTime.Parse(dtpEndTime.Text)) > 7)
            {
                MessageBox.Show("��ʼʱ��ͽ���ʱ��֮���������ܴ���7�죬������ѡ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dtpEndTime.Value > DateTime.Now)
            {
                MessageBox.Show("����ʱ�䲻�ܴ��ڵ�ǰʱ�䣬������ѡ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BindDataGridView();
        }

        #endregion

        #region���¼�����ӡ��

        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgrd, "���ɲ��¾�ͳ��", "��" + dgrd.Rows.Count.ToString() + "����¼");
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

        private void txtEmployeeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
        


    }
}