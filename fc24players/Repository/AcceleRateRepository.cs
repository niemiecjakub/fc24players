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
}