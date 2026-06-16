using ConnectionModule;
using emujv2Api.Constructor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using static System.Collections.Specialized.BitVector32;

namespace emujv2Api.Model
{
    public class InsertUpdate
    {

        //DELETE

        public string DeleteGangDetails(string StaffId)
        {
            StringBuilder SqlStr = new StringBuilder();
            DataTable Recc = new DataTable();
            MsSql DbCon = new MsSql();
            string Salah = "";
            CommonFunc Conn = new CommonFunc();
            Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

            SqlStr.Append(" DELETE FROM gang_desc WHERE staff_no = @StaffId ");

            ParamTmp.Add("@StaffId", StaffId);


            Recc = DbCon.ExecuteReader(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);
            if (Salah != "") { return Salah; }
            else { return "0"; }
        }

        public string DeleteReport(string RptCode)
        {
            StringBuilder SqlStr = new StringBuilder();
            DataTable Recc = new DataTable();
            MsSql DbCon = new MsSql();
            string Salah = "";
            CommonFunc Conn = new CommonFunc();
            Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

            SqlStr.Append(" DELETE FROM daily_form WHERE rpt_code = @RptCode ");
            SqlStr.Append(" DELETE FROM daily_form_attendancelist WHERE rpt_code = @RptCode ");
            SqlStr.Append(" DELETE FROM daily_form_attendancelistno WHERE rpt_code = @RptCode ");
            SqlStr.Append(" DELETE FROM work_plan WHERE rpt_code = @RptCode ");

            ParamTmp.Add("@RptCode", RptCode);

            Recc = DbCon.ExecuteReader(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);
            if (Salah != "") { return Salah; }
            else { return "0"; }
        }


        public string DeleteFormList(string RptCode)
        {
            StringBuilder SqlStr = new StringBuilder();
            DataTable Recc = new DataTable();
            MsSql DbCon = new MsSql();
            string Salah = "";
            CommonFunc Conn = new CommonFunc();
            Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

            SqlStr.Append(" DELETE FROM daily_form WHERE rpt_code = @RptCode ");

            ParamTmp.Add("@RptCode", RptCode);

            Recc = DbCon.ExecuteReader(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);
            if (Salah != "") { return Salah; }
            else { return "0"; }
        }






        //UPDATE

        public string UpdateUser(string Status, string UserLevel, string Region, string KMUJ, string Section, string StaffId, string UpdBy)
        {
            StringBuilder SqlStr = new StringBuilder();
            DataTable Recc = new DataTable();
            MsSql DbCon = new MsSql();
            string Salah = "";
            CommonFunc Conn = new CommonFunc();
            Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

            SqlStr.Append(" UPDATE staff_login ");
            SqlStr.Append(" SET usrlevel = @UserLevel, ");
            SqlStr.Append(" staff_status = @Status, ");
            SqlStr.Append(" section = @Region, ");
            SqlStr.Append(" muj = @Kmuj, "); 
            SqlStr.Append(" kmuj = @Section, ");
            SqlStr.Append(" upd_date = GETDATE(), ");
            SqlStr.Append(" upd_by = @UpdBy ");
            SqlStr.Append(" WHERE staff_id = @Staffid ");

            ParamTmp.Add("@UserLevel", UserLevel ?? (object)DBNull.Value);
            ParamTmp.Add("@Status", Status ?? (object)DBNull.Value);
            ParamTmp.Add("@Region", Region ?? (object)DBNull.Value);
            ParamTmp.Add("@Kmuj", KMUJ ?? (object)DBNull.Value);
            ParamTmp.Add("@Section", Section ?? (object)DBNull.Value);
            ParamTmp.Add("@StaffId", StaffId);
            ParamTmp.Add("@UpdBy", UpdBy ?? (object)DBNull.Value);

            Recc = DbCon.ExecuteReader(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);
            if (Salah != "") { return Salah; }
            else { return "0"; }
        }

