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
    public partial class FrmPathEmp : Wilson.Controls.Docking.DockContent
    {
        #region [���캯��]

        public FrmPathEmp()
        {
            InitializeComponent();
        }

        #endregion

        #region [�ֶ�]

        private PathInfoBll pathInfoBll = new PathInfoBll();

        private PathEmpRelationBll pathEmpRelationbll = new PathEmpRelationBll();

        //private KJ128NSerialAndDeserial KJ128Nsad = new KJ128NSerialAndDeserial();

        private DataTable dtEmp = null;

        private DataTable dtDept = null;


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
            this.tbPathNo.Text = tvMain.SelectedNode.Name;
            this.tbPathName.Text = tvMain.SelectedNode.Text;

            //InitialzeEmpComboBox();

            InitialzeDeptComboBox();

            this.bcpAdd.CaptionTitle = "������Ϣ";
            this.btnAddOrEdit.CaptionTitle = "����";

        }

        /// <summary>
        /// ��ʼ���޸�
        /// </summary>
        private void InitialzeUpdate()
        {
            this.tbPathNo.Text = dgvMain.CurrentRow.Cells["PathNo"].Value.ToString();
            this.tbPathName.Text = dgvMain.CurrentRow.Cells["PathName"].Value.ToString();

            //InitialzeEmpComboBox();
            InitialzeDeptComboBox();

            this.bcpAdd.CaptionTitle = "�޸���Ϣ";
            this.btnAddOrEdit.CaptionTitle = "�޸�";
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
                node.ToolTipText = "·�߱��:" + dr["PathNo"].ToString() + "\n"
                    + "·����:" + dr["PathName"].ToString() + "\n"
                    + "��ע:" + dr["Remark"].ToString();

                tvMain.Nodes[0].Nodes.Add(node);
            }

            this.tvMain.ExpandAll();
        }

        ///// <summary>
        ///// ���ط�վComboBox
        ///// </summary>
        //private void InitialzeStationComboBox()
        //{
        //    if (dtStation == null)
        //        dtStation = GetStationInfo();

        //    //�����б�
        //    cbstation.DisplayMember = "StationPlace";
        //    cbstation.ValueMember = "StationAddress";

        //    cbstation.DataSource = dtStation;

        //    cbstation.SelectedIndex = 0;

        //}

        /// <summary>
        /// ����̽ͷComboBox
        /// </summary>
        //private void InitialzePointComboBox(int stationAddress)
        //{
        //    DataTable dt = DataHelper.GetPointInfo(stationAddress);

        //    cbPiont.DisplayMember = "StationHeadPlace";
        //    cbPiont.ValueMember = "StationHeadAddress";
        //    cbPiont.DataSource = dt;

        //}

        /// <summary>
        /// ��һ���Ĳ�ѯ����������ݱ�
        /// </summary>
        /// <param name="condition"> ��ѯ���������conditionΪ�գ���ʾȫ������</param>
        /// <returns>���ݱ�</returns>
        private DataTable GetDataTable(string condition)
        {
            DataTable dt = pathEmpRelationbll.SelectPathEmpRelation(condition);
            return dt;
        }

        /// <summary>
        /// ��ȡ��Ա��Ϣ�����ڰ�ComboBox
        /// </summary>
        /// <param name="tationAddress">��վ��ַ�����ݷ�վ��ַ��ȡ̽ͷ��Ϣ</param>
        /// <returns>̽ͷ��</returns>
        private DataTable GetEmpInfo(int deptId)
        {
            //if (dtEmp==null)
                dtEmp = DataHelper.GetEmpInfo(deptId);

            return dtEmp;
        }

        private DataTable GetDeptInfo()
        {
            //if (dtDept == null)
                dtDept = DataHelper.GetDeptInfo();
            return dtDept;
        }

        /// <summary>
        /// ��ȡ��Ա��Ϣ�����ص� ComboBox ��ȥ
        /// </summary>
        private void InitialzeEmpComboBox(int deptId)
        {
            DataTable dt = GetEmpInfo(deptId);

            this.cbEmp.DisplayMember = "EmpName";
            this.cbEmp.ValueMember = "EmpID";
            this.cbEmp.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                this.cbEmp.SelectedIndex = 0;
            }
        }

        private void InitialzeDeptComboBox()
        {
            DataTable dt = GetDeptInfo();

            this.cbDept.DisplayMember = "DeptName";
            this.cbDept.ValueMember = "DeptId";
            this.cbDept.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                this.cbDept.SelectedIndex = 0;
            }
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

                MessageBox.Show("�������ѡ��Ҫ���̽ͷ��·��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    int result = AddPathEmpRelation();
                    if (result == 1)
                    {
                        if (pathEmpRelationbll == null)
                            pathEmpRelationbll = new  PathEmpRelationBll();

                        MessageBox.Show("������Ϣ�ɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!New_DBAcess.IsDouble)
                        {
                            DataTable dt = pathEmpRelationbll.SelectPathEmpRelation("");

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

                    int result = UpdatePathEmpRelation();
                    if (result == 1)
                    {
                        if (pathEmpRelationbll == null)
                            pathEmpRelationbll = new PathEmpRelationBll();

                        MessageBox.Show("�޸���Ϣ�ɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (!New_DBAcess.IsDouble)
                        {
                            DataTable dt = pathEmpRelationbll.SelectPathEmpRelation("");

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
        /// ˢ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcpRefresh_Click(object sender, EventArgs e)
        {
            //������
            InitialzeTreeView();
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
                        DialogResult dr = MessageBox.Show("��ȷ��Ҫɾ��������¼��", "ȷ����ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            operated = 2;

                            //������־
                            LogSave.Messages("[FrmPathEmp]", LogIDType.UserLogID, "ɾ��Ա��·����ϵ��Ϣ��·�߱�ţ�"
                                + dgvMain.CurrentRow.Cells["PathNo"].Value.ToString() + "��Ա��������" + dgvMain.CurrentRow.Cells[5].Value.ToString() + "��");

                            int id = Convert.ToInt32(dgvMain.CurrentRow.Cells["Id"].Value.ToString());
                            int count = pathEmpRelationbll.DeletePathEmpRelation(id);

                            bool flag = (count == 1 ? true : false);

                            if (flag)
                            {
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
        /// ����PathEmpRelation��Ϣ
        /// </summary>
        /// <returns>���ز������ ���ز������ 1��ʾ�ɹ�</returns>
        private int AddPathEmpRelation()
        {
            try
            {
                //������־
                LogSave.Messages("[FrmPathEmp]", LogIDType.UserLogID, "����Ա��·����ϵ��Ϣ��·�߱�ţ�"
                    + this.tbPathNo.Text + "��Ա��������" + this.cbEmp.SelectedText.ToString() + "��");

                KJ128NModel.PathEmpRelationModel model = new PathEmpRelationModel();

                if (this.cbEmp.SelectedValue != null)
                {
                    model.EmpID = Convert.ToInt32(this.cbEmp.SelectedValue);
                }
                else
                {
                    MessageBox.Show("���Ա����Ϣ������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 0;
                }
                model.PathNo = this.tbPathNo.Text;
                string strMessage = "";
                int count = pathEmpRelationbll.InsertPathEmpRelation(model,out strMessage);

                bool flag = (count == 1 ? true : false);

                if (flag)
                {
                    this.vspnlAdd.Visible = false;
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
        /// �޸�PathEmpRelation��Ϣ
        /// </summary>
        /// <returns>���ز������ 1��ʾ�ɹ�</returns>
        private int UpdatePathEmpRelation()
        {
            try
            {
                //������־
                LogSave.Messages("[FrmPathEmp]", LogIDType.UserLogID, "�޸�Ա��·����ϵ��Ϣ��·�߱�ţ�"
                    + this.tbPathNo.Text + "��Ա��������" + this.cbEmp.SelectedText.ToString() + "��");

                KJ128NModel.PathEmpRelationModel model = new PathEmpRelationModel();
                model.Id = Convert.ToInt32(dgvMain.CurrentRow.Cells["Id"].Value.ToString());

                if (this.cbEmp.SelectedValue != null)
                {
                    model.EmpID = Convert.ToInt32(this.cbEmp.SelectedValue.ToString());
                }
                else
                {
                    MessageBox.Show("�޸�Ա����Ϣ������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 0;
                }
                model.PathNo = this.tbPathNo.Text;
                string strMessage = "";
                int count = pathEmpRelationbll.UpdatePathEmpRelation(model,out strMessage);

                bool flag = (count == 1 ? true : false);

                if (flag)
                {
                    this.vspnlAdd.Visible = false;
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
            if (cbEmp.Text.Trim() == "")
            {
                MessageBox.Show("Ա��������ҪΪ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        /// <summary>
        /// �޸������ʾʱ������DataGridʱ�����Ĳ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dbgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (vspnlAdd.Visible == true && bcpAdd.CaptionTitle == "�޸�̽ͷ��Ϣ")
                {
                    tbPathNo.Text = dgvMain.CurrentRow.Cells["PathNo"].Value.ToString();
                    tbPathName.Text = dgvMain.CurrentRow.Cells["PathName"].Value.ToString();
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
            this.dgvMain.Columns["EmpID"].Visible = false;
            this.dgvMain.Columns["PathNo"].HeaderText = "·�߱��";
            this.dgvMain.Columns["PathName"].HeaderText = "·������";

            //this.dbgvMain.Columns["Id"].DisplayIndex = 0;
            //this.dbgvMain.Columns["PathNo"].DisplayIndex = 1;
            //this.dbgvMain.Columns["PathName"].DisplayIndex = 2;
            this.dgvMain.Columns["EmpNo"].HeaderText = "Ա�����";
            this.dgvMain.Columns["EmpName"].HeaderText = "Ա������";
        }

        /// <summary>
        /// �������ڵ�ʱ��DataGrid����ʾ��Ӧ����Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvMain_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Node.Nodes.Count < 1)
            {
                string pathNo = e.Node.Name;
                if (pathEmpRelationbll == null)
                    pathEmpRelationbll = new PathEmpRelationBll();

                string condition = "per.PathNo='" + pathNo + "'";

                DataTable dt = pathEmpRelationbll.SelectPathEmpRelation(condition);
                SortDataGrid(dt);
            }
        }

        /// <summary>
        /// �������ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcpAddInfo_Click(object sender, EventArgs e)
        {
            if (tvMain.SelectedNode == null || tvMain.SelectedNode == tvMain.TopNode)
            {
                MessageBox.Show("�������ѡ��Ҫ���Ա����Ϣ��·��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //��ʼ������
                InitialzeNew();
                vspnlAdd.Visible = true;
            }
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPathEmp_Load(object sender, EventArgs e)
        {
            //������
            InitialzeTreeView();

            //����DataGrid
            InitialzeDataGridView();
        }

        /// <summary>
        /// ������Ա��Ϣ�����ConboBox��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbEmp_Click(object sender, EventArgs e)
        {
            if (cbDept.Text != "")
            {
                int deptId = Convert.ToInt32(cbDept.SelectedValue);
                InitialzeEmpComboBox(deptId);
            }
        }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcpSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string condition = String.Empty;

                if (tbPNo.Text.Trim() != "")
                {
                    condition = "per.PathNo like '%" + tbPNo.Text + "%'";
                }
                else
                {
                    condition = "1=1";
                }

                if (tbPName.Text.Trim() != "")
                {
                    condition += "and pi.PathName like '%" + tbPName.Text + "%'";
                }

                if (tbEmpNo.Text.Trim() != "")
                {
                    condition += "and per.EmpNo like '%" + tbEmpNo.Text + "%'";
                }

                if (tbEmpName.Text.Trim() != "")
                {
                    condition += "and ei.EmpName like '%" + tbEmpName.Text + "%'";
                }

                if (pathEmpRelationbll == null)
                    pathEmpRelationbll = new PathEmpRelationBll();

                DataTable dt = pathEmpRelationbll.SelectPathEmpRelation(condition);

                SortDataGrid(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("��ѯ�������󣬷�վ��̽ͷ��ַӦ��Ϊ����", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pbDept_Click(object sender, EventArgs e)
        {
            InitialzeDeptComboBox();
        }

        private void cbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            int deptId = Convert.ToInt32(cbDept.SelectedValue);
            InitialzeEmpComboBox(deptId);
        }


        private void bcpPrint_Click(object sender, EventArgs e)
        {
            //FormPrint frm = new FormPrint();
            //frm.CallPrintForm(this.dgvMain, "Ա��·�߹�ϵ��Ϣ", "");
            KJ128NDBTable.PrintBLL.Print(this.dgvMain, "Ա��·�߹�ϵ��Ϣ", "");
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

                string strWhere = "PathNo='" + tbPathNo.Text
                    + "' and EmpNo='" + cbEmp.SelectedValue.ToString() + "'";

                if (RecordSearch.IsRecordExists("Path_Emp_Relation", strWhere))
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
            //ɾ��
            else if (operated == 2)
            {
                timer1.Interval = 1000;

                string value = dgvMain.CurrentRow.Cells["Id"].Value.ToString();
                if (!RecordSearch.IsRecordExists("Path_Emp_Relation", "Id", value, DataType.String))
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
            //�޸�
            else
            {
                timer1.Interval = 400;

                string ID = dgvMain.CurrentRow.Cells["Id"].Value.ToString();
                string strWhere = "PathNo='" + tbPathNo.Text
                    + "' and EmpNo='" + cbEmp.SelectedValue.ToString()
                    + "' and Id=" + ID;

                if (RecordSearch.IsRecordExists("Path_Emp_Relation", strWhere))
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

        #endregion        

        private void bcpRef_Click(object sender, EventArgs e)
        {
            InitialzeDataGridView();
        }
    }
}