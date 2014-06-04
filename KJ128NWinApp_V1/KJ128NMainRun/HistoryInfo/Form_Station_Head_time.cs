using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using KJ128NDBTable;
using KJ128NModel;
using Shine.Logs;
using Shine.Logs.LogType;

namespace KJ128NMainRun.HistoryInfo
{
    public partial class Form_Station_Head_time : Wilson.Controls.Docking.DockContent
    {
        DeptBLL dBLL = new DeptBLL();
        His_Station_Head_time_BLL_txj myhis = new His_Station_Head_time_BLL_txj();
        /// <summary>
        /// 是否为空数据,true为空数据,false为有数据,默认为false
        /// </summary>
        private bool isnulldata = false;
        /// <summary>
        /// 每页显示行数
        /// </summary>
        int pageSize = 0;     //每页显示行数
        /// <summary>
        /// 总记录数
        /// </summary>
        int nMax = 0;         //总记录数
        /// <summary>
        /// 页数＝总记录数/每页显示行数
        /// </summary>
        int pageCount = 0;    //页数＝总记录数/每页显示行数
        /// <summary>
        /// 当前页号
        /// </summary>
        int pageCurrent = 0;   //当前页号
        /// <summary>
        /// 当前记录行
        /// </summary>
        int nCurrent = 0;      //当前记录行

        DataSet ds = new DataSet();
        DataTable dtInfo = new DataTable();
        public Form_Station_Head_time()
        {
         
            InitializeComponent();
            page_load();
            dtpStartTime.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
            dtpEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); 

        }

