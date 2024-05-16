using fc24players.Models;

namespace fc24players.Interfaces;

public interface ILeagueRepository
{
    Task<ICollection<League>> GetAll();
}