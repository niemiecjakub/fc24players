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

        if (paginationQuery.PageNumber != null && paginationQuery.PageSize != null)
        {
            var skipNumber = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
            return await players.Skip((int)skipNumber).Take((int)paginationQuery.PageSize).ToListAsync();
        }
        return await players.ToListAsync();
    }

    public async Task<ICollection<string>> GetAllNames()
    {
        return await context.Player.Select(p => p.Name).ToListAsync();
    }

    public async Task<Player> GetById(int id)
    {
        return await context.Player
            .Include(p => p.Nationality)
            .Include(p => p.Cards)
            .ThenInclude(c => c.Version)
            .Include(p => p.Cards)
            .ThenInclude(c => c.Club)
            .Include(p => p.Cards)
            .ThenInclude(c => c.League)
            .Include(p => p.Cards)
            .ThenInclude(c => c.Position)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}