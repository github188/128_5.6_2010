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
using KJ128NDBTable;
using Shine.Logs;
using Shine.Logs.LogType;
using System.Text.RegularExpressions;
using System.Threading;
namespace KJ128NMainRun
{
    public partial class FrmIpConfig_Main : Form
    {
        private IpListDataSource_BAl myipbal = new IpListDataSource_BAl();
        /// <summary>
        /// ipid delete 时赋值
        /// </summary>
        private int id;
        /// <summary>
        /// statid delete 时赋值
        /// </summary>
        private int statid;

        public FrmIpConfig_Main()
        {
            InitializeComponent();
            dataipbind();
            datastationbind();
        }
        private void datastationbind()
        {
            dataGridViewKJ128_station.DataSource = myipbal.Getstationlist();
        }
        public void dataipbind()
        {
            dataGridViewKJ128_ip.DataSource = myipbal.iplist();
           
        }
        private void ToolStripMenuItem_addip_Click(object sender, EventArgs e)
        {

            Control c1 = splitContainer1.Parent;

            Control c2 = c1.Controls["ipadd"];
            splitContainer1.Visible = false;
            c2.Visible = true;

            Control c3 = c1.Controls["ipadd"];
            Control c4 = c3.Controls["label4"];
            c4.Text = "";

            Control c5 = c3.Controls["textBox_azwz"];
            c5.Text = "";


            Control c6 = c3.Controls["textBox_ip"];
            c6.Text = "";

            Control c7 = c3.Controls["textBox_ipport"];
            c7.Text = "";


        }

        private void ToolStripMenuItem_updata_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dataGridViewKJ128_ip.CurrentCell.RowIndex;
                string id = dataGridViewKJ128_ip.Rows[i].Cells[3].Value.ToString();
                string ip = dataGridViewKJ128_ip.Rows[i].Cells[1].Value.ToString();
                string prot = dataGridViewKJ128_ip.Rows[i].Cells[2].Value.ToString();
                string place = dataGridViewKJ128_ip.Rows[i].Cells[0].Value.ToString();
                Control c1 = splitContainer1.Parent;

                Control c2 = c1.Controls["ipadd"];
                splitContainer1.Visible = false;
                c2.Visible = true;
                Control c3 = c1.Controls["ipadd"];
                Control c4 = c3.Controls["label4"];
                c4.Text = id;

                Control c5 = c3.Controls["textBox_azwz"];
                c5.Text = place;


                Control c6 = c3.Controls["textBox_ip"];
                c6.Text = ip;

