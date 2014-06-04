using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;
using System.Windows.Forms;

namespace KJ128NDBTable
{
    public class A_ToolOptionsBLL
    {
        #region【声明】

        private A_ToolOptionsDAL asdal = new A_ToolOptionsDAL();

        private DataSet ds;

        #endregion

        #region [ 方法: 加载 报警声音类别 ]
        public bool AlarmWaveType(ComboBox cmbAlarmWaveType)
        {
            using (ds = new DataSet())
            {
                ds = asdal.GetAlarmWaveType();
                cmbAlarmWaveType.DataSource = ds.Tables[0];
                cmbAlarmWaveType.DisplayMember = "Title";
                cmbAlarmWaveType.ValueMember = "EnumID";
                cmbAlarmWaveType.SelectedIndex = 0;
            }

            return true;
        }

        #endregion

        #region [ 方法: 加载报警数据 ]

        public bool LoadAlarmSetInfo(CheckBox cb, ComboBox cmbType, TextBox txtPath, int intType, Button btPath, Button btTest)
        {
            using (ds = new DataSet())
            {
                ds = asdal.GetAlarmSetInfo(intType);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    int i = Convert.ToInt32(ds.Tables[0].Rows[0][1]);
                    cmbType.SelectedValue = i;
                    if (i == 1 || i == 2)
                    {
                        txtPath.Enabled = false;
                        btPath.Enabled = false;
                        btTest.Enabled = false;
                        txtPath.Text = "";
                    }
                    else
                    {
                        txtPath.Enabled = true;
                        btPath.Enabled = true;
                        btTest.Enabled = true;
                        txtPath.Text = ds.Tables[0].Rows[0][2].ToString();
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[0][3]) == 1)
                    {
                        cb.Checked = true;
                        cmbType.Enabled = true;
                    }
                    else
                    {
                        cb.Checked = false;
                        cmbType.Enabled = false;
                    }
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region [ 方法: 存储报警设置信息 ]

        public int UpDateAlarmSet(int intAlarmSetType, bool blEnumValue, int intAlarmWaveType, string strAlarmWavePath)
        {
            return asdal.UpDateAlarmSet(intAlarmSetType, blEnumValue, intAlarmWaveType, strAlarmWavePath);
        }

        #endregion

    }
}
