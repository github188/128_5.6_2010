using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128WindowsLibrary;

namespace KJ128NMainRun
{
    public partial class FrmEmpInfo : Form
    {

        #region [ 声明 ]

        private string strID;
        private EmpInfoBLL eibll = new EmpInfoBLL();
        private DataTable dt;
        //拖动
        private bool isMove = false;            // (设置面板) 是否移动
        private int mleft = 0;
        private int mtop = 0;

        private bool blIsEmp;
        #endregion

        #region [ 构造函数 ]

        public FrmEmpInfo(string strID, bool blIsEmp)
        {
            InitializeComponent();
            this.blIsEmp = blIsEmp;
            this.strID = strID;
        }

        #endregion

        #region [ 事件: 窗体加载 ]

        private void FrmEmpInfo_Load(object sender, EventArgs e)
        {
            GetEmpInfo();
        }

        #endregion

        #region [ 方法: 获取员工信息 ]

        private void GetEmpInfo()
        {
            using (dt=new DataTable())
            {
                dt = eibll.GetEmpInfo(strID,blIsEmp);
                if (dt.Rows.Count > 0)
                {
                    label_CodeSender.Text = dt.Rows[0][0].ToString();
                    label_Name.Text = dt.Rows[0][1].ToString();
                    label_CardID.Text = dt.Rows[0][2].ToString();
                    label_BirthDay.Text = dt.Rows[0][3].ToString();
                    label_DutyName.Text = dt.Rows[0][4].ToString();
                    label_WorkTypeName.Text = dt.Rows[0][5].ToString();
                    label_ClassGroup.Text = dt.Rows[0][6].ToString();
                    label_WorkPlace.Text = dt.Rows[0][7].ToString();
                }

            }
        }

        #endregion

        #region [ 事件: 关闭 ]

        private void buttonCaptionPanel1_CloseButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 拖动
        //private void buttonCaptionPanel1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    isMove = true;
        //    Form p = (Form)((CaptionPanel)sender).Parent;
        //    mleft = e.Location.X;
        //    mtop = e.Location.Y;
        //}
        //private void buttonCaptionPanel1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (isMove)
        //    {
        //        Form frm = (Form)((CaptionPanel)sender).Parent;
        //        frm.Location = new Point(frm.Left + e.Location.X - mleft, frm.Top + e.Location.Y - mtop);
        //    }
        //}
        //private void buttonCaptionPanel1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    isMove = false;
        //}
        #endregion

        #region [拖拽]

        /// <summary>
        /// 是否启用拖拽
        /// </summary>
        private bool moveAble = false;
        /// <summary>
        /// 左边距离
        /// </summary>
        private int left = 0;
        /// <summary>
        /// 上边距离 
        /// </summary>
        private int top = 0;

        /// <summary>
        /// 移动的方法
        /// </summary>
        /// <param name="obj">移动的对象</param>
        /// <param name="leftSize">左边距离</param>
        /// <param name="topSize">上边距离</param>
        private void ToMove(Form obj, int leftSize, int topSize)
        {

            obj.Left += (Cursor.Position.X - leftSize);
            obj.Top += (Cursor.Position.Y - topSize);


            this.Cursor = Cursors.SizeAll;
            left = Cursor.Position.X;
            top = Cursor.Position.Y;

        }

        private void FrmEmpInfo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 20)
            {
                moveAble = true;
            }

            left = Cursor.Position.X;
            top = Cursor.Position.Y;
        }

        private void FrmEmpInfo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Y < 25)
            {
                this.Cursor = Cursors.SizeAll;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }

            if (moveAble)
            {
                ToMove(this, left, top);
            }
        }

        private void FrmEmpInfo_MouseUp(object sender, MouseEventArgs e)
        {
            moveAble = false;
            this.Cursor = Cursors.Default;
        }

        #endregion

        #region 退出

        private void pbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 鼠标经过效果

        private void pbClose_MouseMove(object sender, MouseEventArgs e)
        {
            pbExit.Image = global::KJ128NMainRun.Properties.Resources._6;
        }

        private void pbClose_MouseLeave(object sender, EventArgs e)
        {
            pbExit.Image = global::KJ128NMainRun.Properties.Resources._09;
        }

        #endregion

        
        
    }
}