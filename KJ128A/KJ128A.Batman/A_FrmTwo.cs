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
using KJ128A.Ports;
using System.Xml;
using System.IO;
using KJ128A.Controls;

namespace KJ128A.Batman
{
    public partial class A_FrmTwo : Form
    {
        #region【属性,字段】
        private string strLogPath = Application.StartupPath + "\\KJ128ALog\\";

        GetTwoMessage twobll = new GetTwoMessage();
        // GetCardInfo get = new GetCardInfo();

        /// <summary>
        /// 待呼叫的标识卡数组
        /// </summary>
        private int[] _Cards;
        /// <summary>
        /// 双向通讯广播分站命令
        /// </summary>
        private int[] _Order;


        #region 【方法：获取待呼叫的标识卡数组】
        /// <summary>
        /// 获取待呼叫的标识卡数组
        /// </summary>
        /// <returns></returns>
        public int[] GetCards()
        {
            return _Cards;
        }
        #endregion

        #region 【方法：获取双向通讯广播分站命令】
        /// <summary>
        /// 获取双向通讯广播分站命令
        /// </summary>
        /// <returns></returns>
        public int[] GetOrder()
        {
            return _Order;
        }
        #endregion

        #region【Czlt-2011-08-10 记录传输分站，读卡分站，标识卡的信息】
        /// <summary>
        /// Czlt-2011-08-10 传输分站的编号
        /// </summary>
        private string stationNum;
        /// <summary>
        /// Czlt-2011-08-10 传输分站的编号
        /// </summary>
        public string StationNum
        {
            get { return stationNum; }
            set { stationNum = value; }
        }

        /// <summary>
        /// Czlt-2011-08-10 读卡分站的编号
        /// </summary>
        private string staHeadNum;
        /// <summary>
        ///   /// <summary>
        /// Czlt-2011-08-10 读卡分站的编号
        /// </summary>
        /// </summary>
        public string StaHeadNum
        {
            get { return staHeadNum; }
            set { staHeadNum = value; }
        }

        /// <summary>
        /// Czlt-2011-08-10 标识卡号
        /// </summary>
        private string codeNum;
        /// <summary>
        /// Czlt-2011-08-10 标识卡号
        /// </summary>
        public string CodeNum
        {
            get { return codeNum; }
            set { codeNum = value; }
        }

        /// <summary>
        /// Czlt-2011-08-15 标识卡个数
        /// </summary>
        private string codes;
        public string Codes
        {
            get { return codes; }
            set { codes = value; }
        }

        /// <summary>
        /// Czlt-2011-08-17 呼叫标识卡
        /// </summary>
        private string strCodes;
        /// <summary>
        /// Czlt-2011-08-17 呼叫标识卡
        /// </summary>
        public string StrCodes
        {
            get { return strCodes; }
            set { strCodes = value; }
        }

        /// <summary>
        /// Czlt-2011-08-17 呼叫标识卡和姓名
        /// </summary>
        private string strCodeAndName;
        /// <summary>
        /// Czlt-2011-08-17 呼叫标识卡和姓名
        /// </summary>
        public string StrCodeAndName
        {
            get { return strCodeAndName; }
            set { strCodeAndName = value; }
        }

        /// <summary>
        /// Czlt-2011-08-17 进行全矿井呼叫
        /// </summary>
        private bool isCallAll;

        /// <summary>
        /// Czlt-2011-08-17 进行全矿井呼叫
        /// </summary>
        public bool IsCallAll
        {
            get { return isCallAll; }
            set { isCallAll = value; }
        }

        private bool isClose;
        public bool IsClose
        {
            get { return isClose; }
            set { isClose = value; }
        }

        Dictionary<int, string> czltCalls = new Dictionary<int, string>();
        #endregion

        #endregion

        #region【构造函数】
        public A_FrmTwo()
        {
            InitializeComponent();
            rTxtBox.Text = "";
            numTxtCard.Text = "";
            strCodes = "";

        }
        #endregion

        #region【事件方法】

        /// <summary>
        /// 传输分站值改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSta_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblName.Text = "";
            if (cmbStaHead.DataSource != null && !cmbSta.Text.Trim().Equals(""))
            {
                BindStaHead(Convert.ToInt32(cmbSta.SelectedValue.ToString()));
            }
        }

