using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.AspNetCore.Mvc;

namespace fc24players.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BodytypeController(IBodytypeRepository bodytypeRepository) : Controller
{
    [HttpGet("all")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Bodytype>))]
    public async Task<IActionResult> GetAll()
    {
        var bodytypes = await bodytypeRepository.GetAll();
        return Ok(bodytypes);
    }
    
    [HttpGet("all/names")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<string>))]
    public async Task<IActionResult> GetAllNames()
    {
        var bodytypes = await bodytypeRepository.GetAllNames();
        return Ok(bodytypes);
    }
}