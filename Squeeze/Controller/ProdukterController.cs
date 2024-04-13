using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Squeeze.Models;
using System;
using Squeeze.DbContext;

namespace Squeeze.Controller
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class ProdukterController : ControllerBase
    {
        private readonly DbContext.AppDbContext _context;

        public ProdukterController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Produkter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produkt>>> HentAlleProdukter()
        {
            return await _context.Produkter.Where(p => p.Tilgjengelig).ToListAsync();
        }

        // POST: api/Produkter
        [HttpPost]
        public async Task<ActionResult<Produkt>> LeggTilProdukt(Produkt produkt)
        {
            _context.Produkter.Add(produkt);
            await _context.SaveChangesAsync();
            return CreatedAtAction("HentProdukt", new { produktId = produkt.ProduktId }, produkt);
        }
    }

}
