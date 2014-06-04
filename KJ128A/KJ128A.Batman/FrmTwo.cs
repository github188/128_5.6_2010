using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using KJ128A.Ports;
using KJ128A.Protocol;
using KJ128NMainRun;

namespace KJ128A.Batman
{
    public partial class FrmTwo : Form
    {
        private int _ComIndex;
        private int _iAddress = 1;
        private int _iMark;
        public FrmTwo()
        {
            InitializeComponent();
            cmdSerical.DisplayMember = "PortName";
            cmdSerical.DataSource = StartPort.s_serialPort;
            cmdSerical.SelectedIndexChanged += new EventHandler(cmdSerical_SelectedIndexChanged);
            if (cmdSerical.Items.Count > 0)
            {
                cmdSerical.SelectedIndex = 0;
                
                cmdSerical_SelectedIndexChanged(null, null);
            }
        }

        void cmdSerical_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdStation.DisplayMember = "Address";
            cmdStation.DataSource = StartPort.s_serialPort[cmdSerical.SelectedIndex].Stations;
            if (cmdStation.Items.Count>0)
            {
                cmdStation.SelectedIndex = 0;
            }
        }
        private void btnCancal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!Check())
            { return; }

            byte[] b = Encoding.ASCII.GetBytes(rtxtMessage.Text);
            if (b.Length>40)
            {
                MessageBox.Show("输入的发送信息只能有20个汉字", "双向通讯", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtxtMessage.Focus();
                return;
            }

            _ComIndex = cmdSerical.SelectedIndex;
            _iAddress = StartPort.s_serialPort[_ComIndex].TempStations[cmdStation.SelectedIndex].Address;
            _iMark = StartPort.s_serialPort[_ComIndex].Mark;
            try
            {
                StartPort.s_serialPort[_ComIndex].Stations[cmdStation.SelectedIndex].CmdTwo = Two(_iAddress, _iMark, int.Parse(txtCard.Text), rtxtMessage.Text);
                StartPort.s_serialPort[_ComIndex].Stations[cmdStation.SelectedIndex].IsTwo = true;
            }
            catch
            {
            }
            this.Close();
        }

        public static byte[] Two(int iStationAddress, int iMark, int iCard, string strMessage)
        {
            try
            {
                byte[] bMessage = Encoding.GetEncoding("gb2312").GetBytes(strMessage);

                byte[] eBit;
                byte[] Fs = new byte[15+bMessage.Length];
                Fs[0] = 10;
                for (int i = 1; i <= 5; i++)
                {
                    Fs[i] = 255;
                }
                Fs[6] = (byte)iStationAddress; // 基站地址号
                Fs[7] = 19; // 命令号
                Fs[8] = (byte)iMark; // 主备标志
                Fs[9] = (byte)(3 + bMessage.Length);     // 长度
                Fs[10] = (byte)0;            // 控制
                if (iCard >= 0)
                {
                    if (iCard > 256)
                    {
                        Fs[11] = (byte)(iCard / 256);
                        Fs[12] = (byte)(iCard - 256);
                    }
                    else
                    {
                        Fs[11] = (byte)0;
                        Fs[12] = (byte)iCard;
                    }

                }
                else
                {
                    Fs[11] = (byte)0; // 卡号
                    Fs[12] = (byte)0; // 卡号
                }
                
                for (int i = 0; i < bMessage.Length; i++)
                {
                    Fs[13 + i] = bMessage[i];
                }
                eBit = CRCVerify.Crc(Fs, Fs.Length - 2, 1);
                Fs[Fs.Length-2] = eBit[1]; //低位
                Fs[Fs.Length-1] = eBit[0]; //高位
                return Fs;
            }
            catch
            {
                return null;
            }
        }

        private bool Check()
        {
            if (cmdSerical.SelectedIndex < 0)
            {
                MessageBox.Show("未选择通讯串口", "双向通讯", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmdStation.SelectedIndex < 0)
            {
                MessageBox.Show("未选择分站", "双向通讯", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Microsoft.VisualBasic.Information.IsNumeric(txtCard.Text))
            {
                MessageBox.Show("请输入数字", "双向通讯", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCard.Focus();
                return false;
            }
            if (int.Parse(txtCard.Text)<0 || int.Parse(txtCard.Text)>8000)
            {
                MessageBox.Show("人员卡号范围（0-8000）", "双向通讯", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCard.Focus();
                return false;
            }

            if (rtxtMessage.Text.Trim().Equals(""))
            {
                MessageBox.Show("请输入发送信息", "双向通讯", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtxtMessage.Focus();
                return false;
            }
            return true;
        }

        private void txtCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void rtxtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
    }
}
