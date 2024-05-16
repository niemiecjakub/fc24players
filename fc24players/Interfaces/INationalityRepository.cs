using fc24players.Models;

namespace fc24players.Interfaces;

public interface INationalityRepository
{
    Task<ICollection<Nationality>> GetAll();
}