using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using System.Drawing.Imaging;
using System.IO;
using KJ128NMainRun.Graphics.DPic;
using KJ128NMainRun.Graphics.Expert;
namespace KJ128NMainRun.Graphics.A_DPic_Wizard
{
    public partial class A_DPic_ChooseStation : Form
    {
        KJ128NMainRun.Graphics.Expert.A_FrmDCreateConfig frmMain = null;
        Graphics_DpicBLL dpicbll = new Graphics_DpicBLL();
        string strMineBgImage = string.Empty;

        #region 构造函数
        public A_DPic_ChooseStation()
        {
            InitializeComponent();

            
        }
        #endregion

        #region 重构构造函数
        public A_DPic_ChooseStation(string MineBgImage, Image img, KJ128NMainRun.Graphics.Expert.A_FrmDCreateConfig frm)
        {
            InitializeComponent();
            strMineBgImage = MineBgImage;


            picShow.Image = img;
            frmMain = frm;
        }
        #endregion

        #region 窗体加载事件
        private void A_DPic_ChooseStation_Load(object sender, EventArgs e)
        {
            lsbStation.Items.Clear();
            lsbStation.Values.Clear();
            DataTable station = dpicbll.GetAllInStationInfoByFileID();
            for (int i = 0; i < station.Rows.Count; i++)
            {
                if (!this.lsbStation.Values.Contains(station.Rows[i][0].ToString()))
                {
                    lsbSelectStation.AddItem(station.Rows[i][1].ToString(), station.Rows[i][0].ToString());
                }
            }
        }
        #endregion

        #region 分站移除按钮的单击事件
        private void btnRemoveStations_Click(object sender, EventArgs e)
        {
            if (lsbSelectStation.SelectedItems != null)
            {
                for (int i = (lsbSelectStation.SelectedItems.Count - 1); i >= 0; i--)
                {
                    int index = lsbSelectStation.Items.IndexOf(lsbSelectStation.SelectedItems[i]);
                    lsbStation.Items.Insert(0, lsbSelectStation.Items[index].ToString());
                    lsbStation.Values.Insert(0, lsbSelectStation.Values[index]);
                    lsbSelectStation.Values.RemoveAt(index);
                    lsbSelectStation.Items.RemoveAt(index);
                }
            }
        }
        #endregion

        #region 添加分站按钮的单击事件
        private void btnAddStations_Click(object sender, EventArgs e)
        {
            if (lsbStation.SelectedItems.Count > 0)
            {
                for (int i = (lsbStation.SelectedItems.Count - 1); i >= 0; i--)
                {
                    string item = lsbStation.SelectedItems[i].ToString();
                    string value = lsbStation.Values[lsbStation.Items.IndexOf(lsbStation.SelectedItems[i])];
                    lsbSelectStation.Items.Insert(0, item);
                    lsbSelectStation.Values.Insert(0, value);
                    lsbStation.Values.RemoveAt(lsbStation.Items.IndexOf(lsbStation.SelectedItems[i]));
                    lsbStation.Items.RemoveAt(lsbStation.Items.IndexOf(lsbStation.SelectedItems[i]));
                }
            }
        }
        #endregion

        #region 上一步按钮的单击事件
        private void btnPreview_Click(object sender, EventArgs e)
        {
            A_DPic_ImportPic ADPicImport = new A_DPic_ImportPic(frmMain);
            ADPicImport.Show();
            this.Close();
        }
        #endregion

        #region 下一步按钮的单击事件
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (strMineBgImage!= string.Empty)
            {
                List<string> stationidlist = new List<string>();
                for (int i = 0; i < lsbSelectStation.Items.Count; i++)
                {
                    stationidlist.Add(lsbSelectStation.Values[lsbSelectStation.Items.IndexOf(lsbSelectStation.Items[i])]);
                }
                if (dpicbll.UpdateFileStation_Wizard(strMineBgImage, stationidlist))
                {
                   //底图和分站的相应配置信息保存完成后，进入第四步, 配置分站在底图上的安装位置
                    A_DPic_AddPicLayer adpicadd = new A_DPic_AddPicLayer(strMineBgImage, picShow.Image,frmMain);
                    adpicadd.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("更新读卡分站配置失败...", "提示", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                MessageBox.Show("底图尚未选择...", "提示", MessageBoxButtons.OK);
                return;
            }
        }
        #endregion
    }
}
