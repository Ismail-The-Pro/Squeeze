using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using Squeeze.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class BestillingController : ControllerBase
{
    private readonly AppDbContext _context;

    public BestillingController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bestilling>>> GetAllBestillinger()
    {
        return await _context.Bestillinger
            .Include(b => b.Bestillingsdetaljer)
                .ThenInclude(d => d.Lemonade)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Bestilling>> GetBestilling(int id)
    {
        var bestilling = await _context.Bestillinger
            .Include(b => b.Bestillingsdetaljer)
                .ThenInclude(d => d.Lemonade)
            .FirstOrDefaultAsync(b => b.BestillingId == id);
        if (bestilling == null)
        {
            return NotFound("Bestilling ikke funnet.");
        }
        return bestilling;
    }

    [HttpPost]
    public async Task<ActionResult<Bestilling>> CreateBestilling([FromBody] Bestilling bestilling)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _context.Bestillinger.Add(bestilling);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBestilling), new { id = bestilling.BestillingId }, bestilling);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBestilling(int id, [FromBody] Bestilling bestilling)
    {
        if (id != bestilling.BestillingId || !ModelState.IsValid)
        {
            return BadRequest();
        }
        _context.Entry(bestilling).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBestilling(int id)
    {
        var bestilling = await _context.Bestillinger.FindAsync(id);
        if (bestilling == null)
        {
            return NotFound();
        }
        _context.Bestillinger.Remove(bestilling);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
