using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using Shine.Logs;
using Shine.Logs.LogType;
using System.Media;
using Shine;
using System.Xml;
using System.IO;

namespace KJ128NMainRun.A_Tool
{
    public partial class A_FrmToolOptions : Form
    {
        #region【声明】

        private A_ToolOptionsBLL asbll = new A_ToolOptionsBLL();

        private OpenFileDialog ofd;

        private string strPath = System.Environment.CurrentDirectory + "\\Sound";

        private A_FrmMain Main = null;

        private bool isOpen = false;

        #endregion

        #region【构造函数】

        public A_FrmToolOptions(A_FrmMain frmmain)
        {
            InitializeComponent();
            Main = frmmain;
        }

        #endregion

        #region【窗体加载】

        private void A_FrmToolOptions_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\PowerManager.xml"))
            {
                XmlDocument dom = new XmlDocument();
                dom.Load(Application.StartupPath + "\\PowerManager.Xml");
                // string Location = xml1.SelectSingleNode("/Config/Location").InnerText;
                //string staID = xml.SelectSingleNode("StationID").InnerText;
                string staID = dom.SelectSingleNode("Root/IsOpen").InnerText;
                if (staID.ToLower().Trim().Equals("true"))
                {
                    isOpen = true;
                    SetEle(true);
                }
                else
                {
                    isOpen = false;
                    SetEle(false);
                }
            }
            else
            {
                isOpen = false;
                SetEle(false);
            }
            
            asbll.AlarmWaveType(cbAlarmWaveType1);
            asbll.AlarmWaveType(cbAlarmWaveType2);
            asbll.AlarmWaveType(cbAlarmWaveType3);
            asbll.AlarmWaveType(cbAlarmWaveType4);
            asbll.AlarmWaveType(cbAlarmWaveType5);
            asbll.AlarmWaveType(cbAlarmWaveType6);
            asbll.AlarmWaveType(cbAlarmWaveType7);
            asbll.AlarmWaveType(cbAlarmWaveType8);
            asbll.AlarmWaveType(cbAlarmWaveType9);
            asbll.AlarmWaveType(cbAlarmWaveType10);
            asbll.AlarmWaveType(cbAlarmWaveType11);
            asbll.AlarmWaveType(cbAlarmWaveType12);
            asbll.AlarmWaveType(cbAlarmWaveType13);
            asbll.AlarmWaveType(cbAlarmWaveType14);

            if (isOpen)
            {
                //Czlt-2011-06-05 - 交直流供电
                asbll.AlarmWaveType(cmbStatEle);
                asbll.AlarmWaveType(cmbJHJEle);

                cmbStatEle.SelectedIndex = 0;
                cmbJHJEle.SelectedIndex = 0;
            }

            asbll.LoadAlarmSetInfo(checkBox1,cbAlarmWaveType1, txtAlarmWavePath1, 1, btAlarmWavePath1, btTest1);
            asbll.LoadAlarmSetInfo(checkBox2, cbAlarmWaveType2, txtAlarmWavePath2, 2, btAlarmWavePath2, btTest2);
            asbll.LoadAlarmSetInfo(checkBox3, cbAlarmWaveType3, txtAlarmWavePath3, 3, btAlarmWavePath3, btTest3);
            asbll.LoadAlarmSetInfo(checkBox4, cbAlarmWaveType4, txtAlarmWavePath4, 4, btAlarmWavePath4, btTest4);
            asbll.LoadAlarmSetInfo(checkBox5, cbAlarmWaveType5, txtAlarmWavePath5, 5, btAlarmWavePath5, btTest5);
            asbll.LoadAlarmSetInfo(checkBox6, cbAlarmWaveType6, txtAlarmWavePath6, 6, btAlarmWavePath6, btTest6);
            asbll.LoadAlarmSetInfo(checkBox7, cbAlarmWaveType7, txtAlarmWavePath7, 7, btAlarmWavePath7, btTest7);
            asbll.LoadAlarmSetInfo(checkBox8, cbAlarmWaveType8, txtAlarmWavePath8, 8, btAlarmWavePath8, btTest8);
            asbll.LoadAlarmSetInfo(checkBox9, cbAlarmWaveType9, txtAlarmWavePath9, 9, btAlarmWavePath9, btTest9);
            asbll.LoadAlarmSetInfo(checkBox10, cbAlarmWaveType10, txtAlarmWavePath10, 10, btAlarmWavePath10, btTest10);
            asbll.LoadAlarmSetInfo(checkBox11, cbAlarmWaveType11, txtAlarmWavePath11, 11, btAlarmWavePath11, btTest11);
            asbll.LoadAlarmSetInfo(checkBox12, cbAlarmWaveType12, txtAlarmWavePath12, 12, btAlarmWavePath12, btTest12);
            asbll.LoadAlarmSetInfo(checkBox13, cbAlarmWaveType13, txtAlarmWavePath13, 13, btAlarmWavePath13, btTest13);
            asbll.LoadAlarmSetInfo(checkBox14, cbAlarmWaveType14, txtAlarmWavePath14, 14, btAlarmWavePath14, btTest14);
            if (isOpen)
            {
                //Czlt-2011-06-05 - 交直流供电
                asbll.LoadAlarmSetInfo(chkStatEle, cmbStatEle, txtAlarmStaElePath15, 17, btAlarmStaElePath15, btTest15);
                asbll.LoadAlarmSetInfo(chkJHJEle, cmbJHJEle, txtAlarmJHJElePath16, 18, btAlarmJHJElePath16, btTest16);
            }
        



        }

