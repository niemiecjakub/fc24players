using fc24players.Models;

namespace fc24players.Interfaces;

public interface IPlaystyleRepository
{
    Task<ICollection<Playstyle>> GetAll();
    Task<ICollection<string>> GetAllNames();
}