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


namespace APICore.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HRMSAttributeController : ControllerBase
    {
        private readonly IHRMSAttribute _repo;
        public HRMSAttributeController(IHRMSAttribute repo)
        {
            _repo = repo;
        }

        #region -- mHRMSAttribute
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Int64 id)
        {
            HRMSAttributeEntry result = await _repo.GetEntry(id);
            return Ok(result);
        }
        //ex:http://localhost:5000/api/HRMSAttribute/4 

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
                List<HRMSAttributeIndex> result = new List<HRMSAttributeIndex>();

                result = await _repo.GetIndex(pScreenId, pUserId, pRecordsPerPage, pPageNo, pTableId, pLastPage);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        private bool Validate(HRMSAttributeEntry pModel, bool isUpdateValidation)
        {
            if (isUpdateValidation == true)
            {
                if (pModel.HRMSAttributeId <= 0)
                {
                    ModelState.AddModelError("", Messages.Blank("HRMSAttribute entry"));
                    return false;
                }
            }
            if (pModel.AttributeName.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("AttributeName"));
                return false;
            }
            if (pModel.UsedFor.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("UsedFor"));
                return false;
            }
            if (pModel.AuditColumns.MACAddress.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("MAC Address"));
                return false;
            }
            if (pModel.AuditColumns.HostName.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("Host Name"));
                return false;
            }
            if (pModel.AuditColumns.IPAddress.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("IP Address"));
                return false;
            }
            if (pModel.AuditColumns.DeviceType.Trim().Length == 0)
            {
                ModelState.AddModelError("", Messages.Blank("Device Type"));
                return false;
            }

            return true;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]HRMSAttributeEntry pModel)
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
                    //ex:  {
              //"AttributeID": 0,
              //"AttributeName": "test1",
              //"UsedFor": "test1",
              //"active": true,
            //  "auditColumns": 
            //{
            //"userId":1,
            //"hostname":"test",
            //"ipaddress":"test",
            //"devicetype":"test",
            //"macaddress":"test",
            //"companyId":10001
            //}
            //}
    [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromBody]HRMSAttributeEntry pModel)
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
        //ex:  {
        //"AttributeID": 2,
        //"AttributeName": "testEdit",
        //"UsedFor": "test1",
        //"active": true,
        //  "auditColumns": 
        //{
        //"userId":1,
        //"hostname":"test",
        //"ipaddress":"test",
        //"devicetype":"test",
        //"macaddress":"test",
        //"companyId":10001
        //}
        //}
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody]HRMSAttributeEntry pModel)
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
                result = await _repo.Delete(pModel);
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
        //ex:  {
        //"AttributeID": 2,
        //"AttributeName": "test1",
        //"UsedFor": "test1",
        //"active": true,
        //  "auditColumns": 
        //{
        //"userId":1,
        //"hostname":"test",
        //"ipaddress":"test",
        //"devicetype":"test",
        //"macaddress":"test",
        //"companyId":10001
        //}
        //}
        #endregion -- mHRMSAttribute




    }
}