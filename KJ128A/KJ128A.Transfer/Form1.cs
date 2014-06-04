using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128A.DataSave;
using System.Data.SqlClient;

namespace KJ128A.Transfer
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        DataBaseSync db;
        private string strErr = string.Empty;
        

        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                db = new DataBaseSync();
                db.SyncComplete += new DataBaseSync.SyncCompleteEventHandler(db_SyncComplete);
                db.GuageEvent += new DataBaseSync.GuageEventHandler(db_GuageEvent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        void db_GuageEvent(int percent)
        {
            this.Text = percent.ToString();
        }

        void db_SyncComplete()
        {
            MessageBox.Show("ok");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.Close();
            db.InitCheckDB();
            db.DBSync();
            //try
            //{
            //    SqlConnection sql = new SqlConnection("server=.;database=kj128n;uid=sa;pwd=sa");
            //    sql.Open();
            //    if (!db.DBSync(out strErr))
            //    {
            //        MessageBox.Show(strErr);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //    throw;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.InitCheckDB();
            db.DBSync();
        }
    }
}