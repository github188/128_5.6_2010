using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NDataBase;
using Shine.Logs;
using Shine.Logs.LogType;

namespace KJ128NMainRun.EquManage
{
    public partial class FrmEquEdit : Wilson.Controls.Docking.DockContent
    {
        EquBLL equDAL = new EquBLL();
        DeptBLL deptBll = new DeptBLL();
        DataTable dtEqu = null;
        DataTable dtDetail = null;
        public FrmEquEdit()
        {
            InitializeComponent();
            Init();
        }

        #region ��ʼ����

        public void Init()
        {
            BindDept();
            BindType();
            BindState();
            BindFactory();
            txtEquHeight.Text = "0";
            txtEquPower.Text = "0";
        }

        #region ��
        // �󶨲���
        public void BindDept()
        {
            deptBll.getDept(cmbDeptID);
        }

        // �豸����
        public void BindType()
        {
            deptBll.getEquType(cmbEquType);
        }

        // �豸״̬
        public void BindState()
        {
            deptBll.getEquState(cmbEquState);
        }

        // ��������
        public void BindFactory()
        {
            deptBll.getFactory(cmbFactoryID);
        }
        #endregion 

        #endregion

        #region �ж�����ӻ����޸�
        /// <summary>
        /// �ж�����ӻ����޸�
        /// </summary>
        public void GetValue()
        {
            if (this.Text == "�޸��豸��Ϣ")
            { 
                // �޸�
                btnEdit.Text = "�޸�";
                ShowValue();
            }
            else
            { 
                // ���
                btnEdit.Text = "���";
            }
        }
        #endregion 

        #region ��ֵ
        /// <summary>
        /// ��ֵ
        /// </summary>
        public void ShowValue()
        {
            if (dtEqu == null) return;
            if (dtEqu.Rows.Count > 0)
            {
                // �����Կؼ���ֵ
                DataRow dr = dtEqu.Rows[0];
                // ������ĸ�ֵ
                txtEquNO.Text = dr["EquNO"].ToString();
                txtEquName.Text = dr["EquName"].ToString();
                
                // �жϲ����Ƿ����
                cmbDeptID.SelectedValue = dr["DeptID"].ToString();

                // �ж����������Ƿ����
                cmbFactoryID.SelectedValue = dr["FactoryID"].ToString();
                
                cmbEquState.SelectedValue = dr["EquState"].ToString();
                cmbEquType.SelectedValue = dr["EquType"].ToString();
                txtRemark.Text = dr["Remark"].ToString();
            }

            if (dtDetail == null) return;
            if (dtDetail.Rows.Count > 0)
            {
                DataRow dr = dtDetail.Rows[0];
                txtModelSpecial.Text = dr["ModelSpecial"].ToString();
                txtDutyEmployee.Text = dr["DutyEmployee"].ToString();
                dtimeProductionDate.Text = dr["ProductionDate"].ToString();
                txtEquHeight.Text = dr["EquHeight"].ToString() == "0" ? "" : dr["EquHeight"].ToString();
                txtEquPower.Text = dr["EquPower"].ToString() == "0" ? "" : dr["EquPower"].ToString();
                txtUseRange.Text = dr["UseRange"].ToString();
                dtimeUserDate.Text = dr["UserDate"].ToString();
            }
        }
        #endregion 

        #region ���
        /// <summary>
        /// ���
        /// </summary>
        public void ClearCon()
        { 
            foreach (Control ctl in Controls)
            {
                if(ctl.GetType() == typeof(TextBox))
                {
                    ctl.Text = "";
                }
            }
            dtimeProductionDate.Text = DateTime.Now.ToString("yyyy��M��d��");
            dtimeUserDate.Text = DateTime.Now.ToString("yyyy��M��d��");
        }
        #endregion

        #region ShowDialog

        public void ShowDialog(DataTable dt,DataTable dtD)
        {
            dtEqu = dt;
            dtDetail = dtD;
            GetValue();
            ShowDialog();
        }
        #endregion

        #region ��ť�¼�

