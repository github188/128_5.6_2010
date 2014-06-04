using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using Shine.Logs;
using Shine.Logs.LogType;
using KJ128NDataBase;

namespace KJ128NMainRun.EmployeeManage
{
    public partial class A_FrmEmpInfo_AddCerInfo : Form
    {

        #region【声明】

        private A_DeptBLL dbll = new A_DeptBLL();

        private DataSet ds;

        private A_FrmEmpInfo frmEmp;
        /// <summary>
        /// 用于保存要修改的证书ID
        /// </summary>
        int tempCer_ID;

        /// <summary>
        /// 是否是修改,true:修改；false:查看
        /// </summary>
        public bool blIsUpdate = false;

        private string strCerName;

        #endregion

        #region【构造函数】

        public A_FrmEmpInfo_AddCerInfo(A_FrmEmpInfo frm)
        {
            InitializeComponent();
            frmEmp = frm;
            tempCer_ID = frm.tempCer_ID;
            blIsUpdate = frm.blIsUpdate;

            lb_CerTipsInfo.Visible = false;

            GetCerInfo_Add();
        }

        #endregion

        #region【方法：验证 证书信息】

        /// <summary>
        /// 验证证书信息
        /// </summary>
        /// <returns></returns>
        private bool CheckingCertificate()
        {
            //验证证书名称不能为空
            if (textBox_CerName.Text.Trim().Equals(""))
            {
                this.SetTipsInfo(lb_CerTipsInfo, false, "请输入证书名称！");
                textBox_CerName.Focus();
                textBox_CerName.SelectAll();
                return false;
            }

            if (tempCer_ID == -1 ||(tempCer_ID!=-1 && !textBox_CerName.Text.Trim().Equals(strCerName)))
            {
                using (DataSet ds = dbll.GetNameCertificateInfoTable(textBox_CerName.Text.Trim()))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count != 0)
                        {
                            this.SetTipsInfo(lb_CerTipsInfo, false, "证书名称已存在,请重新输入证书名称！");
                            textBox_CerName.Focus();
                            textBox_CerName.SelectAll();
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        #endregion

        #region 【方法：添加 证书信息】

        /// <summary>
        /// 添加 证书信息
        /// </summary>
        private bool SaveSetCer()
        {
            int intImpactCounts = 0;

            intImpactCounts = dbll.SaveCertificateData(textBox_CerName.Text.Trim(), textBox_CerVestIn.Text.Trim(), textBox_CertificateRemark.Text.Trim());

            if (intImpactCounts > 0)
            {
                //存入日志
                LogSave.Messages("[A_FrmEmpInfo]", LogIDType.UserLogID, "添加证书信息，证书名称：" + textBox_CerName.Text + "。");
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region【方法：修改 证书信息】

        /// <summary>
        /// 修改 证书信息
        /// </summary>
        private bool UpDateCer()
        {
            int intImpactCounts = 0;

            intImpactCounts = dbll.UpDateCertificate(tempCer_ID, textBox_CerName.Text.Trim(), textBox_CerVestIn.Text.Trim(), textBox_CertificateRemark.Text.Trim());

            if (intImpactCounts > 0)
            {
                strCerName = textBox_CerName.Text.Trim();
                //存入日志
                LogSave.Messages("[A_FrmEmpInfo]", LogIDType.UserLogID, "修改证书信息，证书名称：" + textBox_CerName.Text + "。");
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion

        #region【方法：加载证书信息（新增）】

        private void GetCerInfo_Add()
        {
            lb_CerTipsInfo.Visible = false;

            if (tempCer_ID == -1)          //新增
            {
                this.Text = "新增证书信息";

                bt_Cer_Save.Enabled = bt_Cer_Reset.Enabled = gb_AddCerInfo.Enabled = true;
                label110.Visible =  true;


            }
            else                            
            {
                if (blIsUpdate)         //修改
                {
                    this.Text = "修改证书信息";
                    textBox_CerName.Enabled = false;
                    bt_Cer_Reset.Enabled = false;
                    bt_Cer_Save.Enabled = gb_AddCerInfo.Enabled = true;
                    label110.Visible = true;
                }
                else                    //查看
                {
                    this.Text = "查看证书信息";
                    bt_Cer_Reset.Enabled = false;
                    bt_Cer_Save.Enabled = gb_AddCerInfo.Enabled = false;
                    label110.Visible = lb_CerTipsInfo.Visible = false;
                }
                BindingCer(tempCer_ID);             //绑定修改的职务信息
            }
        }

        #endregion

        #region【方法：绑定修改的证书信息】

        private void BindingCer(int intCerTypeID)
        {
            using (ds = dbll.GetCertificateInfo(intCerTypeID))
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        textBox_CerName.Text = dt.Rows[0][1].ToString();
                        strCerName = dt.Rows[0][1].ToString();

                        textBox_CerVestIn.Text = dt.Rows[0][2].ToString();
                        textBox_CertificateRemark.Text = dt.Rows[0][4].ToString();
                    }
                }
            }


        }

        #endregion

        #region【方法：清空 证书信息】

        /// <summary>
        /// 清空 证书信息
        /// </summary>
        void ClearCertificate()
        {
            textBox_CerName.Text = "";
            textBox_CerVestIn.Text = "";
            textBox_CertificateRemark.Text = "";
        }
        #endregion

        #region 【方法：设置提示信息】


        private void SetTipsInfo(Label lb, bool blIsSuccess, string strInfo)
        {
            lb.Text = strInfo;
            lb.Visible = true;
            if (blIsSuccess)
            {
                lb.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                lb.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion


        #region【事件：保存】

        private void bt_Cer_Save_Click(object sender, EventArgs e)
        {
            if (CheckingCertificate())          //验证证书信息
            {
                if (tempCer_ID == -1)           //添加
                {
                    if (SaveSetCer())
                    {
                        SetTipsInfo(lb_CerTipsInfo, true, "保存成功！");


                        //Czlt-2011-12-10 跟新时间
                        dbll.UpdateTime();

                        if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                        {
                            frmEmp.Refresh_Cer();
                        }
                        else                                //热备版，启用定时器
                        {
                            frmEmp.HostBackRefresh(true);
                        }
                    }
                    else
                    {
                        SetTipsInfo(lb_CerTipsInfo, false, "保存失败！");
                    }
                }
                else                           //修改
                {
                    if (UpDateCer())
                    {
                        SetTipsInfo(lb_CerTipsInfo, true, "修改成功！");

                        //Czlt-2011-12-10 跟新时间
                        dbll.UpdateTime();

                        if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                        {
                            frmEmp.Refresh_Cer();
                        }
                        else                                //热备版，启用定时器
                        {
                            frmEmp.HostBackRefresh(true);
                        }
                    }
                    else
                    {
                        SetTipsInfo(lb_CerTipsInfo, false, "修改失败！");
                    }
                }
            }
        }

        #endregion

        #region【事件：重置】

        private void bt_Cer_Reset_Click(object sender, EventArgs e)
        {
            ClearCertificate();
        }

        #endregion

        #region【事件：返回】

        private void bt_Cer_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void textBox_CerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_CerVestIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_CertificateRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

    }
}
