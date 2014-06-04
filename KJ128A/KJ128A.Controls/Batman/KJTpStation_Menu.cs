using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

namespace KJ128A.Controls.Batman
{
    internal class KJTpStation_Menu : ContextMenuStrip
    {
        private KJ128A.BatmanAPI.IFrmMain frmMain = null;

        private ToolStripMenuItem menuItemStation = new ToolStripMenuItem("�����վ");              // ��վ�˵�
        private ToolStripSeparator menuItemSeparator3 = new ToolStripSeparator();               // �ָ��� 3

        #region KJTpStation_Menu ���캯��

        /// <summary>
        /// ���캯��
        /// </summary>
        public KJTpStation_Menu(int index, KJ128A.BatmanAPI.IFrmMain frm)
        {
            frmMain = frm;
            Index = index;

            InitMenu();
        }

        #endregion

        #region [ ���� ] ����

        private int _Index;

        /// <summary>
        /// ����, ����ʼ���������ʱ, ���������ڵĳ�ʼ����ʶ
        /// </summary>
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        #endregion

        #region [ ���� ] ��ǰ�����Ļ�վ��ַ

        private int m_CurStationAddress = 0;

        /// <summary>
        /// ��ǰ�����Ļ�վ��ַ
        /// </summary>
        public int CurStationAddress
        {
            get
            {
                return m_CurStationAddress;
            }
            set
            {
                m_CurStationAddress = value;
            }
        }

        #endregion

        #region [ �˵� ] ��ʼ���˵�

        /// <summary>
        /// ��ʼ���˵�
        /// </summary>
        public void InitMenu()
        {
            // �����˵�
            ToolStripMenuItem menuItemReset = new ToolStripMenuItem("����");
            menuItemReset.Click += new System.EventHandler(menuItemReset_Click);
            Items.Add(menuItemReset);

            // �ָ���
            Items.Add("-");

            // ���Ѳ˵�
            ToolStripMenuItem menuItemWaken = new ToolStripMenuItem("����");
            menuItemWaken.Click += new System.EventHandler(menuItemWaken_Click);
            Items.Add(menuItemWaken);

            // ���߲˵�
            ToolStripMenuItem menuItemSleep = new ToolStripMenuItem("����");
            menuItemSleep.Click += new System.EventHandler(menuItemSleep_Click);
            Items.Add(menuItemSleep);

            // �ָ���
            Items.Add("-");

            //����Ѳ��
            ToolStripMenuItem menuItemPoint = new ToolStripMenuItem("����Ѳ��");
            menuItemPoint.Click += new EventHandler(menuItemPoint_Click);
            Items.Add(menuItemPoint);

            ////�ָ���
            //Items.Add("-");
            
            ////˫��ͨѶ
            //ToolStripMenuItem menuItemTwo = new ToolStripMenuItem("˫��ͨѶ");
            //menuItemTwo.Click += new EventHandler(menuItemTwo_Click);
            //Items.Add(menuItemTwo);

            // �ָ���
            Items.Add(menuItemSeparator3);

            // ��վ�˵�
            //Items.Add(menuItemStation);

            // ��ӻ�վ
            ToolStripMenuItem menuItemStationAdd = new ToolStripMenuItem("���");
            menuItemStationAdd.Click += new EventHandler(menuItemStationAdd_Click);
            menuItemStation.DropDownItems.Add(menuItemStationAdd);

            // �༭��վ
            ToolStripMenuItem menuItemStationEdit = new ToolStripMenuItem("�༭");
            menuItemStationEdit.Click += new EventHandler(menuItemStationEdit_Click);
            menuItemStation.DropDownItems.Add(menuItemStationEdit);

            // ɾ����վ
            ToolStripMenuItem menuItemStationDel = new ToolStripMenuItem("ɾ��");
            menuItemStationDel.Click += new EventHandler(menuItemStationDel_Click);
            menuItemStation.DropDownItems.Add(menuItemStationDel);

        }

        //void menuItemTwo_Click(object sender, EventArgs e)
        //{
            
        //}

