using fc24players.Dto.Card;
using fc24players.Models;

namespace fc24players.Mapper;

public static class CardMapper
{
    public static CardDto ToCardDto(this Card card)
    {
        return new CardDto()
        {
            Id = card.Id,
            Link = card.Link
        };
    }
}