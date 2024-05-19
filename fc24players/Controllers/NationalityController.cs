using fc24players.Interfaces;
using fc24players.Mapper;
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
        var nationalitiesDto = nationalities.Select(n => n.ToNationalityDto()).ToList();
        return Ok(nationalitiesDto);
    }
    
    [HttpGet("{name}")]
    [ProducesResponseType(200, Type = typeof(Nationality))]
    [ProducesResponseType(204)]
    public async Task<IActionResult> GetByName(string name)
    {
        var nationality = await nationalityRepository.GetByName(name);
        if (nationality == null)
        {
            return NoContent();
        }

        var nationalityDto = nationality.ToNationalityDto();
        return Ok(nationalityDto);
    }
}