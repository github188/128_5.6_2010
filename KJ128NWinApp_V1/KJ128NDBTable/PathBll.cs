using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;
using KJ128NModel;
using KJ128NDBTable;

namespace KJ128NDBTable
{
    /*
    * ����
    */

    #region [PathInfoBll]

    /// <summary>
    /// 
    /// </summary>
    public class PathInfoBll
    {
        private PathInfoDal pathInfodal = new PathInfoDal();

        /// <summary>
        /// ����Path_Info
        /// </summary>
        /// <param name="strCondition">��ѯ����</param>
        /// <returns>���صļ�¼����Ϣ</returns>
        public DataTable SelectPathInfo(string strCondition)
        {
            if (pathInfodal == null)
            {
                pathInfodal = new PathInfoDal();
            }

            DataTable dt = pathInfodal.SelectPathInfo(strCondition);
            return dt;
        }

        /// <summary>
        /// ����Path_Info
        /// </summary>
        /// <param name="pathInfo">��·��Ϣ�����</param>
        /// <returns>�˴β���Ӱ�������</returns>
        public int InsertPathInfo(PathInfoModel pathInfo,out string strMessage)
        {
            if (pathInfodal == null)
            {
                pathInfodal = new PathInfoDal();
            }

            int result = pathInfodal.InsertPathInfo(pathInfo,out strMessage);
            return result;
        }

        /// <summary>
        /// �޸�Path_Info
        /// </summary>
        /// <param name="pathInfo">��·��Ϣ�����</param>
        /// <returns>�˴β���Ӱ�������</returns>
        public int UpdatePathInfo(PathInfoModel pathInfo,out string strMessage)
        {
            if (pathInfodal == null)
            {
                pathInfodal = new PathInfoDal();
            }

            int result = pathInfodal.UpdatePathInfo(pathInfo,out strMessage);
            return result;
        }

        /// <summary>
        /// ɾ��Path_Info
        /// </summary>
        /// <param name="id">��·Id</param>
        /// <returns>�˴β���Ӱ�������</returns>
        public int DeletePathInfo(int id)
        {
            if (pathInfodal == null)
            {
                pathInfodal = new PathInfoDal();
            }

            int result = pathInfodal.DeletePathInfo(id);
            return result;
        }

