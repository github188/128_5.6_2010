using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace KJ128NDBTable
{
    public class A_TreeBLL
    {

        //无刷树
        #region【方法：统计子节点的人数】

        private int GetCounts(DataTable dt, string strID)
        {
            int intCounts = 0;
            DataRow[] drT = dt.Select("ParentID = '" + strID + "'");
            if (drT.Length > 0)
            {
                for (int i = 0; i < drT.Length; i++)
                {
                    intCounts = intCounts + Convert.ToInt32(drT[i]["Num"].ToString()) + GetCounts(dt, drT[i]["ID"].ToString());

                }
            }
            return intCounts;
        }

        #endregion

        #region【方法：判断是否有子节点】

        /// <summary>
        /// 是否有子节点
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="strID"></param>
        /// <returns></returns>
        private bool IsChildNode(DataTable dt, string strID)
        {
            DataRow[] dr = dt.Select("ParentID='" + strID + "'");
            if (dr.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region【方法：更新树的节点】

        private void AddTreeNode(TreeNode tr, string id, DataTable dt, string strText)
        {
            DataRow[] dr = dt.Select("ParentID='" + id + "'");
            string strID_Temp;

            if (tr.Nodes.Count >= dr.Length)
            {
                for (int i = 0; i < tr.Nodes.Count; i++)
                {
                    string strIsUserNum = dr[i]["IsUserNum"].ToString();
                    strID_Temp = dr[i]["ID"].ToString();

                    if (tr.Nodes.ContainsKey(strID_Temp))
                    {
                        if (strIsUserNum.ToLower().Equals("true"))
                        {
                            if (IsChildNode(dt, dr[i]["ID"].ToString()))
                            {
                                tr.Nodes[strID_Temp].Text = dr[i]["Name"].ToString() + "( " + dr[i]["Num"].ToString() + " + " + GetCounts(dt, dr[i]["ID"].ToString()).ToString() + " " + strText + ")";
                            }
                            else
                            {
                                tr.Nodes[strID_Temp].Text = dr[i]["Name"].ToString() + "( " + dr[i]["Num"].ToString() + " " + strText + ")";
                            }
                        }
                        else
                        {
                            tr.Nodes[strID_Temp].Text = dr[i]["Name"].ToString();
                        }
                        tr.Nodes[strID_Temp].ImageKey = dr[i]["ID"].ToString();
                        tr.Nodes[strID_Temp].Tag = dr[i]["Name"].ToString();

                        AddTreeNode(tr.Nodes[strID_Temp], dr[i]["ID"].ToString(), dt, strText);
                    }
                    else
                    {
                        tr.Nodes.RemoveByKey(strID_Temp);
                    }
                }
            }
            else
            {
                for (int i = 0; i < dr.Length; i++)
                {
                    strID_Temp = dr[i]["ID"].ToString();

                    if (tr.Nodes.ContainsKey(strID_Temp))
                    {
                        string strIsUserNum = dr[i]["IsUserNum"].ToString();
                        if (strIsUserNum.ToLower().Equals("true"))
                        {
                            if (IsChildNode(dt, dr[i]["ID"].ToString()))
                            {
                                tr.Nodes[strID_Temp].Text = dr[i]["Name"].ToString() + "( " + dr[i]["Num"].ToString() + " + " + GetCounts(dt, dr[i]["ID"].ToString()).ToString() + " " + strText + ")";
                            }
                            else
                            {
                                tr.Nodes[strID_Temp].Text = dr[i]["Name"].ToString() + "( " + dr[i]["Num"].ToString() + " " + strText + ")";
                            }
                        }
                        else
                        {
                            tr.Nodes[strID_Temp].Text = dr[i]["Name"].ToString();
                        }
                        tr.Nodes[strID_Temp].ImageKey = dr[i]["ID"].ToString();
                        tr.Nodes[strID_Temp].Tag = dr[i]["Name"].ToString();

                        AddTreeNode(tr.Nodes[strID_Temp], dr[i]["ID"].ToString(), dt, strText);
                    }
                    else
                    {
                        string strIsUserNum = dr[i]["IsUserNum"].ToString();
                        if (strIsUserNum.ToLower().Equals("true"))
                        {
                            if (IsChildNode(dt, dr[i]["ID"].ToString()))
                            {
                                tr.Nodes.Add(strID_Temp, dr[i]["Name"].ToString() + "( " + dr[i]["Num"].ToString() + " + " + GetCounts(dt, dr[i]["ID"].ToString()).ToString() + " " + strText + ")", dr[i]["ID"].ToString());
                            }
                            else
                            {
                                tr.Nodes.Add(strID_Temp, dr[i]["Name"].ToString() + "( " + dr[i]["Num"].ToString() + " " + strText + ")", dr[i]["ID"].ToString());
                            }
                        }
                        else
                        {
                            tr.Nodes.Add(strID_Temp, dr[i]["Name"].ToString());
                        }
                        tr.Nodes[strID_Temp].Tag = dr[i]["Name"].ToString();
                        AddTreeNode(tr.Nodes[strID_Temp], dr[i]["ID"].ToString(), dt, strText);
                    }
                }
            }
        }

        #endregion

        #region【方法：添加树】

        public void AddTreeRoot(TreeView tr, DataSet ds, string strHead, string strText)
        {
            TreeNode tnTree = new TreeNode();

            tnTree.Text = strHead;
            tnTree.Name = "0";
            tnTree.Tag = strHead;

            if (!tr.Nodes.ContainsKey(tnTree.Name))
            {
                tr.Nodes.Add(tnTree);
            }
            if (ds != null && ds.Tables.Count > 0)
            {

                tr.Nodes[tnTree.Name].Text = strHead + " ( " + GetCounts(ds.Tables[0], "0").ToString() + " " + strText + ")";

                AddTreeNode(tr.Nodes[tnTree.Name], "0", ds.Tables[0], strText);
            }
            else
            {
                tnTree.Text = strHead + " ( 0 " + strText + ")";
            }
        }

        #endregion


        //老蔡树
        #region【方法：自定义树的表的行结构】

        private void SetDataRow(ref DataRow dr, int id, string name, int parentid, bool isChild, bool isUserNum, int num)
        {
            dr[0] = id;
            dr[1] = name;
            dr[2] = parentid;
            dr[3] = isChild;
            dr[4] = isUserNum;
            dr[5] = num;
        }

        #endregion

        #region 【方法：初始化部门树（查询）】

        /// <summary>
        /// 初始化部门树
        /// </summary>
        public void LoadTree(DegonControlLib.TreeViewControl tvc, DataSet dsTemp, string strName, bool blCount, string strHeadTip)
        {
            if (tvc.Nodes.Count > 0)
            {
                tvc.Nodes.Clear();
            }
            DataTable dt;

            if (dsTemp != null && dsTemp.Tables.Count > 0)
            {
                dt = dsTemp.Tables[0];
            }
            else
            {
                dt = tvc.BuildMenusEntity();
            }

            DataRow dr = dt.NewRow();

            SetDataRow(ref dr, 0, strHeadTip, -1, false, blCount, 0);

            dt.Rows.Add(dr);

            tvc.DataSouce = dt;
            tvc.LoadNode(strName);


            tvc.ExpandAll();
            tvc.SelectedNode = tvc.Nodes[0];
            tvc.SetSelectNodeColor();
        }

        #endregion

    }
}