        #endregion

        #region【方法：验证】

        private bool CheckingAlarmSet()
        {
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
            if (txtAlarmWavePath8.Enabled && txtAlarmWavePath8.Text.Equals(""))
            {
                MessageBox.Show("请输入超速报警声音文件路径！", "提示", MessageBoxButtons.OK);
                txtAlarmWavePath8.Focus();
                txtAlarmWavePath8.SelectAll();
                return false;
            }
            if (txtAlarmWavePath9.Enabled && txtAlarmWavePath9.Text.Equals(""))
            {
                MessageBox.Show("请输入欠速报警声音文件路径！", "提示", MessageBoxButtons.OK);
                txtAlarmWavePath9.Focus();
                txtAlarmWavePath9.SelectAll();
                return false;
            }
            if (txtAlarmWavePath10.Enabled && txtAlarmWavePath10.Text.Equals(""))
            {
                MessageBox.Show("请输入求救报警声音文件路径！", "提示", MessageBoxButtons.OK);
                txtAlarmWavePath10.Focus();
                txtAlarmWavePath10.SelectAll();
                return false;
            }
            if (txtAlarmWavePath11.Enabled && txtAlarmWavePath11.Text.Equals(""))
            {
                MessageBox.Show("请输入区域超时报警声音文件路径！", "提示", MessageBoxButtons.OK);
                txtAlarmWavePath11.Focus();
                txtAlarmWavePath11.SelectAll();
                return false;
            }
            if (txtAlarmWavePath12.Enabled && txtAlarmWavePath12.Text.Equals(""))
            {
                MessageBox.Show("请输入区域超员报警声音文件路径！", "提示", MessageBoxButtons.OK);
                txtAlarmWavePath12.Focus();
                txtAlarmWavePath12.SelectAll();
                return false;
            }
            if (txtAlarmWavePath13.Enabled && txtAlarmWavePath13.Text.Equals(""))
            {
                MessageBox.Show("请输入异地交接班报警声音文件路径！", "提示", MessageBoxButtons.OK);
                txtAlarmWavePath13.Focus();
                txtAlarmWavePath13.SelectAll();
                return false;
            }
            if (txtAlarmWavePath14.Enabled && txtAlarmWavePath14.Text.Equals(""))
            {
                MessageBox.Show("请输入唯一性报警声音文件路径！", "提示", MessageBoxButtons.OK);
                txtAlarmWavePath13.Focus();
                txtAlarmWavePath13.SelectAll();
                return false;
            }


            //****************Czlt-2011-06-04 交直流供电**********************
            if (txtAlarmStaElePath15.Enabled && txtAlarmStaElePath15.Text.Equals(""))
            {
                MessageBox.Show("请输入传输分站供电报警声音文件路径！", "提示", MessageBoxButtons.OK);
                txtAlarmStaElePath15.Focus();
                txtAlarmStaElePath15.SelectAll();
                return false;
            }

            if (txtAlarmJHJElePath16.Enabled && txtAlarmJHJElePath16.Text.Equals(""))
            {
                MessageBox.Show("请输入交换机供电报警声音文件路径！", "提示", MessageBoxButtons.OK);
                txtAlarmJHJElePath16.Focus();
                txtAlarmJHJElePath16.SelectAll();
                return false;
            }
            //****************Czlt-2011-06-04 交直流供电**********************


            //验证声音文件是否正确
            if (txtAlarmWavePath1.Enabled)
            {
                if (!IsOK(txtAlarmWavePath1))
                {
                    return false;
                }
            }
            if (txtAlarmWavePath2.Enabled)
            {
                if (!IsOK(txtAlarmWavePath2))
                {
                    return false;
                }
            }
            if (txtAlarmWavePath3.Enabled)
            {
                if (!IsOK(txtAlarmWavePath3))
                {
                    return false;
                }
            }
            if (txtAlarmWavePath4.Enabled)
            {
                if (!IsOK(txtAlarmWavePath4))
                {
                    return false;
                }
            }
            if (txtAlarmWavePath5.Enabled)
            {
                if (!IsOK(txtAlarmWavePath5))
                {
                    return false;
                }
            }
            if (txtAlarmWavePath6.Enabled)
            {
                if (!IsOK(txtAlarmWavePath6))
                {
                    return false;
                }
            }
            if (txtAlarmWavePath7.Enabled)
            {
                if (!IsOK(txtAlarmWavePath7))
                {
                    return false;
                }
            }
            if (txtAlarmWavePath8.Enabled)
            {
                if (!IsOK(txtAlarmWavePath8))
                {
                    return false;
                }
            }
            if (txtAlarmWavePath9.Enabled)
            {
                if (!IsOK(txtAlarmWavePath9))
                {
                    return false;
                }
            }
            if (txtAlarmWavePath10.Enabled)
            {
                if (!IsOK(txtAlarmWavePath10))
                {
                    return false;
                }
            }
            if (txtAlarmWavePath11.Enabled)
            {
                if (!IsOK(txtAlarmWavePath11))
                {
                    return false;
                }
            }
            if (txtAlarmWavePath12.Enabled)
            {
                if (!IsOK(txtAlarmWavePath12))
                {
                    return false;
                }
            }
            if (txtAlarmWavePath13.Enabled)
            {
                if (!IsOK(txtAlarmWavePath13))
                {
                    return false;
                }
            }
            if (txtAlarmWavePath14.Enabled)
            {
                if (!IsOK(txtAlarmWavePath14))
                {
                    return false;
                }
            }


            //**************Czlt-2011-06-05*交直流供电******************
            if (txtAlarmStaElePath15.Enabled)
            {
                if (!IsOK(txtAlarmStaElePath15))
                {
                    return false;
                }
            }

            if (txtAlarmJHJElePath16.Enabled)
            {
                if (!IsOK(txtAlarmJHJElePath16))
                {
                    return false;
                }
            }
            //**************Czlt-2011-06-05*交直流供电******************

            return true;
        }
        #endregion

