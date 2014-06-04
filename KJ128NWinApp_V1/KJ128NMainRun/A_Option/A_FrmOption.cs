using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJ128NMainRun.A_Option
{
    public partial class A_FrmOption : Wilson.Controls.Docking.DockContent
    {
        private OpenFileDialog openFileDialog = new OpenFileDialog();

        public A_FrmOption()
        {
            InitializeComponent();
        }

        private void SetComboBoxValue()
        {
            foreach (DataGridViewRow dr in this.dgvMain.Rows)
            {
                foreach (DataGridViewCell dc in dr.Cells)
                {
                    int value = Convert.ToInt32(dr.Cells["alterValue"].Value);

                    dr.Cells["AlertType"].Value = ((DataGridViewComboBoxCell)dr.Cells["AlertType"]).Items[value - 1].ToString();
                }


            }
        }

        private void Temp()
        {
            //构造Table
            DataTable dt = new DataTable("AlertTable");

            DataColumn dcName = new DataColumn("AlertName");
            DataColumn dcValue = new DataColumn("AlertValue");

            dt.Columns.Add(dcName);
            dt.Columns.Add(dcValue);

            DataRow dr1 = dt.NewRow();
            dr1["AlertName"] = "超员报警";
            dr1["AlertValue"] = 1;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["AlertName"] = "超时报警";
            dr2["AlertValue"] = 2;
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["AlertName"] = "超速报警";
            dr3["AlertValue"] = 3;
            dt.Rows.Add(dr3);

            //绑定数据

            this.dgvMain.DataSource = dt;


        }

        private void A_FrmOption_Load(object sender, EventArgs e)
        {
            Temp();
        }

        private void dgvMain_Sorted(object sender, EventArgs e)
        {
            SetComboBoxValue();
        }

        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                #region[单击效果]

                if (this.dgvMain.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    if (this.dgvMain.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "...")
                    {
                        if (dgvMain.Rows[e.RowIndex].Cells["AlertType"].Value != null && dgvMain.Rows[e.RowIndex].Cells["AlertType"].Value.ToString() == "自定义")
                        {
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                if (openFileDialog.FileName.Trim() != "")
                                {
                                    dgvMain.Rows[e.RowIndex].Cells["Path"].Value = openFileDialog.FileName;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("报警声音类别请选择自定义!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }


                    if (this.dgvMain.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "测试")
                    {
                        if (dgvMain.Rows[e.RowIndex].Cells["Path"].Value != null)
                        {
                            if (dgvMain.Rows[e.RowIndex].Cells["Path"].Value.ToString().Trim() != "")
                            {
                                string path = dgvMain.Rows[e.RowIndex].Cells["Path"].Value.ToString().Trim();
                                MessageBox.Show(path, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("报警声音路径为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("报警声音路径为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }

                #endregion
            }
        }

        private void dgvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMain.CurrentRow != null && dgvMain.CurrentRow.Index > -1)
            {
                if (dgvMain.CurrentRow.Cells["AlertType"].Value != null)
                {
                    if (dgvMain.CurrentRow.Cells["AlertType"].Value.ToString() != "自定义")
                    {
                        dgvMain.CurrentRow.Cells["Path"].Value = String.Empty;
                    }
                }
            }
        }

        private void A_FrmOption_DockStateChanged(object sender, EventArgs e)
        {
            SetComboBoxValue();
        }
    }
}
