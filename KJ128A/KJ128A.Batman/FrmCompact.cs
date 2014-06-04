using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using KJ128A.DataSave;

namespace KJ128A.Batman
{
    public partial class FrmCompact : Form
    {
        public FrmCompact()
        {
            InitializeComponent();
        }

        Thread t = null;
        private void FrmCompact_Load(object sender, EventArgs e)
        {
            t = new Thread(this.StartPbar);
            t.Name = "StartPbar";
            t.Start();
        }

        private delegate void SetProgressBarCallback();

        private void SetProgressBar()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    SetProgressBarCallback d = new SetProgressBarCallback(SetProgressBar);
                    Invoke(d);
                }
                else
                {
                    label1.AutoSize = true;
                    label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
                    label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    label1.ForeColor = System.Drawing.Color.Red;
                    label1.Location = new System.Drawing.Point(50, 45);
                    label1.Name = "label1";
                    label1.Size = new System.Drawing.Size(231, 14);
                    label1.Text = "正在压缩修复数据库，请稍后。。。";
                    label1.Visible = true;

                    AccessBase ab = new AccessBase();
                    
                    string[] strFile = ab.Compact();
                    string[] strFile1 = ab.Compact1();

                    progressBar1.Visible = true;
                    progressBar1.Minimum = 1;
                    progressBar1.Maximum = strFile1.Length + strFile.Length + 1;
                    progressBar1.Value = 1;
                    progressBar1.Step = 1;
                    for (int i = 0; i < strFile.Length; i++)
                    {
                        string strfilenameTemp = strFile[i].Replace(".mdb", ".ldb");
                        if (File.Exists(strfilenameTemp))
                        {
                            File.Delete(strfilenameTemp);
                        }
                        try
                        {
                            ab.Compact(strFile[i]);
                        }
                        catch { }
                        progressBar1.PerformStep();
                        Thread.Sleep(100);
                    }
                    for (int i = 0; i < strFile1.Length; i++)
                    {
                        string strfilenameTemp = strFile1[i].Replace(".mdb", ".ldb");
                        if (File.Exists(strfilenameTemp))
                        {
                            File.Delete(strfilenameTemp);
                        }
                        try
                        {
                            ab.Compact(strFile1[i]);
                        }
                        catch { }
                        progressBar1.PerformStep();
                        Thread.Sleep(100);
                    }
                    if (ab != null)
                    { ab = null; }

                    this.Hide();

                    FrmMain f = new FrmMain();
                    f.Show();
                    f = null;
                }
            }
            catch { }
        }

        private void StartPbar()
        {

            SetProgressBar();

            t.Abort();
        }
    }
}
