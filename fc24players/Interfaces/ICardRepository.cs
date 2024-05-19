using fc24players.Helpers;
using fc24players.Models;

namespace fc24players.Interfaces;

public interface ICardRepository
{
    Task<ICollection<Card>> GetAll(PaginationQueryObject paginationQuery, CardQueryObject cardQuery);
}