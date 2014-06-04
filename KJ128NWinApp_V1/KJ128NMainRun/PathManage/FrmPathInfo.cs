using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using KJ128NModel;
using System.Text;
using System.Windows.Forms;
using KJ128NInterfaceShow;
using ZdcCommonLibrary;
using KJ128WindowsLibrary;
using KJ128NDBTable;
using Shine.Logs;
using Shine.Logs.LogType;
using PrintCore;
using KJ128NDataBase;


namespace KJ128NMainRun.PathManage
{
    public partial class FrmPathInfo : Wilson.Controls.Docking.DockContent
    {
        #region [���캯��]

        public FrmPathInfo()
        {
            InitializeComponent();
        }

        #endregion

        #region [�ֶ�]

        private PathInfoBll infoBll = new PathInfoBll();

        //private KJ128NSerialAndDeserial KJ128Nsad = new KJ128NSerialAndDeserial();

        #endregion

        #region [˽�з���]

        #region [�����޸Ĳ���]

        /// <summary>
        /// �ر��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcpAdd_CloseButtonClick(object sender, EventArgs e)
        {
            this.vspnlAdd.Visible = false;
        }

        /// <summary>
        /// ���"������·",��ʾ�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcpNew_Click(object sender, EventArgs e)
        {
            InitializeToNew();
        }

        /// <summary>
        /// ���"������·"����ʼ��������Ϣ״̬
        /// </summary>
        private void InitializeToNew()
        {
            this.lblPathId.Visible = false;
            this.tbPathId.Visible = false;
            this.btnAddNew.Visible = true;
            this.tbPathNo.Text = "";
            this.tbPathName.Text = "";
            this.tbRemark.Text = "";
            this.btnAddNew.CaptionTitle = "���沢����";
            this.btnAdd.CaptionTitle = "����";
            this.bcpAdd.CaptionTitle = "������·��Ϣ";
            this.vspnlAdd.Visible = true;
        }

        /// <summary>
        /// �޸�·����Ϣʱ����ʼ���޸���Ϣ״̬
        /// </summary>
        /// <param name="pachinfo"></param>
        private void InitializeToUpdate(PathInfoModel pathInfo)
        {
            if (pathInfo != null)
            {
                //this.lblPathId.Visible = true;
                //this.tbPathId.Visible = true;
                this.btnAddNew.Visible = false;
                this.tbPathId.Text = pathInfo.Id.ToString();
                this.tbPathNo.Text = pathInfo.PathNo.ToString();
                this.tbPathName.Text = pathInfo.PathName;
                this.tbRemark.Text = pathInfo.Remark;
                this.bcpAdd.CaptionTitle = "�޸���·��Ϣ";
                this.btnAdd.CaptionTitle = "�޸�";
                this.vspnlAdd.Visible = true;
            }
        }

