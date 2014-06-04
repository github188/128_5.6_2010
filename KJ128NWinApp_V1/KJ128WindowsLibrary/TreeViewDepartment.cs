using System;
using System.Windows.Forms;
using System.Collections;
using System.Data;
namespace KJ128WindowsLibrary
{
    /// <summary>
    /// 与部门绑定的TreeView
    /// </summary>
    public class TreeViewDepartment:TreeView
    {
       /// <summary>
       /// 继承的TreeView，构造函数
       /// </summary>
        public TreeViewDepartment():base()
        {
            
        }
       
        /// <summary>
        /// 根据部门表中的信息，添加到TreeView节点
        /// </summary>
        /// <param name="dt">部门表的信息</param>
        public void ReadDept_Info(DataTable dt)
        {
            this.Nodes.Add("root", "所有");//默认有一个全部的根节点
            DataTable dt_tem = dt;//存取在内存中的临时表，用于检索上级的记录
            //获取TreeNode集合
            TreeNodeCollection treeNodeColle = this.Nodes["root"].Nodes;
            //遍历所有部门
            #region 遍历所有部门
            foreach (DataRow dr in dt.Rows)
            {
                int int_DeptId = (int)dr["DeptID"];//部门ID
                int int_ParentDeptID = (int)dr["ParentDeptID"];//父部门ID,没有父部门则为0
                string str_DeptName = (string)dr["DeptName"];//部门名称
                string key = "N" + int_DeptId;//treeNode 的key 
                #region 添加子节点
                if (int_ParentDeptID == 0)//没有父部门
                {
                    treeNodeColle.Add(key, str_DeptName);//添加一个根节点
                }
                else
                {
                    string str_key = "N" + int_ParentDeptID;//node key 取父级的key
                    string[] str_DeptIDs;//如果有多个上级，则将多个上级以数组形式存储
                    string str_DeptID; //存储多个上级，以,分隔存储在字符串
                    str_DeptID = GetParentDepKey(dt_tem, int_ParentDeptID, "");//根据DeptID检索DataRow,可以获取所有父级索引的字符串集合
                    str_DeptIDs = str_DeptID.Split(new char[] { ',' });//拆分所有的父级
                    #region 判断有多少父级
                    switch (str_DeptIDs.Length)//判断有多少父级
                    {
                        case 1://只有一个父级
                            {
                                treeNodeColle[str_key].Nodes.Add(key, str_DeptName);
                                break;
                            }
                        case 2://只有两个父级
                            {
                                treeNodeColle["N" + str_DeptIDs[0]].Nodes["N" + str_DeptIDs[1]].Nodes.Add(key, str_DeptName);
                                break;
                            }
                        case 3://只有三个父级
                            {                         
                                treeNodeColle["N" + str_DeptIDs[0]].Nodes["N" + str_DeptIDs[1]].Nodes["N" + str_DeptIDs[2]].Nodes.Add(key, str_DeptName);
                                break;
                            }
                        case 4://只有四个父级
                            {
                                treeNodeColle["N" + str_DeptIDs[0]].Nodes["N" + str_DeptIDs[1]].Nodes["N" + str_DeptIDs[2]].
                                    Nodes["N"+str_DeptIDs[3]].Nodes.Add(key, str_DeptName);
                                break;
                            }
                        case 5://只有五个父级
                            {
                                treeNodeColle["N" + str_DeptIDs[0]].Nodes["N" + str_DeptIDs[1]].Nodes["N" + str_DeptIDs[2]].
                                    Nodes["N" + str_DeptIDs[3]].Nodes["N"+str_DeptIDs[4]].Nodes.Add(key, str_DeptName);
                                break;
                            }
                        case 6:
                            {
                                treeNodeColle["N" + str_DeptIDs[0]].Nodes["N" + str_DeptIDs[1]].Nodes["N" + str_DeptIDs[2]].
                                    Nodes["N" + str_DeptIDs[3]].Nodes["N" + str_DeptIDs[4]].Nodes["N"+str_DeptIDs[5]].Nodes.Add(key, str_DeptName);
                                break;
                            }
                        case 7:
                            {
                                treeNodeColle["N" + str_DeptIDs[0]].Nodes["N" + str_DeptIDs[1]].Nodes["N" + str_DeptIDs[2]].
                                    Nodes["N" + str_DeptIDs[3]].Nodes["N" + str_DeptIDs[4]].Nodes["N" + str_DeptIDs[5]].
                                    Nodes["N"+str_DeptIDs[6]].Nodes.Add(key, str_DeptName);
                                break;
                            }
                        case 8:
                            {
                                treeNodeColle["N" + str_DeptIDs[0]].Nodes["N" + str_DeptIDs[1]].Nodes["N" + str_DeptIDs[2]].
                                    Nodes["N" + str_DeptIDs[3]].Nodes["N" + str_DeptIDs[4]].Nodes["N" + str_DeptIDs[5]].
                                    Nodes["N" + str_DeptIDs[6]].Nodes["N"+str_DeptIDs[7]].Nodes.Add(key, str_DeptName);
                                break;
                            }
                        case 9:
                            {
                                treeNodeColle["N" + str_DeptIDs[0]].Nodes["N" + str_DeptIDs[1]].Nodes["N" + str_DeptIDs[2]].
                                    Nodes["N" + str_DeptIDs[3]].Nodes["N" + str_DeptIDs[4]].Nodes["N" + str_DeptIDs[5]].
                                    Nodes["N" + str_DeptIDs[6]].Nodes["N" + str_DeptIDs[7]].Nodes["N"+str_DeptIDs[8]].Nodes.Add(key, str_DeptName);
                                break;
                            }
                        case 10://只有10个父级
                            {
                                treeNodeColle["N" + str_DeptIDs[0]].Nodes["N" + str_DeptIDs[1]].Nodes["N" + str_DeptIDs[2]].
                                    Nodes["N" + str_DeptIDs[3]].Nodes["N" + str_DeptIDs[4]].Nodes["N" + str_DeptIDs[5]].
                                    Nodes["N" + str_DeptIDs[6]].Nodes["N" + str_DeptIDs[7]].Nodes["N" + str_DeptIDs[8]].
                                    Nodes["N"+str_DeptIDs[9]].Nodes.Add(key, str_DeptName);
                                break;
                            }
                        case 11:
                            {
                                treeNodeColle["N" + str_DeptIDs[0]].Nodes["N" + str_DeptIDs[1]].Nodes["N" + str_DeptIDs[2]].
                                    Nodes["N" + str_DeptIDs[3]].Nodes["N" + str_DeptIDs[4]].Nodes["N" + str_DeptIDs[5]].
                                    Nodes["N" + str_DeptIDs[6]].Nodes["N" + str_DeptIDs[7]].Nodes["N" + str_DeptIDs[8]].
                                    Nodes["N" + str_DeptIDs[9]].Nodes["N"+str_DeptIDs[10]].Nodes.Add(key, str_DeptName);
                                break;
                            }
                    }
                    #endregion
                }
                #endregion
            }
            #endregion
        }
        #region 根据DeptID检索DataRow
        /// <summary>
        /// 根据DeptID检索DataRow,递归计算
        /// </summary>
        /// <param name="tem_dt">记录集</param>
        /// <param name="int_DeptID">索引号</param>
        /// <param name="str_Dept_Info_DeptIDs">累计的父级的DeptID</param>
        /// <returns>DataRow</returns>
        private string GetParentDepKey(DataTable tem_dt, int int_DeptID, string str_Dept_Info_DeptIDs)
        {
            string str_tem_DeptID = "";
            DataRow[] drs;
            drs = tem_dt.Select("DeptID=" + int_DeptID);

            int int_DeptLevelID = (int)drs[0]["DeptLevelID"];
            if (int_DeptLevelID != 1)
            {
                str_tem_DeptID = GetParentDepKey(tem_dt, (int)drs[0]["ParentDeptID"], str_Dept_Info_DeptIDs);//递归
                str_Dept_Info_DeptIDs = str_tem_DeptID + "," + drs[0]["DeptID"].ToString();//累计父级ID
            }
            else
            {
                str_Dept_Info_DeptIDs = drs[0]["DeptID"].ToString();//获取顶级的父亲的ID
            }
            return str_Dept_Info_DeptIDs;
        }
        #endregion
    }//class
}//namespace