using fc24players.Helpers;
using fc24players.Models;

namespace fc24players.Interfaces;

public interface IPlayerRepository
{
    Task<ICollection<Player>> GetAll(PlayerQueryObject playerQuery);
    Task<Player> GetByName();
}