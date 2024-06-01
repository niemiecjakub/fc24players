using fc24players.Dto.Card;

namespace fc24players.Dtos;

public class PlayerDetailedDto : PlayerDto
{
    public ICollection<CardDto> Cards { get; set; }
}