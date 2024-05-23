using fc24players.Models;

namespace fc24players.Interfaces;

public interface IAcceleRateRepository
{
    Task<ICollection<AcceleRate>> GetAll();
    Task<ICollection<string>> GetAllNames();
    Task<AcceleRate?> GetByName(string name);
}