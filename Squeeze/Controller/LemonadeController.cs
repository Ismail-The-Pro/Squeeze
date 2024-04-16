using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using Squeeze.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class LemonadeController : ControllerBase
{
    private readonly AppDbContext _context;

    public LemonadeController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Lemonade>>> GetLemonades()
    {
        return await _context.Lemonades.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Lemonade>> GetLemonade(int id)
    {
        var lemonade = await _context.Lemonades.FindAsync(id);
        if (lemonade == null)
        {
            return NotFound();
        }
        return lemonade;
    }

    [HttpPost]
    public async Task<ActionResult<Lemonade>> CreateLemonade([FromBody] Lemonade lemonade)
    {
        _context.Lemonades.Add(lemonade);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLemonade), new { id = lemonade.LemonadeId }, lemonade);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLemonade(int id, [FromBody] Lemonade lemonade)
    {
        if (id != lemonade.LemonadeId)
        {
            return BadRequest();
        }

        _context.Entry(lemonade).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLemonade(int id)
    {
        var lemonade = await _context.Lemonades.FindAsync(id);
        if (lemonade == null)
        {
            return NotFound();
        }

        _context.Lemonades.Remove(lemonade);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
