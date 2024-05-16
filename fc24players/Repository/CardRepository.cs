using fc24players.Data;
using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.EntityFrameworkCore;

namespace fc24players.Repository;

public class CardRepository(ApplicationDbContext context) : ICardRepository
{
    public async Task<ICollection<Card>> GetAll()
    {
        return await context.Card.ToListAsync();
    }
}