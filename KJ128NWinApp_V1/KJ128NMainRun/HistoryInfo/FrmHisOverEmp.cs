using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NMainRun.HistoryInfo
{
    public partial class FrmHisOverEmp : Wilson.Controls.Docking.DockContent
    {
        #region [ ���� ]
        
        /// <summary>
        /// ÿҳ��ʾ����
        /// </summary>
        private int pSize = 40;

        /// <summary>
        /// ��ѯ�������ҳ��
        /// </summary>
        private int countPage;

        /// <summary>
        /// ��ѯ����
        /// </summary>
        private string where = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private HisOverEmpBLL his = new HisOverEmpBLL();

        private RealTimeBLL rtbll = new RealTimeBLL();

        #endregion

        #region [ ���캯�� ]

        public FrmHisOverEmp()
        {
            InitializeComponent();

            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
            cbPSize.SelectedIndex = 0;                      //����ÿҳ��ʾ����Ϊ20;

            where = strWhere();                 // Ĭ�ϲ�ѯ�����
            SelectInfo(1);
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

        #region [ ����: ѡ��ÿҳ��ʾ���� ]

        private void cbPSize_DropDownClosed(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cbPSize.SelectedItem);
            btnSearch_Click(sender, e);
            cpUp.Enabled = false;
            cpDown.Enabled = true;
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
            DataSet ds = his.GetHisOverEmpAll(pIndex, pSize, where);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // ��������ҳ��
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                if (sumPage > 1)
                {
                    bcpPageSum.Visible = true;
                    bcpPageSum.Location = new Point(261, 8);
                }
                else
                {
                    bcpPageSum.Visible = true;
                    bcpPageSum.Location = new Point(631, 8);
                }

                if (pIndex > sumPage)
                {
                    if (sumPage == 0)
                    {
                        dgValue.Columns.Clear();
                        dgValue.DataSource = ds.Tables[0];

                        bcpPageSum.CaptionTitle = "0 ��";
                        pageControlsVisible(false);
                        return;
                    }
                    // �������һҳ
                    return;
                }
                bcpPageSum.CaptionTitle = "��" + ds.Tables[1].Rows[0][0].ToString() + "��";
                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "ҳ";
                dgValue.Columns.Clear();
                dgValue.DataSource = ds.Tables[0];

                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    buttonCaptionPanel1.CaptionTitle = "��ʷ��Ա��ʾ��\t��" + ds.Tables[0].Rows.Count.ToString() + "����Ϣ";
                }
                else
                {
                    buttonCaptionPanel1.CaptionTitle = "��ʷ��Ա��ʾ��\t��0����Ϣ";
                }

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
        }

        #endregion

        #region [ ����: ���������ҳ����ʾ ]

        /// <summary>
        /// ���������ҳ����ʾ
        /// </summary>
        /// <param name="bl"></param>
        private void pageControlsVisible(bool bl)
        {
            //bcpPageSum.Visible = bl;
            cpUp.Visible = bl;
            cpDown.Visible = bl;
            txtPage.Visible = bl;
            lblSumPage.Visible = bl;
            txtCheckPage.Visible = bl;
            cpCheckPage.Visible = bl;
        }

        #endregion

        #region ��ѯ

        /// <summary>
        /// ��֯��ѯ����
        /// </summary>
        /// <returns></returns>
        private string strWhere()
        {
            string[,] strArray = null;

            strArray = new string[2, 4]{{"His_OverEmployeeBeginTime",">",dtStartTime.Text,"string"},
                    {"His_OverEmployeeBeginTime","<",dtEndTime.Text,"string"}
            };

            return rtbll.SelectWhere(strArray, 1);
        }

        #endregion

        #region ��ѯ ����¼� Click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtStartTime.Text.Trim() == "" || dtEndTime.Text.Trim() == "")
            {
                MessageBox.Show("�Բ���, ��ʼ�ͽ���ʱ�䶼����Ϊ�գ�");
                return;
            }
            if (DateTime.Compare(DateTime.Parse(dtStartTime.Text), DateTime.Parse(dtEndTime.Text)) > 0)
            {
                MessageBox.Show("�Բ���, ��ʼʱ�䲻�ܴ��ڽ���ʱ�䣡");
                return;
            }

            if (dgValue.Visible == true)
            {
                // ��֯��ѯ����
                where = strWhere();
                SelectInfo(1);      //��ҳ��ѯ
                cpUp.Enabled = false;
                cpDown.Enabled = true;
            }
        }
        #endregion

        #region [ �¼�: ��ӡ ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgValue, Text);
        }

        #endregion
    }
}