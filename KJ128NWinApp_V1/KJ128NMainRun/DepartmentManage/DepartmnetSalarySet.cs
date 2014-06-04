using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using System.IO;
using Shine.Logs;
using Shine.Logs.LogType;
using KJ128NDataBase;

namespace KJ128NInterfaceShow
{
    public partial class DepartmnetSalarySet : Wilson.Controls.Docking.DockContent
    {

        #region [ ���� ]

        DeptBLL dBLL = new DeptBLL();
        string strErr = string.Empty;
        static int intDeptID = 0;

        #endregion

        #region [ ���캯�� ]

        public DepartmnetSalarySet()
        {
            InitializeComponent();
        }

        #endregion

        /*
         * ����
         */ 

        #region [ ����: dgrd���ݰ� ]
        public void BindDataGridView()
        {
            string strWhere = string.Empty;
            if (ddlDeptStation.SelectedValue.ToString() != "0")
            {
                strWhere = " where upc.DeptID = "+ddlDeptStation.SelectedValue.ToString();
            }

            DataSet ds = dBLL.GetUnitPriceInfo(strWhere, out strErr);
            if (strErr.ToString() == "Succeeds")
            {
                dgrd.DataSource = ds.Tables[0];
                dgrd.Columns[0].DisplayIndex = 5;
                dgrd.Columns[1].DisplayIndex = 5;
                dgrd.Columns[2].Visible = false;
            }


        }
        #endregion

        /*
         * �¼�
         */ 

        #region [ �¼�: ������� ]

        private void DepartmnetSalarySet_Load(object sender, EventArgs e)
        {
            dBLL.getDeptAddAll(ddlDeptStation);
            dBLL.getDept(ddlAdd);
            gbStation.Visible = false;
            capModify.Visible = false;
            lblErr.Visible = false;
            BindDataGridView();

        }
        #endregion

        #region [ �¼�: ��ѡ��ĵ����¼� ]

        private void ckAll_Click(object sender, EventArgs e)
        {
            if (ckAll.Checked)
            {
                dBLL.getDeptAddAll(ddlAdd);
                ddlAdd.SelectedValue = "0";
                this.ddlAdd.Enabled = false;
            }
            if(!ckAll.Checked)
            {
                if (btnModify.CaptionTitle != "�� ��")
                {
                    this.ddlAdd.Enabled = true;
                    dBLL.getDept(ddlAdd);


                }
                else
                {
                    dBLL.getDept(ddlAdd);
                    ddlAdd.SelectedValue = lblTemp.Text.ToString();
                }
            }
        }
        #endregion

