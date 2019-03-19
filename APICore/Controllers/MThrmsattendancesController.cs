using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelCore.HRMS.Admin.Recruitment;
using OfficeOpenXml;

namespace APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MThrmsattendancesController : ControllerBase
    {
        private readonly AMTDEVContext _context;

        public MThrmsattendancesController(AMTDEVContext context)
        {
            _context = context;
        }

        // GET: api/MThrmsattendances
        [HttpGet]
        public IEnumerable<MThrmsattendance> GetMThrmsattendance()
        {
            return _context.MThrmsattendance;
        }

        // GET: api/MThrmsattendances/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMThrmsattendance([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsattendance = await _context.MThrmsattendance.FindAsync(id);

            if (mThrmsattendance == null)
            {
                return NotFound();
            }

            return Ok(mThrmsattendance);
        }

        // PUT: api/MThrmsattendances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMThrmsattendance([FromRoute] long id, [FromBody] MThrmsattendance mThrmsattendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mThrmsattendance.MThrmsattendanceId)
            {
                return BadRequest();
            }

            _context.Entry(mThrmsattendance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MThrmsattendanceExists(id))
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

        // POST: api/MThrmsattendances
        [HttpPost]
        public async Task<IActionResult> PostMThrmsattendance([FromBody] MThrmsattendance mThrmsattendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MThrmsattendance.Add(mThrmsattendance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMThrmsattendance", new { id = mThrmsattendance.MThrmsattendanceId }, mThrmsattendance);
        }

        [HttpGet("upatt")]
        public async Task<IActionResult> PostMThrmsattendance2()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            using (var con = new SqlConnection(@"Server=172.168.0.137; UID=markoncs; Password=Mar@123; Database=AMTDev;MultipleActiveResultSets=true;"))
            {
                con.Open();

                var excelFile = new FileInfo(@"E:\Node Server\uploads\Test.xlsx");
                using (var epPackage = new ExcelPackage(excelFile))
                {
                    var worksheet = epPackage.Workbook.Worksheets.First();

                    for (var row = 1; row <= worksheet.Dimension.End.Row; row++)
                    {
                        var rowValues = worksheet.Cells[row, 1, row, worksheet.Dimension.End.Column];
                        var cmd = new SqlCommand("INSERT INTO mTHRMSAttendance(mTHRMSEmployeeId, attendancedate, workingdate, checkin, checkout) VALUES (@contactid, @firstname, @secondname, @age, @wow)", con);
                        cmd.Parameters.AddWithValue("@contactid", rowValues["A"+row].Value);
                        cmd.Parameters.AddWithValue("@firstname", rowValues["B"+row].Value);
                        cmd.Parameters.AddWithValue("@secondname", rowValues["C"+row].Value);
                        cmd.Parameters.AddWithValue("@age", rowValues["D"+row].Value);
                        cmd.Parameters.AddWithValue("@wow", rowValues["E"+row].Value);

                        cmd.ExecuteNonQuery();
                    }

                }
                excelFile.Delete();

            }

            return Ok();
        }

        // DELETE: api/MThrmsattendances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMThrmsattendance([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mThrmsattendance = await _context.MThrmsattendance.FindAsync(id);
            if (mThrmsattendance == null)
            {
                return NotFound();
            }

            _context.MThrmsattendance.Remove(mThrmsattendance);
            await _context.SaveChangesAsync();

            return Ok(mThrmsattendance);
        }

        private bool MThrmsattendanceExists(long id)
        {
            return _context.MThrmsattendance.Any(e => e.MThrmsattendanceId == id);
        }
    }
}