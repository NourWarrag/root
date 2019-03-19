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
using Microsoft.SqlServer.Server;

namespace ConcreteCore.HRMS.Admin.Recruitment
{
    public class HRMSAllowanceConcrete : IHRMSAllowance
    {
        private readonly DatabaseContext _Context;

        public HRMSAllowanceConcrete(DatabaseContext context)
        {
            _Context = context;
        }


        public async Task<List<HRMSAllowanceIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage)
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
                return await _Context.HRMSAllowanceIndex.FromSql(csql, sqlparam.ToArray()).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HRMSAllowanceEntry> GetEntry(Int64 pId)

        {

            try
            {

                HRMSAllowanceEntry mPageData =  await _Context.HRMSAllowanceEntry.FromSql(

                    @"EXEC spmHRMSAllowanceEntry @pi_Id,@pi_mHRMSAllowanceId",

                      new SqlParameter("pi_Id", 1)

                    , new SqlParameter("pi_mHRMSAllowanceId", pId)).SingleOrDefaultAsync();

                mPageData.HRMSAllowDependency = await _Context.GetHRMSAllowDependency.FromSql(

                    @"EXEC spmHRMSAllowanceEntry @pi_Id, @pi_mHRMSAllowanceId",

                      new SqlParameter("pi_Id", 2)

                    , new SqlParameter("pi_mHRMSAllowanceId", pId)).ToListAsync();

                mPageData.HRMSAllowSlab = await _Context.GetHRMSAllowSlab.FromSql(

                    @"EXEC spmHRMSAllowanceEntry @pi_Id, @pi_mHRMSAllowanceId",

                      new SqlParameter("pi_Id", 3)

                    , new SqlParameter("pi_mHRMSAllowanceId", pId)).ToListAsync();

                mPageData.HRMSAllowOthers = await _Context.GetHRMSAllowOthers.FromSql(

               @"EXEC spmHRMSAllowanceEntry @pi_Id, @pi_mHRMSAllowanceId",

                 new SqlParameter("pi_Id", 4)

               , new SqlParameter("pi_mHRMSAllowanceId", pId)).ToListAsync();

                return mPageData;

            }

            catch (Exception Ex)

            {

                throw Ex;

            }

        }

