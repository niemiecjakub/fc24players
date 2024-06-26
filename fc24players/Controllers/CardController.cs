﻿using fc24players.Helpers;
using fc24players.Interfaces;
using fc24players.Mapper;
using fc24players.Models;
using Microsoft.AspNetCore.Mvc;

namespace fc24players.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CardController(ICardRepository cardRepository) : Controller
{
    [HttpGet("all")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Card>))]
    public async Task<IActionResult> GetAll([FromQuery] PaginationQueryObject paginationQuery, [FromQuery] CardQueryObject cardQuery)
    {
        var cards = await cardRepository.GetAll(paginationQuery, cardQuery);
        var cardsDto = cards.Select(c => c.ToCardDto()).ToList();
        return Ok(cardsDto);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(Card))]
    public async Task<IActionResult> GetById(int id)
    {
        var card = await cardRepository.GetById(id);
        if (card == null)
        {
            return NotFound();
        }
        var cardDto = card.ToCardDetailedDto();
        return Ok(cardDto);
    }
        
    [HttpGet("ids")]
    [ProducesResponseType(200, Type = typeof(Card))]
    public async Task<IActionResult> GetCardIds([FromQuery] CursorPaginationQueryObject paginationQuery)
    {
        var cardIdPageDto = await cardRepository.GetIds(paginationQuery);
        return Ok(cardIdPageDto);
    }
}