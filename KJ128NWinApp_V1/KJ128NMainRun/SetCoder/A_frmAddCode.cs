using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NDataBase;

namespace KJ128NMainRun.SetCoder
{
    public partial class A_frmAddCode : Form
    {
        private A_CodeSenderBLL codebll = new A_CodeSenderBLL();

        private int frmoperator = 0;

        private string CodeSenderAddress = string.Empty;

        private A_frmCodeSender a_FrmCodeSender;

        public A_frmAddCode(A_frmCodeSender a_frmcode)
        {
            InitializeComponent();
            a_FrmCodeSender = a_frmcode;
        }

        public A_frmAddCode(string codesenderaddress, int op, A_frmCodeSender a_frmcode)
        {
            InitializeComponent();
            this.CodeSenderAddress = codesenderaddress;
            this.frmoperator = op;
            a_FrmCodeSender = a_frmcode;
        }

        #region 【事件方法：选择 单添加标示卡 还是批量添加】
        private void chbMulit_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMulit.Checked)
            {
                txtCodeMaxNum.Enabled = true;
            }
            else
            {
                txtCodeMaxNum.Enabled = false;
            }
        }
        #endregion

        #region 【事件方法：重置界面数据】
        private void btnCodeReSet_Click(object sender, EventArgs e)
        {
            txtCodeMinNum.Text = "";
            txtCodeMaxNum.Text = "";
            rbtZC.Checked = true;
            rbtLost.Checked = false;
            rbtLowD.Checked = false;
            rbtBad.Checked = false;
            chbMulit.Checked = false;
            txtCodeReMark.Text = "";
        }
        #endregion

        #region 【事件方法：关闭窗体】
        private void btnCodeReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 【事件方法：保存标识卡信息】
        private void btnCodeSave_Click(object sender, EventArgs e)
        {
            if (txtCodeMinNum.Text.Trim().Equals(""))
            {
                labCodeMassage.ForeColor = Color.Red;
                labCodeMassage.Text = "最小值未输入标识卡号";
                labCodeMassage.Visible = true;
                return;
            }
            if (int.Parse(txtCodeMinNum.Text) <= 0)
            {
                labCodeMassage.ForeColor = Color.Red;
                labCodeMassage.Text = "不能输入0号标识卡";
                labCodeMassage.Visible = true;
                return;
            }
            if (frmoperator == 0)
            {
                int state = 0;
                if (rbtZC.Checked)
                    state = 1;
                if (rbtBad.Checked)
                    state = 2;
                if (rbtLost.Checked)
                    state = 3;
                if (rbtLowD.Checked)
                    state = 4;
                if (chbMulit.Checked)
                {
                    try
                    {
                        if (txtCodeMaxNum.Text.Trim().Equals(""))
                        {
                            labCodeMassage.ForeColor = Color.Red;
                            labCodeMassage.Text = "最大值未输入标识卡号";
                            labCodeMassage.Visible = true;
                            return;
                        }
                        int min = int.Parse(txtCodeMinNum.Text);
                        int max = int.Parse(txtCodeMaxNum.Text);
                        if ((max - min) >= 500)
                        {
                            labCodeMassage.ForeColor = Color.Red;
                            labCodeMassage.Text = "标识卡一次最多添加500个...";
                            labCodeMassage.Visible = true;
                            //MessageBox.Show("标识卡一次最多添加100个...", "提示", MessageBoxButtons.OK);
                            return;
                        }
                        if (max <min)
                        {
                            labCodeMassage.ForeColor = Color.Red;
                            labCodeMassage.Text = "最大输入值不能比最小输入值小";
                            labCodeMassage.Visible = true;
                            return;
                        }
                        //int state = 0;
                        bool flag = true;
                        //if (rbtZC.Checked)
                        //    state = 1;
                        //if (rbtBad.Checked)
                        //    state = 2;
                        //if (rbtLost.Checked)
                        //    state = 3;
                        //if (rbtLowD.Checked)
                        //    state = 4;
                        for (int i = min; i <= max; i++)
                        {
                            if (codebll.InsertCodeSender(i, 1, state, 2, txtCodeReMark.Text) <= 0)
                                flag = false;
                        }
                        if (flag)
                        {
                            labCodeMassage.ForeColor = Color.Black;
                            labCodeMassage.Text = "保存成功";
                        }
                        else
                        {
                            labCodeMassage.ForeColor = Color.Black;
                            labCodeMassage.Text = "保存成功";
                        }
                        labCodeMassage.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        labCodeMassage.ForeColor = Color.Red;
                        labCodeMassage.Text = "保存失败";
                        labCodeMassage.Visible = true;
                    }
                }
                else
                {
                    try
                    {
                        if (txtCodeMinNum.Enabled)
                        {
                            int code = int.Parse(txtCodeMinNum.Text);
                            labCodeMassage.Visible = true;
                            if (codebll.InsertCodeSender(code, 1, state, 2, txtCodeReMark.Text) > 0)
                            {
                                labCodeMassage.ForeColor = Color.Black;
                                labCodeMassage.Text = "保存成功";
                            }
                            else
                            {
                                labCodeMassage.ForeColor = Color.Red;
                                labCodeMassage.Text = "该标识卡已存在";
                                return;
                            }
                        }
                        else
                        {
                            int code = int.Parse(txtCodeMinNum.Text);
                            labCodeMassage.Visible = true;
                            if (codebll.UpdateCodeSenderState(code, state) > 0)
                            {
                                labCodeMassage.ForeColor = Color.Black;
                                labCodeMassage.Text = "保存成功";
                            }
                            else
                            {
                                labCodeMassage.ForeColor = Color.Red;
                                labCodeMassage.Text = "保存失败";
                                return;
                            }
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        labCodeMassage.ForeColor = Color.Red;
                        labCodeMassage.Text = "保存失败";
                        labCodeMassage.Visible = true;
                    }
                }
            }
            else
            {
                int state = 0;
                if (rbtZC.Checked)
                    state = 1;
                if (rbtBad.Checked)
                    state = 2;
                if (rbtLost.Checked)
                    state = 3;
                if (rbtLowD.Checked)
                    state = 4;
                if (codebll.UpdateCodeSenderState(CodeSenderAddress, state, txtCodeReMark.Text))
                {
                    labCodeMassage.ForeColor = Color.Black;
                    labCodeMassage.Text = "保存成功";
                    label14.Visible = true;
                    labCodeMassage.Visible = true;
                }
                else
                {
                    labCodeMassage.ForeColor = Color.Red;
                    labCodeMassage.Text = "保存失败";
                    label14.Visible = true;
                    labCodeMassage.Visible = true;
                    return;
                }
            }


            //Czlt-2011-12-10 跟新时间
            codebll.UpdateTime();

            if (!New_DBAcess.IsDouble)          //单机版，直接刷新
            {
                a_FrmCodeSender.BindCode(1);
            }
            else                                //热备版，启用定时器
            {
                a_FrmCodeSender.HostBackRefresh(true);
            }
        }
        #endregion

        #region 【事件方法：窗体加载】
        private void A_frmAddCode_Load(object sender, EventArgs e)
        {
            if (frmoperator == 1)
            {
                DataTable dt = codebll.GetCodeSenderByAddress(this.CodeSenderAddress);
                txtCodeMinNum.Text = CodeSenderAddress;
                if (dt.Rows[0][1].ToString()=="正常")
                {
                    rbtZC.Checked = true;
                    rbtLost.Checked = false;
                    rbtLowD.Checked = false;
                    rbtBad.Checked = false;
                    chbMulit.Checked = false;
                }
                if (dt.Rows[0][1].ToString() == "低电量")
                {
                    rbtZC.Checked = false;
                    rbtLost.Checked = false;
                    rbtLowD.Checked = true;
                    rbtBad.Checked = false;
                    chbMulit.Checked = false;
                }
                if (dt.Rows[0][1].ToString() == "遗失")
                {
                    rbtZC.Checked = false;
                    rbtLost.Checked = true;
                    rbtLowD.Checked = false;
                    rbtBad.Checked = false;
                    chbMulit.Checked = false;
                }
                if (dt.Rows[0][1].ToString() == "损坏")
                {
                    rbtZC.Checked = false;
                    rbtLost.Checked = false;
                    rbtLowD.Checked = false;
                    rbtBad.Checked = true;
                    chbMulit.Checked = false;
                }
                txtCodeReMark.Text = dt.Rows[0][3].ToString();
                chbMulit.Enabled = false;
                txtCodeMinNum.Enabled = false;
            }
        }
        #endregion

        private void txtCodeReMark_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
    }
}
