using Version = fc24players.Models.Version;

namespace fc24players.Interfaces;

public interface IVersionRepository
{
    Task<ICollection<Version>> GetAll();
    Task<ICollection<string>> GetAllNames();
}