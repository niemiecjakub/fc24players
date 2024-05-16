using fc24players.Data;
using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.EntityFrameworkCore;

namespace fc24players.Repository;

public class LeagueRepository(ApplicationDbContext context) : ILeagueRepository
{
    public async Task<ICollection<League>> GetAll()
    {
        return await context.League.ToListAsync();
    }
}