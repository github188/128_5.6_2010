using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NMainRun.RealTime
{
    public partial class FrmRealTimeOverEmp : Wilson.Controls.Docking.DockContent
    {

        #region [ ���� ]

        private RealTimeOverEmpBLL rtoebll = new RealTimeOverEmpBLL();

        #endregion

        #region [ ���캯�� ]

        public FrmRealTimeOverEmp()
        {
            InitializeComponent();

            //��ѯ��Ա��Ϣ
            SelectOverEmp();
        }

        #endregion

        /*
         * ����
         */ 

        #region [ ����: ��ѯ��Ա��Ϣ ]

        private void SelectOverEmp()
        {
            rtoebll.SelectOverEmp(1, dgvOverEmp);

            buttonCaptionPanel1.CaptionTitle = "ʵʱ��Ա��ʾ��\t��" + dgvOverEmp.Rows.Count.ToString() + "����Ϣ";

        }

        #endregion

        /*
         * �¼�
         */ 
         
        #region [ �¼�: �Ƿ�����ʵʱ���� ]

        private void chk_EnabledChanged(object sender, EventArgs e)
        {
            if (chk.Checked)
            {
                this.timer.Start();
            }
            else
            {
                this.timer.Stop();
            }
        }

        #endregion

        #region [ �¼�: ��ʱ�� ]

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                this.SelectOverEmp();
            }
        }

        #endregion

        #region [ �¼�: ��ӡ ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvOverEmp,Text);
        }

        #endregion

    }
}