using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.Library;
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
    public class HRMSAllowanceController : ControllerBase
    {
        private readonly IHRMSAllowance _repo;

        public HRMSAllowanceController(IHRMSAllowance repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Int64 id)
        {
            HRMSAllowanceEntry result = await _repo.GetEntry(id);
            return Ok(result);
        }
        //ex:http://localhost:5000/api/HRMSAllowance/1

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
                List<HRMSAllowanceIndex> result = new List<HRMSAllowanceIndex>();

                result = await _repo.GetIndex(pScreenId, pUserId, pRecordsPerPage, pPageNo, pTableId, pLastPage);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        private bool Validate(HRMSAllowanceEntry pModel, bool isUpdateValidation)
        {
            if (isUpdateValidation == true)
            {
                if (pModel.HRMSAllowanceId <= 0)
                {
                    ModelState.AddModelError("", Messages.Blank("mHRMSAllowance entry"));
                    return false;
                }
            }
            if (pModel.AllowanceCode.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("AllowanceCode"));
                return false;
            }
            if (pModel.AllowanceName.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("AllowanceName"));
                return false;
            }
            if (pModel.AllowanceDescription.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("AllowanceDescription"));
                return false;
            }
            if (pModel.AllowanceTypeId <= 0)
            {
                ModelState.AddModelError("", Messages.Blank("AllowanceTypeId"));
                return false;
            }
            if (pModel.AllowanceGroup <= 0)
            {
                ModelState.AddModelError("", Messages.Blank("AllowanceGroup"));
                return false;
            }
            //if (pModel.GrossCheck )
            //{
            //    ModelState.AddModelError("", Messages.Blank("GrossCheck"));
            //    return false;
            //}
            if (pModel.EffectiveDateFrom == null)
            {
                ModelState.AddModelError("", Messages.Blank("EffectiveDateFrom"));
                return false;
            }
            if (pModel.EffectiveDateTo == null)
            {
                ModelState.AddModelError("", Messages.Blank("EffectiveDateTo"));
                return false;
            }
            if (pModel.ValueTypeId <= 0)
            {
                ModelState.AddModelError("", Messages.Blank("ValueTypeId"));
                return false;
            }
            if (pModel.Value <= 0)
            {
                ModelState.AddModelError("", Messages.Blank("Value"));
                return false;
            }
            //if (pModel.DependencyStatus)
            //{
            //    ModelState.AddModelError("", Messages.Blank("DependencyStatus"));
            //    return false;
            //}
            //if (pModel.SlabStatus)
            //{
            //    ModelState.AddModelError("", Messages.Blank("SlabStatus"));
            //    return false;
            //}
            //if (pModel.OthersStatus)
            //{
            //    ModelState.AddModelError("", Messages.Blank("OthersStatus"));
            //    return false;
            //}
            foreach (HRMSAllowDependency item in pModel.HRMSAllowDependency)
            {

                if (item.Deleted == false)
                {
                    if (isUpdateValidation == true && item.EntryStatus == (int)EntryStatus.Update)
                    {
                        if (item.HRMSAllowDependencyId <= 1)
                        {
                            ModelState.AddModelError("", Messages.Blank("mHRMSAllowDependencyId"));
                            return false;
                        }
                        if (item.HRMSAllowanceId <= 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("mHRMSAllowance entry"));
                            return false;
                        }
                    }
          
                    if (item.SrNo <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("SrNo"));
                        return false;
                    }
                    //if (item.HRMSAllowanceId <= 1)
                    //{
                    //    ModelState.AddModelError("", Messages.Blank("mHRMSAllowanceId"));
                    //    return false;
                    //}
                    if (item.TreatedAs <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("TreatedAs"));
                        return false;
                    }
                    if (item.EntryStatus < 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("EntryStatus"));
                        return false;
                    }
                }


            }
            foreach (HRMSAllowSlab item in pModel.HRMSAllowSlab)
            {

                if (item.Deleted == false)
                {
                    if (isUpdateValidation == true && item.EntryStatus == (int)EntryStatus.Update)
                    {
                        if (item.HRMSAllowSlabId <= 1)
                        {
                            ModelState.AddModelError("", Messages.Blank("mHRMSAllowSlabId"));
                            return false;
                        }
                        if (item.HRMSAllowanceId <= 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("mHRMSAllowance entry"));
                            return false;
                        }
                    }
                   
                  
                    if (item.SrNo <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("SrNo"));
                        return false;
                    }
                    if (item.MinValue <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("MinValue"));
                        return false;
                    }
                    if (item.MaxValue <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("MaxValue"));
                        return false;
                    }
                    if (item.ValueTypeId <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("ValueTypeId"));
                        return false;
                    }
                    if (item.SlabValue <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("SlabValue"));
                        return false;
                    }
                    if (item.EntryStatus < 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("EntryStatus"));
                        return false;
                    }
                }


            }
            foreach (HRMSAllowOthers item in pModel.HRMSAllowOthers)
            {
                if (item.Deleted == false)
                {
                    if (isUpdateValidation == true && item.EntryStatus == (int)EntryStatus.Update)
                    {
                        if (item.HRMSAllowOthersId <= 1)
                        {
                            ModelState.AddModelError("", Messages.Blank("mHRMSAllowOthersId"));
                            return false;
                        }
                        if (item.HRMSAllowanceId <= 0)
                        {
                            ModelState.AddModelError("", Messages.Blank("mHRMSAllowance entry"));
                            return false;
                        }
                    }
                  
                   
                    if (item.SrNo <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("SrNo"));
                        return false;
                    }
                    //if (item.HRMSAllowanceId <= 1)
                    //{
                    //    ModelState.AddModelError("", Messages.Blank("mHRMSAllowanceId"));
                    //    return false;
                    //}
                    if (item.PropertyValue.Trim().Length == 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("PropertyValue"));
                        return false;
                    }
                    if (item.MinValue <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("MinValue"));
                        return false;
                    }
                    if (item.MaxValue <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("MaxValue"));
                        return false;
                    }
                    if (item.ValueType <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("ValueType"));
                        return false;
                    }
                    if (item.OthersValue <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("OthersValue"));
                        return false;
                    }
                    if (item.TreatedAs <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("TreatedAs"));
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
        public async Task<IActionResult> Create([FromBody]HRMSAllowanceEntry pModel)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Validate(pModel,false) == false)
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
        //ext:{
        //        	"auditColumns": 
        //        			{
        //        			"userId":1,
        //        			"hostname":"test",
        //        			"ipaddress":"test",
        //        			"devicetype":"test",
        //        			"macaddress":"test",
        //        			"companyId":10001
        //        			},
        //            "hrmsAllowanceId": 0,
        //            "allowanceCode": 1111,
        //            "allowanceName": "test",
        //            "allowanceDescription": "test",
        //            "allowanceTypeId": 1,
        //            "allowanceGroup": 1,
        //            "grossCheck": true,
        //            "effectiveDateFrom": "2009-01-01T00:00:00",
        //            "effectiveDateTo": "2001-01-01T00:00:00",
        //            "valueTypeId": 1,
        //            "value": 1,
        //            "dependencyStatus": true,
        //            "slabStatus": true,
        //            "othersStatus": true,
        //            "active": true,
        //            "hrmsAllowDependency": [
        //                {
        //                    "hrmsAllowDependencyId": 0,
        //                    "srNo": 1,
        //                    "hrmsAllowanceId": 0,
        //                    "treatedAs": 1,
        //                    "active": true,
        //                    "deleted": false,
        //                    "entryStatus":0
        //                }
        //            ],
        //            "hrmsAllowSlab": [
        //                {
        //                    "hrmsAllowSlabId": 0,
        //                    "srNo": 1,
        //                    "hrmsAllowanceId": 0,
        //                    "minValue": 1,
        //                    "maxValue": 3,
        //                    "valueTypeId": 1,
        //                    "slabValue": 1,
        //                    "active": true,
        //                    "deleted": false,
        //                    "entryStatus": 0
        //                }
        //            ],
        //            "hrmsAllowOthers": [
        //                {
        //                    "hrmsAllowOthersId": 0,
        //                    "srNo": 1,
        //                    "hrmsAllowanceId": 0,
        //                    "propertyValue": "a",
        //                    "minMaxCheck": true,
        //                    "minValue": 1,
        //                    "maxValue": 36666,
        //                    "valueType": 1,
        //                    "othersValue": 1,
        //                    "treatedAs": 1,
        //                    "active": true,
        //                    "deleted": false,
        //                    "entryStatus": 0
        //                }
        //            ]
        //        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromBody]HRMSAllowanceEntry pModel)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Validate(pModel,true) == false)
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
                    //        ex:{
                    //	"auditColumns": 
                    //			{
                    //			"userId":1,
                    //			"hostname":"test",
                    //			"ipaddress":"test",
                    //			"devicetype":"test",
                    //			"macaddress":"test",
                    //			"companyId":10001
                    //			},
                    //    "hrmsAllowanceId": 2,
                    //    "allowanceCode": 1111,
                    //    "allowanceName": "test",
                    //    "allowanceDescription": "test",
                    //    "allowanceTypeId": 1,
                    //    "allowanceGroup": 1,
                    //    "grossCheck": true,
                    //    "effectiveDateFrom": "2009-01-01T00:00:00",
                    //    "effectiveDateTo": "2001-01-01T00:00:00",
                    //    "valueTypeId": 1,
                    //    "value": 1,
                    //    "dependencyStatus": true,
                    //    "slabStatus": true,
                    //    "othersStatus": true,
                    //    "active": true,
                    //    "hrmsAllowDependency": [
                    //        {
                    //            "hrmsAllowDependencyId": 2,
                    //            "srNo": 1,
                    //            "hrmsAllowanceId": 2,
                    //            "treatedAs": 1,
                    //            "active": true,
                    //            "deleted": false,
                    //            "entryStatus":1
                    //        }
                    //    ],
                    //    "hrmsAllowSlab": [
                    //        {
                    //            "hrmsAllowSlabId": 2,
                    //            "srNo": 1,
                    //            "hrmsAllowanceId": 2,
                    //            "minValue": 1,
                    //            "maxValue": 3333,
                    //            "valueTypeId": 1,
                    //            "slabValue": 1,
                    //            "active": true,
                    //            "deleted": false,
                    //            "entryStatus": 1
                    //        }
                    //    ],
                    //    "hrmsAllowOthers": [
                    //        {
                    //            "hrmsAllowOthersId": 0,
                    //            "srNo": 2,
                    //            "hrmsAllowanceId": 2,
                    //            "propertyValue": "b",
                    //            "minMaxCheck": true,
                    //            "minValue": 1,
                    //            "maxValue": 99999,
                    //            "valueType": 1,
                    //            "othersValue": 1,
                    //            "treatedAs": 1,
                    //            "active": true,
                    //            "deleted": false,
                    //            "entryStatus": 0
                    //        },
                    //        {
                    //            "hrmsAllowOthersId": 2,
                    //            "srNo": 1,
                    //            "hrmsAllowanceId": 2,
                    //            "propertyValue": "a",
                    //            "minMaxCheck": true,
                    //            "minValue": 1,
                    //            "maxValue": 36666,
                    //            "valueType": 1,
                    //            "othersValue": 1,
                    //            "treatedAs": 1,
                    //            "active": true,
                    //            "deleted": true,
                    //            "entryStatus": 2
                    //        }
        
                    //    ]
                    //}
    }
}