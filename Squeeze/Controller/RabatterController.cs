using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Squeeze.Models;
using Squeeze.DbContext;

namespace Squeeze.Controller
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class RabatterController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RabatterController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Rabatter/{kundeId}
        [HttpGet("{kundeId}")]
        public async Task<ActionResult<Rabatt>> HentRabatt(int kundeId)
        {
            var rabatt = await _context.Rabatter.FirstOrDefaultAsync(r => r.KundeId == kundeId);

            if (rabatt == null)
            {
                return NotFound();
            }

            return rabatt;
        }
    }

}
