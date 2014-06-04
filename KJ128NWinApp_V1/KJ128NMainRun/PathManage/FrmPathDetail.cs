using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128WindowsLibrary;
using KJ128NDBTable;
using KJ128NDataBase;
using KJ128NModel;
using Shine.Logs;
using Shine.Logs.LogType;
using PrintCore;

namespace KJ128NMainRun.PathManage
{
    public partial class FrmPathDetail : Wilson.Controls.Docking.DockContent
    {

        #region [���캯��]

        public FrmPathDetail()
        {
            InitializeComponent();
        }

        #endregion

        #region [�ֶ�]

        private PathInfoBll pathInfoBll = new PathInfoBll();

        private PathDetailBll pathDetailBll = new PathDetailBll();

        DataTable dtStation = null;

        #endregion

        #region [����]

        #region [��ק]

        /// <summary>
        /// �Ƿ�������ק
        /// </summary>
        private bool moveAble = false;
        /// <summary>
        /// ��߾���
        /// </summary>
        private int left = 0;
        /// <summary>
        /// �ϱ߾��� 
        /// </summary>
        private int top = 0;

        /// <summary>
        /// �ƶ��ķ���
        /// </summary>
        /// <param name="obj">�ƶ��Ķ���</param>
        /// <param name="leftSize">��߾���</param>
        /// <param name="topSize">�ϱ߾���</param>
        private void ToMove(VSPanel obj, int leftSize, int topSize)
        {

            obj.Left += (Cursor.Position.X - leftSize);
            obj.Top += (Cursor.Position.Y - topSize);


            this.Cursor = Cursors.SizeAll;
            left = Cursor.Position.X;
            top = Cursor.Position.Y;

        }

        private void bcpAdd_MouseDown(object sender, MouseEventArgs e)
        {
            moveAble = true;

            left = Cursor.Position.X;
            top = Cursor.Position.Y;
        }

