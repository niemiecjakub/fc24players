using fc24players.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Version = fc24players.Models.Version;

namespace fc24players.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VersionController(IVersionRepository versionRepository) : Controller
{
    [HttpGet("all")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Version>))]
    public async Task<IActionResult> GetAll()
    {
        var versions = await versionRepository.GetAll();
        return Ok(versions);
    }
    
    [HttpGet("all/names")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<string>))]
    public async Task<IActionResult> GetAllNames()
    {
        var versions = await versionRepository.GetAllNames();
        return Ok(versions);
    }
}