        public string UpdateForm(R1FormCons formCons, string RptCode)
        {
            StringBuilder SqlStr = new StringBuilder();
            DataTable Recc = new DataTable();
            MsSql DbCon = new MsSql();
            string Salah = "";
            CommonFunc Conn = new CommonFunc();
            Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

            string gangString = formCons.Gang != null ? string.Join(",", formCons.Gang) : string.Empty;

            SqlStr.Append(" UPDATE daily_form ");
            SqlStr.Append(" SET daily_gang = @Gang, ");
            SqlStr.Append(" daily_date = @Date, ");
            SqlStr.Append(" daily_worktype = @WorkType, ");
            SqlStr.Append(" daily_total = @Total, ");
            SqlStr.Append(" daily_unit = @TotalUnit, ");
            SqlStr.Append(" daily_timestart = @TimeStart, ");
            SqlStr.Append(" daily_timelast = @TimeLast, ");
            SqlStr.Append(" daily_category = @Category, ");
            SqlStr.Append(" daily_condition = @Condition, ");
            SqlStr.Append(" daily_additional = @Adds, ");
            SqlStr.Append(" daily_timetaken = @TimeTaken, ");
            SqlStr.Append(" effect_kmfrom = @KMFrom, ");
            SqlStr.Append(" effect_kmto = @KMTo, ");
            SqlStr.Append(" effect_kmtotal = @KMTotal, ");
            SqlStr.Append(" station = @Station, ");
            SqlStr.Append(" station_point = @SPoint, ");
            SqlStr.Append(" category_details = @CatDetails, ");
            SqlStr.Append(" temperature = @Temp, ");
            SqlStr.Append(" daily_workers = @Workers + ' pax', ");
            SqlStr.Append(" upd_user = @UpdBy, ");
            SqlStr.Append(" upd_date = GETDATE() ");
            SqlStr.Append(" WHERE rpt_code = @RptCode ");

            ParamTmp.Add("@Gang", string.IsNullOrEmpty(gangString) ? (object)DBNull.Value : gangString);
            ParamTmp.Add("@Date", formCons.Date ?? (object)DBNull.Value);
            ParamTmp.Add("@WorkType", formCons.WorkType ?? (object)DBNull.Value);
            ParamTmp.Add("@Total", formCons.Total ?? (object)DBNull.Value);
            ParamTmp.Add("@TotalUnit", formCons.TotalUnit ?? (object)DBNull.Value);
            ParamTmp.Add("@TimeStart", formCons.TimeStart ?? (object)DBNull.Value);
            ParamTmp.Add("@TimeLast", formCons.TimeLast ?? (object)DBNull.Value);
            ParamTmp.Add("@Category", formCons.Category ?? (object)DBNull.Value);
            ParamTmp.Add("@Condition", formCons.Condition ?? (object)DBNull.Value);
            ParamTmp.Add("@Adds", formCons.Adds ?? (object)DBNull.Value);
            ParamTmp.Add("@TimeTaken", formCons.TimeTaken ?? (object)DBNull.Value);
            ParamTmp.Add("@KMFrom", formCons.KMFrom ?? (object)DBNull.Value);
            ParamTmp.Add("@KMTo", formCons.KMTo ?? (object)DBNull.Value);
            ParamTmp.Add("@KMTotal", formCons.KMTotal ?? (object)DBNull.Value);
            ParamTmp.Add("@Station", formCons.Station ?? (object)DBNull.Value);
            ParamTmp.Add("@SPoint", formCons.SPoint ?? (object)DBNull.Value);
            ParamTmp.Add("@CatDetails", formCons.CatDetails ?? (object)DBNull.Value);
            ParamTmp.Add("@Temp", formCons.Temp ?? (object)DBNull.Value);
            ParamTmp.Add("@RptCode", formCons.RptCode);
            ParamTmp.Add("@Workers", formCons.Workers ?? (object)DBNull.Value);
            ParamTmp.Add("@UpdBy", formCons.UpdBy);
            ParamTmp.Add("@UpdDate", formCons.UpdDate ?? (object)DBNull.Value);

            Recc = DbCon.ExecuteReader(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);
            if (Salah != "") { return Salah; }
            else { return "0"; }
        }

        public string updateDailyAttendList(MasukCons formCons, string Gang)
        {
            StringBuilder SqlStr = new StringBuilder();
            DataTable Recc = new DataTable();
            MsSql DbCon = new MsSql();
            string Salah = "";
            CommonFunc Conn = new CommonFunc();
            Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

            SqlStr.Clear();
            SqlStr.Append(" SELECT staff_no ");
            SqlStr.Append(" FROM gang_desc WHERE staff_status = 'VALID' AND gang_id IN (");

            if (formCons.Gang != null && formCons.Gang.Any())
            {
                for (int i = 0; i < formCons.Gang.Count(); i++)
                {
                    string paramName = "@Gang" + i;
                    SqlStr.Append(paramName);
                    if (i < formCons.Gang.Count() - 1)
                    {
                        SqlStr.Append(", ");
                    }
                    ParamTmp.Add(paramName, formCons.Gang[i]);
                }
                SqlStr.Append(")");
            }
            else
            {
                return "Gang array is null or empty.";
            }

            Recc = DbCon.ExecuteReader(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);
            if (Salah != "") { return Salah; }

            var validStaffIds = Recc.AsEnumerable().Select(row => row["staff_no"].ToString()).ToList();
            var validAttIds = formCons.AttId?.Where(id => validStaffIds.Contains(id)).ToList() ?? new List<string>();

            SqlStr.Clear();
            SqlStr.Append(" UPDATE daily_form_attendancelist ");
            SqlStr.Append(" SET staff_attd_no = @AttId, ");
            SqlStr.Append(" staff_attd_updatedate = GETDATE(), ");
            SqlStr.Append(" staff_attd_updby = @Gang, ");
            SqlStr.Append(" staff_attd_total = @Workers ");
            SqlStr.Append(" WHERE rpt_code = @RptCode ");

            string idString = validAttIds.Any() ? string.Join(",", validAttIds) : string.Empty;
            string gangString = formCons.Gang != null ? string.Join(",", formCons.Gang) : string.Empty;

            ParamTmp.Add("@AttId", string.IsNullOrEmpty(idString) ? (object)DBNull.Value : idString);
            ParamTmp.Add("@Gang", string.IsNullOrEmpty(gangString) ? (object)DBNull.Value : gangString);
            ParamTmp.Add("@Workers", validStaffIds.Count);
            ParamTmp.Add("@RptCode", formCons.RptCode);

            Recc = DbCon.ExecuteReader(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);
            if (Salah != "") { return Salah; }
            else { return "0"; }
        }