                Control c7 = c3.Controls["textBox_ipport"];
                c7.Text = prot;
            }
            catch (Exception ex)
            {
 
            }
        }

        private void dataGridViewKJ128_ip_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridViewKJ128_ip.ClearSelection();
                dataGridViewKJ128_ip.Rows[e.RowIndex].Selected = true;
                dataGridViewKJ128_ip.CurrentCell = dataGridViewKJ128_ip.Rows[e.RowIndex].Cells[e.ColumnIndex];
                bCP_updata.Visible = true;
            }
            else
            {
 
            }
        }

        private void bCP_add_Click(object sender, EventArgs e)
        {
            Control c1 = splitContainer1.Parent;

            Control c2 = c1.Controls["ipadd"];
            splitContainer1.Visible = false;
            c2.Visible = true;

            Control c3 = c1.Controls["ipadd"];
            Control c4 = c3.Controls["label4"];
            c4.Text = "";

            Control c5 = c3.Controls["textBox_azwz"];
            c5.Text = "";


            Control c6 = c3.Controls["textBox_ip"];
            c6.Text = "";

            Control c7 = c3.Controls["textBox_ipport"];
            c7.Text = "";





        }

        private void bCP_updata_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dataGridViewKJ128_ip.CurrentCell.RowIndex;
                string id = dataGridViewKJ128_ip.Rows[i].Cells[3].Value.ToString();
                string ip = dataGridViewKJ128_ip.Rows[i].Cells[1].Value.ToString();
                string prot = dataGridViewKJ128_ip.Rows[i].Cells[2].Value.ToString();
                string place = dataGridViewKJ128_ip.Rows[i].Cells[0].Value.ToString();
                Control c1 = splitContainer1.Parent;

                Control c2 = c1.Controls["ipadd"];
                splitContainer1.Visible = false;
                c2.Visible = true;
                Control c3 = c1.Controls["ipadd"];
                Control c4 = c3.Controls["label4"];
                c4.Text = id;

                Control c5 = c3.Controls["textBox_azwz"];
                c5.Text = place;


                Control c6 = c3.Controls["textBox_ip"];
                c6.Text = ip;

                Control c7 = c3.Controls["textBox_ipport"];
                c7.Text = prot;




            }
            catch (Exception ex)
            {
 
            }
        }

        private void ToolStripMenuItem_delip_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dataGridViewKJ128_ip.CurrentCell.RowIndex;
                 id = Convert.ToInt32(dataGridViewKJ128_ip.Rows[i].Cells[3].Value.ToString());

                DialogResult msgType = MessageBox.Show("您是否要删除该记录", "提示信息", MessageBoxButtons.YesNo);
               

                if (msgType == DialogResult.Yes)
                {
                    int k = myipbal.deleteip(id);
                    if (k >= 1)
                    {
                        operate = 2;
                        model = 1;
                        timer1.Start();

                       
                        MessageBox.Show("删除成功", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    else
                    {
                        operate = 2;
                        model = 1;
                        timer1.Start();
                        MessageBox.Show("删除失败", "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }


                }


                
            }
            catch (Exception ex)
            {

            }
        }

        private void bCP_shuaxin_Click(object sender, EventArgs e)
        {
            dataipbind();
        }

        private void ToolStripMenuItem_Associationstation_Click(object sender, EventArgs e)
        {
            //关联

            try
            {
                int i = dataGridViewKJ128_station.CurrentCell.RowIndex;
                string id = dataGridViewKJ128_station.Rows[i].Cells[4].Value.ToString();

                string ipid = dataGridViewKJ128_station.Rows[i].Cells[5].Value.ToString();


                Control c1 = splitContainer1.Parent;
                Control c = c1.Controls["ipadd"];
                c.Visible = false;
                Control c2 = c1.Controls["station"];
                splitContainer1.Visible = false;
                c2.Visible = true;

                Control c4 = c2.Controls["label5"];
                c4.Text = id;

                Control c5 = c2.Controls["label6"];
                c5.Text = ipid;



                Control cc1 = c2.Controls["comboBox_ip"];



                ComboBox c33 = new ComboBox();

                c33 = (ComboBox)cc1;
                c33.DataSource = myipbal.getipdrop().Tables[0];

                c33.ValueMember = "ipid";
                c33.DisplayMember = "ipaddress";




                Control cc2 = c2.Controls["comboBox_station"];

                ComboBox c44 = new ComboBox();

                c44 = (ComboBox)cc2;
                c44.DataSource = myipbal.getstationdrop().Tables[0];


                c44.ValueMember = "stationid";
                c44.DisplayMember = "stationaddress";



              
            }
            catch (Exception ex)
            {
                Control c1 = splitContainer1.Parent;
                Control c = c1.Controls["ipadd"];
                Control c2 = c1.Controls["station"];
                c.Visible = false;
                splitContainer1.Visible = false;
                c2.Visible = true;


                Control cc1 = c2.Controls["comboBox_ip"];


                ComboBox c3 = new ComboBox();

                c3 = (ComboBox)cc1;
                c3.DataSource = myipbal.getipdrop().Tables[0];

                c3.ValueMember = "ipid";
                c3.DisplayMember = "ipaddress";


                Control cc2 = c2.Controls["comboBox_station"];
                ComboBox c4 = new ComboBox();

                c4 = (ComboBox)cc2;



                c4.DataSource = myipbal.getstationdrop().Tables[0];

                c4.ValueMember = "stationid";
                c4.DisplayMember = "stationaddress";




                Control cc5 = c2.Controls["comboBox_station"];

                ComboBox c44 = new ComboBox();

                c44 = (ComboBox)cc5;
                c44.DataSource = myipbal.getstationdrop().Tables[0];


                c44.ValueMember = "stationid";
                c44.DisplayMember = "stationaddress";





            }



          

          

        }

        private void dataGridViewKJ128_station_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridViewKJ128_station.ClearSelection();
                dataGridViewKJ128_station.Rows[e.RowIndex].Selected = true;
                dataGridViewKJ128_station.CurrentCell = dataGridViewKJ128_station.Rows[e.RowIndex].Cells[e.ColumnIndex];
                //bCP_updata.Visible = true;
            }
            else
            {

            }
        }

        private void ToolStripMenuItem_delstation_Click(object sender, EventArgs e)
        {

            try
            {
                int i = dataGridViewKJ128_station.CurrentCell.RowIndex;
                  statid = Convert.ToInt32(dataGridViewKJ128_station.Rows[i].Cells[4].Value.ToString());

                DialogResult msgType = MessageBox.Show("您是否要删除该记录", "提示信息", MessageBoxButtons.YesNo);
                // 备份

                if (msgType == DialogResult.Yes)
                {
                    int k = myipbal.delstation(statid);
                    if (k == 1)
                    {
                        operate = 2;
                        model = 2;
                        timer1.Start();
                        MessageBox.Show("删除成功", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    else
                    {
                        operate = 2;
                        model = 2;
                        timer1.Start();
                        MessageBox.Show("删除失败", "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }


                }



            }
            catch (Exception ex)
            {

            }
        }

        private void bCP_shuaxinip_Click(object sender, EventArgs e)
        {
            datastationbind();
        }

        private void buttonCaptionPanel4_Click(object sender, EventArgs e)
        {
            dataipbind();

            textBox_ip.Text = "";
        }

        private void buttonCaptionPanel3_Click(object sender, EventArgs e)
        {
            //根据条件查询
            string ip = textBox_ip.Text.Trim();
            
                if (ip.Length > 0)
                {
                    if (!checkIpAddress(ip))
                    {
                        MessageBox.Show("IP地址不正确,请重新输入,"+ "\r\n" + "输入格式:192.168.1.1", "IP地址", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {

                    MessageBox.Show("IP不能为空，请重新输入", "IP地址", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            //chaxun
                dataGridViewKJ128_ip.DataSource=myipbal.getiplistbyip(ip);


           

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

        private void buttonCaptionPanel2_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dataGridViewKJ128_station.CurrentCell.RowIndex;
                string id = dataGridViewKJ128_station.Rows[i].Cells[4].Value.ToString();

                string ipid = dataGridViewKJ128_station.Rows[i].Cells[5].Value.ToString();


                Control c1 = splitContainer1.Parent;
                Control c = c1.Controls["ipadd"];
                c.Visible = false;
                Control c2 = c1.Controls["station"];
                splitContainer1.Visible = false;
                c2.Visible = true;

                Control c4 = c2.Controls["label5"];
                c4.Text = id;

                Control c5 = c2.Controls["label6"];
                c5.Text = ipid;



                Control cc1 = c2.Controls["comboBox_ip"];



                ComboBox c33 = new ComboBox();

                c33 = (ComboBox)cc1;
                c33.DataSource = myipbal.getipdrop().Tables[0];

                c33.ValueMember = "ipid";
                c33.DisplayMember = "ipaddress";




                Control cc2 = c2.Controls["comboBox_station"];

                ComboBox c44 = new ComboBox();

                c44 = (ComboBox)cc2;
                c44.DataSource = myipbal.getstationdrop().Tables[0];


                c44.ValueMember = "stationid";
                c44.DisplayMember = "stationaddress";




            }
            catch (Exception ex)
            {
                Control c1 = splitContainer1.Parent;
                Control c = c1.Controls["ipadd"];
                Control c2 = c1.Controls["station"];
                c.Visible = false;
                splitContainer1.Visible = false;
                c2.Visible = true;


                Control cc1 = c2.Controls["comboBox_ip"];


                ComboBox c3 = new ComboBox();

                c3 = (ComboBox)cc1;
                c3.DataSource = myipbal.getipdrop().Tables[0];

                c3.ValueMember = "ipid";
                c3.DisplayMember = "ipaddress";


                Control cc2 = c2.Controls["comboBox_station"];
                ComboBox c4 = new ComboBox();

                c4 = (ComboBox)cc2;



                c4.DataSource = myipbal.getstationdrop().Tables[0];

                c4.ValueMember = "stationid";
                c4.DisplayMember = "stationaddress";




                Control cc5 = c2.Controls["comboBox_station"];

                ComboBox c44 = new ComboBox();

                c44 = (ComboBox)cc5;
                c44.DataSource = myipbal.getstationdrop().Tables[0];


                c44.ValueMember = "stationid";
                c44.DisplayMember = "stationaddress";

                Control cc6 = c2.Controls["textBox_place"];
                TextBox cc7 = new TextBox();
                cc7 = (TextBox)cc6;
                cc7.Text = "";


                Control cc8 = c2.Controls["textBox_ipweizhi"];
                TextBox cc9 = new TextBox();
                cc9 = (TextBox)cc8;
                cc9.Text = "";




                int stcout = c44.Items.Count;
                int ipcout = c3.Items.Count;
                if (stcout > 0)
                {
                    //分站安装位置

                    int stationid = Convert.ToInt32(c44.SelectedValue.ToString());

                    cc7.Text = myipbal.stationplace(stationid);

                }
                if (ipcout > 0)
                {
                    //ip安装位置

                    int ipid = Convert.ToInt32(c3.SelectedValue.ToString());

                    cc9.Text = myipbal.ipplace(ipid);

                }




            }
        }

        private void bCP_shuaxinip_Click_1(object sender, EventArgs e)
        {
            datastationbind();
        }

        private void buttonCaptionPanel6_Click(object sender, EventArgs e)
        {

             string ip = textBox_ip1.Text.Trim();
            
                if (ip.Length > 0)
                {
                    if (!checkIpAddress(ip))
                    {
                        MessageBox.Show("IP地址不正确,请重新输入" + "\r\n" + " 输入格式:192.168.1.1", "IP地址", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {

                    MessageBox.Show("IP不能为空，请重新输入", "IP地址", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            //chaxun
                dataGridViewKJ128_station.DataSource = myipbal.stationbyip(ip);


            
        }

        private void buttonCaptionPanel5_Click(object sender, EventArgs e)
        {
            datastationbind();
            textBox_ip1.Text = "";

        }






        #region 热备定时刷新


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
        public int model = 1;


        private string worktype = "";

        private string cer = "";

        private string duty = "";

        public string ipaddress;

        public void timer1_Tick(object sender, EventArgs e)
        {

            switch (model)
            {
                //IP
                case 1:

                    if (operate == 2)
                    
                    {
                        

                        if (!RecordSearch.IsRecordExists("TcpIPConfig", "ipid", id.ToString(), DataType.Int))
                        {
                            //刷新

                            dataipbind();
                            datastationbind();
                            times = 0;
                            //关闭timer1
                            timer1.Stop();
                        }
                        else
                        {
                            if (times < maxTimes)
                            {
                                times++;
                                //timer1_Tick(sender, e);
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

                //address
                case 2:

                    if (operate == 2)
                    {
                        if (!RecordSearch.IsRecordExists("Station_Info", "ipaddressid", statid.ToString(), DataType.Int))
                        {
                            //刷新

                            dataipbind();
                            datastationbind();
                            times = 0;
                            //关闭timer1
                            timer1.Stop();
                        }
                        else
                        {
                            if (times < maxTimes)
                            {
                                times++;
                                //timer1_Tick(sender, e);
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
     
                default:
                    break;
            }
                   
           
        }
        #endregion
    }
}
