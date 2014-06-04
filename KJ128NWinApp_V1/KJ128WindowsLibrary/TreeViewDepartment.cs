using System;
using System.Windows.Forms;
using System.Collections;
using System.Data;
namespace KJ128WindowsLibrary
{
    /// <summary>
    /// �벿�Ű󶨵�TreeView
    /// </summary>
    public class TreeViewDepartment:TreeView
    {
       /// <summary>
       /// �̳е�TreeView�����캯��
       /// </summary>
        public TreeViewDepartment():base()
        {
            
        }
       
        /// <summary>
        /// ���ݲ��ű��е���Ϣ����ӵ�TreeView�ڵ�
        /// </summary>
        /// <param name="dt">���ű����Ϣ</param>
        public void ReadDept_Info(DataTable dt)
        {
            this.Nodes.Add("root", "����");//Ĭ����һ��ȫ���ĸ��ڵ�
            DataTable dt_tem = dt;//��ȡ���ڴ��е���ʱ�����ڼ����ϼ��ļ�¼
            //��ȡTreeNode����
            TreeNodeCollection treeNodeColle = this.Nodes["root"].Nodes;
            //�������в���
            #region �������в���
            foreach (DataRow dr in dt.Rows)
            {
                int int_DeptId = (int)dr["DeptID"];//����ID
                int int_ParentDeptID = (int)dr["ParentDeptID"];//������ID,û�и�������Ϊ0
                string str_DeptName = (string)dr["DeptName"];//��������
                string key = "N" + int_DeptId;//treeNode ��key 
                #region ����ӽڵ�
                if (int_ParentDeptID == 0)//û�и�����
                {
                    treeNodeColle.Add(key, str_DeptName);//���һ�����ڵ�
                }
                else
                {
                    string str_key = "N" + int_ParentDeptID;//node key ȡ������key
                    string[] str_DeptIDs;//����ж���ϼ����򽫶���ϼ���������ʽ�洢
                    string str_DeptID; //�洢����ϼ�����,�ָ��洢���ַ���
                    str_DeptID = GetParentDepKey(dt_tem, int_ParentDeptID, "");//����DeptID����DataRow,���Ի�ȡ���и����������ַ�������
                    str_DeptIDs = str_DeptID.Split(new char[] { ',' });//������еĸ���
                    #region �ж��ж��ٸ���
                    switch (str_DeptIDs.Length)//�ж��ж��ٸ���
                    {
                        case 1://ֻ��һ������
                            {
                                treeNodeColle[str_key].Nodes.Add(key, str_DeptName);
                                break;
                            }
                        case 2://ֻ����������
                            {
                                treeNodeColle["N" + str_DeptIDs[0]].Nodes["N" + str_DeptIDs[1]].Nodes.Add(key, str_DeptName);
                                break;
                            }
                        case 3://ֻ����������
                            {                         
                                treeNodeColle["N" + str_DeptIDs[0]].Nodes["N" + str_DeptIDs[1]].Nodes["N" + str_DeptIDs[2]].Nodes.Add(key, str_DeptName);
                                break;
                            }
                        case 4://ֻ���ĸ�����
                            {
                                treeNodeColle["N" + str_DeptIDs[0]].Nodes["N" + str_DeptIDs[1]].Nodes["N" + str_DeptIDs[2]].
                                    Nodes["N"+str_DeptIDs[3]].Nodes.Add(key, str_DeptName);
                                break;
                            }
                        case 5://ֻ���������
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
                        case 10://ֻ��10������
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
        #region ����DeptID����DataRow
        /// <summary>
        /// ����DeptID����DataRow,�ݹ����
        /// </summary>
        /// <param name="tem_dt">��¼��</param>
        /// <param name="int_DeptID">������</param>
        /// <param name="str_Dept_Info_DeptIDs">�ۼƵĸ�����DeptID</param>
        /// <returns>DataRow</returns>
        private string GetParentDepKey(DataTable tem_dt, int int_DeptID, string str_Dept_Info_DeptIDs)
        {
            string str_tem_DeptID = "";
            DataRow[] drs;
            drs = tem_dt.Select("DeptID=" + int_DeptID);

            int int_DeptLevelID = (int)drs[0]["DeptLevelID"];
            if (int_DeptLevelID != 1)
            {
                str_tem_DeptID = GetParentDepKey(tem_dt, (int)drs[0]["ParentDeptID"], str_Dept_Info_DeptIDs);//�ݹ�
                str_Dept_Info_DeptIDs = str_tem_DeptID + "," + drs[0]["DeptID"].ToString();//�ۼƸ���ID
            }
            else
            {
                str_Dept_Info_DeptIDs = drs[0]["DeptID"].ToString();//��ȡ�����ĸ��׵�ID
            }
            return str_Dept_Info_DeptIDs;
        }
        #endregion
    }//class
}//namespace