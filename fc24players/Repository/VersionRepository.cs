using fc24players.Data;
using fc24players.Interfaces;
using Microsoft.EntityFrameworkCore;
using Version = fc24players.Models.Version;

namespace fc24players.Repository;

public class VersionRepository(ApplicationDbContext context) : IVersionRepository
{
    public async Task<ICollection<Version>> GetAll()
    {
        return await context.Version.ToListAsync();
    }

    public async Task<ICollection<string>> GetAllNames()
    {
        return await context.Version.Select(v => v.Name).ToListAsync();
    }
}