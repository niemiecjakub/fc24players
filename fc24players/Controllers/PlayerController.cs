using fc24players.Helpers;
using fc24players.Interfaces;
using fc24players.Mapper;
using fc24players.Models;
using Microsoft.AspNetCore.Mvc;

namespace fc24players.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayerController(IPlayerRepository playerRepository) : Controller
{
    [HttpGet("all")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Player>))]
    public async Task<IActionResult> GetAll([FromQuery] PaginationQueryObject paginationQuery)
    {
        var players = await playerRepository.GetAll(paginationQuery);
        var playerDtos = players.Select(p => p.ToPlayerDto()).ToList();
        return Ok(playerDtos);
    }
}