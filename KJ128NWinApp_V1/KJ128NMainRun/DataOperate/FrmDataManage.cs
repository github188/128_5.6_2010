using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.IO;
using KJ128NDataBase;
using Shine.Logs;
using Shine.Logs.LogType;

namespace KJ128NMainRun.DataOperate
{
    public partial class FrmDataManage : Wilson.Controls.Docking.DockContent
    {
        private Thread myThread;
        // dbName 操作的数据库名 serverIp 数据库所在机器的ip path传值使用
        private string dbName = "kj128n",serverIp="127.0.0.1",path = "";
        private int WM_NCLBUTTONDOWN = 0x00A1;
        private int HTCLOSE = 20;

        #region [ 构造函数 ]

        public FrmDataManage()
        {
            InitializeComponent();
            Init();                                                 // 初始化
            Control.CheckForIllegalCrossThreadCalls = false;        // 不捕获对错误线程的调用
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        #endregion

        #region [ 方法 ]

        #region [ 方法: 初始化 ]

        private void Init()
        {
            txtPath.Text = @"D:\database\backup";          // 初始化备份文件默认文件夹
            // 文件夹不存在则创建
            if (!Directory.Exists(@"D:\database\backup"))
            {
                Directory.CreateDirectory(@"D:\database\backup");
            }
            lblBackupPath.Visible = false;
            lblFileName.Visible = false;
        }

        #endregion

        #region [ 方法: 窗体不可拖动 ]

        protected override void WndProc(ref   Message msg)
        {
            if (msg.Msg == WM_NCLBUTTONDOWN)
                if (msg.WParam.ToInt32() != HTCLOSE)
                    return;
            base.WndProc(ref   msg);
        }

        #endregion

        #region [ 方法: 执行操作时界面效果 ]

        /// <summary>
        /// 执行操作时界面效果
        /// </summary>
        /// <param name="state">执行操作时界面状态 0无操作 1备份 2还原</param>
        private void RunState(int state)
        {
            switch (state)
            {
                case 0:
                    // 按钮状态
                    btnBackup.Enabled = true;
                    btnRevert.Enabled = true;
                    btnScan.Enabled = true;
                    lblInfo.Visible = false;
                    lbl.Visible = false;
                    pBarDB.Visible = false;
                    break;
                case 1:
                    // 按钮状态
                    pBarDB.Value = 0;
                    btnBackup.Enabled = false;
                    btnRevert.Enabled = false;
                    btnScan.Enabled = false;

                    lblBackupPath.Visible = false;
                    lblFileName.Visible = false;
                    linklblScan.Visible = false;        // 浏览按钮状态
                    lblInfo.Visible = true;
                    lblInfo.Text = "数据库备份进度";      // 操作提示信息
                    break;
                case 2:
                    // 按钮状态
                    pBarDB.Value = 0;
                    btnBackup.Enabled = false;
                    btnRevert.Enabled = false;
                    btnScan.Enabled = false;

                    lblBackupPath.Visible = false;
                    lblFileName.Visible = false;
                    linklblScan.Visible = false;        // 浏览按钮状态
                    lblInfo.Visible = true;
                    lblInfo.Text = "数据库还原进度";      // 操作提示信息
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region [ 方法: 备份、还原 ]

        /// <summary>
        /// 执行还原
        /// </summary>
        private void RestoreThread()
        {
            if (DataOperateBLL.RestoreDB(dbName, path, serverIp, "sa", "sa",pBarDB))
            {
                MessageBox.Show("还原成功");
            }
            RunState(0);
        }

        /// <summary>
        /// 执行备份
        /// </summary>
        private void BackupThread()
        {
            if (DataOperateBLL.BackUPDB(dbName, path, serverIp, "sa", "sa", pBarDB))
            {
                string p = txtPath.Text;
                p = p.Length > 24 ? (p.Substring(0, 24) + "...") : p;
                lblBackupPath.Text = p;
                lblFileName.Text = "文件名为 " + txtPath.Tag.ToString();
                if (MessageBox.Show(@"您已经成功将数据库备份到" + "\r\n" + p + "\r\n文件名为 " + txtPath.Tag.ToString() + "\r\n是否打开文件夹",
                    "提示信息", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", "/select,"+txtPath.Text+"\\" + txtPath.Tag.ToString());
                }
            }
            RunState(0);
        }

        #endregion

        #region [ 方法: 显示进度数百分比 ]

        private void DisplayBarValue()
        {
            lbl.Visible = true;                     // 显示进度百分比
            Thread th = new Thread(BarValue);
            th.Start();
        }

        private void BarValue()
        {
            
            while (pBarDB.Value < 100)
            {
                lbl.Text = "已完成 " + pBarDB.Value + "%";
                Thread.Sleep(1000);
            }
            lbl.Text = "完成";
        }

        #endregion
        
        #endregion

        #region [ 事件 ]

        #region [ 事件: 备份选择文件夹 ]

        private void btnScan_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog s = new FolderBrowserDialog();
            if (s.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = s.SelectedPath;
            }
        }

        #endregion

        #region [ 事件: 备份 ]

        private void btnBackup_Click(object sender, EventArgs e)
        {
            // 将备份的文件名保存在txtPath.Tag中
            txtPath.Tag = dbName + DateTime.Now.ToString("[yyyyMMdd-HHmm]");

            // 备份文件路径
            if (txtPath.Tag == null) return;
            path = txtPath.Text + "\\" + txtPath.Tag.ToString();

            // 备份时界面效果
            RunState(1);
            DisplayBarValue();                  // 显示进度百分比
            // 创建线程执行备份
            myThread = new Thread(new ThreadStart(BackupThread));
            myThread.Start();

            //存入日志
            LogSave.Messages("[FrmDataManage]", LogIDType.UserLogID, "数据库备份，备份日志路径为：" + path);
        }

        #endregion

        #region [ 事件: 备份完后 浏览备份文件 ]

        private void linklblScan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 打开文件夹 并默认选中备份后的文件
            if (linklblScan.Tag != null)
            {
                System.Diagnostics.Process.Start("explorer.exe", "/select," + linklblScan.Tag.ToString() + "\\" + txtPath.Tag.ToString());
            }
        }

        #endregion

        #region [ 事件: 还原 ]

        private void btnRevert_Click(object sender, EventArgs e)
        {
            #region [ 浏览选择文件 ]

            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = @"D:\database\backup"; // 默认路径为默认备份路径
            if (o.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = o.FileName;
            }
            else
            {
                return;
            }

            #endregion

            #region [ 还原数据库存在时是否先备份 ]

            // 数据库存在时提示是备份否强制还原
            ArrayList array = DataOperateBLL.GetDbList(serverIp, "sa", "sa");
            foreach (object obj in array)
            {
                if (obj.ToString().ToLower() == dbName.ToLower())
                {
                    DialogResult msgType = MessageBox.Show("数据库 ["
                        + dbName
                        + "] 已存在,还原前是否先备份", "提示信息", MessageBoxButtons.YesNoCancel);
                    // 备份
                    if (msgType == DialogResult.Yes)
                    {
                        // 备份前选择文件夹
                        FolderBrowserDialog s = new FolderBrowserDialog();
                        if (s.ShowDialog() == DialogResult.OK)
                        {
                            txtPath.Text = s.SelectedPath;
                        }
                        else
                        {
                            return;
                        }

                        // 备份
                        btnBackup_Click(sender, e);
                        return;
                    }// 取消还原
                    else if (msgType == DialogResult.Cancel)
                    {
                        lblInfo.Visible = false;
                        return;
                    }
                }
            }

            #endregion

            // 还原文件路径及文件名
            path = txtFile.Text;

            // 还原时界面效果
            RunState(2);
            DisplayBarValue();              // 显示进度百分比
            // 创建线程执行还原
            myThread = new Thread(RestoreThread);
            myThread.Start();

            //存入日志
            LogSave.Messages("[FrmDataManage]", LogIDType.UserLogID, "还原数据库，还原文件路径及文件名为：" + path);
        }

        #endregion

        #region [ 事件: 窗体关闭Closing ]

        private void FrmDataManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lblInfo.Text.Length > 2 && lblInfo.Visible)
            {
                if (MessageBox.Show("您确定要终止[" + lblInfo.Text.Substring(0, 5) + "]操作", "关闭提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    if (lblInfo.Text.Substring(0, 5) == "数据库备份")
                    { 
                        
                    }
                    // 未解决窗体关闭后 未备份完的数据库删除
                    //if (txtPath.Tag.ToString().IndexOf(" ") > 1)
                    //{
                    //    //return;
                    //}c
                    //try
                    //{	        
                    //    //File.Delete(path);
                    //}
                    //catch (Exception ex)
                    //{                       
                    //    MessageBox.Show(ex.Message.ToString());
                    //    throw;
                    //}
                }
            }
        }

        #endregion

        // 删除未备份完成的文件
        private void RemoveFile()
        {
            bool bl = true;
            while (bl)
            {
                Thread.Sleep(10000);
                try
                {
                    File.Delete(path);
                    bl = false;
                }
                catch (Exception ex)
                {
                    bl = true;
                }
            }
        }

        #endregion

        private void rtxt_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select," + txtPath.Text.ToString() + "\\" + txtPath.Tag.ToString());
        }
    }
}