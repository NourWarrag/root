using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.Library;
using ConcreteCore.HRMS.Admin.Recruitment;
using InterfaceCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelCore.HRMS.Admin.Recruitment;
using ModelCore.Misc;
using static ModelCore.Misc.Enums;

namespace APICore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HRMSEmployeeController : ControllerBase
    {
        private readonly IHRMSEmployee _repo;
       
        public HRMSEmployeeController(IHRMSEmployee repo)
        {
            _repo = repo;
      
        }

        /*********************************************************************/
        /*        //example: http://localhost:5000/api/HRMSEmployee/40        */
        /**********************************************************************/

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Int64 id)
        {
            HRMSEmployeeEntry result = await _repo.GetEntry(id);
            return Ok(result);
        }

        

        [HttpPost("getpagedata/{pScreenId}/{pUserId}/{pRecordsPerPage}/{pPageNo}/{pTableId}/{pLastPage}")]
        public async Task<IActionResult> GetPageData(Int64 pScreenId, Int64 pUserId, Int64 pRecordsPerPage,
           Int64 pPageNo, Int64 pTableId, Boolean pLastPage)
        {
            SQLResult resultValidation = new SQLResult();
            resultValidation = Functions.ValidateGetPageData(pScreenId, pUserId, pRecordsPerPage, pPageNo, pTableId, pLastPage);
            if (resultValidation.ErrorNo > 0)
            {
                return BadRequest(resultValidation.ErrorMessage);
            }
            try
            {
                List<HRMSEmployeeIndex> result = new List<HRMSEmployeeIndex>();

                result = await _repo.GetIndex(pScreenId, pUserId, pRecordsPerPage, pPageNo, pTableId, pLastPage);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }


        private bool Validate(HRMSEmployeeEntry pModel, bool isUpdateValidation)
        {
            if (isUpdateValidation == true)
            {
                if (pModel.HRMSEmployeeId <= 0)
                {
                    ModelState.AddModelError("", Messages.Blank("mHRMSEmployee entry"));
                    return false;
                }
            }
            if (pModel.EmployeeCode.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("EmployeeCode"));
                return false;
            }
            if (pModel.CompanyId <= 1)
            {
                ModelState.AddModelError("", Messages.Blank("mCompanyId"));
                return false;
            }
            if (pModel.BranchId <= 1)
            {
                ModelState.AddModelError("", Messages.Blank("mBranchId"));
                return false;
            }
            if (pModel.DepartmentId <= 1)
            {
                ModelState.AddModelError("", Messages.Blank("mDepartmentId"));
                return false;
            }
            if (pModel.DesignationId <= 1)
            {
                ModelState.AddModelError("", Messages.Blank("mDesignationId"));
                return false;
            }
            if (pModel.DOJ == null)
            {
                ModelState.AddModelError("", Messages.Blank("DOJ"));
                return false;
            }
            if (pModel.EmployeeType <= 0)
            {
                ModelState.AddModelError("", Messages.Blank("EmployeeType"));
                return false;
            }
            if (pModel.EmployeeTreatedAs <= 0)
            {
                ModelState.AddModelError("", Messages.Blank("EmployeeTreatedAs"));
                return false;
            }
            if (pModel.EffectiveFrom == null)
            {
                ModelState.AddModelError("", Messages.Blank("EffectiveFrom"));
                return false;
            }
            if (pModel.EffectiveTo == null)
            {
                ModelState.AddModelError("", Messages.Blank("EffectiveTo"));
                return false;
            }
            foreach (HRMSEmpExperience item in pModel.HRMSEmpExperience)
            {
                if (item.Deleted == false)
                {
                    if (isUpdateValidation == true && (int)item.EntryStatus == 1)
                    {
                        if (item.HRMSEmpExperienceId <= 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("Cost center ledger entry"));
                            return false;
                        }
                        if (item.HRMSEmployeeId <= 1)
                        {
                            ModelState.AddModelError("", Messages.Blank("Cost center entry"));
                            return false;
                        }
                    }
                    
                    if (item.SrNo <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("SrNo"));
                        return false;
                    }
                    //if (item.HRMSEmployeeId <= 1)
                    //{
                    //    ModelState.AddModelError("", Messages.Blank("mHRMSEmployeeId"));
                    //    return false;
                    //}
                    if (item.CompanyName.Trim().Length == 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("CompanyName"));
                        return false;
                    }
                    if (item.Designation.Trim().Length == 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("Designation"));
                        return false;
                    }
                    if (item.JoinMonth <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("JoinMonth"));
                        return false;
                    }
                    if (item.JoinYear <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("JoinYear"));
                        return false;
                    }
                    if (item.LeaveMonth <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("LeaveMonth"));
                        return false;
                    }
                    if (item.LeaveYear <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("LeaveYear"));
                        return false;
                    }
                    if (item.MonthlySalary <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("MonthlySalary"));
                        return false;
                    }
                    if (item.CountryId <= 1)
                    {
                        ModelState.AddModelError("", Messages.Blank("mCountryId"));
                        return false;
                    }
                    if (item.StateId <= 1)
                    {
                        ModelState.AddModelError("", Messages.Blank("mStateId"));
                        return false;
                    }
                    if (item.CityId <= 1)
                    {
                        ModelState.AddModelError("", Messages.Blank("mCityId"));
                        return false;
                    }
                    if (item.Description.Trim().Length == 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("Description"));
                        return false;
                    }
                    if (item.EntryStatus < 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("EntryStatus"));
                        return false;
                    }
                }

            }

            foreach (HRMSEmpEducation item in pModel.HRMSEmpEducation)
            {
                if (item.Deleted == false)
                {
                    if (isUpdateValidation == true && (int)item.EntryStatus == 1)
                    {
                        if (item.HRMSEmpEducationId <= 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("Cost center ledger entry"));
                            return false;
                        }
                        if (item.HRMSEmployeeId <= 1)
                        {
                            ModelState.AddModelError("", Messages.Blank("Cost center entry"));
                            return false;
                        }
                    }

                    if (item.SrNo <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("SrNo"));
                        return false;
                    }
                    //if (pModel.HRMSEmpEducation.mHRMSEmployeeId <= 1)
                    //{
                    //    ModelState.AddModelError("", Messages.Blank("mHRMSEmployeeId"));
                    //    return false;

                    //}
                    if (item.CertDegreeName.Trim().Length == 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("CertDegreeName"));
                        return false;
                    }
                    if (item.Major.Trim().Length == 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("Major"));
                        return false;
                    }
                    if (item.UniInstituteName.Trim().Length == 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("UniInstituteName"));
                        return false;
                    }
                    if (item.StartMonth <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("StartMonth"));
                        return false;
                    }
                    if (item.StartYear <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("StartYear"));
                        return false;
                    }
                    if (item.CompletionMonth <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("CompletionMonth"));
                        return false;
                    }
                    if (item.CompletionYear <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("CompletionYear"));
                        return false;
                    }
                    if (item.Grade.Trim().Length == 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("Grade"));
                        return false;
                    }
                    if (item.EntryStatus <0)
                    {
                        ModelState.AddModelError("", Messages.Blank("EntryStatus"));
                        return false;
                    }

                }
            }

            foreach (HRMSEmpSkill item in pModel.HRMSEmpSkill)
            {
                if (item.Deleted == false)
                {
                    if (isUpdateValidation == true && (int)item.EntryStatus == 1)
                    {
                        if (item.HRMSEmpSkillId <= 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("skill ID!"));
                            return false;
                        }
                        if (item.HRMSEmployeeId <= 1)
                        {
                            ModelState.AddModelError("", Messages.Blank("Employee ID"));
                            return false;
                        }
                    }
                    if (item.SrNo <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("SrNo"));
                        return false;
                    }
                    //if (item.HRMSEmpSkillId <= 1)
                    //{
                    //    ModelState.AddModelError("", Messages.Blank("mHRMSEmpSkillId"));
                    //    return false;
                    //}
                    //if (item.HRMSEmployeeId <= 1)
                    //{
                    //    ModelState.AddModelError("", Messages.Blank("mHRMSEmployeeId"));
                    //    return false;
                    //}
                    if (item.HRMSSkillSetId < 1) //return <=1 later
                    {
                        ModelState.AddModelError("", Messages.Blank("mHRMSSkillSetId"));
                        return false;
                    }
                    if (item.SkillLevel <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("SkillLevel"));
                        return false;
                    }
                    if (item.EntryStatus < 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("EntryStatus"));
                        return false;
                    }
                }
            }

            foreach (HRMSEmployeeAdditionalSkill item in pModel.HRMSEmployeeAdditionalSkill)
            {

                if (item.Deleted == false)
                {
                    if (isUpdateValidation == true && (int)item.EntryStatus == 1)
                    {

                        if (item.HRMSEmployeeAdditionalSkillId <= 1)
                        {
                            ModelState.AddModelError("", Messages.Blank("mHRMSEmployeeAdditionalSkillId"));
                            return false;
                        }
                        if (item.HRMSEmployeeId <= 1)
                        {
                            ModelState.AddModelError("", Messages.Blank("mHRMSEmployeeId"));
                            return false;
                        }
                    }
                    if (item.SrNo <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("SrNo"));
                        return false;
                    }

                    if (item.Skill.Trim().Length == 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("Skill"));
                        return false;
                    }
                    if (item.SkillLevel <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("SkillLevel"));
                        return false;
                    }
                    if (item.EntryStatus <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("EntryStatus"));
                        return false;
                    }
                }
            }

            foreach (HRMSEmployeeNationalityDetail item in pModel.HRMSEmployeeNationalityDetail)
            {
                if (item.Deleted == false)
                {
                    if (isUpdateValidation == true && (int)item.EntryStatus == 1)
                    {
                        if (item.HRMSEmployeeNationalityDetailId <= 1)
                        {
                            ModelState.AddModelError("", Messages.Blank("mHRMSEmployeeNationalityDetailId"));
                            return false;
                        }
                        if (item.HRMSEmployeeId <= 1)
                        {
                            ModelState.AddModelError("", Messages.Blank("mHRMSEmployeeId"));
                            return false;
                        }
                    }
                        if (item.SrNo <= 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("SrNo"));
                            return false;
                        }
                       
                        if (item.Nationality <= 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("Nationality"));
                            return false;
                        }
                        if (item.AlternateNationality <= 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("AlternateNationality"));
                            return false;
                        }
                        if (item.IDNumber.Trim().Length == 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("IDNumber"));
                            return false;
                        }
                        if (item.IDIssuePlace.Trim().Length == 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("IDIssuePlace"));
                            return false;
                        }
                        if (item.IDIssueDate == null)
                        {
                            ModelState.AddModelError("", Messages.Blank("IDIssueDate"));
                            return false;
                        }
                        if (item.IDExpiryDate == null)
                        {
                            ModelState.AddModelError("", Messages.Blank("IDExpiryDate"));
                            return false;
                        }
                        if (item.AlternativeIDNumber.Trim().Length == 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("AlternativeIDNumber"));
                            return false;
                        }
                        if (item.AlternativeIDIssuePlace.Trim().Length == 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("AlternativeIDIssuePlace"));
                            return false;
                        }
                        if (item.AlternativeIDIssueDate == null)
                        {
                            ModelState.AddModelError("", Messages.Blank("AlternativeIDIssueDate"));
                            return false;
                        }
                        if (item.AlternativeIDExpiryDate == null)
                        {
                            ModelState.AddModelError("", Messages.Blank("AlternativeIDExpiryDate"));
                            return false;
                        }
                        if (item.PassportNumber.Trim().Length == 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("PassportNumber"));
                            return false;
                        }
                        if (item.PassportIssuePlace.Trim().Length == 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("PassportIssuePlace"));
                            return false;
                        }
                        if (item.PassportIssueDate == null)
                        {
                            ModelState.AddModelError("", Messages.Blank("PassportIssueDate"));
                            return false;
                        }
                        if (item.PassportExpiryDate == null)
                        {
                            ModelState.AddModelError("", Messages.Blank("PassportExpiryDate"));
                            return false;
                        }
                        if (item.VisaType <= 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("VisaType"));
                            return false;
                        }
                        if (item.VisaNumber.Trim().Length == 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("VisaNumber"));
                            return false;
                        }
                        if (item.VisaIssuePlace.Trim().Length == 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("VisaIssuePlace"));
                            return false;
                        }
                        if (item.VisaIssueDate == null)
                        {
                            ModelState.AddModelError("", Messages.Blank("VisaIssueDate"));
                            return false;
                        }
                        if (item.VisaExpiryDate == null)
                        {
                            ModelState.AddModelError("", Messages.Blank("VisaExpiryDate"));
                            return false;
                        }
                        if (item.ExpatWorkPermitType <= 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("ExpatWorkPermitType"));
                            return false;
                        }
                        if (item.ExpatWorkPermitIssuePlace.Trim().Length == 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("ExpatWorkPermitIssuePlace"));
                            return false;
                        }
                        if (item.ExpatWorkPermitIssueDate == null)
                        {
                            ModelState.AddModelError("", Messages.Blank("ExpatWorkPermitIssueDate"));
                            return false;
                        }
                        if (item.ExpatWorkPermitExpiryDate == null)
                        {
                            ModelState.AddModelError("", Messages.Blank("ExpatWorkPermitExpiryDate"));
                            return false;
                        }
                        if (item.EntryStatus <= 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("EntryStatus"));
                            return false;
                        }
                    }
                
            }

            foreach (HRMSEmployeePersonalDetail item in pModel.HRMSEmployeePersonalDetail)
            {
                if (item.Deleted == false)
                {
                    if (isUpdateValidation == true && (int)item.EntryStatus == 1)
                    {
                        if (item.HRMSEmployeePersonalDetailId <= 1)
                        {
                            ModelState.AddModelError("", Messages.Blank("mHRMSEmployeePersonalDetailId"));
                            return false;
                        }
                        if (item.HRMSEmployeeId <= 1)
                        {
                            ModelState.AddModelError("", Messages.Blank("mHRMSEmployeeId"));
                            return false;
                        }
                    }
                if (item.SrNo <= 0)
                {
                    ModelState.AddModelError("", Messages.Blank("SrNo"));
                    return false;
                }
                if (item.HRMSEmployeeId <= 1)
                {
                    ModelState.AddModelError("", Messages.Blank("mHRMSEmployeeId"));
                    return false;
                }
                if (item.CompanyId <= 1)
                {
                    ModelState.AddModelError("", Messages.Blank("mCompanyId"));
                    return false;
                }
                if (item.BranchId <= 1)
                {
                    ModelState.AddModelError("", Messages.Blank("mBranchId"));
                    return false;
                }
                if (item.EmployeeName.Trim().Length == 0)
                {
                    ModelState.AddModelError("", Messages.Blank("EmployeeName"));
                    return false;
                }
                if (item.FatherName.Trim().Length == 0)
                {
                    ModelState.AddModelError("", Messages.Blank("FatherName"));
                    return false;
                }
                if (item.GrandfatherName.Trim().Length == 0)
                {
                    ModelState.AddModelError("", Messages.Blank("GrandfatherName"));
                    return false;
                }
                if (item.FamilyName.Trim().Length == 0)
                {
                    ModelState.AddModelError("", Messages.Blank("FamilyName"));
                    return false;
                }
                if (item.DOB == null)
                {
                    ModelState.AddModelError("", Messages.Blank("DOB"));
                    return false;
                }
                if (item.Gender <= 0)
                {
                    ModelState.AddModelError("", Messages.Blank("Gender"));
                    return false;
                }
                if (item.MaritalStatus <= 0)
                {
                    ModelState.AddModelError("", Messages.Blank("MaritalStatus"));
                    return false;
                }
                if (item.NumberOfFamilyMembers <= 0)
                {
                    ModelState.AddModelError("", Messages.Blank("NumberOfFamilyMembers"));
                    return false;
                }
                if (item.ContactId <= 1)
                {
                    ModelState.AddModelError("", Messages.Blank("mContactId"));
                    return false;
                }
                if (item.EntryStatus <= 0)
                {
                    ModelState.AddModelError("", Messages.Blank("EntryStatus"));
                    return false;
                }
            }
            }

            foreach (HRMSEmployeeRelatives item in pModel.HRMSEmployeeRelatives)
            {
                if (item.Deleted == false)
                {
                    if (isUpdateValidation == true && (int)item.EntryStatus == 1)
                    {
                        if (item.HRMSEmployeeRelativesId <= 1)
                        {
                            ModelState.AddModelError("", Messages.Blank("mHRMSEmployeeRelativesId"));
                            return false;
                        }
                        if (item.HRMSEmployeeId <= 1)
                        {
                            ModelState.AddModelError("", Messages.Blank("mHRMSEmployeeId"));
                            return false;
                        }
                    }
                    if (item.SrNo <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("SrNo"));
                        return false;
                    }

                    if (item.RelativeName.Trim().Length == 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("RelativeName"));
                        return false;
                    }
                    if (item.RelationId <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("RelationId"));
                        return false;
                    }
                    if (item.EntryStatus <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("EntryStatus"));
                        return false;
                    }
                }
            }
            return true;
        }


        /*********************************************************************/
        /*        //Json example for Create:
         *            {
                	"auditColumns": 
                			{
                			"userId":1,
                			"hostname":"test",
                			"ipaddress":"test",
                			"devicetype":"test",
                			"macaddress":"test",
                			"companyId":10001
                			},
      "hrmsEmployeeId": 0,
    "employeeCode": "8787",
    "companyId": 10001,
    "branchId": 201,
    "departmentId": 201,
    "designationId": 2,
    "managerId": 2,
    "supervisorId": 2,
    "subordinateId": 2,
    "doj": "2017-01-01T00:00:00",
    "employeeType": 1,
    "employeeTreatedAs": 1,
    "fingerprintId": 1,
    "hrmscvRepositoryId": 2,
    "hrmsctcId": 2,
    "bankAccountDetailId": 2,
    "effectiveFrom": "2017-01-01T00:00:00",
    "effectiveTo": "2017-01-01T00:00:00",
    "versionNo": 1,
    "myParentId": 1,
    "active": true,
    "contactDetail": [
        {
            "contactDetailId": 0,
            "contactId": 2,
            "srNo": 1,
            "hrmsEmployeeId": 0,
            "contactTypeId": 1,
            "titleId": 1,
            "contactName": "1",
            "designation": "1",
            "addressId": 0,
            "phoneId": 0,
            "mobileId": 0,
            "emailId": 0,
            "default": true,
            "addressDetail": [
                {
                    "addressDetailId": 0,
                    "addressId": 0,
                    "mobileId": 0,
                    "srNo": 1,
                    "hrmsEmployeeId": 0,
                    "contactDetailId": 0,
                    "addressTypeId": 1,
                    "address": "1sqd",
                    "countryId": 12001,
                    "stateId": 120001,
                    "cityId": 1200001,
                    "pinCode": "1",
                    "defaultFlag": true,
                    "deleted": false,
                    "active": true,
                    "entryStatus": 0
                }
            ],
            "mobileDetail": [
                {
                    "mobileDetailId": 0,
                    "mobileId": 0,
                    "srNo": 1,
                    "hrmsEmployeeId": 0,
                    "contactDetailId": 0,
                    "mobileTypeId": 50100002,
                    "countryCode": 10001,
                    "mobileNo": 1234565,
                    "defaultFlag": true,
                    "active": true,
                    "deleted": false,
                    "entryStatus": 0
                }
            ],
            "emailDetail": [
                {
                    "emailDetailId": 0,
                    "emailId": 0,
                    "srNo": 1,
                    "hrmsEmployeeId": 0,
                    "contactDetailId": 0,
                    "emailTypeId": 1,
                    "email": "132edfw",
                    "default": true,
                    "deleted": false,
                    "active": true,
                    "entryStatus": 0
                }
            ],
            "phoneDetail": [
                {
                    "phoneDetailId": 0,
                    "hrmsEmployeeId": 0,
                    "contactDetailId": 0,
                    "phoneId": 0,
                    "srNo": 1,
                    "phoneTypeId": 1,
                    "phonePrefixCode": 1,
                    "phoneNo": 1,
                    "extension": 1,
                    "default": true,
                    "active": true,
                    "deleted": false,
                    "entryStatus": 0
                }
            ],
            "deleted": false,
            "active": true,
            "entryStatus": 0
        }
    ],
    "hrmsEmpEducation": [
        {
            "hrmsEmpEducationId": 0,
            "srNo": 5,
            "hrmsEmployeeId": 0,
            "certDegreeName": "a",
            "major": "a",
            "uniInstituteName": "a",
            "startMonth": 1,
            "startYear": 1,
            "completionMonth": 1,
            "completionYear": 1,
            "grade": "1",
            "deleted": false,
            "entryStatus": 0
        }
    ],
    "hrmsEmpExperience": [
        {
            "hrmsEmpExperienceId": 0,
            "srNo": 4,
            "hrmsEmployeeId": 0,
            "companyName": "j",
            "designation": "j",
            "joinMonth": 2,
            "joinYear": 2,
            "leaveMonth": 2,
            "leaveYear": 2,
            "monthlySalary": 12,
            "countryId": 12001,
            "stateId": 120001,
            "cityId": 1200001,
            "description": "12",
            "deleted": false,
            "entryStatus": 0
        }
    ],
    "hrmsEmpSkill": [
        {
            "hrmsEmpSkillId": 0,
            "srNo": 5,
            "hrmsEmployeeId": 0,
            "hrmsSkillSetId": 2,
            "skillLevel": 1,
            "active": true,
            "deleted": false,
            "entryStatus": 0
        }
    ],
    "hrmsEmployeePersonalDetail": [
        {
            "hrmsEmployeePersonalDetailId": 0,
            "srNo": 3,
            "hrmsEmployeeId": 0,
            "companyId": 10001,
            "branchId": 201,
            "employeeName": "Mohammed",
            "fatherName": "d",
            "grandfatherName": "da",
            "familyName": "ad",
            "dob": "1999-01-01T00:00:00",
            "gender": 1,
            "maritalStatus": 1,
            "numberOfFamilyMembers": 1,
            "contactId": 2,
            "active": true,
            "deleted": false,
            "entryStatus": 0
        }
    ],
    "hrmsEmployeeRelatives": [
        {
            "hrmsEmployeeRelativesId": 0,
            "srNo": 3,
            "hrmsEmployeeId": 0,
            "relativeName": "3",
            "relation": "1",
            "workingInCompany": true,
            "relativeEmployeeId": 12,
            "active": true,
            "deleted": false,
            "entryStatus": 0
        }
    ],
    "hrmsEmployeeCTC": [
        {
            "hrmsEmployeeCTCId": 0,
            "srNo": 2,
            "hrmsEmployeeId": 0,
            "companyId": 10001,
            "branchId": 201,
            "hrmsAllowanceId": 115,
            "allowanceValue": 1,
            "effectiveFrom": "1999-01-01T00:00:00",
            "effectiveTo": "1999-01-01T00:00:00",
            "active": true,
            "deleted": false,
            "entryStatus": 0
        }
    ],
    "hrmsEmployeeNationalityDetail": [
        {
            "hrmsEmployeeNationalityDetailId": 0,
            "srNo": 2,
            "hrmsEmployeeId": 0,
            "nationality": 1,
            "alternateNationality": 1,
            "idNumber": "1",
            "idIssuePlace": "1",
            "idIssueDate": "1999-01-01T00:00:00",
            "idExpiryDate": "1999-01-01T00:00:00",
            "alternativeIDNumber": "1",
            "alternativeIDIssuePlace": "1",
            "alternativeIDIssueDate": "1999-01-01T00:00:00",
            "alternativeIDExpiryDate": "1999-01-01T00:00:00",
            "passportNumber": "1",
            "passportIssuePlace": "1",
            "passportIssueDate": "1999-01-01T00:00:00",
            "passportExpiryDate": "1999-01-01T00:00:00",
            "visaType": 1,
            "visaNumber": "1",
            "visaIssuePlace": "1",
            "visaIssueDate": "1999-01-01T00:00:00",
            "visaExpiryDate": "1999-01-01T00:00:00",
            "expatWorkPermitType": 1,
            "expatWorkPermitIssuePlace": "1",
            "expatWorkPermitIssueDate": "1999-01-01T00:00:00",
            "expatWorkPermitExpiryDate": "1999-01-01T00:00:00",
            "active": true,
            "deleted": false,
            "entryStatus": 0
        }
    ],
    "hrmsEmployeeAdditionalSkill": []
}*/
        /**********************************************************************/

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]HRMSEmployeeEntry pModel)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Validate(pModel, false) == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                // Execution of concrete process
                SQLResult result = new SQLResult();
                result = await _repo.Create(pModel);
                if (result.ErrorNo > 0)
                {
                    return BadRequest(result);
                }
                else
                {
                    return Ok(result);
                }
            }
        }

        /*********************************************************************/
        /*        //Json example for Edit:    {
                	"auditColumns": 
                			{
                			"userId":1,
                			"hostname":"test",
                			"ipaddress":"test",
                			"devicetype":"test",
                			"macaddress":"test",
                			"companyId":10001
                			},
    "hrmsEmployeeId": 46,
    "employeeCode": "8787",
    "companyId": 10001,
    "branchId": 201,
    "departmentId": 201,
    "designationId": 2,
    "managerId": 2,
    "supervisorId": 2,
    "subordinateId": 2,
    "doj": "2017-01-01T00:00:00",
    "employeeType": 1,
    "employeeTreatedAs": 1,
    "fingerprintId": 1,
    "hrmscvRepositoryId": 2,
    "hrmsctcId": 2,
    "bankAccountDetailId": 2,
    "effectiveFrom": "2017-01-01T00:00:00",
    "effectiveTo": "2017-01-01T00:00:00",
    "versionNo": 1,
    "myParentId": 1,
    "active": true,
    "contactDetail": [
        {
            "contactDetailId": 17,
            "contactId": 616,
            "srNo": 1,
            "hrmsEmployeeId": 46,
            "contactTypeId": 50100002,
            "titleId": 50000600001,
            "contactName": "1",
            "designation": "1",
            "addressId": 20031,
            "phoneId": 425,
            "mobileId": 742,
            "emailId": 523,
            "default": true,
            "addressDetail": [
                {
                    "addressDetailId": 30,
                    "addressId": 20031,
                    "srNo": 1,
                    "hrmsEmployeeId": 46,
                    "contactDetailId": 17,
                    "addressTypeId": 50100002,
                    "address": "1sqd",
                    "countryId": 12001,
                    "stateId": 120001,
                    "cityId": 1200001,
                    "pinCode": "1",
                    "defaultFlag": true,
                    "deleted": false,
                    "active": true,
                    "entryStatus": 1
                }
            ],
            "mobileDetail": [
                {
                    "mobileDetailId": 44,
                    "mobileId": 742,
                    "srNo": 1,
                    "hrmsEmployeeId": 46,
                    "contactDetailId": 17,
                    "mobileTypeId": 50100002,
                    "countryCode": 10001,
                    "mobileNo": 1234565,
                    "defaultFlag": true,
                    "active": true,
                    "deleted": false,
                    "entryStatus": 1
                }
            ],
            "emailDetail": [
                {
                    "emailDetailId": 24,
                    "emailId": 523,
                    "srNo": 1,
                    "hrmsEmployeeId": 46,
                    "contactDetailId": 17,
                    "emailTypeId": 50100002,
                    "email": "132edfw",
                    "default": true,
                    "deleted": false,
                    "active": true,
                    "entryStatus": 1
                }
            ],
            "phoneDetail": [
                {
                    "phoneDetailId": 24,
                    "hrmsEmployeeId": 46,
                    "contactDetailId": 17,
                    "phoneId": 425,
                    "srNo": 1,
                    "phoneTypeId": 50100002,
                    "phonePrefixCode": 1,
                    "phoneNo": 1,
                    "extension": 1,
                    "default": true,
                    "active": true,
                    "deleted": false,
                    "entryStatus": 1
                }
            ],
            "deleted": false,
            "active": true,
            "entryStatus": 1
        }
    ],
    "hrmsEmpEducation": [
        {
            "hrmsEmpEducationId": 26,
            "srNo": 5,
            "hrmsEmployeeId": 46,
            "certDegreeName": "a",
            "major": "a",
            "uniInstituteName": "a",
            "startMonth": 1,
            "startYear": 1,
            "completionMonth": 1,
            "completionYear": 1,
            "grade": "1",
            "deleted": false,
            "entryStatus": 1
        }
    ],
    "hrmsEmpExperience": [
        {
            "hrmsEmpExperienceId": 26,
            "srNo": 4,
            "hrmsEmployeeId": 46,
            "companyName": "j",
            "designation": "j",
            "joinMonth": 2,
            "joinYear": 2,
            "leaveMonth": 2,
            "leaveYear": 2,
            "monthlySalary": 12,
            "countryId": 12001,
            "stateId": 120001,
            "cityId": 1200001,
            "description": "12",
            "deleted": false,
            "entryStatus": 1
        }
    ],
    "hrmsEmpSkill": [
        {
            "hrmsEmpSkillId": 31,
            "srNo": 5,
            "hrmsEmployeeId": 46,
            "hrmsSkillSetId": 2,
            "skillLevel": 1,
            "active": true,
            "deleted": false,
            "entryStatus": 1
        }
    ],
    "hrmsEmployeePersonalDetail": [
        {
            "hrmsEmployeePersonalDetailId": 33,
            "srNo": 3,
            "hrmsEmployeeId": 46,
            "companyId": 10001,
            "branchId": 201,
            "employeeName": "Mohammed",
            "fatherName": "d",
            "grandfatherName": "da",
            "familyName": "ad",
            "dob": "1999-01-01T00:00:00",
            "gender": 1,
            "maritalStatus": 1,
            "numberOfFamilyMembers": 1,
            "contactId": 616,
            "active": true,
            "deleted": false,
            "entryStatus": 1
        }
    ],
    "hrmsEmployeeRelatives": [
        {
            "hrmsEmployeeRelativesId": 24,
            "srNo": 3,
            "hrmsEmployeeId": 46,
            "relativeName": "3",
            "relation": "1",
            "workingInCompany": true,
            "relativeEmployeeId": 12,
            "active": true,
            "deleted": false,
            "entryStatus": 1
        }
    ],
    "hrmsEmployeeCTC": [
        {
            "hrmsEmployeeCTCId": 29,
            "srNo": 2,
            "hrmsEmployeeId": 46,
            "companyId": 10001,
            "branchId": 201,
            "hrmsAllowanceId": 115,
            "allowanceValue": 1,
            "effectiveFrom": "1999-01-01T00:00:00",
            "effectiveTo": "1999-01-01T00:00:00",
            "active": true,
            "deleted": false,
            "entryStatus": 1
        }
    ],
    "hrmsEmployeeNationalityDetail": [
        {
            "hrmsEmployeeNationalityDetailId": 26,
            "srNo": 2,
            "hrmsEmployeeId": 46,
            "nationality": 1,
            "alternateNationality": 1,
            "idNumber": "1",
            "idIssuePlace": "1",
            "idIssueDate": "1999-01-01T00:00:00",
            "idExpiryDate": "1999-01-01T00:00:00",
            "alternativeIDNumber": "1",
            "alternativeIDIssuePlace": "1",
            "alternativeIDIssueDate": "1999-01-01T00:00:00",
            "alternativeIDExpiryDate": "1999-01-01T00:00:00",
            "passportNumber": "1",
            "passportIssuePlace": "1",
            "passportIssueDate": "1999-01-01T00:00:00",
            "passportExpiryDate": "1999-01-01T00:00:00",
            "visaType": 1,
            "visaNumber": "1",
            "visaIssuePlace": "1",
            "visaIssueDate": "1999-01-01T00:00:00",
            "visaExpiryDate": "1999-01-01T00:00:00",
            "expatWorkPermitType": 1,
            "expatWorkPermitIssuePlace": "1",
            "expatWorkPermitIssueDate": "1999-01-01T00:00:00",
            "expatWorkPermitExpiryDate": "1999-01-01T00:00:00",
            "active": true,
            "deleted": false,
            "entryStatus": 1
        }
    ],
    "hrmsEmployeeAdditionalSkill": []
}
         *           */
        /**********************************************************************/
        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromBody]HRMSEmployeeEntry pModel)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Validate(pModel, true) == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                // Execution of concrete process
                SQLResult result = new SQLResult();
                result = await _repo.Edit(pModel);
                if (result.ErrorNo > 0)
                {
                    return BadRequest(result);
                }
                else
                {
                    return Ok(result);
                }
            }
        }

    }
}
