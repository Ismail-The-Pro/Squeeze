using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Squeeze.Models;
using Squeeze.Service.IService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Squeeze.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BestillingController : ControllerBase
    {
        private readonly IBestillingService _bestillingService;

        // Constructor injection for dependency
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

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBestilling(int id, [FromBody] BestillingDTO bestillingDto)
        {
            if (id != bestillingDto.BestillingId || !ModelState.IsValid)
            {
                return BadRequest();
            }
            var success = await _bestillingService.UpdateBestillingAsync(bestillingDto);  // Assuming UpdateBestillingAsync returns a Task<bool>
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBestilling(int id)
        {
            var success = await _bestillingService.DeleteBestillingAsync(id);  // Assuming DeleteBestillingAsync returns a Task<bool>
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
