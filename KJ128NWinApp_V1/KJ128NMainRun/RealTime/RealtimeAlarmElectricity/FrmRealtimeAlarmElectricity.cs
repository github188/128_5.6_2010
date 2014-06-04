using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NInterfaceShow;

namespace KJ128NMainRun.RealTime.RealtimeAlarmElectricity
{
    public partial class FrmRealtimeAlarmElectricity : Wilson.Controls.Docking.DockContent
    {

        #region [ ���� ]
        
        private RealtimeAlarmElectricityBLL raebll = new RealtimeAlarmElectricityBLL();

        private int intCsTypeID = 2;
        #endregion

        #region [ ���캯�� ]

        public FrmRealtimeAlarmElectricity()
        {
            InitializeComponent();
            SelectRealtimeAlarmElectricity();
        }

        #endregion

        /*
         * ����
         */ 

        #region [ ����: ��ѯʵʱ�͵�����Ϣ ]

        private void SelectRealtimeAlarmElectricity()
        {
            string strCounts;
            if (rbEmp.Checked)
            {
                intCsTypeID = 0;
            }
            else if (rbEqu.Checked)
            {
                intCsTypeID = 1;
            }
            else if (rbNotRegister.Checked)
            {
                intCsTypeID = 2;
            }
            else
            {
                intCsTypeID = 3;
            }
            raebll.N_SelectAlarmElectricity(4,intCsTypeID, dgvInfo,out strCounts);
            //bcpPageSum.Visible = true;
           // bcpPageSum.CaptionTitle = "�� " + strCounts + " ��������";
            if (rbEmp.Checked)
            {
                lb_Counts.Text = "�� " + strCounts + " ��";
            }
            else if (rbEqu.Checked)
            {
                lb_Counts.Text = "�� " + strCounts + " ���豸";
            }
            else
            {
                lb_Counts.Text = "�� " + strCounts + " ����ʶ��";
            }
        }

        #endregion
        
        /*
         * �¼�
         */ 

        #region [ �¼�: �Ƿ�ʵʱ�������� ]

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (chk.Checked)
            {
                timeControl.Start();
            }
            else
            {
                timeControl.Stop();
            }
        }

        #endregion

        #region [ �¼�: ��ʱ���¼� ]

        private void timeControl_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                SelectRealtimeAlarmElectricity();                //��ѯʵʱ�͵�����Ϣ
            }
        }

        #endregion

        #region [ �¼�: ��ӡ ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvInfo,Text);
        }

        #endregion

        #region [ �¼�: ѡ����Ա ]

        private void rbEmp_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEmp.Checked)
            {
                this.SelectRealtimeAlarmElectricity();
            }
        }

        #endregion

        #region [ �¼�: ѡ���豸 ]

        private void rbEqu_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEqu.Checked)
            {
                this.SelectRealtimeAlarmElectricity();
            }
        }

        #endregion

        #region [ �¼�: ѡ�����з����� ]

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAll.Checked)
            {
                this.SelectRealtimeAlarmElectricity();
            }
        }

        #endregion

        #region [ �¼�: ѡ��δ�Ǽǵķ����� ]

        private void rbNotRegister_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNotRegister.Checked)
            {
                this.SelectRealtimeAlarmElectricity();
            }
        }

        #endregion
    }

}