        #region ��������
        // ��������
        private void plEqu_BaseInfo_ShiftButtonMouseClick(object sender, EventArgs e)
        {
            vsPanel.RainRangeControl();
            vsPanel.Height = vsPanel.Controls[vsPanel.Controls.Count - 1].Top + vsPanel.Controls[vsPanel.Controls.Count - 1].Height + 10;
            this.Height = vsPanel.Height + 50;
        }
        #endregion 

        #region ���أ�ȡ��
        // ����
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ȡ��
        private void btnCanel_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "�޸�")
            { 
                // �޸�(���¼���)
                ShowValue();
            }
            else
            { 
                // ���
                ClearCon();
            }
        }
        #endregion 

        #region �Ƿ���д����
        /// <summary>
        /// �Ƿ���д����
        /// </summary>
        /// <returns>0Ϊ��д����</returns>
        public int  IsFull()
        {
            int i = 0;
            foreach (Control ctl in plEqu_BaseInfo.Controls)
            {
                if (ctl.GetType() == typeof(ComboBox))
                {
                    if (ctl.Text == "")
                    {
                        ctl.BackColor = Color.Yellow;
                        i++;
                    }
                    else
                    {
                        ctl.BackColor = Color.Empty;
                    }
                }
            }
            return i;
        }
        #endregion

        #region ȷ��
        // ȷ��
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // �ж��Ƿ���д����
            if (IsFull() != 0)
            {
                return;
            }

            if (txtEquHeight.Text.Trim() == "")
            {
                MessageBox.Show("��������Ϊ�գ�");
                return;
            }
            if (this.txtEquPower.Text.Trim() == "")
            {
                MessageBox.Show("���Ĳ���Ϊ�գ�");
                return;
            }
            try
            {
                int.Parse(txtEquHeight.Text);
            }
            catch
            {
                MessageBox.Show("����ֻ��Ϊ����!");
                return;
            }
            if (btnEdit.Text == "�޸�")
            {
                //������־
                LogSave.Messages("[FrmEquEdit]", LogIDType.UserLogID, "�޸��豸��Ϣ���������ң�" + cmbFactoryID.SelectedText.ToString() + "���豸���ƣ�" + txtEquName.Text);

                // �޸ı�����Ϣ
                int intCount = equDAL.UpdateEqu_BaseInfo(txtEquNO.Text, txtEquName.Text, cmbDeptID.Text == "" ? 0 : int.Parse(cmbDeptID.SelectedValue.ToString()),
                    cmbEquType.Text == "" ? 0 : int.Parse(cmbEquType.SelectedValue.ToString()), cmbEquState.Text == "" ? 0 : int.Parse(cmbEquState.SelectedValue.ToString()),
                    cmbFactoryID.Text == "" ? 0 : int.Parse(cmbFactoryID.SelectedValue.ToString()), txtRemark.Text, int.Parse(dtEqu.Rows[0]["EquID"].ToString()));

                if (dtDetail.Rows.Count < 1)
                {
                    if (!IsFill())
                    {
                        // ����ϸ�������
                        int intCounta = equDAL.AddEqu_Detail(int.Parse(dtEqu.Rows[0]["EquID"].ToString()), txtModelSpecial.Text, txtDutyEmployee.Text, txtUseRange.Text,
                            Convert.ToDateTime(dtimeProductionDate.Text).ToString("yyyy-M-d"), txtEquHeight.Text == "" ? 0 : int.Parse(txtEquHeight.Text), txtEquPower.Text == "" ? 0 : int.Parse(txtEquPower.Text),
                            Convert.ToDateTime(dtimeUserDate.Text).ToString("yyyy-M-d"));
                        if (intCounta == -1)
                        {
                            MessageBox.Show("��ϸ��Ϣ�޸�ʧ��");
                            return;
                        }
                        else if (intCounta == 0)
                        {
                            //return;
                        }
                    }
                }
                else
                {
                    // �޸�ѡ����Ϣ
                    int intCountD = equDAL.UpdateEqu_Detail(txtModelSpecial.Text, txtDutyEmployee.Text, txtUseRange.Text, dtimeProductionDate.Text,
                        int.Parse(txtEquHeight.Text), int.Parse(txtEquPower.Text), dtimeUserDate.Text, int.Parse(dtDetail.Rows[0]["EquDetailID"].ToString()));
                }
                if (intCount == 1 && intCount == 1) MessageBox.Show("�޸ĳɹ�");
                this.Close();
            }
            else
            {
                //������־
                LogSave.Messages("[FrmEquEdit]", LogIDType.UserLogID, "����豸��Ϣ���������ң�" + cmbEquType.SelectedText.ToString() + "���豸���ƣ�" + txtEquName.Text);

                // ������Ƿ���д����
                if (!IsNull()) return;
                int iCount = equDAL.AddEqu_BaseInfo(txtEquNO.Text, txtEquName.Text, cmbDeptID.Text == "" ? 0 : int.Parse(cmbDeptID.SelectedValue.ToString()),
                    cmbEquType.Text == "" ? 0 : int.Parse(cmbEquType.SelectedValue.ToString()), cmbEquState.Text == "" ? 0 : int.Parse(cmbEquState.SelectedValue.ToString()),
                    cmbFactoryID.Text == "" ? 0 : int.Parse(cmbFactoryID.SelectedValue.ToString()), txtRemark.Text);
                if (iCount == -1)
                {
                    MessageBox.Show("���ʧ��");
                    return;
                }
                else if (iCount == 0)
                {
                    MessageBox.Show("����ӵ��豸����Ѵ��ڣ���������д");
                    txtEquNO.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("��ӳɹ���", "��ʾ", MessageBoxButtons.OK);
                }

                // ���EquID
                //DataTable dt = equDAL.GetEquID(txtEquNO.Text);
                //int int_EquID = int.Parse(dt.Rows[0]["EquID"].ToString());

                // �ж���ϸ��Ϣ�Ƿ���д
                if (!IsFill())
                {
                    // ����ϸ�������
                    int intCount = equDAL.AddEqu_Detail(/*int.Parse(dtEqu.Rows[0]["EquID"].ToString())*/txtEquNO.Text.Trim(), txtModelSpecial.Text, txtDutyEmployee.Text, txtUseRange.Text,
                            Convert.ToDateTime(dtimeProductionDate.Text).ToString("yyyy-M-d"), txtEquHeight.Text == "" ? 0 : int.Parse(txtEquHeight.Text), txtEquPower.Text == "" ? 0 : int.Parse(txtEquPower.Text),
                            Convert.ToDateTime(dtimeUserDate.Text).ToString("yyyy-M-d"));
                    if (intCount != 1)
                    {
                        MessageBox.Show("��ϸ��Ϣ���ʧ��");

                        return;
                    }
                }
            }
            this.Close();
        }
        #endregion

        #endregion 

        #region �Ƿ�Ҫ����ϸ�������
        /// <summary>
        /// �Ƿ�Ҫ����ϸ�������
        /// </summary>
        /// <returns>true(�����)</returns>
        public bool IsFill()
        {
            bool isEmpty = true;
            foreach (Control ctl in plEquDetail.Controls)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    if (ctl.Text != "")
                    {
                        // �޸���
                        isEmpty = false;
                    }
                }
            }
            if (Convert.ToDateTime(dtimeProductionDate.Text).ToString("yyyy-M-d") != DateTime.Now.ToString("yyyy-M-d") || DateTime.Parse(dtimeUserDate.Text).ToString("yyyy-M-d") != DateTime.Now.ToString("yyyy-M-d"))
            {
                // �޸���
                isEmpty = false;
            }
            return isEmpty;
        }
        #endregion

        #region �ж���д�Ƿ�����
        /// <summary>
        /// �ж���д�Ƿ�����
        /// </summary>
        /// <returns>true(����)</returns>
        public bool IsNull()
        {
            if (txtEquNO.Text == "")
            {
                MessageBox.Show("����д�豸���");
                txtEquNO.Focus();
                return false;
            }
            if (txtEquName.Text == "")
            {
                MessageBox.Show("����д�豸����");
                txtEquName.Focus();
                return false;
            }

            return true;
        }
        #endregion 

    }
}