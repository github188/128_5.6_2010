using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJ128NMainRun.EquManage
{
    public partial class A_frmAddFactory : Form
    {
        private KJ128NDBTable.A_EquBLL bll = new KJ128NDBTable.A_EquBLL();
        private string FactoryNo = string.Empty;
        private int frmoperator = 0;

        private A_frmEquManager frmeqm;

        private string strFactoryNO = "";

        private string strFactoryID = "-1";

        #region【构造函数——新增】

        public A_frmAddFactory(A_frmEquManager frm)
        {
            InitializeComponent();

            frmeqm = frm;
        }

        #endregion

        #region【构造函数——修改】

        public A_frmAddFactory(string fno,int frmoperator,A_frmEquManager frm)
        {
            InitializeComponent();
            this.FactoryNo = fno;
            this.frmoperator = frmoperator;
            frmeqm = frm;
            strFactoryID = frm.strUpDateFactoryID;
        }

        #endregion

        #region【窗体加载】

        private void A_frmAddFactory_Load(object sender, EventArgs e)
        {
            if (frmoperator == 1 || frmoperator == -1 )
            {
                DataTable dt = bll.GetFactoryByFno(FactoryNo);
                txtFNo.Text = dt.Rows[0][1].ToString();
                txtFaddress.Text = dt.Rows[0][3].ToString();
                txtFemp.Text = dt.Rows[0][6].ToString();
                txtFemptel.Text = dt.Rows[0][7].ToString();
                txtFfex.Text = dt.Rows[0][4].ToString();
                txtFName.Text = dt.Rows[0][2].ToString();
                txtFremark.Text = dt.Rows[0][8].ToString();
                txtFtel.Text = dt.Rows[0][5].ToString();
                
                strFactoryNO = txtFNo.Text.Trim();
                txtFNo.Enabled = false;
                this.Text = "修改设备生产厂家";
            }
            if (frmoperator == -1)
            {
                this.Text = "查看设备生产厂家";
                txtFNo.Enabled = false;
                gb_AddFactory.Enabled = btnSave.Enabled = btnReset.Enabled = false;
                labTT.Visible = false;
                gb_AddFactory.Enabled = false;
            }
        }

        #endregion

        #region【事件：重置】

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (frmoperator == 0)
            {
                txtFNo.Text = "";
            }
            txtFaddress.Text = "";
            txtFemp.Text = "";
            txtFemptel.Text = "";
            txtFfex.Text = "";
            txtFName.Text = "";
            txtFremark.Text = "";
            txtFtel.Text = "";
        }

        #endregion

        #region【事件：保存】

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFNo.Text.Trim() == "")
            {
                SetTipsInfo(false, "编号不能为空！");
                txtFNo.Focus();
                txtFNo.SelectAll();
                return;
            }
            if (txtFName.Text.Trim() == "")
            {
                SetTipsInfo(false, "名称不能为空！");
                txtFName.Focus();
                txtFName.SelectAll();
                return;
            }
            //验证设备编号是否相同
            if (frmoperator == 0 || (frmoperator != 0 && !txtFNo.Text.Trim().Equals(strFactoryNO)))
            {
                if (bll.isExitsFactory(txtFNo.Text))
                {
                    SetTipsInfo(false, "编号已存在，请重新输入！");
                    txtFNo.Focus();
                    txtFNo.SelectAll();
                    return;
                }
            }

            if (frmoperator == 0)
            {
                if (bll.InsertFactory(txtFNo.Text, txtFName.Text, txtFaddress.Text, txtFfex.Text, txtFtel.Text, txtFemp.Text, txtFemptel.Text, txtFremark.Text))
                {
                    SetTipsInfo(true, "保存成功！");


                    //Czlt-2011-12-10 跟新时间
                    bll.UpdateTime();
                    frmeqm.Flash();
                }
                else
                {
                    SetTipsInfo(false, "保存失败！");
                }
            }
            else
            {
                if (bll.UpdateFactory(txtFNo.Text, txtFName.Text, txtFaddress.Text, txtFfex.Text, txtFtel.Text, txtFemp.Text, txtFemptel.Text, txtFremark.Text,strFactoryID))
                {
                    strFactoryNO = txtFNo.Text.Trim();
                    SetTipsInfo(true, "保存成功！");

                    //Czlt-2011-12-10 跟新时间
                    bll.UpdateTime();
                    frmeqm.Flash();
                }
                else
                {
                    SetTipsInfo(false, "保存失败！");
                }
            }
        }

        #endregion

        #region【事件：返回】

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        string model = "0123456789-" + ((char)Keys.Back).ToString();

        private void txtFfex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (model.Contains(e.KeyChar.ToString()))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtFemptel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (model.Contains(e.KeyChar.ToString()))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtFtel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (model.Contains(e.KeyChar.ToString()))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        #region 【方法：设置提示信息】

        private void SetTipsInfo( bool blIsSuccess, string strInfo)
        {
            labMessage.Text = strInfo;
            labMessage.Visible = true;
            if (blIsSuccess)
            {
                labMessage.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                labMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion

        private void txtFNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtFName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtFtel_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtFfex_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtFemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtFemptel_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtFaddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtFremark_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

    }
}
