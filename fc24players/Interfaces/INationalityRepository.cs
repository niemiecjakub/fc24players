using fc24players.Dto.Nationality;
using fc24players.Models;

namespace fc24players.Interfaces;

public interface INationalityRepository
{
    Task<ICollection<Nationality>> GetAll();
    Task<ICollection<string>> GetAllNames();
    Task<Nationality?> GetByName(string name);
}