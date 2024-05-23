using fc24players.Models;

namespace fc24players.Interfaces;

public interface IPositionRepository
{
    Task<ICollection<Position>> GetAll();
    Task<ICollection<string>> GetAllNames();
}