        void menuItemPoint_Click(object sender, EventArgs e)
        {

            int iStationAddress = 0;
            try
            {
                iStationAddress = int.Parse(CurStationAddress.ToString());
            }
            catch { return; }
            if (iStationAddress != 0)
            {
                if (Items[5].Text.Equals("����Ѳ��"))
                {
                    Items[5].Text = "����" + CurStationAddress.ToString() + "�Ŷ���Ѳ��";
                    if (frmMain.GetCommType())//����
                    {
                        frmMain.Station_ChangeState(iStationAddress, KJ128A.BatmanAPI.EnumStationState.PointSelect);
                    }
                    else//����
                    {
                        frmMain.Station_ChangeState(Index, iStationAddress, KJ128A.BatmanAPI.EnumStationState.PointSelect);
                    }
                    //frmMain.Station_ChangeState(Index, iStationAddress, KJ128A.BatmanAPI.EnumStationState.PointSelect);
                }
                else
                {
                    Items[5].Text = "����Ѳ��";
                    if (frmMain.GetCommType())//����
                    {
                        frmMain.Station_ChangeState(iStationAddress, KJ128A.BatmanAPI.EnumStationState.PointCancal);
                    }
                    else//����
                    {
                        frmMain.Station_ChangeState(Index, iStationAddress, KJ128A.BatmanAPI.EnumStationState.PointCancal);
                    }
                    //frmMain.Station_ChangeState(Index, iStationAddress, KJ128A.BatmanAPI.EnumStationState.PointCancal);
                }
            }
        }

        // ɾ����վ
        void menuItemStationDel_Click(object sender, EventArgs e)
        {
            int iStationAddress = int.Parse(CurStationAddress.ToString());
            frmMain.Station_Change(Index, iStationAddress, KJ128A.BatmanAPI.EnumOP.Del);
        }

        /// <summary>
        /// �༭��վ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuItemStationEdit_Click(object sender, EventArgs e)
        {
            int iStationAddress = int.Parse(CurStationAddress.ToString());
            frmMain.Station_Change(Index, iStationAddress, KJ128A.BatmanAPI.EnumOP.Edit);
        }

        /// <summary>
        /// ��ӻ�վ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuItemStationAdd_Click(object sender, EventArgs e)
        {
            int iStationAddress = int.Parse(CurStationAddress.ToString());
            frmMain.Station_Change(Index, iStationAddress, KJ128A.BatmanAPI.EnumOP.Add);
            
        }

        /// <summary>
        /// ��վ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemWaken_Click(object sender, System.EventArgs e)
        {
            int iStationAddress = 0;
            try
            {
                iStationAddress = int.Parse(CurStationAddress.ToString());
            }
            catch { return; }
            if (iStationAddress != 0)
            {
                if (frmMain.GetCommType())//����
                {
                    frmMain.Station_ChangeState(iStationAddress, KJ128A.BatmanAPI.EnumStationState.NoInit);
                }
                else//����
                {
                    frmMain.Station_ChangeState(Index, iStationAddress, KJ128A.BatmanAPI.EnumStationState.NoInit);
                }
                //frmMain.Station_ChangeState(Index, iStationAddress, KJ128A.BatmanAPI.EnumStationState.NoInit);
            }
        }

        /// <summary>
        /// ��վ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemSleep_Click(object sender, System.EventArgs e)
        {
            int iStationAddress = 0;
            try
            {
                iStationAddress = int.Parse(CurStationAddress.ToString());
            }
            catch { return; }
            if (iStationAddress != 0)
            {
                bool blnOP;
                if (frmMain.GetCommType())//����
                {
                    blnOP = frmMain.Station_ChangeState(iStationAddress, KJ128A.BatmanAPI.EnumStationState.Sleep);
                }
                else
                {
                    blnOP = frmMain.Station_ChangeState(Index, iStationAddress, KJ128A.BatmanAPI.EnumStationState.Sleep);
                }

                if (!blnOP)
                {
                    MessageBox.Show("���һ�������վ��������");
                }
            }
        }

        /// <summary>
        /// ��վ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemReset_Click(object sender, System.EventArgs e)
        {
            int iStationAddress = 0;
            try
            {
                iStationAddress = int.Parse(CurStationAddress.ToString());
            }
            catch { return; }
            if (iStationAddress != 0)
            {
                if (frmMain.GetCommType())//����
                {
                    frmMain.Station_ChangeState(iStationAddress, KJ128A.BatmanAPI.EnumStationState.Reset);
                }
                else//����
                {
                    frmMain.Station_ChangeState(Index, iStationAddress, KJ128A.BatmanAPI.EnumStationState.Reset);
                }
            }
        }

        #endregion
    }
}
