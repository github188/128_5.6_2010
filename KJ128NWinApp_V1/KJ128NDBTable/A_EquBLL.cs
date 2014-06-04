using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class A_EquBLL
    {
        private A_EquDAL dal = new A_EquDAL();

        public DataTable GetEquTypes()
        {
            return dal.GetEquTypes();
        }

        public DataTable GetFactoryNames()
        {
            return dal.GetFactoryNames();
        }

        public DataTable GetFactoryInfo(string factoryid)
        {
            return dal.GetFactoryInfo(factoryid);
        }

        public DataTable GetEquInfo(string equtype)
        {
            return dal.GetEquInfo(equtype);
        }

        public DataTable GetDepts()
        {
            return dal.GetDepts();
        }

        //public DataTable GetEquTypes()
        //{
        //    return dal.GetEquTypes();
        //}

        public DataTable GetEquStates()
        {
            return dal.GetEquStates();
        }

        public DataTable GetEquFactorys()
        {
            return dal.GetEquFactorys();
        }

        public bool IsExitsEquNo(string equno)
        {
            return dal.IsExitsEquNo(equno);
        }

        public bool InsertEquBaseInfo(string equno, string equname, int deptid, string DeptName, int equtype, int equstate, int factoryid, string remark)
        {
            return dal.InsertEquBaseInfo(equno, equname, deptid, DeptName, equtype, equstate, factoryid, remark);
        }

        #region【方法：修改设备基本信息】

        public bool UpdateEquBaseInfo(string equno, string equname, int deptid,string strDeptName, int equtype, int equstate, int factoryid, string remark,string strEquID)
        {
            return dal.UpdateEquBaseInfo(equno, equname, deptid,strDeptName, equtype, equstate, factoryid, remark,strEquID);
        }

        #endregion

        public bool InsertEquDetailInfo(string equno, string ModelSpecial, string DutyEmployee, string UseRange, string ProductionDate, string EquHeight, string EquPower, string UserDate)
        {
            string equid = dal.GetEquIDbyEquno(equno);
            return dal.InsertEquDetailInfo(equid, ModelSpecial, DutyEmployee, UseRange, ProductionDate, EquHeight, EquPower, UserDate);
        }

        #region【方法：修改设备详细信息】

        public bool UpdateEquDetailInfo(string equid, string ModelSpecial, string DutyEmployee, string UseRange, DateTime ProductionDate, string EquHeight, string EquPower, DateTime UserDate)
        {
            return dal.UpdateEquDetailInfo(equid, ModelSpecial, DutyEmployee, UseRange, ProductionDate, EquHeight, EquPower, UserDate);
        }

        #endregion

        public void DelEquInfo(string equno)
        {
            dal.DelEquInfo(equno);
        }

        public DataTable GetEquInfoByEquNO(string equno)
        {
            return dal.GetEquInfoByEquNO(equno);
        }

        public DataTable GetEquDetailInfobyEquNO(string equno)
        {
            string equid = dal.GetEquIDbyEquno(equno);
            return dal.GetEquDetailInfobyEquID(equid);
        }

        public void DelFactory(string factoryno)
        {
            dal.DelFactory(factoryno);
        }

        public bool isExitsFactory(string fno)
        {
            return dal.isExitsFactory(fno);
        }

        public bool InsertFactory(string fno, string fname, string faddress, string ffax, string ftel, string femp, string femptel, string fremark)
        {
            return dal.InsertFactory(fno, fname, faddress, ffax, ftel, femp, femptel, fremark);
        }

        public DataTable GetFactoryByFno(string fno)
        {
            return dal.GetFactoryByFno(fno);
        }

        public bool UpdateFactory(string fno, string fname, string faddress, string ffax, string ftel, string femp, string femptel, string fremark, string strFactoryID)
        {
            return dal.UpdateFactory(fno, fname, faddress, ffax, ftel, femp, femptel, fremark,strFactoryID);
        }


        #region【方法：Czlt-2011-12-10 修改时间】

        public void UpdateTime()
        {
            dal.UpdateTime();
        }
        #endregion
  
    }
}