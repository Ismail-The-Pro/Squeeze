using Microsoft.AspNetCore.Mvc;
using Squeeze.Models;
using Squeeze.Service;
using Squeeze.Mapper;
using Squeeze.Models.DTO;
using Squeeze.Service.IService;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
public class KundeController : ControllerBase
{
    private readonly IKundeService _kundeService;

    public KundeController(IKundeService kundeService)
    {
        _kundeService = kundeService;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<KundeDTO>>> GetKunder()
    {
        var kunder = await _kundeService.GetAllKunderAsync();
        var kunderDto = kunder.Select(KundeMapper.ToDTO);
        return Ok(kunderDto);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<KundeDTO>> GetKunde(int id)
    {
        var kunde = await _kundeService.GetKundeByIdAsync(id);
        if (kunde == null)
        {
            return NotFound();
        }
        return KundeMapper.ToDTO(kunde);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<KundeDTO>> CreateKunde([FromBody] KundeDTO kundeDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var kunde = KundeMapper.FromDTO(kundeDto);
        var createdKunde = await _kundeService.CreateKundeAsync(kunde);
        return CreatedAtAction(nameof(GetKunde), new { id = createdKunde.KundeId }, KundeMapper.ToDTO(createdKunde));
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateKunde(int id, [FromBody] KundeDTO kundeDto)
    {
        if (id != kundeDto.KundeId || !ModelState.IsValid)
        {
            return BadRequest();
        }
        var kunde = KundeMapper.FromDTO(kundeDto);
        await _kundeService.UpdateKundeAsync(kunde);
        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteKunde(int id)
    {
        await _kundeService.DeleteKundeAsync(id);
        return NoContent();
    }
}
