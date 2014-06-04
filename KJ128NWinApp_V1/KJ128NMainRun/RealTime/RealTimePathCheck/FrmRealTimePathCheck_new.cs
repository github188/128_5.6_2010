using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using PrintCore;
using KJ128NInterfaceShow;

namespace KJ128NMainRun.RealTime.RealTimePathCheck
{
    public partial class FrmRealTimePathCheck_new : KJ128NMainRun.FromModel.FrmModel
    {
        public FrmRealTimePathCheck_new()
        {
            InitializeComponent();
            BandingTimeInterval();
            tid = comboBox_work.SelectedValue.ToString();
            tree(tid);
            timer_con.Interval = RefReshTime._rtTime;
            timer_con.Start();
        }
        private DataTable dtinfo;
        private string tid;
        private PathInfoBll bll = new PathInfoBll();
        private HisPathCheckBll hbll = new HisPathCheckBll();
        private string pathNo;
        private void BandingTimeInterval()
        {
            DataTable dt = hbll.GetTimeInterval();

            if (dt != null && dt.Rows.Count > 0)
            {

                comboBox_work.DataSource = null;
                DataRow dr = dt.NewRow();
                dr[0] = 0;
                dr[1] = "所有";
                dt.Rows.InsertAt(dr, 0);

                //cmb.DataSource = ds.Tables[0];
                //cmb.DisplayMember = "TerritorialName";
                //cmb.ValueMember = "TerritorialID";

                comboBox_work.DataSource = dt;
                comboBox_work.DisplayMember = "IntervalName";
                comboBox_work.ValueMember = "ID";

                 
            }
        }

        #region 树

        private void tree(string tid)
        {

             
            DataTable ds = bll.GetTreeDtReal(tid);
            LoadTree(treeViewControl1, ds, "人", true);



        }

        #endregion
        private void SetDataRow(ref DataRow dr, int id, string name, int parentid, bool isChild, bool isUserNum, int num)
        {
            dr[0] = id;
            dr[1] = name;
            dr[2] = parentid;
            dr[3] = isChild;
            dr[4] = isUserNum;
            dr[5] = num;
        }
        private void LoadTree(DegonControlLib.TreeViewControl tvc, DataTable dsTemp, string strName, bool blCount)
        {
            if (tvc.Nodes.Count > 0)
            {
                tvc.Nodes.Clear();
            }
            DataTable dt;

            if (dsTemp != null && dsTemp.Rows.Count > 0)
            {
                dt = dsTemp;
            }
            else
            {
                dt = tvc.BuildMenusEntity();
            }

            DataRow dr = dt.NewRow();
            SetDataRow(ref dr, 0, "所有", -1, false, blCount, 0);
            dt.Rows.Add(dr);

            tvc.DataSouce = dt;
            tvc.LoadNode(strName);


            tvc.ExpandAll();
            tvc.SelectedNode = tvc.Nodes[0];
            tvc.SetSelectNodeColor();
        }

        private void query_Click(object sender, EventArgs e)
        {
            #region 重新绑定树

            tid = comboBox_work.SelectedValue.ToString();
            tree(tid);
            #endregion
            #region 绑定中间主表格
            string codeid;
            string name;
            string gongz;

            if (textBox_send.Text.Length > 6)
            {
                MessageBox.Show("请输入正确的标示卡号");
                return;
            }
            if (textBox_send.Text.Length > 0)
            {
                codeid = textBox_send.Text.Trim();
            }
            else
            {
                codeid = "0";
            }
            if (textBox_name.Text.Length > 0)
            {
                name = textBox_name.Text.Trim();
            }
            else
            {
                name = "0";
            }
            //string pathno=treeViewControl1.Node

            gongz = comboBox_work.SelectedValue.ToString();
          
           
            if (pathNo != "")
            {
                dtinfo = bll.GetEmpReal_by(codeid, name, gongz, pathNo);
            }
            else
            {
                dtinfo = bll.GetEmpReal_by(codeid, name, gongz, "0");
            }

            dataGridViewKJ1281.DataSource = dtinfo;


            #endregion

        }

        private void treeViewControl1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Node.Nodes.Count < 1)
            {
                ////MessageBox.Show(e.Node.Name);

                 pathNo = e.Node.Name;
                // MessageBox.Show(pathNo);

              
                 string gongz = comboBox_work.SelectedValue.ToString();
                //DataTable dt = bll.GetEmp_by("0", "0", gongz, kssj.ToString(), jssj.ToString(), pathNo);

                 dtinfo = bll.GetEmpReal_by("0", "0", gongz, pathNo);
                 
                 dataGridViewKJ1281.DataSource = dtinfo;
               // dtinfo = bll.GetEmp_by("0", "0", gongz, kssj.ToString(), jssj.ToString(), pathNo);
                //InitDataSet(dtinfo);

                //int dtnum = dtinfo.Rows.Count;
                //lblCounts.Text = "共" + dtnum + "条信息";
                //改变刷新的条件

            }
            else
            {
                //点所有的
              
                string gongz = comboBox_work.SelectedValue.ToString();
                //DataTable dt = bll.GetEmp_by("0", "0", gongz, kssj.ToString(), jssj.ToString(), pathNo);


                dtinfo = bll.GetEmpReal_by("0", "0", gongz, "0");

                dataGridViewKJ1281.DataSource = dtinfo;

                //int dtnum = dtinfo.Rows.Count;
                //lblCounts.Text = "共" + dtnum + "条信息";


            }
        }

        private void checkBox_realtime_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_realtime.Checked)
            {
                timer_con.Start();
            }
            else
            {
                timer_con.Stop();
            }

        }

        private void timer_con_Tick(object sender, EventArgs e)
        {
            #region shuaxin

            query_Click(null, null);

            #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox_send.Text = "";
            textBox_name.Text = "";
            comboBox_work.SelectedIndex = 0;
            query_Click(null, null);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dataGridViewKJ1281, "实时巡检");
        }

        private void textBox_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

    }
}
