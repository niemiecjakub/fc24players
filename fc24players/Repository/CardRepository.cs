using fc24players.Data;
using fc24players.Dto.Card;
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
        return await context.Card
            .Include(c => c.AcceleRate)
            .Include(c => c.Version)
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
    
    public async Task<CardIdPageDto> GetIds(CursorPaginationQueryObject paginationQuery)
    {
        IQueryable<Card> cards = context.Card.OrderBy(c => c.Id);
        
        int takeAmmount = paginationQuery.PageSize + 1;
        if (paginationQuery.Cursor is not null)
        {
            if (paginationQuery.IsNextPage == true)
            {
                cards = cards.Where(c => c.Id > paginationQuery.Cursor);
            }
            else
            {
                cards = cards.Where(c => c.Id < paginationQuery.Cursor).OrderByDescending(c => c.Id);
                takeAmmount = paginationQuery.PageSize;
            }
        }

        cards = cards.Take(takeAmmount);
        if (paginationQuery.IsNextPage == false && paginationQuery.Cursor is not null)
        {
            cards = cards.Reverse();
        }

        var cardIdsOnPage =  await cards.Include(c => c.Club).AsNoTracking().Select(c => c.Id).ToListAsync();
        bool isFirstPage = !paginationQuery.Cursor.HasValue || (paginationQuery.Cursor.HasValue &&
                                                                cardIdsOnPage.First() == context.Card.OrderBy(c => c.Id)
                                                                    .First().Id);

        bool hasNextPage = cardIdsOnPage.Count > paginationQuery.PageSize ||
                           (paginationQuery.Cursor is not null && paginationQuery.IsNextPage == false);

        if (cardIdsOnPage.Count > paginationQuery.PageSize)
        {
            cardIdsOnPage.RemoveAt(cardIdsOnPage.Count - 1);
        }

        int? nextId = hasNextPage ? cardIdsOnPage.Last() : null;
        int? previousId = cardIdsOnPage.Count > 0 && !isFirstPage ? cardIdsOnPage.First() : null;

        return new CardIdPageDto()
        {
            Data = cardIdsOnPage,
            NextId = nextId,
            PreviousId = previousId,
            IsFirstPage = isFirstPage
        };
    }
}