        public async Task<SQLResult> Create(HRMSAllowanceEntry pModel)
        {
            SQLResult result = new SQLResult();
            _Context.Database.BeginTransaction();
            try
            {
                // typ_mHRMSAllowDependencytable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSAllowDependencyParameter = new SqlParameter("@pi_typ_mHRMSAllowDependency", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSAllowDependency"
                };
                var pRowCollection_typ_mHRMSAllowDependency = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSAllowDependency)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSAllowDependencyId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSAllowanceId", SqlDbType.BigInt)
                                                , new SqlMetaData("ReferenceAllowanceId", SqlDbType.BigInt)
                                                , new SqlMetaData("TreatedAs", SqlDbType.BigInt)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSAllowDependencyId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSAllowanceId);
                    pRow.SetInt64(3, item.ReferenceAllowanceId);
                    pRow.SetInt64(4, item.TreatedAs);
                    pRow.SetBoolean(5, item.Active);
                    pRow.SetBoolean(6, item.Deleted);
                    pRow.SetInt32(7, item.EntryStatus);

                    pRowCollection_typ_mHRMSAllowDependency.Add(pRow);
                }
                    if (pModel.DependencyStatus==true)
                {
                    ptyp_mHRMSAllowDependencyParameter.Value = pRowCollection_typ_mHRMSAllowDependency;

                }
                else
                {
                    ptyp_mHRMSAllowDependencyParameter.Value = null;
                }
               
                // typ_mHRMSAllowSlabtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSAllowSlabParameter = new SqlParameter("@pi_typ_mHRMSAllowSlab", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSAllowSlab"
                };
                var pRowCollection_typ_mHRMSAllowSlab = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSAllowSlab)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSAllowSlabId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSAllowanceId", SqlDbType.BigInt)
                                                , new SqlMetaData("MinValue", SqlDbType.Decimal, 36, 6)
                                                , new SqlMetaData("MaxValue", SqlDbType.Decimal, 36, 6)
                                                , new SqlMetaData("ValueTypeId", SqlDbType.BigInt)
                                                , new SqlMetaData("SlabValue", SqlDbType.Decimal, 36, 6)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSAllowSlabId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSAllowanceId);
                    pRow.SetDecimal(3, item.MinValue);
                    pRow.SetDecimal(4, item.MaxValue);
                    pRow.SetInt64(5, item.ValueTypeId);
                    pRow.SetDecimal(6, item.SlabValue);
                    pRow.SetBoolean(7, item.Active);
                    pRow.SetBoolean(8, item.Deleted);
                    pRow.SetInt32(9, item.EntryStatus);

                    pRowCollection_typ_mHRMSAllowSlab.Add(pRow);
                }
                if (pModel.SlabStatus==true)
                {
                 
                    ptyp_mHRMSAllowSlabParameter.Value = pRowCollection_typ_mHRMSAllowSlab;

                }
                else
                {
                    
                    ptyp_mHRMSAllowSlabParameter.Value = null;
                }
               
                // typ_mHRMSAllowOtherstable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSAllowOthersParameter = new SqlParameter("@pi_typ_mHRMSAllowOthers", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSAllowOthers"
                };
                var pRowCollection_typ_mHRMSAllowOthers = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSAllowOthers)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSAllowOthersId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSAllowanceId", SqlDbType.BigInt)
                                                , new SqlMetaData("PropertyType", SqlDbType.BigInt)
                                                , new SqlMetaData("PropertyValue", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("MinMaxCheck", SqlDbType.Bit)
                                                , new SqlMetaData("MinValue", SqlDbType.Decimal, 36, 6)
                                                , new SqlMetaData("MaxValue", SqlDbType.Decimal, 36, 6)
                                                , new SqlMetaData("ValueType", SqlDbType.BigInt)
                                                , new SqlMetaData("OthersValue", SqlDbType.Decimal, 36, 6)
                                                , new SqlMetaData("TreatedAs", SqlDbType.BigInt)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSAllowOthersId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSAllowanceId);
                    pRow.SetInt64(3, item.PropertyType);
                    pRow.SetString(4, item.PropertyValue);
                    pRow.SetBoolean(5, item.MinMaxCheck);
                    pRow.SetDecimal(6, item.MinValue);
                    pRow.SetDecimal(7, item.MaxValue);
                    pRow.SetInt64(8, item.ValueType);
                    pRow.SetDecimal(9, item.OthersValue);
                    pRow.SetInt64(10, item.TreatedAs);
                    pRow.SetBoolean(11, item.Active);
                    pRow.SetBoolean(12, item.Deleted);
                    pRow.SetInt32(13, item.EntryStatus);

                    pRowCollection_typ_mHRMSAllowOthers.Add(pRow);
                }

                if (pModel.OthersStatus==true)
                {

                    ptyp_mHRMSAllowOthersParameter.Value = pRowCollection_typ_mHRMSAllowOthers;

                }
                else
                {
                    ptyp_mHRMSAllowOthersParameter.Value = null;
               
                }
               
                string csql = @" EXEC spmHRMSAllowanceInsert
                    @pi_AllowanceCode
                    , @pi_AllowanceName
                    , @pi_AllowanceDescription
                    , @pi_AllowanceTypeId
                    , @pi_AllowanceGroup
                    , @pi_GrossCheck
                    , @pi_EffectiveDateFrom
                    , @pi_EffectiveDateTo
                    , @pi_ValueTypeId
                    , @pi_Value
                    , @pi_DependencyStatus
                    , @pi_SlabStatus
                    , @pi_OthersStatus
                    , @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
                    , @pi_typ_mHRMSAllowDependency
                    , @pi_typ_mHRMSAllowSlab
                    , @pi_typ_mHRMSAllowOthers
                ";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                                new SqlParameter("@pi_AllowanceCode", pModel.AllowanceCode) ,
                                new SqlParameter("@pi_AllowanceName", pModel.AllowanceName) ,
                                new SqlParameter("@pi_AllowanceDescription", pModel.AllowanceDescription) ,
                                new SqlParameter("@pi_AllowanceTypeId", pModel.AllowanceTypeId) ,
                                new SqlParameter("@pi_AllowanceGroup", pModel.AllowanceGroup) ,
                                new SqlParameter("@pi_GrossCheck", pModel.GrossCheck) ,
                                new SqlParameter("@pi_EffectiveDateFrom", pModel.EffectiveDateFrom) ,
                                new SqlParameter("@pi_EffectiveDateTo", pModel.EffectiveDateTo) ,
                                new SqlParameter("@pi_ValueTypeId", pModel.ValueTypeId) ,
                                new SqlParameter("@pi_Value", pModel.Value) ,
                                new SqlParameter("@pi_DependencyStatus", pModel.DependencyStatus) ,
                                new SqlParameter("@pi_SlabStatus", pModel.SlabStatus) ,
                                new SqlParameter("@pi_OthersStatus", pModel.OthersStatus) ,
                                new SqlParameter("@pi_Active", pModel.Active) ,
                                new SqlParameter("@pi_UserId", pModel.AuditColumns.UserId) ,
                                new SqlParameter("@pi_HostName", pModel.AuditColumns.HostName) ,
                                new SqlParameter("@pi_IPAddress", pModel.AuditColumns.IPAddress) ,
                                new SqlParameter("@pi_DeviceType", pModel.AuditColumns.DeviceType) ,
                                new SqlParameter("@pi_MACAddress", pModel.AuditColumns.MACAddress) ,
                ptyp_mHRMSAllowDependencyParameter,
                ptyp_mHRMSAllowSlabParameter,
                ptyp_mHRMSAllowOthersParameter,
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

        public async Task<SQLResult> Edit(HRMSAllowanceEntry pModel)
        {
            SQLResult result = new SQLResult();
            _Context.Database.BeginTransaction();
            try
            {
                // typ_mHRMSAllowDependencytable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSAllowDependencyParameter = new SqlParameter("@pi_typ_mHRMSAllowDependency", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSAllowDependency"
                };
                var pRowCollection_typ_mHRMSAllowDependency = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSAllowDependency)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSAllowDependencyId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSAllowanceId", SqlDbType.BigInt)
                                                , new SqlMetaData("ReferenceAllowanceId", SqlDbType.BigInt)
                                                , new SqlMetaData("TreatedAs", SqlDbType.BigInt)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSAllowDependencyId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSAllowanceId);
                    pRow.SetInt64(3, item.ReferenceAllowanceId);
                    pRow.SetInt64(4, item.TreatedAs);
                    pRow.SetBoolean(5, item.Active);
                    pRow.SetBoolean(6, item.Deleted);
                    pRow.SetInt32(7, item.EntryStatus);

                    pRowCollection_typ_mHRMSAllowDependency.Add(pRow);
                }

                if (pModel.DependencyStatus == true)
                {
                    ptyp_mHRMSAllowDependencyParameter.Value = pRowCollection_typ_mHRMSAllowDependency;

                }
                else
                {
                    ptyp_mHRMSAllowDependencyParameter.Value = null;
                }
                // typ_mHRMSAllowSlabtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSAllowSlabParameter = new SqlParameter("@pi_typ_mHRMSAllowSlab", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSAllowSlab"
                };
                var pRowCollection_typ_mHRMSAllowSlab = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSAllowSlab)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSAllowSlabId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSAllowanceId", SqlDbType.BigInt)
                                                , new SqlMetaData("MinValue", SqlDbType.Decimal, 36, 6)
                                                , new SqlMetaData("MaxValue", SqlDbType.Decimal, 36, 6)
                                                , new SqlMetaData("ValueTypeId", SqlDbType.BigInt)
                                                , new SqlMetaData("SlabValue", SqlDbType.Decimal, 36, 6)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSAllowSlabId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSAllowanceId);
                    pRow.SetDecimal(3, item.MinValue);
                    pRow.SetDecimal(4, item.MaxValue);
                    pRow.SetInt64(5, item.ValueTypeId);
                    pRow.SetDecimal(6, item.SlabValue);
                    pRow.SetBoolean(7, item.Active);
                    pRow.SetBoolean(8, item.Deleted);
                    pRow.SetInt32(9, item.EntryStatus);

                    pRowCollection_typ_mHRMSAllowSlab.Add(pRow);
                }

                if (pModel.SlabStatus == true)
                {

                    ptyp_mHRMSAllowSlabParameter.Value = pRowCollection_typ_mHRMSAllowSlab;

                }
                else
                {

                    ptyp_mHRMSAllowSlabParameter.Value = null;
                }

                // typ_mHRMSAllowOtherstable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSAllowOthersParameter = new SqlParameter("@pi_typ_mHRMSAllowOthers", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSAllowOthers"
                };
                var pRowCollection_typ_mHRMSAllowOthers = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSAllowOthers)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSAllowOthersId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSAllowanceId", SqlDbType.BigInt)
                                                , new SqlMetaData("PropertyType", SqlDbType.BigInt)
                                                , new SqlMetaData("PropertyValue", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("MinMaxCheck", SqlDbType.Bit)
                                                , new SqlMetaData("MinValue", SqlDbType.Decimal, 36, 6)
                                                , new SqlMetaData("MaxValue", SqlDbType.Decimal, 36, 6)
                                                , new SqlMetaData("ValueType", SqlDbType.BigInt)
                                                , new SqlMetaData("OthersValue", SqlDbType.Decimal, 36, 6)
                                                , new SqlMetaData("TreatedAs", SqlDbType.BigInt)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSAllowOthersId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSAllowanceId);
                    pRow.SetInt64(3, item.PropertyType);
                    pRow.SetString(4, item.PropertyValue);
                    pRow.SetBoolean(5, item.MinMaxCheck);
                    pRow.SetDecimal(6, item.MinValue);
                    pRow.SetDecimal(7, item.MaxValue);
                    pRow.SetInt64(8, item.ValueType);
                    pRow.SetDecimal(9, item.OthersValue);
                    pRow.SetInt64(10, item.TreatedAs);
                    pRow.SetBoolean(11, item.Active);
                    pRow.SetBoolean(12, item.Deleted);
                    pRow.SetInt32(13, item.EntryStatus);

                    pRowCollection_typ_mHRMSAllowOthers.Add(pRow);
                }

                if (pModel.OthersStatus == true)
                {

                    ptyp_mHRMSAllowOthersParameter.Value = pRowCollection_typ_mHRMSAllowOthers;

                }
                else
                {
                    ptyp_mHRMSAllowOthersParameter.Value = null;

                }

                string csql = @" EXEC spmHRMSAllowanceUpdate
                    @pi_mHRMSAllowanceId
                    , @pi_AllowanceCode
                    , @pi_AllowanceName
                    , @pi_AllowanceDescription
                    , @pi_AllowanceTypeId
                    , @pi_AllowanceGroup
                    , @pi_GrossCheck
                    , @pi_EffectiveDateFrom
                    , @pi_EffectiveDateTo
                    , @pi_ValueTypeId
                    , @pi_Value
                    , @pi_DependencyStatus
                    , @pi_SlabStatus
                    , @pi_OthersStatus
                    , @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
                    , @pi_typ_mHRMSAllowDependency
                    , @pi_typ_mHRMSAllowSlab
                    , @pi_typ_mHRMSAllowOthers
                ";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                                new SqlParameter("@pi_mHRMSAllowanceId", pModel.HRMSAllowanceId) ,
                                new SqlParameter("@pi_AllowanceCode", pModel.AllowanceCode) ,
                                new SqlParameter("@pi_AllowanceName", pModel.AllowanceName) ,
                                new SqlParameter("@pi_AllowanceDescription", pModel.AllowanceDescription) ,
                                new SqlParameter("@pi_AllowanceTypeId", pModel.AllowanceTypeId) ,
                                new SqlParameter("@pi_AllowanceGroup", pModel.AllowanceGroup) ,
                                new SqlParameter("@pi_GrossCheck", pModel.GrossCheck) ,
                                new SqlParameter("@pi_EffectiveDateFrom", pModel.EffectiveDateFrom) ,
                                new SqlParameter("@pi_EffectiveDateTo", pModel.EffectiveDateTo) ,
                                new SqlParameter("@pi_ValueTypeId", pModel.ValueTypeId) ,
                                new SqlParameter("@pi_Value", pModel.Value) ,
                                new SqlParameter("@pi_DependencyStatus", pModel.DependencyStatus) ,
                                new SqlParameter("@pi_SlabStatus", pModel.SlabStatus) ,
                                new SqlParameter("@pi_OthersStatus", pModel.OthersStatus) ,
                                new SqlParameter("@pi_Active", pModel.Active) ,
                                new SqlParameter("@pi_UserId", pModel.AuditColumns.UserId) ,
                                new SqlParameter("@pi_HostName", pModel.AuditColumns.HostName) ,
                                new SqlParameter("@pi_IPAddress", pModel.AuditColumns.IPAddress) ,
                                new SqlParameter("@pi_DeviceType", pModel.AuditColumns.DeviceType) ,
                                new SqlParameter("@pi_MACAddress", pModel.AuditColumns.MACAddress) ,
                ptyp_mHRMSAllowDependencyParameter,
                ptyp_mHRMSAllowSlabParameter,
                ptyp_mHRMSAllowOthersParameter,
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
