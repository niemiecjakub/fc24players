using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.AspNetCore.Mvc;

namespace fc24players.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeagueController(ILeagueRepository leagueRepository) : Controller
{
    [HttpGet("all")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<League>))]
    public async Task<IActionResult> GetAll()
    {
        var leagues = await leagueRepository.GetAll();
        return Ok(leagues);
    } 
}