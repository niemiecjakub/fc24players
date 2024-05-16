using fc24players.Data;
using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.EntityFrameworkCore;

namespace fc24players.Repository;

public class NationalityRepository(ApplicationDbContext context) : INationalityRepository
{
    public async Task<ICollection<Nationality>> GetAll()
    {
        return await context.Nationality.ToListAsync();
    }
}