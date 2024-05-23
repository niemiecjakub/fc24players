using fc24players.Data;
using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.EntityFrameworkCore;

namespace fc24players.Repository;

public class PositionRepository(ApplicationDbContext context) : IPositionRepository
{
    public async Task<ICollection<Position>> GetAll()
    {
        return await context.Position.ToListAsync();
    }

    public async Task<ICollection<string>> GetAllNames()
    {
        return await context.Position.Select(p => p.Name).ToListAsync();
    }
}