        #region 页面初始化代码
        /// <summary>
        /// 页面初始化
        /// </summary>
        private void page_load()
        {
            dBLL.getDeptAddAll(comboBox_bumen);
            myhis.getStation(comboBox_ksjzh);
            myhis.getStation(comboBox_jsjzh);

            int k = Convert.ToInt32(comboBox_bumen.SelectedValue);
            int stationid = Convert.ToInt32(comboBox_ksjzh.SelectedValue);
            int stationid1 = Convert.ToInt32(comboBox_ksjzh.SelectedValue);
            myhis.getHead(comboBox_ksjsq, stationid);
            myhis.getHead(comboBox_jsjsq, stationid1);

            int tempcount = comboBox_jsjzh.Items.Count;
            if (tempcount > 1)
            {
                comboBox_jsjzh.SelectedIndex = 1;
                int stationidtt = Convert.ToInt32(comboBox_jsjzh.SelectedValue);

                myhis.getHead(comboBox_jsjsq, stationidtt);


            }
            label6.Text = label7.Text = "0";
        }
        #endregion
        private void InitDataSet(DataTable dt)
        {
            pageSize = 30;      //设置页面行数
            nMax = dtInfo.Rows.Count;

            pageCount = (nMax / pageSize);    //计算出总页数

            if ((nMax % pageSize) > 0) pageCount++;

            pageCurrent = 1;    //当前页数从1开始
            nCurrent = 0;       //当前记录数从0开始

            LoadData();
        }
        private void LoadData()
        {
            int nStartPos = 0;   //当前页面开始记录行
            int nEndPos = 0;     //当前页面结束记录行

            DataTable dtTemp = dtInfo.Clone();   //克隆DataTable结构框架
            int hang = dtInfo.Rows.Count;
            if (hang == 0)
            {
                cap_sum.CaptionTitle = "共" + "0" + "页";
                cap_dangqian.CaptionTitle = "第" + "0" + "页";
                isnulldata = true;
                dataGridViewMian.DataSource = dtTemp;
            }
            else
            {
                isnulldata = false;
                if (pageCurrent == pageCount)
                    nEndPos = nMax;
                else
                    nEndPos = pageSize * pageCurrent;

                nStartPos = nCurrent;

                cap_sum.CaptionTitle = "共" + pageCount.ToString() + "页";
                cap_dangqian.CaptionTitle = "第" + Convert.ToString(pageCurrent) + "页";

                label6.Text = Convert.ToString(pageCurrent);
                label7.Text = pageCount.ToString();
                //从元数据源复制记录行
                for (int i = nStartPos; i < nEndPos; i++)
                {
                    dtTemp.ImportRow(dtInfo.Rows[i]);
                    nCurrent++;
                }
                //bdsInfo.DataSource = dtTemp;
                //bdnInfo.BindingSource = bdsInfo;
                dataGridViewMian.DataSource = dtTemp;
            }
        }
        private void button_query_Click(object sender, EventArgs e)
        {

            //判断空值label6
            if (comboBox_ksjzh.SelectedValue == null ||
                comboBox_ksjsq.SelectedValue == null ||
                comboBox_jsjzh.SelectedValue == null ||
                comboBox_jsjsq.SelectedValue == null ||
                comboBox_bumen.SelectedValue == null)
            {
                MessageBox.Show("所需填写条件有空值，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            #region 点击查询按钮
            cap_dangqian.Visible = true;
            cap_sum.Visible = true;
            string kssj = dtpStartTime.Value.ToShortDateString();
            string jssj = dtpEndTime.Value.ToShortDateString();
            string ksjz = comboBox_ksjzh.SelectedValue.ToString();
            string kstt = comboBox_ksjsq.SelectedValue.ToString();
            string jsjz = comboBox_jsjzh.SelectedValue.ToString();
            string jstt = comboBox_jsjsq.SelectedValue.ToString();
            string depid = comboBox_bumen.SelectedValue.ToString();
            string name = textBox_name.Text.Trim();

            string yue1 = dtpStartTime.Value.Month.ToString();
            string date1 = dtpStartTime.Value.Day.ToString();
            string hour1 = dtpStartTime.Value.Hour.ToString();
            string min1 = dtpStartTime.Value.Minute.ToString();
            string sound1 = dtpStartTime.Value.Second.ToString();
            if (yue1.Length == 1)
            {
                yue1 = "0" + yue1;
            }
            if (date1.Length == 1)
            {
                date1 = "0" + date1;
            }
            if (hour1.Length == 1)
            {
                hour1 = "0" + hour1;
            }
            if (min1.Length == 1)
            {
                min1 = "0" + min1;
            }
            if (sound1.Length == 1)
            {
                sound1 = "0" + sound1;
            }






            string yue2 = dtpEndTime.Value.Month.ToString();
            string date2 = dtpEndTime.Value.Day.ToString();
            string hour2 = dtpEndTime.Value.Hour.ToString();
            string min2 = dtpEndTime.Value.Minute.ToString();
            string sound2 = dtpEndTime.Value.Second.ToString();

            if (yue2.Length == 1)
            {
                yue2 = "0" + yue2;
            }
            if (date2.Length == 1)
            {
                date2 = "0" + date2;
            }
            if (hour2.Length == 1)
            {
                hour2 = "0" + hour2;
            }
            if (min2.Length == 1)
            {
                min2 = "0" + min2;
            }
            if (sound2.Length == 1)
            {
                sound2 = "0" + sound2;
            }

            //2008-05-22 10:14:03
            kssj = dtpStartTime.Value.Year + "-" + yue1 + "-" + date1 + " " + hour1 + ":" + min1 + ":" + sound1;
            jssj = dtpEndTime.Value.Year + "-" + yue2 + "-" + date2 + " " + hour2 + ":" + min2 + ":" + sound2;
            #region 检测
            if (dtpStartTime.Text.Trim() == "" || dtpEndTime.Text.Trim() == "")
            {
                MessageBox.Show("对不起, 开始和结束时间都不能为空！");
                return;
            }
            if (DateTime.Compare(DateTime.Parse(dtpStartTime.Text), DateTime.Parse(dtpEndTime.Text)) > 0)
            {
                MessageBox.Show("对不起, 开始时间不能大于结束时间！");
                return;
            }
            if (ksjz == jsjz && kstt == jstt)
            {
                MessageBox.Show("对不起, 开始和结束地址不能为同一地址！");
                return;
            }

            if (DateTime.Compare(DateTime.Parse(dtpStartTime.Text), System.DateTime.Now) > 0)
            {
                MessageBox.Show("对不起, 开始时间不能大于今天！");
                return;
            }

            if (DateTime.Compare(DateTime.Parse(dtpEndTime.Text), System.DateTime.Now) > 0)
            {
                MessageBox.Show("对不起, 结束时间不能大于今天！");
                return;
            }
            #endregion
            #region 查询
            if (ksjz.Length == 0 || kstt.Length == 0 || jsjz.Length == 0 || jstt.Length == 0)
            {

            }
            else
            {
            dtInfo = myhis.GetHisInOutTime(kssj, jssj, ksjz, kstt, jsjz, jstt, depid, name);

            InitDataSet(dtInfo);
            }

          
            //dataGridViewMian.Columns[0].FillWeight = 50;
            //dataGridViewMian.Columns[1].FillWeight = 50;

            //dataGridViewMian.Columns[2].FillWeight = 100;
            //dataGridViewMian.Columns[3].FillWeight = 100;
            //dataGridViewMian.Columns[4].FillWeight = 100;
            //dataGridViewMian.Columns[5].FillWeight = 150;

            ////dataGridViewMian.Columns[6].FillWeight = 150;
            //dataGridViewMian.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            //dataGridViewMian.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            #endregion



            #endregion
        }

        private void buttonCaptionPanel1_Click(object sender, EventArgs e)
        {
            if (isnulldata)
            {

            }
            else
            {
                 pageCurrent--;
                if (pageCurrent <= 0)
                {
                    //MessageBox.Show("已经是第一页，请点击“下一页”查看！");
                    return;
                }

                if (pageCurrent > pageCount)
                {
                    pageCurrent = Convert.ToInt32(label6.Text) - 1;
                    nCurrent = pageSize * pageCurrent - pageSize;
                    LoadData();
                }
                else
                {
                    nCurrent = pageSize * (pageCurrent - 1);
                    LoadData();
                }
            }
            //上一页
           
        }

        private void buttonCaptionPanel2_Click(object sender, EventArgs e)
        {
            // 下一页
            if (isnulldata)
            { }
            else
            {
                pageCurrent++;
                if (pageCurrent <= 0)
                {
                    //MessageBox.Show("已经是第一页，请点击“下一页”查看！");
                    pageCurrent = 2;
                }
                if (pageCurrent > pageCount)
                {
                    //MessageBox.Show("已经是最后一页，请点击“上一页”查看！");
                    pageCurrent = pageCount;

                    return;
                }
                else
                {
                    nCurrent = pageSize * (pageCurrent - 1);
                }
                LoadData();
            }
          

        }

        

        private void comboBox_ksjzh_DropDownClosed(object sender, EventArgs e)
        {
            int stationid = Convert.ToInt32(comboBox_ksjzh.SelectedValue);

            myhis.getHead(comboBox_ksjsq, stationid);
          
        }

        private void comboBox_jsjzh_DropDownClosed(object sender, EventArgs e)
        {

            int stationid1 = Convert.ToInt32(comboBox_jsjzh.SelectedValue);
            
            myhis.getHead(comboBox_jsjsq, stationid1);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13)
            {
                
                e.Handled = true;//表示已经处理过该KeyPress事件
            }
        }

        private void buttonCaptionPanel3_Click(object sender, EventArgs e)
        {
            //跳至多少页
            if (textBox1.Text.Length > 0)
            {
                int ye = Convert.ToInt32(textBox1.Text);
                int total = Convert.ToInt32(label7.Text);
                if (total == 0)
                { }
                else
                {
                    #region 先判断是否页数是不是超出了总共的页数
                    if (ye <= 0)
                    {

                    }
                    else
                    {
                        if (ye > total)
                        {
                            //跳到最后一页 pageCurrent
                            nCurrent = pageSize * (total - 1);
                            pageCurrent = total;

                            LoadData();

                        }
                        else
                        {//跳到那一页
                            nCurrent = pageSize * (ye - 1);
                            pageCurrent = ye;

                            LoadData();

                        }
                    }
                    #endregion
                }
            }
	 
        }

        private void buttonCaptionPanel3_Load(object sender, EventArgs e)
        {

        }

        
    }
}
