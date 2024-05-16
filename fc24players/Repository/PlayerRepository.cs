using fc24players.Data;
using fc24players.Helpers;
using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.EntityFrameworkCore;

namespace fc24players.Repository;

public class PlayerRepository(ApplicationDbContext context) : IPlayerRepository
{
    public async Task<ICollection<Player>> GetAll(PlayerQueryObject playerQuery)
    {
        var players = context.Player
            .Include(p => p.Nationality)
            .AsQueryable();
        
        Console.WriteLine(playerQuery.Nationality);
        
        if (!string.IsNullOrEmpty(playerQuery.Nationality))
        {
            players = players.Where(p => p.Nationality.Name.ToUpper().Equals(playerQuery.Nationality.ToUpper()));
        }
        
        var skipNumber = (playerQuery.PageNumber - 1) * playerQuery.PageSize;
        return await players.Skip(skipNumber).Take(playerQuery.PageSize).ToListAsync();
    }


    public async Task<Player> GetByName()
    {
        throw new NotImplementedException();
    }
}