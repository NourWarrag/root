using ModelCore.HRMS.Admin.Recruitment;
using InterfaceCore;
using Microsoft.EntityFrameworkCore;
using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace ConcreteCore.HRMS.Admin.Recruitment
{
    public class HRMSAttributeConcrete : IHRMSAttribute
    {

        private readonly DatabaseContext _Context;

        public HRMSAttributeConcrete(DatabaseContext context)
        {
            _Context = context;
        }

        public async Task<HRMSAttributeEntry> GetEntry(Int64 id)
        {
            try
            {
                HRMSAttributeEntry result = await _Context.HRMSAttributeEntry.FromSql("Exec spmHRMSAttributeEntry @pi_mHRMSAttributeId", new SqlParameter("@pi_mHRMSAttributeId", id)).SingleOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<HRMSAttributeIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage)
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
                return await _Context.HRMSAttributeIndex.FromSql(csql, sqlparam.ToArray()).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SQLResult> Create(HRMSAttributeEntry pModel)
        {
            SQLResult result = new SQLResult();
            _Context.Database.BeginTransaction();
            try
            {
                string csql = @" EXEC spmHRMSAttributeInsert
                    @pi_AttributeName
                    , @pi_UsedFor
                    , @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
 new SqlParameter("@pi_AttributeName", pModel.AttributeName) ,
 new SqlParameter("@pi_UsedFor", pModel.UsedFor) ,
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

        public async Task<SQLResult> Edit(HRMSAttributeEntry pModel)
        {
            SQLResult result = new SQLResult();
            _Context.Database.BeginTransaction();
            try
            {
                string csql = @" EXEC spmHRMSAttributeUpdate
                    @pi_mHRMSAttributeId
                    , @pi_AttributeName
                    , @pi_UsedFor
                    , @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
 new SqlParameter("@pi_mHRMSAttributeId", pModel.HRMSAttributeId) ,
 new SqlParameter("@pi_AttributeName", pModel.AttributeName) ,
 new SqlParameter("@pi_UsedFor", pModel.UsedFor) ,
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

        public async Task<SQLResult> Delete(HRMSAttributeEntry pModel)
        {
            SQLResult result = new SQLResult();
            _Context.Database.BeginTransaction();
            try
            {
                string csql = @" EXEC spmHRMSAttributeDelete
                    @pi_mHRMSAttributeId
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
 new SqlParameter("@pi_mHRMSAttributeId", pModel.HRMSAttributeId) ,
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




    }
}