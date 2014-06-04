using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using Shine.Logs;
using Shine.Logs.LogType;

namespace KJ128NMainRun.EquManage
{
    public partial class FrmFactoryEdit : Wilson.Controls.Docking.DockContent
    {
        EquBLL equDAL = new EquBLL();
        DataTable dt = null;

        #region ��ʼ��

        public FrmFactoryEdit()
        {
            InitializeComponent();
            // Init();
        }

        // ����һ������
        public void ShowDialog(DataTable dtUpdate )
        {
            dt = dtUpdate;
            Init();
            ShowDialog();
        }

        public void Init()
        {
            if (this.Text == "�޸ĳ�����Ϣ") // ���޸�Ҫ��
            {
                btnEdit.Text = "�޸�";

                if(dt == null) return;

                txtFactoryNO.Enabled = false;

                // �����пؼ���ֵ
                DataRow dr = dt.Rows[0];

                txtFactoryNO.Text = dr["FactoryNO"].ToString();
                txtFactoryName.Text = dr["FactoryName"].ToString();
                txtFactoryTel.Text = dr["FactoryTel"].ToString();
                txtRemark.Text = dr["Remark"].ToString();
                txtFactoryFax.Text = dr["FactoryFax"].ToString();
                txtFactoryEmpoyeeTel.Text = dr["FactoryEmpoyeeTel"].ToString();
                txtFactoryEmployee.Text = dr["FactoryEmployee"].ToString();
                txtFactoryAddress.Text = dr["FactoryAddress"].ToString();

                btnCanel.Visible = false;
            }
            else
            {
                btnEdit.Text = "���";
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
                if (ctl.GetType() == typeof(TextBox))
                {
                    ctl.Text = "";
                }
            }

            btnCanel.Visible = true;
        }
        #endregion 

        #region �ж��Ƿ�Ϊ��
        /// <summary>
        /// �ж��Ƿ�Ϊ��
        /// </summary>
        /// <returns></returns>
        public bool IsNull()
        {
            if (txtFactoryNO.Text == "")
            {
                MessageBox.Show("����д���ұ��");
                txtFactoryNO.Focus();
                return false;
            }

            if (txtFactoryName.Text == "")
            {
                MessageBox.Show("����д��������");
                txtFactoryName.Focus();
                return false;
            }

            return true;
        }
        #endregion

        #region ��ť�¼�

        #region ȡ��
        // ȡ��
        private void btnCanel_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "�޸�")
            {
                // ���¼��ش��������
                Init();
            }
            else
            { 
                // ���
                ClearCon();
            }
        }
        #endregion 

        #region ��ӣ��޸�
        // ��ӣ��޸�
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!IsNull()) return;
            if (btnEdit.Text == "�޸�")
            {
                //������־
                LogSave.Messages("[FrmFactoryEdit]", LogIDType.UserLogID, "�޸�����������Ϣ���������ұ�ţ�" + txtFactoryNO.Text + "�������������ƣ�" + txtFactoryName.Text);

                DataRow dr = dt.Rows[0];
                // �޸�
                int intCount = equDAL.UpdateFactory(txtFactoryNO.Text, txtFactoryName.Text, txtFactoryAddress.Text,txtFactoryFax.Text, 
                    txtFactoryTel.Text, txtFactoryEmployee.Text, txtFactoryEmpoyeeTel.Text, txtRemark.Text, int.Parse(dr["FactoryID"].ToString()));
                if (intCount == 1)
                {
                    MessageBox.Show("�޸ĳɹ�");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("�޸Ĳ��ɹ�");
                }
            }
            else
            {
                //������־
                LogSave.Messages("[FrmFactoryEdit]", LogIDType.UserLogID, "��������������Ϣ���������ұ�ţ�" + txtFactoryNO.Text + "�������������ƣ�" + txtFactoryName.Text);

                // �����ݿ����
                int intCount = equDAL.AddFactory(txtFactoryNO.Text, txtFactoryName.Text, txtFactoryAddress.Text, 
                    txtFactoryFax.Text, txtFactoryTel.Text, txtFactoryEmployee.Text, txtFactoryEmpoyeeTel.Text, txtRemark.Text);

                if (intCount == 1)
                {
                    MessageBox.Show("��ӳɹ�");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("���������ҵı���Ѿ��������������");
                    return;
                }
                
            }
            
        }
        #endregion 

        #region ����
        // ����
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #endregion 

    }
}