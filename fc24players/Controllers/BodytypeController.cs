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
}