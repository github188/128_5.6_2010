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
    public partial class FrmHistoryInOutAntenna : Wilson.Controls.Docking.DockContent
    {
        //����
        private Li_HistoryInOutAntenna_BLL lhab = new Li_HistoryInOutAntenna_BLL();

        #region ˽�б���
        /// <summary>
        /// ��ѯ����
        /// </summary>
        private string where;
        /// <summary>
        /// ÿҳ��ʾ����
        /// </summary>
        private int pSize = 40;
        /// <summary>
        /// ��ѯ�������ҳ��
        /// </summary>
        private int countPage;
        #endregion
      
        #region ҳ�����
        public FrmHistoryInOutAntenna()
        {
            InitializeComponent();
            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString();
            #region ���ط�վ��Ϣ
            lhab.LoadInfo(cmbStationAddress, cmbStationHeadAddress, false);
            #endregion

            cbPSize.SelectedIndex = 0;
            dvValue.Columns[0].FillWeight = 40;
            dvValue.Columns[1].FillWeight = 50;
            dvValue.Columns[2].FillWeight = 50;
            dvValue.Columns[3].FillWeight = 150;
            dvValue.Columns[4].FillWeight = 50;
        }
        #endregion

        //�¼�
        #region ѡ���վ�¼� SelectionChangeCommitted
        private void cmbStationAddress_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lhab.LoadInfo(cmbStationAddress, cmbStationHeadAddress, true);
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
            where= lhab.SelectWhere(txtCard.Text.Trim(), dtStartTime.Text.Trim(), dtEndTime.Text.Trim(), cmbStationAddress.SelectedValue.ToString(), cmbStationHeadAddress.SelectedValue.ToString(),
                            rbEmp.Checked || rbEqu.Checked ? rbEmp.Checked ? 0 : 1 : 2, rbNotCode.Checked);
            SelectInfo(1);
            cpUp.Enabled = false;
            cpDown.Enabled = true;
        }
        #endregion

        #region ���� ����¼� Click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtStartTime.Text = DateTime.Today.ToString();
            txtCard.Text = "";
            lhab.LoadInfo(cmbStationAddress, cmbStationHeadAddress, false);
            lhab.LoadInfo(cmbStationAddress, cmbStationHeadAddress, true);
            rbAll.Checked = true;
        }
        #endregion

        #region ��ҳ
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

        #region ѡ��ÿҳ��ʾ����
        private void cbPSize_DropDownClosed(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cbPSize.SelectedItem);
            btnSearch_Click(sender, e);
            //SelectInfo(1);
            cpUp.Enabled = false;
            cpDown.Enabled = true;
        }
        #endregion

        //����
        #region ��ҳ��ѯ
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
            DataSet ds = lhab.GetHisInOutAntennaSet(pIndex, pSize, where);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                //���ķ�����->��������ŵ���Ϣ
                ds.Tables[0].Columns[0].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);
                ds.Tables[0].Columns[2].ColumnName = HardwareName.Value(CorpsName.Station) + "@" + HardwareName.Value(CorpsName.StaHead);
                ds.Tables[0].Columns[3].ColumnName = HardwareName.Value(CorpsName.StaHeadSplace);
                ds.Tables[0].Columns[6].ColumnName = HardwareName.Value(CorpsName.Inspect);
                

                // ��������ҳ��
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                if (sumPage > 1)
                {
                    bcpPageSum.Visible = true;
                    bcpPageSum.Location = new Point(316, 9);
                }
                else
                {
                    bcpPageSum.Visible = true;
                    bcpPageSum.Location = new Point(640, 9);

                }
                if (pIndex > sumPage)
                {
                    if (sumPage == 0)
                    {
                        dvValue.Columns.Clear();
                        dvValue.DataSource = ds.Tables[0];
                        dvValue.Columns[0].FillWeight = 40;
                        dvValue.Columns[1].FillWeight = 50;
                        dvValue.Columns[2].FillWeight = 50;
                        dvValue.Columns[3].FillWeight = 150;
                        dvValue.Columns[4].FillWeight = 50;
                        dvValue.Columns[7].Visible = false;
                        dvValue.Columns[8].Visible = false;
                        dvValue.Columns[9].Visible = false;
                        dvValue.Columns[10].Visible = false;
                        dvValue.Columns[11].Visible = false;

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
                dvValue.Columns.Clear();
                dvValue.DataSource = ds.Tables[0];
                dvValue.Columns[0].FillWeight = 40;
                dvValue.Columns[1].FillWeight = 50;
                dvValue.Columns[2].FillWeight = 50;
                dvValue.Columns[3].FillWeight = 150;
                dvValue.Columns[4].FillWeight = 50;
                dvValue.Columns[7].Visible = false;
                dvValue.Columns[8].Visible = false;
                dvValue.Columns[9].Visible = false;
                dvValue.Columns[10].Visible = false;
                dvValue.Columns[11].Visible = false;

                dvValue.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

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

        #region ���������ҳ����ʾ
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

        #region ���� Excel
        private void cpToExcel_Click(object sender, EventArgs e)
        {
            ExcelExports.ExportDataGridViewToExcel(dvValue);
        }
        #endregion

        #region �� ��������¼� ��
        
        private void FrmHistoryInOutAntenna_Load(object sender, EventArgs e)
        {
            label10.Text = HardwareName.Value(CorpsName.CodeSenderAddress);
            label3.Text = HardwareName.Value(CorpsName.StationSplace);
            label5.Text = HardwareName.Value(CorpsName.StaHeadSplace);
            rbNotCode.Text ="δ�Ǽǵ�"+ HardwareName.Value(CorpsName.CodeSender);
            btnSearch_Click(null, null);
        }

        #endregion
    }
}