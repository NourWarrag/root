using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfaceCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelCore.Misc;

namespace APICore.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HRMSDdlController : ControllerBase
    {
        private readonly ICommon _repo;
        public HRMSDdlController(ICommon repo)
        {
            _repo = repo;
        }

        //allowance
        [HttpGet("allowance/{pNoneRecord}")]
        public async Task<IActionResult> Allowance(Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                result = await _repo.GetSelectDdl(
                    new SelectDdlParameters
                    {
                        TableName = "mHRMSAllowance",
                        DisplayColumnName = "AllowanceName",
                        IndexColumnName = "mHRMSAllowanceId",
                        WhereClause = "",
                        OrderByClause = "",
                        NoneRecord = pNoneRecord
                    });
                return Ok(result);
            }
            catch (Exception ex)
            {
                SQLResult errResult = new SQLResult
                {
                    ErrorNo = 9999999999,
                    ErrorMessage = ex.Message.ToString(),
                    SQLErrorNumber = ex.HResult,
                    SQLErrorMessage = ex.Source.ToString()
                };
                return BadRequest(errResult);
            }
        }
        

        [HttpGet("acAllowance/{pSearchText}/{pNoneRecord}")]
        public async Task<IActionResult> ACAllowance(string pSearchText, Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                result = await _repo.GetSelectDdl(
                    new SelectDdlParameters
                    {
                        TableName = "mHRMSAllowance",
                        DisplayColumnName = "AllowanceName",
                        IndexColumnName = "mHRMSAllowanceId",
                        WhereClause = "AllowanceName like '%" + pSearchText + "%'",
                        OrderByClause = "",
                        NoneRecord = pNoneRecord
                    });
                return Ok(result);
            }
            catch (Exception ex)
            {
                SQLResult errResult = new SQLResult
                {
                    ErrorNo = 9999999999,
                    ErrorMessage = ex.Message.ToString(),
                    SQLErrorNumber = ex.HResult,
                    SQLErrorMessage = ex.Source.ToString()
                };
                return BadRequest(errResult);
            }
        }

        [HttpGet("acCountry/{pSearchText}/{pNoneRecord}")]
        public async Task<IActionResult> ACCountry(string pSearchText, Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                if (pSearchText != null && pSearchText.ToString() != "")
                {
                    result = await _repo.GetSelectDdl(
                        new SelectDdlParameters
                        {
                            TableName = "mCountry",
                            DisplayColumnName = "Country",
                            IndexColumnName = "mCountryId",
                            WhereClause = "Country like '%" + pSearchText + "%'",
                            OrderByClause = "Country",
                            NoneRecord = pNoneRecord
                        });
                    return Ok(result);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                SQLResult errResult = new SQLResult
                {
                    ErrorNo = 9999999999,
                    ErrorMessage = ex.Message.ToString(),
                    SQLErrorNumber = ex.HResult,
                    SQLErrorMessage = ex.Source.ToString()
                };
                return BadRequest(errResult);
            }
        }

        [HttpGet("state/{pCountryId}/{pNoneRecord}")]
        public async Task<IActionResult> State(Int64 pCountryId, Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                result = await _repo.GetSelectDdl(
                    new SelectDdlParameters
                    {
                        TableName = "mState",
                        DisplayColumnName = "State",
                        IndexColumnName = "mStateId",
                        WhereClause = pCountryId == 0 ? "" : "mCountryId = " + pCountryId.ToString(),
                        OrderByClause = "",
                        NoneRecord = pNoneRecord
                    });
                return Ok(result);
            }
            catch (Exception ex)
            {
                SQLResult errResult = new SQLResult
                {
                    ErrorNo = 9999999999,
                    ErrorMessage = ex.Message.ToString(),
                    SQLErrorNumber = ex.HResult,
                    SQLErrorMessage = ex.Source.ToString()
                };
                return BadRequest(errResult);
            }
        }

        // City List
        [HttpGet("city/{pStateId}/{pNoneRecord}")]
        public async Task<IActionResult> City(Int64 pStateId, Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                result = await _repo.GetSelectDdl(
                    new SelectDdlParameters
                    {
                        TableName = "mCity",
                        DisplayColumnName = "City",
                        IndexColumnName = "mCityId",
                        WhereClause = pStateId == 0 ? "" : "mStateId = " + pStateId.ToString(),
                        OrderByClause = "",
                        NoneRecord = pNoneRecord
                    });
                return Ok(result);
            }
            catch (Exception ex)
            {
                SQLResult errResult = new SQLResult
                {
                    ErrorNo = 9999999999,
                    ErrorMessage = ex.Message.ToString(),
                    SQLErrorNumber = ex.HResult,
                    SQLErrorMessage = ex.Source.ToString()
                };
                return BadRequest(errResult);
            }
        }

        [HttpGet("acCompany/{pSearchText}/{pNoneRecord}")]
        public async Task<IActionResult> ACCompany(string pSearchText, Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                if (pSearchText != null && pSearchText.ToString() != "")
                {
                    result = await _repo.GetSelectDdl(
                        new SelectDdlParameters
                        {
                            TableName = "mCompany",
                            DisplayColumnName = "Company",
                            IndexColumnName = "mCompanyId",
                            WhereClause = "Company like '%" + pSearchText + "%'",
                            OrderByClause = "Company",
                            NoneRecord = pNoneRecord
                        });
                    return Ok(result);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                SQLResult errResult = new SQLResult
                {
                    ErrorNo = 9999999999,
                    ErrorMessage = ex.Message.ToString(),
                    SQLErrorNumber = ex.HResult,
                    SQLErrorMessage = ex.Source.ToString()
                };
                return BadRequest(errResult);
            }
        }

        [HttpGet("acBranch/{pSearchText}/{pNoneRecord}")]
        public async Task<IActionResult> ACBranch(string pSearchText, Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                if (pSearchText != null && pSearchText.ToString() != "")
                {
                    result = await _repo.GetSelectDdl(
                        new SelectDdlParameters
                        {
                            TableName = "mBranch",
                            DisplayColumnName = "Branch",
                            IndexColumnName = "mBranchId",
                            WhereClause = "Branch like '%" + pSearchText + "%'",
                            OrderByClause = "Branch",
                            NoneRecord = pNoneRecord
                        });
                    return Ok(result);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                SQLResult errResult = new SQLResult
                {
                    ErrorNo = 9999999999,
                    ErrorMessage = ex.Message.ToString(),
                    SQLErrorNumber = ex.HResult,
                    SQLErrorMessage = ex.Source.ToString()
                };
                return BadRequest(errResult);
            }
        }


        [HttpGet("acDepartment/{pSearchText}/{pNoneRecord}")]
        public async Task<IActionResult> ACDepartment(string pSearchText, Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                if (pSearchText != null && pSearchText.ToString() != "")
                {
                    result = await _repo.GetSelectDdl(
                        new SelectDdlParameters
                        {
                            TableName = "mDepartment",
                            DisplayColumnName = "Department",
                            IndexColumnName = "mDepartmentId",
                            WhereClause = "Department like '%" + pSearchText + "%'",
                            OrderByClause = "Department",
                            NoneRecord = pNoneRecord
                        });
                    return Ok(result);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                SQLResult errResult = new SQLResult
                {
                    ErrorNo = 9999999999,
                    ErrorMessage = ex.Message.ToString(),
                    SQLErrorNumber = ex.HResult,
                    SQLErrorMessage = ex.Source.ToString()
                };
                return BadRequest(errResult);
            }
        }

        [HttpGet("acDesignation/{pSearchText}/{pNoneRecord}")]
        public async Task<IActionResult> ACDesignation(string pSearchText, Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                if (pSearchText != null && pSearchText.ToString() != "")
                {
                    result = await _repo.GetSelectDdl(
                        new SelectDdlParameters
                        {
                            TableName = "mDesignation",
                            DisplayColumnName = "Designation",
                            IndexColumnName = "mDesignationId",
                            WhereClause = "Designation like '%" + pSearchText + "%'",
                            OrderByClause = "Designation",
                            NoneRecord = pNoneRecord
                        });
                    return Ok(result);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                SQLResult errResult = new SQLResult
                {
                    ErrorNo = 9999999999,
                    ErrorMessage = ex.Message.ToString(),
                    SQLErrorNumber = ex.HResult,
                    SQLErrorMessage = ex.Source.ToString()
                };
                return BadRequest(errResult);
            }
        }

        [HttpGet("acEmployee/code/{pSearchText}/{pNoneRecord}")]
        public async Task<IActionResult> ACEmployee(string pSearchText, Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                result = await _repo.GetSelectDdl(
                    new SelectDdlParameters
                    {
                        TableName = "mHRMSEmployee",
                        DisplayColumnName = "EmployeeCode",
                        IndexColumnName = "mHRMSEmployeeId",
                        WhereClause = "EmployeeCode like '%" + pSearchText + "%'",
                        OrderByClause = "",
                        NoneRecord = pNoneRecord
                    });
                return Ok(result);
            }
            catch (Exception ex)
            {
                SQLResult errResult = new SQLResult
                {
                    ErrorNo = 9999999999,
                    ErrorMessage = ex.Message.ToString(),
                    SQLErrorNumber = ex.HResult,
                    SQLErrorMessage = ex.Source.ToString()
                };
                return BadRequest(errResult);
            }
        }

        [HttpGet("acEmployee/name/{pSearchText}/{pNoneRecord}")]
        public async Task<IActionResult> ACEmployeeName(string pSearchText, Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                result = await _repo.GetSelectDdl(
                    new SelectDdlParameters
                    {
                        TableName = "mHRMSEmployeePersonalDetail",
                        DisplayColumnName = "EmployeeName",
                        IndexColumnName = "mHRMSEmployeeId",
                        WhereClause = "EmployeeName like '%" + pSearchText + "%'",
                        OrderByClause = "",
                        NoneRecord = pNoneRecord
                    });
                return Ok(result);
            }
            catch (Exception ex)
            {
                SQLResult errResult = new SQLResult
                {
                    ErrorNo = 9999999999,
                    ErrorMessage = ex.Message.ToString(),
                    SQLErrorNumber = ex.HResult,
                    SQLErrorMessage = ex.Source.ToString()
                };
                return BadRequest(errResult);
            }
        }

        [HttpGet("skillSet/{pNoneRecord}")]
        public async Task<IActionResult> ACSkillSet(Boolean pNoneRecord)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                result = await _repo.GetSelectDdl(
                    new SelectDdlParameters
                    {
                        TableName = "mHRMSSkillSet",
                        DisplayColumnName = "SkillSetName",
                        IndexColumnName = "mHRMSSkillSetId",
                        WhereClause = "",
                        OrderByClause = "",
                        NoneRecord = pNoneRecord
                    });
                return Ok(result);
            }
            catch (Exception ex)
            {
                SQLResult errResult = new SQLResult
                {
                    ErrorNo = 9999999999,
                    ErrorMessage = ex.Message.ToString(),
                    SQLErrorNumber = ex.HResult,
                    SQLErrorMessage = ex.Source.ToString()
                };
                return BadRequest(errResult);
            }
        }

        [HttpGet("ddlSortColumn/{pTableId}/{pUserId}")]
        public async Task<IActionResult> DdlPageSortColumns(Int64 pTableId, Int64 pUserId)
        {
            try
            {
                List<SelectDdl> result = new List<SelectDdl>();
                result = await _repo.GetSelectDdl(
                    new SelectDdlParameters
                    {
                        TableName = "mColumn",
                        DisplayColumnName = "ColumnName",
                        IndexColumnName = "mColumnId",
                        WhereClause = "DisplayColumn =  1 and mTableId = " + pTableId.ToString(),
                        OrderByClause = "ColumnName",
                        NoneRecord = false
                    });
                return Ok(result);
            }
            catch (Exception ex)
            {
                SQLResult errResult = new SQLResult
                {
                    ErrorNo = 9999999999,
                    ErrorMessage = ex.Message.ToString(),
                    SQLErrorNumber = ex.HResult,
                    SQLErrorMessage = ex.Source.ToString()
                };
                return BadRequest(errResult);
            }
        }


    }
}