        /// <summary>
        /// ��� "����" "�޸�" ǰ�����ݵļ��
        /// </summary>
        /// <returns>�Ƿ���֤ͨ��</returns>
        private bool CheckValue()
        {
            try
            {
                //if (tbPathId.Text.Trim() == "")
                //{
                //    MessageBox.Show("��·Id����Ϊ��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return false;
                //}

                if (tbPathNo.Text.Trim() == "")
                {
                    MessageBox.Show("��·��Ų���Ϊ��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (tbPathName.Text.Trim() == "")
                {
                    MessageBox.Show("��·������Ϊ��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                return true;
            }
            catch (FormatException fe)
            {
                MessageBox.Show("�����·Id�Ƿ�Ϊ����", fe.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// ��Ӻ��޸�PathInfo��Ϣ����ӣ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValue())
                {
                    operated = 1;

                    //������Ϣ
                    if (btnAdd.CaptionTitle == "����")
                    {
                        //MessageBox.Show("����");

                        pathnum = tbPathNo.Text;

                        int result = AddPathInfoModel();

                        if (result > 0)
                        {
                            vspnlAdd.Visible = false;
                            MessageBox.Show("�����Ϣ�ɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (!New_DBAcess.IsDouble)
                            {
                                InitializeTreeView("");

                                InitializeGridView("");
                            }
                            else
                            {
                                timer1.Start();
                            }
                        }
                        else
                        {
                            MessageBox.Show("�����Ϣʧ��,��¼�Ѿ�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                    //�޸���Ϣ
                    else if (btnAdd.CaptionTitle == "�޸�")
                    {
                        pathnum = tbPathNo.Text;

                        int result = UpdatePathInfoModel();

                        if (result > 0)
                        {
                            vspnlAdd.Visible = false;
                            MessageBox.Show("�޸���Ϣ�ɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (!New_DBAcess.IsDouble)
                            {
                                InitializeTreeView("");

                                InitializeGridView("");
                            }
                            else
                            {
                                timer1.Start();
                            }
                        }
                        else
                        {
                            MessageBox.Show("�޸���Ϣʧ��,��¼�Ѿ�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ��Ӻ��޸�PathInfo��Ϣ����Ӳ�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValue())
                {
                    if (btnAddNew.CaptionTitle == "���沢����")
                    {

                        operated = 1;

                        int result = AddPathInfoModel();

                        pathnum = tbPathNo.Text;

                        if (result > 0)
                        {
                            MessageBox.Show("�����Ϣ�ɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);



                            InitializeToNew();

                            if (!New_DBAcess.IsDouble)
                            {
                                InitializeTreeView("");

                                InitializeGridView("");
                            }
                            else
                            {
                                timer1.Start();
                            }
                        }
                        else
                        {
                            MessageBox.Show("�����Ϣʧ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <returns></returns>
        private int AddPathInfoModel()
        {
            try
            {

                //Serial_Path_Info serialPathInfo = new Serial_Path_Info();

                //serialPathInfo.Operate = 1;
                //serialPathInfo.TableName = "Path_Info";
                //serialPathInfo.PathNo = this.tbPathNo.Text;
                //serialPathInfo.PathName = this.tbPathName.Text;
                //serialPathInfo.Remark = this.tbRemark.Text;

                //bool flag = KJ128Nsad.DataReceived(KJ128Nsad.SerialOperate(serialPathInfo));

                //������־
                LogSave.Messages("[FrmPathInfo]", LogIDType.UserLogID, "���·��������Ϣ��·�߱�ţ�" + this.tbPathNo.Text + "��·������" + this.tbPathName.Text + "��");


                KJ128NModel.PathInfoModel model = new PathInfoModel();
                model.PathNo = this.tbPathNo.Text;
                model.PathName = this.tbPathName.Text;
                model.Remark = this.tbRemark.Text;
                string strMessage="";
                 int count = infoBll.InsertPathInfo(model,out strMessage);

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
        /// �޸���Ϣ
        /// </summary>
        /// <returns></returns>
        private int UpdatePathInfoModel()
        {
            try
            {

                //Serial_Path_Info serialPathInfo = new Serial_Path_Info();

                //serialPathInfo.Operate = 2;
                //serialPathInfo.TableName = "Path_Info";
                //serialPathInfo.Id = Convert.ToInt32(this.tbPathId.Text.Trim());
                //serialPathInfo.PathNo = this.tbPathNo.Text;
                //serialPathInfo.PathName = this.tbPathName.Text;
                //serialPathInfo.Remark = this.tbRemark.Text;

                //bool flag = KJ128Nsad.DataReceived(KJ128Nsad.SerialOperate(serialPathInfo));

                //������־
                LogSave.Messages("[FrmPathInfo]", LogIDType.UserLogID, "�޸�·��������Ϣ��·�߱�ţ�" + this.tbPathNo.Text + "��·������" + this.tbPathName.Text + "��");

                KJ128NModel.PathInfoModel model = new PathInfoModel();
                model.Id = Convert.ToInt32(this.tbPathId.Text.Trim());
                model.PathNo = this.tbPathNo.Text;
                model.PathName = this.tbPathName.Text;
                model.Remark = this.tbRemark.Text;
                string strMessage = "";
                int count = infoBll.UpdatePathInfo(model,out strMessage);

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

        #endregion

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

        #region [ȡ���ݺ�ˢ�½���]

        /// <summary>
        /// ��ȡPathInfo��Ϣ
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <returns>��ѯ���ı�</returns>
        private DataTable GetPathInfo(string condition)
        {
            if (infoBll == null)
                infoBll = new PathInfoBll();

            DataTable dt = infoBll.SelectPathInfo(condition);

            return dt;
        }

        /// <summary>
        /// ������οؼ�
        /// </summary>
        private void InitializeTreeView(string condition)
        {
            try
            {
                //�����
                tvPathInfo.Nodes[0].Nodes.Clear();

                DataTable dt = GetPathInfo(condition);

                foreach (DataRow dr in dt.Rows)
                {
                    TreeNode node = new TreeNode(dr["PathName"].ToString());

                    node.Name = dr["Id"].ToString();

                    node.Text = dr["PathName"].ToString();

                    node.ToolTipText = "·�߱��:" + dr["PathNo"].ToString() + "\n"
                        + "·����:" + dr["PathName"].ToString() + "\n"
                        + "·�߱�ע��" + dr["Remark"].ToString();
                    tvPathInfo.Nodes[0].Nodes.Add(node);
                }

                tvPathInfo.ExpandAll();
            }
            catch
            {
                MessageBox.Show("����·������Ϣʧ��", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ���DataGridView
        /// </summary>
        private void InitializeGridView(string condition)
        {
            DataTable dt = GetPathInfo(condition);
            this.dgvMain.DataSource = dt;
            dgvMain.Columns["PathName"].DisplayIndex = 2;
        }

        /// <summary>
        /// ˢ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcpRefresh_Click(object sender, EventArgs e)
        {
            InitializeTreeView("");

            InitializeGridView("");
        }

        #endregion

        #region [�������ʱ������Ϣ]

        private void FrmPathInfo_Load(object sender, EventArgs e)
        {
            //������
            InitializeTreeView("");

            //����DataGrid
            InitializeGridView("");

        }

        #endregion

        #region [���Ұ�ť����]

        /// <summary>
        /// ���ҷ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSerch_Click(object sender, EventArgs e)
        {
            try
            {
                string condition = String.Empty;

                if (tbpId.Text.Trim() != "")
                {
                    condition = "Id like '%" + tbpId.Text + "%'";
                }
                else
                {
                    condition = "1=1";
                }
                if (tbpNo.Text.Trim() != "")
                {
                    condition += " and PathNo like '%" + tbpNo.Text + "%'";
                }

                if (tbpName.Text.Trim() != "")
                {
                    condition += " and PathName like '%" + tbpName.Text + "%'";
                }

                if (tbpRemark.Text.Trim() != "")
                {
                    condition += " and Remark like '%" + tbpRemark.Text + "%'";
                }

                if (infoBll == null)
                    infoBll = new PathInfoBll();
                DataTable dt = infoBll.SelectPathInfo(condition);

                this.dgvMain.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("������������δ�ܲ�ѯ������", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region [���޸Ľ��棬ʵ��ɾ��]

        /// <summary>
        /// ����DataGridView���޸ĺ�ɾ������
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
                    PathInfoModel info = new PathInfoModel();

                    info.Id = Convert.ToInt32(dgvMain.CurrentRow.Cells["PathId"].Value.ToString());
                    info.PathNo = dgvMain.CurrentRow.Cells["PathNo"].Value.ToString();
                    info.PathName = dgvMain.CurrentRow.Cells["PathName"].Value.ToString();
                    info.Remark = dgvMain.CurrentRow.Cells["Remark"].Value.ToString();

                    InitializeToUpdate(info);
                }

                else if (operate == "ɾ��")
                {
                    operated = 2;

                    try
                    {
                        this.vspnlAdd.Visible = false;

                        DialogResult dr = MessageBox.Show("���Ƿ�ȷ��ɾ�������ȷ�Ͻ���ɾ����������������ݣ��޷��ָ�", "��Ҫȷ����ʾ",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            //������־
                            LogSave.Messages("[FrmPathInfo]", LogIDType.UserLogID, "ɾ��·��������Ϣ��·�߱�ţ�" + dgvMain.CurrentRow.Cells["PathNo"].Value.ToString()
                                + "��·������" + dgvMain.CurrentRow.Cells["PathName"].Value.ToString() + "��");

                            ////Serial_Path_Info serialPathInfo = new Serial_Path_Info();

                            ////serialPathInfo.Operate = 3;
                            ////serialPathInfo.TableName = "Path_Info";
                            ////serialPathInfo.Id = Convert.ToInt32(dbgvMain.CurrentRow.Cells["PathId"].Value.ToString());

                            ////bool flag = KJ128Nsad.DataReceived(KJ128Nsad.SerialOperate(serialPathInfo));
                            //(count == 1 ? true : false);
                            int id = Convert.ToInt32(dgvMain.CurrentRow.Cells["PathId"].Value.ToString());

                            int count = infoBll.DeletePathInfo(id);

                            bool flag = (count == 1 ? true : false);

                            if (flag)
                            {
                                if (!New_DBAcess.IsDouble)
                                {
                                    InitializeTreeView("");
                                    InitializeGridView("");
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
                        MessageBox.Show("ɾ��ʧ��:" + ex.Message, "��Ϣ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        private void bcpPrint_Click(object sender, EventArgs e)
        {
            //FormPrint frm = new FormPrint();
            //frm.CallPrintForm(this.dgvMain,"·�߻�����Ϣ","");
            KJ128NDBTable.PrintBLL.Print(this.dgvMain, "·�߻�����Ϣ", "");
        }

        private void cpnlTile_Load(object sender, EventArgs e)
        {

        }

        private void pnlSerach_Paint(object sender, PaintEventArgs e)
        {

        }

        #region [������]
        //private void tvPathInfo_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        if (e.Node.Parent == null)
        //        {
        //            MessageBox.Show("������");
        //        }
        //        else
        //        {
        //            MessageBox.Show(e.Node.Name.ToString());
        //        }
        //    }
        //}
        #endregion

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
        /// 1��ʾ ���ӣ��޸� 2 ��ʾɾ�� 
        /// </summary>
        private int operated = 1;

        private string pathnum = ""; 

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (operated == 1)
            {
                if (RecordSearch.IsRecordExists("Path_Info", "PathNo", pathnum, DataType.String))
                {
                    //ˢ��

                    InitializeTreeView("");

                    InitializeGridView("");

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
            else
            {
                string value = dgvMain.CurrentRow.Cells["PathNo"].Value.ToString();

                if (!RecordSearch.IsRecordExists("Path_Info", "PathNo", value, DataType.String))
                {
                    //ˢ��

                    InitializeTreeView("");

                    InitializeGridView("");

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
            InitializeTreeView("");
            InitializeGridView("");
        }
    }
}