        public string updateDailyAttendListNo(MasukCons formCons, string Gang)
        {
            StringBuilder SqlStr = new StringBuilder();
            DataTable Recc = new DataTable();
            MsSql DbCon = new MsSql();
            string Salah = "";
            CommonFunc Conn = new CommonFunc();
            Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

            SqlStr.Clear();
            SqlStr.Append(" SELECT staff_no ");
            SqlStr.Append(" FROM gang_desc WHERE staff_status = 'VALID' AND gang_id IN (");

            if (formCons.Gang != null && formCons.Gang.Any())
            {
                for (int i = 0; i < formCons.Gang.Count(); i++)
                {
                    string paramName = "@Gang" + i;
                    SqlStr.Append(paramName);
                    if (i < formCons.Gang.Count() - 1)
                    {
                        SqlStr.Append(", ");
                    }
                    ParamTmp.Add(paramName, formCons.Gang[i]);
                }
                SqlStr.Append(")");
            }
            else
            {
                return "Gang array is null or empty.";
            }

            Recc = DbCon.ExecuteReader(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);
            if (Salah != "") { return Salah; }

            var validStaffIds = Recc.AsEnumerable().Select(row => row["staff_no"].ToString()).ToList();
            var validAttIds = formCons.AttId?.Where(id => validStaffIds.Contains(id)).ToList() ?? new List<string>();

            SqlStr.Clear();
            SqlStr.Append(" UPDATE daily_form_attendancelistno ");
            SqlStr.Append(" SET staff_attdno_no = @AttId, ");
            SqlStr.Append(" staff_attdno_updatedate = GETDATE(), ");
            SqlStr.Append(" staff_attdno_updby = @Gang, ");
            SqlStr.Append(" staff_attdno_total = @Workers ");
            SqlStr.Append(" WHERE rpt_code = @RptCode ");

            string idString = validAttIds.Any() ? string.Join(",", validAttIds) : string.Empty;
            string gangString = formCons.Gang != null ? string.Join(",", formCons.Gang) : string.Empty;

            ParamTmp.Add("@AttId", string.IsNullOrEmpty(idString) ? (object)DBNull.Value : idString);
            ParamTmp.Add("@Gang", string.IsNullOrEmpty(gangString) ? (object)DBNull.Value : gangString);
            ParamTmp.Add("@Workers", validStaffIds.Count);
            ParamTmp.Add("@RptCode", formCons.RptCode);

            Recc = DbCon.ExecuteReader(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);
            if (Salah != "") { return Salah; }
            else { return "0"; }
        }


        public string UpdateGangDetails(string StatusCuti, string Userid)
        {
            StringBuilder SqlStr = new StringBuilder();
            DataTable Recc = new DataTable();
            MsSql DbCon = new MsSql();
            string Salah = "";
            CommonFunc Conn = new CommonFunc();
            Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

            SqlStr.Append(" UPDATE gang_desc ");
            SqlStr.Append(" SET staff_status = UPPER(@StatusCuti), ");
            SqlStr.Append(" upd_date = GETDATE() ");
            SqlStr.Append(" WHERE staff_no = @Userid ");

            ParamTmp.Add("@StatusCuti", StatusCuti ?? (object)DBNull.Value);
            ParamTmp.Add("@Userid", Userid);

            Recc = DbCon.ExecuteReader(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);
            if (Salah != "") { return Salah; }
            else { return "0"; }
        }

        public string UpdateWorkPlan(string UpdBy, string StaffNo, string WorkDate, string PlanCode)
        {
            StringBuilder SqlStr = new StringBuilder();
            DataTable Recc = new DataTable();
            MsSql DbCon = new MsSql();
            string Salah = "";
            CommonFunc Conn = new CommonFunc();
            Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

            SqlStr.Append(" UPDATE work_plan ");
            SqlStr.Append(" SET work_plan_type_code = @PlanCode, ");
            SqlStr.Append(" updated_at = GETDATE(), ");
            SqlStr.Append(" updated_by = @UpdBy ");
            SqlStr.Append(" WHERE staff_no = @StaffNo ");
            SqlStr.Append(" AND work_date = @WorkDate ");

            ParamTmp.Add("@PlanCode", PlanCode ?? (object)DBNull.Value);
            ParamTmp.Add("@StaffNo", StaffNo);
            ParamTmp.Add("@UpdBy", UpdBy);
            ParamTmp.Add("@WorkDate", WorkDate);

            Recc = DbCon.ExecuteReader(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);
            if (Salah != "") { return Salah; }
            else { return "0"; }
        }

        public string UpdateStaffLeave(string UpdBy, string StaffNo, string WorkDate, string CutiCode)
        {
            StringBuilder SqlStr = new StringBuilder();
            DataTable Recc = new DataTable();
            MsSql DbCon = new MsSql();
            string Salah = "";
            CommonFunc Conn = new CommonFunc();
            Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

            SqlStr.Append(" UPDATE staff_leave ");
            SqlStr.Append(" SET leaveType_id = @CutiCode, ");
            SqlStr.Append(" updated_at = GETDATE(), ");
            SqlStr.Append(" updated_by = @UpdBy ");
            SqlStr.Append(" WHERE staff_no = @StaffNo ");
            SqlStr.Append(" AND leave_date = @WorkDate ");

            ParamTmp.Add("@CutiCode", CutiCode ?? (object)DBNull.Value);
            ParamTmp.Add("@StaffNo", StaffNo);
            ParamTmp.Add("@UpdBy", UpdBy);
            ParamTmp.Add("@WorkDate", WorkDate);

            Recc = DbCon.ExecuteReader(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);
            if (Salah != "") { return Salah; }
            else { return "0"; }
        }



