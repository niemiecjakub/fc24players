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
            .Include(c => c.League)
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

        if (paginationQuery.PageNumber != null && paginationQuery.PageSize != null)
        {
            var skipNumber = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
            return await cards.Skip((int)skipNumber).Take((int)paginationQuery.PageSize).ToListAsync();
        }
        return await cards.ToListAsync();
    }

    public async Task<Card> GetById(int id)
    {
        return await context.Card.Include(c => c.Version)
            .Include(c => c.Club)
            .Include(c => c.League)
            .Include(c => c.Position)
            .Include(c => c.Player)
            .ThenInclude(p => p.Nationality)
            .Include(c => c.CardBodytype)
            .ThenInclude(cb => cb.Bodytype)
            .Include(c => c.CardAltPos)
            .ThenInclude(cb => cb.Altpos)
            .Include(c => c.CardPlaystyle)
            .ThenInclude(cb => cb.Playstyle)
            .Include(c => c.CardPlayStylePlus)
            .ThenInclude(cb => cb.Playstyle)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}