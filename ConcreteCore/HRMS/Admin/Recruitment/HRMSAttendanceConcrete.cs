using ModelCore.HRMS.Admin.Recruitment;
using InterfaceCore;
using Microsoft.EntityFrameworkCore;
using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace ConcreteCore.HRMS.Admin.Recruitment
{
    public class HRMSAttendanceConcrete: IHRMSAttendance
    {
        private readonly DatabaseContext _Context;
        public HRMSAttendanceConcrete(DatabaseContext context)
        {
            _Context = context;
        }

        public async Task<HRMSAttendanceEntry> GetEntry(Int64 id)
        {
            try
            {
                HRMSAttendanceEntry result = await _Context.HRMSAttendanceEntry.FromSql("Exec spHRMSAttendanceEntry @pi_HRMSAttendanceId",
                    new SqlParameter("@pi_HRMSAttendanceId", id)).SingleOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<HRMSAttendanceIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage)
        {
            try
            {
                string csql = @" EXEC spGetPageData
                    @pi_mScreenId
                    , @pi_mUserId
                    , @pi_RecordsPerPage
                    , @pi_PageNo
                    , @pi_mTableId
                    , @pi_LastPage";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                     new SqlParameter("@pi_mScreenId", ScreenId) ,
                     new SqlParameter("@pi_mUserId", UserId) ,
                     new SqlParameter("@pi_RecordsPerPage", RecordsPerPage) ,
                     new SqlParameter("@pi_PageNo", PageNo) ,
                     new SqlParameter("@pi_mTableId", TableId) ,
                     new SqlParameter("@pi_LastPage", LastPage) ,
                    };
                return await _Context.HRMSAttendanceIndex.FromSql(csql, sqlparam.ToArray()).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SQLResult> Create(HRMSAttendanceEntry pModel)
        {
            SQLResult result = new SQLResult();
            _Context.Database.BeginTransaction();
            try
            {
                string csql = @" EXEC spHRMSAttendanceInsert
                    @pi_mHRMSEmployeeId
                    , @pi_mHRMSShiftId
                    , @pi_AttendanceDate
                    , @pi_WorkingDay
                    , @pi_CheckIn
                    , @pi_CheckOut
                    , @pi_WeekEndOff
                    , @pi_Holiday
                    , @pi_Absent
                    , @pi_IsValid
                    , @pi_PayrollStatus
                    , @pi_DayStatusId
                    , @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
                ";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                                new SqlParameter("@pi_mHRMSEmployeeId", pModel.HRMSEmployeeId) ,
                                new SqlParameter("@pi_mHRMSShiftId", pModel.HRMSShiftId) ,
                                new SqlParameter("@pi_AttendanceDate", pModel.AttendanceDate) ,
                                new SqlParameter("@pi_WorkingDay", pModel.WorkingDay) ,
                                new SqlParameter("@pi_CheckIn", pModel.CheckIn) ,
                                new SqlParameter("@pi_CheckOut", pModel.CheckOut) ,
                                new SqlParameter("@pi_WeekEndOff", pModel.WeekEndOff) ,
                                new SqlParameter("@pi_Holiday", pModel.Holiday) ,
                                new SqlParameter("@pi_Absent", pModel.Absent) ,
                                new SqlParameter("@pi_IsValid", pModel.IsValid) ,
                                new SqlParameter("@pi_PayrollStatus", pModel.PayrollStatus) ,
                                new SqlParameter("@pi_DayStatusId", pModel.DayStatusId) ,
                                new SqlParameter("@pi_Active", pModel.Active) ,
                                new SqlParameter("@pi_UserId", pModel.AuditColumns.UserId) ,
                                new SqlParameter("@pi_HostName", pModel.AuditColumns.HostName) ,
                                new SqlParameter("@pi_IPAddress", pModel.AuditColumns.IPAddress) ,
                                new SqlParameter("@pi_DeviceType", pModel.AuditColumns.DeviceType) ,
                                new SqlParameter("@pi_MACAddress", pModel.AuditColumns.MACAddress) ,
                };
                result = await _Context.DBResult.FromSql(csql, sqlparam.ToArray()).SingleOrDefaultAsync();
                if (result.ErrorNo != 0)
                {
                    _Context.Database.RollbackTransaction();
                }
                else
                {
                    _Context.Database.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                _Context.Database.RollbackTransaction();
                result.ErrorNo = 9999999999;
                result.ErrorMessage = ex.Message.ToString();
                result.SQLErrorNumber = ex.HResult;
                result.SQLErrorMessage = ex.Source.ToString();
            }
            return result;
        }

        public async Task<SQLResult> Edit(HRMSAttendanceEntry pModel)
        {
            SQLResult result = new SQLResult();
            _Context.Database.BeginTransaction();
            try
            {
                string csql = @" EXEC spHRMSAttendanceUpdate
                    @pi_HRMSAttendanceId
                    , @pi_mHRMSEmployeeId
                    , @pi_mHRMSShiftId
                    , @pi_AttendanceDate
                    , @pi_WorkingDay
                    , @pi_CheckIn
                    , @pi_CheckOut
                    , @pi_WeekEndOff
                    , @pi_Holiday
                    , @pi_Absent
                    , @pi_IsValid
                    , @pi_PayrollStatus
                    , @pi_DayStatusId
                    , @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
                ";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                                new SqlParameter("@pi_HRMSAttendanceId", pModel.HRMSAttendanceId) ,
                                new SqlParameter("@pi_mHRMSEmployeeId", pModel.HRMSEmployeeId) ,
                                new SqlParameter("@pi_mHRMSShiftId", pModel.HRMSShiftId) ,
                                new SqlParameter("@pi_AttendanceDate", pModel.AttendanceDate) ,
                                new SqlParameter("@pi_WorkingDay", pModel.WorkingDay) ,
                                new SqlParameter("@pi_CheckIn", pModel.CheckIn) ,
                                new SqlParameter("@pi_CheckOut", pModel.CheckOut) ,
                                new SqlParameter("@pi_WeekEndOff", pModel.WeekEndOff) ,
                                new SqlParameter("@pi_Holiday", pModel.Holiday) ,
                                new SqlParameter("@pi_Absent", pModel.Absent) ,
                                new SqlParameter("@pi_IsValid", pModel.IsValid) ,
                                new SqlParameter("@pi_PayrollStatus", pModel.PayrollStatus) ,
                                new SqlParameter("@pi_DayStatusId", pModel.DayStatusId) ,
                                new SqlParameter("@pi_Active", pModel.Active) ,
                                new SqlParameter("@pi_UserId", pModel.AuditColumns.UserId) ,
                                new SqlParameter("@pi_HostName", pModel.AuditColumns.HostName) ,
                                new SqlParameter("@pi_IPAddress", pModel.AuditColumns.IPAddress) ,
                                new SqlParameter("@pi_DeviceType", pModel.AuditColumns.DeviceType) ,
                                new SqlParameter("@pi_MACAddress", pModel.AuditColumns.MACAddress) ,
                };
                result = await _Context.DBResult.FromSql(csql, sqlparam.ToArray()).SingleOrDefaultAsync();
                if (result.ErrorNo != 0)
                {
                    _Context.Database.RollbackTransaction();
                }
                else
                {
                    _Context.Database.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                _Context.Database.RollbackTransaction();
                result.ErrorNo = 9999999999;
                result.ErrorMessage = ex.Message.ToString();
                result.SQLErrorNumber = ex.HResult;
                result.SQLErrorMessage = ex.Source.ToString();
            }
            return result;
        }

        public SQLResult BulkCopy(DataTable table)
        {
            SQLResult result = new SQLResult();
            try
            {
                using (SqlConnection destinationConnection =
                (SqlConnection)_Context.Database.GetDbConnection())

                {
                    // open the connection
                    destinationConnection.Open();

                    using (SqlBulkCopy bulkCopy =
                         new SqlBulkCopy(destinationConnection.ConnectionString,
                         SqlBulkCopyOptions.KeepIdentity))

                    {
                        bulkCopy.DestinationTableName = "HRMSAttendanceTempLog";
                        bulkCopy.BulkCopyTimeout = 15;
                        bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("HRMSEmployeeId", "mHRMSEmployeeId"));
                        bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("AttendanceDateTime", "AttendanceDateTime"));
                        bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("UserCR", "UserCR"));
                        bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("MACAddressCR", "MACAddressCR"));
                        bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("HostNameCR", "HostNameCR"));
                        bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("IPAddressCR", "IPAddressCR"));
                        bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("DeviceTypeCR", "DeviceTypeCR"));
                        bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("DateCR", "DateCR"));

                       if(_Context.Database.ExecuteSqlCommand("TRUNCATE TABLE [HRMSAttendanceTempLog]") == 0)
                        {
                            result.ErrorNo = 9999999999;
                            result.ErrorMessage = "Unable to truncate Temp log table";
                            return result;
                        }
                        bulkCopy.WriteToServerAsync(table);
                    }

                }
             
                return result;
            }
            catch (Exception ex)
            {
                result.ErrorNo = 9999999999;
                result.ErrorMessage = ex.Message.ToString();
                result.SQLErrorNumber = ex.HResult;
                result.SQLErrorMessage = ex.Source.ToString();
                return result;
            }
        }
    }
            
}


 