using fc24players.Dtos;
using fc24players.Helpers;
using fc24players.Interfaces;
using fc24players.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace fc24players.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayerController(IPlayerRepository playerRepository) : Controller
{
    [HttpGet("all")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<PlayerDto>))]
    public async Task<IActionResult> GetAll([FromQuery] PaginationQueryObject paginationQuery, [FromQuery] string? nationality)
    {
        var players = await playerRepository.GetAll(paginationQuery, nationality);
        var playerDtos = players.Select(p => p.ToPlayerDto()).ToList();
        return Ok(playerDtos);
    }
    
    [HttpGet("all/names")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<string>))]
    public async Task<IActionResult> GetAllNames()
    {
        var players = await playerRepository.GetAllNames();
        return Ok(players);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(PlayerDetailedDto))]
    public async Task<IActionResult> GetById(int id)
    {
        var player = await playerRepository.GetById(id);
        var playerDto = player.ToPlayerDetailedDto();
        return Ok(playerDto);
    }
}