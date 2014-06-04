using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NMainRun.Graphics.DPic;
namespace KJ128NMainRun.Graphics.Expert
{
    public partial class A_frmDpicDialog : Form
    {
        KJ128NDBTable.Graphics_DpicBLL dpicbll = new KJ128NDBTable.Graphics_DpicBLL();
        DataTable FileDt;

        private string _FileID;

        public string FileID
        {
            get { return _FileID; }
        }

        private string _FileName;

        public string FileName
        {
            get { return _FileName; }
        }

        public A_frmDpicDialog()
        {
            InitializeComponent();
        }

        private void frmDpicDialog_Load(object sender, EventArgs e)
        {
            LoadFileDt();
        }

        private void LoadFileDt()
        {
            trvDback.Nodes.Clear();
            FileDt = dpicbll.GetAllBackPicFile();
            for (int i = 0; i < FileDt.Rows.Count; i++)
            {
                trvDback.Nodes.Add(FileDt.Rows[i][0].ToString(), FileDt.Rows[i][1].ToString());
            }
        }

        private Image BytesToImage(byte[] buffer)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(buffer);
            return Image.FromStream(ms);
        }

        private Image GetImageFromDT(string filename)
        {
            for (int i = 0; i < FileDt.Rows.Count; i++)
            {
                if (FileDt.Rows[i][1].ToString() == filename)
                {
                    return BytesToImage((byte[])(FileDt.Rows[i][2]));
                }
            }
            return null;
        }

        private void trvDback_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.picDback.Image = GetImageFromDT(trvDback.SelectedNode.Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.trvDback.SelectedNode != null)
            {
                this._FileID = trvDback.SelectedNode.Name;
                this._FileName = trvDback.SelectedNode.Text;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("您尚未选择任何底图...", "提示", MessageBoxButtons.OK);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
