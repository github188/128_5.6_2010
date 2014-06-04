using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NDataBase;
using KJ128NModel;

namespace KJ128NMainRun.PathManage
{
    public partial class FrmEmpPathAdd : Form
    {
        #region 【自定义参数】
        /// <summary>
        /// 巡检配置窗体对象
        /// </summary>
        private FrmPathManage m_frmPathManage;
        /// <summary>
        /// 操作类型  1添加  2修改
        /// </summary>
        private int m_type;
        /// <summary>
        /// 传入数据
        /// </summary>
        private DataGridViewRow m_dgvRow;
        /// <summary>
        /// 获取的数据
        /// </summary>
        public DataGridViewRow DgvRow
        {
            set { m_dgvRow = value; }
        }
        /// <summary>
        /// 路径逻辑对象
        /// </summary>
        private PathInfoBll pathinfoBll = new PathInfoBll();
        /// <summary>
        /// 部门逻辑对象
        /// </summary>
        private DeptBLL deptBll = new DeptBLL();
        /// <summary>
        /// 巡检人员逻辑对象
        /// </summary>
        private PathEmpRelationBll pathEmpBll = new PathEmpRelationBll();

        private int state = 0;
        #endregion

        #region 【构造函数】
        public FrmEmpPathAdd(int type,FrmPathManage frmPathManage)
        {
            InitializeComponent();
            m_frmPathManage = frmPathManage;
            m_type = type;
            pathinfoBll.PathInfo_BindComboBox(cmbPathID);
            deptBll.getDeptAddAll1(cmbDept);
        }
        #endregion

        #region 【自定义方法】

        #region 【方法：设置显示提示信息】
        /// <summary>
        /// 设置显示提示信息
        /// </summary>
        /// <param name="strMessage">显示信息</param>
        /// <param name="c">颜色</param>
        private void SetShowInfo(string strMessage, Color c)
        {
            labMessage.Visible = true;
            labMessage.ForeColor = c;
            labMessage.Text = strMessage;
        }
        #endregion

        #region 【方法：绑定文本框和下拉列表】
        /// <summary>
        /// 绑定文本框和下拉列表框
        /// </summary>
        private void BindText()
        {
            try
            {
                txtID.Text = m_dgvRow.Cells["id"].Value.ToString();
                cmbPathID.Text = m_dgvRow.Cells["pathno1"].Value.ToString();
                cmbDept.SelectedValue = m_dgvRow.Cells["deptid"].Value.ToString();
            }
            catch
            { }
        }
        #endregion

        #region 【方法：保存前判断】
        /// <summary>
        /// 保存前期判断
        /// </summary>
        /// <returns></returns>
        private bool Check()
        {
            if (cmbPathID.SelectedIndex<1)
            {
                SetShowInfo("请选择路线编号", Color.Blue);
                return false;
            }
            if (cmbDept.SelectedIndex<1 || cmbEmp.SelectedIndex<1)
            {
                SetShowInfo("请选择巡检人员", Color.Blue);
                return false;
            }
            return true;
        }
        #endregion

        #endregion

        #region 【系统事件方法】
        #region 【事件方法：窗体加载】
        private void FrmEmpPathAdd_Load(object sender, EventArgs e)
        {
            string strPathNo = "";
            switch (m_type)
            {
                case 1://添加
                    this.Text = "新增人员巡检";
                    cmbPathID.SelectedIndex = 0;
                    cmbDept.SelectedIndex = 0;
                    strPathNo = "";
                    break;
                case 2://修改
                    this.Text = "修改人员巡检";
                    state = 0;
                    BindText();
                    strPathNo = cmbPathID.Text;
                    break;
                default://查看
                    this.Text = "查看人员巡检";
                    BindText();
                    strPathNo = cmbPathID.Text;
                    groupBox1.Enabled = false;
                    break;
            }
        }
        #endregion

        #region 【事件方法：保存数据】
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                PathEmpRelationModel pathEmpModel = new PathEmpRelationModel();
                pathEmpModel.PathNo = cmbPathID.Text;
                pathEmpModel.EmpID = int.Parse(cmbEmp.SelectedValue.ToString());
                string strMessage = "";
                int rowCount = 0;
                switch (m_type)
                {
                    case 1://添加
                        try
                        {
                            rowCount=pathEmpBll.InsertPathEmpRelation(pathEmpModel, out strMessage);
                            if (strMessage.Equals("Succeeds"))
                            {
                                if (rowCount > 0)
                                {
                                    SetShowInfo("保存成功", Color.Black);
                                }
                                else
                                {
                                    SetShowInfo("添加重复数据", Color.Red);
                                    return;
                                }
                            }
                            else
                            {
                                SetShowInfo("保存失败", Color.Red);
                                return;
                            }
                        }
                        catch
                        {
                            SetShowInfo("保存失败", Color.Red);
                            return;
                        }
                        
                        break;
                    case 2://修改
                        pathEmpModel.Id = int.Parse(txtID.Text);
                        try
                        {
                            pathEmpBll.UpdatePathEmpRelation(pathEmpModel,out strMessage);
                            if (strMessage.Equals("Succeeds"))
                            {
                                SetShowInfo("修改成功", Color.Black);
                            }
                            else
                            {
                                SetShowInfo("修改失败", Color.Red);
                                return;
                            }
                        }
                        catch
                        {
                            SetShowInfo("修改失败", Color.Red);
                            return;
                        }
                        break;
                }
                if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                {
                    m_frmPathManage.SetTreeViewPathEmp();
                    m_frmPathManage.BindData("");
                }
                else                                //热备版，启用定时器
                {
                    m_frmPathManage.HostBackRefresh(true);
                }
            }
        }
        #endregion

        #region 【事件方法：重置数据】
        private void btnReset_Click(object sender, EventArgs e)
        {
            labMessage.Visible = false;
            switch (m_type)
            {
                case 1://添加
                    cmbPathID.SelectedIndex = 0;
                    txtPathName.Text = "";
                    cmbDept.SelectedIndex = 0;
                    cmbEmp.SelectedIndex = 0;
                    break;
                case 2://修改
                    state = 0;
                    BindText();
                    
                    break;
            }
        }
        #endregion

        #region 【事件方法：关闭窗体】
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 【事件方法：路线编号下拉列表框被改变】
        private void cmbPathID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPathID.SelectedIndex > 0)
            {
                txtPathName.Text = cmbPathID.SelectedValue.ToString();
            }
            else
            {
                txtPathName.Text = "";
            }
        }
        #endregion

        #region 【事件方法：部门下拉列表框被改变】
        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDept.SelectedIndex > 0)
            {
                //绑定人员下拉列表
                pathinfoBll.EmpInfo_BindComboBox(cmbEmp, cmbDept.SelectedValue.ToString());
                switch (m_type)
                {
                    case 1:
                        cmbEmp.SelectedIndex = 0;
                        break;
                    case 2:
                        if (state == 0)
                        {
                            cmbEmp.SelectedValue = m_dgvRow.Cells["empid"].Value.ToString();
                            state = 1;
                        }
                        else
                        {
                            cmbEmp.SelectedIndex = 0;
                        }
                        break;
                }
                //cmbEmp.SelectedIndex = 0;
            }
            else
            {
                cmbEmp.DataSource = null;
                cmbEmp.Items.Clear();
                cmbEmp.Items.Add("无");
                cmbEmp.SelectedIndex = 0;
            }
        }
        #endregion

        private void txtPathName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
        #endregion

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
    }
}
