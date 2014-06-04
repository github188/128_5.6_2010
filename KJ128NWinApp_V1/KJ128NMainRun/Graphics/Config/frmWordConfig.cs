using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NMainRun.Graphics.Config
{
    public partial class frmWordConfig : Form
    {
        private string _Key;

        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }

        public Label ConfigLab
        {
            get { return this.labWord; }
        }

        public frmWordConfig()
        {
            InitializeComponent();
        }

        public frmWordConfig(string StaticStr,string key)
        {
            InitializeComponent();
            this.ConfigLab.Text = StaticStr;
            this.Key = key;
        }

        private void frmWordConfig_Load(object sender, EventArgs e)
        {
            trvRealTime.Nodes.Add("qy", "按区域划分");
            trvRealTime.Nodes.Add("gz", "按工种划分");
            trvRealTime.Nodes.Add("bm", "按部门划分");
            trvRealTime.Nodes.Add("cf", "传输分站状态");
            LoadRealTimeInfo();
        }

        /// <summary>
        /// 重新载入实时事件
        /// </summary>
        private void LoadRealTimeInfo()
        {
            try
            {                
                    int allNum = int.Parse(new Graphics_RealTimeBLL().GetEmpInMineCounts());
                    this.labTitle.Text = "实时分布: 共有" + allNum.ToString() + "人下井";
                    List<string> list = new Graphics_AreaRealtimeBLL().GetAreaInfoAndEmpcount();
                    //trvRealTime.Nodes["qy"].Nodes.Clear();
                    //foreach (string s in list)
                    //{
                    //    trvRealTime.Nodes["qy"].Nodes.Add(s);
                    //}
                    if (list.Count >= trvRealTime.Nodes["qy"].Nodes.Count)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (trvRealTime.Nodes["qy"].Nodes.ContainsKey("qy" + i.ToString()))
                                trvRealTime.Nodes["qy"].Nodes["qy" + i.ToString()].Text = list[i];
                            else
                                trvRealTime.Nodes["qy"].Nodes.Add("qy" + i.ToString(), list[i]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < trvRealTime.Nodes["qy"].Nodes.Count; i++)
                        {
                            if (i < list.Count)
                                trvRealTime.Nodes["qy"].Nodes["qy" + i.ToString()].Text = list[i];
                            else
                                trvRealTime.Nodes["qy"].Nodes.RemoveAt(i);
                        }
                    }
                    list = new Graphics_RealTimeBLL().GetEmpWorkTypeNumRealTime(allNum);
                    //trvRealTime.Nodes["gz"].Nodes.Clear();
                    //foreach (string s in list)
                    //{
                    //    trvRealTime.Nodes["gz"].Nodes.Add(s);
                    //}
                    if (list.Count >= trvRealTime.Nodes["gz"].Nodes.Count)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (trvRealTime.Nodes["gz"].Nodes.ContainsKey("gz" + i.ToString()))
                                trvRealTime.Nodes["gz"].Nodes["gz" + i.ToString()].Text = list[i];
                            else
                                trvRealTime.Nodes["gz"].Nodes.Add("gz" + i.ToString(), list[i]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < trvRealTime.Nodes["gz"].Nodes.Count; i++)
                        {
                            if (i < list.Count)
                                trvRealTime.Nodes["gz"].Nodes["gz" + i.ToString()].Text = list[i];
                            else
                                trvRealTime.Nodes["gz"].Nodes.RemoveAt(i);
                        }
                    }
                    list = new Graphics_RealTimeBLL().GetRealTimeEmpNumByDept();
                    //trvRealTime.Nodes["bm"].Nodes.Clear();
                    //foreach (string s in list)
                    //{
                    //    trvRealTime.Nodes["bm"].Nodes.Add(s);
                    //}    
                    if (list.Count >= trvRealTime.Nodes["bm"].Nodes.Count)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (trvRealTime.Nodes["bm"].Nodes.ContainsKey("bm" + i.ToString()))
                                trvRealTime.Nodes["bm"].Nodes["bm" + i.ToString()].Text = list[i];
                            else
                                trvRealTime.Nodes["bm"].Nodes.Add("bm" + i.ToString(), list[i]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < trvRealTime.Nodes["bm"].Nodes.Count; i++)
                        {
                            if (i < list.Count)
                                trvRealTime.Nodes["bm"].Nodes["bm" + i.ToString()].Text = list[i];
                            else
                                trvRealTime.Nodes["bm"].Nodes.RemoveAt(i);
                        }
                    }

                    list = new Graphics_RealTimeBLL().GetAllStationState();
                    //trvRealTime.Nodes["bm"].Nodes.Clear();
                    //foreach (string s in list)
                    //{
                    //    trvRealTime.Nodes["bm"].Nodes.Add(s);
                    //}    
                    if (list.Count >= trvRealTime.Nodes["cf"].Nodes.Count)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (trvRealTime.Nodes["cf"].Nodes.ContainsKey("cf" + i.ToString()))
                                trvRealTime.Nodes["cf"].Nodes["cf" + i.ToString()].Text = list[i];
                            else
                                trvRealTime.Nodes["cf"].Nodes.Add("cf" + i.ToString(), list[i]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < trvRealTime.Nodes["cf"].Nodes.Count; i++)
                        {
                            if (i < list.Count)
                                trvRealTime.Nodes["cf"].Nodes["cf" + i.ToString()].Text = list[i];
                            else
                                trvRealTime.Nodes["cf"].Nodes.RemoveAt(i);
                        }
                    }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void trvRealTime_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.trvRealTime.SelectedNode.Name != "bm" && this.trvRealTime.SelectedNode.Name != "gz" && this.trvRealTime.SelectedNode.Name != "qy" && this.trvRealTime.SelectedNode.Name != "cf")
            {
                this.labWord.Text = this.trvRealTime.SelectedNode.Text;
                this.Key = this.trvRealTime.SelectedNode.Name;
            }
        }

        private void labTitle_Click(object sender, EventArgs e)
        {
            this.labWord.Text = this.labTitle.Text;
            this.trvRealTime.SelectedNode = null;
            this.Key = "zong";
        }

        

        private void btnUse_Click(object sender, EventArgs e)
        {
            if (this.labWord.Text != "")
            {
                this.labWord.Text = txtUserWord.Text;
                this.trvRealTime.SelectedNode = null;
                this.Key = "null";
            }
            else
            {
                MessageBox.Show("对不起,用于图形系统的文字不能为空", "提示", MessageBoxButtons.OK);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtUserWord.Text = "";
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.labWord.Font = dialog.Font;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.labWord.ForeColor = dialog.Color;
            }
        }

        private void txtUserWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.labWord.Text = txtUserWord.Text;
                if (this.labWord.Text != "")
                {
                    this.Key = "null";
                    this.trvRealTime.SelectedNode = null;
                    this.btnFont.Focus();
                }
                else
                {
                    MessageBox.Show("对不起,用于图形系统的文字不能为空", "提示", MessageBoxButtons.OK);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

       
    }
}
