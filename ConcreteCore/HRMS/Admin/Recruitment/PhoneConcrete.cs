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
    public class PhoneConcrete
    {
        public async Task<SQLResult> Create(List<PhoneDetail> pModel, DatabaseContext _Context, AuditColumns auditColumns)
        {
            SQLResult result = new SQLResult();
            try
            {
                // typ_mPhoneDetailtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mPhoneDetailParameter = new SqlParameter("@pi_typ_mPhoneDetail", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mPhoneDetail"
                };
                var pRowCollection_typ_mPhoneDetail = new List<SqlDataRecord>();
                foreach (var item in pModel)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mPhoneDetailId", SqlDbType.BigInt)
                                                , new SqlMetaData("mPhoneId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mPhoneTypeId", SqlDbType.BigInt)
                                                , new SqlMetaData("PhonePrefixCode", SqlDbType.Decimal, 10, 0)
                                                , new SqlMetaData("PhoneNo", SqlDbType.Decimal, 10, 0)
                                                , new SqlMetaData("Extension", SqlDbType.Decimal, 10, 0)
                                                , new SqlMetaData("Default", SqlDbType.Bit)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.PhoneDetailId);
                    pRow.SetInt64(1, item.PhoneId);
                    pRow.SetInt32(2, item.SrNo);
                    pRow.SetInt64(3, item.PhoneTypeId);
                    pRow.SetDecimal(4, item.PhonePrefixCode);
                    pRow.SetDecimal(5, item.PhoneNo);
                    pRow.SetDecimal(6, item.Extension);
                    pRow.SetBoolean(7, item.Default);
                    pRow.SetBoolean(8, item.Active);
                    pRow.SetBoolean(9, item.Deleted);
                    pRow.SetInt32(10, (int)item.EntryStatus);

                    pRowCollection_typ_mPhoneDetail.Add(pRow);
                }

                ptyp_mPhoneDetailParameter.Value = pRowCollection_typ_mPhoneDetail;
                string csql = @" EXEC spmPhoneInsert
                    @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
                    , @pi_typ_mPhoneDetail
                ";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                                new SqlParameter("@pi_Active", true) ,
                                new SqlParameter("@pi_UserId", auditColumns.UserId) ,
                                new SqlParameter("@pi_HostName", auditColumns.HostName) ,
                                new SqlParameter("@pi_IPAddress", auditColumns.IPAddress) ,
                                new SqlParameter("@pi_DeviceType", auditColumns.DeviceType) ,
                                new SqlParameter("@pi_MACAddress", auditColumns.MACAddress) ,
                ptyp_mPhoneDetailParameter,
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

        public async Task<SQLResult> Edit(List<PhoneDetail> pModel, DatabaseContext _Context, AuditColumns auditColumns, bool Active)
        {
            SQLResult result = new SQLResult();
        _Context.Database.BeginTransaction();
try
{
                // typ_mPhoneDetailtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mPhoneDetailParameter = new SqlParameter("@pi_typ_mPhoneDetail", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mPhoneDetail"
                };
        var pRowCollection_typ_mPhoneDetail = new List<SqlDataRecord>();
                foreach (var item in pModel)
                {
 
                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mPhoneDetailId", SqlDbType.BigInt)
                                                , new SqlMetaData("mPhoneId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mPhoneTypeId", SqlDbType.BigInt)
                                                , new SqlMetaData("PhonePrefixCode", SqlDbType.Decimal, 10, 0)
                                                , new SqlMetaData("PhoneNo", SqlDbType.Decimal, 10, 0)
                                                , new SqlMetaData("Extension", SqlDbType.Decimal, 10, 0)
                                                , new SqlMetaData("Default", SqlDbType.Bit)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

        pRow.SetInt64(0, item.PhoneDetailId);
                    pRow.SetInt64(1, item.PhoneId);
                    pRow.SetInt32(2, item.SrNo);
                    pRow.SetInt64(3, item.PhoneTypeId);
                    pRow.SetDecimal(4, item.PhonePrefixCode);
                    pRow.SetDecimal(5, item.PhoneNo);
                    pRow.SetDecimal(6, item.Extension);
                    pRow.SetBoolean(7, item.Default);
                    pRow.SetBoolean(8, item.Active);
                    pRow.SetBoolean(9, item.Deleted);
                    pRow.SetInt32(10, (int)item.EntryStatus);
 
                    pRowCollection_typ_mPhoneDetail.Add(pRow);
                }

    ptyp_mPhoneDetailParameter.Value = pRowCollection_typ_mPhoneDetail;
                string csql = @" EXEC spmPhoneUpdate
                    @pi_mPhoneId
                    , @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
                    , @pi_typ_mPhoneDetail
                ";
    List<SqlParameter> sqlparam = new List<SqlParameter>() {
                                new SqlParameter("@pi_mPhoneId", pModel[0].PhoneId) ,
                                new SqlParameter("@pi_Active", Active) ,
                                new SqlParameter("@pi_UserId", auditColumns.UserId) ,
                                new SqlParameter("@pi_HostName", auditColumns.HostName) ,
                                new SqlParameter("@pi_IPAddress", auditColumns.IPAddress) ,
                                new SqlParameter("@pi_DeviceType", auditColumns.DeviceType) ,
                                new SqlParameter("@pi_MACAddress", auditColumns.MACAddress) ,
                ptyp_mPhoneDetailParameter,
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