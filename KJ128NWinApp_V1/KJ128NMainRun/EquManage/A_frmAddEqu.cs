using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJ128NMainRun.EquManage
{
    public partial class A_frmAddEqu : Form
    {

        #region【声明】

        private KJ128NDBTable.A_EquBLL bll = new KJ128NDBTable.A_EquBLL();
        private string EquNo = string.Empty;
        private int Frmoperator = 0;

        private A_frmEquManager frmeqm;

        private string strEquID = "-1";
        private string strEquNO = "";
        #endregion

        #region【构造函数——新增】

        public A_frmAddEqu(A_frmEquManager frm)
        {
            InitializeComponent();
            frmeqm = frm;
        }

        #endregion

        #region【构造函数——修改、查看】

        public A_frmAddEqu(string equno,int frmoperator,A_frmEquManager frm)
        {
            InitializeComponent();
            this.EquNo = equno;
            this.Frmoperator = frmoperator;
            frmeqm = frm;
            strEquID = frm.strUpDateEquID;
        }

        #endregion

        #region【窗体加载】

        private void A_frmAddEqu_Load(object sender, EventArgs e)
        {
            LoadInfo();
            if (Frmoperator == 1 || Frmoperator==-1)
            {
                LoadEquInfo(EquNo);
            }

            if (Frmoperator == 1)       //修改
            {
                this.Text = "修改设备";
                btnReset.Enabled = false;
                txtEquNo.Enabled = false;
            }
            else if(Frmoperator==-1)    //查看
            {
                this.Text = "查看设备";
                btnSave.Enabled = btnReset.Enabled = false;
                gb_Equ.Enabled = false;
                labTT.Visible = false;
                txtEquNo.Enabled = false;
            }

        }

        #endregion

        #region【方法：绑定数据】

        private void LoadInfo()
        {
            try
            {
                DataTable dt = bll.GetDepts();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbEquDept.AddItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString());
                }
                dt = bll.GetEquTypes();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbEqutype.AddItem(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
                }
                dt = bll.GetEquStates();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbEqustate.AddItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString());
                }
                dt = bll.GetEquFactorys();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbEqufactory.AddItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString());
                }
                cmbEquDept.SelectedIndex = 0;
                cmbEqufactory.SelectedIndex = 0;
                cmbEqustate.SelectedIndex = 0;
                cmbEqutype.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("部门或者生产厂尚未配置,请配置后在做此操作...", "提示", MessageBoxButtons.OK);
                btnSave.Enabled = false;
            }
        }

        private void LoadEquInfo(string equno)
        {
            txtEquNo.Text = equno;
            strEquNO = txtEquNo.Text.Trim();
            DataTable dt = bll.GetEquInfoByEquNO(equno);
            txtEquName.Text = dt.Rows[0][1].ToString();
            cmbEqutype.SelectedIndex = cmbEqutype.Items.IndexOf(dt.Rows[0][2].ToString());
            cmbEqustate.SelectedIndex = cmbEqustate.Items.IndexOf(dt.Rows[0][3].ToString());
            cmbEquDept.SelectedIndex = cmbEquDept.Items.IndexOf(dt.Rows[0][4].ToString());
            cmbEqufactory.SelectedIndex = cmbEqufactory.Items.IndexOf(dt.Rows[0][5].ToString());
            txtEquRemark.Text = dt.Rows[0][6].ToString();
            dt = bll.GetEquDetailInfobyEquNO(equno);
            if (dt.Rows.Count > 0)
            {
                txtModelSpecial.Text = dt.Rows[0][2].ToString();
                txtDutyEmployee.Text = dt.Rows[0][3].ToString();
                txtEquHeight.Text=dt.Rows[0][6].ToString();
                txtEquKw.Text = dt.Rows[0][7].ToString();
                txtUserange.Text = dt.Rows[0][4].ToString();
                try
                {
                    dtpProductDate.Value = DateTime.Parse(dt.Rows[0][5].ToString());
                    dtpProductDate.Enabled = true;
                    checkBox1.Checked = true;
                }
                catch (Exception ex)
                {
                    dtpProductDate.Enabled = false;
                    dtpProductDate.Value = DateTime.Now;
                    checkBox1.Checked = false;
                }
                try
                {
                    dtpUseDate.Value = DateTime.Parse(dt.Rows[0][8].ToString());
                    dtpUseDate.Enabled = true;
                    checkBox2.Checked = true;
                }
                catch (Exception ex)
                {
                    dtpUseDate.Enabled = false;
                    dtpUseDate.Value = DateTime.Now;
                    checkBox2.Checked = false;
                }
            }
        }

        #endregion

        #region【事件：是否启用生产日期】

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dtpProductDate.Enabled = checkBox1.Checked;
        }

        #endregion

        #region【事件：是否启用使用年限】

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            dtpUseDate.Enabled = checkBox2.Checked;
        }

        #endregion

        #region【事件：保存】

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEquNo.Text.Trim() == "")
            {
                SetTipsInfo(false, "设备编号不能为空!");
                txtEquNo.Focus();
                txtEquNo.SelectAll();
                return;
            }
            if (txtEquName.Text.Trim() == "")
            {
                SetTipsInfo(false, "设备名称不能为空!");
                txtEquName.Focus();
                txtEquName.SelectAll();
                return;
            }
            //判断设备编号是否重复
            if (Frmoperator == 0 || (Frmoperator == 1 && !txtEquNo.Text.Trim().Equals(strEquNO)))
            {
                if (bll.IsExitsEquNo(txtEquNo.Text))
                {
                    SetTipsInfo(false, "编号已存在!");
                    txtEquNo.Focus();
                    txtEquNo.SelectAll();
                    return;
                }
            }

            if (Frmoperator == 0)                   //新增
            {
                int deptid = int.Parse(cmbEquDept.SelectedValue);
                int equtype = int.Parse(cmbEqutype.SelectedValue);
                int equstate = int.Parse(cmbEqustate.SelectedValue);
                int factoryid = int.Parse(cmbEqufactory.SelectedValue);
                string DeptName = cmbEquDept.Text;
                if (bll.InsertEquBaseInfo(txtEquNo.Text, txtEquName.Text, deptid,DeptName, equtype, equstate, factoryid, txtEquRemark.Text))
                {
                    string modelspecial = txtModelSpecial.Text;
                    string dutyemployee = txtDutyEmployee.Text;
                    string userange = txtUserange.Text;
                    string prodate = "null";
                    string usedate = "null";
                    if (checkBox1.Checked)
                        prodate = "'" + dtpProductDate.Value.ToString("yyyy-MM-dd") + "'";
                    if (checkBox2.Checked)
                        usedate = "'" + dtpUseDate.Value.ToString("yyyy-MM-dd") + "'";
                    string height = "null";
                    string kw = "null";
                    if (txtEquHeight.Text != "")
                        height = txtEquHeight.Text;
                    if (txtEquKw.Text != "")
                        kw = txtEquKw.Text;
                    bll.InsertEquDetailInfo(txtEquNo.Text, modelspecial, dutyemployee, userange, prodate, height, kw, usedate);
                    SetTipsInfo(true, "保存成功!");


                    //Czlt-2011-12-10 跟新时间
                    bll.UpdateTime();

                    frmeqm.Flash();
                }
                else
                {
                    SetTipsInfo(false, "保存失败!");
                }
            }
            if (Frmoperator == 1)                   //修改
            {
                int deptid = int.Parse(cmbEquDept.SelectedValue);
                int equtype = int.Parse(cmbEqutype.SelectedValue);
                int equstate = int.Parse(cmbEqustate.SelectedValue);
                int factoryid = int.Parse(cmbEqufactory.SelectedValue);
                string DeptName = cmbEquDept.Text;
                if (bll.UpdateEquBaseInfo(txtEquNo.Text, txtEquName.Text, deptid,DeptName, equtype, equstate, factoryid, txtEquRemark.Text,strEquID))
                {
                    bll.UpdateEquDetailInfo(strEquID, txtModelSpecial.Text, txtDutyEmployee.Text, txtUserange.Text, dtpProductDate.Value, txtEquHeight.Text, txtEquKw.Text, dtpUseDate.Value);
                    strEquNO = txtEquNo.Text.Trim();
                    SetTipsInfo(true, "保存成功!");


                    //Czlt-2011-12-10 跟新时间
                    bll.UpdateTime();

                    frmeqm.Flash();
                }
                else
                {
                    SetTipsInfo(false, "保存失败!");
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

        #region【事件：重置】

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (Frmoperator == 0)
            {
                txtEquNo.Text = "";                
            }
            txtDutyEmployee.Text = "";
            txtEquHeight.Text = "";
            txtEquKw.Text = "";
            txtEquName.Text = "";
            txtEquRemark.Text = "";
            txtModelSpecial.Text = "";
            txtUserange.Text = "";
            checkBox1.Checked = checkBox2.Checked = false;
        }

        #endregion



        #region 【方法：设置提示信息】

        private void SetTipsInfo(bool blIsSuccess, string strInfo)
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

        private void txtEquNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtEquName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtModelSpecial_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtDutyEmployee_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtUserange_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtEquRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
    }
}