        public string UpdateWorkPlanTotal(string Userid, List<WorkPlanTotal> workPlanList)
        {
            if (workPlanList == null || workPlanList.Count == 0) return "0";

            StringBuilder SqlStr = new StringBuilder();
            MsSql DbCon = new MsSql();
            string Salah = "";
            CommonFunc Conn = new CommonFunc();
            Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

            List<string> dateParamNames = new List<string>();
            for (int i = 0; i < workPlanList.Count; i++)
            {
                string pName = "@Date" + i;
                dateParamNames.Add(pName);
                ParamTmp.Add(pName, workPlanList[i].Date);
            }
            SqlStr.Append(@"
                            UPDATE wpt
                            SET 
                                wpt.work_dp = counts.dp,
                                wpt.work_up = counts.up,
                                wpt.work_pl = counts.pl,
                                wpt.updated_at = GETDATE()
                            FROM work_plan_total_pax wpt
                            INNER JOIN (
                                SELECT work_date, rpt_code,
                                    SUM(CASE WHEN work_plan_type_code = 'dp' THEN 1 ELSE 0 END) as dp,
                                    SUM(CASE WHEN work_plan_type_code = 'up' THEN 1 ELSE 0 END) as up,
                                    SUM(CASE WHEN work_plan_type_code = 'pl' THEN 1 ELSE 0 END) as pl
                                FROM work_plan
                                WHERE work_date IN (" + string.Join(",", dateParamNames) + @")
                                GROUP BY work_date, rpt_code
                            ) AS counts ON wpt.work_date = counts.work_date AND wpt.rpt_code = counts.rpt_code;
                        ");

            DbCon.ExecuteReader(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);

            return (Salah != "") ? Salah : "0";
        }



        //INSERT 

        public string NewUser(UserCons userCons)
        {
            StringBuilder SqlStr = new StringBuilder();
            DataTable Recc = new DataTable();
            MsSql DbCon = new MsSql();
            string Salah = "";
            CommonFunc Conn = new CommonFunc();
            Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

            SqlStr.Append(" INSERT INTO staff_login ");
            SqlStr.Append(" ([login_id] ");
            SqlStr.Append(" ,[staff_id] ");
            SqlStr.Append(" ,[dept] ");
            SqlStr.Append(" ,[usrlevel] ");
            SqlStr.Append(" ,[staff_name] ");
            SqlStr.Append(" ,[position] ");
            SqlStr.Append(" ,[upd_date] ");
            SqlStr.Append(" ,[staff_status] ");
            SqlStr.Append(" ,[section] ");
            SqlStr.Append(" ,[muj] ");
            SqlStr.Append(" ,[kmuj]) ");
            SqlStr.Append(" VALUES ");
            SqlStr.Append(" ( @LoginID ");
            SqlStr.Append(" , @StaffID ");
            SqlStr.Append(" , 'Permanent Way' ");
            SqlStr.Append(" , @UserLevel ");
            SqlStr.Append(" , @Nama ");
            SqlStr.Append(" , @Designation ");
            SqlStr.Append(" , GETDATE() ");
            SqlStr.Append(" , 'active' ");
            SqlStr.Append(" , @Region ");
            SqlStr.Append(" , @Kmuj ");
            SqlStr.Append(" , @Section ) ");

            ParamTmp.Add("@LoginID", userCons.Userid ?? (object)DBNull.Value);
            ParamTmp.Add("@StaffID", userCons.Userid ?? (object)DBNull.Value);
            ParamTmp.Add("@UserLevel", userCons.UserLevel ?? (object)DBNull.Value);
            ParamTmp.Add("@Nama", userCons.Nama ?? (object)DBNull.Value);
            ParamTmp.Add("@Designation", userCons.Designation ?? (object)DBNull.Value);
            ParamTmp.Add("@Region", userCons.Region ?? (object)DBNull.Value);
            ParamTmp.Add("@Kmuj", userCons.KMUJ ?? (object)DBNull.Value);
            ParamTmp.Add("@Section", userCons.Section ?? (object)DBNull.Value);

            Recc = DbCon.ExecuteReader(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);
            if (Salah != "") { return Salah; }
            else { return "0"; }

        }






        private (int staffSecCount, int staffCount) CheckCounts(string staffId)
        {
            MsSql DbCon = new MsSql();
            string Salah = "";
            CommonFunc Conn = new CommonFunc();
            Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

            StringBuilder SqlStr = new StringBuilder();
            SqlStr.Append("SELECT ");
            SqlStr.Append("(SELECT COUNT(*) FROM gang_desc WHERE staff_no = @StaffId) AS staffSecCount, ");
            SqlStr.Append("(SELECT COUNT(*) FROM staff_section WHERE no_perkh = @StaffId) AS StaffCount");

            ParamTmp.Add("@StaffId", staffId ?? (object)DBNull.Value);

            DataTable Recc = DbCon.ExecuteReader(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);
            if (Salah != "")
            {
                throw new Exception(Salah);
            }

            int staffSecCount = Convert.ToInt32(Recc.Rows[0]["StaffSecCount"]);
            int staffCount = Convert.ToInt32(Recc.Rows[0]["StaffCount"]);

            return (staffSecCount, staffCount);
        }


        public string NewGang(List<UserCons> userConsList)
        {
            MsSql DbCon = new MsSql();
            string Salah = "";
            CommonFunc Conn = new CommonFunc();

            // Log the size and content of the input list before removing duplicates
            Console.WriteLine($"Number of users before removing duplicates: {userConsList.Count}");
            foreach (var user in userConsList)
            {
                Console.WriteLine($"User: {user.StaffId}, {user.Nama}");
            }

            // Remove duplicates based on StaffId
            var distinctUserConsList = userConsList
                .GroupBy(u => u.StaffId)
                .Select(g => g.First())
                .ToList();

            // Log the size and content of the distinct list
            Console.WriteLine($"Number of distinct users to process: {distinctUserConsList.Count}");
            foreach (var user in distinctUserConsList)
            {
                Console.WriteLine($"Distinct User: {user.StaffId}, {user.Nama}");
            }

            foreach (var userCons in distinctUserConsList)
            {
                // Logging to verify each user is being processed
                Console.WriteLine($"Processing User: {userCons.StaffId}, {userCons.Nama}");

                var (staffSecCount, staffCount) = CheckCounts(userCons.StaffId);

                if (staffSecCount == 0 && staffCount == 0)
                {
                    StringBuilder SqlStr = new StringBuilder();
                    Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

                    SqlStr.Append(" INSERT INTO gang_desc ");
                    SqlStr.Append(" ([gang_id] ");
                    SqlStr.Append(", [staff_no] ");
                    SqlStr.Append(", [staff_name] ");
                    SqlStr.Append(", [section_id] ");
                    SqlStr.Append(", [upd_by] ");
                    SqlStr.Append(", [upd_date] ");
                    SqlStr.Append(", [position] ");
                    SqlStr.Append(", [staff_status]) ");
                    SqlStr.Append(" VALUES ");
                    SqlStr.Append(" ( @GangId ");
                    SqlStr.Append(" , @StaffId ");
                    SqlStr.Append(" , @Nama ");
                    SqlStr.Append(" , @Grade ");
                    SqlStr.Append(" , @UpdBy ");
                    SqlStr.Append(" , GETDATE() ");
                    SqlStr.Append(" , @Designation ");
                    SqlStr.Append(" , 'VALID' )");

                    ParamTmp.Add("@GangId", userCons.GangId ?? (object)DBNull.Value);
                    ParamTmp.Add("@StaffId", userCons.StaffId ?? (object)DBNull.Value);
                    ParamTmp.Add("@Nama", userCons.Nama ?? (object)DBNull.Value);
                    ParamTmp.Add("@Grade", userCons.Grade ?? (object)DBNull.Value);
                    ParamTmp.Add("@UpdBy", userCons.UpdBy);
                    ParamTmp.Add("@Designation", userCons.Designation ?? (object)DBNull.Value);

                    bool isSuccess = DbCon.ExecuteNonQuery(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);
                    if (!isSuccess)
                    {
                        return Salah;
                    }

                    StringBuilder SqlStrNew = new StringBuilder();
                    Dictionary<string, Object> ParamTmpNew = new Dictionary<string, Object>();

                    SqlStrNew.Append(" INSERT INTO staff_section ");
                    SqlStrNew.Append(" ([no_perkh] ");
                    SqlStrNew.Append(", [no_muj] ");
                    SqlStrNew.Append(", [no_section]) ");
                    SqlStrNew.Append(" VALUES ");
                    SqlStrNew.Append(" ( @StaffId ");
                    SqlStrNew.Append(" , @Kmuj ");
                    SqlStrNew.Append(" , @Section )");

                    ParamTmpNew.Add("@StaffId", userCons.StaffId ?? (object)DBNull.Value);
                    ParamTmpNew.Add("@Kmuj", userCons.KMUJ);
                    ParamTmpNew.Add("@Section", userCons.Section);

                    isSuccess = DbCon.ExecuteNonQuery(SqlStrNew.ToString(), ParamTmpNew, Conn.emujConn, ref Salah);
                    if (!isSuccess)
                    {
                        return Salah;
                    }
                }
                else if (staffSecCount == 0 && staffCount == 1)
                {
                    StringBuilder SqlStrNewer = new StringBuilder();
                    Dictionary<string, Object> ParamTmpNewer = new Dictionary<string, Object>();

                    SqlStrNewer.Append(" INSERT INTO gang_desc ");
                    SqlStrNewer.Append(" ([gang_id] ");
                    SqlStrNewer.Append(", [staff_no] ");
                    SqlStrNewer.Append(", [staff_name] ");
                    SqlStrNewer.Append(", [section_id] ");
                    SqlStrNewer.Append(", [upd_by] ");
                    SqlStrNewer.Append(", [upd_date] ");
                    SqlStrNewer.Append(", [position] ");
                    SqlStrNewer.Append(", [staff_status]) ");
                    SqlStrNewer.Append(" VALUES ");
                    SqlStrNewer.Append(" ( @GangId ");
                    SqlStrNewer.Append(" , @StaffId ");
                    SqlStrNewer.Append(" , @Nama ");
                    SqlStrNewer.Append(" , @Grade ");
                    SqlStrNewer.Append(" , @UpdBy ");
                    SqlStrNewer.Append(" , GETDATE() ");
                    SqlStrNewer.Append(" , @Designation ");
                    SqlStrNewer.Append(" , 'VALID' )");

                    ParamTmpNewer.Add("@GangId", userCons.GangId ?? (object)DBNull.Value);
                    ParamTmpNewer.Add("@StaffId", userCons.StaffId ?? (object)DBNull.Value);
                    ParamTmpNewer.Add("@Nama", userCons.Nama ?? (object)DBNull.Value);
                    ParamTmpNewer.Add("@Grade", userCons.Grade ?? (object)DBNull.Value);
                    ParamTmpNewer.Add("@UpdBy", userCons.UpdBy);
                    ParamTmpNewer.Add("@Designation", userCons.Designation ?? (object)DBNull.Value);

                    bool isSuccess = DbCon.ExecuteNonQuery(SqlStrNewer.ToString(), ParamTmpNewer, Conn.emujConn, ref Salah);
                    if (!isSuccess)
                    {
                        return Salah;
                    }
                }
            }
            return "0";
        }


        //generate rptcode
        public (int latestDailyId, string formattedRptCode) GenerateFormattedRptCode()
        {
            MsSql DbCon = new MsSql();
            string Salah = "";
            CommonFunc Conn = new CommonFunc();
            Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

            // Query to get the latest daily_id
            StringBuilder SqlStr = new StringBuilder();
            SqlStr.Append("SELECT TOP 1 daily_id FROM [dbo].[daily_form] ORDER BY daily_id DESC");

            DataTable Recc = DbCon.ExecuteReader(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);
            if (Salah != "")
            {
                throw new Exception(Salah);
            }

            // Fetch the latest daily_id
            int latestDailyId = 0;
            if (Recc.Rows.Count > 0 && Recc.Rows[0]["daily_id"] != DBNull.Value)
            {
                // Get the last daily_id and increment by 1
                latestDailyId = Convert.ToInt32(Recc.Rows[0]["daily_id"]) + 1;
            }
            else
            {
                // If no rows are returned, set the default starting value
                latestDailyId = 1;
            }

            // Increment by 8 and format the report code
            string formattedRptCode = $"RPTD{latestDailyId + 0:D5}";

            // Print or use the values
            Console.WriteLine($"Latest Daily ID: {latestDailyId}");
            Console.WriteLine($"Formatted Report Code: {formattedRptCode}");

            return (latestDailyId, formattedRptCode);
        }


        // 1. R1 FORM
        public string NewForm(R1FormCons formCons)
        {
            StringBuilder SqlStr = new StringBuilder();
            DataTable Recc = new DataTable();
            MsSql DbCon = new MsSql();
            string Salah = "";
            CommonFunc Conn = new CommonFunc();
            Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

            // 1. Generate the code BEFORE the insert
            var (latestDailyId, formattedRptCode) = GenerateFormattedRptCode();
            string gangString = formCons.Gang != null ? string.Join(",", formCons.Gang) : string.Empty;

            SqlStr.Append("INSERT INTO [dbo].[daily_form] ");
            SqlStr.Append("([daily_id], [daily_section], [daily_kmuj], [daily_sec], [daily_gang], [daily_date], [daily_worktype], [daily_total], [daily_unit], ");
            SqlStr.Append("[daily_timestart], [daily_timelast], [daily_category], [daily_condition], [daily_additional], [daily_timetaken], ");
            SqlStr.Append("[effect_kmfrom], [effect_kmto], [effect_kmtotal], [station], [station_point], [category_details], [temperature], ");
            SqlStr.Append("[rpt_code], [daily_workers], [upd_user], [upd_date]) ");
            SqlStr.Append("VALUES ");
            SqlStr.Append("(@DailyId, @Region, @Kmuj, @Section, @Gang, @Date, @WorkType, @Total, @TotalUnit, ");
            SqlStr.Append("@TimeStart, @TimeLast, @Category, @Condition, @Adds, @TimeTaken, @KMFrom, @KMTo, @KMTotal, @Station, @SPoint, ");
            SqlStr.Append("@CatDetails, @Temp, @RptCode, ISNULL(@Workers, '0') + ' pax', @UpdBy, GETDATE()); ");
            SqlStr.Append("SELECT SCOPE_IDENTITY();");

            // Parameter mapping
            ParamTmp.Add("@DailyId", latestDailyId);
            ParamTmp.Add("@Region", formCons.Region ?? (object)DBNull.Value);
            ParamTmp.Add("@Kmuj", formCons.Kmuj ?? (object)DBNull.Value);
            ParamTmp.Add("@Section", formCons.Section ?? (object)DBNull.Value);
            ParamTmp.Add("@Gang", string.IsNullOrEmpty(gangString) ? (object)DBNull.Value : gangString);
            ParamTmp.Add("@Date", formCons.Date ?? (object)DBNull.Value);
            ParamTmp.Add("@WorkType", formCons.WorkType ?? (object)DBNull.Value);
            ParamTmp.Add("@Total", formCons.Total ?? (object)DBNull.Value);
            ParamTmp.Add("@TotalUnit", formCons.TotalUnit ?? (object)DBNull.Value);
            ParamTmp.Add("@TimeStart", formCons.TimeStart ?? (object)DBNull.Value);
            ParamTmp.Add("@TimeLast", formCons.TimeLast ?? (object)DBNull.Value);
            ParamTmp.Add("@Category", formCons.Category ?? (object)DBNull.Value);
            ParamTmp.Add("@Condition", formCons.Condition ?? (object)DBNull.Value);
            ParamTmp.Add("@Adds", formCons.Adds ?? (object)DBNull.Value);
            ParamTmp.Add("@TimeTaken", formCons.TimeTaken ?? (object)DBNull.Value);
            ParamTmp.Add("@KMFrom", formCons.KMFrom ?? (object)DBNull.Value);
            ParamTmp.Add("@KMTo", formCons.KMTo ?? (object)DBNull.Value);
            ParamTmp.Add("@KMTotal", formCons.KMTotal ?? (object)DBNull.Value);
            ParamTmp.Add("@Station", formCons.Station ?? (object)DBNull.Value);
            ParamTmp.Add("@SPoint", formCons.SPoint ?? (object)DBNull.Value);
            ParamTmp.Add("@CatDetails", formCons.CatDetails ?? (object)DBNull.Value);
            ParamTmp.Add("@Temp", formCons.Temp ?? (object)DBNull.Value);
            ParamTmp.Add("@RptCode", formattedRptCode ?? (object)DBNull.Value);
            ParamTmp.Add("@Workers", formCons.Workers ?? (object)DBNull.Value);
            ParamTmp.Add("@UpdBy", formCons.UpdBy);

            // Execute the query
            Recc = DbCon.ExecuteReader(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);

            // If Salah has a value, the SQL actually crashed
            if (!string.IsNullOrEmpty(Salah))
            {
                return JsonConvert.SerializeObject(new { status = "01", message = Salah });
            }

            if (Recc.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(new
                {
                    status = "00",
                    rptCode = formattedRptCode
                });
            }

            return JsonConvert.SerializeObject(new { status = "01", message = "Failed to insert record into database." });
        }

        // 2. STAFF LEAVE
        public string DailyLeave(R1FormCons formCons)
        {
            if (formCons.StaffList == null || formCons.StaffList.Count == 0)
                return "0";

            MsSql DbCon = new MsSql();
            CommonFunc Conn = new CommonFunc();
            string Salah = "";

            foreach (var staff in formCons.StaffList)
            {
                StringBuilder SqlStr = new StringBuilder();
                Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

                SqlStr.Append(" INSERT INTO staff_leave ([staff_no], [leave_date], [leaveType_id], [created_by], [created_at], [rpt_code]) ");
                SqlStr.Append(" VALUES (@StaffNo, @Date, @LeaveTypeId, @CreatedBy, GETDATE(), @RptCode)");

                ParamTmp.Add("@StaffNo", staff.StaffNo ?? (object)DBNull.Value);
                ParamTmp.Add("@Date", formCons.Date ?? (object)DBNull.Value);
                ParamTmp.Add("@LeaveTypeId", staff.LeaveTypeId ?? (object)DBNull.Value);
                ParamTmp.Add("@CreatedBy", formCons.UpdBy ?? (object)DBNull.Value);
                ParamTmp.Add("@RptCode", formCons.RptCode ?? (object)DBNull.Value);

                DbCon.ExecuteNonQuery(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);
                if (!string.IsNullOrEmpty(Salah)) return Salah;
            }
            return "0";
        }

        // 3. WORK PLAN
        public string R1WorkPlan(R1FormCons formCons)
        {
            if (formCons.StaffList == null || formCons.StaffList.Count == 0)
                return "0";

            MsSql DbCon = new MsSql();
            CommonFunc Conn = new CommonFunc();
            string Salah = "";

            foreach (var staff in formCons.StaffList)
            {
                StringBuilder SqlStr = new StringBuilder();
                Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

                SqlStr.Append(" INSERT INTO work_plan ([work_date], [staff_no], [rpt_code], [created_by], [created_at]) ");
                SqlStr.Append(" VALUES (@Date, @StaffNo, @RptCode, @CreatedBy, GETDATE())");

                ParamTmp.Add("@Date", formCons.Date ?? (object)DBNull.Value);
                ParamTmp.Add("@StaffNo", staff.StaffNo ?? (object)DBNull.Value);
                ParamTmp.Add("@CreatedBy", formCons.UpdBy ?? (object)DBNull.Value);
                ParamTmp.Add("@RptCode", formCons.RptCode ?? (object)DBNull.Value);

                DbCon.ExecuteNonQuery(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);
                if (!string.IsNullOrEmpty(Salah)) return Salah;
            }
            return "0";
        }

        // 4. WORK PLAN TOTAL
        public string R1WorkPlanTotal(WorkPlanTotal workplantotalCons)
        {
            MsSql DbCon = new MsSql();
            CommonFunc Conn = new CommonFunc();
            string Salah = "";
            Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

            StringBuilder SqlStr = new StringBuilder();
            SqlStr.Append(" INSERT INTO work_plan_total_pax ([work_date], [rpt_code], [work_dp], [work_up], [work_pl], [created_by], [created_at]) ");
            SqlStr.Append(" VALUES (@Date, @RptCode, @WorkDp, @WorkUp, @WorkPl, @CreatedBy, GETDATE())");

            ParamTmp.Add("@Date", workplantotalCons.Date ?? (object)DBNull.Value);
            ParamTmp.Add("@CreatedBy", workplantotalCons.CreatedBy ?? (object)DBNull.Value);
            ParamTmp.Add("@RptCode", workplantotalCons.RptCode ?? (object)DBNull.Value);
            ParamTmp.Add("@WorkDp", workplantotalCons.WorkDp ?? (object)DBNull.Value);
            ParamTmp.Add("@WorkUp", workplantotalCons.WorkUp ?? (object)DBNull.Value);
            ParamTmp.Add("@WorkPl", workplantotalCons.WorkPl ?? (object)DBNull.Value);

            DbCon.ExecuteNonQuery(SqlStr.ToString(), ParamTmp, Conn.emujConn, ref Salah);
            return string.IsNullOrEmpty(Salah) ? "0" : Salah;
        }

        // 5. ATTENDANCE LIST (VALID)
        public string DailyAttendList([FromBody] MasukCons formCons)
        {
            MsSql DbCon = new MsSql();
            CommonFunc Conn = new CommonFunc();
            string Salah = "";
            Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

            if (formCons.Gang == null || !formCons.Gang.Any()) return "Gang array empty";

            // Query valid staff in these gangs
            StringBuilder SqlSelect = new StringBuilder();
            SqlSelect.Append(" SELECT staff_no FROM gang_desc WHERE staff_status = 'VALID' AND gang_id IN (");
            for (int i = 0; i < formCons.Gang.Count(); i++)
            {
                string paramName = "@Gang" + i;
                SqlSelect.Append(paramName + (i < formCons.Gang.Count() - 1 ? ", " : ""));
                ParamTmp.Add(paramName, formCons.Gang[i]);
            }
            SqlSelect.Append(")");

            DataTable Recc = DbCon.ExecuteReader(SqlSelect.ToString(), ParamTmp, Conn.emujConn, ref Salah);
            if (!string.IsNullOrEmpty(Salah)) return Salah;

            var validStaffIds = Recc.AsEnumerable().Select(row => row["staff_no"].ToString()).ToList();
            var validAttIds = formCons.AttId?.Where(id => validStaffIds.Contains(id)).ToList() ?? new List<string>();

            // Insert into table
            Dictionary<string, Object> ParamInsert = new Dictionary<string, Object>();
            string SqlInsert = "INSERT INTO [dbo].[daily_form_attendancelist] ([staff_attd_no], [staff_attd_updatedate], [staff_attd_updby], [staff_attd_total], [staff_attd_gang], [rpt_code]) " +
                               "VALUES (@AttId, GETDATE(), @UpdBy, @Workers, @Gang, @RptCode)";

            ParamInsert.Add("@AttId", validAttIds.Any() ? string.Join(",", validAttIds) : (object)DBNull.Value);
            ParamInsert.Add("@UpdBy", formCons.UpdBy ?? (object)DBNull.Value);
            ParamInsert.Add("@Gang", string.Join(",", formCons.Gang));
            ParamInsert.Add("@Workers", validStaffIds.Count);
            ParamInsert.Add("@RptCode", formCons.RptCode ?? (object)DBNull.Value);

            DbCon.ExecuteNonQuery(SqlInsert, ParamInsert, Conn.emujConn, ref Salah);
            return string.IsNullOrEmpty(Salah) ? "0" : Salah;
        }

        // 6. ATTENDANCE LIST (NOT VALID)
        public string DailyAttendListNo([FromBody] MasukCons formCons)
        {
            MsSql DbCon = new MsSql();
            CommonFunc Conn = new CommonFunc();
            string Salah = "";
            Dictionary<string, Object> ParamTmp = new Dictionary<string, Object>();

            if (formCons.Gang == null || !formCons.Gang.Any()) return "Gang array empty";

            StringBuilder SqlSelect = new StringBuilder();
            SqlSelect.Append(" SELECT staff_no FROM gang_desc WHERE staff_status != 'VALID' AND gang_id IN (");
            for (int i = 0; i < formCons.Gang.Count(); i++)
            {
                string paramName = "@Gang" + i;
                SqlSelect.Append(paramName + (i < formCons.Gang.Count() - 1 ? ", " : ""));
                ParamTmp.Add(paramName, formCons.Gang[i]);
            }
            SqlSelect.Append(")");

            DataTable Recc = DbCon.ExecuteReader(SqlSelect.ToString(), ParamTmp, Conn.emujConn, ref Salah);
            if (!string.IsNullOrEmpty(Salah)) return Salah;

            var validStaffIds = Recc.AsEnumerable().Select(row => row["staff_no"].ToString()).ToList();
            var validAttIds = formCons.AttId?.Where(id => validStaffIds.Contains(id)).ToList() ?? new List<string>();

            Dictionary<string, Object> ParamInsert = new Dictionary<string, Object>();
            string SqlInsert = "INSERT INTO [dbo].[daily_form_attendancelistno] ([staff_attdno_no], [staff_attdno_updatedate], [staff_attdno_updby], [staff_attdno_total], [staff_attdno_gang], [rpt_code]) " +
                               "VALUES (@AttId, GETDATE(), @UpdBy, @Workers, @Gang, @RptCode)";

            ParamInsert.Add("@AttId", validAttIds.Any() ? string.Join(",", validAttIds) : (object)DBNull.Value);
            ParamInsert.Add("@UpdBy", formCons.UpdBy ?? (object)DBNull.Value);
            ParamInsert.Add("@Gang", string.Join(",", formCons.Gang));
            ParamInsert.Add("@Workers", validStaffIds.Count);
            ParamInsert.Add("@RptCode", formCons.RptCode ?? (object)DBNull.Value);

            DbCon.ExecuteNonQuery(SqlInsert, ParamInsert, Conn.emujConn, ref Salah);
            return string.IsNullOrEmpty(Salah) ? "0" : Salah;
        }

    }
}

