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
    public partial class FrmStationIpConfig : Form
    {
        private IpListDataSource_BAl myipbal = new IpListDataSource_BAl();
        private string tempip;

        public FrmStationIpConfig()
        {
            InitializeComponent();
            ipdrop();
            stationdrop();
            bindtext();

        }
        /// <summary>
        /// 绑定文本框
        /// </summary>
        private void bindtext()
        {
            int stcout = comboBox_station.Items.Count;
            int ipcout = comboBox_ip.Items.Count;
            if (stcout > 0)
            {
                //分站安装位置

                 int stationid=Convert.ToInt32(comboBox_station.SelectedValue.ToString());

                 textBox_place.Text = myipbal.stationplace(stationid); 

            }
            if (ipcout > 0)
            {
                //ip安装位置

                int ipid = Convert.ToInt32(comboBox_ip.SelectedValue.ToString());

                textBox_ipweizhi.Text = myipbal.ipplace(ipid); 

            }





        }
        private void stationdrop()
        {
            if (myipbal.getstationdrop().Tables[0].Rows.Count > 0)
            {
                comboBox_station.DataSource = myipbal.getstationdrop().Tables[0];
                comboBox_station.ValueMember = "stationid";
                comboBox_station.DisplayMember = "stationaddress";

            }
        }
        private void ipdrop()
        {
            if (myipbal.getipdrop().Tables[0].Rows.Count > 0)
            {
                comboBox_ip.DataSource = myipbal.getipdrop().Tables[0];
                comboBox_ip.ValueMember = "ipid";
                comboBox_ip.DisplayMember = "ipaddress";
            }

        }
        private void buttonCaptionPanel1_Click(object sender, EventArgs e)
        {
            try
            {
                string ipid = comboBox_ip.SelectedValue.ToString();
                string stationid = comboBox_station.SelectedValue.ToString();
                if (ipid.Length < 1 || stationid.Length < 1)
                {

                }
                else
                {
                    tempip = comboBox_ip.Text; 
                    //
                    int i = myipbal.updatestation(Convert.ToInt32(stationid), Convert.ToInt32(ipid));
                    //if (i == 1)
                    //{
                        MessageBox.Show("保存成功", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("保存失败", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}


                }
            }
            catch
            {
 
            }

        }

        private void bCPl_return_Click(object sender, EventArgs e)
        {
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
                        //FrmIpConfig_Main a = new FrmIpConfig_Main();
                        //a.model = 1;
                        //a.operate = 1;
                        //a.ipaddress = tempip;

                        model = 1;
                        operate = 1;
                        timer1.Start();

                    }
                }
            }


            



        }

        private void comboBox_ip_DropDownClosed(object sender, EventArgs e)
        {
           
            int ipcout = comboBox_ip.Items.Count;
           
            if (ipcout > 0)
            {
                int ipid = Convert.ToInt32(comboBox_ip.SelectedValue.ToString());

                textBox_ipweizhi.Text = myipbal.ipplace(ipid); 

            }
        }

        private void comboBox_station_DropDownClosed(object sender, EventArgs e)
        {
            int stcout = comboBox_station.Items.Count;
            int ipcout = comboBox_ip.Items.Count;
            if (stcout > 0)
            {
                //分站安装位置

                int stationid = Convert.ToInt32(comboBox_station.SelectedValue.ToString());

                textBox_place.Text = myipbal.stationplace(stationid);

            }
            if (ipcout > 0)
            {
                //ip安装位置

            }
        }

        private void bCPl_baofan_Click(object sender, EventArgs e)
        {
            //保存并返回

            try
            {
                string ipid = comboBox_ip.SelectedValue.ToString();
                string stationid = comboBox_station.SelectedValue.ToString();
                if (ipid.Length < 1 || stationid.Length < 1)
                {

                }
                else
                {
                    tempip = comboBox_ip.Text; 
                    int i = myipbal.updatestation(Convert.ToInt32(stationid), Convert.ToInt32(ipid));
                    //if (i == 1)
                    //{
                        MessageBox.Show("保存成功", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                                    //FrmIpConfig_Main a = new FrmIpConfig_Main();
                                    //a.model = 1;
                                    //a.operate = 1;
                                    //a.ipaddress = tempip;

                                    model = 1;
                                    operate = 1;
                                    timer1.Start();

                                }
                            }
                        }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("保存失败", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}


                }
            }
            catch
            {

            }



        }

        /// <summary>
        /// 最大刷新次数
        /// </summary>
        private int maxTimes = 2;

        /// <summary>
        /// 查询刷新次数
        /// </summary>
        private int times = 0;

        /// <summary>
        /// 1表示增加，修改 2 表示删除 
        /// </summary>
        public int operate = 1;

        /// <summary>
        /// 检测是哪个模块触发
        /// 1是IP 2是ADDRESS  
        /// </summary>
        public int model = 0;



        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (model)
            {
                case 1:

                    if (operate == 1)
                    {
                        if (RecordSearch.IsRecordExists("TcpIPConfig", "IPAddress", tempip, DataType.String))
                        {
                            //刷新
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

                            c3.DataSource = myipbal.iplist();
                            c33.DataSource = myipbal.Getstationlist();

                            //dataipbind();
                            //datastationbind();
                            times = 0;
                            //关闭timer1
                            timer1.Stop();
                        }
                        else
                        {
                            if (times < maxTimes)
                            {
                                times++;
                                timer1.Stop();
                                timer1.Start();
                            }
                            else
                            {
                                times = 0;
                                //关闭timer1
                                timer1.Stop();
                            }
                        }
                    }
                    break;

            }


         
        }
    }
}
