using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.AspNetCore.Mvc;

namespace fc24players.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClubController(IClubRepository clubRepository) : Controller
{
    [HttpGet("all")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Club>))]
    public async Task<IActionResult> GetAll()
    {
        var clubs = await clubRepository.GetAll();
        return Ok(clubs);
    }
}