using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using System.Threading;
using System.Collections;
using KJ128NDataBase;

namespace KJ128NMainRun.HistoryInfo
{
    public partial class FrmStatMonthEmpInMine : Wilson.Controls.Docking.DockContent
    {
        private HisStatEmpInMineBLL bll = new HisStatEmpInMineBLL();
        /// <summary>
        /// ÿҳ��ʾ����
        /// </summary>
        private int pSize = 30;

        /// <summary>
        /// ��ѯ�������ҳ��
        /// </summary>
        private int countPage;
        private string where = "";
        private string date = "";

        public FrmStatMonthEmpInMine()
        {
            InitializeComponent();
            date = DateTime.Now.Year.ToString();
            BindCmd();

            label4.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + ":";

            SelectInfo(1);


        }

        #region [ ����: ������ ]

        private void BindCmd()
        {
            int iYear = DateTime.Now.Year;
            for (int i = iYear - 5; i < iYear + 5; i++)
            {
                cmbYear.Items.Add(i.ToString());
            }
            cmbYear.SelectedIndex = 5;

            //�󶨲��š�����
            DeptBLL deptbll = new DeptBLL();
            deptbll.getWorkTypeCmb(cmbWorkType);    // ����
            deptbll.getDeptAddAll(cmbDept);  // ����
        }

        #endregion

        #region [ ����: ��ҳ ]
        //��һҳ
        private void cpUp_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page--;
            cpDown.Cursor = Cursors.Hand;
            cpDown.Enabled = true;
            if (page == 1)
            {
                cpUp.Enabled = false;
            }
            else if (page < 1)
            {
                return;
            }
            SelectInfo(page);
        }

