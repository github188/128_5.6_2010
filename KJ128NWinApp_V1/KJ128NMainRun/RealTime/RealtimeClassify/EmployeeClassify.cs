using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128WindowsLibrary;
using KJ128NDBTable;

namespace KJ128NInterfaceShow
{
    public partial class EmployeeClassify : Wilson.Controls.Docking.DockContent
    {

        #region [ ���� ]

        private RTClassifyBLL rtcbll = new RTClassifyBLL();

        private int intSelect = 0;

        #endregion


        #region [ ���캯�� ]

        public EmployeeClassify()
        {
            InitializeComponent();
            //����Ĭ��Ϊ�¾����ֻ���
            captionPanel1.SetCaptionPanelStyle = CaptionPanelStyleEnum.Office2007Panel;
            captionPanel2.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
            captionPanel3.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
            captionPanel4.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
            captionPanel5.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
            dgv_WorkType.Visible = false;

            rtcbll.N_LoadInfo(treeView1, "WorkType", 0);
        }
        #endregion

        /*
         * �¼�
         */ 

        #region [ �¼�: �����ֻ���_Click�¼� ]

        private void captionPanel1_Click(object sender, EventArgs e)
        {
            if (rtcbll.N_LoadInfo(treeView1, "WorkType", 0))
            {
                captionPanel1.SetCaptionPanelStyle = CaptionPanelStyleEnum.Office2007Panel;
                captionPanel2.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel3.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel4.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel5.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel6.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;

                buttonCaptionPanel1.CaptionTitle = "���ݲ�ͬ�Ĺ��ֶ�Ա���¾���Ϣ���л���:";
                dgv_WorkType.Visible = false;
                treeView1.Visible = true;
                intSelect = 1;
            }
        }

        #endregion

        #region [ �¼�: �����Ż���_Click�¼� ]

        private void captionPanel2_Click(object sender, EventArgs e)
        {
            if (rtcbll.N_LoadInfo(treeView1, "Dept", 0))
            {
                captionPanel1.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel2.SetCaptionPanelStyle = CaptionPanelStyleEnum.Office2007Panel;
                captionPanel3.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel4.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel5.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel6.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;

                buttonCaptionPanel1.CaptionTitle = "���ݲ�ͬ�Ĳ��Ŷ�Ա���¾���Ϣ���л���:";
                dgv_WorkType.Visible = false;
                treeView1.Visible = true;
                intSelect = 2;
            }
        }

        #endregion

        #region [ �¼�: ��ְ�����_Click�¼� ]

        private void captionPanel3_Click(object sender, EventArgs e)
        {
            if (rtcbll.N_LoadInfo(treeView1, "Business", 0))
            {
                captionPanel1.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel2.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel3.SetCaptionPanelStyle = CaptionPanelStyleEnum.Office2007Panel;
                captionPanel4.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel5.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel6.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;

                buttonCaptionPanel1.CaptionTitle = "���ݲ�ͬ��ְ���Ա���¾���Ϣ���л���:";
                dgv_WorkType.Visible = false;
                treeView1.Visible = true;
                intSelect = 3;
            }

        }

        #endregion

        #region [ �¼�: ��ְ��ȼ�����_Click�¼� ]

        private void captionPanel5_Click(object sender, EventArgs e)
        {
            if (rtcbll.N_LoadInfo(treeView1, "BusLevel", 0))
            {
                captionPanel1.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel2.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel3.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel4.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel5.SetCaptionPanelStyle = CaptionPanelStyleEnum.Office2007Panel;
                captionPanel6.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;

                buttonCaptionPanel1.CaptionTitle = "���ݲ�ͬ��ְ��ȼ���Ա���¾���Ϣ���л���:";
                dgv_WorkType.Visible = false;
                treeView1.Visible = true;
                intSelect = 5;
            }
        }

        #endregion

        #region [ �¼�: �������Ի���_Click�¼� ]

        private void captionPanel4_Click(object sender, EventArgs e)
        {
            if (rtcbll.N_LoadInfo(treeView1, "Directional", 0))
            {
                captionPanel1.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel2.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel3.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel4.SetCaptionPanelStyle = CaptionPanelStyleEnum.Office2007Panel;
                captionPanel5.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel6.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;

                buttonCaptionPanel1.CaptionTitle = "���ݲ�ͬ�ķ����Զ�Ա���¾���Ϣ���л���:";

                intSelect = 4;
                treeView1.ExpandAll();
            }
            
        }

        #endregion

        #region [ �¼������������_Click�¼�]

        private void captionPanel6_Click(object sender, EventArgs e)
        {
            if (rtcbll.N_LoadInfo(treeView1, "Territorial", 0))
            {
                captionPanel1.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel2.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel3.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel4.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel5.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                captionPanel6.SetCaptionPanelStyle = CaptionPanelStyleEnum.Office2007Panel;

                buttonCaptionPanel1.CaptionTitle = "���ݲ�ͬ�������Ա���¾���Ϣ���л���:";

                intSelect = 6;
                treeView1.ExpandAll();
            }
        }

        #endregion

        #region [ �¼�: ��ʱ�� ]

        private void timeControl_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                switch (intSelect)
                {
                    case 1:                             //����
                        captionPanel1_Click(sender, e);
                        break;
                    case 2:                             //����
                        captionPanel2_Click(sender, e);
                        break;
                    case 3:                             //ְ��
                        captionPanel3_Click(sender, e);
                        break;
                    case 4:                             //������
                        captionPanel4_Click(sender, e);
                        break;
                    case 5:                             //ְ��ȼ�
                        captionPanel5_Click(sender, e);
                        break;
                    case 6:                             //����
                        captionPanel6_Click(sender, e);
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

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

        
    }
}