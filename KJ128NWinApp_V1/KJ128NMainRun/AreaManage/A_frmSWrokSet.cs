using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NMainRun.AreaManage
{
    public partial class A_frmSWrokSet : Form
    {
        private SpecialWorkTypeTerrialSetBLL bll = new SpecialWorkTypeTerrialSetBLL();

        private System.Collections.Hashtable WtTable = new System.Collections.Hashtable();

        private A_FrmAreaManage Frm = null;

        public A_frmSWrokSet(A_FrmAreaManage f)
        {
            InitializeComponent();
            this.Frm = f;
        }

        private void A_frmSWrokSet_Load(object sender, EventArgs e)
        {
            LoadCmbTer();
        }

        private void LoadCmbTer()
        {
            cmbTer.Items.Clear();
            cmbTer.Values.Clear();
            DataTable dt = bll.GetTerrialInfo();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbTer.AddItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString());
                List<WorkTypeModel> list = GetWtList(dt.Rows[i][0].ToString());
                WtTable.Add(dt.Rows[i][0].ToString(), list);
            }
            if (cmbTer.Items.Count > 0)
            {
                cmbTer.SelectedIndex = 0;
            }
        }

        private List<WorkTypeModel> GetWtList(string terid)
        {
            List<WorkTypeModel> list=new List<WorkTypeModel>();
            DataTable dt = bll.GetWtInfoByTerID(terid);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WorkTypeModel wtm = new WorkTypeModel(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
                list.Add(wtm);
            }
            return list;
        }

        private void cmbTer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = cmbTer.SelectedValue;
            List<WorkTypeModel> list = (List<WorkTypeModel>)WtTable[key];
            lsbSelected.Items.Clear();
            lsbSelected.Values.Clear();
            foreach (WorkTypeModel wtb in list)
            {
                lsbSelected.AddItem(wtb.WorkType, wtb.WorkTypeID);
            }
            FlashWt();
        }

        private void FlashWt()
        {
            lsbWt.Items.Clear();
            lsbWt.Values.Clear();
            DataTable dt = bll.GetWtInfo();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lsbWt.AddItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString());
            }
            for (int i = 0; i < lsbSelected.Items.Count; i++)
            {
                if (lsbWt.Values.Contains(lsbSelected.Values[i]))
                {
                    lsbWt.Items.RemoveAt(lsbWt.Values.IndexOf(lsbSelected.Values[i]));
                    lsbWt.Values.Remove(lsbSelected.Values[i]);
                }
            }
        }

        private void bt_Right_Click(object sender, EventArgs e)
        {
            if(lsbWt.SelectedItem!=null)
            {
                if (lsbWt.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < lsbWt.SelectedItems.Count; i++)
                    {
                        lsbSelected.AddItem(lsbWt.SelectedItems[i].ToString(), lsbWt.Values[lsbWt.Items.IndexOf(lsbWt.SelectedItems[i].ToString())]);
                    }
                    FlashWt();
                }
            }
            string key = cmbTer.SelectedValue;
            if (key != null)
            {
                List<WorkTypeModel> list = new List<WorkTypeModel>();
                for (int i = 0; i < lsbSelected.Items.Count; i++)
                {
                    WorkTypeModel wtb = new WorkTypeModel(lsbSelected.Values[i], lsbSelected.Items[i].ToString());
                    list.Add(wtb);
                }
                WtTable[key] = list;
            }
        }

        private void bt_Left_Click(object sender, EventArgs e)
        {
            if (lsbSelected.SelectedItem != null)
            {
                if (lsbSelected.SelectedItems.Count > 0)
                {
                    for (int i = (lsbSelected.SelectedItems.Count - 1); i >= 0; i--)
                    {
                        lsbSelected.Values.Remove(lsbSelected.Values[lsbSelected.Items.IndexOf(lsbSelected.SelectedItems[i].ToString())]);
                        lsbSelected.Items.Remove(lsbSelected.SelectedItems[i]);
                    }
                    FlashWt();
                }
            }
            string key = cmbTer.SelectedValue;
            if (key != null)
            {
                List<WorkTypeModel> list = new List<WorkTypeModel>();
                for (int i = 0; i < lsbSelected.Items.Count; i++)
                {
                    WorkTypeModel wtb = new WorkTypeModel(lsbSelected.Values[i], lsbSelected.Items[i].ToString());
                    list.Add(wtb);
                }
                WtTable[key] = list;
            }
        }

        private void bt_TerSet_Reset_Click(object sender, EventArgs e)
        {
            ReSet();
        }

        private void ReSet()
        {
            WtTable = new System.Collections.Hashtable();
            cmbTer.Items.Clear();
            cmbTer.Values.Clear();
            DataTable dt = bll.GetTerrialInfo();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbTer.AddItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString());
                List<WorkTypeModel> list = new List<WorkTypeModel>();
                WtTable.Add(dt.Rows[i][0].ToString(), list);
            }
            if(cmbTer.Items.Count>0)
                cmbTer.SelectedIndex = 0;
        }

        private void bt_TerSet_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_TerSet_Save_Click(object sender, EventArgs e)
        {
            if (WtTable.Count > 0)
            {
                bll.DelSWTer("");
                foreach (object key in WtTable.Keys)
                {
                    List<WorkTypeModel> list = (List<WorkTypeModel>)WtTable[key];
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (!bll.InsertSWTer(key.ToString(), list[i].WorkTypeID))
                        {
                            labMessage.ForeColor = Color.Red;
                            labMessage.Text = "保存失败!";
                            labMessage.Visible = true;
                            return;
                        }
                    }
                }
                labMessage.ForeColor = Color.Black;
                labMessage.Text = "保存成功!";
            }
            else
            {
                labMessage.ForeColor = Color.Red;
                labMessage.Text = "尚未配置任何特殊工种";
            }
            labMessage.Visible = true;
            Frm.SelectInfoSWork(1);
        }
    }

    class WorkTypeModel
    {
        private string _WorkTypeID;

        public string WorkTypeID
        {
            get { return _WorkTypeID; }
            set { _WorkTypeID = value; }
        }

        private string _WorkType;

        public string WorkType
        {
            get { return _WorkType; }
            set { _WorkType = value; }
        }

        public WorkTypeModel()
        { 
            
        }

        public WorkTypeModel(string worktypeid, string worktype)
        {
            this.WorkTypeID = worktypeid;
            this.WorkType = worktype;
        }
    }
}
