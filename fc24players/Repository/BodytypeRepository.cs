using fc24players.Data;
using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.EntityFrameworkCore;

namespace fc24players.Repository;

public class BodytypeRepository(ApplicationDbContext context) : IBodytypeRepository
{
    public async Task<ICollection<Bodytype>> GetAll()
    {
        return await context.Bodytype.ToListAsync();
    }

    public async Task<ICollection<string>> GetAllNames()
    {
        return await context.Bodytype.Select(b => b.Name).ToListAsync();
    }
}