        #region【方法：验证声音文件是否正确】

        private bool IsOK(ShineTextBox txtAlarmWavePath )
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(txtAlarmWavePath.Text);
                simpleSound.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAlarmWavePath.Focus();
                txtAlarmWavePath.SelectAll();
                return false;
            }
            return true;
        }

        #endregion


        #region【事件：保存】

        private void bt_Save_Click(object sender, EventArgs e)
        {
            //存入日志
            LogSave.Messages("[A_FrmToolOptions]", LogIDType.UserLogID, "配置选项");

            if (CheckingAlarmSet())
            {
                //超时报警
                asbll.UpDateAlarmSet(1, true, Convert.ToInt32(cbAlarmWaveType1.SelectedValue), txtAlarmWavePath1.Text.Trim());
                //区域报警
                asbll.UpDateAlarmSet(2, true, Convert.ToInt32(cbAlarmWaveType2.SelectedValue), txtAlarmWavePath2.Text.Trim());
                //分站报警
                asbll.UpDateAlarmSet(3, true, Convert.ToInt32(cbAlarmWaveType3.SelectedValue), txtAlarmWavePath3.Text.Trim());
                //超员报警
                asbll.UpDateAlarmSet(4, true, Convert.ToInt32(cbAlarmWaveType4.SelectedValue), txtAlarmWavePath4.Text.Trim());
                //低电量报警
                asbll.UpDateAlarmSet(5, checkBox5.Checked, Convert.ToInt32(cbAlarmWaveType5.SelectedValue), txtAlarmWavePath5.Text.Trim());
                //接收器报警
                asbll.UpDateAlarmSet(6, true, Convert.ToInt32(cbAlarmWaveType6.SelectedValue), txtAlarmWavePath6.Text.Trim());
                //路线报警
                asbll.UpDateAlarmSet(7, checkBox7.Checked, Convert.ToInt32(cbAlarmWaveType7.SelectedValue), txtAlarmWavePath7.Text.Trim());
                //超速报警
                asbll.UpDateAlarmSet(8, checkBox8.Checked, Convert.ToInt32(cbAlarmWaveType8.SelectedValue), txtAlarmWavePath8.Text.Trim());
                //欠速报警
                asbll.UpDateAlarmSet(9, checkBox9.Checked, Convert.ToInt32(cbAlarmWaveType9.SelectedValue), txtAlarmWavePath9.Text.Trim());
                //求救报警
                asbll.UpDateAlarmSet(10, checkBox10.Checked, Convert.ToInt32(cbAlarmWaveType10.SelectedValue), txtAlarmWavePath10.Text.Trim());
                //区域超时报警
                asbll.UpDateAlarmSet(11, checkBox11.Checked, Convert.ToInt32(cbAlarmWaveType11.SelectedValue), txtAlarmWavePath11.Text.Trim());
                //区域超员报警
                asbll.UpDateAlarmSet(12, checkBox12.Checked, Convert.ToInt32(cbAlarmWaveType12.SelectedValue), txtAlarmWavePath12.Text.Trim());
                //异地交接班报警
                asbll.UpDateAlarmSet(13, checkBox13.Checked, Convert.ToInt32(cbAlarmWaveType13.SelectedValue), txtAlarmWavePath13.Text.Trim());
                //唯一性报警
                asbll.UpDateAlarmSet(14, checkBox14.Checked, Convert.ToInt32(cbAlarmWaveType14.SelectedValue), txtAlarmWavePath14.Text.Trim());


                //Czlt-2011-06-04 - 传输分站供电报警
                asbll.UpDateAlarmSet(17, chkStatEle.Checked, Convert.ToInt32(cmbStatEle.SelectedValue), txtAlarmStaElePath15.Text.Trim());

                //Czlt-2011-06-04 - 交换机供电报警
                asbll.UpDateAlarmSet(18, chkJHJEle.Checked, Convert.ToInt32(cmbJHJEle.SelectedValue), txtAlarmJHJElePath16.Text.Trim());
                

                Main.FlashTsmi();
                this.Close();
            }
        }

        #endregion

        #region【事件：关闭】

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion



        #region【超时报警】
        #region [ 事件: 超时报警声音类别设置 ]
        private void cbAlarmWaveType1_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType1.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath1.Enabled = false;
                    btAlarmWavePath1.Enabled = false;
                    btTest1.Enabled = false;
                    break;
                case 3:
                    txtAlarmWavePath1.Enabled = true;
                    btAlarmWavePath1.Enabled = true;
                    btTest1.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region [ 事件: 超时报警声音路径选择 Click ]
        private void btAlarmWavePath1_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";

            ofd.InitialDirectory = strPath;

            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath1.Text = ofd.FileName;
            }
        }
        #endregion

        #region  [ 事件: 超时报警声音测试 Click ]
        private void btTest1_Click(object sender, EventArgs e)
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

        #region【事件：启用超时报警】

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cbAlarmWaveType1.Enabled = checkBox1.Checked;

            if (!checkBox1.Checked)
            {
                cbAlarmWaveType1.SelectedIndex = 0;
                txtAlarmWavePath1.Enabled = false;
                btAlarmWavePath1.Enabled = false;
                btTest1.Enabled = false;
            }
        }

        #endregion

        #endregion

        #region【区域报警】

        #region [ 事件: 区域报警声音类别设置 ]
        private void cbAlarmWaveType2_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType2.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath2.Enabled = false;
                    btAlarmWavePath2.Enabled = false;
                    btTest2.Enabled = false;
                    break;
                case 3:
                    txtAlarmWavePath2.Enabled = true;
                    btAlarmWavePath2.Enabled = true;
                    btTest2.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region [ 事件: 区域报警声音路径选择 Click ]
        private void btAlarmWavePath2_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";
            ofd.InitialDirectory = strPath;
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath2.Text = ofd.FileName;
            }
        }
        #endregion

        #region [ 事件: 区域报警声音测试 Click ]
        private void btTest2_Click(object sender, EventArgs e)
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

        #region【事件：启用区域报警】

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            cbAlarmWaveType2.Enabled = checkBox2.Checked;

            if (!checkBox2.Checked)
            {
                cbAlarmWaveType2.SelectedIndex = 0;
                txtAlarmWavePath2.Enabled = false;
                btAlarmWavePath2.Enabled = false;
                btTest2.Enabled = false;
            }
        }

        #endregion

        #endregion

        #region【分站报警】

        #region [ 事件: 分站报警声音类别设置 ]
        private void cbAlarmWaveType3_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType3.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath3.Enabled = false;
                    btAlarmWavePath3.Enabled = false;
                    btTest3.Enabled = false;
                    break;
                case 3:
                    txtAlarmWavePath3.Enabled = true;
                    btAlarmWavePath3.Enabled = true;
                    btTest3.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region [ 事件: 分站报警声音路径 Click ]
        private void btAlarmWavePath3_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";
            ofd.InitialDirectory = strPath;
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath3.Text = ofd.FileName;
            }
        }
        #endregion

        #region [ 事件: 分站报警声音测 Click ]
        private void btTest3_Click(object sender, EventArgs e)
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

        #region【事件：启用传输分站报警】

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            cbAlarmWaveType3.Enabled = checkBox3.Checked;

            if (!checkBox3.Checked)
            {
                cbAlarmWaveType3.SelectedIndex = 0;
                txtAlarmWavePath3.Enabled = false;
                btAlarmWavePath3.Enabled = false;
                btTest3.Enabled = false;
            }
        }

        #endregion

        #endregion

        #region【超员报警】

        #region [ 事件: 超员报警声音类别设置 ]
        private void cbAlarmWaveType4_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType4.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath4.Enabled = false;
                    btAlarmWavePath4.Enabled = false;
                    btTest4.Enabled = false;
                    break;
                case 3:
                    txtAlarmWavePath4.Enabled = true;
                    btAlarmWavePath4.Enabled = true;
                    btTest4.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region [ 事件: 超员报警声音路径选择 Click ]
        private void btAlarmWavePath4_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";
            ofd.InitialDirectory = strPath;
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath4.Text = ofd.FileName;
            }
        }
        #endregion

        #region [ 事件: 超员报警声音测试 Click ]
        private void btTest4_Click(object sender, EventArgs e)
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

        #region【事件：启用超员报警】

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            cbAlarmWaveType4.Enabled = checkBox4.Checked;

            if (!checkBox4.Checked)
            {
                cbAlarmWaveType4.SelectedIndex = 0;
                txtAlarmWavePath4.Enabled = false;
                btAlarmWavePath4.Enabled = false;
                btTest4.Enabled = false;
            }
        }

        #endregion

        #endregion

        #region【低电量报警】

        #region [ 事件: 低电量报警声音类别设置 ]
        private void cbAlarmWaveType5_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType5.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath5.Enabled = false;
                    btAlarmWavePath5.Enabled = false;
                    btTest5.Enabled = false;
                    break;
                case 3:
                    txtAlarmWavePath5.Enabled = true;
                    btAlarmWavePath5.Enabled = true;
                    btTest5.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region [ 事件: 低电量报警声音路径选择 Click ]
        private void btAlarmWavePath5_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";

            ofd.InitialDirectory = strPath;
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath5.Text = ofd.FileName;
            }
        }
        #endregion

        #region [ 事件: 低电量报警声音测试 Click ]
        private void btTest5_Click(object sender, EventArgs e)
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

        #region【事件：启用低电量】

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            cbAlarmWaveType5.Enabled = checkBox5.Checked;

            if (!checkBox5.Checked)
            {
                cbAlarmWaveType5.SelectedIndex = 0;
                txtAlarmWavePath5.Enabled = false;
                btAlarmWavePath5.Enabled = false;
                btTest5.Enabled = false;
            }
        }

        #endregion

        #endregion

        #region【接收器报警】
        #region [ 事件: 接收器报警声音类别设置 ]
        private void cbAlarmWaveType6_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType6.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath6.Enabled = false;
                    btAlarmWavePath6.Enabled = false;
                    btTest6.Enabled = false;
                    break;
                case 3:
                    txtAlarmWavePath6.Enabled = true;
                    btAlarmWavePath6.Enabled = true;
                    btTest6.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region [ 事件: 接收器报警声音路径选择 ]
        private void btAlarmWavePath6_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";

            ofd.InitialDirectory = strPath;
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath6.Text = ofd.FileName;
            }
        }
        #endregion

        #region [ 事件: 接收器报警声音测试 ]
        private void btTest6_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@txtAlarmWavePath6.Text.Trim());
                simpleSound.Load();
                simpleSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAlarmWavePath6.Focus();
                txtAlarmWavePath6.SelectAll();
            }
        }
        #endregion

        #region【事件：启用读卡分站】

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            cbAlarmWaveType6.Enabled = checkBox6.Checked;

            if (!checkBox6.Checked)
            {
                cbAlarmWaveType6.SelectedIndex = 0;
                txtAlarmWavePath6.Enabled = false;
                btAlarmWavePath6.Enabled = false;
                btTest6.Enabled = false;
            }
        }

        #endregion

        #endregion

        #region【路线报警】

        #region 路线报警声音类别设置
        private void cbAlarmWaveType7_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType7.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath7.Enabled = false;
                    btAlarmWavePath7.Enabled = false;
                    btTest7.Enabled = false;
                    break;
                case 3:
                    txtAlarmWavePath7.Enabled = true;
                    btAlarmWavePath7.Enabled = true;
                    btTest7.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 路线报警声音路径选择
        private void btAlarmWavePath7_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";
            ofd.InitialDirectory = strPath;
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath7.Text = ofd.FileName;
            }
        }
        #endregion

        #region 路线报警声音测试
        private void btTest7_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@txtAlarmWavePath7.Text.Trim());
                simpleSound.Load();
                simpleSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAlarmWavePath7.Focus();
                txtAlarmWavePath7.SelectAll();
            }
        }
        #endregion

        #region【事件：启用路线报警】

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            cbAlarmWaveType7.Enabled = checkBox7.Checked;

            if (!checkBox7.Checked)
            {
                cbAlarmWaveType7.SelectedIndex = 0;
                txtAlarmWavePath7.Enabled = false;
                btAlarmWavePath7.Enabled = false;
                btTest7.Enabled = false;
            }
        }

        #endregion

        #endregion

        #region【超速报警】

        #region 超速报警声音类别设置
        private void cbAlarmWaveType8_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType8.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath8.Enabled = false;
                    btAlarmWavePath8.Enabled = false;
                    btTest8.Enabled = false;
                    break;
                case 3:
                    txtAlarmWavePath8.Enabled = true;
                    btAlarmWavePath8.Enabled = true;
                    btTest8.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 超速报警声音路径选择
        private void btAlarmWavePath8_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";
            ofd.InitialDirectory = strPath;
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath8.Text = ofd.FileName;
            }
        }
        #endregion

        #region 超速报警声音测试
        private void btTest8_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@txtAlarmWavePath8.Text.Trim());
                simpleSound.Load();
                simpleSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAlarmWavePath8.Focus();
                txtAlarmWavePath8.SelectAll();
            }
        }
        #endregion

        #region【事件：启用超速报警】

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            cbAlarmWaveType8.Enabled = checkBox8.Checked;

            if (!checkBox8.Checked)
            {
                cbAlarmWaveType8.SelectedIndex = 0;
                txtAlarmWavePath8.Enabled = false;
                btAlarmWavePath8.Enabled = false;
                btTest8.Enabled = false;
            }
        }

        #endregion

        #endregion

        #region【欠速报警】

        #region 欠速报警声音类别设置
        private void cbAlarmWaveType9_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType9.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath9.Enabled = false;
                    btAlarmWavePath9.Enabled = false;
                    btTest9.Enabled = false;
                    break;
                case 3:
                    txtAlarmWavePath9.Enabled = true;
                    btAlarmWavePath9.Enabled = true;
                    btTest9.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 欠速报警声音路径选择
        private void btAlarmWavePath9_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";
            ofd.InitialDirectory = strPath;
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath9.Text = ofd.FileName;
            }
        }
        #endregion

        #region 欠速报警声音测试
        private void btTest9_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@txtAlarmWavePath9.Text.Trim());
                simpleSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAlarmWavePath9.Focus();
                txtAlarmWavePath9.SelectAll();
            }
        }
        #endregion

        #region【事件：启用欠速报警】

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            cbAlarmWaveType9.Enabled = checkBox9.Checked;

            if (!checkBox9.Checked)
            {
                cbAlarmWaveType9.SelectedIndex = 0;
                txtAlarmWavePath9.Enabled = false;
                btAlarmWavePath9.Enabled = false;
                btTest9.Enabled = false;
            }
        }

        #endregion

        #endregion

        #region【求救报警】

        #region 求救报警声音类别设置
        private void cbAlarmWaveType10_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType10.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath10.Enabled = false;
                    btAlarmWavePath10.Enabled = false;
                    btTest10.Enabled = false;
                    break;
                case 3:
                    txtAlarmWavePath10.Enabled = true;
                    btAlarmWavePath10.Enabled = true;
                    btTest10.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 求救报警声音路径选择
        private void btAlarmWavePath10_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";
            ofd.InitialDirectory = strPath;
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath10.Text = ofd.FileName;
            }
        }
        #endregion

        #region 求救报警声音测试
        private void btTest10_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@txtAlarmWavePath10.Text.Trim());
                simpleSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAlarmWavePath10.Focus();
                txtAlarmWavePath10.SelectAll();
            }
        }
        #endregion

        #region【事件：启用求救报警】

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            cbAlarmWaveType10.Enabled = checkBox10.Checked;

            if (!checkBox10.Checked)
            {
                cbAlarmWaveType10.SelectedIndex = 0;
                txtAlarmWavePath10.Enabled = false;
                btAlarmWavePath10.Enabled = false;
                btTest10.Enabled = false;
            }
        }

        #endregion

        #endregion

        #region【区域超时报警】

        #region 区域超时报警声音类别设置
        private void cbAlarmWaveType11_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType11.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath11.Enabled = false;
                    btAlarmWavePath11.Enabled = false;
                    btTest11.Enabled = false;
                    break;
                case 3:
                    txtAlarmWavePath11.Enabled = true;
                    btAlarmWavePath11.Enabled = true;
                    btTest11.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 区域超时报警声音路径选择
        private void btAlarmWavePath11_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";
            ofd.InitialDirectory = strPath;
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath11.Text = ofd.FileName;
            }
        }
        #endregion

        #region 区域超时报警声音测试
        private void btTest11_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@txtAlarmWavePath11.Text.Trim());
                simpleSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAlarmWavePath11.Focus();
                txtAlarmWavePath11.SelectAll();
            }
        }
        #endregion

        #region【事件：启用区域超时报警】

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            cbAlarmWaveType11.Enabled = checkBox11.Checked;
            
            if (!checkBox11.Checked)
            {
                cbAlarmWaveType11.SelectedIndex = 0;
                txtAlarmWavePath11.Enabled = false;
                btAlarmWavePath11.Enabled = false;
                btTest11.Enabled = false;
            }
        }

        #endregion

        #endregion

        #region【区域超员报警】

        #region 区域超员报警声音类别设置
        private void cbAlarmWaveType12_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType12.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath12.Enabled = false;
                    btAlarmWavePath12.Enabled = false;
                    btTest12.Enabled = false;
                    break;
                case 3:
                    txtAlarmWavePath12.Enabled = true;
                    btAlarmWavePath12.Enabled = true;
                    btTest12.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 区域超员报警声音路径选择
        private void btAlarmWavePath12_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";
            ofd.InitialDirectory = strPath;
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath12.Text = ofd.FileName;
            }
        }
        #endregion

        #region 区域超员报警声音测试
        private void btTest12_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@txtAlarmWavePath12.Text.Trim());
                simpleSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAlarmWavePath12.Focus();
                txtAlarmWavePath12.SelectAll();
            }
        }
        #endregion

        #region【事件：启用区域超员报警】

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            cbAlarmWaveType12.Enabled = checkBox12.Checked;

            if (!checkBox12.Checked)
            {
                cbAlarmWaveType12.SelectedIndex = 0;
                txtAlarmWavePath12.Enabled = false;
                btAlarmWavePath12.Enabled = false;
                btTest12.Enabled = false;
            }
        }

        #endregion

        #endregion

        #region【异地交接班报警】

        #region 异地交接班报警声音类别设置
        private void cbAlarmWaveType13_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType13.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath13.Enabled = false;
                    btAlarmWavePath13.Enabled = false;
                    btTest13.Enabled = false;
                    break;
                case 3:
                    txtAlarmWavePath13.Enabled = true;
                    btAlarmWavePath13.Enabled = true;
                    btTest13.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 异地交接班报警声音路径选择
        private void btAlarmWavePath13_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";
            ofd.InitialDirectory = strPath;
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath13.Text = ofd.FileName;
            }
        }
        #endregion

        #region 异地交接班报警声音测试
        private void btTest13_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@txtAlarmWavePath13.Text.Trim());
                simpleSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAlarmWavePath13.Focus();
                txtAlarmWavePath13.SelectAll();
            }
        }
        #endregion

        #region【事件：启用异地交接班报警】

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            cbAlarmWaveType13.Enabled = checkBox13.Checked;

            if (!checkBox13.Checked)
            {
                cbAlarmWaveType13.SelectedIndex = 0;
                txtAlarmWavePath13.Enabled = false;
                btAlarmWavePath13.Enabled = false;
                btTest13.Enabled = false;
            }
        }

        #endregion

        private void A_FrmToolOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigXmlWiter.Write("EnumTable.xml");
            ConfigXmlWiter.Write("AlarmSet.xml");
        }

        #endregion

        #region 【唯一性报警】
        
        #region 【唯一性报警声音类别设置】
        private void cbAlarmWaveType14_DropDownClosed(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbAlarmWaveType14.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmWavePath14.Enabled = false;
                    btAlarmWavePath14.Enabled = false;
                    btTest14.Enabled = false;
                    break;
                case 3:
                    txtAlarmWavePath14.Enabled = true;
                    btAlarmWavePath14.Enabled = true;
                    btTest14.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 【唯一性报警声音路径选择】
        private void btAlarmWavePath14_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";
            ofd.InitialDirectory = strPath;
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty)
            {
                txtAlarmWavePath14.Text = ofd.FileName;
            }
        }
        #endregion

        #region 【唯一性报警声音测试】
        private void btTest14_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@txtAlarmWavePath14.Text.Trim());
                simpleSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAlarmWavePath14.Focus();
                txtAlarmWavePath14.SelectAll();
            }
        }
        #endregion

        #region 【启用唯一性报警】
        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            cbAlarmWaveType14.Enabled = checkBox14.Checked;

            if (!checkBox14.Checked)
            {
                cbAlarmWaveType14.SelectedIndex = 0;
                txtAlarmWavePath14.Enabled = false;
                btAlarmWavePath14.Enabled = false;
                btTest14.Enabled = false;
            }
        }
        #endregion

        private void txtAlarmWavePath1_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        #endregion

        private void txtAlarmWavePath2_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtAlarmWavePath3_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtAlarmWavePath6_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtAlarmWavePath4_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtAlarmWavePath5_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtAlarmWavePath7_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }


        //****************Czlt-2011-06-04****************************
        #region 【传输分站供电报警】

        #region 【传输分站供电报警声音路径选择】
        private void btAlarmStaElePath15_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";
            ofd.InitialDirectory = strPath;
            ofd.ShowDialog();

            if (ofd.FileName != string.Empty)
            {
                txtAlarmStaElePath15.Text = ofd.FileName;
            }
        }
        #endregion

        #region【传输分站供电声音测试】
        private void btTest15_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@txtAlarmStaElePath15.Text.Trim());
                simpleSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAlarmStaElePath15.Focus();
                txtAlarmStaElePath15.SelectAll();
            }
        }
        #endregion

        #region 【启用传输分站供电声音报警】
        private void chkStatEle_CheckedChanged(object sender, EventArgs e)
        {
            cmbStatEle.Enabled = chkStatEle.Checked;

            if (!chkStatEle.Checked)
            {
                cmbStatEle.SelectedIndex = 0;
                txtAlarmStaElePath15.Enabled = false;
                btAlarmStaElePath15.Enabled = false;
                btTest15.Enabled = false;
            }
        }
        #endregion

        #region 【传输分站供电报警声音设置】
        private void cmbStatEle_DropDownClosed(object sender, EventArgs e)
        {

            switch (Convert.ToInt32(cmbStatEle.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmStaElePath15.Enabled = false;
                    btAlarmStaElePath15.Enabled = false;
                    btTest15.Enabled = false;
                    break;
                case 3:
                    txtAlarmStaElePath15.Enabled = true;
                    btAlarmStaElePath15.Enabled = true;
                    btTest15.Enabled = true;
                    break;
                default:
                    break;
            }

        }
        #endregion
        #endregion

        #region 【交换机供电报警】

        #region 【交换机供电报警路径选择】
        private void btAlarmJHJElePath16_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "*.wav|*.wav";
            ofd.InitialDirectory = strPath;
            ofd.ShowDialog();

            if (ofd.FileName != string.Empty)
            {
                txtAlarmJHJElePath16.Text = ofd.FileName;
            }

        }
        #endregion

        #region【交换机供电声音测试】
        private void btTest16_Click(object sender, EventArgs e)
        {

            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@txtAlarmJHJElePath16.Text.Trim());
                simpleSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtAlarmJHJElePath16.Focus();
                txtAlarmJHJElePath16.SelectAll();
            }
        }
        #endregion

        #region【交换机供电报警声音设置】
        private void cmbJHJEle_DropDownClosed(object sender, EventArgs e)
        {

            switch (Convert.ToInt32(cmbJHJEle.SelectedIndex) + 1)
            {
                case 1:
                case 2:
                    txtAlarmJHJElePath16.Enabled = false;
                    btAlarmJHJElePath16.Enabled = false;
                    btTest16.Enabled = false;
                    break;
                case 3:
                    txtAlarmJHJElePath16.Enabled = true;
                    btAlarmJHJElePath16.Enabled = true;
                    btTest16.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 【启用交换机供电报警】
        private void chkJHJEle_CheckedChanged(object sender, EventArgs e)
        {


            cmbJHJEle.Enabled = chkJHJEle.Checked;

            if (!chkJHJEle.Checked)
            {
                cmbJHJEle.SelectedIndex = 0;
                txtAlarmJHJElePath16.Enabled = false;
                btAlarmJHJElePath16.Enabled = false;
                btTest16.Enabled = false;
            }
        }
        #endregion




        #endregion

        //****************Czlt-2011-06-04****************************

        #region 【Czlt-2011-11-22 显示供电信息】
        private void SetEle(bool isValue)
        {
            string type = "";
            if (File.Exists(Application.StartupPath + "\\CommType.xml"))
            {
                XmlDocument dom = new XmlDocument();
                dom.Load(Application.StartupPath + "\\CommType.Xml");
                // string Location = xml1.SelectSingleNode("/Config/Location").InnerText;
                //string staID = xml.SelectSingleNode("StationID").InnerText;
                type = dom.SelectSingleNode("comm/commType").InnerText;
            }
            chkStatEle.Visible = isValue;
            cmbStatEle.Visible = isValue;

            //判断是否为环网  1-环网 
            if (type.Trim().Equals("1"))
            {
                chkJHJEle.Visible = isValue;
                cmbJHJEle.Visible = isValue;
            }

            label7.Visible = isValue;
            txtAlarmStaElePath15.Visible = isValue;
            btAlarmStaElePath15.Visible = isValue;
            btTest15.Visible = isValue;

             //判断是否为环网  1-环网 
            if (type.Trim().Equals("1"))
            {
                label8.Visible = isValue;
                txtAlarmJHJElePath16.Visible = isValue;
                btAlarmJHJElePath16.Visible = isValue;
                btTest16.Visible = isValue;
            }


        }
        #endregion

    }
}
