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
        //    _epo = epo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Int64 id)
        {
            HRMSEmployeeEntry result = await _repo.GetEntry(id);
            return Ok(result);
        }

        //[HttpGet("contact/{id}")]
        //public async Task<IActionResult> GetContact(Int64 id)
        //{

        //    ContactEntry result = await _epo.GetEntry(id);
        //    return Ok(result);
        ////}

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

                return true;
        }

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
