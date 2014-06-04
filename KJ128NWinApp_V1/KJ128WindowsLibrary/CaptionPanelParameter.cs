using System;
using System.Drawing;
namespace KJ128WindowsLibrary
{
     class CaptionPanelParameter
    {
        public Color CaptionForeColor = Color.FromArgb(21, 47, 147);//标题颜色
        public Color CaptionBackColor1 = Color.FromArgb(184, 207, 233);//渐变色1
        public Color CaptionBackColor2 = Color.FromArgb(184, 207, 233);//渐变色2
        public bool IsCaptionSingleColor = true; //标题是否不启用渐变
        public Color BorderLineColor = Color.FromArgb(118, 153, 199);//边框线条的颜色
        public int BorderLineWidth = 1;//边框线宽
        public int BorderLineLeft = 0;//边框线的左边界
        public int BorderLineTop = 0;//边框线的顶
        public int CaptionHeight = 20;//标题的高度
        public Font CaptionFont = //字体
            new System.Drawing.Font("宋体", 10, System.Drawing.FontStyle.Bold, 
               System.Drawing.GraphicsUnit.Point, (byte)(134));
        public int CaptionLeft = 1;//标题的左边界
        public int CaptionTop = 1;//标题的顶
        public Color CaptionBackColor = Color.FromArgb(184, 207, 233);//启用单色的底色
        public string CaptionTitle = "Title";//标题
        public int CaptionTitleLeft = 8;//标题字左边界
        public int CaptionTitleTop = 4;//标题字 顶
        public Color PanelBackColor = Color.FromArgb(213,228,242);//默认panel背景
        public bool IsBorderLine = true;//是否有边框线
        public bool IsUserBackColor = false; //是否使用Panel背景
        public bool IsUserCaptionBottomLine = false;//是否启用标题底线
        public Color CaptionBottomLineColor = Color.FromArgb(197, 197, 197);//标题底线颜色
        public int CaptionBottomLineWidth = 1; //标题底线的线宽

        //关闭按钮
        public bool IsUserButtonClose = false;//使用关闭按钮
        public string CaptionCloseButtonTitle = "×";//关闭按钮的文本×
        public Font CaptionCloseButtonFont = new System.Drawing.Font
             ("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));//字体
                
        public Color CaptionCloseButtonForeColor = Color.FromArgb(192, 192, 192);//关闭按钮的字休颜色

        public Color CaptionCloseButtonEnterBorderColor = Color.FromArgb(255,189,105); //关闭按钮成为活动控件时边框颜色

        public Color CaptionCloseButtonEnterBackColor = Color.FromArgb(255,231,162);//关闭按钮成为活动控件时背景色

        public int CaptionCloseButtonEnterBorderWidth = 1;//边框线宽

        public int CaptionCloseButtonEnterIntervalRight = 3; //关闭按钮距离右边界的距离

        public int CaptionCloseButtonWidth = 21;//关闭按钮的宽度

        public int CaptionCloseButtonBorderLeft = 0;//边框线左

        public int CaptionCloseButtonBorderTop = 0;//边框线顶

        public int CaptionCloseButtonBorderHeight = 18;//边框线高

        public int CaptionCloseButtonTitleLeft = 1;

         public int CaptionCloseButtonControlLeft = 2;
        

        //panel前面的图像
        public bool IsPanelImage = false;
        
        public int PanelImageLeft = 1;//iamge的左边界
        public int PanelImageTop = 1;//image的顶

        public int CaptionTitleLeftForPanelImage = 1;
         //背景
         public Color FormBackColorOffice2003 = Color.FromArgb(195,218,249);  //Color(243,242,231)

         public Color FormBackColorOffice2007 = Color.FromArgb(213,228,242);

         


    }
}