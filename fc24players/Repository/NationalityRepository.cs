using fc24players.Data;
using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.EntityFrameworkCore;

namespace fc24players.Repository;

public class NationalityRepository(ApplicationDbContext context) : INationalityRepository
{
    public async Task<ICollection<Nationality>> GetAll()
    {
        return await context.Nationality.Include(n => n.Players).ToListAsync();
    }

    public async Task<ICollection<string>> GetAllNames()
    {
        return await context.Nationality.Select(n => n.Name).ToListAsync();
    }

    public async Task<Nationality?> GetByName(string name)
    {
        return await context.Nationality.Include(n => n.Players).FirstOrDefaultAsync(n => n.Name.ToUpper().Trim().Equals(name.ToUpper().Trim()));
    }
}