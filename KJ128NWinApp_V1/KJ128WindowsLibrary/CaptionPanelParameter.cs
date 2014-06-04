using System;
using System.Drawing;
namespace KJ128WindowsLibrary
{
     class CaptionPanelParameter
    {
        public Color CaptionForeColor = Color.FromArgb(21, 47, 147);//������ɫ
        public Color CaptionBackColor1 = Color.FromArgb(184, 207, 233);//����ɫ1
        public Color CaptionBackColor2 = Color.FromArgb(184, 207, 233);//����ɫ2
        public bool IsCaptionSingleColor = true; //�����Ƿ����ý���
        public Color BorderLineColor = Color.FromArgb(118, 153, 199);//�߿���������ɫ
        public int BorderLineWidth = 1;//�߿��߿�
        public int BorderLineLeft = 0;//�߿��ߵ���߽�
        public int BorderLineTop = 0;//�߿��ߵĶ�
        public int CaptionHeight = 20;//����ĸ߶�
        public Font CaptionFont = //����
            new System.Drawing.Font("����", 10, System.Drawing.FontStyle.Bold, 
               System.Drawing.GraphicsUnit.Point, (byte)(134));
        public int CaptionLeft = 1;//�������߽�
        public int CaptionTop = 1;//����Ķ�
        public Color CaptionBackColor = Color.FromArgb(184, 207, 233);//���õ�ɫ�ĵ�ɫ
        public string CaptionTitle = "Title";//����
        public int CaptionTitleLeft = 8;//��������߽�
        public int CaptionTitleTop = 4;//������ ��
        public Color PanelBackColor = Color.FromArgb(213,228,242);//Ĭ��panel����
        public bool IsBorderLine = true;//�Ƿ��б߿���
        public bool IsUserBackColor = false; //�Ƿ�ʹ��Panel����
        public bool IsUserCaptionBottomLine = false;//�Ƿ����ñ������
        public Color CaptionBottomLineColor = Color.FromArgb(197, 197, 197);//���������ɫ
        public int CaptionBottomLineWidth = 1; //������ߵ��߿�

        //�رհ�ť
        public bool IsUserButtonClose = false;//ʹ�ùرհ�ť
        public string CaptionCloseButtonTitle = "��";//�رհ�ť���ı���
        public Font CaptionCloseButtonFont = new System.Drawing.Font
             ("����", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));//����
                
        public Color CaptionCloseButtonForeColor = Color.FromArgb(192, 192, 192);//�رհ�ť��������ɫ

        public Color CaptionCloseButtonEnterBorderColor = Color.FromArgb(255,189,105); //�رհ�ť��Ϊ��ؼ�ʱ�߿���ɫ

        public Color CaptionCloseButtonEnterBackColor = Color.FromArgb(255,231,162);//�رհ�ť��Ϊ��ؼ�ʱ����ɫ

        public int CaptionCloseButtonEnterBorderWidth = 1;//�߿��߿�

        public int CaptionCloseButtonEnterIntervalRight = 3; //�رհ�ť�����ұ߽�ľ���

        public int CaptionCloseButtonWidth = 21;//�رհ�ť�Ŀ��

        public int CaptionCloseButtonBorderLeft = 0;//�߿�����

        public int CaptionCloseButtonBorderTop = 0;//�߿��߶�

        public int CaptionCloseButtonBorderHeight = 18;//�߿��߸�

        public int CaptionCloseButtonTitleLeft = 1;

         public int CaptionCloseButtonControlLeft = 2;
        

        //panelǰ���ͼ��
        public bool IsPanelImage = false;
        
        public int PanelImageLeft = 1;//iamge����߽�
        public int PanelImageTop = 1;//image�Ķ�

        public int CaptionTitleLeftForPanelImage = 1;
         //����
         public Color FormBackColorOffice2003 = Color.FromArgb(195,218,249);  //Color(243,242,231)

         public Color FormBackColorOffice2007 = Color.FromArgb(213,228,242);

         


    }
}