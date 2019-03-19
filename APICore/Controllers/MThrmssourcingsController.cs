using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelCore.HRMS.Admin.Recruitment;

namespace APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MThrmssourcingsController : ControllerBase
    {
        private readonly AMTDEVContext _newContext;

        public MThrmssourcingsController(AMTDEVContext context)
        {
            _newContext = context;
        }

        // GET: api/MThrmssourcings
        [HttpGet]
        public IEnumerable<MThrmssourcing> GetMThrmssourcing()
        {
            return _newContext.MThrmssourcing;
        }


        [HttpGet("getalloc/{id}")]
        public IEnumerable<MThrmssourcing> GetMThrmssourcing2([FromRoute] long id)
        {
            return _newContext.MThrmssourcing.Where(u => u.ResourceAllocationId == id);
        }

        // GET: api/MThrmssourcings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmssourcing([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmssourcing = await _newContext.MThrmssourcing.FindAsync(id);

            if (mThrmssourcing == null)
            {
                return NotFound();
            }

            return Ok(mThrmssourcing);
        }

        // PUT: api/MThrmssourcings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmssourcing([FromRoute] long id, [FromBody] MThrmssourcing mThrmssourcing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmssourcing.MThrmssourcingId)
            {
                return BadRequest();
            }

            _newContext.Entry(mThrmssourcing).State = EntityState.Modified;

            try
            {
                await _newContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmssourcingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MThrmssourcings
        [HttpPost]
        public async Task<IActionResult> PostMThrmssourcing([FromBody] MThrmssourcing mThrmssourcing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _newContext.MThrmssourcing.Add(mThrmssourcing);
            await _newContext.SaveChangesAsync();
            //_context.SaveChangesAsync();

            //var _candidate = new MThrmscvrepository() { MThrmscvrepositoryId = (long)mThrmssourcing.CandidateId, Status="sourcing" };

            //using (var newContext = new AMTDEVContext())
            //{

            //    newContext.MThrmscvrepository.Attach(_candidate);
            //    newContext.Entry(_candidate).Property(X => X.Status).IsModified = true;
            //    newContext.SaveChanges();
            //}
            long test = mThrmssourcing.CandidateId.Value;
            MThrmscvrepository f = _newContext.MThrmscvrepository.FirstOrDefault(x => x.MThrmscvrepositoryId == mThrmssourcing.CandidateId);
                //myEntities.Friend.FirstOrDefault(x => x.Id = MyId);
            f.Status = "sourcing";
            await _newContext.SaveChangesAsync();

            var _shortlistrecord = new MThrmsshortlist()
            {
                MThrmsshortlistId= 0,
                ManPowerId= mThrmssourcing.ManPowerId,
                DesignationId= mThrmssourcing.DesignationId,
                ResourceRequisitionId= mThrmssourcing.ResourceRequisitionId,
                JobCode= mThrmssourcing.JobCode,
                ResourceAllocationId= mThrmssourcing.ResourceAllocationId,
                RecruiterId= mThrmssourcing.RecruiterId,
                SourcingId= mThrmssourcing.MThrmssourcingId,
                CandidateId= mThrmssourcing.CandidateId
            };
            _newContext.MThrmsshortlist.Add(_shortlistrecord);
            await _newContext.SaveChangesAsync();
            //using (var newContext = new AMTDEVContext())
            //{

            //    newContext.MThrmsshortlist.Add(_shortlistrecord);
            //    newContext.SaveChanges();
            //}

            return CreatedAtAction("GetMThrmssourcing", new { id = mThrmssourcing.MThrmssourcingId }, mThrmssourcing);
        }

        // DELETE: api/MThrmssourcings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmssourcing([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmssourcing = await _newContext.MThrmssourcing.FindAsync(id);
            if (mThrmssourcing == null)
            {
                return NotFound();
            }

            //long test = mThrmssourcing.CandidateId.Value;
            MThrmscvrepository f = _newContext.MThrmscvrepository.FirstOrDefault(x => x.MThrmscvrepositoryId == mThrmssourcing.CandidateId);
            //myEntities.Friend.FirstOrDefault(x => x.Id = MyId);
            f.Status = "available";
            await _newContext.SaveChangesAsync();

            //var _shortlistrecord = new MThrmsshortlist() {SourcingId = (long)mThrmssourcing.MThrmssourcingId};
            //// using (var newContext = new AMTDEVContext())
            //// {

            ////     //newContext.MThrmsshortlist.Attach(_shortlistrecord);
            //_newContext.MThrmsshortlist.Attach(_shortlistrecord);
            //_newContext.Remove(_shortlistrecord);
            MThrmsshortlist ff = _newContext.MThrmsshortlist.FirstOrDefault(x => x.SourcingId == mThrmssourcing.MThrmssourcingId);
            _newContext.MThrmsshortlist.Remove(ff);
            await _newContext.SaveChangesAsync();
            //     newContext.SaveChanges();MIL
            // }

            _newContext.MThrmssourcing.Remove(mThrmssourcing);
            
            await _newContext.SaveChangesAsync();

            return Ok(mThrmssourcing);
        }

        private bool MThrmssourcingExists(long id)
        {
            return _newContext.MThrmssourcing.Any(e => e.MThrmssourcingId == id);
        }
    }
}