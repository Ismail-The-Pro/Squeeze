using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Squeeze.Models;
using System;
using Squeeze.DbContext;

namespace Squeeze.Controller
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class BestillingerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BestillingerController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Bestillinger
        [HttpPost]
        public async Task<ActionResult<Bestilling>> OpprettBestilling(Bestilling bestilling)
        {
            _context.Bestillinger.Add(bestilling);
            await _context.SaveChangesAsync();
            return CreatedAtAction("HentBestilling", new { bestillingId = bestilling.BestillingId }, bestilling);
        }

        // GET: api/Bestillinger/{bestillingId}
        [HttpGet("{bestillingId}")]
        public async Task<ActionResult<Bestilling>> HentBestilling(int bestillingId)
        {
            var bestilling = await _context.Bestillinger
                .Include(b => b.Bestillingsdetaljer)
                .ThenInclude(d => d.Produkt)
                .FirstOrDefaultAsync(b => b.BestillingId == bestillingId);

            if (bestilling == null)
            {
                return NotFound();
            }

            return bestilling;
        }

        // GET: api/Bestillinger
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bestilling>>> HentAlleBestillinger()
        {
            return await _context.Bestillinger.ToListAsync();
        }

        // PUT: api/Bestillinger/{bestillingId}/status
        [HttpPut("{bestillingId}/status")]
        public async Task<IActionResult> OppdaterStatus(int bestillingId, [FromBody] string status)
        {
            var bestilling = await _context.Bestillinger.FindAsync(bestillingId);
            if (bestilling == null)
            {
                return NotFound();
            }

            bestilling.Status = status;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