        #region [ �¼�: ��Ӱ�ť�ĵ����¼� ]

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            lblErr.Text = "";
            ckAll.Enabled = true;
            ckAll.Visible = true;
            capModify.Visible = true;
            lblErr.Visible = true;
            gbStation.Visible = true;
            txtUnit.Text = "";
            txtRemark.Text = "";
            ddlAdd.Enabled = true;
            btnModify.CaptionTitle = "�� ��";
            capModify.CaptionTitle = "��Ӳ��Ź�ʱ����";
            ckAll.Checked = false;
            dBLL.getDept(ddlAdd);
            BindDataGridView();
            if (ddlAdd.Items.Count == 0)
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "û�в��Ż���û������Ա����";
                return;
            }

           
        }
        #endregion

        #region [ �¼�: ���ذ�ť�ĵ����¼� ]

        private void btnReturn_Click(object sender, EventArgs e)
        {
            capModify.Visible = false;
            gbStation.Visible = false;
            lblErr.Visible = false;
        }
        #endregion

        #region [ �¼�: ��ѯ��ť�ĵ����¼� ]

        private void btnQuery_Click(object sender, EventArgs e)
        {
            BindDataGridView();
        }
        #endregion

        #region [ �¼�: �޸�/��Ӱ�ť�ĵ����¼� ]

        private void btnModify_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            if (ddlAdd.Items.Count == 0)
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "û�в��Ż���û������Ա����";
                return;
            }

            if (txtUnit.Text.Trim() == "")
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "���۲���Ϊ��!";
                return;
            }
            else
            {
                try
                {
                    Convert.ToDouble(txtUnit.Text.Trim());
                    if (Convert.ToDouble(txtUnit.Text.Trim()) < 0)
                    {
                        lblErr.ForeColor = Color.Red;
                        lblErr.Text = "���۲���Ϊ����!";
                        return;
                    }
                }
                catch
                {
                    lblErr.ForeColor = Color.Red;
                    lblErr.Text = "����ֻ��Ϊ������С��!";
                    return;
                }
            }
            if (btnModify.CaptionTitle == "�� ��")
            {
                //������־
                LogSave.Messages("[DepartmnetSalarySet]", LogIDType.UserLogID, "�޸Ĳ��Ź�ʱ���ۣ����ţ�" + ddlAdd.SelectedText + "�����ۣ�" + txtUnit.Text + "��");

                operated = 3;

                dBLL.UpdateUnitPriceInfo(intDeptID, (float)Convert.ToDouble(txtUnit.Text.ToString()), txtRemark.Text, out strErr);
                if (strErr.ToString() == "Succeeds")
                {
                    lblErr.ForeColor = Color.Blue;
                    lblErr.Text = "�޸ĳɹ�!";

                    if (!New_DBAcess.IsDouble)
                    {
                        BindDataGridView();
                    }
                    else
                    {
                        timer1.Start();
                    }
                }
            }
            else
            {
                //������־
                LogSave.Messages("[DepartmnetSalarySet]", LogIDType.UserLogID, "�����µĲ��Ź�ʱ���ۣ����ţ�" + ddlAdd.SelectedText + "�����ۣ�" + txtUnit.Text + "��");

                if (ckAll.Checked)
                {
                    for (int i = 1; i < ddlAdd.Items.Count; i++)
                    {
                        DataRowView drv = (DataRowView)ddlAdd.Items[i];
                        string strDeptID = drv["DeptID"].ToString();

                        operated = 1;

                        dBLL.InsertUnitPriceInfo(Convert.ToInt32(strDeptID), (float)Convert.ToDouble(txtUnit.Text.ToString()), txtRemark.Text, out strErr);
                        if (strErr == "Succeeds")
                        {
                            lblErr.ForeColor = Color.Blue;
                            lblErr.Text = "��ӳɹ�!";
                            if (!New_DBAcess.IsDouble)
                            {
                                BindDataGridView();
                            }
                            else
                            {
                                timer1.Start();
                            }
                        }
                        else
                        {
                            lblErr.ForeColor = Color.Red;
                            lblErr.Text = "���ʧ��!";
                        }
                    }
                    
                }
                else
                {
                    if (ddlAdd.SelectedValue != null)
                    {
                        operated = 1;

                        dBLL.InsertUnitPriceInfo(Convert.ToInt32(ddlAdd.SelectedValue.ToString()), (float)Convert.ToDouble(txtUnit.Text.ToString()), txtRemark.Text, out strErr);
                        if (strErr == "Succeeds")
                        {
                            lblErr.ForeColor = Color.Blue;
                            lblErr.Text = "��ӳɹ�!";
                            if (!New_DBAcess.IsDouble)
                            {
                                BindDataGridView();
                            }
                            else
                            {
                                timer1.Start();
                            }
                        }
                        else
                        {
                            lblErr.ForeColor = Color.Red;
                            lblErr.Text = "���ʧ��!";
                        }
                    }
                    else
                    {
                        lblErr.ForeColor = Color.Red;
                        lblErr.Text = "������Ӳ���!";
                    }
                }
            }
        }
        #endregion

        #region [ �¼�: DataGridView��Ԫ��ĵ����¼� ]

        private void dgrd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblErr.Text = "";
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                intDeptID = Convert.ToInt32(dgrd.Rows[e.RowIndex].Cells[2].Value.ToString());
                ddlAdd.SelectedValue = dgrd.Rows[e.RowIndex].Cells[2].Value.ToString();
                lblTemp.Text = dgrd.Rows[e.RowIndex].Cells[2].Value.ToString();
                ddlAdd.Enabled = false;
                txtUnit.Text = dgrd.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtRemark.Text = dgrd.Rows[e.RowIndex].Cells[5].Value.ToString();
                gbStation.Visible = true;
                capModify.Visible = true;
                lblErr.Visible = true;
                btnModify.CaptionTitle = "�� ��";
                capModify.CaptionTitle = "�޸Ĳ��Ź�ʱ����";
                ckAll.Checked = false;
                ckAll.Enabled = false;
            }
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                //������־
                LogSave.Messages("[DepartmnetSalarySet]", LogIDType.UserLogID, "ɾ�����Ź�ʱ���ۣ����ţ�" + dgrd.Rows[e.RowIndex].Cells[3].Value + "�����ۣ�" + dgrd.Rows[e.RowIndex].Cells[4].Value + "��");

                if (MessageBox.Show("��ȷ��Ҫɾ����", "��ʾ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    operated = 2;

                    dBLL.DeleteUnitPriceInfo(Convert.ToInt32(dgrd.Rows[e.RowIndex].Cells[2].Value.ToString()),out strErr);
                    if (strErr == "Succeeds")
                    {
                        lblErr.ForeColor = Color.Blue;
                        lblErr.Text = "ɾ���ɹ�!";

                        if (!New_DBAcess.IsDouble)
                        {
                            BindDataGridView();
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

        #region [ �¼�: ����Excel ]

        private void buttonCaptionPanel2_Click(object sender, EventArgs e)
        {
            ExcelExports.ExportDataGridViewToExcel(dgrd);
        }

        #endregion

        #region [�ȱ���ʱˢ��]

        /// <summary>
        /// ���ˢ�´���
        /// </summary>
        private int maxTimes = 2;

        /// <summary>
        /// ��ѯˢ�´���
        /// </summary>
        private int times = 0;

        /// <summary>
        /// 1��ʾ ���ӣ��޸� 2 ��ʾɾ��,3��ʾ�޸�
        /// </summary>
        private int operated = 1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            //����
            if (operated == 1)
            {
                string value = ddlAdd.SelectedValue.ToString();

                if (RecordSearch.IsRecordExists("UnitPrice", "DeptID", value, DataType.Int))
                {
                    //ˢ��

                    BindDataGridView();

                    times = 0;
                    //�ر�timer1
                    timer1.Stop();
                }
                else
                {
                    if (times < maxTimes)
                    {
                        times++;
                        timer1.Stop();
                        timer1.Start();
                    }
                    else
                    {
                        times = 0;
                        //�ر�timer1
                        timer1.Stop();
                    }
                }
            }
            //ɾ��
            else if (operated == 2)
            {
                string value = dgrd.CurrentRow.Cells[2].Value.ToString();

                if (!RecordSearch.IsRecordExists("UnitPrice", "DeptID", value, DataType.Int))
                {
                    //ˢ��

                    BindDataGridView();

                    times = 0;
                    //�ر�timer1
                    timer1.Stop();
                }
                else
                {
                    if (times < maxTimes)
                    {
                        times++;
                        timer1.Stop();
                        timer1.Start();
                    }
                    else
                    {
                        times = 0;
                        //�ر�timer1
                        timer1.Stop();
                    }
                }
            }
            //�޸�
            else
            {
                string strWhere = "DeptID=" + ddlAdd.SelectedValue.ToString()
                    + "and UnitPrice=" + txtUnit.Text
                    + " and Remark ='" + txtRemark.Text + "'";

                if (RecordSearch.IsRecordExists("UnitPrice", strWhere))
                {
                    //ˢ��
                    BindDataGridView();

                    times = 0;
                    //�ر�timer1
                    timer1.Stop();
                }
                else
                {
                    if (times < maxTimes)
                    {
                        times++;
                        timer1.Stop();
                        timer1.Start();
                    }
                    else
                    {
                        times = 0;
                        //�ر�timer1
                        timer1.Stop();
                    }
                }
            }
        }

        #endregion        

        private void bcpRef_Click(object sender, EventArgs e)
        {
            BindDataGridView();
        }
    }
}