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
    public class EmailConcrete
    {
        public async Task<SQLResult> Create(List<EmailDetail> pModel, DatabaseContext _Context,AuditColumns auditColumns)
        {
            SQLResult result = new SQLResult();
         
            try
            {
                // typ_mEmailDetailtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mEmailDetailParameter = new SqlParameter("@pi_typ_mEmailDetail", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mEmailDetail"
                };
                var pRowCollection_typ_mEmailDetail = new List<SqlDataRecord>();
                foreach (var item in pModel)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mEmailDetailId", SqlDbType.BigInt)
                                                , new SqlMetaData("mEmailId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mEmailTypeId", SqlDbType.BigInt)
                                                , new SqlMetaData("Email", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("Default", SqlDbType.Bit)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.EmailDetailId);
                    pRow.SetInt64(1, item.EmailId);
                    pRow.SetInt32(2, item.SrNo);
                    pRow.SetInt64(3, item.EmailTypeId);
                    pRow.SetString(4, item.Email);
                    pRow.SetBoolean(5, item.Default);
                    pRow.SetBoolean(6, item.Active);
                    pRow.SetBoolean(7, item.Deleted);
                    pRow.SetInt32(8, (int)item.EntryStatus);

                    pRowCollection_typ_mEmailDetail.Add(pRow);
                }

                ptyp_mEmailDetailParameter.Value = pRowCollection_typ_mEmailDetail;
                string csql = @" EXEC spmEmailInsert
                    @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
                    , @pi_typ_mEmailDetail
                ";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                                new SqlParameter("@pi_Active", true) ,
                                new SqlParameter("@pi_UserId", auditColumns.UserId) ,
                                new SqlParameter("@pi_HostName", auditColumns.HostName) ,
                                new SqlParameter("@pi_IPAddress", auditColumns.IPAddress) ,
                                new SqlParameter("@pi_DeviceType", auditColumns.DeviceType) ,
                                new SqlParameter("@pi_MACAddress", auditColumns.MACAddress) ,
                ptyp_mEmailDetailParameter,
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

        public async Task<SQLResult> Edit(List<EmailDetail> pModel,DatabaseContext _Context,AuditColumns auditColumns,bool Active)
        {
            SQLResult result = new SQLResult();
           
            try
            {
                // typ_mEmailDetailtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mEmailDetailParameter = new SqlParameter("@pi_typ_mEmailDetail", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mEmailDetail"
                };
                var pRowCollection_typ_mEmailDetail = new List<SqlDataRecord>();
                foreach (var item in pModel)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mEmailDetailId", SqlDbType.BigInt)
                                                , new SqlMetaData("mEmailId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mEmailTypeId", SqlDbType.BigInt)
                                                , new SqlMetaData("Email", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("Default", SqlDbType.Bit)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.EmailDetailId);
                    pRow.SetInt64(1, item.EmailId);
                    pRow.SetInt32(2, item.SrNo);
                    pRow.SetInt64(3, item.EmailTypeId);
                    pRow.SetString(4, item.Email);
                    pRow.SetBoolean(5, item.Default);
                    pRow.SetBoolean(6, item.Active);
                    pRow.SetBoolean(7, item.Deleted);
                    pRow.SetInt32(8, (int)item.EntryStatus);

                    pRowCollection_typ_mEmailDetail.Add(pRow);
                }

                ptyp_mEmailDetailParameter.Value = pRowCollection_typ_mEmailDetail;
                string csql = @" EXEC spmEmailUpdate
                    @pi_mEmailId
                    , @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
                    , @pi_typ_mEmailDetail
                ";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                                new SqlParameter("@pi_mEmailId", pModel[0].EmailId) ,
                                new SqlParameter("@pi_Active", Active) ,
                                new SqlParameter("@pi_UserId", auditColumns.UserId) ,
                                new SqlParameter("@pi_HostName", auditColumns.HostName) ,
                                new SqlParameter("@pi_IPAddress", auditColumns.IPAddress) ,
                                new SqlParameter("@pi_DeviceType", auditColumns.DeviceType) ,
                                new SqlParameter("@pi_MACAddress", auditColumns.MACAddress) ,
                ptyp_mEmailDetailParameter,
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
