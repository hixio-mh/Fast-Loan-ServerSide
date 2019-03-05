using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FwCore.DBContext;
using FwCore.DBContext.Model;

namespace FwApi.AppData
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanApplicationController : ControllerBase
    {
        private readonly AppDataDbContext _context;

        public LoanApplicationController(AppDataDbContext context)
        {
            _context = context;
        }

        // GET: api/LoanApplication
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanApplication>>> GetLoanApplications()
        {
            return await _context.LoanApplications.ToListAsync();
        }

        // GET: api/LoanApplication/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanApplication>> GetLoanApplication(int id)
        {
            var loanApplication = await _context.LoanApplications.FindAsync(id);

            if (loanApplication == null)
            {
                return NotFound();
            }

            return loanApplication;
        }

        // PUT: api/LoanApplication/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoanApplication(int id, LoanApplication loanApplication)
        {
            if (id != loanApplication.LoanApplicationId)
            {
                return BadRequest();
            }

            _context.Entry(loanApplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanApplicationExists(id))
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

        // POST: api/LoanApplication
        [HttpPost]
        public async Task<ActionResult<LoanApplication>> PostLoanApplication(LoanApplication loanApplication)
        {
            _context.LoanApplications.Add(loanApplication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanApplication", new { id = loanApplication.LoanApplicationId }, loanApplication);
        }

        // DELETE: api/LoanApplication/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoanApplication>> DeleteLoanApplication(int id)
        {
            var loanApplication = await _context.LoanApplications.FindAsync(id);
            if (loanApplication == null)
            {
                return NotFound();
            }

            _context.LoanApplications.Remove(loanApplication);
            await _context.SaveChangesAsync();

            return loanApplication;
        }

        private bool LoanApplicationExists(int id)
        {
            return _context.LoanApplications.Any(e => e.LoanApplicationId == id);
        }
    }
}
