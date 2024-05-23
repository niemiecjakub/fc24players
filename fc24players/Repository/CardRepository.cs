using fc24players.Data;
using fc24players.Helpers;
using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.EntityFrameworkCore;

namespace fc24players.Repository;

public class CardRepository(ApplicationDbContext context) : ICardRepository
{
    public async Task<ICollection<Card>> GetAll(PaginationQueryObject paginationQuery, CardQueryObject cardQuery)
    {
        var cards = context.Card
            .Include(c => c.Version)
            .Include(c => c.Club)
            .Include(c => c.Position)
            .Include(c => c.Player)
            .ThenInclude(p => p.Nationality)
            .AsQueryable();
        if (cardQuery.Club != null)
        {
            cards = cards.Where(c => c.Club.Name.ToUpper().Trim().Equals(cardQuery.Club.ToUpper().Trim()));
        }
        if (cardQuery.Version != null)
        {
            cards = cards.Where(c => c.Version.Name.ToUpper().Trim().Equals(cardQuery.Version.ToUpper().Trim()));
        }
        if (cardQuery.Position != null)
        {
            cards = cards.Where(c => c.Position.Name.ToUpper().Trim().Equals(cardQuery.Position.ToUpper().Trim()));
        }
        if (cardQuery.MinOverallRating != null)
        {
            cards = cards.Where(c => c.OverallRating > cardQuery.MinOverallRating);
        }
        if (cardQuery.MaxOverallRating != null)
        {
            cards = cards.Where(c => c.OverallRating < cardQuery.MaxOverallRating);
        }
        if (cardQuery.MaxPrice != null)
        {
            cards = cards.Where(c => c.Price < cardQuery.MaxPrice);
        }
        if (cardQuery.MaxAge != null)
        {
            cards = cards.Where(c => c.Age < cardQuery.MaxAge);
        }
        var skipNumber = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
        return await cards.Skip(skipNumber).Take(paginationQuery.PageSize).ToListAsync();
    }

    public async Task<ICollection<Card>> GetByAcceleRateName(string name)
    {
        return await context.Card
            .Include(c => c.Version)
            .Include(c => c.Club)
            .Include(c => c.Position)
            .Include(c => c.Player)
            .ThenInclude(p => p.Nationality)
            .Where(c => c.AcceleRate.Name.Equals(name))
            .ToListAsync();
    }
}