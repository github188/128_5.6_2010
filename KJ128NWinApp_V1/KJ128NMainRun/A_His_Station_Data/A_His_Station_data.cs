using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NMainRun.A_His_Station_Data
{
    public partial class A_His_Station_data : FromModel.FrmModel
    {
        #region[声明、定义]
        private KJ128NDBTable.A_His_Station.A_His_StationBLL bll = new KJ128NDBTable.A_His_Station.A_His_StationBLL();
        #endregion

        public A_His_Station_data()
        {
            InitializeComponent();
            base.btnAdd.Hide();
            base.btnSelectAll.Hide();
            base.btnLaws.Hide();
            base.btnDelete.Hide();
            loadTree();
            //bindcmbslect();
            lblCounts.Text = "";
            cmbSelectCounts.SelectedIndex = 0;
            int page;
            if (empradio.Checked)
            {
                page = int.Parse(bll.His_Station_Info(true, 0, 1, 1, "1=1").Rows[0][0].ToString()) / int.Parse(cmbSelectCounts.Text);
            }
            else
            {
                page = int.Parse(bll.His_Station_Info(true, 1, 1, 1, "1=1").Rows[0][0].ToString()) / int.Parse(cmbSelectCounts.Text);
            }
            lblSumPage.Text = @"/"+page.ToString()+"页";
            //cmbSelectCounts.Text = "20";
            beginTime.Value = Convert.ToDateTime(DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd HH:mm:ss"));
            
            selectindex();
            //cmbSelectCounts.Text = 40;
        }


        private void loadTree()
        {
            DetyTree.Nodes.Clear();
            if (empradio.Checked)
            {
                DetyTree.DataSouce = bll.DeptTree(0);
                DetyTree.LoadNode("人");
                lbl.Text = "姓 名";
            }
            else
            {
                DetyTree.DataSouce = bll.DeptTree(1);
                DetyTree.LoadNode("台");
                lbl.Text = "设 备";
            }
            DetyTree.ExpandAll();
        }

        private void empradio_CheckedChanged(object sender, EventArgs e)
        {
            loadTree();
            //bindblbcount();
            selectindex();
        }


        //private void bindcmbslect()
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        int j=(i+1)*20;
        //        cmbSelectCounts.Items.Add(j);
        //    }
        //}


        private void loaddgrd(int size, int index)
        {
            if (empradio.Checked)
            {
                string str = " emp.EmpName like ('%" + nameText.Text + "%') and hi.InStationHeadTime>= '" + beginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and hi.OutStationHeadTime<='"+endtime.Value.ToString("yyyy-MM-dd HH:mm:ss")+"'";
                if (DetyTree.SelectedNode != null)
                {
                    if (DetyTree.SelectedNode.Name != "0")
                    {
                        str = str + " and de.DeptID=" + DetyTree.SelectedNode.Name;
                    }
                }
                if (CodeText.Text.Trim() != "")
                {
                    str = str + " and hi.CodeSenderAddress=" + CodeText.Text;
                }
                if (sendText.Text.Trim() != "")
                {
                    str = str + " and hi.StationAddress=" + sendText.Text;
                }
                if (readText.Text.Trim() != "")
                {
                    str = str + " and hi.StationHeadAddress=" + readText.Text;
                }
                dgrd.DataSource = bll.His_Station_Info(false, 0, size, index, str);
                dgrd.Columns[0].Visible = false;
                lblCounts.Text = "符合条件的有" + bll.His_Station_Info(true, 0, 1, 1, str).Rows[0][0].ToString() + "记录";
            }
            else
            {
                string str = " eq.EquName like ('%" + nameText.Text + "%')  and hi.InStationHeadTime>= '" + beginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and hi.OutStationHeadTime<='" + endtime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                if (DetyTree.SelectedNode != null)
                {
                    if (DetyTree.SelectedNode.Name != "0")
                    {
                        str = str + " and de.DeptID=" + DetyTree.SelectedNode.Name;
                    }
                }
                if (CodeText.Text.Trim() != "")
                {
                    str = str + " and hi.CodeSenderAddress=" + CodeText.Text;
                }
                if (sendText.Text.Trim() != "")
                {
                    str = str + " and hi.StationAddress=" + sendText.Text;
                }
                if (readText.Text.Trim() != "")
                {
                    str = str + " and hi.StationHeadAddress=" + readText.Text;
                }
                dgrd.DataSource = bll.His_Station_Info(false, 1, size, index, str);
                dgrd.Columns[0].Visible = false;
                lblCounts.Text = "符合条件的有" + bll.His_Station_Info(true, 1, 1, 1, str).Rows[0][0].ToString() + "记录";
            }

        }

  

        private void selectindex()
        {
            loaddgrd(int.Parse(cmbSelectCounts.Text), int.Parse(lblPageCounts.Text));
        }

        private void btnUpPage_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblPageCounts.Text) > 1)
            {
                int j=int.Parse(lblPageCounts.Text)-1;
                lblPageCounts.Text=j.ToString();
                selectindex();
            }

        }

        private void btnDownPage_Click(object sender, EventArgs e)
        {
            int page;
            if(empradio.Checked)
            {
                page = int.Parse(bll.His_Station_Info(true, 0, 1, 1, "1=1").Rows[0][0].ToString()) / int.Parse(cmbSelectCounts.Text);
            }
            else
            {
                page=int.Parse(bll.His_Station_Info(true, 1, 1, 1, "1=1").Rows[0][0].ToString())/int.Parse(cmbSelectCounts.Text);
            }
            if (int.Parse(lblPageCounts.Text) < page+1)
            {
                int j = int.Parse(lblPageCounts.Text)+ 1;
                lblPageCounts.Text = j.ToString();
                selectindex();
            }
        }

        private void txtSkipPage_Enter(object sender, EventArgs e)
        {
             
        }

        private void cmbSelectCounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelectCounts.Text != "")
            {
                loaddgrd(int.Parse(cmbSelectCounts.Text), 1);
            }
            int page;
            if (empradio.Checked)
            {
                page = int.Parse(bll.His_Station_Info(true, 0, 1, 1, "1=1").Rows[0][0].ToString()) / int.Parse(cmbSelectCounts.Text);
            }
            else
            {
                page = int.Parse(bll.His_Station_Info(true, 1, 1, 1, "1=1").Rows[0][0].ToString()) / int.Parse(cmbSelectCounts.Text);
            }
            lblSumPage.Text =@"/"+ page.ToString() + "页";
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            if (beginTime.Text.Trim() == "" || endtime.Text.Trim() == "")
            {
                MessageBox.Show("开始和结束时间都不能为空！");
                return;
            }
            if (DateTime.Compare(DateTime.Parse(beginTime.Text), DateTime.Parse(endtime.Text)) > 0)
            {
                MessageBox.Show("开始时间不能大于结束时间，请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Czlt-2010-11-30 优化
            //if (DateTime.Compare(DateTime.Parse(beginTime.Text), DateTime.Parse(endtime.Text)) > 7)
            //{
            //    MessageBox.Show("开始时间和结束时间之间天数不能大于7天，请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (endtime.Value > DateTime.Now)
            {
                MessageBox.Show("结束时间不能大于当前时间，请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }

            selectindex();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CodeText.Text = "";
            nameText.Text = "";
            sendText.Text = "";
            readText.Text = "";
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgrd, "历史分站");
        }

        private void DetyTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectindex();
         
        }

        private void txtSkipPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int page;
                if (empradio.Checked)
                {
                    page = int.Parse(bll.His_Station_Info(true, 0, 1, 1, "1=1").Rows[0][0].ToString()) / int.Parse(cmbSelectCounts.Text);
                }
                else
                {
                    page = int.Parse(bll.His_Station_Info(true, 1, 1, 1, "1=1").Rows[0][0].ToString()) / int.Parse(cmbSelectCounts.Text);
                }
                if (txtSkipPage.Text != "")
                {
                    if (int.Parse(txtSkipPage.Text) < page + 2 && int.Parse(txtSkipPage.Text) > 0)
                    {
                        loaddgrd(int.Parse(cmbSelectCounts.Text), int.Parse(txtSkipPage.Text));
                    }
                }
            }
        }

        private void nameText_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
    }
}
