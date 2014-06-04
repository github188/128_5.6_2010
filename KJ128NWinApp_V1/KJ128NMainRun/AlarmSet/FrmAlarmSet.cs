using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using System.Media;
using Shine.Logs;
using Shine.Logs.LogType;

namespace KJ128NMainRun.AlarmSet
{
    public partial class FrmAlarmSet : Wilson.Controls.Docking.DockContent
    {
        private AlarmSetBLL asbll = new AlarmSetBLL();

        private OpenFileDialog ofd;

        /// <summary>
        /// 窗体加载时的超员人数
        /// </summary>
        private int intOverEmp = 0;

        #region [ 构造函数 ]

        public FrmAlarmSet()
        {
            InitializeComponent();
        }

        #endregion

        #region [ 事件: 窗体加载事件 ]

        private void FrmAlarmSet_Load(object sender, EventArgs e)
        {
            asbll.AlarmWaveType(cbAlarmWaveType1);
            asbll.AlarmWaveType(cbAlarmWaveType2);
            asbll.AlarmWaveType(cbAlarmWaveType3);
            asbll.AlarmWaveType(cbAlarmWaveType4);
            asbll.AlarmWaveType(cbAlarmWaveType5);
            asbll.AlarmWaveType(cbAlarmWaveType6);
            asbll.AlarmWaveType(cbAlarmWaveType7);

            asbll.LoadAlarmSetInfo(cbAlarmSet1, cbAlarmWaveType1, txtAlarmWavePath1, 1, bcpAlarmWavePath1, bcpTest1);
            asbll.LoadAlarmSetInfo(cbAlarmSet2, cbAlarmWaveType2, txtAlarmWavePath2, 2, bcpAlarmWavePath2, bcpTest2);
            asbll.LoadAlarmSetInfo(cbAlarmSet3, cbAlarmWaveType3, txtAlarmWavePath3, 3, bcpAlarmWavePath3, bcpTest3);
            asbll.LoadAlarmSetInfo(cbAlarmSet4, cbAlarmWaveType4, txtAlarmWavePath4, 4, bcpAlarmWavePath4, bcpTest4);
            asbll.LoadAlarmSetInfo(cbAlarmSet5, cbAlarmWaveType5, txtAlarmWavePath5, 5, bcpAlarmWavePath5, bcpTest5);
            asbll.LoadAlarmSetInfo(cbAlarmSet6, cbAlarmWaveType6, txtAlarmWavePath6, 6, bcpAlarmWavePath6, bcpTest6);
            asbll.LoadAlarmSetInfo(cbAlarmSet7, cbAlarmWaveType7, txtAlarmWavePath7, 7, bcpAlarmWavePath7, bcpTest7);

            asbll.LoadEmpCount(txtEmpCount);
            //获取加载时的超员人数
            intOverEmp = Convert.ToInt32(txtEmpCount.Text.Trim());

        }

        #endregion

