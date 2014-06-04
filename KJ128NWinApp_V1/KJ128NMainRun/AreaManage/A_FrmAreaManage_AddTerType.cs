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

namespace KJ128NMainRun.AreaManage
{
    public partial class A_FrmAreaManage_AddTerType : Form
    {

        #region【声明】

        private A_AreaBLL areaBll = new A_AreaBLL();

        private int tempTerritorialTypeID = -1;

        private A_FrmAreaManage frmAm;

        public bool blIsUpDate = false;

        private DataSet ds;

        private string strTerTypeName = "";

        #endregion

        #region【构造函数】

        public A_FrmAreaManage_AddTerType(A_FrmAreaManage frm)
        {
            InitializeComponent();
            frmAm = frm;
            tempTerritorialTypeID = frm.tempTerritorialTypeID;
            blIsUpDate = frm.blIsUpDate;
            GetTerType_Add();
        }

        #endregion



        #region【方法：验证 区域类型】

        /// <summary>
        /// 验证区域类型
        /// </summary>
        /// <returns></returns>
        private bool CheckingTerType()
        {
            //验证区域类型名称不能为空
            if (textBox_TerTypeName.Text.Trim().Equals(""))
            {
                this.SetTipsInfo(lb_TerTypeTipsInfo, false, "请输入区域类型名称！");
                textBox_TerTypeName.Focus();
                textBox_TerTypeName.SelectAll();
                return false;
            }
            if (tempTerritorialTypeID == -1 ||(tempTerritorialTypeID!=-1 && !textBox_TerTypeName.Text.Trim().Equals(strTerTypeName)))
            {
                //验证区域类型不能重复
                using (ds = areaBll.GetKJ128NTerTypeTable(textBox_TerTypeName.Text.Trim()))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            SetTipsInfo(lb_TerTypeTipsInfo, false, "区域类型名称已存在,请重新输入区域类型名称!");
                            textBox_TerTypeName.Focus();
                            textBox_TerTypeName.SelectAll();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        #endregion

        #region 【方法：添加 区域类型】

        /// <summary>
        /// 添加 区域类型
        /// </summary>
        private bool SaveSetTerType()
        {
            int intImpactCounts = 0;

            intImpactCounts = areaBll.SaveTerType(textBox_TerTypeName.Text.Trim(), 1, textBox_TerTypeRemark.Text.Trim());

            if (intImpactCounts > 0)
            {
                //存入日志
                LogSave.Messages("[A_FrmAreaManage]", LogIDType.UserLogID, "添加区域配置，区域配置名称：" + textBox_TerTypeName.Text + "。");
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region【方法：修改 区域类型】

        /// <summary>
        /// 修改 区域类型
        /// </summary>
        private bool UpDateTerType()
        {
            int intImpactCounts = 0;

            intImpactCounts = areaBll.UpDateTerType(tempTerritorialTypeID, textBox_TerTypeName.Text, 1, textBox_TerTypeRemark.Text);

            if (intImpactCounts > 0)
            {
                strTerTypeName = textBox_TerTypeName.Text.Trim();
                //存入日志
                LogSave.Messages("[A_FrmAreaManage]", LogIDType.UserLogID, "修改区域配置，区域配置名称：" + textBox_TerTypeName.Text + "。");
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion

        #region【方法：加载添加区域类型信息（新增）】

        /// <summary>
        /// 加载添加区域类型信息（新增）
        /// </summary>
        private void GetTerType_Add()
        {
            lb_TerTypeTipsInfo.Visible = false;

            if (tempTerritorialTypeID == -1)    //新增
            {
                this.Text = "新增区域类型";
                textBox_TerTypeName.Enabled = true;
                gb_AddTerTypeInfo.Enabled = bt_TerType_Save.Enabled = bt_TerType_Reset.Enabled = true;
                lb_TerTypeTipsInfo2.Visible =  true;
                Empty_TerType();        //清空区域类型
            }
            else
            {
                if (blIsUpDate)         //修改
                {

                    this.Text = "修改区域类型";
                    textBox_TerTypeName.Enabled = false;
                    gb_AddTerTypeInfo.Enabled = bt_TerType_Save.Enabled = true;
                    bt_TerType_Reset.Enabled = false;
                    lb_TerTypeTipsInfo2.Visible  = true;


                }
                else                            //查看
                {
                    this.Text = "查看区域类型";
                    gb_AddTerTypeInfo.Enabled = bt_TerType_Save.Enabled = false;
                    bt_TerType_Reset.Enabled = false;
                    lb_TerTypeTipsInfo2.Visible = false;
                }
                BindingTerType(tempTerritorialTypeID);
            }
        }

        #endregion

        #region【方法：绑定修改的区域类型】

        private void BindingTerType(int intID)
        {
            using (ds = areaBll.GetTerType_Binding(intID))
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        textBox_TerTypeName.Text = dt.Rows[0][1].ToString();
                        strTerTypeName = dt.Rows[0][1].ToString();
                        textBox_TerTypeRemark.Text = dt.Rows[0][3].ToString();
                        //if (strTerTypeName != "重点区域" && strTerTypeName != "限制区域" && strTerTypeName != "地域")
                        //{
                        //    textBox_TerTypeName.Enabled = true;
                        //}
                    }
                }
                else
                {
                    textBox_TerTypeName.Text = "";
                    textBox_TerTypeRemark.Text = "";
                }
            }
        }

        #endregion

        #region【方法：清空——区域类型】

        private void Empty_TerType()
        {
            textBox_TerTypeName.Text = textBox_TerTypeRemark.Text = "";
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

        private void bt_TerType_Save_Click(object sender, EventArgs e)
        {
            if (CheckingTerType())
            {
                if (tempTerritorialTypeID == -1)            //新增
                {
                    if (SaveSetTerType())
                    {
                        SetTipsInfo(lb_TerTypeTipsInfo, true, "保存成功！");
                        //Czlt-2011-12-10 跟新时间
                        areaBll.UpdateTime();


                        if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                        {
                            frmAm.Refresh_TerType();
                        }
                        else                                //热备版，启用定时器
                        {
                            frmAm.HostBackRefresh(true);
                        }
                    }
                    else
                    {
                        SetTipsInfo(lb_TerTypeTipsInfo, false, "保存失败！");
                    }
                }
                else                                        //修改
                {
                    if (UpDateTerType())
                    {
                        SetTipsInfo(lb_TerTypeTipsInfo, true, "修改成功！");

                        //Czlt-2011-12-10 跟新时间
                        areaBll.UpdateTime();


                        if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                        {
                            frmAm.Refresh_TerType();
                        }
                        else                                //热备版，启用定时器
                        {
                            frmAm.HostBackRefresh(true);
                        }
                    }
                    else
                    {
                        SetTipsInfo(lb_TerTypeTipsInfo, false, "修改失败！");
                    }
                }

            }
        }

        #endregion

        #region【事件：重置】

        private void bt_TerType_Reset_Click(object sender, EventArgs e)
        {
            Empty_TerType();
        }

        #endregion

        #region【事件：返回】

        private void bt_TerType_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void textBox_TerTypeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_TerTypeRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }


    }
}
