using fc24players.Models;

namespace fc24players.Interfaces;

public interface IClubRepository
{
    Task<ICollection<Club>> GetAll();
}