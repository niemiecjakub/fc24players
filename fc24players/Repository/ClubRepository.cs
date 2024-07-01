using fc24players.Data;
using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.EntityFrameworkCore;

namespace fc24players.Repository;

public class ClubRepository(ApplicationDbContext context) : IClubRepository
{
    public async Task<ICollection<Club>>  GetAll()
    {
        return await context.Club.Include(c => c.Manager).ToListAsync();
    }
    
    public async Task<ICollection<string>> GetAllNames()
    {
        return await context.Club.Select(c => c.Name).ToListAsync();
    }
}