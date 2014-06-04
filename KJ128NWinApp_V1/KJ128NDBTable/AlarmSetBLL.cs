using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;

using KJ128NDataBase;
using KJ128NInterfaceShow;
using KJ128WindowsLibrary;
namespace KJ128NDBTable
{
    public class AlarmSetBLL
    {

        private DataSet ds ;
        private AlarmSetDAL asdal = new AlarmSetDAL();

        #region [ 方法: 加载 报警声音类别 ]
        public bool AlarmWaveType(ComboBox cmbAlarmWaveType)
        {
            DataSet ds = null;
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

        #region [ 方法: 加载超时报警数据 ]

        public bool LoadAlarmSetInfo(CheckBox chbType, ComboBox cmbType, TextBox txtPath, int intType,ButtonCaptionPanel bcpPath,ButtonCaptionPanel bcpTest)
        {
            DataSet ds = null;
            using(ds=new DataSet())
            {
                ds = asdal.GetAlarmSetInfo(intType);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    int i = Convert.ToInt32(ds.Tables[0].Rows[0][1]);
                    cmbType.SelectedValue = i;
                    if (i == 1 || i == 2)
                    {
                        txtPath.Enabled = false;
                        bcpPath.Enabled = false;
                        bcpTest.Enabled = false;
                        txtPath.Text = "";
                    }
                    else
                    {
                        txtPath.Enabled = true;
                        bcpPath.Enabled = true;
                        bcpTest.Enabled = true;
                        txtPath.Text = ds.Tables[0].Rows[0][2].ToString();
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[0][3])== 1)
                    {
                        chbType.Checked = true;
                    }
                    else
                    {
                        chbType.Checked = false;
                    }
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region [ 方法: 加载超员人数 ]

        public bool LoadEmpCount(TextBox txtEmpCount)
        {

            using (ds = new DataSet())
            {
                ds = asdal.GetEmpCount();

                if (ds!=null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtEmpCount.Text = ds.Tables[0].Rows[0][0].ToString();
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

        #region [ 方法: 存储超员报警人数 ]

        public int SaveEmpCount(string strEmpCount)
        {
            return asdal.SaveEmpCount(strEmpCount);
        }

        #endregion

        #region [ 方法: 判断是否超员 ]

        public bool IsOverEmp()
        {
            return asdal.IsOverEmp();
        }

        #endregion
    }
}
