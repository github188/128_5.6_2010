using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128WindowsLibrary;
using ZdcCommonLibrary;
using KJ128NDataBase;
using System.Data.SqlClient;

using Shine.Logs;
using Shine.Logs.LogType;

using System.Text.RegularExpressions;
using KJ128NDBTable;

namespace KJ128NMainRun
{
    public partial class FrmIpConfig_Add : Form
    {
        private string tempip;
        public FrmIpConfig_Add()
        {
            InitializeComponent();
        }
        private IpListDataSource_BAl myipbal = new IpListDataSource_BAl();
     
        private void buttonCaptionPanel_save_Click(object sender, EventArgs e)
        {
            if (label4.Text.Length > 0)
            {

                #region 修改
                //添加前先验证
                string ip = textBox_ip.Text.Trim();
                string port = textBox_ipport.Text.Trim();
                string address = textBox_azwz.Text.Trim();
                if (checkaddress(address))
                {

                }
                else
                {
                    MessageBox.Show("安装位置格式不正确，请重新输入", "安装位置格式", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                if (ip.Length > 0)
                {
                    if (!checkIpAddress(ip))
                    {
                        MessageBox.Show("IP地址不正确，请重新输入", "IP地址", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {

                    MessageBox.Show("IP不能为空，请重新输入", "IP地址", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Check())
                {
                    return;
                }

                if (RecordSearch.IsRecordExists("TcpIPConfig", "IPAddress", ip, DataType.String))
                {
                    MessageBox.Show("IP不能为重复，请重新输入", "IP地址", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                tempip = textBox_ip.Text.Trim();
                int i = myipbal.updateip(ip, port, address,Convert.ToInt32(label4.Text));
                if (i == 1)
                {
                    MessageBox.Show("修改成功", "修改成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("修改失败", "修改失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                #endregion
            
            }
            else
            {
             #region 添加IP
            //添加前先验证
            string ip = textBox_ip.Text.Trim();
            string port = textBox_ipport.Text.Trim();
            string address=textBox_azwz.Text.Trim();
            if (checkaddress(address))
            {

            }
            else
            {
                MessageBox.Show("安装位置格式不正确，请重新输入", "安装位置格式", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            if (ip.Length > 0)
            {
                if (!checkIpAddress(ip))
                {
                    MessageBox.Show("IP地址不正确,请重新输入," + "\r\n" + " 输入格式:192.168.1.1", "IP地址", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {

                MessageBox.Show("IP不能为空，请重新输入", "IP地址", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Check())
            {
                return;
            }
            if (RecordSearch.IsRecordExists("TcpIPConfig", "IPAddress", ip, DataType.String))
            {
                MessageBox.Show("IP不能为重复，请重新输入", "IP地址", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            int i = myipbal.addip(ip, port,address);
            if (i == 1)
            {
                tempip = textBox_ip.Text.Trim();
                MessageBox.Show("添加成功", "添加成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //清空内容
                textBox_ip.Text = "";
                textBox_ipport.Text = "";
                textBox_azwz.Text = "";


            }
            else
            {
                MessageBox.Show("添加失败", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #endregion
            }
           

        }
        #region 验证IP
        public static bool checkIpAddress(string strIpAddress)
        {
            try
            {
                string webServerAddress;
                Regex r = new Regex(@"^(\d+)\.(\d+)\.(\d+)\.(\d+)$");//IP地址的正则表达式
                Match m;
                webServerAddress = strIpAddress.Trim();
                m = r.Match(webServerAddress);
                if (m.Success)   //进一步判断IP地址的合法性
                {
                    //获取该IP地址的段数
                    int j = checkIpAddressMore(webServerAddress);
                    if (j == 4)
                        return true;// 满足IP地址格式的要求
                    else
                        return false;//非法地址
                }
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }
        private static int checkIpAddressMore(string strIpAdderss)
        {
            string[] stringArray;
            int j = 0;
            //分割字符串
            stringArray = strIpAdderss.Split('.');
            foreach (string strVar in stringArray)
            {
                if (int.Parse(strVar) <= 255)
                {
                    j++;
                }
                else
                {
                    break;
                }
            }
            return j;
        }

        #endregion

        private void textBox_ip_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
        private bool Check()
        {

            if (textBox_ipport.Text.Length < 1)
            {
                MessageBox.Show("端口号不能为空", "端口配置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (int.Parse(textBox_ipport.Text) <= 1024 || int.Parse(textBox_ipport.Text) >= 65535)
            {
                MessageBox.Show("端口号配置不正确 " + "\r\n" + " 端口号为1024至65535", "端口配置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void textBox_ipport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == false && e.KeyChar != '\b')
            {
                e.KeyChar = new char();
            }
        }

        private void buttonCaptionPanel_fanhui_Click(object sender, EventArgs e)
        {
            //Control c1 = panel1.Parent;
            //Control c2 = c1.Controls["ipmain"];
            //panel1.Visible = false;
            //c2.Visible = true;
            //Control cc = c2.Controls[1];
            //Control cc1 = cc.Controls["splitContainer3"];
            //Control cc2 = cc1.Controls[0];
            //DataGridView c3 = new DataGridView();
            //c3 = (DataGridView)cc2.Controls["dataGridViewKJ128_ip"];


            //Control cc5 = cc1.Controls[1];
            //DataGridView c33 = new DataGridView();
            //c33 = (DataGridView)cc5.Controls["dataGridViewKJ128_station"];
            //if (tempip != null)
            //{
            //    if (tempip.Length > 0)
            //    {
            //        if (!New_DBAcess.IsDouble)
            //        {
            //            c3.DataSource = myipbal.iplist();
            //            c33.DataSource = myipbal.Getstationlist();
            //        }
            //        else
            //        {
            //            //FrmIpConfig_Main a = new FrmIpConfig_Main();
            //            //a.model = 1;
            //            //a.operate = 1;
            //            //a.ipaddress = tempip;

            //            model = 1;
            //            operate = 1;
            //            timer1.Start();

            //        }
            //    }
            //}
            
        }
        /// <summary>
        /// true为没有
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        private bool checkaddress(string add)
        {
            char[] array = new char[] { ',', '.', '*', '/', '>', '!', '@', '#', '$', '%', '^', '&', '(', ')', '-', '_', '=', '+', '[', ']', '{', '}', ';', ':', '"', '\\' };
            int ygbhn = add.IndexOfAny(array);
            if (ygbhn > -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void buttonCaptionPanel2_Click(object sender, EventArgs e)
        {
            if (label4.Text.Length > 0)
            {

                #region 修改
                //添加前先验证
                string ip = textBox_ip.Text.Trim();
                string port = textBox_ipport.Text.Trim();
                string address = textBox_azwz.Text.Trim();
                if (checkaddress(address))
                {

                }
                else
                {
                    MessageBox.Show("安装位置格式不正确，请重新输入", "安装位置格式", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                if (ip.Length > 0)
                {
                    if (!checkIpAddress(ip))
                    {
                        MessageBox.Show("IP地址不正确，请重新输入", "IP地址", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {

                    MessageBox.Show("IP不能为空，请重新输入", "IP地址", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Check())
                {
                    return;
                }
                if (RecordSearch.IsRecordExists("TcpIPConfig", "IPAddress", ip, DataType.String))
                {
                    MessageBox.Show("IP不能为重复，请重新输入", "IP地址", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                tempip = textBox_ip.Text.Trim();
                int i = myipbal.updateip(ip, port, address,Convert.ToInt32(label4.Text));
                if (i == 1)
                {
                    MessageBox.Show("修改成功", "修改成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Control c1 = panel1.Parent;
                    Control c2 = c1.Controls["ipmain"];
                    panel1.Visible = false;
                    c2.Visible = true;
                    Control cc = c2.Controls[1];
                    Control cc1 = cc.Controls["splitContainer3"];
                    Control cc2 = cc1.Controls[0];
                    DataGridView c3 = new DataGridView();
                    c3 = (DataGridView)cc2.Controls["dataGridViewKJ128_ip"];


                    Control cc5 = cc1.Controls[1];
                    DataGridView c33 = new DataGridView();
                    c33 = (DataGridView)cc5.Controls["dataGridViewKJ128_station"];
                    if (tempip != null)
                    {
                        if (tempip.Length > 0)
                        {
                            if (!New_DBAcess.IsDouble)
                            {
                                c3.DataSource = myipbal.iplist();
                                c33.DataSource = myipbal.Getstationlist();
                            }
                            else
                            {

                                //model = 1;
                                //operate = 1;

                                //timer1.Start();

                            }
                        }
                    }


                }
                else
                {
                    MessageBox.Show("修改失败", "修改失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                #endregion

            }
            else
            {
                #region 添加IP
                //添加前先验证
                string ip = textBox_ip.Text.Trim();
                string port = textBox_ipport.Text.Trim();
                string address = textBox_azwz.Text.Trim();
                if (checkaddress(address))
                {

                }
                else
                {
                    MessageBox.Show("安装位置格式不正确，请重新输入", "安装位置格式", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                if (ip.Length > 0)
                {
                    if (!checkIpAddress(ip))
                    {
                        MessageBox.Show("IP地址不正确，请重新输入", "IP地址", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {

                    MessageBox.Show("IP不能为空，请重新输入", "IP地址", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Check())
                {
                    return;
                }
                if (RecordSearch.IsRecordExists("TcpIPConfig", "IPAddress", ip, DataType.String))
                {
                    MessageBox.Show("IP不能为重复，请重新输入", "IP地址", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                int i = myipbal.addip(ip, port, address);
                tempip = textBox_ip.Text.Trim();
                if (i == 1)
                {
                    MessageBox.Show("添加成功", "添加成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Control c1 = panel1.Parent;
                    //Control c2 = c1.Controls["ipmain"];
                    //panel1.Visible = false;
                    //c2.Visible = true;
                    //Control cc = c2.Controls[1];
                    //Control cc1 = cc.Controls["splitContainer3"];
                    //Control cc2 = cc1.Controls[0];
                    //DataGridView c3 = new DataGridView();
                    //c3 = (DataGridView)cc2.Controls["dataGridViewKJ128_ip"];


                    //Control cc5 = cc1.Controls[1];
                    //DataGridView c33 = new DataGridView();
                    //c33 = (DataGridView)cc5.Controls["dataGridViewKJ128_station"];
                    //if (tempip != null)
                    //{
                    //    if (tempip.Length > 0)
                    //    {
                    //        if (!New_DBAcess.IsDouble)
                    //        {
                    //            c3.DataSource = myipbal.iplist();
                    //            c33.DataSource = myipbal.Getstationlist();
                    //        }
                    //        else
                    //        {

                    //            model = 1;
                    //            operate = 1;

                    //            timer1.Start();

                    //        }
                    //    }
                    //}
                }
                else
                {
                    MessageBox.Show("添加失败", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                #endregion
            }
        }




        ///// <summary>
        ///// 最大刷新次数
        ///// </summary>
        //private int maxTimes = 2;

        ///// <summary>
        ///// 查询刷新次数
        ///// </summary>
        //private int times = 0;

        ///// <summary>
        ///// 1表示增加，修改 2 表示删除 
        ///// </summary>
        //public int operate = 1;

        ///// <summary>
        ///// 检测是哪个模块触发
        ///// 1是IP 2是ADDRESS  
        ///// </summary>
        //public int model = 0;

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    switch (model)
        //    {
        //        case 1:

        //            if (operate == 1)
        //            {
        //                if (RecordSearch.IsRecordExists("TcpIPConfig", "IPAddress", tempip, DataType.String))
        //                {
        //                    //刷新
        //                    Control c1 = panel1.Parent;
        //                    Control c2 = c1.Controls["ipmain"];
        //                    panel1.Visible = false;
        //                    c2.Visible = true;
        //                    Control cc = c2.Controls[1];
        //                    Control cc1 = cc.Controls["splitContainer3"];
        //                    Control cc2 = cc1.Controls[0];
        //                    DataGridView c3 = new DataGridView();
        //                    c3 = (DataGridView)cc2.Controls["dataGridViewKJ128_ip"];


        //                    Control cc5 = cc1.Controls[1];
        //                    DataGridView c33 = new DataGridView();
        //                    c33 = (DataGridView)cc5.Controls["dataGridViewKJ128_station"];

        //                    c3.DataSource = myipbal.iplist();
        //                    c33.DataSource = myipbal.Getstationlist();

        //                    //dataipbind();
        //                    //datastationbind();
        //                    times = 0;
        //                    //关闭timer1
        //                    timer1.Stop();
        //                }
        //                else
        //                {
        //                    if (times < maxTimes)
        //                    {
        //                        times++;
        //                        timer1.Stop();
        //                        timer1.Start();
        //                    }
        //                    else
        //                    {
        //                        times = 0;
        //                        //关闭timer1
        //                        timer1.Stop();
        //                    }
        //                }
        //            }
        //            break;
                   
        //    }

           
        //}

        
    }
}