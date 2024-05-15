using fc24players.Data;
using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.EntityFrameworkCore;

namespace fc24players.Repository;

public class PlayerRepository(ApplicationDbContext context) : IPlayerRepository
{
    public async Task<ICollection<Player>> GetPlayers()
    {
        return await context.Player.ToListAsync();
    }

    public async Task<Player> GetPlayerById()
    {
        throw new NotImplementedException();
    }

    public async Task<Player> GetPlayerByName()
    {
        throw new NotImplementedException();
    }
}