using Microsoft.AspNetCore.Mvc;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using Squeeze.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class KundeController : ControllerBase
{
    private readonly AppDbContext _context;

    public KundeController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Kunde>>> GetKunder()
    {
        return await _context.Kunder.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Kunde>> GetKunde(int id)
    {
        var kunde = await _context.Kunder.FindAsync(id);
        if (kunde == null)
        {
            return NotFound();
        }
        return kunde;
    }

    [HttpPost]
    public async Task<ActionResult<Kunde>> CreateKunde([FromBody] Kunde kunde)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _context.Kunder.Add(kunde);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetKunde), new { id = kunde.KundeId }, kunde);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateKunde(int id, [FromBody] Kunde kunde)
    {
        if (id != kunde.KundeId || !ModelState.IsValid)
        {
            return BadRequest();
        }
        _context.Entry(kunde).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteKunde(int id)
    {
        var kunde = await _context.Kunder.FindAsync(id);
        if (kunde == null)
        {
            return NotFound();
        }
        _context.Kunder.Remove(kunde);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