        public DataTable GetEmpInfo(string deptID)
        {
            if (pathInfodal == null)
            {
                pathInfodal = new PathInfoDal();
            }

            DataSet ds = pathInfodal.GetEmpInfo(deptID);
            DataTable dt;
            if (ds == null || ds.Tables.Count < 0)
            {
                dt = new DataTable();
            }
            else
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        #region [ ����: ������б��ĺ��� ]

        public void PathInfo_BindComboBox(ComboBox CB)
        {
            try
            {
                DataTable dt = SelectPathInfo("");

                DataRow dr = dt.NewRow();
                dr["PathName"] = "ѡ��";
                dr["PathNo"] = "ѡ��";
                dt.Rows.InsertAt(dr, 0);
                dt.AcceptChanges();

                CB.DataSource = dt;
                CB.DisplayMember = "PathNo";
                CB.ValueMember = "PathName";
            }
            catch
            { }
        }


        public void EmpInfo_BindComboBox(ComboBox CB,string deptID)
        {
            try
            {
                DataTable dt = GetEmpInfo(deptID);

                DataRow dr = dt.NewRow();
                dr["EmpName"] = "��";
                dr["EmpID"] = "0";
                dt.Rows.InsertAt(dr, 0);
                dt.AcceptChanges();

                CB.DataSource = dt;
                CB.DisplayMember = "EmpName";
                CB.ValueMember = "EmpID";
            }
            catch
            { }
        }
        #endregion

        #region ��������������TreeView����ʾ��·�߱���Ϣ��
        /// <summary>
        /// ��ȡ��TreeView����ʾ��·�߱�
        /// </summary>
        public DataTable getPathInfoTreeViewTable()
        {
            //��ȡ���Ʊ�����
            DataTable dtPathInfo = null;
            try
            {
                dtPathInfo = SelectPathInfo("");
            }
            catch { }
            //��������ṹ
            DataTable dt = new DegonControlLib.TreeViewControl().BuildMenusEntity();

            DataRow dr = dt.NewRow();
            setDataRow(ref dr, "0", "����", "-1", false, false, 0);
            dt.Rows.Add(dr);
            if (dtPathInfo != null)
            {
                foreach (DataRow dr1 in dtPathInfo.Rows)
                {
                    dr = dt.NewRow();
                    setDataRow(ref dr, dr1["id"].ToString(), dr1["PathName"].ToString(), "0", true, false, 0);
                    dt.Rows.Add(dr);
                }
            }
            dt.AcceptChanges();
            return dt;
        }

        private void setDataRow(ref DataRow dr, string id, string name, string parentid, bool isChild, bool isUserNum, int num)
        {
            dr[0] = id;
            dr[1] = name;
            dr[2] = parentid;
            dr[3] = isChild;
            dr[4] = isUserNum;
            dr[5] = num;
        }
        #endregion

        #region ��������������TreeView����ʾ�Ķ�����վ��Ϣ��
        /// <summary>
        /// ��ȡTreeView�еĶ�����վ��Ϣ
        /// </summary>
        /// <returns></returns>
        public DataTable getStationTreeViewTable(string pathNo)
        {
            //��ȡ���Ʊ�����
            DataTable dtStationInfo = null;
            try
            {
                dtStationInfo = pathInfodal.GetStationTreeTable(pathNo).Tables[0];
            }
            catch { }
            //��������ṹ
            DataTable dt;
            if (dtStationInfo == null || dtStationInfo.Rows.Count <= 0)
            {
                dt = new DegonControlLib.TreeViewControl().BuildMenusEntity();
            }
            else
            {
                dt = dtStationInfo;
            }

            return dt;
        }

        /// <summary>
        /// ��ȡTreeView�еĶ�����վ��Ϣ
        /// </summary>
        /// <returns></returns>
        public DataTable getStationTreeViewTable()
        {
            //��ȡ���Ʊ�����
            DataTable dtStationInfo = null;
            try
            {
                dtStationInfo = pathInfodal.GetStationTreeTable().Tables[0];
            }
            catch { }
            //��������ṹ
            DataTable dt;
            if (dtStationInfo == null || dtStationInfo.Rows.Count <= 0)
            {
                dt = new DegonControlLib.TreeViewControl().BuildMenusEntity();
            }
            else
            {
                dt = dtStationInfo;
            }

            return dt;
        }
        #endregion

        #region ����������ȡ������վ��Ϣ��
        public DataTable getStationHeadTable(string strPathNo)
        {
            //��ȡ���Ʊ�����
            DataTable dtStationInfo = null;
            try
            {
                dtStationInfo = pathInfodal.GetStationHeadTable(strPathNo).Tables[0];
            }
            catch { }
            //��������ṹ
            DataTable dt;
            if (dtStationInfo == null || dtStationInfo.Rows.Count <= 0)
            {
                dt = new DataTable();
            }
            else
            {
                dt = dtStationInfo;
            }

            return dt;
        }
        #endregion

        #region ����������ѯѲ��·����
        /// <summary>
        /// ��ѯѲ��·��
        /// </summary>
        /// <param name="strWhere"></param>
        public DataTable SelectPathDetail(string strWhere)
        {
            if (pathInfodal == null)
            {
                pathInfodal = new PathInfoDal();
            }

            DataTable dt = pathInfodal.SelectPathDetailInfo(strWhere);
            return dt;
        }
        #endregion

        #region ��������ɾ��Ѳ��·����
        public void DeletePathDetail(int id, string pathNo)
        {
            if (pathInfodal == null)
            {
                pathInfodal = new PathInfoDal();
            }

            pathInfodal.DeletePathDetail(id, pathNo);
        }

        public void DeletePathDetail(string pathNo, int stationAddress, int stationHeadAddress)
        {
            if (pathInfodal == null)
            {
                pathInfodal = new PathInfoDal();
            }

            pathInfodal.DeletePathDetail(pathNo, stationAddress, stationHeadAddress);
        }
        #endregion

        #region �����������Ѳ��·����
        /// <summary>
        /// ���Ѳ��·��
        /// </summary>
        /// <param name="pathDetail"></param>
        /// <returns></returns>
        public int InsertPathDetail(PathDetailModel pathDetail)
        {
            if (pathInfodal == null)
            {
                pathInfodal = new PathInfoDal();
            }

            int result = pathInfodal.InsertPathDetail(pathDetail);
            return result;
        }
        #endregion

        #region ����������ѯ��ԱѲ�졿
        /// <summary>
        /// ��ѯѲ��·��
        /// </summary>
        /// <param name="strPathNo">·�߱��</param>
        public DataTable SelectPathEmpRelation(string strPathNo)
        {
            if (pathInfodal == null)
            {
                pathInfodal = new PathInfoDal();
            }

            DataTable dt = new DataTable();
            DataSet ds = pathInfodal.GetPathEmpRelationTable(strPathNo);
            if (ds!=null && ds.Tables.Count>0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        #endregion

        public DataTable GetTreeDt(string st1, string st2,string tid)
        {
            return pathInfodal.GetTreeDt(st1,st2,tid);
        }
        public DataTable GetEmp_by(string codeid, string rname, string banci, string kssj, string jssj, string pathid)
        {
            return pathInfodal.GetEmp_by( codeid,  rname,  banci,  kssj,  jssj,  pathid);
        }
        public DataTable GetTreeDtReal(string tid)
        {
            return pathInfodal.GetTreeDtReal(tid);
        }
        public DataTable GetEmpReal_by(string codeid, string rname, string banci,  string pathid)
        {
            return pathInfodal.GetEmpReal_by(codeid, rname, banci, pathid);
        }
    }

    #endregion

    #region [Path_DetailBll]

    public class PathDetailBll
    {
        private PathDetailDal pathDetailDal = new PathDetailDal();

        /// <summary>
        /// ����PathDetail��Ϣ
        /// </summary>
        /// <param name="strCondition">��ѯ����</param>
        /// <returns>���صļ�¼����Ϣ</returns>
        public DataTable SelectPathDetail(string strCondition)
        {
            if (pathDetailDal == null)
            {
                pathDetailDal = new PathDetailDal();
            }
            DataTable dt = pathDetailDal.SelectPathDetail(strCondition);
            return dt;
        }

        /// <summary>
        /// ����PathDetail��Ϣ
        /// </summary>
        /// <param name="pathDetail">��·������Ϣ�����</param>
        /// <returns>�˴β���Ӱ�������</returns>
        public int InsertPathDetail(PathDetailModel pathDetail)
        {
            if (pathDetailDal == null)
            {
                pathDetailDal = new PathDetailDal();
            }
            int result = pathDetailDal.InsertPathDetail(pathDetail);
            return result;
        }

        /// <summary>
        /// �޸�PathDetail��Ϣ
        /// </summary>
        /// <param name="pathDetail">��·������Ϣ�����</param>
        /// <returns>�˴β���Ӱ�������</returns>
        public int UpdatePathDetail(PathDetailModel pathDetail)
        {
            if (pathDetailDal == null)
            {
                pathDetailDal = new PathDetailDal();
            }
            int result = pathDetailDal.UpdatePathDetail(pathDetail);
            return result;
        }

        /// <summary>
        /// ɾ��PathDetail��Ϣ
        /// </summary>
        /// <param name="id">��¼Id</param>
        /// <returns>�˴β���Ӱ�������</returns>
        public int DeletePathDetail(int id)
        {
            if (pathDetailDal == null)
            {
                pathDetailDal = new PathDetailDal();
            }
            int result = pathDetailDal.DeletePathDetail(id);
            return result;
        }
    }

    #endregion

    #region [PathEmpRelationBll]

    public class PathEmpRelationBll
    {
        private PathEmpRelationDal pathEmpRelationDal = new PathEmpRelationDal();

        /// <summary>
        /// ����PathEmpRelation��Ϣ
        /// </summary>
        /// <param name="strCondition">��ѯ����</param>
        /// <returns>���صļ�¼����Ϣ</returns>
        public DataTable SelectPathEmpRelation(string strCondition)
        {
            if (pathEmpRelationDal == null)
            {
                pathEmpRelationDal = new PathEmpRelationDal();
            }

            DataTable dt = pathEmpRelationDal.SelectPathEmpRelation(strCondition);
            return dt;
        }

        /// <summary>
        /// ����PathEmpRelation��Ϣ
        /// </summary>
        /// <param name="pathEmpRelation">��·Ա����ϵ�����</param>
        /// <returns>�˴β���Ӱ�������</returns>
        public int InsertPathEmpRelation(PathEmpRelationModel pathEmpRelation,out string strMessage)
        {
            if (pathEmpRelationDal == null)
            {
                pathEmpRelationDal = new PathEmpRelationDal();
            }

            int result = pathEmpRelationDal.InsertPathEmpRelation(pathEmpRelation,out strMessage);
            return result;
        }

        /// <summary>
        /// ����PathEmpRelation��Ϣ
        /// </summary>
        /// <param name="pathEmpRelation">��·Ա����ϵ�����</param>
        /// <returns>�˴β���Ӱ�������</returns>
        public int InsertPathEmpRelation_cjg(PathEmpRelationModel pathEmpRelation)
        {
            if (pathEmpRelationDal == null)
            {
                pathEmpRelationDal = new PathEmpRelationDal();
            }

            int result = pathEmpRelationDal.InsertPathEmpRelation_cjg(pathEmpRelation);
            return result;
        }

        /// <summary>
        /// �޸�PathEmpRelation��Ϣ
        /// </summary>
        /// <param name="pathEmpRelation">��·Ա����ϵ�����</param>
        /// <returns>�˴β���Ӱ�������</returns>
        public int UpdatePathEmpRelation(PathEmpRelationModel pathEmpRelation,out string strMessage)
        {
            if (pathEmpRelationDal == null)
            {
                pathEmpRelationDal = new PathEmpRelationDal();
            }

            int result = pathEmpRelationDal.UpdatePathEmpRelation(pathEmpRelation,out strMessage);
            return result;
        }

        /// <summary>
        /// �޸�PathEmpRelation��Ϣ
        /// </summary>
        /// <param name="pathEmpRelation">��·Ա����ϵ�����</param>
        /// <returns>�˴β���Ӱ�������</returns>
        public int UpdatePathEmpRelation_cjg(PathEmpRelationModel pathEmpRelation)
        {
            if (pathEmpRelationDal == null)
            {
                pathEmpRelationDal = new PathEmpRelationDal();
            }
            string strMessage="";
            int result = pathEmpRelationDal.UpdatePathEmpRelation(pathEmpRelation,out strMessage);
            return result;
        }

        /// <summary>
        /// ɾ��PathEmpRelation��Ϣ
        /// </summary>
        /// <param name="id">��¼Id</param>
        /// <returns>�˴β���Ӱ�������</returns>
        public int DeletePathEmpRelation(int id)
        {
            if (pathEmpRelationDal == null)
            {
                pathEmpRelationDal = new PathEmpRelationDal();
            }

            int result = pathEmpRelationDal.DeletePathEmpRelation(id);
            return result;
        }
    }

    #endregion

    #region [RealTimeAlarmPathBll]
    //public class RealTimeAlarmPathBll
    //{
    //    private RealTimeAlarmPathDal dal = new RealTimeAlarmPathDal();

    //    public int DeleteRealTimeAlarmPathByEmpNo(string empNO)
    //    {
    //        if (dal == null)
    //        {
    //            dal = new RealTimeAlarmPathDal();
    //        }

    //        return dal.DeleteRealTimeAlarmPathByEmpNo(empNO);
    //    }
    //}
    #endregion

    #region [HisPathAlertBll]

    public class HisPathAlertBll
    {
        private HisPathAlertDal hisPathAlertDal = new HisPathAlertDal();

        /// <summary>
        /// ����HisPathAlert
        /// </summary>
        /// <param name="strCondition">��ѯ����</param>
        /// <returns>���صļ�¼����Ϣ</returns>
        public DataTable SelectHisPathAlert(string strCondition)
        {
            if (hisPathAlertDal == null)
            {
                hisPathAlertDal = new HisPathAlertDal();
            }

            DataTable dt = hisPathAlertDal.SelectHisPathAlert(strCondition);
            return dt;
        }

        /// <summary>
        /// ����HisPathAlert
        /// </summary>
        /// <param name="hisPathAlert">��ʷ��·���������</param>
        /// <returns>�˴β���Ӱ�������</returns>
        public int InsertHisPathAlert(HisPathAlertModel hisPathAlert)
        {
            if (hisPathAlertDal == null)
            {
                hisPathAlertDal = new HisPathAlertDal();
            }

            int result = hisPathAlertDal.InsertHisPathAlert(hisPathAlert);
            return result;
        }

        /// <summary>
        /// ɾ��HisPathAlert
        /// </summary>
        /// <param name="id">��¼Id</param>
        /// <returns>�˴β���Ӱ�������</returns>
        public int DeleteHisPathAlert(int id)
        {
            if (hisPathAlertDal == null)
            {
                hisPathAlertDal = new HisPathAlertDal();
            }

            int result = hisPathAlertDal.DeleteHisPathAlert(id);
            return result;
        }
    }

    #endregion

    #region [RealTimePathCheckBll]

    public class RealTimePathCheckBll
    {
        private RealTimePathCheckDal dal = new RealTimePathCheckDal();

        /// <summary>
        /// ��·�߲�ѯRealTimePathCheck
        /// </summary>
        /// <param name="strCondition">·�߱��</param>
        /// <returns>���صļ�¼����Ϣ</returns>
        public DataTable SelectRealTimePathCheckByPath(string pathNo)
        {
            if (dal == null)
            {
                dal = new RealTimePathCheckDal();
            }

            DataTable dt = dal.SelectRealTimePathCheckByPath(pathNo);
            return dt;
        }

        /// <summary>
        /// ����β�ѯRealTimePathCheck
        /// </summary>
        /// <param name="interval">���id</param>
        /// <returns>���صļ�¼����Ϣ</returns>
        public DataTable SelectRealTimePathCheckByInterval(int interval)
        {
            if (dal == null)
            {
                dal = new RealTimePathCheckDal();
            }

            DataTable dt = dal.SelectRealTimePathCheckByInterval(interval);
            return dt;
        }


        /// <summary>
        /// ����RealTimePathCheck
        /// </summary>
        /// <param name="hisPathAlert">��ʷ��·���������</param>
        /// <returns>�˴β���Ӱ�������</returns>
        public int InsertRealTimePathCheck(RealTimePathCheckModel model)
        {
            if (dal == null)
            {
                dal = new RealTimePathCheckDal();
            }

            int result = dal.InsertRealTimePathCheck(model);
            return result;
        }

        /// <summary>
        /// ����RealTimePathCheck
        /// </summary>
        /// <param name="model">RealTimePathCheckModel</param>
        /// <returns>����ִ�н������</returns>
        public int UpdateRealTimePathCheck(RealTimePathCheckModel model)
        {
            if (dal == null)
            {
                dal = new RealTimePathCheckDal();
            }

            int result = dal.UpdateRealTimePathCheck(model);
            return result;
        }

        /// <summary>
        /// ɾ��RealTimePathCheck
        /// </summary>
        /// <param name="id">��¼Id</param>
        /// <returns>�˴β���Ӱ�������</returns>
        public int DeleteRealTimePathCheck(int id)
        {
            if (dal == null)
            {
                dal = new RealTimePathCheckDal();
            }

            int result = dal.DeleteRealTimePathCheck(id);
            return result;
        }


        public DataTable GetTimeInterval()
        {
            if (dal == null)
            {
                dal = new RealTimePathCheckDal();
            }

            return dal.GetTimeInterval();
        }
    }

    #endregion

    #region [HisPathCheckBll]

    public class HisPathCheckBll
    {
        private HisPathCheckDal dal = new HisPathCheckDal();

        /// <summary>
        /// ��ѯHisPathCheckDal
        /// </summary>
        /// <param name="strCondition">��ѯ����</param>
        /// <returns>���صļ�¼����Ϣ</returns>
        public DataTable SelectHisPathCheckByPath(string pathNo)
        {
            if (dal == null)
            {
                dal = new HisPathCheckDal();
            }

            DataTable dt = dal.SelectHisPathCheckByPath(pathNo);
            return dt;
        }

        public DataTable SelectHisPathCheckInterval(int interval)
        {
            if (dal == null)
            {
                dal = new HisPathCheckDal();
            }

            DataTable dt = dal.SelectHisPathCheckByInterval(interval);
            return dt;
        }

        public DataTable SelectEmpPassInfo(int EmpID, DateTime beginTime)
        {
            if (dal == null)
            {
                dal = new HisPathCheckDal();
            }

            DataTable dt = dal.SelectEmpPassInfo(EmpID, beginTime);
            return dt;
        }

        /// <summary>
        /// ����HisPathCheckDal
        /// </summary>
        /// <param name="hisPathAlert">��ʷ��·���������</param>
        /// <returns>�˴β���Ӱ�������</returns>
        public int InsertHisPathCheck(HisPathCheckModel model)
        {
            if (dal == null)
            {
                dal = new HisPathCheckDal();
            }

            int result = dal.InsertHisPathCheck(model);
            return result;
        }

        /// <summary>
        /// ����HisPathCheckDal
        /// </summary>
        /// <param name="model">HisPathCheckModel</param>
        /// <returns>����ִ�н������</returns>
        public int UpdateHisPathCheck(HisPathCheckModel model)
        {
            if (dal == null)
            {
                dal = new HisPathCheckDal();
            }

            int result = dal.UpdateHisPathCheck(model);
            return result;
        }

        /// <summary>
        /// ɾ��HisPathCheckDal
        /// </summary>
        /// <param name="id">��¼Id</param>
        /// <returns>�˴β���Ӱ�������</returns>
        public int DeleteHisPathCheck(int id)
        {
            if (dal == null)
            {
                dal = new HisPathCheckDal();
            }

            int result = dal.DeleteHisPathCheck(id);
            return result;
        }


        public DataTable GetTimeInterval()
        {
            if (dal == null)
            {
                dal = new HisPathCheckDal();
            }

            return dal.GetTimeInterval();
        }
    }
    #endregion
}
