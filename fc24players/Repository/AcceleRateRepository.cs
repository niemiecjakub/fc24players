using fc24players.Data;
using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.EntityFrameworkCore;

namespace fc24players.Repository;

public class AcceleRateRepository(ApplicationDbContext context) : IAcceleRateRepository
{
    public async Task<ICollection<AcceleRate>> GetAll()
    {
        return await context.Accelerate.ToListAsync();
    }

    public async Task<ICollection<string>> GetAllNames()
    {
        return await context.Accelerate.Select(a => a.Name).ToListAsync();
    }

    public Task<AcceleRate?> GetByName(string name)
    {
        throw new NotImplementedException();
    }
}