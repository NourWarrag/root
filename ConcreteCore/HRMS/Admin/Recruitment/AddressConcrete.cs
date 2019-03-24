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
    public class AddressConcrete
    {
        public async Task<SQLResult> Create(List<HRMSEmployeeAddressDetail> pModel, DatabaseContext _Context,AuditColumns auditColumns)
        {
         
            SQLResult result = new SQLResult();
           
            try
            {
                // typ_mAddressDetailtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mAddressDetailParameter = new SqlParameter("@pi_typ_mAddressDetail", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mAddressDetail"
                };
                var pRowCollection_typ_mAddressDetail = new List<SqlDataRecord>();
                foreach (var item in pModel)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mAddressDetailId", SqlDbType.BigInt)
                                                , new SqlMetaData("mAddressId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mAddressTypeId", SqlDbType.BigInt)
                                                , new SqlMetaData("Address", SqlDbType.NVarChar, 1000)
                                                , new SqlMetaData("mCountryId", SqlDbType.BigInt)
                                                , new SqlMetaData("mStateId", SqlDbType.BigInt)
                                                , new SqlMetaData("mCityId", SqlDbType.BigInt)
                                                , new SqlMetaData("PINCode", SqlDbType.NVarChar, 10)
                                                , new SqlMetaData("DefaultFlag", SqlDbType.Bit)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.AddressDetailId);
                    pRow.SetInt64(1, item.AddressId);
                    pRow.SetInt32(2, item.SrNo);
                    pRow.SetInt64(3, item.AddressTypeId);
                    pRow.SetString(4, item.Address);
                    pRow.SetInt64(5, item.CountryId);
                    pRow.SetInt64(6, item.StateId);
                    pRow.SetInt64(7, item.CityId);
                    pRow.SetString(8, item.PINCode);
                    pRow.SetBoolean(9, item.DefaultFlag);
                    pRow.SetBoolean(10, item.Active);
                    pRow.SetBoolean(11, item.Deleted);
                    pRow.SetInt32(12, (int)item.EntryStatus);

                    pRowCollection_typ_mAddressDetail.Add(pRow);
                }

                ptyp_mAddressDetailParameter.Value = pRowCollection_typ_mAddressDetail;
                string csql = @" EXEC spmAddressInsert
                    @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
                    , @pi_typ_mAddressDetail
                ";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                                new SqlParameter("@pi_Active",true) ,
                                new SqlParameter("@pi_UserId", auditColumns.UserId) ,
                                new SqlParameter("@pi_HostName", auditColumns.HostName) ,
                                new SqlParameter("@pi_IPAddress", auditColumns.IPAddress) ,
                                new SqlParameter("@pi_DeviceType", auditColumns.DeviceType) ,
                                new SqlParameter("@pi_MACAddress", auditColumns.MACAddress) ,
                ptyp_mAddressDetailParameter,
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

        public async Task<SQLResult> Edit(List<HRMSEmployeeAddressDetail> pModel,DatabaseContext _Context,AuditColumns auditColumns,bool Active)
        {
            SQLResult result = new SQLResult();
           
            try
            {
                // typ_mAddressDetailtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mAddressDetailParameter = new SqlParameter("@pi_typ_mAddressDetail", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mAddressDetail"
                };
                var pRowCollection_typ_mAddressDetail = new List<SqlDataRecord>();
                foreach (var item in pModel)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mAddressDetailId", SqlDbType.BigInt)
                                                , new SqlMetaData("mAddressId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mAddressTypeId", SqlDbType.BigInt)
                                                , new SqlMetaData("Address", SqlDbType.NVarChar, 1000)
                                                , new SqlMetaData("mCountryId", SqlDbType.BigInt)
                                                , new SqlMetaData("mStateId", SqlDbType.BigInt)
                                                , new SqlMetaData("mCityId", SqlDbType.BigInt)
                                                , new SqlMetaData("PINCode", SqlDbType.NVarChar, 10)
                                                , new SqlMetaData("DefaultFlag", SqlDbType.Bit)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.AddressDetailId);
                    pRow.SetInt64(1, item.AddressId);
                    pRow.SetInt32(2, item.SrNo);
                    pRow.SetInt64(3, item.AddressTypeId);
                    pRow.SetString(4, item.Address);
                    pRow.SetInt64(5, item.CountryId);
                    pRow.SetInt64(6, item.StateId);
                    pRow.SetInt64(7, item.CityId);
                    pRow.SetString(8, item.PINCode);
                    pRow.SetBoolean(9, item.DefaultFlag);
                    pRow.SetBoolean(10, item.Active);
                    pRow.SetBoolean(11, item.Deleted);
                    pRow.SetInt32(12, (int)item.EntryStatus);

                    pRowCollection_typ_mAddressDetail.Add(pRow);
                }

                ptyp_mAddressDetailParameter.Value = pRowCollection_typ_mAddressDetail;
                string csql = @" EXEC spmAddressUpdate
                    @pi_mAddressId
                    , @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
                    , @pi_typ_mAddressDetail
                ";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                                new SqlParameter("@pi_mAddressId", pModel[0].AddressId) ,
                                new SqlParameter("@pi_Active", Active) ,
                                new SqlParameter("@pi_UserId", auditColumns.UserId) ,
                                new SqlParameter("@pi_HostName", auditColumns.HostName) ,
                                new SqlParameter("@pi_IPAddress", auditColumns.IPAddress) ,
                                new SqlParameter("@pi_DeviceType", auditColumns.DeviceType) ,
                                new SqlParameter("@pi_MACAddress", auditColumns.MACAddress) ,
                ptyp_mAddressDetailParameter,
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
