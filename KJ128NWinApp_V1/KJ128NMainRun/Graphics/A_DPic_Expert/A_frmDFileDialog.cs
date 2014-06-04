using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NMainRun.Graphics.Config;
using KJ128NMainRun.Graphics.DPic;
namespace KJ128NMainRun.Graphics.Expert
{
    public partial class A_frmDFileDialog : Form
    {
        private Graphics_DpicBLL dpicbll = new Graphics_DpicBLL();

        private bool isSave = true;

        private string _SafeFileName;

        public string SafeFileName
        {
            get { return _SafeFileName; }
            set { _SafeFileName = value; }
        }

        public A_frmDFileDialog()
        {
            InitializeComponent();
        }

        public A_frmDFileDialog(bool issave)
        {
            InitializeComponent();
            this.isSave = issave;
            if (isSave)
            {
                this.Text = "另存为";
                this.btnSave.Text = "保存(&S)";
            }
            else
            {
                this.Text = "打开";
                this.btnSave.Text = "打开(&O)";
            }
        }

        private void frmFileDialog_Load(object sender, EventArgs e)
        {
            DataTable filedt = dpicbll.GetAllFileName();
            if (filedt != null)
            {
                for (int i = 0; i < filedt.Rows.Count; i++)
                {
                    lsvFile.Items.Add(filedt.Rows[i][0].ToString(), filedt.Rows[i][0].ToString(), 0);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text != "")
            {
                if (isSave)
                {
                    SafeFileName = txtFileName.Text;
                    if (new FileChanger().IsValidFileName(SafeFileName))
                    {
                        if (SafeFileName.Length >= 4)
                        {
                            if (SafeFileName == ".shz")
                            {
                                MessageBox.Show(SafeFileName + "\r\n上述文件名无效!", "另存为", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                if (SafeFileName.Substring(SafeFileName.Length - 4) != ".shz")
                                    SafeFileName = SafeFileName + ".shz";
                            }
                        }
                        else
                        {
                            SafeFileName = SafeFileName + ".shz";
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(SafeFileName + "\r\n上述文件名无效!", "另存为", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    SafeFileName = txtFileName.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void lsvFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvFile.SelectedItems.Count > 0)
                txtFileName.Text = lsvFile.SelectedItems[0].Text;
        }

        private void lsvFile_DoubleClick(object sender, EventArgs e)
        {
            if (this.lsvFile.SelectedItems.Count > 0)
            {
                this.txtFileName.Text = lsvFile.SelectedItems[0].Text;
                btnSave_Click(this, new EventArgs());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lsvFile_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.lsvFile.SelectedItems.Count > 0 && e.Button == MouseButtons.Right)
            {
                cmsItem.Show(lsvFile.PointToScreen(e.Location));
            }
        }

        private void tsmiChoose_Click(object sender, EventArgs e)
        {
            lsvFile_DoubleClick(this, new EventArgs());
        }

        private void tsmiDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确定要删除文件" + lsvFile.SelectedItems[0].Text + "？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dpicbll.RemoveFile(lsvFile.SelectedItems[0].Text);
                lsvFile.Items.Remove(lsvFile.SelectedItems[0]);
                lsvFile.SelectedItems.Clear();
                txtFileName.Text = "";
            }
        }

        private void txtFileName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

    }
}
