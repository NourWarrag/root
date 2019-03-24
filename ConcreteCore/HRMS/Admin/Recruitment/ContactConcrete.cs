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
    public class ContactConcrete
    {

        //DatabaseContext _Context;
        //public ContactConcrete(DatabaseContext context)
        //{
        //    _Context = context;
        //}

        //public async Task<C> GetEntry(Int64 Id)

        //{

        //    try
        //    {

        //        ContactEntry mPageData = await _Context.GetContactEntry.FromSql(

        //             @"EXEC spmContactEntry @pi_Id, @pi_mContactId",

        //               new SqlParameter("pi_Id", 1)

        //             , new SqlParameter("pi_mContactId", Id)).SingleOrDefaultAsync();

        //        mPageData.ContactDetail = await _Context.GetContactDetail.FromSql(

        //            @"EXEC spmContactEntry @pi_Id, @pi_mContactId",

        //              new SqlParameter("pi_Id", 1)

        //            , new SqlParameter("pi_mContactId", Id)).ToListAsync();

        //        mPageData.AddressDetail = await _Context.GetAddressDetail.FromSql(

        //            @"EXEC spmContactEntry @pi_Id, @pi_mContactId",

        //              new SqlParameter("pi_Id", 5)

        //            , new SqlParameter("pi_mContactId", Id)).ToListAsync();

        //        mPageData.EmailDetail = await _Context.GetEmailDetail.FromSql(

        //            @"EXEC spmContactEntry @pi_Id, @pi_mContactId",

        //              new SqlParameter("pi_Id", 4)

        //            , new SqlParameter("pi_mContactId", Id)).ToListAsync();
        //        mPageData.MobileDetail = await _Context.GetMobileDetail.FromSql(

        //            @"EXEC spmContactEntry @pi_Id, @pi_mContactId",

        //              new SqlParameter("pi_Id", 3)

        //            , new SqlParameter("pi_mContactId", Id)).ToListAsync();

        //        return mPageData;

        //    }

        //    catch (Exception Ex)

        //    {

        //        throw Ex;

        //    }

        //}

        public async Task<SQLResult> Create(List<HRMSEmployeeContactDetail> pModel, DatabaseContext _Context,AuditColumns auditColumns)
        {
            SQLResult result = new SQLResult();
            try
            {

               
                // typ_mContactDetailtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mContactDetailParameter = new SqlParameter("@pi_typ_mContactDetail", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mContactDetail"
                };
                var pRowCollection_typ_mContactDetail = new List<SqlDataRecord>();
                foreach (var item in pModel)
                {
                    SQLResult lMobileResult = new SQLResult();
                    MobileConcrete mobileConcrete = new MobileConcrete();
                   lMobileResult = await mobileConcrete.Create(item.MobileDetail, _Context, auditColumns);
                    if (lMobileResult.ErrorNo != 0)
                    {
                       
                        return lMobileResult;
                    }

                    SQLResult lAddressResult = new SQLResult();
                    AddressConcrete addressConcrete = new AddressConcrete();
                    lAddressResult = await addressConcrete.Create(item.AddressDetail, _Context, auditColumns);
                    if (lAddressResult.ErrorNo != 0)
                    {
                    
                        return lAddressResult;
                    }


                    SQLResult lEmailResult = new SQLResult();
                    EmailConcrete emailConcrete = new EmailConcrete();
                    lEmailResult = await emailConcrete.Create(item.EmailDetail, _Context, auditColumns);
                    if (lEmailResult.ErrorNo != 0)
                    {
                  
                        return lEmailResult;
                    }

                    SQLResult lPhoneResult = new SQLResult();
                    PhoneConcrete phoneConcrete = new PhoneConcrete();
                    lPhoneResult = await phoneConcrete.Create(item.PhoneDetail, _Context, auditColumns);
                    if (lPhoneResult.ErrorNo != 0)
                    {
                
                        return lPhoneResult;
                    }


                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mContactDetailId", SqlDbType.BigInt)
                                                , new SqlMetaData("mContactId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mContactTypeId", SqlDbType.BigInt)
                                                , new SqlMetaData("mTitleId", SqlDbType.BigInt)
                                                , new SqlMetaData("ContactName", SqlDbType.NVarChar, 100)
                                                , new SqlMetaData("Designation", SqlDbType.NVarChar, 100)
                                                , new SqlMetaData("mAddressId", SqlDbType.BigInt)
                                                , new SqlMetaData("mPhoneId", SqlDbType.BigInt)
                                                , new SqlMetaData("mMobieId", SqlDbType.BigInt)
                                                , new SqlMetaData("mEmailId", SqlDbType.BigInt)
                                                , new SqlMetaData("Default", SqlDbType.Bit)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.ContactDetailId);
                    pRow.SetInt64(1, item.ContactId);
                    pRow.SetInt32(2, item.SrNo);
                    pRow.SetInt64(3, item.ContactTypeId);
                    pRow.SetInt64(4, item.TitleId);
                    pRow.SetString(5, item.ContactName);
                    pRow.SetString(6, item.Designation);
                    pRow.SetInt64(7, lAddressResult.ID);
                    pRow.SetInt64(8, lPhoneResult.ID);
                    pRow.SetInt64(9, lMobileResult.ID);
                    pRow.SetInt64(10, lEmailResult.ID);
                    pRow.SetBoolean(11, item.Default);
                    pRow.SetBoolean(12, item.Active);
                    pRow.SetBoolean(13, item.Deleted);
                    pRow.SetInt32(14, (int)item.EntryStatus);

                    pRowCollection_typ_mContactDetail.Add(pRow);
                }

                ptyp_mContactDetailParameter.Value = pRowCollection_typ_mContactDetail;
                string csql = @" EXEC spmContactInsert
                    @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
                    , @pi_typ_mContactDetail
                ";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                                new SqlParameter("@pi_Active", true) ,
                                new SqlParameter("@pi_UserId", auditColumns.UserId) ,
                                new SqlParameter("@pi_HostName", auditColumns.HostName) ,
                                new SqlParameter("@pi_IPAddress", auditColumns.IPAddress) ,
                                new SqlParameter("@pi_DeviceType", auditColumns.DeviceType) ,
                                new SqlParameter("@pi_MACAddress", auditColumns.MACAddress) ,
                ptyp_mContactDetailParameter,
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

        public async Task<SQLResult> Edit(List<HRMSEmployeeContactDetail> pModel,DatabaseContext _Context,
            AuditColumns auditColumns,bool Active)
        {
            SQLResult result = new SQLResult();
        
            try
            {
                // typ_mContactDetailtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mContactDetailParameter = new SqlParameter("@pi_typ_mContactDetail", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mContactDetail"
                };
                var pRowCollection_typ_mContactDetail = new List<SqlDataRecord>();
                foreach (var item in pModel)
                {
                    SQLResult lMobileResult = new SQLResult();
                    MobileConcrete mobileConcrete = new MobileConcrete();
                    lMobileResult = await mobileConcrete.Edit(item.MobileDetail, _Context, auditColumns,Active);
                    if (lMobileResult.ErrorNo != 0)
                    {

                        return lMobileResult;
                    }


                    SQLResult lAddressResult = new SQLResult();
                    AddressConcrete addressConcrete = new AddressConcrete();
                    lAddressResult = await addressConcrete.Edit(item.AddressDetail, _Context, auditColumns,Active);
                    if (lAddressResult.ErrorNo != 0)
                    {

                        return lAddressResult;
                    }

                    SQLResult lEmailResult = new SQLResult();
                    EmailConcrete emailConcrete = new EmailConcrete();
                    lEmailResult = await emailConcrete.Edit(item.EmailDetail, _Context, auditColumns,Active);

                    if (lEmailResult.ErrorNo != 0)
                    {

                        return lEmailResult;
                    }

                    SQLResult lPhoneResult = new SQLResult();
                    PhoneConcrete phoneConcrete = new PhoneConcrete();
                    lPhoneResult = await phoneConcrete.Edit(item.PhoneDetail, _Context, auditColumns, Active);
                    if (lPhoneResult.ErrorNo != 0)
                    {
                   
                        return lPhoneResult;
                    }


                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mContactDetailId", SqlDbType.BigInt)
                                                , new SqlMetaData("mContactId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mContactTypeId", SqlDbType.BigInt)
                                                , new SqlMetaData("mTitleId", SqlDbType.BigInt)
                                                , new SqlMetaData("ContactName", SqlDbType.NVarChar, 100)
                                                , new SqlMetaData("Designation", SqlDbType.NVarChar, 100)
                                                , new SqlMetaData("mAddressId", SqlDbType.BigInt)
                                                , new SqlMetaData("mPhoneId", SqlDbType.BigInt)
                                                , new SqlMetaData("mMobileId", SqlDbType.BigInt)
                                                , new SqlMetaData("mEmailId", SqlDbType.BigInt)
                                                , new SqlMetaData("Default", SqlDbType.Bit)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.ContactDetailId);
                    pRow.SetInt64(1, item.ContactId);
                    pRow.SetInt32(2, item.SrNo);
                    pRow.SetInt64(3, item.ContactTypeId);
                    pRow.SetInt64(4, item.TitleId);
                    pRow.SetString(5, item.ContactName);
                    pRow.SetString(6, item.Designation);
                    pRow.SetInt64(7, item.AddressId);
                    pRow.SetInt64(8, item.PhoneId);     
                    pRow.SetInt64(9, item.MobileId);
                    pRow.SetInt64(10, item.EmailId);
                    pRow.SetBoolean(11, item.Default);
                    pRow.SetBoolean(12, item.Active);
                    pRow.SetBoolean(13, item.Deleted);
                    pRow.SetInt32(14,(int) item.EntryStatus);

                    pRowCollection_typ_mContactDetail.Add(pRow);
                }

                ptyp_mContactDetailParameter.Value = pRowCollection_typ_mContactDetail;
                string csql = @" EXEC spmContactUpdate
                    @pi_mContactId
                    , @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
                    , @pi_typ_mContactDetail
                ";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                                new SqlParameter("@pi_mContactId", pModel[0].ContactId) ,
                                new SqlParameter("@pi_Active", Active) ,
                                new SqlParameter("@pi_UserId", auditColumns.UserId) ,
                                new SqlParameter("@pi_HostName", auditColumns.HostName) ,
                                new SqlParameter("@pi_IPAddress", auditColumns.IPAddress) ,
                                new SqlParameter("@pi_DeviceType", auditColumns.DeviceType) ,
                                new SqlParameter("@pi_MACAddress", auditColumns.MACAddress) ,
                ptyp_mContactDetailParameter,
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
