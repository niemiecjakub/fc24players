using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.AspNetCore.Mvc;

namespace fc24players.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AcceleRateController(IAcceleRateRepository acceleRateRepository) : Controller
{
    [HttpGet("all")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<AcceleRate>))]
    public async Task<IActionResult> GetAll()
    {
        var accelerate = await acceleRateRepository.GetAll();
        return Ok(accelerate);
    }
}