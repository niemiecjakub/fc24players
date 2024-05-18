using fc24players.Data;
using fc24players.Helpers;
using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.EntityFrameworkCore;

namespace fc24players.Repository;

public class CardRepository(ApplicationDbContext context) : ICardRepository
{
    public async Task<ICollection<Card>> GetAll(PaginationQueryObject paginationQuery)
    {
        var card = context.Card.AsQueryable();
        var skipNumber = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
        return await card.Skip(skipNumber).Take(paginationQuery.PageSize).ToListAsync();
    }
}