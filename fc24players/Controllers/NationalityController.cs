using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.AspNetCore.Mvc;

namespace fc24players.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NationalityController(INationalityRepository nationalityRepository) : Controller
{
    [HttpGet("all")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Nationality>))]
    public async Task<IActionResult> GetAll()
    {
        var nationalities = await nationalityRepository.GetAll();
        return Ok(nationalities);
    }
}