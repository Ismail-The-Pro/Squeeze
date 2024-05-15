using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Squeeze.Mapper;
using Squeeze.Models.DTO;
using Squeeze.Service.IService;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class KundeController : ControllerBase
{
    private readonly IKundeService _kundeService;

    public KundeController(IKundeService kundeService)
    {
        _kundeService = kundeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<KundeDTO>>> GetKunder()
    {
        var kunder = await _kundeService.GetAllKunderAsync();
        return Ok(kunder);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<KundeDTO>> GetKunde(int id)
    {
        var kunde = await _kundeService.GetKundeByIdAsync(id);
        if (kunde == null)
        {
            return NotFound();
        }
        return kunde;
    }

    [HttpPost]
    public async Task<ActionResult<KundeDTO>> CreateKunde([FromBody] KundeDTO kundeDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKunde = await _kundeService.CreateKundeAsync(kundeDto);
        return CreatedAtAction(nameof(GetKunde), new { id = createdKunde.KundeId }, createdKunde);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateKunde(int id, [FromBody] KundeDTO kundeDto)
    {
        if (id != kundeDto.KundeId || !ModelState.IsValid)
        {
            return BadRequest();
        }
        var updated = await _kundeService.UpdateKundeAsync(kundeDto);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteKunde(int id)
    {
        await _kundeService.DeleteKundeAsync(id);
        return NoContent();
    }
}
