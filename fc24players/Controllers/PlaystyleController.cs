using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.AspNetCore.Mvc;

namespace fc24players.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlaystyleController(IPlaystyleRepository playstyleRepository) : Controller
{
    [HttpGet("all")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Playstyle>))]
    public async Task<IActionResult> GetAll()
    {
        var playstyles = await playstyleRepository.GetAll();
        return Ok(playstyles);
    }
}