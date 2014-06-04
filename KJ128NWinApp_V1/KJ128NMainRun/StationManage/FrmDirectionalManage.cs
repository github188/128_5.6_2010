using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128WindowsLibrary;
using KJ128NDBTable;
using Shine.Logs;
using Shine.Logs.LogType;
using KJ128NDataBase;

namespace KJ128NMainRun.StationManage
{
    public partial class FrmDirectionalManage : Wilson.Controls.Docking.DockContent
    {
        //�϶�
        private bool isMove = false;            // (�������) �Ƿ��ƶ�
        private int mleft = 0;
        private int mtop = 0;
        private StationBLL sbll = new StationBLL();
        private int pSize = 40;
        

        public FrmDirectionalManage()
        {
            InitializeComponent();
            Init();
        }

        #region ��ʼ������

        private void Init()
        {
            vsPanel.Visible = false;
            vspConfig.Visible = false;

            cmb_Size.SelectedIndex = 0;
            loaddgvData();
        }

        #endregion

        #region ��ʼ��DataGridView

        private void loaddgvData()
        {
            getInfo(1,"");
        }

        #endregion

        #region ����treeview

        private void loadTreeView()
        {
            trFromStation.Nodes.Clear();
            trToStation.Nodes.Clear();

            DataSet ds = sbll.GetStationAndHead();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TreeNode tnode = new TreeNode();
                    TreeNode tnode1 = new TreeNode();
                    tnode.Name = dr["StationAddress"].ToString();
                    tnode.Text = dr["StationPlace"].ToString();
                    tnode1.Name = dr["StationAddress"].ToString();
                    tnode1.Text = dr["StationPlace"].ToString();
                    DataRow[] drhead = ds.Tables[1].Select("StationAddress = " + dr["StationAddress"].ToString());
                    if (drhead.GetUpperBound(0) + 1>0)
                    {
                        TreeNode headnode = null;
                        TreeNode headnode1 = null;
                        foreach (DataRow drh in drhead)
	                    {
                            headnode = new TreeNode();
                            headnode.Name = drh["StationHeadAddress"].ToString();
                            headnode.Text = drh["StationHeadPlace"].ToString();
                            // ���ߵ�ַΪ��ʱ Ĭ��Ϊ ����A 
                            headnode.Tag = drh["AntennaA"].ToString()==""?"����A,":drh["AntennaA"].ToString()+",";
                            headnode.Tag += drh["AntennaB"].ToString()==""?"����B":drh["AntennaB"].ToString();

                            headnode1 = new TreeNode();
                            headnode1.Name = drh["StationHeadAddress"].ToString();
                            headnode1.Text = drh["StationHeadPlace"].ToString();
                            // ���ߵ�ַΪ��ʱ Ĭ��Ϊ ����A 
                            headnode1.Tag = drh["AntennaA"].ToString() == "" ? "����A," : drh["AntennaA"].ToString() + ",";
                            headnode1.Tag += drh["AntennaB"].ToString() == "" ? "����B" : drh["AntennaB"].ToString();
                            // ��ӵ���վ�ڵ���
                            tnode.Nodes.Add(headnode);
                            tnode1.Nodes.Add(headnode1);
	                    }
                    }
                    // ��ӵ�treeView
                    trFromStation.Nodes.Add(tnode);
                    trToStation.Nodes.Add(tnode1);
                }
                if (trFromStation.Nodes.Count > 0)
                {
                    trFromStation.Nodes[0].Checked = true;
                }
                if (trToStation.Nodes.Count >0)
                {
                    trToStation.Nodes[0].Checked = true;
                }
            }
        }

        #endregion

        #region ��ҳ���� ɾ�� �޸�

        #region ��ҳ�¼�

        // ����
        void cpCheckPage_Click(object sender, EventArgs e)
        {
            if (txtCheckPage.Text == string.Empty) return;
            string value = txtCheckPage.Text;
            int page = int.Parse(value);
            getInfo(page,"");
        }

        // ��һҳ


        void cpDown_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page++;
            // ��ʾ��ʽ
            getInfo(page,"");

        }

        // ��һҳ


        void cpUp_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page--;
            // ��ʾ��ʽ
            getInfo(page,"");
        }

        #endregion

        // ҳ������
        private void getInfo(int pIndex,string strWhere)
        {
            dgvData.Columns.Clear();
            if (pIndex < 0) return;
            DataSet ds = null;
            if (strWhere == "") strWhere = "1=1";
            ds = sbll.getAllDirectional(pIndex - 1, pSize, strWhere);
            if (pIndex < 1)
            {
                MessageBox.Show("�������ҳ��������Χ,����ȷ����ҳ��");
                return;
            }
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // ��������ҳ��
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                //if (sumPage > 1)
                //{
                //    bcpPageSum.Location = new Point(394, 5);
                //}
                //else
                //{
                //    bcpPageSum.Location = new Point(704, 5);
                //}

                if (!cpUp.Enabled)
                {
                    cpUp.Enabled = true;
                }
                if (!cpDown.Enabled)
                {
                    cpDown.Enabled = true;
                }

                if (pIndex == 1)
                {
                    // ֻ��һҳʱ
                    if (sumPage <= 1)
                    {
                        pageControlsVisible(false);
                    }
                    else
                    {
                        pageControlsVisible(true);
                        cpUp.Enabled = false;
                    }
                }
                else if (pIndex == sumPage)
                {
                    cpDown.Enabled = false;
                    // ���һҳ
                }
                else if (pIndex > sumPage)
                {
                    // �������һҳ
                    getInfo(sumPage,"");
                    return;
                }
                //bcpPageSum.CaptionTitle = "��" + ds.Tables[1].Rows[0][0].ToString() + "��/��ҳ" + ds.Tables[0].Rows.Count.ToString() + "��";
                bcpPageSum.CaptionTitle = "��" + ds.Tables[1].Rows[0][0].ToString() + "��";
                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "ҳ";

                //ɾ��
                DataGridViewLinkColumn dgvLBtnColRemove = new DataGridViewLinkColumn();
                dgvLBtnColRemove.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvLBtnColRemove.HeaderText = "����";
                dgvLBtnColRemove.Name = "delete";
                dgvLBtnColRemove.DataPropertyName = "������";
                dgvLBtnColRemove.Text = "ɾ  ��";
                dgvLBtnColRemove.Visible = true;
                dgvLBtnColRemove.UseColumnTextForLinkValue = true;

                // �޸�
                DataGridViewLinkColumn dgvLBtnColUpdate = new DataGridViewLinkColumn();
                dgvLBtnColUpdate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvLBtnColUpdate.HeaderText = "����";
                dgvLBtnColUpdate.Name = "update";
                dgvLBtnColUpdate.DataPropertyName = "������";
                dgvLBtnColUpdate.Text = "��  ��";
                dgvLBtnColUpdate.Visible = true;
                dgvLBtnColUpdate.UseColumnTextForLinkValue = true;

                dgvData.DataSource = ds.Tables[0];
                dgvData.Columns.Add(dgvLBtnColUpdate);
                dgvData.Columns.Add(dgvLBtnColRemove);
                dgvData.Columns[0].Visible = false;
                dgvData.Columns[1].FillWeight = 25;
                dgvData.Columns[3].FillWeight = 50;
            }
        }

        #region ���������ҳ����ʾ
        // ���������ҳ����ʾ

        private void pageControlsVisible(bool bl)
        {
            cpUp.Visible = bl;
            cpDown.Visible = bl;
            txtPage.Visible = bl;
            lblSumPage.Visible = bl;
            txtCheckPage.Visible = bl;
            cpCheckPage.Visible = bl;
            //bcpPageSum.Visible = bl;
        }

        #endregion

        // �޸� ɾ��
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // ɾ��
            if (e.RowIndex > -1 && e.ColumnIndex == dgvData.Columns["delete"].Index)
            {
                dgvData.Rows[e.RowIndex].Selected = true;
                ((DataGridViewLinkColumn)dgvData.Columns["delete"]).VisitedLinkColor = Color.Blue;

                //MessageBox.Show(dgvData.CurrentRow.Cells["��ʶ"].Value.ToString());

                if (MessageBox.Show("��ȷ��ɾ���÷�����", "ɾ  ��", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    operated = 2;

                    //ɾ����������Ϣ�ı�ʶ
                    strDelete = dgvData.Rows[e.RowIndex].Cells["��ʶ"].Value.ToString();

                    //������־
                    LogSave.Messages("[FrmDirectionalManage]", LogIDType.UserLogID, "ɾ�������ԣ���ʶ��" + dgvData.Rows[e.RowIndex].Cells["��ʶ"].Value.ToString()
                        + "��������" + dgvData.Rows[e.RowIndex].Cells["����������"].Value.ToString() + "��");

                    int tmpInt = e.RowIndex;
                    sbll.removeDirectional(int.Parse(dgvData.Rows[e.RowIndex].Cells[dgvData.Columns["������"].Index].Value.ToString()));
                    getInfo(int.Parse(txtPage.CaptionTitle),"1=1");
                    dgvData.ClearSelection();
                    //if (tmpInt > 0)
                    //{
                    //    if (dgvData.Rows.Count > tmpInt + 1)
                    //    {
                    //        dgvData.Rows[tmpInt].Selected = true;
                    //    }
                    //    else
                    //    {
                    //        dgvData.Rows[tmpInt - 1].Selected = true;
                    //    }
                    //}


                    if (!New_DBAcess.IsDouble)
                    {
                        getInfo(int.Parse(txtPage.CaptionTitle), "");
                    }
                    else
                    {
                        timer1.Start();
                    }
                }
            }
            else if (e.RowIndex > -1 && e.ColumnIndex == dgvData.Columns["update"].Index)
            {
                //������־
                LogSave.Messages("[FrmDirectionalManage]", LogIDType.UserLogID, "�޸ķ����ԣ���ʶ��" + dgvData.Rows[e.RowIndex].Cells["��ʶ"].Value.ToString()
                    + "��������" + dgvData.Rows[e.RowIndex].Cells["����������"].Value.ToString() + "��");

                ((DataGridViewLinkColumn)dgvData.Columns["update"]).VisitedLinkColor = Color.Blue;
                vsPanel.Visible = true;
                vsPanel.Tag = dgvData.Rows[e.RowIndex].Cells["������"].Value.ToString();
                txt.Text = dgvData.Rows[e.RowIndex].Cells["��ʶ"].Value.ToString();
                txtUpdateDInfo.Text = dgvData.Rows[e.RowIndex].Cells["λ��"].Value.ToString();
                txtUpdateD.Text = dgvData.Rows[e.RowIndex].Cells["����������"].Value.ToString();
                lblUpdateResult.Text = "";

            }
        }

        #endregion

        #region panel�϶�

        private void cpConfigHead_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            VSPanel p = (VSPanel)((CaptionPanel)sender).Parent;
            mleft = e.Location.X;
            mtop = e.Location.Y;
        }

        private void cpConfigHead_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                VSPanel p = (VSPanel)((CaptionPanel)sender).Parent;
                p.Location = new Point(p.Left + e.Location.X - mleft, p.Top + e.Location.Y - mtop);
            }
        }

        private void cpConfigHead_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        // �������ر��¼�
        private void cpConfigHead_CloseButtonClick(object sender, EventArgs e)
        {
            vspConfig.Visible = false;
        }

        // �޸����ر��¼�
        private void cp_CloseButtonClick(object sender, EventArgs e)
        {
            vsPanel.Visible = false;
        }

        #endregion 

        #region ���TreeView From

        private void trFromStation_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                lblFromStation.Text = e.Node.Parent.Text;
                lblFromHead.Text = e.Node.Text;
                string[] s = e.Node.Tag.ToString().Split(',');
                rbtnFromA.Text = s[0].ToString();
                rbtnFromB.Text = s[1].ToString();

                rbtnFromA.Visible = true;
                rbtnFromB.Visible = true;

                lblFromStation.Tag = e.Node.Parent.Name;
                lblFromHead.Tag = e.Node.Name;
            }
            else
            {
                lblFromStation.Text = "";
                lblFromHead.Text = "";
                
                rbtnFromA.Visible = false;
                rbtnFromB.Visible = false;

                lblFromStation.Tag = null;
                lblFromHead.Tag = null;
            }
        }

        #endregion

        #region ���TreeView To

        private void trToStation_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                lblToStation.Text = e.Node.Parent.Text;
                lblToHead.Text = e.Node.Text;
                string[] s = e.Node.Tag.ToString().Split(',');
                rbtnToA.Text = s[0].ToString();
                rbtnToB.Text = s[1].ToString();

                rbtnToA.Visible = true;
                rbtnToB.Visible = true;

                lblToStation.Tag = e.Node.Parent.Name;
                lblToHead.Tag = e.Node.Name;
            }
            else
            {
                lblToStation.Text = "";
                lblToHead.Text = "";

                rbtnToA.Visible = false;
                rbtnToB.Visible = false;

                lblToStation.Tag = null;
                lblToHead.Tag = null;
            }
        }

        #endregion

        #region ��֤

        private bool CheckSave()
        {
            // �ж��Ƿ�ѡ�������
            if (lblFromHead.Tag == null || lblToHead.Tag == null)
            {
                lblInfo.ForeColor = Color.Red;
                lblInfo.Text = "��ѡ��������������Ķ�����վ";
                return false;
            }

            string tmpd1 = lblFromStation.Tag.ToString() + "," + lblFromHead.Tag.ToString() + ",";
            tmpd1 += rbtnFromA.Checked ? "1" : "2";
            string tmpd2 = lblToStation.Tag.ToString() + "," + lblToHead.Tag.ToString() + ",";
            tmpd2 += rbtnToA.Checked ? "1" : "2";

            //������־
            LogSave.Messages("[FrmDirectionalManage]", LogIDType.UserLogID, "���÷����ԣ���ʼ������վ��" + tmpd1 + "��Ŀ�������վ��" + tmpd2
                + "��������" + txtDirectional.Text + "��");

            if (tmpd1 == tmpd2)
            {
                lblInfo.ForeColor = Color.Red;
                lblInfo.Text = "�����Բ�����һ��������վ�µ�ͬһ������";
                return false;
            }
            
            return true;
        }

        // ������������ý���ʱ ��֤
        private void txtDirectional_Enter(object sender, EventArgs e)
        {
            if (!CheckSave())
            {
                return;
            }
        }

        #endregion

        #region ��ӷ�����

        private void bcpSave_Click(object sender, EventArgs e)
        {
            if (!CheckSave())
            {
                return;
            }
            if (txtDirectional.Text == string.Empty)
            {
                lblInfo.ForeColor = Color.Red;
                lblInfo.Text = "����д����������";
                return;
            }

            // ���췽����
            string tmpd1 = lblFromStation.Tag.ToString() + "," + lblFromHead.Tag.ToString() + ",";
            tmpd1 += rbtnFromA.Checked ? "1" : "2"; 
            string tmpd2 = lblToStation.Tag.ToString() + "," + lblToHead.Tag.ToString() + ",";
            tmpd2 += rbtnToA.Checked ? "1" : "2";

            //������־
            LogSave.Messages("[FrmDirectionalManage]", LogIDType.UserLogID, "���÷����ԣ���ʼ��������" + tmpd1 + "��Ŀ���������" + tmpd2
                + "��������" + txtDirectional.Text + "��");

            operated = 1;

            int result = sbll.addDirectional(tmpd1 + ":" + tmpd2, txtDirectional.Text);
            if (result == 0)
            {
                lblInfo.ForeColor = Color.Red;
                lblInfo.Text = "�������Ѵ���";
                return;
            }
            else if (result == 1)
            {
                txtDirectional.Text = "";
                lblInfo.ForeColor = Color.Blue;
                lblInfo.Text = "��ӳɹ�";

                if (!New_DBAcess.IsDouble)
                {
                    getInfo(int.Parse(txtPage.CaptionTitle), "");
                }
                else
                {
                    timer1.Start();
                }
                return;
            }
        }

        #endregion

        // ��ѯ ���ݱ�ʶ ������ѯ
        private void bcpSelect_Click(object sender, EventArgs e)
        {
            string[,] strArray = new string[2, 4]{{"DetectionInfo","=",txtD.Text,"string"},
                                    {"Directional","=",txtWhere.Text,"string"}
              };
            RealTimeBLL rtbll = new RealTimeBLL();
            string where = rtbll.SelectWhere(strArray, 0);
            getInfo(1, where);

        }

        private void bcpUpdate_Click(object sender, EventArgs e)
        {
            if (txtUpdateD.Text == string.Empty)
            {
                lblUpdateResult.ForeColor = Color.Red;
                lblUpdateResult.Text = "����д����������";
                return;
            }

            

            if (vsPanel.Tag != null)
            {
                int result = sbll.upDateDirectional(int.Parse(vsPanel.Tag.ToString()), txtUpdateD.Text);
                if (result == 1)
                {
                    lblUpdateResult.ForeColor = Color.Blue;
                    lblUpdateResult.Text = "�޸ĳɹ�!";
                }
                vsPanel.Visible = false;

                operated = 3;

                if (!New_DBAcess.IsDouble)
                {
                    getInfo(int.Parse(txtPage.CaptionTitle), "");
                }
                else
                {
                    timer1.Start();
                }
            }
        }

        private void bcpConfig_Click(object sender, EventArgs e)
        {
            vspConfig.Visible = true;
            loadTreeView();
            
            // ��ʼ������
            lblInfo.Text = "";
            lblFromStation.Text = "";
            lblFromHead.Text = "";
            rbtnFromA.Visible = false;
            rbtnFromB.Visible = false;
            lblFromStation.Tag = null;
            lblFromHead.Tag = null;

            lblToStation.Text = "";
            lblToHead.Text = "";
            rbtnToA.Visible = false;
            rbtnToB.Visible = false;
            lblToStation.Tag = null;
            lblToHead.Tag = null;
        }

        private void buttonCaptionPanel1_Click(object sender, EventArgs e)
        {
            vsPanel.Visible = false;
        }

        private void FrmDirectionalManage_Load(object sender, EventArgs e)
        {

        }

        private void bcpSelect_Load(object sender, EventArgs e)
        {

        }

        private void vspConfig_Paint(object sender, PaintEventArgs e)
        {

        }


        #region ѡ�� ÿҳ��ʾ����
        private void cmb_Size_SelectionChangeCommitted(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cmb_Size.SelectedItem);
            loaddgvData();
        }
        #endregion

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'')
            {
                e.Handled = true;
            }
        }


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
        /// 1��ʾ ���ӣ��޸� 2 ��ʾɾ�� 
        /// </summary>
        private int operated = 1;

        /// <summary>
        /// ɾ����������Ϣ�ı�ʶ
        /// </summary>
        private string strDelete = string.Empty;

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (operated == 1)
            {

                // ���췽����
                string tmpd1 = lblFromStation.Tag.ToString() + "," + lblFromHead.Tag.ToString() + ",";
                tmpd1 += rbtnFromA.Checked ? "1" : "2";
                string tmpd2 = lblToStation.Tag.ToString() + "," + lblToHead.Tag.ToString() + ",";
                tmpd2 += rbtnToA.Checked ? "1" : "2";

                string value = tmpd1 + ":" + tmpd2;

                if (RecordSearch.IsRecordExists("CodeSender_Directional", "DetectionInfo", value, DataType.String))
                {
                    //ˢ��

                    getInfo(int.Parse(txtPage.CaptionTitle), "");

                    times = 0;
                    //�ر�timer1
                    timer1.Stop();
                }
                else
                {
                    if (times < maxTimes)
                    {
                        times++;
                        timer1_Tick(sender, e);
                    }
                    else
                    {
                        times = 0;
                        //�ر�timer1
                        timer1.Stop();
                    }
                }
            }
            else if (operated == 2)
            {
                if (strDelete != string.Empty)
                {
                    string value = strDelete; //dgvData.CurrentRow.Cells["��ʶ"].Value.ToString();

                    if (!RecordSearch.IsRecordExists("CodeSender_Directional", "DetectionInfo", value, DataType.String))
                    {
                        //ˢ��

                        getInfo(int.Parse(txtPage.CaptionTitle), "");

                        times = 0;
                        //�ر�timer1
                        timer1.Stop();
                    }
                    else
                    {
                        if (times < maxTimes)
                        {
                            times++;
                            timer1_Tick(sender, e);
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
            else
            {
                string strWhere = "DetectionInfo='" + txt.Text + "'"
                    + " and Directional='" + txtUpdateD.Text + "'";

                if (RecordSearch.IsRecordExists("CodeSender_Directional", strWhere))
                {
                    //ˢ��

                    getInfo(int.Parse(txtPage.CaptionTitle), "");

                    times = 0;
                    //�ر�timer1
                    timer1.Stop();
                }
                else
                {
                    if (times < maxTimes)
                    {
                        times++;
                       // timer1_Tick(sender, e);
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

        #region �� �¼�: ˢ�� ��

        private void buttonCaptionPanel2_Click(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cmb_Size.SelectedItem);
            loaddgvData();
        }

        #endregion

    }
}