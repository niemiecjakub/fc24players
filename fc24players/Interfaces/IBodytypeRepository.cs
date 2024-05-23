using fc24players.Models;

namespace fc24players.Interfaces;

public interface IBodytypeRepository
{
    Task<ICollection<Bodytype>> GetAll();
    Task<ICollection<string>> GetAllNames();
}