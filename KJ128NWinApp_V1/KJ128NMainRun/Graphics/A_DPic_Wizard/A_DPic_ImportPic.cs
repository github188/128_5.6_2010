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
    public partial class A_DPic_ImportPic : Form
    {
        Graphics_DpicBLL dpicbll = new Graphics_DpicBLL();
        DataTable FileDt;
        KJ128NMainRun.Graphics.Expert.A_FrmDCreateConfig frmMain = null;

        #region 构造函数
        public A_DPic_ImportPic(KJ128NMainRun.Graphics.Expert.A_FrmDCreateConfig frm)
        {
            InitializeComponent();

            frmMain = frm;
        }
        #endregion

        #region 底图菜单列表的鼠标单击事件
        private void trvDpic_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = trvDpic.GetNodeAt(e.Location);
                if (node != null)
                {
                    tsmiDel.Visible = true;
                    trvDpic.SelectedNode = node;
                }
                else
                {
                    tsmiDel.Visible = false;
                }
                cmsMenu.Show(trvDpic.PointToScreen(e.Location));
            }

            for (int i = 0; i < trvDpic.Nodes.Count; i++)
            {
                if (trvDpic.Nodes[i].Checked)
                {
                    trvDpic.Nodes[i].Checked = false;
                }
            }
        }
        #endregion

        #region 弹出菜单的添加事件
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
                int Success = dpicbll.InsertBackPicFile(SafeFileName, buffer);
                if (Success == -1)
                {
                    MessageBox.Show("添加底图失败,数据库中存在相同的文件名,未避免混乱请修改文件名后添加...", "提示", MessageBoxButtons.OK);
                    return;
                }
                LoadFileDt();

                btnNext.Enabled = true;
            }
        }
        #endregion

        #region 加载图片预览
        private void LoadFileDt()
        {
            trvDpic.Nodes.Clear();
            FileDt = dpicbll.GetAllBackPicFile();
            for (int i = 0; i < FileDt.Rows.Count; i++)
            {
                trvDpic.Nodes.Add(FileDt.Rows[i][0].ToString(),FileDt.Rows[i][1].ToString());
            }

            if (trvDpic.Nodes.Count < 1)
            {
                btnNext.Enabled = false;
                return;
            }
            else
            {
                trvDpic.Nodes[trvDpic.Nodes.Count-1].Checked = true;
            }

            foreach (TreeNode tn in trvDpic.Nodes)
            {
                if (tn.Checked)
                {
                    this.picBackimg.Image = GetImageFromDT(tn.Text);
                    this.picBackimg.Tag = tn.Name;
                }
            }

        }
        #endregion

        #region 导入按钮的单击事件
        private void btn_Import_Click(object sender, EventArgs e)
        {
            tsmiAdd_Click(this, new EventArgs());
        }
        #endregion

        #region 删除按钮的单击事件
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
            //picBackimg.Image = null;

        }
        #endregion

        #region 窗体加载事件
        private void A_DPic_ImportPic_Load(object sender, EventArgs e)
        {
            LoadFileDt();
        }
        #endregion

        #region 下一步按钮的单击事件
        private void btnNext_Click(object sender, EventArgs e)
        {
            bool IsNodeChecked = false;

            for (int i = 0; i < trvDpic.Nodes.Count; i++)
            {
                if (trvDpic.Nodes[i].Checked)
                {
                    IsNodeChecked = true;
                }
            }

            if (!IsNodeChecked)
            {
                MessageBox.Show("请选中一张煤矿底图，并在前面打上勾", "提示");
                return;
            }


            A_DPic_ChooseStation AdpicC = new A_DPic_ChooseStation(picBackimg.Tag.ToString(), picBackimg.Image, frmMain);
            AdpicC.Show();
            this.Close();

        }
        #endregion

        #region 被选中后的事件
        private void trvDpic_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode tn in trvDpic.Nodes)
            {
                if (tn.Checked)
                {
                   
                    this.picBackimg.Image = GetImageFromDT(tn.Text);
                    this.picBackimg.Tag = tn.Name.ToString();
                    
                    
                }
            }
        }
        #endregion

        #region 被选中后的事件
        private void trvDpic_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.Checked = true;
        }
        #endregion

        #region 上一步的单击事件
        private void btnPreview_Click(object sender, EventArgs e)
        {
            A_DPic_Welcom dpicWelcom = new A_DPic_Welcom(frmMain);
            dpicWelcom.Show();
            this.Close();
        }
        #endregion

        #region 创建图片预览
        /// <summary>
        /// 创建底图的Image实例
        /// </summary>
        /// <param name="filepath">底图图片路径</param>
        /// <returns>返回创建好的底图实例</returns>
        public Image CreateBitMap(string filepath)
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
        #endregion

        #region 加载图片
        public Image NewBitMap(string filepath)
        {
            Stream stream = new FileStream(filepath, FileMode.Open);
            byte[] buffer = new byte[Convert.ToInt32(stream.Length)];
            stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
            stream.Close();
            System.IO.MemoryStream ms = new System.IO.MemoryStream(buffer);
            return Image.FromStream(ms);
        }
        #endregion

        #region 图片的加载事件
        public Image GetImageFromDT(string filename)
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

        public Image BytesToImage(byte[] buffer)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(buffer);
            return Image.FromStream(ms);
        }
        #endregion

    }
}
