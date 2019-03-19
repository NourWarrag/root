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
    public class HRMSInventoryConcrete : IHRMSInventory
    {
        private readonly DatabaseContext _Context;

        public HRMSInventoryConcrete(DatabaseContext context)
        {
            _Context = context;
        }


        public async Task<List<HRMSInventoryIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage)
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
                return await _Context.HRMSInventoryIndex.FromSql(csql, sqlparam.ToArray()).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HRMSInventoryEntry> GetEntry(Int64 Id)

        {
            try
            {

                HRMSInventoryEntry mPageData = await _Context.HRMSInventoryEntry.FromSql(

                    @"EXEC spmHRMSInventoryEntry @pi_Id, @pi_HRMSInventoryDetailId",

                      new SqlParameter("pi_Id", 1)

                    , new SqlParameter("pi_HRMSInventoryDetailId", Id)).SingleOrDefaultAsync();

                mPageData.HRMSInventoryDetail = await _Context.GetHRMSInventoryDetails.FromSql(

                    @"EXEC spmHRMSInventoryEntry @pi_Id, @pi_HRMSInventoryDetailId",

                      new SqlParameter("pi_Id", 2)

                    , new SqlParameter("pi_HRMSInventoryDetailId", Id)).ToListAsync();

                return mPageData;

            }

            catch (Exception Ex)

            {

                throw Ex;

            }

        }

        public async Task<SQLResult> Create(HRMSInventoryEntry pModel)
        {
            SQLResult result = new SQLResult();
            _Context.Database.BeginTransaction();
            try
            {
                // typ_mHRMSInventoryDetailtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSInventoryDetailParameter = new SqlParameter("@pi_typ_mHRMSInventoryDetail", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSInventoryDetail"
                };
                var pRowCollection_typ_mHRMSInventoryDetail = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSInventoryDetail)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSInventoryDetailId", SqlDbType.BigInt),
                                                new SqlMetaData("SrNo", SqlDbType.Int),
                                                new SqlMetaData("mHRMSInventoryId", SqlDbType.BigInt),
                                                new SqlMetaData("mHRMSAttributeId", SqlDbType.BigInt),
                                                new SqlMetaData("AttributeValue", SqlDbType.NVarChar,100),
                                                new SqlMetaData("Active", SqlDbType.Bit),
                                                new SqlMetaData("Deleted", SqlDbType.Bit),
                                                new SqlMetaData("EntryStatus",SqlDbType.BigInt)
                                            );
                    pRow.SetInt64(0, item.HRMSInventoryDetailId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSInventoryId);
                    pRow.SetInt64(3, item.HRMSAttributeId);
                    pRow.SetString(4, item.AttributeValue);
                    pRow.SetBoolean(5, item.Active);
                    pRow.SetBoolean(6, item.Deleted);
                    pRow.SetInt64(7, (int)item.EntryStatus);

                    pRowCollection_typ_mHRMSInventoryDetail.Add(pRow);
                }

                ptyp_mHRMSInventoryDetailParameter.Value = pRowCollection_typ_mHRMSInventoryDetail;
                string csql = @" EXEC spmHRMSInventoryInsert
                    @pi_InventoryName
                    , @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
                    , @pi_typ_mHRMSInventoryDetail
                ";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                 new SqlParameter("@pi_InventoryName", pModel.InventoryName) ,
                 new SqlParameter("@pi_Active", pModel.Active) ,
                 new SqlParameter("@pi_UserId", pModel.AuditColumns.UserId) ,
                 new SqlParameter("@pi_HostName", pModel.AuditColumns.HostName) ,
                 new SqlParameter("@pi_IPAddress", pModel.AuditColumns.IPAddress) ,
                 new SqlParameter("@pi_DeviceType", pModel.AuditColumns.DeviceType) ,
                 new SqlParameter("@pi_MACAddress", pModel.AuditColumns.MACAddress) ,
                 ptyp_mHRMSInventoryDetailParameter
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

        public async Task<SQLResult> Edit(HRMSInventoryEntry pModel)
        {
            SQLResult result = new SQLResult();
            _Context.Database.BeginTransaction();
            try
            {
                // typ_mHRMSInventoryDetailtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSInventoryDetailParameter = new SqlParameter("@pi_typ_mHRMSInventoryDetail", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSInventoryDetail"
                };
                var pRowCollection_typ_mHRMSInventoryDetail = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSInventoryDetail)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSInventoryDetailId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSInventoryId", SqlDbType.BigInt)
                                                , new SqlMetaData("mHRMSAttributeId", SqlDbType.BigInt)
                                                , new SqlMetaData("AttributeValue", SqlDbType.NVarChar,256)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSInventoryDetailId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSInventoryId);
                    pRow.SetInt64(3, item.HRMSAttributeId);
                    pRow.SetString(4, item.AttributeValue);
                    pRow.SetBoolean(5, item.Active);
                    pRow.SetBoolean(6, item.Deleted);
                    pRow.SetInt32(7, Convert.ToInt32(item.EntryStatus));

                    pRowCollection_typ_mHRMSInventoryDetail.Add(pRow);
                }

                ptyp_mHRMSInventoryDetailParameter.Value = pRowCollection_typ_mHRMSInventoryDetail;
                string csql = @" EXEC spmHRMSInventoryUpdate
                        @pi_mHRMSInventoryId
                        , @pi_InventoryName
                        , @pi_Active
                        , @pi_UserId
                        , @pi_HostName
                        , @pi_IPAddress
                        , @pi_DeviceType
                        , @pi_MACAddress
                        , @pi_typ_mHRMSInventoryDetail
                        ";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                        new SqlParameter("@pi_mHRMSInventoryId", pModel.HRMSInventoryId) ,
                        new SqlParameter("@pi_InventoryName", pModel.InventoryName) ,
                        new SqlParameter("@pi_Active", pModel.Active) ,
                        new SqlParameter("@pi_UserId", pModel.AuditColumns.UserId) ,
                        new SqlParameter("@pi_HostName", pModel.AuditColumns.HostName) ,
                        new SqlParameter("@pi_IPAddress", pModel.AuditColumns.IPAddress) ,
                        new SqlParameter("@pi_DeviceType", pModel.AuditColumns.DeviceType) ,
                        new SqlParameter("@pi_MACAddress", pModel.AuditColumns.MACAddress) ,
                        @ptyp_mHRMSInventoryDetailParameter
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