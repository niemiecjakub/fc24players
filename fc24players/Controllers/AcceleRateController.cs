using fc24players.Dto.AcceleRate;
using fc24players.Interfaces;
using fc24players.Mapper;
using fc24players.Models;
using Microsoft.AspNetCore.Mvc;

namespace fc24players.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AcceleRateController(IAcceleRateRepository acceleRateRepository, ICardRepository cardRepository) : Controller
{
    [HttpGet("all")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<AcceleRate>))]
    public async Task<IActionResult> GetAll()
    {
        var accelerate = await acceleRateRepository.GetAll();
        return Ok(accelerate);
    }
    
    [HttpGet("all/names")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<string>))]
    public async Task<IActionResult> GetAllNames()
    {
        var accelerate = await acceleRateRepository.GetAllNames();
        return Ok(accelerate);
    }
    
    [HttpGet("{name}")]
    [ProducesResponseType(200, Type = typeof(AcceleRateDto))]
    public async Task<IActionResult> GetByName(string name)
    {
        // var accelerate = await acceleRateRepository.GetAllNames();
        // return Ok(accelerate);
        return BadRequest();
    }

}