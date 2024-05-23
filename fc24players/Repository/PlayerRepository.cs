using fc24players.Data;
using fc24players.Helpers;
using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.EntityFrameworkCore;

namespace fc24players.Repository;

public class PlayerRepository(ApplicationDbContext context) : IPlayerRepository
{
    public async Task<ICollection<Player>> GetAll(PaginationQueryObject paginationQuery, string nationality)
    {
        var players = context.Player
            .Include(p => p.Nationality)
            .AsQueryable();
        if (nationality != null)
        {
            players = players.Where(p => p.Nationality.Name.ToUpper().Trim().Equals(nationality.ToUpper().Trim()));
        }
        var skipNumber = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
        return await players.Skip(skipNumber).Take(paginationQuery.PageSize).ToListAsync();
    }

    public async Task<ICollection<string>> GetAllNames()
    {
        return await context.Player.Select(p => p.Name).ToListAsync();
    }

    public async Task<Player> GetByName()
    {
        throw new NotImplementedException();
    }
}