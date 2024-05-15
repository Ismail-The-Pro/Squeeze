using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Squeeze.Models;
using Squeeze.Service.IService;
using Sqyeeze.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Squeeze.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
       // Sørger for at alle operasjoner krever autorisasjon
    public class BestillingController : ControllerBase
    {
        private readonly IBestillingService _bestillingService;

        public BestillingController(IBestillingService bestillingService)
        {
            _bestillingService = bestillingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BestillingDTO>>> GetAllBestillinger()
        {
            var bestillinger = await _bestillingService.GetAllBestillingerAsync();
            return Ok(bestillinger);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BestillingDTO>> GetBestilling(int id)
        {
            var bestilling = await _bestillingService.GetBestillingByIdAsync(id);
            if (bestilling == null)
            {
                return NotFound();
            }
            return Ok(bestilling);
        }

        [HttpPost]
        public async Task<ActionResult<BestillingDTO>> CreateBestilling([FromBody] BestillingDTO bestillingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdBestilling = await _bestillingService.CreateBestillingAsync(bestillingDto);
            return CreatedAtAction(nameof(GetBestilling), new { id = createdBestilling.BestillingId }, createdBestilling);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBestilling(int id, [FromBody] BestillingDTO bestillingDto)
        {
            if (id != bestillingDto.BestillingId || !ModelState.IsValid)
            {
                return BadRequest();
            }
            var success = await _bestillingService.UpdateBestillingAsync(bestillingDto);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBestilling(int id)
        {
            var success = await _bestillingService.DeleteBestillingAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

