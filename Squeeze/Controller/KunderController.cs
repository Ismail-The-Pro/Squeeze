using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Squeeze.Models;
using System;
using System.Data.Entity;
using Squeeze.DbContext;

namespace Squeeze.Controller
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class KunderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public KunderController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Kunder
        [HttpPost]
        public async Task<ActionResult<Kunde>> RegistrerKunde(Kunde kunde)
        {
            _context.Kunder.Add(kunde);
            await _context.SaveChangesAsync();
            return CreatedAtAction("HentKunde", new { kundeId = kunde.KundeId }, kunde);
        }

        // GET: api/Kunder/{kundeId}
        [HttpGet("{kundeId}")]
        public async Task<ActionResult<Kunde>> HentKunde(int kundeId)
        {
            var kunde = await _context.Kunder.FindAsync(kundeId);
            if (kunde == null)
            {
                return NotFound();
            }
            return kunde;
        }
    }

}