        /// <summary>
        /// 按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCallCard_Click(object sender, EventArgs e)
        {
           
            try
            {
               

                if (MessageBox.Show("确定呼叫？", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (strCodes.Length > 0)
                    {
                        strCodes = strCodes.Substring(0, strCodes.Length - 1);

                        //Czlt-2011-08-10 给传输分站赋值
                        if (cmbSta.SelectedValue.ToString().Equals("0"))
                        {
                            StationNum = "0";
                        }
                        else
                        {
                            StationNum = cmbSta.SelectedValue.ToString();
                        }

                        //Czlt-2011-08-10 给读卡分站赋值
                        if (cmbStaHead.SelectedValue.ToString().Equals("0"))
                        {
                            StaHeadNum = "0";
                        }
                        else
                        {
                            StaHeadNum = cmbStaHead.SelectedValue.ToString();
                        }

                        //Czlt-2011-08-10 给标识卡赋值
                        CodeNum = strCodes;

                        this.DialogResult = DialogResult.OK;
                        IsCallAll = false;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("请输入要呼叫的标识卡！", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    }                  

                }

              


            }
            catch { }

        }

        /// <summary>
        /// 退出方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            czltCalls.Clear();
            
            IsCallAll = false;
            IsClose = true;
            this.Close();
        }

        /// <summary>
        /// 标识卡内容改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numTxtCard_TextChanged(object sender, EventArgs e)
        {

            if (!this.numTxtCard.Text.Trim().Equals(""))
            {
                try
                {
                    Convert.ToInt32(this.numTxtCard.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("请输入数字!", "提示");
                }
                this.lblName.Text = GetEmpName(Convert.ToInt32(this.numTxtCard.Text.Trim()));
            }
        }

        private void A_FrmTwo_Load(object sender, EventArgs e)
        {
            this.lblName.Text = "";
            this.BindSta();
            this.BindStaHead(0);
            if (StrCodeAndName != null)
            {
                if (StrCodeAndName.Length > 0)
                {
                    StringBuilder strB = new StringBuilder();
                    string[] strC = strCodeAndName.Split(' ');
                    for (int i = 1; i < strC.Length; i++)
                    {
                        string[] czltS = strC[i - 1].Split('-');
                        czltCalls.Add(Convert.ToInt32(czltS[0]), czltS[1]);

                        if (i % 3 == 0)
                        {
                            strB.Append(strC[i - 1] + "\n");
                        }
                        else
                        {
                            strB.Append(strC[i - 1] + " ");
                        }
                    }
                    rTxtBox.Text = strB.ToString();
                }
            }


        }
        #endregion
        #region【私有方法】

        private void BindSta()
        {
            DataTable dtStn = twobll.GetStn();
            if (dtStn != null)
            {
                cmbSta.DataSource = dtStn.Copy();
                cmbSta.DisplayMember = "StationPlace";
                cmbSta.ValueMember = "StationAddress";
            }

        }

        private void BindStaHead(int staHead)
        {
            DataTable dtStaHead = twobll.GetStnHead(staHead);
            if (dtStaHead != null)
            {
                cmbStaHead.DataSource = dtStaHead.Copy();
                cmbStaHead.DisplayMember = "StationHeadPlace";
                cmbStaHead.ValueMember = "StationHeadAddress";
            }

        }

        #region 【方法：获得员工姓名】
        /// <summary>
        /// 获得员工姓名
        /// </summary>
        /// <param name="iCardNO">标示卡卡号</param>
        public string GetEmpName(int iCardNO)
        {
            try
            {
                DataTable dtEmpName = twobll.GetEnpNameByCard(iCardNO);

                if (dtEmpName.Rows.Count > 0)
                {
                    return dtEmpName.Rows[0][0].ToString();
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        #endregion

        private void numTxtCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ("0123456789".IndexOf(e.KeyChar.ToString()) == -1)
            //{
            //    e.Handled = true;
            //    return;
            //}
            string AstrictChar = "0123456789.";
            if ((Keys)e.KeyChar == Keys.Back)
            {
                return;
            }
            //允许输入的字符外，
            if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1)
            {
                e.Handled = true;
                return;
            }
        }
        #endregion

        /// <summary>
        /// 添加呼叫人员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!lblName.Text.Equals(""))
            {
                string sCode = this.numTxtCard.Text;
                string sName = lblName.Text;
                StringBuilder strB = new StringBuilder();
                if (strCodes != null && strCodes.Length > 0)
                {
                    string[] strCC = strCodes.Substring(0, strCodes.Length - 1).Split(',');
                    foreach (string str in strCC)
                    {
                        if (str.Equals(sCode))
                        {
                            MessageBox.Show(sCode + "号标识卡已经在呼叫队列中！", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            return;

                        }
                    }
                    if (strCC.Length >= 10)
                    {
                        MessageBox.Show("最多可以同时呼叫10张标识卡！", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        return;
                    }
                }
                if (!czltCalls.ContainsKey(Convert.ToInt32(sCode)))
                {
                    czltCalls.Add(Convert.ToInt32(sCode), sName);
 
                }
                if (czltCalls.Count > 0)
                {
                    strCodes = "";
                    strCodeAndName = "";
                    foreach (int codeID in czltCalls.Keys)
                    {
                        strCodes += codeID.ToString() + ",";
                        strCodeAndName += codeID.ToString() + "-" + czltCalls[codeID] + " ";
                       
                    }

                    string[] strC = strCodeAndName.Substring(0, strCodeAndName.Length - 1).Split(' ');
                    for (int i = 1; i < strC.Length + 1; i++)
                    {
                        if (i % 3 == 0)
                        {
                            strB.Append(strC[i - 1] + "\n");
                        }
                        else
                        {
                            strB.Append(strC[i - 1] + " ");
                        }
                    }
                    rTxtBox.Text = strB.ToString();
                }

            }
            else
            {
                MessageBox.Show(numTxtCard.Text + "号标识卡没有配置人员！", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            }

        }

        /// <summary>
        /// Czlt-2011-08-17 全矿井呼叫
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCallAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要进行全矿呼叫吗？", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.IsCallAll = true;
                this.Close();

            }
            else
            {
                this.IsCallAll = false;
            }
        }

        /// <summary>
        /// Czlt-2011-08-17 区域呼叫
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSta_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要进行区域呼叫吗？", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (cmbSta.SelectedValue.ToString().Equals("0"))
                {
                    MessageBox.Show("请选择要呼叫的传输分站！", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    return;
                }


                StationNum = cmbSta.SelectedValue.ToString();


                //Czlt-2011-08-10 给读卡分站赋值
                if (cmbStaHead.SelectedValue.ToString().Equals("0"))
                {
                    StaHeadNum = "0";
                }
                else
                {
                    StaHeadNum = cmbStaHead.SelectedValue.ToString();
                }

                //Czlt-2011-08-10 给标识卡赋值
                CodeNum = "";
                this.DialogResult = DialogResult.OK;
                IsCallAll = false;

                this.Close();

            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (!lblName.Text.Equals(""))
            {
                StringBuilder strB = new StringBuilder();
                string sCode = this.numTxtCard.Text;
                string sName = lblName.Text;
                if (czltCalls.ContainsKey(Convert.ToInt32(sCode)))
                {
                    czltCalls.Remove(Convert.ToInt32(sCode));

                    if (czltCalls.Count > 0)
                    {
                        strCodes = "";
                        strCodeAndName = "";
                        foreach (int codeID in czltCalls.Keys)
                        {
                            strCodes += codeID.ToString() + ",";
                            strCodeAndName += codeID.ToString() + "-" + czltCalls[codeID] + " ";


                        }

                        string[] strC = strCodeAndName.Substring(0, strCodeAndName.Length - 1).Split(' ');
                        for (int i = 1; i < strC.Length + 1; i++)
                        {
                            if (i % 3 == 0)
                            {
                                strB.Append(strC[i - 1] + "\n");
                            }
                            else
                            {
                                strB.Append(strC[i - 1] + " ");
                            }
                        }
                        rTxtBox.Text = strB.ToString();
                    }
                    else
                    {
                        strCodes = "";
                        strCodeAndName = "";
                        rTxtBox.Text = "";
                    }
                }
                else 
                {
                    MessageBox.Show(sCode + "号标识卡不在呼叫队列中！", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
            }
            else
            {
                MessageBox.Show("请输入要停止呼叫的标识卡号！", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            
        }




    }
}
