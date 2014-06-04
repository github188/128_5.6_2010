using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using PrintCore;
using KJ128NInterfaceShow;

namespace KJ128NMainRun.IpConfig
{
    public partial class Frm_Ip_Add_new : KJ128NMainRun.FromModel.FrmModel
    {


        private IpListDataSource_BAl myipbal = new IpListDataSource_BAl();
        public Frm_Ip_Add_new()
        {
            InitializeComponent();
            this.drawerMainControl1.Add(panel_guanglian, true);
            this.drawerMainControl1.Add(panel_peizhi);
            this.drawerMainControl1.LeftPartResize();
            tree();
            bindgirdview();
        }
        //select ipid,place,'0' as ParentID,'true' as IsChild ,'true' as IsUserNum,'0' as Num from TcpIPConfig

        #region 切换
        private void button_guanlian_Click(object sender, EventArgs e)
        {
            this.drawerMainControl1.ButtonClick(panel_guanglian.Name);
        } 
        #endregion

        #region 切换
        private void button_peizhi_Click(object sender, EventArgs e)
        {
            this.drawerMainControl1.ButtonClick(panel_peizhi.Name);
        } 
        #endregion
        private void bindgirdview()
        {
            dataGridView1.DataSource = myipbal.iplist();

        }
        private void tree()
        {


            DataTable ds = myipbal.guanlian_tree();
            LoadTree(treeViewControl_guanlian, ds, " ", false);



        }
        private void SetDataRow(ref DataRow dr, int id, string name, int parentid, bool isChild, bool isUserNum, int num)
        {
            dr[0] = id;
            dr[1] = name;
            dr[2] = parentid;
            dr[3] = isChild;
            dr[4] = isUserNum;
            dr[5] = num;
        }
        private void LoadTree(DegonControlLib.TreeViewControl tvc, DataTable dsTemp, string strName, bool blCount)
        {
            if (tvc.Nodes.Count > 0)
            {
                tvc.Nodes.Clear();
            }
            DataTable dt;

            if (dsTemp != null && dsTemp.Rows.Count > 0)
            {
                dt = dsTemp;
            }
            else
            {
                dt = tvc.BuildMenusEntity();
            }

            DataRow dr = dt.NewRow();
            SetDataRow(ref dr, 0, "所有", -1, false, blCount, 0);
            dt.Rows.Add(dr);

            tvc.DataSouce = dt;
            tvc.LoadNode(strName);


            tvc.ExpandAll();
            tvc.SelectedNode = tvc.Nodes[0];
            tvc.SetSelectNodeColor();
        }
    }
}