        private void bcpAdd_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveAble)
            {
                ToMove(vspnlAdd, left, top);
            }
        }

        private void bcpAdd_MouseUp(object sender, MouseEventArgs e)
        {
            moveAble = false;
            this.Cursor = Cursors.Default;
        }

        #endregion

        private void bcpAdd_CloseButtonClick(object sender, EventArgs e)
        {
            vspnlAdd.Visible = false;
        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        private void InitialzeNew()
        {
            this.tbPathNum.Text = tvMain.SelectedNode.Name;
            this.tbPathN.Text = tvMain.SelectedNode.Text;

            //��ʼ����վ��ϢComboBox
            InitialzeStationComboBox();

            this.bcpAdd.CaptionTitle = "���ӽ�������Ϣ";
            this.btnAddOrEdit.CaptionTitle = "����";

        }

        /// <summary>
        /// ��ʼ���޸�
        /// </summary>
        private void InitialzeUpdate()
        {
            this.tbPathNum.Text = dgvMain.CurrentRow.Cells["PathNo"].Value.ToString();
            this.tbPathN.Text = dgvMain.CurrentRow.Cells["PathName"].Value.ToString();

            this.bcpAdd.CaptionTitle = "�޸Ľ�������Ϣ";
            this.btnAddOrEdit.CaptionTitle = "�޸�";

            //��ʼ����վ��ϢComboBox
            InitialzeStationComboBox();

            this.vspnlAdd.Visible = true;
        }

        /// <summary>
        /// ��ʼ��DataGridView
        /// </summary>
        private void InitialzeDataGridView()
        { 
            //���DataTable�������
            DataTable dt = GetDataTable("");
            //this.dbgvMain.DataSource = dt;
            SortDataGrid(dt);
        }

        /// <summary>
        /// ��ʼ����
        /// </summary>
        private void InitialzeTreeView()
        {
            //���·����Ϣ(PathInfo)DataTable�������
            DataTable dt = GetPathInfo("");

            tvMain.Nodes[0].Nodes.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                TreeNode node = new TreeNode();
                node.Name = dr["PathNo"].ToString();
                node.Text = dr["PathName"].ToString();

                //node.ToolTipText = "·��Id:" + dr["Id"].ToString() + "\n"
                node.ToolTipText =  "·�߱��:" + dr["PathNo"].ToString() + "\n"
                    + "·����:" + dr["PathName"].ToString() + "\n"
                    + "��ע:" + dr["Remark"].ToString();

                tvMain.Nodes[0].Nodes.Add(node);
            }

            this.tvMain.ExpandAll();
        }

        /// <summary>
        /// ���ط�վComboBox
        /// </summary>
        private void InitialzeStationComboBox()
        {
            if (dtStation == null)
                dtStation = GetStationInfo();

            //�����б�
            cbstation.DisplayMember = "StationPlace";
            cbstation.ValueMember = "StationAddress";

            cbstation.DataSource = dtStation;
            if (dtStation.Rows.Count > 0)
            {
                cbstation.SelectedIndex = 0;
            }

        }

        /// <summary>
        /// ���ؽ�����ComboBox
        /// </summary>
        private void InitialzePointComboBox(int stationAddress)
        {
            DataTable dt = DataHelper.GetPointInfo(stationAddress);

            cbPiont.DisplayMember = "StationHeadPlace";
            cbPiont.ValueMember = "StationHeadAddress";
            cbPiont.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                cbPiont.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// ��һ���Ĳ�ѯ����������ݱ�
        /// </summary>
        /// <param name="condition"> ��ѯ���������conditionΪ�գ���ʾȫ������</param>
        /// <returns>���ݱ�</returns>
        private DataTable GetDataTable(string condition)
        {
            DataTable dt = pathDetailBll.SelectPathDetail(condition);
            return dt;
        }

        /// <summary>
        /// ��ȡ��վ��Ϣ�����ڰ�ComboBox
        /// </summary>
        /// <returns>��վ��</returns>
        private DataTable GetStationInfo()
        {
            DataTable dt = DataHelper.GetStationInfo();
            
            return dt;
        }

        /// <summary>
        /// ��ȡ��������Ϣ�����ڰ�ComboBox
        /// </summary>
        /// <param name="tationAddress">��վ��ַ�����ݷ�վ��ַ��ȡ��������Ϣ</param>
        /// <returns>��������</returns>
        private DataTable GetPointInfo(int stationAddress)
        {
            DataTable dt = DataHelper.GetPointInfo(stationAddress);

            return dt;
        }

        /// <summary>
        /// ��ȡPathInfo��Ϣ
        /// </summary>
        /// <param name="conditon">��ѯ����</param>
        /// <returns>PathInfo��Ϣ</returns>
        private DataTable GetPathInfo(string conditon)
        {
            if (pathInfoBll == null)
            {
                pathInfoBll = new PathInfoBll();
            }
            DataTable dt = pathInfoBll.SelectPathInfo(conditon);
            return dt;
        }

        /// <summary>
        /// ���·�ߵľ�����Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcp_Add_Click(object sender, EventArgs e)
        {
            if (tvMain.SelectedNode == null || tvMain.SelectedNode == tvMain.TopNode)
            {
                
                MessageBox.Show("�������ѡ��Ҫ��ӽ�������·��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //��ʼ������
                InitialzeNew();
                vspnlAdd.Visible = true;
            }
        }

        /// <summary>
        /// ���� �����ӡ� �� ���޸ġ�ʱ�Ĳ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            if (CheckValue())
            {
                if (btnAddOrEdit.CaptionTitle == "����")
                {
                    operated = 1;

                    int result = AddPathDetailInfo();
                    if (result == 1)
                    {
                        
                        
                        if (pathDetailBll == null)
                            pathDetailBll = new PathDetailBll();

                        MessageBox.Show("������Ϣ�ɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (!New_DBAcess.IsDouble)
                        {
                            DataTable dt = pathDetailBll.SelectPathDetail("");

                            SortDataGrid(dt);
                        }
                        else
                        {
                            timer1.Start();
                        }

                    }
                    else
                    {
                        MessageBox.Show("���Ӳ���ʧ��,��¼�����Ѵ��ڣ����������ظ���¼", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (btnAddOrEdit.CaptionTitle == "�޸�")
                {
                    operated = 3;

                    int result = UpdatePathDetailInfo();
                    if (result == 1)
                    {
                        if (pathDetailBll == null)
                            pathDetailBll = new PathDetailBll();
                        MessageBox.Show("�޸���Ϣ�ɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (!New_DBAcess.IsDouble)
                        {
                            DataTable dt = pathDetailBll.SelectPathDetail("");

                            SortDataGrid(dt);
                        }
                        else
                        {
                            timer1.Start();
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("�޸Ĳ���ʧ�ܣ���¼�����Ѵ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPathDetail_Load(object sender, EventArgs e)
        {
            //������
            InitialzeTreeView();

            //����DataGrid
            InitialzeDataGridView();
        }

        /// <summary>
        /// ˢ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcpRefresh_Click(object sender, EventArgs e)
        {
            //������
            InitialzeTreeView();
        }

        private void bcpSearch_Click(object sender, EventArgs e)
        {

            try
            {
                string condition = String.Empty;

                if (tbPathNo.Text.Trim() != "")
                {
                    condition = "pd.PathNo like '%" + tbPathNo.Text + "%'";
                }
                else
                {
                    condition = "1=1";
                }

                if (tbStationAddress.Text.Trim() != "")
                {
                    condition += "and pd.StationAddress like '%" + Convert.ToInt32(tbStationAddress.Text).ToString() + "%'";
                }

                if (tbPointAddress.Text.Trim() != "")
                {
                    condition += "and pd.StationHeadAddress like '%" + Convert.ToInt32(tbPointAddress.Text).ToString() + "%'";
                }

                if (pathDetailBll == null)
                    pathDetailBll = new PathDetailBll();

                DataTable dt = pathDetailBll.SelectPathDetail(condition);

                SortDataGrid(dt);
            }
            catch( Exception ex)
            {
                MessageBox.Show("��ѯ�������󣬷�վ���������ַӦ��Ϊ����",ex.Message,MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// ����Stationѡ��������Point��Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbstation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int stationAddress = Convert.ToInt32(cbstation.SelectedValue);
            InitialzePointComboBox(stationAddress);
            //MessageBox.Show(cbstation.SelectedValue + "----" + cbstation.Text);
        }

        private void cbPiont_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cbPiont.SelectedValue + "----" + cbPiont.Text);
        }

        /// <summary>
        /// ��Station��Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbStation_Click(object sender, EventArgs e)
        {
            dtStation = GetStationInfo();

            //�󶨷�վ��Ϣ
            InitialzeStationComboBox();
        }

        /// <summary>
        /// ��Point��Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbPoint_Click(object sender, EventArgs e)
        {
            if (cbstation.SelectedItem != null)
            {
                int stationAddress = Convert.ToInt32(cbstation.SelectedValue);

                //�󶨽�������Ϣ
                InitialzePointComboBox(stationAddress);
            }
        }

        /// <summary>
        /// ������Ԫ��ɾ�����޸�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dbgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string operate = dgvMain.CurrentRow.Cells[e.ColumnIndex].Value.ToString();

                if (operate == "�޸�")
                {
                    InitialzeUpdate();
                }

                else if (operate == "ɾ��")
                {
                    try
                    {
                        DialogResult dr =  MessageBox.Show("��ȷ��Ҫɾ��������¼��","ȷ����ʾ",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            operated = 2;

                            //������־
                            LogSave.Messages("[FrmPathDetail]", LogIDType.UserLogID, "ɾ��·����ϸ��Ϣ��·�߱�ţ�" + dgvMain.CurrentRow.Cells["PathNo"].Value.ToString()
                                + "����վ��װλ�ã�" +this.cbstation.SelectedText + "��������λ�ã�" + this.cbPiont.SelectedText + "��");

                            int id = Convert.ToInt32(dgvMain.CurrentRow.Cells["Id"].Value.ToString());

                            int count =  pathDetailBll.DeletePathDetail(id);

                            bool flag = (count == 1 ? true : false);

                            if (flag)
                            {
                                //ˢ�½���

                                if (!New_DBAcess.IsDouble)
                                {
                                    InitialzeDataGridView();
                                }
                                else
                                {
                                    timer1.Start();
                                }
                            }
                            else
                            {
                                MessageBox.Show("ɾ������ʧ��", "��Ϣ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("����ʧ��:" + ex.Message, "��Ϣ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// ����PathDetail��Ϣ
        /// </summary>
        /// <returns>���ز������ ���ز������ 1��ʾ�ɹ�</returns>
        private int AddPathDetailInfo()
        {
            try
            {
                //Serial_Path_Detail serialPathDetail = new Serial_Path_Detail();

                //serialPathDetail.Operate = 1;
                //serialPathDetail.TableName = "Path_Detail";
                //serialPathDetail.PathNo = this.tbPathNum.Text;
                //serialPathDetail.StationAddress = Convert.ToInt32(this.cbstation.SelectedValue);
                //serialPathDetail.StationHeadAddress = Convert.ToInt32(this.cbPiont.SelectedValue);

                //bool flag = KJ128Nsad.DataReceived(KJ128Nsad.SerialOperate(serialPathDetail));

                //������־
                LogSave.Messages("[FrmPathDetail]", LogIDType.UserLogID, "���·����ϸ��Ϣ��·�߱�ţ�"+tbPathNum.Text
                    +"����վ��װλ�ã�"+this.cbstation.SelectedText+"��������λ�ã�"+this.cbPiont.SelectedText+"��");

                PathDetailModel model = new PathDetailModel();

                model.PathNo = this.tbPathNum.Text;
                model.StationAddress = Convert.ToInt32(this.cbstation.SelectedValue); 
                model.StationHeadAddress = Convert.ToInt32(this.cbPiont.SelectedValue);

                int count = pathDetailBll.InsertPathDetail(model);

                bool flag = (count == 1 ? true : false);

                if (flag)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// �޸�PathDetail��Ϣ
        /// </summary>
        /// <returns>���ز������ 1��ʾ�ɹ�</returns>
        private int UpdatePathDetailInfo()
        {
            try
            {
                //Serial_Path_Detail serialPathDetail = new Serial_Path_Detail();

                //serialPathDetail.Operate = 2;
                //serialPathDetail.TableName = "Path_Detail";
                //serialPathDetail.Id = Convert.ToInt32(dbgvMain.CurrentRow.Cells["Id"].Value.ToString());
                //serialPathDetail.PathNo = dbgvMain.CurrentRow.Cells["PathNo"].Value.ToString();
                //serialPathDetail.StationAddress = Convert.ToInt32(this.cbstation.SelectedValue);
                //serialPathDetail.StationHeadAddress = Convert.ToInt32(this.cbPiont.SelectedValue);

                //bool flag = KJ128Nsad.DataReceived(KJ128Nsad.SerialOperate(serialPathDetail));


                PathDetailModel model = new PathDetailModel();

                model.Id = Convert.ToInt32(dgvMain.CurrentRow.Cells["Id"].Value.ToString());
                model.PathNo = this.tbPathNum.Text;
                model.StationAddress = Convert.ToInt32(this.cbstation.SelectedValue);
                model.StationHeadAddress = Convert.ToInt32(this.cbPiont.SelectedValue);

                //������־
                LogSave.Messages("[FrmPathDetail]", LogIDType.UserLogID, "�޸�·����ϸ��Ϣ��·�߱�ţ�" + model.PathNo
                    + "����վ��װλ�ã�" + this.cbstation.SelectedText + "��������λ�ã�" + this.cbPiont.SelectedText + "��");

                int count = pathDetailBll.UpdatePathDetail(model);

                bool flag = (count == 1 ? true : false);

                if (flag)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        private bool CheckValue()
        {
            if (cbstation.Text.Trim() == "")
            {
                MessageBox.Show("��վ�ص㲻ҪΪ��","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return false;
            }

            if (cbPiont.Text.Trim() == "")
            {
                MessageBox.Show("�������ص㲻ҪΪ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void dbgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (vspnlAdd.Visible == true && bcpAdd.CaptionTitle == "�޸Ľ�������Ϣ")
                {
                    tbPathNum.Text = dgvMain.CurrentRow.Cells["PathNo"].Value.ToString();
                    tbPathN.Text = dgvMain.CurrentRow.Cells["PathName"].Value.ToString();
                }
            }
        }

        /// <summary>
        /// ��DataGrid��ֵ����Դ�����Ҷ��н���˳��
        /// </summary>
        private void SortDataGrid(DataTable dt)
        {
            this.dgvMain.Columns.Clear();
            this.dgvMain.DataSource = dt;

            DataGridViewLinkColumn editCol = new DataGridViewLinkColumn();
            editCol.Name = "edit";
            editCol.HeaderText = "�޸���Ϣ";
            editCol.Text = "�޸�";
            editCol.Width = 60;
            editCol.UseColumnTextForLinkValue = true;
            this.dgvMain.Columns.Add(editCol);

            DataGridViewLinkColumn deleteCol = new DataGridViewLinkColumn();
            deleteCol.Name = "delete";
            deleteCol.HeaderText = "ɾ����Ϣ";
            deleteCol.Text = "ɾ��";
            deleteCol.Width = 60;
            deleteCol.UseColumnTextForLinkValue = true;
            this.dgvMain.Columns.Add(deleteCol);


            this.dgvMain.Columns["Id"].Visible = false;
            this.dgvMain.Columns["PathNo"].HeaderText  = "·�߱��";
            this.dgvMain.Columns["PathName"].HeaderText = "·������";




            //this.dbgvMain.Columns["Id"].DisplayIndex = 0;
            //this.dbgvMain.Columns["PathNo"].DisplayIndex = 1;
            //this.dbgvMain.Columns["PathName"].DisplayIndex = 2;
            //this.dbgvMain.Columns["StationAddress"].DisplayIndex = 3;
            //this.dbgvMain.Columns["StationPlace"].DisplayIndex = 4;
            //this.dbgvMain.Columns["StationHeadAddress"].DisplayIndex = 5;
            //this.dbgvMain.Columns["StationHeadPlace"].DisplayIndex = 6;
            //this.dbgvMain.Columns["edit"].DisplayIndex = 7;
            //this.dbgvMain.Columns["delete"].DisplayIndex = 8;

            //��������,��վ->��վ ��
            this.dgvMain.Columns["StationAddress"].HeaderText = HardwareName.Value(CorpsName.StationAddress);
            this.dgvMain.Columns["StationPlace"].HeaderText = HardwareName.Value(CorpsName.StationSplace);
            this.dgvMain.Columns["StationHeadAddress"].HeaderText = HardwareName.Value(CorpsName.StaHeadAddress);
            this.dgvMain.Columns["StationHeadPlace"].HeaderText = HardwareName.Value(CorpsName.StaHeadSplace);


        }

        private void tvMain_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Node.Nodes.Count < 1)
            {
                //MessageBox.Show(e.Node.Name);

                string pathNo = e.Node.Name;
                if (pathDetailBll == null)
                    pathDetailBll = new PathDetailBll();

                string condition = "pd.PathNo='" + pathNo + "'";

                DataTable dt = pathDetailBll.SelectPathDetail(condition);
                SortDataGrid(dt);
            }

            
        }

        private void bcpPrint_Click(object sender, EventArgs e)
        {
            //FormPrint frm = new FormPrint();
            //frm.CallPrintForm(this.dgvMain, "·����ϸ��Ϣ", "");
            KJ128NDBTable.PrintBLL.Print(this.dgvMain, "·����ϸ��Ϣ", "");
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
                timer1.Interval = 400;

                //ˢ������(����)
                if (times < maxTimes)
                {
                    times++;

                    //ˢ��
                    InitialzeDataGridView();
                }
                else
                {
                    times = 0;
                    timer1.Stop();
                }
            }
                //ɾ��
            else if (operated == 2)
            {
                if (times < maxTimes)
                {

                    timer1.Interval = 1000;
                    times++;

                    InitialzeDataGridView();

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
                //�޸�
            else
            {
                timer1.Interval = 400;

                string ID = dgvMain.CurrentRow.Cells["Id"].Value.ToString();
                string strWhere = "PathNo='" + tbPathNum.Text 
                    + "' and StationAddress="+ cbstation.SelectedValue.ToString()
                    + " and StationHeadAddress="+ cbPiont.SelectedValue.ToString()
                    + " and Id=" + ID;

                if (RecordSearch.IsRecordExists("Path_Detail", strWhere))
                {
                    //ˢ��

                    InitialzeDataGridView();

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
            InitialzeDataGridView();
        }
    }
}