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
    public class MobileConcrete
    {
        public async Task<SQLResult> Create(List<HRMSEmployeeMobileDetail> pModel, DatabaseContext _Context,AuditColumns auditColumns)
        {
            SQLResult result = new SQLResult();
           
            try
            {
                // typ_mMobileDetailtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mMobileDetailParameter = new SqlParameter("@pi_typ_mMobileDetail", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mMobileDetail"
                };
                var pRowCollection_typ_mMobileDetail = new List<SqlDataRecord>();
                foreach (HRMSEmployeeMobileDetail item in pModel)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mMobileDetailId", SqlDbType.BigInt)
                                                , new SqlMetaData("mMobileId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mMobileTypeId", SqlDbType.BigInt)
                                                , new SqlMetaData("CountryCode", SqlDbType.Decimal, 10, 0)
                                                , new SqlMetaData("MobileNo", SqlDbType.Decimal, 30, 0)
                                                , new SqlMetaData("DefaultFlag", SqlDbType.Bit)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.MobileDetailId);
                    pRow.SetInt64(1, item.MobileId);
                    pRow.SetInt32(2, item.SrNo);
                    pRow.SetInt64(3, item.MobileTypeId);
                    pRow.SetDecimal(4, item.CountryCode);
                    pRow.SetDecimal(5, item.MobileNo);
                    pRow.SetBoolean(6, item.DefaultFlag);
                    pRow.SetBoolean(7, item.Active);
                    pRow.SetBoolean(8, item.Deleted);
                    pRow.SetInt32(9, (int)item.EntryStatus);

                    pRowCollection_typ_mMobileDetail.Add(pRow);
                }

                ptyp_mMobileDetailParameter.Value = pRowCollection_typ_mMobileDetail;
                string csql = @" EXEC spmMobileInsert
                    @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
                    , @pi_typ_mMobileDetail
                ";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                                new SqlParameter("@pi_Active", 1),
                                new SqlParameter("@pi_UserId", auditColumns.UserId) ,
                                new SqlParameter("@pi_HostName", auditColumns.HostName) ,
                                new SqlParameter("@pi_IPAddress", auditColumns.IPAddress) ,
                                new SqlParameter("@pi_DeviceType", auditColumns.DeviceType) ,
                                new SqlParameter("@pi_MACAddress", auditColumns.MACAddress) ,
                ptyp_mMobileDetailParameter,
                };
                result = await _Context.DBResult.FromSql(csql, sqlparam.ToArray()).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                result.ErrorNo = 9999999999;
                result.ErrorMessage = ex.Message.ToString();
                result.SQLErrorNumber = ex.HResult;
                result.SQLErrorMessage = ex.Source.ToString();
            }
            return result;
        }

        public async Task<SQLResult> Edit(List<HRMSEmployeeMobileDetail> pModel,DatabaseContext _Context,AuditColumns auditColumns,bool Active)
        {
            SQLResult result = new SQLResult();
        
            try
            {
                // typ_mMobileDetailtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mMobileDetailParameter = new SqlParameter("@pi_typ_mMobileDetail", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mMobileDetail"
                };
                var pRowCollection_typ_mMobileDetail = new List<SqlDataRecord>();
                foreach (var item in pModel)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mMobileDetailId", SqlDbType.BigInt)
                                                , new SqlMetaData("mMobileId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mMobileTypeId", SqlDbType.BigInt)
                                                , new SqlMetaData("CountryCode", SqlDbType.Decimal, 10, 0)
                                                , new SqlMetaData("MobileNo", SqlDbType.Decimal, 30, 0)
                                                , new SqlMetaData("DefaultFlag", SqlDbType.Bit)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.MobileDetailId);
                    pRow.SetInt64(1, item.MobileId);
                    pRow.SetInt32(2, item.SrNo);
                    pRow.SetInt64(3, item.MobileTypeId);
                    pRow.SetDecimal(4, item.CountryCode);
                    pRow.SetDecimal(5, item.MobileNo);
                    pRow.SetBoolean(6, item.DefaultFlag);
                    pRow.SetBoolean(7, item.Active);
                    pRow.SetBoolean(8, item.Deleted);
                    pRow.SetInt32(9, (int)item.EntryStatus);

                    pRowCollection_typ_mMobileDetail.Add(pRow);
                }

                ptyp_mMobileDetailParameter.Value = pRowCollection_typ_mMobileDetail;
                string csql = @" EXEC spmMobileUpdate
                    @pi_mMobileId
                    , @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
                    , @pi_typ_mMobileDetail
                ";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                                new SqlParameter("@pi_mMobileId", pModel[0].MobileId) ,
                                new SqlParameter("@pi_Active", Active) ,
                                new SqlParameter("@pi_UserId", auditColumns.UserId) ,
                                new SqlParameter("@pi_HostName", auditColumns.HostName) ,
                                new SqlParameter("@pi_IPAddress", auditColumns.IPAddress) ,
                                new SqlParameter("@pi_DeviceType", auditColumns.DeviceType) ,
                                new SqlParameter("@pi_MACAddress", auditColumns.MACAddress) ,
                ptyp_mMobileDetailParameter,
                };
                result = await _Context.DBResult.FromSql(csql, sqlparam.ToArray()).SingleOrDefaultAsync();
             
            }
            catch (Exception ex)
            {
              
                result.ErrorNo = 9999999999;
                result.ErrorMessage = ex.Message.ToString();
                result.SQLErrorNumber = ex.HResult;
                result.SQLErrorMessage = ex.Source.ToString();
            }
            return result;
        }



    }
}
