using fc24players.Models;

namespace fc24players.Interfaces;

public interface IPlayerRepository
{
    Task<ICollection<Player>> GetPlayers();
    Task<Player> GetPlayerById();
    Task<Player> GetPlayerByName();
}