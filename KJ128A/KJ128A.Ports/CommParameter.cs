using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Drawing;
using System.Management;

namespace KJ128A.Ports
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CommParameter :UserControl
    {
        private SerialPort commPort = null;

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        public CommParameter()
        {
            InitializeComponent();
            try
            {
                //ManagementClass class2 = new ManagementClass("Win32_SerialPort");
                //foreach (ManagementObject obj2 in class2.GetInstances())
                //{
                //    this.cmbCommPort.Items.Add(obj2["DeviceID"].ToString());
                //}

                foreach (string mo in SerialPort.GetPortNames())
                {
                    this.cmbCommPort.Items.Add(mo);
                } 
                if (this.cmbCommPort.Items.Count > 0)
                {
                    this.cmbCommPort.SelectedIndex = 0;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("获取COM口信息失败,失败信息：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        #endregion 

        #region [ 属性 : 串口标题 ]

        /// <summary>
        /// 串口标题
        /// </summary>
        public string PortTitle
        {
            get { return gpbPort.Text; }
            set { gpbPort.Text = value; }
        }

        #endregion 

        #region [ 属性 : 串口号 ]

        /// <summary>
        /// 串口号
        /// </summary>
        public string PortName
        {
            get { return cmbCommPort.Text; }
            set { cmbCommPort.Text = value; }
        }

        #endregion

        #region [ 属性 : 波特率 ]

        /// <summary>
        ///  波特率
        /// </summary>
        public int BaudRate
        {
            get { return int.Parse(cmbBaudRate.Text); }
            set
            {
                int iValue = value / 300;
                int iCount = 0;
                while (iValue != 1)
                {
                    iValue /= 2;
                    iCount++;
                }
                cmbBaudRate.SelectedIndex = iCount;
            }
        }

        #endregion 

        #region [ 属性 : 标志位 ]

        /// <summary>
        /// 标志位
        /// </summary>
        public int Mark
        {
            get { return int.Parse(cmbMark.Text); }
            set { cmbMark.Text = value.ToString(); }
        }

        #endregion

        #region [ 属性 : 基站组 ]

        /// <summary>
        /// 基站组
        /// </summary>
        public int Group
        {
            get { return int.Parse(cmbGroup.Text); }
            set { cmbGroup.Text = value.ToString(); }
        }

        #endregion

        #region [ 属性 : 是否启用 ]

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsCheck
        {
            get { return chkInvo.Checked; }
            set { chkInvo.Checked = value; gpbPort.Enabled = value; }
        }

        #endregion

        #region [ 属性 : 相同的串口名 ]

        private bool bln_Same_ProtName = false;

        /// <summary>
        /// 相同的串口名
        /// </summary>
        public bool Same_ProtName
        {
            get { return bln_Same_ProtName; }
            set
            {
                bln_Same_ProtName = value;
                if (value)
                {
                    cmbCommPort.ForeColor = Color.Red;
                }
                else
                {
                    cmbCommPort.ForeColor = Color.Black;
                }
            }
        }

        #endregion

        #region [ 属性 : 相同的标志位，基站组 ]

        private bool bln_Same_MarkGroup = false;

        /// <summary>
        /// 相同的标志位，基站组
        /// </summary>
        public bool Same_MarkGroup
        {
            get { return bln_Same_MarkGroup; }
            set 
            {
                bln_Same_MarkGroup = value;
                if (value)
                {
                    cmbGroup.ForeColor = cmbMark.ForeColor = Color.Red;
                }
                else
                {
                    cmbGroup.ForeColor = cmbMark.ForeColor = Color.Black;
                }
            }
        }

        #endregion


        #region [ 事件 : 按钮 ]

        private void btnOpenClose_Click(object sender, EventArgs e)
        {
            if (cmbCommPort.Text.Trim().Equals(string.Empty))
            { 
                // 提示 填写串口号
                ChangeState(lblCommState, 4);
                return;
            }

            if (btnOpenClose.Text == "打开串口")
            {
                if (StartPort.s_serialPort != null)
                {
                    for (int i = 0; i < StartPort.s_serialPort.Length; i++)
                    {
                        if (StartPort.s_serialPort[i].PortName == cmbCommPort.Text)
                        {
                            if (StartPort.s_serialPort[i].IsOpen())
                            {
                                ChangeState(lblCommState, 5);
                                return;
                            }
                        }
                    }
                }

                if (commPort == null)
                {
                    commPort = new SerialPort(cmbCommPort.Text, int.Parse(cmbBaudRate.Text));
                }
                // 打开串口
                Open();

                // 判断是否打开
                if (!IsOpen())
                {
                    // 提示串口打开失败
                    ChangeState(lblCommState, 3);
                    return;
                }

                btnOpenClose.Text = "关闭串口";
                // 提示串口状态
                ChangeState(lblCommState, 1);
            }
            else
            {
                Close();

                btnOpenClose.Text = "打开串口";
                // 提示串口状态
                ChangeState(lblCommState, 2);
            }
        }

        #endregion 
   
        #region [ 事件 : 是否启用]

        private void chkInvo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInvo.Checked)
            {
                gpbPort.Enabled = true;
            }
            else
            {
                gpbPort.Enabled = false;
                ChangeState(lblCommState, 6);
                btnOpenClose.Text = "打开串口";
            }
        }

        #endregion

        #region [ 方法 : 更改串口状态 ]

        /// <summary>
        /// 更改串口状态
        /// </summary>
        /// <param name="lblState">显示控件</param>
        /// <param name="iState">状态（1，打开 2，关闭 3，打开失败 4，填写）</param>
        public void ChangeState(Label lblState, int iState)
        {
            switch (iState)
            { 
                case 1:
                    lblState.ForeColor = Color.Blue;
                    cmbBaudRate.Enabled = false;
                    cmbCommPort.Enabled = false;
                    cmbMark.Enabled = false;
                    cmbGroup.Enabled = false;
                    lblState.Text = "串口打开状态";
                    break;
                case 2:
                    lblState.Text = "串口关闭状态";
                    lblState.ForeColor = Color.Black;
                    cmbBaudRate.Enabled = true;
                    cmbCommPort.Enabled = true;
                    cmbMark.Enabled = true;
                    cmbGroup.Enabled = true;
                    break;
                case 3:
                    lblState.Text = "串口打开失败";
                    lblState.ForeColor = Color.Red;
                    break;
                case 4:
                    lblState.Text = "请填写串口号";
                    lblState.ForeColor = Color.Red;
                    break;
                case 5:
                    lblState.Text = "串口使用中";
                    lblState.ForeColor = Color.Green;
                    break;
                case 6:
                    lblState.Text = "串口状态未知";
                    lblState.ForeColor = Color.Black;
                    break;
            }
        }

        #endregion

        #region  [ 方法 : 打开串口 ]

        /// <summary>
        ///  打开串口
        /// </summary>
        /// <returns></returns>
        public bool Open()
        {
            try
            {
                if (!commPort.IsOpen)
                {
                    commPort.Open();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region [ 方法 : 关闭串口 ]

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <returns></returns>
        public bool Close()
        {
            try
            {
                if (commPort!=null)
                {
                    commPort.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region [ 方法 : 判断串口是否打开 ]

        /// <summary>
        /// 判断串口是否打开
        /// </summary>
        /// <returns>true 打开</returns>
        public bool IsOpen()
        {
            try
            {
                if (commPort == null) return false;
                return commPort.IsOpen;
            }
            catch
            {
                return false;
            }
        }

        #endregion 

    }
}
