﻿using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.AspNetCore.Mvc;

namespace fc24players.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PositionController(IPositionRepository positionRepository) : Controller
{
    [HttpGet("all")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Position>))]
    public async Task<IActionResult> GetAll()
    {
        var positions = await positionRepository.GetAll();
        return Ok(positions);
    }
}