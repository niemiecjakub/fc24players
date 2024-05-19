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
            Player = card.Player.ToPlayerDto(),
            Version = card.Version.Name,
            Club = card.Club.Name,
            Position = card.Position.Name,
            Age = card.Age,
            OverallRating = card.OverallRating,
            Price = card.Price,
            Link = card.Link
        };
    }
}