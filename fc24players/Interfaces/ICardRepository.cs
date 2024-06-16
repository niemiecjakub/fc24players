using fc24players.Dto.Card;
using fc24players.Helpers;
using fc24players.Models;

namespace fc24players.Interfaces;

public interface ICardRepository
{
    Task<ICollection<Card>> GetAll(PaginationQueryObject paginationQuery, CardQueryObject cardQuery);
    Task<Card> GetById(int id);
    Task<CardIdPageDto> GetIds(CursorPaginationQueryObject paginationQuery);
}