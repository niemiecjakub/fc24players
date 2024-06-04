using fc24players.Dtos;
using fc24players.Models;

namespace fc24players.Mapper;

public static class PlayerMapper
{
    public static PlayerDto ToPlayerDto(this Player player)
    {
        return new PlayerDto()
        {
            Id = player.Id,
            Name = player.Name,
            Nationality = player.Nationality.Name,
            NationalityCode = player.Nationality.Code
        };
    }
    
    public static PlayerDetailedDto ToPlayerDetailedDto(this Player player)
    {
        return new PlayerDetailedDto()
        {
            Id = player.Id,
            Name = player.Name,
            Nationality = player.Nationality.Name,
            NationalityCode = player.Nationality.Code,
            Cards = player.Cards.Select(c => c.ToCardDto()).ToList()
        };
    }
}