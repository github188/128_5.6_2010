using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
     public class A_RT_PathCheckDAL
    {
         private DBAcess db = new DBAcess();

         public DataSet A_RT_PathCheck(string StrWhere)
         {
             string sql = "SELECT r.ID, dbo.CodeSender_Set.CodeSenderAddress AS 标识卡号, e.EmpName AS 姓名,wtif.WtName as 工种,"
                 +"dbo.Dept_Info.DeptName AS 部门,du.DutyName 职务, t.IntervalName AS 班次," 
                 +"dbo.Path_Info.PathName AS 巡检路线, r.CheckTime AS 开始巡检时间, "
                 +"dbo.RealTimeCodeSender.LastPlace AS 现处位置, " 
                 +"dbo.RealTimeCodeSender.StationHeadDetectTime AS 入现处位置时间, r.EmpID,  "
                 +"dbo.Path_Info.Id AS pid, t.ID AS tid  "
                 +"FROM dbo.Path_Info INNER JOIN " 
                 +"dbo.RealTimePathCheck r INNER JOIN  "
                 +"dbo.Emp_Info e ON r.EmpID = e.EmpID left join "
                 +"dbo.Emp_NowCompany as enow on e.EmpID=enow.EmpID left join  "
                 +"dbo.Duty_Info as du on enow.DutyID=du.DutyID LEFT  JOIN  "
                 +"dbo.Path_Emp_Relation p ON r.EmpID = p.EmpID left JOIN  "
                 +"dbo.Emp_WorkType as empw on  p.EmpID=empw.EmpID left join "
                 +"dbo.WorkType_Info as wtif on empw.WorkTypeID=wtif.WorkTypeID left join "
                 +"dbo.TimerInterval t ON r.[Interval] = t.ID INNER JOIN  "
                 +"dbo.CodeSender_Set ON e.EmpID = dbo.CodeSender_Set.UserID ON " 
                 +"dbo.Path_Info.PathNo = p.PathNo INNER JOIN  "
                 +"dbo.RealTimeCodeSender ON  "
                 +"dbo.CodeSender_Set.CsSetID = dbo.RealTimeCodeSender.CsSetID LEFT  JOIN  "
                 +"dbo.Dept_Info INNER JOIN  "
                 + "dbo.Emp_NowCompany ON  "
                 +"dbo.Dept_Info.DeptID = dbo.Emp_NowCompany.DeptID ON "
                 +"e.EmpID = dbo.Emp_NowCompany.EmpID where " + StrWhere;
             return db.GetDataSet(sql);
     
         }
    }
}
