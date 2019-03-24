using InterfaceCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using ModelCore.FA.BK.Master;
using ModelCore.HRMS.Admin.Recruitment;
using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ConcreteCore.HRMS.Admin.Recruitment
{
    public class HRMSEmployeeConcrete : IHRMSEmployee
    {

        private readonly DatabaseContext _Context;

        public HRMSEmployeeConcrete(DatabaseContext context)
        {
            _Context = context;
        }

        public async Task<List<HRMSEmployeeIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage)
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
                return await _Context.HRMSEmployeeIndex.FromSql(csql, sqlparam.ToArray()).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HRMSEmployeeEntry> GetEntry(Int64 Id)

        {

            try
            {

                HRMSEmployeeEntry mPageData = await _Context.HRMSEmployeeEntry.FromSql(

                    @"EXEC spmHRMSEmployeeEntry @pi_Id, @pi_HRMSEmployeeId",

                      new SqlParameter("pi_Id", 1)

                    , new SqlParameter("pi_HRMSEmployeeId", Id)).SingleOrDefaultAsync();

                mPageData.HRMSEmpEducation = await _Context.GetHRMSEmpEducation.FromSql(

                    @"EXEC spmHRMSEmployeeEntry @pi_Id, @pi_HRMSEmployeeId",

                      new SqlParameter("pi_Id", 2)

                    , new SqlParameter("pi_HRMSEmployeeId", Id)).ToListAsync();

                mPageData.HRMSEmpExperience = await _Context.GetHRMSEmpExperience.FromSql(

                    @"EXEC spmHRMSEmployeeEntry @pi_Id, @pi_HRMSEmployeeId",

                      new SqlParameter("pi_Id", 3)

                    , new SqlParameter("pi_HRMSEmployeeId", Id)).ToListAsync();


                mPageData.HRMSEmployeePersonalDetail = await _Context.GetHRMSEmployeePersonalDetail.FromSql(

                 @"EXEC spmHRMSEmployeeEntry @pi_Id, @pi_HRMSEmployeeId",

                   new SqlParameter("pi_Id", 4)

                 , new SqlParameter("pi_HRMSEmployeeId", Id)).ToListAsync();


                mPageData.HRMSEmpSkill = await _Context.GetHRMSEmpSkill.FromSql(

                    @"EXEC spmHRMSEmployeeEntry @pi_Id, @pi_HRMSEmployeeId",

                      new SqlParameter("pi_Id", 5)

                    , new SqlParameter("pi_HRMSEmployeeId", Id)).ToListAsync();

              
                mPageData.HRMSEmployeeRelatives = await _Context.GetHRMSEmployeeRelatives.FromSql(

                   @"EXEC spmHRMSEmployeeEntry @pi_Id, @pi_HRMSEmployeeId",

                     new SqlParameter("pi_Id", 6)

                   , new SqlParameter("pi_HRMSEmployeeId", Id)).ToListAsync();

                mPageData.HRMSEmployeeAdditionalSkill = await _Context.GetHRMSEmployeeAdditionalSkill.FromSql(

                  @"EXEC spmHRMSEmployeeEntry @pi_Id, @pi_HRMSEmployeeId",

                    new SqlParameter("pi_Id", 7)

                  , new SqlParameter("pi_HRMSEmployeeId", Id)).ToListAsync();

                mPageData.HRMSEmployeeNationalityDetail = await _Context.GetHRMSEmployeeNationalityDetail.FromSql(

                  @"EXEC spmHRMSEmployeeEntry @pi_Id, @pi_HRMSEmployeeId",

                    new SqlParameter("pi_Id", 8)

                  , new SqlParameter("pi_HRMSEmployeeId", Id)).ToListAsync();

                mPageData.HRMSEmployeeCTC = await _Context.GetHRMSEmployeeCTC.FromSql(

                   @"EXEC spmHRMSEmployeeEntry @pi_Id, @pi_HRMSEmployeeId",

                     new SqlParameter("pi_Id", 9)

                   , new SqlParameter("pi_HRMSEmployeeId", Id)).ToListAsync();

                mPageData.ContactDetail = await _Context.GetContactDetail.FromSql(

               @"EXEC spmHRMSEmployeeEntry @pi_Id, @pi_HRMSEmployeeId",

                 new SqlParameter("pi_Id", 10)

               , new SqlParameter("pi_HRMSEmployeeId", Id)).ToListAsync();



                mPageData.ContactDetail[0].MobileDetail = await _Context.GetMobileDetail.FromSql(

                   @"EXEC spmHRMSEmployeeEntry @pi_Id, @pi_HRMSEmployeeId",

                     new SqlParameter("pi_Id", 11)

                   , new SqlParameter("pi_HRMSEmployeeId", Id)).ToListAsync();

                mPageData.ContactDetail[0].EmailDetail = await _Context.GetEmailDetail.FromSql(

                  @"EXEC spmHRMSEmployeeEntry @pi_Id, @pi_HRMSEmployeeId",

                    new SqlParameter("pi_Id", 12)

                  , new SqlParameter("pi_HRMSEmployeeId", Id)).ToListAsync();

                mPageData.ContactDetail[0].AddressDetail = await _Context.GetAddressDetail.FromSql(

                 @"EXEC spmHRMSEmployeeEntry @pi_Id, @pi_HRMSEmployeeId",

                   new SqlParameter("pi_Id", 13)

                 , new SqlParameter("pi_HRMSEmployeeId", Id)).ToListAsync();

               
                mPageData.ContactDetail[0].PhoneDetail = await _Context.GetPhoneDetail.FromSql(

                @"EXEC spmHRMSEmployeeEntry @pi_Id, @pi_HRMSEmployeeId",

                  new SqlParameter("pi_Id", 14)

                , new SqlParameter("pi_HRMSEmployeeId", Id)).ToListAsync();




                return mPageData;

            }

            catch (Exception Ex)

            {

                throw Ex;

            }

        }


        public async Task<SQLResult> Create(HRMSEmployeeEntry pModel)
        {
            SQLResult result = new SQLResult();
            _Context.Database.BeginTransaction();
            try
            {

               
                SQLResult lContactResult = new SQLResult();
                ContactConcrete contactConcrete = new ContactConcrete();
                lContactResult = await contactConcrete.Create(pModel.ContactDetail, _Context, pModel.AuditColumns); //show me code of contact concrete

                
                if (lContactResult.ErrorNo != 0)
                {
                    _Context.Database.RollbackTransaction();
                    return lContactResult;
                }
                // typ_mHRMSEmpEducationtable type parameter declartaion with parameiter name and table type name
                SqlParameter ptyp_mHRMSEmpEducationParameter = new SqlParameter("@pi_typ_mHRMSEmpEducation", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSEmpEducation"
                };
                var pRowCollection_typ_mHRMSEmpEducation = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSEmpEducation)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSEmpEducationId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSEmployeeId", SqlDbType.BigInt)
                                                , new SqlMetaData("CertDegreeName", SqlDbType.NVarChar, 2000)
                                                , new SqlMetaData("Major", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("UniInstituteName", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("StartMonth", SqlDbType.Int)
                                                , new SqlMetaData("StartYear", SqlDbType.Int)
                                                , new SqlMetaData("CompletionMonth", SqlDbType.Int)
                                                , new SqlMetaData("CompletionYear", SqlDbType.Int)
                                                , new SqlMetaData("Grade", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSEmpEducationId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSEmployeeId);
                    pRow.SetString(3, item.CertDegreeName);
                    pRow.SetString(4, item.Major);
                    pRow.SetString(5, item.UniInstituteName);
                    pRow.SetInt32(6, item.StartMonth);
                    pRow.SetInt32(7, item.StartYear);
                    pRow.SetInt32(8, item.CompletionMonth);
                    pRow.SetInt32(9, item.CompletionYear);
                    pRow.SetString(10, item.Grade);
                    pRow.SetBoolean(11, item.Deleted);
                    pRow.SetInt32(12, (int)item.EntryStatus);

                    pRowCollection_typ_mHRMSEmpEducation.Add(pRow);
                }
                //if (pRowCollection_typ_mHRMSEmpEducation != null && pRowCollection_typ_mHRMSEmpEducation.Count > 0)
                //{
                    ptyp_mHRMSEmpEducationParameter.Value = pRowCollection_typ_mHRMSEmpEducation;
                //}
                //else
                //{
                //    ptyp_mHRMSEmpEducationParameter.Value = null;
                //}

                // typ_mHRMSEmpExperiencetable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSEmpExperienceParameter = new SqlParameter("@pi_typ_mHRMSEmpExperience", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSEmpExperience"
                };
                var pRowCollection_typ_mHRMSEmpExperience = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSEmpExperience)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSEmpExperienceId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSEmployeeId", SqlDbType.BigInt)
                                                , new SqlMetaData("CompanyName", SqlDbType.NVarChar, 200)
                                                , new SqlMetaData("Designation", SqlDbType.NVarChar, 500)
                                                , new SqlMetaData("JoinMonth", SqlDbType.Int)
                                                , new SqlMetaData("JoinYear", SqlDbType.Int)
                                                , new SqlMetaData("LeaveMonth", SqlDbType.Int)
                                                , new SqlMetaData("LeaveYear", SqlDbType.Int)
                                                , new SqlMetaData("MonthlySalary", SqlDbType.Decimal, 36, 6)
                                                , new SqlMetaData("mCountryId", SqlDbType.BigInt)
                                                , new SqlMetaData("mStateId", SqlDbType.BigInt)
                                                , new SqlMetaData("mCityId", SqlDbType.BigInt)
                                                , new SqlMetaData("Description", SqlDbType.NVarChar, 2000)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSEmpExperienceId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSEmployeeId);
                    pRow.SetString(3, item.CompanyName);
                    pRow.SetString(4, item.Designation);
                    pRow.SetInt32(5, item.JoinMonth);
                    pRow.SetInt32(6, item.JoinYear);
                    pRow.SetInt32(7, item.LeaveMonth);
                    pRow.SetInt32(8, item.LeaveYear);
                    pRow.SetDecimal(9, item.MonthlySalary);
                    pRow.SetInt64(10, item.CountryId);
                    pRow.SetInt64(11, item.StateId);
                    pRow.SetInt64(12, item.CityId);
                    pRow.SetString(13, item.Description);
                    pRow.SetBoolean(14, item.Deleted);
                    pRow.SetInt32(15, (int)item.EntryStatus);

                    pRowCollection_typ_mHRMSEmpExperience.Add(pRow);
                }

                if (pRowCollection_typ_mHRMSEmpExperience != null && pRowCollection_typ_mHRMSEmpExperience.Count > 0)
                {
                    ptyp_mHRMSEmpExperienceParameter.Value = pRowCollection_typ_mHRMSEmpExperience;

                }
                else
                {
                    ptyp_mHRMSEmpExperienceParameter.Value = null;
                }
                
                
                // typ_mHRMSEmpSkilltable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSEmpSkillParameter = new SqlParameter("@pi_typ_mHRMSEmpSkill", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSEmpSkill"
                };
                var pRowCollection_typ_mHRMSEmpSkill = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSEmpSkill)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSEmpSkillId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSEmployeeId", SqlDbType.BigInt)
                                                , new SqlMetaData("mHRMSSkillSetId", SqlDbType.BigInt)
                                                , new SqlMetaData("SkillLevel", SqlDbType.BigInt)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSEmpSkillId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSEmployeeId);
                    pRow.SetInt64(3, item.HRMSSkillSetId);
                    pRow.SetInt64(4, item.SkillLevel);
                    pRow.SetBoolean(5, item.Active);
                    pRow.SetBoolean(6, item.Deleted);
                    pRow.SetInt32(7, (int)item.EntryStatus);

                    pRowCollection_typ_mHRMSEmpSkill.Add(pRow);
                }
                if (pRowCollection_typ_mHRMSEmpSkill != null && pRowCollection_typ_mHRMSEmpSkill.Count > 0)
                {
                    ptyp_mHRMSEmpSkillParameter.Value = pRowCollection_typ_mHRMSEmpSkill;
                }
                else
                {
                    ptyp_mHRMSEmpSkillParameter.Value = null;
                }
                // typ_mHRMSEmployeeAdditionalSkilltable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSEmployeeAdditionalSkillParameter = new SqlParameter("@pi_typ_mHRMSEmployeeAdditionalSkill", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSEmployeeAdditionalSkill"
                };
                var pRowCollection_typ_mHRMSEmployeeAdditionalSkill = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSEmployeeAdditionalSkill)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSEmployeeAdditionalSkillId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSEmployeeId", SqlDbType.BigInt)
                                                , new SqlMetaData("Skill", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("SkillLevel", SqlDbType.BigInt)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSEmployeeAdditionalSkillId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSEmployeeId);
                    pRow.SetString(3, item.Skill);
                    pRow.SetInt64(4, item.SkillLevel);
                    pRow.SetBoolean(5, item.Active);
                    pRow.SetBoolean(6, item.Deleted);
                    pRow.SetInt32(7, (int)item.EntryStatus);

                    pRowCollection_typ_mHRMSEmployeeAdditionalSkill.Add(pRow);
                }
                if (pRowCollection_typ_mHRMSEmployeeAdditionalSkill != null && pRowCollection_typ_mHRMSEmployeeAdditionalSkill.Count > 0)
                {
                    ptyp_mHRMSEmployeeAdditionalSkillParameter.Value = pRowCollection_typ_mHRMSEmployeeAdditionalSkill;
                }
                else
                {
                    ptyp_mHRMSEmployeeAdditionalSkillParameter.Value = null;
                }
                    
                    // typ_mHRMSEmployeePersonalDetailtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSEmployeePersonalDetailParameter = new SqlParameter("@pi_typ_mHRMSEmployeePersonalDetail", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSEmployeePersonalDetail"
                };
                var pRowCollection_typ_mHRMSEmployeePersonalDetail = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSEmployeePersonalDetail)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSEmployeePersonalDetailId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSEmployeeId", SqlDbType.BigInt)
                                                , new SqlMetaData("mCompanyId", SqlDbType.BigInt)
                                                , new SqlMetaData("mBranchId", SqlDbType.BigInt)
                                                , new SqlMetaData("EmployeeName", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("FatherName", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("GrandfatherName", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("FamilyName", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("DOB", SqlDbType.DateTime)
                                                , new SqlMetaData("Gender", SqlDbType.BigInt)
                                                , new SqlMetaData("MaritalStatus", SqlDbType.BigInt)
                                                , new SqlMetaData("NumberOfFamilyMembers", SqlDbType.Int)
                                               
                                                , new SqlMetaData("mContactId", SqlDbType.BigInt)
                                               
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSEmployeePersonalDetailId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSEmployeeId);
                    pRow.SetInt64(3, item.CompanyId);
                    pRow.SetInt64(4, item.BranchId);
                    pRow.SetString(5, item.EmployeeName);
                    pRow.SetString(6, item.FatherName);
                    pRow.SetString(7, item.GrandfatherName);
                    pRow.SetString(8, item.FamilyName);
                    pRow.SetDateTime(9, item.DOB);
                    pRow.SetInt64(10, item.Gender);
                    pRow.SetInt64(11, item.MaritalStatus);
                    pRow.SetInt32(12, item.NumberOfFamilyMembers);    
                    pRow.SetInt64(13, lContactResult.ID);
                    pRow.SetBoolean(14, item.Active);
                    pRow.SetBoolean(15, item.Deleted);
                    pRow.SetInt32(16, (int)item.EntryStatus);

                    pRowCollection_typ_mHRMSEmployeePersonalDetail.Add(pRow);
                }
                //if ( pRowCollection_typ_mHRMSEmployeePersonalDetail != null &&  pRowCollection_typ_mHRMSEmployeePersonalDetail.Count > 0)
                //{
                ptyp_mHRMSEmployeePersonalDetailParameter.Value = pRowCollection_typ_mHRMSEmployeePersonalDetail;
                //}
                //else
                //{
                //    ptyp_mHRMSEmployeePersonalDetailParameter.Value = null;
                //}

                    
                    // typ_mHRMSEmployeeNationalityDetailtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSEmployeeNationalityDetailParameter = new SqlParameter("@pi_typ_mHRMSEmployeeNationalityDetail", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSEmployeeNationalityDetail"
                };
                var pRowCollection_typ_mHRMSEmployeeNationalityDetail = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSEmployeeNationalityDetail)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSEmployeeNationalityDetailId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSEmployeeId", SqlDbType.BigInt)
                                                , new SqlMetaData("Nationality", SqlDbType.BigInt)
                                                , new SqlMetaData("AlternateNationality", SqlDbType.BigInt)
                                                , new SqlMetaData("IDNumber", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("IDIssuePlace", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("IDIssueDate", SqlDbType.DateTime)
                                                , new SqlMetaData("IDExpiryDate", SqlDbType.DateTime)
                                                , new SqlMetaData("AlternativeIDNumber", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("AlternativeIDIssuePlace", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("AlternativeIDIssueDate", SqlDbType.DateTime)
                                                , new SqlMetaData("AlternativeIDExpiryDate", SqlDbType.DateTime)
                                                , new SqlMetaData("PassportNumber", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("PassportIssuePlace", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("PassportIssueDate", SqlDbType.DateTime)
                                                , new SqlMetaData("PassportExpiryDate", SqlDbType.DateTime)
                                                , new SqlMetaData("VisaType", SqlDbType.BigInt)
                                                , new SqlMetaData("VisaNumber", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("VisaIssuePlace", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("VisaIssueDate", SqlDbType.DateTime)
                                                , new SqlMetaData("VisaExpiryDate", SqlDbType.DateTime)
                                                , new SqlMetaData("ExpatWorkPermitType", SqlDbType.BigInt)
                                                , new SqlMetaData("ExpatWorkPermitIssuePlace", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("ExpatWorkPermitIssueDate", SqlDbType.DateTime)
                                                , new SqlMetaData("ExpatWorkPermitExpiryDate", SqlDbType.DateTime)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSEmployeeNationalityDetailId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSEmployeeId);
                    pRow.SetInt64(3, item.Nationality);
                    pRow.SetInt64(4, item.AlternateNationality);
                    pRow.SetString(5, item.IDNumber);
                    pRow.SetString(6, item.IDIssuePlace);
                    pRow.SetDateTime(7, item.IDIssueDate);
                    pRow.SetDateTime(8, item.IDExpiryDate);
                    pRow.SetString(9, item.AlternativeIDNumber);
                    pRow.SetString(10, item.AlternativeIDIssuePlace);
                    pRow.SetDateTime(11, item.AlternativeIDIssueDate);
                    pRow.SetDateTime(12, item.AlternativeIDExpiryDate);
                    pRow.SetString(13, item.PassportNumber);
                    pRow.SetString(14, item.PassportIssuePlace);
                    pRow.SetDateTime(15, item.PassportIssueDate);
                    pRow.SetDateTime(16, item.PassportExpiryDate);
                    pRow.SetInt64(17, item.VisaType);
                    pRow.SetString(18, item.VisaNumber);
                    pRow.SetString(19, item.VisaIssuePlace);
                    pRow.SetDateTime(20, item.VisaIssueDate);
                    pRow.SetDateTime(21, item.VisaExpiryDate);
                    pRow.SetInt64(22, item.ExpatWorkPermitType);
                    pRow.SetString(23, item.ExpatWorkPermitIssuePlace);
                    pRow.SetDateTime(24, item.ExpatWorkPermitIssueDate);
                    pRow.SetDateTime(25, item.ExpatWorkPermitExpiryDate);
                    pRow.SetBoolean(26, item.Active);
                    pRow.SetBoolean(27, item.Deleted);
                    pRow.SetInt32(28, (int)item.EntryStatus);

                    pRowCollection_typ_mHRMSEmployeeNationalityDetail.Add(pRow);
                }
                //if (pRowCollection_typ_mHRMSEmployeeNationalityDetail != null && pRowCollection_typ_mHRMSEmployeeNationalityDetail.Count > 0)
                //{
                    ptyp_mHRMSEmployeeNationalityDetailParameter.Value = pRowCollection_typ_mHRMSEmployeeNationalityDetail;
                //}
                //else
                //{
                //    ptyp_mHRMSEmployeeNationalityDetailParameter.Value = null;
                //}
                // typ_mHRMSEmployeeRelativestable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSEmployeeRelativesParameter = new SqlParameter("@pi_typ_mHRMSEmployeeRelatives", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSEmployeeRelatives"
                };
                var pRowCollection_typ_mHRMSEmployeeRelatives = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSEmployeeRelatives)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSEmployeeRelativesId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSEmployeeId", SqlDbType.BigInt)
                                                , new SqlMetaData("RelativeName", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("Relation", SqlDbType.BigInt)
                                                , new SqlMetaData("WorkingInCompany", SqlDbType.Bit)
                                                , new SqlMetaData("RelativeEmployeeId", SqlDbType.BigInt)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSEmployeeRelativesId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSEmployeeId);
                    pRow.SetString(3, item.RelativeName);
                    pRow.SetInt64(4, item.Relation);
                    pRow.SetBoolean(5, item.WorkingInCompany);
                    pRow.SetInt64(6, item.RelativeEmployeeId);
                    pRow.SetBoolean(7, item.Active);
                    pRow.SetBoolean(8, item.Deleted);
                    pRow.SetInt32(9, (int)item.EntryStatus);

                    pRowCollection_typ_mHRMSEmployeeRelatives.Add(pRow);
                }
                //if (pRowCollection_typ_mHRMSEmployeeRelatives != null && pRowCollection_typ_mHRMSEmployeeRelatives.Count > 0)
                //{
                    ptyp_mHRMSEmployeeRelativesParameter.Value = pRowCollection_typ_mHRMSEmployeeRelatives;
                //}
                //else
                //{
                //    ptyp_mHRMSEmployeeRelativesParameter.Value = null;
                //}

                // typ_HRMSEmployeeCTCtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_HRMSEmployeeCTCParameter = new SqlParameter("@pi_typ_HRMSEmployeeCTC", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_HRMSEmployeeCTC"
                };
                var pRowCollection_typ_HRMSEmployeeCTC = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSEmployeeCTC)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("HRMSEmployeeCTCId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSEmployeeId", SqlDbType.BigInt)
                                                , new SqlMetaData("mCompanyId", SqlDbType.BigInt)
                                                , new SqlMetaData("mBranchId", SqlDbType.BigInt)
                                                , new SqlMetaData("mHRMSAllowanceId", SqlDbType.BigInt)
                                                , new SqlMetaData("AllowanceValue", SqlDbType.Decimal, 36, 6)
                                                , new SqlMetaData("EffectiveFrom", SqlDbType.DateTime)
                                                , new SqlMetaData("EffectiveTo", SqlDbType.DateTime)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSEmployeeCTCId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSEmployeeId);
                    pRow.SetInt64(3, item.CompanyId);
                    pRow.SetInt64(4, item.BranchId);
                    pRow.SetInt64(5, item.HRMSAllowanceId);
                    pRow.SetDecimal(6, item.AllowanceValue);
                    pRow.SetDateTime(7, item.EffectiveFrom);
                    pRow.SetDateTime(8, item.EffectiveTo);
                    pRow.SetBoolean(9, item.Active);
                    pRow.SetBoolean(10, item.Deleted);
                    pRow.SetInt32(11, (int)item.EntryStatus);

                    pRowCollection_typ_HRMSEmployeeCTC.Add(pRow);
                }
                //if (pRowCollection_typ_HRMSEmployeeCTC != null && pRowCollection_typ_HRMSEmployeeCTC.Count > 0)
                //{
                    ptyp_HRMSEmployeeCTCParameter.Value = pRowCollection_typ_HRMSEmployeeCTC;
                //}
                //else
                //{
                //    ptyp_HRMSEmployeeCTCParameter.Value = null;
                //}
                string csql = @" EXEC spmHRMSEmployeeInsert
                    @pi_EmployeeCode
                    , @pi_mCompanyId
                    , @pi_mBranchId
                    , @pi_mDepartmentId
                    , @pi_mDesignationId
                    , @pi_ManagerId
                    , @pi_SupervisorId
                    , @pi_SubordinateId
                    , @pi_DOJ
                    , @pi_EmployeeType
                    , @pi_EmployeeTreatedAs
                    , @pi_FingerprintId
                    , @pi_mHRMSCVRepositoryId
                    , @pi_mHRMSCTCId
                    , @pi_mBankAccountDetailId
                    , @pi_EffectiveFrom
                    , @pi_EffectiveTo
                    , @pi_VersionNo
                    , @pi_MyParentId
                    , @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
                    , @pi_typ_mHRMSEmpEducation
                    , @pi_typ_mHRMSEmpExperience
                    , @pi_typ_mHRMSEmpSkill
                    , @pi_typ_mHRMSEmployeeAdditionalSkill
                    , @pi_typ_mHRMSEmployeePersonalDetail
                    , @pi_typ_mHRMSEmployeeNationalityDetail
                    , @pi_typ_mHRMSEmployeeRelatives
                    , @pi_typ_HRMSEmployeeCTC
                ";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                                new SqlParameter("@pi_EmployeeCode", pModel.EmployeeCode) ,
                                new SqlParameter("@pi_mCompanyId", pModel.AuditColumns.CompanyId) ,
                                new SqlParameter("@pi_mBranchId", pModel.BranchId) ,
                                new SqlParameter("@pi_mDepartmentId", pModel.DepartmentId) ,
                                new SqlParameter("@pi_mDesignationId", pModel.DesignationId) ,
                                new SqlParameter("@pi_ManagerId", pModel.ManagerId) ,
                                new SqlParameter("@pi_SupervisorId", pModel.SupervisorId) ,
                                new SqlParameter("@pi_SubordinateId", pModel.SubordinateId) ,
                                new SqlParameter("@pi_DOJ", pModel.DOJ) ,
                                new SqlParameter("@pi_EmployeeType", pModel.EmployeeType) ,
                                new SqlParameter("@pi_EmployeeTreatedAs", pModel.EmployeeTreatedAs) ,
                                new SqlParameter("@pi_FingerprintId", pModel.FingerprintId) ,
                                new SqlParameter("@pi_mHRMSCVRepositoryId", pModel.HRMSCVRepositoryId) ,
                                new SqlParameter("@pi_mHRMSCTCId", pModel.HRMSCTCId) ,
                                new SqlParameter("@pi_mBankAccountDetailId", pModel.BankAccountDetailId) ,
                                new SqlParameter("@pi_EffectiveFrom", pModel.EffectiveFrom) ,
                                new SqlParameter("@pi_EffectiveTo", pModel.EffectiveTo) ,
                                new SqlParameter("@pi_VersionNo", pModel.VersionNo) ,
                                new SqlParameter("@pi_MyParentId", pModel.MyParentId) ,
                                new SqlParameter("@pi_Active", pModel.Active) ,
                                new SqlParameter("@pi_UserId", pModel.AuditColumns.UserId) ,
                                new SqlParameter("@pi_HostName", pModel.AuditColumns.HostName) ,
                                new SqlParameter("@pi_IPAddress", pModel.AuditColumns.IPAddress) ,
                                new SqlParameter("@pi_DeviceType", pModel.AuditColumns.DeviceType) ,
                                new SqlParameter("@pi_MACAddress", pModel.AuditColumns.MACAddress) ,
                ptyp_mHRMSEmpEducationParameter,
                ptyp_mHRMSEmpExperienceParameter,
                ptyp_mHRMSEmpSkillParameter,
                ptyp_mHRMSEmployeeAdditionalSkillParameter,
                ptyp_mHRMSEmployeePersonalDetailParameter,
                ptyp_mHRMSEmployeeNationalityDetailParameter,
                ptyp_mHRMSEmployeeRelativesParameter,
                ptyp_HRMSEmployeeCTCParameter,
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


        public async Task<SQLResult> Edit(HRMSEmployeeEntry pModel)
        {
            SQLResult result = new SQLResult();
            _Context.Database.BeginTransaction();
            try
            {

                //SQLResult lMobileResult = new SQLResult();
                //MobileConcrete mobileConcrete = new MobileConcrete();
                //lMobileResult = await mobileConcrete.Edit(pModel.MobileDetail, _Context, pModel.AuditColumns,true);

                //SQLResult lAddressResult = new SQLResult();
                //AddressConcrete addressConcrete = new AddressConcrete();
                //lAddressResult = await addressConcrete.Edit(pModel.AddressDetail, _Context, pModel.AuditColumns, true);

                //SQLResult lEmailResult = new SQLResult();
                //EmailConcrete emailConcrete = new EmailConcrete();
                //lEmailResult = await emailConcrete.Edit(pModel.EmailDetail, _Context, pModel.AuditColumns, true);

                SQLResult lContactResult = new SQLResult(); //show me/wait is this createor edit/?
                ContactConcrete contactConcrete = new ContactConcrete();
             
                lContactResult = await contactConcrete.Edit(pModel.ContactDetail, _Context, pModel.AuditColumns,pModel.Active); //show me where this goes

                //if (lMobileResult.ErrorNo != 0)
                //{
                //    _Context.Database.RollbackTransaction();
                //    return lMobileResult;
                //}
                //if (lAddressResult.ErrorNo != 0)
                //{
                //    _Context.Database.RollbackTransaction();
                //    return lAddressResult;
                //}
                //if (lEmailResult.ErrorNo != 0)
                //{
                //    _Context.Database.RollbackTransaction();
                //    return lEmailResult;
                ////}
                if (lContactResult.ErrorNo != 0)
                {
                    _Context.Database.RollbackTransaction();
                    return lContactResult;
                }
                // typ_mHRMSEmpEducationtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSEmpEducationParameter = new SqlParameter("@pi_typ_mHRMSEmpEducation", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSEmpEducation"
                };
                var pRowCollection_typ_mHRMSEmpEducation = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSEmpEducation)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSEmpEducationId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSEmployeeId", SqlDbType.BigInt)
                                                , new SqlMetaData("CertDegreeName", SqlDbType.NVarChar, 2000)
                                                , new SqlMetaData("Major", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("UniInstituteName", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("StartMonth", SqlDbType.Int)
                                                , new SqlMetaData("StartYear", SqlDbType.Int)
                                                , new SqlMetaData("CompletionMonth", SqlDbType.Int)
                                                , new SqlMetaData("CompletionYear", SqlDbType.Int)
                                                , new SqlMetaData("Grade", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSEmpEducationId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSEmployeeId);
                    pRow.SetString(3, item.CertDegreeName);
                    pRow.SetString(4, item.Major);
                    pRow.SetString(5, item.UniInstituteName);
                    pRow.SetInt32(6, item.StartMonth);
                    pRow.SetInt32(7, item.StartYear);
                    pRow.SetInt32(8, item.CompletionMonth);
                    pRow.SetInt32(9, item.CompletionYear);
                    pRow.SetString(10, item.Grade);
                    pRow.SetBoolean(11, item.Deleted);
                    pRow.SetInt32(12, (int)item.EntryStatus);

                    pRowCollection_typ_mHRMSEmpEducation.Add(pRow);
                }
                //if (pRowCollection_typ_mHRMSEmpEducation != null && pRowCollection_typ_mHRMSEmpEducation.Count > 0)
                //{
                    ptyp_mHRMSEmpEducationParameter.Value = pRowCollection_typ_mHRMSEmpEducation;
                //}
                //else
                //{
                //    ptyp_mHRMSEmpEducationParameter.Value = null;
                //}

                // typ_mHRMSEmpExperiencetable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSEmpExperienceParameter = new SqlParameter("@pi_typ_mHRMSEmpExperience", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSEmpExperience"
                };
                var pRowCollection_typ_mHRMSEmpExperience = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSEmpExperience)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSEmpExperienceId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSEmployeeId", SqlDbType.BigInt)
                                                , new SqlMetaData("CompanyName", SqlDbType.NVarChar, 200)
                                                , new SqlMetaData("Designation", SqlDbType.NVarChar, 500)
                                                , new SqlMetaData("JoinMonth", SqlDbType.Int)
                                                , new SqlMetaData("JoinYear", SqlDbType.Int)
                                                , new SqlMetaData("LeaveMonth", SqlDbType.Int)
                                                , new SqlMetaData("LeaveYear", SqlDbType.Int)
                                                , new SqlMetaData("MonthlySalary", SqlDbType.Decimal, 36, 6)
                                                , new SqlMetaData("mCountryId", SqlDbType.BigInt)
                                                , new SqlMetaData("mStateId", SqlDbType.BigInt)
                                                , new SqlMetaData("mCityId", SqlDbType.BigInt)
                                                , new SqlMetaData("Description", SqlDbType.NVarChar, 2000)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSEmpExperienceId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSEmployeeId);
                    pRow.SetString(3, item.CompanyName);
                    pRow.SetString(4, item.Designation);
                    pRow.SetInt32(5, item.JoinMonth);
                    pRow.SetInt32(6, item.JoinYear);
                    pRow.SetInt32(7, item.LeaveMonth);
                    pRow.SetInt32(8, item.LeaveYear);
                    pRow.SetDecimal(9, item.MonthlySalary);
                    pRow.SetInt64(10, item.CountryId);
                    pRow.SetInt64(11, item.StateId);
                    pRow.SetInt64(12, item.CityId);
                    pRow.SetString(13, item.Description);
                    pRow.SetBoolean(14, item.Deleted);
                    pRow.SetInt32(15, (int)item.EntryStatus);

                    pRowCollection_typ_mHRMSEmpExperience.Add(pRow);
                }

                if (pRowCollection_typ_mHRMSEmpExperience != null && pRowCollection_typ_mHRMSEmpExperience.Count > 0)
                {
                    ptyp_mHRMSEmpExperienceParameter.Value = pRowCollection_typ_mHRMSEmpExperience;

                }
                else
                {
                    ptyp_mHRMSEmpExperienceParameter.Value = null;
                }


                // typ_mHRMSEmpSkilltable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSEmpSkillParameter = new SqlParameter("@pi_typ_mHRMSEmpSkill", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSEmpSkill"
                };
                var pRowCollection_typ_mHRMSEmpSkill = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSEmpSkill)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSEmpSkillId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSEmployeeId", SqlDbType.BigInt)
                                                , new SqlMetaData("mHRMSSkillSetId", SqlDbType.BigInt)
                                                , new SqlMetaData("SkillLevel", SqlDbType.BigInt)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSEmpSkillId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSEmployeeId);
                    pRow.SetInt64(3, item.HRMSSkillSetId);
                    pRow.SetInt64(4, item.SkillLevel);
                    pRow.SetBoolean(5, item.Active);
                    pRow.SetBoolean(6, item.Deleted);
                    pRow.SetInt32(7, (int)item.EntryStatus);

                    pRowCollection_typ_mHRMSEmpSkill.Add(pRow);
                }
                if (pRowCollection_typ_mHRMSEmpSkill != null && pRowCollection_typ_mHRMSEmpSkill.Count > 0)
                {
                    ptyp_mHRMSEmpSkillParameter.Value = pRowCollection_typ_mHRMSEmpSkill;
                }
                else
                {
                    ptyp_mHRMSEmpSkillParameter.Value = null;
                }
                // typ_mHRMSEmployeeAdditionalSkilltable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSEmployeeAdditionalSkillParameter = new SqlParameter("@pi_typ_mHRMSEmployeeAdditionalSkill", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSEmployeeAdditionalSkill"
                };
                var pRowCollection_typ_mHRMSEmployeeAdditionalSkill = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSEmployeeAdditionalSkill)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSEmployeeAdditionalSkillId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSEmployeeId", SqlDbType.BigInt)
                                                , new SqlMetaData("Skill", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("SkillLevel", SqlDbType.BigInt)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSEmployeeAdditionalSkillId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSEmployeeId);
                    pRow.SetString(3, item.Skill);
                    pRow.SetInt64(4, item.SkillLevel);
                    pRow.SetBoolean(5, item.Active);
                    pRow.SetBoolean(6, item.Deleted);
                    pRow.SetInt32(7, (int)item.EntryStatus);

                    pRowCollection_typ_mHRMSEmployeeAdditionalSkill.Add(pRow);
                }
                if (pRowCollection_typ_mHRMSEmployeeAdditionalSkill != null && pRowCollection_typ_mHRMSEmployeeAdditionalSkill.Count > 0)
                {
                    ptyp_mHRMSEmployeeAdditionalSkillParameter.Value = pRowCollection_typ_mHRMSEmployeeAdditionalSkill;
                }
                else
                {
                    ptyp_mHRMSEmployeeAdditionalSkillParameter.Value = null;
                }

                // typ_mHRMSEmployeePersonalDetailtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSEmployeePersonalDetailParameter = new SqlParameter("@pi_typ_mHRMSEmployeePersonalDetail", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSEmployeePersonalDetail"
                };
                var pRowCollection_typ_mHRMSEmployeePersonalDetail = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSEmployeePersonalDetail)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSEmployeePersonalDetailId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSEmployeeId", SqlDbType.BigInt)
                                                , new SqlMetaData("mCompanyId", SqlDbType.BigInt)
                                                , new SqlMetaData("mBranchId", SqlDbType.BigInt)
                                                , new SqlMetaData("EmployeeName", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("FatherName", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("GrandfatherName", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("FamilyName", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("DOB", SqlDbType.DateTime)
                                                , new SqlMetaData("Gender", SqlDbType.BigInt)
                                                , new SqlMetaData("MaritalStatus", SqlDbType.BigInt)
                                                , new SqlMetaData("NumberOfFamilyMembers", SqlDbType.Int)
                                            
                                                , new SqlMetaData("mContactId", SqlDbType.BigInt)
                                              
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSEmployeePersonalDetailId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSEmployeeId);
                    pRow.SetInt64(3, item.CompanyId);
                    pRow.SetInt64(4, item.BranchId);
                    pRow.SetString(5, item.EmployeeName);
                    pRow.SetString(6, item.FatherName);
                    pRow.SetString(7, item.GrandfatherName);
                    pRow.SetString(8, item.FamilyName);
                    pRow.SetDateTime(9, item.DOB);
                    pRow.SetInt64(10, item.Gender);
                    pRow.SetInt64(11, item.MaritalStatus);
                    pRow.SetInt32(12, item.NumberOfFamilyMembers);
                    pRow.SetInt64(13, item.ContactId);
                    pRow.SetBoolean(14, item.Active);
                    pRow.SetBoolean(15, item.Deleted);
                    pRow.SetInt32(16, (int)item.EntryStatus);

                    pRowCollection_typ_mHRMSEmployeePersonalDetail.Add(pRow);
                }
                //}
                //if (pRowCollection_typ_mHRMSEmployeePersonalDetail != null && pRowCollection_typ_mHRMSEmployeePersonalDetail.Count > 0)
                //{
                ptyp_mHRMSEmployeePersonalDetailParameter.Value = pRowCollection_typ_mHRMSEmployeePersonalDetail;
                //}
                //else
                //{
                //    ptyp_mHRMSEmployeePersonalDetailParameter.Value = null;
                //}


                // typ_mHRMSEmployeeNationalityDetailtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSEmployeeNationalityDetailParameter = new SqlParameter("@pi_typ_mHRMSEmployeeNationalityDetail", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSEmployeeNationalityDetail"
                };
                var pRowCollection_typ_mHRMSEmployeeNationalityDetail = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSEmployeeNationalityDetail)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSEmployeeNationalityDetailId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSEmployeeId", SqlDbType.BigInt)
                                                , new SqlMetaData("Nationality", SqlDbType.BigInt)
                                                , new SqlMetaData("AlternateNationality", SqlDbType.BigInt)
                                                , new SqlMetaData("IDNumber", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("IDIssuePlace", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("IDIssueDate", SqlDbType.DateTime)
                                                , new SqlMetaData("IDExpiryDate", SqlDbType.DateTime)
                                                , new SqlMetaData("AlternativeIDNumber", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("AlternativeIDIssuePlace", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("AlternativeIDIssueDate", SqlDbType.DateTime)
                                                , new SqlMetaData("AlternativeIDExpiryDate", SqlDbType.DateTime)
                                                , new SqlMetaData("PassportNumber", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("PassportIssuePlace", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("PassportIssueDate", SqlDbType.DateTime)
                                                , new SqlMetaData("PassportExpiryDate", SqlDbType.DateTime)
                                                , new SqlMetaData("VisaType", SqlDbType.BigInt)
                                                , new SqlMetaData("VisaNumber", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("VisaIssuePlace", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("VisaIssueDate", SqlDbType.DateTime)
                                                , new SqlMetaData("VisaExpiryDate", SqlDbType.DateTime)
                                                , new SqlMetaData("ExpatWorkPermitType", SqlDbType.BigInt)
                                                , new SqlMetaData("ExpatWorkPermitIssuePlace", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("ExpatWorkPermitIssueDate", SqlDbType.DateTime)
                                                , new SqlMetaData("ExpatWorkPermitExpiryDate", SqlDbType.DateTime)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSEmployeeNationalityDetailId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSEmployeeId);
                    pRow.SetInt64(3, item.Nationality);
                    pRow.SetInt64(4, item.AlternateNationality);
                    pRow.SetString(5, item.IDNumber);
                    pRow.SetString(6, item.IDIssuePlace);
                    pRow.SetDateTime(7, item.IDIssueDate);
                    pRow.SetDateTime(8, item.IDExpiryDate);
                    pRow.SetString(9, item.AlternativeIDNumber);
                    pRow.SetString(10, item.AlternativeIDIssuePlace);
                    pRow.SetDateTime(11, item.AlternativeIDIssueDate);
                    pRow.SetDateTime(12, item.AlternativeIDExpiryDate);
                    pRow.SetString(13, item.PassportNumber);
                    pRow.SetString(14, item.PassportIssuePlace);
                    pRow.SetDateTime(15, item.PassportIssueDate);
                    pRow.SetDateTime(16, item.PassportExpiryDate);
                    pRow.SetInt64(17, item.VisaType);
                    pRow.SetString(18, item.VisaNumber);
                    pRow.SetString(19, item.VisaIssuePlace);
                    pRow.SetDateTime(20, item.VisaIssueDate);
                    pRow.SetDateTime(21, item.VisaExpiryDate);
                    pRow.SetInt64(22, item.ExpatWorkPermitType);
                    pRow.SetString(23, item.ExpatWorkPermitIssuePlace);
                    pRow.SetDateTime(24, item.ExpatWorkPermitIssueDate);
                    pRow.SetDateTime(25, item.ExpatWorkPermitExpiryDate);
                    pRow.SetBoolean(26, item.Active);
                    pRow.SetBoolean(27, item.Deleted);
                    pRow.SetInt32(28, (int)item.EntryStatus);

                    pRowCollection_typ_mHRMSEmployeeNationalityDetail.Add(pRow);
                }
                //if (pRowCollection_typ_mHRMSEmployeeNationalityDetail != null && pRowCollection_typ_mHRMSEmployeeNationalityDetail.Count > 0)
                //{
                    ptyp_mHRMSEmployeeNationalityDetailParameter.Value = pRowCollection_typ_mHRMSEmployeeNationalityDetail;
                //}
                //else
                //{
                //    ptyp_mHRMSEmployeeNationalityDetailParameter.Value = null;
                //}
                // typ_mHRMSEmployeeRelativestable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_mHRMSEmployeeRelativesParameter = new SqlParameter("@pi_typ_mHRMSEmployeeRelatives", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_mHRMSEmployeeRelatives"
                };
                var pRowCollection_typ_mHRMSEmployeeRelatives = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSEmployeeRelatives)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("mHRMSEmployeeRelativesId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSEmployeeId", SqlDbType.BigInt)
                                                , new SqlMetaData("RelativeName", SqlDbType.NVarChar, 255)
                                                , new SqlMetaData("Relation", SqlDbType.BigInt)
                                                , new SqlMetaData("WorkingInCompany", SqlDbType.Bit)
                                                , new SqlMetaData("RelativeEmployeeId", SqlDbType.BigInt)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSEmployeeRelativesId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSEmployeeId);
                    pRow.SetString(3, item.RelativeName);
                    pRow.SetInt64(4, item.Relation);
                    pRow.SetBoolean(5, item.WorkingInCompany);
                    pRow.SetInt64(6, item.RelativeEmployeeId);
                    pRow.SetBoolean(7, item.Active);
                    pRow.SetBoolean(8, item.Deleted);
                    pRow.SetInt32(9, (int)item.EntryStatus);

                    pRowCollection_typ_mHRMSEmployeeRelatives.Add(pRow);
                }
                //if (pRowCollection_typ_mHRMSEmployeeRelatives != null && pRowCollection_typ_mHRMSEmployeeRelatives.Count > 0)
                //{
                    ptyp_mHRMSEmployeeRelativesParameter.Value = pRowCollection_typ_mHRMSEmployeeRelatives;
                //}
                //else
                //{
                //    ptyp_mHRMSEmployeeRelativesParameter.Value = null;
                //}

                // typ_HRMSEmployeeCTCtable type parameter declartaion with parameter name and table type name
                SqlParameter ptyp_HRMSEmployeeCTCParameter = new SqlParameter("@pi_typ_HRMSEmployeeCTC", SqlDbType.Structured)
                {
                    Direction = ParameterDirection.Input,
                    TypeName = "typ_HRMSEmployeeCTC"
                };
                var pRowCollection_typ_HRMSEmployeeCTC = new List<SqlDataRecord>();
                foreach (var item in pModel.HRMSEmployeeCTC)
                {

                    SqlDataRecord pRow = new SqlDataRecord(
                                                new SqlMetaData("HRMSEmployeeCTCId", SqlDbType.BigInt)
                                                , new SqlMetaData("SrNo", SqlDbType.Int)
                                                , new SqlMetaData("mHRMSEmployeeId", SqlDbType.BigInt)
                                                , new SqlMetaData("mCompanyId", SqlDbType.BigInt)
                                                , new SqlMetaData("mBranchId", SqlDbType.BigInt)
                                                , new SqlMetaData("mHRMSAllowanceId", SqlDbType.BigInt)
                                                , new SqlMetaData("AllowanceValue", SqlDbType.Decimal, 36, 6)
                                                , new SqlMetaData("EffectiveFrom", SqlDbType.DateTime)
                                                , new SqlMetaData("EffectiveTo", SqlDbType.DateTime)
                                                , new SqlMetaData("Active", SqlDbType.Bit)
                                                , new SqlMetaData("Deleted", SqlDbType.Bit)
                                                , new SqlMetaData("EntryStatus", SqlDbType.Int)
                                            );

                    pRow.SetInt64(0, item.HRMSEmployeeCTCId);
                    pRow.SetInt32(1, item.SrNo);
                    pRow.SetInt64(2, item.HRMSEmployeeId);
                    pRow.SetInt64(3, item.CompanyId);
                    pRow.SetInt64(4, item.BranchId);
                    pRow.SetInt64(5, item.HRMSAllowanceId);
                    pRow.SetDecimal(6, item.AllowanceValue);
                    pRow.SetDateTime(7, item.EffectiveFrom);
                    pRow.SetDateTime(8, item.EffectiveTo);
                    pRow.SetBoolean(9, item.Active);
                    pRow.SetBoolean(10, item.Deleted);
                    pRow.SetInt32(11, (int)item.EntryStatus);

                    pRowCollection_typ_HRMSEmployeeCTC.Add(pRow);
                }
                //if (pRowCollection_typ_HRMSEmployeeCTC != null && pRowCollection_typ_HRMSEmployeeCTC.Count > 0)
                //{
                    ptyp_HRMSEmployeeCTCParameter.Value = pRowCollection_typ_HRMSEmployeeCTC;
                //}
                //else
                //{
                //    ptyp_HRMSEmployeeCTCParameter.Value = null;
                //}


                string csql = @" EXEC spmHRMSEmployeeUpdate
                    @pi_mHRMSEmployeeId
                    , @pi_EmployeeCode
                    , @pi_mCompanyId
                    , @pi_mBranchId
                    , @pi_mDepartmentId
                    , @pi_mDesignationId
                    , @pi_ManagerId
                    , @pi_SupervisorId
                    , @pi_SubordinateId
                    , @pi_DOJ
                    , @pi_EmployeeType
                    , @pi_EmployeeTreatedAs
                    , @pi_FingerprintId
                    , @pi_mHRMSCVRepositoryId
                    , @pi_mHRMSCTCId
                    , @pi_mBankAccountDetailId
                    , @pi_EffectiveFrom
                    , @pi_EffectiveTo
                    , @pi_VersionNo
                    , @pi_MyParentId
                    , @pi_Active
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress
                    , @pi_typ_mHRMSEmpEducation
                    , @pi_typ_mHRMSEmpExperience
                    , @pi_typ_mHRMSEmpSkill
                    , @pi_typ_mHRMSEmployeeAdditionalSkill
                    , @pi_typ_mHRMSEmployeePersonalDetail
                    , @pi_typ_mHRMSEmployeeNationalityDetail
                    , @pi_typ_mHRMSEmployeeRelatives
                    , @pi_typ_HRMSEmployeeCTC
                ";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                                new SqlParameter("@pi_mHRMSEmployeeId", pModel.HRMSEmployeeId) ,
                                new SqlParameter("@pi_EmployeeCode", pModel.EmployeeCode) ,
                                new SqlParameter("@pi_mCompanyId", pModel.AuditColumns.CompanyId) ,
                                new SqlParameter("@pi_mBranchId", pModel.BranchId) ,
                                new SqlParameter("@pi_mDepartmentId", pModel.DepartmentId) ,
                                new SqlParameter("@pi_mDesignationId", pModel.DesignationId) ,
                                new SqlParameter("@pi_ManagerId", pModel.ManagerId) ,
                                new SqlParameter("@pi_SupervisorId", pModel.SupervisorId) ,
                                new SqlParameter("@pi_SubordinateId", pModel.SubordinateId) ,
                                new SqlParameter("@pi_DOJ", pModel.DOJ) ,
                                new SqlParameter("@pi_EmployeeType", pModel.EmployeeType) ,
                                new SqlParameter("@pi_EmployeeTreatedAs", pModel.EmployeeTreatedAs) ,
                                new SqlParameter("@pi_FingerprintId", pModel.FingerprintId) ,
                                new SqlParameter("@pi_mHRMSCVRepositoryId", pModel.HRMSCVRepositoryId) ,
                                new SqlParameter("@pi_mHRMSCTCId", pModel.HRMSCTCId) ,
                                new SqlParameter("@pi_mBankAccountDetailId", pModel.BankAccountDetailId) ,
                                new SqlParameter("@pi_EffectiveFrom", pModel.EffectiveFrom) ,
                                new SqlParameter("@pi_EffectiveTo", pModel.EffectiveTo) ,
                                new SqlParameter("@pi_VersionNo", pModel.VersionNo) ,
                                new SqlParameter("@pi_MyParentId", pModel.MyParentId) ,
                                new SqlParameter("@pi_Active", pModel.Active) ,
                                new SqlParameter("@pi_UserId", pModel.AuditColumns.UserId) ,
                                new SqlParameter("@pi_HostName", pModel.AuditColumns.HostName) ,
                                new SqlParameter("@pi_IPAddress", pModel.AuditColumns.IPAddress) ,
                                new SqlParameter("@pi_DeviceType", pModel.AuditColumns.DeviceType) ,
                                new SqlParameter("@pi_MACAddress", pModel.AuditColumns.MACAddress) ,
                ptyp_mHRMSEmpEducationParameter,
                ptyp_mHRMSEmpExperienceParameter,
                ptyp_mHRMSEmpSkillParameter,
                ptyp_mHRMSEmployeeAdditionalSkillParameter,
                ptyp_mHRMSEmployeePersonalDetailParameter,
                ptyp_mHRMSEmployeeNationalityDetailParameter,
                ptyp_mHRMSEmployeeRelativesParameter,
                ptyp_HRMSEmployeeCTCParameter,
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