        //��һҳ
        private void cpDown_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page++;
            cpUp.Enabled = true;
            if (page == countPage)
            {
                cpDown.Enabled = false;
            }
            else if (page > countPage)
            {
                return;
            }
            SelectInfo(page);
        }


        //����
        private void cpCheckPage_Click(object sender, EventArgs e)
        {
            string value = txtCheckPage.Text;
            if (value.CompareTo("") == 0)
            {
                return;
            }
            else if (int.Parse(value) > 0)
            {
                int page = int.Parse(value);
                if (page == 1)
                {
                    cpUp.Enabled = false;
                    cpDown.Enabled = true;
                }
                else if (page == countPage)
                {
                    cpUp.Enabled = true;
                    cpDown.Enabled = false;
                }
                else
                {
                    cpUp.Enabled = true;
                    cpDown.Enabled = true;
                }
                if (page > countPage)
                {
                    page = countPage;
                    cpUp.Enabled = true;
                    cpDown.Enabled = false;
                }
                SelectInfo(page);
            }
        }
        #endregion

        #region [ ����: ��ҳ��ѯ ]

        /// <summary>
        /// ��ҳ��ѯ
        /// </summary>
        /// <param name="pIndex">�ڼ�ҳ</param>
        private void SelectInfo(int pIndex)
        {
            if (pIndex < 1)
            {
                MessageBox.Show("�������ҳ��������Χ,����ȷ����ҳ����");
                return;
            }
            dgvkj128Data.Columns.Clear();
            DataSet ds = bll.StatMonthEmp(date, pIndex, pSize,where,rbtnCount.Checked?"0":"1");

            if (ds != null && ds.Tables.Count > 0)
            {
                // ��������ҳ��
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;

                if (pIndex > sumPage)
                {
                    if (sumPage == 0)
                    {
                        dgvkj128Data.Columns.Clear();
                        dgvkj128Data.DataSource = ds.Tables[0];

                        bcpPageSum.CaptionTitle = "0 ��";
                        pageControlsVisible(false);
                        return;
                    }
                    // �������һҳ
                    return;
                }
                bcpPageSum.CaptionTitle = "�� " + ds.Tables[1].Rows[0][0].ToString() + " ��";
                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "ҳ";
                dgvkj128Data.Columns.Clear();
                dgvkj128Data.DataSource = ds.Tables[0];
                dgvkj128Data.Columns["EmpID"].Visible = false;
                AddColumns(dgvkj128Data);
                #region ���ơ���һҳ��������һҳ���Ȱ�ť����ʾ״̬
                if (Convert.ToInt32(ds.Tables[1].Rows[0][0]) <= pSize)
                {
                    pageControlsVisible(false);
                }
                else
                {
                    pageControlsVisible(true);
                }
                #endregion
            }
            else
            {
                pageControlsVisible(false);
            }
        }

        #endregion

        #region [ ����: ��Ӳ鿴�� ]

        private void AddColumns(DataGridView dgvTmep)
        {
            DataGridViewLinkColumn dgvLink = new DataGridViewLinkColumn();
            dgvLink.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvLink.HeaderText = "�鿴Ա����Ϣ";
            dgvLink.Name = "EmpInfo";
            dgvLink.Text = "�鿴";
            dgvLink.UseColumnTextForLinkValue = true;
            dgvLink.Resizable = DataGridViewTriState.False;
            dgvTmep.Columns.Add(dgvLink);
        }

        #endregion

        #region [ �¼�: ����DataGridView��Ԫ�� ]

        private void dgvRTInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvkj128Data.Columns[e.ColumnIndex].HeaderText.Equals("�鿴Ա����Ϣ") && e.RowIndex >= 0)
            {
                string strCodeSenderAddress = dgvkj128Data.Rows[e.RowIndex].Cells["EmpID"].Value.ToString();
                FrmEmpInfo frm = new FrmEmpInfo(strCodeSenderAddress, true);
                frm.ShowDialog();

                frm.Dispose();
            }
        }

        #endregion

        #region [ ����: ���������ҳ����ʾ ]

        /// <summary>
        /// ���������ҳ����ʾ
        /// </summary>
        /// <param name="bl"></param>
        private void pageControlsVisible(bool bl)
        {
            bcpPageSum.Visible = bl;
            cpUp.Visible = bl;
            cpDown.Visible = bl;
            txtPage.Visible = bl;
            lblSumPage.Visible = bl;
            txtCheckPage.Visible = bl;
            cpCheckPage.Visible = bl;
            buttonCaptionPanel12.Visible = bl;
            label1.Visible = bl;
        }

        #endregion

        #region [ ����: ��֯��ѯ���� ]

        private string strWhere()
        {
            RealTimeBLL rtbll = new RealTimeBLL();
            //if ()
            string[,] strArray = null;
            string str = string.Empty;
            if (chkLead.Checked)
            {
                str = string.Format("(select EnumID from EnumTable"
                        + " where FunID = 4 and EnumValue = '1')");
            }
            if (!chkLead.Checked)
            {
                strArray = new string[5, 4]{{"cs.CodeSenderAddress","=",txtCodeSender.Text,"int"},
                            {"ei.EmpName","=",txtEmpName.Text,"string"},
                            {"ew.WorkTypeID","=",cmbWorkType.SelectedValue.ToString()=="0"?"":cmbWorkType.SelectedValue.ToString(),"int"},
                            {"enc.DeptID","=",cmbDept.SelectedValue.ToString()=="0"?"":cmbDept.SelectedValue.ToString(),"int"},
                            {"di.DutyClassID","in",str,"int"}
                };
            }
            else
            {
                
                strArray = new string[5, 4]{{"cs.CodeSenderAddress","=",txtCodeSender.Text,"int"},
                            {"ei.EmpName","=",txtEmpName.Text,"string"},
                            {"ew.WorkTypeID","=",cmbWorkType.SelectedValue.ToString()=="0"?"":cmbWorkType.SelectedValue.ToString(),"int"},
                            {"enc.DeptID","=",cmbDept.SelectedValue.ToString()=="0"?"":cmbDept.SelectedValue.ToString(),"int"},
                            {"di.DutyClassID","in",str,"int"}
                };
            }
            return rtbll.SelectWhere(strArray, 0);
        }

        #endregion

        #region ��ѯ ����¼� Click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dgvkj128Data.Visible == true)
            {
                // ��֯��ѯ����
                date=cmbYear.Text;
                where = strWhere();
                SelectInfo(1);      //��ҳ��ѯ
                cpUp.Enabled = false;
                cpDown.Enabled = true;
            }
        }
        #endregion

        #region [ ����: ��ӡ ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvkj128Data, Text);
        }

        #endregion

    }
}