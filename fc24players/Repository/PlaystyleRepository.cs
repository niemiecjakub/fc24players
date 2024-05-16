using fc24players.Data;
using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.EntityFrameworkCore;

namespace fc24players.Repository;

public class PlaystyleRepository(ApplicationDbContext context) : IPlaystyleRepository
{
    public async Task<ICollection<Playstyle>> GetAll()
    { 
        return await context.Playstyle.ToListAsync();
    }
}