        #region [ 超时报警 ]
        #region [ 事件: 超时报警声音类别设置 ]
        private void cbAlarmWaveType1_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType1.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath1.Enabled = false;
                    bcpAlarmWavePath1.Enabled = false;
                    bcpTest1.Enabled = false;
                    break;
                case 3:
                case 4:
                    txtAlarmWavePath1.Enabled = true;
                    bcpAlarmWavePath1.Enabled = true;
                    bcpTest1.Enabled = true;
                    break;
                default:
                    break;
            } 
        }
        #endregion

        #region [ 事件: 超时报警声音路径选择 Click ]
        private void bcpAlarmWavePath1_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath1.Text = ofd.FileName;
            }
        }
        #endregion

        #region  [ 事件: 超时报警声音测试 Click ]
        private void bcpTest1_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@txtAlarmWavePath1.Text.Trim());
                simpleSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAlarmWavePath1.Focus();
                txtAlarmWavePath1.SelectAll();
            }
        }
        #endregion
        #endregion

        #region [ 区域报警 ]
        #region [ 事件: 区域报警声音类别设置 ]
        private void cbAlarmWaveType2_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType2.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath2.Enabled = false;
                    bcpAlarmWavePath2.Enabled = false;
                    bcpTest2.Enabled = false;
                    break;
                case 3:
                case 4:
                    txtAlarmWavePath2.Enabled = true;
                    bcpAlarmWavePath2.Enabled = true;
                    bcpTest2.Enabled = true;
                    break;
                default:
                    break;
            } 
        }
        #endregion

        #region [ 事件: 区域报警声音路径选择 Click ]
        private void bcpAlarmWavePath2_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath2.Text = ofd.FileName;
            }
        }
        #endregion

        #region [ 事件: 区域报警声音测试 Click ]
        private void bcpTest2_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@txtAlarmWavePath2.Text.Trim());
                simpleSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAlarmWavePath2.Focus();
                txtAlarmWavePath2.SelectAll();
            }
        }
        #endregion
        #endregion

        #region [ 分站报警 ]
        #region [ 事件: 分站报警声音类别设置 ]
        private void cbAlarmWaveType3_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType3.SelectedIndex)+1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath3.Enabled = false;
                    bcpAlarmWavePath3.Enabled = false;
                    bcpTest3.Enabled = false;
                    break;
                case 3:
                case 4:
                    txtAlarmWavePath3.Enabled = true;
                    bcpAlarmWavePath3.Enabled = true;
                    bcpTest3.Enabled = true;
                    break;
                default:
                    break;
            } 
        }
        #endregion

        #region [ 事件: 分站报警声音路径 Click ]
        private void bcpAlarmWavePath3_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath3.Text = ofd.FileName;
            }
        }
        #endregion

        #region [ 事件: 分站报警声音测 Click ]
        private void bcpTest3_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@txtAlarmWavePath3.Text.Trim());
                simpleSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAlarmWavePath3.Focus();
                txtAlarmWavePath3.SelectAll();
            }
        }
        #endregion
        #endregion

        #region [ 超员报警 ]
        #region [ 事件: 超员报警声音类别设置 ]
        private void cbAlarmWaveType4_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType4.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath4.Enabled = false;
                    bcpAlarmWavePath4.Enabled = false;
                    bcpTest4.Enabled = false;
                    break;
                case 3:
                case 4:
                    txtAlarmWavePath4.Enabled = true;
                    bcpAlarmWavePath4.Enabled = true;
                    bcpTest4.Enabled = true;
                    break;
                default:
                    break;
            } 
        }
        #endregion

        #region [ 事件: 超员报警声音路径选择 Click ]
        private void bcpAlarmWavePath4_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath4.Text = ofd.FileName;
            }
        }
        #endregion

        #region [ 事件: 超员报警声音测试 Click ]
        private void bcpTest4_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@txtAlarmWavePath4.Text.Trim());
                simpleSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAlarmWavePath4.Focus();
                txtAlarmWavePath4.SelectAll();
            }
        }
        #endregion
        #endregion

        #region [ 低电量报警 ]
        #region [ 事件: 低电量报警声音类别设置 ]
        private void cbAlarmWaveType5_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType5.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath5.Enabled = false;
                    bcpAlarmWavePath5.Enabled = false;
                    bcpTest5.Enabled = false;
                    break;
                case 3:
                case 4:
                    txtAlarmWavePath5.Enabled = true;
                    bcpAlarmWavePath5.Enabled = true;
                    bcpTest5.Enabled = true;
                    break;
                default:
                    break;
            } 
        }
        #endregion

        #region [ 事件: 低电量报警声音路径选择 Click ]
        private void bcpAlarmWavePath5_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath5.Text = ofd.FileName;
            }
        }
        #endregion

        #region [ 事件: 低电量报警声音测试 Click ]
        private void bcpTest5_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@txtAlarmWavePath5.Text.Trim());
                simpleSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAlarmWavePath5.Focus();
                txtAlarmWavePath5.SelectAll();
            }
        }
        #endregion
        #endregion

        #region [ 接收器报警 ]
        #region [ 事件: 接收器报警声音类别设置 ]
        private void cbAlarmWaveType6_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType6.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath6.Enabled = false;
                    bcpAlarmWavePath6.Enabled = false;
                    bcpTest6.Enabled = false;
                    break;
                case 3:
                case 4:
                    txtAlarmWavePath6.Enabled = true;
                    bcpAlarmWavePath6.Enabled = true;
                    bcpTest6.Enabled = true;
                    break;
                default:
                    break;
            } 
        }
        #endregion

        #region [ 事件: 接收器报警声音路径选择 ]
        private void bcpAlarmWavePath6_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath6.Text = ofd.FileName;
            }
        }
        #endregion

        #region [ 事件: 接收器报警声音测试 ]
        private void bcpTest6_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@txtAlarmWavePath6.Text.Trim());
                simpleSound.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAlarmWavePath6.Focus();
                txtAlarmWavePath6.SelectAll();
            }
        }
        #endregion
        #endregion

        #region [ 路线报警 ]

        #region 路线报警声音类别设置
        private void cbAlarmWaveType7_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType7.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath7.Enabled = false;
                    bcpAlarmWavePath7.Enabled = false;
                    bcpTest7.Enabled = false;
                    break;
                case 3:
                case 4:
                    txtAlarmWavePath7.Enabled = true;
                    bcpAlarmWavePath7.Enabled = true;
                    bcpTest7.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 路线报警声音路径选择
        private void bcpAlarmWavePath7_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath7.Text = ofd.FileName;
            }
        }
        #endregion

        #region 路线报警声音测试
        private void bcpTest7_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@txtAlarmWavePath7.Text.Trim());
                simpleSound.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAlarmWavePath7.Focus();
                txtAlarmWavePath7.SelectAll();
            }
        }
        #endregion
        #endregion


        #region [ 事件: 确定 Click ]
        private void bcpOK_Click(object sender, EventArgs e)
        {
            //存入日志
            LogSave.Messages("[FrmAlarmSet]", LogIDType.UserLogID, "报警参数设置");

            if (CheckingAlarmSet())
            {
                asbll.SaveEmpCount(txtEmpCount.Text.Trim());
                //超时报警
                asbll.UpDateAlarmSet(1, cbAlarmSet1.Checked, Convert.ToInt32(cbAlarmWaveType1.SelectedValue), txtAlarmWavePath1.Text.Trim());
                //区域报警
                asbll.UpDateAlarmSet(2, cbAlarmSet2.Checked, Convert.ToInt32(cbAlarmWaveType2.SelectedValue), txtAlarmWavePath2.Text.Trim());
                //分站报警
                asbll.UpDateAlarmSet(3, cbAlarmSet3.Checked, Convert.ToInt32(cbAlarmWaveType3.SelectedValue), txtAlarmWavePath3.Text.Trim());
                //超员报警
                asbll.UpDateAlarmSet(4, cbAlarmSet4.Checked, Convert.ToInt32(cbAlarmWaveType4.SelectedValue), txtAlarmWavePath4.Text.Trim());
                //低电量报警
                asbll.UpDateAlarmSet(5, cbAlarmSet5.Checked, Convert.ToInt32(cbAlarmWaveType5.SelectedValue), txtAlarmWavePath5.Text.Trim());
                //接收器报警
                asbll.UpDateAlarmSet(6, cbAlarmSet6.Checked, Convert.ToInt32(cbAlarmWaveType6.SelectedValue), txtAlarmWavePath6.Text.Trim());
                //路线报警
                asbll.UpDateAlarmSet(7, cbAlarmSet7.Checked, Convert.ToInt32(cbAlarmWaveType7.SelectedValue), txtAlarmWavePath7.Text.Trim());

                //判断是否超员
                if (intOverEmp != Convert.ToInt32(txtEmpCount.Text.Trim()))
                {
                    IsOverEmp();
                }

                this.Close();
            }
        }
        #endregion

        #region [ 事件: 取消 Click ]
        private void bcpExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region [ 方法: 验证 ]
        bool CheckingAlarmSet()
        {
            if (txtEmpCount.Text.Trim() == "")
            {
                MessageBox.Show("请输入超员人数！", "提示", MessageBoxButtons.OK);
                txtEmpCount.Focus();
                txtEmpCount.SelectAll();
                return false;
            }
            if (txtAlarmWavePath1.Enabled && txtAlarmWavePath1.Text.Equals(""))
            {
                MessageBox.Show("请输入超时报警声音文件路径！", "提示", MessageBoxButtons.OK);
                txtAlarmWavePath1.Focus();
                txtAlarmWavePath1.SelectAll();
                return false;
            }
            if (txtAlarmWavePath2.Enabled && txtAlarmWavePath2.Text.Equals(""))
            {
                MessageBox.Show("请输入区域报警声音文件路径！", "提示", MessageBoxButtons.OK);
                txtAlarmWavePath2.Focus();
                txtAlarmWavePath2.SelectAll();
                return false;
            }
            if (txtAlarmWavePath3.Enabled && txtAlarmWavePath3.Text.Equals(""))
            {
                MessageBox.Show("请输入分站报警声音文件路径！", "提示", MessageBoxButtons.OK);
                txtAlarmWavePath3.Focus();
                txtAlarmWavePath3.SelectAll();
                return false;
            }
            if (txtAlarmWavePath4.Enabled && txtAlarmWavePath4.Text.Equals(""))
            {
                MessageBox.Show("请输入超员报警声音文件路径！", "提示", MessageBoxButtons.OK);
                txtAlarmWavePath4.Focus();
                txtAlarmWavePath4.SelectAll();
                return false;
            }
            if (txtAlarmWavePath5.Enabled && txtAlarmWavePath5.Text.Equals(""))
            {
                MessageBox.Show("请输入低电量报警声音文件路径！", "提示", MessageBoxButtons.OK);
                txtAlarmWavePath5.Focus();
                txtAlarmWavePath5.SelectAll();
                return false;
            }
            if (txtAlarmWavePath6.Enabled && txtAlarmWavePath6.Text.Equals(""))
            {
                MessageBox.Show("请输入接收器报警声音文件路径！", "提示", MessageBoxButtons.OK);
                txtAlarmWavePath6.Focus();
                txtAlarmWavePath6.SelectAll();
                return false;
            }
            if (txtAlarmWavePath7.Enabled && txtAlarmWavePath7.Text.Equals(""))
            {
                MessageBox.Show("请输入路线报警声音文件路径！", "提示", MessageBoxButtons.OK);
                txtAlarmWavePath7.Focus();
                txtAlarmWavePath7.SelectAll();
                return false;
            }

            //验证声音文件是否正确
            if (txtAlarmWavePath1.Enabled)
            {
                if (!IsOK(txtAlarmWavePath1.Text.Trim()))
                {
                    return false;
                }
            }
            if (txtAlarmWavePath2.Enabled)
            {
                if (!IsOK(txtAlarmWavePath2.Text.Trim()))
                {
                    return false;
                }
            }
            if (txtAlarmWavePath3.Enabled)
            {
                if (!IsOK(txtAlarmWavePath3.Text.Trim()))
                {
                    return false;
                }
            }
            if (txtAlarmWavePath4.Enabled)
            {
                if (!IsOK(txtAlarmWavePath4.Text.Trim()))
                {
                    return false;
                }
            }
            if (txtAlarmWavePath5.Enabled)
            {
                if (!IsOK(txtAlarmWavePath5.Text.Trim()))
                {
                    return false;
                }
            }
            if (txtAlarmWavePath6.Enabled)
            {
                if (!IsOK(txtAlarmWavePath6.Text.Trim()))
                {
                    return false;
                }
            }
            if (txtAlarmWavePath7.Enabled)
            {
                if (!IsOK(txtAlarmWavePath7.Text.Trim()))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion


        #region [ 方法: 判断是否超员 ]

        private bool IsOverEmp()
        {
            return asbll.IsOverEmp();
        }

        #endregion


        #region [ 方法: 验证声音文件是否正确 ]

        private bool IsOK(string strAlarmWavePath )
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(strAlarmWavePath);
                simpleSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAlarmWavePath1.Focus();
                txtAlarmWavePath1.SelectAll();
                return false;
            }
            return true;
        }

        #endregion


    }
}