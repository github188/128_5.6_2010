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

namespace KJ128NMainRun.Graphics.DPic
{
    public partial class A_FrmAddPic : Wilson.Controls.Docking.DockContent
    {
        Graphics_DpicBLL dpicbll = new Graphics_DpicBLL();
        DataTable FileDt;

        public A_FrmAddPic()
        {
            InitializeComponent();
        }

        private void trvDpic_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = trvDpic.GetNodeAt(e.Location);
                if (node != null)
                {
                    tsmiDel.Visible = true;
                    tsmiUpdate.Visible = true;
                    trvDpic.SelectedNode = node;
                }
                else
                {
                    tsmiDel.Visible = false;
                    tsmiUpdate.Visible = false;
                }
                cmsMenu.Show(trvDpic.PointToScreen(e.Location));
            }
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Application.StartupPath + "\\MapGis\\Map";
            ofd.Filter = "所有图片文件(*.wmf;*.bmp;*.gif;*.jpg)|*.wmf;*.bmp;*.gif;*.jpg|图元(*.wmf)|*.wmf|位图(*.bmp)|*.bmp|动态图片(*.gif)|*.gif|静态图片(*.jpg)|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image img = CreateBitMap(ofd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("添加底图失败,无法识别的图片...", "提示", MessageBoxButtons.OK);
                    return;
                }
                string SafeFileName = ofd.FileName.Substring(ofd.FileName.LastIndexOf("\\") + 1);
                System.IO.FileStream fs = new System.IO.FileStream(ofd.FileName, System.IO.FileMode.Open);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();
                int Success=dpicbll.InsertBackPicFile(SafeFileName, buffer);
                if (Success == -1)
                {
                    MessageBox.Show("添加底图失败,数据库中存在相同的文件名,未避免混乱请修改文件名后添加...", "提示", MessageBoxButtons.OK);
                    return;
                }
                LoadFileDt();
                picBackimg.Image = null;
                labPoint.Visible = false;
                labRoute.Visible = false;
                lsbSelectStation.Values.Clear();
                lsbSelectStation.Items.Clear();
                lsbStation.Values.Clear();
                lsbStation.Items.Clear();
            }
        }

        /// <summary>
        /// 创建底图的Image实例
        /// </summary>
        /// <param name="filepath">底图图片路径</param>
        /// <returns>返回创建好的底图实例</returns>
        private Image CreateBitMap(string filepath)
        {
            try
            {
                Metafile bitmap = new Metafile(filepath);
                return bitmap;
            }
            catch (System.Exception ex)
            {
                Image image = NewBitMap(filepath);
                return image;
            }
        }

        private Image NewBitMap(string filepath)
        {
            Stream stream = new FileStream(filepath, FileMode.Open);
            byte[] buffer = new byte[Convert.ToInt32(stream.Length)];
            stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
            stream.Close();
            System.IO.MemoryStream ms = new System.IO.MemoryStream(buffer);
            return Image.FromStream(ms);
        }

        private void tsmiDel_Click(object sender, EventArgs e)
        {
            if (trvDpic.SelectedNode != null)
            {
                if (MessageBox.Show("删除该底图将会丢失该图所有的图形配置文件及路径,是否删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (dpicbll.DelBackPicFile(trvDpic.SelectedNode.Text))
                    {
                        this.picBackimg.Image.Dispose();
                        this.picBackimg.Image = null;
                        this.picBackimg.Refresh();
                    }
                }
            }
            LoadFileDt();
            picBackimg.Image = null;
            labPoint.Visible = false;
            labRoute.Visible = false;
            lsbSelectStation.Values.Clear();
            lsbSelectStation.Items.Clear();
            lsbStation.Values.Clear();
            lsbStation.Items.Clear();
        }

        private void LoadFileDt()
        {
            trvDpic.Nodes.Clear();
            FileDt = dpicbll.GetAllBackPicFile();
            for (int i = 0; i < FileDt.Rows.Count; i++)
            {
                trvDpic.Nodes.Add(FileDt.Rows[i][0].ToString(), FileDt.Rows[i][1].ToString());
            }
        }

        private void LoadStation()
        {
            lsbStation.Items.Clear();
            lsbStation.Values.Clear();
            DataTable station = dpicbll.GetNotInStationInfoByFileID();
            for (int i = 0; i < station.Rows.Count; i++)
            {
                if (!lsbSelectStation.Values.Contains(station.Rows[i][0].ToString()))
                {
                    lsbStation.AddItem(station.Rows[i][1].ToString(), station.Rows[i][0].ToString());
                }
            }
        }

        private void FrmAddPic_Load(object sender, EventArgs e)
        {
            LoadFileDt();
            LoadStation();
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

        private void trvDpic_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lsbStation.Items.Clear();
            lsbStation.Values.Clear();
            lsbSelectStation.Items.Clear();
            lsbSelectStation.Values.Clear();
            this.picBackimg.Image = GetImageFromDT(trvDpic.SelectedNode.Text);
            if (dpicbll.IsRouted(trvDpic.SelectedNode.Name))
            {
                this.labRoute.Visible = true;
                this.labRoute.ForeColor = Color.Blue;
                this.labRoute.Text = "已配置";
            }
            else
            {
                this.labRoute.Visible = true;
                this.labRoute.ForeColor = Color.Red;
                this.labRoute.Text = "未配置";
            }
            if (dpicbll.IsPointed(trvDpic.SelectedNode.Name))
            {
                this.labPoint.Visible = true;
                this.labPoint.ForeColor = Color.Blue;
                this.labPoint.Text = "已生成";
            }
            else
            {
                this.labPoint.Visible = true;
                this.labPoint.ForeColor = Color.Red;
                this.labPoint.Text = "未生成";
            }
            DataTable dt = dpicbll.GetStationInfoByFileID(trvDpic.SelectedNode.Name);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lsbSelectStation.AddItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString());
            }
            LoadStation();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lsbStation.SelectedItems != null)
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
                    //LoadStation();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
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
                //btnSelect.Enabled = false;
                //LoadStationAll();
            }
        }

        private void LoadStationAll()
        {
            lsbStation.Items.Clear();
            lsbStation.Values.Clear();
            DataTable station = dpicbll.GetStationInfo();
            for (int i = 0; i < station.Rows.Count; i++)
            {
                if (!lsbSelectStation.Values.Contains(station.Rows[i][0].ToString()))
                {
                    lsbStation.AddItem(station.Rows[i][1].ToString(), station.Rows[i][0].ToString());
                }
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (trvDpic.SelectedNode != null)
            {
                List<string> stationidlist = new List<string>();
                for (int i = 0; i < lsbSelectStation.Values.Count; i++)
                {
                    stationidlist.Add(lsbSelectStation.Values[i]);
                }
                if (dpicbll.UpdateFileStation(trvDpic.SelectedNode.Name, stationidlist))
                {
                    MessageBox.Show("更新读卡分站配置成功!", "提示", MessageBoxButtons.OK);
                    //btnSelect.Enabled = true;
                    LoadStation();
                }
                else
                {
                    MessageBox.Show("更新读卡分站配置失败...", "提示", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("底图尚未选择...", "提示", MessageBoxButtons.OK);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tsmiAdd_Click(this, new EventArgs());
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("该操作将修改您已经配置的底图,是否继续？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = Application.StartupPath + "\\MapGis\\Map";
                ofd.Filter = "所有图片文件(*.wmf;*.bmp;*.gif;*.jpg)|*.wmf;*.bmp;*.gif;*.jpg|图元(*.wmf)|*.wmf|位图(*.bmp)|*.bmp|动态图片(*.gif)|*.gif|静态图片(*.jpg)|*.jpg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image img = CreateBitMap(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("添加底图失败,无法识别的图片...", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    string SafeFileName = trvDpic.SelectedNode.Text;
                    System.IO.FileStream fs = new System.IO.FileStream(ofd.FileName, System.IO.FileMode.Open);
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();
                    int Success = dpicbll.UpdateBackPicFile(SafeFileName, buffer);
                    if (Success == -1)
                    {
                        MessageBox.Show("修改底图失败...", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    LoadFileDt();
                    picBackimg.Image = null;
                    labPoint.Visible = false;
                    labRoute.Visible = false;
                    lsbSelectStation.Values.Clear();
                    lsbSelectStation.Items.Clear();
                    lsbStation.Values.Clear();
                    lsbStation.Items.Clear();
                }
            }
        }
    }
}
