using fc24players.Data;
using fc24players.Helpers;
using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.EntityFrameworkCore;

namespace fc24players.Repository;

public class PlayerRepository(ApplicationDbContext context) : IPlayerRepository
{
    public async Task<ICollection<Player>> GetAll(PaginationQueryObject paginationQuery)
    {
        var players = context.Player
            .Include(p => p.Nationality)
            .AsQueryable();
        
        var skipNumber = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
        return await players.Skip(skipNumber).Take(paginationQuery.PageSize).ToListAsync();
    }
    
    public async Task<Player> GetByName()
    {
        throw new NotImplementedException();
    }
}