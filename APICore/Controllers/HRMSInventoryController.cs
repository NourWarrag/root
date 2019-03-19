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
 public class HRMSInventoryController : ControllerBase
 {
     private readonly IHRMSInventory _repo;
     public HRMSInventoryController(IHRMSInventory repo)
     {
         _repo = repo;
     }

     [HttpGet("{id}")]
     public async Task<IActionResult> Get(Int64 id)
        {
            HRMSInventoryEntry result = await _repo.GetEntry(id);
            return Ok(result);
        }
        //ex:http://localhost:5000/api/HRMSInventory/13       

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
                List<HRMSInventoryIndex> result = new List<HRMSInventoryIndex>();

                result = await _repo.GetIndex(pScreenId, pUserId, pRecordsPerPage, pPageNo, pTableId, pLastPage);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        private bool Validate(HRMSInventoryEntry pModel, bool isUpdateValidation)
        {
            if (isUpdateValidation == true)
            {
                    if (pModel.HRMSInventoryId <= 0)
                    {
                            ModelState.AddModelError("", Messages.Blank("mHRMSInventory entry"));
                            return false;
                    }
            }
            if ( pModel.InventoryName.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("InventoryName"));
                return false;
            }
           foreach (HRMSInventoryDetails item in pModel.HRMSInventoryDetail)
            {
                if(item.Deleted == false ){
                    if (isUpdateValidation == true && item.EntryStatus == EntryStatus.Update)                    {
                      if (item.HRMSInventoryDetailId<= 1)
                            {
                                ModelState.AddModelError("", Messages.Blank("mHRMSInventoryDetailId"));
                                return false;
                            }
                            

                            if (item.HRMSInventoryId<= 1)
                            {
                                ModelState.AddModelError("", Messages.Blank("mHRMSInventoryId"));
                                return false;
                            }
                            if (item.HRMSAttributeId<= 1)
                            {
                                ModelState.AddModelError("", Messages.Blank("mHRMSAttributeId"));
                                return false;
                            }
                          
                            // if (item.EntryStatus < 0)
                            // {
                            //     ModelState.AddModelError("", Messages.Blank("EntryStatus"));
                            //     return false;
                            // }
                    }
                    if (item.SrNo <= 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("SrNo"));
                        return false;
                    }
                    if (item.AttributeValue.Trim().Length == 0)
                    {
                        ModelState.AddModelError("", Messages.Blank("AttributeValue"));
                        return false;
                    }
                }

            }   
            
            return true;
        }


         [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]HRMSInventoryEntry pModel)
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
        //ex:{
                //    "auditcolumns": 
                //			{
                //			"userid":1,
                //			"hostname":"test",
                //			"ipaddress":"test",
                //			"devicetype":"test",
                //			"macaddress":"test",
                //			"companyid":10001
                //			},
                //    "hrmsinventoryid": 0,
                //    "inventoryname": "test inv",
                //    "active": true,
                //    "hrmsinventorydetail": [
                //        {	
                //        	"hrmsinventorydetailid": 0,
                //        	"srno": 1,
                //        	"hrmsinventoryid": 0,
                //            "hrmsattributeid": 2,
                //            "attributevalue": "50",
                //            "active": true,
                //            "deleted": false,
                //            "entrystatus":0


                //        },
                //        {	 
                //        	"hrmsinventorydetailid": 0,
                //        	"srno": 1,
                //        	"hrmsinventoryid": 0,
                //            "hrmsattributeid": 3,
                //            "attributevalue": "999",
                //            "active": true,
                //            "deleted": false,
                //            "entrystatus":0
            
                //        }
        
                //    ]
                //}

        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromBody]HRMSInventoryEntry pModel)
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
                    //    "auditColumns": 
                    //			{
                    //			"userId":1,
                    //			"hostname":"test",
                    //			"ipaddress":"test",
                    //			"devicetype":"test",
                    //			"macaddress":"test",
                    //			"companyId":10001
                    //			},
                    //    "hrmsInventoryId": 13,
                    //    "inventoryName": "test inv edited",
                    //    "active": true,
                    //    "EntryStatus":1,
                    //    "hrmsInventoryDetail": [
                    //        {	
                    //        	"hrmsInventoryDetailId": 9,
                    //        	"srNo": 1,
                    //        	"hrmsInventoryId": 13,
                    //            "hrmsAttributeId": 2,
                    //            "attributeValue": "50",
                    //            "active": true,
                    //            "deleted": true,
                    //            "EntryStatus":1


                    //        },
                    //        {	 
                    //        	"hrmsInventoryDetailId": 10,
                    //        	"srNo": 1,
                    //        	"hrmsInventoryId": 13,
                    //            "hrmsAttributeId": 3,
                    //            "attributeValue": "9",
                    //            "active": true,
                    //            "deleted": false,
                    //            "EntryStatus":1
            
                    //        },
                    //        {	 
                    //        	"hrmsInventoryDetailId": 0,
                    //        	"srNo": 1,
                    //        	"hrmsInventoryId": 13,
                    //            "hrmsAttributeId": 3,
                    //            "attributeValue": "9009",
                    //            "active": true,
                    //            "deleted": false,
                    //            "EntryStatus":0
            
                    //        }
        
                    //    ]
                    //}

 }
}